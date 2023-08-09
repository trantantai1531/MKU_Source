' Class WEthnic
' Puspose: management ethnic
' Creator: Lent
' CreatedDate: 19-1-2005
' Modification History:
'   - 25/04/2005 by oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WEthnic
        Inherits clsWBase 'Web.UI.Page 'clsWBase
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
        Private objBEthnic As New clsBEthnic

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
        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            objBEthnic.DBServer = Session("DBServer")
            objBEthnic.ConnectionString = Session("ConnectionString")
            objBEthnic.InterfaceLanguage = Session("InterfaceLanguage")
            objBEthnic.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Dim strJSConfirm As String
            Dim strJSCheckMerge As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/JSMainList.js'></script>")

            btnAdd.Attributes.Add("OnClick", "javascript:return(CheckAddNew('document.forms[0].txtEthnic','document.forms[0].ddlEthnic','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")

            ' Get the js script strings 
            strJSCheckMerge = "if(!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, '" & ddlLabelNote.Items(5).Text & "')) return false;"
            strJSConfirm = "return ConfirmMerger('" & ddlLabelNote.Items(4).Text & "');"
            btnMerger.Attributes.Add("onClick", strJSCheckMerge & " else " & strJSConfirm)
        End Sub

        ' BindData method
        ' Purpose: Load data
        'PhuongTT Modify : Filter & Split Pages
        Private Sub BindData(Optional ByVal _Ethnic As String = "", Optional ByVal _new As Boolean = False)
            Dim tblResult As DataView
            Dim tblResultTotal As DataTable
            Dim intItem As Integer
            Dim intCount As Integer

            tblResult = objBEthnic.GetEthnic(_Ethnic)
            tblResultTotal = objBEthnic.GetEthnic()
            ' Check error
            Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

            If Not tblResult Is Nothing Then
                If tblResult.Count > 0 Then
                    'intCount = CInt(tblResult.Count / dtgEthnic.PageSize - 0.5)
                    'intItem = intCount * dtgEthnic.PageSize
                    ''If intItem = tblResult.Count Then
                    'If _new Then
                    '    dtgEthnic.CurrentPageIndex = intCount
                    'Else
                    '    If dtgEthnic.CurrentPageIndex > intCount Then
                    '        dtgEthnic.CurrentPageIndex = intCount

                    '    End If
                    'End If
                    ' End If
                    ' Load datagrid
                    dtgEthnic.DataSource = tblResult
                    'dtgEthnic.DataBind()
                    ' Load dropdownlist
                    ddlEthnic.DataSource = tblResultTotal
                    ddlEthnic.DataTextField = "Ethnic"
                    ddlEthnic.DataValueField = "ID"
                    ddlEthnic.SelectedIndex = 0
                    ddlEthnic.DataBind()
                Else
                    dtgEthnic.DataSource = Nothing
                    'dtgEthnic.DataBind()
                    ' Load dropdownlist
                    ddlEthnic.DataSource = tblResultTotal
                    ddlEthnic.DataTextField = "Ethnic"
                    ddlEthnic.DataValueField = "ID"
                    ddlEthnic.SelectedIndex = 0
                    ddlEthnic.DataBind()
                End If
            Else
                dtgEthnic.DataSource = Nothing
                'dtgEthnic.DataBind()
                ' Load dropdownlist
                ddlEthnic.DataSource = tblResultTotal
                ddlEthnic.DataTextField = "Ethnic"
                ddlEthnic.DataValueField = "ID"
                ddlEthnic.SelectedIndex = 0
                ddlEthnic.DataBind()

            End If
        End Sub

        ' Event: btnAdd_Click
        ' Purpose: Create ethnic
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intOut As Integer = 0

            If txtEthnic.Text.Trim <> "" Then
                objBEthnic.Ethnic = txtEthnic.Text.Trim
                intOut = objBEthnic.Create()

                If objBEthnic.ErrorCode = 8152 Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(9).Text.Trim & " " & txtEthnic.Text.Trim & " " & ddlLabelNote.Items(12).Text.Trim & "');</script>")
                    Exit Sub
                End If
                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                If intOut <> -1 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabelNote.Items(9).Text & ": " & txtEthnic.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(9).Text.Trim & " \'" & txtEthnic.Text.Trim & "\' " & ddlLabelNote.Items(6).Text.Trim & "');</script>")
                    txtEthnic.Text = ""
                    ' Reload form
                    Call BindData("", True)
                    dtgEthnic.Rebind()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(3).Text.Trim & "');</script>")
                End If
            End If

        End Sub

        ' Event: dtgEthnic_EditCommand
        'Private Sub dtgEthnic_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgEthnic.EditCommand
        '    Try
        '        If Not CheckPemission(213) Then
        '            Exit Sub
        '        End If
        '        dtgEthnic.EditItemIndex = e.Item.ItemIndex
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Event: dtgEthnic_UpdateCommand
        ' Purpose: update ethnic
        Private Sub dtgEthnic_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgEthnic.UpdateCommand
            Dim intOut As Integer = 0
            Dim txtType As TextBox

            txtType = e.Item.FindControl("txtdtgEthnic")
            Dim editItem As GridEditableItem = TryCast(e.Item, GridEditableItem)

            If Not txtType.Text.Trim = "" Then
                objBEthnic.ID = CInt(editItem.GetDataKeyValue("ID"))
                objBEthnic.Ethnic = txtType.Text.Trim
                intOut = objBEthnic.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                ' WriteLog
                Call WriteLog(118, ddlLabelNote.Items(9).Text.Trim & ": " & txtEthnic.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intOut = 0 Then
                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(9).Text.Trim & " \'" & txtType.Text.Trim & "\' " & ddlLabelNote.Items(6).Text.Trim & "');</script>")

                    ' Refresh Data

                    Call BindData()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(3).Text & "');</script>")
                End If
            End If
        End Sub

        ' Event: dtgEthnic_DeleteCommand
        Private Sub dtgEthnic_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgEthnic.DeleteCommand
            Try
                objBEthnic.ID = CInt(e.Item.Cells(2).Text)
                Call objBEthnic.Delete()

                If Not (objBEthnic.ErrorMsg = "") Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(2).Text & " " & ddlLabelNote.Items(3).Text & "');</script>")
                Else
                    ' WriteLog
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabelNote.Items(6).Text & "');</script>")
                    Call WriteLog(118, ddlLabelNote.Items(9).Text.Trim & ": " & txtEthnic.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If

                ' Check error
                'Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        '' Event: dtgEthnic_CancelCommand
        'Private Sub dtgEthnic_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgEthnic.CancelCommand
        '    dtgEthnic.EditItemIndex = -1
        '    Call BindData()
        'End Sub

        ' Method: btnMerger_Click
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As GridDataItem
            Dim chkCheckBox As HtmlInputCheckBox
            Dim intIDCur As Integer
            Dim strIDs As String

            intIDCur = CInt(ddlEthnic.SelectedValue)
            strIDs = ""
            For Each dtgItem In dtgEthnic.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    If CInt(dtgItem.Cells(2).Text) <> intIDCur Then
                        strIDs = strIDs & dtgItem.Cells(2).Text & ","
                    End If
                End If
            Next
            If strIDs <> "" Then
                strIDs = "," & strIDs
                objBEthnic.ID = CInt(ddlEthnic.SelectedValue)
                objBEthnic.IDs = strIDs
                Call objBEthnic.Merger()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                ' WriteLog
                Call WriteLog(118, ddlLabelNote.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Page.RegisterClientScriptBlock("MergerSucc", "<script language='javascript'>alert('" & ddlLabelNote.Items(10).Text & " " & ddlLabelNote.Items(6).Text & "');</script>")
                Call BindData()
                dtgEthnic.Rebind()
            End If
        End Sub

        ' Event: dtgEthnic_ItemCreated
        Private Sub dtgEthnic_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgEthnic.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUp As LinkButton
                    lnkbtnUp = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgEthnic__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgEthnic','document.forms[0].ddlEthnic','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
                    End If
            End Select
        End Sub

        '' Event: dtgEthnic_PageIndexChanged
        'Private Sub dtgEthnic_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgEthnic.PageIndexChanged
        '    Try
        '        dtgEthnic.EditItemIndex = -1
        '        dtgEthnic.CurrentPageIndex = e.NewPageIndex
        '        Call BindData()
        '    Catch ex As Exception
        '    End Try
        'End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEthnic Is Nothing Then
                    objBEthnic.Dispose(True)
                    objBEthnic = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            ''Dim dvTemp As DataView = objBEthnic.GetEthnic.DefaultView
            '''dtgProvince.DataSource()
            ''If txtEthnic.Text <> "" Then
            ''    dvTemp.RowFilter = "Ethnic like '" & txtEthnic.Text.Trim() & "'"
            ''End If

            ''' Check error
            ''Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)
            ''Dim intCount, intItem As Integer
            ''If Not dvTemp Is Nothing Then
            ''    If dvTemp.Count > 0 Then
            ''        intCount = CInt(dvTemp.Count / dtgEthnic.PageSize)
            ''        intItem = intCount * dtgEthnic.PageSize
            ''        If intItem = dvTemp.Count Then
            ''            If dtgEthnic.CurrentPageIndex > intCount - 1 Then
            ''                dtgEthnic.CurrentPageIndex = dtgEthnic.CurrentPageIndex - 1
            ''            End If
            ''        Else
            ''            dtgEthnic.CurrentPageIndex = 0
            ''        End If
            ''    End If
            ''    dtgEthnic.DataSource = dvTemp
            ''    dtgEthnic.DataBind()

            ''    dtgEthnic.SelectedIndex = 0
            ''    Page.DataBind()
            ''End If
            ' txtEthnic.Text = ""
            Call BindData(txtEthnic.Text.Trim())

        End Sub


        Protected Sub dtgEthnic_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgEthnic.NeedDataSource
            Call BindData()

        End Sub


        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace