Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBAccountTransaction
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strPatronCode As String = ""
        Private intFineID As Integer
        Private dblAmount As Double = 0
        Private strReason As String = 0
        Private strCreatedDate As String = ""
        Private strCurrency As String = ""
        Private strCreator As String = ""
        Private intMonth As Int16 = 0
        Private intYear As Integer = 0
        Private intType As Int16 = 0
        Private dblSeetled As Double = 0
        Private dblUnSeetled As Double = 0
        Private dblRemain As Double = 0
        Private intOutPut As Int16
        Private dblRate As Double = 0
        Private intLibID As Integer = 0

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDAcountTransaction As New clsDAccountTransaction

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' FineID property
        Public Property FineID() As Integer
            Get
                Return intFineID
            End Get
            Set(ByVal Value As Integer)
                intFineID = Value
            End Set
        End Property

        ' PatronCode property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
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

        ' Reason property
        Public Property Reason() As String
            Get
                Return strReason
            End Get
            Set(ByVal Value As String)
                strReason = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' Creator property
        Public Property Creator() As String
            Get
                Return strCreator
            End Get
            Set(ByVal Value As String)
                strCreator = Value
            End Set
        End Property

        ' Month property
        Public Property Month() As Int16
            Get
                Return intMonth
            End Get
            Set(ByVal Value As Int16)
                intMonth = Value
            End Set
        End Property

        ' Year property 
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property

        ' Type property 
        Public Property Type() As Int16
            Get
                Return intType
            End Get
            Set(ByVal Value As Int16)
                intType = Value
            End Set
        End Property

        ' Settled property
        Public Property Settled() As Double
            Get
                Return dblSeetled
            End Get
            Set(ByVal Value As Double)
                dblSeetled = Value
            End Set
        End Property

        ' UnSettled property
        Public Property UnSettled() As Double
            Get
                Return dblUnSeetled
            End Get
            Set(ByVal Value As Double)
                dblUnSeetled = Value
            End Set
        End Property

        ' Remain property
        Public Property Remain() As Double
            Get
                Return dblRemain
            End Get
            Set(ByVal Value As Double)
                dblRemain = Value
            End Set
        End Property

        ' OutPut property
        Public Property OutPut() As Int16
            Get
                Return intOutPut
            End Get
            Set(ByVal Value As Int16)
                intOutPut = Value
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
        ' LibID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                ' Init objBCSP object
                objBCSP.ConnectionString = strConnectionString
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                Call objBCSP.Initialize()

                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' Init objDAcountTransaction object
                objDAcountTransaction.ConnectionString = strConnectionString
                objDAcountTransaction.DBServer = strDBServer
                Call objDAcountTransaction.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetAccountInfor method
        ' Purpose: get all SettedFees, Unsettled Fees and Summaries
        ' Input:
        ' Output: datatable result
        Public Function GetAccountInfor() As DataTable
            Dim tblResult As DataTable
            Dim inti As Integer
            Try
                strErrorMsg = objDAcountTransaction.ErrorMsg
                intErrorCode = objDAcountTransaction.ErrorCode
                objDAcountTransaction.PatronCode = strPatronCode
                objDAcountTransaction.Month = intMonth
                objDAcountTransaction.Year = intYear
                objDAcountTransaction.Type = intType
                objDAcountTransaction.LibID = intLibID
                tblResult = objBCDBS.ConvertTable(objDAcountTransaction.GetAccountInfor, False)
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    For inti = 0 To tblResult.Rows.Count - 1
                        tblResult.Rows(inti).Item("Amount") = tblResult.Rows(inti).Item("Amount")
                    Next
                End If
                GetAccountInfor = tblResult
                dblSeetled = objDAcountTransaction.Settled
                dblUnSeetled = objDAcountTransaction.UnSettled
                dblRemain = objDAcountTransaction.Remain
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateNewFine method
        ' Purpose: Add new fine (settled or unsettled)
        ' Input: some main information of Fine
        Public Sub CreateNewFine(ByVal intCheckPatronDept As Integer)
            Try
                objDAcountTransaction.Type = intType
                objDAcountTransaction.PatronCode = strPatronCode
                objDAcountTransaction.Amount = dblAmount
                objDAcountTransaction.Currency = strCurrency
                objDAcountTransaction.Rate = dblRate
                objDAcountTransaction.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                objDAcountTransaction.Reason = objBCSP.ConvertItBack(strReason)
                objDAcountTransaction.LibID = intLibID
                objDAcountTransaction.CreateNewFine(intCheckPatronDept)
                intOutPut = objDAcountTransaction.OutPut
                strErrorMsg = objDAcountTransaction.ErrorMsg
                intErrorCode = objDAcountTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub

        ' UpdateFine method
        ' Purpose: Update fine (settled or unsettled)
        ' Input: some main information of Fine
        Public Sub UpdateFine()
            Try
                objDAcountTransaction.Type = intType
                objDAcountTransaction.FineID = intFineID
                objDAcountTransaction.PatronCode = strPatronCode
                objDAcountTransaction.Amount = dblAmount
                objDAcountTransaction.Currency = strCurrency
                objDAcountTransaction.Rate = dblRate
                objDAcountTransaction.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                objDAcountTransaction.Reason = objBCSP.ConvertItBack(strReason)
                objDAcountTransaction.UpdateFine()
                intOutPut = objDAcountTransaction.OutPut
                strErrorMsg = objDAcountTransaction.ErrorMsg
                intErrorCode = objDAcountTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' DeleteFine method
        ' Purpose: Delete fine (settled or unsettled)
        ' Input: FineID
        Public Sub DeleteFine()
            Try
                objDAcountTransaction.FineID = intFineID
                objDAcountTransaction.DeleteFine()
                strErrorMsg = objDAcountTransaction.ErrorMsg
                intErrorCode = objDAcountTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDAcountTransaction Is Nothing Then
                    objDAcountTransaction.Dispose(True)
                    objDAcountTransaction = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
