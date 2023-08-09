Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIndexDictionaries
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

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Select Case UCase(Session("TypeData"))
                Case "AUTHORITY"
                    Response.Redirect("WCatAuthority.aspx")
                Case "CLASSIFICATION"
                    Response.Redirect("WDicClassification.aspx")
                Case Else
                    Response.Redirect("WDicAuthority.aspx")
            End Select
        End Sub
    End Class
End Namespace