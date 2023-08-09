Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WILLInComing
        Inherits clsWBase
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
        Protected WithEvents OK As System.Web.UI.HtmlControls.HtmlInputHidden

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBOPACILLInComingReq As New clsBOPACILLInComingReq
        Private objBCommonStringProc As New clsBCommonStringProc
        Private objBCommonDBSystem As New clsBCommonDBSystem

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJScript()
            If Not IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' Initialize
        Private Sub Initialize()
            '  Init objBOPACILLInComingReq
            objBOPACILLInComingReq.ConnectionString = Session("ConnectionString")
            objBOPACILLInComingReq.DBServer = Session("DBServer")
            objBOPACILLInComingReq.Initialize()
            '  Init objBCommonStringProc
            objBCommonStringProc.ConnectionString = Session("ConnectionString")
            objBCommonStringProc.DBServer = Session("DBServer")
            objBCommonStringProc.Initialize()
            '  Init objBCommonDBSystem
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.Initialize()
        End Sub

        ' BindJavaScript
        Private Sub BindJScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/ILL/WILLInComing.js'></script>")

            txtComponentPubDate.Attributes.Add("onchange", "javascript:if (!CheckDate(this,'dd/mm/yyyy','" & lblMsgInvalidDate.Text & "')) return false;")
            txtNeedBeforeDate.Attributes.Add("onchange", "javascript:if (!CheckDate(this,'dd/mm/yyyy','" & lblMsgInvalidDate.Text & "')) return false;")
            txtPubDate.Attributes.Add("onchange", "if (!CheckDate(this,'dd/mm/yyyy','" & lblMsgInvalidDate.Text & "')) return false;")
            'txtPlaceOfPub.Attributes.Add("onchange", "if (!CheckDate(this,'dd/mm/yyyy','" & lblMsgInvalidDate.Text & "')) return false;")
            'ddlPostDelivCountry.Attributes.Add("onchange", "parent.Hiddenbase.location.href='WILLInComingHidden.aspx?RequesterSymbol='+document.forms[0].txtRequesterSymbol.value+'&PostDelivCountry='+document.forms[0].ddlPostDelivCountry.options[document.forms[0].ddlPostDelivCountry.selectedIndex].value+'&EmailReplyAddress='+document.forms[0].txtEmailReplyAddress.value")
            btnSendRequest.Attributes.Add("Onclick", "javascript:return CheckValid('" & lblMsgRequesterSymbol.Text & "','" & lblMsgRequestID.Text & "','" & lblMsgEmailReply.Text & "','" & lblMsgTitle.Text & "','" & lblMsgEmailErr.Text & "','" & lblMsgRequest.Text & "');")
            btnDeleteRequest.Attributes.Add("OnClick", "javascript:document.forms[0].reset();ResetCtlValue();return false;")
            txtMaxCost.Attributes.Add("onchange", "javascript:if(!CheckNumBer(this,'" & lblMsgNotNum.Text & "')) {return false;}")
        End Sub

        ' BindData
        Private Sub BindData()
            Dim tblTemp As DataTable

            ' Bind data for ddlPostDelivCountry
            objBCommonDBSystem.SQLStatement = "SELECT * FROM  CAT_DIC_COUNTRY ORDER BY ISOCode"
            tblTemp = objBCommonDBSystem.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlPostDelivCountry.DataSource = tblTemp
                ddlPostDelivCountry.DataTextField = "DisplayEntry"
                ddlPostDelivCountry.DataValueField = "ID"
                ddlPostDelivCountry.DataBind()
                ' Bind data for ddlBillDelivCountry
                ddlBillDelivCountry.DataSource = tblTemp
                ddlBillDelivCountry.DataTextField = "DisplayEntry"
                ddlBillDelivCountry.DataValueField = "ID"
                ddlBillDelivCountry.DataBind()
            End If
            ' Bind data for ddlMedium
            tblTemp = Nothing
            objBCommonDBSystem.SQLStatement = "SELECT * FROM  ILL_MEDIUM_TYPES ORDER BY ID"
            tblTemp = objBCommonDBSystem.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlMedium.DataSource = tblTemp
                ddlMedium.DataTextField = "Medium"
                ddlMedium.DataValueField = "ID"
                ddlMedium.DataBind()
            End If
            ' Bind data for ddlPaymentType
            tblTemp = Nothing
            objBCommonDBSystem.SQLStatement = "SELECT * FROM ILL_PAYMENT_TYPES ORDER BY ID"
            tblTemp = objBCommonDBSystem.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlPaymentType.DataSource = tblTemp
                ddlPaymentType.DataTextField = "PaymentType"
                ddlPaymentType.DataValueField = "ID"
                ddlPaymentType.DataBind()
            End If
        End Sub
        Private Sub SetEnableControlLib(ByVal blnAct As Boolean)
            txtRequesterName.Enabled = blnAct
            txtPostDelivName.Enabled = blnAct
            txtPostDelivXAddr.Enabled = blnAct
            txtPostDelivStreet.Enabled = blnAct
            txtPostDelivBox.Enabled = blnAct
            txtPostDelivCity.Enabled = blnAct
            txtPostDelivCode.Enabled = blnAct
            txtEmailReplyAddress.Enabled = blnAct
            txtTelephone.Enabled = blnAct
            txtBillDelivName.Enabled = blnAct
            txtBillDelivXAddr.Enabled = blnAct
            txtBillDelivStreet.Enabled = blnAct
            txtBillDelivBox.Enabled = blnAct
            txtBillDelivCity.Enabled = blnAct
            txtBillDelivCode.Enabled = blnAct
            txtEDelivTSAddr.Enabled = blnAct
            txtAccountNumber.Enabled = blnAct
            ddlPostDelivCountry.Enabled = blnAct
            ddlBillDelivCountry.Enabled = blnAct
            optFax.Enabled = blnAct
            optArielMIME.Enabled = blnAct
            optArielFTP.Enabled = blnAct
            If Not blnAct Then
                txtRequesterName.Text = ""
                txtPostDelivName.Text = ""
                txtPostDelivXAddr.Text = ""
                txtPostDelivStreet.Text = ""
                txtPostDelivBox.Text = ""
                txtPostDelivCity.Text = ""
                txtPostDelivCode.Text = ""
                txtEmailReplyAddress.Text = ""
                txtTelephone.Text = ""
                txtBillDelivName.Text = ""
                txtBillDelivXAddr.Text = ""
                txtBillDelivStreet.Text = ""
                txtBillDelivBox.Text = ""
                txtBillDelivCity.Text = ""
                txtBillDelivCode.Text = ""
                txtEDelivTSAddr.Text = ""
                txtAccountNumber.Text = ""
            End If
        End Sub
        Private Sub txtCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.TextChanged
            Dim dtbLib As DataTable
            objBCommonDBSystem.SQLStatement = "SELECT * FROM ILL_LIBRARIES WHERE Upper(Code) = '" & txtCode.Text.Trim.ToUpper & "'"
            dtbLib = objBCommonDBSystem.RetrieveItemInfor
            Call LoadDataLibInfo(dtbLib)
        End Sub

        Private Sub LoadDataLibInfo(ByVal dtbLib As DataTable)
            Dim intCount As Integer
            If Not dtbLib Is Nothing AndAlso dtbLib.Rows.Count > 0 Then
                txtRequesterSymbol.Text = dtbLib.Rows(0).Item("LibrarySymbol")
                txtRequesterName.Text = dtbLib.Rows(0).Item("LibraryName")
                If Not IsDBNull(dtbLib.Rows(0).Item("PostDelivName")) Then
                    txtPostDelivName.Text = dtbLib.Rows(0).Item("PostDelivName")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("PostDelivXAddr")) Then
                    txtPostDelivXAddr.Text = dtbLib.Rows(0).Item("PostDelivXAddr")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("PostDelivStreet")) Then
                    txtPostDelivStreet.Text = dtbLib.Rows(0).Item("PostDelivStreet")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("PostDelivBox")) Then
                    txtPostDelivBox.Text = dtbLib.Rows(0).Item("PostDelivBox")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("PostDelivCity")) Then
                    txtPostDelivCity.Text = dtbLib.Rows(0).Item("PostDelivCity")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("PostDelivCode")) Then
                    txtPostDelivCode.Text = dtbLib.Rows(0).Item("PostDelivCode")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("EmailReplyAddress")) Then
                    txtEmailReplyAddress.Text = dtbLib.Rows(0).Item("EmailReplyAddress")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("Telephone")) Then
                    txtTelephone.Text = dtbLib.Rows(0).Item("Telephone")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("BillDelivName")) Then
                    txtBillDelivName.Text = dtbLib.Rows(0).Item("BillDelivName")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("BillDelivXAddr")) Then
                    txtBillDelivXAddr.Text = dtbLib.Rows(0).Item("BillDelivXAddr")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("BillDelivStreet")) Then
                    txtBillDelivStreet.Text = dtbLib.Rows(0).Item("BillDelivStreet")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("BillDelivBox")) Then
                    txtBillDelivBox.Text = dtbLib.Rows(0).Item("BillDelivBox")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("BillDelivCity")) Then
                    txtBillDelivCity.Text = dtbLib.Rows(0).Item("BillDelivCity")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("BillDelivCode")) Then
                    txtBillDelivCode.Text = dtbLib.Rows(0).Item("BillDelivCode")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("EDelivTSAddr")) Then
                    txtEDelivTSAddr.Text = dtbLib.Rows(0).Item("EDelivTSAddr")
                End If
                If Not IsDBNull(dtbLib.Rows(0).Item("AccountNumber")) Then
                    txtAccountNumber.Text = dtbLib.Rows(0).Item("AccountNumber")
                End If
                'hidLibID.Value = dtbLib.Rows(0).Item("ID")
                For intCount = 0 To ddlPostDelivCountry.Items.Count - 1
                    If ddlPostDelivCountry.SelectedValue = dtbLib.Rows(0).Item("PostDelivCountry") Then
                        ddlPostDelivCountry.SelectedIndex = intCount
                        Exit For
                    End If
                Next
                For intCount = 0 To ddlBillDelivCountry.Items.Count - 1
                    If ddlBillDelivCountry.SelectedValue = dtbLib.Rows(0).Item("BillDelivCountry") Then
                        ddlBillDelivCountry.SelectedIndex = intCount
                        Exit For
                    End If
                Next
                optArielFTP.Checked = True
                If Not IsDBNull(dtbLib.Rows(0).Item("EDelivMode")) Then
                    If dtbLib.Rows(0).Item("EDelivMode") = "Fax" Then
                        optFax.Checked = True
                    ElseIf dtbLib.Rows(0).Item("EDelivMode") = "Ariel MIME" Then
                        optArielMIME.Checked = True
                    End If
                End If
            Else
                txtRequesterSymbol.Text = ""
                txtRequesterName.Text = ""
                txtPostDelivName.Text = ""
                txtPostDelivXAddr.Text = ""
                txtPostDelivStreet.Text = ""
                txtPostDelivBox.Text = ""
                txtPostDelivCity.Text = ""
                txtPostDelivCode.Text = ""
                txtEmailReplyAddress.Text = ""
                txtTelephone.Text = ""
                txtBillDelivName.Text = ""
                txtBillDelivXAddr.Text = ""
                txtBillDelivStreet.Text = ""
                txtBillDelivBox.Text = ""
                txtBillDelivCity.Text = ""
                txtBillDelivCode.Text = ""
                txtEDelivTSAddr.Text = ""
                txtAccountNumber.Text = ""
            End If
        End Sub

        Private Sub btnSendRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendRequest.Click
            Dim strBillDelivName As String
            Dim strBillDelivXAddress As String
            Dim strBillDelivStreet As String
            Dim strBillDelivBox As String
            Dim strBillDelivCity As String
            Dim strBillDelivCountry As String
            Dim strBillDelivCode As String
            Dim strBillDelivRegion As String
            Dim blnCheckExist As Boolean = False

            If cbxBillDelivEqualPostDeliv.Checked Then
                strBillDelivName = txtPostDelivName.Text
                strBillDelivXAddress = txtPostDelivXAddr.Text
                strBillDelivStreet = txtPostDelivStreet.Text
                strBillDelivBox = txtPostDelivBox.Text
                strBillDelivCity = txtPostDelivCity.Text
                strBillDelivCountry = ddlPostDelivCountry.SelectedValue
                strBillDelivCode = txtPostDelivCode.Text
                strBillDelivRegion = ""
            Else
                strBillDelivName = txtBillDelivName.Text
                strBillDelivXAddress = txtBillDelivXAddr.Text
                strBillDelivStreet = txtBillDelivStreet.Text
                strBillDelivBox = txtBillDelivBox.Text
                strBillDelivCity = txtBillDelivCity.Text
                strBillDelivCountry = ddlBillDelivCountry.SelectedValue
                strBillDelivCode = txtBillDelivCode.Text
                strBillDelivRegion = ""
            End If
            Dim strCode As String = ""
            Dim intDublicate As Integer
            Dim dtbLib As New DataTable
            objBCommonDBSystem.SQLStatement = "SELECT ID,Code FROM ILL_LIBRARIES WHERE Upper(LibrarySymbol) = '" & txtRequesterSymbol.Text.Trim.ToUpper & "' AND Upper(EmailReplyAddress) = '" & txtEmailReplyAddress.Text.Trim.ToUpper & "'"
            dtbLib = objBCommonDBSystem.RetrieveItemInfor
            objBOPACILLInComingReq.LibID = 0
            If Not dtbLib Is Nothing AndAlso dtbLib.Rows.Count > 0 Then
                strCode = dtbLib.Rows(0).Item("Code")
                objBOPACILLInComingReq.LibID = dtbLib.Rows(0).Item("ID")
                blnCheckExist = True
            End If
            If strCode = "" Then
                Randomize()
                strCode = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                objBCommonDBSystem.SQLStatement = "SELECT Code FROM ILL_LIBRARIES WHERE Upper(Code) = '" & strCode.ToUpper & "'"
                dtbLib = objBCommonDBSystem.RetrieveItemInfor
                If Not dtbLib Is Nothing AndAlso dtbLib.Rows.Count > 0 Then
                    While dtbLib.Rows.Count <> 0
                        strCode = Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
                        objBCommonDBSystem.SQLStatement = "SELECT Code FROM ILL_LIBRARIES WHERE Upper(Code) = '" & strCode.ToUpper & "'"
                        dtbLib = objBCommonDBSystem.RetrieveItemInfor
                    End While
                End If
            End If
            objBOPACILLInComingReq.Code = strCode
            objBOPACILLInComingReq.RequestID = txtRequestID.Text.Trim
            objBOPACILLInComingReq.LibrarySymbol = txtRequesterSymbol.Text
            objBOPACILLInComingReq.LibraryName = txtRequesterName.Text
            objBOPACILLInComingReq.PostDelivName = txtPostDelivName.Text
            objBOPACILLInComingReq.PostDelivXAddr = txtPostDelivXAddr.Text
            objBOPACILLInComingReq.PostDelivStreet = txtPostDelivStreet.Text
            objBOPACILLInComingReq.PostDelivBox = txtPostDelivBox.Text
            objBOPACILLInComingReq.PostDelivCity = txtPostDelivCity.Text
            objBOPACILLInComingReq.PostDelivRegion = ""
            objBOPACILLInComingReq.PostDelivCountry = ddlPostDelivCountry.SelectedValue
            objBOPACILLInComingReq.PostDelivCode = txtPostDelivCode.Text
            objBOPACILLInComingReq.Telephone = txtTelephone.Text
            objBOPACILLInComingReq.BillDelivName = strBillDelivName
            objBOPACILLInComingReq.BillDelivXAddr = strBillDelivXAddress
            objBOPACILLInComingReq.BillDelivStreet = strBillDelivStreet
            objBOPACILLInComingReq.BillDelivBox = strBillDelivBox
            objBOPACILLInComingReq.BillDelivCity = strBillDelivCity
            objBOPACILLInComingReq.BillDelivRegion = strBillDelivRegion
            objBOPACILLInComingReq.BillDelivCountry = strBillDelivCountry
            objBOPACILLInComingReq.BillDelivCode = strBillDelivCode
            objBOPACILLInComingReq.AccountNumber = txtAccountNumber.Text
            objBOPACILLInComingReq.Dublicate = intDublicate
            objBOPACILLInComingReq.Priority = ddlPriority.SelectedValue
            objBOPACILLInComingReq.CurrencyCode = txtCurrencyCode.Text
            objBOPACILLInComingReq.PaymentType = ddlPaymentType.SelectedValue
            objBOPACILLInComingReq.ItemType = ddlItemType.SelectedValue
            objBOPACILLInComingReq.Medium = ddlMedium.SelectedValue
            If optLend.Checked Then
                objBOPACILLInComingReq.ServiceType = 1
            Else
                objBOPACILLInComingReq.ServiceType = 2
            End If
            If optCCG.Checked Then
                objBOPACILLInComingReq.CopyrightCompliance = 1
            Else
                objBOPACILLInComingReq.CopyrightCompliance = 2
            End If
            If optFax.Checked Then
                objBOPACILLInComingReq.EDelivMode = "Fax"
            ElseIf optArielMIME.Checked Then
                objBOPACILLInComingReq.EDelivMode = "Ariel MIME"
            Else
                objBOPACILLInComingReq.EDelivMode = "Ariel FTP"
            End If
            objBOPACILLInComingReq.EDelivTSAddr = txtEDelivTSAddr.Text
            objBOPACILLInComingReq.EmailReplyAddress = txtEmailReplyAddress.Text
            objBOPACILLInComingReq.Note = txtNote.Text
            objBOPACILLInComingReq.PatronName = txtPatronName.Text
            objBOPACILLInComingReq.PatronID = txtPatronID.Text
            objBOPACILLInComingReq.PatronStatus = "?"
            objBOPACILLInComingReq.Title = txtTitle.Text
            objBOPACILLInComingReq.NeedBeforeDate = txtNeedBeforeDate.Text
            objBOPACILLInComingReq.ExpiryDate = ""
            If txtMaxCost.Text <> "" Then
                objBOPACILLInComingReq.MaxCost = txtMaxCost.Text
            End If
            objBOPACILLInComingReq.Status = 21
            objBOPACILLInComingReq.ReciprocalAgreement = cbxReciprocalAgreement.Checked
            objBOPACILLInComingReq.WillPayFee = cbxWillPayFee.Checked
            objBOPACILLInComingReq.PaymentProvided = cbxPaymentProvided.Checked
            If txtPostDelivName.Text <> "" Then
                objBOPACILLInComingReq.DelivMode = 2
            Else
                objBOPACILLInComingReq.DelivMode = 1
            End If
            objBOPACILLInComingReq.CallNumber = txtCallNumber.Text
            objBOPACILLInComingReq.Author = txtAuthor.Text
            objBOPACILLInComingReq.PlaceOfPub = txtPlaceOfPub.Text
            objBOPACILLInComingReq.Publisher = txtPublisher.Text
            objBOPACILLInComingReq.SeriesTitleNumber = txtSeriesTitleNumber.Text
            objBOPACILLInComingReq.VolumeIssue = txtVolumeIssue.Text
            objBOPACILLInComingReq.Edition = txtEdition.Text
            objBOPACILLInComingReq.PubDate = txtPubDate.Text
            objBOPACILLInComingReq.ComponentPubDate = txtComponentPubDate.Text
            objBOPACILLInComingReq.ArticleAuthor = txtArticleAuthor.Text
            objBOPACILLInComingReq.ArticleTitle = txtArticleTitle.Text
            objBOPACILLInComingReq.Pagination = txtPagination.Text
            objBOPACILLInComingReq.NationalBibNumber = txtNationalBibNumber.Text
            objBOPACILLInComingReq.ISBN = txtISBN.Text
            objBOPACILLInComingReq.ISSN = txtISSN.Text
            objBOPACILLInComingReq.SystemNumber = "?"
            objBOPACILLInComingReq.OtherNumbers = txtOtherNumbers.Text
            objBOPACILLInComingReq.Verification = txtVerification.Text
            objBOPACILLInComingReq.EncodingScheme = ddlEncodingSchema.SelectedValue
            Dim intRetval As Integer
            intRetval = objBOPACILLInComingReq.CreateRequest()
            If intRetval > 0 Then
                hidReset.Value = 1
                Page.RegisterClientScriptBlock("CreateSuccess", "<Script language='JavaScript'>alert('" & lblMsgUpdateSuccess.Text & "');</Script>")
                If Not blnCheckExist Then
                    Response.Write("<Font size=3><B>" & lblMsgUpdateSuccess.Text & "</B></FONT>")
                    Response.Write("<BR>" & lblDisIDRequest.Text & " <B><Font color='red'>" & objBOPACILLInComingReq.RequestID & "</Font></B><br><hr>")
                    Response.Write(lblDisAssignUD.Text & " <B><Font color='red'>" & objBOPACILLInComingReq.Code & "</Font color='red'></B><br>")
                    Response.Write(lblDisTutorial.Text)
                    Response.End()
                End If
            Else
                Page.RegisterClientScriptBlock("CreateFail", "<Script language='JavaScript'>alert('" & lblMsgUpdateFail.Text & "')</Script>")
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACILLInComingReq Is Nothing Then
                    objBOPACILLInComingReq.Dispose(True)
                    objBOPACILLInComingReq = Nothing
                End If
                If Not objBCommonStringProc Is Nothing Then
                    objBCommonStringProc.Dispose(True)
                    objBCommonStringProc = Nothing
                End If
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace