' Class: WOpenLoc
' Puspose: open locations
' Creator: lent
' CreatedDate: 18-2-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WOpenLoc
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
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call LoadLibraries()
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(119) Then
                btnOpenLoc.Enabled = False
            End If
        End Sub

        ' Initialize method
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

        ' Method: LoadLibraries
        ' Purpose: load list of libraries
        Private Sub LoadLibraries()
            Dim tblResult As DataTable
            objBLibrary.UserID = Session("UserID")
            objBLibrary.LibID = clsSession.GlbSite
            tblResult = objBLibrary.GetLibrary(0)
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                ddlLibrary.DataSource = InsertOneRow(tblResult, ddlLabelNote.Items(0).Text)
                ddlLibrary.DataTextField = "FullName"
                ddlLibrary.DataValueField = "ID"
                ddlLibrary.DataBind()
                ddlLibrary.SelectedIndex = 0
                'Else
                '    Page.RegisterClientScriptBlock("JSNoLib", "<script language='javascript'>alert('" & ddlLabelNote.Items(8).Text & "');</script>")
            End If
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Dim strJSConfirm As String
            Dim strJSCheck As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WLocMan.js'></script>")

            strJSCheck = "if(!CheckOptionsNull('dtgLocation', 'cbkdtgLocation', 3, 20, '" & ddlLabelNote.Items(1).Text & "')) return false;"
            strJSCheck = "if(!CheckOptionsNullByCssClass('ckb-value', 'chkID', 2, 50, '" & ddlLabelNote.Items(1).Text & "')) return false;"
            strJSConfirm = "return ConfirmCloseOpen('" & ddlLabelNote.Items(2).Text & "');"
            btnOpenLoc.Attributes.Add("onClick", strJSCheck & " else " & strJSConfirm)
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblResult As DataTable
            Dim intItem As Integer
            Dim intCount As Integer
            Dim blnNoInfo As Boolean = True

            'bind data for datagrid
            tblResult = Nothing
            If ddlLibrary.Items.Count > 0 Then
                objBLocation.LibID = ddlLibrary.SelectedValue
                objBLocation.UserID = Session("UserID")
                objBLocation.LocID = 0
                objBLocation.Status = 0
                tblResult = objBLocation.GetLocation
                If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                    intCount = CInt(tblResult.Rows.Count / dtgLocation.PageSize)
                    intItem = intCount * dtgLocation.PageSize
                    If intItem = tblResult.Rows.Count Then
                        If dtgLocation.CurrentPageIndex > intCount - 1 Then
                            dtgLocation.CurrentPageIndex = dtgLocation.CurrentPageIndex - 1
                        End If
                    End If
                    blnNoInfo = False
                End If

                If Not blnNoInfo Then
                    dtgLocation.DataSource = tblResult
                    dtgLocation.DataBind()
                    dtgLocation.Visible = True
                    btnOpenLoc.Visible = True
                Else
                    '  Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabelNote.Items(8).Text & "');</script>")
                    '  ddlLibrary.Visible = False
                    dtgLocation.Visible = False
                    btnOpenLoc.Visible = False
                End If
            End If
        End Sub

        ' btnOpenLoc_Click event
        Private Sub btnOpenLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenLoc.Click
            Dim dtgItem As GridDataItem
            Dim chkCheckBox As HtmlInputCheckBox
            Dim strIDs As String = ""
            Dim strNameLoc As String = ""

            For Each dtgItem In dtgLocation.Items
                chkCheckBox = dtgItem.FindControl("cbkdtgLocation")
                If chkCheckBox.Checked Then
                    strIDs = strIDs & dtgItem.Cells(2).Text & ","
                    strNameLoc = strNameLoc & dtgItem.Cells(1).Text & ","
                End If
            Next

            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                strNameLoc = Left(strNameLoc, Len(strNameLoc) - 1)
                objBLocation.LocIDs = strIDs
                objBLocation.Shelf = ""
                objBLocation.Status = 1
                Call objBLocation.UpdateStatusLocation()
                ' Write log
                Call WriteLog(91, ddlLabelNote.Items(6).Text & " " & ddlLibrary.SelectedItem.Text & " -- " & strNameLoc, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabelNote.Items(3).Text & "');</script>")

                ' Reload form
                Call BindData()
            End If
        End Sub


        ' dtgLocation_PageIndexChanged event
        Protected Sub dtgLocation_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgLocation.NeedDataSource
            BindData()

        End Sub

        ' ddlLibrary_SelectedIndexChanged event
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            dtgLocation.CurrentPageIndex = 0
            Call BindData()
            dtgLocation.Rebind()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
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