'class:clsDOrdinalNumberChange
'purpose: set ordinal number
'creator: lent
'CreateDate: 16/2/2005
'histoty update:

Imports eMicLibAdmin.DataAccess.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.BusinessRules.Acquisition
    Public Class clsBOrdinalNumberChange
        Inherits clsBBase

        Private intLibID As Integer
        Private strStoreIDs As String
        Private strMaxNumber As String
        Private objBOrdinalNumberChange As New clsDOrdinalNumberChange
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonStringProc

        'property get LibraryID 
        Public Property LibID() As Integer
            Get
                Return (intLibID)
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        'property get StoreID
        Public Property StoreIDs() As String
            Get
                Return (strStoreIDs)
            End Get
            Set(ByVal Value As String)
                strStoreIDs = Value
            End Set
        End Property
        'get MaxNumber to update in holding_location
        Public Property MaxNumber() As String
            Get
                Return (strMaxNumber)
            End Get
            Set(ByVal Value As String)
                strMaxNumber = Value
            End Set
        End Property
        'END PROPERTYS
        '----------------------------------------------------------------------------------------------------
        'START PROCEDURES OR FUNCTIONS
        ' Init all objects
        Public Sub Initialize()
            ' Initialize objBOrdinalNumberChange object
            objBOrdinalNumberChange.ConnectionString = strconnectionstring
            objBOrdinalNumberChange.DBServer = strdbserver
            objBOrdinalNumberChange.Initialize()
            ' Initialize objBCDBS object
            objBCDBS.ConnectionString = strconnectionstring
            objBCDBS.DBServer = strdbserver
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
            ' Initialize objBCSP object
            objBCSP.ConnectionString = strconnectionstring
            objBCSP.DBServer = strdbserver
            objBCSP.InterfaceLanguage = strInterfaceLanguage
            objBCSP.Initialize()
        End Sub

        'purpose: select all fields from Library and Location where Location.LibID=Library.ID
        'in: LibID ( 0: select All )
        'out: data table
        Public Function RetrieveLibLoc() As DataTable
            Try
                objBOrdinalNumberChange.LibID = intLibID
                RetrieveLibLoc = objBCDBS.ConvertTable(objBOrdinalNumberChange.RetrieveLibLoc())
            Catch ex As Exception
                strerrormsg = objBOrdinalNumberChange.ErrorMsg
                interrorcode = objBOrdinalNumberChange.ErrorCode
            End Try
        End Function
        'purpose: Update MaxNumber ins Locaiton table
        'in: strStoreIDs, strMaxNumber
        'out: 
        Public Sub UpdateMaxNumber()
            Try
                objBOrdinalNumberChange.StoreIDs = strStoreIDs
                objBOrdinalNumberChange.MaxNumber = strMaxNumber
                Call objBOrdinalNumberChange.UpdateMaxNumber()
            Catch ex As Exception
                strerrormsg = objBOrdinalNumberChange.ErrorMsg
                interrorcode = objBOrdinalNumberChange.ErrorCode
            End Try
        End Sub
        'END PROCEDURE OR FUNCTIONS
        '----------------------------------------------------------------------------------------------------
        'DISPOSE METHODS
        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOrdinalNumberChange Is Nothing Then
                    objBOrdinalNumberChange.Dispose(True)
                    objBOrdinalNumberChange = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace