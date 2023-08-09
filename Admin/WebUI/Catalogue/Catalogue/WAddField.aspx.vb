' WAddField class
' Purpose: Add fields to the current catalogue form
' Creator: Oanhtn
' CreatedDate: 18/05/2004
' Modification history:
'   - 14/07/2004 by Oanhtn: Modify btnSearch_Click sub: allow working with authority data
'   - 02/03/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WAddField
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
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBField object
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            objBField.IsAuthority = Session("IsAuthority")
            Call objBField.Initialize()

            ' Customize interface
            dtgMarcFields.Visible = False
            btnAdd.Visible = False
        End Sub

        ' BindJS method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WAddFieldJs", "<script language = 'javascript' src = '../Js/Catalogue/WAddField.js'></script>")

            btnSearch.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtPattern)) {alert('" & ddlLabel.Items(2).Text & "'); return false;}")
            btnAdd.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtPattern)) {alert('" & ddlLabel.Items(2).Text & "'); return false;} else {AddTags();}")
            btnClose.Attributes.Add("OnClick", "self.close();")
        End Sub

        ' btnSearch_Click event
        ' Purpose: search field by fieldcode
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            ' Declare variables
            Dim tblResult As New DataTable
            Dim strResult As String = ""
            Dim intCounter As Integer
            Dim strFieldProperties As String = "javascript:OpenWindow(""../BibliographyTemplate/WMarcFieldProperties.aspx?FieldCode=FIELDVALUE"",""WMarcFieldProperties"",700,360,50,100);"
            Dim strChecked As String = "<input type=""Checkbox"" name=""chkField"" id=""chkField"" value=""PARAM"">"

            ' Search
            objBField.Pattern = Trim(txtPattern.Text)
            objBField.HaveParentFieldCode = -1 ' get parent FieldCode only
            objBField.FCURL1 = strFieldProperties
            objBField.FCURL2 = strChecked
            tblResult = objBField.SearchField
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                dtgMarcFields.DataSource = tblResult
                dtgMarcFields.DataBind()

                ' Customize display
                dtgMarcFields.Columns(2).Visible = False
                dtgMarcFields.Visible = True
                btnAdd.Visible = True
            Else
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text.Trim & "');</script>")
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace