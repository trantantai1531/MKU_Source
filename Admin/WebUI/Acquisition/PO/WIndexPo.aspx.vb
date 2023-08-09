' Purpose: display purchase orders index form
' Creator: Oanhtn
' Created Date: 19/03/2004
' Modification history
'   - Add link

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WIndexPo
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            ' Tab1
            'lnkAcqRequest.NavigateUrl = "WAcqRequest.aspx"
            'lnkAcqSRequest.NavigateUrl = "WAcqSRequest.aspx"
            'lnkOrderAccepted.NavigateUrl = "WViewItemOrder.aspx"
            'lnkAcceptedOrderReport.NavigateUrl = "WPOPrintSearch.aspx"
            '' Tab2
            'lnkPoProcess.NavigateUrl = "WContractIndex.aspx"
            'lnkSendPo.NavigateUrl = "WSendPOSearch.aspx"
            'lnkLocationDis.NavigateUrl = "WSendPOSeperatedSearch.aspx"
            '' Tab3
            'lnkWFormComplaintFrame.NavigateUrl = "WPOTemplate.aspx?TemplateType=8"
            'lnkWFormPostFrame.NavigateUrl = "WPOTemplate.aspx?TemplateType=7"
            'lnkWFormRequestFrame.NavigateUrl = "WPOTemplate.aspx?TemplateType=9"
            'lnkWFormSeparatedStoreFrame.NavigateUrl = "WPOTemplate.aspx?TemplateType=10"
            '' Tab4
            'lnkWAcqVendor.NavigateUrl = "WVendorMan.aspx"
        End Sub

        'Private Sub imgWFormComplaintFrame_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWFormComplaintFrame.Click
        '    Response.Redirect("WPOTemplate.aspx?TemplateType=8")
        'End Sub

        'Private Sub imgWFormPostFrame_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWFormPostFrame.Click
        '    Response.Redirect("WPOTemplate.aspx?TemplateType=7")
        'End Sub

        'Private Sub imgWFormRequestFrame_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWFormRequestFrame.Click
        '    Response.Redirect("WPOTemplate.aspx?TemplateType=9")
        'End Sub

        'Private Sub imgWFormSeparatedStoreFrame_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWFormSeparatedStoreFrame.Click
        '    Response.Redirect("WPOTemplate.aspx?TemplateType=10")
        'End Sub

        'Private Sub img_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        '    Response.Redirect("WAcqWaitingPO.aspx")
        'End Sub

        'Private Sub imgWAcqVendor_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWAcqVendor.Click
        '    Response.Redirect("WVendorMan.aspx")
        'End Sub

        'Private Sub imgLocationDis_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgLocationDis.Click
        '    Response.Redirect("WSendPOSeperatedSearch.aspx")
        'End Sub

        'Private Sub imgSendPo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSendPo.Click
        '    Response.Redirect("WSendPOSearch.aspx")
        'End Sub

        'Private Sub imgPoProcess_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPoProcess.Click
        '    Response.Redirect("WContractIndex.aspx")
        'End Sub

        'Private Sub imgOrderAccepted_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOrderAccepted.Click
        '    Response.Redirect("WViewItemOrder.aspx")
        'End Sub

        'Private Sub imgAcqSRequest_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAcqSRequest.Click
        '    Response.Redirect("WAcqSRequest.aspx")
        'End Sub

        'Private Sub imgAcqRequest_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAcqRequest.Click
        '    Response.Redirect("WAcqRequest.aspx")
        'End Sub

        'Private Sub ImageButton4_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        '    Response.Redirect("WPOPrintSearch.aspx")
        'End Sub

        'Private Sub ImgAcceptedOrderReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgAcceptedOrderReport.Click
        '    Response.Redirect("WPOPrintSearch.aspx")
        'End Sub
    End Class
End Namespace