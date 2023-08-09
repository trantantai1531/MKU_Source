Namespace eMicLibAdmin.WebUI.Common
    Partial Class WNCalendar
        Inherits System.Web.UI.Page

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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Dim strColLanguage As String
            Select Case clsSession.GlbLanguage
                Case "tcvn", "vni", "unicode"
                    strColLanguage = "vie"
                Case Else
                    strColLanguage = clsSession.GlbLanguage
            End Select

            Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = '" & strColLanguage & "';var imgDir=''</script>")
            Page.RegisterClientScriptBlock("RegisterCalendar", "<script language='javascript' src='PopCalendar.js'></script>")
            Page.RegisterClientScriptBlock("ShowCalendar", "<script language='javascript'>popUpCalendar(this, opener.document.forms[0]." & Request("id") & ", '" & Session("DateFormat") & "',26)</script>")
        End Sub

    End Class
End Namespace