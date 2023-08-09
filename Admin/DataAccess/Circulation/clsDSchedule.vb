' Name: clsDSchedule
' Purpose: allow manage Schedule
' Creator: Oanhtn
' CreatedDate: 16/08/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDSchedule
        Inherits clsDBase

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

        ' GetWorkingTime method
        ' Purpose: Get WorkingTime of Library
        ' Input: intLocationID, intWeekDay
        ' Output: Datatable result
        Public Function GetWorkingTime() As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_GETWORKINGTIME"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                                .Parameters.Add(New OracleParameter("intWeekDay", OracleType.Number)).Value = intWeekDay
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                GetWorkingTime = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_spOpenHour_SelWorkingTime"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                                .Parameters.Add(New SqlParameter("@intWeekDay", SqlDbType.Int)).Value = intWeekDay
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblResult")
                                GetWorkingTime = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
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
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_UPDATE_WORKINGTIME"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                                .Parameters.Add(New OracleParameter("intWeekDay", OracleType.Number)).Value = intWeekDay
                                .Parameters.Add(New OracleParameter("strOpen1", OracleType.VarChar, 4)).Value = strOpen1
                                .Parameters.Add(New OracleParameter("strClose1", OracleType.VarChar, 4)).Value = strClose1
                                .Parameters.Add(New OracleParameter("strOpen2", OracleType.VarChar, 4)).Value = strOpen2
                                .Parameters.Add(New OracleParameter("strClose2", OracleType.VarChar, 4)).Value = strClose2
                                .ExecuteNonQuery()
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_spWorkingTime_Upd"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                                .Parameters.Add(New SqlParameter("@intWeekDay", SqlDbType.Int)).Value = intWeekDay
                                .Parameters.Add(New SqlParameter("@strOpen1", SqlDbType.VarChar, 4)).Value = strOpen1
                                .Parameters.Add(New SqlParameter("@strClose1", SqlDbType.VarChar, 4)).Value = strClose1
                                .Parameters.Add(New SqlParameter("@strOpen2", SqlDbType.VarChar, 4)).Value = strOpen2
                                .Parameters.Add(New SqlParameter("@strClose2", SqlDbType.VarChar, 4)).Value = strClose2
                                .ExecuteNonQuery()
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' UpdateSchedule method
        ' Purpose: update new schedule of Library
        ' Input: main information of new schedule
        Public Sub UpdateSchedule()
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_UPDATE_SCHEDULE"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                                .Parameters.Add(New OracleParameter("strOffday", OracleType.VarChar, 30)).Value = strOffDay
                                .ExecuteNonQuery()
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_spSchedule_Upd"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                                .Parameters.Add(New SqlParameter("@strOffday", SqlDbType.VarChar, 30)).Value = strOffDay
                                .ExecuteNonQuery()
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' DeleteSchedule method
        ' Purpose: Delete new schedule of Library
        ' Input: main information of exist schedule
        Public Sub DeleteSchedule()
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_DELETE_SCHEDULE"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                                .Parameters.Add(New OracleParameter("strOffYear", OracleType.VarChar, 4)).Value = strOffYear
                                .ExecuteNonQuery()
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_spCalendar_DelByLocationIdAndYear"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                                .Parameters.Add(New SqlParameter("@strOffYear", SqlDbType.VarChar, 4)).Value = strOffYear
                                .ExecuteNonQuery()
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetSchedule method
        ' Purpose: get schedule of Library
        ' Input: strOffDay, intLocationID
        ' Output: datatable result
        Public Function GetSchedule() As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_GETSCHEDULE"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                                .Parameters.Add(New OracleParameter("strOffDay", OracleType.VarChar, 30)).Value = strOffDay
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblResult")
                                GetSchedule = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_spCalendar_SelSChedule"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                                .Parameters.Add(New SqlParameter("@strOffDay", SqlDbType.VarChar, 30)).Value = strOffDay
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblResult")
                                GetSchedule = dsData.Tables("tblResult")
                                dsData.Tables.Remove("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
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
            Try
                If isDisposing Then
                    If Not oraConnection Is Nothing Then
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlDataAdapter Is Nothing Then
                        SqlDataAdapter.Dispose()
                        SqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace