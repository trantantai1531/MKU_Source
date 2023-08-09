Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSendPOClaimActionResult
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            lblDisplay.Text = Request("Editor").Replace("&lt;", "<").Replace("&gt;", ">")
            Select Case UCase(Request.QueryString("action")) & ""
                Case "PRINT"
                    Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
            End Select
        End Sub
    End Class
End Namespace