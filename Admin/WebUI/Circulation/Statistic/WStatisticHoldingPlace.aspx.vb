' class  WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 06/09/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticHoldingPlace
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblErrInput As System.Web.UI.WebControls.Label
        Protected WithEvents lblGroupName As System.Web.UI.WebControls.Label
        Protected WithEvents lblTotalLoan As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonChart As New clsBCommonChart
        Private objBUserLocation As New clsBUserLocation
        Private objBDHVLStat As New clsBDHVLStatistic


        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If rbtLibLevel.Checked Then
                divLoc.Attributes("style") = "display:none"
                divLocFilter.Attributes("style") = "display:inline-block"
                divLib.Attributes("style") = "display:block"

            Else
                divLoc.Attributes("style") = "display:block"
                divLib.Attributes("style") = "display:none"
                divLocFilter.Attributes("style") = "display:none"
            End If
            If Not Page.IsPostBack Then
                Call BindData()
                Call StatHoldingPlace()
            End If
        End Sub

        ' Initialize method
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

        ' BindScript method
        ' Purpose: Bind javascript
        Private Sub BindScript()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "StatJs", "<script language = 'javascript' src = '../Js/Statistic/WStatistic.js'></script>", False)

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(3).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(3).Text)

            btnCancel.Attributes.Add("OnClick", "document.forms[0].txtCheckOutDateFrom.value='';document.forms[0].txtCheckOutDateTo.value='';return false;")
            btnStatic.Attributes.Add("onClick", "SetLibIDs();")
        End Sub

        'BindDataLoaction method
        'Purpose: Bind location 
        Sub BindData()
            objBUserLocation.UserID = Session("UserID")
            lstLib.DataSource = objBUserLocation.GetHoldingLibrary()
            lstLib.DataTextField = "Code"
            lstLib.DataValueField = "ID"
            lstLib.DataBind()

            Dim tblResultHoldingLocation As DataTable
            tblResultHoldingLocation = objBUserLocation.GetHoldingCirLocationByUserID(clsSession.GlbSite, If(Session("UserID"), 0), 1, ddlLabel.Items(6).Text)
            If Not (tblResultHoldingLocation Is Nothing) Then
                ddlLocation.DataSource = tblResultHoldingLocation
                ddlLocation.DataTextField = "Symbol"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
                tblResultHoldingLocation.Rows.RemoveAt(0)
                lstLoc.DataSource = tblResultHoldingLocation
                lstLoc.DataTextField = "Symbol"
                lstLoc.DataValueField = "ID"
                lstLoc.DataBind()
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Statistic Day
            If Not CheckPemission(67) Then
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
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
                                ByVal isHistory As Boolean,
                                ByRef total As Integer,
                                ByVal index As Integer,
                                ByVal size As Integer,
                                Optional shouldConverted As Boolean = True,
                                Optional isAddHeader As Boolean = False,
                                Optional isOutputTotal As Boolean = False) As Object
            Dim result As Object = Nothing
            If RbtItem.Checked = True Then
                objBDHVLStat.StatOption = 0
            Else
                If RbtCopynumber.Checked = True Then
                    objBDHVLStat.StatOption = 1
                Else
                    objBDHVLStat.StatOption = 2
                End If
            End If

            Dim isLib As Integer
            Dim ids As String = ""


            If Len(ids) > 1 Then
                ids = Right(ids, Len(ids) - 1)
            End If

            If rbtLibLevel.Checked = True Then
                isLib = 0
                For intLstCount = 0 To lstLib.Items.Count - 1
                    If lstLib.Items(intLstCount).Selected Then
                        ids = ids & "," & lstLib.Items(intLstCount).Value
                    End If
                Next
            Else
                isLib = 1
                For intLstCount = 0 To lstLoc.Items.Count - 1
                    If lstLoc.Items(intLstCount).Selected Then
                        ids = ids & "," & lstLoc.Items(intLstCount).Value
                    End If
                Next
            End If
            If ids.Trim() = "" Then
                ids = Nothing
            Else
                ids = ids.Substring(1)
            End If

            objBDHVLStat.LibID = clsSession.GlbSite
            objBDHVLStat.UserID = If(Session("UserID"), 0)
            objBDHVLStat.LoanMode = ddlLoanMode.SelectedValue
            If isStat Then
                result = objBDHVLStat.GetHoldingPlaceStat(
                            isHistory,
                            isLib,
                            ddlLocation.SelectedValue,
                            ids,
                            total,
                            txtCheckOutDateFrom.Text,
                            txtCheckOutDateTo.Text,
                            index,
                            size,
                            isOutputTotal
                        )
            Else
                result = objBDHVLStat.GetHoldingPlace(
                            isHistory,
                            isLib,
                            ddlLocation.SelectedValue,
                            ids,
                            total,
                            txtCheckOutDateFrom.Text,
                            txtCheckOutDateTo.Text,
                            index,
                            size,
                            shouldConverted,
                            isAddHeader
                        )
            End If
            Return result
        End Function

        ' BindStatic method
        ' Purpose: Bind the data and draw the statistic
        Private Sub StatHoldingPlace()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String = "../Images/bground.gif"

            If RbtItem.Checked = True Then
                lblGroupTitleLoan.Text = lblFirstTitle.Text & " " & RbtItem.Text
                lblGroupTitleLoanHistory.Text = lblFirstTitle.Text & " " & RbtItem.Text
            Else
                If RbtCopynumber.Checked = True Then
                    lblGroupTitleLoan.Text = lblFirstTitle.Text & " " & RbtCopynumber.Text
                    lblGroupTitleLoanHistory.Text = lblFirstTitle.Text & " " & RbtCopynumber.Text
                Else
                    If RbtPatron.Checked = True Then
                        lblGroupTitleLoan.Text = lblFirstTitle.Text & " " & RbtPatron.Text
                        lblGroupTitleLoanHistory.Text = lblFirstTitle.Text & " " & RbtPatron.Text
                    End If
                End If
            End If

            Dim total As Integer = 0
            Dim keyValue As KeyValuePair(Of String(), Integer()) = GetData(True, False, total, 0, 20)
            arrData = keyValue.Value
            arrLabel = keyValue.Key
            image1.Visible = False
            image2.Visible = False
            hidHave.Value = 0
            hidHave1.Value = 0
            lblNostatic.Visible = True
            lblNostatic1.Visible = True
            lblNostatic2.Visible = True
            lblNostatic3.Visible = True

            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    Try
                        image1.Visible = True
                        image2.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, lblVBarcharTitle.Text, lblHBarchartTitle.Text, 0, strImage, "")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream

                        Call objBCommonChart.Makepiechart(arrData, arrLabel, lblPiechartTitle.Text, strImage)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCommonChart.OutPutStream
                        hidHave.Value = 1
                        lblNostatic.Visible = False
                        lblNostatic1.Visible = False
                    Catch
                    End Try
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
            End If
            'Static loaned
            arrData = Nothing
            arrLabel = Nothing
            keyValue = GetData(True, True, total, 0, 20)
            arrData = keyValue.Value
            arrLabel = keyValue.Key

            image3.Visible = False
            image4.Visible = False
            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    Try
                        image3.Visible = True
                        image4.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, lblVBarcharTitle.Text, lblHBarchartTitle.Text, 0, strImage, "")
                        Session("chart3") = Nothing
                        Session("chart3") = objBCommonChart.OutPutStream

                        Call objBCommonChart.Makepiechart(arrData, arrLabel, lblPiechartTitle.Text, strImage)
                        Session("chart4") = Nothing
                        Session("chart4") = objBCommonChart.OutPutStream
                        hidHave1.Value = 1
                        lblNostatic2.Visible = False
                        lblNostatic3.Visible = False
                    Catch
                    End Try
                Else
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing
                End If
            Else
                Session("chart3") = Nothing
                Session("chart4") = Nothing
            End If
        End Sub

        Private Sub btnStatic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatic.Click
            Call StatHoldingPlace()
        End Sub

        Protected Sub btnExportLoan_Click(sender As Object, e As EventArgs) Handles btnExportLoan.Click
            Try
                Dim total As Integer = 0
                Dim tblResult As DataTable = GetData(False, False, total, 0, 1000, True, True)

                If Not IsNothing(tblResult) AndAlso tblResult.Rows.Count > 0 Then
                    If total > 1000 Then
                        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "DataTruncated", "alert('Dữ liệu xuất quá lớn, chỉ lấy 1000 dòng đầu tiên!')", True)
                    End If
                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Thống kê đang mượn theo địa điểm"))
                    clsExport.StringBuilderToExcel(strHTMLContent)
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
                End If
            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
            End Try
        End Sub

        Protected Sub btnExportLoanHistory_Click(sender As Object, e As EventArgs) Handles btnExportLoanHistory.Click
            Try
                Dim total As Integer = 0
                Dim tblResult As DataTable = GetData(False, True, total, 0, 1000, True, True)

                If Not IsNothing(tblResult) AndAlso tblResult.Rows.Count > 0 Then
                    If total > 1000 Then
                        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "DataTruncated", "alert('Dữ liệu xuất quá lớn, chỉ lấy 1000 dòng đầu tiên!')", True)
                    End If
                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Thống kê từng mượn theo địa điểm"))
                    clsExport.StringBuilderToExcel(strHTMLContent)
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
                End If
            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
            End Try
        End Sub

        ' Page_Unload event
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
