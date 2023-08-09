' Class WLibMan
' Puspose: manage library system
' Creator: Lent 
' CreatedDate: 17-2-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WLibMan
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
                hidPageIndex.Value = 0
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
        End Sub

        ' Method: CheckPermission 
        Private Sub CheckPermission()
            If Not CheckPemission(128) Then
                btnAddnewLib.Enabled = False
                btnMergerLib.Enabled = False
            End If
        End Sub

        ' Method: BindJavascript 
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WLibMan.js'></script>")

            btnAddnewLib.Attributes.Add("OnClick", "javascript:return(CheckAddNew('" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
            btnMergerLib.Attributes.Add("OnClick", "javascript:return(CheckMerger('" & ddlLabelNote.Items(14).Text & "','" & ddlLabelNote.Items(6).Text & "','" & ddlLabelNote.Items(4).Text & "','" & ddlLabelNote.Items(5).Text & "'));")
            btnReset.Attributes.Add("onclick", "javascript:ResetForm();return false;")
        End Sub

        ' Method: BindData 
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intCount As Integer
            Dim strLibIDs As String = ""

            'bind data for datagrid
            objBLibrary.LibID = clsSession.GlbSite
            tblResult = objBLibrary.GetLibrary
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                intCount = Math.Ceiling(tblResult.Rows.Count / dtgInfoLib.PageSize)
                If dtgInfoLib.CurrentPageIndex >= intCount Then
                    dtgInfoLib.CurrentPageIndex = dtgInfoLib.CurrentPageIndex - 1
                End If

                dtgInfoLib.DataSource = tblResult
                dtgInfoLib.DataBind()

                ' Bind data for dropdownlist library for merger
                ddlMergerLib.DataSource = tblResult
                ddlMergerLib.DataTextField = "FullName"
                ddlMergerLib.DataValueField = "ID"
                ddlMergerLib.DataBind()

                ' Set value for hidLibIDs
                For intCount = 0 To tblResult.Rows.Count - 1
                    strLibIDs = strLibIDs & CStr(tblResult.Rows(intCount).Item("ID")) & ","
                Next
                If strLibIDs <> "" Then
                    hidLibIDs.Value = Left(strLibIDs, Len(strLibIDs) - 1)
                Else
                    hidLibIDs.Value = 0
                End If
            End If
        End Sub

        ' btnAddnewLib_Click event
        Private Sub btnAddnewLib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddnewLib.Click
            Dim intRetVal As Integer = 0
            objBLibrary.Code = txtCodeLib.Text.Trim
            objBLibrary.Name = txtNameLib.Text.Trim
            objBLibrary.Address = txtAddressLib.Text.Trim
            objBLibrary.AccessEntry = txtCodeLib.Text.Trim
            objBLibrary.LibID = clsSession.GlbSite
            intRetVal = objBLibrary.Create

            If intRetVal = 0 Then
                ' Write log
                Call WriteLog(64, ddlLabelNote.Items(10).Text & ": " & txtNameLib.Text & "(" & txtCodeLib.Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh data
                Call BindData()

                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabelNote.Items(17).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabelNote.Items(16).Text & "');</script>")
            End If
        End Sub

        ' btnMergerLib_Click event
        Private Sub btnMergerLib_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMergerLib.Click
            Dim dtgItem As DataGridItem
            Dim chkCheckBox As CheckBox
            Dim strIDs As String = ""

            For Each dtgItem In dtgInfoLib.Items
                chkCheckBox = dtgItem.FindControl("ckbdtgMerger")
                If chkCheckBox.Checked Then
                    strIDs = strIDs & dtgItem.Cells(0).Text & ","
                End If
            Next
            If strIDs <> "" Then
                'process merger
                objBLibrary.DesLibID = CInt(ddlMergerLib.SelectedValue)
                Call objBLibrary.MergeLibrary(strIDs)
                'write log
                Call WriteLog(64, ddlLabelNote.Items(11).Text & ": " & strIDs & " -> " & ddlMergerLib.SelectedItem.Text & "(" & ddlMergerLib.SelectedItem.Value & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("MergerSucc", "<script language='javascript'>alert('" & ddlLabelNote.Items(7).Text & "');</script>")
                Call BindData()
            End If
        End Sub

        ' dtgInfoLib_ItemCreated event
        Private Sub dtgInfoLib_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgInfoLib.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUp As LinkButton
                    lnkbtnUp = CType(e.Item.FindControl("lnkdtgbtnUpdate"), LinkButton)
                    If Not lnkbtnUp Is Nothing Then
                        lnkbtnUp.Attributes.Add("OnClick", "javascript:return(CheckUpdate('" & DataBinder.Eval(e.Item.DataItem, "ID") & "','document.forms[0].dtgInfoLib__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtdtgCodeLib','document.forms[0].ddlMergerLib','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'));")
                    End If
            End Select
        End Sub

        ' dtgInfoLib_CancelCommand event
        Private Sub dtgInfoLib_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgInfoLib.CancelCommand
            dtgInfoLib.EditItemIndex = -1
            Call BindData()
        End Sub

        ' dtgInfoLib_EditCommand event
        Private Sub dtgInfoLib_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgInfoLib.EditCommand
            dtgInfoLib.EditItemIndex = e.Item.ItemIndex
            Call BindData()
        End Sub

        ' dtgInfoLib_UpdateCommand event
        Private Sub dtgInfoLib_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgInfoLib.UpdateCommand
            Dim intRetVal As Integer = 0
            Dim txtTemp As TextBox

            ' Get data to update
            txtTemp = e.Item.FindControl("txtdtgCodeLib")
            objBLibrary.Code = txtTemp.Text
            objBLibrary.AccessEntry = txtTemp.Text
            txtTemp = e.Item.FindControl("txtdtgNameLib")
            objBLibrary.Name = txtTemp.Text
            txtTemp = e.Item.FindControl("txtdtgAddressLib")
            objBLibrary.Address = txtTemp.Text
            objBLibrary.LibID = CInt(e.Item.Cells(0).Text)

            intRetVal = objBLibrary.Update()

            If intRetVal = 0 Then
                ' Write log
                Call WriteLog(64, ddlLabelNote.Items(12).Text & ": " & objBLibrary.Name, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Refresh Data
                dtgInfoLib.EditItemIndex = -1
                Call BindData()

                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabelNote.Items(12).Text & ddlLabelNote.Items(15).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabelNote.Items(16).Text & "');</script>")
            End If

        End Sub

        ' dtgInfoLib_PageIndexChanged event
        Private Sub dtgInfoLib_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgInfoLib.PageIndexChanged
            dtgInfoLib.EditItemIndex = -1
            dtgInfoLib.CurrentPageIndex = e.NewPageIndex
            hidPageIndex.Value = dtgInfoLib.CurrentPageIndex * dtgInfoLib.PageSize
            Call BindData()
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
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace