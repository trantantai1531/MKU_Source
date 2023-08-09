' Name: clsDUser
' Purpose: Management login databse
' Creator: Tuanhv
' Created Date: 18/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Admin
    Public Class ClsDLogin
        Inherits clsDBase

        Private strUserName As String
        Private strPassWord As String
        Private strOldPassWord As String

        ' UserName property
        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal Value As String)
                strUserName = Value
            End Set
        End Property

        ' PassWord property
        Public Property PassWord() As String
            Get
                Return strPassWord
            End Get
            Set(ByVal Value As String)
                strPassWord = Value
            End Set
        End Property

        ' PassWord property
        Public Property OldPassWord() As String
            Get
                Return strOldPassWord
            End Get
            Set(ByVal Value As String)
                strOldPassWord = Value
            End Set
        End Property

        ' UpdatePassUser method
        ' Purpose: Update Login database
        Public Sub UpdatePassUser()
            Dim intOutVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_PASSWORD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("old", SqlDbType.VarChar, 20)).Value = strOldPassWord
                            .Parameters.Add(New OracleParameter("new", SqlDbType.VarChar, 20)).Value = strPassWord
                            .Parameters.Add(New OracleParameter("loginame", SqlDbType.VarChar, 20)).Value = strUserName
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
                        .CommandText = "SP_PASSWORD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@old", SqlDbType.VarChar, 20)).Value = strOldPassWord
                            .Parameters.Add(New SqlParameter("@new", SqlDbType.VarChar, 20)).Value = strPassWord
                            .Parameters.Add(New SqlParameter("@loginame", SqlDbType.VarChar, 20)).Value = strUserName
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

