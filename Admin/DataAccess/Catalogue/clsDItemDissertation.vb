Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDItemDissertation
        Inherits clsDBase

        Private intItemDissertationID As Int16 = 0
        Private intItemID As Integer = 0
        Private intCountPages As Integer = 0
        Private strNumber As String = ""
        Private intYear As Integer = 0
        Private strPathImage As String = ""
        Private strPathFile As String = ""
        Private strContent As String = ""
        Private strDateFrom As String = ""
        Private strDateTo As String = ""

        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property
        Public Property DateFrom() As String
            Get
                Return strDateFrom
            End Get
            Set(ByVal Value As String)
                strDateFrom = Value
            End Set
        End Property
        Public Property DateTo() As String
            Get
                Return strDateTo
            End Get
            Set(ByVal Value As String)
                strDateTo = Value
            End Set
        End Property
        Public Property ItemDissertationID() As Int16
            Get
                Return intItemDissertationID
            End Get
            Set(ByVal Value As Int16)
                intItemDissertationID = Value
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
        Public Property Number() As String
            Get
                Return strNumber
            End Get
            Set(ByVal Value As String)
                strNumber = Value
            End Set
        End Property
        Public Property CountPages() As Integer
            Get
                Return intCountPages
            End Get
            Set(ByVal Value As Integer)
                intCountPages = Value
            End Set
        End Property

        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property
        Public Property PathImage() As String
            Get
                Return strPathImage
            End Get
            Set(ByVal Value As String)
                strPathImage = Value
            End Set
        End Property
        Public Property PathFile() As String
            Get
                Return strPathFile
            End Get
            Set(ByVal Value As String)
                strPathFile = Value
            End Set
        End Property
        Public Function GetListItemDissertation() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetListItemDissertation = dsData.Tables("tblResult")
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

        Public Function GetItemDissertationById() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intItemDissertationID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertationById = dsData.Tables("tblResult")
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

        Public Function GetItemDissertationByItemId() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetByItemId"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertationByItemId = dsData.Tables("tblResult")
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

        Public Function GetListItemDissertation(Optional ByVal strTitle As String = "", Optional ByVal strNumber As String = "", Optional ByVal intYear As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetListItem"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar)).Value = strTitle
                        .Parameters.Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 50)).Value = strNumber
                        .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetListItemDissertation = dsData.Tables("tblResult")
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

        Public Function GetItemDissertationAll() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetAll"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strContent", SqlDbType.VarChar)).Value = strContent
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.VarChar)).Value = strDateTo
                        .Parameters.Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 50)).Value = strNumber
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertationAll = dsData.Tables("tblResult")
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
        Public Function GetItemDissertationByNumberAndYear() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_GetByNumberAndYear"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                        .Parameters.Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 50)).Value = strNumber
                        .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemDissertationByNumberAndYear = dsData.Tables("tblResult")
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

        Public Function CheckItemDissertationByNumberAndYear() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_CheckByNumberAndYear"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intItemDissertationID
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                        .Parameters.Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 50)).Value = strNumber
                        .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CheckItemDissertationByNumberAndYear = dsData.Tables("tblResult")
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
        '

        Public Function CreateItemDissertation() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_Insert"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                            .Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 50)).Value = strNumber
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Add(New SqlParameter("@strPathImage", SqlDbType.NVarChar)).Value = strPathImage
                            .Add(New SqlParameter("@strPathFile", SqlDbType.NVarChar)).Value = strPathFile
                            .Add(New SqlParameter("@intCountPages", SqlDbType.Int)).Value = intCountPages
                        End With
                        Try
                            .ExecuteNonQuery()
                            result = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            result = -1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
            End Select
            Call CloseConnection()
            Return result
        End Function

        Public Function UpdateItemDissertation() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_Update"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intItemDissertationID
                            .Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                            .Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 50)).Value = strNumber
                            .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Add(New SqlParameter("@strPathImage", SqlDbType.NVarChar)).Value = strPathImage
                            .Add(New SqlParameter("@strPathFile", SqlDbType.NVarChar)).Value = strPathFile
                            .Add(New SqlParameter("@intCountPages", SqlDbType.Int)).Value = intCountPages
                        End With
                        Try
                            .ExecuteNonQuery()
                            result = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            result = -1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
            End Select
            Call CloseConnection()
            Return result
        End Function
        Public Function UpdateItemDissertation_CountPage() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_UpdateCountPage"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intItemDissertationID                          
                            .Add(New SqlParameter("@intCountPages", SqlDbType.Int)).Value = intCountPages
                        End With
                        Try
                            .ExecuteNonQuery()
                            result = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            result = -1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
            End Select
            Call CloseConnection()
            Return result
        End Function
        Public Function DeleteItemDissertation() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemDissertation_Delete"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intItemDissertationID
                        End With
                        Try
                            .ExecuteNonQuery()
                            result = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            result = -1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
            End Select
            Call CloseConnection()
            Return result
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
