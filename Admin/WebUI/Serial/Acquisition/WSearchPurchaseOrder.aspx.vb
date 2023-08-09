' Class: WSearchPurchaseOrder
' Puspose: Search PurchaseOrders
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 21/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSearchPurchaseOrder
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
        Private objBVendor As New clsBVendor
        Private objBPO As New clsBPurchaseOrder
        Public strObjName As String

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBBudget object
            objBBudget.ConnectionString = Session("ConnectionString")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBBudget.Initialize()

            ' Init objBPO object
            objBPO.ConnectionString = Session("ConnectionString")
            objBPO.DBServer = Session("DBServer")
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPO.Initialize()

            ' Init objBVendor object
            objBVendor.ConnectionString = Session("ConnectionString")
            objBVendor.DBServer = Session("DBServer")
            objBVendor.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBVendor.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: include all necessary js functions
        Private Sub BindJS()
            Dim strObjName As String = Request("ContractCode")
            Dim strObjContractID As String = Request("ContractID")

            Page.RegisterClientScriptBlock("InitVar", "<script language = 'javascript'>strObjName = '" & strObjName & "';strObjContractID = '" & strObjContractID & "';</script>")

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WSearchPurchaseOrder.js'></script>")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromDate, txtFromDate, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkToDate, txtToDate, ddlLabel.Items(4).Text)
            btnReset.Attributes.Add("OnClick", "ResetAll();return false;")
        End Sub

        ' BindData method
        ' Purpose: Bind some dropdownlist
        Private Sub BindData()
            Dim tblTemp As DataTable

            tblTemp = objBVendor.GetVendor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBVendor.ErrorMsg, ddlLabel.Items(0).Text, objBVendor.ErrorCode)

            If Not tblTemp Is Nothing Then
                If Not tblTemp Is Nothing Then
                    ddlVendor.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                    ddlVendor.DataTextField = "Name"
                    ddlVendor.DataValueField = "ID"
                    ddlVendor.DataBind()
                End If
                tblTemp = Nothing
            End If

            tblTemp = objBBudget.GetBudget

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBudget.ErrorMsg, ddlLabel.Items(0).Text, objBBudget.ErrorCode)

            If Not tblTemp Is Nothing Then
                If Not tblTemp Is Nothing Then
                    ddlBudget.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                    ddlBudget.DataTextField = "BudgetName"
                    ddlBudget.DataValueField = "ID"
                    ddlBudget.DataBind()
                End If
                tblTemp = Nothing
            End If
        End Sub

        ' btnSearch_Click event
        ' Purpose: search contract
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            Dim tblContracts As DataTable
            Dim blnFound As Boolean = False

            Try
                objBPO.PoName = txtContractName.Text.Trim
                objBPO.ReceiptNo = txtContractNo.Text.Trim
                objBPO.VendorID = ddlVendor.SelectedValue
                objBPO.PoType = 0
                tblContracts = objBPO.GetContractList(txtFromDate.Text.Trim, txtToDate.Text.Trim, ddlBudget.SelectedValue)

                If Not tblContracts Is Nothing Then
                    If tblContracts.Rows.Count > 0 Then
                        dtgResult.Visible = True
                        dtgResult.DataSource = tblContracts
                        dtgResult.DataBind()
                        blnFound = True
                    End If
                    tblContracts = Nothing
                End If
                If Not blnFound Then
                    dtgResult.Visible = False
                    Page.RegisterClientScriptBlock("Alter", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_ItemCreated event
        ' Purpose: Add the javascript for contract code table row
        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    Dim lnkContractCode As HyperLink

                    tblCell = e.Item.Cells(0)
                    'lnkContractCode.CssClass = "lbLinkFunction"
                    lnkContractCode = CType(tblCell.FindControl("lnkContractCode"), HyperLink)
                    ' Add the attribute for the hiperlink to change the contract code
                    lnkContractCode.NavigateUrl = "javascript:LoadBack('" & DataBinder.Eval(e.Item.DataItem, "ReceiptNo") & "','" & DataBinder.Eval(e.Item.DataItem, "ContractID") & "');"
            End Select
        End Sub

        ' Page_Unload event
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
                If Not objBPO Is Nothing Then
                    objBPO.Dispose(True)
                    objBPO = Nothing
                End If
                If Not objBVendor Is Nothing Then
                    objBVendor.Dispose(True)
                    objBVendor = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace