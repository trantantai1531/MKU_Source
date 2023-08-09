Imports System.Data.SqlClient

Namespace eMicLibAdmin.BusinessRules.Circulation
    Public Class clsDDHVLStatistic
        Inherits clsDBase

        ''' <summary>
        ''' Hình thức mượn
        ''' 0 - Tất cả
        ''' 1 - Về nhà
        ''' 2 - Tại chỗ
        ''' </summary>
        ''' <returns></returns>
        Public Property LoanMode() As Integer

        ''' <summary>
        ''' Dạng tư liệu lưu thông
        ''' </summary>
        ''' <returns></returns>
        Public Property LoanType() As Integer

        Public Property Location() As Integer

        ''' <summary>
        ''' 0 - Theo đầu ấn phẩm
        ''' 1 - Theo bản ấn phẩm
        ''' 2 - Theo bạn đọc
        ''' </summary>
        ''' <returns></returns>
        Public Property StatOption() As Integer

        ''''''''''''''''''''''''' Mượn & Trả báo cáo [CheckOutIn]'''''''''''''''''''''''''''''''''''
        Public Function GetReportOnLoanCopy(ByVal intLocationID As Integer,
                                            ByVal strPatronCode As String,
                                            ByVal strCopyNumber As String,
                                            ByVal strItemCode As String,
                                            ByRef intTotal As Integer,
                                            Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                            Optional dtCheckOutDateTo As DateTime? = Nothing,
                                            Optional dtCheckInDateFrom As DateTime? = Nothing,
                                            Optional dtCheckInDateTo As DateTime? = Nothing,
                                            Optional intOffset As Integer? = Nothing,
                                            Optional intTake As Integer? = Nothing,
                                            Optional bitOutputTotal As Boolean = False,
                                            Optional bitLocation As Boolean = True) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_ReportOnLoanCopy"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value =
                                If(strPatronCode Is Nothing, DBNull.Value, DirectCast(strPatronCode, Object))
                            .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value =
                                If(strItemCode Is Nothing, DBNull.Value, DirectCast(strItemCode, Object))
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value =
                                If(strCopyNumber Is Nothing, DBNull.Value, DirectCast(strCopyNumber, Object))
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckInDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckInDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckInDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckInDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@bitLocation", SqlDbType.Bit)).Value =
                                If(bitLocation, 1, 0)
                            .Parameters.Add(New SqlParameter("@bitOutputTotal", SqlDbType.Bit)).Value =
                                If(bitOutputTotal, 1, 0)
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .CommandTimeout = 240 ' 4 minute waiting
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetReportLoanCopy(
                                            ByVal intLocationID As Integer,
                                            ByVal strPatronCode As String,
                                            ByVal strCopyNumber As String,
                                            ByVal strItemCode As String,
                                            ByRef intTotal As Integer,
                                            Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                            Optional dtCheckOutDateTo As DateTime? = Nothing,
                                            Optional dtCheckInDateFrom As DateTime? = Nothing,
                                            Optional dtCheckInDateTo As DateTime? = Nothing,
                                            Optional intOffset As Integer? = Nothing,
                                            Optional intTake As Integer? = Nothing,
                                            Optional bitOutputTotal As Boolean = False,
                                            Optional bitLocation As Boolean = True) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_ReportLoanCopy"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                            .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value =
                                If(strPatronCode Is Nothing, DBNull.Value, DirectCast(strPatronCode, Object))
                            .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value =
                                If(strItemCode Is Nothing, DBNull.Value, DirectCast(strItemCode, Object))
                            .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value =
                                If(strCopyNumber Is Nothing, DBNull.Value, DirectCast(strCopyNumber, Object))
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckInDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckInDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckInDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckInDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@bitLocation", SqlDbType.Bit)).Value =
                                If(bitLocation, 1, 0)
                            .Parameters.Add(New SqlParameter("@bitOutputTotal", SqlDbType.Bit)).Value =
                                If(bitOutputTotal, 1, 0)
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .CommandTimeout = 240 ' 4 minute waiting
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        '''''''''''''''''''''''''''Thống kê theo thời gian''''''''''''''''''''''''''''''
        Public Function GetCheckInLocationStat(
                                                ByVal intLocationID As Integer,
                                                ByRef intTotal As Integer,
                                                Optional dtCheckInDateFrom As DateTime? = Nothing,
                                                Optional dtCheckInDateTo As DateTime? = Nothing,
                                                Optional intOffset As Integer? = Nothing,
                                                Optional intTake As Integer? = Nothing
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_StatCheckInLocation"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckInDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckInDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckInDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckInDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetCheckOutLocationStat(
                                                ByVal intLocationID As Integer,
                                                ByRef intTotal As Integer,
                                                Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                                Optional dtCheckOutDateTo As DateTime? = Nothing,
                                                Optional intOffset As Integer? = Nothing,
                                                Optional intTake As Integer? = Nothing
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_StatCheckOutLocation"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetCheckInLocation(
                                                ByVal intLocationID As Integer,
                                                ByRef intTotal As Integer,
                                                Optional dtCheckInDateFrom As DateTime? = Nothing,
                                                Optional dtCheckInDateTo As DateTime? = Nothing,
                                                Optional intOffset As Integer? = Nothing,
                                                Optional intTake As Integer? = Nothing
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_CheckInLocation"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@dtCheckInDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckInDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckInDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckInDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckInDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetCheckOutLocation(
                                                ByVal intLocationID As Integer,
                                                ByRef intTotal As Integer,
                                                Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                                Optional dtCheckOutDateTo As DateTime? = Nothing,
                                                Optional intOffset As Integer? = Nothing,
                                                Optional intTake As Integer? = Nothing
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_CheckOutLocation"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckInDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckInDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetAnnualStat(
                                        ByVal bitHistory As Boolean,
                                        ByVal intLocationID As Integer,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing,
                                        Optional bitOutputTotal As Boolean = False
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_StatAnnual"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(bitHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@bitOutputTotal", SqlDbType.Bit)).Value = If(bitOutputTotal, 1, 0)
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetMonthStat(
                                        ByVal isHistory As Boolean,
                                        ByVal intLocationID As Integer,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing,
                                        Optional bitOutputTotal As Boolean = False
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_StatMonth"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(isHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@bitOutputTotal", SqlDbType.Bit)).Value = If(bitOutputTotal, 1, 0)
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetDayStat(
                                        ByVal isHistory As Boolean,
                                        ByVal intLocationID As Integer,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing,
                                        Optional bitOutputTotal As Boolean = False
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_StatDay"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(isHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@bitOutputTotal", SqlDbType.Bit)).Value = If(bitOutputTotal, 1, 0)
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetInformationAnnual(
                                        ByVal isHistory As Boolean,
                                        ByVal intLocationID As Integer,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_InformationAnnual"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(isHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = LibID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetHoldingPlaceStat(
                                        ByVal bitHistory As Boolean,
                                        ByVal bitIsLib As Boolean,
                                        ByVal strIDs As String,
                                        ByVal intLocationID As Integer,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing,
                                        Optional bitOutputTotal As Boolean = False
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_StatHoldingPlace"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(bitHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@bitIsLib", SqlDbType.Bit)).Value = If(bitIsLib, 1, 0)
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value =
                                If(strIDs Is Nothing, DBNull.Value, DirectCast(strIDs, Object))
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@bitOutputTotal", SqlDbType.Bit)).Value = If(bitOutputTotal, 1, 0)
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetHoldingPlace(
                                        ByVal bitHistory As Boolean,
                                        ByVal bitIsLib As Boolean,
                                        ByVal strIDs As String,
                                        ByVal intLocationID As Integer,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_GetHoldingPlace"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(bitHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@bitIsLib", SqlDbType.Bit)).Value = If(bitIsLib, 1, 0)
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value =
                                If(strIDs Is Nothing, DBNull.Value, DirectCast(strIDs, Object))
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanMode", SqlDbType.Int)).Value = LoanMode
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetHoldingLoanTypeStat(
                                        ByVal bitHistory As Boolean,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing,
                                        Optional bitOutputTotal As Boolean = False
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_StatHoldingLoanType"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(bitHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanType", SqlDbType.Int)).Value = LoanType
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@bitOutputTotal", SqlDbType.Bit)).Value = If(bitOutputTotal, 1, 0)
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function

        Public Function GetHoldingLoanType(
                                        ByVal isHistory As Boolean,
                                        ByRef intTotal As Integer,
                                        Optional dtCheckOutDateFrom As DateTime? = Nothing,
                                        Optional dtCheckOutDateTo As DateTime? = Nothing,
                                        Optional intOffset As Integer? = Nothing,
                                        Optional intTake As Integer? = Nothing
                                                ) As DataTable
            Dim tblResult As DataTable = Nothing
            Call OpenConnection()
            Select Case UCase(DBServer)
                Case "SQLSERVER"
                    Try
                        With sqlCommand
                            .CommandText = "Cir_spDHVL_GetHoldingLoanType"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@bitHistory", SqlDbType.Bit)).Value = If(isHistory, 1, 0)
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = UserID
                            .Parameters.Add(New SqlParameter("@intStatOption", SqlDbType.Int)).Value = StatOption
                            .Parameters.Add(New SqlParameter("@intLoanType", SqlDbType.Int)).Value = LoanType
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateFrom", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateFrom Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateFrom, Object))
                            .Parameters.Add(New SqlParameter("@dtCheckOutDateTo", SqlDbType.DateTime)).Value =
                                If(dtCheckOutDateTo Is Nothing, DBNull.Value, DirectCast(dtCheckOutDateTo, Object))
                            .Parameters.Add(New SqlParameter("@intOffset", SqlDbType.Int)).Value =
                                If(intOffset Is Nothing, DBNull.Value, DirectCast(intOffset, Object))
                            .Parameters.Add(New SqlParameter("@intTake", SqlDbType.Int)).Value =
                                If(intTake Is Nothing, DBNull.Value, DirectCast(intTake, Object))
                            .Parameters.Add(New SqlParameter("@intTotal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            sqlDataAdapter.SelectCommand = sqlCommand
                            Dim dsData As New DataSet
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            If Not IsDBNull(.Parameters("@intTotal")) Then
                                intTotal = .Parameters("@intTotal").Value
                            Else
                                intTotal = 0
                            End If
                            tblResult = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        End With
                    Catch sqlClientEx As SqlException
                        ErrorMsg = sqlClientEx.Message.ToString
                        ErrorCode = sqlClientEx.Number
                    Finally
                        sqlCommand.Parameters.Clear()
                    End Try
            End Select
            Call CloseConnection()
            Return tblResult
        End Function
    End Class
End Namespace