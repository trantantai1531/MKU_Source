' Name: ShowPic
' Purpose: write image
' Creator: Oanhtn
' CreatedDate: 07/09/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.WebUI.Common
Imports System.IO

Namespace eMicLibAdmin.WebUI
    Partial Class ShowPic
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim intw As Integer
            Dim inth As Integer
            Dim strUrl As String = ""

            intw = Request.QueryString("intw")
            inth = Request.QueryString("inth")
            strUrl = Request.QueryString("Url")

            Dim newWidth As Integer = 80
            Dim newHeight As Integer = 120

            Dim cardImage As System.Drawing.Image = Nothing
            Dim MemStream As System.IO.MemoryStream = Nothing
            Dim imageType As System.Drawing.Imaging.ImageFormat = System.Drawing.Imaging.ImageFormat.Png
            MemStream = New System.IO.MemoryStream()

            Dim objFI As New FileInfo(Server.MapPath(strUrl))
            If objFI.Exists Then
                cardImage = System.Drawing.Image.FromFile(Server.MapPath(strUrl))
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
                If .Width > intw Or .Height > inth Then
                    newWidth = .Width
                    newHeight = .Height
                    If .Width > intw Then
                        newWidth = intw
                        newHeight = (newWidth * .Height) / .Width
                    End If
                    If newHeight > inth Then
                        newWidth = (newWidth * inth) / newHeight
                        newHeight = inth
                    End If
                End If
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


        End Sub
    End Class
End Namespace