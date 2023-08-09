' Class: WContractDetail
' Purpose: Show detail information of the selected contract
' Creator: Oanhtn
' CreatedDate: 31/03/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.WebUI

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPODetail
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
        Private objBPO As New clsBPurchaseOrder
        Private objBVendor As New clsBVendor
        Private objBCB As New clsBCommonBusiness
        Private objBAccounting As New clsBAccounting

        Dim intPoType As Integer = 0
        Private intContractID As Integer
        Private intPOS As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Page.IsPostBack Or Not txbFunc.Value = "" Then
                Call BindData()
            End If
            Call BindJavascript()
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

        ' BindJavascript method
        ' Purpose: include all neccessary objects
        Private Sub BindJavascript()
            ddlCurrency.Attributes.Add("OnChange", "document.forms[0].txbFixedRate.value=document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.selectedIndex].value;")
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        ' BindData method
        ' Purpose: loadform
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intIndex As Integer
            Dim dblDiscount As Double = 0
            Dim intStatus As Integer
            Dim dblTotalReal As Long = 0
            Dim dblTotalPlan As Long = 0
            Dim strCurrencyOfPo As String = ""

            ' Get position of record
            If Not Request("POS") = "" Then
                txbPOS.Value = Request("POS")
            Else
                txbPOS.Value = 1
            End If
            intPOS = Request("POS")

            ' Get list of vendors
            tblTemp = objBVendor.GetVendor
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlVendor.DataSource = tblTemp
                    ddlVendor.DataTextField = "Name"
                    ddlVendor.DataValueField = "ID"
                    ddlVendor.DataBind()
                    tblTemp.Clear()
                End If
            End If

            ' Get list of vendors
            tblTemp = objBCB.GetCurrency
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlCurrency.DataSource = tblTemp
                    ddlCurrency.DataTextField = "CurrencyCode"
                    ddlCurrency.DataValueField = "Rate"
                    ddlCurrency.DataBind()
                    tblTemp.Clear()
                End If
            End If

            ' Get list of acqstatus
            tblTemp = objBCB.GetAcqStatus
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlStatus.DataSource = tblTemp
                    ddlStatus.DataTextField = "Status"
                    ddlStatus.DataValueField = "ID"
                    ddlStatus.DataBind()
                    tblTemp.Clear()
                End If
            End If

            ' Get information of the selected contract
            If Not Session("FilterIDs") Is Nothing Then
                intContractID = Session("FilterIDs")(intPOS - 1)
            Else
                If Not Request("ContractID") = "" Then
                    intContractID = CInt(Request("ContractID"))
                Else
                    intContractID = objBPO.GetContractID(intPOS)
                End If
            End If
            intContractID = Request("POS")
            txbContractID.Value = Request("POS")

            objBPO.LibID = clsSession.GlbSite
            objBPO.AcqPOID = Request("POS")
            tblTemp = objBPO.GetPO("")

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    txbReceiptNo.Text = Trim(tblTemp.Rows(0).Item("ReceiptNo"))
                    txbPOName.Text = Trim(tblTemp.Rows(0).Item("POName"))
                    txbFixedRate.Text = Trim(tblTemp.Rows(0).Item("FixedRate"))
                    txbFixedRate.Text = If(Not (txbFixedRate.Text = "0"), CDbl(txbFixedRate.Text).ToString("#,##"), "0")
                    If Not IsDBNull(tblTemp.Rows(0).Item("VALIDDATE")) Then
                        txbValidDate.Text = Trim(tblTemp.Rows(0).Item("VALIDDATE"))
                    End If

                    intStatus = CInt(Trim(tblTemp.Rows(0).Item("StatusID")))
                    For intIndex = 0 To ddlStatus.Items.Count - 1
                        If CInt(ddlStatus.Items(intIndex).Value) = intStatus Then
                            ddlStatus.SelectedIndex = intIndex
                            Exit For
                        End If
                    Next

                    If Not tblTemp.Rows(0).Item("Currency") Is Nothing AndAlso Not IsDBNull(tblTemp.Rows(0).Item("Currency")) Then
                        Dim strCurrency As String = Trim(tblTemp.Rows(0).Item("Currency"))
                        For intIndex = 0 To ddlCurrency.Items.Count - 1
                            If ddlCurrency.Items(intIndex).Text = strCurrency Then
                                ddlCurrency.SelectedIndex = intIndex
                                Exit For
                            End If
                        Next

                    End If

                    Dim intVendorID As Integer = CInt(tblTemp.Rows(0).Item("VendorID"))
                    For intIndex = 0 To ddlVendor.Items.Count - 1
                        If CInt(ddlVendor.Items(intIndex).Value) = intVendorID Then
                            ddlVendor.SelectedIndex = intIndex
                            Exit For
                        End If
                    Next

                    If Not IsDBNull(tblTemp.Rows(0).Item("FILLEDDATE")) Then
                        txbFilledDate.Text = Trim(tblTemp.Rows(0).Item("FILLEDDATE"))
                    End If

                    If Not IsDBNull(tblTemp.Rows(0).Item("TotalAmount")) Then
                        txbTotalAmount.Text = Trim(tblTemp.Rows(0).Item("TotalAmount"))
                        txbTotalAmount.Text = If(Not (txbTotalAmount.Text = "0"), CDbl(txbTotalAmount.Text).ToString("#,##"), "0")
                    End If

                    If Not IsDBNull(tblTemp.Rows(0).Item("PrepaidAmount")) Then
                        txbPrepaidAmount.Text = Trim(tblTemp.Rows(0).Item("PrepaidAmount"))
                        txbPrepaidAmount.Text = If(Not (txbPrepaidAmount.Text = "0"), CDbl(txbPrepaidAmount.Text).ToString("#,##"), "0")
                    End If

                    If Not IsDBNull(tblTemp.Rows(0).Item("StatusNote")) Then
                        txbNote.Text = Trim(tblTemp.Rows(0).Item("StatusNote"))
                    End If

                    If Not IsDBNull(tblTemp.Rows(0).Item("Discount")) Then
                        txbDiscount.Text = Trim(tblTemp.Rows(0).Item("Discount"))
                        txbDiscount.Text = If(Not (txbDiscount.Text = "0"), CDbl(txbDiscount.Text).ToString("#,##"), "0")
                        dblDiscount = CDbl(tblTemp.Rows(0).Item("Discount"))
                    End If

                    If CInt(tblTemp.Rows(0).Item("POType")) = 0 Then
                        lblMainTitle.Text = ddlLabel.Items(3).Text
                    Else
                        txbPoType.Value = 1
                        lblMainTitle.Text = ddlLabel.Items(2).Text
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
                    txbRealAmount.Text = Trim(Str(CLng(dblTotalReal)))
                    txbRealAmount.Text = If(Not (txbRealAmount.Text = "0"), CDbl(txbRealAmount.Text).ToString("#,##"), "0")

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
                    txbPlanAmount.Text = Trim(Str(CLng(dblTotalPlan)))
                    txbPlanAmount.Text = If(Not (txbPlanAmount.Text = "0"), CDbl(txbPlanAmount.Text).ToString("#,##"), "0")
                End If
            End If

            ' Show selected items of this contract
            tblTemp = objBPO.GetOrderedItems
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    Call ShowListOfItem(tblTemp, dblDiscount, intStatus)
                End If
            End If

            ' Show status
            tblTemp = objBPO.GetStatusLog

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgStatus.DataSource = tblTemp
                    dtgStatus.DataBind()
                End If
            End If

            ' Show financial information
            Dim strAmount As String = ""
            Dim strExchangeRate As String = ""
            tblTemp = objBPO.GetFinacialInfor
            tblTemp.Columns.Add("AmountTmp")
            tblTemp.Columns.Add("ExchangeRateTmp")
            For intIndex = 0 To tblTemp.Rows.Count - 1
                strAmount = tblTemp.Rows(intIndex).Item("Amount") & ""
                tblTemp.Rows(intIndex).Item("AmountTmp") = If(Not (strAmount = "0"), CDbl(strAmount).ToString("#,##"), "0").ToString()
                strExchangeRate = tblTemp.Rows(intIndex).Item("ExchangeRate") & ""
                tblTemp.Rows(intIndex).Item("ExchangeRateTmp") = If(Not (strExchangeRate = "0"), CDbl(strExchangeRate).ToString("#,##"), "0").ToString()
            Next

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgAccount.DataSource = tblTemp
                    dtgAccount.DataBind()
                End If
            End If

            If Not tblTemp Is Nothing Then
                tblTemp = Nothing
            End If

            If Not txbFunc.Value = "" Then
                txbFunc.Value = ""
            End If
        End Sub

        ' ShowListOfItem method
        ' Purpose: Show list items of contract
        Private Sub ShowListOfItem(ByVal tblData As DataTable, ByVal dblDiscount As Double, ByVal intStatusID As Integer)
            Dim tblRow As TableRow
            Dim tblCell As TableCell
            Dim chkTemp As CheckBox
            Dim lblTemp As Label
            Dim intIndex As Integer
            Dim dblSumAmount1 As Double = 0
            Dim dblSumAmount2 As Double = 0
            Dim intTotalReqCopies As Integer = 0
            Dim intTotalRecCopies As Integer = 0

            ' Show header
            tblRow = New TableRow
            tblRow.CssClass = "lbGridHeader"

            ' Select column
            tblCell = New TableCell
            tblCell.Width = Unit.Percentage(5)
            tblRow.Controls.Add(tblCell)

            ' Title column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(7).Text
            tblCell.Controls.Add(lblTemp)
            tblRow.Controls.Add(tblCell)

            ' ItemType column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(8).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(8)
            tblRow.Controls.Add(tblCell)

            ' Medium column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(9).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(8)
            tblRow.Controls.Add(tblCell)

            ' Price Unit column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(10).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(7)
            tblRow.Controls.Add(tblCell)

            ' RequestedCopies column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(11).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(8)
            tblRow.Controls.Add(tblCell)

            ' Price column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(12).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(10)
            tblRow.Controls.Add(tblCell)

            ' ReceivedCopies column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(13).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(8)
            tblRow.Controls.Add(tblCell)

            ' PaidAmount column
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(14).Text
            tblCell.Controls.Add(lblTemp)
            tblCell.Width = Unit.Percentage(9)
            tblRow.Controls.Add(tblCell)

            ' Add this column to this row
            tblItemInfor.Rows.Add(tblRow)

            ' Show content
            For intIndex = 0 To tblData.Rows.Count - 1
                ' New row
                tblRow = New TableRow
                If (intIndex Mod 2) = 1 Then
                    tblRow.CssClass = "lbGridCell"
                Else
                    tblRow.CssClass = "lbGridAlterCell"
                End If

                tblCell = New TableCell
                If intStatusID < 3 Then
                    chkTemp = New CheckBox
                    chkTemp.Attributes.Add("OnClick", "if (this.checked) {AddThis('" & tblData.Rows(intIndex).Item("ID") & "');} else {RemoveThis('" & tblData.Rows(intIndex).Item("ID") & "');}")
                    tblCell.Controls.Add(chkTemp)
                    tblCell.HorizontalAlign = HorizontalAlign.Center
                End If
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
                lblTemp.Text = tblData.Rows(intIndex).Item("ItemType")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblRow.Controls.Add(tblCell)

                ' Medium column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = tblData.Rows(intIndex).Item("Medium")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Center
                tblRow.Controls.Add(tblCell)

                ' UnitPrice column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = tblData.Rows(intIndex).Item("UnitPrice")
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' RequestedCopies column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = tblData.Rows(intIndex).Item("RequestedCopies")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Amount1 column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = tblData.Rows(intIndex).Item("Amount1")
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' ReceivedCopies column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = tblData.Rows(intIndex).Item("ReceivedCopies")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Amount2 column
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = tblData.Rows(intIndex).Item("Amount2")
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.CssClass = "lbLabel"
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                dblSumAmount1 = dblSumAmount1 + CDbl(tblData.Rows(intIndex).Item("Amount1"))
                dblSumAmount2 = dblSumAmount2 + CDbl(tblData.Rows(intIndex).Item("Amount2"))
                intTotalReqCopies = intTotalReqCopies + CInt(tblData.Rows(intIndex).Item("RequestedCopies"))
                intTotalRecCopies = intTotalRecCopies + CInt(tblData.Rows(intIndex).Item("ReceivedCopies"))

                ' Add this row to table
                tblItemInfor.Rows.Add(tblRow)
            Next

            ' Show sumary amount row
            tblRow = New TableRow
            tblRow.CssClass = "lbGridHeader"
            tblCell = New TableCell
            lblTemp = New Label
            lblTemp.Text = ddlLabel.Items(15).Text
            lblTemp.Font.Bold = True
            tblCell.Controls.Add(lblTemp)
            tblCell.ColumnSpan = 5
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
                tblRow.CssClass = "lbGridHeader"
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Font.Bold = True
                lblTemp.Text = ddlLabel.Items(16).Text
                tblCell.Controls.Add(lblTemp)
                tblCell.ColumnSpan = 5
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Sumary TotalReqCopies
                tblCell = New TableCell
                tblRow.Controls.Add(tblCell)

                ' Sumary amount1
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = dblSumAmount1 * dblDiscount / 100
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
                lblTemp.Text = dblSumAmount2 * dblDiscount / 100
                lblTemp.Text = If(Not (lblTemp.Text = "0"), CDbl(lblTemp.Text).ToString("#,##"), "0")
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.HorizontalAlign = HorizontalAlign.Right
                tblRow.Controls.Add(tblCell)

                ' Add this row to table
                tblItemInfor.Rows.Add(tblRow)

                ' Show sumary (real) amount
                tblRow = New TableRow
                tblRow.CssClass = "lbGridHeader"
                tblCell = New TableCell
                lblTemp = New Label
                lblTemp.Text = ddlLabel.Items(17).Text
                lblTemp.Font.Bold = True
                tblCell.Controls.Add(lblTemp)
                tblCell.ColumnSpan = 5
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
                lblTemp.Text = dblSumAmount1 * (100 - dblDiscount) / 100
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
                lblTemp.Text = dblSumAmount2 * (100 - dblDiscount) / 100
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
    End Class
End Namespace