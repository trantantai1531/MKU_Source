Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class Pages_AcqDisplayControlChooseFiles
        Inherits clsWBase

        Protected Sub ToolBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar.Load
            Call ChangeLanguage()
        End Sub
        Private Sub ChangeLanguage()
            ToolBar.Items(0).Text = span_acquisition.InnerText
        End Sub
    End Class

End Namespace
