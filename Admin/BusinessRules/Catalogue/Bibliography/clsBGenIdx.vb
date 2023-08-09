Imports System.IO
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBGenIdx
        Inherits clsBBase

        ' declare object
        Private objBString As New clsBCommonStringProc
        Private objBComDB As New clsBCommonDBSystem
        Private objBTemplate As New clsBCommonTemplate
        Private objBInput As New clsBInput
        Private objDGenIdx As New clsDGenIdx
        'Private objTemp As New TVCOMLib.LibolTemplate
        'Private objUpc As New TVCOMLib.utf8

        ' declare variable for properties
        Private bytTypeView As Byte
        Private strIdxID As String
        Private strTypeViewVal As String
        Private arrLabel() As Object
        Private intPageSize As Integer = 20
        Private intTemplateID As Integer
        Private strGroupBy As String

        Private arrItemID()
        Private arrTitle() As String
        Private arrIndex() As String

        ' declare global variable Table
        Private TblItem As New DataTable
        Private TblHolding As New DataTable
        Private TblField As New DataTable

        ' declare global variable Array
        Private arrFields()

        ' declare global variable other
        Private blnSelectedTemp As Boolean = False

        Private strDumTags As String = "001,900,907,911,912,925,926,927,id,leader,no,"

        Public abc As Object

        Public Property ItemIDArr() As Object
            Get
                Return arrItemID
            End Get
            Set(ByVal Value As Object)
                arrItemID = Value
            End Set
        End Property

        Public Property TitleArr() As Object
            Get
                Return arrTitle
            End Get
            Set(ByVal Value As Object)
                arrTitle = Value
            End Set
        End Property

        Public Property IndexArr() As Object
            Get
                Return arrIndex
            End Get
            Set(ByVal Value As Object)
                arrIndex = Value
            End Set
        End Property

        Public Property GroupBy() As String
            Get
                Return strGroupBy
            End Get
            Set(ByVal Value As String)
                strGroupBy = Value
            End Set
        End Property

        Public Property TemplateID() As Integer
            Get
                Return intTemplateID
            End Get
            Set(ByVal Value As Integer)
                intTemplateID = Value
            End Set
        End Property

        Public Property PageSize() As Integer
            Get
                Return intPageSize
            End Get
            Set(ByVal Value As Integer)
                intPageSize = Value
            End Set
        End Property

        Public Property Label() As Object
            Get
                Return arrLabel
            End Get
            Set(ByVal Value As Object)
                arrLabel = Value
            End Set
        End Property

        Public Property TypeViewVal() As String
            Get
                Return strTypeViewVal
            End Get
            Set(ByVal Value As String)
                strTypeViewVal = Value
            End Set
        End Property

        Public Property IdxID() As String
            Get
                Return strIdxID
            End Get
            Set(ByVal Value As String)
                strIdxID = Value
            End Set
        End Property

        Public Property TypeView() As Byte
            Get
                Return bytTypeView
            End Get
            Set(ByVal Value As Byte)
                bytTypeView = Value
            End Set
        End Property

        Public Sub Generate3array()
            Dim TblIdx As New DataTable
            Dim intGroupIDFrom As Integer
            Dim intGroupIDTo As Integer
            Dim strGroupName As String
            Dim strItemIDs As String
            Dim lngGrpIDTmp As Long
            Dim intCount As Integer = 0
            Dim lngIndex As Long
            Dim inti As Integer
            Dim intj As Integer
            Dim intTORs As Integer

            objDGenIdx.IDs = strIdxID
            objDGenIdx.TypeSel = bytTypeView
            objDGenIdx.GroupName = objBString.ConvertItBack(strTypeViewVal)
            If IsNumeric(strTypeViewVal) Then
                objDGenIdx.GroupIDFrom = strTypeViewVal
            ElseIf InStr(strTypeViewVal, "-") <> 0 Then
                objDGenIdx.GroupIDFrom = CInt(Left(strTypeViewVal, InStr(strTypeViewVal, "-") - 1))
                objDGenIdx.GroupIDTo = CInt(Right(strTypeViewVal, Len(strTypeViewVal) - InStr(strTypeViewVal, "-")))
            Else
                objDGenIdx.GroupIDFrom = 1
                objDGenIdx.GroupIDTo = 1
            End If
            TblIdx = objBComDB.ConvertTable(objDGenIdx.Retrieve_CustomIdx)
            If TblIdx.Rows.Count > 0 Then
                strItemIDs = ""
                lngGrpIDTmp = -1
                intTORs = CLng(TblIdx.Rows(0).Item("TORs"))
                ReDim arrTitle(intTORs)
                intCount = 0
                For inti = 0 To TblIdx.Rows.Count - 1
                    strItemIDs = strItemIDs & TblIdx.Rows(inti).Item("ItemIDs") & ","
                    If CLng(TblIdx.Rows(inti).Item("GroupID")) <> lngGrpIDTmp Then
                        lngGrpIDTmp = CLng(TblIdx.Rows(inti).Item("GroupID"))
                        lngIndex = CLng(TblIdx.Rows(inti).Item("Position"))
                        'generate Title array
                        arrTitle(lngIndex) = TblIdx.Rows(inti).Item("GroupName")
                    End If
                Next inti
                'generate Index array
                ReDim arrIndex(intTORs)
                For intCount = 0 To intTORs - 1
                    arrIndex(intCount) = CStr(intCount).PadLeft(CStr(intTORs).Length, "0")
                Next intCount
                strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                'generate ItemID array
                arrItemID = Split(strItemIDs, ",")
            Else

            End If
        End Sub

        Public Sub Generate3Table(ByVal arrField As Object, ByVal strItemIDs As String)
            Dim strTabs As String
            Dim blnHaveHolding As Boolean = False
            Dim strSQLHolding As String = ""
            Dim strSQLItem As String = ""
            Dim strSQLField As String = ""
            Dim intCount As Integer = 0
            Dim strTag As String
            Dim strTabName As String = ""

            For intCount = 0 To UBound(arrField)
                strTag = Replace(LCase(arrField(intCount)), ":upper", "")
                If InStr(strDumTags, strTag & ",") > 0 Then
                    Select Case arrField(intCount)
                        Case "id", "no"
                            strSQLItem = strSQLItem & "Lib_tblItem.ID As ItemID,"
                        Case "leader"
                            strSQLItem = strSQLItem & "Leader,"
                        Case "001"
                            strSQLItem = strSQLItem & "Code,"
                        Case "907"
                            strSQLItem = strSQLItem & "CoverPicture,"
                        Case "911"
                            strSQLItem = strSQLItem & "Cataloguer,"
                        Case "912"
                            strSQLItem = strSQLItem & "Reviewer,"
                        Case "925"
                            strSQLItem = strSQLItem & "MediumID,"
                        Case "926"
                            strSQLItem = strSQLItem & "AccessLevel,"
                        Case "927"
                            strSQLItem = strSQLItem & "TypeID,"
                    End Select
                ElseIf InStr(strTag, "holding") = 1 Then
                    If InStr(strTag, "holdingcomposite") <> 1 Then
                        If Not blnHaveHolding Then
                            Select Case UCase(strDBserver)
                                Case "SQLSERVER"
                                    strSQLHolding = "SELECT Code, CopyNumber, Symbol, CallNumber, Shelf, ItemID FROM Lib_tblHolding LEFT JOIN Lib_tblHoldingType ON  Lib_tblHolding.LibID = Lib_tblHoldingType.ID LEFT JOIN Lib_tblHoldingLocation ON Lib_tblHoldingLocation.ID = Lib_tblHolding.LocationID WHERE  ItemID IN (" & strItemIDs & ")"
                                Case "ORACLE"
                                    strSQLHolding = "SELECT Code,CopyNumber,Symbol,Shelf, CallNumber, ItemID FROM Lib_tblHolding, Lib_tblHoldingType, Lib_tblHoldingLocation WHERE Lib_tblHolding.LibID = Lib_tblHoldingType.ID(+) AND Lib_tblHoldingLocation.ID(+) = Lib_tblHolding.LocationID AND ItemID IN (" & strItemIDs & ")"
                            End Select
                            blnHaveHolding = True
                        End If
                    End If
                ElseIf InStr(strTabs, Left(strTag, 1) & ",") = 0 And IsNumeric(Left(strTag, 1)) Then
                    strTabs = strTabs & Left(strTag, 1) & ","
                    strTabName = "Lib_tblField" & Left(strTag, 1) & "00s"
                    strSQLField = strSQLField & " SELECT " & strTabName & ".ID, " & strTabName & ".ItemID, " & strTabName & ".Content, " & strTabName & ".Ind1," & strTabName & ".Ind2, " & strTabName & ".FieldCode FROM Lib_tblField" & Left(strTag, 1) & "00s WHERE " & strTabName & ".ItemID IN (" & strItemIDs & ") UNION"
                    strTabName = ""
                End If
            Next intCount

            strSQLField = Left(strSQLField, Len(strSQLField) - 6)
            If strSQLItem <> "" Then
                strSQLItem = "SELECT " & Left(strSQLItem, Len(strSQLItem) - 1) & " FROM Lib_tblItem,Cat_tblDic_ItemType, Cat_tblDicMedium WHERE Cat_tblDicMedium.ID = Lib_tblItem.MediumID AND Lib_tblItem.TypeID = Cat_tblDic_ItemType.ID AND Lib_tblItem.ID IN (" & Trim(strItemIDs) & ")"
                objBComDB.SQLStatement = strSQLItem
                TblItem = objBComDB.RetrieveItemInfor
            End If
            objBComDB.SQLStatement = strSQLField
            TblField = objBComDB.RetrieveItemInfor
            If blnHaveHolding Then
                objBComDB.SQLStatement = strSQLHolding
                TblHolding = objBComDB.RetrieveItemInfor
            End If
        End Sub

        Public Function GenerateDataForReport(ByVal intPageCount As Integer, ByVal intTotalItem As Integer) As Object
            Dim arrRet()
            Dim lngCountRet As Long = 0
            Dim srtStreamTmp As String = ""
            Dim strItemIDs As String = ""
            Dim intCount As Integer
            Dim intCountPg As Integer
            Dim inti As Integer
            Dim blnUpperIt As Boolean = False
            Dim strTag As String = ""
            Dim strTagTmp As String = ""
            Dim strFilter As String = ""
            Dim strGenNote As String = ""
            Dim strSubFieldCode As String = ""
            Dim arrSubVal()
            Dim blnHaveLib As Boolean = False
            Dim blnHaveLoc As Boolean = False
            Dim blnHaveShelf As Boolean = False
            Dim arrData()
            Dim objrowi() As DataRow
            Dim TblTemp As New DataTable
            Dim strContentTemp As String
            Dim strCurrGrp As String
            Dim strHeadTmp As String
            Dim intFrom As Integer
            Dim intTo As Integer

            'read template Table
            objBTemplate.TemplateID = intTemplateID
            TblTemp = objBTemplate.GetTemplate
            If TblTemp.Rows.Count > 0 Then
                strContentTemp = TblTemp.Rows(0).Item("Content")
                If strGroupBy <> "" Then
                    strContentTemp = strContentTemp & "-----//-----<$" & strGroupBy & ",,,,,1$>"
                Else
                    strContentTemp = strContentTemp & "-----//-----"
                End If
            Else
                strContentTemp = ""
            End If
            'objTemp.Template = objBString.ToUTF8(strContentTemp)
            'arrFields = objTemp.Fields
            Dim strContent As String = objBString.ToUTF8(strContentTemp)
            arrFields = objBTemplate.getArrayFromTemplate(strContentTemp)

            If intTotalItem < 0 Then ' View all
                intFrom = LBound(arrItemID)
                intTo = UBound(arrItemID)
            Else
                intFrom = 0
                intTo = intTotalItem
            End If
            For intCount = intFrom To intTo
                If intCount >= UBound(arrItemID) Then
                    Exit For
                End If
                strItemIDs = strItemIDs & arrItemID(intCount) & ","
            Next intCount
            If strItemIDs <> "" Then
                strItemIDs = Trim(strItemIDs)
                While Right(strItemIDs, 1) = ","
                    strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                    strItemIDs = Trim(strItemIDs)
                End While
            End If

            ' generate 3 Table
            ' TblItem + TblHolding + TblField
            Call Me.Generate3Table(arrFields, strItemIDs)
            For intCountPg = intFrom To intTo
                If intCountPg >= UBound(arrItemID) Then
                    Exit For
                End If
                strContentTemp = strContent
                ReDim arrData(UBound(arrFields))
                For intCount = 0 To UBound(arrFields)
                    strTag = arrFields(intCount)
                    If InStr(UCase(strTag), ":UPPER") > 0 Then
                        blnUpperIt = True
                    Else
                        blnUpperIt = False
                    End If
                    strTag = Trim(Replace(LCase(arrFields(intCount)), ":upper", ""))
                    If InStr(strDumTags, strTag & ",") > 0 Then
                        strFilter = "ItemID=" & arrItemID(intCountPg)
                        objrowi = TblItem.Select(strFilter)
                        strFilter = ""
                        If objrowi.GetUpperBound(0) > -1 Then
                            Select Case strTag
                                Case "id"
                                    arrData(intCount) = objrowi(0).Item("ItemID") & Chr(9)
                                Case "no"
                                    arrData(intCount) = arrIndex(intCountPg) & Chr(9)
                                Case "leader"
                                    arrData(intCount) = Replace(objrowi(0).Item("Leader"), " ", "&nbsp;") & Chr(9)
                                Case "001"
                                    arrData(intCount) = objrowi(0).Item("Code") & Chr(9)
                                Case "907"
                                    arrData(intCount) = objrowi(0).Item("CoverPicture") & Chr(9)
                                Case "911"
                                    arrData(intCount) = objrowi(0).Item("Cataloguer") & Chr(9)
                                Case "912"
                                    arrData(intCount) = objrowi(0).Item("Reviewer") & Chr(9)
                                Case "925"
                                    arrData(intCount) = objrowi(0).Item("MediumID") & Chr(9)
                                Case "926"
                                    arrData(intCount) = objrowi(0).Item("AccessLevel") & Chr(9)
                                Case "927"
                                    arrData(intCount) = objrowi(0).Item("TypeID") & Chr(9)
                            End Select
                        End If
                    End If
                    ' k co holding
                    If InStr(strTag, "holding") = 0 Then
                        strTagTmp = Left(strTag, 3)
                        strFilter = "ItemID=" & arrItemID(intCountPg) & " AND FieldCode='" & strTagTmp & "'"
                        objrowi = TblField.Select(strFilter)
                        strFilter = ""
                        For inti = 0 To objrowi.GetUpperBound(0)
                            strGenNote = ""
                            Select Case Left(strTag, 3)
                                Case "246"
                                    If CStr(objrowi(inti).Item("Ind2") & "") <> "" Then
                                        Select Case CStr(objrowi(inti).Item("Ind2") & "")
                                            Case "2"
                                                strGenNote = "<I>" & arrLabel(0) & ":</I> "
                                            Case "3"
                                                strGenNote = "<I>" & arrLabel(1) & ":</I> "
                                            Case "4"
                                                strGenNote = "<I>" & arrLabel(2) & ":</I> "
                                            Case "5"
                                                strGenNote = "<I>" & arrLabel(3) & ":</I> "
                                            Case "6"
                                                arrData(intCount) = "<I>" & arrLabel(4) & ":</I> "
                                            Case "7"
                                                strGenNote = "<I>" & arrLabel(5) & ":</I> "
                                            Case "8"
                                                strGenNote = "<I>" & arrLabel(6) & ":</I> "
                                        End Select
                                    End If
                                Case "247"
                                    If CStr(objrowi(inti).Item("Ind2") & "") <> "" Then
                                        Select Case CStr(objrowi(inti).Item("Ind2") & "")
                                            Case "0"
                                                strGenNote = "<I>" & arrLabel(7) & ":</I> "
                                        End Select
                                    End If
                            End Select
                            If Len(strTag) > 3 Then
                                strSubFieldCode = Right(strTag, 2)
                                Call objBString.ParseField(strSubFieldCode, objrowi(inti).Item("Content"), "tr" & Chr(9), arrSubVal)

                                arrData(intCount) = arrData(intCount) & strGenNote & objBString.TheDisplayOne(arrSubVal(0)) & Chr(9)
                            Else
                                arrData(intCount) = arrData(intCount) & strGenNote & objBString.TheDisplayOne(objrowi(inti).Item("Content")) & Chr(9)
                            End If
                        Next inti
                    ElseIf InStr(strTag, "holdingcomposite") = 1 Then
                        ' co holdingcomposite
                        If InStr(strTag, ":lib") > 0 Then
                            blnHaveLib = True
                        Else
                            blnHaveLib = False
                        End If
                        If InStr(strTag, ":inventory") > 0 Then
                            blnHaveLoc = True
                        Else
                            blnHaveLoc = False
                        End If
                        If InStr(strTag, ":shelf") > 0 Then
                            blnHaveShelf = True
                        Else
                            blnHaveShelf = False
                        End If
                        'If IsNumeric(arrItemID(intCountPg)) Then
                        arrData(intCount) = objBInput.GenerateCompositeHoldings(arrItemID(intCountPg), blnHaveLib, blnHaveLoc, blnHaveShelf, 0, 0, ".") & Chr(9)
                        'End If
                    Else
                        ' truong hop con lai
                        strFilter = "ItemID=" & arrItemID(intCountPg)
                        objrowi = TblHolding.Select(strFilter)
                        strFilter = ""
                        For inti = 0 To objrowi.GetUpperBound(0)
                            If InStr(strTag, ":lib") > 0 Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("Code") & "."
                            End If
                            If InStr(strTag, ":inventory") > 0 And objrowi(inti).Item("Symbol") <> "" Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("Symbol") & "."
                            End If
                            If InStr(strTag, ":shelf") > 0 And (objrowi(inti).Item("Shelf") & "") <> "" Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("Shelf") & "."
                            End If
                            If InStr(strTag, ":number") > 0 Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("CopyNumber")
                            End If
                            If InStr(strTag, ":callnumber") > 0 Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("CallNumber")
                            End If
                            arrData(intCount) = arrData(intCount) & Chr(9)
                        Next inti
                    End If
                    If arrData(intCount) <> "" Then
                        arrData(intCount) = Left(arrData(intCount), Len(arrData(intCount)) - 1)
                        arrData(intCount) = objBString.ToUTF8(CStr(arrData(intCount)))
                    End If
                    If blnUpperIt Then
                        'arrData(intCount) = objUpc.Upper(arrData(intCount))
                        arrData(intCount) = UCase(arrData(intCount))
                    End If
                    strContentTemp = Replace(strContentTemp, "<$" & arrFields(intCount) & "$>", arrData(intCount))
                Next intCount
                ReDim Preserve arrRet(lngCountRet)
                srtStreamTmp = ""
                'srtStreamTmp = objTemp.Generate(arrData)
                srtStreamTmp = strContentTemp
                strHeadTmp = Me.ProGroupVal(srtStreamTmp, strCurrGrp)
                If srtStreamTmp <> "" And Not IsDBNull(srtStreamTmp) Then
                    srtStreamTmp = objBString.ToUTF8Back(srtStreamTmp)
                    srtStreamTmp = Left(srtStreamTmp, InStr(srtStreamTmp, "-----//-----") - 1)
                    srtStreamTmp = Replace(srtStreamTmp, "  ", "&nbsp;&nbsp;")
                End If
                arrRet(lngCountRet) = arrTitle(CLng(arrIndex(intCountPg))) & strHeadTmp & objBString.TrimSubFieldCodes(srtStreamTmp & "")
                lngCountRet = lngCountRet + 1
            Next intCountPg
            Return arrRet
        End Function

        Public Function GenerateData(ByVal intPageCount As Integer) As Object
            Dim arrRet()
            Dim lngCountRet As Long = 0
            Dim srtStreamTmp As String = ""
            Dim strItemIDs As String = ""
            Dim intCount As Integer
            Dim intCountPg As Integer
            Dim inti As Integer
            Dim blnUpperIt As Boolean = False
            Dim strTag As String = ""
            Dim strTagTmp As String = ""
            Dim strFilter As String = ""
            Dim strGenNote As String = ""
            Dim strSubFieldCode As String = ""
            Dim arrSubVal()
            Dim blnHaveLib As Boolean = False
            Dim blnHaveLoc As Boolean = False
            Dim blnHaveShelf As Boolean = False
            Dim arrData()
            Dim objrowi() As DataRow
            Dim TblTemp As New DataTable
            Dim strContentTemp As String
            Dim strCurrGrp As String
            Dim strHeadTmp As String
            Dim intFrom As Integer
            Dim intTo As Integer

            'read template Table
            objBTemplate.TemplateID = intTemplateID
            TblTemp = objBTemplate.GetTemplate
            If TblTemp.Rows.Count > 0 Then
                strContentTemp = TblTemp.Rows(0).Item("Content")
                If strGroupBy <> "" Then
                    strContentTemp = strContentTemp & "-----//-----<$" & strGroupBy & ",,,,,1$>"
                Else
                    strContentTemp = strContentTemp & "-----//-----"
                End If
            Else
                strContentTemp = ""
            End If
            'objTemp.Template = objBString.ToUTF8(strContentTemp)
            'arrFields = objTemp.Fields
            'Dim strContent As String = objBString.ToUTF8(strContentTemp)
            Dim strContent As String = strContentTemp
            arrFields = objBTemplate.getArrayFromTemplate(strContentTemp)

            ' make ItemIDs string
            'If Not blnRetriveAll Then
            intFrom = (intPageCount - 1) * intPageSize
            intTo = intPageCount * intPageSize - 1
            'Else
            '    intFrom = 0
            '    intTo = UBound(arrItemID)
            'End If
            For intCount = intFrom To intTo
                If intCount >= arrItemID.Length Then
                    Exit For
                End If
                strItemIDs = strItemIDs & arrItemID(intCount) & ","
            Next intCount
            If strItemIDs <> "" Then
                strItemIDs = Trim(strItemIDs)
                While Right(strItemIDs, 1) = ","
                    strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                    strItemIDs = Trim(strItemIDs)
                End While
            End If

            ' generate 3 Table
            ' TblItem + TblHolding + TblField
            Call Me.Generate3Table(arrFields, strItemIDs)
            For intCountPg = intFrom To intTo
                'For intCountPg = 0 To 173
                If intCountPg >= arrItemID.Length Then
                    Exit For
                End If
                strContentTemp = strContent
                ReDim arrData(UBound(arrFields))
                For intCount = 0 To UBound(arrFields)
                    strTag = arrFields(intCount)
                    If InStr(UCase(strTag), ":UPPER") > 0 Then
                        blnUpperIt = True
                    Else
                        blnUpperIt = False
                    End If
                    strTag = Trim(Replace(LCase(arrFields(intCount)), ":upper", ""))
                    If InStr(strDumTags, strTag & ",") > 0 Then
                        strFilter = "ItemID=" & arrItemID(intCountPg)
                        objrowi = TblItem.Select(strFilter)
                        strFilter = ""
                        If objrowi.GetUpperBound(0) > -1 Then
                            Select Case strTag
                                Case "id"
                                    arrData(intCount) = objrowi(0).Item("ItemID") & Chr(9)
                                Case "no"
                                    arrData(intCount) = arrIndex(intCountPg) & Chr(9)
                                Case "leader"
                                    arrData(intCount) = Replace(objrowi(0).Item("Leader"), " ", "&nbsp;") & Chr(9)
                                Case "001"
                                    arrData(intCount) = objrowi(0).Item("Code") & Chr(9)
                                Case "907"
                                    arrData(intCount) = objrowi(0).Item("CoverPicture") & Chr(9)
                                Case "911"
                                    arrData(intCount) = objrowi(0).Item("Cataloguer") & Chr(9)
                                Case "912"
                                    arrData(intCount) = objrowi(0).Item("Reviewer") & Chr(9)
                                Case "925"
                                    arrData(intCount) = objrowi(0).Item("MediumID") & Chr(9)
                                Case "926"
                                    arrData(intCount) = objrowi(0).Item("AccessLevel") & Chr(9)
                                Case "927"
                                    arrData(intCount) = objrowi(0).Item("TypeID") & Chr(9)
                            End Select
                        End If
                    End If
                    ' k co holding
                    If InStr(strTag, "holding") = 0 Then
                        strTagTmp = Left(strTag, 3)
                        strFilter = "ItemID=" & arrItemID(intCountPg) & " AND FieldCode='" & strTagTmp & "'"
                        objrowi = TblField.Select(strFilter)
                        strFilter = ""
                        For inti = 0 To objrowi.GetUpperBound(0)
                            strGenNote = ""
                            Select Case Left(strTag, 3)
                                Case "242"
                                Case "246"
                                    If CStr(objrowi(inti).Item("Ind2") & "") <> "" Then
                                        Select Case CStr(objrowi(inti).Item("Ind2") & "")
                                            Case "2"
                                                strGenNote = "<I>" & arrLabel(0) & ":</I> "
                                            Case "3"
                                                strGenNote = "<I>" & arrLabel(1) & ":</I> "
                                            Case "4"
                                                strGenNote = "<I>" & arrLabel(2) & ":</I> "
                                            Case "5"
                                                strGenNote = "<I>" & arrLabel(3) & ":</I> "
                                            Case "6"
                                                arrData(intCount) = "<I>" & arrLabel(4) & ":</I> "
                                            Case "7"
                                                strGenNote = "<I>" & arrLabel(5) & ":</I> "
                                            Case "8"
                                                strGenNote = "<I>" & arrLabel(6) & ":</I> "
                                        End Select
                                    End If
                                Case "247"
                                    If CStr(objrowi(inti).Item("Ind2") & "") <> "" Then
                                        Select Case CStr(objrowi(inti).Item("Ind2") & "")
                                            Case "0"
                                                strGenNote = "<I>" & arrLabel(7) & ":</I> "
                                        End Select
                                    End If
                            End Select
                            If Len(strTag) > 3 Then
                                strSubFieldCode = Right(strTag, 2)
                                Call objBString.ParseField(strSubFieldCode, objrowi(inti).Item("Content"), "tr" & Chr(9), arrSubVal)
                                arrData(intCount) = arrData(intCount) & strGenNote & objBString.TheDisplayOne(arrSubVal(0)) & Chr(9)
                            Else
                                arrData(intCount) = arrData(intCount) & strGenNote & objBString.TheDisplayOne(objrowi(inti).Item("Content")) & Chr(9)
                            End If
                        Next inti
                    ElseIf InStr(strTag, "holdingcomposite") = 1 Then
                        ' co holdingcomposite
                        If InStr(strTag, ":lib") > 0 Then
                            blnHaveLib = True
                        Else
                            blnHaveLib = False
                        End If
                        If InStr(strTag, ":inventory") > 0 Then
                            blnHaveLoc = True
                        Else
                            blnHaveLoc = False
                        End If
                        If InStr(strTag, ":shelf") > 0 Then
                            blnHaveShelf = True
                        Else
                            blnHaveShelf = False
                        End If
                        'If IsNumeric(arrItemID(intCountPg)) Then
                        arrData(intCount) = objBInput.GenerateCompositeHoldings(arrItemID(intCountPg), blnHaveLib, blnHaveLoc, blnHaveShelf, 0, 0, ".") & Chr(9)
                        'End If
                    Else
                        ' truong hop con lai
                        strFilter = "ItemID=" & arrItemID(intCountPg)
                        objrowi = TblHolding.Select(strFilter)
                        strFilter = ""
                        For inti = 0 To objrowi.GetUpperBound(0)
                            If InStr(strTag, ":lib") > 0 Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("Code") & "."
                            End If
                            If InStr(strTag, ":inventory") > 0 And objrowi(inti).Item("Symbol") <> "" Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("Symbol") & "."
                            End If
                            If InStr(strTag, ":shelf") > 0 And (objrowi(inti).Item("Shelf") & "") <> "" Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("Shelf") & "."
                            End If
                            If InStr(strTag, ":number") > 0 Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("CopyNumber")
                            End If
                            If InStr(strTag, ":callnumber") > 0 Then
                                arrData(intCount) = arrData(intCount) & objrowi(inti).Item("CallNumber")
                            End If
                            arrData(intCount) = arrData(intCount) & Chr(9)
                        Next inti
                    End If
                    If arrData(intCount) <> "" Then
                        arrData(intCount) = Left(arrData(intCount), Len(arrData(intCount)) - 1)
                        'arrData(intCount) = objBString.ToUTF8(CStr(arrData(intCount)))
                        arrData(intCount) = CStr(arrData(intCount))
                    End If
                    If blnUpperIt Then
                        'arrData(intCount) = objUpc.Upper(arrData(intCount))
                        arrData(intCount) = UCase(arrData(intCount))
                    End If
                    strContentTemp = Replace(strContentTemp, "<$" & arrFields(intCount) & "$>", arrData(intCount))
                Next intCount
                ReDim Preserve arrRet(lngCountRet)
                srtStreamTmp = ""
                'srtStreamTmp = objTemp.Generate(arrData)
                srtStreamTmp = strContentTemp
                strHeadTmp = Me.ProGroupVal(srtStreamTmp, strCurrGrp)
                If srtStreamTmp <> "" And Not IsDBNull(srtStreamTmp) Then
                    'srtStreamTmp = objBString.ToUTF8Back(srtStreamTmp)
                    srtStreamTmp = Left(srtStreamTmp, InStr(srtStreamTmp, "-----//-----") - 1)
                    srtStreamTmp = Replace(srtStreamTmp, "  ", "&nbsp;&nbsp;")
                End If
                'Quocdd
                ' remove h1 tag
                ' arrRet(lngCountRet) = "<CENTER><H1>" & arrTitle(CLng(arrIndex(intCountPg))) & "</H1></CENTER>" & strHeadTmp & objBString.TrimSubFieldCodes(srtStreamTmp & "")
                arrRet(lngCountRet) = "<CENTER></CENTER>" & strHeadTmp & objBString.TrimSubFieldCodes(srtStreamTmp & "")
                lngCountRet = lngCountRet + 1
            Next intCountPg
            Return arrRet
        End Function

        Public Function ProGroupVal(ByVal strStream As String, ByRef strCurrentGrp As String) As String
            Dim strGroupSubFieldCode As String
            Dim intGroupLen As Integer
            Dim strGroupVal As String
            Dim arrSubGroupVal()
            Dim strGrpVal As String
            Dim strRet As String = ""
            Dim strStreamTmp As String = ""

            strStreamTmp = objBString.ToUTF8Back(strStream)
            If strGroupBy <> "" Then
                If InStr(strGroupBy, "$") > 0 Then
                    strGroupSubFieldCode = Mid(strGroupBy, 4, 2)
                    strGroupBy = Left(strGroupBy, 3)
                Else
                End If
            End If
            If InStr(strGroupBy, ":") > 0 Then
                intGroupLen = CInt(Right(strGroupBy, Len(strGroupBy) - InStr(strGroupBy, ":")))
            End If

            If strGroupBy <> "" Then
                If Len(strStreamTmp) - InStr(strStreamTmp, "-----//-----") - 11 > 0 Then
                    strGroupVal = Right(strStreamTmp, Len(strStreamTmp) - InStr(strStreamTmp, "-----//-----") - 11)
                    If strGroupSubFieldCode <> "" Then
                        Call objBString.ParseField(strGroupSubFieldCode, strGroupVal, " ", arrSubGroupVal)
                        strGroupVal = arrSubGroupVal(0)
                    Else
                        strGroupVal = objBString.TrimSubFieldCodes(strGroupVal)
                    End If
                    strGroupVal = Trim(objBString.GEntryTrim(strGroupVal))
                    Do While InStr(strGroupVal, "(") > 0
                        strGrpVal = Left(strGroupVal, InStr(strGroupVal, "(") - 1)
                        strGroupVal = Right(strGroupVal, Len(strGroupVal) - InStr(strGroupVal, "("))
                        If InStr(strGroupVal, ")") > 0 Then
                            strGrpVal = strGrpVal & Right(strGroupVal, Len(strGroupVal) - InStr(strGroupVal, ")"))
                        Else
                            strGrpVal = strGrpVal & strGroupVal
                        End If
                        strGroupVal = strGrpVal
                    Loop
                    If intGroupLen > 0 Then
                        strGroupVal = Left(strGroupVal, intGroupLen)
                    End If
                    If UCase(strCurrentGrp) <> UCase(strGroupVal) Then
                        strCurrentGrp = strGroupVal
                        strRet = "<H2><CENTER>" & strCurrentGrp & "</CENTER></H2>"
                    End If
                End If
            End If
            'strCurrentGrp = objBString.ToUTF8Back(strCurrentGrp)
            Return strRet
        End Function

        '  Save data to file .htm and convert to .doc
        Public Function SaveFile(ByVal strContent As String, Optional ByVal strServerRootPath As String = "") As String
            Try
                ' Dim Doc2HTML As New DOC2HTMLLib.Converter
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
                'Doc2HTML.HtmlToDocFile(strPathHtm, strPathDoc, 1)
                'If Doc2HTML.ErrorCode = 0 Then
                '    Dim filUpload As File
                '    filUpload.Delete(strPathHtm)
                '    Call objBComDB.InsertSysDownloadFile()
                '    SaveFile = strFileName ' Convert successful
                'Else
                '    strErrorMsg = Doc2HTML.ErrorMessage
                '    intErrorCode = Doc2HTML.ErrorCode
                'End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

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

                objBTemplate.DBServer = strDBServer
                objBTemplate.InterfaceLanguage = strInterfaceLanguage
                objBTemplate.ConnectionString = strConnectionString
                objBTemplate.Initialize()

                objBInput.DBServer = strDBServer
                objBInput.InterfaceLanguage = strInterfaceLanguage
                objBInput.ConnectionString = strConnectionString
                objBInput.Initialize()

                objDGenIdx.ConnectionString = strConnectionString
                objDGenIdx.DBServer = strDBServer
                objDGenIdx.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBComDB Is Nothing Then
                    objBComDB.Dispose(True)
                    objBComDB = Nothing
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
                If Not objDGenIdx Is Nothing Then
                    objDGenIdx.Dispose(True)
                    objDGenIdx = Nothing
                End If
                'objTemp = Nothing
                'objUpc = Nothing
            Finally
                Me.Dispose()
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace