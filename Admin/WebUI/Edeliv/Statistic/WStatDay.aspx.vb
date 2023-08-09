Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
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
        Private objBRequestCollection As New clsBERequestCollection
        Private objBCommonChart As New clsBCommonChart

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            Call BindDropDownList()
            If Not Page.IsPostBack Then
                If LoadYearMonth() Then
                    Call DrawDayStat(CInt(hidYear.Value), CInt(hidMonth.Value))
                    ' WriteLog
                    Call WriteLog(76, ddlLabel.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(163) Then
                Call WriteErrorMssg(ddlLabel.Items(7).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonChart.Initialize()

            ' Init objBRequestCollection object
            objBRequestCollection.ConnectionString = Session("ConnectionString")
            objBRequestCollection.DBServer = Session("DBServer")
            objBRequestCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBRequestCollection.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Statistic/WStatic.js'></script>")
        End Sub

        ' LoadYearMonth method
        Private Function LoadYearMonth() As Boolean
            Dim intIndex As Integer
            ' Load year and month
            If Not Request.QueryString("Month") Is Nothing And Not Request.QueryString("Year") Is Nothing Then
                For intIndex = 0 To ddlYear.Items.Count - 1
                    If ddlYear.Items(intIndex).Value = Request.QueryString("Year") Then
                        ddlYear.SelectedIndex = intIndex
                        hidYear.Value = ddlYear.SelectedValue
                    End If
                Next
                Call BindMonthByYear()
                For intIndex = 0 To ddlMonth.Items.Count - 1
                    If ddlMonth.Items(intIndex).Value = Request.QueryString("Month") Then
                        ddlMonth.SelectedIndex = intIndex
                        hidMonth.Value = ddlMonth.SelectedValue
                    End If
                Next
            Else
                Dim blnFound As Boolean = False
                If ddlYear.Items.Count > 0 Then
                    For intIndex = 0 To ddlYear.Items.Count - 1
                        If ddlYear.Items(intIndex).Value = Year(Now) Then
                            ddlYear.SelectedIndex = intIndex
                            hidYear.Value = ddlYear.SelectedValue
                            blnFound = True
                        End If
                    Next

                    If blnFound = False Then
                        ddlYear.SelectedIndex = ddlYear.Items.Count - 1
                        hidYear.Value = ddlYear.SelectedValue
                    End If

                    BindMonthByCurrentYear()
                    For intIndex = 0 To ddlMonth.Items.Count - 1
                        If ddlMonth.Items(intIndex).Value = Month(Now) Then
                            ddlMonth.SelectedIndex = intIndex
                            hidMonth.Value = ddlMonth.SelectedValue
                        End If
                    Next
                    hidYear.Value = ddlYear.SelectedValue
                    hidMonth.Value = ddlMonth.SelectedValue
                End If

            End If
            If Not IsNumeric(hidMonth.Value) Then
                Return False
            Else
                Return True
            End If
        End Function

        ' BindMonthByYear method
        Private Sub BindMonthByYear()
            Dim tblTemp As DataTable

            tblTemp = objBRequestCollection.GetRequestedMonths(CInt(Request.QueryString("Year")))
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

            ' Month data
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    With ddlMonth
                        .DataSource = objBRequestCollection.GetRequestedMonths(CInt(Request.QueryString("Year")))
                        .DataTextField = "Month"
                        .DataValueField = "Month"
                        .DataBind()
                    End With
                End If
            End If
        End Sub

        ' BindMonthByCurrentYear method
        Private Sub BindMonthByCurrentYear()
            Dim tblTemp As DataTable
            tblTemp = objBRequestCollection.GetRequestedMonths(CInt(hidYear.Value))
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

            ' Month data
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                With ddlMonth
                    .DataSource = tblTemp
                    .DataTextField = "Month"
                    .DataValueField = "Month"
                    .DataBind()
                End With
            End If
        End Sub

        ' BindMonthByYearPostBack method
        Private Sub BindMonthByYearPostBack()
            Dim tblTemp As DataTable
            tblTemp = objBRequestCollection.GetRequestedMonths(CInt(hidYear.Value))
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

            ' Month data
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    With ddlMonth
                        .DataSource = objBRequestCollection.GetRequestedMonths(CInt(hidYear.Value))
                        .DataTextField = "Month"
                        .DataValueField = "Month"
                        .DataBind()
                    End With
                End If
            End If

            ddlYear.SelectedValue = CInt(hidYear.Value)
            If ddlMonth.Items.Count > 0 Then
                ddlMonth.SelectedValue = CInt(hidMonth.Value)
            End If
        End Sub

        ' BindDropDownList method
        ' Purpose: Get the Holding Library and Holding Location that user manage
        Private Sub BindDropDownList()
            ' Declare varivables
            Dim intMonthCount As Integer = 0
            Dim tblYear As DataTable
            Dim tblMonth As DataTable
            Dim strScript As String = ""
            Dim intIndex As Integer

            tblMonth = objBRequestCollection.GetRequestedMonths
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)
            tblYear = objBRequestCollection.GetRequestedYears
            Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)
            If Not tblMonth Is Nothing AndAlso tblMonth.Rows.Count > 0 Then
                intMonthCount = tblMonth.Rows.Count
            End If

            ' Year data
            If Not tblYear Is Nothing AndAlso tblYear.Rows.Count > 0 Then
                With ddlYear
                    .DataSource = tblYear
                    .DataTextField = "Year"
                    .DataValueField = "Year"
                    .DataBind()
                End With
            End If

            ' Bind javascript
            If intMonthCount > 0 Then
                strScript = "<script Language='JavaScript'>"
                strScript = strScript & "Years = new Array(" & intMonthCount & ");" & Chr(10)
                strScript = strScript & "Months = new Array(" & intMonthCount & ");" & Chr(10)
                For intIndex = 0 To intMonthCount - 1
                    strScript = strScript & "Months[" & intIndex & "] = " _
                    & tblMonth.Rows(intIndex).Item("Month") & ";" & Chr(10)
                    strScript = strScript & "Years[" & intIndex & "] = " _
& tblMonth.Rows(intIndex).Item("Year") & ";" & Chr(10)
                Next
                strScript = strScript & "function FilterMonth(Year) {" & Chr(10)
                strScript = strScript & "if (Year==0) {document.forms[0].hidMonth.value='';document.forms[0].hidYear.value='';}else{document.forms[0].hidYear.value=document.forms[0].ddlYear.options[document.forms[0].ddlYear.options.selectedIndex].value}" & Chr(10)
                strScript = strScript & "document.forms[0].ddlMonth.options.length = 0;" & Chr(10)
                strScript = strScript & "for (j = 0; j < Months.length; j++) {" & Chr(10)
                strScript = strScript & "if (Years[j] == Year) {" & Chr(10)
                strScript = strScript & "document.forms[0].ddlMonth.options.length = document.forms[0].ddlMonth.options.length + 1;" & Chr(10)
                strScript = strScript & "document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.length - 1].value = Months[j];" & Chr(10)
                strScript = strScript & "document.forms[0].ddlMonth.options[document.forms[0].ddlMonth.options.length - 1].text = Months[j];" & Chr(10)
                strScript = strScript & "document.forms[0].hidMonth.value = document.forms[0].ddlMonth.options[0].value;" & Chr(10)
                strScript = strScript & "}}}" & Chr(10)
                strScript = strScript & "</script>" & Chr(10)
            End If

            ' Bind the scripts and add attributes for the controls
            Page.RegisterClientScriptBlock("ChangeYear", strScript)
            ddlYear.Attributes.Add("OnChange", "FilterMonth(this.options[this.options.selectedIndex].value);")
            ddlMonth.Attributes.Add("OnChange", "if (eval(document.forms[0].hidMonth)) {document.forms[0].hidMonth.value=this.options[this.options.selectedIndex].value;}")
        End Sub

        ' DrawMonthStat
        Private Sub DrawDayStat(ByVal intYear As Integer, ByVal intMonth As Integer)
            Dim arrData, arrLabel, arrDataPie, arrLabelPie As Object
            Dim strImage As String
            Dim strVTitle1 As String
            Dim strVTitle2 As String
            Dim strHTitle1 As String
            Dim strHTitle2 As String
            Dim strTitle1 As String
            Dim strTitle2 As String
            Dim strTitle3 As String
            Dim strOutput As String

            ' ***************** Get the selected request's daily static **************
            If intYear > 0 Then
                strImage = Server.MapPath("..\..\Images\bground.gif")
                strVTitle1 = ddlLabel.Items(4).Text
                strVTitle2 = ddlLabel.Items(5).Text
                strHTitle1 = ddlLabel.Items(3).Text
                strHTitle2 = ddlLabel.Items(6).Text
                strTitle1 = ddlLabel.Items(0).Text & " " & intMonth & "/" & intYear
                strTitle2 = ddlLabel.Items(1).Text & " " & intMonth & "/" & intYear
                strTitle3 = ddlLabel.Items(2).Text & " " & intMonth & "/" & intYear

                ' Get the selected request's daily static (Type=0)
                arrData = Nothing
                arrLabel = Nothing
                arrDataPie = Nothing
                arrLabelPie = Nothing

                objBRequestCollection.CreateDailyStat(0, intYear, intMonth, ddlLabel.Items(3).Text)
                Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)
                arrData = objBRequestCollection.arrData
                arrLabel = objBRequestCollection.arrLabel
                arrDataPie = objBRequestCollection.arrDataPie
                arrLabelPie = objBRequestCollection.arrLabelPie
                image1.Visible = False
                image2.Visible = False
                If Not arrData Is Nothing AndAlso UBound(arrData) > -1 Then
                    image1.Visible = True
                    image2.Visible = True
                    ' Bar chart
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle1, strHTitle1, 1, strImage, "", "")
                    Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream
                    ' Pie chart
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Day")
                    Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")
                    Call objBCommonChart.Makepiechart(arrDataPie, arrLabelPie, strTitle1, strImage)
                    Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCommonChart.OutPutStream
                End If

                ' Get the selected request's daily static (Type 2)
                arrData = Nothing
                arrLabel = Nothing
                arrDataPie = Nothing
                arrLabelPie = Nothing
                objBRequestCollection.CreateDailyStat(1, intYear, intMonth, ddlLabel.Items(3).Text)
                Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

                arrData = objBRequestCollection.arrData
                arrLabel = objBRequestCollection.arrLabel
                arrDataPie = objBRequestCollection.arrDataPie
                arrLabelPie = objBRequestCollection.arrLabelPie
                image3.Visible = False
                image4.Visible = False
                If Not arrData Is Nothing AndAlso UBound(arrData) > -1 Then
                    image3.Visible = True
                    image4.Visible = True
                    ' Bar chart
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle2, strHTitle1, 1, strImage, "", "")
                    Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                    Session("chart3") = Nothing
                    Session("chart3") = objBCommonChart.OutPutStream
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Day")
                    Response.Write("<MAP NAME=""map3"">" & strOutput & "</MAP>")
                    ' Pir chart
                    Call objBCommonChart.Makepiechart(arrDataPie, arrLabelPie, strTitle2, strImage)
                    Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                    Session("chart4") = Nothing
                    Session("chart4") = objBCommonChart.OutPutStream
                End If

                arrData = Nothing
                arrLabel = Nothing
                ' Get the selected request's daily static (Type 3)
                objBRequestCollection.CreateDailyStat(2, intYear, intMonth, ddlLabel.Items(3).Text)
                Call WriteErrorMssg(ddlLabel.Items(9).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(8).Text, objBRequestCollection.ErrorCode)

                arrData = objBRequestCollection.arrData
                arrLabel = objBRequestCollection.arrLabel
                image5.Visible = False
                image6.Visible = False
                If Not arrData Is Nothing AndAlso UBound(arrData) > -1 Then
                    image5.Visible = True
                    image6.Visible = True
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle1, strHTitle2, 15, strImage, "", "")

                    Session("chart5") = Nothing
                    Session("chart5") = objBCommonChart.OutPutStream

                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Day")

                    Response.Write("<MAP NAME=""map5"">" & strOutput & "</MAP>")

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strTitle3, strImage)
                    Call WriteErrorMssg(ddlLabel.Items(9).Text, objBCommonChart.ErrorMsg, ddlLabel.Items(8).Text, objBCommonChart.ErrorCode)
                    Session("chart6") = Nothing
                    Session("chart6") = objBCommonChart.OutPutStream
                End If
            End If
        End Sub

        ' btnDraw_Click event
        ' Purpose: Filter the data and draw the statistics
        Private Sub btnDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDraw.Click
            Dim intIndex As Integer
            If hidYear.Value <> "" And hidMonth.Value <> "" Then
                Call DrawDayStat(CInt(hidYear.Value), CInt(hidMonth.Value))
                Call BindMonthByYearPostBack()
                For intIndex = 0 To ddlMonth.Items.Count - 1
                    If ddlMonth.Items(intIndex).Value = hidMonth.Value Then
                        ddlMonth.SelectedIndex = intIndex
                        hidMonth.Value = ddlMonth.SelectedValue
                    End If
                Next
            End If
        End Sub

        ' btnShowAll_Click event
        ' Purpose: Show MonthlyStatistic
        Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
            Response.Redirect("WStatMonth.aspx?Year=" & hidYear.Value)
        End Sub

        ' Page UnLoad event
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
                If Not objBRequestCollection Is Nothing Then
                    objBRequestCollection.Dispose(True)
                    objBRequestCollection = Nothing
                End If

            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
