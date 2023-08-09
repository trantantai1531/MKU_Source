Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WIntroduce
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
            Call BindJavaScript()
        End Sub

        ' BindJavaScript method
        Private Sub BindJavaScript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WIntroduce.js'></script>")
        End Sub

        ' Event: imgCheckOut_Click
        Private Sub imgCheckOut_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCheckOut.Click
            Response.Redirect("CheckOut/WCheckOutIndex.aspx")
        End Sub

        'Event: imgCheckIn_Click
        Private Sub imgCheckIn_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCheckIn.Click
            Response.Redirect("CheckIn/WCheckInIndex.aspx")
        End Sub

        ' Event: imgOnHold_Click
        Private Sub imgOnHold_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOnHold.Click
            Response.Redirect("Statistic/WReportOnLoanCopy.aspx")
        End Sub

        ' Event: imgLoaned_Click
        Private Sub imgLoaned_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLoaned.Click
            Response.Redirect("Statistic/WReportLoanCopy.aspx")
        End Sub

        ' Event: ImgPolicy_Click
        Private Sub ImgPolicy_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgPolicy.Click
            Response.Redirect("Policy/WPolicyIndex.aspx")
        End Sub

        ' Event: ImgChangeType_Click
        Private Sub ImgChangeType_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgChangeType.Click
            Response.Redirect("Policy/WChangeLoanType.aspx")
        End Sub

        ' Event: imgOverDue_Click
        Private Sub imgOverDue_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOverDue.Click
            Response.Redirect("Overdue/WOverdueList.aspx")
        End Sub

        ' Event: imgHoldTrans_Click
        Private Sub imgHoldTrans_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgHoldTrans.Click
            Response.Redirect("Hold/WHoldTransactionManage.aspx")
        End Sub

        ' Event: imgLockCard_Click
        Private Sub imgLockCard_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLockCard.Click
            Response.Redirect("Policy/WLockCard.aspx")
        End Sub

        ' Event: imgStat_Click
        Private Sub imgStat_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgStat.Click
            Response.Redirect("Statistic/WStatisticIndex.aspx")
        End Sub

        ' Event: imgMakeSchedule_Click
        Private Sub imgMakeSchedule_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMakeSchedule.Click
            Response.Redirect("Policy/WScheduleView.aspx")
        End Sub

        ' Event: imgOverDueSendMail_Click
        Private Sub imgOverDueSendMail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOverDueSendMail.Click
            Response.Redirect("Overdue/WOverdueList.aspx")
        End Sub

        ' Event: imgPhotocopyMan_Click
        Private Sub imgPhotocopyMan_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPhotocopyMan.Click
            Response.Redirect("Policy/WPhotocopyManagement.aspx")
        End Sub

        ' Event: imgAccountMan_Click
        Private Sub imgAccountMan_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAccountMan.Click
            Response.Redirect("Accounting/WAccountManagement.aspx")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            MyBase.Dispose()
            Me.Dispose()
        End Sub
    End Class
End Namespace
