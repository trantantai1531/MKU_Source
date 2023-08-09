Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatCataloguerTimes
        Inherits clsWBase
        Private objBHolding As New clsBHolding
        Private objBCDBS As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then

            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBHolding.ConnectionString = Session("ConnectionString")
            objBHolding.DBServer = Session("DBServer")
            objBHolding.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBHolding.Initialize()

            ' Initialize objBCC object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        Private Sub BindJS()

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            '
            txtDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtDateFrom.ToolTip = Session("DateFormat")
            txtDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(6).Text & " (" & Session("DateFormat") & ")');")
            txtDateTo.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabel.Items(6).Text)

        End Sub

        Private Sub BindData()
            Dim strDateFrom As String = ""
            Dim strDateTo As String = ""

            ' Static on loan
            strDateFrom = Trim(txtDateFrom.Text)
            strDateTo = Trim(txtDateTo.Text)

            If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom + " 00:00:00")
            If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo + " 23:59:59")

            Dim tblData As DataTable = objBHolding.StatCopyNumberCatalogerDetail(strDateFrom, strDateTo)
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
                tblConvert.Columns.Add("DateCreate")
                tblConvert.Columns.Add("NameCreate")
                tblConvert.Columns.Add("LoanType")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("Barcode")
                tblConvert.Columns.Add("Content")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("PublishPlace")
                tblConvert.Columns.Add("Publisher")
                tblConvert.Columns.Add("PublishYear")
                tblConvert.Columns.Add("ClassifyIndex")
                tblConvert.Columns.Add("Majors")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim strContent245 As String = rows.Item("Content245") & ""
                    Dim strContent100 As String = rows.Item("Content100") & ""
                    Dim strContent260 As String = rows.Item("Content260") & ""
                    Dim strContent082 As String = rows.Item("Content082") & ""
                    Dim strContent691 As String = rows.Item("Content691") & ""
                    Dim strDateCreate As String = rows.Item("DateCreate") & ""
                    Dim strNameCreate As String = rows.Item("NameCreate") & ""
                    Dim strLoanType As String = rows.Item("LoanType") & ""
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""
                    Dim strBarcode As String = rows.Item("Barcode") & ""

                    Dim strTitle As String = objBCDBS.GetContent(strContent245, "$", "a")
                    Dim strAuthor As String = objBCDBS.GetContent(strContent100, "$", "a")
                    Dim strPublisher As String = objBCDBS.GetContent(strContent260, "$", "b")
                    Dim strPublishyear As String = objBCDBS.GetContent(strContent260, "$", "c")
                    Dim strPublishPlace As String = objBCDBS.GetContent(strContent260, "$", "a")
                    Dim strClassifyIndex As String = objBCDBS.GetContent(strContent082, "$", "a")
                    Dim strMajors As String = objBCDBS.GetContent(strContent691, "$", "a")

                    strTitle = strTitle.Replace(" . . ", " . ")
                    strTitle = strTitle.Replace(" , , ", " , ")

                    strDateCreate = String.Format("{0:dd/MM/yyyy}", strDateCreate)

                    Dim strSTT As String = rows.Item("STT") & ""

                    dtRow.Item("STT") = strSTT
                    dtRow.Item("DateCreate") = strDateCreate
                    dtRow.Item("NameCreate") = strNameCreate
                    dtRow.Item("LoanType") = strLoanType
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("Barcode") = strBarcode
                    dtRow.Item("Content") = strTitle
                    dtRow.Item("Author") = strAuthor
                    dtRow.Item("PublishPlace") = strPublishPlace
                    dtRow.Item("Publisher") = strPublisher
                    dtRow.Item("PublishYear") = strPublishyear
                    dtRow.Item("ClassifyIndex") = strClassifyIndex
                    dtRow.Item("Majors") = strMajors

                    tblConvert.Rows.Add(dtRow)
                Next
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
            Call BindData()
        End Sub

        Private Sub Export()
            Try
                Dim strDateFrom As String = ""
                Dim strDateTo As String = ""

                ' Static on loan
                strDateFrom = Trim(txtDateFrom.Text)
                strDateTo = Trim(txtDateTo.Text)

                If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom + " 00:00:00")
                If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo + " 23:59:59")

                Dim tblData As DataTable = objBHolding.StatCopyNumberCatalogerDetail(strDateFrom, strDateTo)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    tblData.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblData.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    Dim tblConvert As New DataTable("tblConvert")
                    ConvertTable(tblData, tblConvert)
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                        ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text, ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text,
                                        ddlLabelHeaderTable.Items(12).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                    clsExport.StringBuilderToExcel(strHTMLContent)
                End If
            Catch ex As Exception

            End Try
        End Sub

    End Class
End Namespace

