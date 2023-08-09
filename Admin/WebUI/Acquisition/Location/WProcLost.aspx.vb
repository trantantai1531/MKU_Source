Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WProcLost
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
            Call SearchRemoveIDs()
            'Call BindScript()
            'Call BindData()
            'If Not Page.IsPostBack Then
            '    Call LoadDDL()
            '    Call LoadDataToDTGrid()
            'End If
            'Call ProcessReq()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(134) Then
                Call WriteErrorMssg(ddlLabel.Items(4).Text)
            End If
        End Sub

        ' Purpose: search Holding_Remove IDs depend on some conditions
        Private Sub SearchRemoveIDs()
            Dim strTitle, strItemCode As String
            Dim tblCN As New DataTable
            Dim arrIDs() As String
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
                objBCN.Shelf = ""
            End If

            If Trim(Request.QueryString("search") & "") <> "" Then
                objBCN.CallNumber = Trim(Session("CallNumber") & "")
                objBCN.CopyNumber = Trim(Session("CopyNumber") & "")
                objBCN.Volume = Trim(Session("Volume") & "")
                strTitle = Trim(Session("Title") & "")
                strItemCode = Trim(Session("ItemCode") & "")
            Else
                objBCN.CallNumber = ""
                objBCN.CopyNumber = ""
                objBCN.Volume = ""
                strTitle = ""
                strItemCode = ""
            End If

            ' search for removed
            tblCN = objBCN.GetCopyNumberRemovedIDs(strTitle, strItemCode)
            ' Show error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCN.ErrorMsg, ddlLabel.Items(0).Text, objBCN.ErrorCode)
            If Not tblCN Is Nothing AndAlso tblCN.Rows.Count > 0 Then
                ReDim arrIDs(tblCN.Rows.Count - 1)
                For inti = 0 To tblCN.Rows.Count - 1
                    arrIDs(inti) = tblCN.Rows(inti).Item("ID")
                Next
                Session("IDs") = arrIDs
                Session("LibID") = objBCN.LibID
                Session("LocID") = objBCN.LocID
                Session("Shelf") = objBCN.Shelf
                Page.RegisterClientScriptBlock("RefreshJs", "<script language='javascript'>parent.mainfunc.location.href='WTaskBarFunc.aspx?Mode=2';parent.display.location.href='WProcLostDisplay.aspx';</script>")
            End If
        End Sub

        ' Method: LoadDDL
        Private Sub LoadDDL()
            Dim tblLibrary As DataTable
            Dim tblLocation As DataTable

            ' Load library
            tblLibrary = Me.RetrieveLibrary
            If Not tblLibrary Is Nothing Then
                If tblLibrary.Rows.Count > 0 Then
                    ddlLib.DataSource = Me.RetrieveLibrary
                    ddlLib.DataTextField = "Code"
                    ddlLib.DataValueField = "ID"
                    ddlLib.DataBind()
                End If
            End If

            ' Load location
            If ddlLib.Items.Count > 0 Then
                tblLocation = Me.RetrieveLocation(ddlLib.SelectedValue, 0)
                If Not tblLocation Is Nothing Then
                    If tblLocation.Rows.Count > 0 Then
                        ddlLocation.DataSource = Me.RetrieveLocation(ddlLib.SelectedValue, 0)
                        ddlLocation.DataTextField = "Symbol"
                        ddlLocation.DataValueField = "ID"
                        ddlLocation.DataBind()
                    End If
                End If
            End If
        End Sub

        ' Method: ProcessReq
        Private Sub ProcessReq()
            Dim dtgItem As DataGridItem
            Dim chkSelected As New CheckBox
            Dim strCopyIDs As String = ""
            Dim strCopyNumbers As String = ""
            Dim bytNewLoc As Byte = 0

            If Trim(txtAction.Value & "") = "" Then
                Exit Sub
            End If

            ' Get ID of selected CheckBox
            For Each dtgItem In dtgResult.Items ' Get Selected CopyID
                chkSelected = CType(dtgItem.Cells(0).FindControl("chkCopyID"), CheckBox)
                If chkSelected.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.Cells(0).FindControl("lblCopyID"), Label).Text & ","
                    strCopyNumbers = strCopyNumbers & CType(dtgItem.Cells(0).FindControl("txtdtgCopynumber"), TextBox).Text.Trim & ","
                End If
            Next
            If strCopyIDs <> "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
                strCopyNumbers = Left(strCopyNumbers, Len(strCopyNumbers) - 1)
                If optOld.Checked Then
                    bytNewLoc = 0
                Else
                    bytNewLoc = 1
                    objBCN.LibID = ddlLib.SelectedValue
                    objBCN.LocID = ddlLocation.SelectedValue
                    objBCN.Shelf = Trim(txtShelf.Text & "")
                End If
                objBCN.CopyIDs = strCopyIDs
                Select Case UCase(Trim(txtAction.Value & ""))
                    Case "RESTORE"
                        'Restore
                        objBCN.RestoreCopyNumber(bytNewLoc, 0, strCopyNumbers)
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        If strCopyNumbers = "" Then
                            Page.RegisterClientScriptBlock("RestoreSuccess", "<script>alert('" & ddlLabel.Items(2).Text & "');</script>")
                        Else
                            Page.RegisterClientScriptBlock("RestoreSuccessHasErr", "<script>alert('" & ddlLabel.Items(2).Text & " " & ddlLabel.Items(7).Text & " " & Left(strCopyNumbers, Len(strCopyNumbers) - 1) & " " & ddlLabel.Items(8).Text & "');</script>")
                        End If
                    Case "RESTOREUNLOCK"
                        'Restore&Unlock
                        objBCN.RestoreCopyNumber(bytNewLoc, 1, strCopyNumbers)
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        If strCopyNumbers = "" Then
                            Page.RegisterClientScriptBlock("RestoreUnLockSuccess", "<script>alert('" & ddlLabel.Items(3).Text & "');</script>")
                        Else
                            Page.RegisterClientScriptBlock("RestoreUnLockSuccessHasErr", "<script>alert('" & ddlLabel.Items(3).Text & " " & ddlLabel.Items(7).Text & " " & Left(strCopyNumbers, Len(strCopyNumbers) - 1) & " " & ddlLabel.Items(8).Text & "');</script>")
                        End If
                End Select
                Call LoadDataToDTGrid()
            End If
            txtAction.Value = ""
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBCN object
            objBCN.InterfaceLanguage = Session("InterfaceLanguage")
            objBCN.DBServer = Session("DBServer")
            objBCN.ConnectionString = Session("ConnectionString")
            Call objBCN.Initialize()

            ' Init objBLoc object
            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            Call objBLoc.Initialize()

            ' Init objBLib object
            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            Call objBLib.Initialize()

            Session("IDs") = Nothing
        End Sub

        ' Method: BindScript
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Location/WProcInventory.js'></script>")
            lnkCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', 20,1)"
            lnkUnCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', 20,0)"
        End Sub

        ' Method: BindData
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
            End If

        End Sub

        ' Method: LoadDataToDTGrid
        ' Purpose: Show data in datagrid
        Private Sub LoadDataToDTGrid()
            Dim strTitle As String
            Dim strCopyNumber As String
            Dim strCallNumber As String
            Dim strVolume As String

            Dim tblCN As New DataTable
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
                objBCN.Shelf = ""
            End If

            If Trim(Request.QueryString("search") & "") <> "" Then
                strCallNumber = Trim(Session("CallNumber") & "")
                strCopyNumber = Trim(Session("CopyNumber") & "")
                strVolume = Trim(Session("Volume") & "")
                strTitle = Trim(Session("Title") & "")
            Else
                strCallNumber = ""
                strCopyNumber = ""
                strVolume = ""
                strTitle = ""
            End If

            objBCN.CallNumber = strCallNumber
            objBCN.CopyNumber = strCopyNumber
            objBCN.Volume = strVolume

            ' search for removed
            tblCN = objBCN.GetCopyNumberRemoveds(strTitle)
            dtgResult.Visible = False
            If Not tblCN Is Nothing AndAlso tblCN.Rows.Count > 0 Then
                Dim intCount As Integer
                intCount = Math.Ceiling(tblCN.Rows.Count / dtgResult.PageSize)
                If dtgResult.CurrentPageIndex >= intCount Then
                    dtgResult.CurrentPageIndex = dtgResult.CurrentPageIndex - 1
                End If

                dtgResult.Visible = True
                dtgResult.DataSource = tblCN
                dtgResult.DataBind()
                hidCountID.Value = tblCN.Rows.Count + 2
            End If
        End Sub

        ' RetrieveLibrary method
        ' Purpose: Retrieve libraries
        ' Input: boolean value of IsSelectAll, true if selelect all data of HOLDING_LIBRARY table
        ' Output: datatable of libraries' information
        Private Function RetrieveLibrary() As DataTable
            objBLib.LibID = 0
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

        ' Event: ddlLib_SelectedIndexChanged
        Private Sub ddlLib_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLib.SelectedIndexChanged
            Dim tblTemp As DataTable

            tblTemp = RetrieveLocation(ddlLib.SelectedValue, 0)
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLocation.DataSource = tblTemp
                    ddlLocation.DataTextField = "Symbol"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()
                End If
            End If
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