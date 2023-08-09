' class WTransferBudget
' Puspose: transfer money from budget to another
' Creator: Lent
' CreatedDate: 6-4-2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WTransferBudget
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
        Dim objBBudget As New clsBBudget
        Dim objBAccounting As New clsBAccounting
        Dim objBRateMan As New clsBRateMan

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Check permisssion
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(113) Then
                btnTransfer.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            ' Initialize objBBudget object
            objBBudget.DBServer = Session("DBServer")
            objBBudget.ConnectionString = Session("ConnectionString")
            objBBudget.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBBudget.Initialize()

            ' Initialize objBAccounting object
            objBAccounting.DBServer = Session("DBServer")
            objBAccounting.ConnectionString = Session("ConnectionString")
            objBAccounting.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBAccounting.Initialize()

            ' Initialize objBRateMan object
            objBRateMan.DBServer = Session("DBServer")
            objBRateMan.ConnectionString = Session("ConnectionString")
            objBRateMan.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRateMan.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Accounting/WTransferBudget.js'></script>")

            btnReset.Attributes.Add("onclick", "javascript:document.forms[0].reset();return false;")
            btnTransfer.Attributes.Add("Onclick", "javascript:return(CheckTransfer('" & ddlLabelNote.Items(0).Text & "','" & ddlLabelNote.Items(13).Text & "','" & ddlLabelNote.Items(1).Text & "','" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "','" & ddlLabelNote.Items(7).Text & "','" & ddlLabelNote.Items(12).Text & "'))")
            Me.SetCheckNumberCurrency(txtMoney, ddlLabelNote.Items(1).Text)
            'Me.SetCheckNumber(txtDateTran, ddlLabelNote.Items(2).Text)
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDateTran, txtDateTran, ddlLabelNote.Items(2).Text)
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tmpResult As DataTable

            ' Get budgets
            objBBudget.LibID = clsSession.GlbSite
            tmpResult = objBBudget.GetBudgetByStatus

            If Not tmpResult Is Nothing AndAlso tmpResult.Rows.Count > 0 Then
                ddlBudgetDes.DataSource = tmpResult
                ddlBudgetDes.DataTextField = "BudgetNames"
                ddlBudgetDes.DataValueField = "BudgetValue"
                ddlBudgetDes.DataBind()

                ddlBudgetSrc.DataSource = tmpResult
                ddlBudgetSrc.DataTextField = "BudgetNames"
                ddlBudgetSrc.DataValueField = "BudgetValue"
                ddlBudgetSrc.DataBind()
            End If
            txtMoney.Text = ""
            txtDateTran.Text = Session("ToDay")
            txtDecision.Text = clsSession.GlbUserFullName
        End Sub

        ' btnTransfer_Click event
        ' Purpose: Transfer the budget
        Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
            Dim arrValueSrc() As String = ddlBudgetSrc.SelectedValue.Split(",")
            Dim arrValueDes() As String = ddlBudgetDes.SelectedValue.Split(",")
            Dim tblRateMan As DataTable
            Dim dblRateSrc As Double = 1
            Dim dblRateDes As Double = 1
            Dim dblMonTrans As Double = 0
            Dim strBudgetName As String
            Dim strFilter As String = ""
            Dim intresult As Integer
            objBRateMan.CurrencyCode = ""
            tblRateMan = objBRateMan.GetRate
            ' Get the currency rate of source budget and destination budget
            If (Not tblRateMan Is Nothing) AndAlso tblRateMan.Rows.Count > 0 Then
                strFilter = "CurrencyCode='" & arrValueSrc(2) & "'"
                tblRateMan.DefaultView.RowFilter = strFilter
                dblRateSrc = CDbl(tblRateMan.DefaultView(0).Item("Rate"))
                strFilter = "CurrencyCode='" & arrValueDes(2) & "'"
                tblRateMan.DefaultView.RowFilter = strFilter
                dblRateDes = CDbl(tblRateMan.DefaultView(0).Item("Rate"))
            End If

            ' Change source money to VND
            dblMonTrans = CDbl(txtMoney.Text) * dblRateSrc
            If arrValueDes(2) <> "VND" Then
                dblMonTrans = dblMonTrans / dblRateDes
            End If

            ' Update acq_budget
            intresult = objBBudget.TransferMoneyWithCheck(CInt(arrValueSrc(0)), CInt(arrValueDes(0)), CDbl(txtMoney.Text), dblMonTrans)
            If intresult <> 0 Then
                Page.RegisterClientScriptBlock("TransferJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(14).Text & "');</script>")
                Exit Sub
            End If
            Call WriteLog(101, ddlLabelNote.Items(11).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Insert acq_budget_credit
            strBudgetName = ddlBudgetSrc.SelectedItem.Text
            strBudgetName = strBudgetName.Substring(0, strBudgetName.IndexOf("("))

            objBAccounting.Currency = arrValueDes(2)
            objBAccounting.Reason = ddlLabelNote.Items(5).Text & " : " & strBudgetName
            objBAccounting.TransactionDate = txtDateTran.Text
            objBAccounting.Inputer = txtDecision.Text
            objBAccounting.BudgetID = arrValueDes(0)
            objBAccounting.Amount = dblMonTrans
            objBAccounting.ExchangeRate = dblRateDes
            objBAccounting.InsertReceived()


            ' Insert acq_budget_debit
            strBudgetName = ddlBudgetDes.SelectedItem.Text
            strBudgetName = strBudgetName.Substring(0, strBudgetName.IndexOf("("))

            objBAccounting.Currency = arrValueSrc(2)
            objBAccounting.Reason = ddlLabelNote.Items(4).Text & " : " & strBudgetName
            objBAccounting.TransactionDate = txtDateTran.Text
            objBAccounting.Inputer = txtDecision.Text
            objBAccounting.BudgetID = arrValueSrc(0)
            objBAccounting.Amount = CDbl(txtMoney.Text)
            objBAccounting.ExchangeRate = dblRateSrc
            objBAccounting.Commited = 0
            objBAccounting.InsertSpend()

            Page.RegisterClientScriptBlock("TransferJS", "<script language='javascript'>alert('" & ddlLabelNote.Items(6).Text & "');</script>")
            Call BindData()
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
                If Not objBAccounting Is Nothing Then
                    objBAccounting.Dispose(True)
                    objBAccounting = Nothing
                End If
                If Not objBRateMan Is Nothing Then
                    objBRateMan.Dispose(True)
                    objBRateMan = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace