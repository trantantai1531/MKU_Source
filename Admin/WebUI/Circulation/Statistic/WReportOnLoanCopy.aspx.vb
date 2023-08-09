' Class: WReportOnLoan
' Puspose: Get Patron on loan
' Creator: Tuanhv
' CreatedDate: 31/08/2004
' Modify history: Modify by: Lent, Tuanhv (19/04/2005 - review and update)

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WReportOnLoanCopy
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
        Private objBUserLocation As New clsBUserLocation
        Private objBDHVLStat As New clsBDHVLStatistic

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call InitializeVisible()
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
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

        Private Sub InitializeVisible()
            lblTitleDataGrid.Visible = False
            lblNothing.Visible = False
            dtgLoan.Visible = False
        End Sub

        Private Sub BindJS()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CheckDateSetForcus", "<script type = 'text/javascript' src = '../Js/Statistic/WReportOnLoanCopy.js'></script>", False)

            btnFind.Attributes.Add("onClick", "return CheckValidDate('" & ddlLabel.Items(4).Text & "')")
            btnCancel.Attributes.Add("onclick", "return ResetForm();")

            txtCheckOutDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateFrom.ToolTip = Session("DateFormat")
            txtCheckOutDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateTo.ToolTip = Session("DateFormat")
            txtCheckInDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckInDateFrom.ToolTip = Session("DateFormat")
            txtCheckInDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtCheckInDateTo.ToolTip = Session("DateFormat")

            'Register Calendar
            Me.RegisterCalendar("../..")

            'Register link
            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkDueDateFrom, txtCheckInDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkDueDateTo, txtCheckInDateTo, ddlLabel.Items(4).Text)
        End Sub

        Sub BindData()
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

        Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
            dtgLoan.CurrentPageIndex = 0
            Call UpdateGrid(dtgLoan.CurrentPageIndex, dtgLoan.PageSize)
        End Sub

        ''' <summary>
        ''' Get Data report for current loan
        ''' </summary>
        ''' <param name="total"></param>
        ''' <param name="index"></param>
        ''' <param name="size"></param>
        ''' <param name="shouldConverted">Should convert Lib Field Content Or keep it original content</param>
        ''' <param name="isAddHeader">Export file only</param>
        ''' <param name="isOutputTotal">Should get total item or not</param>
        ''' <returns></returns>
        Private Function GetData(ByRef total As Integer,
                                 ByVal index As Integer?,
                                 ByVal size As Integer?,
                                 Optional shouldConverted As Boolean = True,
                                 Optional isAddHeader As Boolean = False,
                                 Optional isOutputTotal As Boolean = False) As DataTable

            Dim tblData As DataTable = Nothing
            objBDHVLStat.LibID = clsSession.GlbSite
            objBDHVLStat.UserID = If(Session("UserID"), 0)
            tblData = objBDHVLStat.GetReportOnLoanCopy(
                            ddlLocation.SelectedValue,
                            txtPatronCode.Text,
                            txtCopyNumber.Text,
                            txtItemCode.Text,
                            total,
                            txtCheckOutDateFrom.Text,
                            txtCheckOutDateTo.Text,
                            txtCheckInDateFrom.Text,
                            txtCheckInDateTo.Text,
                            index,
                            size,
                            shouldConverted,
                            isAddHeader,
                            isOutputTotal
                        )
            Return tblData
        End Function

        Private Sub UpdateGrid(Optional index As Integer = 0, Optional size As Integer = 10)
            Dim tblCreateOnloanReport As DataTable
            Try
                Dim total As Integer = 0
                tblCreateOnloanReport = GetData(total, index, size, True, False, True)
                dtgLoan.Visible = False
                lblNothing.Visible = True
                lblTitleDataGrid.Visible = True
                lblTotal.Text = 0
                If Not tblCreateOnloanReport Is Nothing AndAlso tblCreateOnloanReport.Rows.Count > 0 Then
                    lblTitleDataGrid.Visible = True
                    dtgLoan.Visible = True
                    lblNothing.Visible = False
                    dtgLoan.VirtualItemCount = total
                    dtgLoan.DataSource = tblCreateOnloanReport
                    dtgLoan.DataBind()
                    lblTotallb.Visible = True
                    lblTotal.Visible = True
                    lblTotal.Text = total
                End If
            Catch ex As Exception
                WriteLog(0, ex.Message, "", "", "")
            End Try
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Dim total As Integer = 0
                Dim tblData As DataTable = GetData(total, Nothing, Nothing, True, True, False)
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                    'If total > 1000 Then
                    '    ClientScript.RegisterClientScriptBlock(Me.GetType(), "DataTruncated", "alert('Dữ liệu xuất quá lớn, chỉ lấy 1000 dòng đầu tiên!')", True)
                    'End If
                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblData, "Thông tin ấn phẩm đang mượn"))
                    clsExport.StringBuilderToExcel(strHTMLContent)
                Else
                    ClientScript.RegisterClientScriptBlock(Me.GetType(), "NoDataExport", "alert('Không có dữ liệu để xuất!')", True)
                End If
            Catch ex As Exception
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "ErrorOnDataExport", "alert('Có lỗi xảy ra trong quá trình xuất dữ liệu!')", True)
            End Try
        End Sub

        Private Sub dtgLoan_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgLoan.PageIndexChanged
            dtgLoan.CurrentPageIndex = e.NewPageIndex
            Call UpdateGrid(dtgLoan.CurrentPageIndex, dtgLoan.PageSize)
        End Sub

        Private Sub dtgLoan_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dtgLoan.ItemDataBound
            If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim lblSTT As Label = DirectCast(e.Item.FindControl("lblSTT"), Label)
                lblSTT.Text = 1 + e.Item.ItemIndex + DirectCast(sender, DataGrid).CurrentPageIndex * DirectCast(sender, DataGrid).PageSize
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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