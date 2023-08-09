Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WProcInventoryDisplay
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
        Private objBCN As New clsBCopyNumber
        Private objBLoc As New clsBLocation
        Private objBLib As New clsBLibrary

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            If Not Page.IsPostBack Then
                If Request.QueryString("Action") & "" = "" Then
                    Call LoadDataToDTGrid()
                Else
                    txtAction.Value = Request.QueryString("Action")
                End If
                Call BindLink()
            End If
            If Request.QueryString("CurPage") & "" = "" Then
                Call BindData()
            Else
                If Request.QueryString("Action") & "" = "" Then
                    Call LoadDataToDTGrid()
                End If
            End If
            Call BindScript() ' Must put here
            Call ProcessReq()
            'Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init for objBCN
            objBCN.InterfaceLanguage = Session("InterfaceLanguage")
            objBCN.DBServer = Session("DBServer")
            objBCN.ConnectionString = Session("ConnectionString")
            objBCN.Initialize()

            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            objBLoc.Initialize()

            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            objBLib.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Location/WProcInventory.js'></script>")
            lnkCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', " & hidCountID.Value & ",1)"
            lnkUnCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', " & hidCountID.Value & ",0)"

        End Sub
        Private Sub BindLink()
            Dim strQuery As String
            strQuery = ""
            If Trim(Request.QueryString("LibID") & "") <> "" Then
                strQuery = strQuery & "LibID=" & Trim(Request.QueryString("LibID"))
            End If
            If Trim(Request.QueryString("LocID") & "") <> "" Then
                strQuery = strQuery & "&LocID=" & Trim(Request.QueryString("LocID"))
            End If
            If Trim(Request.QueryString("Shelf") & "") <> "" Then
                strQuery = strQuery & "&Shelf=" & Trim(Request.QueryString("Shelf"))
            End If
            lnkInUsed.NavigateUrl = "WProcInventory.aspx?" & strQuery & "&InUsed=1"
            lnkLocked.NavigateUrl = "WProcInventory.aspx?" & strQuery & "&Locked=1"
        End Sub
        ' BindData method
        Private Sub BindData()
            Dim tblGeneral As New DataTable
            Dim tblCN As New DataTable
            If Session("LibID") = "0" Then
                Exit Sub
            End If
            objBLoc.LocID = Session("LocID")
            objBLoc.LibID = Session("LibID")
            objBLoc.Shelf = Session("Shelf")
            tblGeneral = objBLoc.GetGeneralInfor(1)

            If tblGeneral.Rows.Count > 0 Then
                tblGeneral.DefaultView.RowFilter = "Type = 'LIB'"
                If tblGeneral.DefaultView.Count > 0 Then
                    lblLib.Text = tblGeneral.DefaultView(0).Item("VALUE")
                End If

                tblGeneral.DefaultView.RowFilter = "Type = 'LOC'"
                If tblGeneral.DefaultView.Count > 0 Then
                    lblLoc.Text = tblGeneral.DefaultView(0).Item("VALUE")
                End If

                If objBLoc.Shelf = "noname" Then
                    lblShelf.Text = ""
                Else
                    lblShelf.Text = objBLoc.Shelf
                End If

                tblGeneral.DefaultView.RowFilter = "Type = 'SUMCOPY'"
                If tblGeneral.DefaultView.Count > 0 Then
                    lblSumCopy.Text = tblGeneral.DefaultView(0).Item("VALUE")
                End If

                tblGeneral.DefaultView.RowFilter = "Type = 'SUMITEM'"
                If tblGeneral.DefaultView.Count > 0 Then
                    lblSumItem.Text = tblGeneral.DefaultView(0).Item("VALUE")
                End If

                tblGeneral.DefaultView.RowFilter = "Type = 'INVENTORY'"
                If tblGeneral.DefaultView.Count > 0 Then
                    lblLastLiquid.Text = tblGeneral.DefaultView(0).Item("VALUE") & " (" & tblGeneral.DefaultView(0).Item("OPENEDDATE") & " - " & tblGeneral.DefaultView(0).Item("CLOSEDDATE") & ")"
                End If
            End If

            objBCN.LibID = objBLoc.LibID
            objBCN.LocID = objBLoc.LocID
            objBCN.Shelf = objBLoc.Shelf

            ' On hold
            tblCN = objBCN.GetTotalSearch(1)
            lnkInUsed.Text = tblCN.Rows(0).Item("Total")
            tblCN.Clear()

            ' On lock
            tblCN = objBCN.GetTotalSearch(2)
            lnkLocked.Text = tblCN.Rows(0).Item("Total")
            tblCN.Clear()
        End Sub

        ' Method: LoadDataToDTGrid
        ' Purpose: Show data in datagrid
        Private Sub LoadDataToDTGrid()
            Dim strTitle, strCopyNumber, strCallNumber, strVolume, strIDs, arrIDs() As String
            Dim bytMode As Byte
            Dim inti, intStartID, intStopID, intCurPage As Integer
            Dim tblCN As New DataTable
            objBCN.LibID = clsSession.GlbSite
            If Not Session("IDs") Is Nothing AndAlso UBound(Session("IDs")) >= 0 Then
                arrIDs = Session("IDs")
                ' Get strIDs, default 200 records on a page
                intCurPage = 1
                strIDs = ""
                If Not Request.QueryString("CurPage") & "" = "" Then
                    If IsNumeric(Request.QueryString("CurPage")) Then
                        intCurPage = CInt(Request.QueryString("CurPage"))
                    End If
                End If
                intStartID = (intCurPage - 1) * 20
                intStopID = intStartID + 19
                For inti = intStartID To intStopID
                    If inti > UBound(arrIDs) Then
                        Exit For
                    End If
                    strIDs = strIDs & arrIDs(inti) & ","
                Next
                If strIDs <> "" Then
                    strIDs = Left(strIDs, Len(strIDs) - 1)
                End If
                objBCN.LibID = Session("LibID")
                objBCN.LocID = Session("LocID")
                objBCN.Shelf = Session("Shelf")
                objBCN.CallNumber = strCallNumber
                objBCN.CopyNumber = strCopyNumber
                objBCN.Volume = strVolume
                If Trim(Request.QueryString("InUsed") & "") <> "" Then
                    ' on hold
                    bytMode = 1
                ElseIf Trim(Request.QueryString("Locked") & "") <> "" Then
                    ' on lock
                    bytMode = 2
                Else
                    ' on location
                    bytMode = 0
                End If
                ' Search result
                objBCN.LibID = clsSession.GlbSite
                tblCN = objBCN.SearchCopyNumber(bytMode, strTitle, strIDs, True)
                dtgResult.Visible = False
                If Not tblCN Is Nothing AndAlso tblCN.Rows.Count > 0 Then
                    Dim intCount As Integer
                    intCount = Math.Ceiling(tblCN.Rows.Count / dtgResult.PageSize)
                    If dtgResult.CurrentPageIndex >= intCount Then
                        dtgResult.CurrentPageIndex = dtgResult.CurrentPageIndex - 1
                    End If
                    Dim intj As Integer
                    For intj = 0 To tblCN.Rows.Count - 1
                        If Not IsDBNull(tblCN.Rows(intj).Item("Price")) Then
                            tblCN.Rows(intj).Item("Price") = CInt(tblCN.Rows(intj).Item("Price"))
                        End If
                    Next
                    dtgResult.Visible = True
                    dtgResult.DataSource = tblCN
                    dtgResult.DataBind()
                    hidCountID.Value = tblCN.Rows.Count + 2
                Else
                    Page.RegisterClientScriptBlock("DataNotFoundJs", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
                End If
            End If
        End Sub

        ' Method: ProcessReq
        Private Sub ProcessReq()
            Dim strCopyIDs As String = ""

            If Trim(txtAction.Value & "") = "" Then
                Exit Sub
            End If
            strCopyIDs = hidTotalCopyIDs.Value
            If strCopyIDs <> "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
                objBCN.CopyIDs = strCopyIDs
                Select Case UCase(Trim(txtAction.Value & ""))
                    Case "UNLOCK"
                        'unlock
                        objBCN.ProcessCopyNumber(0, 0)
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        Page.RegisterClientScriptBlock("LockSuccess", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                    Case "LOCK"
                        'lock
                        objBCN.ProcessCopyNumber(1, 0)
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        Page.RegisterClientScriptBlock("UnLockSuccess", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                    Case "REMOVE"
                        'Remove
                        objBCN.ReasonID = txtReasonID.Value
                        objBCN.Remove()
                        ' Write error
                        If objBCN.ErrorMsg <> "" Then
                            Page.RegisterClientScriptBlock("ErrorRemove", "<script language='javascript'>alert('" & ddlLabel.Items(14).Text & "');</script>")
                        Else
                            Call WriteLog(41, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                            Page.RegisterClientScriptBlock("RemoveSuccess", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
                        End If
                        'Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCN.ErrorMsg, ddlLabel.Items(0).Text, objBCN.ErrorCode)
                        ' Write Log
                        'Call WriteLog(41, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        'Page.RegisterClientScriptBlock("RemoveSuccess", "<script>alert('" & ddlLabel.Items(4).Text & "');</script>")
                        'sPage.RegisterClientScriptBlock("RefreshTreeview", "<script language='javascript'>parent.location.href = 'WInvenFrame.aspx';</script>")
                End Select

                Call LoadDataToDTGrid()
            End If
            txtReasonID.Value = "1"
            txtAction.Value = ""
        End Sub

        ' RetrieveLibrary method
        ' Purpose: Retrieve libraries
        ' Input: boolean value of IsSelectAll, true if selelect all data of HOLDING_LIBRARY table
        ' Output: datatable of libraries' information
        Private Function RetrieveLibrary(ByVal IsSelectAll As Boolean) As DataTable
            If Not txtLibID.Value = "" And Not IsSelectAll Then
                objBLib.LibID = CInt(txtLibID.Value)
            End If
            RetrieveLibrary = objBLib.GetLibrary
        End Function

        ' RetrieveLocation
        ' Purpose: retrieve locations
        ' Input: two integer value of LibraryID and LocationID
        ' Output: datatable of locations' information
        Private Function RetrieveLocation(ByVal intLibID As Integer, ByVal intLocID As Integer) As DataTable
            Dim intUserID As Integer = 0
            If IsNumeric(Session("UserID")) Then
                intUserID = CInt(Session("UserID"))
            End If
            objBLoc.LibID = intLibID
            objBLoc.UserID = intUserID
            objBLoc.LocID = intLocID
            RetrieveLocation = objBLoc.GetLocation
        End Function
        ' Event: dtgResult_PageIndexChanged
        Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            dtgResult.CurrentPageIndex = e.NewPageIndex
            Call LoadDataToDTGrid()
        End Sub

        ' Event: dtgResult_CancelCommand
        Private Sub dtgResult_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.CancelCommand
            dtgResult.EditItemIndex = -1
            Call LoadDataToDTGrid()
        End Sub

        ' Event: dtgResult_EditCommand
        Private Sub dtgResult_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.EditCommand
            dtgResult.EditItemIndex = CInt(e.Item.ItemIndex)
            Call LoadDataToDTGrid()
        End Sub

        ' Event: dtgResult_UpdateCommand
        Private Sub dtgResult_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.UpdateCommand
            ' Declare variables
            Dim lngCopyID As Long
            Dim intLibID As Integer
            Dim intLocationID As Integer
            Dim strShelf As String
            Dim strCallNumber As String
            Dim strCopyNumber As String
            Dim strVolume As String
            Dim strNote As String
            Dim objtmp As Object
            Dim blnUpdate As Boolean = False
            Dim strLog As String

            If CType(e.Item.Cells(0).FindControl("chkCopyID"), CheckBox).Visible Then
                ' get value of all control
                lngCopyID = CLng(CType(e.Item.Cells(0).FindControl("lblCopyID"), Label).Text)
                intLibID = CInt(CType(e.Item.Cells(1).FindControl("ddlSelectLibrary"), DropDownList).SelectedValue)
                objtmp = CType(e.Item.Cells(2).FindControl("ddlSelectLocation"), DropDownList).SelectedValue
                If IsNumeric(objtmp) Then
                    intLocationID = CInt(objtmp)
                Else
                    intLocationID = 0
                End If
                strShelf = CType(e.Item.Cells(3).Controls.Item(0), TextBox).Text
                strVolume = CType(e.Item.Cells(6).Controls.Item(0), TextBox).Text
                strCallNumber = CType(e.Item.Cells(5).Controls.Item(0), TextBox).Text
                strNote = CType(e.Item.Cells(12).Controls.Item(0), TextBox).Text
                strCopyNumber = CType(e.Item.Cells(4).Controls.Item(0), TextBox).Text
                If objBCN.IsExistCopyNumber(strCopyNumber.Substring(4), intLocationID, clsSession.GlbSite, lngCopyID) Then
                    ' Alert Existing !
                    Page.RegisterClientScriptBlock("ExistingAlert", "<script language='JavaScript'>alert('" & lblExisting.Text & "')</script>")
                Else
                    ' Set value of objBCN' properties
                    objBCN.CopyID = lngCopyID
                    objBCN.LibID = intLibID
                    objBCN.LocID = intLocationID
                    objBCN.Shelf = strShelf
                    objBCN.Volume = strVolume
                    objBCN.CallNumber = strCallNumber
                    objBCN.Price = 0
                    objBCN.AcquiredDate = ""
                    objBCN.AcqSourceID = 0
                    objBCN.Note = strNote
                    objBCN.CopyNumber = strCopyNumber

                    ' Update
                    Call objBCN.Update()
                    ' Write Log
                    strLog = ddlLabel.Items(9).Text & ddlLabel.Items(10).Text & ": " & CType(e.Item.Cells(1).FindControl("ddlSelectLibrary"), DropDownList).SelectedItem.Text & ", " & ddlLabel.Items(11).Text & ": " & CType(e.Item.Cells(2).FindControl("ddlSelectLocation"), DropDownList).SelectedItem.Text & ", " & ddlLabel.Items(12).Text & ": " & strCopyNumber
                    Call WriteLog(41, strLog, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If
            End If
            dtgResult.EditItemIndex = -1
            Call LoadDataToDTGrid()
        End Sub

        ' Event: dtgResult_ItemDataBound
        Private Sub dtgResult_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemDataBound
            If e.Item.ItemType = ListItemType.EditItem Then
                ' Declare variables
                Dim intCount As Integer
                Dim intLibID As Integer
                Dim intSelectedLocID As Integer
                Dim ddlLib As DropDownList
                Dim tblLibrary As New DataTable
                Dim intSelectedLibID As Integer
                Dim ddlLocationTemp As New DropDownList
                Dim ddlLibraryTemp As New DropDownList
                Dim tblLocation As New DataTable
                Dim txtTextbox As TextBox
                Dim blnInUsed As Boolean = True

                ' Get all libraries
                tblLibrary = RetrieveLibrary(True)

                ' Bind library dropdown list
                intSelectedLibID = CInt(CType(e.Item.FindControl("txtSelectLibID"), TextBox).Text)
                intSelectedLocID = CInt(CType(e.Item.FindControl("txtSelectLocID"), TextBox).Text)
                ddlLib = CType(e.Item.FindControl("ddlSelectLibrary"), DropDownList)
                ddlLib.DataTextField = "Code"
                ddlLib.DataValueField = "ID"
                ddlLib.DataSource = tblLibrary
                ddlLib.DataBind()

                For intCount = 0 To tblLibrary.Rows.Count - 1
                    If tblLibrary.Rows(intCount).Item("ID") = intSelectedLibID Then
                        ddlLib.SelectedIndex = intCount
                    End If
                Next

                ' Bind location dropdownlist when the library dropdownlist is selected
                'tblLocation = RetrieveLocation(intSelectedLibID, intSelectedLocID)
                tblLocation = RetrieveLocation(intSelectedLibID, 0)
                ddlLocationTemp = CType(e.Item.FindControl("ddlSelectLocation"), DropDownList)
                If Not tblLocation Is Nothing Then
                    If tblLocation.Rows.Count > 0 Then
                        ddlLocationTemp.DataSource = tblLocation
                        ddlLocationTemp.DataBind()
                        For intCount = 0 To tblLocation.Rows.Count - 1
                            If tblLocation.Rows(intCount).Item("ID") = intSelectedLocID Then
                                ddlLocationTemp.SelectedIndex = intCount
                            End If
                        Next
                    End If
                End If

                If Not CType(e.Item.Cells(0).FindControl("chkCopyID"), CheckBox).Visible Then
                    blnInUsed = False
                End If
                ' set style for Controls
                ' Shelf
                txtTextbox = New TextBox
                txtTextbox = CType(e.Item.Cells(3).Controls.Item(0), TextBox)
                txtTextbox.CssClass = "lbTextbox"
                txtTextbox.Enabled = blnInUsed
                txtTextbox.Width = Unit.Point(20)
                ' CopyNumber
                txtTextbox = New TextBox
                txtTextbox = CType(e.Item.Cells(4).Controls.Item(0), TextBox)
                txtTextbox.CssClass = "lbTextbox"
                txtTextbox.Enabled = blnInUsed
                txtTextbox.Width = Unit.Point(100)
                ' CallNumber
                txtTextbox = New TextBox
                txtTextbox = CType(e.Item.Cells(5).Controls.Item(0), TextBox)
                txtTextbox.CssClass = "lbTextbox"
                txtTextbox.Enabled = blnInUsed
                txtTextbox.Width = Unit.Point(100)
                ' Volume
                txtTextbox = New TextBox
                txtTextbox = CType(e.Item.Cells(6).Controls.Item(0), TextBox)
                txtTextbox.CssClass = "lbTextbox"
                txtTextbox.Enabled = blnInUsed
                txtTextbox.Width = Unit.Point(30)
                ' Note
                txtTextbox = New TextBox
                txtTextbox = CType(e.Item.Cells(12).Controls.Item(0), TextBox)
                txtTextbox.CssClass = "lbTextbox"
                txtTextbox.Enabled = blnInUsed
                txtTextbox.Width = Unit.Point(100)
            End If
        End Sub
        ' PopulateLocationDropDownList method
        ' Purpose: create location dropdownlist when library dropdown list is selected
        Public Sub PopulateLocationDropDownList(ByVal sender As Object, ByVal e As System.EventArgs)
            ' Declare variables
            Dim intSelectedLibID As Integer
            Dim ddlLocationTemp As New DropDownList
            Dim ddlLibraryTemp As New DropDownList
            Dim tblLocation As New DataTable

            Dim strJS As String
            Dim objLabel As New Label
            Dim strMark As String = ""

            'objLabel = CType(dtgResult.Items.Item(dtgResult.EditItemIndex).FindControl("lblMark"), Label)
            'strMark = Replace(objLabel.Text, "<a name=""", "")
            'strMark = Replace(strMark, """>", "")
            'strJS = "<script language='JavaScript'>"
            'strJS = strJS & "self.location.href='#" & strMark & "';"
            'strJS = strJS & "</script>"
            'Page.RegisterClientScriptBlock("Bookmark1", strJS)

            ' Get ID of the selected library
            ddlLibraryTemp = CType(dtgResult.Items.Item(dtgResult.EditItemIndex).FindControl("ddlSelectLibrary"), DropDownList)
            intSelectedLibID = ddlLibraryTemp.SelectedValue

            ' Bind location dropdownlist where library dropdownlist is selected
            tblLocation = RetrieveLocation(intSelectedLibID, 0)
            ddlLocationTemp = CType(dtgResult.Items.Item(dtgResult.EditItemIndex).FindControl("ddlSelectLocation"), DropDownList)
            ddlLocationTemp.DataSource = tblLocation
            ddlLocationTemp.DataBind()
            ddlLocationTemp.SelectedIndex = ddlLocationTemp.Items.IndexOf(ddlLocationTemp.Items.FindByValue(txtLocIDdgr.Value))
            If ddlLibraryTemp.Enabled Then
                ddlLocationTemp.Enabled = True
            End If

            ' Release all objects
            ddlLibraryTemp.Dispose()
            ddlLibraryTemp = Nothing
            ddlLocationTemp.Dispose()
            ddlLocationTemp = Nothing
        End Sub
        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCN Is Nothing Then
                    objBCN.Dispose(True)
                    objBCN = Nothing
                End If
                If Not objBLoc Is Nothing Then
                    objBLoc.Dispose(True)
                    objBLoc = Nothing
                End If
                If Not objBLib Is Nothing Then
                    objBLib.Dispose(True)
                    objBLib = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace