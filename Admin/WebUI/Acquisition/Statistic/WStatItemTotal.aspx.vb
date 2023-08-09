Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports Aspose.Pdf
Imports Aspose.Pdf.Generator
Imports Aspose

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WStatItemTotal
        Inherits System.Web.UI.Page

        Private objBItem As New clsBItem
        Private objBCDBS As New clsBCommonDBSystem
        Private _clsBItemDissertation As DataTable

        Private Property clsBItemDissertation As DataTable
            Get
                Return _clsBItemDissertation
            End Get
            Set(value As DataTable)
                _clsBItemDissertation = value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                PanelTotal.Visible = False
                txtDateFrom.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                txtDateTo.Text = String.Format("{0:dd/MM/yyyy}", Date.Now)
                Session("pageIndex") = 0
                dtgPolicy.PageIndex = 0
                dtgPolicy.DataSource = Nothing
                dtgPolicy.DataBind()
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
        Private Sub SetOnclickCalendar(ByRef lnkCalendarTmp As WebControls.HyperLink, ByRef txtDateTmp As TextBox, ByVal strMsg As String)
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
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            Call objBItem.Initialize()
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
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
                If ddlTimes.SelectedValue = "-1" Then

                    If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                    If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)

                    tblResult = objBItem.GetItemStatisticTotal(strDateFrom, strDateTo)
                    clsBItemDissertation = objBItem.GetItemDissertationTotal(strDateFrom, strDateTo)
                Else
                    If ddlTimes.SelectedValue = "0" Then
                        tblResult = objBItem.GetItemStatisticTotal("", "")
                    Else
                        Dim countDate As Integer = CType(ddlTimes.SelectedValue, Integer)
                        strDateFrom = String.Format("{0:dd/MM/yyyy}", Date.Now.AddDays(countDate * (-1)))
                        strDateTo = String.Format("{0:dd/MM/yyyy}", Date.Now)
                        If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                        If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)
                        tblResult = objBItem.GetItemStatisticTotal(strDateFrom, strDateTo)
                    End If
                End If
                If tblResult.Rows.Count > 0 Then
                    PanelTotal.Visible = True
                    If ddlTimes.SelectedValue = "-1" Then
                        LabelTime.Text = txtDateFrom.Text & "-" & txtDateTo.Text
                    Else
                        LabelTime.Text = ddlTimes.SelectedItem.Text
                    End If

                    Dim intCountValid As Integer = 0
                    Dim intCountViews As Integer = 0
                    Dim intCountDownloads As Integer = 0
                    Dim intCountPatronDownloads As Integer = 0
                    Dim intCountFileUpload As Integer = 0
                    Dim intCountItems As Integer = 0
                    Dim intCountViewEbooks As Integer = 0
                    Dim intCountPageEbooks As Integer = 0
                    Dim intCountDissertations As Integer = 0
                    Dim intCountLogin As Integer = 0
                    Dim intCountMagazinePage As Integer = 0

                    For Each row As DataRow In tblResult.Rows
                        intCountValid = intCountValid + CType(row("CountValid").ToString(), Integer)
                        intCountViews = intCountViews + CType(row("CountViews").ToString(), Integer)
                        intCountDownloads = intCountDownloads + CType(row("CountDownloads").ToString(), Integer)
                        intCountPatronDownloads = intCountPatronDownloads + CType(row("CountPatronDownloads").ToString(), Integer)
                        intCountFileUpload = intCountFileUpload + CType(row("CountFileUpload").ToString(), Integer)
                        intCountItems = intCountItems + CType(row("CountItems").ToString(), Integer)
                        intCountViewEbooks = intCountViewEbooks + CType(row("CountEbookView").ToString(), Integer)
                        intCountPageEbooks = intCountPageEbooks + CType(row("CountPage").ToString(), Integer)
                        intCountDissertations = intCountDissertations + CType(row("CountDissertation").ToString(), Integer)
                        intCountLogin = intCountLogin + CType(row("CountLogins").ToString(), Integer)
                        intCountMagazinePage = intCountMagazinePage + CType(row("CountMagazinePages").ToString, Integer)
                    Next

                    LabelCountValid.Text = intCountValid
                    LabelCountViews.Text = intCountViews                    '' Luot xem bieu ghi
                    LabelCountDownloads.Text = intCountDownloads            '' Luot Download
                    LabelCountPatronDownloads.Text = intCountPatronDownloads '' Luot Ban doc Download
                    LabelCountFileUpload.Text = intCountFileUpload          '' Số Ebook Upload
                    LabelCountItem.Text = intCountItems                     '' Số Biểu ghi
                    LabelCountViewEbooks.Text = intCountViewEbooks          '' Số luot xem Ebook
                    LabelCountPageEbooks.Text = intCountPageEbooks          '' Số trang Ebook
                    LabelCountDissertation.Text = intCountDissertations     '' Số File tạp chí
                    LabelCountLogin.Text = intCountLogin                    '' Lượt bạn đọc đăng nhập
                    LabelCountMagazinePage.Text = intCountMagazinePage      '' Số Trang tạp chí

                    dtgPolicy.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                    dtgPolicy.DataSource = objBCDBS.ConvertTable(tblResult, False)
                    dtgPolicy.DataBind()

                End If
            Catch ex As Exception
                Dim strEx As String = ex.Message
            End Try
        End Sub


        Protected Sub btnBindData_Click(sender As Object, e As EventArgs) Handles btnBindData.Click
            BindData()
        End Sub

        Protected Sub dtgPolicy_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgPolicy.PageIndexChanging
            Session("pageIndex") = e.NewPageIndex
            BindData()
        End Sub

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

                Dim tblResult As New DataTable
                Dim strDateFrom As String = txtDateFrom.Text
                Dim strDateTo As String = txtDateTo.Text
                If ddlTimes.SelectedValue = "-1" Then

                    If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                    If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)

                    tblResult = objBItem.GetItemStatisticTotal(strDateFrom, strDateTo)
                Else
                    If ddlTimes.SelectedValue = "0" Then
                        tblResult = objBItem.GetItemStatisticTotal("", "")
                    Else
                        Dim countDate As Integer = CType(ddlTimes.SelectedValue, Integer)
                        strDateFrom = String.Format("{0:dd/MM/yyyy}", Date.Now.AddDays(countDate * (-1)))
                        strDateTo = String.Format("{0:dd/MM/yyyy}", Date.Now)
                        If strDateFrom <> "" Then strDateFrom = objBCDBS.ConvertDateBack(strDateFrom, False)
                        If strDateTo <> "" Then strDateTo = objBCDBS.ConvertDateBack(strDateTo, False)
                        tblResult = objBItem.GetItemStatisticTotal(strDateFrom, strDateTo)
                    End If
                End If
                'tblResult = objBCDBS.ConvertTable(tblResult, False)

                Dim filename As String = String.Format("Report_{0}.xls", DateAndTime.Now.Ticks)

                Response.Clear()
                Response.ClearContent()
                Response.ClearHeaders()
                Response.Buffer = True
                Response.ContentType = "application/ms-excel"
                Response.AddHeader("Content-Disposition", "attachment;filename=" & filename)

                Response.Charset = Encoding.UTF8.EncodingName
                Response.ContentEncoding = System.Text.Encoding.Unicode
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble())
                Response.Write("<Table border='1' borderColor='#000000' cellSpacing='0' cellPadding='0'><TR>")
                Dim columnscount As Integer = tblResult.Columns.Count

                For i As Integer = 0 To columnscount - 1
                    Response.Write("<Td>")
                    Response.Write("<B>")
                    Select Case tblResult.Columns(i).ColumnName.ToString()
                        Case "SetDate"
                            Response.Write("Ngày")
                        Case "CountValid"
                            Response.Write("Lượt truy cập OPAC")
                        Case "CountLogins"
                            Response.Write("Lượt bạn đọc đăng nhập")
                        Case "CountViews"
                            Response.Write("Lượt xem biểu ghi")
                        Case "CountItems"
                            Response.Write("Số biểu ghi")
                        Case "CountFileUpload"
                            Response.Write("Số ebook upload")
                        Case "CountPage"
                            Response.Write("Số trang Ebook Upload")
                        Case "CountEbookView"
                            Response.Write("Số lượt xem Ebook")
                        Case "CountPatronDownloads"
                            Response.Write("Lượt bạn đọc download")
                        Case "CountDownloads"
                            Response.Write("Lượt tài liệu download")
                        Case "CountDissertation"
                            Response.Write("Số file tạp chí")
                        Case "CountMagazinePages"
                            Response.Write("Số trang tạp chí")
                        Case Else
                            Response.Write(tblResult.Columns(i).ColumnName.ToString())
                    End Select

                    Response.Write("</B>")
                    Response.Write("</Td>")
                Next

                Response.Write("</TR>")
                For Each Row As DataRow In tblResult.Rows
                    Response.Write("<TR>")
                    For i As Integer = 0 To columnscount - 1
                        Response.Write("<Td>")
                        Dim gType As System.Type = Row(i).GetType()
                        If gType.ToString() = "System.DateTime" Then
                            Response.Write(String.Format("{0:dd/MM/yyyy}", CType(Row(i).ToString(), Date)))
                        Else
                            Response.Write(Row(i).ToString())
                        End If
                        Response.Write("</Td>")
                    Next
                    Response.Write("</TR>")
                Next
                Response.Write("</Table>")
                Response.Write("</font>")
                Response.Flush()
                Response.End()

            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace

