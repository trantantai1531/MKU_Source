Imports System
Imports System.Data
Imports System.Data.OleDb
Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBCheckExistItem1
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private objDCheckExistItem As New clsDCheckExistItem
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        Private strTitle As String
        Private intID As Integer
        Private strIDs As String

        ' *****************************************************************************************************
        ' Public Properties
        ' *****************************************************************************************************

        ' ---- Title Property
        Public Property Title()
            Get
                Return strTitle
            End Get
            Set(ByVal Value)
                strTitle = Value
            End Set
        End Property

        ' ---- IDs Property
        Public Property IDs()
            Get
                Return strIDs
            End Get
            Set(ByVal Value)
                strIDs = Value
            End Set
        End Property

        ' ---- ID Property
        Public Property ID()
            Get
                Return intID
            End Get
            Set(ByVal Value)
                intID = Value
            End Set
        End Property

        ' *******************************************************************************************************
        ' Methods here
        ' *******************************************************************************************************

        ' ---- Set parameters
        Public Sub Initialize()
            ' ---- clsDDicVendor' Properties
            objDCheckExistItem.DBServer = strDBServer
            objDCheckExistItem.ConnectionString = strConnectionString
            objDCheckExistItem.Initialize()

            ' ---- objBCDBS' Properties
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' ---- objBCSP' Properties
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()
        End Sub

        '   Retrieve data 
        '   Intput: 
        '   Output: DataSet
        Public Function RetrieveItemRequest() As DataTable
            Try
                objDCheckExistItem.ID = intID
                RetrieveItemRequest = objBCDBS.ConvertTable(objDCheckExistItem.RetrieveItemRequest)
                strSql = objDCheckExistItem.SQL
                strErrorMsg = objDCheckExistItem.ErrorMsg
                intErrorCode = objDCheckExistItem.ErrorCode
                If strErrorMsg = "" Then
                    Dim Exp As New Exception
                    strErrorMsg = Exp.Message.ToString
                End If
            Finally
            End Try
        End Function


        '   Retrieve data 
        '   Intput: 
        '   Output: DataSet
        Public Function RetrieveItemAvailable() As DataTable
            Try
                objDCheckExistItem.IDs = strIDs
                RetrieveItemAvailable = objBCDBS.ConvertTable(objDCheckExistItem.RetrieveItemAvailable)
                strSql = objDCheckExistItem.SQL
                strErrorMsg = objDCheckExistItem.ErrorMsg
                intErrorCode = objDCheckExistItem.ErrorCode
                If strErrorMsg = "" Then
                    Dim Exp As New Exception
                    strErrorMsg = Exp.Message.ToString
                End If
            Finally
            End Try
        End Function

        '   Retrieve data 
        '   Intput: 
        '   Output: DataSet
        Public Function RetrieveItemOrdered() As DataTable
            Try
                objDCheckExistItem.Title = objBCSP.ConvertItBack(strTitle)
                RetrieveItemOrdered = objBCDBS.ConvertTable(objDCheckExistItem.RetrieveItemOrdered)
                strSql = objBCSP.ConvertIt(objDCheckExistItem.SQL)
                strErrorMsg = objDCheckExistItem.ErrorMsg
                intErrorCode = objDCheckExistItem.ErrorCode
                If strErrorMsg = "" Then
                    Dim Exp As New Exception
                    strErrorMsg = Exp.Message.ToString
                End If
            Finally
            End Try
        End Function

        '   Retrieve data 
        '   Intput: 
        '   Output: DataSet
        Public Function RetrieveLoanHistory() As DataTable
            Try
                objDCheckExistItem.IDs = strIDs
                objDCheckExistItem.SQL = strSql
                RetrieveLoanHistory = objBCDBS.ConvertTable(objDCheckExistItem.RetrieveLoanHistory)
                strErrorMsg = objDCheckExistItem.ErrorMsg
                intErrorCode = objDCheckExistItem.ErrorCode
                If strErrorMsg = "" Then
                    Dim Exp As New Exception
                    strErrorMsg = Exp.Message.ToString
                End If
            Finally
            End Try
        End Function

        '   Retrieve data 
        '   Intput: 
        '   Output: DataSet
        Public Function RetrieveItemCount() As DataTable
            Try
                objDCheckExistItem.IDs = strIDs
                RetrieveItemCount = objBCDBS.ConvertTable(objDCheckExistItem.RetrieveItemCount)
                strSql = objDCheckExistItem.SQL
                strErrorMsg = objDCheckExistItem.ErrorMsg
                intErrorCode = objDCheckExistItem.ErrorCode
                If strErrorMsg = "" Then
                    Dim Exp As New Exception
                    strErrorMsg = Exp.Message.ToString
                End If
            Finally
            End Try
        End Function

        Public Function CheckExitItem(ByVal strTitle As String, ByVal strAuthor As String, ByVal intPublishYear As Integer) As Integer
            Return objDCheckExistItem.CheckExitItem(strTitle, strAuthor, intPublishYear)
        End Function

        ' ****************************** Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    ' Dispose manage resource
                End If
                ' Release unmanaged resources.
                If Not objDCheckExistItem Is Nothing Then
                    ' Call Dispose on your class on DataAccess Layer.
                    objDCheckExistItem.Dispose(True)
                    objDCheckExistItem = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                ' Call Dispose on your base class.
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace