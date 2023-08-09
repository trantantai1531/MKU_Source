' Class: WLibMan.aspx
' Puspose: Management list of ILL libraries
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
'   - 23/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WLibMan
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
        Private objBILLLibrary As New clsBILLLibrary
        Private objBCommonBussiness As New clsBCommonBusiness

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindAllLibrary()
                Call BindCountries()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(152) Then
                btnUpdate.Enabled = False
            End If
            If Not CheckPemission(206) Then
                btnDelete.Enabled = False
                hidNoDel.Value = 1
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBCommonBussiness object
            objBCommonBussiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBussiness.DBServer = Session("DBServer")
            objBCommonBussiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBussiness.Initialize()

            ' Init objBILLLibrary object
            objBILLLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLLibrary.DBServer = Session("DBServer")
            objBILLLibrary.ConnectionString = Session("ConnectionString")
            Call objBILLLibrary.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Include all need js functions
        Private Sub BindScript()
            Dim strJSConfirm As String

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'js/WLibMan.js'></script>")
            Page.RegisterClientScriptBlock("Self1Js", "<script language = 'javascript' src = 'js/WLibLoadInfor.js'></script>")

            lstLibrary.Attributes.Add("OnChange", "javascript:document.forms[0].rdoBillAddress.checked = false;document.forms[0].rdoPosAddress.checked = true;if (this.options[this.options.selectedIndex].value != 0) {parent.Sentform.location.href='WLibLoadInfor.aspx?LibID=' + this.options[this.options.selectedIndex].value + '&Del= ' + document.forms[0].hidNoDel.value ;document.forms[0].hidLibID.value=this.options[this.options.selectedIndex].value;return false;}else{ClearContent();return false;}")

            btnUpdate.Attributes.Add("Onclick", "javascript:return CheckValid('" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(10).Text & "','" & ddlLabel.Items(17).Text & "');")
            btnReset.Attributes.Add("OnClick", "ClearContent(); return false;")
            btnDelete.Attributes.Add("OnClick", "javascript:if(document.forms[0].hidLibID.value==0) {return false;}")

            rdoBillAddress.Attributes.Add("OnClick", "javascript:ShowBill();")
            rdoPosAddress.Attributes.Add("OnClick", "javascript:ShowPost();")

            txtDelivName.Attributes.Add("OnChange", "javascript:UpdateValue('DelivName',-1)")
            txtDelivXAddr.Attributes.Add("OnChange", "javascript:UpdateValue('DelivXAddr',-1)")
            txtDelivStreet.Attributes.Add("OnChange", "javascript:UpdateValue('DelivStreet',-1)")
            txtDelivBox.Attributes.Add("OnChange", "javascript:UpdateValue('DelivBox',-1)")
            txtDelivCity.Attributes.Add("OnChange", "javascript:UpdateValue('DelivCity',-1)")
            txtDelivRegion.Attributes.Add("OnChange", "javascript:UpdateValue('DelivRegion',-1)")
            txtDelivCode.Attributes.Add("OnChange", "javascript:UpdateValue('DelivCode',-1)")

            ddlCountry.Attributes.Add("OnChange", "javascript:UpdateValue('DelivCountry', this.options[this.options.selectedIndex].value)")

            strJSConfirm = "return ConfirmDelete('" & ddlLabel.Items(12).Text & "', '" & ddlLabel.Items(16).Text & "');"
            btnDelete.Attributes.Add("onClick", strJSConfirm)
        End Sub

        ' Method: BindCountries
        Private Sub BindCountries()
            Dim tblCountry As DataTable
            Dim inti As Integer

            ' Bind the countries
            tblCountry = objBCommonBussiness.GetCountries

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBussiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBussiness.ErrorCode)

            ' Check error
            If Not tblCountry Is Nothing Then
                If tblCountry.Rows.Count > 0 Then
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
            End If
        End Sub

        ' Method: BindAllLibrary
        Private Sub BindAllLibrary()
            Dim tblLibrary As DataTable
            Dim intIndex As Integer
            Dim blFound As Boolean = False

            ' bind the customers
            objBILLLibrary.LibID = clsSession.GlbSite
            tblLibrary = objBILLLibrary.GetLib(-1)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLLibrary.ErrorMsg, ddlLabel.Items(0).Text, objBILLLibrary.ErrorCode)

            If Not tblLibrary Is Nothing Then
                If tblLibrary.Rows.Count > 0 Then
                    tblLibrary = InsertOneRow(tblLibrary, Trim(ddlLabel.Items(14).Text))

                    ' Check error
                    'Call WriteErrorMssg(ddlLabel.Items(1).Text, ErrorMsg, ddlLabel.Items(0).Text, ErrorCode)

                    lstLibrary.Items.Clear()
                    lstLibrary.DataSource = tblLibrary
                    lstLibrary.DataTextField = "LibSymCode"
                    lstLibrary.DataValueField = "ID"
                    lstLibrary.DataBind()
                    lstLibrary.SelectedIndex = 0
                    blFound = True
                End If
            End If

            If Not blFound Then
                lstLibrary.Items.Clear()
                lstLibrary.Items.Add(ddlLabel.Items(14).Text)
                lstLibrary.Items(0).Text = ddlLabel.Items(14).Text
                lstLibrary.Items(0).Value = 0
            End If
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intRetval As Integer = 1
            If hidLibID.Value = 0 Then
                intRetval = CreateLibrary()
            Else
                intRetval = UpdateLibrary()
            End If
            If intRetval = 0 Then
                Call BindAllLibrary()
            End If
        End Sub

        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Call Delete()
            Call BindAllLibrary()
            Page.RegisterClientScriptBlock("SucessDelete", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
        End Sub

        ' Method: CreateLibrary
        Private Function CreateLibrary() As Integer
            Dim intOutValue As Integer = 0

            objBILLLibrary.LibrarySymbol = txtSymbol.Text.Trim
            objBILLLibrary.LibraryName = txtName.Text.Trim
            objBILLLibrary.EmailReplyAddress = txtEmailAddress.Text.Trim
            objBILLLibrary.Telephone = txtPhone.Text.Trim
            objBILLLibrary.LibraryCode = txtCode.Text.Trim
            objBILLLibrary.Note = txtNote.Text.Trim
            objBILLLibrary.EDelivMode = txtEDelivMode.Text.Trim
            objBILLLibrary.EDelivTSAddr = txtEDelivTSAdd.Text.Trim
            objBILLLibrary.BillDelivName = hidBillDelivName.Value.Trim
            objBILLLibrary.BillDelivXAddr = hidBillDelivXAddr.Value.Trim
            objBILLLibrary.BillDelivStreet = hidBillDelivStreet.Value.Trim
            objBILLLibrary.BillDelivBox = hidBillDelivBox.Value.Trim
            objBILLLibrary.BillDelivCity = hidBillDelivCity.Value.Trim
            objBILLLibrary.BillDelivRegion = hidBillDelivRegion.Value.Trim
            objBILLLibrary.BillDelivCountry = CInt(hidBillDelivCountry.Value.Trim)
            objBILLLibrary.BillDelivCode = hidBillDelivCode.Value.Trim
            objBILLLibrary.PostDelivName = hidPostDelivName.Value.Trim
            objBILLLibrary.PostDelivXAddr = hidPostDelivXAddr.Value.Trim
            objBILLLibrary.PostDelivStreet = hidPostDelivStreet.Value.Trim
            objBILLLibrary.PostDelivBox = hidPostDelivBox.Value.Trim
            objBILLLibrary.PostDelivCity = hidPostDelivCity.Value.Trim
            objBILLLibrary.PostDelivRegion = hidPostDelivRegion.Value.Trim
            objBILLLibrary.PostDelivCountry = CInt(hidPostDelivCountry.Value.Trim)
            objBILLLibrary.PostDelivCode = hidPostDelivCode.Value.Trim
            objBILLLibrary.EncodingScheme = ddlEncodingSchema.SelectedValue
            objBILLLibrary.LibID = clsSession.GlbSite
            intOutValue = objBILLLibrary.Create()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLLibrary.ErrorMsg, ddlLabel.Items(0).Text, objBILLLibrary.ErrorCode)

            If intOutValue = 0 Then ' Success
                ' WriteLog
                Call WriteLog(64, ddlLabel.Items(2).Text & " " & txtSymbol.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Page.RegisterClientScriptBlock("Sucess", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
            Else
                If intOutValue = 1 Then  ' Exist symbol
                    Page.RegisterClientScriptBlock("ExistSymbol", "<script language='javascript'>alert('" & ddlLabel.Items(15).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("ExistCode", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "');</script>")
                End If
            End If
            rdoBillAddress.Checked = False
            rdoPosAddress.Checked = True
            CreateLibrary = intOutValue
        End Function

        ' Method: UpdateLibrary
        Private Function UpdateLibrary() As Integer
            Dim intOutValue As Integer = 0

            objBILLLibrary.LibID = CInt(hidLibID.Value.Trim)
            objBILLLibrary.LibrarySymbol = txtSymbol.Text.Trim
            objBILLLibrary.LibraryName = txtName.Text.Trim
            objBILLLibrary.EmailReplyAddress = txtEmailAddress.Text.Trim
            objBILLLibrary.Telephone = txtPhone.Text.Trim
            objBILLLibrary.LibraryCode = txtCode.Text.Trim
            objBILLLibrary.Note = txtNote.Text.Trim
            objBILLLibrary.EDelivMode = txtEDelivMode.Text.Trim
            objBILLLibrary.EDelivTSAddr = txtEDelivTSAdd.Text.Trim
            objBILLLibrary.BillDelivName = hidBillDelivName.Value.Trim
            objBILLLibrary.BillDelivXAddr = hidBillDelivXAddr.Value.Trim
            objBILLLibrary.BillDelivStreet = hidBillDelivStreet.Value.Trim
            objBILLLibrary.BillDelivBox = hidBillDelivBox.Value.Trim
            objBILLLibrary.BillDelivCity = hidBillDelivCity.Value.Trim
            objBILLLibrary.BillDelivRegion = hidBillDelivRegion.Value.Trim
            If Not hidBillDelivCountry.Value.Trim = "" AndAlso Not hidBillDelivCountry.Value.Trim = "0" Then
                objBILLLibrary.BillDelivCountry = CInt(hidBillDelivCountry.Value.Trim)
            Else
                objBILLLibrary.BillDelivCountry = 0
            End If
            objBILLLibrary.BillDelivCode = hidBillDelivCode.Value.Trim
            objBILLLibrary.PostDelivName = hidPostDelivName.Value.Trim
            objBILLLibrary.PostDelivXAddr = hidPostDelivXAddr.Value.Trim
            objBILLLibrary.PostDelivStreet = hidPostDelivStreet.Value.Trim
            objBILLLibrary.PostDelivBox = hidPostDelivBox.Value.Trim
            objBILLLibrary.PostDelivCity = hidPostDelivCity.Value.Trim
            objBILLLibrary.PostDelivRegion = hidPostDelivRegion.Value.Trim
            If Not hidPostDelivCountry.Value.Trim = "" AndAlso Not hidPostDelivCountry.Value.Trim = "0" Then
                objBILLLibrary.PostDelivCountry = CInt(hidPostDelivCountry.Value.Trim)
            Else
                objBILLLibrary.PostDelivCountry = 0
            End If
            objBILLLibrary.PostDelivCode = hidPostDelivCode.Value.Trim
            objBILLLibrary.EncodingScheme = ddlEncodingSchema.SelectedValue
            intOutValue = objBILLLibrary.Update()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLLibrary.ErrorMsg, ddlLabel.Items(0).Text, objBILLLibrary.ErrorCode)

            If intOutValue = 0 Then ' Success
                ' WriteLog
                Call WriteLog(64, ddlLabel.Items(3).Text & " " & txtSymbol.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Page.RegisterClientScriptBlock("SucessUpdate", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
            Else
                If intOutValue = 1 Then  ' Exist symbol
                    Page.RegisterClientScriptBlock("ExistSymbol1", "<script language='javascript'>alert('" & ddlLabel.Items(15).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("ExistCode1", "<script language='javascript'>alert('" & ddlLabel.Items(18).Text & "');</script>")
                End If
            End If

            rdoBillAddress.Checked = False
            rdoPosAddress.Checked = True
            UpdateLibrary = intOutValue
        End Function

        ' Method: Delete
        ' Purpose: delete selected library's informations
        Private Sub Delete()
            Dim intOutValue As Integer = 0

            objBILLLibrary.LibID = CInt(hidLibID.Value)
            intOutValue = objBILLLibrary.Delete()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBILLLibrary.ErrorMsg, ddlLabel.Items(0).Text, objBILLLibrary.ErrorCode)

            If intOutValue = 0 Then ' Success
                ' WriteLog
                Call WriteLog(64, ddlLabel.Items(4).Text & " " & txtSymbol.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
        End Sub

        ' Event: Page UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLLibrary Is Nothing Then
                    objBILLLibrary.Dispose(True)
                    objBILLLibrary = Nothing
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