Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Edeliv
    Public Class clsDECustomer
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strUserName As String
        Private strName As String
        Private strDelivName As String
        Private strDelivXAddr As String
        Private strDelivStreet As String
        Private strDelivBox As String
        Private strDelivCity As String
        Private strDelivRegion As String
        Private intDelivCountryID As Integer
        Private strDelivCode As String
        Private strTelephone As String
        Private strEmailAddress As String
        Private strNote As String
        Private strPassword As String
        Private dblDebt As Double
        Private intApproved As Integer
        Private strFax As String
        Private strContactPerson As String
        Private intCustomerID As Integer
        Private intSecretLevel As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        'SecretLevel Property
        Public Property SecretLevel() As Integer
            Get
                Return intSecretLevel
            End Get
            Set(ByVal Value As Integer)
                intSecretLevel = Value
            End Set
        End Property

        ' UserName property
        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal Value As String)
                strUserName = Value
            End Set
        End Property

        ' Name property
        Public Property Name() As String
            Get
                Return strName
            End Get
            Set(ByVal Value As String)
                strName = Value
            End Set
        End Property

        ' DelivName property
        Public Property DelivName() As String
            Get
                Return strDelivName
            End Get
            Set(ByVal Value As String)
                strDelivName = Value
            End Set
        End Property

        ' DelivXAddr property
        Public Property DelivXAddr() As String
            Get
                Return strDelivXAddr
            End Get
            Set(ByVal Value As String)
                strDelivXAddr = Value
            End Set
        End Property

        ' DelivStreet property
        Public Property DelivStreet() As String
            Get
                Return strDelivStreet
            End Get
            Set(ByVal Value As String)
                strDelivStreet = Value
            End Set
        End Property

        ' DelivBox property
        Public Property DelivBox() As String
            Get
                Return strDelivBox
            End Get
            Set(ByVal Value As String)
                strDelivBox = Value
            End Set
        End Property

        ' DelivCity property
        Public Property DelivCity() As String
            Get
                Return strDelivCity
            End Get
            Set(ByVal Value As String)
                strDelivCity = Value
            End Set
        End Property

        ' DelivRegion property
        Public Property DelivRegion() As String
            Get
                Return strDelivRegion
            End Get
            Set(ByVal Value As String)
                strDelivRegion = Value
            End Set
        End Property

        ' DelivCountryID property
        Public Property DelivCountryID() As Integer
            Get
                Return intDelivCountryID
            End Get
            Set(ByVal Value As Integer)
                intDelivCountryID = Value
            End Set
        End Property

        ' DelivCode property
        Public Property DelivCode() As String
            Get
                Return strDelivCode
            End Get
            Set(ByVal Value As String)
                strDelivCode = Value
            End Set
        End Property

        ' Telephone property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                strTelephone = Value
            End Set
        End Property

        ' EmailAddress property
        Public Property EmailAddress() As String
            Get
                Return strEmailAddress
            End Get
            Set(ByVal Value As String)
                strEmailAddress = Value
            End Set
        End Property

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
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

        ' Debt property
        Public Property Debt() As Double
            Get
                Return dblDebt
            End Get
            Set(ByVal Value As Double)
                dblDebt = Value
            End Set
        End Property

        ' Approved property
        Public Property Approved() As Integer
            Get
                Return intApproved
            End Get
            Set(ByVal Value As Integer)
                intApproved = Value
            End Set
        End Property

        ' Fax property
        Public Property Fax() As String
            Get
                Return strFax
            End Get
            Set(ByVal Value As String)
                strFax = Value
            End Set
        End Property

        ' ContactPerson property
        Public Property ContactPerson() As String
            Get
                Return strContactPerson
            End Get
            Set(ByVal Value As String)
                strContactPerson = Value
            End Set
        End Property

        ' CustomerID property
        Public Property CustomerID() As Integer
            Get
                Return intCustomerID
            End Get
            Set(ByVal Value As Integer)
                intCustomerID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Create method
        ' Purpose: create new customer record
        ' Input: main infor of customer infor
        ' Output: int value (0 when success)
        Public Function Create() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Edl_spUser_Ins"
                        .CommandType = CommandType.StoredProcedure

                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strUserName", SqlDbType.NVarChar, 16)).Value = strUserName
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strName
                                .Add(New SqlParameter("@strDelivName", SqlDbType.NVarChar, 100)).Value = strDelivName
                                .Add(New SqlParameter("@strDelivXAddr", SqlDbType.NVarChar, 100)).Value = strDelivXAddr
                                .Add(New SqlParameter("@strDelivStreet", SqlDbType.NVarChar, 50)).Value = strDelivStreet
                                .Add(New SqlParameter("@strDelivBox", SqlDbType.NVarChar, 50)).Value = strDelivBox
                                .Add(New SqlParameter("@strDelivCity", SqlDbType.NVarChar, 50)).Value = strDelivCity
                                .Add(New SqlParameter("@strDelivRegion", SqlDbType.NVarChar, 30)).Value = strDelivRegion
                                .Add(New SqlParameter("@intDelivCountry", SqlDbType.TinyInt)).Value = intDelivCountryID
                                .Add(New SqlParameter("@strDelivCode", SqlDbType.VarChar, 10)).Value = strDelivCode
                                .Add(New SqlParameter("@strTelephone", SqlDbType.VarChar, 14)).Value = strTelephone
                                .Add(New SqlParameter("@strEmailAddress", SqlDbType.VarChar, 50)).Value = strEmailAddress
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 20)).Value = strPassword
                                .Add(New SqlParameter("@strFax", SqlDbType.VarChar, 20)).Value = strFax
                                .Add(New SqlParameter("@strContactPerson", SqlDbType.NVarChar, 50)).Value = strContactPerson
                                .Add(New SqlParameter("@intApproved", SqlDbType.TinyInt)).Value = intApproved
                                .Add(New SqlParameter("@intSecretLevel", SqlDbType.Int)).Value = intSecretLevel
                                .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("@intOutPut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_CREATE_EDELIV_ACCOUNT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strUserName", OracleType.VarChar, 16)).Value = strUserName
                                .Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strName
                                .Add(New OracleParameter("strDelivName", OracleType.VarChar, 100)).Value = strDelivName
                                .Add(New OracleParameter("strDelivXAddr", OracleType.VarChar, 100)).Value = strDelivXAddr
                                .Add(New OracleParameter("strDelivStreet", OracleType.VarChar, 50)).Value = strDelivStreet
                                .Add(New OracleParameter("strDelivBox", OracleType.VarChar, 50)).Value = strDelivBox
                                .Add(New OracleParameter("strDelivCity", OracleType.VarChar, 50)).Value = strDelivCity
                                .Add(New OracleParameter("strDelivRegion", OracleType.VarChar, 30)).Value = strDelivRegion
                                .Add(New OracleParameter("intDelivCountry", OracleType.Number)).Value = intDelivCountryID
                                .Add(New OracleParameter("strDelivCode", OracleType.VarChar, 10)).Value = strDelivCode
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 14)).Value = strTelephone
                                .Add(New OracleParameter("strEmailAddress", OracleType.VarChar, 50)).Value = strEmailAddress
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 50)).Value = strNote
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 20)).Value = strPassword
                                .Add(New OracleParameter("strFax", OracleType.VarChar, 20)).Value = strFax
                                .Add(New OracleParameter("strContactPerson", OracleType.VarChar, 50)).Value = strContactPerson
                                .Add(New OracleParameter("intApproved", OracleType.Number)).Value = intApproved
                                .Add(New OracleParameter("intSecretLevel", OracleType.Number)).Value = intSecretLevel
                                .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Create = .Parameters("intOutPut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With

            End Select
            Call CloseConnection()
        End Function

        ' Update method
        ' Purpose: update information of the selected customer record
        ' Input: main infor of customer infor
        ' Output: int value (0 when success)
        Public Function Update() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Edl_spCustomer_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intCustomerID
                                .Add(New SqlParameter("@strUserName", SqlDbType.NVarChar, 16)).Value = strUserName
                                .Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strName
                                .Add(New SqlParameter("@strDelivName", SqlDbType.NVarChar, 100)).Value = strDelivName
                                .Add(New SqlParameter("@strDelivXAddr", SqlDbType.NVarChar, 100)).Value = strDelivXAddr
                                .Add(New SqlParameter("@strDelivStreet", SqlDbType.NVarChar, 50)).Value = strDelivStreet
                                .Add(New SqlParameter("@strDelivBox", SqlDbType.NVarChar, 50)).Value = strDelivBox
                                .Add(New SqlParameter("@strDelivCity", SqlDbType.NVarChar, 50)).Value = strDelivCity
                                .Add(New SqlParameter("@strDelivRegion", SqlDbType.NVarChar, 30)).Value = strDelivRegion
                                .Add(New SqlParameter("@intDelivCountry", SqlDbType.TinyInt)).Value = intDelivCountryID
                                .Add(New SqlParameter("@strDelivCode", SqlDbType.VarChar, 10)).Value = strDelivCode
                                .Add(New SqlParameter("@strTelephone", SqlDbType.VarChar, 14)).Value = strTelephone
                                .Add(New SqlParameter("@strEmailAddress", SqlDbType.VarChar, 50)).Value = strEmailAddress
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 20)).Value = strPassword
                                .Add(New SqlParameter("@strFax", SqlDbType.VarChar, 20)).Value = strFax
                                .Add(New SqlParameter("@strContactPerson", SqlDbType.NVarChar, 50)).Value = strContactPerson
                                .Add(New SqlParameter("@intApproved", SqlDbType.TinyInt)).Value = intApproved
                                .Add(New SqlParameter("@intSecretLevel", SqlDbType.Int)).Value = intSecretLevel
                                .Add(New SqlParameter("@intOutPut", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("@intOutPut").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_UPDATE_EDELIV_CUSTOMER  "
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intCustomerID
                                .Add(New OracleParameter("strUserName", OracleType.VarChar, 16)).Value = strUserName
                                .Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strName
                                .Add(New OracleParameter("strDelivName", OracleType.VarChar, 100)).Value = strDelivName
                                .Add(New OracleParameter("strDelivXAddr", OracleType.VarChar, 100)).Value = strDelivXAddr
                                .Add(New OracleParameter("strDelivStreet", OracleType.VarChar, 50)).Value = strDelivStreet
                                .Add(New OracleParameter("strDelivBox", OracleType.VarChar, 50)).Value = strDelivBox
                                .Add(New OracleParameter("strDelivCity", OracleType.VarChar, 50)).Value = strDelivCity
                                .Add(New OracleParameter("strDelivRegion", OracleType.VarChar, 30)).Value = strDelivRegion
                                .Add(New OracleParameter("intDelivCountry", OracleType.Number)).Value = intDelivCountryID
                                .Add(New OracleParameter("strDelivCode", OracleType.VarChar, 10)).Value = strDelivCode
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 14)).Value = strTelephone
                                .Add(New OracleParameter("strEmailAddress", OracleType.VarChar, 50)).Value = strEmailAddress
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 50)).Value = strNote
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 20)).Value = strPassword
                                .Add(New OracleParameter("strFax", OracleType.VarChar, 20)).Value = strFax
                                .Add(New OracleParameter("strContactPerson", OracleType.VarChar, 50)).Value = strContactPerson
                                .Add(New OracleParameter("intApproved", OracleType.Number)).Value = intApproved
                                .Add(New OracleParameter("intSecretLevel", OracleType.Number)).Value = intSecretLevel
                                .Add(New OracleParameter("intOutPut", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            Update = .Parameters("intOutPut").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With

            End Select
            Call CloseConnection()
        End Function

        ' Delete method
        ' Purpose: delete the selected customer record
        ' Input: CustomerID
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Edl_spUser_DelExitAccount"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intCustomerID
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_DELETE_EDELIV_CUSTOMER"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intCustomerID
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' GetCustomerInfor method
        ' Purpose: Get information of the selected customer (also of all sys customers)
        ' Input: main infor of customer infor
        ' Output: datatable result
        Public Function GetCustomerInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_CUSTOMER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intUserID", OracleType.Number)).Value = intCustomerID
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCustomerInfor = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spUser_SelByUserId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intCustomerID
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCustomerInfor = dsData.Tables("tblResult")
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

        ' GetCustomerInforByCode method
        ' Purpose: Get information of the selected customer
        ' Input: main infor of customer infor
        ' Output: datatable result
        Public Function GetCustomerInforByCode(ByVal strCustomerCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_EDELIV_CUSTOMER_BY_CODE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCustomerCode", OracleType.VarChar, 20)).Value = strCustomerCode
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCustomerInforByCode = dsData.Tables("tblResult")
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
                        .CommandText = "Edl_spUser_SelByUserName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCustomerCode", SqlDbType.VarChar, 20)).Value = strCustomerCode
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCustomerInforByCode = dsData.Tables("tblResult")
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