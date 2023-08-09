' class WEDelMode.aspx
' Puspose: 
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.WebUI.Common
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WEDelMode
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

        Private objBEDelMode As New clsBElecDelMode
        Private objBGirdpager As New clsGirdPager

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                gvEdelMode.PageSize = 5
                Call BindData()

            Else
                gvEdelMode.PagerSettings.Visible = True
                objBGirdpager.gridView = gvEdelMode
                objBGirdpager.ApplyPaging(New Integer() {5, 10, 20})
                AddHandler objBGirdpager.DllPageSizeControl.SelectedIndexChanged, AddressOf ddlEye_SelectedIndexChanged
                AddHandler objBGirdpager.TxtPageIndexControl.TextChanged, AddressOf txtPageIndex_TextChanged


            End If

        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBEDelMode object
            objBEDelMode.ConnectionString = Session("ConnectionString")
            objBEDelMode.InterfaceLanguage = Session("InterfaceLanguage")
            objBEDelMode.DBServer = Session("DBServer")
            Call objBEDelMode.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            'Quan ly danh muc
            If Not CheckPemission(155) Then
                btnAddnew.Enabled = False
                gvEdelMode.Columns(3).Visible = False
                gvEdelMode.Columns(4).Visible = False
            End If
            'Nhap moi
            If CheckPemission(207) Then
                btnAddnew.Enabled = True
            End If
            'Xoa
            If CheckPemission(210) Then
                gvEdelMode.Columns(4).Visible = True
            End If
            'Sua
            If CheckPemission(209) Then
                gvEdelMode.Columns(3).Visible = True
            End If
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblEDelMode As New DataTable
            txtAddnew.Text = ""
            txtAddr.Text = ""
            gvEdelMode.Visible = False
            objBEDelMode.ID = 0
            objBEDelMode.LibID = clsSession.GlbSite
            tblEDelMode = objBEDelMode.GetElectDelMode()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBEDelMode.ErrorMsg, ddlLabel.Items(0).Text, objBEDelMode.ErrorCode)

            If Not tblEDelMode Is Nothing Then
                If tblEDelMode.Rows.Count > 0 Then
                    dgrEdelMode.DataSource = tblEDelMode
                    dgrEdelMode.DataBind()
                End If
            End If


        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("EDelivModeJs", "<script language='javascript' src='../JS/ToolsMan/WEDelMode.js'></script>")
            btnAddnew.Attributes.Add("OnClick", "javascript:return(CheckAddNew('" & ddlLabel.Items(4).Text & "'));")
            btnClose.Attributes.Add("OnClick", "javascript:self.close();")
            txtAddnew.Attributes.Add("Onchange", "if (this.value.length>20){alert('" & ddlLabel.Items(9).Text & "'); this.focus();}")
            txtAddr.Attributes.Add("Onchange", "if (this.value.length>50){alert('" & ddlLabel.Items(10).Text & "'); this.focus();}")
        End Sub




        ' Event: btnAddnew_Click
        Private Sub btnAddnew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddnew.Click
            Dim intResult As Integer
            ' Get data to create
            objBEDelMode.ModeName = Trim(txtAddnew.Text)
            objBEDelMode.ModeAddr = Trim(txtAddr.Text)

            objBEDelMode.LibID = clsSession.GlbSite
            ' Create
            intResult = objBEDelMode.Create()
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBEDelMode.ErrorMsg, ddlLabel.Items(1).Text, objBEDelMode.ErrorCode)

            ' WriteLog
            Call WriteLog(67, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If intResult > 0 Then
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
            End If
            ' Refresh data
            Call BindData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEDelMode Is Nothing Then
                    objBEDelMode.Dispose(True)
                    objBEDelMode = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub gvEdelMode_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles gvEdelMode.RowCreated
            Select Case e.Row.RowType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim myTableCell1 As TableCell
                    Dim myTableCell2 As TableCell
                    Dim myDeleteButton As LinkButton
                    Dim lnkdtgUpdate As LinkButton

                    myTableCell1 = e.Row.Cells(4)
                    myTableCell2 = e.Row.Cells(3)

                    myDeleteButton = myTableCell1.Controls(0)
                    If Not myDeleteButton Is Nothing Then
                        myDeleteButton.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabel.Items(3).Text & " ')==false) {swapBG(this,'red');return false}")
                    End If

                    lnkdtgUpdate = myTableCell2.Controls(0)
                    If Not lnkdtgUpdate Is Nothing Then
                        lnkdtgUpdate.Attributes.Add("OnClick", "javascript:return(CheckInserUpdate('document.forms[0].dgrEdelMode__ctl" & CStr(e.Row.RowIndex + 2) & "_','" & ddlLabel.Items(4).Text & "'));")
                    End If
            End Select

        End Sub

        Private Sub ddlEye_SelectedIndexChanged(sender As Object, e As System.EventArgs)

            gvEdelMode.PageSize = objBGirdpager.DllPageSizeControl.SelectedValue
            BindData()
            objBGirdpager.gridView = gvEdelMode
        End Sub

        Protected Sub gvEdelMode_PageIndexChanged(sender As Object, e As EventArgs) Handles gvEdelMode.PageIndexChanged

        End Sub

        Protected Sub gvEdelMode_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvEdelMode.PageIndexChanging
            gvEdelMode.PageIndex = e.NewPageIndex
            BindData()
        End Sub


        Protected Sub gvEdelMode_DataBound(sender As Object, e As EventArgs) Handles gvEdelMode.DataBound
            objBGirdpager.gridView = gvEdelMode
            objBGirdpager.gridView = gvEdelMode
            objBGirdpager.ApplyPaging(New Integer() {5, 10, 20})

        End Sub

        Protected Sub txtPageIndex_TextChanged(sender As Object, e As EventArgs)
            Dim intValue As Integer
            If Not Integer.TryParse(objBGirdpager.TxtPageIndexControl.Text, intValue) OrElse intValue < 1 OrElse intValue > gvEdelMode.PageCount Then
                'MessageBox.Show("Please Enter a Number from 1 to 10")
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('vui lòng nhập số từ 1 đến " & gvEdelMode.PageCount & "');</script>")
                gvEdelMode.PageIndex = 0
                BindData()
            Else
                ' MessageBox.Show("Thank You, your rating was " & TxtBox.Text)

                gvEdelMode.PageIndex = CType(objBGirdpager.TxtPageIndexControl.Text, Integer) - 1
                BindData()
            End If
        End Sub

        Protected Sub gvEdelMode_RowEditing(sender As Object, e As GridViewEditEventArgs) Handles gvEdelMode.RowEditing
            gvEdelMode.EditIndex = e.NewEditIndex

            BindData()
        End Sub

        Protected Sub gvEdelMode_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) Handles gvEdelMode.RowUpdating
            Dim txtEdelivTSAddr As New TextBox
            Dim txtEdelivTSName As New TextBox
            Dim intID As Integer
            Dim intResult As Integer

            ' Get data to update
            txtEdelivTSAddr = CType(gvEdelMode.Rows(e.RowIndex).Cells(2).Controls(0), TextBox)
            intID = Convert.ToInt32(gvEdelMode.DataKeys(e.RowIndex).Value.ToString())
            txtEdelivTSName = CType(gvEdelMode.Rows(e.RowIndex).Cells(1).Controls(0), TextBox)

            'intID = CInt(gvEdelMode.Rows(e.RowIndex).Cells(0).Text)
            objBEDelMode.ID = intID
            objBEDelMode.ModeName = txtEdelivTSName.Text
            'objBEDelMode.ModeAddr = txtEdelivTSAddr.Text.Trim
            objBEDelMode.ModeAddr = txtEdelivTSAddr.Text
            ' Update
            intResult = objBEDelMode.Update()

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBEDelMode.ErrorMsg, ddlLabel.Items(1).Text, objBEDelMode.ErrorCode)

            If intResult > 0 Then
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                'CType(gvEdelMode.Items(gvEdelMode.EditItemIndex).Cells(1).Controls(0), TextBox).ID = "txtEMode"
            Else
                ' WriteLog
                Call WriteLog(67, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh Data
                gvEdelMode.EditIndex = -1
                Call BindData()
            End If
        End Sub

        Protected Sub gvEdelMode_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs) Handles gvEdelMode.RowCancelingEdit
            gvEdelMode.EditIndex = -1

            BindData()
        End Sub

        Protected Sub gvEdelMode_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles gvEdelMode.RowDeleting
            Dim intID As Integer
            Dim txtTextbox As TextBox
            Dim intValue As Integer

            intID = Convert.ToInt32(gvEdelMode.DataKeys(e.RowIndex).Value.ToString())
            objBEDelMode.ID = intID
            intValue = objBEDelMode.Delete()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBEDelMode.ErrorMsg, ddlLabel.Items(0).Text, objBEDelMode.ErrorCode)

            ' WriteLog
            Call WriteLog(67, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            If intValue = 0 Then
                ' Alert message
                Page.RegisterClientScriptBlock("Alert1Msg", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("Alert2Msg", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
            End If
            ' Refresh Data
            gvEdelMode.EditIndex = -1
            Call BindData()
        End Sub

    End Class
End Namespace