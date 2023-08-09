' Name: clsBPhyDelAddress
' Purpose: Physical del address
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBPhyDelAddress
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private intID As Integer = 0
        Private strStreet As String = ""
        Private strXAddress As String = ""
        Private strAddress As String = ""
        Private strPOBox As String = ""
        Private strCity As String = ""
        Private strRegion As String = ""
        Private intCountryID As Integer = 0
        Private strPostCode As String = ""

        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc
        Private objDPhyDelAddress As New clsDPhyDelAddress

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************

        ' ID property
        Public Property ID() As Integer
            Get
                Return (intID)
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' Street property
        Public Property Street() As String
            Get
                Return (strStreet)
            End Get
            Set(ByVal Value As String)
                strStreet = Value
            End Set
        End Property

        ' XAddress property
        Public Property XAddress() As String
            Get
                Return (strXAddress)
            End Get
            Set(ByVal Value As String)
                strXAddress = Value
            End Set
        End Property

        ' Address property
        Public Property Address() As String
            Get
                Return (strAddress)
            End Get
            Set(ByVal Value As String)
                strAddress = Value
            End Set
        End Property

        ' POBox property
        Public Property POBox() As String
            Get
                Return (strPOBox)
            End Get
            Set(ByVal Value As String)
                strPOBox = Value
            End Set
        End Property

        ' City property
        Public Property City() As String
            Get
                Return (strCity)
            End Get
            Set(ByVal Value As String)
                strCity = Value
            End Set
        End Property

        ' Region property
        Public Property Region() As String
            Get
                Return (strRegion)
            End Get
            Set(ByVal Value As String)
                strRegion = Value
            End Set
        End Property

        ' Country ID property
        Public Property CountryID() As Integer
            Get
                Return (intCountryID)
            End Get
            Set(ByVal Value As Integer)
                intCountryID = Value
            End Set
        End Property

        ' PostCode property
        Public Property PostCode() As String
            Get
                Return (strPostCode)
            End Get
            Set(ByVal Value As String)
                strPostCode = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Initialize objDPhyDelAddress object
            objDPhyDelAddress.ConnectionString = strconnectionstring
            objDPhyDelAddress.DBServer = strdbserver
            objDPhyDelAddress.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = strinterfacelanguage
            objBCDBS.ConnectionString = strconnectionstring
            objBCDBS.DBServer = strdbserver
            objBCDBS.Initialize()

            ' Initialize objBCSP object
            objBCSP.InterfaceLanguage = strinterfacelanguage
            objBCSP.ConnectionString = strconnectionstring
            objBCSP.DBServer = strdbserver
            objBCSP.Initialize()
        End Sub

        ' Method: GetPhyDelAddr
        ' Purpose: Get physical del address
        ' Input: intID
        ' Output: Datatable
        ' Creator: Sondp
        Public Function GetPhyDelAddr(Optional ByVal splittor As Boolean = False) As DataTable
            Dim tblPhyDelAddr As New DataTable
            Dim inti As Integer

            Try
                objDPhyDelAddress.ID = intID
                objDPhyDelAddress.LibID = intLibID
                tblPhyDelAddr = objBCDBS.ConvertTable(objDPhyDelAddress.GetPhyDelAddr)
                strErrorMsg = objDPhyDelAddress.ErrorMsg
                intErrorCode = objDPhyDelAddress.ErrorCode
                If splittor = True Then
                    If Not tblPhyDelAddr Is Nothing Then
                        If tblPhyDelAddr.Rows.Count > 0 Then
                            For inti = 0 To tblPhyDelAddr.Rows.Count - 1
                                ' Format template: ID<$#$>Address<$#$>XAddress<$#$>Street<$#$>POBox<$#$>City<$#$>Region<$#$>CountryID<$#$>PostCode
                                tblPhyDelAddr.Rows(inti).Item("splittor") = tblPhyDelAddr.Rows(inti).Item("ID") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("Address") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("XAddress") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("Street") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("POBox") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("City") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("Region") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("CountryID") & "<$#$>" & tblPhyDelAddr.Rows(inti).Item("PostCode")
                            Next
                        End If
                    End If
                End If
                GetPhyDelAddr = tblPhyDelAddr
                intErrorCode = objDPhyDelAddress.ErrorCode
                strErrorMsg = objDPhyDelAddress.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Create
        ' Purpose: Create physical del address
        ' Input: Some Information
        ' Output: 0 if success, 1 if exists
        ' Creator: Sondp
        Public Function Create() As Integer
            Try
                objDPhyDelAddress.Address = objBCSP.ConvertItBack(strAddress)
                objDPhyDelAddress.City = objBCSP.ConvertItBack(strCity)
                objDPhyDelAddress.CountryID = intCountryID
                objDPhyDelAddress.POBox = objBCSP.ConvertItBack(strPOBox)
                objDPhyDelAddress.PostCode = objBCSP.ConvertItBack(strPostCode)
                objDPhyDelAddress.Region = objBCSP.ConvertItBack(strRegion)
                objDPhyDelAddress.Street = objBCSP.ConvertItBack(strStreet)
                objDPhyDelAddress.XAddress = objBCSP.ConvertItBack(strXAddress)
                objDPhyDelAddress.LibID = intLibID
                Create = objDPhyDelAddress.Create()
                strErrorMsg = objDPhyDelAddress.ErrorMsg
                intErrorCode = objDPhyDelAddress.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Update
        ' Purpose: Update physical del address
        ' Input: Some information
        ' Output: 0 if success, 1 if exists
        ' Creator: Sondp
        Public Function Update() As Integer
            Try
                objDPhyDelAddress.ID = intID
                objDPhyDelAddress.Address = objBCSP.ConvertItBack(strAddress)
                objDPhyDelAddress.City = objBCSP.ConvertItBack(strCity)
                objDPhyDelAddress.CountryID = intCountryID
                objDPhyDelAddress.POBox = objBCSP.ConvertItBack(strPOBox)
                objDPhyDelAddress.PostCode = objBCSP.ConvertItBack(strPostCode)
                objDPhyDelAddress.Region = objBCSP.ConvertItBack(strRegion)
                objDPhyDelAddress.Street = objBCSP.ConvertItBack(strStreet)
                objDPhyDelAddress.XAddress = objBCSP.ConvertItBack(strXAddress)
                Update = objDPhyDelAddress.Update()
                strErrorMsg = objDPhyDelAddress.ErrorMsg
                intErrorCode = objDPhyDelAddress.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Delete
        ' Purpose: Delete physical del address
        ' Input: intID
        ' Creator: Sondp
        Public Function Delete() As Integer
            Try
                objDPhyDelAddress.ID = intID
                Delete = objDPhyDelAddress.Delete()
                strErrorMsg = objDPhyDelAddress.ErrorMsg
                intErrorCode = objDPhyDelAddress.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Method: Dispose
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objDPhyDelAddress Is Nothing Then
                        objDPhyDelAddress.Dispose(True)
                        objDPhyDelAddress = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objBCSP Is Nothing Then
                        objBCSP.Dispose(True)
                        objBCSP = Nothing
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