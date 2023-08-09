' Class: WTemplate.aspx
' Puspose: All puspose for ILL Template
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   - 24/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WTemplate
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
        Private objBCTemplate As New clsBCommonTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                hdType.Value = Request.QueryString("TemplateType")
                If hdType.Value = "" Then
                    Response.End()
                End If
                Call BindData()
                Call RefreshData(hdType.Value)
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            'Quan ly khuon dang
            If Not CheckPemission(156) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
            'Cap nhat
            If CheckPemission(211) Then
                btnUpdate.Enabled = True
            End If
            'Xoa
            If CheckPemission(212) Then
                btnDelete.Enabled = True
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initialize objBCTemplate object
            objBCTemplate.ConnectionString = Session("ConnectionString")
            objBCTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCTemplate.DBServer = Session("DBServer")
            Call objBCTemplate.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("TempalteJs", "<script language='javascript' src='../JS/ToolsMan/WTemplate.js'></script>")

            ddlTemplate.Attributes.Add("OnChange", "javascript:parent.Hiddenbase.location.href='WLoadTemplate.aspx?TemplateID=' + this.value + '&TemplateType=' + document.forms[0].hdType.value;return false;")
            ddlItem.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlItem.options[document.forms[0].ddlItem.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtContent,this);return false;}")
            ddlDestination.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlDestination.options[document.forms[0].ddlDestination.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtContent,this);return false;}")
            ddlRequest.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlRequest.options[document.forms[0].ddlRequest.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtContent,this);return false;}")
            ddlElse.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlElse.options[document.forms[0].ddlElse.options.selectedIndex].value==0){return false;}else{UsePatronInfo(document.forms[0].txtContent,this);return false;}")

            txtContent.Attributes.Add("OnClick", "javascript:storeCaret(document.forms[0].txtContent)")
            txtContent.Attributes.Add("OnSelect", "javascript:storeCaret(document.forms[0].txtContent)")
            txtContent.Attributes.Add("OnKeyup", "javascript:storeCaret(document.forms[0].txtContent)")

            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); return(false);")
            btnPreview.Attributes.Add("OnClick", "javascript:return(PreviewTemplate());")
            btnUpdate.Attributes.Add("OnClick", "javascript:return(CheckforUpdate('" & ddlLabel.Items(6).Text & "'));")
            btnDelete.Attributes.Add("OnClick", "javascript:if (!CheckforDelete()) {alert('" & ddlLabel.Items(5).Text & "'); return false;}else {if(confirm('" & ddlLabel.Items(9).Text & " ')){return true;}else{return false;}};")
        End Sub

        ' Method: Bind Data 
        Private Sub BindData()
            Dim tblAddInfo As New DataTable
            Dim arrTextField() As String
            Dim arrValueField() As String

            ' Bind item information
            arrTextField = Split(lblItemText.Text, ",")
            arrValueField = Split(lblItemValue.Text, ",")
            tblAddInfo = CreateTable(arrTextField, arrValueField)
            tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
            ddlItem.DataSource = tblAddInfo
            ddlItem.DataTextField = "TextField"
            ddlItem.DataValueField = "ValueField"
            ddlItem.DataBind()

            Select Case hdType.Value
                Case "12" ' Pack template
                    lblMainTitle.Text = lblPackTemplate.Text
                    ' Bind destination information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblPackDestinationText.Text, ",")
                    arrValueField = Split(lblPackDestinationValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlDestination.DataSource = tblAddInfo
                    ddlDestination.DataTextField = "TextField"
                    ddlDestination.DataValueField = "ValueField"
                    ddlDestination.DataBind()

                    ' Bind request information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblPackRequestText.Text, ",")
                    arrValueField = Split(lblPackRequestValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlRequest.DataSource = tblAddInfo
                    ddlRequest.DataTextField = "TextField"
                    ddlRequest.DataValueField = "ValueField"
                    ddlRequest.DataBind()
                Case "13" ' Denied template
                    lblMainTitle.Text = lblDeniedTemplate.Text
                    lblDestination.Text = lblPatron.Text

                    ' Bind destination information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblDeniedPatronText.Text, ",")
                    arrValueField = Split(lblDeniedPatronValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlDestination.DataSource = tblAddInfo
                    ddlDestination.DataTextField = "TextField"
                    ddlDestination.DataValueField = "ValueField"
                    ddlDestination.DataBind()

                    ' Bind request information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblDeniedRequetText.Text, ",")
                    arrValueField = Split(lblDeniedRequestValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    ddlRequest.DataSource = tblAddInfo
                    ddlRequest.DataTextField = "TextField"
                    ddlRequest.DataValueField = "ValueField"
                    ddlRequest.DataBind()

                    ' Bind else information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblDeniedElseText.Text, ",")
                    arrValueField = Split(lblDeniedElseValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlElse.DataSource = tblAddInfo
                    ddlElse.DataTextField = "TextField"
                    ddlElse.DataValueField = "ValueField"
                    ddlElse.DataBind()
                Case "14" ' Notice template
                    lblMainTitle.Text = lblNoticeTemplate.Text
                    lblDestination.Text = lblPatron.Text

                    ' Bind destination information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblNoticePatronText.Text, ",")
                    arrValueField = Split(lblNoticePatronValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlDestination.DataSource = tblAddInfo
                    ddlDestination.DataTextField = "TextField"
                    ddlDestination.DataValueField = "ValueField"
                    ddlDestination.DataBind()

                    ' Bind request information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblNoticeRequestText.Text, ",")
                    arrValueField = Split(lblNoticeRequestValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlRequest.DataSource = tblAddInfo
                    ddlRequest.DataTextField = "TextField"
                    ddlRequest.DataValueField = "ValueField"
                    ddlRequest.DataBind()
                Case "16" ' Overdue template
                    lblMainTitle.Text = lblOverdueTemplate.Text
                    lblDestination.Text = lblPatron.Text
                    ' Bind destination information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblOverduePatronText.Text, ",")
                    arrValueField = Split(lblOverduePatronValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlDestination.DataSource = tblAddInfo
                    ddlDestination.DataTextField = "TextField"
                    ddlDestination.DataValueField = "ValueField"
                    ddlDestination.DataBind()

                    ' Bind request information
                    tblAddInfo = Nothing
                    arrTextField = Split(lblOverdueRequestText.Text, ",")
                    arrValueField = Split(lblOverdueRequestValue.Text, ",")
                    tblAddInfo = CreateTable(arrTextField, arrValueField)
                    tblAddInfo = InsertOneRow(tblAddInfo, "---------- Chọn ----------")
                    ddlRequest.DataSource = tblAddInfo
                    ddlRequest.DataTextField = "TextField"
                    ddlRequest.DataValueField = "ValueField"
                    ddlRequest.DataBind()
            End Select
        End Sub

        ' Method: RefreshData
        ' Purpose: Refresh Data
        Private Sub RefreshData(ByVal intTemplateType As Integer)
            Dim tblTemplate As New DataTable

            ' Get all template have TemplateType
            objBCTemplate.TemplateID = 0
            objBCTemplate.TemplateType = intTemplateType
            objBCTemplate.LibID = clsSession.GlbSite
            tblTemplate = objBCTemplate.GetTemplate

            ' Catch error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCTemplate.ErrorCode)

            If Not tblTemplate Is Nothing Then
                ddlTemplate.DataSource = InsertOneRow(tblTemplate, ddlLabel.Items(2).Text)
                ddlTemplate.DataTextField = "Title"
                ddlTemplate.DataValueField = "ID"
                ddlTemplate.DataBind()
            End If
            txtCaption.Text = ""
            txtContent.Text = ""
            tblTemplate = Nothing
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intOut As Integer = 0
            objBCTemplate.TemplateType = hdType.Value
            objBCTemplate.Name = txtCaption.Text.Trim.Replace(vbCrLf, "<~>").Replace("'", "")
            objBCTemplate.Creator = clsSession.GlbUserFullName
            objBCTemplate.Modifier = clsSession.GlbUserFullName
            objBCTemplate.Content = txtContent.Text.Trim.Replace(vbCrLf, "<~>").Replace("'", "").Replace(Chr(9), "")
            objBCTemplate.LibID = clsSession.GlbSite
            If ddlTemplate.SelectedValue = 0 Then  ' Create
                intOut = objBCTemplate.CreateTemplate()

                ' Catch error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCTemplate.ErrorCode)

                ' WriteLog
                Call WriteLog(68, ddlLabel.Items(3).Text & " " & txtCaption.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Else ' Update
                objBCTemplate.TemplateID = ddlTemplate.SelectedValue
                intOut = objBCTemplate.UpdateTemplate()

                ' Catch error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCTemplate.ErrorCode)

                ' WriteLog
                Call WriteLog(68, ddlLabel.Items(3).Text & " " & txtCaption.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If

            ' Alert message
            If intOut = 1 Then
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & " " & ddlLabel.Items(8).Text & "')</script>")
            End If
            Call RefreshData(hdType.Value)
        End Sub

        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            If ddlTemplate.SelectedValue > 0 Then
                objBCTemplate.TemplateID = ddlTemplate.SelectedValue
                objBCTemplate.TemplateType = hdType.Value
                objBCTemplate.DeleteTemplate()

                ' Catch error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBCTemplate.ErrorCode)

                ' WriteLog
                Call WriteLog(68, ddlLabel.Items(4).Text & " " & txtCaption.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & " " & ddlLabel.Items(8).Text & "')</script>")
            End If
            Call RefreshData(hdType.Value)
        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCTemplate Is Nothing Then
                    objBCTemplate.Dispose(True)
                    objBCTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace