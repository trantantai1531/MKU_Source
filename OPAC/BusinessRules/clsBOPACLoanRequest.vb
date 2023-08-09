Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACLoanRequest
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intPatronID As Integer
        Private intItemID As Integer
        Private strCopyNumber As String

        Private objDOPACLoanRequest As New clsDOPACLoanRequest
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' PatronID property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        ' CopyNumber property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACLoanRequest object
            objDOPACLoanRequest.DBServer = strDBServer
            objDOPACLoanRequest.ConnectionString = strConnectionString
            objDOPACLoanRequest.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        ' Purpose: Renew
        ' Input: 
        ' Output: 
        ' Created by:
        Public Function Renew(ByVal intLoanID As Integer) As Integer
            Try
                Dim result As Integer = objDOPACLoanRequest.Renew(intLoanID)
                intErrorCode = objDOPACLoanRequest.ErrorCode
                strErrorMsg = objDOPACLoanRequest.ErrorMsg
                Return result
            Catch ex As Exception
                intErrorCode = objDOPACLoanRequest.ErrorCode
                strErrorMsg = objDOPACLoanRequest.ErrorMsg
                Return 0
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACLoanRequest Is Nothing Then
                    Call objDOPACLoanRequest.Dispose(True)
                    objDOPACLoanRequest = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace