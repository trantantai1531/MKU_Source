' WMarcFieldSearch class
' Puspose: search field by FieldCode
' Creator: KhoaNA
' CreatedDate: 07/05/2004
' Modification Historiy:

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldSearch
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

        ' Declare variables
        Private objBField As New clsBField

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
        End Sub

        ' Initialize method
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Init objBField object
            objBField.IsAuthority = Session("IsAuthority")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcFieldSearch", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcSubFields.js'></script>")

            btnSearch.Attributes.Add("OnClick", "javascript:if(CheckNull(document.forms[0].txtPattern)) {alert('" & ddlLabel.Items(0).Text & "'); return false;}")
        End Sub

        ' btnSearch_Click event
        ' Purpose: display searching results
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim strResult As String = ""
            Dim intCounter As Integer
            Dim tblResult As New DataTable
            Dim strFieldProperties As String = "javascript:OpenWindow(""WMarcFieldProperties.aspx?FieldCode=FIELDVALUE"",""WMarcFieldProperties"",700,360,50,100);"
            Dim strChecked As String = "<input type=""Checkbox"" name=""chkMarcSubField"" id=""chkMarcSubField"" value=""PARAM"" onClick=""if (this.checked) {AddSubField(this);} else {RemoveSubField(this);}"">"

            ' Search
            objBField.Pattern = Trim(txtPattern.Text)
            objBField.HaveParentFieldCode = 1
            objBField.FCURL1 = strFieldProperties
            objBField.FCURL2 = strChecked
            tblResult = objBField.SearchField
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                dtgMarcFields.Visible = True
                dtgMarcFields.DataSource = tblResult
                dtgMarcFields.DataBind()
                ' Customize display
                dtgMarcFields.Columns(2).Visible = False
            Else
                dtgMarcFields.Visible = False
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text.Trim & "'); document.forms[0].txtPattern.value=''; document.forms[0].txtPattern.focus();</script>")
            End If

            ' Release object
            tblResult = Nothing
        End Sub

        ' ShowMarcFieldsInfor method
        ' Purpose: Display MARC sub fields of the selected field
        Private Sub ShowMarcFieldsInfor(ByVal strFieldCodes As String)
            ' Declare variables
            Dim intBlockID As Integer
            Dim tblSubFields As DataTable
            Dim strFieldProperties As String = "javascript:OpenWindow(""WMarcFieldProperties.aspx?FieldCode=FIELDVALUE"",""WMarcFieldProperties"",700,360,50,100);"
            Dim strChecked As String = "<input type=""Checkbox"" name=""chkMarcSubField"" id=""chkMarcSubField"" value=""PARAM"" onClick=""if (this.checked) {AddSubField(this);} else {RemoveSubField(this);}"">"

            ' Retrieve subfield of the selected field
            objBField.FCURL1 = strFieldProperties
            objBField.FCURL2 = strChecked
            objBField.FieldCode = strFieldCodes
            tblSubFields = objBField.GetSubFields
            If Not tblSubFields Is Nothing AndAlso tblSubFields.Rows.Count > 0 Then
                dtgMarcFields.Visible = True
                dtgMarcFields.DataSource = tblSubFields
                dtgMarcFields.DataBind()

                ' Customize display
                dtgMarcFields.Columns(2).Visible = False
            Else
                dtgMarcFields.Visible = False
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text.Trim & "'); document.forms[0].txtPattern.value=''; document.forms[0].txtPattern.focus();</script>")
            End If

            ' Release object
            tblSubFields = Nothing
        End Sub

        ' Page_UnLoad event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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