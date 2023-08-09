Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WChangeLoanType
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents chkAll As System.Web.UI.WebControls.CheckBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBIC As New clsBItemCollection
        Private objBLoanType As New clsBLoanType

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strQuery As String
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            Call ShowControls(False)
            If Not Page.IsPostBack Then
                Call BindData()
                If Request.QueryString("intLoanTypeID") <> "" Then
                    strQuery = Request.QueryString("intLoanTypeID")
                    Dim intCount As Integer
                    For intCount = 0 To ddlLoanType.Items.Count - 1
                        If ddlLoanType.Items(intCount).Value = strQuery Then
                            ddlLoanType.Items(intCount).Selected = True
                        Else
                            ddlLoanType.Items(intCount).Selected = False
                        End If
                    Next
                    Call ShowResultSearch(, strQuery)
                End If
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(70) Then
                btnMerge.Enabled = False
                btnSearch.Enabled = False
            End If
        End Sub

        ' Method: Initialze
        ' Purpose: init need object
        Private Sub Initialze()
            ' Init objBIC object
            objBIC.InterfaceLanguage = Session("InterfaceLanguage")
            objBIC.DBServer = Session("DBServer")
            objBIC.ConnectionString = Session("ConnectionString")
            Call objBIC.Initialize()

            ' Init objBLoanType object
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblLoanType As New DataTable

            objBLoanType.LoanTypeID = 0
            objBLoanType.LibID = clsSession.GlbSite
            tblLoanType = objBLoanType.GetLoanTypes()
            If Not tblLoanType Is Nothing AndAlso tblLoanType.Rows.Count > 0 Then
                ddlLoanType.DataSource = InsertOneRow(tblLoanType, ddlLabel.Items(3).Text)
                ddlLoanType.DataTextField = "LoanType"
                ddlLoanType.DataValueField = "ID"
                ddlLoanType.DataBind()

                ddlNewLoanType.DataSource = tblLoanType
                ddlNewLoanType.DataTextField = "LoanType"
                ddlNewLoanType.DataValueField = "ID"
                ddlNewLoanType.DataBind()
                tblLoanType = Nothing
            End If
        End Sub

        ' Method: ShowResultSearch
        ' Purpose: Show search result
        Private Sub ShowResultSearch(Optional ByVal intPage As Integer = 0, Optional ByVal strQuery As String = "")
            Dim tblHolding As New DataTable
            Dim blnFound As Boolean = False
            Dim intLoan As Integer

            If strQuery <> "" Then
                intLoan = strQuery
            Else
                If ddlLoanType.SelectedIndex > 0 Then
                    intLoan = ddlLoanType.SelectedValue
                Else
                    intLoan = 0
                End If
            End If
            objBIC.UserID = Session("UserID")
            tblHolding = objBIC.SearchHolding(intLoan, txtAuthor.Text.Trim, txtPublishYear.Text.Trim, txtPublisher.Text.Trim, txtISBN.Text.Trim, txtCopyNumber.Text.Trim, txtTitle.Text.Trim)
            If Not tblHolding Is Nothing AndAlso tblHolding.Rows.Count > 0 Then
                dtgHolding.DataSource = tblHolding
                dtgHolding.CurrentPageIndex = intPage
                dtgHolding.DataBind()
                blnFound = True
                tblHolding = Nothing
            End If
            Call ShowControls(blnFound)
            If Not blnFound Then
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            End If
        End Sub

        ' Method: ShowControls
        ' Purpose: Show/Hide form's controls
        Private Sub ShowControls(ByVal blnVisible As Boolean)
            dtgHolding.Visible = blnVisible
            ddlNewLoanType.Visible = blnVisible
            btnMerge.Visible = blnVisible
            lblMerge.Visible = blnVisible
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("JSPolicy", "<script language = 'javascript' src = '../js/Policy/WPolicyManagement.js'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WChangeLoanType.js'></script>")

            btnMerge.Attributes.Add("OnClick", "if(!CheckOptionsNull('dtgHolding', 'chkHoldingID', 3, 10, '" & ddlLabel.Items(6).Text & "')) {return false} else {if (document.forms[0].ddlNewLoanType.options[document.forms[0].ddlNewLoanType.options.selectedIndex].value == 0) {alert('" & ddlLabel.Items(5).Text & "'); return false;}}")
            btnSearch.Attributes.Add("OnClick", "return CheckAllValues('" & ddlLabel.Items(7).Text.Trim & "')")
            btnReset.Attributes.Add("OnClick", "ClearAllValues(); return false;")
        End Sub

        ' Event: btnSearch_Click
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Call ShowResultSearch()
        End Sub

        ' Event: dtgHolding_PageIndexChanged
        Private Sub dtgHolding_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgHolding.PageIndexChanged
            Try
                Call ShowResultSearch(e.NewPageIndex)
            Catch ex As Exception
            End Try
        End Sub

        ' Event: btnMerge_Click
        Private Sub btnMerge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerge.Click
            Dim strCopyNumberIDs As String = ""
            Dim intCount As Integer

            For intCount = 0 To dtgHolding.Items.Count - 1
                If CType(dtgHolding.Items(intCount).Cells(8).FindControl("chkHoldingID"), CheckBox).Checked Then
                    strCopyNumberIDs = strCopyNumberIDs & dtgHolding.Items(intCount).Cells(0).Text & ","
                End If
            Next
            If strCopyNumberIDs <> "" Then
                strCopyNumberIDs = Left(strCopyNumberIDs, Len(strCopyNumberIDs) - 1)
                objBIC.UpdateLoanTypeOfCopies(strCopyNumberIDs, ddlNewLoanType.SelectedValue)
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text.Trim & " " & ddlLabel.Items(8).Text.Trim & "');</script>")

                Call ShowResultSearch()
            End If
        End Sub

        ' Event: chkAll_CheckedChanged
        Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
            Dim intcount As Integer
            Dim blnChecked As Boolean

            blnChecked = chkAll.Checked
            For intcount = 0 To dtgHolding.Items.Count - 1
                CType(dtgHolding.Items(intcount).Cells(8).FindControl("chkHoldingID"), CheckBox).Checked = blnChecked
            Next
        End Sub

        ' dtgHolding_ItemCreated event
        Private Sub dtgHolding_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgHolding.ItemCreated
            Dim intIndex As Int16 = e.Item.ItemIndex + 3
            Dim inti As Integer
            For inti = 0 To e.Item.Cells.Count - 2
                e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dtgHolding','chkHoldingID'," & e.Item.ItemIndex + 3 & ");")
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
                If Not objBIC Is Nothing Then
                    objBIC.Dispose(True)
                    objBIC = Nothing
                End If
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace