' Class: clsDVendor
' Purpose: Manage vendor information
' Creator: Sondp
' Created date:
' Modification history:

Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Acquisition
    Public Class clsDVendor
        Inherits clsDBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intVendorID As Integer
        Private intProvinceID As Integer
        Private strNameIDs As String
        Private strName As String
        Private strAddress As String
        Private intCountryID As Integer
        Private strZip As String
        Private strContactPerson As String
        Private strTel As String
        Private strFax As String
        Private strEmail As String
        Private strSAN As String
        Private strLibSAN As String
        Private blnX12Enable As Boolean
        Private strX12Email As String
        Private intDeliveryTime As Integer
        Private intClaimCycle1 As Integer
        Private intClaimCycle2 As Integer
        Private intClaimCycle3 As Integer
        Private strClaimEmail As String
        Private strLibAC As String
        Private strBankingInfo As String
        Private strNote As String
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' ---- Vendor Property
        Public Property Name()
            Get
                Return strName
            End Get
            Set(ByVal Value)
                strName = Value
            End Set
        End Property

        ' ---- Address Property
        Public Property Address()
            Get
                Return strAddress
            End Get
            Set(ByVal Value)
                strAddress = Value
            End Set
        End Property

        ' ---- ProvinceID Property
        Public Property ProvinceID()
            Get
                Return intProvinceID
            End Get
            Set(ByVal Value)
                intProvinceID = Value
            End Set
        End Property

        ' ---- CountryID Property
        Public Property CountryID()
            Get
                Return intCountryID
            End Get
            Set(ByVal Value)
                intCountryID = Value
            End Set
        End Property

        ' ---- Zip Property
        Public Property Zip()
            Get
                Return strZip
            End Get
            Set(ByVal Value)
                strZip = Value
            End Set
        End Property

        ' ---- Contact person Property
        Public Property ContactPerson()
            Get
                Return strContactPerson
            End Get
            Set(ByVal Value)
                strContactPerson = Value
            End Set
        End Property

        ' ---- Telephone Property
        Public Property Tel()
            Get
                Return strTel
            End Get
            Set(ByVal Value)
                strTel = Value
            End Set
        End Property

        ' ---- Fax Property
        Public Property Fax()
            Get
                Return strFax
            End Get
            Set(ByVal Value)
                strFax = Value
            End Set
        End Property

        ' ---- Email Property
        Public Property Email()
            Get
                Return strEmail
            End Get
            Set(ByVal Value)
                strEmail = Value
            End Set
        End Property

        ' ---- SAN Property
        Public Property SAN()
            Get
                Return strSAN
            End Get
            Set(ByVal Value)
                strSAN = Value
            End Set
        End Property

        ' ---- LibSAN Property
        Public Property LibSAN()
            Get
                Return strLibSAN
            End Get
            Set(ByVal Value)
                strLibSAN = Value
            End Set
        End Property

        ' ---- X12Enable Property
        Public Property X12Enable()
            Get
                Return blnX12Enable
            End Get
            Set(ByVal Value)
                blnX12Enable = Value
            End Set
        End Property

        ' ---- X12Email Property
        Public Property X12Email()
            Get
                Return strX12Email
            End Get
            Set(ByVal Value)
                strX12Email = Value
            End Set
        End Property

        ' ---- DeliveryTime Property
        Public Property DeliveryTime()
            Get
                Return intDeliveryTime
            End Get
            Set(ByVal Value)
                intDeliveryTime = Value
            End Set
        End Property

        ' ---- ClaimCycle1 Property
        Public Property ClaimCycle1()
            Get
                Return intClaimCycle1
            End Get
            Set(ByVal Value)
                intClaimCycle1 = Value
            End Set
        End Property

        ' ---- ClaimCycle2 Property
        Public Property ClaimCycle2()
            Get
                Return intClaimCycle2
            End Get
            Set(ByVal Value)
                intClaimCycle2 = Value
            End Set
        End Property

        ' ---- ClaimCycle3 Property
        Public Property ClaimCycle3()
            Get
                Return intClaimCycle3
            End Get
            Set(ByVal Value)
                intClaimCycle3 = Value
            End Set
        End Property

        ' ---- ClaimEmail Property
        Public Property ClaimEmail()
            Get
                Return strClaimEmail
            End Get
            Set(ByVal Value)
                strClaimEmail = Value
            End Set
        End Property

        ' ---- LibAC Property
        Public Property LibAC()
            Get
                Return strLibAC
            End Get
            Set(ByVal Value)
                strLibAC = Value
            End Set
        End Property

        ' ---- BankingInfo Property
        Public Property BankingInfo()
            Get
                Return strBankingInfo
            End Get
            Set(ByVal Value)
                strBankingInfo = Value
            End Set
        End Property

        ' ---- Note Property
        Public Property Note()
            Get
                Return strNote
            End Get
            Set(ByVal Value)
                strNote = Value
            End Set
        End Property
        ' VendorID property
        Public Property VendorID() As Integer
            Get
                Return (intVendorID)
            End Get
            Set(ByVal Value As Integer)
                intVendorID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Purpose: Create new vendor
        ' Input: some infor
        ' Output: intRetVal
        ' Creator: Sondp
        Public Function Create() As Integer
            Dim intRetval As Integer = 0 ' Integer Return value 
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_VENDOR_INS"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strName", OracleType.VarChar, 50)).Value = strName
                            .Add(New OracleParameter("strAddress", OracleType.VarChar, 150)).Value = strAddress
                            .Add(New OracleParameter("intProvinceID", OracleType.Number, 4)).Value = intProvinceID
                            .Add(New OracleParameter("intCountryID", OracleType.Number, 4)).Value = intCountryID
                            .Add(New OracleParameter("strZip", OracleType.VarChar, 12)).Value = strZip
                            .Add(New OracleParameter("strContactPerson", OracleType.VarChar, 50)).Value = strContactPerson
                            .Add(New OracleParameter("strTel", OracleType.VarChar, 15)).Value = strTel
                            .Add(New OracleParameter("strFax", OracleType.VarChar, 15)).Value = strFax
                            .Add(New OracleParameter("strEmail", OracleType.VarChar, 50)).Value = strEmail
                            .Add(New OracleParameter("strSAN", OracleType.VarChar, 10)).Value = strSAN
                            .Add(New OracleParameter("strLibSAN", OracleType.VarChar, 32)).Value = strLibSAN
                            .Add(New OracleParameter("intClaimCycle1", OracleType.Number, 4)).Value = intClaimCycle1
                            .Add(New OracleParameter("intClaimCycle2", OracleType.Number, 4)).Value = intClaimCycle2
                            .Add(New OracleParameter("intClaimCycle3", OracleType.Number, 4)).Value = intClaimCycle3
                            .Add(New OracleParameter("strClaimEmail", OracleType.VarChar, 40)).Value = strClaimEmail
                            .Add(New OracleParameter("intDeliveryTime", OracleType.Number, 4)).Value = intDeliveryTime
                            .Add(New OracleParameter("blnX12Enable", OracleType.Byte, 4)).Value = blnX12Enable
                            .Add(New OracleParameter("strX12Email", OracleType.VarChar, 40)).Value = strX12Email
                            .Add(New OracleParameter("strLibAC", OracleType.VarChar, 16)).Value = strLibAC
                            .Add(New OracleParameter("strBankingInfo", OracleType.VarChar, 150)).Value = strBankingInfo
                            .Add(New OracleParameter("strNote", OracleType.VarChar, 320)).Value = strNote
                            .Add(New OracleParameter("intRetVal", OracleType.Number)).Direction = ParameterDirection.Output
                        End With
                        Try
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
                        .CommandText = "Acq_spVendor_Ins"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 50)).Value = strName
                            .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar, 150)).Value = strAddress
                            .Add(New SqlParameter("@intProvinceID", SqlDbType.Int, 4)).Value = intProvinceID
                            .Add(New SqlParameter("@intCountryID", SqlDbType.Int, 4)).Value = intCountryID
                            .Add(New SqlParameter("@strZip", SqlDbType.VarChar, 12)).Value = strZip
                            .Add(New SqlParameter("@strContactPerson", SqlDbType.NVarChar, 50)).Value = strContactPerson
                            .Add(New SqlParameter("@strTel", SqlDbType.VarChar, 15)).Value = strTel
                            .Add(New SqlParameter("@strFax", SqlDbType.VarChar, 15)).Value = strFax
                            .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 50)).Value = strEmail
                            .Add(New SqlParameter("@strSAN", SqlDbType.VarChar, 10)).Value = strSAN
                            .Add(New SqlParameter("@strLibSAN", SqlDbType.VarChar, 32)).Value = strLibSAN
                            .Add(New SqlParameter("@intClaimCycle1", SqlDbType.Int, 4)).Value = intClaimCycle1
                            .Add(New SqlParameter("@intClaimCycle2", SqlDbType.Int, 4)).Value = intClaimCycle2
                            .Add(New SqlParameter("@intClaimCycle3", SqlDbType.Int, 4)).Value = intClaimCycle3
                            .Add(New SqlParameter("@strClaimEmail", SqlDbType.VarChar, 40)).Value = strClaimEmail
                            .Add(New SqlParameter("@blnX12Enable", SqlDbType.Bit)).Value = blnX12Enable
                            .Add(New SqlParameter("@strX12Email", SqlDbType.VarChar, 40)).Value = strX12Email
                            .Add(New SqlParameter("@intDeliveryTime", SqlDbType.Int, 4)).Value = intDeliveryTime
                            .Add(New SqlParameter("@strLibAC", SqlDbType.VarChar, 16)).Value = strLibAC
                            .Add(New SqlParameter("@strBankingInfo", SqlDbType.NVarChar, 150)).Value = strBankingInfo
                            .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 320)).Value = strNote
                            .Add(New SqlParameter("@intRetVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = intVendorID
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Create = intRetval
        End Function

        ' Purpose: Update vendor
        ' In: some infor
        ' Output: intRetval
        ' Creator: Sondp
        Public Function Update() As Integer
            Dim intRetval As Integer = 0 ' Integer Return value 
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_VENDOR_UPD"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strName", OracleType.VarChar, 50)).Value = strName
                            .Add(New OracleParameter("strAddress", OracleType.VarChar, 150)).Value = strAddress
                            .Add(New OracleParameter("intProvinceID", OracleType.Number, 4)).Value = intProvinceID
                            .Add(New OracleParameter("intCountryID", OracleType.Number, 4)).Value = intCountryID
                            .Add(New OracleParameter("strZip", OracleType.VarChar, 12)).Value = strZip
                            .Add(New OracleParameter("intVendorID", OracleType.Number, 4)).Value = intVendorID
                            .Add(New OracleParameter("strContactPerson", OracleType.VarChar, 50)).Value = strContactPerson
                            .Add(New OracleParameter("strTel", OracleType.VarChar, 15)).Value = strTel
                            .Add(New OracleParameter("strFax", OracleType.VarChar, 15)).Value = strFax
                            .Add(New OracleParameter("strEmail", OracleType.VarChar, 50)).Value = strEmail
                            .Add(New OracleParameter("strSAN", OracleType.VarChar, 10)).Value = strSAN
                            .Add(New OracleParameter("strLibSAN", OracleType.VarChar, 32)).Value = strLibSAN
                            .Add(New OracleParameter("intClaimCycle1", OracleType.Number, 4)).Value = intClaimCycle1
                            .Add(New OracleParameter("intClaimCycle2", OracleType.Number, 4)).Value = intClaimCycle2
                            .Add(New OracleParameter("intClaimCycle3", OracleType.Number, 4)).Value = intClaimCycle3
                            .Add(New OracleParameter("strClaimEmail", OracleType.VarChar, 40)).Value = strClaimEmail
                            .Add(New OracleParameter("intDeliveryTime", OracleType.Number, 4)).Value = intDeliveryTime
                            .Add(New OracleParameter("blnX12Enable", OracleType.Byte, 4)).Value = blnX12Enable
                            .Add(New OracleParameter("strX12Email", OracleType.VarChar, 40)).Value = strX12Email
                            .Add(New OracleParameter("strLibAC", OracleType.VarChar, 16)).Value = strLibAC
                            .Add(New OracleParameter("strBankingInfo", OracleType.VarChar, 150)).Value = strBankingInfo
                            .Add(New OracleParameter("strNote", OracleType.VarChar, 320)).Value = strNote
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spVendor_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intVendorID", SqlDbType.Int, 4)).Value = intVendorID
                            .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 50)).Value = strName
                            .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar, 150)).Value = strAddress
                            .Add(New SqlParameter("@intProvinceID", SqlDbType.Int, 4)).Value = intProvinceID
                            .Add(New SqlParameter("@intCountryID", SqlDbType.Int, 4)).Value = intCountryID
                            .Add(New SqlParameter("@strZip", SqlDbType.NVarChar, 12)).Value = strZip
                            .Add(New SqlParameter("@strContactPerson", SqlDbType.NVarChar, 50)).Value = strContactPerson
                            .Add(New SqlParameter("@strTel", SqlDbType.VarChar, 15)).Value = strTel
                            .Add(New SqlParameter("@strFax", SqlDbType.VarChar, 15)).Value = strFax
                            .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 50)).Value = strEmail
                            .Add(New SqlParameter("@strSAN", SqlDbType.VarChar, 10)).Value = strSAN
                            .Add(New SqlParameter("@strLibSAN", SqlDbType.VarChar, 32)).Value = strLibSAN
                            .Add(New SqlParameter("@intClaimCycle1", SqlDbType.Int, 4)).Value = intClaimCycle1
                            .Add(New SqlParameter("@intClaimCycle2", SqlDbType.Int, 4)).Value = intClaimCycle2
                            .Add(New SqlParameter("@intClaimCycle3", SqlDbType.Int, 4)).Value = intClaimCycle3
                            .Add(New SqlParameter("@strClaimEmail", SqlDbType.VarChar, 40)).Value = strClaimEmail
                            .Add(New SqlParameter("@blnX12Enable", SqlDbType.Bit, 4)).Value = blnX12Enable
                            .Add(New SqlParameter("@strX12Email", SqlDbType.VarChar, 40)).Value = strX12Email
                            .Add(New SqlParameter("@intDeliveryTime", SqlDbType.Int, 4)).Value = intDeliveryTime
                            .Add(New SqlParameter("@strLibAC", SqlDbType.VarChar, 16)).Value = strLibAC
                            .Add(New SqlParameter("@strBankingInfo", SqlDbType.NVarChar, 150)).Value = strBankingInfo
                            .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 320)).Value = strNote
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = intVendorID
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Update = intRetval
        End Function

        ' Purpose: Delete vendor
        ' Input: intVendorID
        ' Output: intResult
        ' Creator: Sondp
        Public Function Delete() As Integer
            Dim intRetval As Integer = 0 ' Integer Return value 
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ACQUISITION.SP_ACQ_VENDOR_DEL"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intVendorID", OracleType.Number)).Value = intVendorID
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spVendor_Del"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@intVendorID", SqlDbType.Int)).Value = intVendorID
                            .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            intRetval = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message
                            intErrorCode = intVendorID
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            Delete = intRetval
        End Function

        ' Purpose: Get list of vendor
        ' Input: intVendorID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetVendor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spVendor_SelByVendorId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intVendorID", SqlDbType.Int, 4)).Value = intVendorID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetVendor = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ACQ_GET_VENDOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intVendorID", OracleType.Number, 4)).Value = intVendorID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetVendor = dsData.Tables("tblResult")
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

        ' Purpose: Get Vendor for send PO
        ' Input: intVendorID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetVendorSendPO() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spVendorSenPO_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intVendorID", SqlDbType.Int, 4)).Value = intVendorID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetVendorSendPO = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SQ_ACQ_GET_VENDOR_SENDPO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intVendorID", OracleType.Number, 4)).Value = intVendorID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetVendorSendPO = dsData.Tables("tblResult")
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

        ' Purpose: Get Province
        ' Input: 
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetProvince() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spDicProvince_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetProvince = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            dsData.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "COMMON.SP_COMMON_GET_PROVINCE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetProvince = dsData.Tables("tblResult")
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

        ' Purpose: Get po contact by vendor
        ' In: intVendorID
        ' Out: Datatable
        ' Creator: Sondp
        ' CreatedDate: 07/04/2005
        Public Function GetContract() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Acq_spPo_SelByVendorId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intVendorID", SqlDbType.Int, 4)).Value = intVendorID
                            .ExecuteNonQuery()
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetContract = dsData.Tables("tblResult")
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
                        .CommandText = "ACQUISITION.SP_ACQ_GET_CONTACTDETAIL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intVendorID", OracleType.Number, 4)).Value = intVendorID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetContract = dsData.Tables("tblResult")
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

        '  Release resource method
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