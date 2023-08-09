Imports ComponentArt.Web.UI
Imports System.Data

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class Pages_AcqMagazineAddFolderValue
        Inherits clsWBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            txtNewFolder.EmptyText = span_input.InnerText
        End Sub
    End Class

End Namespace
