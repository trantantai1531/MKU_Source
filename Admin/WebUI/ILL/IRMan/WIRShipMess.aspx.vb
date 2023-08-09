' class WIRShipMess.aspx
' Puspose: 
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:
' Add : lent 13/12/2004
' Review code : lent 26-4-2005

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WIRShipMess
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnAddressRepay As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBILLInRequest As New clsBILLInRequest
        Private objBPaymentType As New clsBPaymentType
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBPhyDelAddress As New clsBPhyDelAddress
        Private objBPhysDelMode As New clsBPhysDelMode
        Private objBCDBS As New clsBCommonDBSystem

        ' Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBILLInRequest object
            objBILLInRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLInRequest.DBServer = Session("DBServer")
            objBILLInRequest.ConnectionString = Session("ConnectionString")
            Call objBILLInRequest.Initialize()
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(153) Then
                Page.RegisterClientScriptBlock("AccessDeniedJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
                Response.End()
            End If
        End Sub

        ' InitialClassMore method
        ' Purpose : Init more class for get data to form
        Private Sub InitialClassMore()
            ' Init objBPaymentType object
            objBPaymentType.InterfaceLanguage = Session("InterfaceLanguage")
            objBPaymentType.DBServer = Session("DBServer")
            objBPaymentType.ConnectionString = Session("ConnectionString")
            Call objBPaymentType.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()

            ' Init objBPhyDelAddress object
            objBPhyDelAddress.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhyDelAddress.DBServer = Session("DBServer")
            objBPhyDelAddress.ConnectionString = Session("ConnectionString")
            Call objBPhyDelAddress.Initialize()

            ' Init objBPhysDelMode object
            objBPhysDelMode.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhysDelMode.DBServer = Session("DBServer")
            objBPhysDelMode.ConnectionString = Session("ConnectionString")
            Call objBPhysDelMode.Initialize()

            ' Init objBPhysDelMode object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("IRMainJS", "<script language = 'javascript' src = '../Js/IRMan/WIRMan.js'></script>")
            Page.RegisterClientScriptBlock("IRSelfJS", "<script language = 'javascript' src = '../Js/IRMan/WIRShipMess.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkProvidedDate, txtProvidedDate, ddlLabel.Items(8).Text)
            SetOnclickCalendar(lnkDueDate, txtDueDate, ddlLabel.Items(8).Text)
            btnNoSend.Attributes.Add("Onclick", "javascript:self.close()")
            txtProvidedDate.Text = Session("ToDay")
            Me.SetCheckNumber(txtInsuredForCost, ddlLabel.Items(9).Text, "")
            Me.SetCheckNumber(txtCost, ddlLabel.Items(9).Text, "")
            Me.SetCheckNumber(txtReturnInsuranceCost, ddlLabel.Items(9).Text, "")
        End Sub

        ' BindData method
        ' Purpose : get data to form
        Private Sub BindData()
            Dim intIllID As Integer = 0
            Dim intPaymentType, intServiceType As Integer
            Dim i As Integer
            Dim tblResult As DataTable

            If Request("ILLID") & "" <> "" Then
                intIllID = CInt(Request("ILLID"))
            End If
            hidILLID.Value = intIllID
            objBILLInRequest.ILLID = intIllID
            tblResult = objBILLInRequest.GetIRInfor
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                RequesterID.Value = CStr(tblResult.Rows(0).Item("RequesterID"))
                RespondDate.Value = CStr(tblResult.Rows(0).Item("RESPONDDATE"))
                If Not IsDBNull(tblResult.Rows(0).Item("PaymentType")) Then
                    intPaymentType = CInt(tblResult.Rows(0).Item("PaymentType"))
                Else
                    intPaymentType = 0
                End If
                If Not IsDBNull(tblResult.Rows(0).Item("ServiceType")) Then
                    intServiceType = CInt(tblResult.Rows(0).Item("ServiceType"))
                Else
                    intServiceType = 1
                End If


                If CInt(tblResult.Rows(0).Item("Status")) <> 3 And CInt(tblResult.Rows(0).Item("Status")) <> 21 Then
                    Page.RegisterClientScriptBlock("ViewMsg2", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');self.close();</script>")
                Else
                    Call InitialClassMore()
                    'get data
                    tblResult = Nothing
                    objBILLInRequest.IDs = "22,23,24,25,27"
                    tblResult = objBILLInRequest.GetIllResponse
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

                    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                        ddlCondition.DataSource = tblResult
                        ddlCondition.DataTextField = "Condition"
                        ddlCondition.DataValueField = "ID"
                        ddlCondition.DataBind()
                    End If
                    tblResult = Nothing
                    tblResult = objBPaymentType.GetPaymentType
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPaymentType.ErrorMsg, ddlLabel.Items(1).Text, objBPaymentType.ErrorCode)

                    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                        ddlPaymentType.DataSource = tblResult
                        ddlPaymentType.DataTextField = "PaymentType"
                        ddlPaymentType.DataValueField = "ID"
                        ddlPaymentType.DataBind()
                        For i = 0 To ddlPaymentType.Items.Count - 1
                            If ddlPaymentType.Items(i).Value = intPaymentType Then
                                ddlPaymentType.Items(i).Selected = True
                                Exit For
                            End If
                        Next
                    End If

                    tblResult = Nothing
                    tblResult = objBCommonBusiness.GetCurrency
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

                    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                        ddlCurrencyCode1.DataSource = tblResult
                        ddlCurrencyCode1.DataTextField = "CurrencyCode"
                        ddlCurrencyCode1.DataValueField = "CurrencyCode"
                        ddlCurrencyCode1.DataBind()

                        ddlCurrencyCode2.DataSource = ddlCurrencyCode1.DataSource
                        ddlCurrencyCode2.DataTextField = "CurrencyCode"
                        ddlCurrencyCode2.DataValueField = "CurrencyCode"
                        ddlCurrencyCode2.DataBind()

                        ddlCurrencyCode3.DataSource = ddlCurrencyCode1.DataSource
                        ddlCurrencyCode3.DataTextField = "CurrencyCode"
                        ddlCurrencyCode3.DataValueField = "CurrencyCode"
                        ddlCurrencyCode3.DataBind()
                    End If

                    tblResult = Nothing
                    tblResult = objBPhyDelAddress.GetPhyDelAddr
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPhyDelAddress.ErrorMsg, ddlLabel.Items(1).Text, objBPhyDelAddress.ErrorCode)

                    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                        ddlReturnPhysicalAddress.DataSource = tblResult
                        ddlReturnPhysicalAddress.DataTextField = "Address"
                        ddlReturnPhysicalAddress.DataValueField = "ID"
                        ddlReturnPhysicalAddress.DataBind()
                    End If

                    tblResult = Nothing
                    tblResult = objBPhysDelMode.GetPhyDelMode
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPhysDelMode.ErrorMsg, ddlLabel.Items(1).Text, objBPhysDelMode.ErrorCode)

                    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                        ddlTransportationModeID.DataSource = tblResult
                        ddlTransportationModeID.DataTextField = "DeliveryMode"
                        ddlTransportationModeID.DataValueField = "ID"
                        ddlTransportationModeID.DataBind()
                    End If

                    objBCDBS.SQLStatement = "Select * from ILL_SERVICE_TYPES order by ID"
                    tblResult = Nothing
                    tblResult = objBCDBS.RetrieveItemInfor
                    If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                        ddlServiceType.DataSource = tblResult
                        ddlServiceType.DataTextField = "ServiceDisplay"
                        ddlServiceType.DataValueField = "ID"
                        ddlServiceType.DataBind()
                        For i = 0 To tblResult.Rows.Count - 1
                            If tblResult.Rows(i).Item("ID") = intServiceType Then
                                ddlServiceType.SelectedIndex = i
                                Exit For
                            End If
                        Next
                    End If
                End If
            Else
                Page.RegisterClientScriptBlock("ViewMsg1", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');self.close();</script>")
            End If
        End Sub

        ' Event : btnSend_Click
        ' Data proccess and send email action
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Dim strProvidedDate As String = ""
            Dim strDueDate As String = ""
            Dim dbCost As Double = 0
            Dim dbInsuredForCost As Double = 0
            Dim dbReturnInsuranceCost As Double = 0
            Dim bitRenewable As Byte = 0
            Dim intChargeableUnits As Integer = 0
            Dim intServiceType As Integer = 0
            Dim intDelivConditionID As Integer = 0
            Dim intPaymentType As Integer = 0
            Dim strInternalRefNumber As String = ""
            Dim strCurrencyCode1 As String = ""
            Dim strCurrencyCode2 As String = ""
            Dim strCurrencyCode3 As String = ""
            Dim intReturnLocID As Integer = 0
            Dim intTransportationModeID As Integer = 0
            Dim strBarcode As String = ""
            Dim intIllID As Integer = 0
            Dim strRespondDate As String = ""
            Dim intRequesterID As Integer = 0
            Dim strNote As String = ""
            Dim strContent As String = ""
            Dim intSuccess As Integer = 0
            Dim blnSendMail As Boolean = False
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String
            Dim intSendMail As Int16 = 0

            'get request from form submit
            intIllID = CInt(hidILLID.Value)
            If RequesterID.Value <> "" Then
                intRequesterID = CInt(RequesterID.Value)
            End If
            If txtNote.Text <> "" Then
                strNote = txtNote.Text
            End If
            If RespondDate.Value <> "" Then
                strRespondDate = RespondDate.Value
            Else
                strRespondDate = DayOfNow()
            End If

            intServiceType = ddlServiceType.SelectedValue
            If txtProvidedDate.Text <> "" Then
                strProvidedDate = txtProvidedDate.Text
            Else
                strProvidedDate = "NULL"
            End If
            If txtDueDate.Text <> "" Then
                strDueDate = txtDueDate.Text
            Else
                strDueDate = "NULL"
            End If
            bitRenewable = 0
            If cbkRenewable.Checked Then
                bitRenewable = 1
            End If
            intDelivConditionID = ddlCondition.SelectedValue
            intPaymentType = ddlPaymentType.SelectedValue
            If txtChargeableUnit.Text <> "" Then
                intChargeableUnits = CInt(txtChargeableUnit.Text)
            Else
                intChargeableUnits = 0
            End If
            strInternalRefNumber = txtInternalRefNumber.Text
            If Trim(txtCost.Text) <> "" Then
                dbCost = CDbl(Trim(txtCost.Text))
            Else
                dbCost = -2 'set dbCost=NULL in database
            End If
            strCurrencyCode1 = ddlCurrencyCode1.SelectedValue
            If Trim(txtInsuredForCost.Text) <> "" Then
                dbInsuredForCost = CDbl(Trim(txtInsuredForCost.Text))
            Else
                dbInsuredForCost = -2
            End If
            strCurrencyCode2 = ddlCurrencyCode2.SelectedValue
            If Trim(txtReturnInsuranceCost.Text) <> "" Then
                dbReturnInsuranceCost = CDbl(Trim(txtReturnInsuranceCost.Text))
            Else
                dbReturnInsuranceCost = -2
            End If
            strCurrencyCode3 = ddlCurrencyCode3.SelectedValue
            intReturnLocID = ddlReturnPhysicalAddress.SelectedValue
            intTransportationModeID = ddlTransportationModeID.SelectedValue
            strBarcode = txtBarcode.Text

            'set value for update Ill_incomming_request for shipping
            Call objBILLInRequest.InitVariables()
            objBILLInRequest.ILLID = intIllID
            objBILLInRequest.Status = 8
            objBILLInRequest.ShippedDate = strProvidedDate
            objBILLInRequest.RespondDate = strRespondDate
            objBILLInRequest.Renewable = bitRenewable
            objBILLInRequest.DueDate = strDueDate
            objBILLInRequest.Renewals = 0
            objBILLInRequest.ServiceType = intServiceType
            objBILLInRequest.Cost = dbCost
            objBILLInRequest.CurrencyCode1 = strCurrencyCode1
            objBILLInRequest.InsuredForCost = dbInsuredForCost
            objBILLInRequest.CurrencyCode2 = strCurrencyCode2
            objBILLInRequest.ReturnInsuranceCost = dbReturnInsuranceCost
            objBILLInRequest.CurrencyCode3 = strCurrencyCode3
            objBILLInRequest.ChargeableUnits = intChargeableUnits
            objBILLInRequest.PaymentType = intPaymentType
            objBILLInRequest.Barcode = strBarcode
            objBILLInRequest.InternalRefNumber = strInternalRefNumber
            objBILLInRequest.ReturnLocID = intReturnLocID
            objBILLInRequest.TransportationModeID = intTransportationModeID
            objBILLInRequest.DelivConditionID = intDelivConditionID
            objBILLInRequest.BoolSQL = "Status IN (21, 3)"
            intSuccess = objBILLInRequest.UpdateIR
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

            If intSuccess > 0 Then
                'set value for insert a new record into Ill_incomming_request_log
                Call objBILLInRequest.InitVariables()
                objBILLInRequest.ILLID = intIllID
                objBILLInRequest.RequesterID = intRequesterID
                objBILLInRequest.ProvidedDate = strProvidedDate
                objBILLInRequest.APDUType = 3
                objBILLInRequest.ReasonID = intDelivConditionID
                objBILLInRequest.Note = strNote
                objBILLInRequest.Alert = 0
                objBILLInRequest.Cost = dbCost
                objBILLInRequest.CurrencyCode1 = strCurrencyCode1
                objBILLInRequest.InsuredForCost = dbInsuredForCost
                objBILLInRequest.CurrencyCode2 = strCurrencyCode2
                objBILLInRequest.ReturnInsuranceCost = dbReturnInsuranceCost
                objBILLInRequest.CurrencyCode3 = strCurrencyCode3
                objBILLInRequest.Renewable = bitRenewable
                objBILLInRequest.DueDate = strDueDate
                objBILLInRequest.ServiceType = intServiceType
                intSuccess = objBILLInRequest.InsertIRequestLog()
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)
            End If
            If intSuccess > 0 Then
                ' WriteLog
                Call WriteLog(65, lblHeader.Text & ": ILLID=" & hidILLID.Value, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                strContent = objBILLInRequest.ShipedXmlRecord(strNote)

                blnSendMail = objBILLInRequest.GetEmailInfor(Server.MapPath(""), intRequesterID, strContent, strMailFrom, strMailTo, strContentOut)
                EncodeILLError(objBILLInRequest.EncodeOk)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLInRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLInRequest.ErrorCode)

                If Not blnSendMail Then
                    Page.RegisterClientScriptBlock("ViewMsg4", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
                Else
                    intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)

                    If intSendMail = 0 Then
                        Page.RegisterClientScriptBlock("ViewMsg3", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("ViewMsg4", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
                    End If
                End If
            Else
                Page.RegisterClientScriptBlock("ViewMsg5", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WIRMan.aspx';self.close();</script>")
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLInRequest Is Nothing Then
                    objBILLInRequest.Dispose(True)
                    objBILLInRequest = Nothing
                End If
                If Not objBPaymentType Is Nothing Then
                    objBPaymentType.Dispose(True)
                    objBPaymentType = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBPhyDelAddress Is Nothing Then
                    objBPhyDelAddress.Dispose(True)
                    objBPhyDelAddress = Nothing
                End If
                If Not objBPhysDelMode Is Nothing Then
                    objBPhysDelMode.Dispose(True)
                    objBPhysDelMode = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
