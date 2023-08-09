Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACEDelivCustomerInfor
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDEDeCusInfor As New clsDOPACEDelivCustomerInfor
        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private strUserName As String
        Private strFullName As String
        Private strContacter As String
        Private strEmail As String
        Private strTel As String
        Private strFax As String
        Private strPassword As String
        Private strCompany As String
        Private intCountryID As Integer
        Private strDepartment As String
        Private strStreet As String
        Private strBox As String
        Private strCity As String
        Private strRegion As String
        Private strCode As String
        Private strPhone As String
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
        'User  of Acccount
        Public Property UserName() As String
            Get
                Return strUserName
            End Get
            Set(ByVal Value As String)
                strUserName = Value
            End Set
        End Property

        'FullName  of Acccount
        Public Property FullName() As String
            Get
                Return strFullName
            End Get
            Set(ByVal Value As String)
                strFullName = Value
            End Set
        End Property

        ' Contacter of Acccount
        Public Property Contacter() As String
            Get
                Return strContacter
            End Get
            Set(ByVal Value As String)
                strContacter = Value
            End Set
        End Property

        'Email of Acccount
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
            End Set
        End Property

        'Tel of Acccount
        Public Property Tel() As String
            Get
                Return strTel
            End Get
            Set(ByVal Value As String)
                strTel = Value
            End Set
        End Property

        'Fax of Acccount
        Public Property Fax() As String
            Get
                Return strFax
            End Get
            Set(ByVal Value As String)
                strFax = Value
            End Set
        End Property

        'Password of Acccount
        Public Property Password() As String
            Get
                Return strPassword
            End Get
            Set(ByVal Value As String)
                strPassword = Value
            End Set
        End Property

        'Company of Acccount
        Public Property Company() As String
            Get
                Return strCompany
            End Get
            Set(ByVal Value As String)
                strCompany = Value
            End Set
        End Property

        'CountryID of Acccount
        Public Property CountryID() As Integer
            Get
                Return intCountryID
            End Get
            Set(ByVal Value As Integer)
                intCountryID = Value
            End Set
        End Property

        ' Department property
        Public Property Department() As String
            Get
                Return strDepartment
            End Get
            Set(ByVal Value As String)
                strDepartment = Value
            End Set
        End Property

        ' Street property
        Public Property Street() As String
            Get
                Return strStreet
            End Get
            Set(ByVal Value As String)
                strStreet = Value
            End Set
        End Property

        ' Box property
        Public Property Box() As String
            Get
                Return strBox
            End Get
            Set(ByVal Value As String)
                strBox = Value
            End Set
        End Property

        ' City property
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal Value As String)
                strCity = Value
            End Set
        End Property

        ' Region property
        Public Property Region() As String
            Get
                Return strRegion
            End Get
            Set(ByVal Value As String)
                strRegion = Value
            End Set
        End Property

        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                strCode = Value
            End Set
        End Property

        ' Phone property
        Public Property Phone() As String
            Get
                Return strPhone
            End Get
            Set(ByVal Value As String)
                strPhone = Value
            End Set
        End Property

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

            ' Init objDAcqPurchaseOrder object
            objDEDeCusInfor.DBServer = strDBServer
            objDEDeCusInfor.ConnectionString = strConnectionString
            objDEDeCusInfor.Initialize()
        End Sub


        ' purpose : Create new E-Delivery account
        ' Created by: dgsoft
        Public Sub CreateAccount(ByRef intOutPut As Int16)
            Try
                objDEDeCusInfor.UserName = strUserName
                objDEDeCusInfor.FullName = objBSP.ConvertItBack(strFullName)
                objDEDeCusInfor.Company = objBSP.ConvertItBack(strCompany)
                objDEDeCusInfor.Department = objBSP.ConvertItBack(strDepartment)
                objDEDeCusInfor.Street = objBSP.ConvertItBack(strStreet)
                objDEDeCusInfor.Box = objBSP.ConvertItBack(strBox)
                objDEDeCusInfor.City = objBSP.ConvertItBack(strCity)
                objDEDeCusInfor.Region = objBSP.ConvertItBack(strRegion)
                objDEDeCusInfor.CountryID = intCountryID
                objDEDeCusInfor.Code = strCode
                objDEDeCusInfor.Phone = strPhone
                objDEDeCusInfor.Email = strEmail
                objDEDeCusInfor.Password = strPassword
                objDEDeCusInfor.Fax = strFax
                objDEDeCusInfor.Contacter = objBSP.ConvertItBack(strContacter)
                objDEDeCusInfor.SecretLevel = intSecretLevel
                objDEDeCusInfor.CreateAccount(intOutPut)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' purpose : Read information of E-Delivery account
        ' Created by: dgsoft
        Public Function GetAccount() As DataTable

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

                If Not objDEDeCusInfor Is Nothing Then
                    objDEDeCusInfor.Dispose(True)
                    objDEDeCusInfor = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace