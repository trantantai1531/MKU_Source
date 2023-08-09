Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDRoomsBooking
        Inherits clsDBase

        Private intRoomsBookingID As Integer
        Private intRoomID As Integer
        Private intPatronID As Integer
        Private strBookingDate As String
        Private intTimeStart As Integer
        Private intTimeEnd As Integer
        Private strNote As String

        Private intTypeRoom As Integer
        Private strUses As String
        Private strRequestOther As String
        Private intCount As Integer
        Private strListCode As String

        Public Property RoomsBookingID() As Integer
            Get
                Return intRoomsBookingID
            End Get
            Set(ByVal Value As Integer)
                intRoomsBookingID = Value
            End Set
        End Property

        ' RoomID property
        Public Property RoomID() As Integer
            Get
                Return intRoomID
            End Get
            Set(ByVal Value As Integer)
                intRoomID = Value
            End Set
        End Property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        Public Property BookingDate() As String
            Get
                Return strBookingDate
            End Get
            Set(ByVal Value As String)
                strBookingDate = Value
            End Set
        End Property

        Public Property TimeStart() As Integer
            Get
                Return intTimeStart
            End Get
            Set(ByVal Value As Integer)
                intTimeStart = Value
            End Set
        End Property

        Public Property TimeEnd() As Integer
            Get
                Return intTimeEnd
            End Get
            Set(ByVal Value As Integer)
                intTimeEnd = Value
            End Set
        End Property

        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        Public Property TypeRoom() As Integer
            Get
                Return intTypeRoom
            End Get
            Set(ByVal Value As Integer)
                intTypeRoom = Value
            End Set
        End Property
        Public Property Uses() As String
            Get
                Return strUses
            End Get
            Set(ByVal Value As String)
                strUses = Value
            End Set
        End Property
        Public Property RequestOther() As String
            Get
                Return strRequestOther
            End Get
            Set(ByVal Value As String)
                strRequestOther = Value
            End Set
        End Property
        Public Property Count() As Integer
            Get
                Return intCount
            End Get
            Set(ByVal Value As Integer)
                intCount = Value
            End Set
        End Property
        Public Property ListCode() As String
            Get
                Return strListCode
            End Get
            Set(ByVal Value As String)
                strListCode = Value
            End Set
        End Property

        Public Function Update() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRoomsBooking_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRoomBookingID", SqlDbType.Int)).Value = intRoomsBookingID
                                .Add(New SqlParameter("@strBookingDate", SqlDbType.VarChar, 10)).Value = strBookingDate
                                .Add(New SqlParameter("@intTimeStart", SqlDbType.Int)).Value = intTimeStart
                                .Add(New SqlParameter("@intTimeEnd", SqlDbType.Int)).Value = intTimeEnd
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 1000)).Value = strNote
                                .Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("@intResult").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function Active() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRoomsBooking_Act"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRoomBookingID", SqlDbType.Int)).Value = intRoomsBookingID
                            End With
                            .ExecuteNonQuery()
                            Active = 1
                        Catch sqlClientEx As SqlException
                            Active = 0
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function Cancel() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRoomsBooking_Cancel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRoomBookingID", SqlDbType.Int)).Value = intRoomsBookingID
                            End With
                            .ExecuteNonQuery()
                            Cancel = 1
                        Catch sqlClientEx As SqlException
                            Cancel = 0
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetRoomsBooking(Optional ByVal strPatronCode As String = "", Optional ByVal strDateFrom As String = "", Optional ByVal strDateTo As String = "") As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Cir_spRoomsBooking_Get"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                                    .Add(New SqlParameter("@intRoomID", SqlDbType.Int)).Value = intRoomID
                                    .Add(New SqlParameter("@strBookingDate", SqlDbType.VarChar, 10)).Value = strBookingDate
                                    .Add(New SqlParameter("@strDateFrom", SqlDbType.VarChar, 10)).Value = strDateFrom
                                    .Add(New SqlParameter("@strDateTo", SqlDbType.VarChar, 10)).Value = strDateTo
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                GetRoomsBooking = dsData.Tables("tblResult")
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
        Public Function GetRoomsBookingById() As DataTable
            Try
                Me.OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Cir_spRoomsBooking_GetByID"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                With .Parameters
                                    .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intRoomsBookingID
                                End With
                                sqlDataAdapter.SelectCommand = sqlCommand
                                sqlDataAdapter.Fill(dsData, "tblResult")
                                GetRoomsBookingById = dsData.Tables("tblResult")
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

