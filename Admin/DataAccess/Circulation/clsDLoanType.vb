Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDLoanType
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private intLoanTypeID As Int16 = 0
        Private dblOverdueFine As Double = 0
        Private dblFee As Double = 0
        Private intFixedFee As Integer = 0
        Private strLoanType As String = ""
        Private bytTimeUnit As Integer = 0
        Private bytRenewals As Integer = 0
        Private bytRenewPeriod As Integer = 0
        Private bytLoanPeriod As Integer = 0
        Private strGroupLoanTypeIDs As String = ""
        Private strLoanTypeCode As String = ""
        Private strPatronGroupIDs As String = ""
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        Public Property PatronGroupIDs() As String
            Get
                Return strPatronGroupIDs
            End Get
            Set(ByVal Value As String)
                strPatronGroupIDs = Value
            End Set
        End Property

        'strGroupLoanTypeIDs
        Public Property GroupLoanTypeIDs() As String
            Get
                Return strGroupLoanTypeIDs
            End Get
            Set(ByVal Value As String)
                strGroupLoanTypeIDs = Value
            End Set
        End Property

        ' LoanTypeID property
        Public Property LoanTypeID() As Int16
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeID = Value
            End Set
        End Property

        ' OverdueFine property
        Public Property OverdueFine() As Double
            Get
                Return dblOverdueFine
            End Get
            Set(ByVal Value As Double)
                dblOverdueFine = Value
            End Set
        End Property

        ' Fee property
        Public Property Fee() As Double
            Get
                Return dblFee
            End Get
            Set(ByVal Value As Double)
                dblFee = Value
            End Set
        End Property

        ' FixedFee property
        Public Property FixedFee() As Integer
            Get
                Return intFixedFee
            End Get
            Set(ByVal Value As Integer)
                intFixedFee = Value
            End Set
        End Property

        ' LoanType property
        Public Property LoanType() As String
            Get
                Return strLoanType
            End Get
            Set(ByVal Value As String)
                strLoanType = Value
            End Set
        End Property

        ' TimeUnit property
        Public Property TimeUnit() As Integer
            Get
                Return bytTimeUnit
            End Get
            Set(ByVal Value As Integer)
                bytTimeUnit = Value
            End Set
        End Property

        ' Renewals property
        Public Property Renewals() As Integer
            Get
                Return bytRenewals
            End Get
            Set(ByVal Value As Integer)
                bytRenewals = Value
            End Set
        End Property

        ' RenewPeriod property
        Public Property RenewPeriod() As Integer
            Get
                Return bytRenewPeriod
            End Get
            Set(ByVal Value As Integer)
                bytRenewPeriod = Value
            End Set
        End Property

        ' LoanPeriod property
        Public Property LoanPeriod() As Integer
            Get
                Return bytLoanPeriod
            End Get
            Set(ByVal Value As Integer)
                bytLoanPeriod = Value
            End Set
        End Property

        ' LoanTypeCode property
        Public Property LoanTypeCode() As String
            Get
                Return strLoanTypeCode
            End Get
            Set(ByVal Value As String)
                strLoanTypeCode = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetLoanTypes method
        ' Purpose: Get LoanType information
        ' Input: LoanTypeID
        ' Output: datatable result
        Public Function GetLoanTypes() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GETLOANTYPES"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intLoanTypeID", OracleType.Number)).Value = intLoanTypeID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypes = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spLoanType_SelById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intLoanTypeID", SqlDbType.Int)).Value = intLoanTypeID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypes = dsData.Tables("tblResult")
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
        Public Function GetLoanTypesByLoanTypeCode() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spLoanType_SelByLoanTypeCode"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strLoanTypeCode", SqlDbType.VarChar, 50)).Value = strLoanTypeCode
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetLoanTypesByLoanTypeCode = dsData.Tables("tblResult")
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

        Public Function GetTotal_HoldingCopies(Optional ByVal intUserID As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spHolding_SelTotalHoldingCopies"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblHoldingCopies")
                            GetTotal_HoldingCopies = dsData.Tables("tblHoldingCopies")
                            dsData.Tables.Remove("tblHoldingCopies")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_GETTOTAL_HOLDINGCOPIES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblHoldingCopies")
                            GetTotal_HoldingCopies = dsData.Tables("tblHoldingCopies")
                            dsData.Tables.Remove("tblHoldingCopies")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function CreateLoanType() As Integer
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spLoanType_Ins"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@monFee", SqlDbType.Money)).Value = dblFee
                            .Add(New SqlParameter("@intFixedFee", SqlDbType.Int)).Value = intFixedFee
                            .Add(New SqlParameter("@intLoanPeriod", SqlDbType.Int)).Value = bytLoanPeriod
                            .Add(New SqlParameter("@strLoanType", SqlDbType.NVarChar, 100)).Value = strLoanType
                            .Add(New SqlParameter("@strLoanTypeCode", SqlDbType.NVarChar, 50)).Value = strLoanTypeCode
                            .Add(New SqlParameter("@monOverdueFine", SqlDbType.Money)).Value = dblOverdueFine
                            .Add(New SqlParameter("@intRenewalPeriod", SqlDbType.Int)).Value = bytRenewPeriod
                            .Add(New SqlParameter("@intRenewals", SqlDbType.Int)).Value = bytRenewals
                            .Add(New SqlParameter("@intTimeUnit", SqlDbType.Int)).Value = bytTimeUnit
                            .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Add(New SqlParameter("@strPatronGroupIDs", SqlDbType.VarChar, 100)).Value = strPatronGroupIDs
                            .Add(New SqlParameter("@intOut", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            CreateLoanType = .Parameters("@intOut").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CREATELOANTYPE"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("monFee", OracleType.Float)).Value = dblFee
                            .Add(New OracleParameter("intFixedFee", OracleType.Number)).Value = intFixedFee
                            .Add(New OracleParameter("intLoanPeriod", OracleType.Number)).Value = bytLoanPeriod
                            .Add(New OracleParameter("strLoanType", OracleType.VarChar, 100)).Value = strLoanType
                            .Add(New OracleParameter("monOverdueFine", OracleType.Float)).Value = dblOverdueFine
                            .Add(New OracleParameter("intRenewalPeriod", OracleType.Number)).Value = bytRenewPeriod
                            .Add(New OracleParameter("intRenewals", OracleType.Number)).Value = bytRenewals
                            .Add(New OracleParameter("intTimeUnit", OracleType.Number)).Value = bytTimeUnit
                            .Add(New OracleParameter("intOut", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            CreateLoanType = .Parameters("intOut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Sub UpdateLoanType()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spLoanType_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intLoanTypeID
                            .Add(New SqlParameter("@monFee", SqlDbType.Money)).Value = dblFee
                            .Add(New SqlParameter("@intFixedFee", SqlDbType.Int)).Value = intFixedFee
                            .Add(New SqlParameter("@intLoanPeriod", SqlDbType.Int)).Value = bytLoanPeriod
                            .Add(New SqlParameter("@strLoanType", SqlDbType.NVarChar, 100)).Value = strLoanType
                            .Add(New SqlParameter("@strLoanTypeCode", SqlDbType.NVarChar, 50)).Value = strLoanTypeCode
                            .Add(New SqlParameter("@monOverdueFine", SqlDbType.Money)).Value = dblOverdueFine
                            .Add(New SqlParameter("@intRenewalPeriod", SqlDbType.Int)).Value = bytRenewPeriod
                            .Add(New SqlParameter("@intRenewals", SqlDbType.Int)).Value = bytRenewals
                            .Add(New SqlParameter("@intTimeUnit", SqlDbType.Int)).Value = bytTimeUnit
                            .Add(New SqlParameter("@strPatronGroupIDs", SqlDbType.VarChar, 100)).Value = strPatronGroupIDs
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_UPDATELOANTYPE"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intLoanTypeID
                            .Add(New OracleParameter("monFee", OracleType.Float)).Value = dblFee
                            .Add(New OracleParameter("intFixedFee", OracleType.Number)).Value = intFixedFee
                            .Add(New OracleParameter("intLoanPeriod", OracleType.Number)).Value = bytLoanPeriod
                            .Add(New OracleParameter("strLoanType", OracleType.VarChar, 100)).Value = strLoanType
                            .Add(New OracleParameter("monOverdueFine", OracleType.Float)).Value = dblOverdueFine
                            .Add(New OracleParameter("intRenewalPeriod", OracleType.Number)).Value = bytRenewPeriod
                            .Add(New OracleParameter("intRenewals", OracleType.Number)).Value = bytRenewals
                            .Add(New OracleParameter("intTimeUnit", OracleType.Number)).Value = bytTimeUnit
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Sub MergeLoanType()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spLoanType_Merge"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strGroupLoanTypeID", SqlDbType.VarChar, 1000)).Value = strGroupLoanTypeIDs
                            .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intLoanTypeID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_MERGELOANTYPE"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strGroupLoanTypeID", OracleType.VarChar, 1000)).Value = strGroupLoanTypeIDs
                            .Add(New OracleParameter("intID", OracleType.Number)).Value = intLoanTypeID
                        End With
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        ' DeleteLoanType method
        ' Purpose: delete information of the selected LoanType
        ' Input: intLoanTypeID
        Public Sub DeleteLoanType()
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

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