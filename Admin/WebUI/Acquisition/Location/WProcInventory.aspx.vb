Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports System.Data

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WProcInventory
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            'Call BindScript()
            'Call BindData()
            If Not Page.IsPostBack Then
                Call SearchIDs()
                '   Call LoadDataToDTGrid()
            End If
            'Call ProcessReq()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(133) Then
                Call WriteErrorMssg(ddlLabel.Items(5).Text)
            End If
        End Sub

        Private Sub SearchIDs()
            Dim strTitle, strCopyNumber, strCallNumber, strVolume, strItemCode, arrIDs(0), strAuthor As String
            Dim tblCN As New DataTable
            Dim bytMode As Byte
            Dim inti As Integer

            If Request.QueryString("LibID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LibID")) Then
                    objBCN.LibID = CInt(Request.QueryString("LibID"))
                Else
                    objBCN.LibID = 0
                End If
            Else
                objBCN.LibID = 0
            End If
            If Request.QueryString("LocID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LocID")) Then
                    objBCN.LocID = CInt(Request.QueryString("LocID"))
                Else
                    objBCN.LocID = 0
                End If
            Else
                objBCN.LocID = 0
            End If
            If Request.QueryString("shelf") & "" <> "" Then
                objBCN.Shelf = Trim(Request.QueryString("shelf") & "")
            Else
                'objBCN.Shelf = "noname"
                objBCN.Shelf = ""
            End If

            If Trim(Request.QueryString("search") & "") <> "" Then
                strCallNumber = Trim(Session("CallNumber") & "")
                strCopyNumber = Trim(Session("CopyNumber") & "")
                strVolume = Trim(Session("Volume") & "")
                strTitle = Trim(Session("Title") & "")
                strItemCode = Trim(Session("ItemCode") & "")
                strAuthor = Trim(Session("Author") & "")
            Else
                strCallNumber = ""
                strCopyNumber = ""
                strVolume = ""
                strTitle = ""
                strItemCode = ""
                strAuthor = ""
            End If

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
            ' Search on location 
            tblCN = objBCN.SearchCopyNumber2(bytMode, strTitle, "", , strItemCode)
            Dim strQuery As String
            strQuery = "AddSearch=1"
            If Trim(Request.QueryString("LibID") & "") <> "" Then
                strQuery = strQuery & "&LibID=" & Trim(Request.QueryString("LibID"))
            End If
            If Trim(Request.QueryString("LocID") & "") <> "" Then
                strQuery = strQuery & "&LocID=" & Trim(Request.QueryString("LocID"))
            End If
            If Trim(Request.QueryString("Shelf") & "") <> "" Then
                strQuery = strQuery & "&Shelf=" & Trim(Request.QueryString("Shelf"))
            End If
            If Not tblCN Is Nothing AndAlso tblCN.Rows.Count > 0 Then
                If Not strAuthor = "" Then
                    SearchAuthor(tblCN, strAuthor)
                End If
            End If

            If Not tblCN Is Nothing AndAlso tblCN.Rows.Count > 0 Then

                ReDim arrIDs(tblCN.Rows.Count - 1)
                For inti = 0 To tblCN.Rows.Count - 1
                    arrIDs(inti) = tblCN.Rows(inti).Item("ID")
                Next

                Session("IDs") = arrIDs
                Session("LibID") = objBCN.LibID
                Session("LocID") = objBCN.LocID
                Session("Shelf") = objBCN.Shelf
                Page.RegisterClientScriptBlock("RefreshJs", "<script language='javascript'>parent.mainfunc.location.href='WTaskBarFunc.aspx?Mode=1';parent.display.location.href='WProcInventoryDisplay.aspx?" & strQuery & "';</script>")
            End If
            tblCN = Nothing
        End Sub

        Sub SearchAuthor(ByRef data As DataTable, ByVal strAuthor As String)
            Dim count As Integer = 0
            While data.Rows.Count > 0 And Not (count = data.Rows.Count)
                For i As Integer = 0 To data.Rows.Count - 1
                    Dim row As DataRow = data.Rows(i)
                    Dim fieldCodeField100 As String = row.Item("FieldCodeField100").ToString()
                    Dim contentCodeField100 As String = row.Item("ContentField100").ToString()
                    If Not ((fieldCodeField100 = "100") And (contentCodeField100.Contains(strAuthor))) Then
                        data.Rows.RemoveAt(i)
                        count = 0
                        Exit For
                    End If
                    count = count + 1
                Next
            End While
        End Sub

        '' Method: ProcessReq
        'Private Sub ProcessReq()
        '    Dim dtgItem As DataGridItem
        '    Dim chkSelected As New CheckBox
        '    Dim strCopyIDs As String = ""

        '    If Trim(txtAction.Value & "") = "" Then
        '        Exit Sub
        '    End If

        '    ' Get ID of selected CheckBox
        '    For Each dtgItem In dtgResult.Items ' Get Selected CopyID
        '        chkSelected = CType(dtgItem.Cells(0).FindControl("chkCopyID"), CheckBox)
        '        If chkSelected.Checked Then
        '            strCopyIDs = strCopyIDs & CType(dtgItem.Cells(0).FindControl("lblCopyID"), Label).Text & ","
        '        End If
        '    Next
        '    If strCopyIDs <> "" Then
        '        strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
        '        ' set value for properties of object CopyNumber
        '        If Request.QueryString("LibID") & "" <> "" Then
        '            If IsNumeric(Request.QueryString("LibID")) Then
        '                objBCN.LibID = CInt(Request.QueryString("LibID"))
        '            Else
        '                objBCN.LibID = 0
        '            End If
        '        Else
        '            objBCN.LibID = 0
        '        End If
        '        If Request.QueryString("LocID") & "" <> "" Then
        '            If IsNumeric(Request.QueryString("LocID")) Then
        '                objBCN.LocID = CInt(Request.QueryString("LocID"))
        '            Else
        '                objBCN.LocID = 0
        '            End If
        '        Else
        '            objBCN.LocID = 0
        '        End If
        '        If Request.QueryString("shelf") & "" <> "" Then
        '            objBCN.Shelf = Trim(Request.QueryString("shelf") & "")
        '        Else
        '            objBCN.Shelf = ""
        '        End If
        '        objBCN.CopyIDs = strCopyIDs
        '        Select Case UCase(Trim(txtAction.Value & ""))
        '            Case "UNLOCK"
        '                'unlock
        '                objBCN.ProcessCopyNumber(0, 0)
        '                ' Write error
        '                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCN.ErrorMsg, ddlLabel.Items(0).Text, objBCN.ErrorCode)
        '                ' Write Log
        '                Call WriteLog(41, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        '                Page.RegisterClientScriptBlock("LockSuccess", "<script>alert('" & ddlLabel.Items(3).Text & "');</script>")
        '            Case "LOCK"
        '                'lock
        '                objBCN.ProcessCopyNumber(1, 0)
        '                ' Write error
        '                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCN.ErrorMsg, ddlLabel.Items(0).Text, objBCN.ErrorCode)
        '                ' Write Log
        '                Call WriteLog(41, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        '                Page.RegisterClientScriptBlock("UnLockSuccess", "<script>alert('" & ddlLabel.Items(2).Text & "');</script>")
        '            Case "REMOVE"
        '                'Remove
        '                objBCN.ReasonID = txtReasonID.Value
        '                objBCN.Remove()
        '                ' Write error
        '                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCN.ErrorMsg, ddlLabel.Items(0).Text, objBCN.ErrorCode)
        '                ' Write Log
        '                Call WriteLog(41, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        '                Page.RegisterClientScriptBlock("RemoveSuccess", "<script>alert('" & ddlLabel.Items(4).Text & "');</script>")
        '        End Select
        '        Call LoadDataToDTGrid()
        '    End If
        '    txtReasonID.Value = "0"
        '    txtAction.Value = ""
        'End Sub

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

            Session("IDs") = Nothing
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Dim strQuery As String
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Location/WProcInventory.js'></script>")
            lnkCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', 20,1)"
            lnkUnCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', 20,0)"
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

            If Request.QueryString("LibID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LibID")) Then
                    objBLoc.LibID = CInt(Request.QueryString("LibID"))
                Else
                    objBLoc.LibID = 0
                End If
            Else
                objBLoc.LibID = 0
            End If
            If Request.QueryString("LocID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LocID")) Then
                    objBLoc.LocID = CInt(Request.QueryString("LocID"))
                Else
                    objBLoc.LocID = 0
                End If
            Else
                objBLoc.LocID = 0
            End If
            If Request.QueryString("shelf") & "" <> "" Then
                objBLoc.Shelf = Trim(Request.QueryString("shelf") & "")
            Else
                objBLoc.Shelf = ""
            End If
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
            objBCN.CallNumber = ""
            objBCN.CopyNumber = ""
            objBCN.Volume = ""

            ' On hold
            'tblCN = objBCN.SearchCopyNumber(1, "")
            lnkInUsed.Text = tblCN.Rows.Count
            tblCN.Clear()

            ' On lock
            'tblCN = objBCN.SearchCopyNumber(2, "")
            lnkLocked.Text = tblCN.Rows.Count
            tblCN.Clear()
        End Sub

        '' Method: LoadDataToDTGrid
        '' Purpose: Show data in datagrid
        'Private Sub LoadDataToDTGrid()
        '    Dim strTitle As String
        '    Dim strCopyNumber As String
        '    Dim strCallNumber As String
        '    Dim strVolume As String
        '    Dim tblCN As New DataTable
        '    Dim bytMode As Byte

        '    If Request.QueryString("LibID") & "" <> "" Then
        '        If IsNumeric(Request.QueryString("LibID")) Then
        '            objBCN.LibID = CInt(Request.QueryString("LibID"))
        '        Else
        '            objBCN.LibID = 0
        '        End If
        '    Else
        '        objBCN.LibID = 0
        '    End If
        '    If Request.QueryString("LocID") & "" <> "" Then
        '        If IsNumeric(Request.QueryString("LocID")) Then
        '            objBCN.LocID = CInt(Request.QueryString("LocID"))
        '        Else
        '            objBCN.LocID = 0
        '        End If
        '    Else
        '        objBCN.LocID = 0
        '    End If
        '    If Request.QueryString("shelf") & "" <> "" Then
        '        objBCN.Shelf = Trim(Request.QueryString("shelf") & "")
        '    Else
        '        objBCN.Shelf = ""
        '    End If

        '    If Trim(Request.QueryString("search") & "") <> "" Then
        '        strCallNumber = Trim(Session("CallNumber") & "")
        '        strCopyNumber = Trim(Session("CopyNumber") & "")
        '        strVolume = Trim(Session("Volume") & "")
        '        strTitle = Trim(Session("Title") & "")
        '    Else
        '        strCallNumber = ""
        '        strCopyNumber = ""
        '        strVolume = ""
        '        strTitle = ""
        '    End If

        '    objBCN.CallNumber = strCallNumber
        '    objBCN.CopyNumber = strCopyNumber
        '    objBCN.Volume = strVolume

        '    If Trim(Request.QueryString("InUsed") & "") <> "" Then
        '        ' on hold
        '        bytMode = 1
        '    ElseIf Trim(Request.QueryString("Locked") & "") <> "" Then
        '        ' on lock
        '        bytMode = 2
        '    Else
        '        ' on location
        '        bytMode = 0
        '    End If
        '    'tblCN = objBCN.SearchCopyNumber(bytMode, strTitle)

        '    ' Show error
        '    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCN.ErrorMsg, ddlLabel.Items(0).Text, objBCN.ErrorCode)

        '    dtgResult.Visible = False
        '    If Not tblCN Is Nothing AndAlso tblCN.Rows.Count > 0 Then
        '        Dim intCount As Integer
        '        intCount = Math.Ceiling(tblCN.Rows.Count / dtgResult.PageSize)
        '        If dtgResult.CurrentPageIndex >= intCount Then
        '            dtgResult.CurrentPageIndex = dtgResult.CurrentPageIndex - 1
        '        End If
        '        dtgResult.Visible = True
        '        dtgResult.DataSource = tblCN
        '        dtgResult.DataBind()
        '        hidCountID.Value = tblCN.Rows.Count + 2
        '    End If
        '    tblCN = Nothing
        'End Sub

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

        '' PopulateLocationDropDownList method
        '' Purpose: create location dropdownlist when library dropdown list is selected
        'Public Sub PopulateLocationDropDownList(ByVal sender As Object, ByVal e As System.EventArgs)
        '    ' Declare variables
        '    Dim intSelectedLibID As Integer
        '    Dim ddlLocationTemp As New DropDownList
        '    Dim ddlLibraryTemp As New DropDownList
        '    Dim tblLocation As New DataTable

        '    ' Get ID of the selected library
        '    ddlLibraryTemp = CType(dtgResult.Items.Item(dtgResult.EditItemIndex).FindControl("ddlSelectLibrary"), DropDownList)
        '    intSelectedLibID = ddlLibraryTemp.SelectedValue

        '    ' Bind location dropdownlist where library dropdownlist is selected
        '    tblLocation = RetrieveLocation(intSelectedLibID, 0)
        '    ddlLocationTemp = CType(dtgResult.Items.Item(dtgResult.EditItemIndex).FindControl("ddlSelectLocation"), DropDownList)
        '    If Not tblLocation Is Nothing Then
        '        If tblLocation.Rows.Count > 0 Then
        '            ddlLocationTemp.DataSource = tblLocation
        '            ddlLocationTemp.DataBind()
        '            ddlLocationTemp.SelectedIndex = ddlLocationTemp.Items.IndexOf(ddlLocationTemp.Items.FindByValue(txtLocIDdgr.Value))
        '            If ddlLibraryTemp.Enabled Then
        '                ddlLocationTemp.Enabled = True
        '            End If
        '        End If
        '    End If

        '    ' Release all objects
        '    ddlLibraryTemp.Dispose()
        '    ddlLibraryTemp = Nothing
        '    ddlLocationTemp.Dispose()
        '    ddlLocationTemp = Nothing
        'End Sub

        '' Event: dtgResult_PageIndexChanged
        'Private Sub dtgResult_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        '    dtgResult.CurrentPageIndex = e.NewPageIndex
        '    Call LoadDataToDTGrid()
        'End Sub

        '' Event: dtgResult_CancelCommand
        'Private Sub dtgResult_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        '    dtgResult.EditItemIndex = -1
        '    Call LoadDataToDTGrid()
        'End Sub

        '' Event: dtgResult_EditCommand
        'Private Sub dtgResult_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        '    dtgResult.EditItemIndex = CInt(e.Item.ItemIndex)
        '    Call LoadDataToDTGrid()
        'End Sub

        '' Event: dtgResult_UpdateCommand
        'Private Sub dtgResult_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        '    ' Declare variables
        '    Dim lngCopyID As Long
        '    Dim intLibID As Integer
        '    Dim intLocationID As Integer
        '    Dim strShelf As String
        '    Dim strCallNumber As String
        '    Dim strCopyNumber As String
        '    Dim strVolume As String
        '    Dim strNote As String
        '    Dim objtmp As Object
        '    Dim blnUpdate As Boolean = False
        '    Dim strLog As String

        '    If CType(e.Item.Cells(0).FindControl("chkCopyID"), CheckBox).Visible Then
        '        ' get value of all control
        '        lngCopyID = CLng(CType(e.Item.Cells(0).FindControl("lblCopyID"), Label).Text)
        '        intLibID = CInt(CType(e.Item.Cells(1).FindControl("ddlSelectLibrary"), DropDownList).SelectedValue)
        '        objtmp = CType(e.Item.Cells(2).FindControl("ddlSelectLocation"), DropDownList).SelectedValue
        '        If IsNumeric(objtmp) Then
        '            intLocationID = CInt(objtmp)
        '        Else
        '            intLocationID = 0
        '        End If
        '        strShelf = CType(e.Item.Cells(3).Controls.Item(0), TextBox).Text
        '        strVolume = CType(e.Item.Cells(6).Controls.Item(0), TextBox).Text
        '        strCallNumber = CType(e.Item.Cells(5).Controls.Item(0), TextBox).Text
        '        strNote = CType(e.Item.Cells(12).Controls.Item(0), TextBox).Text
        '        strCopyNumber = CType(e.Item.Cells(4).Controls.Item(0), TextBox).Text
        '        If objBCN.IsExistHolding(strCopyNumber, intLocationID, lngCopyID) Then
        '            ' Alert Existing !
        '            Page.RegisterClientScriptBlock("ExistingAlert", "<script language='JavaScript'>alert('" & lblExisting.Text & "')</script>")
        '        Else
        '            ' Set value of objBCN' properties
        '            objBCN.CopyID = lngCopyID
        '            objBCN.LibID = intLibID
        '            objBCN.LocID = intLocationID
        '            objBCN.Shelf = strShelf
        '            objBCN.Volume = strVolume
        '            objBCN.CallNumber = strCallNumber
        '            objBCN.Price = 0
        '            objBCN.AcquiredDate = ""
        '            objBCN.AcqSourceID = 0
        '            objBCN.Note = strNote
        '            objBCN.CopyNumber = strCopyNumber

        '            ' Update
        '            Call objBCN.Update()

        '            ' Show error
        '            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCN.ErrorMsg, ddlLabel.Items(0).Text, objBCN.ErrorCode)
        '            ' Write Log
        '            strLog = ddlLabel.Items(9).Text & ddlLabel.Items(10).Text & ": " & CType(e.Item.Cells(1).FindControl("ddlSelectLibrary"), DropDownList).SelectedItem.Text & ", " & ddlLabel.Items(11).Text & ": " & CType(e.Item.Cells(2).FindControl("ddlSelectLocation"), DropDownList).SelectedItem.Text & ", " & ddlLabel.Items(12).Text & ": " & strCopyNumber
        '            Call WriteLog(41, strLog, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        '        End If
        '    End If
        '    dtgResult.EditItemIndex = -1
        '    Call LoadDataToDTGrid()
        'End Sub

        '' Event: dtgResult_ItemDataBound
        'Private Sub dtgResult_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        '    If e.Item.ItemType = ListItemType.EditItem Then
        '        ' Declare variables
        '        Dim intCount As Integer
        '        Dim intLibID As Integer
        '        Dim intSelectedLocID As Integer
        '        Dim ddlLib As DropDownList
        '        Dim tblLibrary As New DataTable
        '        Dim intSelectedLibID As Integer
        '        Dim ddlLocationTemp As New DropDownList
        '        Dim ddlLibraryTemp As New DropDownList
        '        Dim tblLocation As New DataTable
        '        Dim txtTextbox As TextBox
        '        Dim blnInUsed As Boolean = True

        '        ' Get all libraries
        '        tblLibrary = RetrieveLibrary(True)

        '        ' Bind library dropdown list
        '        intSelectedLibID = CInt(CType(e.Item.FindControl("txtSelectLibID"), TextBox).Text)
        '        intSelectedLocID = CInt(CType(e.Item.FindControl("txtSelectLocID"), TextBox).Text)
        '        ddlLib = CType(e.Item.FindControl("ddlSelectLibrary"), DropDownList)
        '        ddlLib.DataTextField = "Code"
        '        ddlLib.DataValueField = "ID"
        '        ddlLib.DataSource = tblLibrary
        '        ddlLib.DataBind()

        '        For intCount = 0 To tblLibrary.Rows.Count - 1
        '            If tblLibrary.Rows(intCount).Item("ID") = intSelectedLibID Then
        '                ddlLib.SelectedIndex = intCount
        '            End If
        '        Next

        '        ' Bind location dropdownlist when the library dropdownlist is selected
        '        tblLocation = RetrieveLocation(intSelectedLibID, intSelectedLocID)
        '        ddlLocationTemp = CType(e.Item.FindControl("ddlSelectLocation"), DropDownList)
        '        If Not tblLocation Is Nothing Then
        '            If tblLocation.Rows.Count > 0 Then
        '                ddlLocationTemp.DataSource = tblLocation
        '                ddlLocationTemp.DataBind()
        '                For intCount = 0 To tblLocation.Rows.Count - 1
        '                    If tblLocation.Rows(intCount).Item("ID") = intSelectedLocID Then
        '                        ddlLocationTemp.SelectedIndex = intCount
        '                    End If
        '                Next
        '            End If
        '        End If

        '        If Not CType(e.Item.Cells(0).FindControl("chkCopyID"), CheckBox).Visible Then
        '            blnInUsed = False
        '        End If
        '        ' set style for Controls
        '        ' Shelf
        '        txtTextbox = New TextBox
        '        txtTextbox = CType(e.Item.Cells(3).Controls.Item(0), TextBox)
        '        txtTextbox.CssClass = "lbTextbox"
        '        txtTextbox.Enabled = blnInUsed
        '        txtTextbox.Width = Unit.Point(20)
        '        ' CopyNumber
        '        txtTextbox = New TextBox
        '        txtTextbox = CType(e.Item.Cells(4).Controls.Item(0), TextBox)
        '        txtTextbox.CssClass = "lbTextbox"
        '        txtTextbox.Enabled = blnInUsed
        '        txtTextbox.Width = Unit.Point(100)
        '        ' CallNumber
        '        txtTextbox = New TextBox
        '        txtTextbox = CType(e.Item.Cells(5).Controls.Item(0), TextBox)
        '        txtTextbox.CssClass = "lbTextbox"
        '        txtTextbox.Enabled = blnInUsed
        '        txtTextbox.Width = Unit.Point(100)
        '        ' Volume
        '        txtTextbox = New TextBox
        '        txtTextbox = CType(e.Item.Cells(6).Controls.Item(0), TextBox)
        '        txtTextbox.CssClass = "lbTextbox"
        '        txtTextbox.Enabled = blnInUsed
        '        txtTextbox.Width = Unit.Point(30)
        '        ' Note
        '        txtTextbox = New TextBox
        '        txtTextbox = CType(e.Item.Cells(12).Controls.Item(0), TextBox)
        '        txtTextbox.CssClass = "lbTextbox"
        '        txtTextbox.Enabled = blnInUsed
        '        txtTextbox.Width = Unit.Point(100)
        '    End If
        'End Sub

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