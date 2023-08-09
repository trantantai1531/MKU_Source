' Name: clsBOAIHavester
' Purpose: 
' Creator: Kiemdv
' Created Date: 20/10/2004
' Modification History:

Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOAIHavester
        Inherits clsBBase
        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************
        Private strURLResource As String
        Private strFromDate As String
        Private strToDate As String
        Private strMetadataPrefix As String
        Private strIdentifier As String
        Private strOAISet As String
        Private strResumptionToken As String
        Private strVerb As String
        Private intID As Integer = 0
        Private strXMLReturn As String


        Private objDOAIHavester As New clsDOAIHavester
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        'Private objBASPSocket As New BASP21Lib.SocketClass
        'Private objXML As New MSXML2.DOMDocument


        ' ************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ************************************************************************************************

        ' IDResource Property
        Public Property ID() As Integer
            Get
                Return intID
            End Get
            Set(ByVal Value As Integer)
                intID = Value
            End Set
        End Property

        ' XMLReturn Property
        Public ReadOnly Property XMLReturn() As String
            Get
                Return strXMLReturn
            End Get
        End Property

        ' Verb Property
        Public Property Verb() As String
            Get
                Return strVerb
            End Get
            Set(ByVal Value As String)
                strVerb = Value
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

        ' ************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOAIHavester object
            objDOAIHavester.DBServer = strDBServer
            objDOAIHavester.ConnectionString = strConnectionString
            objDOAIHavester.Initialize()

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

        ' CreateURLResource method
        ' Purpose: Create URLResource
        ' Input: some main infor: URLResource, ...
        ' Output: 0 if fail, else is Max(ID)
        Public Function CreateURLResource() As Integer
            Try

            Catch ex As Exception

            End Try
        End Function

        ' UpdateURLResource method
        ' Purpose: Update URLResource
        ' Input: some main infor: ID, URLResource, ...
        ' Output: 0 if fail, else is CurrentID
        Public Function UpdateURLResource() As Integer
            Try

            Catch ex As Exception

            End Try
        End Function

        ' DeleteURLResource method
        ' Purpose: Delete URLResource
        ' Input: some main infor: ID, ...
        ' Output: 0 if fail, else is CurrentID
        Public Function DeleteURLResource() As Integer
            Try

            Catch ex As Exception

            End Try
        End Function

        ' GetURLResource method
        ' Purpose: Get URLResource
        ' Input: intID
        ' Output: DataTable
        Public Function GetURLResource() As DataTable
            Try
                objDOAIHavester.ID = intID
                GetURLResource = objBCDBS.ConvertTable(objDOAIHavester.GetURLResource)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' purpose :  Use BASP21 to read MXL Record
        ' IN : URLResource,verbs & value of verbs
        ' OUT: Dataset with successfull , String if Error
        ' Creator : Vantd
        Public Function ReadXMLRecords() As DataSet
            'Dim strURLTmp As String
            'Dim strHost As String
            'Dim strPath As String
            'Dim intPostDe As Integer
            'Dim strQuery As String
            'Dim intRetSocket As Integer
            'Dim strData
            'Dim strReturn As String
            'Dim dsReturn As New DataSet

            'strURLTmp = strURLResource
            'strURLTmp = Replace(strURLTmp, "http://", "")
            'intPostDe = InStr(strURLTmp, "/")
            'If intPostDe > 0 Then
            '    strHost = Left(strURLTmp, intPostDe - 1)
            '    strPath = Right(strURLTmp, Len(strURLTmp) - (intPostDe - 1))
            '    strQuery = "verb=" & strVerb
            '    If strFromDate <> "" Then
            '        strQuery = strQuery & "&from=" & GenDateTimeType(strFromDate)
            '    End If
            '    If strToDate <> "" Then
            '        strQuery = strQuery & "&until=" & GenDateTimeType(strToDate)
            '    End If
            '    If strResumptionToken <> "" Then
            '        strQuery = strQuery & "&resumptionToken=" & strResumptionToken
            '    End If
            '    Select Case strVerb
            '        Case "Identify"
            '        Case "ListMetadataFormats"
            '        Case "ListSets"
            '            If strOAISet <> "" Then
            '                strQuery = strQuery & "&set=" & strOAISet
            '            End If
            '        Case "ListIdentifiers"
            '            If strResumptionToken = "" Then
            '                If strMetadataPrefix <> "" Then
            '                    strQuery = strQuery & "&metadataPrefix=" & strMetadataPrefix
            '                End If
            '            End If
            '        Case "ListRecords"
            '            If strResumptionToken = "" Then
            '                If strMetadataPrefix <> "" Then
            '                    strQuery = strQuery & "&metadataPrefix=" & strMetadataPrefix
            '                End If
            '            End If
            '        Case "GetRecord"
            '            If strIdentifier <> "" Then
            '                strQuery = strQuery & "&identifier=" & strIdentifier
            '            End If
            '            If strMetadataPrefix <> "" Then
            '                strQuery = strQuery & "&metadataPrefix=" & strMetadataPrefix
            '            End If
            '        Case Else
            '    End Select
            '    ' open socket
            '    intRetSocket = objBASPSocket.Connect(strHost, 80, 100)
            '    objBASPSocket.Write("GET " & strPath & "?" & strQuery & " HTTP/1.0" & vbCrLf & vbCrLf)
            '    ' read first line
            '    intRetSocket = objBASPSocket.ReadLine(strData)
            '    While intRetSocket = 0 And Len(strData) > 0  ' Skip Header lines
            '        intRetSocket = objBASPSocket.ReadLine(strData)
            '    End While
            '    intRetSocket = objBASPSocket.Read(strData)
            '    While intRetSocket = 0
            '        strReturn = strReturn & strData
            '        intRetSocket = objBASPSocket.Read(strData)
            '    End While
            '    ' close socket
            '    objBASPSocket.Close()
            'End If
            '' Read XML to dataset
            'objXML.async = 0
            'objXML.validateOnParse = 0
            'If objXML.loadXML(strReturn) Then
            '    Dim strPathFile As String
            '    Dim arrPara() As String = {"PATH_SAVE_XML"}
            '    Dim arrRet()
            '    arrRet = objBCDBS.GetSystemParameters(arrPara)

            '    If IsArray(arrRet) Then
            '        If UBound(arrRet) >= 0 Then
            '            strPathFile = arrRet(0) & "\XML" & Year(Now) & Month(Now) & Day(Now) & Hour(Now) & Minute(Now) & Second(Now) & ".xml"
            '        Else
            '            strPathFile = "C:\XML\XML" & Year(Now) & Month(Now) & Day(Now) & Hour(Now) & Minute(Now) & Second(Now) & ".xml"
            '        End If
            '    Else
            '        strPathFile = "C:\XML\XML" & Year(Now) & Month(Now) & Day(Now) & Hour(Now) & Minute(Now) & Second(Now) & ".xml"
            '    End If
            '    objXML.save(strPathFile)
            '    dsReturn.ReadXml(strPathFile)
            '    dsReturn = objBCDBS.ConvertDataSet(dsReturn)
            '    FileSystem.Kill(strPathFile)
            '    strXMLReturn = ""
            'Else
            '    strXMLReturn = strReturn
            'End If
            'ReadXMLRecords = dsReturn
        End Function


        ' purpose : Generate datetime format (yyyy-mm-dd-Thh:mm:ssZ)
        ' In: strInDate (dd/mm/yyyy)
        ' creator : Vantd
        Private Function GenDateTimeType(ByVal strInDate As String) As String
            Dim arrDateParts()
            Dim strRet As String
            arrDateParts = Split(strInDate, "/")
            strRet = arrDateParts(2) & "-" & StrDup(2 - Len(arrDateParts(1)), "0") & arrDateParts(1) & "-" & StrDup(2 - Len(arrDateParts(0)), "0") & arrDateParts(0) & "T00:00:00Z"
        End Function


        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            '    Try
            '        If isDisposing Then
            '            objBASPSocket = Nothing
            '            objXML = Nothing
            '        End If
            '        If Not objDOAIHavester Is Nothing Then
            '            Call objDOAIHavester.Dispose(True)
            '            objDOAIHavester = Nothing
            '        End If
            '        If Not objBCSP Is Nothing Then
            '            Call objBCSP.Dispose(True)
            '            objBCSP = Nothing
            '        End If
            '        If Not objBCDBS Is Nothing Then
            '            Call objBCDBS.Dispose(True)
            '            objBCDBS = Nothing
            '        End If
            '    Catch ex As Exception
            '        strErrorMsg = ex.Message
            '    Finally
            '        Dispose()
            '    End Try
        End Sub
    End Class
End Namespace