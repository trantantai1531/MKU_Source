Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACRoomsBooking
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
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
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

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


        Public Function Create(ByVal strPatronCode As String) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRoomsBooking_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRoomID", SqlDbType.VarChar, 20)).Value = intRoomID
                                .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                                .Add(New SqlParameter("@strBookingDate", SqlDbType.VarChar, 10)).Value = strBookingDate
                                .Add(New SqlParameter("@intTimeStart", SqlDbType.Int)).Value = intTimeStart
                                .Add(New SqlParameter("@intTimeEnd", SqlDbType.Int)).Value = intTimeEnd
                                .Add(New SqlParameter("@intTypeRoom", SqlDbType.Int)).Value = intTypeRoom
                                .Add(New SqlParameter("@strUses", SqlDbType.NVarChar)).Value = strUses
                                .Add(New SqlParameter("@strRequestOther", SqlDbType.NVarChar)).Value = strRequestOther
                                .Add(New SqlParameter("@intCount", SqlDbType.Int)).Value = intCount
                                .Add(New SqlParameter("@strListCode", SqlDbType.VarChar)).Value = strListCode
                                .Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("@intResult").Value
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

        Public Function GetHistoryRoomBookingByPatronCode(ByVal strPatronCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRoomsBooking_GetHistoryByPatronCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetHistoryRoomBookingByPatronCode = dsData.Tables("tblResult")
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

        Public Function GetTimeBusyByDate(ByVal strDate As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spRoomsBooking_GetTimeBusyByDate"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strDate", SqlDbType.VarChar, 10)).Value = strDate
                                .Add(New SqlParameter("@intRoomID", SqlDbType.Int)).Value = intRoomID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetTimeBusyByDate = dsData.Tables("tblResult")
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

