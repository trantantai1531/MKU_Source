'Imports NUnit.Framework
Imports System.Collections.Generic
Imports System.Text
Imports System.Linq

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBCommonStringProc
        Inherits clsBBase

        'Private objTVCom As New TVCOMLib.fonts

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
        Public Function CutVietnameseAccent(ByVal strInputs As String) As String
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
            CutVietnameseAccent = strOutput
        End Function
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

        Public Function killChars(ByVal strWords As String) As String
            Dim badChars As String() = {"select ", "drop ", ";", "--", "insert ", "delete ", "xp_", " or ", " and "}
            Dim newChars As String = ""
            newChars = strWords
            For i As Integer = 0 To UBound(badChars)
                newChars = Replace(newChars, badChars(i), " ")
            Next
            killChars = newChars
        End Function
        Public Function CutWords(ByVal _words As String, Optional ByVal _CountCutWords As Integer = 50) As String
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
        ' modify by lenta 21/11/2005
        '--------------------------------------------------
        Public Function TrimSubFieldCodes(ByVal StrInVal As String, Optional ByVal blnConvertFont As Boolean = True) As String
            Dim intj As Integer
            Dim strOutVal As String
            If Trim(StrInVal) <> "" Then
                If blnConvertFont Then
                    StrInVal = ConvertIt(StrInVal) 'KernelOBj.
                End If
                If Right(StrInVal, 1) = "." Then
                    StrInVal = Left(StrInVal, Len(StrInVal) - 1)
                End If
                strOutVal = ""
                Do While Len(StrInVal) > 0
                    intj = InStr(StrInVal, "$")
                    If intj > 0 Then
                        strOutVal = strOutVal & Left(StrInVal, intj - 1) & " "
                        If Len(StrInVal) - intj >= 1 Then
                            StrInVal = Right(StrInVal, Len(StrInVal) - intj - 1)
                        Else
                            StrInVal = ""
                        End If
                    Else
                        strOutVal = strOutVal & StrInVal
                        StrInVal = ""
                    End If
                Loop
            Else
                strErrorMsg = "Empty string"
            End If
            TrimSubFieldCodes = strOutVal
        End Function

        '--------------------------------------------------
        ' purpose : bo cac ky $? va $c trong xau 
        ' in : 
        ' out : xau da loai bo 
        '--------------------------------------------------
        Public Function TrimSubFieldCodesTitle(ByVal StrInVal As String, Optional ByVal blnConvertFont As Boolean = True) As String
            Dim strOutVal As New StringBuilder(1024)
            If Trim(StrInVal) <> "" Then
                If blnConvertFont Then
                    StrInVal = ConvertIt(StrInVal) 'KernelOBj.
                End If
                If Right(StrInVal, 1) = "." Then
                    StrInVal = Left(StrInVal, Len(StrInVal) - 1)
                End If

                Dim ok As Boolean = False 'Ok is when a field mark subfield
                Dim notOk As Boolean = False ' when c subfield
                For Each c As Char In StrInVal
                    If c = "$"c Then
                        ok = True
                        notOk = False
                    Else
                        If ok Then
                            If c = "c"c OrElse c = "C"c Then
                                notOk = True
                            End If
                            ok = False
                        Else
                            If Not notOk Then
                                strOutVal.Append(c)
                            End If
                        End If
                    End If
                Next
            Else
                strErrorMsg = "Empty string"
            End If
            TrimSubFieldCodesTitle = strOutVal.ToString()
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
        Public Sub ParseFieldValue(ByVal strInput As String, ByVal strDeliminator As String, ByRef arrRecs() As Object, Optional ByVal strFieldCode As String = "")
            ' Declare variables
            Dim intIndex As Integer
            Dim intOffset As Integer
            Dim intNc As Integer

            intIndex = 0
            intNc = 0
            'If strFieldCode = "072" Then
            '    strInput = strInput
            'Else
            '    strInput = Trim(strInput)
            'End If
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

        ' ParseField method
        ' SubFieldList "$a,$b,$c,$d,$e"
        ' strValue : $akinh te vi mo,$bNTV/$cfkdjashk
        ' REC(0)=kinh te vi mo ->$a
        ' REC(1)=bNTV -> $b
        ' REC(2)=cfkdjashk -> $c

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
                recs(k) = ""
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
                            recs(k) = recs(k) & GEntryTrim(Left(SubPart, q - 1)) & deliminator
                        Else
                            If Nc = 1 Then
                                recs(k) = recs(k) & Left(SubPart, q - 1) & deliminator
                            Else
                                recs(k) = recs(k) & Left(SubPart, q - 1) & deliminator
                            End If
                        End If
                        TheRest = TheRest & Right(SubPart, Len(SubPart) - q + 1)
                    Else
                        If Tr = 1 Then
                            'recs(k) = recs(k) & GEntryTrim(ConvertItBack(SubPart)) & deliminator
                            recs(k) = recs(k) & GEntryTrim(SubPart) & deliminator
                        Else
                            If Nc = 1 Then
                                recs(k) = recs(k) & SubPart & deliminator
                            Else
                                'recs(k) = recs(k) & ConvertItBack(SubPart) & deliminator
                                recs(k) = recs(k) & SubPart & deliminator
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
            End While
            If Nc = 1 Then
                ReDim Preserve recs(k)
                recs(k) = strValue
            Else
                If strValue <> "" AndAlso strValue <> "," AndAlso strValue <> "." AndAlso strValue <> ":" Then
                    Dim indicatorIndex As Integer = strValue.IndexOf("::")
                    If indicatorIndex > 0 Then
                        If recs(0) <> "" Then
                            recs(0) = strValue.Substring(0, indicatorIndex + 2) & recs(0)
                        End If
                    Else
                        ReDim Preserve recs(k)
                        recs(k) = strValue
                    End If
                End If
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
            Str = Str.Trim
            If Str <> "" Then
                strLastChar = Right(Str, 1)
                If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = "." Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                    Str = Left(Str, Len(Str) - 1)
                End If
            Else
                strErrorMsg = "Empty String"
            End If
            GEntryTrim = Str.Trim
        End Function

        '--------------------------------------------------
        ' SonPQ 20160603, ham Trim cac ky tu dac biet nhung bo qua dau (.)
        '--------------------------------------------------
        Public Function GEntryTrimExp1(ByVal Str As String) As String
            Dim strLastChar As String
            If Str Is Nothing Then
                Str = ""
            End If
            Str = Str.Trim
            If Str <> "" Then
                strLastChar = Right(Str, 1)
                'If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = ";" Or strLastChar = "=" Then ' THO 20170111, ham Trim cac ky tu dac biet nhung bo qua dau (.) va (+)
                    Str = Left(Str, Len(Str) - 1)
                End If
            Else
                strErrorMsg = "Empty String"
            End If
            GEntryTrimExp1 = Str.Trim
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
        Public Function DoubleSingleQuote(ByVal strText As String) As String
            ' can not trim here !
            ' Modify by lent , 13-06-2007
            'strText = Trim(strText)
            If Not strText = "" Then
                'DoubleSingleQuote = Replace(strText, "''", "")
                DoubleSingleQuote = Replace(strText, "'", "''")
            Else
                DoubleSingleQuote = ""
            End If
        End Function

        '--------------------------------------------------
        ' purpose : 
        ' in : 
        ' out : 
        ' creator :
        '--------------------------------------------------
        Public Function ProcessVal(ByVal strPv As String) As String
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
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        'str = Trim(objTVCom.Upper(str))
                        str = Trim(UCase(str))
                    Case "SQLSERVER"
                        str = Trim(UCase(str))
                End Select
                str = SyncAccent(str)
                str = CJKSplitter(str)
                ProcessVal = str
            Else
                ProcessVal = ""
                strErrorMsg = "Empty String"
            End If
        End Function

        Public Function DecryptPassword(ByVal strVal As String) As String
            Dim strRet As String
            Dim objXe As XCrypt.XCryptEngine
            objXe = New XCrypt.XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.MD5)
            strRet = objXe.Decrypt(strVal)
            objXe = Nothing
            DecryptPassword = strRet
        End Function


        Public Function EncryptedPassword(ByVal strVal As String) As String
            Dim strRet As String
            Dim objXe As XCrypt.XCryptEngine
            objXe = New XCrypt.XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.MD5)
            strRet = objXe.Encrypt(strVal, "pl")
            objXe = Nothing
            EncryptedPassword = strRet
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
            'strIn = strIn.Trim()
            'If Trim(strIn) <> "" Then
            '    Select Case Trim(strDBServer)
            '        Case "SQLSERVER"
            '            Select Case strInterfaceLanguage
            '                Case "tcvn"
            '                    strIn = objTVCom.Convert("tcvn", "ucs2", strIn)
            '                Case "vni"
            '                    strIn = objTVCom.Convert("vni", "ucs2", strIn)
            '                Case "viqr"
            '                    strIn = objTVCom.Convert("viqr", "ucs2", strIn)
            '            End Select
            '        Case "ORACLE"
            '            Select Case strInterfaceLanguage
            '                Case "tcvn"
            '                    strIn = objTVCom.Convert("tcvn", "unicode1", strIn)
            '                Case "vni"
            '                    strIn = objTVCom.Convert("vni", "unicode1", strIn)
            '                Case "viqr"
            '                    strIn = objTVCom.Convert("viqr", "unicode1", strIn)
            '                    'Case "unicode"
            '                    'strIn = objTVCom.Convert("ucs2", "unicode1", strIn)
            '            End Select
            '    End Select
            '    ConvertItBack = Trim(strIn)
            'Else
            '    ConvertItBack = ""
            'End If
            If Not strIn Is Nothing Then
                Return strIn
            End If
            ConvertItBack = ""
        End Function

        '---------------------------------------------
        ' purpose: Convert a string to current encode
        ' in : string to convert
        ' out : string converted
        ' creator :
        '---------------------------------------------
        Public Function ConvertItBack(ByVal strIn As String, ByVal blnReplace As Boolean) As String
            strIn = Trim(strIn & "")
            'If Trim(strIn) <> "" Then
            '    Select Case Trim(strDBServer)
            '        Case "SQLSERVER"
            '            Select Case strInterfaceLanguage
            '                Case "tcvn"
            '                    strIn = objTVCom.Convert("tcvn", "ucs2", strIn)
            '                Case "vni"
            '                    strIn = objTVCom.Convert("vni", "ucs2", strIn)
            '                Case "viqr"
            '                    strIn = objTVCom.Convert("viqr", "ucs2", strIn)
            '            End Select
            '        Case "ORACLE"
            '            Select Case strInterfaceLanguage
            '                Case "tcvn"
            '                    strIn = objTVCom.Convert("tcvn", "unicode1", strIn)
            '                Case "vni"
            '                    strIn = objTVCom.Convert("vni", "unicode1", strIn)
            '                Case "viqr"
            '                    strIn = objTVCom.Convert("viqr", "unicode1", strIn)
            '                    'Case "unicode"
            '                    'strIn = objTVCom.Convert("ucs2", "unicode1", strIn)
            '            End Select
            '    End Select
            '    ConvertItBack = Replace(strIn, "'", "''")
            'Else
            '    ConvertItBack = ""
            'End If
            ConvertItBack = strIn
        End Function

        '---------------------------------------------
        ' purpose: Convert a string from other encode to current encode
        ' in : string to convert
        ' out : string converted
        ' creator : 
        '---------------------------------------------
        Public Function ConvertToCurrentEncode(ByVal strSource As String, ByVal strDestination As String, ByVal strIn As String) As String
            strIn = Trim(strIn) & ""
            'strIn = objTVCom.Convert(strSource, strDestination, strIn)
            ConvertToCurrentEncode = strIn
        End Function
        ' Z3950 supports only 2 format: utf8 & marc8
        ' ZConvertIt method for Z3950 search
        ' Purpose: convert string in to Marc8 (utf-8)
        ' Input: strIn, blnIsMarc8
        ' Output: string converted
        ' Created on 25/11/2003 by oanhtn
        Public Function ZConvertIt(ByVal strIn As String, ByVal blnIsMarc8 As Boolean) As String
            strIn = Trim(strIn) & ""
            If blnIsMarc8 Then
                '    Select Case strInterfaceLanguage
                '        Case "tcvn"
                '            strIn = objTVCom.Convert("usmarc", "tcvn", strIn)
                '        Case "vni"
                '            strIn = objTVCom.Convert("usmarc", "vni", strIn)
                '        Case "unicode"
                '            strIn = objTVCom.Convert("usmarc", "ucs2", strIn)
                '    End Select
            Else
                '    Select Case strInterfaceLanguage
                '        Case "tcvn"
                '            strIn = objTVCom.Convert("unicode1", "tcvn", strIn)
                '        Case "vni"
                '            strIn = objTVCom.Convert("unicode1", "vni", strIn)
                '        Case "unicode"
                '            strIn = objTVCom.Convert("unicode1", "ucs2", strIn)
                '    End Select
                Try
                    Dim unicodeBytes As Byte() = Encoding.Default.GetBytes(strIn)
                    Dim utfBytes As Byte() = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, unicodeBytes)
                    strIn = Encoding.Unicode.GetString(utfBytes)
                Catch ex As Exception
                End Try
            End If
            ZConvertIt = strIn
        End Function

        ' ZConvertItBack method for Z3950 search
        ' Purpose: convert string from Marc8 (utf-8)
        ' Input: strIn, blnIsMarc8
        ' Output: string converted
        ' Created on 25/11/2003 by oanhtn
        Public Function ZConvertItBack(ByVal strIn As String, ByVal blnIsMarc8 As Boolean) As String
            strIn = Trim(strIn) & ""
            If blnIsMarc8 Then
                '    Select Case strInterfaceLanguage
                '        Case "tcvn"
                '            strIn = objTVCom.Convert("tcvn", "usmarc", strIn)
                '        Case "vni"
                '            strIn = objTVCom.Convert("vni", "usmarc", strIn)
                '        Case "unicode"
                '            strIn = objTVCom.Convert("ucs2", "usmarc", strIn)
                '    End Select
            Else
                '    Select Case strInterfaceLanguage
                '        Case "tcvn"
                '            strIn = objTVCom.Convert("tcvn", "unicode1", strIn)
                '        Case "vni"
                '            strIn = objTVCom.Convert("vni", "unicode1", strIn)
                '        Case "unicode"
                '            strIn = objTVCom.Convert("ucs2", "unicode1", strIn)
                '    End Select
                Dim Buffer() As Byte
                Dim RecvMessage As String = ""
                Try
                    Dim utf8Bytes As Byte() = Encoding.UTF8.GetBytes(strIn)
                    Dim isoBytes As Byte() = Encoding.Convert(Encoding.Default, Encoding.UTF8, utf8Bytes)
                    RecvMessage = Encoding.UTF8.GetString(isoBytes)
                Catch ex As Exception
                End Try
                Return RecvMessage
            End If
            'ZConvertItBack = Replace(strIn, "'", "''")
            'modify by lent 5-3-2007
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
        Public Function UTF8ToUnicode(ByVal strIn As String) As String
            Dim RecvMessage As String = ""
            Try
                Dim unicodeBytes As Byte() = Encoding.Default.GetBytes(strIn)
                Dim utfBytes As Byte() = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, unicodeBytes)
                RecvMessage = Encoding.Unicode.GetString(utfBytes)
            Catch ex As Exception
            End Try
            Return strIn
        End Function

        ' purpose: Convert tu UTf8 sang ma hien thoi
        '           dung trong truong hop hien thi gia tri sau khi su dung Template
        ' in: strIn -> chuoi can convert
        ' out: String -> chuoi da convert
        Public Function ToUTF8Back(ByVal strIn As String) As String
            'Dim Buffer() As Byte
            'Dim RecvMessage As String = ""
            'Try
            '    Buffer = System.Text.Encoding.Default.GetBytes(strIn.ToCharArray)
            '    Dim clsFont As New MLFonts.UnicodeText
            '    RecvMessage = clsFont.Utf8ToUnicode(Buffer)
            '    clsFont = Nothing
            'Catch ex As Exception : End Try
            'Return RecvMessage
            Dim RecvMessage As String = ""
            Try
                Dim unicodeBytes As Byte() = Encoding.Default.GetBytes(strIn)
                Dim utfBytes As Byte() = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, unicodeBytes)
                RecvMessage = Encoding.Unicode.GetString(utfBytes)
            Catch ex As Exception
            End Try
            Return strIn
        End Function

        ' purpose: Convert UCS2-> UTF8 doi voi SQL Server
        '          Convert UTF8-> UTF8 doi voi ORACLE
        '       dung cho su dung Template
        ' in: strIn -> chuoi can convert
        ' out: String -> chuoi da convert
        Public Function UnicodeToUTF8(ByVal strIn As String) As String
            Dim RecvMessage As String = ""
            Try
                Dim utf8Bytes As Byte() = Encoding.UTF8.GetBytes(strIn)
                Dim isoBytes As Byte() = Encoding.Convert(Encoding.Default, Encoding.UTF8, utf8Bytes)
                RecvMessage = Encoding.UTF8.GetString(isoBytes)
            Catch ex As Exception
            End Try
            Return strIn
        End Function

        Public Function UTF8Upper(ByVal strIn As String) As String
            Dim RecvMessage As String = ""
            Try
                RecvMessage = UTF8ToUnicode(strIn)
                RecvMessage = UCase(RecvMessage)
                RecvMessage = UnicodeToUTF8(RecvMessage)
            Catch ex As Exception : End Try
            Return strIn
        End Function

        ' purpose : convert  tu ma hien thoi sang UTF8
        '           dung cho truong hop su dung COM template
        ' in: strIN -> chuoi can convert
        ' out: String -> chuoi duoc convert
        Public Function ToUTF8(ByVal strIn As String) As String
            'Dim Buffer() As Byte
            'Dim RecvMessage As String = ""
            'Try
            '    Dim clsFont As New MLFonts.UnicodeText
            '    Buffer = clsFont.UnicodeToUtf8(strIn)
            '    RecvMessage = System.Text.Encoding.Default.GetString(Buffer)
            '    clsFont = Nothing
            'Catch ex As Exception : End Try
            'Return RecvMessage

            ' remove funtion by quocdo
            Dim RecvMessage As String = ""
            Try
                Dim utf8Bytes As Byte() = Encoding.UTF8.GetBytes(strIn)
                Dim isoBytes As Byte() = Encoding.Convert(Encoding.Default, Encoding.UTF8, utf8Bytes)
                RecvMessage = Encoding.UTF8.GetString(isoBytes)
            Catch ex As Exception
            End Try
            Return strIn
        End Function

        ' purpose : convert  tu UCS2 sang ma hien thoi
        '           dung cho truong hop su dung COM template
        ' in: strIN -> chuoi can convert
        ' out: String -> chuoi duoc convert

        Public Function UCS2ToCurrent(ByVal strIn As String) As String
            'If Trim(strIn) <> "" Then
            '    Select Case LCase(strInterfaceLanguage)
            '        Case "unicode"
            '        Case "tcvn"
            '            strIn = objTVCom.Convert("ucs2", "tcvn", strIn)
            '        Case "vni"
            '            strIn = objTVCom.Convert("ucs2", "vni", strIn)
            '    End Select
            '    UCS2ToCurrent = Trim(strIn)
            'Else
            '    UCS2ToCurrent = ""
            'End If
            UCS2ToCurrent = Trim(strIn)
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
            UCS2Title = Trim(strconvert)
        End Function

        Public Function UCS2DataLabel(ByVal strconvert As String) As String
            ''If Trim(strconvert) <> "" Then
            ''    Select Case UCase(strDBServer)
            ''        Case "ORACLE"
            ''            UCS2DataLabel = objTVCom.Convert("unicode1", "ucs2", strconvert)
            ''        Case "SQLSERVER"
            ''            UCS2DataLabel = strconvert
            ''    End Select
            ''End If
            ''UCS2DataLabel = Trim(UCS2DataLabel)
            'Dim Buffer() As Byte
            'Dim RecvMessage As String = ""
            'Try
            '    Buffer = System.Text.Encoding.Default.GetBytes(strconvert.ToCharArray)
            '    Dim clsFont As New MLFonts.UnicodeText
            '    RecvMessage = clsFont.Utf8ToUnicode(Buffer)
            '    clsFont = Nothing
            'Catch ex As Exception : End Try
            'Return RecvMessage

            'quocdd 23/09/2013
            ' fix error font
            'Dim RecvMessage As String = ""
            'Try
            '    Dim unicodeBytes As Byte() = Encoding.Default.GetBytes(strconvert)
            '    Dim utfBytes As Byte() = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, unicodeBytes)
            '    RecvMessage = Encoding.Unicode.GetString(utfBytes)
            'Catch ex As Exception
            'End Try
            Return strconvert
        End Function

        Public Function UCS2Back(ByVal strIn As String) As String
            Dim RecvMessage As String = ""
            Try
                Dim unicodeBytes As Byte() = Encoding.Default.GetBytes(strIn)
                Dim utfBytes As Byte() = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, unicodeBytes)
                RecvMessage = Encoding.Unicode.GetString(utfBytes)
            Catch ex As Exception
            End Try
            Return RecvMessage
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
                    'If (et - at <> 2) Then
                    If strInput.Substring(at, et - at + 1).ToUpper <> "<BR>" Then
                        Dim tem As String
                        tem = strInput.Substring(at, et - at + 1)
                        tem = tem.Replace("<", "&")
                        tem = tem.Replace(">", "@")
                        strInput = strInput.Replace(strInput.Substring(at, et - at + 1), tem)
                        'MsgBox(strInput.Substring(at, et - at + 1).ToUpper)
                        'MsgBox(strInput)
                    End If
                End If
                'End If
                ' MessageBox.Show("Vi tri cua chuoi la", at & " va dấu đóng " & et)
            End While
            'MessageBox.Show(strInput)
        End Function


        ' Method: CJKSplitter
        ' Purpose: support Chinese, Japanese, Korea language
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
            CJKSplitter = strOut
        End Function

        Public Sub SortByDictionary(ByRef objSort As Object, ByVal objTitle As Object, ByVal intDirectionsort As Integer)
            Try
                'Sap xep
                'B1
                'PhuongTT -  2014.11.19
                Dim sortDic As New SortedDictionary(Of Object, Object)
                Dim strKey As Object = ""
                Dim intValue As Object = 0
                Dim inti As Integer
                For inti = 0 To UBound(objSort)
                    Try
                        strKey = ""
                        If Not IsDBNull(objTitle(inti)) Then
                            strKey = Trim(objTitle(inti))
                        Else
                            'Neu gia tri rong thi sap xep nam o cuoi cung
                            strKey &= "z"
                        End If
                        strKey &= objSort(inti)
                        intValue = objSort(inti)
                        sortDic.Add(strKey, intValue)
                    Catch ex As Exception
                        'pass duplicate record
                    End Try
                Next
                inti = 0
                For Each kvp As KeyValuePair(Of Object, Object) In sortDic
                    ReDim Preserve objSort(inti)
                    objSort(inti) = kvp.Value
                    inti += 1
                Next
            Catch ex As Exception
            End Try
        End Sub

        Public Function SortIndexDictionary(ByVal objSort() As Object, ByVal objTitle() As Object, ByVal intDirectionsort As Integer) As Integer()
            Dim intArrResult() As Integer = Nothing
            Try
                'Sap xep
                'B1
                'PhuongTT -  2014.11.19
                Dim sortDic As New SortedDictionary(Of Object, Object)
                Dim strKey As String = ""
                Dim intValue As Integer = 0
                Dim inti As Integer
                For inti = 0 To UBound(objSort)
                    Try
                        strKey = ""
                        If Not IsDBNull(objTitle(inti)) Then
                            strKey = Trim(objTitle(inti))
                        Else
                            'Neu gia tri rong thi sap xep nam o cuoi cung
                            strKey &= "z"
                        End If
                        strKey &= objSort(inti)
                        intValue = objSort(inti)
                        sortDic.Add(strKey, intValue)
                    Catch ex As Exception
                        'pass duplicate record
                    End Try
                Next
                inti = 0
                For Each kvp As KeyValuePair(Of Object, Object) In sortDic
                    ReDim Preserve intArrResult(inti)
                    intArrResult(inti) = kvp.Value
                    inti += 1
                Next
            Catch ex As Exception
            End Try
            Return intArrResult
        End Function

        Public Function SortIndexDictionary(ByVal objTitle() As Object, ByVal intDirectionsort As Integer) As Object()
            Dim intArrResult() As Object = Nothing
            Try
                'Sap xep
                'B1
                'PhuongTT -  2014.11.19
                Dim sortDic As New SortedDictionary(Of Object, Integer)
                Dim strKey As String = ""
                Dim intValue As Integer = 0
                Dim inti As Integer
                For inti = 0 To UBound(objTitle)
                    Try
                        strKey = ""
                        If Not IsDBNull(objTitle(inti)) Then
                            strKey = Trim(objTitle(inti))
                        Else
                            'Neu gia tri rong thi sap xep nam o cuoi cung
                            strKey &= "z"
                        End If
                        strKey &= inti
                        intValue = inti
                        sortDic.Add(strKey, intValue)
                    Catch ex As Exception
                        'pass duplicate record
                    End Try
                Next
                inti = 0
                For Each kvp As KeyValuePair(Of Object, Integer) In sortDic
                    ReDim Preserve intArrResult(inti)
                    intArrResult(inti) = kvp.Value
                    inti += 1
                Next
            Catch ex As Exception
            End Try
            Return intArrResult
        End Function

        Public Function MiscIdxPos(ByVal arrItemID() As Object, ByVal ItemID As String) As Integer
            Dim intResult As Integer = 0
            Try
                If Not IsNothing(arrItemID) Then
                    For i As Integer = 0 To UBound(arrItemID)
                        If arrItemID(i) = ItemID Then
                            intResult = i + 1
                            Exit For
                        End If
                    Next
                End If
                'intResult = Array.Find(arrItemID, Function(x) (x = ItemID))
            Catch ex As Exception
            End Try
            Return intResult
        End Function


        '2016.04.22 B1
        '$&: Lặp
        'ex: 
        'Input:  ::$aH.$& :$bGiáo dục$& ,$c1999$&
        'Output: ::$aH. :$bGiáo dục ,$c1999$&
        'Input  ::$a1.Khoa hoc 650$&  ::$a2.Khoa hoc 650$& $xx$& $yy$& $zz1$&z2$&
        'Output    ::$a1.Khoa hoc 650 $xx $yy $zz1$& ::$a2.Khoa hoc 650 z2$&
        Public Function parseValueField(ByVal strField As String, ByVal val As String) As String
            Dim strResult As String = ""
            Try
                If InStr(val, "$") > 0 Then
                    Dim SubRecsTemp() As Object = Nothing
                    ParseField("$a,$b,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$n,$o,$p,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z,$2,$3,$4,$5,$6,$7,$8", val, "##", SubRecsTemp)
                    Dim strArrDollar() As String = Split("$a,$b,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$n,$o,$p,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z,$2,$3,$4,$5,$6,$7,$8", ",")
                    If Not IsNothing(SubRecsTemp) Then
                        Dim strArr() As String = Nothing
                        Dim ItemList As New ArrayList()
                        Dim i As Integer = 0
                        Dim j As Integer = 0
                        Dim strTemp As String = ""
                        For i = 0 To UBound(SubRecsTemp) - 1
                            If SubRecsTemp(i).Trim <> "" Then
                                SubRecsTemp(i) = Replace(Replace(SubRecsTemp(i), "::", ""), "$&", "")
                                strTemp = Trim(GEntryTrimExp1(SubRecsTemp(i))) 'SonPQ 20160603, khong trim dau (.) cho cac truong NXB, so trang
                                If strTemp <> "" Then
                                    ReDim Preserve strArr(j)
                                    strArr(j) = ConcatDeliminator(strArrDollar(i), strArrDollar(i) & strTemp)
                                    j += 1
                                End If
                            End If
                        Next

                        Dim strArrTemp() As String = Nothing
                        Dim strArrLst() As String = Nothing
                        Dim k As Integer = 0
                        Dim intMax As Integer = 0
                        For i = 0 To UBound(strArr)
                            If strArr(i).Trim <> "" Then
                                strArrTemp = Split(strArr(i), "##")
                                k = 0
                                For j = 0 To UBound(strArrTemp)
                                    If strArrTemp(j).Trim <> "" Then
                                        ReDim Preserve strArrLst(k)
                                        strArrLst(k) = setSubField(strField, strArrTemp(j).Trim)
                                        k += 1
                                    End If
                                Next
                                ItemList.Add(strArrLst)

                                If intMax < UBound(strArrTemp) Then
                                    intMax = UBound(strArrTemp)
                                End If
                            End If
                        Next

                        Dim arr(ItemList.Count - 1, intMax) As String
                        For i = 0 To ItemList.Count - 1
                            For j = 0 To intMax
                                arr(i, j) = ""
                            Next
                        Next
                        For i = 0 To ItemList.Count - 1
                            Dim strTempAA() As String = ItemList(i)
                            For j = 0 To UBound(strTempAA)
                                If strTempAA(j).Trim <> "" Then
                                    arr(i, j) = strTempAA(j).Trim
                                End If
                            Next
                        Next


                        For j = 0 To intMax
                            strTemp = ""
                            For i = 0 To ItemList.Count - 1
                                If arr(i, j).Trim <> "" Then
                                    If (i = 0 And j = 0) Then
                                        strTemp &= arr(i, j).Trim & Space(1)
                                        If (Right(strTemp, 2) = ". ") Then
                                            strTemp = strTemp.Substring(0, strTemp.Length - 1)
                                        End If
                                    Else
                                        strTemp &= arr(i, j).Trim & Space(1)
                                    End If
                                End If
                            Next
                            If strTemp.Trim <> "" Then
                                strResult &= strTemp.Trim & "$&"
                            End If
                        Next
                        If Not InStr(strResult, "$a") > 0 Then
                            strResult = GEntryTrimSubField(strResult)
                        End If
                    End If
                Else
                    strResult = val
                End If
            Catch ex As Exception
                strResult = val
            End Try
            Return strResult
        End Function

        Public Function parseValueFieldOther(ByVal strField As String, ByVal val As String) As String
            Dim strResult As String = ""
            Dim hasParallelTitle As Boolean = False
            Try
                If InStr(val, "$") > 0 Then
                    Dim SubRecsTemp() As Object = Nothing
                    If strField = "245" AndAlso val.Contains("= $b") Then
                        hasParallelTitle = True
                    End If
                    ParseField("$a,$b,$n,$p,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$o,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z,$2,$3,$4,$5,$6,$7,$8", val, "##", SubRecsTemp)
                    Dim strArrDollar() As String = Split("$a,$b,$n,$p,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$o,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z,$2,$3,$4,$5,$6,$7,$8", ",")
                    If Not IsNothing(SubRecsTemp) Then
                        Dim strArr() As String = Nothing
                        Dim ItemList As New ArrayList()
                        Dim i As Integer = 0
                        Dim j As Integer = 0
                        Dim strTemp As String = ""
                        Dim ub As Integer = Math.Min(UBound(SubRecsTemp), UBound(strArrDollar))
                        For i = 0 To ub
                            If SubRecsTemp(i).Trim <> "" Then
                                If strArrDollar(i) = "$a" Then
                                    SubRecsTemp(i) = Replace(SubRecsTemp(i), "$&", "")
                                    strTemp = Trim(GEntryTrimExp1(SubRecsTemp(i))) 'SonPQ 20160603, khong trim dau (.) cho cac truong NXB, so trang
                                    If strTemp <> "" Then
                                        ReDim Preserve strArr(j)
                                        If strTemp.Contains("::") Then
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), strTemp)
                                        Else
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), strArrDollar(i) & strTemp)
                                        End If
                                        j += 1
                                    End If
                                Else
                                    SubRecsTemp(i) = Replace(Replace(SubRecsTemp(i), "::", ""), "$&", "")
                                    strTemp = Trim(GEntryTrimExp1(SubRecsTemp(i))) 'SonPQ 20160603, khong trim dau (.) cho cac truong NXB, so trang
                                    If strTemp <> "" Then
                                        ReDim Preserve strArr(j)
                                        If strField = "245" AndAlso strArrDollar(i) = "$b" AndAlso hasParallelTitle Then
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), "= " & strArrDollar(i) & strTemp)
                                        Else
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), strArrDollar(i) & strTemp)
                                        End If
                                        j += 1
                                    End If
                                End If
                            End If
                        Next

                        Dim strArrTemp() As String = Nothing
                        Dim strArrLst() As String = Nothing
                        Dim k As Integer = 0
                        Dim intMax As Integer = 0
                        For i = 0 To UBound(strArr)
                            If strArr(i).Trim <> "" Then
                                strArrTemp = Split(strArr(i), "##")
                                k = 0
                                For j = 0 To UBound(strArrTemp)
                                    If strArrTemp(j).Trim <> "" Then
                                        ReDim Preserve strArrLst(k)
                                        strArrLst(k) = setSubField(strField, strArrTemp(j).Trim)
                                        k += 1
                                    End If
                                Next
                                ItemList.Add(strArrLst)

                                If intMax < UBound(strArrTemp) Then
                                    intMax = UBound(strArrTemp)
                                End If
                            End If
                        Next

                        Dim arr(ItemList.Count - 1, intMax) As String
                        For i = 0 To ItemList.Count - 1
                            For j = 0 To intMax
                                arr(i, j) = ""
                            Next
                        Next
                        For i = 0 To ItemList.Count - 1
                            Dim strTempAA() As String = ItemList(i)
                            For j = 0 To UBound(strTempAA)
                                If strTempAA(j).Trim <> "" Then
                                    arr(i, j) = strTempAA(j).Trim
                                End If
                            Next
                        Next


                        For j = 0 To intMax
                            strTemp = ""
                            For i = 0 To ItemList.Count - 1
                                If arr(i, j).Trim <> "" Then
                                    If (i = 0 And j = 0) Then
                                        strTemp &= arr(i, j).Trim & Space(1)
                                        If (Right(strTemp, 2) = ". ") Then
                                            strTemp = strTemp.Substring(0, strTemp.Length - 1)
                                        End If
                                    Else
                                        strTemp &= arr(i, j).Trim & Space(1)
                                    End If
                                End If
                            Next
                            If strTemp.Trim <> "" Then
                                strResult &= strTemp.Trim & "$&"
                            End If
                        Next
                        If Not InStr(strResult, "$a") > 0 Then
                            strResult = GEntryTrimSubField(strResult)
                        End If
                    End If
                Else
                    strResult = val
                End If
            Catch ex As Exception
                strResult = val
            End Try
            Return strResult
        End Function

        Public Function parseValueFieldForEIU(ByVal strField As String, ByVal val As String) As String
            Dim strResult As String = ""
            Dim hasParallelTitle As Boolean = False
            Try
                If InStr(val, "$") > 0 Then
                    Dim SubRecsTemp() As Object = Nothing
                    If strField = "245" AndAlso val.Contains("= $b") Then
                        hasParallelTitle = True
                    End If
                    ParseField("$a,$b,$n,$p,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$o,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z,$2,$3,$4,$5,$6,$7,$8", val, "##", SubRecsTemp)
                    Dim strArrDollar() As String = Split("$a,$b,$n,$p,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$o,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z,$2,$3,$4,$5,$6,$7,$8", ",")
                    If Not IsNothing(SubRecsTemp) Then
                        Dim strArr() As String = Nothing
                        Dim ItemList As New ArrayList()
                        Dim i As Integer = 0
                        Dim j As Integer = 0
                        Dim strTemp As String = ""
                        For i = 0 To UBound(SubRecsTemp)
                            If SubRecsTemp(i).Trim <> "" Then
                                If strArrDollar(i) = "$a" Then
                                    SubRecsTemp(i) = Replace(SubRecsTemp(i), "$&", "")
                                    strTemp = Trim(GEntryTrimExp1(SubRecsTemp(i))) 'SonPQ 20160603, khong trim dau (.) cho cac truong NXB, so trang
                                    If strTemp <> "" Then
                                        ReDim Preserve strArr(j)
                                        If strTemp.Contains("::") Then
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), strTemp)
                                        Else
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), strArrDollar(i) & strTemp)
                                        End If
                                        j += 1
                                    End If
                                Else
                                    SubRecsTemp(i) = Replace(Replace(SubRecsTemp(i), "::", ""), "$&", "")
                                    strTemp = Trim(GEntryTrimExp1(SubRecsTemp(i))) 'SonPQ 20160603, khong trim dau (.) cho cac truong NXB, so trang
                                    If strTemp <> "" Then
                                        ReDim Preserve strArr(j)
                                        If strField = "245" AndAlso strArrDollar(i) = "$b" AndAlso hasParallelTitle Then
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), "= " & strArrDollar(i) & strTemp)
                                        Else
                                            strArr(j) = ConcatDeliminator(strArrDollar(i), strArrDollar(i) & strTemp)
                                        End If
                                        j += 1
                                    End If
                                End If
                            End If
                        Next

                        Dim strArrTemp() As String = Nothing
                        Dim strArrLst() As String = Nothing
                        Dim k As Integer = 0
                        Dim intMax As Integer = 0
                        For i = 0 To UBound(strArr)
                            If strArr(i).Trim <> "" Then
                                strArrTemp = Split(strArr(i), "##")
                                k = 0
                                For j = 0 To UBound(strArrTemp)
                                    If strArrTemp(j).Trim <> "" Then
                                        ReDim Preserve strArrLst(k)
                                        strArrLst(k) = setSubField(strField, strArrTemp(j).Trim)
                                        k += 1
                                    End If
                                Next
                                ItemList.Add(strArrLst)

                                If intMax < UBound(strArrTemp) Then
                                    intMax = UBound(strArrTemp)
                                End If
                            End If
                        Next

                        Dim arr(ItemList.Count - 1, intMax) As String
                        For i = 0 To ItemList.Count - 1
                            For j = 0 To intMax
                                arr(i, j) = ""
                            Next
                        Next
                        For i = 0 To ItemList.Count - 1
                            Dim strTempAA() As String = ItemList(i)
                            For j = 0 To UBound(strTempAA)
                                If strTempAA(j).Trim <> "" Then
                                    arr(i, j) = strTempAA(j).Trim
                                End If
                            Next
                        Next


                        For j = 0 To intMax
                            strTemp = ""
                            For i = 0 To ItemList.Count - 1
                                If arr(i, j).Trim <> "" Then
                                    If (i = 0 And j = 0) Then
                                        strTemp &= arr(i, j).Trim & Space(1)
                                        If (Right(strTemp, 2) = ". ") Then
                                            strTemp = strTemp.Substring(0, strTemp.Length - 1)
                                        End If
                                    Else
                                        strTemp &= arr(i, j).Trim & Space(1)
                                    End If
                                End If
                            Next
                            If strTemp.Trim <> "" Then
                                strResult &= strTemp.Trim & "$&"
                            End If
                        Next
                        If Not InStr(strResult, "$a") > 0 Then
                            strResult = GEntryTrimSubField(strResult)
                        End If
                    End If
                Else
                    strResult = val
                End If
            Catch ex As Exception
                strResult = val
            End Try
            Return strResult
        End Function

        Private Function ConcatDeliminator(ByVal strDollar As String, ByVal strVal As String, Optional ByVal deliminator As String = "##") As String
            Dim strResult As String = ""
            Try
                strResult = Replace(strVal, deliminator, deliminator & strDollar)
                If strResult.Contains("::") Then
                    strResult = Replace(strResult, "::", "::$a")
                Else
                    strResult = Replace(strResult, "$a", "::$a")
                End If
            Catch ex As Exception

            End Try
            Return strResult
        End Function

        Private Function AddDeliminator(ByVal strDollar As String, ByVal strVal As String, Optional ByVal deliminator As String = "$&") As String
            Dim strResult As String = ""
            Try
                Dim strArr() As String = Split(strVal, deliminator)
                For i As Integer = 0 To UBound(strArr)
                    If strArr(i).Trim <> "" Then
                        strResult &= strDollar & strArr(i) & deliminator
                    End If
                Next
            Catch ex As Exception
                strResult = strVal
            End Try
            Return strResult
        End Function

        Private Function AddDeliminator_245b(ByVal value As String) As String
            Dim strResult As String = ""
            Dim titleParts As String() = value.Replace("$b", "").Trim().Split(New String() {"##"}, StringSplitOptions.None)
            If titleParts.Length > 1 Then
                'Check Parallel Title valid
                If titleParts(0) <> "" Then
                    strResult &= " = $b" + titleParts(0)

                    'Check sub-title valid
                    If titleParts(1) <> "" Then
                        strResult &= " : " + titleParts(1)
                    End If
                Else
                    If titleParts(1) <> "" Then
                        strResult &= " : $b" + titleParts(1)
                    End If
                End If
            End If
            Return strResult
        End Function

        Private Function setSubField(ByVal strField As String, ByVal value As String) As String
            Dim strResult As String = ""
            Try
                Dim strDollar As String = strField
                Dim strSpace As String = Space(1)
                If (strField = "245") AndAlso InStr(value, "$b") > 0 Then
                    If Not value.Contains("= $b") Then
                        strResult = Replace(value, "$b", strSpace & ":" & "$b")
                    Else
                        strResult = value
                    End If
                ElseIf (strField = "245") AndAlso InStr(value, "$c") > 0 Then
                    strResult = Replace(value, "$c", GetFieldPunctuationMark("245$c") & "$c")
                ElseIf (strField = "245") AndAlso InStr(value, "$n") > 0 Then
                    strResult = Replace(value, "$n", GetFieldPunctuationMark("245$n") & "$n")
                ElseIf (strField = "245") AndAlso InStr(value, "$p") > 0 Then
                    strResult = Replace(value, "$p", GetFieldPunctuationMark("245$p") & "$p")
                ElseIf (strField = "100") AndAlso InStr(value, "$b") > 0 Then
                    strResult = Replace(value, "$b", GetFieldPunctuationMark("100$b") & "$b")
                ElseIf (strField = "100") AndAlso InStr(value, "$c") > 0 Then
                    strResult = Replace(value, "$c", GetFieldPunctuationMark("100$c") & "$c")
                ElseIf (strField = "100") AndAlso InStr(value, "$d") > 0 Then
                    strResult = Replace(value, "$d", GetFieldPunctuationMark("100$d") & "$d")
                ElseIf (strField = "110") AndAlso InStr(value, "$b") > 0 Then
                    strResult = Replace(value, "$b", GetFieldPunctuationMark("110$b") & "$b")
                ElseIf (strField = "020") AndAlso InStr(value, "$c") > 0 Then
                    strResult = Replace(value, "$c", GetFieldPunctuationMark("020$c") & "$c")
                ElseIf (strField = "250") AndAlso InStr(value, "$b") > 0 Then
                    strResult = Replace(value, "$b", GetFieldPunctuationMark("250$b") & "$b")
                ElseIf (strField = "260") AndAlso InStr(value, "$b") > 0 Then
                    strResult = Replace(value, "$b", GetFieldPunctuationMark("260$b") & "$b")
                ElseIf (strField = "260") AndAlso InStr(value, "$c") > 0 Then
                    strResult = Replace(value, "$c", GetFieldPunctuationMark("260$c") & "$c")
                ElseIf (strField = "300") AndAlso InStr(value, "$b") > 0 Then
                    strResult = Replace(value, "$b", GetFieldPunctuationMark("300$b") & "$b")
                ElseIf (strField = "300") AndAlso InStr(value, "$c") > 0 Then
                    strResult = Replace(value, "$c", GetFieldPunctuationMark("300$c") & "$c")
                ElseIf (strField = "300") AndAlso InStr(value, "$e") > 0 Then
                    strResult = Replace(value, "$e", GetFieldPunctuationMark("300$e") & "$e")
                ElseIf (strField = "440") AndAlso InStr(value, "$b") > 0 Then
                    strResult = Replace(value, "$b", GetFieldPunctuationMark("440$b") & "$b")
                ElseIf (strField = "440") AndAlso InStr(value, "$v") > 0 Then
                    strResult = Replace(value, "$v", GetFieldPunctuationMark("440$v") & "$v")
                ElseIf (strField = "440") AndAlso InStr(value, "$n") > 0 Then
                    strResult = Replace(value, "$n", GetFieldPunctuationMark("440$n") & "$n")
                ElseIf (strField = "440") AndAlso InStr(value, "$p") > 0 Then
                    strResult = Replace(value, "$p", GetFieldPunctuationMark("440$p") & "$p")
                ElseIf (strField = "440$x") AndAlso InStr(value, "$x") > 0 Then
                    strResult = Replace(value, "$x", GetFieldPunctuationMark("440$x") & "$x")
                ElseIf (strField = "650") AndAlso InStr(value, "$2") > 0 Then
                    strResult = Replace(value, "$2", GetFieldPunctuationMark("650$2") & "$2")
                ElseIf (strField = "650") AndAlso InStr(value, "$b") > 0 Then
                    strResult = Replace(value, "$b", GetFieldPunctuationMark("650$b") & "$b")
                ElseIf (strField = "650") AndAlso InStr(value, "$e") > 0 Then
                    strResult = Replace(value, "$e", GetFieldPunctuationMark("650$e") & "$e")
                ElseIf (strField = "700") AndAlso InStr(value, "$d") > 0 Then
                    strResult = Replace(value, "$d", GetFieldPunctuationMark("700$d") & "$d")
                ElseIf (strField = "700") AndAlso InStr(value, "$e") > 0 Then
                    strResult = Replace(value, "$e", GetFieldPunctuationMark("700$e") & "$e")
                ElseIf (strField = "710") AndAlso InStr(value, "$d") > 0 Then
                    strResult = Replace(value, "$d", GetFieldPunctuationMark("710$d") & "$d")
                ElseIf (strField = "710") AndAlso InStr(value, "$e") > 0 Then
                    strResult = Replace(value, "$e", GetFieldPunctuationMark("710$e") & "$e")
                Else
                    strResult = value
                End If
            Catch ex As Exception
                strResult = value
            End Try
            Return strResult
        End Function

        ''' <summary>
        ''' ex: 260$c,2016,::$aTp.Ho Chi Minh$&  :$bGiao duc$& --> strResult = ::$aTp.Ho Chi Minh$&  :$bGiao duc$& ,$c2016$&
        ''' ::$a260 a1$&::$a260 a2$& :$b260 b1$& :$b260 b2$& ,$c260 c1$& ,$c260 c2$&
        ''' </summary>
        ''' <param name="strSubFieldCode"> The full fieldcode include it's subfield, ex: 260$a</param>
        ''' <param name="value"></param>
        ''' <param name="strResult"></param>
        Public Sub concatValueSubFields(ByVal strSubFieldCode As String, ByVal value As String, ByRef strResult As String)
            Try
                strSubFieldCode = strSubFieldCode.ToLower()
                value = value.Trim()
                If strSubFieldCode.Contains("$a") Then
                    If value <> "" AndAlso value <> "::" AndAlso value <> "::$&" Then
                        'Is result hold a previous value of other subfield.
                        If strResult <> "" Then
                            'Only concat value for subFieldCode not fieldCode.
                            If strSubFieldCode.Contains("$") Then
                                Dim subFieldName As String = strResult.Substring(InStr(strResult, "$"), 1) '260$a, a is subfied name
                                If IsNumeric(subFieldName) Then
                                    If value.Contains("$&") Then
                                        value = Replace(value, "::", "::$a")
                                        strResult = Replace(value, "$&", strResult & "$&")
                                    Else
                                        strResult = Replace(value, "::", "::$a") & strResult
                                    End If
                                Else
                                    strResult &= Replace(value, "::", "::$a")
                                End If
                            End If
                        Else
                            'Temporary fix, will remove the next time.
                            If strSubFieldCode = "956$a" Then
                                If value.Contains("::") Then
                                    strResult = Replace(value, "::", "::$a")
                                Else
                                    strResult = "::$a" & value
                                End If
                            Else
                                strResult = Replace(value, "::", "::$a")
                            End If
                        End If
                    End If
                Else
                    If value <> "" AndAlso value <> "$&" Then
                        If strSubFieldCode.Contains("$") Then
                            Dim strDollar As String = strSubFieldCode.Substring(InStr(strSubFieldCode, "$") - 1)
                            Dim strSpace As String = Space(1)
                            Select Case strSubFieldCode
                                Case "245$b"
                                    strResult &= AddDeliminator_245b(value)
                                Case Else
                                    strResult &= AddDeliminator(GetFieldPunctuationMark(strSubFieldCode) & strDollar, value)
                            End Select
                        Else
                            strResult &= value
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Function GetFieldPunctuationMark(ByVal strSubFieldCode As String) As String
            Select Case strSubFieldCode
                Case "020$c"
                    Return " : "
                Case "100$b"
                    Return " ,"
                Case "100$c", "100$e"
                    Return ", "
                Case "100$d"
                    Return " :"
                Case "110$b"
                    Return ". "
                Case "245$c"
                    Return " / "
                Case "245$n"
                    Return " . "
                Case "245$p"
                    Return ", "
                Case "246$b"
                    Return " : "
                Case "250$b"
                    Return " /"
                Case "260$b"
                    Return " : "
                Case "260$c"
                    Return ", "
                Case "300$b"
                    Return " : "
                Case "300$c"
                    Return " ; "
                Case "300$e"
                    Return " + "
                Case "440$b"
                    Return " :"
                Case "440$v"
                    Return " ;"
                Case "440$n"
                    Return " ."
                Case "440$p"
                    Return " ,"
                Case "440$x"
                    Return " ,"
                Case "650$2"
                    Return " ."
                Case "650$b"
                    Return " ."
                Case "650$e"
                    Return " ,"
                Case "700$d", "700$e", "710$d", "710$e"
                    Return ", "
                Case Else
                    Return " "
            End Select
        End Function

        'ex: 245,$aTest nhan de  /$cNgo Van Nam --> 245$a,245$c
        Public Function getSubFieldMARC(ByVal strTag As String, ByVal strVal As String) As String
            Dim strResult As String = ""
            Try
                If strVal.Trim <> "" Then
                    Dim SubRecsTemp() As Object = Nothing
                    ParseField("$2,$3,$4,$5,$6,$7,$8,$a,$b,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$n,$o,$p,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z", strVal, "##", SubRecsTemp)
                    Dim strDollar() As String = Split("$2,$3,$4,$5,$6,$7,$8,$a,$b,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$n,$o,$p,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z", ",")

                    If Not IsNothing(SubRecsTemp) Then
                        For ii As Integer = 0 To UBound(SubRecsTemp)
                            If SubRecsTemp(ii).Trim <> "" Then
                                strResult &= strTag & strDollar(ii) & ","
                            End If
                        Next
                    End If
                    If strResult <> "" Then
                        strResult = Left(strResult, Len(strResult) - 1)
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        'ex: 245$a, $aNhan de 1 /$cNgo Van Nam ,$n1 --> Nhan de 1
        Public Function getValSubFieldMARC(ByVal strTag As String, ByVal strVal As String) As String
            Dim strResult As String = ""
            Dim hasParallelTitle As Boolean = False
            Try
                If strVal.Trim <> "" Then
                    If InStr(strTag, "$") > 0 Then
                        If strTag = "245$b" AndAlso strVal.Contains("= $b") Then
                            hasParallelTitle = True
                        End If
                        Dim strDollar As String = strTag.Trim.Substring(InStr(strTag, "$") - 1)
                        Dim SubRecsTemp() As Object = Nothing
                        ParseField("$2,$3,$4,$5,$6,$7,$8,$a,$b,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$n,$o,$p,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z", strVal, "##", SubRecsTemp)
                        Dim strArrDollar() As String = Split("$2,$3,$4,$5,$6,$7,$8,$a,$b,$c,$d,$e,$f,$g,$h,$i,$j,$k,$l,$m,$n,$o,$p,$q,$r,$s,$t,$u,$v,$w,$x,$y,$z", ",")

                        If Not IsNothing(SubRecsTemp) Then
                            For ii As Integer = 0 To UBound(SubRecsTemp)
                                If SubRecsTemp(ii).Trim <> "" AndAlso strArrDollar(ii) = strDollar Then
                                    strResult = SubRecsTemp(ii).Trim
                                    If strTag = "245$b" Then
                                        If hasParallelTitle Then
                                            If strResult.Contains(" : ") Then
                                                strResult = Trim(GEntryTrim(strResult))
                                            Else
                                                strResult = Trim(GEntryTrim(strResult)) & " : "
                                            End If
                                        Else
                                            strResult = Trim(GEntryTrim(strResult))
                                        End If
                                    ElseIf (strTag = "245$c" OrElse strTag = "245$n" OrElse strTag = "245$p") Then
                                        strResult = Trim(GEntryTrim(strResult))
                                    Else
                                        strResult = Trim(GEntryTrimExp1(strResult))
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                    Else
                        strResult = strVal
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        'ex: 100$a --> 100
        Function getParentField(ByVal strFieldCode As String) As String
            Dim strResult As String = strFieldCode
            Try
                If InStr(strFieldCode, "$") > 0 Then
                    strResult = Left(strFieldCode, 3)
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Private Function GEntryTrimSubField(ByVal Str As String) As String
            Dim strLastChar As String
            Str = Str.Trim
            If Str <> "" Then
                strLastChar = Left(Str, 1)
                If strLastChar = "/" Or strLastChar = ":" Or strLastChar = "," Or strLastChar = "." Or strLastChar = ";" Or strLastChar = "=" Or strLastChar = "+" Then
                    Str = Str.Trim.Substring(1)
                End If
            Else
                strErrorMsg = "Empty String"
            End If
            GEntryTrimSubField = Str.Trim
        End Function

        '2016.04.22 E1

    End Class
End Namespace