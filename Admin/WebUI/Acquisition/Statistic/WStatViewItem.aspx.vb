Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatViewItem
        Inherits clsWBase

        Private objBCommonChart As New clsBCommonChart
        Private objBStatic As New clsBLoanTransaction
        Private objBInput As New clsBInput

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                txtDayYear.Text = String.Format("{0}", Date.Now.Year)
                txtMonthYear.Text = String.Format("{0}", Date.Now.Year)
                txtWeekYear.Text = String.Format("{0}", Date.Now.Year)
                txtYearFrom.Text = String.Format("{0}", Date.Now.Year)
                txtYearTo.Text = String.Format("{0}", Date.Now.Year)
                txtWeekFrom.Text = String.Format("{0}", DatePart(DateInterval.WeekOfYear, Date.Now))
                txtWeekTo.Text = String.Format("{0}", DatePart(DateInterval.WeekOfYear, Date.Now))
                ddlMonth.SelectedValue = String.Format("{0}", Date.Now.Month)
                txtDateFrom.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                txtDateTo.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)

                rdNgay.Checked = True
                rdTuan.Checked = False
                rdThang.Checked = False
                rdNam.Checked = False
                rdOther.Checked = False

                'txtKeyword.CssClass = "lbTextBox enable-block"
                'txtKeyword.Enabled = True

                'ddlKeyword.CssClass = "disable-block"
                'ddlKeyword.Enabled = False

                PanelNgay.Attributes.Remove("style")
                PanelTuan.Attributes.Add("style", "display:none")
                PanelThang.Attributes.Add("style", "display:none")
                PanelNam.Attributes.Add("style", "display:none")
                PanelOther.Attributes.Add("style", "display:none")

                Session("chart1") = Nothing
                Session("chart2") = Nothing
                PanelStatistic.Visible = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            ' Init clsBLoanTransaction object
            objBStatic.ConnectionString = Session("ConnectionString")
            objBStatic.DBServer = Session("DBServer")
            objBStatic.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBStatic.Initialize()

            ' Init objBCommonChart object
            objBCommonChart.ConnectionString = Session("ConnectionString")
            objBCommonChart.DBServer = Session("DBServer")
            objBCommonChart.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonChart.Initialize()

            ' Init objBInput object
            objBInput.ConnectionString = Session("ConnectionString")
            objBInput.DBServer = Session("DBServer")
            objBInput.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBInput.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../../Circulation/Js/Statistic/WStatistic.js'></script>")


            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabelValue.Items(4).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabelValue.Items(4).Text)

            rdNgay.Attributes.Add("onclick", "Choise(1)")
            rdTuan.Attributes.Add("onclick", "Choise(2)")
            rdThang.Attributes.Add("onclick", "Choise(3)")
            rdNam.Attributes.Add("onclick", "Choise(4)")
            rdOther.Attributes.Add("onclick", "Choise(5)")

        End Sub
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabelValue.Items(2).Text)
            End If
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        Private Sub BindStatic()
            Dim arrData() As Integer
            Dim arrLabel() As String
            Dim strImage As String = "../../Images/bground.gif"
            Dim strHTitle As String = ddlLabelValue.Items(5).Text
            Dim strVTitle As String = ""
            lblSubTitle.Text = hidTitleChart.Value

            If (rdNgay.Checked) Then

                strVTitle = rdNgay.Text
                Dim intThang As Integer = CInt(ddlMonth.SelectedItem.Value)
                Dim intNam As Integer = CInt(txtDayYear.Text)
                objBStatic.GetItemViewByDay(intThang, intNam)
            End If


            If (rdTuan.Checked) Then
                strVTitle = rdTuan.Text
                Dim intWeekFrom As Integer = CInt(txtWeekFrom.Text)
                Dim intWeekTo As Integer = CInt(txtWeekTo.Text)
                Dim intYear As Integer = CInt(txtWeekYear.Text)

                objBStatic.GetItemViewByWeek(intWeekFrom, intWeekTo, intYear)
            End If


            If (rdThang.Checked) Then
                strVTitle = rdThang.Text
                Dim intYear As Integer = CInt(txtMonthYear.Text)

                objBStatic.GetItemViewByMonth(intYear)
            End If


            If (rdNam.Checked) Then
                strVTitle = rdNam.Text
                Dim intYearFrom As Integer = CInt(txtYearFrom.Text)
                Dim intYearTo As Integer = CInt(txtYearTo.Text)

                objBStatic.GetItemViewByYear(intYearFrom, intYearTo)
            End If


            If (rdOther.Checked) Then
                strVTitle = rdOther.Text
                Dim strDateFrom As String = txtDateFrom.Text
                Dim strDateTo As String = txtDateTo.Text

                objBStatic.GetItemView(strDateFrom, strDateTo)
            End If

            arrData = objBStatic.arrData
            arrLabel = objBStatic.arrLabel
            image1.Visible = False
            image2.Visible = False
            lblNostatic.Visible = True
            lblNostatic1.Visible = True

            If Not arrData Is Nothing And Not arrLabel Is Nothing Then
                If arrData.Count > 0 Then
                    image1.Visible = True
                    image2.Visible = True

                    Call objBCommonChart.Makebarchart(arrData, arrLabel, strHTitle, strVTitle, 45, strImage, "")
                    Session("chart1") = Nothing
                    Session("chart1") = objBCommonChart.OutPutStream

                    Call objBCommonChart.Makepiechart(arrData, arrLabel, strHTitle, strImage)
                    Session("chart2") = Nothing
                    Session("chart2") = objBCommonChart.OutPutStream

                    lblNostatic.Visible = False
                    lblNostatic1.Visible = False

                Else
                    Session("chart1") = Nothing
                    Session("chart2") = Nothing
                End If
            Else
                Session("chart1") = Nothing
                Session("chart2") = Nothing
            End If
        End Sub

        ' Event: btnCancel_Click
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            txtDayYear.Text = String.Format("{0}", Date.Now.Year)
            txtMonthYear.Text = String.Format("{0}", Date.Now.Year)
            txtWeekYear.Text = String.Format("{0}", Date.Now.Year)
            txtYearFrom.Text = String.Format("{0}", Date.Now.Year)
            txtYearTo.Text = String.Format("{0}", Date.Now.Year)
            txtWeekFrom.Text = String.Format("{0}", DatePart(DateInterval.WeekOfYear, Date.Now))
            txtWeekTo.Text = String.Format("{0}", DatePart(DateInterval.WeekOfYear, Date.Now))
            ddlMonth.SelectedValue = String.Format("{0}", Date.Now.Month)
            txtDateFrom.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
            txtDateTo.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonChart Is Nothing Then
                    objBCommonChart.Dispose(True)
                    objBCommonChart = Nothing
                End If
                If Not objBStatic Is Nothing Then
                    objBStatic.Dispose(True)
                    objBStatic = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Protected Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
            BindStatic()
            ShowPanel()
            PanelStatistic.Visible = True
        End Sub

        Private Sub ShowPanel()
            If (rdNgay.Checked) Then
                PanelNgay.Attributes.Remove("style")
                PanelTuan.Attributes.Add("style", "display:none")
                PanelThang.Attributes.Add("style", "display:none")
                PanelNam.Attributes.Add("style", "display:none")
                PanelOther.Attributes.Add("style", "display:none")
            End If
            If (rdTuan.Checked) Then
                PanelTuan.Attributes.Remove("style")
                PanelNgay.Attributes.Add("style", "display:none")
                PanelThang.Attributes.Add("style", "display:none")
                PanelNam.Attributes.Add("style", "display:none")
                PanelOther.Attributes.Add("style", "display:none")
            End If
            If (rdThang.Checked) Then
                PanelThang.Attributes.Remove("style")
                PanelNgay.Attributes.Add("style", "display:none")
                PanelTuan.Attributes.Add("style", "display:none")
                PanelNam.Attributes.Add("style", "display:none")
                PanelOther.Attributes.Add("style", "display:none")
            End If
            If (rdNam.Checked) Then
                PanelNam.Attributes.Remove("style")
                PanelNgay.Attributes.Add("style", "display:none")
                PanelTuan.Attributes.Add("style", "display:none")
                PanelThang.Attributes.Add("style", "display:none")
                PanelOther.Attributes.Add("style", "display:none")
            End If
            If (rdOther.Checked) Then
                PanelOther.Attributes.Remove("style")
                PanelNgay.Attributes.Add("style", "display:none")
                PanelTuan.Attributes.Add("style", "display:none")
                PanelThang.Attributes.Add("style", "display:none")
                PanelNam.Attributes.Add("style", "display:none")
            End If
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Dim arrData() As Integer
            Dim arrLabel() As String
            Dim strVTitle As String = ""

            If (rdNgay.Checked) Then
                Dim intThang As Integer = CInt(ddlMonth.SelectedItem.Value)
                Dim intNam As Integer = CInt(txtDayYear.Text)

                strVTitle = rdNgay.Text & String.Format(". Tháng: {0} - Năm: {1}", intThang, intNam)
                objBStatic.GetItemViewByDay(intThang, intNam)
            End If


            If (rdTuan.Checked) Then
                Dim intWeekFrom As Integer = CInt(txtWeekFrom.Text)
                Dim intWeekTo As Integer = CInt(txtWeekTo.Text)
                Dim intYear As Integer = CInt(txtWeekYear.Text)

                strVTitle = rdTuan.Text & String.Format(". Tuần: từ {0} đến {1} - Năm: {2}", intWeekFrom, intWeekTo, intYear)
                objBStatic.GetItemViewByWeek(intWeekFrom, intWeekTo, intYear)
            End If


            If (rdThang.Checked) Then
                Dim intYear As Integer = CInt(txtMonthYear.Text)

                strVTitle = rdThang.Text & String.Format(". Năm: {1}", intYear)
                objBStatic.GetItemViewByMonth(intYear)
            End If


            If (rdNam.Checked) Then
                Dim intYearFrom As Integer = CInt(txtYearFrom.Text)
                Dim intYearTo As Integer = CInt(txtYearTo.Text)

                strVTitle = rdNam.Text & String.Format(". Năm: từ {0} đến {1}", intYearFrom, intYearTo)
                objBStatic.GetItemViewByYear(intYearFrom, intYearTo)
            End If


            If (rdOther.Checked) Then
                Dim strDateFrom As String = txtDateFrom.Text
                Dim strDateTo As String = txtDateTo.Text

                strVTitle = String.Format(". Từ ngày {0} đến ngày {1}", strDateFrom, strDateTo)
                objBStatic.GetItemView(strDateFrom, strDateTo)
            End If

            arrData = objBStatic.arrData
            arrLabel = objBStatic.arrLabel

            Dim sBuilder1 As StringBuilder = clsBExportHelper.GenToExcel(arrLabel, arrData, ddlLog.Items(0).Text & " " & strVTitle)

            clsExport.StringBuilderToExcel(sBuilder1)

            ShowPanel()
            PanelStatistic.Visible = True
        End Sub
    End Class
End Namespace

