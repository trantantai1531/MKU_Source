'class: clsBBudget
' Purpose: proccess information of budget
' Creator: lent
'created date: 28-3-2005
'histoty update:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBBudget
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objDBudget As New clsDBudget
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        Private intBudID As Integer = 0
        Private intPoID As Integer = 0
        Private strCurrency As String = ""
        Private strBudgetCode As String = ""
        Private strPurpose As String = ""
        Private douBalance As Double = 0
        Private douRealBalance As Double = 0
        Private strBudgetName As String = ""
        Private intStatus As Integer = 0
        Private dblStartRemain As Double = 0
        Private dblLastBase As Double = 0
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' BudID property
        Public Property BudID() As Integer
            Get
                Return (intBudID)
            End Get
            Set(ByVal Value As Integer)
                intBudID = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return (strCurrency)
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' BudgetCode property
        Public Property BudgetCode() As String
            Get
                Return (strBudgetCode)
            End Get
            Set(ByVal Value As String)
                strBudgetCode = Value
            End Set
        End Property

        ' BudgetName property
        Public Property BudgetName() As String
            Get
                Return (strBudgetName)
            End Get
            Set(ByVal Value As String)
                strBudgetName = Value
            End Set
        End Property

        ' Purpose property
        Public Property Purpose() As String
            Get
                Return (strPurpose)
            End Get
            Set(ByVal Value As String)
                strPurpose = Value
            End Set
        End Property

        ' Balance proproperty
        Public Property Balance() As Double
            Get
                Return (douBalance)
            End Get
            Set(ByVal Value As Double)
                douBalance = Value
            End Set
        End Property

        ' RealBalance property
        Public Property RealBalance() As Double
            Get
                Return (douRealBalance)
            End Get
            Set(ByVal Value As Double)
                douRealBalance = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Integer
            Get
                Return (intStatus)
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' PoID property
        Public Property PoID() As Integer
            Get
                Return (intPoID)
            End Get
            Set(ByVal Value As Integer)
                intPoID = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' init all objects
        Public Sub Initialize()
            ' Intialize objDBudget object
            objDBudget.DBServer = strdbserver
            objDBudget.ConnectionString = strConnectionString
            objDBudget.Initialize()
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

        ' Method: CreateBudget
        ' Purpose: create new a budget
        ' Input: budget informations
        ' Output: int value (0 if fail)
        ' Creator: lent
        Public Function CreateBudget() As Integer
            Try
                objDBudget.BudgetName = objBCSP.ConvertItBack(strBudgetName)
                objDBudget.BudgetCode = strBudgetCode
                objDBudget.Balance = douBalance
                objDBudget.Currency = strCurrency
                objDBudget.Status = intStatus
                objDBudget.LibID = intLibID
                objDBudget.Purpose = objBCSP.ConvertItBack(strPurpose)
                CreateBudget = objDBudget.CreateBudget()
            Catch ex As Exception
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
            End Try
        End Function

        ' Method: UpdateBudget
        ' Purpose: update information of budget
        ' Input: budget informations
        ' Output: int value (0 if fail)
        ' Creator: lent
        Public Function UpdateBudget() As Integer
            Try
                objDBudget.BudID = intBudID
                objDBudget.BudgetName = objBCSP.ConvertItBack(strBudgetName)
                objDBudget.BudgetCode = strBudgetCode
                objDBudget.Balance = douBalance
                objDBudget.Currency = strCurrency
                objDBudget.Status = intStatus
                objDBudget.Purpose = objBCSP.ConvertItBack(strPurpose)
                UpdateBudget = objDBudget.UpdateBudget()
            Catch ex As Exception
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
            End Try
        End Function

        ' Method: DeleteBudget
        ' Purpose: delete a budget
        ' Input: BudgetID
        ' Creator: lent
        Public Sub DeleteBudget()
            Try
                objDBudget.BudID = intBudID
                Call objDBudget.DeleteBudget()
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        ' Method: TransferMoney
        ' Purpose: Transfer money between budgets
        ' Input: some informations
        ' Creator:Lent
        Public Sub TransferMoney(ByVal intIDSrc As Integer, ByVal intIDDes As Integer, ByVal dbMonSrc As Double, ByVal dbMonDes As Double)
            Try
                Call objDBudget.TransferMoney(intIDSrc, intIDDes, dbMonSrc, dbMonDes)
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub
        ' Method: TransferMoney
        ' Purpose: Transfer money between budgets with check
        ' Input: some informations
        ' Creator:tulnn
        Public Function TransferMoneyWithCheck(ByVal intIDSrc As Integer, ByVal intIDDes As Integer, ByVal dbMonSrc As Double, ByVal dbMonDes As Double) As Integer
            Try
                Dim intresult As Integer
                intresult = objDBudget.TransferMoneyWithCheck(intIDSrc, intIDDes, dbMonSrc, dbMonDes)
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
                Return intresult
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Method: GetBudget
        ' Purpose: Get information of Budget(s)
        ' Input: BudgetID
        ' Output: Datatable result
        ' Creator: lent
        Public Function GetBudget(Optional ByVal intFromPO As Integer = 0, Optional ByVal intDisplay As Integer = 0) As DataTable
            Try
                objDBudget.BudID = intBudID
                objDBudget.LibID = intLibID
                GetBudget = objBCDBS.ConvertTable(objDBudget.GetBudget(intFromPO, intDisplay))
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: get information of Budget by status
        ' Input: strCurrencyCode
        ' Output: datatable
        ' Creator: lent
        Public Function GetBudgetByStatus(Optional ByVal intStatusBud As Integer = 0, Optional ByVal intDisplay As Integer = 0) As DataTable
            Dim tblResult As DataTable
            Try
                objDBudget.BudID = 0
                objDBudget.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDBudget.GetBudget(0, intDisplay))
                'tblResult.DefaultView.RowFilter = "Status=" & CStr(intStatusBud)
                GetBudgetByStatus = tblResult
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetGroupStausPO() As DataTable
            Dim tblResult As DataTable
            Try
                objDBudget.LibID = intLibID
                tblResult = objDBudget.GetGroupStausPO()
                GetGroupStausPO = tblResult
                strErrorMsg = objDBudget.ErrorMsg
                intErrorCode = objDBudget.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDBudget Is Nothing Then
                    objDBudget.Dispose(True)
                    objDBudget = Nothing
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