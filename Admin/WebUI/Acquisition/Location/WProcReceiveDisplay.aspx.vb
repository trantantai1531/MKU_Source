Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WProcReceiveDisplay
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
                Call LoadDDL()
                If Request.QueryString("Action") & "" = "" Then
                    Call LoadDataToDTGrid()
                Else
                    txtAction.Value = Request.QueryString("Action")
                End If
            End If
            If Request.QueryString("CurPage") & "" = "" Then
                Call BindData()
            Else
                Call LoadDataToDTGrid()
            End If
            Call BindScript() ' Must put here
            Call ProcessReq()
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
        End Sub

        ' BindScript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Location/WProcInventory.js'></script>")
            lnkCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', " & hidCountID.Value & ",1)"
            lnkUnCheckAll.NavigateUrl = "javascript:CheckedAllOpt('dtgResult', 'chkCopyID', " & hidCountID.Value & ",0)"
        End Sub

        ' Method: LoadDDL
        Private Sub LoadDDL()
            Dim tblTemp As DataTable
            Dim inti As Integer
            ' Get libraries
            tblTemp = RetrieveLibrary()
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLib.DataSource = tblTemp
                    ddlLib.DataTextField = "Code"
                    ddlLib.DataValueField = "ID"
                    ddlLib.DataBind()
                    If Not Session("LibID") Is Nothing Then
                        For inti = 0 To ddlLib.Items.Count - 1
                            If ddlLib.Items(inti).Value = CInt(Session("LibID")) Then
                                ddlLib.Items(inti).Selected = True
                                Exit For
                            End If
                        Next
                    End If
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
                    If Not Session("LocID") Is Nothing Then
                        For inti = 0 To ddlLocation.Items.Count - 1
                            If ddlLocation.Items(inti).Value = CInt(Session("LocID")) Then
                                ddlLocation.Items(inti).Selected = True
                                Exit For
                            End If
                        Next
                    End If
                End If
                tblTemp.Clear()
            End If
            If Not Session("Shelf") Is Nothing AndAlso Session("Shelf") & "" = "noname" Then
                txtShelf.Text = CStr(Session("Shelf"))
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
            objBLib.LibID = clsSession.GlbSite
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
        Private Sub BindData()
            Dim tblGeneral As New DataTable
            Dim tblCN As New DataTable
            If Session("LibID") = "0" Then
                Exit Sub
            End If
            objBLoc.LibID = Session("LibID")
            objBLoc.LocID = Session("LocID")
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
            End If
        End Sub

        ' Method: LoadDataToDTGrid
        ' Purpose: show data in datagrid
        Private Sub LoadDataToDTGrid()
            Dim tblCN As New DataTable
            Dim strIDs As String
            Dim arrIDs() As String
            Dim inti, intStartID, intStopID, intCurPage As Integer
            If Not Session("IDs") Is Nothing Then
                arrIDs = Session("IDs")
                ' Get strIDs, default 200 records on a segment
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

                objBCN.LocID = 0
                objBCN.LocID = 0
                objBCN.Shelf = ""
                objBCN.CallNumber = ""
                objBCN.CopyNumber = ""
                objBCN.Volume = ""
                ' get data for display
                tblCN = objBCN.SearchCopyNumber(3, "", strIDs)
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
                Else
                    If txtAction.Value & "" = "" Then
                        Page.RegisterClientScriptBlock("DataNotFoundJs", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                    End If
                End If
                tblCN = Nothing
            End If
        End Sub

        ' Method: ProcessReq
        Private Sub ProcessReq()
            Dim dtgItem As DataGridItem
            Dim chkSelected As New CheckBox
            Dim strCopyIDs As String = ""
            Dim bytNewLoc As Byte = 0

            If Trim(txtAction.Value & "") = "" Then
                Exit Sub
            End If
            strCopyIDs = hidTotalCopyIDs.Value
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
                Select Case UCase(Trim(txtAction.Value & ""))
                    Case "RECEIVE"
                        'Receive
                        objBCN.ProcessCopyNumber(2, bytNewLoc)
                        Page.RegisterClientScriptBlock("ReceivedSuccess", "<script>alert('" & ddlLabel.Items(2).Text & "');</script>")
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                    Case "RECEIVEUNLOCK"
                        'Receive&Unlock
                        objBCN.ProcessCopyNumber(3, bytNewLoc)
                        Page.RegisterClientScriptBlock("ReceivedUnLockSuccess", "<script>alert('" & ddlLabel.Items(3).Text & "');</script>")
                        ' Write Log
                        Call WriteLog(41, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Select
                Page.RegisterClientScriptBlock("RefreshTreeview", "<script language='javascript'>parent.location.href = 'WReceiveFrame.aspx';</script>")
                Call LoadDataToDTGrid()
            End If
            txtAction.Value = ""
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

        Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            dtgResult.CurrentPageIndex = e.NewPageIndex
            Call LoadDataToDTGrid()
        End Sub

        Private Sub ddlLib_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLib.SelectedIndexChanged
            ' Get locations
            Dim tblTemp As DataTable
            Dim inti As Integer
            tblTemp = RetrieveLocation(ddlLib.SelectedValue, 0)
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlLocation.DataSource = tblTemp
                ddlLocation.DataTextField = "Symbol"
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataBind()
                If Not Session("LocID") Is Nothing Then
                    For inti = 0 To ddlLocation.Items.Count - 1
                        If ddlLocation.Items(inti).Value = CInt(Session("LocID")) Then
                            ddlLocation.Items(inti).Selected = True
                            Exit For
                        End If
                    Next
                End If
                tblTemp.Clear()
            Else
                ddlLocation.Items.Clear()
            End If
        End Sub
    End Class
End Namespace