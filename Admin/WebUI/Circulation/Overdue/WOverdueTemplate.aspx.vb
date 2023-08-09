' Class: WOverdueTemplate
' Puspose: all process in Template Table
' Creator: Sondp
' CreatedDate: 20/12/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOverdueTemplateWindow
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblAddNew As System.Web.UI.WebControls.Label
        Protected WithEvents Header As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents SubTemplate As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBOverdueTemplate As New clsBOverdueTemplate

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(60) Then
                Call WritePermErrorMssg()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all objects
        Private Sub Initialize()
            'Init objBOverdueTemplate
            objBOverdueTemplate.ConnectionString = Session("ConnectionString")
            objBOverdueTemplate.DBServer = Session("DBServer")
            objBOverdueTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTemplate.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("RegisterActionTemplateJs", "<script language='javascript' src='../Js/Overdue/WOverdueTemplate.js'></script>")

            ' Controls action
            ddlTemplate.Attributes.Add("OnChange", "javascript:parent.Hiddenbase.location.href='WOverdueTemplateHidden.aspx?TemplateID=' + this.value;document.forms[0].txtTemplate.value=this.value; return false;")
            'ddlHeaderPickInformation.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlHeaderPickInformation.options[document.forms[0].ddlHeaderPickInformation.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtHeader,this); return false;}")
            'ddlFooterInformation.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlFooterInformation.options[document.forms[0].ddlFooterInformation.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtFooter,this); return false;}")

            'txtHeader.Attributes.Add("onclick", "javascript:storeCaret(document.forms[0].txtHeader)")
            'txtHeader.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtHeader)")
            'txtHeader.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtHeader)")
            'txtFooter.Attributes.Add("onclick", "javascript:storeCaret(document.forms[0].txtFooter)")
            'txtFooter.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtFooter)")
            'txtFooter.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtFooter)")

            btnAdd.Attributes.Add("OnClick", "javascript:AddItem(); return false;")
            btnRemove.Attributes.Add("OnClick", "javascript:RemoveItem(); return false;")
            btnPreview.Attributes.Add("OnClick", "javascript:if(CheckNull(document.forms[0].txtCaption)) {alert('" & ddlLabel.Items(8).Text.Trim & "')} else {Preview();} return false;")
            btnUpdate.Attributes.Add("OnClick", "javascript:if(CheckNull(document.forms[0].txtCaption)){alert('" & ddlLabel.Items(8).Text.Trim & "'); document.forms[0].txtCaption.focus(); return false;} else {EncryptionTags(); return true;}")
            btnDelete.Attributes.Add("OnClick", "javascript:if(parseFloat(document.forms[0].ddlTemplate.options[document.forms[0].ddlTemplate.options.selectedIndex].value)==0){alert('" & ddlLabel.Items(9).Text.Trim & "'); return false;} else {if(confirm(' " & ddlLabel.Items(7).Text.Trim & " ')) {EncryptionTags(); return true;}};return false;")
        End Sub

        ' BindData method
        ' Purpose: BindData for FirstTime Page is called
        Private Sub BindData()
            Dim tblTemplate As DataTable
            Dim item As New ListItem

            ' Bind data to ddlTemplate
            objBOverdueTemplate.TemplateID = 0 ' Select all 
            objBOverdueTemplate.TemplateType = 2 ' OvedueTemplate Type
            objBOverdueTemplate.LibID = clsSession.GlbSite
            tblTemplate = objBOverdueTemplate.GetTemplate
            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                tblTemplate = InsertOneRow(tblTemplate, ddlLabel.Items(5).Text)
                ddlTemplate.DataSource = tblTemplate
                ddlTemplate.DataTextField = "Title"
                ddlTemplate.DataValueField = "ID"
                ddlTemplate.DataBind()
            Else
                item.Value = 0
                item.Text = ddlLabel.Items(5).Text
                ddlTemplate.Items.Add(item)
            End If

            ' Clear textbox controls
            txtCollumCaption.Text = ""
            txtCaption.Text = ""
            txtHeader.Text = ""
            txtFooter.Text = ""
            txtAlign.Text = ""
            txtCollumWidth.Text = ""
            txtWord.Text = ""
            txtCollum.Value = ""

            'BindData for ListBox
            Dim arrValue() As String = {"<$SEQUENCY$>", "<$ITEMCODE$>", "<$ITEMTITLE$>", "<$COPYNUMBER$>", "<$CHECKOUTDATE$>", "<$CHECKINDATE$>", "<$OVERDUEDATE$>", "<$NOTE$>", "<$PENATI$>", "<$LIBRARY$>", "<$STORE$>", "<$LOANCOUNT$>"}
            Dim arrText() As String = {lblSequency.Value, lblItemCode.Value, lblItemTitle.Value, lblCopyNumber.Value, lblCheckOutDate.Value, lblCheckInDate.Value, lblOverdueDate.Value, lblNote.Value, lblPenati.Value, lblLibrary.Value, lblStore.Value, lblLoanCount.Value}
            Dim tblAllCollum As DataTable

            tblAllCollum = CreateTable(arrText, arrValue)

            ' For listbox all collums (lsbAllCollums)
            lsbAllCollums.DataSource = tblAllCollum
            lsbAllCollums.DataTextField = "TextField"
            lsbAllCollums.DataValueField = "ValueField"
            lsbAllCollums.DataBind()

            ' For "hidden" listbox (lsbTemp)    
            lsbTemp.DataSource = tblAllCollum
            lsbTemp.DataTextField = "TextField"
            lsbTemp.DataValueField = "ValueField"
            lsbTemp.DataBind()

            ' Bind Data for dowpdownlist HeaderInformation, FooterInformation
            ReDim arrValue(0)
            ReDim arrText(0)
            arrValue = Split(lblPatronInformationValue.Text, ",")
            arrText = Split(lblPatronInformationText.Text, ",")
            tblAllCollum = CreateTable(arrText, arrValue)

            ' Dropdownlist Header
            ddlHeaderPickInformation.DataSource = tblAllCollum
            ddlHeaderPickInformation.DataTextField = "TextField"
            ddlHeaderPickInformation.DataValueField = "ValueField"
            ddlHeaderPickInformation.DataBind()

            ' Dropdownlist Footer
            ddlFooterInformation.DataSource = tblAllCollum
            ddlFooterInformation.DataTextField = "TextField"
            ddlFooterInformation.DataValueField = "ValueField"
            ddlFooterInformation.DataBind()

            ' Dispose resource
            tblTemplate = Nothing
            tblAllCollum = Nothing
        End Sub

        ' btnUpdate_Click event
        ' Purpose: Update or create template
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strContent As String

            strContent = txtHeader.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) & txtCollum.Value & Chr(9) & txtCollumCaption.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtCollumWidth.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtAlign.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtWord.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtFooter.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "")
            objBOverdueTemplate.Name = txtCaption.Text.Trim
            objBOverdueTemplate.Content = strContent
            objBOverdueTemplate.TemplateType = 2
            objBOverdueTemplate.LibID = clsSession.GlbSite
            objBOverdueTemplate.Modifier = clsSession.GlbUserFullName
            objBOverdueTemplate.Creator = clsSession.GlbUserFullName

            If txtTemplate.Value = 0 Then ' Create new
                Dim result = objBOverdueTemplate.CreateTemplate()
                If result = 0 Then
                    Page.RegisterClientScriptBlock("InsertAlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("InsertAlertJs", "<script language='javascript'>alert('Đã tồn tại mẫu thư');</script>")
                End If
                ' WriteLog
                Call WriteLog(108, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)


            Else ' Update
                objBOverdueTemplate.TemplateID = CInt(txtTemplate.Value)
                objBOverdueTemplate.UpdateTemplate()
                ' WriteLog
                Call WriteLog(108, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Page.RegisterClientScriptBlock("UpdateAlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text.Trim & "');</script>")
            End If

            ' Refresh
            Call BindData()
        End Sub

        ' Event: btnDelete_Click
        ' Purpose: delete the selected template
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            objBOverdueTemplate.TemplateID = ddlTemplate.SelectedValue
            objBOverdueTemplate.TemplateType = 2
            objBOverdueTemplate.DeleteTemplate()
            ' WriteLog
            Call WriteLog(108, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Refesh data
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOverdueTemplate Is Nothing Then
                    objBOverdueTemplate.Dispose(True)
                    objBOverdueTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace