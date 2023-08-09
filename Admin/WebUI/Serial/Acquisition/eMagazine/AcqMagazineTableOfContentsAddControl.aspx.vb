﻿Namespace eMicLibAdmin.WebUI.Serial
    Partial Class Pages_AcqMagazineTableOfContentsAddControl
        Inherits clsWBase
        Protected Sub ToolBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBar.Load
            Call ChangeLanguage()
        End Sub
        Private Sub ChangeLanguage()
            ToolBar.Items(0).Text = span_Toolbar_item0.InnerText
            ToolBar.Items(2).Text = span_Toolbar_item2.InnerText
            If Not Request.QueryString("addnew") Is Nothing AndAlso Request.QueryString("addnew") = "1" Then
                ToolBar.Items(0).Value = "addTableofcontent"
            Else
                ToolBar.Items(0).Value = "renameTableofcontent"
            End If
        End Sub
    End Class
End Namespace

