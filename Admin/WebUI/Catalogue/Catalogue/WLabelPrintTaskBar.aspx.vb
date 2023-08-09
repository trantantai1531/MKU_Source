' Class: WLabelPrintTaskbar
' Puspose: Print label
' Creator: Sondp
' CreatedDate: 22/02/2005
' Modification History:

Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WLabelPrintTaskBar
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hdHagPage As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdColsPage As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdLibID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdLocID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdItemType As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdTemplateID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents Hidden1 As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindScript()
            If Not Page.IsPostBack Then
                If Not Session("IDs") Is Nothing And Not Session("ItemIDs") Is Nothing Then
                    If UBound(Session("IDs")) > 0 And UBound(Session("ItemIDs")) > 0 Then
                        txtCurrentPage.Text = 1
                        lblMaxPage.Text = Session("MaxPage")
                        hdMaxPage.Value = Session("MaxPage")
                    Else
                        txtCurrentPage.Text = "0"
                        lblMaxPage.Text = "0"
                        hdMaxPage.Value = 0
                    End If
                End If
            End If
        End Sub

        ' Method: BindScript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WLabelPrintTaskBarJs", "<script language='javascript' src='../Js/Catalogue/WLabelPrintSearch.js'></script>")
            btnPrevious.Attributes.Add("OnClick", "PreviousClick(" & Session("MaxPage") & ",document.forms[0].txtCurrentPage.value);return false;")
            btnNext.Attributes.Add("OnClick", "NextClick(" & Session("MaxPage") & ", document.forms[0].txtCurrentPage.value);return false;")
            txtCurrentPage.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) {CurrentPageChange(" & Session("MaxPage") & ",document.forms[0].txtCurrentPage.value);return false;}")
            hrfRequest.NavigateUrl = "javascript:parent.location.href='WLabelPrintSearch.aspx';"
        End Sub
    End Class
End Namespace