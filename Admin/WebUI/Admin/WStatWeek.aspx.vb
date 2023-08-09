' Class: WStatWeek
' Puspose: Show weekly statistic
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:
'   + 25/11/2004 by Tuanhv: Add 3 method for stattistic purpose
'       + Sub GetDataLogDetailPileColumn()
'       + Sub GetDataLogDetailManyColumn()
'       + Sub GetDataLogDetail()
'   + 02/12/2004 by Oanhtn: Review & modify 3 above methods

Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WStatWeek
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

        Private objBLog As New clsBLog
        Private objBCommonChart As New clsBCommonChart
        Dim dtFirstDate As Date

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()

            If Not Page.IsPostBack Then
                Call GetDataLogDetailPileColumn() 'default Statistic follow log day in week, Select type Statistic follow PileColumn 
            End If
        End Sub

        ' ShowStat method
        Private Sub ShowStat()
            If ddlTypeMap.SelectedValue = 0 Then 'Statistic follow log day in week, Select type Statistic follow PileColumn 
                GetDataLogDetailPileColumn()
            ElseIf ddlTypeMap.SelectedValue = 1 Then 'Statistic follow log day in week, Select type Statistic follow many Column 
                GetDataLogDetailManyColumn()
            ElseIf ddlTypeMap.SelectedValue = 2 Then 'Statistic follow log day in week 
                GetDataLogDetail()
            End If
        End Sub

        ' GetDataLogDetailPileColumn method
        ' Purpsose: Create statistic log day in week in PileColumn mode
        Sub GetDataLogDetailPileColumn()
            Dim inti As Integer
            Dim strDateTo As String
            Dim strDateFrom As String
            Dim objSort As Object
            Dim objLegend As Object
            Dim objData As Object
            Dim strPicturePath As String = Server.MapPath("../Images/bground.gif")
            Dim objLabels As Object
            Dim dtFromDate As Date
            Dim dtToDate As Date
            Dim strDateFromvie As String
            Dim strDateTovie As String
            Dim strTitle As String
            Dim strScale As String
            Dim dtBase_date As Date

            ReDim objLabels(ddlDay.Items.Count - 1)
            For inti = LBound(objLabels) To UBound(objLabels)
                objLabels(inti) = ddlDay.Items(inti).Text
            Next

            ' Get information about date changer
            If hidDate.Value = "" Then
                dtBase_date = System.DateTime.Now
            Else
                dtBase_date = CDate(hidDate.Value)
                dtBase_date = DateSerial(Year(dtBase_date), Month(dtBase_date), Day(dtBase_date))
            End If

            ' Calculate first day, last day of the current week
            dtFromDate = dtBase_date.AddDays(2 - Weekday(dtBase_date))
            dtToDate = dtBase_date.AddDays(8 - Weekday(dtBase_date))
            strDateFrom = CStr(Month(dtFromDate) & "/" & Day(dtFromDate) & "/" & Year(dtFromDate) & " " & "00:00:00")
            strDateFromvie = CStr(Day(dtFromDate) & "/" & Month(dtFromDate) & "/" & Year(dtFromDate))
            strDateTo = CStr(Month(dtToDate) & "/" & Day(dtToDate) & "/" & Year(dtToDate) & " " & "23:59:59")
            strDateTovie = CStr(Day(dtToDate) & "/" & Month(dtToDate) & "/" & Year(dtToDate))

            ' Resever FirstDate
            hidDate.Value = CStr(dtFromDate)

            ' Get data
            Call objBLog.StatWeekly(strDateFrom, strDateTo, objLegend, objData)
            strTitle = ddlLabel.Items(2).Text & strDateFromvie & ddlLabel.Items(3).Text & strDateTovie
            strScale = ddlLabel.Items(4).Text

            ' Show statistic
            Call objBCommonChart.StackBarChart(760, 350, objData, objLabels, objLegend, strTitle, strScale, strPicturePath, 1)
            Session("chart1") = Nothing
            Session("chart1") = objBCommonChart.OutPutStream
        End Sub

        ' GetDataLogDetailManyColumn method
        ' Purpsose: Create statistic log day in week in multiple column mode
        Sub GetDataLogDetailManyColumn()
            Dim inti As Integer
            Dim strDateTo As String
            Dim strDateFrom As String
            Dim objSort As Object
            Dim objLegend As Object
            Dim objData As Object
            Dim strPicturePath As String = Server.MapPath("../Images/bground.gif")
            Dim objLabels As Object
            Dim dtFromDate As Date
            Dim dtToDate As Date
            Dim strDateFromvie As String
            Dim strDateTovie As String
            Dim strTitle As String
            Dim strScale As String
            Dim dtBase_date As Date

            ReDim objLabels(ddlDay.Items.Count - 1)
            For inti = 0 To UBound(objLabels)
                objLabels(inti) = ddlDay.Items(inti).Text
            Next

            ' Get information about date changer
            If hidDate.Value = "" Then
                dtBase_date = System.DateTime.Now
            Else
                dtBase_date = CDate(hidDate.Value)
                dtBase_date = DateSerial(Year(dtBase_date), Month(dtBase_date), Day(dtBase_date))
            End If

            ' Calculate first day, last day of the current week
            dtFromDate = dtBase_date.AddDays(2 - Weekday(dtBase_date))
            dtToDate = dtBase_date.AddDays(8 - Weekday(dtBase_date))
            strDateFrom = CStr(Month(dtFromDate) & "/" & Day(dtFromDate) & "/" & Year(dtFromDate) & " " & "00:00:00")
            strDateFromvie = CStr(Day(dtFromDate) & "/" & Month(dtFromDate) & "/" & Year(dtFromDate))
            strDateTo = CStr(Month(dtToDate) & "/" & Day(dtToDate) & "/" & Year(dtToDate) & " " & "23:59:59")
            strDateTovie = CStr(Day(dtToDate) & "/" & Month(dtToDate) & "/" & Year(dtToDate))

            ' Resever FirstDate
            hidDate.Value = CStr(dtFromDate)

            ' Get data
            Call objBLog.StatWeekly(strDateFrom, strDateTo, objLegend, objData)
            strTitle = ddlLabel.Items(2).Text & strDateFromvie & ddlLabel.Items(3).Text & strDateTovie
            strScale = ddlLabel.Items(4).Text

            ' Show statistic
            Call objBCommonChart.MultiBarChart(760, 400, objData, objLabels, objLegend, strTitle, strScale, strPicturePath, 1)
            Session("chart1") = Nothing
            Session("chart1") = objBCommonChart.OutPutStream
        End Sub

        ' GetDataLogDetail method
        ' Purpsose: Create simple statistic
        Sub GetDataLogDetail()
            Dim inti As Integer
            Dim strDateTo As String
            Dim strDateFrom As String
            Dim objLegend As Object
            Dim objData As Object
            Dim strPicturePath As String = Server.MapPath("../Images/bground.gif")
            Dim objLabels As Object
            Dim objLabelDay As Object
            Dim dtFromDate As Date
            Dim dtToDate As Date
            Dim strDateFromvie As String
            Dim strDateTovie As String
            Dim strTitle As String
            Dim strScale As String
            Dim objData2() As Integer
            Dim objmTemp2() As Object

            ReDim objLabels(6)
            ReDim objLabelDay(6)

            For inti = 0 To UBound(objLabels)
                objLabels(inti) = ddlDay.Items(inti).Text
            Next

            'Get information about date changer
            Dim dtBase_date As Date

            If hidDate.Value = "" Then
                dtBase_date = System.DateTime.Now
            Else
                dtBase_date = CDate(hidDate.Value)
                dtBase_date = DateSerial(Year(dtBase_date), Month(dtBase_date), Day(dtBase_date))
            End If

            ' Calculate first day, last day of the current week
            dtFromDate = dtBase_date.AddDays(2 - Weekday(dtBase_date))
            dtToDate = dtBase_date.AddDays(8 - Weekday(dtBase_date))
            strDateFrom = CStr(Month(dtFromDate) & "/" & Day(dtFromDate) & "/" & Year(dtFromDate) & " " & "00:00:00")
            strDateFromvie = CStr(Day(dtFromDate) & "/" & Month(dtFromDate) & "/" & Year(dtFromDate))
            strDateTo = CStr(Month(dtToDate) & "/" & Day(dtToDate) & "/" & Year(dtToDate) & " " & "23:59:59")
            strDateTovie = CStr(Day(dtToDate) & "/" & Month(dtToDate) & "/" & Year(dtToDate))

            ' Resever FirstDate
            hidDate.Value = CStr(dtFromDate)

            ' Create objLabelDay
            For inti = 0 To 6
                objLabelDay(inti) = DateAdd(DateInterval.Day, inti, dtFromDate)
            Next

            ' Get data for Diagram
            Call objBLog.StatWeekly(strDateFrom, strDateTo, objLegend, objData)
            strScale = ddlLabel.Items(2).Text & strDateFromvie & ddlLabel.Items(3).Text & strDateTovie
            strTitle = ddlLabel.Items(4).Text

            ReDim objData2(6)
            ReDim objmTemp2(UBound(objData) + 1)

            Try
                For inti = 0 To UBound(objData) - 1
                    objmTemp2 = objData(inti)
                    objData2(0) = objData2(0) + objmTemp2(0)
                    objData2(1) = objData2(1) + objmTemp2(1)
                    objData2(2) = objData2(2) + objmTemp2(2)
                    objData2(3) = objData2(3) + objmTemp2(3)
                    objData2(4) = objData2(4) + objmTemp2(4)
                    objData2(5) = objData2(5) + objmTemp2(5)
                    objData2(6) = objData2(6) + objmTemp2(6)
                Next
                Call objBCommonChart.Makebarchart(objData2, objLabels, strTitle, strScale, 45, strPicturePath, "WStatDayModule.aspx")
                Session("chart1") = Nothing
                Session("chart1") = objBCommonChart.OutPutStream

                Response.Write("<MAP NAME=""map1"">")

                Dim arrLines()
                Dim intPos1 As Integer
                Dim intPos2 As Integer
                Dim intPos3 As Integer
                Dim strLine As String
                Dim intCount As Integer

                arrLines = Split(objBCommonChart.OutMapImg, Chr(10))
                For intCount = LBound(arrLines) To UBound(arrLines)
                    intPos1 = InStr(arrLines(intCount), "?x=")
                    intPos2 = InStr(arrLines(intCount), "&xLabel=")
                    If intPos1 > 0 Then
                        intPos3 = Mid(arrLines(intCount), intPos1 + 3, intPos2 - intPos1 - 3)
                        strLine = Left(arrLines(intCount), intPos1) & "Year=" & Year(objLabelDay(intCount)) & "&Month=" & Month(objLabelDay(intCount)) & "&Day=" & Day(objLabelDay(intCount)) & """>" & Chr(13)
                        Response.Write(strLine)
                    End If
                Next
                Response.Write("</MAP>")
            Catch
                Session("chart1") = Nothing
            End Try
        End Sub

        ' Initialize method
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBLog object
            objBLog.ConnectionString = Session("ConnectionString")
            objBLog.DBServer = Session("DBServer")
            objBLog.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLog.Initialize()

            ' Init objCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript'src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript'src = 'Js/WStatWeek.js'></script>")
        End Sub

        ' btnPrevWeek_Click event
        ' Purpose: Show stattistic of the previuos week
        Private Sub btnPrevWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevWeek.Click
            hidDate.Value = CStr(CDate(hidDate.Value).AddDays(-2))
            Call ShowStat()
        End Sub

        ' btnWeekNext_Click event
        ' Purpose: Show stattistic of the next week
        Private Sub btnWeekNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeekNext.Click
            hidDate.Value = CStr(CDate(hidDate.Value).AddDays(7))
            Call ShowStat()
        End Sub

        ' ddlTypeMap_SelectedIndexChanged event
        ' Purpose: show suitable statistic
        Private Sub ddlTypeMap_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlTypeMap.SelectedIndexChanged
            Call ShowStat()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        'Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLog Is Nothing Then
                    objBLog.Dispose(True)
                    objBLog = Nothing
                End If
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace