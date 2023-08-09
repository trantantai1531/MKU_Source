Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Serial
    Partial Class SubjectAdd
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblDictionary As System.Web.UI.WebControls.Label
        Protected WithEvents txtDictionary As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim objBCDB As New clsBCommonDBSystem
        Dim objBCSP As New clsBCommonStringProc
        Private objBArticle As New clsBArticle
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJS()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            objBCDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDB.DBServer = Session("DBServer")
            objBCDB.ConnectionString = Session("ConnectionString")
            Call objBCDB.Initialize()

            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()

            objBArticle.InterfaceLanguage = Session("InterfaceLanguage")
            objBArticle.DBServer = Session("DBServer")
            objBArticle.ConnectionString = Session("ConnectionString")
            Call objBArticle.Initialize()
        End Sub
        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("onClick", "self.close();")
            btnAdd.Attributes.Add("onClick", "javascript:if (CheckNull(document.forms[0].txtSubject)) {alert('" & ddlLabel.Items(9).Text & "'); return false;}")
        End Sub
        Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim strSQL As String = ""
            Dim strSubject As String = ""
            strSubject = objBCSP.ConvertItBack(txtSubject.Text.Trim)
            objBArticle.AddSubject(strSubject)
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBArticle.ErrorMsg, ddlLabel.Items(0).Text, objBArticle.ErrorCode)
            Page.RegisterClientScriptBlock("AddItem", "<script language='javascript'>AddItem(opener.document.forms[0].ddlSubject, '" & txtSubject.Text.Trim & "', '" & txtSubject.Text.Trim & "');</script>")
            Page.RegisterClientScriptBlock("LoadBack", "<script language='javascript'>opener.document.forms[0].hid.value = '" & txtSubject.Text.Trim & "';</script>")

        End Sub
    End Class
End Namespace
