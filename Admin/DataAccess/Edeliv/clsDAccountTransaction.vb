' Name: clsDAccountTransaction
' Purpose: Management account transactions
' Creator: Oanhtn
' Created Date: 01/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Edeliv
    Public Class clsDAccountTransaction
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strCreatedDate As String
        Private strReason As String
        Private strCurrencyCode As String
        Private strCustomerCode As String
        Private dblRate As Double
        Private dblAmount As Double
        Private dblDebt As Double
        Private intMonth As Integer
        Private intYear As Integer
        Private strPaymentIDs As String
        Private intPaymentID As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' Reason property
        Public Property Reason() As String
            Get
                Return strReason
            End Get
            Set(ByVal Value As String)
                strReason = Value
            End Set
        End Property

        ' CurrencyCode property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property

        ' CustomerCode property
        Public Property CustomerCode() As String
            Get
                Return strCustomerCode
            End Get
            Set(ByVal Value As String)
                strCustomerCode = Value
            End Set
        End Property

        ' Rate property
        Public Property Rate() As Double
            Get
                Return dblRate
            End Get
            Set(ByVal Value As Double)
                dblRate = Value
            End Set
        End Property

        ' Amount property
        Public Property Amount() As Double
            Get
                Return dblAmount
            End Get
            Set(ByVal Value As Double)
                dblAmount = Value
            End Set
        End Property

        ' Debt property
        Public Property Debt() As Double
            Get
                Return dblDebt
            End Get
            Set(ByVal Value As Double)
                dblDebt = Value
            End Set
        End Property

        ' Month property
        Public Property Month() As Integer
            Get
                Return intMonth
            End Get
            Set(ByVal Value As Integer)
                intMonth = Value
            End Set
        End Property

        ' Year property
        Public Property Year() As String
            Get
                Return intYear
            End Get
            Set(ByVal Value As String)
                intYear = Value
            End Set
        End Property

        ' PaymentIDs property
        Public Property PaymentIDs() As String
            Get
                Return strPaymentIDs
            End Get
            Set(ByVal Value As String)
                strPaymentIDs = Value
            End Set
        End Property

        ' PaymentID property
        Public Property PaymentID() As String
            Get
                Return intPaymentID
            End Get
            Set(ByVal Value As String)
                intPaymentID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: create new transaction record
        ' Input: main infor of transaction infor
        ' Output: int value (0 when success)
        Public Function Create() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_CREATE_EDELIV_ACCTRAN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCustomerCode", OracleType.VarChar, 30)).Value = strCustomerCode
                                .Add(New OracleParameter("mnyAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrencyCode
                                .Add(New OracleParameter("fltRate", OracleType.Float)).Value = dblRate
                                .Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 15)).Value = strCreatedDate
                                .Add(New OracleParameter("strReason", OracleType.VarChar, 2000)).Value = strReason
                                .Add(New OracleParameter("strPaymentIDs", OracleType.VarChar, 1000)).Value = strPaymentIDs
                                .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("intOutPut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Edl_spRequestMode_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCustomerCode", SqlDbType.VarChar, 30)).Value = strCustomerCode
                                .Add(New SqlParameter("@mnyAmount", SqlDbType.Money)).Value = dblAmount
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrencyCode
                                .Add(New SqlParameter("@fltRate", SqlDbType.Float)).Value = dblRate
                                .Add(New SqlParameter("@strCreatedDate", SqlDbType.VarChar, 15)).Value = strCreatedDate
                                .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 2000)).Value = strReason
                                .Add(New SqlParameter("@strPaymentIDs", SqlDbType.VarChar, 1000)).Value = strPaymentIDs
                                .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("@intOutPut").Value
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

        ' Update method
        ' Purpose: update information of the selected transaction record
        ' Input: main infor of transaction infor
        ' Output: int value (0 when success)
        Public Function Update() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_UPDATE_EDELIV_ACCTRAN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intPaymentID
                                .Add(New OracleParameter("mnyAmount", OracleType.Float)).Value = dblAmount
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrencyCode
                                .Add(New OracleParameter("fltRate", OracleType.Float)).Value = dblRate
                                .Add(New OracleParameter("strCreatedDate", OracleType.VarChar, 15)).Value = strCreatedDate
                                .Add(New OracleParameter("strReason", OracleType.VarChar, 2000)).Value = strReason
                                .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("intOutPut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Edl_spAccTran_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intPaymentID
                                .Add(New SqlParameter("@mnyAmount", SqlDbType.Money)).Value = dblAmount
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 10)).Value = strCurrencyCode
                                .Add(New SqlParameter("@fltRate", SqlDbType.Float)).Value = dblRate
                                .Add(New SqlParameter("@strCreatedDate", SqlDbType.VarChar, 15)).Value = strCreatedDate
                                .Add(New SqlParameter("@strReason", SqlDbType.NVarChar, 2000)).Value = strReason
                                .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("@intOutPut").Value
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

        ' Delete method
        ' Purpose: delete the selected transaction record
        ' Input: PaymentID
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_DELETE_EDELIV_ACCTRAN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intPaymentID
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
                        .CommandText = "Edl_spPayment_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intPaymentID
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

        ' CheckDebt method
        ' Purpose: check debt of the selected customer
        ' Input: customercode
        ' Output: datatable result
        Public Function CheckDebt(ByRef dblDebt As Double, ByRef intOutPut As Int16) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_CHECKDEBT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCustomerCode", OracleType.VarChar, 30)).Value = strCustomerCode
                            .Parameters.Add(New OracleParameter("mnyDebt", OracleType.Float)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            CheckDebt = dsData.Tables("tblResult")
                            dblDebt = .Parameters("mnyDebt").Value
                            intOutPut = .Parameters("intOutPut").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Edl_spUser_CheckDebit"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCustomerCode", SqlDbType.VarChar, 30)).Value = strCustomerCode
                            .Parameters.Add(New SqlParameter("@mnyDebt", SqlDbType.Money)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            CheckDebt = dsData.Tables("tblResult")
                            dblDebt = .Parameters("@mnyDebt").Value
                            intOutPut = .Parameters("@intOutPut").Value
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

        ' GetAccInfor method
        ' Purpose: Get account infor
        ' Input: main infor of transaction infor
        ' Output: datatable result
        Public Function GetAccInfor(ByVal intType As Int16, ByRef dblSeetled As Double, ByRef dblUnSeetled As Double, ByRef dblRemain As Double) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_ACCINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCustomerCode", OracleType.VarChar, 30)).Value = strCustomerCode
                            .Parameters.Add(New OracleParameter("intMonth", OracleType.Number)).Value = intMonth
                            .Parameters.Add(New OracleParameter("intYear", OracleType.Number)).Value = intYear
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("mnySettled", OracleType.Float)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("mnyUnSettled", OracleType.Float)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("mnyRemain", OracleType.Float)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAccInfor = dsData.Tables("tblResult")
                            dblSeetled = .Parameters("mnySettled").Value
                            dblUnSeetled = .Parameters("mnyUnSettled").Value
                            dblRemain = .Parameters("mnyRemain").Value
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
                        .CommandText = "Edl_spUser_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCustomerCode", SqlDbType.VarChar, 30)).Value = strCustomerCode
                            .Parameters.Add(New SqlParameter("@intMonth", SqlDbType.Int)).Value = intMonth
                            .Parameters.Add(New SqlParameter("@intYear", SqlDbType.Int)).Value = intYear
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@mnySettled", SqlDbType.Money)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@mnyUnSettled", SqlDbType.Money)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@mnyRemain", SqlDbType.Money)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            dblSeetled = .Parameters("@mnySettled").Value
                            dblUnSeetled = .Parameters("@mnyUnSettled").Value
                            dblRemain = .Parameters("@mnyRemain").Value
                            GetAccInfor = dsData.Tables("tblResult")
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

        ' GetGenInfor method
        ' Purpose: Get general infor for creating report
        ' Input: main infor
        ' Output: datatable result
        Public Function GetGenInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_GENINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetGenInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With oraCommand
                        .CommandText = "SP_GET_EDELIV_GENINFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetGenInfor = dsData.Tables("tblResult")
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

        ' GetTransYears method
        ' Purpose: Get transaction year
        ' Input: main infor
        ' Output: datatable result
        Public Function GetTransYears() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_TRANSYEAR"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTransYears = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With oraCommand
                        .CommandText = "SP_GET_EDELIV_TRANSYEAR"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetTransYears = dsData.Tables("tblResult")
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