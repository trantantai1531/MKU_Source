Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WAccountDetail
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTemp2 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBAccountTrans As New clsBAccountTransaction
        Private objBCommonBussiness As New clsBCommonBusiness

        Private dblSeetled As Double = 0
        Private dblUnSeetled As Double = 0
        Private dblRemain As Double = 0
        Private intDisplay As Int16 = 1
        Private tblAccount As DataTable
        Private intIndexShare As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call BindDropDownList()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Account/WAccountDetail.js'></script>")

            btnAction.Attributes.Add("Onclick", "javascript:if(!CheckAll('" & ddlLabel.Items(18).Text & "','" & ddlLabel.Items(13).Text & "','" & ddlLabel.Items(14).Text & "')) {return false;}")
            btnCancel.Attributes.Add("OnClick", "javascript:document.forms[0].reset();document.forms[0].txtDate.value=document.forms[0].hidToday.value; return false;")

            Me.SetCheckNumber(txtAmount, ddlLabel.Items(15).Text, "0")
            txtRate.Attributes.Add("OnChange", "javascript:if(!CheckNumber(this,'" & ddlLabel.Items(16).Text & "')) {ChangeRate(document.forms[0].hidCurrency.value);return false;}")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDate, txtDate, ddlLabel.Items(17).Text)
            lnkCheckDebt.NavigateUrl = "javascript:OpenWindow('WCheckDebt.aspx?CustomerCode=' + document.forms[0].txtCustomerCode.value,'CheckDebt',600,350,100,50)"
            ' Check Number of text box year
            txtYear.Attributes.Add("OnChange", "javascript:if(!CheckNumBer('document.forms[0].txtYear','" & ddlLabel.Items(0).Text & "' ," & Year(Session("ToDay")) & ")){ return false; } else {if (this.value.length > 4) {this.value = '" & Year(Session("ToDay")) & "'; this.focus(); return false;}}")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBAccountTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccountTrans.DBServer = Session("DBServer")
            objBAccountTrans.ConnectionString = Session("ConnectionString")
            Call objBAccountTrans.Initialize()

            ' Init for objBCirCommon
            objBCommonBussiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBussiness.DBServer = Session("DBServer")
            objBCommonBussiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBussiness.Initialize()

            txtDate.Text = Session("ToDay")
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(162) Then
                Call WriteErrorMssg(ddlLabel.Items(25).Text)
            End If
        End Sub

        ' BindData method
        Private Sub BindData()

            ' Get the current date
            txtDate.Text = Session("Today") & ""
            hidToday.Value = txtDate.Text

            ' Display the settled fees list
            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                    intDisplay = 1
                End If
                lblSettledTitle.Visible = True
                lblReportTitle.Visible = False
                lblFineDetails.Visible = True
                ddlFineType.Visible = True
                lblReportDetails.Visible = False
                VisibleTableRows()
                ' Display the Unsettled fees list
            ElseIf Trim(Request("Display")) = "0" Then
                intDisplay = 0
                lblSettledTitle.Visible = False
                lblReportTitle.Visible = True
                lblFineDetails.Visible = False
                lblReportDetails.Visible = True
                ddlFineType.Visible = False
                DisableTableRows()
            End If

            lnkReport.NavigateUrl = "#"
            lnkSettled.NavigateUrl = "#"
            lnkSettled.Attributes.Add("OnClick", "javascript:location.href='WAccountDetail.aspx?Display=1'")
            lnkReport.Attributes.Add("OnClick", "javascript:location.href='WAccountDetail.aspx?Display=0'")

            ' Get the data from database
            tblAccount = objBAccountTrans.GetAccInfor(intDisplay, dblSeetled, dblUnSeetled, dblRemain)
            Call WriteErrorMssg(ddlLabel.Items(27).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(26).Text, objBAccountTrans.ErrorCode)

            ' Get the Sum of seetled fees, unseetled fees and remain
            If Not tblAccount Is Nothing Then
                lblUnSettledAmount.Text = dblUnSeetled
                lblSettledAmount.Text = dblSeetled
                lblRemainAmount.Text = dblRemain

                Select Case Trim(Request("Display"))
                    Case "1", Nothing
                        lblSumary.Text = dblSeetled
                        If tblAccount.Rows.Count > 0 Then
                            TRSumary.Visible = True
                            btnPrint.Enabled = True
                        Else
                            TRSumary.Visible = False
                            btnPrint.Enabled = False
                        End If
                End Select
            Else
                lblUnSettledAmount.Text = "0.00"
                lblSettledAmount.Text = "0.00"
                lblRemainAmount.Text = "0.00"
                TRSumary.Visible = False
                btnPrint.Enabled = False
            End If

            ' For display settled and unsetlled fees
            If intDisplay = 1 Then
                dgtResult.DataSource = tblAccount
                dgtResult.DataBind()
                btnPrint.Attributes.Add("OnClick", "javascript:var CustomerCode; var Year; if(CheckNull(document.forms[0].txtCustomerCodeToFil)) CustomerCode='0'; else CustomerCode=document.forms[0].txtCustomerCodeToFil.value; if(CheckNull(document.forms[0].txtYear)) Year='0'; else Year=document.forms[0].txtYear.value;OpenWindow('WFeesReport.aspx?Display=" & intDisplay & "&CustomerCode=' + CustomerCode + '&Month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value + '&Year=' + Year,'FeesReport',650,500,70,10);return false;")
                ' Display the accounting report
            ElseIf intDisplay = 0 Then
                btnPrint.Attributes.Add("OnClick", "javascript:var CustomerCode; var Year; if(CheckNull(document.forms[0].txtCustomerCodeToFil)) CustomerCode='0'; else CustomerCode=document.forms[0].txtCustomerCodeToFil.value; if(CheckNull(document.forms[0].txtYear)) Year='0'; else Year=document.forms[0].txtYear.value;OpenWindow('WAccountReport.aspx?CustomerCode=' + CustomerCode + '&Month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value + '&Year=' + Year,'FeesReport',650,500,70,10); return false;")
                TRSumary.Visible = False
                Call ShowAccountReport()
            End If
        End Sub

        ' btnFilter_Click event
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Call FilterData()
            Call CheckDebt()
        End Sub

        ' FilterData method
        ' Purpose: Filter the data by Customer code, month and year
        Private Sub FilterData()
            ' Declare variables
            Dim strJS As String
            Dim strYear As String
            Dim strMonth As String
            Dim strCustomerCode As String

            ' Get the year value from input(if year is null, month not null -> year = current year)
            If Trim(CStr(ddlMonth.SelectedValue)) <> "0" And (Trim(txtYear.Text) = "") Then
                strYear = Year(Now)
                txtYear.Text = strYear
            Else
                If Trim(txtYear.Text) = "" Then
                    strYear = "0"
                Else
                    strYear = Trim(txtYear.Text)
                End If
            End If

            ' Get the patron code from input
            If Trim(txtCustomerCodeToFil.Text) = "" Then
                strCustomerCode = ""
            Else
                strCustomerCode = Trim(txtCustomerCodeToFil.Text)
            End If

            ' Get the month value from input
            strMonth = CStr(ddlMonth.SelectedValue)

            ' Get the type of display mode (seetled, unseetled or report)
            If Trim(Request("Display")) = "1" Or Trim(Request("Display")) = Nothing Then
                If ddlFineType.SelectedIndex = 0 Then
                    intDisplay = 1
                Else
                    intDisplay = 2
                End If
            ElseIf Trim(Request("Display")) = "0" Then
                intDisplay = 0
            End If

            ' Transfer the properties for class B 
            objBAccountTrans.Year = CInt(strYear)
            objBAccountTrans.CustomerCode = strCustomerCode
            objBAccountTrans.Month = CInt(strMonth)
            tblAccount = objBAccountTrans.GetAccInfor(intDisplay, dblSeetled, dblUnSeetled, dblRemain) ' Get the data
            Call WriteErrorMssg(ddlLabel.Items(27).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(26).Text, objBAccountTrans.ErrorCode)

            ' Display the sum of seetled, unseetled and remain amount
            If Not tblAccount Is Nothing Then
                lblUnSettledAmount.Text = dblUnSeetled
                lblSettledAmount.Text = dblSeetled
                lblRemainAmount.Text = dblRemain

                Select Case intDisplay
                    Case 1
                        lblSumary.Text = dblSeetled
                        If tblAccount.Rows.Count > 0 Then
                            TRSumary.Visible = True
                            btnPrint.Enabled = True
                        Else
                            TRSumary.Visible = False
                            btnPrint.Enabled = False
                        End If
                    Case 2
                        lblSumary.Text = dblUnSeetled
                        If tblAccount.Rows.Count > 0 Then
                            TRSumary.Visible = True
                            btnPrint.Enabled = True
                        Else
                            TRSumary.Visible = False
                            btnPrint.Enabled = False
                        End If
                End Select
            Else
                lblUnSettledAmount.Text = "0.00"
                lblSettledAmount.Text = "0.00"
                lblRemainAmount.Text = "0.00"
                TRSumary.Visible = False
                btnPrint.Enabled = False
            End If

            ' Display the result (For each display mode)
            If intDisplay = 1 Or intDisplay = 2 Then
                dgtResult.DataSource = tblAccount
                dgtResult.DataBind()
                btnPrint.Attributes.Add("OnClick", "javascript:var CustomerCode; var Year; if(CheckNull(document.forms[0].txtCustomerCodeToFil)) CustomerCode='0'; else CustomerCode=document.forms[0].txtCustomerCodeToFil.value; if(CheckNull(document.forms[0].txtYear)) Year='0'; else Year=document.forms[0].txtYear.value;OpenWindow('WFeesReport.aspx?Display=" & intDisplay & "&CustomerCode=' + CustomerCode + '&Month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value + '&Year=' + Year,'FeesReport',650,500,70,10);return false;")
            ElseIf intDisplay = 0 Then
                Call ShowAccountReport()
                TRSumary.Visible = False
            End If
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

            If Not tblAccount Is Nothing Then
                intSumFound = CInt(tblAccount.Rows.Count)   ' Sum of records found
                If intSumFound > 0 Then
                    ' Declare the table row and cell variables
                    Dim tblRow As TableRow
                    Dim tblCell As TableCell

                    ' Add attributes for dinamic table
                    tblReport.BorderWidth = Unit.Pixel(0)
                    tblReport.Width = Unit.Percentage(100)

                    ' Display the report header (3 rows)
                    For inti = 0 To 2
                        tblRow = New TableRow
                        Select Case inti
                            Case 0
                                tblCell = New TableCell
                                tblCell.ColumnSpan = 11
                                tblCell.CssClass = "lbSubTitle"
                                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(1).Text))
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblRow.Cells.Add(tblCell)
                                tblRow.CssClass = "lbGridPager"
                            Case 1
                                For intj = 0 To 4
                                    tblCell = New TableCell
                                    Select Case intj
                                        Case 0
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(2).Text))
                                        Case 1
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
                                        Case 2
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
                                        Case 3
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(5).Text))
                                        Case 4
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(6).Text))
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                    tblRow.CssClass = "lbGridHeader"
                                Next
                            Case 2
                                tblCell = New TableCell
                                For intk = 0 To 7
                                    tblCell = New TableCell
                                    Select Case intk
                                        Case 0, 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(7).Text))
                                        Case 1, 5
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(8).Text))
                                        Case 2, 6
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(9).Text))
                                        Case 3, 7
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(10).Text))
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
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("FROMDATE")) Then
                            strCreatedDate = Trim(CStr(tblAccount.Rows(intIndex).Item("FROMDATE")))
                        Else
                            strCreatedDate = ""
                        End If
                        ' Note
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Note")) Then
                            strNote = Trim(CStr(tblAccount.Rows(intIndex).Item("Note")))
                        Else
                            strNote = ""
                        End If
                        ' Amount
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Amount")) Then
                            strAmount = Trim(CStr(tblAccount.Rows(intIndex).Item("Amount")))
                        Else
                            strAmount = ""
                        End If
                        ' Currency Code
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Currency")) Then
                            strCurrency = Trim(CStr(tblAccount.Rows(intIndex).Item("Currency")))
                        Else
                            strCurrency = ""
                        End If
                        ' Rate (At the new settled or unsttled making time)
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("DRate")) Then
                            strRate = Trim(CStr(tblAccount.Rows(intIndex).Item("DRate")))
                        Else
                            strRate = ""
                        End If
                        ' Rate (current rate)
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("SRate")) Then
                            strSRate = Trim(CStr(tblAccount.Rows(intIndex).Item("SRate")))
                        Else
                            strSRate = ""
                        End If

                        ' Total of amount
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Total")) Then
                            strTotal = Trim(CStr(tblAccount.Rows(intIndex).Item("Total")))
                        Else
                            strTotal = ""
                        End If

                        ' Paid or not
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("RequestID")) Then
                            intIsSeetled = 0
                        Else
                            intIsSeetled = 1
                        End If

                        ' Subtract with 2 other rates
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("SRate")) And Not IsDBNull(tblAccount.Rows(intIndex).Item("Amount")) And Not IsDBNull(tblAccount.Rows(intIndex).Item("Total")) Then
                            dblRealTotal = CDbl(strSRate) * CDbl(strAmount)
                        End If

                        If intIsSeetled = 0 Then
                            strSubtract = CStr(CDbl(strTotal) - dblRealTotal)
                            dblSubtractTotal2 = dblSubtractTotal2 + CDbl(strSubtract)
                        Else
                            strSubtract = CStr(CDbl(strTotal) - dblRealTotal)
                            dblSubtractTotal1 = dblSubtractTotal1 + CDbl(strSubtract)
                        End If

                        ' Make the css for rows
                        If intIndex Mod 2 = 0 Then
                            tblRow.CssClass = "lbGridCell"
                        Else
                            tblRow.CssClass = "lbGridAlterCell"
                        End If

                        ' Begin displaying the content (11 column)
                        For intl = 0 To 10
                            Select Case intl
                                Case 0  ' Created Date
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(7%)
                                    tblCell.Controls.Add(New LiteralControl(strCreatedDate))
                                Case 1  ' Reason
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(33%)
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
                                Case 6  ' Amount (UnSeetled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(CStr(CDbl(strAmount))))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 7  ' Currency Code (UnSeetled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strCurrency))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 8  ' Transaction rate (UnSeetled)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(5%)
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strRate))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 9 ' Subtract with 2 amount (current rate and transaction rate - UnSeetled)
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
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Controls.Add(New LiteralControl(strSRate))
                            End Select
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblReport.Rows.Add(tblRow)
                    Next

                    ' Display the footer (2 rows)
                    For intIndex = 0 To 1
                        tblRow = New TableRow
                        Select Case intIndex
                            ' Display the sumarry
                            Case 0
                                For intm = 0 To 5
                                    Select Case intm
                                        Case 0  ' Label: SUM
                                            tblCell = New TableCell
                                            tblCell.ColumnSpan = 2
                                            tblCell.CssClass = "lbSubTitle"
                                            tblCell.HorizontalAlign = HorizontalAlign.Left
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(11).Text))
                                        Case 1  ' Sum of seetled fees
                                            tblCell = New TableCell
                                            tblCell.ColumnSpan = 3
                                            tblCell.HorizontalAlign = HorizontalAlign.Left
                                            tblCell.CssClass = "lbAmount"
                                            strSum1 = Trim(CStr(dblSeetled))
                                            If CDbl(strSum1) <> "0" Then
                                                tblCell.Controls.Add(New LiteralControl(strSum1))
                                            Else
                                                tblCell.Controls.Add(New LiteralControl("0.00"))
                                            End If
                                        Case 2  ' Sum of subtract (seetled)
                                            tblCell = New TableCell
                                            tblCell.HorizontalAlign = HorizontalAlign.Right
                                            If dblSubtractTotal1 <> 0 Then
                                                tblCell.Controls.Add(New LiteralControl(CStr(dblSubtractTotal1)))
                                            Else
                                                tblCell.Controls.Add(New LiteralControl("0.00"))
                                            End If
                                        Case 3  ' Sum of Unseetled fees
                                            tblCell = New TableCell
                                            tblCell.ColumnSpan = 3
                                            tblCell.HorizontalAlign = HorizontalAlign.Left
                                            tblCell.CssClass = "lbAmount"
                                            strSum2 = Trim(CStr(dblUnSeetled))
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
                                    'tblRow.CssClass = "lbGridHeader"
                                Next

                                ' Display the remain amount
                            Case 1
                                tblCell = New TableCell
                                tblCell.ColumnSpan = 11
                                tblCell.HorizontalAlign = HorizontalAlign.Right
                                tblCell.CssClass = "lbSubTitle"

                                If dblRemain <> 0 Then
                                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(12).Text & ": <span id=""lblRemainder"" class=""lbAmount"">" & CStr(dblRemain) & " VND</span>"))
                                Else
                                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(12).Text & ": <span id=""lblRemainder"" class=""lbAmount"">0.00 VND</span>"))
                                End If
                                tblRow.CssClass = "lbGridPager"
                                tblRow.Cells.Add(tblCell)
                        End Select
                        tblReport.Rows.Add(tblRow)
                    Next
                End If
            End If
        End Sub

        ' BindDropDownList method
        ' Purpose: Get the currency data
        Private Sub BindDropDownList()
            Dim tblCurrency As DataTable
            Dim intCount As Integer
            Dim intIndex As Integer
            Dim strScript As String
            Dim inti As Integer

            objBCommonBussiness.CurrencyCode = ""
            tblCurrency = objBCommonBussiness.GetCurrency()
            Call WriteErrorMssg(ddlLabel.Items(27).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(26).Text, objBCommonBussiness.ErrorCode)

            ' Currency Data
            With ddlCurrency
                .DataSource = tblCurrency
                .DataTextField = "CurrencyCode"
                .DataValueField = "CurrencyCode"
                .DataBind()
            End With

            ' Get the VND currency
            For inti = 0 To ddlCurrency.Items.Count - 1
                If ddlCurrency.Items(inti).Value = "VND" Then
                    ddlCurrency.Items(inti).Selected = True
                End If
            Next

            If Not tblCurrency Is Nothing Then
                intCount = CInt(tblCurrency.Rows.Count)
            End If

            If intCount > 0 Then
                strScript = "<script Language='JavaScript'>"
                strScript = strScript & "arrCurrency = new Array(" & intCount & ");" & Chr(10)
                strScript = strScript & "arrRate = new Array(" & intCount & ");" & Chr(10)
                For intIndex = 0 To intCount - 1
                    strScript = strScript & "arrCurrency[" & intIndex & "]='" & tblCurrency.Rows(intIndex).Item("CurrencyCode") & "';" & Chr(10)
                    strScript = strScript & "arrRate[" & intIndex & "]=" & tblCurrency.Rows(intIndex).Item("Rate") & ";" & Chr(10)
                Next
                strScript = strScript & "function ChangeRate(Id) {" & Chr(10)
                strScript = strScript & "vRate = Id;document.forms[0].hidCurrency.value=vRate;" & Chr(10)
                strScript = strScript & "for (i = 0; i <=" & intCount & "; i++){" & Chr(10)
                strScript = strScript & "if (arrCurrency[i] == vRate){" & Chr(10)
                strScript = strScript & "document.forms[0].txtRate.value = arrRate[i];}}}" & Chr(10)
                strScript = strScript & "</script>"
            End If
            Page.RegisterClientScriptBlock("ChangeRate", strScript)
            ddlCurrency.Attributes.Add("OnChange", "ChangeRate(this.options[this.options.selectedIndex].value);")
        End Sub

        ' txtCustomerCode_TextChanged event
        ' Get the account infor and debt infor of an edeliv - user
        Private Sub txtCustomerCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerCode.TextChanged
            ddlFineType.SelectedIndex = 1
            txtCustomerCodeToFil.Text = txtCustomerCode.Text
            Call FilterData()
            Call CheckDebt()
        End Sub

        ' CheckDebt method
        ' Purpose: Gey the debt infor of an edeliv - user
        Private Sub CheckDebt()
            Dim dblDebt As Double
            Dim intOutPut As Int16
            Dim tblDebt As DataTable
            Dim intCount As Integer = 0
            Dim strIDs As String = ""

            objBAccountTrans.CustomerCode = Trim(txtCustomerCode.Text)
            tblDebt = objBAccountTrans.CheckDebt(dblDebt, intOutPut)
            Call WriteErrorMssg(ddlLabel.Items(27).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(26).Text, objBAccountTrans.ErrorCode)

            ' get the amount have to pay and debt
            If dblDebt < 0 Then
                txtDebt.Text = CStr(dblDebt * (-1))
                txtAmount.Text = CStr(dblDebt * (-1))
            Else
                txtDebt.Text = "0"
                txtAmount.Text = "0"
            End If

            ' Get the payment IDs 
            If Not tblDebt Is Nothing Then
                If tblDebt.Rows.Count > 0 Then
                    For intCount = 0 To tblDebt.Rows.Count - 1
                        strIDs = strIDs & tblDebt.Rows(intCount).Item("ID") & ","
                    Next
                    hidIDs.Value = Left(strIDs, Len(strIDs) - 1)
                    txtReason.Text = ddlLabel.Items(24).Text
                Else
                    hidIDs.Value = ""
                    txtReason.Text = ""
                End If
            Else
                hidIDs.Value = ""
                txtReason.Text = ""
            End If
        End Sub

        ' btnAction_Click event
        ' Purpose: Insert new settled fee of an customer
        Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
            ' Declare Variables
            Dim intOutPut As Int16 = 2
            Dim strLog As String

            ' Get properties
            objBAccountTrans.CustomerCode = Trim(txtCustomerCode.Text)
            objBAccountTrans.CurrencyCode = Trim(hidCurrency.Value)
            objBAccountTrans.Rate = CDbl(Trim(txtRate.Text))
            objBAccountTrans.CreatedDate = Trim(txtDate.Text)

            If txtReason.Text <> "" Then
                objBAccountTrans.Reason = Trim(txtReason.Text)
            Else
                objBAccountTrans.Reason = ""
            End If

            If hidIDs.Value <> "" Then
                objBAccountTrans.PaymentIDs = hidIDs.Value
            Else
                objBAccountTrans.PaymentIDs = ""
            End If

            objBAccountTrans.Amount = CDbl(Trim(txtAmount.Text))

            ' Create seetled fee
            intOutPut = objBAccountTrans.Create()
            Call WriteErrorMssg(ddlLabel.Items(27).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(26).Text, objBAccountTrans.ErrorCode)

            strLog = lblHeader.Text & ": " & lblSettledTitle.Text & ": "
            strLog = strLog & lblCustomerCode.Text & " " & txtCustomerCode.Text
            strLog = strLog & ", " & lblAmount.Text & " " & txtAmount.Text & " (" & ddlCurrency.SelectedValue & ")"
            strLog = strLog & ", " & lblRate.Text & " " & txtRate.Text
            strLog = strLog & ", " & lblDate.Text & " " & txtRate.Text
            strLog = strLog & ", " & lblReason.Text & " " & txtReason.Text

            If intOutPut = 1 Then
                Page.RegisterClientScriptBlock("NotExistCustomer", "<script language='javascript'>alert('" & ddlLabel.Items(19).Text & "')</script>")
            ElseIf intOutPut = 0 Then
                Call WriteLog(75, strLog, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('" & ddlLabel.Items(20).Text & "')</script>")
            Else
                Page.RegisterClientScriptBlock("Fail", "<script language='javascript'>alert('" & ddlLabel.Items(21).Text & "')</script>")
            End If

            ' Refresh Data
            Call FilterData()
            Call CheckDebt()
        End Sub

        ' VisibleTableRows method
        ' Purpose: Visible the table rows (Add new seetled or unsettled fees)
        Private Sub VisibleTableRows()
            TR1.Visible = True
            TR2.Visible = True
            TR3.Visible = True
            TR4.Visible = True
        End Sub

        ' VisibleTableRows method
        ' Purpose: Disable the table rows (Display report only)
        Private Sub DisableTableRows()
            TR1.Visible = False
            TR2.Visible = False
            TR3.Visible = False
            TR4.Visible = False
        End Sub

        ' dgtResult_ItemCreated event
        Private Sub dgtResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgtResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' Declare variables
                    Dim tblCell As TableCell
                    Dim tblCell1 As TableCell
                    Dim tblCell2 As TableCell
                    Dim lbl As Label
                    Dim btnDel As LinkButton
                    Dim btnUpdate As LinkButton

                    tblCell = e.Item.Cells(7)
                    tblCell1 = e.Item.Cells(10)
                    tblCell2 = e.Item.Cells(9)

                    lbl = CType(tblCell.FindControl("lblPaid"), Label)
                    If DataBinder.Eval(e.Item.DataItem, "Paid") = "1" Then
                        lbl.Text = "x"
                    Else
                        lbl.Text = ""
                    End If
                    btnDel = tblCell1.Controls(0)
                    btnUpdate = tblCell2.Controls(0)

                    btnDel.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(30).Text & "')==false) {return false}")
                    If Not btnUpdate Is Nothing Then
                        btnUpdate.Attributes.Add("onclick", "javascript:return(CheckInsertUpdate('document.forms[0].dgtResult__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabel.Items(18).Text & "','" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(13).Text & "'));")
                    End If
            End Select
        End Sub

        ' Edit event of DataGrid
        Private Sub dgtResult_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.EditCommand
            Dim ddlCurrencyDisplay As New DropDownList
            Dim intIndex As Integer
            Dim intCount As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim strCurrency As String
            Dim strScript As String
            Dim lnkCalendarDisplay As HyperLink

            intIndex = CInt(e.Item.ItemIndex)
            intIndexShare = intIndex

            dgtResult.EditItemIndex = intIndex

            Call FilterData()
            Call CheckDebt()

            ' Load all Controls to DataGrid
            ddlCurrencyDisplay = CType(dgtResult.Items(intIndex).Cells(4).FindControl("ddlCurrencyDisplay"), DropDownList)
            lnkCalendarDisplay = CType(dgtResult.Items(intIndex).Cells(0).FindControl("lnkCalendarDisplay"), HyperLink)
            strCurrency = CType(dgtResult.Items(intIndex).Cells(4).FindControl("txtCurrencyHid"), TextBox).Text
            CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(0).FindControl("txtCreatedDate"), TextBox).Attributes.Add("OnChange", "javascript:if (!CheckDate(this,'dd/mm/yyyy','" & ddlLabel.Items(17).Text & "'))return false;")
            CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(3).FindControl("txtAmountDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(13).Text & "')) {this.focus();this.value='';return false;}")
            CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(5).FindControl("txtRateDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(14).Text & "')) {this.focus();this.value='';return false;}")

            Page.RegisterClientScriptBlock("ChangeRate", strScript)
            ddlCurrency.Attributes.Add("OnChange", "ChangeRate(this.options[this.options.selectedIndex].value);")

            ddlCurrencyDisplay.DataSource = objBCommonBussiness.GetCurrency
            ddlCurrencyDisplay.DataTextField = "CurrencyCode"
            ddlCurrencyDisplay.DataValueField = "CurrencyCode"
            ddlCurrencyDisplay.DataBind()

            If Not objBCommonBussiness.GetCurrency Is Nothing Then
                intCount = CInt(objBCommonBussiness.GetCurrency.Rows.Count)
                Call WriteErrorMssg(ddlLabel.Items(27).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(26).Text, objBCommonBussiness.ErrorCode)
            End If

            If intCount > 0 Then
                strScript = "<script Language='JavaScript'>"
                strScript = strScript & "arrCurrency = new Array(" & intCount & ");" & Chr(10)
                strScript = strScript & "arrRate = new Array(" & intCount & ");" & Chr(10)
                For intj = 0 To intCount - 1
                    strScript = strScript & "arrCurrency[" & intj & "]='" & objBCommonBussiness.GetCurrency.Rows(intj).Item("CurrencyCode") & "';" & Chr(10)
                    strScript = strScript & "arrRate[" & intj & "]=" & objBCommonBussiness.GetCurrency.Rows(intj).Item("Rate") & ";" & Chr(10)
                Next
                strScript = strScript & "function ChangeRateValue(Id) {" & Chr(10)
                strScript = strScript & "vRate = Id;" & Chr(10)
                strScript = strScript & "for (i = 0; i <=" & intCount & "; i++){" & Chr(10)
                strScript = strScript & "if (arrCurrency[i] == vRate){" & Chr(10)
                strScript = strScript & "eval('document.forms[0].dgtResult__ctl" & intIndex + 2 & "_txtRateDisplay').value = arrRate[i];}}}" & Chr(10)
                strScript = strScript & "</script>"
                Page.RegisterClientScriptBlock("ChangeRateValue", strScript)
                ddlCurrencyDisplay.Attributes.Add("OnChange", "ChangeRateValue(this.options[this.options.selectedIndex].value," & intIndex + 2 & ");")
            End If
            'SetOnclickCalendar(lnkCalendarDisplay, "dgtResult__ctl" & CStr(intIndex + 2) & "_txtCreatedDate", ddlLabel.Items(17).Text)

            For inti = 0 To ddlCurrencyDisplay.Items.Count - 1
                If CStr(ddlCurrencyDisplay.Items(inti).Value) = strCurrency Then
                    ddlCurrencyDisplay.Items(inti).Selected = True
                Else
                    ddlCurrencyDisplay.Items(inti).Selected = False
                End If
            Next
        End Sub

        ' Cancel event of DataGrid
        Private Sub dgtResult_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.CancelCommand
            dgtResult.EditItemIndex = -1
            Call FilterData()
            Call CheckDebt()
        End Sub

        ' Update event of DataGrid
        ' Purpose: Update selected Fine
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
            Dim intOutPut As Int16 = 2
            Dim strLog As String

            ' Get data to Update
            intIndex = e.Item.ItemIndex
            intID = Trim(CInt(CType(dgtResult.Items(intIndex).Cells(9).FindControl("lblID"), Label).Text))
            strCreatedDate = Trim(CType(dgtResult.Items(intIndex).Cells(0).FindControl("txtCreatedDate"), TextBox).Text)

            If CType(dgtResult.Items(intIndex).Cells(2).FindControl("txtReasonDisplay"), TextBox).Text <> "" Then
                strReason = Trim(CType(dgtResult.Items(intIndex).Cells(2).FindControl("txtReasonDisplay"), TextBox).Text)
            Else
                strReason = ""
            End If

            strAmount = Trim(CType(dgtResult.Items(intIndex).Cells(3).FindControl("txtAmountDisplay"), TextBox).Text)
            strRate = Trim(CType(dgtResult.Items(intIndex).Cells(5).FindControl("txtRateDisplay"), TextBox).Text)

            If CType(dgtResult.Items(intIndex).Cells(4).FindControl("ddlCurrencyDisplay"), DropDownList).SelectedValue <> "" Then
                strCurrency = CStr(CType(dgtResult.Items(intIndex).Cells(4).FindControl("ddlCurrencyDisplay"), DropDownList).SelectedValue)
            Else
                strCurrency = ""
            End If

            If strCreatedDate = "" Or strAmount = "" Or strCurrency = "" Or strRate = "" Then
                blnValid = False
            Else
                blnValid = True
            End If

            ' Not null values
            If blnValid = True Then
                dblAmount = CDbl(strAmount)
                dblRate = CDbl(strRate)
                ' Transfer the property
                objBAccountTrans.PaymentID = intID
                objBAccountTrans.CurrencyCode = strCurrency
                objBAccountTrans.Rate = dblRate
                objBAccountTrans.CreatedDate = strCreatedDate
                objBAccountTrans.Reason = strReason
                objBAccountTrans.Amount = dblAmount

                strLog = lblHeader.Text & ": " & ddlLabel.Items(28).Text & " (PaymentID: " & intID & "): "
                strLog = strLog & lblCustomerCode.Text & " " & txtCustomerCode.Text
                strLog = strLog & ", " & lblAmount.Text & " " & strAmount & " (" & strCurrency & ")"
                strLog = strLog & ", " & lblRate.Text & " " & dblRate
                strLog = strLog & ", " & lblDate.Text & " " & strCreatedDate
                strLog = strLog & ", " & lblReason.Text & " " & strReason

                ' Update
                intOutPut = objBAccountTrans.Update()
                Call WriteErrorMssg(ddlLabel.Items(27).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(26).Text, objBAccountTrans.ErrorCode)

                If intOutPut = 0 Then   ' Success
                    Call WriteLog(75, strLog, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('" & ddlLabel.Items(22).Text & "')</script>")
                    dgtResult.EditItemIndex = -1
                    Call FilterData()
                    Call CheckDebt()
                Else    ' Fail
                    Page.RegisterClientScriptBlock("Fail", "<script language='javascript'>alert('" & ddlLabel.Items(23).Text & "')</script>")
                    dgtResult.EditItemIndex = -1
                    Call FilterData()
                    Call CheckDebt()
                End If
            Else    ' Null values
                Page.RegisterClientScriptBlock("NullValue", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "')</script>")
                Call BindDinamicScript()
            End If
        End Sub

        ' BindDinamicScript method
        Private Sub BindDinamicScript()
            ' Declare variables
            Dim ddlCurrencyDisplay As New DropDownList
            Dim lnkCalendarDisplay As HyperLink
            Dim intCount As Integer
            Dim inti As Integer
            Dim intj As Integer
            Dim strCurrency As String
            Dim strScript As String


            If Not objBCommonBussiness.GetCurrency Is Nothing Then
                objBCommonBussiness.CurrencyCode = ""
                intCount = CInt(objBCommonBussiness.GetCurrency.Rows.Count)
                Call WriteErrorMssg(ddlLabel.Items(27).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(26).Text, objBCommonBussiness.ErrorCode)
            End If

            ddlCurrencyDisplay = CType(dgtResult.Items(intIndexShare).Cells(4).FindControl("ddlCurrencyDisplay"), DropDownList)
            strCurrency = CType(dgtResult.Items(intIndexShare).Cells(4).FindControl("txtCurrencyHid"), TextBox).Text

            lnkCalendarDisplay = CType(dgtResult.Items(intIndexShare).Cells(0).FindControl("lnkCalendarDisplay"), HyperLink)

            If intCount > 0 Then
                strScript = "<script Language='JavaScript'>"
                strScript = strScript & "arrCurrency = new Array(" & intCount & ");" & Chr(10)
                strScript = strScript & "arrRate = new Array(" & intCount & ");" & Chr(10)
                For intj = 0 To intCount - 1
                    strScript = strScript & "arrCurrency[" & intj & "]='" & objBCommonBussiness.GetCurrency.Rows(intj).Item("CurrencyCode") & "';" & Chr(10)
                    strScript = strScript & "arrRate[" & intj & "]=" & objBCommonBussiness.GetCurrency.Rows(intj).Item("Rate") & ";" & Chr(10)
                Next
                strScript = strScript & "function ChangeRateValue(Id) {" & Chr(10)
                strScript = strScript & "vRate = Id;" & Chr(10)
                strScript = strScript & "for (i = 0; i <=" & intCount & "; i++){" & Chr(10)
                strScript = strScript & "if (arrCurrency[i] == vRate){" & Chr(10)
                strScript = strScript & "eval('document.forms[0].dgtResult__ctl" & intIndexShare + 2 & "_txtRateDisplay').value = arrRate[i];}}}" & Chr(10)
                strScript = strScript & "</script>"
                Page.RegisterClientScriptBlock("ChangeRateValue", strScript)
                ddlCurrencyDisplay.Attributes.Add("OnChange", "ChangeRateValue(this.options[this.options.selectedIndex].value," & intIndexShare + 2 & ");")
            End If
            'SetOnclickCalendar(lnkCalendarDisplay, "dgtResult__ctl" & intIndexShare + 2 & "_txtCreatedDate", ddlLabel.Items(17).Text)

            For inti = 0 To ddlCurrencyDisplay.Items.Count - 1
                If CStr(ddlCurrencyDisplay.Items(inti).Value) = strCurrency Then
                    ddlCurrencyDisplay.Items(inti).Selected = True
                Else
                    ddlCurrencyDisplay.Items(inti).Selected = False
                End If
            Next
        End Sub

        ' Delete event of DataGrid
        Private Sub dgtResult_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.DeleteCommand
            ' Declare variables
            Dim intIndex As Integer
            Dim intID As Integer

            ' Get data to Delete
            intIndex = e.Item.ItemIndex

            intID = Trim(CInt(CType(dgtResult.Items(intIndex).Cells(8).FindControl("lblID"), Label).Text))
            objBAccountTrans.PaymentID = intID
            objBAccountTrans.Delete()
            Call WriteErrorMssg(ddlLabel.Items(27).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(26).Text, objBAccountTrans.ErrorCode)
            Call WriteLog(75, ddlLabel.Items(29).Text & " (PaymentID: " & intID & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call FilterData()
            Call CheckDebt()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not tblAccount Is Nothing Then
                    tblAccount.Dispose()
                    tblAccount = Nothing
                End If
                If Not objBAccountTrans Is Nothing Then
                    objBAccountTrans.Dispose(True)
                    objBAccountTrans = Nothing
                End If
                If Not objBCommonBussiness Is Nothing Then
                    objBCommonBussiness.Dispose(True)
                    objBCommonBussiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace