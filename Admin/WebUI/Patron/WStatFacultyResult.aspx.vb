' Class: WStatFacultyResult
' Puspose: Show statistic by faculty
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatFacultyResult
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents lblNoname As System.Web.UI.WebControls.Label
        Protected WithEvents lblHTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblVTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatronCollection As New clsBPatronCollection
        Private objBCChart As New clsBCommonChart

        Private objBCollege As New clsBCollege
        Private objBGroup As New clsBPatronGroup
        Private objBFaculty As New clsBFaculty
        Private objBPatron As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If (Page.IsPostBack = False) Then
                txtYearFrom.Text = ""
                txtYearTo.Text = ""
                Call BindDLL()
                'Call BindData()
                'Call GenChart()
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBPatron object
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatron.Initialize()
            ' Initialize objBFaculty object
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.ConnectionString = Session("ConnectionString")
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBFaculty.Initialize()

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


            ' Initialize object objBCollege
            objBCollege.DBServer = Session("DBServer")
            objBCollege.ConnectionString = Session("ConnectionString")
            objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCollege.Initialize()

            ' Initialize object objBGroup
            objBGroup.DBServer = Session("DBServer")
            objBGroup.ConnectionString = Session("ConnectionString")
            objBGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBGroup.Initialize()
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

        Private Sub BindDLL()
            'Dim tblCollege As New DataTable

            'tblCollege = objBCollege.GetCollege
            Dim tblFaculty As New DataTable
            Dim tblGroupPatron As New DataTable
            'objBGroup.LibID = clsSession.GlbSite
            tblGroupPatron = objBGroup.GetPatronGroup()

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCollege.ErrorMsg, ddlLabel.Items(0).Text, objBCollege.ErrorCode)

            'If Not tblCollege Is Nothing Then
            '    If tblCollege.Rows.Count > 0 Then
            '        ddlCollege.DataSource = tblCollege
            '        ddlCollege.DataTextField = "College"
            '        ddlCollege.DataValueField = "ID"
            '        ddlCollege.DataBind()
            '    End If
            'End If

            ddlGroupPatron.Items.Clear()
            ddlGroupPatron.Items.Add(New ListItem(ddlLabel.Items(9).Text, "0"))

            If Not tblGroupPatron Is Nothing Then
                If tblGroupPatron.Rows.Count > 0 Then
                    For Each groupPatron As DataRow In tblGroupPatron.Rows
                        ddlGroupPatron.Items.Add(New ListItem(groupPatron.Item("Name"), groupPatron.Item("ID")))
                    Next
                    ddlGroupPatron.DataBind()
                End If
            End If

            tblFaculty = objBFaculty.GetFaculty()
            If Not tblFaculty Is Nothing Then
                If tblFaculty.Rows.Count > 0 Then
                    tblFaculty = InsertOneRow(tblFaculty, ddlLabel.Items(9).Text)
                    ddlFaculty.DataSource = tblFaculty
                    ddlFaculty.DataTextField = "Faculty"
                    ddlFaculty.DataValueField = "ID"
                    ddlFaculty.DataBind()
                End If
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatFacultyResultJs", "<script language='javascript' src='js/WStartIndex.js'></script>")
        End Sub

        ' Method: GenChart
        'Private Sub GenChart()
        '    Dim strImgURL As String
        '    Dim data As Object
        '    Dim label As Object

        '    Dim intYearFrom As Integer = 0
        '    Dim intYearTo As Integer = 0
        '    If (Not IsNothing(txtYearFrom.Text)) Then
        '        Try
        '            intYearFrom = Integer.Parse(txtYearFrom.Text)
        '        Catch ex As Exception
        '            intYearFrom = 0
        '        End Try
        '    End If
        '    If (Not IsNothing(txtYearTo.Text)) Then
        '        Try
        '            intYearTo = Integer.Parse(txtYearTo.Text)
        '        Catch ex As Exception
        '            intYearTo = 0
        '        End Try
        '    End If

        '    strImgURL = "../Images/bground.gif"
        '    lblNotFound.Visible = False

        '    objBPatronCollection.LibID = clsSession.GlbSite
        '    'objBPatronCollection.FacultyStat(ddlLabel.Items(6).Text, Request("ID"))
        '    objBPatronCollection.FacultyStat(ddlLabel.Items(6).Text, CType(ddlFaculty.SelectedItem.Value, Integer), CType(ddlGroupPatron.SelectedItem.Value, Integer), intYearFrom, intYearTo)

        '    'objBPatronCollection.FacultyStat(ddlLabel.Items(6).Text, Request("ID"), intYearFrom, intYearTo)
        '    ' Write error
        '    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

        '    data = objBPatronCollection.ArrDataChart
        '    label = objBPatronCollection.ArrLabelChart
        '    If UCase(label(0)) = "NOT FOUND" Then
        '        lblNotFound.Visible = True
        '        anh1.Visible = False
        '        anh2.Visible = False
        '        dtgResult.DataSource = Nothing
        '        dtgResult.DataBind()
        '    Else
        '        objBCChart.Makebarchart(data, label, ddlLabel.Items(4).Text, ddlLabel.Items(3).Text, 45, strImgURL, "WStatisticFaculty.aspx")
        '        Session("chart1") = Nothing
        '        Session("chart1") = objBCChart.OutPutStream
        '        objBCChart.Makepiechart(data, label, ddlLabel.Items(5).Text, strImgURL)
        '        Session("char2") = Nothing
        '        Session("chart2") = objBCChart.OutPutStream
        '        Call BindData()
        '    End If
        '    ' Write log
        '    Call WriteFormLog()
        'End Sub

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

        Protected Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
            'Call GenChart()
            Call BindData()
        End Sub

        'Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        '    Dim intYearFrom As Integer = 0
        '    Dim intYearTo As Integer = 0
        '    Dim intFacultyID As Integer
        '    Dim intPatronGroupID As Integer
        '    Dim tblResult As DataTable

        '    intPatronGroupID = CType(ddlGroupPatron.SelectedValue, Integer)
        '    intFacultyID = CType(ddlFaculty.SelectedValue, Integer)
        '    If (Not IsNothing(txtYearFrom.Text)) Then
        '        Try
        '            intYearFrom = Integer.Parse(txtYearFrom.Text)
        '        Catch ex As Exception
        '            intYearFrom = 0
        '        End Try
        '    End If
        '    If (Not IsNothing(txtYearTo.Text)) Then
        '        Try
        '            intYearTo = Integer.Parse(txtYearTo.Text)
        '        Catch ex As Exception
        '            intYearTo = 0
        '        End Try
        '    End If


        '    tblResult = objBPatron.GetPatron_byOrder(intFacultyID, intPatronGroupID, intYearFrom, intYearTo)
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
        '                        ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text,
        '                        ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
        '                        ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text)
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
        '    'objBPatronCollection.LibID = clsSession.GlbSite
        '    'objBPatronCollection.FacultyStat(ddlLabel.Items(6).Text, Request("ID"), ddlGroupPatron.SelectedItem.Value, intYearFrom, intYearTo)

        '    'If Not (objBPatronCollection.ArrLabelChart(0) = "NOT FOUND") Then

        '    '    Dim objData() As Integer = CType(objBPatronCollection.ArrDataChart, Integer())
        '    '    Dim objLabel() As String = CType(objBPatronCollection.ArrLabelChart, String())
        '    '    Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, ddlLabel.Items(7).Text)

        '    '    clsExport.StringBuilderToExcel(sBuilder1)
        '    'End If

        '    'Data = objBPatronCollection.ArrDataChart
        '    'Label = objBPatronCollection.ArrLabelChart
        '    'If Label(0) = "NOT FOUND" Then
        '    '    lblNotFound.Visible = True
        '    '    anh1.Visible = False
        '    '    anh2.Visible = False
        '    'Else
        '    '    objBCChart.Makebarchart(Data, Label, ddlLabel.Items(4).Text, ddlLabel.Items(3).Text, 45, strImgURL, "WStatisticFaculty.aspx")
        '    '    Session("chart1") = Nothing
        '    '    Session("chart1") = objBCChart.OutPutStream
        '    '    objBCChart.Makepiechart(Data, Label, ddlLabel.Items(5).Text, strImgURL)
        '    '    Session("char2") = Nothing
        '    '    Session("chart2") = objBCChart.OutPutStream
        '    'End If
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

        Private Sub BindData()
            Dim tblResult As New DataTable("tblResult")

            Dim intCollegeID As Integer = CType(ddlFaculty.SelectedItem.Value, Integer)
            Dim intGroupPatronID As Integer = CType(ddlGroupPatron.SelectedItem.Value, Integer)
            Dim intYearFrom As Integer = 0
            Dim intYearTo As Integer = 0
            If (Not IsNothing(txtYearFrom.Text)) Then
                Try
                    intYearFrom = Integer.Parse(txtYearFrom.Text)
                Catch ex As Exception
                    intYearFrom = 0
                End Try
            End If
            If (Not IsNothing(txtYearTo.Text)) Then
                Try
                    intYearTo = Integer.Parse(txtYearTo.Text)
                Catch ex As Exception
                    intYearTo = 0
                End Try
            End If

            objBPatronCollection.LibID = clsSession.GlbSite
            tblResult = objBPatronCollection.FacultyStatDetail(intCollegeID, intGroupPatronID, intYearFrom, intYearTo)
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
                Else
                    dtgResult.DataSource = Nothing
                    dtgResult.DataBind()
                End If
            Else
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            End If
        End Sub
        Protected Sub dtgResult_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResult.PageIndexChanging
            dtgResult.PageIndex = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim intYearFrom As Integer = 0
            Dim intYearTo As Integer = 0
            If (Not IsNothing(txtYearFrom.Text)) Then
                Try
                    intYearFrom = Integer.Parse(txtYearFrom.Text)
                Catch ex As Exception
                    intYearFrom = 0
                End Try
            End If
            If (Not IsNothing(txtYearTo.Text)) Then
                Try
                    intYearTo = Integer.Parse(txtYearTo.Text)
                Catch ex As Exception
                    intYearTo = 0
                End Try
            End If

            Dim tblData As New DataTable("tblResult")
            Dim intCollegeID As Integer = CType(ddlFaculty.SelectedItem.Value, Integer)
            Dim intGroupPatronID As Integer = CType(ddlGroupPatron.SelectedItem.Value, Integer)

            objBPatronCollection.LibID = clsSession.GlbSite
            tblData = objBPatronCollection.FacultyStatDetail(intCollegeID, intGroupPatronID, intYearFrom, intYearTo)

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
    End Class
End Namespace