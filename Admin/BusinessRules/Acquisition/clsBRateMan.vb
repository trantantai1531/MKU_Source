' class:clsBRateMan
' purpose:process information of currency
' Creator:lent
' Created Date: 28-3-2005
' History update:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBRateMan
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objDRateMan As New clsDRateMan
        Private objBCDBS As New clsBCommonDBSystem
        Private strCurrencyCode As String
        Private douRate As Double

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' Property CurrencyCode
        Public Property CurrencyCode() As String
            Get
                Return (strCurrencyCode)
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property

        ' Property Rate
        Public Property Rate() As Double
            Get
                Return (douRate)
            End Get
            Set(ByVal Value As Double)
                douRate = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' Method: Initialize
        ' Purpose: Init all objects
        Public Sub Initialize()
            ' Intialize objDRateMan object
            objDRateMan.DBServer = strdbserver
            objDRateMan.ConnectionString = strConnectionString
            Call objDRateMan.Initialize()

            ' Initialise objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()
        End Sub

        ' Method: Create
        ' Purpose: New currency
        ' Input: Currency, rate
        ' Output: int value (0 if success)
        ' Creator: lent
        Public Function Create() As Integer
            Try
                objDRateMan.CurrencyCode = strCurrencyCode
                objDRateMan.Rate = douRate
                Create = objDRateMan.Create()
            Catch ex As Exception
                strerrormsg = objDRateMan.ErrorMsg
                interrorcode = objDRateMan.ErrorCode
            End Try
        End Function

        ' Method: Update
        ' Purpose: update currency
        ' Input: currency, rate
        ' Output: int value (0 if success)
        ' Creator: lent
        Public Function Update() As Integer
            Try
                objDRateMan.CurrencyCode = strCurrencyCode
                objDRateMan.Rate = douRate
                Update = objDRateMan.Update()
            Catch ex As Exception
                strerrormsg = objDRateMan.ErrorMsg
                interrorcode = objDRateMan.ErrorCode
            End Try
        End Function

        'purpose: delete a currency format
        'in:strCurrencyCode
        'out:
        'creator: lent
        Public Sub Delete()
            Try
                objDRateMan.CurrencyCode = strCurrencyCode
                Call objDRateMan.Delete()
            Catch ex As Exception
                strerrormsg = objDRateMan.ErrorMsg
                interrorcode = objDRateMan.ErrorCode
            End Try
        End Sub

        'purpose: Get information of currency
        'in: strCurrencyCode
        'out: datatable
        'creator: lent
        Public Function GetRate() As DataTable
            Try
                objDRateMan.CurrencyCode = strCurrencyCode
                GetRate = objBCDBS.ConvertTable(objDRateMan.GetRate())
                strErrorMsg = objDRateMan.ErrorMsg
                intErrorCode = objDRateMan.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDRateMan Is Nothing Then
                    objDRateMan.Dispose(True)
                    objDRateMan = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace