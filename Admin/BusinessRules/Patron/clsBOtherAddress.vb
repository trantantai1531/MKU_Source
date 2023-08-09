Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Patron

Namespace eMicLibAdmin.BusinessRules.Patron
    Public Class clsBOtherAddress
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strPatronIDs As String
        Private intPatronID As Integer
        Private strAddress As String
        Private strProvince As String
        Private strCity As String
        Private strCountry As String
        Private strZip As String
        Private strActive As String

        Private objDOtherAddress As New clsDOtherAddress
        Private objBCDBS As New clsBCommonDBSystem

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************

        ' PatronIDs property
        Public Property PatronIDs() As String
            Get
                Return strPatronIDs
            End Get
            Set(ByVal Value As String)
                strPatronIDs = Value
            End Set
        End Property

        ' PatronID property
        Public Property PatronID() As Integer
            Get
                Return intPatronID
            End Get
            Set(ByVal Value As Integer)
                intPatronID = Value
            End Set
        End Property

        ' Address property
        Public Property Address() As String
            Get
                Return strAddress
            End Get
            Set(ByVal Value As String)
                strAddress = Value & ""
            End Set
        End Property

        ' Province Property
        Public Property Province() As String
            Get
                Return strProvince
            End Get
            Set(ByVal Value As String)
                strProvince = Value & ""
            End Set
        End Property

        ' City property
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal Value As String)
                strCity = Value & ""
            End Set
        End Property

        ' Country property
        Public Property Country() As String
            Get
                Return strCountry
            End Get
            Set(ByVal Value As String)
                strCountry = Value & ""
            End Set
        End Property

        ' Zip property
        Public Property Zip() As String
            Get
                Return strZip
            End Get
            Set(ByVal Value As String)
                strZip = Value & ""
            End Set
        End Property

        ' Active property
        Public Property Active() As String
            Get
                Return strActive
            End Get
            Set(ByVal Value As String)
                strActive = Value & ""
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' Declare public method
        ' *************************************************************************************************
        Public Sub initialize()
            objDOtherAddress.DBServer = strDBServer
            objDOtherAddress.ConnectionString = strConnectionString
            objDOtherAddress.Initialize()

            ' Initialize objBCSP object
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            Call objBCDBS.Initialize()
        End Sub

        Public Function GetOtherAddress() As DataTable
            Try
                objDOtherAddress.PatronID = intPatronID
                GetOtherAddress = objBCDBS.ConvertTable(objDOtherAddress.GetOtherAddress)
                strErrorMsg = objDOtherAddress.ErrorMsg
                intErrorCode = objDOtherAddress.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Function

        ' Method: Create
        ' Purpose: Create patron's address informations
        ' Input: All parameters
        ' Creator: Sondp
        Public Sub Create(ByVal strAddress As String, ByVal intProvinceID As Integer, ByVal strCity As String, ByVal intCountryID As Integer, ByVal strZip As String, ByVal intisActive As Integer)
            Try
                objDOtherAddress.PatronID = intPatronID
                Call objDOtherAddress.Create(strAddress, intProvinceID, strCity, intCountryID, strZip, intisActive)
                strErrorMsg = objDOtherAddress.ErrorMsg
                intErrorCode = objDOtherAddress.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        ' Method: Create
        ' Purpose: Update patron's address informations
        ' Input: All parameters
        ' Creator: Sondp
        Public Sub Update(ByVal intID As Integer, ByVal strAddress As String, ByVal intProvinceID As Integer, ByVal strCity As String, ByVal intCountryID As Integer, ByVal strZip As String, ByVal intisActive As Integer)
            Try
                objDOtherAddress.PatronID = intPatronID
                Call objDOtherAddress.Update(intID, strAddress, intProvinceID, strCity, intCountryID, strZip, intisActive)
                strErrorMsg = objDOtherAddress.ErrorMsg
                intErrorCode = objDOtherAddress.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        ' Method: Delete
        ' Purpose: delete patron's address informations
        ' Input: All parameters
        ' Creator: Sondp
        Public Sub Delete()
            Try
                objDOtherAddress.PatronID = intPatronID
                Call objDOtherAddress.Delete()
                strErrorMsg = objDOtherAddress.ErrorMsg
                intErrorCode = objDOtherAddress.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.Trim
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDOtherAddress Is Nothing Then
                        objDOtherAddress.Dispose(True)
                        objDOtherAddress = Nothing
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