Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.Common
    Public Class clsDCommon
        Inherits clsDBase

        Private strDFError As String = "Error in DataAccess(clsDCommon): "

        ' *************************************************************************************************
        ' Declare public properties
        ' *************************************************************************************************
        Public Function Retrieve_SysParameters(ByVal strNames As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.Sys_spParameter_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strWh", OracleType.VarChar, 4000)).Value = strNames
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSysParas")
                            Retrieve_SysParameters = dsData.Tables("tblSysParas")
                            dsData.Tables.Remove("tblSysParas")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spParameter_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strWh", SqlDbType.VarChar, 4000)).Value = strNames
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSysParas")
                            Retrieve_SysParameters = dsData.Tables("tblSysParas")
                            dsData.Tables.Remove("tblSysParas")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetEventGroupMode method
        ' Purpose: Get the group mode of an user 
        Public Function GetEventGroupMode(ByVal lngGroupID As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "Sys_spEventGroup_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = lngGroupID
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSysGroupMode")
                            GetEventGroupMode = dsData.Tables("tblSysGroupMode")
                            dsData.Tables.Remove("tblSysGroupMode")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spEventGroup_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = lngGroupID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSysGroupMode")
                            GetEventGroupMode = dsData.Tables("tblSysGroupMode")
                            dsData.Tables.Remove("tblSysGroupMode")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = strDFError & ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Sub WriteLog(ByVal lngGroupID As Long, ByVal strMsg As String, ByVal strFilename As String, ByVal strRemote_Host As String, ByVal strUser_name As String)

            Dim intOnOff As Integer
            ' Check if the event-group's log mode is on
            If Not Me.GetEventGroupMode(lngGroupID) Is Nothing Then
                If Me.GetEventGroupMode(lngGroupID).Rows.Count > 0 Then
                    intOnOff = CInt(Me.GetEventGroupMode(lngGroupID).Rows(0).Item("LogMode"))
                End If
            End If

            If intOnOff <> 0 Then
                Call OpenConnection()
                ' If the log mode is on, add a log entry to the log database
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "Sys_spLog_Ins"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New OracleParameter("intEventGroupID", OracleType.Number)).Value = lngGroupID
                            .Parameters.Add(New OracleParameter("strEvent", OracleType.NVarChar, 300)).Value = strMsg
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.NVarChar, 200)).Value = strFilename
                            .Parameters.Add(New OracleParameter("strUser", OracleType.NVarChar, 70)).Value = strUser_name
                            .Parameters.Add(New OracleParameter("strWorkStation", OracleType.VarChar, 50)).Value = strRemote_Host
                            Try
                                .ExecuteNonQuery()
                                oraDataAdapter.SelectCommand = oraCommand
                            Catch OraEx As OracleException
                                strErrorMsg = strDFError & OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Sys_spLog_Ins"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intEventGroupID", SqlDbType.Int)).Value = lngGroupID
                            .Parameters.Add(New SqlParameter("@strEvent", SqlDbType.NVarChar, 300)).Value = strMsg
                            .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.NVarChar, 200)).Value = strFilename
                            .Parameters.Add(New SqlParameter("@strUser", SqlDbType.NVarChar, 70)).Value = strUser_name
                            .Parameters.Add(New SqlParameter("@strWorkStation", SqlDbType.VarChar, 50)).Value = strRemote_Host
                            Try
                                .ExecuteNonQuery()

                            Catch sqlClientEx As SqlException
                                strErrorMsg = strDFError & sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
            End If
            Call CloseConnection()
        End Sub

        Public Function CreateID(ByVal strTableName As String, ByVal strFieldName As String) As DataTable
            Dim lngRet As Long
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Try
                        oraCommand.CommandText = "SELECT NVL(Max(" & strFieldName & "), 0) + 1 as ID FROM " & strTableName
                        oraCommand.CommandType = CommandType.Text
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "TblCreateID")
                        CreateID = dsData.Tables("TblCreateID")
                        dsData.Tables.Remove("TblCreateID")
                    Catch ex As OracleException
                        intErrorCode = ex.Code
                        strErrorMsg = strDFError & ex.Message.ToString
                    End Try
                Case "SQLSERVER"
                    Try
                        SqlCommand.CommandText = "SELECT ISNULL(Max(" & strFieldName & "), 0) + 1 as ID FROM " & strTableName
                        SqlCommand.CommandType = CommandType.Text
                        SqlDataAdapter.SelectCommand = SqlCommand
                        SqlDataAdapter.Fill(dsData, "TblCreateID")
                        CreateID = dsData.Tables("TblCreateID")
                        dsData.Tables.Remove("TblCreateID")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = strDFError & ex.Message.ToString
                    End Try
            End Select
            Call CloseConnection()
        End Function

        Public Function Retrieve_StyleSheet(ByVal lngUserID As Long, ByVal bytModuleID As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "PATRON.Sys_spUserCSS_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("lngUserID", OracleType.Number)).Value = lngUserID
                        .Parameters.Add(New OracleParameter("bytModuleID", OracleType.Number)).Value = bytModuleID
                        .Parameters.Add(New OracleParameter("strSQL", OracleType.VarChar, 8000)).Direction = ParameterDirection.Output
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            strSQLStatement = .Parameters("strSQL").Value
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSysCSS")
                            Retrieve_StyleSheet = dsData.Tables("tblSysCSS")
                            dsData.Tables.Remove("tblSysCSS")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = strDFError & ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUserCSS_Sel"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@lngUserID", SqlDbType.Int)).Value = lngUserID
                        .Parameters.Add(New SqlParameter("@bytModuleID", SqlDbType.Int)).Value = bytModuleID
                        .Parameters.Add(New SqlParameter("@SQL", SqlDbType.VarChar, 8000)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            strSQLStatement = .Parameters("@SQL").Value
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSysCSS")
                            Retrieve_StyleSheet = dsData.Tables("tblSysCSS")
                            dsData.Tables.Remove("tblSysCSS")
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = strDFError & ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Retrieve data
        ' Input: string of select statement
        ' Output: DataTable
        ' STOREPROCEDURE
        Public Function RetrieveItemInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = strSQLStatement ' "COMMON.SP_ITEM_SEL"
                        .CommandType = CommandType.Text '.StoredProcedure
                        Try
                            'With .Parameters
                            '    .Add(New OracleParameter("strSQLStatement", OracleType.VarChar, 4000)).Value = strSQLStatement
                            '    .Add(New OracleParameter("strsqlout", OracleType.VarChar, 2000)).Direction = ParameterDirection.Output
                            '    .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            'End With
                            oraCommand.ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            RetrieveItemInfor = dsData.Tables("tblResult")
                            'Dim STRTEST As String = .Parameters("strsqlout").Value
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = strDFError & OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spExecQueryString"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSQL", SqlDbType.NText)).Value = strSQLStatement
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            RetrieveItemInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = strDFError & sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetTempFilePath(ByVal intModuleID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.Sys_spTempFile_SelByModuleId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intModuleID", OracleType.Number)).Value = intModuleID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTempFilePath = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = strDFError & OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spTempFile_SelByModuleId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intModuleID", SqlDbType.Int)).Value = intModuleID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetTempFilePath = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = strDFError & sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not dsData Is Nothing Then
                    dsData.Dispose()
                    dsData = Nothing
                End If
                If Not oraConnection Is Nothing Then
                    oraConnection.Dispose()
                    oraConnection = Nothing
                End If
                If Not oraCommand Is Nothing Then
                    oraCommand.Dispose()
                    oraCommand = Nothing
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
                If Not OraDataAdapter Is Nothing Then
                    OraDataAdapter.Dispose()
                    OraDataAdapter = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace