Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WEdataCollection
        Inherits clsWBase

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

        Dim objBEData As New clsBEData

        'Event: Page_Load 
        'Purpose: Init information for form collection
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            Session("RightUser") = "165,"
            If Not CheckPemission(165) Then
                Call WriteErrorMssg(ddlLabelNote.Items(8).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Init objBCSP object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Dim strJSConfirm As String
            Dim strJSCheckMerge As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='../JS/EData/WEdataCollection.js'></script>")
            btnAdd.Attributes.Add("OnClick", "javascript:return(CheckAddNew('document.forms[0].txtCollectionName','document.forms[0].ddlCollection','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")

            ' Get the js script strings
            strJSCheckMerge = "if(!CheckOptionsNull('dtgCollection', 'cbkOption', 3, 20, '" & ddlLabelNote.Items(6).Text & "')) return false;"
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

            tmpResult = objBEData.GetCollection
            Call WriteErrorMssg(ddlLabelNote.Items(14).Text, objBEData.ErrorMsg, ddlLabelNote.Items(13).Text, objBEData.ErrorCode)
            If Not tmpResult Is Nothing Then
                If tmpResult.Rows.Count > 0 Then
                    intCount = CInt(tmpResult.Rows.Count / dtgCollection.PageSize)
                    intItem = intCount * dtgCollection.PageSize
                    If intItem = tmpResult.Rows.Count Then
                        If dtgCollection.CurrentPageIndex > intCount - 1 Then
                            dtgCollection.CurrentPageIndex = dtgCollection.CurrentPageIndex - 1
                        End If
                    End If
                End If
            End If
            dtgCollection.DataSource = tmpResult
            dtgCollection.DataBind()
            ddlCollection.DataSource = tmpResult
            ddlCollection.DataTextField = "Collection"
            ddlCollection.DataValueField = "CollectionID"
            ddlCollection.SelectedIndex = 0
            ddlCollection.DataBind()
        End Sub

        'Event: btnAdd_Click
        'Purpose: Add new record of collection.
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            If txtCollectionName.Text <> "" Then
                objBEData.Collection = txtCollectionName.Text
                Call objBEData.CreateCollectionRecord(txtDes.Text)
                Call WriteErrorMssg(ddlLabelNote.Items(14).Text, objBEData.ErrorMsg, ddlLabelNote.Items(13).Text, objBEData.ErrorCode)
                Call WriteLog(77, ddlLabelNote.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("Remote_Addr"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("AddnewSucc", "<script language='javascript'>alert('" & ddlLabelNote.Items(16).Text & "');</script>")
                Call BindData()
            End If
        End Sub

        'Event: dtgCollection_EditCommand
        Private Sub dtgCollection_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgCollection.EditCommand
            dtgCollection.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        'Event: dtgCollection_UpdateCommand
        Private Sub dtgCollection_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgCollection.UpdateCommand
            Dim txtCollectionType As TextBox
            Dim txtDescriptionType As TextBox

            ' Get data to update
            txtCollectionType = e.Item.FindControl("txtdtgCollection")
            txtDescriptionType = e.Item.FindControl("txtdtgDescription")
            If txtCollectionType.Text <> "" Then
                objBEData.CollectionID = CInt(e.Item.Cells(0).Text)
                objBEData.Collection = txtCollectionType.Text
                objBEData.Description = txtDescriptionType.Text
                Call objBEData.UpdateCollection()
                Call WriteErrorMssg(ddlLabelNote.Items(14).Text, objBEData.ErrorMsg, ddlLabelNote.Items(13).Text, objBEData.ErrorCode)
                ' Refresh Data
                Call WriteLog(77, ddlLabelNote.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("UpdateSucc", "<script language='javascript'>alert('" & ddlLabelNote.Items(15).Text & "');</script>")
                dtgCollection.EditItemIndex = -1
                Call BindData()
            End If
        End Sub

        'Event: dtgCollection_DeleteCommand
        Private Sub dtgCollection_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgCollection.DeleteCommand
            objBEData.CollectionID = CInt(e.Item.Cells(0).Text)
            Call WriteLog(77, ddlLabelNote.Items(12).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call objBEData.DeleteCollection()
            Call WriteErrorMssg(ddlLabelNote.Items(14).Text, objBEData.ErrorMsg, ddlLabelNote.Items(13).Text, objBEData.ErrorCode)
            Call BindData()
        End Sub

        'Event: dtgCollection_CancelCommand
        Private Sub dtgCollection_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgCollection.CancelCommand
            dtgCollection.EditItemIndex = -1
            Call BindData()
        End Sub

        'Event: btnMerger_Click
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As DataGridItem
            Dim chkCheckBox As CheckBox
            Dim intIDCur As Integer
            Dim strIDs As String

            intIDCur = CInt(ddlCollection.SelectedValue)
            strIDs = ""
            For Each dtgItem In dtgCollection.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    If CInt(dtgItem.Cells(0).Text) <> intIDCur Then
                        strIDs = strIDs & dtgItem.Cells(0).Text & ","
                    End If
                End If
            Next
            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                objBEData.CollectionID = CInt(ddlCollection.SelectedValue)
                Call objBEData.GroupCollection(strIDs)
                Call WriteErrorMssg(ddlLabelNote.Items(14).Text, objBEData.ErrorMsg, ddlLabelNote.Items(13).Text, objBEData.ErrorCode)
                Call WriteLog(77, ddlLabelNote.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call BindData()
                Page.RegisterClientScriptBlock("MergerSucc", "<script language='javascript'>alert('" & ddlLabelNote.Items(7).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("MergerErr", "<script language='javascript'>alert('" & ddlLabelNote.Items(4).Text & "');</script>")
            End If
        End Sub

        'Event: dtgCollection_ItemCreated
        Private Sub dtgCollection_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgCollection.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim btnlnkDelete As LinkButton
                    Dim lnkbtnUp As LinkButton
                    btnlnkDelete = e.Item.Cells(4).Controls(0)
                    btnlnkDelete.Attributes.Add("Onclick", "swapBG(this,'red'); if (!confirm('" & ddlLabelNote.Items(0).Text & " ')) {swapBG(this,'red');return false}")
                    'btnlnkDelete.Attributes.Add("Onclick", "if (!confirm('" & ddlLabelNote.Items(0).Text & " ')) {return false}")
                    lnkbtnUp = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "CollectionID") & "','document.forms[0].dtgCollection__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgCollection','document.forms[0].ddlCollection','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
                    End If
            End Select
        End Sub

        'Event dtgCollection_PageIndexChanged
        Private Sub dtgCollection_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgCollection.PageIndexChanged
            dtgCollection.EditItemIndex = -1
            dtgCollection.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace