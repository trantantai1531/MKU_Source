' Name: clsDReservationTransaction
' Purpose: allow manage ReservationTransactions
' Creator: Tuanhv
' CreatedDate: 26/08/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDReservationTransaction
        Inherits clsDBaseTransaction

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************
        Private strCRR_ID As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' CRR_ID property
        Public Property CRR_ID() As String
            Get
                Return CRR_ID
            End Get
            Set(ByVal Value As String)
                strCRR_ID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetReservationPatronInfor method
        ' Purpose: Get information of ReservationTransactions
        ' Input:
        ' Output: datatable result
        Public Function GetReservationPatronInfor(Optional ByVal intType As Int16 = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_NAME_REQUEST"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number, 6)).Value = intUserID
                        .Parameters.Add(New OracleParameter("intType", OracleType.Number, 6)).Value = intType
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetReservationInfor")
                            GetReservationPatronInfor = dsData.Tables("tblGetReservationInfor")
                            dsData.Tables.Remove("tblGetReservationInfor")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelNameRequest"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetReservationInfor")
                            GetReservationPatronInfor = dsData.Tables("tblGetReservationInfor")
                            dsData.Tables.Remove("tblGetReservationInfor")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        '
        Public Function GetReservationPatronByTime(Optional ByVal intType As Int16 = 0,Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_SelNameRequest"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetReservationInfor")
                            GetReservationPatronByTime = dsData.Tables("tblGetReservationInfor")
                            dsData.Tables.Remove("tblGetReservationInfor")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        '
        Public Function GetReservation_ReportByTime(Optional ByVal intType As Int16 = 0, Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
                    With sqlCommand
                .CommandText = "Cir_GetReservation_Report"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.NVarChar)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.NVarChar)).Value = strDateTo
                        Try
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblGetReservationReport")
                    GetReservation_ReportByTime = dsData.Tables("tblGetReservationReport")
                    dsData.Tables.Remove("tblGetReservationReport")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            Call CloseConnection()
        End Function
        Public Function GetResereAll(Optional ByVal intType As Int16 = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatron_SelReserveAll"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblGetReservationInfor")
                            GetResereAll = dsData.Tables("tblGetReservationInfor")
                            dsData.Tables.Remove("tblGetReservationInfor")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        ' GetReservationCopynumberInfor method
        ' Purpose: Lấy các thông tin về đăng ký cá biệt của ấn phẩm.
        ' Input:
        ' Output: datatable result
        Public Function GetReservationInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GET_PATRON_COPYNUMBERS"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number, 6)).Value = intUserID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetReservationInfor")
                            GetReservationInfor = dsData.Tables("tblGetReservationInfor")
                            dsData.Tables.Remove("tblGetReservationInfor")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelCopyNumber"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetReservationInfor")
                            GetReservationInfor = dsData.Tables("tblGetReservationInfor")
                            dsData.Tables.Remove("tblGetReservationInfor")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' RemoveReservation() method
        ' Purpose: Xoa thong tin mot tap yeu cau dat muon tu hang doi
        ' Input:
        ' Output: datatable result
        Public Function RemoveReservation()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_RESERVE_REQUEST_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strCRR_ID", OracleType.VarChar, 200)).Value = strCRR_ID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spReserveRequestDelete"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strCRR_ID", SqlDbType.VarChar, 200)).Value = strCRR_ID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function RemoveHoldTransaction()
            Call OpenConnection()                            
                    With sqlCommand
                        .CommandText = "Cir_spHoldTransactionDelete"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strCRR_ID", SqlDbType.VarChar, 200)).Value = strCRR_ID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
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
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlDataAdapter Is Nothing Then
                        SqlDataAdapter.Dispose()
                        SqlDataAdapter = Nothing
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
