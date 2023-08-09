' Class: WAcqIndex 
' Puspose: Show acqindex page
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WAcqIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label7 As System.Web.UI.WebControls.Label
        Protected WithEvents Label9 As System.Web.UI.WebControls.Label
        Protected WithEvents Label13 As System.Web.UI.WebControls.Label
        Protected WithEvents Label15 As System.Web.UI.WebControls.Label
        Protected WithEvents lnkSetRe As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkBin As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Call Initialize()
            lnkShowAnnualSumHolding.Attributes.Add("OnClick", "javascript:location.href='WShowAnnualSumHolding.aspx';parent.Hiddenbase.location.href='../WSaveSession.aspx';")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
        End Sub
        'Private Sub imgCreateRequest_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCreateRequest.Click
        '    Response.Redirect("WACQsRequest.aspx")
        'End Sub

        'Private Sub imgViewRequest_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgViewRequest.Click
        '    Response.Redirect("WViewRequestList.aspx")
        'End Sub

        'Private Sub imgDailyRegister_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDailyRegister.Click
        '    Response.Redirect("WRegisterFrame.aspx")
        'End Sub

        'Private Sub imgDailyReceive_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDailyReceive.Click
        '    Response.Redirect("WReceiveFrame.aspx")
        'End Sub

        'Private Sub imgShowAnnualSumHolding_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgShowAnnualSumHolding.Click
        '    Response.Redirect("WShowAnnualSumHolding.aspx")
        'End Sub

        'Private Sub imgAcquire_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgAcquire.Click
        '    Response.Redirect("WAcquire.aspx")
        'End Sub

        'Private Sub imgSetRegularity_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSetRegularity.Click
        '    Response.Redirect("WSetRegularity.aspx")
        'End Sub

        'Private Sub imgRegister_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgRegister.Click
        '    Response.Redirect("WCreateIssue.aspx")
        'End Sub

        'Private Sub imgReceive_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgReceive.Click
        '    Response.Redirect("WReceive.aspx")
        'End Sub

        'Private Sub imgViewSummaryHolding_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgViewSummaryHolding.Click
        '    Response.Redirect("WViewInListMode.aspx")
        'End Sub

        'Private Sub imgBinding_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBinding.Click
        '    Response.Redirect("WBinding.aspx")
        'End Sub

        'Private Sub imgUpdateSummaryHolding_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgUpdateSummaryHolding.Click
        '    Response.Redirect("WSummaryHoldingManagement.aspx")
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

    End Class
End Namespace