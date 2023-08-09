Imports System.Xml
Imports System.Data
Imports System.Collections.Generic
Imports System.Drawing.Imaging
Imports System.Text.RegularExpressions
Imports System.IO
Imports Aspose.Words
Imports System.Runtime.CompilerServices

Namespace eMicLibAdmin.WebUI.Common
    Public Class clsWCommon
        Public Enum MAIN_TOOLBAR
            UserManagement = 20
            LogManangement = 3
            SystemParameter = 22
            SystemLanguage = 21
            RoleManangement = 18
            UserGroupManagement = 19
            ChangePass = 4
            catSetValueDefault = 9
            catAddRecord = 10
            catTableOfContent = 11
            catRecordManagement = 12
            catFileManagement = 13
            catExport2File = 14
            catImportFromFile = 15
            catImportFromZ3950 = 16
        End Enum
        Public Enum ACTION_ID
            eNew = 1
            eUpdate = 2
            eDelete = 3
            eView = 4
            eDownload = 5
            ePrint = 6
            ePublish = 7
        End Enum
        Public Enum gViewer
            TableOfContent = 1
            NotTableOfContent = 2
            FullTableOfContent = 3
        End Enum

        Public Enum gfileType
            eEbook = 4
            ePicture = 1
            eMedia = 2
            eSound = 3
        End Enum

        Public Enum COM_INFO
            Infomation = 1
            Warning = 2
            Question = 3

            _New = 10
            _Save = 11
            _Edit = 12
            _Delete = 13
            _Search = 14
            _ExportToExcel = 15
            _Register = 16
            _Cancel = 17
            _Close = 19

            SaveSuccess = 20
            SaveError = 21
            DeleteSuccess = 22
            DeleteError = 23
            DeleteRequired = 24
            ExistsData = 25

            addField = 26
            z3950 = 27
            view = 28
            reuse = 29

            tableofcontent = 30
            folder = 31
            viewrecord = 32
        End Enum

        Public Shared gImageWidthCollection As String = ReturnValueURL("imageWidthCollection")
        Public Shared gImageHeightCollection As String = ReturnValueURL("imageHeightCollection")
        Public Shared gIIPServer As String = ReturnValueURL("IIPServer")
        Public Shared gBarcodeWidth As String = ReturnValueURL("barcodeWidth")
        Public Shared gBarcodeHeight As String = ReturnValueURL("barcodeHeight")
        Public Shared gBarcodeType As String = ReturnValueURL("barcodeType")
        Public Shared gBarcodeLabelShow As String = ReturnValueURL("barcodeLabelShow")

        Public Shared gAutoDBServer As String = ""
        Public Shared gAutoConnectionString As String = ""
        Public Shared gInterfaceLanguage As String = ""

        Public Shared Function ResizeImage(ByVal original As System.Drawing.Image, ByVal _Width As Integer, ByVal _Height As Integer) As System.Drawing.Image
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

        Public Shared Function getTextLog(ByVal idXml As Integer, Optional ByVal lang As String = "vie") As String
            Dim strUrl As String = ""
            Try
                Dim xmlDoc As XmlDocument
                Dim xmlNodeListDoc As XmlNodeList
                xmlDoc = New XmlDocument()
                Dim intIndex As Integer = 1
                If Not lang = "vie" Then
                    intIndex = 2
                End If
                xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~") & "\Log\Log.xml")
                xmlNodeListDoc = xmlDoc.SelectNodes("/Log/Group/Item")
                For Each nodeDoc In xmlNodeListDoc
                    If idXml = nodeDoc.Attributes.Item(0).Value() Then
                        strUrl = nodeDoc.Attributes.Item(intIndex).Value()
                        Exit For
                    End If
                Next
            Catch ex As Exception
            End Try
            Return strUrl
        End Function

        Public Shared Function COM_MESS(ByVal mess As Integer, ByVal strLang As String) As String
            Try
                Select Case mess
                    Case COM_INFO.Infomation : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Thông tin", "Infomation")
                    Case COM_INFO.Warning : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Cảnh báo", "Warning")
                    Case COM_INFO.Question : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Câu hỏi", "Question")

                    Case COM_INFO.SaveSuccess : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Lưu dữ liệu thành công", "Data has been saved.")
                    Case COM_INFO.SaveError : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Lưu dữ liệu thất bại", "Data save failed.")
                    Case COM_INFO.DeleteSuccess : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Xóa dữ liệu thành công", "Data has been deleted.")
                    Case COM_INFO.DeleteError : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Xóa dữ liệu thất bại", "Failure to delete data.")
                    Case COM_INFO.DeleteRequired : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Vui lòng chọn dữ liệu cần xóa", "Please select record to delete.")

                    Case COM_INFO.ExistsData : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Đã tồn tại dữ liệu này, vui lòng kiểm tra lại", "This record already exists in a database, try again please.")


                    Case COM_INFO._New : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Thêm mới", "Add new")
                    Case COM_INFO._Save : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Lưu", "Save")
                    Case COM_INFO._Edit : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Sửa", "Edit")
                    Case COM_INFO._Delete : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Xóa", "Delete")
                    Case COM_INFO._Search : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Tìm", "Search")
                    Case COM_INFO._Cancel : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Hủy", "Cancel")
                    Case COM_INFO._ExportToExcel : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Xuất Excel", "Export to Excel")
                    Case COM_INFO.addField : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Thêm trường", "Add field")
                    Case COM_INFO.z3950 : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Tải về qua Z39.50", "Get record from Z39.50")
                    Case COM_INFO.view : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Xem", "View")
                    Case COM_INFO.reuse : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Dùng lại", "Reuse")

                    Case COM_INFO._Register : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Đăng ký", "Create My Account")

                    Case COM_INFO._Close : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Đóng", "Close")

                    Case COM_INFO.tableofcontent : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Mục lục", "Table of content")
                    Case COM_INFO.folder : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Tư liệu điện tử", "Electronic data")
                    Case COM_INFO.viewrecord : Return IIf(strLang Is Nothing OrElse strLang = "vie", "Bản ghi biên mục", "Cataloging record")

                    Case Else : Return ""
                End Select
            Catch ex As Exception
                Return ""
            End Try
        End Function
        Public Shared Sub MyMsgBoxInfor(ByVal strMsg As String, ByVal cls As Object)
            ScriptManager.RegisterStartupScript(cls, cls.GetType(), "javascriptfunction", strMsg, True)
        End Sub

        Public Shared Function ChangeFileName(ByVal strPv As String, Optional ByVal strJoinSign As String = "_") As String
            Dim str As String = ""
            Try
                If Trim(strPv & "") <> "" Then
                    str = strPv
                    str = Replace(str, "/", " ")
                    str = Replace(str, ",", " ")
                    str = Replace(str, ":", " ")
                    str = Replace(str, ";", " ")
                    str = Replace(str, "?", " ")
                    str = Replace(str, "!", " ")
                    str = Replace(str, "[", " ")
                    str = Replace(str, "]", " ")
                    str = Replace(str, "=", " ")
                    str = Replace(str, "(", " ")
                    str = Replace(str, ")", " ")
                    str = Replace(str, """", " ")
                    str = Replace(str, "--", " ")
                    str = Replace(str, "-", " ")
                    str = Replace(str, "  ", " ")
                    str = Replace(str, "©", " ")
                    str = Replace(str, "'", " ")
                    str = Replace(str, "+", "")
                    str = Replace(str, "&", "")
                    Do While InStr(str, "  ") > 0
                        str = Replace(str, "  ", " ")
                    Loop
                    str = CutVietnameseAccent(str)
                    str = Replace(str, Space(1), strJoinSign)
                End If
            Catch ex As Exception
            End Try
            Return str
        End Function

        ' Cut vietnamese accent method
        ' INPUT: vietnamese accent string
        ' OUTPUT: string with no accent
        Public Shared Function CutVietnameseAccent(ByVal strInputs As String) As String
            Dim strNoAccentChar As String
            Dim strOutput As String = ""
            Dim strInput As String
            Dim inti As Integer
            If strInputs & "" = "" Then
                CutVietnameseAccent = ""
                Exit Function
            End If
            For inti = 0 To strInputs.Length - 1
                strInput = strInputs.Chars(inti)
                If InStr("A,À,Á,Ả,Ã,Ạ,Â,Ầ,Ấ,Ẩ,Ẫ,Ậ,Ă,Ằ,Ắ,Ẳ,Ẵ,Ặ", strInput) > 0 Then
                    strNoAccentChar = "A"
                ElseIf InStr("a,à,á,ả,ã,ạ,â,ầ,ấ,ẩ,ẫ,ậ,ă,ằ,ắ,ẳ,ẵ,ặ", strInput) > 0 Then
                    strNoAccentChar = "a"
                ElseIf InStr("E,È,É,Ẻ,Ẽ,Ẹ,Ê,Ề,Ế,Ể,Ễ,Ệ", strInput) > 0 Then
                    strNoAccentChar = "E"
                ElseIf InStr("e,è,é,ẻ,ẽ,ẹ,ê,ề,ế,ể,ễ,ệ", strInput) > 0 Then
                    strNoAccentChar = "e"
                ElseIf InStr("U,Ù,Ú,Ủ,Ũ,Ụ,Ư,Ừ,Ứ,Ử,Ữ,Ự", strInput) > 0 Then
                    strNoAccentChar = "U"
                ElseIf InStr("u,ù,ú,ủ,ũ,ụ,ư,ừ,ứ,ử,ữ,ự", strInput) > 0 Then
                    strNoAccentChar = "u"
                ElseIf InStr("I,Ì,Í,Ỉ,Ĩ,Ị", strInput) > 0 Then
                    strNoAccentChar = "I"
                ElseIf InStr("i,ì,í,ỉ,ĩ,ị", strInput) > 0 Then
                    strNoAccentChar = "i"
                ElseIf InStr("O,Ò,Ó,Ỏ,Õ,Ọ,Ô,Ồ,Ố,Ổ,Ỗ,Ộ,Ơ,Ờ,Ớ,Ở,Ỡ,Ợ", strInput) > 0 Then
                    strNoAccentChar = "O"
                ElseIf InStr("o,ò,ó,ỏ,õ,ọ,ô,ồ,ố,ổ,ỗ,ộ,ơ,ờ,ớ,ở,ỡ,ợ", strInput) > 0 Then
                    strNoAccentChar = "o"
                ElseIf InStr("Y,Ỳ,Ý,Ỷ,Ỹ,Ỵ", strInput) > 0 Then
                    strNoAccentChar = "Y"
                ElseIf InStr("y,ỳ,ý,ỷ,ỹ,ỵ", strInput) > 0 Then
                    strNoAccentChar = "y"
                ElseIf InStr("đ", strInput) > 0 Then
                    strNoAccentChar = "d"
                ElseIf InStr("Đ", strInput) > 0 Then
                    strNoAccentChar = "D"
                Else
                    strNoAccentChar = strInput
                End If
                strOutput = strOutput & strNoAccentChar
            Next
            Return strOutput
        End Function

        Public Shared Function GetFileMediaType(ByVal strFilePath As String) As Integer
            Dim intMediaType As Integer = 0
            Dim strExtension As String = ""

            strExtension = LCase(Right(strFilePath, Len(strFilePath) - InStrRev(strFilePath, ".")))
            Try
                Select Case strExtension.ToLower
                    Case "bmp", "gif", "jpg", "jpeg", "tif", "tiff", "pcx", "png", "jpe", "tga"
                        intMediaType = 1
                    Case "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf", "flv", "mp4", "ivf", "div", "divx", "m4v", "mpe", "wmv", "mov", "qt", "ts", "mts", "m2t", "m2ts", "mod", "tod", "vro", "dat", "3pg2", "3gpp", "3gp", "3g2", "dvr", "ms", "f4v", "amv", "rm", "rmm", "rv", "rmvb", "ogv", "mkv"
                        intMediaType = 2
                    Case "mp3", "wav", "aac", "wma", "m4a", "m4b", "ogg", "flac", "ra", "ram", "amr", "ape", "mka", "tta", "aiff", "au", "mpc", "spx", "ac3"
                        intMediaType = 3
                    Case "doc", "docx", "pdf", "ps", "html", "htm", "rtf", "txt", "ppt", "pptx", "pps", "xls", "xlsx", "prc", "lit", "chm", "comic", "epub", "fb2", "htlz", "lrf", "mobi", "odt", "pdb", "pml", "rb", "recipe", "snb", "tcr"
                        intMediaType = 4
                    Case "exe"
                        intMediaType = 5
                    Case Else
                        intMediaType = 6
                End Select
            Catch ex As Exception : End Try
            Return intMediaType
        End Function


        Public Shared Function ReturnValueURL(ByVal key As String) As String
            Return Global.System.Configuration.ConfigurationManager.AppSettings(key).ToString
        End Function

        Public Shared Function CutWords(ByVal _words As String, Optional ByVal _CountCutWords As Integer = 10) As String
            Dim _str As String = ""
            Try
                Dim _cutWord As String = ""
                Dim _arrWord() As String = Nothing
                Dim _bol As Boolean = False
                _cutWord = _words
                _arrWord = Split(_cutWord, " ")
                _bol = False
                _str = ""
                If _CountCutWords >= UBound(_arrWord) Then
                    _CountCutWords = UBound(_arrWord)
                    _bol = True
                End If
                For i As Integer = 0 To _CountCutWords
                    _str &= _arrWord(i) & " "
                Next
                If Not _bol Then
                    _str &= "..."
                End If
            Catch ex As Exception

            End Try
            Return _str
        End Function


        Public Shared Function GetImage(ByVal _FilePath As String) As String
            Dim strFileType As String = ""
            Try
                _FilePath = LCase(Right(_FilePath, Len(_FilePath) - InStrRev(_FilePath, ".") + 1))
                If _FilePath.ToLower.EndsWith(".doc") Or _FilePath.ToLower.EndsWith(".docx") Then
                    strFileType = "document/doc.png"
                ElseIf _FilePath.ToLower.EndsWith(".pdf") Then
                    strFileType = "document/pdf.png"
                ElseIf _FilePath.ToLower.EndsWith(".html") Or _FilePath.ToLower.EndsWith(".htm") Then
                    strFileType = "document/html.png"
                ElseIf _FilePath.ToLower.EndsWith(".ppt") Or _FilePath.ToLower.EndsWith(".pptx") Then
                    strFileType = "document/ppt.png"
                ElseIf _FilePath.ToLower.EndsWith(".xls") Or _FilePath.ToLower.EndsWith(".xlsx") Then
                    strFileType = "document/xls.png"
                ElseIf _FilePath.ToLower.EndsWith(".rtf") Then
                    strFileType = "document/rtf.png"
                ElseIf _FilePath.ToLower.EndsWith(".prc") Then
                    strFileType = "document/prc.png"
                ElseIf _FilePath.ToLower.EndsWith(".lit") Then
                    strFileType = "document/lit.png"
                ElseIf _FilePath.ToLower.EndsWith(".txt") Then
                    strFileType = "document/txt.png"
                ElseIf _FilePath.ToLower.EndsWith(".chm") Then
                    strFileType = "document/chm.png"
                ElseIf _FilePath.ToLower.EndsWith(".mobi") Then
                    strFileType = "document/mobi.png"
                ElseIf _FilePath.ToLower.EndsWith(".epub") Then
                    strFileType = "document/epub.png"
                Else
                    If _FilePath.Substring(0, 1) = "." Then
                        Select Case _FilePath
                            Case ".mpg", ".avi", ".asf", ".mpeg", ".mov", ".flc", ".mpv", ".swf", ".flv", ".mp4", ".ivf", ".div", ".divx", ".m4v", ".mpe", ".wmv", ".mov", ".qt", ".ts", ".mts", ".m2t", ".m2ts", ".mod", ".tod", ".vro", ".dat", ".3pg2", ".3gpp", ".3gp", ".3g2", ".dvr", ".ms", ".f4v", ".amv", ".rm", ".rmm", ".rv", ".rmvb", ".ogv", ".mkv"
                                strFileType = "Media/Media.png"
                            Case ".mp3", ".wav", ".aac", ".wma", ".m4a", ".m4b", ".ogg", ".flac", ".ra", ".ram", ".amr", ".ape", ".mka", ".tta", ".aiff", ".au", ".mpc", ".spx", ".ac3"
                                strFileType = "Audio/Sound.png"
                            Case ".bmp", ".gif", ".jpg", ".jpeg", ".tif", ".tiff", ".pcx", ".png", ".jpe", ".tga"
                                strFileType = "Picture/Picture.png"
                            Case ".exe"
                                strFileType = "exe/exe.png"
                            Case Else
                                strFileType = "Other/Other.png"
                        End Select
                    Else
                        strFileType = "other/other.png"
                    End If
                End If
            Catch ex As Exception

            End Try
            Return strFileType
        End Function

        Public Shared Function GetExtensionFileType(ByVal strExtension As String) As Integer
            Dim intMediaType As Integer = 0
            Try
                Select Case strExtension.ToLower
                    Case ".bmp", ".gif", ".jpg", ".jpeg", ".tif", ".tiff", ".pcx", ".png", ".jpe", ".tga"
                        intMediaType = 1
                    Case ".mpg", ".avi", ".asf", ".mpeg", ".mov", ".flc", ".mpv", ".swf", ".flv", ".mp4", ".ivf", ".div", ".divx", ".m4v", ".mpe", ".wmv", ".mov", ".qt", ".ts", ".mts", ".m2t", ".m2ts", ".mod", ".tod", ".vro", ".dat", ".3pg2", ".3gpp", ".3gp", ".3g2", ".dvr", ".ms", ".f4v", ".amv", ".rm", ".rmm", ".rv", ".rmvb", ".ogv", ".mkv"
                        intMediaType = 2
                    Case ".mp3", ".wav", ".aac", ".wma", ".m4a", ".m4b", ".ogg", ".flac", ".ra", ".ram", ".amr", ".ape", ".mka", ".tta", ".aiff", ".au", ".mpc", ".spx", ".ac3"
                        intMediaType = 3
                    Case ".doc", ".docx", ".pdf", ".ps", ".html", ".htm", ".rtf", ".txt", ".ppt", ".pptx", ".pps", ".xls", ".xlsx", ".prc", ".lit", ".chm", ".comic", ".epub", ".fb2", ".htlz", ".lrf", ".mobi", ".odt", ".pdb", ".pml", ".rb", ".recipe", ".snb", ".tcr"
                        intMediaType = 4
                    Case ".exe"
                        intMediaType = 5
                    Case Else
                        intMediaType = 6
                End Select
            Catch ex As Exception : End Try
            Return intMediaType
        End Function

        ' Formats the file size string 
        Public Shared Function GetSizeString(ByVal length As Long) As String
            Dim strResult As String = ""
            Try
                strResult = (Convert.ToInt32(length / 1000) + 1).ToString() & " KB"
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' Returns item attributes based on its extension 
        Public Shared Function getItemAttributes(ByVal Extension As String, Optional ByVal _size As String = "32") As ItemAttributes
            Dim attribs As New ItemAttributes()
            Select Case Extension.ToLower()
                Case ""
                    attribs.Icon = "folder.png"
                    attribs.Type = "File Folder"
                    Exit Select
                Case ".mp3"
                    attribs.Icon = "FileType/Audio/mp3/MP3" & _size & ".png"
                    attribs.Type = "Audio File"
                    Exit Select
                Case ".wav"
                    attribs.Icon = "FileType/Audio/wav/WAV" & _size & ".png"
                    attribs.Type = "Audio File"
                    Exit Select
                Case ".html", ".htm"
                    attribs.Icon = "FileType/document/html/html" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".xls", ".xlsx"
                    attribs.Icon = "FileType/document/excel/Excel" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".ppt", ".pptx"
                    attribs.Icon = "FileType/document/powerpoint/PowerPoint" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".rtf"
                    attribs.Icon = "FileType/document/rtf/rtf" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".txt"
                    attribs.Icon = "FileType/document/text/txt" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".doc", ".docx"
                    attribs.Icon = "FileType/document/word/Word" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".pdf"
                    attribs.Icon = "FileType/document/pdf/pdf" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".xml"
                    attribs.Icon = "FileType/document/xml/xml" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".exe"
                    attribs.Icon = "FileType/exec/exec" & _size & ".png"
                    attribs.Type = "Exe File"
                    Exit Select
                Case ".avi"
                    attribs.Icon = "FileType/media/avi/avi" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".flv"
                    attribs.Icon = "FileType/media/flv/flv" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".mov"
                    attribs.Icon = "FileType/media/mov/mov" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".mpeg"
                    attribs.Icon = "FileType/media/mpeg/mpeg" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".mpg"
                    attribs.Icon = "FileType/media/mpg/mpg" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".swf"
                    attribs.Icon = "FileType/media/swf/swf" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".bmp"
                    attribs.Icon = "FileType/picture/bmp/bmp" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".gif"
                    attribs.Icon = "FileType/picture/gif/gif" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".jpeg"
                    attribs.Icon = "FileType/picture/jpeg/jpeg" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".jpg"
                    attribs.Icon = "FileType/picture/jpg/jpg" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".png"
                    attribs.Icon = "FileType/picture/png/png" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".tif"
                    attribs.Icon = "FileType/picture/tif/tif" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".tiff"
                    attribs.Icon = "FileType/picture/tiff/tiff" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case Else
                    attribs.Icon = "FileType/other/other" & _size & ".png"
                    attribs.Type = Extension.Replace(".", "").ToUpper() & " File"
                    Exit Select
            End Select
            Try
                attribs.Icon = "FileType/" & GetImage(Extension)
            Catch ex As Exception
            End Try
            Return attribs
        End Function

        Public Class ItemAttributes
            Private _icon As String
            Public Property Icon() As String
                Get
                    Return _icon
                End Get
                Set(ByVal value As String)
                    _icon = value
                End Set
            End Property

            Private _type As String
            Public Property Type() As String
                Get
                    Return _type
                End Get
                Set(ByVal value As String)
                    _type = value
                End Set
            End Property
        End Class

        Public Shared Function GetCountPageFile(ByVal strFilePath As String, ByVal strExtentionFile As String) As Integer

            Select Case strExtentionFile
                Case ".doc"
                    Try
                        Dim word As New Document(strFilePath)
                        Return word.PageCount
                    Catch ex As Exception
                        Return 0
                    End Try
                Case ".pdf"
                    Try
                        Using sr As New StreamReader(File.OpenRead(strFilePath))
                            Dim regex As New Regex("/Type\s*/Page[^s]")
                            Dim matches As MatchCollection = regex.Matches(sr.ReadToEnd())
                            Return matches.Count
                        End Using
                    Catch ex As Exception
                        Return 0
                    End Try
                Case Else
                    Return -1
            End Select
        End Function
#Region "News"
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


        Private Shared ReadOnly VietnameseSigns As String() = New String() {"aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ",
                                                                             "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ",
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
                    lengthRatio = System.Math.Min(ThumbnailRatioWidth, ThumbnailRatioHeight)
                    ThumbnailNewWidth = ThumbnailWidth
                    Dim lengthTemp As Decimal = ImageBMP.Height * lengthRatio
                    ThumbnailNewHeight = CInt(System.Math.Truncate(lengthTemp))
                Else
                    ThumbnailRatioWidth = CDec(ThumbnailWidth) / ImageBMP.Width
                    ThumbnailRatioHeight = CDec(ThumbnailHeight) / ImageBMP.Height
                    lengthRatio = System.Math.Min(ThumbnailRatioWidth, ThumbnailRatioHeight)
                    ThumbnailNewHeight = ThumbnailHeight
                    Dim lengthTemp As Decimal = ImageBMP.Width * lengthRatio
                    ThumbnailNewWidth = CInt(System.Math.Truncate(lengthTemp))
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
#End Region
    End Class

    Public Module DataTableExtensions
        <Extension()>
        Public Sub SetColumnsOrder(ByVal table As DataTable, ParamArray columnNames As String())
            Dim columnIndex As Integer = 0

            For Each columnName In columnNames
                table.Columns(columnName).SetOrdinal(columnIndex)
                columnIndex += 1
            Next
        End Sub

        <Extension()>
        Public Sub UpgradeColumns(ByVal table As DataTable, ParamArray columnNames As String())
            For Each columnName As String In columnNames
                If Not table.Columns.Contains(columnName) Then
                    table.Columns.Add(columnName)
                End If
            Next
        End Sub
    End Module
End Namespace