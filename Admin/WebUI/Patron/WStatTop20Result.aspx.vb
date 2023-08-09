' Class: WStatTop20Result
' Puspose: Show statistic by top 20 entries
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 02/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatTop20Result
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
        Private objBCChart As New clsBCommonChart
        Private objBPatronCollection As New clsBPatronCollection

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Page.IsPostBack = False Then
                Call SelectStatistic()
            End If
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
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
        Private Sub WriteFormLog(ByVal intddlLabelValue As Integer)
            Call WriteLog(31, ddlLabel.Items(intddlLabelValue).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WStatTop20ResultJs", "<script language='javascript' src='js/WStartIndex.js'></script>")
        End Sub

        ' Select Statistic method
        Private Sub SelectStatistic()
            Select Case CInt(Request.QueryString("sign"))
                Case 1 ' Patron Group
                    Call GenPatronGroupChart()
                Case 2 ' School
                    Call GenSchoolChart()
                Case 3 ' Faculty
                    Call GenFacultyChart()
                Case 4 ' Grade
                    Call GenGradeChart()
                Case 5 ' Class
                    Call GenClassChart()
                Case 6 ' Ethnic
                    Call GenEthnicChart()
                Case 7 ' Education Level
                    Call GenEducationLevelChart()
                Case 8 ' Occupation
                    Call GenOccupationChart()
                Case Else
                    lblNotFound.Visible = True
                    chart1.Visible = False
                    chart2.Visible = False
            End Select
        End Sub

        ' GenPatronGroupChart method
        Private Sub GenPatronGroupChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.LibID = clsSession.GlbSite
            objBPatronCollection.Top20Stat("PATRONGROUP", lblNoname.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblPGVTitle.Text, lblPGHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblPGTitle.Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Call BindData(1)
            End If
            ' Write log
            Call WriteFormLog(4)
        End Sub

        ' GenSchoolChart method
        Private Sub GenSchoolChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.Top20Stat("SCHOOL", lblNoname.Text)

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblSVTitle.Text, lblSHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblSTitle.Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Call BindData(2)
            End If
            ' Write log
            Call WriteFormLog(5)
        End Sub

        ' GenFacultyChart method
        Private Sub GenFacultyChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.Top20Stat("FACULTY", lblNoname.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblFVTitle.Text, lblFHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblFTitle.Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Session("strIndex") = Nothing
                Call BindData(3)
            End If
            ' Write log
            Call WriteFormLog(6)
        End Sub

        ' GenGradeChart method
        Private Sub GenGradeChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.Top20Stat("GRADE", lblNoname.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblGVTitle.Text, lblGHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblGTitle.Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Call BindData(4)
            End If
            ' Write log
            Call WriteFormLog(7)
        End Sub

        ' GenClassChart method
        Private Sub GenClassChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.Top20Stat("CLASS", lblNoname.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblCVTitle.Text, lblCHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblCTitle.Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Session("strIndex") = Nothing
                Call BindData(5)
            End If
            ' Write log
            Call WriteFormLog(8)
        End Sub

        ' GenEthnicChart method
        Private Sub GenEthnicChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.Top20Stat("ETHNIC", lblNoname.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblEVTitle.Text, lblEHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblETitle.Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Call BindData(6)
            End If
            ' Write log
            Call WriteFormLog(9)
        End Sub

        ' GenEducationLevelChart method
        Private Sub GenEducationLevelChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.Top20Stat("EDUCATIONLEVEL", lblNoname.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblELVTitle.Text, lblELHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblELTitle.Text, strImgURL)
                Session("char2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Session("strIndex") = Nothing
                Call BindData(7)
            End If
            ' Write log
            Call WriteFormLog(10)
        End Sub

        ' GenOccupationChart method
        Private Sub GenOccupationChart()
            Dim strImgURL As String
            Dim data As Object
            Dim label As Object
            strImgURL = "..\Images\bground.gif"
            objBPatronCollection.Top20Stat("OCCUPATION", lblNoname.Text)
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPatronCollection.ErrorMsg, ddlLabel.Items(1).Text, objBPatronCollection.ErrorCode)

            data = objBPatronCollection.ArrDataChart
            label = objBPatronCollection.ArrLabelChart
            If UCase(label(0)) = "NOT FOUND" Then
                lblNotFound.Visible = True
                chart1.Visible = False
                chart2.Visible = False
                dtgResult.DataSource = Nothing
                dtgResult.DataBind()
            Else
                objBCChart.Makebarchart(data, label, lblOVTitle.Text, lblOHTitle.Text, 45, strImgURL, "WStatTop20Result.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCChart.OutPutStream
                objBCChart.Makepiechart(data, label, lblOTitle.Text, strImgURL)
                Session("chart2") = Nothing
                Session("chart2") = objBCChart.OutPutStream
                Call BindData(8)
            End If
            ' Write log
            Call WriteFormLog(11)
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

        Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Response.Redirect("WStatTop20.aspx")
        End Sub

        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("FullName")
                tblConvert.Columns.Add("PatronCode")
                tblConvert.Columns.Add("Birthday")
                tblConvert.Columns.Add("YEARS")
                tblConvert.Columns.Add("Email")
                tblConvert.Columns.Add("Mobile")
                tblConvert.Columns.Add("Class")
                tblConvert.Columns.Add("Grade")
                tblConvert.Columns.Add("Faculty")
                tblConvert.Columns.Add("GroupName")
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()
                    Dim stt As String = rows.Item("STT") & ""
                    Dim strFullName As String = rows.Item("FullName") & ""
                    Dim strPatronCode As String = rows.Item("PatronCode") & ""
                    Dim strBirthday As String = rows.Item("Birthday") & ""
                    Dim strYears As String = rows.Item("YEARS") & ""
                    Dim strEmail As String = rows.Item("Email") & ""
                    Dim strMobile As String = rows.Item("Mobile") & ""
                    Dim strClass As String = rows.Item("Class") & ""
                    Dim strGrade As String = rows.Item("Grade") & ""
                    Dim strFaculty As String = rows.Item("Faculty") & ""
                    Dim strGroupName As String = rows.Item("GroupName") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("FullName") = strFullName
                    dtRow.Item("PatronCode") = strPatronCode
                    dtRow.Item("Birthday") = String.Format("{0:dd/MM/yyyy}", strBirthday)
                    dtRow.Item("YEARS") = strYears
                    dtRow.Item("Email") = strEmail
                    dtRow.Item("Mobile") = strMobile
                    dtRow.Item("Class") = strClass
                    dtRow.Item("Grade") = strGrade
                    dtRow.Item("Faculty") = strFaculty
                    dtRow.Item("GroupName") = strGroupName

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub

        Private Sub BindData(ByVal intSign As Integer)
            Dim tblResult As New DataTable("tblResult")

            Dim strTypeStatis As String = ""

            Select Case intSign
                Case 1 ' Patron Group
                    strTypeStatis = "PATRONGROUP"
                Case 2 ' School
                    strTypeStatis = "SCHOOL"
                Case 3 ' Faculty
                    strTypeStatis = "FACULTY"
                Case 4 ' Grade
                    strTypeStatis = "GRADE"
                Case 5 ' Class
                    strTypeStatis = "CLASS"
                Case 6 ' Ethnic
                    strTypeStatis = "ETHNIC"
                Case 7 ' Education Level
                    strTypeStatis = "EDUCATIONLEVEL"
                Case 8 ' Occupation
                    strTypeStatis = "OCCUPATION"
                Case Else
                    strTypeStatis = ""
            End Select

            objBPatronCollection.LibID = clsSession.GlbSite
            tblResult = objBPatronCollection.Top20StatDetail(strTypeStatis)

            If Not IsNothing(tblResult) Then
                If tblResult.Rows.Count > 0 Then
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
            Dim intSign As Integer = CInt(Request.QueryString("sign"))
            BindData(intSign)
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

            If Not Request.QueryString("Year") & "" = "" Then

                Dim tblData As New DataTable("tblResult")

                Dim strTypeStatis As String = ""
                Dim intSign As Integer = CInt(Request.QueryString("sign"))

                Select Case intSign
                    Case 1 ' Patron Group
                        strTypeStatis = "PATRONGROUP"
                    Case 2 ' School
                        strTypeStatis = "SCHOOL"
                    Case 3 ' Faculty
                        strTypeStatis = "FACULTY"
                    Case 4 ' Grade
                        strTypeStatis = "GRADE"
                    Case 5 ' Class
                        strTypeStatis = "CLASS"
                    Case 6 ' Ethnic
                        strTypeStatis = "ETHNIC"
                    Case 7 ' Education Level
                        strTypeStatis = "EDUCATIONLEVEL"
                    Case 8 ' Occupation
                        strTypeStatis = "OCCUPATION"
                    Case Else
                        strTypeStatis = ""
                End Select

                objBPatronCollection.LibID = clsSession.GlbSite
                tblData = objBPatronCollection.Top20StatDetail(strTypeStatis)

                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then

                    tblData.Columns.Add("STT")
                    Dim intSTT As Integer = 1
                    For Each row As DataRow In tblData.Rows
                        row("STT") = intSTT
                        intSTT = intSTT + 1
                    Next
                    Dim tblConvert As New DataTable("tblConvert")
                    ConvertTable(tblData, tblConvert)
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text, ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text, ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text)

                    Dim strHTMLContent As New StringBuilder()
                    strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblConvert))

                    clsExport.StringBuilderToExcel(strHTMLContent)
                End If
            End If
        End Sub

        'Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        '    Call SelectStatistic()

        '    Dim intIndex As Integer = 0

        '    Select Case CInt(Request.QueryString("sign"))
        '        Case 1 ' Patron Group
        '            intIndex = 0
        '        Case 2 ' School
        '            intIndex = 1
        '        Case 3 ' Faculty
        '            intIndex = 2
        '        Case 4 ' Grade
        '            intIndex = 3
        '        Case 5 ' Class
        '            intIndex = 4
        '        Case 6 ' Ethnic
        '            intIndex = 5
        '        Case 7 ' Education Level
        '            intIndex = 6
        '        Case 8 ' Occupation
        '            intIndex = 7
        '        Case Else
        '            intIndex = 0
        '    End Select

        '    If Not (objBPatronCollection.ArrLabelChart(0) = "NOT FOUND") Then

        '        Dim objData() As Integer = CType(objBPatronCollection.ArrDataChart, Integer())
        '        Dim objLabel() As String = CType(objBPatronCollection.ArrLabelChart, String())
        '        Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(objLabel, objData, ddlLabelTop20.Items(intIndex).Text)

        '        clsExport.StringBuilderToExcel(sBuilder1)
        '    End If
        'End Sub
    End Class
End Namespace