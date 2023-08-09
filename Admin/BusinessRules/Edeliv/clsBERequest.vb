Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess
Imports eMicLibAdmin.DataAccess.Edeliv

Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBERequest
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Protected intStatusID As Integer = 0
        Protected lngRequestID As Long = 0
        Protected strSizeOfFile As String = ""
        Protected strSizeOfFileFrom As String = ""
        Protected strSizeOfFileTo As String = ""
        Private objPara() As String = {"SMTP_SERVER", "SMTP_PORT", "ADMIN_EMAIL_ADDRESS", "SERVER_IP_ADDRESS"}
        Private objSysPara() As String

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDERequest As New clsDERequest

        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' SizeOfFileTo property
        Public Property SizeOfFileTo() As String
            Get
                Return strSizeOfFileTo
            End Get
            Set(ByVal Value As String)
                strSizeOfFileTo = Value
            End Set
        End Property

        ' SizeOfFileFrom property
        Public Property SizeOfFileFrom() As String
            Get
                Return strSizeOfFile
            End Get
            Set(ByVal Value As String)
                strSizeOfFileFrom = Value
            End Set
        End Property

        ' StatusID property
        Public Property StatusID() As Integer
            Get
                Return intStatusID
            End Get
            Set(ByVal Value As Integer)
                intStatusID = Value
            End Set
        End Property

        ' RequestID property
        Public Property RequestID() As Long
            Get
                Return lngRequestID
            End Get
            Set(ByVal Value As Long)
                lngRequestID = Value
            End Set
        End Property

        ' SizeOfFile property
        Public Property SizeOfFile() As String
            Get
                Return strSizeOfFile
            End Get
            Set(ByVal Value As String)
                strSizeOfFile = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare public properties
        ' Implement methods here
        ' *************************************************************************************************

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

            ' Init objDERequest object
            objDERequest.DBServer = strDBServer
            objDERequest.ConnectionString = strConnectionString
            objDERequest.Initialize()

            ' Get objSysPara
            objSysPara = objBCDBS.GetSystemParameters(objPara)
        End Sub

        ' GetRequestInfor method
        ' Purpose: Get information of the selected file
        ' Input: RequestID
        ' Output: datatable result
        Public Function GetRequestInfor() As DataTable
            Try
                objDERequest.RequestID = lngRequestID
                GetRequestInfor = objBCDBS.ConvertTable(objDERequest.GetRequestInfor, "TITLE")
                intErrorCode = objDERequest.ErrorCode
                strErrorMsg = objDERequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Delete method
        ' Purpose: delete the selected request record
        ' Input: RequestID
        Public Sub Delete()
            Try
                objDERequest.RequestID = lngRequestID
                Call objDERequest.Delete()
                intErrorCode = objDERequest.ErrorCode
                strErrorMsg = objDERequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' MoveFolder method
        ' Purpose: Move to request to suite folder (Update alert = 0)
        ' Input: RequestID
        Public Sub MoveFolder()
            Try
                objDERequest.RequestID = lngRequestID
                Call objDERequest.MoveFolder()
                intErrorCode = objDERequest.ErrorCode
                strErrorMsg = objDERequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' ChangeStatus method
        ' Purpose: change the status of the selected request record
        ' Input: RequestID, new StatusID
        Public Sub ChangeStatus()
            Try
                objDERequest.RequestID = lngRequestID
                objDERequest.StatusID = intStatusID
                Call objDERequest.ChangeStatus()
                intErrorCode = objDERequest.ErrorCode
                strErrorMsg = objDERequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' SendMessage function
        ' Purpose: send message to customer
        ' Input: some infor of message
        ' Output: int value (0 when success)
        Public Function SendMessage(ByVal lngRequestID, ByVal strSubject, ByVal strContent) As Integer
            Try

            Catch ex As Exception

            End Try
        End Function

        ' GetServerIP function
        ' Purpose: Get server ip address
        ' Output: string value of Server's IPAddress
        Public Function GetServerIP() As String
            Try
                GetServerIP = objSysPara(3)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMailInfor function
        ' Purpose: get information of mail
        ' Input: some infor of message
        ' Output: int value (0 when success)
        Public Function GetMailInfor(ByRef strEmailTo As String) As Integer
            Dim tblTemp As DataTable

            Try
                ' strContent = Trim(Replace(objBCSP.ToUTF8(strContent), Chr(10), "<BR>"))

                objDERequest.RequestID = lngRequestID
                tblTemp = GetRequestInfor()
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        strEmailTo = tblTemp.Rows(0).Item("EmailAddress")
                    End If
                End If
                GetMailInfor = 0
            Catch ex As Exception
                strErrorMsg = ex.Message
                GetMailInfor = 1
            End Try
        End Function

        '' SendMail function
        '' Purpose: send mail to customer
        '' Input: some infor of message
        '' Output: int value (0 when success)
        'Public Function SendMail(ByVal strSubject As String, ByVal strContent As String, Optional ByVal strFileAttach As String = "") As Integer
        '    Dim tblTemp As DataTable
        '    Dim objMail As New ASPEMAILLib.MailSender
        '    Dim strSMTPPort As String = ""
        '    Dim strSMTPServer As String = ""
        '    Dim strAdminEmail As String = ""
        '    Dim strEmailAddress As String = ""

        '    Try
        '        strSubject = Trim(objBCSP.ToUTF8(strSubject))
        '        strContent = Trim(Replace(objBCSP.ToUTF8(strContent), Chr(10), "<BR>"))

        '        strSMTPServer = objSysPara(0)
        '        strSMTPPort = objSysPara(1)
        '        strAdminEmail = objSysPara(2)

        '        objDERequest.RequestID = lngRequestID
        '        tblTemp = GetRequestInfor()
        '        If Not tblTemp Is Nothing Then
        '            If tblTemp.Rows.Count > 0 Then
        '                strEmailAddress = tblTemp.Rows(0).Item("EmailAddress")
        '                objMail.From = strAdminEmail
        '                If strSMTPPort = "" Then
        '                    strSMTPPort = 25
        '                End If
        '                objMail.Host = strSMTPServer
        '                objMail.Port = strSMTPPort
        '                objMail.Subject = strSubject
        '                objMail.From = strAdminEmail
        '                objMail.AddAddress(strEmailAddress)
        '                If Not strFileAttach = "" Then
        '                    objMail.AddAttachment(strFileAttach)
        '                End If
        '                objMail.IsHTML = True
        '                objMail.Body = strContent
        '                objMail.Send()
        '            End If
        '        End If
        '        SendMail = 0
        '    Catch ex As Exception
        '        strErrorMsg = ex.Message
        '        SendMail = 1
        '    End Try
        'End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objDERequest Is Nothing Then
                    objDERequest.Dispose(True)
                    objDERequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace