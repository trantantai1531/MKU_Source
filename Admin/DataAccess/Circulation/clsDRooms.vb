Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDRooms
        Inherits clsDBase

        Private intRoomID As Integer
        Private strRoomCode As String
        Private strRoomName As String
        Private strRoomNote As String

        Public Property RoomID() As Integer
            Get
                Return intRoomID
            End Get
            Set(ByVal Value As Integer)
                intRoomID = Value
            End Set
        End Property

        Public Property RoomCode() As String
            Get
                Return strRoomCode
            End Get
            Set(ByVal Value As String)
                strRoomCode = Value
            End Set
        End Property

        Public Property RoomName() As String
            Get
                Return strRoomName
            End Get
            Set(ByVal Value As String)
                strRoomName = Value
            End Set
        End Property

        Public Property RoomNote() As String
            Get
                Return strRoomNote
            End Get
            Set(ByVal Value As String)
                strRoomNote = Value
            End Set
        End Property

        Public Function Create() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRooms_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strRoomCode", SqlDbType.VarChar, 20)).Value = strRoomCode
                                .Add(New SqlParameter("@strRoomName", SqlDbType.NVarChar, 250)).Value = strRoomName
                                .Add(New SqlParameter("@strRoomNote", SqlDbType.NVarChar, 1000)).Value = strRoomNote
                            End With
                            .ExecuteNonQuery()
                            Create = 1
                        Catch sqlClientEx As SqlException
                            Create = 0
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function Update() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRooms_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRoomID", SqlDbType.Int)).Value = intRoomID
                                .Add(New SqlParameter("@strRoomCode", SqlDbType.VarChar, 20)).Value = strRoomCode
                                .Add(New SqlParameter("@strRoomName", SqlDbType.NVarChar, 250)).Value = strRoomName
                                .Add(New SqlParameter("@strRoomNote", SqlDbType.NVarChar, 1000)).Value = strRoomNote
                            End With
                            .ExecuteNonQuery()
                            Update = 1
                        Catch sqlClientEx As SqlException
                            Update = 0
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function Delete() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRooms_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRoomID", SqlDbType.Int)).Value = intRoomID
                            End With
                            .ExecuteNonQuery()
                            Delete = 1
                        Catch sqlClientEx As SqlException
                            Delete = 0
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function
        Public Function GetAllRooms() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Cir_spRooms_GetAll"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                GetAllRooms = dsData.Tables("tblResult")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                dsData.Tables.Remove("tblResult")
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Me.CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
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
                    If Not sqlConnection Is Nothing Then
                        sqlConnection.Dispose()
                        sqlConnection = Nothing
                    End If
                    If Not sqlCommand Is Nothing Then
                        sqlCommand.Dispose()
                        sqlCommand = Nothing
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
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

