' Class: WCheckOutInLibrary
' Puspose: Cho ban doc muon sach, doc luon trong thu vien 
' Creator: Tuanhv
' CreatedDate: 19/08/2004
' Modification History:
'   - 15/04/2005 by Oanhtn: review & update

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckOutInLibrary
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkExtentDue As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            lnkAddPatron.Visible = False
            If Not Page.IsPostBack Then
                txtCreatedDate.Text = Session("ToDay")
                txtCreatedTime.Text = CStr(Hour(Now)).PadLeft(2, "0") & ":" & CStr(Minute(Now)).PadLeft(2, "0") & ":" & CStr(Second(Now)).PadLeft(2, "0")
                txtDueDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy")
                txtDueTime.Text = "22:00:00"
            End If
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
            Response.Expires = 0
            Session("Remain") = 0
            Session("TransactionID") = Nothing
        End Sub

        ' Method: BindJS
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/CheckOut/WCheckOut.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            lnkSearchPatron.Target = "CheckOutMain"
            lnkSearchPatron.NavigateUrl = "../WSearchPatron.aspx"
            lnkAddPatron.Target = "CheckOutMain"
            lnkAddPatron.NavigateUrl = "../WAddPatron.aspx"
            lnkCheckPatronCode.Target = "CheckOutMain"
            lnkCheckPatronCode.NavigateUrl = "../WCheckPatronCode.aspx"

            lnkAddCopyNumber.Target = "CheckOutMain"
            lnkAddCopyNumber.NavigateUrl = "../WAddCopyNumber.aspx"
            lnkSearchCopyNumber.Target = "CheckOutMain"
            lnkSearchCopyNumber.NavigateUrl = "../WSearchCopyNumber.aspx"

            lnkCheckOut.NavigateUrl = "WCheckOut.aspx"
            lnkMuonDK.NavigateUrl = "WCheckOutCopyNumber.aspx"

            txtPatronCode.Attributes.Add("onkeydown", "javascript:txtPatronCodeEventkeypress('" & ddlLabel.Items(3).Text & "', " & GenRandomNumber(10) & ",event);")

            'txtPatronCode.Attributes.Add("OnChange", "javascript:txtPatronCodeEvent('" & ddlLabel.Items(3).Text & "', " & GenRandomNumber(10) & ");")
            'txtCopyNumber.Attributes.Add("OnChange", "javascript:txtCopyNumberEvent('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "', " & GenRandomNumber(10) & ");")

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

            txtPatronCode.Attributes.Add("onFocus", "javascript:ChangeTab('txtPatronCode');")
            'txtCopyNumber.Attributes.Add("onFocus", "javascript:ChangeTab('txtCopyNumber');")

            ' btnCheckOut.Attributes.Add("OnClick", "javascript:CheckOut('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "', " & GenRandomNumber(10) & "); return false;")
            btnCheckOut.Attributes.Add("OnClick", "javascript:CheckOut('" & ddlLabel.Items(1).Text & "', '" & ddlLabel.Items(2).Text & "', '" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(5).Text & "', '" & ddlLabel.Items(6).Text & "', " & GenRandomNumber(10) & "); return false;")
            btnPrint.Attributes.Add("OnClick", "javascript:parent.CheckOutMain.location.href='WCheckOutPrintResult.aspx?x=" & GenRandomNumber(10) & "'; return false;")
            btnEnd.Attributes.Add("OnClick", "javascript:parent.CheckOutMain.location.href='WCheckOutPrintResult.aspx?x=" & GenRandomNumber(10) & "&EndSession=1'; return false;")

            lnkReservation.NavigateUrl = "javascript:OpenWindow('../WReservations.aspx?x=" & GenRandomNumber(10) & "','Reservation',600,400,150,50);"
            lnkPatronInLib.NavigateUrl = "javascript:OpenWindow('WPatronInLibrary.aspx?x=" & GenRandomNumber(10) & "','PatronInLibrary',600,400,150,50);"
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace