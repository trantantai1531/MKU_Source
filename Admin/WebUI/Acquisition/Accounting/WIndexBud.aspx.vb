Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WIndexBud
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
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", Me.GetStyleSheetURL("Acquisition")))
            'WBudgetView.aspx
            lnkSpeDec.NavigateUrl = "WBudgetView.aspx"
            'WAcqView.aspx
            lnkAcqDec.NavigateUrl = "WAcqView.aspx"
            'WRateChange.aspx
            lnkWRateChange.NavigateUrl = "WRateChange.aspx"
            'WBugdetDisplay.aspx
            lnkWBudgetFrame.NavigateUrl = "WBudgetFrame.aspx"

            'Me.ExportResource("c:\inetpub\wwwroot\Libol60\WebUI\Resources\LabelString\Acquisition\Budget\WIndexBudSR.vi.resx", False)
            'Me.ExportResource("c:\inetpub\wwwroot\Libol60\WebUI\Resources\Images\Acquisition\Budget\WIndexBudIR.vi.resx", True)
        End Sub

        Private Sub imgSpeDec_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSpeDec.Click
            Response.Redirect("WBudgetView.aspx")
        End Sub

        Private Sub imgAcqDec_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAcqDec.Click
            Response.Redirect("WAcqView.aspx")
        End Sub

        Private Sub imgWRateChange_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWRateChange.Click
            Response.Redirect("WRateChange.aspx")
        End Sub

        Private Sub imgWBudgetFrame_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWBudgetFrame.Click
            Response.Redirect("WBudgetFrame.aspx")
        End Sub
    End Class
End Namespace