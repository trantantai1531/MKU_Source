Imports eMicLibOPAC.BusinessRules.OPAC
Imports System.Security.Cryptography
Imports System.Text
Imports eMicLibOPAC.BusinessRules.Common
Imports System.Web.Services
Imports System.Net

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OLogin
        Inherits clsWBaseJqueryUI 'clsWBase
        Private objBPatronInfor As New clsBOPACPatronInfor
        Private objBCounter As New clsBCounter

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                Dim _strInfo As String = ""

                If (Not IsNothing(Request("txtSothe")) AndAlso Request("txtSothe") <> "") AndAlso (Not IsNothing(Request("txtMatkhau")) AndAlso Request("txtMatkhau") <> "") Then
                    Dim tblTmp As New DataTable
                    objBPatronInfor.CardNo = Request("txtSothe").Trim
                    objBPatronInfor.Password = Request("txtMatkhau").Trim
                    tblTmp = objBPatronInfor.GetPatron
                    If Not tblTmp Is Nothing AndAlso tblTmp.Rows.Count > 0 Then
                        Dim strEmail As String = ""
                        If tblTmp.Rows(0).Item("isLocked") = 0 Then
                            clsSession.GlbUserLevel = tblTmp.Rows(0).Item("AccessLevel")
                            clsSession.GlbUser = tblTmp.Rows(0).Item("Code")
                            clsSession.GlbPassword = tblTmp.Rows(0).Item("Password")
                            clsSession.GlbUserFullName = tblTmp.Rows(0).Item("FullName")
                            If Not IsDBNull(tblTmp.Rows(0).Item("Email")) Then
                                strEmail = tblTmp.Rows(0).Item("Email")
                            End If
                            clsSession.GlbEmail = strEmail
                            'Gan tai khoan cho phan tu tren form TOP
                            _strInfo &= " parent.setUser('" & clsSession.GlbUser & "','" & clsSession.GlbUserFullName & "');" & vbCrLf
                            'Kiem tra neu la form comment thi submit
                            If (Not IsNothing(Request("comment")) AndAlso Request("comment") <> "") Then
                                _strInfo &= " parent.closeShowLogin();" & vbCrLf
                                _strInfo &= " parent.onSubmitComment();" & vbCrLf
                            End If
                            If (Not IsNothing(Request("patron")) AndAlso Request("patron") <> "") Then
                                _strInfo &= " location.href='OPatronInfo.aspx';" & vbCrLf
                            End If
                            If (Not IsNothing(Request("viewer")) AndAlso Request("viewer") <> "") Then
                                Select Case Request("viewer")
                                    Case 1 'Tai lieu dien tu
                                        Dim collViewer As New Collection
                                        If Not IsNothing(clsSession.GlbViewerCollection) Then
                                            collViewer = clsSession.GlbViewerCollection
                                            _strInfo &= " top.location.href='" & String.Format("OViewLoading.aspx?search={0}&pageno={1}&ItemID={2}&fileId={3}&fileType={4}&subjectId={5}&collectionId={6}&fulltext={7}", collViewer.Item("search"), collViewer.Item("pageno"), collViewer.Item("ItemID"), collViewer.Item("fileId"), collViewer.Item("fileType"), collViewer.Item("subjectId"), collViewer.Item("collectionId"), collViewer.Item("fulltext")) & "';" & vbCrLf
                                            clsSession.GlbViewerCollection = Nothing
                                        End If
                                    Case 2 'Bao in/tap chi dien tu
                                        Dim collViewer As New Collection
                                        If Not IsNothing(clsSession.GlbViewerCollection) Then
                                            collViewer = clsSession.GlbViewerCollection
                                            _strInfo &= " top.location.href='" & String.Format("OViewerMagazine.aspx?MagId={0}&ItemID={1}&page={2}", collViewer.Item("MagId"), collViewer.Item("ItemID"), collViewer.Item("pageno")) & "';" & vbCrLf
                                            clsSession.GlbViewerCollection = Nothing
                                        End If
                                End Select
                            End If
                            If (Not IsNothing(Request("RequestLogin")) AndAlso Request("RequestLogin") <> "") Then
                                _strInfo &= " top.location.href='" & String.Format("OIndex.aspx") & "';" & vbCrLf
                            End If
                            clsCookie.CookieGlbLastVisited = Now
                            If Not IsNothing(Request("chkSavePassword")) AndAlso Request("chkSavePassword") <> "" Then
                                clsCookie.CookieGlbUserFullName = tblTmp.Rows(0).Item("FullName")
                                clsCookie.CookieGlbUserLevel = tblTmp.Rows(0).Item("AccessLevel")
                                clsCookie.CookieGlbUser = tblTmp.Rows(0).Item("Code")
                                clsCookie.CookieGlbPassword = tblTmp.Rows(0).Item("Password")
                                clsCookie.CookieGlbEmail = strEmail
                            Else
                                clsCookie.RemoveCookieGlbUserFullname()
                                clsCookie.RemoveCookieGlbUser()
                                clsCookie.RemoveCookieGlbPassword()
                                clsCookie.RemoveCookieGlbUserLevel()
                                clsCookie.RemoveCookieGlbEmail()
                            End If
                            clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                            objBCounter.Code = Request("txtSothe").Trim
                            objBCounter.InsertLoginCounter()
                        Else
                            If tblTmp.Rows(0).Item("isLocked") = 1 Then
                                lblShowText.InnerText = "Hiện tại thẻ này đang bị khoá !"
                            Else
                                lblShowText.InnerText = "Hiện tại thẻ này đã hết hạn sử dụng !"
                            End If
                        End If
                    Else
                        lblShowText.InnerText = "Tài khoản đăng nhập không đúng!"
                    End If
                Else
                End If
            End If
        End Sub

        ' Init method
        ' purpose initialize all components
        Private Sub Initialize()
            'Init objBPatronInfor
            objBPatronInfor.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatronInfor.DBServer = Session("DBServer")
            objBPatronInfor.ConnectionString = Session("ConnectionString")
            objBPatronInfor.Initialize()

            objBCounter.ConnectionString = Session("ConnectionString")
            objBCounter.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCounter.DBServer = Session("DBServer")
            objBCounter.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()

        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronInfor Is Nothing Then
                    objBPatronInfor.Dispose(True)
                    objBPatronInfor = Nothing
                End If
                If Not objBCounter Is Nothing Then
                    objBCounter.Dispose(True)
                    objBCounter = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub btnLoginForGoogle_Click(sender As Object, e As EventArgs) Handles btnLoginForGoogle.Click
            Dim tblTmp As New DataTable
            objBPatronInfor.Email = hidEmail.Value
            tblTmp = objBPatronInfor.GetPatronByEmail
            If Not tblTmp Is Nothing AndAlso tblTmp.Rows.Count > 0 Then
                Dim strEmail As String = ""
                Dim _strInfo As String = ""
                If tblTmp.Rows(0).Item("isLocked") = 0 Then
                    clsSession.GlbUserLevel = tblTmp.Rows(0).Item("AccessLevel")
                    clsSession.GlbUser = tblTmp.Rows(0).Item("Code")
                    clsSession.GlbPassword = tblTmp.Rows(0).Item("Password")
                    clsSession.GlbUserFullName = tblTmp.Rows(0).Item("FullName")
                    If Not IsDBNull(tblTmp.Rows(0).Item("Email")) Then
                        strEmail = tblTmp.Rows(0).Item("Email")
                    End If
                    clsSession.GlbEmail = strEmail
                    'Gan tai khoan cho phan tu tren form TOP
                    _strInfo &= " parent.setUser('" & clsSession.GlbUser & "','" & clsSession.GlbUserFullName & "');" & vbCrLf
                    'Kiem tra neu la form comment thi submit
                    If (Not IsNothing(Request("comment")) AndAlso Request("comment") <> "") Then
                        _strInfo &= " parent.closeShowLogin();" & vbCrLf
                        _strInfo &= " parent.onSubmitComment();" & vbCrLf
                    End If
                    If (Not IsNothing(Request("patron")) AndAlso Request("patron") <> "") Then
                        _strInfo &= " location.href='OPatronInfo.aspx';" & vbCrLf
                    End If
                    If (Not IsNothing(Request("viewer")) AndAlso Request("viewer") <> "") Then
                        Select Case Request("viewer")
                            Case 1 'Tai lieu dien tu
                                Dim collViewer As New Collection
                                If Not IsNothing(clsSession.GlbViewerCollection) Then
                                    collViewer = clsSession.GlbViewerCollection
                                    _strInfo &= " top.location.href='" & String.Format("OViewLoading.aspx?search={0}&pageno={1}&ItemID={2}&fileId={3}&fileType={4}&subjectId={5}&collectionId={6}&fulltext={7}", collViewer.Item("search"), collViewer.Item("pageno"), collViewer.Item("ItemID"), collViewer.Item("fileId"), collViewer.Item("fileType"), collViewer.Item("subjectId"), collViewer.Item("collectionId"), collViewer.Item("fulltext")) & "';" & vbCrLf
                                    clsSession.GlbViewerCollection = Nothing
                                End If
                            Case 2 'Bao in/tap chi dien tu
                                Dim collViewer As New Collection
                                If Not IsNothing(clsSession.GlbViewerCollection) Then
                                    collViewer = clsSession.GlbViewerCollection
                                    _strInfo &= " top.location.href='" & String.Format("OViewerMagazine.aspx?MagId={0}&ItemID={1}&page={2}", collViewer.Item("MagId"), collViewer.Item("ItemID"), collViewer.Item("pageno")) & "';" & vbCrLf
                                    clsSession.GlbViewerCollection = Nothing
                                End If
                        End Select
                    End If
                    If (Not IsNothing(Request("RequestLogin")) AndAlso Request("RequestLogin") <> "") Then
                        _strInfo &= " top.location.href='" & String.Format("OIndex.aspx") & "';" & vbCrLf
                    End If
                    clsCookie.CookieGlbLastVisited = Now
                    If Not IsNothing(Request("chkSavePassword")) AndAlso Request("chkSavePassword") <> "" Then
                        clsCookie.CookieGlbUserFullName = tblTmp.Rows(0).Item("FullName")
                        clsCookie.CookieGlbUserLevel = tblTmp.Rows(0).Item("AccessLevel")
                        clsCookie.CookieGlbUser = tblTmp.Rows(0).Item("Code")
                        clsCookie.CookieGlbPassword = tblTmp.Rows(0).Item("Password")
                        clsCookie.CookieGlbEmail = strEmail
                    Else
                        clsCookie.RemoveCookieGlbUserFullname()
                        clsCookie.RemoveCookieGlbUser()
                        clsCookie.RemoveCookieGlbPassword()
                        clsCookie.RemoveCookieGlbUserLevel()
                        clsCookie.RemoveCookieGlbEmail()
                    End If
                    clsUICommon.MyMsgBoxInfor(_strInfo, Me.Page)
                    'objBCounter.Code = tblTmp.Rows(0).Item("Code")
                    'objBCounter.InsertLoginCounter()
                Else
                    If tblTmp.Rows(0).Item("isLocked") = 1 Then
                        lblShowText.InnerText = "Hiện tại thẻ này đang bị khoá !"
                    Else
                        lblShowText.InnerText = "Hiện tại thẻ này đã hết hạn sử dụng !"
                    End If
                End If
            Else
                lblShowText.InnerText = "Thông tin email của bạn đọc chưa có trong hệ thống"
            End If
        End Sub
    End Class
End Namespace
