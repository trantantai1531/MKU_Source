Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WToolIndex
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
            'Put user code to initialize the page here
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Call BindScript()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Tool/WToolIndex.js'></script>")
        End Sub

        ' Initialize method
        Private Sub Initialize()

        End Sub
        Private Sub imgRequestMode_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRequestMode.Click
            Response.Redirect("WRequestModeMan.aspx")
        End Sub

        Private Sub imgPack_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPack.Click
            Response.Redirect("WPackTemplateMan.aspx")
        End Sub

        Private Sub imgRefuse_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRefuse.Click
            Response.Redirect("WRefuseTemplateMan.aspx")
        End Sub

        Private Sub imgBill_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBill.Click
            Response.Redirect("WBillTemplateMan.aspx")
        End Sub

        Private Sub imgNote_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNote.Click
            Response.Redirect("WNoticeTemplateMan.aspx")
        End Sub

        ' Page UnLoad event
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
