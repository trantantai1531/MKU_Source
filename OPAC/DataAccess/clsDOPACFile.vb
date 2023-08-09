' Name: clsDOPACFile
' Purpose: 
' Creator: PhuongTT
' Created Date: 2014.09.03
Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACFile
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intItemID As Integer
        Private intFileID As Integer
        Private strWordSearch As String
      
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' FileID property
        Public Property FileID() As Integer
            Get
                Return intFileID
            End Get
            Set(ByVal Value As Integer)
                intFileID = Value
            End Set
        End Property

        ' WordSearch property
        Public Property WordSearch() As String
            Get
                Return strWordSearch
            End Get
            Set(ByVal Value As String)
                strWordSearch = Value
            End Set
        End Property
        

        ' Purpose: get files by ItemID
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT  - 2014.09.03
        Public Function GetFiles() As DataTable
            Dim dtResult As DataTable = Nothing
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spFile_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetFiles")
                            dtResult = dsData.Tables("tblGetFiles")
                            dsData.Tables.Remove("tblGetFiles")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spFile_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetFiles")
                            dtResult = dsData.Tables("tblGetFiles")
                            dsData.Tables.Remove("tblGetFiles")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
            Return dtResult
        End Function

        Public Function GetItemFile() As DataTable
            Dim dtResult As DataTable = Nothing
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spItemFile_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intFileID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetFiles")
                            dtResult = dsData.Tables("tblGetFiles")
                            dsData.Tables.Remove("tblGetFiles")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spFile_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetFiles")
                            dtResult = dsData.Tables("tblGetFiles")
                            dsData.Tables.Remove("tblGetFiles")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
            Return dtResult
        End Function

        ' Purpose: get files by ItemID
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT - 2014.09.03
        Public Function GetFileDetail() As DataTable
            Dim dtResult As DataTable = Nothing
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spFileView_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetFileDetail")
                            dtResult = dsData.Tables("tblGetFileDetail")
                            dsData.Tables.Remove("tblGetFileDetail")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spFileView_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intFileID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetFileDetail")
                            dtResult = dsData.Tables("tblGetFileDetail")
                            dsData.Tables.Remove("tblGetFileDetail")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
            Return dtResult
        End Function


        '  purpose : Update views statistic
        ' IN: ItemID,Weekly,Monthly,Yearly
        ' OUT : boolean
        ' Created by: PhuongTT - 2014.09.04
        Public Function updateViews(ByVal ItemID As Integer, ByVal Weekly As Integer, ByVal Monthly As Integer, ByVal Yearly As Integer) As Boolean
            Dim bolResult As Boolean = False
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spView"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                                    .Add(New SqlParameter("@intWeek", SqlDbType.Int)).Value = Weekly
                                    .Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = Monthly
                                    .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = Yearly
                                End With
                                .ExecuteNonQuery()
                                bolResult = True
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "OPAC.Opac_spView"
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                                    .Add(New OracleParameter("intWeek", OracleType.Number)).Value = Weekly
                                    .Add(New OracleParameter("intMonth", OracleType.Number)).Value = Monthly
                                    .Add(New OracleParameter("intYear", OracleType.Number)).Value = Yearly
                                End With
                                .ExecuteNonQuery()
                                bolResult = True
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
            End Try
            Return bolResult
        End Function


        Public Function updateViews(ByVal ItemID As Integer, ByVal Weekly As Integer, ByVal Monthly As Integer, ByVal Yearly As Integer, ByVal PatronCode As String) As Boolean
            Dim bolResult As Boolean = False
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spView_2"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                                    .Add(New SqlParameter("@intWeek", SqlDbType.Int)).Value = Weekly
                                    .Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = Monthly
                                    .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = Yearly
                                    .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = PatronCode
                                End With
                                .ExecuteNonQuery()
                                bolResult = True
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"

                End Select
                Call CloseConnection()
            Catch ex As Exception
            End Try
            Return bolResult
        End Function
        ' ' Purpose: Get treeview Table of content data
        ' Input: ItemID
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.09.04
        Public Function GetTreeviewTableOfContent() As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spTableOfContent"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblTreeviewTableOfContent")
                                dtResults = dsData.Tables("tblTreeviewTableOfContent")
                                dsData.Tables.Remove("tblTreeviewTableOfContent")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spTableOfContent"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblTreeviewTableOfContent")
                                dtResults = dsData.Tables("tblTreeviewTableOfContent")
                                dsData.Tables.Remove("tblTreeviewTableOfContent")
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


        ' ' Purpose: Get total of record by ItemID
        ' Input: ItemID
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.09.04
        Public Function GetCountFulltext() As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spFulltext_CountByItem"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblGetCountFulltext")
                                dtResults = dsData.Tables("tblGetCountFulltext")
                                dsData.Tables.Remove("tblGetCountFulltext")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spFulltext_CountByItem"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblGetCountFulltext")
                                dtResults = dsData.Tables("tblGetCountFulltext")
                                dsData.Tables.Remove("tblGetCountFulltext")
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


        ' ' Purpose: Get all of page document by fulltext search
        ' Input: word search
        ' Output: Datatable 
        ' Created by: Phuongtt 2014.09.05
        Public Function fulltextWordSearch() As DataTable
            Dim dtResults As DataTable = Nothing
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Opac_spContent_Search"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                                    .Add(New SqlParameter("@strWord", SqlDbType.NVarChar, 1000)).Value = WordSearch
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblfulltextWordSearch")
                                dtResults = dsData.Tables("tblfulltextWordSearch")
                                dsData.Tables.Remove("tblfulltextWordSearch")
                            Catch ex As SqlException
                                strErrorMsg = ex.Message.ToString
                                intErrorCode = ex.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "OPAC.Opac_spContent_Search"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                                    .Add(New OracleParameter("strWord", OracleType.NVarChar, 1000)).Value = WordSearch
                                    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                End With
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblfulltextWordSearch")
                                dtResults = dsData.Tables("tblfulltextWordSearch")
                                dsData.Tables.Remove("tblfulltextWordSearch")
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