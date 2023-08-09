Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDLoanTypeOther
        Inherits clsDBase

        Private intLoanTypeOtherID As Int16 = 0
        Private dateStart As DateTime = New DateTime
        Private dateEnd As DateTime = New DateTime
        Private dateExpired As DateTime = New DateTime
        Private intLoanTypeID As Int16 = 0

        Public Property LoanTypeOtherID() As Int16
            Get
                Return intLoanTypeOtherID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeOtherID = Value
            End Set
        End Property
        Public Property DateStartLoanType() As DateTime
            Get
                Return dateStart
            End Get
            Set(value As DateTime)
                dateStart = value
            End Set
        End Property
        Public Property DateEndLoanType() As DateTime
            Get
                Return dateEnd
            End Get
            Set(value As DateTime)
                dateEnd = value
            End Set
        End Property
        Public Property DateExpiredLoanType() As DateTime
            Get
                Return dateExpired
            End Get
            Set(value As DateTime)
                dateExpired = value
            End Set
        End Property
        Public Property LoanTypeID() As Int16
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeID = Value
            End Set
        End Property

        Public Function GetListLoanTypeOther() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_GETLOANTYPES"
                    '    .CommandType = CommandType.StoredProcedure
                    '    .Parameters.Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                    '    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '    Try
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetLoanTypes = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoanTypeOther_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetListLoanTypeOther = dsData.Tables("tblResult")
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

        Public Function GetLoanTypeOtherById() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_GETLOANTYPES"
                    '    .CommandType = CommandType.StoredProcedure
                    '    .Parameters.Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                    '    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '    Try
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetLoanTypes = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoanTypeOther_GetById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@id", SqlDbType.Int)).Value = intLoanTypeOtherID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypeOtherById = dsData.Tables("tblResult")
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

        Public Function GetLoanTypeOtherByLoanTypeId() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_GETLOANTYPES"
                    '    .CommandType = CommandType.StoredProcedure
                    '    .Parameters.Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                    '    .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                    '    Try
                    '        oraDataAdapter.SelectCommand = oraCommand
                    '        oraDataAdapter.Fill(dsData, "tblResult")
                    '        GetLoanTypes = dsData.Tables("tblResult")
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
                        .CommandText = "Cir_spLoanTypeOther_GetByLoanTypeId"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@loanTypeId", SqlDbType.Int)).Value = intLoanTypeID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypeOtherByLoanTypeId = dsData.Tables("tblResult")
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

        Public Function CreateLoanTypeOther() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeOther_Insert"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@dateStart", SqlDbType.DateTime)).Value = dateStart
                            .Add(New SqlParameter("@dateEnd", SqlDbType.DateTime)).Value = dateEnd
                            .Add(New SqlParameter("@dateExpired", SqlDbType.DateTime)).Value = dateExpired
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
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
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_CREATELOANTYPE"
                    '    .CommandType = CommandType.StoredProcedure
                    '    With .Parameters
                    '        .Add(New OracleParameter("monFee", OracleType.Float)).Value = dblFee
                    '        .Add(New OracleParameter("intFixedFee", OracleType.Number)).Value = intFixedFee
                    '        .Add(New OracleParameter("intLoanPeriod", OracleType.Number)).Value = bytLoanPeriod
                    '        .Add(New OracleParameter("strLoanType", OracleType.VarChar, 100)).Value = strLoanType
                    '        .Add(New OracleParameter("monOverdueFine", OracleType.Float)).Value = dblOverdueFine
                    '        .Add(New OracleParameter("intRenewalPeriod", OracleType.Number)).Value = bytRenewPeriod
                    '        .Add(New OracleParameter("intRenewals", OracleType.Number)).Value = bytRenewals
                    '        .Add(New OracleParameter("intTimeUnit", OracleType.Number)).Value = bytTimeUnit
                    '        .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                    '    End With
                    '    Try
                    '        .ExecuteNonQuery()
                    '        CreateLoanType = .Parameters("intOut").Value
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
            Return result
        End Function

        Public Function UpdateLoanTypeOther() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeOther_Update"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@id", SqlDbType.Int)).Value = intLoanTypeOtherID
                            .Add(New SqlParameter("@dateStart", SqlDbType.DateTime)).Value = dateStart
                            .Add(New SqlParameter("@dateEnd", SqlDbType.DateTime)).Value = dateEnd
                            .Add(New SqlParameter("@dateExpired", SqlDbType.DateTime)).Value = dateExpired
                            .Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
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
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_CREATELOANTYPE"
                    '    .CommandType = CommandType.StoredProcedure
                    '    With .Parameters
                    '        .Add(New OracleParameter("monFee", OracleType.Float)).Value = dblFee
                    '        .Add(New OracleParameter("intFixedFee", OracleType.Number)).Value = intFixedFee
                    '        .Add(New OracleParameter("intLoanPeriod", OracleType.Number)).Value = bytLoanPeriod
                    '        .Add(New OracleParameter("strLoanType", OracleType.VarChar, 100)).Value = strLoanType
                    '        .Add(New OracleParameter("monOverdueFine", OracleType.Float)).Value = dblOverdueFine
                    '        .Add(New OracleParameter("intRenewalPeriod", OracleType.Number)).Value = bytRenewPeriod
                    '        .Add(New OracleParameter("intRenewals", OracleType.Number)).Value = bytRenewals
                    '        .Add(New OracleParameter("intTimeUnit", OracleType.Number)).Value = bytTimeUnit
                    '        .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                    '    End With
                    '    Try
                    '        .ExecuteNonQuery()
                    '        CreateLoanType = .Parameters("intOut").Value
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
            End Select
            Call CloseConnection()
            Return result
        End Function

        Public Function DeleteLoanTypeOther() As Integer
            Dim result As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanTypeOther_Delete"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@id", SqlDbType.Int)).Value = intLoanTypeOtherID
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
                    'With oraCommand
                    '    .CommandText = "CIRCULATION.SP_CREATELOANTYPE"
                    '    .CommandType = CommandType.StoredProcedure
                    '    With .Parameters
                    '        .Add(New OracleParameter("monFee", OracleType.Float)).Value = dblFee
                    '        .Add(New OracleParameter("intFixedFee", OracleType.Number)).Value = intFixedFee
                    '        .Add(New OracleParameter("intLoanPeriod", OracleType.Number)).Value = bytLoanPeriod
                    '        .Add(New OracleParameter("strLoanType", OracleType.VarChar, 100)).Value = strLoanType
                    '        .Add(New OracleParameter("monOverdueFine", OracleType.Float)).Value = dblOverdueFine
                    '        .Add(New OracleParameter("intRenewalPeriod", OracleType.Number)).Value = bytRenewPeriod
                    '        .Add(New OracleParameter("intRenewals", OracleType.Number)).Value = bytRenewals
                    '        .Add(New OracleParameter("intTimeUnit", OracleType.Number)).Value = bytTimeUnit
                    '        .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                    '    End With
                    '    Try
                    '        .ExecuteNonQuery()
                    '        CreateLoanType = .Parameters("intOut").Value
                    '    Catch OraEx As OracleException
                    '        strErrorMsg = OraEx.Message.ToString
                    '        intErrorCode = OraEx.Code
                    '    Finally
                    '        .Parameters.Clear()
                    '    End Try
                    'End With
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
