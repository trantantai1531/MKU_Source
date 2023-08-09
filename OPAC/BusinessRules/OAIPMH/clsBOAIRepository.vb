' Name: clsDRepository
' Purpose: 
' Creator: Kiemdv
' Created Date: 20/10/2004
' Modification History:

Imports System
Imports System.Data
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBRepository
        Inherits clsBBase
        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************
        Private strVerb As String
        Private strScriptName As String
        Private blnHasBadArg As Boolean
        Private strURLResource As String
        Private strFromDate As String
        Private strToDate As String
        Private strMetadataPrefix As String
        Private strIdentifier As String
        Private strOAISet As String
        Private strResumptionToken As String
        Public IDs() As Integer

        Private objDOAIRepository As New clsDOAIRepository
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private dtbLeader As DataTable
        Private dtbItem As DataTable
        '        Private dtbItem As DataTable
        '       Private dtbLeader As DataTable
        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' Verb property
        Public Property Verb() As String
            Get
                Return strVerb
            End Get
            Set(ByVal Value As String)
                strVerb = Value
            End Set
        End Property
        ' ScriptName property 
        Public Property ScriptName() As String
            Get
                Return strScriptName
            End Get
            Set(ByVal Value As String)
                strScriptName = Value
            End Set
        End Property
        ' HasBadArg property 
        Property HasBadArg() As Boolean
            Get
                Return blnHasBadArg
            End Get
            Set(ByVal Value As Boolean)
                blnHasBadArg = Value
            End Set
        End Property
        ' URLResource Property
        Public Property URLResource() As String
            Get
                Return strURLResource
            End Get
            Set(ByVal Value As String)
                strURLResource = Value
            End Set
        End Property

        ' FromDate Property
        Public Property FromDate() As String
            Get
                Return strFromDate
            End Get
            Set(ByVal Value As String)
                strFromDate = Value
            End Set
        End Property

        ' ToDate Property
        Public Property ToDate() As String
            Get
                Return strToDate
            End Get
            Set(ByVal Value As String)
                strToDate = Value
            End Set
        End Property

        ' MetadataPrefix Property
        Public Property MetadataPrefix() As String
            Get
                Return strMetadataPrefix
            End Get
            Set(ByVal Value As String)
                strMetadataPrefix = Value
            End Set
        End Property

        ' Identifier Property
        Public Property Identifier()
            Get
                Return strIdentifier
            End Get
            Set(ByVal Value)
                strIdentifier = Value
            End Set
        End Property

        ' OAISet Property
        Public Property OAISet() As String
            Get
                Return strOAISet
            End Get
            Set(ByVal Value As String)
                strOAISet = Value
            End Set
        End Property

        ' ResumptionToken Property
        Public Property ResumptionToken() As String
            Get
                Return strResumptionToken
            End Get
            Set(ByVal Value As String)
                strResumptionToken = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOAIRepository object
            objDOAIRepository.DBServer = strDBServer
            objDOAIRepository.ConnectionString = strConnectionString
            objDOAIRepository.Initialize()

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
        End Sub

        ' PrintHeader function
        Private Function PrintHeader() As String
            Dim strResult As String = ""
            strResult = strResult & "<?xml version=""1.0"" encoding=""UTF-8""?>"
            strResult = strResult & "<OAI-PMH xmlns=""http://www.openarchives.org/OAI/2.0/"" "
            strResult = strResult & "         xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"""
            strResult = strResult & "         xsi:schemaLocation=""http://www.openarchives.org/OAI/2.0/"
            strResult = strResult & "         http://www.openarchives.org/OAI/2.0/OAI-PMH.xsd"">"
            strResult = strResult & "      <responseDate>" & Year(Now) & "-" & StrDup(2 - Len(CStr(Month(Now))), "0") & Month(Now)
            strResult = strResult & "-" & StrDup(2 - Len(CStr(Day(Now))), "0") & Day(Now) & "T"
            strResult = strResult & StrDup(2 - Len(CStr(Hour(Now))), "0") & Hour(Now) & ":"
            strResult = strResult & StrDup(2 - Len(CStr(Minute(Now))), "0") & Minute(Now) & ":"
            strResult = strResult & StrDup(2 - Len(CStr(Second(Now))), "0") & Second(Now) & "Z</responseDate>"
            Return strResult
        End Function

        ' PrintTrailer function
        Private Function PrintTrailer() As String
            PrintTrailer = "</OAI-PMH>"
        End Function

        ' ErrorResponse function
        Private Function ErrorResponse(ByVal strErrCode As String, ByVal strRequest As String, ByVal strVerb As String) As String
            Dim strResult As String = ""
            ' Dictionary of error codes            
            Dim colErrDict As New Collection
            colErrDict.Add(" The request includes illegal arguments, is missing required arguments, includes a repeated argument, or values for arguments have an illegal syntax.", "badArgument")
            colErrDict.Add("The value of the resumptionToken argument is invalid or expired", "badResumptionToken")
            colErrDict.Add(" Value of the verb argument is not a legal OAI-PMH verb, the verb argument is missing, or the verb argument is repeated", "badVerb")
            colErrDict.Add(" The metadata format identified by the value given for the metadataPrefix argument is not supported by the item or by the repository", "cannotDisseminateFormat")
            colErrDict.Add("The value of the identifier argument is unknown or illegal in this repository", "idDoesNotExist")
            colErrDict.Add("The combination of the values of the from, until, set and metadataPrefix arguments results in an empty list", "noRecordsMatch")
            colErrDict.Add("There are no metadata formats available for the specified item", "noMetadataFormats")
            colErrDict.Add("The repository does not support sets", "noSetHierarchy")
            'strResult = strResult & PrintHeader()
            If Not strErrCode = "badVerb" Then
                strResult = strResult & "<request verb=""" & Verb & """>" & strRequest & "</request>" & vbCrLf
            Else
                strResult = strResult & "<request>" & strRequest & "</request>" & vbCrLf
            End If
            strResult = strResult & "<error code=""" & strErrCode & """>" & colErrDict(strErrCode) & "</error>"
            'strResult = strResult & PrintTrailer()
            Return strResult
        End Function

        ' GetRecord method
        ' Purpose: Get Record
        ' Input: some main infor: , ...
        ' Output: DataTable
        Public Function GetRecord() As String
            Dim strResult As String = ""
            Dim strServerAddr As String = ""
            Dim dtbSystem As DataTable
            Dim arrPara() As String = {"SERVER_IP_ADDRESS"}
            Dim arrRet()
            arrRet = objBCDBS.GetSystemParameters(arrPara)
            If UBound(arrRet) >= 0 Then
                strServerAddr = arrRet(0)
            End If
            Select Case strVerb
                Case "Identify"
                    Return Identify("http://" & strServerAddr & strScriptName, "http://" & strServerAddr & Left(strScriptName, InStrRev(strScriptName, "/") - 1))
                Case "ListMetadataFormats"
                    Return ListMetadataFormats("http://" & strServerAddr & strScriptName, strIdentifier)
                Case "ListSets"
                    Return ListSets("http://" & strServerAddr & strScriptName)
                Case "ListIdentifiers"
                    Return Listing("http://" & strServerAddr & strScriptName, "ListIdentifiers")
                Case "ListRecords"
                    Return Listing("http://" & strServerAddr & strScriptName, "ListRecords")
                Case "GetRecord"
                    Return GetRecord("http://" & strServerAddr & strScriptName, strIdentifier, strMetadataPrefix)
                Case Else
                    strResult = strResult & PrintHeader()
                    strResult = strResult & ErrorResponse("badVerb", "http://" & strServerAddr & strScriptName, "")
                    strResult = strResult & PrintTrailer()
                    Return strResult
            End Select
            dtbSystem.Dispose()
            dtbSystem = Nothing
        End Function

        ' Identify function
        Private Function Identify(ByVal strURL As String, ByVal strBaseURL As String) As String
            Dim strResult As String = ""
            If blnHasBadArg Then
                strResult = strResult & ErrorResponse("badArgument", strURL, "")
            Else
                strResult = strResult & PrintHeader()
                strResult = strResult & "<request verb=""Identify"">" & strURL & "</request>"
                strResult = strResult & "<Identify>"
                strResult = strResult & "<repositoryName>eMicLib 60 libliographic database</repositoryName>"
                strResult = strResult & "<baseURL>" & strBaseURL & "</baseURL>"
                strResult = strResult & "<protocolVersion>2.0</protocolVersion>"
                Dim arrPara() As String = {"ADMIN_EMAIL_ADDRESS"}
                Dim arrRet()
                arrRet = objBCDBS.GetSystemParameters(arrPara)
                If UBound(arrRet) >= 0 Then
                    strResult = strResult & "<adminEmail>" & arrRet(0) & "</adminEmail>"
                End If
                Dim dtbItem As DataTable
                If UCase(strDBServer) = "SQLSERVER" Then
                    objBCDBS.SQLStatement = "SELECT  Min(CreatedDate) AS CreatedDate FROM Item"
                Else
                    objBCDBS.SQLStatement = "SELECT  To_Char(Min(CreatedDate), ""mm/dd/yyyy hh24:mi:ss"")  AS CreatedDate FROM Item"
                End If
                dtbItem = objBCDBS.RetrieveItemInfor(False)
                Dim dtmTransactionDate As DateTime
                Dim strEarliestDatestamp As String = ""
                If dtbItem.Rows.Count > 0 Then
                    dtmTransactionDate = dtbItem.Rows(0).Item("CREATEDDATE")
                    strEarliestDatestamp = Year(dtmTransactionDate) & "-"
                    strEarliestDatestamp = strEarliestDatestamp & StrDup(2 - Len(CStr(Month(dtmTransactionDate))), "0")
                    strEarliestDatestamp = strEarliestDatestamp & Month(dtmTransactionDate) & "-"
                    strEarliestDatestamp = strEarliestDatestamp & StrDup(2 - Len(CStr(Day(dtmTransactionDate))), "0")
                    strEarliestDatestamp = strEarliestDatestamp & Day(dtmTransactionDate) & "T"
                    strEarliestDatestamp = strEarliestDatestamp & StrDup(2 - Len(CStr(Hour(dtmTransactionDate))), "0")
                    strEarliestDatestamp = strEarliestDatestamp & Hour(dtmTransactionDate) & ":"
                    strEarliestDatestamp = strEarliestDatestamp & StrDup(2 - Len(CStr(Minute(dtmTransactionDate))), "0")
                    strEarliestDatestamp = strEarliestDatestamp & Minute(dtmTransactionDate) & ":"
                    strEarliestDatestamp = strEarliestDatestamp & StrDup(2 - Len(CStr(Second(dtmTransactionDate))), "0")
                    strEarliestDatestamp = strEarliestDatestamp & Second(dtmTransactionDate) & "Z"
                End If
                strResult = strResult & "<strEarliestDatestamp>" & strEarliestDatestamp & "</strEarliestDatestamp>"
                strResult = strResult & "<deletedRecord>no</deletedRecord>"
                strResult = strResult & "<granularity>YYYY-MM-DDThh:mm:ssZ</granularity>"
                strResult = strResult & "</Identify>"
                strResult = strResult & PrintTrailer()
            End If
            Return strResult
        End Function

        ' ListMetadataFormats function
        Private Function ListMetadataFormats(ByVal URL As String, ByVal strRecID As String) As String
            Dim strRequestLine As String
            Dim strResult As String = ""
            strRequestLine = """ListMetadataFormats"""
            If Not strRecID = "" Then
                strRequestLine = strRequestLine & " identifier=""" & strRecID & """"
            End If
            If blnHasBadArg Then
                strResult = strResult & PrintHeader()
                strResult = strResult & ErrorResponse("badArgument", URL, strRequestLine)
                strResult = strResult & PrintTrailer()
                Return strResult
            End If
            Dim dtbItem As DataTable
            If strRecID <> "" Then
                objBCDBS.SQLStatement = "SELECT ID FROM Item WHERE Code = '" & strRecID & "'"
                dtbItem = objBCDBS.RetrieveItemInfor
                If dtbItem.Rows.Count = 0 Then
                    strResult = strResult & PrintHeader()
                    strResult = strResult & ErrorResponse("idDoesNotExist", URL, strRequestLine)
                    strResult = strResult & PrintTrailer()
                    Return strResult
                End If
            End If
            strResult = strResult & PrintHeader()
            strResult = strResult & "<request verb=" & strRequestLine & ">" & URL & "</request>"
            strResult = strResult & "<ListMetadataFormats>"
            strResult = strResult & "<metadataFormat>"
            strResult = strResult & "<metadataPrefix>oai_dc</metadataPrefix>"
            strResult = strResult & "<schema>http://www.openarchives.org/OAI/2.0/oai_dc.xsd</schema>"
            strResult = strResult & "<metadataNamespace>http://www.openarchives.org/OAI/2.0/oai_dc/</metadataNamespace>"
            strResult = strResult & "</metadataFormat>"
            strResult = strResult & "</ListMetadataFormats>"
            strResult = strResult & PrintTrailer()
            Return strResult
        End Function

        ' ListSets function
        Private Function ListSets(ByVal strURL As String) As String
            Dim dtbOAISet As DataTable
            Dim strResult As String = ""
            objBCDBS.SQLStatement = "SELECT * FROM OAI_Set ORDER BY SetSpec"
            dtbOAISet = objBCDBS.RetrieveItemInfor
            strResult = strResult & PrintHeader()
            If dtbOAISet.Rows.Count = 0 Then
                strResult = strResult & ErrorResponse("noSetHierarchy", strURL, "ListSets")
            Else
                If blnHasBadArg Then
                    strResult = strResult & ErrorResponse("noSetHierarchy", strURL, "ListSets")
                End If
                If Not strResumptionToken = "" Then
                    strResult = strResult & ErrorResponse("badResumptionToken", strURL, "ListSets")
                End If
                strResult = strResult & "<request verb=""ListSets"">" & strURL & "</request>"
                strResult = strResult & "<ListSets>"
                Dim i As Integer
                For i = 0 To dtbOAISet.Rows.Count - 1
                    strResult = strResult & "<set>"
                    strResult = strResult & "<setSpec>" & dtbOAISet.Rows(i).Item("SetSpec") & "</setSpec>"
                    strResult = strResult & "<setName>" & dtbOAISet.Rows(i).Item("SetName") & "</setName>"
                    strResult = strResult & "</set>"
                Next
                strResult = strResult & "</ListSets>"
            End If
            strResult = strResult & PrintTrailer()
            Return strResult
        End Function

        ' Listing Function
        Private Function Listing(ByVal strURL As String, ByVal strVerb As String) As String
            Dim strRequestLine As String
            Dim strResult As String
            strRequestLine = strVerb
            If strFromDate <> "" Then
                strRequestLine = strRequestLine & """ from=""" & strFromDate
            End If
            If strToDate <> "" Then
                strRequestLine = strRequestLine & """ until=""" & strToDate
            End If
            strRequestLine = strRequestLine & """ metadataPrefix=""oai_dc"
            If blnHasBadArg Then
                strResult = strResult & PrintHeader()
                strResult = strResult & ErrorResponse("badArgument", strURL, strRequestLine)
                strResult = strResult & PrintTrailer()
                Return strResult
            End If
            If Not strMetadataPrefix = "oai_dc" And strResumptionToken = "" Then
                strResult = strResult & PrintHeader()
                strResult = strResult & ErrorResponse("cannotDisseminateFormat", strURL, strRequestLine)
                strResult = strResult & PrintTrailer()
                Return strResult
            End If
            Dim dtbItem As DataTable
            If Not strOAISet = "" Then
                objBCDBS.SQLStatement = "SELECT * FROM OAI_Set"
                dtbItem = objBCDBS.RetrieveItemInfor
                If dtbItem.Rows.Count = 0 Then
                    strResult = strResult & PrintHeader()
                    strResult = strResult & ErrorResponse("noSetHierarchy", strURL, strRequestLine)
                    strResult = strResult & PrintTrailer()
                    Return strResult
                End If
            End If
            Dim strSql As String
            Dim lngStart As Long
            Dim SessionID
            Dim MaxID As Integer
            Dim i As Integer
            If strResumptionToken = "" Then
                strSql = ""
                objDOAIRepository.OAISet = strOAISet & ""
                objDOAIRepository.FromDate = strFromDate & ""
                objDOAIRepository.ToDate = strToDate & ""
                dtbItem = objDOAIRepository.GetItemByOAI
                If dtbItem.Rows.Count > 0 Then
                    If dtbItem.Rows.Count > 1000 Then
                        MaxID = 999
                    Else
                        MaxID = dtbItem.Rows.Count - 1
                    End If
                    ReDim IDs(MaxID)
                    For i = 0 To MaxID
                        IDs(i) = dtbItem.Rows(i).Item("ID")
                    Next
                Else
                    strResult = strResult & PrintHeader()
                    strResult = strResult & ErrorResponse("noRecordsMatch", strURL, strRequestLine)
                    strResult = strResult & PrintTrailer()
                    Return strResult
                End If
                ' SessionID = Session.SessionID
                ' Application(SessionID & "OAIIDs") = IDs
                lngStart = 0
            Else
                ' SessionID = Left(strResumptionToken, InStr(strResumptionToken, "pos") - 1)
                ' Application(SessionID & "OAIIDs")
                If Not IsArray(IDs) Then
                    strResult = strResult & PrintHeader()
                    strResult = strResult & ErrorResponse("badResumptionToken" & SessionID & "OAIIDs", strURL, strRequestLine)
                    strResult = strResult & PrintTrailer()
                    Return strResult
                End If
                lngStart = Right(strResumptionToken, Len(strResumptionToken) - InStr(strResumptionToken, "pos") - 2)
                ' Application(SessionID & "OAIIDs")
                If Not IsNumeric(lngStart) Or CLng(lngStart) > UBound(IDs) Then
                    strResult = strResult & PrintHeader()
                    strResult = strResult & ErrorResponse("badResumptionToken2", strURL, strRequestLine)
                    strResult = strResult & PrintTrailer()
                    Return strResult
                End If
            End If
            strResult = strResult & PrintHeader()
            strResult = strResult & "<request verb=""" & strRequestLine & """>" & strURL & "</request>"
            If strVerb = "ListRecords" Then
                strResult = strResult & "<ListRecords>"
            Else
                strResult = strResult & "<ListIdentifiers>"
            End If
            ' Application(SessionID & "OAIIDs")           
            Dim intMAX As Integer = 100
            strResult = strResult & GET_DCXML(IDs, lngStart, intMAX, strVerb, SessionID)
            If strVerb = "ListRecords" Then
                strResult = strResult & "</ListRecords>"
            Else
                strResult = strResult & "</ListIdentifiers>"
            End If
            strResult = strResult & PrintTrailer()
            Return strResult
        End Function

        ' GetRecord Function
        Private Function GetRecord(ByVal URL As String, ByVal strRecID As String, ByVal strMetadataPrefix As String) As String
            Dim strRequestLine As String
            Dim strResult As String = ""
            strRequestLine = """GetRecord"" identifier=""" & strRecID & """ metadataPrefix=""" & strMetadataPrefix & """"
            If blnHasBadArg Then
                strResult = strResult & PrintHeader()
                strResult = strResult & ErrorResponse("badArgument", URL, strRequestLine)
                strResult = strResult & PrintTrailer()
                Return strResult
            End If
            If strRecID = "" Or strMetadataPrefix = "" Then
                strResult = strResult & PrintHeader()
                strResult = strResult & ErrorResponse("badArgument", URL, strRequestLine)
                strResult = strResult & PrintTrailer()
                Return strResult
            End If
            If Not strMetadataPrefix = "oai_dc" Then
                strResult = strResult & PrintHeader()
                strResult = strResult & ErrorResponse("cannotDisseminateFormat", URL, strRequestLine)
                strResult = strResult & PrintTrailer()
                Return strResult
            End If
            Dim dtbItem As DataTable
            objBCDBS.SQLStatement = "SELECT ID FROM Item WHERE Code = '" & strRecID & "'"
            dtbItem = objBCDBS.RetrieveItemInfor
            If dtbItem.Rows.Count = 0 Then
                strResult = strResult & PrintHeader()
                strResult = strResult & ErrorResponse("idDoesNotExist", URL, strRequestLine)
                strResult = strResult & PrintTrailer()
                Return strResult
            End If
            Dim dblRecID As Double
            dblRecID = dtbItem.Rows(0).Item("ID")
            ' Goi ham lay du lieu vao 2 bang Item va Leader
            Call GetDCVals(dblRecID, "GetRecord")
            strResult = strResult & PrintHeader()
            strResult = strResult & "<request verb=" & strRequestLine & ">" & URL & "</request>"
            strResult = strResult & "<GetRecord>"
            strResult = strResult & DisplayRecord("GetRecord")
            strResult = strResult & "</GetRecord>"
            strResult = strResult & PrintTrailer()
            Return strResult
        End Function

        ' GetDCVals sub
        Private Sub GetDCVals(ByVal strIDs As String, ByVal strVerb As String)
            If strVerb = "ListRecords" Or strVerb = "GetRecord" Then
                objDOAIRepository.IDs = strIDs
                dtbItem = objBCDBS.ConvertTable(objDOAIRepository.GetOAIItemInfor)
            End If
            objDOAIRepository.IDs = strIDs
            dtbLeader = objBCDBS.ConvertTable(objDOAIRepository.GetOAIItemLeader)
        End Sub

        ' GET_DCXML function
        Private Function GET_DCXML(ByVal DocID() As Integer, ByVal intStartID As Integer, ByVal intPageSize As Integer, ByVal strVerb As String, ByVal SessionID As Integer) As String
            Dim dtvLeader As DataView
            Dim dtvItem As DataView
            Dim XMLStream As String
            Dim StrDocID As String
            Dim j As Integer
            For j = intStartID To intStartID + intPageSize
                If j > UBound(DocID) Then
                    Exit For
                End If
                StrDocID = StrDocID & DocID(j) & ", "
            Next
            StrDocID = Left(StrDocID, Len(StrDocID) - 2)
            ' Goi ham lay du lieu vao 2 bang Item va Leader
            Call GetDCVals(StrDocID, strVerb)
            If strVerb = "ListIdentifiers" Then
                dtvLeader = dtbLeader.DefaultView
                For j = intStartID To intStartID + intPageSize
                    If j > UBound(DocID) Then
                        Exit For
                    End If
                    dtvLeader.RowFilter = "ID = " & DocID(j)
                    If dtvLeader.Count > 0 Then
                        XMLStream = XMLStream & DisplayListIdentifiers(dtvLeader, "ListIdentifiers")
                    End If
                Next
            ElseIf strVerb = "ListRecords" Then
                dtvLeader = dtbLeader.DefaultView
                dtvItem = dtbItem.DefaultView
                For j = intStartID To intStartID + intPageSize
                    If j > UBound(DocID) Then
                        Exit For
                    End If
                    dtvLeader.RowFilter = "ID = " & DocID(j)
                    'dtvItem.RowFilter = "ID = " & DocID(j) --2023.06.26 B1
                    dtvItem.RowFilter = "ItemID = " & DocID(j)
                    '--2023.06.26 E1
                    If dtvLeader.Count > 0 Then
                        XMLStream = XMLStream & DisplayListRecords(dtvLeader, dtvItem, "ListRecords")
                    End If
                Next
            End If
            Dim ExpDate As Date
            If intStartID + intPageSize < UBound(DocID) Then
                ExpDate = DateAdd("n", 20, Now)
                XMLStream = XMLStream & "<resumptionToken expirationDate=""" & Year(ExpDate) & "-"
                XMLStream = XMLStream & StrDup(2 - Len(CStr(Month(ExpDate))), "0") & Month(ExpDate) & "-"
                XMLStream = XMLStream & StrDup(2 - Len(CStr(Day(ExpDate))), "0") & Day(ExpDate) & "T"
                XMLStream = XMLStream & StrDup(2 - Len(CStr(Hour(ExpDate))), "0") & Hour(ExpDate) & ":"
                XMLStream = XMLStream & StrDup(2 - Len(CStr(Minute(ExpDate))), "0") & Minute(ExpDate) & ":"
                XMLStream = XMLStream & StrDup(2 - Len(CStr(Second(ExpDate))), "0") & Second(ExpDate)
                XMLStream = XMLStream & "Z"" completeListSize=""" & (UBound(DocID) + 1) & """ cursor="""
                XMLStream = XMLStream & intStartID & """>" & SessionID & "pos"
                XMLStream = XMLStream & (intStartID + intPageSize + 1) & "</resumptionToken>" & Chr(13)
            End If
            XMLStream = Replace(XMLStream, "&", "&amp;")
            GET_DCXML = XMLStream
        End Function

        ' DisplayListIdentifiers function
        Private Function DisplayListIdentifiers(ByVal dtvLeader As DataView, ByVal strVerb As String) As String
            Dim i, j As Integer
            Dim XMLStream As String
            Dim strDateStamp As String
            Dim dtmTransactionDate As Date
            dtmTransactionDate = CDate(dtvLeader.Item(0).Item("CreatedDate_"))
            strDateStamp = Year(dtmTransactionDate) & "-" & StrDup(2 - Len(CStr(Month(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Month(dtmTransactionDate) & "-" & StrDup(2 - Len(CStr(Day(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Day(dtmTransactionDate) & "T" & StrDup(2 - Len(CStr(Hour(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Hour(dtmTransactionDate) & ":" & StrDup(2 - Len(CStr(Minute(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Minute(dtmTransactionDate) & ":" & StrDup(2 - Len(CStr(Second(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Second(dtmTransactionDate) & "Z"
            If strVerb = "ListIdentifiers" Then
                XMLStream = XMLStream & "<header>" & Chr(13) & "<identifier>" & dtvLeader.Item(0).Item("Code")
                XMLStream = XMLStream & "</identifier>" & Chr(13) & "<datestamp>" & strDateStamp & "</datestamp>"
                XMLStream = XMLStream & Chr(13) & "</header>" & Chr(13)
            End If
            DisplayListIdentifiers = XMLStream
        End Function

        ' DisplayListRecords function
        Private Function DisplayListRecords(ByVal dtvLeader As DataView, ByVal dtvItem As DataView, ByVal strVerb As String) As String
            Dim i, j As Integer
            Dim XMLStream As String
            Dim SubRecords() As Object
            Dim strDateStamp As String
            Dim dtmTransactionDate As Date
            dtmTransactionDate = CDate(dtvLeader.Item(0).Item("CreatedDate_"))
            strDateStamp = Year(dtmTransactionDate) & "-" & StrDup(2 - Len(CStr(Month(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Month(dtmTransactionDate) & "-" & StrDup(2 - Len(CStr(Day(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Day(dtmTransactionDate) & "T" & StrDup(2 - Len(CStr(Hour(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Hour(dtmTransactionDate) & ":" & StrDup(2 - Len(CStr(Minute(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Minute(dtmTransactionDate) & ":" & StrDup(2 - Len(CStr(Second(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Second(dtmTransactionDate) & "Z"
            XMLStream = XMLStream & "<record>" & Chr(13) & "<header>" & Chr(13) & "<identifier>"
            XMLStream = XMLStream & dtvLeader.Item(0).Item("Code") & "</identifier>"
            XMLStream = XMLStream & Chr(13) & "<datestamp>" & strDateStamp & "</datestamp>" & Chr(13)
            XMLStream = XMLStream & "</header>" & Chr(13) & "<metadata>" & Chr(13) & "<oai_dc:dc "
            XMLStream = XMLStream & Chr(13) & "          xmlns:oai_dc=""http://www.openarchives.org/OAI/2.0/oai_dc/"" "
            XMLStream = XMLStream & Chr(13) & "          xmlns:dc=""http://purl.org/dc/elements/1.1/"" "
            XMLStream = XMLStream & Chr(13) & "          xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" "
            XMLStream = XMLStream & Chr(13) & "          xsi:schemaLocation=""http://www.openarchives.org/OAI/2.0/oai_dc/ "
            XMLStream = XMLStream & Chr(13) & "          http://www.openarchives.org/OAI/2.0/oai_dc.xsd"">" & Chr(13)
            If dtvItem.Count > 0 Then
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 245 Then
                        XMLStream = XMLStream & "<dc:title>"
                        ' TheDisplayOne(TrimSubFieldCodes(ConvertIt
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content")))
                        XMLStream = XMLStream & "</dc:title>" & Chr(13)
                    End If
                Next
                For i = 0 To dtvItem.Count - 1
                    Select Case CInt(dtvItem.Item(i).Item("FieldCode"))
                        '311, 329, 346, 1398, 1442, 1467, 1507
                        Case 100
                            XMLStream = XMLStream & "<dc:creator>"
                            XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content")))
                            XMLStream = XMLStream & "</dc:creator>" & Chr(13)
                    End Select
                Next
                For i = 0 To dtvItem.Count - 1
                    Select Case CInt(dtvItem.Item(i).Item("FieldCode"))
                        '1205, 1234, 1262, 1288, 1311, 1341
                        Case 650
                            XMLStream = XMLStream & "<dc:subject>"
                            XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content")))
                            XMLStream = XMLStream & "</dc:subject>" & Chr(13)
                        Case 653
                            XMLStream = XMLStream & "<dc:subject>"
                            XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content")))
                            XMLStream = XMLStream & "</dc:subject>" & Chr(13)
                    End Select
                Next
                For i = 0 To dtvItem.Count - 1
                    Select Case CInt(dtvItem.Item(i).Item("FieldCode"))
                        ' 805, 814, 819, 823, 826, 831, 848, 853, 857, 865, 869, 872
                        Case 500
                            XMLStream = XMLStream & "<dc:description>"
                            XMLStream = XMLStream & Replace(Replace(Trim(objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content"))), "<", "("), ">", ")")
                            XMLStream = XMLStream & "</dc:description>" & Chr(13)
                    End Select
                Next
                'Contributor = NULL
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 260 Then
                        'Call ParseField("$a,$b,$c", dtvItem.Item(i).Item("Content"), "nc ", SubRecords)
                        objBCSP.ParseField("$a,$b,$c", dtvItem.Item(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            'Dim strpub As String = SubRecords(1).ToString().Trim()
                            'If strpub.EndsWith(" ,") Then
                            '    strpub = strpub.Substring(0, strpub.Length - 2)
                            'End If
                            XMLStream = XMLStream & "<dc:publisher>"
                            ' ConvertIt(
                            XMLStream = XMLStream & Trim(SubRecords(0) & SubRecords(1).ToString().Replace(" ,", ","))
                            XMLStream = XMLStream & "</dc:publisher>" & Chr(13)
                        End If
                        If Not SubRecords(2) = "" Then
                            XMLStream = XMLStream & "<dc:date>"
                            ' ConvertIt(
                            XMLStream = XMLStream & Trim(SubRecords(2))
                            XMLStream = XMLStream & "</dc:date>" & Chr(13)
                        End If
                    End If
                Next
                Dim strType As String = ""
                Select Case Mid(dtbLeader.Rows(0).Item("Leader"), 7, 1)
                    Case "a", "c", "d", "t"
                        'strType = "text"
                        strType = "Book"
                    Case "e", "f", "g", "k"
                        strType = "image"
                    Case "m", "o", "p", "r"
                        strType = "no type provided"
                    Case Else
                        Select Case Mid(dtbLeader.Rows(0).Item("Leader"), 8, 1)
                            Case "c", "s", "p"
                                strType = "collection"
                        End Select
                End Select
                XMLStream = XMLStream & "<dc:type>"
                XMLStream = XMLStream & strType
                XMLStream = XMLStream & "</dc:type>" & Chr(13)
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 655 Then
                        XMLStream = XMLStream & "<dc:type>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content")))
                        XMLStream = XMLStream & "</dc:type>" & Chr(13)
                    End If
                Next
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 856 Then
                        'Call ParseField("$q,$u", dtvItem.Item(i).Item("Content"), "nc ", SubRecords)
                        objBCSP.ParseField("$q,$u", dtvItem.Item(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Then
                            XMLStream = XMLStream & "<dc:format>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(0)
                            XMLStream = XMLStream & "</dc:format>" & Chr(13)
                        End If
                        If Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:identifier>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(1)
                            XMLStream = XMLStream & "</dc:identifier>" & Chr(13)
                        End If
                        If Not SubRecords(2) = "" Then
                            objDOAIRepository.File = SubRecords(2).ToString()
                            Dim dtbIden As DataTable
                            dtbIden = objBCDBS.ConvertTable(objDOAIRepository.GetIdentifier)
                            If Not dtbIden Is Nothing AndAlso dtbIden.Rows.Count = 1 Then
                                XMLStream = XMLStream & "<dc:identifier>"
                                XMLStream = XMLStream & dtbIden.Rows(0).Item("Url")
                                XMLStream = XMLStream & "</dc:identifier>" & Chr(13)
                            End If
                        End If
                    End If
                Next
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 786 Then
                        'Call ParseField("$o,$t", dtvItem.Item(i).Item("Content"), "nc ", SubRecords)
                        objBCSP.ParseField("$q,$u", dtvItem.Item(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:source>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(0) & SubRecords(1)
                            XMLStream = XMLStream & "</dc:source>" & Chr(13)
                        End If
                    End If
                Next
                For i = 0 To dtvItem.Count - 1
                    Select Case CInt(dtvItem.Item(i).Item("FieldCode"))
                        Case 8
                            XMLStream = XMLStream & "<dc:language>"
                            XMLStream = XMLStream & Mid(dtvItem.Item(i).Item("Content"), 36, 3)
                            XMLStream = XMLStream & "</dc:language>" & Chr(13)
                        Case 546
                            XMLStream = XMLStream & "<dc:language>"
                            XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content"))
                            XMLStream = XMLStream & "</dc:language>" & Chr(13)
                    End Select
                Next
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 530 Then
                        XMLStream = XMLStream & "<dc:relation>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content"))
                        XMLStream = XMLStream & "</dc:relation>" & Chr(13)
                    End If
                    If (CInt(Left(dtvItem.Item(i).Item("FieldCode"), 3)) >= 760 And CInt(Left(dtvItem.Item(i).Item("FieldCode"), 3)) <= 787) Then
                        'Call ParseField("$o,$t", dtvItem.Item(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:relation>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(0) & SubRecords(1)
                            XMLStream = XMLStream & "</dc:relation>" & Chr(13)
                        End If
                    End If
                Next
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 651 Or CInt(dtvItem.Item(i).Item("FieldCode")) = 752 Then
                        XMLStream = XMLStream & "<dc:coverage>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content"))
                        XMLStream = XMLStream & "</dc:coverage>" & Chr(13)
                    End If
                Next
                For i = 0 To dtvItem.Count - 1
                    If CInt(dtvItem.Item(i).Item("FieldCode")) = 540 Or CInt(dtvItem.Item(i).Item("FieldCode")) = 506 Then
                        XMLStream = XMLStream & "<dc:rights>"
                        ' ConvertIt(
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtvItem.Item(i).Item("Content"))
                        XMLStream = XMLStream & "</dc:rights>" & Chr(13)
                    End If
                Next
            End If
            XMLStream = XMLStream & "</oai_dc:dc>" & Chr(13) & "</metadata>"
            XMLStream = XMLStream & Chr(13) & " </record>" & Chr(13)
            DisplayListRecords = XMLStream
        End Function

        ' DisplayRecord function
        Private Function DisplayRecord(ByVal strVerb As String) As String
            Dim i, j As Integer
            Dim XMLStream As String
            Dim SubRecords() As Object
            Dim strDateStamp As String
            Dim dtmTransactionDate As Date
            dtmTransactionDate = CDate(dtbLeader.Rows(0).Item("CreatedDate_"))
            strDateStamp = Year(dtmTransactionDate) & "-" & StrDup(2 - Len(CStr(Month(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Month(dtmTransactionDate) & "-" & StrDup(2 - Len(CStr(Day(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Day(dtmTransactionDate) & "T" & StrDup(2 - Len(CStr(Hour(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Hour(dtmTransactionDate) & ":" & StrDup(2 - Len(CStr(Minute(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Minute(dtmTransactionDate) & ":" & StrDup(2 - Len(CStr(Second(dtmTransactionDate))), "0")
            strDateStamp = strDateStamp & Second(dtmTransactionDate) & "Z"
            XMLStream = XMLStream & "<record>" & Chr(13) & "<header>" & Chr(13) & "<identifier>"
            XMLStream = XMLStream & dtbLeader.Rows(0).Item("Code") & "</identifier>"
            XMLStream = XMLStream & Chr(13) & "<datestamp>" & strDateStamp & "</datestamp>" & Chr(13)
            XMLStream = XMLStream & "</header>" & Chr(13) & "<metadata>" & Chr(13) & "<oai_dc:dc "
            XMLStream = XMLStream & Chr(13) & "          xmlns:oai_dc=""http://www.openarchives.org/OAI/2.0/oai_dc/"" "
            XMLStream = XMLStream & Chr(13) & "          xmlns:dc=""http://purl.org/dc/elements/1.1/"" "
            XMLStream = XMLStream & Chr(13) & "          xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" "
            XMLStream = XMLStream & Chr(13) & "          xsi:schemaLocation=""http://www.openarchives.org/OAI/2.0/oai_dc/ "
            XMLStream = XMLStream & Chr(13) & "          http://www.openarchives.org/OAI/2.0/oai_dc.xsd"">" & Chr(13)
            If dtbItem.Rows.Count > 0 Then
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 245 Then
                        XMLStream = XMLStream & "<dc:title>"
                        ' TheDisplayOne(TrimSubFieldCodes(ConvertIt
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content")))
                        XMLStream = XMLStream & "</dc:title>" & Chr(13)
                    End If
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    Select Case CInt(dtbItem.Rows(i).Item("FieldCode"))
                        '311, 329, 346, 1398, 1442, 1467, 1507
                        Case 100
                            XMLStream = XMLStream & "<dc:creator>"
                            XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content")))
                            XMLStream = XMLStream & "</dc:creator>" & Chr(13)
                    End Select
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    Select Case CInt(dtbItem.Rows(i).Item("FieldCode"))
                        '1205, 1234, 1262, 1288, 1311, 1341
                        Case 653
                            XMLStream = XMLStream & "<dc:subject>"
                            XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content")))
                            XMLStream = XMLStream & "</dc:subject>" & Chr(13)
                    End Select
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    Select Case CInt(dtbItem.Rows(i).Item("FieldCode"))
                        ' 805, 814, 819, 823, 826, 831, 848, 853, 857, 865, 869, 872
                        Case 500
                            XMLStream = XMLStream & "<dc:description>"
                            XMLStream = XMLStream & Replace(Replace(objBCSP.TrimSubFieldCodes(Trim(dtbItem.Rows(i).Item("Content"))), "<", "("), ">", ")")
                            XMLStream = XMLStream & "</dc:description>" & Chr(13)
                    End Select
                Next
                'Contributor = NULL
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 260 Then
                        'Call ParseField("$a,$b,$c", dtbItem.Rows(i).Item("Content"), "nc ", SubRecords)
                        objBCSP.ParseField("$a,$b,$c", dtbItem.Rows(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:publisher>"
                            ' ConvertIt(
                            XMLStream = XMLStream & Trim(SubRecords(0) & SubRecords(1))
                            XMLStream = XMLStream & "</dc:publisher>" & Chr(13)
                        End If
                        If Not SubRecords(2) = "" Then
                            XMLStream = XMLStream & "<dc:date>"
                            ' ConvertIt(
                            XMLStream = XMLStream & Trim(SubRecords(2))
                            XMLStream = XMLStream & "</dc:date>" & Chr(13)
                        End If
                    End If
                Next
                Dim strType As String = ""
                Select Case Mid(dtbLeader.Rows(0).Item("Leader"), 7, 1)
                    Case "a", "c", "d", "t"
                        strType = "text"
                    Case "e", "f", "g", "k"
                        strType = "image"
                    Case "m", "o", "p", "r"
                        strType = "no type provided"
                    Case Else
                        Select Case Mid(dtbLeader.Rows(0).Item("Leader"), 8, 1)
                            Case "c", "s", "p"
                                strType = "collection"
                        End Select
                End Select
                XMLStream = XMLStream & "<dc:type>"
                XMLStream = XMLStream & strType
                XMLStream = XMLStream & "</dc:type>" & Chr(13)
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 655 Then
                        XMLStream = XMLStream & "<dc:type>"
                        XMLStream = XMLStream & Trim(objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content")))
                        XMLStream = XMLStream & "</dc:type>" & Chr(13)
                    End If
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 856 Then
                        'Call ParseField("$q,$u", dtbItem.Rows(i).Item("Content"), "nc ", SubRecords)
                        objBCSP.ParseField("$q,$u", dtbItem.Rows(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Then
                            XMLStream = XMLStream & "<dc:format>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(0)
                            XMLStream = XMLStream & "</dc:format>" & Chr(13)
                        End If
                        If Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:identifier>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(1)
                            XMLStream = XMLStream & "</dc:identifier>" & Chr(13)
                        End If
                    End If
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 786 Then
                        'Call ParseField("$o,$t", dtbItem.Rows(i).Item("Content"), "nc ", SubRecords)
                        objBCSP.ParseField("$q,$u", dtbItem.Rows(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:source>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(0) & SubRecords(1)
                            XMLStream = XMLStream & "</dc:source>" & Chr(13)
                        End If
                    End If
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    Select Case CInt(dtbItem.Rows(i).Item("FieldCode"))
                        Case 8
                            XMLStream = XMLStream & "<dc:language>"
                            XMLStream = XMLStream & Mid(dtbItem.Rows(i).Item("Content"), 36, 3)
                            XMLStream = XMLStream & "</dc:language>" & Chr(13)
                        Case 546
                            XMLStream = XMLStream & "<dc:language>"
                            XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content"))
                            XMLStream = XMLStream & "</dc:language>" & Chr(13)
                    End Select
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 530 Then
                        XMLStream = XMLStream & "<dc:relation>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content"))
                        XMLStream = XMLStream & "</dc:relation>" & Chr(13)
                    End If
                    If (CInt(Left(dtbItem.Rows(i).Item("FieldCode"), 3)) >= 760 And CInt(Left(dtbItem.Rows(i).Item("FieldCode"), 3)) <= 787) Then
                        'Call ParseField("$o,$t", dtbItem.Rows(i).Item("Content"), "nc ", SubRecords)
                        If Not SubRecords(0) = "" Or Not SubRecords(1) = "" Then
                            XMLStream = XMLStream & "<dc:relation>"
                            ' ConvertIt(
                            XMLStream = XMLStream & SubRecords(0) & SubRecords(1)
                            XMLStream = XMLStream & "</dc:relation>" & Chr(13)
                        End If
                    End If
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 651 Or CInt(dtbItem.Rows(i).Item("FieldCode")) = 752 Then
                        XMLStream = XMLStream & "<dc:coverage>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content"))
                        XMLStream = XMLStream & "</dc:coverage>" & Chr(13)
                    End If
                Next
                For i = 0 To dtbItem.Rows.Count - 1
                    If CInt(dtbItem.Rows(i).Item("FieldCode")) = 540 Or CInt(dtbItem.Rows(i).Item("FieldCode")) = 506 Then
                        XMLStream = XMLStream & "<dc:rights>"
                        XMLStream = XMLStream & objBCSP.TrimSubFieldCodes(dtbItem.Rows(i).Item("Content"))
                        XMLStream = XMLStream & "</dc:rights>" & Chr(13)
                    End If
                Next
            End If
            XMLStream = XMLStream & "</oai_dc:dc>" & Chr(13) & "</metadata>"
            XMLStream = XMLStream & Chr(13) & " </record>" & Chr(13)
            DisplayRecord = XMLStream
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOAIRepository Is Nothing Then
                    Call objDOAIRepository.Dispose(True)
                    objDOAIRepository = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace