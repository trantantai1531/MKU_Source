' Class: WCataSent
' Purpose: Show catalogue form
' Creator: Oanhtn
' CreatedDate: 27/03/2004
' Modification history:
'  - 23/03/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCata
        Inherits clsWBase

        ' Declare variables
        Private objBForm As New clsBForm
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBCSP As New clsBCommonStringProc
        Dim intUTF As Integer = 0

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadCataForm()
            Call BindJs()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBCatalogueForm object
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            objBCatalogueForm.IsAuthority = Session("IsAuthority")
            Call objBCatalogueForm.Initialize()

            ' Init objBForm obect
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            objBForm.IsAuthority = Session("IsAuthority")
            Call objBForm.Initialize()

            ' Init objBCSP
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            ' UTF variable
            If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                intUTF = 1
            End If
        End Sub

        ' BindJavascripts method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJs()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WCommonJs", "<script type='text/javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WCataJs", "<script type='text/javascript' src = '../Js/Catalogue/WCata.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)

            btnChangeWS.Attributes.Add("OnClick", "javascript:ChangeWorkSheet();")
            If CInt(Session("IsAuthority")) <> 1 Then
                optNew.Attributes.Add("OnClick", "javascript:parent.Sentform.document.forms[0].tag900.value = 1; document.forms[0].tag900.value = 1;")
                optRenew.Attributes.Add("OnClick", "javascript:parent.Sentform.document.forms[0].tag900.value = 0; document.forms[0].tag900.value = 0;")
            End If
        End Sub

        ' LoadMenu method
        ' Purpose: load all marc worksheet into ddlMarcForm dropdownlist, load some link option
        Private Sub LoadPageHeader()
            ' Declare variables
            Dim intCount As Integer
            Dim tblTemp As DataTable
            Dim strShowFieldName As String = ddlLabel.Items(2).Text
            Dim strHiddFieldName As String = ddlLabel.Items(3).Text
            Dim strShowGroupName As String = ddlLabel.Items(4).Text
            Dim strHiddGroupName As String = ddlLabel.Items(5).Text
            Dim strJsmsg1 As String = ddlLabel.Items(6).Text
            Dim strJsmsg2 As String = ddlLabel.Items(7).Text
            Dim strJsmsg3 As String = ddlLabel.Items(8).Text
            Dim strJsmsg4 As String = ddlLabel.Items(9).Text

            txtJsmsg1.Value = strJsmsg1
            txtJsmsg2.Value = strJsmsg2
            txtJsmsg3.Value = strJsmsg3
            txtJsmsg4.Value = strJsmsg4

            ' Get all worksheet & load into dropdownlist
            tblTemp = objBCatalogueForm.GetForms()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlMarcForm.DataSource = tblTemp
                ddlMarcForm.DataTextField = "Name"
                ddlMarcForm.DataValueField = "ID"
                ddlMarcForm.DataBind()
                If Not Request("FormID") = "" Then
                    For intCount = 0 To tblTemp.Rows.Count - 1
                        If CInt(tblTemp.Rows(intCount).Item("ID")) = CInt(Request("FormID")) Then
                            ddlMarcForm.SelectedIndex = intCount
                            Exit For
                        End If
                    Next
                End If
            End If

            ' GroupBy links
            If Not CInt(Request("GroupBy")) = 0 Then
                lnkGroup.NavigateUrl = "WCata.aspx?FormID=" & Request("FormID") & "&GroupBy=0"
                lnkFunction.NavigateUrl = ""
            Else
                lnkGroup.NavigateUrl = ""
                lnkFunction.NavigateUrl = "WCata.aspx?FormID=" & Request("FormID") & "&GroupBy=1"
            End If

            ' Show FieldName
            If Not Request("ShowFieldName") = "" Then
                Session("ShowFieldName") = Request("ShowFieldName")
            End If
            If Not Request("ShowGroupName") = "" Then
                Session("ShowGroupName") = Request("ShowGroupName")
            End If

            If CInt(Session("ShowFieldName")) = 1 Then
                lnkShowFieldName.NavigateUrl = "WCata.aspx?AddedFieldCodes=" & Request("AddedFieldCodes") & "&FormID=" & Request("FormID") & "&Fields=" & Request("Fields") & "&ShowFieldName=0&ShowGroupName=" & Session("ShowGroupName")
                lnkShowFieldName.Text = strHiddFieldName
            Else
                lnkShowFieldName.NavigateUrl = "WCata.aspx?AddedFieldCodes=" & Request("AddedFieldCodes") & "&FormID=" & Request("FormID") & "&Fields=" & Request("Fields") & "&ShowFieldName=1&ShowGroupName=" & Session("ShowGroupName")
                lnkShowFieldName.Text = strShowFieldName
            End If
            If CInt(Session("ShowGroupName")) = 1 Then
                lnkShowGroupName.NavigateUrl = "WCata.aspx?AddedFieldCodes=" & Request("AddedFieldCodes") & "&FormID=" & Request("FormID") & "&Fields=" & Request("Fields") & "&ShowFieldName=" & Session("ShowFieldName") & "&ShowGroupName=0"
                lnkShowGroupName.Text = strHiddGroupName
            Else
                lnkShowGroupName.NavigateUrl = "WCata.aspx?AddedFieldCodes=" & Request("AddedFieldCodes") & "&FormID=" & Request("FormID") & "&Fields=" & Request("Fields") & "&ShowFieldName=" & Session("ShowFieldName") & "&ShowGroupName=1"
                lnkShowGroupName.Text = strShowGroupName
            End If
        End Sub

        ''' <summary>
        ''' This method is use to create UI cata forms and bind functionalities to each controls.
        ''' </summary>
        ''' <param name="intItemID"></param>
        Private Sub LoadPageBody(Optional ByVal intItemID As Integer = 0)
            ' Declare variables
            Dim strJavascript As String
            Dim intNumberOfCataFields As Integer = 0  ' (Number of cataloguing fields)
            Dim intGroupBy As Integer = 0
            Dim intFormID As Integer
            Dim strFieldCodes As String = Request("FieldCodes")
            Dim strAddedFieldCodes As String = Request("AddedFieldCodes")
            Dim strTextAreaFields As String = ","
            Dim tblCataFields As DataTable = Nothing
            Dim tblCataBlocks As DataTable = Nothing
            Dim tblCataFunctions As DataTable = Nothing

            ' Get FormID
            If IsNumeric(Request("FormID")) Then
                intFormID = Request("FormID")
            End If

            ' Get all form' field to catalogue
            If Not Request("GroupBy") = "" Then
                intGroupBy = CInt(Request("GroupBy"))
            End If

            ' Get TextArea Fields
            strTextAreaFields = GetFieldCodesWithRenderByTextArea(intFormID)

            'Get FieldCode, Functions, Blocks of Cata Fields
            intNumberOfCataFields = GetCataFields(intGroupBy, intFormID, strFieldCodes, strAddedFieldCodes, tblCataFunctions, tblCataBlocks, tblCataFields)

            'Register FieldCode storing javascript
            strJavascript = CreateClientJavascriptStoresForFieldCodes(intNumberOfCataFields, tblCataFields)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CreateArray", strJavascript, True)

            ' Display all form's fields
            Dim intWidth As Integer = 104
            Dim intCols As Integer = 3
            Dim intCount As Integer
            Dim tblRow As TableRow
            Dim tblCell As TableCell

            Dim intGroupID As Integer
            Dim strGroupName As String = ""
            Dim strRepeatFieldValue As New StringBuilder(1024)
            Dim dtrData() As DataRow = Nothing

            intGroupID = -1

            'Create Leader First
            tblResult.Rows.AddRange(CreateLeaderRowUI(intCols))
            'Create Group - Field Name - Field Detail(Link,Indicator,Content)
            For intCount = 0 To intNumberOfCataFields - 1
                Dim drCataFieldRow As DataRow = tblCataFields.Rows(intCount)
                Dim strFieldCode As String = drCataFieldRow.Item("FieldCode")
                If Session("ShowGroupName") = "1" Then
                    tblResult.Rows.Add(CreateCataFieldGroup(intCount, intGroupID, intCols, tblCataFields, tblCataBlocks, tblCataFunctions))
                End If
                If Session("ShowFieldName") = "1" OrElse tblCataFields.Rows(intCount).Item("Repeatable") Then
                    tblResult.Rows.Add(CreateCataFieldName(intCount, intCols, strRepeatFieldValue, drCataFieldRow))
                End If
                If strFieldCode = "245$b" Then
                    tblResult.Rows.Add(CreateCataFieldDetail245b_ss(strTextAreaFields, intItemID, drCataFieldRow))
                    tblResult.Rows.Add(CreateCataFieldDetail245b_pd(strTextAreaFields, intItemID, drCataFieldRow))
                Else
                    tblResult.Rows.Add(CreateCataFieldDetail(strTextAreaFields, intItemID, drCataFieldRow))
                End If
            Next

            tblCell = New TableCell
            tblCell.ColumnSpan = 3
            tblCell.Controls.Add(New LiteralControl("<BR>"))
            tblCell.Controls.Add(New LiteralControl("<BR>"))
            tblRow = New TableRow
            tblRow.Cells.Add(tblCell)
            tblResult.Rows.Add(tblRow)

            ' Load repeatable field values
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "LoadRepFields", "var strRepeatFieldValue = """ & strRepeatFieldValue.ToString() & """;", True)
        End Sub

        ' LoadCataForm method
        ' Purpose: Load catalogue form
        Private Sub LoadCataForm()
            Session.Remove("uploadCataloger")

            Dim strLabel38 As String = ddlLabel.Items(19).Text
            Dim strJs As String = ""

            strJs = strJs & "var strLabel38 = '" & strLabel38 & "';"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "LoadLabels", strJs, True)

            ' LoadPageHeader
            Call LoadPageHeader()

            'Them thao so intItemID dung cho attach file
            Call initUploadfiles()
            Dim intItemID As Integer = 0
            If Not IsNothing(Request("intItemID")) AndAlso Request("intItemID") <> "" Then
                intItemID = Request("intItemID")
            End If
            Call LoadPageBody(intItemID)
        End Sub

        Private Function CreateFieldCodeLinkUIFor245b_ss(ByVal drCataFieldRow As DataRow) As TableCell
            Dim tblFieldCodeLinkCell As TableCell
            Dim lnkFieldCodeLink As HyperLink

            'Create Field Code Link UI
            tblFieldCodeLinkCell = New TableCell
            lnkFieldCodeLink = New HyperLink

            lnkFieldCodeLink.ID = "p" & drCataFieldRow.Item("FieldCode") & "_ss"
            lnkFieldCodeLink.ClientIDMode = UI.ClientIDMode.Static
            lnkFieldCodeLink.CssClass = "lbLinkFunction"
            lnkFieldCodeLink.NavigateUrl = "JavaScript:ShowFieldProperties('" & drCataFieldRow.Item("FieldCode") & "')"
            lnkFieldCodeLink.Text = "245$b(Song song)"

            tblFieldCodeLinkCell.Width = Unit.Percentage(6)
            tblFieldCodeLinkCell.HorizontalAlign = HorizontalAlign.Right
            tblFieldCodeLinkCell.VerticalAlign = VerticalAlign.Top

            Dim imgFieldCodeHelp As New HtmlImage
            imgFieldCodeHelp.Src = "~/Images/RibbonBar/Help/Tag18x18.png"
            tblFieldCodeLinkCell.Controls.Add(imgFieldCodeHelp)

            tblFieldCodeLinkCell.Controls.Add(lnkFieldCodeLink)

            Return tblFieldCodeLinkCell
        End Function

        Private Function CreateFieldCodeLinkUIFor245b_pd(ByVal drCataFieldRow As DataRow) As TableCell
            Dim tblFieldCodeLinkCell As TableCell
            Dim lnkFieldCodeLink As HyperLink

            'Create Field Code Link UI
            tblFieldCodeLinkCell = New TableCell
            lnkFieldCodeLink = New HyperLink

            lnkFieldCodeLink.ID = "p" & drCataFieldRow.Item("FieldCode") & "_pd"
            lnkFieldCodeLink.ClientIDMode = UI.ClientIDMode.Static
            lnkFieldCodeLink.CssClass = "lbLinkFunction"
            lnkFieldCodeLink.NavigateUrl = "JavaScript:ShowFieldProperties('" & drCataFieldRow.Item("FieldCode") & "')"
            lnkFieldCodeLink.Text = "245$b(Phụ đề)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

            tblFieldCodeLinkCell.Width = Unit.Percentage(6)
            tblFieldCodeLinkCell.HorizontalAlign = HorizontalAlign.Right
            tblFieldCodeLinkCell.VerticalAlign = VerticalAlign.Top

            Dim imgFieldCodeHelp As New HtmlImage
            imgFieldCodeHelp.Src = "~/Images/RibbonBar/Help/Tag18x18.png"
            tblFieldCodeLinkCell.Controls.Add(imgFieldCodeHelp)

            tblFieldCodeLinkCell.Controls.Add(lnkFieldCodeLink)

            Return tblFieldCodeLinkCell
        End Function

        Private Function CreateFieldContentUIFor245b_ss(ByVal intItemID As Integer, ByVal strTextAreaFields As String, ByVal drCataFieldRow As DataRow) As TableCell
            Dim tblFieldContentCell As TableCell
            Dim txtFieldContent As TextBox
            Dim IsTextAreaFieldRender As Boolean = If(InStr(strTextAreaFields, drCataFieldRow.Item("FieldCode")) > 0, True, False)
            Dim onChangeFieldContentScriptBuilder As New StringBuilder(1024)
            Dim onFocusFieldContentScriptBuilder As New StringBuilder(256)

            tblFieldContentCell = New TableCell
            tblFieldContentCell.VerticalAlign = VerticalAlign.Top

            txtFieldContent = New TextBox
            txtFieldContent.CssClass = "lbTextbox"
            txtFieldContent.ID = "tag245$b_ss"
            txtFieldContent.ClientIDMode = UI.ClientIDMode.Static
            txtFieldContent.TextMode = TextBoxMode.SingleLine
            txtFieldContent.Width = Unit.Percentage(95)
            onFocusFieldContentScriptBuilder.Append("ChangeTab('245$b_ss');")

            onChangeFieldContentScriptBuilder.Append(clsBCataScriptHelper.CreateOnChangeScriptForNonrepeatableFieldContent245("245$b_ss", ""))
            If IsTextAreaFieldRender Then
                txtFieldContent.TextMode = TextBoxMode.MultiLine
                txtFieldContent.Rows = 2
            End If
            Dim strOnChangeScript As String = onChangeFieldContentScriptBuilder.ToString()
            If strOnChangeScript <> "" Then
                txtFieldContent.Attributes.Add("OnChange", strOnChangeScript)
            End If

            Dim strOnFocusScript As String = onFocusFieldContentScriptBuilder.ToString()
            If strOnFocusScript <> "" Then
                txtFieldContent.Attributes.Add("onFocus", strOnFocusScript)
            End If

            tblFieldContentCell.Controls.Add(txtFieldContent)
            tblFieldContentCell.Controls.Add(New LiteralControl("<BR>"))
            Return tblFieldContentCell
        End Function

        Private Function CreateFieldContentUIFor245b_pd(ByVal intItemID As Integer, ByVal strTextAreaFields As String, ByVal drCataFieldRow As DataRow) As TableCell
            Dim tblFieldContentCell As TableCell
            Dim txtFieldContent As TextBox
            Dim IsTextAreaFieldRender As Boolean = If(InStr(strTextAreaFields, drCataFieldRow.Item("FieldCode")) > 0, True, False)
            Dim onChangeFieldContentScriptBuilder As New StringBuilder(1024)
            Dim onFocusFieldContentScriptBuilder As New StringBuilder(256)

            tblFieldContentCell = New TableCell
            tblFieldContentCell.VerticalAlign = VerticalAlign.Top

            txtFieldContent = New TextBox
            txtFieldContent.CssClass = "lbTextbox"
            txtFieldContent.ID = "tag245$b_pd"
            txtFieldContent.ClientIDMode = UI.ClientIDMode.Static
            txtFieldContent.TextMode = TextBoxMode.SingleLine
            txtFieldContent.Width = Unit.Percentage(95)
            onFocusFieldContentScriptBuilder.Append("ChangeTab('245$b_pd');")

            onChangeFieldContentScriptBuilder.Append(clsBCataScriptHelper.CreateOnChangeScriptForNonrepeatableFieldContent245("245$b_pd", ""))
            If IsTextAreaFieldRender Then
                txtFieldContent.TextMode = TextBoxMode.MultiLine
                txtFieldContent.Rows = 2
            End If
            Dim strOnChangeScript As String = onChangeFieldContentScriptBuilder.ToString()
            If strOnChangeScript <> "" Then
                txtFieldContent.Attributes.Add("OnChange", strOnChangeScript)
            End If

            Dim strOnFocusScript As String = onFocusFieldContentScriptBuilder.ToString()
            If strOnFocusScript <> "" Then
                txtFieldContent.Attributes.Add("onFocus", strOnFocusScript)
            End If

            tblFieldContentCell.Controls.Add(txtFieldContent)
            tblFieldContentCell.Controls.Add(New LiteralControl("<BR>"))
            Return tblFieldContentCell
        End Function

        Private Function CreateFieldCodeLink(ByVal drCataFieldRow As DataRow) As TableCell
            Dim tblFieldCodeLinkCell As TableCell
            Dim lnkFieldCodeLink As HyperLink

            'Create Field Code Link UI
            tblFieldCodeLinkCell = New TableCell
            lnkFieldCodeLink = New HyperLink

            lnkFieldCodeLink.ID = "p" & drCataFieldRow.Item("FieldCode")
            lnkFieldCodeLink.ClientIDMode = UI.ClientIDMode.Static
            lnkFieldCodeLink.CssClass = "lbLinkFunction"
            lnkFieldCodeLink.NavigateUrl = "JavaScript:ShowFieldProperties('" & drCataFieldRow.Item("FieldCode") & "')"
            lnkFieldCodeLink.Text = drCataFieldRow.Item("FieldCode")

            tblFieldCodeLinkCell.Width = Unit.Percentage(6)
            tblFieldCodeLinkCell.HorizontalAlign = HorizontalAlign.Right
            tblFieldCodeLinkCell.VerticalAlign = VerticalAlign.Top

            Dim imgFieldCodeHelp As New HtmlImage
            imgFieldCodeHelp.Src = "~/Images/RibbonBar/Help/Tag18x18.png"
            tblFieldCodeLinkCell.Controls.Add(imgFieldCodeHelp)

            tblFieldCodeLinkCell.Controls.Add(lnkFieldCodeLink)

            Return tblFieldCodeLinkCell
        End Function

        Private Function CreateFieldContent(ByVal intItemID As Integer,
                                              ByVal strTextAreaFields As String,
                                              ByVal drCataFieldRow As DataRow
                                              ) As TableCell
            Dim tblFieldContentCell As TableCell
            Dim txtFieldContent As TextBox

            Dim FieldCode As String = drCataFieldRow.Item("FieldCode").ToString().Trim()
            Dim FieldType As Integer = CInt(drCataFieldRow.Item("FieldTypeID"))
            Dim IsTextAreaFieldRender As Boolean = If(InStr(strTextAreaFields, drCataFieldRow.Item("FieldCode")) > 0, True, False)
            Dim IsRepeatableField As Boolean = drCataFieldRow.Item("Repeatable")
            Dim IsRequiredField As Boolean = False
            Dim onChangeFieldContentScriptBuilder As New StringBuilder(1024)
            Dim onFocusFieldContentScriptBuilder As New StringBuilder(256)
            If Not IsDBNull(drCataFieldRow.Item("AlwaysMandatory")) Then
                IsRequiredField = drCataFieldRow.Item("AlwaysMandatory")
            End If
            If Not IsRequiredField Then
                If Not IsDBNull(drCataFieldRow.Item("Mandatory")) Then
                    IsRequiredField = drCataFieldRow.Item("Mandatory")
                End If
            End If


            tblFieldContentCell = New TableCell
            tblFieldContentCell.VerticalAlign = VerticalAlign.Top

            ' If current tag is "001" (Id number) then check if the entered value has been already in use
            If FieldCode = "001" Then
                onChangeFieldContentScriptBuilder.Append(clsBCataScriptHelper.CreateCheckItemCodeScript(intUTF))
            End If

            ' If current tag is "245" (title) then check if the same title has been catalogued elsewhere in the database
            Dim checkTitleScript As String = ""
            If FieldCode = "245$a" Then
                checkTitleScript = clsBCataScriptHelper.CreateCheckTitleScript(intUTF)
            End If

            txtFieldContent = New TextBox
            txtFieldContent.CssClass = "lbTextbox"
            txtFieldContent.ID = "tag" & drCataFieldRow.Item("FieldCode")
            txtFieldContent.ClientIDMode = UI.ClientIDMode.Static
            txtFieldContent.TextMode = TextBoxMode.SingleLine
            txtFieldContent.Width = Unit.Percentage(95)

            'Depend on FieldTypeID of MARC Field, the appropriate TextBox control will created
            Select Case FieldType
                Case 2, 3
                    onChangeFieldContentScriptBuilder.AppendFormat("u('").Append(FieldCode).Append("');").
                                              Append("if(CheckDate(this,document.forms[0].txtJsmsg2.value)){").
                                              AppendFormat("parent.Sentform.document.forms[0].tag").Append(FieldCode).Append(".value = this.value;").
                                              Append("UpdateLeader('', '', '', '');").
                                              Append("}")
                    onFocusFieldContentScriptBuilder.Append("ChangeTab('").Append(FieldCode).Append("');")
                    If FieldType = 2 Then
                        txtFieldContent.MaxLength = 10
                    End If
                Case 5
                    onChangeFieldContentScriptBuilder.AppendFormat("if (this.value == 'True') {parent.Sentform.document.forms[0].tag").Append(FieldCode).Append(".value = 1;}").
                                              AppendFormat("else {parent.Sentform.document.forms[0].tag").Append(FieldCode).Append(".value = 0;}").
                                              AppendFormat("parent.Sentform.document.forms[0].tag").Append(FieldCode).Append(".value = this.value;")
                    onFocusFieldContentScriptBuilder.Append("this.blur();")
                    txtFieldContent.Enabled = False
                Case Else
                    'Hardcode field 520$a with textarea render
                    If FieldCode = "520$a" Then
                        txtFieldContent.TextMode = TextBoxMode.MultiLine
                        txtFieldContent.Rows = 5
                    End If

                    'Cataloguer so set it text
                    If FieldCode = "911" Then
                        txtFieldContent.Text = clsSession.GlbUserFullName
                    End If

                    onFocusFieldContentScriptBuilder.Append("ChangeTab('").Append(FieldCode).Append("');")

                    If IsRepeatableField Then
                        onChangeFieldContentScriptBuilder.Append(clsBCataScriptHelper.CreateOnChangeScriptForRepeatableFieldContent(FieldCode, checkTitleScript))
                        If IsTextAreaFieldRender Then
                            txtFieldContent.TextMode = TextBoxMode.MultiLine
                            txtFieldContent.Rows = 2
                        End If
                    Else
                        onChangeFieldContentScriptBuilder.Append(clsBCataScriptHelper.CreateOnChangeScriptForNonrepeatableFieldContent(FieldCode, checkTitleScript))
                        'If Request('modify') = 1
                        If FieldCode <> "911" OrElse CStr(Request("modify")) <> "1" Then
                            If IsTextAreaFieldRender Then
                                txtFieldContent.TextMode = TextBoxMode.MultiLine
                                txtFieldContent.Rows = 2
                            End If
                        Else
                            txtFieldContent.TextMode = TextBoxMode.MultiLine
                            txtFieldContent.Rows = 2
                        End If
                    End If
            End Select
            Dim strOnChangeScript As String = onChangeFieldContentScriptBuilder.ToString()
            If strOnChangeScript <> "" Then
                txtFieldContent.Attributes.Add("OnChange", strOnChangeScript)
            End If
            Dim strOnFocusScript As String = onFocusFieldContentScriptBuilder.ToString()
            If strOnFocusScript <> "" Then
                txtFieldContent.Attributes.Add("onFocus", strOnFocusScript)
            End If

            tblFieldContentCell.Controls.Add(txtFieldContent)

            ' Show mandatory comment
            If IsRequiredField Then
                Dim lblRequired As Label
                lblRequired = New Label
                lblRequired.ForeColor = Color.Red
                lblRequired.Text = " (*)"
                lblRequired.ToolTip = ddlLabel.Items(20).Text
                tblFieldContentCell.Controls.Add(lblRequired)
            End If
            tblFieldContentCell.Controls.Add(New LiteralControl("<BR>"))
            CreateHelperFieldContentLink(intItemID, drCataFieldRow, tblFieldContentCell)
            Return tblFieldContentCell
        End Function

        Private Function CreateFieldIndicator(ByVal drCataFieldRow As DataRow) As TableCell
            Dim tblIndicatorCell As TableCell
            ' Create Indicator UI
            tblIndicatorCell = New TableCell
            tblIndicatorCell.HorizontalAlign = HorizontalAlign.Center
            tblIndicatorCell.VerticalAlign = VerticalAlign.Top
            If Not (IsDBNull(drCataFieldRow.Item("Indicators")) OrElse Not IsDBNull(drCataFieldRow.Item("VietIndicators"))) Then
                CreateFieldIndicator(drCataFieldRow, tblIndicatorCell)
            End If
            Return tblIndicatorCell
        End Function

        ''' <summary>
        ''' Create TableRow UI contains Field Code Link, Field Indicator TextBox, Field Content TextBox.
        ''' This version custom for 245$b with Parallel Title and Sub-Title
        ''' </summary>
        ''' <param name="strTextAreaFields"></param>
        ''' <param name="intItemID"></param>
        ''' <param name="drCataFieldRow"></param>
        ''' <returns></returns>
        Private Function CreateCataFieldDetail245b_ss(ByVal strTextAreaFields As String, ByVal intItemID As Integer,
                                      ByVal drCataFieldRow As DataRow) As TableRow
            Dim tblRow As TableRow

            tblRow = New TableRow
            tblRow.Attributes.Add("onMouseOver", "mOvr(this,'#FFCC99');")
            tblRow.Attributes.Add("onMouseOut", "mOut(this,'#f0f3f4');")
            tblRow.Attributes.Add("onFocus", "mOvr(this,'#FFCC99');")

            ' Add to row
            Dim cell As TableCell = CreateFieldCodeLinkUIFor245b_ss(drCataFieldRow)
            cell.ColumnSpan = 2
            tblRow.Cells.Add(cell)
            tblRow.Cells.Add(CreateFieldContentUIFor245b_ss(intItemID, strTextAreaFields, drCataFieldRow))
            Return tblRow
        End Function

        Private Function CreateCataFieldDetail245b_pd(ByVal strTextAreaFields As String, ByVal intItemID As Integer,
                                      ByVal drCataFieldRow As DataRow) As TableRow
            Dim tblRow As TableRow

            tblRow = New TableRow
            tblRow.Attributes.Add("onMouseOver", "mOvr(this,'#FFCC99');")
            tblRow.Attributes.Add("onMouseOut", "mOut(this,'#f0f3f4');")
            tblRow.Attributes.Add("onFocus", "mOvr(this,'#FFCC99');")

            ' Add to row
            Dim cell As TableCell = CreateFieldCodeLinkUIFor245b_pd(drCataFieldRow)
            cell.ColumnSpan = 2
            tblRow.Cells.Add(cell)
            tblRow.Cells.Add(CreateFieldContentUIFor245b_pd(intItemID, strTextAreaFields, drCataFieldRow))
            Return tblRow
        End Function

        ''' <summary>
        ''' Create TableRow UI contains Field Code Link, Field Indicator TextBox, Field Content TextBox
        ''' </summary>
        ''' <param name="strTextAreaFields"></param>
        ''' <param name="intItemID"></param>
        ''' <param name="drCataFieldRow"></param>
        ''' <returns></returns>
        Private Function CreateCataFieldDetail(ByVal strTextAreaFields As String, ByVal intItemID As Integer,
                                      ByVal drCataFieldRow As DataRow) As TableRow
            Dim tblRow As TableRow

            tblRow = New TableRow
            tblRow.Attributes.Add("onMouseOver", "mOvr(this,'#FFCC99');")
            tblRow.Attributes.Add("onMouseOut", "mOut(this,'#f0f3f4');")
            tblRow.Attributes.Add("onFocus", "mOvr(this,'#FFCC99');")

            ' Add to row
            tblRow.Cells.Add(CreateFieldCodeLink(drCataFieldRow))
            tblRow.Cells.Add(CreateFieldIndicator(drCataFieldRow))
            tblRow.Cells.Add(CreateFieldContent(intItemID, strTextAreaFields, drCataFieldRow))
            Return tblRow
        End Function

        Private Sub CreateFieldIndicator(ByVal drCataFieldRow As DataRow, ByVal tblCell As TableCell)
            Dim txtIndicator As TextBox
            Dim lnkIndicatorHelp As HyperLink
            Dim fieldCode As String = drCataFieldRow.Item("FieldCode")

            txtIndicator = New TextBox
            txtIndicator.CssClass = "lbTextbox"
            txtIndicator.ID = "ind" & fieldCode
            txtIndicator.ClientIDMode = UI.ClientIDMode.Static
            txtIndicator.Attributes.Add("OnFocus", "ChangeTab('" & fieldCode & "')")

            txtIndicator.Width = Unit.Pixel(30)
            txtIndicator.MaxLength = 2
            If CInt(drCataFieldRow.Item("Repeatable")) = 0 Then
                txtIndicator.Attributes.Add("OnChange", "u('" & fieldCode & "'); parent.Sentform.document.forms[0].tag" & fieldCode & ".value = this.value + '::' + document.forms[0].tag" & fieldCode & ".value; UpdateLeader('', '', '', '')")
            Else
                txtIndicator.Attributes.Add("OnChange", "u('" & fieldCode & "'); UpdateRecord('" & fieldCode & "', 0)")
            End If

            lnkIndicatorHelp = New HyperLink
            lnkIndicatorHelp.ID = "p" & objBCSP.getParentField(fieldCode)
            lnkIndicatorHelp.ClientIDMode = UI.ClientIDMode.Static
            lnkIndicatorHelp.CssClass = "lbLinkFunction"
            lnkIndicatorHelp.NavigateUrl = "JavaScript:ShowFieldProperties('" & objBCSP.getParentField(fieldCode) & "')"
            lnkIndicatorHelp.ImageUrl = "~/Images/RibbonBar/Help/HelpB18x18.png"

            tblCell.Width = Unit.Percentage(6)
            tblCell.HorizontalAlign = HorizontalAlign.Center
            tblCell.VerticalAlign = VerticalAlign.Top

            'Add to our table cell
            tblCell.Controls.Add(txtIndicator)
            tblCell.Controls.Add(lnkIndicatorHelp)
        End Sub

        ''' <summary>
        ''' Create some helper link below Field TextBox
        ''' </summary>
        ''' <param name="intItemID"></param>
        ''' <param name="drCataFieldRow"></param>
        ''' <param name="tblCell"></param>
        Private Sub CreateHelperFieldContentLink(ByVal intItemID As Integer, ByVal drCataFieldRow As DataRow, ByVal tblCell As TableCell)
            Dim lnkLink As HyperLink
            Dim lnkGenVal As HyperLink
            Dim lnkGen090 As HyperLink
            Dim lnkHelp As HyperLink
            Dim lnkSelect As HyperLink
            Dim lnkNLVCutter As HyperLink
            Dim lnkNLVCutterTG As HyperLink
            Dim lnkDictionary As HyperLink
            Dim lnkAuthority As HyperLink
            Dim lnkFieldHelp As HyperLink
            Dim lnkClassification As HyperLink
            Dim intSlash As Integer = 0
            Dim strRep As String

            Dim strDictionary As String = ddlLabel.Items(12).Text
            Dim strHelp As String = ddlLabel.Items(13).Text
            Dim strAttachFile As String = ddlLabel.Items(14).Text
            Dim strAuthority As String = ddlLabel.Items(16).Text

            lnkLink = New HyperLink
            lnkLink.Text = ddlLabel.Items(21).Text
            lnkLink.CssClass = "lbLinkFunction"

            lnkGenVal = New HyperLink
            lnkGenVal.Text = ddlLabel.Items(15).Text
            lnkGenVal.CssClass = "lbLinkFunction"

            lnkGen090 = New HyperLink
            lnkGen090.Text = ddlLabel.Items(15).Text
            lnkGen090.CssClass = "lbLinkFunction"

            lnkHelp = New HyperLink
            lnkHelp.Text = ddlLabel.Items(13).Text
            lnkHelp.CssClass = "lbLinkFunction"

            lnkSelect = New HyperLink
            lnkSelect.Text = ddlLabel.Items(10).Text
            lnkSelect.CssClass = "lbLinkFunction"

            lnkNLVCutter = New HyperLink
            lnkNLVCutter.Text = ddlLabel.Items(17).Text
            lnkNLVCutter.CssClass = "lbLinkFunction"

            lnkNLVCutterTG = New HyperLink
            lnkNLVCutterTG.Text = ddlLabel.Items(18).Text
            lnkNLVCutterTG.CssClass = "lbLinkFunction"

            lnkDictionary = New HyperLink
            lnkDictionary.CssClass = "lbLinkFunction"
            lnkDictionary.Text = strDictionary

            lnkAuthority = New HyperLink
            lnkAuthority.CssClass = "lbLinkFunction"
            lnkAuthority.Text = strAuthority

            lnkFieldHelp = New HyperLink
            lnkFieldHelp.CssClass = "lbLinkFunction"
            lnkFieldHelp.Text = strHelp

            lnkClassification = New HyperLink
            lnkClassification.CssClass = "lbLinkFunction"
            lnkClassification.Text = ddlLabel.Items(22).Text.Trim

            If drCataFieldRow.Item("FieldCode") = "001" Then
                lnkGenVal.NavigateUrl = "JavaScript:Gen001()"
            Else
                lnkGenVal.NavigateUrl = ""
            End If

            ' Links item
            If CInt(drCataFieldRow.Item("FieldTypeID")) = 7 Then
                lnkLink.NavigateUrl = "JavaScript:Search('" & drCataFieldRow.Item("FieldCode") & "')"
            Else
                If CInt(drCataFieldRow.Item("FieldTypeID")) = 8 Then
                    lnkLink.NavigateUrl = "JavaScript:SearchMaga('" & drCataFieldRow.Item("FieldCode") & "')"
                Else
                    lnkLink.NavigateUrl = ""
                End If
            End If

            If CInt(drCataFieldRow.Item("FieldTypeID")) = 4 Or CInt(drCataFieldRow.Item("FieldTypeID")) = 6 Then
                lnkHelp.ID = "a" & drCataFieldRow.Item("FieldCode")
                lnkHelp.ClientIDMode = UI.ClientIDMode.Static
                lnkHelp.Attributes.Add("name", "a" & drCataFieldRow.Item("FieldCode"))
                lnkHelp.NavigateUrl = "JavaScript:AttachFile(" & intItemID & ",'Workform.document.forms[0].tag" & drCataFieldRow.Item("FieldCode") & "','Sentform.document.forms[0].tag" & drCataFieldRow.Item("FieldCode") & "','" & drCataFieldRow.Item("FieldCode") & "','" & drCataFieldRow.Item("Repeatable") & "')"
                lnkHelp.Text = strAttachFile
                '2016.05.07 B1
                If drCataFieldRow.Item("FieldCode") <> "907" And drCataFieldRow.Item("FieldCode") <> "956$a" Then
                    lnkSelect.ID = "k" & drCataFieldRow.Item("FieldCode")
                    lnkSelect.ClientIDMode = UI.ClientIDMode.Static
                    lnkSelect.Attributes.Add("name", "k" & drCataFieldRow.Item("FieldCode"))
                    lnkSelect.NavigateUrl = "JavaScript:SelectFile(" & intItemID & ",'Workform.document.forms[0].tag" & drCataFieldRow.Item("FieldCode") & "','Sentform.document.forms[0].tag" & drCataFieldRow.Item("FieldCode") & "','" & drCataFieldRow.Item("FieldCode") & "','" & drCataFieldRow.Item("Repeatable") & "')"
                    lnkSelect.Text = ddlLabel.Items(10).Text
                Else
                    lnkSelect.NavigateUrl = ""
                End If
                '2016.05.07 E1
            Else
                lnkHelp.NavigateUrl = ""
                lnkSelect.NavigateUrl = ""
            End If

            ' Show some links (help, dictionary, authority...)
            intSlash = 0
            If Not lnkLink.NavigateUrl = "" Then
                tblCell.Controls.Add(lnkLink)
                intSlash = 1
            End If
            If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
            intSlash = 0
            If Not lnkGenVal.NavigateUrl = "" Then
                tblCell.Controls.Add(lnkGenVal)
            End If
            If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
            intSlash = 0
            If Not lnkHelp.NavigateUrl = "" Then
                tblCell.Controls.Add(lnkHelp)
                intSlash = 1
            End If
            If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
            intSlash = 0
            If Not lnkSelect.NavigateUrl = "" Then
                tblCell.Controls.Add(lnkSelect)
                intSlash = 1
            End If

            If drCataFieldRow.Item("FieldCode") = "082$b" Then
                '2016.04.14 E1
                If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
                lnkNLVCutter.NavigateUrl = "JavaScript:CalCutter(0)"
                tblCell.Controls.Add(lnkNLVCutter)
                intSlash = 1

                If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
                lnkNLVCutterTG.NavigateUrl = "JavaScript:CalCutter(1)"
                tblCell.Controls.Add(lnkNLVCutterTG)
                intSlash = 1
            End If
            If Not IsDBNull(drCataFieldRow.Item("DicID")) Then
                If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
                If CStr(drCataFieldRow.Item("Repeatable")) = "True" Or CInt(drCataFieldRow.Item("Repeatable")) = 1 Then
                    strRep = "1"
                Else
                    strRep = "0"
                End If
                Dim fieldCode = drCataFieldRow.Item("FieldCode")
                If fieldCode.ToString() <> "650$a" And fieldCode.ToString() <> "653$a" Then
                    lnkDictionary.NavigateUrl = "JavaScript:CheckIt(document.forms[0].tag" & drCataFieldRow.Item("FieldCode") & ".value,'tag" & drCataFieldRow.Item("FieldCode") & "','" & strRep & "', " & Session("IsAuthority") & ")"
                    lnkDictionary.ID = "d" & drCataFieldRow.Item("FieldCode")
                    lnkDictionary.Attributes.Add("name", "d" & drCataFieldRow.Item("FieldCode"))
                    tblCell.Controls.Add(lnkDictionary)
                    intSlash = 1
                    If fieldCode = "100$a" Or fieldCode = "110$a" Or fieldCode = "700$a" Or fieldCode = "710$a" Then
                        lnkDictionary.Visible = False
                    End If
                End If
            End If

            If CInt(drCataFieldRow.Item("Coded")) = 1 Or CStr(drCataFieldRow.Item("Coded")) = "True" Then
                If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
                lnkFieldHelp.ID = "h" & drCataFieldRow.Item("FieldCode")
                lnkFieldHelp.ClientIDMode = UI.ClientIDMode.Static
                lnkFieldHelp.Attributes.Add("name", "h" & drCataFieldRow.Item("FieldCode"))
                lnkFieldHelp.NavigateUrl = "JavaScript:CodedHelp('" & drCataFieldRow.Item("FieldCode") & "', " & Session("IsAuthority") & ")"
                tblCell.Controls.Add(lnkFieldHelp)
                intSlash = 1
            End If

            If Not IsDBNull(drCataFieldRow.Item("AuthorityID")) Then
                If CStr(drCataFieldRow.Item("Repeatable")) = "True" Or CInt(drCataFieldRow.Item("Repeatable")) = 1 Then
                    strRep = "1"
                Else
                    strRep = "0"
                End If
                If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
                lnkAuthority.ID = "y" & drCataFieldRow.Item("FieldCode")
                lnkAuthority.ClientIDMode = UI.ClientIDMode.Static
                lnkAuthority.Attributes.Add("name", "y" & drCataFieldRow.Item("FieldCode"))
                lnkAuthority.NavigateUrl = "JavaScript:AuthorityHelp(document.forms[0].tag" & drCataFieldRow.Item("FieldCode") & ".value,'tag" & drCataFieldRow.Item("FieldCode") & "','" & strRep & "', " & Session("IsAuthority") & ")"
                tblCell.Controls.Add(lnkAuthority)
            End If

            If Not IsDBNull(drCataFieldRow.Item("ClassificationID")) Then
                If CStr(drCataFieldRow.Item("Repeatable")) = "True" Or CInt(drCataFieldRow.Item("Repeatable")) = 1 Then
                    strRep = "1"
                Else
                    strRep = "0"
                End If
                If intSlash = 1 Then tblCell.Controls.Add(New LiteralControl(" | "))
                lnkClassification.ID = "a" & drCataFieldRow.Item("FieldCode")
                lnkClassification.ClientIDMode = UI.ClientIDMode.Static
                lnkClassification.Attributes.Add("name", "a" & drCataFieldRow.Item("FieldCode"))
                lnkClassification.NavigateUrl = "JavaScript:ClassificationHelp(document.forms[0].tag" & drCataFieldRow.Item("FieldCode") & ".value,'tag" & drCataFieldRow.Item("FieldCode") & "','" & strRep & "')"
                tblCell.Controls.Add(lnkClassification)
            End If
        End Sub

        ''' <summary>
        ''' This row include: Field-Name + Repeatable Field Content Control(move,new).
        ''' </summary>
        ''' <param name="intCount"></param>
        ''' <param name="intCols"></param>
        ''' <param name="strRepeatFieldValue"></param>
        ''' <param name="drCataFieldRow"></param>
        ''' <returns></returns>
        Private Function CreateCataFieldName(ByVal intCount As Integer, ByVal intCols As Integer,
                                                  ByVal strRepeatFieldValue As StringBuilder,
                                                  ByVal drCataFieldRow As DataRow) As TableRow
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim tblChildTable As Table
            Dim tblChildRow As TableRow
            Dim tblChildCell As TableCell
            Dim lblFieldFunctionNameDisplay As Label

            Dim fieldCode As String = drCataFieldRow.Item("FieldCode").ToString()
            Dim fieldName As String = drCataFieldRow.Item("FieldName").ToString()
            Dim viFieldName As String = drCataFieldRow.Item("VietFieldName").ToString()
            Dim isRepeatable As Boolean = drCataFieldRow.Item("Repeatable")
            Dim fieldType As Integer = CInt(drCataFieldRow.Item("FieldTypeID"))

            tblRow = New TableRow
            tblCell = New TableCell

            tblChildTable = New Table
            tblChildTable.CellPadding = 0
            tblChildTable.CellSpacing = 1
            tblChildTable.BorderWidth = Unit.Pixel(0)
            tblChildTable.Width = Unit.Percentage(100)

            tblChildRow = New TableRow
            tblChildCell = New TableCell
            tblChildCell.HorizontalAlign = HorizontalAlign.Left
            tblChildCell.VerticalAlign = VerticalAlign.Top

            If Session("ShowFieldName") = "1" Then
                lblFieldFunctionNameDisplay = New Label
                lblFieldFunctionNameDisplay.CssClass = "lbLabel"
                lblFieldFunctionNameDisplay.Font.Bold = True
                lblFieldFunctionNameDisplay.Font.Size = FontUnit.Small

                ' Take care of the case when the field is not yet translated into Vietnamese (4)
                If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                    lblFieldFunctionNameDisplay.Text = fieldCode & ": " & viFieldName
                Else
                    lblFieldFunctionNameDisplay.Text = fieldCode & ": " & fieldName
                End If ' End Field name
                tblChildCell.Controls.Add(lblFieldFunctionNameDisplay)
            End If

            tblChildRow.Cells.Add(tblChildCell)
            tblChildCell = New TableCell
            tblChildCell.HorizontalAlign = HorizontalAlign.Right
            tblChildCell.VerticalAlign = VerticalAlign.Top

            ' If the parent field is a repeatable one, then display the navigatiob bar (5)
            If isRepeatable Then
                If fieldType <> 4 Then
                    strRepeatFieldValue.Append(fieldCode).Append(",")

                    ' Create Move First Button
                    Dim btnMoveFirst As New Button
                    btnMoveFirst.Text = "|<"
                    btnMoveFirst.Width = Unit.Pixel(20)
                    btnMoveFirst.CssClass = "lbButton"
                    btnMoveFirst.ID = "btn" & fieldCode & "1" 'ID is btn245$a1
                    btnMoveFirst.ClientIDMode = UI.ClientIDMode.Static
                    'ViewRecord('245$a',1,'Bạn đang ở bản ghi đầu tiên','Bạn đang ở bản ghi cuối cùng')
                    'fieldCode-Index from 1-lower bound msg-higher bound msg
                    btnMoveFirst.Attributes.Add("OnClick", "ViewRecord('" & fieldCode & "', 1, document.forms[0].txtJsmsg3.value, document.forms[0].txtJsmsg4.value); return false;")
                    tblChildCell.Controls.Add(btnMoveFirst)

                    ' Create Move Prev Button
                    Dim btnMovePrev As New Button
                    btnMovePrev.Text = "<"
                    btnMovePrev.Width = Unit.Pixel(20)
                    btnMovePrev.CssClass = "lbButton"
                    btnMovePrev.ID = "btn" & fieldCode & "2"
                    btnMovePrev.ClientIDMode = UI.ClientIDMode.Static
                    btnMovePrev.Attributes.Add("OnClick", "ViewRecord('" & fieldCode & "', parseInt(document.forms[0].nr" & fieldCode & "1.value) - 1, document.forms[0].txtJsmsg3.value, document.forms[0].txtJsmsg4.value); return false;")
                    tblChildCell.Controls.Add(btnMovePrev)

                    ' Create current record textbox
                    Dim txtCurrentRecord As New TextBox
                    txtCurrentRecord.Text = 0
                    txtCurrentRecord.Width = Unit.Pixel(30)
                    txtCurrentRecord.MaxLength = 2
                    txtCurrentRecord.Enabled = False
                    txtCurrentRecord.CssClass = "lbTextbox"
                    txtCurrentRecord.ID = "nr" & fieldCode & "1"
                    txtCurrentRecord.Attributes.Add("onFocus", "this.blur();")
                    tblChildCell.Controls.Add(txtCurrentRecord)

                    ' Create Move Next Button
                    Dim btnMoveNext As New Button
                    btnMoveNext.Text = ">"
                    btnMoveNext.Width = Unit.Pixel(20)
                    btnMoveNext.CssClass = "lbButton"
                    btnMoveNext.ID = "btn" & fieldCode & "3"
                    btnMoveNext.ClientIDMode = UI.ClientIDMode.Static
                    btnMoveNext.Attributes.Add("OnClick", "ViewRecord('" & fieldCode & "', parseInt(document.forms[0].nr" & fieldCode & "1.value) + 1, document.forms[0].txtJsmsg3.value, document.forms[0].txtJsmsg4.value); return false;")
                    tblChildCell.Controls.Add(btnMoveNext)

                    ' Create Move Last Button
                    Dim btnMoveLast As New Button
                    btnMoveLast.Text = ">|"
                    btnMoveLast.Width = Unit.Pixel(20)
                    btnMoveLast.CssClass = "lbButton"
                    btnMoveLast.ID = "btn" & fieldCode & "4"
                    btnMoveLast.ClientIDMode = UI.ClientIDMode.Static
                    btnMoveLast.Attributes.Add("OnClick", "ViewRecord('" & fieldCode & "', document.forms[0].nr" & fieldCode & "2.value, document.forms[0].txtJsmsg3.value, document.forms[0].txtJsmsg4.value); return false;")
                    tblChildCell.Controls.Add(btnMoveLast)

                    ' Create NewRecord Button
                    Dim btnNewRecord As New Button
                    btnNewRecord.Text = ">*"
                    btnNewRecord.Width = Unit.Pixel(20)
                    btnNewRecord.CssClass = "lbButton"
                    btnNewRecord.ID = "btn" & fieldCode & "5"
                    btnNewRecord.ClientIDMode = UI.ClientIDMode.Static
                    btnNewRecord.Attributes.Add("OnClick", "AddNewRecord('" & fieldCode & "', nr" & fieldCode & "1, nr" & fieldCode & "2); return false;")
                    tblChildCell.Controls.Add(btnNewRecord)

                    ' Create TotalRecord TextBox
                    Dim txtTotalRecord As New TextBox
                    txtTotalRecord.Text = 0
                    txtTotalRecord.Width = Unit.Pixel(30)
                    txtTotalRecord.MaxLength = 2
                    txtTotalRecord.Enabled = False
                    txtTotalRecord.CssClass = "lbTextbox"
                    txtTotalRecord.ID = "nr" & fieldCode & "2"
                    txtTotalRecord.ClientIDMode = UI.ClientIDMode.Static
                    tblChildCell.Controls.Add(txtTotalRecord)

                    ' Show delete button
                    Dim btnDeleteRecord As New Button
                    btnDeleteRecord.Text = "X"
                    btnDeleteRecord.Width = Unit.Pixel(20)
                    btnDeleteRecord.CssClass = "lbButton"
                    btnDeleteRecord.ID = "btn" & fieldCode & "6"
                    btnDeleteRecord.ClientIDMode = UI.ClientIDMode.Static
                    btnDeleteRecord.Attributes.Add("OnClick", "DeleteRecord('" & fieldCode & "', parseInt(document.forms[0].nr" & fieldCode & "1.value)); return false;")
                    tblChildCell.Controls.Add(btnDeleteRecord)
                End If
            End If  ' End Repeatable (5)

            tblChildRow.Cells.Add(tblChildCell)
            tblChildTable.Controls.Add(tblChildRow)
            tblCell.Controls.Add(tblChildTable)
            tblCell.ColumnSpan = intCols
            tblRow.Cells.Add(tblCell)
            Return tblRow
        End Function

        'When intGroupID and Field Block ID have different values, Create a new GroupName
        Private Function CreateCataFieldGroup(ByVal intIndex As Integer,
                                                   ByRef intGroupID As Integer,
                                                   ByVal intColumnSpan As Integer,
                                                   ByVal tblCataFields As DataTable,
                                                   ByVal tblCataBlocks As DataTable,
                                                   ByVal tblCataFunctions As DataTable) As TableRow

            Dim tblFieldGroupRow As New TableRow

            Dim dtrData() As DataRow
            Dim strGroupName As String = Nothing

            ' Grouped by USMARC block
            'This has a issue if BlockID not in sequence place , multiple GroupName with same name will created.
            'When field BlockID change, create new group name.
            If Request("GroupBy") <> "1" Then 'Group By Block
                If CInt(tblCataFields.Rows(intIndex).Item("BlockID")) <> intGroupID Then
                    intGroupID = tblCataFields.Rows(intIndex).Item("BlockID")
                    dtrData = tblCataBlocks.Select("ID=" & intGroupID)
                    If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                        strGroupName = dtrData(0).Item("VietBlockName")
                    Else
                        strGroupName = dtrData(0).Item("BlockName")
                    End If
                    strGroupName = dtrData(0).Item("BlockCode") & ": " & strGroupName
                    tblCataBlocks.Select()
                End If
            Else ' Group by function
                If Not IsDBNull(tblCataFields.Rows(intIndex).Item("FunctionID")) Then
                    If CLng(tblCataFields.Rows(intIndex).Item("FunctionID")) <> intGroupID Then
                        intGroupID = CLng(tblCataFields.Rows(intIndex).Item("FunctionID"))
                        dtrData = tblCataFunctions.Select("ID=" & intGroupID)
                        strGroupName = dtrData(0).Item("FieldFunction")
                        tblCataFunctions.Select()
                    End If
                End If
            End If ' End Grouped by
            If strGroupName IsNot Nothing Then
                Dim lblFieldGroup As New Label
                Dim tblFieldGroupCell As New TableCell
                lblFieldGroup.CssClass = "lbLabel"
                lblFieldGroup.ForeColor = Color.FromName("#0000")
                lblFieldGroup.Text = strGroupName
                tblFieldGroupCell.Controls.Add(lblFieldGroup)
                tblFieldGroupCell.ColumnSpan = intColumnSpan
                tblFieldGroupRow.Cells.Add(tblFieldGroupCell)
                tblFieldGroupRow.BackColor = Color.FromName("aacfea")
            End If
            Return tblFieldGroupRow
        End Function

        'Leader
        Private Function CreateLeaderRowUI(ByVal intCols As Integer) As TableRow()
            Dim tblLeaderRow As TableRow
            Dim tblCell As TableCell
            Dim lblTemp As Label
            Dim txbTemp As TextBox
            Dim lnkTemp As HyperLink
            Dim tblRows() As TableRow
            ReDim tblRows(2)

            tblLeaderRow = New TableRow
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = "Chỉ dẫn đầu biểu ghi"
            lblTemp.CssClass = "lbLabel"
            tblCell.Controls.Add(lblTemp)
            tblCell.ColumnSpan = intCols
            tblLeaderRow.Cells.Add(tblCell)
            tblLeaderRow.BackColor = Color.FromName("#FDFDC9")
            tblRows(0) = tblLeaderRow

            tblLeaderRow = New TableRow
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(6) ' FieldCode
            tblLeaderRow.Cells.Add(tblCell)
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(6) ' Indicators
            tblLeaderRow.Cells.Add(tblCell)
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(88) ' Textbox for input data
            txbTemp = New TextBox
            txbTemp.CssClass = "lbTextbox"
            txbTemp.ID = "txtLeader"
            txbTemp.ClientIDMode = UI.ClientIDMode.Static
            txbTemp.Width = Unit.Percentage(100)
            txbTemp.Enabled = False
            txbTemp.Attributes.Add("OnChange", "parent.Sentform.document.forms[0].txtLeader.value = this.value")
            txbTemp.Attributes.Add("OnFocus", "this.blur()")
            tblCell.Controls.Add(txbTemp)
            tblLeaderRow.Cells.Add(tblCell)
            tblRows(1) = tblLeaderRow

            ' Show links for this field
            tblLeaderRow = New TableRow
            tblCell = New TableCell
            lnkTemp = New HyperLink
            tblCell.ColumnSpan = 2
            tblLeaderRow.Cells.Add(tblCell)
            tblCell = New TableCell
            lnkTemp.CssClass = "lbLinkFunction"
            lnkTemp.Text = ddlLabel.Items(13).Text
            lnkTemp.NavigateUrl = "JavaScript:PopUpLeaderHelp(" & Session("IsAuthority") & ")"
            tblCell.Controls.Add(lnkTemp)
            tblLeaderRow.Cells.Add(tblCell)
            tblRows(2) = tblLeaderRow

            Return tblRows
        End Function

        ''' <summary>
        ''' </summary>
        Private Function GetCataFields(ByVal intGroupBy As Integer, ByVal intFormID As Integer, ByVal strFieldCodes As String, ByVal strAddedFieldCodes As String,
                                  ByRef tblCataFunctions As DataTable, ByRef tblCataBlocks As DataTable, ByRef tblCataFields As DataTable
                                  ) As Integer
            Dim intNumberOfCataFields As Integer = 0
            ' Get all functions of all marc fields
            tblCataFunctions = objBCatalogueForm.RetrieveMarcFunctions()
            tblCataBlocks = objBCatalogueForm.GetBlockFields

            'Get Cata Fields
            objBCatalogueForm.GroupBy = intGroupBy
            objBCatalogueForm.FormID = intFormID
            objBCatalogueForm.FieldCodes = Trim(strFieldCodes)
            objBCatalogueForm.AddedFieldCodes = Trim(strAddedFieldCodes)
            tblCataFields = objBCatalogueForm.GetCatalogueFields
            If Not tblCataFields Is Nothing Then
                intNumberOfCataFields = tblCataFields.Rows.Count
            End If

            Return intNumberOfCataFields
        End Function

        ''' <summary>
        ''' Check Any Field Code that can render by TextArea.
        ''' </summary>
        ''' <param name="intFormID"></param>
        ''' <returns></returns>
        Private Function GetFieldCodesWithRenderByTextArea(ByVal intFormID As Integer) As String
            'Statefull object so so dangerous.
            objBForm.FormID = intFormID
            Dim tblTextAreaFields As DataTable = objBForm.GetTextAreaFields
            Dim strResult As String = ""

            'Some Statements use 'And' operator instead of 'AndAlso', this is a big mistake although it procduces same result but if you look carefully there's a bug.
            If tblTextAreaFields IsNot Nothing AndAlso tblTextAreaFields.Rows.Count > 0 Then
                'Mutable string is good than immuatable string.
                Dim strFieldsWithTextAreaRender As New StringBuilder(1024)
                For intCounter = 0 To tblTextAreaFields.Rows.Count - 1
                    strFieldsWithTextAreaRender.Append(tblTextAreaFields.Rows(intCounter).Item("FieldCode")).Append(",")
                Next
                strResult = strFieldsWithTextAreaRender.ToString()
            End If

            'Single terminated statement is a good code.
            Return strResult
        End Function

        ''' <summary>
        ''' Use javascript to restore all field's value.
        ''' Note that with fieldcode='245$b' we have special handle.
        ''' Pipeline -> match -> next
        ''' </summary>
        ''' <param name="intNumberOfCataFields">Number of cata field use to create ArrFieldCode</param>
        ''' <param name="tblCataFields"></param>
        ''' <returns></returns>
        Private Function CreateClientJavascriptStoresForFieldCodes(ByVal intNumberOfCataFields As Integer, ByVal tblCataFields As DataTable) As String
            Dim strJavascript As String = ""
            If intNumberOfCataFields > 0 Then
                Dim sb As New StringBuilder(2048)
                sb.Append("var curtab = 0;").Append(Chr(13)).
                    Append("var TagArr = [];").Append(Chr(13)).
                    AppendFormat("var intUtf = {0};", CStr(intUTF)).Append(Chr(13)).
                    Append("var ArrFieldCode = [];").Append(Chr(13)).
                    Append("var ArrFieldRep =[];").Append(Chr(13))

                For intCounter = 0 To intNumberOfCataFields - 1
                    Dim fieldCode As String = tblCataFields.Rows(intCounter).Item("FieldCode").ToString()
                    Dim isRepeatable As Boolean = If(CInt(tblCataFields.Rows(intCounter).Item("Repeatable")) = 0, True, False)
                    If isRepeatable Then
                        sb.Append("ArrFieldRep.push(0);").Append(Chr(13))
                    Else
                        sb.Append("ArrFieldRep.push(1);").Append(Chr(13))
                    End If
                    sb.AppendFormat("ArrFieldCode.push('{0}');", fieldCode).Append(Chr(13))
                Next
                strJavascript = sb.ToString()
            End If
            Return strJavascript
        End Function

        Private Sub initUploadfiles()
            Try
                If Not IsNothing(Session("uploadFiles")) Then
                    If Not IsNothing(Request("FileIds")) AndAlso Request("FileIds") = "1" Then
                        'Giu lai file vi duoc attach file tu lieu so.
                    Else
                        Session("uploadFiles") = Nothing
                    End If
                End If
                If Not IsNothing(Session("imageCover")) Then
                    Session("imageCover") = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub


        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Sub removeFileCallbackk(ByVal _item As Integer)
            Try
                If Not Session("uploadFiles") Is Nothing Then
                    Dim _iUbound As Integer = UBound(Session("uploadFiles"), 2)

                    'Chieu mang UI nguoc voi chieu session
                    'UI 0   1   2   3
                    '   A1  A2  A3  A4
                    'Se 0   1   2   3
                    '   A4  A3  A2  A1
                    _item = _iUbound - _item
                    For _icount As Integer = _item To _iUbound - 1
                        Session("uploadFiles")(0, _icount) = Session("uploadFiles")(0, _icount + 1)
                        Session("uploadFiles")(1, _icount) = Session("uploadFiles")(1, _icount + 1)
                        Session("uploadFiles")(2, _icount) = Session("uploadFiles")(2, _icount + 1)
                    Next
                    If _iUbound > -1 Then
                        _iUbound -= 1
                        ReDim Preserve Session("uploadFiles")(2, _iUbound)
                    Else
                        Session("uploadFiles") = Nothing
                    End If
                End If
            Catch ex As Exception : End Try
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCatalogueForm Is Nothing Then
                    objBCatalogueForm.Dispose(True)
                    objBCatalogueForm = Nothing
                End If
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
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
    End Class
End Namespace