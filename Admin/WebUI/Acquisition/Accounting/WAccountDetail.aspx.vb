﻿Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WAccountDetail
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblUnSeetledSum As System.Web.UI.WebControls.Label
        Protected WithEvents lblUnSettledAmount As System.Web.UI.WebControls.Label
        Protected WithEvents lblSeetledSum As System.Web.UI.WebControls.Label
        Protected WithEvents lblSettledAmount As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblField1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblField2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblField3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblField4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblField5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSubField1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSubField2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSubField3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblSubField4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg6 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg7 As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg11 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblBudgetDisplay As System.Web.UI.WebControls.Label
        Protected WithEvents lblSum As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBAccounting As New clsBAccounting
        Private objBBudget As New clsBBudget
        Private objBPurchaseOrder As New clsBPurchaseOrder
        Private objBCommonBusiness As New clsBCommonBusiness
        Private intDisplay As Int16 = 1
        Private tblAccount As DataTable
        Private dblStartRemain As Double
        Private dblLastBase As Double
        Private objBPO As New clsBPurchaseOrder
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindDropdownList()
                If Not Request("BudgetID") & "" = "" Then
                    Dim tblTemp As DataTable
                    Dim inti As Integer
                    tblTemp = CType(ddlBudget.DataSource, DataTable)
                    If Not tblTemp Is Nothing Then
                        For inti = 0 To tblTemp.Rows.Count - 1
                            If tblTemp.Rows(inti).Item("ID") = Request("BudgetID") Then
                                txtRate.Text = tblTemp.Rows(inti).Item("Rate")
                                ddlBudget.SelectedIndex = inti
                                lblDetails.Text = ddlBudget.SelectedItem.Text
                                Exit For
                            End If
                        Next
                    End If
                End If
                If Not clsSession.GlbUserFullName Is Nothing Then
                    txtReporter.Text = clsSession.GlbUserFullName
                End If
                ddlYear.SelectedValue = Year(Now)
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all object
        Private Sub Initialize()
            ' Init for objBAccounting
            objBAccounting.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccounting.DBServer = Session("DBServer")
            objBAccounting.ConnectionString = Session("ConnectionString")
            Call objBAccounting.Initialize()

            ' Init for objBPurchaseOrder
            objBPurchaseOrder.InterfaceLanguage = Session("InterfaceLanguage")
            objBPurchaseOrder.DBServer = Session("DBServer")
            objBPurchaseOrder.ConnectionString = Session("ConnectionString")
            Call objBPurchaseOrder.Initialize()

            ' Init for objBBudget
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            Call objBBudget.Initialize()

            ' Init for objBCommonBusiness
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()

            ' Init objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Add new spend or received LOG
            If Not CheckPemission(107) Then
                btnAction.Enabled = False
            Else
                btnAction.Enabled = True
            End If
            ' Edit spend or amount LOG
            If Not CheckPemission(182) Then
                dgtResult.Columns(6).Visible = False
            Else
                dgtResult.Columns(6).Visible = True
            End If
            ' Delete spend or amount LOG
            If Not CheckPemission(183) Then
                dgtResult.Columns(7).Visible = False
            Else
                dgtResult.Columns(7).Visible = True
            End If
        End Sub

        ' BindData method
        ' Purpose: Bind the account data
        Private Sub BindData()
            If ddlBudget.SelectedIndex = "-1" Then
                lblDetails.Text = ""
            Else
                lblDetails.Text = ddlBudget.SelectedItem.Text
            End If


            ' Get the current day
            txtDate.Text = Session("Today")
            hidToday.Value = txtDate.Text

            ' Display the spend fees list
            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                intDisplay = 1
                lblSpendTitle.Visible = True
                lblSettledTitle.Visible = False
                lblReportTitle.Visible = False
                lblReportDetails.Visible = False
                lblSpendDetails.Visible = True
                lblSeetledDetails.Visible = False
                TR5.Visible = True
                lblSpendFor.Visible = True
                lblReceiveFor.Visible = False
                lblDate.Text = ddlLabel.Items(35).Text
                VisibleTableRows()

                ' Display the received fees list
            ElseIf Trim(Request("Display")) = "2" Then
                lblSpendFor.Visible = False
                lblReceiveFor.Visible = True
                intDisplay = 2
                lblSpendTitle.Visible = False
                lblSettledTitle.Visible = True
                lblReportTitle.Visible = False
                lblReportDetails.Visible = False
                lblSpendDetails.Visible = False
                lblSeetledDetails.Visible = True
                VisibleTableRows()
                TR5.Visible = False
                lblDate.Visible = True
                txtDate.Visible = True
                divDate.Visible = True
                lblDate.Text = ddlLabel.Items(36).Text
                rdoReal.Text = "Dự thu"
                rdoUnReal.Text = "Thực thu"
            ElseIf Trim(Request("Display")) = "0" Then
                intDisplay = 0
                lblSpendTitle.Visible = False
                lblSettledTitle.Visible = False
                lblReportTitle.Visible = True
                lblReportDetails.Visible = True
                lblSpendDetails.Visible = False
                lblSeetledDetails.Visible = False
                TR5.Visible = False
                DisableTableRows()
            End If

            If Not Request("BudgetID") & "" = "" Then
                objBAccounting.BudgetID = CInt(Request("BudgetID"))
            End If
            objBAccounting.LibID = clsSession.GlbSite
            'tblAccount = objBAccounting.GetAccountInfor(intDisplay, ddlMonth.SelectedValue, ddlYear.SelectedValue)
            tblAccount = Nothing

            ' Print or not
            If Not tblAccount Is Nothing Then
                If tblAccount.Rows.Count > 0 Then
                    btnPrint.Enabled = True
                Else
                    btnPrint.Enabled = False
                End If
            Else
                btnPrint.Enabled = False
            End If

            ' Indicate the URL for the hyperlink
            lnkReport.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=0&BudgetID=" & Request("BudgetID") & "'"
            Select Case intDisplay
                Case 1
                    lnkAddAccount.Text = lblSettledTitle.Text
                    lnkAddAccount.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=2&BudgetID=" & Request("BudgetID") & "'"
                Case 2
                    lnkAddAccount.Text = lblSpendTitle.Text
                    lnkAddAccount.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=1&BudgetID=" & Request("BudgetID") & "'"
                Case 0
                    ' Display the accounting report
                    lnkAddAccount.Text = lblSpendTitle.Text
                    lnkAddAccount.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=1&BudgetID=" & Request("BudgetID") & "'"
                    lnkReport.Text = lblSettledTitle.Text
                    lnkReport.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=2&BudgetID=" & Request("BudgetID") & "'"
            End Select

            ' Begin to display
            lblBalanceAmount.Text = objBAccounting.Balance.ToString("#,##")
            lblRealBalanceAmount.Text = objBAccounting.RealBalance.ToString("#,##")
            lblSetCur1.Text = objBAccounting.Currency
            lblSetCur2.Text = objBAccounting.Currency
            dblStartRemain = objBAccounting.StartRemain
            dblLastBase = objBAccounting.LastBase
            hidCurrency.Value = objBAccounting.Currency

            If Not intDisplay = 0 Then
                'Format InfoAmount Column
                Dim inti As Integer
                If intDisplay = 1 Then
                    If Not tblAccount Is Nothing Then
                        For inti = 0 To tblAccount.Rows.Count - 1
                            objBPO.AcqPOID = tblAccount.Rows(inti).Item("POID")
                            objBPO.Direction = 10
                            Dim acqDetail = objBPO.GetAcqPoInfor()
                            If tblAccount.Rows(inti).Item("Commited") = 0 Then
                                If acqDetail.Rows.Count > 0 Then
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(29).Text & "</li><li>" & ddlLabel.Items(31).Text & " " & acqDetail.Rows(0).Item("POName") & "</li><ul>"
                                Else
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(29).Text & "</li><ul>"
                                End If
                            Else
                                If acqDetail.Rows.Count > 0 Then
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(30).Text & "</li><li>" & ddlLabel.Items(31).Text & " " & acqDetail.Rows(0).Item("POName") & "</li><ul>"
                                Else
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(30).Text & "</li><ul>"
                                End If
                            End If
                        Next
                    End If
                Else
                    If intDisplay = 2 Then
                        If Not tblAccount Is Nothing AndAlso tblAccount.Rows.Count > 0 Then
                            For inti = 0 To tblAccount.Rows.Count - 1
                                objBPO.AcqPOID = tblAccount.Rows(inti).Item("POID")
                                objBPO.Direction = 10
                                Dim acqDetail = objBPO.GetAcqPoInfor()
                                If acqDetail.Rows.Count > 0 Then
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(32).Text & "</li><li>" & ddlLabel.Items(33).Text & " " & acqDetail.Rows(0).Item("POName") & "</li><ul>"
                                Else
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(32).Text & "</li><ul>"
                                End If
                            Next
                        End If

                    End If
                End If
                dgtResult.DataSource = tblAccount
                dgtResult.DataBind()
                btnPrint.Attributes.Add("OnClick", "javascript:OpenWindow('WFeesReport.aspx?Display=" & intDisplay & "&BudgetID=" & ddlBudget.SelectedValue & "&Month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value + '&Year=' + document.forms[0].ddlYear.options[document.forms[0].ddlYear.options.selectedIndex].value,'FeesReport',650,500,70,10);return false;")
            Else
                Call ShowAccountReport()
                btnPrint.Attributes.Add("OnClick", "javascript:OpenWindow('WAccountReport.aspx?BudgetID=" & ddlBudget.SelectedValue & "&Month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value + '&Year=' + document.forms[0].ddlYear.options[document.forms[0].ddlYear.options.selectedIndex].value,'AccountReport',650,500,70,10);return false;")
            End If
        End Sub

        ' FilterData method
        Private Sub FilterData()
            ' Display the pay fees list
            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                intDisplay = 1
                ' Display the Settled fees list
            ElseIf Trim(Request("Display")) = "2" Then
                intDisplay = 2
            ElseIf Trim(Request("Display")) = "0" Then
                intDisplay = 0
            End If

            Select Case intDisplay
                Case 1
                    lnkAddAccount.Text = lblSettledTitle.Text
                    lnkAddAccount.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=2&BudgetID=" & Request("BudgetID") & "'"
                Case 2
                    lnkAddAccount.Text = lblSpendTitle.Text
                    lnkAddAccount.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=1&BudgetID=" & Request("BudgetID") & "'"
                    ' Display the accounting report
                Case 0
                    ' Display the accounting report
                    lnkAddAccount.Text = lblSpendTitle.Text
                    lnkAddAccount.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=1&BudgetID=" & Request("BudgetID") & "'"
                    lnkReport.Text = lblSettledTitle.Text
                    lnkReport.NavigateUrl = "javascript:location.href='WAccountDetail.aspx?Display=2&BudgetID=" & Request("BudgetID") & "'"
            End Select

            If Not Request("BudgetID") & "" = "" Then
                objBAccounting.BudgetID = CInt(Request("BudgetID"))
            End If
            objBAccounting.LibID = clsSession.GlbSite
            tblAccount = objBAccounting.GetAccountInfor(intDisplay, ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlPO1.SelectedValue)

            ' Print or not
            If Not tblAccount Is Nothing Then
                If tblAccount.Rows.Count > 0 Then
                    btnPrint.Enabled = True
                Else
                    btnPrint.Enabled = False
                End If
            Else
                btnPrint.Enabled = False
            End If
            lblBalanceAmount.Text = objBAccounting.Balance.ToString("#,##")
            lblRealBalanceAmount.Text = objBAccounting.RealBalance.ToString("#,##")
            'lblBalanceAmount.Text = CStr(objBAccounting.Balance)
            'lblRealBalanceAmount.Text = CStr(objBAccounting.RealBalance)
            lblSetCur1.Text = objBAccounting.Currency
            lblSetCur2.Text = objBAccounting.Currency
            dblStartRemain = objBAccounting.StartRemain
            dblLastBase = objBAccounting.LastBase
            hidCurrency.Value = objBAccounting.Currency

            ' Begin to display
            If Not intDisplay = 0 Then
                'Format InfoAmount Column
                Dim inti As Integer
                If intDisplay = 1 Then
                    If Not tblAccount Is Nothing Then
                        For inti = 0 To tblAccount.Rows.Count - 1
                            If tblAccount.Rows(inti).Item("Commited") = 0 Then
                                objBPO.AcqPOID = tblAccount.Rows(inti).Item("POID")
                                objBPO.Direction = 10
                                Dim acqDetail = objBPO.GetAcqPoInfor()
                                If acqDetail.Rows.Count > 0 Then
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(29).Text & "</li><li>" & ddlLabel.Items(31).Text & " " & acqDetail.Rows(0).Item("POName") & "</li><ul>"
                                Else
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(29).Text & "</li><ul>"
                                End If

                            Else
                                objBPO.AcqPOID = tblAccount.Rows(inti).Item("POID")
                                objBPO.Direction = 10
                                Dim acqDetail = objBPO.GetAcqPoInfor()
                                If acqDetail.Rows.Count > 0 Then
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(30).Text & "</li><li>" & ddlLabel.Items(31).Text & " " & acqDetail.Rows(0).Item("POName") & "</li><ul>"
                                Else
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><ul>"
                                End If

                            End If
                        Next
                    End If

                Else
                    If intDisplay = 2 Then
                        If Not tblAccount Is Nothing Then
                            For inti = 0 To tblAccount.Rows.Count - 1
                                objBPO.AcqPOID = tblAccount.Rows(inti).Item("POID")
                                objBPO.Direction = 10
                                Dim acqDetail = objBPO.GetAcqPoInfor()
                                If acqDetail.Rows.Count > 0 Then
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(32).Text & "</li><li>" & ddlLabel.Items(33).Text & " " & acqDetail.Rows(0).Item("POName") & "</li><ul>"
                                Else
                                    tblAccount.Rows(inti).Item("InfoAmount") = "<ul><li>" & CInt(tblAccount.Rows(inti).Item("InfoAmount")).ToString("#,##") & " " & tblAccount.Rows(inti).Item("Currency") & "</li><li>" & ddlLabel.Items(32).Text & "</li><ul>"
                                End If

                            Next

                        End If
                    End If

                End If
                dgtResult.DataSource = tblAccount
                dgtResult.DataBind()
            Else
                Call ShowAccountReport()
            End If
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Accounting/WAccountDetail.js'></script>")

            btnAction.Attributes.Add("Onclick", "javascript:if(!CheckAll('" & ddlLabel.Items(18).Text & "','" & ddlLabel.Items(13).Text & "','" & ddlLabel.Items(14).Text & "')) {return false;}")
            btnCancel.Attributes.Add("OnClick", "javascript:ResetForm(); return false;")

            Me.SetCheckNumber(txtAmount, ddlLabel.Items(15).Text)
            Me.SetCheckNumber(txtRate, ddlLabel.Items(15).Text, "1")
            Me.SetCheckNumber(txtDate, ddlLabel.Items(17).Text)
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDate, txtDate, ddlLabel.Items(37).Text)
            'txtAmount.Attributes.Add("disabled", "disabled")
            'txtRate.Attributes.Add("disabled", "disabled")
            lnkPODetails.NavigateUrl = "javascript:if (document.forms[0].ddlPO.options.selectedIndex!=0) OpenWindow('WPODetailByID.aspx?POS=' + document.forms[0].ddlPO.options[document.forms[0].ddlPO.options.selectedIndex].value + '&ViewOnly=1','PODetails',700,500,50,10)"
        End Sub

        ' BindDropdownList method
        Private Sub BindDropdownList()
            Dim tblBudget As DataTable
            Dim tblPO As DataTable
            Dim tblPO1 As DataTable
            Dim tblGroupStatus As DataTable
            Dim lstItem As ListItem
            Dim intIndex As Integer

            ' Get the budget
            objBBudget.LibID = clsSession.GlbSite
            tblBudget = objBBudget.GetBudgetByStatus(, CInt(Trim(Request("Display"))))

            If Not tblBudget Is Nothing Then
                If tblBudget.Rows.Count > 0 Then
                    ddlBudget.DataSource = tblBudget
                    ddlBudget.DataTextField = "BudgetDetail"
                    ddlBudget.DataValueField = "ID"
                    ddlBudget.DataBind()
                End If
            End If

            ' get the group status
            objBBudget.LibID = clsSession.GlbSite
            tblGroupStatus = objBBudget.GetGroupStausPO()
            If Not tblGroupStatus Is Nothing Then
                If tblGroupStatus.Rows.Count > 0 Then
                    ddlStatus.DataSource = tblGroupStatus
                    ddlStatus.DataTextField = "Status"
                    ddlStatus.DataValueField = "ID"
                    ddlStatus.DataBind()
                End If
            End If

            ' Get the PO
            objBPurchaseOrder.LibID = clsSession.GlbSite
            tblPO = objBPurchaseOrder.GetPO("", ddlStatus.SelectedValue)
            ' Get the PO1
            objBPurchaseOrder.LibID = clsSession.GlbSite
            tblPO1 = objBPurchaseOrder.GetPO("", 0)

            If Not tblPO Is Nothing Then
                If tblPO.Rows.Count > 0 Then
                    ddlPO.DataSource = InsertOneRow(tblPO, ddlLabel.Items(0).Text)
                    ddlPO.DataTextField = "ReceiptNo"
                    ddlPO.DataValueField = "ID"
                    ddlPO.DataBind()
                    ddlPO1.DataSource = InsertOneRow(tblPO1, ddlLabel.Items(0).Text)
                    ddlPO1.DataTextField = "ReceiptNo"
                    ddlPO1.DataValueField = "ID"
                    ddlPO1.DataBind()
                End If
            End If

            ' Get Year
            Dim intFirstYear = Year(Now) - 10
            lstItem = New ListItem
            lstItem.Text = CStr(intFirstYear)
            lstItem.Value = intFirstYear
            ddlYear.Items.Add(lstItem)

            For intIndex = 0 To 19
                lstItem = New ListItem
                intFirstYear = intFirstYear + 1
                lstItem.Text = CStr(intFirstYear)
                lstItem.Value = intFirstYear
                ddlYear.Items.Add(lstItem)
            Next
        End Sub

        ' ShowAccountReport method
        ' Purpose: Show the accounting summary data 
        ' For display account report
        Private Sub ShowAccountReport()
            ' Declare variables
            Dim intSumFound As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim intk As Integer
            Dim intl As Integer
            Dim intIndex As Integer
            Dim intm As Integer
            Dim strCreatedDate As String = ""
            Dim strNote As String = ""
            Dim strAmount As String = ""
            Dim strCurrency As String = ""
            Dim strRate As String = ""
            Dim strSRate As String = ""
            Dim strSubtract As String = ""
            Dim intIsSeetled As Integer = 0
            Dim strTotal As String = ""
            Dim strSum1 As String = 0
            Dim strSum2 As String = 0
            Dim dblRealTotal As Double = 0
            Dim dblSubtractTotal1 As Double = 0
            Dim dblSubtractTotal2 As Double = 0
            Dim dblSeetled As Double = 0
            Dim dblSpend As Double = 0
            Dim strStatus As String = ""

            If Not tblAccount Is Nothing Then
                intSumFound = CInt(tblAccount.Rows.Count)   ' Sum of records found
                If intSumFound > 0 Then
                    ' Declare the table row and cell variables
                    Dim tblRow As TableRow
                    Dim tblCell As TableCell

                    TRHeader.Visible = True

                    ' Add attributes for dinamic table
                    tblReport.BorderWidth = Unit.Pixel(0)
                    tblReport.Width = Unit.Percentage(100)

                    ' Display the report header (3 rows)
                    For inti = 0 To 1
                        tblRow = New TableRow
                        Select Case inti
                            Case 0
                                For intj = 0 To 5
                                    tblCell = New TableCell
                                    Select Case intj
                                        Case 0
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
                                        Case 1
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
                                        Case 2
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(5).Text))
                                        Case 3
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(6).Text))
                                        Case 4
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(7).Text))
                                        Case 5
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(34).Text))
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                    tblRow.CssClass = "lbGridHeader"
                                Next
                            Case 1
                                tblCell = New TableCell
                                For intk = 0 To 7
                                    tblCell = New TableCell
                                    Select Case intk
                                        Case 0, 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(8).Text))
                                        Case 1, 5
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(9).Text))
                                        Case 2, 6
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(10).Text))
                                        Case 3, 7
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(11).Text))
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                    tblRow.CssClass = "lbGridHeader"
                                Next
                        End Select
                        tblReport.Rows.Add(tblRow)
                    Next

                    ' Display the report contents
                    For intIndex = 0 To intSumFound - 1
                        tblRow = New TableRow
                        ' Created Date
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("TRANSACTIONDATE")) Then
                            strCreatedDate = Trim(CStr(tblAccount.Rows(intIndex).Item("TRANSACTIONDATE")))
                        Else
                            strCreatedDate = ""
                        End If
                        ' Note
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Reason")) Then
                            strNote = Trim(CStr(tblAccount.Rows(intIndex).Item("Reason")))
                        Else
                            strNote = ""
                        End If
                        ' Amount
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("AmountDisplay")) Then
                            strAmount = Trim(CInt(tblAccount.Rows(intIndex).Item("AmountDisplay")).ToString("#,##"))
                        Else
                            strAmount = "0"
                        End If
                        ' Currency Code
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Currency")) Then
                            strCurrency = Trim(CStr(tblAccount.Rows(intIndex).Item("Currency")))
                        Else
                            strCurrency = ""
                        End If
                        ' Rate (At the new spending or receive reporting time)
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("ExchangeRate")) Then
                            strRate = Trim(CStr(tblAccount.Rows(intIndex).Item("ExchangeRate")))
                        Else
                            strRate = ""
                        End If
                        ' Rate (current rate at this moment)
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("FixedRate")) Then
                            strSRate = Trim(CStr(tblAccount.Rows(intIndex).Item("FixedRate")))
                        Else
                            strSRate = ""
                        End If

                        ' Total of amount
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Total")) Then
                            strTotal = Trim(CInt(tblAccount.Rows(intIndex).Item("Total")).ToString("#,##"))
                        Else
                            strTotal = ""
                        End If

                        ' Paid or not
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Type")) Then
                            If tblAccount.Rows(intIndex).Item("Type") = 1 Then
                                intIsSeetled = 0
                            Else
                                intIsSeetled = 1
                            End If
                        End If

                        ' Subtract with 2 other rates
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("FixedRate")) And Not IsDBNull(tblAccount.Rows(intIndex).Item("AmountDisplay")) And Not IsDBNull(tblAccount.Rows(intIndex).Item("Total")) Then
                            dblRealTotal = CDbl(strSRate) * CDbl(strAmount)
                        End If

                        If intIsSeetled = 1 Then
                            If strTotal = "" Then
                                strTotal = "0.0"
                            End If
                            strSubtract = CStr(CDbl(strTotal) - dblRealTotal)
                            dblSubtractTotal1 = dblSubtractTotal1 + CDbl(strSubtract)
                            dblSeetled = dblSeetled + CDbl(strAmount)
                        Else
                            strSubtract = CStr(CDbl(strTotal) - dblRealTotal)
                            dblSubtractTotal2 = dblSubtractTotal2 + CDbl(strSubtract)
                            dblSpend = dblSpend + CDbl(strAmount)
                        End If

                        'Status
                        If tblAccount.Rows(intIndex).Item("Commited") = 0 Then
                            strStatus = ddlLabel.Items(29).Text
                        Else
                            If tblAccount.Rows(intIndex).Item("Commited") = 1 Then
                                strStatus = ddlLabel.Items(30).Text
                            Else
                                strStatus = ddlLabel.Items(32).Text
                            End If
                        End If

                        ' Make the css for rows
                        If intIndex Mod 2 = 0 Then
                            tblRow.CssClass = "lbGridCell"
                        Else
                            tblRow.CssClass = "lbGridAlterCell"
                        End If

                        ' Begin displaying the content (12 column)
                        For intl = 0 To 11
                            Select Case intl
                                Case 0  ' Created Date
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(7%)
                                    tblCell.Controls.Add(New LiteralControl(strCreatedDate))
                                Case 1  ' Reason
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(25%)
                                    tblCell.Controls.Add(New LiteralControl(strNote))
                                Case 2  ' Amount (Seetled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    If intIsSeetled <> 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strAmount))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 3  ' Currency Code (Settled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(5%)
                                    If intIsSeetled <> 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strCurrency))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 4  ' transaction Rate (seetled)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(5%)
                                    If intIsSeetled <> 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strRate))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 5  ' Subtract with 2 amount (current rate and transaction rate - settled)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(8%)
                                    If intIsSeetled <> 0 Then
                                        tblCell.Controls.Add(New LiteralControl(CStr(CDbl(strSubtract))))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 6  ' Amount (Spend)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(CDbl(strAmount).ToString("#,##")))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 7  ' Currency Code (Spend)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(5%)
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strCurrency))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 8  ' Transaction rate (Spend)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(5%)
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strRate))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 9 ' Subtract with 2 amount (current rate and transaction rate - Spend)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(8%)
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strSubtract))

                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 10 ' Current Transaction rate
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    tblCell.HorizontalAlign = HorizontalAlign.Center
                                    tblCell.Controls.Add(New LiteralControl(strSRate))
                                Case 11 ' Status
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Controls.Add(New LiteralControl(strStatus))
                            End Select
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblReport.Rows.Add(tblRow)
                    Next

                    ' Display the footer (2 rows)
                    'For intIndex = 0 To 1
                    tblRow = New TableRow

                    ' Display the sumarry
                    For intm = 0 To 5
                        Select Case intm
                            Case 0  ' Label: SUM
                                tblCell = New TableCell
                                tblCell.ColumnSpan = 2
                                tblCell.CssClass = "lbSubTitle"
                                tblCell.HorizontalAlign = HorizontalAlign.Left
                                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(12).Text))
                            Case 1  ' Sum of seetled fees
                                tblCell = New TableCell
                                tblCell.ColumnSpan = 3
                                tblCell.HorizontalAlign = HorizontalAlign.Left
                                tblCell.CssClass = "lbAmount"
                                strSum1 = "0"
                                If dblSeetled <> 0 Then
                                    strSum1 = dblSeetled.ToString("#,##")
                                End If
                                If CDbl(strSum1) <> "0" Then
                                    tblCell.Controls.Add(New LiteralControl(strSum1))
                                Else
                                    tblCell.Controls.Add(New LiteralControl("0.00"))
                                End If
                            Case 2  ' Sum of subtract (seetled)
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Right
                                If dblSubtractTotal1 <> 0 Then
                                    tblCell.Controls.Add(New LiteralControl(dblSubtractTotal1.ToString("#,##")))
                                Else
                                    tblCell.Controls.Add(New LiteralControl("0.00"))
                                End If
                            Case 3  ' Sum of Spend fees
                                tblCell = New TableCell
                                tblCell.ColumnSpan = 3
                                tblCell.HorizontalAlign = HorizontalAlign.Left
                                tblCell.CssClass = "lbAmount"
                                strSum2 = dblSpend.ToString("#,##")
                                If CDbl(strSum2) <> "0" Then
                                    tblCell.Controls.Add(New LiteralControl(strSum2))
                                Else
                                    tblCell.Controls.Add(New LiteralControl("0.00"))
                                End If
                            Case 4  ' Sum of subtract (Unseetled)
                                tblCell = New TableCell
                                tblCell.HorizontalAlign = HorizontalAlign.Right
                                If dblSubtractTotal2 <> 0 Then
                                    tblCell.Controls.Add(New LiteralControl(CStr(dblSubtractTotal2)))
                                Else
                                    tblCell.Controls.Add(New LiteralControl("0.00"))
                                End If
                            Case 5  ' Empty cell
                                tblCell = New TableCell
                                tblCell.Controls.Add(New LiteralControl(""))
                        End Select
                        tblRow.Cells.Add(tblCell)
                    Next
                    tblReport.Rows.Add(tblRow)

                    ' Visible the first and last remain or not
                    If ddlMonth.SelectedIndex = 0 Then
                        TRFirstRemain.Visible = False
                        TRLastRemain.Visible = False
                    Else
                        TRFirstRemain.Visible = True
                        TRLastRemain.Visible = True
                    End If
                Else
                    TRHeader.Visible = False
                End If
            Else
                TRHeader.Visible = False
            End If

            ' Calculate the start remain and last remain of month
            Dim dblRealStartRemain As Double
            Dim dblLastRemain As Double

            If dblStartRemain = -1 Then
                dblRealStartRemain = dblLastBase + dblSeetled - dblSpend
            Else
                dblRealStartRemain = dblStartRemain
            End If

            dblLastRemain = dblRealStartRemain + dblSeetled - dblSpend
            hidRemain.Value = dblLastRemain

            lblFirstRemainAmount.Text = CStr(dblRealStartRemain)
            lblLastRemainAmount.Text = CStr(dblLastRemain)
            lblSetCurRemain1.Text = hidCurrency.Value
            lblSetCurRemain2.Text = hidCurrency.Value
        End Sub

        ' btnUpdateRemain_Click event
        ' Purpose: Update the accumulate of acccount
        Private Sub btnUpdateRemain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateRemain.Click
            objBAccounting.BudgetID = Request("BudgetID")
            objBAccounting.Amount = CDbl(hidRemain.Value)
            objBAccounting.UpdateAccumulate(ddlMonth.SelectedValue, ddlYear.SelectedValue)
            Page.RegisterClientScriptBlock("UpdateSuccess", "<script language='javascript'>alert('" & ddlLabel.Items(19).Text & "')</script>")
            Call FilterData()
        End Sub

        ' btnAction_Click event
        Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
            Dim tblCurrency As DataTable
            Dim strLog As String

            If dgtResult.EditItemIndex <> -1 Then
                dgtResult.EditItemIndex = -1
            End If

            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                intDisplay = 1
                ' Display the Settled fees list
            ElseIf Trim(Request("Display")) = "2" Then
                intDisplay = 2
            End If

            objBAccounting.BudgetID = ddlBudget.SelectedValue
            If ddlPO.SelectedIndex <> 0 Then
                objBAccounting.PoID = ddlPO.SelectedValue
            End If
            objBAccounting.Currency = hidCurrency.Value
            objBAccounting.Reason = txtReason.Text
            If intDisplay = 1 Then
                If rdoReal.Checked - True Then
                    objBAccounting.Commited = 0
                End If
                If rdoUnReal.Checked = True Then
                    objBAccounting.Commited = 1
                End If
            End If
            objBAccounting.TransactionDate = txtDate.Text
            objBAccounting.Inputer = txtReporter.Text
            objBAccounting.Amount = CDbl(txtAmount.Text)
            objBAccounting.ExchangeRate = CDbl(txtRate.Text)
            objBAccounting.LibID = clsSession.GlbSite

            ' get the curren currency exchange
            objBCommonBusiness.CurrencyCode = hidCurrency.Value
            tblCurrency = objBCommonBusiness.GetCurrency

            If Not tblCurrency Is Nothing Then
                If tblCurrency.Rows.Count > 0 Then
                    objBAccounting.FixedRate = tblCurrency.Rows(0).Item("Rate")
                End If
            End If
            objBAccounting.InsertAccountInfor(intDisplay)

            ' Write log
            Select Case intDisplay
                ' Spend
                Case 1
                    strLog = ddlLabel.Items(21).Text & ": " & lblBudget.Text & " " & ddlBudget.SelectedItem.Text
                    If ddlPO.SelectedIndex <> 0 Then
                        strLog = strLog & ", " & lblSpendFor.Text & ddlPO.SelectedItem.Text
                    End If
                    strLog = strLog & ", " & lblAmount.Text & " " & txtAmount.Text
                    strLog = strLog & ", " & lblRate.Text & " " & txtRate.Text
                    strLog = strLog & ", " & lblDate.Text & " " & txtRate.Text
                    strLog = strLog & ", " & lblUser.Text & " " & txtReporter.Text
                    strLog = strLog & ", " & lblReason.Text & " " & txtReason.Text
                    If rdoReal.Checked = True Then
                        strLog = strLog & " (" & rdoReal.Text & ")"
                    End If
                    If rdoUnReal.Checked = True Then
                        strLog = strLog & " (" & rdoUnReal.Text & ")"
                    End If
                Case 2
                    ' Receive
                    strLog = ddlLabel.Items(20).Text & ": " & lblBudget.Text & ddlBudget.SelectedItem.Text
                    If ddlPO.SelectedIndex <> 0 Then
                        strLog = strLog & ", " & lblReceiveFor.Text & ":" & ddlPO.SelectedItem.Text
                    End If
                    strLog = strLog & ", " & lblAmount.Text & " " & txtAmount.Text
                    strLog = strLog & ", " & lblRate.Text & " " & txtRate.Text
                    strLog = strLog & ", " & lblDate.Text & " " & txtRate.Text
                    strLog = strLog & ", " & lblUser.Text & " " & txtReporter.Text
                    strLog = strLog & ", " & lblReason.Text & " " & txtReason.Text
            End Select
            Call WriteLog(40, strLog, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call FilterData()
        End Sub

        ' dgtResult_EditCommand event
        Private Sub dgtResult_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.EditCommand
            Dim tblPO As DataTable
            Dim ddlPODisplay As New DropDownList
            Dim intIndex As Integer
            Dim intCount As Integer
            Dim inti As Integer
            Dim strPO As String
            Dim strCommited As String
            Dim lnkCalendarDisplay As HyperLink
            Dim lblSpendForDisplay As Label
            Dim lblReceiveForDisplay As Label
            Dim ddlComited As New DropDownList

            intIndex = CInt(e.Item.ItemIndex)
            dgtResult.EditItemIndex = intIndex

            Call FilterData()

            ' Load all Controls to DataGrid
            lblSpendForDisplay = CType(dgtResult.Items(intIndex).Cells(1).FindControl("lblSpendForDisplay"), Label)
            lblReceiveForDisplay = CType(dgtResult.Items(intIndex).Cells(1).FindControl("lblReceiveForDisplay"), Label)
            ddlPODisplay = CType(dgtResult.Items(intIndex).Cells(1).FindControl("ddlPODisplay"), DropDownList)
            ddlComited = CType(dgtResult.Items(intIndex).Cells(1).FindControl("ddlComited"), DropDownList)
            lnkCalendarDisplay = CType(dgtResult.Items(intIndex).Cells(0).FindControl("lnkCalendarDisplay"), HyperLink)

            strPO = CType(dgtResult.Items(intIndex).Cells(1).FindControl("txtPOHid"), TextBox).Text
            strCommited = CType(dgtResult.Items(intIndex).Cells(1).FindControl("txtCommitedHid"), TextBox).Text

            'Get the PO
            tblPO = objBPurchaseOrder.GetPO("")
            Call WriteErrorMssg(ddlLabel.Items(2).Text, objBPurchaseOrder.ErrorMsg, ddlLabel.Items(1).Text, objBPurchaseOrder.ErrorCode)

            If Not tblPO Is Nothing Then
                If tblPO.Rows.Count > 0 Then
                    ddlPODisplay.DataSource = InsertOneRow(tblPO, ddlLabel.Items(0).Text)
                    ddlPODisplay.DataTextField = "ReceiptNo"
                    ddlPODisplay.DataValueField = "ID"
                    ddlPODisplay.DataBind()
                End If
            End If

            Select Case intDisplay
                Case 1
                    lblSpendForDisplay.Visible = True
                    lblReceiveForDisplay.Visible = False
                    ddlComited.Visible = True
                Case 2
                    lblSpendForDisplay.Visible = False
                    lblReceiveForDisplay.Visible = True
                    ddlComited.Visible = False
            End Select
            'SetOnclickCalendar(lnkCalendarDisplay, "dgtResult__ctl" & CStr(intIndex + 2) & "_txtCreatedDate", ddlLabel.Items(37).Text)

            For inti = 0 To ddlPODisplay.Items.Count - 1
                If CStr(ddlPODisplay.Items(inti).Value) = strPO Then
                    ddlPODisplay.Items(inti).Selected = True
                Else
                    ddlPODisplay.Items(inti).Selected = False
                End If
            Next

            Select Case strCommited
                Case "False"
                    ddlComited.SelectedIndex = 0
                Case "True"
                    ddlComited.SelectedIndex = 1
            End Select

            ' Add the attributes (javascript debuging) for controls
            CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(0).FindControl("txtCreatedDate"), TextBox).Attributes.Add("OnChange", "javascript:if (!CheckDate(this,'dd/mm/yyyy','" & ddlLabel.Items(17).Text & "'))return false;")
            CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(1).FindControl("txtAmountDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(13).Text & "')) {this.focus();this.value='';return false;}")
            CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(2).FindControl("txtRateDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(16).Text & "','" & ddlLabel.Items(14).Text & "')) {this.focus();this.value='';return false;}")
        End Sub

        ' Cancel event of DataGrid
        Private Sub dgtResult_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.CancelCommand
            dgtResult.EditItemIndex = -1
            Call FilterData()
        End Sub

        ' dgtResult_UpdateCommand method
        ' Purpose: Update the fine details
        Private Sub dgtResult_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.UpdateCommand
            ' Declare variables
            Dim intID As Integer
            Dim intIndex As Integer
            Dim blnValid As Boolean
            Dim strCreatedDate As String
            Dim strReason As String
            Dim strAmount As String
            Dim strCurrency As String
            Dim dblAmount As Double = 0
            Dim dblRate As Double = 0
            Dim strRate As String
            Dim intBudgetID As Integer
            Dim intPOID As Integer
            Dim strInputer As String
            Dim intComited As Int16
            Dim strLog As String

            ' Get data to Update
            intIndex = e.Item.ItemIndex
            intID = CInt(CType(dgtResult.Items(intIndex).Cells(5).FindControl("lblID"), Label).Text)

            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                intDisplay = 1
                ' Display the Settled fees list
            ElseIf Trim(Request("Display")) = "2" Then
                intDisplay = 2
            End If

            ' POID
            If Not CType(dgtResult.Items(intIndex).Cells(1).FindControl("ddlPODisplay"), DropDownList).SelectedValue = "" Then
                intPOID = CInt(CType(dgtResult.Items(intIndex).Cells(1).FindControl("ddlPODisplay"), DropDownList).SelectedValue)
            Else
                intPOID = 0
            End If

            ' Currency
            strCurrency = hidCurrency.Value

            ' Reason
            strReason = Trim(CType(dgtResult.Items(intIndex).Cells(3).FindControl("txtReasonDisplay"), TextBox).Text)

            ' Commited (For Spend only)
            If intDisplay = 1 Then
                intComited = CInt(CType(dgtResult.Items(intIndex).Cells(1).FindControl("ddlComited"), DropDownList).SelectedValue)
            End If

            ' Transaction Date
            strCreatedDate = Trim(CType(dgtResult.Items(intIndex).Cells(0).FindControl("txtCreatedDate"), TextBox).Text)

            ' Inputer
            If CType(dgtResult.Items(intIndex).Cells(4).FindControl("txtReporterDisplay"), TextBox).Text <> "" Then
                strInputer = Trim(CType(dgtResult.Items(intIndex).Cells(4).FindControl("txtReporterDisplay"), TextBox).Text)
            Else
                strInputer = ""
            End If

            ' Amount
            strAmount = Trim(CType(dgtResult.Items(intIndex).Cells(1).FindControl("txtAmountDisplay"), TextBox).Text)

            ' ExchangeRate
            strRate = Trim(CType(dgtResult.Items(intIndex).Cells(2).FindControl("txtRateDisplay"), TextBox).Text)

            ' Check valid data
            If strCreatedDate = "" Or strAmount = "" Or strRate = "" Or strInputer = "" Or strReason = "" Then
                blnValid = False
            Else
                blnValid = True
            End If

            ' Not null values
            If blnValid = True Then
                dblAmount = CDbl(strAmount)
                dblRate = CDbl(strRate)
                ' Transfer the property
                objBAccounting.ID = intID
                objBAccounting.BudgetID = CInt(Request("BudgetID"))
                objBAccounting.PoID = intPOID
                objBAccounting.Currency = strCurrency
                objBAccounting.Reason = strReason
                If intDisplay = 1 Then
                    objBAccounting.Commited = intComited
                End If
                objBAccounting.TransactionDate = strCreatedDate
                objBAccounting.Inputer = strInputer
                objBAccounting.Amount = dblAmount
                objBAccounting.ExchangeRate = dblRate
                ' Update
                objBAccounting.UpdateAccountInfor(intDisplay)
                ' Write log

                Select Case intDisplay
                    ' Spend
                    Case 1
                        strLog = ddlLabel.Items(23).Text & ": " & lblBudget.Text & " " & ddlBudget.SelectedItem.Text
                        If ddlPO.SelectedIndex <> 0 Then
                            strLog = strLog & ", " & lblSpendFor.Text & ":" & CType(dgtResult.Items(intIndex).Cells(1).FindControl("ddlPODisplay"), DropDownList).SelectedItem.Text
                        End If
                        strLog = strLog & ", " & lblAmount.Text & " " & strAmount
                        strLog = strLog & ", " & lblRate.Text & " " & strRate
                        strLog = strLog & ", " & lblDate.Text & " " & strCreatedDate
                        strLog = strLog & ", " & lblUser.Text & " " & strInputer
                        strLog = strLog & ", " & lblReason.Text & " " & strReason
                        If intComited = 0 Then
                            strLog = strLog & " (" & rdoReal.Text & ")"
                        Else
                            strLog = strLog & " (" & rdoUnReal.Text & ")"
                        End If
                    Case 2
                        ' Receive
                        strLog = ddlLabel.Items(22).Text & ": " & lblBudget.Text & " " & ddlBudget.SelectedItem.Text
                        If ddlPO.SelectedIndex <> 0 Then
                            strLog = strLog & ", " & lblReceiveFor.Text & " " & CType(dgtResult.Items(intIndex).Cells(1).FindControl("ddlPODisplay"), DropDownList).SelectedItem.Text
                        End If
                        strLog = strLog & ", " & lblAmount.Text & " " & txtAmount.Text
                        strLog = strLog & ", " & lblRate.Text & " " & txtRate.Text
                        strLog = strLog & ", " & lblDate.Text & " " & txtRate.Text
                        strLog = strLog & ", " & lblUser.Text & " " & txtReporter.Text
                        strLog = strLog & ", " & lblReason.Text & " " & txtReason.Text
                End Select
                Call WriteLog(40, strLog, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                dgtResult.EditItemIndex = -1
                Call FilterData()
            Else    ' Null values
                Page.RegisterClientScriptBlock("NullValue", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "')</script>")
            End If
        End Sub

        ' ddlBudget_SelectedIndexChanged event
        Private Sub ddlBudget_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlBudget.SelectedIndexChanged
            Response.Redirect("WAccountDetail.aspx?Display=" & Request("Display") & "&BudgetID=" & ddlBudget.SelectedValue)
        End Sub

        ' btnFilter_Click event
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            If dgtResult.EditItemIndex <> -1 Then
                dgtResult.EditItemIndex = -1
            End If
            Call FilterData()
        End Sub

        ' dgtResult_DeleteCommand event
        Private Sub dgtResult_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.DeleteCommand
            ' Declare variables
            Dim intIndex As Integer
            Dim intID As Integer

            ' Get data to Delete
            If dgtResult.EditItemIndex <> -1 Then
                dgtResult.EditItemIndex = -1
            End If

            intIndex = e.Item.ItemIndex

            intID = Trim(CInt(CType(dgtResult.Items(intIndex).Cells(5).FindControl("lblID"), Label).Text))

            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                intDisplay = 1
                ' Display the Settled fees list
            ElseIf Trim(Request("Display")) = "2" Then
                intDisplay = 2
            End If

            objBAccounting.ID = intID
            objBAccounting.BudgetID = CInt(Request("BudgetID"))
            objBAccounting.DeleteAccountInfor(intDisplay)
            Select Case intDisplay
                Case 1
                    Call WriteLog(40, ddlLabel.Items(25).Text & " (" & lblBudget.Text & " " & ddlBudget.SelectedItem.Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Case 2
                    Call WriteLog(40, ddlLabel.Items(24).Text & " (" & lblBudget.Text & " " & ddlBudget.SelectedItem.Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End Select
            Call FilterData()
        End Sub

        ' VisibleTableRows method
        ' Purpose: Visible the table rows (Add new seetled or spend fees)
        Private Sub VisibleTableRows()
            TR2.Visible = True
            TR3.Visible = True
            TR4.Visible = True
            TR6.Visible = True
            lblDate.Visible = True
            txtDate.Visible = True
            divDate.Visible = True
            lnkDate.Visible = True
            TRHeader.Visible = False
            TRFirstRemain.Visible = False
            TRLastRemain.Visible = False
        End Sub

        ' VisibleTableRows method
        ' Purpose: Disable the table rows (Display report only)
        Private Sub DisableTableRows()
            TR2.Visible = False
            TR3.Visible = False
            TR4.Visible = False
            TR6.Visible = False
            lblDate.Visible = False
            txtDate.Visible = False
            divDate.Visible = False
            lnkDate.Visible = False
            TRHeader.Visible = True
            TRFirstRemain.Visible = False
            TRLastRemain.Visible = False
        End Sub

        ' dgtResult_ItemCreated event
        Private Sub dgtResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgtResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    tblCell = e.Item.Cells(7)
                    Dim tblCell1 As TableCell
                    tblCell1 = e.Item.Cells(6)

                    Dim btnDel As LinkButton
                    Dim btnUpdate As LinkButton

                    btnDel = tblCell.Controls(0)
                    btnUpdate = tblCell1.Controls(0)

                    Select Case Request("Display")
                        Case 1
                            btnDel.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(27).Text & "')==false) {return false}")
                        Case 2
                            btnDel.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(26).Text & "')==false) {return false}")
                    End Select
                    If Not btnUpdate Is Nothing Then
                        btnUpdate.Attributes.Add("onclick", "javascript:return(CheckInsertUpdate('document.forms[0].dgtResult__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabel.Items(18).Text & "','" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(13).Text & "'));")
                    End If
            End Select
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBAccounting Is Nothing Then
                    objBAccounting.Dispose(True)
                    objBAccounting = Nothing
                End If
                If Not objBPurchaseOrder Is Nothing Then
                    objBPurchaseOrder.Dispose(True)
                    objBPurchaseOrder = Nothing
                End If
                If Not objBBudget Is Nothing Then
                    objBBudget.Dispose(True)
                    objBBudget = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
        Protected Sub ddlPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPO.SelectedIndexChanged
            Dim dblTotalReal As Long = 0
            Dim strCurrencyOfPo As String = ""
            objBPO.AcqPOID = ddlPO.SelectedValue
            objBPO.LibID = clsSession.GlbSite
            Dim tblPo As DataTable = objBPO.GetPO("")
            If Not IsNothing(tblPo) Then
                If tblPo.Rows.Count > 0 Then
                    ''Tinh tong thuc chi cho don dat:
                    'objBAccounting.PoID = GetPoId(CInt(ddlPO.SelectedValue))
                    'Dim tblTemp As DataTable = objBAccounting.GetDebitAmount(0)
                    'If Not tblTemp Is Nothing Then
                    '    For intIndex = 0 To tblTemp.Rows.Count - 1
                    '        If strCurrencyOfPo = CStr(tblTemp.Rows(intIndex).Item("ExchangeRate")) Then
                    '            'dblTotalReal = dblTotalReal + CLng(tblTemp.Rows(intIndex).Item("Amount")) * CLng(tblTemp.Rows(intIndex).Item("ExchangeRate"))
                    '            'dblTotalReal = CLng(tblTemp.Rows(intIndex).Item("Amount")) * CLng(tblTemp.Rows(intIndex).Item("ExchangeRate"))
                    '            dblTotalReal = CLng(tblTemp.Rows(intIndex).Item("Amount")) * CLng(tblTemp.Rows(intIndex).Item("ExchangeRate"))
                    '        Else
                    '            'dblTotalReal = dblTotalReal + CLng(tblTemp.Rows(intIndex).Item("Amount"))
                    '            dblTotalReal = CLng(tblTemp.Rows(intIndex).Item("Amount"))
                    '        End If
                    '    Next
                    '    tblTemp.Clear()
                    'End If

                    For intIndex = 0 To tblPo.Rows.Count - 1
                        dblTotalReal = CLng(tblPo.Rows(intIndex).Item("TotalAmount")) - (CLng(tblPo.Rows(intIndex).Item("TotalAmount")) * CLng(tblPo.Rows(intIndex).Item("Discount")) / 100)
                    Next

                    txtAmount.Text = Trim(Str(CLng(dblTotalReal)))
                    txtAmount.Text = If(Not (txtAmount.Text = "0"), CDbl(txtAmount.Text).ToString("#,##"), "0")
                    'txtAmount.Text = CInt(tblPo.Rows(0).Item("TotalAmount"))
                    txtRate.Text = tblPo.Rows(0).Item("FixedRate")
                    txtRate.Text = If(Not (txtRate.Text = "0"), CDbl(txtRate.Text).ToString("#,##"), "0")

                End If
            End If
        End Sub


        Public Function GetPoId(ByVal intPoID As Integer) As String
            'quocDD
            ' Get Po by number row 
            objBPO.AcqPOID = intPoID
            objBPO.LibID = clsSession.GlbSite
            Dim tblTemp As DataTable
            tblTemp = objBPO.GetPO("")
            Dim PoID = 0
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                PoID = tblTemp.Rows(0).Item("Id").ToString()
                ' set id for AcqPo again
                objBPO.AcqPOID = PoID

            End If
            Return PoID
        End Function
        Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatus.SelectedIndexChanged
            Dim tblPO As DataTable
            ' Get the PO
            objBPurchaseOrder.LibID = clsSession.GlbSite
            tblPO = objBPurchaseOrder.GetPO("", ddlStatus.SelectedValue)

            If Not tblPO Is Nothing Then
                If tblPO.Rows.Count > 0 Then
                    ddlPO.DataSource = InsertOneRow(tblPO, ddlLabel.Items(0).Text)
                    ddlPO.DataTextField = "ReceiptNo"
                    ddlPO.DataValueField = "ID"
                    ddlPO.DataBind()
                Else
                    ddlPO.DataSource = InsertOneRow(tblPO, ddlLabel.Items(0).Text)
                    ddlPO.DataTextField = "ReceiptNo"
                    ddlPO.DataValueField = "ID"
                    ddlPO.DataBind()
                End If
            Else
                ddlPO.DataSource = InsertOneRow(tblPO, ddlLabel.Items(0).Text)
                ddlPO.DataTextField = "ReceiptNo"
                ddlPO.DataValueField = "ID"
                ddlPO.DataBind()
            End If
        End Sub

    End Class
End Namespace