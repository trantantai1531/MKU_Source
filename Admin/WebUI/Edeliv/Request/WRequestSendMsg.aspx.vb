Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestSendMsg
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

        Dim objBERequest As New clsBERequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(1).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBERequest object
            objBERequest.ConnectionString = Session("ConnectionString")
            objBERequest.DBServer = Session("DBServer")
            objBERequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBERequest.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Request/WRequestSendFile.js'></script>")

            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
            btnSend.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtSubject) | CheckNull(document.forms[0].txtContent)) {alert('" & ddlLabel.Items(0).Text & "'); return false;}")
        End Sub

        ' btnSend_Click event
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Dim strSubject As String = Trim(txtSubject.Text)
            Dim strContent As String = Trim(txtContent.Text)
            Dim lngRequestID As Long = CLng(Request("RequestID"))
            Dim intSucess As Integer
            Dim intSendMail As Integer
            Dim strEmailTo As String = ""

            objBERequest.RequestID = lngRequestID
            intSucess = objBERequest.GetMailInfor(strEmailTo)
            Call WriteErrorMssg(ddlLabel.Items(3).Text, objBERequest.ErrorMsg, ddlLabel.Items(2).Text, objBERequest.ErrorCode)
            intSendMail = SendMail(strSubject, strContent, strEmailTo, True)
            'Call WriteErrorMssg(ddlLabel.Items(3).Text, ErrorMsg, ddlLabel.Items(2).Text, ErrorCode)
            If ErrorMsg <> "" Then
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "'); self.close();</script>")
            End If
            ' WriteLog
            Call WriteLog(72, lblPageTitle.Text & " (RequestID:" & Request("RequestID") & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            If intSendMail = 1 Then
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "'); self.close();</script>")
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
                If Not objBERequest Is Nothing Then
                    objBERequest.Dispose(True)
                    objBERequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace