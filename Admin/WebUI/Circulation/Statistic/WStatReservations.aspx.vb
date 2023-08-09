Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports Service.Excel

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WStatReservations
        Inherits System.Web.UI.Page

        'Private objBItem As New clsBItem
        Private objBCDBS As New clsBCommonDBSystem

        Private objBRT As New clsBReservationTransaction
        Private strErrorMsg As String

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                txtDateFrom.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                txtDateTo.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                Session("pageIndex") = 0
                dtgResultByPatronName.PageIndex = 0
                dtgResultByPatronName.DataSource = Nothing
                dtgResultByPatronName.DataBind()
            End If
        End Sub
        Public Function CheckPemission(ByVal intPemission As Integer) As Boolean
            CheckPemission = False
            If clsSession.GlbUser.ToLower() = "Admin".ToLower() Then
                CheckPemission = True
            Else
                If clsSession.ModuleID = 1 And Session("CatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 2 And Session("PatModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 3 And Session("CirModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 4 And Session("AcqModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 5 And Session("SerModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 6 And Session("AdmModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 8 And Session("ILLModule") = 0 Then
                    Return False
                ElseIf clsSession.ModuleID = 9 And Session("DELModule") = 0 Then
                    Return False
                ElseIf Not Session("UserRights") Is Nothing Then
                    If InStr("," & Session("UserRights"), "," & intPemission & ",") > 0 Then
                        CheckPemission = True
                    End If
                End If
            End If
        End Function

        Public Overloads Sub WriteErrorMssg(ByVal strErrorMsg As String)
            Response.Write("<CENTER><H2><FONT COLOR=""RED"">" & strErrorMsg & "</FONT></H2></CENTER>")
            Response.End()
        End Sub
        Private Sub RegisterCalendar(Optional ByVal strOutPath As String = "..")
            'strOutCalendarPath = strOutPath
            If clsSession.GlbLanguage = "" Or clsSession.GlbLanguage Is Nothing Then
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = 'vie';var imgDir='" & strOutPath & "/Common/Calendar/'</script>")
            Else
                Page.RegisterClientScriptBlock("SetCalendarLang", "<script language='javascript'>var language = '" & clsSession.GlbLanguage & "';var imgDir='" & strOutPath & "/Common/Calendar/'</script>")
            End If
            Page.RegisterClientScriptBlock("ShowCalendar", "<script language='javascript' src='" & strOutPath & "/Common/Calendar/PopCalendar1.js'></script>")
        End Sub
        Private Sub SetOnclickCalendar(ByRef lnkCalendarTmp As HyperLink, ByRef txtDateTmp As TextBox, ByVal strMsg As String)
            lnkCalendarTmp.NavigateUrl = "#"
            lnkCalendarTmp.Attributes.Add("onClick", "popUpCalendar(this, document.forms[0]." & txtDateTmp.ID & ", '" & Session("DateFormat") & "',26)")
            txtDateTmp.Attributes.Add("OnChange", "if (!CheckDate(this, '" & Session("DateFormat") & "', '" & strMsg & " (" & Session("DateFormat") & ")')) {this.value='';this.focus();return false;}")
            txtDateTmp.Attributes.Add("onkeypress", "if (window.event.keyCode == 13) {if (!CheckDate(this, '" & Session("DateFormat") & "', '" & strMsg & " (" & Session("DateFormat") & ")')) {this.value='';this.focus();return false;}}")
            txtDateTmp.ToolTip = Session("DateFormat")
        End Sub
        Private Sub CheckFormPermission()
            If Not CheckPemission(67) Then
                Call WriteErrorMssg(ddlLabelValue.Items(2).Text)
            End If
        End Sub

        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../../Circulation/Js/Statistic/WStatistic.js'></script>")


            Me.RegisterCalendar("../..")

            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabelValue.Items(4).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabelValue.Items(4).Text)

            ddlTimes.Attributes.Add("onChange", "change(this);")
        End Sub


        Private Sub Initialze()
            'objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            'objBItem.DBServer = Session("DBServer")
            'objBItem.ConnectionString = Session("ConnectionString")
            'Call objBItem.Initialize()
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()

            ' Init objBRT object
            objBRT.ConnectionString = Session("ConnectionString")
            objBRT.DBServer = Session("DBServer")
            objBRT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRT.Initialize()
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRT Is Nothing Then
                    objBRT.Dispose(True)
                    objBRT = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        Private Sub BindData()
            Try
                Dim tblResult As New DataTable
                Dim strDateFrom As String = txtDateFrom.Text
                Dim strDateTo As String = txtDateTo.Text
                objBRT.UserID = Session("UserID")
                If ddlTimes.SelectedValue = "-1" Then

                    If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                    If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)

                    tblResult = objBRT.GetReservation_ReportByTime(0, strDateFrom, strDateTo)
                Else
                    If ddlTimes.SelectedValue = "0" Then
                        tblResult = objBRT.GetReservation_ReportByTime(0, "", "")
                    Else
                        Dim countDate As Integer = CType(ddlTimes.SelectedValue, Integer)
                        strDateFrom = String.Format("{0:dd/MM/yyyy}", Date.Now.AddDays(countDate * (-1)))
                        strDateTo = String.Format("{0:dd/MM/yyyy}", Date.Now)
                        If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                        If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)
                        tblResult = objBRT.GetReservation_ReportByTime(0, strDateFrom, strDateTo)
                    End If
                End If

                If tblResult.Rows.Count > 0 Then
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
                    If ddlType.SelectedValue = 0 Then
                        dtgResultByFileName.Visible = True
                        dtgResultByPatronName.Visible = False
                        dtgResultByFileName.DataSource = objBCDBS.ConvertTable(tblResult, False)
                        dtgResultByFileName.DataBind()
                    ElseIf ddlType.SelectedValue = 1 Then
                        dtgResultByFileName.Visible = False
                        dtgResultByPatronName.Visible = True
                        dtgResultByPatronName.DataSource = objBCDBS.ConvertTable(tblResult, False)
                        dtgResultByPatronName.DataBind()
                    End If
                End If
                Session("tblResult") = tblResult
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Protected Sub btnBindData_Click(sender As Object, e As EventArgs) Handles btnBindData.Click
            BindData()
        End Sub

        'Protected Sub dtgPolicy_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgResultByPatronName.PageIndexChanging
        '    Session("pageIndex") = e.NewPageIndex
        '    BindData()
        'End Sub

        Private Shared Function DecimalFormatPlace(ByVal Decimals As Integer) As String
            If (Decimals = 0) Then
                Return "General"
            End If

            Dim strReturn As String = "0."

            If (Decimals >= 0) Then
                For i As Integer = 0 To Decimals - 1
                    strReturn = strReturn & "0"
                Next
            End If
            Return strReturn
        End Function


        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
            Try

                Response.ClearContent()
                Response.AppendHeader("content-disposition", "attachment;filename=export_" & DateTime.Now.Year.ToString() & DateTime.Now.Month.ToString() & DateTime.Now.Day.ToString() & DateTime.Now.Hour.ToString() & DateTime.Now.Minute.ToString() & DateTime.Now.Second.ToString() & DateTime.Now.Millisecond.ToString() & ".doc")
                Response.Charset = "UTF-8"
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = "application/msword"
                Response.ContentEncoding = Encoding.Unicode
                Response.BinaryWrite(Encoding.Unicode.GetPreamble())

                'Dim yearFrom As Integer = CType(If(String.IsNullOrEmpty(txtYearFrom.Text), "0", txtYearFrom.Text), Integer)
                'Dim yearTo As Integer = CType(If(String.IsNullOrEmpty(txtYearTo.Text), "0", txtYearTo.Text), Integer)
                'Dim intAcqSource As Integer = CType(If(String.IsNullOrEmpty(ddlAcqSource.SelectedItem.Value), "0", ddlAcqSource.SelectedItem.Value), Integer)

                'Dim tblResult As DataTable = objBItem.GetItemByKeyword(ddlKeyword.SelectedItem.Value, ddlItemType.SelectedValue, ddlLoanType.SelectedValue, yearFrom, yearTo, intAcqSource)
                Dim tblResult As DataTable = CType(Session("tblResult"), DataTable)
                Dim totalRecord As Double = 0
                Dim totalCopyNumber As Double = 0
                'ResultSearch(tblResult, totalRecord, totalCopyNumber)
                Dim tblConvert As New DataTable("tblConvert")
                totalCopyNumber = 0
                ConvertTable(tblResult, tblConvert, totalRecord, totalCopyNumber)
                If (ddlType.SelectedValue = 0) Then
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text,
                                        ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text,
                                        ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text
                                        )
                Else
                    tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text,
                                        ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                        ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text
                                        )
                End If


                Dim wordHelper As New clsBExportHelper

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='www.w3.org/TR/REC-html40'>")
                strHTMLContent.Append("<head>")
                strHTMLContent.Append("<title></title>")
                strHTMLContent.Append("<!--[if gte mso 9]>")
                strHTMLContent.Append("<xml>" & clsBExportHelper.Xml_Word() & "</xml>")
                strHTMLContent.Append("<![endif]-->")
                strHTMLContent.Append("<style>" & clsBExportHelper.css_word("2cm", "1cm", "2cm", "1cm", False) & "</style>")
                strHTMLContent.Append("</head>")
                strHTMLContent.Append("<body lang=EN-US style='tab-interval:.5in'>")
                strHTMLContent.Append("<div class=Section1>")
                strHTMLContent.Append("<p>" & clsBExportHelper.GenHeader(hidLeftTable.Value, hidRightTable.Value, hidTitleTable.Value) & "</p>")
                '& ": " & ddlKeyword.SelectedItem.Text.ToUpper
                strHTMLContent.Append("<br/>")
                strHTMLContent.Append("<p>" & clsBExportHelper.GenFooter(hidMessageBook.Value & "<b>" & totalRecord & "</b>", hidMessageCopyNumber.Value) & "</p>")
                strHTMLContent.Append("<br/>")
                strHTMLContent.Append("<p>" & clsBExportHelper.GenDataTableToString(tblConvert) & "</p>")
                strHTMLContent.Append("<div id='hrdftrtbl'>")
                strHTMLContent.Append("<div style='mso-element:header' id=h1>" & clsBExportHelper.HeaderWord("") & "</div>")
                strHTMLContent.Append("<div style='mso-element:footer; text-align:right;' id=f1>" & clsBExportHelper.FooterWord("<span style='mso-tab-count:1'></span>" & "<b>" & "Trang: </b>" & "<i><span style='mso-field-code:"" PAGE ""'></span>" & " / " & "<span style='mso-field-code:"" NUMPAGES ""'></span></i>") & "</div>")
                strHTMLContent.Append("</div></body></html>")

                Response.Write(strHTMLContent)
                Response.End()
                Response.Flush()

            Catch ex As Exception

            End Try
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
        Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable, ByRef totalRecord As Double, ByRef totalCopyNumber As Double)
            tblConvert.Clear()
            If (ddlType.SelectedValue = 0) Then
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("CREATEDDATE")
                tblConvert.Columns.Add("MAINITEM")
                tblConvert.Columns.Add("COPYNUMBER")
                tblConvert.Columns.Add("CODE")
                tblConvert.Columns.Add("FULLNAME")
            Else
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("CREATEDDATE")
                tblConvert.Columns.Add("CODE")
                tblConvert.Columns.Add("FULLNAME")
                tblConvert.Columns.Add("MAINITEM")
                tblConvert.Columns.Add("COPYNUMBER")
            End If

            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                totalRecord = CType(tblResult.Rows.Count, Double)
                'tblConvert.Columns.Add("EXPIREDDATE")
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim STT As String = rows.Item("STT")
                    Dim EXPIREDDATE As String = CDate(rows.Item("EXPIREDDATE")).ToString("dd/MM/yyyy")
                    Dim content As String = rows.Item("MAINITEM").ToString()
                    Dim CODE As String = rows.Item("CODE").ToString()
                    Dim COPYNUMBER As String = rows.Item("COPYNUMBER").ToString()
                    Dim CREATEDDATE As String = CDate(rows.Item("CREATEDDATE")).ToString("dd/MM/yyyy")
                    Dim FULLNAME As String = rows.Item("FULLNAME").ToString()
                    Dim Title As String = ""

                    If content.Contains("/") Then
                        Dim split() As String = content.Split("/")
                        Title = split(0).ToString.Trim
                    Else
                        Title = content.Trim
                    End If


                    dtRow.Item("STT") = STT
                    dtRow.Item("CREATEDDATE") = CREATEDDATE
                    dtRow.Item("MAINITEM") = Title
                    dtRow.Item("COPYNUMBER") = COPYNUMBER
                    dtRow.Item("CODE") = CODE
                    dtRow.Item("FULLNAME") = FULLNAME
                    tblConvert.Rows.Add(dtRow)
                Next
            End If

        End Sub

    End Class
End Namespace

