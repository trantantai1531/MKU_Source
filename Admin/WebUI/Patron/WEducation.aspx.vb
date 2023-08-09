' Class: WEducation
' Puspose: management educations
' Creator: Lent
' CreatedDate: 20-1-2005
' Modification History:
'   - 25/04/2005 by Tuanhv: review & update

Imports eMicLibAdmin.BusinessRules.Patron
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WEducation
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

        ' Declare variable
        Private objBEducation As New clsBEducation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
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
        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            objBEducation.DBServer = Session("DBServer")
            objBEducation.ConnectionString = Session("ConnectionString")
            objBEducation.InterfaceLanguage = Session("InterfaceLanguage")
            objBEducation.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Dim strJSConfirm As String
            Dim strJSCheckMerge As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/JSMainList.js'></script>")

            btnAdd.Attributes.Add("OnClick", "javascript:return(CheckAddNew('document.forms[0].txtEducation','document.forms[0].ddlEducation','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")

            ' Get the js script strings 
            strJSCheckMerge = "if(!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, '" & ddlLabelNote.Items(5).Text & "')) return false;"
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

            tmpResult = objBEducation.GetEducation
            Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBEducation.ErrorMsg, ddlLabelNote.Items(8).Text, objBEducation.ErrorCode)

            If Not tmpResult Is Nothing Then
                If tmpResult.Rows.Count > 0 Then
                    intCount = CInt(tmpResult.Rows.Count / dtgEducation.PageSize)
                    intItem = intCount * dtgEducation.PageSize
                    If intItem = tmpResult.Rows.Count Then
                        If dtgEducation.CurrentPageIndex > intCount - 1 Then
                            dtgEducation.CurrentPageIndex = dtgEducation.CurrentPageIndex - 1
                        End If
                    End If
                    dtgEducation.DataSource = tmpResult
                    ' dtgEducation.DataBind()
                    ddlEducation.DataSource = tmpResult
                    ddlEducation.DataTextField = "EducationLevel"
                    ddlEducation.DataValueField = "ID"
                    ddlEducation.SelectedIndex = 0
                    ddlEducation.DataBind()
                End If
            End If
        End Sub

        ' Event: btnAdd_Click
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intResult As Integer
            If txtEducation.Text <> "" Then
                objBEducation.Education = txtEducation.Text.Trim
                intResult = objBEducation.Create()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBEducation.ErrorMsg, ddlLabelNote.Items(8).Text, objBEducation.ErrorCode)

                If intResult <> -1 Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(11).Text.Trim & " \'" & txtEducation.Text.Trim & "\' " & ddlLabelNote.Items(14).Text & "');</script>")

                    ' WriteLog
                    Call WriteLog(118, ddlLabelNote.Items(11).Text.Trim & " " & txtEducation.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Reload form
                    Call BindData()
                    dtgEducation.Rebind()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(3).Text & "');</script>")
                End If
            End If
            txtEducation.Text = ""
        End Sub

        ' Event: btnMerger_Click
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As GridDataItem
            Dim chkCheckBox As HtmlInputCheckBox
            Dim intIDCur As Integer
            Dim strIDs As String

            intIDCur = CInt(ddlEducation.SelectedValue)
            strIDs = ""
            For Each dtgItem In dtgEducation.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    If CInt(dtgItem.Cells(2).Text) <> intIDCur Then
                        strIDs = strIDs & dtgItem.Cells(2).Text & ","
                    End If
                End If
            Next
            If strIDs <> "" Then
                strIDs = "," & strIDs
                objBEducation.ID = CInt(ddlEducation.SelectedValue)
                objBEducation.IDs = strIDs
                Call objBEducation.Merger()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBEducation.ErrorMsg, ddlLabelNote.Items(8).Text, objBEducation.ErrorCode)

                ' WriteLog
                Call WriteLog(118, ddlLabelNote.Items(13).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Reload data
                Call BindData()
                dtgEducation.Rebind()
                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(7).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(4).Text & "');</script>")
            End If
        End Sub

        '' Event: dtgEducation_CancelCommand
        'Private Sub dtgEducation_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgEducation.CancelCommand
        '    dtgEducation.EditItemIndex = -1
        '    Call BindData()
        'End Sub

        '' Event: dtgEducation_EditCommand
        'Private Sub dtgEducation_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgEducation.EditCommand
        '    If Not CheckPemission(213) Then
        '        Exit Sub
        '    End If
        '    dtgEducation.EditItemIndex = e.Item.ItemIndex
        '    Call BindData()
        'End Sub

        ' Event: dtgEducation_UpdateCommand
        Private Sub dtgEducation_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgEducation.UpdateCommand
            Dim intResult As Integer
            Dim txtType As TextBox
            ' Get data to update
            txtType = e.Item.FindControl("txtdtgEducation")
            Dim editItem As GridEditableItem = TryCast(e.Item, GridEditableItem)
            If txtType.Text <> "" Then
                objBEducation.ID = CInt(editItem.GetDataKeyValue("ID"))
                objBEducation.Education = txtType.Text.Trim
                intResult = objBEducation.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(9).Text, objBEducation.ErrorMsg, ddlLabelNote.Items(8).Text, objBEducation.ErrorCode)

                If intResult = 0 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabelNote.Items(10).Text.Trim & " " & txtType.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(11).Text.Trim & " \'" & txtType.Text.Trim & "\' " & ddlLabelNote.Items(14).Text & "');</script>")

                    ' Refresh Data
                    Call BindData()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(3).Text & "');</script>")
                End If
            End If
        End Sub

        Private Sub dtgEducation_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgEducation.DeleteCommand
            Try
                objBEducation.ID = CInt(e.Item.Cells(2).Text)
                Call objBEducation.Delete()

                If Not (objBEducation.ErrorMsg = "") Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(2).Text & " " & ddlLabelNote.Items(3).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(14).Text & "');</script>")
                    ' WriteLog
                    Call WriteLog(118, ddlLabelNote.Items(9).Text.Trim & ": " & txtEducation.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If

                ' Check error
                'Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dtgEducation_ItemCreated
        Private Sub dtgEducation_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgEducation.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUp As LinkButton
                    lnkbtnUp = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgEducation__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgEducation','document.forms[0].ddlEducation','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
                    End If
            End Select
        End Sub

        '' Event: dtgEducation_PageIndexChanged
        'Private Sub dtgEducation_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgEducation.PageIndexChanged
        '    dtgEducation.EditItemIndex = -1
        '    dtgEducation.CurrentPageIndex = e.NewPageIndex
        '    Call BindData()
        'End Sub

        Protected Sub dtgEducation_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgEducation.NeedDataSource

            BindData()
        End Sub


        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEducation Is Nothing Then
                    objBEducation.Dispose(True)
                    objBEducation = Nothing
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