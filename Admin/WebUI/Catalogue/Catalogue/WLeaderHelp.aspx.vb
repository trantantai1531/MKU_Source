' WLeaderHelp class
' Purpose: allow user enter ItemLeader
' Creator: Oanhtn
' CreatedDate: 16/05/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WLeaderHelp
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim overlay As String
            overlay = Request("overlay")
            hid.value = overlay
            Call BindJavascripts()
        End Sub

        ' BindJavascripts method
        Private Sub BindJavascripts()
            Page.RegisterClientScriptBlock("WLeaderHelp", "<script language = 'javascript' src = '../Js/Catalogue/WLeaderHelp.js'></script>")
            Page.RegisterClientScriptBlock("WCata", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")

            btnUpdate.Attributes.Add("OnClick", "javascript:CreateLeader(0); self.close();")
            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset();")
            btnPreview.Attributes.Add("OnClick", "javascript:PreView();")
            btnClose.Attributes.Add("OnClick", "self.close();")
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
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