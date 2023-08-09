' Class: WDicItemType
' Propose: 
' CreatedDate: 19/04/2004
' Creator: Sondp.
'  Modification history 
'    - 02/03/2005 by Tuanhv: review
'    - 11/05/2005 by Lent: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDicItemType
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

        Private objBDicItemType As New clsBCatDicItemType

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call Load_Data("")
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            ' New entry
            If Not CheckPemission(172) Then
                btnNew.Enabled = False
            End If
            ' Update entry
            If Not CheckPemission(6) Then
                btnGroup.Enabled = False
                dtgDicIndex.Columns(1).Visible = False
                dtgDicIndex.Columns(4).Visible = False
            End If
        End Sub

        ' Methord: BindJS
        ' Purpose: Bind data for all control need.
        Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicIndexClass.js'></script>")

            btnGroup.Attributes.Add("onClick", "return(CheckMerger('" & ddlLabel.Items(11).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(10).Text & "'))")
            btnNew.Attributes.Add("OnClick", "return(CheckAddNew('" & ddlLabel.Items(5).Text & "'));")
        End Sub

        ' Methord: Initialze
        Private Sub Initialze()
            ' Object objBDicItemType
            objBDicItemType.InterfaceLanguage = Session("InterfaceLanguage")
            objBDicItemType.DBServer = Session("DbServer")
            objBDicItemType.ConnectionString = Session("ConnectionString")
            objBDicItemType.Initialize()

        End Sub

        ' Method: Load_Data
        Private Sub Load_Data(ByVal strFiler As String)
            Dim intCount As Integer
            Dim tblTemp As New DataTable
            Dim strDicIDs As String

            objBDicItemType.TypeCode = strFiler
            tblTemp = objBDicItemType.Retrieve()
            dtgDicIndex.Visible = False
            txtGroup.Visible = False
            btnGroup.Visible = False
            ddlDic.Visible = False
            lblFilterDrop.Visible = False
            lblNoInfo.Visible = True

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                intCount = Math.Ceiling(tblTemp.Rows.Count / dtgDicIndex.PageSize)
                If dtgDicIndex.CurrentPageIndex >= intCount Then
                    dtgDicIndex.CurrentPageIndex = dtgDicIndex.CurrentPageIndex - 1
                End If
                dtgDicIndex.DataSource = tblTemp
                dtgDicIndex.DataBind()

                ddlDic.DataSource = tblTemp
                ddlDic.DataTextField = "strView"
                ddlDic.DataValueField = "ID"
                ddlDic.DataBind()

                ' Set value for hidLocIDs
                For intCount = 0 To tblTemp.Rows.Count - 1
                    strDicIDs = strDicIDs & CStr(tblTemp.Rows(intCount).Item("ID")) & ","
                Next
                If strDicIDs <> "" Then
                    hidDicIDs.Value = Left(strDicIDs, Len(strDicIDs) - 1)
                End If

                dtgDicIndex.Visible = True
                txtGroup.Visible = True
                btnGroup.Visible = True
                ddlDic.Visible = True
                lblFilterDrop.Visible = True
                lblNoInfo.Visible = False
            End If

        End Sub

        ' Event: dtgDicIndex_PageIndexChanged
        Private Sub dtgDicIndex_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgDicIndex.PageIndexChanged
            dtgDicIndex.CurrentPageIndex = e.NewPageIndex
            Me.Load_Data(txtFilter.Text)
        End Sub

        ' Event: dtgDicIndex_CancelCommand
        Private Sub dtgDicIndex_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.CancelCommand
            dtgDicIndex.EditItemIndex = -1
            Call Load_Data(txtFilter.Text)
        End Sub

        ' Event: dtgDicIndex_EditCommand
        Private Sub dtgDicIndex_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.EditCommand
            dtgDicIndex.EditItemIndex = e.Item.ItemIndex
            Call Load_Data(txtFilter.Text)
        End Sub

        ' Event: dtgDicIndex_UpdateCommand
        Private Sub dtgDicIndex_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.UpdateCommand
            Dim intRetval As Integer = 1

            objBDicItemType.ID = CInt(e.Item.Cells(0).Text)
            objBDicItemType.TypeCode = CType(e.Item.Cells(2).FindControl("txtTypeCode"), TextBox).Text
            objBDicItemType.TypeName = CType(e.Item.Cells(3).FindControl("txtTypeName"), TextBox).Text
            intRetval = objBDicItemType.Update()
            If intRetval = 0 Then
                ' Write log
                Call WriteLog(15, ddlLabel.Items(7).Text & " " & objBDicItemType.IDs & " -> " & objBDicItemType.TypeCode & ", " & objBDicItemType.TypeName, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Page.RegisterClientScriptBlock("UpdateSuccJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                dtgDicIndex.EditItemIndex = -1
                Call Load_Data(txtFilter.Text)
            Else
                Page.RegisterClientScriptBlock("DuplicateUpJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
            End If
        End Sub

        ' Event: btnFilter_Click
        Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            dtgDicIndex.CurrentPageIndex = 0
            Call Load_Data(txtFilter.Text)
        End Sub

        ' Event: txtGroup_TextChanged
        Private Sub txtGroup_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGroup.TextChanged
            Dim TblDicIndex As New DataTable
            objBDicItemType.TypeCode = txtGroup.Text
            TblDicIndex = objBDicItemType.Retrieve
            If Not TblDicIndex Is Nothing Then
                ddlDic.DataSource = TblDicIndex
                ddlDic.DataTextField = "strView"
                ddlDic.DataValueField = "ID"
                ddlDic.DataBind()
            End If
        End Sub

        ' Event : dtgDicIndex_ItemCreated
        Private Sub dtgDicIndex_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgDicIndex.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUpdate As LinkButton
                    lnkbtnUpdate = CType(e.Item.FindControl("lnkdtgUpdate"), LinkButton)
                    If Not lnkbtnUpdate Is Nothing Then
                        lnkbtnUpdate.Attributes.Add("OnClick", "javascript:return(CheckUpdate('document.forms[0].dtgDicIndex__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtTypeCode','" & ddlLabel.Items(5).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: btnNew_Click
        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
            Dim intRetval As Integer = 1

            objBDicItemType.TypeName = txtDescription.Text
            objBDicItemType.TypeCode = txtCode.Text
            intRetval = objBDicItemType.Insert()
            If intRetval = 0 Then
                ' Write log
                Call WriteLog(14, ddlLabel.Items(6).Text & " " & txtCode.Text & "-" & txtDescription.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Call Load_Data(txtFilter.Text)
                txtDescription.Text = ""
                txtCode.Text = ""
                Page.RegisterClientScriptBlock("AddSuccJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("DuplicateAddJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
            End If
        End Sub

        ' Event: btnGroup_Click
        Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
            Dim chkCheckBox As CheckBox
            Dim strIDs As String = ""
            Dim dtgItem As DataGridItem

            For Each dtgItem In dtgDicIndex.Items
                chkCheckBox = dtgItem.FindControl("ckbdtgMerger")
                If chkCheckBox.Checked Then
                    strIDs = strIDs & dtgItem.Cells(0).Text & ","
                End If
            Next

            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                objBDicItemType.IDs = strIDs
                objBDicItemType.ID = ddlDic.SelectedValue
                objBDicItemType.Merge()
                ' Write log
                Call WriteLog(16, ddlLabel.Items(8).Text & " " & strIDs & " -->" & ddlDic.SelectedItem.Text & "(" & ddlDic.SelectedValue & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Page.RegisterClientScriptBlock("MegerSuccJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
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
                    If Not objBDicItemType Is Nothing Then
                        objBDicItemType.Dispose(True)
                        objBDicItemType = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace