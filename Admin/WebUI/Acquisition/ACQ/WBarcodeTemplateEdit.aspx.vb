' Class: WBarcodeTemplateEdit
' Puspose: Create barcode template
' Creator: Sondp
' CreatedDate: 11/02/2006
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBarcodeTemplateEdit
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
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
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
            If Not CheckPemission(87) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        End Sub

        ' BindSript method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WBarcodeTemplateEditJs", "<script language='javascript' src='../Js/ACQ/WBarcodeTemplate.js'></script>")

            ddlTemplate.Attributes.Add("OnChange", "javascript:ChangeTemplate(); return false;")

            txtContent.Attributes.Add("OnClick", "javascript:storeCaret(document.forms[0].txtContent)")
            txtContent.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtContent)")
            txtContent.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtContent)")

            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); return false;")
            btnDelete.Attributes.Add("OnClick", "javascript:return(AskDelete('" & ddlLog.Items(7).Text & "', '" & ddlLog.Items(11).Text & "'));	DecryptionTags('document.forms[0].txtContent');")
            btnUpdate.Attributes.Add("OnClick", "javascript:return(CheckValidData('" & ddlLog.Items(8).Text.Trim() & "'));	DecryptionTags('document.forms[0].txtContent');")
            btnView.Attributes.Add("OnClick", "javascript:PreviewBarcodeTemplate();DecryptionTags('document.forms[0].txtContent'); return false;")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim listItem As New ListItem

            txtTitle.Text = ""
            txtContent.Text = ""
            objBCT.TemplateID = 0
            objBCT.TemplateType = 79
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
            objBCT.TemplateType = 79
            objBCT.TemplateID = ddlTemplate.SelectedValue
            If ddlTemplate.SelectedValue > 0 Then
                objBCT.DeleteTemplate()
                Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('Xóa mẫu thành công');</script>")
            Else
                Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('Chưa chọn mẫu');</script>")
            End If
            ' WriteLog
            Call WriteLog(39, ddlLog.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call BindData()
        End Sub

        ' Delete method
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            objBCT.TemplateID = ddlTemplate.SelectedItem.Value
            If txtContent.Text <> "" Then
                objBCT.Content = Replace(txtContent.Text, "'", "").Replace(Chr(9), "")
            End If


            objBCT.Name = Replace(txtTitle.Text, "'", "")
            objBCT.Modifier = CStr(clsSession.GlbUserFullName)
            objBCT.Creator = CStr(clsSession.GlbUserFullName)
            objBCT.TemplateType = 79
            objBCT.LibID = clsSession.GlbSite
            If ddlTemplate.SelectedItem.Value > 0 Then ' Update
                Try
                    objBCT.UpdateTemplate()
                    Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'>alert('" & ddlLog.Items(9).Text.Trim & "');</script>")
                Catch ex As Exception
                    Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLog.Items(10).Text.Trim & "');</script>")
                Finally
                End Try
            Else ' Addnew
                Try
                    Dim result = objBCT.CreateTemplate()
                    If result = 1 Then
                        Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('Đã tồn tại tên mẫu ');</script>")
                    Else
                        Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLog.Items(9).Text.Trim & "');</script>")
                    End If
                Catch ex As Exception
                    Response.Write(ex.Message)
                Finally
                    ' WriteLog
                    Call WriteLog(39, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Try
            End If
            Call BindData()
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