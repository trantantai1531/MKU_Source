Imports System.IO
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports Aspose.Words

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBFiche
        Inherits clsBBase

        ' Declare variables
        Private objDFiche As New clsDFiche
        Private objBString As New clsBCommonStringProc
        Private objBComDB As New clsBCommonDBSystem
        Private objBTemplate As New clsBTemplate
        Private objBInput As New clsBInput
        Private objBCT As New clsBCommonTemplate

        Private intItemType As Integer = 0
        Private strCopyNumFrom As String = ""
        Private strCopyNumTo As String = ""
        Private strItemCodes As String = ""
        Private bytMultiFiche As Byte = 0
        Private intItemIDFrom As Integer = 0
        Private intItemIDTo As Integer = 0
        Private intLibID As Integer = 0
        Private intLocID As Integer = 0
        Private bytNewItemOnly As Byte = 0
        Private strOUT As String = ""
        Private strTagSort As String
        Private strIDTemplate As String
        Private intPageSize As Integer = 5
        Private strInitTag As String = "001,900,907,911,912,925,926,927,id,leader,no,curday,curmonth,curyear,"

        Private strItemCodeFrom As String = ""
        Private strItemCodeTo As String = ""

        Public TblItem As New DataTable
        Public TblHolding As New DataTable
        Public TblField As New DataTable
        Public a As String

        ' PageSize property
        Public Property PageSize() As Integer
            Get
                Return intPageSize
            End Get
            Set(ByVal Value As Integer)
                intPageSize = Value
            End Set
        End Property

        ' IDTempate property
        Public Property IDTempate() As String
            Get
                Return strIDTemplate
            End Get
            Set(ByVal Value As String)
                strIDTemplate = Value
            End Set
        End Property

        ' TagSort property
        Public Property TagSort() As String
            Get
                Return strTagSort
            End Get
            Set(ByVal Value As String)
                strTagSort = Value
            End Set
        End Property

        ' SQLOUT property
        Public ReadOnly Property SQLOUT() As String
            Get
                Return strOUT
            End Get
        End Property

        ' ItemType property
        Public Property ItemType() As Integer
            Get
                Return intItemType
            End Get
            Set(ByVal Value As Integer)
                intItemType = Value
            End Set
        End Property

        ' CopyNumFrom property
        Public Property CopyNumFrom() As String
            Get
                Return strCopyNumFrom
            End Get
            Set(ByVal Value As String)
                strCopyNumFrom = Value
            End Set
        End Property

        ' CopyNumTo property
        Public Property CopyNumTo() As String
            Get
                Return strCopyNumTo
            End Get
            Set(ByVal Value As String)
                strCopyNumTo = Value
            End Set
        End Property

        ' CopyNums property
        Public Property ItemCodes() As String
            Get
                Return strItemCodes
            End Get
            Set(ByVal Value As String)
                strItemCodes = Value
            End Set
        End Property

        ' MultiFiche property
        Public Property MultiFiche() As Byte
            Get
                Return bytMultiFiche
            End Get
            Set(ByVal Value As Byte)
                bytMultiFiche = Value
            End Set
        End Property

        ' ItemIDFrom property
        Public Property ItemIDFrom() As Integer
            Get
                Return intItemIDFrom
            End Get
            Set(ByVal Value As Integer)
                intItemIDFrom = Value
            End Set
        End Property

        ' ItemIDTo property
        Public Property ItemIDTo() As Integer
            Get
                Return intItemIDTo
            End Get
            Set(ByVal Value As Integer)
                intItemIDTo = Value
            End Set
        End Property

        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        ' LocID property
        Public Property LocID() As Integer
            Get
                Return intLocID
            End Get
            Set(ByVal Value As Integer)
                intLocID = Value
            End Set
        End Property

        ' NewItemOnly property
        Public Property NewItemOnly() As Byte
            Get
                Return bytNewItemOnly
            End Get
            Set(ByVal Value As Byte)
                bytNewItemOnly = Value
            End Set
        End Property

        Public Property ItemCodeFrom() As String
            Get
                Return strItemCodeFrom
            End Get
            Set(ByVal Value As String)
                strItemCodeFrom = Value
            End Set
        End Property

        ' ItemIDTo property
        Public Property ItemCodeTo() As String
            Get
                Return strItemCodeTo
            End Get
            Set(ByVal Value As String)
                strItemCodeTo = Value
            End Set
        End Property

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                objBString.DBServer = strDBserver
                objBString.InterfaceLanguage = strInterfaceLanguage
                objBString.ConnectionString = strConnectionString
                objBString.Initialize()

                objBComDB.DBServer = strDBServer
                objBComDB.InterfaceLanguage = strInterfaceLanguage
                objBComDB.ConnectionString = strConnectionString
                objBComDB.Initialize()

                objDFiche.DBServer = strDBServer
                objDFiche.ConnectionString = strConnectionString
                objDFiche.Initialize()

                objBTemplate.DBServer = strDBServer
                objBTemplate.InterfaceLanguage = strInterfaceLanguage
                objBTemplate.ConnectionString = strConnectionString
                objBTemplate.Initialize()

                objBInput.DBServer = strDBServer
                objBInput.InterfaceLanguage = strInterfaceLanguage
                objBInput.ConnectionString = strConnectionString
                objBInput.Initialize()

                ' Init objBCT object
                objBCT.ConnectionString = strConnectionString
                objBCT.DBServer = strDBServer
                objBCT.InterfaceLanguage = strInterfaceLanguage
                Call objBCT.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Retrieve_ItemID method
        Public Function Retrieve_ItemID() As DataTable
            Try
                objDFiche.CopyNumFrom = objBString.ConvertItBack(strCopyNumFrom)
                objDFiche.CopyNumTo = objBString.ConvertItBack(strCopyNumTo)
                objDFiche.ItemIDFrom = intItemIDFrom
                objDFiche.ItemIDTo = intItemIDTo
                objDFiche.ItemType = intItemType
                objDFiche.LibID = intLibID
                objDFiche.LocID = intLocID
                objDFiche.MultiFiche = bytMultiFiche
                objDFiche.NewItemOnly = bytNewItemOnly
                Retrieve_ItemID = objBComDB.ConvertTable(objDFiche.Retrieve_ItemID)
                strOUT = objDFiche.SQLOUT
                strErrorMsg = objBComDB.ErrorMsg
                intErrorCode = objBComDB.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Retrieve_ItemCode method
        Public Function Retrieve_ItemCode() As DataTable
            Try
                objDFiche.CopyNumFrom = objBString.ConvertItBack(strCopyNumFrom)
                objDFiche.CopyNumTo = objBString.ConvertItBack(strCopyNumTo)
                objDFiche.ItemCodes = objBString.ConvertItBack(strItemCodes)
                objDFiche.ItemIDFrom = intItemIDFrom
                objDFiche.ItemIDTo = intItemIDTo
                objDFiche.ItemCodeFrom = strItemCodeFrom
                objDFiche.ItemCodeTo = strItemCodeTo
                objDFiche.ItemType = intItemType
                objDFiche.LibID = intLibID
                objDFiche.LocID = intLocID
                objDFiche.MultiFiche = bytMultiFiche
                objDFiche.NewItemOnly = bytNewItemOnly
                Retrieve_ItemCode = objBComDB.ConvertTable(objDFiche.Retrieve_ItemCode)
                strOUT = objDFiche.SQLOUT
                strErrorMsg = objBComDB.ErrorMsg
                intErrorCode = objBComDB.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Generate_IDSort
        Public Function Generate_IDSort() As Object
            'Dim objSort As New TVCOMLib.utf8
            Dim arrIndex()
            Dim arrRet()
            Dim arrTag()
            Dim arrItemID()
            Dim arrSortVal()
            Dim arrSubVal()
            Dim tblItemID As New DataTable
            Dim tblItemSort As New DataTable
            Dim intCount As Integer
            Dim strSortCon As String
            Dim strSortField As String
            Dim strSortTabs As String
            Dim strSortSQL As String
            Dim strTag As String
            Dim intm As Integer
            Dim rowi() As DataRow
            Dim strSortVal As String

            strSortSQL = ""
            tblItemID = Me.Retrieve_ItemID
            'a = tblItemID.Rows.Count & "--"
            If Not tblItemID Is Nothing AndAlso tblItemID.Rows.Count > 0 Then
                arrTag = Split(strTagSort, ",")
                For intCount = 0 To UBound(arrTag)
                    strSortCon = ""
                    strTagSort = ""
                    strSortField = ""
                    If Len(Trim(arrTag(intCount))) = 3 Or (Len(Trim(arrTag(intCount))) = 5 And InStr(Trim(arrTag(intCount)), "$") = 4) Then
                        strTag = Left(arrTag(intCount), 3)
                        Select Case strTag
                            Case "001"
                                strSortField = "Code AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "911"
                                strSortField = "Reviewer AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "912"
                                strSortField = "Cataloguer AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "925"
                                strSortField = "MediumID AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "926"
                                strSortField = "AccessLevel AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "927"
                                strSortField = "TypeID AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case Else
                                Select Case strDBServer
                                    Case "ORACLE"
                                        strSortField = "Content, NVL(Ind1,'') AS Ind1"
                                    Case Else
                                        strSortField = "Content, ISNULL(Ind1,'') AS Ind1"
                                End Select
                                strSortTabs = "Lib_tblField" & Left(strTag, 1) & "00s,Lib_tblMARCBibField"
                                strSortCon = " AND Lib_tblMARCBibField.FieldCode = '" & Trim(arrTag(intCount)) & "'"
                        End Select
                        If strSortField <> "" And strSortTabs <> "" Then
                            Select Case strDBServer
                                Case "ORACLE"
                                    strSortSQL = strSortSQL & " SELECT ItemID, " & strSortField & ", '" & Trim(arrTag(intCount)) & "' AS Tag FROM " & strSortTabs & " WHERE ROWNUM<=100000 AND ItemID IN (" & strOUT & ")" & strSortCon & " UNION"
                                Case Else
                                    strSortSQL = strSortSQL & " SELECT TOP 100000 ItemID, " & strSortField & ", '" & Trim(arrTag(intCount)) & "' AS Tag FROM " & strSortTabs & " WHERE ItemID IN (" & strOUT & ")" & strSortCon & " UNION"
                            End Select
                        End If
                    Else
                        arrTag(intCount) = ""
                    End If
                Next
                If strSortSQL <> "" Then
                    strSortSQL = Left(strSortSQL, Len(strSortSQL) - 6)
                End If
            End If
            objBComDB.SQLStatement = strSortSQL
            'Generate_IDSort = strSortSQL
            'Exit Function
            tblItemSort = objBComDB.RetrieveItemInfor
            If Not tblItemSort Is Nothing AndAlso tblItemSort.Rows.Count > 0 Then
                ReDim arrItemID(tblItemID.Rows.Count - 1)
                ReDim arrSortVal(tblItemID.Rows.Count - 1)

                For intCount = 0 To tblItemID.Rows.Count - 1
                    If bytMultiFiche = 1 Then
                        arrItemID(intCount) = tblItemID.Rows(intCount).Item("ItemID")
                        If Not IsDBNull(tblItemID.Rows(intCount).Item("LibID")) Then
                            arrItemID(intCount) = arrItemID(intCount) & ":" & tblItemID.Rows(intCount).Item("LibID")
                        Else
                            arrItemID(intCount) = arrItemID(intCount) & ":NULL"
                        End If
                        If Not IsDBNull(tblItemID.Rows(intCount).Item("LocationID")) Then
                            arrItemID(intCount) = arrItemID(intCount) & ":" & tblItemID.Rows(intCount).Item("LocationID")
                        Else
                            arrItemID(intCount) = arrItemID(intCount) & ":NULL"
                        End If
                    Else
                        arrItemID(intCount) = tblItemID.Rows(intCount).Item("ItemID")
                    End If

                    If strSortSQL <> "" Then
                        arrSortVal(intCount) = ""
                        For intm = LBound(arrTag) To UBound(arrTag)
                            If arrTag(intm) <> "" Then
                                rowi = tblItemSort.Select("ItemID=" & tblItemID.Rows(intCount).Item("ItemID") & " AND Tag='" & arrTag(intm) & "'")
                                If rowi.GetUpperBound(0) > -1 Then
                                    strSortVal = objBString.TheSortOne(rowi(0).Item("Content"))
                                    If Len(arrTag(intm)) > 3 Then
                                        objBString.ParseField(Right(arrTag(intm), 2), strSortVal, "tr" & Chr(9), arrSubVal)
                                        strSortVal = arrSubVal(0)
                                    Else
                                        strSortVal = objBString.TrimSubFieldCodes(strSortVal)
                                    End If
                                    If Left(arrTag(intm), 3) = "245" Then
                                        Try
                                            If Not IsDBNull(rowi(0).Item("Ind1")) AndAlso Len(Trim(rowi(0).Item("Ind1"))) = 2 Then
                                                If IsNumeric(Right(rowi(0).Item("Ind1"), 1)) Then
                                                    strSortVal = Right(strSortVal, Len(strSortVal) - CInt(Right(rowi(0).Item("Ind1"), 1)))
                                                End If
                                            End If
                                        Catch ex As Exception
                                            strSortVal = ""
                                        End Try
                                    End If
                                    If arrSortVal(intCount) <> "" Then
                                        arrSortVal(intCount) = arrSortVal(intCount) & Chr(9) & Trim(strSortVal)
                                    Else
                                        arrSortVal(intCount) = Trim(strSortVal)
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                ' use TVCOM to sort DATA
                'arrIndex = objSort.SortIndex(arrSortVal, 1)
                arrIndex = objBString.SortIndexDictionary(arrSortVal, 1)

                ReDim arrRet(UBound(arrIndex))
                ' Genatate array Sort.
                For intCount = LBound(arrIndex) To UBound(arrIndex)
                    arrRet(intCount) = arrItemID(arrIndex(intCount))
                Next
                'objSort = Nothing
            End If
            Generate_IDSort = arrRet
        End Function
        ' Generate_CodeSort
        Public Function Generate_CodeSort() As Object
            'Dim objSort As New TVCOMLib.utf8
            Dim arrIndex()
            Dim arrRet()
            Dim arrTag()
            Dim arrItemID()
            Dim arrSortVal()
            Dim arrSubVal()
            Dim tblItemID As New DataTable
            Dim tblItemSort As New DataTable
            Dim intCount As Integer
            Dim strSortCon As String
            Dim strSortField As String
            Dim strSortTabs As String
            Dim strSortSQL As String
            Dim strTag As String
            Dim intm As Integer
            Dim rowi() As DataRow
            Dim strSortVal As String

            strSortSQL = ""
            tblItemID = Me.Retrieve_ItemCode
            'a = tblItemID.Rows.Count & "--"
            If Not tblItemID Is Nothing AndAlso tblItemID.Rows.Count > 0 Then
                arrTag = Split(strTagSort, ",")
                For intCount = 0 To UBound(arrTag)
                    strSortCon = ""
                    strTagSort = ""
                    strSortField = ""
                    If Len(Trim(arrTag(intCount))) = 3 Or (Len(Trim(arrTag(intCount))) = 5 And InStr(Trim(arrTag(intCount)), "$") = 4) Then
                        strTag = Left(arrTag(intCount), 3)
                        Select Case strTag
                            Case "001"
                                strSortField = "Code AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "911"
                                strSortField = "Reviewer AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "912"
                                strSortField = "Cataloguer AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "925"
                                strSortField = "MediumID AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "926"
                                strSortField = "AccessLevel AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case "927"
                                strSortField = "TypeID AS Value, '' AS Indicators"
                                strSortTabs = "Lib_tblItem"
                            Case Else
                                Select Case strDBServer
                                    Case "ORACLE"
                                        strSortField = "Content, NVL(Ind1,'') AS Ind1"
                                    Case Else
                                        strSortField = "Content, ISNULL(Ind1,'') AS Ind1"
                                End Select
                                strSortTabs = "Lib_tblField" & Left(strTag, 1) & "00s,Lib_tblMARCBibField"
                                strSortCon = " AND Lib_tblMARCBibField.FieldCode = '" & Trim(arrTag(intCount)) & "'"
                        End Select
                        If strSortField <> "" And strSortTabs <> "" Then
                            Select Case strDBServer
                                Case "ORACLE"
                                    strSortSQL = strSortSQL & " SELECT ItemID, " & strSortField & ", '" & Trim(arrTag(intCount)) & "' AS Tag FROM " & strSortTabs & " WHERE ROWNUM<=100000 AND ItemID IN (" & strOUT & ")" & strSortCon & " UNION"
                                Case Else
                                    strSortSQL = strSortSQL & " SELECT TOP 100000 ItemID, " & strSortField & ", '" & Trim(arrTag(intCount)) & "' AS Tag FROM " & strSortTabs & " WHERE ItemID IN (" & strOUT & ")" & strSortCon & " UNION"
                            End Select
                        End If
                    Else
                        arrTag(intCount) = ""
                    End If
                Next
                If strSortSQL <> "" Then
                    strSortSQL = Left(strSortSQL, Len(strSortSQL) - 6)
                End If
            End If
            objBComDB.SQLStatement = strSortSQL
            'Generate_IDSort = strSortSQL
            'Exit Function
            tblItemSort = objBComDB.RetrieveItemInfor
            If Not tblItemSort Is Nothing AndAlso tblItemSort.Rows.Count > 0 Then
                ReDim arrItemID(tblItemID.Rows.Count - 1)
                ReDim arrSortVal(tblItemID.Rows.Count - 1)

                For intCount = 0 To tblItemID.Rows.Count - 1
                    If bytMultiFiche = 1 Then
                        arrItemID(intCount) = tblItemID.Rows(intCount).Item("ItemID")
                        If Not IsDBNull(tblItemID.Rows(intCount).Item("LibID")) Then
                            arrItemID(intCount) = arrItemID(intCount) & ":" & tblItemID.Rows(intCount).Item("LibID")
                        Else
                            arrItemID(intCount) = arrItemID(intCount) & ":NULL"
                        End If
                        If Not IsDBNull(tblItemID.Rows(intCount).Item("LocationID")) Then
                            arrItemID(intCount) = arrItemID(intCount) & ":" & tblItemID.Rows(intCount).Item("LocationID")
                        Else
                            arrItemID(intCount) = arrItemID(intCount) & ":NULL"
                        End If
                    Else
                        arrItemID(intCount) = tblItemID.Rows(intCount).Item("ItemID")
                    End If

                    If strSortSQL <> "" Then
                        arrSortVal(intCount) = ""
                        For intm = LBound(arrTag) To UBound(arrTag)
                            If arrTag(intm) <> "" Then
                                rowi = tblItemSort.Select("ItemID=" & tblItemID.Rows(intCount).Item("ItemID") & " AND Tag='" & arrTag(intm) & "'")
                                If rowi.GetUpperBound(0) > -1 Then
                                    strSortVal = objBString.TheSortOne(rowi(0).Item("Content"))
                                    If Len(arrTag(intm)) > 3 Then
                                        objBString.ParseField(Right(arrTag(intm), 2), strSortVal, "tr" & Chr(9), arrSubVal)
                                        strSortVal = arrSubVal(0)
                                    Else
                                        strSortVal = objBString.TrimSubFieldCodes(strSortVal)
                                    End If
                                    If Left(arrTag(intm), 3) = "245" Then
                                        Try
                                            If Not IsDBNull(rowi(0).Item("Ind1")) AndAlso Len(Trim(rowi(0).Item("Ind1"))) = 2 Then
                                                If IsNumeric(Right(rowi(0).Item("Ind1"), 1)) Then
                                                    strSortVal = Right(strSortVal, Len(strSortVal) - CInt(Right(rowi(0).Item("Ind1"), 1)))
                                                End If
                                            End If
                                        Catch ex As Exception
                                            strSortVal = ""
                                        End Try
                                    End If
                                    If arrSortVal(intCount) <> "" Then
                                        arrSortVal(intCount) = arrSortVal(intCount) & Chr(9) & Trim(strSortVal)
                                    Else
                                        arrSortVal(intCount) = Trim(strSortVal)
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                ' use TVCOM to sort DATA
                'arrIndex = objSort.SortIndex(arrSortVal, 1)
                arrIndex = objBString.SortIndexDictionary(arrSortVal, 1)

                ReDim arrRet(UBound(arrIndex))
                ' Genatate array Sort.
                For intCount = LBound(arrIndex) To UBound(arrIndex)
                    arrRet(intCount) = arrItemID(arrIndex(intCount))
                Next
                'objSort = Nothing
            End If
            Generate_CodeSort = arrRet
        End Function

        ' Generate_DataTable method
        Public Sub Generate_DataTable(ByVal intPage As Integer, ByVal arrID As Object, Optional ByVal blnAll As Boolean = False)
            Dim arrField()
            Dim arrSQL() As String
            ReDim arrSQL(3)
            Dim arrI()
            Dim tblTemplate As New DataTable
            Dim strContentTemp As String
            Dim strHeader As String
            Dim strFooter As String
            Dim strBody As String
            'Dim objTVTemplate As New TVCOMLib.LibolTemplate
            Dim intCount As Integer
            Dim strTabs As String
            Dim bytTab25 As Byte
            Dim strUnionSql As String
            Dim intHolding As Integer
            Dim strTag As String
            Dim strIDs As String
            Dim intFrom As Integer
            Dim intTo As Integer
            Dim strContent As String

            If blnAll Then
                intFrom = 0
                intTo = UBound(arrID) - 1
            Else
                intFrom = (intPage - 1) * intPageSize
                intTo = intPage * intPageSize - 1
            End If

            For intCount = intFrom To intTo
                If intCount > UBound(arrID) Then
                    Exit For
                End If
                If bytMultiFiche = 1 Then
                    arrI = Split(arrID(intCount), ":")
                    strIDs = strIDs & arrI(0) & ","
                Else
                    strIDs = strIDs & arrID(intCount) & ","
                End If
            Next intCount
            If strIDs <> "" Then
                strIDs = "(" & Left(strIDs, Len(strIDs) - 1) & ")"
                objBTemplate.Type = 15
                objBTemplate.IDs = strIDTemplate
                tblTemplate = objBTemplate.GetTemplates
                '
                If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                    strContentTemp = tblTemplate.Rows(0).Item("Content")
                    If InStr(strContentTemp, "<!--Page header-->") > 0 And InStr(strContentTemp, "<!--Page footer-->") > 0 Then
                        strBody = Mid(strContentTemp, InStr(strContentTemp, "<!--Page header-->") + 18, InStr(strContentTemp, "<!--Page footer-->") - InStr(strContentTemp, "<!--Page header-->") - 18)
                    Else
                        strBody = strContentTemp
                    End If
                    strTabs = ""
                    bytTab25 = 0
                    strUnionSql = ""
                    intHolding = 0
                    arrSQL(1) = "Lib_tblItem.ID AS ItemID,"
                    'objTVTemplate.Template = strBody
                    'arrField = objTVTemplate.Fields
                    strContent = strBody
                    arrField = objBCT.getArrayFromTemplate(strContent)
                    If Not arrField Is Nothing Then
                        For intCount = 0 To UBound(arrField)
                            If InStr(arrField(intCount), ":") > 0 Then
                                strTag = Left(arrField(intCount), InStr(arrField(intCount), ":") - 1)
                            Else
                                strTag = arrField(intCount)
                            End If
                            strTag = LCase(strTag)
                            If InStr(strInitTag, strTag & ",") > 0 Then
                                Select Case strTag
                                    Case "leader"
                                        arrSQL(1) = arrSQL(1) & "Leader,"
                                    Case "001"
                                        arrSQL(1) = arrSQL(1) & "Lib_tblItem.Code,"
                                    Case "907"
                                        arrSQL(1) = arrSQL(1) & "CoverPicture,"
                                    Case "911"
                                        arrSQL(1) = arrSQL(1) & "Reviewer,"
                                    Case "912"
                                        arrSQL(1) = arrSQL(1) & "Cataloguer,"
                                    Case "925"
                                        arrSQL(1) = arrSQL(1) & "MediumID,"
                                    Case "926"
                                        arrSQL(1) = arrSQL(1) & "AccessLevel,"
                                    Case "927"
                                        arrSQL(1) = arrSQL(1) & "TypeID,"
                                End Select
                            ElseIf InStr(strTag, "holding") = 1 Then
                                If Not InStr(strTag, "holdingcomposite") = 1 Then
                                    If intHolding = 0 Then
                                        Select Case UCase(strDBServer)
                                            Case "SQLSERVER"
                                                arrSQL(0) = "SELECT Code, CopyNumber, Symbol, Shelf, ItemID FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingType ON  Lib_tblHolding.LibID = Lib_tblHoldingType.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE ItemID IN " & strIDs
                                            Case "ORACLE"
                                                arrSQL(0) = "SELECT Code, CopyNumber, Symbol, Shelf, ItemID FROM Lib_tblHolding, Lib_tblHoldingType, Lib_tblHoldingLocation WHERE Lib_tblHolding.LibID = Lib_tblHoldingType.ID(+) AND Lib_tblHoldingLocation.ID(+) = Lib_tblHolding.LocationID AND ItemID IN " & strIDs
                                        End Select
                                    End If
                                    intHolding = 1
                                End If
                            ElseIf InStr(strTabs, Left(strTag, 1) & ",") = 0 Then
                                strTabs = strTabs & Left(strTag, 1) & ","
                                arrSQL(2) = arrSQL(2) & " SELECT Lib_tblField" & Left(strTag, 1) & "00S.ID AS ID, ItemID, Content, Ind1, Lib_tblMARCBibField.FieldCode FROM Lib_tblField" & Left(strTag, 1) & "00S, Lib_tblMARCBibField WHERE Lib_tblMARCBibField.FieldCode = Lib_tblField" & Left(strTag, 1) & "00S.FieldCode AND ItemID IN" & strIDs & " UNION"
                            End If
                        Next
                    End If
                    If arrSQL(2) <> "" Then
                        arrSQL(2) = Left(arrSQL(2), Len(arrSQL(2)) - 6) & " ORDER BY ItemID,ID"
                    End If
                End If ' Of tblTemplate.Rows.Count >0
                If arrSQL(1) <> "" Then
                    arrSQL(1) = "SELECT " & Left(arrSQL(1), Len(arrSQL(1)) - 1) & " FROM Lib_tblItem, Cat_tblDic_ItemType, Cat_tblDicMedium WHERE Cat_tblDicMedium.ID = Lib_tblItem.MediumID AND Lib_tblItem.TypeID = Cat_tblDic_ItemType.ID AND Lib_tblItem.ID IN " & strIDs
                End If
                Dim arrIDi()
                arrIDi = Split(strIDs, ",")
                ' generate DataTable by SQL Statement
                If arrSQL(0) <> "" Then
                    objBComDB.SQLStatement = arrSQL(0)
                    TblHolding = objBComDB.RetrieveItemInfor
                End If
                If arrSQL(2) <> "" Then
                    objBComDB.SQLStatement = arrSQL(2)
                    TblItem = objBComDB.RetrieveItemInfor
                    'a = arrSQL(2)
                End If
                If arrSQL(1) <> "" Then
                    objBComDB.SQLStatement = arrSQL(1)
                    TblField = objBComDB.RetrieveItemInfor
                End If
            End If
        End Sub

        ' Generate_Fiche method
        Public Function Generate_Fiche(ByVal intPage As Integer, ByVal ArrID As Object, Optional ByVal blnAll As Boolean = False) As String
            Dim arrField()
            Dim arrSubVal()
            Dim inti As Integer
            Dim strIDi As String
            Dim blnUpper As Boolean = False
            Dim blnSerial As Boolean
            Dim blnFix As Boolean
            Dim arrI()
            Dim arrData()
            Dim intl
            Dim strTag As String
            Dim strSerialFormat As String
            Dim strFixFormat As String
            Dim rowi() As DataRow
            Dim strFieldCode As String
            Dim strSubFieldCode As String
            Dim strGenNote As String
            Dim introw As Integer
            Dim intLocIDlocal As Integer
            Dim intLibIDlocal As Integer
            Dim blnIncShelf As Boolean
            Dim blnIncInv As Boolean
            Dim blnIncLib As Boolean
            'Dim objUpper As New TVCOMLib.utf8
            'Dim objTVTemplate As New TVCOMLib.LibolTemplate
            Dim intStart As Integer
            Dim bytFlag As Byte
            Dim strLocation As String
            Dim intNo As Integer = 0
            Dim tblTemplate As New DataTable
            Dim strContentTemp As String
            Dim strBody As String
            Dim strHeader As String
            Dim strFooter As String
            Dim strReturn As String
            Dim intFromID As Integer
            Dim intToID As Integer
            Dim strContent As String = ""
            If blnAll Then
                intFromID = 0
                intToID = UBound(ArrID) - 1
            Else
                intFromID = (intPage - 1) * intPageSize
                intToID = intPage * intPageSize - 1
            End If

            Me.Generate_DataTable(intPage, ArrID, blnAll)
            For inti = intFromID To intToID
                If inti > UBound(ArrID) Then
                    Exit For
                End If
                If bytMultiFiche = 1 Then
                    arrI = Split(ArrID(inti), ":")
                    strIDi = arrI(0)
                Else
                    strIDi = ArrID(inti)
                End If
                objBTemplate.Type = 15
                objBTemplate.IDs = strIDTemplate
                tblTemplate = objBTemplate.GetTemplates
                '
                If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                    strContentTemp = tblTemplate.Rows(0).Item("Content")
                    If InStr(strContentTemp, "<!--Page header-->") > 0 And InStr(strContentTemp, "<!--Page footer-->") > 0 Then
                        strHeader = Left(strContentTemp, InStr(strContentTemp, "<!--Page header-->") - 1)
                        strBody = Mid(strContentTemp, InStr(strContentTemp, "<!--Page header-->") + 18, InStr(strContentTemp, "<!--Page footer-->") - InStr(strContentTemp, "<!--Page header-->") - 18)
                        strFooter = Right(strContentTemp, Len(strContentTemp) - InStr(strContentTemp, "<!--Page footer-->") - 17)
                    Else
                        strHeader = ""
                        strBody = strContentTemp
                        strFooter = ""
                    End If
                    'objTVTemplate.Template = strBody
                    'arrField = objTVTemplate.Fields
                    strContent = strBody
                    arrField = objBCT.getArrayFromTemplate(strContent)
                End If
                If Not arrField Is Nothing Then




                    ReDim arrData(UBound(arrField))
                    intStart = 1
                    For intl = LBound(arrField) To UBound(arrField)
                        strTag = ""
                        strTag = LCase(arrField(intl) & "")
                        If InStr(strTag, ":upper") > 0 Then
                            blnUpper = True
                            strTag = Replace(strTag, ":upper", "")
                        Else
                            blnUpper = False
                        End If
                        If InStr(strTag, ":serial") > 0 Then
                            blnSerial = True
                            strSerialFormat = GetProperty(arrField(intl), ":serial")
                            strTag = Replace(strTag, LCase(strSerialFormat), "")
                        Else
                            blnSerial = False
                        End If
                        If InStr(strTag, ":fixed") > 0 Then
                            blnFix = True
                            strFixFormat = GetProperty(arrField(intl), ":fixed")
                            strTag = Replace(strTag, LCase(strFixFormat), "")
                            If InStr(strFixFormat, "=") > 0 Then
                                strFixFormat = Right(strFixFormat, Len(strFixFormat) - InStr(strFixFormat, "="))
                            Else
                                strFixFormat = ""
                            End If
                        Else
                            blnFix = False
                        End If
                        If InStr(strInitTag, strTag & ",") > 0 Then
                            rowi = TblField.Select("ItemID = " & strIDi)
                            Select Case strTag
                                Case "id"
                                    arrData(intl) = rowi(0).Item("ItemID") & Chr(9)
                                Case "leader"
                                    arrData(intl) = Replace(rowi(0).Item("Leader"), " ", "&nbsp;") & Chr(9)
                                Case "001"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("Code") & Chr(9)
                                Case "907"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("CoverPicture") & Chr(9)
                                Case "911"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("Reviewer") & Chr(9)
                                Case "912"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("Cataloguer") & Chr(9)
                                Case "925"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("MediumID") & Chr(9)
                                Case "926"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("AccessLevel") & Chr(9)
                                Case "927"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("TypeID") & Chr(9)
                                Case "no"
                                    arrData(intl) = (intNo + 1) & Chr(9)
                                Case "curday"
                                    arrData(intl) = CStr(Day(Now)) & Chr(9)
                                Case "curmonth"
                                    arrData(intl) = CStr(Month(Now)) & Chr(9)
                                Case "curyear"
                                    arrData(intl) = CStr(Year(Now)) & Chr(9)
                            End Select
                        ElseIf InStr(strTag, "holding") = 0 Then
                            strFieldCode = Left(strTag, 3)
                            Try
                                rowi = TblItem.Select("ItemID=" & strIDi & " AND FieldCode='" & strFieldCode & "'")
                                If blnSerial And InStr(strSerialFormat, "start") > 0 Then
                                    intStart = 1
                                End If
                                For introw = 0 To rowi.GetUpperBound(0)
                                    If blnSerial Then
                                        Select Case strSerialFormat
                                            Case "serialstart1", "serialcontinue1"
                                                arrData(intl) = arrData(intl) & intStart & ". "
                                            Case "serialstartI", "serialcontinueI"
                                                arrData(intl) = arrData(intl) & ToRoman(intStart, 1) & ". "
                                            Case "serialstarti", "serialcontinuei"
                                                arrData(intl) = arrData(intl) & ToRoman(intStart, 0) & ". "
                                            Case "serialstartA", "serialcontinueA"
                                                arrData(intl) = arrData(intl) & ToChar(intStart, 1) & ". "
                                            Case "serialstarta", "serialcontinuea"
                                                arrData(intl) = arrData(intl) & ToChar(intStart, 0) & ". "
                                        End Select
                                        intStart = intStart + 1
                                    End If
                                    If blnFix Then
                                        arrData(intl) = arrData(intl) & strFixFormat & Chr(9)
                                    Else
                                        strGenNote = ""
                                        Select Case Left(strTag, 3)
                                            Case "242"
                                                If Len(rowi(introw).Item("Indicators")) = 2 Then
                                                    Select Case Right(rowi(introw).Item("Indicators"), 1)
                                                        Case "0"
                                                            'GenNote = "<I>" & LabelStr(20) & ":</I> "
                                                    End Select
                                                End If
                                            Case "246"
                                                If Len(rowi(introw).Item("Indicators")) = 2 Then
                                                    Select Case Right(rowi(introw).Item("Indicators"), 1)
                                                        Case "2"
                                                            strGenNote = "<I>Nhan đề làm rõ (phân định):</I> "
                                                        Case "3"
                                                            strGenNote = "<I>Nhan đề khác:</I> "
                                                        Case "4"
                                                            strGenNote = "<I>Nhan đề ngoài bìa:</I> "
                                                        Case "5"
                                                            strGenNote = "<I>Nhan đề trên trang tên bổ sung:</I> "
                                                        Case "6"
                                                            arrData(intl) = "<I>Nhan đề hoa văn:</I> "
                                                        Case "7"
                                                            strGenNote = "<I>Nhan đề chạy:</I> "
                                                        Case "8"
                                                            strGenNote = "<I>Nhan đề gáy sách:</I> "
                                                    End Select
                                                End If
                                            Case "247"
                                                If Len(rowi(introw).Item("Indicators")) = 2 Then
                                                    Select Case Right(rowi(introw).Item("Indicators"), 1)
                                                        Case "0"
                                                            strGenNote = "<I>Nhan đề thay đổi:</I> "
                                                    End Select
                                                End If
                                        End Select
                                        If InStr(strTag, "$") = 4 Then
                                            strSubFieldCode = Mid(strTag, 4, 2)
                                            Call objBString.ParseField(strSubFieldCode, rowi(introw).Item("Content"), "tr" & Chr(9), arrSubVal)
                                            arrData(intl) = arrData(intl) & strGenNote & objBString.TheDisplayOne(arrSubVal(0)) & Chr(9)
                                        Else
                                            arrData(intl) = arrData(intl) & strGenNote & objBString.TheDisplayOne(objBString.TrimSubFieldCodes(rowi(introw).Item("Content"))) & Chr(9)
                                        End If
                                    End If
                                Next introw
                            Catch ex As Exception
                            End Try
                        ElseIf InStr(strTag, "holdingcomposite") = 1 Then
                            If bytMultiFiche = 1 Then
                                If Trim(CStr(arrI(1))) = "NULL" Then
                                    intLibIDlocal = 0
                                Else
                                    intLibIDlocal = CInt(arrI(1))
                                End If
                                If Trim(CStr(arrI(2))) = "NULL" Then
                                    intLocIDlocal = 0
                                Else
                                    intLocIDlocal = CInt(arrI(2))
                                End If
                            Else
                                intLibIDlocal = intLibID
                                intLocIDlocal = intLocID
                            End If
                            If InStr(strTag, ":lib") > 0 Then
                                blnIncLib = True
                            Else
                                blnIncLib = False
                            End If
                            If InStr(strTag, ":inventory") > 0 Then
                                blnIncInv = True
                            Else
                                blnIncInv = False
                            End If
                            If InStr(strTag, ":shelf") > 0 Then
                                blnIncShelf = True
                            Else
                                blnIncShelf = False
                            End If
                            arrData(intl) = objBInput.GenerateCompositeHoldings(strIDi, blnIncLib, blnIncInv, blnIncShelf, intLibIDlocal, intLocIDlocal, ".") & Chr(9)
                            ' La^'y ra te^n kho
                            If bytFlag = 0 Then
                                If InStr(arrData(intl), "/") > 0 Then
                                    strLocation = Left(arrData(intl), InStr(arrData(intl), "/"))
                                End If
                                bytFlag = 1
                            End If
                            arrData(intl) = strLocation & Replace(arrData(intl), strLocation, "")
                            arrData(intl) = Replace(arrData(intl), "/", "<HR WIDTH=60 NOSHADE COLOR=000000 SIZE=1>")
                        Else
                            If Not TblHolding Is Nothing AndAlso TblHolding.Rows.Count > 0 Then
                                rowi = TblHolding.Select("ItemID=" & strIDi)
                                For introw = 0 To rowi.GetUpperBound(0)
                                    If InStr(strTag, ":lib") > 0 Then
                                        arrData(intl) = arrData(intl) & rowi(introw).Item("Code") & "."
                                    End If
                                    If InStr(strTag, ":inventory") > 0 And rowi(introw).Item("Symbol") <> "" Then
                                        arrData(intl) = arrData(intl) & rowi(introw).Item("Symbol") & "."
                                    End If
                                    'If InStr(strTag, ":shelf") > 0 And rowi(introw).Item("Self") <> "" Then
                                    '    arrData(intl) = arrData(intl) & rowi(introw).Item("Self") & "."
                                    'End If
                                    If InStr(strTag, ":number") > 0 Then
                                        arrData(intl) = arrData(intl) & rowi(introw).Item("CopyNumber")
                                    End If
                                    arrData(intl) = arrData(intl) & Chr(9)
                                Next
                            End If
                        End If

                        If arrData(intl) <> "" And Right(arrData(intl), 1) = Chr(9) Then
                            arrData(intl) = Left(arrData(intl), Len(arrData(intl)) - 1)
                        End If
                        arrData(intl) = arrData(intl)
                        If blnUpper Then
                            'arrData(intl) = objUpper.Upper(arrData(intl))
                            arrData(intl) = arrData(intl)
                        End If

                        strContent = Replace(strContent, "<$" & arrField(intl) & "$>", arrData(intl))
                    Next intl
                End If
                'strReturn = strReturn & strHeader & objBString.ToUTF8Back(objTVTemplate.Generate(arrData)) & strFooter
                strReturn &= strHeader & strContent & strFooter
            Next inti
            'objUpper = Nothing
            Generate_Fiche = strReturn
        End Function

        Public Function Generate_Fiche_ToList(ByVal intPage As Integer, ByVal ArrID As Object, Optional ByVal blnAll As Boolean = False) As String()
            Dim arrField()
            Dim arrSubVal()
            Dim inti As Integer
            Dim strIDi As String
            Dim blnUpper As Boolean = False
            Dim blnSerial As Boolean
            Dim blnFix As Boolean
            Dim arrI()
            Dim arrData()
            Dim intl
            Dim strTag As String
            Dim strSerialFormat As String
            Dim strFixFormat As String
            Dim rowi() As DataRow
            Dim strFieldCode As String
            Dim strSubFieldCode As String
            Dim strGenNote As String
            Dim introw As Integer
            Dim intLocIDlocal As Integer
            Dim intLibIDlocal As Integer
            Dim blnIncShelf As Boolean
            Dim blnIncInv As Boolean
            Dim blnIncLib As Boolean
            'Dim objUpper As New TVCOMLib.utf8
            'Dim objTVTemplate As New TVCOMLib.LibolTemplate
            Dim intStart As Integer
            Dim bytFlag As Byte
            Dim strLocation As String
            Dim intNo As Integer = 0
            Dim tblTemplate As New DataTable
            Dim strContentTemp As String
            Dim strBody As String
            Dim strHeader As String
            Dim strFooter As String
            Dim strReturn() As String
            Dim intFromID As Integer
            Dim intToID As Integer
            Dim strContent As String = ""
            If blnAll Then
                intFromID = 0
                intToID = UBound(ArrID) - 1
            Else
                intFromID = (intPage - 1) * intPageSize
                intToID = intPage * intPageSize - 1
            End If

            Me.Generate_DataTable(intPage, ArrID, blnAll)
            Dim countArray As Integer = intToID - intFromID
            ReDim strReturn(countArray)
            Dim iArrary As Integer = 0
            For inti = intFromID To intToID
                If inti > UBound(ArrID) Then
                    Exit For
                End If
                If bytMultiFiche = 1 Then
                    arrI = Split(ArrID(inti), ":")
                    strIDi = arrI(0)
                Else
                    strIDi = ArrID(inti)
                End If
                objBTemplate.Type = 15
                objBTemplate.IDs = strIDTemplate
                tblTemplate = objBTemplate.GetTemplates
                '
                If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                    strContentTemp = tblTemplate.Rows(0).Item("Content")
                    If InStr(strContentTemp, "<!--Page header-->") > 0 And InStr(strContentTemp, "<!--Page footer-->") > 0 Then
                        strHeader = Left(strContentTemp, InStr(strContentTemp, "<!--Page header-->") - 1)
                        strBody = Mid(strContentTemp, InStr(strContentTemp, "<!--Page header-->") + 18, InStr(strContentTemp, "<!--Page footer-->") - InStr(strContentTemp, "<!--Page header-->") - 18)
                        strFooter = Right(strContentTemp, Len(strContentTemp) - InStr(strContentTemp, "<!--Page footer-->") - 17)
                    Else
                        strHeader = ""
                        strBody = strContentTemp
                        strFooter = ""
                    End If
                    'objTVTemplate.Template = strBody
                    'arrField = objTVTemplate.Fields
                    strContent = strBody
                    arrField = objBCT.getArrayFromTemplate(strContent)
                End If
                If Not arrField Is Nothing Then

                    ReDim arrData(UBound(arrField))
                    intStart = 1
                    For intl = LBound(arrField) To UBound(arrField)
                        strTag = ""
                        strTag = LCase(arrField(intl) & "")
                        If InStr(strTag, ":upper") > 0 Then
                            blnUpper = True
                            strTag = Replace(strTag, ":upper", "")
                        Else
                            blnUpper = False
                        End If
                        If InStr(strTag, ":serial") > 0 Then
                            blnSerial = True
                            strSerialFormat = GetProperty(arrField(intl), ":serial")
                            strTag = Replace(strTag, LCase(strSerialFormat), "")
                        Else
                            blnSerial = False
                        End If
                        If InStr(strTag, ":fixed") > 0 Then
                            blnFix = True
                            strFixFormat = GetProperty(arrField(intl), ":fixed")
                            strTag = Replace(strTag, LCase(strFixFormat), "")
                            If InStr(strFixFormat, "=") > 0 Then
                                strFixFormat = Right(strFixFormat, Len(strFixFormat) - InStr(strFixFormat, "="))
                            Else
                                strFixFormat = ""
                            End If
                        Else
                            blnFix = False
                        End If
                        If InStr(strInitTag, strTag & ",") > 0 Then
                            rowi = TblField.Select("ItemID = " & strIDi)
                            Select Case strTag
                                Case "id"
                                    arrData(intl) = rowi(0).Item("ItemID") & Chr(9)
                                Case "leader"
                                    arrData(intl) = Replace(rowi(0).Item("Leader"), " ", "&nbsp;") & Chr(9)
                                Case "001"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("Code") & Chr(9)
                                Case "907"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("CoverPicture") & Chr(9)
                                Case "911"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("Reviewer") & Chr(9)
                                Case "912"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("Cataloguer") & Chr(9)
                                Case "925"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("MediumID") & Chr(9)
                                Case "926"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("AccessLevel") & Chr(9)
                                Case "927"
                                    arrData(intl) = arrData(intl) & rowi(0).Item("TypeID") & Chr(9)
                                Case "no"
                                    arrData(intl) = (intNo + 1) & Chr(9)
                                Case "curday"
                                    arrData(intl) = CStr(Day(Now)) & Chr(9)
                                Case "curmonth"
                                    arrData(intl) = CStr(Month(Now)) & Chr(9)
                                Case "curyear"
                                    arrData(intl) = CStr(Year(Now)) & Chr(9)
                            End Select
                        ElseIf InStr(strTag, "holding") = 0 Then
                            strFieldCode = Left(strTag, 3)
                            Try
                                rowi = TblItem.Select("ItemID=" & strIDi & " AND FieldCode='" & strFieldCode & "'")
                                If blnSerial And InStr(strSerialFormat, "start") > 0 Then
                                    intStart = 1
                                End If
                                For introw = 0 To rowi.GetUpperBound(0)
                                    If blnSerial Then
                                        Select Case strSerialFormat
                                            Case "serialstart1", "serialcontinue1"
                                                arrData(intl) = arrData(intl) & intStart & ". "
                                            Case "serialstartI", "serialcontinueI"
                                                arrData(intl) = arrData(intl) & ToRoman(intStart, 1) & ". "
                                            Case "serialstarti", "serialcontinuei"
                                                arrData(intl) = arrData(intl) & ToRoman(intStart, 0) & ". "
                                            Case "serialstartA", "serialcontinueA"
                                                arrData(intl) = arrData(intl) & ToChar(intStart, 1) & ". "
                                            Case "serialstarta", "serialcontinuea"
                                                arrData(intl) = arrData(intl) & ToChar(intStart, 0) & ". "
                                        End Select
                                        intStart = intStart + 1
                                    End If
                                    If blnFix Then
                                        arrData(intl) = arrData(intl) & strFixFormat & Chr(9)
                                    Else
                                        strGenNote = ""
                                        Select Case Left(strTag, 3)
                                            Case "242"
                                                If Len(rowi(introw).Item("Indicators")) = 2 Then
                                                    Select Case Right(rowi(introw).Item("Indicators"), 1)
                                                        Case "0"
                                                            'GenNote = "<I>" & LabelStr(20) & ":</I> "
                                                    End Select
                                                End If
                                            Case "246"
                                                If Len(rowi(introw).Item("Indicators")) = 2 Then
                                                    Select Case Right(rowi(introw).Item("Indicators"), 1)
                                                        Case "2"
                                                            strGenNote = "<I>Nhan đề làm rõ (phân định):</I> "
                                                        Case "3"
                                                            strGenNote = "<I>Nhan đề khác:</I> "
                                                        Case "4"
                                                            strGenNote = "<I>Nhan đề ngoài bìa:</I> "
                                                        Case "5"
                                                            strGenNote = "<I>Nhan đề trên trang tên bổ sung:</I> "
                                                        Case "6"
                                                            arrData(intl) = "<I>Nhan đề hoa văn:</I> "
                                                        Case "7"
                                                            strGenNote = "<I>Nhan đề chạy:</I> "
                                                        Case "8"
                                                            strGenNote = "<I>Nhan đề gáy sách:</I> "
                                                    End Select
                                                End If
                                            Case "247"
                                                If Len(rowi(introw).Item("Indicators")) = 2 Then
                                                    Select Case Right(rowi(introw).Item("Indicators"), 1)
                                                        Case "0"
                                                            strGenNote = "<I>Nhan đề thay đổi:</I> "
                                                    End Select
                                                End If
                                        End Select
                                        If InStr(strTag, "$") = 4 Then
                                            strSubFieldCode = Mid(strTag, 4, 2)
                                            Call objBString.ParseField(strSubFieldCode, rowi(introw).Item("Content"), "tr" & Chr(9), arrSubVal)
                                            arrData(intl) = arrData(intl) & strGenNote & objBString.TheDisplayOne(arrSubVal(0)) & Chr(9)
                                        Else
                                            arrData(intl) = arrData(intl) & strGenNote & objBString.TheDisplayOne(objBString.TrimSubFieldCodes(rowi(introw).Item("Content"))) & Chr(9)
                                        End If
                                    End If
                                Next introw
                            Catch ex As Exception
                            End Try
                        ElseIf InStr(strTag, "holdingcomposite") = 1 Then
                            If bytMultiFiche = 1 Then
                                If Trim(CStr(arrI(1))) = "NULL" Then
                                    intLibIDlocal = 0
                                Else
                                    intLibIDlocal = CInt(arrI(1))
                                End If
                                If Trim(CStr(arrI(2))) = "NULL" Then
                                    intLocIDlocal = 0
                                Else
                                    intLocIDlocal = CInt(arrI(2))
                                End If
                            Else
                                intLibIDlocal = intLibID
                                intLocIDlocal = intLocID
                            End If
                            If InStr(strTag, ":lib") > 0 Then
                                blnIncLib = True
                            Else
                                blnIncLib = False
                            End If
                            If InStr(strTag, ":inventory") > 0 Then
                                blnIncInv = True
                            Else
                                blnIncInv = False
                            End If
                            If InStr(strTag, ":shelf") > 0 Then
                                blnIncShelf = True
                            Else
                                blnIncShelf = False
                            End If
                            'arrData(intl) = objBInput.GenerateCompositeHoldings(strIDi, blnIncLib, blnIncInv, blnIncShelf, intLibIDlocal, intLocIDlocal, ".") & Chr(9)
                            arrData(intl) = objBInput.GenerateCompositeHoldingsOther(strIDi, blnIncLib, blnIncInv, blnIncShelf, intLibIDlocal, intLocIDlocal, ".") & Chr(9)
                            ' La^'y ra te^n kho
                            If bytFlag = 0 Then
                                If InStr(arrData(intl), "/") > 0 Then
                                    strLocation = Left(arrData(intl), InStr(arrData(intl), "/"))
                                End If
                                bytFlag = 1
                            End If
                            'arrData(intl) = strLocation & Replace(arrData(intl), strLocation, "")
                            'arrData(intl) = Replace(arrData(intl), "/", "<HR WIDTH=60 NOSHADE COLOR=000000 SIZE=1>")
                            arrData(intl) = Replace(arrData(intl), strLocation, "")
                            arrData(intl) = Replace(arrData(intl), "<br>", "#")
                            Dim valueData As String = ""
                            Dim tempData As String = arrData(intl)
                            Dim splitTemp() As String = tempData.Split("#")
                            For Each stringResultData As String In splitTemp
                                If (Not IsNothing(stringResultData)) Then
                                    Dim tempValue As String = stringResultData
                                    Dim valueSplit() As String = tempValue.Split("/")
                                    If (valueSplit.Length > 0) Then
                                        valueData = valueData & valueSplit(valueSplit.Length - 1) & "<br>"
                                    End If
                                End If
                            Next
                            arrData(intl) = valueData
                        Else
                            If Not TblHolding Is Nothing AndAlso TblHolding.Rows.Count > 0 Then
                                rowi = TblHolding.Select("ItemID=" & strIDi)
                                For introw = 0 To rowi.GetUpperBound(0)
                                    If InStr(strTag, ":lib") > 0 Then
                                        arrData(intl) = arrData(intl) & rowi(introw).Item("Code") & "."
                                    End If
                                    If InStr(strTag, ":inventory") > 0 And rowi(introw).Item("Symbol") <> "" Then
                                        arrData(intl) = arrData(intl) & rowi(introw).Item("Symbol") & "."
                                    End If
                                    'If InStr(strTag, ":shelf") > 0 And rowi(introw).Item("Self") <> "" Then
                                    '    arrData(intl) = arrData(intl) & rowi(introw).Item("Self") & "."
                                    'End If
                                    If InStr(strTag, ":number") > 0 Then
                                        arrData(intl) = arrData(intl) & rowi(introw).Item("CopyNumber")
                                    End If
                                    arrData(intl) = arrData(intl) & Chr(9)
                                Next
                            End If
                        End If

                        If arrData(intl) <> "" And Right(arrData(intl), 1) = Chr(9) Then
                            arrData(intl) = Left(arrData(intl), Len(arrData(intl)) - 1)
                        End If
                        arrData(intl) = arrData(intl)
                        If blnUpper Then
                            'arrData(intl) = objUpper.Upper(arrData(intl))
                            arrData(intl) = arrData(intl)
                        End If

                        Select Case arrField(intl)
                            Case "245$b"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", ": " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "245$n"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "" & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "245$p"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", ": " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "245$c"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "/ " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "250$a"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", ".- " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "260$a"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", ".- " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "260$b"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", ": " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "260$c"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", ", " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "300$a"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", ".- " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case "300$c"
                                If (arrData(intl) <> "") Then
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "; " & arrData(intl))
                                Else
                                    strContent = Replace(strContent, "<$" & arrField(intl) & "$>", "")
                                End If
                            Case Else
                                strContent = Replace(strContent, "<$" & arrField(intl) & "$>", arrData(intl))
                        End Select
                    Next intl
                End If
                'strReturn = strReturn & strHeader & objBString.ToUTF8Back(objTVTemplate.Generate(arrData)) & strFooter
                strReturn(iArrary) = strHeader & strContent & strFooter
                iArrary = iArrary + 1
            Next inti
            'objUpper = Nothing
            Generate_Fiche_ToList = strReturn
        End Function

        '  Save data to file .htm and convert to .doc
        Public Function SaveFile(ByVal strContent As String, Optional ByVal strServerRootPath As String = "") As String
            Try
                Dim Doc2HTML As New DOC2HTMLLib.Converter
                Dim strFileName, strPath, strPathHtm, strPathDoc As String
                If objBComDB.GetTempFilePath(1).Rows.Count > 0 Then
                    strPath = strServerRootPath & objBComDB.GetTempFilePath(1).Rows(0).Item("TempFilePath")
                End If
                objBComDB.Extension = "HTML"
                strFileName = objBComDB.GenRandomFile
                SaveFile = strFileName ' Html file
                strPathHtm = strPath & "\" & strFileName
                Dim ObjOut = New StreamWriter(strPathHtm, True)
                ObjOut.WriteLine(strContent)
                ObjOut.Close()
                objBComDB.Extension = "DOC"
                strFileName = objBComDB.GenRandomFile
                strPathDoc = strPath & "\" & strFileName
                Doc2HTML.HtmlToDocFile(strPathHtm, strPathDoc, 1)
                If Doc2HTML.ErrorCode = 0 Then
                    Dim filUpload As File
                    filUpload.Delete(strPathHtm)
                    Call objBComDB.InsertSysDownloadFile()
                    SaveFile = strFileName ' Convert successful
                Else
                    strErrorMsg = Doc2HTML.ErrorMessage
                    intErrorCode = Doc2HTML.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        '  Save data to file .htm and convert to .doc
        Public Function SaveFileAspose(ByVal strContent As String, Optional ByVal strServerRootPath As String = "") As String
            Try
                Dim strFileName, strPath, strPathHtm, strPathDoc As String
                strFileName = objBComDB.GenRandomFile
                strFileName &= Format(Now, "yyyyMMddhhmmssfff") & ".doc"
                If Not strServerRootPath.EndsWith("\") Then
                    strServerRootPath = strServerRootPath + "\"
                End If
                Dim licenseFile As String = Path.Combine(strServerRootPath, "bin\Aspose.Words.lic")
                If (File.Exists(licenseFile)) Then
                    Dim license As Aspose.Words.License = New Aspose.Words.License()
                    license.SetLicense(licenseFile)
                    Dim strDocFile As String = strServerRootPath & "Template\documentList.doc"
                    Dim doc As Aspose.Words.Document = New Aspose.Words.Document(strDocFile)
                    Dim builder As DocumentBuilder = New DocumentBuilder(doc)
                    builder.MoveToMergeField("HTMLValue")

                    builder.InsertHtml("<span style='font-size:10pt; font-family:Arial;text-align:justify;'>" & strContent & "</span>")
                    Dim strFile As String = ""
                    strFile = strServerRootPath & "Catalogue\Attach\" & strFileName
                    doc.Save(strFile, Aspose.Words.SaveFormat.Doc)

                    If Not IsNothing(doc) Then
                        doc = Nothing
                        SaveFileAspose = strFileName
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' ToChar property
        Private Function ToChar(ByVal lngNumber As Long, ByVal blnLCase As Boolean) As String
            ToChar = Chr(lngNumber Mod 26 + 64)
            If blnLCase Then
                ToChar = LCase(ToChar)
            End If
        End Function

        ' ToRoman method
        Private Function ToRoman(ByVal lngNumber As Long, ByVal blnLCase As Boolean) As String
            Dim strReturn As String
            Dim lngThousands As Long
            Dim lngFiveHundreds As Long
            Dim lngHundreds As Long
            Dim lngFifties As Long
            Dim lngTens As Long
            Dim lngFives As Long
            Dim lngOnes As Long

            lngOnes = lngNumber
            lngThousands = lngOnes \ 1000
            lngOnes = lngOnes - lngThousands * 1000
            lngFiveHundreds = lngOnes \ 500
            lngOnes = lngOnes - lngFiveHundreds * 500
            lngHundreds = lngOnes \ 100
            lngOnes = lngOnes - lngHundreds * 100
            lngFifties = lngOnes \ 50
            lngOnes = lngOnes - lngFifties * 50
            lngTens = lngOnes \ 10
            lngOnes = lngOnes - lngTens * 10
            lngFives = lngOnes \ 5
            lngOnes = lngOnes - lngFives * 5

            strReturn = "M".PadLeft(lngThousands)

            If lngHundreds = 4 Then
                If lngFiveHundreds = 1 Then
                    strReturn = strReturn & "CM"
                Else
                    strReturn = strReturn & "CD"
                End If
            Else
                strReturn = strReturn & "D".PadLeft(lngFiveHundreds) & "C".PadLeft(lngHundreds)
            End If

            If lngTens = 4 Then
                If lngFifties = 1 Then
                    strReturn = strReturn & "XC"
                Else
                    strReturn = strReturn & "XL"
                End If
            Else
                strReturn = strReturn & "L".PadLeft(lngFifties) & "X".PadLeft(lngTens)
            End If

            If lngOnes = 4 Then
                If lngFives = 1 Then
                    strReturn = strReturn & "IX"
                Else
                    strReturn = strReturn & "IV"
                End If
            Else
                strReturn = strReturn & "V".PadLeft(lngFives) & "I".PadLeft(lngOnes)
            End If
            If blnLCase Then
                strReturn = LCase(strReturn)
            End If
            ToRoman = strReturn
        End Function

        ' GetProperty method
        Private Function GetProperty(ByVal strIn As String, ByVal strSub As String) As String
            Dim strTmp As String
            Dim intp As Integer

            intp = InStr(LCase(strIn), strSub)
            If intp > 0 Then
                strTmp = Right(strIn, Len(strIn) - intp)
                strIn = Left(strIn, intp - 1)
                intp = InStr(strTmp, ":")
                If intp > 0 Then
                    GetProperty = Left(strTmp, intp - 1)
                Else
                    GetProperty = strTmp
                End If
            Else
                GetProperty = ""
            End If
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBComDB Is Nothing Then
                    objBComDB.Dispose(True)
                    objBComDB = Nothing
                End If
                If Not objDFiche Is Nothing Then
                    objDFiche.Dispose(True)
                    objDFiche = Nothing
                End If
                If Not objBString Is Nothing Then
                    objBString.Dispose(True)
                    objBString = Nothing
                End If
                If Not objBTemplate Is Nothing Then
                    objBTemplate.Dispose(True)
                    objBTemplate = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace