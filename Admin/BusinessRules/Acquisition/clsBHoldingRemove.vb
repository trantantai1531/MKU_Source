' Purpose: process libraries location informations
' Creator: Lent
' Created Date: 17-2-2005
' Last Modified Date: 

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBHoldingRemove
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objDHoldingRemove As New clsDHoldingRemove
        Private objBCDBS As New clsBCommonDBSystem

        Private strCopyNumbers As String
        Private intReasonID As Integer
        Private strRemovedDate As String
        Private strItemCode As String
        Private intTotalItem As Integer
        Private intOnLoan As Integer

        ' *******************************************************************************************************
        ' End declare variables
        ' Declare properties here
        ' *******************************************************************************************************
        Public Property CopyNumbers() As String
            Get
                Return (strCopyNumbers)
            End Get
            Set(ByVal Value As String)
                strCopyNumbers = Value
            End Set
        End Property
        Public Property ReasonID() As Integer
            Get
                Return (intReasonID)
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property
        Public Property RemovedDate() As String
            Get
                Return (strRemovedDate)
            End Get
            Set(ByVal Value As String)
                strRemovedDate = Value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                Return (strItemCode)
            End Get
            Set(ByVal Value As String)
                strItemCode = Value
            End Set
        End Property
        Public Property TotalItem() As Integer
            Get
                Return (intTotalItem)
            End Get
            Set(ByVal Value As Integer)
                intTotalItem = Value
            End Set
        End Property
        Public Property OnLoan() As Integer
            Get
                Return (intOnLoan)
            End Get
            Set(ByVal Value As Integer)
                intOnLoan = Value
            End Set
        End Property

        ' *******************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *******************************************************************************************************
        ' init all objects
        Public Sub Initialize()
            ' Intialize objDHoldingRemove object
            objDHoldingRemove.DBServer = strdbserver
            objDHoldingRemove.ConnectionString = strConnectionString
            objDHoldingRemove.Initialize()
            ' Initialise objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        ' Liquidate method
        ' Purpose: process liquidate
        ' Input: 
        ' Output: 
        ' date : 7-3-2005
        Public Sub Liquidate()
            Try
                objDHoldingRemove.ItemCode = strItemCode
                objDHoldingRemove.ReasonID = intReasonID
                objDHoldingRemove.CopyNumbers = strCopyNumbers
                objDHoldingRemove.RemovedDate = strRemovedDate
                Call objDHoldingRemove.Liquidate()
                intTotalItem = objDHoldingRemove.TotalItem
                intOnLoan = objDHoldingRemove.OnLoan
            Catch ex As Exception
                strerrormsg = objDHoldingRemove.ErrorMsg
                interrorcode = objDHoldingRemove.ErrorCode
            End Try
        End Sub
        ' RetrieveRemoveReason method 
        ' Purpose: retrieve removed reason
        ' Output: datatable
        ' Creator: Lent
        Public Function GetHoldingRemoveReason() As DataTable
            Try
                objDHoldingRemove.ReasonID = intReasonID
                GetHoldingRemoveReason = objBCDBS.ConvertTable(objDHoldingRemove.GetHoldingRemoveReason)
                strErrorMsg = objDHoldingRemove.ErrorMsg
                intErrorCode = objDHoldingRemove.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDHoldingRemove Is Nothing Then
                    objDHoldingRemove.Dispose(True)
                    objDHoldingRemove = Nothing
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

