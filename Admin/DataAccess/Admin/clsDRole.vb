Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Admin
    Public Class clsDRole
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************
        Private intModuleID As Integer
        Private intUID As Integer = 0
        Private intParentID As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        Public Property ModuleID() As Integer
            Get
                Return intModuleID
            End Get
            Set(ByVal Value As Integer)
                intModuleID = Value
            End Set
        End Property

        Public Property UID() As Integer
            Get
                Return intUID
            End Get
            Set(ByVal Value As Integer)
                intUID = Value
            End Set
        End Property

        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetRoles method
        ' Purpose: Get user informations
        ' Output: datatable result
        Public Function GetRights() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GET_RIGHTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intModuleID", OracleType.Number)).Value = intModuleID
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRights = dsData.Tables("tblResult")
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
                        .CommandText = "Sys_spUser_Permission_SelPermission"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intModuleID", SqlDbType.Int)).Value = intModuleID
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRights = dsData.Tables("tblResult")
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
                Dispose()
            End Try
        End Sub
    End Class
End Namespace