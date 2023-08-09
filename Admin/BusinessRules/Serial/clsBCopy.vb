' Class: clsBBinding
' Purpose: Management copy
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:
'   - 06/10/2004 by Oanhtn: add new method:
'       + UpdateReceiveDate: for update ReceivedDate
'       + UnReceive: unreceive copies
'       + Receive: receive copies

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Serial

Namespace eMicLibAdmin.BusinessRules.Serial
    Public Class clsBCopy
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intLocationID As Integer = 0
        Private intPubYear As Integer = 0
        Private strName As String = ""
        Private strReceivedDate As String = ""
        Private strNote As String = ""
        Private intReceivedCopies As Integer = 0
        Private lngCopyID As Long = 0
        Private lngIssueID As Long = 0

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDCopy As New clsDCopy

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' LocationID Property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        ' PubYear Property
        Public Property PubYear() As Integer
            Get
                Return intPubYear
            End Get
            Set(ByVal Value As Integer)
                intPubYear = Value
            End Set
        End Property

        ' Name Property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' ReceivedDate Property
        Public Property ReceivedDate() As String
            Get
                Return strReceivedDate
            End Get
            Set(ByVal Value As String)
                strReceivedDate = Value
            End Set
        End Property

        ' Note Property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' ReceivedCopies Property
        Public Property ReceivedCopies() As Integer
            Get
                Return intReceivedCopies
            End Get
            Set(ByVal Value As Integer)
                intReceivedCopies = Value
            End Set
        End Property

        ' CopyID Property
        Public Property CopyID() As Long
            Get
                Return lngCopyID
            End Get
            Set(ByVal Value As Long)
                lngCopyID = Value
            End Set
        End Property

        ' IssueID Property
        Public Property IssueID() As Long
            Get
                Return lngIssueID
            End Get
            Set(ByVal Value As Long)
                lngIssueID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            Call objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Init objDCopy object
            objDCopy.DBServer = strDBServer
            objDCopy.ConnectionString = strConnectionString
            Call objDCopy.Initialize()
        End Sub

        ' UpdateReceiveDate method
        ' Purpose: update receiveddate of the selected issue
        ' Input: Some main infor of the current copy
        Public Sub UpdateReceiveDate()
            Try
                objDCopy.CopyID = lngCopyID
                objDCopy.Note = Trim(objBCSP.ConvertItBack(strNote))
                objDCopy.ReceivedDate = objBCDBS.ConvertDateBack(strReceivedDate)
                Call objDCopy.UpdateReceiveDate()
                intErrorCode = objDCopy.ErrorCode
                strErrorMsg = objDCopy.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Receive method
        ' Purpose: Receive some copies
        ' Input: some main information of the current issue
        ' Output: 0 if fail
        Public Function Receive() As Integer
            Try
                objDCopy.IssueID = lngIssueID
                objDCopy.LocationID = intLocationID
                objDCopy.ReceivedDate = objBCDBS.ConvertDateBack(Trim(strReceivedDate))
                objDCopy.Note = Trim(objBCSP.ConvertItBack(strNote))
                objDCopy.ReceivedCopies = intReceivedCopies
                Receive = objDCopy.Receive
                intErrorCode = objDCopy.ErrorCode
                strErrorMsg = objDCopy.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UnReceive method
        ' Purpose: UnReceive some issues
        ' Input: IssueID for unreceive
        Public Sub UnReceive(ByVal strCopyIDs As String, ByVal intCount As Integer)
            Try
                objDCopy.IssueID = lngIssueID
                Call objDCopy.UnReceive(strCopyIDs, intCount)
                intErrorCode = objDCopy.ErrorCode
                strErrorMsg = objDCopy.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: Dispose
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDCopy Is Nothing Then
                    objDCopy.Dispose(True)
                    objDCopy = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace