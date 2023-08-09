' WOverlayForm class
' Purpose: Display overlay item form
' Creator: Oanhtn
' CreatedDate: 07/07/2004
' Modification history:
'   - 11/03/2005 by Oanhtn: review & update

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WOverlayForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents optRaw As System.Web.UI.WebControls.RadioButton
        Protected WithEvents optTag As System.Web.UI.WebControls.RadioButton


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        ' Purpose: call all method here
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJavascript()
            Call BindData()
        End Sub

        ' BindData method
        ' Purpose: Load some informations to form
        Private Sub BindData()
            Session("Overlay") = 1
            txtDesignator.Text = "$"
            txtLeader.Text = Request("Leader")
            txtItemCode.Text = Request("ItemCode")
            hidFormID.Value = Request("FormID")
            hidCurrentID.Value = Request("CurrentID")
            hidStage.Value = Request("Stage")
            hidItemID.Value = Request("ItemID")
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WOverlayFormJs", "<script language = 'javascript' src = '../Js/Catalogue/WOverlayForm.js'></script>")

            ' Create HelpLink navigate
            lnkLeaderHelp.NavigateUrl = "javascript:OpenWindow('WLeaderHelp.aspx?overlay=1','LeaderWin',600,380,70,70);"
            btnImport.Attributes.Add("OnClick", "javascript:CheckValid(); return false;")

            Me.SetOnclickZ3950(btnZ3950, "../..")
            'btnZ3950.Attributes.Add("OnClick", "OpenWindow('WZForm.aspx','WZForm',640,380,70,70); return false;")
            btnReset.Attributes.Add("OnClick", "document.forms[0].txtContent.value='';document.forms[0].txtDesignator.value='';document.forms[0].txtDeliminator.value='';document.forms[0].txtExcludeFields.value='';document.forms[0].txtItemCode.value='" & Request("ItemCode") & "';document.forms[0].txtLeader.value='" & Request("Leader") & "'; return false;")
        End Sub


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace