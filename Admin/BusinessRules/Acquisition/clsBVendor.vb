' Class: clsBVendor
' Purpose: Manage vendor information
' Creator: Sondp
' Created Date: 
' Modification history:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBVendor
        Inherits clsBBase

        ' *****************************************************************************************************
        ' Declare Private variables
        ' *****************************************************************************************************

        Private intVendorID As Integer = 0
        Private strNameIDs As String = ""
        Private strName As String = ""
        Private strAddress As String = ""
        Private intProvinceID As Integer = 0
        Private intCountryID As Integer = 0
        Private strZip As String = ""
        Private strContactPerson As String = ""
        Private strTel As String = ""
        Private strFax As String = ""
        Private strEmail As String = ""
        Private strSAN As String = ""
        Private strLibSAN As String = ""
        Private blnX12Enable As Boolean = False
        Private strX12Email As String = ""
        Private intDeliveryTime As Integer = 0
        Private intClaimCycle1 As Integer = 0
        Private intClaimCycle2 As Integer = 0
        Private intClaimCycle3 As Integer = 0
        Private strClaimEmail As String = ""
        Private strLibAC As String = ""
        Private strBankingInfo As String = ""
        Private strNote As String = ""

        ' User define object
        Private objDVendor As New clsDVendor
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objBCT As New clsBCommonTemplate

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' Vendor Property
        Public Property Name()
            Get
                Return strName
            End Get
            Set(ByVal Value)
                strName = Value
            End Set
        End Property

        ' Address Property
        Public Property Address()
            Get
                Return strAddress
            End Get
            Set(ByVal Value)
                strAddress = Value
            End Set
        End Property

        ' ProvinceID Property
        Public Property ProvinceID()
            Get
                Return intProvinceID
            End Get
            Set(ByVal Value)
                intProvinceID = Value
            End Set
        End Property

        ' CountryID Property
        Public Property CountryID()
            Get
                Return intCountryID
            End Get
            Set(ByVal Value)
                intCountryID = Value
            End Set
        End Property

        ' Zip Property
        Public Property Zip()
            Get
                Return strZip
            End Get
            Set(ByVal Value)
                strZip = Value
            End Set
        End Property

        ' Contact person Property
        Public Property ContactPerson()
            Get
                Return strContactPerson
            End Get
            Set(ByVal Value)
                strContactPerson = Value
            End Set
        End Property

        ' Telephone Property
        Public Property Tel()
            Get
                Return strTel
            End Get
            Set(ByVal Value)
                strTel = Value
            End Set
        End Property

        ' Fax Property
        Public Property Fax()
            Get
                Return strFax
            End Get
            Set(ByVal Value)
                strFax = Value
            End Set
        End Property

        ' Email Property
        Public Property Email()
            Get
                Return strEmail
            End Get
            Set(ByVal Value)
                strEmail = Value
            End Set
        End Property

        ' SAN Property
        Public Property SAN()
            Get
                Return strSAN
            End Get
            Set(ByVal Value)
                strSAN = Value
            End Set
        End Property

        ' LibSAN Property
        Public Property LibSAN()
            Get
                Return strLibSAN
            End Get
            Set(ByVal Value)
                strLibSAN = Value
            End Set
        End Property

        ' X12Enable Property
        Public Property X12Enable()
            Get
                Return blnX12Enable
            End Get
            Set(ByVal Value)
                blnX12Enable = Value
            End Set
        End Property

        ' X12Email Property
        Public Property X12Email()
            Get
                Return strX12Email
            End Get
            Set(ByVal Value)
                strX12Email = Value
            End Set
        End Property

        ' DeliveryTime Property
        Public Property DeliveryTime()
            Get
                Return intDeliveryTime
            End Get
            Set(ByVal Value)
                intDeliveryTime = Value
            End Set
        End Property

        ' ClaimCycle1 Property
        Public Property ClaimCycle1()
            Get
                Return intClaimCycle1
            End Get
            Set(ByVal Value)
                intClaimCycle1 = Value
            End Set
        End Property

        ' ClaimCycle2 Property
        Public Property ClaimCycle2()
            Get
                Return intClaimCycle2
            End Get
            Set(ByVal Value)
                intClaimCycle2 = Value
            End Set
        End Property

        ' ClaimCycle3 Property
        Public Property ClaimCycle3()
            Get
                Return intClaimCycle3
            End Get
            Set(ByVal Value)
                intClaimCycle3 = Value
            End Set
        End Property

        ' ClaimEmail Property
        Public Property ClaimEmail()
            Get
                Return strClaimEmail
            End Get
            Set(ByVal Value)
                strClaimEmail = Value
            End Set
        End Property

        ' LibAC Property
        Public Property LibAC()
            Get
                Return strLibAC
            End Get
            Set(ByVal Value)
                strLibAC = Value
            End Set
        End Property

        ' BankingInfo Property
        Public Property BankingInfo()
            Get
                Return strBankingInfo
            End Get
            Set(ByVal Value)
                strBankingInfo = Value
            End Set
        End Property

        ' Note Property
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

        ' Method: Initialize
        ' Purpose: Init all objects
        Public Sub Initialize()
            ' Init object objDVendor
            objDVendor.ConnectionString = strConnectionString
            objDVendor.DBServer = strDBServer
            objDVendor.Initialize()

            ' Init object objBCDBS
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.DBServer = strDBServer
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init object objBCSP
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.DBServer = strDBServer
            objBCSP.Initialize()

            ' Init object objBCT
            objBCT.ConnectionString = strConnectionString
            objBCT.InterfaceLanguage = strInterfaceLanguage
            objBCT.DBServer = strDBServer
            objBCT.Initialize()
        End Sub

        ' Purpose: create new vendor
        ' Input: some infor
        ' Output: intRetval
        ' Creator: Sondp
        Public Function Create() As Integer
            Try
                objDVendor.Name = objBCSP.ConvertItBack(strName)
                objDVendor.Address = objBCSP.ConvertItBack(strAddress)
                objDVendor.ProvinceID = intProvinceID
                objDVendor.CountryID = intCountryID
                objDVendor.Zip = strZip
                objDVendor.ContactPerson = objBCSP.ConvertItBack(strContactPerson)
                objDVendor.Tel = strTel
                objDVendor.Fax = strFax
                objDVendor.Email = strEmail
                objDVendor.SAN = strSAN
                objDVendor.LibSAN = strLibSAN
                objDVendor.ClaimCycle1 = intClaimCycle1
                objDVendor.ClaimCycle2 = intClaimCycle2
                objDVendor.ClaimCycle3 = intClaimCycle3
                objDVendor.ClaimEmail = strClaimEmail
                objDVendor.DeliveryTime = intDeliveryTime
                objDVendor.X12Enable = blnX12Enable
                objDVendor.X12Email = strX12Email
                objDVendor.LibAC = strLibAC
                objDVendor.BankingInfo = objBCSP.ConvertItBack(strBankingInfo)
                objDVendor.Note = objBCSP.ConvertItBack(strNote)
                Create = objDVendor.Create
                strErrorMsg = objDVendor.ErrorMsg
                intErrorCode = objDVendor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Purpose: Update vendor
        ' In: some infor
        ' Output: intRetval
        ' Creator: Sondp
        Public Function Update() As Integer
            Try
                objDVendor.VendorID = intVendorID
                objDVendor.Name = objBCSP.ConvertItBack(strName)
                objDVendor.Address = objBCSP.ConvertItBack(strAddress)
                objDVendor.ProvinceID = intProvinceID
                objDVendor.CountryID = intCountryID
                objDVendor.Zip = strZip
                objDVendor.ContactPerson = objBCSP.ConvertItBack(strContactPerson)
                objDVendor.Tel = strTel
                objDVendor.Fax = strFax
                objDVendor.Email = strEmail
                objDVendor.SAN = strSAN
                objDVendor.LibSAN = strLibSAN
                objDVendor.ClaimCycle1 = intClaimCycle1
                objDVendor.ClaimCycle2 = intClaimCycle2
                objDVendor.ClaimCycle3 = intClaimCycle3
                objDVendor.ClaimEmail = strClaimEmail
                objDVendor.DeliveryTime = intDeliveryTime
                objDVendor.X12Enable = blnX12Enable
                objDVendor.X12Email = strX12Email
                objDVendor.LibAC = strLibAC
                objDVendor.BankingInfo = objBCSP.ConvertItBack(strBankingInfo)
                objDVendor.Note = objBCSP.ConvertItBack(strNote)
                Update = objDVendor.Update()
                strErrorMsg = objDVendor.ErrorMsg
                intErrorCode = objDVendor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Delete vendor
        ' In: intVendorID
        ' Output: intRetVal
        ' Creator: Sondp
        Public Function Delete() As Integer
            Try
                objDVendor.VendorID = intVendorID
                Delete = objDVendor.Delete()
                strErrorMsg = objDVendor.ErrorMsg
                intErrorCode = objDVendor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        ' Purpose: Get list of vendor
        ' Input: intVendorID
        ' Outputput: Datatable result
        ' Creator: Sondp
        Public Function GetVendor() As DataTable
            Try
                objDVendor.VendorID = intVendorID
                GetVendor = objBCDBS.ConvertTable(objDVendor.GetVendor)
                strErrorMsg = objDVendor.ErrorMsg
                intErrorCode = objDVendor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' Purpose: Get Vendor for send PO
        ' In: intVendorID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetVendorSendPO() As DataTable
            Try
                objDVendor.VendorID = intVendorID
                GetVendorSendPO = objBCDBS.ConvertTable(objDVendor.GetVendorSendPO)
                strErrorMsg = objDVendor.ErrorMsg
                intErrorCode = objDVendor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get province
        ' In: 
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetProvince() As DataTable
            Try
                GetProvince = objBCDBS.ConvertTable(objDVendor.GetProvince)
                strErrorMsg = objDVendor.ErrorMsg
                intErrorCode = objDVendor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get po contact by vendor
        ' In: intVendorID
        ' Out: Datatable
        ' Creator: Sondp
        ' CreatedDate: 07/04/2005
        Public Function GetContract() As DataTable
            Try
                objDVendor.VendorID = intVendorID
                GetContract = objBCDBS.ConvertTable(objDVendor.GetContract)
                strErrorMsg = objDVendor.ErrorMsg
                intErrorCode = objDVendor.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Dispose
        ' Purpose: Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDVendor Is Nothing Then
                        objDVendor.Dispose(True)
                        objDVendor = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                    If Not objBCT Is Nothing Then
                        objBCT.Dispose(True)
                        objBCT = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace