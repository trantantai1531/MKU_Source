Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Threading
Imports System.Globalization
Imports System.Web.Mail
Imports System.Web.Services
Imports System.Xml

Namespace eMicLibOPAC.WebUI
    Public Class clsWBase
        Inherits System.Web.UI.Page

        ' *****************************************************************************************************
        ' Declare member variables
        ' *****************************************************************************************************
        Private strScriptName, strPathName As String
        Private fs As StreamWriter
        Private dsResource As New DataSet
        Private dtvResource As New DataView
        Private blnReadyFile As Boolean = False
        Private strColLanguage As String
        Private strCtl As String
        Protected objSysPara() As String
        Private objPara() As String = {"OPAC_FORUM_URL", "LDAP_LOCATION", "LDAP_SERVER_TYPE", "LDAP_LOGON_USER", "LDAP_LOGON_PASSWORD", "SMTP_SERVER", "ADMIN_EMAIL_ADDRESS", "EDATA_LOCATIONS", "OPAC_URL", "DATE_FORMAT", "OPAC_SERVER_LOCAL", "OPAC_SERVER_PUBLIC", "OPAC_PHYSICAL_PATH", "OPAC_PICTURE_PATH"}
        Private strSlip As String = "|+|"
        Private intlenSlip As String = Len(strSlip)
        Private strSlipTable As String = "|++|"
        Private intlenSlipTable As String = Len(strSlipTable)
        Private strWordDes As String = "|+++|"
        Private strWordSource As String = " & "
        Private xmlDoc As XmlDocument

        Dim objBCDBS As New eMicLibOPAC.BusinessRules.Common.clsBCommonDBSystem
        Dim objBCSP As New eMicLibOPAC.BusinessRules.Common.clsBCommonStringProc

        ' GetSysPara method
        Public Sub GetSysPara()
            Try
                objSysPara = objBCDBS.GetSystemParameters(objPara)
            Catch ex As Exception
            End Try
        End Sub
        ' Page Events
        '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
            'AddHandler Me.Load, AddressOf Archive_Load
            AddHandler Me.Error, AddressOf eMicLib_Error
        End Sub
        Protected Sub eMicLib_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim currentError As Exception = Server.GetLastError()
            ' Write error to log file if not already done by AppException
            'If Not (TypeOf currentError Is Core.AppException) Then
            '    Core.AppException.LogError(currentError.Message.ToString)
            'End If
            ' Show error on screen
            ShowError(currentError)
            ' Clear error so that it does not buble up to Application Level
            Server.ClearError()
        End Sub
        ' Shared Methods
        '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        Private Sub ShowError(ByVal currentError As Exception)
            Dim context As HttpContext = HttpContext.Current
            Session("ErrorMessage") = "ERROR ON eMicLib60 SYSTEM" & vbCrLf & vbCrLf & _
              "Has an error on this page:" & vbCrLf & vbCrLf & _
                context.Request.Url.ToString & vbCrLf & vbCrLf & _
              "Exception Details:" & _
                currentError.Message.ToString & vbCrLf & vbCrLf & _
              "Stack Trace:" & vbCrLf & _
               currentError.ToString & vbCrLf
            'show path
            Dim strPath As String = Server.MapPath("").ToUpper
            Dim intLen As Integer
            intLen = InStr(strPath, Request.ApplicationPath.Replace("/", "\").ToUpper)
            strPath = strPath.Substring(intLen)
            intLen = strPath.Split("\").Length - 1
            Dim inti As Integer
            strPath = "WShowError.aspx"
            For inti = 0 To intLen - 1
                strPath = "../" & strPath
            Next
            'Response.Write("<script language='javascript'>window.open('" & strPath & "','Error','height=380,width=650,top=50,left=50,menubar=no,resizable=yes,scrollbars=yes');</script>")
        End Sub

        Private Function checkValidSite() As Boolean
            Dim bolResult As Boolean = True
            Try
                If Not IsNothing(clsSession.GlbSite) AndAlso clsSession.GlbSite >= 0 Then
                Else
                    If InStr(Request.ServerVariables("SCRIPT_NAME").ToLower, "odefault.aspx") <= 0 Then
                        bolResult = False
                    End If
                End If
            Catch ex As Exception
            End Try
            Return bolResult
        End Function

        Private Sub checklicense()
            If IsNothing(Application("licenseOpac")) Or Not Application("licenseOpac") Then
                Response.Redirect("~/Pages/License/MLLicense.aspx")
                Response.End()
            End If
        End Sub

        ' **********************************************************************
        ' Page_Load method
        ' Purpose: Load necessary objects
        ' **********************************************************************
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Call checklicense()
            Call PageInit()
            Call GetCultureInfoCookie()
            ' Get PathName of resource file
            If Request.QueryString.Get("Script_Name") <> "" Then
                strScriptName = Request.QueryString.Get("Script_Name")
            Else
                strScriptName = Request.ServerVariables("Script_Name")
            End If
            strPathName = Right(strScriptName, Len(strScriptName) - InStr(2, strScriptName, "/"))
            Session("strPathName") = Right(strScriptName.Replace("/", "\"), Len(strScriptName) - 1)
            strPathName = "\Resources\LabelString\" & Replace(Replace(strPathName, ".aspx", ".xml"), "/", "\")
            strPathName = Server.MapPath(Request.ApplicationPath) & strPathName
            If Not Page.IsPostBack Then
                ' Export Resource 
                Call ExportResource()
            End If
            'Response.Write("<script language = 'javascript'>self.close();</script>")
            'Response.End()
            ' Set Resource for controls
            Call SetResourceForControls()

            If Not objSysPara(9) Is Nothing Then
                Session("DateFormat") = LCase(objSysPara(9))
            Else
                Session("DateFormat") = "dd/mm/yyyy"
            End If

            If Session("DateFormat") = "dd/mm/yyyy" Then
                Session("ToDay") = CStr(Day(Now)).PadLeft(2, "0") & "/" & CStr(Month(Now)).PadLeft(2, "0") & "/" & CStr(Year(Now))
            ElseIf Session("DateFormat") = "mm/dd/yyyy" Then
                Session("ToDay") = CStr(Month(Now)).PadLeft(2, "0") & "/" & CStr(Day(Now)).PadLeft(2, "0") & "/" & CStr(Year(Now))
            ElseIf Session("DateFormat") = "yyyy/dd/mm" Then
                Session("ToDay") = CStr(Year(Now)) & "/" & CStr(Day(Now)).PadLeft(2, "0") & "/" & CStr(Month(Now)).PadLeft(2, "0")
            ElseIf Session("DateFormat") = "yyyy/mm/dd" Then
                Session("ToDay") = CStr(Year(Now)) & "/" & CStr(Month(Now)).PadLeft(2, "0") & "/" & CStr(Day(Now)).PadLeft(2, "0")
            End If

            'Call setDefaultMetadata()
        End Sub

        Private Sub setDefaultMetadata()
            Try
                Dim lkHead As HtmlLink
                Dim hm As HtmlMeta
                Dim head As HtmlHead = Page.Header
                lkHead = New HtmlLink
                With lkHead
                    .Attributes.Add("rel", "shortcut icon")
                    .Href = "images/Logo/logo1.ico"
                End With
                head.Controls.Add(lkHead)
                lkHead = New HtmlLink
                With lkHead
                    .Attributes.Add("rel", "schema.DC")
                    .Href = "http://purl.org/dc/elements/1.1/"
                End With
                head.Controls.Add(lkHead)
                lkHead = New HtmlLink
                With lkHead
                    .Attributes.Add("rel", "schema.DCTERMS")
                    .Href = "http://purl.org/dc/terms/"
                End With
                head.Controls.Add(lkHead)

                hm = New HtmlMeta
                With hm
                    .Attributes.Add("http-equiv", "Content-Type")
                    .Content = "text/html; charset=utf-8"
                End With
                head.Controls.Add(hm)
                hm = New HtmlMeta
                With hm
                    .Name = "robots"
                    .Content = "index,follow"
                End With
                head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Title"
                '    .Attributes.Add("xml:lang", "vi")
                '    .Content = "www.emiclib.com: Tài liệu điện tử trực tuyến Emiclib. Kết nối và chia sẻ nguồn tri thức, những người yêu và đam mê đọc sách."
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Subject"
                '    .Attributes.Add("xml:lang", "vi")
                '    .Content = "Dublin Core Meta Tags. Trang chủ, Chia sẻ tài liệu số trực tuyến Emiclib."
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Identifier"
                '    .Scheme = "DCterms:URI"
                '    .Attributes.Add("lang", "vi")
                '    .Content = "http://www.emiclib.com"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Format"
                '    .Scheme = "DCterms:IMT"
                '    .Content = "text/html"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Creator"
                '    .Content = "emiclib"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Publisher"
                '    .Content = "emiclib"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Publisher.Address"
                '    .Content = "contact@emiclib.com"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Contributor"
                '    .Content = "emiclib"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Date"
                '    .Content = Now.Year.ToString
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Type"
                '    .Content = "text/html"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Identifier"
                '    .Content = "http://www.emiclib.com"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Relation"
                '    .Scheme = "IsPartOf"
                '    .Content = "www.emiclib.com"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Coverage"
                '    .Content = "emiclib"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Rights"
                '    .Content = "Copyright " & Now.Year.ToString & ", emiclib, Ltd.  All rights reserved."
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Language"
                '    .Scheme = "dcterms:RFC1766"
                '    .Content = "vi"
                'End With
                'head.Controls.Add(hm)
                'hm = New HtmlMeta
                'With hm
                '    .Name = "DC.Description"
                '    .Attributes.Add("xml:lang", "vi")
                '    .Content = "Emiclib đọc sách trực tuyến là một kỹ thuật công nghệ số được biên mục theo chuẩn thư viện cung cấp, tìm kiếm trực tuyến với nội dung đầy đủ của hàng ngàn cuốn sách điện tử, sách nói, hình ảnh, Media,... từ nhiều tác giả và nhà xuất bản hàng đầu. Emiclib đọc sách trực tuyến cung cấp công nghệ hiện đại, giúp bạn tìm kiếm thông tin nhanh, tiết kiệm thời gian, dễ dàng tổ chức thông tin và cá nhân hoá những kinh nghiệm học tập của bạn."
                'End With
                'head.Controls.Add(hm)
                'head.Title = "EMICLIB.OPAC - DGSOFT"
            Catch ex As Exception
            End Try
        End Sub

        ' **********************************************************************
        ' Initialize method
        ' Purpose: Init all necessary objects
        ' **********************************************************************
        Public Sub PageInit()
            ' Init objects
            objBCSP.InterfaceLanguage = clsSession.GlbInterfaceLanguage

            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            Call objBCDBS.Initialize()

            If Trim(clsSession.GlbInterfaceLanguage & "") = "" Then
                clsSession.GlbInterfaceLanguage = objBCSP.InterfaceLanguage
                If Trim(clsSession.GlbInterfaceLanguage & "") = "" Then
                    clsSession.GlbInterfaceLanguage = "unicode"
                End If
            End If

            Dim objContentEncoding As System.Text.Encoding
            Dim objEncoding As System.Text.Encoding
            Select Case Trim(clsSession.GlbInterfaceLanguage & "")
                Case "tcvn", "vni"
                    objContentEncoding = objEncoding.GetEncoding("iso-8859-1")
                Case Else
                    Select Case Session("DBServer")
                        Case "SQLSERVER"
                            objContentEncoding = objEncoding.GetEncoding("utf-8")
                        Case "ORACLE"
                            objContentEncoding = objEncoding.GetEncoding("iso-8859-1")
                    End Select
            End Select
            Request.ContentEncoding = objContentEncoding
            ' Set StyleSheet, language, typing
            Session("Module") = "Opac"
            'If clsSession.GlbLanguage & "" = "" Then
            '    clsSession.GlbLanguage = "vie"
            'End If
            Call setLanguage()
            If Session("FontType") & "" = "" Then
                Session("FontType") = "utf8"
            End If
            If Session("Typing") & "" = "" Then
                Session("Typing") = 0
            End If
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", Me.GetStyleSheetURL(Session("Module"))))

            Response.Write(String.Format("{0}", Me.GetStyleSheetURL_Metro()))
            Page.RegisterClientScriptBlock("jqueryJs", "<Script Language='JavaScript'  type='text/javascript' src='js/jquery.min.js'></Script>")
            Page.RegisterClientScriptBlock("metroWidgetJs", "<Script Language='JavaScript'  type='text/javascript' src='js/jquery.widget.min.js'></Script>")
            Page.RegisterClientScriptBlock("metroMousewheelJs", "<Script Language='JavaScript'  type='text/javascript' src='js/jquery.mousewheel.js'></Script>")
            Page.RegisterClientScriptBlock("metroJs", "<Script Language='JavaScript'  type='text/javascript' src='js/metro.min.js'></Script>")
            Page.RegisterClientScriptBlock("docsJs", "<Script Language='JavaScript'  type='text/javascript' src='js/docs.js'></Script>")

            ' Get system parameters
            Call GetSysPara()

        End Sub

        Private Sub setLanguage()
            Try
                Dim strLanguage As String = "vie"
                If Not IsNothing(HttpContext.Current.Request.QueryString("Language")) AndAlso HttpContext.Current.Request.QueryString("Language") <> "" Then
                    strLanguage = HttpContext.Current.Request.QueryString("Language")
                    clsCookie.CookieGlbLanguage = strLanguage
                ElseIf Not IsNothing(clsCookie.CookieGlbLanguage) AndAlso clsCookie.CookieGlbLanguage <> "" Then
                    strLanguage = clsCookie.CookieGlbLanguage
                ElseIf Not IsNothing(clsSession.GlbLanguage) AndAlso clsSession.GlbLanguage <> "" Then
                    strLanguage = clsSession.GlbLanguage
                Else
                    strLanguage = "vie"
                End If
                clsSession.GlbLanguage = strLanguage
            Catch ex As Exception
            End Try
        End Sub

        ' **********************************************************************
        ' Read XmlFile
        ' **********************************************************************
        Private Sub ReadXmlFile()

            Me.blnReadyFile = False
            Try
                strColLanguage = clsSession.GlbLanguage
                If (Me.strPathName = "") Or Not File.Exists(Me.strPathName) Then
                    Throw New ApplicationException("Invalid language file " + Me.strPathName)
                End If
                If Me.xmlDoc Is Nothing Then
                    Me.xmlDoc = New XmlDocument()
                End If
                Me.xmlDoc.Load(Me.strPathName)
                Me.blnReadyFile = True
            Catch ex As Exception
            End Try
        End Sub

        ' **********************************************************************
        ' GetControlValue
        ' **********************************************************************
        Public Function GetControlValue(ByVal strControlName As String) As String
            'GetControlValue = ""
            'dtvResource.RowFilter = "name='" & strControlName & "'"
            'If dtvResource.Count > 0 Then
            '    Try
            '        GetControlValue = dtvResource.Item(0).Item(strColLanguage)
            '    Catch ex As Exception
            '        Try
            '            GetControlValue = dtvResource.Item(0).Item("vie")
            '        Catch ex1 As Exception
            '        End Try
            '    End Try
            'End If
            Dim strResult As String = ""
            Try
                strControlName = strControlName.ToUpper(New CultureInfo("en"))
                If Me.xmlDoc Is Nothing Then
                    Return ""
                End If
                Dim nodes As XmlNodeList
                nodes = Me.xmlDoc.SelectNodes("/Head/data")
                For Each node As XmlNode In nodes
                    If node.SelectSingleNode("name").InnerText.ToUpper = strControlName.ToUpper Then
                        With node
                            strResult = .SelectSingleNode(Me.strColLanguage).InnerText
                            Exit For
                        End With
                    End If
                Next
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' **********************************************************************
        ' SetCultureInfoCookie
        ' **********************************************************************
        Public Sub SetCultureInfoCookie(ByVal culture As String, ByVal uiCulture As String)
            Try
                Me.Response.Cookies("Culture").Value = culture
                Me.Response.Cookies("UICulture").Value = uiCulture
                Me.Response.Cookies("Culture").Expires = DateTime.MaxValue
                Me.Response.Cookies("UICulture").Expires = DateTime.MaxValue
            Catch
            End Try
        End Sub
        Public Sub ShowWaitingOnPage(ByVal strMsg As String, ByVal strPathOut As String, Optional ByVal blnHidden As Boolean = False)
            If Not blnHidden Then
                Response.Write("<span id='spnlbProcessing' style='LEFT: 300px; POSITION: absolute; TOP: 200px;TEXT-ALIGN: center;'>" & strMsg & " <br><img src='" & strPathOut & "/Images/progressBar.gif'></span>")
                Response.Flush()
            Else
                Response.Write("<script language='javascript'>spnlbProcessing.style.visibility = 'hidden';</script>")
            End If
        End Sub

        ' **********************************************************************
        ' GetCultureInfoCookie
        ' **********************************************************************
        Public Sub GetCultureInfoCookie()
            Try
                Dim cultureCookie As HttpCookie = Me.Request.Cookies("Culture")
                Dim uicultureCookie As HttpCookie = Me.Request.Cookies("UICulture")
                If Not (cultureCookie Is Nothing) And Not (uicultureCookie Is Nothing) Then
                    ' Set thread culture and UI culture based on cookies information if available
                    Thread.CurrentThread.CurrentCulture = New CultureInfo(cultureCookie.Value)
                    Thread.CurrentThread.CurrentUICulture = New CultureInfo(uicultureCookie.Value)
                Else
                    ' Retrieve information from the browser
                    Dim ci As CultureInfo = CultureInfo.CreateSpecificCulture(Me.Request.UserLanguages(0))
                    ' Ensure that we have information we can use for the localized information
                    ' coming from the database
                    Dim UICandidate As String = ci.Parent.Name
                    Dim UICultureName As String = "vi"
                    Dim Languages As String() = ConfigurationSettings.AppSettings("LanguageList").Split(","c)
                    Dim s As String
                    For Each s In Languages
                        If String.Equals(s, UICandidate) Then
                            UICultureName = s
                        End If
                    Next s
                    ' Set culture and UI culture
                    Thread.CurrentThread.CurrentCulture = ci
                    Thread.CurrentThread.CurrentUICulture = New CultureInfo(UICultureName)

                    ' Save cookies
                    SetCultureInfoCookie(ci.Name, UICultureName)
                End If
            Catch
                Thread.CurrentThread.CurrentCulture = New CultureInfo("vi-VN")
                Thread.CurrentThread.CurrentUICulture = New CultureInfo("vi")
            End Try
        End Sub

        ' **********************************************************************
        ' GetStyleSheetURL
        ' **********************************************************************
        Public Function GetStyleSheetURL(ByVal name As String) As String
            'If clsSession.GlbLanguage & "" <> "unicode" And clsSession.GlbLanguage & "" <> "vni" And clsSession.GlbLanguage & "" <> "tcvn" Then
            '    name = name & ".unicode.css"
            'Else
            '    name = name & "." & clsSession.GlbLanguage & ".css"
            'End If
            name = name & "." & clsSession.GlbLanguage & ".css"
            Return String.Format("Resources/StyleSheet/" & name)
        End Function


        Public Function GetStyleSheetURL_Metro() As String
            Dim strResults As String = ""
            strResults &= vbCrLf
            strResults &= String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", String.Format("Resources/StyleSheet/metro-bootstrap-responsive.css"))
            strResults &= vbCrLf
            strResults &= String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", String.Format("Resources/StyleSheet/metro-bootstrap.css"))
            strResults &= vbCrLf
            strResults &= String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", String.Format("Resources/StyleSheet/iconFont.css"))
            strResults &= vbCrLf
            Return strResults
        End Function

        ' **********************************************************************
        ' GetImageURL
        ' **********************************************************************
        Public Function GetImageURL(ByVal name As String) As String
            Return String.Format("Image.aspx?id={0}&Script_Name={1}", name, strPathName)
        End Function

        ' **********************************************************************
        ' GetPhotoURL
        ' **********************************************************************
        Public Function GetPhotoURL(ByVal ID As Integer) As String
            Return String.Format("picture.aspx?id={0}", ID)
        End Function

        ' **********************************************************************
        ' GetThumbnailURL
        ' **********************************************************************
        Public Function GetThumbnailURL(ByVal ID As Integer) As String
            Return String.Format("thumbnail.aspx?id={0}", ID)
        End Function

        ' InsertOneRow function
        ' Purpose: insert one row at the top of the selected datatable
        Public Function InsertOneRow(ByVal scrTable As DataTable, ByVal objInsert As Object, Optional ByVal blnInsertAtEnd As Boolean = False) As DataTable
            Try
                InsertOneRow = objBCDBS.InsertOneRow(scrTable, objInsert, blnInsertAtEnd)
            Catch ex As Exception
            End Try
        End Function

        ' **********************************************************************
        ' Convert vietnamese character to english character
        ' **********************************************************************
        Private Function ParseToEngChar(ByVal strInput As String) As String
            Dim strEngChar As String
            If Trim(strInput) <> "" Then
                If InStr("A,À,Á,Ả,Ã,Ạ", strInput) > 0 Then
                    strEngChar = "A"
                ElseIf InStr("Â,Ầ,Ấ,Ẩ,Ẫ,Ậ", strInput) > 0 Then
                    strEngChar = "A"
                ElseIf InStr("Ă,Ằ,Ắ,Ẳ,Ẵ,Ặ", strInput) > 0 Then
                    strEngChar = "A"
                ElseIf InStr("E,È,É,Ẻ,Ẽ,Ẹ", strInput) > 0 Then
                    strEngChar = "E"
                ElseIf InStr("Ê,Ề,Ế,Ể,Ễ,Ệ", strInput) > 0 Then
                    strEngChar = "E"
                ElseIf InStr("U,Ù,Ú,Ủ,Ũ,Ụ", strInput) > 0 Then
                    strEngChar = "U"
                ElseIf InStr("Ư,Ừ,Ứ,Ử,Ữ,Ự", strInput) > 0 Then
                    strEngChar = "U"
                ElseIf InStr("I,Ì,Í,Ỉ,Ĩ,Ị", strInput) > 0 Then
                    strEngChar = "I"
                ElseIf InStr("O,Ò,Ó,Ỏ,Õ,Ọ", strInput) > 0 Then
                    strEngChar = "O"
                ElseIf InStr("Ô,Ồ,Ố,Ổ,Ỗ,Ộ", strInput) > 0 Then
                    strEngChar = "O"
                ElseIf InStr("Ơ,Ờ,Ớ,Ở,Ỡ,Ợ", strInput) > 0 Then
                    strEngChar = "O"
                ElseIf InStr("Y,Ỳ,Ý,Ỷ,Ỹ,Ỵ", strInput) > 0 Then
                    strEngChar = "Y"
                ElseIf InStr("Đ,D", strInput) > 0 Then
                    strEngChar = "D"
                Else
                    strEngChar = strInput
                End If
            Else
                strEngChar = ""
            End If
            ParseToEngChar = strEngChar
        End Function

        ' **********************************************************************
        ' SetResourceForControls
        ' **********************************************************************
        Private Sub SetResourceForControls()
            Me.ReadXmlFile()
            Dim ctlItem As Control
            Dim ctl As Control
            Dim strCtlName As String = ""
            Dim strCtlValue As String = ""
            Dim strArrCtlValue As String = ""
            Dim ArrCtlValue() As String
            Dim lstCtlValue As New ListItem
            Dim strAccKey As String = ""
            Dim arrAccKey() As String
            Dim i, j As Integer
            Dim ctlUpdatePanel As UpdatePanel
            Dim span_title As String = ""

            For intCtlPageCount As Integer = 0 To Page.Controls.Count - 1
                ctlItem = Page.Controls(intCtlPageCount)
                If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                    For intCtlCount As Integer = 0 To ctlItem.Controls.Count - 1
                        ctl = ctlItem.Controls(intCtlCount)
                        If TypeOf (ctl) Is UpdatePanel Then
                            ctlUpdatePanel = CType(ctl, UpdatePanel)
                            For k As Integer = 0 To ctlUpdatePanel.ContentTemplateContainer.Controls.Count - 1
                                ctl = ctlUpdatePanel.ContentTemplateContainer.Controls(k)
                                ' --- Set Label
                                If ctl.ID <> "" Then
                                    strCtlValue = ""
                                    strCtlName = ctl.ID
                                    'If Me._ReadyFile Then
                                    '    strCtlValue = GetText(strCtlName, Me._Language)
                                    'End If
                                    If blnReadyFile Then
                                        strCtlValue = GetControlValue(strCtlName)
                                    End If
                                    If TypeOf (ctl) Is WebControl Then
                                        Select Case ctl.GetType.ToString
                                            Case "System.Web.UI.WebControls.Literal"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, Literal).Text
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, Literal).Text = strCtlValue

                                            Case "System.Web.UI.WebControls.Button"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, Button).Text
                                                End If
                                                ' Set CssClass
                                                'If CType(ctl, Button).CssClass = "" Then
                                                '    CType(ctl, Button).CssClass = "btn"
                                                'End If
                                                ' Set AccessKey
                                                If strCtlValue.IndexOf("(") > 0 Then
                                                    Dim strBtnAccKey As String
                                                    strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                                    strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                                    CType(ctl, Button).AccessKey = strBtnAccKey
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, Button).Text = strCtlValue
                                            Case "System.Web.UI.WebControls.Label"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, Label).Text
                                                End If
                                                ' Set CssClass
                                                'If CType(ctl, Label).CssClass = "" Then
                                                '    CType(ctl, Label).CssClass = "lbLabel"
                                                'End If
                                                ' Get AccessKey
                                                If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                                    strAccKey = strAccKey & ParseToEngChar(UCase(strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1))) & ","
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, Label).Text = strCtlValue
                                            Case "System.Web.UI.WebControls.HyperLink"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, HyperLink).Text
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, HyperLink).Text = strCtlValue
                                                'If CType(ctl, HyperLink).CssClass = "" Then
                                                '    CType(ctl, HyperLink).CssClass = "lbLinkFunction"
                                                'End If
                                            Case "System.Web.UI.WebControls.LinkButton"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, LinkButton).Text
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, LinkButton).Text = strCtlValue
                                                'If CType(ctl, LinkButton).CssClass = "" Then
                                                '    CType(ctl, LinkButton).CssClass = "lbLinkFunction"
                                                'End If
                                                'If ctl.ID.ToString.ToUpper = "LKBLANGUAGE" Then
                                                '    If InStr(Me._ScriptName, "?") > 0 Then
                                                '        'CType(ctl, LinkButton).PostBackUrl = Me._ScriptName & String.Format("&Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                                '        CType(ctl, LinkButton).PostBackUrl = String.Format("&Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                                '    Else
                                                '        'CType(ctl, LinkButton).PostBackUrl = Me._ScriptName & String.Format("?Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                                '        CType(ctl, LinkButton).PostBackUrl = String.Format("?Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                                '    End If
                                                'End If
                                            Case "System.Web.UI.WebControls.TextBox"
                                                ' Set CssClass
                                                'If CType(ctl, TextBox).CssClass = "" Then
                                                '    CType(ctl, TextBox).CssClass = "lbTextBox"
                                                'End If
                                                ' Set AccessKey                          
                                                arrAccKey = Split(strAccKey, ",")
                                                If UBound(arrAccKey) >= 0 Then
                                                    CType(ctl, TextBox).AccessKey = arrAccKey(0)
                                                    strAccKey = Right(strAccKey, Len(strAccKey) - InStr(strAccKey, ","))
                                                End If
                                            Case "System.Web.UI.WebControls.RadioButton"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, RadioButton).Text
                                                End If
                                                ' Set CssClass
                                                'If CType(ctl, RadioButton).CssClass = "" Then
                                                '    CType(ctl, RadioButton).CssClass = "lbRadio"
                                                'End If
                                                ' Set Accesskey
                                                If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                                    Dim strOptAccKey As String
                                                    strOptAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                                    strOptAccKey = ParseToEngChar(UCase(strOptAccKey))
                                                    CType(ctl, RadioButton).AccessKey = strOptAccKey
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, RadioButton).Text = strCtlValue
                                            Case "System.Web.UI.WebControls.CheckBox"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, CheckBox).Text
                                                End If
                                                ' Set CssClass
                                                'If CType(ctl, CheckBox).CssClass = "" Then
                                                '    CType(ctl, CheckBox).CssClass = "lbCheckBox"
                                                'End If
                                                ' Set Accesskey
                                                If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                                    Dim strCbxAccKey As String
                                                    strCbxAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                                    strCbxAccKey = ParseToEngChar(UCase(strCbxAccKey))
                                                    CType(ctl, CheckBox).AccessKey = strCbxAccKey
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, CheckBox).Text = strCtlValue
                                            Case "System.Web.UI.WebControls.ListBox"
                                                Dim intSelectedIndex As Integer = CType(ctl, ListBox).SelectedIndex
                                                If strCtlValue = "" Then
                                                    For Each lstCtlValue In CType(ctl, ListBox).Items
                                                        strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                                    Next
                                                    If Len(strCtlValue) > 0 Then
                                                        strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                                    End If
                                                End If
                                                ' Set CssClass
                                                'If CType(ctl, ListBox).CssClass = "" Then
                                                '    CType(ctl, ListBox).CssClass = "lbListBox"
                                                'End If
                                                If strCtlValue <> "" Then
                                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                    ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                                    CType(ctl, ListBox).Items.Clear()
                                                    For i = 0 To UBound(ArrCtlValue) Step 2
                                                        lstCtlValue = New ListItem(ArrCtlValue(i + 1), ArrCtlValue(i))
                                                        CType(ctl, ListBox).Items.Add(lstCtlValue)
                                                    Next
                                                End If
                                                CType(ctl, ListBox).SelectedIndex = intSelectedIndex
                                            Case "System.Web.UI.WebControls.DropDownList"
                                                Dim intSelectedIndex As Integer = CType(ctl, DropDownList).SelectedIndex
                                                If strCtlValue = "" Then
                                                    strCtlValue = ""
                                                    If CType(ctl, DropDownList).Items.Count > 0 Then
                                                        For Each lstCtlValue In CType(ctl, DropDownList).Items
                                                            strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                                        Next
                                                    End If
                                                    If Len(strCtlValue) > 0 Then
                                                        strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                                    End If
                                                End If
                                                ' Set Accesskey
                                                arrAccKey = Split(strAccKey, ",")
                                                If UBound(arrAccKey) >= 0 Then
                                                    CType(ctl, DropDownList).AccessKey = arrAccKey(0)
                                                    strAccKey = Right(strAccKey, Len(strAccKey) - InStr(strAccKey, ","))
                                                End If
                                                If strCtlValue <> "" Then
                                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                    CType(ctl, DropDownList).Items.Clear()
                                                    ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                                    For i = 0 To UBound(ArrCtlValue) Step 2
                                                        lstCtlValue = New ListItem(ArrCtlValue(i + 1), ArrCtlValue(i))
                                                        CType(ctl, DropDownList).Items.Add(lstCtlValue)
                                                    Next
                                                End If
                                                CType(ctl, DropDownList).SelectedIndex = intSelectedIndex
                                            Case "System.Web.UI.WebControls.DataGrid"
                                                ' Set CssClass
                                                CType(ctl, DataGrid).CssClass = "lbGrid"
                                                CType(ctl, DataGrid).PagerStyle.CssClass = "lbGridPager"
                                                CType(ctl, DataGrid).HeaderStyle.CssClass = "lbGridHeader"
                                                CType(ctl, DataGrid).ItemStyle.CssClass = "lbGridCell"
                                                CType(ctl, DataGrid).AlternatingItemStyle.CssClass = "lbGridAlterCell"
                                                CType(ctl, DataGrid).EditItemStyle.CssClass = "lbGridEdit"
                                                If strCtlValue = "" Then
                                                    If CType(ctl, DataGrid).Columns.Count > 0 Then
                                                        For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                                            strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + Me.strSlip
                                                        Next
                                                    End If
                                                    If Len(strCtlValue) > 0 Then
                                                        strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                                    End If
                                                End If
                                                If strCtlValue <> "" Then
                                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                    ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                                    For i = 0 To UBound(ArrCtlValue)
                                                        CType(ctl, DataGrid).Columns(i).HeaderText = ArrCtlValue(i)
                                                    Next
                                                End If
                                            Case "System.Web.UI.WebControls.Table"
                                                If strCtlValue = "" Then
                                                    If CType(ctl, Table).Rows.Count > 0 Then
                                                        For i = 0 To CType(ctl, Table).Rows.Count - 1
                                                            For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                                                strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + Me.strSlip
                                                            Next
                                                            If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                                                strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(Me.strSlip))
                                                            End If
                                                            strCtlValue = strCtlValue + Me.strSlipTable
                                                        Next
                                                    End If
                                                    If Len(strCtlValue) > 0 Then
                                                        strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(Me.strSlipTable))
                                                    End If
                                                End If
                                                If strCtlValue <> "" Then
                                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                    Dim arRow() As String
                                                    arRow = Split(strCtlValue, Me.strSlipTable)
                                                    For i = LBound(arRow) To UBound(arRow)
                                                        ArrCtlValue = Split(arRow(i), Me.strSlip)
                                                        For j = LBound(ArrCtlValue) To UBound(ArrCtlValue)
                                                            CType(ctl, Table).Rows(i).Cells(j).Text = ArrCtlValue(j)
                                                        Next
                                                    Next
                                                End If
                                            Case "System.Web.UI.WebControls.ImageButton"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, ImageButton).ImageUrl
                                                Else
                                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                    CType(ctl, ImageButton).ImageUrl = strCtlValue
                                                End If
                                                CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                            Case "System.Web.UI.WebControls.Image"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, WebControls.Image).ImageUrl
                                                Else
                                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                    CType(ctl, WebControls.Image).ImageUrl = strCtlValue
                                                End If
                                                CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                            Case "System.Web.UI.HtmlControls.HtmlInputButton"
                                                If strCtlValue = "" Then
                                                    strCtlValue = CType(ctl, HtmlInputButton).Value
                                                End If
                                                ' Set CssClass
                                                'If CType(ctl, HtmlInputButton).Attributes.Item("Class") = "" Then
                                                '    CType(ctl, HtmlInputButton).Attributes.Add("Class", "lbButton")
                                                'End If
                                                ' Set AccessKey
                                                If strCtlValue.IndexOf("(") > 0 Then
                                                    Dim strBtnAccKey As String
                                                    strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                                    strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                                    CType(ctl, HtmlInputButton).Attributes.Add("AccessKey", strBtnAccKey)
                                                End If
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, HtmlInputButton).Value = strCtlValue
                                        End Select
                                    Else
                                        If Not IsNothing(strCtlName) Then
                                            Select Case ctl.GetType.BaseType.ToString()
                                                Case "System.Web.UI.HtmlControls.HtmlContainerControl"
                                                    Call setResourceHtmlContainerControl(ctl)
                                            End Select
                                        End If
                                    End If

                                End If
                            Next
                        Else
                            ' --- Set Label
                            If ctl.ID <> "" Then
                                strCtlValue = ""
                                strCtlName = ctl.ID
                                'If Me._ReadyFile Then
                                '    strCtlValue = GetText(strCtlName, Me._Language)
                                'End If
                                If blnReadyFile Then
                                    strCtlValue = GetControlValue(strCtlName)
                                End If
                                If TypeOf (ctl) Is WebControl Then
                                    Select Case ctl.GetType.ToString
                                        Case "System.Web.UI.WebControls.Literal"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, Literal).Text
                                            End If
                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, Literal).Text = strCtlValue

                                        Case "System.Web.UI.WebControls.Button"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, Button).Text
                                            End If
                                            ' Set CssClass
                                            'If CType(ctl, Button).CssClass = "" Then
                                            '    CType(ctl, Button).CssClass = "btn"
                                            'End If
                                            ' Set AccessKey
                                            If strCtlValue.IndexOf("(") > 0 Then
                                                Dim strBtnAccKey As String
                                                strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                                strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                                CType(ctl, Button).AccessKey = strBtnAccKey
                                            End If
                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, Button).Text = strCtlValue
                                        Case "System.Web.UI.WebControls.Label"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, Label).Text
                                            End If
                                            ' Set CssClass
                                            'If CType(ctl, Label).CssClass = "" Then
                                            '    CType(ctl, Label).CssClass = "lbLabel"
                                            'End If
                                            ' Get AccessKey
                                            If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                                strAccKey = strAccKey & ParseToEngChar(UCase(strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1))) & ","
                                            End If

                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, Label).Text = strCtlValue
                                        Case "System.Web.UI.WebControls.HyperLink"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, HyperLink).Text
                                            End If

                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, HyperLink).Text = strCtlValue
                                            'If CType(ctl, HyperLink).CssClass = "" Then
                                            '    CType(ctl, HyperLink).CssClass = "lbLinkFunction"
                                            'End If
                                        Case "System.Web.UI.WebControls.LinkButton"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, LinkButton).Text
                                            End If

                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, LinkButton).Text = strCtlValue
                                            'If CType(ctl, LinkButton).CssClass = "" Then
                                            '    CType(ctl, LinkButton).CssClass = "lbLinkFunction"
                                            'End If
                                            'If ctl.ID.ToString.ToUpper = "LKBLANGUAGE" Then
                                            '    If InStr(Me._ScriptName, "?") > 0 Then
                                            '        'CType(ctl, LinkButton).PostBackUrl = Me._ScriptName & String.Format("&Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                            '        CType(ctl, LinkButton).PostBackUrl = String.Format("&Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                            '    Else
                                            '        'CType(ctl, LinkButton).PostBackUrl = Me._ScriptName & String.Format("?Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                            '        CType(ctl, LinkButton).PostBackUrl = String.Format("?Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                            '    End If
                                            'End If
                                        Case "System.Web.UI.WebControls.TextBox"
                                            ' Set CssClass
                                            'If CType(ctl, TextBox).CssClass = "" Then
                                            '    CType(ctl, TextBox).CssClass = "lbTextBox"
                                            'End If
                                            ' Set AccessKey                          
                                            arrAccKey = Split(strAccKey, ",")
                                            If UBound(arrAccKey) >= 0 Then
                                                CType(ctl, TextBox).AccessKey = arrAccKey(0)
                                                strAccKey = Right(strAccKey, Len(strAccKey) - InStr(strAccKey, ","))
                                            End If
                                        Case "System.Web.UI.WebControls.RadioButton"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, RadioButton).Text
                                            End If
                                            ' Set CssClass
                                            'If CType(ctl, RadioButton).CssClass = "" Then
                                            '    CType(ctl, RadioButton).CssClass = "lbRadio"
                                            'End If
                                            ' Set Accesskey
                                            If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                                Dim strOptAccKey As String
                                                strOptAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                                strOptAccKey = ParseToEngChar(UCase(strOptAccKey))
                                                CType(ctl, RadioButton).AccessKey = strOptAccKey
                                            End If

                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, RadioButton).Text = strCtlValue
                                        Case "System.Web.UI.WebControls.CheckBox"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, CheckBox).Text
                                            End If
                                            ' Set CssClass
                                            'If CType(ctl, CheckBox).CssClass = "" Then
                                            '    CType(ctl, CheckBox).CssClass = "lbCheckBox"
                                            'End If
                                            ' Set Accesskey
                                            If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                                Dim strCbxAccKey As String
                                                strCbxAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                                strCbxAccKey = ParseToEngChar(UCase(strCbxAccKey))
                                                CType(ctl, CheckBox).AccessKey = strCbxAccKey
                                            End If

                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, CheckBox).Text = strCtlValue
                                        Case "System.Web.UI.WebControls.ListBox"
                                            Dim intSelectedIndex As Integer = CType(ctl, ListBox).SelectedIndex
                                            If strCtlValue = "" Then
                                                For Each lstCtlValue In CType(ctl, ListBox).Items
                                                    strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                                Next
                                                If Len(strCtlValue) > 0 Then
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                                End If
                                            End If

                                            ' Set CssClass
                                            'If CType(ctl, ListBox).CssClass = "" Then
                                            '    CType(ctl, ListBox).CssClass = "lbListBox"
                                            'End If
                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                                CType(ctl, ListBox).Items.Clear()
                                                For i = 0 To UBound(ArrCtlValue) Step 2
                                                    lstCtlValue = New ListItem(ArrCtlValue(i + 1), ArrCtlValue(i))
                                                    CType(ctl, ListBox).Items.Add(lstCtlValue)
                                                Next
                                            End If
                                            CType(ctl, ListBox).SelectedIndex = intSelectedIndex
                                        Case "System.Web.UI.WebControls.DropDownList"
                                            Dim intSelectedIndex As Integer = CType(ctl, DropDownList).SelectedIndex
                                            If strCtlValue = "" Then
                                                strCtlValue = ""
                                                If CType(ctl, DropDownList).Items.Count > 0 Then
                                                    For Each lstCtlValue In CType(ctl, DropDownList).Items
                                                        strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                                    Next
                                                End If
                                                If Len(strCtlValue) > 0 Then
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                                End If
                                            End If

                                            ' Set Accesskey
                                            arrAccKey = Split(strAccKey, ",")
                                            If UBound(arrAccKey) >= 0 Then
                                                CType(ctl, DropDownList).AccessKey = arrAccKey(0)
                                                strAccKey = Right(strAccKey, Len(strAccKey) - InStr(strAccKey, ","))
                                            End If
                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, DropDownList).Items.Clear()
                                                ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                                For i = 0 To UBound(ArrCtlValue) Step 2
                                                    lstCtlValue = New ListItem(ArrCtlValue(i + 1), ArrCtlValue(i))
                                                    CType(ctl, DropDownList).Items.Add(lstCtlValue)
                                                Next
                                            End If
                                            CType(ctl, DropDownList).SelectedIndex = intSelectedIndex
                                        Case "System.Web.UI.WebControls.DataGrid"
                                            ' Set CssClass
                                            CType(ctl, DataGrid).CssClass = "lbGrid"
                                            CType(ctl, DataGrid).PagerStyle.CssClass = "lbGridPager"
                                            CType(ctl, DataGrid).HeaderStyle.CssClass = "lbGridHeader"
                                            CType(ctl, DataGrid).ItemStyle.CssClass = "lbGridCell"
                                            CType(ctl, DataGrid).AlternatingItemStyle.CssClass = "lbGridAlterCell"
                                            CType(ctl, DataGrid).EditItemStyle.CssClass = "lbGridEdit"
                                            If strCtlValue = "" Then
                                                If CType(ctl, DataGrid).Columns.Count > 0 Then
                                                    For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                                        strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + Me.strSlip
                                                    Next
                                                End If
                                                If Len(strCtlValue) > 0 Then
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                                End If
                                            End If

                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                                For i = 0 To UBound(ArrCtlValue)
                                                    CType(ctl, DataGrid).Columns(i).HeaderText = ArrCtlValue(i)
                                                Next
                                            End If
                                        Case "System.Web.UI.WebControls.Table"
                                            If strCtlValue = "" Then
                                                If CType(ctl, Table).Rows.Count > 0 Then
                                                    For i = 0 To CType(ctl, Table).Rows.Count - 1
                                                        For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                                            strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + Me.strSlip
                                                        Next
                                                        If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(Me.strSlip))
                                                        End If
                                                        strCtlValue = strCtlValue + Me.strSlipTable
                                                    Next
                                                End If
                                                If Len(strCtlValue) > 0 Then
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(Me.strSlipTable))
                                                End If
                                            End If

                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                Dim arRow() As String
                                                arRow = Split(strCtlValue, Me.strSlipTable)
                                                For i = LBound(arRow) To UBound(arRow)
                                                    ArrCtlValue = Split(arRow(i), Me.strSlip)
                                                    For j = LBound(ArrCtlValue) To UBound(ArrCtlValue)
                                                        CType(ctl, Table).Rows(i).Cells(j).Text = ArrCtlValue(j)
                                                    Next
                                                Next
                                            End If
                                        Case "System.Web.UI.WebControls.ImageButton"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, ImageButton).ImageUrl
                                            Else
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, ImageButton).ImageUrl = strCtlValue
                                            End If
                                            CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                        Case "System.Web.UI.WebControls.Image"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, WebControls.Image).ImageUrl
                                            Else
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                CType(ctl, WebControls.Image).ImageUrl = strCtlValue
                                            End If
                                            CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                        Case "System.Web.UI.HtmlControls.HtmlInputButton"
                                            If strCtlValue = "" Then
                                                strCtlValue = CType(ctl, HtmlInputButton).Value
                                            End If
                                            ' Set CssClass
                                            'If CType(ctl, HtmlInputButton).Attributes.Item("Class") = "" Then
                                            '    CType(ctl, HtmlInputButton).Attributes.Add("Class", "lbButton")
                                            'End If
                                            ' Set AccessKey
                                            If strCtlValue.IndexOf("(") > 0 Then
                                                Dim strBtnAccKey As String
                                                strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                                strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                                CType(ctl, HtmlInputButton).Attributes.Add("AccessKey", strBtnAccKey)
                                            End If

                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                            CType(ctl, HtmlInputButton).Value = strCtlValue
                                    End Select
                                Else
                                    If Not IsNothing(strCtlName) Then
                                        Select Case ctl.GetType.BaseType.ToString()
                                            Case "System.Web.UI.HtmlControls.HtmlContainerControl"
                                                'If strCtlValue = "" Then
                                                '    strCtlValue = CType(ctl, HtmlContainerControl).InnerHtml
                                                'End If
                                                '' Set CssClass
                                                'If CType(ctl, HtmlContainerControl).Style.Value = "" Then
                                                '    CType(ctl, HtmlContainerControl).Style.Value = "lbl"
                                                'End If
                                                '' Set AccessKey
                                                'If strCtlValue.IndexOf("(") > 0 Then
                                                '    Dim strBtnAccKey As String
                                                '    strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                                '    strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                                '    'CType(ctl, Button).AccessKey = strBtnAccKey
                                                'End If
                                                'strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                                'CType(ctl, HtmlContainerControl).InnerHtml = strCtlValue

                                                'Try
                                                '    If ctl.ID = "span_title" Then
                                                '        span_title = strCtlValue
                                                '    End If
                                                'Catch ex As Exception : End Try
                                                Call setResourceHtmlContainerControl(ctl)
                                        End Select
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Next
        End Sub

        Private Sub ExportResource()
            Dim ctlItem As Control
            Dim ctl As Control
            Dim strCtlName As String
            Dim lstCtlValue As ListItem
            Dim strCtlValue As String
            Dim strColLanguageName As String
            Dim i, j As Integer

            Dim objDirInfor As DirectoryInfo
            Dim strDirectory As String

            '' check exists file, if exist then exit else create
            'Dim objFileInfo As New FileInfo(Me._fileName)
            'If objFileInfo.Exists Then
            '    objFileInfo = Nothing
            '    Exit Sub
            'End If
            'objFileInfo = Nothing

            'strColLanguageName = Me._Language



            'strDirectory = Left(Me._fileName, InStrRev(Me._fileName, "\") - 1)
            'objDirInfor = New DirectoryInfo(strDirectory)
            'If Not objDirInfor.Exists Then
            '    Call objDirInfor.Create()
            'End If
            'objDirInfor = Nothing
            'Me._fs = File.CreateText(Me._fileName)

            'Me._fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            'Me._fs.WriteLine("<Resources>")
            'Me._fs.WriteLine("  <Page name=""" & Me._PageName & """>")


            ' check exists file, if exist then exit else create
            Dim objFileInfo As New FileInfo(strPathName)
            If objFileInfo.Exists Then
                objFileInfo = Nothing
                Exit Sub
            End If
            objFileInfo = Nothing

            Dim ctlUpdatePanel As UpdatePanel

            strColLanguageName = "vie"
            strDirectory = Left(strPathName, InStrRev(strPathName, "\") - 1)
            objDirInfor = New DirectoryInfo(strDirectory)
            If Not objDirInfor.Exists Then
                Call objDirInfor.Create()
            End If
            objDirInfor = Nothing
            fs = File.CreateText(strPathName)

            fs.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            fs.WriteLine("<Head>")
            For Each ctlItem In Me.Page.Controls
                If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                    ' Find each controls in the Form posited on Webpages   
                    For Each ctl In ctlItem.Controls
                        If TypeOf (ctl) Is UpdatePanel Then
                            ctlUpdatePanel = CType(ctl, UpdatePanel)
                            For k As Integer = 0 To ctlUpdatePanel.ContentTemplateContainer.Controls.Count - 1
                                ctl = ctlUpdatePanel.ContentTemplateContainer.Controls(k)
                                If TypeOf (ctl) Is WebControl Then
                                    strCtlName = ctl.ID
                                    Select Case ctl.GetType.ToString
                                        Case "System.Web.UI.WebControls.Literal"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, Literal).Text)
                                        Case "System.Web.UI.WebControls.Button"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, Button).Text)
                                        Case "System.Web.UI.WebControls.Label"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, Label).Text)
                                        Case "System.Web.UI.WebControls.HyperLink"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, HyperLink).Text)
                                        Case "System.Web.UI.WebControls.LinkButton"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, LinkButton).Text)
                                        Case "System.Web.UI.WebControls.RadioButton"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, RadioButton).Text)
                                        Case "System.Web.UI.WebControls.CheckBox"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, CheckBox).Text)
                                        Case "System.Web.UI.WebControls.ListBox"
                                            strCtlValue = ""
                                            For Each lstCtlValue In CType(ctl, ListBox).Items
                                                strCtlValue = strCtlValue & lstCtlValue.Value & "|&" & lstCtlValue.Text & "|&"
                                            Next
                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                                WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - 1))
                                            End If
                                        Case "System.Web.UI.WebControls.DropDownList"
                                            strCtlValue = ""
                                            For Each lstCtlValue In CType(ctl, DropDownList).Items
                                                strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                            Next
                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                                WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip))
                                            End If
                                        Case "System.Web.UI.WebControls.DataGrid"
                                            strCtlValue = ""
                                            For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                                strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + Me.strSlip
                                            Next
                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                                WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip))
                                            End If
                                        Case "System.Web.UI.WebControls.Table"
                                            strCtlValue = ""
                                            For i = 0 To CType(ctl, Table).Rows.Count - 1
                                                For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                                    strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + Me.strSlip
                                                Next
                                                If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                                End If
                                                strCtlValue = strCtlValue + Me.strSlipTable
                                            Next
                                            If strCtlValue <> "" Then
                                                strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                                WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlipTable))
                                            End If
                                        Case "System.Web.UI.WebControls.ImageButton"
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, ImageButton).ImageUrl)
                                            'Case "System.Web.UI.WebControls.Image"
                                            '    WriteFile(strColLanguageName, strCtlName, CType(ctl, WebControls.Image).ImageUrl)
                                    End Select
                                Else
                                    strCtlName = ctl.ID
                                    If Not IsNothing(strCtlName) Then
                                        Select Case ctl.GetType.BaseType.ToString()
                                            Case "System.Web.UI.HtmlControls.HtmlContainerControl"
                                                'WriteFile(strColLanguageName, strCtlName, CType(ctl, HtmlContainerControl).InnerHtml)
                                                Call writeResourceHtmlContainerControl(ctl, strColLanguageName)
                                        End Select
                                    End If
                                End If
                            Next
                        Else
                            If TypeOf (ctl) Is WebControl Then
                                strCtlName = ctl.ID
                                Select Case ctl.GetType.ToString
                                    Case "System.Web.UI.WebControls.Literal"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, Literal).Text)
                                    Case "System.Web.UI.WebControls.Button"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, Button).Text)
                                    Case "System.Web.UI.WebControls.Label"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, Label).Text)
                                    Case "System.Web.UI.WebControls.HyperLink"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, HyperLink).Text)
                                    Case "System.Web.UI.WebControls.LinkButton"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, LinkButton).Text)
                                    Case "System.Web.UI.WebControls.RadioButton"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, RadioButton).Text)
                                    Case "System.Web.UI.WebControls.CheckBox"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, CheckBox).Text)
                                    Case "System.Web.UI.WebControls.ListBox"
                                        strCtlValue = ""
                                        For Each lstCtlValue In CType(ctl, ListBox).Items
                                            strCtlValue = strCtlValue & lstCtlValue.Value & "|&" & lstCtlValue.Text & "|&"
                                        Next
                                        If strCtlValue <> "" Then
                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                            WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - 1))
                                        End If
                                    Case "System.Web.UI.WebControls.DropDownList"
                                        strCtlValue = ""
                                        For Each lstCtlValue In CType(ctl, DropDownList).Items
                                            strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                        Next
                                        If strCtlValue <> "" Then
                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                            WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip))
                                        End If
                                    Case "System.Web.UI.WebControls.DataGrid"
                                        strCtlValue = ""
                                        For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                            strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + Me.strSlip
                                        Next
                                        If strCtlValue <> "" Then
                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                            WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip))
                                        End If
                                    Case "System.Web.UI.WebControls.Table"
                                        strCtlValue = ""
                                        For i = 0 To CType(ctl, Table).Rows.Count - 1
                                            For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                                strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + Me.strSlip
                                            Next
                                            If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                                strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                            End If
                                            strCtlValue = strCtlValue + Me.strSlipTable
                                        Next
                                        If strCtlValue <> "" Then
                                            strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                            WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlipTable))
                                        End If
                                    Case "System.Web.UI.WebControls.ImageButton"
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, ImageButton).ImageUrl)
                                        'Case "System.Web.UI.WebControls.Image"
                                        '    WriteFile(strColLanguageName, strCtlName, CType(ctl, WebControls.Image).ImageUrl)
                                End Select
                            Else
                                strCtlName = ctl.ID
                                If Not IsNothing(strCtlName) Then
                                    Select Case ctl.GetType.BaseType.ToString()
                                        Case "System.Web.UI.HtmlControls.HtmlContainerControl"
                                            'WriteFile(strColLanguageName, strCtlName, CType(ctl, HtmlContainerControl).InnerHtml)
                                            Call writeResourceHtmlContainerControl(ctl, strColLanguageName)
                                    End Select
                                End If
                            End If
                        End If
                    Next
                End If
            Next
            fs.WriteLine("</Head>")
            fs.Close()
        End Sub


        Sub writeResourceHtmlContainerControl(ByVal ctlHtmlContainerControl As HtmlContainerControl, ByVal strColLanguageName As String)
            Try
                Dim strCtlName As String = ""
                Dim strCtlValue As String = ""
                Dim strArrCtlValue As String = ""
                Dim lstCtlValue As New ListItem
                Dim strAccKey As String = ""
                Dim i, j As Integer
                Dim span_title As String = ""
                Dim ctl As Control
                If ctlHtmlContainerControl.Controls.Count = 1 Then
                    strCtlName = ctlHtmlContainerControl.ID
                    If Not IsNothing(strCtlName) AndAlso strCtlName <> "" Then
                        WriteFile(strColLanguageName, strCtlName, CType(ctlHtmlContainerControl, HtmlContainerControl).InnerHtml)
                    End If
                Else
                    For Each ctl In ctlHtmlContainerControl.Controls
                        strCtlName = ctl.ID
                        If Not IsNothing(strCtlName) AndAlso strCtlName <> "" Then
                            Select Case ctl.GetType.ToString
                                Case "System.Web.UI.WebControls.Literal"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, Literal).Text)
                                Case "System.Web.UI.WebControls.Button"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, Button).Text)
                                Case "System.Web.UI.WebControls.Label"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, Label).Text)
                                Case "System.Web.UI.WebControls.HyperLink"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, HyperLink).Text)
                                Case "System.Web.UI.WebControls.LinkButton"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, LinkButton).Text)
                                Case "System.Web.UI.WebControls.RadioButton"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, RadioButton).Text)
                                Case "System.Web.UI.WebControls.CheckBox"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, CheckBox).Text)
                                Case "System.Web.UI.WebControls.ListBox"
                                    strCtlValue = ""
                                    For Each lstCtlValue In CType(ctl, ListBox).Items
                                        strCtlValue = strCtlValue & lstCtlValue.Value & "|&" & lstCtlValue.Text & "|&"
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - 1))
                                    End If
                                Case "System.Web.UI.WebControls.DropDownList"
                                    strCtlValue = ""
                                    For Each lstCtlValue In CType(ctl, DropDownList).Items
                                        strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip))
                                    End If
                                Case "System.Web.UI.WebControls.DataGrid"
                                    strCtlValue = ""
                                    For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                        strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + Me.strSlip
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip))
                                    End If
                                Case "System.Web.UI.WebControls.Table"
                                    strCtlValue = ""
                                    For i = 0 To CType(ctl, Table).Rows.Count - 1
                                        For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                            strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + Me.strSlip
                                        Next
                                        If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                        End If
                                        strCtlValue = strCtlValue + Me.strSlipTable
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordSource, Me.strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - Me.intlenSlipTable))
                                    End If
                                Case "System.Web.UI.WebControls.ImageButton"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, ImageButton).ImageUrl)
                                    'Case "System.Web.UI.WebControls.Image"
                                    '    WriteFile(strColLanguageName, strCtlName, CType(ctl, WebControls.Image).ImageUrl)
                                Case "System.Web.UI.HtmlControls.HtmlGenericControl"
                                    Try
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, HtmlGenericControl).InnerHtml)
                                    Catch ex As Exception
                                    End Try
                                Case "System.Web.UI.HtmlControls.HtmlContainerControl"
                                    Call writeResourceHtmlContainerControl(ctl, strColLanguageName)
                                Case "System.Web.UI.LiteralControl"
                                    Try
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, LiteralControl).Text)
                                    Catch ex As Exception
                                    End Try
                                Case Else
                                    'Stop
                            End Select
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
        End Sub

        Sub setResourceHtmlContainerControl(ByVal ctlHtmlContainerControl As HtmlContainerControl)
            Try
                Dim strCtlName As String = ""
                Dim strCtlValue As String = ""
                Dim strArrCtlValue As String = ""
                Dim ArrCtlValue() As String
                Dim lstCtlValue As New ListItem
                Dim strAccKey As String = ""
                Dim arrAccKey() As String
                Dim i, j As Integer
                Dim span_title As String = ""
                Dim ctl As Control
                If ctlHtmlContainerControl.Controls.Count = 1 Then
                    strCtlName = ctlHtmlContainerControl.ID
                    If Not IsNothing(strCtlName) AndAlso strCtlName <> "" Then
                        If blnReadyFile Then
                            strCtlValue = GetControlValue(strCtlName)
                        End If
                        If strCtlValue = "" Then
                            strCtlValue = CType(ctlHtmlContainerControl, HtmlContainerControl).InnerHtml
                        End If
                        '' Set CssClass
                        'If CType(ctlHtmlContainerControl, HtmlContainerControl).Style.Value = "" Then
                        '    CType(ctlHtmlContainerControl, HtmlContainerControl).Style.Value = "lbl"
                        'End If
                        ' Set AccessKey
                        If strCtlValue.IndexOf("(") > 0 Then
                            Dim strBtnAccKey As String
                            strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                            strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                            'CType(ctl, Button).AccessKey = strBtnAccKey
                        End If
                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                        CType(ctlHtmlContainerControl, HtmlContainerControl).InnerHtml = strCtlValue
                    End If

                Else
                    For Each ctl In ctlHtmlContainerControl.Controls
                        strCtlName = ctl.ID
                        If Not IsNothing(strCtlName) AndAlso strCtlName <> "" Then

                            strCtlValue = ""

                            If blnReadyFile Then
                                strCtlValue = GetControlValue(strCtlName)
                            End If
                            Select Case ctl.GetType.ToString
                                Case "System.Web.UI.WebControls.Literal"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, Literal).Text
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, Literal).Text = strCtlValue

                                Case "System.Web.UI.WebControls.Button"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, Button).Text
                                    End If
                                    '' Set CssClass
                                    'If CType(ctl, Button).CssClass = "" Then
                                    '    CType(ctl, Button).CssClass = "btn"
                                    'End If
                                    ' Set AccessKey
                                    If strCtlValue.IndexOf("(") > 0 Then
                                        Dim strBtnAccKey As String
                                        strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                        strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                        CType(ctl, Button).AccessKey = strBtnAccKey
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, Button).Text = strCtlValue
                                Case "System.Web.UI.WebControls.Label"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, Label).Text
                                    End If
                                    ' Set CssClass
                                    'If CType(ctl, Label).CssClass = "" Then
                                    '    CType(ctl, Label).CssClass = "lbLabel"
                                    'End If
                                    ' Get AccessKey
                                    If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                        strAccKey = strAccKey & ParseToEngChar(UCase(strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1))) & ","
                                    End If

                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, Label).Text = strCtlValue
                                Case "System.Web.UI.WebControls.HyperLink"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, HyperLink).Text
                                    End If

                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, HyperLink).Text = strCtlValue
                                    'If CType(ctl, HyperLink).CssClass = "" Then
                                    '    CType(ctl, HyperLink).CssClass = "lbLinkFunction"
                                    'End If
                                Case "System.Web.UI.WebControls.LinkButton"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, LinkButton).Text
                                    End If

                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, LinkButton).Text = strCtlValue
                                    'If CType(ctl, LinkButton).CssClass = "" Then
                                    '    CType(ctl, LinkButton).CssClass = "lbLinkFunction"
                                    'End If
                                    'If ctl.ID.ToString.ToUpper = "LKBLANGUAGE" Then
                                    '    If InStr(Me._ScriptName, "?") > 0 Then
                                    '        'CType(ctl, LinkButton).PostBackUrl = Me._ScriptName & String.Format("&Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                    '        CType(ctl, LinkButton).PostBackUrl = String.Format("&Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                    '    Else
                                    '        'CType(ctl, LinkButton).PostBackUrl = Me._ScriptName & String.Format("?Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                    '        CType(ctl, LinkButton).PostBackUrl = String.Format("?Language={0}", IIf(Me._Language = "vie", "eng", "vie"))
                                    '    End If
                                    'End If
                                Case "System.Web.UI.WebControls.TextBox"
                                    ' Set CssClass
                                    'If CType(ctl, TextBox).CssClass = "" Then
                                    '    CType(ctl, TextBox).CssClass = "lbTextBox"
                                    'End If
                                    ' Set AccessKey                          
                                    arrAccKey = Split(strAccKey, ",")
                                    If UBound(arrAccKey) >= 0 Then
                                        CType(ctl, TextBox).AccessKey = arrAccKey(0)
                                        strAccKey = Right(strAccKey, Len(strAccKey) - InStr(strAccKey, ","))
                                    End If
                                Case "System.Web.UI.WebControls.RadioButton"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, RadioButton).Text
                                    End If
                                    ' Set CssClass
                                    'If CType(ctl, RadioButton).CssClass = "" Then
                                    '    CType(ctl, RadioButton).CssClass = "lbRadio"
                                    'End If
                                    ' Set Accesskey
                                    If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                        Dim strOptAccKey As String
                                        strOptAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                        strOptAccKey = ParseToEngChar(UCase(strOptAccKey))
                                        CType(ctl, RadioButton).AccessKey = strOptAccKey
                                    End If

                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, RadioButton).Text = strCtlValue
                                Case "System.Web.UI.WebControls.CheckBox"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, CheckBox).Text
                                    End If
                                    ' Set CssClass
                                    'If CType(ctl, CheckBox).CssClass = "" Then
                                    '    CType(ctl, CheckBox).CssClass = "lbCheckBox"
                                    'End If
                                    ' Set Accesskey
                                    If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                        Dim strCbxAccKey As String
                                        strCbxAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                        strCbxAccKey = ParseToEngChar(UCase(strCbxAccKey))
                                        CType(ctl, CheckBox).AccessKey = strCbxAccKey
                                    End If

                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, CheckBox).Text = strCtlValue
                                Case "System.Web.UI.WebControls.ListBox"
                                    Dim intSelectedIndex As Integer = CType(ctl, ListBox).SelectedIndex
                                    If strCtlValue = "" Then
                                        For Each lstCtlValue In CType(ctl, ListBox).Items
                                            strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                        Next
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                        End If
                                    End If

                                    ' Set CssClass
                                    'If CType(ctl, ListBox).CssClass = "" Then
                                    '    CType(ctl, ListBox).CssClass = "lbListBox"
                                    'End If
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                        CType(ctl, ListBox).Items.Clear()
                                        For i = 0 To UBound(ArrCtlValue) Step 2
                                            lstCtlValue = New ListItem(ArrCtlValue(i + 1), ArrCtlValue(i))
                                            CType(ctl, ListBox).Items.Add(lstCtlValue)
                                        Next
                                    End If
                                    CType(ctl, ListBox).SelectedIndex = intSelectedIndex
                                Case "System.Web.UI.WebControls.DropDownList"
                                    Dim intSelectedIndex As Integer = CType(ctl, DropDownList).SelectedIndex
                                    If strCtlValue = "" Then
                                        strCtlValue = ""
                                        If CType(ctl, DropDownList).Items.Count > 0 Then
                                            For Each lstCtlValue In CType(ctl, DropDownList).Items
                                                strCtlValue = strCtlValue & lstCtlValue.Value & Me.strSlip & lstCtlValue.Text & Me.strSlip
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                        End If
                                    End If

                                    ' Set Accesskey
                                    arrAccKey = Split(strAccKey, ",")
                                    If UBound(arrAccKey) >= 0 Then
                                        CType(ctl, DropDownList).AccessKey = arrAccKey(0)
                                        strAccKey = Right(strAccKey, Len(strAccKey) - InStr(strAccKey, ","))
                                    End If
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        CType(ctl, DropDownList).Items.Clear()
                                        ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                        For i = 0 To UBound(ArrCtlValue) Step 2
                                            lstCtlValue = New ListItem(ArrCtlValue(i + 1), ArrCtlValue(i))
                                            CType(ctl, DropDownList).Items.Add(lstCtlValue)
                                        Next
                                    End If
                                    CType(ctl, DropDownList).SelectedIndex = intSelectedIndex
                                Case "System.Web.UI.WebControls.DataGrid"
                                    ' Set CssClass
                                    CType(ctl, DataGrid).CssClass = "lbGrid"
                                    CType(ctl, DataGrid).PagerStyle.CssClass = "lbGridPager"
                                    CType(ctl, DataGrid).HeaderStyle.CssClass = "lbGridHeader"
                                    CType(ctl, DataGrid).ItemStyle.CssClass = "lbGridCell"
                                    CType(ctl, DataGrid).AlternatingItemStyle.CssClass = "lbGridAlterCell"
                                    CType(ctl, DataGrid).EditItemStyle.CssClass = "lbGridEdit"
                                    If strCtlValue = "" Then
                                        If CType(ctl, DataGrid).Columns.Count > 0 Then
                                            For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                                strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + Me.strSlip
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - Me.intlenSlip)
                                        End If
                                    End If

                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        ArrCtlValue = Split(strCtlValue, Me.strSlip)
                                        For i = 0 To UBound(ArrCtlValue)
                                            CType(ctl, DataGrid).Columns(i).HeaderText = ArrCtlValue(i)
                                        Next
                                    End If
                                Case "System.Web.UI.WebControls.Table"
                                    If strCtlValue = "" Then
                                        If CType(ctl, Table).Rows.Count > 0 Then
                                            For i = 0 To CType(ctl, Table).Rows.Count - 1
                                                For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                                    strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + Me.strSlip
                                                Next
                                                If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(Me.strSlip))
                                                End If
                                                strCtlValue = strCtlValue + Me.strSlipTable
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(Me.strSlipTable))
                                        End If
                                    End If

                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        Dim arRow() As String
                                        arRow = Split(strCtlValue, Me.strSlipTable)
                                        For i = LBound(arRow) To UBound(arRow)
                                            ArrCtlValue = Split(arRow(i), Me.strSlip)
                                            For j = LBound(ArrCtlValue) To UBound(ArrCtlValue)
                                                CType(ctl, Table).Rows(i).Cells(j).Text = ArrCtlValue(j)
                                            Next
                                        Next
                                    End If
                                Case "System.Web.UI.WebControls.ImageButton"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, ImageButton).ImageUrl
                                    Else
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        CType(ctl, ImageButton).ImageUrl = strCtlValue
                                    End If
                                    CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                Case "System.Web.UI.WebControls.Image"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, WebControls.Image).ImageUrl
                                    Else
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        CType(ctl, WebControls.Image).ImageUrl = strCtlValue
                                    End If
                                    CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                Case "System.Web.UI.HtmlControls.HtmlInputButton"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, HtmlInputButton).Value
                                    End If
                                    ' Set CssClass
                                    'If CType(ctl, HtmlInputButton).Attributes.Item("Class") = "" Then
                                    '    CType(ctl, HtmlInputButton).Attributes.Add("Class", "lbButton")
                                    'End If
                                    ' Set AccessKey
                                    If strCtlValue.IndexOf("(") > 0 Then
                                        Dim strBtnAccKey As String
                                        strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                        strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                        CType(ctl, HtmlInputButton).Attributes.Add("AccessKey", strBtnAccKey)
                                    End If

                                    strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                    CType(ctl, HtmlInputButton).Value = strCtlValue
                                Case "System.Web.UI.HtmlControls.HtmlContainerControl"
                                    Call setResourceHtmlContainerControl(ctl)
                                Case "System.Web.UI.HtmlControls.HtmlGenericControl"
                                    Try
                                        If strCtlValue = "" Then
                                            strCtlValue = CType(ctl, HtmlGenericControl).InnerHtml
                                        End If
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        CType(ctl, HtmlGenericControl).InnerHtml = strCtlValue
                                    Catch ex As Exception
                                    End Try
                                Case "System.Web.UI.LiteralControl"
                                    Try
                                        If strCtlValue = "" Then
                                            strCtlValue = CType(ctl, LiteralControl).Text
                                        End If
                                        strCtlValue = ReplaceWordTypical(strCtlValue, Me.strWordDes, Me.strWordSource)
                                        CType(ctl, LiteralControl).Text = strCtlValue
                                    Catch ex As Exception
                                    End Try
                                Case Else
                                    'Stop
                            End Select
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' Replace word typical
        Public Function ReplaceWordTypical(ByVal strCtlValue As String, ByVal strSourceWord As String, ByVal strDesWord As String) As String
            Return Replace(strCtlValue, strSourceWord, strDesWord)
        End Function

        ' **********************************************************************
        ' WriteFile
        ' **********************************************************************
        Private Sub WriteFile(ByVal strColLanguageName As String, ByVal strKey As String, ByVal strValue As String)
            Try
                fs.WriteLine("<data>")
                fs.WriteLine("<name>" & Replace(Replace(Replace(strKey, "<", "&lt;"), ">", "&gt;"), "&nbsp;", "") & "</name>")
                fs.WriteLine("<" & strColLanguageName & ">" & Replace(Replace(Replace(strValue, "<", "&lt;"), ">", "&gt;"), "&nbsp;", " ") & "</" & strColLanguageName & ">")
                If strColLanguageName <> "eng" Then
                    fs.WriteLine("<eng></eng>")
                End If
                fs.WriteLine("</data>")
            Catch ex As Exception
            End Try
        End Sub

        Public Function getEDataPATH() As String
            Dim strResult As String = ""
            Try
                strResult = objSysPara(11)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        'Map Virtual path
        Public Function ChangeMapVirtualPath(ByVal strPath As String) As String
            Dim strResult As String = ""
            Try
                Dim strVirtualPath As String = ""
                Dim strPhysicalPath As String = objSysPara(12)
                If objSysPara(10).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_LOCAL
                    strVirtualPath = objSysPara(10)
                ElseIf objSysPara(11).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_PUBLIC
                    strVirtualPath = objSysPara(11)
                End If
                strResult = Replace(strPath, strPhysicalPath, strVirtualPath)
                strResult = Replace(strResult, "\", "/")
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        'Get picrture card Virtual path
        Public Function getPictureCardVirtualPath() As String
            Dim strResult As String = ""
            Try
                strResult = objSysPara(13)
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        ' SendEmail method
        Public Function SendMail(ByVal strSubject As String, ByVal strContent As String, ByVal strEmailTo As String, Optional ByVal blnIsHtml As Boolean = True, Optional ByVal strEmailFrom As String = "", Optional ByVal strFileAttach As String = "") As Integer
            Dim objMail As New MailMessage
            Dim arrFileAttach() As String
            Dim intIndex As Integer

            Try
                'strSubject = Trim(objBCSP.ToUTF8(strSubject))
                If Not strEmailFrom = "" Then
                    objMail.From = strEmailFrom
                Else
                    objMail.From = objSysPara(6)
                End If

                If Not strEmailTo = "" Then
                    objMail.To = strEmailTo
                Else
                    objMail.To = objSysPara(6)
                End If

                'objMail.From = "lent@tinhvan.com"

                'objMail.To = "lent@tinhvan.com"

                objMail.Subject = strSubject

                If blnIsHtml Then
                    strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
                    objMail.BodyFormat = MailFormat.Html
                Else
                    objMail.BodyFormat = MailFormat.Text
                End If
                objMail.Body = strContent

                objMail.BodyEncoding = Text.UTF8Encoding.UTF8
                objMail.Priority = MailPriority.High
                If Not strFileAttach = "" Then
                    Try
                        arrFileAttach = strFileAttach.Split(",")
                        For intIndex = 0 To UBound(arrFileAttach)
                            objMail.Attachments.Add(New MailAttachment(arrFileAttach(intIndex), MailEncoding.UUEncode))
                        Next
                    Catch ex As Exception
                    End Try
                End If
                SmtpMail.SmtpServer = objSysPara(5)
                SmtpMail.Send(objMail)
                SendMail = 1
            Catch ex As Exception
                SendMail = 0
            End Try
        End Function

        Public Sub RegisterCalendar(Optional ByVal strOutPath As String = "../")
            'strOutCalendarPath = strOutPath
            If strColLanguage = "" Or strColLanguage Is Nothing Then
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = 'Vie';var imgDir='" & strOutPath & "Common/Calendar/'</script>")
            Else
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = '" & strColLanguage & "';var imgDir='" & strOutPath & "Common/Calendar/'</script>")
            End If

            Page.RegisterClientScriptBlock("ShowCalendar", "<script language='javascript' src='" & strOutPath & "Common/Calendar/PopCalendar1.js'></script>")
        End Sub
        Public Sub SetOnclickCalendar(ByRef lnkCalendarTmp As HyperLink, ByVal strSetField As String)
            lnkCalendarTmp.NavigateUrl = "#"
            lnkCalendarTmp.Attributes.Add("onClick", "popUpCalendar(this, document.forms[0]." & strSetField & ", '" & Session("DateFormat") & "',26)")
            'lnkCalendarTmp.Attributes.Add("onClick", "OpenWindowCalendar('" & strOutCalendarPath & "/Common/Calendar/WNCalendar.aspx?id=" & strSetField & "');")
        End Sub

        ' **********************************************************************
        ' OnError
        ' **********************************************************************
        Protected Overrides Sub OnError(ByVal e As System.EventArgs)
            Dim strRemoteAddr As String
            Dim htErrorContext As Hashtable = New Hashtable(5)
            Dim slServerVars As SortedList = New SortedList(9)

            ' Extract a subset of the server variables
            slServerVars("SCRIPT_NAME") = Request.ServerVariables("SCRIPT_NAME")
            slServerVars("HTTP_HOST") = Request.ServerVariables("HTTP_HOST")
            slServerVars("HTTP_USER_AGENT") = Request.ServerVariables("HTTP_USER_AGENT")
            'slServerVars("AUTH_TYPE") = this.AuthType
            slServerVars("AUTH_USER") = Request.ServerVariables("AUTH_USER")
            slServerVars("LOGON_USER") = Request.ServerVariables("LOGON_USER")
            slServerVars("SERVER_NAME") = Request.ServerVariables("SERVER_NAME")
            slServerVars("LOCAL_ADDR") = Request.ServerVariables("LOCAL_ADDR")
            strRemoteAddr = Request.ServerVariables("REMOTE_ADDR")
            slServerVars("REMOTE_ADDR") = strRemoteAddr

            ' Save the context information
            htErrorContext("LastError") = Server.GetLastError().ToString()
            htErrorContext("ServerVars") = slServerVars
            htErrorContext("QueryString") = Request.QueryString
            htErrorContext("Form") = Request.Form
            htErrorContext("Page") = Request.Path

            Cache.Insert(strRemoteAddr, htErrorContext, Nothing, DateTime.MaxValue, TimeSpan.FromMinutes(5))
            MyBase.OnError(e)
        End Sub


        ' setItemToMyList method
        ' Purpose: set Ids string to my list
        <WebMethod()>
        Public Shared Sub setItemToMyList(ByVal Ids As String)
            clsSession.GlbMyListIds = Ids
        End Sub

        ' WriteErrorMssg
        ' Purpose: write error message when user has not permission 
        Public Overloads Sub WriteErrorMssg(ByVal strErrorMssg As String, ByVal intErrorCode As Integer)
            'If intErrorCode > 0 Then
            '    Response.Write("<H3>Error Code: " & intErrorCode & "</H3><BR>")
            'End If
            'If Not strErrorMssg = "" Then
            '    Response.Write("<H3>Error Message: " & strErrorMssg & "</H3>")
            '    Response.End()
            'End If
        End Sub

        Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
            Try
                If Not checkValidSite() Then
                    Response.Redirect("ODefault.aspx")
                End If
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace
