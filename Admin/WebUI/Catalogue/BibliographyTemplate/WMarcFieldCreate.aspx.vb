' WMarcFieldModify class
' Purpose: modify user defined fields
' Creator: Oanhtn
' CreatedDate: 13/05/2004
' Modification history
'   - 22/02/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldCreate
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
            Call BindJavascripts()
            ' Insert new field
            If Not Trim(txtFieldCode.Text) = "" Then
                Call CreateMarcField()
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

            If UCase(Session("InterfaceLanguage")) = "UNICODE" Then
                intUTF = 1
            End If
        End Sub

        ' BindJavascripts method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJavascripts()
            Dim strMess2 As String = ddlLabel.Items(2).Text
            Dim strMess3 As String = ddlLabel.Items(1).Text
            Dim strMess4 As String = ddlLabel.Items(3).Text

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcFieldCreateJs", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcFieldCreate.js'></script>")

            txtFieldCode.Attributes.Add("OnChange", "javascript:CheckUniqueField(" & intUTF & ", '" & strMess4 & "');")
            Me.SetCheckNumber(txtLength, ddlLabel.Items(8).Text)


            btnConfigureAttachDataField.Attributes.Add("OnClick", "javascript:ConfigureAttachDataField('" & strMess3 & "'); return false;")

            ddlMarcFieldTypes.Attributes.Add("OnFocus", "javascript:intType = this.selectedIndex;")
            ddlMarcFieldTypes.Attributes.Add("OnChange", "javascript:if(CheckNull(document.forms[0].txtFieldCode)) {alert('" & strMess4 & "'); this.selectedIndex = 0;} else { if (document.forms[0].txtFieldCode.value.indexOf('$') >= 0) { parent.Hiddenbase.location.href='WCheckAttachField.aspx?FieldCode=' + document.forms[0].txtFieldCode.value + '&TypeID=' + this.options[this.options.selectedIndex].value; }}")

            'Phuong 
            'Modify 20080802
            Dim strFieldCode As String = Trim(Request("FieldCode"))

            lnkModify.NavigateUrl = "javascript:location.href='WMarcFieldModify.aspx?FieldCode=" & strFieldCode & "'; parent.Sentform.location.href='WMarcFieldSend.aspx'"
            'Modify 20080802
        End Sub

        ' BindData method
        ' Purpose: bind data for all necessary controls
        Private Sub BindData()
            Dim tblData As DataTable
            Dim strSelect As String = "---------- " & ddlLabel.Items(0).Text & " ---------- "

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
            End If

            ' Get AuthorityControl
            tblData = objBField.RetrieveCatDicList
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlAuthorityControl.DataSource = InsertOneRow(tblData, strSelect)
                ddlAuthorityControl.DataTextField = "Name"
                ddlAuthorityControl.DataValueField = "ID"
                ddlAuthorityControl.DataBind()
            End If
        End Sub

        ' InsertMarcField method
        ' Purpose: insert new field into MARC_BIB_FIELD table
        Private Sub CreateMarcField()
            Dim strFieldCode As String = txtFieldCode.Text.Trim
            Dim strMess1 As String = ddlLabel.Items(4).Text
            Dim strMess2 As String = ddlLabel.Items(5).Text
            Dim intDicID As Integer = 0
            Dim intFunctionID As Integer = 0
            Dim intFieldTypeID As Integer = 0
            Dim intRetVal As Integer = 0

            objBField.FieldCode = strFieldCode.Trim
            objBField.FieldName = txtFieldName.Text.Trim
            objBField.VietFieldName = txtVietFieldName.Text.Trim
            objBField.Indicators = txtIndicators.Text.Trim
            objBField.VietIndicators = txtVietIndicators.Text.Trim

            If chkRepeatable.Checked Then
                objBField.Repeatable = 1
            End If
            If chkMandatory.Checked Then
                objBField.Mandatory = 1
            End If
            objBField.Length = CInt(txtLength.Text.Trim)
            objBField.Description = txtDescription.Text.Trim
            If Not txtLinkTypeID.Value = "" Then
                objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
            End If
            If IsNumeric(ddlMarcFunctions.SelectedValue) Then
                intFunctionID = ddlMarcFunctions.SelectedValue
            End If
            If IsNumeric(ddlMarcFieldTypes.SelectedValue) Then
                intFieldTypeID = ddlMarcFieldTypes.SelectedValue
            End If
            If IsNumeric(ddlAuthorityControl.SelectedValue) Then
                intDicID = ddlAuthorityControl.SelectedValue
            End If
            objBField.FunctionID = ddlMarcFunctions.SelectedValue
            objBField.FieldTypeID = intFieldTypeID
            objBField.DicID = intDicID

            ' Insert new field
            intRetVal = objBField.Create()
            If intRetVal > 0 Then
                Select Case ddlMarcFieldTypes.SelectedValue
                    Case 4 ' Attach
                        objBEData.FieldCode = strFieldCode
                        If Not Trim(txtPhysicalPath.Value) = "" Then
                            objBEData.PhysicalPath = txtPhysicalPath.Value
                            objBEData.AllowedFileExt = txtAllowedFileExt.Value
                            objBEData.DeniedFileExt = txtDeniedFileExt.Value
                            objBEData.Logo = txtLogo.Value
                            objBEData.Prefix = txtPrefix.Value
                            objBEData.Maxsize = txtMaxsize.Value
                            objBEData.URL = txtURL.Value
                        End If
                        ' Insert new record into edataparameter table
                        objBEData.Add()
                    Case 7 ' Link
                        ' Insert Title subfield
                        objBField.FieldCode = Trim(txtFieldCode.Text) & "$t"
                        objBField.FieldName = "Title"
                        objBField.VietFieldName = "Title"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 0
                        objBField.FieldTypeID = 7
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert publish infor
                        objBField.FieldCode = strFieldCode & "$d"
                        objBField.FieldName = "Publish"
                        objBField.VietFieldName = "Publish"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 0
                        objBField.FieldTypeID = 7
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert edition subfield
                        objBField.FieldCode = strFieldCode & "$b"
                        objBField.FieldName = "Edition"
                        objBField.VietFieldName = "Edition"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 0
                        objBField.FieldTypeID = 7
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert physical infor
                        objBField.FieldCode = strFieldCode & "$h"
                        objBField.FieldName = "Physical infor"
                        objBField.VietFieldName = "Physical infor"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 0
                        objBField.FieldTypeID = 7
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert link subfield
                        objBField.FieldCode = strFieldCode & "$w"
                        objBField.FieldName = "Link"
                        objBField.VietFieldName = "Link"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 0
                        objBField.FieldTypeID = 7
                        objBField.DicID = 0
                        objBField.Create()
                    Case 8 ' Serials
                        ' Insert Title subfield
                        objBField.FieldCode = strFieldCode & "$t"
                        objBField.FieldName = "Title"
                        objBField.VietFieldName = "Title"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 7
                        objBField.FieldTypeID = 8
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert publish infor
                        objBField.FieldCode = strFieldCode & "$d"
                        objBField.FieldName = "Publish"
                        objBField.VietFieldName = "Publish"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 7
                        objBField.FieldTypeID = 8
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert edition subfield
                        objBField.FieldCode = strFieldCode & "$b"
                        objBField.FieldName = "Edition"
                        objBField.VietFieldName = "Edition"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 7
                        objBField.FieldTypeID = 8
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert physical infor
                        objBField.FieldCode = strFieldCode & "$h"
                        objBField.FieldName = "Physical infor"
                        objBField.VietFieldName = "Physical infor"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 7
                        objBField.FieldTypeID = 8
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert Serial No infor
                        objBField.FieldCode = strFieldCode & "$e"
                        objBField.FieldName = "Serial No"
                        objBField.VietFieldName = "Serial No"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 7
                        objBField.FieldTypeID = 8
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert issuieddate infor
                        objBField.FieldCode = strFieldCode & "$f"
                        objBField.FieldName = "Issuied Date"
                        objBField.VietFieldName = "Issuied Date"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 7
                        objBField.FieldTypeID = 8
                        objBField.DicID = 0
                        objBField.Create()
                        ' Insert link infor
                        objBField.FieldCode = strFieldCode & "$w"
                        objBField.FieldName = "Serial No"
                        objBField.VietFieldName = "Serial No"
                        objBField.Indicators = ""
                        objBField.VietIndicators = ""
                        objBField.Repeatable = 0
                        objBField.Mandatory = 0
                        objBField.Length = 0
                        objBField.Description = ""
                        objBField.LinkTypeID = CInt(txtLinkTypeID.Value)
                        objBField.FunctionID = 7
                        objBField.FieldTypeID = 8
                        objBField.DicID = 0
                        objBField.Create()
                End Select
                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & strMess1 & " " & txtFieldCode.Text & " " & strMess2 & "');</script>")

                ' Reset form's values
                txtFieldCode.Text = ""
                txtFieldName.Text = ""
                txtVietFieldName.Text = ""
                txtIndicators.Text = ""
                txtVietIndicators.Text = ""
                txtDescription.Text = ""
                txtLength.Text = "0"
                chkMandatory.Checked = False
                chkRepeatable.Checked = False
                ddlAuthorityControl.SelectedIndex = 0
                ddlMarcFieldTypes.SelectedIndex = 0
                ddlMarcFunctions.SelectedIndex = 0
                ' EData
                txtPhysicalPath.Value = ""
                txtAllowedFileExt.Value = ""
                txtDeniedFileExt.Value = ""
                txtLogo.Value = ""
                txtPrefix.Value = ""
                txtMaxsize.Value = ""
                txtURL.Value = ""

                ' Write log
                Call WriteLog(23, ddlLabel.Items(4).Text & ": " & txtFieldCode.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Else
                ' Alert message
                Page.RegisterClientScriptBlock("Alert", "<script language = 'javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBField Is Nothing Then
                    objBField.Dispose(True)
                    objBField = Nothing
                End If
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace