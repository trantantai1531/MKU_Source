' Class: WContractPOSearch
' Purpose: 
' Creator: tuanhv
' CreatedDate: 04/04/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractPOSearch
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
        Private objVendor As New clsBVendor
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBBudget As New clsBBudget

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Methord: BindJavascript
        Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("TaskbarJs", "<script language = 'javascript' src = '../Js/Po/WContractPOSearch.js'></script>")
            ' Calendar
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkValidDateFrom, txtValidDateFrom, ddlLabel.Items(6).Text)
            SetOnclickCalendar(lnkValidDateTo, txtValidDateTo, ddlLabel.Items(6).Text)
            ' Reset value
            btnReset.Attributes.Add("OnClick", "javascript:Reset(); return false;")
            ' Check null
            btnFilter.Attributes.Add("OnClick", "javascript:Filter(); return false;")
        End Sub

        ' Initialize method
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
        End Sub

        ' Methord: BindData
        Sub BindData()
            Dim tblResult As DataTable
            ' Get all vendors 
            objVendor.VendorID = 0
            tblResult = objVendor.GetVendor()
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlVendor.DataSource = tblResult
                    ddlVendor.DataTextField = "Name"
                    ddlVendor.DataValueField = "ID"
                    ddlVendor.DataBind()
                End If
            End If
            tblResult = Nothing

            ' Get currency
            tblResult = objBCommonBusiness.GetCurrency()
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlCurrency.DataSource = tblResult
                    ddlCurrency.DataTextField = "CurrencyCode"
                    ddlCurrency.DataValueField = "CurrencyCode"
                    ddlCurrency.DataBind()
                End If
            End If
            tblResult = Nothing

            ' Get budget
            objBBudget.BudID = 0
            objBBudget.PoID = 0
            tblResult = objBBudget.GetBudget
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlBudget.DataSource = tblResult
                    ddlBudget.DataTextField = "BudgetName"
                    ddlBudget.DataValueField = "ID"
                    ddlBudget.DataBind()
                End If
            End If
        End Sub


        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call objBCommonBusiness.Dispose(True)
                Call objVendor.Dispose(True)
                Call objBBudget.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click

        End Sub
    End Class
End Namespace
