' Class: WClaimTemplateManagement
' Puspose: Manage Claim Template
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 26/09/2004 by Sondp: Create, Update, Delete Claim Template method

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WClaimTemplateManagement
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnMoveUp As System.Web.UI.HtmlControls.HtmlInputButton
        Protected WithEvents btnMoveDown As System.Web.UI.HtmlControls.HtmlInputButton


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBBCT As New clsBClaimTemplate
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBBCT object
            objBBCT.ConnectionString = Session("ConnectionString")
            objBBCT.DBServer = Session("DBServer")
            objBBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBBCT.Initialize()

            'Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(94) Then
                btnUpdate.Enabled = False
            End If
            If Not CheckPemission(219) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' Method BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ClaimTemplateManagementJs", "<script language='javascript' src='../js/Claim/WClaimTemplateManagement.js'></script>")

            'hrfSetClaimCycle.Attributes.Add("OnClick", "parent.Workform.location.href='WSetClaimCycle.aspx'; return false;")
            'hrfClaim.Attributes.Add("OnClick", "parent.Workform.location.href='WClaim.aspx'; return false;")
            'hrfShowClaimList.Attributes.Add("OnClick", "parent.Workform.location.href='WShowClaimList.aspx'; return false;")

            ddlTemplate.Attributes.Add("OnChange", "parent.Hiddenbase.location.href='WLoadTemplate.aspx?TemplateID=' + this.value;document.forms[0].txtTemplate.value=this.value; return false;")
            ddlHeaderAddInformation.Attributes.Add("OnChange", "if(document.forms[0].ddlHeaderAddInformation.options[document.forms[0].ddlHeaderAddInformation.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtHeader,this); return false;}")
            ddlFooterAddInformation.Attributes.Add("OnChange", "if(document.forms[0].ddlFooterAddInformation.options[document.forms[0].ddlFooterAddInformation.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtFooter,this); return false;}")

            txtHeader.Attributes.Add("OnClick", "storeCaret(document.forms[0].txtHeader)")
            txtHeader.Attributes.Add("OnSelect", "storeCaret(document.forms[0].txtHeader)")
            txtHeader.Attributes.Add("OnKeyup", "storeCaret(document.forms[0].txtHeader)")
            txtFooter.Attributes.Add("OnClick", "storeCaret(document.forms[0].txtFooter)")
            txtFooter.Attributes.Add("OnSelect", "storeCaret(document.forms[0].txtFooter)")
            txtFooter.Attributes.Add("OnKeyup", "storeCaret(document.forms[0].txtFooter)")

            btnAdd.Attributes.Add("OnClick", "AddItem(); return false;")
            btnRemove.Attributes.Add("OnClick", "RemoveItem(); return false;")
            btnUpdate.Attributes.Add("OnClick", "AddItem();EncryptionTags();if(document.forms[0].txtCaption.value==''){alert('" & ddlLabel.Items(6).Text & "'); return false;}else{return(true);}")
            btnPreview.Attributes.Add("OnClick", "EncryptionTags();Preview(); return false;")
            btnDelete.Attributes.Add("OnClick", "if(document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value==0){return false;}else{if(confirm('" & ddlLabel.Items(9).Text & " ')){return(true);}else{return false;}}")

        End Sub

        ' Method BindData
        ' Purpose: BindData to all controls
        Private Sub BindData()
            Dim tblAddInformation As DataTable
            Dim tblCollums As DataTable
            Dim arrTextField() As String
            Dim arrValueField() As String

            Call RefreshPage()
            ' Binddata to dropdownlists
            arrTextField = ddlLabel.Items(4).Text.Split(",")
            arrValueField = ddlLabel.Items(4).Value.Split(",")
            tblAddInformation = objBCDBS.CreateTable(arrTextField, arrValueField)
            ddlHeaderAddInformation.DataSource = tblAddInformation
            ddlHeaderAddInformation.DataTextField = "TextField"
            ddlHeaderAddInformation.DataValueField = "ValueField"
            ddlHeaderAddInformation.DataBind()
            ddlFooterAddInformation.DataSource = tblAddInformation
            ddlFooterAddInformation.DataTextField = "TextField"
            ddlFooterAddInformation.DataValueField = "ValueField"
            ddlFooterAddInformation.DataBind()

            ' BindData to listbox
            arrTextField = ddlLabel.Items(3).Text.Split(",")
            arrValueField = ddlLabel.Items(3).Value.Split(",")
            tblCollums = objBCDBS.CreateTable(arrTextField, arrValueField)
            lsbTemp.DataSource = tblCollums
            lsbTemp.DataTextField = "TextField"
            lsbTemp.DataValueField = "ValueField"
            lsbTemp.DataBind()
            lsbAllCollums.DataSource = tblCollums
            lsbAllCollums.DataTextField = "TextField"
            lsbAllCollums.DataValueField = "ValueField"
            lsbAllCollums.DataBind()
        End Sub

        ' ReBindData to DrowDownList and clear all Textbox
        Private Sub RefreshPage()
            Dim tblTemplate As DataTable = Nothing
            Dim lItem As New ListItem

            ' Get all template to bind to dropdownlist Caption
            objBBCT.TemplateID = 0
            objBBCT.TemplateType = 6
            objBBCT.LibID = clsSession.GlbSite
            tblTemplate = objBBCT.GetTemplate
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBBCT.ErrorMsg, ddlLabel.Items(1).Text, objBBCT.ErrorCode)

            If Not tblTemplate Is Nothing And Not IsDBNull(tblTemplate) Then
                If tblTemplate.Rows.Count > 0 Then
                    ddlTemplate.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(5).Text) '  lblAddNew.Text)
                    ddlTemplate.DataTextField = "Title"
                    ddlTemplate.DataValueField = "ID"
                    ddlTemplate.DataBind()
                Else
                    lItem.Text = ddlLabel.Items(5).Text
                    lItem.Value = 0
                    ddlTemplate.Items.Add(lItem)
                End If
            Else
                lItem.Text = ddlLabel.Items(5).Text
                lItem.Value = 0
                ddlTemplate.Items.Add(lItem)
            End If
            ' Reset controls
            txtPageHeader.Text = ""
            hidCollum.Value = ""
            txtCaption.Text = ""
            txtHeader.Text = ""
            txtCollumCaption.Text = ""
            txtTemplate.Value = 0
            txtCollumWidth.Text = ""
            txtAlign.Text = ""
            txtTableColor.Text = ""
            txtOddColor.Text = ""
            txtEventColor.Text = ""
            txtPageFooter.Text = ""
            txtFormat.Text = ""
            txtFooter.Text = ""
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            Dim strContent As String = ""
            strContent = strContent & txtHeader.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) ' Get Header
            strContent = strContent & txtPageHeader.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) ' Get PageHeader
            strContent = strContent & hidCollum.Value & Chr(9) ' Get Collums( user's choice )
            strContent = strContent & txtCollumCaption.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Name display on Colllums
            strContent = strContent & txtCollumWidth.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Collum Width
            strContent = strContent & txtAlign.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Collum Align
            strContent = strContent & txtFormat.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Collum Format
            strContent = strContent & txtTableColor.Text.Replace("'", "") & Chr(9) ' Get Title color
            strContent = strContent & txtEventColor.Text.Replace("'", "") & Chr(9) ' Get Event Rows color
            strContent = strContent & txtOddColor.Text.Replace("'", "") & Chr(9) ' Get Odd Rows color
            strContent = strContent & txtPageFooter.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) ' Get Page Footer
            strContent = strContent & txtFooter.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") ' Get Footer                
            objBBCT.Name = txtCaption.Text
            objBBCT.Content = strContent
            objBBCT.TemplateType = 6
            objBBCT.Modifier = clsSession.GlbUserFullName
            objBBCT.Creator = clsSession.GlbUserFullName
            objBBCT.LibID = clsSession.GlbSite
            If txtTemplate.Value = 0 Then   ' Create new
                objBBCT.CreateTemplate()
                ' Check error
                'Call WriteErrorMssg(ddlLabel.Items(0).Text, objBBCT.ErrorMsg, ddlLabel.Items(1).Text, objBBCT.ErrorCode)
                ' Write log
                Call WriteLog(115, ddlLabel.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("InsertAlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
            Else ' Update
                objBBCT.TemplateID = CInt(txtTemplate.Value)
                objBBCT.UpdateTemplate()
                ' Check error
                'Call WriteErrorMssg(ddlLabel.Items(0).Text, objBBCT.ErrorMsg, ddlLabel.Items(1).Text, objBBCT.ErrorCode)
                ' Write log
                Call WriteLog(115, ddlLabel.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("UpdateAlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
            End If
            Call RefreshPage()
        End Sub

        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

            objBBCT.TemplateID = ddlTemplate.SelectedValue
            objBBCT.TemplateType = 6
            objBBCT.DeleteTemplate()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBBCT.ErrorMsg, ddlLabel.Items(1).Text, objBBCT.ErrorCode)
            ' Write log
            Call WriteLog(115, ddlLabel.Items(12).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call RefreshPage()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBBCT Is Nothing Then
                    objBBCT.Dispose(True)
                    objBBCT = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace