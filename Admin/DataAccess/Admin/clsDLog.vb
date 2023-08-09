'Name: clsDLog
'Purpose: Management log object
'Creator: Oanhtn
'Created Date: 18/11/2004
'Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Admin
    Public Class clsDLog
        Inherits clsDBase

        '*******************************************************************************************************
        'Declare Private variables
        '*******************************************************************************************************

        Private lngLogID As Long
        Private strEventGroupIDs As String
        Private strUserNames As String
        Private strMessage As String
        Private strLogTimeTo As String
        Private strLogTimeFrom As String

        '*****************************************************************************************************
        'End declare variables
        'Declare public properties
        '*****************************************************************************************************

        'LogID property
        Public Property LogID() As Long
            Get
                Return lngLogID
            End Get
            Set(ByVal Value As Long)
                lngLogID = Value
            End Set
        End Property

        'EventGroupIDs property
        Public Property EventGroupIDs() As String
            Get
                Return strEventGroupIDs
            End Get
            Set(ByVal Value As String)
                strEventGroupIDs = Value
            End Set
        End Property

        'UserNames property
        Public Property UserNames() As String
            Get
                Return strUserNames
            End Get
            Set(ByVal Value As String)
                strUserNames = Value
            End Set
        End Property

        'Message property
        Public Property Message() As String
            Get
                Return strMessage
            End Get
            Set(ByVal Value As String)
                strMessage = Value
            End Set
        End Property

        'LogTimeTo property
        Public Property LogTimeTo() As String
            Get
                Return strLogTimeTo
            End Get
            Set(ByVal Value As String)
                strLogTimeTo = Value
            End Set
        End Property

        'LogTimeFrom property
        Public Property LogTimeFrom() As String
            Get
                Return strLogTimeFrom
            End Get
            Set(ByVal Value As String)
                strLogTimeFrom = Value
            End Set
        End Property

        '*****************************************************************************************************
        'End declare properties
        'Implement methods here
        '*****************************************************************************************************

        'DeleteLog method
        'Purpose: delete log
        'Input: some conditions
        'Output: integer value (0 if success)
        Public Function DeleteLog() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_DELETE_LOGS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFromDate", OracleType.VarChar, 30)).Value = strLogTimeFrom
                            .Parameters.Add(New OracleParameter("strToDate", OracleType.VarChar, 30)).Value = strLogTimeTo
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
                        .CommandText = "Admin_spLog_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.VarChar)).Value = strLogTimeFrom
                            .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.VarChar)).Value = strLogTimeTo
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
        End Function

        'Search method
        'Purpose: Get logs informations
        'Input: some logs information
        'Output: datatable result
        Public Function Search() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spLog_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strEventGroupIDs", OracleType.VarChar, 1000)).Value = strEventGroupIDs
                            .Parameters.Add(New OracleParameter("strUserNames", OracleType.VarChar, 1000)).Value = strUserNames
                            .Parameters.Add(New OracleParameter("strMessage", OracleType.VarChar, 200)).Value = strMessage
                            .Parameters.Add(New OracleParameter("strFromDate", OracleType.VarChar, 30)).Value = strLogTimeFrom
                            .Parameters.Add(New OracleParameter("strToDate", OracleType.VarChar, 30)).Value = strLogTimeTo
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            Search = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spLog_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strEventGroupIDs", SqlDbType.VarChar, 4000)).Value = strEventGroupIDs
                            .Parameters.Add(New SqlParameter("@strUserNames", SqlDbType.VarChar, 1000)).Value = strUserNames
                            .Parameters.Add(New SqlParameter("@strMessage", SqlDbType.NVarChar, 200)).Value = strMessage
                            .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.VarChar)).Value = strLogTimeFrom
                            .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.VarChar)).Value = strLogTimeTo
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            Search = dsData.Tables("tblResult")
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
        End Function

        'StatMonthly method
        'Purpose: create monthly statistic
        'Input: some information
        'Output: datatable result
        Public Function StatMonthly(ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_STATMONTH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatMonthly = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spStatMonth_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatMonthly = dsData.Tables("tblResult")
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
        End Function

        ' Purpose: Statistic log group event method
        ' In: intMonth, intYear, intDay
        ' Creator: Sondp
        ' Output: datatable 
        Public Function StatQuickView(ByVal intDay As Integer, ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spStaticQuickview_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intDay", OracleType.Number)).Value = intDay
                            .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatQuickView = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spStaticQuickview_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intDay", SqlDbType.Int)).Value = intDay
                            .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatQuickView = dsData.Tables("tblResult")
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
        End Function

        ' StatDayModule method
        ' Purpose: create daymodule statistic
        ' Input: date
        ' Output: datatable result
        Public Function StatDayModule(ByVal intDay As Integer, ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spStatday_module_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intDay", OracleType.Number)).Value = intDay
                            .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatDayModule = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spStatday_module_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intDay", SqlDbType.Int)).Value = intDay
                            .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatDayModule = dsData.Tables("tblResult")
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
        End Function

        ' StatDayEvent method
        ' Purpose: create daymodule statistic
        ' Input: date
        ' Output: datatable result
        Public Function StatDayEvent(ByVal intParentID As Integer, ByVal intDay As Integer, ByVal intMonth As Integer, ByVal intYear As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spStatDate_Event_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                            .Parameters.Add(New OracleParameter("intDay", OracleType.Number)).Value = intDay
                            .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatDayEvent = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spStatDate_Event_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            .Parameters.Add(New SqlParameter("@intDay", SqlDbType.Int)).Value = intDay
                            .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatDayEvent = dsData.Tables("tblResult")
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
        End Function

        'GetLogTimeParent method
        'Purpose: Get log time parent
        'Input: some information
        'Output: datatable result
        Public Function GetLogTimeParent() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.ADMIN_STAITC_GET_LOGTIME_PARENT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLogTimeParent = dsData.Tables("tblResult")
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
                        .CommandText = "ADMIN_STAITC_GET_LOGTIME_PARENT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLogTimeParent = dsData.Tables("tblResult")
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
        End Function

        'StatWeekly method
        'Purpose: Create day detail statistic
        'Input: some information
        'Output: datatable result
        Public Function StatWeekly(ByVal strDateTo As String, ByVal strDateFrom As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Admin_spStaticWeekly_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strTo_Date", OracleType.VarChar)).Value = strDateTo
                            .Parameters.Add(New OracleParameter("strFrom_Date", OracleType.VarChar)).Value = strDateFrom
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            StatWeekly = dsData.Tables("tblResult")
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
                        .CommandText = "Admin_spStaticWeekly_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strTo_Date", SqlDbType.VarChar)).Value = strDateTo
                            .Parameters.Add(New SqlParameter("@strFrom_Date", SqlDbType.VarChar)).Value = strDateFrom
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            StatWeekly = dsData.Tables("tblResult")
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
        End Function

        'Dispose method
        'Purpose: Release all resource
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
                Dispose()
            End Try
        End Sub
    End Class
End Namespace