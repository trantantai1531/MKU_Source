Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WQuickView
        Inherits clswbase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgPatron As System.Web.UI.HtmlControls.HtmlImage
        Protected WithEvents lblOnLoan As System.Web.UI.WebControls.Label
        Protected WithEvents lblLoanCycle As System.Web.UI.WebControls.Label
        Protected WithEvents lblOverdue As System.Web.UI.WebControls.Label
        Protected WithEvents lblHoldingRequest As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemsInOrder As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemsInUsed As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemsInProcess As System.Web.UI.WebControls.Label
        Protected WithEvents lblItemsInQuery As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBCommonChart As New clsBCommonChart
        Private objBLoanTransaction As New clsBLoanTransaction
        Private objBOverdueTransaction As New clsBOverdueTransaction

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            Call GenChart()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonChart.Initialize()

            'Init clsBLoanTransaction
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLoanTransaction.Initialize()

            'Init clsBLoanTransaction
            objBOverdueTransaction.ConnectionString = Session("ConnectionString")
            objBOverdueTransaction.DBServer = Session("DBServer")
            objBOverdueTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTransaction.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Bind javascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("MenuJs", "<script language = 'javascript' src = 'js/WMenu.js?t=" & String.Format("{0:yyyyMMddHHmmss}", Date.Now) & "'></script>")
            hrfCheckIn.Attributes.Add("OnClick", "CheckIn_Click();")
            hrfCheckOut.Attributes.Add("OnClick", "CheckOut_Click();")
            hrfFineAndFee.Attributes.Add("OnClick", "Account_Click();")
            hrfOverdue.Attributes.Add("OnClick", "Overdue_Click();")
            hrfPolici.Attributes.Add("OnClick", "Policy_Click();")
            hrfRenew.Attributes.Add("OnClick", "Renew_Click();")
            hrfRequest.Attributes.Add("OnClick", "Hold_Click();")
            hrfStatistic.Attributes.Add("OnClick", "Statistic_Click();")
            hrfRoomsBooking.Attributes.Add("OnClick", "RoomsBooking_Click();")
        End Sub

        ' BindStatic method
        ' Purpose: Bind the data and draw the statistic
        Private Sub GenChart()
            Dim strImgURL As String
            Dim tblQuickView As New DataTable
            strImgURL = Server.MapPath("..\Images\bground.gif")

            objBLoanTransaction.LibID = clsSession.GlbSite
            objBLoanTransaction.GetQuickView(0, Session("UserID"))
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBLoanTransaction.ErrorMsg, ddlLabel.Items(1).Text, objBLoanTransaction.ErrorCode)
            lblStabyCat.Visible = False
            anh1.Visible = False
            If objBLoanTransaction.arrData(0) > -1 Then
                lblStabyCat.Visible = True
                anh1.Visible = True
                hidControl.Value = 1
                objBCommonChart.Makebarchart(objBLoanTransaction.arrData, objBLoanTransaction.arrLabel, "", "", 45, strImgURL, "WQuickView.aspx", "", 1)
                Session("chart1") = Nothing
                Session("chart1") = objBCommonChart.OutPutStream
            End If


            Dim tblOverdueList As New DataTable
            objBOverdueTransaction.UserID = Session("UserID")
            objBOverdueTransaction.PatronIDs = ""
            tblOverdueList = objBOverdueTransaction.GetOverdueListAuthority(0, 0)

            tblQuickView = objBLoanTransaction.GetQuickView(1, Session("UserID"))
            lblLoanItems.Text &= Space(1) & "<b>" & FormatNumber(tblQuickView.Rows(0).Item("LoanItems"), 0) & "</b>"
            lblLoancycles.Text &= Space(1) & "<b>" & FormatNumber(tblQuickView.Rows(0).Item("LoanCycles"), 0) & "</b>"
            lblOverdueItems.Text &= Space(1) & "<b>" & tblOverdueList.Rows.Count.ToString() & "</b>"
            lblHoldingRequests.Text &= Space(1) & "<b>" & FormatNumber(tblQuickView.Rows(0).Item("HoldingRequests"), 0) & "</b>"
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
                If Not objBOverdueTransaction Is Nothing Then
                    objBOverdueTransaction.Dispose(True)
                    objBOverdueTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub
    End Class
End Namespace