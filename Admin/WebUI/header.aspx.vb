Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI
    Partial Class header
        Inherits Web.UI.Page

#Region " Web Form Designer Generated Code "
        Protected WithEvents imgline1 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline2 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline3 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline4 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline5 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline6 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline7 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline8 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline9 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline10 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline11 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents Image1 As System.Web.UI.WebControls.Image
        Protected WithEvents hidLogOn As System.Web.UI.HtmlControls.HtmlInputHidden
        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
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
        Private strColLanguage As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Load stylesheet
            Dim strName As String = "Admin"
            Dim strStyleSheetURL As String

            If Session("InterfaceLanguage") & "" <> "unicode" And Session("InterfaceLanguage") & "" <> "vni" And Session("InterfaceLanguage") & "" <> "tcvn" Then
                strName = strName & ".unicode.css"
            Else
                strName = strName & "." & Session("InterfaceLanguage") & ".css"
            End If

            strStyleSheetURL = String.Format(Request.ApplicationPath & "/Resources/StyleSheet/" & strName)
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", strStyleSheetURL))
            'Call ExportResource()

            If Not Page.IsPostBack Then
                hidLanguage.Value = Session("InterfaceLanguage")
            End If
            Session("InterfaceLanguage") = hidLanguage.Value
            clsSession.GlbLanguage = Session("InterfaceLanguage")

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

            Call SetResourceForControls()


            ' References Scripts file
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/header.js'></script>")

            Dim strJS As String
            If clsSession.GlbUser & "" = "" Then
                strJS = strJS & "top.location.href='Windex  ';"
                Page.RegisterClientScriptBlock("LogOutJs", "<script language = 'javascript'>" & strJS & "</script>")
            End If
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
                dsResource.ReadXml(Server.MapPath("Resources/LabelString/header.xml"))
                If dsResource.Tables.Count > 0 Then
                    Select Case clsSession.GlbLanguage
                        Case "tcvn", "vni", "unicode"
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
            Dim objBCSP As New clsBCommonStringProc
            If clsSession.GlbLanguage = "tcvn" Or clsSession.GlbLanguage = "vni" Then
                ' Init objBCSP object
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

            Select Case Session("InterfaceLanguage")
                Case "unicode", "tcvn", "vni"
                    strColLanguageName = "vie"
                Case Else
                    strColLanguageName = Session("InterfaceLanguage")
            End Select
            fs = File.CreateText(Server.MapPath("Resources\LabelString") & "\header.xml")
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
    End Class
End Namespace