Namespace eMicLibOPAC.BusinessRules.Common
    Public Class clsBCommonStringProc
        Inherits clsBBase

        Public Sub Initialize()
            ' Code here
        End Sub


        '=======================================================================
        ' Process String Here
        '=======================================================================
        '--------------------------------------------------
        ' purpose : bo dau trong cau tieng viet
        ' in : xau can bo
        ' out : xau da duoc bo
        ' creator :
        '--------------------------------------------------
        'Public Function CutVietnameseAccent(ByVal strInput As String) As String
        '    Dim strNoAccentChar As String
        '    If Trim(strInput) <> "" Then
        '        If InStr("A,À,Á,Ả,Ã,Ạ", strInput) > 0 Then
        '            strNoAccentChar = "A"
        '        ElseIf InStr("Â,Ầ,Ấ,Ẩ,Ẫ,Ậ", strInput) > 0 Then
        '            strNoAccentChar = "Â"
        '        ElseIf InStr("Ă,Ằ,Ắ,Ẳ,Ẵ,Ặ", strInput) > 0 Then
        '            strNoAccentChar = "Ă"
        '        ElseIf InStr("E,È,É,Ẻ,Ẽ,Ẹ", strInput) > 0 Then
        '            strNoAccentChar = "E"
        '        ElseIf InStr("Ê,Ề,Ế,Ể,Ễ,Ệ", strInput) > 0 Then
        '            strNoAccentChar = "Ê"
        '        ElseIf InStr("U,Ù,Ú,Ủ,Ũ,Ụ", strInput) > 0 Then
        '            strNoAccentChar = "U"
        '        ElseIf InStr("Ư,Ừ,Ứ,Ử,Ữ,Ự", strInput) > 0 Then
        '            strNoAccentChar = "Ư"
        '        ElseIf InStr("I,Ì,Í,Ỉ,Ĩ,Ị", strInput) > 0 Then
        '            strNoAccentChar = "I"
        '        ElseIf InStr("O,Ò,Ó,Ỏ,Õ,Ọ", strInput) > 0 Then
        '            strNoAccentChar = "O"
        '        ElseIf InStr("Ô,Ồ,Ố,Ổ,Ỗ,Ộ", strInput) > 0 Then
        '            strNoAccentChar = "Ô"
        '        ElseIf InStr("Ơ,Ờ,Ớ,Ở,Ỡ,Ợ", strInput) > 0 Then
        '            strNoAccentChar = Chr(198) + Chr(160)
        '        ElseIf InStr("Y,Ỳ,Ý,Ỷ,Ỹ,Ỵ", strInput) > 0 Then
        '            strNoAccentChar = "Y"
        '        Else
        '            strNoAccentChar = strInput
        '        End If
        '    Else
        '        strErrorMsg = "Empty string"
        '        strNoAccentChar = ""
        '    End If
        '    CutVietnameseAccent = strNoAccentChar
        'End Function


        ' Cut vietnamese accent method
        ' INPUT: vietnamese accent string
        ' OUTPUT: string with no accent
        Public Function CutVietnameseAccent(ByVal strInputs As String) As String
            Dim strOutput As String = ""
            Try
                Dim strNoAccentChar As String
                Dim strInput As String
                Dim inti As Integer
                If strInputs & "" <> "" Then
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
                Else
                    strErrorMsg = "Empty string"
                End If
            Catch ex As Exception
                strErrorMsg = "Error string"
            End Try
            Return strOutput
        End Function

        ' Method: CJKSplitter
        ' Purpose: support Chinese, Japanese, Korea language
        ' PhuongTT - 2014.09.01
        Private Function CJKSplitter(ByVal strInput As String) As String
            Dim strOut As String = ""
            Dim strcurChar As String
            Dim lngUChrPos As Integer
            Dim intIndex As Integer
            If Not Trim(strInput) = "" Then
                strInput = Trim(strInput)

                ' u3300-u33FF   CJK Compatibility
                ' u4E00-u9FFF   CJK Unified Ideographs
                ' uF900-uFAFF   CJK Compatibility Ideographs

                For intIndex = 0 To strInput.Length - 1
                    strcurChar = strInput.Substring(intIndex, 1)
                    lngUChrPos = Math.Abs(AscW(strcurChar))
                    If (lngUChrPos >= 13056 And lngUChrPos <= 13311) Or (lngUChrPos >= 19968 And lngUChrPos <= 40956) Or (lngUChrPos >= 63744 And lngUChrPos <= 64255) Then
                        If Not strOut = "" Then
                            If Not strOut.Substring(Len(strOut) - 1) = " " Then
                                strOut = strOut & " "
                            End If
                        End If
                        strOut = strOut & strcurChar & " "
                    Else
                        strOut = strOut & strcurChar
                    End If
                Next
            End If
            Return strOut
        End Function

        '--------------------------------------------------
        ' purpose : 
        ' in : 
        ' out : 
        ' creator:
        '--------------------------------------------------
        Public Function TheDisplayOne(ByVal StrTitle As String) As String
            Dim blnOutOfBracket As Boolean
            Dim strDispTitle As String
            Dim strinBracketPart As String
            Dim inti As Integer
            StrTitle = Trim(StrTitle)
            blnOutOfBracket = True
            strDispTitle = ""
            strinBracketPart = ""
            For inti = 1 To Len(StrTitle)
                If Mid(StrTitle, inti, 1) = "<" Then
                    blnOutOfBracket = False
                End If
                If Mid(StrTitle, inti, 1) = ">" Then
                    blnOutOfBracket = True
                    If Not strinBracketPart = "" Then
                        If InStr(strinBracketPart, "=") > 0 Then
                            strDispTitle = strDispTitle & Left(strinBracketPart, InStr(strinBracketPart, "=") - 1)
                        Else
                            strDispTitle = strDispTitle & strinBracketPart
                        End If
                        strinBracketPart = ""
                    End If
                End If
                If blnOutOfBracket Then
                    If Mid(StrTitle, inti, 1) <> ">" Then
                        strDispTitle = strDispTitle & Mid(StrTitle, inti, 1)
                    End If
                Else
                    If Mid(StrTitle, inti, 1) <> "<" Then
                        strinBracketPart = strinBracketPart & Mid(StrTitle, inti, 1)
                    End If
                End If
            Next
            If Not strinBracketPart = "" Then
                If InStr(strinBracketPart, "|") > 0 Then
                    strDispTitle = strDispTitle & Left(strinBracketPart, InStr(strinBracketPart, "=") - 1)
                Else
                    strDispTitle = strDispTitle & strinBracketPart
                End If
                strinBracketPart = ""
            End If
            TheDisplayOne = strDispTitle
        End Function

        '--------------------------------------------------
        ' purpose : bo cac ky $? trong xau 
        ' in : 
        ' out : xau da loai bo 
        ' creator:
        '--------------------------------------------------
        Public Function TrimSubFieldCodes(ByVal StrInVal As String) As String
            Dim intj As Integer
            Dim strOutVal As String
            If Trim(StrInVal) <> "" Then
                If Right(StrInVal, 1) = "." Then
                    StrInVal = Left(StrInVal, Len(StrInVal) - 1)
                End If
                strOutVal = ""
                If InStr(StrInVal, "$") = Len(StrInVal) Then
                    strOutVal = strOutVal & Left(StrInVal, Len(StrInVal) - 1) & " "
                Else
                    Do While Len(StrInVal) > 0
                        intj = InStr(StrInVal, "$")
                        If intj > 0 Then
                            strOutVal = strOutVal & Left(StrInVal, intj - 1) & " "
                            StrInVal = Right(StrInVal, Len(StrInVal) - intj - 1)
                        Else
                            strOutVal = strOutVal & StrInVal
                            StrInVal = ""
                        End If
                    Loop
                End If
            Else
                strErrorMsg = "Empty string"
            End If
            TrimSubFieldCodes = strOutVal
        End Function
        '--------------------------------------------------
        ' purpose : 
        ' in : 
        ' out : 
        '--------------------------------------------------
        Public Function TheSortOne(ByVal strTitle As String) As String
            Dim blnOutOfBracket As Boolean
            Dim strDispTitle As String
            Dim strInBracketPart As String
            Dim inti
            strTitle = Trim(strTitle)
            blnOutOfBracket = True
            strDispTitle = ""
            strInBracketPart = ""
            For inti = 1 To Len(strTitle)
                If Mid(strTitle, inti, 1) = "<" Then
                    blnOutOfBracket = False
                End If
                If Mid(strTitle, inti, 1) = ">" Then
                    blnOutOfBracket = True
                    If Not strInBracketPart = "" Then
                        If InStr(strInBracketPart, "=") > 0 Then
                            strDispTitle = strDispTitle & Right(strInBracketPart, Len(strInBracketPart) - InStr(strInBracketPart, "="))
                        End If
                        strInBracketPart = ""
                    End If
                End If
                If blnOutOfBracket Then
                    If Not Mid(strTitle, inti, 1) = ">" Then
                        strDispTitle = strDispTitle & Mid(strTitle, inti, 1)
                    End If
                Else
                    If Not Mid(strTitle, inti, 1) = "<" Then
                        strInBracketPart = strInBracketPart & Mid(strTitle, inti, 1)
                    End If
                End If
            Next
            If Not strInBracketPart = "" Then
                If InStr(strInBracketPart, "|") > 0 Then
                    strDispTitle = strDispTitle & Right(strInBracketPart, Len(strInBracketPart) - InStr(strInBracketPart, "|"))
                End If
                strInBracketPart = ""
            End If
            TheSortOne = strDispTitle
        End Function
        ' This procedure parses value of a repeatable tag into an array
        Public Sub ParseFieldValue(ByVal strInput As String, ByVal strDeliminator As String, ByRef arrRecs() As Object)
            ' Declare variables
            Dim intIndex As Integer
            Dim intOffset As Integer
            Dim intNc As Integer

            intIndex = 0
            intNc = 0
            strInput = Trim(strInput)
            ReDim arrRecs(intIndex)
            If Left(strDeliminator, 2) = "nc" Then
                strDeliminator = Right(strDeliminator, Len(strDeliminator) - 2)
                intNc = 1
            End If
            Do While Len(strInput) > 0
                intOffset = InStr(strInput, strDeliminator)
                If intOffset > 0 Then
                    arrRecs(intIndex) = Left(strInput, intOffset - 1)
                    strInput = Right(strInput, Len(strInput) - intOffset - Len(strDeliminator) + 1)
                Else
                    arrRecs(intIndex) = strInput
                    strInput = ""
                End If
                If InStr(arrRecs(intIndex), "::") > 0 Then
                    If intNc = 1 Then
                        arrRecs(intIndex) = Left(arrRecs(intIndex), InStr(arrRecs(intIndex), "::") + 1) & Right(arrRecs(intIndex), Len(arrRecs(intIndex)) - InStr(arrRecs(intIndex), "::") - 1)
                    Else
                        arrRecs(intIndex) = Left(arrRecs(intIndex), InStr(arrRecs(intIndex), "::") + 1) & Me.ConvertItBack(Right(arrRecs(intIndex), Len(arrRecs(intIndex)) - InStr(arrRecs(intIndex), "::") - 1))
                    End If
                Else
                    If intNc = 1 Then
                        arrRecs(intIndex) = arrRecs(intIndex)
                    Else
                        arrRecs(intIndex) = Me.ConvertItBack(arrRecs(intIndex))
                    End If
                End If
                intIndex = intIndex + 1
                ReDim Preserve arrRecs(intIndex)
            Loop
        End Sub

        ' ParseField method
        ' SubFieldList "$a,$b,$c"
        ' strValue : $akinh te vi mo,$bNTV/$cfkdjashk
        ' REC(0)=kinh te vi mo

        Public Sub ParseField(ByVal SubFieldList As String, ByVal strValue As String, ByVal deliminator As String, ByRef recs() As Object)
            Dim Nc, Tr As Integer
            Dim p, q, k As Integer
            Dim SubField, SubPart, TheRest As String
            Nc = 0
            Tr = 0
            If Left(deliminator, 2) = "tr" Then
                deliminator = Right(deliminator, Len(deliminator) - 2)
                Tr = 1
            ElseIf Left(deliminator, 2) = "nc" Then
                deliminator = Right(deliminator, Len(deliminator) - 2)
                Nc = 1
            End If
            ReDim recs(0)
            k = 0
            While Len(SubFieldList) > 0
                TheRest = ""
                ReDim Preserve recs(k)
                p = InStr(SubFieldList, ",")
                If p > 0 Then
                    SubField = Left(SubFieldList, p - 1)
                    SubFieldList = Right(SubFieldList, Len(SubFieldList) - p)
                Else
                    SubField = SubFieldList
                    SubFieldList = ""
                End If
                q = InStr(strValue, SubField)
                recs(k) = ""
                While q > 0
                    SubPart = Right(strValue, Len(strValue) - q - 1)
                    TheRest = Left(strValue, q - 1)
                    q = InStr(SubPart, "$")
                    If q > 0 Then
                        If Tr = 1 Then
                            recs(k) = recs(k) & GEntryTrim(ConvertItBack(Left(SubPart, q - 1))) & deliminator
                        Else
                            If Nc = 1 Then
                                recs(k) = recs(k) & Left(SubPart, q - 1) & deliminator
                            Else
                                recs(k) = recs(k) & ConvertItBack(Left(SubPart, q - 1)) & deliminator
                            End If
                        End If
                        TheRest = TheRest & Right(SubPart, Len(SubPart) - q + 1)
                    Else
                        If Tr = 1 Then
                            recs(k) = recs(k) & GEntryTrim(ConvertItBack(SubPart)) & deliminator
                        Else
                            If Nc = 1 Then
                                recs(k) = recs(k) & SubPart & deliminator
                            Else
                                recs(k) = recs(k) & ConvertItBack(SubPart) & deliminator
                            End If
                        End If
                    End If
                    strValue = TheRest
                    q = InStr(strValue, SubField)
                End While
                If Right(recs(k), Len(deliminator)) = deliminator And Not recs(k) = "" Then
                    recs(k) = Left(recs(k), Len(recs(k)) - Len(deliminator))
                End If
                k = k + 1
                ReDim Preserve recs(k)
            End While
            If Nc = 1 Then
                recs(k) = strValue
            Else
                recs(k) = ConvertItBack(strValue)
            End If
        End Sub

        '--------------------------------------------------
        ' purpose : loai bo cac ky tu : /:,.;=+ 
        ' in : xau can loai bo
        ' out : xau da loai bo
        ' creator:
        '--------------------------------------------------
        Public Function GEntryTrim(ByVal Str As String) As String
            Dim strLastChar As String
            Str = Trim(Str)
            If Str <> "" Then
                strLastChar = Right(Str, 1)
                If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = "." Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                    Str = Left(Str, Len(Str) - 1)
                End If
            Else
                strErrorMsg = "Empty String"
            End If
            GEntryTrim = Str
        End Function

        '--------------------------------------------------
        ' purpose : do^`ng bo^. da^'u ddoi vo+'i xa^u tie^'ng vie^.t
        ' in : xa^u ca^`n ddo^`ng bo^.
        ' out : xa^u dda~ ddo^`ng bo^.
        ' creator:
        '--------------------------------------------------
        Public Function SyncAccent(ByVal StrSA As String) As String
            Dim saArr1() As String = {"OÀ", "OÁ", "OẠ", "OẢ", "OÃ", "UỶ", "UÝ", "UỴ", "UỸ", "UỲ", "OÈ", "OÉ", "OẸ", "OẺ", "OẼ"}
            Dim saArr2() As String = {"ÒA", "ÓA", "ỌA", "ỎA", "ÕA", "ỦY", "ÚY", "ỤY", "ŨY", "ÙY", "ÒE", "ÓE", "ỌE", "ỎE", "ÕE"}
            If Trim(StrSA) <> "" Then
                Dim saIdx As Byte
                For saIdx = LBound(saArr1) To UBound(saArr1)
                    StrSA = Replace(StrSA, saArr2(saIdx), saArr1(saIdx))
                Next
            Else
                strErrorMsg = "Empty String"
            End If
            SyncAccent = StrSA
        End Function
        '--------------------------------------------------
        ' purpose : 
        ' in : 
        ' out : 
        ' creator :
        '--------------------------------------------------
        Public Function ProcessVal(ByVal strPv As String) As String
            'Dim objUtf8 As New TVCOMLib.utf8Class
            If Trim(strPv & "") <> "" Then
                Dim str As String
                str = strPv
                str = Replace(str, "/", " ")
                str = Replace(str, ".", " ")
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
                str = Replace(str, "'", "''")
                str = Replace(str, "--", " ")
                str = Replace(str, "-", " ")
                str = Replace(str, "  ", " ")
                str = Trim(UCase(str))
                'Select Case UCase(strDBServer)
                '    Case "ORACLE"
                '        str = Trim(objUtf8.Upper(str))
                '    Case "SQLSERVER"
                '        str = Trim(UCase(str))
                'End Select
                str = SyncAccent(str)
                ProcessVal = str
            Else
                ProcessVal = ""
                strErrorMsg = "Empty String"
            End If
            'objUtf8 = Nothing
        End Function

        '--------------------------------------------------
        ' purpose : 
        ' in : 
        ' out : 
        ' creator :
        '--------------------------------------------------
        Public Function killCharsProcessVal(ByVal strPv As String) As String
            Dim str As String = ""
            If Trim(strPv & "") <> "" Then
                str = strPv
                str = Replace(str, "/", " ")
                str = Replace(str, ".", " ")
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
                str = Replace(str, ">", " ")
                str = Replace(str, "<", " ")
                str = Replace(str, """", " ")
                str = Replace(str, "--", " ")
                str = Replace(str, "-", " ")
                str = Replace(str, "–", " ")
                str = Replace(str, "  ", " ")
                str = Replace(str, "©", " ")
                str = Replace(str, "'", " ")
                str = Replace(str, "+", "")
                str = Replace(str, "&", "")
                Do While InStr(str, "  ") > 0
                    str = Replace(str, "  ", " ")
                Loop
                str = killChars(str)
                str = CJKSplitter(str)
                str = Trim(str)
            End If
            Return str
        End Function

        '--------------------------------------------------
        ' purpose : 
        ' in : 
        ' out : 
        ' creator :
        '--------------------------------------------------
        Public Function ProcessVal1(ByVal strPv As String) As String
            ' Dim objUtf8 As New TVCOMLib.utf8Class
            If Trim(strPv & "") <> "" Then
                Dim str As String
                str = strPv
                str = Replace(str, "/", " ")
                str = Replace(str, ".", " ")
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
                str = Replace(str, "'", "''")

                'str = Replace(str, "/", " ")
                'str = Replace(str, ",", " ")
                'str = Replace(str, ":", " ")
                'str = Replace(str, ";", " ")
                'str = Replace(str, "?", " ")
                'str = Replace(str, "!", " ")
                'str = Replace(str, "[", " ")
                'str = Replace(str, "]", " ")
                'str = Replace(str, "=", " ")
                'str = Replace(str, "(", " ")
                'str = Replace(str, ")", " ")
                'str = Replace(str, """", " ")
                'str = Replace(str, "--", " ")
                'str = Replace(str, "-", " ")
                'str = Replace(str, "  ", " ")
                str = Trim(UCase(str))
                'Select Case UCase(strDBServer)
                '    Case "ORACLE"
                '        str = Trim(objUtf8.Upper(str))
                '    Case "SQLSERVER"
                '        str = Trim(UCase(str))
                'End Select
                str = SyncAccent(str)
                ProcessVal1 = str
            Else
                ProcessVal1 = ""
                strErrorMsg = "Empty String"
            End If
            'objUtf8 = Nothing
        End Function



        ' Cut vietnamese accent method
        ' INPUT: vietnamese accent string
        ' OUTPUT: string with no accent
        Public Function FormNoAccentString(ByVal strInput As String) As String
            Dim strNoAccentChar As String
            Dim strResult As String = ""
            Dim strCurrentchar As String
            If Not Trim(strInput) = "" Then
                Dim intPos As Integer
                For intPos = 1 To Len(strInput)
                    strCurrentchar = Mid(strInput, intPos, 1)
                    If Not Trim(strCurrentchar) = "" Then
                        If InStr("A,À,Á,Ả,Ã,Ạ,Â,Ầ,Ấ,Ẩ,Ẫ,Ậ,Ă,Ằ,Ắ,Ẳ,Ẵ,Ặ", strCurrentchar) > 0 Then
                            strNoAccentChar = "A"
                        ElseIf InStr("E,È,É,Ẻ,Ẽ,Ẹ,Ê,Ề,Ế,Ể,Ễ,Ệ", strCurrentchar) > 0 Then
                            strNoAccentChar = "E"
                        ElseIf InStr("U,Ù,Ú,Ủ,Ũ,Ụ,Ư,Ừ,Ứ,Ử,Ữ,Ự", strCurrentchar) > 0 Then
                            strNoAccentChar = "U"
                        ElseIf InStr("I,Ì,Í,Ỉ,Ĩ,Ị", strCurrentchar) > 0 Then
                            strNoAccentChar = "I"
                        ElseIf InStr("O,Ò,Ó,Ỏ,Õ,Ọ,Ô,Ồ,Ố,Ổ,Ỗ,Ộ,Ơ,Ờ,Ớ,Ở,Ỡ,Ợ", strCurrentchar) > 0 Then
                            strNoAccentChar = "O"
                        ElseIf InStr("Y,Ỳ,Ý,Ỷ,Ỹ,Ỵ", strCurrentchar) > 0 Then
                            strNoAccentChar = "Y"
                        ElseIf InStr("Đ", strCurrentchar) > 0 Then
                            strNoAccentChar = "D"
                        Else
                            strNoAccentChar = strCurrentchar
                        End If
                    End If
                    strResult = strResult & strNoAccentChar
                Next
            Else
                strResult = strInput
            End If
            FormNoAccentString = strResult
        End Function
        Public Sub GLoadArray(ByVal strInput As String, ByRef objArr As Object, ByVal strDeli As String)
            Dim intIndex1 As Integer
            Dim intIndex2 As Integer
            Dim intIndex3 As Integer
            Dim strWord As String
            strInput = Trim(strInput)
            intIndex1 = 0
            Do While Len(strInput) > 0
                ReDim Preserve objArr(intIndex1)
                intIndex2 = InStr(strInput, strDeli)
                If intIndex2 > 0 Then
                    strWord = Left(strInput, intIndex2 - 1)
                    strInput = Right(strInput, Len(strInput) - intIndex2 - Len(strDeli) + 1)
                    objArr(intIndex1) = strWord
                    intIndex1 = intIndex1 + 1
                Else
                    objArr(intIndex1) = strInput
                    strInput = ""
                End If
            Loop
        End Sub
        '=============================================================
        ' End Process String
        '=============================================================

        '=======================================================================
        ' Process Font Here
        '=======================================================================
        '---------------------------------------------
        ' purpose: Convert a string to current encode
        ' in : string to convert
        ' out : string converted
        ' creator : 
        '---------------------------------------------
        Public Function ConvertIt(ByVal strIn As String) As String
            strIn = Trim(strIn) & ""
            'Select Case Trim(strDBServer)
            '    Case "SQLSERVER"
            '        Select Case strInterfaceLanguage
            '            Case "tcvn"
            '                strIn = objTVCom.Convert("ucs2", "tcvn", strIn)
            '            Case "vni"
            '                strIn = objTVCom.Convert("ucs2", "vni", strIn)
            '            Case "viqr"
            '                strIn = objTVCom.Convert("ucs2", "viqr", strIn)
            '        End Select
            '    Case "ORACLE"
            '        Select Case strInterfaceLanguage
            '            Case "tcvn"
            '                strIn = objTVCom.Convert("unicode1", "tcvn", strIn)
            '            Case "vni"
            '                strIn = objTVCom.Convert("unicode1", "vni", strIn)
            '                'Case "unicode"
            '                'strIn = objTVCom.Convert("unicode1", "ucs2", strIn)
            '            Case "viqr"
            '                strIn = objTVCom.Convert("unicode1", "viqr", strIn)
            '        End Select
            'End Select
            ConvertIt = strIn
        End Function

        '---------------------------------------------
        ' purpose: Convert a string to current encode
        ' in : string to convert
        ' out : string converted
        ' creator :
        '---------------------------------------------
        Public Function ConvertItBack(ByVal strIn As String) As String
            strIn = Trim(strIn & "")
            If Trim(strIn) <> "" Then
                'Select Case Trim(strDBServer)
                '    Case "SQLSERVER"
                '        Select Case strInterfaceLanguage
                '            Case "tcvn"
                '                strIn = objTVCom.Convert("tcvn", "ucs2", strIn)
                '            Case "vni"
                '                strIn = objTVCom.Convert("vni", "ucs2", strIn)
                '            Case "viqr"
                '                strIn = objTVCom.Convert("viqr", "ucs2", strIn)
                '        End Select
                '    Case "ORACLE"
                '        Select Case strInterfaceLanguage
                '            Case "tcvn"
                '                strIn = objTVCom.Convert("tcvn", "unicode1", strIn)
                '            Case "vni"
                '                strIn = objTVCom.Convert("vni", "unicode1", strIn)
                '            Case "viqr"
                '                strIn = objTVCom.Convert("viqr", "unicode1", strIn)
                '                'Case "unicode"
                '                'strIn = objTVCom.Convert("ucs2", "unicode1", strIn)
                '        End Select
                'End Select
                ConvertItBack = Replace(strIn, "'", "''")
            Else
                ConvertItBack = ""
            End If
        End Function

        '---------------------------------------------
        ' purpose: Convert a string to current encode
        ' in : string to convert
        ' out : string converted
        ' creator :
        '---------------------------------------------
        Public Function ConvertItBack(ByVal strIn As String, ByVal blnReplace As Boolean) As String
            strIn = Trim(strIn & "")
            If Trim(strIn) <> "" Then
                'Select Case Trim(strDBServer)
                '    Case "SQLSERVER"
                '        Select Case strInterfaceLanguage
                '            Case "tcvn"
                '                strIn = objTVCom.Convert("tcvn", "ucs2", strIn)
                '            Case "vni"
                '                strIn = objTVCom.Convert("vni", "ucs2", strIn)
                '            Case "viqr"
                '                strIn = objTVCom.Convert("viqr", "ucs2", strIn)
                '        End Select
                '    Case "ORACLE"
                '        Select Case strInterfaceLanguage
                '            Case "tcvn"
                '                strIn = objTVCom.Convert("tcvn", "unicode1", strIn)
                '            Case "vni"
                '                strIn = objTVCom.Convert("vni", "unicode1", strIn)
                '            Case "viqr"
                '                strIn = objTVCom.Convert("viqr", "unicode1", strIn)
                '                'Case "unicode"
                '                'strIn = objTVCom.Convert("ucs2", "unicode1", strIn)
                '        End Select
                'End Select
                ConvertItBack = Replace(strIn, "'", "''")
            Else
                ConvertItBack = ""
            End If
        End Function

        ' Z3950 supports only 2 format: utf8 & marc8
        ' ZConvertIt method for Z3950 search
        ' Purpose: convert string in to Marc8 (utf-8)
        ' Input: strIn, blnIsMarc8
        ' Output: string converted
        ' Created on 25/11/2003 by oanhtn
        Public Function ZConvertIt(ByVal strIn As String, ByVal blnIsMarc8 As Boolean) As String
            strIn = Trim(strIn) & ""
            'If blnIsMarc8 Then
            '    Select Case strInterfaceLanguage
            '        Case "tcvn"
            '            strIn = objTVCom.Convert("usmarc", "tcvn", strIn)
            '        Case "vni"
            '            strIn = objTVCom.Convert("usmarc", "vni", strIn)
            '        Case "unicode"
            '            strIn = objTVCom.Convert("usmarc", "ucs2", strIn)
            '    End Select
            'Else
            '    Select Case strInterfaceLanguage
            '        Case "tcvn"
            '            strIn = objTVCom.Convert("unicode1", "tcvn", strIn)
            '        Case "vni"
            '            strIn = objTVCom.Convert("unicode1", "vni", strIn)
            '        Case "unicode"
            '            strIn = objTVCom.Convert("unicode1", "ucs2", strIn)
            '    End Select
            'End If
            ZConvertIt = strIn
        End Function

        ' ZConvertItBack method for Z3950 search
        ' Purpose: convert string from Marc8 (utf-8)
        ' Input: strIn, blnIsMarc8
        ' Output: string converted
        ' Created on 25/11/2003 by oanhtn
        Public Function ZConvertItBack(ByVal strIn As String, ByVal blnIsMarc8 As Boolean) As String
            strIn = Trim(strIn) & ""
            'If blnIsMarc8 Then
            '    Select Case strInterfaceLanguage
            '        Case "tcvn"
            '            strIn = objTVCom.Convert("tcvn", "usmarc", strIn)
            '        Case "vni"
            '            strIn = objTVCom.Convert("vni", "usmarc", strIn)
            '        Case "unicode"
            '            strIn = objTVCom.Convert("ucs2", "usmarc", strIn)
            '    End Select
            'Else
            '    Select Case strInterfaceLanguage
            '        Case "tcvn"
            '            strIn = objTVCom.Convert("tcvn", "unicode1", strIn)
            '        Case "vni"
            '            strIn = objTVCom.Convert("vni", "unicode1", strIn)
            '        Case "unicode"
            '            strIn = objTVCom.Convert("ucs2", "unicode1", strIn)
            '    End Select
            'End If
            'ZConvertItBack = Replace(strIn, "'", "''")
            ZConvertItBack = strIn
        End Function

        '---------------------------------------------
        ' Purpose: Convert a string from marc8 format
        ' In : string to convert
        ' Out : string converted
        ' Creator : oanhtn
        ' CreatedDate: 24/11/2003
        '---------------------------------------------
        Public Function ConvertItUSMARC(ByVal strIn As String) As String
            strIn = Trim(strIn) & ""
            'Select Case strInterfaceLanguage
            '    Case "tcvn"
            '        strIn = objTVCom.Convert("usmarc", "tcvn", strIn)
            '    Case "vni"
            '        strIn = objTVCom.Convert("usmarc", "vni", strIn)
            '    Case Else
            '        strIn = objTVCom.Convert("usmarc", "unicode1", strIn)
            'End Select
            ConvertItUSMARC = Replace(strIn, "'", "''")
        End Function
        ' UTF8ToUCS2
        ' Purpose: Convert from UTF8 to UCS2
        ' Input: UTF8 string
        ' Return UCS2 string
        Public Function UTF8ToUCS2(ByVal strIn As String) As String
            'If Trim(strIn) <> "" Then
            '    UTF8ToUCS2 = objTVCom.Convert("unicode1", "ucs2", strIn)
            'Else
            '    UTF8ToUCS2 = ""
            'End If
            UTF8ToUCS2 = ""
        End Function

        ' purpose: Convert tu UTf8 sang ma hien thoi
        '           dung trong truong hop hien thi gia tri sau khi su dung Template
        ' in: strIn -> chuoi can convert
        ' out: String -> chuoi da convert
        Public Function ToUTF8Back(ByVal strIn As String) As String
            'If Trim(strIn) <> "" Then
            '    Select Case LCase(strInterfaceLanguage)
            '        Case "unicode"
            '            ToUTF8Back = objTVCom.Convert("unicode1", "ucs2", strIn)
            '        Case "tcvn"
            '            ToUTF8Back = objTVCom.Convert("unicode1", "tcvn", strIn)
            '        Case "vni"
            '            ToUTF8Back = objTVCom.Convert("unicode1", "vni", strIn)
            '    End Select
            'Else
            '    ToUTF8Back = ""
            'End If
            ToUTF8Back = strIn
        End Function

        ' purpose: Convert UCS2-> UTF8 doi voi SQL Server
        '          Convert UTF8-> UTF8 doi voi ORACLE
        '       dung cho su dung Template
        ' in: strIn -> chuoi can convert
        ' out: String -> chuoi da convert
        Public Function DBtoUTF8(ByVal strIn As String) As String
            'If Trim(strIn) <> "" Then
            '    Select Case UCase(strDBServer)
            '        Case "ORACLE"
            '            DBtoUTF8 = strIn
            '        Case "SQLSERVER"
            '            DBtoUTF8 = objTVCom.Convert("ucs2", "unicode1", strIn)
            '        Case Else
            '            DBtoUTF8 = objTVCom.Convert("ucs2", "unicode1", strIn)
            '    End Select
            'Else
            '    DBtoUTF8 = ""
            'End If
            DBtoUTF8 = strIn
        End Function

        ' purpose : convert  tu ma hien thoi sang UTF8
        '           dung cho truong hop su dung COM template
        ' in: strIN -> chuoi can convert
        ' out: String -> chuoi duoc convert
        ' creator : dgsoft2016 
        Public Function ToUTF8(ByVal strIn As String) As String
            'If Trim(strIn) <> "" Then
            '    Select Case LCase(strInterfaceLanguage)
            '        Case "unicode"
            '            ToUTF8 = objTVCom.Convert("ucs2", "unicode1", strIn)
            '        Case "tcvn"
            '            ToUTF8 = objTVCom.Convert("tcvn", "unicode1", strIn)
            '        Case "vni"
            '            ToUTF8 = objTVCom.Convert("vni", "unicode1", strIn)
            '    End Select
            'Else
            '    ToUTF8 = ""
            'End If
            ToUTF8 = strIn
        End Function

        ' purpose : convert  tu UCS2 sang ma hien thoi
        '           dung cho truong hop su dung COM template
        ' in: strIN -> chuoi can convert
        ' out: String -> chuoi duoc convert
        ' creator : dgsoft2016 
        Public Function UCS2ToCurrent(ByVal strIn As String) As String
            'If Trim(strIn) <> "" Then
            '    Select Case LCase(strInterfaceLanguage)
            '        Case "unicode"
            '        Case "tcvn"
            '            UCS2ToCurrent = objTVCom.Convert("ucs2", "tcvn", strIn)
            '        Case "vni"
            '            UCS2ToCurrent = objTVCom.Convert("ucs2", "vni", strIn)
            '    End Select
            'Else
            '    UCS2ToCurrent = ""
            'End If
            UCS2ToCurrent = strIn
        End Function

        Public Function UCS2Title(ByVal strconvert As String) As String
            'If Trim(strconvert) <> "" Then
            '    Select Case strInterfaceLanguage
            '        Case "tcvn"
            '            strconvert = objTVCom.Convert("tcvn", "ucs2", strconvert)
            '        Case "vni"
            '            strconvert = objTVCom.Convert("vni", "ucs2", strconvert)
            '        Case "unicode"
            '            strconvert = strconvert
            '    End Select
            'End If
            UCS2Title = strconvert
        End Function

        Public Function UCS2DataLabel(ByVal strconvert As String) As String
            'If Trim(strconvert) <> "" Then
            '    Select Case UCase(strDBServer)
            '        Case "ORACLE"
            '            UCS2DataLabel = objTVCom.Convert("unicode1", "ucs2", strconvert)
            '        Case "SQLSERVER"
            '            UCS2DataLabel = strconvert
            '    End Select
            'End If
            UCS2DataLabel = strconvert
        End Function

        Public Function UCS2Back(ByVal strIn As String) As String
            'Return objTVCom.Convert("ucs2", LCase(strInterfaceLanguage), strIn)
            UCS2Back = strIn
        End Function

        ' Merge two string (include char ",") on a string and cancel the duplicate value  
        Public Function MergeStrings(ByVal strID1 As String, ByVal strID2 As String) As String
            Dim inti As Integer
            Dim strResult As String
            Dim x() As String

            If strID1 <> "" Then
                strResult = "," & strID1 & ","
            Else
                strResult = "," & strID1
            End If
            x = Split(strID2, ",")
            For inti = 0 To UBound(x)
                If InStr(strResult, "," & x(inti) & ",") <= 0 Then
                    strResult = strResult & x(inti) & ","
                End If
            Next
            MergeStrings = Mid(strResult, 2, Len(strResult) - 2)
        End Function

        '=============================================================
        ' End Process Font
        '=============================================================
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                'If isDisposing Then
                '    ' Dispose manage resource
                '    objTVCom = Nothing
                'End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Input :Two String
        'OutPut:A String couple with $
        Function Symbolize(ByVal parentField As String, ByVal Field As String) As String
            Dim SubFieldCode As String  ' ByVal si As Char
            If Not Right(Field, 2) = "$" Then
                SubFieldCode = Right(Field, 2)
                parentField = Replace(parentField, SubFieldCode, "$" & Right(SubFieldCode, 1))
            End If
            Symbolize = parentField
        End Function

        Public Function ReplaceBracket(ByVal strInput As String) As String
            Dim start, startend As Integer
            Dim at, et As Integer
            Dim [end] As Integer
            Dim count As Integer
            [end] = strInput.Length
            start = 0
            count = 0
            at = 0
            et = 0
            While start <= [end] AndAlso at > -1
                count = [end] - start
                at = strInput.IndexOf("<", start, count)
                If at = -1 Then
                    Exit While
                ElseIf at = 0 Then
                    et = strInput.IndexOf(">", 1, count - 1)
                Else
                    et = strInput.IndexOf(">", start + 1, count - 1)
                End If

                If et > 0 Then
                    start = et
                Else
                    start = at + 1
                End If

                If et > 0 Then
                    If strInput.Substring(at, et - at + 1).ToUpper <> "<BR>" Then
                        Dim tem As String
                        tem = strInput.Substring(at, et - at + 1)
                        tem = tem.Replace("<", "&")
                        tem = tem.Replace(">", "@")
                        strInput = strInput.Replace(strInput.Substring(at, et - at + 1), tem)
                    End If
                End If
            End While
        End Function

        ' Purpose: remove all character to get number(s) from string
        ' Input: strIn
        ' Output: number(s)
        Public Function RemoveCharacter(ByVal strInput As String) As String
            Dim strNumber As String
            Dim inti As Integer
            strNumber = ""
            For inti = 0 To strInput.Length - 1
                If Asc(strInput.Substring(inti, 1)) >= 48 And Asc(strInput.Substring(inti, 1)) <= 57 Then
                    strNumber = strNumber & strInput.Substring(inti, 1)
                End If
            Next
            RemoveCharacter = strNumber
        End Function

        ' Purpose: fill iTems from datatable to item string
        ' Input: datatable
        ' Output: string
        Public Function getiTemString(ByVal dt As DataTable) As String
            Dim strIds As String = ""
            Try
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    Dim iCount As Integer = dt.Rows.Count - 1
                    For i As Integer = 0 To iCount
                        strIds &= dt.Rows(i).Item("ID") & ","
                    Next
                    If strIds <> "" Then
                        strIds = strIds.Substring(0, strIds.Length - 1)
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strIds
        End Function

        ' Purpose: fill iTems from datatable to item string
        ' Input: datatable
        ' Output: string
        Public Function getIdsSring(ByVal Ids As String) As String
            Dim strIds As String = ""
            Try
                If Ids <> "" Then
                    strIds = Ids
                    If Ids.EndsWith(",") Then
                        strIds = strIds.Substring(0, strIds.Length - 1)
                    End If
                    If Ids.StartsWith(",") Then
                        strIds = strIds.Substring(1, strIds.Length)
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strIds
        End Function

        ' Purpose: prevent SQL Injection
        ' Input: string
        ' Output: string
        Public Function killChars(ByVal strWords As String) As String
            'Dim badChars As String() = {"select ", "drop ", ";", "--", "insert ", "delete ", "xp_", " or ", " and "}
            Dim badChars As String() = {"select ", "drop ", ";", "--", "insert ", "delete ", "xp_", " or "} '-- Not select data with keywork = 'Roads and Highways' because was remove ' and '.
            Dim newChars As String = ""
            newChars = strWords
            For i As Integer = 0 To UBound(badChars)
                newChars = Replace(newChars, badChars(i), " ")
            Next
            killChars = newChars
        End Function


    End Class
End Namespace