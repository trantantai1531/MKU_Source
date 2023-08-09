Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBLoanTypeSemester
        Inherits clsBBase

        Private objDLoanTypeSemester As New clsDLoanTypeSemester

        Private intLoanTypeSemesterID As Int16 = 0
        Private intSemester As Integer = 0
        Private intDayFrom As Integer = 0
        Private intMonthFrom As Integer = 0
        Private intDayTo As Integer = 0
        Private intMonthTo As Integer = 0
        Private intYearFrom As Integer = 0
        Private intYearTo As Integer = 0


        Public Property LoanTypeSemesterID() As Int16
            Get
                Return intLoanTypeSemesterID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeSemesterID = Value
            End Set
        End Property
        Public Property Semester() As Integer
            Get
                Return intSemester
            End Get
            Set(ByVal Value As Integer)
                intSemester = Value
            End Set
        End Property
        Public Property DayFrom() As Integer
            Get
                Return intDayFrom
            End Get
            Set(ByVal Value As Integer)
                intDayFrom = Value
            End Set
        End Property
        Public Property DayTo() As Integer
            Get
                Return intDayTo
            End Get
            Set(ByVal Value As Integer)
                intDayTo = Value
            End Set
        End Property
        Public Property MonthFrom() As Integer
            Get
                Return intMonthFrom
            End Get
            Set(ByVal Value As Integer)
                intMonthFrom = Value
            End Set
        End Property
        Public Property MonthTo() As Integer
            Get
                Return intMonthTo
            End Get
            Set(ByVal Value As Integer)
                intMonthTo = Value
            End Set
        End Property
        Public Property YearFrom() As Integer
            Get
                Return intYearFrom
            End Get
            Set(ByVal Value As Integer)
                intYearFrom = Value
            End Set
        End Property
        Public Property YearTo() As Integer
            Get
                Return intYearTo
            End Get
            Set(ByVal Value As Integer)
                intYearTo = Value
            End Set
        End Property
        Public Function GetListLoanTypeSemester() As DataTable
            Try
                Dim result As DataTable = objDLoanTypeSemester.GetListLoanTypeSemester()
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetLoanTypeSemesterById() As DataTable
            Try
                objDLoanTypeSemester.LoanTypeSemesterID = intLoanTypeSemesterID
                Dim result As DataTable = objDLoanTypeSemester.GetLoanTypeSemesterById()
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetLoanTypeSemesterBySemester() As DataTable
            Try
                objDLoanTypeSemester.Semester = intSemester
                Dim result As DataTable = objDLoanTypeSemester.GetLoanTypeSemesterBySemester()
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function GetLoanTypeSemesterByIdAndSemester() As DataTable
            Try
                objDLoanTypeSemester.LoanTypeSemesterID = intLoanTypeSemesterID
                objDLoanTypeSemester.Semester = intSemester
                Dim result As DataTable = objDLoanTypeSemester.GetLoanTypeSemesterByIdAndSemester()
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return New DataTable
            End Try
        End Function
        Public Function CreateLoanTypeSemester() As Integer
            Try
                objDLoanTypeSemester.DayFrom = intDayFrom
                objDLoanTypeSemester.Semester = intSemester
                objDLoanTypeSemester.MonthFrom = intMonthFrom
                objDLoanTypeSemester.YearFrom = intYearFrom
                objDLoanTypeSemester.DayTo = intDayTo
                objDLoanTypeSemester.MonthTo = intMonthTo
                objDLoanTypeSemester.YearTo = intYearTo
                Dim result As Integer = objDLoanTypeSemester.CreateLoanTypeSemester()
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return -1
            End Try
        End Function

        Public Function UpdateLoanTypeSemester() As Integer
            Try
                objDLoanTypeSemester.LoanTypeSemesterID = intLoanTypeSemesterID
                objDLoanTypeSemester.DayFrom = intDayFrom
                objDLoanTypeSemester.Semester = intSemester
                objDLoanTypeSemester.MonthFrom = intMonthFrom
                objDLoanTypeSemester.YearFrom = intYearFrom
                objDLoanTypeSemester.DayTo = intDayTo
                objDLoanTypeSemester.MonthTo = intMonthTo
                objDLoanTypeSemester.YearTo = intYearTo
                Dim result As Integer = objDLoanTypeSemester.UpdateLoanTypeSemester()
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return -1
            End Try
        End Function
        Public Function DeleteLoanTypeSemester() As Integer
            Try
                objDLoanTypeSemester.LoanTypeSemesterID = intLoanTypeSemesterID
                Dim result As Integer = objDLoanTypeSemester.DeleteLoanTypeSemester()
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return result
            Catch ex As Exception
                strErrorMsg = objDLoanTypeSemester.ErrorMsg
                intErrorCode = objDLoanTypeSemester.ErrorCode
                Return -1
            End Try
        End Function
        Public Sub Initialize()
            Try
                ' Init objDLoanTypeOther object
                objDLoanTypeSemester.ConnectionString = strConnectionString
                objDLoanTypeSemester.DBServer = strDBServer
                Call objDLoanTypeSemester.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If isDisposing Then
                If Not objDLoanTypeSemester Is Nothing Then
                    objDLoanTypeSemester.Dispose(True)
                    objDLoanTypeSemester = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
