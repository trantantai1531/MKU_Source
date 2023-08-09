' Class: WCardTemplate
' Puspose: Management patron card template
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCardTemplate
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
            If Not IsPostBack Then
                Call BindData()
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

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(55) Then
                btnUpdate.Enabled = False
            End If
            If Not CheckPemission(56) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WCardTemplate.js'></script>")

            ddlTemplate.Attributes.Add("onchange", "LoadTemplate(); return false;")
            'ddlInf.Attributes.Add("OnChange", "javascript:UsePatronInfo(document.Form1.txtContent); return false;")
            ddlInf.Attributes.Add("OnChange", "javascript:InsertPatronContent();")

            'txtContent.Attributes.Add("OnClick", "javascript:storeCaret(document.Form1.txtContent)")
            'txtContent.Attributes.Add("OnSelect", "javascript:storeCaret(document.Form1.txtContent)")
            'txtContent.Attributes.Add("OnKeyup", "javascript:storeCaret(document.Form1.txtContent)")

            btnUpdate.Attributes.Add("OnClick", "javascript:if (!CheckNull(document.forms[0].txtTitle)) {EncryptionTags(document.forms[0].txtTitle); EncryptionTags(document.forms[0].txtContent);} else {alert('" & ddlLabel.Items(9).Text.Trim & "'); document.forms[0].txtTitle.focus(); return false;}")
            btnView.Attributes.Add("OnClick", "EncryptionTags(document.forms[0].txtTitle); EncryptionTags(document.forms[0].txtContent);PreviewCard(); DecryptionTags(document.forms[0].txtTitle); DecryptionTags(document.forms[0].txtContent); return false;")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); resetEditor(); return false;")
            btnDelete.Attributes.Add("OnClick", "javascript:if (document.forms[0].ddlTemplate.value !=0) {if(confirm('" & ddlLabel.Items(4).Text & "')){EncryptionTags(document.forms[0].txtTitle);EncryptionTags(document.forms[0].txtContent); return true;} else {return false;}} else {alert('" & ddlLabel.Items(8).Text.Trim & "'); return false;}")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim lsItem As New ListItem

            objBCT.TemplateID = 0
            objBCT.TemplateType = 5
            tblTemplate = objBCT.GetTemplate()

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCT.ErrorMsg, ddlLabel.Items(1).Text, objBCT.ErrorCode)

            If Not tblTemplate Is Nothing Then
                ddlTemplate.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(3).Text)
                ddlTemplate.DataTextField = "Title"
                ddlTemplate.DataValueField = "ID"
                ddlTemplate.DataBind()
            Else
                lsItem.Value = "0"
                lsItem.Text = ddlLabel.Items(3).Text
                ddlTemplate.Items.Add(lsItem)
            End If
            lsItem = Nothing
            tblTemplate = Nothing
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: Update or Create new card method
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intResult As Integer

            objBCT.TemplateID = ddlTemplate.SelectedItem.Value.ToString
            objBCT.Content = Replace(fckContent.Value, "'", "''") ' Replace(txtContent.Text.Trim, "'", "''")
            objBCT.Name = Replace(txtTitle.Text.Trim, "'", "''")
            If clsSession.GlbUser & "" <> "" Then
                objBCT.Modifier = CStr(clsSession.GlbUser)
                objBCT.Creator = CStr(clsSession.GlbUser)
            Else
                objBCT.Modifier = "eMicLib"
                objBCT.Creator = "eMicLib"
            End If
            objBCT.TemplateType = 5
            If ddlTemplate.SelectedItem.Value > 0 Then
                If Not CheckPemission(56) Then
                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(2).Text)
                Else
                    objBCT.UpdateTemplate()

                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCT.ErrorMsg, ddlLabel.Items(1).Text, objBCT.ErrorCode)

                    Call btnReset_Click(sender, e)
                End If
            Else
                If txtTitle.Text.Trim <> "" Or fckContent.Value.Trim <> "" Then ' Or txtContent.Text.Trim <> "" Then
                    If Not CheckPemission(55) Then
                        ' Write error
                        Call WriteErrorMssg(ddlLabel.Items(2).Text)
                    Else
                        intResult = objBCT.CreateTemplate()
                        If intResult = 1 Then
                            Page.RegisterClientScriptBlock("Exits", "<script language='javascript'>alert('" & ddlLabel.Items(10).Text.Trim & "');</script>")
                            Exit Sub
                        End If
                        ' Write error
                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCT.ErrorMsg, ddlLabel.Items(1).Text, objBCT.ErrorCode)

                        Call btnReset_Click(sender, e)
                    End If
                End If
            End If
            ' Alert message
            Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text.Trim & " " & ddlLabel.Items(7).Text.Trim & "');</script>")

            ' WriteLog
            Call WriteLog(120, ddlLabel.Items(5).Text & ": " & txtTitle.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Event: btnReset_Click
        Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
            fckContent.Value = "" 'txtContent.Text = ""
            txtTitle.Text = ""
            Call BindData()
        End Sub

        ' Event: btnDelete_Click
        ' Purpose: Delete patroncard template
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            If ddlTemplate.SelectedItem.Value > 0 Then
                objBCT.TemplateType = 5
                objBCT.TemplateID = ddlTemplate.SelectedItem.Value.ToString
                Call objBCT.DeleteTemplate()

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCT.ErrorMsg, ddlLabel.Items(1).Text, objBCT.ErrorCode)

                Call btnReset_Click(sender, e)

                ' WriteLog
                Call WriteLog(120, ddlLabel.Items(6).Text & ": " & txtTitle.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text.Trim & " " & ddlLabel.Items(7).Text.Trim & "');</script>")
            End If
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