Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCardIndex
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

        'Private Sub ImgFollowPrint_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        '    Response.Redirect("WMonitorPrintCard.aspx")
        'End Sub

        'Private Sub ImgPrintBarCode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        '    Response.Redirect("WBarcodeSearch.aspx")
        'End Sub

        'Private Sub ImgPrintCard_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgPrintCard.Click
        '    Response.Redirect("WCards.aspx")
        'End Sub

        'Private Sub ImgStyleCard_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        '    Response.Redirect("WCardTemplate.aspx")
        'End Sub

        'Private Sub ImgStyleCard_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgStyleCard.Click
        '    Response.Redirect("WCardTemplate.aspx")
        'End Sub

        'Private Sub ImgPrintBarCode_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgPrintBarCode.Click
        '    Response.Redirect("WBarcodeSearch.aspx")
        'End Sub

        'Private Sub ImgFollowPrint_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgFollowPrint.Click
        '    Response.Redirect("WMonitorPrintCard.aspx")
        'End Sub
    End Class
End Namespace