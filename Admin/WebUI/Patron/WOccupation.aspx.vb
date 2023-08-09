' Class: WOccupation
' Puspose: management occupations
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Tuanhv: review & update

Imports eMicLibAdmin.BusinessRules.Patron
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WOccupation
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
        Private objBOccupation As New clsBOccupation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
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
            objBOccupation.DBServer = Session("DBServer")
            objBOccupation.ConnectionString = Session("ConnectionString")
            objBOccupation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOccupation.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Dim strJSConfirm As String
            Dim strJSCheckMerge As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/JSMainList.js'></script>")

            btnAdd.Attributes.Add("OnClick", "javascript:return(CheckAddNew('document.forms[0].txtOccupation','document.forms[0].ddlOccupation','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")

            ' Get the js script strings 
            strJSCheckMerge = "if(!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, '" & ddlLabelNote.Items(6).Text & "')) return false;"
            strJSConfirm = "return ConfirmMerger('" & ddlLabelNote.Items(5).Text & "');"
            btnMerger.Attributes.Add("onClick", strJSCheckMerge & " else " & strJSConfirm)
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            'bind data for datagrid
            Dim tmpResult As DataTable
            Dim intItem As Integer
            Dim intCount As Integer

            tmpResult = objBOccupation.GetOccupation

            ' Check error
            Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBOccupation.ErrorMsg, ddlLabelNote.Items(8).Text, objBOccupation.ErrorCode)

            If Not tmpResult Is Nothing Then
                If tmpResult.Rows.Count > 0 Then
                    dtgOccupation.DataSource = tmpResult
                    'dtgOccupation.DataBind()
                    ddlOccupation.DataSource = tmpResult
                    ddlOccupation.DataTextField = "Occupation"
                    ddlOccupation.DataValueField = "ID"
                    ddlOccupation.SelectedIndex = 0
                    ddlOccupation.DataBind()
                End If
            End If
        End Sub

        ' Event: btnAdd_Click
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intResult As Integer
            If txtOccupation.Text <> "" Then
                objBOccupation.Occupation = txtOccupation.Text.Trim
                intResult = objBOccupation.Create()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBOccupation.ErrorMsg, ddlLabelNote.Items(8).Text, objBOccupation.ErrorCode)

                If intResult <> -1 Then
                    ' Check error
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(10).Text.Trim & " \'" & txtOccupation.Text.Trim & "\' " & ddlLabelNote.Items(15).Text & "');</script>")

                    ' WriteLog
                    Call WriteLog(118, ddlLabelNote.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData()
                    dtgOccupation.Rebind()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(3).Text & "');</script>")
                End If
            End If
            txtOccupation.Text = ""
        End Sub

        ' Event: btnMerger_Click
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As GridDataItem
            Dim chkCheckBox As HtmlInputCheckBox
            Dim intIDCur As Integer
            Dim strIDs As String

            intIDCur = CInt(ddlOccupation.SelectedValue)
            strIDs = ""
            For Each dtgItem In dtgOccupation.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    If CInt(dtgItem.Cells(2).Text) <> intIDCur Then
                        strIDs = strIDs & dtgItem.Cells(2).Text & ","
                    End If
                End If
            Next
            If strIDs <> "" Then
                strIDs = "," & strIDs
                objBOccupation.ID = CInt(ddlOccupation.SelectedValue)
                objBOccupation.IDs = strIDs
                Call objBOccupation.Merger()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBOccupation.ErrorMsg, ddlLabelNote.Items(8).Text, objBOccupation.ErrorCode)

                ' WriteLog
                Call WriteLog(118, ddlLabelNote.Items(13).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh data

                Call BindData()
                dtgOccupation.Rebind()

                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(7).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(4).Text & "');</script>")
            End If
        End Sub

        '' Event: dtgOccupation_CancelCommand
        'Private Sub dtgOccupation_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgOccupation.CancelCommand
        '    dtgOccupation.EditItemIndex = -1
        '    Call BindData()
        'End Sub

        '' Event: dtgOccupation_EditCommand
        'Private Sub dtgOccupation_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgOccupation.EditCommand
        '    If Not CheckPemission(213) Then
        '        Exit Sub
        '    End If
        '    dtgOccupation.EditItemIndex = e.Item.ItemIndex
        '    Call BindData()
        'End Sub

        Protected Sub dtgOccupation_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgOccupation.NeedDataSource
            BindData()

        End Sub


        ' Event: dtgOccupation_ItemCreated
        Private Sub dtgOccupation_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgOccupation.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUp As LinkButton
                    lnkbtnUp = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgOccupation__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgOccupation','document.forms[0].ddlOccupation','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dtgOccupation_UpdateCommand
        Private Sub dtgOccupation_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgOccupation.UpdateCommand
            Dim intResult As Integer
            Dim txtType As TextBox
            ' Get data to update
            txtType = e.Item.FindControl("txtdtgOccupation")
            Dim editItem As GridEditableItem = TryCast(e.Item, GridEditableItem)

            If txtType.Text <> "" Then
                objBOccupation.ID = CInt(editItem.GetDataKeyValue("ID"))
                objBOccupation.Occupation = txtType.Text.Trim
                intResult = objBOccupation.Update()
                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBOccupation.ErrorMsg, ddlLabelNote.Items(8).Text, objBOccupation.ErrorCode)

                If intResult = 0 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabelNote.Items(10).Text & " " & txtType.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(10).Text.Trim & " \'" & txtType.Text.Trim & "\' " & ddlLabelNote.Items(15).Text.Trim & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(3).Text & "');</script>")
                End If

                Call BindData()
            End If
        End Sub

        Private Sub dtgOccupation_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgOccupation.DeleteCommand
            Try
                objBOccupation.ID = CInt(e.Item.Cells(2).Text)
                Call objBOccupation.Delete()

                If Not (objBOccupation.ErrorMsg = "") Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(2).Text & " " & ddlLabelNote.Items(3).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(15).Text & "');</script>")
                    ' WriteLog
                    Call WriteLog(118, ddlLabelNote.Items(9).Text.Trim & ": " & txtOccupation.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If

                ' Check error
                'Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        '' Event: dtgOccupation_PageIndexChanged
        'Private Sub dtgOccupation_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgOccupation.PageIndexChanged
        '    dtgOccupation.EditItemIndex = -1
        '    dtgOccupation.CurrentPageIndex = e.NewPageIndex
        '    Call BindData()
        'End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOccupation Is Nothing Then
                    objBOccupation.Dispose(True)
                    objBOccupation = Nothing
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