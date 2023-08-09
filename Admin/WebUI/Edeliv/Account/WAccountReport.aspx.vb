Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WAccountReport
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

        ' Declare variables
        Private objBAccountTrans As New clsBAccountTransaction
        Private tblAccount As DataTable
        Private intDisplay As Integer
        Private dblSeetled As Double
        Private dblUnSeetled As Double
        Private dblRemain As Double

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            'Me.ExportResource("c:\inetpub\wwwroot\Libol60\Resources\LabelString\Circulation\Accounting\WAccountReportSR.vi.resx", False)
            'Me.ExportResource("c:\inetpub\wwwroot\Libol60\Resources\LabelString\Circulation\Accounting\WAccountReportSR.en.resx", False)
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(162) Then
                Call WriteErrorMssg(ddlLabel.Items(15).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBAccountTrans
            objBAccountTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccountTrans.DBServer = Session("DBServer")
            objBAccountTrans.ConnectionString = Session("ConnectionString")
            objBAccountTrans.Initialize()
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim strYear As String
            Dim strMonth As String
            Dim strCustomerCode As String

            Dim intDisplay As Integer

            ' Get the patron code
            If Trim(Request("CustomerCode")) = "0" Or Trim(Request("CustomerCode")) = Nothing Then
                strCustomerCode = ""
            Else
                strCustomerCode = Trim(Request("CustomerCode"))
            End If

            ' Get the month value
            If Trim(Request("Month")) = "0" Or Trim(Request("Month")) = Nothing Then
                strMonth = "0"
            Else
                strMonth = Trim(Request("Month"))
            End If

            ' Get the year value
            If Trim(Request("Year")) = "0" Or Trim(Request("Year")) = Nothing Then
                strYear = "0"
            Else
                strYear = Trim(Request("Year"))
            End If


            ' Get the SubTitle
            If strCustomerCode <> "" Then
                lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(18).Text & " " & strCustomerCode
                If strMonth <> "0" Then
                    lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(1).Text & " " & strMonth
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(3).Text & " " & strYear
                    End If
                Else
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(3).Text & " " & strYear
                    End If
                End If
            Else
                If strMonth <> "0" Then
                    lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(0).Text & " " & strMonth
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & " " & ddlLabel.Items(3).Text & " " & strYear
                    End If
                Else
                    If strYear <> "0" Then
                        lblSubTitle.Text = lblSubTitle.Text & ddlLabel.Items(2).Text & " " & strYear
                    End If
                End If
            End If

            If Trim(lblSubTitle.Text) <> "" Then
                lblSubTitle.Visible = True
            Else
                lblSubTitle.Visible = False
            End If

            ' Transfer the properties for class B
            objBAccountTrans.Year = CInt(strYear)
            objBAccountTrans.CustomerCode = strCustomerCode
            objBAccountTrans.Month = CInt(strMonth)
            tblAccount = objBAccountTrans.GetAccInfor(intDisplay, dblSeetled, dblUnSeetled, dblRemain)  ' Get the data
            Call WriteErrorMssg(ddlLabel.Items(17).Text, objBAccountTrans.ErrorMsg, ddlLabel.Items(16).Text, objBAccountTrans.ErrorCode)
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
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(6).Text))
                                        Case 1
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(7).Text))
                                        Case 2
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(8).Text))
                                        Case 3
                                            tblCell.ColumnSpan = 4
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(9).Text))
                                        Case 4
                                            tblCell.RowSpan = 2
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(10).Text))
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
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(11).Text))
                                        Case 1, 5
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(12).Text))
                                        Case 2, 6
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(13).Text))
                                        Case 3, 7
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(14).Text))
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
                                            tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(5).Text))
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
                                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text & ": <span id=""lblRemainder"" class=""lbAmount"">" & CStr(dblRemain) & " VND</span>"))
                                Else
                                    tblCell.Controls.Add(New LiteralControl(ddlLabel.Items(4).Text & ": <span id=""lblRemainder"" class=""lbAmount"">0.00 VND</span>"))
                                End If
                                tblRow.CssClass = "lbGridPager"
                                tblRow.Cells.Add(tblCell)
                        End Select
                        tblReport.Rows.Add(tblRow)
                    Next
                End If
            End If
        End Sub

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
    End Class
End Namespace