' Class: WStatMonth
' Puspose: Show monthly statistic
' Creator: Oanhtn
' CreatedDate: 25/11/2004
' Modification History:
'   + 25/11/2004 by Oanhtn: create statistic

Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WStatDayModule
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

        Dim objBCommonChart As New clsBCommonChart
        Dim objBLog As New clsBLog
        Dim objBEventGroup As New clsBEventGroup

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call CreateStatistic()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init objBLog object
            objBLog.ConnectionString = Session("ConnectionString")
            objBLog.DBServer = Session("DBServer")
            objBLog.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLog.Initialize()

            ' Init objBEventGroup object
            objBEventGroup.ConnectionString = Session("ConnectionString")
            objBEventGroup.DBServer = Session("DBServer")
            objBEventGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBEventGroup.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WStatDayModule.js'></script>")
        End Sub

        ' CreateStatistic method
        ' Purpose: show monthly statistic
        Private Sub CreateStatistic()
            Dim strURL As String
            Dim tblTemp As DataTable
            Dim intMax As Integer
            Dim arrData()
            Dim arrLabel()
            Dim arrLabelID()
            Dim intCount As Integer
            Dim intCount1 As Integer
            Dim strImage As String = Server.MapPath("../Images/bground.gif")
            Dim strVTitle As String = ddlLabel.Items(5).Text
            Dim strHTitle As String = ddlLabel.Items(4).Text
            Dim blnNotFound As Boolean = False
            Dim intYear As Integer
            Dim intMonth As Integer
            Dim intDay As Integer


            If Not Request("Day") = "" Then
                hidDay.Value = Request("Day")
            End If
            If Not Request("Month") = "" Then
                hidMonth.Value = Request("Month")
            End If
            If Not Request("Year") = "" Then
                hidYear.Value = Request("Year")
            End If
            If Not Request("Type") = "" Then
                hidType.Value = Request("Type")
            End If

            intYear = CInt(hidYear.Value)
            intMonth = CInt(hidMonth.Value)
            intDay = CInt(hidDay.Value)

            tblTemp = objBEventGroup.GetEventGroups
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                intMax = tblTemp.Rows.Count
                ReDim arrLabel(intMax - 1)
                ReDim arrData(intMax - 1)
                ReDim arrLabelID(intMax - 1)
                For intCount = 0 To intMax - 1
                    arrLabelID(intCount) = tblTemp.Rows(intCount).Item("ID")
                    arrLabel(intCount) = tblTemp.Rows(intCount).Item("VietName")
                    arrData(intCount) = 0
                Next
            End If

            lblPageTitle.Text = ddlLabel.Items(2).Text & hidDay.Value & "/" & hidMonth.Value & "/" & hidYear.Value
            tblTemp = objBLog.StatDayModule(CInt(hidDay.Value), CInt(hidMonth.Value), CInt(hidYear.Value))
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                intMax = tblTemp.Rows.Count
                ' Create 2 arrays of Label & Data
                For intCount = 0 To intMax - 1
                    For intCount1 = LBound(arrLabelID) To UBound(arrLabelID)
                        If CInt(arrLabelID(intCount1)) = CInt(tblTemp.Rows(intCount).Item("ParentID")) Then
                            arrData(intCount1) = arrData(intCount1) + CInt(tblTemp.Rows(intCount).Item("NOR"))
                            Exit For
                        End If
                    Next
                Next
            End If

            Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 60, strImage, "WStatDayDetail.aspx")
            Session("chart1") = Nothing
            Session("chart1") = objBCommonChart.OutPutStream
            Response.Write("<MAP NAME=""map1"">")

            Dim arrLines()
            Dim intPos1 As Integer
            Dim intPos2 As Integer
            Dim intPos3 As Integer
            Dim strLine As String

            arrLines = Split(objBCommonChart.OutMapImg, Chr(10))
            For intCount = LBound(arrLines) To UBound(arrLines)
                intPos1 = InStr(arrLines(intCount), "?x=")
                intPos2 = InStr(arrLines(intCount), "&xLabel=")
                If intPos1 > 0 Then
                    intPos3 = Mid(arrLines(intCount), intPos1 + 3, intPos2 - intPos1 - 3)
                    strLine = Left(arrLines(intCount), intPos1) & "Year=" & hidYear.Value & "&Month=" & hidMonth.Value & "&Day=" & hidDay.Value & "&Type=" & hidType.Value & "&ModuleID=" & arrLabelID(CInt(intPos3)) & """>" & Chr(13)
                    Response.Write(strLine)
                End If
            Next
            Response.Write("</MAP>")

            objBCommonChart.Makepiechart(arrData, arrLabel, ddlLabel.Items(6).Text, strImage)
            Session("chart2") = Nothing
            Session("chart2") = objBCommonChart.OutPutStream
        End Sub

        ' btnPrevDay_Click event
        ' Purpose: move to previous day
        Private Sub btnPrevDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevDay.Click
            Dim dtmTemp As DateTime = CDate(hidDay.Value & "/" & hidMonth.Value & "/" & hidYear.Value).AddDays(-1)

            hidDay.Value = dtmTemp.Day
            hidMonth.Value = dtmTemp.Month
            hidYear.Value = dtmTemp.Year
            Response.Write(hidDay.Value)
            Response.Redirect("WStatDayModule.aspx?Year=" & hidYear.Value & "&Month=" & hidMonth.Value & "&Day=" & hidDay.Value & "&x=" & GenRandomNumber(10) & "&Type= " & hidType.Value)
        End Sub

        ' btnNextDay_Click move to next day
        Private Sub btnNextDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextDay.Click
            Dim dtmTemp As DateTime = CDate(hidDay.Value & "/" & hidMonth.Value & "/" & hidYear.Value).AddDays(1)

            hidDay.Value = dtmTemp.Day
            hidMonth.Value = dtmTemp.Month
            hidYear.Value = dtmTemp.Year
            Response.Redirect("WStatDayModule.aspx?Year=" & hidYear.Value & "&Month=" & hidMonth.Value & "&Day=" & hidDay.Value & "&x=" & GenRandomNumber(10) & "&Type= " & hidType.Value)
        End Sub

        ' btnBack_Click event
        ' Purpose: back to statMonthly page
        Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
            If Request("Type") = 0 Then
                Response.Redirect("WStatWeek.aspx")
            Else
                Response.Redirect("WStatMonth.aspx?Year=" & hidYear.Value & "&Month=" & hidMonth.Value & "&x=" & GenRandomNumber(10) & "&Type=1")
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
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
                If Not objBEventGroup Is Nothing Then
                    objBEventGroup.Dispose(True)
                    objBEventGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace