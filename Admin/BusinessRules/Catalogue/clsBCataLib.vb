Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBCataLib
        Inherits clsBBase
        Private objBComDBSys As New clsBCommonDBSystem
        Private objBString As New clsBCommonStringProc
        Private objBCatDicList As New clsBCatDicList
        'Private objUtf8 As New TVCOMLib.utf8

        Private strTitle As String = ""
        Private strPublisher As String = ""
        Private strAuthor As String = ""
        Private strClassNum As String = ""
        Private strKeyword As String = ""
        Private strLang As String = ""
        Private strItemType As String = ""
        Private strUser As String = ""
        Private strCreatedDateFrom As String = ""
        Private strCreatedDateTo As String = ""
        Private intIDFrom As Integer = -1
        Private intIDto As Integer = -1
        Private strSubject As String = ""
        Private strYr As String = ""
        Private strCallNum As String = ""
        Private lngMaxRecord As Long = 0

        Public abc As String

        ' Initialize method
        Public Sub Initialize()
            objBComDBSys.ConnectionString = strConnectionstring
            objBComDBSys.DBServer = strDBServer
            objBComDBSys.InterfaceLanguage = strInterfaceLanguage
            objBComDBSys.Initialize()

            objBString.InterfaceLanguage = strInterfaceLanguage
            objBString.ConnectionString = strConnectionstring
            objBString.DBServer = strDBServer
            objBString.Initialize()

            objBCatDicList.ConnectionString = strConnectionstring
            objBCatDicList.DBServer = strDBServer
            objBCatDicList.InterfaceLanguage = strInterfaceLanguage
            objBCatDicList.Initialize()
        End Sub

        ' FormingSQL method
        Public Function FormingSQL() As String
            Dim strLikeTitle As String
            Dim strClassTab As String
            Dim strSQL As String
            Dim strPrefix As String
            Dim strTAB As String
            Dim strTab1 As String
            Dim strTab2 As String
            Dim strTab3 As String
            Dim strTab4 As String
            Dim strTab5 As String
            Dim strTab6 As String
            Dim strTab7 As String
            Dim strTab8 As String
            Dim strTab9 As String
            Dim strEndYr As String
            Dim strStartYr As String

            ' process string
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    strTitle = objBString.ConvertItBack(strTitle)
                    strLikeTitle = objBString.ProcessVal(strTitle)
                    strPublisher = objBString.ConvertItBack(strPublisher)
                    strAuthor = objBString.ConvertItBack(strAuthor)
                    strClassNum = objBString.ConvertItBack(strClassNum)
                    strKeyword = objBString.ConvertItBack(strKeyword)
                    strLang = objBString.ConvertItBack(strLang)
                    strUser = objBString.ConvertItBack(strUser)
                    strSubject = objBString.ConvertItBack(strSubject)
                    strCallNum = objBString.ConvertItBack(strCallNum)
                Case "ORACLE"
                    strLikeTitle = objBString.ConvertItBack(strTitle)
                    strTitle = strLikeTitle
                    strPublisher = objBString.ConvertItBack(strPublisher)
                    strAuthor = objBString.ConvertItBack(strAuthor)
                    strClassNum = objBString.ConvertItBack(strClassNum)
                    strKeyword = objBString.ConvertItBack(strKeyword)
                    strLang = objBString.ConvertItBack(strLang)
                    strUser = objBString.ConvertItBack(strUser)
                    strSubject = objBString.ConvertItBack(strSubject)
                    strCallNum = objBString.ConvertItBack(strCallNum)
            End Select
            strTitle = Replace(strTitle, "%", "")
            If Not Left(strLikeTitle, 1) = "%" Then
                strLikeTitle = "$a" & strLikeTitle
            End If
            If lngMaxRecord = 0 Then
                lngMaxRecord = 5000
            End If
            If strClassNum <> "" Then
                ' Read system Parameter
                Dim ArrPara() As String = {"USED_CLASSIFICATION"}
                Dim arrRet()
                arrRet = objBComDBSys.GetSystemParameters(ArrPara)
                strClassTab = "DDC"
                If IsArray(arrRet) Then
                    If CInt(arrRet(0)) = 0 Then
                        strClassTab = "BBK"
                    End If
                End If
            End If
            If strItemType <> "" Or strCreatedDateFrom <> "" Or strCreatedDateTo <> "" Or strUser <> "" Then
                strPrefix = "Lib_tblItem"
                strTAB = "Lib_tblItem, "
            Else
                If strPublisher <> "" Then
                    strPrefix = "Lib_tblItemPublisher"
                ElseIf strAuthor <> "" Then
                    strPrefix = "Lib_tblItem_Author"
                ElseIf strKeyword <> "" Then
                    strPrefix = "Lib_tblItemKeyword"
                ElseIf strClassNum <> "" Then
                    strPrefix = "ITEM_" & strClassTab
                ElseIf strLang <> "" Then
                    strPrefix = "Lib_tblItemLanguage"
                ElseIf strSubject <> "" Then
                    strPrefix = "Lib_tblItemSH"
                ElseIf strYr <> "" Then
                    strPrefix = "CAT_DIC_YEAR"
                ElseIf strCallNum <> "" Then
                    strPrefix = "CopyNumber"
                ElseIf strTitle <> "" Then
                    strPrefix = "Lib_tblField200S"
                Else
                    strPrefix = "Lib_tblItem"
                    strTAB = "Lib_tblItem, "
                End If
            End If

            strSQL = ""
            If strTitle <> "" Then
                Select Case UCase(strDBserver)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND Lib_tblField200S.Content LIKE '" & strLikeTitle & "'"
                    Case "ORACLE"
                        strSQL = strSQL & " AND UPPER(Lib_tblField200S.Content) LIKE UPPER('" & strLikeTitle & "')"
                End Select
            Else
                strSQL = "1=1 "
            End If

            ' Work with ItemType
            If strItemType <> "" Then
                strSQL = strSQL & " AND Lib_tblItem.TypeID IN (" & strItemType & ")"
            End If

            ' Work with User
            If strUser <> "" Then
                strSQL = strSQL & " AND Lib_tblItem.Reviewer LIKE '" & strUser & "'"
            End If

            ' Work with strCreatedDateFrom
            If strCreatedDateFrom <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND CreatedDate >= CONVERT(datetime, '" & strCreatedDateFrom & "', 103)"
                    Case "ORACLE"
                        strSQL = strSQL & " AND CreatedDate >= To_Date('" & strCreatedDateFrom & "', 'dd/mm/yyyy')"
                End Select
            End If

            ' Work with strCreatedDateTo
            If strCreatedDateTo <> "" Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND CreatedDate <= CONVERT(datetime, '" & strCreatedDateTo & "', 103)"
                    Case "ORACLE"
                        strSQL = strSQL & " AND CreatedDate <= To_Date('" & strCreatedDateTo & "', 'dd/mm/yyyy')"
                End Select
            End If

            ' Work with Author
            If strAuthor <> "" Then
                strTab2 = "Lib_tblItem_Author, Cat_tblDicAuthor, "
                If strPrefix <> "Lib_tblItem_Author" Then
                    strSQL = strSQL & " AND Lib_tblItem_Author.ItemID = " & strPrefix & ".ItemID"
                End If
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID AND AccessEntry LIKE '" & objBString.ProcessVal(strAuthor) & "'"
                    Case "ORACLE"
                        strSQL = strSQL & " AND Lib_tblItem_Author.AuthorID = Cat_tblDicAuthor.ID AND UPPER(AccessEntry) LIKE UPPER('" & objBString.ProcessVal(strAuthor) & "')"
                End Select
            End If

            ' Work with BBK or DDC (Class Number)
            If strClassNum <> "" Then
                strTab3 = "CAT_DIC_CLASS_" & strClassTab & ", ITEM_" & strClassTab & ", "
                If Not strPrefix = "ITEM_" & strClassTab Then
                    strSQL = strSQL & " AND ITEM_" & strClassTab & ".ItemID = " & strPrefix & ".ItemID"
                End If
                Select Case UCase(strDBserver)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND CAT_DIC_CLASS_" & strClassTab & ".ID = ITEM_" & strClassTab & "." & strClassTab & "ID AND AccessEntry LIKE '" & strClassNum & "'"
                    Case "ORACLE"
                        strSQL = strSQL & " AND CAT_DIC_CLASS_" & strClassTab & ".ID = ITEM_" & strClassTab & "." & strClassTab & "ID AND UPPER(AccessEntry) LIKE UPPER('" & strClassNum & "')"
                End Select
            End If

            If strKeyword <> "" Then
                strTab4 = "Lib_tblItemKeyword, Cat_tblDicKeyword, "
                If strPrefix <> "Lib_tblItemKeyword" Then
                    SQL = SQL & " AND Lib_tblItemKeyword.ItemID = " & strPrefix & ".ItemID"
                End If
                Select Case UCase(strDBserver)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND Lib_tblItemKeyword.KeyWordID = Cat_tblDicKeyword.ID AND AccessEntry LIKE '" & strKeyword & "'"
                    Case "ORACLE"
                        strSQL = strSQL & " AND Lib_tblItemKeyword.KeyWordID = Cat_tblDicKeyword.ID AND UPPER(AccessEntry) LIKE UPPER('" & strKeyword & "')"
                End Select
            End If

            If strLang <> "" Then
                strTab5 = "Lib_tblItemLanguage, Cat_tblDic_Language, "
                If strPrefix <> "Lib_tblItemLanguage" Then
                    strSQL = strSQL & " AND Lib_tblItemLanguage.ItemID = " & strPrefix & ".ItemID"
                End If
                strSQL = strSQL & " AND Lib_tblItemLanguage.LanguageID = Cat_tblDic_Language.ID AND ISOCode = '" & strLang & "'"
            End If

            If strPublisher <> "" Then
                strTab6 = "Cat_tblDicPublisher, Lib_tblItemPublisher, "
                If strPrefix <> "Lib_tblItemPublisher" Then
                    strSQL = strSQL & " AND Lib_tblItemPublisher.ItemID = " & strPrefix & ".ItemID"
                End If
                Select Case UCase(strDBserver)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID AND AccessEntry LIKE '" & strPublisher & "'"
                    Case "ORACLE"
                        strSQL = strSQL & " AND Lib_tblItemPublisher.PublisherID = Cat_tblDicPublisher.ID AND UPPER(AccessEntry) LIKE UPPER('" & strPublisher & "')"
                End Select
            End If

            If strSubject <> "" Then
                strTab7 = "Lib_tblItemSH, CAT_DIC_SH, "
                If strPrefix <> "Lib_tblItemSH" Then
                    strSQL = strSQL & " AND Lib_tblItemSH.ItemID = " & strPrefix & ".ItemID"
                End If
                Select Case UCase(strDBserver)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND Lib_tblItemSH.SHID = CAT_DIC_SH.ID AND AccessEntry LIKE '" & strSubject & "'"
                    Case "ORACLE"
                        strSQL = strSQL & " AND Lib_tblItemSH.SHID = CAT_DIC_SH.ID AND UPPER(AccessEntry) LIKE UPPER('" & strSubject & "')"
                End Select
            End If

            If strYr <> "" Then
                strTab8 = "CAT_DIC_YEAR, "
                If strPrefix <> "CAT_DIC_YEAR" Then
                    strSQL = strSQL & " AND CAT_DIC_YEAR.ItemID = " & strPrefix & ".ItemID"
                End If
                If InStr(strYr, "-") = 0 Then
                    strSQL = strSQL & " AND CAT_DIC_YEAR LIKE '" & strYr & "'"
                Else
                    strStartYr = Trim(Left(strYr, InStr(strYr, "-") - 1))
                    strEndYr = Trim(Right(strYr, Len(strYr) - InStr(strYr, "-")))
                    If strStartYr <> "" Then
                        strSQL = strSQL & " AND Year >= '" & strStartYr & "'"
                    End If
                    If strEndYr <> "" Then
                        If Len(strStartYr) > Len(strEndYr) Then
                            strEndYr = Left(strStartYr, Len(strStartYr) - Len(strEndYr)) & strEndYr
                        End If
                        strSQL = strSQL & " AND YeaR <= '" & strEndYr & "'"
                    End If
                End If
            End If

            If strCallNum <> "" Then
                strTab9 = "Lib_tblHolding, "
                If strPrefix = "Lib_tblHolding" Then
                    strSQL = strSQL & " AND Lib_tblHolding.ItemID = " & strPrefix & ".ItemID"
                End If
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strSQL = strSQL & " AND CopyNumber LIKE '" & strCallNum & "'"
                    Case "ORACLE"
                        strSQL = strSQL & " AND UPPER(CopyNumber) LIKE UPPER('" & strCallNum & "')"
                End Select
            End If

            strTAB = strTAB & strTab1 & strTab2 & strTab3 & strTab4 & strTab5 & strTab6 & strTab7 & strTab8 & strTab9
            strTAB = Left(strTAB, Len(strTAB) - 2)
            If strTitle <> "" Then
                If strPrefix <> "Lib_tblField200S" Then
                    strPrefix = strPrefix & "."
                Else
                    strPrefix = ""
                End If
            Else
                strPrefix = strPrefix & "."
            End If

            If intIDFrom <> -1 Then
                strSQL = strSQL & " AND " & strPrefix & "ItemID >= " & intIDFrom
            End If
            If intIDto <> -1 Then
                strSQL = strSQL & " AND " & strPrefix & "ItemID <= " & intIDto
            End If
            If lngMaxRecord > 0 Then
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strSQL = "SELECT DISTINCT TOP " & lngMaxRecord & " " & strPrefix & "ItemID FROM " & strTAB & " WHERE " & strSQL & " ORDER BY " & strPrefix & "ItemID DESC"
                    Case "ORACLE"
                        strSQL = "SELECT DISTINCT " & strPrefix & "ItemID FROM " & strTAB & " WHERE " & strSQL & " AND ROWNUM <= " & lngMaxRecord & " ORDER BY " & strPrefix & "ItemID DESC"
                End Select
            ElseIf lngMaxRecord = -1 Then
                strSQL = "SELECT DISTINCT " & strPrefix & "ItemID FROM " & strTAB & " WHERE " & strSQL
            Else
                strSQL = "SELECT DISTINCT " & strPrefix & "ItemID FROM " & strTAB & " WHERE " & strSQL & " ORDER BY " & strPrefix & "ItemID DESC"
            End If
        End Function

        ' FormingDataSQL method
        Public Function FormingDataSQL(ByVal arrTags As Object, ByVal sqlstring As String) As String
            Dim strInit As String = ",001,900,907,911,912,925,926,927,id,leader,no,"
            Dim arrBlocks() As String = {"", "", "", "", "", "", "", "", "", "", ""}
            Dim intCount As Integer
            Dim intPos As Integer
            Dim strSQL As String

            For intCount = 0 To arrTags.Length - 1 'UBound(arrTags) - 1
                arrTags(intCount) = Trim(arrTags(intCount))
                If InStr(strInit, "," & arrTags(intCount) & ",") = 0 And IsNumeric(Left(arrTags(intCount), 3)) And (Len(arrTags(intCount)) = 3 Or (Len(arrTags(intCount)) = 5 And InStr(arrTags(intCount), "$") = 4)) Then
                    intPos = CInt(Left(arrTags(intCount), 1))
                    arrBlocks(intPos) = arrBlocks(intPos) & "'" & Left(arrTags(intCount), 3) & "', "
                End If
            Next
            strSQL = ""
            For intCount = 0 To arrBlocks.Length - 1 ' UBound(arrBlocks) - 1
                If arrBlocks(intCount) <> "" Then
                    strSQL = strSQL & " SELECT ID, ItemID, Content, FieldCode, Ind1 FROM Lib_tblField" & intCount & "00s, Lib_tblMARCBibField WHERE Lib_tblMARCBibField.FieldCode = Lib_tblField" & intCount & "00s.FieldCode AND Lib_tblMARCBibField.FieldCode IN (" & Left(arrBlocks(intCount), Len(arrBlocks(intCount)) - 2) & ") AND ItemID IN (" & sqlstring & ") UNION"
                End If
            Next
            If Not strSQL = "" Then
                strSQL = Left(strSQL, Len(strSQL) - 6) '& " ORDER BY ItemID, FieldCode, ITEM.ID"
            End If
            FormingDataSQL = strSQL
        End Function

        ' SortRecordIDs method
        Function SortRecordIDs(ByVal strOrderBy As String, ByVal strGroupBy As String, ByVal strSQLString As String) As Object
            Dim arrIndexRet As Object
            Dim arrOrderTags() As String
            Dim intPos As Integer
            Dim intGroupLen As Integer
            Dim intIndex As Integer
            Dim intCountSort As Integer
            Dim TblTmp As New DataTable
            Dim intCurItemID As Integer
            Dim arrDocID As Object
            Dim strSQLTmp As String

            ' analysis Orderby and groupby
            arrOrderTags = Split(strOrderBy, ",")
            If Trim(strGroupBy) <> "" Or Trim(strOrderBy) <> "" Then
                If strGroupBy <> "" Then
                    intPos = InStr(strGroupBy, ":")
                    intGroupLen = 0
                    ' check length groupby
                    If intPos > 0 Then
                        intGroupLen = CInt(Right(strGroupBy, Len(strGroupBy) - intPos))
                        strGroupBy = Left(strGroupBy, intPos - 1)
                    End If
                    If strOrderBy <> "" Then
                        intIndex = UBound(arrOrderTags)
                    Else
                        intIndex = -1
                    End If
                    ReDim Preserve arrOrderTags(intIndex + 1)
                    arrOrderTags(intIndex + 1) = strGroupBy
                End If
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strSQLTmp = Replace(FormingDataSQL(arrOrderTags, strSQLString), "SELECT ID, ItemID, Content, FieldCode", "SELECT DISTINCT ItemID,Lib_tblMARCBibField.FieldCode,Content,ind1,ind2")
                    Case Else
                        strSQLTmp = Replace(FormingDataSQL(arrOrderTags, strSQLString), "SELECT ID, ItemID, Content, FieldCode", "SELECT DISTINCT TOP 1000 ItemID,Lib_tblMARCBibField.FieldCode,Content,ind1,ind2")
                End Select
            Else
                strSQLTmp = strSQLString
            End If
            ' query to database
            objBComDBSys.SQLStatement = strSQLTmp
            'abc = strSQLTmp
            'Exit Function
            TblTmp = objBComDBSys.RetrieveItemInfor

            If Not TblTmp Is Nothing AndAlso TblTmp.Rows.Count > 0 Then
                intCurItemID = -2
                intIndex = 0
                Dim intCount As Integer = 0
                For intIndex = 0 To TblTmp.Rows.Count - 1
                    ' to filter distinct ItemID
                    If CLng(intCurItemID) <> CLng(TblTmp.Rows(intIndex).Item("ItemID")) Then
                        ReDim Preserve arrDocID(intCount)
                        arrDocID(intCount) = TblTmp.Rows(intIndex).Item("ItemID")
                        intCurItemID = TblTmp.Rows(intIndex).Item("ItemID")
                        intCount += 1
                    End If
                Next
                'start generate arrays to sort
                If Trim(strGroupBy) <> "" Or Trim(strOrderBy) <> "" Then
                    Dim arrSort As Object
                    Dim arrGroup() As String
                    ReDim arrSort(UBound(arrDocID))
                    ReDim arrGroup(UBound(arrDocID))
                    Dim SubRecords As Object
                    Dim strGroupSubFieldCode As String
                    Dim strOrderSubFieldCode As String
                    Dim strFilter As String
                    Dim RowFilter() As DataRow
                    Dim strContent As String
                    Dim strValSort As String
                    Dim strGrpVal As String
                    Dim strOrderTag As String

                    If strGroupBy <> "" Then
                        strGroupSubFieldCode = ""
                        ' find sub field if have
                        If InStr(strGroupBy, "$") > 0 Then
                            strGroupSubFieldCode = Right(strGroupBy, 2)
                            strGroupBy = Left(strGroupBy, 3)
                        End If
                    End If
                    For intIndex = 0 To arrDocID.Length - 1
                        ' generate array groupby
                        arrGroup(intIndex) = ""
                        If strGroupBy <> "" Then
                            ' execute filter to generate arrays group
                            If Not IsNumeric(arrDocID(intIndex)) Then
                                arrDocID(intIndex) = 0
                            End If
                            strFilter = "ItemID = " & arrDocID(intIndex) & " AND FieldCode = '" & strGroupBy & "'"
                            RowFilter = TblTmp.Select(strFilter)
                            If RowFilter.GetUpperBound(0) > -1 Then
                                strContent = RowFilter(0).Item("Content")
                                If strGroupSubFieldCode = "" Then
                                    strContent = objBString.TrimSubFieldCodes(strContent)
                                Else
                                    objBString.ParseField(strGroupSubFieldCode, strContent, " ", SubRecords)
                                    strContent = objBString.GEntryTrim(SubRecords(0))
                                End If
                                strGrpVal = ""
                                While (InStr(strContent, "(") > 0)
                                    strGrpVal = Left(strContent, InStr(strContent, "(") - 1)
                                    strContent = Right(strContent, Len(strContent) - InStr(strContent, "("))
                                    If InStr(strContent, ")") > 0 Then
                                        strGrpVal = strGrpVal & Right(strContent, Len(strContent) - InStr(strContent, ")"))
                                    Else
                                        strGrpVal = strGrpVal & strContent
                                    End If
                                    strContent = strGrpVal
                                End While
                                arrGroup(intIndex) = strContent
                            End If
                        End If
                        ' generate array sortby
                        arrSort(intIndex) = ""
                        For intCountSort = 0 To UBound(arrOrderTags) - 1
                            strValSort = ""
                            strOrderSubFieldCode = ""
                            If InStr(arrOrderTags(intCountSort), "$") > 0 Then
                                strOrderSubFieldCode = Right(arrOrderTags(intCountSort), 2)
                                strOrderTag = Left(arrOrderTags(intCountSort), 3)
                            Else
                                strOrderTag = arrOrderTags(intCountSort)
                            End If
                            strFilter = "ItemID = " & arrDocID(intIndex) & " AND FieldCode = '" & strOrderTag & "'"
                            RowFilter = TblTmp.Select(strFilter)
                            If RowFilter.GetUpperBound(0) > -1 Then
                                strContent = RowFilter(0).Item("Content")
                                If strOrderSubFieldCode = "" Then
                                    strValSort = Trim(objBString.TheSortOne(objBString.TrimSubFieldCodes(strContent)))
                                Else
                                    Call objBString.ParseField(strOrderSubFieldCode, strContent, " ", SubRecords)
                                    strValSort = Trim(objBString.TheSortOne(SubRecords(0)))
                                End If
                                If RowFilter(0).Item("FieldCode") = "245" Then
                                    If IsNumeric(RowFilter(0).Item("ind2") & "") Then
                                        strValSort = Right(strValSort, Len(strValSort) - CStr(RowFilter(0).Item("ind2")))
                                    End If
                                End If
                            End If
                            If arrSort(intIndex) <> "" Then
                                arrSort(intIndex) = arrSort(intIndex) & Chr(9) & strValSort
                            Else
                                arrSort(intIndex) = strValSort
                            End If
                        Next intCountSort
                    Next intIndex
                    For intIndex = 0 To arrSort.Length - 1
                        If intGroupLen > 0 Then
                            arrGroup(intIndex) = Left(arrGroup(intIndex), intGroupLen)
                            arrSort(intIndex) = arrGroup(intIndex) & Chr(9) & arrSort(intIndex)
                        Else
                            arrSort(intIndex) = arrGroup(intIndex) & Chr(9) & arrSort(intIndex)
                        End If
                        arrSort(intIndex) = Trim(objBString.ToUTF8(arrSort(intIndex)))
                    Next intIndex
                    'Execute sort by TVCom
                    'arrIndexRet = objUtf8.SortIndex(arrSort, 1)
                    arrIndexRet = objBString.SortIndexDictionary(arrSort, 1)
                    arrDocID = objBComDBSys.SortByIndex(arrDocID, arrIndexRet)
                End If
            Else
                ReDim arrDocID(0)
                arrDocID(0) = "empty"
            End If
            Return arrDocID

        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBComDBSys Is Nothing Then
                    objBComDBSys.Dispose(True)
                    objBComDBSys = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
                If Not objBCatDicList Is Nothing Then
                    objBCatDicList.Dispose(True)
                    objBCatDicList = Nothing
                End If
                'If Not objUtf8 Is Nothing Then
                '    objUtf8 = Nothing
                'End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace