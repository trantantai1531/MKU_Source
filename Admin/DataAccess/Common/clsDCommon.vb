Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Common
    Public Class clsDCommon
        Inherits clsDBase

        Private intFormID As Integer
        Private intIsAuthority As Integer

        ' IsAuthority Property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property


        ' FormID Property
        Public Property FormID() As Integer
            Get
                Return intFormID
            End Get
            Set(ByVal Value As Integer)
                intFormID = Value
            End Set
        End Property

        Public Function CheckOpenConnection(ByVal strDBServerCheck As String, ByVal strConnectionstringCkeck As String) As Boolean
            Try
                CheckOpenConnection = True
                Select Case UCase(strDBServerCheck)
                    Case "ORACLE"
                        Dim oraConnectionCheck As New OracleConnection(strConnectionstringCkeck)
                        Dim oraCommandCheck As New OracleCommand
                        oraCommandCheck.Connection = oraConnectionCheck
                        If oraConnectionCheck.State = ConnectionState.Closed Then
                            oraConnectionCheck.Open()
                            If Not oraConnectionCheck Is Nothing Then
                                oraConnectionCheck.Close()
                                oraConnectionCheck.Dispose()
                                oraConnectionCheck = Nothing
                                oraCommandCheck = Nothing
                            End If
                        End If
                    Case "SQLSERVER"
                        Dim sqlConnectionCheck As SqlConnection
                        Dim sqlCommandCheck As SqlCommand
                        sqlConnectionCheck = New SqlConnection(strConnectionstringCkeck)
                        sqlCommandCheck = New SqlCommand
                        sqlCommandCheck.Connection = sqlConnectionCheck
                        If sqlConnectionCheck.State = ConnectionState.Closed Then
                            sqlConnectionCheck.Open()
                            If Not sqlConnectionCheck Is Nothing Then
                                sqlConnectionCheck.Close()
                                sqlConnectionCheck.Dispose()
                                sqlConnectionCheck = Nothing
                                sqlCommandCheck = Nothing
                            End If
                        End If
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
                CheckOpenConnection = False
            End Try
        End Function

        Public Function Retrieve_SysParameters(ByVal strNames As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_SYS_PARAMETER_SELECT"
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
                        .CommandText = "COMMON.Sys_spEventGroup_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = lngGroupID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
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
                            strErrorMsg = ex.Message.ToString
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
                            .CommandText = "COMMON.SP_SYS_LOG_INS"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New OracleParameter("intEventGroupID", OracleType.Number)).Value = lngGroupID
                            .Parameters.Add(New OracleParameter("strEvent", OracleType.VarChar, 300)).Value = strMsg
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 200)).Value = strFilename
                            .Parameters.Add(New OracleParameter("strUser", OracleType.VarChar, 70)).Value = strUser_name
                            .Parameters.Add(New OracleParameter("strWorkStation", OracleType.VarChar, 50)).Value = strRemote_Host
                            Try
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
                                strErrorMsg = sqlClientEx.Message.ToString
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
                        strErrorMsg = ex.Message.ToString
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
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
            Call CloseConnection()
        End Function

        Public Function Retrieve_StyleSheet(ByVal lngUserID As Long, ByVal bytModuleID As Byte) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_SYS_USER_CSS_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("lngUserID", OracleType.Number)).Value = lngUserID
                        .Parameters.Add(New OracleParameter("bytModuleID", OracleType.Number)).Value = bytModuleID
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSysCSS")
                            Retrieve_StyleSheet = dsData.Tables("tblSysCSS")
                            dsData.Tables.Remove("tblSysCSS")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
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
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSysCSS")
                            Retrieve_StyleSheet = dsData.Tables("tblSysCSS")
                            dsData.Tables.Remove("tblSysCSS")
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

        Public Function Retrieve_OneUser(ByVal strUS As String, ByVal strPW As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_SYS_USER_SELECT"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strUS", OracleType.VarChar, 50)).Value = strUS
                        .Parameters.Add(New OracleParameter("strPW", OracleType.VarChar, 50)).Value = strPW
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSysUser")
                            Retrieve_OneUser = dsData.Tables("tblSysUser")
                            dsData.Tables.Remove("tblSysUser")
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_Sel2"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strUS", SqlDbType.VarChar, 50)).Value = strUS
                        .Parameters.Add(New SqlParameter("@strPW", SqlDbType.VarChar, 50)).Value = strPW
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSysUser")
                            Retrieve_OneUser = dsData.Tables("tblSysUser")
                            dsData.Tables.Remove("tblSysUser")
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

        ' Retrieve data
        ' Input: string of select statement
        ' Output: DataTable
        ' STOREPROCEDURE
        Public Function RetrieveItemInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = strSQLStatement
                        .CommandType = CommandType.Text
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "ITEM_INFOR")
                            RetrieveItemInfor = dsData.Tables("ITEM_INFOR")
                            dsData.Tables.Remove("ITEM_INFOR")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = strSQLStatement
                        .CommandType = CommandType.Text
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "ITEM_INFOR")
                            RetrieveItemInfor = dsData.Tables("ITEM_INFOR")
                            dsData.Tables.Remove("ITEM_INFOR")
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
        Public Sub RetrieveNonQuery()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = strSQLStatement
                        .CommandType = CommandType.Text
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = strSQLStatement
                        .CommandType = CommandType.Text
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
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
        End Sub

        Public Function RetrieveCopyNumberIds() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = strSQLStatement
                        .CommandType = CommandType.Text
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "COPYNUMBER_ID")
                            RetrieveCopyNumberIds = dsData.Tables("COPYNUMBER_ID")
                            dsData.Tables.Remove("COPYNUMBER_ID")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            RetrieveCopyNumberIds = New DataTable()
                            RetrieveCopyNumberIds.Columns.Add(New DataColumn("ID"))
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case Else
                    RetrieveCopyNumberIds = New DataTable()
                    RetrieveCopyNumberIds.Columns.Add(New DataColumn("ID"))
                    Exit Select
            End Select
            Call CloseConnection()
        End Function

        ' Insert (Update)
        ' Input: string of SQL statement
        ' STOREPROCEDURE
        Public Sub ProcessItem()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = strSQLStatement
                        .CommandType = CommandType.Text
                        Try
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
                        .CommandText = strSQLStatement
                        .CommandType = CommandType.Text
                        Try
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
        End Sub

        Public Function GetTempFilePath(ByVal intModuleID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_GET_SYS_TEMP_FILE"
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
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spTempFile_SelByModule"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intModuleID", SqlDbType.Int)).Value = intModuleID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetTempFilePath = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetZServerList method
        ' Purpose: Get Z3950Server List
        ' Output: Datatable result
        Public Function GetZServerList() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_GET_ZSERVER_LIST"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblZServer")
                            GetZServerList = dsData.Tables("tblZServer")
                            dsData.Tables.Remove("tblZServer")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Ill_spZ3950Server_SelListZServer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblZServer")
                            GetZServerList = dsData.Tables("tblZServer")
                            dsData.Tables.Remove("tblZServer")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetRightUserInfor
        ' Input: int UserID
        ' Output: DataTable content Right this user
        Public Function GetUserRight() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_GET_USER_RIGHT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "RIGHT_USER")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_Permission_SelPermissionByUserId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "RIGHT_USER")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetUserRight = dsData.Tables("RIGHT_USER")
            dsData.Tables.Remove("RIGHT_USER")
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