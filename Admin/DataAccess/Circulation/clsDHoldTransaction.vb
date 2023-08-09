Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Circulation
    Public Class clsDHoldTransaction
        Inherits clsDBaseTransaction

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************

        Private strCreatedDateFrom As String = ""
        Private strCreatedDateTo As String = ""
        Private strTimeOutDateFrom As String = ""
        Private strTimeOutDateTo As String = ""
        Private intReservationID As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' CreatedDateFrom property
        Public Property CreatedDateFrom() As String
            Get
                Return strCreatedDateFrom
            End Get
            Set(ByVal Value As String)
                strCreatedDateFrom = Value
            End Set
        End Property

        ' CreatedDateTo property
        Public Property CreatedDateTo() As String
            Get
                Return strCreatedDateTo
            End Get
            Set(ByVal Value As String)
                strCreatedDateTo = Value
            End Set
        End Property

        ' TimeOutDateFrom property
        Public Property TimeOutDateFrom() As String
            Get
                Return strTimeOutDateFrom
            End Get
            Set(ByVal Value As String)
                strTimeOutDateFrom = Value
            End Set
        End Property

        ' TimeOutDateTo property
        Public Property TimeOutDateTo() As String
            Get
                Return strTimeOutDateTo
            End Get
            Set(ByVal Value As String)
                strTimeOutDateTo = Value
            End Set
        End Property

        ' ReservationID property
        Public Property ReservationID() As Integer
            Get
                Return intReservationID
            End Get
            Set(ByVal Value As Integer)
                intReservationID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' GetHoldTransactions function 
        ' Purpose: get information of HoldTransaction
        ' Input:
        ' Output: datatable result
        Public Function GetHoldTransactions(Optional ByVal intReserv As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_GET_RESERVATION_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("strTitle", OracleType.VarChar, 500)).Value = strTitle
                        .Parameters.Add(New OracleParameter("strPatron", OracleType.VarChar, 100)).Value = strPatronCode
                        .Parameters.Add(New OracleParameter("strCreatedDateFrom", OracleType.VarChar, 15)).Value = strCreatedDateFrom
                        .Parameters.Add(New OracleParameter("strCreatedDateTo", OracleType.VarChar, 15)).Value = strCreatedDateTo
                        .Parameters.Add(New OracleParameter("strTimeOutDateFrom", OracleType.VarChar, 15)).Value = strTimeOutDateFrom
                        .Parameters.Add(New OracleParameter("strTimeOutDateTo", OracleType.VarChar, 15)).Value = strTimeOutDateTo
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUserID
                        .Parameters.Add(New OracleParameter("intReserv", OracleType.Number)).Value = intReserv
                        .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblReservation")
                            GetHoldTransactions = dsData.Tables("tblReservation")
                            dsData.Tables.Remove("tblReservation")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spHolding_SelReservationInfor"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 500)).Value = strTitle
                        .Parameters.Add(New SqlParameter("@strPatron", SqlDbType.NVarChar, 100)).Value = strPatronCode
                        .Parameters.Add(New SqlParameter("@strCreatedDateFrom", SqlDbType.VarChar, 15)).Value = strCreatedDateFrom
                        .Parameters.Add(New SqlParameter("@strCreatedDateTo", SqlDbType.VarChar, 15)).Value = strCreatedDateTo
                        .Parameters.Add(New SqlParameter("@strTimeOutDateFrom", SqlDbType.VarChar, 15)).Value = strTimeOutDateFrom
                        .Parameters.Add(New SqlParameter("@strTimeOutDateTo", SqlDbType.VarChar, 15)).Value = strTimeOutDateTo
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUserID
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@intReserv", SqlDbType.Int)).Value = intReserv
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblReservation")
                            GetHoldTransactions = dsData.Tables("tblReservation")
                            dsData.Tables.Remove("tblReservation")
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

        ' RemoveReservation method
        ' Purpose: remove selected ReservationTransaction
        ' Input: 
        Public Sub RemoveHoldTransactions()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_CIR_RESERVATION_DEL"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intReservationID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spHolding_DelById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intReservationID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' ChangeHoldingTurn method
        ' Purpose: Change the turn of patron reservation 
        ' Input:
        ' Output: datatable result
        Public Sub ChangeHoldingTurn()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_RESERVATION_CHANGETURN"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intReservationID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spReservationChangeTurn"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intReservationID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

        End Sub

        ' CutHoldingTurn method
        ' Purpose: Cut the turn of patron reservation 
        ' Input:
        ' Output: datatable result
        Public Sub CutHoldingTurn()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CIRCULATION.SP_RESERVATION_CUTTURN"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intReservationID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As OracleException
                            intErrorCode = ex.Code
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spReservationCutTurn"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intReservationID
                        Try
                            .ExecuteNonQuery()
                        Catch ex As SqlException
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' GetHolding By ItemID method
        ' Purpose: Get cir_holding table with ItemID
        ' Input:ItemID
        ' Output: datatable result
        Public Function GetHoldingByItemID() As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Cir_tblReserveRequest_Sel"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = lngItemID
                            Try
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblCirHolding")
                                GetHoldingByItemID = dsData.Tables("tblCirHolding")
                                dsData.Tables.Remove("tblCirHolding")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "CIRCULATION.SP_CIR_HOLDING_SEL"
                            .CommandType = CommandType.StoredProcedure
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            Try
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblLoanType")
                                GetHoldingByItemID = dsData.Tables("tblLoanType")
                                dsData.Tables.Remove("tblLoanType")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
