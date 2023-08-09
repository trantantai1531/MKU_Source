Imports System.Net.Mail
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Net


Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OSendEmail
        Inherits System.Web.UI.Page

        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBSearchResult As New clsBOPACSearchResult
        Private objBSearchQr As New clsBOPACSearchQuery
        Private objBCDBS As New clsBCommonDBSystem

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Dim strEmailTo As String = ""
                If Not IsNothing(Request("EmailTo")) Then
                    strEmailTo = Request("EmailTo")
                End If
                Call sendEmail(strEmailTo)
            End If

        End Sub

        Private Sub sendEmail(ByVal strEmailTo As String)
            Try
                Dim strIds As String = objBCommonStringProc.getIdsSring(clsSession.GlbMyListIds)
                Dim strSort As String = "TITLE"
                Dim intOrderBy As Integer = 1
                Dim strList As String = resortListIds(strIds, strSort)
                Dim strContent As String = processBooks(strList, intOrderBy)
                Dim intResult As Integer = Send2Mail(strContent, strEmailTo)
                If intResult Then
                    lblResult.Text = spEmailSuccess.InnerHtml
                Else
                    lblResult.Text = spEmailFail.InnerHtml
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function Send2Mail(ByVal strContent As String, ByVal strEmail As String) As Integer
            Dim intResult As Integer = 1
            Try
                Dim objSysPara() As String
                Dim objPara() As String = {"SMTP_SERVER", "SMTP_PORT", "ADMIN_EMAIL_ADDRESS", "ADMIN_EMAIL_PASS", "ADMIN_EMAIL_USER_AUTHEN"}
                objSysPara = objBCDBS.GetSystemParameters(objPara)
                Dim strSMTPServer As String = ""
                If Not IsNothing(objSysPara(0)) Then
                    strSMTPServer = objSysPara(0)
                End If
                Dim strSMTPPort As String = ""
                If Not IsNothing(objSysPara(1)) Then
                    strSMTPPort = objSysPara(1)
                End If
                Dim strSMTPMailUser As String = ""
                If Not IsNothing(objSysPara(2)) Then
                    strSMTPMailUser = objSysPara(2)
                End If
                Dim strSMTPMailPass As String = ""
                If Not IsNothing(objSysPara(3)) Then
                    strSMTPMailPass = objSysPara(3)
                End If
                Dim strMailUserAuthen As String = ""
                If Not IsNothing(objSysPara(4)) Then
                    strMailUserAuthen = objSysPara(4)
                End If
                strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")

                'Dim strBody As String = "Xin chào " & fullName.Trim & "!" & vbCrLf & vbCrLf
                'strBody &= "Cám ơn bạn đã đăng ký tài khoản đọc sách trực tuyến tại " & clsCommon.SendRegMailFrom & vbCrLf & vbCrLf
                'strBody &= "Tài khoản đăng nhập của bạn là: " & strUser & vbCrLf & vbCrLf
                'strBody &= clsCommon.SendRegMailFrom & " được xây dựng nhằm mục đích hỗ trợ người dùng có thể dễ dàng tìm kiếm, chia sẻ nguồn tri thức, kết nối những người yêu và đam mê đọc sách..." & vbCrLf & vbCrLf
                'strBody &= "Chúng tôi rất vui nếu nhận được sự đóng góp và phản hồi của các bạn. Mọi đóng góp xin vui lòng gửi về địa chỉ: " & clsCommon.SendRegMailUser & vbCrLf & vbCrLf
                'strBody &= "Trân trọng!" & vbCrLf
                Dim bolGmail As Boolean = False
                If InStr(strSMTPMailUser.ToLower, "gmail.com") > 0 Then
                    bolGmail = True
                End If
                Dim mailMessage As New MailMessage()
                Dim mailClient As New SmtpClient(strSMTPServer, strSMTPPort)
                With mailClient
                    .Timeout = 15000
                    .Credentials = New NetworkCredential(strMailUserAuthen, strSMTPMailPass)
                    .EnableSsl = bolGmail
                End With
                With mailMessage
                    .BodyEncoding = System.Text.UTF8Encoding.UTF8
                    .IsBodyHtml = True
                    .From = New MailAddress(strSMTPMailUser)
                    .Subject = spEmailSubject.InnerHtml
                    .Priority = Net.Mail.MailPriority.Normal
                    .Body = spEmailBodyHeader.InnerHtml & "<br />" & strContent
                    .[To].Add(strEmail)
                End With
                mailClient.Send(mailMessage)
            Catch ex As Exception
                intResult = 0
            End Try
            Return intResult
        End Function

        ' purpose :  show books by list of ids document
        ' Creator: phuongtt
        Private Function processBooks(ByVal strIds As String, ByVal intOrderBy As Integer) As String
            Dim strBook As String = ""
            Try
                If strIds.Trim <> "" Then
                    strIds = objBCommonStringProc.getIdsSring(strIds)
                    objBSearchResult.ItemIDs = strIds
                    Dim arrField() As String = {"022", "100", "245", "250", "260", "300", "490", "700", "773"}
                    Dim strSort As String = ""
                    Select Case intOrderBy
                        Case 1
                            strSort = ""
                        Case 2
                        Case 3
                        Case 4
                    End Select
                    Dim tblTmp As New DataTable
                    tblTmp = objBSearchResult.GetItemResultsByFields(arrField, True)
                    strBook = getBooks(tblTmp, strIds, intOrderBy)
                Else
                End If
            Catch ex As Exception
            End Try
            Return strBook
        End Function

        ' purpose :  show books
        ' Creator: phuongtt
        Private Function getBooks(ByVal tblData As DataTable, ByVal strIDs As String, ByVal intOrderBy As Integer) As String
            Dim strResult As String = ""
            Try
                Dim strTitle As String = ""
                Dim str100 As String = ""
                Dim str022 As String = ""
                Dim str700 As String = ""
                Dim str773 As String = ""
                Dim str260_300 As String = ""
                Dim intCount As Integer
                Dim arrIDs() As String
                Dim strCover As String = ""
                Dim intJ As Integer = 0
                arrIDs = Split(strIDs, ",")
                Dim IntTotal As Integer = UBound(arrIDs)
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                    strResult = "<TABLE WIDTH='100%' BORDER = '0px'  cellpadding='2px' cellspacing='2px'>"
                    strResult &= "<TR VALIGN='Top'><TD colspan='2'>&nbsp;</TD></TR>"
                    If tblData.Rows.Count > 0 Then
                        For intCount = 0 To IntTotal
                            strResult &= "<TR VALIGN='Top'>"

                            'GetHolding
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='MXG'"
                            If tblData.DefaultView.Count > 0 Then
                                strResult &= "<TD style='width:10%;'>" & tblData.DefaultView(intJ).Item("Content") & "</TD>"
                            Else
                                strResult &= "<TD style='width:10%;'>&nbsp;</TD>"
                            End If

                            strResult &= "<TD style='width:90%;'>"

                            strTitle = ""
                            str260_300 = ""
                            str773 = ""
                            '022
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='022')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str022 = str022 & tblData.DefaultView(intJ).Item("Content")
                            Next
                            '100
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='100'"
                            If tblData.DefaultView.Count > 0 Then
                                str100 = tblData.DefaultView(0).Item("Content") & ""
                            End If
                            '245
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND Field='245'"
                            If tblData.DefaultView.Count > 0 Then
                                strTitle = "<b>" & (intCount + 1).ToString & ". " & "</b>" & tblData.DefaultView(0).Item("Content") & ""
                            End If
                            '250
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='250')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                            Next
                            '260
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='260')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                            Next
                            '300
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='300')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content") & ". - "
                            Next
                            '490
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='490')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & "( " & tblData.DefaultView(intJ).Item("Content") & " )" & ". - "
                            Next
                            '700
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='700')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str260_300 = str260_300 & tblData.DefaultView(intJ).Item("Content")
                            Next
                            '773
                            tblData.DefaultView.RowFilter = "ItemID=" & arrIDs(intCount) & " AND (Field='773')"
                            For intJ = 0 To tblData.DefaultView.Count - 1
                                str773 = str773 & " //" & tblData.DefaultView(intJ).Item("Content")
                            Next
                            strResult &= "<u>" & strTitle & "</u> . - " & str260_300 & str773
                            strResult &= "</TD></TR>"
                            strResult &= "<TR VALIGN='Top'><TD colspan='2'>&nbsp;</TD></TR>"
                        Next
                        strResult &= "</TABLE>"
                    End If
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' resortListIds method
        ' Purpose: resort by fields
        Private Function resortListIds(ByVal Ids As String, ByVal strSortby As String) As String
            Dim strListIds As String = ""
            Try
                Dim dtListIds As DataTable = Nothing
                objBSearchQr.SortBy = strSortby
                Dim strSQL As String = objBSearchQr.sortByListIds(Ids)
                dtListIds = objBSearchQr.eExecuteQuerySQL(strSQL)
                strListIds = objBCommonStringProc.getiTemString(dtListIds)
            Catch ex As Exception
            End Try
            Return strListIds
        End Function

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            '  Init objBCommonStringProc
            objBCommonStringProc.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()

            ' init objBSearchQr object
            objBSearchQr.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchQr.DBServer = Session("DBServer")
            objBSearchQr.ConnectionString = Session("ConnectionString")
            objBSearchQr.Initialize()

            ' init objBSearchResult object
            objBSearchResult.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBSearchResult.DBServer = Session("DBServer")
            objBSearchResult.ConnectionString = Session("ConnectionString")
            objBSearchResult.Initialize()

            ' init objBSearchResult object
            objBCDBS.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            Call objBCDBS.Initialize()

        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBSearchQr Is Nothing Then
                    objBSearchQr.Dispose(True)
                    objBSearchQr = Nothing
                End If
                If Not objBSearchResult Is Nothing Then
                    objBSearchResult.Dispose(True)
                    objBSearchResult = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
