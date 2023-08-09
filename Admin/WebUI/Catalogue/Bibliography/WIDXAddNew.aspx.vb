Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIDXAddNew
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblTitleView As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variable
        Private objBIDX As New clsBIDX

        'Event Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Init all object use in form
            Call Initialze()
            'Bind javascript for all control need
            Call BindJavascript()
            If Not Page.IsPostBack Then
                'Show data
                Call LoadData()
            End If
            Call CheckFormPermission()
        End Sub

        ' Initialze method
        Private Sub Initialze()
            'Object objBIDX
            objBIDX.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDX.DBServer = Session("DbServer")
            objBIDX.ConnectionString = Session("ConnectionString")
            objBIDX.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            ' Register the JS (common and self)
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WIDXAddNew.js'></script>")

            btnAddNew.Attributes.Add("onClick", "return ValidAddNew('" & ddlLabel.Items(0).Text & "');")
            btnDelete.Attributes.Add("onClick", "return ValidDel('" & ddlLabel.Items(1).Text & "');")
            btnUpdate.Attributes.Add("onClick", "return ValidUpdate('" & ddlLabel.Items(2).Text & "');")
            btnView.Attributes.Add("onClick", "return ValidView('" & ddlLabel.Items(2).Text & "');")
            btnSaveToFile.Attributes.Add("onClick", "return ValidView('" & ddlLabel.Items(2).Text & "');")
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            ' Create New bibliography
            If Not CheckPemission(11) Then
                btnAddNew.Enabled = False
            End If
            ' Modify bibliography (Name, group by)
            If Not CheckPemission(12) Then
                dtgIDX.Columns(7).Visible = False
            End If
            ' Delete bibliography
            If Not CheckPemission(167) Then
                btnDelete.Enabled = False
            End If
            ' View bibliography details
            If Not CheckPemission(168) Then
                btnView.Enabled = False
            End If
            ' Update bibliography
            If Not CheckPemission(174) Then
                btnUpdate.Enabled = False
            End If
            ' Save bibliography to file
            If Not CheckPemission(175) Then
                btnSaveToFile.Enabled = False
            End If
        End Sub

        ' LoadData method
        Private Sub LoadData(Optional ByVal intPage As Integer = 0)
            objBIDX.IDs = ""
            objBIDX.UserID = Session("UserID")
            objBIDX.LibID = clsSession.GlbSite
            dtgIDX.DataSource = objBIDX.IDXRetrieve()
            dtgIDX.CurrentPageIndex = intPage
            dtgIDX.DataBind()
        End Sub

        ' dtgIDX_PageIndexChanged event
        Private Sub dtgIDX_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgIDX.PageIndexChanged
            Call LoadData(e.NewPageIndex)
        End Sub

        ' btnAddNew_Click event
        Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            objBIDX.Title = txtTitle.Text
            objBIDX.GroupBy = txtGroupBy.Text
            objBIDX.LibID = clsSession.GlbSite
            objBIDX.UserID = Session("UserID")
            Dim intOut = objBIDX.IDXInsert()
            If intOut = 0 Then
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & " thành công')</script>")
            Else
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Đã tồn tại danh mục')</script>")
            End If
            'Write log
            Call WriteLog(82, ddlLabel.Items(6).Text & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Call LoadData()
            txtTitle.Text = ""
            txtGroupBy.Text = ""
        End Sub

        ' dtgIDX_EditCommand event
        Private Sub dtgIDX_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgIDX.EditCommand
            dtgIDX.EditItemIndex = CInt(e.Item.ItemIndex)
            Call LoadData(dtgIDX.CurrentPageIndex)
        End Sub

        ' dtgIDX_UpdateCommand event
        Private Sub dtgIDX_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgIDX.UpdateCommand
            Dim strTitle As String = Trim(CType(e.Item.Cells(2).FindControl("txtTitleG"), TextBox).Text & "")
            Dim strGroupBy As String = Trim(CType(e.Item.Cells(3).FindControl("txtGroupByG"), TextBox).Text & "")
            objBIDX.IDs = CType(e.Item.Cells(0).FindControl("lblID"), Label).Text
            If strTitle = "" Or strGroupBy = "" Then
                ' Not update
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "')</script>")
            Else
                ' Execute update
                objBIDX.Title = strTitle
                objBIDX.GroupBy = strGroupBy
                objBIDX.TORsAdd = 0
                objBIDX.UserID = Session("UserID")
                objBIDX.LibID = clsSession.GlbSite
                Dim intOut = objBIDX.IDXUpdate()
                If intOut = 0 Then
                    'Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & " thành công')</script>")
                Else
                    Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Đã tồn tại danh mục')</script>")
                End If
                'Write log
                Call WriteLog(82, ddlLabel.Items(7).Text & strTitle, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                dtgIDX.EditItemIndex = -1
                Call LoadData(dtgIDX.CurrentPageIndex)
            End If
        End Sub

        ' dtgIDX_CancelCommand event
        Private Sub dtgIDX_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgIDX.CancelCommand
            dtgIDX.EditItemIndex = -1
            Call LoadData(dtgIDX.CurrentPageIndex)
        End Sub

        ' btnDelete_Click event
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim strIDs As String = Trim(txtHidIDs.Value & "")
            If strIDs <> "" Then
                Try
                    objBIDX.IDs = strIDs
                    objBIDX.IDXDelete()
                    Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Xóa danh mục thành công')</script>")
                Catch ex As Exception

                End Try

                ' Write log
                Call WriteLog(82, ddlLabel.Items(8).Text & "(IDs:" & strIDs & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call LoadData()
            End If
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Response.Redirect("WIDXForm.aspx?ID=" & txtHidIDs.Value)
        End Sub

        ' btnView_Click event
        Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
            Response.Redirect("WIDXViewForm.aspx?intIDXID=" & txtHidIDs.Value & "&intTypeview=1")
        End Sub

        ' btnSaveToFile_Click event
        Private Sub btnSaveToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveToFile.Click
            Response.Redirect("WIDXSaveForm.aspx?intIDXID=" & txtHidIDs.Value & "&intTypeview=1")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBIDX Is Nothing Then
                        objBIDX.Dispose(True)
                        objBIDX = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace