Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ORegisterBooking
        Inherits clsWBaseJqueryUI

        Private objBOPACRooms As New clsBOPACRooms
        Private objBOPACRoomsBooking As New clsBOPACRoomsBooking
        Private objBCDBS As New clsBCommonDBSystem

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If String.IsNullOrEmpty(clsSession.GlbUser) Then
                Response.Redirect("OLoginRequest.aspx?RequestLogin=1", False)
            Else
                Call Initialize()
                Call BindJS()
                If Page.IsPostBack = False Then
                    lbFullName.Text = clsSession.GlbUserFullName
                    lbEmail.Text = clsSession.GlbEmail
                    lbPatronCode.Text = clsSession.GlbUser
                    hidDate.Value = String.Format("{0:dd/MM/yyyy}", Date.Now)
                    Call BindDataRooms()
                    Call BindTimeBusy()
                    Call BindHistory()
                End If
            End If
        End Sub

        Private Sub Initialize()
            ' Init objBOPACRooms object
            objBOPACRooms.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACRooms.DBServer = Session("DBServer")
            objBOPACRooms.ConnectionString = Session("ConnectionString")
            Call objBOPACRooms.Initialize()

            ' init objBOPACRoomsBooking object
            objBOPACRoomsBooking.InterfaceLanguage = Session("InterfaceLanguage")
            objBOPACRoomsBooking.DBServer = Session("DBServer")
            objBOPACRoomsBooking.ConnectionString = Session("ConnectionString")
            Call objBOPACRoomsBooking.Initialize()

            ' init objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        Private Sub BindJS()
            txtCount.Attributes.Item("type") = "number"
        End Sub

        Private Sub BindDataRooms()
            Dim tblData As DataTable = objBOPACRooms.GetAllRooms()
            If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then
                Dim tblRooms As New DataTable()
                tblRooms.Columns.Add("Active")
                tblRooms.Columns.Add("RoomID")
                tblRooms.Columns.Add("RoomName")
                For i As Integer = 0 To tblData.Rows.Count - 1 Step 1
                    Dim rowData As DataRow = tblRooms.NewRow()
                    rowData("Active") = "clr-steel"
                    rowData("RoomID") = tblData.Rows(i).Item("ID")
                    rowData("RoomName") = tblData.Rows(i).Item("RoomName")
                    If i = 0 Then
                        rowData("Active") = "clr-steel active"
                        hidRoom.Value = tblData.Rows(i).Item("ID")
                    End If
                    tblRooms.Rows.Add(rowData)
                Next

                RepeaterListRoom.DataSource = tblRooms
                RepeaterListRoom.DataBind()
            Else
                RepeaterListRoom.DataSource = Nothing
                RepeaterListRoom.DataBind()
            End If
        End Sub

        Private Sub BindTimeBusy()
            objBOPACRoomsBooking.RoomID = hidRoom.Value
            Dim tblData As DataTable = objBOPACRoomsBooking.GetTimeBusyByDate(String.Format("{0:yyyy-MM-dd}", Date.Now))
            If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then
                ListTimesBusy.InnerHtml = ""
                For i As Integer = 0 To tblData.Rows.Count - 1 Step 1
                    If i = 0 Then
                        ListTimesBusy.InnerHtml = "<b>" & tblData.Rows(i).Item("TimesBusy") & "</b>"
                    Else
                        ListTimesBusy.InnerHtml = ListTimesBusy.InnerHtml & ", <b>" & tblData.Rows(i).Item("TimesBusy") & "</b>"
                    End If
                Next
            End If
        End Sub

        Private Sub BindHistory()
            Dim tblData As DataTable = objBOPACRoomsBooking.GetHistoryRoomBookingByPatronCode(clsSession.GlbUser)
            If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then
                Dim tblHistory As New DataTable()
                tblHistory.Columns.Add("STT")
                tblHistory.Columns.Add("ID")
                tblHistory.Columns.Add("RoomName")
                tblHistory.Columns.Add("BookingDate")
                tblHistory.Columns.Add("TimeStart")
                tblHistory.Columns.Add("TimeEnd")
                tblHistory.Columns.Add("StatusName")
                tblHistory.Columns.Add("Status")
                tblHistory.Columns.Add("DateCreate")
                For i As Integer = 0 To tblData.Rows.Count - 1 Step 1
                    Dim rowData As DataRow = tblHistory.NewRow()

                    rowData.Item("STT") = i + 1
                    rowData.Item("ID") = tblData.Rows(i).Item("ID")
                    rowData.Item("RoomName") = tblData.Rows(i).Item("RoomName")
                    rowData.Item("BookingDate") = String.Format("{0:dd/MM/yyyy}", tblData.Rows(i).Item("BookingDate"))
                    rowData.Item("TimeStart") = tblData.Rows(i).Item("TimeStart")
                    rowData.Item("TimeEnd") = tblData.Rows(i).Item("TimeEnd")
                    rowData.Item("Status") = tblData.Rows(i).Item("BookingStatus")
                    If tblData.Rows(i).Item("BookingStatus") = "1" Then
                        If tblData.Rows(i).Item("BookingDate") > Date.Now Then
                            rowData.Item("StatusName") = ddlStatus.Items(2).Text
                        Else
                            rowData.Item("StatusName") = ddlStatus.Items(3).Text
                        End If
                    Else
                        If tblData.Rows(i).Item("BookingStatus") = "-1" Then
                            rowData.Item("StatusName") = ddlStatus.Items(0).Text
                        Else
                            If tblData.Rows(i).Item("BookingDate") > Date.Now Then
                                rowData.Item("StatusName") = ddlStatus.Items(1).Text
                            Else
                                rowData.Item("StatusName") = ddlStatus.Items(3).Text
                            End If
                        End If

                    End If
                    rowData.Item("DateCreate") = String.Format("{0:dd/MM/yyyy}", tblData.Rows(i).Item("DateCreate"))
                    tblHistory.Rows.Add(rowData)
                Next
                GridViewHistory.DataSource = tblHistory
                GridViewHistory.DataBind()
            Else

                GridViewHistory.DataSource = Nothing
                GridViewHistory.DataBind()
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACRooms Is Nothing Then
                    objBOPACRooms.Dispose(True)
                    objBOPACRooms = Nothing
                End If
                If Not objBOPACRoomsBooking Is Nothing Then
                    objBOPACRoomsBooking.Dispose(True)
                    objBOPACRoomsBooking = Nothing
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

        Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            Dim strBookingDate As String = hidDate.Value
            Dim intRoomID As Integer = CInt(hidRoom.Value)
            Dim strTimes As String = hidTimes.Value
            Dim arrTime() As String = strTimes.Split(",")
            Dim intTimeStart As Integer = arrTime(0)
            Dim intTimeEnd As Integer = arrTime(1)

            If (intTimeEnd - intTimeStart = 2) Then
                objBOPACRoomsBooking.BookingDate = String.Format("{0:yyyy-MM-dd}", Date.Parse(strBookingDate))
                objBOPACRoomsBooking.RoomID = intRoomID
                objBOPACRoomsBooking.TimeStart = intTimeStart
                objBOPACRoomsBooking.TimeEnd = intTimeEnd
                objBOPACRoomsBooking.TypeRoom = ddlTypeRoom.SelectedValue
                objBOPACRoomsBooking.Uses = txtUses.Text
                objBOPACRoomsBooking.RequestOther = txtRequestOther.Text
                objBOPACRoomsBooking.Count = txtCount.Text
                objBOPACRoomsBooking.ListCode = txtListCode.Text
                objBOPACRoomsBooking.Note = ""
                Dim intResult As Integer = objBOPACRoomsBooking.Create(clsSession.GlbUser)
                If intResult = 1 Then

                    Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbMsgSuccess.Text & "');</script>")

                    Dim objPara() As String = {"EMAIL_REQUEST_ROOM_BOOKING"}
                    Dim objSysPara() As String = objBCDBS.GetSystemParameters(objPara)

                    Dim tblDataRooms As DataTable = objBOPACRooms.GetAllRooms()
                    tblDataRooms.DefaultView.RowFilter = "ID=" & intRoomID

                    Dim strContent As String = ContentMail.InnerHtml

                    strContent = strContent.Replace("<$FullName$>", clsSession.GlbUserFullName)
                    strContent = strContent.Replace("<$Code$>", clsSession.GlbUser)
                    strContent = strContent.Replace("<$Email$>", clsSession.GlbEmail)

                    strContent = strContent.Replace("<$BookingDate$>", strBookingDate)
                    strContent = strContent.Replace("<$TimeRange$>", intTimeStart & " - " & intTimeEnd)
                    strContent = strContent.Replace("<$RoomName$>", tblDataRooms.DefaultView(0).Item("RoomName"))

                    Dim intSendMail As Integer = Send2Mail(String.Format(lbSubjectEmail.Text, clsSession.GlbUser, clsSession.GlbUserFullName), strContent, objSysPara(0))

                    Call ResetForm()
                    Call BindTimeBusy()
                    Call BindHistory()
                Else
                    Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbMsgValidBusyTime.Text & "');</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbMsgValidCheckInTime.Text & "');</script>")
            End If


        End Sub

        Private Sub ResetForm()
            txtUses.Text = ""
            txtCount.Text = ""
            txtListCode.Text = ""
            txtRequestOther.Text = ""
            ddlTypeRoom.SelectedIndex = 0
            Call BindDataRooms()
        End Sub


        Protected Function IsVisible(ByVal intStatus As Boolean, ByVal strDate As String) As Boolean
            If intStatus = True Then
                Return False
            Else
                If Date.Parse(strDate) < Date.Now Then
                    Return False
                Else
                    Return True
                End If
            End If
        End Function

        Protected Sub GridViewHistory_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewHistory.RowDataBound
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim hidStatus As HiddenField = CType(e.Row.Cells(5).FindControl("hidStatus"), HiddenField)
                If hidStatus IsNot Nothing Then
                    Dim strBookingDate As String = e.Row.Cells(2).Text
                    If strBookingDate <> "" Then
                        e.Row.Cells(7).Controls(0).Visible = IsVisible(CBool(hidStatus.Value), strBookingDate)
                    End If
                End If
            End If

        End Sub

        Protected Sub GridViewHistory_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridViewHistory.RowEditing

            Dim intIndex As Integer = CInt(e.NewEditIndex)
            GridViewHistory.EditIndex = intIndex
            Call BindHistory()
        End Sub

        Protected Sub GridViewHistory_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridViewHistory.RowUpdating
            Dim intRoomBookingID As Integer = GridViewHistory.DataKeys(e.RowIndex).Value
            Dim txtBookingDate As TextBox = CType(GridViewHistory.Rows(e.RowIndex).Cells(2).Controls(0), TextBox)
            Dim txtTimeStart As TextBox = CType(GridViewHistory.Rows(e.RowIndex).Cells(3).Controls(0), TextBox)
            Dim txtTimeEnd As TextBox = CType(GridViewHistory.Rows(e.RowIndex).Cells(4).Controls(0), TextBox)

            If (Integer.Parse(txtTimeEnd.Text) - Integer.Parse(txtTimeStart.Text) = 2) Then
                objBOPACRoomsBooking.RoomsBookingID = intRoomBookingID
                objBOPACRoomsBooking.BookingDate = String.Format("{0:yyyy-MM-dd}", Date.Parse(txtBookingDate.Text))
                objBOPACRoomsBooking.TimeStart = txtTimeStart.Text
                objBOPACRoomsBooking.TimeEnd = txtTimeEnd.Text
                objBOPACRoomsBooking.Note = ""
                Dim intResult As Integer = objBOPACRoomsBooking.Update()
                If intResult = 1 Then

                    Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbMsgSuccess.Text & "');</script>")

                    GridViewHistory.EditIndex = -1
                    Call BindTimeBusy()
                    Call BindHistory()
                Else
                    Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbMsgValidBusyTime.Text & "');</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("callJs", "<script language = 'javascript'>alert('" & lbMsgValidCheckInTime.Text & "');</script>")
            End If


        End Sub

        Protected Sub GridViewHistory_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridViewHistory.RowCancelingEdit
            GridViewHistory.EditIndex = -1
            Call BindHistory()
        End Sub
    End Class
End Namespace
