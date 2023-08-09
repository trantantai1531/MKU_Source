Imports eMicLibAdmin.WebUI.Common
Imports System.IO

Namespace eMicLibAdmin.Serial.Acquisition
    Partial Class WViewImage
        Inherits System.Web.UI.Page
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                If Not IsNothing(Request("strPath")) Then

                    Dim newWidth As Integer = 80
                    Dim newHeight As Integer = 120

                    Dim cardImage As System.Drawing.Image = Nothing
                    Dim MemStream As System.IO.MemoryStream = Nothing
                    Dim imageType As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                    MemStream = New System.IO.MemoryStream()

                    Dim objFI As New FileInfo(Request("strPath"))
                    If objFI.Exists Then
                        cardImage = System.Drawing.Image.FromFile(Request("strPath"))
                    Else
                        cardImage = System.Drawing.Image.FromFile(Server.MapPath("../Images/Card/empty.gif"))
                    End If
                    Select Case objFI.Extension.ToLower
                        Case ".gif"
                            imageType = System.Drawing.Imaging.ImageFormat.Gif
                            Response.ContentType = "image/gif"
                        Case ".jpg", ".jpeg"
                            imageType = System.Drawing.Imaging.ImageFormat.Jpeg
                            Response.ContentType = "image/jpeg"
                        Case ".png"
                            imageType = System.Drawing.Imaging.ImageFormat.Png
                            Response.ContentType = "image/png"
                        Case ".bmp"
                            imageType = System.Drawing.Imaging.ImageFormat.Bmp
                            Response.ContentType = "image/bmp"
                        Case ".tif", ".tiff"
                            imageType = System.Drawing.Imaging.ImageFormat.Tiff
                            Response.ContentType = "image/tiff"
                        Case Else
                            imageType = System.Drawing.Imaging.ImageFormat.Png
                            Response.ContentType = "image/jpeg"
                    End Select

                    With cardImage
                        newWidth = .Width
                        newHeight = .Height
                    End With

                    Dim thumbNailImg As System.Drawing.Image
                    thumbNailImg = clsWCommon.ResizeImage(cardImage, newWidth, newHeight)
                    thumbNailImg.Save(MemStream, imageType)
                    thumbNailImg.Dispose()

                    Dim objImage As Object
                    objImage = MemStream.ToArray()
                    Response.BinaryWrite(objImage)
                    Response.Flush()
                    Response.End()
                    Response.Close()
                End If
            End If
        End Sub
    End Class
End Namespace
