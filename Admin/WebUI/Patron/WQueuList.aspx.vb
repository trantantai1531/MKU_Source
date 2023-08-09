' class WQueuList
' Puspose: List view patron in queue
' Creator: Lent
' CreatedDate: 26-1-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WQueuList
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblNoteConfirm As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBPatron As New clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckPemisonform()
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Event: CheckPemisonform
        Sub CheckPemisonform()
            If Not CheckPemission(51) Then
                WriteErrorMssg(ddlLabelNote.Items(4).Text)
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Dim strJSConfirm As String
            Dim strJSCheckDelte As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/WQueueList.js'></script>")

            ' Get the js script strings 
            strJSCheckDelte = "if(!CheckOptionsNull('dtgCirPatronQueue', 'cbkOption', 3, 20, '" & ddlLabelNote.Items(0).Text & "')) return false;"
            strJSConfirm = "return ConfirmDelete('" & ddlLabelNote.Items(1).Text & "');"
            btnDelete.Attributes.Add("OnClick", strJSCheckDelte & " else " & strJSConfirm)
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            'bind data for datagrid
            Dim tmpResult As DataTable
            Dim intItem As Integer
            Dim intCount As Integer
            Dim blCheckQueue As Boolean = False

            tmpResult = objBPatron.GetPatronQueue
            ' Check error
            Call WriteErrorMssg(ddlLabelNote.Items(3).Text, objBPatron.ErrorMsg, ddlLabelNote.Items(2).Text, objBPatron.ErrorCode)

            If Not tmpResult Is Nothing Then
                If tmpResult.Rows.Count > 0 Then
                    intCount = CInt(tmpResult.Rows.Count / dtgCirPatronQueue.PageSize)
                    intItem = CInt(tmpResult.Rows.Count / dtgCirPatronQueue.PageSize) * dtgCirPatronQueue.PageSize
                    If intItem = tmpResult.Rows.Count Then
                        If dtgCirPatronQueue.CurrentPageIndex > intCount - 1 Then
                            dtgCirPatronQueue.CurrentPageIndex = dtgCirPatronQueue.CurrentPageIndex - 1
                        End If
                    End If
                    blCheckQueue = True
                End If
            End If
            If blCheckQueue Then
                dtgCirPatronQueue.DataSource = tmpResult
                dtgCirPatronQueue.DataBind()
            Else
                lblNotFound.Visible = True
                dtgCirPatronQueue.Visible = False
                btnDelete.Visible = False
            End If
        End Sub

        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim dtgItem As DataGridItem
            Dim chkCheckBox As CheckBox
            Dim strIDs As String

            strIDs = ""
            For Each dtgItem In dtgCirPatronQueue.Items
                chkCheckBox = dtgItem.FindControl("cbkOption")
                If chkCheckBox.Checked Then
                    strIDs = strIDs & dtgItem.Cells(0).Text & ","
                End If
            Next
            If Trim(strIDs) <> "" Then
                strIDs = strIDs
                objBPatron.IDs = Left(strIDs, Len(strIDs) - 1)
                Call objBPatron.UpdateQueue()

                ' Check error
                Call WriteErrorMssg(ddlLabelNote.Items(3).Text, objBPatron.ErrorMsg, ddlLabelNote.Items(2).Text, objBPatron.ErrorCode)

                Call BindData()
            End If
        End Sub

        ' Event: dtgCirPatronQueue_ItemCreated
        Private Sub dtgCirPatronQueue_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgCirPatronQueue.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim inti As Integer
                    Dim lnkNamePatron As New HyperLink
                    lnkNamePatron = e.Item.Cells(2).Controls(0)
                    lnkNamePatron.NavigateUrl = "WPatron.aspx?PatronID=" & DataBinder.Eval(e.Item.DataItem, "ID")
                    lnkNamePatron.CssClass = "lbLinkFunction"

                    For inti = 0 To e.Item.Cells.Count - 2
                        e.Item.Cells(inti).Attributes.Add("onClick", "javascript:swapBG(this,'red');CheckOptionVisible('dtgCirPatronQueue','cbkOption'," & e.Item.ItemIndex + 3 & ");")
                    Next
            End Select
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace