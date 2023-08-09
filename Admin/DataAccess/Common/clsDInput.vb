' Purpose: used to insert (update) informations of the item
' Creator: Oanhtn
' Created Date: 30/12/2003
' LastModifiedDate: 15/01/2004 by Oanhtn

Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Common
    Public Class clsDInput
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private oraTransaction As OracleTransaction
        Private sqlTransaction As SqlTransaction
        Private strReturnSQL As String

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' ReturnSQL property
        Public Property ReturnSQL() As String
            Get
                ReturnSQL = strReturnSQL
            End Get
            Set(ByVal Value As String)
                strReturnSQL = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Begin Transaction
        Public Sub BeginInputTrans()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    If oraTransaction Is Nothing Then
                        oraTransaction = oraConnection.BeginTransaction()
                        oraCommand.Transaction = oraTransaction
                    End If
                Case "SQLSERVER"
                    If sqlTransaction Is Nothing Then
                        sqlTransaction = SqlConnection.BeginTransaction()
                        SqlCommand.Transaction = sqlTransaction
                    End If
            End Select
        End Sub

        ' RollBack Transaction
        Public Sub RollBackInputTrans()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    oraTransaction.Rollback()
                    oraTransaction = Nothing
                Case "SQLSERVER"
                    sqlTransaction.Rollback()
                    sqlTransaction = Nothing
            End Select
            Call CloseConnection()
        End Sub

        ' Commit Transaction
        Public Sub CommitInputTrans()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    oraTransaction.Commit()
                    oraTransaction = Nothing
                Case "SQLSERVER"
                    sqlTransaction.Commit()
                    sqlTransaction = Nothing
            End Select
            Call CloseConnection()
        End Sub

        ' Retrieve data
        ' Input: string of select statement
        ' Output: DataTable
        Public Function GetData() As DataTable
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "COMMON.SP_ITEM_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSQLStatement", OracleType.NVarChar, 1000)).Value = strSQLStatement
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetData = dsData.Tables("tblResult")
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
                        .CommandText = "Lib_spExecQueryString"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSQL", SqlDbType.NVarChar)).Value = strSQLStatement
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetData = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
        End Function
        ' GetContentFieldCode Tho
        Public Function GetContentFieldCode(ByVal fieldCode As String, ByVal itemId As Integer, ByVal nameTable As String) As String
            Dim strTempoSql As String = ""
            Try
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strTempoSql = "SELECT [Content] FROM [" & nameTable & "] WHERE [ItemID]=" & itemId & " AND [FieldCode]='" & fieldCode & "'"
                    Case "SQLSERVER"
                        strTempoSql = "SELECT [Content] FROM [" & nameTable & "] WHERE [ItemID]=" & itemId & " AND [FieldCode]='" & fieldCode & "'"
                    Case Else
                        strTempoSql = ""
                End Select

                sqlCommand.CommandText = strTempoSql
                sqlCommand.CommandType = CommandType.Text
                sqlDataAdapter.SelectCommand = sqlCommand
                sqlDataAdapter.Fill(dsData, "tblResult")
                'If Not dsData.Tables("tblResult") Is Nothing Then
                '    If Not dsData.Tables("tblResult").Rows.Count = 0 Then
                '        Dim valueContent As String = dsData.Tables("tblResult").Rows(0).Item("Content")
                '        Try
                '            Dim valueSplit As String() = valueContent.Split(" ")
                '            If (Not valueSplit(1) Is Nothing) Then
                '                GetContentFieldCode = valueSplit(1).Replace("$b", "")
                '            Else
                '                GetContentFieldCode = valueContent.Replace("$a", "").Replace("$b", "")
                '            End If
                '        Catch ex As Exception
                '            GetContentFieldCode = valueContent.Replace("$a", "").Replace("$b", "")
                '        End Try

                '    Else
                '        GetContentFieldCode = Nothing
                '    End If
                'Else
                '    GetContentFieldCode = Nothing
                'End If
                If (Not dsData.Tables("tblResult") Is Nothing) AndAlso dsData.Tables("tblResult").Rows.Count > 0 Then
                    GetContentFieldCode = dsData.Tables("tblResult").Rows(0).Item("Content")
                Else
                    GetContentFieldCode = ""
                End If
                dsData.Tables.Remove("tblResult")
            Catch ex As SqlException
                intErrorCode = ex.Number
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        ' Insert (Update)
        ' Input: string of SQL statement

        ' Get CallNumber, AcquiredDate, LoanTypeID, AcquiredSourceID from holding by ItemId
        Public Function GetHoldingByItemId(ByVal itemId As Integer) As DataTable
            Dim strTempoSql As String = ""
            Try
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        strTempoSql = "SELECT AcquiredDate, Price, LoanTypeID, AcquiredSourceID FROM Lib_tblHolding WHERE ItemID=" & itemId & " GROUP BY AcquiredDate, Price, LoanTypeID, AcquiredSourceID"
                    Case "SQLSERVER"
                        strTempoSql = "SELECT AcquiredDate, Price, LoanTypeID, AcquiredSourceID FROM Lib_tblHolding WHERE ItemID=" & itemId & " GROUP BY AcquiredDate, Price, LoanTypeID, AcquiredSourceID"
                    Case Else
                        strTempoSql = ""
                End Select

                sqlCommand.CommandText = strTempoSql
                sqlCommand.CommandType = CommandType.Text
                sqlDataAdapter.SelectCommand = sqlCommand
                sqlDataAdapter.Fill(dsData, "tblResult")
                If Not dsData.Tables("tblResult") Is Nothing Then
                    If Not dsData.Tables("tblResult").Rows.Count = 0 Then
                        GetHoldingByItemId = dsData.Tables("tblResult")
                    Else
                        GetHoldingByItemId = New DataTable
                    End If
                Else
                    GetHoldingByItemId = New DataTable
                End If
                dsData.Tables.Remove("tblResult")
            Catch ex As SqlException
                intErrorCode = ex.Number
                strErrorMsg = ex.Message.ToString
            End Try
        End Function
        Public Sub ExecuteQuery()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = strSQLStatement '"COMMON.SP_ITEM_PROCESS"
                        .CommandType = CommandType.Text '.StoredProcedure
                        Try
                            '.Parameters.Add(New OracleParameter("strSQLStatement", OracleType.VarChar, 4000)).Value = strSQLStatement
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = strSQLStatement & "->" & OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = strSQLStatement '"SP_ITEM_PROCESS"
                        .CommandType = CommandType.Text '.StoredProcedure
                        Try
                            '.Parameters.Add(New SqlParameter("@strSQLStatement", SqlDbType.NVarChar, 4000)).Value = strSQLStatement
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = strSQLStatement & "->" & sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        End Try
                    End With
            End Select
        End Sub

        ' CreateID Function
        Public Function CreateID(ByVal strTableName As String, ByVal strFieldName As String) As DataTable
            Dim lngRet As Long

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Try
                        oraCommand.CommandText = "SELECT SQ_" & strTableName & ".NEXTVAL as ID FROM Dual"
                        oraCommand.CommandType = CommandType.Text
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        CreateID = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As OracleException
                        Try
                            oraCommand.CommandText = "SELECT NVL(Max(" & strFieldName & "), 0) + 1 as ID FROM " & strTableName
                            oraCommand.CommandType = CommandType.Text
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CreateID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch ex1 As OracleException
                            intErrorCode = ex1.Code
                            strErrorMsg = ex1.Message.ToString
                        End Try
                    End Try
                Case "SQLSERVER"
                    Try
                        sqlCommand.CommandText = "SELECT ISNULL(Max(" & strFieldName & "), 0) + 1 as ID FROM " & strTableName
                        sqlCommand.CommandType = CommandType.Text
                        sqlDataAdapter.SelectCommand = sqlCommand
                        sqlDataAdapter.Fill(dsData, "tblResult")
                        CreateID = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
        End Function

        'Tho Phan
        ' Get last record Holding by ItemId
        Public Function GetLastRecordHoldingByItemId(ByVal itemId As Integer) As DataTable
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Try
                        oraCommand.CommandText = "Lib_spHolding_LastRecord_By_Item"
                        oraCommand.CommandType = CommandType.StoredProcedure
                        oraCommand.Parameters.Add(New OracleParameter("@ItemId", SqlDbType.Int)).Value = itemId
                        oraDataAdapter.SelectCommand = oraCommand
                        oraDataAdapter.Fill(dsData, "tblResult")
                        GetLastRecordHoldingByItemId = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
                Case "SQLSERVER"
                    Try
                        sqlCommand.CommandText = "Lib_spHolding_LastRecord_By_Item"
                        sqlCommand.CommandType = CommandType.StoredProcedure
                        sqlCommand.Parameters.Add(New SqlParameter("@ItemId", SqlDbType.Int)).Value = itemId
                        sqlDataAdapter.SelectCommand = sqlCommand
                        sqlDataAdapter.Fill(dsData, "tblResult")
                        GetLastRecordHoldingByItemId = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
        End Function

        ' Get HoldingLocation
        Public Function GetHoldingLocation(ByVal intHoldingLibrary As Integer) As DataTable
            GetHoldingLocation = Nothing
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Try
                        sqlCommand.CommandText = "Lib_spHoldingLocation_Sel"
                        sqlCommand.CommandType = CommandType.StoredProcedure
                        sqlCommand.Parameters.Add(New SqlParameter("@intLidId", SqlDbType.Int)).Value = intHoldingLibrary
                        sqlDataAdapter.SelectCommand = sqlCommand
                        sqlDataAdapter.Fill(dsData, "tblResult")
                        GetHoldingLocation = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
        End Function

        ''' <summary>
        ''' Get HoldingLocation
        ''' </summary>
        ''' <param name="intHoldingLibrary"></param>
        ''' <param name="intUserID">0 if get all location, or get only location belong to user</param>
        ''' <param name="intTopText">0 if not generating top text (--chọn tất cả--) 1 if so</param>
        ''' <returns></returns>
        Public Function GetHoldingLocationByUserID(ByVal intHoldingLibrary As Integer,
                                                   Optional intUserID As Integer = 0,
                                                   Optional intTopText As Integer = 1,
                                                   Optional strTopText As String = Nothing) As DataTable
            GetHoldingLocationByUserID = Nothing
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Try
                        sqlCommand.CommandText = "Lib_spHoldingLocation_SelByUserId"
                        sqlCommand.CommandType = CommandType.StoredProcedure
                        sqlCommand.Parameters.Add(New SqlParameter("@intLidID", SqlDbType.Int)).Value = intHoldingLibrary
                        sqlCommand.Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        sqlCommand.Parameters.Add(New SqlParameter("@intTopText", SqlDbType.Int)).Value = intTopText
                        sqlCommand.Parameters.Add(New SqlParameter("@strTopText", SqlDbType.NVarChar, 100)).Value = strTopText
                        sqlDataAdapter.SelectCommand = sqlCommand
                        sqlDataAdapter.Fill(dsData, "tblResult")
                        GetHoldingLocationByUserID = dsData.Tables("tblResult")
                        dsData.Tables.Remove("tblResult")
                    Catch ex As SqlException
                        intErrorCode = ex.Number
                        strErrorMsg = ex.Message.ToString
                    End Try
            End Select
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(True)
            Finally
                Me.Dispose()
            End Try
        End Sub

        ' Only when Dispose fail
        Protected Overrides Sub Finalize()
            Dispose(False)
        End Sub
    End Class
End Namespace