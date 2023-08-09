Imports System.IO
Imports Aspose.Pdf
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WStatFileUpload
        Inherits clsWBase
        Private objBFile As New clsBEFile
        Private objBItem As New clsBItem
        Private objBItemCollection As New clsBItemCollection
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            'Call BindDropDownList()
            If Not Page.IsPostBack Then
                Session("pageIndex") = 0
                txtDateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy")
                txtTimeFrom.Text = "00:00:00"
                txtDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy")
                txtTimeTo.Text = "23:59:59"

                BindDDL()

                BindData()
                'If LoadYearMonth() Then
                '    Call DrawDayStat(CInt(hidYear.Value), CInt(hidMonth.Value))
                '    ' WriteLog
                '    Call WriteLog(76, ddlLabel.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                'End If
            End If
        End Sub

        Private Sub BindDDL()
            Dim tblResult As DataTable = objBItem.GetListCataloguer()
            ddlCataloguer.Items.Clear()
            ddlCataloguer.Items.Add(New ListItem("----- Tất cả -----", ""))
            If (Not IsNothing(tblResult)) Then
                For Each item As DataRow In tblResult.Rows
                    ddlCataloguer.Items.Add(New ListItem(item("Cataloguer"), item("Cataloguer")))
                Next
                ddlCataloguer.DataBind()
            End If
        End Sub

        Public Sub CheckFormPemission()
            If Not CheckPemission(163) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBFile object
            objBFile.ConnectionString = Session("ConnectionString")
            objBFile.DBServer = Session("DBServer")
            objBFile.InterfaceLanguage = Session("InterfaceLanguage")
            objBFile.Initialize()

            ' Init objBItem object
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.DBServer = Session("DBServer")
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.Initialize()

            ' Init objBItemCollection object
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Statistic/WStatic.js'></script>")
            SetOnclickCalendar(lnkCheckInDateFrom, txtDateFrom, ddlLabel.Items(1).Text)
            SetOnclickCalendar(lnkCheckInDateTo, txtDateTo, ddlLabel.Items(1).Text)
        End Sub


        Private Sub BindData()
            Dim strCateloguer As String = ddlCataloguer.SelectedItem.Value

            Dim strDateTimeFrom As String = ""
            Dim strDateTimeTo As String = ""

            If txtDateFrom.Text <> "" Then
                strDateTimeFrom = txtDateFrom.Text + " " + txtTimeFrom.Text
            End If

            If txtDateTo.Text <> "" Then
                strDateTimeTo = txtDateTo.Text + " " + txtTimeTo.Text
            End If

            Dim intStatus As Integer = CType(If(String.IsNullOrEmpty(ddlStatus.SelectedItem.Value), "3", ddlStatus.SelectedItem.Value), Integer)
            Dim intType As Integer = CType(If(String.IsNullOrEmpty(ddlType.SelectedItem.Value), "0", ddlType.SelectedItem.Value), Integer)

            Dim tblResult As DataTable = objBFile.StatisFileUpload(strCateloguer, strDateTimeFrom, strDateTimeTo, intStatus, intType)
            Session("tblResult") = tblResult
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then

                Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                newColumn.DefaultValue = "1"
                tblResult.Columns.Add(newColumn)

                newColumn = New Data.DataColumn("StatusDetail", GetType(System.String))
                newColumn.DefaultValue = ""
                tblResult.Columns.Add(newColumn)

                Dim indexRows As Integer = 1
                For Each rows As DataRow In tblResult.Rows
                    If (Not (rows.RowState = DataRowState.Deleted)) Then
                        rows.Item("STT") = indexRows.ToString()
                        indexRows = indexRows + 1

                        If Not (String.IsNullOrEmpty(rows.Item("Status"))) Then
                            If rows.Item("Status").ToString() = "-1" Then
                                rows.Item("StatusDetail") = "Chưa xử lý"
                            End If
                            If rows.Item("Status").ToString() = "0" Then
                                rows.Item("StatusDetail") = "Thành công"
                            End If
                            If rows.Item("Status").ToString() = "1" Then
                                rows.Item("StatusDetail") = "Lỗi xử lý"
                            End If
                            If rows.Item("Status").ToString() = "2" Then
                                rows.Item("StatusDetail") = "Đang xử lý"
                            End If
                        End If

                        'If (rows.Item("CountPage").ToString() = "0") AndAlso (rows.Item("Status").ToString() = "0") Then
                        '    Dim countPage As Integer = clsWCommon.GetCountPageFile(rows.Item("PathFile").ToString, rows.Item("Extention").ToString.ToLower)
                        '    rows.Item("CountPage") = countPage
                        '    objBItem.UpdateCountPage(CInt(rows.Item("ID")), countPage)
                        'End If
                        Dim licenseFile As String = Path.Combine(Server.MapPath("~") & "\bin\", "Aspose.Pdf.lic")
                        If (File.Exists(licenseFile)) Then
                            Dim countPage As Integer
                            Dim pdfDocument As Document
                            Dim strPathFile As String = rows.Item("PathFile").ToString
                            Dim strExtention As String = rows.Item("Extention").ToString.ToLower
                            If (File.Exists(rows.Item("PathFile").ToString())) Then
                                If (strExtention <> ".mp4") Then
                                    pdfDocument = New Document(strPathFile)
                                    countPage = pdfDocument.Pages.Count
                                    rows.Item("CountPage") = countPage
                                    Else
                                        rows.Item("CountPage") = 0
                                        countPage = 0
                                End If
                            Else
                                rows.Item("CountPage") = 0
                                countPage = 0
                            End If

                            objBItem.UpdateCountPage(CInt(rows.Item("ID")), countPage)
                        End If
                        
                    End If
                Next

                dtgStatis.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                dtgStatis.DataSource = tblResult
                dtgStatis.DataBind()
            Else
                Session("pageIndex") = 0
                dtgStatis.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                dtgStatis.DataSource = Nothing
                dtgStatis.DataBind()
            End If
        End Sub


        Protected Sub btnStatic_Click(sender As Object, e As EventArgs) Handles btnStatic.Click
            Session("pageIndex") = 0
            BindData()
        End Sub

        Protected Sub dtgStatis_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgStatis.PageIndexChanging
            Session("pageIndex") = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            Dim strSelectedIDs As String = hidListIDCheck.Value
            If strSelectedIDs <> "" Then
                objBItemCollection.IsAuthority = 0
                objBItemCollection.ItemIDs = strSelectedIDs
                objBItemCollection.DeleteItem()
                Page.RegisterClientScriptBlock("DeleteResult", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("DeleteResult", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            End If
        End Sub

        ' Page_UnLoad event    
        ' Purpose: Unload the page and dispose the elements
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBFile Is Nothing Then
                    objBFile.Dispose(True)
                    objBFile = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
        Protected Sub btnExportWord_Click(sender As Object, e As EventArgs) Handles btnExportWord.Click
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
            Dim tblResult As DataTable = Session("tblResult")
            Dim totalRecord As Double = 0
            Dim totalCopyNumber As Double = 0
            ResultSearch(tblResult, totalRecord, totalCopyNumber)
            Dim tblConvert As New DataTable("tblConvert")
            totalCopyNumber = 0
            ConvertTable(tblResult, tblConvert, totalRecord, totalCopyNumber)
            tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(6).Text)

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
        End Sub
         Private Sub ResultSearch(ByVal tblResult As DataTable, ByRef totalRecord As Double, ByRef totalCopyNumber As Double)
            Try

                Dim testcount As Integer = tblResult.Rows.Count
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

                dtgStatis.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                dtgStatis.DataSource = tblConvert
                dtgStatis.DataBind()
            Catch ex As Exception

            End Try
        End Sub
         Private Sub ConvertTable(ByVal tblResult As DataTable, ByRef tblConvert As DataTable, ByRef totalRecord As Double, ByRef totalCopyNumber As Double)
            If (Not IsNothing(tblResult)) AndAlso (tblResult.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("DateUpload")
                'tblConvert.Columns.Add("Cataloguer")
                tblConvert.Columns.Add("CountPage")
                totalRecord = CType(tblResult.Rows.Count, Double)

                
                For Each rows As DataRow In tblResult.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    'Dim content245 As String = rows.Item("Content245").ToString()
                    'Dim content082 As String = rows.Item("Content082").ToString()
                    'Dim content260 As String = rows.Item("Content260").ToString()
                    'Dim content300 As String = rows.Item("Content300").ToString()
                    Dim content As String = rows.Item("Content").ToString()
                    Dim title As String = rows.Item("Content")
                    Dim FileName As String = rows.Item("FileName")
                    Dim DateUpload As String = CDate(rows.Item("DateUpload")).ToString("dd/MM/yyyy")
                    'Dim Cataloguer As String = rows.Item("Cataloguer")
                    Dim StatusDetail As String = rows.Item("StatusDetail")
                    Dim CountPage As String = rows.Item("CountPage")
                    Dim stt As String = rows.Item("STT")
                    Dim author As String = ""
                    Dim Tittle As String = ""
                     If content.Contains("/") Then
                        Dim split() As String = content.Split("/")
                        title = split(0).ToString.Trim
                        author = split(1).ToString.Trim
                        Else
                        title = content.Trim
                        author =""
                     End If
                    

                    dtRow.Item("STT") = stt
                    dtRow.Item("Title") = title
                    dtRow.Item("Author") = author
                    dtRow.Item("DateUpload") = DateUpload
                    'dtRow.Item("Cataloguer") = Cataloguer
                    'dtRow.Item("StatusDetail") = StatusDetail
                    dtRow.Item("CountPage") = CountPage
                    tblConvert.Rows.Add(dtRow)
                Next
            End If

        End Sub

    End Class
End Namespace

