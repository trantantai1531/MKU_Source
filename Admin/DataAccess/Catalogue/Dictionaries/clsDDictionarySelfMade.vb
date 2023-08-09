Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType
Imports eMicLibAdmin.DataAccess

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDDictionarySelfMade
        Inherits clsDBase

        Private strTableName As String
        Private strFieldCode As String
        Private strFieldName As String
        Private intID As Integer
        Private strDictionary As String
        Private strAccessEntry As String
        Private intDicID As Integer
        Private strFieldID As String
        Private strContent As String
        Private intForPatron As Integer
        Private intForStaff As Integer
        Private intFieldSize As Integer
        Private strNameDic As String
        Private intItemID As Integer
        Private intIDNew As Integer
        Private strIDMerge As String

        Public Property IDNew() As Integer
            Get
                Return intIDNew
            End Get
            Set(ByVal Value As Integer)
                intIDNew = Value
            End Set
        End Property

        Public Property IDMerge() As String
            Get
                Return strIDMerge
            End Get
            Set(ByVal Value As String)
                strIDMerge = Value
            End Set
        End Property

        Public Property TableName() As String
            Get
                Return strTableName
            End Get
            Set(ByVal Value As String)
                strTableName = Value
            End Set
        End Property

        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        Public Property FieldName() As String
            Get
                Return strFieldName
            End Get
            Set(ByVal Value As String)
                strFieldName = Value
            End Set
        End Property

        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        Public Property Dictionary() As String
            Get
                Return strDictionary
            End Get
            Set(ByVal Value As String)
                strDictionary = Value
            End Set
        End Property

        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        Public Property DicID() As Integer
            Get
                Return intDicID
            End Get
            Set(ByVal Value As Integer)
                intDicID = Value
            End Set
        End Property

        Public Property FieldID() As String
            Get
                Return strFieldID
            End Get
            Set(ByVal Value As String)
                strFieldID = Value
            End Set
        End Property

        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property

        Public Property ForPatron() As Integer
            Get
                Return intForPatron
            End Get
            Set(ByVal Value As Integer)
                intForPatron = Value
            End Set
        End Property

        Public Property ForStaff() As Integer
            Get
                Return intForStaff
            End Get
            Set(ByVal Value As Integer)
                intForStaff = Value
            End Set
        End Property

        Public Property FieldSize()
            Get
                Return intFieldSize
            End Get
            Set(ByVal Value)
                intFieldSize = Value
            End Set
        End Property

        Public Property NameDic() As String
            Get
                Return strNameDic
            End Get
            Set(ByVal Value As String)
                strNameDic = Value
            End Set
        End Property

        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' Method: UpdateEntry
        ' Purpose: Update information of the selected entry
        ' Input: some main infor
        Public Sub UpdateEntry()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spDic_UpdEntry"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@strDictionary", SqlDbType.NVarChar, 1000)).Value = strDictionary
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 1000)).Value = strAccessEntry
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_UPDATE_ENTRY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("strDictionary", OracleType.VarChar, 1000)).Value = strDictionary
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 1000)).Value = strAccessEntry
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: RemoveAllEntries
        ' Purpose: Remove all entries of the selected dictionary
        ' Input: Name of dictionary, fielcode
        Public Sub RemoveAllEntries()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spRemoveAllEntries"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTableName", SqlDbType.VarChar, 100)).Value = strTableName
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CATA_REMOVEALL_ENTRIES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTableName", OracleType.VarChar, 100)).Value = strTableName
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub
        Private Function GetQueryEntry(ByVal strSql As String) As DataTable
            With SqlCommand
                .CommandText = strSql
                .CommandType = CommandType.Text
                Try
                    SqlDataAdapter.SelectCommand = SqlCommand
                    SqlDataAdapter.Fill(dsdata, "QueryEntry")
                    GetQueryEntry = dsdata.Tables("QueryEntry")
                    dsdata.Tables.Remove("QueryEntry")
                Catch ex As SqlException
                    strErrorMsg = ex.Message.ToString
                    intErrorCode = ex.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Function
        Private Sub ExecuteEntry(ByVal strSql As String)
            With SqlCommand
                .CommandText = strSql
                .CommandType = CommandType.Text
                Try
                    .ExecuteNonQuery()
                Catch ex As SqlException
                    strErrorMsg = ex.Message.ToString
                    intErrorCode = ex.Number
                Finally
                    .Parameters.Clear()
                End Try
            End With

        End Sub
        ' Method: CreateEntry
        ' Purpose: New entry of selected dictionary
        Public Function CreateEntry() As Integer
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    Try
                        Dim strSql As String
                        Dim tblTempEntry As DataTable
                        strSql = "SELECT ID FROM " & strTableName & " WHERE AccessEntry=N'" & strAccessEntry & "'"
                        tblTempEntry = Me.GetQueryEntry(strSql)
                        If tblTempEntry.Rows.Count > 0 Then
                            CreateEntry = tblTempEntry.Rows(0).Item("ID")
                        Else
                            strSql = "SELECT ISNULL(MAX(ID),0)+1 as ID FROM " & strTableName
                            tblTempEntry = Me.GetQueryEntry(strSql)
                            CreateEntry = tblTempEntry.Rows(0).Item("ID")
                            strSql = "INSERT INTO " & strTableName & " (ID,Dictionary,AccessEntry) VALUES(" & CreateEntry & ",N'" & strDictionary & "',N'" & strAccessEntry & "')"
                            ExecuteEntry(strSql)
                        End If
                    Catch ex As Exception

                    End Try
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.Cat_spCreateEntry"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strTableName", OracleType.VarChar, 100)).Value = strTableName
                                .Add(New OracleParameter("strDictionary", OracleType.VarChar, 1000)).Value = strDictionary
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 1000)).Value = strAccessEntry
                                .Add(New OracleParameter("intIDOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateEntry = .Parameters("intIDOutPut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Insert_Item_Dic
        Public Sub Insert_Item_Dic()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_Dictionary_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strTableName", SqlDbType.VarChar, 100)).Value = strTableName
                                .Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode
                                .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_ITEM_DICTIONARY_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("strTableName", OracleType.VarChar, 100)).Value = strTableName
                                .Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                                .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                            End With
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: GetNextID
        ' Purpose: Get new ID of the selected table
        Public Function GetNextID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spSelMaxId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTableName", SqlDbType.VarChar, 100)).Value = strTableName
                            .Parameters.Add(New SqlParameter("@strFieldID", SqlDbType.VarChar, 100)).Value = strFieldID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetNextID = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CREATED_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTableName", OracleType.VarChar, 100)).Value = strTableName
                            .Parameters.Add(New OracleParameter("strFieldID", OracleType.VarChar, 100)).Value = strFieldID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetNextID = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Retrieve_Source_Dic
        Public Function Retrieve_Source_Dic() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spReadSourceDictionary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strLabelField", SqlDbType.VarChar, 10)).Value = strFieldCode
                                .Add(New SqlParameter("@strFieldName", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@strTableName", SqlDbType.VarChar, 100)).Direction = ParameterDirection.Output
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "SOURCE_DICTIONARY")
                            Retrieve_Source_Dic = dsdata.Tables("SOURCE_DICTIONARY")
                            strFieldName = .Parameters("@strFieldName").Value
                            strTableName = .Parameters("@strTableName").Value
                            dsdata.Tables.Remove("SOURCE_DICTIONARY")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_READ_SOURCE_DICTIONAY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strLabelField", OracleType.VarChar, 10)).Value = strFieldCode
                                .Add(New OracleParameter("strFieldName", OracleType.VarChar, 100)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("strTableName", OracleType.VarChar, 100)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "SOURCE_DICTIONARY")
                            Retrieve_Source_Dic = dsdata.Tables("SOURCE_DICTIONARY")
                            strFieldName = .Parameters("strFieldName").Value
                            strTableName = .Parameters("strTableName").Value
                            dsdata.Tables.Remove("SOURCE_DICTIONARY")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: Retrieve_Source_Dic_byVal
        Public Function Retrieve_Source_Dic_byVal() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spReadSourceDicByVal"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strValue", SqlDbType.NVarChar, 1000)).Value = strContent
                                .Add(New SqlParameter("@strFieldName", SqlDbType.VarChar, 100)).Value = strFieldName
                                .Add(New SqlParameter("@strTableName", SqlDbType.VarChar, 100)).Value = strTableName
                            End With
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "SOURCE_DICTIONARY_VAL")
                            Retrieve_Source_Dic_byVal = dsdata.Tables("SOURCE_DICTIONARY_VAL")
                            dsdata.Tables.Remove("SOURCE_DICTIONARY_VAL")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_READ_SOURCE_DIC_BYVAL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strValue", OracleType.VarChar, 1000)).Value = strContent
                                .Add(New OracleParameter("strFieldName", OracleType.VarChar, 100)).Value = strFieldName
                                .Add(New OracleParameter("strTableName", OracleType.VarChar, 100)).Value = strTableName
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "SOURCE_DICTIONARY_VAL")
                            Retrieve_Source_Dic_byVal = dsdata.Tables("SOURCE_DICTIONARY_VAL")
                            dsdata.Tables.Remove("SOURCE_DICTIONARY_VAL")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: ChangeDic
        ' Purpose: Modify information of the selected index (rename, reindex...)
        ' Input: Some main informations
        ' Output: int value
        Public Function ChangeDic() As Integer
            Call OpenConnection()

            Dim intRET As Integer
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_tblDic_RenameDictionary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@strNewName", SqlDbType.NVarChar, 100)).Value = strTableName
                                .Add(New SqlParameter("@intNewForPatron", SqlDbType.Int)).Value = intForPatron
                                .Add(New SqlParameter("@intNewForStaff", SqlDbType.Int)).Value = intForStaff
                                .Add(New SqlParameter("@intNewFieldSize", SqlDbType.Int)).Value = intFieldSize
                                .Add(New SqlParameter("@intRET", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRET = .Parameters("@intRET").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CATA_RENAME_DICTIONARY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("strNewName", OracleType.VarChar, 100)).Value = strTableName
                                .Add(New OracleParameter("intNewForPatron", OracleType.Number)).Value = intForPatron
                                .Add(New OracleParameter("intNewForStaff", OracleType.Number)).Value = intForStaff
                                .Add(New OracleParameter("intNewFieldSize", OracleType.Number)).Value = intFieldSize
                                .Add(New OracleParameter("intRET", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRET = .Parameters("intRET").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            ChangeDic = intRET
            Call CloseConnection()
        End Function

        ' CreateDictionary method
        ' Purpose: Create dictionary
        ' Input: some main informations
        ' Output: int value
        Public Function CreateDictionary() As Integer
            Call OpenConnection()
            Dim intRET As Integer
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spDictionary_CreateTable"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 50)).Value = strNameDic
                                .Add(New SqlParameter("@intFieldSize", SqlDbType.Int)).Value = intFieldSize
                                .Add(New SqlParameter("@intForPatron", SqlDbType.Int)).Value = intForPatron
                                .Add(New SqlParameter("@intForStaff", SqlDbType.Int)).Value = intForStaff
                                .Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intRET", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRET = .Parameters("@intRET").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CATA_CREATE_DICTIONARY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strName", OracleType.VarChar, 50)).Value = strNameDic
                                .Add(New OracleParameter("intFieldSize", OracleType.Number)).Value = intFieldSize
                                .Add(New OracleParameter("intForPatron", OracleType.Number)).Value = intForPatron
                                .Add(New OracleParameter("intForStaff", OracleType.Number)).Value = intForStaff
                                .Add(New OracleParameter("intRET", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRET = .Parameters("intRET").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            CreateDictionary = intRET
            Call CloseConnection()
        End Function

        ' DropDictionary method
        ' Purpose: drop dictionary table
        ' Input: ID of the dictionary
        Public Sub DropDictionary()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spDicList_DelDictionary"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CATA_DROP_DICTIONARY"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Function Retrieve_Table_By_FieldCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spMARCBibField_SelFieldCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFielsCode", SqlDbType.VarChar, 5)).Value = strFieldCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            Retrieve_Table_By_FieldCode = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CATA_FIELDCODE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFielsCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            Retrieve_Table_By_FieldCode = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetEntries method
        ' Purpose: Get list of entries
        ' Input: DicID, AccessEntry
        ' Output: datatable result
        Public Function GetEntries() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spDictionary_SelSelfMade"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 300)).Value = strAccessEntry
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetEntries = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CATA_DICSELFMADE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 300)).Value = strAccessEntry
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetEntries = dsdata.Tables("tblResult")
                            dsdata.Tables.Remove("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Method: MergeEntries
        ' Purpose: merge some entries
        ' Input: some main information
        Public Sub MergeEntries()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_tblDic_MergeEntries"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                            .Parameters.Add(New SqlParameter("@strIDMerge", SqlDbType.VarChar, 4000)).Value = strIDMerge
                            .Parameters.Add(New SqlParameter("@intIDNew", SqlDbType.Int)).Value = intIDNew
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CATA_MERGE_ENTRIES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                            .Parameters.Add(New OracleParameter("strIDMerge", OracleType.VarChar, 4000)).Value = strIDMerge
                            .Parameters.Add(New OracleParameter("intIDNew", OracleType.Number)).Value = intIDNew
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: SetDicIDForField
        ' Purpose: Set DicID for the selected field
        ' Input: DicID, FieldCode
        Public Function SetDicIDForField()
            Call OpenConnection()
            Select Case UCase(strDBserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spMARCBibField_UpdDicId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intDicID
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 1000)).Value = strFieldCode
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oracommand
                        .CommandText = "CATALOGUE.SP_CATA_SET_DICID_FOR_FIELD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intDicID", OracleType.Number)).Value = intDicID
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace