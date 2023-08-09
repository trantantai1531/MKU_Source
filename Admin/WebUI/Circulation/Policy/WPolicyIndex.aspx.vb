Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPolicyIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgCirculationTemplate As System.Web.UI.WebControls.ImageButton
        Protected WithEvents lnkCirculationTemplate As System.Web.UI.WebControls.HyperLink
        Protected WithEvents CirculationTemplate As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Call Initialze()
            Call LoadStyle_JS()
        End Sub

        Private Sub Initialze()
        End Sub

        Private Sub LoadStyle_JS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPolicyIndex.js'></script>")
        End Sub

        ' Event: imgScheduleWork_Click
        'Private Sub imgScheduleWork_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgScheduleWork.Click
        '    Response.Redirect("WScheduleUpdate.aspx")
        'End Sub

        '' Event: ImgLockCard_Click
        'Private Sub ImgLockCard_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgLockCard.Click
        '    Response.Redirect("WLockCard.aspx")
        'End Sub

        '' Event: ImgPolicy_Click
        'Private Sub ImgPolicy_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgPolicy.Click
        '    Response.Redirect("WPolicyManagement.aspx")
        'End Sub

        '' Event: imgChangeLoan_Click
        'Private Sub imgChangeLoan_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgChangeLoan.Click
        '    Response.Redirect("WChangeLoanType.aspx")
        'End Sub

        '' Event: imgPhotoMan_Click
        'Private Sub imgPhotoMan_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPhotoMan.Click
        '    Response.Redirect("WPhotocopyManagement.aspx")
        'End Sub

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

        'Private Sub imgCheckInTemplate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCheckInTemplate.Click
        '    Response.Redirect("WCirculationTemplate.aspx?Template=1")
        'End Sub

        'Private Sub imgCheckOutTemplate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCheckOutTemplate.Click
        '    Response.Redirect("WCirculationTemplate.aspx?Template=2")
        'End Sub
    End Class
End Namespace