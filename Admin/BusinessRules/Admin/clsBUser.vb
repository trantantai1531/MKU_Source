Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Admin

Namespace eMicLibAdmin.BusinessRules.Admin
    Public Class clsBUser
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private intUID As Integer = 0
        Private intParentID As Integer = 0
        Private strUIDs As String = ""
        Private strFullName As String = ""
        Private strUserName As String = ""
        Private strUserPass As String = ""
        Private intCatModule As Integer = 0
        Private intPatModule As Integer = 0
        Private intCirModule As Integer = 0
        Private intAcqModule As Integer = 0
        Private intSerModule As Integer = 0
        Private intILLModule As Integer = 0
        Private intDelModule As Integer = 0
        Private intAdmModule As Integer = 0
        Private intRightID As Integer = 0
        Private intLocationID As Integer = 0
        Private strLDAPAdsPath As String = ""
        Private intLibID As Integer = 0
        Private strRightList As String = ""

        Dim objDUser As New clsDUser
        Dim objBCDBS As New clsBCommonDBSystem
        Dim objBCSP As New clsBCommonStringProc

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

        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Sub Initialize()
            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objDUser object
            objDUser.DBServer = strDBServer
            objDUser.ConnectionString = strConnectionString
            objDUser.Initialize()
        End Sub

        ' AddUser method
        ' Purpose: Add new user
        ' Input: main information of new user
        ' Output: integer value (0 if success)
        Public Function AddUser(ByRef intNewUID As Integer, Optional ByVal intIsLDAP As Int16 = 0) As Integer
            Try
                objDUser.FullName = objBCSP.ConvertItBack(strFullName)
                objDUser.UserName = objBCSP.ConvertItBack(strUserName)
                objDUser.UserPass = objBCSP.EncryptedPassword(strUserPass)
                objDUser.CatModule = intCatModule
                objDUser.PatModule = intPatModule
                objDUser.CirModule = intCirModule
                objDUser.AcqModule = intAcqModule
                objDUser.SerModule = intSerModule
                objDUser.ILLModule = intILLModule
                objDUser.DelModule = intDelModule
                objDUser.AdmModule = intAdmModule
                objDUser.ParentID = intParentID
                objDUser.LDAPAdsPath = objBCSP.ConvertItBack(strLDAPAdsPath)
                objDUser.LibID = intLibID
                AddUser = objDUser.AddUser(intNewUID, intIsLDAP)
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' UpdateUser method
        ' Purpose: Update user infor
        ' Input: main information of the selected user
        ' Output: integer value (0 if success)
        Public Function UpdateUser(Optional ByVal intISLDAP As Int16 = 0) As Integer
            Try
                objDUser.UID = intUID
                objDUser.FullName = objBCSP.ConvertItBack(strFullName)
                objDUser.UserName = objBCSP.ConvertItBack(strUserName)
                If strUserPass <> "" Then
                    objDUser.UserPass = objBCSP.EncryptedPassword(strUserPass)
                Else
                    objDUser.UserPass = ""
                End If
                objDUser.CatModule = intCatModule
                objDUser.PatModule = intPatModule
                objDUser.CirModule = intCirModule
                objDUser.AcqModule = intAcqModule
                objDUser.SerModule = intSerModule
                objDUser.ILLModule = intILLModule
                objDUser.DelModule = intDelModule
                objDUser.AdmModule = intAdmModule
                objDUser.ParentID = intParentID
                UpdateUser = objDUser.UpdateUser
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' ChangeUserPass method
        ' Purpose: Change user Password and FullName
        ' Input: main information of the selected user
        ' Output: integer value (0 if success)
        Public Function ChangeUserPass(Optional ByVal intISLDAP As Int16 = 0) As Integer
            Try
                objDUser.UID = intUID
                objDUser.FullName = objBCSP.ConvertItBack(strFullName)
                objDUser.UserName = objBCSP.ConvertItBack(strUserName)
                If strUserPass <> "" Then
                    objDUser.UserPass = objBCSP.EncryptedPassword(strUserPass)
                Else
                    objDUser.UserPass = ""
                End If
                ChangeUserPass = objDUser.ChangeUserPass(intISLDAP)
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function


        ' DeleteUser method
        ' Purpose: Delete user infor
        ' Input: UserIDs
        Public Sub DeleteUser()
            Try
                objDUser.UIDs = strUIDs
                objDUser.DeleteUser()
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        ' GetUsers method
        ' Purpose: Get user informations
        ' Input: UserID
        ' Output: datatable result
        Public Function GetUsers() As DataTable
            Try
                objDUser.UID = intUID
                objDUser.ParentID = intParentID
                objDUser.LibID = intLibID
                GetUsers = objBCDBS.ConvertTable(objDUser.GetUsers)
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function
        ' GetPermUsers method
        ' Purpose: Get user has UserType = 1 (had set permission)
        ' Input: UserID
        ' Output: datatable result
        Public Function GetPermUsers() As DataTable
            Try
                objDUser.UID = intUID
                objDUser.ParentID = intParentID
                objDUser.LibID = intLibID
                GetPermUsers = objBCDBS.ConvertTable(objDUser.GetPermUsers)
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function
        ' SelectUserSSC method
        ' Purpose: Grant user - UserType = 1 (had set permission)
        ' Input: UserName, FullName
        ' Output: datatable result
        Public Sub SelectUserSSC()
            Try
                objDUser.UIDs = strUIDs
                objDUser.UserName = strUserName
                objDUser.FullName = strFullName
                objDUser.LibID = intLibID
                objDUser.SelectUserSSC()
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub
        ' UnSelectUserSSC method
        ' Purpose: UnSelect user perm
        ' Input: UserIDs
        Public Sub UnSelectUserSSC()
            Try
                objDUser.UIDs = strUIDs
                objDUser.UnSelectUserSSC()
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        ' GrantRights method
        ' Purpose: Grant right for the selected user
        ' Input: UserID, rightID
        Public Sub GrantRights()
            Try
                objDUser.UID = intUID
                objDUser.RightID = intRightID
                objDUser.GrantRights()
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        ' GrantRights method
        ' Purpose: Grant right for the selected user
        ' Input: UserID, rightID
        Public Sub GrantBasicRights()
            Try
                objDUser.UID = intUID
                objDUser.GrantBasicRights()
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        ' GrantLocation method
        ' Purpose: Grant locations for the selected user
        ' Input: some informations
        Public Sub GrantLocation(ByVal intType As Integer)
            Try
                objDUser.UserID = intUserID
                objDUser.LocationID = intLocationID
                objDUser.GrantLocation(intType)
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        ' GetRoleInfor method
        ' Purpose: Get role informations
        ' Output: datatable result
        Public Function GetRoleInfor() As DataTable
            Try
                GetRoleInfor = objDUser.GetRoleInfor
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Function

        ' GetLocationInfor method
        ' Purpose: Get user informations
        ' Output: datatable result
        Public Sub GetLocationInfor(ByRef strCirLocs As String, ByRef strSerLocs As String, ByRef strAcqLocs As String)
            Try
                objDUser.UID = intUID
                objDUser.GetLocationInfor(strCirLocs, strSerLocs, strAcqLocs)
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch Ex As Exception
                strErrorMsg = Ex.Message
            Finally
            End Try
        End Sub

        ' GetUserLogin function 
        ' Purpose : check exist user when login
        ' Input: strUsername,strPassword
        ' Output: DataTable
        ' Creator: Lent (23-4-2005)
        Public Function GetUserLogin() As DataTable
            Try
                strUserName = objBCSP.ConvertItBack(strUserName)
                strUserPass = objBCSP.EncryptedPassword(strUserPass)
                objDUser.UserName = strUserName
                objDUser.UserPass = strUserPass
                GetUserLogin = objBCDBS.ConvertTable(objDUser.GetUserLogin())
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetUserLoginNonPass function 
        ' Purpose : check exist user when login with non password
        ' Input: strUsername
        ' Output: DataTable
        ' Creator: SonPQ
        Public Function GetUserLoginNonPass() As DataTable
            Try
                strUserName = objBCSP.ConvertItBack(strUserName)
                strUserPass = objBCSP.EncryptedPassword(strUserPass)
                objDUser.UserName = strUserName
                objDUser.UserPass = strUserPass
                GetUserLoginNonPass = objBCDBS.ConvertTable(objDUser.GetUserLoginNonPass())
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetLDAPUserLogin(ByVal strAdsPath As String) As DataTable
            Try
                strUserName = objBCSP.ConvertItBack(strUserName)
                objDUser.UserName = strUserName
                strAdsPath = objBCSP.ConvertItBack(strAdsPath)
                GetLDAPUserLogin = objBCDBS.ConvertTable(objDUser.GetLDAPUserLogin(strAdsPath))
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetUserCount() As DataTable
            Try
                GetUserCount = objDUser.GetUserCount
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' getModules function 
        ' Purpose : get all module
        ' Input: strRightList, intParentId
        ' Output: DataTable
        ' Creator: PhuongTT  - 2014.09.17
        Public Function getModules(Optional ByVal intParentId As Integer = 0) As DataTable
            Try
                objDUser.RightList = RightList
                getModules = objDUser.getModules(intParentId)
                strErrorMsg = objDUser.ErrorMsg
                intErrorCode = objDUser.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDUser Is Nothing Then
                    objDUser.Dispose(True)
                    objDUser = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace