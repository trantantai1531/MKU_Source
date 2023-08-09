' Class: WCollege
' Puspose: Management college
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 26/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports Telerik.Web.UI
Imports System.ComponentModel

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCollege
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
        Private objBCollege As New clsBCollege

        Public Function FindInnerControl(id As String) As Control
            If dtgCollege.Controls.Count > 0 Then
                'The first control is your ContentContainer
                Return dtgCollege.Controls(0).FindControl(id)
            End If
            Return Nothing
        End Function
        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                ' Call BindData()
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
            objBCollege.DBServer = Session("DBServer")
            objBCollege.ConnectionString = Session("ConnectionString")
            objBCollege.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCollege.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Dim strJSConfirm As String
            Dim strJSCheckMerge As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/JSMainList.js'></script>")

            btnAdd.Attributes.Add("OnClick", "javascript:return(CheckAddNew('document.forms[0].txtCollege','document.forms[0].ddlCollege','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "'));")

            ' Get the js script strings 
            strJSCheckMerge = "if(!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, '" & ddlLabel.Items(4).Text & "')) return false;"
            strJSConfirm = "return ConfirmMerger('" & ddlLabel.Items(5).Text & "');"
            btnMerger.Attributes.Add("onClick", strJSCheckMerge & " else " & strJSConfirm)
        End Sub

        ' Method: BindData
        ' Purpose: Load data
        Private Sub BindData()
            'bind data for datagrid
            Dim tblTemp As DataTable
            Dim intItem As Integer
            Dim intCount As Integer

            tblTemp = objBCollege.GetCollege

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(11).Text, objBCollege.ErrorMsg, ddlLabel.Items(10).Text, objBCollege.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then

                    ' Show data in grid
                    dtgCollege.DataSource = tblTemp
                    'dtgCollege.DataBind()
                    ' Show data in dropdownlist
                    ddlCollege.DataSource = tblTemp
                    ddlCollege.DataTextField = "College"
                    ddlCollege.DataValueField = "ID"
                    ddlCollege.SelectedIndex = 0
                    ddlCollege.DataBind()
                End If
            End If
        End Sub

        ' Event: btnAdd_Click
        ' Purpose: Add new college
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intOut As Integer = 0
            If txtCollege.Text <> "" Then
                objBCollege.College = txtCollege.Text.Trim
                intOut = objBCollege.Create()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBCollege.ErrorMsg, ddlLabel.Items(10).Text, objBCollege.ErrorCode)

                If intOut <> -1 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(7).Text & ": " & txtCollege.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & " \'" & txtCollege.Text.Trim & "\' " & ddlLabel.Items(9).Text & "');</script>")

                    ' Reload form
                    Call BindData()
                Else ' Exist college
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
                Call BindData()
                dtgCollege.Rebind()
            End If
            txtCollege.Text = ""
        End Sub

        ' Event: btnMerger_Click
        ' Purpose: Merger some colleges
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As GridDataItem
            Dim chkCheckBox As HtmlInputCheckBox
            Dim intIDCur As Integer
            Dim strIDs As String

            intIDCur = CInt(ddlCollege.SelectedValue)
            strIDs = ""
            For Each dtgItem In dtgCollege.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    If CInt(dtgItem.Cells(2).Text) <> intIDCur Then
                        strIDs = strIDs & dtgItem.Cells(2).Text & ","
                    End If
                End If
            Next
            If strIDs <> "" Then
                strIDs = "," & strIDs
                objBCollege.ID = CInt(ddlCollege.SelectedValue)
                objBCollege.IDs = strIDs
                Call objBCollege.Merger()

                ' WriteLog
                Call WriteLog(118, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & " " & ddlLabel.Items(9).Text & "');</script>")

                ' Refresh data
                Call BindData()
                dtgCollege.Rebind()
            End If
        End Sub

        '' Event: dtgCollege_CancelCommand
        'Private Sub dtgCollege_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgCollege.CancelCommand
        '    Try
        '        dtgCollege.EditItemIndex = -1
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        '' Event: dtgCollege_EditCommand
        'Private Sub dtgCollege_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgCollege.EditCommand
        '    Try
        '        If Not CheckPemission(213) Then
        '            Exit Sub
        '        End If
        '        ' dtgCollege.EditItemIndex = e.Item.ItemIndex
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Event: dtgCollege_ItemCreated
        Private Sub dtgCollege_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgCollege.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUp As LinkButton
                    lnkbtnUp = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgCollege__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgCollege','document.forms[0].ddlCollege','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "'));")
                    End If
            End Select
            

         

        End Sub

        ' Event: dtgCollege_UpdateCommand
        ' Purpose: update information of the selected college
        Private Sub dtgCollege_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgCollege.UpdateCommand
            Dim intOut As Integer = 0
            Dim txtType As TextBox

            ' Get data to update
            txtType = e.Item.FindControl("txtdtgCollege")
            Dim editItem As GridEditableItem = TryCast(e.Item, GridEditableItem)
            If txtType.Text <> "" Then
                objBCollege.ID = CInt(editItem.GetDataKeyValue("ID"))
                objBCollege.College = txtType.Text
                intOut = objBCollege.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBCollege.ErrorMsg, ddlLabel.Items(10).Text, objBCollege.ErrorCode)

                If intOut = 0 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(7).Text & ": " & txtCollege.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & " \'" & txtType.Text.Trim & "\' " & ddlLabel.Items(9).Text & "');</script>")

                    ' Refresh Data
                    'dtgCollege.EditItemIndex = -1
                    Call BindData()
                Else ' Exist college
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End If
        End Sub

        Private Sub dtgCollege_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgCollege.DeleteCommand
            Try
                objBCollege.ID = CInt(e.Item.Cells(2).Text)
                Call objBCollege.Delete()

                If Not (objBCollege.ErrorMsg = "") Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & " " & ddlLabel.Items(3).Text & "');</script>")
                Else
                    ' WriteLog
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                    Call WriteLog(118, ddlLabel.Items(7).Text.Trim & ": " & txtCollege.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If

                ' Check error
                'Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub dtgCollege_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgCollege.NeedDataSource
            BindData()

        End Sub

        '' Event: dtgCollege_PageIndexChanged
        'Private Sub dtgCollege_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgCollege.PageIndexChanged
        '    Try
        '        dtgCollege.EditItemIndex = -1
        '        dtgCollege.CurrentPageIndex = e.NewPageIndex
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCollege Is Nothing Then
                    objBCollege.Dispose(True)
                    objBCollege = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace