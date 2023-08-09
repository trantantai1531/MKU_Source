' Class: WContractCreate
' Purpose: Create new contract
' Creator: Oanhtn
' CreatedDate: 30/03/2005
' Modification history:

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WContractCreate
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Or Not txbFunc.Value = "" Then
                Call BindData()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Quan ly don dat
            If Not CheckPemission(136) Then
                btnCreate.Enabled = False
            End If
            ' Them moi NCC
            If Not CheckPemission(34) Then
                btnAddVendor.Enabled = False
            End If
            'Them moi loai tien te
            If Not CheckPemission(184) Then
                btnAddCurrency.Enabled = False
            End If
        End Sub
        ' Initialize method
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
        End Sub

        ' BindJS method
        ' Purpose: include all neccessary objects
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/PO/WContractCreate.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkValidDate, txbValidDate, ddlLabel.Items(6).Text.Trim)
            SetOnclickCalendar(lnkFilledDate, txbFilledDate, ddlLabel.Items(6).Text.Trim)
            Me.SetCheckNumber(txbTotalAmount, ddlLabel.Items(2).Text)
            Me.SetCheckNumber(txbFixedRate, ddlLabel.Items(2).Text)
            Me.SetCheckNumber(txbPrepaidAmount, ddlLabel.Items(2).Text)
            Me.SetCheckNumber(txbDiscount, ddlLabel.Items(2).Text)


            ddlCurrency.Attributes.Add("onchange", "javascript:document.forms[0].txbFixedRate.value=document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.selectedIndex].value;document.forms[0].hidFixedRate.value=document.forms[0].ddlCurrency.options[document.forms[0].ddlCurrency.selectedIndex].value;")
            btnVendorDetail.Attributes.Add("onClick", "OpenWindow('WViewDetailPObyVendor.aspx?VendorID='+document.forms[0].ddlVendor.options[document.forms[0].ddlVendor.options.selectedIndex].value + '','VendorMan',800,600,50,50); return false;")
            btnAddVendor.Attributes.Add("onClick", "OpenWindow('WVendorMan.aspx?From=1','VendorMan',800,600,50,50); return false;")

            ' Need review later
            btnAddCurrency.Attributes.Add("onclick", "OpenWindow('../Accounting/WRate.aspx?Load=1','AddNewCurrency',400,350,100,100); return false;")
            btnCreate.Attributes.Add("OnClick", "return CheckAll('" & ddlLabel.Items(7).Text.Trim & "', '" & Session("DateFormat") & "')")
        End Sub

        ' BindData method
        ' Purpose: loadform
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim inti As Integer
            txbValidDate.Text = Session("ToDay")

            ' Get list of vendors
            tblTemp = objBVendor.GetVendor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlVendor.DataSource = tblTemp
                ddlVendor.DataTextField = "Name"
                ddlVendor.DataValueField = "ID"
                ddlVendor.DataBind()
            End If

            ' Get list of vendors
            tblTemp = Nothing
            tblTemp = objBCB.GetCurrency

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlCurrency.DataSource = tblTemp
                ddlCurrency.DataTextField = "CurrencyCode"
                ddlCurrency.DataValueField = "Rate"
                ddlCurrency.DataBind()
                'For inti = 0 To tblTemp.Rows.Count - 1
                '    If CStr(tblTemp.Rows(inti).Item("CurrencyCode")).ToLower = "vnd" Then
                '        ddlCurrency.SelectedIndex = inti
                '        Exit For
                '    End If
                'Next
            End If

            ' Get list of acqstatus
            tblTemp = Nothing
            tblTemp = objBCB.GetAcqStatus
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                txbStatus.Text = tblTemp.Rows(0).Item("Status")
                tblTemp.Clear()
            End If

            If Not tblTemp Is Nothing Then
                tblTemp = Nothing
            End If

            txbFunc.Value = ""
        End Sub

        ' btnCreate_Click event
        Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click
            Dim intRetVal As Integer
            Dim intPoType As Integer = 0

            If optMonoItem.Checked = True Then
                intPoType = 1
            End If

            objBPO.ReceiptNo = txbReceiptNo.Text.Trim
            objBPO.PoName = txbPOName.Text.Trim
            objBPO.VendorID = ddlVendor.SelectedValue
            objBPO.PoType = intPoType
            objBPO.ValidDate = txbValidDate.Text.Trim
            objBPO.FilledDate = txbFilledDate.Text.Trim
            objBPO.LibID = clsSession.GlbSite
            If IsNumeric(txbTotalAmount.Text) Then objBPO.TotalAmount = txbTotalAmount.Text.Trim
            If IsNumeric(txbPrepaidAmount.Text) Then objBPO.PrepaidAmount = txbPrepaidAmount.Text.Trim
            'If txbFixedRate.Text <> "" AndAlso IsNumeric(txbFixedRate.Text) Then
            If hidFixedRate.Value <> "" Then
                objBPO.FixedRate = CDbl(hidFixedRate.Value)
            Else
                objBPO.FixedRate = 1.0
            End If
            If IsNumeric(txbDiscount.Text) Then objBPO.Discount = txbDiscount.Text.Trim
            'objBPO.Currency = ddlCurrency.SelectedItem.Text
            If hidCurrency.Value = "" Then
                objBPO.Currency = "VND"
            Else
                objBPO.Currency = hidCurrency.Value
            End If

            intRetVal = objBPO.Create()
            If Not intRetVal = 0 Then ' Exist code 
                Page.RegisterClientScriptBlock("UnSuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")

                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(4).Text & ": " & txbReceiptNo.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' View detail
                Page.RegisterClientScriptBlock("ReloadJs", "<script language = 'javascript'>parent.taskbar.document.forms[0].txtMaxID.value=parseFloat(parent.taskbar.document.forms[0].txtMaxID.value) + 1; parent.taskbar.document.forms[0].txtCurrentID.value = parent.taskbar.document.forms[0].txtMaxID.value; location.href='WContractDetail.aspx?POS=' + parent.taskbar.document.forms[0].txtMaxID.value;</script>")
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
                Call objBPO.Dispose(True)
                Call objBVendor.Dispose(True)
                Call objBCB.Dispose(True)
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
            hidCurrency.Value = ddlCurrency.SelectedItem.Text
        End Sub
    End Class
End Namespace