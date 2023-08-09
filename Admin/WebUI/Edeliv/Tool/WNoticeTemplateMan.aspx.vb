'Class WRefuseTemplateMan
'Puspose: Manage template notice
'Creator: Tuanhv
'CreatedDate: 10/11/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WNoticeTemplateMan
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
        Private objBCDBS As New clsBCommonDBSystem

        '*************************************END DECLARE VARIABLES*****************************************

        'Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            'Init alls object 
            Call Initialize()
            'Bind javascript
            Call BindScript()
            If Not Page.IsPostBack Then
                'Show data
                Call BindData()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(161) Then
                Call WriteErrorMssg(lblLabel4.Text)
            End If
        End Sub

        'Method: BindData
        'Purpose: BindData to all controls
        Private Sub BindData()
            Dim tblAddInformation As DataTable
            Dim tblCollums As DataTable
            Dim arrTextField() As String
            Dim arrValueField() As String
            Call RefreshPage()

            'Create table contain all column priew
            arrTextField = lblCollumText.Text.Split(",")
            arrValueField = lblCollumValue.Text.Split(",")
            tblAddInformation = objBCDBS.CreateTable(arrTextField, arrValueField)

            'Get all column can priview 
            lsbTemp.DataSource = tblAddInformation
            lsbTemp.DataTextField = "TextField"
            lsbTemp.DataValueField = "ValueField"
            lsbTemp.DataBind()
            lsbAllCollums.DataSource = tblAddInformation
            lsbAllCollums.DataTextField = "TextField"
            lsbAllCollums.DataValueField = "ValueField"
            lsbAllCollums.DataBind()
            ddlHeadRequestInfo1.SelectedIndex = 0
            ddlFootRequestInfo.SelectedIndex = 0
        End Sub

        'RefreshPage method
        'Input: Type template
        'Purpose: Get name all template in database
        Private Sub RefreshPage()
            Dim tblTemplate As DataTable = Nothing
            Dim lItem As New ListItem
            'Get all template to bind to dropdownlist Caption
            objBCommonTemplate.TemplateID = 0
            objBCommonTemplate.TemplateType = 20
            tblTemplate = objBCommonTemplate.GetTemplate
            Call WriteErrorMssg(lblLabel3.Text, objBCommonTemplate.ErrorMsg, lblLabel2.Text, objBCommonTemplate.ErrorCode)
            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                tblTemplate = InsertOneRow(tblTemplate, lblAddNewFormat.Text)
                ddlFormatName.DataSource = tblTemplate
                ddlFormatName.DataTextField = "Title"
                ddlFormatName.DataValueField = "ID"
                ddlFormatName.DataBind()
            Else
                lItem.Text = lblAddNewFormat.Text
                lItem.Value = 0
                ddlFormatName.Items.Add(lItem)
            End If

            txtTitle.Text = ""
            txtAlign.Text = ""
            txtCollumCaption.Text = ""
            txtCollum.Value = 0
            txtCollumWidth.Text = ""
            txtFooter.Text = ""
            txtHeader.Text = ""
            txtFormat.Text = ""
            txtTemplate.Value = 0
            txtFormat.Text = ""
            hdCollumCaptionText.Value = ""
            hdMax.Value = 0
            ddlFootRequestInfo.SelectedIndex = 0
            ddlHeadRequestInfo1.SelectedIndex = 0
        End Sub

        'BindScript method
        Private Sub BindScript()

            'Add information for header template
            ddlHeadRequestInfo1.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlHeadRequestInfo1.options[document.forms[0].ddlHeadRequestInfo1.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtHeader,this);return false;}")
            txtHeader.Attributes.Add("OnClick", "javascript:storeCaret(document.forms[0].txtHeader)")
            txtHeader.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtHeader)")
            txtHeader.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtHeader)")

            'Add information for footer template
            ddlFootRequestInfo.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlFootRequestInfo.options[document.forms[0].ddlFootRequestInfo.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtFooter,this);return false;}")
            txtFooter.Attributes.Add("OnClick", "javascript:storeCaret(document.forms[0].txtFooter)")
            txtFooter.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtFooter)")
            txtFooter.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtFooter)")
            txtTitle.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ){ return false;}")
            'Add column priview
            btnAdd.Attributes.Add("OnClick", "javascript:AddItem();return(false);")

            'Remove column priview
            btnRemove.Attributes.Add("OnClick", "javascript:RemoveItem();return(false);")

            'Update database
            btnUpdate.Attributes.Add("OnClick", "javascript:AddItem();EncryptionTags();if(document.forms[0].txtTitle.value==''){alert('" & lblEmtyCaption.Text & "');return(false);}else{return(true);}")

            'Delete database
            btnDelete.Attributes.Add("OnClick", "javascript:EncryptionTags();if(document.forms[0].ddlFormatName.options[document.forms[0].ddlFormatName.options.selectedIndex].value==0){return(false);}else{if(confirm('" & lblConfirmDelete.Text & " ')){return(true);}else{return(false);}}")

            'Change template script
            ddlFormatName.Attributes.Add("OnChange", "javascript:parent.Hiddenbase.location.href='WTemplateLoadInfor.aspx?TemplateID='+ this.value + '&TemplateType=20';document.forms[0].txtTemplate.value=this.value;return(false);")

            'Preview temp select 
            btnPreview.Attributes.Add("OnClick", "javascript:EncryptionTags();Preview();return(false);")
        End Sub

        'Event click update, create new template or update template
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strContent As String
            Dim arrCollumCaption() As String
            Dim arrCollumText() As String
            Dim strCollumCaption As String
            Dim inti As Integer
            Dim intj As Integer

            'add data if user no get infomation about column name, align, format, width
            arrCollumCaption = Split(txtCollumCaption.Text.Replace("&lt;", "<").Replace("&gt;", ">"), vbCrLf)
            arrCollumText = Split(hdCollumCaptionText.Value, "<~>")
            If UBound(arrCollumCaption) < UBound(arrCollumText) Then
                ReDim Preserve arrCollumCaption(UBound(arrCollumText))
            End If
            For inti = LBound(arrCollumText) To UBound(arrCollumText)
                If arrCollumCaption(inti) = "" Then
                    arrCollumCaption(inti) = arrCollumText(inti)
                End If
                strCollumCaption &= arrCollumCaption(inti) & "<~>"
            Next
            If Len(strCollumCaption) > 2 Then
                strCollumCaption = Left(strCollumCaption, Len(strCollumCaption) - 3)
            End If
            If txtCollumWidth.Text = "" Then
                intj = 0
            Else
                intj = UBound(Split(txtCollumWidth.Text, vbCrLf))
            End If
            For inti = intj To CInt(hdMax.Value)
                txtCollumWidth.Text &= vbCrLf
            Next
            If txtAlign.Text = "" Then
                intj = 0
            Else
                intj = UBound(Split(txtAlign.Text, vbCrLf))
            End If
            For inti = intj To CInt(hdMax.Value)
                txtAlign.Text &= vbCrLf
            Next
            If txtFormat.Text = "" Then
                intj = 0
            Else
                intj = UBound(Split(txtFormat.Text, vbCrLf))
            End If
            For inti = intj To CInt(hdMax.Value)
                txtFormat.Text &= vbCrLf
            Next

            strContent = txtHeader.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtCollum.Value & Chr(9) & strCollumCaption & Chr(9) & txtCollumWidth.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtAlign.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtFormat.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtFooter.Text.Replace(vbCrLf, "<~>")
            objBCommonTemplate.Name = Trim(txtTitle.Text)

            objBCommonTemplate.Content = strContent
            objBCommonTemplate.TemplateType = 20
            objBCommonTemplate.Modifier = clsSession.GlbUserFullName
            objBCommonTemplate.Creator = clsSession.GlbUserFullName
            If txtTemplate.Value = 0 Then   'create new
                objBCommonTemplate.CreateTemplate()
                Call WriteErrorMssg(lblLabel3.Text, objBCommonTemplate.ErrorMsg, lblLabel2.Text, objBCommonTemplate.ErrorCode)
                Page.RegisterClientScriptBlock("InsertAlertJs", "<script language='javascript'>alert('" & lblAddNewSuccessful.Text & "');</script>")
            Else 'update
                objBCommonTemplate.TemplateID = CInt(txtTemplate.Value)
                objBCommonTemplate.UpdateTemplate()
                Call WriteErrorMssg(lblLabel3.Text, objBCommonTemplate.ErrorMsg, lblLabel2.Text, objBCommonTemplate.ErrorCode)
                Page.RegisterClientScriptBlock("UpdateAlertJs", "<script language='javascript'>alert('" & lblUpdateSuccessful.Text & "');</script>")
            End If
            'Show data
            Call BindData()
        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            objBCommonTemplate.TemplateID = txtTemplate.Value
            objBCommonTemplate.TemplateType = 20
            objBCommonTemplate.DeleteTemplate()
            Call WriteErrorMssg(lblLabel3.Text, objBCommonTemplate.ErrorMsg, lblLabel2.Text, objBCommonTemplate.ErrorCode)
            'Show data
            Call BindData()
        End Sub

        'Initialize method
        Private Sub Initialize()
            ' Init objBCDBS
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.Initialize()
            'Init objBBClaimTemplate object
            objBETemplate.ConnectionString = Session("ConnectionString")
            objBETemplate.DBServer = Session("DBServer")
            objBETemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBETemplate.Initialize()

            'Init objBCommonTemplate object
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonTemplate.Initialize()

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'src = '../js/Tool/WNoticeTemplateMan.js'></script>")

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
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
