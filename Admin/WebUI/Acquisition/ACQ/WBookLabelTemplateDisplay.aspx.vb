' Class: WBookLabelTemplateDisplay
' Puspose: Create Book Label Template
' Creator: Sondp
' CreatedDate: 20/02/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBookLabelTemplateDisplay
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
        Private objBCT As New clsBCommonTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            Call objBCT.Initialize()
        End Sub

        ' Method: CheckFormPermission
        Private Sub CheckFormPermission()
            If Not CheckPemission(102) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        End Sub

        ' BindSript method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WBookLabelTemplateDisplayJs", "<script language='javascript' src='../Js/ACQ/WBookLabelTemplate.js'></script>")

            ddlTemplate.Attributes.Add("OnChange", "javascript:ChangeTemplate(); return false;")

            ddlInf.Attributes.Add("OnChange", "javascript:InsertPatronContent();")

            txtContent.Attributes.Add("OnClick", "javascript:storeCaret(document.forms[0].txtContent)")
            txtContent.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtContent)")
            txtContent.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtContent)")

            'btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); return false;")
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); resetEditor(); return false;")
            btnDelete.Attributes.Add("OnClick", "javascript:return(AskDelete('" & ddlLog.Items(7).Text & "', '" & ddlLog.Items(11).Text & "'));	DecryptionTags('document.forms[0].txtContent');")
            btnUpdate.Attributes.Add("OnClick", "javascript:return(CheckValidData('" & ddlLog.Items(8).Text & "'));	DecryptionTags(document.forms[0].txtTitle);DecryptionTags('document.forms[0].txtContent');")
            btnView.Attributes.Add("OnClick", "javascript:EncryptionTags(document.forms[0].txtTitle); EncryptionTags(document.forms[0].txtContent);PreviewBookLabelTemplate();DecryptionTags('document.forms[0].txtContent'); return false;")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim listItem As New ListItem

            txtTitle.Text = ""
            txtContent.Text = ""
            objBCT.TemplateID = 0
            objBCT.TemplateType = 4
            objBCT.LibID = clsSession.GlbSite
            ddlTemplate.Items.Clear()

            Try
                tblTemplate = objBCT.GetTemplate
                If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                    ddlTemplate.DataSource = InsertOneRow(tblTemplate, ddlLog.Items(6).Text)
                    ddlTemplate.DataValueField = "ID"
                    ddlTemplate.DataTextField = "Title"
                    ddlTemplate.DataBind()
                Else
                    listItem.Value = 0
                    listItem.Text = ddlLog.Items(6).Text.Trim
                    ddlTemplate.Items.Add(listItem)
                End If
            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                If Not tblTemplate Is Nothing Then
                    tblTemplate = Nothing
                End If
            End Try
        End Sub

        ' Update or Addnew method
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            objBCT.TemplateType = 4
            If ddlTemplate.SelectedValue > 0 Then
                objBCT.TemplateID = ddlTemplate.SelectedValue
                objBCT.DeleteTemplate()
                Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'>alert('Xóa thành công');</script>")
            Else
                Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'>alert('Chưa chọn mẫu');</script>")
            End If
            fckContent.Value = ""
            ' Catch errors
            Call WriteErrorMssg(ddlLog.Items(4).Text, objBCT.ErrorMsg, ddlLog.Items(5).Text, objBCT.ErrorCode)
        
            ' WriteLog
            Call WriteLog(39, ddlLog.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call BindData()
        End Sub

        ' Delete method
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            objBCT.TemplateID = ddlTemplate.SelectedItem.Value
            objBCT.Content = Replace(fckContent.Value, "'", "''") 'objBCT.Content = Replace(txtContent.Text, "'", "").Replace(Chr(9), "")
            objBCT.Name = Replace(txtTitle.Text, "'", "")
            objBCT.Modifier = CStr(clsSession.GlbUserFullName)
            objBCT.Creator = CStr(clsSession.GlbUserFullName)
            objBCT.TemplateType = 4
            objBCT.LibID = clsSession.GlbSite
            Dim stritle = Replace(txtTitle.Text, "'", "")
            Dim strTemplateId = ddlTemplate.SelectedItem.Value
            If ddlTemplate.SelectedItem.Value > 0 Then ' Update
                Try
                    objBCT.UpdateTemplate()
                    Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'>alert('" & ddlLog.Items(9).Text.Trim & "');</script>")

                Catch ex As Exception
                    Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLog.Items(10).Text.Trim & "');</script>")
                Finally
                    ' WriteLog
                    Call WriteLog(39, ddlLog.Items(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Try

                ddlTemplate.Items.FindByValue(strTemplateId).Selected = True
                txtTitle.Text = stritle
            Else ' Addnew
                Try
                    If txtTitle.Text.Trim <> "" Or fckContent.Value.Trim <> "" Then
                        Dim intResult As Integer
                        intResult = objBCT.CreateTemplate()
                        If intResult = 1 Then
                            Page.RegisterClientScriptBlock("Exits", "<script language='javascript'>alert('" & ddlLog.Items(10).Text.Trim & "');</script>")
                            Exit Sub
                        End If
                        Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLog.Items(9).Text.Trim & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('Bạn chưa nhập đủ thông tin');</script>")
                    End If

                Catch ex As Exception
                    Response.Write(ex.Message)
                Finally
                    ' WriteLog
                    Call WriteLog(39, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Try
            End If
            fckContent.Value = ""
            Call BindData()

        End Sub

        ' Event: ddlTemplate_SelectedIndexChanged
        ' Purpose: Reload template list
        Private Sub ddlTemplate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTemplate.SelectedIndexChanged
            If ddlTemplate.SelectedIndex = 0 Then
                Response.Redirect(Request.RawUrl)
            End If

        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
        End Sub
    End Class
End Namespace