Namespace eMicLibAdmin.WebUI
    Partial Class WIntroduction
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
            'Call ExportResource()
            imgAcq.Alt = ddlLabel.Items(0).Text
            imgAcq.Attributes.Add("OnClick", "javascript:parent.header.MenuChange(6);parent.header.MenuClick(6);")
            imgAdmin.Alt = ddlLabel.Items(7).Text
            imgAdmin.Attributes.Add("OnClick", "javascript:parent.header.MenuChange(2);parent.header.MenuClick(2);")
            imgCatalogue.Alt = ddlLabel.Items(1).Text
            imgCatalogue.Attributes.Add("OnClick", "javascript:parent.header.MenuChange(4);parent.header.MenuClick(4);")
            imgOPAC.Alt = ddlLabel.Items(5).Text
            imgOPAC.Attributes.Add("OnClick", "javascript:parent.header.MenuChange(10);parent.header.MenuClick(10);")
            imgCirculation.Alt = ddlLabel.Items(2).Text
            imgCirculation.Attributes.Add("OnClick", "javascript:parent.header.MenuChange(5);parent.header.MenuClick(5);")
            imgSerial.Alt = ddlLabel.Items(4).Text
            imgSerial.Attributes.Add("OnClick", "javascript:parent.header.MenuChange(7);parent.header.MenuClick(7);")
            imgPatron.Alt = ddlLabel.Items(8).Text
            imgPatron.Attributes.Add("OnClick", "javascript:parent.header.MenuChange(3);parent.header.MenuClick(3);")
        End Sub
    End Class
End Namespace
