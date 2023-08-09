Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.DataAccess.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBItemDissertation
        Inherits clsBBase

        Private objDItemDissertation As New clsDItemDissertation

        Private intItemDissertationID As Int16 = 0
        Private intItemID As Integer = 0
        Private intCountPages As Integer = 0
        Private strNumber As String = ""
        Private intYear As Integer = 0
        Private strPathImage As String = ""
        Private strPathFile As String = ""
        Private strContent As String = ""
        Private strDateFrom As String = ""
        Private strDateTo As String = ""


        Public Property Content() As String
            Get
                Return strContent
            End Get
            Set(ByVal Value As String)
                strContent = Value
            End Set
        End Property
        Public Property DateFrom() As String
            Get
                Return strDateFrom
            End Get
            Set(ByVal Value As String)
                strDateFrom = Value
            End Set
        End Property
        Public Property DateTo() As String
            Get
                Return strDateTo
            End Get
            Set(ByVal Value As String)
                strDateTo = Value
            End Set
        End Property

        Public Property ItemDissertationID() As Int16
            Get
                Return intItemDissertationID
            End Get
            Set(ByVal Value As Int16)
                intItemDissertationID = Value
            End Set
        End Property
        Public Property CountPages() As Integer
            Get
                Return intCountPages
            End Get
            Set(ByVal Value As Integer)
                intCountPages = Value
            End Set
        End Property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        Public Property Number() As String
            Get
                Return strNumber
            End Get
            Set(ByVal Value As String)
                strNumber = Value
            End Set
        End Property
        Public Property Year() As Integer
            Get
                Return intYear
            End Get
            Set(ByVal Value As Integer)
                intYear = Value
            End Set
        End Property
        Public Property PathImage() As String
            Get
                Return strPathImage
            End Get
            Set(ByVal Value As String)
                strPathImage = Value
            End Set
        End Property
        Public Property PathFile() As String
            Get
                Return strPathFile
            End Get
            Set(ByVal Value As String)
                strPathFile = Value
            End Set
        End Property
        Public Function GetListItemDissertation() As DataTable
            Try
                Dim result As DataTable = objDItemDissertation.GetListItemDissertation()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetItemDissertationById() As DataTable
            Try
                objDItemDissertation.ItemDissertationID = intItemDissertationID
                Dim result As DataTable = objDItemDissertation.GetItemDissertationById()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function

        Public Function GetItemDissertationByItemId() As DataTable
            Try
                objDItemDissertation.ItemID = intItemID
                Dim result As DataTable = objDItemDissertation.GetItemDissertationByItemId()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetListItemDissertation(Optional ByVal strTitle As String = "", Optional ByVal strNumber As String = "", Optional ByVal intYear As Integer = 0) As DataTable
            Try
                Dim result As DataTable = objDItemDissertation.GetListItemDissertation(strTitle, strNumber, intYear)
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetItemDissertationByNumberAndYear() As DataTable
            Try
                objDItemDissertation.ItemID = intItemID
                objDItemDissertation.Number = strNumber
                objDItemDissertation.Year = intYear
                Dim result As DataTable = objDItemDissertation.GetItemDissertationByNumberAndYear()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetItemDissertationAll() As DataTable
            Try
                objDItemDissertation.Content = strContent
                objDItemDissertation.DateFrom = strDateFrom
                objDItemDissertation.DateTo = strDateTo
                objDItemDissertation.Number = strNumber
                Dim result As DataTable = objDItemDissertation.GetItemDissertationAll()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function CheckItemDissertationByNumberAndYear() As DataTable
            Try
                objDItemDissertation.ItemDissertationID = intItemDissertationID
                objDItemDissertation.ItemID = intItemID
                objDItemDissertation.Number = strNumber
                objDItemDissertation.Year = intYear
                Dim result As DataTable = objDItemDissertation.CheckItemDissertationByNumberAndYear()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function CreateItemDissertation() As Integer
            Try
                objDItemDissertation.ItemID = intItemID
                objDItemDissertation.Number = strNumber
                objDItemDissertation.Year = intYear
                objDItemDissertation.PathImage = strPathImage
                objDItemDissertation.PathFile = strPathFile
                objDItemDissertation.CountPages = intCountPages
                Dim result As Integer = objDItemDissertation.CreateItemDissertation()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return -1
            End Try
        End Function

        Public Function UpdateItemDissertation() As Integer
            Try
                objDItemDissertation.ItemDissertationID = intItemDissertationID
                objDItemDissertation.ItemID = intItemID
                objDItemDissertation.Number = strNumber
                objDItemDissertation.Year = intYear
                objDItemDissertation.PathImage = strPathImage
                objDItemDissertation.PathFile = strPathFile
                objDItemDissertation.CountPages = intCountPages
                Dim result As Integer = objDItemDissertation.UpdateItemDissertation()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return -1
            End Try
        End Function
        Public Function UpdateItemDissertation_CountPage() As Integer
            Try
                objDItemDissertation.ItemDissertationID = intItemDissertationID
                objDItemDissertation.CountPages = intCountPages
                Dim result As Integer = objDItemDissertation.UpdateItemDissertation_CountPage()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return -1
            End Try
        End Function
        Public Function DeleteItemDissertation() As Integer
            Try
                objDItemDissertation.ItemDissertationID = intItemDissertationID
                Dim result As Integer = objDItemDissertation.DeleteItemDissertation()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return -1
            End Try
        End Function
        Public Sub Initialize()
            Try
                ' Init objDLoanTypeOther object
                objDItemDissertation.ConnectionString = strConnectionString
                objDItemDissertation.DBServer = strDBServer
                Call objDItemDissertation.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDItemDissertation Is Nothing Then
                    objDItemDissertation.Dispose(True)
                    objDItemDissertation = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class

End Namespace
