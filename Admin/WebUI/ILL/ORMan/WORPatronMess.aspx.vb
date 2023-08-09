'Class WORPatronMess.aspx
'Puspose: Send mail for patron when we want denied request of this patron
'Creator: Tuanhv
'CreatedDate: 27/12/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORPatronMess
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
        ' Declare variable 
        Private objBILLOutRequest As New clsBILLOutRequest
        Private objBILLTemplate As New clsBILLTemplate
        Dim mtx As clsBILLTemplate.Metric
        Dim tblCauseResponse As DataTable
        Dim strContent As String
        Private objBILLLibrary As New clsBILLLibrary

        'Page_Load event
        'Pupose: Load information init in this form
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

        'Initialize method
        'Pupose: init all object use in this form 
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

            'Initialize objBILLLibrary object
            objBILLLibrary.ConnectionString = Session("ConnectionString")
            objBILLLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLLibrary.DBServer = Session("DBServer")
            objBILLLibrary.Initialize()
        End Sub

        'BindJavascript method
        'Pupose: Get code javascript using in this form
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript'src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnClose.Attributes.Add("Onclick", "javascript:self.close()")
        End Sub


        'GetInitData methor
        'Pupose: Init data insert into control in this form
        Public Sub GetInitData()
            Dim tblCauseDenied As New DataTable
            Dim tblModelMail As New DataTable
            Dim intTemplateType As Integer
            Dim tblORInfor As DataTable

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
            intTemplateType = 14
            tblModelMail = objBILLTemplate.GetGenTemplate(intTemplateType)

            ' Check error
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
            End If

            'Get response denied
            tblCauseDenied = objBILLOutRequest.GetILLResponse
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLTemplate.ErrorMsg, ddlLabel.Items(1).Text, objBILLTemplate.ErrorCode)
            tblCauseResponse = tblCauseDenied

        End Sub

        'Sub ChangerActiveControl
        'Pupose: Changer all control when onclick on button in from
        Private Sub ChangerActiveControl(ByVal bol As Boolean)
            lblModelMail.Visible = bol
            lblTitleFrom.Visible = bol
            btnPrintMail.Visible = bol
            btnSendMail.Visible = bol
            btnSendSMS.Visible = bol
            ddlModelMail.Visible = bol
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
            Dim intIllID As Integer

            arrRowTitle = Split(Me.ddlLabel.Items(2).Text, ",")
            intCount = UBound(arrRowTitle) - 1

            'Get content data
            For intRow = 0 To intCount
                objBILLOutRequest.ContentData.Add(arrRowTitle(intRow), arrRowTitle(intRow))
            Next

            'Set default template and request(value id template of response denied)
            intTempType = 14

            intIllID = CLng(Request("IllID"))
            'Set dafault for test
            intTemplateID = CInt(ddlModelMail.SelectedValue)
            objBILLOutRequest.IllID = intIllID
            mtx = objBILLOutRequest.SendNoticePatron(intTemplateID, intTempType)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            ' Write log
            WriteLog(66, ddlLabel.Items(8).Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

            If Not mtx.arrStrOutMsg Is Nothing Then
                strContent = mtx.arrStrOutMsg(0)
            End If
        End Sub

        'Event print mail
        Private Sub btnPrintMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintMail.Click
            'Visible control in form
            Call ChangerActiveControl(False)

            'Show content mail
            Call PrevieViewLetter()
            If Not mtx.arrStrOutMsg Is Nothing Then
                If UBound(mtx.arrStrOutMsg) > -1 Then
                    lblContents.Text = mtx.arrStrOutMsg(0)
                    Response.Write(strContent & "<P Style='Page-break-before:always'>")
                    '    'Print content of email
                    Page.RegisterClientScriptBlock("PrintLetterJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                End If
            End If
        End Sub

        'btnSendMail_Click event 
        'Pupose: Send mail for patron
        Private Sub btnSendMail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendMail.Click
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim intSuccess As Integer
            Dim strContentOut As String
            Dim strSubject As String
            Dim tblLocalLibMail As DataTable

            'Show content mail
            Call PrevieViewLetter()
            If Not mtx.arrStrOutMsg Is Nothing AndAlso UBound(mtx.arrStrOutMsg) > -1 Then
                ' Send Email here
                strContent = CStr(mtx.arrStrOutMsg(0))
                strMailTo = CStr(mtx.arrStrEmailAddress(0))

                '  Get local lib email
                objBILLLibrary.LibID = 0
                tblLocalLibMail = objBILLLibrary.GetLib(1)
                strMailFrom = "ill@greenhouse.com"
                If Not tblLocalLibMail Is Nothing Then
                    If tblLocalLibMail.Rows.Count > 0 Then
                        strMailFrom = tblLocalLibMail.Rows(0).Item("EmailReplyAddress").ToString.Trim
                    End If
                End If

                'objBILLOutRequest.ResponderID = hdnResponderID.Value
                'intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)

                ' Check error
                'Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)
                strSubject = lblTitleFrom.Text
                intSendMail = SendMail(strSubject, strContent, strMailTo, True, strMailFrom)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)

                If intSendMail = 1 Then
                    Page.RegisterClientScriptBlock("AlertSendMailJs", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "')</script>")
                Else
                    Page.RegisterClientScriptBlock("AlertSendMailUnSuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "')</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("AlertSendMailUnSuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "')</script>")
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
                If Not objBILLLibrary Is Nothing Then
                    objBILLLibrary.Dispose(True)
                    objBILLLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

