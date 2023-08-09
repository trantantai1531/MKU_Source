' Class: WAcquire
' Puspose: acquire new periodical
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WMainMenu
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkIndex As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkCheckOut As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkCheckIn As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkRenew As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkOverdue As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkHold As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkPolicy As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink1 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkAccount As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkBack As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkForward As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkTitle As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
        End Sub

        ' BindJS method
        ' Purpose: Include all javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WMainMenu.js'></script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace