' WMarcBlocks class: allow user select suitable Marc field block
' Creator: Oanhtn
' CreatedDate: 27/03/2004
' Modification history:
'   - 23/02/2005 by oanhtn: review & update

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMarcFieldBlocks
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If

            If Session("IsAuthority") = 1 Then
                ddlMarcBlock.Attributes.Add("OnChange", "javascript:if (this.selectedIndex >= 0 ) { parent.MarcFields.location.href='WMarcFields.aspx?BlockID=' + this.options[this.selectedIndex].value; parent.MarcSubFields.location.href='WNothing.htm';}")
                btnFind.Attributes.Add("OnClick", "javascript:parent.MarcSubFields.location.href='WMarcFieldSearch.aspx';")
            Else
                ddlMarcBlock.Attributes.Add("OnChange", "javascript:if (this.selectedIndex >= 0) { parent.MarcFields.location.href='WMarcFields.aspx?BlockID=' + this.options[this.selectedIndex].value; parent.MarcSubFields.location.href='WNothing.htm';}")
                btnFind.Attributes.Add("OnClick", "javascript:parent.MarcSubFields.location.href='WMarcFieldSearch.aspx';")
            End If
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

        ' BindData method
        Private Sub BindData()
            Dim tblTemp As DataTable
            objBField.IsAuthority = Session("IsAuthority")
            tblTemp = objBField.GetBlockFields
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlMarcBlock.DataSource = tblTemp
                ddlMarcBlock.DataTextField = "Code"
                ddlMarcBlock.DataValueField = "ID"
                ddlMarcBlock.DataBind()
                ddlMarcBlock.SelectedIndex = 0
            End If
        End Sub

        ' Page_Unload event
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