' Class: WCheckOut 
' Puspose: Display checkout form
' Creator: Tuanhv
' CreatedDate: 19/08/2004
' Modification History:
'   + 17/04/2005 by Oanhtn: Review & update

Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckOut
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label9 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Label8 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Label10 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Label11 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Overduelist As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents Label7 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents UnDueDate As System.Web.UI.WebControls.CheckBox
        Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg5 As System.Web.UI.WebControls.Label
        Protected WithEvents hidRemain As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBDB As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            txtCreatedDate.Text = Session("ToDay")
            Session("CheckForm") = "CheckOut"
            lnkAddPatron.Visible = False
            If Not Page.IsPostBack Then
                Call BindData()
                txtCreatedTime.Text = CStr(Hour(Now)).PadLeft(2, "0") & ":" & CStr(Minute(Now)).PadLeft(2, "0") & ":" & CStr(Second(Now)).PadLeft(2, "0")
            End If
            txtDueTime.Text = "23:00:00"
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(57) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text.Trim)
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Session("Remain") = 0
            Session("TransactionID") = Nothing

            ' Init objBDB object
            objBDB.ConnectionString = Session("ConnectionString")
            objBDB.DBServer = Session("DBServer")
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBDB.Initialize()
        End Sub
        Private Sub BindData()
            Try
                objBDB.SQLStatement = "SELECT Val FROM Sys_tblParameter WHERE  NAME='RESERVATION_REQUIRED_INFO'"
                Dim tblResult As DataTable = objBDB.RetrieveItemInfor
                If Not tblResult Is Nothing And tblResult.Rows.Count > 0 Then
                    If CInt(tblResult.Rows(0).Item("Val")) = 1 Then
                        Page.RegisterClientScriptBlock("LoadFrame1", "<script language = 'javascript'>parent.document.getElementById('frmCheckOut').setAttribute('rows','*,25');</script>")
                    Else
                        Page.RegisterClientScriptBlock("LoadFrame2", "<script language = 'javascript'>parent.document.getElementById('frmCheckOut').setAttribute('rows','*,0');</script>")
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub
        ' Method: BindScript
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/CheckOut/WCheckOut.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            lnkSearchPatron.Target = "CheckOutMain"
            lnkSearchPatron.NavigateUrl = "../WSearchPatron.aspx"

            lnkAddPatron.Target = "CheckOutMain"
            lnkAddPatron.NavigateUrl = "../WAddPatron.aspx"

            lnkCheckPatronCode.Target = "CheckOutMain"
            lnkCheckPatronCode.NavigateUrl = "../WCheckPatronCode.aspx?"

            lnkAddCopyNumber.Target = "CheckOutMain"
            lnkAddCopyNumber.NavigateUrl = "../WAddCopyNumber.aspx"

            lnkSearchCopyNumber.Target = "CheckOutMain"
            lnkSearchCopyNumber.NavigateUrl = "../WSearchCopyNumber.aspx"

            lnkCheckOutInLibrary.NavigateUrl = "WCheckOutInLibrary.aspx"
            lnkMuonDK.NavigateUrl = "WCheckOutCopyNumber.aspx"
            lnkReservRequest.NavigateUrl = "javascript:OpenWindow('../WReservations.aspx?x=" & GenRandomNumber(10) & "','Reservation',600,400,150,50);"
            lnkViewHoldTransaction.NavigateUrl = "javascript:OpenWindow('../WViewHoldTransaction.aspx?x=" & GenRandomNumber(10) & "','Reservation',600,400,150,50);"

            'txtPatronCode.Attributes.Add("OnChange", "javascript:txtPatronCodeEvent('" & ddlLabel.Items(3).Text & "', " & GenRandomNumber(10) & ");")
            txtPatronCode.Attributes.Add("onkeydown", "javascript:txtPatronCodeEventkeypress('" & ddlLabel.Items(3).Text & "', " & GenRandomNumber(10) & ",event);")
            txtCopyNumber.Attributes.Add("onkeydown", "javascript:txtCopyNumberEvent('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "', '" & ddlLabel.Items(7).Text & "', " & GenRandomNumber(10) & ");")

            txtCreatedDate.Attributes.Add("onFocus", "javascript:ChangeTab('txtCreatedDate');")
            txtCreatedDate.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(2).Text & " (" & Session("DateFormat") & ")');")
            txtCreatedDate.ToolTip = Session("DateFormat")

            txtCreatedTime.Attributes.Add("onFocus", "javascript:ChangeTab('txtCreatedTime');")
            txtCreatedTime.Attributes.Add("onChange", "javascript:CheckTime(this,'" & ddlLabel.Items(1).Text & "');")

            txtDueDate.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(2).Text & " (" & Session("DateFormat") & ")');")
            txtDueDate.Attributes.Add("onFocus", "javascript:ChangeTab('txtDueDate');")
            txtDueDate.ToolTip = Session("DateFormat")

            txtDueTime.Attributes.Add("onFocus", "javascript:ChangeTab('txtDueTime');")
            txtDueTime.Attributes.Add("onChange", "javascript:CheckTime(this,'" & ddlLabel.Items(1).Text & "');")

            ' txtPatronCode.Attributes.Add("onFocus", "javascript:ChangeTab('txtPatronCode');")
            'txtCopyNumber.Attributes.Add("onFocus", "javascript:ChangeTab('txtCopyNumber');")

            chkExemptQuota.Attributes.Add("OnClick", "javascript:chkExemptQuotaEvent();")
            chkIndefiniteDue.Attributes.Add("OnClick", "javascript:chkIndefiniteDueEvent();")

            btnPrint.Attributes.Add("OnClick", "javascript:parent.CheckOutMain.location.href='WCheckOutPrintResult.aspx'; return false;")
            btnEnd.Attributes.Add("OnClick", "javascript:parent.CheckOutMain.location.href='WCheckOutPrintResult.aspx?EndSession=1'; return false;")
            btnCheckOut.Attributes.Add("OnClick", "javascript:CheckOut('" & ddlLabel.Items(1).Text & "', '" & ddlLabel.Items(2).Text & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "', '" & ddlLabel.Items(6).Text & "', " & GenRandomNumber(10) & "); return false;")
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace