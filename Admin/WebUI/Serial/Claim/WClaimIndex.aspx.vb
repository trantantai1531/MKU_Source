' Class: WClaimIndex
' Puspose: show claim index page
' Creator: Oanhtn
' CreatedDate: 27/05/2005

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WClaimIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ddlLabel As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
        End Sub

        ' Show Claimtempalte
        'Private Sub imgTemplate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgTemplate.Click
        '    Response.Redirect("WClaimTemplateManagement.aspx")
        'End Sub

        '' Set claim cycle
        'Private Sub imgSetClaimCycle_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSetClaimCycle.Click
        '    Response.Redirect("WSetClaimCycle.aspx")
        'End Sub

        '' Claim
        'Private Sub imgClaim_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClaim.Click
        '    Response.Redirect("WClaim.aspx")
        'End Sub

        '' Show claimed list
        'Private Sub imgShowClaimList_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgShowClaimList.Click
        '    Response.Redirect("WShowClaimList.aspx")
        'End Sub
    End Class
End Namespace