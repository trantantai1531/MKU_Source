Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatisticLoanHistoryCopyNumber
        Inherits clsWBase
        Private objBCommonChart As New clsBCommonChart
        Private objBLoanTransaction As New clsBLoanTransaction

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            Call BindStatic()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init clsBLoanTransaction object
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLoanTransaction.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindJS method
        ' Purpose: Bind javascript
        Private Sub BindJS()


            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            txtCheckOutDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateFrom.ToolTip = Session("DateFormat")
            txtCheckOutDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtCheckOutDateTo.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCheckOutDateFrom, txtCheckOutDateFrom, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkCheckOutDateTo, txtCheckOutDateTo, ddlLabel.Items(6).Text)

        End Sub

        ' BindStatic method
        Private Sub BindStatic()
            Dim arrData() As Integer
            Dim arrLabel() As String
            Dim strImage As String = "../Images/bground.gif"
            Dim strVTitle As String = ddlLabel.Items(4).Text
            Dim strHTitle As String = ddlLabel.Items(5).Text
            Dim strCheckOutDateFrom As String = ""
            Dim strCheckOutDateTo As String = ""

            ' Static on loan
            strCheckOutDateFrom = Trim(txtCheckOutDateFrom.Text)
            strCheckOutDateTo = Trim(txtCheckOutDateTo.Text)

            If strCheckOutDateFrom <> "" Or strCheckOutDateTo <> "" Then
                objBLoanTransaction.CreateStatisticLoanHistoryCopyNumber(strCheckOutDateFrom, strCheckOutDateTo)
                arrData = objBLoanTransaction.arrData
                arrLabel = objBLoanTransaction.arrLabel
                Image1.Visible = False
                Image2.Visible = False
                hidHave.Value = 0
                lblNostatic.Visible = True
                lblNostatic1.Visible = True

                If Not arrData Is Nothing And Not arrLabel Is Nothing Then
                    If arrData(0) > -1 Then
                        Image1.Visible = True
                        Image2.Visible = True
                        Call objBCommonChart.Makebarchart(arrData, arrLabel, strHTitle, strVTitle, 45, strImage, "")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream

                        Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCommonChart.OutPutStream
                        hidHave.Value = 1
                        lblNostatic.Visible = False
                        lblNostatic1.Visible = False

                        BindData()
                    Else
                        Session("chart1") = Nothing
                        Session("chart2") = Nothing

                        dtgResult.DataSource = Nothing
                        dtgResult.DataBind()
                    End If
                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing

                    dtgResult.DataSource = Nothing
                    dtgResult.DataBind()
                End If
            Else
                lblNostatic.Visible = False
                lblNostatic1.Visible = False
                Image1.Visible = False
                Image2.Visible = False
                Session("chart1") = Nothing
                Session("chart2") = Nothing

                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            End If

        End Sub
        Private Sub BindData()
            Dim strCheckOutDateFrom As String = ""
            Dim strCheckOutDateTo As String = ""

            ' Static on loan
            strCheckOutDateFrom = Trim(txtCheckOutDateFrom.Text)
            strCheckOutDateTo = Trim(txtCheckOutDateTo.Text)

            Dim tblData As DataTable = objBLoanTransaction.CreateStatisticLoanHistoryCopyNumberDetail(strCheckOutDateFrom, strCheckOutDateTo)
            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                tblData.Columns.Add("STT")
                Dim intSTT As Integer = 1
                For Each row As DataRow In tblData.Rows
                    row("STT") = intSTT
                    intSTT = intSTT + 1
                Next
                dtgResult.DataSource = tblData
                dtgResult.DataBind()
            End If
        End Sub

        ' Event: btnCancel_Click
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            txtCheckOutDateFrom.Text = ""
            txtCheckOutDateTo.Text = ""
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
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("CheckOutDate")
                tblConvert.Columns.Add("CheckInDate")
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("STT")
                    Dim strCopyNumber As String = rows.Item("CopyNumber")
                    Dim strPatronCode As String = rows.Item("PatronCode")
                    Dim strCheckOutDate As String = String.Format("{0:dd/MM/yyyy}", rows.Item("CheckOutDate"))
                    Dim strCheckInDate As String = String.Format("{0:dd/MM/yyyy}", rows.Item("CheckInDate"))

                    dtRow.Item("STT") = stt
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("PatronCode") = strPatronCode
                    dtRow.Item("CheckOutDate") = strCheckOutDate
                    dtRow.Item("CheckInDate") = strCheckInDate

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try
                Dim strCheckOutDateFrom As String = ""
                Dim strCheckOutDateTo As String = ""

                ' Static on loan
                strCheckOutDateFrom = Trim(txtCheckOutDateFrom.Text)
                strCheckOutDateTo = Trim(txtCheckOutDateTo.Text)
                Dim tblData As DataTable = objBLoanTransaction.CreateStatisticLoanHistoryCopyNumberDetail(strCheckOutDateFrom, strCheckOutDateTo)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    tblData.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblData.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    Dim tblConvert As New DataTable("tblConvert")
                    ConvertTable(tblData, tblConvert)
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                    clsExport.StringBuilderToExcel(strHTMLContent)
                End If

            Catch ex As Exception

            End Try
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub
    End Class
End Namespace

