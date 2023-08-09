Imports eMicLibAdmin.BusinessRules.ILL
Imports System.Web.Mail

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WSaveMail
        Inherits clsWBase

        Private objBSaveMail As New clsBSaveMail

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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call SaveMail()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(153) And Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "'); </script>")
                Response.End()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all object use in this form 
        Private Sub Initialize()
            'Initialize objBILLOutRequest object
            objBSaveMail.ConnectionString = Session("ConnectionString")
            objBSaveMail.InterfaceLanguage = Session("InterfaceLanguage")
            objBSaveMail.DBServer = Session("DBServer")
            objBSaveMail.Initialize()
        End Sub

        ' SaveMail method
        Private Sub SaveMail()

            Dim blnSuccess As Boolean
            Dim blnNoHaveEmail As Boolean = False
            Dim arrContentOut() As String
            Dim arrMailToOut() As String
            Dim strMailFromOut As String
            Dim intSendMail As Integer

            hidAction.Value = 0 ' has error
            hidMsgAct.Value = ""
            objBSaveMail.DateOfNow = DayOfNow(True)
            objBSaveMail.ServerPath = Server.MapPath("")
            objBSaveMail.ReplyStatus = ddlLabel.Items(5).Text
            objBSaveMail.NoStatus = ddlLabel.Items(6).Text
            blnSuccess = objBSaveMail.SaveMail(blnNoHaveEmail, arrContentOut, arrMailToOut, strMailFromOut)

            ' Write Error
            If objBSaveMail.ErrorMsg <> "" Then
                hidMsgAct.Value = objBSaveMail.ErrorMsg
                Exit Sub
            End If
            'Call WriteErrorMssg(objBSaveMail.ErrorCode, objBSaveMail.ErrorMsg)

            ' Write log
            WriteLog(65, ddlLabel.Items(1).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

            If blnSuccess = False Then
                If blnNoHaveEmail Then
                    hidMsgAct.Value = ddlLabel.Items(4).Text
                Else
                    hidMsgAct.Value = ddlLabel.Items(3).Text
                End If
            Else
                If Not arrMailToOut Is Nothing AndAlso arrMailToOut.Length > 0 Then
                    Dim inti As Integer
                    For inti = 0 To arrMailToOut.Length - 1
                        intSendMail = SendMail("ILL", arrContentOut(inti), arrMailToOut(inti), False, strMailFromOut)
                    Next
                End If
                If Request("Mode") = 1 Then
                    hidAction.Value = 1
                    hidMsgAct.Value = ddlLabel.Items(2).Text
                Else
                    hidAction.Value = 2
                    hidMsgAct.Value = ddlLabel.Items(2).Text
                End If
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
                If Not objBSaveMail Is Nothing Then
                    objBSaveMail.Dispose(True)
                    objBSaveMail = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
