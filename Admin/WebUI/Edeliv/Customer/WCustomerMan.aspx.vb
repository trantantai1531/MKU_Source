Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WCustomerMan
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

        Private objBECustomer As New clsBECustomer
        Private objBCommonBussiness As New clsBCommonBusiness

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJS()
            Call BindAllCustomer()
            If Not Page.IsPostBack Then
                Call BindCountries()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(158) Then
                Call WriteErrorMssg(ddlLabel.Items(15).Text)
            End If
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Customer/WCustomerMan.js'></script>")

            ' Add the attributes for the controls
            txtSecretLevel.Attributes.Add("OnChange", "if (!CheckNumBer(this, '" & ddlLabel.Items(27).Text.Trim & "')) {this.value=0; this.focus();} if (this.value.length > 1) {alert('" & ddlLabel.Items(27).Text & "');this.value=0; this.focus();} if (this.value == '') {alert('" & ddlLabel.Items(27).Text & "');this.value=0; this.focus();}")
            btnUpdate.Attributes.Add("Onclick", "javascript:return CheckValid('" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(10).Text & "','" & ddlLabel.Items(11).Text & "','" & ddlLabel.Items(12).Text & "','" & ddlLabel.Items(13).Text & "');")
            btnDelete.Attributes.Add("OnClick", "javascript:if(document.forms[0].hidCustomerID.value==0) {alert('" & ddlLabel.Items(26).Text.Trim & "'); return false;} else {if (!confirm('" & ddlLabel.Items(23).Text & "')) {return false;}}")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBCommonBussiness
            objBCommonBussiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBussiness.DBServer = Session("DBServer")
            objBCommonBussiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBussiness.Initialize()

            ' Init for objBECustomer
            objBECustomer.InterfaceLanguage = Session("InterfaceLanguage")
            objBECustomer.DBServer = Session("DBServer")
            objBECustomer.ConnectionString = Session("ConnectionString")
            Call objBECustomer.Initialize()
        End Sub

        ' BindCountries method
        Private Sub BindCountries()
            Dim tblCountry As DataTable
            Dim inti As Integer
            ' Bind the countries
            tblCountry = objBCommonBussiness.GetCountries
            Call WriteErrorMssg(ddlLabel.Items(17).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(16).Text, objBCommonBussiness.ErrorCode)

            If Not tblCountry Is Nothing AndAlso tblCountry.Rows.Count > 0 Then
                ddlCountry.DataSource = tblCountry
                ddlCountry.DataTextField = "DisplayEntry"
                ddlCountry.DataValueField = "ID"
                ddlCountry.DataBind()
                For inti = 0 To tblCountry.Rows.Count - 1
                    If CStr(tblCountry.Rows(inti).Item("ISOCode")).ToLower = "vm" Then
                        ddlCountry.SelectedIndex = inti
                        Exit For
                    End If
                Next
            End If
        End Sub

        ' BindAllCustomer method
        Private Sub BindAllCustomer()
            Dim tblCustomer As DataTable
            Dim intIndex As Integer
            Dim blFound As Boolean = False

            ' bind the customers
            objBECustomer.CustomerID = 0
            tblCustomer = objBECustomer.GetCustomerInfor
            Call WriteErrorMssg(ddlLabel.Items(17).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(16).Text, objBCommonBussiness.ErrorCode)

            If Not tblCustomer Is Nothing AndAlso tblCustomer.Rows.Count > 0 Then
                tblCustomer = InsertOneRow(tblCustomer, Trim(ddlLabel.Items(0).Text))
                lstCustomerName.DataSource = tblCustomer
                lstCustomerName.DataTextField = "Name"
                lstCustomerName.DataValueField = "UserID"
                lstCustomerName.DataBind()

                For intIndex = 1 To tblCustomer.Rows.Count - 1
                    If tblCustomer.Rows(intIndex).Item("Approved") = 0 Then
                        lstCustomerName.Items(intIndex).Attributes.Add("style", "color:red")
                    Else
                        lstCustomerName.Items(intIndex).Attributes.Add("style", "color:green")
                    End If
                Next
            Else
                lstCustomerName.Items.Clear()
                lstCustomerName.Items.Add(ddlLabel.Items(0).Text)
                lstCustomerName.Items(0).Text = ddlLabel.Items(0).Text
                lstCustomerName.Items(0).Value = 0
            End If

            lstCustomerName.SelectedIndex = 0
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            If hidCustomerID.Value = 0 Then
                Call CreateAccount()
            Else
                Call UpdateAccount()
            End If
            Call SendEMail()
            Call BindJS()
            Call BindAllCustomer()
        End Sub

        ' btnDelete_Click event
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Call WriteLog(71, ddlLabel.Items(20).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call Delete()
            Call BindJS()
            Call BindAllCustomer()
        End Sub

        ' CreateAccount method
        Private Function CreateAccount() As Integer
            objBECustomer.UserName = txtEdelivUserName.Text.Trim
            objBECustomer.Name = txtFullName.Text.Trim
            objBECustomer.DelivName = txtWorkPlace.Text.Trim
            objBECustomer.DelivXAddr = txtDepartment.Text.Trim
            objBECustomer.DelivStreet = txtAddress.Text.Trim
            objBECustomer.DelivBox = txtBox.Text.Trim
            objBECustomer.DelivCity = txtCity.Text.Trim
            objBECustomer.DelivRegion = txtArea.Text.Trim
            objBECustomer.DelivCountryID = ddlCountry.SelectedValue
            objBECustomer.DelivCode = txtPostalCode.Text.Trim
            objBECustomer.Telephone = txtPhone.Text.Trim
            objBECustomer.EmailAddress = txtEmailAddress.Text.Trim
            objBECustomer.Note = txtNote.Text.Trim
            objBECustomer.Password = txtEdelivPassword.Text.Trim
            objBECustomer.Fax = txtFaxNumber.Text.Trim
            objBECustomer.ContactPerson = txtContactName.Text.Trim
            objBECustomer.SecretLevel = CInt(txtSecretLevel.Text.Trim)

            If chkStatus.Checked = False Then
                objBECustomer.Approved = 0
            Else
                objBECustomer.Approved = 1
            End If
            CreateAccount = objBECustomer.Create()

            Call WriteErrorMssg(ddlLabel.Items(17).Text, objBECustomer.ErrorMsg, ddlLabel.Items(16).Text, objBECustomer.ErrorCode)

            If CreateAccount <> 0 Then
                Page.RegisterClientScriptBlock("Unssucess", "<script language='javascript'>alert('" & ddlLabel.Items(21).Text & "');</script>")
            Else
                Call WriteLog(71, ddlLabel.Items(18).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("AlterJS", "<script language='javascript'>alert('" & ddlLabel.Items(24).Text & "');</script>")
            End If
        End Function

        ' UpdateAccount method
        Private Function UpdateAccount() As Integer
            objBECustomer.CustomerID = CInt(hidCustomerID.Value)
            objBECustomer.UserName = txtEdelivUserName.Text.Trim
            objBECustomer.Name = txtFullName.Text.Trim
            objBECustomer.DelivName = txtWorkPlace.Text.Trim
            objBECustomer.DelivXAddr = txtDepartment.Text.Trim
            objBECustomer.DelivStreet = txtAddress.Text.Trim
            objBECustomer.DelivBox = txtBox.Text.Trim
            objBECustomer.DelivCity = txtCity.Text.Trim
            objBECustomer.DelivRegion = txtArea.Text.Trim
            objBECustomer.DelivCountryID = ddlCountry.SelectedValue
            objBECustomer.DelivCode = txtPostalCode.Text.Trim
            objBECustomer.Telephone = txtPhone.Text.Trim
            objBECustomer.EmailAddress = txtEmailAddress.Text.Trim
            objBECustomer.Note = txtNote.Text.Trim
            objBECustomer.Password = txtEdelivPassword.Text.Trim
            objBECustomer.Fax = txtFaxNumber.Text.Trim
            objBECustomer.ContactPerson = txtContactName.Text.Trim
            objBECustomer.SecretLevel = CInt(txtSecretLevel.Text.Trim)

            If chkStatus.Checked = False Then
                objBECustomer.Approved = 0
            Else
                objBECustomer.Approved = 1
            End If
            UpdateAccount = objBECustomer.Update()
            Call WriteErrorMssg(ddlLabel.Items(17).Text, objBECustomer.ErrorMsg, ddlLabel.Items(16).Text, objBECustomer.ErrorCode)
            If UpdateAccount <> 0 Then
                Page.RegisterClientScriptBlock("Unssucess", "<script language='javascript'>alert('" & ddlLabel.Items(22).Text & "');</script>")
            Else
                Call WriteLog(71, ddlLabel.Items(19).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("AlterJS", "<script language='javascript'>alert('" & ddlLabel.Items(24).Text & "');</script>")
            End If
        End Function
        Private Sub SendEMail()
            Dim strEmailTo As String
            Dim strContent As String
            Dim strSubject As String
            Dim intOK As Integer

            strSubject = ddlLabel.Items(30).Text
            strEmailTo = txtEmailAddress.Text.Trim
            If chkStatus.Checked = False Then
                strContent = ddlLabel.Items(29).Text
            Else
                strContent = ddlLabel.Items(28).Text
            End If
            intOK = Me.SendMail(strSubject, strContent, strEmailTo)
            If intOK = 0 Then
                Page.RegisterClientScriptBlock("Error1", "<script language='javascript'>alert('" & ddlLabel.Items(31).Text & "');</script>")
            End If
        End Sub

        ' Delete method
        Private Sub Delete()
            objBECustomer.CustomerID = CInt(hidCustomerID.Value)
            objBECustomer.Delete()

            Call WriteErrorMssg(ddlLabel.Items(17).Text, objBECustomer.ErrorMsg, ddlLabel.Items(16).Text, objBECustomer.ErrorCode)

            Page.RegisterClientScriptBlock("AlterJS", "<script language='javascript'>alert('" & ddlLabel.Items(25).Text & "');</script>")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBECustomer Is Nothing Then
                    objBECustomer.Dispose(True)
                    objBECustomer = Nothing
                End If
                If Not objBCommonBussiness Is Nothing Then
                    objBCommonBussiness.Dispose(True)
                    objBCommonBussiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace