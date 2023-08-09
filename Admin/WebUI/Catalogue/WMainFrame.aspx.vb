' WMainframe class
' Creator: Oanhtn
' CreatedDate: 27/02/2004
' Modification history 
' - 11/03/2004 by Oanhtn

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMainFrame
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
            If Not Session("CatModule") Is Nothing Then
                'CATALOG Module
                Session("ModuleID") = 1
                Session("ModuleName") = "Catalogue"

                If Session("CatModule") = 0 Then
                    Response.Redirect("../WInvalidUser.aspx")
                End If
            Else
                Response.Redirect("../WNothing.aspx")
            End If
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = 'js/WMainFrame.js'></script>")
        End Sub
        Protected Overrides Function SaveViewState() As Object
            'MyBase.LoadViewState(
        End Function
        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            Dim message As Object
            message = Session("IsAuthority")
            If Not (savedState Is Nothing) Then
                CType(message, IStateManager).LoadViewState(savedState)
            End If
        End Sub
    End Class
End Namespace