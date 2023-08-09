Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticLocationIn
        Inherits clsWBase

        Private objBCommonChart As New clsBCommonChart
        Private objBUserLocation As New clsBUserLocation
        Private objBDHVLStat As New clsBDHVLStatistic


        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Page.IsPostBack = False Then
                txtCheckInDateFrom.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                txtCheckInDateTo.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                Session("chart1") = Nothing
                Session("chart2") = Nothing
                PanelStatistic.Visible = False
                Call BindData()
            End If
        End Sub

        Private Sub BindData()
            Dim tblUserLocations As DataTable
            tblUserLocations = objBUserLocation.GetHoldingCirLocationByUserID(clsSession.GlbSite, If(Session("UserID"), 0), 1, ddlLabel.Items(5).Text)
            If Not tblUserLocations Is Nothing AndAlso tblUserLocations.Rows.Count > 0 Then
                ddlLocation.DataSource = tblUserLocations
                ddlLocation.DataTextField = "Symbol"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
                ddlLocation.SelectedIndex = 0
                ddlLocation.Items(0).Value = 0
            End If
        End Sub

        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all necessary objects
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init objBUserLocation object
            objBUserLocation.ConnectionString = Session("ConnectionString")
            objBUserLocation.DBServer = Session("DBServer")
            objBUserLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBUserLocation.Initialize()

            ' Initialize objBDHVLStat object
            objBDHVLStat.InterfaceLanguage = Session("InterfaceLanguage")
            objBDHVLStat.DBServer = Session("DBServer")
            objBDHVLStat.ConnectionString = Session("ConnectionString")
            Call objBDHVLStat.Initialize()
        End Sub
        Private Sub BindJS()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script type = 'text/javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "StatJs", "<script type = 'text/javascript' src = '../Js/Statistic/WStatistic.js'></script>", False)

            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkCheckInDateFrom, txtCheckInDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkCheckInDateTo, txtCheckInDateTo, ddlLabel.Items(4).Text)
        End Sub

        ''' <summary>
        ''' Get Data Support Paging
        ''' </summary>
        ''' <param name="isStat">True If statistic else export</param>
        ''' <param name="total"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="shouldConverted">Should convert Lib Field Content Or keep it original content</param>
        ''' <returns>KeyValuePair(Of String(),Integer()) when Statistic else DataTable when export</returns>
        Private Function GetData(
                                ByVal isStat As Boolean,
                                ByRef total As Integer,
                                ByVal index As Integer,
                                ByVal size As Integer,
                                Optional shouldConverted As Boolean = True,
                                Optional isAddHeader As Boolean = False) As Object
            Dim result As Object = Nothing
            If RbtItem.Checked = True Then
                objBDHVLStat.StatOption = 0
                lblSubTitle1.Text = hidTitleChart.Value & " " & RbtItem.Text
            Else
                If RbtCopynumber.Checked = True Then
                    objBDHVLStat.StatOption = 1
                    lblSubTitle1.Text = hidTitleChart.Value & " " & RbtCopynumber.Text
                Else
                    objBDHVLStat.StatOption = 2
                    lblSubTitle1.Text = hidTitleChart.Value & " " & RbtPatron.Text
                End If
            End If
            objBDHVLStat.LibID = clsSession.GlbSite
            objBDHVLStat.UserID = If(Session("UserID"), 0)
            If isStat Then
                result = objBDHVLStat.GetCheckInLocationStat(
                            ddlLocation.SelectedValue,
                            total,
                            txtCheckInDateFrom.Text,
                            txtCheckInDateTo.Text,
                            index,
                            size
                        )
            Else
                result = objBDHVLStat.GetCheckInLocation(
                            ddlLocation.SelectedValue,
                            total,
                            txtCheckInDateFrom.Text,
                            txtCheckInDateTo.Text,
                            index,
                            size,
                            shouldConverted,
                            isAddHeader
                        )
            End If
            Return result
        End Function

        Private Sub BindStatic()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String = "../Images/bground.gif"
            Dim strVTitle As String = ddlLabel.Items(6).Text
            Dim strHTitle As String = ddlLabel.Items(5).Text
            Dim total As Integer = 0
            Dim keyValue As KeyValuePair(Of String(), Integer()) = GetData(True, total, 0, 20)
            arrData = keyValue.Value
            arrLabel = keyValue.Key
            image1.Visible = False
            image2.Visible = False
            lblNostatic.Visible = True
            lblNostatic1.Visible = True

            If Not arrData Is Nothing And Not arrLabel Is Nothing Then
                If UBound(arrData) >= 0 Then
                    image1.Visible = True
                    image2.Visible = True

                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strHTitle, strVTitle, 45, strImage, "")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCommonChart.OutPutStream
                    lblNostatic.Visible = False
                    lblNostatic1.Visible = False
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
            End If
        End Sub

        ' Event: btnCancel_Click
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            txtCheckInDateFrom.Text = ""
        End Sub

        Protected Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
            BindStatic()
            PanelStatistic.Visible = True
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Dim total As Integer = 0
                Dim tblResult As DataTable = GetData(False, total, 0, 1000, True, True)

                If Not IsNothing(tblResult) AndAlso tblResult.Rows.Count > 0 Then
                    If total > 1000 Then
                        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "DataTruncated", "alert('Dữ liệu xuất quá lớn, chỉ lấy 1000 dòng đầu tiên!')", True)
                    End If
                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Thống kê ghi trả theo từng kho"))
                    clsExport.StringBuilderToExcel(strHTMLContent)
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
                End If
            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
            End Try
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objBUserLocation Is Nothing Then
                    objBUserLocation.Dispose(True)
                    objBUserLocation = Nothing
                End If
                If Not objBDHVLStat Is Nothing Then
                    objBDHVLStat.Dispose(True)
                    objBDHVLStat = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace

