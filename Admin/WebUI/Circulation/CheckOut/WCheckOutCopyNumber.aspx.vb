Imports eMicLibAdmin.WebUI.Common
Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WCheckOutCopyNumber
        Inherits clsWBase
        Dim objBCSP As New eMicLibAdmin.BusinessRules.Common.clsBCommonStringProc
        Dim objBCDBS As New eMicLibAdmin.BusinessRules.Common.clsBCommonDBSystem
        Dim objBPatron As New eMicLibAdmin.BusinessRules.Circulation.clsBPatron

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMuonDK As System.Web.UI.WebControls.Label
        Protected WithEvents lnkAddPatron As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkCheckPatronCode As System.Web.UI.WebControls.HyperLink

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            txtCreatedDate.Text = Session("ToDay")
            Session("CheckForm") = "CheckOut"
            If Not Page.IsPostBack Then
                BindLocation()
                lblTitle.Text = lblTitle.Text & " " & Session("ToDay")
            End If
        End Sub
        Private Sub Initialize()
            ' Init for objBCommonStringProc
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.Initialize()
            ' Init for objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()

            ' Init for objBPatron
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.Initialize()

            Response.Expires = 0
            Session("Remain") = 0
            Session("TransactionID") = Nothing
        End Sub
        Private Sub CheckFormPermission()
            If Not CheckPemission(57) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text.Trim)
            End If
        End Sub

        Private Sub BindLocation()
            Dim tblLocation As DataTable
            objBPatron.User_ID = Session("UserID")
            tblLocation = objBPatron.GetLocationID(2)
            ddlLocation.DataSource = tblLocation
            ddlLocation.DataTextField = "LOCNAME"
            ddlLocation.DataValueField = "ID"
            ddlLocation.DataBind()
        End Sub
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/CheckOut/WCheckOut.js'></script>")
            lnkCheckOutInLibrary.NavigateUrl = "WCheckOutInLibrary.aspx"
            lnkCheckOut.NavigateUrl = "WCheckOut.aspx"
            txtPatronCode.Attributes.Add("onkeydown", "javascript:txtPatronCodeEventkeypress('" & ddlLabel.Items(3).Text & "', " & GenRandomNumber(10) & ",event);")

            txtPatronCode.Attributes.Add("onFocus", "javascript:ChangeTab('txtPatronCode');")
            lnkSearchPatron.Target = "CheckOutMain"
            lnkSearchPatron.NavigateUrl = "../WSearchPatron.aspx"
            lnkPatronReport.Target = "CheckOutMain"
            lnkPatronReport.NavigateUrl = "WPatronReport.aspx"
            lnkPatronMax.Target = "CheckOutMain"
            lnkPatronMax.NavigateUrl = "WPatronMax.aspx"
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCal, txtCreatedDate, ddlLabel.Items(2).Text)
        End Sub

        Private Sub btnInput_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInput.Click
            If txtPatronCode.Text = "" Then
                Response.Write("<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            ElseIf Not IsDate(txtCreatedDate.Text) Then
                Response.Write("<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
            Else
                Dim intLocationID As Integer
                objBPatron.User_ID = Session("UserID")
                intLocationID = ddlLocation.SelectedValue
                objBPatron.PatronCode = Trim(Request("txtPatronCode"))
                'objBPatron.CreateDate = Request("txtCreatedDate")
                'objBPatron.CreateDate = Session("ToDay")
                objBPatron.LocationID = intLocationID
                'objBPatron.Note = Request("txtNote")
                objBPatron.Note = ""
                Dim tblResult As DataTable
                objBCDBS.SQLStatement = "SELECT * FROM Cir_tblPatron WHERE UPPER(CODE)='" & objBPatron.PatronCode.ToUpper & "'"

                'tblResult = objBPatron.GetPatronInfor
                tblResult = objBCDBS.ConvertTable(objBCDBS.RetrieveItemInfor())
                If tblResult.Rows.Count <= 0 Then
                    Response.Write("<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                Else
                    objBPatron.AddRegularity_out()
                    txtNote.Text = ""
                    txtPatronCode.Text = ""
                End If
            End If
        End Sub
    End Class
End Namespace
