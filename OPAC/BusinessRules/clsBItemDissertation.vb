
Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBItemDissertation
        Inherits clsBBase

        Private objDItemDissertation As New clsDItemDissertation

        Private intItemDissertationID As Int16 = 0
        Private intItemID As Integer = 0
        Private strNumber As String = ""
        Private intYear As Integer = 0
        Private strPathImage As String = ""
        Private strPathFile As String = ""

        Public Property ItemDissertationID() As Int16
            Get
                Return intItemDissertationID
            End Get
            Set(ByVal Value As Int16)
                intItemDissertationID = Value
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
        Public Function GetItemDissertationYear() As DataTable
            Try
                objDItemDissertation.ItemID = intItemID
                Dim result As DataTable = objDItemDissertation.GetItemDissertationYear()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetItemDissertationNumber() As DataTable
            Try
                objDItemDissertation.ItemID = intItemID
                objDItemDissertation.Year = intYear
                Dim result As DataTable = objDItemDissertation.GetItemDissertationNumber()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetItemDissertation() As DataTable
            Try
                objDItemDissertation.ItemID = intItemID
                objDItemDissertation.Year = intYear
                objDItemDissertation.Number = strNumber
                Dim result As DataTable = objDItemDissertation.GetItemDissertation()
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDItemDissertation.ErrorMsg
                intErrorCode = objDItemDissertation.ErrorCode
                Return New DataTable
            End Try
        End Function
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
