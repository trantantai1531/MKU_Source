' Name: clsBBaseTransaction
' Purpose: Based for another transaction
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBBaseTransaction
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Protected strTransactionDate As String = ""
        Protected strPatronCode As String = ""
        Protected strCopyNumber As String = ""
        Protected strTitle As String = ""
        Protected lngItemID As Long = 0
        Protected lngLocationID As Long = 0
        Protected lngPatronID As Long = 0
        Protected lngTransactionID As Long = 0
        Protected strTransactionIDs As String = ""

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDBaseTransaction As New clsDBaseTransaction

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' TransactionDate property
        Public Property TransactionDate() As String
            Get
                Return strTransactionDate
            End Get
            Set(ByVal Value As String)
                strTransactionDate = Value
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

        ' CopyNumber property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' ItemID property
        Public Property ItemID() As Long
            Get
                Return lngItemID
            End Get
            Set(ByVal Value As Long)
                lngItemID = Value
            End Set
        End Property

        ' LocationID property
        Public Property LocationID() As Long
            Get
                Return lngLocationID
            End Get
            Set(ByVal Value As Long)
                lngLocationID = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Long
            Get
                Return lngPatronID
            End Get
            Set(ByVal Value As Long)
                lngPatronID = Value
            End Set
        End Property

        ' TransactionID property
        Public Property TransactionID() As Long
            Get
                Return lngTransactionID
            End Get
            Set(ByVal Value As Long)
                lngTransactionID = Value
            End Set
        End Property

        ' TransactionIDs property
        Public Property TransactionIDs() As String
            Get
                Return strTransactionIDs
            End Get
            Set(ByVal Value As String)
                strTransactionIDs = Value
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

                ' Init objDBaseTransaction object
                objDBaseTransaction.ConnectionString = strConnectionString
                objDBaseTransaction.DBServer = strDBServer
                Call objDBaseTransaction.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' CheckPatronCode method
        ' Purpose: Check PatronCode
        ' Input: string value of PatronCode
        ' Output:
        '   -- 0: OK
        '   -- 2: Card expired
        '   -- 3: Quota exceeded (Loan in lib)
        '   -- 4: Card is locked
        '   -- 5: Patron doesn't has access permission to one of the locations which this librarian has manage permission
        '   -- 6: Quota exceeded (Loan out of quota)
        Public Function CheckPatronCode(Optional ByVal intLoanMode As Int16 = 0) As Int16
            Try
                objDBaseTransaction.UserID = intUserID
                objDBaseTransaction.PatronCode = Trim(strPatronCode)
                objDBaseTransaction.LibID = intLibID
                CheckPatronCode = objDBaseTransaction.CheckPatronCode(intLoanMode)
                strErrorMsg = objDBaseTransaction.ErrorMsg
                intErrorCode = objDBaseTransaction.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CheckCopyNumber method
        ' Purpose: CheckCopyNumber
        ' Input: CopyNumber, PatronCode, UserID
        ' Output: 
        '   -- 0: OK
        '   -- 1: Copynumber doesn't exists
        '   -- 2: Copynumber is locked or not in circulation
        '   -- 3: Copynumber is on load
        '   -- 4: Copynumber is on hold
        '   -- 5: Librarian has not permission to manage location of the CopyNumber
        '   -- 6: Librarian has not permission to manage location of Patron
        Public Function CheckCopyNumber() As Int16
            Try
                objDBaseTransaction.UserID = intUserID
                objDBaseTransaction.PatronCode = Trim(strPatronCode)
                objDBaseTransaction.CopyNumber = Trim(strCopyNumber)
                CheckCopyNumber = objDBaseTransaction.CheckCopyNumber()
                strErrorMsg = objDBaseTransaction.ErrorMsg
                intErrorCode = objDBaseTransaction.ErrorCode
                'Catch ex As Exception
                '    strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetGroupPolicy method
        ' Purpose: Get policy infor of PatronGroup
        ' Input: string value of PatronCode
        ' Output: 
        Public Function GetGroupPolicy() As DataTable
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDBaseTransaction Is Nothing Then
                    objDBaseTransaction.Dispose(True)
                    objDBaseTransaction = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
