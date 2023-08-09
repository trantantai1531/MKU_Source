Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACZ3950Client
        Inherits clsBBase
        ' ************************************************************************************************
        ' Declare Private variables
        ' ************************************************************************************************

        Private strZServer As String
        Private strZPort As String
        Private strZDatabase As String
        Private strZHost As String
        Private strZFormat As String = "usmarc"
        Private strName1 As String
        Private strName2 As String
        Private strName3 As String
        Private strValue1 As String
        Private strValue2 As String
        Private strValue3 As String
        Private strBool2 As String
        Private strBool3 As String
        Private blnVietUSMARC As Boolean
        Private strZError As String
        Private intHits As Integer
        Private objRecord As Object
        Private intStart As Integer
        Private intHowmany As Integer
        Private dbTimeout As Double
        Private objZHosts()


        Private objDZ3950 As New clsDOPACZ3950Client
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objZclient As MLZ3950.Z3950

        ' ************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ************************************************************************************************

        ' zServer Property
        Public Property zServer() As String
            Get
                Return strZServer
            End Get
            Set(ByVal Value As String)
                strZServer = Value
            End Set
        End Property

        ' zPort Property
        Public Property zPort() As String
            Get
                Return strZPort
            End Get
            Set(ByVal Value As String)
                strZPort = Value
            End Set
        End Property

        ' zDatabase Property
        Public Property zDatabase() As String
            Get
                Return strZDatabase
            End Get
            Set(ByVal Value As String)
                strZDatabase = Value
            End Set
        End Property

        ' zHost Property
        Public Property zHost() As String
            Get
                Return strZHost
            End Get
            Set(ByVal Value As String)
                strZHost = Value
            End Set
        End Property

        ' zFormat property
        Public Property zFormat() As String
            Get
                zFormat = strZFormat
            End Get
            Set(ByVal Value As String)
                strZFormat = Value
            End Set
        End Property

        ' Name1 Property
        Public Property Name1() As String
            Get
                Return strName1
            End Get
            Set(ByVal Value As String)
                strName1 = Value
            End Set
        End Property

        ' Name2 Property
        Public Property Name2() As String
            Get
                Return strName2
            End Get
            Set(ByVal Value As String)
                strName2 = Value
            End Set
        End Property

        ' Name3
        Public Property Name3() As String
            Get
                Return strName3
            End Get
            Set(ByVal Value As String)
                strName3 = Value
            End Set
        End Property

        ' Value1 property
        Public Property Value1() As String
            Get
                Return strValue1
            End Get
            Set(ByVal Value As String)
                strValue1 = Value
            End Set
        End Property

        ' Value2 property
        Public Property Value2() As String
            Get
                Return strValue2
            End Get
            Set(ByVal Value As String)
                strValue2 = Value
            End Set
        End Property

        ' Value3 property
        Public Property Value3() As String
            Get
                Return strValue3
            End Get
            Set(ByVal Value As String)
                strValue3 = Value
            End Set
        End Property

        ' Bool3 property
        Public Property Bool3() As String
            Get
                Return strBool3
            End Get
            Set(ByVal Value As String)
                strBool3 = Value
            End Set
        End Property

        ' Bool2 property
        Public Property Bool2() As String
            Get
                Return strBool2
            End Get
            Set(ByVal Value As String)
                strBool2 = Value
            End Set
        End Property

        ' VietUSMARC property
        Public Property VietUSMARC() As Boolean
            Get
                Return blnVietUSMARC
            End Get
            Set(ByVal Value As Boolean)
                blnVietUSMARC = Value
            End Set
        End Property

        ' ZError property
        Public Property ZError() As String
            Get
                Return strZError
            End Get
            Set(ByVal Value As String)
                strZError = Value
            End Set
        End Property

        ' Hits Property
        Public Property Hits() As Integer
            Get
                Return intHits
            End Get
            Set(ByVal Value As Integer)
                intHits = Value
            End Set
        End Property

        ' objRecord Property
        Public Property Record() As Object
            Get
                Return objRecord
            End Get
            Set(ByVal Value As Object)
                objRecord = Value
            End Set
        End Property

        ' Start property
        Public Property Start() As Integer
            Get
                Return intStart
            End Get
            Set(ByVal Value As Integer)
                intStart = Value
            End Set
        End Property

        ' Howmany property
        Public Property Howmany() As Integer
            Get
                Return intHowmany
            End Get
            Set(ByVal Value As Integer)
                intHowmany = Value
            End Set
        End Property

        ' Timeout property
        Public Property Timeout() As Double
            Get
                Return dbTimeout
            End Get
            Set(ByVal Value As Double)
                dbTimeout = Value
            End Set
        End Property

        ' ArrZHost property
        Public Property ArrZHost()
            Get
                Return objZHosts
            End Get
            Set(ByVal Value)
                objZHosts = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objZclient object
            objZclient = New MLZ3950.Z3950

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

            ' Init objDCommon object
            objDZ3950.DBServer = strDBServer
            objDZ3950.ConnectionString = strConnectionString
            objDZ3950.Initialize()
        End Sub

        ' ProccessQuery method
        Public Sub ProccessQuery(Optional ByVal intTop As Integer = 100)
            Dim strZQuery As String
            Dim blnReInit As Boolean
            Dim intCounter As Integer
            zServer = strZServer
            zPort = strZPort
            zDatabase = strZDatabase
            strZHost = zServer & ":" & zPort & "#" & zDatabase
            strZQuery = FormingZQuery()

            With objZclient
                .Host = strZServer
                .Port = strZPort
                .Database = strZDatabase
                .Top = intTop ' CInt(cboRecordLimit.SelectedValue)
                .Search(strZQuery)
                If Not .Hits = .Fail Then
                    objRecord = .Records
                Else
                    If .zerror <> "" Then
                        strZError = .zerror
                    End If
                End If
            End With

            'objZclient.Format = strZFormat
            '' Reset zServer:zPort
            'If Not objZclient.Host = zServer & ":" & zPort Then
            '    objZclient.Host = zServer & ":" & zPort
            'End If

            '' Reset zDatabase
            'If Not objZclient.Database = zDatabase Then
            '    objZclient.Database = zDatabase
            'End If

            'If Not objZclient.Connected Then
            '    blnReInit = True
            'End If

            '' objZclient Error
            'If objZclient.Init() = objZclient.FAIL Then
            '    strZError = "Init Stage: " & objZclient.LastError
            'Else
            '    Hits = objZclient.Search(strZQuery)
            '    If Hits = objZclient.FAIL Then
            '        strZError = "Search error: " & objZclient.LastError
            '    End If
            'End If
            ''If intHowmany > intHits - intStart Then
            ''    intHowmany = intHits - intStart + 1
            ''End If
            '' Get intHowmany records start with intStart
            'If objZclient.Present(intStart, intHowmany) = objZclient.FAIL Then
            '    strZError = "Present Stage: " & objZclient.LastError
            'End If

            '' Record 
            'objRecord = objZclient.Records
            'If Not objRecord Is Nothing AndAlso UBound(objRecord) >= 0 Then
            '    For intCounter = LBound(objRecord) To UBound(objRecord)
            '        objRecord(intCounter, 0) = objBCSP.ZConvertIt(objRecord(intCounter, 0), blnVietUSMARC)
            '    Next
            'End If
        End Sub

        ' ProccessQuery method
        ' Out: Array Resullt
        ' Creator: dgsoft
        Public Function ProccessMultiSearch() As Object
            'Dim strZQuery As String
            'strZQuery = FormingZQuery()
            'objZclient.Format = strZFormat
            'Try
            '    ReDim Preserve objZHosts(UBound(objZHosts))
            '    Return objZclient.MultiSearch(strZQuery, objZHosts)
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Function

        ' FormingZQuery method
        Public Function FormingZQuery() As String
            Dim strQuery As String
            strQuery = strName1 & " """ & strValue1 & """"
            If Not strValue2 = "" Then
                strQuery = strBool2 & " " & strName2 & " """ & strValue2 & """ " & strQuery
            End If

            If Not strValue3 = "" Then
                strQuery = strBool3 & " " & strName3 & " """ & strValue3 & """ " & strQuery
            End If
            FormingZQuery = objBCSP.ZConvertItBack(strQuery, blnVietUSMARC)
        End Function

        ' ParseTaggedRecord method
        Public Sub ParseTaggedRecord(ByVal strRec As String, ByRef objTag As Object, ByRef objTagVal As Object, ByVal strDesignator As String)
            ReDim objTag(0)
            ReDim objTagVal(0)
            Dim strTagname As String
            Dim strIndicators As String
            Dim strVal As String
            Dim objTagArr As Object
            Dim intIndex1 As Integer = 0
            Dim intIndex2 As Integer
            Dim intIndex3 As Integer
            strRec = Replace(strRec, strDesignator, "$")
            objTagArr = Split(strRec, "##")
            'Call objBCSP.GLoadArray(strRec, objTagArr, "##")
            For intIndex2 = LBound(objTagArr) To UBound(objTagArr)
                strVal = Trim(objTagArr(intIndex2))
                strTagname = Left(strVal, 3)
                If InStr(strTagname, "00") = 1 Then
                    If Len(strVal) > 4 Then
                        strVal = Right(strVal, Len(strVal) - 4)
                    End If
                Else
                    If Len(strVal) > 7 Then
                        strVal = Right(strVal, Len(strVal) - 7)
                    End If
                End If
                intIndex3 = FindIndex(objTag, strTagname)
                If intIndex3 = -1 Then
                    ReDim Preserve objTag(intIndex1)
                    ReDim Preserve objTagVal(intIndex1)
                    objTag(intIndex1) = strTagname
                    objTagVal(intIndex1) = strVal
                    intIndex1 = intIndex1 + 1
                Else
                    objTagVal(intIndex3) = objTagVal(intIndex3) & ". - " & strVal
                End If
            Next
        End Sub

        ' FindIndex method
        Public Function FindIndex(ByVal objTemp As Object, ByVal strTemp As String)
            Dim intTemp As Integer
            Dim intIndex As Integer
            intTemp = -1
            For intIndex = LBound(objTemp) To UBound(objTemp)
                If UCase(strTemp) = UCase(objTemp(intIndex)) Then
                    intTemp = intIndex
                    Exit For
                End If
            Next
            FindIndex = intTemp
        End Function

        ' GetZServerList method
        ' Purpose: Get list of ZServer
        Public Function GetZServerList() As DataTable
            Try
                GetZServerList = objBCDBS.ConvertTable(objDZ3950.GetZServerList)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objZclient Is Nothing Then
                    objZclient = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    Call objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDZ3950 Is Nothing Then
                    objDZ3950.Dispose(True)
                    objDZ3950 = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace