' Class: WMenuDic
' Popurse: 
' CreatedDate: 19/04/2004
' Creator: Sondp.
'  Modification history 
'    - 03/03/2005 by Tuanhv: review

Namespace eMicLibAdmin.WebUI.Catalogue
    Public Class WMenuDic
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkClassification As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkAuthority As System.Web.UI.WebControls.HyperLink

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJavascript()
            lnkAuthority.NavigateUrl = "javascript:parent.MainDic.location.href='WDicClassification.aspx';self.location.href='WMenuDic.aspx';"
            lnkClassification.NavigateUrl = "javascript:parent.MainDic.location.href='WDicAuthority.aspx';self.location.href='WMenuDic.aspx';"
        End Sub

        ' Methord: BindJavascript
        ' Popurse: Bind javascript for all control need
        Private Sub BindJavascript()
            Response.Write(String.Format("<link href=""{0}"" type=""text/css"" rel=""StyleSheet"">", Me.GetStyleSheetURL("Catalogue")))
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace