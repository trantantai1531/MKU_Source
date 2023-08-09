Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBudgetList
        Inherits clsWBase
        Implements IUCNumberOfRecord
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblReport As System.Web.UI.WebControls.Label


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

            Select Case Request("Display")
                Case 0
                    lblReportTitle.Visible = True
                    lblSpendTitle.Visible = False
                    lblReceiveTitle.Visible = False
                Case 1
                    lblReportTitle.Visible = False
                    lblSpendTitle.Visible = True
                    lblReceiveTitle.Visible = False
                Case 2
                    lblReportTitle.Visible = False
                    lblSpendTitle.Visible = False
                    lblReceiveTitle.Visible = True
            End Select
            objBBudget.LibID = clsSession.GlbSite
            tblBudget = objBBudget.GetBudget(0, CInt(Request("Display")))
            If Not tblBudget Is Nothing Then
                If tblBudget.Rows.Count > 0 Then
                    dgtBudget.DataSource = tblBudget
                    ' dgtBudget.DataBind()
                End If
            End If
        End Sub

        ' dgtBudget_ItemCreated event
        Private Sub dgtBudget_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dgtBudget.ItemCreated

            If TypeOf e.Item Is GridDataItem Then
               Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)


                Dim lnk = TryCast(e.Item.FindControl("lnkBudgetName"), HyperLink)
                If Not lnk Is Nothing Then

                    lnk.NavigateUrl = "WAccountDetail.aspx?Display=" & Request("Display") & "&BudgetID=" & DataBinder.Eval(e.Item.DataItem, "ID")
                    'lnk.CssClass = "lbLinkFunction"
                    'If DataBinder.Eval(e.Item.DataItem, "Status") = 0 Then
                    '    lnk.NavigateUrl = "WAccountDetail.aspx?Display=" & Request("Display") & "&BudgetID=" & 1
                    '    lnk.CssClass = "lbLinkFunction"
                    'End If
                End If
            End If
          

            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    ' Declare variables
                    Dim tblCell As TableCell
                    Dim lnk As HyperLink

                    tblCell = e.Item.Cells(0)

                    lnk = CType(tblCell.FindControl("lnkBudgetName"), HyperLink)
                    If Not lnk Is Nothing Then
                        If DataBinder.Eval(e.Item.DataItem, "Status") = 0 Then
                            lnk.NavigateUrl = "WAccountDetail.aspx?Display=" & Request("Display") & "&BudgetID=" & 1
                            lnk.CssClass = "lbLinkFunction"
                        End If
                    End If


            End Select
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

     

     

        Protected Sub dgtBudget_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dgtBudget.NeedDataSource
            BindData()

        End Sub

        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function
     
    End Class
End Namespace