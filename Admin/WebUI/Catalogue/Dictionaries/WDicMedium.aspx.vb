Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDicMedium
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

        Private objBDicMedium As New clsBCatDicMedium

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call Load_Data("")
            End If
        End Sub

        ' Methord: BindJavascript
        ' Popurse: bind javascript for all control need
        Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicIndexClass.js'></script>")

            btnGroup.Attributes.Add("onClick", "CreateIDs();")
        End Sub

        ' Methord Initialze
        Private Sub Initialze()
            ' Object objBDicMedium
            objBDicMedium.InterfaceLanguage = Session("InterfaceLanguage")
            objBDicMedium.DBServer = Session("DbServer")
            objBDicMedium.ConnectionString = Session("ConnectionString")
            objBDicMedium.Initialize()

            dtgDicIndex.HeaderStyle.CssClass = "lbGridHeader"
            dtgDicIndex.PagerStyle.CssClass = "lbGridPager"
            dtgDicIndex.AlternatingItemStyle.CssClass = "lbGridAlterCell"
            dtgDicIndex.ItemStyle.CssClass = "lbGridCell"
            dtgDicIndex.EditItemStyle.CssClass = "lbGridEdit"
        End Sub

        ' Methord: Load_Data
        Private Sub Load_Data(ByVal strFiler As String, Optional ByVal intPage As Integer = 0)

            Dim intCount As Integer
            Dim tblTemp As New DataTable
            Dim strDicIDs As String

            objBDicMedium.Code = strFiler
            tblTemp = objBDicMedium.Retrieve()
            dtgDicIndex.Visible = False
            txtGroup.Visible = False
            btnGroup.Visible = False
            ddlDic.Visible = False
            lblFilterDrop.Visible = False


            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                intCount = Math.Ceiling(tblTemp.Rows.Count / dtgDicIndex.PageSize)
                If dtgDicIndex.CurrentPageIndex >= intCount Then
                    dtgDicIndex.CurrentPageIndex = dtgDicIndex.CurrentPageIndex - 1
                End If
                dtgDicIndex.CurrentPageIndex = intPage
                dtgDicIndex.DataSource = tblTemp
                dtgDicIndex.DataBind()

                ddlDic.DataSource = tblTemp
                ddlDic.DataTextField = "Description"
                ddlDic.DataValueField = "ID"

                ddlDic.DataBind()

                ' Set value for hidLocIDs
                For intCount = 0 To tblTemp.Rows.Count - 1
                    strDicIDs = strDicIDs & CStr(tblTemp.Rows(intCount).Item("ID")) & ","
                Next
                If strDicIDs <> "" Then
                    strDicIDs = Left(strDicIDs, Len(strDicIDs) - 1)
                End If

                dtgDicIndex.Visible = True
                txtGroup.Visible = True
                btnGroup.Visible = True
                ddlDic.Visible = True
                lblFilterDrop.Visible = True

            End If
        End Sub

        ' Event: dtgDicIndex_PageIndexChanged
        Private Sub dtgDicIndex_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgDicIndex.PageIndexChanged
            Me.Load_Data(txtFilter.Text, e.NewPageIndex)
        End Sub

        ' Event: dtgDicIndex_CancelCommand
        Private Sub dtgDicIndex_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.CancelCommand
            dtgDicIndex.EditItemIndex = -1
            Call Load_Data(txtFilter.Text, dtgDicIndex.CurrentPageIndex)
        End Sub

        ' Event: dtgDicIndex_EditCommand
        Private Sub dtgDicIndex_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.EditCommand
            dtgDicIndex.EditItemIndex = CInt(e.Item.ItemIndex)
            Call Load_Data(txtFilter.Text, dtgDicIndex.CurrentPageIndex)
        End Sub

        ' Event: dtgDicIndex_UpdateCommand
        'PhuongTT 20080821
        'Modify : Replace IDs --> ID
        Private Sub dtgDicIndex_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.UpdateCommand
            If CType(e.Item.Cells(2).FindControl("txtDescriptionG"), TextBox).Enabled Then
                objBDicMedium.ID = CType(e.Item.Cells(0).FindControl("lblID"), Label).Text
                objBDicMedium.Code = CType(e.Item.Cells(2).FindControl("txtCodeG"), TextBox).Text
                objBDicMedium.Description = CType(e.Item.Cells(3).FindControl("txtDescriptionG"), TextBox).Text
                objBDicMedium.Update()
            End If
            dtgDicIndex.EditItemIndex = -1
            Call Load_Data(txtFilter.Text, dtgDicIndex.CurrentPageIndex)
        End Sub

        ' Event: btnFilter_Click
        Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Call Load_Data(txtFilter.Text)
        End Sub

        ' Event: txtGroup_TextChanged
        Private Sub txtGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroup.TextChanged
            Dim TblDicIndex As New DataTable
            If Trim(txtGroup.Text) <> "" Then
                objBDicMedium.Code = txtGroup.Text
                TblDicIndex = objBDicMedium.Retrieve
                ddlDic.DataSource = TblDicIndex
                ddlDic.DataTextField = "Code"
                ddlDic.DataValueField = "ID"
                ddlDic.DataBind()
            Else
                ddlDic.DataSource = TblDicIndex
                ddlDic.DataBind()
            End If
        End Sub

        ' Event: btnNew_Click
        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
            objBDicMedium.Description = txtDescription.Text
            objBDicMedium.Code = txtCode.Text
            objBDicMedium.Insert()
            Call Load_Data(txtFilter.Text)
            txtDescription.Text = ""
            txtCode.Text = ""
        End Sub

        ' Event: btnGroup_Click
        Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
            Dim strIDsCheck As String
            If IsNumeric(ddlDic.SelectedValue & "") Then
                strIDsCheck = txtIDs.Value
                If strIDsCheck <> "" Then
                    objBDicMedium.IDs = strIDsCheck
                    objBDicMedium.ID = ddlDic.SelectedValue
                    objBDicMedium.Merge()
                Else
                    ' chua chon ID can gop
                End If
            Else
                ' chua chon IDNew
            End If
            Call Load_Data(txtFilter.Text)
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBDicMedium Is Nothing Then
                        objBDicMedium.Dispose(True)
                        objBDicMedium = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace