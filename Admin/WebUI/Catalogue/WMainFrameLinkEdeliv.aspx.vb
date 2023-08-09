Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class Catalogue_WMainFrameLinkEdeliv
        Inherits clsWBase
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
     
        Protected Overrides Sub LoadViewState(ByVal savedState As Object)
            Dim message As Object
            message = Session("IsAuthority")
            If Not (savedState Is Nothing) Then
                CType(message, IStateManager).LoadViewState(savedState)
            End If
        End Sub
    End Class
End Namespace

