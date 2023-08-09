Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDAccounting
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intID As Integer
        Private intPoID As Integer
        Private strCurrency As String
        Private strReason As String
        Private strTransactionDate As String
        Private strInputer As String
        Private intBudgetID As Integer
        Private dblAmount As Double
        Private dblExchangeRate As Double
        Private dblFixedRate As Double
        Private intCommited As Integer
        Private dblBalance As Double
        Private dblRealBalance As Double
        Private dblStartRemain As Double
        Private dblLastBase As Double
        Private intLibID As Integer = 0
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property
        Public Property PoID() As Integer
            Get
                Return intPoID
            End Get
            Set(ByVal Value As Integer)
                intPoID = Value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property
        Public Property Reason() As String
            Get
                Return strReason
            End Get
            Set(ByVal Value As String)
                strReason = Value
            End Set
        End Property
        Public Property TransactionDate() As String
            Get
                Return strTransactionDate
            End Get
            Set(ByVal Value As String)
                strTransactionDate = Value
            End Set
        End Property
        Public Property Inputer() As String
            Get
                Return strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
            End Set
        End Property
        Public Property BudgetID() As Integer
            Get
                Return intBudgetID
            End Get
            Set(ByVal Value As Integer)
                intBudgetID = Value
            End Set
        End Property
        Public Property Amount() As Double
            Get
                Return dblAmount
            End Get
            Set(ByVal Value As Double)
                dblAmount = Value
            End Set
        End Property
        Public Property ExchangeRate() As Double
            Get
                Return dblExchangeRate
            End Get
            Set(ByVal Value As Double)
                dblExchangeRate = Value
            End Set
        End Property
        Public Property FixedRate() As Double
            Get
                Return dblFixedRate
            End Get
            Set(ByVal Value As Double)
                dblFixedRate = Value
            End Set
        End Property
        Public Property Commited() As Integer
            Get
                Return intCommited
            End Get
            Set(ByVal Value As Integer)
                intCommited = Value
            End Set
        End Property

        Public Property Balance() As Double
            Get
                Return (dblBalance)
            End Get
            Set(ByVal Value As Double)
                dblBalance = Value
            End Set
        End Property
        Public Property RealBalance() As Double
            Get
                Return (dblRealBalance)
            End Get
            Set(ByVal Value As Double)
                dblRealBalance = Value
            End Set
        End Property

        Public Property StartRemain() As Double
            Get
                Return (dblStartRemain)
            End Get
            Set(ByVal Value As Double)
                dblStartRemain = Value
            End Set
        End Property

        Public Property LastBase() As Double
            Get
                Return (dblLastBase)
            End Get
            Set(ByVal Value As Double)
                dblLastBase = Value
            End Set
        End Property
        ' LIBID 
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property

        Public Sub InsertReceived()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BUDGET_CREDIT_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPoID", OracleType.Number)).Value = intPoID
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                                .Add(New OracleParameter("strReason", OracleType.VarChar, 200)).Value = strReason
                                .Add(New OracleParameter("strTransactionDate", OracleType.VarChar, 30)).Value = strTransactionDate
                                .Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                                .Add(New OracleParameter("intBudgetID", OracleType.Number)).Value = intBudgetID
                                .Add(New OracleParameter("dblAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("dblExchangeRate", OracleType.Float)).Value = dblExchangeRate
                                .Add(New OracleParameter("dblFixedRate", OracleType.Float)).Value = dblFixedRate
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spBudget_Credit_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPoID", SqlDbType.Int)).Value = intPoID
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 200)).Value = strReason
                                .Add(New SqlParameter("@strTransactionDate", SqlDbType.VarChar, 30)).Value = strTransactionDate
                                .Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                                .Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                                .Add(New SqlParameter("@dblAmount", SqlDbType.Money)).Value = dblAmount
                                .Add(New SqlParameter("@dblExchangeRate", SqlDbType.Float)).Value = dblExchangeRate
                                .Add(New SqlParameter("@dblFixedRate", SqlDbType.Float)).Value = dblFixedRate
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Sub InsertSpend()
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BUDGET_DEBIT_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intPoID", OracleType.Number)).Value = intPoID
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                                .Add(New OracleParameter("strReason", OracleType.VarChar, 200)).Value = strReason
                                .Add(New OracleParameter("intCommited", OracleType.Number)).Value = intCommited
                                .Add(New OracleParameter("strTransactionDate", OracleType.VarChar, 30)).Value = strTransactionDate
                                .Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                                .Add(New OracleParameter("intBudgetID", OracleType.Number)).Value = intBudgetID
                                .Add(New OracleParameter("dblAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("dblExchangeRate", OracleType.Float)).Value = dblExchangeRate
                                .Add(New OracleParameter("dblFixedRate", OracleType.Float)).Value = dblFixedRate
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spBudget_Debit_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPoID", SqlDbType.Int)).Value = intPoID
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 200)).Value = strReason
                                .Add(New SqlParameter("@bytCommited", SqlDbType.Int)).Value = intCommited
                                .Add(New SqlParameter("@strTransactionDate", SqlDbType.VarChar, 30)).Value = strTransactionDate
                                .Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                                .Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                                .Add(New SqlParameter("@dblAmount", SqlDbType.Money)).Value = dblAmount
                                .Add(New SqlParameter("@dblExchangeRate", SqlDbType.Float)).Value = dblExchangeRate
                                .Add(New SqlParameter("@dblFixedRate", SqlDbType.Float)).Value = dblFixedRate
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Function GetAccountInfor(ByVal intType As Integer, ByVal intMonth As Integer, ByVal intYear As Integer, ByVal intPOID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_tblFine_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                                .Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                                .Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                                .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                                .Add(New SqlParameter("@intPOID", SqlDbType.Int)).Value = intPOID
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@mnyBalance", SqlDbType.Money)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@mnyRealBalance", SqlDbType.Money)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 5)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@mnyStartRemain", SqlDbType.Money)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@mnyLastBase", SqlDbType.Money)).Direction = ParameterDirection.Output
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAccountInfor = dsData.Tables("tblResult")
                            dblBalance = .Parameters("@mnyBalance").Value
                            dblRealBalance = .Parameters("@mnyRealBalance").Value
                            strCurrency = .Parameters("@strCurrency").Value
                            dblStartRemain = .Parameters("@mnyStartRemain").Value
                            dblLastBase = .Parameters("@mnyLastBase").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_FINE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intType", OracleType.Number, 4)).Value = intType
                                .Add(New OracleParameter("intBudgetID", OracleType.Number, 4)).Value = intBudgetID
                                .Add(New OracleParameter("intMonth", OracleType.Number, 4)).Value = intMonth
                                .Add(New OracleParameter("intYear", OracleType.Number, 4)).Value = intYear
                                .Add(New OracleParameter("intPOID", OracleType.Number, 4)).Value = intPOID
                                .Add(New OracleParameter("mnyBalance", OracleType.Float)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("mnyRealBalance", OracleType.Float)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 5)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("mnyStartRemain", OracleType.Float)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("mnyLastBase", OracleType.Float)).Direction = ParameterDirection.Output
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAccountInfor = dsData.Tables("tblResult")
                            dblBalance = .Parameters("mnyBalance").Value
                            dblRealBalance = .Parameters("mnyRealBalance").Value
                            strCurrency = .Parameters("strCurrency").Value
                            dblStartRemain = .Parameters("mnyStartRemain").Value
                            dblLastBase = .Parameters("mnyLastBase").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Sub InsertAccountInfor(ByVal intType As Integer)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_FINE_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("intBudgetID", OracleType.Number)).Value = intBudgetID
                                .Add(New OracleParameter("intPoID", OracleType.Number)).Value = intPoID
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                                .Add(New OracleParameter("strReason", OracleType.VarChar, 200)).Value = strReason
                                .Add(New OracleParameter("intCommited", OracleType.Number)).Value = intCommited
                                .Add(New OracleParameter("strTransactionDate", OracleType.VarChar, 30)).Value = strTransactionDate
                                .Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                                .Add(New OracleParameter("mnyAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("dblExchangeRate", OracleType.Float)).Value = dblExchangeRate
                                .Add(New OracleParameter("dblFixedRate", OracleType.Float)).Value = dblFixedRate
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_tblFine_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                                .Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                                .Add(New SqlParameter("@intPoID", SqlDbType.Int)).Value = intPoID
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 200)).Value = strReason
                                .Add(New SqlParameter("@bytCommited", SqlDbType.Int)).Value = intCommited
                                .Add(New SqlParameter("@strTransactionDate", SqlDbType.VarChar, 30)).Value = strTransactionDate
                                .Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                                .Add(New SqlParameter("@mnyAmount", SqlDbType.Money)).Value = dblAmount
                                .Add(New SqlParameter("@dblExchangeRate", SqlDbType.Float)).Value = dblExchangeRate
                                .Add(New SqlParameter("@dblFixedRate", SqlDbType.Float)).Value = dblFixedRate
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Sub UpdateAccountInfor(ByVal intType As Integer)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_FINE_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("intBudgetID", OracleType.Number)).Value = intBudgetID
                                .Add(New OracleParameter("intPoID", OracleType.Number)).Value = intPoID
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                                .Add(New OracleParameter("strReason", OracleType.VarChar, 200)).Value = strReason
                                .Add(New OracleParameter("intCommited", OracleType.Number)).Value = intCommited
                                .Add(New OracleParameter("strTransactionDate", OracleType.VarChar, 30)).Value = strTransactionDate
                                .Add(New OracleParameter("strInputer", OracleType.VarChar, 50)).Value = strInputer
                                .Add(New OracleParameter("mnyAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("dblExchangeRate", OracleType.Float)).Value = dblExchangeRate
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_tblFine_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                                .Add(New SqlParameter("@intPoID", SqlDbType.Int)).Value = intPoID
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 200)).Value = strReason
                                .Add(New SqlParameter("@bytCommited", SqlDbType.Int)).Value = intCommited
                                .Add(New SqlParameter("@strTransactionDate", SqlDbType.VarChar, 30)).Value = strTransactionDate
                                .Add(New SqlParameter("@strInputer", SqlDbType.NVarChar, 50)).Value = strInputer
                                .Add(New SqlParameter("@mnyAmount", SqlDbType.Money)).Value = dblAmount
                                .Add(New SqlParameter("@dblExchangeRate", SqlDbType.Float)).Value = dblExchangeRate
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Sub DeleteAccountInfor(ByVal intType As Integer)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_FINE_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                                .Add(New OracleParameter("intBudgetID", OracleType.Number)).Value = intBudgetID
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_tblFine_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Sub UpdateAccumulate(ByVal intMonth As Integer, ByVal intYear As Integer)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_ACCUMULATE_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intBudgetID", OracleType.Number)).Value = intBudgetID
                                .Add(New OracleParameter("mnyAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                                .Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            End With
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spBudget_Accumulate_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                                .Add(New SqlParameter("@mnyAmount", SqlDbType.Int)).Value = dblAmount
                                .Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                                .Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Sub

        Public Function GetDebitAmount(ByVal bytCommitedOnly As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_DEBIT_AMOUNT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("bytCommitedOnly", OracleType.Number)).Value = bytCommitedOnly
                            .Parameters.Add(New OracleParameter("intPoID", OracleType.Number)).Value = intPoID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetDebitAmount = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spBudget_Debit_SelAmount"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@bytCommitedOnly", SqlDbType.Bit)).Value = bytCommitedOnly
                            .Parameters.Add(New SqlParameter("@intPoID", SqlDbType.Int)).Value = intPoID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetDebitAmount = dsData.Tables("tblResult")
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

        Public Sub UpdateDebitAmount(ByVal strIDs As String, ByVal strRates As String)
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_UPDATE_DEBIT_AMOUNT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 1000)).Value = strIDs
                            .Parameters.Add(New OracleParameter("strRates", OracleType.VarChar, 1000)).Value = strRates
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spBudget_Debit_UpdAmount"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value = strIDs
                            .Parameters.Add(New SqlParameter("@strRates", SqlDbType.VarChar)).Value = strRates
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Sub DeleteDebitAmount(ByVal strIDs As String)
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_DEL_DEBIT_AMOUNT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 500)).Value = strIDs
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spBudget_Debit_DelAmount"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 500)).Value = strIDs
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' Method: Dispose
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