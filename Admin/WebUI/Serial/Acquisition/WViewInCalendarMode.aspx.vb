Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WViewInCalendarMode
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblAcquire As System.Web.UI.WebControls.Label
        Protected WithEvents lnkHdView As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lnkHdSearch As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPeriodical As New clsBPeriodical
        Private objBCommonBussiness As New clsBCommonBusiness

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Me.ShowWaitingOnPage(ddlLabel.Items(5).Text, "../..")
            If Not Page.IsPostBack Then
                If Trim(Request("Year")) & "" <> "" Then
                    lblYear.Text = Trim(Request("Year"))
                Else
                    lblYear.Text = Year(Now)
                End If
                ' Bind the current Date
                Call BindCurrentDate()

                lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text & "&Switch=1"

                BindDropDownList()

                If Request("LocationID") <> 0 Then
                    Dim intIndex As Integer
                    For intIndex = 0 To ddlHoldAddress.Items.Count - 1
                        If ddlHoldAddress.Items(intIndex).Value = Request("LocationID") Then
                            ddlHoldAddress.Items(intIndex).Selected = True
                        End If
                    Next
                End If

                If ddlHoldAddress.SelectedValue <> 0 Then
                    lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue & "&Switch=1"
                    btnUpdateAcq.Enabled = False
                End If

                DrawDynamicTable()
                BindData()
                btnUpdateAcq.Attributes.Add("OnClick", "javascript:location.href='WSummaryHoldingManagement.aspx?Update=1';return false;")

            End If
            Me.ShowWaitingOnPage("", "", True)
        End Sub

        ' CheckFormPermission method
        ' Purpose: check the user permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(91) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
            If Not CheckPemission(93) Then
                btnUpdateAcq.Enabled = False
            Else
                btnUpdateAcq.Enabled = True
            End If
        End Sub

        ' BindCurrentDate method
        ' Purpose: Display the currentDate
        Private Sub BindCurrentDate()
            lblCurrentDate.Text = Session("ToDay")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Session("ItemID") & "" = "" Then
                Response.Redirect("../WSearch.aspx?URL=Acquisition/WViewInCalendarMode.aspx")
            End If

            ' Init for objBPeriodical
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = CInt(Session("ItemID"))
            objBPeriodical.Initialize()

            ' Init for objBCommonBussiness
            objBCommonBussiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBussiness.DBServer = Session("DBServer")
            objBCommonBussiness.ConnectionString = Session("ConnectionString")
            objBCommonBussiness.UserID = Session("UserID")
            objBCommonBussiness.ItemID = Session("ItemID")
            objBCommonBussiness.Initialize()
            'show title
            lblTitle.Text = "<H3>" & Session("Title") & "</H3>"
        End Sub


        ' BindData method
        Private Sub BindData()
            If Request("Switch") & "" <> "" Then
                lblHavingIssue.Text = Session("HavingIssue")
                lblLostIssue.Text = Session("LostIssue")
                Exit Sub
            End If
            Dim intYear As Integer
            Dim intResetReg As Integer

            Dim strMonths, strHavingYearIssue, strShowHas, strShowLost, strFirstIssueInYear As String

            intYear = CInt(lblYear.Text)

            objBPeriodical.LocationID = CInt(ddlHoldAddress.SelectedValue)
            Call objBPeriodical.GetReceiveIssueNums(intYear, intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear)

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

            ' Set the default values
            clsGetIssueNos.GetHasLostIssueNo(intResetReg, strMonths, strHavingYearIssue, strFirstIssueInYear, ddlLabel.Items(6).Text, ddlLabel.Items(4).Text, ddlLabel.Items(7).Text, strShowHas, strShowLost)
            lblHavingIssue.Text = strShowHas
            lblLostIssue.Text = strShowLost
            Session("HavingIssue") = strShowHas
            Session("LostIssue") = strShowLost
        End Sub


        ' BindDropDownList method
        Private Sub BindDropDownList()
            Dim tblLocation As DataTable
            tblLocation = objBCommonBussiness.GetRoutingLocations

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBussiness.ErrorCode)

            If Not tblLocation Is Nothing Then
                tblLocation = InsertOneRow(tblLocation, Trim(ddlLabel.Items(3).Text))
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
            End If

            ' get the user location
            If Not tblLocation Is Nothing Then
                If tblLocation.Rows.Count > 0 Then
                    With ddlHoldAddress
                        .DataSource = tblLocation
                        .DataTextField = "LOCNAME"
                        .DataValueField = "ID"
                        .DataBind()
                    End With
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub


        ' DrawDynamicTable method
        ' Purpose: Draw the calendar and display the have and lost issues
        Private Sub DrawDynamicTable()
            Dim tblItem As DataTable
            Dim intYear As Integer
            Dim intSumFound As Integer = 0
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim inti As Integer
            Dim intj As Integer
            Dim intIndex As Integer
            Dim intItemID As Integer
            Dim strDOWs As String = ""
            Dim intFreqMode As Integer = 0
            Dim strBasedDate As String = ""
            Dim strCeasedDate As String = ""
            intItemID = Session("ItemID")

            ' Get year value
            intYear = CInt(lblYear.Text)
            objBPeriodical.LocationID = ddlHoldAddress.SelectedValue
            tblItem = objBPeriodical.GetReceivedIssuesByYear(intYear, strDOWs, strBasedDate, strCeasedDate)

            If Trim(strBasedDate) = "" Then
                strBasedDate = "0"
            End If

            If Trim(strCeasedDate) = "" Then
                strCeasedDate = Year(Now) & StrDup(2 - Len(CStr(Month(Now))), "0") & Month(Now) & _
                StrDup(2 - Len(CStr(Day(Now))), "0") & Day(Now)
            End If

            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

            intFreqMode = objBPeriodical.FreqMode
            strBasedDate = Trim(strBasedDate)
            strCeasedDate = Trim(strCeasedDate)

            'If intFreqMode = 0 Then
            '    lblLostIssue.Visible = False
            'Else
            '    lblLostIssue.Visible = True
            'End If

            ' Get the total record
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    intSumFound = CInt(tblItem.Rows.Count)   ' Sum of records found
                End If
            End If

            Dim intNumDayOfMonth1 As Integer = 0
            Dim intNumDayOfMonth2 As Integer = 0
            Dim intNumDayOfMonth3 As Integer = 0
            Dim intMonthDisplay As Integer = 0
            Dim intFirstWeekDay As Integer = 0
            Dim intCount1 As Integer = 0
            Dim intCount2 As Integer = 0
            Dim intCount3 As Integer = 0
            Dim intMon As Integer = 0
            Dim intDay As Integer = 0
            Dim intIssueID As Integer
            Dim intWeekDay As Integer = 0
            Dim intDate1, intDate2, intDate3 As Integer
            Dim dtDate As Date
            Dim strIssueNum As String
            Dim blnFound As Boolean = False

            ' ************ BEGIN DRAW THE DINAMIC TABLE ******************
            Select Case intFreqMode   ' Draw by Freq Mode
                Case 0, 1, 2 ' Hang ngay, hang tuan, ko xac dinh
                    ' Add attributes for dinamic table
                    tblCalendar.BorderWidth = Unit.Pixel(1)

                    tblCalendar.Width = Unit.Percentage(100)
                    tblCalendar.HorizontalAlign = HorizontalAlign.Center
                    tblCalendar.CellPadding = 1
                    ' Draw the header of first 3 months (1,2,3)
                    For inti = 0 To 1
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center

                        Select Case inti
                            Case 0
                                tblRow.BackColor = Drawing.Color.FromName("#128DB9")
                                For intj = 0 To 4
                                    tblCell = New TableCell
                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                    tblCell.Font.Bold = True
                                    tblCell.Font.Size = FontUnit.Point(14)
                                    'tblCell.Width = Unit.Percentage(100 / 3)
                                    Select Case intj
                                        Case 0
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("January " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 1
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.1)
                                        Case 2
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("February " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 3
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.1)
                                        Case 4
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("March " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                            Case 1
                                tblRow.BackColor = Drawing.Color.FromName("#FFCC66")
                                For intj = 0 To 22
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(100 / 3 / 7)
                                    Select Case intj
                                        Case 0, 8, 16
                                            tblCell.Controls.Add(New LiteralControl("Sun"))
                                            tblCell.ForeColor = Color.Red
                                        Case 1, 9, 17
                                            tblCell.Controls.Add(New LiteralControl("Mon"))
                                        Case 2, 10, 18
                                            tblCell.Controls.Add(New LiteralControl("Tue"))
                                        Case 3, 11, 19
                                            tblCell.Controls.Add(New LiteralControl("Wed"))
                                        Case 4, 12, 20
                                            tblCell.Controls.Add(New LiteralControl("Thu"))
                                        Case 5, 13, 21
                                            tblCell.Controls.Add(New LiteralControl("Fri"))
                                        Case 6, 14, 22
                                            tblCell.Controls.Add(New LiteralControl("Sat"))
                                            tblCell.BorderWidth = Unit.Pixel(2)
                                        Case 7, 15
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.1)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                        End Select
                        tblCalendar.Rows.Add(tblRow)
                    Next

                    ' Get the value for first 3 months
                    For intj = 1 To 6
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center
                        tblRow.BackColor = Drawing.Color.FromName("#EEEECC")
                        For inti = 1 To 23
                            intMon = 0
                            intDay = 0
                            strIssueNum = ""
                            blnFound = False
                            tblCell = New TableCell
                            Select Case inti
                                Case 1, 2, 3, 4, 5, 6, 7
                                    If intj = 1 Then
                                        intNumDayOfMonth1 = GetDaysInMonth(1, intYear)
                                        dtDate = "1/1/" & intYear
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 1 And intDay = (inti - intWeekDay) + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) + 1 & "/" & "01/" & intYear & """ class=""lbAmount"">v<A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "01/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "01/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "01/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 7 Then
                                            intCount1 = (inti - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount1 = intCount1 + 1
                                        If intCount1 <= intNumDayOfMonth1 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 1 And intDay = intCount1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        Case 1
                                                            If CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "01/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "01/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                    Case 1
                                                        If CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "01/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "01" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "01/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 1 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 8, 16
                                    tblCell.BackColor = Drawing.Color.FromName("red")
                                    tblCell.Width = Unit.Percentage(0.10000000000000001)
                                Case 9, 10, 11, 12, 13, 14, 15
                                    If intj = 1 Then
                                        intNumDayOfMonth2 = GetDaysInMonth(2, intYear)
                                        intMonthDisplay = 2
                                        Try
                                            dtDate = "1/2/" & intYear
                                        Catch ex As Exception
                                            dtDate = "2/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 7 - 1 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 2 And intDay = inti - 7 - intWeekDay + 1 - 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "02" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "02" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(inti - 7 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "02" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "02" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(inti - 7 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 15 Then
                                            intCount2 = ((inti - 7 - 1) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount2 = intCount2 + 1
                                        If intCount2 <= intNumDayOfMonth2 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 2 And intDay = intCount2 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        Case 1
                                                            If CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                    End Select

                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                    Case 1
                                                        If CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "02" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "02/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 2 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 17, 18, 19, 20, 21, 22, 23
                                    If intj = 1 Then
                                        intNumDayOfMonth3 = GetDaysInMonth(3, intYear)
                                        intMonthDisplay = 3
                                        Try
                                            dtDate = "1/3/" & intYear
                                        Catch ex As Exception
                                            dtDate = "3/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 14 - 2 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 3 And intDay = inti - 14 - 2 - intWeekDay + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 23 Then
                                            intCount3 = ((inti - 14 - 2) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount3 = intCount3 + 1
                                        If intCount3 <= intNumDayOfMonth3 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 3 And intDay = intCount3 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        Case 1
                                                            If CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                    End Select

                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                    Case 1
                                                        If CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "03" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "03/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 3 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                            End Select
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblCalendar.Rows.Add(tblRow)
                    Next
                    ' End draw table for first 3 months

                    ' *********** Draw table for second 3 months (4,5,6) ***********
                    For inti = 0 To 1
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center

                        Select Case inti
                            Case 0
                                tblRow.BackColor = Drawing.Color.FromName("#128DB9")
                                For intj = 0 To 4
                                    tblCell = New TableCell
                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                    tblCell.Font.Bold = True
                                    tblCell.Font.Size = FontUnit.Point(14)
                                    'tblCell.Width = Unit.Percentage(100 / 3)
                                    Select Case intj
                                        Case 0
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("April " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 1
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                        Case 2
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("May " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 3
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                        Case 4
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("June " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                            Case 1
                                tblRow.BackColor = Drawing.Color.FromName("#FFCC66")
                                For intj = 0 To 22
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(100 / 3 / 7)
                                    Select Case intj
                                        Case 0, 8, 16
                                            tblCell.Controls.Add(New LiteralControl("Sun"))
                                            tblCell.ForeColor = Color.Red
                                        Case 1, 9, 17
                                            tblCell.Controls.Add(New LiteralControl("Mon"))
                                        Case 2, 10, 18
                                            tblCell.Controls.Add(New LiteralControl("Tue"))
                                        Case 3, 11, 19
                                            tblCell.Controls.Add(New LiteralControl("Wed"))
                                        Case 4, 12, 20
                                            tblCell.Controls.Add(New LiteralControl("Thu"))
                                        Case 5, 13, 21
                                            tblCell.Controls.Add(New LiteralControl("Fri"))
                                        Case 6, 14, 22
                                            tblCell.Controls.Add(New LiteralControl("Sat"))
                                        Case 7, 15
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                        End Select
                        tblCalendar.Rows.Add(tblRow)
                    Next

                    ' Get the value for second 3 months
                    For intj = 1 To 6
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center
                        tblRow.BackColor = Drawing.Color.FromName("#EEEECC")
                        For inti = 1 To 23
                            intMon = 0
                            intDay = 0
                            strIssueNum = ""
                            blnFound = False
                            tblCell = New TableCell
                            Select Case inti
                                Case 1, 2, 3, 4, 5, 6, 7
                                    If intj = 1 Then
                                        intNumDayOfMonth1 = GetDaysInMonth(4, intYear)
                                        Try
                                            dtDate = "1/4/" & intYear
                                        Catch ex As Exception
                                            dtDate = "4/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 4 And intDay = (inti - intWeekDay) + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 7 Then
                                            intCount1 = (inti - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount1 = intCount1 + 1
                                        If intCount1 <= intNumDayOfMonth1 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 4 And intDay = intCount1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        Case 1
                                                            If CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                    Case 1
                                                        If CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "04" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "04/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 4 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 8, 16
                                    tblCell.BackColor = Drawing.Color.FromName("red")
                                    tblCell.Width = Unit.Percentage(0.10000000000000001)
                                Case 9, 10, 11, 12, 13, 14, 15
                                    If intj = 1 Then
                                        intNumDayOfMonth2 = GetDaysInMonth(5, intYear)
                                        intMonthDisplay = 2
                                        Try
                                            dtDate = "1/5/" & intYear
                                        Catch ex As Exception
                                            dtDate = "5/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 7 - 1 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 5 And intDay = inti - 7 - 1 - intWeekDay + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "5" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "5" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "05" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "05" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "05" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "05" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "05" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "05" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 15 Then
                                            intCount2 = ((inti - 7 - 1) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount2 = intCount2 + 1
                                        If intCount2 <= intNumDayOfMonth2 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 5 And intDay = intCount2 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        Case 1
                                                            If CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                    End Select

                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                    Case 1
                                                        If CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "05" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "05/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 5 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 17, 18, 19, 20, 21, 22, 23
                                    If intj = 1 Then
                                        intNumDayOfMonth3 = GetDaysInMonth(6, intYear)
                                        intMonthDisplay = 3
                                        Try
                                            dtDate = "1/6/" & intYear
                                        Catch ex As Exception
                                            dtDate = "6/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 14 - 2 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 6 And intDay = inti - 14 - 2 - intWeekDay + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "06/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "06/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "06/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "6/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 23 Then
                                            intCount3 = ((inti - 14 - 2) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount3 = intCount3 + 1
                                        If intCount3 <= intNumDayOfMonth3 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 6 And intDay = intCount3 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        Case 1
                                                            If CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "06/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "06/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                    End Select

                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                    Case 1
                                                        If CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "06/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "06" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "06/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 6 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                            End Select
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblCalendar.Rows.Add(tblRow)
                    Next


                    ' ************* End draw table for second 3 months ************

                    ' ************* Draw table for third 3 months (7,8,9) ***********
                    For inti = 0 To 1
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center

                        Select Case inti
                            Case 0
                                tblRow.BackColor = Drawing.Color.FromName("#128DB9")
                                For intj = 0 To 4
                                    tblCell = New TableCell
                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                    tblCell.Font.Bold = True
                                    tblCell.Font.Size = FontUnit.Point(14)
                                    'tblCell.Width = Unit.Percentage(100 / 3)
                                    Select Case intj
                                        Case 0
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("July " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 1
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)

                                        Case 2
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("August " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 3
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                        Case 4
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("September " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                            Case 1
                                tblRow.BackColor = Drawing.Color.FromName("#FFCC66")
                                For intj = 0 To 22
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(100 / 3 / 7)
                                    Select Case intj
                                        Case 0, 8, 16
                                            tblCell.Controls.Add(New LiteralControl("Sun"))
                                            tblCell.ForeColor = Color.Red
                                        Case 1, 9, 17
                                            tblCell.Controls.Add(New LiteralControl("Mon"))
                                        Case 2, 10, 18
                                            tblCell.Controls.Add(New LiteralControl("Tue"))
                                        Case 3, 11, 19
                                            tblCell.Controls.Add(New LiteralControl("Wed"))
                                        Case 4, 12, 20
                                            tblCell.Controls.Add(New LiteralControl("Thu"))
                                        Case 5, 13, 21
                                            tblCell.Controls.Add(New LiteralControl("Fri"))
                                        Case 6, 14, 22
                                            tblCell.Controls.Add(New LiteralControl("Sat"))
                                        Case 7, 15
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                        End Select
                        tblCalendar.Rows.Add(tblRow)
                    Next

                    ' Get the value for third 3 months
                    For intj = 1 To 6
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center
                        tblRow.BackColor = Drawing.Color.FromName("#EEEECC")
                        For inti = 1 To 23
                            intMon = 0
                            intDay = 0
                            strIssueNum = ""
                            blnFound = False
                            tblCell = New TableCell
                            Select Case inti
                                Case 1, 2, 3, 4, 5, 6, 7
                                    If intj = 1 Then
                                        intNumDayOfMonth1 = GetDaysInMonth(7, intYear)
                                        Try
                                            dtDate = "1/7/" & intYear
                                        Catch ex As Exception
                                            dtDate = "7/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 7 And intDay = (inti - intWeekDay) + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 7 Then
                                            intCount1 = (inti - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount1 = intCount1 + 1
                                        If intCount1 <= intNumDayOfMonth1 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 7 And intDay = intCount1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        Case 1
                                                            If CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                    Case 1
                                                        If CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "07" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "07/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 7 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 8, 16
                                    tblCell.BackColor = Drawing.Color.FromName("red")
                                    tblCell.Width = Unit.Percentage(0.10000000000000001)
                                Case 9, 10, 11, 12, 13, 14, 15
                                    If intj = 1 Then
                                        intNumDayOfMonth2 = GetDaysInMonth(8, intYear)
                                        intMonthDisplay = 8
                                        Try
                                            dtDate = "1/8/" & intYear
                                        Catch ex As Exception
                                            dtDate = "8/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 7 - 1 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 8 And intDay = inti - 7 - 1 - intWeekDay + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 15 Then
                                            intCount2 = ((inti - 7 - 1) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount2 = intCount2 + 1
                                        If intCount2 <= intNumDayOfMonth2 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 8 And intDay = intCount2 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        Case 1
                                                            If CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                    End Select

                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                    Case 1
                                                        If CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "08" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "08/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 8 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 17, 18, 19, 20, 21, 22, 23
                                    If intj = 1 Then
                                        intNumDayOfMonth3 = GetDaysInMonth(9, intYear)
                                        intMonthDisplay = 9
                                        Try
                                            dtDate = "1/9/" & intYear
                                        Catch ex As Exception
                                            dtDate = "9/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 14 - 2 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 9 And intDay = inti - 14 - 2 - intWeekDay + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 23 Then
                                            intCount3 = ((inti - 14 - 2) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount3 = intCount3 + 1
                                        If intCount3 <= intNumDayOfMonth3 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 9 And intDay = intCount3 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        Case 1
                                                            If CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                    End Select

                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                    Case 1
                                                        If CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "09" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "09/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 9 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                            End Select
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblCalendar.Rows.Add(tblRow)
                    Next

                    ' ************** End draw table for third 3 months *************

                    ' *************** Draw table for fourth 3 months (10,11,12) ********
                    For inti = 0 To 1
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center

                        Select Case inti
                            Case 0
                                tblRow.BackColor = Drawing.Color.FromName("#128DB9")
                                For intj = 0 To 4
                                    tblCell = New TableCell
                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                    tblCell.Font.Bold = True
                                    tblCell.Font.Size = FontUnit.Point(14)
                                    'tblCell.Width = Unit.Percentage(100 / 3)
                                    Select Case intj
                                        Case 0
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("October " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 1
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                        Case 2
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("November " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                        Case 3
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                        Case 4
                                            tblCell.ColumnSpan = 7
                                            tblCell.Controls.Add(New LiteralControl("December " & lblYear.Text))
                                            tblCell.Width = Unit.Percentage(100 / 3)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                            Case 1
                                tblRow.BackColor = Drawing.Color.FromName("#FFCC66")
                                For intj = 0 To 22
                                    tblCell = New TableCell
                                    tblCell.Width = Unit.Percentage(100 / 3 / 7)
                                    Select Case intj
                                        Case 0, 8, 16
                                            tblCell.Controls.Add(New LiteralControl("Sun"))
                                            tblCell.ForeColor = Color.Red
                                        Case 1, 9, 17
                                            tblCell.Controls.Add(New LiteralControl("Mon"))
                                        Case 2, 10, 18
                                            tblCell.Controls.Add(New LiteralControl("Tue"))
                                        Case 3, 11, 19
                                            tblCell.Controls.Add(New LiteralControl("Wed"))
                                        Case 4, 12, 20
                                            tblCell.Controls.Add(New LiteralControl("Thu"))
                                        Case 5, 13, 21
                                            tblCell.Controls.Add(New LiteralControl("Fri"))
                                        Case 6, 14, 22
                                            tblCell.Controls.Add(New LiteralControl("Sat"))
                                        Case 7, 15
                                            tblCell.BackColor = Drawing.Color.FromName("red")
                                            tblCell.Width = Unit.Percentage(0.10000000000000001)
                                    End Select
                                    tblRow.Cells.Add(tblCell)
                                Next
                        End Select
                        tblCalendar.Rows.Add(tblRow)
                    Next

                    ' Get the value for fourth 3 months
                    For intj = 1 To 6
                        tblRow = New TableRow
                        tblRow.HorizontalAlign = HorizontalAlign.Center
                        tblRow.BackColor = Drawing.Color.FromName("#EEEECC")
                        For inti = 1 To 23
                            intMon = 0
                            intDay = 0
                            strIssueNum = ""
                            blnFound = False
                            tblCell = New TableCell
                            Select Case inti
                                Case 1, 2, 3, 4, 5, 6, 7
                                    If intj = 1 Then
                                        intNumDayOfMonth1 = GetDaysInMonth(10, intYear)
                                        Try
                                            dtDate = "1/10/" & intYear
                                        Catch ex As Exception
                                            dtDate = "10/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 10 And intDay = (inti - intWeekDay) + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(inti - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - intWeekDay + 1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = inti - intWeekDay + 1 Then
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr((inti - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 7 Then
                                            intCount1 = (inti - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount1 = intCount1 + 1
                                        If intCount1 <= intNumDayOfMonth1 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 10 And intDay = intCount1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        Case 1
                                                            If CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti)) > 0 Then
                                                                If CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 1 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                                End If
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 1 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                    Case 1
                                                        If CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti)) > 0 Then
                                                            If CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) >= CInt(strBasedDate) And CInt(intYear & "10" & Right("0" & CStr(intCount1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount1), 2) & "/" & "10/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 1 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                            End If
                                                        Else
                                                            If inti = 1 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 10 And Year(Now) = intYear And Day(Now) = intCount1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount1)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 8, 16
                                    tblCell.BackColor = Drawing.Color.FromName("red")
                                    tblCell.Width = Unit.Percentage(0.10000000000000001)
                                Case 9, 10, 11, 12, 13, 14, 15
                                    If intj = 1 Then
                                        intNumDayOfMonth2 = GetDaysInMonth(11, intYear)
                                        intMonthDisplay = 11
                                        Try
                                            dtDate = "1/11/" & intYear
                                        Catch ex As Exception
                                            dtDate = "11/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 7 - 1 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 11 And intDay = inti - 7 - 1 - intWeekDay + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 7 - 1 - intWeekDay + 1), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = inti - 7 - 1 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 7 - 1) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 15 Then
                                            intCount2 = ((inti - 7 - 1) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount2 = intCount2 + 1
                                        If intCount2 <= intNumDayOfMonth2 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 11 And intDay = intCount2 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        Case 1
                                                            If CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                                If CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 9 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                                End If
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                    End Select

                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 9 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                    Case 1
                                                        If CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 7 - 1)) > 0 Then
                                                            If CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) >= CInt(strBasedDate) And CInt(intYear & "11" & Right("0" & CStr(intCount2), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount2), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 9 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                            End If
                                                        Else
                                                            If inti = 9 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 11 And Year(Now) = intYear And Day(Now) = intCount2 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount2)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                                Case 17, 18, 19, 20, 21, 22, 23
                                    If intj = 1 Then
                                        intNumDayOfMonth3 = GetDaysInMonth(12, intYear)
                                        intMonthDisplay = 12
                                        Try
                                            dtDate = "1/12/" & intYear
                                        Catch ex As Exception
                                            dtDate = "12/1/" & intYear
                                        End Try
                                        intWeekDay = Weekday(dtDate)
                                        If intWeekDay > inti - 14 - 2 Then
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        Else
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 12 And intDay = inti - 14 - 2 - intWeekDay + 1 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        Case 1
                                                            If CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "11/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                    Case 1
                                                        If CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "12/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(inti - 14 - 2 - intWeekDay + 1), 2) & "/" & "12/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = inti - 14 - 2 - intWeekDay + 1 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(((inti - 14 - 2) - intWeekDay) + 1)))
                                                        End If
                                                End Select
                                            End If
                                        End If
                                        If inti = 23 Then
                                            intCount3 = ((inti - 14 - 2) - intWeekDay) + 1
                                        End If
                                    Else
                                        intCount3 = intCount3 + 1
                                        If intCount3 <= intNumDayOfMonth3 Then
                                            If intSumFound > 0 Then
                                                For intIndex = 0 To intSumFound - 1
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                        intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        intDay = Day(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                        ' Compare with calendar date
                                                        If intMon = 12 And intDay = intCount3 Then
                                                            blnFound = True
                                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                                If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                Else
                                                                    If ddlHoldAddress.SelectedValue <> 0 Then
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                    Else
                                                                        strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                    End If
                                                                End If
                                                            Else
                                                                If ddlHoldAddress.SelectedValue <> 0 Then
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                                Else
                                                                    strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                Next
                                                If blnFound = True Then
                                                    strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR>" & strIssueNum))
                                                Else
                                                    Select Case intFreqMode
                                                        Case 0
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        Case 1
                                                            If CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "12/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Case 2
                                                            If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                                If CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "12/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                                Else
                                                                    If inti = 17 Then
                                                                        tblCell.Font.Bold = True
                                                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                    End If
                                                                    If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                        tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                    End If
                                                                    tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                                End If
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                    End Select
                                                End If
                                            Else
                                                Select Case intFreqMode
                                                    Case 0
                                                        If inti = 17 Then
                                                            tblCell.Font.Bold = True
                                                            tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                        End If
                                                        If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                            tblCell.ForeColor = Drawing.Color.FromName("White")
                                                        End If
                                                        tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                    Case 1
                                                        If CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                            tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "12/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                    Case 2
                                                        If InStr(strDOWs, CStr(inti - 14 - 2)) > 0 Then
                                                            If CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) >= CInt(strBasedDate) And CInt(intYear & "12" & Right("0" & CStr(intCount3), 2)) <= CInt(strCeasedDate) Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#CCCC99")
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3) & "<BR><font color=""990000""><A href=""WCreateIssue.aspx?PubDate=" & Right("0" & CStr(intCount3), 2) & "/" & "12/" & intYear & """ class=""lbAmount"">v</A></font>"))
                                                            Else
                                                                If inti = 17 Then
                                                                    tblCell.Font.Bold = True
                                                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                                End If
                                                                If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                    tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                                                End If
                                                                tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                            End If
                                                        Else
                                                            If inti = 17 Then
                                                                tblCell.Font.Bold = True
                                                                tblCell.ForeColor = Drawing.Color.FromName("Red")
                                                            End If
                                                            If Month(Now) = 12 And Year(Now) = intYear And Day(Now) = intCount3 Then
                                                                tblCell.BackColor = Drawing.Color.FromName("#128DB9")
                                                                tblCell.ForeColor = Drawing.Color.FromName("White")
                                                            End If
                                                            tblCell.Controls.Add(New LiteralControl(CStr(intCount3)))
                                                        End If
                                                End Select
                                            End If
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    End If
                            End Select
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblCalendar.Rows.Add(tblRow)
                    Next
                    ' *************** End draw table for fourth 3 months **************

                    ' ****************** BEGIN DISPLAY THE TABLE FOR REG MODE = Every month (3)
                Case 3  ' Hang thang
                    ' Add attributes for dinamic table
                    tblCalendar.BorderStyle = BorderStyle.None
                    tblCalendar.BorderWidth = Unit.Pixel(1)
                    tblCalendar.Width = Unit.Percentage(100)
                    tblCalendar.HorizontalAlign = HorizontalAlign.Center
                    tblCalendar.CellPadding = 2
                    tblCalendar.CellSpacing = 0
                    For intj = 1 To 12
                        tblRow = New TableRow
                        tblRow.BackColor = Drawing.Color.FromName("FFCC66")
                        intMon = 0
                        For inti = 0 To 38
                            tblCell = New TableCell
                            Select Case inti
                                Case 0
                                    tblCell.RowSpan = 2
                                    tblCell.BackColor = Drawing.Color.FromName("128DB9 ")
                                    tblCell.ForeColor = Drawing.Color.FromName("White")
                                    tblCell.Font.Size = FontUnit.Point(11)
                                    tblCell.HorizontalAlign = HorizontalAlign.Center
                                    tblCell.Width = Unit.Percentage(3)
                                    tblCell.Font.Bold = True
                                    Select Case intj
                                        Case 1
                                            tblCell.Controls.Add(New LiteralControl("Jan"))
                                        Case 2
                                            tblCell.Controls.Add(New LiteralControl("Feb"))
                                        Case 3
                                            tblCell.Controls.Add(New LiteralControl("Mar"))
                                        Case 4
                                            tblCell.Controls.Add(New LiteralControl("Apr"))
                                        Case 5
                                            tblCell.Controls.Add(New LiteralControl("May"))
                                        Case 6
                                            tblCell.Controls.Add(New LiteralControl("Jun"))
                                        Case 7
                                            tblCell.Controls.Add(New LiteralControl("Jul"))
                                        Case 8
                                            tblCell.Controls.Add(New LiteralControl("Aug"))
                                        Case 9
                                            tblCell.Controls.Add(New LiteralControl("Sep"))
                                        Case 10
                                            tblCell.Controls.Add(New LiteralControl("Oct"))
                                        Case 11
                                            tblCell.Controls.Add(New LiteralControl("Nov"))
                                        Case 12
                                            tblCell.Controls.Add(New LiteralControl("Dec"))
                                    End Select
                                Case 1, 8, 15, 22, 29, 36
                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                    tblCell.Controls.Add(New LiteralControl("S"))
                                Case 2, 9, 16, 23, 30, 37
                                    tblCell.Controls.Add(New LiteralControl("M"))
                                Case 3, 5, 10, 12, 17, 19, 24, 26, 31, 33
                                    tblCell.Controls.Add(New LiteralControl("T"))
                                Case 4, 11, 18, 25, 32
                                    tblCell.Controls.Add(New LiteralControl("W"))
                                Case 6, 13, 20, 27, 34
                                    tblCell.Controls.Add(New LiteralControl("F"))
                                Case 7, 14, 21, 28, 35
                                    tblCell.Controls.Add(New LiteralControl("S"))
                                Case 38
                                    strIssueNum = ""
                                    blnFound = False
                                    tblCell.RowSpan = 2
                                    tblCell.BackColor = Drawing.Color.FromName("White")
                                    tblCell.Controls.Add(New LiteralControl(""))
                                    If intSumFound > 0 Then
                                        For intIndex = 0 To intSumFound - 1
                                            If Not IsDBNull(tblItem.Rows(intIndex).Item("ISSUEDDATE")) Then
                                                intMon = Month(tblItem.Rows(intIndex).Item("ISSUEDDATE"))
                                                ' Compare with calendar date
                                                If intMon = intj Then
                                                    blnFound = True
                                                    If Not IsDBNull(tblItem.Rows(intIndex).Item("VolumeByPublisher")) Then
                                                        If Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher"))) <> "" Then
                                                            If ddlHoldAddress.SelectedValue <> 0 Then
                                                                strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=" & tblItem.Rows(intIndex).Item("VolumeByPublisher") & "&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                            Else
                                                                strIssueNum = strIssueNum & Trim(CStr(tblItem.Rows(intIndex).Item("VolumeByPublisher") & ": <A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                            End If
                                                        Else
                                                            If ddlHoldAddress.SelectedValue <> 0 Then
                                                                strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                            Else
                                                                strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                            End If
                                                        End If
                                                    Else
                                                        If ddlHoldAddress.SelectedValue <> 0 Then
                                                            strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000""><A HREF=""WReceive.aspx?ItemID=" & Session("ItemID") & "&Year=" & intYear & "&IssueID=" & tblItem.Rows(intIndex).Item("ID") & "&Volume=NULL&LocationID=" & ddlHoldAddress.SelectedValue & """ class=""lbAmount"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</A></font>")) & "<BR>"
                                                        Else
                                                            strIssueNum = strIssueNum & Trim(CStr("<A HREF=""WCreateIssue.aspx?Modify=1&IssueID=" & tblItem.Rows(intIndex).Item("ID") & """ class=""lbLinkFunction"">" & tblItem.Rows(intIndex).Item("IssueNo") & "</A>" & If(String.IsNullOrEmpty((tblItem.Rows(intIndex).Item("OvIssueNo")).ToString()), "", "(" & tblItem.Rows(intIndex).Item("OvIssueNo") & ")") & "<BR>" & "<font color=""990000"">" & tblItem.Rows(intIndex).Item("ReceivedCopies") & "</font>")) & "<BR>"
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next
                                        If blnFound = True Then
                                            tblCell.Width = Unit.Percentage(10)
                                            strIssueNum = Left(strIssueNum, Len(strIssueNum) - 4)
                                            tblCell.Controls.Add(New LiteralControl(strIssueNum))
                                        Else
                                            tblCell.Controls.Add(New LiteralControl(""))
                                        End If
                                    Else
                                        tblCell.Controls.Add(New LiteralControl(""))
                                    End If

                            End Select
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblCalendar.Rows.Add(tblRow)


                        intCount1 = 0
                        intNumDayOfMonth1 = GetDaysInMonth(intj, intYear)
                        Try
                            dtDate = "1/" & intj & "/" & intYear
                        Catch ex As Exception
                            dtDate = "intj" & "/1" & intYear
                        End Try
                        intWeekDay = Weekday(dtDate)

                        ' Add row (days in month)
                        tblRow = New TableRow
                        tblRow.BackColor = Drawing.Color.FromName("EEEECC")
                        For inti = 1 To 37
                            tblCell = New TableCell
                            If intCount1 = 0 Then
                                If intWeekDay = inti Then
                                    If inti = 1 Then
                                        tblCell.ForeColor = Drawing.Color.FromName("Red")
                                        tblCell.Font.Bold = True
                                    End If
                                    If Month(Now) = intj And Day(Now) = 1 And Year(Now) = intYear Then
                                        tblCell.BackColor = Drawing.Color.FromName("128DB9")
                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                    End If
                                    tblCell.Controls.Add(New LiteralControl("1"))
                                    intCount1 = 1
                                Else
                                    tblCell.Controls.Add(New LiteralControl(""))
                                End If
                            Else
                                intCount1 = intCount1 + 1
                                If inti = 8 Or inti = 15 Or inti = 22 Or inti = 29 Or inti = 36 Then
                                    tblCell.ForeColor = Drawing.Color.FromName("Red")
                                    tblCell.Font.Bold = True
                                End If
                                If intCount1 <= intNumDayOfMonth1 Then
                                    If Month(Now) = intj And Day(Now) = intCount1 And Year(Now) = intYear Then
                                        tblCell.BackColor = Drawing.Color.FromName("128DB9")
                                        tblCell.ForeColor = Drawing.Color.FromName("White")
                                    End If
                                    tblCell.Controls.Add(New LiteralControl(intCount1))
                                Else
                                    tblCell.Controls.Add(New LiteralControl(""))
                                End If
                            End If
                            tblRow.Cells.Add(tblCell)
                        Next
                        tblCalendar.Rows.Add(tblRow)
                        'add line red between months
                        tblRow = New TableRow
                        tblCell = New TableCell
                        tblCell.ColumnSpan = 39
                        tblCell.BackColor = Drawing.Color.Red
                        tblCell.Width = Unit.Pixel(2)
                        tblRow.Cells.Add(tblCell)
                        tblCalendar.Rows.Add(tblRow)
                    Next
            End Select

        End Sub

        ' Merrge method
        Private Sub Merger(ByRef strHaveIssues As String, ByRef strLostIssues As String, ByRef strLine As String, ByRef intLast As Integer, ByVal intStartNumber As Integer, ByVal intNumber As Integer)
            If intLast = -1 Then
                If intNumber > intStartNumber Then
                    If intNumber > intStartNumber + 1 Then
                        strLostIssues = intStartNumber & "-" & intNumber - 1
                    Else
                        strLostIssues = intStartNumber
                    End If
                    intLast = intNumber
                    strHaveIssues = intNumber
                ElseIf intNumber = intStartNumber Then
                    intLast = intStartNumber
                    strHaveIssues = intStartNumber
                    strLostIssues = ""
                End If
            Else
                If intNumber > intStartNumber Then
                    If CInt(intNumber) = intLast + 1 Then
                        If strLine = "-" Then
                            strHaveIssues = Replace(strHaveIssues, "-" & intLast, "-" & intNumber)
                        Else
                            strHaveIssues = strHaveIssues & "-" & intNumber
                            strLine = "-"
                        End If
                    Else
                        If intLast + 1 < intNumber - 1 Then
                            strLostIssues = strLostIssues & "," & intLast + 1 & "-" & intNumber - 1
                        Else
                            strLostIssues = strLostIssues & "," & intNumber - 1
                        End If
                        strHaveIssues = strHaveIssues & "," & intNumber
                        strLine = ""
                    End If
                    intLast = intNumber
                End If
            End If
        End Sub

        ' ddlHoldAddress_SelectedIndexChanged event
        Private Sub ddlHoldAddress_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlHoldAddress.SelectedIndexChanged
            BindData()
            DrawDynamicTable()
            If ddlHoldAddress.SelectedValue <> 0 Then
                btnUpdateAcq.Enabled = False
                lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue
            Else
                lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text
                If CheckPemission(93) Then
                    btnUpdateAcq.Enabled = True
                Else
                    btnUpdateAcq.Enabled = False
                End If
            End If
        End Sub

        ' lnkNext_Click event
        Private Sub lnkNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNext.Click
            lblYear.Text = CStr(CInt(lblYear.Text) + 1)
            BindData()
            DrawDynamicTable()
            lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text
            If ddlHoldAddress.SelectedValue <> 0 Then
                lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue
            End If
        End Sub

        ' lnkPrevious_Click event
        Private Sub lnkPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPrevious.Click
            lblYear.Text = CStr(CInt(lblYear.Text) - 1)
            BindData()
            DrawDynamicTable()
            lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text
            If ddlHoldAddress.SelectedValue <> 0 Then
                lnkListView.NavigateUrl = "WViewInListMode.aspx?Year=" & lblYear.Text & "&LocationID=" & ddlHoldAddress.SelectedValue
            End If
        End Sub

        ' GetDaysInMonth function
        ' Purpose: Calculate the num of days per month
        Function GetDaysInMonth(ByVal intMonth As Integer, ByVal intYear As Integer) As Integer
            Select Case intMonth
                Case 1, 3, 5, 7, 8, 10, 12
                    GetDaysInMonth = 31
                Case 4, 6, 9, 11
                    GetDaysInMonth = 30
                Case 2
                    If IsDate("February 29, " & intYear) Then
                        GetDaysInMonth = 29
                    Else
                        GetDaysInMonth = 28
                    End If
            End Select
        End Function

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
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