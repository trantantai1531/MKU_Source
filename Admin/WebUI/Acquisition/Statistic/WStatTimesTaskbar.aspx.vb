Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatTimesTaskbar
        Inherits clsWBase

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            BindScript()
            CheckFormPermission()
        End Sub

        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WStatTimesTaskbarJs", "<script language='javascript' src='../Js/Statistic/WStatTimes.js'></script>")
            btnClose.Attributes.Add("OnClick", "parent.parent.mainacq.location.href='WStatIndex.aspx';return(false);")


            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabel.Items(2).Text)

            btnStatistic.Attributes.Add("OnClick", "TransferData();return(false);")
            btnExport.Attributes.Add("OnClick", "TransferDataExport();return(false);")
        End Sub
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(3).Text)
            End If
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace

