Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WViewInListMode
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblCalendaView As System.Web.UI.WebControls.Label
        Protected WithEvents lnkHdSearch As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblSumPrice As System.Web.UI.WebControls.Label
        Protected WithEvents lblSum As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPeriodical As New clsBPeriodical
        Private objBCommonBussiness As New clsBCommonBusiness

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Me.ShowWaitingOnPage(ddlLabel.Items(5).Text, "../..")
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            If Not Page.IsPostBack Then
                If Trim(Request("Year")) <> "" Then
                    lblYear.Text = Trim(Request("Year"))
                Else
                    lblYear.Text = Year(Now)
                End If
                If Request("ItemID") & "" <> "" Then
                    Session("ItemID") = Request("ItemID")
                End If
                If Request("title") <> "" Then
                    Session("Title") = Request("title")
                End If
                Call BindCurrentDate()
                lnkCalendaView.NavigateUrl = "WViewInCalendarMode.aspx?Year=" & lblYear.Text & "&Switch=1"
                BindDropDownList()
                If Request("LocationID") <> 0 Then
                    Dim intIndex As Integer
                    For intIndex = 0 To ddlHoldAddress.Items.Count - 1
                        If ddlHoldAddress.Items(intIndex).Value = Request("LocationID") Then
                            ddlHoldAddress.Items(intIndex).Selected = True
                        End If
                    Next
                End If
                If ddlHoldAddress.SelectedValue <> 0 Then
                    lnkCalendaView.NavigateUrl = "WViewInCalendarMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue & "&Switch=1"
                    btnUpdateAcq.Enabled = False
                End If
                BindDataGrid()
                BindData()
                btnUpdateAcq.Attributes.Add("OnClick", "javascript:location.href='WSummaryHoldingManagement.aspx?Update=1';return false;")
                Call CheckFormPermission()
            End If
            Dim strYear As String = ""
            If hidNext.Value = 1 Then
                strYear = CInt(lblYear.Text) + 1
            ElseIf hidPrevious.Value = 1 Then
                strYear = CInt(lblYear.Text) - 1
            Else
                strYear = lblYear.Text
            End If
            lnkShowMoney.Attributes.Add("onClick", "OpenWindow('WShowInforMoney.aspx?Year=" & strYear & "&LocationID=" & ddlHoldAddress.SelectedValue & "','MoneyInfo',500,300,50,50)")
            Me.ShowWaitingOnPage("", "", True)
        End Sub

        ' CheckFormPermission method
        ' Purpose: check the user permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(93) Then
                btnUpdateAcq.Enabled = False
            Else
                btnUpdateAcq.Enabled = True
            End If
        End Sub
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            lnkNext.Attributes.Add("onclick", "document.forms[0].hidNext.value=1;")
            lnkPrevious.Attributes.Add("onclick", "document.forms[0].hidPrevious.value=1;")
        End Sub
        ' BindCurrentDate method
        ' Purpose: Display the currentDate
        Private Sub BindCurrentDate()
            lblCurrentDate.Text = Session("ToDay")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Session("ItemID") & "" = "" Then
                Response.Redirect("../WSearch.aspx?URL=Acquisition/WViewInListMode.aspx")
            End If

            ' Init for objBPeriodical
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = CInt(Session("ItemID"))
            objBPeriodical.Initialize()

            ' Init for objBCommonBussiness
            objBCommonBussiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBussiness.DBServer = Session("DBServer")
            objBCommonBussiness.ConnectionString = Session("ConnectionString")
            objBCommonBussiness.UserID = Session("UserID")
            objBCommonBussiness.ItemID = Session("ItemID")
            objBCommonBussiness.Initialize()
            'show title
            lblTitle.Text = "<H3>" & Session("Title") & "</H3>"
        End Sub

        ' BindData method
        Private Sub BindData()
            If Request("Switch") & "" <> "" And Session("Next") = 0 And Session("Previous") = 0 Then
                lblHavingIssue.Text = Session("HavingIssue")
                lblLostIssue.Text = Session("LostIssue")
                Exit Sub
            End If
            Dim intYear As Integer
            Dim intResetReg As Integer

            Dim strMonths, strHavingYearIssue, strShowHas, strShowLost, strFirstIssueInYear As String

            intYear = CInt(lblYear.Text)

            objBPeriodical.LocationID = CInt(ddlHoldAddress.SelectedValue)
            Call objBPeriodical.GetReceiveIssueNums(intYear, intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear)

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

            ' Set the default values
            clsGetIssueNos.GetHasLostIssueNo(intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear, ddlLabel.Items(6).Text, ddlLabel.Items(4).Text, ddlLabel.Items(7).Text, strShowHas, strShowLost)
            lblHavingIssue.Text = strShowHas
            lblLostIssue.Text = strShowLost
            Session("HavingIssue") = strShowHas
            Session("LostIssue") = strShowLost
        End Sub

        ' BindDropDownList method
        Private Sub BindDropDownList()
            Dim tblLocation As DataTable
            tblLocation = objBCommonBussiness.GetRoutingLocations
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBussiness.ErrorCode)

            If Not tblLocation Is Nothing Then
                tblLocation = InsertOneRow(tblLocation, Trim(ddlLabel.Items(3).Text))
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
            End If

            With ddlHoldAddress
                .DataSource = tblLocation
                .DataTextField = "LOCNAME"
                .DataValueField = "ID"
                .DataBind()
            End With
        End Sub

        ' BindDataGrid method
        Private Sub BindDataGrid()
            Dim tblItem As DataTable
            Dim intYear As Integer
            Dim strDOWs As String = ""
            Dim intFreqMode As Integer = 0
            Dim strBasedDate As String
            Dim strCeasedDate As String

            intYear = CInt(lblYear.Text)
            objBPeriodical.LocationID = ddlHoldAddress.SelectedValue
            tblItem = objBPeriodical.GetReceivedIssuesByYear(intYear, strDOWs, strBasedDate, strCeasedDate)

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

            intFreqMode = objBPeriodical.FreqMode

            'If intFreqMode = 0 Then
            '    lblLostIssue.Visible = False
            'Else
            '    lblLostIssue.Visible = True
            'End If

            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    dtgResult.Visible = True
                    dtgResult.DataSource = tblItem
                    dtgResult.DataBind()
                Else
                    dtgResult.Visible = False
                End If
            Else
                dtgResult.Visible = False
            End If

        End Sub

        ' ddlHoldAddress_SelectedIndexChanged event
        Private Sub ddlHoldAddress_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlHoldAddress.SelectedIndexChanged
            BindData()
            BindDataGrid()
            If ddlHoldAddress.SelectedValue <> 0 Then
                btnUpdateAcq.Enabled = False
                lnkCalendaView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue
            Else
                lnkCalendaView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text
                If CheckPemission(93) Then
                    btnUpdateAcq.Enabled = True
                Else
                    btnUpdateAcq.Enabled = False
                End If
            End If
        End Sub

        ' dtgResult_PageIndexChanged event
        ' Purpose: Change the page index
        Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            dtgResult.CurrentPageIndex = e.NewPageIndex
            Call BindDataGrid()
        End Sub

        ' dtgResult_ItemCreated event
        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' Declare variables
                    Dim tblCell1 As TableCell
                    Dim tblCell2 As TableCell
                    Dim lnkID As HyperLink
                    Dim lnk As HyperLink
                    Dim lbl As Label

                    tblCell1 = e.Item.Cells(0)
                    tblCell2 = e.Item.Cells(6)

                    lnkID = CType(tblCell1.FindControl("lnkIssueNum"), HyperLink)
                    lnkID.Font.Bold = True
                    lnkID.NavigateUrl = "#"
                    lnkID.Attributes.Add("onclick", "javascript:location.href='WCreateIssue.aspx?Modify=1&IssueID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';return false;")

                    lnk = CType(tblCell2.FindControl("lnkCopyNum"), HyperLink)
                    lbl = CType(tblCell2.FindControl("lblCopyNum"), Label)
                    lnk.Font.Bold = True
                    If ddlHoldAddress.SelectedValue <> 0 Then
                        lnk.Visible = True
                        lbl.Visible = False
                        ' Add the attribute for the hiperlink to change the item session to item selected
                        lnk.NavigateUrl = "#"
                        If Not DataBinder.Eval(e.Item.DataItem, "VolumeByPublisher") Is Nothing AndAlso Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "VolumeByPublisher")) Then
                            If Trim(CStr(DataBinder.Eval(e.Item.DataItem, "VolumeByPublisher"))) <> "" Then
                                lnk.Attributes.Add("onclick", "javascript:location.href='WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & lblYear.Text & "&IssueID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "&Volume=" & DataBinder.Eval(e.Item.DataItem, "VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & "';return false;")
                            Else
                                lnk.Attributes.Add("onclick", "javascript:location.href='WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & lblYear.Text & "&IssueID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & "';return false;")
                            End If
                        Else
                            lnk.Attributes.Add("onclick", "javascript:location.href='WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & lblYear.Text & "&IssueID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & "';return false;")
                        End If

                    Else
                        lbl.Visible = True
                        lnk.Visible = False
                    End If
            End Select
        End Sub

        ' lnkNext_Click event
        Private Sub lnkNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNext.Click
            lblYear.Text = CStr(CInt(lblYear.Text) + 1)
            Session("Next") = 1
            BindData()
            BindDataGrid()
            lnkCalendaView.NavigateUrl = "WViewInCalendarMode.aspx?Year=" & lblYear.Text
            If ddlHoldAddress.SelectedValue <> 0 Then
                lnkCalendaView.NavigateUrl = "WViewInCalendarMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue
            End If
            Session("Next") = 0
            hidNext.Value = 0
        End Sub

        ' lnkPrevious_Click event
        Private Sub lnkPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPrevious.Click
            lblYear.Text = CStr(CInt(lblYear.Text) - 1)
            Session("Previous") = 1
            BindData()
            BindDataGrid()
            lnkCalendaView.NavigateUrl = "WViewInCalendarMode.aspx?Year=" & lblYear.Text
            If ddlHoldAddress.SelectedValue <> 0 Then
                lnkCalendaView.NavigateUrl = "WViewInCalendarMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue
            End If
            Session("Previous") = 0
            hidPrevious.Value = 0
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
                If Not objBCommonBussiness Is Nothing Then
                    objBCommonBussiness.Dispose(True)
                    objBCommonBussiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace