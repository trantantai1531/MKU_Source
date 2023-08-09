'class WPackTemplateMan
'Puspose: Manage template package
'Creator: Tuanhv
'CreatedDate: 10/11/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WPackTemplateMan
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

        '***************************************DECLARE VARIABLES*******************************************
        Private objBETemplate As New clsBETemplate
        Private objBCommonTemplate As New clsBCommonTemplate
        '*************************************END DECLARE VARIABLES*****************************************

        'Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call RefreshPage()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(161) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        End Sub

        'RefreshPage method
        'Input: Type template
        'Purpose: Get name all template in database
        Private Sub RefreshPage()
            Dim tblTemplate As DataTable = Nothing
            Dim lItem As New ListItem

            'Get all template to bind to dropdownlist Caption
            objBCommonTemplate.TemplateID = 0
            objBCommonTemplate.TemplateType = 17
            tblTemplate = objBCommonTemplate.GetTemplate

            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCommonTemplate.ErrorCode)

            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                ddlFormatName.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(5).Text)
                ddlFormatName.DataTextField = "Title"
                ddlFormatName.DataValueField = "ID"
                ddlFormatName.DataBind()
            Else
                lItem.Text = ddlLabel.Items(5).Text.Trim
                lItem.Value = 0
                ddlFormatName.Items.Add(lItem)
            End If
            txtTitle.Text = ""
            txtContents.Text = ""
            ddlLocation.SelectedIndex = 0
            ddlRequestInfo.SelectedIndex = 0
            ddlOther.SelectedIndex = 0
        End Sub

        'BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'src = '../js/Tool/WPackTemplateMan.js'></script>")

            ddlLocation.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtContents,this);return false;}")
            ddlOther.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlOther.options[document.forms[0].ddlOther.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtContents,this);return false;}")
            ddlRequestInfo.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlRequestInfo.options[document.forms[0].ddlRequestInfo.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtContents,this);return false;}")
            ddlFormatName.Attributes.Add("OnChange", "javascript:parent.Hiddenbase.location.href='WTemplateLoadInfor.aspx?TemplateID='+ this.value + '&TemplateType=17&SelectPackTemplateMan=1';document.forms[0].txtTemplate.value=this.value;return false;")

            txtContents.Attributes.Add("OnClick", "javascript:storeCaret(document.forms[0].txtContents)")
            txtContents.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtContents)")
            txtContents.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtContents)")

            btnUpdate.Attributes.Add("OnClick", "javascript:EncryptionTags(); if(CheckNull(document.forms[0].txtTitle)){alert('" & ddlLabel.Items(3).Text & "'); return false;}else{return true;}")
            btnDelete.Attributes.Add("OnClick", "javascript:if(document.forms[0].ddlFormatName.options.selectedIndex==0){alert('" & ddlLabel.Items(6).Text.Trim & "'); return false;} else {if(confirm('" & ddlLabel.Items(2).Text & " ')){return true; EncryptionTags();}else{return false;}}")
            btnReset.Attributes.Add("OnClick", "javascript:ClearContent(); return false;")
            btnPreview.Attributes.Add("OnClick", "javascript:EncryptionTags(); Preview(); return false;")
            txtTitle.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ){ return false;}")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strHeader As String = ""
            objBCommonTemplate.Name = Trim(txtTitle.Text)

            strHeader = txtContents.Text.Replace(vbCrLf, "<~>")
            objBCommonTemplate.Content = strHeader
            objBCommonTemplate.TemplateType = 17
            objBCommonTemplate.Modifier = clsSession.GlbUserFullName
            objBCommonTemplate.Creator = clsSession.GlbUserFullName

            If txtTemplate.Value = 0 Then   'create new
                objBCommonTemplate.CreateTemplate()
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCommonTemplate.ErrorCode)
                Page.RegisterClientScriptBlock("InsertAlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            Else 'update
                objBCommonTemplate.TemplateID = CInt(txtTemplate.Value)
                objBCommonTemplate.UpdateTemplate()
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCommonTemplate.ErrorCode)
                Page.RegisterClientScriptBlock("UpdateAlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            End If
            'Show data
            Call RefreshPage()
        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            objBCommonTemplate.TemplateID = CInt(txtTemplate.Value)
            objBCommonTemplate.DeleteTemplate()
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCommonTemplate.ErrorCode)
            'Show data
            Call RefreshPage()
        End Sub

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Call RefreshPage()
        End Sub
        'Initialize method
        Private Sub Initialize()
            'Init objBBClaimTemplate object
            objBETemplate.ConnectionString = Session("ConnectionString")
            objBETemplate.DBServer = Session("DBServer")
            objBETemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBETemplate.Initialize()

            'Init objBCommonTemplate object
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonTemplate.Initialize()
        End Sub

        'Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        'Dispose method
        'Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBETemplate Is Nothing Then
                    objBETemplate.Dispose(True)
                    objBETemplate = Nothing
                End If
                If Not objBCommonTemplate Is Nothing Then
                    objBCommonTemplate.Dispose(True)
                    objBCommonTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
