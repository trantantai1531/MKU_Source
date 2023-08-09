Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMainTitle As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Statistic Year
            If Not CheckPemission(52) Then
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        'Private Sub ImgAges_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgAges.Click
        '    Response.Redirect("WStatAgeForm.aspx")
        'End Sub

        'Private Sub ImgCompanies_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgCompanies.Click
        '    Response.Redirect("WStatColleFaculGraClass.aspx")
        'End Sub

        'Private Sub ImgJobs_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgJobs.Click
        '    Response.Redirect("WStatOccuForm.aspx")
        'End Sub

        'Private Sub ImgReaders_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgReaders.Click
        '    Response.Redirect("WStatPatronGrp.aspx")
        'End Sub

        'Private Sub ImgTimeDistribute_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgTimeDistribute.Click
        '    Response.Redirect("WStatCreatedExpired.aspx")
        'End Sub

        'Private Sub ImgTimeLimit_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgTimeLimit.Click
        '    Response.Redirect("WStatExpiredDate.aspx")
        'End Sub

        'Private Sub ImgTop20_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgTop20.Click
        '    Response.Redirect("WStatTop20.aspx")
        'End Sub
    End Class
End Namespace