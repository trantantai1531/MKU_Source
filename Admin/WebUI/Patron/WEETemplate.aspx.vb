' Class: WEETemplate
' Puspose: Management export template
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 13/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WEETemplate
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblAddNew As System.Web.UI.WebControls.Label
        Protected WithEvents lblConfirmDelete As System.Web.UI.WebControls.Label
        Protected WithEvents lblEmtyTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddNewSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddNewUnSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblActionFail As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPT As New clsBPatronTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(216) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub
        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPT object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPT.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WEETemplateJs", "<script language = 'javascript' src = 'js/WExportTemplate.js'></script>")

            ddlTemplate.Attributes.Add("onchange", "parent.hiddenbase.location.href='WEHTemplate.aspx?TemplateID=' + document.forms[0].ddlTemplate.options[forms[0].ddlTemplate.selectedIndex].value; return false;")
            ddlInf.Attributes.Add("OnChange", "UsePatronInfo(document.Form1.txtContent); return false;")

            txtContent.Attributes.Add("OnClick", "storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnSelect", "storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnKeyup", "storeCaret(document.Form1.txtContent)")

            btnUpdate.Attributes.Add("OnClick", "EncryptionTags(); return(CheckUpdate('" & ddlLabel.Items(5).Text & "'));")
            btnDelete.Attributes.Add("OnClick", "EncryptionTags(); return(ConfirmDelete('" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(13).Text & "'));")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return(false);")
            btnView.Attributes.Add("OnClick", "EncryptionTags();PreviewCard();DecryptionTags(); return false;")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim lsItem As New ListItem

            txtContent.Text = ""
            txtTitle.Text = ""
            objBPT.TemplateID = 0
            objBPT.TemplateType = 31
            tblTemplate = objBPT.GetPatronTemplate

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPT.ErrorMsg, ddlLabel.Items(1).Text, objBPT.ErrorCode)

            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
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

        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Try
                If ddlTemplate.SelectedItem.Value > 0 Then
                    objBPT.TemplateType = 31
                    objBPT.TemplateID = ddlTemplate.SelectedItem.Value.ToString
                    objBPT.Delete()

                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPT.ErrorMsg, ddlLabel.Items(1).Text, objBPT.ErrorCode)

                    ' WriteLog
                    Call WriteLog(119, ddlLabel.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Refresh data
                    Call BindData()

                    ' Alert message
                    Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text.Trim & " " & ddlLabel.Items(12).Text.Trim & "');</script>")
                End If
            Catch ex As Exception
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & " " & ex.Message & "');</script>")
            End Try
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intResult As Integer
            Try
                objBPT.TemplateID = ddlTemplate.SelectedItem.Value.ToString
                If txtContent.Text.Trim <> "" Then
                    objBPT.Content = Replace(txtContent.Text.Trim, "'", "''").Replace(Chr(9), "")
                Else
                    objBPT.Content = ""
                End If

                objBPT.Name = Replace(txtTitle.Text.Trim, "'", "''")
                objBPT.Modifier = CStr(clsSession.GlbUserFullName)
                objBPT.Creator = CStr(clsSession.GlbUserFullName)
                objBPT.TemplateType = 31
                If ddlTemplate.SelectedItem.Value > 0 Then ' Update
                    objBPT.Update()

                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPT.ErrorMsg, ddlLabel.Items(1).Text, objBPT.ErrorCode)

                    ' WriteLog
                    Call WriteLog(119, ddlLabel.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Else ' Addnew
                    intResult = objBPT.Create()
                    If intResult = 1 Then
                        Page.RegisterClientScriptBlock("Exits", "<script language='javascript'>alert('" & ddlLabel.Items(14).Text.Trim & "');</script>")
                        Exit Sub
                    End If
                    ' Write error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPT.ErrorMsg, ddlLabel.Items(1).Text, objBPT.ErrorCode)

                    ' WriteLog
                    Call WriteLog(119, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If
                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(10).Text.Trim & " " & ddlLabel.Items(12).Text.Trim & "');</script>")
            Catch ex As Exception
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & " " & ex.Message & "');</script>")
            End Try
            Call BindData()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPT Is Nothing Then
                objBPT.Dispose(True)
                objBPT = Nothing
            End If
        End Sub
    End Class
End Namespace