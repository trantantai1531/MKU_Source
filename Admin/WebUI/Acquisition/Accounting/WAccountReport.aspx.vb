Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WAccountReport
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnUpdateRemain As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBAccounting As New clsBAccounting
        Private objBBudget As New clsBBudget
        Private tblAccount As DataTable
        Private dblStartRemain As Double
        Private dblLastBase As Double

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
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
            objBAccounting.Initialize()

            ' Init for objBBudget
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            objBBudget.Initialize()
        End Sub

        ' BindData method
        ' Purpose: Bind the account data
        Private Sub BindData()
            ' Declare variable
            Dim intMonth As Integer = 0
            Dim intYear As Integer = 0
            Dim strBudget As String = ""
            Dim intDisplay As Int16 = 1
            Dim tblBudget As DataTable

            ' Month
            If Not Request("Month") & "" = "" Then
                intMonth = Request("Month")
            End If

            ' Year
            If Not Request("Year") & "" = "" Then
                intYear = Request("Year")
            End If

            ' BudgetID
            If Not Request("BudgetID") & "" = "" Then
                objBAccounting.BudgetID = CInt(Request("BudgetID"))
                objBBudget.BudID = CInt(Request("BudgetID"))
                tblBudget = objBBudget.GetBudget
                If Not tblBudget Is Nothing Then
                    If tblBudget.Rows.Count > 0 Then
                        strBudget = tblBudget.Rows(0).Item("BudgetName")
                    End If
                End If
            End If

            ' Get the SubTitle
            If Not strBudget = "" Then
                lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(0).Text & " " & strBudget
            End If

            If intMonth = 0 Then
                lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(14).Text & " " & intYear
            Else
                lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(13).Text & " " & intMonth
                lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(14).Text & " " & intYear
            End If

            If Trim(lblSubTitle.Text) <> "" Then
                lblSubTitle.Visible = True
            Else
                lblSubTitle.Visible = False
            End If

            tblAccount = objBAccounting.GetAccountInfor(0, intMonth, intYear)
            hidCurrency.Value = objBAccounting.Currency
            dblStartRemain = objBAccounting.StartRemain
            dblLastBase = objBAccounting.LastBase

            Call ShowAccountReport()
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
                    For inti = 0 To 1
                        tblRow = New TableRow
                        Select Case inti
                            Case 0
                                For intj = 0 To 4
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
                            strAmount = Trim(CStr(tblAccount.Rows(intIndex).Item("AmountDisplay")))
                        Else
                            strAmount = ""
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
                            strTotal = Trim(CStr(tblAccount.Rows(intIndex).Item("Total")))
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
                            strSubtract = CStr(CDbl(strTotal) - dblRealTotal)
                            dblSubtractTotal1 = dblSubtractTotal1 + CDbl(strSubtract)
                            dblSeetled = dblSeetled + CDbl(strAmount)
                        Else
                            strSubtract = CStr(CDbl(strTotal) - dblRealTotal)
                            dblSubtractTotal2 = dblSubtractTotal2 + CDbl(strSubtract)
                            dblSpend = dblSpend + CDbl(strAmount)
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
                                Case 6  ' Amount (Spend)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    If intIsSeetled = 0 Then
                                        tblCell.Controls.Add(New LiteralControl(CStr(CDbl(strAmount))))
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If
                                Case 7  ' Currency Code (Spend)
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(8%)
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
                                    tblCell.HorizontalAlign = HorizontalAlign.Right
                                    tblCell.Controls.Add(New LiteralControl(strSRate))
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
                            Case 3  ' Sum of Spend fees
                                tblCell = New TableCell
                                tblCell.ColumnSpan = 3
                                tblCell.HorizontalAlign = HorizontalAlign.Left
                                tblCell.CssClass = "lbAmount"
                                strSum2 = Trim(CStr(dblSpend))
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
                    tblReport.Rows.Add(tblRow)

                    ' Visible the first and last remain or not
                    If CInt("0" & Request("Month")) = 0 Then
                        TRFirstRemain.Visible = False
                        TRLastRemain.Visible = False
                    Else
                        TRFirstRemain.Visible = True
                        TRLastRemain.Visible = True
                    End If
                End If
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

            lblFirstRemainAmount.Text = CStr(dblRealStartRemain)
            lblLastRemainAmount.Text = CStr(dblLastRemain)
            lblSetCurRemain1.Text = hidCurrency.Value
            lblSetCurRemain2.Text = hidCurrency.Value
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
                If Not objBBudget Is Nothing Then
                    objBBudget.Dispose(True)
                    objBBudget = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
