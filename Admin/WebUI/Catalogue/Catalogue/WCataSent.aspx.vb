' WCataSent class
' Purpose: Prepare for catalogue form
' Creator: Oanhtn
' CreatedDate: 13/05/2004
' Modification history:
'   - 26/02/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataSent
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents tag900 As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBCSP As New clsBCommonStringProc
        Private bolFileIds856 As Boolean = False

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Page.IsPostBack Then
                Me.SetResourceForControls()
            End If
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            Call LoadData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBCatalogueForm object
            objBCatalogueForm.IsAuthority = CInt(Session("IsAuthority"))
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()

            ' Init objBCSP
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Session("IsAuthority") = 0 Then 'Thu muc
                If Not CheckPemission(2) Then
                    btnUpdate.Enabled = False
                End If
            Else 'Tu chuan
                If Not CheckPemission(141) Then
                    btnUpdate.Enabled = False
                End If
            End If
        End Sub

        ' BindJS method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script type = 'text/javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "WCataSentJs", "<script type = 'text/javascript' src = '../Js/Catalogue/WCataSent.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)
        End Sub

        ' LoadData method
        ' Purpose: Load data into hidden controls
        Private Sub LoadData()
            ' Declare variables 
            Dim strLeader As String
            Dim intFormID As Integer
            Dim strModule As String = Trim(txtModule.Value)
            Dim strAddedFieldCodes As String = Trim(txtAddedFieldCodes.Value)
            Dim strModifiedFieldCodes As String = Trim(txtModifiedFieldCodes.Value)
            Dim strFieldCodes As String = ""
            Dim intCount As Integer
            Dim blnMandatory As Boolean
            Dim strPreviewJS As String = "" ' store information to preview
            Dim strJavascript As String = ""
            Dim strCheckAllJS As String = "" ' create CheckAll Js functions to check null value of all field' value
            Dim strPresetValue As String = ""
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim hidField As HtmlControls.HtmlInputHidden
            Dim tblDefaultValue As DataTable
            Dim tblFields As DataTable
            Dim tblRepeatableFields As New DataTable
            Dim strPrefix As String = ""
            Dim dtrow() As DataRow
            Dim bolAuthority As Boolean = False

            If Not IsNothing(Request("FileIds")) AndAlso Request("FileIds") <> "" Then
                bolFileIds856 = True
            Else
                bolFileIds856 = False
            End If


            If Request("Holdings") = 1 Then
                strCheckAllJS = ""
                strCheckAllJS = strCheckAllJS & "parent.Workform.focus();" & Chr(10)
                strCheckAllJS = strCheckAllJS & "self.focus();" & Chr(10)
                lblMyJS.Text = "<script language='javascript'>" & strCheckAllJS & Chr(10) & "parent.Workform.location.href = 'WCopyNumber.aspx?FormID=" & "" & Trim(txtFormID.Value) & "&Module=" & "" & Trim(txtModule.Value) & "&AddedFieldCodes=" & "" & Trim(txtAddedFieldCodes.Value) & "';</script>"

            Else
                Session("911") = clsSession.GlbUserFullName
                Session("a911") = clsSession.GlbUserFullName
                Session("040") = "::$a" & Me.getLibraryCode() ' "$aUEFL"
                Session("041") = "::$avie" '"$avie"
                Session("925") = "G"
                Session("926") = "0"
                Session("927") = "SH"
                If bolFileIds856 Then
                    Session("856") = getFileIds()
                Else
                    Session("856") = ""
                End If

                If Session("IsAuthority") = 1 Then
                    strPrefix = "a"
                    bolAuthority = True

                    IsAuthority.Value = 1
                Else
                    IsAuthority.Value = 0
                End If
                ' Load some labelstring to display in javascript
                strPreviewJS = strPreviewJS & "var strLabel5 = '" & ddlLabel.Items(0).Text & "';"
                strPreviewJS = strPreviewJS & "var strLabel6 = '" & ddlLabel.Items(1).Text & "';"
                strPreviewJS = strPreviewJS & "var strLabel10 = '" & ddlLabel.Items(2).Text & "';"

                ' Load value of necessary controls
                If Not txtLeader.Value = "" Then ' from catalogue form
                    strLeader = txtLeader.Value
                Else
                    If Session("IsAuthority") = 1 Then
                        strLeader = "00142az  22000061   4500"
                    Else
                        strLeader = "00025nam a22      p 4500"
                    End If
                    'strLeader = "00025nam a22      p 4500"
                End If

                If Not Request("lstMarcForm") = "" Then
                    txtFormID.Value = Request("lstMarcForm")
                End If
                If Not Request("FormID") = "" Then
                    txtFormID.Value = Request("FormID")
                End If
                intFormID = CInt(txtFormID.Value)

                ' Get default value from database (by form id)
                objBCatalogueForm.FormID = intFormID
                objBCatalogueForm.Creator = clsSession.GlbUserFullName
                tblDefaultValue = objBCatalogueForm.GetFields
                txtLeader.Value = strLeader
                txtModule.Value = strModule
                txtAddedFieldCodes.Value = strAddedFieldCodes
                txtModifiedFieldCodes.Value = strModifiedFieldCodes
                txtFieldCodes.Value = ""

                ' Get all fields need for catalogue
                objBCatalogueForm.FormID = intFormID
                objBCatalogueForm.AddedFieldCodes = strAddedFieldCodes
                tblFields = objBCatalogueForm.GetCatalogueFields
                If Not tblFields Is Nothing Then
                    total.Value = tblFields.Rows.Count + 1
                Else
                    total.Value = 0
                End If
                ' Process
                If Not tblFields Is Nothing Then
                    If Not tblFields.Rows.Count = 0 Then
                        strPreviewJS = strPreviewJS & "varStyleStheet = '" & String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", Me.GetStyleSheetURL("Catalogue")) & "';" & Chr(13)
                        strPreviewJS = strPreviewJS & "var arrFieldCode = new Array(" & tblFields.Rows.Count + 1 & ");" & Chr(13)
                        strPreviewJS = strPreviewJS & "var arrFieldValue = new Array(" & tblFields.Rows.Count + 1 & ");" & Chr(13)

                        For intCount = 0 To tblFields.Rows.Count - 1
                            ' Check mandatory fields
                            blnMandatory = False
                            If Not IsDBNull(tblFields.Rows(intCount).Item("Mandatory")) Then
                                If CBool(tblFields.Rows(intCount).Item("Mandatory")) Then
                                    blnMandatory = True
                                End If
                            End If
                            If Not IsDBNull(tblFields.Rows(intCount).Item("AlwaysMandatory")) And Not blnMandatory Then
                                If CBool(tblFields.Rows(intCount).Item("AlwaysMandatory")) Then
                                    blnMandatory = True
                                End If
                            End If

                            If blnMandatory Then
                                If Not IsDBNull(tblFields.Rows(intCount).Item("ParentFieldCode")) Then
                                    If Not IsDBNull(tblFields.Rows(intCount).Item("Repeatable")) Then
                                        If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                                            strJavascript = strJavascript & "if (CheckNullValue(document.forms[0].tag" & tblFields.Rows(intCount).Item("FieldCode") & ", '" & tblFields.Rows(intCount).Item("FieldCode") & "--" & tblFields.Rows(intCount).Item("VietFieldName") & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "')) {return false;}" & Chr(13)
                                        Else
                                            strJavascript = strJavascript & "if (CheckNullValue(document.forms[0].tag" & tblFields.Rows(intCount).Item("FieldCode") & ", '" & tblFields.Rows(intCount).Item("FieldCode") & "--" & Replace(tblFields.Rows(intCount).Item("FieldName"), "'", "\'") & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "')) {return false;}" & Chr(13)
                                        End If
                                    End If
                                Else
                                    If Not UCase(Session("InterfaceLanguage")) = "ENGLISH" Then
                                        strJavascript = strJavascript & "if (CheckNullValue(document.forms[0].tag" & tblFields.Rows(intCount).Item("FieldCode") & ", '" & tblFields.Rows(intCount).Item("FieldCode") & "--" & tblFields.Rows(intCount).Item("VietFieldName") & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "')) {return false;}" & Chr(13)
                                    Else
                                        strJavascript = strJavascript & "if (CheckNullValue(document.forms[0].tag" & tblFields.Rows(intCount).Item("FieldCode") & ", '" & tblFields.Rows(intCount).Item("FieldCode") & "--" & Replace(tblFields.Rows(intCount).Item("FieldName"), "'", "\'") & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "')) {return false;}" & Chr(13)
                                    End If
                                End If
                            End If

                            ' Create hidden fields
                            If Request("tag" & tblFields.Rows(intCount).Item("FieldCode")) <> "" Then
                                ' New row
                                Try
                                    tblRow = New TableRow
                                    tblCell = New TableCell
                                    hidField = New HtmlControls.HtmlInputHidden
                                    hidField.ID = "tag" & tblFields.Rows(intCount).Item("FieldCode")
                                    hidField.ClientIDMode = UI.ClientIDMode.Static
                                    hidField.Value = strPresetValue
                                    tblCell.Controls.Add(hidField)
                                    tblRow.Cells.Add(tblCell)
                                    tblHiddenFields.Rows.Add(tblRow)
                                Catch ex As Exception
                                End Try
                            Else
                                strPresetValue = ""
                                'If Session(strPrefix & tblFields.Rows(intCount).Item("FieldCode")) = "" Then
                                If Session(strPrefix & objBCSP.getParentField(tblFields.Rows(intCount).Item("FieldCode"))) = "" Then
                                    Select Case tblFields.Rows(intCount).Item("FieldCode")
                                        Case "005"
                                            strPresetValue = CStr(Year(Now)) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & CStr(Hour(Now)).PadLeft(3 - Len(CStr(Hour(Now))), "0") & CStr(Minute(Now)).PadLeft(3 - Len(CStr(Minute(Now))), "0") & CStr(Second(Now)).PadLeft(3 - Len(CStr(Second(Now))), "0") & ".0"
                                        Case "008"
                                            Dim strRecordType As String = Mid(strLeader, 6, 1)
                                            Dim strDirLevel As String = Mid(strLeader, 7, 1)
                                            Select Case strRecordType
                                                Case "m"
                                                    strPresetValue = Right(CStr(Year(Now)), 2) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & "s        vm         b        vie d"
                                                Case "e", "f"
                                                    strPresetValue = Right(CStr(Year(Now)), 2) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & "s        vm        a     0   vie d"
                                                Case "i", "j"
                                                    strPresetValue = Right(CStr(Year(Now)), 2) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & "s        vm uuu              vie d"
                                                Case "g", "h"
                                                    strPresetValue = Right(CStr(Year(Now)), 2) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & "s        vm ---            zzvie d"
                                                Case "o", "p", "r"
                                                    strPresetValue = Right(CStr(Year(Now)), 2) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & "s        vm                  vie d"
                                                Case Else
                                                    If strDirLevel = "s" Then
                                                        strPresetValue = Right(CStr(Year(Now)), 2) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & "c        vm  x ||||  |||   ||vie u"
                                                    Else
                                                        strPresetValue = Right(CStr(Year(Now)), 2) & CStr(Month(Now)).PadLeft(3 - Len(CStr(Month(Now))), "0") & CStr(Day(Now)).PadLeft(3 - Len(CStr(Day(Now))), "0") & "s        vm    a       000 0 vie d"
                                                    End If
                                            End Select
                                    End Select
                                Else
                                    strPresetValue = Session(strPrefix & objBCSP.getParentField(tblFields.Rows(intCount).Item("FieldCode")))
                                    If strPresetValue <> "" AndAlso tblFields.Rows(intCount).Item("FieldCode") <> "856$f" Then
                                        strPresetValue = objBCSP.getValSubFieldMARC(tblFields.Rows(intCount).Item("FieldCode"), strPresetValue)
                                        If InStr(tblFields.Rows(intCount).Item("FieldCode"), "$a") > 0 Then
                                            strPresetValue = "::" & strPresetValue
                                        End If
                                    End If
                                End If

                                ' Get default value from database if session is nothing
                                If strPresetValue = "" Then
                                    dtrow = tblDefaultValue.Select("FieldCode = '" & tblFields.Rows(intCount).Item("FieldCode") & "'")
                                    If dtrow.Length > 0 Then
                                        If Not IsDBNull(tblFields.Rows(intCount).Item("Indicators")) Or Not IsDBNull(tblFields.Rows(intCount).Item("VietIndicators")) Then
                                            If Not IsDBNull(dtrow(0).Item("DefaultIndicators")) Then
                                                strPresetValue = dtrow(0).Item("DefaultIndicators") & "::" & dtrow(0).Item("DefaultValue")
                                            Else
                                                If Not IsDBNull(dtrow(0).Item("DefaultValue")) Then
                                                    strPresetValue = dtrow(0).Item("DefaultValue")
                                                End If
                                            End If
                                        Else
                                            If Not IsDBNull(dtrow(0).Item("DefaultValue")) Then
                                                strPresetValue = dtrow(0).Item("DefaultValue")
                                            End If
                                        End If
                                    End If
                                    tblDefaultValue.Select()
                                End If

                                ' New row
                                Try
                                    tblRow = New TableRow
                                    tblCell = New TableCell
                                    hidField = New HtmlControls.HtmlInputHidden
                                    hidField.ID = "tag" & tblFields.Rows(intCount).Item("FieldCode")
                                    hidField.ClientIDMode = UI.ClientIDMode.Static
                                    If ("tag" & tblFields.Rows(intCount).Item("FieldCode")) = "tag852$t" Then
                                        hidField.Value = "0"
                                    Else
                                        hidField.Value = strPresetValue
                                    End If
                                    tblCell.Controls.Add(hidField)
                                    tblRow.Cells.Add(tblCell)
                                    tblHiddenFields.Rows.Add(tblRow)
                                Catch ex As Exception
                                End Try
                            End If
                            strPreviewJS = strPreviewJS & "arrFieldCode[" & intCount + 1 & "] = '" & tblFields.Rows(intCount).Item("FieldCode") & "';" & Chr(13)
                            strFieldCodes = strFieldCodes & tblFields.Rows(intCount).Item("FieldCode") & ","
                        Next
                    End If
                End If
                'If bolAuthority Or strFieldCodes.IndexOf("900") = -1 Then
                If strFieldCodes.IndexOf("900") = -1 Then
                    tblRow = New TableRow
                    tblCell = New TableCell
                    hidField = New HtmlControls.HtmlInputHidden
                    hidField.ID = "tag" & "900"
                    hidField.ClientIDMode = UI.ClientIDMode.Static
                    hidField.Value = 1
                    tblCell.Controls.Add(hidField)
                    tblRow.Cells.Add(tblCell)
                    tblHiddenFields.Rows.Add(tblRow)
                    If CInt(Session("IsAuthority")) <> 1 Then
                        strPreviewJS = strPreviewJS & "arrFieldCode[" & intCount + 1 & "] = '" & "900" & "';" & Chr(13)
                        strFieldCodes = strFieldCodes & "900" & ","
                    End If
                End If
                ' Display some hiddenfields (mandatory fields)
                txtFieldCodes.Value = strFieldCodes
                Session("FieldCodes") = strFieldCodes
                ' Create CheckAll Js functions to check null value of all field' value
                strCheckAllJS = strCheckAllJS & "function CheckAll() {" & Chr(10)
                strCheckAllJS = strCheckAllJS & "parent.Workform.focus();" & Chr(10)
                strCheckAllJS = strCheckAllJS & "self.focus();" & Chr(10)
                strCheckAllJS = strCheckAllJS & strJavascript
                strCheckAllJS = strCheckAllJS & "ValidateMARC(1, 0);" & Chr(10)
                strCheckAllJS = strCheckAllJS & "}"
                ' Create CheckAll Js functions to check null value of all field's value but not submit
                Dim strCheckAll1JS As String = ""
                strCheckAll1JS = strCheckAll1JS & "function CheckAll1() {" & Chr(10)
                strCheckAll1JS = strCheckAll1JS & "parent.Workform.focus();" & Chr(10)
                strCheckAll1JS = strCheckAll1JS & "self.focus();" & Chr(10)
                strCheckAll1JS = strCheckAll1JS & strJavascript
                strCheckAll1JS = strCheckAll1JS & "ValidateMARC(0, 0);" & Chr(10)
                strCheckAll1JS = strCheckAll1JS & "}"


                Dim intFileIds As Integer = 0 'Nhan file tu tai nguyen so
                If bolFileIds856 Then
                    intFileIds = 1
                End If

                ' Display catalogue form in Workform frame
                lblMyJS.Text = "<script language='javascript'>" & strCheckAllJS & Chr(10) & strCheckAll1JS & Chr(10) & "parent.Workform.location.href = 'WCata.aspx?FileIds=" & intFileIds & "&FormID=" & "" & Trim(txtFormID.Value) & "&Module=" & "" & Trim(txtModule.Value) & "&AddedFieldCodes=" & "" & Trim(txtAddedFieldCodes.Value) & "';</script>"

                ' For preview window
                ClientScript.RegisterClientScriptBlock(Me.GetType(), "PreviewJS", strPreviewJS, True)

                ' Write event for all button on this form
                btnUpdate.Attributes.Add("OnClick", "CheckAll('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(4).Text & "'); return false;")
                btnPreview.Attributes.Add("OnClick", "Preview(); return false;")
                btnReset.Attributes.Add("OnClick", "ResetForm('" & ddlLabel.Items(7).Text & "');return false;")
                btnValidate.Attributes.Add("OnClick", "CheckAll1('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(4).Text & "'); return false;")
                btnAddFields.Attributes.Add("OnClick", "AddFields(); return false;")
                btnSpellCheck.Attributes.Add("OnClick", "SpellCheck(); return false;")
            End If

        End Sub

        Private Function getFileIds() As String
            Dim strResult As String = ""
            Try
                If Not Session("uploadFiles") Is Nothing Then
                    Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2)
                    For _icount As Integer = 0 To _icountArr
                        strResult &= Session("uploadFiles")(1, _icount) & "$&"
                    Next
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

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