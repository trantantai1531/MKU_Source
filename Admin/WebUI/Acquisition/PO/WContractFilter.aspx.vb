' Class: WContractFilter
' Purpose: Filter contracts
' Creator: oanhtn
' CreatedDate: 11/04/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractFilter
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
        Private objVendor As New clsBVendor
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBBudget As New clsBBudget
        Private objBPO As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
            ' Init objVendor object
            objVendor.InterfaceLanguage = Session("InterfaceLanguage")
            objVendor.DBServer = Session("DBServer")
            objVendor.ConnectionString = Session("ConnectionString")
            Call objVendor.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()

            ' Init objBBudget object
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            Call objBBudget.Initialize()

            ' Init objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()
        End Sub

        ' Method: BindJavascript
        ' Purpose: Include all need js functions
        Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/PO/WContract.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkValidDateFrom, txtValidDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkValidDateTo, txtValidDateTo, ddlLabel.Items(4).Text)

            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")

            Me.SetCheckNumber(txtAmountFrom, ddlLabel.Items(4).Text, "")
            Me.SetCheckNumber(txtAmountTo, ddlLabel.Items(4).Text, "")
        End Sub

        ' Method: BindData
        ' Purpose: binddata now
        Sub BindData()
            Dim tblTemp As DataTable

            ' Get all vendors 
            tblTemp = objVendor.GetVendor()
            If Not tblTemp Is Nothing Then
                tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(5).Text)
                ddlVendor.DataSource = tblTemp
                ddlVendor.DataTextField = "Name"
                ddlVendor.DataValueField = "ID"
                ddlVendor.DataBind()
                tblTemp.Clear()
            End If

            ' Get currency
            tblTemp = objBCommonBusiness.GetCurrency()
            If Not tblTemp Is Nothing Then
                tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(5).Text)
                ddlCurrency.DataSource = tblTemp
                ddlCurrency.DataTextField = "CurrencyCode"
                ddlCurrency.DataValueField = "CurrencyCode"
                ddlCurrency.DataBind()
                tblTemp.Clear()
            End If

            ' Get budget
            objBBudget.LibID = clsSession.GlbSite
            tblTemp = objBBudget.GetBudget
            If Not tblTemp Is Nothing Then
                tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(5).Text)
                ddlBudget.DataSource = tblTemp
                ddlBudget.DataTextField = "BudgetName"
                ddlBudget.DataValueField = "ID"
                ddlBudget.DataBind()
                'tblTemp.Clear()
            End If

            ' Release objects
            If Not tblTemp Is Nothing Then
                tblTemp = Nothing
            End If
        End Sub

        ' Event: btnFilter_Click
        ' Purpose: filter data now
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Dim arrIDs() As Object

            objBPO.PoName = txtPoName.Text.Trim
            objBPO.ReceiptNo = txtReceiptNo.Text.Trim
            objBPO.ValidDateFrom = txtValidDateFrom.Text.Trim
            objBPO.ValidDateTo = txtValidDateTo.Text.Trim
            If Not txtAmountFrom.Text.Trim = "" Then
                objBPO.AmountFrom = txtAmountFrom.Text.Trim
            End If
            If Not txtAmountTo.Text.Trim = "" Then
                objBPO.AmountTo = txtAmountTo.Text.Trim
            End If
            objBPO.Title = txtTitle.Text.Trim
            objBPO.Author = txtAuthor.Text.Trim
            objBPO.Publisher = txtPublisher.Text.Trim
            objBPO.PubYear = txtPubYear.Text.Trim
            objBPO.ISBN = txtISBN.Text.Trim
            'If Not InStr(ddlCurrency.SelectedItem.Value, "-----") >= 0 Then
            If Not ddlCurrency Is Nothing AndAlso ddlCurrency.Items.Count > 0 Then
                If ddlCurrency.SelectedIndex > 0 Then
                    objBPO.Currency = ddlCurrency.SelectedItem.Value
                End If
            End If
            objBPO.VendorID = 0
            If Not ddlVendor Is Nothing Then
                objBPO.VendorID = ddlVendor.SelectedItem.Value
            End If
            objBPO.BudgetID = 0
            If Not ddlBudget Is Nothing AndAlso ddlBudget.Items.Count > 0 Then
                objBPO.BudgetID = ddlBudget.SelectedItem.Value
            End If
            ' Get result
            objBPO.LibID = clsSession.GlbSite
            arrIDs = objBPO.SearchContract()

            ' Load taskbar
            If Not arrIDs Is Nothing Then
                Session("FilterIDs") = arrIDs
                Page.RegisterClientScriptBlock("LoadTaskBarJs", "<script language = 'javascript'>parent.taskbar.document.forms[0].txtMaxID.value=" & UBound(arrIDs) + 1 & "; parent.taskbar.document.forms[0].txtCurrentID.value=" & LBound(arrIDs) + 1 & "; location.href='WContractDetail.aspx';</script>")
            Else
                Page.RegisterClientScriptBlock("NotFoundJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
            End If
        End Sub

        ' Method: Dispose
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call objBCommonBusiness.Dispose(True)
                Call objVendor.Dispose(True)
                Call objBBudget.Dispose(True)
                Call objBPO.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace