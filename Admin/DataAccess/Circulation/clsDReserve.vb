Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDReserve
        Inherits clsDBase

        Protected intItemID As Integer = 0
        Protected strPatronCode As String = ""
        Protected intID As Integer = 0

        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
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

        Public Function GetReserve() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    GetReserve = New DataTable("tblResult")
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_tblReserve_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetReserve = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            GetReserve = New DataTable("tblResult")
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function InsertReserve() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    InsertReserve = -1
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_tblReserve_Insert"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@intItemId", SqlDbType.Int)).Value = intItemID
                        .Parameters.Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            InsertReserve = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            InsertReserve = -1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function DeleteReserve() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    DeleteReserve = 0
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_tblReserve_Del"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                        Try
                            .ExecuteNonQuery()
                            DeleteReserve = 1
                        Catch ex As SqlException
                            DeleteReserve = 0
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        Public Function DeleteReserve(ByVal strIDs As String) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    DeleteReserve = 0
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_tblReserve_DelByIDs"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strIds", SqlDbType.Int)).Value = strIDs
                        Try
                            .ExecuteNonQuery()
                            DeleteReserve = 1
                        Catch ex As SqlException
                            DeleteReserve = 0
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function FillReserve(ByVal intTypeReserve As Integer, ByVal intTypeSearch As Integer, Optional ByVal strSearch As String = "", Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    FillReserve = New DataTable("tblResult")
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_tblReserve_Fill"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intTypeReserve", SqlDbType.Int)).Value = intTypeReserve
                        .Parameters.Add(New SqlParameter("@intTypeSearch", SqlDbType.Int)).Value = intTypeSearch
                        .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                        .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 20)).Value = strDateTo
                        .Parameters.Add(New SqlParameter("@strSearch", SqlDbType.VarChar)).Value = strSearch
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            FillReserve = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex As SqlException
                            FillReserve = New DataTable("tblResult")
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function FillReserveReport(Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Call OpenConnection()
            With sqlCommand
                .CommandText = "Cir_tblReserveReport_Fill"
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 20)).Value = strDateFrom
                .Parameters.Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 20)).Value = strDateTo
                Try
                    sqlDataAdapter.SelectCommand = sqlCommand
                    sqlDataAdapter.Fill(dsData, "tblResult")
                    FillReserveReport = dsData.Tables("tblResult")
                    dsData.Tables.Remove("tblResult")
                Catch ex As SqlException
                    FillReserveReport = New DataTable("tblResult")
                    intErrorCode = ex.Number
                    strErrorMsg = ex.Message.ToString
                Finally
                    .Parameters.Clear()
                End Try
            End With
            Call CloseConnection()
        End Function
    End Class
End Namespace
