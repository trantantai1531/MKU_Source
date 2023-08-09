Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Threading
Imports System.Globalization
Imports System.Web.Mail

Namespace eMicLibOPAC.WebUI
    Public Class clsWHelpBase
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
        Private strSlip As String = "|+|"
        Private intlenSlip As String = Len(strSlip)
        Private strSlipTable As String = "|++|"
        Private intlenSlipTable As String = Len(strSlipTable)
        Private strWordDes As String = "|+++|"
        Private strWordSource As String = " & "

        Dim objBCDBS As New eMicLibOPAC.BusinessRules.Common.clsBCommonDBSystem
        Dim objBCSP As New eMicLibOPAC.BusinessRules.Common.clsBCommonStringProc

        ' **********************************************************************
        ' Page_Load method
        ' Purpose: Load necessary objects
        ' **********************************************************************
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call PageInit()
            Call GetCultureInfoCookie()
            ' Get PathName of resource file
            If Request.QueryString.Get("Script_Name") <> "" Then
                strScriptName = Request.QueryString.Get("Script_Name")
            Else
                strScriptName = Request.ServerVariables("Script_Name")
            End If
            strPathName = Right(strScriptName, Len(strScriptName) - InStr(2, strScriptName, "/"))
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
            objBCSP.InterfaceLanguage = clsSession.GlbInterfaceLanguage

            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            Call objBCDBS.Initialize()

            If Trim(clsSession.GlbInterfaceLanguage & "") = "" Then
                clsSession.GlbInterfaceLanguage = objBCSP.InterfaceLanguage
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
            If clsSession.GlbLanguage & "" = "" Then
                clsSession.GlbLanguage = clsSession.GlbInterfaceLanguage
            End If
            If Session("FontType") & "" = "" Then
                Session("FontType") = "utf8"
            End If
            If Session("Typing") & "" = "" Then
                Session("Typing") = 0
            End If
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", Me.GetStyleSheetURL(Session("Module"))))
            Page.RegisterClientScriptBlock("vietuni", "<Script Language='JavaScript'  type='text/javascript' src='/Opac/Common/vietuni.js'></Script>")
            Page.RegisterClientScriptBlock("EmbVietuni", "<Script language='JavaScript'>Typing=" & Session("Typing") & ";FontType='" & Session("FontType") & "';</Script>")
        End Sub

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
                        Case "tcvn", "vni", "unicode"
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
            If clsSession.GlbLanguage & "" <> "unicode" And clsSession.GlbLanguage & "" <> "vni" And clsSession.GlbLanguage & "" <> "tcvn" Then
                name = name & ".unicode.css"
            Else
                name = name & "." & clsSession.GlbLanguage & ".css"
            End If
            Return String.Format("Resources/StyleSheet/" & name)
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
            Dim objBCSP As New eMicLibOPAC.BusinessRules.Common.clsBCommonStringProc
            If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                objBCSP.ConnectionString = Session("ConnectionString")
                objBCSP.DBServer = Session("DBServer")
                objBCSP.InterfaceLanguage = clsSession.GlbInterfaceLanguage
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
                                    ' Dim intSelectedIndex As Integer = CType(ctl, ListBox).SelectedIndex
                                    'Dim licCollection As New ListItemCollection
                                    'licCollection.Clear()
                                    'For i = 0 To CType(ctl, ListBox).Items.Count - 1
                                    '    If CType(ctl, ListBox).Items(i).Selected = True Then
                                    '        licCollection.Add(CType(ctl, ListBox).Items(i))
                                    '    End If
                                    'Next
                                    'If strCtlValue = "" Then
                                    '    For Each lstCtlValue In CType(ctl, ListBox).Items
                                    '        strCtlValue = strCtlValue & lstCtlValue.Value & strSlip & lstCtlValue.Text & strSlip
                                    '    Next
                                    '    If Len(strCtlValue) > 0 Then
                                    '        strCtlValue = Left(strCtlValue, Len(strCtlValue) - intlenSlip)
                                    '    End If
                                    'End If
                                    '' Convert to CurrenEncode
                                    'If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                                    '    strCtlValue = objBCSP.UCS2ToCurrent(strCtlValue)
                                    'End If
                                    ' Set CssClass
                                    If CType(ctl, ListBox).CssClass = "" Then
                                        CType(ctl, ListBox).CssClass = "lbListBox"
                                    End If
                                    'If strCtlValue <> "" Then
                                    '    strCtlValue = ReplaceWordTypical(strCtlValue, strWordDes, strWordSource)
                                    '    ArrCtlValue = Split(strCtlValue, strSlip)
                                    '    CType(ctl, ListBox).Items.Clear()
                                    '    For i = 0 To UBound(ArrCtlValue) Step 2
                                    '        lstCtlValue = New ListItem(ArrCtlValue(i + 1), ArrCtlValue(i))
                                    '        CType(ctl, ListBox).Items.Add(lstCtlValue)
                                    '    Next
                                    'End If
                                    'For i = 0 To licCollection.Count - 1
                                    '    For j = 0 To CType(ctl, ListBox).Items.Count - 1
                                    '        If licCollection.Item(i).Value = CType(ctl, ListBox).Items(j).Value And licCollection.Item(i).Text = CType(ctl, ListBox).Items(j).Text Then
                                    '            CType(ctl, ListBox).Items(j).Selected = True
                                    '        End If
                                    '    Next
                                    'Next
                                    ' CType(ctl, ListBox).SelectedIndex = intSelectedIndex
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
                                        For i = 0 To UBound(ArrCtlValue)
                                            CType(ctl, DataGrid).Columns(i).HeaderText = ArrCtlValue(i)
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
            '    Case "unicode", "tcvn", "vni"
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
        ' Replace word typical
        Public Function ReplaceWordTypical(ByVal strCtlValue As String, ByVal strSourceWord As String, ByVal strDesWord As String) As String
            Return Replace(strCtlValue, strSourceWord, strDesWord)
        End Function

        ' **********************************************************************
        ' WriteFile
        ' **********************************************************************
        Private Sub WriteFile(ByVal strColLanguageName As String, ByVal strKey As String, ByVal strValue As String)
            fs.WriteLine("<data>")
            fs.WriteLine("<name>" & Replace(Replace(Replace(strKey, "<", "&lt;"), ">", "&gt;"), "&nbsp;", "") & "</name>")
            fs.WriteLine("<" & strColLanguageName & ">" & Replace(Replace(Replace(strValue, "<", "&lt;"), ">", "&gt;"), "&nbsp;", " ") & "</" & strColLanguageName & ">")
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

        ' WriteErrorMssg
        ' Purpose: write error message when user has not permission 
        Public Overloads Sub WriteErrorMssg(ByVal strErrorMssg As String, ByVal intErrorCode As Integer)
            If intErrorCode > 0 Then
                Response.Write("<H3>Error Code: " & intErrorCode & "</H3><BR>")
            End If
            If Not strErrorMssg = "" Then
                Response.Write("<H3>Error Message: " & strErrorMssg & "</H3>")
                Response.End()
            End If
        End Sub
        '--AlertMsg 
        '--Copy & Add by dgsoft2016
        Public Sub AlertMsg(ByVal strMsg As String, Optional ByVal strMsgID As String = "")
            Page.RegisterClientScriptBlock("AlertJS" & strMsgID, "<script language='javascript'> alert('" & strMsg & "');  </script>")
        End Sub
    End Class
End Namespace
