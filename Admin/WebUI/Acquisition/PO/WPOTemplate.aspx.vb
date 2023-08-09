' Class: WPOTemplate
' Puspose: Manager Template
' Creator: Sondp
' CreatedDate: 10/03/2005
' Modification History:
'   + 12/04/2005, Sonnt: Bat loi
'   + 08/06/2005 by Oanhtn: fix error

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPOTemplate
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblConfirmDelete As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddNew As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateUnSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitleEmty As System.Web.UI.WebControls.Label
        Protected WithEvents lblRequestValue As System.Web.UI.WebControls.Label
        Protected WithEvents lblRequestText As System.Web.UI.WebControls.Label
        Protected WithEvents lblPostValue As System.Web.UI.WebControls.Label
        Protected WithEvents lblPostText As System.Web.UI.WebControls.Label
        Protected WithEvents lblVendorText As System.Web.UI.WebControls.Label
        Protected WithEvents lblVendorValue As System.Web.UI.WebControls.Label
        Protected WithEvents lblVendorInforText As System.Web.UI.WebControls.Label
        Protected WithEvents lblVendorInforValue As System.Web.UI.WebControls.Label
        Protected WithEvents lblRequestTemplate As System.Web.UI.WebControls.Label
        Protected WithEvents lblPostTemplate As System.Web.UI.WebControls.Label
        Protected WithEvents lblComplaintTemplate As System.Web.UI.WebControls.Label
        Protected WithEvents lblSeperatedTemplate As System.Web.UI.WebControls.Label
        Protected WithEvents lblComplaintText As System.Web.UI.WebControls.Label
        Protected WithEvents lblComplaintValue As System.Web.UI.WebControls.Label
        Protected WithEvents lblSeparatedStoreText As System.Web.UI.WebControls.Label
        Protected WithEvents lblSeparatedStoreValue As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonTemplate As New clsBCommonTemplate

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermisssion()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                hdTemplateType.Value = Request.QueryString("TemplateType")
                Call BindData(hdTemplateType.Value)
            End If
            Call BindJS()
        End Sub

        ' Method: CheckFormPermisssion
        ' Purpose: Check permission
        Private Sub CheckFormPermisssion()
            If Not CheckPemission(37) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initialize objBCommonTemplate object
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            Call objBCommonTemplate.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions 
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../Js/PO/WOPTemplate.js'></script>")

            txtHeader.Attributes.Add("OnClick", "storeCaret(document.forms[0].txtHeader);")
            txtHeader.Attributes.Add("OnSelect", "storeCaret(document.forms[0].txtHeader);")
            txtHeader.Attributes.Add("OnKeyup", "storeCaret(document.forms[0].txtHeader);")
            txtFooter.Attributes.Add("OnClick", "storeCaret(document.forms[0].txtFooter);")
            txtFooter.Attributes.Add("OnSelect", "storeCaret(document.forms[0].txtFooter);")
            txtFooter.Attributes.Add("OnKeyup", "storeCaret(document.forms[0].txtFooter);")

            ddlHeaderVendor.Attributes.Add("OnChange", "if(document.forms[0].ddlHeaderVendor.options.selectedIndex==0){return false;}else{UsePatronInfo(document.forms[0].txtHeader,this); return false;}")
            ddlHeaderInfPostForm.Attributes.Add("OnChange", "if(document.forms[0].ddlHeaderInfPostForm.options.selectedIndex==0){return false;}else{UsePatronInfo(document.forms[0].txtHeader,this); return false;}")
            ddlFooterVendor.Attributes.Add("OnChange", "if(document.forms[0].ddlFooterVendor.options.selectedIndex==0){return false;}else{UsePatronInfo(document.forms[0].txtFooter,this); return false;}")
            ddlFooterInfPostForm.Attributes.Add("OnChange", "if(document.forms[0].ddlFooterInfPostForm.options.selectedIndex==0){return false;}else{UsePatronInfo(document.forms[0].txtFooter,this); return false;}")
            ddlID.Attributes.Add("OnChange", "LoadTemplate(this.value,'" & hdTemplateType.Value & "'); return false;")

            btnAdd.Attributes.Add("OnClick", "AddItem(); return false;")
            btnRemove.Attributes.Add("OnClick", "RemoveItem(); return false;")
            btnUpdate.Attributes.Add("OnClick", "Encryption(); return(CheckValidData('" & ddlLabel.Items(22).Text & "'));")
            btnDelete.Attributes.Add("OnClick", "Encryption(); return(ConfirmDelete('" & ddlLabel.Items(23).Text & "', '" & ddlLabel.Items(36).Text & "'));Decryption();")
            btnPreview.Attributes.Add("OnClick", "Encryption();PreviewForm('" & hdTemplateType.Value & "'); return false;")
        End Sub

        ' BindData method
        Private Sub BindData(ByVal intTemplateType As Integer)
            Dim tblTemplate As New DataTable
            Dim listItem As New listItem

            objBCommonTemplate.TemplateID = 0
            objBCommonTemplate.TemplateType = intTemplateType
            objBCommonTemplate.LibID = clsSession.GlbSite
            tblTemplate = objBCommonTemplate.GetTemplate
            ' Bind the template
            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                ddlID.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(3).Text)
                ddlID.DataTextField = "Title"
                ddlID.DataValueField = "ID"
                ddlID.DataBind()
            Else
                ddlID.Items.Clear()
                listItem.Value = 0
                listItem.Text = ddlLabel.Items(3).Text
                ddlID.Items.Add(listItem)
            End If

            Call BindListBox(intTemplateType)
            txtCollumCaption.Text = ""
            txtCollum.Value = ""
            txtHeader.Text = ""
            txtPageHeader.Text = ""
            txtCaption.Text = ""
            txtCollumWidth.Text = ""
            txtAlign.Text = ""
            txtFormat.Text = ""
            txtTableColor.Text = ""
            txtEventColor.Text = ""
            txtOddColor.Text = ""
            txtPageFooter.Text = ""
            txtFooter.Text = ""
        End Sub

        ' BindListBox method
        Private Sub BindListBox(ByVal intTemplateType As Integer)
            Dim arrTextFields(), arrValueFields() As String
            Dim tblData As New DataTable
            Select Case intTemplateType
                Case 9 ' Request Template
                    lblMainTitle.Text = ddlLabel.Items(4).Text
                    Call VisiableControls(False)
                    arrValueFields = Split(ddlLabel.Items(8).Text, ",")
                    arrTextFields = Split(ddlLabel.Items(9).Text, ",")
                Case 7 ' Post Template
                    lblMainTitle.Text = ddlLabel.Items(5).Text
                    Call VisiableControls(True)
                    Call BindVendorInfor()
                    arrValueFields = Split(ddlLabel.Items(10).Text, ",")
                    arrTextFields = Split(ddlLabel.Items(11).Text, ",")
                Case 8 ' Complaint Template
                    lblMainTitle.Text = ddlLabel.Items(6).Text
                    Call VisiableControls(True)
                    Call BindVendorInfor()
                    arrValueFields = Split(ddlLabel.Items(12).Text, ",")
                    arrTextFields = Split(ddlLabel.Items(13).Text, ",")
                Case Else ' Default Separated Template
                    lblMainTitle.Text = ddlLabel.Items(7).Text
                    Call VisiableControls(True)
                    Call BindVendorInfor()
                    arrValueFields = Split(ddlLabel.Items(14).Text, ",")
                    arrTextFields = Split(ddlLabel.Items(15).Text, ",")
            End Select
            tblData = CreateTable(arrTextFields, arrValueFields)
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                lsbTemp.DataSource = tblData
                lsbTemp.DataValueField = "ValueField"
                lsbTemp.DataTextField = "TextField"
                lsbTemp.DataBind()
                lsbAllCollums.DataSource = tblData
                lsbAllCollums.DataTextField = "TextField"
                lsbAllCollums.DataValueField = "ValueField"
                lsbAllCollums.DataBind()
            End If
        End Sub

        ' BindVendorInfor method
        Private Sub BindVendorInfor()
            Dim arrTextFields(), arrValueFields() As String
            Dim tblVendorInfor As New DataTable

            arrValueFields = Split(ddlLabel.Items(16).Text, ",")
            arrTextFields = Split(ddlLabel.Items(17).Text, ",")
            tblVendorInfor = CreateTable(arrTextFields, arrValueFields)

            If Not tblVendorInfor Is Nothing AndAlso tblVendorInfor.Rows.Count > 0 Then
                ddlHeaderVendor.DataSource = tblVendorInfor
                ddlHeaderVendor.DataTextField = "TextField"
                ddlHeaderVendor.DataValueField = "ValueField"
                ddlHeaderVendor.DataBind()
                ddlFooterVendor.DataSource = tblVendorInfor
                ddlFooterVendor.DataTextField = "TextField"
                ddlFooterVendor.DataValueField = "ValueField"
                ddlFooterVendor.DataBind()
            End If

            arrValueFields = Split(ddlLabel.Items(18).Text, ",")
            arrTextFields = Split(ddlLabel.Items(19).Text, ",")
            tblVendorInfor = CreateTable(arrTextFields, arrValueFields)

            If Not tblVendorInfor Is Nothing AndAlso tblVendorInfor.Rows.Count > 0 Then
                ddlHeaderInfPostForm.DataSource = tblVendorInfor
                ddlHeaderInfPostForm.DataValueField = "ValueField"
                ddlHeaderInfPostForm.DataTextField = "TextField"
                ddlHeaderInfPostForm.DataBind()
                ddlFooterInfPostForm.DataSource = tblVendorInfor
                ddlFooterInfPostForm.DataValueField = "ValueField"
                ddlFooterInfPostForm.DataTextField = "TextField"
                ddlFooterInfPostForm.DataBind()
            End If
        End Sub

        ' Visiable controls method
        ' Purpose: visiable some controls
        ' In: boolFlage
        Private Sub VisiableControls(Optional ByVal boolFlage As Boolean = False)
            lblHeaderVendor.Visible = boolFlage
            ddlHeaderVendor.Visible = boolFlage
            lblHeaderInfPostForm.Visible = boolFlage
            ddlHeaderInfPostForm.Visible = boolFlage
            lblFooterVendor.Visible = boolFlage
            ddlFooterVendor.Visible = boolFlage
            lblFooterInfPostForm.Visible = boolFlage
            ddlFooterInfPostForm.Visible = boolFlage
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strContent As String = ""
            strContent = strContent & txtHeader.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) ' Get Header
            strContent = strContent & txtPageHeader.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) ' Get PageHeader
            strContent = strContent & txtCollum.Value & Chr(9) ' Get Collums( user's choice )
            strContent = strContent & txtCollumCaption.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Name display on Colllums
            strContent = strContent & txtCollumWidth.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Collum Width
            strContent = strContent & txtAlign.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Collum Align
            strContent = strContent & txtFormat.Text.Replace(vbCrLf, "<~>") & Chr(9) ' Get Collum Format
            strContent = strContent & txtTableColor.Text.Replace("'", "") & Chr(9) ' Get Title color
            strContent = strContent & txtEventColor.Text.Replace("'", "") & Chr(9) ' Get Event Rows color
            strContent = strContent & txtOddColor.Text.Replace("'", "") & Chr(9) ' Get Odd Rows color
            strContent = strContent & txtPageFooter.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) ' Get Page Footer
            strContent = strContent & txtFooter.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") ' Get Footer                

            objBCommonTemplate.Content = strContent
            objBCommonTemplate.Name = txtCaption.Text  ' Title
            objBCommonTemplate.Modifier = CStr(clsSession.GlbUserFullName)  'Modifier Name
            objBCommonTemplate.Creator = CStr(clsSession.GlbUserFullName) 'Creator
            objBCommonTemplate.TemplateType = hdTemplateType.Value
           
            objBCommonTemplate.LibID = clsSession.GlbSite
                
            If ddlID.SelectedItem.Value > 0 Then ' Update
                Try
                    objBCommonTemplate.TemplateID = ddlID.SelectedItem.Value.ToString
                    objBCommonTemplate.UpdateTemplate()
                    ' Write Log
                    Select Case hdTemplateType.Value
                        Case 9 ' Request Template
                            Call WriteLog(106, ddlLabel.Items(25).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        Case 7 ' Post Template
                            Call WriteLog(106, ddlLabel.Items(28).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        Case 8 ' Complaint Template
                            Call WriteLog(106, ddlLabel.Items(31).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        Case Else ' Default Separated Template
                            Call WriteLog(106, ddlLabel.Items(34).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    End Select
                    Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'> alert('" & ddlLabel.Items(20).Text & "');</script>")
                Catch ex As Exception
                    Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'> alert('" & ddlLabel.Items(20).Text & "');</script>")
                End Try
            Else  ' Insert
                If txtCaption.Text <> "" Then
                    Try
                        Dim result = objBCommonTemplate.CreateTemplate()
                        ' Write Log
                        Select Case hdTemplateType.Value
                            Case 9 ' Request Template
                                Call WriteLog(106, ddlLabel.Items(24).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            Case 7 ' Post Template
                                Call WriteLog(106, ddlLabel.Items(27).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            Case 8 ' Complaint Template
                                Call WriteLog(106, ddlLabel.Items(30).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            Case Else ' Default Separated Template
                                Call WriteLog(106, ddlLabel.Items(33).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        End Select
                        If result = 1 Then
                            Page.RegisterClientScriptBlock("AddNewSuccessfulJs", "<script language='javascript'> alert('Trùng tên mẫu!');</script>")
                            txtCaption.Text = ""
                            Exit Sub
                        Else
                            Page.RegisterClientScriptBlock("AddNewSuccessfulJs", "<script language='javascript'> alert('Tạo mới mẫu thành công!');</script>")
                        End If

                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("AddNewUnSuccessfulJs", "<script language='javascript'> alert('Tạo mới không thành công!');</script>")
                    End Try
                End If
            End If
            Call BindData(hdTemplateType.Value)
        End Sub

        ' btnDelete_Click event
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim strTemplate As String

            Try
                strTemplate = ddlID.SelectedItem.Text
                objBCommonTemplate.TemplateID = ddlID.SelectedValue
                objBCommonTemplate.TemplateType = hdTemplateType.Value
                objBCommonTemplate.DeleteTemplate()
                Select Case hdTemplateType.Value
                    Case 9 ' Request Template
                        Call WriteLog(106, ddlLabel.Items(26).Text & ": " & strTemplate, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Case 7 ' Post Template
                        Call WriteLog(106, ddlLabel.Items(29).Text & ": " & strTemplate, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Case 8 ' Complaint Template
                        Call WriteLog(106, ddlLabel.Items(32).Text & ": " & strTemplate, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Case Else ' Default Separated Template
                        Call WriteLog(106, ddlLabel.Items(35).Text & ": " & strTemplate, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Select
                Page.RegisterClientScriptBlock("DeleteSuccessfulJs", "<script language='javascript'> alert('Xóa mẫu thành công!');</script>")
            Catch ex As Exception
                Page.RegisterClientScriptBlock("DeleteUnSuccessfulJs", "<script language='javascript'> alert('Xóa không thành công!');</script>")
            Finally
                Call BindData(hdTemplateType.Value)
            End Try
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCommonTemplate Is Nothing Then
                objBCommonTemplate.Dispose(True)
                objBCommonTemplate = Nothing
            End If
        End Sub
    End Class
End Namespace