' class 
' Puspose: Manager Template
' Creator: Sondp
' CreatedDate: 10/03/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPOPrintPreview
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
            Call BindScript()
            If Not IsPostBack Then
                lblDisplay.Text = Request("Editor").Replace("&lt;", "<").Replace("&gt;", ">")
                hidvalue.Text = Request("Editor").ToString
            End If
        End Sub

        ' BindScipt method
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "self.close();return(false);")
        End Sub
        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            btnClose.Visible = False
            btnPrint.Visible = False
            lblDisplay.Text = hidvalue.Text.Replace("&lt;", "<").Replace("&gt;", ">")
            Page.RegisterClientScriptBlock("PrintActionJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);</script>")
        End Sub
    End Class
End Namespace