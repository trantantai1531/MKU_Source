'Class WORLost.aspx
'Puspose: Lost mess 
'Creator: Tuanhv
'CreatedDate: 23/11/2004
'Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORLost
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
        Private objBILLOutRequest As New clsBILLOutRequest
        Dim intIllID As Integer
        Dim intResponderID As Integer

        'Page_Load event
        'Pupose: Load information init in this form
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJavascript()

            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        'Initialize method
        'Pupose: Init all object using in this class
        Private Sub Initialize()
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            Call objBILLOutRequest.Initialize()
        End Sub

        'BindJavascript method
        'Pupose: Get code javascript using in this form
        Private Sub BindJavascript()
            btnNoSend.Attributes.Add("Onclick", "javascript:self.close()")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblResult As DataTable
            If Request("ILLID") & "" <> "" Then
                intIllID = CInt(Request("ILLID"))
                hdnILLID.Value = intIllID
            End If
            objBILLOutRequest.IllID = intIllID
            tblResult = objBILLOutRequest.GetORInfor
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)
            If Not tblResult.Rows.Count > 0 Then
                'No find request
                Page.RegisterClientScriptBlock("NotSelect", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');self.close();</script>")
            Else
                ' ResponderID
                intResponderID = 0
                If Not IsDBNull(tblResult.Rows(0).Item("ResponderID")) Then
                    intResponderID = tblResult.Rows(0).Item("ResponderID")
                    hdnResponderID.Value = intResponderID
                Else
                    hdnResponderID.Value = 0
                End If
            End If
        End Sub

        'BindData method
        Private Sub SendData()
            Dim strNote As String = ""
            Dim intRequestID As Integer = 0
            Dim strContent As String = ""
            Dim intResponderID As Integer
            Dim tblResult As DataTable
            Dim intSuccess As Integer
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String

            If hdnILLID.Value & "" <> "" Then
                intIllID = CInt(hdnILLID.Value)
            End If
            If hdnResponderID.Value & "" <> "" Then
                intResponderID = CInt(hdnResponderID.Value)
            End If
            objBILLOutRequest.IllID = intIllID
            tblResult = objBILLOutRequest.GetORInfor

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            Call objBILLOutRequest.InitValues()
            If Not tblResult.Rows.Count > 0 Then
                'No find request
                Page.RegisterClientScriptBlock("NotSelect", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');self.close();</script>")
            Else
                intResponderID = CInt(tblResult.Rows(0).Item("ResponderID"))
                hdnResponderID.Value = intResponderID
                objBILLOutRequest.ResponderID = intResponderID
            End If

            If Not IsDBNull(txtNote.Text) Then
                strNote = txtNote.Text
            Else
                strNote = ""
            End If

            If hdnResponderID.Value & "" <> "" Then
                intResponderID = CInt(hdnResponderID.Value)
            End If

            'Update ill_outgoing_request
            objBILLOutRequest.IllID = intIllID
            objBILLOutRequest.Status = 17
            Call objBILLOutRequest.UpdateOR()

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            'Insert Ill_outgoing_request_log
            objBILLOutRequest.IllID = intIllID
            objBILLOutRequest.APDUType = 15
            objBILLOutRequest.Note = strNote
            objBILLOutRequest.ResponderID = intResponderID
            objBILLOutRequest.Alert = 0
            Call objBILLOutRequest.InsertORequestLog()

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)
            ' Write log
            WriteLog(66, lblHeader.Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

            strContent = objBILLOutRequest.LostitXmlRecord(strNote)
            objBILLOutRequest.ResponderID = hdnResponderID.Value
            intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
            EncodeILLError(objBILLOutRequest.EncodeOk)
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            If intSuccess = 0 Then
                intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                If intSendMail = 1 Then
                    Page.RegisterClientScriptBlock("AlertSendMailJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                Else
                    Page.RegisterClientScriptBlock("AlertSendMailUnSuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("AlertSendMailUnSuccessJs", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
            End If
        End Sub

        'btnSend_Click Event
        'Pupose: Send information for request select
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Call SendData()
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
