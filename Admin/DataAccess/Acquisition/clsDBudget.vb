'class: clsDBudget
' Purpose: proccess information of budget
' Creator: lent
'created date: 28-3-2005
'histoty update:

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDBudget
        Inherits clsDBase
        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intBudID As Integer
        Private intPoID As Integer
        Private strCurrency As String
        Private strBudgetCode As String
        Private strPurpose As String
        Private douBalance As Double
        Private douRealBalance As Double
        Private strBudgetName As String
        Private intStatus As Integer
        Private dblStartRemain As Double
        Private dblLastBase As Double
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property BudID() As Integer
            Get
                Return (intBudID)
            End Get
            Set(ByVal Value As Integer)
                intBudID = Value
            End Set
        End Property
        Public Property Currency() As String
            Get
                Return (strCurrency)
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property
        Public Property BudgetCode() As String
            Get
                Return (strBudgetCode)
            End Get
            Set(ByVal Value As String)
                strBudgetCode = Value
            End Set
        End Property
        Public Property BudgetName() As String
            Get
                Return (strBudgetName)
            End Get
            Set(ByVal Value As String)
                strBudgetName = Value
            End Set
        End Property
        Public Property Purpose() As String
            Get
                Return (strPurpose)
            End Get
            Set(ByVal Value As String)
                strPurpose = Value
            End Set
        End Property
        Public Property Balance() As Double
            Get
                Return (douBalance)
            End Get
            Set(ByVal Value As Double)
                douBalance = Value
            End Set
        End Property
        Public Property RealBalance() As Double
            Get
                Return (douRealBalance)
            End Get
            Set(ByVal Value As Double)
                douRealBalance = Value
            End Set
        End Property

        Public Property Status() As Integer
            Get
                Return (intStatus)
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        Public Property PoID() As Integer
            Get
                Return (intPoID)
            End Get
            Set(ByVal Value As Integer)
                intPoID = Value
            End Set
        End Property


        ' *************************************************************************************************
        ' End declare properties
        ' Declare public function 
        ' *************************************************************************************************

        ' Method: CreateBudget
        ' Purpose: create new a budget
        ' Input: budget informations
        ' Output: int value (0 if fail)
        ' Creator: lent
        Public Function CreateBudget() As Integer
            Dim intRetval As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BUDGET_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strBudgetName", OracleType.VarChar, 150)).Value = strBudgetName
                                .Add(New OracleParameter("strBudgetCode", OracleType.VarChar, 16)).Value = strBudgetCode
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 15)).Value = strCurrency
                                .Add(New OracleParameter("strPurpose", OracleType.VarChar, 300)).Value = strPurpose
                                .Add(New OracleParameter("monBalance", OracleType.Float)).Value = douBalance
                                .Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus

                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spBudget_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strBudgetName", SqlDbType.NVarChar, 50)).Value = strBudgetName
                                .Add(New SqlParameter("@strBudgetCode", SqlDbType.NVarChar, 16)).Value = strBudgetCode
                                .Add(New SqlParameter("@strCurrency", SqlDbType.NVarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@strPurpose", SqlDbType.NVarChar, 100)).Value = strPurpose
                                .Add(New SqlParameter("@monBalance", SqlDbType.Float)).Value = douBalance
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intRetval
        End Function

        ' Method: UpdateBudget
        ' Purpose: update information of budget
        ' Input: budget informations
        ' Output: int value (0 if fail)
        ' Creator: lent
        Public Function UpdateBudget() As Integer
            Dim intRetVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BUDGET_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intBudID", OracleType.Number, 4)).Value = intBudID
                                .Add(New OracleParameter("strBudgetName", OracleType.VarChar, 50)).Value = strBudgetName
                                .Add(New OracleParameter("strBudgetCode", OracleType.VarChar, 16)).Value = strBudgetCode
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 10)).Value = strCurrency
                                .Add(New OracleParameter("intStatus", OracleType.Number, 4)).Value = intStatus
                                .Add(New OracleParameter("strPurpose", OracleType.VarChar, 100)).Value = strPurpose
                                .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spBudget_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intBudID", SqlDbType.Int, 4)).Value = intBudID
                                .Add(New SqlParameter("@strBudgetName", SqlDbType.NVarChar, 50)).Value = strBudgetName
                                .Add(New SqlParameter("@strBudgetCode", SqlDbType.NVarChar, 16)).Value = strBudgetCode
                                .Add(New SqlParameter("@strCurrency", SqlDbType.NVarChar, 10)).Value = strCurrency
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int, 4)).Value = intStatus
                                .Add(New SqlParameter("@strPurpose", SqlDbType.NVarChar, 100)).Value = strPurpose
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            UpdateBudget = intRetVal
        End Function

        ' Method: DeleteBudget
        ' Purpose: delete a budget
        ' Input: BudgetID
        ' Creator: lent
        Public Sub DeleteBudget()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BUDGET_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intBudID", OracleType.Number, 4)).Value = intBudID
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
                        .CommandText = "Acq_spBudget_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intBudID", SqlDbType.Int, 4)).Value = intBudID
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

        ' Method: TransferMoney
        ' Purpose: Transfer money between budgets
        ' Input: some informations
        ' Creator:Lent
        Public Sub TransferMoney(ByVal intIDSrc As Integer, ByVal intIDDes As Integer, ByVal dbMonSrc As Double, ByVal dbMonDes As Double)
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BUDGET_TRANSFER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intIDSrc", OracleType.Number)).Value = intIDSrc
                                .Add(New OracleParameter("intIDDes", OracleType.Number)).Value = intIDDes
                                .Add(New OracleParameter("dbMonSrc", OracleType.Float)).Value = dbMonSrc
                                .Add(New OracleParameter("dbMonDes", OracleType.Float)).Value = dbMonDes
                            End With
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
                        .CommandText = "Acq_spBudget_Transfer"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intIDSrc", SqlDbType.Int)).Value = intIDSrc
                                .Add(New SqlParameter("@intIDDes", SqlDbType.Int)).Value = intIDDes
                                .Add(New SqlParameter("@dbMonSrc", SqlDbType.Float)).Value = dbMonSrc
                                .Add(New SqlParameter("@dbMonDes", SqlDbType.Float)).Value = dbMonDes
                            End With
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
        ' Method: TransferMoney
        ' Purpose: Transfer money between budgets with check
        ' Input: some informations
        ' Creator:Tulnn
        Public Function TransferMoneyWithCheck(ByVal intIDSrc As Integer, ByVal intIDDes As Integer, ByVal dbMonSrc As Double, ByVal dbMonDes As Double) As Integer
            Dim intRetVal As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BUDGET_TRANSFER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intIDSrc", OracleType.Number)).Value = intIDSrc
                                .Add(New OracleParameter("intIDDes", OracleType.Number)).Value = intIDDes
                                .Add(New OracleParameter("dbMonSrc", OracleType.Float)).Value = dbMonSrc
                                .Add(New OracleParameter("dbMonDes", OracleType.Float)).Value = dbMonDes
                            End With
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
                        .CommandText = "SP_ACQ_BUDGET_TRANSFER_WITH_CHECK"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                                .Add(New SqlParameter("@intIDSrc", SqlDbType.Int)).Value = intIDSrc
                                .Add(New SqlParameter("@intIDDes", SqlDbType.Int)).Value = intIDDes
                                .Add(New SqlParameter("@dbMonSrc", SqlDbType.Float)).Value = dbMonSrc
                                .Add(New SqlParameter("@dbMonDes", SqlDbType.Float)).Value = dbMonDes
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            TransferMoneyWithCheck = intRetVal
        End Function

        ' Method: GetBudget
        ' Purpose: Get information of Budget(s)
        ' Input: BudgetID
        ' Output: Datatable result
        ' Creator: lent
        Public Function GetBudget(Optional ByVal intFromPO As Integer = 0, Optional ByVal intDisplay As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spBudget_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intBudID", SqlDbType.Int)).Value = intBudID
                            .Parameters.Add(New SqlParameter("@intFromPO", SqlDbType.Int)).Value = intFromPO
                            .Parameters.Add(New SqlParameter("@intDisplay", SqlDbType.Int)).Value = intDisplay
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetBudget = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_BUDGET_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intBudID", OracleType.Number, 4)).Value = intBudID
                            .Parameters.Add(New OracleParameter("intFromPO", OracleType.Number, 4)).Value = intFromPO
                            .Parameters.Add(New OracleParameter("intDisplay", OracleType.Number, 4)).Value = intDisplay
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetBudget = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Method: GetBudget
        ' Purpose: Get information of Budget(s)
        ' Input: BudgetID
        ' Output: Datatable result
        ' Creator: lent
        Public Function GetGroupStausPO() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spStatus_GetGroupStatusPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetGroupStausPO = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Close()
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
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
                    If Not SqlDataAdapter Is Nothing Then
                        SqlDataAdapter.Dispose()
                        SqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace