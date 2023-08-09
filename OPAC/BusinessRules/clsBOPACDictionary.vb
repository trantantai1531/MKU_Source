Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACDictionary
        Inherits clsBBase
        ' ************************************************************************************************
        ' Declare Private variables
        ' ************************************************************************************************

        Private strAccessEntry As String
        Private strDicName As String
        Private strDirection As String
        Private intDicType As Integer
        Private intDictionaryID As Integer = 1
        Private objDOPACDictionary As New clsDOPACDictionary
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        ' ************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ************************************************************************************************

        ' DictionaryID Property
        Public Property DictionaryID() As Integer
            Get
                Return (intDictionaryID)
            End Get
            Set(ByVal Value As Integer)
                intDictionaryID = Value
            End Set
        End Property
        ' AccessEntry Property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' DicName Property
        Public Property DicName() As String
            Get
                Return strDicName
            End Get
            Set(ByVal Value As String)
                strDicName = Value
            End Set
        End Property

        ' Direction Property
        Public Property Direction() As String
            Get
                Return strDirection
            End Get
            Set(ByVal Value As String)
                strDirection = Value
            End Set
        End Property

        ' intDicType Property
        Public Property DicType() As Integer
            Get
                Return intDicType
            End Get
            Set(ByVal Value As Integer)
                intDicType = Value
            End Set
        End Property

        ' ************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACDictionary object
            objDOPACDictionary.DBServer = strDBServer
            objDOPACDictionary.ConnectionString = strConnectionString
            objDOPACDictionary.Initialize()

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
        End Sub

        ' GetDictionary method
        ' Purpose: Get Dictionary
        ' Input: DictionaryID, AccessEntry
        ' Output: DataTable
        ' Creator: PhuongTT
        Public Function GetDictionary(Optional ByVal intTop As Integer = 400) As DataTable
            Try
                Dim tblCatDicList As DataTable
                Dim tblEntries As DataTable
                Dim arrValueField(0) As String
                Dim arrTextField(0) As String
                Dim objQueryFields As Object
                Dim Entries() As String
                Dim text, val, strPattern, EntryPattern, strMySQL As String
                Dim inti, intMaxNumber As Integer
                ' Select DicTable, AccessEntry From CAT_DIC_LIST table
                tblCatDicList = GetCatDicList(intDictionaryID)
                If tblCatDicList Is Nothing Or tblCatDicList.Rows.Count <= 0 Then
                    Return (Nothing)
                End If
                If tblCatDicList.Rows(0).Item("SearchFields") <> "" Then
                    objQueryFields = LoadArray(tblCatDicList.Rows(0).Item("SearchFields"))
                Else
                    ReDim objQueryFields(0)
                    objQueryFields(0) = tblCatDicList.Rows(0).Item("CaptionField")
                End If
                strPattern = objBCSP.ConvertItBack(AccessEntry)
                EntryPattern = objBCSP.ProcessVal(strPattern)
                ' Forming SQL command
                If strdbserver = "SQLSERVER" Then
                    'strPattern = objtvComUtf8.SearchPattern(strPattern)
                    strPattern = objBCSP.killCharsProcessVal(strPattern)
                    strMySQL = "SELECT TOP " & intTop & " * FROM " & tblCatDicList.Rows(0).Item("DicTable") & " WHERE "
                    If Not strPattern = "" Then
                        For inti = 0 To UBound(objQueryFields)
                            If Not objQueryFields(inti) = tblCatDicList.Rows(0).Item("CaptionField") Then
                                strMySQL = strMySQL & objQueryFields(inti) & " LIKE N'" & strPattern & "' OR "
                            End If
                        Next
                        strMySQL = strMySQL & "AccessEntry LIKE N'" & EntryPattern & "' OR "
                    Else
                        strMySQL = strMySQL & "1 = 1 OR"
                    End If
                    strMySQL = Left(strMySQL, Len(strMySQL) - 3)
                    strMySQL = strMySQL & " ORDER BY AccessEntry"
                Else
                    strMySQL = "SELECT * FROM " & tblCatDicList.Rows(0).Item("DicTable") & " WHERE ("
                    If Not strPattern = "" Then
                        For inti = 0 To UBound(objQueryFields)
                            If Not objQueryFields(inti) = tblCatDicList.Rows(0).Item("CaptionField") Then
                                strMySQL = strMySQL & " UPPER(" & objQueryFields(inti) & ") LIKE UPPER('" & strPattern & "') OR "
                            End If
                            strMySQL = strMySQL & "AccessEntry LIKE N'" & EntryPattern & "' OR "
                        Next
                    Else
                        strMySQL = strMySQL & "1 = 1 OR"
                    End If
                    strMySQL = Left(strMySQL, Len(strMySQL) - 3)
                    strMySQL = strMySQL & ") AND ROWNUM<=" & intTop & " ORDER BY AccessEntry"
                End If
                objBCDBS.SQLStatement = strMySQL
                tblEntries = objBCDBS.RetrieveItemInfor
                ErrorCode = objBCDBS.ErrorCode
                ErrorMsg = objBCDBS.ErrorMsg
                If tblEntries Is Nothing Or tblEntries.Rows.Count <= 0 Then
                    Return (Nothing)
                End If
                intMaxNumber = tblEntries.Rows.Count - 1
                ReDim arrTextField(intMaxNumber)
                ReDim arrValueField(intMaxNumber)
                ReDim Entries(intMaxNumber)
                For inti = 0 To intMaxNumber
                    text = ""
                    val = ""
                    Select Case CInt(tblCatDicList.Rows(0).Item("ID"))
                        Case 14 'CAT_DIC_MEDIUM
                            If Not tblEntries.Rows(inti).Item("Code") & "" = "" Then
                                text = tblEntries.Rows(inti).Item("Code") & " : " & tblEntries.Rows(inti).Item("Description") & ""
                                val = tblEntries.Rows(inti).Item("Code")
                            End If
                        Case Is >= 32 'DICTIONARY34,  DICTIONARY35
                            If Not tblEntries.Rows(inti).Item("Dictionary") & "" = "" Then
                                text = tblEntries.Rows(inti).Item("Dictionary")
                                val = tblEntries.Rows(inti).Item("Dictionary")
                            End If
                        Case 10 'CAT_DIC_LANGUAGE
                            If Not tblEntries.Rows(inti).Item("DisplayEntry") & "" = "" Then
                                text = LCase(tblEntries.Rows(inti).Item("AccessEntry")) & ": " & tblEntries.Rows(inti).Item("DisplayEntry")
                                val = tblEntries.Rows(inti).Item("AccessEntry")
                            End If
                        Case Else
                            If Not tblEntries.Rows(inti).Item("DisplayEntry") & "" = "" Then
                                text = tblEntries.Rows(inti).Item("DisplayEntry")
                                val = tblEntries.Rows(inti).Item("AccessEntry")
                            End If
                    End Select
                    Entries(inti) = text & Chr(9) & val
                Next
                '' objtvComUtf8.Sort: have somethings wrong here ????
                'objtvComUtf8.Sort(Entries, 1)
                Dim EntrParts() As String
                If UBound(Entries) < 0 Then
                    Return (Nothing)
                End If
                For inti = LBound(Entries) To UBound(Entries)
                    EntrParts = Split(Entries(inti), Chr(9))
                    arrTextField(inti) = EntrParts(0) ' Text field
                    arrValueField(inti) = EntrParts(1) ' Value field
                Next
                ' Build table from 2 arrays 
                GetDictionary = objBCDBS.CreateTable(arrTextField, arrValueField)
                ErrorCode = objDOPACDictionary.ErrorCode
                ErrorMsg = objDOPACDictionary.ErrorMsg
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Function

        ' GetCatDicList method
        ' Purpose: Get information of Catdiclist table
        ' Input: intID (optional default=0)
        ' Output: DataTable
        ' Creator: dgsoft
        Public Function GetCatDicList(Optional ByVal intID As Integer = 0) As DataTable
            GetCatDicList = objBCDBS.ConvertTable(objDOPACDictionary.GetCatDicList(intID))
        End Function
        ' GetCatDicList method
        ' Purpose: Get information of Catdiclist table
        ' Input: intID (optional default=0)
        ' Output: DataTable includes two field : Name, ID
        ' Creator: dgsoft2016
        Public Function GetCatDicList2Field(Optional ByVal intID As Integer = 0) As DataTable
            GetCatDicList2Field = objBCDBS.ConvertTable(objDOPACDictionary.GetCatDicList2Field(intID))
        End Function

        ' Purpose: gen array from input string 
        ' Creator: dgsoft2016
        Function LoadArray(ByVal StrInput As String) As Object
            Dim OutArray As Object
            Dim m As Integer
            Dim s As String
            m = 0
            While Len(StrInput) > 0
                ReDim Preserve OutArray(m)
                s = InStr(StrInput, ",")
                If s > 0 Then
                    OutArray(m) = Left(StrInput, s - 1)
                    StrInput = Right(StrInput, Len(StrInput) - s)
                    m = m + 1
                Else
                    OutArray(m) = StrInput
                    StrInput = ""
                End If
            End While
            LoadArray = OutArray
        End Function

        ' Purpose: get Item from dictionary AccessEntry
        ' Input: dictionary AccessEntry
        ' Output: datatable
        ' Created by: PhuongTT
        ' Date : 2014.09.06
        Public Function getItemFromDictionaryAccessEntry(ByVal intItemID As Integer, Optional ByVal intLibID As Integer = 0) As DataTable
            objDOPACDictionary.DicType = DicType
            objDOPACDictionary.AccessEntry = AccessEntry
            getItemFromDictionaryAccessEntry = objDOPACDictionary.getItemFromDictionaryAccessEntry(intItemID, intLibID)
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACDictionary Is Nothing Then
                    Call objDOPACDictionary.Dispose(True)
                    objDOPACDictionary = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace