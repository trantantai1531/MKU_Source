' class WIRSendRetry.aspx
' Puspose: 
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
' Add : lent 20/12/2004
' Review code : lent 26-4-2005

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WIRSendRetry
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

        Private objBILLInRequest As New clsBILLInRequest

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLInRequest object
            objBILLInRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInRequest.DBServer = Session("DBServer")
            objBILLInRequest.ConnectionString = Session("ConnectionString")
            Call objBILLInRequest.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(153) Then
                Page.RegisterClientScriptBlock("AccessDeniedJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
                Response.End()
            End If
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("IRMainJS", "<script language = 'javascript' src = '../Js/IRMan/WIRMan.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkProvidedDate, txtProvidedDate, ddlLabel.Items(8).Text)
            btnNoSend.Attributes.Add("Onclick", "javascript:self.close()")
        End Sub

        ' BindData method
        ' Purpose : bind data to form
        Private Sub BindData()
            Dim intIllID As Integer = 0
            Dim tblResult As DataTable

            If Request("ILLID") & "" <> "" Then
                intIllID = CInt(Request("ILLID"))
            End If
            hidILLID.Value = intIllID
            objBILLInRequest.ILLID = intIllID
            tblResult = objBILLInRequest.GetIRInfor
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                RequesterID.Value = CStr(tblResult.Rows(0).Item("RequesterID"))
                RequestDate.Value = CStr(tblResult.Rows(0).Item("REQUESTDATE"))
                If CInt(tblResult.Rows(0).Item("Status")) <> 3 And CInt(tblResult.Rows(0).Item("Status")) <> 21 And CInt(tblResult.Rows(0).Item("Status")) <> 5 Then
                    Page.RegisterClientScriptBlock("ViewMsg2", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');self.close();</script>")
                Else
                    'get data
                    tblResult = Nothing
                    objBILLInRequest.IDs = "1,2,6,7,8,13,14,15,16,17,19,27,28"
                    tblResult = objBILLInRequest.GetIllResponse
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

                    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                        ddlReason.DataSource = tblResult
                        ddlReason.DataTextField = "Condition"
                        ddlReason.DataValueField = "ID"
                        ddlReason.DataBind()
                    End If
                End If
            Else
                Page.RegisterClientScriptBlock("ViewMsg1", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');self.close();</script>")
            End If
        End Sub

        ' Event : btnSend_Click
        ' Data proccess and send email action
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Dim intIllID As Integer = 0
            Dim strProvidedDate As String = ""
            Dim intDelivConditionID As Integer = 0
            Dim strNote As String = ""
            Dim strRequestDate As String = ""
            Dim intRequesterID As Integer = 0
            Dim strContent As String = ""
            Dim intSuccess As Integer = 0
            Dim blnSendMail As Boolean = False
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String
            Dim intSendMail As Int16 = 0

            ' get data for proccess data
            intIllID = CInt(hidILLID.Value)
            If RequesterID.Value <> "" Then
                intRequesterID = CInt(RequesterID.Value)
            End If
            If txtNote.Text <> "" Then
                strNote = txtNote.Text
            End If
            If RequestDate.Value <> "" Then
                strRequestDate = RequestDate.Value
            Else
                strRequestDate = DayOfNow()
            End If
            If txtProvidedDate.Text <> "" Then
                strProvidedDate = txtProvidedDate.Text
            Else
                strProvidedDate = "NULL"
            End If
            intDelivConditionID = ddlReason.SelectedValue

            'update ill_incoming_request
            Call objBILLInRequest.InitVariables()
            objBILLInRequest.ILLID = intIllID
            objBILLInRequest.Status = 1
            objBILLInRequest.RespondDate = DayOfNow()
            intSuccess = objBILLInRequest.UpdateIR
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

            If intSuccess > 0 Then
                'insert ill_incoming_request_log
                Call objBILLInRequest.InitVariables()
                objBILLInRequest.RequesterID = intRequesterID
                objBILLInRequest.ProvidedDate = strProvidedDate
                objBILLInRequest.APDUType = 4
                objBILLInRequest.TRE = 2
                objBILLInRequest.ReasonID = intDelivConditionID
                objBILLInRequest.Note = strNote
                objBILLInRequest.Alert = 0
                intSuccess = objBILLInRequest.InsertIRequestLog()
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

                If intSuccess > 0 Then
                    'insert ill_incoming_request_denied
                    objBILLInRequest.RequestDate = strRequestDate
                    objBILLInRequest.RequesterID = intRequesterID
                    objBILLInRequest.ReasonID = intDelivConditionID
                    objBILLInRequest.RespondDate = DayOfNow()
                    Call objBILLInRequest.InsertIRequestDenied()
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)
                End If
            End If
            If intSuccess > 0 Then
                ' WriteLog
                Call WriteLog(65, lblHeader.Text & ": ILLID=" & hidILLID.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                strContent = objBILLInRequest.RetryXmlRecord(CStr(intDelivConditionID), strProvidedDate, strNote)
                blnSendMail = objBILLInRequest.GetEmailInfor(Server.MapPath(""), intRequesterID, strContent, strMailFrom, strMailTo, strContentOut)
                EncodeILLError(objBILLInRequest.EncodeOk)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

                If Not blnSendMail Then
                    Page.RegisterClientScriptBlock("ViewMsg4", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
                Else
                    intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)

                    If intSendMail = 0 Then
                        Page.RegisterClientScriptBlock("ViewMsg3", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("ViewMsg4", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
                    End If
                End If
            Else
                Page.RegisterClientScriptBlock("ViewMsg5", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLInRequest Is Nothing Then
                    objBILLInRequest.Dispose(True)
                    objBILLInRequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

