Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WRoomsBooking
        Inherits clsWBase

        Private objBRoomsBooking As New clsBRoomsBooking
        Private objBRooms As New clsBRooms
        Private objBCDBS As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJS()
            Call Initialize()
            If Not Page.IsPostBack Then
                'Active
                If Not IsNothing(Request.QueryString("ActiveId")) Then
                    Dim intId As Integer = CInt(Request.QueryString("ActiveId"))
                    objBRoomsBooking.RoomsBookingID = CInt(Request.QueryString("ActiveId"))
                    Dim intResult As Integer = objBRoomsBooking.Active()

                    If intResult = 1 Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbActiveSuccess.Text & "')</script>")

                        objBRoomsBooking.RoomsBookingID = CInt(Request.QueryString("ActiveId"))
                        Dim tblDataInfo As DataTable = objBRoomsBooking.GetRoomsBookingById()

                        Dim strContent As String = LiteralContentMailActive.Text

                        strContent = strContent.Replace("<$FullName$>", tblDataInfo.Rows(0).Item("FullName"))
                        strContent = strContent.Replace("<$Code$>", tblDataInfo.Rows(0).Item("Code"))
                        strContent = strContent.Replace("<$Email$>", tblDataInfo.Rows(0).Item("Email"))

                        strContent = strContent.Replace("<$BookingDate$>", String.Format("{0:dd/MM/yyyy}", tblDataInfo.Rows(0).Item("BookingDate")))
                        strContent = strContent.Replace("<$TimeRange$>", tblDataInfo.Rows(0).Item("TimeStart") & " - " & tblDataInfo.Rows(0).Item("TimeEnd"))
                        strContent = strContent.Replace("<$RoomName$>", tblDataInfo.Rows(0).Item("RoomName"))

                        Dim intSendMail As Integer = Send2Mail(String.Format(lbSubjectEmailActive.Text, tblDataInfo.Rows(0).Item("Code"), tblDataInfo.Rows(0).Item("FullName")), strContent, tblDataInfo.Rows(0).Item("Email"))

                    Else
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbActiveError.Text & "')</script>")
                    End If
                End If

                'Cancel
                If Not IsNothing(Request.QueryString("CancelId")) Then
                    Dim intId As Integer = CInt(Request.QueryString("CancelId"))
                    objBRoomsBooking.RoomsBookingID = CInt(Request.QueryString("CancelId"))
                    Dim intResult As Integer = objBRoomsBooking.Cancel()

                    If intResult = 1 Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCancelSuccess.Text & "')</script>")

                        objBRoomsBooking.RoomsBookingID = CInt(Request.QueryString("CancelId"))
                        Dim tblDataInfo As DataTable = objBRoomsBooking.GetRoomsBookingById()

                        Dim strContent As String = LiteralContentMailCancel.Text

                        strContent = strContent.Replace("<$FullName$>", tblDataInfo.Rows(0).Item("FullName"))
                        strContent = strContent.Replace("<$Code$>", tblDataInfo.Rows(0).Item("Code"))
                        strContent = strContent.Replace("<$Email$>", tblDataInfo.Rows(0).Item("Email"))

                        strContent = strContent.Replace("<$BookingDate$>", String.Format("{0:dd/MM/yyyy}", tblDataInfo.Rows(0).Item("BookingDate")))
                        strContent = strContent.Replace("<$TimeRange$>", tblDataInfo.Rows(0).Item("TimeStart") & " - " & tblDataInfo.Rows(0).Item("TimeEnd"))
                        strContent = strContent.Replace("<$RoomName$>", tblDataInfo.Rows(0).Item("RoomName"))

                        Dim intSendMail As Integer = Send2Mail(String.Format(lbSubjectEmailCancel.Text, tblDataInfo.Rows(0).Item("Code"), tblDataInfo.Rows(0).Item("FullName")), strContent, tblDataInfo.Rows(0).Item("Email"))
                    Else
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCancelError.Text & "')</script>")
                    End If
                End If

                Call BindDLLRooms()
                Call BindDataHistory()
            End If
        End Sub

        Private Sub Initialize()
            ' Init objBRoomsBooking object
            objBRoomsBooking.InterfaceLanguage = Session("InterfaceLanguage")
            objBRoomsBooking.DBServer = Session("DBServer")
            objBRoomsBooking.ConnectionString = Session("ConnectionString")
            Call objBRoomsBooking.Initialize()
            ' Init objBRooms object
            objBRooms.InterfaceLanguage = Session("InterfaceLanguage")
            objBRooms.DBServer = Session("DBServer")
            objBRooms.ConnectionString = Session("ConnectionString")
            Call objBRooms.Initialize()
            ' Init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        Private Sub BindJS()
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>", False)

            txtDateFrom.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtDateFrom.ToolTip = Session("DateFormat")
            txtDateTo.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtDateTo.ToolTip = Session("DateFormat")
            txtBookingDate.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtBookingDate.ToolTip = Session("DateFormat")

            Me.RegisterCalendar("../..")

            'Link bind
            SetOnclickCalendar(lnkDateFrom, txtDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkDateTo, txtDateTo, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkBookingDate, txtBookingDate, ddlLabel.Items(4).Text)

        End Sub

        Private Sub BindDataHistory()
            objBRoomsBooking.BookingDate = If(txtBookingDate.Text <> "", String.Format("{0:yyyy-MM-dd}", Date.Parse(txtBookingDate.Text)), "")
            objBRoomsBooking.RoomID = ddlRooms.SelectedValue
            Dim tblData As DataTable = objBRoomsBooking.GetRoomsBooking(txtPatronCode.Text, If(txtDateFrom.Text <> "", String.Format("{0:yyyy-MM-dd}", Date.Parse(txtDateFrom.Text)), ""), If(txtDateTo.Text <> "", String.Format("{0:yyyy-MM-dd}", Date.Parse(txtDateTo.Text)), ""))
            If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then
                Dim tblHistory As New DataTable()
                tblHistory.Columns.Add("STT")
                tblHistory.Columns.Add("ID")
                tblHistory.Columns.Add("Code")
                tblHistory.Columns.Add("FullName")
                tblHistory.Columns.Add("Email")
                tblHistory.Columns.Add("RoomName")
                tblHistory.Columns.Add("BookingDate")
                tblHistory.Columns.Add("TimeStart")
                tblHistory.Columns.Add("TimeEnd")
                tblHistory.Columns.Add("Note")
                tblHistory.Columns.Add("BookingStatus")
                tblHistory.Columns.Add("Faculty")
                tblHistory.Columns.Add("TypeRoom")
                tblHistory.Columns.Add("Count")
                tblHistory.Columns.Add("ListCode")
                tblHistory.Columns.Add("Uses")
                tblHistory.Columns.Add("RequestOther")

                For i As Integer = 0 To tblData.Rows.Count - 1 Step 1
                    Dim rowData As DataRow = tblHistory.NewRow()

                    rowData.Item("STT") = i + 1
                    rowData.Item("ID") = tblData.Rows(i).Item("ID")
                    rowData.Item("Code") = tblData.Rows(i).Item("Code")
                    rowData.Item("FullName") = tblData.Rows(i).Item("FullName")
                    rowData.Item("Email") = tblData.Rows(i).Item("Email")
                    rowData.Item("RoomName") = tblData.Rows(i).Item("RoomName")
                    rowData.Item("BookingDate") = String.Format("{0:dd/MM/yyyy}", tblData.Rows(i).Item("BookingDate"))
                    rowData.Item("TimeStart") = tblData.Rows(i).Item("TimeStart")
                    rowData.Item("TimeEnd") = tblData.Rows(i).Item("TimeEnd")
                    If tblData.Rows(i).Item("Note") & "" = "" Then
                        If tblData.Rows(i).Item("BookingStatus") = "1" Then
                            rowData.Item("Note") = lbMsgActive.Text
                        End If
                        If tblData.Rows(i).Item("BookingStatus") = "-1" Then
                            rowData.Item("Note") = lbMsgCancel.Text
                        End If
                    Else
                        rowData.Item("Note") = tblData.Rows(i).Item("Note")
                    End If
                    rowData.Item("BookingStatus") = tblData.Rows(i).Item("BookingStatus")

                    rowData.Item("Faculty") = tblData.Rows(i).Item("Faculty")
                    rowData.Item("TypeRoom") = ""
                    If tblData.Rows(i).Item("TypeRoom") & "" = "0" Then
                        rowData.Item("TypeRoom") = ddlTypeRoom.Items(0).Text
                    End If
                    If tblData.Rows(i).Item("TypeRoom") & "" = "1" Then
                        rowData.Item("TypeRoom") = ddlTypeRoom.Items(1).Text
                    End If
                    rowData.Item("Count") = tblData.Rows(i).Item("Count")
                    rowData.Item("ListCode") = tblData.Rows(i).Item("ListCode")
                    rowData.Item("Uses") = tblData.Rows(i).Item("Uses")
                    rowData.Item("RequestOther") = tblData.Rows(i).Item("RequestOther")
                    tblHistory.Rows.Add(rowData)
                Next
                GridViewHistory.DataSource = tblHistory
                GridViewHistory.DataBind()
            Else

                GridViewHistory.DataSource = Nothing
                GridViewHistory.DataBind()
            End If
        End Sub

        Private Sub BindDLLRooms()
            Dim tblData As DataTable = objBRooms.GetAllRooms()
            If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then

                ddlRooms.Items.Clear()
                ddlRooms.Items.Add(New ListItem(ddlLabel.Items(5).Text, "0"))
                For Each row As DataRow In tblData.Rows
                    ddlRooms.Items.Add(New ListItem(row.Item("RoomName"), row.Item("ID")))
                Next
                ddlRooms.DataBind()
            End If
        End Sub


        Protected Sub GridViewHistory_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridViewHistory.RowEditing
            GridViewHistory.EditIndex = e.NewEditIndex
            BindDataHistory()
        End Sub

        Protected Sub GridViewHistory_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridViewHistory.RowUpdating
            Dim intRoomBookingID As Integer = GridViewHistory.DataKeys(e.RowIndex).Value
            Dim txtBookingDateGV As TextBox = CType(GridViewHistory.Rows(e.RowIndex).Cells(11).Controls(0), TextBox)
            Dim txtTimeStartGV As TextBox = CType(GridViewHistory.Rows(e.RowIndex).Cells(12).Controls(0), TextBox)
            Dim txtTimeEndGV As TextBox = CType(GridViewHistory.Rows(e.RowIndex).Cells(13).Controls(0), TextBox)
            Dim txtNoteGV As TextBox = CType(GridViewHistory.Rows(e.RowIndex).Cells(14).Controls(0), TextBox)

            objBRoomsBooking.RoomsBookingID = intRoomBookingID
            objBRoomsBooking.BookingDate = String.Format("{0:yyyy-MM-dd}", Date.Parse(txtBookingDateGV.Text))
            objBRoomsBooking.TimeStart = txtTimeStartGV.Text
            objBRoomsBooking.TimeEnd = txtTimeEndGV.Text
            objBRoomsBooking.Note = txtNoteGV.Text
            Dim intResult As Integer = objBRoomsBooking.Update()
            If intResult = 1 Then

                Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbUpdateSuccess.Text & "');</script>")

                GridViewHistory.EditIndex = -1
                BindDataHistory()
            Else
                Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbMsgValidBusyTime.Text & "');</script>")
            End If

        End Sub

        Protected Sub GridViewHistory_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridViewHistory.RowCancelingEdit
            GridViewHistory.EditIndex = -1
            BindDataHistory()
        End Sub
        Protected Sub GridViewHistory_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewHistory.RowDataBound
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim hidStatus As HiddenField = CType(e.Row.Cells(10).FindControl("hidStatus"), HiddenField)
                If hidStatus IsNot Nothing Then
                    Dim linkActive As HyperLink = CType(e.Row.Cells(10).FindControl("linkActive"), HyperLink)
                    Dim linkCancel As HyperLink = CType(e.Row.Cells(10).FindControl("linkCancel"), HyperLink)
                    If hidStatus.Value = "1" Or hidStatus.Value = "-1" Then
                        linkActive.Visible = False
                        linkCancel.Visible = False
                    Else
                        linkActive.Visible = True
                        linkCancel.Visible = True
                        Dim hidID As String = GridViewHistory.DataKeys(e.Row.RowIndex).Value
                        linkActive.Attributes.Add("onclick", "ActiveRoomsBooking('" & hidID & "')")
                        linkActive.Attributes.Add("href", "javascript:void('" & hidID & "')")
                        linkCancel.Attributes.Add("onclick", "CancelRoomsBooking('" & hidID & "')")
                        linkCancel.Attributes.Add("href", "javascript:void('" & hidID & "')")
                    End If
                End If
            End If
        End Sub

        Protected Sub GridViewHistory_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewHistory.PageIndexChanging
            GridViewHistory.PageIndex = e.NewPageIndex
            BindDataHistory()
        End Sub

        Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
            GridViewHistory.EditIndex = -1
            GridViewHistory.PageIndex = 0
            BindDataHistory()
        End Sub

        Protected Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

            Dim tblHistory As New DataTable()
            objBRoomsBooking.BookingDate = If(txtBookingDate.Text <> "", String.Format("{0:yyyy-MM-dd}", Date.Parse(txtBookingDate.Text)), "")
            objBRoomsBooking.RoomID = ddlRooms.SelectedValue
            Dim tblData As DataTable = objBRoomsBooking.GetRoomsBooking(txtPatronCode.Text, If(txtDateFrom.Text <> "", String.Format("{0:yyyy-MM-dd}", Date.Parse(txtDateFrom.Text)), ""), If(txtDateTo.Text <> "", String.Format("{0:yyyy-MM-dd}", Date.Parse(txtDateTo.Text)), ""))
            If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then
                tblHistory.Columns.Add("Index")
                tblHistory.Columns.Add("Code")
                tblHistory.Columns.Add("FullName")
                tblHistory.Columns.Add("Email")
                tblHistory.Columns.Add("Faculty")
                tblHistory.Columns.Add("TypeRoom")
                tblHistory.Columns.Add("Uses")
                tblHistory.Columns.Add("RequestOther")
                tblHistory.Columns.Add("Count")
                tblHistory.Columns.Add("ListCode")
                tblHistory.Columns.Add("BookingDate")
                tblHistory.Columns.Add("TimeStart")
                tblHistory.Columns.Add("TimeEnd")

                For i As Integer = 0 To tblData.Rows.Count - 1 Step 1
                    Dim rowData As DataRow = tblHistory.NewRow()

                    rowData.Item("Index") = i + 1
                    rowData.Item("Code") = tblData.Rows(i).Item("Code")
                    rowData.Item("FullName") = tblData.Rows(i).Item("FullName")
                    rowData.Item("Email") = tblData.Rows(i).Item("Email")
                    rowData.Item("Faculty") = tblData.Rows(i).Item("Faculty")
                    rowData.Item("TypeRoom") = ""
                    If tblData.Rows(i).Item("TypeRoom") & "" = "0" Then
                        rowData.Item("TypeRoom") = ddlTypeRoom.Items(0).Text
                    End If
                    If tblData.Rows(i).Item("TypeRoom") & "" = "1" Then
                        rowData.Item("TypeRoom") = ddlTypeRoom.Items(1).Text
                    End If
                    rowData.Item("Uses") = tblData.Rows(i).Item("Uses")
                    rowData.Item("RequestOther") = tblData.Rows(i).Item("RequestOther")
                    rowData.Item("Count") = tblData.Rows(i).Item("Count")
                    rowData.Item("ListCode") = tblData.Rows(i).Item("ListCode")
                    rowData.Item("BookingDate") = String.Format("{0:dd/MM/yyyy}", tblData.Rows(i).Item("BookingDate"))
                    rowData.Item("TimeStart") = tblData.Rows(i).Item("TimeStart")
                    rowData.Item("TimeEnd") = tblData.Rows(i).Item("TimeEnd")

                    tblHistory.Rows.Add(rowData)
                Next
            End If

            If Not tblHistory Is Nothing AndAlso tblHistory.Rows.Count > 0 Then

                tblHistory.Rows.Add(ddlLabelHeaderTable.Items(0).Text, ddlLabelHeaderTable.Items(1).Text, ddlLabelHeaderTable.Items(2).Text, ddlLabelHeaderTable.Items(3).Text, ddlLabelHeaderTable.Items(4).Text, ddlLabelHeaderTable.Items(5).Text,
                                    ddlLabelHeaderTable.Items(6).Text, ddlLabelHeaderTable.Items(7).Text, ddlLabelHeaderTable.Items(8).Text, ddlLabelHeaderTable.Items(9).Text, ddlLabelHeaderTable.Items(10).Text, ddlLabelHeaderTable.Items(11).Text,
                                    ddlLabelHeaderTable.Items(12).Text)

                Dim strHTMLContent As New StringBuilder()
                strHTMLContent.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%'><tr><td>")
                strHTMLContent.Append(clsBExportHelper.GenHeader(lbHeaderLeft.Text, lbHeaderRight.Text, If(txtDateFrom.Text <> "" And txtDateTo.Text <> "", lbHeaderTitle.Text & String.Format(lbHeaderFromTo, txtDateFrom.Text, txtDateTo.Text), lbHeaderTitle.Text)))
                strHTMLContent.Append("</td></tr>")
                strHTMLContent.Append("<tr><td>")
                strHTMLContent.Append(clsBExportHelper.GenDataTableToString(tblHistory))
                strHTMLContent.Append("</td></tr>")
                strHTMLContent.Append("<tr><td>")
                strHTMLContent.Append(clsBExportHelper.GenFooterCenter("", String.Format(lbFooterRight.Text, Date.Now)))
                strHTMLContent.Append("</td></tr>")
                strHTMLContent.Append("</table>")


                Response.ClearContent()
                Response.AppendHeader("content-disposition", "attachment;filename=export_" & DateTime.Now.Year.ToString() & DateTime.Now.Month.ToString() & DateTime.Now.Day.ToString() & DateTime.Now.Hour.ToString() & DateTime.Now.Minute.ToString() & DateTime.Now.Second.ToString() & DateTime.Now.Millisecond.ToString() & ".doc")
                Response.Charset = "UTF-8"
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = "application/msword"
                Response.ContentEncoding = Encoding.Unicode
                Response.BinaryWrite(Encoding.Unicode.GetPreamble())

                Dim strHTMLContentWord As New StringBuilder()

                strHTMLContentWord.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns='www.w3.org/TR/REC-html40'>")
                strHTMLContentWord.Append("<head>")
                strHTMLContentWord.Append("<!--[if gte mso 9]>")
                strHTMLContentWord.Append("<xml>" & clsBExportHelper.Xml_Word() & "</xml>")
                strHTMLContentWord.Append("<![endif]-->")
                strHTMLContentWord.Append("<style>" & clsBExportHelper.css_word(True) & "</style>")
                strHTMLContentWord.Append("</head>")
                strHTMLContentWord.Append("<body>")
                strHTMLContentWord.Append("<div class=Section2>")
                strHTMLContentWord.Append("<p>" & strHTMLContent.ToString() & "</p>")
                strHTMLContentWord.Append("</div></body></html>")

                Response.Write(strHTMLContentWord)
                Response.End()
                Response.Flush()
            Else
            End If
        End Sub

    End Class

End Namespace
