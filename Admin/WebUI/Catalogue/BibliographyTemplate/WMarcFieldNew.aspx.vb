' WMarcFieldNew class
' Creator: Oanhtn
' CreatedDate: 11/05/2004
' Modification history 
'   - 13/05/2004 by Oanhtn
'   - 01/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldNew
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
                Call InsertMarcField()
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
            Dim strMess2 As String = ddlLabel.Items(4).Text
            Dim strMess4 As String = ddlLabel.Items(5).Text

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcFieldNewJs", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcFieldNew.js'></script>")
            txtFieldCode.Attributes.Add("OnChange", "javascript:CheckUniqueField(" & intUTF & ", '" & strMess4 & "');")
            btnConfigureAttachDataField.Attributes.Add("OnClick", "javascript:ConfigureAttachDataField('" & strMess2 & "'); return false;")
            ddlMarcFieldTypes.Attributes.Add("OnFocus", "javascript:intType = this.selectedIndex;")
            ddlMarcFieldTypes.Attributes.Add("OnChange", "javascript:if(CheckNull(document.forms[0].txtFieldCode)) {alert('" & strMess4 & "'); this.selectedIndex = 0;} else { if (document.forms[0].txtFieldCode.value.indexOf('$') >= 0) { parent.Hiddenbase.location.href='WCheckAttachField.aspx?FieldCode=' + document.forms[0].txtFieldCode.value + '&TypeID=' + this.options[this.options.selectedIndex].value; }}")
        End Sub

        ' BindData method
        ' Purpose: bind data for all necessary controls
        Private Sub BindData()
            Dim strSelect As String = ddlLabel.Items(0).Text

            ' Bind ddlMarcFieldTypes
            ddlMarcFieldTypes.DataSource = objBField.RetrieveMarcFieldTypes
            ddlMarcFieldTypes.DataTextField = "FieldType"
            ddlMarcFieldTypes.DataValueField = "ID"
            ddlMarcFieldTypes.DataBind()

            ' Bind ddlMarcFunctions
            ddlMarcFunctions.DataSource = objBField.RetrieveMarcFunctions
            ddlMarcFunctions.DataTextField = "FieldFunction"
            ddlMarcFunctions.DataValueField = "ID"
            ddlMarcFunctions.DataBind()

            ' Bind ddlAuthorityControl
            ddlAuthorityControl.DataSource = InsertOneRow(objBField.RetrieveCatDicList, strSelect)
            ddlAuthorityControl.DataTextField = "Name"
            ddlAuthorityControl.DataValueField = "ID"
            ddlAuthorityControl.DataBind()
        End Sub

        ' InsertMarcField method
        ' Purpose: insert new field into MARC_BIB_FIELD table
        Private Sub InsertMarcField()
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
            objBField.DicID = ddlAuthorityControl.SelectedValue

            ' Insert new field
            objBField.Create()
            ' Write log
            Call WriteLog(23, ddlLabel.Items(3).Text & Trim(txtFieldCode.Text) & " : " & Trim(txtFieldName.Text), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If objBField.ErrorMsg = "" Then
                Select Case ddlMarcFieldTypes.SelectedValue
                    Case 4 ' Attach
                        objBEData.PhysicalPath = txtPhysicalPath.Value.Trim
                        objBEData.AllowedFileExt = txtAllowedFileExt.Value.Trim
                        objBEData.DeniedFileExt = txtDeniedFileExt.Value.Trim
                        objBEData.Logo = txtLogo.Value.Trim
                        objBEData.Prefix = txtPrefix.Value.Trim
                        objBEData.Maxsize = txtMaxSize.Value.Trim
                        objBEData.URL = txtURL.Value.Trim
                        ' Insert new record into edataparameter table
                        objBEData.Add()
                        Response.Write(objBEData.SQL)
                    Case 7 ' Link
                        ' Insert Title subfield
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$t"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$d"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$b"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$h"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$w"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$t"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$d"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$b"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$h"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$e"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$f"
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
                        objBField.FieldCode = txtFieldCode.Text.Trim & "$w"
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
                Page.RegisterClientScriptBlock("InsertSuccessfull", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & " " & txtFieldCode.Text & "'); document.forms[0].reset();</script>")
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
