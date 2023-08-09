' Class: WContractToBudget
' Purpose: 
' Creator: tuanhv
' CreatedDate: 04/04/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractToBudget
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

        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBBudget As New clsBBudget
        Private objBAccounting As New clsBAccounting

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objecs
        Private Sub Initialize()
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

            ' Init objBAccounting object
            objBAccounting.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccounting.DBServer = Session("DBServer")
            objBAccounting.ConnectionString = Session("ConnectionString")
            Call objBAccounting.Initialize()

            txtInputer.Text = clsSession.GlbUserFullName
            txtTransactionDate.Text = CStr(Day(Now)).PadLeft(2, "0") & "/" & CStr(Month(Now)).PadLeft(2, "0") & "/" & CStr(Year(Now))
        End Sub

        ' Method: BindJavascript
        ' Purpose: include all need JS functions
        Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkTransactionDate, txtTransactionDate, ddlLabel.Items(3).Text)

            Me.SetCheckNumber(txtAmount, ddlLabel.Items(4).Text, "")
            Me.SetCheckNumber(txtRate, ddlLabel.Items(4).Text, "")

            ddlCurrency.Attributes.Add("OnChange", "document.forms[0].txtRate.value=document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.options.selectedIndex].value;")
            btnClose.Attributes.Add("Onclick", "javascript:self.close();")
        End Sub

        ' Method: BindData
        Sub BindData()
            Dim tblResult As DataTable
            Dim inti As Integer
            ' Get currency
            objBCommonBusiness.LibID = clsSession.GlbSite
            tblResult = objBCommonBusiness.GetCurrency()
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlCurrency.DataSource = tblResult
                    ddlCurrency.DataTextField = "CurrencyCode"
                    ddlCurrency.DataValueField = "Rate"
                    ddlCurrency.DataBind()

                    For inti = 0 To tblResult.Rows.Count - 1
                        If CStr(tblResult.Rows(inti).Item("CurrencyCode")).ToLower = "vnd" Then
                            ddlCurrency.SelectedIndex = inti
                            Exit For
                        End If
                    Next

                End If
            End If
            tblResult = Nothing

            ' Get budget
            objBBudget.LibID = clsSession.GlbSite
            tblResult = objBBudget.GetBudget(1)
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    ddlBudget.DataSource = tblResult
                    ddlBudget.DataTextField = "BudgetDetail"
                    ddlBudget.DataValueField = "BudgetInfor"
                    ddlBudget.DataBind()
                End If
            End If

            If Not Request("ContractID") = "" Then
                hidContractID.Value = Request("ContractID")
            End If
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            ' Declare variables
            Dim intContractID As Integer
            Dim intBudgetID As Integer
            Dim strCurrency As String
            Dim strReason As String
            Dim strInputer As String
            Dim dblExchangeRate As Double = 0
            Dim dblFixedRate As Double
            Dim dblAmount As Double
            Dim strTransactionDate As String
            Dim strCode As String ' format: BudgetID#Currency#Rate
            Dim arrCode()

            ' Set properties's value
            strCode = ddlBudget.SelectedValue
            arrCode = Split(strCode, "#")
            If Not Trim(txtRate.Text) = "" Then
                dblExchangeRate = Trim(txtRate.Text)
            End If

            intContractID = CInt(hidContractID.Value)

            Try
                objBAccounting.BudgetID = CInt(arrCode(0))
                objBAccounting.FixedRate = CDbl(arrCode(2))

                objBAccounting.PoID = intContractID
                objBAccounting.Amount = CDbl(txtAmount.Text.Trim)
                'objBAccounting.ExchangeRate = CDbl(dblExchangeRate)
                objBAccounting.TransactionDate = txtTransactionDate.Text.Trim
                objBAccounting.Inputer = Trim(txtInputer.Text)
                objBAccounting.Reason = Trim(txtReason.Text)
                objBAccounting.Currency = ddlCurrency.SelectedItem.Text
                objBAccounting.ExchangeRate = CDbl(ddlCurrency.SelectedValue)
                objBAccounting.Commited = 2
                If CDbl(arrCode(2)) <> 0 Then
                    Call objBAccounting.InsertAccountInfor(3)
                    ' Write log
                    Call WriteLog(38, ddlLabel.Items(5).Text & ": " & txtAmount.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If
            Catch ex As Exception

            End Try
            ' Refresh opener window
            Page.RegisterClientScriptBlock("RefreshOpener", "<script language = 'javascript'>opener.document.location.href='WContractDetail.aspx?ContractID=" & hidContractID.Value & "'; self.close();</script>")
        End Sub

        ' Page_Unload
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call objBCommonBusiness.Dispose(True)
                Call objBBudget.Dispose(True)
                Call objBAccounting.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace