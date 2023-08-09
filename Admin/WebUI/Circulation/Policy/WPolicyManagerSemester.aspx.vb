Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPolicyManagerSemester
        Inherits System.Web.UI.Page

        Private objBLoanTypeSemester As New clsBLoanTypeSemester
        Public Sub Initialize()
            ' Init objBLoanTypeSemester object
            objBLoanTypeSemester.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTypeSemester.DBServer = Session("DBServer")
            objBLoanTypeSemester.ConnectionString = Session("ConnectionString")
            Call objBLoanTypeSemester.Initialize()
        End Sub
        Private Sub BindJS()
            'Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPolicyManagement.js'></script>")

            'btnNew.Attributes.Add("onClick", "return ValidNew('" & ddlLabel.Items(4).Text & "');")
        End Sub
        Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                If Not IsNothing(Request.QueryString("DeleteId")) Then
                    Dim intId As Integer = CInt(Request.QueryString("DeleteId"))
                    Try
                        objBLoanTypeSemester.LoanTypeSemesterID = CInt(Request.QueryString("DeleteId"))
                        objBLoanTypeSemester.DeleteLoanTypeSemester()

                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDeleteSuccess.Text & "')</script>")
                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDeleteError.Text & "')</script>")
                    End Try
                End If
                Call BindData()
            End If
        End Sub
        Private Sub BindData()
            Dim tblLoanTypeSemester As New DataTable
            tblLoanTypeSemester = objBLoanTypeSemester.GetListLoanTypeSemester()
            If Not tblLoanTypeSemester Is Nothing Then
                If tblLoanTypeSemester.Rows.Count > 0 Then
                    Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    newColumn.DefaultValue = "1"
                    tblLoanTypeSemester.Columns.Add(newColumn)
                    newColumn = New Data.DataColumn("DateFrom", GetType(System.String))
                    newColumn.DefaultValue = ""
                    tblLoanTypeSemester.Columns.Add(newColumn)
                    newColumn = New Data.DataColumn("DateTo", GetType(System.String))
                    newColumn.DefaultValue = ""
                    tblLoanTypeSemester.Columns.Add(newColumn)
                    newColumn = New Data.DataColumn("Title", GetType(System.String))
                    newColumn.DefaultValue = ""
                    tblLoanTypeSemester.Columns.Add(newColumn)
                    Dim indexRows As Integer = 1
                    For Each rows As DataRow In tblLoanTypeSemester.Rows
                        If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                            rows.Item("STT") = indexRows.ToString()
                            Dim strYearFrom As String = Date.Now.Year.ToString()
                            Dim strYearTo As String = Date.Now.Year.ToString()
                            If (rows.Item("YearFrom").ToString() = "1") Then
                                strYearFrom = String.Format("{0}", Date.Now.Year + 1)
                            End If
                            If (rows.Item("YearTo").ToString() = "1") Then
                                strYearTo = String.Format("{0}", Date.Now.Year + 1)
                            End If
                            Dim strTitle As String = ""
                            If (rows.Item("Semester").ToString = "1") Then
                                strTitle = ddlSemester.Items(0).Text
                            End If
                            If (rows.Item("Semester").ToString = "2") Then
                                strTitle = ddlSemester.Items(1).Text
                            End If
                            If (rows.Item("Semester").ToString = "3") Then
                                strTitle = ddlSemester.Items(2).Text
                            End If
                            rows.Item("DateFrom") = rows.Item("DayFrom").ToString() & "/" & rows.Item("MonthFrom").ToString() & "/" & strYearFrom
                            rows.Item("DateTo") = rows.Item("DayTo").ToString() & "/" & rows.Item("MonthTo").ToString() & "/" & strYearTo
                            rows.Item("Title") = strTitle
                            indexRows = indexRows + 1
                        End If

                    Next
                    dtgPolicy.DataSource = tblLoanTypeSemester
                    dtgPolicy.DataBind()
                End If
            End If
        End Sub

        Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            If ((String.IsNullOrEmpty(txtDayFrom.Text)) Or (String.IsNullOrEmpty(txtMonthFrom.Text)) Or (String.IsNullOrEmpty(txtDayTo.Text)) Or (String.IsNullOrEmpty(txtMonthTo.Text))) Then
                If (String.IsNullOrEmpty(txtDayFrom.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDayRequired.Text & "')</script>")
                End If
                If (String.IsNullOrEmpty(txtMonthFrom.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbMonthRequired.Text & "')</script>")
                End If
                If (String.IsNullOrEmpty(txtDayTo.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDayRequired.Text & "')</script>")
                End If
                If (String.IsNullOrEmpty(txtMonthTo.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbMonthRequired.Text & "')</script>")
                End If
            Else
                objBLoanTypeSemester.Semester = CInt(ddlSemester.SelectedValue)
                Dim dtCheck As DataTable = objBLoanTypeSemester.GetLoanTypeSemesterBySemester()
                If (Not dtCheck Is Nothing) AndAlso (dtCheck.Rows.Count > 0) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbSemesterValid.Text & "')</script>")
                Else
                    Try
                        objBLoanTypeSemester.Semester = CInt(ddlSemester.SelectedValue)
                        objBLoanTypeSemester.DayFrom = CInt(txtDayFrom.Text)
                        objBLoanTypeSemester.MonthFrom = CInt(txtMonthFrom.Text)
                        objBLoanTypeSemester.YearFrom = CInt(ddlYearFrom.SelectedValue)
                        objBLoanTypeSemester.DayTo = CInt(txtDayTo.Text)
                        objBLoanTypeSemester.MonthTo = CInt(txtMonthTo.Text)
                        objBLoanTypeSemester.YearTo = CInt(ddlYearTo.SelectedValue)
                        Dim intResult As Integer = objBLoanTypeSemester.CreateLoanTypeSemester()
                        If intResult = 1 Then
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateSuccess.Text & "')</script>")
                        Else
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateError.Text & "')</script>")
                        End If
                        Call BindData()
                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbCreateError.Text & "')</script>")
                    End Try
                End If
                
            End If
        End Sub

        Protected Sub dtgPolicy_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles dtgPolicy.RowEditing
            dtgPolicy.EditIndex = e.NewEditIndex
            BindData()

            Dim hidID As Integer = CInt(dtgPolicy.DataKeys(e.NewEditIndex).Value.ToString())
            objBLoanTypeSemester.LoanTypeSemesterID = hidID
            Dim dtResult As DataTable = objBLoanTypeSemester.GetLoanTypeSemesterById()
            Dim ddlSemesterGridView As DropDownList = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("ddlSemester"), DropDownList)
            Dim txtDayFromGridView As TextBox = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("txtDayFrom"), TextBox)
            Dim txtMonthFromGridView As TextBox = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("txtMonthFrom"), TextBox)
            Dim txtDayToGridView As TextBox = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("txtDayTo"), TextBox)
            Dim txtMonthToGridView As TextBox = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("txtMonthTo"), TextBox)
            Dim ddlYearFromGridView As DropDownList = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("ddlYearFrom"), DropDownList)
            Dim ddlYearToGridView As DropDownList = CType(dtgPolicy.Rows(e.NewEditIndex).FindControl("ddlYearTo"), DropDownList)
            ddlSemesterGridView.SelectedValue = dtResult.Rows(0).Item("Semester")
            txtDayFromGridView.Text = dtResult.Rows(0).Item("DayFrom")
            txtMonthFromGridView.Text = dtResult.Rows(0).Item("MonthFrom")
            txtDayToGridView.Text = dtResult.Rows(0).Item("DayTo")
            txtMonthToGridView.Text = dtResult.Rows(0).Item("MonthTo")
            ddlYearFromGridView.SelectedValue = dtResult.Rows(0).Item("YearFrom")
            ddlYearToGridView.SelectedValue = dtResult.Rows(0).Item("YearTo")
        End Sub
        Protected Sub dtgPolicy_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles dtgPolicy.RowUpdating
            Dim hidID As Integer = CInt(dtgPolicy.DataKeys(e.RowIndex).Value.ToString())

            Dim dtResult As DataTable = objBLoanTypeSemester.GetLoanTypeSemesterById()
            Dim ddlSemesterGridView As DropDownList = CType(dtgPolicy.Rows(e.RowIndex).FindControl("ddlSemester"), DropDownList)
            Dim txtDayFromGridView As TextBox = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtDayFrom"), TextBox)
            Dim txtMonthFromGridView As TextBox = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtMonthFrom"), TextBox)
            Dim txtDayToGridView As TextBox = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtDayTo"), TextBox)
            Dim txtMonthToGridView As TextBox = CType(dtgPolicy.Rows(e.RowIndex).FindControl("txtMonthTo"), TextBox)
            Dim ddlYearFromGridView As DropDownList = CType(dtgPolicy.Rows(e.RowIndex).FindControl("ddlYearFrom"), DropDownList)
            Dim ddlYearToGridView As DropDownList = CType(dtgPolicy.Rows(e.RowIndex).FindControl("ddlYearTo"), DropDownList)

            If ((String.IsNullOrEmpty(txtDayFromGridView.Text)) Or (String.IsNullOrEmpty(txtMonthFromGridView.Text)) Or (String.IsNullOrEmpty(txtDayToGridView.Text)) Or (String.IsNullOrEmpty(txtMonthToGridView.Text))) Then
                If (String.IsNullOrEmpty(txtDayFromGridView.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDayRequired.Text & "')</script>")
                End If
                If (String.IsNullOrEmpty(txtMonthFromGridView.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbMonthRequired.Text & "')</script>")
                End If
                If (String.IsNullOrEmpty(txtDayToGridView.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbDayRequired.Text & "')</script>")
                End If
                If (String.IsNullOrEmpty(txtMonthToGridView.Text)) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbMonthRequired.Text & "')</script>")
                End If
            Else
                objBLoanTypeSemester.LoanTypeSemesterID = hidID
                objBLoanTypeSemester.Semester = CInt(ddlSemester.SelectedValue)
                Dim dtCheck As DataTable = objBLoanTypeSemester.GetLoanTypeSemesterByIdAndSemester()
                If (Not dtCheck Is Nothing) AndAlso (dtCheck.Rows.Count > 0) Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbSemesterValid.Text & "')</script>")
                Else
                    Try
                        objBLoanTypeSemester.LoanTypeSemesterID = hidID
                        objBLoanTypeSemester.Semester = CInt(ddlSemesterGridView.SelectedValue)
                        objBLoanTypeSemester.DayFrom = CInt(txtDayFromGridView.Text)
                        objBLoanTypeSemester.MonthFrom = CInt(txtMonthFromGridView.Text)
                        objBLoanTypeSemester.YearFrom = CInt(ddlYearFromGridView.SelectedValue)
                        objBLoanTypeSemester.DayTo = CInt(txtDayToGridView.Text)
                        objBLoanTypeSemester.MonthTo = CInt(txtMonthToGridView.Text)
                        objBLoanTypeSemester.YearTo = CInt(ddlYearToGridView.SelectedValue)
                        Dim intResult As Integer = objBLoanTypeSemester.UpdateLoanTypeSemester()
                        If intResult = 1 Then
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateSuccess.Text & "')</script>")
                        Else
                            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateError.Text & "')</script>")
                        End If

                        dtgPolicy.EditIndex = -1
                        BindData()
                    Catch ex As Exception
                        Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & lbUpdateError.Text & "')</script>")
                    End Try
                End If
                
            End If
        End Sub
        Protected Sub dtgPolicy_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles dtgPolicy.RowCancelingEdit
            dtgPolicy.EditIndex = -1
            BindData()
        End Sub
        Protected Sub dtgPolicyt_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles dtgPolicy.RowDataBound
            For i = 0 To dtgPolicy.Rows.Count - 1
                Dim hidID As Integer = CInt(dtgPolicy.DataKeys(i).Value.ToString())
                Dim linkDelete As HyperLink = CType(dtgPolicy.Rows(i).Cells(5).FindControl("linkDelete"), HyperLink)
                linkDelete.Attributes.Add("onclick", "DeleteItem('" & hidID & "')")
                linkDelete.Attributes.Add("href", "javascript:void('" & hidID & "')")
            Next
        End Sub
    End Class
End Namespace
