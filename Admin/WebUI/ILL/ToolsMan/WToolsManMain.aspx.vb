' class WToolsManMain
' Puspose: Show tool index page
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   - 23/04/2005 by Tuanhv: Update

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WToolsManMain
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Hyperlink1 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink3 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink4 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink5 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink6 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblElectric As System.Web.UI.WebControls.Label
        Protected WithEvents hrfPackTemplatea As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJS()
        End Sub

        ' Method: BindJS
        Sub BindJS()
            Page.RegisterClientScriptBlock("TempalteJs", "<script language='javascript' src='../JS/ToolsMan/WToolsManMain.js'></script>")
            'lnkElectric.NavigateUrl = "javascript:ViewURL(1,400,300);"
            'imgElectric.Attributes.Add("Onclick", "javascript:ViewURL(1,400,300);return false;")
            'lnkPhysical.NavigateUrl = "javascript:ViewURL(2,400,300);"
            'imgPhysical.Attributes.Add("Onclick", "javascript:ViewURL(2,400,300);return false;")
            'lnkRequestRetrievPayment.NavigateUrl = "javascript:ViewURL(3,630,420);"
            'imgRequestRetrievPayment.Attributes.Add("Onclick", "javascript:ViewURL(3,630,420);return false;")
            'lnkPayment.NavigateUrl = "javascript:ViewURL(4,350,300);"
            'imgPayment.Attributes.Add("Onclick", "javascript:ViewURL(4,300,300);return false;")
            'lnkCopyright.NavigateUrl = "javascript:ViewURL(5,400,300);"
            'imgCopyright.Attributes.Add("Onclick", "javascript:ViewURL(5,400,300);return false;")
            'lnkDenied.NavigateUrl = "javascript:ViewURL(6,520,350);"
            'imgDenied.Attributes.Add("Onclick", "javascript:ViewURL(6,520,350);return false;")
            'lnkZ3950.NavigateUrl = "javascript:ViewURL(7,530,350);"
            'imgZ3950.Attributes.Add("Onclick", "javascript:ViewURL(7,530,350);return false;")
        End Sub

        ' Evnet: imgPackTemplate_Click
        'Private Sub imgPackTemplate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPackTemplate.Click
        '    Response.Redirect("WTemplate.aspx?TemplateType=12")
        'End Sub

        '' Event: imgDeniedTemplate_Click
        'Private Sub imgDeniedTemplate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDeniedTemplate.Click
        '    Response.Redirect("WTemplate.aspx?TemplateType=13")
        'End Sub

        '' Event: Response.Redirect("
        'Private Sub imgNoticeTemplate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNoticeTemplate.Click
        '    Response.Redirect("WTemplate.aspx?TemplateType=14")
        'End Sub

        '' Event: imgOverdueTemplate_Click
        'Private Sub imgOverdueTemplate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOverdueTemplate.Click
        '    Response.Redirect("WTemplate.aspx?TemplateType=16")
        'End Sub
    End Class
End Namespace