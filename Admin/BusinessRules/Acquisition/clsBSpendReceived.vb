Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBSpendReceived1
        Inherits clsBBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDSpendReceived As New clsDSpendReceived
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

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' init all objects
        Public Sub Initialize()
            ' Intialize objDSpendReceived object
            objDSpendReceived.DBServer = strdbserver
            objDSpendReceived.ConnectionString = strConnectionString
            objDSpendReceived.Initialize()
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

        Public Function GetGeneralReceived() As DataTable
            Try
                objDSpendReceived.BudgetID = intBudgetID
                GetGeneralReceived = objBCDBS.ConvertTable(objDSpendReceived.GetGeneralReceivedSpend)
                strErrorMsg = objDSpendReceived.ErrorMsg
                intErrorCode = objDSpendReceived.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub InsertReceived()
            Try
                objDSpendReceived.PoID = intPoID
                objDSpendReceived.Currency = strCurrency
                objDSpendReceived.Reason = objBCSP.ConvertItBack(strReason)
                objDSpendReceived.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDSpendReceived.Inputer = strInputer
                objDSpendReceived.BudgetID = intBudgetID
                objDSpendReceived.Amount = dblAmount
                objDSpendReceived.ExchangeRate = dblExchangeRate
                objDSpendReceived.FixedRate = dblFixedRate
                Call objDSpendReceived.InsertReceived()
            Catch ex As Exception
                strerrormsg = objDSpendReceived.ErrorMsg
                interrorcode = objDSpendReceived.ErrorCode
            End Try
        End Sub
        'purpose: Insert a spend budget
        'in:strCurrencyCode
        'out:
        'creator: lent
        Public Sub InsertSpend()
            Try
                objDSpendReceived.PoID = intPoID
                objDSpendReceived.Currency = strCurrency
                objDSpendReceived.Reason = objBCSP.ConvertItBack(strReason)
                objDSpendReceived.Commited = intCommited
                objDSpendReceived.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDSpendReceived.Inputer = strInputer
                objDSpendReceived.BudgetID = intBudgetID
                objDSpendReceived.Amount = dblAmount
                objDSpendReceived.ExchangeRate = dblExchangeRate
                objDSpendReceived.FixedRate = dblFixedRate
                Call objDSpendReceived.InsertSpend()
            Catch ex As Exception
                strerrormsg = objDSpendReceived.ErrorMsg
                interrorcode = objDSpendReceived.ErrorCode
            End Try
        End Sub

        'purpose: Get information of RealBalance and balance
        'in: budget id, 
        'out: datatable
        'creator: lent
        Public Function GetGeneralSpend() As DataTable
            Try
                objDSpendReceived.BudgetID = intBudgetID
                GetGeneralSpend = objBCDBS.ConvertTable(objDSpendReceived.GetGeneralReceivedSpend)
                strErrorMsg = objDSpendReceived.ErrorMsg
                intErrorCode = objDSpendReceived.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        'purpose: delete a received budget
        'in:strCurrencyCode
        'out:
        'creator: lent
        Public Sub DeleteReceived()
            Try
                objDSpendReceived.ID = intID
                Call objDSpendReceived.DeleteReceived()
            Catch ex As Exception
                strerrormsg = objDSpendReceived.ErrorMsg
                interrorcode = objDSpendReceived.ErrorCode
            End Try
        End Sub

        'purpose: delete a spend budget
        'in:strCurrencyCode
        'out:
        'creator: lent
        Public Sub DeleteSpend()
            Try
                objDSpendReceived.ID = intID
                Call objDSpendReceived.DeleteSpend()
            Catch ex As Exception
                strerrormsg = objDSpendReceived.ErrorMsg
                interrorcode = objDSpendReceived.ErrorCode
            End Try
        End Sub

        'purpose: update a received budget
        'in:strCurrencyCode
        'out:
        'creator: lent
        Public Sub UpdateReceived()
            Try
                objDSpendReceived.ID = intID
                objDSpendReceived.PoID = intPoID
                objDSpendReceived.Currency = strCurrency
                objDSpendReceived.Reason = objBCSP.ConvertItBack(strReason)
                objDSpendReceived.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDSpendReceived.Inputer = strInputer
                objDSpendReceived.BudgetID = intBudgetID
                objDSpendReceived.Amount = dblAmount
                objDSpendReceived.ExchangeRate = dblExchangeRate
                objDSpendReceived.FixedRate = dblFixedRate
                Call objDSpendReceived.UpdateReceived()
            Catch ex As Exception
                strerrormsg = objDSpendReceived.ErrorMsg
                interrorcode = objDSpendReceived.ErrorCode
            End Try
        End Sub

        Public Sub UpdateSpend()
            Try
                objDSpendReceived.ID = intID
                objDSpendReceived.PoID = intPoID
                objDSpendReceived.Currency = strCurrency
                objDSpendReceived.Reason = objBCSP.ConvertItBack(strReason)
                objDSpendReceived.Commited = intCommited
                objDSpendReceived.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDSpendReceived.Inputer = strInputer
                objDSpendReceived.BudgetID = intBudgetID
                objDSpendReceived.Amount = dblAmount
                objDSpendReceived.ExchangeRate = dblExchangeRate
                objDSpendReceived.FixedRate = dblFixedRate
                Call objDSpendReceived.UpdateSpend()
            Catch ex As Exception
                strerrormsg = objDSpendReceived.ErrorMsg
                interrorcode = objDSpendReceived.ErrorCode
            End Try
        End Sub

        'purpose:
        'in:
        'out:
        'creator:
        Public Sub ReceivedReport()

        End Sub

        'purpose:
        'in:
        'out:
        'creator:
        Public Sub SpendReport()

        End Sub

        Public Sub DeclareReceived()

        End Sub

        Public Sub DeclareSpend()

        End Sub

        Public Function GetAccountInfor(ByVal intType As Integer, ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            'Try
            objDSpendReceived.BudgetID = intBudgetID
            GetAccountInfor = objBCDBS.ConvertTable(objDSpendReceived.GetAccountInfor(intType, intMonth, intYear))
            dblBalance = objDSpendReceived.Balance
            dblRealBalance = objDSpendReceived.RealBalance
            strErrorMsg = objDSpendReceived.ErrorMsg
            intErrorCode = objDSpendReceived.ErrorCode
            strCurrency = objDSpendReceived.Currency
            dblStartRemain = objDSpendReceived.StartRemain
            dblLastBase = objDSpendReceived.LastBase
            'Catch ex As Exception
            'strErrorMsg = ex.Message
            'End Try
        End Function

        Public Sub InsertAccountInfor(ByVal intType As Integer)
            'Try
            objDSpendReceived.BudgetID = intBudgetID
            objDSpendReceived.PoID = intPoID
            objDSpendReceived.Currency = strCurrency
            objDSpendReceived.Reason = objBCSP.ConvertItBack(strReason)
            objDSpendReceived.Commited = intCommited
            objDSpendReceived.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
            objDSpendReceived.Inputer = strInputer
            objDSpendReceived.Amount = dblAmount
            objDSpendReceived.ExchangeRate = dblExchangeRate
            objDSpendReceived.FixedRate = dblFixedRate
            Call objDSpendReceived.InsertAccountInfor(intType)
            'Catch ex As Exception
            '    strerrormsg = objDSpendReceived.ErrorMsg
            '    interrorcode = objDSpendReceived.ErrorCode
            'End Try
        End Sub

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDSpendReceived Is Nothing Then
                    objDSpendReceived.Dispose(True)
                    objDSpendReceived = Nothing
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

