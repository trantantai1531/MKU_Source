' Class: WStatMonth
' Puspose: Show monthly statistic
' Creator: Oanhtn
' CreatedDate: 18/11/2004
' Modification History:
'   + 24/11/2004 by Oanhtn: create statistic

Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WStatMonth
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblBarChart As System.Web.UI.WebControls.Label
        Protected WithEvents Button1 As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Dim objBCommonChart As New clsBCommonChart
        Dim objBLog As New clsBLog

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call CreateStatistic()
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
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/WStatMonth.js'></script>")

            btnPrevMonth.Attributes.Add("OnClick", "MovePrevMonth();")
            btnNextMonth.Attributes.Add("OnClick", "MoveNextMonth();")
        End Sub

        ' CreateStatistic method
        ' Purpose: show monthly statistic
        Private Sub CreateStatistic()
            Dim tblTemp As DataTable
            Dim arrData()
            Dim arrLabel()
            Dim intCount As Integer
            Dim intCount1 As Integer
            Dim intLenOfMonth As Integer
            Dim strImage As String = Server.MapPath("../Images/bground.gif")
            Dim strVTitle As String = ddlLabel.Items(5).Text
            Dim strHTitle As String = ddlLabel.Items(4).Text
            Dim blnNotFound As Boolean = False

            If Not Request("Month") = "" Then
                hidMonth.Value = Request("Month")
            End If
            If Not Request("Year") = "" Then
                hidYear.Value = Request("Year")
            End If

            If hidMonth.Value = "" Then
                hidMonth.Value = Month(Now)
            End If
            If hidYear.Value = "" Then
                hidYear.Value = Year(Now)
            End If

            intLenOfMonth = CDate(hidMonth.Value & "/01/" & hidYear.Value).DaysInMonth(CInt(hidYear.Value), CInt(hidMonth.Value))
            ReDim arrLabel(intLenOfMonth - 1)
            ReDim arrData(intLenOfMonth - 1)
            For intCount = 0 To intLenOfMonth - 1
                arrData(intCount) = 0
                arrLabel(intCount) = intCount + 1
            Next

            lblPageTitle.Text = ddlLabel.Items(2).Text & hidMonth.Value & "/" & hidYear.Value
            tblTemp = objBLog.StatMonthly(CInt(hidMonth.Value), CInt(hidYear.Value))
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ' Create 2 arrays of Label & Data
                For intCount = 0 To tblTemp.Rows.Count - 1
                    For intCount1 = 0 To UBound(arrLabel)
                        If arrLabel(intCount1) = CInt(tblTemp.Rows(intCount).Item("DisplayEntry")) Then
                            arrData(intCount1) = arrData(intCount1) + CInt(tblTemp.Rows(intCount).Item("NOR"))
                            Exit For
                        End If
                    Next
                Next
            End If

            Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle, strHTitle, 0, strImage, "WStatDayModule.aspx")
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
                    strLine = Left(arrLines(intCount), intPos1) & "Year=" & hidYear.Value & "&Month=" & hidMonth.Value & "&Day=" & arrLabel(intCount) & "&Type=1"">" & Chr(13)
                    Response.Write(strLine)
                End If
            Next
            Response.Write("</MAP>")
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace