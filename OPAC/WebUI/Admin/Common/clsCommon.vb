Imports System.Data
Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.Text.RegularExpressions

Namespace eMicLibOPAC
    Public Class clsCommon

        Public Shared Function GetExtFile(ByVal fileName As String) As String
            Dim fn As String = fileName + String.Empty

            If fn = String.Empty Then
                Return String.Empty
            Else
                Dim i As Integer = fn.IndexOf(".") ' lay kieu file

                If i < 0 Then
                    Return String.Empty
                Else
                    Return fn.Substring(i) + String.Empty
                End If

            End If
        End Function


        Private Shared ReadOnly VietnameseSigns As String() = New String() {"aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", _
                                                                             "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", _
                                                                             "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ"}

        Public Shared Function RemoveSign4VietnameseString(ByVal str As String) As String
            For i As Integer = 1 To VietnameseSigns.Length - 1
                For j As Integer = 0 To VietnameseSigns(i).Length - 1
                    str = str.Replace(VietnameseSigns(i)(j), VietnameseSigns(0)(i - 1))
                Next
            Next
            Return str
        End Function


        ''' <summary>
        ''' CreateThumbnail function returns a Bitmap image of the changed thumbnail image which we can save on the disk.
        ''' </summary>
        Public Shared Function CreateThumbnail(ByVal ImagePath As String, ByVal ThumbnailWidth As Integer, ByVal ThumbnailHeight As Integer) As Bitmap
            Dim Thumbnail As System.Drawing.Bitmap = Nothing
            Try
                Dim ImageBMP As New Bitmap(ImagePath)
                Dim loFormat As ImageFormat = ImageBMP.RawFormat

                Dim lengthRatio As Decimal
                Dim ThumbnailNewWidth As Integer = 0
                Dim ThumbnailNewHeight As Integer = 0
                Dim ThumbnailRatioWidth As Decimal
                Dim ThumbnailRatioHeight As Decimal

                ' If the uploaded image is smaller than a thumbnail size the just return it
                If ImageBMP.Width <= ThumbnailWidth AndAlso ImageBMP.Height <= ThumbnailHeight Then
                    Return ImageBMP
                End If

                ' Compute best ratio to scale entire image based on larger dimension.
                If ImageBMP.Width > ImageBMP.Height Then
                    ThumbnailRatioWidth = CDec(ThumbnailWidth) / ImageBMP.Width
                    ThumbnailRatioHeight = CDec(ThumbnailHeight) / ImageBMP.Height
                    lengthRatio = Math.Min(ThumbnailRatioWidth, ThumbnailRatioHeight)
                    ThumbnailNewWidth = ThumbnailWidth
                    Dim lengthTemp As Decimal = ImageBMP.Height * lengthRatio
                    ThumbnailNewHeight = CInt(Math.Truncate(lengthTemp))
                Else
                    ThumbnailRatioWidth = CDec(ThumbnailWidth) / ImageBMP.Width
                    ThumbnailRatioHeight = CDec(ThumbnailHeight) / ImageBMP.Height
                    lengthRatio = Math.Min(ThumbnailRatioWidth, ThumbnailRatioHeight)
                    ThumbnailNewHeight = ThumbnailHeight
                    Dim lengthTemp As Decimal = ImageBMP.Width * lengthRatio
                    ThumbnailNewWidth = CInt(Math.Truncate(lengthTemp))
                End If
                Thumbnail = New Bitmap(ThumbnailNewWidth, ThumbnailNewHeight)
                Dim g As Graphics = Graphics.FromImage(Thumbnail)
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                g.FillRectangle(Brushes.White, 0, 0, ThumbnailNewWidth, ThumbnailNewHeight)
                g.DrawImage(ImageBMP, 0, 0, ThumbnailNewWidth, ThumbnailNewHeight)

                ImageBMP.Dispose()
            Catch
                Return Nothing
            End Try

            Return Thumbnail
        End Function

        Public Shared Function Filename(ByVal Chuoi As String) As String
            If Chuoi.Trim().Length > 0 Then
                If Chuoi.Trim().Length > 80 Then
                    Chuoi = Cat_Chuoi(80, Chuoi.Trim())
                End If
                Chuoi = RejectMarks(Chuoi.Trim())

                Return Chuoi.Replace(" ", "-") + "-"
            End If
            Return ""
        End Function


        Public Shared Function Cat_Chuoi(ByVal sl As Integer, ByVal Chuoi As String) As String
            If Chuoi.Trim().Length <= sl Then
                Return Chuoi
            Else
                For i As Integer = sl To Chuoi.Length - 1
                    If Chuoi(i).ToString() = " " Then
                        Return Chuoi.Substring(0, i) + "..."
                    End If
                Next
            End If
            Return Chuoi
        End Function


        Public Shared Function RejectMarks(ByVal text As String) As String
            text = text.Replace(":", "")
            text = text.Replace(".", "")
            text = text.Replace(",", "")
            text = text.Replace("?", "")
            text = text.Replace("!", "")
            text = text.Replace("@", "")
            text = text.Replace("'", "")
            text = text.Replace("""", "")
            text = text.Replace("%", "")
            text = text.Replace("$", "")
            text = text.Replace("^", "")
            text = text.Replace("&", "")
            text = text.Replace("*", "")
            text = text.Replace("(", "")
            text = text.Replace(")", "")
            text = text.Replace("=", "")
            text = text.Replace("+", "")
            text = text.Replace("/", "")
            text = text.Replace("–", "")
            text = text.Replace("-", "")
            text = text.Replace("|", "")
            text = text.Replace("#", "")
            text = text.Replace("  ", "-")
            text = RejectMarkst(text)
            text = RejectMarksh(text)
            Return text
        End Function

        Public Shared Function RejectMarksh(ByVal text As String) As String

            Dim pattern As String() = New String(6) {}
            pattern(0) = "A|(Á|Ả|À|Ạ|Ã|Ă|Ắ|Ẳ|Ằ|Ặ|Ẵ|Â|Ấ|Ẩ|Ầ|Ậ|Ẫ)"
            pattern(1) = "O|(Ó|Ỏ|Ò|Ọ|Õ|Ô|Ố|Ổ|Ồ|Ộ|Ỗ|Ơ|Ớ|Ở|Ờ|Ợ|Ỡ)"
            pattern(2) = "E|(É|È|Ẻ|Ẹ|Ẽ|Ê|Ế|Ề|Ể|Ệ|Ễ)"
            pattern(3) = "U|(Ú|Ù|Ủ|Ụ|Ũ|Ư|Ứ|Ừ|Ử|Ự|Ữ)"
            pattern(4) = "I|(Í|Ì|Ỉ|Ị|Ĩ)"
            pattern(5) = "Y|(Ý|Ỳ|Ỷ|Ỵ|Ỹ)"
            pattern(6) = "D|Đ"
            For i As Integer = 0 To pattern.Length - 1
                ' kí tự sẽ thay thế
                Dim replaceChar As Char = pattern(i)(0)
                Dim matchs As MatchCollection = Regex.Matches(text, pattern(i))
                For Each m As Match In matchs
                    text = text.Replace(m.Value(0), replaceChar)
                Next
            Next
            Return text
        End Function
        Public Shared Function RejectMarkst(ByVal text As String) As String
            Dim pattern As String() = New String(6) {}
            pattern(0) = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)"
            pattern(1) = "o|(ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ)"
            pattern(2) = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)"
            pattern(3) = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)"
            pattern(4) = "i|(í|ì|ỉ|ị|ĩ)"
            pattern(5) = "y|(ý|ỳ|ỷ|ỵ|ỹ)"
            pattern(6) = "d|đ"
            For i As Integer = 0 To pattern.Length - 1
                ' kí tự sẽ thay thế
                Dim replaceChar As Char = pattern(i)(0)
                Dim matchs As MatchCollection = Regex.Matches(text, pattern(i))
                For Each m As Match In matchs
                    text = text.Replace(m.Value(0), replaceChar)
                Next
            Next
            Return text
        End Function


    End Class
End Namespace

