Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatAuthority
        Inherits clsDBase

        ' Declare variables
        Private strIDs As String
        Private strAccessEntry As String

        ' AccessEntry property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        ' IDs property
        Public Property IDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' Retrieve method
        Public Function Retrieve() As DataTable
            Call OpenConnection()
            Select Case UCase(strDbserver)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spAuthority_Sel1"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value = strIDs
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.VarChar)).Value = strAccessEntry
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "CAT_AUTHORITY_ALL")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_AUTHORITYS_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strIDs", OracleType.VarChar)).Value = strIDs
                                .Add(New OracleParameter("strAccessEntry", OracleType.VarChar, 400)).Value = strAccessEntry
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "CAT_AUTHORITY_ALL")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Return dsdata.Tables("CAT_AUTHORITY_ALL")
            dsdata.Tables.Remove("CAT_AUTHORITY_ALL")
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace