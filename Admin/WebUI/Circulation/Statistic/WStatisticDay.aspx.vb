' Class: WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 06/09/2004
' Modification History:
' Review code : lent date: 180405

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticDay
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

        Private objBCommonChart As New clsBCommonChart
        Private objBUserLocation As New clsBUserLocation
        Private objBDHVLStat As New clsBDHVLStatistic

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
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

        ' BindScript method
        ' Purpose: Bind javascript
        Private Sub BindScript()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "StatisticIndexJs", "<script language = 'javascript' src = '../Js/Statistic/WStatistic.js'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WStatisticDayJs", "<script language = 'javascript' src = '../Js/Statistic/WStatisticDay.js'></script>", False)

            txtCheckOutDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateFrom.ToolTip = Session("DateFormat")
            txtCheckOutDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateTo.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(4).Text)

            btnStatic.Attributes.Add("OnClick", "return CheckStatic('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "');")
            btnCancel.Attributes.Add("OnClick", "document.forms[0].txtYear.value='" & Year(Now) & "'; document.forms[0].txtMonth.value='" & Month(Now) & "'; return false;")
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' btnStatic_Click event
        Private Sub btnStatic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatic.Click
            Call StatDay()
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

            Dim strYear As String
            Dim strMon As String
            Dim strDay As String
            If Request("Year") <> "" Then
                strYear = CStr(Request("Year"))
            Else
                strYear = Year(Now)
            End If

            If Request("Month") <> "" Then
                strMon = Request("Month")
                strDay = "01"
            Else
                strMon = Month(Now)
                strDay = Day(Now)
            End If
            txtCheckOutDateFrom.Text = strDay & "/" & strMon & "/" & strYear
            Call StatDay()
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
                result = objBDHVLStat.GetDayStat(
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

        ' BindDataFind method
        Private Sub StatDay()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String

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

            strImage = "../Images/bground.gif"
            Dim total As Integer = 0
            Dim keyValue As KeyValuePair(Of String(), Integer()) = GetData(True, False, total, 0, 50)
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
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, lblVBarcharTitle.Text, lblHBarchartTitle.Text, 45, strImage, "")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, lblPiechartTitle.Text, strImage)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCommonChart.OutPutStream
                    hidHave.Value = 1
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
            ' Static loaned
            arrData = Nothing
            arrLabel = Nothing
            keyValue = GetData(True, True, total, 0, 50)
            arrData = keyValue.Value
            arrLabel = keyValue.Key
            image3.Visible = False
            image4.Visible = False
            If Not arrData Is Nothing Then
                If UBound(arrData) > -1 Then
                    image3.Visible = True
                    image4.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, lblVBarcharTitle.Text, lblHBarchartTitle.Text, 45, strImage, "")
                    Session("chart3") = Nothing
                    Session("chart3") = objBCommonChart.OutPutStream

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, lblPiechartTitle.Text, strImage)
                    Session("chart4") = Nothing
                    Session("chart4") = objBCommonChart.OutPutStream
                    hidHave1.Value = 1
                    lblNostatic2.Visible = False
                    lblNostatic3.Visible = False
                Else
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing
                End If
            Else
                Session("chart3") = Nothing
                Session("chart4") = Nothing
            End If
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
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Thống kê đang mượn hàng ngày"))
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
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblResult, "Thống kê từng mượn hàng ngày"))
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
