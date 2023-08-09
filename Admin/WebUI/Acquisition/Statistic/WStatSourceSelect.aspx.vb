' Class: WStatSourceSelect
' Puspose: allow select time range for creating statistic by acqsource
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:


Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatSourceSelect
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
            Call BindJS()
        End Sub

        ' Method: BindJS
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("LibolCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WStatSourceJs", "<script language='javascript' src='../Js/Statistic/WStatSource.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfToDate, txtToDate, lblErrorMsg.Text)
            SetOnclickCalendar(hrfFromDate, txtFromDate, lblErrorMsg.Text)

            btnStatistic.Attributes.Add("OnClick", "javascript:CheckForSubmit('" & lblFromDate.Text & "','" & lblToDate.Text & "'); return false;")
        End Sub
    End Class
End Namespace