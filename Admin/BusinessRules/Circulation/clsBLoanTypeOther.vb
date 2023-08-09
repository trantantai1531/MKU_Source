Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBLoanTypeOther
        Inherits clsBBase

        Private objDLoanTypeOther As New clsDLoanTypeOther

        Private intLoanTypeOtherID As Int16 = 0
        Private dateStart As DateTime = New DateTime
        Private dateEnd As DateTime = New DateTime
        Private dateExpired As DateTime = New DateTime
        Private intLoanTypeID As Int16 = 0

        Public Property LoanTypeOtherID() As Int16
            Get
                Return intLoanTypeOtherID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeOtherID = Value
            End Set
        End Property
        Public Property DateStartLoanType() As DateTime
            Get
                Return dateStart
            End Get
            Set(value As DateTime)
                dateStart = value
            End Set
        End Property
        Public Property DateEndLoanType() As DateTime
            Get
                Return dateEnd
            End Get
            Set(value As DateTime)
                dateEnd = value
            End Set
        End Property
        Public Property DateExpiredLoanType() As DateTime
            Get
                Return dateExpired
            End Get
            Set(value As DateTime)
                dateExpired = value
            End Set
        End Property
        Public Property LoanTypeID() As Int16
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeID = Value
            End Set
        End Property

        Public Function GetListLoanTypeOther() As DataTable
            Try
                Dim result As DataTable = objDLoanTypeOther.GetListLoanTypeOther()
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetLoanTypeOtherById() As DataTable
            Try
                objDLoanTypeOther.LoanTypeOtherID = intLoanTypeOtherID
                Dim result As DataTable = objDLoanTypeOther.GetLoanTypeOtherById()
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetLoanTypeOtherByLoanTypeId() As DataTable
            Try
                objDLoanTypeOther.LoanTypeID = intLoanTypeID
                Dim result As DataTable = objDLoanTypeOther.GetLoanTypeOtherByLoanTypeId()
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function CreateLoanTypeOther() As Integer
            Try
                objDLoanTypeOther.DateStartLoanType = dateStart
                objDLoanTypeOther.DateEndLoanType = dateEnd
                objDLoanTypeOther.DateExpiredLoanType = dateExpired
                objDLoanTypeOther.LoanTypeID = intLoanTypeID
                Dim result As Integer = objDLoanTypeOther.CreateLoanTypeOther()
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return -1
            End Try
        End Function

        Public Function UpdateLoanTypeOther() As Integer
            Try
                objDLoanTypeOther.LoanTypeOtherID = intLoanTypeOtherID
                objDLoanTypeOther.DateStartLoanType = dateStart
                objDLoanTypeOther.DateEndLoanType = dateEnd
                objDLoanTypeOther.DateExpiredLoanType = dateExpired
                objDLoanTypeOther.LoanTypeID = intLoanTypeID
                Dim result As Integer = objDLoanTypeOther.UpdateLoanTypeOther()
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return -1
            End Try
        End Function
        Public Function DeleteLoanTypeOther() As Integer
            Try
                objDLoanTypeOther.LoanTypeOtherID = intLoanTypeOtherID
                Dim result As Integer = objDLoanTypeOther.DeleteLoanTypeOther()
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeOther.ErrorMsg
                intErrorCode = objDLoanTypeOther.ErrorCode
                Return -1
            End Try
        End Function
        Public Sub Initialize()
            Try
                ' Init objDLoanTypeOther object
                objDLoanTypeOther.ConnectionString = strConnectionString
                objDLoanTypeOther.DBServer = strDBServer
                Call objDLoanTypeOther.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDLoanTypeOther Is Nothing Then
                    objDLoanTypeOther.Dispose(True)
                    objDLoanTypeOther = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
