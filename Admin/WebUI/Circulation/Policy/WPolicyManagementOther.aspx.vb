Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPolicyManagementOther
        Inherits System.Web.UI.Page

        Private objBLoanType As New clsBLoanType
        Private objBLoanTypeOther As New clsBLoanTypeOther
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BinDDl()
                Session("pageIndex") = 0
                ddlLoanType.SelectedIndex = 0
                Session("intLoanTypeID") = ddlLoanType.SelectedItem.Value
                Call BindData()
            End If
        End Sub

        Private Sub Initialze()
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()
            objBLoanTypeOther.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTypeOther.DBServer = Session("DBServer")
            objBLoanTypeOther.ConnectionString = Session("ConnectionString")
            Call objBLoanTypeOther.Initialize()
        End Sub
        Private Sub BindData()
            Dim tblLoanTypeOther As New DataTable
            objBLoanTypeOther.LoanTypeID = CType(Session("intLoanTypeID"), Integer)
            tblLoanTypeOther = objBLoanTypeOther.GetLoanTypeOtherByLoanTypeId()
            If Not tblLoanTypeOther Is Nothing Then
                If tblLoanTypeOther.Rows.Count > 0 Then

                    Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    newColumn.DefaultValue = "1"
                    tblLoanTypeOther.Columns.Add(newColumn)
                    Dim indexRows As Integer = 1
                    For Each rows As DataRow In tblLoanTypeOther.Rows
                        If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                            rows.Item("STT") = indexRows.ToString()
                            indexRows = indexRows + 1
                        End If

                    Next

                    dtgPolicy.PageIndex = CType(Session("pageIndex").ToString(), Integer)
                    dtgPolicy.DataSource = tblLoanTypeOther
                    dtgPolicy.DataBind()
                End If
                tblLoanTypeOther = Nothing
            End If
            'Call BinDDl()
        End Sub

        Private Sub BinDDl()

            'Load data to dropdownlist LoanTypeGroup
            ddlLoanType.DataSource = objBLoanType.GetLoanTypes()
            ddlLoanType.DataTextField = "LoanType"
            ddlLoanType.DataValueField = "ID"
            ddlLoanType.DataBind()
        End Sub

        Private Sub BindJS()
            'Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPolicyManagement.js'></script>")

            btnNew.Attributes.Add("onClick", "return ValidNew('" & ddlLabel.Items(4).Text & "');")
        End Sub

        'Protected Sub dtgPolicy_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgPolicy.UpdateCommand
        '    '            Dim intItemIndex As Integer
        '    '            Dim intIndexControl As Integer
        '    '            Dim lngID As Long
        '    '            Dim dblFee As Double
        '    '            Dim bytFixedFee As Byte
        '    '            Dim bytLoanPeriod As Integer
        '    '            Dim strLoanType As String
        '    '            Dim dblOverdueFine As Double
        '    '            Dim bytRenewals As Integer
        '    '            Dim bytRenewPeriod As Integer
        '    '            Dim bytTimeUnit As Integer
        '    '            Dim blnValidUpdate As Boolean = True
        '    '            Dim intLoanPeriod As Byte

        '    '            intItemIndex = e.Item.ItemIndex

        '    '            ' Get Value
        '    '            lngID = CLng(CType(e.Item.Cells(1).FindControl("lblID"), Label).Text)
        '    '            If CType(e.Item.Cells(8).FindControl("txtFee"), TextBox).Text <> "" Then
        '    '                If IsNumeric(CType(e.Item.Cells(8).FindControl("txtFee"), TextBox).Text) Then
        '    '                    dblFee = CDbl(CType(e.Item.Cells(8).FindControl("txtFee"), TextBox).Text)
        '    '                Else
        '    '                    blnValidUpdate = False
        '    '                    intIndexControl = 6
        '    '                    GoTo ErrInput
        '    '                End If
        '    '            Else
        '    '                blnValidUpdate = False
        '    '                intIndexControl = 6
        '    '                GoTo ErrInput
        '    '            End If
        '    '            bytFixedFee = CType(e.Item.Cells(9).FindControl("ddlFixedFee"), DropDownList).SelectedValue
        '    '            If CType(e.Item.Cells(4).FindControl("txtLoanPeriod"), TextBox).Text <> "" Then
        '    '                If IsNumeric(CType(e.Item.Cells(4).FindControl("txtLoanPeriod"), TextBox).Text) Then
        '    '                    bytLoanPeriod = CInt(CType(e.Item.Cells(4).FindControl("txtLoanPeriod"), TextBox).Text)
        '    '                Else
        '    '                    blnValidUpdate = False
        '    '                    intIndexControl = 2
        '    '                    GoTo ErrInput
        '    '                End If
        '    '            Else
        '    '                blnValidUpdate = False
        '    '                intIndexControl = 2
        '    '                GoTo ErrInput
        '    '            End If
        '    '            strLoanType = CType(e.Item.Cells(2).FindControl("txtLoanType"), TextBox).Text
        '    '            If Trim(strLoanType) = "" Then
        '    '                blnValidUpdate = False
        '    '                intIndexControl = 1
        '    '                GoTo ErrInput
        '    '            End If
        '    '            If CType(e.Item.Cells(7).FindControl("txtOverdueFine"), TextBox).Text <> "" Then
        '    '                If IsNumeric(CType(e.Item.Cells(7).FindControl("txtOverdueFine"), TextBox).Text) Then
        '    '                    dblOverdueFine = CDbl(CType(e.Item.Cells(7).FindControl("txtOverdueFine"), TextBox).Text)
        '    '                Else
        '    '                    blnValidUpdate = False
        '    '                    intIndexControl = 5
        '    '                    GoTo ErrInput
        '    '                End If
        '    '            Else
        '    '                blnValidUpdate = False
        '    '                intIndexControl = 5
        '    '                GoTo ErrInput
        '    '            End If
        '    '            If CType(e.Item.Cells(5).FindControl("txtRenewals"), TextBox).Text <> "" Then
        '    '                If IsNumeric(CType(e.Item.Cells(5).FindControl("txtRenewals"), TextBox).Text) Then
        '    '                    bytRenewals = CInt(CType(e.Item.Cells(5).FindControl("txtRenewals"), TextBox).Text)
        '    '                Else
        '    '                    blnValidUpdate = False
        '    '                    intIndexControl = 1
        '    '                    GoTo ErrInput
        '    '                End If
        '    '            Else
        '    '                blnValidUpdate = False
        '    '                intIndexControl = 1
        '    '                GoTo ErrInput
        '    '            End If
        '    '            If CType(e.Item.Cells(6).FindControl("txtRenewalPeriod"), TextBox).Text <> "" Then
        '    '                If IsNumeric(CType(e.Item.Cells(6).FindControl("txtRenewalPeriod"), TextBox).Text) Then
        '    '                    bytRenewPeriod = CInt(CType(e.Item.Cells(6).FindControl("txtRenewalPeriod"), TextBox).Text)
        '    '                Else
        '    '                    blnValidUpdate = False
        '    '                    intIndexControl = 4
        '    '                    GoTo ErrInput
        '    '                End If
        '    '            Else
        '    '                blnValidUpdate = False
        '    '                intIndexControl = 4
        '    '                GoTo ErrInput
        '    '            End If
        '    'ErrInput:
        '    '            If Not blnValidUpdate Then
        '    '                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>ValidUpdate(" & intIndexControl & ",'" & ddlLabel.Items(4).Text & "'," & intItemIndex & ")</script>")
        '    '            Else
        '    '                bytTimeUnit = CInt(CType(e.Item.Cells(4).FindControl("ddlSelectTimeUnit"), DropDownList).SelectedValue)
        '    '                If bytTimeUnit = 0 Then
        '    '                    bytTimeUnit = 2
        '    '                End If
        '    '                'Check with MaxHour=15h
        '    '                If bytTimeUnit = 2 Then
        '    '                    If bytLoanPeriod > 15 Then
        '    '                        Page.RegisterClientScriptBlock("JSErr", "<script language = 'javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
        '    '                        bytLoanPeriod = 1
        '    '                    End If
        '    '                End If

        '    '                objBLoanType.LoanTypeID = lngID
        '    '                objBLoanType.Fee = dblFee
        '    '                objBLoanType.FixedFee = bytFixedFee
        '    '                objBLoanType.LoanPeriod = bytLoanPeriod
        '    '                objBLoanType.LoanType = strLoanType
        '    '                objBLoanType.OverdueFine = dblOverdueFine
        '    '                objBLoanType.Renewals = bytRenewals
        '    '                objBLoanType.RenewPeriod = bytRenewPeriod
        '    '                objBLoanType.TimeUnit = bytTimeUnit
        '    '                objBLoanType.UpdateLoanType()
        '    '                ' WriteLog
        '    '                Call WriteLog(110, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

        '    '                'dtgPolicy.EditItemIndex = -1
        '    '                Call BindData()
        '    '            End If
        'End Sub

        'Protected Sub dtgPolicy_EditCommand(sender As Object, e As GridCommandEventArgs) Handles dtgPolicy.EditCommand
        '    'Dim intIndex As Integer
        '    'Dim ddlTimeUnitTmp As New DropDownList
        '    'Dim ddlFixedFeeTmp As New DropDownList

        '    'intIndex = CInt(e.Item.ItemIndex)
        '    ''dtgPolicy.EditItemIndex = intIndex
        '    'Call BindData()
        'End Sub

        'Protected Sub dtgPolicy_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles dtgPolicy.ItemCommand
        '    'Dim strJS As String
        '    'Dim strCmd As String = ""
        '    'Dim objLabel As New Label
        '    'Dim strMark As String = ""

        '    'strCmd = UCase(e.CommandName)
        '    'If strCmd = "EDIT" Or strCmd = "UPDATE" Or strCmd = "CANCEL" Then
        '    '    objLabel = CType(e.Item.FindControl("lblMark"), Label)
        '    '    strMark = Replace(objLabel.Text, "<a name=""", "")
        '    '    strMark = Replace(strMark, """>", "")
        '    '    strJS = "<script language='JavaScript'>"
        '    '    strJS = strJS & "self.location.href='#" & strMark & "';"
        '    '    strJS = strJS & "</script>"
        '    '    Page.RegisterClientScriptBlock("Bookmark", strJS)
        '    'End If
        'End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
            objBLoanTypeOther.DateStartLoanType = RadDateTimePickerDateStart.SelectedDate
            objBLoanTypeOther.DateEndLoanType = RadDateTimePickerDateEnd.SelectedDate
            objBLoanTypeOther.DateExpiredLoanType = RadDateTimePickerDateExpired.SelectedDate
            objBLoanTypeOther.LoanTypeID = ddlLoanType.SelectedItem.Value
            objBLoanTypeOther.CreateLoanTypeOther()
            BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub dtgPolicy_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles dtgPolicy.RowEditing
            dtgPolicy.EditIndex = e.NewEditIndex
            BindData()

            Dim row As GridViewRow = CType(dtgPolicy.Rows(e.NewEditIndex), GridViewRow)
            Dim ddlLoanType As DropDownList = CType(row.FindControl("ddlLoanTypeOther"), DropDownList)
            Dim hidLoanTypeID As HiddenField = CType(row.FindControl("hidLoanTypeID"), HiddenField)
            ddlLoanType.DataSource = objBLoanType.GetLoanTypes()
            ddlLoanType.DataTextField = "LoanType"
            ddlLoanType.DataValueField = "ID"
            ddlLoanType.DataBind()
            ddlLoanType.SelectedValue = hidLoanTypeID.Value
        End Sub

        Protected Sub dtgPolicy_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles dtgPolicy.RowUpdating
            Dim row As GridViewRow = CType(dtgPolicy.Rows(e.RowIndex), GridViewRow)
            Dim ddlLoanTypeOther As DropDownList = CType(row.FindControl("ddlLoanTypeOther"), DropDownList)
            Dim hidID As HiddenField = CType(row.FindControl("hidID"), HiddenField)
            Dim RadDateTimePickerDateStartEdit As Telerik.Web.UI.RadDatePicker = CType(row.FindControl("RadDateTimePickerDateStartEdit"), Telerik.Web.UI.RadDatePicker)
            Dim RadDateTimePickerDateEndEdit As Telerik.Web.UI.RadDatePicker = CType(row.FindControl("RadDateTimePickerDateEndEdit"), Telerik.Web.UI.RadDatePicker)
            Dim RadDateTimePickerDateExpiredEdit As Telerik.Web.UI.RadDatePicker = CType(row.FindControl("RadDateTimePickerDateExpiredEdit"), Telerik.Web.UI.RadDatePicker)

            objBLoanTypeOther.LoanTypeOtherID = hidID.Value
            objBLoanTypeOther.DateStartLoanType = RadDateTimePickerDateStartEdit.SelectedDate
            objBLoanTypeOther.DateEndLoanType = RadDateTimePickerDateEndEdit.SelectedDate
            objBLoanTypeOther.DateExpiredLoanType = RadDateTimePickerDateExpiredEdit.SelectedDate
            objBLoanTypeOther.LoanTypeID = ddlLoanTypeOther.SelectedItem.Value

            objBLoanTypeOther.UpdateLoanTypeOther()

            dtgPolicy.EditIndex = -1
            BindData()
        End Sub

        Protected Sub dtgPolicy_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles dtgPolicy.RowCancelingEdit
            dtgPolicy.EditIndex = -1
            BindData()
        End Sub

        Protected Sub dtgPolicy_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles dtgPolicy.PageIndexChanging
            Session("pageIndex") = e.NewPageIndex
            BindData()
        End Sub

        Protected Sub dtgPolicy_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles dtgPolicy.RowDeleting
            Dim row As GridViewRow = CType(dtgPolicy.Rows(e.RowIndex), GridViewRow)
            Dim hidID As HiddenField = CType(row.FindControl("hidID"), HiddenField)

            objBLoanTypeOther.LoanTypeOtherID = hidID.Value
            objBLoanTypeOther.DeleteLoanTypeOther()

            dtgPolicy.EditIndex = -1
            BindData()
        End Sub

        Protected Sub ddlLoanType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLoanType.SelectedIndexChanged
            Session("intLoanTypeID") = ddlLoanType.SelectedItem.Value
            BindData()
        End Sub
    End Class
End Namespace
