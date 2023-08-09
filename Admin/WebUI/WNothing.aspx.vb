Namespace eMicLibAdmin.WebUI
    Partial Class WNothing
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call BindJS()
        End Sub

        ' Method: BindJS
        ' Purpose: include all need js functions
        Private Sub BindJS()
            If Not IsNothing(Request("home")) AndAlso Request("home") <> "" Then
                'Page.RegisterClientScriptBlock("WAcqNothingJs", "<script language='javascript'>location.href='Acquisition/WACQIndex.aspx';</script>")
                Response.Redirect("Acquisition/WACQIndex.aspx", False)
            End If
        End Sub
    End Class

End Namespace
