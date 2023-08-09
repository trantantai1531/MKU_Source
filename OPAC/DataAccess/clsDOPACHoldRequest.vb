Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACHoldRequest
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strCardNo As String
        Private strPassword As String
        Private strCopyNumber As String
        Private strValidDateReq As String
        Private intItemID As Integer

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        'ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        ' CardNo property
        Public Property CardNo() As String
            Get
                Return strCardNo
            End Get
            Set(ByVal Value As String)
                strCardNo = Value
            End Set
        End Property

        ' Password property
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        ' CopyNumber property
        Public Property CopyNumber() As String
            Get
                Return strCopyNumber
            End Get
            Set(ByVal Value As String)
                strCopyNumber = Value
            End Set
        End Property

        ' ValidDateReq Property
        Public Property ValidDateReq() As String
            Get
                Return strValidDateReq
            End Get
            Set(ByVal Value As String)
                strValidDateReq = Value
            End Set
        End Property

        ' Purpose: Create Holding Request
        ' Input: @intItemID,@strCardNo,@strPassWord,@strValidDate,@strCopyNumber
        ' output: Byte
        ' 0-successfull
        ' 1-Patron is not Exists
        ' 2-Patron card is expired
        ' 3-Patron already request this item
        ' 4-Over Loan
        ' 5-Over Holding
        ' 6- Copynumber is invalid
        Public Function CreateHold() As Byte
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spHolding_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                                .Add(New SqlParameter("@strPassWord", SqlDbType.VarChar, 50)).Value = strPassword
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar, 20)).Value = strValidDateReq
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 32)).Value = strCopyNumber
                                .Add(New SqlParameter("@intRET", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateHold = .Parameters("@intRET").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spHolding_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                                .Add(New OracleParameter("strPassWord", OracleType.VarChar, 50)).Value = strPassword
                                .Add(New OracleParameter("strValidDate", OracleType.VarChar, 20)).Value = strValidDateReq
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 32)).Value = strCopyNumber
                                .Add(New OracleParameter("intRET", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateHold = .Parameters("intRET").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        ' Purpose: Create Reservation Request
        ' Input: @intItemID,@strCardNo,@strPassWord,@strValidDate,@strCopyNumber
        ' Output: Byte
        ' 0-successfull
        ' 1-Patron is not Exists
        ' 2-Patron card is expired
        ' 3-Patron already request this item
        ' 4-Patron already has a copy on loan
        ' 5-No copy is in patron's accessible locations
        Public Function CreateReserv() As Byte
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spReservation_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                                .Add(New SqlParameter("@strPassWord", SqlDbType.VarChar, 50)).Value = strPassword
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar, 20)).Value = strValidDateReq
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 32)).Value = strCopyNumber
                                .Add(New SqlParameter("@intRET", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateReserv = .Parameters("@intRET").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spReservation_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                                .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                                .Add(New OracleParameter("strPassWord", OracleType.VarChar, 50)).Value = strPassword
                                .Add(New OracleParameter("strValidDate", OracleType.VarChar, 20)).Value = strValidDateReq
                                .Add(New OracleParameter("strCopyNumber", OracleType.VarChar, 32)).Value = strCopyNumber
                                .Add(New OracleParameter("intRET", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateReserv = .Parameters("intRET").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function
        Public Function CreateReserv_Report() As Byte
            Me.OpenConnection()
                    With sqlCommand
                        .CommandText = "Opac_spReservation_Create_Report"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                                .Add(New SqlParameter("@strPassWord", SqlDbType.VarChar, 50)).Value = strPassword
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar, 20)).Value = strValidDateReq
                                .Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 32)).Value = strCopyNumber
                                '.Add(New SqlParameter("@intRET", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            'CreateReserv = .Parameters("@intRET").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With 
            Me.CloseConnection()
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