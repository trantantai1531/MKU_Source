Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WBatchProcess
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
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
        End Sub

        'Private Sub ImgDeadLine_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgDeadLine.Click
        '    Response.Redirect("WRenewCards.aspx")
        'End Sub

        'Private Sub ImgDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgDelete.Click
        '    Response.Redirect("WBatchPatronDelete.aspx")
        'End Sub

        'Private Sub ImgUpdate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgUpdate.Click
        '    Response.Redirect("WBatchPatronUpdate.aspx")
        'End Sub
    End Class
End Namespace