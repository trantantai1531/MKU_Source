Imports ComponentArt.Web.UI
Imports System.Data
Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqAddFolderValue
        Inherits clsWBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsNothing(Request("nodeName")) AndAlso Not Request("nodeName").Trim = "" Then
                txtNewFolder.Text = Request("nodeName").Trim
            Else
                txtNewFolder.EmptyText = span_input.InnerText
            End If

        End Sub
    End Class

End Namespace
