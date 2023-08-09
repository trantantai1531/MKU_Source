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
    Partial Class WOPPrintEdit
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        'Protected WithEvents btnPrint As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call BindScript()
            If Not Page.IsPostBack Then
                Editor.Text = Request("hdDisplay") ' Request("hdDisplay").Replace("&lt;", "<").Replace("&gt;", ">")
            End If
            Editor.Text = Editor.Text.Replace("&lt;", "<").Replace("&gt;", ">")
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WPOPrintEditJs", "<script language='javascript' src='../Js/PO/WPOPrint.js'></script>")

            btnPreview.Attributes.Add("OnClick", "Encryption();Preview();return(false);")
            'btnPrint.Attributes.Add("OnClick", "Print();return(false);")
            btnClose.Attributes.Add("OnClick", "self.location.href='WPOPrintSearch.aspx';return(false);")
        End Sub
    End Class
End Namespace