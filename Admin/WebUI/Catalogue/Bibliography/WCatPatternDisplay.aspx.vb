Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPatternDisplay
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

        Private objBCommonTemplate As New clsBCommonTemplate

        ' Pahge Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        'Methord: Initialize
        Public Sub Initialize()
            'Object objBCommonTemplate 
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonTemplate.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            ' Register Javascript (common and self JS)
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("PatternCatalogueJs", "<script language='javascript' src='../js/Bibliography/WCatPatternCatalogue.js'></script>")

            ' Send selected TemplateID to form WCatPatternHidden.aspx
            ddlTemplate.Attributes.Add("Onchange", "if (this.value=='' || this.value==0) {document.forms[0].hidTemplate.value=0} else{document.forms[0].hidTemplate.value=this.options[this.selectedIndex].value};parent.Hidden.location.href='WCatPatternHidden.aspx?ID=' + document.forms[0].hidTemplate.value;CheckPermission();return false;")
            txtContent.Attributes.Add("OnClick", "storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnSelect", "storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnKeyup", "storeCaret(document.Form1.txtContent)")

            ' Preview catalogue template
            btnView.Attributes.Add("OnClick", "return(PreviewIt());")

            ' Clear all textbox on the form
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset();document.forms[0].txtTitle.focus();return false;")

            ' Don't Delete if Combobox's Value is "Them moi"
            btnDelete.Attributes.Add("OnClick", "if(document.forms[0].hidTemplate.value==0){alert('Chưa chọn mẫu cần xóa');return false;} else{return(Message('" & ddlLabel.Items(0).Text & "'));Decryptions();}")

            ' Update data:if Combobox's Value is "Add New" then AddNew
            btnAddField.Attributes.Add("OnClick", "Encryptions();return(CheckValidData('" & ddlLabel.Items(4).Text & "'));Decryptions();")
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            ' AddNew right
            If Not CheckPemission(13) Then
                hidAddRight.Value = 0
                btnAddField.Enabled = False
            Else
                hidAddRight.Value = 1
                btnAddField.Enabled = True
            End If
            ' Update right
            If Not CheckPemission(14) Then
                hidUpdateRight.Value = 0
            Else
                hidUpdateRight.Value = 1
            End If
            ' Delete right
            If Not CheckPemission(15) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' BindData method-Load data into ComboBox
        Private Sub BindData()
            ' Declare variables
            Dim tblTemp As DataTable = Nothing
            Dim lsItem As New ListItem

            objBCommonTemplate.TemplateID = 0

            'The type of the Item called "Danh muc"
            objBCommonTemplate.TemplateType = 1
            objBCommonTemplate.LibID = clsSession.GlbSite
            tblTemp = objBCommonTemplate.GetTemplate
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                'Load data into ComboBox
                ddlTemplate.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlTemplate.DataTextField = "Title"
                ddlTemplate.DataValueField = "ID"
                ddlTemplate.DataBind()
            Else
                'Default -No select: Load String "--Them moi--"
                lsItem.Text = ddlLabel.Items(14).Text
                lsItem.Value = 0
                ddlTemplate.Items.Add(lsItem)
            End If

            'clear all Textbox when form load or reload
            txtContent.Text = ""
            txtTitle.Text = ""
            txtHeader.Text = ""
            txtFooter.Text = ""
        End Sub

        ' btnDelete_Click event
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            objBCommonTemplate.TemplateType = 1 'Template type
            objBCommonTemplate.TemplateID = hidTemplate.Value
            objBCommonTemplate.DeleteTemplate()
            ' Write Log
            Call WriteLog(85, ddlLabel.Items(13).Text & ddlLabel.Items(8).Text & hidTemplate.Value & ":" & hidTemplateName.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Alert message
            Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(15).Text.Trim & "');</script>")

            hidTemplate.Value = 0
            Call BindData()
        End Sub

        ' btnAddField_Click event
        Private Sub btnAddField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddField.Click
            Dim strTemplateContent, strTemplateTitle As String

            ' Header
            If Not IsDBNull(txtHeader.Text) Then
                txtHeader.Text = txtHeader.Text.Replace("'", "<!--`-->").Replace(Chr(9), "") & Chr(9)
            End If

            ' Content
            If Not IsDBNull(txtContent.Text) Then
                txtContent.Text = txtContent.Text.Replace("'", "<!--`-->").Replace(Chr(9), "") & Chr(9)
            End If

            ' Footer
            If Not IsDBNull(txtFooter.Text) Then
                txtFooter.Text = txtFooter.Text.Replace("'", "<!--`-->").Replace(Chr(9), "") & Chr(9)
            End If

            ' Title
            If Not IsDBNull(txtTitle.Text) Then
                txtTitle.Text = txtTitle.Text.Replace("'", "<!--`-->") & Chr(9)
            End If

            ' Update or insert template
            objBCommonTemplate.TemplateID = hidTemplate.Value
            objBCommonTemplate.Content = txtHeader.Text & txtContent.Text & txtFooter.Text
            objBCommonTemplate.Name = txtTitle.Text
            objBCommonTemplate.Modifier = CStr(clsSession.GlbUserFullName)
            objBCommonTemplate.Creator = CStr(clsSession.GlbUserFullName)
            objBCommonTemplate.LibID = clsSession.GlbSite
            objBCommonTemplate.TemplateType = 1

            If Not hidTemplate.Value = 0 Then  ' Update
                objBCommonTemplate.UpdateTemplate()
                ' Write log
                Call WriteLog(85, ddlLabel.Items(13).Text & ddlLabel.Items(7).Text & Trim(hidTemplate.Value) & " : " & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("UpdateAlertJs", "<script language='javascript'>alert(' " & ddlLabel.Items(2).Text & " ');</script>")
            Else ' Insert
                Dim result = objBCommonTemplate.CreateTemplate()
                ' Write log
                Call WriteLog(85, ddlLabel.Items(13).Text & ddlLabel.Items(6).Text & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                If result = 1 Then
                    ' Alert message
                    Page.RegisterClientScriptBlock("UpdateAlertJs", "<script language='javascript'>alert(' Mẫu danh mục đã tồn tại ');</script>")
                Else
                    Page.RegisterClientScriptBlock("UpdateAlertJs", "<script language='javascript'>alert(' " & ddlLabel.Items(2).Text & " ');</script>")
                End If
            End If
            hidTemplate.Value = 0
            Call BindData()
        End Sub

        'Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonTemplate Is Nothing Then
                    objBCommonTemplate.Dispose(True)
                    objBCommonTemplate = Nothing
                End If
                ' Call Dispose on your base class.
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace