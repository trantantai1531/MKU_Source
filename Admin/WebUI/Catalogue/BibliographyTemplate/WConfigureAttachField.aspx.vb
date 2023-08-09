' WConfigureAttachField class
' Purpose: configure Attach field
' Creator: Oanhtn
' CreatedDate: 10/05/2004
' Modification history 
'    - 01/03/2005 by Tuanhv: review

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WConfigureAttachField
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
            Call BindJavascripts()
        End Sub

        ' BindJavascripts method
        ' Purpose: some javascript process 
        Private Sub BindJavascripts()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WConfigureAttachFieldJs", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WConfigureAttachField.js'></script>")
            btnClose.Attributes.Add("OnClick", "javascript:SubmitForm();")
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