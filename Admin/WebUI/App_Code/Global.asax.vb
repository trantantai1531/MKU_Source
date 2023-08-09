Imports System.Web
Imports System.Web.SessionState
Imports System.Resources
Imports System.Reflection
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibLogin

Public Class [Global]
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim StringResourceManager As New ResourceManager("Strings", [Assembly].GetExecutingAssembly())
        Dim ImageResourceManager As New ResourceManager("Images", [Assembly].GetExecutingAssembly())
        Application("UserCount") = 0
        Application("UserIDs") = ","
        Application.Add("StringRM", StringResourceManager)
        Application.Add("ImageRM", ImageResourceManager)
        Application("SendErrorToEmail") = ConfigurationSettings.AppSettings("SendErrorToEmail")
        Application("SendErrorFromEmail") = ConfigurationSettings.AppSettings("SendErrorFromEmail")
        Application("SmtpServer") = ConfigurationSettings.AppSettings("SmtpServer")
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        Session("InterfaceLanguage") = "unicode"
        Session("HelpInput") = False
        Session("HelpLibolType") = 1 ' Tro giup Opac =0; Tro giup Libol60=1
    End Sub

    ' Method: BindData
    Private Sub BindData()
        Dim objeMicLibLogin As New eMicLibLogin.clseMicLibLogin
        Session("ConnectionString") = objeMicLibLogin.GetConnectionString()
        Session("DBServer") = objeMicLibLogin.DBServer
        objeMicLibLogin = Nothing
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
        Application.Lock()
        If Application("UserCount") >= 1 Then
            Application("UserCount") = Application("UserCount") - 1
        End If
        Application("UserIDs") = Replace(Application("UserIDs"), "," & Session("UserID") & ",", ",")
        Application.UnLock()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub
End Class
