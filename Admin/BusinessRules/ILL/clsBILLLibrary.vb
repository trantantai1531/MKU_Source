' Name: clsBZ3950Server
' Purpose: Process on remote library
' Creator: Sondp
' Created Date: 25/11/2004
' Modification History: 

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBILLLibrary
        Inherits clsBBase
        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************

        Private lngLibID As Long = 0
        Private strLibrarySymbol As String = ""
        Private strPostDelivName As String = ""
        Private strLibraryName As String = ""
        Private strLibraryCode As String = ""
        Private strPostDelivXAddr As String = ""
        Private strPostDelivStreet As String = ""
        Private strPostDelivBox As String = ""
        Private strPostDelivCity As String = ""
        Private strPostDelivRegion As String = ""
        Private intPostDelivCountry As Integer = 0
        Private strPostDelivMode As String = ""
        Private strEDelivMode As String = ""
        Private strEDelivTSAddr As String = ""
        Private strTelephone As String = ""
        Private strEmailReplyAddress As String = ""
        Private strBillDelivName As String = ""
        Private strBillDelivXAddr As String = ""
        Private strBillDelivStreet As String = ""
        Private strBillDelivBox As String = ""
        Private strBillDelivCity As String = ""
        Private strBillDelivRegion As String = ""
        Private intBillDelivCountry As Integer = 0
        Private strName7 As String = ""
        Private strNote As String = ""
        Private strPostDelivCode As String = ""
        Private strBillDelivCode As String = ""
        Private strAccountNumber As String = ""
        Private intEncodingScheme As Int16 = 0

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDILLLibrary As New clsDILLLibrary

        ' LibID property
        Public Property IllLibID() As Long
            Get
                Return lngLibID
            End Get
            Set(ByVal Value As Long)
                lngLibID = Value
            End Set
        End Property

        ' Library Symbol property
        Public Property LibrarySymbol() As String
            Get
                Return strLibrarySymbol
            End Get
            Set(ByVal Value As String)
                strLibrarySymbol = Value
            End Set
        End Property

        ' PostDelivName property
        Public Property PostDelivName() As String
            Get
                Return strPostDelivName
            End Get
            Set(ByVal Value As String)
                strPostDelivName = Value
            End Set
        End Property

        ' Library Name property
        Public Property LibraryName() As String
            Get
                Return strLibraryName
            End Get
            Set(ByVal Value As String)
                strLibraryName = Value
            End Set
        End Property

        ' Library Code property
        Public Property LibraryCode() As String
            Get
                Return strLibraryCode
            End Get
            Set(ByVal Value As String)
                strLibraryCode = Value
            End Set
        End Property

        ' PostDelivXAddr property
        Public Property PostDelivXAddr() As String
            Get
                Return strPostDelivXAddr
            End Get
            Set(ByVal Value As String)
                strPostDelivXAddr = Value
            End Set
        End Property

        ' PostDelivStreet property
        Public Property PostDelivStreet() As String
            Get
                Return strPostDelivStreet
            End Get
            Set(ByVal Value As String)
                strPostDelivStreet = Value
            End Set
        End Property

        ' PostDelivBox property
        Public Property PostDelivBox() As String
            Get
                Return strPostDelivBox
            End Get
            Set(ByVal Value As String)
                strPostDelivBox = Value
            End Set
        End Property

        ' PostDelivCode property
        Public Property PostDelivCode() As String
            Get
                Return strPostDelivCode
            End Get
            Set(ByVal Value As String)
                strPostDelivCode = Value
            End Set
        End Property

        ' BillDelivCode property
        Public Property BillDelivCode() As String
            Get
                Return strBillDelivCode
            End Get
            Set(ByVal Value As String)
                strBillDelivCode = Value
            End Set
        End Property

        ' PostDelivCity property
        Public Property PostDelivCity() As String
            Get
                Return strPostDelivCity
            End Get
            Set(ByVal Value As String)
                strPostDelivCity = Value
            End Set
        End Property

        ' PostDelivRegion property
        Public Property PostDelivRegion() As String
            Get
                Return strPostDelivRegion
            End Get
            Set(ByVal Value As String)
                strPostDelivRegion = Value
            End Set
        End Property

        ' PostDelivCountry property
        Public Property PostDelivCountry() As Integer
            Get
                Return intPostDelivCountry
            End Get
            Set(ByVal Value As Integer)
                intPostDelivCountry = Value
            End Set
        End Property

        ' PostDelivMode property
        Public Property PostDelivMode() As String
            Get
                Return strPostDelivMode
            End Get
            Set(ByVal Value As String)
                strPostDelivMode = Value
            End Set
        End Property

        ' EDelivMode property
        Public Property EDelivMode() As String
            Get
                Return strEDelivMode
            End Get
            Set(ByVal Value As String)
                strEDelivMode = Value
            End Set
        End Property

        ' EDelivTSAddr property
        Public Property EDelivTSAddr() As String
            Get
                Return strEDelivTSAddr
            End Get
            Set(ByVal Value As String)
                strEDelivTSAddr = Value
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

        ' EmailReplyAddress property
        Public Property EmailReplyAddress() As String
            Get
                Return strEmailReplyAddress
            End Get
            Set(ByVal Value As String)
                strEmailReplyAddress = Value
            End Set
        End Property

        ' BillDelivName property
        Public Property BillDelivName() As String
            Get
                Return strBillDelivName
            End Get
            Set(ByVal Value As String)
                strBillDelivName = Value
            End Set
        End Property

        ' BillDelivXAddr property
        Public Property BillDelivXAddr() As String
            Get
                Return strBillDelivXAddr
            End Get
            Set(ByVal Value As String)
                strBillDelivXAddr = Value
            End Set
        End Property

        ' BillDelivStreet property
        Public Property BillDelivStreet() As String
            Get
                Return strBillDelivStreet
            End Get
            Set(ByVal Value As String)
                strBillDelivStreet = Value
            End Set
        End Property

        ' BillDelivBox property
        Public Property BillDelivBox() As String
            Get
                Return strBillDelivBox
            End Get
            Set(ByVal Value As String)
                strBillDelivBox = Value
            End Set
        End Property

        ' BillDelivCity property
        Public Property BillDelivCity() As String
            Get
                Return strBillDelivCity
            End Get
            Set(ByVal Value As String)
                strBillDelivCity = Value
            End Set
        End Property

        ' BillDelivCountry property
        Public Property BillDelivCountry() As Integer
            Get
                Return intBillDelivCountry
            End Get
            Set(ByVal Value As Integer)
                intBillDelivCountry = Value
            End Set
        End Property

        ' BillDelivRegion property
        Public Property BillDelivRegion() As String
            Get
                Return strBillDelivRegion
            End Get
            Set(ByVal Value As String)
                strBillDelivRegion = Value
            End Set
        End Property

        ' Name7 property
        Public Property Name7() As String
            Get
                Return strName7
            End Get
            Set(ByVal Value As String)
                strName7 = Value
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

        ' AccountNumber property
        Public Property AccountNumber() As String
            Get
                Return strAccountNumber
            End Get
            Set(ByVal Value As String)
                strAccountNumber = Value
            End Set
        End Property

        ' EncodingScheme property
        Public Property EncodingScheme() As Int16
            Get
                Return intEncodingScheme
            End Get
            Set(ByVal Value As Int16)
                intEncodingScheme = Value
            End Set
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCSP object
            objBCSP.DBServer = strDBServer
            objBCSP.ConnectionString = strConnectionString
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDILLLibrary object  
            objDILLLibrary.DBServer = strDBServer
            objDILLLibrary.ConnectionString = strConnectionString
            objDILLLibrary.Initialize()
        End Sub

        Public Function GetLib(Optional ByVal intType As Integer = 0) As DataTable
            Try
                objDILLLibrary.IllLibID = lngLibID
                objDILLLibrary.LibID = intLibID
                GetLib = objBCDBS.ConvertTable(objDILLLibrary.GetLib(intType))
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Create() As Integer
            Try
                objDILLLibrary.AccountNumber = objBCSP.ConvertItBack(strAccountNumber)
                objDILLLibrary.LibrarySymbol = Replace(Replace(objBCSP.ConvertItBack(strLibrarySymbol), "''", ""), "'", "")
                objDILLLibrary.LibraryName = Replace(Replace(objBCSP.ConvertItBack(strLibraryName), "''", ""), "'", "")
                objDILLLibrary.EmailReplyAddress = objBCSP.ConvertItBack(strEmailReplyAddress)
                objDILLLibrary.Telephone = objBCSP.ConvertItBack(strTelephone)
                objDILLLibrary.LibraryCode = Replace(Replace(objBCSP.ConvertItBack(strLibraryCode), "''", ""), "'", "")
                objDILLLibrary.Note = objBCSP.ConvertItBack(strNote)
                objDILLLibrary.EDelivMode = objBCSP.ConvertItBack(strEDelivMode)
                objDILLLibrary.EDelivTSAddr = objBCSP.ConvertItBack(strEDelivTSAddr)
                objDILLLibrary.BillDelivName = objBCSP.ConvertItBack(strBillDelivName)
                objDILLLibrary.BillDelivXAddr = objBCSP.ConvertItBack(strBillDelivXAddr)
                objDILLLibrary.BillDelivStreet = objBCSP.ConvertItBack(strBillDelivStreet)
                objDILLLibrary.BillDelivBox = objBCSP.ConvertItBack(strBillDelivBox)
                objDILLLibrary.BillDelivCity = objBCSP.ConvertItBack(strBillDelivCity)
                objDILLLibrary.BillDelivRegion = objBCSP.ConvertItBack(strBillDelivRegion)
                objDILLLibrary.BillDelivCountry = intBillDelivCountry
                objDILLLibrary.BillDelivCode = objBCSP.ConvertItBack(strBillDelivCode)
                objDILLLibrary.PostDelivName = objBCSP.ConvertItBack(strPostDelivName)
                objDILLLibrary.PostDelivXAddr = objBCSP.ConvertItBack(strPostDelivXAddr)
                objDILLLibrary.PostDelivStreet = objBCSP.ConvertItBack(strPostDelivStreet)
                objDILLLibrary.PostDelivBox = objBCSP.ConvertItBack(strPostDelivBox)
                objDILLLibrary.PostDelivCity = objBCSP.ConvertItBack(strPostDelivCity)
                objDILLLibrary.PostDelivRegion = objBCSP.ConvertItBack(strPostDelivRegion)
                objDILLLibrary.PostDelivCountry = intPostDelivCountry
                objDILLLibrary.PostDelivCode = objBCSP.ConvertItBack(strPostDelivCode)
                objDILLLibrary.EncodingScheme = intEncodingScheme
                objDILLLibrary.LibID = intLibID
                Create = objDILLLibrary.Create()
                strErrorMsg = objDILLLibrary.ErrorMsg
                intErrorCode = objDILLLibrary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Update() As Integer
            Try
                objDILLLibrary.LibID = lngLibID
                objDILLLibrary.LibrarySymbol = Replace(Replace(objBCSP.ConvertItBack(strLibrarySymbol), "''", ""), "'", "")
                objDILLLibrary.LibraryName = Replace(Replace(objBCSP.ConvertItBack(strLibraryName), "''", ""), "'", "")
                objDILLLibrary.EmailReplyAddress = objBCSP.ConvertItBack(strEmailReplyAddress)
                objDILLLibrary.Telephone = objBCSP.ConvertItBack(strTelephone)
                objDILLLibrary.LibraryCode = Replace(Replace(objBCSP.ConvertItBack(strLibraryCode), "''", ""), "'", "")
                objDILLLibrary.Note = objBCSP.ConvertItBack(strNote)
                objDILLLibrary.EDelivMode = objBCSP.ConvertItBack(strEDelivMode)
                objDILLLibrary.EDelivTSAddr = objBCSP.ConvertItBack(strEDelivTSAddr)
                objDILLLibrary.BillDelivName = objBCSP.ConvertItBack(strBillDelivName)
                objDILLLibrary.BillDelivXAddr = objBCSP.ConvertItBack(strBillDelivXAddr)
                objDILLLibrary.BillDelivStreet = objBCSP.ConvertItBack(strBillDelivStreet)
                objDILLLibrary.BillDelivBox = objBCSP.ConvertItBack(strBillDelivBox)
                objDILLLibrary.BillDelivCity = objBCSP.ConvertItBack(strBillDelivCity)
                objDILLLibrary.BillDelivRegion = objBCSP.ConvertItBack(strBillDelivRegion)
                objDILLLibrary.BillDelivCountry = intBillDelivCountry
                objDILLLibrary.BillDelivCode = objBCSP.ConvertItBack(strBillDelivCode)
                objDILLLibrary.PostDelivName = objBCSP.ConvertItBack(strPostDelivName)
                objDILLLibrary.PostDelivXAddr = objBCSP.ConvertItBack(strPostDelivXAddr)
                objDILLLibrary.PostDelivStreet = objBCSP.ConvertItBack(strPostDelivStreet)
                objDILLLibrary.PostDelivBox = objBCSP.ConvertItBack(strPostDelivBox)
                objDILLLibrary.PostDelivCity = objBCSP.ConvertItBack(strPostDelivCity)
                objDILLLibrary.PostDelivRegion = objBCSP.ConvertItBack(strPostDelivRegion)
                objDILLLibrary.PostDelivCountry = intPostDelivCountry
                objDILLLibrary.PostDelivCode = objBCSP.ConvertItBack(strPostDelivCode)
                objDILLLibrary.EncodingScheme = intEncodingScheme
                Update = objDILLLibrary.Update()
                strErrorMsg = objDILLLibrary.ErrorMsg
                intErrorCode = objDILLLibrary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete method
        ' Purpose: Delete a remote library
        ' Input: LibID
        ' Output: 0 if success
        ' Creator: 
        Public Function Delete() As Integer
            Try
                objDILLLibrary.LibID = lngLibID
                Delete = objDILLLibrary.Delete()
                strErrorMsg = objDILLLibrary.ErrorMsg
                intErrorCode = objDILLLibrary.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Get Edelivery Local Library method
        ' Purpose: Get Edelivery local libraries
        ' Input: intID (0 is all)
        ' Output:  DataTable
        ' Creator: Sondp
        Public Function GetELocalLib(Optional ByVal intID As Integer = 0) As DataTable
            Try
                GetELocalLib = objBCDBS.ConvertTable(objDILLLibrary.GetELocalLib(intID))
                intErrorCode = objDILLLibrary.ErrorCode
                strErrorMsg = objDILLLibrary.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Get Local Library method
        ' Purpose: Get local libraries
        ' Input: intID (0 is all)
        ' Output:  DataTable
        ' Creator: Sondp
        Public Function GetLocalLib(Optional ByVal intID As Integer = 0) As DataTable
            Try
                GetLocalLib = objBCDBS.ConvertTable(objDILLLibrary.GetLocalLib(intID))
                intErrorCode = objDILLLibrary.ErrorCode
                strErrorMsg = objDILLLibrary.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Purpose: Get ILL quick view
        ' Input: intOption (0,1,2)
        ' Output:  DataTable, arrData, arrLabel
        ' Creator: Sondp
        Public Function GetQuickView(ByVal intOption As Integer, ByRef arrData As Object, ByRef arrLabel As Object) As DataTable
            Dim tblQuickView As New DataTable
            Dim inti As Integer
            Try
                ReDim arrData(0)
                ReDim arrLabel(0)
                arrData(0) = -1
                tblQuickView = objBCDBS.ConvertTable(objDILLLibrary.GetQuickView(intOption))
                intErrorCode = objDILLLibrary.ErrorCode
                strErrorMsg = objDILLLibrary.ErrorMsg
                If intOption > 0 Then
                    If Not tblQuickView Is Nothing Then
                        If tblQuickView.Rows.Count > 0 Then
                            ReDim arrData(tblQuickView.Rows.Count - 1)
                            ReDim arrLabel(tblQuickView.Rows.Count - 1)
                            For inti = 0 To tblQuickView.Rows.Count - 1
                                arrData(inti) = tblQuickView.Rows(inti).Item("Amount")
                                arrLabel(inti) = tblQuickView.Rows(inti).Item("Status")
                            Next
                        End If
                    End If
                End If
                GetQuickView = tblQuickView
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCSP Is Nothing Then
                        Call objBCSP.Dispose(True)
                        objBCSP = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        Call objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objDILLLibrary Is Nothing Then
                        Call objDILLLibrary.Dispose(True)
                        objDILLLibrary = Nothing
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