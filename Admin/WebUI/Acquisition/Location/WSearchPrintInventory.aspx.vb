' Class WExecuteInventory
' Puspose: Excute inventory
' Creator: Tuanhv
' CreatedDate: 09/03/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WSearchPrintInventory
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSortView As System.Web.UI.WebControls.Label
        Protected WithEvents ddlSortView As System.Web.UI.WebControls.DropDownList


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBInventory As New clsBInventory
        Private objBLocation As New clsBLocation
        Private objBCB As New clsBCommonBusiness

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Init all object use form
            Call CheckPemissions()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckPemission method
        Private Sub CheckPemissions()
            ' Check permisssion
            If Not CheckPemission(118) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub
        ' Methord: BindJS
        Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            SetCheckNumber(txtNumrow, ddlLabel.Items(4).Text, "30")
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromDate, txtFromOpenDate, ddlLabel.Items(9).Text)
            SetOnclickCalendar(lnkToDate, txtToOpenDate, ddlLabel.Items(9).Text)
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Init objBCB object
            objBInventory.DBServer = Session("DBServer")
            objBInventory.ConnectionString = Session("ConnectionString")
            objBInventory.InterfaceLanguage = Session("InterfaceLanguage")
            objBInventory.Initialize()

            ' Init objBLocation object
            objBLocation.DBServer = Session("DBServer")
            objBLocation.ConnectionString = Session("ConnectionString")
            objBLocation.InterfaceLanguage = Session("InterfaceLanguage")
            objBLocation.Initialize()

            ' Init objBCB object
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.Initialize()
        End Sub

        ' Methord: BindData
        Private Sub BindData()
            Dim tblResult As DataTable
            ' Get Inventory
            objBInventory.LibID = clsSession.GlbSite
            tblResult = objBInventory.GetInventory(-1)
            ' Bind inventory
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    tblResult = InsertOneRow(tblResult, ddlLabel.Items(7).Text)
                    ddlInventory.DataValueField = "ID"
                    ddlInventory.DataTextField = "Name"
                    ddlInventory.DataSource = tblResult
                    ddlInventory.DataBind()
                End If
            End If
            tblResult = Nothing

            ' Get Liblary
            objBCB.UserID = CInt(Session("UserID"))
            tblResult = objBCB.GetLibraries(clsSession.GlbSite, -1, -1, CInt(Session("UserID")))
            'tblResult = objBCB.GetLibraries(, , -1, )
            'Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCB.ErrorMsg, ddlLabel.Items(0).Text, objBCB.ErrorCode)
            ' Bind liblary
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlLibrary.DataValueField = "ID"
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataSource = tblResult
                    ddlLibrary.DataBind()
                    tblResult = Nothing
                    ' Get Location
                    objBLocation.UserID = Session("UserID")
                    objBLocation.LibID = CInt(ddlLibrary.Items(0).Value)
                    objBLocation.Status = -1
                    tblResult = objBLocation.GetLocation
                    ' Bind location
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            tblResult = InsertOneRow(tblResult, ddlLabel.Items(6).Text)
                            ddlLocation.DataValueField = "ID"
                            ddlLocation.DataTextField = "Symbol"
                            ddlLocation.DataSource = tblResult
                            ddlLocation.DataBind()
                        End If
                    End If
                End If
                tblResult = Nothing
            End If
            txtNumrow.Text = 30
        End Sub

        ' Event ddlLibrary_SelectedIndexChanged
        Private Sub ddlLibrary_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLibrary.SelectedIndexChanged
            Dim tblResult As DataTable
            ' Get Location
            objBLocation.UserID = Session("UserID")
            Try
                objBLocation.LibID = CInt(ddlLibrary.SelectedValue)
            Catch ex As Exception
                objBLocation.LibID = 0
            End Try
            objBLocation.Status = -1
            tblResult = objBLocation.GetLocation
            ' Bind location
            If Not tblResult Is Nothing Then
                tblResult = InsertOneRow(tblResult, ddlLabel.Items(6).Text)
                ddlLocation.DataValueField = "ID"
                ddlLocation.DataTextField = "Symbol"
                ddlLocation.DataSource = tblResult
                ddlLocation.DataBind()
            End If

            'hiddenIspostback.Value = 1
            tblResult = Nothing
        End Sub

        ' Event: btnInventory_Click
        Private Sub btnInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventory.Click
            If CheckPemission(118) Then
                Dim intInventoryID As Integer = 0
                Dim intLibID As Integer = 0
                Dim intLocID As Integer = 0
                Dim strShelf As String = ""
                Dim intType As Integer = 0
                Dim tblResult As New DataTable
                Dim colInfor As New Collection

                dgrLostResult.Visible = False
                dgrFalsePath.Visible = False
                If CInt(ddlInventory.SelectedValue) >= 0 Then
                    If CInt(ddlInventory.SelectedValue) = 0 Then
                        Page.RegisterClientScriptBlock("NthingJS", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                    Else
                        intInventoryID = CInt(ddlInventory.SelectedValue)
                    End If
                End If
                If ddlLibrary.SelectedValue <> "" AndAlso CInt(ddlLibrary.SelectedValue) > 0 Then
                    intLibID = CInt(ddlLibrary.SelectedValue)
                End If
                If ddlLocation.SelectedValue <> "" AndAlso CInt(ddlLocation.SelectedValue) >= 0 Then
                    intLocID = CInt(ddlLocation.SelectedValue)
                End If
                If Trim(txtShelf.Text) <> "" Then
                    strShelf = Trim(txtShelf.Text)
                End If
                If optPurpose.SelectedValue = 1 Then
                    intType = 1
                End If
                ' get information inventory
                Session("InventoryInfor") = CStr(intType) & "," & ddlLibrary.SelectedValue & "," & ddlLocation.SelectedValue & "," & txtShelf.Text & "," & ddlInventory.SelectedValue & "," & txtNumrow.Text
                ' Search IDs in Holding_Inventory
                objBInventory.InventoryID = intInventoryID
                objBInventory.LibID = intLibID
                objBInventory.LocationID = intLocID
                objBInventory.Shelf = strShelf
                objBInventory.OrderField = ddlOrderField.SelectedValue
                objBInventory.Direction = ddlDirection.SelectedValue

                If optPurpose.SelectedValue = 1 Then
                    colInfor.Add(1, "Type")
                Else
                    colInfor.Add(0, "Type")
                End If

                '' hiddenOptInventory(0: Kỳ kiểm kê; 1: Ngày kiểm kê)
                If hiddenOptInventory.Value = "0" Then
                    colInfor.Add(0, "OptInventoryType")
                Else
                    colInfor.Add(1, "OptInventoryType")
                End If
                colInfor.Add(txtFromOpenDate.Text.Trim(), "FromOpenDate")
                colInfor.Add(txtToOpenDate.Text.Trim(), "ToOpenDate")
                colInfor.Add(intInventoryID, "InventoryID")
                colInfor.Add(intLibID, "LibID")
                colInfor.Add(intLocID, "LocID")
                colInfor.Add(strShelf, "Shelf")
                colInfor.Add(ddlOrderField.SelectedValue, "OrderField")
                colInfor.Add(ddlDirection.SelectedValue, "Direction")
                colInfor.Add(ddlLibrary.SelectedItem.Text, "LibName")
                Session("ColInfor") = colInfor
                Response.Redirect("WPrintLocationInventory.aspx")
                'If intType = 0 Then ' Lost
                '    tblResult = objBInventory.GetItemNoHaveReal
                '    'Check error
                '    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBInventory.ErrorMsg, ddlLabel.Items(0).Text, objBInventory.ErrorCode)
                '    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                '        dgrLostResult.Visible = True
                '        dgrLostResult.DataSource = tblResult
                '        dgrLostResult.DataBind()
                '    End If
                'Else ' Wrong path
                '    tblResult = objBInventory.GetItemFalsePaths
                '    'Check error
                '    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBInventory.ErrorMsg, ddlLabel.Items(0).Text, objBInventory.ErrorCode)
                '    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                '        dgrFalsePath.Visible = True
                '        dgrFalsePath.DataSource = tblResult
                '        dgrFalsePath.DataBind()
                '    End If
                'End If
            Else
                Page.RegisterClientScriptBlock("MsgError", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
            End If
        End Sub

        Private Sub VisableObjects()

        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
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
                If Not objBCB Is Nothing Then
                    objBCB.Dispose(True)
                    objBCB = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
