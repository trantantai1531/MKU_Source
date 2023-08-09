' class WLocMan
' Puspose: process location
' Creator: lent
' CreatedDate: 17-2-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WLocMan
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

        Private objBLibrary As New clsBLibrary
        Private objBLocation As New clsBLocation

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Check permisssion
            Call CheckPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call LoadLibraries()
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

        ' Method: CheckPermission 
        Private Sub CheckPermission()
            If Not CheckPemission(129) Then
                btnAdd.Enabled = False
                btnMerger.Enabled = False
            End If
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WLocMan.js'></script>")

            btnAdd.Attributes.Add("OnClick", "return(CheckAddNew('" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(19).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
            btnMerger.Attributes.Add("onClick", "return(CheckMerger('" & ddlLabelNote.Items(14).Text & "','" & ddlLabelNote.Items(6).Text & "','" & ddlLabelNote.Items(4).Text & "','" & ddlLabelNote.Items(5).Text & "'))")
        End Sub

        ' Method: LoadLibraries 
        Private Sub LoadLibraries()
            Dim tblResult As DataTable
            'objBLibrary.UserID = Session("UserID")
            objBLibrary.LibID = clsSession.GlbSite
            tblResult = objBLibrary.GetLibrary()
            ' Get library
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                ddlLibrary.DataSource = tblResult
                ddlLibrary.DataTextField = "FullName"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
                ddlLibrary.SelectedIndex = 0
                Call BindData()
            Else
                btnAdd.Enabled = False
                btnMerger.Enabled = False
            End If
            hidPageIndex.Value = 0
        End Sub

        ' Method: BindData 
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intCount As Integer
            Dim inti As Integer
            Dim strLocIDs As String = ""
            ' Bind data for datagrid
            tblResult = Nothing
            objBLocation.LocID = 0
            If IsNumeric(ddlLibrary.SelectedValue) Then
                objBLocation.LibID = ddlLibrary.SelectedValue
            Else
                objBLocation.LibID = 0
            End If
            objBLocation.Status = -1
            objBLocation.UserID = Session("UserID")
            tblResult = objBLocation.GetLocation
            btnMerger.Enabled = True
            dtgLocation.Visible = False
            ddlLocation.Visible = False
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                intCount = Math.Ceiling(tblResult.Rows.Count / dtgLocation.PageSize)
                If dtgLocation.CurrentPageIndex >= intCount Then
                    dtgLocation.CurrentPageIndex = dtgLocation.CurrentPageIndex - 1
                End If
                dtgLocation.DataSource = tblResult
                dtgLocation.DataBind()
                ' Bind data for dropdownlist location

                ddlLocation.DataSource = tblResult
                ddlLocation.DataTextField = "CodeSymbol"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()

                dtgLocation.Visible = True
                ddlLocation.Visible = True
                ' Set value for hidLocIDs
                For intCount = 0 To tblResult.Rows.Count - 1
                    strLocIDs = strLocIDs & CStr(tblResult.Rows(intCount).Item("ID")) & ","
                Next
                If strLocIDs <> "" Then
                    hidLocIDs.Value = Left(strLocIDs, Len(strLocIDs) - 1)
                Else
                    hidLocIDs.Value = ""
                End If
            Else
                ddlLocation.Items.Clear()
                ddlLocation.Visible = True
                btnMerger.Enabled = False
            End If
        End Sub

        ' btnAdd_Click event
        Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim intRetVal As Integer = 0
            objBLocation.Symbol = txtLocation.Text
            objBLocation.CodeLoc = txtCode.Text
            objBLocation.LibID = ddlLibrary.SelectedValue
            objBLocation.UserID = Session("UserID")
            intRetVal = objBLocation.Create()

            If intRetVal = 1 Then ' Error 
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(16).Text & "');</script>")
            Else
                ' Write log
                Call WriteLog(88, ddlLabelNote.Items(10).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & txtLocation.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh data
                Call BindData()
                txtLocation.Text = ""
                txtCode.Text = ""
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(17).Text & "');</script>")
            End If
        End Sub

        ' btnMerger_Click event
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim dtgItem As DataGridItem
            Dim chkCheckBox As CheckBox
            Dim strIDs As String = ""

            For Each dtgItem In dtgLocation.Items
                chkCheckBox = dtgItem.FindControl("ckbdtgMerger")
                If chkCheckBox.Checked Then
                    strIDs = strIDs & dtgItem.Cells(0).Text & ","
                End If
            Next
            If strIDs <> "" Then
                objBLocation.DesLocID = ddlLocation.SelectedValue
                objBLocation.UserID = Session("UserID")
                Call objBLocation.MergeLocation(strIDs)
                ' Write log
                Call WriteLog(88, ddlLabelNote.Items(11).Text & " " & ddlLibrary.SelectedItem.Text & ":" & strIDs & " -> " & ddlLocation.SelectedItem.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                ' Alert successful and refresh data
                Page.RegisterClientScriptBlock("MergerSucc", "<script language='javascript'>alert('" & ddlLabelNote.Items(7).Text & "');</script>")
                Call BindData()
            End If
        End Sub

        ' ddlLibrary_SelectedIndexChanged event
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            If dtgLocation.EditItemIndex >= 0 Then
                dtgLocation.EditItemIndex = -1
            End If
            Call BindData()
        End Sub

        ' dtgLocation_CancelCommand event
        Private Sub dtgLocation_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgLocation.CancelCommand
            dtgLocation.EditItemIndex = -1
            Call BindData()
        End Sub

        ' dtgLocation_EditCommand event
        Private Sub dtgLocation_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgLocation.EditCommand
            dtgLocation.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        ' dtgLocation_ItemCreated event
        Private Sub dtgLocation_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgLocation.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUpdate As LinkButton
                    lnkbtnUpdate = CType(e.Item.FindControl("lnkdtgUpdate"), LinkButton)
                    If Not lnkbtnUpdate Is Nothing Then
                        lnkbtnUpdate.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgLocation__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgCode','document.forms[0].ddlLocation','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
                    End If
            End Select

        End Sub

        ' dtgLocation_PageIndexChanged event
        Private Sub dtgLocation_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgLocation.PageIndexChanged
            dtgLocation.EditItemIndex = -1
            dtgLocation.CurrentPageIndex = e.NewPageIndex
            hidPageIndex.Value = dtgLocation.CurrentPageIndex * dtgLocation.PageSize
            Call BindData()
        End Sub

        ' dtgLocation_UpdateCommand event
        Private Sub dtgLocation_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgLocation.UpdateCommand
            Dim intRetVal As Integer = 0
            Dim txtTmpLocation As TextBox

            objBLocation.LocID = CInt(e.Item.Cells(0).Text)
            txtTmpLocation = e.Item.FindControl("txtdtgLocation")
            objBLocation.Symbol = txtTmpLocation.Text.Trim
            txtTmpLocation = e.Item.FindControl("txtdtgCode")
            objBLocation.CodeLoc = txtTmpLocation.Text.Trim
            intRetVal = objBLocation.Update()

            If intRetVal = 0 Then
                ' Write log
                Call WriteLog(88, ddlLabelNote.Items(12).Text & " " & ddlLibrary.SelectedItem.Text & ": " & txtTmpLocation.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                dtgLocation.EditItemIndex = -1
                Call BindData()

                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(12).Text & ddlLabelNote.Items(15).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(16).Text & "');</script>")
            End If
        End Sub

        ' Page_Unload event
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