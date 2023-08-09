' Class: WCirculationTemplate
' Puspose: Management patron card template
' Creator: chuyenpt
' CreatedDate: 19/04/07
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCirculationTemplate
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
            ' Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not IsPostBack Then
                hdType.Value = Request.QueryString("Template")
                If hdType.Value = "" Then
                    Response.End()
                End If
                Call BindData()
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(220) Then
                btnUpdate.Enabled = False
            End If
        End Sub
        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBCT object
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCT.Initialize()
        End Sub
        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Policy/WCirculationTemplate.js'></script>")

            ddlInf.Attributes.Add("OnChange", "javascript:UsePatronInfo(document.Form1.txtContent); return false;")

            txtContent.Attributes.Add("OnClick", "javascript:storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnSelect", "javascript:storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnKeyup", "javascript:storeCaret(document.Form1.txtContent)")

            btnUpdate.Attributes.Add("OnClick", "javascript:if (!CheckNull(document.forms[0].txtTitle)) {EncryptionTags(document.forms[0].txtTitle); EncryptionTags(document.forms[0].txtContent);} else {alert('" & ddlLabel.Items(9).Text.Trim & "'); document.forms[0].txtTitle.focus(); return false;}")
            btnView.Attributes.Add("OnClick", "EncryptionTags(document.forms[0].txtTitle); EncryptionTags(document.forms[0].txtContent);PreviewCirculationTemplate(); DecryptionTags(document.forms[0].txtTitle); DecryptionTags(document.forms[0].txtContent); return false;")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemplate As New DataTable

            objBCT.TemplateID = 0
            If hdType.Value = 1 Then
                objBCT.TemplateType = 37
                lblTitleTem.Text = ddlLabel.Items(10).Text
            Else
                objBCT.TemplateType = 73
                lblTitleTem.Text = ddlLabel.Items(11).Text
            End If
            objBCT.LibID = clsSession.GlbSite
            tblTemplate = objBCT.GetTemplate()
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    hdTemplateID.Value = tblTemplate.Rows(0).Item("ID")
                    txtTitle.Text = tblTemplate.Rows(0).Item("Title")
                    txtContent.Text = tblTemplate.Rows(0).Item("Content")
                Else
                    hdTemplateID.Value = "0"
                End If
            End If
            tblTemplate = Nothing
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: Update or Create new card method
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            objBCT.TemplateID = CInt(hdTemplateID.Value)
            objBCT.Content = Replace(txtContent.Text.Trim, "'", "''")
            objBCT.LibID = clsSession.GlbSite
            objBCT.Name = Replace(txtTitle.Text.Trim, "'", "''")
            If clsSession.GlbUser & "" <> "" Then
                objBCT.Modifier = CStr(clsSession.GlbUser)
                objBCT.Creator = CStr(clsSession.GlbUser)
            Else
                objBCT.Modifier = "Emiclib"
                objBCT.Creator = "Emiclib"
            End If
            If hdType.Value = 1 Then
                objBCT.TemplateType = 37
            Else
                objBCT.TemplateType = 73
            End If
            If CInt(hdTemplateID.Value) > 0 Then
                objBCT.UpdateTemplate()
            Else
                If txtTitle.Text.Trim <> "" Or txtContent.Text.Trim <> "" Then
                    objBCT.Content = Replace(txtContent.Text.Trim, "'", "''") & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;."
                    objBCT.CreateTemplate()
                End If
            End If
            ' Alert message
            Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text.Trim & " " & ddlLabel.Items(7).Text.Trim & "');</script>")
            Call BindData()
            ' WriteLog
            Call WriteLog(120, ddlLabel.Items(5).Text & ": " & txtTitle.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Event: btnReset_Click
        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            txtContent.Text = ""
            txtTitle.Text = ""
            Call BindData()
        End Sub
        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
        End Sub
    End Class
End Namespace
