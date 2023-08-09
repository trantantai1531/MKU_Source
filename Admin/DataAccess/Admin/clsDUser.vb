Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Admin
    Public Class clsDUser
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intUID As Integer
        Private intParentID As Integer
        Private strUIDs As String
        Private strFullName As String
        Private strUserName As String
        Private strUserPass As String
        Private intCatModule As Integer
        Private intPatModule As Integer
        Private intCirModule As Integer
        Private intAcqModule As Integer
        Private intSerModule As Integer
        Private intILLModule As Integer
        Private intDelModule As Integer
        Private intAdmModule As Integer
        Private intRightID As Integer
        Private intLocationID As Integer
        Private strLDAPAdsPath As String = ""
        Private intLibID As Integer

        Private strRightList As String = ""

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' UID property
        Public Property UID() As Integer
            Get
                Return intUID
            End Get
            Set(ByVal Value As Integer)
                intUID = Value
            End Set
        End Property

        ' ParentID property
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
            End Set
        End Property

        ' UIDs property
        Public Property UIDs() As String
            Get
                Return strUIDs
            End Get
            Set(ByVal Value As String)
                strUIDs = Value
            End Set
        End Property

        ' FullName property
        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
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

        ' UserPass property
        Public Property UserPass() As String
            Get
                Return strUserPass
            End Get
            Set(ByVal Value As String)
                strUserPass = Value
            End Set
        End Property

        ' CatModule property
        Public Property CatModule() As Integer
            Get
                Return intCatModule
            End Get
            Set(ByVal Value As Integer)
                intCatModule = Value
            End Set
        End Property

        ' PatModule property
        Public Property PatModule() As Integer
            Get
                Return intPatModule
            End Get
            Set(ByVal Value As Integer)
                intPatModule = Value
            End Set
        End Property

        ' CirModule property 
        Public Property CirModule() As Integer
            Get
                Return intCirModule
            End Get
            Set(ByVal Value As Integer)
                intCirModule = Value
            End Set
        End Property

        ' AcqModule property 
        Public Property AcqModule() As Integer
            Get
                Return intAcqModule
            End Get
            Set(ByVal Value As Integer)
                intAcqModule = Value
            End Set
        End Property

        ' SerModule property 
        Public Property SerModule() As Integer
            Get
                Return intSerModule
            End Get
            Set(ByVal Value As Integer)
                intSerModule = Value
            End Set
        End Property

        ' ILLModule property 
        Public Property ILLModule() As Integer
            Get
                Return intILLModule
            End Get
            Set(ByVal Value As Integer)
                intILLModule = Value
            End Set
        End Property

        ' DELModule property 
        Public Property DelModule() As Integer
            Get
                Return intDelModule
            End Get
            Set(ByVal Value As Integer)
                intDelModule = Value
            End Set
        End Property

        ' AdmModule property 
        Public Property AdmModule() As Integer
            Get
                Return intAdmModule
            End Get
            Set(ByVal Value As Integer)
                intAdmModule = Value
            End Set
        End Property

        ' RightID property 
        Public Property RightID() As Integer
            Get
                Return intRightID
            End Get
            Set(ByVal Value As Integer)
                intRightID = Value
            End Set
        End Property

        ' LocationID property 
        Public Property LocationID() As Integer
            Get
                Return intLocationID
            End Get
            Set(ByVal Value As Integer)
                intLocationID = Value
            End Set
        End Property

        ' LDAPAdsPath property
        Public Property LDAPAdsPath() As String
            Get
                Return strLDAPAdsPath
            End Get
            Set(ByVal Value As String)
                strLDAPAdsPath = Value
            End Set
        End Property

        ' RightList property
        Public Property RightList() As String
            Get
                Return strRightList
            End Get
            Set(ByVal Value As String)
                strRightList = Value
            End Set
        End Property

        ' UID property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' AddUser method
        ' Purpose: Add new user
        ' Input: main information of new user
        ' Output: integer value (0 if success)
        Public Function AddUser(ByRef intNewUID As Integer, Optional ByVal intIsLDAP As Int16 = 0) As Integer
            Dim intOutVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Sys_spUser_AddNew"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsLdap", OracleType.Number)).Value = intIsLDAP
                            .Parameters.Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strFullName
                            .Parameters.Add(New OracleParameter("strUserName", OracleType.VarChar, 100)).Value = strUserName
                            .Parameters.Add(New OracleParameter("strPassword", OracleType.VarChar, 100)).Value = strUserPass
                            .Parameters.Add(New OracleParameter("intCatModule", OracleType.Number)).Value = intCatModule
                            .Parameters.Add(New OracleParameter("intPatModule", OracleType.Number)).Value = intPatModule
                            .Parameters.Add(New OracleParameter("intCirModule", OracleType.Number)).Value = intCirModule
                            .Parameters.Add(New OracleParameter("intAcqModule", OracleType.Number)).Value = intAcqModule
                            .Parameters.Add(New OracleParameter("intSerModule", OracleType.Number)).Value = intSerModule
                            .Parameters.Add(New OracleParameter("intILLModule", OracleType.Number)).Value = intILLModule
                            .Parameters.Add(New OracleParameter("intDelModule", OracleType.Number)).Value = intDelModule
                            .Parameters.Add(New OracleParameter("intAdmModule", OracleType.Number)).Value = intAdmModule
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                            .Parameters.Add(New OracleParameter("strLDAPAdsPath", OracleType.VarChar, 200)).Value = strLDAPAdsPath
                            .Parameters.Add(New OracleParameter("intNewUID", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intNewUID = .Parameters("intNewUID").Value
                            intOutVal = .Parameters("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_AddNew"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsLdap", SqlDbType.Int)).Value = intIsLDAP
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strFullName
                            .Parameters.Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 100)).Value = strUserName
                            .Parameters.Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strUserPass
                            .Parameters.Add(New SqlParameter("@intCatModule", SqlDbType.Int)).Value = intCatModule
                            .Parameters.Add(New SqlParameter("@intPatModule", SqlDbType.Int)).Value = intPatModule
                            .Parameters.Add(New SqlParameter("@intCirModule", SqlDbType.Int)).Value = intCirModule
                            .Parameters.Add(New SqlParameter("@intAcqModule", SqlDbType.Int)).Value = intAcqModule
                            .Parameters.Add(New SqlParameter("@intSerModule", SqlDbType.Int)).Value = intSerModule
                            .Parameters.Add(New SqlParameter("@intILLModule", SqlDbType.Int)).Value = intILLModule
                            .Parameters.Add(New SqlParameter("@intDelModule", SqlDbType.Int)).Value = intDelModule
                            .Parameters.Add(New SqlParameter("@intAdmModule", SqlDbType.Int)).Value = intAdmModule
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@strLDAPAdsPath", SqlDbType.NVarChar, 200)).Value = strLDAPAdsPath
                            .Parameters.Add(New SqlParameter("@intNewUID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intNewUID = .Parameters("@intNewUID").Value
                            intOutVal = .Parameters("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            AddUser = intOutVal
        End Function

        ' UpdateUser method
        ' Purpose: Update user infor
        ' Input: main information of the selected user
        ' Output: integer value (0 if success)
        Public Function UpdateUser(Optional ByVal intISLDAP As Int16 = 0) As Integer
            Dim intOutVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_UPDATE_USER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsLdap", OracleType.Number)).Value = intISLDAP
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strFullName
                            .Parameters.Add(New OracleParameter("strUserName", OracleType.VarChar, 100)).Value = strUserName
                            .Parameters.Add(New OracleParameter("strPassword", OracleType.VarChar, 100)).Value = strUserPass
                            .Parameters.Add(New OracleParameter("intCatModule", OracleType.Number)).Value = intCatModule
                            .Parameters.Add(New OracleParameter("intPatModule", OracleType.Number)).Value = intPatModule
                            .Parameters.Add(New OracleParameter("intCirModule", OracleType.Number)).Value = intCirModule
                            .Parameters.Add(New OracleParameter("intAcqModule", OracleType.Number)).Value = intAcqModule
                            .Parameters.Add(New OracleParameter("intSerModule", OracleType.Number)).Value = intSerModule
                            .Parameters.Add(New OracleParameter("intILLModule", OracleType.Number)).Value = intILLModule
                            .Parameters.Add(New OracleParameter("intDelModule", OracleType.Number)).Value = intDelModule
                            .Parameters.Add(New OracleParameter("intAdmModule", OracleType.Number)).Value = intAdmModule
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutVal = .Parameters("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsLdap", SqlDbType.Int)).Value = intISLDAP
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strFullName
                            .Parameters.Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 100)).Value = strUserName
                            .Parameters.Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strUserPass
                            .Parameters.Add(New SqlParameter("@intCatModule", SqlDbType.Int)).Value = intCatModule
                            .Parameters.Add(New SqlParameter("@intPatModule", SqlDbType.Int)).Value = intPatModule
                            .Parameters.Add(New SqlParameter("@intCirModule", SqlDbType.Int)).Value = intCirModule
                            .Parameters.Add(New SqlParameter("@intAcqModule", SqlDbType.Int)).Value = intAcqModule
                            .Parameters.Add(New SqlParameter("@intSerModule", SqlDbType.Int)).Value = intSerModule
                            .Parameters.Add(New SqlParameter("@intILLModule", SqlDbType.Int)).Value = intILLModule
                            .Parameters.Add(New SqlParameter("@intDelModule", SqlDbType.Int)).Value = intDelModule
                            .Parameters.Add(New SqlParameter("@intAdmModule", SqlDbType.Int)).Value = intAdmModule
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutVal = .Parameters("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            UpdateUser = intOutVal
        End Function

        ' ChangeUserPass method
        ' Purpose: Update user infor
        ' Input: main information of the selected user
        ' Output: integer value (0 if success)
        Public Function ChangeUserPass(Optional ByVal intISLDAP As Int16 = 0) As Integer
            Dim intOutVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.Sys_spUser_UpdPassword"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intIsLdap", OracleType.Number)).Value = intISLDAP
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("strName", OracleType.VarChar, 100)).Value = strFullName
                            .Parameters.Add(New OracleParameter("strUserName", OracleType.VarChar, 100)).Value = strUserName
                            .Parameters.Add(New OracleParameter("strPassword", OracleType.VarChar, 100)).Value = strUserPass
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutVal = .Parameters("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_UpdPassword"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intIsLdap", SqlDbType.Int)).Value = intISLDAP
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = strFullName
                            .Parameters.Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 100)).Value = strUserName
                            .Parameters.Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strUserPass
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutVal = .Parameters("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            ChangeUserPass = intOutVal
        End Function


        ' DeleteUser method
        ' Purpose: Delete user infor
        ' Input: UserIDs
        Public Sub DeleteUser()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_DELETE_USER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strUIDs", OracleType.VarChar, 1000)).Value = strUIDs
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
                        .CommandText = "Sys_spUser_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strUIDs", SqlDbType.VarChar, 1000)).Value = strUIDs
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

        ' GetUsers method
        ' Purpose: Get user informations
        ' Output: datatable result
        Public Function GetUsers() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GET_USERS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetUsers = dsData.Tables("tblResult")
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
                        .CommandText = "Sys_spUser_SelByUserName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetUsers = dsData.Tables("tblResult")
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

        ' SelectUserSSC method
        ' Purpose: Grant user has UserType = 1 (had set permission)
        ' Input: UserName, FullName
        Public Sub SelectUserSSC()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_SELECT_USER_SSC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strUserID", OracleType.VarChar, 1000)).Value = strUIDs
                            .Parameters.Add(New OracleParameter("strUserName", OracleType.VarChar, 1000)).Value = strUserName
                            .Parameters.Add(New OracleParameter("strFullName", OracleType.VarChar, 1000)).Value = strFullName
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spUser_SelUserSSC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strUserID", SqlDbType.VarChar, 1000)).Value = strUIDs
                            .Parameters.Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 1000)).Value = strUserName
                            .Parameters.Add(New SqlParameter("@strFullName", SqlDbType.NVarChar, 1000)).Value = strFullName
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.NVarChar, 1000)).Value = intLibID
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
        ' UnSelectUserSSC method
        ' Purpose: Unselect user infor
        ' Input: UserIDs
        Public Sub UnSelectUserSSC()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_UNSELECT_USER_SSC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strUIDs", OracleType.VarChar, 1000)).Value = strUIDs
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spUser_UnSelUserSSC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strUIDs", SqlDbType.VarChar, 1000)).Value = strUIDs
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
        ' GetPermUsers method
        ' Purpose: Get user has UserType = 1 (had set permission)
        ' Output: datatable result
        Public Function GetPermUsers() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GET_PERM_USERS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = intParentID
                            .Parameters.Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetPermUsers = dsData.Tables("tblResult")
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
                        .CommandText = "Sys_spUser_SelPerm"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = intParentID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetPermUsers = dsData.Tables("tblResult")
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

        ' GrantRights method
        ' Purpose: Grant right for the selected user
        ' Input: some infor
        Public Sub GrantRights()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GRANT_RIGHTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("intRightID", OracleType.Number)).Value = intRightID
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
                        .CommandText = "Sys_spUser_Permission_SelGrant"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@intRightID", SqlDbType.Int)).Value = intRightID
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

        ' GrantRights method
        ' Purpose: Grant right for the selected user
        ' Input: some infor
        Public Sub GrantBasicRights()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GRANT_BASIC_RIGHTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spUser_Permission_SelBasicRight"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
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

        ' GrantLocation method
        ' Purpose: Grant locations for the selected user
        ' Input: some informations
        Public Sub GrantLocation(ByVal intType As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GRANT_LOCATIONS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("intLocationID", OracleType.Number)).Value = intLocationID
                            .Parameters.Add(New OracleParameter("intLocType", OracleType.Number)).Value = intType
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
                        .CommandText = "Sys_spUser_Location_SelGrantLocation"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@intLocationID", SqlDbType.Int)).Value = intLocationID
                            .Parameters.Add(New SqlParameter("@intLocType", SqlDbType.Int)).Value = intType
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

        ' GetRoleInfor method
        ' Purpose: Get role informations
        ' Output: datatable result
        Public Function GetRoleInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GET_ROLE_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetRoleInfor = dsData.Tables("tblResult")
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
                        .CommandText = "SP_ADMIN_GET_ROLE_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetRoleInfor = dsData.Tables("tblResult")
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

        ' GetLocationInfor method
        ' Purpose: Get user locations informations
        ' Output: datatable result
        Public Sub GetLocationInfor(ByRef strCirLocs As String, ByRef strSerLocs As String, ByRef strAcqLocs As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_GET_LOCATION_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intUserID", OracleType.Number)).Value = intUID
                            .Parameters.Add(New OracleParameter("strCirLocs", OracleType.VarChar, 1000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strAcqLocs", OracleType.VarChar, 1000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strSerLocs", OracleType.VarChar, 1000)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            strCirLocs = .Parameters("strCirLocs").Value.ToString
                            strAcqLocs = .Parameters("strAcqLocs").Value.ToString
                            strSerLocs = .Parameters("strSerLocs").Value.ToString
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Sys_spUser_Location_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intUserID", SqlDbType.Int)).Value = intUID
                            .Parameters.Add(New SqlParameter("@strCirLocs", SqlDbType.VarChar, 1000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strAcqLocs", SqlDbType.VarChar, 1000)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strSerLocs", SqlDbType.VarChar, 1000)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            strCirLocs = .Parameters("@strCirLocs").Value
                            strAcqLocs = .Parameters("@strAcqLocs").Value
                            strSerLocs = .Parameters("@strSerLocs").Value
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

        ' GetUserLogin function 
        ' Purpose : check exist user when login
        ' Input: strUsername,strPassword
        ' Output: DataTable
        ' Creator: Lent (23-4-2005)
        Public Function GetUserLogin() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_SYS_USER_LOGIN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strUsername", OracleType.VarChar, 30)).Value = strUserName
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 30)).Value = strUserPass
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetUserLogin = dsData.Tables("tblResult")
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
                        .CommandText = "Sys_spUser_Login"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strUsername", SqlDbType.VarChar, 100)).Value = strUserName
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 100)).Value = strUserPass
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetUserLogin = dsData.Tables("tblResult")
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

        ' GetUserLoginNonPass function 
        ' Purpose : check exist user when login Non Password
        ' Input: strUsername
        ' Output: DataTable
        ' Creator: SonPQ
        Public Function GetUserLoginNonPass() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_SYS_USER_LOGIN_NON_PASS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strUsername", OracleType.VarChar, 30)).Value = strUserName
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetUserLoginNonPass = dsData.Tables("tblResult")
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
                        .CommandText = "Sys_spUserLoginNonPass"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strUsername", SqlDbType.VarChar, 100)).Value = strUserName
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            GetUserLoginNonPass = dsData.Tables("tblResult")
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

        Public Function GetLDAPUserLogin(ByVal strAdsPath As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_SYS_LDAP_USER_LOGIN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strUsername", OracleType.VarChar, 100)).Value = strUserName
                                .Add(New OracleParameter("strLDAPAdsPath", OracleType.VarChar, 200)).Value = strAdsPath
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetLDAPUserLogin = dsData.Tables("tblResult")
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
                        .CommandText = "Sys_spUserLDAP_Login"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strUsername", SqlDbType.VarChar, 100)).Value = strUserName
                                .Add(New SqlParameter("@strLDAPAdsPath", SqlDbType.NVarChar, 200)).Value = strAdsPath
                            End With
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetLDAPUserLogin = dsData.Tables("tblResult")
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

        Public Function GetUserCount() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .CommandText = "ADMINISTRATOR.SP_ADMIN_COUNT_USER"
                            .CommandType = CommandType.StoredProcedure
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetUserCount = dsData.Tables("tblResult")
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
                        Try
                            .CommandText = "Sys_spUser_CountUser"
                            .CommandType = CommandType.StoredProcedure
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetUserCount = dsData.Tables("tblResult")
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

        Public Function getModules(Optional ByVal ParentId As Integer = 0) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_SYS_GET_MODULE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strRightList", OracleType.VarChar)).Value = RightList
                                .Add(New OracleParameter("intParentId", OracleType.Number)).Value = ParentId
                                .Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            End With
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getModules = dsData.Tables("tblResult")
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
                        .CommandText = "Sys_spModule_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strRightList", SqlDbType.VarChar)).Value = RightList
                                .Add(New SqlParameter("@intParentId", SqlDbType.Int)).Value = ParentId
                            End With
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getModules = dsData.Tables("tblResult")
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

        Public Function UpdateUserSSO(ByVal UserName As String, ByVal FullName As String, ByVal Active As String, ByVal SSCID As String) As Integer
            Dim intOutVal As Integer = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "ADMINISTRATOR.SP_ADMIN_UPDATE_USER_SSO"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strName", OracleType.NVarChar, 100)).Value = FullName
                            .Parameters.Add(New OracleParameter("strUserName", OracleType.VarChar, 100)).Value = UserName
                            .Parameters.Add(New OracleParameter("strSSCID", OracleType.VarChar, 100)).Value = SSCID
                            .Parameters.Add(New OracleParameter("strActive", OracleType.VarChar, 100)).Value = Active
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutVal = .Parameters("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Sys_spUser_UpdUerSSC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = FullName
                            .Parameters.Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 100)).Value = UserName
                            .Parameters.Add(New SqlParameter("@strSSCID", SqlDbType.VarChar, 100)).Value = SSCID
                            .Parameters.Add(New SqlParameter("@strActive", SqlDbType.VarChar, 100)).Value = Active
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            intOutVal = .Parameters("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
            UpdateUserSSO = intOutVal
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