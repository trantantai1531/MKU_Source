Imports System.IO
Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OViewImage
        Inherits System.Web.UI.Page
        'Inherits clsWBaseJqueryUI
        Private objBItemDissertation As New clsBItemDissertation

        Private Sub Initialize()
            objBItemDissertation.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemDissertation.DBServer = Session("DBServer")
            objBItemDissertation.ConnectionString = Session("ConnectionString")
            objBItemDissertation.Initialize()
        End Sub
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Call Initialize()
                If (Not IsNothing(Request("intItemId"))) And (Not IsNothing(Request("intYear"))) And (Not IsNothing(Request("strNumber"))) Then
                    Try
                        objBItemDissertation.ItemID = CInt(Request("intItemId"))
                        objBItemDissertation.Year = CInt(Request("intYear"))
                        objBItemDissertation.Number = Request("strNumber")
                        Dim item As DataTable = objBItemDissertation.GetItemDissertation()
                        If Not IsNothing(item) Then
                            Dim newWidth As Integer = 80
                            Dim newHeight As Integer = 120

                            Dim cardImage As System.Drawing.Image = Nothing
                            Dim MemStream As System.IO.MemoryStream = Nothing
                            Dim imageType As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
                            MemStream = New System.IO.MemoryStream()

                            Dim objFI As New FileInfo(item.Rows(0).Item("PathImage"))
                            If objFI.Exists Then
                                cardImage = System.Drawing.Image.FromFile(item.Rows(0).Item("PathImage"))
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
                            thumbNailImg = ResizeImage(cardImage, newWidth, newHeight)
                            thumbNailImg.Save(MemStream, imageType)
                            thumbNailImg.Dispose()


                            Dim objImage As Object
                            objImage = MemStream.ToArray()
                            Response.BinaryWrite(objImage)
                            Response.Flush()
                            Response.End()
                            Response.Close()
                        End If
                    Catch ex As Exception
                        Return
                    End Try

                End If
            End If
        End Sub

        Private Shared Function ResizeImage(ByVal original As System.Drawing.Image, ByVal _Width As Integer, ByVal _Height As Integer) As System.Drawing.Image
            Try
                Dim tn As New System.Drawing.Bitmap(_Width, _Height)
                Dim g As Graphics = Graphics.FromImage(tn)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
                g.DrawImage(original, New System.Drawing.Rectangle(0, 0, tn.Width, tn.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel)
                g.Dispose()
                Return CType(tn, System.Drawing.Image)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
