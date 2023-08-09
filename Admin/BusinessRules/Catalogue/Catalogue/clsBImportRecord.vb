' clsBExportRecord class
' Creator: Tuanhv
' CreatedDate: 02/08/2004
' Purpose: 
' Modified history:

Imports System
Imports eMicLibAdmin.DataAccess.Catalogue
Imports eMicLibAdmin.DataAccess.Common
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.BusinessRules.Catalogue
    Public Class clsBImportRecord
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strItemCode As String
        Private strItemLeader As String
        Private strDisplayEntry As String
        Private strCaption As String
        Private strType As String
        Private strVersion As String
        Private strDescription As String

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objBItemCollection As New clsBItemCollection
        Private objDImportRecord As New clsDImportRecord

        ' *************************************************************************************************
        ' Declare public properties
        ' *************************************************************************************************

        ' ItemCode Property
        Public Property ItemCode() As String
            Get
                ItemCode = strItemCode
            End Get
            Set(ByVal Value As String)
                strItemCode = Value
            End Set
        End Property

        ' ItemLeader Property
        Public Property ItemLeader() As String
            Get
                ItemLeader = strItemLeader
            End Get
            Set(ByVal Value As String)
                strItemLeader = Value
            End Set
        End Property

        ' DisplayEntry Property
        Public Property DisplayEntry() As String
            Get
                DisplayEntry = strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property

        ' Caption Property
        Public Property Caption() As String
            Get
                Caption = strCaption
            End Get
            Set(ByVal Value As String)
                strCaption = Value
            End Set
        End Property

        ' strType Property
        Public Property Type() As String
            Get
                Type = strType
            End Get
            Set(ByVal Value As String)
                strType = Value
            End Set
        End Property

        ' strVersion Property
        Public Property Version() As String
            Get
                Version = strVersion
            End Get
            Set(ByVal Value As String)
                strVersion = Value
            End Set
        End Property

        ' Description Property
        Public Property Description() As String
            Get
                Description = strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' Implement methods here
        ' *************************************************************************************************

        ' *************************************************************************************************
        ' Initialize method
        ' Purpose: Init all necessary objects
        ' *************************************************************************************************
        Public Sub Initialize()
            Try
                ' Init objBItemCollection object
                objBItemCollection.DBServer = strDBServer
                objBItemCollection.InterfaceLanguage = strInterfaceLanguage
                objBItemCollection.ConnectionString = strConnectionString
                Call objBItemCollection.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objDImportRecord object
                objDImportRecord.DBServer = strDBServer
                objDImportRecord.ConnectionString = strConnectionString
                Call objDImportRecord.Initialize()
            Finally
            End Try
        End Sub

        ' ImportClassfication method
        ' Purpose: import data
        ' Input: record informations
        ' Ouput: intID
        Public Function ImportClassfication() As Integer
            Try
                strDisplayEntry = objBCSP.ConvertItBack(strDisplayEntry)
                objDImportRecord.ItemCode = objBCSP.ConvertItBack(strItemCode)
                objDImportRecord.ItemLeader = strItemLeader
                objDImportRecord.DisplayEntry = strDisplayEntry
                objDImportRecord.AccessEntry = objBCSP.ProcessVal(strDisplayEntry)
                objDImportRecord.Caption = objBCSP.ConvertItBack(strCaption)
                objDImportRecord.Type = strType
                objDImportRecord.Version = strVersion
                objDImportRecord.Description = objBCSP.ConvertItBack(strDescription)
                ImportClassfication = objDImportRecord.ImportClassfication()
                strErrorMsg = objDImportRecord.ErrorMsg
                intErrorCode = objDImportRecord.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateID method
        Public Function CreateID(ByVal strTableName As String, ByVal strFieldName As String) As Long
            Dim tblID As New DataTable
            Try
                tblID = objDImportRecord.CreateID(strTableName, strFieldName)
                CreateID = CLng(tblID.Rows(0).Item(0))
                tblID.Dispose()
                tblID = Nothing
                strErrorMsg = objDImportRecord.ErrorMsg
                intErrorCode = objDImportRecord.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Generate book code
        ' Purpose: Gen itemcode for classification data
        ' Output: string value of itemcode
        Public Function Gen001() As String
            Dim lngMaxID As Long
            Dim strAbbr As String ' string of library abbreviation
            Dim strYear As String ' string of the current year (2 last digits)
            Dim strCode As String ' string of bookcode
            Dim strTemp As String
            Dim intCount As Integer
            Dim objPara() As String = {"LIBRARY_ABBREVIATION"}
            Dim objSysPara() As String
            Dim tblReserve As New DataTable

            ' Delete temp bookcode from BOOKCODE_RES table
            lngMaxID = CreateID("CLASSIFICATION", "ID")

            ' Get LibAbbr from SYS_PARAMETERS table to forming bookcode
            objSysPara = objBCDBS.GetSystemParameters(objPara)
            strAbbr = objSysPara(0)

            ' Get current year to forming bookcode
            strYear = Right(CStr(Year(Now)), 2)

            ' Forming bookcode string
            strCode = Trim(strAbbr & strYear & CStr(lngMaxID).PadLeft(7, "0"))

            ' Get data from BOOKCODE_RES table to check exist
            objDImportRecord.SQLStatement = "SELECT * FROM BOOKCODE_RES WHERE Code = '" & strCode & "'"
            tblReserve = objDImportRecord.GetData()
            While tblReserve.Rows.Count > 0 ' Exist bookcode in BOOKCODE_RES table
                lngMaxID = lngMaxID + 1
                strCode = Trim(strAbbr & strYear & CStr(lngMaxID).PadLeft(7, "0"))
                objDImportRecord.SQLStatement = "SELECT * FROM BOOKCODE_RES WHERE Code = '" & strCode & "'"
                tblReserve = objDImportRecord.GetData()
            End While

            ' Insert tmp bookcode into BOOKCODE_RES table
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    strTemp = "INSERT INTO Cat_tblBookCodeRes (Code, CreatedTime, SessionID) VALUES ('" & strCode & "', SYSDATE, 'TCL000000000')"
                Case "SQLSERVER"
                    strTemp = "INSERT INTO Cat_tblBookCodeRes (Code, CreatedTime, SessionID) VALUES ('" & strCode & "', GETDATE(), 'TCL000000000')"
            End Select

            objDImportRecord.SQLStatement = strTemp
            Call objDImportRecord.ExecuteQuery()
            Gen001 = strCode

            ' Release tblReserve
            tblReserve.Dispose()
            tblReserve = Nothing
        End Function


        ' *************************************************************************************************
        ' Dispose method
        ' Purpose: Release all resource
        ' *************************************************************************************************
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDImportRecord Is Nothing Then
                    objDImportRecord.Dispose(True)
                    objDImportRecord = Nothing
                End If
                If Not objDImportRecord Is Nothing Then
                    objDImportRecord.Dispose(True)
                    objDImportRecord = Nothing
                End If
            Finally
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
