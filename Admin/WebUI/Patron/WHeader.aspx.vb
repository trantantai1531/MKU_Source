Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WHeader
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgReader As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline1 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgDocument As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline2 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgCard As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline3 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgProcGroup As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgline4 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgStatistic As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgLine5 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgBack As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgLine6 As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgForward As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkIndexPO As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkIndexACQ As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkIndexAccounting As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkIndexStore As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkIndexStat As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink3 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkTitle As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJS()
        End Sub

        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='js/WHeader.js'></script>")
        End Sub
    End Class
End Namespace