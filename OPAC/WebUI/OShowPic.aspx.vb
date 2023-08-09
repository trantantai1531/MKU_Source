Imports System.Drawing.Imaging

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OShowPic
        Inherits System.Web.UI.Page

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Not IsNothing(Request("FilePath")) Then
                    Dim imgResize As System.Drawing.Image = System.Drawing.Image.FromFile(Request("FilePath"))
                    Dim thumbNailImg As System.Drawing.Image
                    thumbNailImg = ResizeImage(imgResize, 100)
                    thumbNailImg.Save(Response.OutputStream, ImageFormat.Gif)
                    thumbNailImg.Dispose()
                    imgResize.Dispose()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function ResizeImage(ByVal original As System.Drawing.Image, ByVal percent As Integer) As System.Drawing.Image
            Try
                Dim intWidth As Integer = ConfigurationSettings.AppSettings("eMagazineWidthCover")  'original.Width * CInt(percent / 100)
                Dim intHeight As Integer = ConfigurationSettings.AppSettings("eMagazineHeightCover") ' original.Height * CInt(percent / 100)
                Dim tn As New System.Drawing.Bitmap(intWidth, intHeight)
                Dim g As Graphics = Graphics.FromImage(tn)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                g.DrawImage(original, New System.Drawing.Rectangle(0, 0, tn.Width, tn.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel)
                g.Dispose()
                Return CType(tn, System.Drawing.Image)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
