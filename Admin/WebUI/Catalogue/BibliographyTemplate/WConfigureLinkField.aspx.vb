' WConfigureAttachField class
' Purpose: configure Attach field
' Creator: Oanhtn
' CreatedDate: 11/05/2004
' Modification history
'    - 01/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WConfigureLinkField
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel0 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label


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
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init for objBField
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            objBField.ConnectionString = Session("ConnectionString")
            Call objBField.Initialize()
        End Sub

        ' BindData method
        ' Purpose: bind MarcLinkTypes dropdownlist
        Private Sub BindData()
            Dim intLinkID As Integer = CInt(Request("LinkID"))
            Dim intCounter As Integer
            Dim tblLinkTypes As DataTable

            tblLinkTypes = objBField.GetLinkTypes
            If Not tblLinkTypes Is Nothing Then
                ddlMarcLinkTypes.DataSource = tblLinkTypes
                ddlMarcLinkTypes.DataTextField = "Type"
                ddlMarcLinkTypes.DataValueField = "ID"
                ddlMarcLinkTypes.DataBind()

                For intCounter = 0 To tblLinkTypes.Rows.Count - 1
                    If CInt(tblLinkTypes.Rows(intCounter).Item("ID")) = intLinkID Then
                        ddlMarcLinkTypes.SelectedIndex = intCounter
                    End If
                Next

                ddlMarcLinkTypes.Attributes.Add("OnChange", "javascript:opener.top.Workform.document.forms[0].txtLinkTypeID.value = this.options[this.options.selectedIndex].value;")
            End If
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
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