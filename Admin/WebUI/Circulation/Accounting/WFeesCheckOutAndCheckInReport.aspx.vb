Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Common
Imports System.Globalization


Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WFeesCheckOutAndCheckInReport
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

        Private objBAccountTrans As New clsBAccountTransaction
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                txtFromDate.Text = Session("ToDay")
                txtToDate.Text = Session("ToDay")
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBAccountTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccountTrans.DBServer = Session("DBServer")
            objBAccountTrans.ConnectionString = Session("ConnectionString")
            objBAccountTrans.Initialize()

            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()

        End Sub
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJS", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language='javascript' src='js/WStatCreatedDate.js'></script>")

            'optEachYearExpired.Attributes.Add("OnClick", "document.forms[0].txtYear.focus();")
            'txtYear.Attributes.Add("OnChange", "if (!CheckYear(this, '" & ddlLabel.Items(3).Text & "')){this.focus();this.value=0;};")
            'txtYear.Attributes.Add("OnClick", "document.forms[0].optEachYearExpired.checked=true;")

            btnStatistic.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(6).Text & "'));")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkToDate, txtToDate, ddlLabel.Items(5).Text)

        End Sub
        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim strFromDate As String = ""
            Dim strToDate As String = ""
            Dim tblAccount As DataTable
            Dim strSQL As String
            Dim intSumaryFees, intSumaryOverdueFine, intSumaryLoanDepositFee, intRealCollection As Double
            strFromDate = txtFromDate.Text.ToString()
            strToDate = txtToDate.Text.ToString()
            strSQL = "Select  ROW_NUMBER() Over(order by Cir_tblLoanHistory.ID) as STT, Cir_tblPatron.Code as PatronCode,CopyNumber,CheckOutDate,CheckInDate,ISNULL(Fees,0) as Fees ,ISNULL(OverdueFine,0) as OverdueFine ,ISNULL(LoanDepositFee,0) as LoanDepositFee from Cir_tblLoanHistory, Cir_tblPatron Where datediff(day,Convert(date,'" & strFromDate & "',103),CheckInDate) >= 0 and datediff(day,Convert(date,'" & strToDate & "',103),CheckInDate) <= 0 and Cir_tblLoanHistory.PatronID =  Cir_tblPatron.ID "

            objBCDBS.SQLStatement = strSQL
            tblAccount = objBCDBS.RetrieveItemInfor()

            '' SUmm
            If tblAccount IsNot Nothing AndAlso tblAccount.Rows.Count > 0 Then
                intSumaryFees = Convert.ToDouble(tblAccount.Compute("SUM(Fees)", String.Empty))
                intSumaryOverdueFine = Convert.ToDouble(tblAccount.Compute("SUM(OverdueFine)", String.Empty))
                intSumaryLoanDepositFee = Convert.ToDouble(tblAccount.Compute("SUM(LoanDepositFee)", String.Empty))

                intRealCollection = intSumaryLoanDepositFee - (intSumaryLoanDepositFee - intSumaryFees) + intSumaryOverdueFine

                lblSumaryFees.Text = String.Format("{0:###,###}", intSumaryFees)
                lblSumaryOverdueFine.Text = String.Format("{0:###,###}", intSumaryOverdueFine)
                lblSumaryLoanDepositFee.Text = String.Format("{0:###,###}", intSumaryLoanDepositFee)
                lblRealCollection.Text = String.Format("{0:###,###}", intRealCollection)

                Session("tblAccount") = tblAccount '' session to export excel
                dtgResultCurrentCheckIn.DataSource = tblAccount
                dtgResultCurrentCheckIn.DataBind()

                TRbtnExport.Visible = True
                TRSumary.Visible = True
                TRRealCollection.Visible = True
                TRNothing.Visible = False
            Else
                TRbtnExport.Visible = False
                TRSumary.Visible = False
                TRRealCollection.Visible = False
                TRNothing.Visible = True
                dtgResultCurrentCheckIn.DataSource = Nothing
                dtgResultCurrentCheckIn.DataBind()
            End If
        End Sub

        ' fCurrency method
        'Public Function fCurrency(ByVal strfCurrency) As String
        '    Dim strfCurrency2 As String
        '    Dim blnMinusNum As Boolean
        '    Dim intDecimalpoint As Integer

        '    strfCurrency2 = ""
        '    If Trim(strfCurrency) = "" Or Not IsNumeric(strfCurrency) Then
        '        fCurrency = strfCurrency
        '    Else
        '        blnMinusNum = False
        '        If CDbl(strfCurrency) < 0 Then
        '            blnMinusNum = True
        '            strfCurrency = -1 * CDbl(strfCurrency)
        '        End If
        '        intDecimalpoint = InStr(strfCurrency, ".")
        '        If intDecimalpoint > 0 Then
        '            strfCurrency2 = Right(strfCurrency, Len(strfCurrency) - intDecimalpoint + 1)
        '            strfCurrency = Left(strfCurrency, intDecimalpoint - 1)
        '        Else
        '            strfCurrency2 = ".00"
        '        End If
        '        While Len(strfCurrency) > 3
        '            strfCurrency2 = "," & Right(strfCurrency, 3) & strfCurrency2
        '            strfCurrency = Left(strfCurrency, Len(strfCurrency) - 3)
        '        End While
        '        strfCurrency2 = strfCurrency & strfCurrency2
        '        If blnMinusNum Then
        '            fCurrency = "-" & strfCurrency2
        '        Else
        '            fCurrency = strfCurrency2
        '        End If
        '    End If
        'End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBAccountTrans Is Nothing Then
                    objBAccountTrans.Dispose(True)
                    objBAccountTrans = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Public Function formatCurrency(ByVal str As String) As String
            Return Double.Parse(str).ToString("N0", CultureInfo.InvariantCulture)
        End Function
        'Protected Sub dgtResult_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dgtResult.ItemDataBound
        '    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        '        'If the first column is a date
        '        Dim lblTemp As Label = e.Item.FindControl("lblAmountDisplay")
        '        lblTemp.Text = formatCurrency(lblTemp.Text)
        '        Dim lblAmountDisplay As Label = e.Item.FindControl("lblTotal")
        '        lblAmountDisplay.Text = formatCurrency(lblAmountDisplay.Text)
        '    End If
        'End Sub
        'Protected Sub dtgResultCurrentCheckIn_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dtgResultCurrentCheckIn.ItemDataBound
        '    If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        '        'If the first column is a date
        '        Dim lblTemp As Label = e.Item.FindControl("lblAmountDisplay")
        '        lblTemp.Text = formatCurrency(lblTemp.Text)
        '        Dim lblAmountDisplay As Label = e.Item.FindControl("lblTotal")
        '        lblAmountDisplay.Text = formatCurrency(lblAmountDisplay.Text)
        '    End If
        'End Sub
        Protected Sub btnStatistic_Click(sender As Object, e As EventArgs) Handles btnStatistic.Click
            Call BindData()
        End Sub
        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim strHTMLContent As New StringBuilder()
            Dim tblData As DataTable = Session("tblAccount")
            Dim tblExport As New DataTable
            tblExport.Columns.Add("STT")
            tblExport.Columns.Add("PatronCode")
            tblExport.Columns.Add("CopyNumber")
            tblExport.Columns.Add("CheckOutDate")
            tblExport.Columns.Add("CheckInDate")
            tblExport.Columns.Add("Fees")
            tblExport.Columns.Add("OverdueFine")
            tblExport.Columns.Add("LoanDepositFee")

            For Each Row As DataRow In tblData.Rows
                Dim dtRow As DataRow = tblExport.NewRow()

                'Dim strFees = If(Row.Item("Fees").ToString, "0")
                'Dim strOverdueFine = If(Row.Item("OverdueFine"), "0")
                'Dim strLoanDepositFee = If(Row.Item("LoanDepositFee"), "0")

                dtRow.Item("STT") = Row.Item("STT")
                dtRow.Item("PatronCode") = Row.Item("PatronCode")
                dtRow.Item("CopyNumber") = Row.Item("CopyNumber")
                dtRow.Item("CheckOutDate") = Row.Item("CheckOutDate")
                dtRow.Item("CheckInDate") = Row.Item("CheckInDate")
                dtRow.Item("Fees") = String.Format("{0}", CInt(Row.Item("Fees")))
                dtRow.Item("OverdueFine") = String.Format("{0}", CInt(Row.Item("OverdueFine")))
                dtRow.Item("LoanDepositFee") = String.Format("{0}", CInt(Row.Item("LoanDepositFee")))

                tblExport.Rows.Add(dtRow)
            Next
            '' add header title
            tblExport.Rows.Add(ddlHeaderLabel.Items(0), ddlHeaderLabel.Items(1), ddlHeaderLabel.Items(2),
                                ddlHeaderLabel.Items(3), ddlHeaderLabel.Items(4), ddlHeaderLabel.Items(5),
                                ddlHeaderLabel.Items(6), ddlHeaderLabel.Items(7))

            strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblExport, "Báo cáo các khoản thu chi mượn trả sách."))
            clsExport.StringBuilderToExcel(strHTMLContent)
        End Sub

        Protected Sub dtgResultCurrentCheckIn_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs) Handles dtgResultCurrentCheckIn.PageIndexChanged
            dtgResultCurrentCheckIn.CurrentPageIndex = e.NewPageIndex
            BindData()
        End Sub
    End Class
End Namespace