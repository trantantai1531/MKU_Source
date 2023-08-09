Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestTaskbar
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidAction As System.Web.UI.HtmlControls.HtmlInputText


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Call BindJS()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("LoadWorkForm", "<script labguage='javascript'>parent.Workform.location.href='WRequestList.aspx'</script>")

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Request/WRequestTaskbar.js'></script>")

            btnFilter.Attributes.Add("OnClick", "javascript:FilterData(); return false;")
            btnCancelFilter.Attributes.Add("OnClick", "javascript:parent.Workform.location.href='WRequestList.aspx?Cancel=True'; return false;")
            btnAction.Attributes.Add("OnClick", "javascript:Act();return false;")
        End Sub
    End Class
End Namespace
