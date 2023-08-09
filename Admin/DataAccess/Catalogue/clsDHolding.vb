Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue

    Public Class clsDHolding
        Inherits clsDBase

        Private intItemID As Integer = 0
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        Public Function ClearHoldingPrintLabel(ByVal copyNumber As String) As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Try
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = String.Format("UPDATE Lib_tblHolding SET IsLabelPrint=0 WHERE CopyNumber IN({0})",
                                                         String.Join(",", copyNumber.Split(New Char() {";"c}).Select(Function(x) x.Trim()).
                                                         Where(Function(x) x <> "").Select(Function(x) "'" & x & "'"))
                                                         )
                            .CommandType = CommandType.Text
                            Try
                                .ExecuteNonQuery()
                                result = 1
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
            Catch ex As Exception
                Call CloseConnection()
                Throw
            End Try
            Call CloseConnection()
            Return result
        End Function

        Public Function GetHoldingByStatusCode(ByVal statusCode As String) As DataTable
            Dim result As DataTable = Nothing
            Call OpenConnection()
            Try
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Lib_spHolding_GetByStatusCode"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@strStatusCode", SqlDbType.VarChar, 100)).Value = statusCode
                            Try
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                result = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
            Catch ex As Exception
                result = Nothing
            End Try
            Call CloseConnection()
            Return result
        End Function

        Public Function GetHoldingDate(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_GetDate"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 10)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 10)).Value = strDateTo
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingDate = dsData.Tables("tblResult")
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

        Public Function GetHoldingLocationName(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_GetLocationName"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 10)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 10)).Value = strDateTo
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingLocationName = dsData.Tables("tblResult")
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

        Public Function GetHoldingLocationNameAndTotalHoldingInDate(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_GetLocationNameAndTotalHoldingInDate"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 10)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 10)).Value = strDateTo
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHoldingLocationNameAndTotalHoldingInDate = dsData.Tables("tblResult")
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

        Public Function StatCopyNumberAcqSource(ByVal intAcquiredID As Integer, Optional ByVal strAcquiredDateFrom As String = "", Optional ByVal strAcquiredDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spStatCopyNumberAcqSource"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strAcquiredDateFrom", SqlDbType.VarChar, 20)).Value = strAcquiredDateFrom
                        .Parameters.Add(New SqlParameter("@strAcquiredDateTo", SqlDbType.VarChar, 20)).Value = strAcquiredDateTo
                        .Parameters.Add(New SqlParameter("@intAcquiredID", SqlDbType.Int)).Value = intAcquiredID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatCopyNumberAcqSource = dsData.Tables("tblResult")
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

        Public Function StatCopyNumberAcqSourceDetail(ByVal intAcquiredID As Integer, Optional ByVal strAcquiredDateFrom As String = "", Optional ByVal strAcquiredDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spStatCopyNumberAcqSource_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strAcquiredDateFrom", SqlDbType.VarChar, 20)).Value = strAcquiredDateFrom
                        .Parameters.Add(New SqlParameter("@strAcquiredDateTo", SqlDbType.VarChar, 20)).Value = strAcquiredDateTo
                        .Parameters.Add(New SqlParameter("@intAcquiredID", SqlDbType.Int)).Value = intAcquiredID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatCopyNumberAcqSourceDetail = dsData.Tables("tblResult")
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

        Public Function StatCopyNumberCatalogerDetail(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spCataloguer_SelStatTime_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 20)).Value = strDateTo
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatCopyNumberCatalogerDetail = dsData.Tables("tblResult")
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

        Public Function GetContentByCopyNumber(ByVal strCopyNumber As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spHolding_GetContentByCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 33)).Value = strCopyNumber
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetContentByCopyNumber = dsData.Tables("tblResult")
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
