' Purpose: display acquisition index form
' Creator: Oanhtn
' Created Date: 19/03/2004
' Modification history
'    - 22/03/2004 by KhoaNA

Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WIndexAcq
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Not CheckPemission() Then
                    Call WritePermErrorMssg()
                End If
                'lnkCataForm.NavigateUrl = "WCataForm.aspx"
                'lnkWUpdate.NavigateUrl = "WUpdate.aspx"
                'lnkOrdinalNumberChange.NavigateUrl = "WOrdinalNumberChange.aspx"
                'lnkWRegisterDKCBForm.NavigateUrl = "WCopyNumberTemplate.aspx"
                'lnkWPriceBookTagFormatFrame.NavigateUrl = "WBookLabelTemplateDisplay.aspx"
                'lnkWAcquisitionReportedFrame.NavigateUrl = "WAcqReportTemplateDisplay.aspx"
                'lnkWAcqBarCode.NavigateUrl = "WBarcodeForm.aspx"
                'lnkWAcqPrintLabel.NavigateUrl = "WLabelPrintSearch.aspx"
                'lnkWDKCBAcquisitionReportedFrame.NavigateUrl = "WACQForm.aspx"
                'lnkWAcqReportCopyNumberRelease.NavigateUrl = "WCopyNumRemF.aspx"
                'lnkWComprehensiveReportBook.NavigateUrl = "WComprehReportBookS.aspx"
                'lnkWUpdate.NavigateUrl = "WCopyNumber.aspx"
            Catch ex As Exception

            End Try

        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try

            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Private Sub imgCataForm_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCataForm.Click
        '    Response.Redirect("WCataForm.aspx")
        'End Sub

        'Private Sub imgOrdinalNumberChange_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgOrdinalNumberChange.Click
        '    Response.Redirect("WOrdinalNumberChange.aspx")
        'End Sub

        'Private Sub imgWAcqBarCode_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWAcqBarCode.Click
        '    Response.Redirect("WBarcodeForm.aspx")
        'End Sub

        'Private Sub imgWAcquisitionReportedFrame_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWAcquisitionReportedFrame.Click
        '    Response.Redirect("WAcqReportTemplateDisplay.aspx")
        'End Sub
        'Private Sub imgWDKCBAcquisitionReportedFrame_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWDKCBAcquisitionReportedFrame.Click
        '    Response.Redirect("WACQForm.aspx")
        'End Sub

        'Private Sub imgWPriceBookTagFormatFrame_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWPriceBookTagFormatFrame.Click
        '    Response.Redirect("WBookLabelTemplateDisplay.aspx")
        'End Sub

        'Private Sub imgWRegisterDKCBForm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWRegisterDKCBForm.Click
        '    Response.Redirect("WCopyNumberTemplate.aspx")
        'End Sub

        'Private Sub imgWUpdate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWUpdate.Click
        '    Response.Redirect("WCopyNumber.aspx")
        'End Sub
        'Private Sub imgWAcqPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWAcqPrintLabel.Click
        '    Response.Redirect("WLabelPrintSearch.aspx")
        'End Sub

        'Private Sub imgWAcqReportCopyNumberRelease_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWAcqReportCopyNumberRelease.Click
        '    Response.Redirect("WCopyNumRemF.aspx")
        'End Sub

        'Private Sub imgComprehensiveReportBook_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgComprehensiveReportBook.Click
        '    Response.Redirect("WComprehReportBookS.aspx")
        'End Sub

        'Private Sub imgBarCodeTemplate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBarCodeTemplate.Click
        '    Response.Redirect("WBarcodeTemplateEdit.aspx")
        'End Sub
    End Class
End Namespace