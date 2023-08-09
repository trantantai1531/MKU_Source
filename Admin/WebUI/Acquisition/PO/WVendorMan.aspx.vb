' Class: clsWBase
' Puspose: Manager Vendor
' Creator: Sondp
' CreatedDate: 02/04/2005
' Modification History:
'   - 10/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WVendorMan
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddNew As System.Web.UI.WebControls.Label
        Protected WithEvents lblDeleteVendor As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateVendorUnsuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateVendorSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblConfirmDelete As System.Web.UI.WebControls.Label
        Protected WithEvents lblInvalidEmail As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBVendor As New clsBVendor
        Private objBCB As New clsBCommonBusiness

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
                Call LoadAllVendors()
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all neccessary objects
        Private Sub Initialize()
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

        ' Method: CheckFormPermission
        ' Purpose: Check form permission
        Private Sub CheckFormPermission()
            'Cap nhat NCC
            If Not CheckPemission(35) Then
                btnDelete.Enabled = False
                btnUpdate.Enabled = False
                ddlVendorLists.Enabled = False
            End If
            'Nhap moi NCC
            If CheckPemission(34) Then
                btnUpdate.Enabled = True
            End If
            If Request("From") = "1" Then
                btnClose.Visible = True
                PanelDDLVendorMan.Visible = False
                ddlVendorLists.SelectedIndex = 0
            Else
                btnClose.Visible = False
                PanelDDLVendorMan.Visible = True
            End If
        End Sub

        ' Method: LoadAllVendor
        ' Purpose: Show list of all vendors
        Private Sub LoadAllVendors()
            Dim tblData As New DataTable
            Dim listItem As New listItem

            ' Get Vendor(s)
            objBVendor.VendorID = 0
            If CheckPemission(34) Then
                tblData = InsertOneRow(objBVendor.GetVendor, ddlLabel.Items(7).Text)
            Else
                tblData = objBVendor.GetVendor
            End If
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                ddlVendorLists.DataSource = tblData
                ddlVendorLists.DataTextField = "Name"
                ddlVendorLists.DataValueField = "ID"
                ddlVendorLists.DataBind()
            Else
                listItem.Text = ddlLabel.Items(8).Text
                listItem.Value = 0
                ddlVendorLists.Items.Add(listItem)
            End If
            ddlVendorLists.SelectedIndex = 0
            tblData = Nothing
            listItem = Nothing
            Call ResetForm()
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblData As New DataTable
            Dim listItem As New listItem
            Dim inti As Integer

            ddlCountry.Items.Clear()
            ddlProvince.Items.Clear()
            ' Get country
            tblData = objBCB.GetCountries
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                tblData = InsertOneRow(tblData, ddlLabel.Items(7).Text)
                ddlCountry.DataSource = tblData
                ddlCountry.DataTextField = "DisplayEntry"
                ddlCountry.DataValueField = "ID"
                ddlCountry.DataBind()
                For inti = 0 To tblData.Rows.Count - 1
                    If CStr(tblData.Rows(inti).Item("ISOCode")).ToLower = "vm" Then
                        ddlCountry.SelectedIndex = inti
                        Exit For
                    End If
                Next


            Else
                listItem.Text = ddlLabel.Items(7).Text
                listItem.Value = 0
                ddlCountry.Items.Add(listItem)
            End If
            tblData = Nothing

            ' Get Province
            tblData = objBVendor.GetProvince
            If Not tblData Is Nothing AndAlso tblData.Rows.Count > 0 Then
                tblData = InsertOneRow(tblData, ddlLabel.Items(7).Text)
                ddlProvince.DataSource = tblData
                ddlProvince.DataTextField = "Province"
                ddlProvince.DataValueField = "ID"
                ddlProvince.DataBind()
            Else
                listItem.Text = ddlLabel.Items(7).Text
                listItem.Value = 0
                ddlProvince.Items.Add(listItem)
            End If
            tblData = Nothing
        End Sub

        ' Method: BindJS
        ' Purpose: include all neccessary js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WVendorManJs", "<script language='javascript' src='../Js/PO/WVendorMan.js'></script>")

            btnUpdate.Attributes.Add("OnClick", "return(CheckValidData('" & ddlLabel.Items(3).Text & "', '" & ddlLabel.Items(2).Text & "', '" & ddlLabel.Items(12).Text & "'));")
            btnDelete.Attributes.Add("OnClick", "return(ConfirmDelete('" & ddlLabel.Items(4).Text & "', '" & ddlLabel.Items(13).Text & "'));")
            btnCancel.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnClose.Attributes.Add("OnClick", "opener.document.forms[0].txbFunc.value='ADD'; opener.document.forms[0].submit(); self.close(); return false;")

            Me.SetCheckNumber(txtClaimCycle1, ddlLabel.Items(2).Text, "10")
            Me.SetCheckNumber(txtClaimCycle2, ddlLabel.Items(2).Text, "20")
            Me.SetCheckNumber(txtClaimCycle3, ddlLabel.Items(2).Text, "30")
            Me.SetCheckNumber(txtDeliveryTime, ddlLabel.Items(2).Text, "1")

        End Sub

        ' Method: LoadVendor
        ' Input: intVendorID
        Private Sub LoadVendor(ByVal intVendorID As Integer)
            Dim tblVendor As New DataTable
            Dim intCount As Integer

            If intVendorID <= 0 Then
                Call ResetForm()
                Exit Sub
            End If

            objBVendor.VendorID = intVendorID
            tblVendor = objBVendor.GetVendor
            If Not tblVendor Is Nothing AndAlso tblVendor.Rows.Count > 0 Then
                txtName.Text = tblVendor.Rows(0).Item("Name").ToString.Trim
                txtAddress.Text = tblVendor.Rows(0).Item("Address").ToString.Trim
                If Not IsDBNull(tblVendor.Rows(0).Item("ProvinceID")) Then
                    For intCount = 0 To ddlProvince.Items.Count - 1
                        If tblVendor.Rows(0).Item("ProvinceID") = ddlProvince.Items(intCount).Value Then
                            ddlProvince.SelectedIndex = intCount
                            Exit For
                        End If
                    Next
                End If
                If Not IsDBNull(tblVendor.Rows(0).Item("CountryID")) Then
                    For intCount = 0 To ddlCountry.Items.Count - 1
                        If tblVendor.Rows(0).Item("CountryID") = ddlCountry.Items(intCount).Value Then
                            ddlCountry.SelectedIndex = intCount
                            Exit For
                        End If
                    Next
                End If
                txtZip.Text = tblVendor.Rows(0).Item("Zip").ToString.Trim
                txtContactPerson.Text = tblVendor.Rows(0).Item("ContactPerson").ToString.Trim
                txtTelephone.Text = tblVendor.Rows(0).Item("Tel").ToString.Trim
                txtFax.Text = tblVendor.Rows(0).Item("Fax").ToString.Trim
                txtEmail.Text = tblVendor.Rows(0).Item("Email").ToString.Trim
                txtLibSAN.Text = tblVendor.Rows(0).Item("LibSAN").ToString.Trim
                txtSAN.Text = tblVendor.Rows(0).Item("SAN").ToString.Trim
                If Not IsDBNull(tblVendor.Rows(0).Item("X12Enabled")) Then
                    cbxX12.Checked = tblVendor.Rows(0).Item("X12Enabled")
                Else
                    cbxX12.Checked = True
                End If
                txtX12Email.Text = tblVendor.Rows(0).Item("X12Email").ToString.Trim
                txtDeliveryTime.Text = tblVendor.Rows(0).Item("DeliveryTime").ToString.Trim
                txtClaimCycle1.Text = tblVendor.Rows(0).Item("ClaimCycle1").ToString.Trim
                txtClaimCycle2.Text = tblVendor.Rows(0).Item("ClaimCycle2").ToString.Trim
                txtClaimCycle3.Text = tblVendor.Rows(0).Item("ClaimCycle3").ToString.Trim
                txtClaimEmail.Text = tblVendor.Rows(0).Item("ClaimEmail").ToString.Trim
                txtLibAC.Text = tblVendor.Rows(0).Item("LibAC").ToString.Trim
                txtBankingInfo.Text = tblVendor.Rows(0).Item("BankingInfo").ToString.Trim
                txtNote.Text = tblVendor.Rows(0).Item("Note").ToString.Trim
            End If
        End Sub

        ' Method: ResetForm
        ' Purpose: reset value of all form's controls
        Private Sub ResetForm()
            txtName.Text = ""
            txtAddress.Text = ""
            txtContactPerson.Text = ""
            txtTelephone.Text = ""
            txtFax.Text = ""
            txtEmail.Text = ""
            txtSAN.Text = ""
            txtLibSAN.Text = ""
            txtClaimCycle1.Text = 30
            txtClaimCycle2.Text = 60
            txtClaimCycle3.Text = 90
            txtClaimEmail.Text = ""
            cbxX12.Checked = False
            txtZip.Text = ""
            txtDeliveryTime.Text = 1
            txtX12Email.Text = ""
            txtLibAC.Text = ""
            txtBankingInfo.Text = ""
            txtNote.Text = ""
            ddlProvince.SelectedIndex = 0
            ddlCountry.SelectedIndex = 0
        End Sub

        ' Event: ddlVendorLists_SelectedIndexChanged
        ' Purpose: Reload vendor list
        Private Sub ddlVendorLists_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlVendorLists.SelectedIndexChanged
            Call LoadVendor(ddlVendorLists.SelectedValue)
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: Update/Create vendor record
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intRetVal As Integer

            objBVendor.Name = txtName.Text
            objBVendor.Address = txtAddress.Text
            objBVendor.ProvinceID = ddlProvince.SelectedValue
            objBVendor.CountryID = ddlCountry.SelectedValue
            objBVendor.Zip = txtZip.Text
            objBVendor.ContactPerson = txtContactPerson.Text
            objBVendor.Tel = txtTelephone.Text
            objBVendor.Fax = txtFax.Text
            objBVendor.Email = txtEmail.Text
            objBVendor.SAN = txtSAN.Text
            objBVendor.LibSAN = txtLibSAN.Text
            If Trim(txtClaimCycle1.Text) <> "" And IsNumeric(txtClaimCycle1.Text) Then
                objBVendor.ClaimCycle1 = CInt(Trim(txtClaimCycle1.Text))
            Else
                objBVendor.ClaimCycle1 = 90
            End If
            If Trim(txtClaimCycle2.Text) <> "" And IsNumeric(txtClaimCycle2.Text) Then
                objBVendor.ClaimCycle2 = CInt(Trim(txtClaimCycle2.Text))
            Else
                objBVendor.ClaimCycle2 = 60
            End If
            If Trim(txtClaimCycle3.Text) <> "" And IsNumeric(txtClaimCycle3.Text) Then
                objBVendor.ClaimCycle3 = CInt(Trim(txtClaimCycle3.Text))
            Else
                objBVendor.ClaimCycle3 = 30
            End If
            objBVendor.ClaimEmail = (Trim(txtClaimEmail.Text))
            If Trim(txtDeliveryTime.Text) <> "" And IsNumeric(Trim(txtDeliveryTime.Text)) Then
                objBVendor.DeliveryTime = CInt(Trim(txtDeliveryTime.Text))
            End If
            objBVendor.X12Enable = cbxX12.Checked
            objBVendor.X12Email = txtX12Email.Text
            objBVendor.LibAC = txtLibAC.Text
            objBVendor.BankingInfo = txtBankingInfo.Text
            objBVendor.Note = txtNote.Text

            If ddlVendorLists.SelectedValue = 0 Then ' Create new vendor
                intRetVal = objBVendor.Create()
                ' Writelog
                Call WriteLog(38, ddlLabel.Items(9).Text & " " & txtName.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If objBVendor.ErrorMsg <> "" Then
                    Page.RegisterClientScriptBlock("CreateVendorUnsuccessfulJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                Else
                    If intRetVal = 0 Then
                        Page.RegisterClientScriptBlock("CreateVendorSuccessfulJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("CreateVendorSuccessfulJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(14).Text & "');</script>")
                    End If
                End If
            Else ' Update
                objBVendor.VendorID = ddlVendorLists.SelectedValue
                intRetVal = objBVendor.Update
                ' Writelog
                Call WriteLog(38, ddlLabel.Items(10).Text & " " & txtName.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If objBVendor.ErrorMsg <> "" Then
                    Page.RegisterClientScriptBlock("UpdateVendorUnsuccessfulJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("CreateVendorSuccessfulJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                End If
            End If
            Call LoadAllVendors()
        End Sub

        ' Event: btnDelete_Click
        ' Purpose: Delete the selected vendor record
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim intRetVal As Integer
            objBVendor.VendorID = ddlVendorLists.SelectedValue
            'Delete
            intRetVal = objBVendor.Delete
            ' Writelog
            Call WriteLog(38, ddlLabel.Items(11).Text & " " & txtName.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If intRetVal = -1 Then
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
            ElseIf intRetVal = 0 Then
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('Xoá thông tin nhà cung cấp thành công');</script>")

            ElseIf intRetVal > 0 Then
                Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('không thể xóa  nhà cung cấp');</script>")
            End If



            Call LoadAllVendors()
        End Sub

        ' Method: Page_Unload
        ' Purpose: unload form
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBVendor Is Nothing Then
                objBVendor.Dispose(True)
                objBVendor = Nothing
            End If
            If Not objBCB Is Nothing Then
                objBCB.Dispose(True)
                objBCB = Nothing
            End If
        End Sub
    End Class
End Namespace