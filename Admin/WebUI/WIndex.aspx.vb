Imports System.Web.UI
Imports System.DirectoryServices
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Admin
Imports System.IO
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI
    Partial Class WIndex
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub


#End Region

        ' Declare memeber variables
        Private objBUser As New clsBUser
        Private objBCDBS As New clsBCommonDBSystem
        Private objBRole As New clsBRole
        Private objPara() As String = {"LDAP_AUTHENTICATION_ENABLE", "LDAP_LOCATION", "LDAP_SERVER_TYPE", "LDAP_LOGON_USER", "LDAP_LOGON_PASSWORD", "CATALOG_WORKSTATIONS", "PATRON_WORKSTATIONS", "SERIAL_WORKSTATIONS", "ACQUISITION_WORKSTATIONS", "CIRCULATION_WORKSTATIONS", "ADMIN_WORKSTATIONS", "ILL_WORKSTATIONS", "EDELIV_WORKSTATIONS"}
        Private strAddressPath As String
        Protected objSysPara() As String
        Private strWorkStationIP As String
        Dim objBCSP As New clsBCommonStringProc
        Dim fs As StreamWriter
        Private strSlip As String = "|+|"
        Private intlenSlip As String = Len(strSlip)
        Private strSlipTable As String = "|++|"
        Private intlenSlipTable As String = Len(strSlipTable)
        Private strWordDes As String = "|+++|"
        Private strWordSource As String = " & "
        Private dsResource As New DataSet
        Private dtvResource As New DataView
        Private blnReadyFile As Boolean = False
        Protected WithEvents lblIntroduce1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblIntroduce2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblIntroduce3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblIntroduce4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblIntroduce5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblIntroduce6 As System.Web.UI.WebControls.Label
        Private strColLanguage As String

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If LCase(Request.QueryString("out")) = "ok" Then
                Session.Clear()
                If Application("UserCount") > 0 Then
                    Application("UserCount") = Application("UserCount") - 1
                End If
            End If

            strWorkStationIP = Request.ServerVariables("REMOTE_ADDR")
            Call ExportResource()
            If Not Page.IsPostBack Then
                hidLanguage.Value = clsSession.GlbInterfaceLanguage
            End If
            clsSession.GlbInterfaceLanguage = hidLanguage.Value
            If clsSession.GlbInterfaceLanguage = "" Or clsSession.GlbInterfaceLanguage = "unicode" Then
                clsSession.GlbInterfaceLanguage = "vie"
                hidLanguage.Value = "vie"
            End If
            clsSession.GlbLanguage = clsSession.GlbInterfaceLanguage

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

            Call SetResourceForControls()
            Call BindStyleJS()
            Call BindData()
            If clsSession.GlbUser & "" <> "" Then
                Call AccessModule()
            End If

            'create by lent : 21-05-2007
            ' check sigle sign on 
            If Not LCase(Request.QueryString("out")) = "ok" Then
                Dim strUserName As String
                If Request.Headers("Osso-User-Dn") <> "" Then
                    If Initialize() Then
                        'if in case OSSO Oracle 
                        strAddressPath = Request.Headers("Osso-User-Dn")
                        strUserName = GetValidLdapUser(strAddressPath)
                        If Me.CheckUserLogin(strUserName, "", True) = 1 Then
                            Call AccessModule()
                        End If
                    End If
                End If
            End If
        End Sub
        Public Function GetValidLdapUser(ByRef AdsPath As String) As String
            Dim Search As New DirectorySearcher("(objectClass=person)")
            Search.SearchRoot = New DirectoryEntry(objSysPara(1), objSysPara(3), objSysPara(4), AuthenticationTypes.Anonymous)
            Search.SearchScope = SearchScope.Subtree
            Search.PropertiesToLoad.Add("adspath")
            Search.PropertiesToLoad.Add("sn")
            Dim result As SearchResult

            AdsPath = AdsPath.Replace(" ", "")
            For Each result In Search.FindAll
                If result.Path.IndexOf(AdsPath) > -1 Then
                    AdsPath = result.Properties("adspath")(0)
                    Return result.Properties("sn")(0)
                    Exit Function
                End If
            Next
            Return ""
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

            Dim objFileInfo As New FileInfo(Server.MapPath("Resources\LabelString") & "\Index.xml")
            If objFileInfo.Exists Then
                objFileInfo = Nothing
                Exit Sub
            End If
            objFileInfo = Nothing
            Select Case clsSession.GlbInterfaceLanguage
                Case "vie", "tcvn", "vni"
                    strColLanguageName = "vie"
                Case Else
                    strColLanguageName = clsSession.GlbInterfaceLanguage
            End Select
            fs = File.CreateText(Server.MapPath("Resources\LabelString") & "\Index.xml")
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
                                        strCtlValue = Replace(strCtlValue, strWordSource, strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - 1))
                                    End If
                                Case "System.Web.UI.WebControls.DropDownList"
                                    strCtlValue = ""
                                    For Each lstCtlValue In CType(ctl, DropDownList).Items
                                        strCtlValue = strCtlValue & lstCtlValue.Value & strSlip & lstCtlValue.Text & strSlip
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = Replace(strCtlValue, strWordSource, strWordDes)
                                        WriteFile(strColLanguageName, strCtlName, Left(strCtlValue, Len(strCtlValue) - intlenSlip))
                                    End If
                                Case "System.Web.UI.WebControls.DataGrid"
                                    strCtlValue = ""
                                    For i = 0 To CType(ctl, DataGrid).Columns.Count - 1
                                        strCtlValue = strCtlValue + CType(ctl, DataGrid).Columns(i).HeaderText + strSlip
                                    Next
                                    If strCtlValue <> "" Then
                                        strCtlValue = Replace(strCtlValue, strWordSource, strWordDes)
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
                                        strCtlValue = Replace(strCtlValue, strWordSource, strWordDes)
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

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Function Initialize() As Boolean
            Call ResetSession(ddlDataBase.SelectedValue)
            If Not objBCDBS.CheckOpenConnection(Session("DBServer") & "", Session("ConnectionString") & "") Then
                Initialize = False
                Exit Function
            End If
            ' Init objBUser object
            objBUser.ConnectionString = Session("ConnectionString")
            objBUser.DBServer = Session("DBServer")
            objBUser.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            Call objBUser.Initialize()

            ' Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            Call objBCDBS.Initialize()

            ' Init objBRole object
            objBRole.ConnectionString = Session("ConnectionString")
            objBRole.DBServer = Session("DBServer")
            objBRole.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            Call objBRole.Initialize()

            ' Init objBCSP object
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBCSP.Initialize()
            Call GetSysPara()
            Initialize = True
        End Function
        ' Method: ResetSession
        'Modify by lent
        Private Sub ResetSession(Optional ByVal intDBID As Integer = 0)
            Dim objeMicLibLogin As New eMicLibLogin.clseMicLibLogin
            Session("ConnectionString") = objeMicLibLogin.GetConnectionString(intDBID)
            Session("DBServer") = objeMicLibLogin.DBServer
            Session("DatabaseID") = intDBID
            objeMicLibLogin = Nothing
        End Sub

        ' GetSysPara method
        Public Sub GetSysPara()
            objSysPara = objBCDBS.GetSystemParameters(objPara)
        End Sub

        ' Method: BindData
        Private Sub BindData()
            If Not Page.IsPostBack Then
                Dim objeMicLibLogin As New eMicLibLogin.clseMicLibLogin
                Dim tblTest As DataTable = objeMicLibLogin.GetDBConnection
                If Not tblTest Is Nothing AndAlso tblTest.Rows.Count > 0 Then
                    ddlDataBase.DataSource = tblTest
                    ddlDataBase.DataTextField = "ConnectionName"
                    ddlDataBase.DataValueField = "ID"
                    ddlDataBase.DataBind()
                    Dim inti As Integer
                    For inti = 0 To tblTest.Rows.Count - 1
                        If tblTest.Rows(inti).Item("Run") = "1" Then
                            ddlDataBase.SelectedIndex = inti
                            Session("DefaultDatabaseID") = tblTest.Rows(inti).Item("ID")
                            Exit For
                        End If
                    Next
                    tblTest = Nothing
                End If
                objeMicLibLogin = Nothing
            End If
            Call BindLangFromXml()
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
        ' Read XmlFile
        ' **********************************************************************
        Private Sub ReadXmlFile()
            ' Use function ConvertTable
            Try
                dsResource.ReadXml(Server.MapPath("Resources/LabelString/Index.xml"))
                If dsResource.Tables.Count > 0 Then
                    Select Case clsSession.GlbLanguage
                        Case "tcvn", "vni", "vie"
                            strColLanguage = "vie"
                        Case Else
                            strColLanguage = clsSession.GlbLanguage
                    End Select
                    dtvResource = dsResource.Tables(0).DefaultView
                    dsResource.Tables.Clear()
                End If
            Catch ex As Exception
            Finally
            End Try
        End Sub
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
        ' Replace word typical
        Public Function ReplaceWordTypical(ByVal strCtlValue As String, ByVal strSourceWord As String, ByVal strDesWord As String) As String
            Return Replace(strCtlValue, strSourceWord, strDesWord)
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
            If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                ' Init objBCSP object
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
                            strCtlValue = GetControlValue(strCtlName)
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
                                                    strCtlValue = Left(strCtlValue, Len(strCtlValue) - 1)
                                                End If
                                                strCtlValue = strCtlValue + strSlipTable
                                            Next
                                        End If
                                        If Len(strCtlValue) > 0 Then
                                            strCtlValue = Left(strCtlValue, Len(strCtlValue) - 2)
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

        Public Function CreateTable(ByVal ArrTextField As Object, ByVal ArrValueField As Object) As DataTable
            Dim TblRet As New DataTable
            If IsArray(ArrTextField) And IsArray(ArrValueField) Then
                If UBound(ArrTextField) = UBound(ArrValueField) Then
                    Dim byti As Byte
                    Dim row As DataRow
                    If System.Type.GetType("System.String").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.String"))
                    ElseIf System.Type.GetType("System.Int64").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Int64"))
                    ElseIf System.Type.GetType("System.Int32").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Int32"))
                    ElseIf System.Type.GetType("System.DateTime").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.DateTime"))
                    ElseIf System.Type.GetType("System.Decimal").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("TextField", System.Type.GetType("System.Decimal"))
                    End If

                    If System.Type.GetType("System.String").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.String"))
                    ElseIf System.Type.GetType("System.Int64").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Int64"))
                    ElseIf System.Type.GetType("System.Int32").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Int32"))
                    ElseIf System.Type.GetType("System.DateTime").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.DateTime"))
                    ElseIf System.Type.GetType("System.Decimal").Equals(ArrTextField(0).GetType) Then
                        TblRet.Columns.Add("ValueField", System.Type.GetType("System.Decimal"))
                    End If
                    For byti = 0 To UBound(ArrTextField)
                        row = TblRet.NewRow
                        row(0) = ArrTextField(byti)
                        row(1) = ArrValueField(byti)
                        TblRet.Rows.Add(row)
                    Next
                    CreateTable = TblRet
                Else
                    Exit Function
                End If
            Else
                Exit Function
            End If
        End Function

        ' Method: BindLangFromXml
        ' Purpose: Get all language from file .xml insert in downloadgrid
        Private Sub BindLangFromXml()
            Dim arrText As Object
            Dim arrValue As Object
            Dim tblTest As DataTable
            tblTest = GetXmlFile(Server.MapPath("Resources/LabelString/Index.xml"))
            ReDim arrValue(tblTest.Columns.Count)
            ReDim arrText(tblTest.Columns.Count)
            Dim inti As Integer
            Dim intj As Integer = 3
            arrValue(0) = "vie"
            arrText(0) = ddlLabel.Items(4).Text
            arrValue(1) = "eng"
            arrText(1) = ddlLabel.Items(5).Text
            'arrValue(2) = "vni"
            'arrText(2) = ddlLabel.Items(6).Text
            'For inti = 1 To tblTest.Columns.Count - 1
            '    If tblTest.Columns(inti).ColumnName.ToLower <> "vie" Then
            '        arrValue(intj) = tblTest.Columns(inti).ColumnName
            '        Select Case CStr(arrValue(intj)).ToLower
            '            Case "vie"
            '                'do nothing
            '            Case "eng"
            '                arrText(intj) = ddlLabel.Items(7).Text
            '            Case "fre"
            '                arrText(intj) = ddlLabel.Items(8).Text
            '            Case "chi"
            '                arrText(intj) = ddlLabel.Items(9).Text
            '            Case "ita"
            '                arrText(intj) = ddlLabel.Items(10).Text
            '            Case "spa"
            '                arrText(intj) = ddlLabel.Items(11).Text
            '            Case Else
            '                arrText(intj) = arrValue(0)
            '        End Select
            '        intj = intj + 1
            '    End If
            'Next
            tblTest = Nothing
            tblTest = CreateTable(arrText, arrValue)
            If Not tblTest Is Nothing AndAlso tblTest.Rows.Count > 0 Then
                ddlLanguage.DataSource = tblTest
                ddlLanguage.DataTextField = "TextField"
                ddlLanguage.DataValueField = "ValueField"
                ddlLanguage.DataBind()
                For inti = 0 To tblTest.Rows.Count - 1
                    If ddlLanguage.Items(inti).Value = hidLanguage.Value Then
                        ddlLanguage.SelectedIndex = inti
                        Exit For
                    End If
                Next
            End If
        End Sub

        ' Method: GetXmlFile
        Public Function GetXmlFile(ByVal strFileNameXml As String) As DataTable
            ' Use function ConvertTable
            Dim blnReadyFile As Boolean
            blnReadyFile = False
            Dim strName As String = ""
            Dim dsResource As New DataSet
            Try
                dsResource.ReadXml(strFileNameXml)
                If dsResource.Tables.Count > 0 Then
                    GetXmlFile = dsResource.Tables(0)
                    dsResource.Tables.Clear()
                End If
            Catch ex As Exception
            Finally
            End Try
        End Function

        ' Initialize method
        ' Purpose: Init all style sheet and javascript
        Private Sub BindStyleJS()
            Dim strName As String = "Admin"
            Dim strStyleSheetURL As String

            If clsSession.GlbInterfaceLanguage & "" <> "vie" And clsSession.GlbInterfaceLanguage & "" <> "vni" And clsSession.GlbInterfaceLanguage & "" <> "tcvn" Then
                strName = strName & ".unicode.css"
            Else
                strName = strName & "." & clsSession.GlbInterfaceLanguage & ".css"
            End If

            strStyleSheetURL = String.Format(Request.ApplicationPath & "/Resources/StyleSheet/" & strName)
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", strStyleSheetURL))
            btnLogin.Attributes.Add("Onclick", "if(document.forms[0].txtUserName.value=='') {alert('" & ddlLabel.Items(3).Text & "');document.forms[0].txtUserName.focus();return false;} return true;")
            ddlLanguage.Attributes.Add("OnChange", "document.forms[0].hidLanguage.value=document.forms[0].ddlLanguage.options[document.forms[0].ddlLanguage.options.selectedIndex].value;")
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = 'Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' CheckAccessModule method
        ' Purpose : check exist user can access module when already login
        Private Sub AccessModule()
            'B1 2014.10.24
            clsWCommon.gAutoDBServer = Session("DBServer")
            clsWCommon.gAutoConnectionString = Session("ConnectionString")
            clsWCommon.gInterfaceLanguage = Session("InterfaceLanguage")
            Session("ShowFieldName") = 1
            Session("ShowGroupName") = 1
            'E1
            Dim strJs As String
            strJs = "top.location.href='main.aspx';"
            'strJs = "top.location.href='OMap.aspx';"
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'>" & strJs & "</script>")
        End Sub

        ' CheckUserLogin method
        ' Purpose : check exist user can access follow module 
        ' In: strUserName, strPassword
        ' Out: 1: successful, else: fail
        Private Function CheckUserLogin(ByVal strUserName As String, ByVal strPassword As String, Optional ByVal blnSSO As Boolean = False) As Integer
            Dim tblResult As DataTable
            Dim intRetval As Integer = 0
            Dim blnCheckRightModule As Boolean = False
            Dim tblRights As DataTable
            Dim intIndex As Integer
            Dim strRights As String = ""
            Dim intMode As Int16 = 0
            Dim strLocation As String = ""
            Dim strServerType As String = ""
            Dim blnValidLDAP As Boolean = False
            Dim strCat As String
            Dim strPat As String
            Dim strSer As String
            Dim strAcq As String
            Dim strCir As String
            Dim strAdm As String
            Dim strILL As String
            Dim strDEL As String

            intMode = objSysPara(0)
            strServerType = objSysPara(2)
            strLocation = objSysPara(1)

            If Not blnSSO Then
                If intMode = 1 And strUserName <> "Admin" Then
                    If strUserName & "" <> "" Then
                        blnValidLDAP = IsAuthenticated(strLocation, strUserName, strPassword)
                        If blnValidLDAP = False Then
                            intRetval = 0
                        Else
                            objBUser.UserName = strUserName
                            tblResult = objBUser.GetLDAPUserLogin(strAddressPath)
                            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                                intRetval = 1
                            End If
                        End If
                    End If
                Else
                    If strUserName & "" <> "" Then
                        objBUser.UserName = strUserName
                        objBUser.UserPass = strPassword
                        tblResult = objBUser.GetUserLogin()
                        If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                            intRetval = 1
                        End If
                    End If
                End If
            Else
                objBUser.UserName = strUserName
                tblResult = objBUser.GetLDAPUserLogin(strAddressPath)
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    intRetval = 1
                Else
                    intRetval = 0
                End If
            End If

            If intRetval = 1 Then
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    ' check user can access to current module
                    Session("UserID") = tblResult.Rows(0).Item("ID")
                    If Not InStr("," & Session("UserID") & ",", ",," & Application("UserIDs") & ",") > 0 Then
                        Application.Lock()
                        Application("UserCount") = Application("UserCount") + 1
                        Application("UserIDs") = Application("UserIDs") & Session("UserID") & ","
                        Application.UnLock()
                    End If
                    objBRole.UID = tblResult.Rows(0).Item("ID")
                    tblRights = objBRole.GetRights

                    If Not tblRights Is Nothing Then
                        If tblRights.Rows.Count > 0 Then
                            For intIndex = 0 To tblRights.Rows.Count - 1
                                strRights = strRights & tblRights.Rows(intIndex).Item(0) & ","
                            Next
                        End If
                    End If

                    If Not Trim(strRights) = "" Then
                        Session("UserRights") = strRights
                    End If
                    clsSession.GlbUser = strUserName
                    Session("Password") = strPassword
                    clsSession.GlbUserFullName = tblResult.Rows(0).Item("Name")
                    Session("RightLevel") = tblResult.Rows(0).Item("Priority")
                    Session("UserRightModule") = tblResult

                    ' get the allowed workstations IP address
                    strCat = objSysPara(5)
                    strPat = objSysPara(6)
                    strSer = objSysPara(7)
                    strAcq = objSysPara(8)
                    strCir = objSysPara(9)
                    strAdm = objSysPara(10)
                    strILL = objSysPara(11)
                    strDEL = objSysPara(12)

                    If InStr(strCat, strWorkStationIP) > 0 Or UCase(strCat) = "ANY" Then
                        Session("CatModule") = CInt(tblResult.Rows(0).Item("CatModule"))
                    Else
                        Session("CatModule") = 0
                    End If

                    ' Patron Module right
                    If InStr(strPat, strWorkStationIP) > 0 Or UCase(strPat) = "ANY" Then
                        Session("PatModule") = CInt(tblResult.Rows(0).Item("PatModule"))
                    Else
                        Session("PatModule") = 0
                    End If

                    ' Serial Module right
                    If InStr(strSer, strWorkStationIP) > 0 Or UCase(strSer) = "ANY" Then
                        Session("SerModule") = CInt(tblResult.Rows(0).Item("SerModule"))
                    Else
                        Session("SerModule") = 0
                    End If

                    ' Acquisition Module right
                    If InStr(strAcq, strWorkStationIP) > 0 Or UCase(strAcq) = "ANY" Then
                        Session("AcqModule") = CInt(tblResult.Rows(0).Item("AcqModule"))
                    Else
                        Session("AcqModule") = 0
                    End If

                    ' Circulation Module right
                    If InStr(strCir, strWorkStationIP) > 0 Or UCase(strCir) = "ANY" Then
                        Session("CirModule") = CInt(tblResult.Rows(0).Item("CirModule"))
                    Else
                        Session("CirModule") = 0
                    End If

                    ' Admin module right
                    If InStr(strAdm, strWorkStationIP) > 0 Or UCase(strAdm) = "ANY" Then
                        Session("AdmModule") = CInt(tblResult.Rows(0).Item("AdmModule"))
                    Else
                        Session("AdmModule") = 0
                    End If

                    ' ILL module right
                    If InStr(strILL, strWorkStationIP) > 0 Or UCase(strILL) = "ANY" Then
                        Session("ILLModule") = CInt(tblResult.Rows(0).Item("ILLModule"))
                    Else
                        Session("ILLModule") = 0
                    End If

                    'Begin: Need reivew for Modify
                    If clsSession.GlbUser = "Admin" Then
                        Session("ILLModule") = -1
                    End If
                    'End: Need reivew for Modify

                    ' Edeliv module right
                    If InStr(strDEL, strWorkStationIP) > 0 Or UCase(strDEL) = "ANY" Then
                        Session("DELModule") = CInt(tblResult.Rows(0).Item("DELModule"))
                    Else
                        Session("DELModule") = 0
                    End If
                    intRetval = 1
                End If
            End If
            CheckUserLogin = intRetval
        End Function

        ' btnLogin_Click event
        Private Overloads Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLogin.Click
            Dim intExistuser As Integer = 0
            If Initialize() Then
                intExistuser = CheckUserLogin(txtUserName.Text, txtPassword.Text)
                Select Case intExistuser
                    Case 0
                        Page.RegisterClientScriptBlock("InvalidUser", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "')</script>")
                    Case 1
                        Call AccessModule()
                    Case Else
                        Page.RegisterClientScriptBlock("InvalidUser", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "')</script>")
                End Select
            Else
                Page.RegisterClientScriptBlock("InvalidDatabase", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "')</script>")
            End If
        End Sub


        ' IsAuthenticated function
        ' Purpose: Check the valid Ldap user
        Public Function IsAuthenticated(ByVal strLocation As String, ByVal strUserName As String, ByVal strPwd As String) As Boolean
            Dim strDomain As String = objSysPara(3)
            If InStr(strDomain, "@") > 0 Then
                strDomain = strDomain.Substring(InStr(strDomain, "@") - 1)
            Else
                strDomain = ""
            End If
            Dim entry As DirectoryEntry
            Dim strServerType As String
            strServerType = objSysPara(2)

            Select Case UCase(strServerType)
                Case "MS ACTIVE DIRECTORY"
                    entry = New DirectoryEntry(strLocation, strUserName & strDomain, strPwd)
                Case "LDAP"
                    entry = New DirectoryEntry(strLocation, strUserName & strDomain, strPwd, AuthenticationTypes.ServerBind)
                Case "OSSO ORACLE"
                    entry = New DirectoryEntry(strLocation, strUserName & strDomain, strPwd, AuthenticationTypes.Anonymous)
            End Select

            Try
                'Bind to the native AdsObject to force authentication.
                Dim objsearch As DirectorySearcher = New DirectorySearcher(entry)

                If Not objsearch Is Nothing Then
                    Select Case UCase(strServerType)
                        Case "MS ACTIVE DIRECTORY"
                            objsearch.Filter = "(SAMAccountName=" & strUserName & ")"
                        Case "LDAP"
                            objsearch.Filter = "(uid=" & strUserName & ")"
                        Case "OSSO ORACLE"
                            objsearch.Filter = "(orclsamaccountname=" & strUserName & ")"
                    End Select

                    objsearch.PropertiesToLoad.Add("cn")

                    Dim result As SearchResult = objsearch.FindOne()
                    strAddressPath = CType(result.Properties("adspath")(0), String)

                    If (result Is Nothing) Then
                        Return False
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try

            Return True
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBRole Is Nothing Then
                    objBRole.Dispose(True)
                    objBRole = Nothing
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

        Private Sub ddlLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            'clsSession.GlbInterfaceLanguage = ddlLanguage.SelectedValue
            'Page.RegisterClientScriptBlock("HeaderRefreshJs", "<script language='javascript'>parent.header.location.href='header.aspx';</script>")
        End Sub
    End Class
End Namespace
