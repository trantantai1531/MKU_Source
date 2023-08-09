Partial Class WCataAuthorityLic
    Inherits System.Web.UI.Page

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Request.QueryString("sondp") <> "" Then
            Page.RegisterClientScriptBlock("LicJs", "<script language='javascript'>alert('Developed by Sondp, with ID Card: 011864780, Mobile:0912908193. Thank');</script>")
        End If
    End Sub

End Class
