' WIndexSto class
' Purpose: display store index form
' Creator: Oanhtn
' CreatedDate: 19/03/2004
' History Modification: 
'   - 23/03/2004 by Oanhtn: add resource, style

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WIndexSto
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkLocationClose As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblLocationClose As System.Web.UI.WebControls.Label
        Protected WithEvents lnkLocationPosition As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblLocationPosition As System.Web.UI.WebControls.Label
        Protected WithEvents lnkShelfPosition As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblShelfPosition As System.Web.UI.WebControls.Label
        Protected WithEvents lnkNewInventory As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblNewInventory As System.Web.UI.WebControls.Label
        Protected WithEvents lnkLocationOpen As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblLocationOpen As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Call Initialize()
            Call NavigateURL()
            ' Create resource files
            'Me.ExportResource("c:\inetpub\wwwroot\Libol60\WebUI\Resources\Images\Acquisition\Store\WIndexStoIR.vi.resx", True)
            'Me.ExportResource("c:\inetpub\wwwroot\Libol60\WebUI\Resources\LabelString\Acquisition\Store\WIndexStoSR.en.resx", False)
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

        End Sub

        ' NavigateURL method
        ' Purpose: nevigateURL for all link controls 
        Private Sub NavigateURL()
            ' First tab
            'lnkWLocationClose.NavigateUrl = "WCloseLoc.aspx"
            'lnkWInventoryNew.NavigateUrl = "WCreateInventory.aspx"
            'lnkWInventoryStore.NavigateUrl = "WExecuteInventory.aspx"
            'lnkWInventoryResultForm.NavigateUrl = "WViewInventoryFrame.aspx"
            'lnkWInventoryReport.NavigateUrl = "WSearchPrintInventory.aspx"
            'lnkWLocationOpen.NavigateUrl = "WOpenLoc.aspx"
            'lnkCopyNumberReport.NavigateUrl = "WGenCopyNumListF.aspx"


            '' Second tab
            'lnkWHoldingLibrary.NavigateUrl = "WLibMan.aspx"
            'lnkWHoldingLocation.NavigateUrl = "WLocMan.aspx"
            ''lnkWLocPos.NavigateUrl = "WLocPos.aspx"
            ''lnkWShelfPos.NavigateUrl = "WShelfPos.aspx"


            '' Third tab
            ''lnkFrmRecv.NavigateUrl = "WReceiveFrame.aspx"
            'lnkWFrmInv.NavigateUrl = "WInvenFrame.aspx"
            'lnkWFrmLost.NavigateUrl = "WLostFrame.aspx"
            'lnkWLiquidateForm.NavigateUrl = "WHoldingLocRemove.aspx"
            'lnkWRemoveStoreForm.NavigateUrl = "WMoveLoc.aspx"
            'lnkReceiveUnlock.NavigateUrl = "WReceiveUnlock.aspx"
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Private Sub imgWHoldingLibrary_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWHoldingLibrary.Click
        '    Response.Redirect("WLibMan.aspx")
        'End Sub

        'Private Sub imgWHoldingLocation_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWHoldingLocation.Click
        '    Response.Redirect("WLocMan.aspx")
        'End Sub

        'Private Sub imgWInventoryNew_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWInventoryNew.Click
        '    Response.Redirect("WCreateInventory.aspx")
        'End Sub

        'Private Sub imgWLocationClose_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWLocationClose.Click
        '    Response.Redirect("WCloseLoc.aspx")
        'End Sub

        'Private Sub imgWInventoryStore_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWInventoryStore.Click
        '    Response.Redirect("WExecuteInventory.aspx")
        'End Sub

        'Private Sub imgWInventoryReport_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWInventoryReport.Click
        '    Response.Redirect("WSearchPrintInventory.aspx")
        'End Sub

        'Private Sub ingWLocationOpen_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ingWLocationOpen.Click
        '    Response.Redirect("WOpenLoc.aspx")
        'End Sub

        'Private Sub imgWInventoryResultForm_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWInventoryResultForm.Click
        '    Response.Redirect("WViewInventoryFrame.aspx")
        'End Sub

        'Private Sub imgWLocPos_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWLocPos.Click
        '    Response.Redirect("WLocPos.aspx")
        'End Sub

        'Private Sub imgWShelfPos_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWShelfPos.Click
        '    Response.Redirect("WShelfPos.aspx")
        'End Sub

        'Private Sub imgWFrmRecv_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWFrmRecv.Click
        '    Response.Redirect("WReceiveFrame.aspx")
        'End Sub

        'Private Sub imgWFrmInv_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWFrmInv.Click
        '    Response.Redirect("WInvenFrame.aspx")
        'End Sub

        'Private Sub imgWFrmLost_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWFrmLost.Click
        '    Response.Redirect("WLostFrame.aspx")
        'End Sub

        'Private Sub imgWRemoveStoreForm_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWRemoveStoreForm.Click
        '    Response.Redirect("WMoveLoc.aspx")
        'End Sub

        'Private Sub imgWLiquidateForm_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWLiquidateForm.Click
        '    Response.Redirect("WHoldingLocRemove.aspx")
        'End Sub

        'Private Sub imgGenListCopynum_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGenListCopynum.Click
        '    Response.Redirect("WGenCopyNumListF.aspx")
        'End Sub

        'Private Sub imgReceiveUnlock_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgReceiveUnlock.Click
        '    Response.Redirect("WReceiveUnlock.aspx")
        'End Sub
    End Class
End Namespace