Namespace eMicLibOPAC.WebUI
    Public Class clsCookie
#Region "GlbUser"

        Public Shared Property CookieGlbUserFullName() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Request.Browser.Cookies Then
                    If HttpContext.Current.Request.Cookies("UFULLNAME") IsNot Nothing Then
                        strResult = DirectCast(HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies("UFULLNAME").Value), String)
                    End If
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                Dim cookie As HttpCookie = New HttpCookie("UFULLNAME")
                cookie.Value = HttpContext.Current.Server.UrlEncode(value)
                cookie.Expires = DateTime.MaxValue
                HttpContext.Current.Response.Cookies.Add(cookie)
            End Set
        End Property

        Public Shared Property CookieGlbUser() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Request.Browser.Cookies Then
                    If HttpContext.Current.Request.Cookies("UNAME") IsNot Nothing Then
                        strResult = DirectCast(HttpContext.Current.Request.Cookies("UNAME").Value, String)
                    End If
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                Dim cookie As HttpCookie = New HttpCookie("UNAME")
                cookie.Value = value
                cookie.Expires = DateTime.MaxValue
                HttpContext.Current.Response.Cookies.Add(cookie)
            End Set
        End Property

        Public Shared Property CookieGlbUserLevel() As String
            Get
                Dim intResult As String = 0
                If HttpContext.Current.Request.Browser.Cookies Then
                    If HttpContext.Current.Request.Cookies("UNAMELEVEL") IsNot Nothing Then
                        intResult = DirectCast(HttpContext.Current.Request.Cookies("UNAMELEVEL").Value, String)
                    End If
                End If
                Return intResult
            End Get
            Set(ByVal value As String)
                Dim cookie As HttpCookie = New HttpCookie("UNAMELEVEL")
                cookie.Value = value
                cookie.Expires = DateTime.MaxValue
                HttpContext.Current.Response.Cookies.Add(cookie)
            End Set
        End Property

        Public Shared Property CookieGlbEmail() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Request.Browser.Cookies Then
                    If HttpContext.Current.Request.Cookies("UEmail") IsNot Nothing Then
                        strResult = DirectCast(HttpContext.Current.Request.Cookies("UEmail").Value, String)
                    End If
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                Dim cookie As HttpCookie = New HttpCookie("UEmail")
                cookie.Value = value
                cookie.Expires = DateTime.MaxValue
                HttpContext.Current.Response.Cookies.Add(cookie)
            End Set
        End Property

        Public Shared Property CookieGlbPassword() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Request.Browser.Cookies Then
                    If HttpContext.Current.Request.Cookies("UPASS") IsNot Nothing Then
                        strResult = DirectCast(HttpContext.Current.Request.Cookies("UPASS").Value, String)
                    End If
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                Dim cookie As HttpCookie = New HttpCookie("UPASS")
                cookie.Value = value
                cookie.Expires = DateTime.MaxValue
                HttpContext.Current.Response.Cookies.Add(cookie)
            End Set
        End Property

        Public Shared Property CookieGlbLastVisited() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Request.Browser.Cookies Then
                    If HttpContext.Current.Request.Cookies("LVisit") IsNot Nothing Then
                        strResult = DirectCast(HttpContext.Current.Request.Cookies("LVisit").Value, String)
                    End If
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                Dim cookie As HttpCookie = New HttpCookie("LVisit")
                cookie.Value = value 'DateTime.Now.ToString()
                cookie.Expires = DateTime.MaxValue
                HttpContext.Current.Response.Cookies.Add(cookie)
            End Set
        End Property

        Public Shared Property CookieGlbLanguage() As String
            Get
                Dim strResult As String = ""
                If HttpContext.Current.Request.Browser.Cookies Then
                    If HttpContext.Current.Request.Cookies("Language") IsNot Nothing Then
                        strResult = DirectCast(HttpContext.Current.Request.Cookies("Language").Value, String)
                    End If
                End If
                Return strResult
            End Get
            Set(ByVal value As String)
                Dim cookie As HttpCookie = New HttpCookie("Language")
                cookie.Value = value 'DateTime.Now.ToString()
                cookie.Expires = DateTime.MaxValue
                HttpContext.Current.Response.Cookies.Add(cookie)
            End Set
        End Property

#End Region

#Region "Function & Procedure GlbUser"

        Public Shared Sub RemoveCookieGlbUserFullname()
            If HttpContext.Current.Request.Browser.Cookies Then
                If HttpContext.Current.Request.Cookies("UFULLNAME") IsNot Nothing Then
                    HttpContext.Current.Response.Cookies.Remove("UFULLNAME")
                End If
            End If
        End Sub

        Public Shared Sub RemoveCookieGlbUser()
            If HttpContext.Current.Request.Browser.Cookies Then
                If HttpContext.Current.Request.Cookies("UNAME") IsNot Nothing Then
                    HttpContext.Current.Response.Cookies.Remove("UNAME")
                End If
            End If
        End Sub

        Public Shared Sub RemoveCookieGlbUserLevel()
            If HttpContext.Current.Request.Browser.Cookies Then
                If HttpContext.Current.Request.Cookies("UNAMELEVEL") IsNot Nothing Then
                    HttpContext.Current.Response.Cookies.Remove("UNAMELEVEL")
                End If
            End If
        End Sub

        Public Shared Sub RemoveCookieGlbPassword()
            If HttpContext.Current.Request.Browser.Cookies Then
                If HttpContext.Current.Request.Cookies("UPASS") IsNot Nothing Then
                    HttpContext.Current.Response.Cookies.Remove("UPASS")
                End If
            End If
        End Sub

        Public Shared Sub RemoveCookieGlbEmail()
            If HttpContext.Current.Request.Browser.Cookies Then
                If HttpContext.Current.Request.Cookies("UEmail") IsNot Nothing Then
                    HttpContext.Current.Response.Cookies.Remove("UEmail")
                End If
            End If
        End Sub

        Public Shared Sub RemoveCookieGlbLanguage()
            If HttpContext.Current.Request.Browser.Cookies Then
                If HttpContext.Current.Request.Cookies("Language") IsNot Nothing Then
                    HttpContext.Current.Response.Cookies.Remove("Language")
                End If
            End If
        End Sub

#End Region

    End Class
End Namespace

