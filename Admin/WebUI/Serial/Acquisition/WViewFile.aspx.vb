Imports System.Net

Namespace eMicLibAdmin.Serial.Acquisition

End Namespace
Partial Class Serial_Acquisition_WViewFile
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            If Not IsNothing(Request("strPath")) Then

                Dim path As String = Request("strPath")
                Dim client As New WebClient()
                Dim buffer As [Byte]() = client.DownloadData(path)

                If buffer IsNot Nothing Then
                    Response.Clear()
                    Response.ContentType = "application/pdf"
                    Response.AddHeader("content-length", buffer.Length.ToString())
                    Response.BinaryWrite(buffer)
                    Response.End()
                End If

                'ltrFrame.Text = "<iframe src=""" & Request("strPath") & """></iframe>"
            End If
        End If
    End Sub
End Class
