Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports System.Collections.Generic

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBIdxIdx
        Inherits clsBBase
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBCommonDBSystem As New clsBCommonDBSystem

        'Private objFont As New TVCOMLib.fonts
        'Private objSort As New TVCOMLib.utf8
        'Private objMisc As New libolmisc.misc
        Private dtbBibliography As New DataTable
        Private dtbBibliographyS As New DataTable

        Public Sub Initialize()
            ' ---- Init objBCommonStringProc object
            objBCommonStringProc.DBServer = strDBServer
            objBCommonStringProc.ConnectionString = strConnectionstring
            objBCommonStringProc.InterfaceLanguage = strInterfaceLanguage
            Call objBCommonStringProc.Initialize()
            ' ---- Init objBCommonDBSystem object
            objBCommonDBSystem.DBServer = strDBServer
            objBCommonDBSystem.ConnectionString = strConnectionstring
            objBCommonDBSystem.InterfaceLanguage = strInterfaceLanguage
            Call objBCommonDBSystem.Initialize()
        End Sub

        Public Function LoadData(ByVal strFieldSToIndex As String, ByVal strBibliographyName As String, ByVal intBibliographyCode As Integer, ByVal strMsgFail As String) As String
            Dim strOut As String = ""
            Dim strSql, strItemIDs, strINDoc As String
            Dim i, j, k, l As Integer

            strSql = "SELECT ItemIDS FROM Cat_tblBibliography, CAT_BIBLIOGRAPHY_DETAIL WHERE Cat_tblBibliography.ID = CAT_BIBLIOGRAPHY_DETAIL.ID AND Cat_tblBibliography.ID = " & intBibliographyCode
            objBCommonDBSystem.SQLStatement = strSql
            dtbBibliography = objBCommonDBSystem.RetrieveItemInfor()

            If dtbBibliography Is Nothing AndAlso dtbBibliography.Rows.Count <= 0 Then
                Return strMsgFail
            End If

            Dim arrFieldToIndex() As String
            Dim strFieldToIndex As String

            arrFieldToIndex = Split(strFieldSToIndex, ",")
            Dim arrDocID() As Object
            Dim strField, strTable, strJoinSQL As String
            strSql = ""
            For i = LBound(arrFieldToIndex) To UBound(arrFieldToIndex)
                strField = ""
                strTable = ""
                strJoinSQL = ""
                strFieldToIndex = arrFieldToIndex(i)
                strJoinSQL = ""
                Select Case UCase(strFieldToIndex)
                    Case "ID"
                        strField = "ID As Val, '' As Indicators"
                        strTable = "Item"
                    Case "LEADER"
                        strField = "Leader As Val, '' As Indicators"
                        strTable = "Item"
                    Case "001"
                        strField = "ItemID As Val, '' As Indicators"
                        strTable = "Item"
                    Case "907"
                        strField = "CoverPicture As Val, '' As Indicators"
                        strTable = "Item"
                    Case "911"
                        strField = "Reviewer As Val, '' As Indicators"
                        strTable = "Item"
                    Case "912"
                        strField = "Cataloguer As Val, '' As Indicators"
                        strTable = "Item"
                    Case "925"
                        strField = "Code As Val, '' As Indicators"
                        strTable = "Lib_tblItem, Cat_tblDicMedium"
                        strJoinSQL = "Cat_tblDicMedium.ID = Lib_tblItem.MediumID AND "
                    Case "926"
                        strField = "AccessLevel As Val, '' As Indicators"
                        strTable = "Lib_tblItem"
                    Case "927"
                        strField = "TypeCode As Val, '' As Indicators"
                        strTable = "Lib_tblItem, Cat_tblDicMedium"
                        strJoinSQL = "Cat_tblDicMedium.ID = Lib_tblItem.TypeID AND "
                    Case "MXG"
                        strField = "CopyNumber As Val, '' As Indicators"
                        strTable = "Lib_tblHolding"
                    Case Else
                        If strFieldToIndex > "300" Or strFieldToIndex < "250" Then
                            strField = "Content As Val, Indicators"
                            strTable = "Field" & Left(strFieldToIndex, 1) & "00s A, Lib_tblMARCBibField B"
                            strJoinSQL = " B.FieldCode = A.FieldCode AND B.FieldCode = '" & Left(strFieldToIndex, 3) & "' AND"
                        Else
                            strField = "Content As Val, Indicators"
                            strTable = "Lib_tblField200S A, Lib_tblMARCBibField B"
                            strJoinSQL = " B.FieldCode = A.FieldCode AND B.FieldCode = '" & Left(strFieldToIndex, 3) & "' AND"
                        End If
                End Select

                For j = 0 To dtbBibliography.Rows.Count - 1
                    strINDoc = strINDoc & dtbBibliography.Rows(j).Item("ItemIDs") & ","
                    strItemIDs = strItemIDs & dtbBibliography.Rows(j).Item("ItemIDs") & ","
                    If j Mod 2 = 1 Then
                        strINDoc = Left(strINDoc, Len(strINDoc) - 1)
                        strSql = strSql & "SELECT ItemID, " & strField & ", '" & strFieldToIndex & "' AS Tag FROM " & strTable & " WHERE " & strJoinSQL & " ItemID IN (" & strINDoc & ") UNION "
                        strINDoc = ""
                    End If
                Next
                If j Mod 2 = 1 Then
                    strINDoc = Left(strINDoc, Len(strINDoc) - 1)
                    strSql = strSql & "SELECT ItemID, " & strField & ", '" & strFieldToIndex & "' AS Tag FROM " & strTable & " WHERE " & strJoinSQL & " ItemID IN (" & strINDoc & ") UNION "
                    strINDoc = ""
                End If
                strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                Call objBCommonStringProc.GLoadArray(strItemIDs, arrDocID, ",")
            Next
            dtbBibliography = Nothing
            strSql = Left(strSql, Len(strSql) - 7)
            objBCommonDBSystem.SQLStatement = strSql
            dtbBibliographyS = objBCommonDBSystem.RetrieveItemInfor()
            If Not dtbBibliographyS Is Nothing AndAlso dtbBibliographyS.Rows.Count > 0 Then
                Dim arrIdxList() As Object
                Dim arrIdxDispList() As Object
                Dim arrIdx() As Object
                Dim arrSubVal() As Object
                Dim strPadLeft As String = ""

                Dim intMaxLen, intPosition As Integer
                Dim strVal, strSubFieldCode, strItemID As String

                'objMisc.CreateIdxPos(arrDocID)
                intMaxLen = Len(UBound(arrDocID) + 1)

                'Dim sortDic As New SortedDictionary(Of String, Integer)
                Dim strKey As String = ""
                Dim intValue As Integer = 0

                If Not strFieldToIndex = "mxg" Then
                    If Len(strFieldToIndex) = 5 Then
                        strSubFieldCode = Right(strFieldToIndex, 2)
                    Else
                        strSubFieldCode = ""
                    End If
                    If i = 0 Then
                        l = 0
                    End If
                    For j = 0 To dtbBibliographyS.Rows.Count - 1
                        strItemID = dtbBibliographyS.Rows(j).Item("ItemID")
                        'intPosition = objMisc.IdxPos.Item(CStr(strItemID))
                        intPosition = objBCommonStringProc.MiscIdxPos(arrDocID, CStr(strItemID))
                        If Not strSubFieldCode = "" Then
                            Call objBCommonStringProc.ParseField(strSubFieldCode, dtbBibliographyS.Rows(j).Item("Val"), "tr" & Chr(9), arrSubVal)
                            For k = LBound(arrSubVal) To UBound(arrSubVal)
                                ReDim Preserve arrIdxList(l)
                                ReDim Preserve arrIdxDispList(l)
                                arrIdxDispList(l) = Trim(objBCommonStringProc.TheDisplayOne(objBCommonStringProc.GEntryTrim(arrSubVal(k)))) & Chr(9) & strPadLeft.PadLeft(intMaxLen - Len(intPosition), "0") & intPosition
                                strPadLeft = ""
                                arrIdxList(l) = Trim(objBCommonStringProc.TheSortOne(objBCommonStringProc.GEntryTrim(arrSubVal(k)))) & Chr(9) & strPadLeft.PadLeft(intMaxLen - Len(intPosition), "0") & intPosition
                                strPadLeft = ""
                                If Left(dtbBibliographyS.Rows(i).Item("Tag"), 3) = "245" Then
                                    If Len(dtbBibliographyS.Rows(i).Item("Indicators")) = 2 Then
                                        If IsNumeric(Right(dtbBibliographyS.Rows(j).Item("Indicators"), 1)) Then
                                            arrIdxList(l) = Right(arrIdxList(l), Len(arrIdxList(l)) - CInt(Right(dtbBibliographyS.Rows(j).Item("Indicators"), 1)))
                                        End If
                                    End If
                                End If
                                arrIdxList(l) = objBCommonStringProc.ToUTF8(arrIdxList(l))
                                l = l + 1
                            Next
                        Else
                            ReDim Preserve arrIdxList(l)
                            ReDim Preserve arrIdxDispList(l)
                            arrIdxDispList(l) = Trim(objBCommonStringProc.TheDisplayOne(objBCommonStringProc.TrimSubFieldCodes(dtbBibliographyS.Rows(j).Item("Val")))) & Chr(9) & strPadLeft.PadLeft(intMaxLen - Len(intPosition), "0") & intPosition
                            strPadLeft = ""
                            arrIdxList(l) = Trim(objBCommonStringProc.TheSortOne(objBCommonStringProc.TrimSubFieldCodes(dtbBibliographyS.Rows(j).Item("Val")))) & Chr(9) & strPadLeft.PadLeft(intMaxLen - Len(intPosition), "0") & intPosition
                            strPadLeft = ""
                            If Left(dtbBibliographyS.Rows(j).Item("Tag"), 3) = "245" Then
                                If Len(dtbBibliographyS.Rows(j).Item("Indicators")) = 2 Then
                                    If IsNumeric(Right(dtbBibliographyS.Rows(j).Item("Indicators"), 1)) Then
                                        arrIdxList(l) = Right(arrIdxList(l), Len(arrIdxList(l)) - CInt(Right(dtbBibliographyS.Rows(j).Item("Indicators"), 1)))
                                    End If
                                End If
                            End If
                            arrIdxList(l) = objBCommonStringProc.ToUTF8(arrIdxList(l))
                            l = l + 1
                        End If
                        ''Sap xep
                        ''B1
                        ''PhuongTT -  2014.11.19
                        'Try
                        '    strKey = ""
                        '    If Not IsNothing(arrIdxList(l - 1)) Then
                        '        strKey = Trim(arrIdxList(l - 1))
                        '    Else
                        '        'Neu gia tri rong thi sap xep nam o cuoi cung
                        '        strKey &= "z"
                        '    End If
                        '    strKey &= strItemID
                        '    intValue = strItemID
                        '    sortDic.Add(strKey, intValue)
                        'Catch ex As Exception
                        '    'pass duplicate record
                        'End Try
                        ''E1
                    Next
                Else
                    ReDim arrIdxList(dtbBibliographyS.Rows.Count)
                    ReDim arrIdxDispList(dtbBibliographyS.Rows.Count)
                    For j = 0 To dtbBibliographyS.Rows.Count - 1
                        strItemID = dtbBibliography.Rows(j).Item("ItemID")
                        'intPosition = objMisc.IdxPos.Item(CStr(strItemID))
                        intPosition = objBCommonStringProc.MiscIdxPos(arrDocID, CStr(strItemID))
                        strVal = Trim(dtbBibliographyS.Rows(j).Item("Val"))
                        arrIdxList(l) = strVal & Chr(9) & strPadLeft.PadLeft(intMaxLen - Len(intPosition), "0") & intPosition
                        strPadLeft = ""
                        arrIdxDispList(l) = strVal & Chr(9) & strPadLeft.PadLeft(intMaxLen - Len(intPosition), "0") & intPosition
                        arrIdxList(l) = objBCommonStringProc.ToUTF8(arrIdxList(l))
                        l = l + 1
                        ''B1
                        ''PhuongTT -  2014.11.19
                        'Try
                        '    strKey = ""
                        '    If Not IsNothing(arrIdxList(l - 1)) Then
                        '        strKey = Trim(arrIdxList(l - 1))
                        '    Else
                        '        'Neu gia tri rong thi sap xep nam o cuoi cung
                        '        strKey &= "z"
                        '    End If
                        '    strKey &= strItemID
                        '    intValue = strItemID
                        '    sortDic.Add(strKey, intValue)
                        'Catch ex As Exception
                        '    'pass duplicate record
                        'End Try
                        ''E1
                    Next
                End If

                '' '' ''objSort.SortBy(arrIdxDispList, arrIdxList, 1)
                '' '' ''For j = LBound(arrIdxList) To UBound(arrIdxList)
                '' '' ''arrIdxList(j) = objBCommonStringProc.ToUTF8(arrIdxList(j))
                '' '' ''Next
                'arrIdx = objSort.SortIndex(arrIdxList, 1)
                'Dim inti As Integer = 0
                'For Each kvp As KeyValuePair(Of String, Integer) In sortDic
                '    ReDim Preserve arrIdx(inti)
                '    arrIdx(inti) = kvp.Value
                '    inti += 1
                'Next
                arrIdx = objBCommonStringProc.SortIndexDictionary(arrIdxList, 1)

                Dim strCurVal As String = ""
                Dim strCurIdxGroupVal As String = ""
                Dim strIdxGroupVal As String = ""

                strOut = "<DL>"

                Dim strCurAVal As String
                Dim strIdxListValue As String
                Dim strCurAID As String

                For j = LBound(arrIdxList) To UBound(arrIdxList)
                    strIdxListValue = arrIdxDispList(arrIdx(j))
                    strCurAVal = Trim(Left(strIdxListValue, InStr(strIdxListValue, Chr(9)) - 1))
                    strCurAID = Right(strIdxListValue, Len(strIdxListValue) - InStr(strIdxListValue, Chr(9)))
                    'strIdxGroupVal = objBCommonStringProc.CutVietnameseAccent(objSort.Upper(objSort.Left(Trim(Left(arrIdxList(arrIdx(j)), InStr(arrIdxList(arrIdx(j)), Chr(9)) - 1)), 1)))
                    strIdxGroupVal = objBCommonStringProc.CutVietnameseAccent(Left(strIdxListValue, 1).ToUpper)
                    If Not strIdxGroupVal = strCurIdxGroupVal Then
                        strCurIdxGroupVal = strIdxGroupVal
                        strOut = strOut & "<DT><B>" & strCurIdxGroupVal & "</B>"
                    End If
                    If Not strCurAVal = "" Then
                        If Not strCurAVal.ToUpper = strCurVal Then
                            strCurVal = strCurAVal.ToUpper
                            strOut = strOut & "<DT><I>" & objBCommonStringProc.ConvertIt(strCurAVal) & "</I><DD>" & strCurAID
                        Else
                            strOut = strOut & ", " & strCurAID
                        End If
                    End If
                Next
                strOut = strOut & "</DL>"
            End If
            dtbBibliographyS = Nothing
            'objMisc = Nothing
            LoadData = strOut
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace