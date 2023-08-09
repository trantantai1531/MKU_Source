Imports System.Text.RegularExpressions

Namespace eMicLibOPAC.WebUI
    Public Class clsUICommon
#Region "Common"
        Public Enum gFileType
            eAll = 0
            ePicture = 1
            eMedia = 2
            eSound = 3
            eDocument = 4
            eExe = 5
            eOther = 6
            eMagazine = 7
        End Enum

        Public Shared Function checkSecurityLevel(ByVal bookSercretLevel As Integer) As Boolean
            Dim bolResult As Boolean = False
            Try
                If CInt(clsSession.GlbUserLevel) >= bookSercretLevel Then
                    bolResult = True
                End If
            Catch ex As Exception
            End Try
            Return bolResult
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

        Public Shared Function HomeCutWords(ByVal _words As String, Optional ByVal _CountCutWords As Integer = 10, Optional ByVal _FillMax As Integer = 35) As String
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
                'Do While _str.Length < _FillMax
                '    _str &= "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                'Loop
            Catch ex As Exception
            End Try
            Return _str
        End Function

        Public Shared Sub MyMsgBoxInfor(ByVal strMsg As String, ByVal cls As Object)
            ScriptManager.RegisterStartupScript(cls, cls.GetType(), "javascriptfunction", strMsg, True)
        End Sub

        Public Shared Function sumaryContents(ByVal _Contents As String, ByVal _SearchText As String, Optional ByVal _MinPrefixLength As Integer = 20, Optional ByVal _MaxPrefixLength As Integer = 100, Optional ByVal _MinAfterLength As Integer = 20, Optional ByVal _MaxAfterLength As Integer = 80, Optional ByVal _bolBold As Boolean = False, Optional ByVal intHTMLContentLength As Integer = 0) As String
            Dim _str As String = "..."
            Dim _strPrefix As String = ""
            Dim _strAfterfix As String = ""
            Try
                Dim _WordPrefix As String = ""
                Dim _WordAfterfix As String = ""
                Dim _posWord As Integer = 0
                _posWord = InStr(_Contents.ToLower, _SearchText.ToLower)
                If _posWord > 0 Then
                    _WordPrefix = _Contents.Substring(0, _posWord - 1)
                    _strPrefix = CutPrefixContents(_WordPrefix, _MinPrefixLength, _MaxPrefixLength)
                    '_WordAfterfix = _Contents.Substring(_posWord - 1, _Contents.Length - (_posWord + 1))
                    _WordAfterfix = _Contents.Substring(_posWord - 1, _Contents.Length - (_posWord))
                    _strAfterfix = CutAfterWords(_WordAfterfix, _MinAfterLength, _MaxAfterLength, intHTMLContentLength)
                Else
                    _str = CutPrefixContents(_Contents, _MinPrefixLength * 2, _MaxPrefixLength * 2)
                End If
                _str &= _strPrefix & _strAfterfix
                _str = Trim(_str)
            Catch ex As Exception

            End Try
            Return _str
        End Function

        Public Shared Function getWordHightLight(ByVal _Contents As String, ByVal _SearchText As String, ByVal _wordLen As Integer) As String
            Dim _str As String = "..."
            Try
                Dim _posWord As Integer = 0
                _posWord = InStr(_Contents.ToLower, _SearchText.ToLower)
                If _posWord > 0 Then
                    _str = _Contents.Substring(_posWord + Len(_SearchText) - 1, _wordLen)
                Else
                    _str = ""
                End If
                _str = Trim(_str)
            Catch ex As Exception
            End Try
            Return _str
        End Function

        Public Shared Function HighlightContents(ByVal _Contents As String, ByVal _SearchText As String, Optional ByVal _MinPrefixLength As Integer = 20, Optional ByVal _MaxPrefixLength As Integer = 100, Optional ByVal _MinAfterLength As Integer = 20, Optional ByVal _MaxAfterLength As Integer = 80, Optional ByVal _bolBold As Boolean = False) As String
            Dim _str As String = "..."
            Dim _strPrefix As String = ""
            Dim _strAfterfix As String = ""
            Try
                Dim _WordPrefix As String = ""
                Dim _WordAfterfix As String = ""
                Dim _posWord As Integer = 0
                _posWord = InStr(_Contents.ToLower, _SearchText.ToLower)
                If _posWord > 0 Then
                    _WordPrefix = _Contents.Substring(0, _posWord - 1)
                    _strPrefix = CutPrefixContents(_WordPrefix, _MinPrefixLength, _MaxPrefixLength)
                    _WordAfterfix = _Contents.Substring(_posWord - 1, _Contents.Length - (_posWord + 1))
                    _strAfterfix = CutAfterWords(_WordAfterfix, _MinAfterLength, _MaxAfterLength)
                Else
                    _str = CutPrefixContents(_Contents, _MinPrefixLength * 2, _MaxPrefixLength * 2)
                End If
                _str &= _strPrefix & _strAfterfix
                If _bolBold Then
                    _str = Regex.Replace(_str, "(" & _SearchText & ")", "<B>$1</B>", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                Else
                    _str = Regex.Replace(_str, "(" & _SearchText & ")", "<span style=""background:silver;"">$1</span>", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
                End If
                _str = Trim(_str)
            Catch ex As Exception

            End Try
            Return _str
        End Function

        Public Shared Function CutPrefixContents(ByVal _words As String, ByVal _MinCutWords As Integer, ByVal _MaxCutWords As Integer) As String
            Dim _str As String = ""
            Try

                Dim _cutWord As String = ""
                Dim _arrWord() As String = Nothing
                Dim _bol As Boolean = False
                _cutWord = _words
                '( )|( ) la 2 ky tu khoang trang khac nhau
                Dim pattern As String = "( )|( )"
                _arrWord = Regex.Split(_cutWord, pattern)
                _bol = False
                _str = ""
                Randomize()
                Dim _CountCutWordsRnd As Integer = Int(_MaxCutWords * Rnd(1) + 1) + _MinCutWords
                Dim _posEnd As Integer = UBound(_arrWord)
                If _CountCutWordsRnd >= _posEnd Then
                    _CountCutWordsRnd = 0
                    _bol = True
                Else
                    _CountCutWordsRnd = _posEnd - _CountCutWordsRnd
                End If
                For i As Integer = _posEnd To _CountCutWordsRnd Step -1
                    If _arrWord(i).Trim <> "" Then
                        _str = _arrWord(i).Trim & " " & _str
                    End If
                Next
                If Not _bol Then
                    _str = "..." & _str
                End If
            Catch ex As Exception

            End Try
            Return _str
        End Function

        Public Shared Function CutAfterWords(ByVal _words As String, ByVal _MinCutWords As Integer, ByVal _MaxCutWords As Integer, Optional ByVal intHTMLContentLength As Integer = 0) As String
            Dim _str As String = ""
            Try
                Dim _cutWord As String = ""
                Dim _arrWord() As String = Nothing
                Dim _bol As Boolean = False
                _cutWord = _words
                Dim pattern As String = "( )|( )"
                _arrWord = Regex.Split(_cutWord, pattern)
                _bol = False
                _str = ""
                Randomize()
                Dim _CountCutWordsRnd As Integer = Int(_MaxCutWords * Rnd(1) + 1) + _MinCutWords + intHTMLContentLength
                Dim _posEnd As Integer = UBound(_arrWord)
                If _CountCutWordsRnd >= _posEnd Then
                    _CountCutWordsRnd = _posEnd
                    _bol = True
                End If
                For i As Integer = 0 To _CountCutWordsRnd
                    If _arrWord(i).Trim <> "" Then
                        _str &= _arrWord(i).Trim & " "
                    End If
                Next
                If Not _bol Then
                    _str &= "..."
                End If
            Catch ex As Exception

            End Try
            Return _str
        End Function

        Public Shared Function checkPermission() As Boolean
            Dim bolResult As Boolean = False
            Try
                If Not IsNothing(clsSession.GlbUser) AndAlso clsSession.GlbUser <> "" Then
                    bolResult = True
                End If
            Catch ex As Exception
            End Try
            Return bolResult
        End Function

        Public Shared Function HightLightText(ByVal str As String, ByVal strSearch As String) As String
            Dim strResult As String = str
            Try
                If strSearch.Length >= 3 Then
                    Dim strTemp As String = convertToUnSign(str.Trim)
                    Dim strSearchTemp As String = convertToUnSign(strSearch.Trim)

                    Dim RegexStr As New Regex(strSearchTemp, RegexOptions.IgnoreCase)
                    Dim matchesStr As MatchCollection = RegexStr.Matches(strTemp)
                    For Each match As Match In matchesStr
                        str = Replace(str, str.Substring(match.Index, match.Length), "<B>" & str.Substring(match.Index, match.Length) & "</B>")
                    Next
                    strResult = str
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Public Shared Function convertToUnSign(ByVal s As String) As String
            Dim regex As New Regex("\p{IsCombiningDiacriticalMarks}+")
            Dim temp As String = s.Normalize(System.Text.NormalizationForm.FormD)
            Return regex.Replace(temp, [String].Empty).Replace("đ"c, "d"c).Replace("Đ"c, "D"c).Trim
        End Function

        Public Shared Function UTF82UNICODE(ByVal strconvert As String) As String
            Dim RecvMessage As String = ""
            Try
                Dim Buffer() As Byte
                Buffer = System.Text.Encoding.Default.GetBytes(strconvert.ToCharArray)
                Dim clsFont As New MLFonts.UnicodeText
                RecvMessage = clsFont.Utf8ToUnicode(Buffer)
                clsFont = Nothing
            Catch ex As Exception : End Try
            Return RecvMessage
        End Function

        Public Function UNICODE2UTF8(ByVal strIn As String) As String
            Dim RecvMessage As String = ""
            Try
                Dim Buffer() As Byte
                Dim clsFont As New MLFonts.UnicodeText
                Buffer = clsFont.UnicodeToUtf8(strIn)
                RecvMessage = System.Text.Encoding.Default.GetString(Buffer)
                clsFont = Nothing
            Catch ex As Exception : End Try
            Return RecvMessage
        End Function

#End Region
    End Class

End Namespace
