Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WStatMonth
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
            If Not Page.IsPostBack Then
                Call BindRequestsYear()
                Call LoadData()
                ' WriteLog
                Call WriteLog(76, ddlLabel.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(163) Then
                Call WriteErrorMssg(ddlLabel.Items(8).Text)
            End If
        End Sub

        ' LoadData method
        ' Purpose: Load data at the first time
        Private Sub LoadData()
            Dim intIndex As Integer
            If Not Request.QueryString("Year") & "" = "" Then
                For intIndex = 0 To ddlYear.Items.Count - 1
                    If ddlYear.Items(intIndex).Value = Request("Year") Then
                        ddlYear.SelectedIndex = intIndex
                    End If
                Next
                Call DrawMonthStat(CInt(Request.QueryString("Year")))
            Else
                For intIndex = 0 To ddlYear.Items.Count - 1
                    If ddlYear.Items(intIndex).Value = Year(Now) Then
                        ddlYear.SelectedIndex = intIndex
                    End If
                Next
                If ddlYear.Items.Count > 0 Then
                    Call DrawMonthStat(CInt(ddlYear.SelectedItem.Text))
                End If
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Statistic/WStatic.js'></script>")
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

        ' DrawMonthStat method
        ' Purpose: Draw the monthly statistic by selected year
        Private Sub DrawMonthStat(ByVal intYear As Integer)
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

            ' ***************** Get the selected request's monthly static **************
            If intYear > 0 Then
                strImage = Server.MapPath("..\..\Images\bground.gif")
                strVTitle1 = ddlLabel.Items(5).Text
                strVTitle2 = ddlLabel.Items(6).Text
                strHTitle1 = ddlLabel.Items(4).Text
                strHTitle2 = ddlLabel.Items(7).Text
                strTitle1 = ddlLabel.Items(0).Text & " " & intYear
                strTitle2 = ddlLabel.Items(1).Text & " " & intYear
                strTitle3 = ddlLabel.Items(2).Text & " " & intYear

                ' Get the selected request's monthly static (Type 1)

                arrData = Nothing
                arrLabel = Nothing
                arrDataPie = Nothing
                arrLabelPie = Nothing
                objBRequestCollection.CreateMonthlyStat(0, intYear, ddlLabel.Items(4).Text)
                Call WriteErrorMssg(ddlLabel.Items(10).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(9).Text, objBRequestCollection.ErrorCode)
                arrData = objBRequestCollection.arrData
                arrLabel = objBRequestCollection.arrLabel
                arrDataPie = objBRequestCollection.arrDataPie
                arrLabelPie = objBRequestCollection.arrLabelPie
                image1.Visible = False
                image2.Visible = False
                If Not arrData Is Nothing AndAlso UBound(arrData) > -1 Then
                    image1.Visible = True
                    image2.Visible = True
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing

                    ' Bar chart
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle1, strHTitle1, 1, strImage, "WStatDay.aspx?Year=" & ddlYear.SelectedValue, "")
                    Session("chart1") = objBCommonChart.OutPutStream
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Month")
                    Response.Write("<MAP NAME=""map1"">" & strOutput & "</MAP>")
                    ' Pie chart
                    Call objBCommonChart.Makepiechart(arrDataPie, arrLabelPie, strTitle1, strImage)
                    Session("chart2") = objBCommonChart.OutPutStream
                End If

                ' Get the selected request's monthly static (Type 2)
                arrData = Nothing
                arrLabel = Nothing
                arrDataPie = Nothing
                arrLabelPie = Nothing
                objBRequestCollection.CreateMonthlyStat(1, intYear, ddlLabel.Items(4).Text)
                Call WriteErrorMssg(ddlLabel.Items(10).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(9).Text, objBRequestCollection.ErrorCode)

                arrData = objBRequestCollection.arrData
                arrLabel = objBRequestCollection.arrLabel
                arrDataPie = objBRequestCollection.arrDataPie
                arrLabelPie = objBRequestCollection.arrLabelPie
                image5.Visible = False
                image6.Visible = False
                If Not arrData Is Nothing AndAlso UBound(arrData) > -1 Then
                    image5.Visible = True
                    image6.Visible = True
                    Session("chart3") = Nothing
                    Session("chart4") = Nothing

                    ' Bar chart
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle2, strHTitle1, 1, strImage, "WStatDay.aspx?Year=" & ddlYear.SelectedValue, "")
                    Session("chart3") = objBCommonChart.OutPutStream
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Month")
                    Response.Write("<MAP NAME=""map3"">" & strOutput & "</MAP>")
                    ' Pie chart
                    Call objBCommonChart.Makepiechart(arrDataPie, arrLabelPie, strTitle2, strImage)
                    Session("chart4") = objBCommonChart.OutPutStream
                End If

                ' Get the selected request's monthly static (Type 3)
                objBRequestCollection.CreateMonthlyStat(2, intYear, ddlLabel.Items(4).Text)
                Call WriteErrorMssg(ddlLabel.Items(10).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(9).Text, objBRequestCollection.ErrorCode)

                arrData = objBRequestCollection.arrData
                arrLabel = objBRequestCollection.arrLabel
                image5.Visible = False
                image6.Visible = False
                If Not arrData Is Nothing AndAlso UBound(arrData) > -1 Then
                    image5.Visible = True
                    image6.Visible = True
                    Session("chart5") = Nothing
                    Session("chart6") = Nothing

                    ' Bar chart
                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strVTitle1, strHTitle2, 15, strImage, "", "")
                    Session("chart5") = objBCommonChart.OutPutStream
                    strOutput = objBCommonChart.OutMapImg
                    strOutput = Replace(strOutput, "xLabel", "Month")
                    Response.Write("<MAP NAME=""map5"">" & strOutput & "</MAP>")
                    ' Pie chart
                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strTitle3, strImage)
                    Session("chart6") = objBCommonChart.OutPutStream
                End If
            End If
        End Sub

        ' BindRequestsYear method
        Private Sub BindRequestsYear()
            Dim tblYear As DataTable
            tblYear = objBRequestCollection.GetRequestedYears()
            Call WriteErrorMssg(ddlLabel.Items(10).Text, objBRequestCollection.ErrorMsg, ddlLabel.Items(9).Text, objBRequestCollection.ErrorCode)
            ddlYear.Items.Clear()
            ' Get the data
            If Not tblYear Is Nothing AndAlso tblYear.Rows.Count > 0 Then
                ddlYear.DataSource = tblYear
                ddlYear.DataTextField = "Year"
                ddlYear.DataValueField = "Year"
                ddlYear.DataBind()
            End If
        End Sub

        ' btnShowAll_Click event
        ' Purpose: Draw annual statistic
        Private Sub btnShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAll.Click
            Response.Redirect("WStatYear.aspx")
        End Sub

        ' ddlYear_SelectedIndexChanged event
        ' Purpose: Filter the data and draw the statistic
        Private Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
            Call DrawMonthStat(ddlYear.SelectedValue)
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

