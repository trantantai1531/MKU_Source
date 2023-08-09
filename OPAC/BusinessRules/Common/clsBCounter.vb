Imports System
Imports eMicLibOPAC.DataAccess.Common
Imports System.Text
Imports System.Web

Namespace eMicLibOPAC.BusinessRules.Common
    Public Class clsBCounter
        Inherits clsBBase
        Protected intID As Integer
        Protected strIPAddress As String
        Protected strValidDate As DateTime
        Protected strCode      As String

        Dim objDCounter As New clsDCounter
        '' PatronCode
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property
        ' ID property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' IPAddress property
        Public Property IPAddress() As String
            Get
                Return strIPAddress
            End Get
            Set(ByVal Value As String)
                strIPAddress = Value
            End Set
        End Property

        ' ValidDate property
        Public Property ValidDate() As DateTime
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As DateTime)
                strValidDate = Value
            End Set
        End Property

        Public Sub Initialize()
            ' Init objDUser object
            objDCounter.DBServer = strDBServer
            objDCounter.ConnectionString = strConnectionString
            objDCounter.Initialize()
        End Sub

        Public Sub InsertLoginCounter()
            Try
                objDCounter.Code = strCode
                objDCounter.ValidDate = Date.Now
                objDCounter.InsertLoginCounter()
            Catch ex As Exception
                strErrorMsg = Ex.Message
            End Try
        End Sub
        Public Sub InsertCounter()
            Try
                objDCounter.IPAddress = strIPAddress
                objDCounter.ValidDate = Date.Now
                objDCounter.InsertCounter()
                strErrorMsg = objDCounter.ErrorMsg
                intErrorCode = objDCounter.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        Public Function GetCounterTotal() As Integer
            Try
                Dim dtResult As DataTable = objDCounter.GetCounterTotal()
                If Not dtResult Is Nothing Then
                    GetCounterTotal = Integer.Parse(dtResult.Rows(0).Item("Total").ToString())
                End If
                strErrorMsg = objDCounter.ErrorMsg
                intErrorCode = objDCounter.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
                GetCounterTotal = 0
            Finally
            End Try
        End Function

        Public Function GetCounterLastDay() As Integer
            Try
                Dim dtResult As DataTable = objDCounter.GetCounterLastDay()
                If Not dtResult Is Nothing Then
                    GetCounterLastDay = Integer.Parse(dtResult.Rows(0).Item("Total").ToString())
                End If
                strErrorMsg = objDCounter.ErrorMsg
                intErrorCode = objDCounter.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
                GetCounterLastDay = 0
            Finally
            End Try
        End Function

        Public Function GetCounterLastWeek() As Integer
            Try
                Dim dtResult As DataTable = objDCounter.GetCounterLastWeek()
                If Not dtResult Is Nothing Then
                    GetCounterLastWeek = Integer.Parse(dtResult.Rows(0).Item("Total").ToString())
                End If
                strErrorMsg = objDCounter.ErrorMsg
                intErrorCode = objDCounter.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
                GetCounterLastWeek = 0
            Finally
            End Try
        End Function

        Public Function GetCounterLastMonth() As Integer
            Try
                Dim dtResult As DataTable = objDCounter.GetCounterLastMonth()
                If Not dtResult Is Nothing Then
                    GetCounterLastMonth = Integer.Parse(dtResult.Rows(0).Item("Total").ToString())
                End If
                strErrorMsg = objDCounter.ErrorMsg
                intErrorCode = objDCounter.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
                GetCounterLastMonth = 0
            Finally
            End Try
        End Function
    End Class
End Namespace
