Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqDisplayControl
        Inherits clsWBase

        Protected Sub ToolBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar.Load
            Call ChangeLanguage()
        End Sub
        Private Sub ChangeLanguage()
            ToolBar.Items(0).Text = span_acquisition.InnerText
            ToolBar.Items(2).Text = span_close.InnerText
        End Sub

    End Class
End Namespace

