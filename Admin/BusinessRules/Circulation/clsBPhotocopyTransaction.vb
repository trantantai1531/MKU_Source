Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBPhotocopyTransaction
        Inherits clsBBase

        ' ***************************************************************************************************
        ' Declare member variables
        ' ***************************************************************************************************

        Private intTransactionID As Integer = 0
        Private intPageCount As Integer = 0
        Private strPageDetail As String = ""
        Private dblAmount As Double = 0
        Private dblPaidAmount As Double = 0
        Private intItemID As Integer = 0
        Private strInputer As String = ""
        Private bytDone As Byte = 2
        Private intTypePaperID As Integer = 0
        Private strTransactionDate As String = ""
        Private strPatronCode As String = ""
        Private strCopyNumber As String = ""
        Private strTitle As String = ""

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDPhotoTran As New clsDPhotocopyTransaction

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        Public Property TransactionID() As Integer
            Get
                Return intTransactionID
            End Get
            Set(ByVal Value As Integer)
                intTransactionID = Value
            End Set
        End Property

        ' PageCount property
        Public Property PageCount() As Integer
            Get
                Return intPageCount
            End Get
            Set(ByVal Value As Integer)
                intPageCount = Value
            End Set
        End Property

        ' PageDetail property
        Public Property PageDetail() As String
            Get
                Return strPageDetail
            End Get
            Set(ByVal Value As String)
                strPageDetail = Value
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

        ' PaidAmount property
        Public Property PaidAmount() As Double
            Get
                Return dblPaidAmount
            End Get
            Set(ByVal Value As Double)
                dblPaidAmount = Value
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

        ' Inputer property
        Public Property Inputer() As String
            Get
                Return strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
            End Set
        End Property

        ' Done property
        Public Property Done() As Byte
            Get
                Return bytDone
            End Get
            Set(ByVal Value As Byte)
                bytDone = Value
            End Set
        End Property

        ' TypePayerID property
        Public Property TypePayerID() As Integer
            Get
                Return intTypePaperID
            End Get
            Set(ByVal Value As Integer)
                intTypePaperID = Value
            End Set
        End Property

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

        ' ***************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***************************************************************************************************

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            Try
                ' Init objBCSP object
                objBCSP.ConnectionString = strConnectionString
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                Call objBCSP.Initialize()

                objDPhotoTran.ConnectionString = strConnectionString
                objDPhotoTran.DBServer = strDBServer
                objDPhotoTran.Initialize()

                ' Init objBCDBS object
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub CreatePhotocopyOrder(ByVal strCreateDate As String)
            objDPhotoTran.TypePaperID = intTypePaperID
            objDPhotoTran.Amount = dblAmount
            objDPhotoTran.PaidAmount = dblPaidAmount
            objDPhotoTran.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
            objDPhotoTran.Inputer = objBCSP.ConvertItBack(strInputer)
            objDPhotoTran.Done = bytDone
            objDPhotoTran.PageCount = intPageCount
            objDPhotoTran.PageDetail = objBCSP.ConvertItBack(strPageDetail)
            objDPhotoTran.PatronCode = objBCSP.ConvertItBack(strPatronCode)
            objDPhotoTran.UserID = intUserID
            objDPhotoTran.CreatePhotocopyOrder(objBCDBS.ConvertDateBack(strCreateDate))
        End Sub

        Public Function GetPhotocopyOrders(ByVal strFromCreateDate As String, ByVal strToCreateDate As String) As DataTable
            Dim strFrom As String
            Dim strTo As String
            Dim tblResutl As DataTable
            Dim inti As Integer

            strFrom = objBCDBS.ConvertDateBack(strFromCreateDate)
            strTo = objBCDBS.ConvertDateBack(strToCreateDate)
            objDPhotoTran.TransactionID = intTransactionID
            objDPhotoTran.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
            objDPhotoTran.Done = bytDone
            objDPhotoTran.Inputer = objBCSP.ConvertItBack(strInputer)
            objDPhotoTran.PatronCode = objBCSP.ConvertItBack(strPatronCode)
            objDPhotoTran.UserID = intUserID
            tblResutl = objBCDBS.ConvertTable(objDPhotoTran.GetPhotocopyOrders(strFrom, strTo))
            If Not tblResutl Is Nothing AndAlso tblResutl.Rows.Count > 0 Then
                For inti = 0 To tblResutl.Rows.Count - 1
                    tblResutl.Rows(inti).Item("Amount") = CLng(tblResutl.Rows(inti).Item("Amount"))
                    tblResutl.Rows(inti).Item("PaidAmount") = CLng(tblResutl.Rows(inti).Item("PaidAmount"))
                Next
            End If
            GetPhotocopyOrders = tblResutl
        End Function

        Public Sub UpdatePhotocopyOrder()
            objDPhotoTran.TransactionID = intTransactionID
            objDPhotoTran.TypePaperID = intTypePaperID
            objDPhotoTran.Amount = dblAmount
            objDPhotoTran.PaidAmount = dblPaidAmount
            objDPhotoTran.CopyNumber = objBCSP.ConvertItBack(strCopyNumber)
            objDPhotoTran.Inputer = objBCSP.ConvertItBack(strInputer)
            objDPhotoTran.Done = bytDone
            objDPhotoTran.PageCount = intPageCount
            objDPhotoTran.PageDetail = objBCSP.ConvertItBack(strPageDetail)
            objDPhotoTran.PatronCode = objBCSP.ConvertItBack(strPatronCode)
            objDPhotoTran.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
            objDPhotoTran.UpdatePhotocopyOrder()
        End Sub

        ' DeletePhotocopyOrder method
        ' Purpose: Update information if the selected PhotocopyOrder
        ' Input: intTransactionID
        Public Sub DeletePhotocopyOrder()
            Try

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
                If Not objDPhotoTran Is Nothing Then
                    objDPhotoTran.Dispose(True)
                    objDPhotoTran = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
