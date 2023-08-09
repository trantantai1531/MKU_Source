
Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OAbout
        Inherits clsWBaseJqueryUI

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Page.IsPostBack = False Then
                If Not IsNothing(Request.QueryString("link")) Then
                    HiddenFieldLink.Value = Request.QueryString("link")
                End If
            End If
        End Sub

    End Class
End Namespace
