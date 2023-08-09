Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPhotocopyPrice
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
        Private objBPhotoType As New clsBPhotocopyType

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindDataGrid()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(150) Then
                btnDel.Enabled = False
                btnNew.Enabled = False
                dtgListPrice.Columns(3).Visible = False
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPhotocopyPrice.js'></script>")

            btnNew.Attributes.Add("OnClick", "return ValidNew('" & ddlLabel.Items(2).Text & "')")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnClose.Attributes.Add("OnClick", "self.close();")
            txtPricePerPage.Attributes.Add("OnChange", "if (!CheckNumBer(this, '" & ddlLabel.Items(2).Text.Trim & "',0)) {this.value=0; this.focus();} if (this.value.length > 6 ) {this.value = 0; this.focus(); return false;}")
        End Sub

        ' Method: Initialze
        ' Purpose: Init all need objects
        Private Sub Initialze()
            ' Init objBPhotoType object
            objBPhotoType.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhotoType.DBServer = Session("DBServer")
            objBPhotoType.ConnectionString = Session("ConnectionString")
            Call objBPhotoType.Initialize()
        End Sub

        Private Sub BindDataGrid(Optional ByVal intPage As Integer = 0)
            Dim tblPhotoPrice As New DataTable

            tblPhotoPrice = objBPhotoType.GetPhotocopyTypes
            If Not tblPhotoPrice Is Nothing AndAlso tblPhotoPrice.Rows.Count > 0 Then
                dtgListPrice.DataSource = tblPhotoPrice
                dtgListPrice.CurrentPageIndex = intPage
                dtgListPrice.DataBind()
                tblPhotoPrice = Nothing
            End If
        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
            Dim intRetVal As Integer = 0

            If txtPricePerPage.Text.Trim <> "" Then
                If IsNumeric(txtPricePerPage.Text.Trim) Then
                    objBPhotoType.PricePerPage = CDbl(txtPricePerPage.Text.Trim)
                End If
            End If
            objBPhotoType.TypeName = txtTypeName.Text.Trim
            intRetVal = objBPhotoType.CreatePhotocopyType()

            If intRetVal > 0 Then
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Call BindDataGrid(dtgListPrice.CurrentPageIndex)
                txtPricePerPage.Text = ""
                txtTypeName.Text = ""

                ' Alert message
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text.Trim & " " & ddlLabel.Items(7).Text.Trim & "'); opener.location.href='WPhotocopyManagement.aspx'; self.close();</script>")
            Else
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text.Trim & "');</script>")
            End If
        End Sub

        Private Sub dtgListPrice_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListPrice.EditCommand
            dtgListPrice.EditItemIndex = e.Item.ItemIndex
            Call BindDataGrid(dtgListPrice.CurrentPageIndex)
        End Sub

        Private Sub dtgListPrice_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListPrice.UpdateCommand
            Dim strTypeName As String
            Dim strPricePerPage As String
            Dim blnValid As Boolean = True
            Dim intRetVal As Int16 = 0

            strTypeName = CType(dtgListPrice.Items(e.Item.ItemIndex).Cells(1).FindControl("txtTypeNameGrid"), TextBox).Text
            strPricePerPage = CType(dtgListPrice.Items(e.Item.ItemIndex).Cells(2).FindControl("txtPricePerPageGrid"), TextBox).Text
            If strTypeName = "" Or strPricePerPage = "" Then
                blnValid = False
            Else
                If Not IsNumeric(strPricePerPage) Then
                    blnValid = False
                End If
            End If
            If blnValid Then
                objBPhotoType.TypeID = CType(dtgListPrice.Items(e.Item.ItemIndex).Cells(0).FindControl("lblID"), Label).Text
                objBPhotoType.TypeName = strTypeName
                objBPhotoType.PricePerPage = CDbl(strPricePerPage)
                intRetVal = objBPhotoType.UpdatePhotocopyType()
                If intRetVal > 0 Then
                    ' WriteLog
                    Call WriteLog(110, ddlLabel.Items(4).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    dtgListPrice.EditItemIndex = -1
                    Call BindDataGrid(dtgListPrice.CurrentPageIndex)

                    ' Alert message
                    Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text.Trim & " " & ddlLabel.Items(7).Text.Trim & "')</script>")
                Else
                    Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "')</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "')</script>")
            End If

        End Sub

        Private Sub dtgListPrice_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgListPrice.CancelCommand
            dtgListPrice.EditItemIndex = -1
            Call BindDataGrid(dtgListPrice.CurrentPageIndex)
        End Sub

        ' Event: dtgListPrice_PageIndexChanged
        Private Sub dtgListPrice_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgListPrice.PageIndexChanged
            Call BindDataGrid(e.NewPageIndex)
        End Sub

        ' Event: btnDel_Click
        ' Purpose: Delete selected photocopy type
        Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
            Dim intCount As Integer
            Dim strTypeIDs As String = ""

            For intCount = 0 To dtgListPrice.Items.Count - 1
                If CType(dtgListPrice.Items(intCount).Cells(4).FindControl("chkTypeID"), CheckBox).Checked Then
                    strTypeIDs = strTypeIDs & CType(dtgListPrice.Items(intCount).Cells(0).FindControl("lblID"), Label).Text & ","
                End If
            Next
            If strTypeIDs <> "" Then
                strTypeIDs = Left(strTypeIDs, Len(strTypeIDs) - 1)
                objBPhotoType.TypeIDs = strTypeIDs
                objBPhotoType.DeletePhotocopyType()
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                objBPhotoType.TypeIDs = ""
                Call BindDataGrid()
                Page.RegisterClientScriptBlock("JSReFresh", "<script language = 'javascript'>opener.location.href='WPhotocopyManagement.aspx'; self.close();</script>")
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPhotoType Is Nothing Then
                    objBPhotoType.Dispose(True)
                    objBPhotoType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace