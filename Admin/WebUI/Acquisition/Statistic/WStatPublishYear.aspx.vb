
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatPublishYear
        Inherits clsWBase
        Private objBS As New clsBStatistic
        Private objBCC As New clsBCommonChart
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                ' WriteLog
                txtYearStart.Text = If(String.IsNullOrEmpty(txtYearStart.Text), DateTime.Now.Year - 4, CType(txtYearStart.Text, Integer)).ToString()
                txtYearEnd.Text = If(String.IsNullOrEmpty(txtYearEnd.Text), DateTime.Now.Year, CType(txtYearEnd.Text, Integer)).ToString()
                Call WriteLog(42, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call GenChart()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all opbjects
        Private Sub Initialize()
            ' Initialize objBS object
            objBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBS.DBServer = Session("DBServer")
            objBS.ConnectionString = Session("ConnectionString")
            Call objBS.Initialize()

            ' Initialize objBCC object
            objBCC.InterfaceLanguage = Session("InterfaceLanguage")
            objBCC.DBServer = Session("DBServer")
            objBCC.ConnectionString = Session("ConnectionString")
            Call objBCC.Initialize()

            ' Initialize objBCC object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatIndex.js'></script>")
            Page.RegisterClientScriptBlock("WStatYearJs", "<script language='javascript' src='../Js/Statistic/WStatYear.js'></script>")

            btnClose.Attributes.Add("OnClick", "self.location.href='WStatIndex.aspx';return(false);")
        End Sub

        ' Method: GenChartDirector
        ' Purpose: generate charts here
        Private Sub GenChart()
            Dim strVtitle As String
            Dim strHtitle As String
            Dim strTitle As String
            Dim strImg As String
            strImg = Server.MapPath("..\..\Images\bground.gif")

            Try
                If Request.QueryString("xLabel") & "" = "" Then ' Statistic all years                    
                    Dim objData As Object
                    Dim objLabel As Object
                    Dim objDataNext As Object
                    Dim objDataMoney As Object
                    objBS.LibID = clsSession.GlbSite
                    objBS.StatPulishYear(lblDAPTotal.Text, lblBAPTotal.Text, lblCAPToal.Text, lblInYear.Text, If(String.IsNullOrEmpty(txtYearStart.Text), DateTime.Now.Year - 4, CType(txtYearStart.Text, Integer)), If(String.IsNullOrEmpty(txtYearEnd.Text), DateTime.Now.Year, CType(txtYearEnd.Text, Integer)))
                    objData = objBS.ArrDataChart
                    objLabel = objBS.ArrLabelChart
                    objDataNext = objBS.ArrDataChartNext
                    objDataMoney = objBS.ArrDataMoney
                    If objLabel(0) = -1 Then
                        Response.Redirect("WStatEmty.aspx")
                    Else
                        ' Statistic for DAP
                        strVtitle = ddlLabel.Items(2).Text
                        strHtitle = ddlLabel.Items(1).Text
                        strTitle = ddlLabel.Items(3).Text
                        lblDAP.Text = objBS.DAP
                        objBCC.Makebarchart(objData, objLabel, strVtitle, strHtitle, 45, strImg, "WStatPublishYear.aspx")
                        Session("chart1") = Nothing
                        Session("chart1") = objBCC.OutPutStream
                        Response.Write("<MAP NAME=""map1"">" & objBCC.OutMapImg & "</MAP>")
                        objBCC.Makepiechart(objData, objLabel, strTitle, strImg)
                        Session("chart2") = Nothing
                        Session("chart2") = objBCC.OutPutStream
                        ' Statistic for BAP
                        strVtitle = ddlLabel.Items(6).Text
                        strHtitle = ddlLabel.Items(5).Text
                        strTitle = ddlLabel.Items(7).Text
                        lblBAP.Text = objBS.BAP
                        objBCC.Makebarchart(objDataNext, objLabel, strVtitle, strHtitle, 45, strImg, "WStatPublishYear.aspx")
                        Session("chart3") = Nothing
                        Session("chart3") = objBCC.OutPutStream
                        Response.Write("<MAP NAME=""map2"">" & objBCC.OutMapImg & "</MAP>")
                        objBCC.Makepiechart(objDataNext, objLabel, strTitle, strImg)
                        Session("chart4") = Nothing
                        Session("chart4") = objBCC.OutPutStream
                        ' Statistic Total money
                        strVtitle = ddlLabel.Items(8).Text
                        strHtitle = ddlLabel.Items(9).Text
                        strTitle = ddlLabel.Items(10).Text
                        lblMoney.Text = objBS.Money
                        objBCC.Makebarchart(objDataMoney, objLabel, strVtitle, strHtitle, 45, strImg, "WStatPublishYear.aspx")
                        Session("chart5") = Nothing
                        Session("chart5") = objBCC.OutPutStream
                        Response.Write("<MAP NAME=""map3"">" & objBCC.OutMapImg & "</MAP>")
                        objBCC.Makepiechart(objDataMoney, objLabel, strTitle, strImg)
                        Session("chart6") = Nothing
                        Session("chart6") = objBCC.OutPutStream

                        Call BindData()
                    End If
                Else ' Staitistic year dependon xLabel (selected year)
                    Session("year") = Request("xLabel")
                    Page.RegisterClientScriptBlock("TransferDataJs", "<script language='javascript'> self.location.href='WStatMonthFrame.aspx?xLabel=" & Request.QueryString("xLabel") & "';</script>")
                End If
            Catch ex As Exception ' error occured
            End Try
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBS Is Nothing Then
                objBS.Dispose(True)
                objBS = Nothing
            End If
            If Not objBCC Is Nothing Then
                objBCC.Dispose(True)
                objBCC = Nothing
            End If
        End Sub

        Protected Sub btnExportData_Click(sender As Object, e As EventArgs) Handles btnExportData.Click
            GenChart()
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Call Export()
        End Sub

        Private Sub BindData()
            Dim intYearStart As Integer = If(String.IsNullOrEmpty(txtYearStart.Text), DateTime.Now.Year - 4, CType(txtYearStart.Text, Integer))
            Dim intYearEnd As Integer = If(String.IsNullOrEmpty(txtYearEnd.Text), DateTime.Now.Year, CType(txtYearEnd.Text, Integer))
            ' Call Statatistic day method
            objBS.LibID = clsSession.GlbSite
            Dim tblData As DataTable = objBS.GetItemPulishYearDetail(intYearStart, intYearEnd)
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
                tblConvert.Columns.Add("Content")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("Publisher")
                tblConvert.Columns.Add("PublishYear")
                tblConvert.Columns.Add("Times")
                tblConvert.Columns.Add("Count")
                tblConvert.Columns.Add("Total")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim strContent245 As String = rows.Item("Content245") & ""
                    Dim strContent100 As String = rows.Item("Content100") & ""
                    Dim strContent260 As String = rows.Item("Content260") & ""
                    Dim strTime As String = rows.Item("Times") & ""
                    Dim strCount As String = rows.Item("Count") & ""
                    Dim strTotal As String = rows.Item("Total") & ""

                    Dim strTitle As String = objBCDBS.GetContent(strContent245, "$", "a")
                    Dim strAuthor As String = objBCDBS.GetContent(strContent100, "$", "a")
                    Dim strPublisher As String = objBCDBS.GetContent(strContent260, "$", "b")
                    Dim strPublishyear As String = objBCDBS.GetContent(strContent260, "$", "c")
                    If CInt(strTotal) = 0 Or String.IsNullOrEmpty(strTotal) Then
                        strTotal = "0"
                    Else
                        strTotal = String.Format("{0:0,0}", CInt(strTotal))
                    End If

                    strTitle = strTitle.Replace(" . . ", " . ")
                    strTitle = strTitle.Replace(" , , ", " , ")

                    Dim strSTT As String = rows.Item("STT") & ""

                    dtRow.Item("STT") = strSTT
                    dtRow.Item("Content") = strTitle
                    dtRow.Item("Author") = strAuthor
                    dtRow.Item("Publisher") = strPublisher
                    dtRow.Item("PublishYear") = strPublishyear
                    dtRow.Item("Times") = strTime
                    dtRow.Item("Count") = strCount
                    dtRow.Item("Total") = strTotal

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Private Sub Export()
            Try
                Dim intYearStart As Integer = If(String.IsNullOrEmpty(txtYearStart.Text), DateTime.Now.Year - 4, CType(txtYearStart.Text, Integer))
                Dim intYearEnd As Integer = If(String.IsNullOrEmpty(txtYearEnd.Text), DateTime.Now.Year, CType(txtYearEnd.Text, Integer))
                ' Call Statatistic day method
                objBS.LibID = clsSession.GlbSite
                Dim tblData As DataTable = objBS.GetItemPulishYearDetail(intYearStart, intYearEnd)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    tblData.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblData.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next

                    Dim tblExport As New DataTable("tblExport")
                    ConvertTable(tblData, tblExport)

                    tblExport.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text, ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblExport))

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
