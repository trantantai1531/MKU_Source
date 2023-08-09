' WMarcFieldModify class
' Purpose: modify user defined fields
' Creator: Oanhtn
' CreatedDate: 11/05/2004
' Modification history 
'   - 22/02/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldModify
        Inherits clsWBase

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

        Private objBField As New clsBField
        Private objBEData As New clsBEData
        Private intUTF As Integer = 0

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            ' Update this field
            If Not Trim(txtFieldCode.Text) = "" Then
                Call UpdateMarcField()
            End If
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBField object
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            Call objBField.Initialize()

            ' Init objBEData object
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            Call objBEData.Initialize()

            ' UTF
            If UCase(Session("InterfaceLanguage")) = "UNICODE" Then
                intUTF = 1
            End If
        End Sub

        ' BindData method
        ' Purpose: bind data for all necessary controls
        Private Sub BindData()
            Dim strFieldCode As String = Trim(Request("FieldCode"))
            Dim strSelect As String = "---------- " & ddlLabel.Items(0).Text & " ---------- "
            Dim tblData As New DataTable

            ' Get MarcFieldTypes
            tblData = objBField.RetrieveMarcFieldTypes
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlMarcFieldTypes.DataSource = tblData
                ddlMarcFieldTypes.DataTextField = "FieldType"
                ddlMarcFieldTypes.DataValueField = "ID"
                ddlMarcFieldTypes.DataBind()
                tblData.Clear()
            End If

            ' Get MarcFunctions
            tblData = objBField.RetrieveMarcFunctions
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlMarcFunctions.DataSource = tblData
                ddlMarcFunctions.DataTextField = "FieldFunction"
                ddlMarcFunctions.DataValueField = "ID"
                ddlMarcFunctions.DataBind()
                tblData.Clear()
            End If

            ' Get AuthorityControl
            tblData = objBField.RetrieveCatDicList
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlAuthorityControl.DataSource = InsertOneRow(tblData, strSelect)
                ddlAuthorityControl.DataTextField = "Name"
                ddlAuthorityControl.DataValueField = "ID"
                ddlAuthorityControl.DataBind()
                tblData.Clear()
            End If

            ' Call hiddenbase
            If Not strFieldCode = "" Then
                Page.RegisterClientScriptBlock("CallHiddenbase", "<script language = 'javascript'>parent.Hiddenbase.location.href='WMarcFieldLoad.aspx?FieldCode=" & strFieldCode & "';</script>")
            End If

            ' Load hidden controls
            'If Trim(ddlMarcFieldTypes.SelectedItem.Text).ToLower = "Attached File".ToLower Then
            objBEData.FieldCode = strFieldCode
            tblData = objBEData.GetEDataParams
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                If Not IsDBNull(tblData.Rows(0).Item("FieldCode")) Then
                    txtFieldCode.Text = tblData.Rows(0).Item("FieldCode")
                End If
                If Not IsDBNull(tblData.Rows(0).Item("PhysicalPath")) Then
                    txtPhysicalPath.Value = tblData.Rows(0).Item("PhysicalPath")
                End If
                If Not IsDBNull(tblData.Rows(0).Item("AllowedFileExt")) Then
                    txtAllowedFileExt.Value = tblData.Rows(0).Item("AllowedFileExt")
                End If
                If Not IsDBNull(tblData.Rows(0).Item("DeniedFileExt")) Then
                    txtDeniedFileExt.Value = tblData.Rows(0).Item("DeniedFileExt")
                End If
                If Not IsDBNull(tblData.Rows(0).Item("Logo")) Then
                    txtLogo.Value = tblData.Rows(0).Item("Logo")
                End If
                If Not IsDBNull(tblData.Rows(0).Item("Prefix")) Then
                    txtPrefix.Value = tblData.Rows(0).Item("Prefix")
                End If
                If Not IsDBNull(tblData.Rows(0).Item("MaxSize")) Then
                    txtMaxsize.Value = tblData.Rows(0).Item("MaxSize")
                End If
                If Not IsDBNull(tblData.Rows(0).Item("URL")) Then
                    txtURL.Value = tblData.Rows(0).Item("URL")
                End If
            End If
            ' End If

            ' Release objects
            tblData.Dispose()
            tblData = Nothing
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Dim strMess1 As String = ddlLabel.Items(1).Text
            Dim strMess2 As String = ddlLabel.Items(2).Text
            Dim strMess3 As String = ddlLabel.Items(3).Text

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcFieldModifyJs", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcFieldModify.js'></script>")

            txtFieldCode.Attributes.Add("OnChange", "javascript:if (CheckNull(this)) {alert('" & ddlLabel.Items(6).Text & "');} else {parent.Hiddenbase.location.href='WMarcFieldLoad.aspx?FieldCode=' + Esc(this.value, " & intUTF & ");}")
            Me.SetCheckNumber(txtLength, ddlLabel.Items(9).Text)

            btnConfigureAttachDataField.Attributes.Add("OnClick", "javascript:ConfigureAttachDataField('" & strMess3 & "'); return false;")

            ddlMarcFieldTypes.Attributes.Add("OnFocus", "javascript:intType = this.selectedIndex;")
            ddlMarcFieldTypes.Attributes.Add("OnChange", "javascript:if((document.forms[0].txtFieldCode.value.substring(0,3) != '956') && (document.forms[0].txtFieldCode.value.substring(0,3) != '856') && (this.value == 4)) {alert('" & strMess2 & "'); this.selectedIndex = intType} else { if (! confirm('" & strMess1 & "')) {this.selectedIndex = intType;}}")
            ddlAuthorityControl.Attributes.Add("OnFocus", "javascript:intDicID = this.selectedIndex;")
            ddlAuthorityControl.Attributes.Add("OnChange", "javascript:if (! confirm('" & strMess1 & "')) {this.selectedIndex = intDicID;}")

            'Phuong 
            'Modify 20080802
            Dim strFieldCode As String = Trim(Request("FieldCode"))

            lnkCreate.NavigateUrl = "javascript:location.href='WMarcFieldCreate.aspx?FieldCode=" & strFieldCode & "'; parent.Sentform.location.href='WMarcFieldSend.aspx?FieldCode=0'"
            'Modify 20080802
        End Sub

        ' UpdateMarcField method
        ' Purpose: update the selected field in MARC_BIB_FIELD table
        Private Sub UpdateMarcField()
            Dim strMess1 As String = ddlLabel.Items(4).Text
            Dim strMess2 As String = ddlLabel.Items(5).Text
            Dim intDicID As Integer = 0

            objBField.FieldCode = txtFieldCode.Text.Trim
            objBField.FieldName = Replace(txtFieldName.Text.Trim, "'", "''")
            objBField.VietFieldName = Replace(txtVietFieldName.Text.Trim, "'", "''")
            objBField.Indicators = Replace(txtIndicators.Text.Trim, "'", "''")
            objBField.VietIndicators = Replace(txtVietIndicators.Text.Trim, "'", "''")
            If chkRepeatable.Checked Then
                objBField.Repeatable = 1
            End If
            If chkMandatory.Checked Then
                objBField.Mandatory = 1
            End If
            objBField.Length = CInt(txtLength.Text.Trim)
            objBField.Description = Replace(txtDescription.Text.Trim, "'", "''")
            If Not txtLinkTypeID.Value = "" Then
                objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
            End If
            objBField.FunctionID = ddlMarcFunctions.SelectedValue
            objBField.FieldTypeID = ddlMarcFieldTypes.SelectedValue
            If IsNumeric(ddlAuthorityControl.SelectedValue) Then
                intDicID = ddlAuthorityControl.SelectedValue
            End If
            objBField.DicID = intDicID

            ' Update
            Call objBField.Modify()

            ' Write log
            Call WriteLog(24, ddlLabel.Items(4).Text & ": " & Trim(txtFieldCode.Text), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            ' Or Left(Trim(txtFieldCode.Text), 3) = "901" Or (Left(Trim(txtFieldCode.Text), 3) = "907") Or (Left(Trim(txtFieldCode.Text), 3) = "903")
            If Trim(ddlMarcFieldTypes.SelectedItem.Text).ToLower = "Attached File".ToLower Then
                objBEData.PhysicalPath = txtPhysicalPath.Value.Trim
                objBEData.AllowedFileExt = txtAllowedFileExt.Value.Trim
                objBEData.DeniedFileExt = txtDeniedFileExt.Value.Trim
                objBEData.Logo = txtLogo.Value.Trim
                objBEData.Prefix = txtPrefix.Value.Trim
                objBEData.FieldCode = txtFieldCode.Text.Trim
                objBEData.Maxsize = txtMaxsize.Value.Trim
                objBEData.URL = txtURL.Value
                ' Insert new record into edataparameter table
                If Not txtFunctionID.Value = ddlMarcFieldTypes.SelectedValue Then
                    If CInt(txtFunctionID.Value) = 4 Then
                        Call objBEData.Delete()
                    End If
                    If ddlMarcFieldTypes.SelectedValue = 4 Then
                        'Call objBEData.Add()
                        Call objBEData.Modify()
                    End If
                ElseIf CInt(txtFunctionID.Value) = 4 Then ' Update current record of edataparameter table
                    Call objBEData.Modify()
                End If
            End If

            Page.RegisterClientScriptBlock("UpdateSuccessful", "<script language = 'javascript'>alert('" & strMess1 & " " & txtFieldCode.Text & " " & strMess2 & "');</script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
                If Not objBField Is Nothing Then
                    objBField.Dispose(True)
                    objBField = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace