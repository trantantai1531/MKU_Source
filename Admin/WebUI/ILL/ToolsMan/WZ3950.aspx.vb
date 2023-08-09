' Class WZ3950.aspx
' Puspose: Insert, update and delete Z3950
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
' Add by : Lent
' Add date : 2/12/04

Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WZ3950
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
        Private objBZdbs As New clsBZ3950Server

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
                dtgZServer.Columns(8).Visible = False
                dtgZServer.Columns(9).Visible = False
                dtgZServer.Columns(10).Visible = False
            End If
            'Nhap moi
            If CheckPemission(207) Then
                btnAddnew.Enabled = True
            End If
            'Xoa
            If CheckPemission(210) Then
                dtgZServer.Columns(9).Visible = True
            End If
            'Sua
            If CheckPemission(209) Then
                dtgZServer.Columns(8).Visible = True
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBZdbs object
            objBZdbs.InterfaceLanguage = Session("InterfaceLanguage")
            objBZdbs.DBServer = Session("DBServer")
            objBZdbs.ConnectionString = Session("ConnectionString")
            Call objBZdbs.Initialize()
        End Sub

        ' BindJavascript method
        ' Include all neccessary javascript function
        Public Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WZ3950Js", "<script language = 'javascript' src = '../Js/ToolsMan/WZ3950.js'></script>")
            btnReset.Attributes.Add("Onclick", "javascript:document.forms[0].reset();return false;")
            btnClose.Attributes.Add("Onclick", "javascript:self.close();")
            btnAddnew.Attributes.Add("Onclick", "javascript:return CheckEmptyFieldZ3950(0);")
            txtHostName.Attributes.Add("Onchange", "if (CheckNull(this)) {alert('" & ddlLabel.Items(13).Text & "'); return false;};")
            txtAddress.Attributes.Add("Onchange", "if (CheckNull(this)) {alert('" & ddlLabel.Items(14).Text & "'); return false;};")
            txtPort.Attributes.Add("Onchange", "CheckNumBer(this,'" & ddlLabel.Items(15).Text & "');")
        End Sub

        ' BindData method
        ' Purpose: Create Z3950 server list
        Private Sub BindData()
            txtHostName.Text = ""
            txtAddress.Text = ""
            txtPort.Text = ""
            txtAccount.Text = ""
            txtPassword.Text = ""
            cbkLibPrefer.Checked = False
            dtgZServer.DataSource = objBZdbs.GetZServerList(ddlLabel.Items(9).Text)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZdbs.ErrorMsg, ddlLabel.Items(0).Text, objBZdbs.ErrorCode)
            dtgZServer.DataBind()
        End Sub

        ' Event: btnAddnew_Click
        Private Sub btnAddnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddnew.Click
            Dim intResult As Integer
            objBZdbs.Name = Trim(txtHostName.Text)
            objBZdbs.Host = Trim(txtAddress.Text)
            Try
                objBZdbs.Port = CInt(txtPort.Text)
            Catch ex As Exception
                objBZdbs.Port = 0
            End Try
            objBZdbs.Account = txtAccount.Text
            objBZdbs.Password = txtPassword.Text
            If (cbkLibPrefer.Checked) Then
                objBZdbs.Prefer = 1
            Else
                objBZdbs.Prefer = 0
            End If
            intResult = objBZdbs.CreateNew()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZdbs.ErrorMsg, ddlLabel.Items(0).Text, objBZdbs.ErrorCode)

            If intResult = 0 Then
                ' WriteLog
                Call WriteLog(67, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
            End If

            Call BindData()
        End Sub

        ' Event: dtgZServer_EditCommand
        Private Sub dtgZServer_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServer.EditCommand
            dtgZServer.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        ' Event: dtgZServer_ItemCreated
        Private Sub dtgZServer_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgZServer.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tlcTableC As TableCell
                    Dim tlcTableC2 As TableCell
                    Dim btnDeleteButton As LinkButton
                    Dim lnkdtgUpdate As LinkButton
                    Dim txtdtTemp As New TextBox
                    Dim txtdtTemp1 As New TextBox
                    Dim strError1 As String
                    Dim strError2 As String

                    txtdtTemp = CType(e.Item.FindControl("txtHostNamedtg"), TextBox)
                    If Not txtdtTemp Is Nothing Then
                        txtdtTemp.Attributes.Add("Onchange", "if (CheckNull(this)) {alert('" & ddlLabel.Items(4).Text & "'); return false;};")
                        strError1 = txtdtTemp.Text
                    End If

                    txtdtTemp1 = CType(e.Item.FindControl("txtAddressdtg"), TextBox)
                    If Not txtdtTemp1 Is Nothing Then
                        txtdtTemp1.Attributes.Add("Onchange", "if (CheckNull(this)) {alert('" & ddlLabel.Items(10).Text & "'); return false;};")
                        strError2 = txtdtTemp.Text
                    End If

                    tlcTableC = e.Item.Cells(9)
                    tlcTableC2 = e.Item.Cells(8)

                    btnDeleteButton = tlcTableC.Controls(0)
                    btnDeleteButton.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabel.Items(3).Text & " ')==false) {swapBG(this,'red');return false}")

                    lnkdtgUpdate = tlcTableC2.Controls(0)
                    If Not lnkdtgUpdate Is Nothing Then
                        lnkdtgUpdate.Attributes.Add("OnClick", "javascript:return(CheckInserUpdate('document.forms[0].dtgZServer__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(10).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dtgZServer_DeleteCommand
        Private Sub dtgZServer_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServer.DeleteCommand
            Dim intID As Integer
            Dim intOut As Integer
            ' Get ID             
            intID = CInt(e.Item.Cells(0).Text)
            'Delete here
            objBZdbs.ServerID = intID
            intOut = objBZdbs.Delete()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZdbs.ErrorMsg, ddlLabel.Items(0).Text, objBZdbs.ErrorCode)
            If intOut > 0 Then
                Page.RegisterClientScriptBlock("Alert6Msg", "<script language='javascript'>alert('" & ddlLabel.Items(16).Text & "');</script>")
            End If
            ' WriteLog
            Call WriteLog(67, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Refresh Data
            dtgZServer.EditItemIndex = -1
            Call BindData()
        End Sub

        Private Sub dtgZServer_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServer.UpdateCommand
            ' Get data to update
            Dim intResult As Integer
            Dim ttxtHostName As TextBox = CType(e.Item.Cells(2).FindControl("txtHostNamedtg"), TextBox)
            Dim ttxtAddress As TextBox = CType(e.Item.Cells(3).FindControl("txtAddressdtg"), TextBox)
            Dim ttxtPort As TextBox = CType(e.Item.Cells(4).FindControl("dtxtPort"), TextBox)
            Dim ttxtAccount As TextBox = CType(e.Item.Cells(5).FindControl("dtxtAccount"), TextBox)
            Dim ttxtPassword As TextBox = CType(e.Item.Cells(6).FindControl("dtxtPassword"), TextBox)
            Dim tcbkLibPrefer As CheckBox = CType(e.Item.Cells(7).FindControl("dcbkLibPrefer"), CheckBox)

            If ttxtHostName.Text <> "" And ttxtAddress.Text <> "" Then
                objBZdbs.Name = ttxtHostName.Text
                objBZdbs.Host = ttxtAddress.Text
                Try
                    objBZdbs.Port = CInt(ttxtPort.Text)
                Catch ex As Exception
                    objBZdbs.Port = 0
                End Try
                objBZdbs.Account = ttxtAccount.Text
                objBZdbs.Password = ttxtPassword.Text
                objBZdbs.ServerID = CInt(e.Item.Cells(0).Text)
                If (tcbkLibPrefer.Checked) Then
                    objBZdbs.Prefer = 1
                Else
                    objBZdbs.Prefer = 0
                End If
                intResult = objBZdbs.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZdbs.ErrorMsg, ddlLabel.Items(0).Text, objBZdbs.ErrorCode)

                If intResult = 0 Then
                    ' WriteLog
                    Call WriteLog(67, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
                    ' Refrehs Data
                    dtgZServer.EditItemIndex = -1
                    Call BindData()
                Else
                    Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                End If
            End If
        End Sub

        ' Event: dtgZServer_CancelCommand
        Private Sub dtgZServer_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgZServer.CancelCommand
            dtgZServer.EditItemIndex = -1
            Call BindData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBZdbs Is Nothing Then
                    objBZdbs.Dispose(True)
                    objBZdbs = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
