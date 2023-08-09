Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDTemplate
        Inherits clsDBase

        ' ***************************************************************************************************
        ' Declare Private variables
        ' ***************************************************************************************************
        Private strIDs As String
        Private intType As Integer

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' Type property
        Public Property Type() As Integer
            Get
                Return intType
            End Get
            Set(ByVal Value As Integer)
                intType = Value
            End Set
        End Property


        ' GetTemplates method
        ' Purpose: Get all systemplate
        Public Function GetTemplates() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spTempFile_Sel"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strID", SqlDbType.VarChar, 1000)).Value = strIDs
                            .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblSYS_TEMPLATE")
                            GetTemplates = dsData.Tables("tblSYS_TEMPLATE")
                            dsData.Tables.Remove("tblSYS_TEMPLATE")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "SYS.SP_SYS_TEMPLATE_SEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strID", OracleType.VarChar, 1000)).Value = strIDs
                            .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblSYS_TEMPLATE")
                            GetTemplates = dsData.Tables("tblSYS_TEMPLATE")
                            dsData.Tables.Remove("tblSYS_TEMPLATE")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
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
                Try
                    Call MyBase.Dispose(True)
                Finally
                    Me.Dispose()
                End Try
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace