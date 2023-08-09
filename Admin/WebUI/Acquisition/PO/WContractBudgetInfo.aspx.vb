' Class: WPOContractBudgetInfo
' Purpose: 
' Creator: tuanhv
' CreatedDate: 09/04/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractBudgetInfo
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSubTitle As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBBudget As New clsBBudget

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init objects
        Private Sub Initialize()
            ' Init objBBudget object
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            Call objBBudget.Initialize()
        End Sub

        ' Method: BindData
        Sub BindData()
            Dim tblResult As DataTable

            ' Get budget
            objBBudget.BudID = 0
            objBBudget.PoID = 0
            objBBudget.LibID = clsSession.GlbSite
            tblResult = objBBudget.GetBudget
            hidContractID.Value = Request("ContractID")
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    dtgBudget.DataSource = tblResult
                    dtgBudget.DataBind()
                End If
            End If
        End Sub

        ' Event: dtgBudget_PageIndexChanged
        Private Sub dtgBudget_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgBudget.PageIndexChanged
            dtgBudget.CurrentPageIndex = e.NewPageIndex
        End Sub

        ' Event: dtgBudget_ItemCreated
        Private Sub dtgBudget_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgBudget.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.EditItem, ListItemType.Item
                    Dim lnkclnm As HyperLink
                    Dim strID As String = ""
                    lnkclnm = e.Item.Cells(0).Controls(0)
                    strID = CStr(DataBinder.Eval(e.Item.DataItem, "ID"))
                    If DataBinder.Eval(e.Item.DataItem, "Status") = 0 Then
                        lnkclnm.NavigateUrl = "WContractLiquidateInform.aspx?ContractID=" & hidContractID.Value & "&BudID=" & strID
                        lnkclnm.CssClass = "lbLinkFunction"
                    Else
                        'lnkclnm.NavigateUrl = ""
                    End If
            End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call objBBudget.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace