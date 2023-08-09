Imports System
Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBSaveMail
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBCSP As New clsBCommonStringProc
        Private objBILLInRequest As New clsBILLInRequest
        Private objBILLOutRequest As New clsBILLOutRequest
        Private objBIllLibary As New clsBILLLibrary
        Private objPara() As String = {"SMTP_SERVER", "SMTP_PORT", "ADMIN_EMAIL_ADDRESS", "ILL_USER", "ILL_PASS", "DATE_FORMAT", "POP3_SERVER", "POP3_PORT"}
        Private objSysPara() As String
        ' Private variables
        Private colNameValue As New Collection

        Private arrMsgs() As String
        Private strProtocolVerNum As String = ""
        Private strRequestID As String = ""
        Private strTransactGroupQualifier As String = ""
        Private strSubTransactQualifier As String = ""
        Private strServiceDate As String = ""
        Private strServiceTime As String = ""
        Private strRequesterSymbol As String = ""
        Private strRequesterName As String = ""
        Private strResponderSymbol As String = ""
        Private strResponderName As String = ""
        Private strNote As String
        Private intILLID_OUT As Integer = 0
        Private intILLID_IN As Integer = 0
        Private intLibID As Integer = 0
        Private strMailTo As String
        Private strToday As String = ""
        Private blnLibEncode As Boolean = False
        Private strServerPath As String = ""
        Private strReplyStatus As String = ""
        Private strNoStatus As String = ""

        Public Property DateOfNow() As String
            Get
                Return strToday
            End Get
            Set(ByVal Value As String)
                strToday = Value
            End Set
        End Property
        Public Property ServerPath() As String
            Get
                Return strServerPath
            End Get
            Set(ByVal Value As String)
                strServerPath = Value
            End Set
        End Property
        Public Property ReplyStatus() As String
            Get
                Return strReplyStatus
            End Get
            Set(ByVal Value As String)
                strReplyStatus = Value
            End Set
        End Property
        Public Property NoStatus() As String
            Get
                Return strNoStatus
            End Get
            Set(ByVal Value As String)
                strNoStatus = Value
            End Set
        End Property

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            Try
                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

                ' Init objBILLInRequest object
                objBILLInRequest.DBServer = strDBServer
                objBILLInRequest.InterfaceLanguage = strInterfaceLanguage
                objBILLInRequest.ConnectionString = strConnectionString
                Call objBILLInRequest.Initialize()

                ' Init objBILLOutRequest object
                objBILLOutRequest.DBServer = strDBServer
                objBILLOutRequest.InterfaceLanguage = strInterfaceLanguage
                objBILLOutRequest.ConnectionString = strConnectionString
                Call objBILLOutRequest.Initialize()

                ' Init objBCommonBusiness object
                objBCommonBusiness.DBServer = strDBServer
                objBCommonBusiness.InterfaceLanguage = strInterfaceLanguage
                objBCommonBusiness.ConnectionString = strConnectionString
                Call objBCommonBusiness.Initialize()

                ' Init objBIllLibary object
                objBIllLibary.DBServer = strDBServer
                objBIllLibary.InterfaceLanguage = strInterfaceLanguage
                objBIllLibary.ConnectionString = strConnectionString
                Call objBIllLibary.Initialize()

                ' Init objBCSP object
                objBCSP.DBServer = strDBServer
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()

                Call GetSysPara()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetSysPara method
        Public Sub GetSysPara()
            Try
                objSysPara = objBCDBS.GetSystemParameters(objPara)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' ConvertDate from ISO DATE
        Private Function ConvertDate(ByVal StrInDate)
            Dim strDay, strMonth, strYear
            Dim strTypeShow As String

            If Trim(StrInDate) = "" Then
                ConvertDate = ""
                Exit Function
            Else
                If Not objSysPara(5) & "" = "" Then
                    strTypeShow = objSysPara(5)
                Else
                    strTypeShow = "DD/MM/YYYY"
                End If

                strYear = Trim(Left(StrInDate, 4))
                strMonth = Trim(Mid(StrInDate, 5, 2))
                strDay = Trim(Mid(StrInDate, 7, 2))

                Select Case UCase(strTypeShow)
                    Case "DD/MM/YYYY"
                        ConvertDate = strDay & "/" & strMonth & "/" & strYear
                    Case "MM/DD/YYYY"
                        ConvertDate = strMonth & "/" & strDay & "/" & strYear
                    Case "YYYY/DD/MM"
                        ConvertDate = strYear & "/" & strDay & "/" & strMonth
                    Case "YYYY/MM/DD"
                        ConvertDate = strYear & "/" & strMonth & "/" & strDay
                End Select
            End If
        End Function
        Private Function ConvertNumber(ByVal retval As Object) As Object
            If Not retval Is Nothing AndAlso IsNumeric(retval) Then
                Return retval
            Else
                Return 0
            End If
        End Function
        ' SaveMail method
        ' Purpose: Save the mail content to the 
        Public Function SaveMail(ByRef blnNoHaveEmail As Boolean, ByRef arrContentOut() As String, ByRef arrMailToOut() As String, ByRef strMailFromOut As String) As Boolean
            Dim arrMsg() As String
            Dim blnGet As Boolean

            Try
                blnGet = GetMail(arrMsg)
                If blnGet And (Not arrMsg Is Nothing AndAlso arrMsg.Length > 0) Then
                    arrMsgs = arrMsg
                    Call SaveMsgs(arrContentOut, arrMailToOut, strMailFromOut)
                    SaveMail = True
                Else
                    blnNoHaveEmail = True
                    SaveMail = False
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
                SaveMail = False
            End Try
        End Function

        ' GetMail method
        ' Purpose: Get mail from the client
        ' Output: int value (0 when success)
        Public Function GetMail(ByRef arrMessageOut() As String) As Boolean
            ' Declare variables
            Dim objSock As New Socket.TCP
            Dim strPOP3Port As String = ""
            Dim strPOP3Server As String = ""
            Dim strILLUser As String = ""
            Dim strILLPass As String = ""
            Dim strResult As String = ""
            Dim arrElement As Object
            Dim lngNoM As Long = 0
            Dim intm As Integer = 0
            Dim intIndex As Integer = 0
            Dim strMsg As String
            Dim blnOK As Boolean
            Dim intPoint As Integer
            Dim strHeader As String
            Dim strBody As String
            Dim arrHeaderLines() As String
            Dim strline As String
            Dim strHeaderLine As String
            Dim strFrom As String

            Try
                ' get the pop 3 mail server infor
                strPOP3Server = objSysPara(6)
                strPOP3Port = objSysPara(7)
                strILLUser = objSysPara(3)
                strILLPass = objSysPara(4)

                objSock.Host = strPOP3Server & ":" & strPOP3Port
                objSock.Open()
                strResult = objSock.GetLine()
                objSock.SendLine("USER " & strILLUser)
                strResult = objSock.GetLine()
                objSock.SendLine("PASS " & strILLPass)
                strResult = objSock.GetLine()
                objSock.SendLine("STAT")
                strResult = objSock.GetLine()
                arrElement = Split(strResult, " ")
                lngNoM = CLng(arrElement(1))

                For intIndex = 1 To lngNoM
                    strMsg = ""
                    objSock.SendLine("RETR " & intIndex)
                    strResult = ""
                    strline = objSock.GetLine()
                    While strline <> "."
                        strResult = strResult & strline & vbCrLf
                        strline = objSock.GetLine()
                    End While
                    intPoint = InStr(strResult, vbCrLf & vbCrLf)
                    strHeader = Left(strResult, intPoint - 1)
                    strBody = Right(strResult, Len(strResult) - intPoint - 3)

                    If Trim(strBody) <> "" Then
                        Dim strOut As String
                        Dim objILL As New ILLCOMLib.core
                        strOut = objILL.BERDecode(strBody)
                        If strOut.ToLower <> "errdecode" Then
                            strBody = strOut
                        End If
                        objILL = Nothing
                    End If

                    strBody = Right(strBody, Len(strBody) - InStr(strBody, "<?") + 1)
                    strBody = Left(strBody, InStr(strBody, "</illapdu>") + 9)
                    arrHeaderLines = Split(strHeader, vbCrLf)
                    For Each strHeaderLine In arrHeaderLines
                        If Left(strHeaderLine, 5) = "From" Then
                            strFrom = Right(strHeaderLine, Len(strHeaderLine) - 6)
                        ElseIf Left(strHeaderLine, 11) = "Return-Path" Then
                            strFrom = Right(strHeaderLine, Len(strHeaderLine) - 12)
                        ElseIf Left(strHeaderLine, 13) = "X-Return-Path" Then
                            strFrom = Right(strHeaderLine, Len(strHeaderLine) - 14)
                        End If
                    Next
                    strBody = objBCSP.ToUTF8Back(strBody)
                    strMsg = strMsg & "From=" & strFrom.Trim
                    strBody = Replace(strBody, "version=3D", "version=")
                    strBody = Replace(strBody, "Type=3D", "Type=")
                    strBody = Replace(strBody, "xmlns=3D", "xmlns=")
                    blnOK = ParseMsg(strBody, strMsg)
                    If blnOK Then
                        objSock.SendLine("DELE " & intIndex)
                        strResult = objSock.GetLine()
                        ReDim Preserve arrMessageOut(intm)
                        arrMessageOut(intm) = strMsg
                        intm = intm + 1
                    End If
                Next
                objSock.SendLine("QUIT")
                objSock.Close()
                GetMail = True
            Catch ex As Exception
                GetMail = False
                strErrorMsg = ex.Message
            Finally
                objSock = Nothing
            End Try
        End Function

        ' ParseMsg method
        Function ParseMsg(ByVal strMsgIn As String, ByRef strMsgOut As String) As Boolean
            Dim strType As String
            Dim objXML As New MSXML2.DOMDocument
            Dim blnOK As Boolean
            blnOK = False

            strType = ""
            objXML.async = 0
            objXML.validateOnParse = 0
            If objXML.loadXML(strMsgIn) Then
                strType = objXML.documentElement.getAttribute("type")
                If Not strType = "" Then
                    blnOK = True
                    strMsgOut = strMsgOut & "&type=" & strType
                    Call TreeWalk(objXML, "", strMsgOut)
                End If
            End If
            ParseMsg = blnOK
        End Function

        ' TreeWalk method
        Private Sub TreeWalk(ByVal strNode, ByVal strPath, ByRef strOut)
            Dim strChild
            Dim strTemp As String
            Dim strName As String
            Dim strValue As String

            For Each strChild In strNode.childNodes
                strTemp = strPath
                If strChild.nodeType < 3 Then
                    strPath = strPath & strChild.nodeName + "."
                End If
                If strChild.hasChildNodes Then
                    Call TreeWalk(strChild, strPath, strOut)
                Else
                    If strPath <> "" Then
                        strName = Left(strPath, Len(strPath) - 1)
                        strValue = strChild.text
                        strOut = strOut & "&" & strName & "=" & strValue
                    End If
                End If
                strPath = strTemp
            Next
        End Sub

        ' Thu? tu.c la^'y ra ca'c bie^'n chung cho chu+o+ng tri`nh
        Private Sub GetGeneralValues()
            Dim tblLib As DataTable
            Try
                strProtocolVerNum = GetValue("protocol-version-num")

                strRequestID = GetValue("transaction-id.transaction-qualifier")
                strTransactGroupQualifier = GetValue("transaction-id.transaction-group-qualifier")
                strSubTransactQualifier = GetValue("transaction-id.sub-transaction-qualifier")

                strServiceDate = GetValue("service-date-time.date-time-of-this-service.date")
                strServiceTime = GetValue("service-date-time.date-time-of-this-service.time")

                strRequesterSymbol = Trim(GetValue("requester-id.person-or-institution-symbol.institution-symbol"))
                strRequesterName = Trim(GetValue("requester-id.name-of-person-or-institution.name-of-institution"))
                strResponderSymbol = Trim(GetValue("responder-id.person-or-institution-symbol.institution-symbol"))
                strResponderName = Trim(GetValue("responder-id.name-of-person-or-institution.name-of-institution"))

                strNote = GetValue("requester-note")
                If strNote & "" = "" Then
                    strNote = GetValue("responder-note")
                End If
                If strNote & "" = "" Then
                    strNote = GetValue("note")
                End If

                strMailTo = Trim(GetValue("From"))
                objBCDBS.SQLStatement = "SELECT ID, EmailReplyAddress,EncodingScheme FROM ILL_LIBRARIES WHERE (upper(LibrarySymbol) = '" & strRequesterSymbol.ToUpper & "' or upper(LibrarySymbol) = '" & strResponderSymbol.ToUpper & "')  AND upper(EmailReplyAddress) = '" & strMailTo.ToUpper & "'"

                tblLib = objBCDBS.RetrieveItemInfor

                If Not tblLib Is Nothing AndAlso tblLib.Rows.Count > 0 Then
                    intLibID = tblLib.Rows(0).Item("ID")
                    blnLibEncode = CBool(tblLib.Rows(0).Item("EncodingScheme"))
                Else
                    intLibID = 0
                    strMailTo = ""
                End If

                If Not intLibID = 0 Then
                    objBCDBS.SQLStatement = "SELECT ID FROM ILL_OUTGOING_REQUESTS WHERE RequestID = '" & strRequestID & "' AND ResponderID = " & intLibID
                    tblLib = objBCDBS.RetrieveItemInfor

                    If Not tblLib Is Nothing AndAlso tblLib.Rows.Count > 0 Then
                        intILLID_OUT = tblLib.Rows(0).Item("ID")
                    Else
                        intILLID_OUT = 0
                    End If


                    objBCDBS.SQLStatement = "SELECT ID FROM ILL_INCOMING_REQUESTS WHERE RequestID = '" & strRequestID & "' AND RequesterID = " & intLibID
                    tblLib = objBCDBS.RetrieveItemInfor

                    If Not tblLib Is Nothing AndAlso tblLib.Rows.Count > 0 Then
                        intILLID_IN = tblLib.Rows(0).Item("ID")
                    Else
                        intILLID_IN = 0
                    End If
                End If
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
                tblLib = Nothing
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Ha`m la^'y ra mo^.t gia' tri. tu+` Collection
        Private Function GetValue(ByVal strName As String)
            Try
                If strName = "From" Or strName = "type" Then
                    GetValue = colNameValue.Item(strName)
                Else
                    GetValue = colNameValue.Item("illapdu." & strName)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' SaveMsgs method
        Public Sub SaveMsgs(ByRef arrContentOut() As String, ByRef arrMailToOut() As String, ByRef strMailFormOut As String)
            Dim strMsg As String
            Dim arrTemp, arrSubVal
            Dim inti, strType
            Dim strContent As String

            Dim tblILLLib As DataTable
            Dim intCountMail As Integer = 0

            strMailFormOut = ""

            For Each strMsg In arrMsgs
                ' Loa.i bo? ca'c pha^`n tu+? cu~ cu?a Collection
                For inti = 1 To colNameValue.Count
                    colNameValue.Remove(1)
                Next
                ' Ta'ch ca'c ca(.p Name=Value
                arrTemp = Split(strMsg, "&")
                ' Ta'ch tu+`ng Name, Value va` the^m va`o Collection
                For inti = 0 To UBound(arrTemp)
                    arrSubVal = Split(arrTemp(inti), "=")
                    colNameValue.Add(Item:=arrSubVal(1), Key:=CStr(arrSubVal(0)))
                Next
                strType = GetValue("type")
                If Not strType = "" Then
                    Dim tblTempOut As DataTable, tblTempIn As DataTable
                    Dim intStatusOut As Integer, intStatusIn As Integer
                    If Not intILLID_OUT = 0 Then
                        objBCDBS.SQLStatement = "SELECT Status FROM ILL_OUTGOING_REQUESTS WHERE ID = " & CStr(intILLID_OUT)
                        tblTempOut = objBCDBS.RetrieveItemInfor
                        If Not tblTempOut Is Nothing AndAlso tblTempOut.Rows.Count > 0 Then
                            intStatusOut = CInt(tblTempOut.Rows(0).Item("Status"))
                        End If
                    End If
                    If Not intILLID_IN = 0 Then
                        objBCDBS.SQLStatement = "SELECT Status FROM ILL_INCOMING_REQUESTS WHERE ID = " & CStr(intILLID_IN)
                        tblTempIn = objBCDBS.RetrieveItemInfor
                        If Not tblTempIn Is Nothing AndAlso tblTempIn.Rows.Count > 0 Then
                            intStatusIn = CInt(tblTempIn.Rows(0).Item("Status"))
                        End If
                    End If
                    ' Kho+?i ta.o ca'c bie^'n du`ng chung
                    Call GetGeneralValues()
                    Call objBILLInRequest.InitVariables()
                    Call objBILLOutRequest.InitValues()
                    ' Xu+? ly' ca'c tru+o+`ng ho+.p kha'c nhau cu?a ILLAPDU
                    Select Case UCase(strType)
                        ' Ca'c tru+o+`ng ho+.p ghi va`o ba?ng OUTGOING
                        ' ILLANS, OVERDU, RENANS, SHIPED, CNLREP, RECALL, CHKDIN
                        Case "ILLANS"
                            Call SaveILLANS()
                        Case "OVERDU"
                            If intStatusOut <> 1 Then
                                Call SaveOVERDU()
                            End If
                        Case "RENANS"
                            If intStatusOut <> 1 Then
                                Call SaveRENANS()
                            End If
                        Case "SHIPED"
                            If intStatusOut <> 1 Then
                                Call SaveSHIPED()
                            End If
                        Case "CNLREP"
                            If intStatusOut <> 1 Then
                                Call SaveCNLREP()
                            End If
                        Case "RECALL"
                            If intStatusOut <> 1 Then
                                Call SaveRECALL()
                            End If
                        Case "CHKDIN"
                            If intStatusOut <> 1 Then
                                Call SaveCHKDIN()
                            End If
                            ' Ca'c tru+o+`ng ho+.p ghi va`o ba?ng INCOMING
                            ' ILLREQ, RCEIVD, CANCEL, RENEWL, RETRND, CONREP
                        Case "ILLREQ"
                            Call SaveILLREQ()
                        Case "RCEIVD"
                            If intStatusIn <> 1 Then
                                Call SaveRCEIVD()
                            End If
                        Case "CANCEL"
                            If intStatusIn <> 1 Then
                                Call SaveCANCEL()
                            End If
                        Case "RENEWL"
                            If intStatusIn <> 1 Then
                                Call SaveRENEWL()
                            End If
                        Case "RETRND"
                            If intStatusIn <> 1 Then
                                Call SaveRETRND()
                            End If
                        Case "CONREP"
                            If intStatusIn <> 1 Then
                                Call SaveCONREP()
                            End If
                            ' Ca'c tru+o+`ng ho+.p chung
                            ' FORNOT, MESSAG, LOSTIT, STATUS
                        Case "STATUS"
                            ' Ghi log va` la^'y ra tra.ng tha'i hie^.n tho+`i cu?a ye^u ca^`u
                            If Not (intILLID_IN = 0) Then

                            End If
                            Dim strStatus As String
                            strStatus = SaveSTATUS()
                            strContent = MessagXmlRecord(strStatus)
                            ' Tra? lo+`i thu+ tu+. ddo^.ng
                            If Not strMailTo = "" Then
                                ReDim Preserve arrMailToOut(intCountMail)
                                ReDim Preserve arrContentOut(intCountMail)
                                arrMailToOut(intCountMail) = strMailTo
                                ' EnCode to BASE 64 or not
                                If blnLibEncode Then
                                    Dim strFileName, strOut As String
                                    Dim blnEncodeOk As Boolean
                                    objBCDBS.Extension = "XML"
                                    strFileName = strServerPath & "\" & objBCDBS.GenRandomFile
                                    Dim ObjOut = New StreamWriter(strFileName)
                                    strContent = objBCSP.CutVietnameseAccent(strContent)
                                    ObjOut.Write(strContent)
                                    ObjOut.Close()
                                    ObjOut = Nothing

                                    Try
                                        Dim objILL As New ILLCOMLib.core
                                        Dim i As Integer = 0
                                        Dim itry As Integer = 10
                                        Dim strDecode As String
                                        blnEncodeOk = False
                                        While i < itry
                                            strOut = objILL.BEREncode(strFileName)
                                            strDecode = objILL.BERDecode(strOut)
                                            If strDecode.ToLower <> "errdecode" Then
                                                i = itry
                                                blnEncodeOk = True
                                            End If
                                            i = i + 1
                                        End While
                                        objILL = Nothing
                                    Catch ex As Exception
                                    End Try

                                    If blnEncodeOk Then
                                        strContent = strOut
                                        ' Delete file
                                        Dim objFileInfor As FileInfo
                                        objFileInfor = New FileInfo(strFileName)

                                        If objFileInfor.Exists Then
                                            objFileInfor.Delete()
                                        End If
                                        objFileInfor = Nothing
                                    End If
                                End If
                                arrContentOut(intCountMail) = strContent
                                If strMailFormOut = "" Then
                                    objBIllLibary.LibID = 0
                                    tblILLLib = objBIllLibary.GetLib(1)
                                    If Not tblILLLib Is Nothing AndAlso tblILLLib.Rows.Count > 0 Then
                                        strMailFormOut = tblILLLib.Rows(0).Item("EmailReplyAddress")
                                    End If
                                End If
                                intCountMail = intCountMail + 1
                            End If
                        Case "MESSAG"
                            Call SaveMESSAG()
                        Case "LOSTIT"
                            Call SaveLOSTIT()
                        Case "FORNOT"
                            ' Msg na`y se~ pha't trie^?n sau
                        Case Else
                            ' Thu+ o+? da.ng XML nhu+ng kho^ng pha?i la` 1 ILLAPDU
                    End Select
                Else
                    ' Thu+ o+? da.ng XML nhu+ng kho^ng pha?i la` 1 ILLAPDU
                End If
            Next
        End Sub

        ' SaveCHKDIN method
        Private Sub SaveCHKDIN()
            Dim strProvidedDate As String

            If Not (intILLID_OUT = 0 Or intLibID = 0) Then
                strProvidedDate = GetValue("date-checked-in")
                strProvidedDate = ConvertDate(strProvidedDate)

                ' Update request

                objBILLOutRequest.Status = 22
                objBILLOutRequest.CheckedInDate = strProvidedDate
                objBILLOutRequest.IllID = intILLID_OUT
                objBILLOutRequest.UpdateOR()

                ' Insert Log
                objBILLOutRequest.IllID = intILLID_OUT
                objBILLOutRequest.ResponderID = intLibID
                objBILLOutRequest.APDUType = 11
                objBILLOutRequest.TransactionDate = strToday
                objBILLOutRequest.ProvidedDate = strProvidedDate
                objBILLOutRequest.Note = strNote
                objBILLOutRequest.Alert = 1
                objBILLOutRequest.InsertORequestLog()
            End If
        End Sub

        ' SaveILLANS 
        Private Sub SaveILLANS()
            Dim strProvidedDate As String
            Dim intTransactionResults As Integer
            Dim intCondition As Integer = 0
            Try
                If Not (intILLID_OUT = 0 Or intLibID = 0) Then
                    intTransactionResults = ConvertNumber(GetValue("transaction-results"))
                    Select Case intTransactionResults
                        Case 1
                            strProvidedDate = GetValue("conditional-results.date-for-reply")
                            intCondition = ConvertNumber(GetValue("conditional-results.conditions"))
                        Case 2
                            strProvidedDate = GetValue("retry-results.retry-date")
                            intCondition = ConvertNumber(GetValue("retry-results.reason-not-available"))
                        Case 3
                            strProvidedDate = ""
                            intCondition = ConvertNumber(GetValue("unfilled-results.reason-unfilled"))
                        Case 4
                            'no support
                        Case 5
                            strProvidedDate = GetValue("will-supply-results.supply-date")
                            intCondition = ConvertNumber(GetValue("will-supply-results.reason-will-supply"))
                    End Select

                    strProvidedDate = ConvertDate(strProvidedDate)

                    If Trim(strProvidedDate) = "" Or Trim(strProvidedDate) = "//" Then
                        strProvidedDate = "NULL"
                    End If

                    Select Case intTransactionResults
                        Case 1 ' CONDITION
                            ' Update request
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.Status = 5
                            objBILLOutRequest.RespondDate = strToday
                            objBILLOutRequest.UpdateOR()

                            ' Insert Log
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.ResponderID = intLibID
                            objBILLOutRequest.APDUType = 4
                            objBILLOutRequest.TRE = 1
                            objBILLOutRequest.ReasonID = intCondition
                            objBILLOutRequest.ProvidedDate = strProvidedDate
                            objBILLOutRequest.Note = strNote
                            objBILLOutRequest.Alert = 1
                            objBILLOutRequest.InsertORequestLog()
                        Case 2 ' RETRY
                            ' Update Request
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.Status = 1
                            objBILLOutRequest.RespondDate = strToday
                            objBILLOutRequest.UpdateOR()

                            ' Insert Log
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.ResponderID = intLibID
                            objBILLOutRequest.APDUType = 4
                            objBILLOutRequest.TRE = 2
                            objBILLOutRequest.ReasonID = intCondition
                            objBILLOutRequest.ProvidedDate = strProvidedDate
                            objBILLOutRequest.Note = strNote
                            objBILLOutRequest.Alert = 1
                            objBILLOutRequest.InsertORequestLog()

                            ' Insert OR Deny data
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.RequestDate = strProvidedDate
                            objBILLOutRequest.ResponderID = intLibID
                            objBILLOutRequest.ReasonID = intCondition
                            objBILLOutRequest.RespondDate = strToday
                            objBILLOutRequest.InsertORequestDenied()
                        Case 3 ' UNFILLED
                            Dim tblRequest As DataTable
                            objBILLOutRequest.IllID = intILLID_OUT
                            tblRequest = objBILLOutRequest.GetORInfor
                            If Not tblRequest Is Nothing AndAlso tblRequest.Rows.Count > 0 Then
                                strProvidedDate = tblRequest.Rows(0).Item("REQUESTDATE")
                            End If

                            ' Update Request
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.Status = 1
                            objBILLOutRequest.RespondDate = strToday
                            objBILLOutRequest.UpdateOR()

                            ' Insert Log
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.ResponderID = intLibID
                            objBILLOutRequest.APDUType = 4
                            objBILLOutRequest.TRE = 3
                            objBILLOutRequest.ReasonID = intCondition
                            objBILLOutRequest.Note = strNote
                            objBILLOutRequest.Alert = 1
                            objBILLOutRequest.InsertORequestLog()

                            ' Insert OR Deny data
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.RequestDate = strProvidedDate
                            objBILLOutRequest.ResponderID = intLibID
                            objBILLOutRequest.ReasonID = intCondition
                            objBILLOutRequest.RespondDate = strToday
                            objBILLOutRequest.InsertORequestDenied()

                            tblRequest.Clear()
                            tblRequest = Nothing
                        Case 5 ' Will Supply
                            ' Update Request
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.Status = 3
                            objBILLOutRequest.RespondDate = strToday
                            objBILLOutRequest.UpdateOR()

                            ' Insert Log
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.ResponderID = intLibID
                            objBILLOutRequest.APDUType = 4
                            objBILLOutRequest.TRE = 5
                            objBILLOutRequest.ReasonID = intCondition
                            objBILLOutRequest.ProvidedDate = strProvidedDate
                            objBILLOutRequest.Note = strNote
                            objBILLOutRequest.Alert = 1
                            objBILLOutRequest.InsertORequestLog()
                    End Select

                    If objBCDBS.ErrorCode > 0 Then
                        strErrorMsg = objBCDBS.ErrorMsg
                        intErrorCode = objBCDBS.ErrorCode
                    Else
                        strErrorMsg = objBILLOutRequest.ErrorMsg
                        intErrorCode = objBILLOutRequest.ErrorCode
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SaveOVERDU method
        Private Sub SaveOVERDU()
            Dim intRenewable As Integer
            Dim strDueDate As String

            Try
                If Not (intILLID_OUT = 0 Or intLibID = 0) Then
                    intRenewable = ConvertNumber(GetValue("date-due.renewable"))
                    strDueDate = GetValue("date-due.date-due-field")
                    strDueDate = ConvertDate(strDueDate)

                    If Not intRenewable = 1 Then
                        intRenewable = 0
                    End If


                    ' Update Request
                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.Status = 13
                    objBILLOutRequest.UpdateOR()

                    ' Insert Log
                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.ResponderID = intLibID
                    objBILLOutRequest.APDUType = 12
                    objBILLOutRequest.TransactionDate = strToday
                    objBILLOutRequest.DueDate = strDueDate
                    objBILLOutRequest.Renewable = intRenewable
                    objBILLOutRequest.Note = strNote
                    objBILLOutRequest.Alert = 1
                    objBILLOutRequest.InsertORequestLog()
                End If

                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SaveRECALL method
        Private Sub SaveRECALL()
            Try
                If Not (intILLID_OUT = 0 Or intLibID = 0) Then

                    ' Update Request
                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.Status = 16
                    objBILLOutRequest.UpdateOR()

                    ' Insert Log
                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.ResponderID = intLibID
                    objBILLOutRequest.APDUType = 9
                    objBILLOutRequest.Note = strNote
                    objBILLOutRequest.Alert = 1
                    objBILLOutRequest.InsertORequestLog()
                End If

                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SaveRENANS method
        Private Sub SaveRENANS()
            Dim intRenewable As Integer
            Dim strDueDate As String
            Dim intAnswer As Integer
            Dim strSQL As String

            Try
                If Not (intILLID_OUT = 0 Or intLibID = 0) Then
                    intRenewable = ConvertNumber(GetValue("date-due.renewable"))
                    intAnswer = ConvertNumber(GetValue("answer"))
                    strDueDate = GetValue("date-due.date-due-field")
                    strDueDate = ConvertDate(strDueDate)

                    If intAnswer = 1 Then
                        ' Update Request
                        objBILLOutRequest.IllID = intILLID_OUT
                        objBILLOutRequest.Status = 8
                        objBILLOutRequest.DueDate = strDueDate
                        objBILLOutRequest.Renewals = -3
                        objBILLOutRequest.SubSQL = "Status = 10"
                        objBILLOutRequest.UpdateOR()

                        ' Insert Log
                        objBILLOutRequest.IllID = intILLID_OUT
                        objBILLOutRequest.ResponderID = intLibID
                        objBILLOutRequest.APDUType = 14
                        objBILLOutRequest.TransactionDate = strToday
                        objBILLOutRequest.DueDate = strDueDate
                        objBILLOutRequest.Renewable = intRenewable
                        objBILLOutRequest.Note = strNote
                        objBILLOutRequest.Alert = 1
                        objBILLOutRequest.Answer = 1
                        objBILLOutRequest.InsertORequestLog()
                    Else
                        ' Update Request
                        objBILLOutRequest.IllID = intILLID_OUT
                        objBILLOutRequest.Status = 13
                        objBILLOutRequest.SubSQL = "Status = 10"
                        objBILLOutRequest.UpdateOR()

                        ' Insert Log
                        objBILLOutRequest.IllID = intILLID_OUT
                        objBILLOutRequest.ResponderID = intLibID
                        objBILLOutRequest.APDUType = 14
                        objBILLOutRequest.TransactionDate = strToday
                        objBILLOutRequest.Note = strNote
                        objBILLOutRequest.Alert = 1
                        objBILLOutRequest.Answer = 0
                        objBILLOutRequest.InsertORequestLog()
                    End If

                    'strSQL = "UPDATE ILL_OUTGOING_REQUESTS_LOG SET Alert = 0 WHERE " & _
                    '"LogID IN (SELECT LogID FROM ILL_OUTGOING_REQUESTS_LOG WHERE APDUType = 13 AND Alert = 1 " & _
                    '"AND ID = " & intILLID_OUT & ")"

                    'objBCDBS.SQLStatement = strSQL
                    'objBCDBS.ProcessItem()
                End If

                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SaveSHIPED method
        Private Sub SaveSHIPED()
            Dim SQL As String
            Dim strShippedDate, strDueDate As String
            Dim strCost, strInsuredForCost, strReturnInsuranceCost As String
            Dim strCurrencyCode1, strCurrencyCode2, strCurrencyCode3 As String
            Dim intRenewable As Integer
            Dim strChargeableUnits As String
            Dim strServiceType

            Try
                ' get the values
                strShippedDate = GetValue("supply-details.date-shipped")
                strShippedDate = ConvertDate(strShippedDate)
                strDueDate = GetValue("supply-details.date-due.date-due-field")
                strDueDate = ConvertDate(strDueDate)
                intRenewable = ConvertNumber(GetValue("supply-details.date-due.renewable"))
                strCost = GetValue("supply-details.cost.monetary-value")
                strCurrencyCode1 = GetValue("supply-details.cost.currency-code")
                strInsuredForCost = GetValue("supply-details.insured-for.monetary-value")
                strCurrencyCode2 = GetValue("supply-details.insured-for.currency-code")
                strReturnInsuranceCost = GetValue("supply-details.return-insurance-require.monetary-value")
                strCurrencyCode3 = GetValue("supply-details.return-insurance-require.currency-code")
                strChargeableUnits = GetValue("supply-details.chargeable-units")
                strServiceType = GetValue("shipped-service-type")

                If Not (intILLID_OUT = 0 Or intLibID = 0) Then
                    ' ShippedDate
                    If Trim(strShippedDate) = "" Then
                        strShippedDate = "NULL"
                    End If
                    ' DueDate
                    If Trim(strDueDate) = "" Then
                        strDueDate = "NULL"
                    End If
                    ' Cost
                    If Trim(strCost) = "" Then
                        strCost = Trim(strCost)
                    End If
                    ' InsuredForCost
                    If Trim(strInsuredForCost) = "" Then
                        strInsuredForCost = "NULL"
                    Else
                        strInsuredForCost = Trim(strInsuredForCost)
                    End If
                    ' ReturnInsuranceCost
                    If Trim(strReturnInsuranceCost) = "" Then
                        strReturnInsuranceCost = "NULL"
                    Else
                        strReturnInsuranceCost = Trim(strReturnInsuranceCost)
                    End If
                    ' Renewable
                    If Not intRenewable = 1 Then
                        intRenewable = 0
                    End If
                    ' ChargeableUnits
                    If Not Trim(strChargeableUnits) = "" Then
                        strChargeableUnits = Trim(strChargeableUnits)
                    Else
                        strChargeableUnits = "0"
                    End If

                    ' Update request

                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.Status = 8
                    objBILLOutRequest.ShippedDate = strShippedDate
                    objBILLOutRequest.RespondDate = strToday
                    objBILLOutRequest.Renewable = intRenewable
                    objBILLOutRequest.DueDate = strDueDate
                    objBILLOutRequest.Renewals = 0
                    If IsNumeric(strServiceType) Then
                        objBILLOutRequest.ServiceType = CInt(strServiceType)
                    End If
                    If IsNumeric(strCost) Then
                        objBILLOutRequest.Cost = CDbl(strCost)
                    End If
                    objBILLOutRequest.CurrencyCode1 = strCurrencyCode1
                    objBILLOutRequest.CurrencyCode2 = strCurrencyCode2
                    objBILLOutRequest.CurrencyCode3 = strCurrencyCode3
                    If IsNumeric(strInsuredForCost) Then
                        objBILLOutRequest.InsuredForCost = CDbl(strInsuredForCost)
                    Else
                        If strInsuredForCost = "NULL" Then
                            objBILLOutRequest.InsuredForCost = -2
                        End If
                    End If
                    If IsNumeric(strReturnInsuranceCost) Then
                        objBILLOutRequest.ReturnInsuranceCost = CDbl(strReturnInsuranceCost)
                    Else
                        If strReturnInsuranceCost = "NULL" Then
                            objBILLOutRequest.ReturnInsuranceCost = -2
                        End If
                    End If
                    If IsNumeric(strChargeableUnits) Then
                        objBILLOutRequest.ChageableUnits = CInt(strChargeableUnits)
                    End If
                    objBILLOutRequest.SubSQL = "Status IN (2, 3)"
                    Call objBILLOutRequest.UpdateOR()
                    ' Insert Log
                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.ResponderID = intLibID
                    objBILLOutRequest.ProvidedDate = strShippedDate
                    objBILLOutRequest.APDUType = 3
                    objBILLOutRequest.TransactionDate = strToday
                    objBILLOutRequest.Note = strNote
                    objBILLOutRequest.Alert = 1
                    If IsNumeric(strCost) Then
                        objBILLOutRequest.Cost = CDbl(strCost)
                    End If
                    objBILLOutRequest.CurrencyCode1 = strCurrencyCode1
                    objBILLOutRequest.CurrencyCode2 = strCurrencyCode2
                    objBILLOutRequest.CurrencyCode3 = strCurrencyCode3
                    objBILLOutRequest.DueDate = strDueDate
                    objBILLOutRequest.Renewable = intRenewable
                    If IsNumeric(strInsuredForCost) Then
                        objBILLOutRequest.InsuredForCost = CDbl(strInsuredForCost)
                    Else
                        If strInsuredForCost = "NULL" Then
                            objBILLOutRequest.InsuredForCost = -2
                        End If
                    End If
                    If IsNumeric(strReturnInsuranceCost) Then
                        objBILLOutRequest.ReturnInsuranceCost = CDbl(strReturnInsuranceCost)
                    Else
                        If strReturnInsuranceCost = "NULL" Then
                            objBILLOutRequest.ReturnInsuranceCost = -2
                        End If
                    End If

                    objBILLOutRequest.Renewable = intRenewable
                    objBILLOutRequest.DueDate = strDueDate
                    If IsNumeric(strServiceType) Then
                        objBILLOutRequest.ServiceType = CInt(strServiceType)
                    End If
                    objBILLOutRequest.InsertORequestLog()
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SaveCNLREP method
        Private Sub SaveCNLREP()
            Dim intAnswer As Integer
            Dim strSQL As String
            Dim tblTemp As DataTable
            Try

                If Not (intILLID_OUT = 0 Or intLibID = 0) Then
                    ' get the value
                    intAnswer = ConvertNumber(GetValue("answer"))

                    If intAnswer = 1 Then
                        ' Update request
                        objBILLOutRequest.IllID = intILLID_OUT
                        objBILLOutRequest.Status = 7
                        objBILLOutRequest.CancelledDate = strToday
                        objBILLOutRequest.UpdateOR()

                        ' Insert Log
                        objBILLOutRequest.IllID = intILLID_OUT
                        objBILLOutRequest.ResponderID = intLibID
                        objBILLOutRequest.APDUType = 7
                        objBILLOutRequest.TransactionDate = strToday
                        objBILLOutRequest.Answer = intAnswer
                        objBILLOutRequest.Note = strNote
                        objBILLOutRequest.Alert = 1
                        objBILLOutRequest.InsertORequestLog()
                    Else
                        ' See if there is a SHIPPED APDU that had ever been sent earlier for this request
                        objBCDBS.SQLStatement = "SELECT LogID FROM ILL_OUTGOING_REQUESTS_LOG WHERE APDUType = 3 AND ID = " & CStr(intILLID_OUT)
                        tblTemp = objBCDBS.RetrieveItemInfor
                        ' If there is, change back to SHIPPED status
                        If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                            ' Update request
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.Status = 8
                            objBILLOutRequest.SubSQL = "Status = 6"
                            objBILLOutRequest.UpdateOR()
                            ' otherwise change back to IN-PROCESS satus
                        Else
                            ' Update request
                            objBILLOutRequest.IllID = intILLID_OUT
                            objBILLOutRequest.Status = 3
                            objBILLOutRequest.SubSQL = "Status = 6"
                            objBILLOutRequest.UpdateOR()
                        End If

                        ' Insert Log
                        objBILLOutRequest.IllID = intILLID_OUT
                        objBILLOutRequest.ResponderID = intLibID
                        objBILLOutRequest.APDUType = 7
                        objBILLOutRequest.TransactionDate = strToday
                        objBILLOutRequest.Answer = 0
                        objBILLOutRequest.Note = strNote
                        objBILLOutRequest.Alert = 1
                        objBILLOutRequest.InsertORequestLog()
                    End If

                    'tblTemp = Nothing
                    'objBCDBS.SQLStatement = "SELECT * FROM ILL_OUTGOING_REQUESTS_LOG WHERE  ILL_OUTGOING_REQUESTS_LOG.ID = " & CStr(intILLID_OUT) & " AND Alert = 1 AND APDUType = 6 ORDER BY TransactionDate"
                    'tblTemp = objBCDBS.RetrieveItemInfor

                    'If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    '    objBCDBS.SQLStatement = "UPDATE ILL_OUTGOING_REQUESTS_LOG SET Alert = 0 WHERE LogID = " & CStr(tblTemp.Rows(0).Item("LogID"))
                    '    'objBCDBS.ProcessItem()
                    'End If
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method : SaveILLREQ
        Private Sub SaveILLREQ()
            Dim strCode As String
            Dim strRequestDate As String
            Dim strNeedBeforeDate As String
            Dim strExpiryDate As String
            Dim strMaxCost As String
            Dim strStatus As String
            Dim intReciprocalAgreement As Int16
            Dim intWillPayFee As Int16
            Dim intDelivMode As Int16
            Dim intPriority As Int16
            Dim intPaymentType As Int16
            Dim strEDelivMode As String
            Dim strEDelivTSAddr As String
            Dim strTelephone As String
            Dim strEmailReplyAddress As String
            Dim strPostDelivName As String
            Dim strPostDelivXAddress As String
            Dim strPostDelivStreet As String
            Dim strPostDelivBox As String
            Dim strPostDelivCity As String
            Dim strPostDelivCountry As String
            Dim strPostDelivCode As String
            Dim strPostDelivRegion As String
            Dim strBillDelivName As String
            Dim strBillDelivXAddress As String
            Dim strBillDelivStreet As String
            Dim strBillDelivBox As String
            Dim strBillDelivCity As String
            Dim strBillDelivCountry As String
            Dim strBillDelivCode As String
            Dim strBillDelivRegion As String
            Dim intServiceType As Integer
            Dim intCanSendReceived As String
            Dim intCanSendReturned As String
            Dim intRequesterShipped As String
            Dim intRequesterCheckedIn As String
            Dim strLevelOfService As String
            Dim strExpiryFlag As String
            Dim intMediumInfoType As Integer
            Dim strMediumInfoType As String
            Dim strPlaceOnHold As String
            Dim strClientName As String
            Dim strClientID As String
            Dim strClientStatus As String
            Dim intItemType As Integer
            Dim strHeldMediumType As String
            Dim strCallNumber As String
            Dim strAuthor As String
            Dim strTitle As String
            Dim strSubTitle As String
            Dim strSponsoringBody As String
            Dim strPlaceOfPub As String
            Dim strPublisher As String
            Dim strSeriesTitleNumber As String
            Dim strVolumeIssue As String
            Dim strEdition As String
            Dim strPubDate As String
            Dim strComponentPubDate As String
            Dim strArticleAuthor As String
            Dim strArticleTitle As String
            Dim strPagination As String
            Dim strNationalBibNumber As String
            Dim strISBN As String
            Dim strISSN As String
            Dim strSystemNumber As String
            Dim strOtherNumbers As String
            Dim strVerification As String
            Dim strAccountNumber As String
            Dim strCurrencyCode As String
            Dim strMonetaryValue As String
            Dim strReciprocalAgreement As String
            Dim intPaymentProvided As Integer
            Dim intCopyrightCompliance As Integer
            Dim tblTemp As DataTable
            Dim dvTemp As DataView
            Dim strSQL As String
            Dim lngIDTemp As Long
            Dim intPostDelivCountry As Integer = 0
            Dim intBillDelivCountry As Integer = 0

            Try
                ' La^'y gia' tri. cho ca'c bie^'n

                'lay thong tin delivery-address
                'neu mode =1
                strEDelivMode = GetValue("delivery-address.electronic-address.telecom-service-identifier")
                strEDelivTSAddr = GetValue("delivery-address.electronic-address.telecom-service-address")
                strTelephone = ""
                strEmailReplyAddress = Trim(GetValue("From"))
                ' neu mode =2
                strPostDelivName = GetValue("delivery-address.postal-address.name-of-person-or-institution.name-of-institution")
                strPostDelivXAddress = GetValue("delivery-address.postal-address.extended-postal-delivery-address")
                strPostDelivStreet = GetValue("delivery-address.postal-address.street-and-number")
                strPostDelivBox = GetValue("delivery-address.postal-address.post-office-box")
                strPostDelivCity = GetValue("delivery-address.postal-address.city")
                strPostDelivCode = GetValue("delivery-address.postal-address.postal-code")
                strPostDelivRegion = GetValue("delivery-address.postal-address.region")
                strPostDelivCountry = GetValue("delivery-address.postal-address.country")

                'lay thong tin billing_address
                strBillDelivName = GetValue("billing-address.postal-address.name-of-person-or-institution.name-of-institution")
                strBillDelivXAddress = GetValue("billing-address.postal-address.extended-postal-delivery-address")
                strBillDelivStreet = GetValue("billing-address.postal-address.street-and-number")
                strBillDelivBox = GetValue("billing-address.postal-address.post-office-box")
                strBillDelivCity = GetValue("billing-address.postal-address.city")
                strBillDelivCode = GetValue("billing-address.postal-address.postal-code")
                strBillDelivRegion = GetValue("billing-address.postal-address.region")
                strBillDelivCountry = GetValue("billing-address.postal-address.country")

                tblTemp = objBCommonBusiness.GetCountries()
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    dvTemp = New DataView
                    dvTemp.Table = tblTemp
                    dvTemp.RowFilter = "DisplayEntry ='" & strPostDelivCountry & "'"
                    If dvTemp.Count > 0 Then
                        intPostDelivCountry = dvTemp.Item(0).Row("ID").ToString
                    End If
                    dvTemp = Nothing

                    dvTemp = New DataView
                    dvTemp.Table = tblTemp
                    dvTemp.RowFilter = "DisplayEntry ='" & strBillDelivCountry & "'"
                    If dvTemp.Count > 0 Then
                        intBillDelivCountry = dvTemp.Item(0).Row("ID").ToString
                    End If
                    dvTemp = Nothing
                End If

                intServiceType = ConvertNumber(GetValue("ill-service-type"))
                intCanSendReceived = ConvertNumber(GetValue("requester-optional-messages.can-send-received"))
                intCanSendReturned = ConvertNumber(GetValue("requester-optional-messages.can-send-returned"))
                intRequesterShipped = ConvertNumber(GetValue("requester-optional-messages.requester-shipped"))
                intRequesterCheckedIn = ConvertNumber(GetValue("requester-optional-messages.requester-checked-in"))

                strLevelOfService = GetValue("search-type.level-of-service")
                strNeedBeforeDate = GetValue("search-type.need-before-date")
                'strNeedBeforeDate = ConvertDate(strNeedBeforeDate)
                strExpiryFlag = GetValue("search-type.expiry-flag")
                strExpiryDate = GetValue("search-type.expiry-date")
                'strExpiryDate = ConvertDate(strExpiryDate)

                intMediumInfoType = ConvertNumber(GetValue("supply-medium-info-type.supply-medium-type"))
                strMediumInfoType = GetValue("supply-medium-info-type.medium-characteristics")
                strPlaceOnHold = GetValue("place-on-hold")

                strClientName = GetValue("client-id.client-name")
                strClientID = GetValue("client-id.client-identifier")
                strClientStatus = GetValue("client-id.client-status")

                intItemType = ConvertNumber(GetValue("item-id.item-type"))
                strHeldMediumType = GetValue("item-id.held-medium-type")
                strCallNumber = GetValue("item-id.call-number")
                strAuthor = GetValue("item-id.author")
                strTitle = GetValue("item-id.title")
                strSubTitle = GetValue("item-id.sub-title")
                strSponsoringBody = GetValue("item-id.sponsoring-body")
                strPlaceOfPub = GetValue("item-id.place-of-publication")
                strPublisher = GetValue("item-id.publisher")
                strSeriesTitleNumber = GetValue("item-id.series-title-number")
                strVolumeIssue = GetValue("item-id.volume-issue")
                strEdition = GetValue("item-id.edition")
                strPubDate = GetValue("item-id.publication-date")
                'strPubDate = ConvertDate(strPubDate)
                strComponentPubDate = GetValue("item-id.publication-date-of-component")
                'strComponentPubDate = ConvertDate(strComponentPubDate)
                strArticleAuthor = GetValue("item-id.author-of-article")
                strArticleTitle = GetValue("item-id.title-of-article")
                strPagination = GetValue("item-id.pagination")
                strNationalBibNumber = GetValue("item-id.national-bibliography-no.descriptor")
                strISBN = GetValue("item-id.isbn")
                strISSN = GetValue("item-id.issn")
                strSystemNumber = GetValue("item-id.system-no.descriptor")
                strOtherNumbers = GetValue("item-id.additional-no-letters")
                strVerification = GetValue("item-id.verification-reference-source")

                strAccountNumber = GetValue("cost-info-type.account-number")
                strCurrencyCode = GetValue("cost-info-type.maximum-cost.currency-code")
                strMonetaryValue = GetValue("cost-info-type.maximum-cost.monetary-value")

                If IsNumeric(strMonetaryValue) Then
                    strMaxCost = strMonetaryValue
                Else
                    strMaxCost = "-2"
                End If
                strReciprocalAgreement = GetValue("cost-info-type.reciprocal-agreement")
                intWillPayFee = ConvertNumber(GetValue("cost-info-type.will-pay-fee"))
                intPaymentProvided = ConvertNumber(GetValue("cost-info-type.payment-provided"))
                intCopyrightCompliance = ConvertNumber(GetValue("copyright-compliance"))

                intPriority = CInt(strPlaceOnHold)
                intPaymentType = -2

                ' Kiem tra thong tin thu vien gui yeu toi neu khong co thi tao moi
                If intLibID = 0 Then
                    tblTemp = Nothing
                    objBIllLibary.LibID = 0
                    tblTemp = objBIllLibary.GetLib(-1)
                    Randomize()
                    strCode = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                    dvTemp = Nothing
                    dvTemp = New DataView
                    dvTemp.Table = tblTemp
                    dvTemp.RowFilter = "Code = '" & strCode & "'"
                    Do While dvTemp.Count > 0
                        strCode = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                        dvTemp = Nothing
                        dvTemp = New DataView
                        dvTemp.Table = tblTemp
                        dvTemp.RowFilter = "Code = '" & strCode & "'"
                    Loop
                    objBIllLibary.LibrarySymbol = Trim(strRequesterSymbol)
                    objBIllLibary.LibraryName = strRequesterName
                    objBIllLibary.PostDelivName = strPostDelivName
                    objBIllLibary.PostDelivXAddr = strPostDelivXAddress
                    objBIllLibary.PostDelivStreet = strPostDelivStreet
                    objBIllLibary.PostDelivBox = strPostDelivBox
                    objBIllLibary.PostDelivCity = strPostDelivCity
                    objBIllLibary.PostDelivRegion = strPostDelivRegion
                    objBIllLibary.PostDelivCountry = intPostDelivCountry
                    objBIllLibary.PostDelivCode = strPostDelivCode
                    objBIllLibary.EDelivMode = strEDelivMode
                    objBIllLibary.EDelivTSAddr = strEDelivTSAddr
                    objBIllLibary.Telephone = strTelephone
                    objBIllLibary.EmailReplyAddress = strEmailReplyAddress
                    objBIllLibary.BillDelivName = strBillDelivName
                    objBIllLibary.BillDelivXAddr = strBillDelivXAddress
                    objBIllLibary.BillDelivStreet = strBillDelivStreet
                    objBIllLibary.BillDelivBox = strBillDelivBox
                    objBIllLibary.BillDelivCity = strBillDelivCity
                    objBIllLibary.BillDelivRegion = strBillDelivRegion
                    objBIllLibary.BillDelivCountry = intBillDelivCountry
                    objBIllLibary.BillDelivCode = strBillDelivCode
                    objBIllLibary.LibraryCode = strCode
                    objBIllLibary.AccountNumber = strAccountNumber
                    intLibID = objBIllLibary.Create()
                End If
                strRequestDate = strToday


                If Not Trim(strMaxCost) = "" Then
                    strMaxCost = Trim(strMaxCost)
                Else
                    strMaxCost = "-2"
                End If

                strStatus = "21"

                If Not strReciprocalAgreement = "" Then
                    intReciprocalAgreement = 1
                Else
                    intReciprocalAgreement = 0
                End If
                If Not Trim(strPostDelivName) = "" Then
                    intDelivMode = 2
                Else
                    intDelivMode = 1
                End If
                ' Ba't dda^`u Transaction
                objBILLInRequest.RequesterID = intLibID
                objBILLInRequest.RequestIDCode = strRequestID
                objBILLInRequest.RequestDate = strRequestDate
                objBILLInRequest.NeedBeforeDate = strNeedBeforeDate
                objBILLInRequest.ExpiryDate = strExpiryDate
                objBILLInRequest.ServiceType = intServiceType
                objBILLInRequest.CopyrightCompliance = intCopyrightCompliance
                objBILLInRequest.Priority = intPriority
                objBILLInRequest.MaxCost = CDbl(strMaxCost)
                objBILLInRequest.CurrencyCode = strCurrencyCode
                objBILLInRequest.PaymentType = intPaymentType
                objBILLInRequest.ItemType = intItemType
                objBILLInRequest.ReciprocalAgreement = strReciprocalAgreement
                objBILLInRequest.WillPayFee = intWillPayFee
                objBILLInRequest.PaymentProvided = intPaymentProvided
                objBILLInRequest.Medium = intMediumInfoType
                objBILLInRequest.DelivMode = intDelivMode
                objBILLInRequest.EDelivMode = strEDelivMode
                objBILLInRequest.EDelivTSAddr = strEDelivTSAddr
                objBILLInRequest.EmailReplyAddress = strEmailReplyAddress
                objBILLInRequest.Note = strNote
                objBILLInRequest.PatronName = Trim(strClientName)
                objBILLInRequest.PatronID = Trim(strClientID)
                objBILLInRequest.PatronStatus = strClientStatus
                objBILLInRequest.Status = CInt(strStatus)
                objBILLInRequest.Title = strTitle
                objBILLInRequest.Alert = 1

                lngIDTemp = objBILLInRequest.CreateIR()

                ' Create request Item
                objBILLInRequest.CreateIRItem(lngIDTemp, strCallNumber, strTitle, strAuthor, strPlaceOfPub, strPublisher, strSeriesTitleNumber, strVolumeIssue, strEdition, strPubDate, strComponentPubDate, strArticleAuthor, strArticleTitle, strPagination, strNationalBibNumber, strISBN, strISSN, intItemType, strSystemNumber, strOtherNumbers, strVerification, "", strSponsoringBody, 1)
                ' Create Post Deliv infor
                If Not Trim(strPostDelivName) = "" Then
                    objBILLInRequest.CreateInRequestPostInfor(lngIDTemp, strPostDelivName, strPostDelivXAddress, strPostDelivStreet, strPostDelivBox, strPostDelivCity, strPostDelivRegion, CInt(intPostDelivCountry), strPostDelivCode)
                End If
                ' Create Bill Deliv Infor
                If Not Trim(strBillDelivName) = "" Then
                    objBILLInRequest.CreateInRequestBillInfor(lngIDTemp, strBillDelivName, strBillDelivXAddress, strBillDelivStreet, strBillDelivBox, strBillDelivCity, strBillDelivRegion, CInt(intBillDelivCountry), strBillDelivCode)
                End If
                ' Insert Log
                'ID, RequesterID, TransactionDate, Note, APDUType, ProvidedDate, Alert, ServiceType, DueDate
                objBILLInRequest.ILLID = lngIDTemp
                objBILLInRequest.RequesterID = intLibID
                objBILLInRequest.TransactionDate = ""
                objBILLInRequest.Note = strNote
                objBILLInRequest.APDUType = 1
                objBILLInRequest.ProvidedDate = strToday
                objBILLInRequest.Alert = 1
                objBILLInRequest.ServiceType = intServiceType
                objBILLInRequest.DueDate = strExpiryDate

                objBILLInRequest.InsertIRequestLog()

                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SaveRCEIVD method
        Private Sub SaveRCEIVD()
            Dim intLogID As Integer
            Dim strReceivedDate As String
            Dim intServiceType As Integer
            Dim tblTemp As DataTable
            Try
                If Not (intILLID_IN = 0 Or intLibID = 0) Then
                    ' La^'y ca'c gia' tri.

                    strReceivedDate = GetValue("date-received")
                    intServiceType = ConvertNumber(GetValue("shipped-service-type"))
                    If Trim(strReceivedDate) = "" Then
                        strReceivedDate = "NULL"
                    Else
                        strReceivedDate = ConvertDate(strReceivedDate)
                    End If

                    objBILLInRequest.ReceivedDate = strReceivedDate
                    objBILLInRequest.ILLID = intILLID_IN
                    If intServiceType = 2 Then
                        objBILLInRequest.Status = 22
                        objBILLInRequest.UpdateIR()
                    Else
                        objBILLInRequest.Status = 9
                        objBILLInRequest.UpdateIR()
                    End If

                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.RequesterID = intLibID
                    objBILLInRequest.APDUType = 8
                    objBILLInRequest.TransactionDate = strToday
                    objBILLInRequest.Note = strNote
                    objBILLInRequest.Alert = 1
                    objBILLInRequest.ProvidedDate = strReceivedDate
                    objBILLInRequest.InsertIRequestLog()

                    'objBCDBS.SQLStatement = "SELECT A.LogID FROM ILL_INCOMING_REQUESTS_LOG A LEFT JOIN ILL_RESPONSES B ON B.ID = A.ReasonID WHERE A.ID = " & CStr(intILLID_IN) & " AND APDUType = 3 ORDER BY A.TransactionDate DESC"
                    'tblTemp = objBCDBS.RetrieveItemInfor
                    'If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    '    objBCDBS.SQLStatement = "UPDATE ILL_INCOMING_REQUESTS_LOG SET Alert = 0 WHERE LogID = " & tblTemp.Rows(0).Item("LogID")
                    '    'objBCDBS.ProcessItem()
                    'End If
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: SaveCANCEL
        Private Sub SaveCANCEL()
            Try
                If Not (intILLID_IN = 0 Or intLibID = 0) Then


                    objBILLInRequest.Status = 6
                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.UpdateIR()


                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.RequesterID = intLibID
                    objBILLInRequest.TransactionDate = strToday
                    objBILLInRequest.Note = strNote
                    objBILLInRequest.APDUType = 6
                    objBILLInRequest.Alert = 1
                    objBILLInRequest.InsertIRequestLog()
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Sub

        ' Method : SaveRENEWL
        Private Sub SaveRENEWL()
            Dim strDesiredDueDate As String

            Try
                If Not (intILLID_IN = 0 Or intLibID = 0) Then
                    ' La^'y ra ca'c gia' tri.
                    strDesiredDueDate = GetValue("desired-due-date")
                    If strDesiredDueDate = "" Then
                        strDesiredDueDate = "NULL"
                    Else
                        strDesiredDueDate = ConvertDate(strDesiredDueDate)
                    End If

                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.Status = 10
                    objBILLInRequest.BoolSQL = "Status IN (9, 11,12, 13)"
                    objBILLInRequest.UpdateIR()


                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.RequesterID = intLibID
                    objBILLInRequest.TransactionDate = strToday
                    objBILLInRequest.DueDate = strDesiredDueDate
                    objBILLInRequest.Note = strNote
                    objBILLInRequest.APDUType = 13
                    objBILLInRequest.Alert = 1
                    objBILLInRequest.InsertIRequestLog()

                    'objBCDBS.SQLStatement = "UPDATE ILL_INCOMING_REQUESTS_LOG SET Alert = 0 WHERE logID IN (SELECT LOGID FROM ILL_INCOMING_REQUESTS_LOG WHERE ID=" & CStr(intILLID_IN) & ")"
                    'objBCDBS.ProcessItem()
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method: SaveRETRND
        Private Sub SaveRETRND()
            Dim strReturnedDate As String
            Dim strInsuredForCost As String
            Dim strCurrencyCode As String
            Dim strReturnedVia As String
            Try
                If Not (intILLID_IN = 0 Or intLibID = 0) Then
                    ' La^'y ra ca'c gia' tri.
                    strReturnedDate = GetValue("date-returned")
                    strInsuredForCost = GetValue("insured-for.monetary-value")
                    strCurrencyCode = GetValue("insured-for.currency-code")

                    strReturnedVia = Replace(GetValue("returned-via"), "'", "''")

                    If Trim(strReturnedDate) = "" Then
                        strReturnedDate = "NULL"
                    Else
                        strReturnedDate = ConvertDate(strReturnedDate)
                    End If

                    If Trim(strInsuredForCost) = "" Then
                        strInsuredForCost = "0"
                    Else
                        strInsuredForCost = Trim(strInsuredForCost)
                    End If


                    objBILLInRequest.Status = 14
                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.ReturnedDate = strReturnedDate
                    objBILLInRequest.UpdateIR()


                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.RequesterID = intLibID
                    objBILLInRequest.TransactionDate = strToday
                    objBILLInRequest.ProvidedDate = strReturnedDate
                    objBILLInRequest.Note = strNote
                    objBILLInRequest.APDUType = 10
                    objBILLInRequest.InsuredForCost = CDbl(strInsuredForCost)
                    objBILLInRequest.CurrencyCode2 = strCurrencyCode
                    objBILLInRequest.ReturnedVia = strReturnedVia
                    objBILLInRequest.Alert = 1
                    objBILLInRequest.InsertIRequestLog()
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Method : SaveCONREP
        Private Sub SaveCONREP()
            Dim intAnswer, SQL
            Dim strRequestDate As String
            Dim strReasonID As String
            Dim strRespondDate As String
            Dim LogID
            Dim tblTemp As DataTable

            Try
                If Not (intILLID_IN = 0 Or intLibID = 0) Then
                    intAnswer = ConvertNumber(GetValue("answer"))

                    If intAnswer = 1 Then

                        objBILLInRequest.Status = 3
                        objBILLInRequest.ILLID = intILLID_IN
                        objBILLInRequest.BoolSQL = "Status = 5"
                        objBILLInRequest.UpdateIR()


                        objBILLInRequest.ILLID = intILLID_IN
                        objBILLInRequest.RequesterID = intLibID
                        objBILLInRequest.TransactionDate = strToday
                        objBILLInRequest.Note = strNote
                        objBILLInRequest.APDUType = 5
                        objBILLInRequest.Alert = 1
                        objBILLInRequest.Answer = 1
                        objBILLInRequest.InsertIRequestLog()
                    Else

                        objBILLInRequest.Status = 1
                        objBILLInRequest.CancelledDate = strToday
                        objBILLInRequest.ILLID = intILLID_IN
                        objBILLInRequest.BoolSQL = "Status = 5"
                        objBILLInRequest.UpdateIR()


                        objBILLInRequest.ILLID = intILLID_IN
                        objBILLInRequest.RequesterID = intLibID
                        objBILLInRequest.TransactionDate = strToday
                        objBILLInRequest.Note = strNote
                        objBILLInRequest.APDUType = 5
                        objBILLInRequest.Alert = 1
                        objBILLInRequest.Answer = 0
                        objBILLInRequest.InsertIRequestLog()

                        ' Tra la.i Log dde^? la^'y ra ReasonID, RequestDate, RespondDate
                        objBCDBS.SQLStatement = "SELECT RequestDate, RespondDate FROM Ill_tblInComingRequests WHERE ID = " & CStr(intILLID_IN)
                        tblTemp = objBCDBS.RetrieveItemInfor
                        If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                            strRequestDate = tblTemp.Rows(0).Item("REQUESTDATE")
                            strRespondDate = tblTemp.Rows(0).Item("RESPONDDATE")
                        End If
                        tblTemp = Nothing
                        objBCDBS.SQLStatement = "SELECT ReasonID FROM ILL_INCOMING_REQUESTS_LOG WHERE TRE=1 AND ID = " & CStr(intILLID_IN)
                        tblTemp = objBCDBS.RetrieveItemInfor
                        If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                            strReasonID = tblTemp.Rows(0).Item("ReasonID")
                        End If


                        objBILLInRequest.ILLID = intILLID_IN
                        objBILLInRequest.RequesterID = intLibID
                        objBILLInRequest.RequestDate = strRequestDate
                        objBILLInRequest.RespondDate = strRespondDate
                        objBILLInRequest.ReasonID = strReasonID
                        objBILLInRequest.InsertIRequestDenied()
                    End If
                    'objBCDBS.SQLStatement = "SELECT A.LogID FROM ILL_INCOMING_REQUESTS_LOG A LEFT JOIN ILL_RESPONSES B ON B.ID = A.ReasonID WHERE A.ID = " & CStr(intILLID_IN) & " AND Alert = 1 AND APDUType = 4 AND TRE = 1"
                    'tblTemp = objBCDBS.RetrieveItemInfor
                    'If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    '    objBCDBS.SQLStatement = "UPDATE ILL_INCOMING_REQUESTS_LOG SET Alert = 0 WHERE LogID = " & tblTemp.Rows(0).Item("LogID")
                    '    'objBCDBS.ProcessItem()
                    'End If
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                Else
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SaveMESSAG method
        Private Sub SaveMESSAG()
            Try
                If Not intILLID_OUT = 0 Then
                    ' Insert Log
                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.ResponderID = intLibID
                    objBILLOutRequest.APDUType = 17
                    objBILLOutRequest.TransactionDate = strToday
                    objBILLOutRequest.Note = strNote
                    objBILLOutRequest.Alert = 1
                    objBILLOutRequest.InsertORequestLog()
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
                If Not intILLID_IN = 0 Then
                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.RequesterID = intLibID
                    objBILLInRequest.TransactionDate = strToday
                    objBILLInRequest.Note = strNote
                    objBILLInRequest.Alert = 1
                    objBILLInRequest.APDUType = 17
                    objBILLInRequest.InsertIRequestLog()
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Sub

        ' Function : SaveSTATUS
        Private Function SaveSTATUS() As String
            Dim tblTemp As DataTable
            Dim strStatusReply As String = "Unidentified state"
            Try
                If Not intILLID_OUT = 0 Then
                    objBCDBS.SQLStatement = "SELECT B.State,B.DisplayState FROM ILL_OUTGOING_REQUESTS A join ILL_REQUEST_STATUS B on A.Status=B.ID WHERE A.ID = " & CStr(intILLID_OUT)
                    tblTemp = objBCDBS.RetrieveItemInfor
                    If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                        strStatusReply = tblTemp.Rows(0).Item("State") & " (" & tblTemp.Rows(0).Item("DisplayState") & ")"
                    End If
                    ' Insert Log

                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.ResponderID = intLibID
                    objBILLOutRequest.APDUType = 18
                    objBILLOutRequest.TransactionDate = strToday
                    objBILLOutRequest.Note = strNote
                    objBILLOutRequest.Alert = 1
                    objBILLOutRequest.InsertORequestLog()
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
                If Not intILLID_IN = 0 Then
                    objBCDBS.SQLStatement = "SELECT B.State,B.DisplayState FROM Ill_tblInComingRequests A join ILL_REQUEST_STATUS B on A.Status=B.ID WHERE A.ID = " & CStr(intILLID_IN)
                    tblTemp = objBCDBS.RetrieveItemInfor
                    If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                        strStatusReply = tblTemp.Rows(0).Item("State") & " (" & tblTemp.Rows(0).Item("DisplayState") & ")"
                    End If

                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.RequesterID = intLibID
                    objBILLInRequest.TransactionDate = strToday
                    objBILLInRequest.Note = strNote
                    objBILLInRequest.Alert = 1
                    objBILLInRequest.APDUType = 18
                    objBILLInRequest.InsertIRequestLog()
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
                If objBCDBS.ErrorCode > 0 Then
                    strErrorMsg = objBCDBS.ErrorMsg
                    intErrorCode = objBCDBS.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return strStatusReply
        End Function

        ' Method : SaveLostIT
        Private Sub SaveLOSTIT()
            Try
                If Not intILLID_OUT = 0 Then

                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.Status = 17
                    objBILLOutRequest.UpdateOR()

                    ' Insert Log
                    objBILLOutRequest.IllID = intILLID_OUT
                    objBILLOutRequest.ResponderID = intLibID
                    objBILLOutRequest.APDUType = 15
                    objBILLOutRequest.TransactionDate = strToday
                    objBILLOutRequest.Note = strNote
                    objBILLOutRequest.Alert = 1
                    objBILLOutRequest.InsertORequestLog()
                    strErrorMsg = objBILLOutRequest.ErrorMsg
                    intErrorCode = objBILLOutRequest.ErrorCode
                End If
                If Not intILLID_IN = 0 Then

                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.Status = 17
                    objBILLInRequest.UpdateIR()

                    objBILLInRequest.ILLID = intILLID_IN
                    objBILLInRequest.RequesterID = intLibID
                    objBILLInRequest.APDUType = 15
                    objBILLInRequest.TransactionDate = strToday
                    objBILLInRequest.Note = strNote
                    objBILLInRequest.Alert = 1
                    objBILLInRequest.InsertIRequestLog()
                    strErrorMsg = objBILLInRequest.ErrorMsg
                    intErrorCode = objBILLInRequest.ErrorCode
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try

        End Sub
        ' MessagXmlRecord
        Function MessagXmlRecord(ByVal strStatus As String) As String
            Dim strTemp As String

            ' Kho+?i ta.o ca'c bie^'n chung
            strSubTransactQualifier = "LIBOLILL"
            strTransactGroupQualifier = ""
            ' DDo^?i cho^~ ca'c bie^'n
            strServiceDate = CStr(Year(Now)) & CStr(Month(Now)).PadLeft(2, "0") & CStr(Day(Now)).PadLeft(2, "0")
            strServiceTime = CStr(Hour(Now)).PadLeft(2, "0") & CStr(Minute(Now)).PadLeft(2, "0") & CStr(Second(Now)).PadLeft(2, "0")

            ' Xa^y du+.ng ba?n ghi XML cu?a APDU MESSAG
            strTemp = "<?xml version=""1.0""?>" & vbCrLf
            strTemp = strTemp & "<illapdu type=""MESSAG"" xmlns=""www.GREENHOUSE.com.vn/libol"">" & vbCrLf
            strTemp = strTemp & "<protocol-version-num>" & strProtocolVerNum & "</protocol-version-num>" & vbCrLf
            strTemp = strTemp & "<transaction-id>" & vbCrLf
            strTemp = strTemp & "<initial-requester-id>" & vbCrLf
            strTemp = strTemp & "<person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<institution-symbol>" & strRequesterSymbol & "</institution-symbol>" & vbCrLf
            strTemp = strTemp & "</person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "<name-of-institution>" & strRequesterName & "</name-of-institution>" & vbCrLf
            strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "</initial-requester-id>" & vbCrLf
            strTemp = strTemp & "<transaction-group-qualifier>" & strTransactGroupQualifier & "</transaction-group-qualifier>" & vbCrLf
            strTemp = strTemp & "<transaction-qualifier>" & strRequestID & "</transaction-qualifier>" & vbCrLf
            strTemp = strTemp & "<sub-transaction-qualifier>" & strSubTransactQualifier & "</sub-transaction-qualifier>" & vbCrLf
            strTemp = strTemp & "</transaction-id>" & vbCrLf
            strTemp = strTemp & "<service-date-time>" & vbCrLf
            strTemp = strTemp & "<date-time-of-this-service>" & vbCrLf
            strTemp = strTemp & "<date>" & strServiceDate & "</date>" & vbCrLf
            strTemp = strTemp & "<time>" & strServiceTime & "</time>" & vbCrLf
            strTemp = strTemp & "</date-time-of-this-service>" & vbCrLf
            strTemp = strTemp & "<date-time-of-original-service>" & vbCrLf
            strTemp = strTemp & "<date></date>" & vbCrLf
            strTemp = strTemp & "<time></time>" & vbCrLf
            strTemp = strTemp & "</date-time-of-original-service>" & vbCrLf
            strTemp = strTemp & "</service-date-time>" & vbCrLf
            strTemp = strTemp & "<requester-id>" & vbCrLf
            strTemp = strTemp & "<person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<institution-symbol>" & strRequesterSymbol & "</institution-symbol>" & vbCrLf
            strTemp = strTemp & "</person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "<name-of-institution>" & strRequesterName & "</name-of-institution>" & vbCrLf
            strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "</requester-id>" & vbCrLf
            strTemp = strTemp & "<responder-id>" & vbCrLf
            strTemp = strTemp & "<person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<institution-symbol>" & strResponderSymbol & "</institution-symbol>" & vbCrLf
            strTemp = strTemp & "</person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "<name-of-institution>" & strResponderName & "</name-of-institution>" & vbCrLf
            strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "</responder-id>" & vbCrLf
            If intILLID_IN = 0 And intILLID_OUT = 0 Then
                strTemp = strTemp & "<note>" & strNoStatus & "</note>" & vbCrLf
            Else
                strTemp = strTemp & "<note>" & strReplyStatus & strStatus & "</note>" & vbCrLf
            End If

            strTemp = strTemp & "</illapdu>" & vbCrLf
            MessagXmlRecord = strTemp
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
                    End If
                    If Not objBIllLibary Is Nothing Then
                        objBIllLibary.Dispose(True)
                        objBIllLibary = Nothing
                    End If
                    If Not objBILLInRequest Is Nothing Then
                        objBILLInRequest.Dispose(True)
                        objBILLInRequest = Nothing
                    End If
                    If Not objBCommonBusiness Is Nothing Then
                        objBCommonBusiness.Dispose(True)
                        objBCommonBusiness = Nothing
                    End If
                    If Not objBILLOutRequest Is Nothing Then
                        objBILLOutRequest.Dispose(True)
                        objBILLOutRequest = Nothing
                    End If
                    If Not objBCDBS Is Nothing Then
                        objBCDBS.Dispose(True)
                        objBCDBS = Nothing
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

