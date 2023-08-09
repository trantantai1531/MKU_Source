' class WMoveLoc
' Puspose: process shelf position in a location of library
' Creator: Lent
' CreatedDate: 16-3-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WShelfPos
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

        ' Declare variables
        Private objBLibrary As New clsBLibrary
        Private objBLocation As New clsBLocation

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call LoadLibraries()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(131) Then
                Call WriteErrorMssg(ddlLabelNote.Items(10).Text)
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLibrary.Initialize()

            ' Initialize objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBLocation.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WShelfPos.js'></script>")

            btnAddNew.Attributes.Add("onClick", "javascript:return(CheckAddNew('" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "'));")
            btnReset.Attributes.Add("onClick", "javascript:return(ResetForm());")

            lnkShowSchema.Attributes.Add("Onclick", "javascript:return (ShowImg());")
            Me.SetCheckNumber(txtShelfWidth, ddlLabelNote.Items(11).Text)
            Me.SetCheckNumber(txtShelfDepth, ddlLabelNote.Items(11).Text)
            Me.SetCheckNumber(txtTopCoor, ddlLabelNote.Items(11).Text)
            Me.SetCheckNumber(txtLeftCoor, ddlLabelNote.Items(11).Text)
        End Sub

        ' Method: LoadLibraries 
        Private Sub LoadLibraries()
            Dim tblResult As DataTable

            ' Bind data for dropdownlist library
            tblResult = objBLibrary.GetLibrary
            ' Show libraries
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                ddlLibrary.DataSource = tblResult
                ddlLibrary.DataTextField = "FullName"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
                ddlLibrary.SelectedIndex = 0
                Call BindDataLocation()
                Call BindData()
            Else
                btnAddNew.Enabled = False
                btnReset.Enabled = False
                lnkShowSchema.Enabled = False
            End If
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblResult As New DataTable

            ' Bind data for datagrid content
            If IsNumeric(ddlLocation.SelectedValue) Then
                objBLocation.LocID = ddlLocation.SelectedValue
            Else
                objBLocation.LocID = 0
            End If

            tblResult = objBLocation.GetHoldingShelfSchema(ddlLabelNote.Items(3).Text, ddlLabelNote.Items(4).Text)
            ' Show content
            dtgContent.Visible = False
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    dtgContent.DataSource = tblResult
                    dtgContent.DataBind()
                    dtgContent.Visible = True
                End If
                tblResult = Nothing
            End If
            hidIndex.Value = -1
        End Sub

        ' Method: BindDataLocation
        ' Purpose: Load location
        Private Sub BindDataLocation()
            Dim tblResult As New DataTable

            ' Bind data for dropdownlist location
            objBLocation.UserID = Session("UserID")
            objBLocation.LibID = ddlLibrary.SelectedValue
            objBLocation.LocID = 0
            objBLocation.Status = -1
            tblResult = objBLocation.GetLocation
            If Not tblResult Is Nothing Then
                ddlLocation.DataSource = tblResult
                ddlLocation.DataTextField = "Symbol"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
                If tblResult.Rows.Count > 0 Then
                    ddlLocation.SelectedIndex = 0
                End If
                tblResult = Nothing
            End If
        End Sub

        ' Event: ddlLibrary_SelectedIndexChanged
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            Call BindDataLocation()
            Call BindData()
        End Sub

        ' Event: ddlLocation_SelectedIndexChanged
        Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
            Call BindData()
        End Sub

        ' Event: btnAddNew_Click
        Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Dim intRetval As Integer = 0
            objBLocation.LibID = ddlLibrary.SelectedValue
            objBLocation.LocID = ddlLocation.SelectedValue
            objBLocation.Shelf = txtShelf.Text
            objBLocation.Direction = 0

            objBLocation.Direction = CInt(ddlDirection.SelectedValue)

            objBLocation.Width = CInt(txtShelfWidth.Text)
            objBLocation.Depth = CInt(txtShelfDepth.Text)
            objBLocation.TopCoor = CInt(txtTopCoor.Text)
            objBLocation.LeftCoor = CInt(txtLeftCoor.Text)
            intRetval = objBLocation.CreateShelfPosition()
            If intRetval > 0 Then
                ' Writelog
                Call WriteLog(90, ddlLabelNote.Items(5).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & ddlLocation.SelectedItem.Text & " -- " & txtShelf.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                ' Reload data
                Call BindData()
            Else
                Page.RegisterClientScriptBlock("UnSuccess", "<script>alert('" & ddlLabelNote.Items(12).Text & "')</script>")
            End If

        End Sub

        ' Event: dtgContent_CancelCommand
        Private Sub dtgContent_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.CancelCommand
            dtgContent.EditItemIndex = -1
            Call BindData()
        End Sub

        ' Event: dtgContent_DeleteCommand
        Private Sub dtgContent_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.DeleteCommand
            objBLocation.LocID = ddlLocation.SelectedValue
            objBLocation.Shelf = e.Item.Cells(9).Text
            objBLocation.DeleteShelfPosition()
            ' Writelog
            Call WriteLog(90, ddlLabelNote.Items(7).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & ddlLocation.SelectedItem.Text & " -- " & e.Item.Cells(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' ReLoad form
            Call BindData()
        End Sub

        ' Event: dtgContent_EditCommand
        Private Sub dtgContent_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.EditCommand
            Try
                dtgContent.EditItemIndex = e.Item.ItemIndex
                Call BindData()
                hidIndex.Value = e.Item.ItemIndex
            Catch ex As Exception
                Call WriteErrorMssg(ddlLabelNote.Items(8).Text, ex.Message.Trim, ddlLabelNote.Items(9).Text, 0)
            End Try
        End Sub

        ' Event: dtgContent_ItemCreated
        Private Sub dtgContent_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgContent.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem
                    Dim lnkdtgDelete As LinkButton
                    Dim lnkdtgtmpUpdate As LinkButton
                    Dim ddldtgTemp As DropDownList

                    lnkdtgDelete = e.Item.Cells(7).Controls(0)
                    lnkdtgDelete.Attributes.Add("Onclick", "swapBG(this,'red'); if (confirm(' " & ddlLabelNote.Items(0).Text & " ')==false) {swapBG(this,'red');return false}")
                    ddldtgTemp = e.Item.FindControl("ddldtgDirection")
                    If Not ddldtgTemp Is Nothing Then
                        If CInt(DataBinder.Eval(e.Item.DataItem, "Direction")) = 0 Then
                            ddldtgTemp.SelectedIndex = 0
                        Else
                            ddldtgTemp.SelectedIndex = 1
                        End If
                    End If
                    lnkdtgtmpUpdate = e.Item.FindControl("lnkdtgUpdate")
                    If Not lnkdtgtmpUpdate Is Nothing Then
                        lnkdtgtmpUpdate.Attributes.Add("onclick", "javascript:return(CheckUpdate('document.forms[0].dtgContent__ctl" & CStr(e.Item.ItemIndex + 2) & "_','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dtgContent_UpdateCommand
        Private Sub dtgContent_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgContent.UpdateCommand
            Dim intRetval As Integer = 0
            Dim txtdtgTemp As TextBox
            Dim ddldtgTemp As DropDownList

            objBLocation.LocID = ddlLocation.SelectedValue

            txtdtgTemp = e.Item.FindControl("txtdtgShelf")
            objBLocation.Shelf = txtdtgTemp.Text
            txtdtgTemp = e.Item.FindControl("txtdtgWidth")
            objBLocation.Width = txtdtgTemp.Text
            txtdtgTemp = e.Item.FindControl("txtdtgDepth")
            objBLocation.Depth = txtdtgTemp.Text
            txtdtgTemp = e.Item.FindControl("txtdtgLeftCoor")
            objBLocation.LeftCoor = txtdtgTemp.Text
            txtdtgTemp = e.Item.FindControl("txtdtgTopCoor")
            objBLocation.TopCoor = txtdtgTemp.Text

            ddldtgTemp = e.Item.FindControl("ddldtgDirection")
            objBLocation.Direction = ddldtgTemp.SelectedValue
            objBLocation.SelShelf = e.Item.Cells(9).Text
            ' Update
            intRetval = objBLocation.UpdateShelfPosition()
            If intRetval > 0 Then
                ' Writelog
                Call WriteLog(90, ddlLabelNote.Items(6).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & ddlLocation.SelectedItem.Text & " -- " & e.Item.Cells(9).Text & " --> " & e.Item.Cells(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Reload form
                dtgContent.EditItemIndex = -1
                Call BindData()
            Else
                Page.RegisterClientScriptBlock("UnSuccess", "<script>alert('" & ddlLabelNote.Items(12).Text & "')</script>")
            End If


        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace