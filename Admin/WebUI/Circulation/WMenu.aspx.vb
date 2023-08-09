' Name: WMenu class
' Purpose: Display main menu
' Creator: Oanhtn
' CreatedDate: 23/08/2004
' Modification history:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WMenu
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkHelp As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkBib As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkIndex As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkBack As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkForward As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblCheckOut As System.Web.UI.WebControls.Label
        Protected WithEvents lblCheckIn As System.Web.UI.WebControls.Label
        Protected WithEvents lblRenew As System.Web.UI.WebControls.Label
        Protected WithEvents lblOverDue As System.Web.UI.WebControls.Label
        Protected WithEvents lblHold As System.Web.UI.WebControls.Label
        Protected WithEvents lblPolicy As System.Web.UI.WebControls.Label
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents lnkTitle As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink1 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkAuthority As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkClassification As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkDictionary As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink3 As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WMenu.js'></script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace