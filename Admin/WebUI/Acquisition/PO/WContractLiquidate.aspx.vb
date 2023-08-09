' Class: WContractLiquidate
' Purpose: Payment
' Creator: Tuanhv
' CreatedDate: 10/04/2005
' Modification history:
'   - 12/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractLiquidate
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtPoID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtBudgetID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtCurrency As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtRateTemp As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents dtgResult As System.Web.UI.WebControls.DataGrid


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBAccount As New clsBAccounting
        Private objBPO As New clsBPurchaseOrder

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialize    
        ' Purpose: init all need objecs
        Private Sub Initialize()
            ' Init objBAccount object
            objBAccount.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccount.DBServer = Session("DBServer")
            objBAccount.ConnectionString = Session("ConnectionString")
            Call objBAccount.Initialize()

            ' Init objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include all need js functions
        Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnClose.Attributes.Add("Onclick", "self.close();")
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim intContractID As Integer = 0
            Dim intCount As Integer = 0
            Dim intIndex As Integer = 0
            Dim dblRate As Double = 0
            Dim strPoName As String
            Dim tblTemp As New DataTable

            ' Set PoID
            If Not Request("ContractID") = "" Then
                hidContractID.Value = Request("ContractID")
            End If
            intContractID = CInt(hidContractID.Value)

            ' Get name of this contract
            objBPO.AcqPOID = intContractID
            tblTemp = objBPO.GetPO()
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    If Not IsDBNull(tblTemp.Rows(0).Item("POName")) Then
                        lblPoName.Text = ddlLabel.Items(7).Text & ": " & Trim(tblTemp.Rows(0).Item("POName")) & " (" & Trim(tblTemp.Rows(0).Item("ReceiptNo")) & ")"
                    Else
                        lblPoName.Text = ddlLabel.Items(7).Text & ": " & " " & " (" & Trim(tblTemp.Rows(0).Item("ReceiptNo")) & ")"
                    End If
                End If
                tblTemp.Clear()
            End If

            ' View planning amount
            objBAccount.PoID = intContractID
            tblTemp = objBAccount.GetDebitAmount(0)
            If Not tblTemp Is Nothing Then
                intCount = tblTemp.Rows.Count
                If tblTemp.Rows.Count > 0 Then
                    dtgDetail.DataSource = tblTemp
                    dtgDetail.DataBind()
                Else
                    ' PO have no planning amount
                    Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');self.close();</script>")
                    btnCancel.Visible = False
                    btnUpdate.Visible = False
                End If
            End If

            ' atleats one items have been selected
            btnUpdate.Attributes.Add("OnClick", "javascript:if (!CheckSelectedItems('dtgDetail', 'chkSelectedID', 2, " & intCount & ")) {alert('" & ddlLabel.Items(6).Text & "'); return false;}")
            btnCancel.Attributes.Add("OnClick", "javascript:if (!CheckSelectedItems('dtgDetail', 'chkSelectedID', 2, " & intCount & ")) {alert('" & ddlLabel.Items(6).Text & "'); return false;}")
        End Sub

        ' Load ExchangeRate textbox
        Private Sub dtgDetail_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgDetail.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    tblCell = e.Item.Cells(2)
                    Dim txtExchangeRateTemp As TextBox
                    txtExchangeRateTemp = CType(tblCell.FindControl("txtExchangeRate"), TextBox)
                    txtExchangeRateTemp.Attributes.Add("onchange", "javascript:if(!(CheckNum(this))){alert('" & "Not is a number" & "');this.focus();return false;}")
            End Select
        End Sub

        ' Event: btnUpdate_Click event
        ' Purpose: Change status selected debit amount(s)
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim dtgTemp As DataGridItem
            Dim chkSelected As CheckBox
            Dim strIDs As String = ""
            Dim strRates As String = ""

            For Each dtgTemp In dtgDetail.Items
                chkSelected = dtgTemp.FindControl("chkSelectedID")
                If chkSelected.Checked Then
                    strIDs = strIDs & CType(dtgTemp.FindControl("lblID"), Label).Text & ", "
                    strRates = strRates & CType(dtgTemp.FindControl("txtExchangeRate"), TextBox).Text & ", "
                End If
            Next

            If Not strIDs = "" Then
                Call objBAccount.UpdateDebitAmount(strIDs, strRates)
                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' RefreshOpener
                ' Page.RegisterClientScriptBlock("RefreshOpener", "<script language = 'javascript'>opener.document.location.href='WContractTaskbar.aspx?PoID=" & hidContractID.Value & "'; self.close();</script>")
                Page.RegisterClientScriptBlock("RefreshOpener", "<script language = 'javascript'>opener.document.location.href='WContractTaskbar.aspx?isContract=1&ContractID=" & hidContractID.Value & "'; self.close();</script>")
            End If
        End Sub

        ' Event: btnCancel_Click 
        ' Purpose: delete selected debit amount(s)
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Dim dtgTemp As DataGridItem
            Dim chkSelected As CheckBox
            Dim strIDs As String = ""

            For Each dtgTemp In dtgDetail.Items
                chkSelected = dtgTemp.FindControl("chkSelectedID")
                If chkSelected.Checked Then
                    strIDs = strIDs & CType(dtgTemp.FindControl("lblID"), Label).Text & ","
                End If
            Next
            If Not strIDs = "" Then
                Call objBAccount.DeleteDebitAmount(strIDs)
                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' RefreshOpener
                Page.RegisterClientScriptBlock("RefreshOpener", "<script language = 'javascript'>opener.document.location.href='WContractDetail.aspx?isContract=1&ContractID=" & hidContractID.Value & "'; self.close();</script>")
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
                Call objBAccount.Dispose(True)
                Call objBPO.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace