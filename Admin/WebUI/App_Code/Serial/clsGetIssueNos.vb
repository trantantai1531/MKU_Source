Namespace eMicLibAdmin.WebUI.Serial
    Public Class clsGetIssueNos
        Public Shared Sub ProccessIssueNo(ByVal strInputs As String, ByRef strHas As String, ByRef strLost As String, Optional ByVal strFirstNo As String = "1")
            If Trim(strFirstNo) = "" Then
                strFirstNo = "1"
            End If
            strInputs = strInputs.Replace("+", ",")
            Dim inti, intj, intPost, intFirstNo As Integer
            Dim strTemp, strCmp, strCmp1 As String
            Dim intEnd, intFirst, intEndn, intFirstn, intEndLost As Integer

            Dim arrInput() As String = strInputs.Split(",")
            ' sort inputs
            For inti = 0 To arrInput.Length - 2
                intPost = InStr(arrInput(inti), "-")
                If intPost > 0 Then
                    strCmp = arrInput(inti).Substring(0, intPost - 1)
                Else
                    strCmp = arrInput(inti)
                End If
                If IsNumeric(strCmp) Then
                    strCmp = strCmp.PadLeft(8, "0")
                End If
                For intj = inti + 1 To arrInput.Length - 1
                    intPost = InStr(arrInput(intj), "-")
                    If intPost > 0 Then
                        strCmp1 = arrInput(intj).Substring(0, intPost - 1)
                    Else
                        strCmp1 = arrInput(intj)
                    End If
                    If IsNumeric(strCmp1) Then
                        strCmp1 = strCmp1.PadLeft(8, "0")
                    End If
                    If strCmp > strCmp1 Then
                        strTemp = arrInput(inti)
                        arrInput(inti) = arrInput(intj)
                        arrInput(intj) = strTemp
                        intPost = InStr(arrInput(inti), "-")
                        If intPost > 0 Then
                            strCmp = arrInput(inti).Substring(0, intPost - 1)
                        Else
                            strCmp = arrInput(inti)
                        End If
                        If IsNumeric(strCmp) Then
                            strCmp = strCmp.PadLeft(8, "0")
                        End If
                    End If
                Next
            Next
            ' start get has and lost
            intPost = InStr(strFirstNo, "-")
            If intPost > 0 Then
                intFirstNo = strFirstNo.Substring(0, intPost - 1)
                intFirst = strFirstNo.Substring(0, intPost - 1)
                intEnd = strFirstNo.Substring(intPost)
            Else
                intFirstNo = strFirstNo
                intFirst = intFirstNo
                intEnd = intFirstNo
            End If

            strHas = ""
            strLost = ""
            For inti = 0 To arrInput.Length - 1
                intPost = InStr(arrInput(inti), "-")
                If intPost > 0 Then
                    intFirstn = arrInput(inti).Substring(0, intPost - 1)
                    intEndn = arrInput(inti).Substring(intPost)
                Else
                    If IsNumeric(arrInput(inti)) Then
                        intFirstn = arrInput(inti)
                        intEndn = arrInput(inti)
                    Else
                        'strHas = MergerIssueNo(strHas, arrInput(inti))
                        intFirstn = intFirstNo - 1
                    End If
                End If
                'start from first issue number
                If intFirstn > intFirstNo Then
                    If intFirstn = intEnd + 1 Then
                        If strHas = "" Then
                            strHas = intFirstn
                        End If
                        strHas = MergerIssueNo(strHas, intEndn)
                    Else
                        If intFirstn > intEnd Then
                            strHas &= "," & arrInput(inti)
                            If strLost = "" Then
                                strLost = CInt(intEnd + 1)
                                intEndLost = intFirstn - 1
                                If intEndLost > intEnd + 1 Then
                                    strLost = strLost & "-" & intEndLost
                                End If
                            Else
                                strLost &= "," & CInt(intEnd + 1)
                                If intFirstn > intEnd + 2 Then
                                    strLost = strLost & "-" & CStr(intFirstn - 1)
                                End If
                                intEndLost = intFirstn - 1
                            End If
                        End If
                    End If
                    If inti = 0 Then
                        If intFirstn > intFirstNo + 1 Then
                            strLost = intFirstNo & "-" & CStr(intFirstn - 1)
                        Else
                            strLost = intFirstNo
                        End If
                    End If
                    intEnd = intEndn
                Else
                    If strHas = "" Then
                        strHas = arrInput(inti)
                    Else
                        strHas &= "," & arrInput(inti)
                    End If
                    intEnd = intEndn
                End If
            Next
            If strHas <> "" Then
                If Left(strHas, 1) = "," Then
                    strHas = strHas.Substring(1)
                End If
            End If
            If strLost <> "" Then
                If Left(strLost, 1) = "," Then
                    strLost = strLost.Substring(1)
                End If
            End If
        End Sub
        Private Shared Function MergerIssueNo(ByVal strCurIssueNo As String, ByVal strNextIssuNo As String) As String
            If Not IsNumeric(strNextIssuNo) Then
                If strCurIssueNo <> "" Then
                    MergerIssueNo = strCurIssueNo & "," & strNextIssuNo
                Else
                    MergerIssueNo = strNextIssuNo
                End If
                Exit Function
            End If
            If strCurIssueNo = "" Then
                MergerIssueNo = strNextIssuNo
                Exit Function
            End If
            Dim intPost, intFirst, intEnd As Integer
            Dim strTemp As String

            intPost = InStrRev(strCurIssueNo, ",")
            If intPost > 0 Then
                strTemp = strCurIssueNo.Substring(intPost)
                strCurIssueNo = strCurIssueNo.Substring(0, intPost - 1)
            Else
                strTemp = strCurIssueNo
                strCurIssueNo = ""
            End If
            intPost = InStr(strTemp, "-")
            If intPost > 0 Then
                intFirst = strTemp.Substring(0, intPost - 1)
            Else
                If IsNumeric(strTemp) Then
                    intFirst = strTemp
                Else
                    MergerIssueNo = strTemp & "," & strNextIssuNo
                    Exit Function
                End If
            End If
            If strCurIssueNo <> "" Then
                strCurIssueNo &= "," & intFirst & "-" & strNextIssuNo
            Else
                strCurIssueNo = intFirst & "-" & strNextIssuNo
            End If
            MergerIssueNo = strCurIssueNo
        End Function

        Public Shared Sub GetHasLostIssueNo(ByVal intResetReg As Integer, ByVal strMonths As String, ByVal strHavingYearIssue As String, ByVal strFirstIssueInYear As String, ByVal strNoVolume As String, ByVal strMonthLabel As String, ByVal strNoIssueRegLabel As String, ByRef strShowHas As String, ByRef strShowLost As String)
            Dim inti, intPos As Integer
            Dim strHas, strLost, strShowHasSes, strShowLostSes, strVolumn As String
            Dim arrVolumesIssue() As String
            Dim intVolumn As Integer
            strShowHas = ""
            strShowLost = ""
            ' For reset mode is every month
            If intResetReg = 1 Then
                ' Format strMonths: 1,2,3|2,3,4.... (not has volumns) or Tap1@1,2,3|2,4...#Tap2@1,2,3,..|2,3,4..
                ' check has volumns
                Dim arrMonth(12) As String

                intPos = InStr(strMonths, "@")
                strShowHas = ""
                strShowLost = ""
                If intPos > 0 Then
                    arrVolumesIssue = strMonths.Split("#")
                    For intVolumn = 0 To arrVolumesIssue.Length - 1
                        intPos = InStr(arrVolumesIssue(intVolumn), "@")
                        If intPos > 0 Then
                            strVolumn = Left(arrVolumesIssue(intVolumn), intPos - 1)
                            strMonths = arrVolumesIssue(intVolumn).Substring(intPos)
                        Else
                            strVolumn = strNoVolume
                            strMonths = arrVolumesIssue(intVolumn)
                        End If
                        arrMonth = strMonths.Split("|")
                        strShowHas = strShowHas & strVolumn & ": <br>"
                        strShowLost = strShowLost & strVolumn & ": <br>"
                        For inti = 0 To arrMonth.Length - 1
                            strLost = ""
                            strHas = ""
                            If arrMonth(inti) = "" And Now.Month > inti + 1 Then
                                strLost = strNoIssueRegLabel
                            Else
                                clsGetIssueNos.ProccessIssueNo(arrMonth(inti), strHas, strLost)
                            End If
                            If strHas <> "" Then
                                strShowHas &= strMonthLabel & CStr(inti + 1) & ":" & strHas & "<br>"
                            End If
                            If strLost <> "" Then
                                strShowLost &= strMonthLabel & CStr(inti + 1) & ":" & strLost & "<br>"
                            End If
                        Next
                        If intVolumn < arrVolumesIssue.Length - 1 Then
                            strShowHas = strShowHas & "<br>"
                            strShowLost = strShowLost & "<br>"
                        End If
                    Next
                Else
                    'don't has any volumn
                    arrMonth = strMonths.Split("|")
                    For inti = 0 To arrMonth.Length - 1
                        clsGetIssueNos.ProccessIssueNo(arrMonth(inti), strHas, strLost)
                        If strHas <> "" Then
                            strShowHas &= strMonthLabel & CStr(inti + 1) & ":" & strHas & "<br>"
                        End If
                        If strLost <> "" Then
                            strShowLost &= strMonthLabel & CStr(inti + 1) & ":" & strLost & "<br>"
                        End If
                    Next
                End If

            End If   ' For reset mode = 1

            ' For reset mode is every year
            If intResetReg <> 1 Then
                If strHavingYearIssue <> "" Then
                    strShowHas = ""
                    strShowLost = ""
                    intPos = InStr(strHavingYearIssue, "@")
                    If intPos > 0 Then
                        arrVolumesIssue = strHavingYearIssue.Split("#")
                        For intVolumn = 0 To arrVolumesIssue.Length - 1
                            intPos = InStr(arrVolumesIssue(intVolumn), "@")
                            If intPos > 0 Then
                                strVolumn = Left(arrVolumesIssue(intVolumn), intPos - 1)
                                strHavingYearIssue = arrVolumesIssue(intVolumn).Substring(intPos)
                            Else
                                strVolumn = strNoVolume
                                strHavingYearIssue = arrVolumesIssue(intVolumn)
                            End If
                            strShowHas = strShowHas & strVolumn & ": "
                            strShowLost = strShowLost & strVolumn & ": "
                            clsGetIssueNos.ProccessIssueNo(strHavingYearIssue, strHas, strLost, strFirstIssueInYear)
                            strShowHas &= strHas
                            strShowLost &= strLost
                            If intVolumn < arrVolumesIssue.Length - 1 Then
                                strShowHas = strShowHas & "<br>"
                                strShowLost = strShowLost & "<br>"
                            End If
                        Next
                    Else
                        'don't has any volumn
                        clsGetIssueNos.ProccessIssueNo(strHavingYearIssue, strShowHas, strShowLost, strFirstIssueInYear)
                    End If
                End If
            End If ' For reset mode = 0,2
        End Sub
    End Class
End Namespace