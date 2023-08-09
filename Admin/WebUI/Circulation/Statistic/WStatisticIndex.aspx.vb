' Class: WStatisticPatronGroup
' Puspose: Static allow patron group
' Creator: Tuanhv
' CreatedDate: 06/09/2004
' Modification History:

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticIndex
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkScheduleWork As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblDepSchedule As System.Web.UI.WebControls.Label
        Protected WithEvents lblLockCard As System.Web.UI.WebControls.Label
        Protected WithEvents lnkChangeLoan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblChangeLoan As System.Web.UI.WebControls.Label
        Protected WithEvents lnkPhotoMan As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblPhotoMan As System.Web.UI.WebControls.Label
        Protected WithEvents ddl As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call BindScript()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPolicyIndex.js'></script>")

            'lnkReportOnLoanCopy.NavigateUrl = "WReportOnLoanCopy.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticAnnual.NavigateUrl = "WStatisticAnnual.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticTopCopy.NavigateUrl = "WStatisticTopCopy.aspx?x=" & GenRandomNumber(10)
            'lnkReportLoanCopy.NavigateUrl = "WReportLoanCopy.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticMonth.NavigateUrl = "WStatisticMonth.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticTopPatron.NavigateUrl = "WStatisticTopPatron.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticDay.NavigateUrl = "WStatisticDay.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticTop20.NavigateUrl = "WStatisticTop20.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticPatronGroup.NavigateUrl = "WStatisticPatronGroup.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticHoldingPlace.NavigateUrl = "WStatisticHoldingPlace.aspx?x=" & GenRandomNumber(10)
            'lnkStatisticPolicy.NavigateUrl = "WStatisticPolicy.aspx?x=" & GenRandomNumber(10)
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Statistic
            If Not CheckPemission(67) Then
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
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