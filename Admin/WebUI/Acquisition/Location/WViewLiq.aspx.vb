' Class: WViewLiq
' Puspose: Excute inventory
' Creator: Tuanhv
' CreatedDate: 09/03/2004
' Modification History:
'   - 13/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WViewLiq
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents dtgCollection As System.Web.UI.WebControls.DataGrid
        Protected WithEvents dtgInventory1 As System.Web.UI.WebControls.DataGrid
        Protected WithEvents tblInvrntory1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tblInventory As System.Web.UI.WebControls.DataGrid
        Protected WithEvents tbl1 As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tbl2 As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBInventory As New clsBInventory
        Private objBLocation As New clsBLocation
        Private objBLibrary As New clsBLibrary

        ' Method: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            hidType.Value = 0
            Call CloseAllObjectItemLost(True)
            btnResultLost.Visible = True
            btnResultFalse.Visible = True

            If Not Page.IsPostBack Then
                Try
                    'hidInt.Value = Request("InventoryID")
                    'If Trim(hidInt.Value) = "" Then
                    '    hidInt.Value = Session("InventoryID")
                    'End If

                    If Session("InventoryID") & "" <> "" Then
                        hidInt.Value = Session("InventoryID")
                    Else
                        hidInt.Value = Request("InventoryID")
                    End If
                    hidLib.Value = Request("LibID")
                    hidLoc.Value = Request("LocID")
                    hidShelf.Value = Request("Shelf")
                    If Trim(hidLib.Value) <> "" Then
                        btnResultLost.Enabled = False
                        btnResultFalse.Enabled = True
                        Call BindData()
                    Else
                        Call CloseAllObjectItemLost(False)
                        btnResultLost.Visible = False
                        btnResultFalse.Visible = False
                    End If
                Catch ex As Exception
                End Try
            End If
        End Sub

        ' BindScript method
        ' Purpose: Bindjavascript
        Private Sub BindScript()
            Dim strJSCheckNull1 As String
            Dim strJSCheckNull2 As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Location/WViewLiq.js'></script>")

            strJSCheckNull1 = "if(!CheckOptionsNull('dtgInventoryLost','cbkOption', 3, 10, '" & ddlLabel.Items(17).Text & "')) return false;"
            strJSCheckNull2 = "if(!CheckOptionsNull('dtgInventoryFalsePath','cbkOption1', 3, 10, '" & ddlLabel.Items(17).Text & "')) return false;"

            btnUpdateNote.Attributes.Add("OnClick", strJSCheckNull1)
            btnDelete.Attributes.Add("OnClick", strJSCheckNull1)

            btnDelete1.Attributes.Add("OnClick", strJSCheckNull2)

            'chkCheckAll.Attributes.Add("OnClick", "javascript:CheckAllOptionsVisible('dtgInventoryLost', 'cbkOption', 3, 10);")
        End Sub

        ' Method: BindData
        Sub BindData()
            Dim tblResult As DataTable
            Dim strInventory As String = ""

            lblTypeInventory.Text = ""
            If hidType.Value = 1 Then
                ' Get Liblary
                If Trim(hidLib.Value) <> "" Then
                    objBLibrary.LibID = CInt(Trim(hidLib.Value))
                    objBLocation.LibID = CInt(Trim(hidLib.Value))
                    objBInventory.LibID = CInt(Trim(hidLib.Value))
                Else
                    objBLibrary.LibID = 0
                    objBLocation.LibID = 0
                    objBInventory.LibID = 0
                End If
                If Trim(hidLoc.Value) <> "" Then
                    objBLocation.LocID = CInt(hidLoc.Value)
                    objBInventory.LocationID = CInt(hidLoc.Value)
                Else
                    objBLocation.LocID = 0
                    objBInventory.LocationID = 0
                End If
                'hidInt.Value = Session("InventoryID")

                If Trim(hidInt.Value) <> "" Then
                    objBInventory.InventoryID = CInt(hidInt.Value)
                Else
                    objBInventory.InventoryID = 0
                End If

                strInventory = ddlLabel.Items(14).Text
                tblResult = objBLibrary.GetLibrary()
                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        'PhuongTT
                        'Modify(20080916) Name  --> FullName and [SP_HOLDING_LIBRARY_SELECT]
                        'B1
                        strInventory = strInventory & CStr(IIf(IsDBNull(tblResult.Rows(0).Item("Name")), tblResult.Rows(0).Item("FullName"), tblResult.Rows(0).Item("Name")))
                        'E1
                    End If
                End If
                tblResult = objBLocation.GetLocation
                If Not tblResult Is Nothing And Not hidLoc.Value = "" Then
                    If tblResult.Rows.Count > 0 Then
                        strInventory = strInventory & ddlLabel.Items(15).Text & CStr(tblResult.Rows(0).Item("Symbol"))
                    End If
                End If

                If hidShelf.Value <> "" And Not hidLoc.Value = "" Then
                    objBInventory.Shelf = hidShelf.Value
                    strInventory = strInventory & ddlLabel.Items(16).Text & hidShelf.Value
                Else
                    objBInventory.Shelf = ""
                End If
                lblInventory.Text = "<h3>" & strInventory & "</h3>"

                CloseObjectItemLost(False)
                tblResult = objBInventory.GetItemFalsePaths
                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        lblTypeInventory.Text = "<b><i>" & ddlLabel.Items(11).Text & tblResult.Rows.Count & "</i></b>"
                        dtgInventoryFalsePath.DataSource = tblResult
                        dtgInventoryFalsePath.DataBind()
                    Else
                        Page.RegisterClientScriptBlock("NothingJS", "<script language='javascript'>alert('" & ddlLabel.Items(19).Text & "');</script>")
                        CloseAllObjectItemLost(False)
                    End If
                Else
                    CloseAllObjectItemLost(False)
                End If
            Else
                ' Get Liblary
                If Trim(hidLib.Value) <> "" Then
                    objBLibrary.LibID = CInt(Trim(hidLib.Value))
                    objBLocation.LibID = CInt(Trim(hidLib.Value))
                    objBInventory.LibID = CInt(Trim(hidLib.Value))
                Else
                    objBLibrary.LibID = 0
                    objBLocation.LibID = 0
                    objBInventory.LibID = 0
                End If
                If Trim(hidLoc.Value) <> "" Then
                    objBLocation.LocID = CInt(hidLoc.Value)
                    objBInventory.LocationID = CInt(hidLoc.Value)
                Else
                    objBLocation.LocID = 0
                    objBInventory.LocationID = 0
                End If
                If Trim(hidInt.Value) <> "" Then
                    objBInventory.InventoryID = CInt(hidInt.Value)
                Else
                    objBInventory.InventoryID = 0
                End If

                strInventory = ddlLabel.Items(14).Text

                objBLibrary.LibID = clsSession.GlbSite
                objBLibrary.UserID = Session("UserID")
                tblResult = objBLibrary.GetLibrary
                For Each item As DataRow In tblResult.Rows
                    If item.Item("ID") = hidLib.Value Then

                    End If
                Next
                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        'PhuongTT
                        'Modify(20080916) Name  --> FullName and [SP_HOLDING_LIBRARY_SELECT]
                        Dim libName = ""
                        'B1
                        For Each item As DataRow In tblResult.Rows
                            If item.Item("ID") = hidLib.Value Then
                                libName = item.Item("Name").ToString()
                            End If
                        Next
                        If libName <> "" Then
                            strInventory = strInventory & libName
                        End If


                        'E1
                    End If
                End If
                objBLocation.UserID = Session("UserID")
                objBLocation.Status = -1
                tblResult = objBLocation.GetLocation
                If Not tblResult Is Nothing And Not hidLoc.Value = "" Then
                    If tblResult.Rows.Count > 0 Then
                        strInventory = strInventory & ddlLabel.Items(15).Text & CStr(tblResult.Rows(0).Item("Symbol"))
                    End If
                End If

                If hidShelf.Value <> "" And Not hidLoc.Value = "" Then
                    objBInventory.Shelf = hidShelf.Value
                    If hidShelf.Value <> "noname" Then
                        strInventory = strInventory & ddlLabel.Items(16).Text & hidShelf.Value
                    End If

                Else
                    objBInventory.Shelf = ""
                End If
                lblInventory.Text = "<h3>" & strInventory & "</h3>"

                tblResult = objBInventory.GetItemNoHaveReal()
                CloseObjectItemLost(True)
                If Not tblResult Is Nothing Then
                    If tblResult.Rows.Count > 0 Then
                        lblTypeInventory.Text = "<b><i>" & ddlLabel.Items(10).Text & tblResult.Rows.Count & "</i></b>"
                        dtgInventoryLost.DataSource = tblResult
                        dtgInventoryLost.DataBind()
                    Else
                        Page.RegisterClientScriptBlock("NothingJS", "<script language='javascript'>alert('" & ddlLabel.Items(20).Text & "');</script>")
                        CloseAllObjectItemLost(False)
                    End If
                Else
                    CloseAllObjectItemLost(False)
                End If
            End If
        End Sub

        ' Method: CloseObjectItemLost
        Sub CloseObjectItemLost(ByVal bol As Boolean)
            dtgInventoryLost.Visible = bol
            ddlNote.Visible = bol
            btnUpdateNote.Visible = bol
            btnDelete.Visible = bol
            btnSucessInt.Visible = bol
            lblNote.Visible = bol
            dtgInventoryFalsePath.Visible = Not bol
            btnDelete1.Visible = Not bol
        End Sub

        ' Method: CloseAllObjectItemLost
        Sub CloseAllObjectItemLost(ByVal bol As Boolean)
            dtgInventoryLost.Visible = bol
            ddlNote.Visible = bol
            btnUpdateNote.Visible = bol
            btnDelete.Visible = bol
            btnSucessInt.Visible = bol
            lblNote.Visible = bol
            dtgInventoryFalsePath.Visible = bol
            btnDelete1.Visible = bol

        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBLibrary object
            objBInventory.DBServer = Session("DBServer")
            objBInventory.ConnectionString = Session("ConnectionString")
            objBInventory.InterfaceLanguage = Session("InterfaceLanguage")
            objBInventory.Initialize()

            ' Init objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBLocation.Initialize()

            ' Init objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBLibrary.Initialize()
        End Sub

        ' Event: btnDelete1_Click
        Private Sub btnDelete1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete1.Click
            Dim dtgItem As DataGridItem
            Dim chkCheckBox As CheckBox
            Dim intIDCur As Integer
            Dim lblLabel As Label
            Dim strCopynumbers As String

            strCopynumbers = ""
            For Each dtgItem In dtgInventoryFalsePath.Items
                chkCheckBox = dtgItem.FindControl("cbkOption1")
                If chkCheckBox.Checked Then
                    lblLabel = dtgItem.FindControl("lblLabel4")
                    strCopynumbers = strCopynumbers & lblLabel.Text & ","
                End If
            Next

            If strCopynumbers <> "" Then
                strCopynumbers = Left(strCopynumbers, Len(strCopynumbers) - 1)
                'objBInventory.InventoryID = Session("InventoryID")
                objBInventory.InventoryID = hidInt.Value
                objBInventory.CopyNumbers = strCopynumbers
                objBInventory.DeleteInventory()
                Page.RegisterClientScriptBlock("SuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "');</script>")
                hidType.Value = 1
                dtgInventoryLost.CurrentPageIndex = 0
                Call BindData()
            End If
        End Sub

        ' Method: btnResultLost_Click
        Private Sub btnResultLost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResultLost.Click
            btnResultFalse.Enabled = True
            btnResultLost.Enabled = False
            hidType.Value = 0
            'hidInt.Value = Session("InventoryID")
            Call BindData()
        End Sub

        ' Method: btnResultFalse_Click
        Private Sub btnResultFalse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResultFalse.Click
            btnResultFalse.Enabled = False
            btnResultLost.Enabled = True
            hidType.Value = 1
            'hidInt.Value = Session("InventoryID")
            Call BindData()
        End Sub


        ' Event: btnUpdateNote_Click
        ' Purpose: Update note for selected items
        Private Sub btnUpdateNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateNote.Click
            Dim strReason As String
            Dim dtgItem As DataGridItem
            Dim lblCopynumber As Label
            Dim chkCheckBox As CheckBox
            Dim strIDs As String

            strIDs = ""
            For Each dtgItem In dtgInventoryLost.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    lblCopynumber = dtgItem.FindControl("lbldtgCopynumber")
                    strIDs = strIDs & "'" & lblCopynumber.Text & "',"
                End If
            Next

            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                'objBInventory.InventoryID = Session("InventoryID")
                objBInventory.InventoryID = hidInt.Value
                objBInventory.CopyNumbers = strIDs
                objBInventory.Reason = ddlNote.SelectedItem.Text
                objBInventory.UpdateInventoryRe()
                ' Reload data
                Call BindData()
            End If
        End Sub

        ' Event: btnDelete_Click
        ' Purpose: delete selected items
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim strReason As String
            Dim dtgItem As DataGridItem
            Dim chkCheckBox As CheckBox
            Dim strCopyNumbers As String
            Dim lblCopynumber As Label

            strCopyNumbers = ""
            For Each dtgItem In dtgInventoryLost.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    lblCopynumber = dtgItem.FindControl("lbldtgCopynumber")
                    strCopyNumbers = strCopyNumbers & lblCopynumber.Text & ","
                End If
            Next
            If strCopyNumbers <> "" Then
                strCopyNumbers = Left(strCopyNumbers, Len(strCopyNumbers) - 1)
                objBInventory.CopyNumbers = strCopyNumbers
                objBInventory.UserID = Session("UserID")
                'objBInventory.InventoryID = Session("InventoryID")
                objBInventory.InventoryID = hidInt.Value
                objBInventory.RemoveHoldingInvNoHave()
                Page.RegisterClientScriptBlock("SuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "');</script>")
                ' Reload data
                hidType.Value = 0
                dtgInventoryLost.CurrentPageIndex = 0
                Call BindData()
            End If
        End Sub

        ' Event: dtgInventoryFalsePath_PageIndexChanged
        Private Sub dtgInventoryFalsePath_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgInventoryFalsePath.PageIndexChanged
            Try
                dtgInventoryFalsePath.CurrentPageIndex = e.NewPageIndex
            Catch ex As Exception
                dtgInventoryFalsePath.CurrentPageIndex = 0
            End Try
            hidType.Value = 1
            Call BindData()
        End Sub

        ' Event: dtgInventoryLost_PageIndexChanged
        Private Sub dtgInventoryLost_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgInventoryLost.PageIndexChanged
            Try
                dtgInventoryLost.CurrentPageIndex = e.NewPageIndex
            Catch ex As Exception
                dtgInventoryLost.CurrentPageIndex = 0
            End Try
            hidType.Value = 0
            Call BindData()
        End Sub

        ' Event: btnSucessInt_Click
        Private Sub btnSucessInt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSucessInt.Click
            Call objBInventory.PendingLocation()
            Call BindData()
        End Sub

        ' dtgInventoryFalsePath_ItemCreated event
        Private Sub dtgInventoryFalsePath_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgInventoryFalsePath.ItemCreated
            Dim intIndex As Int16 = e.Item.ItemIndex + 3
            Dim inti As Integer
            For inti = 0 To e.Item.Cells.Count - 2
                e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dtgInventoryFalsePath','cbkOption1'," & e.Item.ItemIndex + 3 & ");")
            Next
        End Sub

        ' dtgInventoryLost_ItemCreated event
        Private Sub dtgInventoryLost_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgInventoryLost.ItemCreated
            Dim intIndex As Int16 = e.Item.ItemIndex + 3
            Dim inti As Integer
            For inti = 0 To e.Item.Cells.Count - 2
                e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dtgInventoryLost','cbkOption'," & e.Item.ItemIndex + 3 & ");")
            Next
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBInventory Is Nothing Then
                    objBInventory.Dispose(True)
                    objBInventory = Nothing
                End If
                If Not objBLocation Is Nothing Then
                    objBLocation.Dispose(True)
                    objBLocation = Nothing
                End If
                If Not objBLibrary Is Nothing Then
                    objBLibrary.Dispose(True)
                    objBLibrary = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Private Sub dtgInventoryLost_ItemDataBound(sender As Object, e As DataGridItemEventArgs) Handles dtgInventoryLost.ItemDataBound
        '    'If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
        '    'Dim a As CheckBox = DirectCast(e.Item.FindControl("chkCheckAll"), CheckBox)
        '    Dim a As CheckBox = e.Item.FindControl("chkCheckAll")
        '    a.Attributes.Add("OnClick", "javascript:CheckAllOptionsVisible_1('dtgInventoryLost', 'cbkOption', 3, 10);")
        '    'End If
        'End Sub
    End Class
End Namespace