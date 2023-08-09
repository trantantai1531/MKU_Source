' Class: WFaculty
' Puspose: management faculty
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 26/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WFaculty
        Inherits clsWBase
        Implements IUCNumberOfRecord

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBFaculty As New clsBFaculty
        Private objBCollege As New clsBCollege

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call GetCollege()
                'Call BindData()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(213) Then
                btnAdd.Enabled = False
                btnMerger.Enabled = False
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBFaculty object
            objBFaculty.DBServer = Session("DBServer")
            objBFaculty.ConnectionString = Session("ConnectionString")
            objBFaculty.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBFaculty.Initialize()

            ' Init objBCollege object
            objBCollege.DBServer = Session("DBServer")
            objBCollege.ConnectionString = Session("ConnectionString")
            objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCollege.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need objects
        Private Sub BindJS()
            Dim strJSConfirm As String
            Dim strJSCheckMerge As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/JSMainList.js'></script>")

            btnAdd.Attributes.Add("OnClick", "javascript:return(CheckAddNewFaculty('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "'));")

            ' Get the js script strings 
            strJSCheckMerge = "if(!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, '" & ddlLabel.Items(4).Text & "')) return false;"
            strJSConfirm = "return ConfirmMerger('" & ddlLabel.Items(5).Text & "');"
            btnMerger.Attributes.Add("onClick", strJSCheckMerge & " else " & strJSConfirm)
        End Sub

        ' Method: GetCollege
        ' Purpose: get list of colleges
        Private Sub GetCollege()
            Dim tblResult As DataTable

            tblResult = objBCollege.GetCollege

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(11).Text, objBCollege.ErrorMsg, ddlLabel.Items(10).Text, objBCollege.ErrorCode)

            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlCollege.DataSource = tblResult
                    ddlCollege.DataTextField = "College"
                    ddlCollege.DataValueField = "ID"
                    ddlCollege.SelectedIndex = 0
                    ddlCollege.DataBind()
                End If
                tblResult = Nothing
            End If
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intItem As Integer
            Dim intCount As Integer
            Dim intRow As Integer
            Dim strNameFacultys As String
            Dim strIDFacultys As String

            objBFaculty.ID = 0
            objBFaculty.CollegeID = CInt(ddlCollege.SelectedValue)
            tblResult = objBFaculty.GetFaculty

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(11).Text, objBFaculty.ErrorMsg, ddlLabel.Items(10).Text, objBFaculty.ErrorCode)

            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlFaculty.DataSource = tblResult
                    ddlFaculty.DataTextField = "FC"
                    ddlFaculty.DataValueField = "ID"
                    ddlFaculty.SelectedIndex = 0
                    ddlFaculty.DataBind()
                End If
            End If

            ' Get faculties
            objBFaculty.ID = 0
            objBFaculty.CollegeID = CInt(ddlCollege.SelectedValue)
            tblResult = objBFaculty.GetFaculty

            dtgFaculty.Visible = False
            hidNameFacultys.Value = ""
            hidIDFacultys.Value = ""
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                   
                    strNameFacultys = ""
                    strIDFacultys = ""
                    For intRow = 0 To tblResult.Rows.Count - 1
                        strNameFacultys = strNameFacultys & CStr(tblResult.Rows(intRow).Item("Faculty")) & ","
                        strIDFacultys = strIDFacultys & CStr(tblResult.Rows(intRow).Item("ID")) & ","
                    Next
                    hidNameFacultys.Value = Left(strNameFacultys, Len(strNameFacultys) - 1)
                    hidIDFacultys.Value = Left(strIDFacultys, Len(strIDFacultys) - 1)
                    dtgFaculty.DataSource = tblResult
                    'dtgFaculty.DataBind()
                    dtgFaculty.Visible = True
                End If
                tblResult = Nothing
            End If
        End Sub

        ' Event: btnAdd_Click
        ' Purpose: New faculty
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intOut As Integer = 0
            If txtFaculty.Text <> "" Then
                objBFaculty.Faculty = txtFaculty.Text.Trim
                objBFaculty.CollegeID = CInt(ddlCollege.SelectedValue)
                intOut = objBFaculty.Create()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBFaculty.ErrorMsg, ddlLabel.Items(10).Text, objBFaculty.ErrorCode)

                If intOut <> -1 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(7).Text & " " & txtFaculty.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & " \'" & txtFaculty.Text.Trim & "\' " & ddlLabel.Items(9).Text & "');</script>")

                    ' Refresh data
                    Call BindData()
                    dtgFaculty.Rebind()
                Else
                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End If
            txtFaculty.Text = ""
        End Sub

        ' Event: btnMerger_Click
        ' Purpose: merger some faculties
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As GridDataItem
            Dim chkCheckBox As HtmlInputCheckBox
            Dim intIDCur As Integer
            Dim strIDs As String

            intIDCur = CInt(ddlFaculty.SelectedValue)
            strIDs = ""
            For Each dtgItem In dtgFaculty.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    If CInt(dtgItem.Cells(2).Text) <> intIDCur Then
                        strIDs = strIDs & dtgItem.Cells(2).Text & ","
                    End If
                End If
            Next
            If strIDs <> "" Then
                strIDs = "," & strIDs
                objBFaculty.ID = CInt(ddlFaculty.SelectedValue)
                objBFaculty.IDs = strIDs
                Call objBFaculty.Merger()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBFaculty.ErrorMsg, ddlLabel.Items(10).Text, objBFaculty.ErrorCode)

                ' WriteLog
                Call WriteLog(118, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & " " & ddlLabel.Items(9).Text & "');</script>")
                Call BindData()
                dtgFaculty.Rebind()
            End If
        End Sub

        ' Event: dtgFaculty_CancelCommand
        'Private Sub dtgFaculty_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgFaculty.CancelCommand
        '    Try
        '        dtgFaculty.EditItemIndex = -1
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Event: dtgFaculty_EditCommand
        'Private Sub dtgFaculty_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgFaculty.EditCommand
        '    Try
        '        If Not CheckPemission(213) Then
        '            Exit Sub
        '        End If
        '        dtgFaculty.EditItemIndex = e.Item.ItemIndex
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Event: dtgFaculty_ItemCreated
        Private Sub dtgFaculty_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgFaculty.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUp As LinkButton
                    lnkbtnUp = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdateFaculty('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgFaculty__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgFaculty','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dtgFaculty_UpdateCommand
        Private Sub dtgFaculty_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgFaculty.UpdateCommand
            Dim intOut As Integer = 0
            Dim txtType As TextBox

            ' Get data to update
            txtType = e.Item.FindControl("txtdtgFaculty")
            If txtType.Text <> "" Then
                objBFaculty.ID = dtgFaculty.MasterTableView.DataKeyValues.Item(e.Item.ItemIndex).Item("ID").ToString() 'CInt(e.Item.Cells(0).Text)
                objBFaculty.Faculty = txtType.Text.Trim
                objBFaculty.CollegeID = CInt(ddlCollege.SelectedValue)
                intOut = objBFaculty.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBFaculty.ErrorMsg, ddlLabel.Items(10).Text, objBFaculty.ErrorCode)

                ' WriteLog
                Call WriteLog(118, ddlLabel.Items(7).Text & " " & txtType.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intOut = 0 Then
                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & " \'" & txtType.Text.Trim & "\' " & ddlLabel.Items(9).Text & "');</script>")

                    ' Refresh Data
                    ' dtgFaculty.EditItemIndex = -1
                    Call BindData()
                Else
                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End If
        End Sub

        Private Sub dtgFaculty_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgFaculty.DeleteCommand
            Try
                objBFaculty.ID = dtgFaculty.MasterTableView.DataKeyValues.Item(e.Item.ItemIndex).Item("ID").ToString() 'CInt(e.Item.Cells(2).Text)
                Call objBFaculty.Delete()

                If Not (objBFaculty.ErrorMsg = "") Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & " " & ddlLabel.Items(3).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(7).Text & " " & txtFaculty.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If

                ' Check error
                'Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: ddlCollege_SelectedIndexChanged
        Private Sub ddlCollege_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCollege.SelectedIndexChanged
            Call BindData()
            dtgFaculty.Rebind()
        End Sub

        Protected Sub dtgFaculty_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgFaculty.NeedDataSource
            Call BindData()

        End Sub


        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

        ' Event: dtgFaculty_PageIndexChanged
        'Private Sub dtgFaculty_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgFaculty.PageIndexChanged
        '    Try
        '        dtgFaculty.EditItemIndex = -1
        '        dtgFaculty.CurrentPageIndex = e.NewPageIndex
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBFaculty Is Nothing Then
                    objBFaculty.Dispose(True)
                    objBFaculty = Nothing
                End If
                If Not objBCollege Is Nothing Then
                    objBCollege.Dispose(True)
                    objBCollege = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace