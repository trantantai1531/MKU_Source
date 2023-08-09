' Class: WStatPatronGrp
' Puspose: Show statistic by patron group
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common
Imports Newtonsoft.Json.Linq

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatPatronGrp
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnBack As System.Web.UI.WebControls.Button
        Protected WithEvents lblHTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblVTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lbnNoname As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoname As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatronCollection As New clsBPatronCollection
        Private objBCChart As New clsBCommonChart
        Private objBPatronGroup As New clsBPatronGroup
        Private objBPatron As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            '' bind patronGroup DropDownList
            If Not IsPostBack Then
                Dim tblPatronGroup = objBPatronGroup.GetAllPatronGroup()
                If Not tblPatronGroup Is Nothing AndAlso tblPatronGroup.Rows.Count > 0 Then
                    ddlPatronGroup.DataSource = InsertOneRow(tblPatronGroup, ddlLabel.Items(8).Text)
                    ddlPatronGroup.DataTextField = "Name"
                    ddlPatronGroup.DataValueField = "ID"
                    ddlPatronGroup.DataBind()
                End If
            End If
            ''
            'Call GenChart()
            'Call BindData()

        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPatron object
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatron.Initialize()

            ' Initialize objBPatronGroup object
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()

            ' Initialize objBPatronCollection object
            objBPatronCollection.DBServer = Session("DBServer")
            objBPatronCollection.ConnectionString = Session("ConnectionString")
            objBPatronCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronCollection.initialize()

            ' Initialize objBCChart object
            objBCChart.DBServer = Session("DBServer")
            objBCChart.ConnectionString = Session("ConnectionString")
            objBCChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCChart.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(52) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: WriteFormLog
        Private Sub WriteFormLog()
            Call WriteLog(31, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatPatronGrpJs", "<script language='javascript' src='js/WStartIndex.js'></script>")
        End Sub

        ' Gen Chart method
        Private Sub GenChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            'Dim tblPatronGroup As DataTable
            ''' Bind Patron Group DropDownList
            'tblPatronGroup = objBPatronGroup.GetAllPatronGroup()
            'If Not tblPatronGroup Is Nothing AndAlso tblPatronGroup.Rows.Count > 0 Then
            '    tblPatronGroup = InsertOneRow(tblPatronGroup, ddlLabel.Items(8).Text)
            '    ddlPatronGroup.DataSource = tblPatronGroup
            '    ddlPatronGroup.DataValueField = "ID"
            '    ddlPatronGroup.DataTextField = "Name"
            '    ddlPatronGroup.DataBind()
            '    tblPatronGroup = Nothing
            'End If
            ''
            strImgURL = "..\images\bground.gif"
            objBPatronCollection.LibID = clsSession.GlbSite
            objBPatronCollection.PatronGroupStat(ddlLabel.Items(6).Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If label(0) = "NOT FOUND" Then
                lblNotFound.Visible = True
                anh1.Visible = False
                anh2.Visible = False
            Else
                objBCChart.Makebarchart(data, label, ddlLabel.Items(4).Text, ddlLabel.Items(3).Text, 45, strImgURL, "WStatPatronGrp.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, ddlLabel.Items(5).Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
            End If
            ' Write log
            Call WriteFormLog()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPatronCollection Is Nothing Then
                objBPatronCollection.Dispose(True)
                objBPatronCollection = Nothing
            End If
            If Not objBCChart Is Nothing Then
                objBCChart.Dispose(True)
                objBCChart = Nothing
            End If
        End Sub
        'Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        '    Dim tblResult As DataTable
        '    'Dim tblconvert As New DataTable("tblConvert")
        '    Dim PatronGroupID As Integer
        '    PatronGroupID = CType(ddlPatronGroup.SelectedValue, Integer)
        '    'If ddlPatronGroup.SelectedValue <> "0" Then
        '    '    hidTitleTable.Value = hidTitleTable.Value + " : " + ddlPatronGroup.SelectedItem.Text.ToUpper()
        '    'End If
        '    tblResult = objBPatron.GetPatron_byPatronGroupID(PatronGroupID)
        '    'Dim type As Integer
        '    'type = CType(ddlPatronGroup.SelectedValue, Integer)
        '    Response.ClearContent()
        '    Response.AppendHeader("content-disposition", "attachment;filename=export_" & DateTime.Now.Year.ToString() & DateTime.Now.Month.ToString() & DateTime.Now.Day.ToString() & DateTime.Now.Hour.ToString() & DateTime.Now.Minute.ToString() & DateTime.Now.Second.ToString() & DateTime.Now.Millisecond.ToString() & ".doc")
        '    Response.Charset = "UTF-8"
        '    Response.Cache.SetCacheability(HttpCacheability.NoCache)
        '    Response.ContentType = "application/msword"
        '    Response.ContentEncoding = Encoding.Unicode
        '    Response.BinaryWrite(Encoding.Unicode.GetPreamble())
        '    Dim totalCopyNumber As Integer
        '    totalCopyNumber = 0
        '    Dim totalRecord As Integer
        '    totalRecord = tblResult.Rows.Count

        '    Dim tblConvert As New DataTable("tblConvert")
        '    ConvertTable(tblResult, tblConvert, totalRecord, totalCopyNumber)
        '    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text,
        '                       ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text,
        '                       ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
        '                       ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text)

        '    Dim wordHelper As New clsBExportHelper
        '    Dim strHTMLContent As New StringBuilder()
        '    strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='www.w3.org/TR/REC-html40'>")
        '    strHTMLContent.Append("<head>")
        '    strHTMLContent.Append("<title></title>")
        '    strHTMLContent.Append("<!--[if gte mso 9]>")
        '    strHTMLContent.Append("<xml>" & clsBExportHelper.Xml_Word() & "</xml>")
        '    strHTMLContent.Append("<![endif]-->")
        '    strHTMLContent.Append("<style>" & clsBExportHelper.css_word("2cm", "1cm", "2cm", "1cm", False) & "</style>")
        '    strHTMLContent.Append("</head>")
        '    strHTMLContent.Append("<body lang=EN-US style='tab-interval:.5in'>")
        '    strHTMLContent.Append("<div class=Section1>")
        '    strHTMLContent.Append("<p>" & clsBExportHelper.GenHeader(hidLeftTable.Value, hidRightTable.Value, hidTitleTable.Value) & "</p>")
        '    '& ": " & ddlKeyword.SelectedItem.Text.ToUpper
        '    strHTMLContent.Append("<br/>")
        '    strHTMLContent.Append("<p>" & clsBExportHelper.GenFooter(hidMessageBook.Value & "<b>" & totalRecord & "</b>", hidMessageCopyNumber.Value) & "</p>")
        '    strHTMLContent.Append("<br/>")
        '    strHTMLContent.Append("<p>" & clsBExportHelper.GenDataTableToString(tblConvert) & "</p>")
        '    strHTMLContent.Append("<div id='hrdftrtbl'>")
        '    strHTMLContent.Append("<div style='mso-element:header' id=h1>" & clsBExportHelper.HeaderWord("") & "</div>")
        '    strHTMLContent.Append("<div style='mso-element:footer; text-align:right;' id=f1>" & clsBExportHelper.FooterWord("<span style='mso-tab-count:1'></span>" & "<b>" & "Trang: </b>" & "<i><span style='mso-field-code:"" PAGE ""'></span>" & " / " & "<span style='mso-field-code:"" NUMPAGES ""'></span></i>") & "</div>")
        '    strHTMLContent.Append("</div></body></html>")

        '    Response.Write(strHTMLContent)
        '    Response.End()
        '    Response.Flush()
        'End Sub
        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable, ByRef totalRecord As Double, ByRef totalCopyNumber As Double)
            tblConvert.Clear()
            tblConvert.Columns.Add("STT")
            tblConvert.Columns.Add("FullName")
            tblConvert.Columns.Add("Code")
            tblConvert.Columns.Add("DOB")
            'tblConvert.Columns.Add("Cataloguer")
            tblConvert.Columns.Add("Class")
            tblConvert.Columns.Add("Grade")
            tblConvert.Columns.Add("Faculty")
            tblConvert.Columns.Add("GroupName")

            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                totalRecord = CType(tblResult.Rows.Count, Double)
                Dim indexRows As Integer = 1
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim FullName As String = rows.Item("FullName").ToString()
                    Dim Code As String = rows.Item("Code").ToString()
                    Dim DOB As String = CDate(rows.Item("DOB")).ToString("dd/MM/yyyy")
                    Dim Classs As String = rows.Item("Class").ToString()

                    Dim Grade As String = rows.Item("Grade").ToString()
                    Dim Faculty As String = rows.Item("Faculty").ToString()
                    Dim GroupName As String = rows.Item("GroupName").ToString()

                    Dim stt As String = CType(indexRows, String)
                    indexRows = indexRows + 1

                    dtRow.Item("STT") = stt
                    dtRow.Item("FullName") = FullName
                    dtRow.Item("Code") = Code
                    dtRow.Item("DOB") = DOB
                    dtRow.Item("Class") = Classs
                    dtRow.Item("Grade") = Grade
                    dtRow.Item("Faculty") = Faculty
                    dtRow.Item("GroupName") = GroupName

                    tblConvert.Rows.Add(dtRow)
                Next
            End If

        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("FirstName")
                tblConvert.Columns.Add("LastName")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("LastIssuedDate")
                'tblConvert.Columns.Add("ValidDate")
                tblConvert.Columns.Add("ExpiredDate")
                tblConvert.Columns.Add("Class")
                tblConvert.Columns.Add("Grade")
                tblConvert.Columns.Add("Faculty")
                tblConvert.Columns.Add("College")
                tblConvert.Columns.Add("GroupName")

                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Email")
                tblConvert.Columns.Add("Address")
                tblConvert.Columns.Add("City")
                tblConvert.Columns.Add("Note")

                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("STT") & ""
                    Dim strFirstName As String = rows.Item("FirstName") & ""
                    Dim strLastName As String = rows.Item("LastName") & ""
                    Dim strPatronCode As String = rows.Item("PatronCode") & ""
                    Dim strLastIssuedDate As String = rows.Item("LastIssuedDate") & ""
                    'Dim strValidDate As String = rows.Item("ValidDate") & ""
                    Dim strExpiredDate As String = rows.Item("ExpiredDate") & ""
                    Dim strClass As String = rows.Item("Class") & ""
                    Dim strGrade As String = rows.Item("Grade") & ""
                    Dim strFaculty As String = rows.Item("Faculty") & ""
                    Dim strCollege As String = rows.Item("College") & ""
                    Dim strGroupName As String = rows.Item("GroupName") & ""

                    Dim strMobile As String = rows.Item("Mobile") & ""
                    Dim strEmail As String = rows.Item("Email") & ""
                    Dim strAddress As String = rows.Item("Address") & ""
                    Dim strCity As String = rows.Item("City") & ""
                    Dim strNote As String = rows.Item("Note") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("FirstName") = strFirstName
                    dtRow.Item("LastName") = strLastName
                    dtRow.Item("PatronCode") = strPatronCode
                    dtRow.Item("LastIssuedDate") = If(Not strLastIssuedDate = String.Empty, String.Format("{0:dd/MM/yyyy}", strLastIssuedDate).Substring(0, 10), "")
                    'dtRow.Item("ValidDate") = String.Format("{0:dd/MM/yyyy}", strValidDate).Substring(0, 10)
                    dtRow.Item("ExpiredDate") = If(Not strExpiredDate = String.Empty, String.Format("{0:dd/MM/yyyy}", strExpiredDate).Substring(0, 10), "")
                    dtRow.Item("Class") = strClass
                    dtRow.Item("Grade") = strGrade
                    dtRow.Item("Faculty") = strFaculty
                    dtRow.Item("College") = strCollege
                    dtRow.Item("GroupName") = strGroupName
                    dtRow.Item("Mobile") = strMobile
                    dtRow.Item("Email") = strEmail
                    dtRow.Item("Address") = strAddress
                    dtRow.Item("City") = strCity
                    dtRow.Item("Note") = strNote

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Private Sub ResultSearch(ByVal tblResult As DataTable, ByRef totalRecord As Double, ByRef totalCopyNumber As Double)
            Try
                Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                newColumn.DefaultValue = "1"
                tblResult.Columns.Add(newColumn)
                Dim indexRows As Integer = 1
                For Each rows As DataRow In tblResult.Rows
                    If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                        rows.Item("STT") = indexRows.ToString()
                        indexRows = indexRows + 1
                    End If
                Next

                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblResult, tblConvert, totalRecord, totalCopyNumber)

                'dtgStatis.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                'dtgStatis.DataSource = tblConvert
                'dtgStatis.DataBind()
            Catch ex As Exception

            End Try
        End Sub
        'Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        '    objBPatronCollection.LibID = clsSession.GlbSite
        '    objBPatronCollection.PatronGroupStat(ddlLabel.Items(6).Text)

        '    If Not (objBPatronCollection.ArrLabelChart(0) = "NOT FOUND") Then

        '        Dim objData() As Integer = CType(objBPatronCollection.ArrDataChart, Integer())
        '        Dim objLabel() As String = CType(objBPatronCollection.ArrLabelChart, String())
        '        Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, ddlLabel.Items(7).Text)

        '        clsExport.StringBuilderToExcel(sBuilder1)
        '    End If
        'End Sub
        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim tblData As New DataTable("tblResult")
            objBPatronCollection.PatronGroupID = ddlPatronGroup.SelectedItem.Value
            objBPatronCollection.LibID = clsSession.GlbSite
            tblData = objBPatronCollection.PatronGroupStatDetail()

            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                tblData.Columns.Add("STT")
                Dim intSTT As Integer = 1
                For Each row As DataRow In tblData.Rows
                    row("STT") = intSTT
                    intSTT = intSTT + 1
                Next
                Dim tblConvert As New DataTable("tblConvert")
                ConvertTable(tblData, tblConvert)
                tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text,
                                        ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                        ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text,
                                        ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text,
                                        ddlLabelHeaderTable.Items(12).Text, ddlLabelHeaderTable.Items(13).Text, ddlLabelHeaderTable.Items(14).Text,
                                        ddlLabelHeaderTable.Items(15).Text)

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                clsExport.StringBuilderToExcel(strHTMLContent)
            End If
        End Sub

        Protected Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
            'Call GenChart()
            '' reset GridView
            dtgResult.DataSource = Nothing
            dtgResult.DataBind()
            Call BindData()
        End Sub
        Private Sub BindData()
            Dim tblResult As New DataTable("tblResult")

            objBPatronCollection.PatronGroupID = ddlPatronGroup.SelectedItem.Value
            objBPatronCollection.LibID = clsSession.GlbSite
            tblResult = objBPatronCollection.PatronGroupStatDetail()
            lblTotal.Text = "0"
            If Not IsNothing(tblResult) Then
                If tblResult.Rows.Count > 0 Then
                    lblTotal.Text = tblResult.Rows.Count
                    tblResult.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblResult.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    dtgResult.DataSource = tblResult
                    dtgResult.DataBind()
                End If
            End If
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub
        'Protected Sub ddlPatronGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPatronGroup.SelectedIndexChanged
        '    Call BindData()
        'End Sub

    End Class
End Namespace