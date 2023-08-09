' class: WComprehReportBookP
' Puspose: Preview Comprehensive Report Book
' Creator: Sondp
' CreatedDate: 12/04/2005
' Modification History:

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WComprehReportBookP
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
            If Not Request("Editor") & "" = "" Then
                lblDisplay.Text = Replace(Replace(Request("Editor"), "&lt;", "<"), "&gt;", ">")
                Select Case UCase(Request.QueryString("action"))
                    Case "PRINT"
                        btnClose.Visible = False
                        Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
                End Select
            End If
            btnClose.Attributes.Add("OnClick", "self.close();return(false);")
        End Sub
    End Class
End Namespace