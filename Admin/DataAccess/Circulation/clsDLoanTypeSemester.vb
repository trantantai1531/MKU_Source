Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDLoanTypeSemester
        Inherits clsDBase

        Private intLoanTypeSemesterID As Int16 = 0
        Private intSemester As Integer = 0
        Private intDayFrom As Integer = 0
        Private intMonthFrom As Integer = 0
        Private intDayTo As Integer = 0
        Private intMonthTo As Integer = 0
        Private intYearFrom As Integer = 0
        Private intYearTo As Integer = 0


        Public Property LoanTypeSemesterID() As Int16
            Get
                Return intLoanTypeSemesterID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeSemesterID = Value
            End Set
        End Property
        Public Property Semester() As Integer
            Get
                Return intSemester
            End Get
            Set(ByVal Value As Integer)
                intSemester = Value
            End Set
        End Property
        Public Property DayFrom() As Integer
            Get
                Return intDayFrom
            End Get
            Set(ByVal Value As Integer)
                intDayFrom = Value
            End Set
        End Property
        Public Property DayTo() As Integer
            Get
                Return intDayTo
            End Get
            Set(ByVal Value As Integer)
                intDayTo = Value
            End Set
        End Property
        Public Property MonthFrom() As Integer
            Get
                Return intMonthFrom
            End Get
            Set(ByVal Value As Integer)
                intMonthFrom = Value
            End Set
        End Property
        Public Property MonthTo() As Integer
            Get
                Return intMonthTo
            End Get
            Set(ByVal Value As Integer)
                intMonthTo = Value
            End Set
        End Property
        Public Property YearFrom() As Integer
            Get
                Return intYearFrom
            End Get
            Set(ByVal Value As Integer)
                intYearFrom = Value
            End Set
        End Property
        Public Property YearTo() As Integer
            Get
                Return intYearTo
            End Get
            Set(ByVal Value As Integer)
                intYearTo = Value
            End Set
        End Property

        Public Function GetListLoanTypeSemester() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeSemester_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetListLoanTypeSemester = dsData.Tables("tblResult")
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

        Public Function GetLoanTypeSemesterById() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeSemester_GetById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intLoanTypeSemesterID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypeSemesterById = dsData.Tables("tblResult")
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

        Public Function GetLoanTypeSemesterBySemester() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeSemester_GetBySemester"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intSemester", SqlDbType.Int)).Value = intSemester
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypeSemesterBySemester = dsData.Tables("tblResult")
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


        Public Function GetLoanTypeSemesterByIdAndSemester() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeSemester_GetByIdAndSemester"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intLoanTypeSemesterID
                        .Parameters.Add(New SqlParameter("@intSemester", SqlDbType.Int)).Value = intSemester
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypeSemesterByIdAndSemester = dsData.Tables("tblResult")
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
        Public Function CreateLoanTypeSemester() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeSemester_Insert"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intSemester", SqlDbType.Int)).Value = intSemester
                            .Add(New SqlParameter("@intDayFrom", SqlDbType.Int)).Value = intDayFrom
                            .Add(New SqlParameter("@intMonthFrom", SqlDbType.Int)).Value = intMonthFrom
                            .Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                            .Add(New SqlParameter("@intDayTo", SqlDbType.Int)).Value = intDayTo
                            .Add(New SqlParameter("@intMonthTo", SqlDbType.Int)).Value = intMonthTo
                            .Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
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

        Public Function UpdateLoanTypeSemester() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeSemester_Update"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intLoanTypeSemesterID
                            .Add(New SqlParameter("@intSemester", SqlDbType.Int)).Value = intSemester
                            .Add(New SqlParameter("@intDayFrom", SqlDbType.Int)).Value = intDayFrom
                            .Add(New SqlParameter("@intMonthFrom", SqlDbType.Int)).Value = intMonthFrom
                            .Add(New SqlParameter("@intYearFrom", SqlDbType.Int)).Value = intYearFrom
                            .Add(New SqlParameter("@intDayTo", SqlDbType.Int)).Value = intDayTo
                            .Add(New SqlParameter("@intMonthTo", SqlDbType.Int)).Value = intMonthTo
                            .Add(New SqlParameter("@intYearTo", SqlDbType.Int)).Value = intYearTo
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

        Public Function DeleteLoanTypeSemester() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeSemester_Delete"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intLoanTypeSemesterID
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
