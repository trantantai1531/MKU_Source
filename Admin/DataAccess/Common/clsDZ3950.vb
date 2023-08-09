Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Common
    Public Class clsDZ3950
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Implement methods
        ' *****************************************************************************************************

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
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
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

        Public Function InsZServer(ByVal strName As String, ByVal strHost As String, ByVal intPort As Integer, ByVal strAccount As String, ByVal strPassword As String, ByVal strDBName As String, ByVal strDescription As String) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "ILL_spZ3950_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 50)).Value = strName
                            .Parameters.Add(New SqlParameter("@strHost", SqlDbType.NVarChar, 50)).Value = strHost
                            .Parameters.Add(New SqlParameter("@intPort", SqlDbType.Int)).Value = intPort
                            .Parameters.Add(New SqlParameter("@strAccount", SqlDbType.VarChar, 32)).Value = strAccount
                            .Parameters.Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 32)).Value = strPassword
                            .Parameters.Add(New SqlParameter("@strDBName", SqlDbType.VarChar, 20)).Value = strDBName
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 200)).Value = strDescription
                            .ExecuteNonQuery()
                            InsZServer = 0
                        Catch ex As SqlException
                            InsZServer = 1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function UpdZServer(ByVal intZ3950ServerID As Integer, ByVal strName As String, ByVal strHost As String, ByVal intPort As Integer, ByVal strAccount As String, ByVal strPassword As String, ByVal strDBName As String, ByVal strDescription As String) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "ILL_spZ3950_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intZ3950ServerID", SqlDbType.Int)).Value = intZ3950ServerID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 50)).Value = strName
                            .Parameters.Add(New SqlParameter("@strHost", SqlDbType.NVarChar, 50)).Value = strHost
                            .Parameters.Add(New SqlParameter("@intPort", SqlDbType.Int)).Value = intPort
                            .Parameters.Add(New SqlParameter("@strAccount", SqlDbType.VarChar, 32)).Value = strAccount
                            .Parameters.Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 32)).Value = strPassword
                            .Parameters.Add(New SqlParameter("@strDBName", SqlDbType.VarChar, 20)).Value = strDBName
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 200)).Value = strDescription
                            .ExecuteNonQuery()
                            UpdZServer = 0
                        Catch ex As SqlException
                            UpdZServer = 1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    Call MyBase.Dispose(True)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace