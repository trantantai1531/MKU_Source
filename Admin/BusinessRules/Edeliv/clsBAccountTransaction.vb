Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Edeliv

Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBAccountTransaction
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDAccountTrans As New clsDAccountTransaction

        Private strCreatedDate As String = ""
        Private strReason As String = ""
        Private strCurrencyCode As String = ""
        Private strCustomerCode As String = ""
        Private dblRate As Double = 0
        Private dblAmount As Double = 0
        Private dblDebt As Double = 0
        Private intMonth As Integer = 0
        Private intYear As Integer = 0
        Private strPaymentIDs As String = ""
        Private intPaymentID As Integer = 0

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' Reason property
        Public Property Reason() As String
            Get
                Return strReason
            End Get
            Set(ByVal Value As String)
                strReason = Value
            End Set
        End Property

        ' CurrencyCode property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property

        ' CustomerCode property
        Public Property CustomerCode() As String
            Get
                Return strCustomerCode
            End Get
            Set(ByVal Value As String)
                strCustomerCode = Value
            End Set
        End Property

        ' Rate property
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal Value As Double)
                dblRate = Value
            End Set
        End Property

        ' Amount property
        Public Property Amount() As Double
            Get
                Return dblAmount
            End Get
            Set(ByVal Value As Double)
                dblAmount = Value
            End Set
        End Property

        ' Debt property
        Public Property Debt() As Double
            Get
                Return dblDebt
            End Get
            Set(ByVal Value As Double)
                dblDebt = Value
            End Set
        End Property

        ' Month property
        Public Property Month() As Integer
            Get
                Return intMonth
            End Get
            Set(ByVal Value As Integer)
                intMonth = Value
            End Set
        End Property

        ' Year property
        Public Property Year() As String
            Get
                Return intYear
            End Get
            Set(ByVal Value As String)
                intYear = Value
            End Set
        End Property

        ' PaymentIDs property
        Public Property PaymentIDs() As String
            Get
                Return strPaymentIDs
            End Get
            Set(ByVal Value As String)
                strPaymentIDs = Value
            End Set
        End Property

        ' PaymentID property
        Public Property PaymentID() As String
            Get
                Return intPaymentID
            End Get
            Set(ByVal Value As String)
                intPaymentID = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare public properties
        ' Implement methods here
        ' *************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBSP.DBServer = strDBServer
            objBSP.ConnectionString = strConnectionString
            objBSP.InterfaceLanguage = strInterfaceLanguage
            objBSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDAccountTrans object
            objDAccountTrans.DBServer = strDBServer
            objDAccountTrans.ConnectionString = strConnectionString
            objDAccountTrans.Initialize()
        End Sub

        ' Create method
        ' Purpose: create new transaction record
        ' Input: main infor of transaction infor
        ' Output: int value (0 when success)
        Public Function Create() As Integer
            Try
                objDAccountTrans.CustomerCode = strCustomerCode
                objDAccountTrans.Amount = dblAmount
                objDAccountTrans.CurrencyCode = strCurrencyCode
                objDAccountTrans.Rate = dblRate
                objDAccountTrans.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                objDAccountTrans.Reason = objBSP.ConvertItBack(strReason)
                objDAccountTrans.PaymentIDs = strPaymentIDs
                Create = objDAccountTrans.Create()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Update method
        ' Purpose: update information of the selected transaction record
        ' Input: main infor of transaction infor
        ' Output: int value (0 when success)
        Public Function Update() As Integer
            Try
                objDAccountTrans.PaymentID = intPaymentID
                objDAccountTrans.Amount = dblAmount
                objDAccountTrans.CurrencyCode = strCurrencyCode
                objDAccountTrans.Rate = dblRate
                objDAccountTrans.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                objDAccountTrans.Reason = objBSP.ConvertItBack(strReason)
                objDAccountTrans.PaymentIDs = strPaymentIDs
                Update = objDAccountTrans.Update()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete method
        ' Purpose: delete the selected transaction record
        ' Input: Payment
        Public Sub Delete()
            Try
                objDAccountTrans.PaymentID = intPaymentID
                objDAccountTrans.Delete()
                strErrorMsg = objDAccountTrans.ErrorMsg
                intErrorcode = objDAccountTrans.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' CheckDebt method
        ' Purpose: check debt of the selected customer
        ' Input: customercode
        ' Output: datatable result
        Public Function CheckDebt(ByRef dblDebt As Double, ByRef intOutPut As Int16) As DataTable
            Try
                objDAccountTrans.CustomerCode = strCustomerCode
                CheckDebt = objBCDBS.ConvertTable(objDAccountTrans.CheckDebt(dblDebt, intOutPut), "TITLE")
                strErrorMsg = objDAccountTrans.ErrorMsg
                intErrorcode = objDAccountTrans.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetAccInfor method
        ' Purpose: Get account infor
        ' Input: main infor of transaction infor
        ' Output: datatable result
        Public Function GetAccInfor(ByVal intType As Int16, ByRef dblSeetled As Double, ByRef dblUnSeetled As Double, ByRef dblRemain As Double) As DataTable
            Try
                objDAccountTrans.CustomerCode = strCustomerCode
                objDAccountTrans.Month = intMonth
                objDAccountTrans.Year = intYear
                GetAccInfor = objBCDBS.ConvertTable(objDAccountTrans.GetAccInfor(intType, dblSeetled, dblUnSeetled, dblRemain), False)
                strErrorMsg = objDAccountTrans.ErrorMsg
                intErrorcode = objDAccountTrans.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetGenInfor method
        ' Purpose: Get general infor for creating report
        ' Input: main infor
        ' Output: datatable result
        Public Function GetGenInfor() As DataTable
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetTransYears method
        ' Purpose: Get transaction year
        ' Input: main infor
        ' Output: datatable result
        Public Function GetTransYears() As DataTable
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSP Is Nothing Then
                    objBSP.Dispose(True)
                    objBSP = Nothing
                End If
                If Not objDAccountTrans Is Nothing Then
                    objDAccountTrans.Dispose(True)
                    objDAccountTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
