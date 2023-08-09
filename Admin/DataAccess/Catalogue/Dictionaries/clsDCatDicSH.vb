Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Common
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
    Public Class clsDCatDicSH
        Inherits clsDBase

        Private intID As Integer
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private intParentID As Integer
        Private intDicItemID As Integer
        Private strVietnameseAccent As String

        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        Public Property DicItemID() As Integer
            Get
                Return intDicItemID
            End Get
            Set(ByVal Value As Integer)
                intDicItemID = Value
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


        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property

        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property

        Public Property VietnameseAccent() As String
            Get
                Return strVietnameseAccent
            End Get
            Set(ByVal Value As String)
                strVietnameseAccent = Value
            End Set
        End Property

        Public Function Update() As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicSH_Update"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intId", SqlDbType.Int)).Value = intID
                                .Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar, 500)).Value = strDisplayEntry
                                .Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 500)).Value = strAccessEntry
                                .Add(New SqlParameter("@intDicItemID", SqlDbType.Int)).Value = intDicItemID
                                .Add(New SqlParameter("@strVietnameseAccent", SqlDbType.NVarChar, 250)).Value = strVietnameseAccent
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch ex As SqlException
                            intRetval = -1
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Update = intRetval
        End Function

        Public Function GetAll(Optional ByVal strSearch As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicSH_SelectAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSearch", SqlDbType.NVarChar, 500)).Value = strSearch
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAll = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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
        Public Function GetAllSHBibliography() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicSH_Bibliography_SelectAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAllSHBibliography = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
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

        Public Function InsertSHBibliography(ByVal intSHID As Integer) As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicSH_Bibliography_Insert"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intSHID", SqlDbType.Int)).Value = intSHID
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch ex As SqlException
                            intRetval = -1
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            InsertSHBibliography = intRetval
        End Function

        Public Function DeleteSHBibliography(ByVal intSHID As Integer) As Integer
            Dim intRetval As Integer = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_tblDicSH_Bibliography_Delete"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intSHID", SqlDbType.Int)).Value = intSHID
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch ex As SqlException
                            intRetval = -1
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            DeleteSHBibliography = intRetval
        End Function

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
                    End If
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Close()
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not oraConnection Is Nothing Then
                        oraConnection.Close()
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not sqlDataAdapter Is Nothing Then
                        sqlDataAdapter.Dispose()
                        sqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

