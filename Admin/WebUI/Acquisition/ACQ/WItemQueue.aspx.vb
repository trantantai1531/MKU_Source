' Class: WItemQueue
' Puspose: show list items
' Creator: Lent 
' CreatedDate: 15/2/2005
' Modification History:
'   - 15/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WItemQueue
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblAllItem As System.Web.UI.WebControls.Label
        Protected WithEvents lblMonth As System.Web.UI.WebControls.Label
        Protected WithEvents lblNoRecord As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBItem As New clsBItem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call LoadCataTimeList()
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBItem object
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBItem.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/ACQ/WItemQueue.js'></script>")

            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' Method: LoadCataTimeList
        ' Purpose: Load catalogued time list
        Private Sub LoadCataTimeList()
            Dim tmpTemp As DataTable
            Dim intCount As Integer = 0

            objBItem.LibID = clsSession.GlbSite
            tmpTemp = objBItem.GetCataTimeList(intCount, ddlLabel.Items(4).Text)

            tmpTemp = InsertOneRow(tmpTemp, ddlLabel.Items(3).Text & "(" & CStr(intCount) & ")")

            If Not tmpTemp Is Nothing AndAlso tmpTemp.Rows.Count > 0 Then
                ddlInputTime.DataSource = tmpTemp
                ddlInputTime.DataTextField = "Content"
                ddlInputTime.DataValueField = "InputDate"
                ddlInputTime.DataBind()
                ddlInputTime.Items(0).Value = ""
                ddlInputTime.SelectedIndex = 0
                ipSortType.Value = "0"
                tmpTemp = Nothing
            End If
        End Sub

        ' Method: BindData
        ' Purpose: Load data
        Private Sub BindData()
            Dim tmpTemp As DataTable
            Dim intItem As Integer
            Dim blCheckQueue As Boolean = False

            ' Bind data for datagrid
            objBItem.LibID = clsSession.GlbSite
            tmpTemp = objBItem.GetItemInQueueList(ipSortType.Value, ddlInputTime.SelectedValue)

            If Not tmpTemp Is Nothing Then
                If tmpTemp.Rows.Count > 0 Then
                    blCheckQueue = True
                End If
            End If

            If blCheckQueue Then
                dtgItemContent.DataSource = tmpTemp
                dtgItemContent.DataBind()
            Else
                dtgItemContent.Visible = False
                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
            End If
        End Sub

        ' Event: dtgItemContent_ItemCreated
        Private Sub dtgItemContent_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgItemContent.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem
                    Dim lnkContent As HyperLink
                    lnkContent = e.Item.Cells(1).Controls(0)
                    lnkContent.CssClass = "lbLinkFunction"
                    lnkContent.NavigateUrl = "javascript:LoadData(" & DataBinder.Eval(e.Item.DataItem, "ID") & ")"
            End Select
        End Sub

        ' Event: dtgItemContent_SortCommand
        Private Sub dtgItemContent_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dtgItemContent.SortCommand
            ipSortType.Value = e.SortExpression
            Call BindData()
        End Sub

        ' Event: dtgItemContent_PageIndexChanged
        Private Sub dtgItemContent_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgItemContent.PageIndexChanged
            dtgItemContent.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Event: ddlInputTime_SelectedIndexChanged
        Private Sub ddlInputTime_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlInputTime.SelectedIndexChanged
            Call BindData()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace