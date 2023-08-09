Imports System.Web
Imports System.Web.SessionState
Imports System.Resources
Imports System.Reflection
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.WebUI
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
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim StringResourceManager As New ResourceManager("Strings", [Assembly].GetExecutingAssembly())
        Dim ImageResourceManager As New ResourceManager("Images", [Assembly].GetExecutingAssembly())

        Application.Add("StringRM", StringResourceManager)
        Application.Add("ImageRM", ImageResourceManager)
        Application("SendErrorToEmail") = ConfigurationSettings.AppSettings("SendErrorToEmail")
        Application("SendErrorFromEmail") = ConfigurationSettings.AppSettings("SendErrorFromEmail")
        Application("SmtpServer") = ConfigurationSettings.AppSettings("SmtpServer")
        Application("ePageSize") = ConfigurationSettings.AppSettings("ePageSize")
        Application("ePageLength") = ConfigurationSettings.AppSettings("ePageLength")
        Application("ePageSpace") = ConfigurationSettings.AppSettings("ePageSpace")
        Application("IIPServer") = ConfigurationSettings.AppSettings("IIPServer")
        Application("eMagazinePageSize") = ConfigurationSettings.AppSettings("eMagazinePageSize")
        Application("eMagazinePageLength") = ConfigurationSettings.AppSettings("eMagazinePageLength")
        Application("eMagazinePageSpace") = ConfigurationSettings.AppSettings("eMagazinePageSpace")
        Application("callNumberLimit") = ConfigurationSettings.AppSettings("callNumberLimit")
        Application("AccountUrl") = ConfigurationSettings.AppSettings("AccountUrl")
        Application("OpacUrl") = ConfigurationSettings.AppSettings("OpacUrl")
        Application("SSCCoreApiUrl") = ConfigurationSettings.AppSettings("SSCCoreApiUrl")

        Application("OnlineCounters") = 0

        If clsLicense.CheckLicense() Then
            Application("licenseOpac") = True
        Else
            Application("licenseOpac") = False
        End If
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        clsSession.GlbInterfaceLanguage = "unicode"
        Call BindData()
        Session("UserID") = 1
        Session("OrderMode") = "off"
        Session("FullName") = "Administrator"
        Session("OPAC_COMENT") = 1
        Session("HelpInput") = False
        Session("HelpeMicLibType") = 0 ' Tro giup Opac =0; Tro giup eMicLib60=1
        clsSession.GlbUserLevel = 0
        ' Get search ubound in sys_parameter table
        Dim objBCDBS As New clsBCommonDBSystem
        Dim arrStr(3) As String
        Dim arrVal(3) As String

        objBCDBS.ConnectionString = Session("ConnectionString")
        objBCDBS.InterfaceLanguage = clsSession.GlbInterfaceLanguage
        objBCDBS.DBServer = Session("DBServer")
        objBCDBS.Initialize()


        Dim objBCounter As New clsBCounter
        objBCounter.ConnectionString = Session("ConnectionString")
        objBCounter.InterfaceLanguage = clsSession.GlbInterfaceLanguage
        objBCounter.DBServer = Session("DBServer")
        objBCounter.Initialize()

        arrStr(0) = "SEARCH_UBOUND"
        arrStr(1) = "SECURED_OPAC"
        arrStr(2) = "USED_CLASSIFICATION"
        arrStr(3) = "OPAC_TOP_TOPIC"
        arrVal = objBCDBS.GetSystemParameters(arrStr)
        Session("SearchUbound") = arrVal(0)
        Session("Secured_OPAC") = arrVal(1)
        clsSession.GlbClassification = arrVal(2)
        clsSession.GlbTopTopics = arrVal(3)
        clsSession.GlbOrderBy = "" '"TITLE"

        If Application("OnlineCounters") Is Nothing Then
            Application("OnlineCounters") = 1
            objBCounter.IPAddress = Request.UserHostAddress
            objBCounter.InsertCounter()
        Else
            Application("OnlineCounters") = Integer.Parse(Application("OnlineCounters")) + 1
            objBCounter.IPAddress = Request.UserHostAddress
            objBCounter.InsertCounter()
        End If

        objBCounter.Dispose(True)
        objBCounter = Nothing

        objBCDBS.Dispose(True)
        objBCDBS = Nothing
    End Sub
    ' Method: BindData
    Private Sub BindData()
        Dim objLg As New clseMicLibLogin
        Session("ConnectionString") = objLg.GetConnectionString
        Session("DBServer") = objLg.DBServer
        objLg = Nothing
    End Sub

    Public Function GetXmlFile(ByVal strFileNameXml As String) As DataTable
        ' Use function ConvertTable
        Dim blnReadyFile As Boolean
        blnReadyFile = False
        Dim strName As String = ""
        Dim dsResource As New DataSet
        Try
            dsResource.ReadXml(strFileNameXml)
            If dsResource.Tables.Count > 0 Then
                GetXmlFile = dsResource.Tables(0)
                dsResource.Tables.Clear()
            End If
        Catch ex As Exception
        Finally
        End Try
    End Function

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
        Session("SearchUbound") = Nothing
        ' Fires when the session ends
        Application.Lock()
        If Application("UserCount") >= 1 Then
            Application("UserCount") = Application("UserCount") - 1
        End If
        Application("UserIDs") = Replace(Application("UserIDs"), "," & Session("UserID") & ",", ",")


        If Application("OnlineCounters") >= 1 Then
            Application("OnlineCounters") = Integer.Parse(Application("OnlineCounters")) - 1
        End If


        Application.UnLock()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
