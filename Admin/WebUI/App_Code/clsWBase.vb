' Class: clsWBase

Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Threading
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
'Imports System.Web.Mail
Imports System.Web.HttpException
Imports aspNetEmail
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI
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
        Protected strErrorMsg As String
        Protected intErrorCode As Integer
        Protected strTypeFile As String
        Protected lngSizeFile As Long
        Private objPara() As String = {"LDAP_AUTHENTICATION_ENABLE", "LDAP_LOCATION", "LDAP_SERVER_TYPE", "LDAP_LOGON_USER", "LDAP_LOGON_PASSWORD", "SMTP_SERVER", "ADMIN_EMAIL_ADDRESS", "EDATA_LOCATIONS", "OPAC_URL", "DATE_FORMAT", "EDATA_DOWNLOAD_DAY_LIMIT", "FILE_UPLOAD_MAX_SIZE", "USED_CLASSIFICATION", "ADMIN_EMAIL_USER_AUTHEN", "ADMIN_EMAIL_PASS", "OPAC_SERVER_LOCAL", "OPAC_SERVER_PUBLIC", "OPAC_PHYSICAL_PATH", "COVER_HEIGHT", "COVER_WIDTH", "LIBRARY_ABBREVIATION"}
        Protected objSysPara() As String
        Private strSlip As String = "|+|"
        Private intlenSlip As String = Len(strSlip)
        Private strSlipTable As String = "|++|"
        Private intlenSlipTable As String = Len(strSlipTable)
        Private strWordDes As String = "|+++|"
        Private strWordSource As String = " & "
        Private strOutCalendarPath As String

        Private strSCRIPT_NAME As String = ""
        Private strREMOTE_ADDR As String = ""

        Dim objBCSP As New eMicLibAdmin.BusinessRules.Common.clsBCommonStringProc
        Dim objBCDBS As New eMicLibAdmin.BusinessRules.Common.clsBCommonDBSystem
        Protected UploadFile As System.Web.UI.HtmlControls.HtmlInputFile

        ' **********************************************************************
        ' Declare properties
        ' **********************************************************************

        ' SCRIPT_NAME Property
        Public Property SCRIPT_NAME() As String
            Get
                SCRIPT_NAME = strSCRIPT_NAME
            End Get
            Set(ByVal Value As String)
                strSCRIPT_NAME = Value
            End Set
        End Property

        ' REMOTE_ADDR Property
        Public Property REMOTE_ADDR() As String
            Get
                REMOTE_ADDR = strREMOTE_ADDR
            End Get
            Set(ByVal Value As String)
                strREMOTE_ADDR = Value
            End Set
        End Property

        ' Error Message Property
        Public Property ErrorMsg() As String
            Get
                ErrorMsg = strErrorMsg
            End Get
            Set(ByVal Value As String)
                strErrorMsg = Value
            End Set
        End Property

        ' Error Code Property
        Public Property ErrorCode() As Integer
            Get
                ErrorCode = intErrorCode
            End Get
            Set(ByVal Value As Integer)
                intErrorCode = Value
            End Set
        End Property

        ' TypeFile property
        Public WriteOnly Property TypeFile() As String
            Set(ByVal Value As String)
                strTypeFile = Value
            End Set
        End Property

        ' SizeFile property
        Public WriteOnly Property SizeFile() As Long
            Set(ByVal Value As Long)
                lngSizeFile = Value
            End Set
        End Property

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
        ' Page Events
        '- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
        Protected Overrides Sub OnInit(ByVal e As EventArgs)
            MyBase.OnInit(e)
            'AddHandler Me.Load, AddressOf Archive_Load
            AddHandler Me.Error, AddressOf Libol_Error
        End Sub
        Protected Sub Libol_Error(ByVal sender As Object, ByVal e As EventArgs)
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
            Session("ErrorMessage") = "ERROR ON SYSTEM" & vbCrLf & vbCrLf & _
              "Has an error on this page:" & vbCrLf & vbCrLf & _
                context.Request.Url.ToString & vbCrLf & vbCrLf & _
              "Exception Details:" & _
                currentError.Message.ToString & vbCrLf & vbCrLf & _
              "Stack Trace:" & vbCrLf & _
               currentError.ToString & vbCrLf
            'show path
            Dim strPath As String = Server.MapPath("").ToUpper
            'Phuong 20080803
            'B1
            strPath = Replace(Request.ServerVariables("SCRIPT_NAME").Replace("/", "\").ToUpper, Request.ApplicationPath.Replace("/", "\").ToUpper, "")
            Dim intLen As Integer
            'intLen = InStr(strPath.Replace("/", "\"), Request.ApplicationPath.Replace("/", "\").ToUpper)
            'strPath = strPath.Substring(intLen)
            intLen = strPath.Split("\").Length - 1
            Dim inti As Integer
            strPath = "WShowError.aspx"
            For inti = 1 To intLen - 1
                strPath = "../" & strPath
            Next
            'E1
            'Response.Write("<script language='javascript'>window.open('" & strPath & "','Error','height=380,width=650,top=50,left=50,menubar=no,resizable=yes,scrollbars=yes');</script>")
        End Sub
        ' **********************************************************************
        ' Page_Load method
        ' Purpose: Load necessary objects
        ' **********************************************************************
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ' Check user already login yet?
            If clsSession.GlbUser & "" = "" Then
                Response.Write("<script language = 'javascript'>if(top.header){top.location.href= top.header.location.href.toLowerCase().replace('header.aspx', 'index.aspx');}else{self.close(); top.location.href = opener.top.header.location.href.toLowerCase().replace('header.aspx', 'index.aspx');}</script>")
                Response.End()
            Else
                Dim strJS As String

                'strJS = "top.status= 'User: " & Replace(clsSession.GlbUserFullName, "'", "\'") & "';"
                ' Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'>" & strJs & "</script>")
            End If

            Call PageInit()
            Call GetCultureInfoCookie()

            ' Get PathName of resource file
            If Request.QueryString.Get("Script_Name") <> "" Then
                strScriptName = Request.QueryString.Get("Script_Name")
            Else
                strScriptName = Request.ServerVariables("Script_Name")
            End If

            If System.Configuration.ConfigurationManager.AppSettings("URLRoot").Trim() <> "" Then
                strPathName = Right(strScriptName, Len(strScriptName) - InStr(2, strScriptName, "/"))
            Else
                strPathName = strScriptName
            End If

            Session("strPathName") = Right(strScriptName.Replace("/", "\"), Len(strScriptName) - 1)
            strPathName = "\Resources\LabelString\" & Replace(Replace(strPathName, ".aspx", ".xml"), "/", "\")
            strPathName = Server.MapPath(Request.ApplicationPath) & strPathName


            ' Export Resource 
            If Not Page.IsPostBack Then
                Call ExportResource()
            End If
            'Response.Write("<script language = 'javascript'>self.close();</script>")
            'Response.End()

            ' Set Resource for controls
            'modify by lent 2/4/2007
            If Not Page.IsPostBack Then
                Call SetResourceForControls()
            End If

            Session("DateFormat") = "dd/mm/yyyy" ' Test here

            If Not objSysPara(9) Is Nothing Then
                Session("DateFormat") = LCase(objSysPara(9))
            Else
                Session("DateFormat") = "dd/mm/yyyy"
            End If

            If objSysPara(12) = 0 Then
                Session("USED_CLASSIFICATION") = "BBK"
            Else
                Session("USED_CLASSIFICATION") = "DDC"
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
        End Sub

        ' **********************************************************************
        ' Initialize method
        ' Purpose: Init all necessary objects
        ' **********************************************************************
        Public Sub PageInit()
            ' Init objects
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")

            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            Call objBCDBS.Initialize()

            If Trim(Session("InterfaceLanguage") & "") = "" Then
                Session("InterfaceLanguage") = objBCSP.InterfaceLanguage
                If Trim(Session("InterfaceLanguage") & "") = "" Then
                    Session("InterfaceLanguage") = "vie"
                End If
            End If

            Dim objContentEncoding As System.Text.Encoding
            Dim objEncoding As System.Text.Encoding
            Select Case Trim(Session("InterfaceLanguage") & "")
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
            Dim strModule As String
            Dim arrScriptName() As String

            arrScriptName = Split(Right(Request.ServerVariables("Script_Name"), Len(Request.ServerVariables("Script_Name")) - 1), "/")
            strModule = arrScriptName(1)
            If strModule.Trim = "" Then
                strModule = "Admin"
            End If
            If clsSession.GlbLanguage & "" = "" Then
                clsSession.GlbLanguage = Session("InterfaceLanguage")
            End If
            If Session("FontType") & "" = "" Then
                Session("FontType") = "utf8"
            End If
            If Session("Typing") & "" = "" Then
                Session("Typing") = 0
            End If

            ' Get stylesheet
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", Me.GetStyleSheetURL(strModule)))
            ' Get system parameters
            Call GetSysPara()

            'Get Request server parameters
            Try
                SCRIPT_NAME = Request.ServerVariables("SCRIPT_NAME")
                REMOTE_ADDR = Request.ServerVariables("REMOTE_ADDR")
            Catch ex As Exception
            End Try
        End Sub

        'Map Virtual path
        Public Function ChangeMapVirtualPath(ByVal strPath As String) As String
            Dim strResult As String = ""
            Try
                Dim strVirtualPath As String = ""
                Dim strPhysicalPath As String = objSysPara(17)
                If objSysPara(15).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_LOCAL
                    strVirtualPath = objSysPara(15)
                ElseIf objSysPara(16).IndexOf(HttpContext.Current.Request.Url.Host.ToString) > 0 Then 'OPAC_SERVER_PUBLIC
                    strVirtualPath = objSysPara(16)
                End If
                strResult = Replace(strPath, strPhysicalPath, strVirtualPath)
                strResult = Replace(strResult, "\", "/")
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Public Function getPhysicalPath() As String
            Dim strPhysicalPath As String = ""
            Try
                strPhysicalPath = objSysPara(17)
            Catch ex As Exception
            End Try
            Return strPhysicalPath
        End Function

        Public Function getHeightCover() As Integer
            Dim intHeight As Integer = 100
            Try
                intHeight = objSysPara(18)
            Catch ex As Exception
            End Try
            Return intHeight
        End Function


        Public Function getLibraryCode() As String
            Dim strLibraycode As String = ""
            Try
                strLibraycode = objSysPara(20)
            Catch ex As Exception
            End Try
            Return strLibraycode
        End Function

        Public Function getWidthCover() As Integer
            Dim intWidth As Integer = 100
            Try
                intWidth = objSysPara(19)
            Catch ex As Exception
            End Try
            Return intWidth
        End Function


        Public Function getUploadRoot() As String
            Dim strUploadRoot As String = ""
            Try
                strUploadRoot = objSysPara(7)
            Catch ex As Exception
            End Try
            Return strUploadRoot
        End Function

        ' **********************************************************************
        ' Read XmlFile
        ' **********************************************************************
        Private Sub ReadXmlFile()
            ' Use function ConvertTable
            blnReadyFile = False
            Try
                dsResource.ReadXml(strPathName)
                If dsResource.Tables.Count > 0 Then
                    Select Case clsSession.GlbLanguage
                        Case "tcvn", "vni", "vie"
                            strColLanguage = "vie"
                        Case Else
                            strColLanguage = clsSession.GlbLanguage
                    End Select
                    dtvResource = dsResource.Tables(0).DefaultView
                    dsResource.Tables.Clear()
                    blnReadyFile = True
                End If
            Catch ex As Exception
            Finally
            End Try
        End Sub

        ' **********************************************************************
        ' GetControlValue
        ' **********************************************************************
        Public Function GetControlValue(ByVal strControlName As String) As String
            GetControlValue = ""
            dtvResource.RowFilter = "name='" & strControlName & "'"
            If dtvResource.Count > 0 Then
                Try
                    GetControlValue = dtvResource.Item(0).Item(strColLanguage)
                Catch ex As Exception
                    Try
                        GetControlValue = dtvResource.Item(0).Item("vie")
                    Catch ex1 As Exception
                    End Try
                End Try
            End If
        End Function

        ' Purpose : replace ' to ''
        Public Function DoubleSingleQuote(ByVal strText As String) As String
            DoubleSingleQuote = objBCSP.DoubleSingleQuote(strText)
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
                    Session("DateFormat") = ci.DateTimeFormat.ShortDatePattern
                    ' Ensure that we have information we can use for the localized information
                    ' coming from the database
                    Dim UICandidate As String = ci.Parent.Name
                    Dim UICultureName As String = "vi"
                    Dim sLanguages As String() = ConfigurationSettings.AppSettings("LanguageList").Split(",")
                    Dim s As String
                    For Each s In sLanguages
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
            If clsSession.GlbLanguage & "" <> "vie" And clsSession.GlbLanguage & "" <> "vni" And clsSession.GlbLanguage & "" <> "tcvn" Then
                name = name & ".unicode.css"
            Else
                name = name & "." & clsSession.GlbLanguage & ".css"
            End If
            'Return String.Format(Request.ApplicationPath & "/Resources/StyleSheet/" & name)
            Dim strTheme As String = "arcticwhite"
            Return String.Format("http://" & Request.ServerVariables("HTTP_HOST") & ReturnValueURL("URLRoot") & "/Resources/Skin/" & strTheme & "/style.css")
        End Function


        Public Function ReturnValueURL(ByVal key As String) As String
            Return Global.System.Configuration.ConfigurationManager.AppSettings(key).ToString
        End Function

        ' **********************************************************************
        ' GetImageURL
        ' **********************************************************************
        Public Function GetImageURL(ByVal name As String) As String
            Return String.Format(Request.ApplicationPath & "/Image.aspx?id={0}&Script_Name={1}", name, strPathName)
        End Function

        ' **********************************************************************
        ' GetPhotoURL
        ' **********************************************************************
        Public Function GetPhotoURL(ByVal ID As Integer) As String
            Return String.Format(Request.ApplicationPath & "/picture.aspx?id={0}", ID)
        End Function

        ' **********************************************************************
        ' GetThumbnailURL
        ' **********************************************************************
        Public Function GetThumbnailURL(ByVal ID As Integer) As String
            Return String.Format(Request.ApplicationPath & "/thumbnail.aspx?id={0}", ID)
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
        Public Sub SetResourceForControls()
            Call ReadXmlFile()
            Dim intCtlPageCount, intCtlCount As Integer
            Dim ctlItem As Control
            Dim ctl As Control
            Dim strCtlName As String
            Dim strCtlValue As String
            Dim strArrCtlValue As String
            Dim ArrCtlValue() As String
            Dim lstCtlValue As New ListItem
            Dim strAccKey As String = ""
            Dim arrAccKey() As String
            Dim i, j As Integer
            Dim objBCSP As New BusinessRules.Common.clsBCommonStringProc
            If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                objBCSP.ConnectionString = Session("ConnectionString")
                objBCSP.DBServer = Session("DBServer")
                objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
                objBCSP.Initialize()
            End If
            For intCtlPageCount = 0 To Page.Controls.Count - 1
                ctlItem = Page.Controls(intCtlPageCount)
                If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
                    For intCtlCount = 0 To ctlItem.Controls.Count - 1
                        ctl = ctlItem.Controls(intCtlCount)
                        ' --- Set Label
                        If ctl.ID <> "" Then
                            strCtlValue = ""
                            strCtlName = ctl.ID
                            If blnReadyFile Then
                                strCtlValue = GetControlValue(strCtlName)
                            End If
                            Select Case ctl.GetType.ToString
                                Case "System.Web.UI.WebControls.Button"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, Button).Text
                                    End If
                                    ' Set CssClass
                                    If CType(ctl, Button).CssClass = "" Then
                                        CType(ctl, Button).CssClass = "lbButton"
                                    End If
                                    ' Set AccessKey
                                    If strCtlValue.IndexOf("(") > 0 Then
                                        Dim strBtnAccKey As String
                                        strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                        strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                        CType(ctl, Button).AccessKey = strBtnAccKey
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    CType(ctl, Button).Text = strCtlValue
                                Case "System.Web.UI.WebControls.Label"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, Label).Text
                                    End If
                                    ' Set CssClass
                                    If CType(ctl, Label).CssClass = "" Then
                                        CType(ctl, Label).CssClass = "lbLabel"
                                    End If
                                    ' Get AccessKey
                                    If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                        strAccKey = strAccKey & ParseToEngChar(UCase(strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1))) & ","
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    CType(ctl, Label).Text = strCtlValue
                                Case "System.Web.UI.WebControls.HyperLink"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, HyperLink).Text
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    CType(ctl, HyperLink).Text = strCtlValue
                                    If CType(ctl, HyperLink).CssClass = "" Then
                                        CType(ctl, HyperLink).CssClass = "lbLinkFunction"
                                    End If
                                Case "System.Web.UI.WebControls.LinkButton"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, LinkButton).Text
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    CType(ctl, LinkButton).Text = strCtlValue
                                    If CType(ctl, LinkButton).CssClass = "" Then
                                        CType(ctl, LinkButton).CssClass = "lbLinkFunction"
                                    End If
                                Case "System.Web.UI.WebControls.TextBox"
                                    ' Set CssClass
                                    If CType(ctl, TextBox).CssClass = "" Then
                                        CType(ctl, TextBox).CssClass = "lbTextBox"
                                    End If
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
                                    If CType(ctl, RadioButton).CssClass = "" Then
                                        CType(ctl, RadioButton).CssClass = "lbRadio"
                                    End If
                                    ' Set Accesskey
                                    If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                        Dim strOptAccKey As String
                                        strOptAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                        strOptAccKey = ParseToEngChar(UCase(strOptAccKey))
                                        CType(ctl, RadioButton).AccessKey = strOptAccKey
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    CType(ctl, RadioButton).Text = strCtlValue
                                Case "System.Web.UI.WebControls.CheckBox"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, CheckBox).Text
                                    End If
                                    ' Set CssClass
                                    If CType(ctl, CheckBox).CssClass = "" Then
                                        CType(ctl, CheckBox).CssClass = "lbCheckBox"
                                    End If
                                    ' Set Accesskey
                                    If strCtlValue.IndexOf("<U>") >= 0 Or strCtlValue.IndexOf("<u>") >= 0 Then
                                        Dim strCbxAccKey As String
                                        strCbxAccKey = strCtlValue.Substring(strCtlValue.IndexOf("<U>") + strCtlValue.IndexOf("<u>") + 4, 1)
                                        strCbxAccKey = ParseToEngChar(UCase(strCbxAccKey))
                                        CType(ctl, CheckBox).AccessKey = strCbxAccKey
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    CType(ctl, CheckBox).Text = strCtlValue
                                Case "System.Web.UI.WebControls.ListBox"
                                    Dim intSelectedIndex As Integer = CType(ctl, ListBox).SelectedIndex
                                    If strCtlValue = "" Then
                                        For Each lstCtlValue In CType(ctl, ListBox).Items
                                            strCtlValue = strCtlValue & lstCtlValue.Value & strSlip & lstCtlValue.Text & strSlip
                                        Next
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - intlenSlip)
                                        End If
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    ' Set CssClass
                                    If CType(ctl, ListBox).CssClass = "" Then
                                        CType(ctl, ListBox).CssClass = "lbListBox"
                                    End If
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                        ArrCtlValue = Split(strCtlValue, strSlip)
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
                                                strCtlValue = strCtlValue & lstCtlValue.Value & strSlip & lstCtlValue.Text & strSlip
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - intlenSlip)
                                        End If
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    ' Set Accesskey
                                    arrAccKey = Split(strAccKey, ",")
                                    If UBound(arrAccKey) >= 0 Then
                                        CType(ctl, DropDownList).AccessKey = arrAccKey(0)
                                        strAccKey = Right(strAccKey, Len(strAccKey) - InStr(strAccKey, ","))
                                    End If
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                        CType(ctl, DropDownList).Items.Clear()
                                        ArrCtlValue = Split(strCtlValue, strSlip)
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
                                                strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + strSlip
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - intlenSlip)
                                        End If
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                        ArrCtlValue = Split(strCtlValue, strSlip)
                                        For i = 0 To UBound(ArrCtlValue) - 1
                                            CType(ctl, DataGrid).Columns(i).HeaderText = ArrCtlValue(i)
                                        Next
                                    End If
                                Case "Telerik.Web.UI.RadGrid"
                                    ' Set CssClass
                                    CType(ctl, RadGrid).CssClass = "lbGrid"
                                    CType(ctl, RadGrid).PagerStyle.CssClass = "lbGridPager"
                                    CType(ctl, RadGrid).HeaderStyle.CssClass = "lbGridHeader"
                                    CType(ctl, RadGrid).ItemStyle.CssClass = "lbGridCell"
                                    CType(ctl, RadGrid).AlternatingItemStyle.CssClass = "lbGridAlterCell"
                                    CType(ctl, RadGrid).EditItemStyle.CssClass = "lbGridEdit"
                                    If strCtlValue = "" Then
                                        If CType(ctl, RadGrid).Columns.Count > 0 Then
                                            For i = 0 To CType(ctl, RadGrid).Columns.Count - 1
                                                strCtlValue = strCtlValue + CType(ctl, RadGrid).MasterTableView.Columns(i).HeaderText + strSlip
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - intlenSlip)
                                        End If
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                        ArrCtlValue = Split(strCtlValue, strSlip)
                                        For i = 0 To UBound(ArrCtlValue)
                                            CType(ctl, RadGrid).MasterTableView.Columns(i).HeaderText = ArrCtlValue(i)
                                        Next
                                    End If
                                Case "System.Web.UI.WebControls.Table"
                                    If strCtlValue = "" Then
                                        If CType(ctl, Table).Rows.Count > 0 Then
                                            For i = 0 To CType(ctl, Table).Rows.Count - 1
                                                For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                                    strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + strSlip
                                                Next
                                                If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(strSlip))
                                                End If
                                                strCtlValue = strCtlValue + strSlipTable
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - Len(strSlipTable))
                                        End If
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                        Dim arRow() As String
                                        arRow = Split(strCtlValue, strSlipTable)
                                        For i = LBound(arRow) To UBound(arRow)
                                            ArrCtlValue = Split(arRow(i), strSlip)
                                            For j = LBound(ArrCtlValue) To UBound(ArrCtlValue)
                                                CType(ctl, Table).Rows(i).Cells(j).Text = ArrCtlValue(j)
                                            Next
                                        Next
                                    End If
                                Case "System.Web.UI.WebControls.ImageButton"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, ImageButton).ImageUrl
                                    Else
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                        CType(ctl, ImageButton).ImageUrl = strCtlValue
                                    End If
                                    CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                Case "System.Web.UI.WebControls.Image"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, WebControls.Image).ImageUrl
                                    Else
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                        CType(ctl, WebControls.Image).ImageUrl = strCtlValue
                                    End If
                                    CType(ctl, WebControls.Image).BorderWidth = Unit.Pixel(0)
                                Case "System.Web.UI.HtmlControls.HtmlInputButton"
                                    If strCtlValue = "" Then
                                        strCtlValue = CType(ctl, HtmlInputButton).Value
                                    End If
                                    ' Set CssClass
                                    If CType(ctl, HtmlInputButton).Attributes.Item("Class") = "" Then
                                        CType(ctl, HtmlInputButton).Attributes.Add("Class", "lbButton")
                                    End If
                                    ' Set AccessKey
                                    If strCtlValue.IndexOf("(") > 0 Then
                                        Dim strBtnAccKey As String
                                        strBtnAccKey = strCtlValue.Substring(strCtlValue.IndexOf("(") + 1, 1)
                                        strBtnAccKey = ParseToEngChar(UCase(strBtnAccKey))
                                        CType(ctl, HtmlInputButton).Attributes.Add("AccessKey", strBtnAccKey)
                                    End If
                                    ' Convert to CurrenEncode
                                    If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                        strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    End If
                                    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    CType(ctl, HtmlInputButton).Value = strCtlValue
                            End Select
                        End If
                    Next
                End If
            Next
        End Sub

        ' Replace word typical
        Public Function ReplaceWordTypical(ByVal strCtlValue As String, ByVal strSourceWord As String, ByVal strDesWord As String) As String
            Return Replace(strCtlValue, strSourceWord, strDesWord)
        End Function

        ' **********************************************************************
        ' ExportResource
        ' **********************************************************************
        Public Sub ExportResource()
            Dim ctlItem As Control
            Dim ctl As Control
            Dim strCtlName As String
            Dim lstCtlValue As ListItem
            Dim strCtlValue As String
            Dim strColLanguageName As String
            Dim i, j As Integer
            Dim objDirInfor As DirectoryInfo
            Dim strDirectory As String

            ' check exists file, if exist then exit else create
            Dim objFileInfo As New FileInfo(strPathName)
            If objFileInfo.Exists Then
                objFileInfo = Nothing
                Exit Sub
            End If
            objFileInfo = Nothing

            strColLanguageName = "vie"

            'Select Case clsSession.GlbLanguage
            '    Case "vie", "tcvn", "vni"
            '        strColLanguageName = "vie"
            '    Case Else
            '        strColLanguageName = clsSession.GlbLanguage
            'End Select

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
                        If TypeOf (ctl) Is WebControl Then
                            strCtlName = ctl.ID
                            Select Case ctl.GetType.ToString
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
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordSource, strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - 1))
                                    End If
                                Case "System.Web.UI.WebControls.DropDownList"
                                    strCtlValue = ""
                                    For Each lstCtlValue In CType(ctl, DropDownList).Items
                                        strCtlValue = strCtlValue & lstCtlValue.Value & strSlip & lstCtlValue.Text & strSlip
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordSource, strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - intlenSlip))
                                    End If
                                Case "System.Web.UI.WebControls.DataGrid"
                                    strCtlValue = ""
                                    For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                        strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + strSlip
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordSource, strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - intlenSlip))
                                    End If
                                Case "Telerik.Web.UI.RadGrid"
                                    ' Set CssClass
                                    strCtlValue = ""
                                    For i = 0 To CType(ctl, RadGrid).Columns.Count - 1
                                        strCtlValue = strCtlValue + CType(ctl, RadGrid).MasterTableView.Columns(i).HeaderText + strSlip
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordSource, strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - intlenSlip))
                                    End If

                                Case "System.Web.UI.WebControls.Table"
                                    strCtlValue = ""
                                    For i = 0 To CType(ctl, Table).Rows.Count - 1
                                        For j = 0 To CType(ctl, Table).Rows(i).Cells.Count - 1
                                            strCtlValue = strCtlValue + CType(ctl, Table).Rows(i).Cells(j).Text + strSlip
                                        Next
                                        If CType(ctl, Table).Rows(i).Cells.Count > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - intlenSlip)
                                        End If
                                        strCtlValue = strCtlValue + strSlipTable
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = ReplaceWordTypical(strCtlValue, strWordSource, strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - intlenSlipTable))
                                    End If
                                Case "System.Web.UI.WebControls.ImageButton"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, ImageButton).ImageUrl)
                                Case "System.Web.UI.WebControls.Image"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, WebControls.Image).ImageUrl)
                            End Select
                        Else
                            strCtlName = ctl.ID
                            Select Case ctl.GetType.ToString
                                Case "System.Web.UI.HtmlControls.HtmlInputButton"
                                    WriteFile(strColLanguageName, strCtlName, CType(ctl, HtmlInputButton).Value)
                            End Select
                        End If
                    Next
                End If
            Next
            fs.WriteLine("</Head>")
            fs.Close()
        End Sub

        ' **********************************************************************
        ' WriteFile
        ' **********************************************************************
        Private Sub WriteFile(ByVal strColLanguageName As String, ByVal strKey As String, ByVal strValue As String)
            fs.WriteLine("<data>")
            fs.WriteLine("<name>" & Replace(Replace(Replace(strKey, "<", "&lt;"), ">", "&gt;"), "&nbsp;", "") & "</name>")
            fs.WriteLine("<" & strColLanguageName & ">" & Trim(Replace(Replace(Replace(Replace(Replace(strValue, "<", "&lt;"), ">", "&gt;"), "&nbsp;", " "), vbCrLf, ""), "	"c, "")) & "</" & strColLanguageName & ">")
            If strColLanguageName <> "eng" Then
                fs.WriteLine("<eng></eng>")
            End If
            fs.WriteLine("</data>")
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

        ' Write Log method
        Public Sub WriteLog(ByVal lngGroupID As Long, ByVal strMsg As String, ByVal strFilename As String, ByVal strRemoteHost As String, ByVal strUserName As String)
            objBCDBS.WriteLog(lngGroupID, strMsg.Replace("'", "''"), strFilename, strRemoteHost, clsSession.GlbUser)
        End Sub

        ' WriteErrorMssg
        ' Purpose: write error message when user has not permission 
        Public Overloads Sub WriteErrorMssg(ByVal strErrorMsg As String)
            Response.Write("<CENTER><H2><FONT COLOR=""RED"">" & strErrorMsg & "</FONT></H2></CENTER>")
            Response.End()
        End Sub

        ' WriteErrorMssg
        ' Purpose: write error message when user has not permission 
        Public Overloads Sub WriteErrorMssg(ByVal intErrorCode As Integer, ByVal strErrorMsg As String)
            'If Not strErrorMsg = "" Then
            '    If intErrorCode > 0 Then
            '        Page.RegisterClientScriptBlock("ErrorAlert", "<script language='javascript'>alert('ErrorCode: " & intErrorCode & "\n ErrorMessage: " & strErrorMsg & " ');</script>")
            '    Else
            '        Page.RegisterClientScriptBlock("ErrorAlert", "<script language='javascript'>alert('ErrorMessage: " & strErrorMsg & " ');</script>")
            '    End If
            '    Response.End()
            'End If
        End Sub

        ' WriteErrorMssg
        ' Purpose: write error message when user has not permission 
        Public Overloads Sub WriteErrorMssg(ByVal strEM As String, ByVal strErrorMssg As String, ByVal strEC As String, ByVal intErrorCode As Integer)
            'If intErrorCode > 0 Then
            '    Response.Write("<H2><FONT COLOR=""RED"">" & strEC & ": " & intErrorCode & "</FONT></H2>")
            'End If
            'If Not strErrorMssg = "" Then
            '    Response.Write("<H2><FONT COLOR=""RED"">" & strEM & ": " & strErrorMssg & "</FONT></H2>")
            '    Response.End()
            'End If
        End Sub

        ' WriteErrorMssg
        ' Purpose: write permission error message when user has not permission 
        Public Overloads Sub WritePermErrorMssg()
            Dim strErrorMsg As String
            If clsSession.GlbLanguage = "vni" Or clsSession.GlbLanguage = "vie" Or clsSession.GlbLanguage = "tcvn" Then
                strErrorMsg = "Bạn không được cấp quyền sử dụng tính năng này!"
            Else
                strErrorMsg = "Bạn không được cấp quyền sử dụng tính năng này!"
            End If
            Response.Write("<CENTER><H2><FONT COLOR=""RED"">" & strErrorMsg & "</FONT></H2></CENTER>")
            Response.End()
        End Sub

        ' CheckPemission function
        ' Input: int Pemission
        ' Output: False if user has not module Pemission
        Public Function CheckPemission() As Boolean
            CheckPemission = False
            If clsSession.GlbUser.ToLower() = "Admin".ToLower() Then
                CheckPemission = True
            Else
                If clsSession.ModuleID = 1 And Session("CatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 2 And Session("PatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 3 And Session("CirModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 4 And Session("AcqModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 5 And Session("SerModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 6 And Session("AdmModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 8 And Session("ILLModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 9 And Session("DELModule") = 0 Then
                    Return False
                End If
                CheckPemission = True
            End If
        End Function

        ' CheckPemission function
        ' Input: int Pemission
        ' Output: True if user has this Pemission or False if user hasn't this Pemission 
        Public Function CheckPemission(ByVal intPemission As Integer) As Boolean
            'CheckPemission = False
            'If Not Session("UserRights") Is Nothing Then
            '    If InStr("," & Session("UserRights"), "," & intPemission & ",") > 0 Then
            '        CheckPemission = True
            '    End If
            'End If

            CheckPemission = False
            If clsSession.GlbUser.ToLower() = "Admin".ToLower() Then
                CheckPemission = True
            Else
                If clsSession.ModuleID = 1 And Session("CatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 2 And Session("PatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 3 And Session("CirModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 4 And Session("AcqModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 5 And Session("SerModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 6 And Session("AdmModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 8 And Session("ILLModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 9 And Session("DELModule") = 0 Then
                    Return False
                ElseIf Not Session("UserRights") Is Nothing Then
                    If InStr("," & Session("UserRights"), "," & intPemission & ",") > 0 Then
                        CheckPemission = True
                    End If
                End If
            End If
        End Function

        ' CheckPemission function
        ' Input: int Pemission
        ' Output: True if user has this Pemission or False if user hasn't this Pemission 
        Public Function CheckPemission(ByVal strPemission As String) As Boolean
            'Dim strPemissionID() As String = strPemission.Split(",")
            'Dim inti As Integer
            'Dim blnCheckPemission As Boolean = True

            'For inti = 0 To strPemissionID.Length - 1
            '    If Not Session("UserRights") Is Nothing Then
            '        If InStr("," & Session("UserRights"), "," & strPemissionID(inti) & ",") = 0 Then
            '            blnCheckPemission = False
            '            Exit For
            '        End If
            '    End If
            'Next
            'Return blnCheckPemission
            Dim strPemissionID() As String = strPemission.Split(",")
            Dim inti As Integer
            Dim blnCheckPemission As Boolean = True
            If Not clsSession.GlbUser = "Admin" Then
                For inti = 0 To strPemissionID.Length - 1
                    If Not Session("UserRights") Is Nothing Then
                        If InStr("," & Session("UserRights"), "," & strPemissionID(inti) & ",") = 0 Then
                            blnCheckPemission = False
                            Exit For
                        End If
                    End If
                Next
            End If
            Return blnCheckPemission
        End Function

        ' InsertOneRow function
        ' Purpose: insert one row at the top of the selected datatable
        Public Function InsertOneRow(ByVal scrTable As DataTable, ByVal objInsert As Object, Optional ByVal blnInsertAtEnd As Boolean = False) As DataTable
            Try
                InsertOneRow = objBCDBS.InsertOneRow(scrTable, objInsert, blnInsertAtEnd)
                intErrorCode = objBCDBS.ErrorCode
                strErrorMsg = objBCDBS.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            End Try
        End Function

        ' CreateTable function
        ' Purpose: create datatable from 2 array
        Public Function CreateTable(ByVal ArrTextField As Object, ByVal ArrValueField As Object) As DataTable
            CreateTable = objBCDBS.CreateTable(ArrTextField, ArrValueField)
        End Function

        ' ToUTF8 funtion
        ' Purpose: convert string to utf8
        Public Function ToUTF8(ByVal strIn As String) As String
            ToUTF8 = objBCSP.ToUTF8(strIn)
        End Function

        ' ToUTF8Back funtion
        ' Purpose: convert string to utf8
        Public Function ToUTF8Back(ByVal strIn As String) As String
            ToUTF8Back = objBCSP.ToUTF8Back(strIn)
        End Function

        ' ReadFromFile function
        Public Function ReadFromFile(ByVal filename As String) As String
            Dim f As File
            Dim fs As FileStream = f.OpenRead(filename)
            Dim sr As StreamReader = New StreamReader(fs)
            ReadFromFile = sr.ReadToEnd
            sr.Close()
            fs.Close()
        End Function

        Public Function CheckType(ByVal strFile As String) As Boolean
            Dim strArrType() As String
            Dim byti As Byte
            Dim strExt As String
            Dim blnRet As Boolean
            strTypeFile = Replace(strTypeFile, " ", "")
            blnRet = False
            If strTypeFile = "" Then
                blnRet = True
            Else
                strArrType = Split(strTypeFile, ";", , CompareMethod.Text)
                strExt = Trim(Right(strFile, strFile.Length - InStrRev(strFile, ".")))
                For byti = 0 To UBound(strArrType)
                    If UCase(strExt).Equals(UCase(strArrType(byti))) Then
                        blnRet = True
                        Exit For
                    End If
                Next
            End If
            CheckType = blnRet
        End Function

        Public Function CheckSize(ByVal lngSizeF As Long) As Boolean
            If lngSizeFile = 0 Then
                ' default = 10 MB
                If lngSizeF >= CLng(objSysPara(11)) * 1024 Then
                    Return False
                Else
                    Return True
                End If
            Else
                ' For > 4 MB
                If lngSizeF > lngSizeFile And lngSizeFile > 0 And lngSizeF >= 4194304 Then
                    Return False
                Else
                    Return True
                End If
            End If
        End Function

        Public Function UpLoadFiles(ByVal objUpload As System.Web.UI.HtmlControls.HtmlInputFile, ByVal strPathSave As String, Optional ByVal strDesFile As String = "") As String
            Dim strRet As String

            strRet = "Fail"
            Try
                If (strPathSave <> "") Then
                    If (Not IsDBNull(objUpload.PostedFile)) And (objUpload.PostedFile.FileName.Length > 0) Then
                        If CheckSize(objUpload.PostedFile.ContentLength) Then
                            Dim strFN As String
                            strFN = Trim(Right(objUpload.PostedFile.FileName, Len(objUpload.PostedFile.FileName) - InStrRev(objUpload.PostedFile.FileName, "\")))
                            Dim strExt As String
                            If InStr(strFN, ".") > 0 Then
                                strExt = Right(strFN, Len(strFN) - InStr(strFN, ".") + 1)
                            Else
                                strExt = ""
                            End If
                            If CheckType(strFN) Then
                                If strDesFile = "" Then
                                    objUpload.PostedFile.SaveAs(strPathSave & "\" & strFN)
                                    strRet = strFN
                                Else
                                    If InStr(strDesFile, ".") > 0 Then
                                        objUpload.PostedFile.SaveAs(strPathSave & "\" & strDesFile)
                                        strRet = strDesFile
                                    Else
                                        objUpload.PostedFile.SaveAs(strPathSave & "\" & strDesFile & strExt)
                                        strRet = strDesFile & strExt
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
            UpLoadFiles = strRet
        End Function
        Public Function CheckFileType(ByVal objUpload As System.Web.UI.HtmlControls.HtmlInputFile) As Boolean
      
            Try
                If (Not IsDBNull(objUpload.PostedFile)) And (objUpload.PostedFile.FileName.Length > 0) Then
                    If CheckSize(objUpload.PostedFile.ContentLength) Then
                        Dim strFN As String
                        strFN = Trim(Right(objUpload.PostedFile.FileName, Len(objUpload.PostedFile.FileName) - InStrRev(objUpload.PostedFile.FileName, "\")))
                        Dim strExt As String
                        If InStr(strFN, ".") > 0 Then
                            strExt = Right(strFN, Len(strFN) - InStr(strFN, ".") + 1).ToLower()
                            If (Not strExt.Contains("iso") And Not strExt.Contains("xls") And Not strExt.Contains("xlsx")) Then
                                Return False
                            End If
                        Else
                            strExt = ""
                        End If
                       
                    End If
                End If

            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
            End Try
            CheckFileType = True
        End Function

        ' GenRandomNumber method
        ' Purpose: generate a random number
        Public Function GenRandomNumber(ByVal intNumber) As String
            Dim strGRN As String = ""
            Dim intIndex As Integer

            Randomize()
            For intIndex = 1 To intNumber
                strGRN = strGRN & Chr(Int(Rnd(1) * 10) + 48)
            Next
            GenRandomNumber = strGRN
        End Function

        ' Method: Round
        Function Round(ByVal strInput As String) As Long 'Integer
            Dim objTemp As Object
            objTemp = Split(strInput, ",")
            If UBound(objTemp) = 0 Then
                objTemp = Split(strInput, ".")
            End If
            'Round = CInt(objTemp(0))
            Round = CLng(objTemp(0))
        End Function

        ' Function: DayOfNow
        ' Purpose: get day format of now
        Public Function DayOfNow(Optional ByVal ShowTime As Boolean = False) As String
            Return objBCDBS.ConvertDate(Now, ShowTime)
        End Function

        ' Function: FormatOfDay
        ' Purpose: get format of day in system parameters
        Public Function FormatOfDay() As String
            Dim strPara(1) As String
            Dim strARet(1) As String
            strPara(0) = "DATE_FORMAT"
            strARet = objBCDBS.GetSystemParameters(strPara)
            If strARet(0) <> "" Then
                FormatOfDay = strARet(0)
            Else
                FormatOfDay = "DD/MM/YYYY"
            End If
        End Function

        ' SendMail method
        'Public Function SendMail_OLD(ByVal strSubject As String, ByVal strContent As String, ByVal strEmailTo As String, Optional ByVal blnIsHtml As Boolean = True, Optional ByVal strEmailFrom As String = "", Optional ByVal strFileAttach As String = "") As Integer
        '    Dim objMail As New MailMessage
        '    Dim arrFileAttach() As String
        '    Dim intIndex As Integer

        '    Try
        '        'strSubject = Trim(objBCSP.ToUTF8(strSubject))
        '        If Not strEmailFrom = "" Then
        '            objMail.From = strEmailFrom
        '        Else
        '            objMail.From = objSysPara(6)
        '        End If

        '        If Not strEmailTo = "" Then
        '            objMail.To = strEmailTo
        '        Else
        '            objMail.To = objSysPara(6)
        '        End If

        '        'objMail.From = "info@dgsoft.vn"

        '        'objMail.To = "info@dgsoft.vn"

        '        objMail.Subject = strSubject
        '        objMail.Headers.Add("Content-Transfer-Encoding", "8bit")
        '        If blnIsHtml Then
        '            strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
        '            objMail.BodyFormat = MailFormat.Html
        '        Else
        '            objMail.BodyFormat = MailFormat.Text
        '        End If
        '        objMail.Body = strContent

        '        objMail.BodyEncoding = System.Text.Encoding.UTF8
        '        objMail.Priority = MailPriority.High
        '        If Not strFileAttach = "" Then
        '            Try
        '                arrFileAttach = strFileAttach.Split(",")
        '                For intIndex = 0 To UBound(arrFileAttach)
        '                    objMail.Attachments.Add(New MailAttachment(arrFileAttach(intIndex), MailEncoding.UUEncode))
        '                Next
        '            Catch ex As Exception
        '            End Try
        '        End If
        '        SmtpMail.SmtpServer = objSysPara(5)
        '        SmtpMail.Send(objMail)
        '        SendMail = 1
        '    Catch ex As Exception
        '        SendMail = 0
        '        strErrorMsg = ex.Message
        '    End Try
        'End Function

        'Phuong 20080929
        'B1
        'Public Function Send2Mail(ByVal strEmailSubject As String, ByVal strContent As String, ByVal strEmail As String) As Integer
        '    Dim intResult As Integer = 1
        '    Try
        '        Dim objSysPara() As String
        '        Dim objPara() As String = {"SMTP_SERVER", "SMTP_PORT", "ADMIN_EMAIL_ADDRESS", "ADMIN_EMAIL_PASS"}
        '        objSysPara = objBCDBS.GetSystemParameters(objPara)
        '        Dim strSMTPServer As String = ""
        '        If Not IsNothing(objSysPara(0)) Then
        '            strSMTPServer = objSysPara(0)
        '        End If
        '        Dim strSMTPPort As String = ""
        '        If Not IsNothing(objSysPara(1)) Then
        '            strSMTPPort = objSysPara(1)
        '        End If
        '        Dim strSMTPMailUser As String = ""
        '        If Not IsNothing(objSysPara(2)) Then
        '            strSMTPMailUser = objSysPara(2)
        '        End If
        '        Dim strSMTPMailPass As String = ""
        '        If Not IsNothing(objSysPara(3)) Then
        '            strSMTPMailPass = objSysPara(3)
        '        End If
        '        strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")

        '        'Dim strBody As String = "Xin chào " & fullName.Trim & "!" & vbCrLf & vbCrLf
        '        'strBody &= "Cám ơn bạn đã đăng ký tài khoản đọc sách trực tuyến tại " & clsCommon.SendRegMailFrom & vbCrLf & vbCrLf
        '        'strBody &= "Tài khoản đăng nhập của bạn là: " & strUser & vbCrLf & vbCrLf
        '        'strBody &= clsCommon.SendRegMailFrom & " được xây dựng nhằm mục đích hỗ trợ người dùng có thể dễ dàng tìm kiếm, chia sẻ nguồn tri thức, kết nối những người yêu và đam mê đọc sách..." & vbCrLf & vbCrLf
        '        'strBody &= "Chúng tôi rất vui nếu nhận được sự đóng góp và phản hồi của các bạn. Mọi đóng góp xin vui lòng gửi về địa chỉ: " & clsCommon.SendRegMailUser & vbCrLf & vbCrLf
        '        'strBody &= "Trân trọng!" & vbCrLf
        '        'Dim bolGmail As Boolean = False
        '        'If InStr(strSMTPMailUser.ToLower, "gmail.com") > 0 Then
        '        '    bolGmail = True
        '        'End If
        '        'Dim mailMessage As New MailMessage()
        '        'Dim mailClient As New SmtpClient(strSMTPMailUser, strSMTPPort)
        '        'With mailClient
        '        '    .Timeout = 15000
        '        '    .Credentials = New NetworkCredential(strSMTPMailUser, strSMTPMailPass)
        '        '    .EnableSsl = bolGmail
        '        'End With
        '        'With mailMessage
        '        '    .BodyEncoding = System.Text.UTF8Encoding.UTF8
        '        '    .IsBodyHtml = True
        '        '    .From = New MailAddress(strSMTPMailUser)
        '        '    .Subject = strEmailSubject
        '        '    .Priority = Net.Mail.MailPriority.Normal
        '        '    .Body = strContent
        '        '    .[To].Add(strEmail)
        '        'End With
        '        'mailClient.Send(mailMessage)

        '        Try
        '            Dim Smtp_Server As New SmtpClient
        '            Dim e_mail As New MailMessage()
        '            Smtp_Server.UseDefaultCredentials = False
        '            Smtp_Server.Credentials = New Net.NetworkCredential(strSMTPMailUser, strSMTPMailPass)
        '            Smtp_Server.Port = strSMTPPort
        '            Smtp_Server.EnableSsl = True
        '            Smtp_Server.Host = strSMTPServer

        '            e_mail = New MailMessage()
        '            e_mail.From = New MailAddress(strSMTPMailUser)
        '            e_mail.To.Add(strEmail)
        '            e_mail.Subject = strEmailSubject
        '            e_mail.IsBodyHtml = True
        '            e_mail.Body = strContent
        '            Smtp_Server.Send(e_mail)


        '        Catch error_t As Exception
        '            intResult = 0
        '        End Try

        '    Catch ex As Exception
        '        intResult = 0
        '    End Try
        '    Return intResult
        'End Function


        Public Function Send2Mail(ByVal strEmailSubject As String, ByVal strContent As String, ByVal strEmail As String) As Integer
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
                    .Subject = strEmailSubject
                    .Priority = Net.Mail.MailPriority.Normal
                    .Body = strContent
                    .[To].Add(strEmail)
                End With
                mailClient.EnableSsl = True
                mailClient.Send(mailMessage)
            Catch ex As Exception
                intResult = 0
            End Try
            Return intResult
        End Function

        Public Function SendMail(ByVal strSubject As String, ByVal strContent As String, ByVal strEmailTo As String, Optional ByVal blnIsHtml As Boolean = True, Optional ByVal strEmailFrom As String = "", Optional ByVal strFileAttach As String = "") As Integer
            Dim objMail As New EmailMessage
            Dim arrFileAttach() As String
            Dim intIndex As Integer

            Try
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

                objMail.Username = objSysPara(13)
                'Dim TempPass As String
                'TempPass = objSysPara(14)
                'If Not TempPass = "" Then
                '    TempPass = objBCSP.DecryptPassword(TempPass)
                'End If
                'objMail.Password = TempPass
                objMail.Password = objSysPara(14)

                objMail.Subject = strSubject
                'objMail.AddHeader("Content-Transfer-Encoding", "8bit")
                If blnIsHtml Then
                    strContent = strContent.Replace("&lt;", "<").Replace("&gt;", ">")
                    objMail.BodyFormat = MailFormat.Html
                Else
                    objMail.BodyFormat = MailFormat.Text
                End If

                objMail.Body = strContent
                objMail.InternalEncoding = System.Text.Encoding.UTF8
                'objMail.CharSet = "ISO-8859-1"
                objMail.CharSet = "UTF-8"
                objMail.Priority = aspNetEmail.MailPriority.Normal
                If Not strFileAttach = "" Then
                    Try
                        arrFileAttach = strFileAttach.Split(",")
                        For intIndex = 0 To UBound(arrFileAttach)
                            objMail.Attachments.Add(arrFileAttach(intIndex))
                        Next
                    Catch ex As Exception
                    End Try
                End If
                objMail.Server = objSysPara(5)
                'objMail.Send()
                Send2Mail(strSubject, strContent, strEmailTo)
                objMail.ClearAttachments()
                objMail.ClearCcs()
                objMail.ClearBccs()
                objMail.ClearBody()
                SendMail = 1
            Catch ex As Exception
                SendMail = 0
                strErrorMsg = ex.Message
            End Try
        End Function
        'E1

        ' WriteErrorMssg Encode in ILL Request
        ' create by Lenta 28-3-2006
        Public Sub EncodeILLError(ByVal blnEncode As Boolean)
            If Not blnEncode Then
                Page.RegisterClientScriptBlock("ErrorILLEndcodeAlert", "<script language='javascript'>alert('Could not encode to base64 but continue with xml request!');</script>")
            End If
        End Sub
        Public Sub RegisterCalendar(Optional ByVal strOutPath As String = "..")
            'strOutCalendarPath = strOutPath
            If strColLanguage = "" Or strColLanguage Is Nothing Then
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = 'vie';var imgDir='" & strOutPath & "/Common/Calendar/'</script>")
            Else
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = '" & strColLanguage & "';var imgDir='" & strOutPath & "/Common/Calendar/'</script>")
            End If
            Page.RegisterClientScriptBlock("ShowCalendar", "<script language='javascript' src='" & strOutPath & "/Common/Calendar/PopCalendar1.js'></script>")
        End Sub
        Public Sub SetOnclickCalendar(ByRef lnkCalendarTmp As HyperLink, ByRef txtDateTmp As TextBox, ByVal strMsg As String)
            lnkCalendarTmp.NavigateUrl = "#"
            lnkCalendarTmp.Attributes.Add("onClick", "popUpCalendar(this, document.forms[0]." & txtDateTmp.ID & ", '" & Session("DateFormat") & "',26)")
            txtDateTmp.Attributes.Add("OnChange", "if (!CheckDate(this, '" & Session("DateFormat") & "', '" & strMsg & " (" & Session("DateFormat") & ")')) {this.value='';this.focus();return false;}")
            txtDateTmp.Attributes.Add("onkeypress", "if (window.event.keyCode == 13) {if (!CheckDate(this, '" & Session("DateFormat") & "', '" & strMsg & " (" & Session("DateFormat") & ")')) {this.value='';this.focus();return false;}}")
            txtDateTmp.ToolTip = Session("DateFormat")
        End Sub

        Public Sub ShowWaitingOnPage(ByVal strMsg As String, ByVal strPathOut As String, Optional ByVal blnHidden As Boolean = False, Optional ByVal blnWidePage As Boolean = False)
            If Not blnHidden Then
                If blnWidePage Then
                    Response.Write("<span id='spnlbProcessing' style='LEFT: 350px; POSITION: absolute; TOP: 60px;TEXT-ALIGN: center;'>" & strMsg & " <br><img src='" & strPathOut & "/Images/progressBar.gif'></span>")
                Else
                    Response.Write("<span id='spnlbProcessing' style='LEFT: 250px; POSITION: absolute; TOP: 60px;TEXT-ALIGN: center;'>" & strMsg & " <br><img src='" & strPathOut & "/Images/progressBar.gif'></span>")
                End If

                Response.Flush()
            Else
                Response.Write("<script language='javascript'>document.getElementById('spnlbProcessing').style.visibility = 'hidden';</script>")
            End If
        End Sub
        ' Add by lent 02/04/2007
        Public Sub SetCheckNumber(ByRef txtNumberTmp As TextBox, ByVal strErrMsg As String, Optional ByVal strValDefault As String = "0")
            txtNumberTmp.Attributes.Add("OnChange", "if(!CheckNumBer(this,'" & strErrMsg & "','" & strValDefault & "')){this.focus();return false;}")
        End Sub

        Public Sub SetCheckNumberCurrency(ByRef txtNumberTmp As TextBox, ByVal strErrMsg As String, Optional ByVal strValDefault As String = "0")
            txtNumberTmp.Attributes.Add("OnChange", "if(!CheckNumBerCurrency(this,'" & strErrMsg & "','" & strValDefault & "')){this.focus();return false;}")
        End Sub

        Public Sub SetOnclickZ3950(ByRef btnZ3950Tmp As Button, ByVal strPathOut As String)
            btnZ3950Tmp.Attributes.Add("OnClick", "OpenWindow('" & strPathOut & "/Common/WZForm.aspx','ZWin',800,450,50,100); return false;")
        End Sub

        Public Sub AlertMsg(ByVal strMsg As String, Optional ByVal strMsgID As String = "")
            Page.RegisterClientScriptBlock("AlertJS" & strMsgID, "<script language='javascript'> alert('" & strMsg & "');  </script>")
        End Sub

        Public Function GetOneParaSystem(ByVal strParaName As String) As String
            Dim arrParaName(0) As String
            arrParaName(0) = strParaName
            GetOneParaSystem = objBCDBS.GetSystemParameters(arrParaName)(0)
        End Function


        ' Release resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
        Public Function ConvertDateBack(ByVal strDateTime As String, Optional ByVal blnShowTime As Boolean = True) As String
            Dim strDate As String
            Dim strTime As String
            Dim strDeli As String
            Dim strRet As String
            Dim strPara(1) As String
            Dim strARet(1) As String
            Dim strTypeCurent As String
            strPara(0) = "DATE_FORMAT"
            If strARet(0) <> "" Then
                strTypeCurent = strARet(0)
            Else
                strTypeCurent = "DD/MM/YYYY"
            End If
            'strTypeCurent = "DD/MM/YYYY"
            strDateTime = Trim(strDateTime)
            If strDateTime <> "" Then
                If InStr(strDateTime, " ") > 0 Then
                    strDate = Left(strDateTime, InStr(strDateTime, " ") - 1)
                    strTime = Trim(Right(strDateTime, Len(strDateTime) - InStr(strDateTime, " ")))
                Else
                    strDate = strDateTime
                End If
                If InStr(strDate, "/") <> 0 Then
                    strDeli = "/"
                End If
                If InStr(strDate, "-") <> 0 Then
                    strDeli = "-"
                End If
            End If
            If strDeli <> "" And strDate <> "" Then
                Dim bytPos1 As Byte
                Dim bytPos2 As Byte
                bytPos1 = InStr(strDate, strDeli)
                bytPos2 = InStrRev(strDate, strDeli)
                ' convert to format mm/dd/yyyy
                Select Case UCase(strTypeCurent)
                    Case "DD/MM/YYYY"
                        strRet = Mid(strDate, bytPos1 + 1, bytPos2 - bytPos1 - 1) & "/" & Left(strDate, bytPos1 - 1) & "/" & Right(strDate, Len(strDate) - bytPos2)
                    Case "MM/DD/YYYY"
                        strRet = strDate
                    Case "YYYY/DD/MM"
                        strRet = Right(strDate, Len(strDate) - bytPos2) & "/" & Mid(strDate, bytPos1 + 1, bytPos2 - bytPos1 - 1) & "/" & Left(strDate, bytPos1 - 1)
                    Case "YYYY/MM/DD"
                        strRet = Mid(strDate, bytPos1 + 1, bytPos2 - bytPos1 - 1) & "/" & Right(strDate, Len(strDate) - bytPos2) & "/" & Left(strDate, bytPos1 - 1)
                End Select
                If blnShowTime Then
                    If strTime <> "" Then
                        strRet = strRet & " " & strTime
                    Else
                        strRet = strRet & " 00:00:00"
                    End If
                End If
            Else
                strRet = strDateTime
            End If
            ConvertDateBack = strRet
        End Function


    End Class
End Namespace