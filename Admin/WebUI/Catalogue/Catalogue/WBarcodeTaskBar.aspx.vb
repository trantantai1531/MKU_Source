' class 
' Puspose: BarCode TaskBar
' Creator: Sondp
' CreatedDate: 
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WBarcodeTaskBar
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
            If Not Page.IsPostBack Then
                If Not Session("IDs") Is Nothing Then
                    Dim collecBarCode As New Collection
                    collecBarCode = Session("BarCodeChoice")
                    txtCurrentPage.Text = "1"
                    lblMaxPage.Text = collecBarCode.Item("maxpage")
                Else
                    txtCurrentPage.Text = 0
                    lblMaxPage.Text = 0
                End If
            End If
            ' Must put BindScript method here
            Call BindScript()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WBarcodeTJs", "<script language='javascript' src='../Js/Catalogue/WBarCodePrint.js'></script>")
            btnPrevious.Attributes.Add("onclick", "javascript:PreviousClick(" & lblMaxPage.Text & ",document.forms[0].txtCurrentPage.value);return false;")
            btnNext.Attributes.Add("onclick", "javascript:NextClick(" & lblMaxPage.Text & ", document.forms[0].txtCurrentPage.value);return false;")
            txtCurrentPage.Attributes.Add("onKeyDown", "javascript:if(event.keyCode == 13 || event.which == 13 ) {CurrentPageChange(" & lblMaxPage.Text & ",document.forms[0].txtCurrentPage.value);return false;}")
            hrfRequest.NavigateUrl = "javascript:parent.location.href='WBarcodeForm.aspx';"
        End Sub
    End Class
End Namespace