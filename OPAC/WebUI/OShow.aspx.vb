Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports System.Text.RegularExpressions
Imports System.Linq
Imports System.Data

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OShow
        Inherits clsWBaseJqueryUI

        Private objBFilterBrowse As New clsBOPACFilterBrowse
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBSearchQr As New clsBOPACSearchQuery
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBOpacItem As New clsBOPACItem
        Private fTop As Integer = 1000000
        'Private fCutContentLength As Integer = 77 '<span style=""background-color:#60a917 !important;color:white;""><I> </I></span>"
        Private fCutContentLength As Integer = 36 '<span class=""hightlight-text""></span>"
        Private strBeginBoldTag As String = "<b>"
        Private strEndBoldTag As String = ":&nbsp;</b>"
        Private strDDCIds As String = ""
        Public strTextHolder As String = ""

        Private Sub GenStringTitleAndTextHolderByDicID(ByVal strOrderby As String)
            Select Case strOrderby
                Case "TITLE"
                    strTextHolder = "Nhập tên tài liệu cần tìm trong tập kết quả bên dưới"
                Case "AUTHOR"
                    strTextHolder = "Nhập tên tác giả cần tìm trong tập kết quả bên dưới"
                Case "YEAR"
                    strTextHolder = "Nhập năm xuất bản cần tìm trong tập kết quả bên dưới"
                Case "PUBLISH"
                    strTextHolder = "Nhập nhà xuất bản cần tìm trong tập kết quả bên dưới"
                Case Else
                    strTextHolder = "Nhập thông tin cần tìm trong tập kết quả bên dưới"
            End Select
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            Call getMyListItems()
            If Not Page.IsPostBack Then
                Dim bolSearchAdvanced As Boolean = False
                If Not IsNothing(Request("searchAdvanced")) Then
                    bolSearchAdvanced = True
                End If

                Call resetObject(bolSearchAdvanced)
                'Call GenStringTitleAndTextHolderByDicID(clsSession.GlbOrderBy)
                Call getItems()
                Call filterInBrowse(clsSession.GlbFilterConditionString, clsSession.GlbSQLStatement)
                Call BindData(clsSession.GlbSQLStatementFilter, clsSession.GlbBrowseFilter)
                'Call BindData(clsSession.GlbSQLStatement)
            End If
        End Sub

        ' Init getItems
        ' purpose get iTems and into session
        Private Sub getItems()
            Try
                Dim strBrowseId As String = ""
                If Not IsNothing(Request("BrowseId")) AndAlso Request("BrowseId") <> "" Then
                    strBrowseId = Request("BrowseId")
                End If
                Dim intDicID As Integer = 0
                If Not IsNothing(Request("DicID")) AndAlso Request("DicID") <> "" Then
                    intDicID = Request("DicID")
                End If
                Dim strSearch As String = ""
                Dim bolEbookSearch As Boolean = False
                'Dim bolBack As Boolean = False
                If strBrowseId <> "" Then 'Nhan gia tri tu browse
                    'objBFilterBrowse.DicID = intDicID
                    'objBFilterBrowse.Ids = strBrowseId
                    'clsSession.GlbIds = objBFilterBrowse.GetItemIdsFromBrowse()
                    objBSearchQr.Top = fTop
                    objBSearchQr.SortBy = clsSession.GlbOrderBy
                    clsSession.GlbSQLStatement = objBSearchQr.getSQLSearchByBrowseID(intDicID, strBrowseId, clsSession.GlbSite)
                ElseIf Not IsNothing(Request("FormatType")) Then 'Nhan gia tri tim kiem loai tai lieu dien tu: ebooks, audio book, audio, media
                    strSearch = Request("FormatType").Trim
                    Call onSearch(strSearch, False)
                ElseIf Not IsNothing(Request("txtSearch")) Then 'Nhan gia tri tim kiem tu header
                    strSearch = Request("txtSearch").Trim
                    strSearch = objBCommonStringProc.ProcessVal(strSearch)
                    strSearch = Replace(strSearch, "'", "''")

                    hidSearch.Value = strSearch
                    Dim intItemTypeId As Integer = 0
                    If Not IsNothing(Request("rdSearchOption")) AndAlso Request("rdSearchOption") = -4 Then 'eBook - Fulltext search
                        bolEbookSearch = True
                        hidSearchEbooks.Value = strSearch
                    Else
                        intItemTypeId = Request("rdSearchOption")
                        hidSearch.Value = strSearch
                        'clsSession.GlbFilterConditionStringInResult &= strSearch & ";"
                    End If

                    Dim typeSearch As Integer = 0
                    If Not IsNothing(Request("TypeSearch")) Then
                        typeSearch = CType(Request("TypeSearch"), Integer)
                        hidSearchType.Value = typeSearch
                    Else
                        If Not IsNothing(Request("DicID")) Then
                            typeSearch = CType(Request("DicID"), Integer)
                            hidSearchType.Value = typeSearch
                        End If
                    End If

                    strSearch = getCutVietnameseAccent(strSearch)
                    Call onSearch(strSearch, True, bolEbookSearch, intItemTypeId)

                    clsSession.GlbSearchFullText = True
                ElseIf Not IsNothing(Request("NoFilter")) Then 'Bo loc trong tap ket qua tra ve
                    'clsSession.GlbIds = clsSession.GlbIdsForStore
                    clsSession.GlbSQLStatement = clsSession.GlbSQLStatementForStore
                    'ElseIf Not IsNothing(Request("back")) Then 'Bo loc trong tap ket qua tra ve
                    '    bolBack = True
                Else
                    If clsSession.GlbSQLStatement = "" Then
                        clsSession.GlbSQLStatement = clsSession.GlbSQLStatementForStore
                    End If
                End If
                'If Not IsNothing(clsSession.GlbIds) Then
                '    clsSession.GlbIdsForStore = clsSession.GlbIds
                'End If
                If clsSession.GlbSQLStatement <> "" Then
                    clsSession.GlbSQLStatementForStore = clsSession.GlbSQLStatement
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function getCutVietnameseAccent(ByVal strSearch As String) As String
            Dim strResult As String = ""
            Try
                strResult = objBCommonStringProc.CutVietnameseAccent(strSearch)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' Init onSearch
        ' purpose search fulltext
        Private Sub onSearch(ByVal strSearch As String, Optional ByVal bolSearchFulltext As Boolean = True, Optional ByVal bolEbookSearch As Boolean = False, Optional ByVal intItemTypeId As Integer = 0)
            Dim arrValue() As String
            Dim arrName() As String
            Dim arrBool() As String
            Dim intCount As Integer
            Dim colData As New Collection

            intCount = 0
            If strSearch <> "" Then
                If bolEbookSearch Then
                    objBSearchQr.Top = fTop
                    clsSession.GlbSQLStatement = objBSearchQr.FormingEbooksSearch(strSearch)
                Else
                    ReDim Preserve arrValue(intCount)
                    ReDim Preserve arrName(intCount)
                    ReDim Preserve arrBool(intCount)

                    If bolSearchFulltext Then
                        'arrValue(intCount) = "%" & strSearch & "%"
                        arrValue(intCount) = """" & strSearch & """"
                        arrName(intCount) = ConvertTypeSearchToSearchBy(Integer.Parse(hidSearchType.Value))
                        arrBool(intCount) = "AND"
                    Else
                        arrValue(intCount) = strSearch
                        arrName(intCount) = "formattype"
                        arrBool(intCount) = "AND"
                    End If

                    intCount = intCount + 1

                    If Not IsNothing(clsSession.GlbSite) AndAlso clsSession.GlbSite <> 0 Then
                        ReDim Preserve arrValue(intCount)
                        ReDim Preserve arrName(intCount)
                        ReDim Preserve arrBool(intCount)
                        arrValue(intCount) = clsSession.GlbSite
                        arrName(intCount) = "LibraryType"
                        arrBool(intCount) = "AND"
                        intCount = intCount + 1
                        colData.Add(clsSession.GlbSite, "LibraryType")
                    End If

                    If intItemTypeId > 0 Then
                        ReDim Preserve arrValue(intCount)
                        ReDim Preserve arrName(intCount)
                        ReDim Preserve arrBool(intCount)
                        arrValue(intCount) = intItemTypeId
                        arrName(intCount) = "itemtype"
                        arrBool(intCount) = "AND"
                        intCount = intCount + 1
                        colData.Add(intItemTypeId, "itemtype")
                    End If

                    colData.Add("", "SortBy")

                    objBSearchQr.SortBy = clsSession.GlbOrderBy
                    objBSearchQr.NameArray = arrName
                    objBSearchQr.ValueArray = arrValue
                    objBSearchQr.BoolArray = arrBool
                    objBSearchQr.SearchMode = "ADVANCE"
                    colData.Add("ADVANCE", "SearchMode")
                    'If optISBD.Checked Then
                    '    colData.Add("ISBD", "Display")
                    'Else

                    'End If
                    colData.Add("Simple", "Display")

                    Session("colSearch") = colData
                    'clsSession.GlbIds = objBSearchQr.ExecuteQueryOPAC()
                    objBSearchQr.Top = fTop
                    clsSession.GlbSQLStatement = objBSearchQr.FormingSQL
                End If
            End If
        End Sub

        Private Function ConvertTypeSearchToSearchBy(ByVal intTypeSearch As Integer) As String
            '13: Nhan De | 1: Tac gia | 9: Nam san xuat | 2: Nha xuat ban |3: Tu Khoa | 10: Dang Tai Lieu : 11 : Tai Lieu Dien Tu
            Select Case intTypeSearch
                Case 13
                    Return "title"
                Case 1
                    Return "author"
                Case 9
                    Return "publishyear"
                Case 2
                    Return "publisher"
                Case 3
                    Return "keyword"
                Case 10
                    Return "itemtype"
                Case 11
                    Return "tabofcontents"
                Case Else
                    Return "fulltext"
            End Select
        End Function

        ' Init onSearch
        ' purpose search fulltext
        Private Sub onSearchDeleteInResult(ByVal strSearch As String, ByVal strFilter As String, Optional ByVal bolSearchFulltext As Boolean = True)
            Try
                Dim arrValue() As String
                Dim arrName() As String
                Dim arrBool() As String
                Dim intCount As Integer
                Dim colData As New Collection

                Dim strSearchArr() As String = Split(strSearch, ";")
                intCount = 0
                If clsSession.GlbSQLStatement <> "" AndAlso strSearchArr(0) <> "" Then
                    ReDim Preserve arrValue(intCount)
                    ReDim Preserve arrName(intCount)
                    ReDim Preserve arrBool(intCount)
                    Dim strSearchAll As String = ""
                    Dim strSearchAllTemp As String = ""
                    For i As Integer = 0 To UBound(strSearchArr)
                        If strSearchArr(i).Trim <> "" Then
                            strSearchAll &= """" & strSearchArr(i).Trim & """ AND "
                            strSearchAllTemp &= strSearchArr(i).Trim & ";"
                            If getCutVietnameseAccent(strSearchArr(i)).Trim = strFilter.Trim Then
                                clsSession.GlbFilterConditionStringInResult = strSearchAllTemp
                                Exit For
                            End If
                        End If
                    Next

                    If strSearchAll <> "" Then
                        strSearchAll = Left(strSearchAll, Len(strSearchAll) - 5)
                    End If
                    strSearchAll = getCutVietnameseAccent(strSearchAll)

                    arrValue(intCount) = strSearchAll
                    arrName(intCount) = ConvertTypeSearchToSearchBy(Integer.Parse(hidSearchType.Value))
                    arrBool(intCount) = "AND"

                    colData.Add("", "SortBy")
                    If Not clsSession.GlbSearchFullText Then
                        objBSearchQr.ItemIDs = objBSearchQr.getFormingSQLForID(clsSession.GlbSQLStatement) 'objBCommonStringProc.getiTemString(clsSession.GlbIds)
                    End If
                    objBSearchQr.SortBy = clsSession.GlbOrderBy
                    objBSearchQr.NameArray = arrName
                    objBSearchQr.ValueArray = arrValue
                    objBSearchQr.BoolArray = arrBool
                    objBSearchQr.SearchMode = "ADVANCE"
                    colData.Add("ADVANCE", "SearchMode")
                    'If optISBD.Checked Then
                    '    colData.Add("ISBD", "Display")
                    'Else

                    'End If
                    colData.Add("Simple", "Display")

                    Session("colSearch") = colData
                    'clsSession.GlbIdsInResult = objBSearchQr.ExecuteQueryOPAC()
                    'clsSession.GlbIds = objBSearchQr.ExecuteQueryOPAC()
                    objBSearchQr.Top = fTop
                    clsSession.GlbSQLStatement = objBSearchQr.FormingSQL
                End If
            Catch ex As Exception
            End Try
        End Sub


        ' Init onSearch
        ' purpose search fulltext
        Private Sub onSearchInResult(ByVal strSearch As String, Optional ByVal bolSearchFulltext As Boolean = True)
            Try
                Dim arrValue() As String
                Dim arrName() As String
                Dim arrBool() As String
                Dim intCount As Integer
                Dim colData As New Collection

                Dim strSearchArr() As String = Split(strSearch, ";")
                intCount = 0
                If clsSession.GlbSQLStatement <> "" AndAlso strSearchArr(0) <> "" Then
                    ReDim Preserve arrValue(intCount)
                    ReDim Preserve arrName(intCount)
                    ReDim Preserve arrBool(intCount)
                    Dim strSearchAll As String = ""
                    For i As Integer = 0 To UBound(strSearchArr)
                        'If strSearchArr(i).Trim <> "" Then
                        '    ReDim Preserve arrValue(intCount)
                        '    ReDim Preserve arrName(intCount)
                        '    ReDim Preserve arrBool(intCount)
                        '    If bolSearchFulltext Then
                        '        arrValue(intCount) = "%" & strSearchArr(i).Trim & "%"
                        '        arrName(intCount) = "fulltext"
                        '        arrBool(intCount) = "AND"
                        '    Else
                        '        arrValue(intCount) = strSearchArr(i).Trim
                        '        arrName(intCount) = "formattype"
                        '        arrBool(intCount) = "AND"
                        '    End If
                        '    intCount = intCount + 1
                        'End If
                        If strSearchArr(i).Trim <> "" Then
                            strSearchAll &= """" & strSearchArr(i).Trim & """ AND "
                        End If
                    Next

                    If strSearchAll <> "" Then
                        strSearchAll = Left(strSearchAll, Len(strSearchAll) - 5)
                    End If
                    arrValue(intCount) = strSearchAll
                    arrName(intCount) = ConvertTypeSearchToSearchBy(Integer.Parse(hidSearchType.Value))
                    arrBool(intCount) = "AND"

                    colData.Add("", "SortBy")
                    If Not clsSession.GlbSearchFullText Then
                        objBSearchQr.ItemIDs = objBSearchQr.getFormingSQLForID(clsSession.GlbSQLStatement) 'objBCommonStringProc.getiTemString(clsSession.GlbIds)
                    End If
                    objBSearchQr.SortBy = clsSession.GlbOrderBy
                    objBSearchQr.NameArray = arrName
                    objBSearchQr.ValueArray = arrValue
                    objBSearchQr.BoolArray = arrBool
                    objBSearchQr.SearchMode = "ADVANCE"
                    colData.Add("ADVANCE", "SearchMode")
                    'If optISBD.Checked Then
                    '    colData.Add("ISBD", "Display")
                    'Else

                    'End If
                    colData.Add("Simple", "Display")

                    Session("colSearch") = colData
                    'clsSession.GlbIdsInResult = objBSearchQr.ExecuteQueryOPAC()
                    'clsSession.GlbIds = objBSearchQr.ExecuteQueryOPAC()
                    objBSearchQr.Top = fTop
                    clsSession.GlbSQLStatement = objBSearchQr.FormingSQL
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()

            ' Init objBHoldingInfo object
            objBFilterBrowse.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBFilterBrowse.DBServer = Session("DBServer")
            objBFilterBrowse.ConnectionString = Session("ConnectionString")
            Call objBFilterBrowse.Initialize()

            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            ' init objBSearchQr object
            objBSearchQr.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchQr.DBServer = Session("DBServer")
            objBSearchQr.ConnectionString = Session("ConnectionString")
            objBSearchQr.Initialize()

            ' init objBSearchResult object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

            ' init objBOpacItem object
            objBOpacItem.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOpacItem.DBServer = Session("DBServer")
            objBOpacItem.ConnectionString = Session("ConnectionString")
            objBOpacItem.Initialize()

            If Session("SecuredOPAC") & "" <> "" Then
                objBSearchQr.SecuredOPAC = True
            Else
                objBSearchQr.SecuredOPAC = False
            End If

            If clsSession.GlbUserLevel & "" <> "" Then
                objBSearchQr.AccessLevel = clsSession.GlbUserLevel
            End If
        End Sub

        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/OShow.js'></script>")
        End Sub


        ' BindScript method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub resetObject(Optional ByVal bolSearchAdvances As Boolean = False)
            'Session for browse
            Call resetFilter()
            'Session for search in result
            clsSession.GlbFilterConditionStringInResult = ""
            'clsSession.GlbIdsInResult = Nothing
            clsSession.GlbSearchFullText = False

            clsSession.GlbOrderBy = "TITLE"

            'Session Ids
            If Not bolSearchAdvances Then
                'clsSession.GlbIds = Nothing
                clsSession.GlbSQLStatement = ""
            End If

            'Hien thi thong tin cac truong (noi luu tru bieu ghi tai lieu)
            If Not IsNothing(Request("MutiLibrary")) Then
                hidMutiLibrary.Value = Request("MutiLibrary")
            End If
        End Sub

        ' resetFilter method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub resetFilter(Optional ByVal bolSearchAdvances As Boolean = False)
            'Session for browse
            clsSession.GlbFilterConditionString = ""
            clsSession.GlbFilterConditionValue = ""
            'clsSession.GlbFilterIds = Nothing
            clsSession.GlbSQLStatementFilter = ""
            ltrBreadcrumbsFilter.Text = ""
        End Sub

        ' filterInBrowse method
        ' Purpose: filter information for browse
        Private Sub filterInBrowse(ByVal strFilterCondition As String, ByVal strIds As String)
            Try
                If (clsSession.GlbOrderBy <> "") Then
                    objBSearchQr.SortBy = clsSession.GlbOrderBy
                End If
                strIds = objBSearchQr.getFormingSQLForID(strIds)
                Dim strSQL As String = objBSearchQr.FormingFilterSQL(strFilterCondition, strIds)
                'clsSession.GlbFilterIds = objBSearchQr.eExecuteQuerySQL(strSQL)
                clsSession.GlbSQLStatementFilter = strSQL
            Catch ex As Exception
            End Try
        End Sub

        Private Sub genBreadcrumbsFilter(ByVal strFilterCondition As String, ByVal strFilterConditionValue As String, Optional ByVal strDelimiter1 As String = ",", Optional ByVal strDelimiter2 As String = "-")
            Try
                Dim strResults As String = ""
                Dim strArray1() As String
                Dim strArray2() As String
                Dim strArray3() As String
                strArray1 = Split(strFilterCondition, strDelimiter1)
                strArray3 = Split(strFilterConditionValue, strDelimiter1)
                Dim strFilter As String = ""
                For i As Integer = 0 To UBound(strArray1)
                    strFilter = ""
                    strArray2 = Split(strArray1(i), strDelimiter2)
                    If UBound(strArray2) = 1 Then
                        strArray3(i) = Replace(strArray3(i), strArray1(i), "")
                        Select Case strArray2(0)
                            Case 1 'Author
                                strFilter &= spAuthor.InnerText & ":" & strArray3(i)
                            Case 2 'Publisher
                                strFilter &= spPublisher.InnerText & ":" & strArray3(i)
                            Case 3 'keyWord
                                strFilter &= spKeyWord.InnerText & ":" & strArray3(i)
                            'Case 4 'Series
                            '    strFilter &= spSeries.InnerText & ":" & strArray3(i)
                            Case 5 'SubjectHeading
                                strFilter &= spSubjectheading.InnerText & ":" & strArray3(i)
                            Case 6 'Language
                                strFilter &= spLanguage.InnerText & ":" & strArray3(i)
                            Case 7 'NLM
                                strFilter &= spNLM.InnerText & ":" & strArray3(i)
                            Case 8 'DDC
                                strFilter &= spDDC.InnerText & ":" & strArray3(i)
                            Case 9 'publisher year
                                strFilter &= spPublisherYear.InnerText & ":" & strArray3(i)
                            Case 10 'Item Type
                                strFilter &= spItemType.InnerText & ":" & strArray3(i)
                            Case 11 'Electronic data
                                strFilter &= spElectronicData.InnerText & ":" & strArray3(i)
                            Case 12 'Electronic data
                                strFilter &= spCatalogy.InnerText & ":" & strArray3(i)
                        End Select
                        strResults &= "<span>" & strFilter & "</span>&nbsp;"
                        strResults &= "<span style='cursor:pointer;' class='mif-cancel mif-lg fg-red' onclick=""filterObject(" & strArray2(0) & ",'" & strArray3(i) & "'," & strArray2(1) & ",0)"" data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white' data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                        'strResults &= "<span class='item-title-secondary'>&nbsp;;&nbsp;</span>"
                        strResults &= "; "
                    End If
                Next
                strResults = strResults.Trim
                If Not strResults = "" Then
                    strResults = strResults.Substring(0, strResults.Length - 1)
                    strResults = spFilter.InnerText & "<b>" & strResults & "</b>"
                End If
                ltrBreadcrumbsFilter.Text = strResults
            Catch ex As Exception
            End Try
        End Sub

        ' BindData method
        ' Purpose: set information for browse
        Private Sub BindData(ByVal SQLStatement As String, Optional ByVal strBrowseFilter As String = "")
            If (clsSession.GlbOrderBy <> "") Then
                objBSearchQr.SortBy = clsSession.GlbOrderBy
            End If
            Try
                'ltrDDC.Text = ""
                If SQLStatement <> "" Then
                    Dim strIds As String = objBSearchQr.getFormingSQLForID(SQLStatement) ' SQLStatement 'objBCommonStringProc.getiTemString(dtIds)
                    Dim strResult As String = ""
                    If strBrowseFilter <> "" Then
                        strResult = strBrowseFilter
                    Else
                        Dim DicID As Integer = 0
                        Dim tblTemp As DataView

                        DicID = 10 'Item Type
                        objBFilterBrowse.Ids = strIds
                        tblTemp = objBFilterBrowse.GetFilterBrowseByMerge(clsSession.GlbTopTopics)
                        If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                            DicID = 10
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spItemType.InnerText, tblTemp)
                            End If
                            DicID = 11
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spElectronicData.InnerText, tblTemp)
                            End If
                            DicID = 1
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spAuthor.InnerText, tblTemp)
                            End If
                            DicID = 3
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spKeyWord.InnerText, tblTemp)
                            End If
                            DicID = 5
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spSubjectheading.InnerText, tblTemp)
                            End If
                            DicID = 9
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "DisplayEntry desc"
                                strResult &= getDictionaryString(DicID, spPublisherYear.InnerText, tblTemp)
                            End If
                            DicID = 2
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spPublisher.InnerText, tblTemp)
                            End If
                            DicID = 7
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spNLM.InnerText, tblTemp)
                            End If
                            DicID = 8
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spDDC.InnerText, tblTemp)
                            End If
                            'DicID = 4
                            'tblTemp.RowFilter = "Type = " & DicID
                            'If tblTemp.Count > 0 Then
                            '    tblTemp.Sort = "NumberNo desc"
                            '    strResult &= getDictionaryString(DicID, spSeries.InnerText, tblTemp)
                            'End If
                            DicID = 6
                            tblTemp.RowFilter = "Type = " & DicID
                            If tblTemp.Count > 0 Then
                                tblTemp.Sort = "NumberNo desc"
                                strResult &= getDictionaryString(DicID, spLanguage.InnerText, tblTemp)
                            End If
                        End If


                        'DicID = 10 'Item Type
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("NumberNo", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spItemType.InnerText, tblTemp)
                        'End If

                        'Treeview DDC
                        If clsSession.GlbClassification = 8 And 1 > 2 Then '8:DDC, 7:NLM
                            Dim dt As New DataTable
                            objBFilterBrowse.Ids = strIds
                            dt = objBFilterBrowse.GetTreeviewDDC()
                            If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                                ltrDDC.Text = getTriewviewDDC(dt) 'getDDC(dt)
                            Else
                                ltrDDC.Text = ""
                            End If
                        End If


                        'DicID = 11 'Electronic Data
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("NumberNo", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spElectronicData.InnerText, tblTemp)
                        'End If

                        'DicID = 1 'Author
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("NumberNo", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spAuthor.InnerText, tblTemp)
                        'End If

                        'DicID = 3 'KeyWord
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("DisplayEntry", "ASC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spKeyWord.InnerText, tblTemp)
                        'End If

                        'DicID = 5 'Subjectheading
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("DisplayEntry", "ASC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spSubjectheading.InnerText, tblTemp)
                        'End If

                        'DicID = 9 'publisher year
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("DisplayEntry", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spPublisherYear.InnerText, tblTemp)
                        'End If

                        'DicID = 2 'publisher
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("NumberNo", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spPublisher.InnerText, tblTemp)
                        'End If

                        'DicID = 7 'NLM
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("NumberNo", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spNLM.InnerText, tblTemp)
                        'End If

                        'DicID = 8 'DDC
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("DisplayEntry", "ASC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spDDC.InnerText, tblTemp)
                        'End If

                        'DicID = 4 'Series
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("NumberNo", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spSeries.InnerText, tblTemp)
                        'End If

                        'DicID = 6 'Language
                        'objBFilterBrowse.DicID = DicID
                        'objBFilterBrowse.Ids = strIds
                        'tblTemp = objBFilterBrowse.GetFilterBrowse("NumberNo", "DESC", clsSession.GlbTopTopics)
                        'If Not tblTemp Is Nothing AndAlso tblTemp.Count > 0 Then
                        '    strResult &= getDictionaryString(DicID, spLanguage.InnerText, tblTemp)
                        'End If

                        'clsSession.GlbBrowseFilter = strResult
                    End If

                    ltrList.Text = strResult

                    Dim dtTemp As DataTable = Nothing
                    strIds = SQLStatement
                    'objBSearchQr.SortBy = "TITLE"
                    dtTemp = objBSearchQr.eExecuteQuerySQL(SQLStatement)
                    If Not IsNothing(dtTemp) AndAlso dtTemp.Rows.Count > 0 Then
                        Call processBooks(dtTemp)
                        divSearchInResult.Visible = True
                        lrtPagination1.Visible = True
                        lrtPagination2.Visible = True
                        divOrderBy.Visible = True
                    Else
                        ltrList.Text = ""
                        ltrBookList.Text = spInfoNotFound.InnerText
                        divSearchInResult.Visible = False
                        lrtPagination1.Visible = False
                        lrtPagination2.Visible = False
                        divOrderBy.Visible = False
                    End If
                Else
                    ltrList.Text = ""
                    ltrBookList.Text = spInfoNotFound.InnerText
                    divSearchInResult.Visible = False
                    lrtPagination1.Visible = False
                    lrtPagination2.Visible = False
                    divOrderBy.Visible = False
                End If
                Call showBreadcrumbsInResult(clsSession.GlbFilterConditionStringInResult)
            Catch ex As Exception
            End Try
        End Sub

        ' getDictionaryString method
        ' Purpose: get objects string to into browse
        Private Function getDictionaryString(ByVal dicId As Integer, ByVal dicName As String, ByVal dv As DataView) As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = 0
                Dim iMax As Integer = clsSession.GlbTopTopics
                Dim strShowDiv As String = "divShow" & dicId
                Dim strHiddenDiv As String = "divHidden" & dicId
                Dim strDiv As String = "divBrowse" & dicId
                Dim strFilter As String = dicId & "spFilterDelete"
                Dim strFilterDelete As String = ""

                'strResult &= "<div>"
                'strResult &= "<h4>" & dicName & "</h4>"
                'strResult &= "<div class='listview-outlook' data-role='listview'>"
                strResult &= "<h1 class='head-title'><span>" & dicName & "</span></h1>"
                strResult &= "<ul class='sub-menu-list'>"
                Dim bolFilter As Boolean = False
                For Each rv As DataRowView In dv
                    bolFilter = checkFilter(dicId, rv("ID"))
                    strFilterDelete = strFilter & rv("ID")
                    strResult &= "<li>"
                    If Not bolFilter Then
                        strResult &= "<a onclick=""filterObject(" & dicId & ",'" & rv("DisplayEntry") & "','" & rv("ID") & "',1)"" style=""cursor:pointer;"">"
                    Else
                        strResult &= "<a style=""cursor:default;"">"
                    End If

                    ''strResult &= "<div class='list-content'>" 'list-title
                    'strResult &= "<span title='" & rv("DisplayEntry") & " (" & FormatNumber(rv("NumberNo"), 0) & ")" & "'>"
                    'If bolFilter Then
                    '    strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='" & strFilterDelete & "' onclick=""filterObject(" & dicId & ",'" & rv("DisplayEntry") & "'," & rv("ID") & ",0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top' style=""cursor:pointer;margin-top:-5px;""></span>"
                    'End If
                    strResult &= "<span data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white' data-hint='" & rv("DisplayEntry") & " (" & FormatNumber(rv("NumberNo"), 0) & ")" & "'>"

                    If dicId = 11 Then 'Edata
                        Dim strIcon As String = ""
                        Select Case CInt(rv("ID"))
                            Case clsUICommon.gFileType.ePicture
                                strIcon = "<span class='mif-images fg-emerald'></span>"
                            Case clsUICommon.gFileType.eMedia
                                strIcon = "<span class='mif-film fg-emerald'></span>"
                            Case clsUICommon.gFileType.eSound
                                strIcon = "<span class='mif-headphones fg-emerald'></span>"
                            Case clsUICommon.gFileType.eDocument
                                strIcon = "<span class='mif-books fg-emerald'></span>"
                            Case clsUICommon.gFileType.eMagazine
                                strIcon = "<span class='icon-newspaper fg-emerald'></span>"
                            Case Else
                                strIcon = "<span class='icon-bug fg-emerald'></span>"
                        End Select
                        strResult &= rv("DisplayEntry") & " (" & FormatNumber(rv("NumberNo"), 0) & Space(1) & strIcon & ")"
                    Else
                        strResult &= rv("DisplayEntry") & " (" & FormatNumber(rv("NumberNo"), 0) & " <span class='mif-books fg-emerald'></span>)"
                    End If
                    strResult &= "</span>"
                    If bolFilter Then
                        strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='" & strFilterDelete & "' onclick=""filterObject(" & dicId & ",'" & rv("DisplayEntry") & "','" & rv("ID") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top' style=""cursor:pointer;margin-top:-5px;""></span>"
                    End If
                    'strResult &= "</div>"
                    strResult &= "</a>"
                    strResult &= "</li>"
                    iCount += 1
                Next
                If iCount >= iMax Then 'view more than 
                    strResult &= "<li>"
                    strResult &= "<a onclick=""showBrowseMore(" & dicId & ");"""" style=""cursor:pointer;"">"
                    'strResult &= "<span style='color:emerald;' title='" & spViewMore.InnerText & "'>"
                    strResult &= "<span style='color:emerald;' data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white' data-hint='" & spViewMore.InnerText & "'>"
                    strResult &= "<b>" & spViewMore.InnerText & " ></b>"
                    strResult &= "</span>"
                    strResult &= "</a>"
                    strResult &= "</li>"

                    'strResult &= "<div id='" & strShowDiv & "'>"
                    'strResult &= "<a class='list' onclick=""showBrowseMore(" & dicId & ");"">"
                    'strResult &= "<div class='list-content'>"
                    'strResult &= "<span class='list-subtitle'>"
                    'strResult &= spViewMore.InnerText
                    'strResult &= "</span>"
                    'strResult &= "</div>"
                    'strResult &= "</a>"
                    'strResult &= "</div>"
                End If
                'strResult &= "</div>" 'Close data-role='listview'
                'strResult &= "</div>" 'Close div class='span4'
                strResult &= "</ul>"
                strResult &= "<div class='div-blank'></div>"
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function


        ' getDictionaryString method
        ' Purpose: get objects string to into browse
        Private Function getDDC(ByVal dt As DataTable) As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = dt.Rows.Count - 1
                Dim intId As Integer = 0
                Dim intParentIdNextNode As Integer = 0
                Dim intParentIdPreviousNode As Integer = 0
                Dim intNodeId As Integer = 0
                Dim bolLeafNode As Boolean = False
                Dim intLevel As Integer = 1
                strResult &= "<h4>" & spCatalogy.InnerText & "</h4>"
                strResult &= "<div id='treeviewDDC'>"
                strResult &= "<ul class='treeview' data-role='treeview'>"
                For i As Integer = 0 To iCount

                    intNodeId = dt.Rows(i).Item("ID")
                    If i + 1 <= iCount Then
                        If Not IsDBNull(dt.Rows(i + 1).Item("ParentID")) Then
                            intParentIdNextNode = dt.Rows(i + 1).Item("ParentID")
                        Else
                            intParentIdNextNode = 0
                        End If
                    End If
                    bolLeafNode = False
                    If intParentIdNextNode <> intNodeId Then
                        bolLeafNode = True
                    End If

                    If IsDBNull(dt.Rows(i).Item("ParentID")) Then
                        If i <> 0 Then
                            For k As Integer = 1 To intLevel - 1
                                strResult &= "</ul>"
                                strResult &= "</li>" 'Close child tag
                                'strResult &= "</ul>"
                                'strResult &= "</li>" 'Close 1 level
                            Next
                        End If
                        If bolLeafNode Then
                            'Neu la nut la thi thay the code --> codeFull
                            strResult &= "<li><a href='#' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("codeFull") & "',1)"">" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If checkFilter(12, dt.Rows(i).Item("codeFull")) Then
                                'strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("codeFull") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("codeFull") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                            strResult &= "</a></li>"
                        Else
                            strResult &= "<li class='node collapsed'>"
                            strResult &= "<a href='#' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("Code") & "',1)""><span class='node-toggle'></span>" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            If checkFilter(12, dt.Rows(i).Item("Code")) Then
                                'strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("Code") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("Code") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                            strResult &= "</a>"
                            strResult &= "<ul>"
                        End If
                    Else
                        If bolLeafNode Then
                            'Neu la nut la thi thay the code --> codeFull
                            strResult &= "<li><a href='#' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("codeFull") & "',1)"">" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If checkFilter(12, dt.Rows(i).Item("codeFull")) Then
                                'strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("codeFull") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                'strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("codeFull") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("codeFull") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                            strResult &= "</a></li>"
                        Else
                            If intParentIdPreviousNode <> dt.Rows(i).Item("ParentID") AndAlso intParentIdPreviousNode <> 0 Then
                                strResult &= "</ul>"
                                strResult &= "</li>"
                            End If
                            strResult &= "<li class='node collapsed'>" 'Child tag
                            strResult &= "<a href='#' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("Code") & "',1)""><span class='node-toggle'></span>" & dt.Rows(i).Item("Caption") & " (" & dt.Rows(i).Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            If checkFilter(12, dt.Rows(i).Item("Code")) Then
                                'strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("Code") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                'strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("Code") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & dt.Rows(i).Item("Code") & "' onclick=""filterObject(12,'" & dt.Rows(i).Item("Caption") & "','" & dt.Rows(i).Item("Code") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                            strResult &= "</a>"
                            strResult &= "<ul>"
                        End If
                    End If

                    If Not IsDBNull(dt.Rows(i).Item("ParentID")) Then
                        intParentIdPreviousNode = dt.Rows(i).Item("ParentID")
                    Else
                        intParentIdPreviousNode = 0
                    End If
                    intLevel = dt.Rows(i).Item("alevel")
                Next

                'strResult &= "</ul>" 'Close 1 level for end node
                'strResult &= "</li>" 'Close 1 level for end node

                For k As Integer = 1 To intLevel - 1
                    strResult &= "</ul>"
                    strResult &= "</li>" 'Close child tag
                    'strResult &= "</ul>"
                    'strResult &= "</li>" 'Close 1 level
                Next
                strResult &= "</ul>" 'Close treeview
                strResult &= "</div>" 'Close div
            Catch ex As Exception
                strResult = ""
            End Try
            'strResult = "<div><ul class='treeview' data-role='treeview'>                                    <li class='node'>                                        <a href='#'><span class='node-toggle'></span>sergey@pimenov.com.ua</a>                                        <ul>                                            <li><a href='#'>Inbox</a></li>                                            <li><a href='#'>Outbox</a></li>                                            <li><a href='#'>Drafts</a></li>                                            <li><a href='#'>Rss-channels</a></li>                                            <li><a href='#'>Trash <span class='value'>[5]</span></a></li>                                            <li class='node'>                                                <a href='#'><span class='node-toggle'></span>subnode</a>                                                <ul>                                                    <li><a href='#'>Inbox</a></li>                                                    <li><a href='#'>Outbox</a></li>                                                    <li><a href='#'>Drafts</a></li>                                                    <li><a href='#'>Rss-channels</a></li>                                                    <li><a href='#'>Trash</a></li>                                                    <li class='node'>                                                        <a href='#'><span class='node-toggle'></span>subnode 2</a>                                                        <ul>                                                            <li><a href='#'>Inbox</a></li>                                                            <li><a href='#'>Outbox</a></li>                                                            <li><a href='#'>Drafts</a></li>                                                            <li><a href='#'>Rss-channels</a></li>                                                            <li><a href='#'>Trash</a></li>                                                        </ul>                                                    </li>                                                </ul>                                            </li>                                        </ul>                                    </li>                                    <li class='node'>                                        <a href='#'><span class='node-toggle'></span>support@metroui.net</a>                                        <ul>                                            <li><a href='#'>Inbox</a></li>                                            <li><a href='#'>Outbox</a></li>                                            <li><a href='#'>Drafts</a></li>                                            <li><a href='#'>Rss-channels</a></li>                                            <li><a href='#'>Trash</a></li>                                        </ul>                                    </li>                                    <li class='node collapsed'>                                        <a href='#'><span class='node-toggle'></span>info@metroui.net</a>                                        <ul>                                            <li><a href='#'>Inbox</a></li>                                            <li><a href='#'>Outbox</a></li>                                            <li><a href='#'>Drafts</a></li>                                            <li><a href='#'>Rss-channels</a></li>                                            <li><a href='#'>Trash</a></li>                                        </ul>                                    </li>                                </ul>                            </div>"
            Return strResult
        End Function


        Function getDDCIDs() As String
            Dim strResult As String = ""
            Try
                Dim intDicID As Integer = 0
                If Not IsNothing(Request("DicID")) AndAlso Request("DicID") <> "" Then
                    intDicID = Request("DicID")
                End If
                If intDicID = 12 Then 'DDC
                    If Not IsNothing(Request("BrowseId")) AndAlso Request("BrowseId") <> "" Then
                        strResult = Request("BrowseId")
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function


        ' getTriewviewDDC method
        ' Purpose: get objects string to into browse
        Private Function getTriewviewDDC(ByVal dt As DataTable) As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = dt.Rows.Count - 1
                If iCount > 0 Then
                    strDDCIds = getDDCIDs()

                    'strResult &= "<h4>" & spCatalogy.InnerText & "</h4>"
                    strResult &= "<h1 class='head-title'><span>" & spCatalogy.InnerText & "</span></h1>"
                    strResult &= "<div id='treeviewDDC'>"
                    'strResult &= "<ul class='treeview' data-role='treeview'>"
                    strResult &= "<div class='treeview' data-role='treeview'>"
                    strResult &= "<ul>"

                    Dim rowView As DataRowView
                    Dim dview As DataView
                    dt.DefaultView.RowFilter = "ParentID IS NULL"
                    If dt.DefaultView.Count > 0 Then
                        dview = dt.DefaultView
                        For Each rowView In dt.DefaultView
                            'strResult &= "<ul>"
                            'strResult &= "<li class='node expanded'>"
                            'strResult &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            'strResult &= "</a>"
                            'strResult &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("code") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If Left(strDDCIds, 1) = rowView.Item("code").ToString Then
                                strResult &= "<li  class='node active expanded'><span class='node-toggle'></span><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("code") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            Else
                                strResult &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("code") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            End If

                            If checkFilter(12, rowView.Item("code")) Then
                                'strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("code") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("code") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                            strResult &= "</span>"
                            Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResult)
                            strResult &= "</li>"
                            'strResult &= "</ul>"
                        Next
                    End If
                    dt.DefaultView.RowFilter = ""

                    'strResult &= "</ul>" 'Close treeview
                    strResult &= "</ul>"
                    strResult &= "</div>" 'Close div
                    strResult &= "</div>" 'Close div
                End If
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function

        ' getTriewviewDDC method
        ' Purpose: get objects string to into browse
        Private Function getTriewviewDDC_v0_9(ByVal dt As DataTable) As String
            Dim strResult As String = ""
            Try
                Dim iCount As Integer = dt.Rows.Count - 1
                If iCount > 0 Then
                    strResult &= "<h4>" & spCatalogy.InnerText & "</h4>"
                    strResult &= "<div id='treeviewDDC'>"
                    strResult &= "<ul class='treeview' data-role='treeview'>"

                    Dim rowView As DataRowView
                    Dim dview As DataView
                    dt.DefaultView.RowFilter = "ParentID IS NULL"
                    If dt.DefaultView.Count > 0 Then
                        dview = dt.DefaultView
                        For Each rowView In dt.DefaultView
                            strResult &= "<ul>"
                            'strResult &= "<li class='node expanded'>"
                            'strResult &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            'strResult &= "</a>"
                            strResult &= "<li  class='node collapsed'><a href='#' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("code") & "',1)""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If checkFilter(12, rowView.Item("code")) Then
                                strResult &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("code") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                            strResult &= "</a>"
                            Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResult)
                            strResult &= "</li>"
                            strResult &= "</ul>"
                        Next
                    End If
                    dt.DefaultView.RowFilter = ""

                    strResult &= "</ul>" 'Close treeview
                    strResult &= "</div>" 'Close div
                End If
            Catch ex As Exception
                strResult = ""
            End Try
            Return strResult
        End Function

        Private Sub getTriewviewDDCChild(ByVal dv As DataView, ByVal intLevel As Integer, ByRef strResultOut As String)
            Try
                dv.RowFilter = "ParentID = " & intLevel
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim dviewLeaf As DataView
                Dim boldviewLeaf As Boolean = False
                If dv.Count > 0 Then
                    dview = dv
                    dviewLeaf = dv
                    strResultOut &= "<ul>"
                    For Each rowView In dv
                        dviewLeaf.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dviewLeaf.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dviewLeaf.RowFilter = ""
                        strResultOut &= "<li>"
                        If boldviewLeaf Then
                            'strResultOut &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            'strResultOut &= "<li><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("codeFull") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If strDDCIds = rowView.Item("code").ToString Then
                                strResultOut &= "<li class='active'><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("codeFull") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            Else
                                strResultOut &= "<li><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("codeFull") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            End If
                            If checkFilter(12, rowView.Item("codeFull")) Then
                                'strResultOut &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("codeFull") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                strResultOut &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("codeFull") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                        Else
                            'strResultOut &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            'strResultOut &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("Code") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If Left(strDDCIds, 2) = rowView.Item("code").ToString Then
                                strResultOut &= "<li  class='node active expanded'><span class='node-toggle'></span><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("Code") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            Else
                                strResultOut &= "<li  class='node collapsed'><span class='node-toggle'></span><span class='leaf' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("Code") & "',1)"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            End If
                            If checkFilter(12, rowView.Item("Code")) Then
                                'strResultOut &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("Code") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                                strResultOut &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("Code") & "',0)""  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                        End If

                        strResultOut &= "</span>"
                        Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResultOut)
                        strResultOut &= "</li>"
                    Next
                    strResultOut &= "</ul>"
                End If
                dv.RowFilter = ""
            Catch ex As Exception
            End Try
        End Sub


        Private Sub getTriewviewDDCChild_v0_9(ByVal dv As DataView, ByVal intLevel As Integer, ByRef strResultOut As String)
            Try
                dv.RowFilter = "ParentID = " & intLevel
                Dim rowView As DataRowView
                Dim dview As DataView
                Dim dviewLeaf As DataView
                Dim boldviewLeaf As Boolean = False
                If dv.Count > 0 Then
                    dview = dv
                    dviewLeaf = dv
                    strResultOut &= "<ul>"
                    For Each rowView In dv
                        dviewLeaf.RowFilter = "ParentID = " & rowView.Item("ID")
                        boldviewLeaf = False
                        If dviewLeaf.Count = 0 Then
                            boldviewLeaf = True
                        End If
                        dviewLeaf.RowFilter = ""
                        If boldviewLeaf Then
                            'strResultOut &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")"">" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            strResultOut &= "<li><a href='#' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("codeFull") & "',1)""></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If checkFilter(12, rowView.Item("codeFull")) Then
                                strResultOut &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("codeFull") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                        Else
                            'strResultOut &= "<a href='#' onclick=""gotoShowRecord(12," & rowView.Item("ID") & ")""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)"
                            strResultOut &= "<li  class='node collapsed'><a href='#' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("Code") & "',1)""><span class='node-toggle'></span>" & rowView.Item("Caption") & " (" & rowView.Item("NumberNo") & " <span class='mif-books fg-emerald'></span>)" 'leaf tag
                            If checkFilter(12, rowView.Item("Code")) Then
                                strResultOut &= "<span class='place-right mif-cancel mif-2x fg-red' id='spDDC" & rowView.Item("Code") & "' onclick=""filterObject(12,'" & rowView.Item("Caption") & "','" & rowView.Item("Code") & "',0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                            End If
                        End If

                        strResultOut &= "</a>"
                        Call getTriewviewDDCChild(dview, rowView.Item("ID"), strResultOut)
                        strResultOut &= "</li>"
                    Next
                    strResultOut &= "</ul>"
                End If
                dv.RowFilter = ""
            Catch ex As Exception
            End Try
        End Sub

        ' filterInBrowse method
        ' Purpose: find browse key and return true if it's found
        Private Function checkFilter(ByVal intDicID As Integer, ByVal intId As String) As Boolean
            Dim bolResult As Boolean = False
            Try
                Dim strId As String = intDicID.ToString & "-" & intId & ","
                If InStr(clsSession.GlbFilterConditionString, strId) > 0 Then
                    bolResult = True
                End If
            Catch ex As Exception
            End Try
            Return bolResult
        End Function

        ' setFilterCondition method
        ' Purpose: check filter condition. add filter string into session if it's true
        Private Sub setFilterCondition(ByVal strCondition As String, ByVal strConditionValue As String, ByVal intStatus As Integer)
            Try
                'intStatus. 1: add, 0:remove
                If intStatus = 1 Then
                    If Not InStr(clsSession.GlbFilterConditionString, strCondition) > 0 Then
                        clsSession.GlbFilterConditionString &= strCondition
                        clsSession.GlbFilterConditionValue &= strConditionValue
                    End If
                Else
                    clsSession.GlbFilterConditionString = Replace(clsSession.GlbFilterConditionString, strCondition, "")
                    clsSession.GlbFilterConditionValue = Replace(clsSession.GlbFilterConditionValue, strConditionValue, "")
                End If

            Catch ex As Exception
            End Try
        End Sub

        ' raiseFilterInResult_Click method
        ' Purpose: Filter In Result
        Private Sub raiseFilterInResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseFilterInResult.Click
            Try
                Dim strSearch As String = hidSearchInResult.Value.Trim
                If strSearch <> "" Then
                    Call resetFilter()

                    strSearch = objBCommonStringProc.killCharsProcessVal(strSearch)
                    hidSearch.Value = strSearch
                    clsSession.GlbFilterConditionStringInResult &= strSearch & ";"
                    strSearch = getCutVietnameseAccent(clsSession.GlbFilterConditionStringInResult)
                    Call onSearchInResult(strSearch, True)
                    'Call showBreadcrumbsInResult(clsSession.GlbFilterConditionStringInResult)
                    'Call BindData(clsSession.GlbIdsInResult)
                    'Call BindData(clsSession.GlbIds)
                    Call BindData(clsSession.GlbSQLStatement)
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' raiseDeleteFilterInResult_Click method
        ' Purpose: delete Filter In Result
        Private Sub raiseDeleteFilterInResult_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseDeleteFilterInResult.Click
            Try
                Dim strSearch As String = hidSearchInResult.Value.Trim
                If strSearch <> "" Then
                    Call resetFilter()

                    strSearch = objBCommonStringProc.killCharsProcessVal(strSearch)
                    hidSearch.Value = strSearch
                    strSearch = getCutVietnameseAccent(strSearch)
                    Call onSearchDeleteInResult(clsSession.GlbFilterConditionStringInResult, strSearch, True)
                    'Call BindData(clsSession.GlbIdsInResult)
                    'Call BindData(clsSession.GlbIds)
                    Call BindData(clsSession.GlbSQLStatement)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub showBreadcrumbsInResult(ByVal strSearchWords As String)
            Dim strBreadcrumbs As String = ""
            Try
                ' hSearchTitle.Visible = False
                If strSearchWords.Trim <> "" Then
                    'hSearchTitle.Visible = True
                    Dim strSearchArr() As String = Split(strSearchWords, ";")
                    'If Not IsNothing(clsSession.GlbIdsInResult) AndAlso clsSession.GlbIdsInResult.Rows.Count > 0 Then
                    '    'strBreadcrumbs = "<nav class='breadcrumbs'>"
                    '    'strBreadcrumbs &= "<ul>"
                    '    'For i As Integer = 0 To UBound(strSearchArr) - 1
                    '    '    If strSearchArr(i) <> "" Then
                    '    '        If i = UBound(strSearchArr) - 1 Then
                    '    '            strBreadcrumbs &= "<li>"
                    '    '            strBreadcrumbs &= "<a>"
                    '    '            strBreadcrumbs &= strSearchArr(i)
                    '    '            strBreadcrumbs &= "</a>"
                    '    '            strBreadcrumbs &= "</li>"
                    '    '        Else
                    '    '            strBreadcrumbs &= "<li>"
                    '    '            strBreadcrumbs &= "<a href='#'>"
                    '    '            strBreadcrumbs &= strSearchArr(i)
                    '    '            strBreadcrumbs &= "</a>"
                    '    '            strBreadcrumbs &= "</li>"
                    '    '        End If
                    '    '    End If
                    '    'Next
                    '    'strBreadcrumbs &= "</ul>"
                    '    'strBreadcrumbs &= "</nav>"
                    '    'If UBound(strSearchArr) > 0 Then

                    '    'End If

                    'Else
                    '    strBreadcrumbs &= "<B>" & strSearchArr(0).Trim() & "</B>"
                    'End If
                    Dim intUbound As Integer = UBound(strSearchArr) - 1
                    For i As Integer = 0 To intUbound
                        If strSearchArr(i) <> "" Then
                            If i = 0 Then
                                If intUbound > 0 Then
                                    strBreadcrumbs &= "<a style='cursor:pointer' onclick=""deleteFilterInResult('" & strSearchArr(i) & "')"">"
                                    'Postback
                                    strBreadcrumbs &= strSearchArr(i)
                                    strBreadcrumbs &= "</a>"
                                Else
                                    strBreadcrumbs &= strSearchArr(i)
                                End If
                            ElseIf i = intUbound Then
                                strBreadcrumbs &= "&nbsp;" & "<span class='mif-chevron-right mif-lg'></span>" & "&nbsp;"
                                strBreadcrumbs &= strSearchArr(i)
                            Else
                                strBreadcrumbs &= "&nbsp;" & "<span class='mif-chevron-right mif-lg'></span>" & "&nbsp;"
                                strBreadcrumbs &= "<a style='cursor:pointer' onclick=""deleteFilterInResult('" & strSearchArr(i) & "')"">"
                                strBreadcrumbs &= strSearchArr(i)
                                strBreadcrumbs &= "</a>"
                            End If
                        End If
                    Next
                    'ltrBreadcrumbsInResult.Text = "<span id='spInFilter'>" & spFilterFor.InnerText & "</span>" & "<a style='cursor:pointer' onclick=""gotoShow(1," & hidMutiLibrary.Value & ")""><span class='icon-cycle'></span></a>" & "&nbsp;" & "<span class='icon-arrow-right-5'></span>" & "&nbsp;" & "<B>" & strBreadcrumbs & "</B>"
                    'ltrBreadcrumbsInResult.Text = "<span id='spInFilter'>" & spFilterFor.InnerText & "</span>" & "<a style='cursor:pointer' onclick=""gotoShow(1," & hidMutiLibrary.Value & ")""><span class='mif-sync-problem mif-lg fg-red'></span></a>" & "&nbsp;" & "<span class='mif-chevron-right mif-lg'></span>" & "&nbsp;" & "<B>" & strBreadcrumbs & "</B>"
                    ltrBreadcrumbsInResult.Text = "<span id='spInFilter'>" & spFilterFor.InnerText & "</span>" & "<a style='cursor:pointer' onclick=""gotoShow(1," & hidMutiLibrary.Value & ")""><span class='mif-sync-problem mif-lg fg-red' data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span></a>" & "&nbsp;" & "<span class='mif-chevron-right mif-lg'></span>" & "&nbsp;" & "<B>" & strBreadcrumbs & "</B>"
                    'strResults &= "<span style='cursor:pointer;' class='mif-loop2 mif-lg fg-red' onclick=""filterObject(" & strArray2(0) & ",'" & strArray3(i) & "'," & strArray2(1) & ",0)"" data-hint='|" & spRemoveFilter.InnerText & "' data-hint-position='top'></span>"
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' raiseOrderBy_Click method
        ' Purpose: order by reocrd
        Private Sub raiseOrderBy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseOrderBy.Click
            Try
                Dim dtIds As DataTable = Nothing
                'If Not IsNothing(clsSession.GlbIdsInResult) AndAlso clsSession.GlbIdsInResult.Rows.Count > 0 Then
                '    dtIds = clsSession.GlbIdsInResult
                'Else
                '    dtIds = clsSession.GlbIds
                'End If
                'dtIds = clsSession.GlbIds
                clsSession.GlbOrderBy = hidOrderBy.Value
                Call filterInBrowse(clsSession.GlbFilterConditionString, clsSession.GlbSQLStatement)
                Call BindData(clsSession.GlbSQLStatementFilter, clsSession.GlbBrowseFilter)
                Call genBreadcrumbsFilter(clsSession.GlbFilterConditionString, clsSession.GlbFilterConditionValue)
            Catch ex As Exception
            End Try
        End Sub

        ' raiseFilter_Click method
        ' Purpose: get objects string to into browse
        Private Sub raiseFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseFilter.Click
            Try
                Dim intBrowseId As String = hidBrowseId.Value
                Dim intDicId As Integer = hidDicId.Value
                Dim intStatus As Integer = hidFilterStatus.Value
                Dim strCondition As String = intDicId & "-" & intBrowseId & ","
                Dim strConditionValue As String = intDicId & "-" & intBrowseId & hidDicName.Value & ","
                Call setFilterCondition(strCondition, strConditionValue, intStatus)

                Dim dtIds As DataTable = Nothing
                'If Not IsNothing(clsSession.GlbIdsInResult) AndAlso clsSession.GlbIdsInResult.Rows.Count > 0 Then
                '    dtIds = clsSession.GlbIdsInResult
                'Else
                '    dtIds = clsSession.GlbIds
                'End If
                'dtIds = clsSession.GlbIds
                Call filterInBrowse(clsSession.GlbFilterConditionString, clsSession.GlbSQLStatement)
                'Call BindData(clsSession.GlbFilterIds)
                Call BindData(clsSession.GlbSQLStatementFilter)

                Call genBreadcrumbsFilter(clsSession.GlbFilterConditionString, clsSession.GlbFilterConditionValue)
            Catch ex As Exception
            End Try
        End Sub

        ' raiseShowRecord_Click method
        ' Purpose: show record by click of page
        Private Sub raiseShowRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseShowRecord.Click
            Try
                Dim intCurrenPage As Integer = hidCurrentPage.Value
                Dim strIds As String = ""
                If clsSession.GlbSQLStatementFilter <> "" Then
                    strIds = clsSession.GlbSQLStatementFilter
                Else
                    strIds = clsSession.GlbSQLStatement
                End If
                'If Not IsNothing(clsSession.GlbFilterIds) AndAlso clsSession.GlbFilterIds.Rows.Count > 0 Then
                '    dt = clsSession.GlbFilterIds
                'Else
                '    'If Not IsNothing(clsSession.GlbIdsInResult) AndAlso clsSession.GlbIdsInResult.Rows.Count > 0 Then
                '    '    dt = clsSession.GlbIdsInResult
                '    'Else
                '    '    dt = clsSession.GlbIds
                '    'End If
                '    'dt = clsSession.GlbIds
                '    strIds = clsSession.GlbSQLStatement
                'End If
                Call BindData(strIds, clsSession.GlbBrowseFilter)
            Catch ex As Exception
            End Try
        End Sub


        ' purpose :  show books by list of ids document
        ' Creator: phuongtt
        Private Sub processBooks(ByVal tblIDs As DataTable)
            Try
                Dim intCurPage As Integer
                Dim intCount As Integer
                Dim strIDs As String = ""
                Dim intSumPage As Integer
                Dim intStart, intStop As Integer
                Dim colSearch As New Collection
                Dim intSumResult As Integer = 0
                Dim strSelectTop As String = ""

                Dim intTotal As Integer = tblIDs.Rows.Count
                Dim intPagezise As Integer = Application("ePageSize")
                Dim intPageLength As Integer = Application("ePageLength")
                Dim intPageSpace As Integer = Application("ePageSpace")

                ' intSumPage = UBound(arrIDs) \ intRecPerPage + 1
                'intSumPage = (intTotal - 1) \ intPagezise + 1
                intSumPage = (intTotal \ intPagezise) + 1

                '' Read current page number
                'If IsNumeric(Request.QueryString("pg") & "") Then
                '    intCurPage = CInt(Request.QueryString("pg") & "")
                'Else
                '    intCurPage = 1
                'End If
                intCurPage = hidCurrentPage.Value

                intStart = (intCurPage - 1) * intPagezise
                intStop = (((intCurPage - 1) * intPagezise) + intPagezise) - 1
                If intStart > intTotal - 1 Then
                    intStart = intTotal - 1
                End If
                If intStop > intTotal - 1 Then
                    intStop = intTotal - 1
                End If

                Call showPagingControl(intTotal, intPagezise, intCurPage, intPageSpace, intPageLength, intStop, intSumPage)

                Call showOrderByControl(intCurPage)

                ' Read IDs of current page

                'For i As Integer = 0 To tblIDs.Rows.Count - 1
                '    strIDs = strIDs & tblIDs.Rows(i).Item("ID") & ","
                'Next
                'If strIDs <> "" Then
                '    strIDs = Left(strIDs, Len(strIDs) - 1)
                'End If

                For intCount = intStart To intStop
                    strIDs = strIDs & tblIDs.Rows(intCount).Item("ID") & ","
                Next
                If strIDs <> "" Then
                    strIDs = Left(strIDs, Len(strIDs) - 1)
                End If


                objBSearchResult.ItemIDs = strIDs
                Dim arrField() As String = {"022", "100", "110", "245", "250", "260", "082", "090", "490", "653", "700", "710", "773", "856"}
                Dim tblTmp As New DataTable
                Dim strSearch As String = hidSearch.Value
                strSearch = getCutVietnameseAccent(strSearch)
                Dim bolEbooksFulltext As Boolean = False
                If hidSearchEbooks.Value <> "" Then
                    bolEbooksFulltext = True
                End If
                Dim tblAuthor As New DataTable("tblAuthor")
                tblAuthor.Columns.Add("ItemID")
                tblAuthor.Columns.Add("Content")
                'tblTmp = objBSearchResult.GetItemResultsByFields(arrField, True, strSearch, , bolEbooksFulltext, False)
                tblTmp = objBSearchResult.GetItemResultsByFieldsOther(arrField, ConvertTypeSearchToSearchBy(Integer.Parse(hidSearchType.Value)), True, strSearch, , bolEbooksFulltext, False, tblAuthor)

                '------
                'Dim arrIds As String = ""
                'Dim dataSetTemp As New DataSet("tmpResult")
                'Dim tabltTemp As DataTable = dataSetTemp.Tables.Add("tmpResult")
                'For j As Integer = 0 To tblTmp.Columns.Count - 1
                '    tabltTemp.Columns.Add(tblTmp.Columns(j).ColumnName)
                'Next
                'For intCount = intStart To intStop
                '    Dim rowTemp As DataRow = tabltTemp.NewRow()
                '    rowTemp.ItemArray = tblTmp.Rows(intCount).ItemArray
                '    tabltTemp.Rows.Add(rowTemp)
                '    arrIds = arrIds & tblTmp.Rows(intCount).Item("ItemID") & ","
                'Next
                'If arrIds <> "" Then
                '    arrIds = Left(arrIds, Len(arrIds) - 1)
                'End If
                '------

                Call showBooks(tblTmp, strIDs, intCurPage, intPagezise, tblAuthor, Integer.Parse(hidSearchType.Value))
                'Call showBooks(tabltTemp, arrIds, intCurPage, intPagezise)
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show order by control
        ' Creator: phuongtt
        Private Sub showOrderByControl(ByVal intCurPage As Integer)
            Dim strResult As String = ""
            Try
                'strResult &= "<ul class=""split-content d-menu place-right"" data-role=""dropdown"">"
                Select Case UCase(clsSession.GlbOrderBy)
                    Case "TITLE"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'TITLE')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spTitleInfo.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'AUTHOR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spAuthor.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'YEAR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisherYear.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'PUBLISH')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisher.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option selected value=""TITLE"">" & spTitleInfo.InnerText & "</option>"
                        strResult &= "<option value=""AUTHOR"">" & spAuthor.InnerText & "</option>"
                        strResult &= "<option value=""YEAR"">" & spPublisherYear.InnerText & "</option>"
                        strResult &= "<option value=""PUBLISH"">" & spPublisher.InnerText & "</option>"
                        strResult &= "</select>"
                    Case "AUTHOR"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'TITLE')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spTitleInfo.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'AUTHOR')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spAuthor.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'YEAR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisherYear.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'PUBLISH')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisher.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""TITLE"">" & spTitleInfo.InnerText & "</option>"
                        strResult &= "<option selected value=""AUTHOR"">" & spAuthor.InnerText & "</option>"
                        strResult &= "<option value=""YEAR"">" & spPublisherYear.InnerText & "</option>"
                        strResult &= "<option value=""PUBLISH"">" & spPublisher.InnerText & "</option>"
                        strResult &= "</select>"
                    Case "YEAR"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'TITLE')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spTitleInfo.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'AUTHOR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spAuthor.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'YEAR')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spPublisherYear.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'PUBLISH')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisher.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""TITLE"">" & spTitleInfo.InnerText & "</option>"
                        strResult &= "<option value=""AUTHOR"">" & spAuthor.InnerText & "</option>"
                        strResult &= "<option selected value=""YEAR"">" & spPublisherYear.InnerText & "</option>"
                        strResult &= "<option value=""PUBLISH"">" & spPublisher.InnerText & "</option>"
                        strResult &= "</select>"
                    Case "PUBLISH"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'TITLE')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spTitleInfo.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'AUTHOR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spAuthor.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'YEAR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisherYear.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'PUBLISH')""><span runat='server' class='icon-radio-checked'>&nbsp;&nbsp;" & spPublisher.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""TITLE"">" & spTitleInfo.InnerText & "</option>"
                        strResult &= "<option value=""AUTHOR"">" & spAuthor.InnerText & "</option>"
                        strResult &= "<option value=""YEAR"">" & spPublisherYear.InnerText & "</option>"
                        strResult &= "<option selected value=""PUBLISH"">" & spPublisher.InnerText & "</option>"
                        strResult &= "</select>"
                    Case Else
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'TITLE')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spTitleInfo.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'AUTHOR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spAuthor.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'YEAR')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisherYear.InnerText & "</span></a></li>"
                        'strResult &= "<li><a onclick=""showRecordOrderBy(" & intCurPage.ToString & ",'PUBLISH')""><span runat='server' class='icon-radio-unchecked'>&nbsp;&nbsp;" & spPublisher.InnerText & "</span></a></li>"
                        strResult &= "<select onChange=""showRecordOrderBy(" & intCurPage.ToString & ",this)"">"
                        strResult &= "<option value="""">" & spOrderBy.InnerText & "</option>"
                        strResult &= "<option value=""TITLE"">" & spTitleInfo.InnerText & "</option>"
                        strResult &= "<option value=""AUTHOR"">" & spAuthor.InnerText & "</option>"
                        strResult &= "<option value=""YEAR"">" & spPublisherYear.InnerText & "</option>"
                        strResult &= "<option value=""PUBLISH"">" & spPublisher.InnerText & "</option>"
                        strResult &= "</select>"
                End Select
                'strResult &= "</ul>"
            Catch ex As Exception
            End Try
            ltrOrderBy.Text = strResult

            Call GenStringTitleAndTextHolderByDicID(clsSession.GlbOrderBy)
        End Sub


        ' purpose :  show paging as google paging
        ' Creator: phuongtt
        Private Sub showPagingControl(ByVal intCount As Integer, ByVal intPagezise As Integer, ByVal intPage As Integer, ByVal intPageSpace As Integer, ByVal intPageLength As Integer, ByVal intStop As Integer, Optional ByVal intSumPage As Integer = 0)
            Try
                Dim iPage As Integer = CInt((intCount / intPagezise) + 0.4999)
                Dim strPagination As String = ""
                Dim PreviousPage As Integer = intPage - 1
                Dim NextPage As Integer = intPage + 1
                If PreviousPage >= 1 Then
                    strPagination &= "<li><a onclick='showRecord(" & 1 & ")' data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spFirstPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'>|<</a></li>"
                    'strPagination &= "<li><a onclick='showRecord(" & PreviousPage.ToString & ")' data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                    strPagination &= "<li><a onclick='showRecord(" & PreviousPage.ToString & ")'  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spPreviousPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'><</a></li>"
                End If
                Dim xy As Integer = CInt((intPage / intPageSpace) + 0.4999)
                Dim alpha As Integer = (xy - 1) * intPageSpace
                Dim iPageCount As Integer = IIf(intPageLength + alpha <= iPage, intPageLength + alpha, iPage)

                For j As Integer = 1 + alpha To iPageCount
                    strPagination &= "<li>"
                    If j = intPage Then
                        strPagination &= "<a onclick='showRecord(" & j.ToString & ")' class='PageSeleted'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    Else
                        strPagination &= "<a onclick='showRecord(" & j.ToString & ")'  style='cursor:pointer;'>" & j.ToString & "</a>"
                    End If
                    strPagination &= "</li>"
                Next
                If NextPage <= iPage Then
                    'strPagination &= "<li><a onclick='showRecord(" & NextPage.ToString & ")' data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
                    strPagination &= "<li><a onclick='showRecord(" & NextPage.ToString & ")'  data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spNextPage.InnerText & "' data-hint-position='top'  style='cursor:pointer;'>></a></li>"
                End If
                If intSumPage > iPageCount Then
                    strPagination &= "<li><a onclick='showRecord(" & intSumPage.ToString & ")' data-role='hint' data-hint-background='bg-blue' data-hint-color='fg-white'  data-hint='|" & spLastPage.InnerText & "' data-hint-position='top' style='cursor:pointer;'>>|</a></li>"
                End If
                lrtPagination1.Text = strPagination
                lrtPagination2.Text = strPagination

                Dim strItemInfo As String = ""
                strItemInfo &= "<div style='vertical-align:middle;'><span class='tertiary-text-secondary'>"
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordItem.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intPagezise * (intPage - 1) + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordTo.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intStop + 1, 0)
                strItemInfo &= "&nbsp;"
                strItemInfo &= spRecordOf.InnerText
                strItemInfo &= "&nbsp;"
                strItemInfo &= FormatNumber(intCount, 0)
                'strItemInfo &= "</strong> "
                strItemInfo &= "</span>"
                strItemInfo &= "</div>"
                lrtPagination1.Text &= strItemInfo
                lrtPagination2.Text &= strItemInfo
            Catch ex As Exception
            End Try
        End Sub

        ' purpose :  show books
        ' Creator: phuongtt
        Private Sub showBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intCurPage As Integer, ByVal intRecPerPage As Integer, Optional ByVal tblAuthor As DataTable = Nothing, Optional ByVal intTypeSearch As Integer = 0)
            Dim strTitle As String ' thong tin nhan de chinh
            Dim strDKCB As String ' thong tin mo ta vat ly
            Dim strSoDinhDanh As String 'thong tin so dinh danh
            Dim strPublish As String ' thong tin xuat ban
            Dim strCover As String ' thong tin bia tai lieu
            Dim strAuthor As String ' thong tin tac gia
            Dim strISSN As String ' thong tin ISSN
            Dim strURL As String ' thong tin URL
            Dim strEDATA As String ' thong tin du lieu dien tu
            Dim strEMAGAZINE As String ' thong tin du lieu dien tu
            Dim strRANKING As String ' thong tin xep hang
            Dim strType As String ' thong tin loai tai lieu
            Dim strKeyword As String ' tu khoa
            Dim strLibrary As String = ""
            Dim intCount As Integer
            Dim strMXG As String = ""
            Dim strArrBrief() As String = Nothing
            Dim strBrief As String = ""
            Dim strSearchFulltext As String = ""
            Dim intPageLink As Integer = 1
            Dim arrIDs() As String
            Dim strArr() As String
            Dim intViews As Integer = 0
            Dim intDownLoads As Integer = 0
            Dim rowView As DataRowView
            Dim intViewRandom As Integer = 0
            If tblData Is Nothing Then
                Exit Sub
            End If
            arrIDs = Split(strIDs, ",")
            Dim strResult As String = ""
            If tblData.Rows.Count > 0 Then

                'Dim itemIdDataView As DataView = tblData.DefaultView
                'itemIdDataView.RowFilter = "Field='245'"
                'Dim count As Integer = itemIdDataView.Count

                'If (count > 0) Then
                '    For i As Integer = 0 To count - 1
                '        arrIDs(i) = itemIdDataView(i).Item("ItemID")
                '    Next
                'End If


                For intCount = 0 To UBound(arrIDs)
                    
                    strTitle = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                        If tblData.DefaultView.Count > 0 Then
                            strTitle = tblData.DefaultView(0).Item("Content") & ""
                            If (intTypeSearch = 1) Then
                                strTitle = strTitle.Replace("<span class=""hightlight-text"">", "").Replace("</span>", "")
                            End If
                        End If
                        strTitle = FormatNumber((intRecPerPage * (intCurPage - 1)) + intCount + 1, 0) & ". " & strTitle
                        If (strTitle(strTitle.Length - 1) = "/") Then
                            strTitle = strTitle.Substring(0, strTitle.Length - 1)
                        End If
                    Catch ex As Exception
                        strTitle = ""
                    End Try

                    ' get description physical
                    strDKCB = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='082'"
                        If tblData.DefaultView.Count > 0 Then
                            strDKCB = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strDKCB = ""
                    End Try

                    
                    ' get so dinh danh
                    strSoDinhDanh = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='090'"
                        If tblData.DefaultView.Count > 0 Then
                            strSoDinhDanh = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strSoDinhDanh = ""
                    End Try
                    
                    ' get publish information
                    strPublish = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='260'"
                        If tblData.DefaultView.Count > 0 Then
                            strPublish = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strPublish = ""
                    End Try
                    

                    ' get ISSN information
                    strISSN = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='022'"
                        If tblData.DefaultView.Count > 0 Then
                            strISSN = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strISSN = ""
                    End Try
                    

                    'get author info
                    strAuthor = ""
                    Try
                        tblAuthor.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount)
                        If tblAuthor.DefaultView.Count > 0 Then
                            strAuthor = tblAuthor.DefaultView(0).Item("Content") & ""
                            If (intTypeSearch = 13) Then
                                strAuthor = strAuthor.Replace("<span class=""hightlight-text"">", "").Replace("</span>", "")
                            End If

                            If (Not Request("txtSearch") Is Nothing AndAlso Not (strAuthor.Contains("<span class=""hightlight-text"">"))) Then
                                Dim uncodeSearch As String = objBCommonStringProc.CutVietnameseAccent(Request("txtSearch"))
                                Dim uncodeAuthor As String = objBCommonStringProc.CutVietnameseAccent(strAuthor)
                                Dim positionSearch As Integer = InStr(uncodeAuthor, uncodeSearch, CompareMethod.Text)
                                If (positionSearch > 0) Then
                                    Dim relAuthor As String = uncodeAuthor.Substring(0, positionSearch - 1)
                                    relAuthor = relAuthor & " <span class=""hightlight-text"">" & uncodeAuthor.Substring(positionSearch - 2, uncodeSearch.Length + 1) & "</span>"
                                    relAuthor = relAuthor & uncodeAuthor.Substring(positionSearch + uncodeSearch.Length, uncodeAuthor.Length - positionSearch - uncodeSearch.Length)

                                    strAuthor = relAuthor
                                End If

                            End If

                        End If
                    Catch ex As Exception
                        strAuthor = ""
                    End Try
                    
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='100'"
                    'For Each rowView In tblData.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        strAuthor &= rowView.Item("Content") & "; "
                    '    End If
                    'Next
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='110'"
                    'For Each rowView In tblData.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        strAuthor &= rowView.Item("Content") & "; "
                    '    End If
                    'Next
                    strKeyword = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='653'"
                        For Each rowView In tblData.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                strKeyword &= rowView.Item("Content") & "; "
                            End If
                        Next
                    Catch ex As Exception
                        strKeyword = ""
                    End Try
                    
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='700'"
                    'For Each rowView In tblData.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        strAuthor &= rowView.Item("Content") & "; "
                    '    End If
                    'Next
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='710'"
                    'For Each rowView In tblData.DefaultView
                    '    If Not IsDBNull(rowView.Item("Content")) Then
                    '        strAuthor &= rowView.Item("Content") & "; "
                    '    End If
                    'Next
                    'strAuthor = strAuthor.Trim
                    'If Not strAuthor = "" Then
                    '    strAuthor = strAuthor.Substring(0, strAuthor.Length - 1)
                    'End If

                    strURL = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='856'"
                        For Each rowView In tblData.DefaultView
                            If Not IsDBNull(rowView.Item("Content")) Then
                                If InStr(rowView.Item("Content"), "http://") > 0 Then
                                    strURL &= "<a href='" & rowView.Item("Content") & "' target='_blank' style='cursor:pointer;'><div class='icon-link'></div>URL</a>; "
                                End If
                            End If
                        Next
                        strURL = strURL.Trim
                        If strURL <> "" Then
                            strURL = strURL.Substring(0, strURL.Length - 1)
                            'Bo span danh dau highlight cac truong 0xx --> 9xx
                            strURL = Replace(strURL, "<span style=""background-color:#60a917 !important;color:white;""></span>", "")
                            strURL = Replace(strURL, "<span class=""hightlight-text""></span>", "")
                        End If
                    Catch ex As Exception
                        strURL = ""
                    End Try
                    

                    'Du lieu dien tu
                    strEDATA = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EDATA'"
                        If tblData.DefaultView.Count > 0 Then
                            strEDATA = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strEDATA = ""
                    End Try
                    

                    'Du lieu bao in/tap chi dien tu
                    strEMAGAZINE = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='EMAGAZINE'"
                        If tblData.DefaultView.Count > 0 Then
                            strEMAGAZINE = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strEMAGAZINE = ""
                    End Try


                    'Ranking 
                    strRANKING = "5"
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='RANKING'"
                        If tblData.DefaultView.Count > 0 Then
                            strRANKING = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strRANKING = "0"
                    End Try
                    

                    'Views
                    intViews = 0
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='VIEWS'"
                        If tblData.DefaultView.Count > 0 Then
                            intViews = tblData.DefaultView(0).Item("Content")
                        End If
                    Catch ex As Exception
                        intViews = 0
                    End Try
                    

                    intDownLoads = 0
                    Try
                        objBOpacItem.ItemID = CInt(arrIDs(intCount))
                        intDownLoads = objBOpacItem.GetCountDownLoad()
                    Catch ex As Exception
                        intDownLoads = 0
                    End Try


                    'Loai tai lieu
                    strType = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='ETYPE'"
                        If tblData.DefaultView.Count > 0 Then
                            strType = tblData.DefaultView(0).Item("Content") & ""
                        End If
                    Catch ex As Exception
                        strType = ""
                    End Try
                    

                    'Thu vien
                    strLibrary = ""
                    Try
                        If hidMutiLibrary.Value = "1" Then 'Hien thi tim kiem tren nhieu thu vien
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='LIBRARY'"
                            If tblData.DefaultView.Count > 0 Then
                                strLibrary = tblData.DefaultView(0).Item("Content") & ""
                            End If
                        End If
                    Catch ex As Exception
                        strLibrary = ""
                    End Try
                    

                    'Tom tat cho eBooks
                    strBrief = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='BRIEF'"
                        If tblData.DefaultView.Count > 0 Then
                            strArrBrief = Split(tblData.DefaultView(0).Item("Content") & "", "@PHUONGTT@")
                            Try
                                intPageLink = strArrBrief(0)
                                'strBrief = clsUICommon.sumaryContents(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>", 10, 50, 10, 40, , fCutContentLength)
                                strBrief = clsUICommon.sumaryContents(strArrBrief(1), "<span class=""hightlight-text"">", 10, 50, 10, 40, , fCutContentLength)

                                Dim strSearch As String = hidSearch.Value
                                strSearch = getCutVietnameseAccent(strSearch)
                                'strSearchFulltext = clsUICommon.getWordHightLight(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>", Len(strSearch))
                                'CutContents(strArrBrief(1), "<span style=""background-color:#60a917 !important;color:white;""><I>")
                                strSearchFulltext = clsUICommon.getWordHightLight(strArrBrief(1), "<span class=""hightlight-text"">", Len(strSearch))
                            Catch ex As Exception
                            End Try
                        End If
                    Catch ex As Exception
                        strBrief = ""
                    End Try
                    

                    'Ma xep gia
                    strMXG = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='MXG'"
                        If tblData.DefaultView.Count > 0 Then
                            Dim intCountMXG As Integer = 0
                            For Each rowView In tblData.DefaultView
                                If intCountMXG < Application("callNumberLimit") Then
                                    If Not IsDBNull(rowView.Item("Content")) Then
                                        'strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                                        '2016.05.11 B1
                                        If Not IsNothing(Request("txtSearch")) Then
                                            If Request("txtSearch").Trim.ToLower = rowView.Item("Content").ToString.Trim.ToLower Then
                                                strMXG &= "<U>" & "<span class=""hightlight-text"">" & rowView.Item("Content") & "</span>" & "</U>" & " "
                                            Else
                                                strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                                            End If
                                        Else
                                            strMXG &= "<U>" & rowView.Item("Content") & "</U>" & " "
                                        End If
                                        '2016.05.11 E1
                                    End If
                                Else
                                    strMXG &= "<a onclick='parent.showPopupDetail(" & arrIDs(intCount) & ")' style='cursor:pointer;'>" & "<span class=' icon-arrow-right-3'/>" & "</a> "
                                    Exit For
                                End If
                                intCountMXG += 1
                            Next
                        End If
                    Catch ex As Exception
                        strMXG = ""
                    End Try
                    

                    strCover = ""
                    Try
                        tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                        If tblData.DefaultView.Count > 0 Then
                            If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                                strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                            Else
                                strCover = "Images/Imgviet/Books.png"
                            End If
                        End If
                    Catch ex As Exception
                        strCover = ""
                    End Try
                    

                    'Fill data
                    If intCount Mod 2 Then
                        strResult &= "<li class=""item-second"">"
                    Else
                        strResult &= "<li>" 'Li1
                    End If

                    strResult &= "<div class=""item-box box-raised"">" 'Open Div1
                    If (strType = "Tài liệu điện tử") Or (strType = "Tài liệu số (Toàn văn)") Then
                        strResult &= "<h2 class=""clr-cyan-2""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                    Else
                        If strEDATA <> "" Then
                            strArr = Split(strEDATA, ";")
                            If UBound(strArr) = 3 Then
                                strResult &= "<h2 class=""clr-cyan-2""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                            Else
                                strResult &= "<h2 class=""clr-cyan""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                            End If
                        Else
                            strResult &= "<h2 class=""clr-cyan""><a onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;"">"
                        End If
                    End If

                    strResult &= strTitle
                    strResult &= "</a></h2>"
                    strResult &= "<div class=""item-info ClearFix"">" 'Open Div2
                    strResult &= "<div class=""item-img col-left-2 txt-center"">"  'item-img col-left-3
                    'strResult &= "<img src=""dbimg/s1.jpg"" alt=""Book Name""/>"
                    'strResult &= getIcons(arrIDs(intCount))
                    strResult &= "<img src='" & strCover & "' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "'>"

                    If strType = "Báo tạp chí" Then
                        strResult &= "<div class=""popup-modul"" style=""position:absolute"">"
                        'strResult &= "<span class=""popup-modul"">"
                        strResult &= "<a class=""btn-read"" onclick=""parent.showPopupDetail(" & arrIDs(intCount) & ")"" style=""cursor:pointer;font-size: 70%;""><div class=""icon-book""></div>" & spEDATAContent.InnerText & "</a>"
                        'strResult &= "</span>"
                        strResult &= "</div>"
                    End If

                    strResult &= "</div>"
                    strResult &= "<div class=""item-intro col-left-8"">" 'Open Div3 'item-intro col-right-7
                    'Thong tin tac gia
                    If strAuthor <> "" Then
                        strAuthor = strAuthor.Trim
                        strResult &= "<p><span>" & strBeginBoldTag & spAuthor.InnerText & strEndBoldTag
                        strResult &= strAuthor
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Thong tin mo ta vat ly
                    'If strDKCB <> "" Then
                    '    strResult &= "<p><span>" & strBeginBoldTag & spDKCBInfo.InnerText & strEndBoldTag
                    '    strResult &= strDKCB
                    '    strResult &= "</span>"
                    '    strResult &= "</p>"
                    'End If
                    'Thong tin so dinh danh
                    If strSoDinhDanh <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spSoDinhDanhInfo.InnerText & strEndBoldTag
                        strResult &= strSoDinhDanh
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Thong tin xuat ban
                    If strPublish <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spPublisherInfo.InnerText & strEndBoldTag
                        strResult &= strPublish
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Loai tai lieu
                    If strType <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spItemType.InnerText & strEndBoldTag
                        strResult &= strType
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Thong tin xep gia
                    If strMXG <> "" Then
                        strResult &= "<p><span>" & strBeginBoldTag & spMXG.InnerText & strEndBoldTag
                        strResult &= strMXG
                        strResult &= "</span>"
                        strResult &= "</p>"
                    End If
                    'Tu khoa spKeyWord
                    'If strKeyword <> "" Then
                    '    strResult &= "<p><span>" & strBeginBoldTag & spKeyWord.InnerText & strEndBoldTag
                    '    strResult &= strKeyword
                    '    strResult &= "</span>"
                    '    strResult &= "</p>"
                    'End If
                    ''Thong tin URL
                    'If strURL <> "" Then
                    '    strResult &= "<p><span>" & spURL.InnerText
                    '    strResult &= strURL
                    '    strResult &= "</span>"
                    '    strResult &= "</p>"
                    'End If

                    'Du lieu dien tu
                    If strEDATA <> "" Then
                        strArr = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            'strResult &= "<br/>"
                            'strResult &= "<span class='line-height'>"
                            'strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            'strResult &= "</span>"
                            ''strResult &= "<br/>"
                            'strResult &= "<p><span>" & spEDATA.InnerText
                            'strResult &= strURL
                            'strResult &= "</span>"
                            'strResult &= "</p>"
                            strResult &= "<span class=""item-img col-left"">"
                            strResult &= "<span class=""popup-modul"">"
                            strResult &= "<a class=""btn-read"" href=""OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & """>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                            strResult &= "</span>"
                            strResult &= "</span>"
                        End If
                    End If

                    'Du lieu bao in/tap chi dien tu
                    'If strEMAGAZINE <> "" Then
                    '    strResult &= "<span class=""item-img col-left"">"
                    '    strResult &= "<span class=""popup-modul"">"
                    '    strResult &= "<a class=""btn-read"" href=""OMagList.aspx?ItemId=" & arrIDs(intCount) & """>" & strEMAGAZINE & spEDATAContent.InnerText & "</a>"
                    '    strResult &= "</span>"
                    '    strResult &= "</span>"
                    'End If

                    'strResult &= "<h3><a href=""#""><span class=""mif-heart""></span>" & spSaveList.InnerText & "</a></h3>"

                    strResult &= "<div>" 'Close Div2
                    Dim strId As String = arrIDs(intCount) & ","
                    If InStr(clsSession.GlbMyListIds, strId) > 0 Then
                        strResult = "<h3 class=""uncheck"" id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart-broken"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spCancelList.InnerText & "</span></a></h3>"
                    Else
                        If (strType = "Tài liệu điện tử") Or (strType = "Tài liệu số (Toàn văn)") Then
                            strResult &= "<h3 class='clr-cyan-3' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                        Else
                            If strEDATA <> "" Then
                                strArr = Split(strEDATA, ";")
                                If UBound(strArr) = 3 Then
                                    strResult &= "<h3 class='clr-cyan-3' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                                Else
                                    strResult &= "<h3 class='clr-cyan-2' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                                End If
                            Else
                                strResult &= "<h3 class='clr-cyan-2' id=""h" & arrIDs(intCount) & """><a onclick='parent.checkMyList(" & arrIDs(intCount).ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & arrIDs(intCount) & """></span><span id=""spCart" & arrIDs(intCount) & """>" & spSaveList.InnerText & "</span></a></h3>"
                            End If
                        End If
                    End If

                    'strResult &= getIcons(arrIDs(intCount))

                    'Tom tat cho eBooks
                    If strBrief <> "" Then
                        strArr = Split(strEDATA, ";")
                        If UBound(strArr) = 3 Then
                            'strResult &= "<hr />"
                            'strResult &= "<div style='text-align:justify;font-style:italic;'>"
                            'strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                            'strResult &= "</div>"
                            strResult &= "<div class=""search-item""><p>"
                            strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                            strResult &= "</p></div>"
                        End If
                    End If

                    ''Thu vien muc luc lien hop
                    If strLibrary <> "" Then
                        strResult &= "<div style=""text-align:center;""><p>"
                        strResult &= "<span class='mif-layers mif-2x fg-emerald'></span>&nbsp;" & strLibrary
                        strResult &= "</p></div>"
                    End If

                    strResult &= "<div class=""more-detail ClearFix"">" 'Open Div4
                    strResult &= "<div class=""class"">" 'Open Div5

                    'strResult &= "<div class=""info-star"">" 'Open Div6
                    'Try
                    '    For kk As Integer = 1 To CInt(strRANKING)
                    '        If kk = 1 Then
                    '            strResult &= "<span class=""icon-star-4""></span>"
                    '        Else
                    '            strResult &= "<span class=""icon-star-3""></span>"
                    '        End If
                    '    Next
                    '    For kk As Integer = 5 To CInt(strRANKING) + 1 Step -1
                    '        strResult &= "<span class=""icon-star""></span>"
                    '    Next
                    'Catch ex As Exception

                    'End Try
                    ''strResult &= "<span class=""icon-star-" & strRANKING & """></span><span class=""icon-star-" & strRANKING & """></span><span class=""icon-star-" & strRANKING & """></span>"
                    ''strResult &= "<span class=""icon-star""></span><span class=""icon-star""></span>"
                    'strResult &= "</div>" 'Close Div6

                    'strResult &= "<div style=""vertical-align:top;text-align:center"" class=""rating"" data-size=""small"" data-role=""rating"" data-value=""" & strRANKING & """ data-static=""true"" data-show-score=""false"" data-size=""small""></div>"

                    strResult &= "</div>" 'Close Div5
                    'Randomize()
                    'intViewRandom = Int(10000 * Rnd(1) + 1)
                    'strResult &= "<div class=""col-right-6 view""><span class=""icon-eye-2""></span>" & FormatNumber(intViewRandom, 0) & "</div>"
                    If (strType = "Tài liệu điện tử") Or (strType = "Tài liệu số (Toàn văn)") Then
                        strResult &= "<div class=""view""><span class=""icon-download""></span>" & FormatNumber(intDownLoads, 0) & " <span class=""icon-eye-2""></span>" & FormatNumber(intViews, 0) & "</div>"
                    Else
                        If strEDATA <> "" Then
                            strArr = Split(strEDATA, ";")
                            If UBound(strArr) = 3 Then
                                strResult &= "<div class=""view""><span class=""icon-download""></span>" & FormatNumber(intDownLoads, 0) & " <span class=""icon-eye-2""></span>" & FormatNumber(intViews, 0) & "</div>"
                            Else
                                strResult &= "<div class=""view""><span class=""icon-eye-2""></span>" & FormatNumber(intViews, 0) & "</div>"
                            End If
                        Else
                            strResult &= "<div class=""view""><span class=""icon-eye-2""></span>" & FormatNumber(intViews, 0) & "</div>"
                        End If
                    End If
                    strResult &= "</div>" 'Close Div3
                    strResult &= "</div>" 'Close Div2
                    strResult &= "</div>" 'Close Div2

                    strResult &= "</div>" 'Close Div4                    
                    strResult &= "</div>" 'Close Div1
                    strResult &= "</li>" 'Close Li1

                    'strResult &= "<div class='panel-header'>"
                    'strResult &= "<a onclick='parent.showPopupDetail(" & arrIDs(intCount) & ")' class='lblinkfunction' style='cursor:pointer;'>" & strTitle & "</a> "
                    'strResult &= getIcons(arrIDs(intCount))
                    'strResult &= "</div>"
                    'strResult &= "<div class='panel-content'>"

                    'strResult &= "<div class='grid no-margin'>"
                    'strResult &= "<div class='row'>"

                    'strResult &= "<div class='span2'>"
                    '' strResult &= "<div class='notice  marker-on-right'>"
                    ''Anh Bia
                    'strResult &= "<div>"
                    'strCover = ""
                    'tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND  Field='COVER'"
                    'If tblData.DefaultView.Count > 0 Then
                    '    If Not IsDBNull(tblData.DefaultView(0).Item("Content")) AndAlso tblData.DefaultView(0).Item("Content") <> "" Then
                    '        strCover = Me.getEDataPATH & tblData.DefaultView(0).Item("Content")
                    '    Else
                    '        strCover = "Images/Imgviet/Books.png"
                    '    End If
                    'End If
                    'strResult &= "<img src='" & strCover & "' class='rounded' id='" & arrIDs(intCount) & "' name='" & arrIDs(intCount) & "' style='z-index:1001;cursor:pointer;' onclick='parent.showPopupDetail(" & arrIDs(intCount) & ")'>"
                    'strResult &= "</div>"
                    ''strResult &= "</div>"
                    'strResult &= "</div>"

                    'strResult &= "<div class='span10'>"
                    ''Thong tin ISSN
                    'If strISSN <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spISSN.InnerText & ":</strong> " & strISSN
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    ''Thong tin tac gia
                    'If strAuthor <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spAuthor.InnerText & ":</strong> " & strAuthor
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    ''Thong tin mo ta vat ly
                    'If strDKCB <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spPhysicalInfo.InnerText & ":</strong> " & strDKCB
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If
                    ''Thong tin xuat ban
                    'If strPublish <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spPublisherInfo.InnerText & ":</strong> " & strPublish
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    ''Loai tai lieu
                    'If strType <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spItemType.InnerText & ":</strong> " & strType
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    ''strMXG
                    'If strMXG <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spMXG.InnerText & ":</strong> " & strMXG
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    ''Thong tin URL
                    'If strURL <> "" Then
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spURL.InnerText & ":</strong> " & strURL
                    '    strResult &= "</span>"
                    '    strResult &= "<br/>"
                    'End If

                    ''Du lieu dien tu
                    'If strEDATA <> "" Then
                    '    strArr = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        strResult &= "<br/>"
                    '        strResult &= "<span class='line-height'>"
                    '        strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OViewLoading.aspx?pageno=1&fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "'>" & strArr(0) & spEDATAContent.InnerText & "</a>"
                    '        strResult &= "</span>"
                    '        'strResult &= "<br/>"
                    '    End If
                    'End If

                    ''Du lieu bao in/tap chi dien tu
                    'If strEMAGAZINE <> "" Then
                    '    strResult &= "<br/>"
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<strong>" & spEDATA.InnerText & ":</strong><a href='OMagList.aspx?ItemId=" & arrIDs(intCount) & "'>" & strEMAGAZINE & spEDATAContent.InnerText & "</a>"
                    '    strResult &= "</span>"
                    '    'strResult &= "<br/>"
                    'End If

                    ''Ranking
                    'If strRANKING <> "" Then
                    '    strResult &= "<br/>"
                    '    strResult &= "<div class='rating  fg-green small' data-role='rating' data-static='true' data-score='" & strRANKING & "'  data-stars='5' data-show-score='false' style='cursor:default;' >"
                    '    strResult &= "</div>"
                    'End If

                    ''Thu vien muc luc lien hop
                    'If strLibrary <> "" Then
                    '    strResult &= "<br/>"
                    '    strResult &= "<span class='line-height'>"
                    '    strResult &= "<i class='icon-layers'></i>&nbsp;<B><I>" & strLibrary & "</I></B>"
                    '    strResult &= "</span>"
                    'End If

                    ''Tom tat cho eBooks
                    'If strBrief <> "" Then
                    '    strArr = Split(strEDATA, ";")
                    '    If UBound(strArr) = 3 Then
                    '        strResult &= "<hr />"
                    '        strResult &= "<div style='text-align:justify;font-style:italic;'>"
                    '        strResult &= "<a href='OViewLoading.aspx?fileType=" & strArr(1) & "&fileId=" & strArr(2) & "&ItemId=" & strArr(3) & "&pageno=" & intPageLink & "&fulltext=" & strSearchFulltext & "'>" & spPageLink.InnerHtml & Space(1) & intPageLink & "</a>&nbsp;" & strBrief
                    '        strResult &= "</div>"
                    '    End If
                    'End If

                    'strResult &= "</div>" 'div span10
                    'strResult &= "</div>" 'div grid no-margin
                    'strResult &= "</div>" 'div row
                    'strResult &= "</div>" 'div panel-content
                Next
                ltrBookList.Text = strResult
            End If
        End Sub

        'Private Function HighlightContents(ByVal _Contents As String, ByVal _SearchText As String, Optional ByVal _MinPrefixLength As Integer = 20, Optional ByVal _MaxPrefixLength As Integer = 100, Optional ByVal _MinAfterLength As Integer = 20, Optional ByVal _MaxAfterLength As Integer = 80, Optional ByVal _bolBold As Boolean = False) As String
        '    Dim _str As String = "..."
        '    Dim _strPrefix As String = ""
        '    Dim _strAfterfix As String = ""
        '    Try
        '        Dim _WordPrefix As String = ""
        '        Dim _WordAfterfix As String = ""
        '        Dim _posWord As Integer = 0
        '        _posWord = InStr(_Contents.ToLower, _SearchText.ToLower)
        '        If _posWord > 0 Then
        '            _WordPrefix = _Contents.Substring(0, _posWord - 1)
        '            _strPrefix = CutPrefixContents(_WordPrefix, _MinPrefixLength, _MaxPrefixLength)
        '            _WordAfterfix = _Contents.Substring(_posWord - 1, _Contents.Length - (_posWord + 1))
        '            _strAfterfix = CutAfterWords(_WordAfterfix, _MinAfterLength, _MaxAfterLength)
        '        Else
        '            _str = CutPrefixContents(_Contents, _MinPrefixLength * 2, _MaxPrefixLength * 2)
        '        End If
        '        _str &= _strPrefix & _strAfterfix
        '        '_str = Change_AV(_str)
        '        If _bolBold Then
        '            _str = Regex.Replace(_str, "(" & _SearchText & ")", "<B>$1</B>", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        '        Else
        '            _str = Regex.Replace(_str, "(" & _SearchText & ")", "<span style=""background:silver;""><i>$1</i></span>", RegexOptions.Singleline Or RegexOptions.IgnoreCase)
        '        End If
        '        _str = Trim(_str)
        '    Catch ex As Exception

        '    End Try
        '    Return _str
        'End Function

        'Private Function CutContents(ByVal _Contents As String, ByVal _SearchText As String, Optional ByVal _MinPrefixLength As Integer = 10, Optional ByVal _MaxPrefixLength As Integer = 50, Optional ByVal _MinAfterLength As Integer = 10, Optional ByVal _MaxAfterLength As Integer = 40, Optional ByVal _bolBold As Boolean = False) As String
        '    Dim _str As String = "..."
        '    Dim _strPrefix As String = ""
        '    Dim _strAfterfix As String = ""
        '    Try
        '        Dim _WordPrefix As String = ""
        '        Dim _WordAfterfix As String = ""
        '        Dim _posWord As Integer = 0
        '        _posWord = InStr(_Contents.ToLower, _SearchText.ToLower)
        '        If _posWord > 0 Then
        '            _WordPrefix = _Contents.Substring(0, _posWord - 1)
        '            _strPrefix = CutPrefixContents(_WordPrefix, _MinPrefixLength, _MaxPrefixLength)
        '            _WordAfterfix = _Contents.Substring(_posWord - 1, _Contents.Length - (_posWord + 1))
        '            _strAfterfix = CutAfterWords(_WordAfterfix, _MinAfterLength, _MaxAfterLength)
        '        Else
        '            _str = CutPrefixContents(_Contents, _MinPrefixLength * 2, _MaxPrefixLength * 2)
        '        End If
        '        _str &= _strPrefix & _strAfterfix
        '        _str = Trim(_str)
        '    Catch ex As Exception

        '    End Try
        '    Return _str
        'End Function

        'Private Function Change_AV(ByVal ip_str_change As String) As String
        '    Dim v_reg_regex As New Regex("\p{IsCombiningDiacriticalMarks}+")
        '    Dim v_str_FormD As String = ip_str_change.Normalize(System.Text.NormalizationForm.FormD)
        '    Return v_reg_regex.Replace(v_str_FormD, [String].Empty).Replace("đ"c, "d"c).Replace("Đ"c, "D"c)
        'End Function

        'Private Function CutPrefixContents(ByVal _words As String, ByVal _MinCutWords As Integer, ByVal _MaxCutWords As Integer) As String
        '    Dim _str As String = ""
        '    Try

        '        Dim _cutWord As String = ""
        '        Dim _arrWord() As String = Nothing
        '        Dim _bol As Boolean = False
        '        _cutWord = _words
        '        '( )|( ) la 2 ky tu khoang trang khac nhau
        '        Dim pattern As String = "( )|( )"
        '        _arrWord = Regex.Split(_cutWord, pattern)
        '        _bol = False
        '        _str = ""
        '        Randomize()
        '        Dim _CountCutWordsRnd As Integer = Int(_MaxCutWords * Rnd(1) + 1) + _MinCutWords
        '        Dim _posEnd As Integer = UBound(_arrWord)
        '        If _CountCutWordsRnd >= _posEnd Then
        '            _CountCutWordsRnd = 0
        '            _bol = True
        '        Else
        '            _CountCutWordsRnd = _posEnd - _CountCutWordsRnd
        '        End If
        '        For i As Integer = _posEnd To _CountCutWordsRnd Step -1
        '            If _arrWord(i).Trim <> "" Then
        '                _str = _arrWord(i).Trim & " " & _str
        '            End If
        '        Next
        '        If Not _bol Then
        '            _str = "..." & _str
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    Return _str
        'End Function

        'Private Function CutAfterWords(ByVal _words As String, ByVal _MinCutWords As Integer, ByVal _MaxCutWords As Integer) As String
        '    Dim _str As String = ""
        '    Try
        '        Dim _cutWord As String = ""
        '        Dim _arrWord() As String = Nothing
        '        Dim _bol As Boolean = False
        '        _cutWord = _words
        '        Dim pattern As String = "( )|( )"
        '        _arrWord = Regex.Split(_cutWord, pattern)
        '        _bol = False
        '        _str = ""
        '        Randomize()
        '        Dim _CountCutWordsRnd As Integer = Int(_MaxCutWords * Rnd(1) + 1) + _MinCutWords + fCutContentLength
        '        Dim _posEnd As Integer = UBound(_arrWord)
        '        If _CountCutWordsRnd >= _posEnd Then
        '            _CountCutWordsRnd = _posEnd
        '            _bol = True
        '        End If
        '        For i As Integer = 0 To _CountCutWordsRnd
        '            If _arrWord(i).Trim <> "" Then
        '                _str &= _arrWord(i).Trim & " "
        '            End If
        '        Next
        '        If Not _bol Then
        '            _str &= "..."
        '        End If
        '    Catch ex As Exception

        '    End Try
        '    Return _str
        'End Function

        ' Dispose method
        ' Purpose: get icon and set to header panel
        Private Function getIcons(ByVal iTem As Integer) As String
            Dim strResult As String = ""
            Try
                Dim strId As String = iTem & ","
                If InStr(clsSession.GlbMyListIds, strId) > 0 Then
                    'strResult = "<a class='element place-right' onclick='#'><span class='icon-checkmark' id='icon" & iTem & "' data-hint='|" & spInMyList.InnerText & "' data-hint-position='top'></span></a>"
                    strResult = "<h3 class=""uncheck"" id=""h" & iTem & """><a onclick='parent.checkMyList(" & iTem.ToString & ")' style=""cursor:pointer;""><span class=""mif-heart-broken"" id=""icon" & iTem & """></span><span id=""spCart" & iTem & """>" & spCancelList.InnerText & "</span></a></h3>"
                Else
                    strResult = "<h3 id=""h" & iTem & """><a onclick='parent.checkMyList(" & iTem.ToString & ")' style=""cursor:pointer;""><span class=""mif-heart"" id=""icon" & iTem & """></span><span id=""spCart" & iTem & """>" & spSaveList.InnerText & "</span></a></h3>"
                    'strResult = "<a class='element place-right' onclick='addMyList(" & iTem.ToString & ")'><span class='icon-plus' id='icon" & iTem & "' style='cursor:pointer;' data-hint='|" & spAddToMyList.InnerText & "' data-hint-position='top'></span></a>"
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' Dispose method
        ' Purpose: get item lists from session
        Private Sub getMyListItems()
            Try
                'hidMyListIds.Value = clsSession.GlbMyListIds
            Catch ex As Exception
            End Try
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBFilterBrowse Is Nothing Then
                    objBFilterBrowse.Dispose(True)
                    objBFilterBrowse = Nothing
                End If
                If Not objBSearchQr Is Nothing Then
                    objBSearchQr.Dispose(True)
                    objBSearchQr = Nothing
                End If
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
                If Not objBOpacItem Is Nothing Then
                    objBOpacItem.Dispose(True)
                    objBOpacItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub



    End Class
End Namespace
