Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Public Class s3capcha_s3capcha
        Inherits System.Web.UI.UserControl

        Public Sub SetIt()
            Dim USessionId As Integer
            CapchaHTML.Text = clsS3capcha.GetHtmlCodes(ResolveClientUrl("~/s3capcha"), USessionId)
            Session(clsS3capcha.s3name) = USessionId
        End Sub


        Public ReadOnly Property IsValid() As Boolean
            Get
                Dim res As Boolean = clsS3capcha.Verify(Session(clsS3capcha.s3name), Request.Form(clsS3capcha.s3name))
                SetIt()
                Return res
            End Get
        End Property

     
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                SetIt()
            End If
        End Sub
    End Class
End Namespace
