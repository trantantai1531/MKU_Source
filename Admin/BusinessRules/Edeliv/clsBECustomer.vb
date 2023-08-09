Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Edeliv

Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBECustomer
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDECustomer As New clsDECustomer

        Private strUserName As String = ""
        Private strName As String = ""
        Private strDelivName As String = ""
        Private strDelivXAddr As String = ""
        Private strDelivStreet As String = ""
        Private strDelivBox As String = ""
        Private strDelivCity As String = ""
        Private strDelivRegion As String = ""
        Private intDelivCountryID As Integer = 0
        Private strDelivCode As String = ""
        Private strTelephone As String = ""
        Private strEmailAddress As String = ""
        Private strNote As String = ""
        Private strPassword As String = ""
        Private dblDebt As Double = 0
        Private intApproved As Integer = 0
        Private strFax As String = ""
        Private strContactPerson As String = ""
        Private intCustomerID As Integer = 0
        Private intSecretLevel As Integer = 0

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
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

        ' *************************************************************************************************
        ' End declare public properties
        ' Implement methods here
        ' *************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBSP.DBServer = strDBServer
            objBSP.ConnectionString = strConnectionString
            objBSP.InterfaceLanguage = strInterfaceLanguage
            objBSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDECustomer object
            objDECustomer.DBServer = strDBServer
            objDECustomer.ConnectionString = strConnectionString
            objDECustomer.Initialize()
        End Sub

        ' Create method
        ' Purpose: create new customer record
        ' Input: main infor of customer infor
        ' Output: int value (0 when success)
        Public Function Create() As Integer
            Try
                objDECustomer.UserName = strUserName
                objDECustomer.Name = objBSP.ConvertItBack(strName)
                objDECustomer.DelivName = objBSP.ConvertItBack(strDelivName)
                objDECustomer.DelivXAddr = objBSP.ConvertItBack(strDelivXAddr)
                objDECustomer.DelivStreet = objBSP.ConvertItBack(strDelivStreet)
                objDECustomer.DelivBox = objBSP.ConvertItBack(strDelivBox)
                objDECustomer.DelivCity = objBSP.ConvertItBack(strDelivCity)
                objDECustomer.DelivRegion = objBSP.ConvertItBack(strDelivRegion)
                objDECustomer.DelivCountryID = intDelivCountryID
                objDECustomer.DelivCode = strDelivCode
                objDECustomer.Telephone = strTelephone
                objDECustomer.EmailAddress = strEmailAddress
                objDECustomer.Note = objBSP.ConvertItBack(strNote)
                objDECustomer.Password = strPassword
                objDECustomer.Fax = strFax
                objDECustomer.ContactPerson = objBSP.ConvertItBack(strContactPerson)
                objDECustomer.Approved = intApproved
                objDECustomer.SecretLevel = intSecretLevel
                Create = objDECustomer.Create()
                intErrorCode = objDECustomer.ErrorCode
                strErrorMsg = objDECustomer.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Update method
        ' Purpose: update information of the selected customer record
        ' Input: main infor of customer infor
        ' Output: int value (0 when success)
        Public Function Update() As Integer
            Try
                objDECustomer.CustomerID = intCustomerID
                objDECustomer.UserName = strUserName
                objDECustomer.Name = objBSP.ConvertItBack(strName)
                objDECustomer.DelivName = objBSP.ConvertItBack(strDelivName)
                objDECustomer.DelivXAddr = objBSP.ConvertItBack(strDelivXAddr)
                objDECustomer.DelivStreet = objBSP.ConvertItBack(strDelivStreet)
                objDECustomer.DelivBox = objBSP.ConvertItBack(strDelivBox)
                objDECustomer.DelivCity = objBSP.ConvertItBack(strDelivCity)
                objDECustomer.DelivRegion = objBSP.ConvertItBack(strDelivRegion)
                objDECustomer.DelivCountryID = intDelivCountryID
                objDECustomer.DelivCode = strDelivCode
                objDECustomer.Telephone = strTelephone
                objDECustomer.EmailAddress = strEmailAddress
                objDECustomer.Note = objBSP.ConvertItBack(strNote)
                objDECustomer.Password = strPassword
                objDECustomer.Fax = strFax
                objDECustomer.ContactPerson = objBSP.ConvertItBack(strContactPerson)
                objDECustomer.Approved = intApproved
                objDECustomer.SecretLevel = intSecretLevel
                Update = objDECustomer.Update()
                intErrorCode = objDECustomer.ErrorCode
                strErrorMsg = objDECustomer.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete method
        ' Purpose: delete the selected customer record
        ' Input: CustomerID
        ' Output: int value (0 when success)
        Public Sub Delete()
            Try
                objDECustomer.CustomerID = intCustomerID
                objDECustomer.Delete()
                intErrorCode = objDECustomer.ErrorCode
                strErrorMsg = objDECustomer.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetCustomerInfor method
        ' Purpose: Get information of the selected customer (also of all sys customers)
        ' Input: main infor of customer infor
        ' Output: datatable result
        Public Function GetCustomerInfor() As DataTable
            Try
                objDECustomer.CustomerID = intCustomerID
                GetCustomerInfor = objBCDBS.ConvertTable(objDECustomer.GetCustomerInfor)
                intErrorCode = objDECustomer.ErrorCode
                strErrorMsg = objDECustomer.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCustomerInforByCode method
        ' Purpose: Get information of the selected customer
        ' Input: main infor of customer infor
        ' Output: datatable result
        Public Function GetCustomerInforByCode(ByVal strCustomerCode As String) As DataTable
            Try
                GetCustomerInforByCode = objBCDBS.ConvertTable(objDECustomer.GetCustomerInforByCode(strCustomerCode))
                intErrorCode = objDECustomer.ErrorCode
                strErrorMsg = objDECustomer.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSP Is Nothing Then
                    objBSP.Dispose(True)
                    objBSP = Nothing
                End If
                If Not objDECustomer Is Nothing Then
                    objDECustomer.Dispose(True)
                    objDECustomer = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace