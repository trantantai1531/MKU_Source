Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACFilterBrowse
        Inherits clsDBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intIDDic As Integer
        Private intID As Integer
        Private intItemID As Integer
        Private strIds As String
        Private strWords As String

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
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
        Public Property DicID() As Integer
            Get
                Return intIDDic
            End Get
            Set(ByVal Value As Integer)
                intIDDic = Value
            End Set
        End Property
        Public Property IDs() As String
            Get
                Return strIds
            End Get
            Set(ByVal Value As String)
                strIds = Value
            End Set
        End Property
        Public Property Words() As String
            Get
                Return strWords
            End Get
            Set(ByVal Value As String)
                strWords = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' IMPLEMENT METHODS HERE
        ' *************************************************************************************************

        ' Purpose: Get information depend on @strWord input and intIDDIc
        ' Input: intIDDic, @strWord
        ' Output: Datatable 
        ' Created by: PhuongTT - 2014.09.08
        Public Function GetAllBrowseByWord(ByVal fieldSort As String, ByVal methodSort As String, ByVal intTop As Integer, Optional ByVal intLibID As Integer = 0) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spBrowseByWord"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intIDDic
                                    .Add(New SqlParameter("@strWord", SqlDbType.NVarChar, 300)).Value = strWords.Trim
                                    .Add(New SqlParameter("@fieldSort", SqlDbType.NVarChar, 50)).Value = fieldSort
                                    .Add(New SqlParameter("@methodSort", SqlDbType.NVarChar, 5)).Value = methodSort
                                    .Add(New SqlParameter("@intTop", SqlDbType.Int)).Value = intTop
                                    .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spBrowseByWord"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intIDDic
                                    .Add(New OracleParameter("strWord", OracleType.NVarChar, 300)).Value = strWords.Trim
                                    .Add(New OracleParameter("fieldSort", OracleType.NVarChar, 50)).Value = fieldSort
                                    .Add(New OracleParameter("methodSort", OracleType.NVarChar, 5)).Value = methodSort
                                    .Add(New OracleParameter("intTop", OracleType.Number)).Value = intTop
                                    .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function


        ' Purpose: Get information depend on @strWord input and intIDDIc
        ' Input: intIDDic, @strWord
        ' Output: Datatable 
        ' Created by: PhuongTT - 2014.09.08
        Public Function GetAllBrowseMoreByWord(ByVal fieldSort As String, ByVal methodSort As String, ByVal intTop As Integer) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spBrowseMoreByWord"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intIDDic
                                    .Add(New SqlParameter("@strWord", SqlDbType.NVarChar, 300)).Value = strWords.Trim
                                    .Add(New SqlParameter("@fieldSort", SqlDbType.NVarChar, 50)).Value = fieldSort
                                    .Add(New SqlParameter("@methodSort", SqlDbType.NVarChar, 5)).Value = methodSort
                                    .Add(New SqlParameter("@strIds", SqlDbType.NText)).Value = strIds
                                    .Add(New SqlParameter("@intTop", SqlDbType.Int)).Value = intTop
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spBrowseMoreByWord"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intIDDic
                                    .Add(New OracleParameter("strWord", OracleType.NVarChar, 300)).Value = strWords.Trim
                                    .Add(New OracleParameter("fieldSort", OracleType.NVarChar, 50)).Value = fieldSort
                                    .Add(New OracleParameter("methodSort", OracleType.NVarChar, 5)).Value = methodSort
                                    .Add(New OracleParameter("strIds", OracleType.NVarChar, 4000)).Value = strIds
                                    .Add(New OracleParameter("intTop", OracleType.Number)).Value = intTop
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function


        ' Purpose: Get ItemIDs from Browse
        ' Input: intIDDic, @strIds
        ' Output: Datatable 
        ' Created by: PhuongTT - 2014.11.07
        Public Function GetItemIdsFromBrowse() As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spBrowse_SearchByID"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intIDDic
                                    .Add(New SqlParameter("@strIds", SqlDbType.NVarChar, 30)).Value = strIds.Trim
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spBrowse_SearchByID"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intIDDic
                                    .Add(New OracleParameter("strIds", OracleType.NVarChar, 30)).Value = strIds.Trim
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function


        ' Purpose: Get information depend on @strIds input and intIDDIc
        ' Input: intIDDic, @strIds
        ' Output: Datatable 
        ' Created by: PhuongTT - 2014.09.08
        Public Function GetFilterBrowse(ByVal fieldSort As String, ByVal methodSort As String, ByVal intTop As Integer) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spBrowser_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intIDDic
                                    .Add(New SqlParameter("@strIds", SqlDbType.NText)).Value = strIds.Trim
                                    .Add(New SqlParameter("@fieldSort", SqlDbType.NVarChar, 50)).Value = fieldSort
                                    .Add(New SqlParameter("@methodSort", SqlDbType.NVarChar, 5)).Value = methodSort
                                    .Add(New SqlParameter("@intTop", SqlDbType.Int)).Value = intTop
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spBrowser_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intIDDic
                                    .Add(New OracleParameter("strIds", OracleType.NVarChar, 4000)).Value = strIds.Trim
                                    .Add(New OracleParameter("fieldSort", OracleType.NVarChar, 50)).Value = fieldSort
                                    .Add(New OracleParameter("methodSort", OracleType.NVarChar, 5)).Value = methodSort
                                    .Add(New OracleParameter("intTop", OracleType.Number)).Value = intTop
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function


        ' Purpose: Get information depend on @strIds input and intIDDIc
        ' Input: intIDDic, @strIds
        ' Output: Datatable 
        ' Created by: PhuongTT - 2014.09.08
        Public Function GetFilterBrowseByMerge(ByVal intTop As Integer) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spBrowseMerge_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@strIds", SqlDbType.NText)).Value = strIds.Trim
                                    .Add(New SqlParameter("@intTop", SqlDbType.Int)).Value = intTop
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spBrowseMerge_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("strIds", OracleType.NVarChar, 4000)).Value = strIds.Trim
                                    .Add(New OracleParameter("intTop", OracleType.Number)).Value = intTop
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblFilterBrowse")
                                dtResults = dsData.Tables("tblFilterBrowse")
                                dsData.Tables.Remove("tblFilterBrowse")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function

        Public Function GetFilterBrowseByID() As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spBrowseByID_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intDicID", SqlDbType.Int)).Value = intIDDic
                                    .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                    .Add(New SqlParameter("@strIds", SqlDbType.NText)).Value = strIds.Trim
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblGetFilterBrowseByID")
                                dtResults = dsData.Tables("tblGetFilterBrowseByID")
                                dsData.Tables.Remove("tblGetFilterBrowseByID")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spBrowseByID_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intDicID", OracleType.Number)).Value = intIDDic
                                    .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                    .Add(New OracleParameter("strIds", OracleType.NVarChar, 400)).Value = strIds.Trim
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblGetFilterBrowseByID")
                                dtResults = dsData.Tables("tblGetFilterBrowseByID")
                                dsData.Tables.Remove("tblGetFilterBrowseByID")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function

        ' ' Purpose: Get treeview DDC data
        ' Input: strIds
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.08.27
        Public Function GetTreeviewDDC() As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spDDC_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@strIds", SqlDbType.NText)).Value = strIds.Trim
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblTreeviewDDC")
                                dtResults = dsData.Tables("tblTreeviewDDC")
                                dsData.Tables.Remove("tblTreeviewDDC")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spDDC_Filter"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("strIds", OracleType.NVarChar, 400)).Value = strIds.Trim
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblTreeviewDDC")
                                dtResults = dsData.Tables("tblTreeviewDDC")
                                dsData.Tables.Remove("tblTreeviewDDC")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function


        ' ' Purpose: Get browse for treeview DDC data
        ' Input: strIds
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.11.07
        Public Function GetTBrowseTreeviewDDC(Optional ByVal intLibID As Integer = 0) As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spBrowseByWordForDDC"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@strWord", SqlDbType.NText)).Value = Words.Trim
                                    .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblTreeviewDDC")
                                dtResults = dsData.Tables("tblTreeviewDDC")
                                dsData.Tables.Remove("tblTreeviewDDC")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spBrowseByWordForDDC"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("strWord", OracleType.NVarChar, 400)).Value = Words.Trim
                                    .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblTreeviewDDC")
                                dtResults = dsData.Tables("tblTreeviewDDC")
                                dsData.Tables.Remove("tblTreeviewDDC")
                            Catch ex As OracleException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
            End Try
            Return dtResults
        End Function

        ' getBrowseByCollection method
        ' Purpose: Get collection by parentID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.07
        Public Function getBrowseByCollection() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "Edl.Lib_spItemCollection_SelByParentId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = ID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getBrowseByCollection = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemCollection_SelByParentId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = ID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getBrowseByCollection = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' getRelatedWords method
        ' Purpose: Get dictionary word by itemID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.18
        Public Function getRelatedWords() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "Edl.Opac_spRelatedWord"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getRelatedWords = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spRelatedWord"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getRelatedWords = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function RunQuerySql(ByVal strSql As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "Edl.Opac_spRelatedWord"
                    '    .CommandType = CommandType.StoredProcedure
                    '    Try
                    '        .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                    '        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        getRelatedWords = dsData.Tables("tblResult")
                    '        dsData.Tables.Remove("tblResult")
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spExecQueryString"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strSQL", SqlDbType.NVarChar)).Value = strSql
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            RunQuerySql = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
       
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraConnection Is Nothing Then
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
                    End If
                    If Not sqlDataAdapter Is Nothing Then
                        sqlDataAdapter.Dispose()
                        sqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace

