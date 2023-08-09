' Name: clsBSchedule
' Purpose: allow manage Schedule
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:

Imports System
Imports System.Data
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.DataAccess.Circulation

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsBSchedule
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strOffDay As String = ""
        Private strOffYear As String = ""
        Private intLocationID As Integer = 0
        Private strOpen1 As String = ""
        Private strOpen2 As String = ""
        Private strClose1 As String = ""
        Private strClose2 As String = ""
        Private intWeekDay As Int16 = 0

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDSchedule As New clsDSchedule

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' OffDay property
        Public Property OffDay() As String
            Get
                Return strOffDay
            End Get
            Set(ByVal Value As String)
                strOffDay = Value
            End Set
        End Property

        ' OffYear property
        Public Property OffYear() As String
            Get
                Return strOffYear
            End Get
            Set(ByVal Value As String)
                strOffYear = Value
            End Set
        End Property

        ' LocationID property
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        ' Open1 property
        Public Property Open1() As String
            Get
                Return strOpen1
            End Get
            Set(ByVal Value As String)
                strOpen1 = Value
            End Set
        End Property

        ' Open2 property
        Public Property Open2() As String
            Get
                Return strOpen2
            End Get
            Set(ByVal Value As String)
                strOpen2 = Value
            End Set
        End Property

        ' strClose1 property
        Public Property Close1() As String
            Get
                Return strClose1
            End Get
            Set(ByVal Value As String)
                strClose1 = Value
            End Set
        End Property

        ' Close2 property
        Public Property Close2() As String
            Get
                Return strClose2
            End Get
            Set(ByVal Value As String)
                strClose2 = Value
            End Set
        End Property

        ' WeekDay property
        Public Property WeekDay() As Int16
            Get
                Return intWeekDay
            End Get
            Set(ByVal Value As Int16)
                intWeekDay = Value
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

                ' Init objDSchedule object
                objDSchedule.ConnectionString = strConnectionString
                objDSchedule.DBServer = strDBServer
                Call objDSchedule.Initialize()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetWorkingTime method
        ' Purpose: Get WorkingTime of Library
        ' Input:
        ' Output: Datatable result
        Public Function GetWorkingTime() As DataTable
            Try
                objDSchedule.LocationID = intLocationID
                objDSchedule.WeekDay = intWeekDay
                GetWorkingTime = objDSchedule.GetWorkingTime
                intErrorCode = objDSchedule.ErrorCode
                strErrorMsg = objDSchedule.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateWorkingTime method
        ' Purpose: Update WorkingTime of Library
        ' Input: some main information of WorkingTime
        ' Output:
        Public Sub UpdateWorkingTime()
            Try
                objDSchedule.LocationID = intLocationID
                objDSchedule.WeekDay = intWeekDay
                objDSchedule.Open1 = strOpen1
                objDSchedule.Close1 = strClose1
                objDSchedule.Open2 = strOpen2
                objDSchedule.Close2 = strClose2
                objDSchedule.UpdateWorkingTime()
                strErrorMsg = objDSchedule.ErrorMsg
                intErrorCode = objDSchedule.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' UpdateSchedule method
        ' Purpose: update new schedule of Library
        ' Input: main information of new schedule
        Public Sub UpdateSchedule()
            Try
                objDSchedule.LocationID = intLocationID
                objDSchedule.OffDay = strOffDay
                objDSchedule.UpdateSchedule()
                strErrorMsg = objDSchedule.ErrorMsg
                intErrorCode = objDSchedule.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' UpdateSchedule method
        ' Purpose: update new schedule of Library
        ' Input: main information of new schedule
        Public Sub DeleteSchedule()
            Try
                objDSchedule.LocationID = intLocationID
                objDSchedule.OffYear = strOffYear
                objDSchedule.DeleteSchedule()
                strErrorMsg = objDSchedule.ErrorMsg
                intErrorCode = objDSchedule.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetSchedule method
        ' Purpose: get schedule of Library
        ' Input: 
        ' Output: datatable result
        Public Function GetSchedule(ByVal IsShowTime As Boolean) As DataTable
            Try
                objDSchedule.LocationID = intLocationID
                objDSchedule.OffDay = objBCDBS.ConvertDateBack(strOffDay)
                GetSchedule = objDSchedule.GetSchedule
                intErrorCode = objDSchedule.ErrorCode
                strErrorMsg = objDSchedule.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' IsOffDay method
        ' Purpose: check input day is offday
        ' Input: strCurrentDay
        ' Output: datatable result
        Public Function IsOffDay(ByVal strCurrentDay As String) As Boolean
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


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
                If Not objDSchedule Is Nothing Then
                    objDSchedule.Dispose(True)
                    objDSchedule = Nothing
                End If
            End If
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace