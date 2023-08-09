' Class: WStatDay
' Puspose: Create statistic by acqday
' Creator: Sondp
' CreatedDate: 01/04/2005
' Modification History:
'   - 13/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatDay
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
        Private objBS As New clsBStatistic
        Private objBCC As New clsBCommonChart
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                ' WriteLog
                Call WriteLog(42, ddlLog.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                If (Not IsNothing(Request.QueryString("export"))) Then
                    Export()
                End If
                Call GenChart()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all objects
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
        ' Purpose: include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatIndexJs", "<script language='javascript' src='../Js/Statistic/WStatIndex.js'></script>")
            Page.RegisterClientScriptBlock("WStatDayJs", "<script language='javascript' src='../Js/Statistic/WStatDay.js'></script>")
        End Sub

        ' Method: GenChartDirector
        ' Purpose: generate charts here
        Private Sub GenChart()
            Dim strVtitle As String
            Dim strHtitle As String
            Dim strTitle As String
            Dim strImg As String
            Dim strMonth As String
            Dim strYear As String
            Dim objData As Object
            Dim objDataNext As Object
            Dim objMoney As Object
            Dim objLabel As Object

            strImg = Server.MapPath("..\..\Images\bground.gif")
            If Request.QueryString("month") & "" = "" And Request.QueryString("year") & "" = "" Then
                If Session("month") & "" = "" Or Session("year") & "" = "" Then
                    Response.Redirect("WStatEmty.aspx")
                Else
                    strMonth = CStr(Session("month"))
                    strYear = CStr(Session("year"))
                End If
            Else
                strMonth = Request.QueryString("month")
                strYear = Request.QueryString("year")
            End If

            Try
                lblDAPHTitle.Text &= lblInMonth.Text & strMonth & lblInYear.Text & strYear
                lblDAPTitle.Text &= lblInMonth.Text & strMonth & lblInYear.Text & strYear
                lblBAPHTitle.Text &= lblInMonth.Text & strMonth & lblInYear.Text & strYear
                lblBAPTitle.Text &= lblInMonth.Text & strMonth & lblInYear.Text & strYear
                lblHMoney.Text &= lblInMonth.Text & strMonth & lblInYear.Text & strYear
                lblTMoney.Text &= lblInMonth.Text & strMonth & lblInYear.Text & strYear

                ' Call Statatistic day method
                objBS.LibID = clsSession.GlbSite
                objBS.StatDay(lblDAPTotal.Text, lblBAPTotal.Text, lblInday.Text, strMonth, strYear)
                objLabel = objBS.ArrLabelChart
                objData = objBS.ArrDataChart
                objDataNext = objBS.ArrDataChartNext
                objMoney = objBS.ArrDataMoney
                If objLabel(0) = -1 Then
                    Response.Redirect("WStatEmty.aspx")
                Else
                    ' Statistic DAP
                    strHtitle = lblDAPHTitle.Text
                    strVtitle = lblDAPVTitle.Text
                    strTitle = lblDAPTitle.Text
                    lblDAP.Text = objBS.DAP
                    objBCC.Makebarchart(objData, objLabel, strVtitle, strHtitle, 0, strImg, "WStatDay.aspx")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCC.OutPutStream
                    objBCC.Makepiechart(objData, objLabel, strTitle, strImg)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCC.OutPutStream

                    ' Statistic BAP
                    strHtitle = lblBAPHTitle.Text
                    strVtitle = lblBAPVTitle.Text
                    strTitle = lblBAPTitle.Text
                    lblBAP.Text = objBS.BAP
                    objBCC.Makebarchart(objDataNext, objLabel, strVtitle, strHtitle, 0, strImg, "WStatDay.aspx")
                    Session("chart3") = Nothing
                    Session("chart3") = objBCC.OutPutStream
                    objBCC.Makepiechart(objDataNext, objLabel, strTitle, strImg)
                    Session("chart4") = Nothing
                    Session("chart4") = objBCC.OutPutStream

                    ' Statistic total money
                    strHtitle = lblHMoney.Text
                    strVtitle = lblVMoney.Text
                    strTitle = lblTMoney.Text
                    lblMoney.Text = objBS.Money
                    objBCC.Makebarchart(objMoney, objLabel, strVtitle, strHtitle, 0, strImg, "WStatDay.aspx")
                    Session("chart5") = Nothing
                    Session("chart5") = objBCC.OutPutStream
                    objBCC.Makepiechart(objMoney, objLabel, strTitle, strImg)
                    Session("chart6") = Nothing
                    Session("chart6") = objBCC.OutPutStream

                    Call BindData()
                End If
            Catch ex As Exception ' Error occured
            End Try
        End Sub

        Private Sub BindData()
            Dim strMonth As String = ""
            Dim strYear As String = ""
            If Request.QueryString("month") & "" <> "" And Request.QueryString("year") & "" <> "" Then
                strMonth = Request.QueryString("month")
                strYear = Request.QueryString("year")
            Else
                strMonth = CStr(Session("month"))
                strYear = CStr(Session("year"))
            End If

            ' Call Statatistic day method
            objBS.LibID = clsSession.GlbSite
            Dim tblData As DataTable = objBS.StatDayDetail(strMonth, strYear)
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
                Dim strMonth As String = ""
                Dim strYear As String = ""
                If Request.QueryString("month") & "" <> "" And Request.QueryString("year") & "" <> "" Then
                    strMonth = Request.QueryString("month")
                    strYear = Request.QueryString("year")
                Else
                    strMonth = CStr(Session("month"))
                    strYear = CStr(Session("year"))
                End If

                ' Call Statatistic day method
                objBS.LibID = clsSession.GlbSite
                Dim tblData As DataTable = objBS.StatDayDetail(strMonth, strYear)

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
    End Class
End Namespace