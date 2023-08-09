Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WDeliveredCheckOut
        Inherits clsWBase

        Private objBCopyNumber As New clsBCopyNumber
        Private objBCDBS As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Page.IsPostBack = False Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Sub Initialize()
            ' Init objBCopyNumber object
            objBCopyNumber.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyNumber.DBServer = Session("DBServer")
            objBCopyNumber.ConnectionString = Session("ConnectionString")
            Call objBCopyNumber.Initialize()
            ' Init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDate, txtDate, ddlLabel.Items(3).Text)
        End Sub


        Public Sub BindData()

            Dim strIDs As String = Request.QueryString("strIDs")

            objBCopyNumber.LibID = clsSession.GlbSite
            Dim tblData As DataTable = objBCopyNumber.GetHoldingDevered(strIDs)

            Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
            newColumn.DefaultValue = "1"
            tblData.Columns.Add(newColumn)
            Dim indexRows As Integer = 1
            For Each rows As DataRow In tblData.Rows
                If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                    rows.Item("STT") = indexRows.ToString()
                    indexRows = indexRows + 1
                End If
            Next

            Dim tblConvert As New DataTable("tblConvert")
            ConvertTable(tblData, tblConvert)

            If tblConvert.Rows.Count > 0 Then
                dtgDelivered.DataSource = tblConvert
                dtgDelivered.DataBind()
            Else
                dtgDelivered.DataSource = Nothing
                dtgDelivered.DataBind()
            End If
        End Sub

        Public Sub ConvertTable(ByVal tblData As DataTable, ByRef tblConvert As DataTable)
            If (Not IsNothing(tblData)) AndAlso (tblData.Rows.Count > 0) Then
                tblConvert.Clear()
                tblConvert.Columns.Add("STT")
                tblConvert.Columns.Add("CopyNumber")
                tblConvert.Columns.Add("Title")
                tblConvert.Columns.Add("Author")
                tblConvert.Columns.Add("Classification")
                tblConvert.Columns.Add("AcquireSource")
                tblConvert.Columns.Add("AdditionalBy")

                For Each rows As DataRow In tblData.Rows
                    Dim dtRow As DataRow = tblConvert.NewRow()

                    Dim content245 As String = rows.Item("Title").ToString()
                    Dim content082 As String = rows.Item("Classification").ToString()
                    Dim content100 As String = rows.Item("Author").ToString()

                    Dim title As String = ""
                    Dim author As String = ""
                    Dim classification As String = ""

                    If content245.Contains("$a") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                title = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    If content100.Contains("$a") Then
                        Dim split() As String = content245.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                title = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If


                    If content082.Contains("$a") Then
                        Dim split() As String = content082.Split("$")
                        For Each iSplit As String In split
                            If Not String.IsNullOrEmpty(iSplit) AndAlso iSplit(0) = "a" Then
                                classification = iSplit.Substring(1).Trim()
                                Exit For
                            End If
                        Next
                    End If

                    Dim stt As String = rows.Item("STT")
                    Dim strCopyNumber As String = rows.Item("CopyNumber") & ""
                    Dim strAcquireSource As String = rows.Item("AcquireSource") & ""
                    Dim strAdditionalBy As String = rows.Item("AdditionalBy") & ""

                    dtRow.Item("STT") = stt
                    dtRow.Item("CopyNumber") = strCopyNumber
                    dtRow.Item("Title") = title
                    dtRow.Item("Author") = author
                    dtRow.Item("Classification") = classification
                    dtRow.Item("AcquireSource") = strAcquireSource
                    dtRow.Item("AdditionalBy") = strAdditionalBy

                    tblConvert.Rows.Add(dtRow)
                Next
            End If
        End Sub
        Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
            Dim strIDs As String = Request.QueryString("strIDs")

            objBCopyNumber.LibID = clsSession.GlbSite
            Dim tblData As DataTable = objBCopyNumber.GetHoldingDevered(strIDs)

            Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
            newColumn.DefaultValue = "1"
            tblData.Columns.Add(newColumn)
            Dim indexRows As Integer = 1
            For Each rows As DataRow In tblData.Rows
                If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                    rows.Item("STT") = indexRows.ToString()
                    indexRows = indexRows + 1
                End If
            Next

            Dim tblConvert As New DataTable("tblConvert")
            ConvertTable(tblData, tblConvert)
            tblConvert.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text,
                                ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text, ddlLabelHeaderTable.Items(6).Text)


            Dim wordHelper As New clsBExportHelper

            Dim strHTMLContent As New StringBuilder()

            strHTMLContent.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='www.w3.org/TR/REC-html40'>")
            strHTMLContent.Append("<head>")
            strHTMLContent.Append("<!--[if gte mso 9]>")
            strHTMLContent.Append("<xml>" & clsBExportHelper.Xml_Word() & "</xml>")
            strHTMLContent.Append("<![endif]-->")
            strHTMLContent.Append("<style>" & clsBExportHelper.css_word("1.0in", "1.25in", " 1.0in", "1.25in", True) & "</style>")
            strHTMLContent.Append("</head>")
            strHTMLContent.Append("<body>")
            strHTMLContent.Append("<div class=Section2>")
            strHTMLContent.Append("<br/>")
            strHTMLContent.Append("<p>" & clsBExportHelper.GenHeader(hidLeftTable.Value, hidRightTable.Value, hidTitleTable.Value) & "</p>")
            strHTMLContent.Append("<p>" & hidTimes.Value & txtDate.Text & "</p>")
            strHTMLContent.Append("<p>" & hidSender.Value & txtSender.Text & "</p>")
            strHTMLContent.Append("<p>" & hidReceiver.Value & txtReceiver.Text & "</p>")
            strHTMLContent.Append("<p>" & hidDetailList.Value & "</p>")
            strHTMLContent.Append("<p>" & clsBExportHelper.GenDataTableToString(tblConvert) & "</p>")
            strHTMLContent.Append("</div></body></html>")

            Response.ClearContent()
            Response.AppendHeader("content-disposition", "attachment;filename=export_" & DateTime.Now.Year.ToString() & DateTime.Now.Month.ToString() & DateTime.Now.Day.ToString() & DateTime.Now.Hour.ToString() & DateTime.Now.Minute.ToString() & DateTime.Now.Second.ToString() & DateTime.Now.Millisecond.ToString() & ".doc")
            Response.Charset = "UTF-8"
            Response.Cache.SetCacheability(HttpCacheability.NoCache)
            Response.ContentType = "application/msword"
            Response.ContentEncoding = Encoding.Unicode
            Response.BinaryWrite(Encoding.Unicode.GetPreamble())
            Response.Write(strHTMLContent)
            Response.End()
            Response.Flush()
        End Sub

        Protected Sub btnDeliveredSend_Click(sender As Object, e As EventArgs) Handles btnDeliveredSend.Click

            Dim strIDs As String = Request.QueryString("strIDs")

            Dim strDate As String = txtDate.Text
            If strDate <> "" Then strDate = objBCDBS.ConvertDateBack(strDate)

            objBCopyNumber.LibID = clsSession.GlbSite
            objBCopyNumber.UpdateholdingDeliveredSuccess(strIDs, clsSession.GlbUser, strDate, txtSender.Text, txtReceiver.Text)

            If objBCopyNumber.ErrorMsg = "" Then
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(4).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(5).Text & "');</script>")
            End If

        End Sub
    End Class
End Namespace

