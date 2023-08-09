Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBAccounting
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objDAccounting As New clsDAccounting
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private intID As Integer = 0
        Private intPoID As Integer = 0
        Private strCurrency As String = ""
        Private strReason As String = ""
        Private strTransactionDate As String = ""
        Private strInputer As String = ""
        Private intBudgetID As Integer = 0
        Private dblAmount As Double = 0
        Private dblExchangeRate As Double = 0
        Private dblFixedRate As Double = 0
        Private intCommited As Integer = 0
        Private dblBalance As Double = 0
        Private dblRealBalance As Double = 0
        Private dblStartRemain As Double = 0
        Private dblLastBase As Double = 0
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

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' init all objects
        Public Sub Initialize()
            ' Intialize objDAccounting object
            objDAccounting.DBServer = strDBServer
            objDAccounting.ConnectionString = strConnectionString
            objDAccounting.Initialize()
            ' Initialise objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
            ' Initialise objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()
        End Sub

        'purpose: Insert a received budget
        'in:strCurrencyCode
        'out:
        'creator: lent
        Public Sub InsertReceived()
            Try
                objDAccounting.PoID = intPoID
                objDAccounting.Currency = strCurrency
                objDAccounting.Reason = objBCSP.ConvertItBack(strReason)
                objDAccounting.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDAccounting.Inputer = objBCSP.ConvertItBack(strInputer)
                objDAccounting.BudgetID = intBudgetID
                objDAccounting.Amount = dblAmount
                objDAccounting.ExchangeRate = dblExchangeRate
                objDAccounting.FixedRate = dblFixedRate
                Call objDAccounting.InsertReceived()
            Catch ex As Exception
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            End Try
        End Sub
        'purpose: Insert a spend budget
        'in:strCurrencyCode
        'out:
        'creator: lent
        Public Sub InsertSpend()
            Try
                objDAccounting.PoID = intPoID
                objDAccounting.Currency = strCurrency
                objDAccounting.Reason = objBCSP.ConvertItBack(strReason)
                objDAccounting.Commited = intCommited
                objDAccounting.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDAccounting.Inputer = objBCSP.ConvertItBack(strInputer)
                objDAccounting.BudgetID = intBudgetID
                objDAccounting.Amount = dblAmount
                objDAccounting.ExchangeRate = dblExchangeRate
                objDAccounting.FixedRate = dblFixedRate
                Call objDAccounting.InsertSpend()
            Catch ex As Exception
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            End Try
        End Sub

        Public Function GetAccountInfor(ByVal intType As Integer, ByVal intMonth As Integer, ByVal intYear As Integer, Optional ByVal intPOID As Integer = 0) As DataTable
            Try
                objDAccounting.BudgetID = intBudgetID
                objDAccounting.LibID = intLibID
                GetAccountInfor = objBCDBS.ConvertTable(objDAccounting.GetAccountInfor(intType, intMonth, intYear, intPOID))
                dblBalance = objDAccounting.Balance
                dblRealBalance = objDAccounting.RealBalance
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
                strCurrency = objDAccounting.Currency
                dblStartRemain = objDAccounting.StartRemain
                dblLastBase = objDAccounting.LastBase
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub InsertAccountInfor(ByVal intType As Integer)
            Try
                objDAccounting.BudgetID = intBudgetID
                objDAccounting.PoID = intPoID
                objDAccounting.Currency = strCurrency
                objDAccounting.Reason = objBCSP.ConvertItBack(strReason)
                objDAccounting.Commited = intCommited
                objDAccounting.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDAccounting.Inputer = objBCSP.ConvertItBack(strInputer)
                objDAccounting.Amount = dblAmount
                objDAccounting.LibID = intLibID
                objDAccounting.ExchangeRate = dblExchangeRate
                objDAccounting.FixedRate = dblFixedRate

                Call objDAccounting.InsertAccountInfor(intType)
            Catch ex As Exception
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            End Try
        End Sub

        Public Sub UpdateAccountInfor(ByVal intType As Integer)
            Try
                objDAccounting.ID = intID
                objDAccounting.BudgetID = intBudgetID
                objDAccounting.PoID = intPoID
                objDAccounting.Currency = strCurrency
                objDAccounting.Reason = objBCSP.ConvertItBack(strReason)
                objDAccounting.Commited = intCommited
                objDAccounting.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDAccounting.Inputer = objBCSP.ConvertItBack(strInputer)
                objDAccounting.Amount = dblAmount
                objDAccounting.ExchangeRate = dblExchangeRate
                Call objDAccounting.UpdateAccountInfor(intType)
            Catch ex As Exception
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            End Try
        End Sub

        Public Sub DeleteAccountInfor(ByVal intType As Integer)
            Try
                objDAccounting.ID = intID
                objDAccounting.BudgetID = intBudgetID
                Call objDAccounting.DeleteAccountInfor(intType)
            Catch ex As Exception
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            End Try
        End Sub

        Public Sub UpdateAccumulate(ByVal intMonth As Integer, ByVal intYear As Integer)
            Try
                objDAccounting.BudgetID = intBudgetID
                objDAccounting.Amount = dblAmount
                Call objDAccounting.UpdateAccumulate(intMonth, intYear)
            Catch ex As Exception
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            End Try
        End Sub

        ' Method: GetDebitAmount
        ' Purpose: Get debit amount
        ' Input: bytCommitedOnly
        ' Output: DataTable
        ' Creator: Tuanhv
        Public Function GetDebitAmount(ByVal bytCommitedOnly As Byte) As DataTable
            Try
                objDAccounting.PoID = intPoID
                GetDebitAmount = objBCDBS.ConvertTable(objDAccounting.GetDebitAmount(bytCommitedOnly))
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: UpdateDebitAmount
        ' Purpose: Change status of selected debit amount(s)
        ' Input: IDs, Rates of debit amounts
        ' Creator: Tuanhv
        Public Sub UpdateDebitAmount(ByVal strIDs As String, ByVal strRates As String)
            Try
                Call objDAccounting.UpdateDebitAmount(strIDs, strRates)
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: DeleteDebitAmount
        ' Purpose: Delete selected debit amount(s)
        ' Input: strIDs
        ' Creator: Tuanhv
        Public Sub DeleteDebitAmount(ByVal strIDs As String)
            Try
                Call objDAccounting.DeleteDebitAmount(strIDs)
                strErrorMsg = objDAccounting.ErrorMsg
                intErrorCode = objDAccounting.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDAccounting Is Nothing Then
                    objDAccounting.Dispose(True)
                    objDAccounting = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

