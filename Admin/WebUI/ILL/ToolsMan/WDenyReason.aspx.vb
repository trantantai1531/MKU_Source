' Class: WDenyReason
' Puspose: Management deny reason
' Creator: Lent
' CreatedDate: 06/12/04
' Modification History:
'   - 24/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WDenyReason
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
        Private objBDenyReason As New clsBDenyReason

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            'Quan ly danh muc
            If Not CheckPemission(155) Then
                btnAddnew.Enabled = False
                dtgDenyReason.Columns(5).Visible = False
                dtgDenyReason.Columns(6).Visible = False
            End If
            'Nhap moi
            If CheckPemission(207) Then
                btnAddnew.Enabled = True
            End If
            'Xoa
            If CheckPemission(210) Then
                dtgDenyReason.Columns(6).Visible = True
            End If
            'Sua
            If CheckPemission(209) Then
                dtgDenyReason.Columns(5).Visible = True
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            'Init objBDenyReason object
            objBDenyReason.InterfaceLanguage = Session("InterfaceLanguage")
            objBDenyReason.DBServer = Session("DBServer")
            objBDenyReason.ConnectionString = Session("ConnectionString")
            Call objBDenyReason.Initialize()
        End Sub

        ' Method: BindJavascript
        ' Purpose: Include all neccessary javascript function
        Public Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnAddnew.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtCode)) {alert('" & ddlLabel.Items(3).Text & "'); document.forms[0].txtCode.focus(); return false;}")
            btnReset.Attributes.Add("Onclick", "document.forms[0].txtCode.value=''; document.forms[0].txtNameEng.value=''; document.forms[0].txtNameViet.value=''; return false;")
            btnClose.Attributes.Add("Onclick", "self.close();")
        End Sub

        ' Method: BindData
        ' Purpose: Create new deny reason
        Private Sub BindData()
            Dim tblTemp As DataTable

            txtCode.Text = ""
            txtNameEng.Text = ""
            txtNameViet.Text = ""
            objBDenyReason.LibID = clsSession.GlbSite
            tblTemp = objBDenyReason.GetDenyReason

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBDenyReason.ErrorMsg, ddlLabel.Items(0).Text, objBDenyReason.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgDenyReason.DataSource = tblTemp
                    dtgDenyReason.DataBind()
                End If
            End If
        End Sub

        ' Event: btnAddnew_Click
        ' Purpose: Addnew DeniedReason
        Private Sub btnAddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddnew.Click
            Dim intOut As Integer = 0

            objBDenyReason.Code = txtCode.Text.Trim
            objBDenyReason.EngName = txtNameEng.Text.Trim
            objBDenyReason.VietName = txtNameViet.Text.Trim
            objBDenyReason.LibID = clsSession.GlbSite
            intOut = objBDenyReason.Create()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBDenyReason.ErrorMsg, ddlLabel.Items(0).Text, objBDenyReason.ErrorCode)

            If intOut = 0 Then
                ' Alert msg
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & " " & ddlLabel.Items(6).Text & "');</script>")

                ' WriteLog
                Call WriteLog(67, ddlLabel.Items(4).Text & ": " & txtCode.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Else
                ' Alert msg
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
            End If
            Call BindData()
        End Sub

        ' Event: dtgDenyReason_ItemCreated
        Private Sub dtgDenyReason_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgDenyReason.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim cell As TableCell
                    Dim btnAction As LinkButton
                    Dim txtTemp As TextBox

                    cell = e.Item.Cells(6)
                    btnAction = cell.Controls(0)
                    txtTemp = e.Item.FindControl("dtxtCode")
                    If e.Item.ItemIndex < 34 Then
                        If Not txtTemp Is Nothing Then
                            txtTemp.ReadOnly = True
                        End If
                        btnAction.Visible = False
                    Else
                        btnAction.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabel.Items(2).Text & " ')==false) {swapBG(this,'red');return false}")
                    End If

                    cell = e.Item.Cells(5)
                    btnAction = cell.Controls(0)
                    btnAction.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].dtgDenyReason__ctl" & CStr(e.Item.ItemIndex + 2) & "_dtxtCode)) {alert('" & ddlLabel.Items(3).Text & "'); document.forms[0].dtgDenyReason__ctl" & CStr(e.Item.ItemIndex + 2) & "_dtxtCode.focus(); return false;}")
            End Select
        End Sub

        ' Event: dtgDenyReason_EditCommand
        Private Sub dtgDenyReason_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDenyReason.EditCommand
            Try
                dtgDenyReason.EditItemIndex = e.Item.ItemIndex
                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dtgDenyReason_CancelCommand
        Private Sub dtgDenyReason_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDenyReason.CancelCommand
            Try
                dtgDenyReason.EditItemIndex = -1
                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dtgDenyReason_DeleteCommand
        ' Purpose: delete selected denied reason
        Private Sub dtgDenyReason_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDenyReason.DeleteCommand
            Dim intOut As Integer

            Try
                objBDenyReason.ID = CInt(e.Item.Cells(0).Text)
                intOut = objBDenyReason.Delete()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBDenyReason.ErrorMsg, ddlLabel.Items(0).Text, objBDenyReason.ErrorCode)

                ' Alert msg
                If intOut = 0 Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & " " & ddlLabel.Items(6).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                End If

                ' WriteLog
                Call WriteLog(67, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh Data
                dtgDenyReason.EditItemIndex = -1
                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dtgDenyReason_UpdateCommand
        ' Purpose: update denied reason
        Private Sub dtgDenyReason_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDenyReason.UpdateCommand
            Dim intOut As Integer = 0

            Try
                Dim txtCode As TextBox = CType(e.Item.Cells(2).FindControl("dtxtCode"), TextBox)
                Dim txtNameEng As TextBox = CType(e.Item.Cells(3).FindControl("dtxtNameEng"), TextBox)
                Dim txtNameViet As TextBox = CType(e.Item.Cells(4).FindControl("dtxtNameViet"), TextBox)
                Dim intID As Integer

                ' Get ID
                intID = CInt(e.Item.Cells(0).Text)

                objBDenyReason.Code = txtCode.Text.Trim
                objBDenyReason.EngName = txtNameEng.Text.Trim
                objBDenyReason.VietName = txtNameViet.Text.Trim
                objBDenyReason.ID = intID

                ' Update now
                intOut = objBDenyReason.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBDenyReason.ErrorMsg, ddlLabel.Items(0).Text, objBDenyReason.ErrorCode)

                If intOut = 0 Then
                    ' Alert msg
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & " " & ddlLabel.Items(6).Text & "');</script>")

                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(4).Text & ": " & txtCode.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    dtgDenyReason.EditItemIndex = -1
                    Call BindData()
                Else
                    ' Alert msg
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                End If

            Catch ex As Exception
            End Try
        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBDenyReason Is Nothing Then
                    objBDenyReason.Dispose(True)
                    objBDenyReason = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace