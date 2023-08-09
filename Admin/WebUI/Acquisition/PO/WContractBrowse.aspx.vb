' Class: WContractPOBrowse
' Purpose: Browse list of contracts
' Creator: tuanhv
' CreatedDate: 04/04/2005
' Modification history:
'   - 11/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractBrowse
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMonth As System.Web.UI.WebControls.Label
        Protected WithEvents btnBrowse As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBPurchaseOrder As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                hidOption.Value = Request("BrowseType")
                If CInt(hidOption.Value) = 1 Then
                    lblPageTitle.Text = ddlLabel.Items(6).Text
                    lblParameter1.Text = ddlLabel.Items(7).Text
                    lblParameter2.Text = ddlLabel.Items(8).Text
                ElseIf CInt(hidOption.Value) = 2 Then
                    lblPageTitle.Text = ddlLabel.Items(9).Text
                    lblParameter1.Text = ddlLabel.Items(10).Text
                    lblParameter2.Text = ddlLabel.Items(7).Text
                ElseIf CInt(hidOption.Value) = 3 Then
                    lblPageTitle.Text = ddlLabel.Items(11).Text
                    lblParameter1.Text = ddlLabel.Items(12).Text
                    lblParameter2.Text = ddlLabel.Items(7).Text
                Else
                    lblPageTitle.Text = ddlLabel.Items(13).Text
                    lblParameter1.Text = ddlLabel.Items(14).Text
                    lblParameter2.Text = ddlLabel.Items(7).Text
                End If
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(180) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all need objects
        Private Sub Initialize()
            ' Init objBPurchaseOrder object
            objBPurchaseOrder.InterfaceLanguage = Session("InterfaceLanguage")
            objBPurchaseOrder.DBServer = Session("DBServer")
            objBPurchaseOrder.ConnectionString = Session("ConnectionString")
            Call objBPurchaseOrder.Initialize()
        End Sub

        ' Method: BindData
        Sub BindData()
            Dim tblResult As DataTable
            Dim intOption As Integer = CInt(hidOption.Value)

            objBPurchaseOrder.LibID = clsSession.GlbSite
            ' Get all year exit contract
            tblResult = objBPurchaseOrder.BrowseContract(0, 0, intOption, clsSession.GlbSite)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlParameter1.DataSource = tblResult
                    ddlParameter1.DataTextField = "Parameter1"
                    ddlParameter1.DataValueField = "ID"
                    ddlParameter1.DataBind()
                    tblResult.Clear()

                    tblResult = objBPurchaseOrder.BrowseContract(CInt(ddlParameter1.SelectedValue), 0, intOption, clsSession.GlbSite)
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            ddlParameter2.DataSource = tblResult
                            ddlParameter2.DataTextField = "Parameter2"
                            ddlParameter2.DataValueField = "ID"
                            ddlParameter2.DataBind()
                            tblResult.Clear()

                            tblResult = objBPurchaseOrder.BrowseContract(CInt(ddlParameter1.SelectedValue), CInt(ddlParameter2.SelectedValue), intOption, clsSession.GlbSite)
                            If Not tblResult Is Nothing Then
                                If tblResult.Rows.Count > 0 Then
                                    dtgResult.DataSource = tblResult
                                    dtgResult.DataBind()
                                    tblResult.Clear()
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            If Not tblResult Is Nothing Then
                tblResult = Nothing
            End If
        End Sub

        ' Event: ddlParameter1_SelectedIndexChanged
        Private Sub ddlParameter1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlParameter1.SelectedIndexChanged
            Dim tblResult As DataTable
            Dim intOption As Integer = CInt(hidOption.Value)

            dtgResult.CurrentPageIndex = 0
            tblResult = objBPurchaseOrder.BrowseContract(CInt(ddlParameter1.SelectedValue), 0, intOption, clsSession.GlbSite)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlParameter2.DataSource = tblResult
                    ddlParameter2.DataTextField = "ID"
                    ddlParameter2.DataValueField = "Parameter2"
                    ddlParameter2.DataBind()
                    tblResult.Clear()

                    tblResult = objBPurchaseOrder.BrowseContract(CInt(ddlParameter1.SelectedValue), CInt(ddlParameter2.SelectedValue), intOption, clsSession.GlbSite)
                    If Not tblResult Is Nothing Then
                        If tblResult.Rows.Count > 0 Then
                            dtgResult.DataSource = tblResult
                            dtgResult.DataBind()
                            tblResult.Clear()
                        End If
                    End If
                End If
            End If

            If Not tblResult Is Nothing Then
                tblResult = Nothing
            End If
        End Sub

        ' Event: dtgResult_ItemCreated
        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem
                    Dim lnkclnm As HyperLink
                    Dim strID As String = ""
                    lnkclnm = e.Item.Cells(1).Controls(0)
                    strID = CStr(DataBinder.Eval(e.Item.DataItem, "ID"))
                    lnkclnm.NavigateUrl = "WContractDetail.aspx?ContractID=" & strID
            End Select
        End Sub

        ' Event: dtgResult_PageIndexChanged
        Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            Dim tblResult As DataTable
            Dim intOption As Integer = CInt(hidOption.Value)

            dtgResult.CurrentPageIndex = e.NewPageIndex
            tblResult = objBPurchaseOrder.BrowseContract(CInt(ddlParameter1.SelectedValue), CInt(ddlParameter2.SelectedValue), intOption, clsSession.GlbSite)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    dtgResult.DataSource = tblResult
                    dtgResult.DataBind()
                    tblResult.Clear()
                End If
            End If

            If Not tblResult Is Nothing Then
                tblResult = Nothing
            End If
        End Sub

        ' Event: ddlParameter2_SelectedIndexChanged
        Private Sub ddlParameter2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlParameter2.SelectedIndexChanged
            Dim tblResult As DataTable
            Dim intOption As Integer = CInt(hidOption.Value)

            dtgResult.CurrentPageIndex = 0
            tblResult = objBPurchaseOrder.BrowseContract(CInt(ddlParameter1.SelectedValue), CInt(ddlParameter2.SelectedValue), intOption, clsSession.GlbSite)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    dtgResult.DataSource = tblResult
                    dtgResult.DataBind()
                End If
            End If
            If Not tblResult Is Nothing Then
                tblResult = Nothing
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call objBPurchaseOrder.Dispose(True)
            Finally
                Call MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub
    End Class
End Namespace