' Class: WRenewPatronCard
' Puspose: Renew for expired patron card
' Creator: Oanhtn
' CreatedDate: 03/09/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WRenewPatronCard
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

        ' Declare variables
        Private objBPatron As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            Call objBPatron.Initialize()

            ' Set PatronCode
            lblPatronCode.Text = Request("PatronCode")
            hidLoanMode.Value = Request("LoanMode")
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            Me.RegisterCalendar("..")
            SetOnclickCalendar(lnkCal, txtNewDate, ddlLabel.Items(2).Text)

            btnRenew.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtNewDate)) {alert('" & ddlLabel.Items(3).Text & "'); return false;}")
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' Method: RenewPatronCard
        ' Purpose: Renew patron card
        Private Sub RenewPatronCard()
            Dim strNewDate As String = txtNewDate.Text.Trim

            objBPatron.PatronCode = lblPatronCode.Text.Trim
            Call objBPatron.RenewPatronCard(strNewDate)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)

            ' WriteLog
            Call WriteLog(45, ddlLabel.Items(4).Text & ": " & lblPatronCode.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Refresh opener window
            Page.RegisterClientScriptBlock("RefreshOpenerJs", "<script language = 'javascript'>opener.top.main.Workform.CheckOutMain.location.href='WCheckPatronCode.aspx?PatronCode=" & lblPatronCode.Text & "&LoanMode=" & hidLoanMode.Value & "'; self.close();</script>")
        End Sub

        ' Event: btnRenew_Click
        ' Purpose: Renew PatronCard
        Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
            Call RenewPatronCard()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace