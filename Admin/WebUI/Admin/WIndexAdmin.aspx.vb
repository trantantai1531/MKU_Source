Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Admin

Namespace eMicLibAdmin.WebUI.Admin
    Public Class WIndexAdmin
        Inherits clsWbase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents ImgPrintBarCode As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblCapStylePatron As System.Web.UI.WebControls.Label
        Protected WithEvents ImgViewLog As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lblCapViewLog As System.Web.UI.WebControls.Label
        Protected WithEvents lblCapSysParam As System.Web.UI.WebControls.Label
        Protected WithEvents ImgSysParam As System.Web.UI.WebControls.ImageButton
        Protected WithEvents imgLanguage As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkLanguage As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblCapLanguage As System.Web.UI.WebControls.Label
        Protected WithEvents ImgDatabase As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkDatabase As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblCapDatabase As System.Web.UI.WebControls.Label
        Protected WithEvents lnkStylePatron As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkViewLog As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkSysParam As System.Web.UI.WebControls.HyperLink
        Protected WithEvents ImgUser As System.Web.UI.WebControls.ImageButton

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
        End Sub

        Private Sub ImgUser_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgUser.Click
            Response.Redirect("WIndexUser.aspx")
        End Sub

        Private Sub ImgViewLog_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgViewLog.Click
            Response.Redirect("WIndexLog.aspx")
        End Sub

        Private Sub ImgSysParam_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgSysParam.Click
            Response.Redirect("WSetSysParam.aspx")
        End Sub

        Private Sub imgLanguage_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLanguage.Click
            Response.Redirect("WManLanguageFrame.aspx")
        End Sub

        Private Sub ImgDatabase_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgDatabase.Click
            Response.Redirect("WIndexDatabase.aspx")
        End Sub
    End Class

End Namespace
