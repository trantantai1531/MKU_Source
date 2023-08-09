Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WField006ID4
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtField3 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtField4 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtField6 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtField7 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtField8 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtField9 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtField11 As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtField12 As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblLabel21 As System.Web.UI.WebControls.Label
        Protected WithEvents ddlField16 As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJS()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary javascript functions
        Private Sub BindJS()
            Dim strWorkField As String = Request("WorkField")
            Dim strSendField As String = Request("SendField")
            Dim strJS As String = ""
            strJS = strJS & "var intFileID = 4;" & Chr(13)
            strJS = strJS & "var strSendField = '" & strSendField & "';" & Chr(13)
            strJS = strJS & "var strWorkField = '" & strWorkField & "';" & Chr(13)
            strJS = strJS & "var strFieldIDs = ',2,5,10,';" & Chr(13)

            Page.RegisterClientScriptBlock("RegvarJs", "<script language = 'javascript'>" & strJS & "</script>")
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WCodedFieldHelpJs", "<script language = 'javascript' src = '../../Js/Catalogue/CodedFields/WCodedFieldHelp.js'></script>")

            ddlTemp2.Attributes.Add("OnChange", "javascript: LoadTextData('ddlTemp2','txtField2');")
            ddlTemp5.Attributes.Add("OnChange", "javascript: LoadTextData('ddlTemp5','txtField5');")

            btnPreview.Attributes.Add("OnClick", "javascript:PreView(12); return false;")
            btnUpdate.Attributes.Add("OnClick", "javascript:Update(12)")
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); return false")
            btnClose.Attributes.Add("OnClick", "self.close();")
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