Imports eMicLibAdmin.BusinessRules.Acquisition
Imports Aspose.Cells
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports System.Globalization
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WAccountManagement
        Inherits clsWBase
        Implements IUCNumberOfRecord

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblReportHeader As System.Web.UI.WebControls.Label
        Protected WithEvents lblSum As System.Web.UI.WebControls.Label
        Protected WithEvents lblReportRemain As System.Web.UI.WebControls.Label
        Dim objBRateMan As New clsBRateMan

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()

            ' Initialize objBRateMan object
            objBRateMan.DBServer = Session("DBServer")
            objBRateMan.ConnectionString = Session("ConnectionString")
            objBRateMan.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRateMan.Initialize()
        End Sub

#End Region

        ' Declare variables
        Private objBAccountTrans As New clsBAccountTransaction
        Private objBCommonBusiness As New clsBCommonBusiness

        Private intDisplay As Int16 = 1
        Private tblAccount As DataTable
        Private intIndexShare As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                '  Call BindData()


            End If
            Call BindDropDownList()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBAccountTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccountTrans.DBServer = Session("DBServer")
            objBAccountTrans.ConnectionString = Session("ConnectionString")
            Call objBAccountTrans.Initialize()

            ' Init for objBCommonBusiness
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.UserID = Session("UserID")
            Call objBCommonBusiness.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Add new account
            If Not CheckPemission(151) Then
                btnAction.Enabled = False
            Else
                btnAction.Enabled = True
            End If
            ' Edit account
            If Not CheckPemission(185) Then
                dgtResult.Columns(8).Visible = False
            Else
                dgtResult.Columns(8).Visible = True
            End If
            ' Delete account
            If Not CheckPemission(186) Then
                dgtResult.Columns(9).Visible = False
            Else
                dgtResult.Columns(9).Visible = True
            End If
        End Sub

        ' BindJS method
        ' Purpose: Bind JAVASCRIPTS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Accounting/WAccountManagement.js'></script>")

            btnAction.Attributes.Add("Onclick", "javascript:if(!CheckAll('" & ddlLabel.Items(20).Text & "','" & ddlLabel.Items(15).Text & "','" & ddlLabel.Items(16).Text & "')) {return false;}")
            btnCancel.Attributes.Add("OnClick", "javascript:document.forms[0].reset(); document.forms[0].txtDate.value=document.forms[0].hidToday.value;return false;")

            txtAmount.Attributes.Add("OnChange", "javascript:if(!CheckNumber(this,'" & ddlLabel.Items(17).Text & "')) {this.value='0';return false;}")
            txtRate.Attributes.Add("OnChange", "javascript:if(!CheckNumber(this,'" & ddlLabel.Items(18).Text & "')) {ChangeRate(document.forms[0].hidCurrency.value);return false;}")
            txtDate.ToolTip = Session("DateFormat")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDate, txtDate, ddlLabel.Items(19).Text)
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Check Number of text box year 
            txtYear.Attributes.Add("OnChange", "javascript:if(!CheckNumber('document.forms[0].txtYear','" & ddlLabel.Items(2).Text & "')) return false;")

            ' Get the current day
            txtDate.Text = Session("Today")
            hidToday.Value = txtDate.Text

            ' Display the settled fees list
            If Request("Display") = 1 Or Request("Display") = Nothing Then
                chkPatronDept.Visible = True
                chkPatronDept.Text = ddlLabel.Items(33).Text
                intDisplay = 1
                objBAccountTrans.Type = 1
                lblSettledTitle.Visible = True
                lblUnSettledTitle.Visible = False
                lblReportTitle.Visible = False
                lblSettledDetails.Visible = True
                lblUnSettledDetails.Visible = False
                lblReportDetails.Visible = False
                lnkSettled.Visible = False
                lnkUnsettled.Visible = True
                lnkReport.Visible = True
                'lblTemp1.Visible = False
                'lblTemp2.Visible = True
                lnkUnsettled.NavigateUrl = "#"
                lnkReport.NavigateUrl = "#"
                lnkUnsettled.Attributes.Add("OnClick", "javascript:location.href='WAccountManagement.aspx?Display=2'")
                lnkReport.Attributes.Add("OnClick", "javascript:location.href='WAccountManagement.aspx?Display=0'")
                VisibleTableRows()
                pnReport.Visible = True
                ' Display the Unsettled fees list
            ElseIf Request("Display") = 2 Then
                chkPatronDept.Visible = True
                chkPatronDept.Text = ddlLabel.Items(34).Text
                intDisplay = 2
                objBAccountTrans.Type = 2
                lblSettledTitle.Visible = False
                lblUnSettledTitle.Visible = True
                lblReportTitle.Visible = False
                lblSettledDetails.Visible = False
                lblUnSettledDetails.Visible = True
                lblReportDetails.Visible = False
                lnkSettled.Visible = True
                lnkUnsettled.Visible = False
                lnkReport.Visible = True
                'lblTemp1.Visible = True
                'lblTemp2.Visible = False
                lnkSettled.NavigateUrl = "#"
                lnkReport.NavigateUrl = "#"
                lnkSettled.Attributes.Add("OnClick", "javascript:location.href='WAccountManagement.aspx?Display=1'")
                lnkReport.Attributes.Add("OnClick", "javascript:location.href='WAccountManagement.aspx?Display=0'")
                VisibleTableRows()
                pnReport.Visible = True
                ' Display the accounting report
            ElseIf Request("Display") = 0 Then
                chkPatronDept.Visible = False
                intDisplay = 0
                objBAccountTrans.Type = 0
                lblSettledTitle.Visible = False
                lblUnSettledTitle.Visible = False
                lblReportTitle.Visible = False 'True
                lblSettledDetails.Visible = False
                lblUnSettledDetails.Visible = False
                lblReportDetails.Visible = True
                lnkSettled.Visible = True
                lnkUnsettled.Visible = True
                lnkReport.Visible = False
                'lblTemp1.Visible = True
                'lblTemp2.Visible = False
                lnkSettled.NavigateUrl = "#"
                lnkUnsettled.NavigateUrl = "#"
                lnkSettled.Attributes.Add("OnClick", "javascript:location.href='WAccountManagement.aspx?Display=1'")
                lnkUnsettled.Attributes.Add("OnClick", "javascript:location.href='WAccountManagement.aspx?Display=2'")
                pnReport.Visible = False
                DisableTableRows()

                objBAccountTrans.Month = CType(ddlMonth.SelectedValue, Short)
                objBAccountTrans.Year = If(String.IsNullOrEmpty(txtYear.Text.Trim), 0, CInt(txtYear.Text))
            End If

            ' Get the data from database
            objBAccountTrans.LibID = clsSession.GlbSite
            tblAccount = objBAccountTrans.GetAccountInfor
            'For Each item As DataRow In tblAccount.Rows
            '    item.Item("Total") = item.Item("Total").ToString().Replace(".0", "")
            'Next
            ' Get the Sum of seetled fees, unseetled fees and remain
            If Not tblAccount Is Nothing Then
                lblUnSettledAmount.Text = objBAccountTrans.UnSettled.ToString("N1", CultureInfo.InvariantCulture).Replace(".0", "")
                lblSettledAmount.Text = objBAccountTrans.Settled.ToString("N0", CultureInfo.InvariantCulture)

                If objBAccountTrans.Remain * (-1) < 0 Then
                    lblRemainAmount.Text = "-" & objBAccountTrans.Remain.ToString("N0", CultureInfo.InvariantCulture)
                Else
                    lblRemainAmount.Text = (objBAccountTrans.Remain * (-1)).ToString("N0", CultureInfo.InvariantCulture)
                End If

                Select Case Request("Display")
                    Case 1, Nothing
                        If tblAccount.Rows.Count > 0 Then
                            lblSumary.Text = objBAccountTrans.Settled.ToString("N0", CultureInfo.InvariantCulture) & " VND"
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                    Case 2
                        If tblAccount.Rows.Count > 0 Then
                            lblSumary.Text = objBAccountTrans.UnSettled.ToString("N0", CultureInfo.InvariantCulture) & " VND"
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                End Select
            Else
                lblUnSettledAmount.Text = "0.00"
                lblSettledAmount.Text = "0.00"
                lblRemainAmount.Text = "0.00"
                TRSumary.Visible = False
            End If

            ' For display settled and unsetlled fees
            If intDisplay = 1 Or intDisplay = 2 Then
                If Not tblAccount Is Nothing AndAlso tblAccount.Rows.Count > 0 Then
                    dgtResult.Visible = True
                    dgtResult.DataSource = tblAccount
                    ' dgtResult.DataBind()
                    btnPrint.Attributes.Add("OnClick", "javascript:var PatronCode; var Year; if(CheckNull(document.forms[0].txtPaTronCodeToFil)) PatronCode='0'; else PatronCode=document.forms[0].txtPaTronCodeToFil.value; if(CheckNull(document.forms[0].txtYear)) Year='0'; else Year=document.forms[0].txtYear.value;OpenWindow('WFeesReport.aspx?Display=" & intDisplay & "&PatronCode=' + PatronCode + '&Month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value + '&Year=' + Year,'FeesReport',650,500,70,10);return false;")
                Else
                    dgtResult.Visible = False
                    'Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(32).Text.Trim & "');</script>")
                End If
                ' Display the accounting report
            ElseIf intDisplay = 0 Then
                btnPrint.Attributes.Add("OnClick", "javascript:var PatronCode; var Year; if(CheckNull(document.forms[0].txtPaTronCodeToFil)) PatronCode='0'; else PatronCode=document.forms[0].txtPaTronCodeToFil.value; if(CheckNull(document.forms[0].txtYear)) Year='0'; else Year=document.forms[0].txtYear.value;OpenWindow('WAccountReport.aspx?PatronCode=' + PatronCode + '&Month=' + document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.selectedIndex].value + '&Year=' + Year,'FeesReport',650,500,70,10); return false;")
                TRSumary.Visible = False
                Call ShowAccountReport()
            End If
        End Sub

        'BindData for Currency
        Private Sub BinDataCurrency()
            Dim tblCurrency As DataTable
            Dim intCount As Integer = 0
            Dim inti As Integer

            objBCommonBusiness.CurrencyCode = ""
            tblCurrency = objBCommonBusiness.GetCurrency
            If Not tblCurrency Is Nothing AndAlso tblCurrency.Rows.Count > 0 Then
                intCount = CInt(tblCurrency.Rows.Count)
                ' Currency Data
                With ddlCurrency
                    .DataSource = tblCurrency
                    .DataTextField = "CurrencyCode"
                    .DataValueField = "CurrencyCode"
                    .DataBind()
                End With

                For inti = 0 To ddlCurrency.Items.Count - 1
                    If ddlCurrency.Items(inti).Value = "VND" Then
                        ddlCurrency.Items(inti).Selected = True
                    End If
                Next
            End If
        End Sub


        ' BindDropDownList method
        Private Sub BindDropDownList()
            Dim tblCurrency As DataTable
            Dim intCount As Integer = 0
            Dim intIndex As Integer
            Dim strScript As String
            Dim inti As Integer

            objBCommonBusiness.CurrencyCode = ""
            tblCurrency = objBCommonBusiness.GetCurrency
            Dim currentSelectedIndex = ddlCurrency.SelectedIndex
            Dim currentSelectedValue = ddlCurrency.SelectedValue
            If Not tblCurrency Is Nothing AndAlso tblCurrency.Rows.Count > 0 Then
                intCount = CInt(tblCurrency.Rows.Count)
                ' Currency Data
                With ddlCurrency
                    .DataSource = tblCurrency
                    .DataTextField = "CurrencyCode"
                    .DataValueField = "CurrencyCode"
                    .DataBind()
                End With

                For inti = 0 To ddlCurrency.Items.Count - 1
                    If ddlCurrency.Items(inti).Value = "VND" AndAlso currentSelectedValue = "" Then
                        ddlCurrency.Items(inti).Selected = True
                        txtRate.Text = "1"
                    End If
                Next
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
                strScript = strScript & "vRate = Id; setTimeout(function() { document.forms[0].hidCurrency.value=vRate;" & Chr(10)
                strScript = strScript & "for (i = 0; i <=" & intCount & "; i++){" & Chr(10)
                strScript = strScript & "if (arrCurrency[i] == vRate){" & Chr(10)
                strScript = strScript & "document.forms[0].txtRate.value = arrRate[i];}}}, 100);}" & Chr(10)
                strScript = strScript & "</script>"
            End If
            Page.RegisterClientScriptBlock("ChangeRate", strScript)
            ddlCurrency.Attributes.Add("OnChange", "ChangeRate(this.options[this.options.selectedIndex].value);")

            If currentSelectedIndex > 0 Then
                ddlCurrency.SelectedIndex = currentSelectedIndex

                Page.RegisterClientScriptBlock("OnlOad", "<script language = 'javascript'> setTimeout(function(){ ChangeRate('" & currentSelectedValue & "'); }, 100);</script>")
            End If
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

        ' btnFilter_Click event
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Call FilterData()
        End Sub

        ' FilterData method
        Private Sub FilterData()
            ' Declare variables
            Dim strJS As String
            Dim strYear As String
            Dim strMonth As String
            Dim strPatronCode As String

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
            If Trim(txtPaTronCodeToFil.Text) = "" Then
                strPatronCode = ""
            Else
                strPatronCode = Trim(txtPaTronCodeToFil.Text)
            End If

            ' Get the month value from input
            strMonth = CStr(ddlMonth.SelectedValue)

            ' Get the type of display mode (seetled, unseetled or report)
            If Request("Display") = 1 Or Request("Display") = Nothing Then
                objBAccountTrans.Type = 1
                intDisplay = 1
            ElseIf Request("Display") = 2 Then
                objBAccountTrans.Type = 2
                intDisplay = 2
            ElseIf Request("Display") = 0 Then
                objBAccountTrans.Type = 0
                intDisplay = 0
            End If

            ' Transfer the properties for class B 
            objBAccountTrans.Year = CInt(strYear)
            objBAccountTrans.PatronCode = strPatronCode
            objBAccountTrans.Month = CInt(strMonth)
            objBAccountTrans.LibID = clsSession.GlbSite
            tblAccount = objBAccountTrans.GetAccountInfor ' Get the data
            ' Display the sum of seetled, unseetled and remain amount
            If Not tblAccount Is Nothing Then
                lblUnSettledAmount.Text = objBAccountTrans.UnSettled.ToString("N1", CultureInfo.InvariantCulture).Replace(".0", "")
                lblSettledAmount.Text = objBAccountTrans.Settled.ToString("N1", CultureInfo.InvariantCulture).Replace(".0", "")
                If objBAccountTrans.Remain * (-1) < 0 Then
                    lblRemainAmount.Text = "-" & objBAccountTrans.Remain.ToString("N1", CultureInfo.InvariantCulture).Replace(".0", "")
                Else
                    lblRemainAmount.Text = (objBAccountTrans.Remain * (-1)).ToString("N1", CultureInfo.InvariantCulture).Replace(".0", "")
                End If
                Select Case intDisplay
                    Case 1
                        If tblAccount.Rows.Count > 0 Then
                            lblSumary.Text = objBAccountTrans.Settled.ToString("N1", CultureInfo.InvariantCulture).Replace(".0", "") & " VND"
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                    Case 2
                        If tblAccount.Rows.Count > 0 Then
                            lblSumary.Text = objBAccountTrans.UnSettled.ToString("N1", CultureInfo.InvariantCulture).Replace(".0", "") & " VND"
                            TRSumary.Visible = True
                        Else
                            TRSumary.Visible = False
                        End If
                End Select
            Else
                lblUnSettledAmount.Text = "0.00"
                lblSettledAmount.Text = "0.00"
                lblRemainAmount.Text = "0.00"
                TRSumary.Visible = False
            End If

            ' Display the result (For each display mode)
            If intDisplay = 1 Or intDisplay = 2 Then
                If Not tblAccount Is Nothing AndAlso tblAccount.Rows.Count > 0 Then
                    dgtResult.Visible = True
                    dgtResult.DataSource = tblAccount
                    dgtResult.DataBind()
                Else
                    dgtResult.Visible = False
                    'Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(32).Text.Trim & "');</script>")
                End If
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
            Dim strReason As String = ""
            Dim strAmount As String = ""
            Dim strCurrency As String = ""
            Dim strRate As String = ""
            Dim strSRate As String = ""
            Dim strSubtract As String = ""
            Dim strTotal As String = ""
            Dim strSum1 As String = 0
            Dim strSum2 As String = 0
            Dim dblRealTotal As Double = 0
            Dim dblSubtractTotal1 As Double = 0
            Dim dblSubtractTotal2 As Double = 0
            Dim dblRemain As Double = 0

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
                                tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(3).Text))
                                tblCell.HorizontalAlign = HorizontalAlign.Center
                                tblRow.Cells.Add(tblCell)
                                tblRow.CssClass = "lbGridPager"
                            Case 1
                                For intj = 0 To 4
                                    tblCell = New TableCell
                                    Select Case intj
                                        Case 0
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text))
                                        Case 1
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(5).Text))
                                        Case 2
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(6).Text))
                                        Case 3
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(7).Text))
                                        Case 4
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(8).Text))
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
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(9).Text))
                                        Case 1, 5
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(10).Text))
                                        Case 2, 6
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(11).Text))
                                        Case 3, 7
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(12).Text))
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
                        ' Reason
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("Reason")) Then
                            strReason = Trim(CStr(tblAccount.Rows(intIndex).Item("Reason")))
                        Else
                            strReason = ""
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
                        ' Subtract with 2 other rates
                        If Not IsDBNull(tblAccount.Rows(intIndex).Item("SRate")) And Not IsDBNull(tblAccount.Rows(intIndex).Item("Amount")) And Not IsDBNull(tblAccount.Rows(intIndex).Item("Total")) Then
                            If CDbl(strAmount) < 0 Then
                                dblRealTotal = CDbl(strSRate) * CDbl(strAmount) * (-1)
                            Else
                                dblRealTotal = CDbl(strSRate) * CDbl(strAmount)
                            End If

                            If CDbl(strTotal) < 0 Then
                                strSubtract = CStr(CDbl(strTotal) * (-1) - dblRealTotal)
                                dblSubtractTotal2 = dblSubtractTotal2 + CDbl(strSubtract)
                            Else
                                strSubtract = CStr(CDbl(strTotal) - dblRealTotal)
                                dblSubtractTotal1 = dblSubtractTotal1 + CDbl(strSubtract)
                            End If
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
                                    tblCell.Controls.Add(New LiteralControl(strReason))
                                Case 2  ' Amount (Seetled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    If CDbl(strAmount) >= 0 Then
                                        tblCell.Controls.Add(New LiteralControl(CStr(CDbl(strAmount))))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 3  ' Currency Code (Settled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(5%)
                                    If CDbl(strAmount) >= 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strCurrency))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 4  ' transaction Rate (seetled)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(5%)
                                    If CDbl(strAmount) >= 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strRate))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 5  ' Subtract with 2 amount (current rate and transaction rate - settled)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(8%)
                                    If CDbl(strAmount) >= 0 Then
                                        If CDbl(strSubtract) < 0 Then
                                            tblCell.Controls.Add(New LiteralControl("-" & CStr(CDbl(strSubtract) * (-1))))
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(strSubtract))
                                        End If
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 6  ' Amount (UnSeetled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    If CDbl(strAmount) < 0 Then
                                        tblCell.Controls.Add(New LiteralControl(CStr(CDbl(strAmount) * (-1))))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 7  ' Currency Code (UnSeetled)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    If CDbl(strAmount) < 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strCurrency))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 8  ' Transaction rate (UnSeetled)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(5%)
                                    If CDbl(strAmount) < 0 Then
                                        tblCell.Controls.Add(New LiteralControl(strRate))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 9 ' Subtract with 2 amount (current rate and transaction rate - UnSeetled)
                                    tblCell = New TableCell
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Width = Unit.Percentage(8%)
                                    If CDbl(strAmount) < 0 Then
                                        If CDbl(strSubtract) < 0 Then
                                            tblCell.Controls.Add(New LiteralControl("-" & CStr(CDbl(strSubtract) * (-1))))
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(strSubtract))
                                        End If
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
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(13).Text))
                                        Case 1  ' Sum of seetled fees
                                            tblCell = New TableCell
                                            tblCell.ColumnSpan = 3
                                            tblCell.HorizontalAlign = HorizontalAlign.Left
                                            tblCell.CssClass = "lbAmount"
                                            strSum1 = Trim(CStr(objBAccountTrans.Settled))
                                            If CDbl(strSum1) <> "0" Then
                                                tblCell.Controls.Add(New LiteralControl(strSum1))
                                            Else
                                                tblCell.Controls.Add(New LiteralControl("0.00"))
                                            End If
                                        Case 2  ' Sum of subtract (seetled)
                                            tblCell = New TableCell
                                            tblCell.HorizontalAlign = HorizontalAlign.Right
                                            If dblSubtractTotal1 <> 0 Then
                                                If dblSubtractTotal1 < 0 Then
                                                    tblCell.Controls.Add(New LiteralControl("-" & CStr(dblSubtractTotal1 * (-1))))
                                                Else
                                                    tblCell.Controls.Add(New LiteralControl(CStr(dblSubtractTotal1)))
                                                End If
                                            Else
                                                tblCell.Controls.Add(New LiteralControl("0.00"))
                                            End If
                                        Case 3  ' Sum of Unseetled fees
                                            tblCell = New TableCell
                                            tblCell.ColumnSpan = 3
                                            tblCell.HorizontalAlign = HorizontalAlign.Left
                                            tblCell.CssClass = "lbAmount"
                                            strSum2 = Trim(CStr(objBAccountTrans.UnSettled))
                                            If CDbl(strSum2) <> "0" Then
                                                tblCell.Controls.Add(New LiteralControl(strSum2))
                                            Else
                                                tblCell.Controls.Add(New LiteralControl("0.00"))
                                            End If
                                        Case 4  ' Sum of subtract (Unseetled)
                                            tblCell = New TableCell
                                            tblCell.HorizontalAlign = HorizontalAlign.Right
                                            If dblSubtractTotal2 <> 0 Then
                                                If dblSubtractTotal2 < 0 Then
                                                    tblCell.Controls.Add(New LiteralControl("-" & CStr(dblSubtractTotal2 * (-1))))
                                                Else
                                                    tblCell.Controls.Add(New LiteralControl(CStr(dblSubtractTotal2)))
                                                End If
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
                                dblRemain = objBAccountTrans.Remain

                                If dblRemain <> 0 Then
                                    If dblRemain < 0 Then
                                        tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(14).Text & ": " & "-" & CStr(dblRemain * (-1)) & " "))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(14).Text & ": " & CStr(dblRemain) & ""))
                                    End If
                                Else
                                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(14).Text & ": 0.00 VND"))
                                End If
                                tblRow.CssClass = "lbGridPager"
                                tblRow.Cells.Add(tblCell)
                        End Select
                        tblReport.Rows.Add(tblRow)
                    Next
                End If
            End If
        End Sub

        ' btnAction_Click event
        ' Purpose: Insert new settled or unsettled fee
        Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
            Dim intOutPut As Int16 = 2
            Dim strLog As String
            Dim intCheckPatronDept As Integer = 1

            If chkPatronDept.Checked = False Then
                intCheckPatronDept = 0
            End If
            objBAccountTrans.PatronCode = Trim(txtPatronCode.Text)
            objBAccountTrans.Currency = ddlCurrency.SelectedValue
            objBAccountTrans.Rate = CDbl(Trim(txtRate.Text))
            objBAccountTrans.CreatedDate = Trim(txtDate.Text)
            objBAccountTrans.LibID = clsSession.GlbSite
            If txtReason.Text <> "" Then
                objBAccountTrans.Reason = Trim(txtReason.Text)
            Else
                objBAccountTrans.Reason = ""
            End If

            objBAccountTrans.Amount = CDbl(Trim(txtAmount.Text))
            Select Case Request("Display")
                Case 1, Nothing
                    objBAccountTrans.Type = 1
                    strLog = lblSettledTitle.Text & ": "
                Case 2
                    objBAccountTrans.Type = 2
                    strLog = lblUnSettledTitle.Text & ": "
            End Select

            objBAccountTrans.CreateNewFine(intCheckPatronDept)
            intOutPut = objBAccountTrans.OutPut

            If intOutPut = 1 Then
                Page.RegisterClientScriptBlock("NotExistPatron", "<script language='javascript'>alert('" & ddlLabel.Items(21).Text & "')</script>")
            ElseIf intOutPut = 0 Then
                ' Get the string log
                strLog = strLog & lblPatronCode.Text & " " & Trim(txtPatronCode.Text) _
                    & ", " & lblAmount.Text & " " & Trim(txtAmount.Text) _
                    & ", " & lblRate.Text & " " & Trim(txtRate.Text) _
                    & ", " & lblDate.Text & " " & Trim(txtDate.Text)
                If txtReason.Text <> "" Then
                    strLog = strLog & ", " & lblReason.Text & " " & Trim(txtReason.Text)
                End If

                Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('" & ddlLabel.Items(22).Text & "')</script>")
                ' Write log
                WriteLog(111, strLog, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            Else
                Page.RegisterClientScriptBlock("Fail", "<script language='javascript'>alert('" & ddlLabel.Items(23).Text & "')</script>")
            End If
            FilterData()
        End Sub

        ' Edit event of DataGrid
        'Private Sub dgtResult_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.EditCommand
        '    Dim ddlCurrencyDisplay As New DropDownList
        '    Dim intIndex As Integer
        '    Dim intCount As Integer
        '    Dim inti As Integer
        '    Dim intj As Integer
        '    Dim strCurrency As String
        '    Dim strScript As String
        '    Dim tblCurrency As DataTable

        '    intIndex = CInt(e.Item.ItemIndex)
        '    intIndexShare = intIndex

        '    dgtResult.EditItemIndex = intIndex

        '    Call FilterData()
        '    ' Load all Controls to DataGrid
        '    ddlCurrencyDisplay = CType(dgtResult.Items(intIndex).Cells(4).FindControl("ddlCurrencyDisplay"), DropDownList)
        '    strCurrency = CType(dgtResult.Items(intIndex).Cells(4).FindControl("txtCurrencyHid"), TextBox).Text
        '    CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(0).FindControl("txtCreatedDate"), TextBox).Attributes.Add("OnChange", "javascript:if (!CheckDate(this,'dd/mm/yyyy','" & ddlLabel.Items(19).Text & "'))return false;")
        '    CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(3).FindControl("txtAmountDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(17).Text & "','" & ddlLabel.Items(15).Text & "')) {this.focus();this.value='';return false;}")
        '    CType(dgtResult.Items(dgtResult.EditItemIndex).Cells(5).FindControl("txtRateDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(17).Text & "','" & ddlLabel.Items(16).Text & "')) {this.focus();this.value='';return false;}")

        '    Page.RegisterClientScriptBlock("ChangeRate", strScript)
        '    ddlCurrency.Attributes.Add("OnChange", "ChangeRate(this.options[this.options.selectedIndex].value);")

        '    objBCommonBusiness.CurrencyCode = ""
        '    tblCurrency = objBCommonBusiness.GetCurrency
        '    If Not tblCurrency Is Nothing AndAlso tblCurrency.Rows.Count > 0 Then
        '        ddlCurrencyDisplay.DataSource = tblCurrency
        '        ddlCurrencyDisplay.DataTextField = "CurrencyCode"
        '        ddlCurrencyDisplay.DataValueField = "CurrencyCode"
        '        ddlCurrencyDisplay.DataBind()
        '        intCount = CInt(tblCurrency.Rows.Count)
        '    End If
        '    If intCount > 0 Then
        '        strScript = "<script Language='JavaScript'>"
        '        strScript = strScript & "arrCurrency = new Array(" & intCount & ");" & Chr(10)
        '        strScript = strScript & "arrRate = new Array(" & intCount & ");" & Chr(10)
        '        For intj = 0 To intCount - 1
        '            strScript = strScript & "arrCurrency[" & intj & "]='" & tblCurrency.Rows(intj).Item("CurrencyCode") & "';" & Chr(10)
        '            strScript = strScript & "arrRate[" & intj & "]=" & tblCurrency.Rows(intj).Item("Rate") & ";" & Chr(10)
        '        Next
        '        strScript = strScript & "function ChangeRateValue(Id) {" & Chr(10)
        '        strScript = strScript & "vRate = Id; console.log(1);" & Chr(10)
        '        strScript = strScript & "for (i = 0; i <=" & intCount & "; i++){" & Chr(10)
        '        strScript = strScript & "if (arrCurrency[i] == vRate){" & Chr(10)
        '        strScript = strScript & "eval('document.Form2.dgtResult__ctl" & intIndex + 3 & "_txtRateDisplay').value = arrRate[i];}}}" & Chr(10)
        '        strScript = strScript & "</script>"
        '        Page.RegisterClientScriptBlock("ChangeRateValue", strScript)
        '        ddlCurrencyDisplay.Attributes.Add("OnChange", "ChangeRateValue(this.options[this.options.selectedIndex].value," & intIndex + 3 & ");")
        '    End If

        '    For inti = 0 To ddlCurrencyDisplay.Items.Count - 1
        '        If CStr(ddlCurrencyDisplay.Items(inti).Value) = strCurrency Then
        '            ddlCurrencyDisplay.Items(inti).Selected = True
        '        Else
        '            ddlCurrencyDisplay.Items(inti).Selected = False
        '        End If
        '    Next
        'End Sub

        ' Cancel event of DataGrid
        'Private Sub dgtResult_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.CancelCommand
        '    dgtResult.EditItemIndex = -1
        '    Call FilterData()
        'End Sub

        ' Update event of DataGrid
        ' Purpose: Update selected Fine
        'Private Sub dgtResult_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.UpdateCommand
        '    ' Declare variables
        '    Dim intID As Integer
        '    Dim intIndex As Integer
        '    Dim blnValid As Boolean
        '    Dim strCreatedDate As String
        '    Dim strPatronCode As String
        '    Dim strReason As String
        '    Dim strAmount As String
        '    Dim strCurrency As String
        '    Dim dblAmount As Double = 0
        '    Dim dblRate As Double = 0
        '    Dim strRate As String
        '    Dim intOutPut As Int16 = 2

        '    ' Get data to Update
        '    intIndex = e.Item.ItemIndex
        '    intID = CInt(Trim(CType(dgtResult.Items(intIndex).Cells(9).FindControl("lblID"), Label).Text))
        '    strCreatedDate = Trim(CType(dgtResult.Items(intIndex).Cells(0).FindControl("txtCreatedDate"), TextBox).Text)
        '    strPatronCode = Trim(CType(dgtResult.Items(intIndex).Cells(1).FindControl("txtPatronCodeDisplay"), TextBox).Text)

        '    If CType(dgtResult.Items(intIndex).Cells(2).FindControl("txtReasonDisplay"), TextBox).Text <> "" Then
        '        strReason = Trim(CType(dgtResult.Items(intIndex).Cells(2).FindControl("txtReasonDisplay"), TextBox).Text)
        '    Else
        '        strReason = ""
        '    End If

        '    strAmount = Trim(CType(dgtResult.Items(intIndex).Cells(3).FindControl("txtAmountDisplay"), TextBox).Text)
        '    strRate = Trim(CType(dgtResult.Items(intIndex).Cells(5).FindControl("txtRateDisplay"), TextBox).Text)

        '    If CType(dgtResult.Items(intIndex).Cells(4).FindControl("ddlCurrencyDisplay"), DropDownList).SelectedValue <> "" Then
        '        strCurrency = CStr(CType(dgtResult.Items(intIndex).Cells(4).FindControl("ddlCurrencyDisplay"), DropDownList).SelectedValue)
        '    Else
        '        strCurrency = ""
        '    End If

        '    objBRateMan.CurrencyCode = strCurrency
        '    Dim currentcyResult = objBRateMan.GetRate()
        '    If Not currentcyResult Is Nothing Then
        '        strRate = currentcyResult.Rows(0).Item("Rate").ToString()
        '    End If
        '    If strCreatedDate = "" Or strPatronCode = "" Or strAmount = "" Or strCurrency = "" Or strRate = "" Then
        '        blnValid = False
        '    Else
        '        blnValid = True
        '    End If

        '    ' Not null values
        '    If blnValid = True Then
        '        dblAmount = CDbl(strAmount)
        '        dblRate = CDbl(strRate)
        '        ' Transfer the property
        '        objBAccountTrans.FineID = intID
        '        objBAccountTrans.PatronCode = strPatronCode
        '        objBAccountTrans.Currency = strCurrency
        '        objBAccountTrans.Rate = dblRate
        '        objBAccountTrans.CreatedDate = strCreatedDate
        '        objBAccountTrans.Reason = strReason
        '        objBAccountTrans.Amount = dblAmount
        '        Select Case Request("Display")
        '            Case 1, Nothing
        '                objBAccountTrans.Type = 1
        '            Case 2
        '                objBAccountTrans.Type = 2
        '        End Select
        '        ' Update
        '        objBAccountTrans.UpdateFine()
        '        intOutPut = objBAccountTrans.OutPut

        '        ' patron is not exist
        '        If intOutPut = 1 Then
        '            Page.RegisterClientScriptBlock("NotExistPatron", "<script language='javascript'>alert('" & ddlLabel.Items(21).Text & "')</script>")
        '            BindDinamicScript()
        '        ElseIf intOutPut = 0 Then   ' Success
        '            Dim strLog As String

        '            Select Case Request("Display")
        '                Case 1, Nothing
        '                    strLog = ddlLabel.Items(28).Text & ": "
        '                Case 2
        '                    strLog = ddlLabel.Items(28).Text & ": "
        '            End Select

        '            ' Get the string log
        '            strLog = strLog & lblPatronCode.Text & " " & Trim(strPatronCode) _
        '                & ", " & lblAmount.Text & " " & Trim(strAmount) _
        '                & ", " & lblRate.Text & " " & Trim(strRate) _
        '                & ", " & lblDate.Text & " " & Trim(strCreatedDate)
        '            If strReason <> "" Then
        '                strLog = strLog & ", " & lblReason.Text & " " & Trim(strReason)
        '            End If
        '            Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('" & ddlLabel.Items(24).Text & "')</script>")
        '            dgtResult.EditItemIndex = -1
        '            FilterData()
        '        Else    ' Fail
        '            Page.RegisterClientScriptBlock("Fail", "<script language='javascript'>alert('" & ddlLabel.Items(25).Text & "')</script>")
        '            dgtResult.EditItemIndex = -1
        '            FilterData()
        '        End If
        '    Else    ' Null values
        '        Page.RegisterClientScriptBlock("NullValue", "<script language='javascript'>alert('" & ddlLabel.Items(20).Text & "')</script>")
        '        BindDinamicScript()
        '    End If
        'End Sub

        ' BindDinamicScript method
        Private Sub BindDinamicScript()
            ' Declare variables
            Dim ddlCurrencyDisplay As New DropDownList
            Dim intCount As Integer = 0
            Dim inti As Integer
            Dim intj As Integer
            Dim strCurrency As String
            Dim strScript As String
            Dim tblCurrency As DataTable

            objBCommonBusiness.CurrencyCode = ""
            tblCurrency = objBCommonBusiness.GetCurrency
            If Not tblCurrency Is Nothing Then
                intCount = CInt(tblCurrency.Rows.Count)
            End If

            ddlCurrencyDisplay = CType(dgtResult.Items(intIndexShare).FindControl("ddlCurrencyDisplay"), DropDownList)
            strCurrency = CType(dgtResult.Items(intIndexShare).FindControl("txtCurrencyHid"), TextBox).Text

            If intCount > 0 Then
                strScript = "<script Language='JavaScript'>"
                strScript = strScript & "arrCurrency = new Array(" & intCount & ");" & Chr(10)
                strScript = strScript & "arrRate = new Array(" & intCount & ");" & Chr(10)
                For intj = 0 To intCount - 1
                    strScript = strScript & "arrCurrency[" & intj & "]='" & tblCurrency.Rows(intj).Item("CurrencyCode") & "';" & Chr(10)
                    strScript = strScript & "arrRate[" & intj & "]=" & tblCurrency.Rows(intj).Item("Rate") & ";" & Chr(10)
                Next
                strScript = strScript & "function ChangeRateValue(Id) {" & Chr(10)
                strScript = strScript & "vRate = Id;" & Chr(10)
                strScript = strScript & "for (i = 0; i <=" & intCount & "; i++){" & Chr(10)
                strScript = strScript & "if (arrCurrency[i] == vRate){" & Chr(10)
                strScript = strScript & "eval('document.forms[0].dgtResult__ctl" & intIndexShare + 2 & "_txtRateDisplay').value = arrRate[i];}}}" & Chr(10)
                strScript = strScript & "</script>"
                Page.RegisterClientScriptBlock("ChangeRateValue", strScript)
                ddlCurrencyDisplay.Attributes.Add("OnChange", "ChangeRateValue(this.options[this.options.selectedIndex].value," & intIndexShare + 2 & ");")
                ' Page.RegisterClientScriptBlock("OnlOad", "<script language = 'javascript'> setTimeout(function(){ ChangeRateValue('" & currentSelectedValue & "'); }, 100);</script>")
            End If

            For inti = 0 To ddlCurrencyDisplay.Items.Count - 1
                If CStr(ddlCurrencyDisplay.Items(inti).Value) = strCurrency Then
                    ddlCurrencyDisplay.Items(inti).Selected = True
                Else
                    ddlCurrencyDisplay.Items(inti).Selected = False
                End If
            Next
        End Sub

        ' Delete event of DataGrid
        'Private Sub dgtResult_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgtResult.DeleteCommand
        '    ' Declare variables
        '    Dim intIndex As Integer
        '    Dim intID As Integer

        '    ' Get data to Delete
        '    intIndex = e.Item.ItemIndex

        '    intID = Trim(CInt(CType(dgtResult.Items(intIndex).Cells(9).FindControl("lblID"), Label).Text))
        '    objBAccountTrans.FineID = intID
        '    objBAccountTrans.DeleteFine()
        '    ' Write log
        '    If Request("Display") = 1 Or Request("Display") = Nothing Then
        '        WriteLog(111, ddlLabel.Items(30).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
        '    ElseIf Request("Display") = 2 Then
        '        WriteLog(111, ddlLabel.Items(30).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
        '    End If
        '    Page.RegisterClientScriptBlock("Fail", "<script language='javascript'>alert('Xóa khoản thu thành công')</script>")
        '    FilterData()
        'End Sub

        ' txtPaTronCode_TextChanged event
        Private Sub txtPatronCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPatronCode.TextChanged
            txtPaTronCodeToFil.Text = Trim(txtPatronCode.Text)
            FilterData()
            If objBAccountTrans.Remain < 0 And Trim(txtPaTronCodeToFil.Text) <> "" Then
                txtAmount.Text = CStr(objBAccountTrans.Remain * (-1))
            Else
                txtAmount.Text = "0"
            End If
        End Sub

        'dgtResult_ItemCreated event
        'Private Sub dgtResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgtResult.ItemCreated
        '    Select Case e.Item.ItemType
        '        Case ListItemType.AlternatingItem, ListItemType.EditItem, ListItemType.Item, ListItemType.Separator
        '            Dim lnkdtgTemp As LinkButton

        '            lnkdtgTemp = e.Item.FindControl("lnkdtgUpdate")

        '            If Not lnkdtgTemp Is Nothing Then
        '                lnkdtgTemp.Attributes.Add("onclick", "javascript:return(CheckInsertUpdate('document.forms[0].dgtResult__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabel.Items(20).Text & "','" & ddlLabel.Items(17).Text & "','" & ddlLabel.Items(15).Text & "'));")
        '            End If

        '            lnkdtgTemp = e.Item.FindControl("lnkdtgDelete")
        '            Select Case Request("Display")
        '                Case 1, Nothing
        '                    lnkdtgTemp.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(26).Text & "')==false) {return false}")
        '                Case 2
        '                    lnkdtgTemp.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(27).Text & "')==false) {return false}")
        '            End Select
        '    End Select
        'End Sub

        ' fCurrency method
        Public Function fCurrency(ByVal strfCurrency) As String
            Dim strfCurrency2 As String
            Dim strSubCurrency As String
            Dim blnMinusNum As Boolean
            Dim intDecimalpoint As Integer


            strfCurrency2 = ""
            If Trim(strfCurrency) = "" Or Not IsNumeric(strfCurrency) Then
                fCurrency = strfCurrency
            Else
                blnMinusNum = False
                If CDbl(strfCurrency) < 0 Then
                    blnMinusNum = True
                    strfCurrency = -1 * CDbl(strfCurrency)
                End If
                intDecimalpoint = InStr(strfCurrency, ".")
                If intDecimalpoint > 0 Then
                    strfCurrency2 = Right(strfCurrency, Len(strfCurrency) - intDecimalpoint + 1)
                    strfCurrency = Left(strfCurrency, intDecimalpoint - 1)
                Else
                    strfCurrency2 = ".00"
                End If
                While Len(strfCurrency) > 3
                    strfCurrency2 = "," & Right(strfCurrency, 3) & strfCurrency2
                    strfCurrency = Left(strfCurrency, Len(strfCurrency) - 3)
                End While
                strfCurrency2 = strfCurrency & strfCurrency2
                If blnMinusNum Then
                    fCurrency = "-" & strfCurrency2
                Else
                    fCurrency = strfCurrency2
                End If
            End If
        End Function

        ' Page_Unload event
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
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Protected Sub dgtResult_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs) Handles dgtResult.PageIndexChanged

        '    dgtResult.CurrentPageIndex = e.NewPageIndex
        '    Call BindData()

        'End Sub

        'Protected Sub dgtResult_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgtResult.ItemDataBound

        '    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        '        'If the first column is a date
        '        Dim lblTemp As Label = e.Item.FindControl("lblTotal")
        '        lblTemp.Text = formatCurrency(lblTemp.Text)
        '        Dim lblAmountDisplay As Label = e.Item.FindControl("lblAmountDisplay")
        '        lblAmountDisplay.Text = formatCurrency(lblAmountDisplay.Text)
        '    End If
        'End Sub

        Public Function formatCurrency(ByVal str As String) As String
            Return Double.Parse(str).ToString("N0", CultureInfo.InvariantCulture)
        End Function

        Protected Sub dgtResult_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dgtResult.NeedDataSource
            Call BindData()

        End Sub

        Protected Sub dgtResult_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles dgtResult.ItemDataBound
            'If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            '    'If the first column is a date
            '    Dim lblTemp As Label = e.Item.FindControl("lblTotal")
            '    lblTemp.Text = formatCurrency(lblTemp.Text)
            '    Dim lblAmountDisplay As Label = e.Item.FindControl("lblAmountDisplay")
            '    lblAmountDisplay.Text = formatCurrency(lblAmountDisplay.Text)
            'End If


            If (TypeOf e.Item Is GridDataItem) AndAlso (e.Item.OwnerTableView.Name = "Master") Then
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
                Dim lblTemp As Label = item.FindControl("lblTotal")
                lblTemp.Text = formatCurrency(lblTemp.Text)
                Dim lblAmountDisplay As Label = e.Item.FindControl("lblAmountDisplay")
                lblAmountDisplay.Text = formatCurrency(lblAmountDisplay.Text)

                Dim lnkdtgTemp As LinkButton

                lnkdtgTemp = e.Item.FindControl("lnkdtgUpdate")

                If Not lnkdtgTemp Is Nothing Then
                    lnkdtgTemp.Attributes.Add("onclick", "javascript:return(CheckInsertUpdate('document.forms[0].dgtResult__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabel.Items(20).Text & "','" & ddlLabel.Items(17).Text & "','" & ddlLabel.Items(15).Text & "'));")
                End If

                lnkdtgTemp = e.Item.FindControl("lnkdtgDelete")
                    Select Request("Display")
                    Case 1, Nothing
                        lnkdtgTemp.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(26).Text & "')==false) {return false}")
                    Case 2
                        lnkdtgTemp.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(27).Text & "')==false) {return false}")
                End Select
            End If


            If e.Item.IsInEditMode Then
                Dim editItem As GridEditableItem = DirectCast(e.Item, GridEditableItem)
                Dim ddlCurrencyDisplay As New DropDownList
                Dim intIndex As Integer
                Dim intCount As Integer
                Dim inti As Integer
                Dim intj As Integer
                Dim strCurrency As String
                Dim strScript As String
                Dim tblCurrency As DataTable

                

              
                ' Call FilterData()
                ' Load all Controls to DataGrid
                ddlCurrencyDisplay = CType(editItem.FindControl("ddlCurrencyDisplay"), DropDownList)
                strCurrency = CType(editItem.FindControl("txtCurrencyHid"), TextBox).Text
                CType(editItem.FindControl("txtCreatedDate"), TextBox).Attributes.Add("OnChange", "javascript:if (!CheckDate(this,'dd/mm/yyyy','" & ddlLabel.Items(19).Text & "'))return false;")
                CType(editItem.FindControl("txtAmountDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(17).Text & "','" & ddlLabel.Items(15).Text & "')) {this.focus();this.value='';return false;}")
                CType(editItem.FindControl("txtRateDisplay"), TextBox).Attributes.Add("OnChange", "javascript:if(!CheckValidNumber(this,'" & ddlLabel.Items(17).Text & "','" & ddlLabel.Items(16).Text & "')) {this.focus();this.value='';return false;}")

                Page.RegisterClientScriptBlock("ChangeRate", strScript)
                ddlCurrency.Attributes.Add("OnChange", "ChangeRate(this.options[this.options.selectedIndex].value);")

                objBCommonBusiness.CurrencyCode = ""
                tblCurrency = objBCommonBusiness.GetCurrency
                If Not tblCurrency Is Nothing AndAlso tblCurrency.Rows.Count > 0 Then
                    ddlCurrencyDisplay.DataSource = tblCurrency
                    ddlCurrencyDisplay.DataTextField = "CurrencyCode"
                    ddlCurrencyDisplay.DataValueField = "CurrencyCode"
                    ddlCurrencyDisplay.DataBind()
                    intCount = CInt(tblCurrency.Rows.Count)
                End If
                If intCount > 0 Then
                    strScript = "<script Language='JavaScript'>"
                    strScript = strScript & "arrCurrency = new Array(" & intCount & ");" & Chr(10)
                    strScript = strScript & "arrRate = new Array(" & intCount & ");" & Chr(10)
                    For intj = 0 To intCount - 1
                        strScript = strScript & "arrCurrency[" & intj & "]='" & tblCurrency.Rows(intj).Item("CurrencyCode") & "';" & Chr(10)
                        strScript = strScript & "arrRate[" & intj & "]=" & tblCurrency.Rows(intj).Item("Rate") & ";" & Chr(10)
                    Next
                    strScript = strScript & "function ChangeRateValue(Id) {" & Chr(10)
                    strScript = strScript & "vRate = Id; console.log(1);" & Chr(10)
                    strScript = strScript & "for (i = 0; i <=" & intCount & "; i++){" & Chr(10)
                    strScript = strScript & "if (arrCurrency[i] == vRate){" & Chr(10)
                    strScript = strScript & "eval('document.Form2.dgtResult__ctl" & intIndex + 3 & "_txtRateDisplay').value = arrRate[i];}}}" & Chr(10)
                    strScript = strScript & "</script>"
                    Page.RegisterClientScriptBlock("ChangeRateValue", strScript)
                    ddlCurrencyDisplay.Attributes.Add("OnChange", "ChangeRateValue(this.options[this.options.selectedIndex].value," & intIndex + 3 & ");")
                End If

                For inti = 0 To ddlCurrencyDisplay.Items.Count - 1
                    If CStr(ddlCurrencyDisplay.Items(inti).Value) = strCurrency Then
                        ddlCurrencyDisplay.Items(inti).Selected = True
                    Else
                        ddlCurrencyDisplay.Items(inti).Selected = False
                    End If
                Next
            End If
        End Sub

        Protected Sub dgtResult_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dgtResult.ItemCreated
            Select Case e.Item.ItemType
                Case GridItemType.Item, GridItemType.AlternatingItem, GridItemType.EditItem
                    'Dim lnkdtgTemp As LinkButton

                    'lnkdtgTemp = e.Item.FindControl("lnkdtgUpdate")

                    'If Not lnkdtgTemp Is Nothing Then
                    '    lnkdtgTemp.Attributes.Add("onclick", "javascript:return(CheckInsertUpdate('document.forms[0].dgtResult__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabel.Items(20).Text & "','" & ddlLabel.Items(17).Text & "','" & ddlLabel.Items(15).Text & "'));")
                    'End If

                    'lnkdtgTemp = e.Item.FindControl("lnkdtgDelete")
                    'Select Case Request("Display")
                    '    Case 1, Nothing
                    '        lnkdtgTemp.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(26).Text & "')==false) {return false}")
                    '    Case 2
                    '        lnkdtgTemp.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(27).Text & "')==false) {return false}")
                    ' End Select
            End Select
        End Sub

        Protected Sub dgtResult_EditCommand(sender As Object, e As GridCommandEventArgs) Handles dgtResult.EditCommand

        End Sub

        Protected Sub dgtResult_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dgtResult.DeleteCommand
            ' Declare variables
            Dim intIndex As Integer
            Dim intID As Integer

            ' Get data to Delete
            intIndex = e.Item.ItemIndex

            intID = Trim(CInt(CType(dgtResult.Items(intIndex).FindControl("lblID"), Label).Text))
            objBAccountTrans.FineID = intID
            objBAccountTrans.DeleteFine()
            ' Write log
            If Request("Display") = 1 Or Request("Display") = Nothing Then
                WriteLog(111, ddlLabel.Items(30).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            ElseIf Request("Display") = 2 Then
                WriteLog(111, ddlLabel.Items(30).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            End If
            Page.RegisterClientScriptBlock("Fail", "<script language='javascript'>alert('Xóa khoản thu thành công')</script>")
            FilterData()
        End Sub

        Protected Sub dgtResult_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dgtResult.UpdateCommand
            ' Declare variables
            Dim intID As Integer
            Dim intIndex As Integer
            Dim blnValid As Boolean
            Dim strCreatedDate As String
            Dim strPatronCode As String
            Dim strReason As String
            Dim strAmount As String
            Dim strCurrency As String
            Dim dblAmount As Double = 0
            Dim dblRate As Double = 0
            Dim strRate As String
            Dim intOutPut As Int16 = 2

            ' Get data to Update
            intIndex = e.Item.ItemIndex
            intID = CInt(Trim(CType(dgtResult.Items(intIndex).Cells(9).FindControl("lblID"), Label).Text))
            strCreatedDate = Trim(CType(dgtResult.Items(intIndex).Cells(0).FindControl("txtCreatedDate"), TextBox).Text)
            strPatronCode = Trim(CType(dgtResult.Items(intIndex).Cells(1).FindControl("txtPatronCodeDisplay"), TextBox).Text)

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

            objBRateMan.CurrencyCode = strCurrency
            Dim currentcyResult = objBRateMan.GetRate()
            If Not currentcyResult Is Nothing Then
                strRate = currentcyResult.Rows(0).Item("Rate").ToString()
            End If
            If strCreatedDate = "" Or strPatronCode = "" Or strAmount = "" Or strCurrency = "" Or strRate = "" Then
                blnValid = False
            Else
                blnValid = True
            End If

            ' Not null values
            If blnValid = True Then
                dblAmount = CDbl(strAmount)
                dblRate = CDbl(strRate)
                ' Transfer the property
                objBAccountTrans.FineID = intID
                objBAccountTrans.PatronCode = strPatronCode
                objBAccountTrans.Currency = strCurrency
                objBAccountTrans.Rate = dblRate
                objBAccountTrans.CreatedDate = strCreatedDate
                objBAccountTrans.Reason = strReason
                objBAccountTrans.Amount = dblAmount
                Select Case Request("Display")
                    Case 1, Nothing
                        objBAccountTrans.Type = 1
                    Case 2
                        objBAccountTrans.Type = 2
                End Select
                ' Update
                objBAccountTrans.UpdateFine()
                intOutPut = objBAccountTrans.OutPut

                ' patron is not exist
                If intOutPut = 1 Then
                    Page.RegisterClientScriptBlock("NotExistPatron", "<script language='javascript'>alert('" & ddlLabel.Items(21).Text & "')</script>")
                    BindDinamicScript()
                ElseIf intOutPut = 0 Then   ' Success
                    Dim strLog As String

                    Select Case Request("Display")
                        Case 1, Nothing
                            strLog = ddlLabel.Items(28).Text & ": "
                        Case 2
                            strLog = ddlLabel.Items(28).Text & ": "
                    End Select

                    ' Get the string log
                    strLog = strLog & lblPatronCode.Text & " " & Trim(strPatronCode) _
                        & ", " & lblAmount.Text & " " & Trim(strAmount) _
                        & ", " & lblRate.Text & " " & Trim(strRate) _
                        & ", " & lblDate.Text & " " & Trim(strCreatedDate)
                    If strReason <> "" Then
                        strLog = strLog & ", " & lblReason.Text & " " & Trim(strReason)
                    End If
                    Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('" & ddlLabel.Items(24).Text & "')</script>")

                    FilterData()
                Else    ' Fail
                    Page.RegisterClientScriptBlock("Fail", "<script language='javascript'>alert('" & ddlLabel.Items(25).Text & "')</script>")

                    FilterData()
                End If
            Else    ' Null values
                Page.RegisterClientScriptBlock("NullValue", "<script language='javascript'>alert('" & ddlLabel.Items(20).Text & "')</script>")
                BindDinamicScript()
            End If
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace