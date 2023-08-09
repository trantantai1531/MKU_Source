Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatCopyNumberAcquiredSource
        Inherits clsWBase
        Private objBCommonChart As New clsBCommonChart
        Private objBHolding As New clsBHolding
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCommon As New clsBCommonBusiness
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindDDl()
                Call BindStatic()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init clsBLoanTransaction object
            objBHolding.ConnectionString = Session("ConnectionString")
            objBHolding.DBServer = Session("DBServer")
            objBHolding.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBHolding.Initialize()

            ' Initialize objBCC object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init BCommonBusiness object
            objBCommon.DBServer = Session("DBServer")
            objBCommon.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommon.ConnectionString = Session("ConnectionString")
            Call objBCommon.Initialize()
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
            '
            txtAcquiredDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtAcquiredDateFrom.ToolTip = Session("DateFormat")
            txtAcquiredDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtAcquiredDateTo.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkAcquiredDateFrom, txtAcquiredDateFrom, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkAcquiredDateTo, txtAcquiredDateTo, ddlLabel.Items(6).Text)

        End Sub
        '' Bind Dropdown menu
        Private Sub BindDDl()
            ' AcqSource ddropdownlist
            Dim tblAcqSource = objBCommon.GetAcqSources
            If Not tblAcqSource Is Nothing AndAlso tblAcqSource.Rows.Count > 0 Then
                ddlAcqSource.DataSource = tblAcqSource
                ddlAcqSource.DataTextField = "Source"
                ddlAcqSource.DataValueField = "ID"
                ddlAcqSource.DataBind()
                ddlAcqSource.Items.Insert(0, New ListItem("Tất cả", 0))
            End If
            tblAcqSource.Clear()
        End Sub
        ' BindStatic method
        Private Sub BindStatic()
            Dim arrData As Object
            Dim arrLabel As Object
            Dim strImage As String = "../Images/bground.gif"
            Dim strVTitle As String = ddlLabel.Items(4).Text
            Dim strHTitle As String = ddlLabel.Items(5).Text
            Dim strAcquiredDateFrom As String = ""
            Dim strAcquiredDateTo As String = ""
            Dim intAcquiredID As Integer = 0       '' 0 = all
            Try
                If Request.QueryString("xLabel") & "" = "" Then
                    ' Static on loan
                    strAcquiredDateFrom = Trim(txtAcquiredDateFrom.Text)
                    strAcquiredDateTo = Trim(txtAcquiredDateTo.Text)
                    '' AcquiredID
                    intAcquiredID = CInt(ddlAcqSource.SelectedItem.Value)
                    '' get data
                    objBHolding.StatCopyNumberAcqSource(intAcquiredID, strAcquiredDateFrom, strAcquiredDateTo)
                    arrData = objBHolding.arrData
                    arrLabel = objBHolding.arrLabel
                    'hidHave.Value = 0

                    If arrData(0) > -1 Then

                        objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 45, strImage, "WStatCopyNumberAcquiredSource.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCommonChart.OutPutStream

                        objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCommonChart.OutPutStream

                        'hidHave.Value = 1

                        BindData()
                    Else
                        Response.Redirect("WStatEmty.aspx")
                    End If
                Else
                    Session("year") = Request("xLabel")
                    Page.RegisterClientScriptBlock("TransferDataJs", "<script language='javascript'> self.location.href='WStatMonthFrame.aspx?xLabel=" & Request.QueryString("xLabel") & "';</script>")
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub BindData()
            Dim strAcquiredDateFrom As String = ""
            Dim strAcquiredDateTo As String = ""
            Dim intAcquiredID As Integer = 0       '' 0 = all
            ' Static on loan
            strAcquiredDateFrom = Trim(txtAcquiredDateFrom.Text)
            strAcquiredDateTo = Trim(txtAcquiredDateTo.Text)
            intAcquiredID = CInt(ddlAcqSource.SelectedItem.Value)
            Dim tblData As DataTable = objBHolding.StatCopyNumberAcqSourceDetail(intAcquiredID, strAcquiredDateFrom, strAcquiredDateTo)
            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                tblData.Columns.Add("STT")
                Dim intSTT As Integer = 1
                For Each row As DataRow In tblData.Rows
                    row("STT") = intSTT
                    intSTT = intSTT + 1
                Next

                Dim tblGridView As New DataTable("tblGirdView")
                ConvertTable(tblData, tblGridView)

                dtgResult.DataSource = tblGridView
                dtgResult.DataBind()
            End If
        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Source")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("Content")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("Publisher")
                tblConvert.Columns.Add("PublishYear")
                tblConvert.Columns.Add("Note")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim strSource As String = rows.Item("Source") & ""
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""

                    Dim strContent245 As String = rows.Item("Content245") & ""
                    Dim strContent100 As String = rows.Item("Content100") & ""
                    Dim strContent260 As String = rows.Item("Content260") & ""
                    Dim strNote As String = rows.Item("Note") & ""

                    Dim strTitle As String = objBCDBS.GetContent(strContent245, "$", "a")
                    Dim strAuthor As String = objBCDBS.GetContent(strContent100, "$", "a")
                    Dim strPublisher As String = objBCDBS.GetContent(strContent260, "$", "b")
                    Dim strPublishyear As String = objBCDBS.GetContent(strContent260, "$", "c")

                    strTitle = strTitle.Replace(" . . ", " . ")
                    strTitle = strTitle.Replace(" , , ", " , ")

                    Dim strSTT As String = rows.Item("STT") & ""

                    dtRow.Item("STT") = strSTT
                    dtRow.Item("Source") = strSource
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("Content") = strTitle
                    dtRow.Item("Author") = strAuthor
                    dtRow.Item("Publisher") = strPublisher
                    dtRow.Item("PublishYear") = strPublishyear
                    dtRow.Item("Note") = strNote

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        ' Event: btnCancel_Click
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            txtAcquiredDateFrom.Text = ""
            txtAcquiredDateTo.Text = ""
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
                If Not objBHolding Is Nothing Then
                    objBHolding.Dispose(True)
                    objBHolding = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Call Export()
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
            Call BindStatic()
        End Sub

        Private Sub Export()
            Try
                Dim strAcquiredDateFrom As String = ""
                Dim strAcquiredDateTo As String = ""

                ' Static on loan
                strAcquiredDateFrom = Trim(txtAcquiredDateFrom.Text)
                strAcquiredDateTo = Trim(txtAcquiredDateTo.Text)
                Dim tblData As DataTable = objBHolding.StatCopyNumberAcqSourceDetail(strAcquiredDateFrom, strAcquiredDateTo)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    tblData.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblData.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    Dim tblConvert As New DataTable("tblConvert")
                    ConvertTable(tblData, tblConvert)
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text, ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                    clsExport.StringBuilderToExcel(strHTMLContent)
                End If
            Catch ex As Exception

            End Try
        End Sub
    End Class

End Namespace
