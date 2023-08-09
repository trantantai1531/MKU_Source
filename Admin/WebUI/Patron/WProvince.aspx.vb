' Class: WProvince
' Puspose: management province
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WProvince
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
        Private objBProvince As New clsBProvince

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
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
            objBProvince.DBServer = Session("DBServer")
            objBProvince.ConnectionString = Session("ConnectionString")
            objBProvince.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBProvince.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Dim strJSConfirm As String
            Dim strJSCheckMerge As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/JSMainList.js'></script>")

            ' Get the js script strings 
            strJSCheckMerge = "if(!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, '" & ddlLabel.Items(6).Text & "')) return false;"
            strJSConfirm = "return ConfirmMerger('" & ddlLabel.Items(5).Text & "');"
            btnMerger.Attributes.Add("onClick", strJSCheckMerge & " else " & strJSConfirm)
            btnAdd.Attributes.Add("OnClick", "javascript:return(CheckAddNew('document.forms[0].txtProvince','document.forms[0].ddlProvince','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "'));")
        End Sub

        ' Method: BindData
        ' Purpose: Load data
        'PhuongTT Modify : Filter & Split Pages
        Private Sub BindData(Optional ByVal _Province As String = "", Optional ByVal _new As Boolean = False)
            'bind data for datagrid
            Dim tblResult As DataView
            Dim tblTemp As DataTable
            Dim intItem As Integer
            Dim intCount As Integer

            tblTemp = objBProvince.GetProvince
            tblResult = objBProvince.GetProvince(_Province)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(11).Text, objBProvince.ErrorMsg, ddlLabel.Items(10).Text, objBProvince.ErrorCode)

            If Not tblResult Is Nothing Then
                If tblResult.Count > 0 Then
                    intCount = CInt(tblResult.Count / dtgProvince.PageSize - 0.5)
                    intItem = intCount * dtgProvince.PageSize
                    'If intItem = tblResult.Count Then
                    If _new Then
                        dtgProvince.CurrentPageIndex = intCount
                    Else
                        If dtgProvince.CurrentPageIndex > intCount Then
                            dtgProvince.CurrentPageIndex = intCount

                            'End If
                        End If

                    End If

                    dtgProvince.DataSource = tblResult
                    'dtgProvince.DataBind()
                    ddlProvince.DataSource = tblTemp
                    ddlProvince.DataTextField = "Province"
                    ddlProvince.DataValueField = "ID"
                    ddlProvince.SelectedIndex = 0
                    ddlProvince.DataBind()
                Else
                    dtgProvince.DataSource = Nothing
                    'dtgProvince.DataBind()
                    ddlProvince.DataSource = tblTemp
                    ddlProvince.DataTextField = "Province"
                    ddlProvince.DataValueField = "ID"
                    ddlProvince.SelectedIndex = 0
                    ddlProvince.DataBind()
                End If
            Else
                dtgProvince.DataSource = Nothing
                'dtgProvince.DataBind()
                ddlProvince.DataSource = tblTemp
                ddlProvince.DataTextField = "Province"
                ddlProvince.DataValueField = "ID"
                ddlProvince.SelectedIndex = 0
                ddlProvince.DataBind()
            End If
        End Sub

        ' Event: btnAdd_Click
        ' Purpose: Create new province
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intOut As Integer = 0

            If txtProvince.Text <> "" Then
                objBProvince.Province = txtProvince.Text.Trim
                intOut = objBProvince.Create()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBProvince.ErrorMsg, ddlLabel.Items(10).Text, objBProvince.ErrorCode)

                If intOut <> -1 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(7).Text & ": " & txtProvince.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & " \'" & txtProvince.Text.Trim & "\' " & ddlLabel.Items(9).Text & "');</script>")

                    ' Refresh Data
                    Call BindData("", False)
                    dtgProvince.Rebind()
                Else
                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End If
            txtProvince.Text = ""
        End Sub

        ' Event: btnMerger_Click
        ' Purpose: Merger some province
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As GridDataItem
            Dim chkCheckBox As HtmlInputCheckBox
            Dim intIDCur As Integer
            Dim strIDs As String

            intIDCur = CInt(ddlProvince.SelectedValue)
            strIDs = ""
            For Each dtgItem In dtgProvince.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    If CInt(dtgItem.Cells(2).Text) <> intIDCur Then
                        strIDs = strIDs & dtgItem.Cells(2).Text & ","
                    End If
                End If
            Next
            If strIDs <> "" Then
                strIDs = "," & strIDs
                objBProvince.ID = CInt(ddlProvince.SelectedValue)
                objBProvince.IDs = strIDs
                Call objBProvince.Merger()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBProvince.ErrorMsg, ddlLabel.Items(10).Text, objBProvince.ErrorCode)

                ' WriteLog
                Call WriteLog(118, ddlLabel.Items(7).Text.Trim & ": " & txtProvince.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text.Trim & " " & ddlLabel.Items(9).Text & "');</script>")
                Call BindData()
                dtgProvince.Rebind()
            End If
        End Sub

        ' Event: dtgProvince_CancelCommand
        'Private Sub dtgProvince_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgProvince.CancelCommand
        '    dtgProvince.EditItemIndex = -1
        '    Call BindData()
        'End Sub


        ' Event: dtgProvince_EditCommand
        'Private Sub dtgProvince_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgProvince.EditCommand
        '    If Not CheckPemission(213) Then
        '        Exit Sub
        '    End If
        '    dtgProvince.EditItemIndex = e.Item.ItemIndex
        '    Call BindData()
        'End Sub

        ' Event: dtgProvince_ItemCreated
        Private Sub dtgProvince_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dtgProvince.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUp As LinkButton
                    lnkbtnUp = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgProvince__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgProvince','document.forms[0].ddlProvince','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dtgProvince_UpdateCommand
        Private Sub dtgProvince_UpdateCommandd(sender As Object, e As GridCommandEventArgs) Handles dtgProvince.UpdateCommand
            Dim intOut As Integer = 0
            Dim txtType As TextBox

            ' Get data to update
            txtType = e.Item.FindControl("txtdtgProvince")
            If txtType.Text <> "" Then
                objBProvince.ID = CInt(e.Item.Cells(0).Text)
                objBProvince.Province = txtType.Text.Trim
                intOut = objBProvince.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(11).Text, objBProvince.ErrorMsg, ddlLabel.Items(10).Text, objBProvince.ErrorCode)

                If intOut = 0 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(7).Text.Trim & ": " & txtProvince.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text.Trim & " \'" & txtType.Text.Trim & "\' " & ddlLabel.Items(9).Text & "');</script>")

                    ' Refresh Data
                    ' dtgProvince.EditItemIndex = -1
                    Call BindData()
                Else
                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End If
        End Sub

        Private Sub dtgProvince_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgProvince.DeleteCommand
            Try
                objBProvince.ID = CInt(e.Item.Cells(2).Text)
                Call objBProvince.Delete()

                If Not (objBProvince.ErrorMsg = "") Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & " " & ddlLabel.Items(3).Text & "');</script>")
                Else
                    ' WriteLog
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                    Call WriteLog(118, ddlLabel.Items(7).Text & " " & txtProvince.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If

                ' Check error
                'Call WriteErrorMssg(ddlLabelNote.Items(8).Text, objBEthnic.ErrorMsg, ddlLabelNote.Items(7).Text, objBEthnic.ErrorCode)

                Call BindData()
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub dtgProvince_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgProvince.NeedDataSource
            Call BindData()

        End Sub

        ' Event: dtgProvince_PageIndexChanged
        'Private Sub dtgProvince_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgProvince.PageIndexChanged
        '    dtgProvince.EditItemIndex = -1
        '    dtgProvince.CurrentPageIndex = e.NewPageIndex
        '    Call BindData()
        'End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose 
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBProvince Is Nothing Then
                    objBProvince.Dispose(True)
                    objBProvince = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            'Dim dvTemp As DataView = objBProvince.GetProvince.DefaultView
            ''dtgProvince.DataSource()
            'If txtProvince.Text <> "" Then
            '    dvTemp.RowFilter = "Province like '" & txtProvince.Text.Trim() & "'"
            'End If

            '' Check error
            'Call WriteErrorMssg(ddlLabel.Items(11).Text, objBProvince.ErrorMsg, ddlLabel.Items(10).Text, objBProvince.ErrorCode)
            'Dim intCount, intItem As Integer
            'If Not dvTemp Is Nothing Then
            '    If dvTemp.Count > 0 Then
            '        intCount = CInt(dvTemp.Count / dtgProvince.PageSize)
            '        intItem = intCount * dtgProvince.PageSize
            '        If intItem = dvTemp.Count Then
            '            If dtgProvince.CurrentPageIndex > intCount - 1 Then
            '                dtgProvince.CurrentPageIndex = dtgProvince.CurrentPageIndex - 1
            '            End If
            '        End If
            '    End If
            '    dtgProvince.DataSource = dvTemp
            '    dtgProvince.DataBind()
            '    ddlProvince.DataSource = dvTemp
            '    ddlProvince.DataTextField = "Province"
            '    ddlProvince.DataValueField = "ID"
            '    ddlProvince.SelectedIndex = 0
            '    ddlProvince.DataBind()
            'End If
            ' txtProvince.Text = ""
            Call BindData(txtProvince.Text.Trim)
            dtgProvince.Rebind()
        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
    End Class
End Namespace