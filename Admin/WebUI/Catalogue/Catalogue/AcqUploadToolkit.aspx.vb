Imports System.IO
Imports System.IO.Path
Imports System.Drawing
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class Pages_AcqUploadToolkit
        Inherits clsWBase

        Protected Function ResizeImage(ByVal original As System.Drawing.Image, ByVal _Width As Integer, ByVal _Height As Integer) As System.Drawing.Image
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

        Protected Sub AsyncFileUpload1_UploadedComplete(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs)
            Try
                Dim intFileType As Integer = 0
                If (AsyncFileUpload1.HasFile) Then
                    'Dim _fileName As String = Format(Now, "yyyyMMddhhmmssfff") & Path.GetExtension(e.FileName)
                    Dim strTempPath As String = Server.MapPath("~/Upload/ImageCover/") & Format(Now, "yyyyMMddhhmmssfff") & Path.GetExtension(e.filename)
                    intFileType = clswCommon.GetFileMediaType(strTempPath)
                    If intFileType = clsWCommon.gfileType.ePicture Then
                        AsyncFileUpload1.SaveAs(strTempPath)
                        Dim fileName As String = Path.GetFileName(e.filename) ' Format(Now, "yyyyMMddhhmmssfff") & Path.GetExtension(e.FileName)

                        fileName = clsWCommon.ChangeFileName(fileName)

                        Dim strDictionary As String = Now.Year.ToString & "\" & Now.Month.ToString & "\" & Now.Day.ToString  'Format(Now, "yyyyMMdd")
                        Dim strPath As String = Server.MapPath("~/Upload/ImageCover/") & strDictionary
                        If Not Directory.Exists(strPath) Then
                            Directory.CreateDirectory(strPath)
                        End If
                        If strPath.EndsWith("\") = False Then
                            strPath &= "\"
                        End If
                        strPath &= fileName

                        Dim imgResize As System.Drawing.Image = System.Drawing.Image.FromFile(strTempPath)
                        Dim thumbNailImg As System.Drawing.Image
                        thumbNailImg = ResizeImage(imgResize, Me.getWidthCover, Me.getHeightCover)
                        thumbNailImg.Save(strPath, System.Drawing.Imaging.ImageFormat.Jpeg)
                        thumbNailImg.Dispose()
                        imgResize.Dispose()
                        imgResize = Nothing
                        thumbNailImg = Nothing
                        MyImageCover.Src = "../../Upload/ImageCover/" & strDictionary & "/" & fileName
                        Session("imageCover") = strPath

                        File.Delete(strTempPath)
                        'lnkDelete.Visible = True
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If Not IsPostBack Then
                    'lnkDelete.Visible = False
                    'If Not IsNothing(Session("imageCover")) Then
                    '    Dim strPath As String = Session("imageCover")
                    '    Dim strImageCover As String = ""
                    '    Dim intImageCover As String = InStr(strPath, "\ImageCover\")
                    '    If intImageCover > 0 Then
                    '        strImageCover = strPath.Substring(InStr(strPath, "\ImageCover\") + 11)
                    '        strImageCover = Replace(strImageCover, "\", "/")
                    '    Else
                    '        strImageCover = "emiclibBlank.jpg"
                    '    End If
                    '    MyImageCover.Src = "../../Upload/ImageCover/" & strImageCover 'Path.GetFileName(strPath)
                    '    'lnkDelete.Visible = True
                    'End If
                    Dim strPath As String = ""
                    If Not IsNothing(Request("sfile")) AndAlso Request("sfile") <> "" Then
                        strPath = Request("sfile")
                        If strPath.Trim <> "" Then
                            Dim strImageCover As String = ""
                            Dim intImageCover As String = InStr(strPath, "/ImageCover/")
                            If intImageCover > 0 Then
                                strImageCover = strPath.Substring(InStr(strPath, "/ImageCover/") + 11)
                            Else
                                strImageCover = "emiclibBlank.jpg"
                            End If
                            MyImageCover.Src = "../../Upload/ImageCover/" & strImageCover
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function Delete_Image_Cover() As Integer
            Dim intResult As Integer = 0
            Try
                Try
                    If Not IsNothing(Session("imageCover")) Then
                        Dim strPath As String = Session("imageCover")
                        If File.Exists(strPath) Then
                            File.Delete(strPath)
                            'lnkDelete.Visible = False
                            intResult = 1
                        End If
                    End If
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function callbackChangeFileName(ByVal fileName As String) As String
            Dim strResult As String = ""
            Try
                strResult = clsWCommon.ChangeFileName(fileName)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        
    End Class
End Namespace

