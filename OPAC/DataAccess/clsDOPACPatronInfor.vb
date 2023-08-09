Imports System
Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACPatronInfor
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private strCardNo As String
        Private strFirstName As String
        Private strLastName As String
        Private strMiddleName As String
        Private strEducationLevel As String
        Private strAddress As String
        Private strPassword As String
        Private strTel As String
        Private strMobile As String
        Private strEmail As String
        Private intOccupationID As Integer
        Private intEducationID As Integer
        Private strDOB As String
        Private strValidDate As String
        Private strWorkPlace As String
        Private strIsCanBo As String


        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        'Facebook Property
        Public Property Facebook() As String

        ' Education property
        Public Property EducationID() As Integer
            Get
                Return (intEducationID)
            End Get
            Set(ByVal Value As Integer)
                intEducationID = Value
            End Set
        End Property
        ' CardNo Property
        Public Property CardNo() As String
            Get
                Return strCardNo
            End Get
            Set(ByVal Value As String)
                strCardNo = Value
            End Set
        End Property

        ' FirstName property
        Public Property FirstName() As String
            Get
                Return strFirstName
            End Get
            Set(ByVal Value As String)
                strFirstName = Value
            End Set
        End Property

        ' LastName property
        Public Property LastName() As String
            Get
                Return strLastName
            End Get
            Set(ByVal Value As String)
                strLastName = Value
            End Set
        End Property
        ' MiddleName property
        Public Property MiddleName() As String
            Get
                Return strMiddleName
            End Get
            Set(ByVal Value As String)
                strMiddleName = Value
            End Set
        End Property

        ' EducationLevel property
        Public Property EducationLevel() As String
            Get
                Return strEducationLevel
            End Get
            Set(ByVal Value As String)
                strEducationLevel = Value
            End Set
        End Property

        ' Address property
        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal Value As String)
                strAddress = Value
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

        ' Tel Property
        Public Property Tel() As String
            Get
                Return strTel
            End Get
            Set(ByVal Value As String)
                strTel = Value
            End Set
        End Property

        ' Mobile property
        Public Property Mobile() As String
            Get
                Return strMobile
            End Get
            Set(ByVal Value As String)
                strMobile = Value
            End Set
        End Property

        ' Email property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property
        ' WorkPlace property
        Public Property WorkPlace() As String
            Get
                Return strWorkPlace
            End Get
            Set(ByVal Value As String)
                strWorkPlace = Value
            End Set
        End Property
        ' IsCanBo property
        Public Property IsCanBo() As String
            Get
                Return strIsCanBo
            End Get
            Set(ByVal Value As String)
                strIsCanBo = Value
            End Set
        End Property
        ' OccupationID Property
        Public Property OccupationID() As Integer
            Get
                Return intOccupationID
            End Get
            Set(ByVal Value As Integer)
                intOccupationID = Value
            End Set
        End Property

        ' DOB property
        Public Property DOB() As String
            Get
                Return strDOB
            End Get
            Set(ByVal Value As String)
                strDOB = Value
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

        Public Function GetPasswordForgot() As DataTable
            OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cir_spPatron_SelByCode"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 100)).Value = strCardNo
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblPatron")
                            GetPasswordForgot = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Cir_spPatron_SelByCode"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 100)).Value = strCardNo
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblPatron")
                            GetPasswordForgot = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            CloseConnection()
        End Function

        Public Function GetPatronByEmail() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spPatronCard_Email"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 100)).Value = strEmail
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblPatron")
                            GetPatronByEmail = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetPatron() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spPatronCard_Check"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 100)).Value = strCardNo
                            .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strPassword
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblPatron")
                            GetPatron = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spPatronCard_Check"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 100)).Value = strCardNo
                            .Add(New OracleParameter("strPassword", OracleType.VarChar, 100)).Value = strPassword
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblPatron")
                            GetPatron = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
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
        Public Function GetPatronNoPassword() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spPatronCard_NoPassword"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 100)).Value = strCardNo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblPatron")
                            GetPatronNoPassword = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetPatronNoPasswordGTVT() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spPatronCard_NoPassword_GTVT"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 100)).Value = strCardNo
                            .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 100)).Value = strEmail
                            .Add(New SqlParameter("@strFirstName", SqlDbType.NVarChar, 100)).Value = strFirstName
                            .Add(New SqlParameter("@strMiddleName", SqlDbType.NVarChar, 100)).Value = strMiddleName
                            .Add(New SqlParameter("@strLastName", SqlDbType.NVarChar, 100)).Value = strLastName
                            .Add(New SqlParameter("@strIsCanBo", SqlDbType.VarChar, 100)).Value = strIsCanBo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblPatron")
                            GetPatronNoPasswordGTVT = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"

            End Select
            Me.CloseConnection()
        End Function

        Public Function GetPatronInfo() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spGetPatronInfo"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 100)).Value = strCardNo
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblPatron")
                            GetPatronInfo = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                            GetPatronInfo = Nothing
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case Else
                    GetPatronInfo = Nothing
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetPatronSSC() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spPatronCardSSC_Check"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 100)).Value = strCardNo
                            .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strPassword
                        End With
                        Try
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblPatron")
                            GetPatronSSC = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spPatronCardSSC_Check"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 100)).Value = strCardNo
                            .Add(New OracleParameter("strPassword", OracleType.VarChar, 100)).Value = strPassword
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblPatron")
                            GetPatronSSC = dsData.Tables("tblPatron")
                            dsData.Tables.Remove("tblPatron")
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

        Public Function ActiveAccount() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spActiveAccount_Get"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 100)).Value = strCardNo
                            .Add(New SqlParameter("@strValidDate", SqlDbType.VarChar, 20)).Value = strValidDate
                            .Add(New SqlParameter("@strDOB", SqlDbType.VarChar, 20)).Value = strDOB
                            .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strPassword
                        End With
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblPatronInfor")
                            ActiveAccount = dsData.Tables("tblPatronInfor")
                            dsData.Tables.Remove("tblPatronInfor")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spActiveAccount_Get"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 100)).Value = strCardNo
                            .Add(New OracleParameter("strValidDate", OracleType.VarChar, 20)).Value = strValidDate
                            .Add(New OracleParameter("strDOB", OracleType.VarChar, 20)).Value = strDOB
                            .Add(New OracleParameter("strPassword", OracleType.VarChar, 100)).Value = strPassword
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblPatronInfor")
                            ActiveAccount = dsData.Tables("tblPatronInfor")
                            dsData.Tables.Remove("tblPatronInfor")
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

        Public Function GetOccupation() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spOccupation_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetOccupation = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            dsdata.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spOccupation_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetOccupation = dsData.Tables("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            dsData.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetEducation() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spEducation_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetEducation = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            dsdata.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "OPAC.Opac_spEducation_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetEducation = dsData.Tables("tblResult")
                        Catch ex As OracleException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Code
                        Finally
                            dsData.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetPatronGroup(ByVal intLibID As Integer) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cir_spPatGetPatronGroup"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPatronGroup = dsData.Tables("tblResult")
                        Catch ex As SqlException
                            strErrorMsg = ex.Message.ToString
                            intErrorCode = ex.Number
                        Finally
                            dsData.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function UpdatePatron() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    Dim dtDOB As DateTime = Nothing
                    If DOB <> "" Then

                        Try
                            dtDOB = System.DateTime.Parse(DOB)
                        Catch ex As Exception
                            dtDOB = Nothing
                        End Try
                    End If
                    With SqlCommand
                        .CommandText = "Opac_spPatron_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                                .Add(New SqlParameter("@intEducationID", SqlDbType.Int)).Value = intEducationID
                                .Add(New SqlParameter("@intOccupationID", SqlDbType.Int)).Value = intOccupationID
                                .Add(New SqlParameter("@strWorkPlace", SqlDbType.NVarChar, 300)).Value = strWorkPlace
                                .Add(New SqlParameter("@strAddress", SqlDbType.NVarChar, 300)).Value = strAddress
                                .Add(New SqlParameter("@strTelephone", SqlDbType.VarChar, 20)).Value = strTel
                                .Add(New SqlParameter("@strMobile", SqlDbType.VarChar, 20)).Value = strMobile
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strPassword
                                .Add(New SqlParameter("@strEmail", SqlDbType.VarChar, 100)).Value = strEmail
                                .Add(New SqlParameter("@strFacebook", SqlDbType.NVarChar, 250)).Value = Facebook
                                .Add(New SqlParameter("@dtDOB", SqlDbType.DateTime)).Value = dtDOB
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spPatron_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                                .Add(New OracleParameter("intEducationID", OracleType.Number, 4)).Value = intEducationID
                                .Add(New OracleParameter("intOccupationID", OracleType.Number, 4)).Value = intOccupationID
                                .Add(New OracleParameter("strWorkPlace", OracleType.NVarChar, 255)).Value = strWorkPlace
                                .Add(New OracleParameter("strAddress", OracleType.NVarChar, 255)).Value = strAddress
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 20)).Value = strTel
                                .Add(New OracleParameter("strMobile", OracleType.VarChar, 20)).Value = strMobile
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 255)).Value = strPassword
                                .Add(New OracleParameter("strEmail", OracleType.VarChar, 255)).Value = strEmail
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
            UpdatePatron = intRetval
        End Function
        Public Function UpdatePasswordPatron() As Integer
            Dim intRetval As Integer = 0
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Opac_spPatronUpdPassword"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 20)).Value = strCardNo
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 30)).Value = strPassword
                            End With
                            .ExecuteNonQuery()
                            intRetval = 1
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
            UpdatePasswordPatron = intRetval
        End Function
        Public Function GetHolding() As DataTable
            Call OpenConnection()
                With SqlCommand
                        .CommandText = "Cir_spLoanHistory_SelLoanInfor"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 50)).Value = strCardNo
                        .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 30)).Value = ""
                        .Parameters.Add(New SqlParameter("@strCopyNumber", SqlDbType.VarChar, 30)).Value = ""
                        .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = 0
                        .Parameters.Add(New SqlParameter("@strCheckOutDateFrom", SqlDbType.VarChar, 30)).Value = ""
                        .Parameters.Add(New SqlParameter("@strCheckOutDateTo", SqlDbType.VarChar, 30)).Value = ""
                        .Parameters.Add(New SqlParameter("@strCheckInDateFrom", SqlDbType.VarChar, 30)).Value = ""
                        .Parameters.Add(New SqlParameter("@strCheckInDateTo", SqlDbType.VarChar, 30)).Value = ""
                        .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = 1
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetHolding = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
               Call CloseConnection()
        End Function
        Public Function GetOnHolding() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spOnHolding_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetOnHolding = dsdata.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spOnHolding_Get"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            .ExecuteNonQuery()
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetOnHolding = dsdata.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            dsdata.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetILLRequest() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spIllRequest_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetILLRequest = dsdata.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spIllRequest_Get"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetILLRequest = dsdata.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            dsdata.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetInterestItem(ByVal strfield As String, ByVal strNumber As String, ByVal strNow As String) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spInterestItem_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strfield", SqlDbType.VarChar, 3)).Value = strfield
                                .Add(New SqlParameter("@strNumber", SqlDbType.NVarChar, 2000)).Value = strNumber
                                .Add(New SqlParameter("@strNow", SqlDbType.VarChar, 20)).Value = strNow
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetInterestItem = dsdata.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spInterestItem_Get"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strfield", OracleType.VarChar, 3)).Value = strfield
                            .Add(New OracleParameter("strNumber", OracleType.NVarChar, 2000)).Value = strNumber
                            .Add(New OracleParameter("strNow", OracleType.VarChar, 20)).Value = strNow
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetInterestItem = dsdata.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            dsdata.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetReservation() As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spReservation_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetReservation = dsdata.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spReservation_Get"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetReservation = dsdata.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            dsdata.Tables.Remove("tblResult")
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Sub DeleteReservation(ByVal intCirID As Integer)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spReservation_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                                .Add(New SqlParameter("@intCirID", SqlDbType.Int)).Value = intCirID
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spReservation_Del"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                            .Add(New OracleParameter("intCirID", OracleType.Number)).Value = intCirID
                        End With
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
            Me.CloseConnection()
        End Sub

        Public Function GetPatronInterestedSubject(ByVal strfield As String) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spIntestedSubject_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strfield", SqlDbType.VarChar, 3)).Value = strfield
                                .Add(New SqlParameter("@strCardNo", SqlDbType.VarChar, 50)).Value = strCardNo
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 250)).Value = strPassword
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetPatronInterestedSubject = dsdata.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spIntestedSubject_Get"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("strfield", OracleType.VarChar, 3)).Value = strfield
                            .Add(New OracleParameter("strCardNo", OracleType.VarChar, 50)).Value = strCardNo
                            .Add(New OracleParameter("strPassword", OracleType.VarChar, 250)).Value = strPassword
                            .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                        End With
                        Try
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetPatronInterestedSubject = dsdata.Tables("tblResults")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Function GetIndexNumber(ByVal strfield As String, ByVal strIDs As String) As DataTable
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spIndexSubject_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strfield", SqlDbType.VarChar, 3)).Value = strfield
                                .Add(New SqlParameter("@strIDs", SqlDbType.NVarChar, 2000)).Value = strIDs
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsdata, "tblResult")
                            GetIndexNumber = dsdata.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spIndexSubject_Get"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strfield", OracleType.VarChar, 3)).Value = strfield
                                .Add(New OracleParameter("strIDs", OracleType.NVarChar, 2000)).Value = strIDs
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsdata, "tblResult")
                            GetIndexNumber = dsdata.Tables("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                            dsdata.Tables.Remove("tblResult")
                        End Try
                    End With
            End Select
            Me.CloseConnection()
        End Function

        Public Sub UpdateInterestedSubject(ByVal intPatronID As Integer, ByVal strInterestedSubjectField As String, ByVal strInterestedSubjectValue As String)
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spInterestSubject_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intPatronID", SqlDbType.Int)).Value = intPatronID
                                .Add(New SqlParameter("@strInterestedSubjectField", SqlDbType.VarChar, 3)).Value = strInterestedSubjectField
                                .Add(New SqlParameter("@strInterestedSubjectValue", SqlDbType.VarChar, 2000)).Value = strInterestedSubjectValue
                            End With
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spInterestSubject_Upd"
                        .CommandType = CommandType.StoredProcedure
                        With .Parameters
                            .Add(New OracleParameter("intPatronID", OracleType.Number, 4)).Value = intPatronID
                            .Add(New OracleParameter("strInterestedSubjectField", OracleType.VarChar, 3)).Value = strInterestedSubjectField
                            .Add(New OracleParameter("strInterestedSubjectValue", OracleType.VarChar, 2000)).Value = strInterestedSubjectValue
                        End With
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
            Me.CloseConnection()
        End Sub


        Public Function GetIsDownLoad_ByPatronCode() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    GetIsDownLoad_ByPatronCode = -1
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_tblPatronDownLoadFile_GetIsDownLoad_ByPatronCode"
                        .CommandType = CommandType.StoredProcedure
                        .Parameters.Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strCardNo
                        .Parameters.Add(New SqlParameter("@intResult", SqlDbType.Int)).Direction = ParameterDirection.Output
                        Try
                            .ExecuteNonQuery()
                            GetIsDownLoad_ByPatronCode = .Parameters("@intResult").Value
                        Catch ex As SqlException
                            GetIsDownLoad_ByPatronCode = -1
                            intErrorCode = ex.Number
                            strErrorMsg = ex.Message.ToString
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