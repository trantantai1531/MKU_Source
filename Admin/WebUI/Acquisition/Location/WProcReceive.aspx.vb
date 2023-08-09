' Class: WProcReceive
' Purpose: process revceiving copynumbers on holding location
' Creator: Sondp
' CreatedDate: 28/11/2005

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WProcReceive
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
            Call SearchIDs() ' For Session("IDs")
            'If Not Page.IsPostBack Then
            '    Call LoadDDL()
            '    Call BindInfor()
            '    Call BindData0()
            'End If
            'hidIndexChanged.Value = "0" ' so funny but must have
            'If Request.QueryString("Direction") <> "" AndAlso hidIndexChanged.Value = "0" Then
            '    Call BindData0()
            'End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(132) Then
                Call WriteErrorMssg(ddlLabel.Items(4).Text)
            End If
        End Sub

        '' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init for objBCN
            objBCN.InterfaceLanguage = Session("InterfaceLanguage")
            objBCN.DBServer = Session("DBServer")
            objBCN.ConnectionString = Session("ConnectionString")
            Call objBCN.Initialize()

            objBLoc.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoc.DBServer = Session("DBServer")
            objBLoc.ConnectionString = Session("ConnectionString")
            Call objBLoc.Initialize()

            objBLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBLib.DBServer = Session("DBServer")
            objBLib.ConnectionString = Session("ConnectionString")
            Call objBLib.Initialize()
            Session("IDs") = Nothing
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Location/WProcInventory.js'></script>")
            lnkCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', 20,1)"
            lnkUnCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', 20,0)"
            'hrfPrevious.NavigateUrl = "javascript:Previous(0," & Request.QueryString("LibID") & "," & Request.QueryString("LocID") & ",'" & Request.QueryString("Shelf") & "');"
            'hrfNext.NavigateUrl = "javascript:Next(1," & Request.QueryString("LibID") & "," & Request.QueryString("LocID") & ",'" & Request.QueryString("Shelf") & "');"
            'btnReceived.Attributes.Add("OnClick", "return(Received());")
            'btnReceivedAndUnlock.Attributes.Add("OnClick", "return(ReceivedAndUnlock());")
        End Sub


        Private Sub SearchIDs()
            Dim strShelf, strCallNumber, strCopyNumber, strTitle, strVolume, strItemCode, arrIDs(0), strScript As String
            Dim intNextID, intLibID, intLocID, intSaveID, inti As Integer
            Dim tblData As New DataTable

            arrIDs(0) = -1
            If Request.QueryString("LibID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LibID")) Then
                    intLibID = CInt(Request.QueryString("LibID"))
                Else
                    intLibID = 0
                End If
            Else
                intLibID = 0
            End If
            If Request.QueryString("LocID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LocID")) Then
                    intLocID = CInt(Request.QueryString("LocID"))
                Else
                    intLocID = 0
                End If
            Else
                intLocID = 0
            End If
            If Request.QueryString("shelf") & "" <> "" Then
                strShelf = Trim(Request.QueryString("shelf") & "")
            Else
                strShelf = ""
            End If
            If Trim(Request.QueryString("search") & "") <> "" Then
                strCallNumber = Trim(Session("CallNumber") & "")
                strCopyNumber = Trim(Session("CopyNumber") & "")
                strVolume = Trim(Session("Volume") & "")
                strTitle = Trim(Session("Title") & "")
                strItemCode = Trim(Session("ItemCode") & "")
            Else
                strCallNumber = ""
                strCopyNumber = ""
                strVolume = ""
                strTitle = ""
                strItemCode = ""
            End If

            objBCN.LibID = intLibID
            objBCN.LocID = intLocID
            objBCN.Shelf = strShelf
            objBCN.Volume = strVolume
            objBCN.CallNumber = strCallNumber
            objBCN.CopyNumber = strCopyNumber
            tblData = objBCN.SearchCopyNumber(3, strTitle, "", False, strItemCode)
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ReDim arrIDs(tblData.Rows.Count - 1)
                For inti = 0 To tblData.Rows.Count - 1
                    arrIDs(inti) = tblData.Rows(inti).Item("ID")
                Next
            End If
            If arrIDs(0) > 0 Then
                Session("IDs") = arrIDs
                Session("LibID") = objBCN.LibID
                Session("LocID") = objBCN.LocID
                Session("Shelf") = objBCN.Shelf
                strScript = "parent.display.location.href='WProcReceiveDisplay.aspx';"
                strScript &= "parent.mainfunc.location.href='WTaskBarFunc.aspx?Mode=0';"
            End If
            Page.RegisterClientScriptBlock("ChangePageJs", "<script language='javascript'>" & strScript & "</script>")
        End Sub


        ' Method: LoadDDL
        Private Sub LoadDDL()
            Dim tblTemp As DataTable

            ' Get libraries
            tblTemp = RetrieveLibrary()
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLib.DataSource = tblTemp
                    ddlLib.DataTextField = "Code"
                    ddlLib.DataValueField = "ID"
                    ddlLib.DataBind()
                End If
                tblTemp.Clear()
            End If

            ' Get locations
            tblTemp = RetrieveLocation(ddlLib.SelectedValue, 0)
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLocation.DataSource = tblTemp
                    ddlLocation.DataTextField = "Symbol"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()
                End If
                tblTemp.Clear()
            End If

            If Not tblTemp Is Nothing Then
                tblTemp = Nothing
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

        ' Method: BindData
        Private Sub BindInfor()
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

                If objBLoc.Shelf = "" Then
                    lblShelf.Text = ""
                Else
                    lblShelf.Text = objBLoc.Shelf
                End If
            End If
        End Sub

        ' Purpose: Search data for each datagrid segment
        ' Input: LibID, LocID, Shelf...
        ' Output: Datatable have 200 rows (default each segment have 200 rows)
        ' Creator: Sondp
        Function SearchReceiveSegment(ByVal intLibID As Integer, ByVal intLocID As Integer, ByVal strShelf As String, ByVal strCallNumber As String, ByVal strVolume As String, ByVal strCopyNumber As String, ByVal strTitle As String, ByVal bytMode As Byte, ByVal intNextID As Integer, ByRef intSaveID As Integer, ByVal isUpdate As Boolean) As DataTable

            Dim tblHoldingInfor As New DataTable
            SearchReceiveSegment = Nothing
            objBCN.LibID = intLibID
            objBCN.LocID = intLocID
            objBCN.Shelf = strShelf
            objBCN.CallNumber = strCallNumber
            objBCN.CopyNumber = strCopyNumber
            objBCN.Volume = strVolume

            ' Search data (not acquired) depend on input cordition
            tblHoldingInfor = objBCN.SearchReceiveSegment(3, strTitle, intNextID, intSaveID, isUpdate)
            If Not tblHoldingInfor Is Nothing Then
                If tblHoldingInfor.Rows.Count > 0 Then
                    SearchReceiveSegment = tblHoldingInfor
                End If
            End If
        End Function

        ' Purpose: BindData to datagrid for changed segment 
        ' In: some infor
        Private Sub BindData0()
            Dim strShelf, strCallNumber, strCopyNumber, strTitle, strVolume As String
            Dim intNextID, intLibID, intLocID, intSaveID As Integer
            Dim tblData As New DataTable

            If Request.QueryString("LibID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LibID")) Then
                    intLibID = CInt(Request.QueryString("LibID"))
                Else
                    intLibID = 0
                End If
            Else
                intLibID = 0
            End If
            If Request.QueryString("LocID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LocID")) Then
                    intLocID = CInt(Request.QueryString("LocID"))
                Else
                    intLocID = 0
                End If
            Else
                intLocID = 0
            End If
            If Request.QueryString("shelf") & "" <> "" Then
                strShelf = Trim(Request.QueryString("shelf") & "")
            Else
                strShelf = ""
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

            If Request.QueryString("Direction") & "" <> "" AndAlso Request.QueryString("Direction") = "1" Then
                intNextID = hidNextID.Value
            Else
                intNextID = hidPreviousID.Value
            End If
            tblData = SearchReceiveSegment(intLibID, intLocID, strShelf, strCallNumber, strVolume, strCopyNumber, strTitle, 3, intNextID, intSaveID, True)
            hidPreviousID.Value = intSaveID ' save startID on previous segment
            dtgResult.Visible = False
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                If Request.QueryString("Direction") & "" = "" Then
                    If Not Page.IsPostBack Then ' The first time display(received from tree view)
                        hidNextID.Value = tblData.Rows(tblData.Rows.Count - 1).Item("ID")
                    End If
                Else
                    ' process for next page click
                    If Request.QueryString("Direction") = "1" Then
                        hidNextID.Value = tblData.Rows(tblData.Rows.Count - 1).Item("ID")
                    End If
                End If
                dtgResult.Visible = True
                dtgResult.DataSource = tblData
                dtgResult.DataBind()
                hidCountID.Value = tblData.Rows.Count + 2
            End If
        End Sub

        ' Purpose: BindData to datagrid for datagrid index changed, or else action
        ' In: some infor
        Private Sub BindData1()
            Dim strShelf, strCallNumber, strCopyNumber, strTitle, strVolume As String
            Dim intNextID, intLibID, intLocID, intSaveID As Integer
            Dim tblData As New DataTable

            If Request.QueryString("LibID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LibID")) Then
                    intLibID = CInt(Request.QueryString("LibID"))
                Else
                    intLibID = 0
                End If
            Else
                intLibID = 0
            End If
            If Request.QueryString("LocID") & "" <> "" Then
                If IsNumeric(Request.QueryString("LocID")) Then
                    intLocID = CInt(Request.QueryString("LocID"))
                Else
                    intLocID = 0
                End If
            Else
                intLocID = 0
            End If
            If Request.QueryString("shelf") & "" <> "" Then
                strShelf = Trim(Request.QueryString("shelf") & "")
            Else
                strShelf = ""
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

            intNextID = hidPreviousID.Value
            tblData = SearchReceiveSegment(intLibID, intLocID, strShelf, strCallNumber, strVolume, strCopyNumber, strTitle, 3, intNextID, intSaveID, False)
            dtgResult.Visible = False
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                Dim intCount As Integer
                intCount = Math.Ceiling(tblData.Rows.Count / dtgResult.PageSize)
                If dtgResult.CurrentPageIndex >= intCount Then
                    dtgResult.CurrentPageIndex = dtgResult.CurrentPageIndex - 1
                End If
                dtgResult.Visible = True
                dtgResult.DataSource = tblData
                dtgResult.DataBind()
                hidCountID.Value = tblData.Rows.Count + 2
            End If
        End Sub

        ' Method: ProcessReq
        Private Sub ProcessReq()
            Dim dtgItem As DataGridItem
            Dim chkSelected As New CheckBox
            Dim strCopyIDs As String = ""
            Dim bytNewLoc As Byte = 0

            If txtAction.Value = "" Then
                Exit Sub
            End If
            ' Get ID of selected CheckBox
            For Each dtgItem In dtgResult.Items ' Get Selected CopyID
                chkSelected = CType(dtgItem.Cells(0).FindControl("chkCopyID"), CheckBox)
                If chkSelected.Checked Then
                    strCopyIDs = strCopyIDs & CType(dtgItem.Cells(0).FindControl("lblCopyID"), Label).Text & ","
                End If
            Next
            If strCopyIDs <> "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
                If optOld.Checked Then
                    bytNewLoc = 0
                Else
                    bytNewLoc = 1
                    objBCN.LibID = ddlLib.SelectedValue
                    objBCN.LocID = ddlLocation.SelectedValue
                    objBCN.Shelf = Trim(txtShelf.Text & "")
                End If
                objBCN.CopyIDs = strCopyIDs
                Select Case UCase(txtAction.Value)
                    Case "0"
                        'Receive
                        objBCN.ProcessCopyNumber(2, bytNewLoc)
                        Page.RegisterClientScriptBlock("ReceivedSuccess", "<script>alert('" & ddlLabel.Items(2).Text & "');</script>")
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Case "1"
                        'Receive&Unlock
                        objBCN.ProcessCopyNumber(3, bytNewLoc)
                        Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(3).Text & "');</script>")
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Select
                Call BindData1()
            End If
        End Sub

        ' Event: dtgResult_PageIndexChanged
        Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            Dim strScript As String
            dtgResult.CurrentPageIndex = e.NewPageIndex
            hidIndexChanged.Value = 1
            Call BindData1()
        End Sub

        ' Event: ddlLib_SelectedIndexChanged
        Private Sub ddlLib_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLib.SelectedIndexChanged
            Dim tblTemp As DataTable
            ' Get locations
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

        Private Sub btnReceived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Call ProcessReq()
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