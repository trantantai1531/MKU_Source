'Class WORDenied.aspx
'Puspose: Send mail for patron when we want denied request of this patron
'Creator: Tuanhv
'CreatedDate: 21/12/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORDenied
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
        Private objBILLOutRequest As New clsBILLOutRequest
        Private objBILLTemplate As New clsBILLTemplate

        Dim mtx As clsBILLTemplate.Metric
        Dim tblCauseResponse As DataTable
        Dim strContent, strEmailAddress As String

        ' Page_Load event
        ' Purpose: Load information init in this form
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call GetInitData()
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        'BindJavascript method
        'Purpose: Get code javascript using in this form
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript'src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnClose.Attributes.Add("Onclick", "javascript:self.close()")
        End Sub

        'Initialize method
        'Purpose: init all object use in this form 
        Private Sub Initialize()
            'Initialize objBILLOutRequest object
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.Initialize()

            'Initialize objBILLTemplate object
            objBILLTemplate.ConnectionString = Session("ConnectionString")
            objBILLTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLTemplate.DBServer = Session("DBServer")
            objBILLTemplate.Initialize()
        End Sub

        'GetInitData methor
        'Purpose: Init data insert into control in this form
        Public Sub GetInitData()
            Dim tblCauseDenied As New DataTable
            Dim tblModelMail As New DataTable
            Dim tblORInfor As DataTable
            Dim intTemplateType As Integer

            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblORInfor = objBILLOutRequest.GetORInfor
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

                If Not tblORInfor Is Nothing Then
                    If tblORInfor.Rows.Count > 0 Then
                        ' ResponderID
                        If Not IsDBNull(tblORInfor.Rows(0).Item("ResponderID")) Then
                            hdnResponderID.Value = tblORInfor.Rows(0).Item("ResponderID")
                        Else
                            hdnResponderID.Value = 0
                        End If
                    End If
                End If
            End If

            'Set templatetype
            intTemplateType = 13
            tblModelMail = objBILLTemplate.GetGenTemplate(intTemplateType)
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLTemplate.ErrorMsg, ddlLabel.Items(1).Text, objBILLTemplate.ErrorCode)

            'Insert template denied
            If Not tblModelMail Is Nothing Then
                If tblModelMail.Rows.Count > 0 Then
                    ddlModelMail.DataSource = tblModelMail
                    ddlModelMail.Visible = True
                    ddlModelMail.DataTextField = "Title"
                    ddlModelMail.DataValueField = "ID"
                    ddlModelMail.DataBind()
                Else
                    ddlModelMail.Visible = False
                End If
            Else
                ddlModelMail.Visible = False
            End If

            'Get response denied
            tblCauseDenied = objBILLOutRequest.GetILLResponse

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            If Not tblCauseDenied Is Nothing Then
                tblCauseResponse = tblCauseDenied
            End If

            'Insert cause denied
            If Not tblCauseDenied Is Nothing Then
                If tblCauseDenied.Rows.Count > 0 Then
                    ddlCauseDenied.Visible = True
                    ddlCauseDenied.DataSource = tblCauseDenied
                    ddlCauseDenied.DataTextField = "Reason_Viet"
                    ddlCauseDenied.DataValueField = "ID"
                    ddlCauseDenied.DataBind()
                Else
                    ddlModelMail.Visible = False
                End If
            Else
                ddlModelMail.Visible = False
            End If
        End Sub

        'Sub ChangerActiveControl
        'Purpose: Changer all control when onclick on button in from
        Private Sub ChangerActiveControl(ByVal blnTemp As Boolean)
            lblCauseDenied.Visible = blnTemp
            lblModelMail.Visible = blnTemp
            lblTitleFrom.Visible = blnTemp
            btnPrintMail.Visible = blnTemp
            btnSendMail.Visible = blnTemp
            btnSendSMS.Visible = blnTemp
            ddlCauseDenied.Visible = blnTemp
            ddlModelMail.Visible = blnTemp
            btnClose.Visible = blnTemp
        End Sub

        'Preview Letter method
        Public Sub PrevieViewLetter()
            Dim intRow As Integer = 0
            Dim intCount As Integer = 0
            Dim intTempType As Integer
            Dim lngRequestID As Integer
            Dim intIndex As Integer
            Dim intTemplateID As Integer
            Dim arrRowTitle As Object
            Dim strCauseResponse As String

            arrRowTitle = Split(ddlLabel.Items(2).Text, ",")
            intCount = UBound(arrRowTitle) - 1

            'Get content data
            For intRow = 0 To intCount
                objBILLOutRequest.ContentData.Add(arrRowTitle(intRow), arrRowTitle(intRow))
            Next

            'Set default template and request(value id template of response denied)
            intTempType = 13

            lngRequestID = CLng(Request("IllID"))
            'Set dafault for test
            intTemplateID = CInt(ddlModelMail.SelectedValue)
            objBILLOutRequest.IllID = lngRequestID
            strCauseResponse = CStr(ddlCauseDenied.SelectedItem.Text)
            mtx = objBILLOutRequest.DenyOR(intTemplateID, intTempType, strCauseResponse)

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            ' Write log
            WriteLog(66, ddlLabel.Items(8).Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

            If Not mtx.arrStrOutMsg Is Nothing Then
                strContent = mtx.arrStrOutMsg(0)
                strEmailAddress = mtx.arrStrEmailAddress(0)
            End If
        End Sub

        'Event print mail
        Private Sub btnPrintMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintMail.Click
            'Visible control in form
            Call ChangerActiveControl(False)

            'Show content mail
            Call PrevieViewLetter()
            If UBound(mtx.arrStrOutMsg) > -1 Then
                lblContents.Text = mtx.arrStrOutMsg(0)
                Response.Write(strContent & "<P Style='Page-break-before:always'>")
                '   Print content of email
                Page.RegisterClientScriptBlock("PrintLetterJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
            End If
        End Sub

        'btnSendMail_Click event 
        'Purpose: Send mail for patron
        Private Sub btnSendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendMail.Click
            Dim intSendMail As Int16 = 0
            Dim strSubject As String

            'Show content mail
            Call PrevieViewLetter()
            ' Send Email here

            'objBILLOutRequest.ResponderID = hdnResponderID.Value
            'intSuccess = objBILLOutRequest.GetEmailInfor(strContent, strMailFrom, strMailTo, strContentOut, False)
            If Trim(strEmailAddress) <> "" Then
                strSubject = Me.lblTitleFrom.Text
                intSendMail = SendMail(strSubject, strContent, strEmailAddress, True)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                If intSendMail = 1 Then
                    Page.RegisterClientScriptBlock("AlertSendMailJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "')</script>")
                Else
                    Page.RegisterClientScriptBlock("AlertSendMailJsUnScucess", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "')</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("AlertSendMailJsUnScucess", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "')</script>")
            End If
        End Sub

        'Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        'Dispose method
        'Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutRequest Is Nothing Then
                    objBILLOutRequest.Dispose(True)
                    objBILLOutRequest = Nothing
                End If
                If Not objBILLTemplate Is Nothing Then
                    objBILLTemplate.Dispose(True)
                    objBILLTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

