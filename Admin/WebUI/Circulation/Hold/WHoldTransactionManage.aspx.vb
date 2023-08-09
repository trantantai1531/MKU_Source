Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WHoldTransactionManage
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
        Private objBHoldTrans As New clsBHoldTransaction
        Private objBReserve As New clsBReserve

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            'OutTurn()
            'ChangeTurn()
        End Sub

        ' Initialize method
        ' Purpose: Initialize all objects
        Private Sub Initialize()
            ' Init objBHoldTrans object
            objBHoldTrans.ConnectionString = Session("ConnectionString")
            objBHoldTrans.DBServer = Session("DBServer")
            objBHoldTrans.InterfaceLanguage = Session("InterfaceLanguage")
            objBHoldTrans.UserID = Session("UserID")
            Call objBHoldTrans.Initialize()

            ' Init objBReserve object
            objBReserve.ConnectionString = Session("ConnectionString")
            objBReserve.DBServer = Session("DBServer")
            objBReserve.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBReserve.Initialize()
        End Sub

        ' CheckForm permission method
        ' Purpose: check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(64) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' ChangeTurn method
        Private Sub ChangeTurn()
            If hidChangeTurn.Value <> 0 Then
                objBHoldTrans.ReservationID = hidChangeTurn.Value
                objBHoldTrans.ChangeHoldingTurn()
                ' Write log
                WriteLog(109, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                hidChangeTurn.Value = 0
                Call BindData()
            End If
        End Sub

        ' OutTurn method
        Private Sub OutTurn()
            If hidOutTurn.Value <> 0 Then
                objBHoldTrans.ReservationID = hidOutTurn.Value
                objBHoldTrans.CutHoldingTurn()
                ' Write log
                WriteLog(109, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                hidOutTurn.Value = 0
                Call BindData()
            End If
        End Sub

        ' BindScript method
        ' Purpose: BindJAVASCRIPT
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = '../js/Hold/WHoldTransactionManage.js'></script>")

            rdoResrv.Attributes.Add("OnClick", "javascript:rdoReservEvent();")
            rdoOutTurn.Attributes.Add("OnClick", "javascript:rdoOutTurnEvent();")
            rdoTitle.Attributes.Add("OnClick", "javascript:rdoTitleEvent();")
            rdoPatron.Attributes.Add("OnClick", "javascript:rdoPatronEvent();")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDateFrom, txtFrom, ddlLabel.Items(5).Text)
            SetOnclickCalendar(lnkDateTo, txtTo, ddlLabel.Items(5).Text)
        End Sub

        ' BindData method
        ' Bind Data by some fields
        Private Sub BindData()
            ' Declare variable
            'Dim tblReservation As Object
            'Dim dtgItem As DataGridItem
            ''Dim strInTurn As String
            ''Dim lblStatus As Label
            'Dim lblID As Label
            'Dim btnOutTurn As ImageButton
            'Dim btnChangeTurn As ImageButton
            Dim intReserv As Integer = 0
            Dim intSearch As Integer = 0
            Dim tblReserve As DataTable

            Select Case hidReserv.Value
                Case 0
                    'objBHoldTrans.CreatedDateFrom = Trim(txtFrom.Text)
                    'objBHoldTrans.CreatedDateTo = Trim(txtTo.Text)

                    intReserv = 0
                Case 1
                    'objBHoldTrans.TimeOutDateFrom = Trim(txtFrom.Text)
                    'objBHoldTrans.TimeOutDateTo = Trim(txtTo.Text)

                    intReserv = 1
            End Select

            Select Case hidTitlePatron.Value
                Case 0
                    'objBHoldTrans.Title = Trim(txtTitlePatron.Text)
                    intSearch = 0
                Case 1
                    'objBHoldTrans.PatronCode = Trim(txtTitlePatron.Text)
                    intSearch = 1
            End Select

            'If CStr(hidColSort.Value) <> "" Then
            '    objBHoldTrans.Sort = CStr(hidColSort.Value)
            'End If

            'If rdoOutTurn.Checked = True Then
            '    intReserv = 1
            'End If

            'objBHoldTrans.LibID = clsSession.GlbSite
            'tblReservation = objBHoldTrans.GetHoldTransactions(intReserv)
            'If Not tblReservation Is Nothing Then
            '    dtgResult.DataSource = tblReservation
            '    dtgResult.DataBind()

            '    For Each dtgItem In dtgResult.Items
            '        'strInTurn = Trim(CStr(CType(dtgItem.FindControl("lblStatus"), Label).Text))
            '        'lblStatus = dtgItem.FindControl("lblStatusDisplay")
            '        lblID = dtgItem.FindControl("lblID")
            '        'btnOutTurn = dtgItem.FindControl("btnOutTurn")
            '        'btnChangeTurn = dtgItem.FindControl("btnChangeTurn")
            '        'If strInTurn = "True" Then
            '        '    lblStatus.Text = ddlLabel.Items(3).Text
            '        '    btnOutTurn.Visible = True
            '        '    btnChangeTurn.Visible = True
            '        '    btnChangeTurn.Attributes.Add("OnClick", "javascript:ChangeTurn('" & Trim(lblID.Text) & "');")
            '        '    btnOutTurn.Attributes.Add("OnClick", "javascript:OutTurn('" & Trim(lblID.Text) & "');")
            '        'Else
            '        '    lblStatus.Text = ddlLabel.Items(4).Text
            '        '    btnOutTurn.Visible = False
            '        '    btnChangeTurn.Visible = False
            '        'End If
            '    Next
            'End If

            tblReserve = objBReserve.FillReserve(intReserv, intSearch, txtTitlePatron.Text, Trim(txtFrom.Text), Trim(txtTo.Text))
            If Not tblReserve Is Nothing Then
                If tblReserve.Rows.Count > 0 Then

                    Dim newColumn As New Data.DataColumn("STT", GetType(System.String))
                    newColumn.DefaultValue = "1"
                    tblReserve.Columns.Add(newColumn)
                    Dim indexRows As Integer = 1
                    For Each rows As DataRow In tblReserve.Rows
                        If (Not (rows.RowState = DataRowState.Deleted)) AndAlso (Not (String.IsNullOrEmpty(rows.Item("STT")))) Then
                            rows.Item("STT") = indexRows.ToString()
                            indexRows = indexRows + 1
                        End If
                    Next

                    dtgResult.DataSource = tblReserve
                    dtgResult.DataBind()
                Else
                    dtgResult.DataSource = tblReserve
                    dtgResult.DataBind()
                End If
            End If
        End Sub

        ' btnFilter_Click event
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            dtgResult.CurrentPageIndex = 0
            Call BindData()
        End Sub

        ' dtgResult_ItemCreated event
        ' Purpose: Add the javascript for each table row
        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemCreated
            'Dim strJS As String
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    Dim lnk As HyperLink
                    Dim lnkdtgTemp As LinkButton

                    tblCell = e.Item.Cells(1)
                    lnk = CType(tblCell.FindControl("lnkPatronCode"), HyperLink)
                    lnk.CssClass = "lbLinkFunction"

                    ' Add the attribute for the hiperlink to modify an item
                    lnk.NavigateUrl = "#"
                    lnk.Attributes.Add("onclick", "javascript:OpenWindow('../WPatronDetail.aspx?PatronCode=" & DataBinder.Eval(e.Item.DataItem, "PatronCode") & "','PatronDetails',600,450,110,50);return false;")

                    lnkdtgTemp = e.Item.FindControl("lnkdtgDelete")

                    lnkdtgTemp.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(6).Text & "')==false) {return false}")
            End Select
        End Sub

        ' dtgResult_SortCommand event
        Private Sub dtgResult_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dtgResult.SortCommand
            hidColSort.Value = e.SortExpression
            Call BindData()
        End Sub

        ' Delete event of DataGrid
        Private Sub dtgResult_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgResult.DeleteCommand
            ' Declare variables
            Dim intIndex As Integer
            Dim intID As Integer

            ' Get data to Delete
            intIndex = e.Item.ItemIndex

            intID = Trim(CInt(CType(dtgResult.Items(intIndex).Cells(0).FindControl("lblID"), Label).Text))
            'objBHoldTrans.ReservationID = intID
            'objBHoldTrans.RemoveHoldTransactions()
            objBReserve.ID = intID
            objBReserve.DeleteReserve()
            ' Write log
            WriteLog(109, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            Call BindData()
        End Sub

        ' dtgResult_SelectedIndexChanged event (Change to new page)
        Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            dtgResult.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Dispose method
        ' Purpose: Realease the objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBHoldTrans Is Nothing Then
                    objBHoldTrans.Dispose(True)
                    objBHoldTrans = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace