' WMarcSubFields class: allow user select suite Marc subfields
' Creator: Oanhtn
' CreatedDate: 28/04/2004
' Modification history :
'   - 23/02/2005 by oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcSubFields
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Test As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBField As New clsBField

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call ShowMarcFieldsInfor()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init for objBField
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.IsAuthority = Session("IsAuthority")
            Call objBField.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WMarcSubFields", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WMarcSubFields.js'></script>")
        End Sub

        ' ShowMarcFieldsInfor method
        ' Purpose: Display MARC sub fields of the selected field
        Private Sub ShowMarcFieldsInfor()
            ' Declare variables
            Dim strFieldCode As String
            Dim intBlockID As Integer
            Dim tblSubFields As DataTable
            Dim strFieldProperties As String = "javascript:OpenWindow(""WMarcFieldProperties.aspx?FieldCode=FIELDVALUE"",""WMarcFieldProperties"",700,360,50,100);"
            Dim strChecked As String = "<input type=""Checkbox"" name=""chkMarcSubField"" id=""chkMarcSubField"" value=""PARAM"" onClick=""if (this.checked) {AddSubField(this);} else {RemoveSubField(this);}"">"

            ' Get FieldCode
            strFieldCode = Request("FieldCode")

            ' Retrieve subfield of the selected field
            objBField.FCURL1 = strFieldProperties
            objBField.FCURL2 = strChecked
            objBField.FieldCode = strFieldCode
            tblSubFields = objBField.GetSubFields
            If Not tblSubFields Is Nothing AndAlso tblSubFields.Rows.Count > 0 Then
                dtgMarcFields.DataSource = tblSubFields
                dtgMarcFields.DataBind()

                ' Customize display
                dtgMarcFields.Columns(2).Visible = False
            End If
        End Sub

        ' Page_Unload Method
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
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