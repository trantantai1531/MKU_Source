Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WRooms
        Inherits clsWBase

        Private objBRooms As New clsBRooms

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                If Not IsNothing(Request.QueryString("DeleteId")) Then
                    Dim intId As Integer = CInt(Request.QueryString("DeleteId"))
                    objBRooms.RoomID = CInt(Request.QueryString("DeleteId"))
                    Dim intResult As Integer = objBRooms.Delete()

                    If intResult = 1 Then
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDeleteSuccess.Text & "')</script>")
                    Else
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDeleteError.Text & "')</script>")
                    End If
                End If
                Call BindData()
            End If
        End Sub

        Private Sub CheckFormPermission()

        End Sub

        Private Sub Initialize()
            ' Init objBRooms object
            objBRooms.InterfaceLanguage = Session("InterfaceLanguage")
            objBRooms.DBServer = Session("DBServer")
            objBRooms.ConnectionString = Session("ConnectionString")
            Call objBRooms.Initialize()
        End Sub

        Private Sub BindJS()

        End Sub

        Private Sub BindData()
            Dim tblData As DataTable = objBRooms.GetAllRooms()
            If tblData IsNot Nothing AndAlso tblData.Rows.Count > 0 Then
                tblData.Columns.Add("STT")
                For i As Integer = 0 To tblData.Rows.Count - 1 Step 1
                    tblData.Rows(i).Item("STT") = i + 1
                Next

                GridViewRooms.DataSource = tblData
                GridViewRooms.DataBind()
            Else
                GridViewRooms.DataSource = Nothing
                GridViewRooms.DataBind()
            End If
        End Sub

        Protected Sub GridViewRooms_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles GridViewRooms.RowEditing
            GridViewRooms.EditIndex = e.NewEditIndex
            BindData()
        End Sub

        Protected Sub GridViewRooms_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles GridViewRooms.RowUpdating
            Dim intRoomID As Integer = GridViewRooms.DataKeys(e.RowIndex).Value
            Dim txtRoomCodeGV As TextBox = CType(GridViewRooms.Rows(e.RowIndex).Cells(1).Controls(0), TextBox)
            Dim txtRoomNameGV As TextBox = CType(GridViewRooms.Rows(e.RowIndex).Cells(2).Controls(0), TextBox)
            Dim txtRoomNoteGV As TextBox = CType(GridViewRooms.Rows(e.RowIndex).Cells(3).Controls(0), TextBox)

            objBRooms.RoomID = intRoomID
            objBRooms.RoomCode = txtRoomCodeGV.Text
            objBRooms.RoomName = txtRoomNameGV.Text
            objBRooms.RoomNote = txtRoomNoteGV.Text

            Dim intResult As Integer = objBRooms.Update()

            If intResult = 1 Then
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateSuccess.Text & "')</script>")
                GridViewRooms.EditIndex = -1
                BindData()
            Else
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateError.Text & "')</script>")
            End If


        End Sub
        Protected Sub GridViewRooms_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles GridViewRooms.RowCancelingEdit
            GridViewRooms.EditIndex = -1
            BindData()
        End Sub
        Protected Sub GridViewRooms_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewRooms.RowDataBound
            For i = 0 To GridViewRooms.Rows.Count - 1
                Dim hidID As Integer = CInt(GridViewRooms.DataKeys(i).Value.ToString())
                Dim linkDelete As HyperLink = CType(GridViewRooms.Rows(i).Cells(5).FindControl("linkDelete"), HyperLink)
                linkDelete.Attributes.Add("onclick", "DeleteRoom('" & hidID & "')")
                linkDelete.Attributes.Add("href", "javascript:void('" & hidID & "')")
            Next
        End Sub
        Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

            objBRooms.RoomCode = txtRoomCode.Text
            objBRooms.RoomName = txtRoomName.Text
            objBRooms.RoomNote = txtRoomNote.Text

            Dim intResult As Integer = objBRooms.Create()

            If intResult = 1 Then
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateSuccess.Text & "')</script>")

                BindData()
            Else
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateError.Text & "')</script>")
            End If
        End Sub

        Protected Sub GridViewRooms_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewRooms.PageIndexChanging
            GridViewRooms.PageIndex = e.NewPageIndex
            BindData()
        End Sub
    End Class
End Namespace

