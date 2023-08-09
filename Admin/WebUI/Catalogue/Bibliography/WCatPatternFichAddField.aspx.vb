'Class: WCatPatternFichAddField  
'Propose: add fich tag
'CreatedDate: 23/4/2004
'Creator:sondp.
'Modification history 
'   - 26/02/2005 by Tuanhv: review
'   - 25/03/2005 by Tuanhv: review

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPatternFichAddField
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtShelfTo As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Binjavascript for all control need
            Call BindScript()
        End Sub

        'register client action
        Public Sub BindScript()
            'Register Client Action
            Page.RegisterClientScriptBlock("PatternFichJs", "<script language='javascript' src='../js/Bibliography/WCatPatternFich.js'></script>")

            'standar tag
            btnAddSpecTag.Attributes.Add("onclick", "javascript:SpecTagAdd();return(false);")
            'normal tag
            txtTagCode.Attributes.Add("onchange", "javascript:return(CheckTag());")
            ckbFixedVal.Attributes.Add("onclick", "javascript:document.forms[0].txtFixedVal.focus();")
            ckbSerialFormat.Attributes.Add("onclick", "javascript:document.forms[0].ddlSerialFormat.focus();")
            btnAddNormalTag.Attributes.Add("onclick", "javascript:if(document.forms[0].txtTagCode.value==''){return false;}else{NormalTagAdd();return(false);}")
            'shelf tag
            btnAddShelfTag.Attributes.Add("onclick", "javascript:ShelfTagAdd();return(false);")
            btnClose.Attributes.Add("OnClick", "self.close();return false;")
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Call Dispose on your base class.
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub
    End Class
End Namespace