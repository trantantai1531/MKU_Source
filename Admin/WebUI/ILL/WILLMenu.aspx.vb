' class WILLMenu
' Puspose: ILL menu
' Creator: Sondp
' CreatedDate: 29/11/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WILLMenu
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkT As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkArticle As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkAcquisition As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkClaim As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkStatistic As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkSearch As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkBack As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkForward As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkTitle As System.Web.UI.WebControls.HyperLink


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

        ' BindScript method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WILLMenu.js'></script>")
        End Sub
    End Class
End Namespace

