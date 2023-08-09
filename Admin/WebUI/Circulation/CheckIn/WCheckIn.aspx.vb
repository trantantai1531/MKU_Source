' Class: WCheckIn 
' Puspose: Display CheckIn form
' Creator: Oanhtn
' CreatedDate: 06/09/2004
' Modification history:
'   - 17/04/2005 by Oanhtn

Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckIn
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidLoanMode As System.Web.UI.HtmlControls.HtmlInputHidden


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
            Session("CheckForm") = "CheckIn"
            Session("CopyNumber") = Nothing
            Session("TransactionIDs") = Nothing
            Session("TransactionID") = Nothing
            Session("Remain") = Nothing
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(58) Then
                Call WriteErrorMssg(ddlLabel.Items(7).Text.Trim)
            End If
        End Sub
        Private Sub BindData()
            Try
                objBDB.SQLStatement = "SELECT Val FROM Sys_tblParameter WHERE NAME='RESERVATION_REQUIRED_INFO'"
                Dim tblResult As DataTable = objBDB.RetrieveItemInfor
                If Not tblResult Is Nothing And tblResult.Rows.Count > 0 Then
                    If CInt(tblResult.Rows(0).Item("Val")) = 1 Then
                        Page.RegisterClientScriptBlock("LoadFrame1", "<script language = 'javascript'>parent.document.getElementById('frmCheckIn').setAttribute('rows','*,25');</script>")
                    Else
                        Page.RegisterClientScriptBlock("LoadFrame2", "<script language = 'javascript'>parent.document.getElementById('frmCheckIn').setAttribute('rows','*,0');</script>")
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub
        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Response.Expires = 0
            txtCheckInDate.Text = Session("ToDay")

            ' Init objBDB object
            objBDB.ConnectionString = Session("ConnectionString")
            objBDB.DBServer = Session("DBServer")
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBDB.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/CheckIn/WCheckIn.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            lnkSearchPatron.Target = "CheckInMain"
            lnkSearchPatron.NavigateUrl = "../WSearchPatron.aspx"
            lnkAddPatron.Target = "CheckInMain"
            lnkAddPatron.NavigateUrl = "../WAddPatron.aspx"
            lnkCheckPatronCode.Target = "CheckInMain"
            lnkCheckPatronCode.NavigateUrl = "../WCheckPatronCode.aspx"

            lnkSearchCopyNumber.Target = "CheckInMain"
            lnkSearchCopyNumber.NavigateUrl = "../WSearchCopyNumber.aspx?CheckIn=1"
            lnkAddCopyNumber.Target = "CheckInMain"
            lnkAddCopyNumber.NavigateUrl = "../WAddCopyNumber.aspx"

            txtCheckInDate.Attributes.Add("onFocus", "javascript:ChangeTab('txtCheckInDate');")
            txtCheckInTime.Attributes.Add("onFocus", "javascript:ChangeTab('txtCheckInTime');")
            txtPatronCode.Attributes.Add("onFocus", "javascript:ChangeTab('txtPatronCode');")
            'txtCopyNumber.Attributes.Add("onFocus", "javascript:ChangeTab('txtCopyNumber');")

            txtCheckInDate.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(3).Text & " (" & Session("DateFormat") & ")');")
            txtCheckInDate.ToolTip = Session("DateFormat")
            txtCheckInTime.Attributes.Add("onChange", "javascript:CheckTime(this,'" & ddlLabel.Items(2).Text & "');")

            txtPatronCode.Attributes.Add("onkeydown", "javascript:txtPatronCodeEventkeypress('" & ddlLabel.Items(4).Text & "', " & GenRandomNumber(10) & ",event);")
            txtCopyNumber.Attributes.Add("onkeydown", "javascript:txtCopyNumberEvent('" & ddlLabel.Items(5).Text & "', " & GenRandomNumber(10) & ");")

            lnkReservRequest.NavigateUrl = "javascript:OpenWindow('../WReservations.aspx?x=" & GenRandomNumber(10) & "','Reservation',600,400,150,50);"
            lnkViewHoldTransaction.NavigateUrl = "javascript:OpenWindow('../WViewHoldTransaction.aspx?x=" & GenRandomNumber(10) & "','Reservation',600,400,150,50);"

            btnCheckIn.Attributes.Add("OnClick", "CheckIn('" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(2).Text & "', " & GenRandomNumber(10) & "); return false;")
            btnPrint.Attributes.Add("OnClick", "parent.CheckInMain.location.href='WCheckInPrintResult.aspx?x=" & GenRandomNumber(10) & "'; return false;")
            btnEnd.Attributes.Add("OnClick", "parent.CheckInMain.location.href='WCheckInPrintResult.aspx?EndSession=1&x=" & GenRandomNumber(10) & "'; return false;")

            chkAutoPaidFees.Attributes.Add("OnClick", "javascript:chkAutoPaidEvent();")
            chkPatronCode.Attributes.Add("OnClick", "javascript:chkPatronCodeEvent();")
            chkCopyNumber.Attributes.Add("OnClick", "javascript:chkCopyNumberEvent();")
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace