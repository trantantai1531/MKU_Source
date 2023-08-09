' Class: WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 06/09/2004
' Modification History:
' Review code : lent date: 180405

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticMonth
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
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
            Call BindJS()
            If (Page.IsPostBack = False) Then
                Call BindData()
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

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindData method
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

            If Request("Year") <> "" Then
                txtCheckOutDateFrom.Text = "01/01/" & CStr(Request("Year"))
            Else
                txtCheckOutDateFrom.Text = Session("ToDay")
            End If
            Call StatMonth()
        End Sub

        ' BindJS method
        ' Purpose: Bind javascript
        Private Sub BindJS()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "StatJs", "<script language = 'javascript' src = '../Js/Statistic/WStatistic.js'></script>", False)

            btnCancel.Attributes.Add("OnClick", "javascript:document.forms[0].txtYear.value='" & Year(Now) & "'; return false;")

            txtCheckOutDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateFrom.ToolTip = Session("DateFormat")
            txtCheckOutDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateTo.ToolTip = Session("DateFormat")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(4).Text)
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
            objBDHVLStat.LibID = clsSession.GlbSite
            objBDHVLStat.UserID = If(Session("UserID"), 0)
            objBDHVLStat.LoanMode = ddlLoanMode.SelectedValue
            If isStat Then
                result = objBDHVLStat.GetMonthStat(
                            isHistory,
                            ddlLocation.SelectedValue,
                            total,
                            txtCheckOutDateFrom.Text,
                            txtCheckOutDateTo.Text,
                            index,
                            size,
                            isOutputTotal
                        )
            Else
                result = objBDHVLStat.GetInformationAnnual(
                            isHistory,
                            ddlLocation.SelectedValue,
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

        ' ShowStat method
        ' Purpose: show statistic now
        Private Sub StatMonth()
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
                    image1.Visible = True
                    image2.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, lblVBarcharTitle.Text, lblHBarchartTitle.Text, 45, strImage, "WStatisticDay.aspx")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream

                    Dim strOutput As String
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Month")
                    strOutput = Replace(strOutput, "WStatisticDay.aspx?", "WStatisticDay.aspx?DateTime=" + Trim(txtCheckOutDateFrom.Text) + "&")
                    Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, lblPiechartTitle.Text, strImage)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCommonChart.OutPutStream
                    hidHave.Value = 1
                    lblNostatic.Visible = False
                    lblNostatic1.Visible = False

                    ' Release objects
                    arrData = Nothing
                    arrLabel = Nothing
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
            End If

            ' Static loaned
            arrData = Nothing
            arrLabel = Nothing
            keyValue = GetData(True, True, total, 0, 20)
            arrData = keyValue.Value
            arrLabel = keyValue.Key

            image3.Visible = False
            image4.Visible = False
            If Not arrData Is Nothing Then
                If UBound(arrData) >= 0 Then
                    image3.Visible = True
                    image4.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, lblVBarcharTitle.Text, lblHBarchartTitle.Text, 45, strImage, "WStatisticDay.aspx")
                    Session("chart3") = Nothing
                    Session("chart3") = objBCommonChart.OutPutStream

                    Dim strOutput As String
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Month")
                    strOutput = Replace(strOutput, "WStatisticDay.aspx?", "WStatisticDay.aspx?Year=" + Trim(txtCheckOutDateFrom.Text) + "&")

                    Response.Write("<MAP NAME=""map3"">" & strOutput & "</MAP>")

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, lblPiechartTitle.Text, strImage)
                    Session("chart4") = Nothing
                    Session("chart4") = objBCommonChart.OutPutStream
                    hidHave1.Value = 1
                    lblNostatic2.Visible = False
                    lblNostatic3.Visible = False

                    ' Release objects
                    arrData = Nothing
                    arrLabel = Nothing
                Else
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing
                End If
            Else
                Session("chart3") = Nothing
                Session("chart4") = Nothing
            End If
        End Sub

        Protected Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
            Call StatMonth()
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
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Thống kê đang mượn hàng tháng"))
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
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Thống kê từng mượn hàng tháng"))
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