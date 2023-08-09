Imports eMicLibAdmin.WebUI

Partial Class main
    Inherits Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Call getSite()

            Call ControlInit()
        End If
    End Sub

    'spLibrary
    Private Sub getSite()
        Try
            If Not IsNothing(Request("Site")) AndAlso Request("Site") <> "" Then
                clsSession.GlbSite = Request("Site")
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub ControlInit()
        ltlogin.Text = clsSession.GlbUserFullName
        'Call GetRootPath()
        'lkbLogout.PostBackUrl = Me._RootPath & "index.aspx?out=ok"
    End Sub
End Class
