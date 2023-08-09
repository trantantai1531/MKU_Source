'class:
' Purpose:
' Creator:
'created date:
'histoty update:

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDPurchaseOrder
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intAcqPOID As Integer = 0
        Private strReceiptNo As String = ""
        Private strPoName As String = ""
        Private intVendorID As Integer = 0
        Private intPoType As Integer = 0
        Private strValidDate As String = ""
        Private strFilledDate As String = ""
        Private strSetDate As String = ""
        Private intStatusID As Integer = 0
        Private intDirection As Integer = 0
        Private dblTotalAmount As Double = 0
        Private dblPrepaidAmount As Double = 0
        Private dblFixedRate As Double = 0
        Private dblDiscount As Double = 0
        Private strCurrency As String = ""
     
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' Direction property
        Public Property Direction() As Integer
            Get
                Return intDirection
            End Get
            Set(ByVal Value As Integer)
                intDirection = Value
            End Set
        End Property

        ' ACQPOID property
        Public Property ACQPOID() As Integer
            Get
                Return intAcqPOID
            End Get
            Set(ByVal Value As Integer)
                intAcqPOID = Value
            End Set
        End Property

        ' ReceiptNo property
        Public Property ReceiptNo() As String
            Get
                Return strReceiptNo
            End Get
            Set(ByVal Value As String)
                strReceiptNo = Value
            End Set
        End Property

        ' PoName property
        Public Property PoName() As String
            Get
                Return strPoName
            End Get
            Set(ByVal Value As String)
                strPoName = Value
            End Set
        End Property

        ' VendorID property
        Public Property VendorID() As Integer
            Get
                Return intVendorID
            End Get
            Set(ByVal Value As Integer)
                intVendorID = Value
            End Set
        End Property

        ' PoType property
        Public Property PoType() As Integer
            Get
                Return intPoType
            End Get
            Set(ByVal Value As Integer)
                intPoType = Value
            End Set
        End Property

        ' ValidDate property
        Public Property ValidDate() As String
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        ' FilledDate property
        Public Property FilledDate() As String
            Get
                Return strFilledDate
            End Get
            Set(ByVal Value As String)
                strFilledDate = Value
            End Set
        End Property

        ' SetDate property
        Public Property SetDate() As String
            Get
                Return strSetDate
            End Get
            Set(ByVal Value As String)
                strSetDate = Value
            End Set
        End Property

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return intStatusID
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' TotalAmount property
        Public Property TotalAmount() As Double
            Get
                Return dblTotalAmount
            End Get
            Set(ByVal Value As Double)
                dblTotalAmount = Value
            End Set
        End Property

        ' PrepaidAmount property
        Public Property PrepaidAmount() As Double
            Get
                Return dblPrepaidAmount
            End Get
            Set(ByVal Value As Double)
                dblPrepaidAmount = Value
            End Set
        End Property

        ' FixedRate property
        Public Property FixedRate() As Double
            Get
                Return dblFixedRate
            End Get
            Set(ByVal Value As Double)
                dblFixedRate = Value
            End Set
        End Property

        ' Discount property
        Public Property Discount() As Double
            Get
                Return dblDiscount
            End Get
            Set(ByVal Value As Double)
                dblDiscount = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Method: Create
        ' Purpose: create new contract
        ' Input: contract's information
        ' Output: integer value (0 if success)
        ' Creator: Oanhtn
        Public Function Create() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CREATE_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strReceiptNo", OracleType.VarChar, 50)).Value = strReceiptNo
                                .Add(New OracleParameter("strPoName", OracleType.VarChar, 150)).Value = strPoName
                                .Add(New OracleParameter("intVendorID", OracleType.Number)).Value = intVendorID
                                .Add(New OracleParameter("intPoType", OracleType.Number)).Value = intPoType
                                .Add(New OracleParameter("strValidDate", OracleType.VarChar, 30)).Value = strValidDate
                                .Add(New OracleParameter("strFilledDate", OracleType.VarChar, 30)).Value = strFilledDate
                                .Add(New OracleParameter("intStatusID", OracleType.Number)).Value = intStatusID
                                .Add(New OracleParameter("dblTotalAmount", OracleType.Float)).Value = dblTotalAmount
                                .Add(New OracleParameter("dblPrepaidAmount", OracleType.Float)).Value = dblPrepaidAmount
                                .Add(New OracleParameter("dblFixedRate", OracleType.Float)).Value = dblFixedRate
                                .Add(New OracleParameter("dblDiscount", OracleType.Float)).Value = dblDiscount
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 30)).Value = strCurrency
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strReceiptNo", SqlDbType.NVarChar)).Value = strReceiptNo
                                .Add(New SqlParameter("@strPoName", SqlDbType.NVarChar)).Value = strPoName
                                .Add(New SqlParameter("@intVendorID", SqlDbType.Int)).Value = intVendorID
                                .Add(New SqlParameter("@intPoType", SqlDbType.Int)).Value = intPoType
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar)).Value = strValidDate
                                .Add(New SqlParameter("@strFilledDate", SqlDbType.VarChar)).Value = strFilledDate
                                .Add(New SqlParameter("@intStatusID", SqlDbType.Int)).Value = intStatusID
                                .Add(New SqlParameter("@dblTotalAmount", SqlDbType.Real)).Value = dblTotalAmount
                                .Add(New SqlParameter("@dblPrepaidAmount", SqlDbType.Real)).Value = dblPrepaidAmount
                                .Add(New SqlParameter("@dblFixedRate", SqlDbType.Real)).Value = dblFixedRate
                                .Add(New SqlParameter("@dblDiscount", SqlDbType.Real)).Value = dblDiscount
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar)).Value = strCurrency
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intRetVal
        End Function

        ' Method: Update
        ' Purpose: Update information of the selected contract
        ' Input: contract's information
        ' Output: integer value (0 if success)
        ' Creator: Oanhtn
        Public Function Update(ByVal strStatusNote As String) As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_UPDATE_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intID", OracleType.Number)).Value = intAcqPOID
                                .Add(New OracleParameter("strReceiptNo", OracleType.VarChar, 50)).Value = strReceiptNo
                                .Add(New OracleParameter("strPoName", OracleType.VarChar, 150)).Value = strPoName
                                .Add(New OracleParameter("intVendorID", OracleType.Number)).Value = intVendorID
                                .Add(New OracleParameter("intPoType", OracleType.Number)).Value = intPoType
                                .Add(New OracleParameter("intStatusID", OracleType.Number)).Value = intStatusID
                                .Add(New OracleParameter("strStatusNote", OracleType.VarChar, 200)).Value = strStatusNote
                                .Add(New OracleParameter("strValidDate", OracleType.VarChar, 30)).Value = strValidDate
                                .Add(New OracleParameter("strFilledDate", OracleType.VarChar, 30)).Value = strFilledDate
                                .Add(New OracleParameter("dblTotalAmount", OracleType.Float)).Value = dblTotalAmount
                                .Add(New OracleParameter("dblPrepaidAmount", OracleType.Float)).Value = dblPrepaidAmount
                                .Add(New OracleParameter("dblFixedRate", OracleType.Float)).Value = dblFixedRate
                                .Add(New OracleParameter("dblDiscount", OracleType.Float)).Value = dblDiscount
                                .Add(New OracleParameter("strCurrency", OracleType.VarChar, 30)).Value = strCurrency
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_UpdContract"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intAcqPOID
                                .Add(New SqlParameter("@strReceiptNo", SqlDbType.NVarChar)).Value = strReceiptNo
                                .Add(New SqlParameter("@strPoName", SqlDbType.NVarChar)).Value = strPoName
                                .Add(New SqlParameter("@intVendorID", SqlDbType.Int)).Value = intVendorID
                                .Add(New SqlParameter("@intPoType", SqlDbType.Int)).Value = intPoType
                                .Add(New SqlParameter("@intStatusID", SqlDbType.Int)).Value = intStatusID
                                .Add(New SqlParameter("@strStatusNote", SqlDbType.NVarChar)).Value = strStatusNote
                                .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar)).Value = strValidDate
                                .Add(New SqlParameter("@strFilledDate", SqlDbType.VarChar)).Value = strFilledDate
                                .Add(New SqlParameter("@dblTotalAmount", SqlDbType.Real)).Value = dblTotalAmount
                                .Add(New SqlParameter("@dblPrepaidAmount", SqlDbType.Real)).Value = dblPrepaidAmount
                                .Add(New SqlParameter("@dblFixedRate", SqlDbType.Real)).Value = dblFixedRate
                                .Add(New SqlParameter("@dblDiscount", SqlDbType.Real)).Value = dblDiscount
                                .Add(New SqlParameter("@strCurrency", SqlDbType.VarChar)).Value = strCurrency
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            intRetVal = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Return intRetVal
        End Function

        ' Method: Delete 
        ' Purpose: delete information of the selected contract
        ' Input: ID
        ' Output: integer value
        ' Creator: oanhtn
        Public Function Delete() As Integer
            Dim intRetVal As Integer = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_DELETE_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intAcqPOID
                            .Parameters.Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
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
                        .CommandText = "Acq_spPO_DelContract"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intAcqPOID
                            .Parameters.Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
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
            Return intRetVal
            Call CloseConnection()
        End Function

        Public Function GetItemCodeByPO(ByVal strPOCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_ITEMCODE_BYPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPOCode", OracleType.VarChar, 50)).Value = strPOCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblGetItemCodeByPO")
                            GetItemCodeByPO = dsData.Tables("tblGetItemCodeByPO")
                            dsData.Tables.Remove("tblGetItemCodeByPO")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_SelItemCode"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPOCode", SqlDbType.NVarChar, 50)).Value = strPOCode
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblGetItemCodeByPO")
                            GetItemCodeByPO = dsData.Tables("tblGetItemCodeByPO")
                            dsData.Tables.Remove("tblGetItemCodeByPO")
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

        ' Purpose: Get all informations form Acq_tblPo by index 
        Public Function GetPO(Optional ByVal strReceiptPO As String = "") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intAcqPOID", OracleType.Number)).Value = intAcqPOID ' index
                            .Parameters.Add(New OracleParameter("strReceiptPO", OracleType.VarChar, 50)).Value = strReceiptPO
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPO = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    Dim dt As New DataTable
                    With SqlCommand
                        .CommandText = "Acq_spPO_SelContact"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intAcqPOID", SqlDbType.Int)).Value = intAcqPOID
                        .Parameters.Add(New SqlParameter("@strReceiptPO", SqlDbType.NVarChar, 50)).Value = strReceiptPO
                        .Parameters.Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            If Not dsData.Tables("tblResult") Is Nothing Then
                                dsData.Tables.Remove("tblResult")
                            End If
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPO = dsData.Tables("tblResult")
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

        Public Function GetPO(Optional ByVal strReceiptPO As String = "", Optional intStatus As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Dim dt As New DataTable
                    With sqlCommand
                        .CommandText = "Acq_spPO_SelContactByStatus"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intAcqPOID", SqlDbType.Int)).Value = intAcqPOID
                        .Parameters.Add(New SqlParameter("@strReceiptPO", SqlDbType.NVarChar, 50)).Value = strReceiptPO
                        .Parameters.Add(New SqlParameter("@intLibId", SqlDbType.Int)).Value = intLibID
                        .Parameters.Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            If Not dsData.Tables("tblResult") Is Nothing Then
                                dsData.Tables.Remove("tblResult")
                            End If
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPO = dsData.Tables("tblResult")
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

        Public Function GetPOID(ByVal intACQITEMID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_POIDFROMACQITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intACQITEMID", OracleType.Number)).Value = intACQITEMID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPOID = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spItem_SelPOIdById"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intACQITEMID", SqlDbType.Int)).Value = intACQITEMID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPOID = dsData.Tables("tblResult")
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

        Public Function GetAcqItemInfor(ByVal intACQITEMID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_ACQITEM_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intACQITEMID", OracleType.Number)).Value = intACQITEMID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAcqItemInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spItem_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intACQITEMID", SqlDbType.Int)).Value = intACQITEMID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqItemInfor = dsData.Tables("tblResult")
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

        ' Method: GetListPOs
        ' Purpose: Get list of ordered items
        ' Output: Datatable result
        Public Function GetListPOs() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_GET_LIST_POS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetListPOs = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spPO_SelList"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetListPOs = dsData.Tables("tblResult")
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

        ' Purpose: Get CheckingReceived Item
        ' Input: intPOID
        ' Output: Datatable 
        ' Creator: Sondp
        Public Function GetCheckingReceived() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Dim oraDataAdapter As OracleDataAdapter
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_CHECKINGRECEIVED"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPOID", OracleType.Number)).Value = intAcqPOID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCheckingReceived = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spItem_CheckingReceived"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPOID", SqlDbType.Int)).Value = intAcqPOID
                            .ExecuteNonQuery()
                            SqlDataAdapter = New SqlDataAdapter(SqlCommand)
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCheckingReceived = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose:
        ' Input:
        ' Output:
        ' Creator:
        Public Sub SendOrder()

        End Sub

        ' Class: GetOrderedItems
        ' Purpose: Get ordered items of this cotract
        ' Input: AcqPOID
        ' Output: datatable result
        ' Creator: Oanhtn
        Public Function GetOrderedItems() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    Dim oraDataAdapter As OracleDataAdapter
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ITEMS_OF_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intContractID", OracleType.Number)).Value = intAcqPOID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetOrderedItems = dsData.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_SelItemOfContract"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intContractID", SqlDbType.Int)).Value = intAcqPOID
                            SqlDataAdapter = New SqlDataAdapter(SqlCommand)
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetOrderedItems = dsData.Tables("tblResult")
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

        ' Class: GetStatusLog
        ' Purpose: Get status log of the selected contract
        ' Input: contractID
        ' Output: datatable result
        ' Creator: Oanhtn
        Public Function GetStatusLog() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_STATUS_OF_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intContractID", OracleType.Number)).Value = intAcqPOID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetStatusLog = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spStatus_SelStatusofContract"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intContractID", SqlDbType.Int)).Value = intAcqPOID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetStatusLog = dsData.Tables("tblResult")
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

        ' Purpose:
        ' Input:
        ' Output:
        ' Creator:
        Public Function GetSumariesOfItemOrdered() As DataTable

        End Function

        ' Purpose: Get ContractID
        ' Input: intPOS
        ' Output: integer value
        ' Creator: Oanhtn
        ' CreatedDate: 04/03/2005
        Public Function GetContractID(ByVal intPOS As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_POID_BY_POS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPOS", OracleType.Number)).Value = intPOS
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetContractID = dsData.Tables("tblResult").Rows(0).Item(0)
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
                        .CommandText = "Acq_spPO_SelIdByPos"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intPOS", SqlDbType.Int)).Value = intPOS
                        .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetContractID = dsData.Tables("tblResult").Rows(0).Item(0)
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

        ' Purpose: Get finacial information of the selected contract
        ' Input: contractID
        ' Output: datatable result
        ' Creator: Oanhtn
        ' CreatedDate: 02/04/2005
        Public Function GetFinacialInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_FINACIAL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intContractID", OracleType.Number)).Value = intAcqPOID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFinacialInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spBudget_SelFinacial"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intContractID", SqlDbType.Int)).Value = intAcqPOID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFinacialInfor = dsData.Tables("tblResult")
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

        ' Methrod: GetAcqPoInfor
        ' Input: integer value of PoID
        ' Output: DataTable
        Public Function GetAcqPoInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_PO_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPoID", OracleType.Number)).Value = intAcqPOID
                            .Parameters.Add(New OracleParameter("intDirection", OracleType.Number)).Value = intDirection
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetAcqPoInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Acq_spPO_SelByPOIdAndDirection"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPoID", SqlDbType.Int)).Value = intAcqPOID
                            .Parameters.Add(New SqlParameter("@intDirection", SqlDbType.Int)).Value = intDirection
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqPoInfor = dsData.Tables("tblResult")
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

        Public Function GetAcqPoStatus() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"

                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spPoStatus_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPoId", SqlDbType.Int)).Value = intAcqPOID
                            .Parameters.Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatusID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetAcqPoStatus = dsData.Tables("tblResult")
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

        ' Method: BrowseContract
        ' Purpose: browse contract list
        ' Input: some main infor
        ' Output: DataTable result
        ' Creator: Tuanhv
        Public Function BrowseContract(ByVal intParameter1 As Integer, ByVal intParameter2 As Integer, ByVal intOption As Integer, ByVal intLibIDParameter As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_BROWSE_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intParameter1", OracleType.Number)).Value = intParameter1
                            .Parameters.Add(New OracleParameter("intParameter2", OracleType.Number)).Value = intParameter2
                            .Parameters.Add(New OracleParameter("intOption", OracleType.Number)).Value = intOption
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            BrowseContract = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spPo_BrowseContract"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intParameter1", SqlDbType.Int)).Value = intParameter1
                            .Parameters.Add(New SqlParameter("@intParameter2", SqlDbType.Int)).Value = intParameter2
                            .Parameters.Add(New SqlParameter("@intOption", SqlDbType.Int)).Value = intOption
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibIDParameter
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            BrowseContract = dsData.Tables("tblResult")
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

        ' Method: SearchContract
        ' Output: DataTable
        Public Function SearchContract() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CONTRACT_SEARCH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strSelectStatement", OracleType.NVarChar, 1000)).Value = strSQLStatement
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spContactSearch"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strSelectStatement", SqlDbType.NVarChar)).Value = strSQLStatement
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            SearchContract = dsData.Tables("tblResult")
            dsData.Dispose()
            dsData = Nothing
            Call CloseConnection()
        End Function

        ' Purpose: Get Items to display on table collums title
        ' In: intPOID, strHaveFields
        ' Out: Datatable
        ' Creator: Sondp
        ' CreatedDate" 06/04/2005
        Public Function GetPOClaimHeader(ByVal intPOID As Integer, ByVal strHaveFields As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPO_SelCliaimItems"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPOID", SqlDbType.Int, 4)).Value = intPOID
                            .Parameters.Add(New SqlParameter("@strHaveFields", SqlDbType.VarChar, 4000)).Value = strHaveFields
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPOClaimHeader = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ACQ_GET_CLIAIMITEMS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPOID", OracleType.Number, 4)).Value = intPOID
                            .Parameters.Add(New OracleParameter("strHaveFields", OracleType.VarChar, 4000)).Value = strHaveFields
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPOClaimHeader = dsData.Tables("tblResult")
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

        ' Purpose: Get Items to display on table
        ' In: intPOID
        ' Out: Datatable
        ' Creator: Sondp
        ' CreatedDate" 06/04/2005
        Public Function GetPOClaimItems(ByVal intPOID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spItem_SelToClaim"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPOID", SqlDbType.Int, 4)).Value = intPOID
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetPOClaimItems = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ACQ_GET_ITEMS_TOCLAIM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPOID", OracleType.Number, 4)).Value = intPOID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPOClaimItems = dsData.Tables("tblResult")
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

        ' Purpose: Remove items of the selected contract
        ' Input: Source ItemID
        ' Creator: Oanhtn
        ' CreatedDate: 09/04/2005
        Public Sub RemoveItems(ByVal strItemIDs As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_REM_ITEMS_OF_CONTRACT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 200)).Value = strItemIDs
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
                        .CommandText = "Acq_spItem_UpdPOIdByItemIds"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar)).Value = strItemIDs
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

        ' Method: GetTotalContracts
        ' Purpose: Get total of contracts
        ' Output: integer value
        ' Creator: Oanhtn
        ' CreatedDate: 11/04/2005
        Public Function GetTotalContracts() As Integer
            Call OpenConnection()

            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_GET_TOTAL_CONTRACTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTotalContracts = dsData.Tables("tblResult").Rows(0).Item("TOTAL")
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
                        .CommandText = "Acq_spPO_SelTotalContracts"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetTotalContracts = dsData.Tables("tblResult").Rows(0).Item("TOTAL")
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

        ' ****************************************************************************
        ' SERIAL
        ' ****************************************************************************

        ' GetContractList method
        ' Purpose: get list of contracts
        ' Input: some main infor of contract and it's request
        ' Output: datatable result
        Public Function GetContractList(ByVal strValidDateFrom As String, ByVal strValidDateTo As String, ByVal intBudgetID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_SER_GET_CONTRACTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPoType", OracleType.Number)).Value = intPoType
                            .Parameters.Add(New OracleParameter("strPoName", OracleType.NVarChar, 100)).Value = strPoName
                            .Parameters.Add(New OracleParameter("strReceiptNo", OracleType.NVarChar, 50)).Value = strReceiptNo
                            .Parameters.Add(New OracleParameter("intVendorID", OracleType.Number)).Value = intVendorID
                            .Parameters.Add(New OracleParameter("intBudgetID", OracleType.Number)).Value = intBudgetID
                            .Parameters.Add(New OracleParameter("strValidDateTo", OracleType.NVarChar, 30)).Value = strValidDateTo
                            .Parameters.Add(New OracleParameter("strValidDateFrom", OracleType.NVarChar, 30)).Value = strValidDateFrom
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetContractList = dsData.Tables("tblResult")
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
                        .CommandText = "Ser_spGetContract"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPoType", SqlDbType.Int)).Value = intPoType
                            .Parameters.Add(New SqlParameter("@strPoName", SqlDbType.NVarChar)).Value = strPoName
                            .Parameters.Add(New SqlParameter("@strReceiptNo", SqlDbType.NVarChar)).Value = strReceiptNo
                            .Parameters.Add(New SqlParameter("@intVendorID", SqlDbType.Int)).Value = intVendorID
                            .Parameters.Add(New SqlParameter("@intBudgetID", SqlDbType.Int)).Value = intBudgetID
                            .Parameters.Add(New SqlParameter("@strValidDateTo", SqlDbType.NVarChar)).Value = strValidDateTo
                            .Parameters.Add(New SqlParameter("@strValidDateFrom", SqlDbType.NVarChar)).Value = strValidDateFrom
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetContractList = dsData.Tables("tblResult")
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

        ' Change PO Status method
        ' Purpose: Change PO status
        ' Input: POIDs, StatusID
        Public Sub ChangePOStatus(ByVal strPOIDs As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_CHANGE_PO_STATUS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strPOIDs", OracleType.VarChar, 500)).Value = strPOIDs
                            .Parameters.Add(New OracleParameter("intStatusID", OracleType.Number)).Value = intStatusID
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
                        .CommandText = "Acq_spPo_UpdStatus"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strPOIDs", SqlDbType.VarChar)).Value = strPOIDs
                            .Parameters.Add(New SqlParameter("@intStatusID", SqlDbType.Int)).Value = intStatusID
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

        Public Function StatAcqPOStatus(Optional ByVal strDateSetFrom As String = "", Optional ByVal strDateSetTo As String = "", Optional ByVal intAcqSourceID As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spStatAcqPOStatus"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateSetFrom", SqlDbType.VarChar, 20)).Value = strDateSetFrom
                        .Parameters.Add(New SqlParameter("@strDateSetTo", SqlDbType.VarChar, 20)).Value = strDateSetTo
                        .Parameters.Add(New SqlParameter("@intAcqSourceID", SqlDbType.Int)).Value = intAcqSourceID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatAcqPOStatus = dsData.Tables("tblResult")
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

        Public Function StatAcqPOStatusDetail(Optional ByVal strDateSetFrom As String = "", Optional ByVal strDateSetTo As String = "", Optional ByVal intAcqSourceID As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Acq_spStatAcqPOStatus_Detail"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strDateSetFrom", SqlDbType.VarChar, 20)).Value = strDateSetFrom
                        .Parameters.Add(New SqlParameter("@strDateSetTo", SqlDbType.VarChar, 20)).Value = strDateSetTo
                        .Parameters.Add(New SqlParameter("@intAcqSourceID", SqlDbType.Int)).Value = intAcqSourceID
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            StatAcqPOStatusDetail = dsData.Tables("tblResult")
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

        ' Method: Dispose
        ' Purpose: Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call MyBase.Dispose(isDisposing)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace