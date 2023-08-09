Imports eMicLibAdmin.WebUI
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Namespace eMicLibAdmin.WebUI
    Partial Class WPrintBarCode
        Inherits System.Web.UI.Page

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
            Dim imageType As Integer = 3 'default *.png
            imageType = CInt(Session("ImgType"))
            Dim strImageType As String = "png"
            Select Case imageType
                Case 1
                    strImageType = "gif"
                Case 2
                    strImageType = "jpeg"
                Case 3
                    strImageType = "png"
                Case 4
                    strImageType = "bmp"
                Case 5
                    strImageType = "tiff"
            End Select
            Response.ContentType = "image/" & strImageType
            Response.BinaryWrite(Session("bc" & Request.QueryString("i")))
        End Sub
    End Class
End Namespace
