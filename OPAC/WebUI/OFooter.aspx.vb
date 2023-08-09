Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Globalization

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OFooter
        Inherits System.Web.UI.Page
        Private fs As StreamWriter
        Private strScriptName, strPathName As String
        Private strWordDes As String = "|+++|"
        Private strWordSource As String = " & "
        Private xmlDoc As XmlDocument
        Private strSlip As String = "|+|"
        Private intlenSlip As String = getLenString(strSlip)
        Private strSlipTable As String = "|++|"
        Private intlenSlipTable As String = getLenString(strSlipTable)
        Private blnReadyFile As Boolean = False
        Private strColLanguage As String = ""

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Call ExportResource()
            End If
            Call SetResourceForControls()
        End Sub

        Private Function getLenString(ByVal val As String) As String
            Return Len(val)
        End Function

        Private Sub ExportResource()
            Try
                If Request.QueryString.Get("Script_Name") <> "" Then
                    strScriptName = Request.QueryString.Get("Script_Name")
                Else
                    strScriptName = Request.ServerVariables("Script_Name")
                End If
                strPathName = Right(strScriptName, Len(strScriptName) - InStr(2, strScriptName, "/"))
                Session("strPathName") = Right(strScriptName.Replace("/", "\"), Len(strScriptName) - 1)
                strPathName = "\Resources\LabelString\" & Replace(Replace(strPathName, ".aspx", ".xml"), "/", "\")
                strPathName = Server.MapPath(Request.ApplicationPath) & strPathName


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
                    'If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
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
                                            WriteFile(strColLanguageName, strCtlName, CType(ctl, LiteralControl).Text)
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
                                        WriteFile(strColLanguageName, strCtlName, CType(ctl, LiteralControl).Text)
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
                    'End If
                Next
                fs.WriteLine("</Head>")
                fs.Close()
            Catch ex As Exception

            End Try

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

        ' Replace word typical
        Private Function ReplaceWordTypical(ByVal strCtlValue As String, ByVal strSourceWord As String, ByVal strDesWord As String) As String
            Return Replace(strCtlValue, strSourceWord, strDesWord)
        End Function

        Private Sub ReadXmlFile()
            Me.blnReadyFile = False
            Try
                '                Select clsSession.GlbLanguage
                '                    Case "tcvn", "vni", "unicode"
                '                        strColLanguage = "vie"
                '                    Case Else
                '                        strColLanguage = clsSession.GlbLanguage
                '                End Select
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
                'If TypeOf (ctlItem) Is System.Web.UI.HtmlControls.HtmlForm Then
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
                'End If
            Next
        End Sub

        Private Function GetControlValue(ByVal strControlName As String) As String
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

        Private Sub setResourceHtmlContainerControl(ByVal ctlHtmlContainerControl As HtmlContainerControl)
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

        ' Cut vietnamese accent method
        ' INPUT: vietnamese accent string
        ' OUTPUT: string with no accent
        Private Shared Function CutVietnameseAccent(ByVal strInputs As String) As String
            Dim strNoAccentChar As String
            Dim strOutput As String = ""
            Dim strInput As String
            Dim inti As Integer
            If strInputs & "" = "" Then
                CutVietnameseAccent = ""
                Exit Function
            End If
            For inti = 0 To strInputs.Length - 1
                strInput = strInputs.Chars(inti)
                If InStr("A,À,Á,Ả,Ã,Ạ,Â,Ầ,Ấ,Ẩ,Ẫ,Ậ,Ă,Ằ,Ắ,Ẳ,Ẵ,Ặ", strInput) > 0 Then
                    strNoAccentChar = "A"
                ElseIf InStr("a,à,á,ả,ã,ạ,â,ầ,ấ,ẩ,ẫ,ậ,ă,ằ,ắ,ẳ,ẵ,ặ", strInput) > 0 Then
                    strNoAccentChar = "a"
                ElseIf InStr("E,È,É,Ẻ,Ẽ,Ẹ,Ê,Ề,Ế,Ể,Ễ,Ệ", strInput) > 0 Then
                    strNoAccentChar = "E"
                ElseIf InStr("e,è,é,ẻ,ẽ,ẹ,ê,ề,ế,ể,ễ,ệ", strInput) > 0 Then
                    strNoAccentChar = "e"
                ElseIf InStr("U,Ù,Ú,Ủ,Ũ,Ụ,Ư,Ừ,Ứ,Ử,Ữ,Ự", strInput) > 0 Then
                    strNoAccentChar = "U"
                ElseIf InStr("u,ù,ú,ủ,ũ,ụ,ư,ừ,ứ,ử,ữ,ự", strInput) > 0 Then
                    strNoAccentChar = "u"
                ElseIf InStr("I,Ì,Í,Ỉ,Ĩ,Ị", strInput) > 0 Then
                    strNoAccentChar = "I"
                ElseIf InStr("i,ì,í,ỉ,ĩ,ị", strInput) > 0 Then
                    strNoAccentChar = "i"
                ElseIf InStr("O,Ò,Ó,Ỏ,Õ,Ọ,Ô,Ồ,Ố,Ổ,Ỗ,Ộ,Ơ,Ờ,Ớ,Ở,Ỡ,Ợ", strInput) > 0 Then
                    strNoAccentChar = "O"
                ElseIf InStr("o,ò,ó,ỏ,õ,ọ,ô,ồ,ố,ổ,ỗ,ộ,ơ,ờ,ớ,ở,ỡ,ợ", strInput) > 0 Then
                    strNoAccentChar = "o"
                ElseIf InStr("Y,Ỳ,Ý,Ỷ,Ỹ,Ỵ", strInput) > 0 Then
                    strNoAccentChar = "Y"
                ElseIf InStr("y,ỳ,ý,ỷ,ỹ,ỵ", strInput) > 0 Then
                    strNoAccentChar = "y"
                ElseIf InStr("đ", strInput) > 0 Then
                    strNoAccentChar = "d"
                ElseIf InStr("Đ", strInput) > 0 Then
                    strNoAccentChar = "D"
                Else
                    strNoAccentChar = strInput
                End If
                strOutput = strOutput & strNoAccentChar
            Next
            Return strOutput
        End Function
    End Class
End Namespace
