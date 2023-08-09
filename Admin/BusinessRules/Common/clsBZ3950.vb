' Class: clsBZ3950
' Purpose: Z39.50 search
' Creator: Oanhtn
' Created Date: 20/09/2004
' Modification History:

Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Common
Imports System.Text
Imports Zoom.Net
Imports Zoom.Net.YazSharp

Namespace eMicLibAdmin.BusinessRules.Common
    Public Class Z3950Client
        Public Property Z3950Host() As String
        Public Property Z3950Port() As Integer
        Public Property Z3950DataBase() As String
        Public Property Z3950QuerySearch() As String
        Public Property Z3950DataResult() As String()
        Public Property Z3950Error() As String
        Public Property Z3950Limit() As Integer

        Public Sub New(host As String, port As Integer, database As String)
            Me.Z3950Host = host
            Me.Z3950Port = port
            Me.Z3950DataBase = database
        End Sub

        Public Sub ResultZ3950Client()
            Try
                Me.Z3950Error = "Kết nối"
                Dim ob1 As New Connection(Me.Z3950Host, Me.Z3950Port)
                ob1.DatabaseName = Me.Z3950DataBase
                ob1.Syntax = RecordSyntax.USMARC
                'ob1.Connect();
                Dim query = Me.Z3950QuerySearch
                Me.Z3950Error = "Truy vấn"
                Dim queryq As New PrefixQuery(query)
                Dim results As IResultSet = ob1.Search(queryq)
                If results IsNot Nothing AndAlso results.Size > 0 Then
                    Me.Z3950Error = ""
                    If Me.Z3950Limit > results.Size Then
                        Me.Z3950Limit = results.Size
                    End If
                    ReDim Me.Z3950DataResult(Me.Z3950Limit)
                    For i As UInteger = 0 To Me.Z3950Limit - 1
                        Dim temp As String = Encoding.UTF8.GetString(results(i).Content)
                        Me.Z3950DataResult(i) = temp
                    Next
                End If
            Catch generatedExceptionName As Exception
                Me.Z3950Error = String.Format("Lỗi {0} đến Máy chủ ({1}:{2}): {3}", Me.Z3950Error, Me.Z3950Host, Me.Z3950Port, generatedExceptionName.Message)
                Dispose()
            End Try
        End Sub

        Public Sub Dispose()
            Me.Z3950DataBase = ""
            Me.Z3950Host = ""
            Me.Z3950Port = -1
            Me.Z3950QuerySearch = ""
        End Sub
    End Class
    Public Class clsBZ3950
        Inherits clsBBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************

        Private strZServer As String
        Private strZPort As String
        Private strZDatabase As String
        Private strZHost As String
        Private strZFormat As String = "usmarc"
        Private strFieldName1 As String
        Private strFieldName2 As String
        Private strFieldName3 As String
        Private strFieldValue1 As String
        Private strFieldValue2 As String
        Private strFieldValue3 As String
        Private strOperator2 As String
        Private strOperator3 As String
        Private blnVietUSMARC As Boolean
        Private strZError As String
        Private intHits As Integer
        Private objRecord As Object
        Private intStart As Integer
        Private intHowmany As Integer
        Private intFormID As Integer
        Private intIsAuthority As Integer

        Private objDZ3950 As New clsDZ3950
        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        'Private objZClient As MLZ3950.Z3950 'ZCOMLib.client
        Private objZClient As Z3950Client

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************

        ' IsAuthority Property
        Public Property IsAuthority() As Integer
            Get
                Return intIsAuthority
            End Get
            Set(ByVal Value As Integer)
                intIsAuthority = Value
            End Set
        End Property


        ' FormID Property
        Public Property FormID() As Integer
            Get
                Return intFormID
            End Get
            Set(ByVal Value As Integer)
                intFormID = Value
            End Set
        End Property


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

        ' FieldName1 Property
        Public Property FieldName1() As String
            Get
                Return strFieldName1
            End Get
            Set(ByVal Value As String)
                strFieldName1 = Value
            End Set
        End Property

        ' FieldName2 Property
        Public Property FieldName2() As String
            Get
                Return strFieldName2
            End Get
            Set(ByVal Value As String)
                strFieldName2 = Value
            End Set
        End Property

        ' FieldName3
        Public Property FieldName3() As String
            Get
                Return strFieldName3
            End Get
            Set(ByVal Value As String)
                strFieldName3 = Value
            End Set
        End Property

        ' FieldValue1 property
        Public Property FieldValue1() As String
            Get
                Return strFieldValue1
            End Get
            Set(ByVal Value As String)
                strFieldValue1 = Value
            End Set
        End Property

        ' FieldValue2 property
        Public Property FieldValue2() As String
            Get
                Return strFieldValue2
            End Get
            Set(ByVal Value As String)
                strFieldValue2 = Value
            End Set
        End Property

        ' FieldValue3 property
        Public Property FieldValue3() As String
            Get
                Return strFieldValue3
            End Get
            Set(ByVal Value As String)
                strFieldValue3 = Value
            End Set
        End Property

        ' Operator3 property
        Public Property Operator3() As String
            Get
                Return strOperator3
            End Get
            Set(ByVal Value As String)
                strOperator3 = Value
            End Set
        End Property

        ' Operator2 property
        Public Property Operator2() As String
            Get
                Return strOperator2
            End Get
            Set(ByVal Value As String)
                strOperator2 = Value
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

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        Public Sub Initialize()
            ' Init objZClient object
            'objZclient = New ZCOMLib.client

            ' Init objZClient object
            'objZClient = New MLZ3950.Z3950

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

            ' Init objDZ3950 object
            objDZ3950.DBServer = strDBServer
            objDZ3950.ConnectionString = strConnectionString
            objDZ3950.Initialize()
        End Sub

        ' ProccessQuery method
        Public Sub ProccessQuery(Optional ByVal intTop As Integer = 50)
            Dim strZQuery As String
            Dim blnReInit As Boolean
            Dim intCounter As Integer
            zServer = strZServer
            zPort = strZPort
            zDatabase = strZDatabase
            strZHost = zServer & ":" & zPort & "#" & zDatabase
            strZQuery = FormingZQuery()

            'With objZClient
            '    .Host = strZServer
            '    .Port = strZPort
            '    .Database = strZDatabase
            '    .Top = intTop ' CInt(cboRecordLimit.SelectedValue)
            '    .Search(strZQuery)
            '    If Not .Hits = .Fail Then
            '        objRecord = .Records
            '        Hits = UBound(.Records) + 1
            '        'objRecord = objZClient.Records
            '        'If UBound(objRecord) >= 0 Then
            '        '    For intCounter = LBound(objRecord) To UBound(objRecord)
            '        '        objRecord(intCounter, 0) = objBCSP.ZConvertIt(objRecord(intCounter, 0), blnVietUSMARC)
            '        '    Next
            '        'End If
            '    Else
            '        If .zerror <> "" Then
            '            strZError = .zerror
            '        End If
            '    End If
            'End With

            objZClient = New Z3950Client(strZServer, strZPort, strZDatabase)
            objZClient.Z3950QuerySearch = strZQuery
            objZClient.Z3950Limit = intTop
            objZClient.ResultZ3950Client()

            If objZClient.Z3950Error = "" Then
                objRecord = objZClient.Z3950DataResult
                Hits = UBound(objZClient.Z3950DataResult) + 1
            Else
                strZError = objZClient.Z3950Error
            End If

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

            '' objZClient Error
            'If objZclient.Init() = objZclient.FAIL Then
            '    strZError = "Init Stage: " & objZclient.LastError
            'Else
            '    Hits = objZclient.Search(strZQuery)
            '    If Hits = objZclient.FAIL Then
            '        strZError = "Init Stage: " & objZclient.LastError
            '    End If
            'End If
            '' Get intHowmany records start with intStart
            'If Hits < intHowmany Then
            '    If objZClient.Present(intStart, Hits) = objZClient.FAIL Then
            '        strZError = "Present Stage: " & objZClient.LastError
            '    End If
            'Else
            '    If objZClient.Present(intStart, intHowmany) = objZClient.FAIL Then
            '        strZError = "Present Stage: " & objZClient.LastError
            '    End If
            'End If
            '' Record 

            '' Close before exist
            'If objZClient.Connected Then
            '    objZClient.Close()
            'End If
        End Sub

        ' FormingZQuery method
        Public Function FormingZQuery() As String
            Dim strQuery As String
            strQuery = strFieldName1 & " " & strFieldValue1
            If Not strFieldValue2 = "" Then
                strQuery = strOperator2 & " " & strFieldName2 & " " & strFieldValue2 & " " & strQuery
            End If

            If Not strFieldValue3 = "" Then
                strQuery = strOperator3 & " " & strFieldName3 & " " & strFieldValue3 & " " & strQuery
            End If
            If Not blnVietUSMARC Then
                strZFormat = "unicode"
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
            Call objBCSP.GLoadArray(strRec, objTagArr, Chr(10))
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

        Public Sub FillValueFieldsToArray(ByVal RecordContent As String, ByRef arrOutFieldName() As String, ByRef arrOutFieldValue() As String, Optional ByVal strDesignator As String = "", Optional ByVal bolMARC As Boolean = False)
            Try
                RecordContent = RecordContent.Substring(5)

                RecordContent = Replace(RecordContent, "#", " ")
                Dim BaseAddress As Integer = 0
                Dim DirBlock As String = ""
                Dim FieldBlock As String = ""
                BaseAddress = CInt(Mid(RecordContent, 8, 5)) - 5
                DirBlock = Mid(RecordContent, 20, BaseAddress - 20)
                FieldBlock = RecordContent.Substring(BaseAddress, Len(RecordContent) - BaseAddress)
                Dim FieldItem As String = ""
                Dim FieldName As String = ""
                Dim FieldValue As String = ""
                Dim objRec() As String = Nothing
                Dim strTempMARC As String = ""

                Do While DirBlock.Trim.Length > 0
                    FieldItem = DirBlock.Substring(0, 12)
                    DirBlock = DirBlock.Substring(12, Len(DirBlock) - 12)
                    FieldName = FieldItem.Substring(0, 3)
                    FieldValue = Mid(FieldBlock, CInt(FieldItem.Substring(Len(FieldItem) - 5, 5)) + 1, CInt(Mid(FieldItem, 4, 4)))
                    If FieldValue.Length > 0 Then
                        FieldValue = FieldValue.Substring(0, Len(FieldValue) - 1).Trim
                        FieldValue = Replace(FieldValue, "'", "''")
                        FieldValue = Replace(FieldValue, Chr(31), "$")
                        FieldValue = Replace(FieldValue, Chr(34), "")
                        FieldValue = Replace(FieldValue, Chr(0), "")
                        'FieldValue = deleteIndicatorOfIso2709(FieldValue)
                        strTempMARC = ""
                        If InStr(FieldValue, "$") > 0 Then
                            If bolMARC Then
                                strTempMARC = FieldValue.Substring(0, InStr(FieldValue, "$") - 1) '& "&nbsp;"
                                Select Case Len(strTempMARC)
                                    Case 0
                                        strTempMARC &= "  "
                                    Case 1
                                        strTempMARC &= " "
                                End Select
                                strTempMARC = Replace(strTempMARC, " ", "_")
                                strTempMARC = "&nbsp;&nbsp;&nbsp;" & strTempMARC & "&nbsp;&nbsp;&nbsp;"
                            End If
                            FieldValue = strTempMARC & FieldValue.Substring(InStr(FieldValue, "$") - 1)
                        End If
                        'If FieldValue.Length > 0 AndAlso FieldValue.Substring(FieldValue.Length - 1) = "#" Then
                        '    FieldValue = FieldValue.Substring(0, FieldValue.Length - 1)
                        'End If
                        Call AddFields(FieldName, FieldValue, arrOutFieldName, arrOutFieldValue)
                    End If
                Loop
            Catch ex As Exception
                'ErrorMsg = "Error..."
            End Try
        End Sub


        Public Function FindField(ByVal Array1() As String, ByVal Array2() As String, ByVal field As String) As String
            Dim strResult As String = ""
            Try
                For i As Integer = 0 To UBound(Array1)
                    If Not IsNothing(Array1(i)) AndAlso Not IsNothing(Array2(i)) Then
                        Select Case Array1(i)
                            Case field
                                strResult = ConvertUTF8toUni(Array2(i))
                                Exit For
                        End Select
                    End If
                Next
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Public Function FindFieldByObject(ByVal Array1() As Object, ByVal Array2() As Object, ByVal field As String) As String
            Dim strResult As String = ""
            Try
                For i As Integer = 0 To UBound(Array1)
                    If Not IsNothing(Array1(i)) AndAlso Not IsNothing(Array2(i)) Then
                        Select Case Array1(i)
                            Case field
                                strResult = ConvertUTF8toUni(Array2(i))
                                Exit For
                        End Select
                    End If
                Next
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' AddFields method
        ' Input: 
        '   - String value of FieldName (strNames)
        '   - String value of FieldValue (strVal)
        ' Output: two array of FieldNames and FieldValues (arrFName, arrFValue)
        Private Sub AddFields(ByVal strNames As String, ByVal strVal As String, ByRef arrFName() As String, ByRef arrFValue() As String)
            Dim intIndex As Integer
            Dim intCounter As Integer

            If Trim(strNames) <> "" Then
                ' For intCounter = 0 To UBound(arrFName) - 1
                For intCounter = 0 To UBound(arrFName)
                    If arrFName(intCounter) = strNames Then
                        intIndex = intCounter
                    Else
                        intIndex = intCounter + 1
                    End If
                Next
                If intIndex > UBound(arrFName) - 1 Then
                    ReDim Preserve arrFName(intIndex + 1)
                    ReDim Preserve arrFValue(intIndex + 1)
                    arrFName(intIndex) = strNames
                    arrFValue(intIndex) = strVal
                    'Else
                    '    arrFValue(intIndex) = arrFValue(intIndex) & "$&" & strVal
                End If
            End If
        End Sub

        Public Function ConvertUniToUTF8(ByVal val As String) As String
            'Dim Buffer() As Byte
            'Dim RecvMessage As String = ""
            'Try
            '    Dim clsFont As New MLFonts.UnicodeText
            '    Buffer = clsFont.UnicodeToUtf8(val)
            '    RecvMessage = System.Text.Encoding.Default.GetString(Buffer)
            '    clsFont = Nothing
            'Catch ex As Exception : End Try
            'Return RecvMessage
            Dim RecvMessage As String = ""
            Dim utf8Bytes As Byte() = Encoding.UTF8.GetBytes(val)
            Dim unicodeBytes As Byte() = Encoding.Convert(Encoding.Default, Encoding.UTF8, utf8Bytes)
            RecvMessage = Encoding.UTF8.GetString(unicodeBytes)
            Return RecvMessage
        End Function

        Public Function ConvertUTF8toUni(ByVal val As String) As String
            'Dim Buffer() As Byte
            'Dim RecvMessage As String = ""
            'Try
            '    Buffer = System.Text.Encoding.Default.GetBytes(val.ToCharArray)
            '    Dim clsFont As New MLFonts.UnicodeText
            '    RecvMessage = clsFont.Utf8ToUnicode(Buffer)
            '    clsFont = Nothing
            'Catch ex As Exception : End Try
            'Return RecvMessage
            Dim RecvMessage As String = ""
            Dim unicodeBytes As Byte() = Encoding.Default.GetBytes(val)
            Dim utfBytes As Byte() = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, unicodeBytes)
            RecvMessage = Encoding.Unicode.GetString(utfBytes)
            Return RecvMessage
        End Function

        ' FindIndex method
        Public Function FindIndex(ByVal objTemp As Object, ByVal strTemp As String) As Integer
            Dim intTemp As Integer = -1
            Dim intIndex As Integer = -1

            Try
                For intIndex = LBound(objTemp) To UBound(objTemp)
                    If UCase(strTemp) = UCase(objTemp(intIndex)) Then
                        intTemp = intIndex
                        Exit For
                    End If
                Next
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
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
        Public Function InsZServer(ByVal strName As String, ByVal strHost As String, ByVal intPort As Integer, ByVal strAccount As String, ByVal strPassword As String, ByVal strDBName As String, ByVal strDescription As String) As Integer
            Try
                InsZServer = objDZ3950.InsZServer(strName, strHost, intPort, strAccount, strPassword, strDBName, strDescription)
                strErrorMsg = objDZ3950.ErrorMsg
                intErrorCode = objDZ3950.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function
        Public Function UpdZServer(ByVal intZ3950ServerID As Integer, ByVal strName As String, ByVal strHost As String, ByVal intPort As Integer, ByVal strAccount As String, ByVal strPassword As String, ByVal strDBName As String, ByVal strDescription As String) As Integer
            Try
                UpdZServer = objDZ3950.UpdZServer(intZ3950ServerID, strName, strHost, intPort, strAccount, strPassword, strDBName, strDescription)
                strErrorMsg = objDZ3950.ErrorMsg
                intErrorCode = objDZ3950.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                'If Not objZClient Is Nothing Then
                '    objZClient.Close()
                '    objZClient = Nothing
                'End If
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