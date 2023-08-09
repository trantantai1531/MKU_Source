
Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WMainIndex
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Session("AdmModule") Is Nothing Then
                ' Admin module
                Session("ModuleID") = 6
                Session("ModuleName") = "Admin"

                If Session("AdmModule") = 0 Then
                    Response.Redirect("../WInvalidUser.aspx")
                End If
            Else
                Response.Redirect("../WNothing.aspx")
            End If
        End Sub
    End Class
End Namespace
