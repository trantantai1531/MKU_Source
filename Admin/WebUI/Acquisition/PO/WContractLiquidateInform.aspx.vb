' Class WContractLiquidateInform
' Puspose: 
' Creator: Tuanhv
' CreatedDate: 09/03/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractLiquidateInform
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents optPlanoptReal As System.Web.UI.WebControls.RadioButton


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBBudget As New clsBBudget
        Private objBAccounting As New clsBAccounting
        Private objBPO As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check form permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(107) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
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

            ' Init objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()

            txtTransactionDate.Text = CStr(Day(Now)).PadLeft(2, "0") & "/" & CStr(Month(Now)).PadLeft(2, "0") & "/" & CStr(Year(Now))
        End Sub

        ' Method: BindJavascript
        ' Purpose: include all need JS functions
        Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            txtTransactionDate.Attributes.Add("OnChange", "CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(3).Text & " '); return false;")
            Me.SetCheckNumber(txtAmount, ddlLabel.Items(4).Text)
            Me.SetCheckNumber(txtRate, ddlLabel.Items(4).Text)
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkTransactionDate, txtTransactionDate, ddlLabel.Items(3).Text)

            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnUpdate.Attributes.Add("OnClick", "if ((CheckNull(document.forms[0].txtRealAmount)) || (CheckNull(document.forms[0].txtTransactionDate))) {alert('" & ddlLabel.Items(10).Text & "'); return false;};")
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim intContractID As Integer
            Dim intBudgetID As Integer
            Dim intCount As Integer
            Dim intIndex As Integer
            Dim strTemp As String
            Dim dblPlanAmount As Double = 0
            Dim dblAmount As Double = 0
            Dim dblRate As Double = 0
            Dim strCurrencyOfBudget As String
            Dim strCurrencyOfPo As String
            Dim tblResult As New DataTable
            Dim dblTotalAmount As Double = 0
            Dim dblPrepaidAmount As Double = 0

            If Request("ContractID") <> "" Then
                intContractID = CInt(Request("ContractID"))
            End If

            If Request("BudID") <> "" Then
                intBudgetID = CInt(Request("BudID"))
            End If

            ' Get the currency of the selected budget
            objBBudget.BudID = intBudgetID
            tblResult = objBBudget.GetBudget
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    strCurrencyOfBudget = CStr(tblResult.Rows(0).Item("Currency"))
                    dblAmount = tblResult.Rows(0).Item("RealBalance")
                    dblRate = CDbl(tblResult.Rows(0).Item("Rate"))
                    hidRateTemp.Value = dblRate

                    'Load Infomation For Amount of budget
                    lblForAmount.Text = ddlLabel.Items(12).Text & " " & FormatNumber(tblResult.Rows(0).Item("Balance"), 0) & " " & strCurrencyOfBudget & " " & ddlLabel.Items(13).Text & " " & FormatNumber(tblResult.Rows(0).Item("RealBalance"), 0) & " " & strCurrencyOfBudget
                    lblForAmount.Visible = True
                End If
                tblResult.Clear()
            End If

            ' Get & Load PoInformation into Textboxs
            hidContractID.Value = intContractID
            hidBudgetID.Value = intBudgetID
            objBPO.AcqPOID = intContractID
            tblResult = objBPO.GetPO

            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    strCurrencyOfPo = tblResult.Rows(0).Item("Currency")
                    lblMainTitle.Text = ddlLabel.Items(7).Text & " (" & tblResult.Rows(0).Item("PoName") & " -- " & tblResult.Rows(0).Item("ReceiptNo") & ")"
                    lblCurrency.Text = strCurrencyOfPo
                    hidCurrency.Value = strCurrencyOfPo
                    'So tien thanh toan truoc:
                    dblPrepaidAmount = tblResult.Rows(0).Item("PrepaidAmount")
                End If
                tblResult.Clear()
            End If


            ' Tinh tong so tien mua an pham cua hop dong:
            objBPO.AcqPOID = intContractID
            tblResult = objBPO.GetOrderedItems
            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                Dim intj As Integer
                For intj = 0 To tblResult.Rows.Count - 1
                    dblTotalAmount = dblTotalAmount + tblResult.Rows(intj).Item("Amount2")
                Next
                tblResult.Clear()
            End If

            'Tinh tong thuc chi cho don dat:
            objBAccounting.PoID = intContractID
            tblResult = objBAccounting.GetDebitAmount(1)
            Dim dblTotalReal As Double = 0
            If Not tblResult Is Nothing Then
                For intIndex = 0 To tblResult.Rows.Count - 1
                    If strCurrencyOfPo = CStr(tblResult.Rows(intIndex).Item("ExchangeRate")) Then
                        dblTotalReal = dblTotalReal + CDbl(tblResult.Rows(intIndex).Item("Amount")) * CDbl(tblResult.Rows(intIndex).Item("ExchangeRate"))
                    Else
                        dblTotalReal = dblTotalReal + CDbl(tblResult.Rows(intIndex).Item("Amount"))
                    End If
                Next
                tblResult.Clear()
            End If

            ' Change to the currency of the selected budget
            objBAccounting.PoID = intContractID
            tblResult = objBAccounting.GetDebitAmount(0)

            If Not tblResult Is Nothing Then
                For intIndex = 0 To tblResult.Rows.Count - 1
                    If strCurrencyOfPo = CStr(tblResult.Rows(intIndex).Item("ExchangeRate")) Then
                        dblPlanAmount = dblPlanAmount + CDbl(tblResult.Rows(intIndex).Item("Amount")) * CDbl(tblResult.Rows(intIndex).Item("ExchangeRate"))
                    Else
                        dblPlanAmount = dblPlanAmount + CDbl(tblResult.Rows(intIndex).Item("Amount"))
                    End If
                Next
                tblResult.Clear()
            End If

            If dblPlanAmount >= dblAmount Then
                Page.RegisterClientScriptBlock("Liquidated", "<script language = 'javascript'>alert('" & ddlLabel.Items(11).Text & "')</script>")
            Else
                'Hien thi So tien chua thanh toan:
                txtAmount.Text = FormatNumber(dblTotalAmount - dblPrepaidAmount - dblTotalReal, 0)
                txtAmount.Enabled = False

                If strCurrencyOfBudget <> strCurrencyOfPo Or strCurrencyOfPo <> "VND" Then
                    If strCurrencyOfBudget = strCurrencyOfPo And strCurrencyOfPo <> "VND" Then
                        strTemp = ""
                    Else
                        strTemp = " (" & ddlLabel.Items(5).Text & strCurrencyOfBudget & " " & ddlLabel.Items(6).Text & " " & strCurrencyOfPo & ")"
                    End If
                    lblRate.Text = lblRate.Text & strTemp
                Else
                    lblRate.Visible = False
                    txtRate.Visible = False
                End If
            End If

            ' Release objects
            If Not tblResult Is Nothing Then
                tblResult.Dispose()
                tblResult = Nothing
            End If
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim dblAmount As Double
            Dim dblRate As Double
            Dim strTransactionDate As String
            Dim strReason As String
            Dim intContractID As Integer
            Dim intBudgetID As Integer
            Dim bytCommited As Byte
            Dim strInputer As String
            Dim strCurrency As String

            strCurrency = hidCurrency.Value
            strReason = txtReason.Text
            strTransactionDate = txtTransactionDate.Text
            strInputer = clsSession.GlbUserFullName
            intContractID = CInt(hidContractID.Value)
            intBudgetID = CInt(hidBudgetID.Value)

            dblAmount = CDbl(txtRealAmount.Text)
            dblRate = CDbl(hidRateTemp.Value)

            If optReal.Checked = True Then
                bytCommited = 1
            Else
                bytCommited = 0
            End If

            ' Insert data into ACQ_BUDGET_DEBIT table
            objBAccounting.BudgetID = intBudgetID
            objBAccounting.PoID = intContractID
            objBAccounting.Amount = dblAmount
            objBAccounting.Currency = strCurrency
            objBAccounting.Reason = strReason
            objBAccounting.TransactionDate = strTransactionDate
            objBAccounting.Inputer = strInputer
            objBAccounting.ExchangeRate = dblRate
            objBAccounting.FixedRate = dblRate
            objBAccounting.Commited = bytCommited
            objBAccounting.InsertAccountInfor(1)
            Call WriteLog(103, ddlLabel.Items(9).Text & ":" & objBAccounting.BudgetID & "," & CStr(intContractID), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

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
                Call objBBudget.Dispose(True)
                Call objBAccounting.Dispose(True)
                Call objBPO.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace