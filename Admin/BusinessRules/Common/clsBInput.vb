' clsBInput class
' Purpose: used to insert (update) informations of the Lib_tblItem
' Creator: Oanhtn
' Created Date: 30/12/2003
' LastModifiedDate: 09/01/2004 by Oanhtn

Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports eMicLibAdmin.DataAccess.Common
Imports System.Linq
Imports System.Collections.Generic

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class clsBInput
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private arrLabelStr() As Object
        Private strItemCode As String = ""
        Private lngRecID As Long = 0
        Private lngWorkID As Long = 0
        Private arrFieldName() As Object
        Private arrFieldValue() As Object
        Private strCodeOut As String
        Private strSQLStatement As String = ""
        Private intLoanType As Integer
        Private intAcqSource As Integer
        Private intUnitPrice As Integer
        Private strAdditionalBy As String


        Private objDInput As New clsDInput
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private tblReferences As New DataTable
        Private intReuse As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        'Parameter Sytem
        Private objPara() As String = {"LDAP_AUTHENTICATION_ENABLE", "LDAP_LOCATION", "LDAP_SERVER_TYPE", "LDAP_LOGON_USER", "LDAP_LOGON_PASSWORD", "CATALOG_WORKSTATIONS", "PATRON_WORKSTATIONS", "SERIAL_WORKSTATIONS", "ACQUISITION_WORKSTATIONS", "CIRCULATION_WORKSTATIONS", "ADMIN_WORKSTATIONS", "ILL_WORKSTATIONS", "EDELIV_WORKSTATIONS", "EDATA_LOCATIONS"}


        ' Reuse Property
        Public Property Reuse() As Integer
            Get
                Reuse = intReuse
            End Get
            Set(ByVal Value As Integer)
                intReuse = Value
            End Set
        End Property

        ' LabelStr Property
        Public Property LabelStr() As Object
            Get
                LabelStr = arrLabelStr
            End Get
            Set(ByVal Value As Object)
                arrLabelStr = Value
            End Set
        End Property

        ' FieldName Property
        Public Property FieldName() As Object
            Get
                FieldName = arrFieldName
            End Get
            Set(ByVal Value As Object)
                arrFieldName = Value
            End Set
        End Property

        ' FieldValue Property
        Public Property FieldValue() As Object
            Get
                FieldValue = arrFieldValue
            End Get
            Set(ByVal Value As Object)
                arrFieldValue = Value
            End Set
        End Property

        ' ItemCode property
        Public Property ItemCode() As String
            Get
                ItemCode = strItemCode
            End Get
            Set(ByVal Value As String)
                strItemCode = Value
            End Set
        End Property

        ' ItemCode property
        Public Property CodeOut() As String
            Get
                CodeOut = strCodeOut
            End Get
            Set(ByVal Value As String)
                strCodeOut = Value
            End Set
        End Property

        ' lngRecID property
        Public Property RecID() As Long
            Get
                RecID = lngRecID
            End Get
            Set(ByVal Value As Long)
                lngRecID = Value
            End Set
        End Property

        ' WorkID property
        Public Property WorkID() As Long
            Get
                WorkID = lngWorkID
            End Get
            Set(ByVal Value As Long)
                lngWorkID = Value
            End Set
        End Property
        ' ItemCode property
        Public Property SQLStatement() As String
            Get
                SQLStatement = strSQLStatement
            End Get
            Set(ByVal Value As String)
                strSQLStatement = Value
            End Set
        End Property

        ' LoanType Property
        Public Property LoanType() As Integer
            Get
                Return intLoanType
            End Get
            Set(ByVal Value As Integer)
                intLoanType = Value
            End Set
        End Property
        ' AcqSource Property
        Public Property AcqSource() As Integer
            Get
                Return intAcqSource
            End Get
            Set(ByVal Value As Integer)
                intAcqSource = Value
            End Set
        End Property
        ' UnitPrice Property
        Public Property UnitPrice() As Integer
            Get
                Return intUnitPrice
            End Get
            Set(ByVal Value As Integer)
                intUnitPrice = Value
            End Set
        End Property
        ' ItemCode property
        Public Property AdditionalBy() As String
            Get
                AdditionalBy = strAdditionalBy
            End Get
            Set(ByVal Value As String)
                strAdditionalBy = Value
            End Set
        End Property


        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init clsDAcqCommon object
            objDInput.DBServer = strDBServer
            objDInput.ConnectionString = strConnectionString
            objDInput.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' tblReferences contains all record in DicID table
            objDInput.SQLStatement = "SELECT * FROM Cat_tblDicList"
            tblReferences = objDInput.GetData
        End Sub

        ' Insert (update) item's information
        Public Function Update(ByVal intFormID As Integer, ByVal intImportRec As Integer, Optional ByVal blnKeepItemCode As Boolean = False, Optional ByVal blnFromAcq As Boolean = False) As Integer
            On Error GoTo RollBack
            ' Declare variables
            Dim arrSrc() As String = {"OÀ", "OÁ", "OẠ", "OẢ", "OÃ", "UỶ", "UÝ", "UỴ", "UỸ", "UỲ", "OÈ", "OÉ", "OẸ", "OẺ", "OẼ"}
            Dim arrDes() As String = {"ÒA", "ÓA", "ỌA", "ỎA", "ÕA", "ỦY", "ÚY", "ỤY", "ŨY", "ÙY", "ÒE", "ÓE", "ỌE", "ỎE", "ÕE"}

            Dim blnUpdateFulltext As Boolean = False
            Dim lngMainID As Long
            Dim strRecordType As Char
            Dim strBibLevel As String = ""
            Dim strTag001 As String = ""
            Dim strTag040a As String = ""
            Dim strTag041a As String = "" ' SourceCountryID
            Dim strTag090 As String = ""
            Dim strTag090a As String = ""
            Dim strTag900 As String = ""
            Dim strTag911 As String = ""
            Dim strTag912 As String = ""
            Dim strTag925 As String = ""
            Dim strTag926 As String = ""
            Dim strTag907 As String = ""
            Dim strUpdateStatement As String = ""
            Dim strSQLStatement As String = ""
            Dim strTempoSQL As String = ""
            Dim strExclTags As String = "001,900,907,911,912,925,926,927"
            Dim strLeader As String = "00025nam a2200024 a 4500" ' Default strLeader value
            Dim strTag As String = ""
            Dim intIndex As Integer = 0 ' Index
            Dim intTypeID As Integer = 0
            Dim str915ID As String = ""
            Dim strItemType As String = ""
            Dim intFuncID As Integer = 0 ' Function ID
            Dim intCount As Integer = 0

            Dim arrSubVal As Object()
            Dim tblItem As New DataTable

            ' Begin transaction
            objDInput.BeginInputTrans()
            objDInput.ErrorMsg = ""
            objDInput.ErrorCode = 0
            objDInput.LibID = intLibID
            ' Check is not a item
            If Not IsArray(arrFieldName) Or Not IsArray(arrFieldValue) Then
                ErrorMsg = arrLabelStr(3)
                Update = 0
                Exit Function
            End If

            ' Get strLeader
            intIndex = FindIndex(arrFieldName, "000")
            If intIndex >= 0 Then
                strLeader = arrFieldValue(intIndex)
            End If

            If Not strItemCode = "" Or Not lngRecID = 0 Then
                strUpdateStatement = "UPDATE Lib_tblItem SET FormID = " & intFormID & ", Leader = '" & strLeader & "', BibLevel = '" & Mid(strLeader, 8, 1) & "', RecordType = '" & Mid(strLeader, 7, 1) & "'"
                If Not strItemCode = "" Then
                    ' Get ItemID
                    If Not strDBServer = "ORACLE" Then
                        strSQLStatement = "SELECT ID FROM Lib_tblItem WHERE UPPER(Code) = N'" & UCase(strItemCode) & "'"
                    Else
                        strSQLStatement = "SELECT ID FROM Lib_tblItem WHERE Upper(Code) = Upper('" & strItemCode & "')"
                    End If
                    objDInput.SQLStatement = strSQLStatement

                    tblItem = objDInput.GetData
                    If Not tblItem Is Nothing Then
                        If Not tblItem.Rows.Count = 0 Then
                            lngMainID = CLng(tblItem.Rows(0).Item("ID"))
                        Else
                            Update = 0
                            ErrorMsg = arrLabelStr(0) ' strItemCode does not exist
                            Exit Function
                        End If
                    Else
                        Update = 0
                        ErrorMsg = arrLabelStr(0) ' strItemCode does not exist
                        Exit Function
                    End If
                Else
                    If Not intReuse = 1 Then
                        lngMainID = lngRecID
                        strSQLStatement = "SELECT Code FROM Lib_tblItem WHERE ID = " & lngRecID
                        objDInput.SQLStatement = strSQLStatement
                        tblItem = objDInput.GetData
                        If Not tblItem Is Nothing Then
                            If Not tblItem.Rows.Count = 0 Then
                                strItemCode = tblItem.Rows(0).Item("Code")
                            Else
                                Update = 0
                                ErrorMsg = arrLabelStr(0) ' strItemCode does not exist
                                Exit Function
                            End If
                        Else
                            Update = 0
                            ErrorMsg = arrLabelStr(0) ' strItemCode does not exist
                            Exit Function
                        End If
                    End If
                End If
            End If

            For intIndex = LBound(arrFieldName) To UBound(arrFieldName)
                strTag = strTag & "'" & arrFieldName(intIndex) & "', "
            Next

            objDInput.SQLStatement = "UPDATE Cat_tblQueue SET Reviewed = 1 WHERE ITEMID = " & lngMainID
            objDInput.ExecuteQuery()

            strTag = Left(strTag, Len(strTag) - 2)

            ' UPDATE Lib_tblItem Table

            ' An imported bib record is not allowed to overlay some local predefined 9XX fields on Lib_tblItem table even
            ' when it updates an local bib record

            ' Get ItemCode
            intIndex = FindIndex(arrFieldName, "001")
            If intIndex >= 0 Then
                strTag001 = arrFieldValue(intIndex)
            End If

            If intImportRec = 1 And Not strItemCode = "" Then
                strSQLStatement = "UPDATE Lib_tblItem SET FormID = " & intFormID & ", strLeader = '" & strLeader & "', BibLevel = '" & Mid(strLeader, 8, 1) & "', RecordType = '" & Mid(strLeader, 7, 1) & "' WHERE ID = " & lngMainID
            Else
                ' The record on Lib_tblItem table can be either created or updated depend on whether the strItemCode is specified

                ' Get tag 040$a value
                intIndex = FindIndex(arrFieldName, "040")
                If intIndex >= 0 Then
                    Call ParseField("$a", arrFieldValue(intIndex), "##", arrSubVal)
                    If arrSubVal(0) = "" Then
                        strTag040a = "NULL"
                    Else
                        strTag040a = PickReferenceID(objBCSP.ConvertItBack(arrSubVal(0)), "Lib_tblHoldingLibrary", "ID", "Code")
                    End If
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", SourceAgencyID = " & strTag040a
                    End If
                Else
                    strTag040a = "NULL"
                End If

                ' CallNumber
                Dim callNumber As String = ""
                'intIndex = FindIndex(arrFieldName, "090")
                intIndex = FindIndex(arrFieldName, "082")
                If intIndex >= 0 Then
                    'Call ParseField("$a,$b", objBCSP.DoubleSingleQuote(arrFieldValue(intIndex)), "##", arrSubVal)
                    Call ParseField("$a", objBCSP.DoubleSingleQuote(arrFieldValue(intIndex)), "##", arrSubVal)
                    'strTag090a = arrSubVal(0) & " " & arrSubVal(1)
                    strTag090a = arrSubVal(0)
                    strTag090a = strTag090a.Trim()
                    callNumber = strTag090a
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", CallNumber = '" & objBCSP.ConvertItBack(strTag090a) & "'"
                        ' Update Holding table by set new value of CallNumber field
                        Select Case UCase(strDBServer)
                            Case "ORACLE"
                                strTempoSQL = "UPDATE Lib_tblHolding SET CallNumber = '" & objBCSP.ConvertItBack(strTag090a) & "' WHERE ItemID = " & lngMainID
                            Case "SQLSERVER"
                                strTempoSQL = "UPDATE Lib_tblHolding SET CallNumber = N'" & objBCSP.ConvertItBack(strTag090a) & "' WHERE ItemID = " & lngMainID
                        End Select
                        objDInput.SQLStatement = strTempoSQL
                        Call objDInput.ExecuteQuery()
                    End If
                Else
                    strTag090a = ""
                End If


                ' Get tag 900 value (New record)
                intIndex = FindIndex(arrFieldName, "900")
                If intIndex >= 0 Then
                    strTag900 = arrFieldValue(intIndex)
                    If strTag900.ToUpper.Trim <> "0" Then
                        strTag900 = "1"
                    Else
                        strTag900 = "0"
                    End If
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", NewRecord = " & strTag900
                    End If
                Else
                    strTag900 = 1
                End If

                ' Get tag 907 value (CoverPicture)
                intIndex = FindIndex(arrFieldName, "907")
                If intIndex >= 0 Then
                    strTag907 = arrFieldValue(intIndex)
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", CoverPicture = '" & strTag907 & "'"
                    End If
                Else
                    strTag907 = ""
                End If

                ' Lenta add more for CAT_DIC_THESIS_SUBJECT
                ' Get tag 915 value
                'intIndex = FindIndex(arrFieldName, "915")
                'If intIndex >= 0 Then
                '    str915ID = PickReference915ID(objBCSP.ConvertItBack(arrFieldValue(intIndex)))
                'End If

                ' Get tag 927 value (ItemType)
                intIndex = FindIndex(arrFieldName, "927")
                If intIndex >= 0 Then
                    intTypeID = PickReferenceID(objBCSP.ConvertItBack(arrFieldValue(intIndex)), "Cat_tblDic_ItemType", "ID", "TypeCode")
                    strItemType = arrFieldValue(intIndex)
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", TypeID = " & intTypeID
                    End If

                    intIndex = FindIndex(arrFieldName, "856")
                    If intIndex >= 0 Then
                        If arrFieldValue(intIndex) = "" AndAlso intTypeID = 1 Then
                            strUpdateStatement = strUpdateStatement & ", FormatId = 0"
                        End If
                    End If
                Else
                    'intTypeID = 1
                    intTypeID = 3
                End If

                ' Get tag 926 value (AccessLevel)
                intIndex = FindIndex(arrFieldName, "926")
                If intIndex >= 0 Then
                    strTag926 = arrFieldValue(intIndex)
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", AccessLevel = " & strTag926
                    End If
                Else
                    strTag926 = "0"
                End If

                ' Get tag 925 value (Medium)
                intIndex = FindIndex(arrFieldName, "925")
                If intIndex >= 0 Then
                    strTag925 = PickReferenceID(objBCSP.ConvertItBack(arrFieldValue(intIndex)), "Cat_tblDicMedium", "ID", "Code")
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", MediumID = " & strTag925
                    End If
                Else
                    strTag925 = 3 ' Papers
                End If

                ' Get tag 911 value (Cataloguer)
                intIndex = FindIndex(arrFieldName, "911")
                If intIndex >= 0 Then
                    strTag911 = objBCSP.DoubleSingleQuote(arrFieldValue(intIndex))
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", Cataloguer = N'" & objBCSP.ConvertItBack(strTag911) & "'"
                    End If
                Else
                    strTag911 = ""
                End If

                ' Get tag 912 value (Reviewer)
                intIndex = FindIndex(arrFieldName, "912")
                If intIndex >= 0 Then
                    strTag912 = objBCSP.DoubleSingleQuote(arrFieldValue(intIndex))
                    If Not strItemCode = "" Then
                        strUpdateStatement = strUpdateStatement & ", Reviewer = N'" & objBCSP.ConvertItBack(strTag912) & "'"
                    End If
                Else
                    strTag912 = ""
                End If

                ' INSERT A RECORD INTO ITEM table
                If strItemCode = "" Then
                    ' Get BookCode
                    If intImportRec = 1 Then
                        strTag001 = Gen001(0)
                    Else
                        intIndex = FindIndex(arrFieldName, "001")
                        If intIndex >= 0 Then
                            If blnKeepItemCode = True Then
                                Dim strSQLCheckCode As String
                                Dim tblItemCode As DataTable

                                ' Check the duplicate item code
                                If Not strDBServer = "ORACLE" Then
                                    strSQLCheckCode = "SELECT ID FROM Lib_tblItem WHERE UPPER(Code) = N'" & UCase(arrFieldValue(intIndex)) & "'"
                                Else
                                    strSQLCheckCode = "SELECT ID FROM Lib_tblItem WHERE Upper(Code) = Upper('" & arrFieldValue(intIndex) & "')"
                                End If

                                objDInput.SQLStatement = strSQLCheckCode
                                tblItemCode = objDInput.GetData

                                ' Gen the Lib_tblItem Code
                                If Not tblItemCode Is Nothing Then
                                    ' If duplicate, gen new Lib_tblItem code
                                    If Not tblItemCode.Rows.Count = 0 Then
                                        strTag001 = Gen001(0)
                                    Else
                                        strTag001 = arrFieldValue(intIndex)
                                    End If
                                Else
                                    strTag001 = arrFieldValue(intIndex)
                                End If
                            Else
                                If strTag001 = "" Then
                                    strTag001 = Gen001(0)
                                End If
                            End If
                        Else
                            strTag001 = Gen001(0)
                        End If
                    End If

                    ' Get ItemID
                    lngMainID = CreateID("Lib_tblItem", "ID")

                    ' Forming Insert statement
                    Select Case UCase(strDBServer)
                        Case "ORACLE"
                            strSQLStatement = "INSERT INTO Lib_tblItem (BibLevel, SourceAgencyID, TypeID, FormID, RecordType, Leader, Code, AccessLevel, CreatedDate, Reviewer, Cataloguer, SourceCountryID, ID, MediumID, NewRecord, CoverPicture, CallNumber) "
                            strSQLStatement = strSQLStatement & " VALUES ('" & Mid(strLeader, 8, 1) & "', " & strTag040a & ", " & intTypeID & ", " & intFormID & ", '"
                            strSQLStatement = strSQLStatement & Mid(strLeader, 7, 1) & "', '" & strLeader & "', '" & strTag001 & "', " & strTag926 & ", SYSDATE, '" & strTag912 & "', '" & strTag911 & "', NULL, " & lngMainID & ", " & strTag925 & ", " & strTag900 & ", '" & strTag907 & "', '" & strTag090a & "')"
                        Case "SQLSERVER"
                            If blnFromAcq = False Then
                                strSQLStatement = "INSERT INTO Lib_tblItem (BibLevel, SourceAgencyID, TypeID, FormID, RecordType, Leader, Code, AccessLevel, CreatedDate, Reviewer, Cataloguer, SourceCountryID, ID, MediumID, NewRecord, CoverPicture, CallNumber, LibID) VALUES ('"
                                strSQLStatement = strSQLStatement & Mid(strLeader, 8, 1) & "', " & strTag040a & ", " & intTypeID & ", " & intFormID & ", '" & Mid(strLeader, 7, 1) & "', '"
                                strSQLStatement = strSQLStatement & strLeader & "', '" & strTag001 & "', " & strTag926 & ", GETDATE(), N'" & strTag912 & "', N'" & strTag911 & "', NULL, " & lngMainID & ", " & strTag925 & ", " & strTag900 & ", '" & strTag907 & "', N'" & strTag090a & "', " & intLibID & ")"
                            Else
                                strSQLStatement = "INSERT INTO Lib_tblItem (BibLevel, SourceAgencyID, TypeID, FormID, RecordType, Leader, Code, AccessLevel, CreatedDate, Reviewer, Cataloguer, SourceCountryID, ID, MediumID, NewRecord, CoverPicture, CallNumber, LibID, AcqSourceID, LoanTypeID, UnitPrice, AdditionalBy) VALUES ('"
                                strSQLStatement = strSQLStatement & Mid(strLeader, 8, 1) & "', " & strTag040a & ", " & intTypeID & ", " & intFormID & ", '" & Mid(strLeader, 7, 1) & "', '"
                                strSQLStatement = strSQLStatement & strLeader & "', '" & strTag001 & "', " & strTag926 & ", GETDATE(), N'" & strTag912 & "', N'" & strTag911 & "', NULL, " & lngMainID & ", " & strTag925 & ", " & strTag900 & ", '" & strTag907 & "', N'" & strTag090a & "', " & intLibID & ", " & intAcqSource & ", " & intLoanType & ", " & intUnitPrice & ", N'" & strAdditionalBy & "')"
                            End If

                    End Select
                    lngWorkID = lngMainID
                    strCodeOut = strTag001

                    ' Delete temp data in BOOKCODE_RES table
                    'Date : 12-12-2006
                    'modify by Lent, Tuannv
                    'If Not strDBServer = "ORACLE" Then
                    '    strTempoSQL = "DELETE FROM BOOKCODE_RES WHERE DATEDIFF(second, CreatedTime, GETDATE()) > 30*60 OR Code = '" & strTag001 & "'"
                    'Else
                    '    strTempoSQL = "DELETE FROM BOOKCODE_RES WHERE (SYSDATE - CreatedTime)*48 > 1 OR Code = '" & strTag001 & "'"
                    'End If
                    'objDInput.SQLStatement = strTempoSQL
                    'Call objDInput.ExecuteQuery()
                Else ' UPDATE A RECORD TO ITEM table
                    strCodeOut = strTag001
                    If Not strDBServer = "ORACLE" Then
                        strSQLStatement = strUpdateStatement & " WHERE ID = " & lngMainID
                    Else
                        strSQLStatement = strUpdateStatement & " WHERE ID = " & lngMainID
                    End If
                End If

                objDInput.SQLStatement = strSQLStatement
                Call objDInput.ExecuteQuery()

                ' Insert new record into SER_ITEM table
                If UCase(Trim(strItemType)) = "TT" Then
                    Dim tblExist As New DataTable
                    ' Check exists before insert new
                    objDInput.SQLStatement = "SELECT COUNT(*) AS Count FROM Ser_tblItem WHERE ItemID=" & lngMainID
                    tblExist = objDInput.GetData
                    If Not tblExist Is Nothing AndAlso tblExist.Rows.Count > 0 Then
                        If tblExist.Rows(0).Item(0) = 0 Then ' Not exists
                            objDInput.SQLStatement = "INSERT INTO Ser_tblItem (ItemID) VALUES (" & lngMainID & ")"
                            Call objDInput.ExecuteQuery()
                        End If
                    End If
                End If
            End If

            ' Release tblItem
            If Not tblItem Is Nothing Then
                tblItem.Dispose()
                tblItem = Nothing
            End If

            Dim intFunctionID As Integer
            Dim intCounter As Integer
            Dim intLanguageID As Integer
            Dim dtrData As DataRow() ' Datarows contain FieldID, FieldName after filtered
            Dim dtrRefData As New DataTable  ' DataTable contain References table data
            Dim row As DataRow
            Dim col As DataColumn

            ' Get data from MARC_BIB_FIELD
            strSQLStatement = "SELECT ID, FieldCode FROM Lib_tblMARCBibField WHERE FieldCode IN (" & strTag & ")"
            objDInput.SQLStatement = strSQLStatement
            tblItem = objDInput.GetData

            ' Select all tags assigned to the submitted cataloguing form.
            ' Insert tags' value to appropriate table
            strRecordType = Mid(strLeader, 7, 1)
            For intCount = LBound(arrFieldName) To UBound(arrFieldName)
                Select Case arrFieldName(intCount)
                    Case "008"
                        Dim strMainLang As String
                        Dim strVal008 As String
                        If InStr(arrFieldValue(intCount), "::") = 1 Then
                            strVal008 = Right(arrFieldValue(intCount), Len(arrFieldValue(intCount)) - 2)
                        Else
                            strVal008 = arrFieldValue(intCount)
                        End If
                        strMainLang = Trim(Mid(strVal008, 36, 3))
                        If Not strMainLang = "" Then
                            ' Insert new language
                            If Not strItemCode = "" Then
                                objDInput.SQLStatement = "DELETE FROM Lib_tblItemLanguage WHERE FieldCode = '008' AND ItemID = " & lngMainID
                                Call objDInput.ExecuteQuery()
                            End If
                            intLanguageID = PickReferenceID(strMainLang, "Cat_tblDic_Language", "ID", "ISOCode")
                            objDInput.SQLStatement = "INSERT INTO Lib_tblItemLanguage (ItemID, LanguageID, FieldCode) VALUES (" & lngMainID & ", " & intLanguageID & ", '008')"
                            Call objDInput.ExecuteQuery()
                        End If
                    Case Else
                End Select

                ' Update fields table
                dtrData = tblItem.Select("FieldCode = '" & arrFieldName(intCount) & "'")
                If InStr(strExclTags, arrFieldName(intCount)) = 0 AndAlso Not dtrData.Length = 0 Then
                    For Each row In dtrData
                        If Not IsDBNull(row.Item("FieldCode")) AndAlso Not arrFieldName(intCount) = "900" AndAlso Not arrFieldName(intCount) = "852" Then '852 Ma xep gia
                            If arrFieldName(intCount) = "008" Then
                                Call UpdateBlockField(arrFieldName(intCount), CStr(arrFieldValue(intCount)).Replace("'", "''"), lngMainID, row.Item("FieldCode"), 1, intImportRec)
                            ElseIf arrFieldName(intCount) = "060" Then 'B3 NLM DH Y DUOC
                                arrFieldValue(intCount) = Replace(arrFieldValue(intCount), "la", "")
                                arrFieldValue(intCount) = Replace(arrFieldValue(intCount), " ", "")
                                Call UpdateBlockField(arrFieldName(intCount), objBCSP.DoubleSingleQuote(arrFieldValue(intCount)), lngMainID, row.Item("FieldCode"), 1, intImportRec)
                            Else
                                Call UpdateBlockField(arrFieldName(intCount), objBCSP.DoubleSingleQuote(arrFieldValue(intCount)), lngMainID, row.Item("FieldCode"), 1, intImportRec)
                            End If
                            'Call UpdateBlockField(arrFieldName(intCount), objBCSP.DoubleSingleQuote(arrFieldValue(intCount)), lngMainID, row.Item("FieldCode"), 1, intImportRec)
                            blnUpdateFulltext = True
                        End If
                    Next row
                End If
            Next

            ' Update FullText table
            Call UpdateRecordContents(lngMainID)

            ' Release tblItem
            If Not tblItem Is Nothing Then
                tblItem.Dispose()
                tblItem = Nothing
            End If

            ' Select all tags or subtags that either use a dictionary or have a function that
            ' is either specific number (such as ISBN, ISSN,...), embedded electronic file

            objDInput.SQLStatement = "SELECT ID, FieldCode, DicID, FunctionID, FieldTypeID, LinkTypeID FROM Lib_tblMARCBibField WHERE (ID IN (SELECT ID FROM Lib_tblMARCBibField WHERE FieldCode IN (" & strTag & ")) OR ParentFieldCode IN ( SELECT FieldCode FROM Lib_tblMARCBibField WHERE FieldCode IN (" & strTag & "))) AND (DicID > 0 OR FunctionID IN (6, 7, 8, 9, 14)) ORDER BY FieldCode"
            dtrRefData = objDInput.GetData

            ' tblItem
            strSQLStatement = ""
            For intCounter = 0 To dtrRefData.Rows.Count - 1
                If IsDBNull(dtrRefData.Rows(intCounter).Item("FunctionID")) Then
                    intFunctionID = 0
                Else
                    intFunctionID = CInt(dtrRefData.Rows(intCounter).Item("FunctionID"))
                End If
                Select Case intFunctionID
                    Case 6
                        ' Update digital data
                        If CInt(dtrRefData.Rows(intCounter).Item("FieldTypeID")) = 4 Then
                            If Not strItemCode = "" Then
                                objDInput.SQLStatement = "UPDATE Cat_tblEdataFile SET ItemID = NULL WHERE FieldCode = '" & dtrRefData.Rows(intCounter).Item("FieldCode") & "' AND ItemID = " & lngMainID
                                Call objDInput.ExecuteQuery()
                            End If
                            Call UpdateDigitalData(dtrRefData.Rows(intCounter).Item("FieldCode"), lngMainID)
                        End If
                    Case 7
                        ' Update Link bib
                        If Not strItemCode = "" Then
                            objDInput.SQLStatement = "DELETE FROM Lib_tblItemLink WHERE FieldCode = '" & dtrRefData.Rows(intCounter).Item("FieldCode") & "' AND ItemID1 = " & lngMainID
                            Call objDInput.ExecuteQuery()
                        End If
                        If CInt(dtrRefData.Rows(intCounter).Item("FieldTypeID")) = 7 Then
                            Call UpdateLinkBib(dtrRefData.Rows(intCounter).Item("FieldCode"), dtrRefData.Rows(intCounter).Item("LinkTypeID"), lngMainID, 0)
                        Else
                            Call UpdateLinkBib(dtrRefData.Rows(intCounter).Item("FieldCode"), dtrRefData.Rows(intCounter).Item("LinkTypeID"), lngMainID, 1)
                        End If
                    Case 9
                        ' Update StandardNumber (ISBN, ISSN)
                        If Not strItemCode = "" Then
                            objDInput.SQLStatement = "DELETE FROM Cat_tblDicNumber WHERE FieldCode = '" & dtrRefData.Rows(intCounter).Item("FieldCode") & "' AND ItemID = " & lngMainID
                            Call objDInput.ExecuteQuery()
                        End If
                        Call UpdateStandardNumber(dtrRefData.Rows(intCounter).Item("FieldCode"), lngMainID)
                    Case 14
                        ' Update publish year
                        If Not strItemCode = "" Then
                            objDInput.SQLStatement = "DELETE FROM Cat_tblDicYear WHERE FieldCode = '" & dtrRefData.Rows(intCounter).Item("FieldCode") & "' AND ItemID = " & lngMainID
                            Call objDInput.ExecuteQuery()
                        End If
                        Call UpdateYear(dtrRefData.Rows(intCounter).Item("FieldCode"), lngMainID)
                    Case Else
                        ' Update reference data
                        If Not IsDBNull(dtrRefData.Rows(intCounter).Item("DicID")) Then
                            dtrData = tblReferences.Select("ID = " & CInt(dtrRefData.Rows(intCounter).Item("DicID")))
                            If Not dtrData.Length = 0 Then
                                For Each row In dtrData
                                    If Not IsDBNull(row.Item("IndexTable")) Then
                                        Call UpdateReference(dtrRefData.Rows(intCounter).Item("FieldCode"), lngMainID, CInt(dtrRefData.Rows(intCounter).Item("DicID")))
                                        Exit For
                                    End If
                                Next row
                            End If
                            dtrData = tblReferences.Select()
                        End If
                End Select
            Next intCounter

            ' Release objects
            If Not dtrRefData Is Nothing Then
                dtrRefData.Dispose()
                dtrRefData = Nothing
            End If

            Update = lngMainID

            ' Commit transaction
            If objDInput.ErrorMsg = "" Then
                Call objDInput.CommitInputTrans()
                Update = 1
            Else
RollBack:
                strErrorMsg = objDInput.ErrorMsg
                Call objDInput.RollBackInputTrans()
                objDInput.ErrorMsg = ""
                objDInput.ErrorCode = 0
                Update = 0
                lngWorkID = 0
            End If
        End Function

        ' Insert a record into a conjuction table that links to a dictionary table.
        ' Before actually updating conjunction table, it will first try to look up the entry
        ' in dictionary table and will update the entry if it is not found.
        ' Depending on the kind of dictionary assiged to the field, the record
        ' will be inserted in adequate table.
        Private Sub UpdateReference(ByVal strTagIn As String, ByVal lngItemID As Long, ByVal intDicID As Integer)
            Dim intTagIndex As Integer
            Dim intCount1 As Integer
            Dim intCount2 As Integer
            Dim intIndexOfColon As Integer

            Dim strValue As String = ""
            Dim strSubTag As String = ""
            Dim lngRefID
            Dim arrSubRecords()
            Dim arrSubVal()
            Dim arrRecords()
            Dim dtrow As DataRow()
            Dim row As DataRow
            Dim col As DataColumn
            Dim strLinkTableName As String = ""
            Dim strMainTableName As String = ""
            Dim strRefFieldName As String = ""
            Dim strIDFieldName As String = ""
            Dim strLinkFieldName As String = ""
            Dim strFieldCode As String
            Dim lngRefIDTemp

            ' strFieldCode = Left(strTagIn, 3)
            strFieldCode = strTagIn

            dtrow = tblReferences.Select("ID = " & intDicID)
            For Each row In dtrow
                If Not IsDBNull(row.Item("IndexTable")) Then
                    strLinkTableName = CStr(row.Item("IndexTable"))
                End If
                If Not IsDBNull(row.Item("Dictable")) Then
                    strMainTableName = CStr(row.Item("Dictable"))
                End If
                If Not IsDBNull(row.Item("DicIDField")) Then
                    strIDFieldName = CStr(row.Item("DicIDField"))
                End If
                If Not IsDBNull(row.Item("CaptionField")) Then
                    strRefFieldName = CStr(row.Item("CaptionField"))
                End If
                If Not IsDBNull(row.Item("IndexIDField")) Then
                    strLinkFieldName = CStr(row.Item("IndexIDField"))
                End If
            Next row

            If Not strItemCode = "" Then
                objDInput.SQLStatement = "DELETE FROM " & strLinkTableName & " WHERE FieldCode = '" & strFieldCode & "' AND ItemID = " & lngItemID
                Call objDInput.ExecuteQuery()
            End If
            If (InStr(strTagIn, "$")) > 0 Then
                strSubTag = Right(strTagIn, 2)
                strTagIn = Left(strTagIn, 3)
            End If
            intTagIndex = FindIndex(arrFieldName, strTagIn)
            If intTagIndex >= 0 Then
                strValue = arrFieldValue(intTagIndex)
            Else
                strValue = ""
            End If
            If strValue = "" Or strValue = "::" Then
                Exit Sub
            End If
            If strMainTableName = "Cat_tblDicThesisSubject" Then
                lngRefIDTemp = Me.PickReference915ID(strValue)
                If IsNumeric(lngRefIDTemp) Then
                    lngRefID = CLng(lngRefIDTemp)
                    objDInput.SQLStatement = "INSERT INTO " & strLinkTableName & " (ItemID, FieldCode, " & strLinkFieldName & ") VALUES (" & lngItemID & ", '" & strFieldCode & "', " & lngRefID & ")"
                    Call objDInput.ExecuteQuery()
                End If
                Exit Sub
            End If
            Call ParseFieldValue(strValue, "$&", arrRecords)
            For intCount1 = LBound(arrRecords) To UBound(arrRecords) - 1
                If Not (arrRecords(intCount1) = "" Or arrRecords(intCount1) = "::") Then
                    If Not strSubTag = "" Then
                        Call ParseField(strSubTag, arrRecords(intCount1), "nc##", arrSubVal)
                        If Not arrSubVal(0) = "" Then
                            Call ParseFieldValue(arrSubVal(0), "nc##", arrSubRecords)
                            For intCount2 = LBound(arrSubRecords) To UBound(arrSubRecords) - 1
                                If Not arrSubRecords(intCount2) = "" Then
                                    lngRefIDTemp = PickReferenceID(arrSubRecords(intCount2), strMainTableName, strIDFieldName, strRefFieldName)
                                    If IsNumeric(lngRefIDTemp) Then
                                        lngRefID = CLng(lngRefIDTemp)
                                        objDInput.SQLStatement = "INSERT INTO " & strLinkTableName & " (ItemID, FieldCode, " & strLinkFieldName & ") VALUES (" & lngItemID & ", '" & strFieldCode & "', " & lngRefID & ")"
                                        Call objDInput.ExecuteQuery()
                                    End If
                                End If
                            Next intCount2
                        End If
                    Else
                        intIndexOfColon = InStr(arrRecords(intCount1), "::")
                        If intIndexOfColon > 0 And intIndexOfColon <= 3 Then
                            arrRecords(intCount1) = Right(arrRecords(intCount1), Len(arrRecords(intCount1)) - intIndexOfColon - 1)
                        End If
                        lngRefID = PickReferenceID(arrRecords(intCount1), strMainTableName, strIDFieldName, strRefFieldName)
                        ' Comment
                        ' LENTA modify : 26-1-2007
                        If IsNumeric(lngRefID) Then
                            objDInput.SQLStatement = "INSERT INTO " & strLinkTableName & " (ItemID, FieldCode, " & strLinkFieldName & ") VALUES (" & lngItemID & ", '" & strFieldCode & "', " & lngRefID & ")"
                            Call objDInput.ExecuteQuery()
                        End If
                    End If
                End If
            Next intCount1
        End Sub

        ' Insert a record into CAT_DIC_NUMBER table for each standard number (ISBN, ISSN,
        ' Deposit number, Publisher bumber,... The standard number is indicated
        ' by the value of FunctionID which is 9) of the catalog record.
        Private Sub UpdateStandardNumber(ByVal strTagIn As String, ByVal lngItemID As Long)
            ' Declare variables
            Dim intTagIndex As Integer
            Dim intCount1 As Integer
            Dim intCount2 As Integer
            Dim intIndexOfColon As Integer
            Dim strValue As String = ""
            Dim strSubTag As String
            Dim arrSubRecords()
            Dim arrSubVal()
            Dim arrRecords()
            Dim strFieldCode As String
            strFieldCode = strTagIn
            ' Execute
            If (InStr(strTagIn, "$")) > 0 Then
                strSubTag = Right(strTagIn, 2)
                strTagIn = Left(strTagIn, 3)
            End If
            intTagIndex = FindIndex(arrFieldName, strTagIn)
            If intTagIndex >= 0 Then
                strValue = arrFieldValue(intTagIndex)
            End If
            If strValue = "" Or strValue = "::" Then
                Exit Sub
            End If
            Call ParseFieldValue(strValue, "$&", arrRecords)
            For intCount1 = LBound(arrRecords) To UBound(arrRecords) - 1
                If Not (arrRecords(intCount1) = "" Or arrRecords(intCount1) = "::") Then
                    If Not strSubTag = "" Then
                        Call ParseField(strSubTag, arrRecords(intCount1), "##", arrSubVal)
                        If Not arrSubVal(0) = "" Then
                            Call ParseFieldValue(arrSubVal(0), "##", arrSubRecords)
                            For intCount2 = LBound(arrSubRecords) To UBound(arrSubRecords) - 1
                                If Not arrSubRecords(intCount2) = "" Then
                                    arrSubRecords(intCount2) = Replace(arrSubRecords(intCount2), "-", "")
                                    If InStr(arrSubRecords(intCount2), "(") > 0 Then
                                        arrSubRecords(intCount2) = Left(arrSubRecords(intCount2), InStr(arrSubRecords(intCount2), "(") - 1)
                                    End If
                                    arrSubRecords(intCount2) = objBCSP.GEntryTrim(Replace(arrSubRecords(intCount2), " ", "").Trim)
                                    arrSubRecords(intCount2) = Replace(arrSubRecords(intCount2), "$a", "")
                                    If strDBServer = "ORACLE" Then
                                        objDInput.SQLStatement = "INSERT INTO Cat_tblDicNumber (ItemID, FieldCode, ""NUMBER"") VALUES (" & lngItemID & ", '" & strFieldCode & "', '" & arrSubRecords(intCount2) & "')"
                                    Else
                                        objDInput.SQLStatement = "INSERT INTO Cat_tblDicNumber (ItemID, FieldCode, Number) VALUES (" & lngItemID & ", '" & strFieldCode & "', '" & arrSubRecords(intCount2) & "')"
                                    End If
                                    Call objDInput.ExecuteQuery()
                                End If
                            Next
                        End If
                    Else
                        intIndexOfColon = InStr(arrRecords(intCount1), "::")
                        If intIndexOfColon > 0 And intIndexOfColon <= 3 Then
                            arrRecords(intCount1) = Right(arrRecords(intCount1), Len(arrRecords(intCount1)) - intIndexOfColon - 1)
                        End If
                        arrRecords(intCount1) = Replace(arrRecords(intCount1), "-", "")
                        If InStr(arrRecords(intCount1), "(") > 0 Then
                            arrRecords(intCount1) = Left(arrRecords(intCount1), InStr(arrRecords(intCount1), "(") - 1)
                        End If
                        arrRecords(intCount1) = objBCSP.GEntryTrim(Replace(arrRecords(intCount1), " ", "").Trim)
                        arrRecords(intCount1) = Replace(arrRecords(intCount1), "$a", "")
                        If strDBServer = "ORACLE" Then
                            objDInput.SQLStatement = "INSERT INTO Cat_tblDicNumber (ItemID, FieldCode, ""NUMBER"") VALUES (" & lngItemID & ", '" & strFieldCode & "', '" & arrRecords(intCount1) & "')"
                        Else
                            objDInput.SQLStatement = "INSERT INTO Cat_tblDicNumber (ItemID, FieldCode, Number) VALUES (" & lngItemID & ", '" & strFieldCode & "', '" & arrRecords(intCount1) & "')"
                        End If
                        Call objDInput.ExecuteQuery()
                    End If
                End If
            Next
        End Sub

        ' UpdateYear method
        ' Insert data into CAT_DIC_YEAR table
        Private Sub UpdateYear(ByVal strTagIn As String, ByVal lngItemID As Long)
            Dim intTagIndex As Integer
            Dim intCount1 As Integer
            Dim intCount2 As Integer
            Dim intIndexOfColon As Integer
            Dim strValue As String = ""
            Dim strSubTag As String
            Dim arrSubRecords()
            Dim arrSubVal()
            Dim arrRecords()
            Dim strFieldCode As String

            strFieldCode = strTagIn
            If (InStr(strTagIn, "$")) > 0 Then
                strSubTag = Right(strTagIn, 2)
                strTagIn = Left(strTagIn, 3)
            End If
            intTagIndex = FindIndex(arrFieldName, strTagIn)
            If intTagIndex >= 0 Then
                strValue = arrFieldValue(intTagIndex)
            End If
            If strValue = "" Or strValue = "::" Then
                Exit Sub
            End If
            Call ParseFieldValue(strValue, "$&", arrRecords)
            For intCount1 = LBound(arrRecords) To UBound(arrRecords) - 1
                If Not (arrRecords(intCount1) = "" Or arrRecords(intCount1) = "::") Then
                    If Not strSubTag = "" Then
                        Call ParseField(strSubTag, arrRecords(intCount1), "##", arrSubVal)
                        If Not arrSubVal(0) = "" Then
                            Call ParseFieldValue(arrSubVal(0), "##", arrSubRecords)
                            For intCount2 = LBound(arrSubRecords) To UBound(arrSubRecords) - 1
                                If Not arrSubRecords(intCount2) = "" Then
                                    arrSubRecords(intCount2) = KeepDigits(arrSubRecords(intCount2))
                                    objDInput.SQLStatement = "INSERT INTO Cat_tblDicYear (ItemID, FieldCode, YEAR) VALUES (" & lngItemID & ", '" & strFieldCode & "', '" & arrSubRecords(intCount2) & "')"
                                    Call objDInput.ExecuteQuery()
                                End If
                            Next
                        End If
                    Else
                        intIndexOfColon = InStr(arrRecords(intCount1), "::")
                        If intIndexOfColon > 0 And intIndexOfColon <= 3 Then
                            arrRecords(intCount1) = Right(arrRecords(intCount1), Len(arrRecords(intCount1)) - intIndexOfColon - 1)
                        End If
                        arrRecords(intCount1) = KeepDigits(arrRecords(intCount1))
                        objDInput.SQLStatement = "INSERT INTO Cat_tblDicYear (ItemID, FieldCode, YEAR) VALUES (" & lngItemID & ", '" & strFieldCode & "', '" & arrRecords(intCount1) & "')"
                        Call objDInput.ExecuteQuery()
                    End If
                End If
            Next
        End Sub

        ' KeepDigits function
        ' Input: strWithDigits
        ' Output: string value of strWithDigits after eliminate characters which it not a number
        Private Function KeepDigits(ByVal strWithDigits As String)
            Dim strWithDigitsOnly As String
            Dim strTemp As String
            Dim intIndex As Integer
            strWithDigitsOnly = ""
            For intIndex = 1 To Len(strWithDigits)
                strTemp = Mid(strWithDigits, intIndex, 1)
                If strTemp >= "0" And strTemp <= "9" Then
                    strWithDigitsOnly = strWithDigitsOnly & strTemp
                End If
            Next
            KeepDigits = strWithDigitsOnly
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
                        arrRecs(intIndex) = Left(arrRecs(intIndex), InStr(arrRecs(intIndex), "::") + 1) & objBCSP.ConvertItBack(Right(arrRecs(intIndex), Len(arrRecs(intIndex)) - InStr(arrRecs(intIndex), "::") - 1))
                    End If
                Else
                    If intNc = 1 Then
                        arrRecs(intIndex) = arrRecs(intIndex)
                    Else
                        arrRecs(intIndex) = objBCSP.ConvertItBack(arrRecs(intIndex))
                    End If
                End If
                intIndex = intIndex + 1
                ReDim Preserve arrRecs(intIndex)
            Loop
        End Sub

        ' This subroutine will take full responsibility for the update process. It will stop if an error occurs. 
        ' In that case, the subroutine will return an error message and rollback the current update transaction.
        Private Sub UpdateLinkBib(ByVal strTagIn As String, ByVal intLinkID As Object, ByVal lngItemID As Long, ByVal intIsSerial As Integer)
            Dim intTagIndex As Integer
            Dim intCount1 As Integer
            Dim intIndexOfColon As Integer
            Dim strSubTag, strValue As String
            Dim arrSubVal()
            Dim arrRecords()
            Dim strFieldCode As String
            strFieldCode = strTagIn
            If IsDBNull(intLinkID) Then
                intLinkID = 0
                Exit Sub
            End If
            If (InStr(strTagIn, "$")) > 0 Then
                strSubTag = Right(strTagIn, 2)
                strTagIn = Left(strTagIn, 3)
            End If
            intTagIndex = FindIndex(arrFieldName, strTagIn)
            If intTagIndex >= 0 Then
                strValue = arrFieldValue(intTagIndex)
            Else
                strValue = ""
            End If
            If strValue = "" Or strValue = "::" Then
                Exit Sub
            End If
            Call ParseFieldValue(strValue, "$&", arrRecords)
            For intCount1 = LBound(arrRecords) To UBound(arrRecords) - 1
                If Not (arrRecords(intCount1) = "" Or arrRecords(intCount1) = "::") Then
                    If InStr(arrRecords(intCount1), "$w") > 0 Then
                        Call ParseField("$w", arrRecords(intCount1), "", arrSubVal)
                    Else
                        Call ParseField("$6", arrRecords(intCount1), "", arrSubVal)
                    End If
                    If InStr(arrSubVal(0), ")") > 0 Then
                        arrSubVal(0) = Right(arrSubVal(0), Len(arrSubVal(0)) - InStr(arrSubVal(0), ")"))
                    End If
                    arrSubVal(0) = Replace(arrSubVal(0) & "", " ", "")
                    If IsNumeric(arrSubVal(0)) And Not arrSubVal(0) = "" Then

                        objDInput.SQLStatement = "INSERT INTO Lib_tblItemLink (LinkTypeID, ItemID1, ItemID2, FieldCode, IsSerial) VALUES (" & intLinkID & "," & lngItemID & "," & arrSubVal(0) & ",'" & strFieldCode & "'," & intIsSerial & ")"
                        Call objDInput.ExecuteQuery()
                    End If
                End If
            Next
        End Sub

        ' UpdateDigitalData method
        Private Sub UpdateDigitalData(ByVal strTagIn As String, ByVal lngItemID As Long)
            Dim intTagIndex As Integer
            Dim intCount1 As Integer
            Dim intCount2 As Integer
            Dim intIndexOfColon As Integer
            Dim strValue As String
            Dim strSubTag As String
            Dim arrSubRecords()
            Dim arrSubVal()
            Dim arrRecords()
            Dim strFieldCode As String
            strFieldCode = strTagIn
            If (InStr(strTagIn, "$")) > 0 Then
                strSubTag = Right(strTagIn, 2)
                strTagIn = Left(strTagIn, 3)
            End If
            intTagIndex = FindIndex(arrFieldName, strTagIn)
            If intTagIndex >= 0 Then
                strValue = arrFieldValue(intTagIndex)
            Else
                strValue = ""
            End If
            If strValue = "" Or strValue = "::" Then
                Exit Sub
            End If
            Call ParseFieldValue(strValue, "$&", arrRecords)
            For intCount1 = LBound(arrRecords) To UBound(arrRecords) - 1
                If Not (arrRecords(intCount1) = "" Or arrRecords(intCount1) = "::") Then
                    If Not strSubTag = "" Then
                        Call ParseField(strSubTag, arrRecords(intCount1), "##", arrSubVal)
                        If Not arrSubVal(0) = "" Then
                            Call ParseFieldValue(arrSubVal(0), "##", arrSubRecords)
                            For intCount2 = LBound(arrSubRecords) To UBound(arrSubRecords) - 1
                                If Not arrSubRecords(intCount2) = "" Then
                                    objDInput.SQLStatement = "UPDATE Cat_tblEdataFile SET ItemID = " & lngItemID & " WHERE FieldCode='" & strFieldCode & "' AND ItemID IS NULL AND URL = '" & arrSubRecords(intCount2) & "'"
                                    Call objDInput.ExecuteQuery()
                                End If
                            Next
                        End If
                    Else
                        intIndexOfColon = InStr(arrRecords(intCount1), "::")
                        If intIndexOfColon > 0 And intIndexOfColon <= 3 Then
                            arrRecords(intCount1) = Right(arrRecords(intCount1), Len(arrRecords(intCount1)) - intIndexOfColon - 1)
                        End If
                        objDInput.SQLStatement = "UPDATE Cat_tblEdataFile SET ItemID = " & lngItemID & " WHERE FieldCode= '" & strFieldCode & "' AND ItemID IS NULL AND URL = '" & arrRecords(intCount1) & "'"
                        Call objDInput.ExecuteQuery()
                    End If
                End If
            Next
        End Sub

        ' UpdateRecordContents method
        ' Get all information of the selected record to add new row to FullText table
        Private Sub UpdateRecordContents(ByVal lngItemID As Long)
            Dim strSQLStatement As String
            Dim strTemp As String, strTemp1 As String
            Dim tblContent As New DataTable
            Dim intCounter As Integer

            ' Get content of this record 
            strSQLStatement = "SELECT UPPER(Content) As Content FROM Lib_tblField000S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField100S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField200S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField300S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField400S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField500S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField600S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField700S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField800S WHERE ItemID = " & lngItemID
            strSQLStatement = strSQLStatement & " UNION ALL SELECT UPPER(Content) As Content FROM Lib_tblField900S WHERE ItemID = " & lngItemID
            objDInput.SQLStatement = strSQLStatement
            tblContent = objDInput.GetData()

            Dim strTmp As String = ""
            strTemp = ""
            For intCounter = 0 To tblContent.Rows.Count - 1
                strTmp = strTmp & tblContent.Rows(intCounter).Item("Content") & "<BR>"
                strTemp = strTemp & objBCSP.ProcessVal(objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(Trim(CStr(tblContent.Rows(intCounter).Item("Content"))), False))) & Chr(9)
            Next
            strTemp = objBCSP.DoubleSingleQuote(strTemp)

            'Alter by chuyenpt(21/08/07): Content = Content co dau(neu co) & Tab & Content bo dau
            strTemp1 = objBCSP.CutVietnameseAccent(strTemp)
            If strTemp1.Trim <> strTemp.Trim Then
                strTemp = strTemp & Chr(9) & strTemp1
            End If
            '---

            ' Release tblContent
            tblContent.Dispose()
            tblContent = Nothing

            ' Check exist Item in Fulltext table to update or insert
            objDInput.SQLStatement = "SELECT ItemID FROM Lib_tblItemFulltext WHERE ItemID = " & lngItemID
            tblContent = objDInput.GetData()

            If Not tblContent.Rows.Count = 0 Then ' UPDATE Lib_tblItemFulltext table
                If Not DBServer = "ORACLE" Then
                    strSQLStatement = "UPDATE Lib_tblItemFulltext SET Contents = N'" & strTemp & "' WHERE ItemID = " & lngItemID
                Else
                    strSQLStatement = "UPDATE Lib_tblItemFulltext SET Contents = '" & strTemp & "' WHERE ItemID = " & lngItemID
                End If
                ' Release tblContent
                tblContent.Dispose()
                tblContent = Nothing
            Else ' Add new row to FullText table
                If Not DBServer = "ORACLE" Then
                    strSQLStatement = "INSERT INTO Lib_tblItemFulltext (ItemID, Contents) VALUES (" & lngItemID & ", N'" & strTemp & "')"
                Else
                    strSQLStatement = "INSERT INTO Lib_tblItemFulltext (ID,ItemID, Contents) VALUES (SQ_ITEM_FULLTEXT.NEXTVAL," & lngItemID & ", '" & strTemp & "')"
                End If
            End If
            objDInput.SQLStatement = strSQLStatement
            Call objDInput.ExecuteQuery()
        End Sub

        ' FindIndex function
        ' Input: array of FieldNames, string value of FieldName
        ' Output: integer value of index of the FieldName in this array
        Public Function FindIndex(ByVal arrFieldNames() As Object, ByVal strFieldName As String) As Integer
            Dim intTempIndex As Integer
            Dim intReturnValue As Integer = -1
            For intTempIndex = LBound(arrFieldNames) To UBound(arrFieldNames)
                If UCase(strFieldName) = UCase(arrFieldNames(intTempIndex)) Then
                    intReturnValue = intTempIndex
                    Exit For
                End If
            Next
            FindIndex = intReturnValue
        End Function

        ' This function takes a value of a tag/subtag that is assigned to a dictionary, looks
        ' up for its IDin the dictionary table. If the value is not existing in the dictionary table,
        ' then the function appends a record for this new value and gets its ID.
        ' The function returns with the value's ID.
        Private Function PickReference915ID(ByVal strValue As String) As String
            ' Declare variables 
            Dim intNextID As Long
            Dim strAccess915 As String
            Dim strSQLStatement As String
            Dim tblTemp As New DataTable

            ' Upper synch accent
            PickReference915ID = ""
            Dim intPost As Integer
            strValue = strValue.Replace("::", "").Trim
            Dim arr915() As Object
            objBCSP.ParseField("$a,$b", strValue, "", arr915)
            If arr915.Length < 1 Then
                Exit Function
            End If
            If arr915(0) = "" Then
                Exit Function
            End If
            strAccess915 = objBCSP.ProcessVal(arr915(0))
            strAccess915 = objBCSP.DoubleSingleQuote(strAccess915)
            arr915(0) = Trim(objBCSP.GEntryTrim(arr915(0)))
            arr915(0) = objBCSP.DoubleSingleQuote(arr915(0))
            If Trim(strAccess915) = "" Then
                Exit Function
            End If
            ' Check exist item
            strSQLStatement = "SELECT ID FROM Cat_tblDicThesisSubject WHERE AccessEntry = N'" & strAccess915 & "' and NAME=N'" & arr915(1) & "'"

            objDInput.SQLStatement = strSQLStatement
            tblTemp = objDInput.GetData()
            ' Get PickReferenceID in string format
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    PickReference915ID = CStr(tblTemp.Rows(0).Item("ID"))
                End If
            End If

            If PickReference915ID = "" Then
                intNextID = CreateID("Cat_tblDicThesisSubject", "ID")
                strSQLStatement = "INSERT INTO Cat_tblDicThesisSubject (ID, DisplayEntry , AccessEntry,Name) VALUES (" & intNextID & ", N'" & arr915(0) & "', N'" & strAccess915 & "', N'" & arr915(1) & "')"
                objDInput.SQLStatement = strSQLStatement
                Call objDInput.ExecuteQuery() ' Insert data into strTabName table
                PickReference915ID = intNextID
            End If

            ' Release tblTemp
            tblTemp.Dispose()
            tblTemp = Nothing
        End Function

        ' This function takes a value of a tag/subtag that is assigned to a dictionary, looks
        ' up for its IDin the dictionary table. If the value is not existing in the dictionary table,
        ' then the function appends a record for this new value and gets its ID.
        ' The function returns with the value's ID.
        Private Function PickReferenceID(ByVal strValue As String, ByVal strTabName As String, ByVal strTabID As String, ByVal strTabVal As String) As String
            ' Declare variables 
            Dim intNextID As Long
            Dim strTempValue As String
            Dim strSQLStatement As String = ""
            Dim tblTemp As New DataTable

            ' Upper synch accent
            PickReferenceID = ""
            Dim intPost As Integer
            strValue = strValue.Replace("::", "").Replace("$a", "").Replace("$A", "")
            intPost = InStr(strValue, "$")
            If intPost > 0 Then
                strValue = Left(strValue, intPost - 1)
            End If
            strTempValue = objBCSP.ProcessVal(strValue)
            strTempValue = objBCSP.DoubleSingleQuote(strTempValue)
            strValue = Trim(objBCSP.GEntryTrim(strValue))
            strValue = objBCSP.DoubleSingleQuote(strValue)
            If Trim(strTempValue) = "" Or Trim(strValue) = "" Then
                Exit Function
            End If

            If Trim(strValue) <> "" Then
                ' Check exist item
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        strSQLStatement = "SELECT " & strTabID & " as ID FROM " & strTabName & " WHERE AccessEntry = N'" & strTempValue & "'"
                    Case "ORACLE"
                        strSQLStatement = "SELECT " & strTabID & " as ID FROM " & strTabName & " WHERE AccessEntry = '" & strTempValue & "'"
                End Select

                objDInput.SQLStatement = strSQLStatement
                tblTemp = objDInput.GetData()

                ' Get PickReferenceID in string format
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        PickReferenceID = CStr(tblTemp.Rows(0).Item("ID"))
                    End If
                End If

                If PickReferenceID = "" Then
                    intNextID = CreateID(strTabName, strTabID)
                    Select Case UCase(strDBServer)
                        Case "SQLSERVER"
                            'strSQLStatement = "INSERT INTO " & strTabName & " (" & strTabID & ", " & strTabVal & ", AccessEntry) VALUES (" & intNextID & ", N'" & strValue & "', N'" & strTempValue & "')"
                            strSQLStatement = "INSERT INTO " & strTabName & " (" & strTabID & ", " & strTabVal & ", AccessEntry, VietnameseAccent) VALUES (" & intNextID & ", N'" & strValue & "', N'" & strTempValue & "','" & objBCSP.CutVietnameseAccent(strTempValue) & "')"
                        Case "ORACLE"
                            'strSQLStatement = "INSERT INTO " & strTabName & " (" & strTabID & ", " & strTabVal & ", AccessEntry) VALUES (" & intNextID & ", '" & strValue & "', '" & strTempValue & "')"
                            strSQLStatement = "INSERT INTO " & strTabName & " (" & strTabID & ", " & strTabVal & ", AccessEntry, VietnameseAccent) VALUES (" & intNextID & ", '" & strValue & "', '" & strTempValue & "','" & objBCSP.CutVietnameseAccent(strTempValue.ToUpper) & "')"
                    End Select

                    objDInput.SQLStatement = strSQLStatement
                    Call objDInput.ExecuteQuery() ' Insert data into strTabName table
                    PickReferenceID = intNextID
                    If objDInput.ErrorMsg <> "" Then
                        PickReferenceID = "NULL"
                        objDInput.ErrorMsg = ""
                    End If

                End If
            End If


            ' Release tblTemp
            tblTemp.Dispose()
            tblTemp = Nothing
        End Function

        ' Generate book code
        ' Input: intIsAuthority checking authority record
        ' Output: string value of bookcode
        Public Function Gen001(ByVal intIsAuthority As Int16) As String
            Dim lngMaxID As Long
            Dim strAbbr As String ' string of library abbreviation
            Dim strYear As String ' string of the current year (2 last digits)
            Dim strCode As String ' string of bookcode
            Dim strTemp As String
            Dim intCount As Integer
            Dim objPara() As String = {"LIBRARY_ABBREVIATION"}
            Dim objSysPara() As String
            Dim tblReserve As New DataTable

            ' Begin transaction
            Call objDInput.BeginInputTrans()
            ' Get LibAbbr from SYS_PARAMETERS table to forming bookcode
            objSysPara = objBCDBS.GetSystemParameters(objPara)
            strAbbr = objSysPara(0)
            ' Get current year to forming bookcode
            strYear = Right(CStr(Year(Now)), 2)

            ' add by Lent
            ' date: 15-12-2006
            If UCase(strDBServer) = "ORACLE" Then
                objDInput.SQLStatement = "select sq_codeitem.NEXTVAL from dual"
                tblReserve = objDInput.GetData()
                Gen001 = Trim(strAbbr & strYear & CStr(tblReserve.Rows(0).Item(0)).PadLeft(7, "0"))
                ' Release tblReserve
                If Not tblReserve Is Nothing Then
                    tblReserve.Dispose()
                    tblReserve = Nothing
                End If
                Exit Function
            Else
                objDInput.SQLStatement = "insert into Cat_tblBookCode values(1)"
                Call objDInput.ExecuteQuery()
                objDInput.SQLStatement = "SELECT max(id) FROM Cat_tblBookCode"
                tblReserve = objDInput.GetData()
            End If
            Gen001 = Trim(strAbbr & strYear & CStr(tblReserve.Rows(0).Item(0)).PadLeft(7, "0"))
            ' commit
            ' Date : 12-12-2006
            'add by Lent, Tuannv
            Call objDInput.CommitInputTrans()
            ' Begin transaction
            Call objDInput.BeginInputTrans()
            ' Commit transaction
            ' Release tblReserve
            If Not tblReserve Is Nothing Then
                tblReserve.Dispose()
                tblReserve = Nothing
            End If

        End Function

        ' UpdateBlockField method
        ' Insert a record into an appropriate table (Lib_tblField000S to Field900s), depending on the tag number
        Private Sub UpdateBlockField(ByVal strTagIn As String, ByVal strValue As String, ByVal lngItemID As Long, ByVal strFieldCode As String, ByVal intTypeID As Integer, ByVal intImportRec As Integer)
            Dim intCounter As Integer
            Dim intIndexOfColon As Integer
            Dim strTagVal As String
            Dim strBlock As String ' to detect suitable field table
            Dim strInd1 As String
            Dim strInd2 As String
            Dim strIndicators As String
            Dim arrSubRecords() As Object = Nothing

            Dim strSQLStatement As String

            'Contains subfield and it's value
            Dim arrRecords() As Object = Nothing

            strBlock = Left(strTagIn, 1)

            ' field 008 can not trim
            If strFieldCode = "008" Then
                ReDim arrRecords(0)
                arrRecords(0) = strValue
            Else
                Call ParseFieldValue(strValue, "$&", arrRecords)
            End If

            If Not strItemCode = "" Then
                If intTypeID = 1 Then
                    strSQLStatement = "DELETE FROM Lib_tblField" & strBlock & "00s WHERE FieldCode = '" & strFieldCode & "' AND ItemID = " & lngItemID
                Else
                    strSQLStatement = "DELETE FROM Lib_tblFiledAutority WHERE FieldCode = '" & strFieldCode & "' AND AuthorityID = " & lngItemID
                End If
                objDInput.SQLStatement = strSQLStatement
                Call objDInput.ExecuteQuery()
            End If

            For intCounter = 0 To UBound(arrRecords)
                If Not arrRecords(intCounter) = "" Or arrRecords(intCounter) = "::" Then
                    strTagVal = arrRecords(intCounter)
                    strInd1 = ""
                    strInd2 = ""
                    intIndexOfColon = InStr(strTagVal, "::")
                    If intIndexOfColon > 0 And intIndexOfColon <= 3 Then
                        strIndicators = Left(strTagVal, intIndexOfColon - 1)
                        strTagVal = Right(strTagVal, Len(strTagVal) - intIndexOfColon - 1)
                        If Len(strIndicators) > 1 Then
                            strInd1 = Left(strIndicators, 1)
                            strInd2 = Right(strIndicators, 1)
                        Else
                            strInd2 = " "
                            strInd2 = strIndicators
                        End If
                    End If
                    If Not intImportRec = 0 And intTypeID = 2 Then
                        Call ParseField("$0", strTagVal, "", arrSubRecords)
                        strTagVal = arrSubRecords(1)
                    End If
                    If strFieldCode <> "008" Then
                        strTagVal = Trim(strTagVal)
                    End If

                    If intTypeID = 1 And Not strTagVal = "" Then
                        ' Check IsTitle information for insert
                        If Not DBServer = "ORACLE" Then
                            strSQLStatement = "INSERT INTO Lib_tblField" & strBlock & "00s (ItemID, FieldCode, Content, Ind1, Ind2) VALUES (" & lngItemID & ", '" & strFieldCode & "', N'" & strTagVal.Replace("''", "'") & "', '" & strInd1 & "', '" & strInd2 & "')"
                        Else
                            strSQLStatement = "INSERT INTO Lib_tblField" & strBlock & "00s (ID, ItemID, FieldCode, Content, Ind1, Ind2) VALUES (SQ_Field" & strBlock & "00s.NextVal, " & lngItemID & ", '" & strFieldCode & "', '" & strTagVal.Replace("''", "'") & "', '" & strInd1 & "', '" & strInd2 & "')"
                        End If
                        If (strTagIn >= "200" And strTagIn < "250") Or strTagIn = "130" Then
                            If Not strItemCode = "" Then
                                objDInput.SQLStatement = "DELETE FROM Lib_tblItemTitle WHERE FieldCode = '" & strFieldCode & "' AND ItemID = " & lngItemID
                                Call objDInput.ExecuteQuery()
                            End If
                            ' Update Lib_tblItemTitle table
                            Call UpdateItemTitle(strTagVal, lngItemID, strFieldCode)
                        End If
                    Else
                        If Not DBServer = "ORACLE" Then
                            strSQLStatement = "INSERT INTO Lib_tblFiledAutority (AuthorityID, FieldCode, Content, Ind1, Ind2) VALUES (" & lngItemID & ", '" & strFieldCode & "', N'" & strTagVal & "', '" & strInd1 & "', '" & strInd2 & "')"
                        Else
                            strSQLStatement = "INSERT INTO Lib_tblFiledAutority (ID, AuthorityID, FieldCode, Content, Ind1, Ind2) VALUES (SQ_Field_Authority.NextVal, " & lngItemID & ", '" & strFieldCode & "', '" & strTagVal & "', '" & strInd1 & "', '" & strInd2 & "')"
                        End If
                    End If
                    If Not strTagVal = "" Then
                        objDInput.SQLStatement = strSQLStatement
                        Call objDInput.ExecuteQuery()
                    End If
                End If
            Next intCounter
        End Sub

        ' Update Lib_tblItemTitle table
        Sub UpdateItemTitle(ByVal strValue As String, ByVal lngItemID As Long, ByVal strFieldCode As String)
            Dim intCounter As Integer
            Dim strTemp As String
            Dim strSQLStatement As String
            Dim arrRecords() As Object = Nothing
            Dim strTemp1 As String

            Call ParseField("$a,$b,$p", strValue, "nc ", arrRecords)
            For intCounter = LBound(arrRecords) To UBound(arrRecords) - 1
                If Trim(arrRecords(intCounter)) <> "" Then
                    strTemp = objBCSP.TheDisplayOne(Trim(arrRecords(intCounter)))
                    strTemp = objBCSP.UCS2Title(objBCSP.ProcessVal(strTemp))

                    'Alter by chuyenpt(21/08/07): Title = Title co dau(neu co) & Tab & Title bo dau
                    strTemp1 = objBCSP.CutVietnameseAccent(strTemp)
                    If strTemp1.Trim <> strTemp.Trim Then
                        strTemp = strTemp & Chr(9) & strTemp1
                    End If
                    '---

                    If Not DBServer = "ORACLE" Then
                        strSQLStatement = "INSERT INTO Lib_tblItemTitle(ItemID, FieldCode, Title) VALUES(" & lngItemID & ",'" & strFieldCode & "', N'" & strTemp & "')"
                    Else
                        strSQLStatement = "INSERT INTO Lib_tblItemTitle(ItemID, FieldCode, Title) VALUES(" & lngItemID & ",'" & strFieldCode & "', '" & strTemp & "')"
                    End If
                    objDInput.SQLStatement = strSQLStatement
                    Call objDInput.ExecuteQuery()
                End If
            Next
        End Sub

        ' ParseField method
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
                            recs(k) = recs(k) & objBCSP.GEntryTrim(objBCSP.ConvertItBack(Left(SubPart, q - 1))) & deliminator
                        Else
                            If Nc = 1 Then
                                recs(k) = recs(k) & Left(SubPart, q - 1) & deliminator
                            Else
                                recs(k) = recs(k) & objBCSP.ConvertItBack(Left(SubPart, q - 1)) & deliminator
                            End If
                        End If
                        TheRest = TheRest & Right(SubPart, Len(SubPart) - q + 1)
                    Else
                        If Tr = 1 Then
                            recs(k) = recs(k) & objBCSP.GEntryTrim(objBCSP.ConvertItBack(SubPart)) & deliminator
                        Else
                            If Nc = 1 Then
                                recs(k) = recs(k) & SubPart & deliminator
                            Else
                                recs(k) = recs(k) & objBCSP.ConvertItBack(SubPart) & deliminator
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
                recs(k) = objBCSP.ConvertItBack(strValue)
            End If
        End Sub

        ' CreateID method
        Public Function CreateID(ByVal strTableName As String, ByVal strFieldName As String) As Long
            Dim tblID As New DataTable
            tblID = objDInput.CreateID(strTableName, strFieldName)
            CreateID = CLng(tblID.Rows(0).Item(0))
            tblID.Dispose()
            tblID = Nothing
        End Function

        ' GenerateCompositeHoldings function
        ' Input: 
        '   - lngItemID
        '   - blnIncLib, blnIncInv, blnIncShelf
        '   - intLibId, intInvId (0 as default)
        '   - strDevider
        ' Output: string value
        Public Function GenerateCompositeHoldings(ByVal lngItemID As Long, ByVal blnIncLib As Boolean, ByVal blnIncInv As Boolean, ByVal blnIncShelf As Boolean, ByVal intLibId As Integer, ByVal intInvID As Integer, ByVal strDevider As String, Optional ByVal blnReplaceSpace As Boolean = False) As String
            ' Declare variables
            Dim strCode As String ' code of library
            Dim strLoc As String ' location
            Dim strShelf As String ' shelf
            Dim strTmpShelf As String ' temp shelf
            Dim strCopyNumber As String
            Dim strCompositeHoldings As String
            Dim strCommonCode As String
            Dim strStartRange As String
            Dim strSelectStatement As String
            Dim strStartNumb As String
            Dim strEndNumb As String
            Dim strCurNumb As String
            Dim blnNextRange As Boolean
            Dim intCounter1 As Integer
            Dim intCounter2 As Integer
            Dim intCounter0 As Integer
            Dim intNOC As Integer ' number of CopyNumber
            Dim tblHolding As DataTable ' datatable of CopyNumberd
            Dim strSpaceLoc As String = Chr(9)

            ' Begin transaction
            objDInput.BeginInputTrans()

            Try
                blnNextRange = True
                If Not DBServer = "ORACLE" Then
                    strSelectStatement = "SELECT A.LibID, A.LocationID, Shelf, CopyNumber, Code, Symbol FROM Lib_tblHolding A JOIN Lib_tblHoldingLibrary B ON A.LibID = B.ID LEFT JOIN Lib_tblHoldingLocation C ON A.LocationID = C.ID WHERE ItemID = " & lngItemID
                Else
                    strSelectStatement = "SELECT A.LibID, A.LocationID, Shelf, CopyNumber, Code, Symbol FROM Lib_tblHolding A, Lib_tblHoldingLibrary B, Lib_tblHoldingLocation C WHERE A.LocationID = C.ID(+) AND A.LibID = B.ID AND ItemID = " & lngItemID
                End If
                If Not intLibId = 0 Then
                    strSelectStatement = strSelectStatement & " AND A.LibID = " & intLibId
                End If
                If Not intInvID = 0 Then
                    strSelectStatement = strSelectStatement & " AND A.LocationID = " & intInvID
                End If
                strSelectStatement = strSelectStatement & " ORDER BY A.LibID, A.LocationID, Shelf, CopyNumber"

                ' Read data from datatable
                objDInput.SQLStatement = strSelectStatement
                tblHolding = objDInput.GetData()
                intNOC = tblHolding.Rows.Count

                strCode = ""
                strLoc = ""
                strShelf = ""
                strCopyNumber = ""
                strCompositeHoldings = ""
                strCommonCode = ""
                strStartNumb = ""
                strEndNumb = ""
                strStartRange = ""

                ' Process
                If Not intNOC = 0 Then
                    For intCounter0 = 0 To intNOC - 1
                        If Not IsDBNull(tblHolding.Rows(intCounter0).Item("Shelf")) Then
                            strTmpShelf = tblHolding.Rows(intCounter0).Item("Shelf")
                        End If
                        If Not strCode = tblHolding.Rows(intCounter0).Item("Code") Or Not strLoc = tblHolding.Rows(intCounter0).Item("Symbol") Or Not strShelf = strTmpShelf Then
                            strCode = tblHolding.Rows(intCounter0).Item("Code")
                            strLoc = tblHolding.Rows(intCounter0).Item("Symbol")
                            strShelf = strTmpShelf
                            If Not strEndNumb = strStartNumb Then
                                intCounter2 = 0
                                Do While intCounter2 < Len(strStartRange) - 2 And intCounter2 < Len(strStartNumb) - 2
                                    If Mid(strStartNumb, intCounter2 + 1, 1) = Mid(strStartRange, intCounter2 + 1, 1) Then
                                        intCounter2 = intCounter2 + 1
                                    Else
                                        Exit Do
                                    End If
                                Loop
                                intCounter1 = 0
                                Do While intCounter1 < Len(strEndNumb) - intCounter2 And intCounter1 < Len(strStartNumb) - intCounter2
                                    If Mid(strStartNumb, intCounter1 + 1, 1) = Mid(strEndNumb, intCounter1 + 1, 1) Then
                                        intCounter1 = intCounter1 + 1
                                    Else
                                        Exit Do
                                    End If
                                Loop
                                If blnNextRange Then
                                    strCompositeHoldings = strCompositeHoldings & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                Else
                                    strCompositeHoldings = Left(strCompositeHoldings, InStrRev(strCompositeHoldings, ",") - 1) & ", " & Right(strStartNumb, Len(strStartNumb) - intCounter1) & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                End If
                            End If
                            strCompositeHoldings = strCompositeHoldings & strSpaceLoc
                            If blnIncLib Then
                                strCompositeHoldings = strCompositeHoldings & tblHolding.Rows(intCounter0).Item("Code") & strDevider
                            End If
                            If blnIncInv Then
                                If blnReplaceSpace Then
                                    strCompositeHoldings = strCompositeHoldings & Replace(tblHolding.Rows(intCounter0).Item("Symbol"), " ", "#") & strDevider
                                Else
                                    strCompositeHoldings = strCompositeHoldings & tblHolding.Rows(intCounter0).Item("Symbol") & strDevider
                                End If
                            End If
                            If blnIncShelf Then
                                strCompositeHoldings = strCompositeHoldings & tblHolding.Rows(intCounter0).Item("Shelf") & strDevider
                            End If
                            strCompositeHoldings = strCompositeHoldings & tblHolding.Rows(intCounter0).Item("CopyNumber")
                            blnNextRange = True
                            strCopyNumber = tblHolding.Rows(intCounter0).Item("CopyNumber")
                            strStartNumb = ""
                            strCommonCode = strCopyNumber
                            While IsNumeric(Right(strCommonCode, 1)) And Len(strCommonCode) > 0
                                strStartNumb = Right(strCommonCode, 1) & strStartNumb
                                strCommonCode = Left(strCommonCode, Len(strCommonCode) - 1)
                            End While
                            strStartRange = strStartNumb
                            strEndNumb = strStartNumb
                        End If
                        If Not strCopyNumber = tblHolding.Rows(intCounter0).Item("CopyNumber") Then
                            strCopyNumber = tblHolding.Rows(intCounter0).Item("CopyNumber")
                            If Not InStr(tblHolding.Rows(intCounter0).Item("CopyNumber"), strCommonCode) = 1 Then
                                If Not strEndNumb = strStartNumb Then
                                    intCounter2 = 0
                                    Do While intCounter2 < Len(strStartRange) - 2 And intCounter2 < Len(strStartNumb) - 2
                                        If Mid(strStartNumb, intCounter2 + 1, 1) = Mid(strStartRange, intCounter2 + 1, 1) Then
                                            intCounter2 = intCounter2 + 1
                                        Else
                                            Exit Do
                                        End If
                                    Loop
                                    intCounter2 = Len(strStartNumb) - intCounter2
                                    intCounter1 = 0
                                    Do While intCounter1 < Len(strEndNumb) - intCounter2 And intCounter1 < Len(strStartNumb) - intCounter2
                                        If Mid(strStartNumb, intCounter1 + 1, 1) = Mid(strEndNumb, intCounter1 + 1, 1) Then
                                            intCounter1 = intCounter1 + 1
                                        Else
                                            Exit Do
                                        End If
                                    Loop
                                    If blnNextRange Then
                                        strCompositeHoldings = strCompositeHoldings & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                    Else
                                        strCompositeHoldings = Left(strCompositeHoldings, InStrRev(strCompositeHoldings, ",") - 1) & ", " & Right(strStartNumb, Len(strStartNumb) - intCounter1) & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                    End If
                                End If
                                strCompositeHoldings = strCompositeHoldings & ", " & tblHolding.Rows(intCounter0).Item("CopyNumber")
                                blnNextRange = True
                                strStartNumb = ""
                                strCommonCode = strCopyNumber
                                While IsNumeric(Right(strCommonCode, 1)) And Len(strCommonCode) > 0
                                    strStartNumb = Right(strCommonCode, 1) & strStartNumb
                                    strCommonCode = Left(strCommonCode, Len(strCommonCode) - 1)
                                End While
                                strStartRange = strStartNumb
                                strEndNumb = strStartNumb
                            Else
                                strCurNumb = Right(strCopyNumber, Len(strCopyNumber) - Len(strCommonCode))
                                If IsNumeric(strCurNumb) Then
                                    If CLng(strCurNumb) = CLng(strEndNumb) + 1 Then
                                        strEndNumb = strCurNumb
                                    Else
                                        If Not strEndNumb = strStartNumb Then
                                            intCounter2 = 0
                                            Do While intCounter2 < Len(strStartRange) - 2 And intCounter2 < Len(strStartNumb) - 2
                                                If Mid(strStartNumb, intCounter2 + 1, 1) = Mid(strStartRange, intCounter2 + 1, 1) Then
                                                    intCounter2 = intCounter2 + 1
                                                Else
                                                    Exit Do
                                                End If
                                            Loop
                                            intCounter2 = Len(strStartNumb) - intCounter2
                                            intCounter1 = 0
                                            Do While intCounter1 < Len(strEndNumb) - intCounter2 And intCounter1 < Len(strStartNumb) - intCounter2
                                                If Mid(strStartNumb, intCounter1 + 1, 1) = Mid(strEndNumb, intCounter1 + 1, 1) Then
                                                    intCounter1 = intCounter1 + 1
                                                Else
                                                    Exit Do
                                                End If
                                            Loop
                                            If blnNextRange Then
                                                strCompositeHoldings = strCompositeHoldings & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                            Else
                                                strCompositeHoldings = Left(strCompositeHoldings, InStrRev(strCompositeHoldings, ",") - 1) & ", " & Right(strStartNumb, Len(strStartNumb) - intCounter1) & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                            End If
                                        End If
                                        intCounter1 = 0
                                        Do While intCounter1 < Len(strEndNumb) - 2 And intCounter1 < Len(strCurNumb) - 2
                                            If Mid(strCurNumb, intCounter1 + 1, 1) = Mid(strEndNumb, intCounter1 + 1, 1) Then
                                                intCounter1 = intCounter1 + 1
                                            Else
                                                Exit Do
                                            End If
                                        Loop
                                        strCompositeHoldings = strCompositeHoldings & ", " & Right(strCurNumb, Len(strCurNumb) - intCounter1)
                                        blnNextRange = False
                                        strStartNumb = strCurNumb
                                        strEndNumb = strCurNumb
                                    End If
                                Else
                                    If Not strEndNumb = strStartNumb Then
                                        intCounter2 = 0
                                        Do While intCounter2 < Len(strStartRange) - 2 And intCounter2 < Len(strStartNumb) - 2
                                            If Mid(strStartNumb, intCounter2 + 1, 1) = Mid(strStartRange, intCounter2 + 1, 1) Then
                                                intCounter2 = intCounter2 + 1
                                            Else
                                                Exit Do
                                            End If
                                        Loop
                                        intCounter1 = 0
                                        intCounter2 = Len(strStartNumb) - intCounter2
                                        Do While intCounter1 < Len(strEndNumb) - intCounter2 And intCounter1 < Len(strStartNumb) - intCounter2
                                            If Mid(strStartNumb, intCounter1 + 1, 1) = Mid(strEndNumb, intCounter1 + 1, 1) Then
                                                intCounter1 = intCounter1 + 1
                                            Else
                                                Exit Do
                                            End If
                                        Loop
                                        If blnNextRange Then
                                            strCompositeHoldings = strCompositeHoldings & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                        Else
                                            strCompositeHoldings = Left(strCompositeHoldings, InStrRev(strCompositeHoldings, ",") - 1) & ", " & Right(strStartNumb, Len(strStartNumb) - intCounter1) & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                                        End If
                                    End If
                                    strCompositeHoldings = strCompositeHoldings & strSpaceLoc
                                    'strCompositeHoldings = strCompositeHoldings & strCompositeHoldings = strCompositeHoldings & strCopyNumber
                                    strCompositeHoldings = strCompositeHoldings & strCopyNumber
                                    While Not IsNumeric(Left(strCurNumb, 1)) And Len(strCurNumb) > 0
                                        strCommonCode = strCommonCode & Left(strCurNumb, 1)
                                        strCurNumb = Right(strCurNumb, Len(strCurNumb) - 1)
                                    End While
                                    strStartRange = strCurNumb
                                    strStartNumb = strCurNumb
                                    strEndNumb = strStartNumb
                                End If
                            End If
                        End If
                    Next
                End If
                If Not strEndNumb = strStartNumb Then
                    intCounter2 = 0
                    Do While intCounter2 < Len(strStartRange) - 2 And intCounter2 < Len(strStartNumb) - 2
                        If Mid(strStartNumb, intCounter2 + 1, 1) = Mid(strStartRange, intCounter2 + 1, 1) Then
                            intCounter2 = intCounter2 + 1
                        Else
                            Exit Do
                        End If
                    Loop
                    intCounter2 = Len(strStartNumb) - intCounter2
                    intCounter1 = 0
                    Do While intCounter1 < Len(strEndNumb) - intCounter2 And intCounter1 < Len(strStartNumb) - intCounter2
                        If Mid(strStartNumb, intCounter1 + 1, 1) = Mid(strEndNumb, intCounter1 + 1, 1) Then
                            intCounter1 = intCounter1 + 1
                        Else
                            Exit Do
                        End If
                    Loop
                    If blnNextRange Then
                        strCompositeHoldings = strCompositeHoldings & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                    Else
                        strCompositeHoldings = Left(strCompositeHoldings, InStrRev(strCompositeHoldings, ",") - 1) & ", " & Right(strStartNumb, Len(strStartNumb) - intCounter1) & "-" & Right(strEndNumb, Len(strEndNumb) - intCounter1)
                    End If
                End If
                If Not strCompositeHoldings = "" Then
                    If Left(strCompositeHoldings, 1) = strSpaceLoc Then
                        GenerateCompositeHoldings = Right(strCompositeHoldings, Len(strCompositeHoldings) - 1)
                    End If
                Else
                    GenerateCompositeHoldings = ""
                End If
            Catch exp As Exception
                ErrorMsg = exp.Message
                GenerateCompositeHoldings = ""
            End Try
            GenerateCompositeHoldings = GenerateCompositeHoldings.Replace(strSpaceLoc, "<br>")
            ' Commit transaction
            If objDInput.ErrorMsg = "" Then
                Call objDInput.CommitInputTrans()
            Else
                Call objDInput.RollBackInputTrans()
            End If
        End Function


        Public Function GenerateCompositeHoldingsOther(ByVal lngItemID As Long, ByVal blnIncLib As Boolean, ByVal blnIncInv As Boolean, ByVal blnIncShelf As Boolean, ByVal intLibId As Integer, ByVal intInvID As Integer, ByVal strDevider As String, Optional ByVal blnReplaceSpace As Boolean = False) As String
            ' Declare variables
            Dim strSelectStatement As String
            Dim intNOC As Integer ' number of CopyNumber
            Dim tblHolding As DataTable ' datatable of CopyNumberd

            ' Begin transaction
            objDInput.BeginInputTrans()

            Try
                If Not DBServer = "ORACLE" Then
                    strSelectStatement = "SELECT A.LibID, A.LocationID, Shelf, CopyNumber, Code, Symbol FROM Lib_tblHolding A JOIN Lib_tblHoldingLibrary B ON A.LibID = B.ID LEFT JOIN Lib_tblHoldingLocation C ON A.LocationID = C.ID WHERE ItemID = " & lngItemID
                Else
                    strSelectStatement = "SELECT A.LibID, A.LocationID, Shelf, CopyNumber, Code, Symbol FROM Lib_tblHolding A, Lib_tblHoldingLibrary B, Lib_tblHoldingLocation C WHERE A.LocationID = C.ID(+) AND A.LibID = B.ID AND ItemID = " & lngItemID
                End If
                If Not intLibId = 0 Then
                    strSelectStatement = strSelectStatement & " AND A.LibID = " & intLibId
                End If
                If Not intInvID = 0 Then
                    strSelectStatement = strSelectStatement & " AND A.LocationID = " & intInvID
                End If
                strSelectStatement = strSelectStatement & " ORDER BY A.LibID, A.LocationID, Shelf, CopyNumber"

                ' Read data from datatable
                objDInput.SQLStatement = strSelectStatement
                tblHolding = objDInput.GetData()
                intNOC = tblHolding.Rows.Count

                ' Process
                If intNOC = 0 Then
                    GenerateCompositeHoldingsOther = ""
                Else
                    '- GTVT /KS1V / /KS1V087306, 91248-91254, 91258-91267, 91269-91274, 91281-91282, 91284-91288, 91290, 91293-91297, 102311-102360
                    '- GTVT /KS2V / /KS2V022028-022038, 103991-103997

                    Dim groupbySymbol As List(Of Object) = tblHolding.Select().AsEnumerable().GroupBy(Function(x) x.Item("Symbol")).Select(Function(x) x.Key).ToList()

                    Dim countGroupbySymbol As Integer = groupbySymbol.Count

                    For i As Integer = 0 To countGroupbySymbol - 1
                        If Not i = 0 Then
                            GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther & "#"
                        End If
                        Dim dataByGroupbySymbol As List(Of DataRow) = tblHolding.Select("Symbol='" & groupbySymbol(i) & "'").ToList()
                        Dim strCopyNumberStart As String = ""
                        Dim strCopyNumberEnd As String = ""
                        Dim resultCopyNumberEnd As String = ""
                        For j As Integer = 0 To dataByGroupbySymbol.Count - 1
                            If j = 0 Then
                                If dataByGroupbySymbol(j).Item("Code").ToString() <> "" Then
                                    GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther & "Thư viện: " & dataByGroupbySymbol(j).Item("Code").ToString() & "<br>"
                                End If
                                If dataByGroupbySymbol(j).Item("Symbol").ToString() <> "" Then
                                    GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther & "Kho: " & dataByGroupbySymbol(j).Item("Symbol").ToString() & "<br>"
                                End If
                                If dataByGroupbySymbol(j).Item("Shelf").ToString() <> "" Then
                                    GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther & "Giá sách: " & dataByGroupbySymbol(j).Item("Shelf").ToString() & "<br>"
                                End If
                                GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther & "ĐKCB: " & dataByGroupbySymbol(j).Item("CopyNumber").ToString()
                                'strCopyNumberStart = dataByGroupbySymbol(j).Item("CopyNumber").ToString()
                            Else
                                'strCopyNumberStart = strCopyNumberStart.Replace(groupbySymbol(i), "")
                                'Dim copynumberStart As Integer = Integer.Parse(strCopyNumberStart)
                                'strCopyNumberEnd = dataByGroupbySymbol(j).Item("CopyNumber").ToString()
                                'Dim copynumberEnd As Integer = Integer.Parse(strCopyNumberEnd.Replace(groupbySymbol(i), ""))

                                'strCopyNumberStart = strCopyNumberEnd
                                'If copynumberEnd = copynumberStart + 1 Then
                                '    resultCopyNumberEnd = "-" & copynumberEnd
                                '    GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther.Replace("-" & copynumberStart, "") & resultCopyNumberEnd
                                'Else
                                '    GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther & ", " & copynumberEnd
                                'End If
                                GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther & "," & dataByGroupbySymbol(j).Item("CopyNumber").ToString()
                            End If
                        Next
                    Next

                End If
            Catch exp As Exception
                ErrorMsg = exp.Message
                GenerateCompositeHoldingsOther = ""
            End Try
            GenerateCompositeHoldingsOther = GenerateCompositeHoldingsOther.Replace("#", "<br>")
            ' Commit transaction
            If objDInput.ErrorMsg = "" Then
                Call objDInput.CommitInputTrans()
            Else
                Call objDInput.RollBackInputTrans()
            End If
        End Function

        ' Insert (update) AuthorityItem' information
        Public Function UpdateAuthority(ByVal intFormID As Integer, ByVal intImportRec As Integer, Optional ByVal blnKeepItemCode As Boolean = False) As Integer
            Dim arrSubVal()
            Dim strTempoSQL As String
            Dim strSQLStatement As String
            Dim strExclTags As String
            Dim strLeader As String
            Dim strTag As String
            Dim strTag001 As String
            Dim strTag911 As String
            Dim strTag912 As String
            Dim strTag040a As String
            Dim strUpdateSQL As String
            Dim strAccessEntry As String
            Dim strDisplayEntry As String
            Dim strHVal As String
            Dim intRefID As Integer
            Dim lngMainID As Long
            Dim intIndex As Integer
            Dim intCounter As Integer
            Dim ItemType, Func As Integer
            Dim tblAuthority As New DataTable

            Dim dtrData As DataRow() ' Datarows contain FieldID, FieldName after filtered
            Dim dtrRefData As New DataTable  ' DataTable contain References table data
            Dim row As DataRow
            Dim col As DataColumn

            ' Begin transaction
            objDInput.BeginInputTrans()

            If Not IsArray(arrFieldName) Or Not IsArray(arrFieldValue) Then
                ErrorMsg = LabelStr(3)
                UpdateAuthority = 0
                Exit Function
            End If

            strExclTags = "000,001,005,911,912"
            strTag = ""

            ' Get Leader
            intIndex = FindIndex(arrFieldName, "000")
            If intIndex >= 0 Then
                strLeader = arrFieldValue(intIndex)
            Else
                strLeader = "00025nz  a2200024n  4500" ' Default leader value
            End If

            If Not strItemCode = "" Or Not lngRecID = 0 Then
                If Not DBServer = "ORACLE" Then
                    strUpdateSQL = "UPDATE Cat_tblAuthority SET FormID = " & intFormID & ", Leader = '" & strLeader & "', LastModifiedDate = GETDATE()"
                Else
                    strUpdateSQL = "UPDATE Cat_tblAuthority SET FormID = " & intFormID & ", Leader = '" & strLeader & "', LastModifiedDate = SYSDATE"
                End If

                If Not strItemCode = "" Then
                    If Not DBServer = "ORACLE" Then
                        strSQLStatement = "SELECT ID FROM Cat_tblAuthority WHERE Upper(Code) = '" & UCase(strItemCode) & "'"
                    Else
                        strSQLStatement = "SELECT ID FROM Cat_tblAuthority WHERE Upper(Code) = Upper('" & strItemCode & "')"
                    End If

                    objDInput.SQLStatement = strSQLStatement
                    tblAuthority = objDInput.GetData()
                    If Not tblAuthority.Rows.Count = 0 Then
                        lngMainID = CLng(tblAuthority.Rows(0).Item("ID"))
                    Else
                        UpdateAuthority = 0
                        ErrorMsg = LabelStr(0) ' strItemCode does not exist
                        Exit Function
                    End If
                Else
                    If Not intReuse = 1 Then
                        lngMainID = lngRecID
                        strSQLStatement = "SELECT Code FROM Cat_tblAuthority WHERE ID = " & lngRecID
                        objDInput.SQLStatement = strSQLStatement
                        tblAuthority = objDInput.GetData()
                        If Not tblAuthority.Rows.Count = 0 Then
                            strItemCode = tblAuthority.Rows(0).Item("Code")
                        Else
                            UpdateAuthority = 0
                            ErrorMsg = LabelStr(0) ' strItemCode does not exist
                            Exit Function
                        End If
                    End If
                End If
            End If

            For intCounter = LBound(arrFieldName) To UBound(arrFieldName)
                strTag = strTag & "'" & arrFieldName(intCounter) & "',"
            Next
            strTag = Left(strTag, Len(strTag) - 1)

            ' Update Authority table

            ' An imported bib record is not allowed to overlay some
            ' local predefined 9XX fields on Authority table even
            ' when it updates an local bib record

            'If intImportRec = 1 And Not strItemCode = "" Then
            '    strSQLStatement = "UPDATE Cat_tblAuthority SET FormID = " & intFormID & ", Leader = '" & strLeader & "' WHERE ID = " & lngMainID
            'Else
            ' The record on Authority table can be either created or
            ' updated depend on whether the strItemCode is specified

            intIndex = FindIndex(arrFieldName, "100")
            If intIndex >= 0 Then
                intRefID = 1
            Else
                intIndex = FindIndex(arrFieldName, "110")
                If intIndex >= 0 Then
                    intRefID = 2
                Else
                    intIndex = FindIndex(arrFieldName, "111")
                    If intIndex >= 0 Then
                        intRefID = 3
                    Else
                        intIndex = FindIndex(arrFieldName, "130")
                        If intIndex >= 0 Then
                            intRefID = 4
                        Else
                            intIndex = FindIndex(arrFieldName, "150")
                            If intIndex >= 0 Then
                                intRefID = 5
                            Else
                                intIndex = FindIndex(arrFieldName, "151")
                                If intIndex >= 0 Then
                                    intRefID = 6
                                Else
                                    intIndex = FindIndex(arrFieldName, "155")
                                    If intIndex >= 0 Then
                                        intRefID = 7
                                    Else
                                        intIndex = FindIndex(arrFieldName, "180")
                                        If intIndex >= 0 Then
                                            intRefID = 8
                                        Else
                                            intIndex = FindIndex(arrFieldName, "181")
                                            If intIndex >= 0 Then
                                                intRefID = 9
                                            Else
                                                intIndex = FindIndex(arrFieldName, "182")
                                                If intIndex >= 0 Then
                                                    intRefID = 10
                                                Else
                                                    intIndex = FindIndex(arrFieldName, "185")
                                                    If intIndex >= 0 Then
                                                        intRefID = 11
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If intIndex >= 0 Then
                strHVal = arrFieldValue(intIndex)
                strDisplayEntry = objBCSP.TrimSubFieldCodes(objBCSP.ConvertItBack(strHVal))
                If InStr(strDisplayEntry, "::") > 0 And InStr(strDisplayEntry, "::") <= 3 Then
                    strDisplayEntry = Right(strDisplayEntry, Len(strDisplayEntry) - InStr(strDisplayEntry, "::") - 1)
                End If
                Call ParseField("$a", strHVal, "", arrSubVal)
                strAccessEntry = objBCSP.ProcessVal(objBCSP.TheDisplayOne(objBCSP.TrimSubFieldCodes(Trim(arrSubVal(0)))))
                If Not strItemCode = "" Then
                    If Not DBServer = "ORACLE" Then
                        strUpdateSQL = strUpdateSQL & ", AccessEntry= N'" & strAccessEntry & "', DisplayEntry = N'" & strDisplayEntry & "'"
                    Else
                        strUpdateSQL = strUpdateSQL & ", AccessEntry= '" & strAccessEntry & "', DisplayEntry = '" & strDisplayEntry & "'"
                    End If
                End If
            End If

            ' Get tag 911 value (Cataloguer)
            intIndex = FindIndex(arrFieldName, "911")
            If intIndex >= 0 Then
                strTag911 = arrFieldValue(intIndex)
                If Not strItemCode = "" Then
                    If Not DBServer = "ORACLE" Then
                        strUpdateSQL = strUpdateSQL & ", Cataloguer = N'" & objBCSP.ConvertItBack(strTag911) & "'"
                    Else
                        strUpdateSQL = strUpdateSQL & ", Cataloguer = '" & objBCSP.ConvertItBack(strTag911) & "'"
                    End If
                End If
            Else
                strTag911 = ""
            End If

            ' Get tag 912 value (Reviewer)
            intIndex = FindIndex(arrFieldName, "912")
            If intIndex >= 0 Then
                strTag912 = arrFieldValue(intIndex)
                If Not strItemCode = "" Then
                    If Not DBServer = "ORACLE" Then
                        strUpdateSQL = strUpdateSQL & ", Reviewer = N'" & objBCSP.ConvertItBack(strTag912) & "'"
                    Else
                        strUpdateSQL = strUpdateSQL & ", Reviewer = '" & objBCSP.ConvertItBack(strTag912) & "'"
                    End If
                End If
            Else
                strTag912 = ""
            End If

            ' Get tag 040$a value
            intIndex = FindIndex(arrFieldName, "040")
            If intIndex >= 0 Then
                Call ParseField("$a", arrFieldValue(intIndex), "##", arrSubVal)
                If arrSubVal(0) = "" Then
                    strTag040a = "NULL"
                Else
                    strTag040a = PickReferenceID(objBCSP.ConvertItBack(arrSubVal(0)), "Lib_tblHoldingLibrary", "ID", "Code")
                End If
                If Not strItemCode = "" Then
                    strUpdateSQL = strUpdateSQL & ",SourceID = " & strTag040a
                End If
            Else
                strTag040a = "NULL"
            End If

            ' Insert a record to Authority table
            If strItemCode = "" Then
                If intImportRec = 1 Then
                    strTag001 = Gen001(1)
                Else
                    intIndex = FindIndex(arrFieldName, "001")
                    If intIndex >= 0 Then
                        If blnKeepItemCode = True Then
                            Dim strSQLCheckCode As String
                            Dim tblItemCode As DataTable

                            ' Check the duplicate item code
                            If Not strDBServer = "ORACLE" Then
                                strSQLCheckCode = "SELECT ID FROM Cat_tblAuthority WHERE UPPER(Code) = N'" & UCase(arrFieldValue(intIndex)) & "'"
                            Else
                                strSQLCheckCode = "SELECT ID FROM Cat_tblAuthority WHERE Upper(Code) = Upper('" & arrFieldValue(intIndex) & "')"
                            End If

                            objDInput.SQLStatement = strSQLCheckCode
                            tblItemCode = objDInput.GetData

                            ' Gen the Item Code
                            If Not tblItemCode Is Nothing Then
                                ' If duplicate, gen new item code
                                If Not tblItemCode.Rows.Count = 0 Then
                                    strTag001 = Gen001(0)
                                Else
                                    strTag001 = arrFieldValue(intIndex)
                                End If
                            Else
                                strTag001 = arrFieldValue(intIndex)
                            End If
                        Else
                            strTag001 = Gen001(0)
                        End If
                    Else
                        strTag001 = Gen001(0)
                    End If
                End If
                'lngMainID = CreateID("CAT_AUTHORITY", "ID")
                lngMainID = CreateID("Cat_tblAuthority", "ID")

                If Not DBServer = "ORACLE" Then
                    strSQLStatement = "INSERT INTO Cat_tblAuthority (Status, FormID, Leader, Code, CreatedDate, Reviewer, Cataloguer, ID, AccessEntry, DisplayEntry, ReferenceID, SourceID, LastModifiedDate) VALUES (1,"
                    strSQLStatement = strSQLStatement & intFormID & ", '" & strLeader & "', '" & strTag001 & "', GETDATE(), '" & strTag912 & "', '" & strTag911 & "', " & lngMainID & ", N'" & strAccessEntry & "', N'" & strDisplayEntry & "', " & intRefID & ", " & strTag040a & ", GETDATE())"
                    lngWorkID = lngMainID
                Else
                    strSQLStatement = "INSERT INTO Cat_tblAuthority (Status, FormID, Leader, Code, CreatedDate, Reviewer, Cataloguer, ID, AccessEntry, DisplayEntry, ReferenceID, SourceID, LastModifiedDate) VALUES (1,"
                    strSQLStatement = strSQLStatement & intFormID & ", '" & strLeader & "', '" & strTag001 & "', SYSDATE, '" & strTag912 & "', '" & strTag911 & "', " & lngMainID & ", '" & strAccessEntry & "', '" & strDisplayEntry & "', " & intRefID & ", " & strTag040a & ", SYSDATE)"
                    lngWorkID = lngMainID
                End If

                ' Delete temp data in BOOKCODE_RES table
                If Not strDBServer = "ORACLE" Then
                    strTempoSQL = "DELETE FROM Cat_tblBookCodeRes WHERE DATEDIFF(second, CreatedTime, GETDATE()) > 30*60 OR Code = '" & strTag001 & "'"
                Else
                    strTempoSQL = "DELETE FROM Cat_tblBookCodeRes WHERE (SYSDATE - CreatedTime)*48 > 1 OR Code = '" & strTag001 & "'"
                End If
                objDInput.SQLStatement = strTempoSQL
                Call objDInput.ExecuteQuery()
                ' update a record to Authority table
            Else
                If Not DBServer = "ORACLE" Then
                    strSQLStatement = strUpdateSQL & ", CreatedDate = GETDATE() WHERE ID = " & lngMainID
                Else
                    strSQLStatement = strUpdateSQL & ", CreatedDate = SYSDATE WHERE ID = " & lngMainID
                End If
            End If

            objDInput.SQLStatement = strSQLStatement
            objDInput.ExecuteQuery()

            ' End If

            strSQLStatement = "SELECT ID, FieldCode, DicID FROM Lib_tblMARCAuthorityField WHERE FieldCode IN (" & strTag & ")"
            objDInput.SQLStatement = strSQLStatement
            tblAuthority = objDInput.GetData
            ' Select all tags assigned to the submitted cataloguing form.
            ' Insert tags' value to appropriate table
            For intCounter = LBound(arrFieldName) To UBound(arrFieldName)
                Try
                    dtrData = tblAuthority.Select("FieldCode = '" & arrFieldName(intCounter) & "'")
                    If InStr(strExclTags, arrFieldName(intCounter)) = 0 And Not dtrData.Length = 0 Then
                        For Each row In dtrData
                            If Not IsDBNull(row.Item("ID")) Then
                                Call UpdateBlockField(arrFieldName(intCounter), objBCSP.DoubleSingleQuote(arrFieldValue(intCounter)), lngMainID, row.Item("FieldCode"), 2, intImportRec)
                            End If
                        Next row
                    End If
                    tblAuthority.Select()
                Catch ex As Exception
                    Exit For
                Finally
                End Try
            Next
            ' Select all tags or subtags that use dictionary
            If intImportRec = 0 Then
                dtrData = tblAuthority.Select("DicID > 0")
                For Each row In dtrData
                    If Not IsDBNull(row.Item("ID")) Then
                        Call UpdateAuthorityReference(row.Item("FieldCode"), lngMainID)
                    End If
                Next row
                tblAuthority.Select()
            End If

            ' Commit transaction
            If objDInput.ErrorMsg = "" Then
                Call objDInput.CommitInputTrans()
                UpdateAuthority = 1
            Else
                Call objDInput.RollBackInputTrans()
                UpdateAuthority = 0
            End If
        End Function

        ' UpdateAuthorityReference method
        Private Sub UpdateAuthorityReference(ByVal strTag As String, ByVal lngItemID As Long)
            ' Declare variables
            Dim intIndex As Integer
            Dim intCounter1 As Integer
            Dim intLinkType As Integer
            Dim strValue As String
            Dim arrSubVal()
            Dim arrRecords()

            ' Process
            If Not strItemCode = "" Then
                objDInput.SQLStatement = "DELETE FROM Cat_tblAutorityLink WHERE ID1 = " & lngItemID
                objDInput.ExecuteQuery()
            End If
            intIndex = FindIndex(arrFieldName, strTag)
            If intIndex >= 0 Then
                strValue = arrFieldValue(intIndex)
            Else
                strValue = ""
            End If
            If strValue = "" Or strValue = "::" Then
                Exit Sub
            End If

            ' Get intLinkType
            Select Case Left(strTag, 1)
                Case "4"
                    intLinkType = 1
                Case "5"
                    intLinkType = 2
                Case "7"
                    intLinkType = 3
                Case Else
                    intLinkType = 0
            End Select

            If intLinkType > 0 Then
                Call ParseFieldValue(strValue, "$&", arrRecords)
                For intCounter1 = 0 To UBound(arrRecords)
                    If Not (arrRecords(intCounter1) = "" Or arrRecords(intCounter1) = "::") Then
                        Call ParseField("$0", arrRecords(intCounter1), "", arrSubVal)
                        If Not arrSubVal(0) = "" Then
                            If InStr(arrSubVal(0), ")") > 0 Then
                                arrSubVal(0) = Right(arrSubVal(0), Len(arrSubVal(0)) - InStr(arrSubVal(0), ")"))
                            End If
                            arrSubVal(0) = Replace(arrSubVal(0) & "", " ", "")
                            If IsNumeric(arrSubVal(0)) And Not arrSubVal(0) = "" Then
                                objDInput.SQLStatement = "INSERT INTO Cat_tblAutorityLink (ID1, ID2, intLinkType) VALUES (" & lngItemID & ", " & arrSubVal(0) & ", " & intLinkType & ")"
                                objDInput.ExecuteQuery()
                            End If
                        End If
                    End If
                Next
            End If
        End Sub

        ' ParseISORec method
        ' Input: string of record content (strRecordContent)
        ' Output: two array of FieldNames and FieldValues (arrOutFieldName, arrOutFieldValue)
        Public Sub ParseISORec(ByVal strRecordContent As String, ByRef arrOutFieldName() As Object, ByRef arrOutFieldValue() As Object)
            Dim lngLenOfRec As Long
            Dim strLeader As String
            Dim lngBaseAddress As Long
            Dim strDirBlock As String
            Dim strFieldBlock As String
            Dim strFieldItem As String
            Dim strFieldName As String
            Dim strFieldValue As String
            Dim strFieldCheck As String = ""
            Dim strFieldValueCheck As String = ""
            Dim intCheck As Integer
            ReDim arrOutFieldName(0)
            ReDim arrOutFieldValue(0)
            strErrorMsg = ""
            Try
                strRecordContent = LTrim(strRecordContent)
                '--PhuongTT -->Xu ly loi Font chu TVKHTH
                strRecordContent = Replace(strRecordContent, "�", " ")
                '--
                lngLenOfRec = CLng(Left(strRecordContent, 5))
                strRecordContent = Left(strRecordContent, lngLenOfRec)
                strRecordContent = Replace(strRecordContent, Chr(31), "$")
                strRecordContent = Replace(strRecordContent, Chr(30), "#")
                strRecordContent = Replace(strRecordContent, Chr(29), "#")
                strRecordContent = objBCSP.UnicodeToUTF8(strRecordContent)
                strLeader = Left(strRecordContent, 24)
                lngBaseAddress = CLng(Mid(strRecordContent, 13, 5))
                strDirBlock = Mid(strRecordContent, 25, lngBaseAddress - 25)
                strFieldBlock = Right(strRecordContent, Len(strRecordContent) - lngBaseAddress)
                Call AddFields("000", strLeader, arrOutFieldName, arrOutFieldValue)
                strFieldCheck = "000"
                intCheck = 0
                Do While Len(strDirBlock) > 0
                    strFieldItem = Left(strDirBlock, 12)
                    strDirBlock = Right(strDirBlock, Len(strDirBlock) - 12)
                    strFieldName = Left(strFieldItem, 3)

                    Dim iC As Integer = strFieldBlock.IndexOf("#")
                    strFieldValue = Trim(Left(strFieldBlock, iC + 1))
                    strFieldBlock = strFieldBlock.Substring(iC + 1)

                    'strFieldValue = Mid(strFieldBlock, iC, strFieldBlock.Substring(iC).IndexOf("#") + 1)
                    'strFieldValue = Trim(strFieldValue)
                    If strFieldValue.Length > 0 Then
                        strFieldValue = Left(strFieldValue, Len(strFieldValue) - 1)

                        If InStr(strFieldName, "00") = 1 Or strFieldName >= "900" Then
                            ' strFieldValue = "::" & strFieldValue
                            'Phuong 02/08/2008
                            'Ap dung import doi voi file iso cuar ibol 
                            'B1
                            If strFieldName = "927" Then
                                strFieldValue = "::" & Mid(strFieldBlock, CInt(Right(strFieldItem, 5)) + 1, CInt(Mid(strFieldItem, 4, 4))) 'strFieldValue
                            ElseIf strFieldName = "915" Then 'B1 DH Y DUOC
                                strFieldValue = Left(strFieldValue, 2) & "::" & Right(strFieldValue, Len(strFieldValue) - 2)
                            End If
                            'E1
                        Else
                            'strFieldValue = Left(strFieldValue, 2) & "::" & Right(strFieldValue, Len(strFieldValue) - 2)
                            strFieldValue = strFieldValue
                        End If
                        'If strFieldName < "900" And Right(strFieldName, 2) < "90" Then
                        '    strFieldValue = objBCSP.UTF8ToUnicode(strFieldValue)
                        '    Call AddFields(strFieldName, strFieldValue, arrOutFieldName, arrOutFieldValue)
                        'End If

                        'Alter by chuyenpt(101007): 020 co >1 gia tri thi chi gia tri dau tien duoc chen vao CAT_DIC_NUMBER

                        If strFieldName.Trim <> strFieldCheck.Trim Then
                            strFieldCheck = strFieldName
                            If strFieldValueCheck <> "" Then
                                arrOutFieldValue((intCheck * 2) + 1) = arrOutFieldValue((intCheck * 2) + 1) & "$&" & strFieldValueCheck
                                strFieldValueCheck = ""
                            End If
                            If strFieldName < "900" Then
                                strFieldValue = objBCSP.UTF8ToUnicode(strFieldValue)
                                Call AddFields(strFieldName, strFieldValue, arrOutFieldName, arrOutFieldValue)
                                intCheck += 1
                            ElseIf strFieldName >= "900" Then
                                'Phuong 02/08/2008
                                'Ap dung import doi voi file iso cuar ibol 
                                'B2
                                If strFieldName = "927" Or strFieldName = "915" Then 'B2 DH Y DUOC
                                    strFieldValue = objBCSP.UTF8ToUnicode(strFieldValue)
                                    Call AddFields(strFieldName, strFieldValue, arrOutFieldName, arrOutFieldValue)
                                    intCheck += 1

                                End If
                                'E2
                            End If
                        Else
                            'Phuong 01/08/2008
                            'Chuyen font doi voi truong trung lap
                            'B1
                            If Not strFieldValue = "" Then
                                strFieldValue = objBCSP.UTF8ToUnicode(strFieldValue)
                            End If
                            'E1
                            strFieldValueCheck = strFieldValueCheck & strFieldValue & "$&"
                        End If
                    End If
                Loop
            Catch ex As Exception
                strErrorMsg = "Error"
            End Try
        End Sub

        ' ParseISORec method
        ' Input: string of record content (strRecordContent)
        ' Output: two array of FieldNames and FieldValues (arrOutFieldName, arrOutFieldValue)
        Public Sub ParseISORecCfs(ByVal strRecordContent As String, ByRef arrOutFieldName() As Object, ByRef arrOutFieldValue() As Object)
            Dim lngLenOfRec As Long
            Dim strLeader As String
            Dim lngBaseAddress As Long
            Dim strDirBlock As String
            Dim strFieldBlock As String
            Dim strFieldItem As String
            Dim strFieldName As String
            Dim strFieldValue As String
            ReDim arrOutFieldName(0)
            ReDim arrOutFieldValue(0)
            Try
                strRecordContent = LTrim(strRecordContent)
                lngLenOfRec = CLng(Left(strRecordContent, 5))
                strRecordContent = Left(strRecordContent, lngLenOfRec)
                strRecordContent = Replace(strRecordContent, Chr(31), "$")
                strRecordContent = Replace(strRecordContent, Chr(30), "#")
                strRecordContent = Replace(strRecordContent, Chr(29), "#")
                strRecordContent = objBCSP.UnicodeToUTF8(strRecordContent)
                strLeader = Left(strRecordContent, 24)
                lngBaseAddress = CLng(Mid(strRecordContent, 13, 5))
                strDirBlock = Mid(strRecordContent, 25, lngBaseAddress - 25)
                strFieldBlock = Right(strRecordContent, Len(strRecordContent) - lngBaseAddress)
                Call AddFields("000", strLeader, arrOutFieldName, arrOutFieldValue)
                Do While Len(strDirBlock) > 0
                    strFieldItem = Left(strDirBlock, 12)
                    strDirBlock = Right(strDirBlock, Len(strDirBlock) - 12)
                    strFieldName = Left(strFieldItem, 3)
                    strFieldValue = Mid(strFieldBlock, CInt(Right(strFieldItem, 5)) + 1, CInt(Mid(strFieldItem, 4, 4)))
                    If Right(strFieldValue, 1) = "#" Then
                        strFieldValue = Left(strFieldValue, Len(strFieldValue) - 1)
                    End If
                    If InStr(strFieldName, "00") = 1 Or strFieldName > "900" Then
                        ' strFieldValue = "::" & strFieldValue
                    Else
                        strFieldValue = Left(strFieldValue, 2) & Right(strFieldValue, Len(strFieldValue) - 2)
                    End If
                    If strFieldName < "900" And Right(strFieldName, 2) < "90" Then
                        strFieldValue = objBCSP.UTF8ToUnicode(strFieldValue)
                        Call AddFields(strFieldName, strFieldValue, arrOutFieldName, arrOutFieldValue)
                    End If
                Loop
            Catch ex As Exception
                strErrorMsg = "Error"
            End Try
        End Sub

        ' AddFields method
        ' Input: 
        '   - String value of FieldName (strNames)
        '   - String value of FieldValue (strVal)
        ' Output: two array of FieldNames and FieldValues (arrFName, arrFValue)
        Private Sub AddFields(ByVal strNames As String, ByVal strVal As String, ByRef arrFName() As Object, ByRef arrFValue() As Object)
            Dim intIndex As Integer
            Dim intCounter As Integer

            If Trim(strNames) <> "" Then
                ' For intCounter = 0 To UBound(arrFName) - 1
                For intCounter = 0 To UBound(arrFName)
                    If arrFName(intCounter) = strNames Then
                        intIndex = intCounter
                    Else
                        intIndex = intCounter + 1
                    End If
                Next
                If intIndex > UBound(arrFName) - 1 Then
                    ReDim Preserve arrFName(intIndex + 1)
                    ReDim Preserve arrFValue(intIndex + 1)
                    arrFName(intIndex) = strNames
                    arrFValue(intIndex) = strVal
                Else
                    arrFValue(intIndex) = arrFValue(intIndex) & "$&" & strVal
                End If
            End If
        End Sub

        ' ParseTaggedRecord method
        ' Purpose: parse record content into 2 array (arrFieldName, arrFieldValue)
        ' Input: 
        '   - string value of Record' content: strRecordContent
        '   - string value of deliminator: strDeliminator
        '   - char to parse lines: chrFd
        '   - string value designator to determine subfields: strDesignator
        '   - int value blnKeep900 allow keep values of field900s: blnKeep900
        ' Output: 2 array (arrFieldName, arrFieldValue)

        Public Sub ParseTaggedRecord(ByVal chrFd As Char, ByVal strDeliminator As String, ByVal strRecordContent As String, ByRef arrFieldName() As Object, ByRef arrFieldValue() As Object, ByVal strDesignator As String, ByVal blnKeep900 As Boolean)
            ' Declare variables
            ReDim arrFieldName(0)
            ReDim arrFieldValue(0)
            Dim strFieldName As String
            Dim strIndicators As String
            Dim strFieldValue As String
            Dim intCount As Integer
            Dim intDeliPos As Integer
            Dim intSubCount As Integer
            Dim intIndex As Integer
            Dim intFindIndex As Integer
            Dim TagArr As Object
            Dim SubTag As Object

            intIndex = 0
            strRecordContent = Replace(strRecordContent, strDesignator, "$")
            TagArr = Split(strRecordContent, chrFd)
            For intCount = LBound(TagArr) To UBound(TagArr)
                strFieldValue = Trim(TagArr(intCount))
                intDeliPos = InStr(strFieldValue, strDeliminator)
                If intDeliPos > 0 Then
                    strFieldName = Right(Trim(Left(strFieldValue, intDeliPos - 1)), 3)
                    If strFieldName < "900" Or blnKeep900 Then
                        If Trim(strFieldName) = "001" Then
                            strFieldValue = Trim(Right(strFieldValue, Len(strFieldValue) - intDeliPos - Len(CStr(chrFd)) + 2))
                        Else
                            strFieldValue = Right(strFieldValue, Len(strFieldValue) - intDeliPos - Len(CStr(chrFd)) + 1)
                        End If
                        intDeliPos = InStr(strFieldValue, strDeliminator)
                        If intDeliPos >= 1 And intDeliPos <= 3 Then
                            strIndicators = Left(strFieldValue, 2) & "::"
                            If intDeliPos > 1 Then
                                strFieldValue = Trim(Right(strFieldValue, Len(strFieldValue) - intDeliPos - Len(CStr(chrFd)) + 1))
                            Else
                                strFieldValue = Trim(Right(strFieldValue, Len(strFieldValue) - 2))
                            End If
                        Else
                            'strIndicators = "::"
                        End If
                        If InStr(strFieldValue, "$") > 0 Then
                            SubTag = Split(strFieldValue, "$")
                            strFieldValue = ""
                            For intSubCount = 0 To UBound(SubTag)
                                If Not Trim(SubTag(intSubCount)) = "" Then
                                    If Mid(SubTag(intSubCount), 2, 1) = " " Then
                                        strFieldValue = strFieldValue & "$" & Left(SubTag(intSubCount), 1) & Right(SubTag(intSubCount), Len(SubTag(intSubCount)) - 2)
                                    Else
                                        strFieldValue = strFieldValue & "$" & SubTag(intSubCount)
                                    End If
                                End If
                            Next
                        End If
                        intFindIndex = FindIndex(arrFieldName, strFieldName)
                        If intFindIndex = -1 Then
                            ReDim Preserve arrFieldName(intIndex)
                            ReDim Preserve arrFieldValue(intIndex)
                            arrFieldName(intIndex) = strFieldName
                            arrFieldValue(intIndex) = strIndicators & strFieldValue
                            intIndex = intIndex + 1
                        Else
                            arrFieldValue(intFindIndex) = arrFieldValue(intFindIndex) & "$&" & strIndicators & strFieldValue
                        End If
                    End If
                End If
            Next
        End Sub

        ' Dispose method
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDInput Is Nothing Then
                    objDInput.Dispose(True)
                    objDInput = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not tblReferences Is Nothing Then
                    tblReferences.Dispose()
                    tblReferences = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Insert ITEM_FILES /Thọ
        Public Sub QueryExcuteItemFile(ByVal itemId As Integer, ByVal fileName As String,
                                            ByVal fileSize As Integer, ByVal pathUrl As String, ByVal originFile As String, Optional formatId As Integer = Nothing, Optional objectId As Integer = Nothing)
            Dim strTempoSql As String = ""
            objDInput.BeginInputTrans()
            If (objectId = Nothing Or objectId = 0) Then
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strTempoSql = "INSERT INTO ITEM_FILES (ItemID, FileName, FormatID, FileSize, Existed, Path, DownloadTimes, DateUpload, Viewer, XMLPath, Status, OriginFile, Description, Thumnail) "
                        strTempoSql = strTempoSql & "VALUES(" & itemId & ",N'" & fileName & "'," & formatId & "," & fileSize & "," & "1" & ",N'" & pathUrl & "'," & "0" & ",GETDATE()," & "0" & ",NULL," & "NULL" & ",'" & originFile & "'," & "NULL" & "," & "NULL" & ")"
                    Case "SQLSERVER"
                        strTempoSql = "INSERT INTO ITEM_FILES (ItemID, FileName, FormatID, FileSize, Existed, Path, DownloadTimes, DateUpload, Viewer, XMLPath, Status, OriginFile, Description, Thumnail) "
                        strTempoSql = strTempoSql & "VALUES(" & itemId & ",N'" & fileName & "'," & formatId & "," & fileSize & "," & "1" & ",N'" & pathUrl & "'," & "0" & ",GETDATE()," & "0" & ",NULL," & "NULL" & ",'" & originFile & "'," & "NULL" & "," & "NULL" & ")"
                    Case Else
                        strTempoSql = ""
                End Select
            Else
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strTempoSql = "UPDATE ITEM_FILES SET ItemID=" & itemId & ", FileName=N'" & fileName & "', FileSize=" & fileSize & ", Path=N'" & pathUrl & "' WHERE ID=" + objectId
                    Case "SQLSERVER"
                        strTempoSql = "UPDATE ITEM_FILES SET ItemID=" & itemId & ", FileName=N'" & fileName & "', FileSize=" & fileSize & ", Path=N'" & pathUrl & "' WHERE ID=" + objectId
                    Case Else
                        strTempoSql = ""
                End Select
            End If

            If (strTempoSql <> "") Then
                objDInput.SQLStatement = strTempoSql
                objDInput.ExecuteQuery()
            End If
            objDInput.CommitInputTrans()
        End Sub
        'Insert FIELDXXXS /Thọ
        Public Sub QueryExcuteField(ByVal tableField As String, ByVal content As String, ByVal itemId As Integer, ByVal fieldCode As Integer, Optional objectId As Integer = Nothing)
            Dim strTempoSql As String = ""
            'objDInput.BeginInputTrans()
            If (objectId = Nothing Or objectId = 0) Then
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strTempoSql = "INSERT INTO " & tableField & " ([Content], ItemID, FieldCode, Ind1, Ind2) "
                        strTempoSql = strTempoSql & "VALUES('" & content & "'," & itemId & ",'" & fieldCode & "','','')"
                    Case "SQLSERVER"
                        strTempoSql = "INSERT INTO " & tableField & " ([Content], ItemID, FieldCode, Ind1, Ind2) "
                        strTempoSql = strTempoSql & "VALUES('" & content & "'," & itemId & ",'" & fieldCode & "','','')"
                    Case Else
                        strTempoSql = ""
                End Select
            Else
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strTempoSql = "UPDATE " & tableField & " SET ItemID=" & itemId & ", [Content]=N'" & content & "', FieldCode=" & fieldCode & " WHERE ID=" & objectId
                    Case "SQLSERVER"
                        strTempoSql = "UPDATE " & tableField & " SET ItemID=" & itemId & ", [Content]=N'" & content & "', FieldCode=" & fieldCode & " WHERE ID=" & objectId
                    Case Else
                        strTempoSql = ""
                End Select
            End If

            If (strTempoSql <> "") Then
                objDInput.SQLStatement = strTempoSql
                objDInput.ExecuteQuery()
            End If
        End Sub
        'ExcuteQuery By TextQuery /Thọ
        Public Function ExcuteQueryByScript(ByVal strQuery As String) As Integer
            objDInput.BeginInputTrans()
            Try
                If (strQuery <> "") Then
                    Select Case UCase(strDBServer)
                        Case "ORACLE"
                            objDInput.SQLStatement = strQuery
                            objDInput.ExecuteQuery()
                        'objDInput.CloseConnection()
                        Case "SQLSERVER"
                            objDInput.SQLStatement = strQuery
                            objDInput.ExecuteQuery()
                            'objDInput.CloseConnection()
                    End Select
                End If
                objDInput.CommitInputTrans()
                Return 1
            Catch ex As Exception
                objDInput.RollBackInputTrans()
                Return 0
            End Try
        End Function


        'Get TextQueryExcute /Thọ
        Public Function GetTextQueryField(ByVal tableField As String, ByVal content As String, ByVal itemId As Integer, ByVal fieldCode As Integer, Optional objectId As Integer = Nothing) As String
            Dim result As String = ""
            If (objectId = Nothing Or objectId = 0) Then
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        result = "INSERT INTO " & tableField & " ([Content], ItemID, FieldCode, Ind1, Ind2) "
                        result = result & "VALUES(N'" & content & "'," & itemId & ",'" & If(fieldCode < 100, "0" & fieldCode.ToString(), fieldCode.ToString()) & "','','')"
                    Case "SQLSERVER"
                        result = "INSERT INTO " & tableField & " ([Content], ItemID, FieldCode, Ind1, Ind2) "
                        result = result & "VALUES(N'" & content & "'," & itemId & ",'" & If(fieldCode < 100, "0" & fieldCode.ToString(), fieldCode.ToString()) & "','','')"
                    Case Else
                        result = ""
                End Select
            Else
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        result = "UPDATE " & tableField & " SET ItemID=" & itemId & ", [Content]=N'" & content & "', FieldCode=" & If(fieldCode < 100, "0" & fieldCode.ToString(), fieldCode.ToString()) & " WHERE ID=" & objectId
                    Case "SQLSERVER"
                        result = "UPDATE " & tableField & " SET ItemID=" & itemId & ", [Content]=N'" & content & "', FieldCode=" & If(fieldCode < 100, "0" & fieldCode.ToString(), fieldCode.ToString()) & " WHERE ID=" & objectId
                    Case Else
                        result = ""
                End Select
            End If
            Return result
        End Function

        'Get FormatId By originFile /Thọ
        Public Function GetFormatId(ByVal originFile As String) As Integer
            Dim result As Integer = 0
            Dim strTempoSql As String = ""
            Dim tblItem As New DataTable
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strTempoSql = "SELECT ID FROM Cat_tblDicFormat WHERE Type like '%," + originFile + ",%'"
                Case "SQLSERVER"
                    strTempoSql = "SELECT ID FROM Cat_tblDicFormat WHERE Type like '%," + originFile + ",%'"
                Case Else
                    strTempoSql = ""
            End Select
            objDInput.SQLStatement = strTempoSql
            tblItem = objDInput.GetData()
            If Not tblItem Is Nothing Then
                If Not tblItem.Rows.Count = 0 Then
                    result = CInt(tblItem.Rows(0).Item("ID"))
                Else
                    result = 0
                End If
            Else
                result = 0
            End If
            Return result
        End Function

        'GetTypeCode by TypeName with DataItem /Thọ
        Public Function GetTypeCode(ByVal typeName As String, ByVal dataItem As String()) As String
            Dim result As String = ""

            For Each item As String In dataItem
                Dim split = item.Split("|")
                Dim typeNameSplit As String = split(0)
                Dim typeCodeSplit As String = split(1)
                If typeName.ToUpper = typeNameSplit.ToUpper Then
                    result = typeCodeSplit
                    Exit For
                End If
            Next

            Return result
        End Function

        'GetListItemCatType CAT_DIC_ITEM_TYPE by SP_CAT_DIC_ITEM_LIST
        Public Function GetListItemCatType() As String()
            Dim result As String() = Nothing
            Dim tblItem As New DataTable
            Dim strTempoSql As String = ""
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strTempoSql = "[Cat_spDicItemType_SelAll]"
                Case "SQLSERVER"
                    strTempoSql = "[Cat_spDicItemType_SelAll]"
                Case Else
                    strTempoSql = ""
            End Select
            objDInput.SQLStatement = strTempoSql
            tblItem = objDInput.GetData()
            If Not tblItem Is Nothing Then
                If Not tblItem.Rows.Count = 0 Then
                    ReDim Preserve result(tblItem.Rows.Count)
                    For i As Integer = 0 To tblItem.Rows.Count - 1
                        result(i) = tblItem.Rows(i).Item("TypeName") & "|" & tblItem.Rows(i).Item("TypeCode")
                    Next
                Else
                    result = Nothing
                End If
            Else
                result = Nothing
            End If
            Return result
        End Function

        'Close Connection /Thọ
        Public Sub CloseConnection()
            objDInput.CloseConnection()
        End Sub

        'GetSysPara method /Thọ
        Public Function GetValueSysByParameter(ByVal para As String) As String
            Dim resultObject() As String = objBCDBS.GetSystemParameters(objPara)
            Dim i = 0
            Dim indexPara As Integer = -1
            For Each Str As String In objPara
                If Str = para Then
                    indexPara = i
                    Exit For
                End If
                i = i + 1
            Next
            If indexPara <> -1 Then
                Return resultObject(indexPara)
            End If
            Return Nothing
        End Function

        'GetLibary /Thọ
        Public Function GetLibaryUrl(ByVal Id As Integer) As String
            Dim result As String = Nothing
            Dim strTempoSql As String = ""
            Dim tblItem As New DataTable
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strTempoSql = "SELECT EdelivFolder FROM SYS_LIBRARY WHERE ID=" & Id
                Case "SQLSERVER"
                    strTempoSql = "SELECT EdelivFolder FROM SYS_LIBRARY WHERE ID=" & Id
                Case Else
                    strTempoSql = ""
            End Select
            objDInput.SQLStatement = strTempoSql
            tblItem = objDInput.GetData()
            If Not tblItem Is Nothing Then
                If Not tblItem.Rows.Count = 0 Then
                    result = tblItem.Rows(0).Item("EdelivFolder")
                Else
                    result = Nothing
                End If
            Else
                result = Nothing
            End If
            Return result
        End Function

       

        ' Get Value FieldCode 082 by ItemId - Tho
        Public Function GetContentFieldCode(ByVal fieldCode As String, ByVal itemId As Integer) As String
            Dim nameTable As String = GenTableField(fieldCode)
            Dim result As String = objDInput.GetContentFieldCode(fieldCode, itemId, nameTable)
            Return result
        End Function
        ' Gen Table Field - Tho
        Public Function GenTableField(ByVal fieldCode As String) As String
            Dim nameTable As String = Nothing
            Dim valueFieldCode As Integer = CInt(fieldCode)
            If (valueFieldCode <= 100) Then
                nameTable = "Lib_tblField000S"
            End If
            If (valueFieldCode > 100 And valueFieldCode <= 200) Then
                nameTable = "Lib_tblField100S"
            End If
            If (valueFieldCode > 200 And valueFieldCode <= 300) Then
                nameTable = "Lib_tblField200S"
            End If
            If (valueFieldCode > 300 And valueFieldCode <= 400) Then
                nameTable = "Lib_tblField300S"
            End If
            If (valueFieldCode > 400 And valueFieldCode <= 500) Then
                nameTable = "Lib_tblField400S"
            End If
            If (valueFieldCode > 500 And valueFieldCode <= 600) Then
                nameTable = "Lib_tblField500S"
            End If
            If (valueFieldCode > 600 And valueFieldCode <= 700) Then
                nameTable = "Lib_tblField600S"
            End If
            If (valueFieldCode > 700 And valueFieldCode <= 800) Then
                nameTable = "Lib_tblField700S"
            End If
            If (valueFieldCode > 800 And valueFieldCode <= 900) Then
                nameTable = "Lib_tblField800S"
            End If
            If (valueFieldCode > 900) Then
                nameTable = "Lib_tblField900S"
            End If
            Return nameTable
        End Function

        Public Function GetHoldingByItemId(ByVal itemId As Integer) As DataTable
            Dim result As DataTable = objDInput.GetHoldingByItemId(itemId)
            Return result
        End Function

        ' Get Last Record Holding By ItemId
        Public Function GetLastRecordHoldingByItemId(ByVal itemId As Integer) As DataTable
            Dim result As DataTable = objDInput.GetLastRecordHoldingByItemId(itemId)
            Return result
        End Function

        ' Get HoldingLocation
        Public Function GetHoldingLocation(ByVal intHoldingLibrary As Integer) As DataTable
            GetHoldingLocation = Nothing
            Try
                GetHoldingLocation = objDInput.GetHoldingLocation(intHoldingLibrary)
                strErrorMsg = objDInput.ErrorMsg
                intErrorCode = objDInput.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDInput.ErrorMsg
                intErrorCode = objDInput.ErrorCode
            End Try
        End Function

        Public Function GetHoldingLocationByUserID(ByVal intHoldingLibrary As Integer,
                                                   Optional intUserID As Integer = 0,
                                                   Optional intTopText As Integer = 1,
                                                   Optional strTopText As String = Nothing) As DataTable
            GetHoldingLocationByUserID = Nothing
            Try
                If strTopText IsNot Nothing AndAlso strTopText.Trim() = "" Then
                    strTopText = Nothing
                End If
                GetHoldingLocationByUserID = objDInput.GetHoldingLocationByUserID(intHoldingLibrary, intUserID, intTopText)
                strErrorMsg = objDInput.ErrorMsg
                intErrorCode = objDInput.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDInput.ErrorMsg
                intErrorCode = objDInput.ErrorCode
            End Try
        End Function

        Public Function GetData() As DataTable
            Try
                objDInput.SQLStatement = strSQL
                GetData = objDInput.GetData()
                strErrorMsg = objDInput.ErrorMsg
                intErrorCode = objDInput.ErrorCode
            Catch ex As Exception
                strErrorMsg = objDInput.ErrorMsg
                intErrorCode = objDInput.ErrorCode
            End Try
        End Function
    End Class
End Namespace