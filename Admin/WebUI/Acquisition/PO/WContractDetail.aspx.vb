' Class: WContractDetail
' Purpose: Show detail information of the selected contract
' Creator: Oanhtn
' CreatedDate: 31/03/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI.Acquisition
Imports eMicLibAdmin.WebUI.Common
Imports System.Math

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractDetail
        Inherits clsWBase
        'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblItem As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPO As New clsBPurchaseOrder
        Private objBVendor As New clsBVendor
        Private objBCB As New clsBCommonBusiness
        Private objBAccounting As New clsBAccounting

        Dim intPoType As Integer = 0
        Private intContractID As Integer
        Private intPOS As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim ScriptManager As ScriptManager = ScriptManager.GetCurrent(Me.Page)
            ScriptManager.RegisterPostBackControl(Me.ddlCurrency)
            ScriptManager.RegisterPostBackControl(Me.ddlStatus)
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Or Not txbFunc.Value = "" Then
                Call BindData()
            End If
            Call BindAttribute()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check form permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(136) Then
                Call WriteErrorMssg(ddlLabel.Items(19).Text)
            End If
            'Them moi NCC
            If Not CheckPemission(34) Then
                btnAddVendor.Enabled = False
            End If
            'Khieu nai
            If Not CheckPemission(42) Then
                btnClaim.Enabled = False
            End If
            'Phan kho
            If Not CheckPemission(135) Then
                btnStored.Enabled = False
            End If
            'Khai bao chi
            If Not CheckPemission(107) Then
                btnLiquidateInform.Enabled = False
            End If
            'Khang dinh chi
            If Not CheckPemission(108) Then
                btnLiquidate.Enabled = False
            End If
            'Hoan quy
            If Not CheckPemission(109) Then
                btnToBudget.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all objects
        Private Sub Initialize()
            ' Init objBPO object
            objBPO.InterfaceLanguage = Session("InterfaceLanguage")
            objBPO.DBServer = Session("DBServer")
            objBPO.ConnectionString = Session("ConnectionString")
            Call objBPO.Initialize()

            ' Init objBVendor object
            objBVendor.InterfaceLanguage = Session("InterfaceLanguage")
            objBVendor.DBServer = Session("DBServer")
            objBVendor.ConnectionString = Session("ConnectionString")
            Call objBVendor.Initialize()

            ' Init objBCB object
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            ' Init objBAccounting object
            objBAccounting.InterfaceLanguage = Session("InterfaceLanguage")
            objBAccounting.DBServer = Session("DBServer")
            objBAccounting.ConnectionString = Session("ConnectionString")
            Call objBAccounting.Initialize()
        End Sub

        Public Function GetPoId() As String
            'quocDD
            ' Get Po by number row 
            objBPO.AcqPOID = txbContractID.Value
            objBPO.LibID = clsSession.GlbSite
            Dim tblTemp As DataTable
            tblTemp = objBPO.GetPO("")
            Dim PoID = 0
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                PoID = tblTemp.Rows(0).Item("Id").ToString()
                ' set id for AcqPo again
                objBPO.AcqPOID = PoID

            End If
            Return PoID
        End Function

        ' BindJavascript method
        ' Purpose: include all neccessary objects
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ContractJs", "<script language = 'javascript' src = '../Js/PO/WContract.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkValidDate, txbValidDate, ddlLabel.Items(21).Text)
            SetOnclickCalendar(lnkFilledDate, txbFilledDate, ddlLabel.Items(21).Text)

            'Me.SetCheckNumber(txbTotalAmount, ddlLabel.Items(20).Text)
            'Me.SetCheckNumber(txbFixedRate, ddlLabel.Items(20).Text)
            'Me.SetCheckNumber(txbPrepaidAmount, ddlLabel.Items(20).Text)
            'Me.SetCheckNumber(txbDiscount, ddlLabel.Items(20).Text)
            'Me.SetCheckNumber(txbRealAmount, ddlLabel.Items(20).Text)
            'Me.SetCheckNumber(txbPlanAmount, ddlLabel.Items(20).Text)
            'txbPlanAmount.Attributes.Add("disabled", "disabled")
            'txbRealAmount.Attributes.Add("disabled", "disabled")
            'txbFixedRate.Attributes.Add("disabled", "disabled")

            ''ddlCurrency.Attributes.Add("OnChange", "document.forms[0].txbFixedRate.value=document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.selectedIndex].value;")
            'btnUpdate.Attributes.Add("OnClick", "return (CheckAll('" & ddlLabel.Items(26).Text & "'));")
            'btnPickItems.Attributes.Add("OnClick", "OpenWindow('WContractPickItems.aspx?ContractID=" & GetPoId() & "&TypeID=" & txbPoType.Value & "','WPickItems',700,370,30,30); return false;")
            'btnPrint.Attributes.Add("Onclick", "self.location.href='WSendPOSearch.aspx?ContractID=" & GetPoId() & "'; return false;")
            'btnInventory.Attributes.Add("OnClick", "self.location.href='WCheckingReceived.aspx?ContractID=" & GetPoId() & "'; return false;")
            'btnClaim.Attributes.Add("OnClick", "self.location.href='WSendPOClaimSearch.aspx?ContractID=" & GetPoId() & "'; return false;")
            'btnStored.Attributes.Add("OnClick", "self.location.href='WSendPOSeperatedSearch.aspx?POID=" & GetPoId() & "'; return false;")

            'btnVendorDetail.Attributes.Add("onClick", "OpenWindow('WViewDetailPObyVendor.aspx?VendorID='+document.forms[0].ddlVendor.options[document.forms[0].ddlVendor.options.selectedIndex].value + '','VendorMan',800,600,50,50); return false;")
            'btnAddVendor.Attributes.Add("onClick", "OpenWindow('WVendorMan.aspx?From=1','VendorMan',800,600,50,50); return false;")

            'btnToBudget.Attributes.Add("OnClick", "OpenWindow('WContractToBudget.aspx?ContractID=" + GetPoId() + "','ToBudget',400,300,50,50); return false;")
            'btnLiquidate.Attributes.Add("OnClick", "OpenWindow('WContractLiquidate.aspx?ContractID=" + GetPoId() + "','Liquidate',650,400,50,50); return false;")
            'btnLiquidateInform.Attributes.Add("OnClick", "OpenWindow('WContractBudgetInfo.aspx?ContractID=" + GetPoId() + "','ToBudget',600,250,50,50); return false;")
            'btnDelete.Attributes.Add("Onclick", "if(!confirm('" & ddlLabel.Items(22).Text & "')) return false;")
        End Sub

        Private Sub BindAttribute()
            txbPlanAmount.Attributes.Add("disabled", "disabled")
            txbRealAmount.Attributes.Add("disabled", "disabled")
            txbFixedRate.Attributes.Add("disabled", "disabled")

            'ddlCurrency.Attributes.Add("OnChange", "document.forms[0].txbFixedRate.value=document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.selectedIndex].value;")
            btnUpdate.Attributes.Add("OnClick", "return (CheckAll('" & ddlLabel.Items(26).Text & "'));")
            btnPickItems.Attributes.Add("OnClick", "OpenWindow('WContractPickItems.aspx?ContractID=" & GetPoId() & "&TypeID=" & txbPoType.Value & "','WPickItems',700,370,30,30); return false;")
            btnPrint.Attributes.Add("Onclick", "self.location.href='WSendPOSearch.aspx?ContractID=" & GetPoId() & "'; return false;")
            btnInventory.Attributes.Add("OnClick", "self.location.href='WCheckingReceived.aspx?ContractID=" & GetPoId() & "'; return false;")
            btnClaim.Attributes.Add("OnClick", "self.location.href='WSendPOClaimSearch.aspx?ContractID=" & GetPoId() & "'; return false;")
            btnStored.Attributes.Add("OnClick", "self.location.href='WSendPOSeperatedSearch.aspx?POID=" & GetPoId() & "'; return false;")

            btnVendorDetail.Attributes.Add("onClick", "OpenWindow('WViewDetailPObyVendor.aspx?VendorID='+document.forms[0].ddlVendor.options[document.forms[0].ddlVendor.options.selectedIndex].value + '','VendorMan',800,600,50,50); return false;")
            btnAddVendor.Attributes.Add("onClick", "OpenWindow('WVendorMan.aspx?From=1','VendorMan',800,600,50,50); return false;")

            btnToBudget.Attributes.Add("OnClick", "OpenWindow('WContractToBudget.aspx?ContractID=" + GetPoId() + "','ToBudget',400,300,50,50); return false;")
            btnLiquidate.Attributes.Add("OnClick", "OpenWindow('WContractLiquidate.aspx?ContractID=" + GetPoId() + "','Liquidate',650,400,50,50); return false;")
            btnLiquidateInform.Attributes.Add("OnClick", "OpenWindow('WContractBudgetInfo.aspx?ContractID=" + GetPoId() + "','ToBudget',600,250,50,50); return false;")
            btnDelete.Attributes.Add("Onclick", "if(!confirm('" & ddlLabel.Items(22).Text & "')) return false;")
        End Sub

        ' BindData method
        ' Purpose: loadform
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intIndex As Integer
            Dim dblDiscount As Long = 0
            Dim intStatus, inti As Integer
            Dim dblTotalReal As Long = 0
            Dim dblTotalPlan As Long = 0
            Dim strCurrencyOfPo As String = ""

            btnCheckAll.Visible = False
            btnUnCheckAll.Visible = False
            ' Get position of record
            If Not Request("POS") = "" Then
                txbPOS.Value = Request("POS")
            Else
                txbPOS.Value = 1
            End If
            intPOS = CInt(txbPOS.Value)

            ' Get list of vendors
            tblTemp = objBVendor.GetVendor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlVendor.DataSource = tblTemp
                ddlVendor.DataTextField = "Name"
                ddlVendor.DataValueField = "ID"
                ddlVendor.DataBind()
                tblTemp.Clear()
            End If

            ' Get list of vendors
            tblTemp = objBCB.GetCurrency
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlCurrency.DataSource = tblTemp
                ddlCurrency.DataTextField = "CurrencyCode"
                ddlCurrency.DataValueField = "ID"
                ddlCurrency.DataBind()
                tblTemp.Clear()
            End If

            ' Get list of acqstatus
            Dim i As Integer
            tblTemp = objBCB.GetAcqStatus
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlStatus.DataSource = tblTemp
                ddlStatus.DataTextField = "Status"
                ddlStatus.DataValueField = "ID"
                ddlStatus.DataBind()
                tblTemp.Clear()
            End If

            ' Get information of the selected contract
            If Not Session("FilterIDs") Is Nothing Then
                'intContractID = Session("FilterIDs")(intPOS - 1)
                intContractID = Session("FilterIDs")(CInt(txbPOS.Value) - 1)
            Else
                If Not Request("ContractID") = "" Then
                    intContractID = CInt(Request("ContractID"))
                Else
                    objBPO.LibID = clsSession.GlbSite
                    intContractID = objBPO.GetContractID(CInt(txbPOS.Value))
                End If
            End If

            txbContractID.Value = intContractID

            objBPO.AcqPOID = intContractID
            objBPO.LibID = clsSession.GlbSite
            tblTemp = objBPO.GetPO("")
            objBPO.AcqPOID = GetPoId()
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strCurrencyOfPo = tblTemp.Rows(0).Item("Currency").ToString()
                txbReceiptNo.Text = tblTemp.Rows(0).Item("ReceiptNo").ToString.Trim
                txbPOName.Text = tblTemp.Rows(0).Item("POName").ToString.Trim
                txbFixedRate.Text = Round(tblTemp.Rows(0).Item("FixedRate")).ToString.Trim
                If Not IsDBNull(tblTemp.Rows(0).Item("VALIDDATE")) Then
                    txbValidDate.Text = tblTemp.Rows(0).Item("VALIDDATE").ToString.Trim
                End If

                intStatus = CInt(Trim(tblTemp.Rows(0).Item("StatusID")))

                For intIndex = 0 To ddlStatus.Items.Count - 1
                    If CInt(ddlStatus.Items(intIndex).Value) = intStatus Then
                        ddlStatus.SelectedIndex = intIndex
                        Exit For
                    End If
                Next

                Dim strCurrency As String
                If Not IsDBNull(tblTemp.Rows(0).Item("Currency")) Then
                    strCurrency = Trim(tblTemp.Rows(0).Item("Currency"))
                Else
                    strCurrency = ""
                End If
                For intIndex = 0 To ddlCurrency.Items.Count - 1
                    If ddlCurrency.Items(intIndex).Text = strCurrency Then
                        ddlCurrency.SelectedIndex = intIndex
                        Exit For
                    End If
                Next

                Dim intVendorID As Integer
                If Not IsDBNull(tblTemp.Rows(0).Item("VendorID")) Then
                    intVendorID = CInt(tblTemp.Rows(0).Item("VendorID"))
                Else
                    intVendorID = 0
                End If

                For intIndex = 0 To ddlVendor.Items.Count - 1
                    If CInt(ddlVendor.Items(intIndex).Value) = intVendorID Then
                        ddlVendor.SelectedIndex = intIndex
                        Exit For
                    End If
                Next

                txbFilledDate.Text = tblTemp.Rows(0).Item("FILLEDDATE").ToString.Trim
                txbTotalAmount.Text = Round(tblTemp.Rows(0).Item("TotalAmount")).ToString.Trim
                txbTotalAmount.Text = If(Not (txbTotalAmount.Text = "0"), CDbl(txbTotalAmount.Text).ToString("#,##"), "0")
                txbPrepaidAmount.Text = Round(tblTemp.Rows(0).Item("PrepaidAmount")).ToString.Trim
                txbPrepaidAmount.Text = If(Not (txbPrepaidAmount.Text = "0"), CDbl(txbPrepaidAmount.Text).ToString("#,##"), "0")
                txbNote.Text = tblTemp.Rows(0).Item("StatusNote").ToString.Trim
                txbDiscount.Text = Round(tblTemp.Rows(0).Item("Discount")).ToString.Trim
                txbDiscount.Text = If(Not (txbDiscount.Text = "0"), CDbl(txbDiscount.Text).ToString("#,##"), "0")
                If Not IsDBNull(tblTemp.Rows(0).Item("Discount")) Then
                    If IsNumeric(tblTemp.Rows(0).Item("Discount")) Then
                        dblDiscount = CLng(tblTemp.Rows(0).Item("Discount").ToString.Trim)
                    End If
                End If
                If CInt(tblTemp.Rows(0).Item("POType")) = 1 Then
                    lblMainTitle.Text = ddlLabel.Items(2).Text
                    txbPoType.Value = 1
                Else
                    txbPoType.Value = 0
                    lblMainTitle.Text = ddlLabel.Items(3).Text
                End If
            End If

            'Tinh tong thuc chi cho don dat:
            objBAccounting.PoID = GetPoId()
            tblTemp = objBAccounting.GetDebitAmount(1)
            If Not tblTemp Is Nothing Then
                For intIndex = 0 To tblTemp.Rows.Count - 1
                    If strCurrencyOfPo = CStr(tblTemp.Rows(intIndex).Item("ExchangeRate")) Then
                        dblTotalReal = dblTotalReal + CLng(tblTemp.Rows(intIndex).Item("Amount")) * CLng(tblTemp.Rows(intIndex).Item("ExchangeRate"))
                    Else
                        dblTotalReal = dblTotalReal + CLng(tblTemp.Rows(intIndex).Item("Amount"))
                    End If
                Next
                tblTemp.Clear()
            End If

            'Tinh tong du chi cho don dat:
            objBAccounting.PoID = GetPoId()
            tblTemp = objBAccounting.GetDebitAmount(0)
            If Not tblTemp Is Nothing Then
                For intIndex = 0 To tblTemp.Rows.Count - 1
                    If strCurrencyOfPo = CStr(tblTemp.Rows(intIndex).Item("ExchangeRate")) Then
                        dblTotalPlan = dblTotalPlan + CLng(tblTemp.Rows(intIndex).Item("Amount")) * CLng(tblTemp.Rows(intIndex).Item("ExchangeRate"))
                    Else
                        dblTotalPlan = dblTotalPlan + CLng(tblTemp.Rows(intIndex).Item("Amount"))
                    End If
                Next
                tblTemp.Clear()
            End If

            'txbPlanAmount.Text = Trim(Str(CLng(dblTotalPlan)))
            'txbPlanAmount.Text = If(Not (txbPlanAmount.Text = "0"), CDbl(txbPlanAmount.Text).ToString("#,##"), "0")

            txbPlanAmount.Text = CDbl(txbTotalAmount.Text)
            txbPlanAmount.Text = If(Not (txbPlanAmount.Text = "0"), CDbl(txbPlanAmount.Text).ToString("#,##"), "0")

            'txbRealAmount.Text = Trim(Str(CLng(dblTotalReal)))
            'txbRealAmount.Text = If(Not (txbRealAmount.Text = "0"), CDbl(txbRealAmount.Text).ToString("#,##"), "0")

            'txbRealAmount.Text = CDbl(txbPrepaidAmount.Text) - CDbl(txbDiscount.Text)
            'txbRealAmount.Text = (CDbl(txbTotalAmount.Text) * CDbl(txbFixedRate.Text)) - (CDbl(txbDiscount.Text) * CDbl(txbFixedRate.Text))
            txbRealAmount.Text = CDbl(txbTotalAmount.Text) - (CDbl(txbTotalAmount.Text) * CDbl(txbDiscount.Text) / 100)
            txbRealAmount.Text = If(Not (txbRealAmount.Text = "0"), CDbl(txbRealAmount.Text).ToString("#,##"), "0")


            ' Show selected items of this contract
            tblTemp = objBPO.GetOrderedItems
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                btnRemoveItems.Visible = True
                btnCheckAll.Visible = True
                btnUnCheckAll.Visible = True
                Call ShowListOfItem(tblTemp, dblDiscount, intStatus)
                btnRemoveItems.Visible = True
                btnPickItems.Visible = True
                'An nut xoa an pham trong don dat neu don dat chua co an pham nao
            Else
                btnRemoveItems.Visible = False
            End If

            ' Show status
            tblTemp = objBPO.GetStatusLog

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                'An nut Chon an pham vao don dat khi don dat da hoan thanh
                For i = 0 To tblTemp.Rows.Count - 1
                    If tblTemp.Rows(i).Item("ID") > 1 Then
                        btnRemoveItems.Visible = False
                        btnPickItems.Visible = False
                        Exit For
                    End If
                Next
                dtgStatus.DataSource = tblTemp
                dtgStatus.DataBind()
            End If

            ' Show financial information
            tblTemp = objBPO.GetFinacialInfor(ddlLabel.Items(23).Text, ddlLabel.Items(24).Text, ddlLabel.Items(25).Text)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                dtgAccount.DataSource = tblTemp
                dtgAccount.DataBind()
            End If

            If Not txbFunc.Value = "" Then
                txbFunc.Value = ""
            End If
            tblTemp = Nothing
        End Sub

        ' ShowListOfItem method
        ' Purpose: Show list items of contract
        Private Sub ShowListOfItem(ByVal tblData As DataTable, ByVal dblDiscount As Long, ByVal intStatusID As Integer)
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim chkTemp As CheckBox
            Dim lblTemp As Label
            Dim intIndex As Integer
            Dim dblSumAmount1 As Long = 0
            Dim dblSumAmount2 As Long = 0
            Dim intTotalReqCopies As Integer = 0
            Dim intTotalRecCopies As Integer = 0

            ' Show header
            tblRow = New TableRow
            tblRow.CssClass = "lbGridHeader row-head"

            ' Select column
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(4)
            tblCell.HorizontalAlign = HorizontalAlign.Center
            tblRow.Controls.Add(tblCell)
            'Dim chkCheckAll As New  CheckBox
            'chkCheckAll.ID = "chkCheckAll"
            'chkCheckAll.Text="&nbsp;"
            'chkCheckAll.CssClass="lbCheckBox"
            'tblCell.Controls.Add(chkCheckAll)

            ' STT column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(27).Text
            tblCell.Width = Unit.Percentage(5)
            tblCell.HorizontalAlign = HorizontalAlign.Center
            tblCell.Controls.Add(lblTemp)
            tblRow.Controls.Add(tblCell)

            ' Title column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(7).Text
            tblCell.Width = Unit.Percentage(16)
            tblCell.Controls.Add(lblTemp)
            tblRow.Controls.Add(tblCell)

            ' ItemType column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(8).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(10)
            tblRow.Controls.Add(tblCell)

            ' Medium column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(9).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(10)
            tblRow.Controls.Add(tblCell)

            ' Price Unit column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(10).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(12)
            tblRow.Controls.Add(tblCell)

            ' RequestedCopies column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(11).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(12)
            tblRow.Controls.Add(tblCell)

            ' Price column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(12).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(12)
            tblRow.Controls.Add(tblCell)

            ' ReceivedCopies column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(13).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(12)
            tblRow.Controls.Add(tblCell)

            ' PaidAmount column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(14).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(12)
            tblRow.Controls.Add(tblCell)

            ' Add this column to this row
            tblItemInfor.Rows.Add(tblRow)

            ' Show content
            For intIndex = 0 To tblData.Rows.Count - 1
                ' New row
                tblRow = New TableRow
                If (intIndex Mod 2) = 1 Then
                    tblRow.CssClass = "lbGridCell row-second"
                Else
                    tblRow.CssClass = "lbGridAlterCell"
                End If

                tblCell = New TableCell
                If intStatusID < 3 Then
                    chkTemp = New CheckBox
                    chkTemp.ID = "ck" + tblData.Rows(intIndex).Item("ID").ToString()
                    chkTemp.Attributes.Add("OnClick", "if (this.checked) {AddThis('" & tblData.Rows(intIndex).Item("ID") & "');} else {RemoveThis('" & tblData.Rows(intIndex).Item("ID") & "');}")
                    tblCell.Controls.Add(chkTemp)

                    lblTemp = New Label
                    lblTemp.Attributes.Add("for", "ck" & tblData.Rows(intIndex).Item("ID").ToString() & "")
                    tblCell.Controls.Add(lblTemp)
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                End If
                tblRow.Controls.Add(tblCell)

                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = intIndex + 1
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblRow.Controls.Add(tblCell)

                Dim strTitle As String

                strTitle = Trim(tblData.Rows(intIndex).Item("Title"))

                If Not IsDBNull(tblData.Rows(intIndex).Item("Author")) Then
                    strTitle = strTitle & " /" & Trim(tblData.Rows(intIndex).Item("Author"))
                End If
                If Not IsDBNull(tblData.Rows(intIndex).Item("Edition")) Then
                    strTitle = strTitle & ". -" & Trim(tblData.Rows(intIndex).Item("Edition"))
                End If
                If Not IsDBNull(tblData.Rows(intIndex).Item("Publisher")) Then
                    strTitle = strTitle & ". -" & Trim(tblData.Rows(intIndex).Item("Publisher"))
                End If
                If Not IsDBNull(tblData.Rows(intIndex).Item("PubYear")) Then
                    strTitle = strTitle & " , " & Trim(tblData.Rows(intIndex).Item("PubYear"))
                End If
                If Not IsDBNull(tblData.Rows(intIndex).Item("ISBN")) Then
                    strTitle = strTitle & "<BR>" & Trim(tblData.Rows(intIndex).Item("ISBN"))
                End If
                If Not IsDBNull(tblData.Rows(intIndex).Item("ISSN")) Then
                    strTitle = strTitle & "<BR>" & Trim(tblData.Rows(intIndex).Item("ISSN"))
                End If

                ' Title column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = strTitle
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblRow.Controls.Add(tblCell)

                ' ItemType column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = Trim(tblData.Rows(intIndex).Item("ItemType") & "")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblRow.Controls.Add(tblCell)

                ' Medium column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = Trim(tblData.Rows(intIndex).Item("Medium") & "")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblRow.Controls.Add(tblCell)

                ' UnitPrice column
                tblCell = New TableCell
                lblTemp = New Label
                'lblTemp.Text = Trim(Round(tblData.Rows(intIndex).Item("UnitPrice")) & "")
                lblTemp.Text = Trim(Round(tblData.Rows(intIndex).Item("Price")) & "")
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' RequestedCopies column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = Trim(tblData.Rows(intIndex).Item("RequestedCopies") & "")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Amount1 column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = CLng(tblData.Rows(intIndex).Item("Amount1"))
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' ReceivedCopies column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = Trim(tblData.Rows(intIndex).Item("ReceivedCopies") & "")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Amount2 column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = CLng(tblData.Rows(intIndex).Item("Amount2"))
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                dblSumAmount1 = dblSumAmount1 + CLng(tblData.Rows(intIndex).Item("Amount1"))
                dblSumAmount2 = dblSumAmount2 + CLng(tblData.Rows(intIndex).Item("Amount2"))
                intTotalReqCopies = intTotalReqCopies + CInt(tblData.Rows(intIndex).Item("RequestedCopies"))
                intTotalRecCopies = intTotalRecCopies + CInt(tblData.Rows(intIndex).Item("ReceivedCopies"))

                ' Add this row to table
                tblItemInfor.Rows.Add(tblRow)
            Next

            ' Show sumary amount row
            tblRow = New TableRow
            tblRow.CssClass = "row-total"
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(15).Text
            lblTemp.Font.Bold = True
            tblCell.Controls.Add(lblTemp)
            tblCell.ColumnSpan = 6
            tblCell.HorizontalAlign = HorizontalAlign.Right
            tblRow.Controls.Add(tblCell)

            ' Sumary TotalReqCopies
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = intTotalReqCopies
            lblTemp.Font.Bold = True
            tblCell.Controls.Add(lblTemp)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            tblRow.Controls.Add(tblCell)

            ' Sumary amount1
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = dblSumAmount1
            lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
            lblTemp.Font.Bold = True
            tblCell.Controls.Add(lblTemp)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            tblRow.Controls.Add(tblCell)

            ' Sumary TotalRecCopies
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = intTotalRecCopies
            lblTemp.Font.Bold = True
            tblCell.Controls.Add(lblTemp)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            tblRow.Controls.Add(tblCell)

            ' Sumary amount2
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = dblSumAmount2
            lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
            lblTemp.Font.Bold = True
            tblCell.Controls.Add(lblTemp)
            tblCell.HorizontalAlign = HorizontalAlign.Right
            tblRow.Controls.Add(tblCell)

            ' Add this row to table
            tblItemInfor.Rows.Add(tblRow)

            If dblDiscount > 0 Then
                ' Show discount amount
                tblRow = New TableRow
                tblRow.CssClass = "lbGridHeader row-head"
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Font.Bold = True
                lblTemp.Text = ddlLabel.Items(16).Text
                tblCell.Controls.Add(lblTemp)
                tblCell.ColumnSpan = 6
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Sumary TotalReqCopies
                tblCell = New TableCell
                tblRow.Controls.Add(tblCell)

                ' Sumary amount1
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = CLng(dblSumAmount1 * dblDiscount / 100)
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Sumary TotalRecCopies
                tblCell = New TableCell
                tblRow.Controls.Add(tblCell)

                ' Sumary amount2
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = CLng(dblSumAmount2 * dblDiscount / 100)
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Add this row to table
                tblItemInfor.Rows.Add(tblRow)

                ' Show sumary (real) amount
                tblRow = New TableRow
                tblRow.CssClass = "lbGridHeader row-head"
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = ddlLabel.Items(17).Text
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.ColumnSpan = 6
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Sumary TotalReqCopies
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = intTotalReqCopies
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Sumary amount1
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = CLng(dblSumAmount1 * (100 - dblDiscount) / 100)
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Sumary TotalRecCopies
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = intTotalRecCopies
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Sumary amount2
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = CLng(dblSumAmount2 * (100 - dblDiscount) / 100)
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Add this row to table
                tblItemInfor.Rows.Add(tblRow)
            End If
            
            tblData.Clear()
        End Sub

        ' btnUpdate_Click event
        ' Purpose: Update selected contract record
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intRetVal As Integer

            objBPO.PoType = txbPoType.Value
            objBPO.AcqPOID = txbContractID.Value
            objBPO.ReceiptNo = txbReceiptNo.Text.Trim()
            objBPO.PoName = txbPOName.Text.Trim
            objBPO.VendorID = ddlVendor.SelectedValue
            objBPO.ValidDate = txbValidDate.Text.Trim
            objBPO.FilledDate = txbFilledDate.Text.Trim
            objBPO.StatusID = ddlStatus.SelectedValue

            If IsNumeric(txbTotalAmount.Text) Then objBPO.TotalAmount = txbTotalAmount.Text.Trim.Replace(".", "")
            If IsNumeric(txbPrepaidAmount.Text) Then objBPO.PrepaidAmount = txbPrepaidAmount.Text.Trim.Replace(".", "")
            If IsNumeric(txbFixedRate.Text) Then objBPO.FixedRate = CDbl(txbFixedRate.Text.Trim.Replace(".", ""))
            If IsNumeric(txbDiscount.Text) Then objBPO.Discount = CDbl(txbDiscount.Text.Trim.Replace(".", "")) 'txbDiscount.Text.Trim
            objBPO.Currency = ddlCurrency.SelectedItem.Text

            intRetVal = objBPO.Update(txbNote.Text.Trim)

            If Not intRetVal = 0 Then ' Exist code 
                Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>" & ddlLabel.Items(6).Text & "</script>")
            Else
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('cập nhật thành công');</script>")

                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(4).Text & ": " & GetPoId(), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
            Call BindData()
        End Sub

        ' btnDelete_Click event
        ' Purpose: delete selected contract record
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim intRetVal As Integer
            objBPO.AcqPOID = txbContractID.Value
            intRetVal = objBPO.Delete()
            If intRetVal = 0 Then ' Delete success
                ClearControlValue()
                Page.RegisterClientScriptBlock("AlterJsDelete", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');parent.taskbar.location.href=parent.taskbar.location.href;</script>")
                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(5).Text & ": " & GetPoId(), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call BindData()
                If Integer.Parse(txbContractID.Value) = 0 Then
                    Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>document.location.href='../../WNothing.aspx';</script>")
                End If
            End If
        End Sub
        Private Sub ClearControlValue()
            txbReceiptNo.Text = ""
            txbPOName.Text = ""
            ddlVendor.SelectedIndex = -1
            txbValidDate.Text = ""
            txbFilledDate.Text = ""
            ddlStatus.SelectedIndex = -1
            txbNote.Text = ""
        End Sub
        ' btnRemoveItems_Click event
        ' Purpose: remove item
        Private Sub btnRemoveItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveItems.Click
            Dim strItemIDs As String = Trim(txbItemIDs.Value)

            If Len(strItemIDs) > 1 Then
                strItemIDs = Left(strItemIDs, Len(strItemIDs) - 1)
                strItemIDs = Right(strItemIDs, Len(strItemIDs) - 1)
                Call objBPO.RemoveItems(strItemIDs)
                txbItemIDs.Value = ","
                ' Writelog
                Call WriteLog(38, ddlLabel.Items(18).Text & ": " & GetPoId(), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                Call objBPO.Dispose(True)
                Call objBVendor.Dispose(True)
                Call objBCB.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub ddlCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCurrency.SelectedIndexChanged
            Dim tblData As DataTable = objBCB.GetCurrencyByID(ddlCurrency.SelectedItem.Value)
            If (Not IsNothing(tblData)) Then
                If tblData.Rows.Count > 0 Then
                    txbFixedRate.Text = tblData.Rows(0).Item("Rate").ToString()
                    txbFixedRate.Text = If(Not (txbFixedRate.Text = "0"), CDbl(txbFixedRate.Text).ToString("#,##"), "0")
                End If
            End If
            Dim dblDiscount As Long = 0
            Dim intStatus As Integer = 0
            objBPO.AcqPOID = txbContractID.Value
            objBPO.LibID = clsSession.GlbSite
            Dim tblTemp As DataTable = objBPO.GetPO("")
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                If Not IsDBNull(tblTemp.Rows(0).Item("Discount")) Then
                    If IsNumeric(tblTemp.Rows(0).Item("Discount")) Then
                        dblDiscount = CLng(tblTemp.Rows(0).Item("Discount").ToString.Trim)

                        intStatus = CInt(Trim(tblTemp.Rows(0).Item("StatusID")))
                    End If
                End If
            End If
            tblTemp = objBPO.GetOrderedItems()
            Call ShowListOfItem(tblTemp, dblDiscount, intStatus)
        End Sub
        Protected Sub ddlStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlStatus.SelectedIndexChanged
            objBPO.AcqPOID = txbContractID.Value
            objBPO.StatusID = ddlStatus.SelectedValue
            Dim tblData As DataTable = objBPO.GetAcqPoStatus
            If (Not IsNothing(tblData)) Then
                If tblData.Rows.Count > 0 Then
                    txbNote.Text = tblData.Rows(0).Item("Note").ToString()
                End If
            End If
            Dim dblDiscount As Long = 0
            Dim intStatus As Integer = 0
            objBPO.AcqPOID = txbContractID.Value
            objBPO.LibID = clsSession.GlbSite
            Dim tblTemp As DataTable = objBPO.GetPO("")
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                If Not IsDBNull(tblTemp.Rows(0).Item("Discount")) Then
                    If IsNumeric(tblTemp.Rows(0).Item("Discount")) Then
                        dblDiscount = CLng(tblTemp.Rows(0).Item("Discount").ToString.Trim)

                        intStatus = CInt(Trim(tblTemp.Rows(0).Item("StatusID")))
                    End If
                End If
            End If
            tblTemp = objBPO.GetOrderedItems()
            Call ShowListOfItem(tblTemp, dblDiscount, intStatus)
        End Sub

    End Class
End Namespace