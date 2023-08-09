Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WDecSpend
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
        Private objBBudget As New clsBBudget

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: Init all object
        Private Sub Initialize()
            ' Init for objBBudget
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            objBBudget.Initialize()
        End Sub

        ' BindData method
        ' Purpose: Bind the budget details
        Private Sub BindData()
            ' Declare variable
            Dim tblBudget As DataTable

            tblBudget = objBBudget.GetBudget
            If Not tblBudget Is Nothing Then
                If tblBudget.Rows.Count > 0 Then
                    dgtBudget.DataSource = tblBudget
                    dgtBudget.DataBind()
                End If
            End If
        End Sub

        ' dgtBudget_ItemCreated event
        Private Sub dgtBudget_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgtBudget.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' Declare variables
                    Dim tblCell As TableCell
                    Dim lnk As HyperLink

                    tblCell = e.Item.Cells(0)

                    lnk = CType(tblCell.FindControl("lnkBudgetName"), HyperLink)

                    If DataBinder.Eval(e.Item.DataItem, "Status") = 0 Then
                        lnk.NavigateUrl = "WAccountDetail.aspx?Display=1&BudgetID=" & DataBinder.Eval(e.Item.DataItem, "ID")
                        lnk.CssClass = "lbLinkFunction"
                    End If
            End Select
        End Sub

        ' dgtBudget_PageIndexChanged event
        Private Sub dgtBudget_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgtBudget.PageIndexChanged
            dgtBudget.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBBudget Is Nothing Then
                    objBBudget.Dispose(True)
                    objBBudget = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace