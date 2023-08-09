' class WStatisticMain
' Puspose: Show statistic index page
' Creator: Sondp
' CreatedDate: 5/12/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WStatisticMain
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblDestinationDeniedRequest As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'lnkSourceService.NavigateUrl = "javascript:parent.Workform.location.href='WIRServReport.aspx';"
            'lnkDestinationService.NavigateUrl = "javascript:parent.Workform.location.href='WORServReport.aspx';"
            'lnkSourceCommon.NavigateUrl = "javascript:parent.Workform.location.href='WIRGeneralReport.aspx';"
            'lnkDestinationCommon.NavigateUrl = "javascript:parent.Workform.location.href='WORGeneralReport.aspx';"
            'lnkSourceDeniedRequest.NavigateUrl = "javascript:parent.Workform.location.href='WIRDeniedReport.aspx';"
            'lnkDestinationDeniedRequest.NavigateUrl = "javascript:parent.Workform.location.href='WORDeniedReport.aspx';"
        End Sub

        ' Event: imgSourceService_Click
        Private Sub imgSourceService_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSourceService.Click
            Response.Redirect("WIRServReport.aspx")
        End Sub

        ' Event: imgSourceCommon_Click
        Private Sub imgSourceCommon_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSourceCommon.Click
            Response.Redirect("WIRGeneralReport.aspx")
        End Sub

        ' Event: imgSourceDeniedRequest_Click
        Private Sub imgSourceDeniedRequest_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSourceDeniedRequest.Click
            Response.Redirect("WIRDeniedReport.aspx")
        End Sub

        ' Event: imgDestinationService_Click
        Private Sub imgDestinationService_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDestinationService.Click
            Response.Redirect("WORServReport.aspx")
        End Sub

        ' Event: imgDestinationCommon_Click
        Private Sub imgDestinationCommon_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDestinationCommon.Click
            Response.Redirect("WORGeneralReport.aspx")
        End Sub

        ' Event: imgDestinationDeniedRequest_Click
        Private Sub imgDestinationDeniedRequest_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDestinationDeniedRequest.Click
            Response.Redirect("WORDeniedReport.aspx")
        End Sub
    End Class
End Namespace