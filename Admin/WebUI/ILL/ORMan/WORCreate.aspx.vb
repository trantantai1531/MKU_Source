Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORCreate
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtCreatedDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents hrfCreatedDate As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblCreatedDate As System.Web.UI.WebControls.Label
        Protected WithEvents lblChange As System.Web.UI.WebControls.Label
        Protected WithEvents hrfPatronCode As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBILLOutR As New clsBILLOutRequest
        Private objBILLLib As New clsBILLLibrary
        Private objBCopyRight As New clsBCopyRightCompliance
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBPhyDelMode As New clsBPhysDelMode
        Private objBPhyDelAddr As New clsBPhyDelAddress
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()

            If Not Page.IsPostBack Then
                Call BindData()
                If Not Request.QueryString("ILLID") Is Nothing And Not Request.QueryString("ILLID") = "" Then
                    hdILLID.Value = Request.QueryString("ILLID")
                    If Not Request.QueryString("clone") Is Nothing And Not Request.QueryString("clone") = "" Then
                        hdClone.Value = Request.QueryString("clone")
                    End If
                    Call LoadData()
                End If
            End If

            If Not Request.QueryString("Create") Is Nothing Or Not Request.QueryString("Create") = "" Then
                Call CreateOR()
            Else
                If Not Request.QueryString("Update") Is Nothing Or Not Request.QueryString("Update") = "" Then
                    If hdClone.Value = 1 Then ' Nhan ban
                        Call CreateOR()
                    Else ' Cap nhat
                        If hdUpdateFlage.Value = 1 Then
                            Call UpdateOR()
                        End If
                    End If
                End If
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Call WriteErrorMssg(ddlLabel.Items(14).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()

            ' Initilaize objBPhyDelAddr object
            objBPhyDelAddr.ConnectionString = Session("ConnectionString")
            objBPhyDelAddr.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhyDelAddr.DBServer = Session("DBServer")
            Call objBPhyDelAddr.Initialize()

            ' Initilaize objBILLOutR object
            objBILLOutR.ConnectionString = Session("ConnectionString")
            objBILLOutR.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutR.DBServer = Session("DBServer")
            objBILLOutR.Initialize()

            ' Initilaize objBILLLib object
            objBILLLib.ConnectionString = Session("ConnectionString")
            objBILLLib.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLLib.DBServer = Session("DBServer")
            objBILLLib.Initialize()

            ' Initilaize objBCopyRight object
            objBCopyRight.ConnectionString = Session("ConnectionString")
            objBCopyRight.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyRight.DBServer = Session("DBServer")
            objBCopyRight.Initialize()

            ' Initilaize objBCommonBusiness object
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.Initialize()

            ' Initilaize objBPhyDelMode object
            objBPhyDelMode.ConnectionString = Session("ConnectionString")
            objBPhyDelMode.InterfaceLanguage = Session("InterfaceLanguage")
            objBPhyDelMode.DBServer = Session("DBServer")
            objBPhyDelMode.Initialize()

            ' objBCDBS
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.Initialize()

        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ORCreateJs", "<script language='javascript' src='../JS/ORMan/WORCreate.js'></script>")

            ddlSymbol.Attributes.Add("OnChange", "javascript:if(this.value>0){ResetSymbol(); parent.Hiddenbase.location.href='WORCreateHidden.aspx?ILLLibID='+this.value;}return(false);")
            ddlDelivMode2.Attributes.Add("OnChange", "javascript:if(this.value>0){ResetDelivMode2(); parent.Hiddenbase.location.href='WORCreateHidden.aspx?DelivModeID='+this.value;}return(false);")
            ddlBillDelivName.Attributes.Add("OnChange", "javascript:if(this.value>0){ResetBillDelivName(); parent.Hiddenbase.location.href='WORCreateHidden.aspx?BillDelivNameID='+this.value;}return(false);")
            txtLibName.Attributes.Add("OnChange", "javascript:if(this.value==''){alert('" & ddlLabel.Items(4).Text & "');document.forms[0].txtLibName.focus();}")
            txtEmailIP.Attributes.Add("OnChange", "javascript:if(this.value==''){alert('" & ddlLabel.Items(5).Text & "');document.forms[0].txtEmailIP.focus();}")
            txtComponentPubDate.Attributes.Add("OnChange", "javascript:if(!CheckDate('document.forms[0].txtComponentPubDate','" & Session("DateFormat") & "','" & ddlLabel.Items(11).Text & "')){document.forms[0].txtComponentPubDate.focus();}")
            txtMaxCost.Attributes.Add("OnChange", "javascript:if(this.value !='' && isNaN(this.value)){alert('" & ddlLabel.Items(10).Text & "');document.forms[0].txtMaxCost.focus();}")
            txtTitle.Attributes.Add("OnChange", "javascript:if(this.value==''){alert('" & ddlLabel.Items(8).Text & "');document.forms[0].txtTitle.focus();}")
            txtPatronCode.Attributes.Add("OnChange", "javascript:if(this.value==''){alert('" & ddlLabel.Items(9).Text & "');document.forms[0].txtPatronCode.focus();} else {parent.Hiddenbase.location.href='WORCreateHidden.aspx?PatronCode='+this.value;}")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(hrfNeedBeforeDate, txtNeedBeforeDate, ddlLabel.Items(11).Text)
            SetOnclickCalendar(hrfExpiredDate, txtExpiredDate, ddlLabel.Items(11).Text)
            SetOnclickCalendar(hrfComponentPubDate, txtComponentPubDate, ddlLabel.Items(11).Text)
            hrfSearchPatron.NavigateUrl = "javascript:OpenPatron();"
            lnkZ3950.Attributes.Add("OnClick", "OpenWindow('../../Common/WZForm.aspx','ZWin',700,360,50,100); return false;")

        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblILLLib As New DataTable
            Dim tblCopyRight As New DataTable
            Dim tblCurrency As New DataTable
            Dim tblItemType As New DataTable
            Dim tblLocalLib As New DataTable
            Dim tblELocalLib As New DataTable
            Dim tblPatronGroup As New DataTable
            Dim tblCountry As New DataTable
            Dim tblMedium As New DataTable
            Dim tblTemp As DataTable

            ' Bind ILL Libraries
            Try
                objBILLLib.LibID = 0
                tblILLLib = objBILLLib.GetLib
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLLib.ErrorMsg, ddlLabel.Items(1).Text, objBILLLib.ErrorCode)

                If Not tblILLLib Is Nothing Then
                    tblILLLib = InsertOneRow(tblILLLib, "--------------")
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                End If

                If Not tblILLLib Is Nothing Then
                    If tblILLLib.Rows.Count > 0 Then
                        ddlSymbol.DataSource = tblILLLib
                        ddlSymbol.DataTextField = "LibrarySymbol"
                        ddlSymbol.DataValueField = "ID"
                        ddlSymbol.DataBind()
                        ddlSymbol.Items(0).Value = 0
                        ddlSymbol.Items(0).Selected = True
                    End If
                End If
            Catch ex As Exception
            End Try

            ' Bind CopyRight
            Try
                objBCopyRight.ID = 0
                tblCopyRight = objBCopyRight.GetCopyright

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCopyRight.ErrorMsg, ddlLabel.Items(1).Text, objBCopyRight.ErrorCode)

                If Not tblCopyRight Is Nothing Then
                    tblCopyRight = InsertOneRow(tblCopyRight, "-----------")
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                End If

                If Not tblCopyRight Is Nothing Then
                    If tblCopyRight.Rows.Count > 0 Then
                        ddlCopyrightCompliance.DataSource = tblCopyRight
                        ddlCopyrightCompliance.DataTextField = "CopyrightCompliance"
                        ddlCopyrightCompliance.DataValueField = "ID"
                        ddlCopyrightCompliance.DataBind()
                        ddlCopyrightCompliance.Items(0).Value = 0
                        ddlCopyrightCompliance.Items(0).Selected = True
                    End If
                End If
            Catch ex As Exception
            End Try

            ' Bind Currency
            Try
                objBCommonBusiness.CurrencyCode = ""
                tblCurrency = objBCommonBusiness.GetCurrency
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

                If Not tblCurrency Is Nothing Then
                    tblCurrency = InsertOneRow(tblCurrency, "------------")
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                End If

                If Not tblCurrency Is Nothing Then
                    If tblCurrency.Rows.Count > 0 Then
                        ddlCurrency.DataSource = tblCurrency
                        ddlCurrency.DataTextField = "CurrencyCode"
                        ddlCurrency.DataValueField = "CurrencyCode"
                        ddlCurrency.DataBind()
                        ddlCurrency.Items(0).Value = ""
                        ddlCurrency.Items(0).Selected = True
                    End If
                End If
            Catch ex As Exception
            End Try

            ' Bind ill service type
            objBCDBS.SQLStatement = "Select * from ILL_SERVICE_TYPES order by ID"
            tblTemp = objBCDBS.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlServiceType.DataSource = tblTemp
                ddlServiceType.DataTextField = "ServiceDisplay"
                ddlServiceType.DataValueField = "ID"
                ddlServiceType.DataBind()
                ddlServiceType.SelectedIndex = 0
            End If

            ' Bind ill service type
            tblTemp = Nothing
            objBCDBS.SQLStatement = "Select * from ILL_PAYMENT_TYPES order by ID"
            tblTemp = objBCDBS.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlPaymentType.DataSource = tblTemp
                ddlPaymentType.DataTextField = "PaymentType"
                ddlPaymentType.DataValueField = "ID"
                ddlPaymentType.DataBind()
                ddlPaymentType.SelectedIndex = 0
            End If

            ' Bind ILL Medium
            Try
                tblMedium = objBILLOutR.GetILLMediumTypes(0)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)

                If Not tblMedium Is Nothing Then
                    If tblMedium.Rows.Count > 0 Then
                        ddlMedium.DataSource = tblMedium
                        ddlMedium.DataTextField = "Medium"
                        ddlMedium.DataValueField = "ID"
                        ddlMedium.DataBind()
                        ddlMedium.Items(0).Selected = True
                    End If
                End If
            Catch ex As Exception
            End Try

            ' Bind ItemType
            Try
                If Session("DBServer") = "ORACLE" Then
                    objBCDBS.SQLStatement = "select ID, Types || ': ' || Description as Display from Ill_Item_types"
                Else
                    objBCDBS.SQLStatement = "select ID, Types + ': ' + Description as Display from Ill_Item_types"
                End If

                tblItemType = objBCDBS.RetrieveItemInfor
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)

                If Not tblItemType Is Nothing Then
                    If tblItemType.Rows.Count > 0 Then
                        ddlItemType.DataSource = tblItemType
                        ddlItemType.DataTextField = "Display"
                        ddlItemType.DataValueField = "ID"
                        ddlItemType.DataBind()
                        ddlItemType.SelectedIndex = 0
                    End If
                End If
            Catch ex As Exception
            End Try

            ' Bind Local Library
            Try
                objBPhyDelAddr.ID = 0
                tblTemp = objBPhyDelAddr.GetPhyDelAddr()

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPhyDelAddr.ErrorMsg, ddlLabel.Items(1).Text, objBPhyDelAddr.ErrorCode)

                If Not tblTemp Is Nothing Then
                    tblTemp = InsertOneRow(tblTemp, "-----------------")
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                End If

                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    ddlDelivMode2.DataSource = tblTemp
                    ddlDelivMode2.DataTextField = "Address"
                    ddlDelivMode2.DataValueField = "ID"
                    ddlDelivMode2.DataBind()
                    ddlDelivMode2.Items(0).Value = 0
                    ddlDelivMode2.Items(0).Selected = True
                End If
                tblTemp = Nothing
                objBPhyDelAddr.ID = 0
                tblTemp = objBPhyDelAddr.GetPhyDelAddr()
                If Not tblTemp Is Nothing Then
                    tblTemp = InsertOneRow(tblTemp, "-----------------")
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                End If
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    ddlBillDelivName.DataSource = tblTemp
                    ddlBillDelivName.DataTextField = "Address"
                    ddlBillDelivName.DataValueField = "ID"
                    ddlBillDelivName.DataBind()
                    ddlBillDelivName.Items(0).Value = 0
                    ddlBillDelivName.Items(0).Selected = True
                End If
            Catch ex As Exception
            End Try

            ' Bind Edelivery Local Library
            Try
                tblELocalLib = objBILLLib.GetELocalLib(0)

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLLib.ErrorMsg, ddlLabel.Items(1).Text, objBILLLib.ErrorCode)

                If Not tblELocalLib Is Nothing Then
                    If tblELocalLib.Rows.Count > 0 Then
                        lsbDelivMode1.DataSource = tblELocalLib
                        lsbDelivMode1.DataTextField = "EdelivTSAddr"
                        lsbDelivMode1.DataValueField = "ID"
                        lsbDelivMode1.DataBind()
                        lsbDelivMode1.Items(0).Selected = True
                    End If
                End If
            Catch ex As Exception

            End Try
            ' Bind Patron Group
            Try
                tblPatronGroup = objBILLOutR.GetPatronGroup(0)

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)

                If Not tblPatronGroup Is Nothing Then
                    tblPatronGroup = InsertOneRow(tblPatronGroup, "--------------")
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                End If

                If Not tblPatronGroup Is Nothing Then
                    If tblPatronGroup.Rows.Count > 0 Then
                        ddlPatronGroup.DataSource = tblPatronGroup
                        ddlPatronGroup.DataTextField = "Name"
                        ddlPatronGroup.DataValueField = "ID"
                        ddlPatronGroup.DataBind()
                        ddlPatronGroup.Items(0).Value = 0
                        ddlPatronGroup.Items(0).Selected = True
                    End If
                End If
            Catch ex As Exception
            End Try

            ' Bind Country
            Try
                tblCountry = objBCommonBusiness.GetCountries()
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

                If Not tblCountry Is Nothing Then
                    tblCountry = InsertOneRow(tblCountry, "---------------")
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                End If

                If Not tblCountry Is Nothing Then
                    If tblCountry.Rows.Count > 0 Then
                        ddlBillDelivCountry.DataSource = tblCountry
                        ddlBillDelivCountry.DataTextField = "DisplayEntry"
                        ddlBillDelivCountry.DataValueField = "ID"
                        ddlBillDelivCountry.DataBind()
                        ddlBillDelivCountry.Items(0).Value = 0
                        ddlBillDelivCountry.Items(0).Selected = True
                        ddlDelivCountry.DataSource = tblCountry
                        ddlDelivCountry.DataTextField = "DisplayEntry"
                        ddlDelivCountry.DataValueField = "ID"
                        ddlDelivCountry.DataBind()
                        ddlDelivCountry.Items(0).Value = 0
                        ddlDelivCountry.Items(0).Selected = True
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        ' LoadData method
        ' In: ILLID
        Private Sub LoadData()
            Dim tblILLOR As New DataTable
            Dim inti As Integer
            Dim lngResponderID As Long

            lngResponderID = 0
            objBILLOutR.IllID = hdILLID.Value

            tblILLOR = objBILLOutR.GetORInfor
            ' Write Error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)

            If Not tblILLOR Is Nothing Then
                If tblILLOR.Rows.Count > 0 Then
                    If Not IsDBNull(tblILLOR.Rows(0).Item("ResponderID")) And IsNumeric(tblILLOR.Rows(0).Item("ResponderID")) Then
                        lngResponderID = tblILLOR.Rows(0).Item("ResponderID")
                    End If
                End If
            End If

            'tblILLOR = Nothing

            'objBILLOutR.ID = CInt(hdILLID.Value)
            'If Request.QueryString("clone") = 1 Then  ' Doublicate
            '    'tblILLOR = objBILLOutR.GetORequestItems(1)
            '    ' Write Error
            '    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)
            'Else ' Update
            '    'tblILLOR = objBILLOutR.GetORequestItems(0)
            '    ' Write Error
            '    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)
            'End If

            If Not tblILLOR Is Nothing Then
                If tblILLOR.Rows.Count > 0 Then
                    ' Load data here
                    ' Library
                    For inti = 0 To ddlSymbol.Items.Count - 1
                        If ddlSymbol.Items(inti).Value = lngResponderID Then
                            ddlSymbol.Items(ddlSymbol.SelectedIndex).Selected = False
                            ddlSymbol.Items(inti).Selected = True
                            Exit For
                        End If
                    Next
                    If Not IsDBNull(tblILLOR.Rows(0).Item("LibraryName")) Then
                        txtLibName.Text = tblILLOR.Rows(0).Item("LibraryName")
                    End If
                    ' Lib Email
                    If Not IsDBNull(tblILLOR.Rows(0).Item("EmailReplyAddress")) Then
                        txtEmailIP.Text = tblILLOR.Rows(0).Item("EmailReplyAddress")
                    End If
                    ' Account
                    If Not IsDBNull(tblILLOR.Rows(0).Item("AccountNumber")) Then
                        txtAccount.Text = tblILLOR.Rows(0).Item("AccountNumber")
                    End If
                    ' Copyright Compliance
                    For inti = 0 To ddlCopyrightCompliance.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("CopyrightCompliance")) Then
                            If ddlCopyrightCompliance.Items(inti).Value = tblILLOR.Rows(0).Item("CopyrightCompliance") Then
                                ddlCopyrightCompliance.Items(ddlCopyrightCompliance.SelectedIndex).Selected = False
                                ddlCopyrightCompliance.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next
                    ' Priority
                    For inti = 0 To ddlPiroity.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("Priority")) Then
                            If ddlPiroity.Items(inti).Value = tblILLOR.Rows(0).Item("Priority") Then
                                ddlPiroity.Items(ddlPiroity.SelectedIndex).Selected = False
                                ddlPiroity.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next
                    ' Need before date
                    If Not IsDBNull(tblILLOR.Rows(0).Item("NEEDBEFOREDATE")) Then
                        txtNeedBeforeDate.Text = tblILLOR.Rows(0).Item("NEEDBEFOREDATE")
                    End If
                    ' Currency
                    For inti = 0 To ddlCurrency.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("CurrencyCode")) Then
                            If UCase(ddlCurrency.Items(inti).Text) = UCase(Trim(tblILLOR.Rows(0).Item("CurrencyCode"))) Then
                                ddlCurrency.Items(ddlCurrency.SelectedIndex).Selected = False
                                ddlCurrency.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next
                    ' Service type
                    For inti = 0 To ddlServiceType.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("ServiceType")) Then
                            If ddlServiceType.Items(inti).Value = tblILLOR.Rows(0).Item("ServiceType") Then
                                ddlServiceType.Items(ddlServiceType.SelectedIndex).Selected = False
                                ddlServiceType.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next
                    ' Payment type
                    For inti = 0 To ddlPaymentType.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("PaymentType")) Then
                            If ddlPaymentType.Items(inti).Value = tblILLOR.Rows(0).Item("PaymentType") Then
                                ddlPaymentType.Items(ddlPaymentType.SelectedIndex).Selected = False
                                ddlPaymentType.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next

                    ' Max cost
                    If Not IsDBNull(tblILLOR.Rows(0).Item("MaxCost")) Then
                        If tblILLOR.Rows(0).Item("MaxCost") = CInt(tblILLOR.Rows(0).Item("MaxCost")) Then
                            txtMaxCost.Text = CInt(tblILLOR.Rows(0).Item("MaxCost"))
                        Else
                            txtMaxCost.Text = tblILLOR.Rows(0).Item("MaxCost")
                        End If
                    End If

                    ' Item type
                    For inti = 0 To ddlItemType.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("ItemType")) Then
                            If ddlItemType.Items(inti).Value = tblILLOR.Rows(0).Item("ItemType") Then
                                ddlItemType.Items(ddlItemType.SelectedIndex).Selected = False
                                ddlItemType.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next
                    ' Reciprocal agreement
                    If Not IsDBNull(tblILLOR.Rows(0).Item("ReciprocalAgreement")) Then
                        If CBool(tblILLOR.Rows(0).Item("ReciprocalAgreement")) = True Then
                            ckbReciprocalAgreement.Checked = True
                        Else
                            ckbReciprocalAgreement.Checked = False
                        End If
                    End If
                    ' Will pay free
                    If Not IsDBNull(tblILLOR.Rows(0).Item("WillPayFee")) Then
                        If CBool(tblILLOR.Rows(0).Item("WillPayFee")) = True Then
                            ckbWilPayFee.Checked = True
                        Else
                            ckbWilPayFee.Checked = False
                        End If
                    End If
                    ' Payment provided
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PaymentProvided")) Then
                        If CBool(tblILLOR.Rows(0).Item("PaymentProvided")) = True Then
                            ckbPaymentProvided.Checked = True
                        Else
                            ckbPaymentProvided.Checked = False
                        End If
                    End If
                    ' Note
                    If Not IsDBNull(tblILLOR.Rows(0).Item("Note")) Then
                        txtLibNote.Text = tblILLOR.Rows(0).Item("Note")
                    End If
                    ' Expiry date
                    If Not IsDBNull(tblILLOR.Rows(0).Item("EXPIRYDATE")) Then
                        txtExpiredDate.Text = tblILLOR.Rows(0).Item("EXPIRYDATE")
                    End If
                    ' Medium
                    For inti = 0 To ddlMedium.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("Medium")) Then
                            If ddlMedium.Items(inti).Value = tblILLOR.Rows(0).Item("Medium") Then
                                ddlMedium.Items(ddlMedium.SelectedIndex).Selected = False
                                ddlMedium.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next
                    ' Title
                    If Not IsDBNull(tblILLOR.Rows(0).Item("Title")) Then
                        txtTitle.Text = tblILLOR.Rows(0).Item("Title")
                    End If
                    ' Edition
                    If Not IsDBNull(tblILLOR.Rows(0).Item("Edition")) Then
                        txtEdition.Text = tblILLOR.Rows(0).Item("Edition")
                    End If
                    ' Author
                    If Not IsDBNull(tblILLOR.Rows(0).Item("Author")) Then
                        txtAuthor.Text = tblILLOR.Rows(0).Item("Author")
                    End If
                    ' Sponsoring body
                    If Not IsDBNull(tblILLOR.Rows(0).Item("SponsoringBody")) Then
                        txtSponsoringBody.Text = tblILLOR.Rows(0).Item("SponsoringBody")
                    End If
                    ' Place of pub
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PlaceOfPub")) Then
                        txtPlaceOfPub.Text = tblILLOR.Rows(0).Item("PlaceOfPub")
                    End If
                    ' Publisher
                    If Not IsDBNull(tblILLOR.Rows(0).Item("Publisher")) Then
                        txtPublisher.Text = tblILLOR.Rows(0).Item("Publisher")
                    End If
                    ' Published date
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PUBDATE")) Then
                        txtPubDate.Text = tblILLOR.Rows(0).Item("PUBDATE")
                    End If
                    ' System number
                    If Not IsDBNull(tblILLOR.Rows(0).Item("SystemNumber")) Then
                        txtItemCode.Text = tblILLOR.Rows(0).Item("SystemNumber")
                    End If
                    ' Article title
                    If Not IsDBNull(tblILLOR.Rows(0).Item("ArticleTitle")) Then
                        txtArticleTitle.Text = tblILLOR.Rows(0).Item("ArticleTitle")
                    End If
                    ' Article author
                    If Not IsDBNull(tblILLOR.Rows(0).Item("ArticleAuthor")) Then
                        txtArticleAuthor.Text = tblILLOR.Rows(0).Item("ArticleAuthor")
                    End If
                    ' Volume issue
                    If Not IsDBNull(tblILLOR.Rows(0).Item("VolumeIssue")) Then
                        txtVolumeIssue.Text = tblILLOR.Rows(0).Item("VolumeIssue")
                    End If
                    ' Component pub date
                    If Not IsDBNull(tblILLOR.Rows(0).Item("COMPONENTPUBDATE")) Then
                        txtComponentPubDate.Text = tblILLOR.Rows(0).Item("COMPONENTPUBDATE")
                    End If
                    ' Pagination
                    If Not IsDBNull(tblILLOR.Rows(0).Item("Pagination")) Then
                        txtPagination.Text = tblILLOR.Rows(0).Item("Pagination")
                    End If
                    ' Callnumber
                    If Not IsDBNull(tblILLOR.Rows(0).Item("CallNumber")) Then
                        txtCallNumber.Text = tblILLOR.Rows(0).Item("CallNumber")
                    End If
                    ' ISBN
                    If Not IsDBNull(tblILLOR.Rows(0).Item("ISBN")) Then
                        txtISBN.Text = tblILLOR.Rows(0).Item("ISBN")
                    End If
                    ' ISSN
                    If Not IsDBNull(tblILLOR.Rows(0).Item("ISSN")) Then
                        txtISSN.Text = tblILLOR.Rows(0).Item("ISSN")
                    End If
                    ' Nationalbibnumber
                    If Not IsDBNull(tblILLOR.Rows(0).Item("NationalBibNumber")) Then
                        txtNationalBibNumber.Text = tblILLOR.Rows(0).Item("NationalBibNumber")
                    End If
                    ' Series title number
                    If Not IsDBNull(tblILLOR.Rows(0).Item("SeriesTitleNumber")) Then
                        txtSerialTitleNumber.Text = tblILLOR.Rows(0).Item("SeriesTitleNumber")
                    End If
                    ' Other number
                    If Not IsDBNull(tblILLOR.Rows(0).Item("OtherNumbers")) Then
                        txtOtherNumbers.Text = tblILLOR.Rows(0).Item("OtherNumbers")
                    End If
                    ' Verification
                    If Not IsDBNull(tblILLOR.Rows(0).Item("Verification")) Then
                        txtVerification.Text = tblILLOR.Rows(0).Item("Verification")
                    End If
                    ' Local note
                    If Not IsDBNull(tblILLOR.Rows(0).Item("LocalNote")) Then
                        txtLocalNote.Text = tblILLOR.Rows(0).Item("LocalNote")
                    End If
                    ' Deliv mode
                    If tblILLOR.Rows(0).Item("DelivMode") = 1 Then
                        If optDelivMode2.Checked = True Then
                            optDelivMode2.Checked = False
                        End If
                        optDelivMode1.Checked = True
                        If Not IsDBNull(tblILLOR.Rows(0).Item("DeliveryLocID")) Then
                            For inti = 0 To lsbDelivMode1.Items.Count - 1
                                If lsbDelivMode1.Items(inti).Value = tblILLOR.Rows(0).Item("DeliveryLocID") Then
                                    lsbDelivMode1.Items(lsbDelivMode1.SelectedIndex).Selected = False
                                    lsbDelivMode1.Items(inti).Selected = True
                                    Exit For
                                End If
                            Next
                        End If
                    Else
                        If optDelivMode1.Checked = True Then
                            optDelivMode1.Checked = False
                        End If
                        optDelivMode2.Checked = True
                        If Not IsDBNull(tblILLOR.Rows(0).Item("DeliveryLocID")) Then
                            For inti = 0 To ddlDelivMode2.Items.Count - 1
                                If ddlDelivMode2.Items(inti).Value = tblILLOR.Rows(0).Item("DeliveryLocID") Then
                                    ddlDelivMode2.Items(ddlDelivMode2.SelectedIndex).Selected = False
                                    ddlDelivMode2.Items(inti).Selected = True
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    ' Post delivery name
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostDelivName")) Then
                        txtPostDelivName.Text = tblILLOR.Rows(0).Item("PostDelivName")
                    End If
                    ' Post delivery XAddress
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostDelivXAddr")) Then
                        txtPostDelivAddr.Text = tblILLOR.Rows(0).Item("PostDelivXAddr")
                    End If
                    ' Post delivery box
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostDelivBox")) Then
                        txtPostDelivBox.Text = tblILLOR.Rows(0).Item("PostDelivBox")
                    End If
                    ' Post delivery street
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostDelivStreet")) Then
                        txtPostDelivStreet.Text = tblILLOR.Rows(0).Item("PostDelivStreet")
                    End If
                    ' Post deliverty region
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostDelivRegion")) Then
                        txtPostDelivRegion.Text = tblILLOR.Rows(0).Item("PostDelivRegion")
                    End If
                    ' Post delivery city
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostDelivCity")) Then
                        txtPostDelivCity.Text = tblILLOR.Rows(0).Item("PostDelivCity")
                    End If
                    ' Post deilvery code
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostDelivCode")) Then
                        txtPostDelivCode.Text = tblILLOR.Rows(0).Item("PostDelivCode")
                    End If
                    ' Post delivery country
                    ddlDelivCountry.SelectedIndex = 0
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PostCountryID")) Then
                        For inti = 0 To ddlDelivCountry.Items.Count - 1
                            If ddlDelivCountry.Items(inti).Value = tblILLOR.Rows(0).Item("PostCountryID") Then
                                ddlDelivCountry.SelectedIndex = inti
                                Exit For
                            End If
                        Next
                    End If
                    ' Patron name
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PatronName")) Then
                        txtPatronName.Text = tblILLOR.Rows(0).Item("PatronName")
                    End If
                    ' Patron code
                    If Not IsDBNull(tblILLOR.Rows(0).Item("PatronCode")) Then
                        txtPatronCode.Text = tblILLOR.Rows(0).Item("PatronCode")
                    End If
                    ' Patron group
                    For inti = 0 To ddlPatronGroup.Items.Count - 1
                        If CStr(Session("DBServer")).ToUpper = "SQLSERVER" Then
                            If Not IsDBNull(tblILLOR.Rows(0).Item("PatronGroupID")) Then
                                If ddlPatronGroup.Items(inti).Value = tblILLOR.Rows(0).Item("PatronGroupID") Then
                                    ddlPatronGroup.Items(ddlPatronGroup.SelectedIndex).Selected = False
                                    ddlPatronGroup.Items(inti).Selected = True
                                    Exit For
                                End If
                            End If
                        Else
                            If Not IsDBNull(tblILLOR.Rows(0).Item("PATRONGROUPID")) Then
                                If ddlPatronGroup.Items(inti).Value = tblILLOR.Rows(0).Item("PATRONGROUPID") Then
                                    ddlPatronGroup.Items(ddlPatronGroup.SelectedIndex).Selected = False
                                    ddlPatronGroup.Items(inti).Selected = True
                                    Exit For
                                End If
                            End If
                        End If
                    Next
                    ' Bill delivery name
                    For inti = 0 To ddlBillDelivName.Items.Count - 1
                        If Not IsDBNull(tblILLOR.Rows(0).Item("BillDelivName")) Then
                            If ddlBillDelivName.Items(inti).Text = tblILLOR.Rows(0).Item("BillDelivName") Then
                                ddlBillDelivName.Items(ddlBillDelivName.SelectedIndex).Selected = False
                                ddlBillDelivName.Items(inti).Selected = True
                                Exit For
                            End If
                        End If
                    Next
                    ' Bill delivery XAddress
                    If Not IsDBNull(tblILLOR.Rows(0).Item("BillDelivXAddr")) Then
                        txtBillDelivAddr.Text = tblILLOR.Rows(0).Item("BillDelivXAddr")
                    End If
                    ' Bill delivery street
                    If Not IsDBNull(tblILLOR.Rows(0).Item("BillDelivStreet")) Then
                        txtBillDelivStreet.Text = tblILLOR.Rows(0).Item("BillDelivStreet")
                    End If
                    ' Bill delivery city
                    If Not IsDBNull(tblILLOR.Rows(0).Item("BillDelivCity")) Then
                        txtBillDelivCity.Text = tblILLOR.Rows(0).Item("BillDelivCity")
                    End If
                    ' Bill delivery region
                    If Not IsDBNull(tblILLOR.Rows(0).Item("BillDelivRegion")) Then
                        txtBillDelivRegion.Text = tblILLOR.Rows(0).Item("BillDelivRegion")
                    End If
                    If Not IsDBNull(tblILLOR.Rows(0).Item("BillDelivBox")) Then
                        txtBillDelivBox.Text = tblILLOR.Rows(0).Item("BillDelivBox")
                    End If
                    ddlBillDelivCountry.SelectedIndex = 0
                    If Not IsDBNull(tblILLOR.Rows(0).Item("BillCountryID")) Then
                        For inti = 0 To ddlBillDelivCountry.Items.Count - 1
                            If ddlBillDelivCountry.Items(inti).Value = tblILLOR.Rows(0).Item("BillCountryID") Then
                                ddlBillDelivCountry.SelectedIndex = inti
                                Exit For
                            End If
                        Next
                    End If
                    If Not IsDBNull(tblILLOR.Rows(0).Item("BillDelivCode")) Then
                        txtBillDelivCode.Text = tblILLOR.Rows(0).Item("BillDelivCode")
                    End If
                End If
            End If
        End Sub
        ' Create OR request
        ' In: some inforamtions
        ' Out: integer
        ' Creator: Sondp
        Private Sub CreateOR()
            Dim intRetval As Integer
            Try
                ' ILL_OUTGOING_REQUESTS
                objBILLOutR.ResponderID = ddlSymbol.SelectedValue
                objBILLOutR.CreatedDate = DayOfNow()
                objBILLOutR.NeedBeforeDate = txtNeedBeforeDate.Text
                objBILLOutR.ExpiredDate = txtExpiredDate.Text
                objBILLOutR.NoticePatron = "0"
                If txtMaxCost.Text <> "" And IsNumeric(txtMaxCost.Text) Then
                    objBILLOutR.MaxCost = CLng(txtMaxCost.Text)
                Else
                    objBILLOutR.MaxCost = 0.0
                End If
                objBILLOutR.CurrencyCode = UCase(ddlCurrency.SelectedValue)
                objBILLOutR.ServiceType = ddlServiceType.SelectedValue
                If hdReview.Value = 0 Then
                    objBILLOutR.Statust = 21
                Else
                    objBILLOutR.Statust = 19
                End If
                objBILLOutR.Note = txtLibNote.Text
                If optDelivMode1.Checked = True Then
                    objBILLOutR.DeliveryLocID = 0
                    objBILLOutR.DelivMode = 1
                    objBILLOutR.EDelivModeID = lsbDelivMode1.SelectedValue
                Else
                    objBILLOutR.DelivMode = 2
                    objBILLOutR.EDelivModeID = 0
                    objBILLOutR.DeliveryLocID = ddlDelivMode2.SelectedValue
                End If
                objBILLOutR.BillingLocID = ddlBillDelivName.SelectedValue
                If ckbReciprocalAgreement.Checked = True Then
                    objBILLOutR.ReciprocalAgreement = 1
                Else
                    objBILLOutR.ReciprocalAgreement = 0
                End If
                If ckbWilPayFee.Checked = True Then
                    objBILLOutR.WillPayFee = 1
                Else
                    objBILLOutR.WillPayFee = 0
                End If
                If ckbPaymentProvided.Checked = True Then
                    objBILLOutR.PaymentProvided = 1
                Else
                    objBILLOutR.PaymentProvided = 0
                End If
                objBILLOutR.ItemType = ddlItemType.SelectedValue
                objBILLOutR.CopyrightCompliance = ddlCopyrightCompliance.SelectedValue
                objBILLOutR.Priority = ddlPiroity.SelectedValue
                ' PaymentType
                objBILLOutR.PaymentType = ddlPaymentType.SelectedValue
                objBILLOutR.Medium = ddlMedium.SelectedValue
                objBILLOutR.Title = txtTitle.Text
                objBILLOutR.PatronName = txtPatronName.Text
                objBILLOutR.PatronCode = txtPatronCode.Text
                objBILLOutR.PatronGroupID = ddlPatronGroup.SelectedValue

                ' ILL_REQUEST_ITEMS
                objBILLOutR.CallNumber = txtCallNumber.Text
                objBILLOutR.Author = txtAuthor.Text
                objBILLOutR.PlaceOfPub = txtPlaceOfPub.Text
                objBILLOutR.Publisher = txtPublisher.Text
                objBILLOutR.SeriesTitleNumber = txtSerialTitleNumber.Text
                objBILLOutR.VolumeIssue = txtVolumeIssue.Text
                objBILLOutR.Edition = txtEdition.Text
                objBILLOutR.PubDate = txtPubDate.Text
                objBILLOutR.ComponentPubDate = txtComponentPubDate.Text
                objBILLOutR.ArticleAuthor = txtArticleAuthor.Text
                objBILLOutR.ArticleTitle = txtArticleTitle.Text
                objBILLOutR.Pagination = txtPagination.Text
                objBILLOutR.NationalBibNumber = txtNationalBibNumber.Text
                objBILLOutR.ISBN = txtISBN.Text
                objBILLOutR.ISSN = txtISSN.Text
                objBILLOutR.SystemNumber = txtItemCode.Text
                objBILLOutR.OtherNumbers = txtOtherNumbers.Text
                objBILLOutR.Verification = txtVerification.Text
                objBILLOutR.LocalNote = txtLocalNote.Text
                objBILLOutR.RequestType = 0
                objBILLOutR.SponsoringBody = txtSponsoringBody.Text
                intRetval = objBILLOutR.CreateOR()
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)

                ' Write log
                WriteLog(66, ddlLabel.Items(15).Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

            Catch ex As Exception
                Page.RegisterClientScriptBlock("CreateORErrorJs1", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            Finally
                If intRetval = 1 Then
                    Page.RegisterClientScriptBlock("CreateORSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');parent.Sentform.location.href='../WRequestTaskBar.aspx?ReqType=2';</script>")
                Else
                    Page.RegisterClientScriptBlock("CreateORErrorJs2", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            End Try
        End Sub

        ' Purpose: Update ORCreate
        ' In: Some informations
        ' Creator: Sondp
        Private Sub UpdateOR()
            Dim intRetVal As Integer = 0

            Try
                ' ILL_OUTGOING_REQUESTS
                Call objBILLOutR.InitValues()
                objBILLOutR.IllID = hdILLID.Value
                objBILLOutR.ResponderID = ddlSymbol.SelectedValue
                objBILLOutR.NeedBeforeDate = txtNeedBeforeDate.Text
                objBILLOutR.ExpiredDate = txtExpiredDate.Text
                objBILLOutR.NoticePatron = "0"
                If txtMaxCost.Text <> "" And IsNumeric(txtMaxCost.Text) Then
                    objBILLOutR.MaxCost = CLng(txtMaxCost.Text)
                Else
                    objBILLOutR.MaxCost = 0.0
                End If
                objBILLOutR.CurrencyCode = UCase(ddlCurrency.SelectedValue)
                objBILLOutR.ServiceType = ddlServiceType.SelectedValue
                If hdClone.Value <> 2 Then
                    If hdReview.Value = 0 Then
                        objBILLOutR.Statust = 21
                    Else
                        objBILLOutR.Statust = 19
                    End If
                End If
                objBILLOutR.Note = txtLibNote.Text
                If optDelivMode1.Checked = True Then
                    objBILLOutR.DeliveryLocID = lsbDelivMode1.SelectedValue
                    objBILLOutR.DelivMode = 1
                    objBILLOutR.EDelivModeID = 1
                Else
                    objBILLOutR.DelivMode = 2
                    objBILLOutR.EDelivModeID = 0
                    objBILLOutR.DeliveryLocID = ddlDelivMode2.SelectedValue
                End If
                objBILLOutR.BillingLocID = ddlBillDelivName.SelectedValue
                If ckbReciprocalAgreement.Checked = True Then
                    objBILLOutR.ReciprocalAgreement = 1
                Else
                    objBILLOutR.ReciprocalAgreement = 0
                End If
                If ckbWilPayFee.Checked = True Then
                    objBILLOutR.WillPayFee = 1
                Else
                    objBILLOutR.WillPayFee = 0
                End If
                If ckbPaymentProvided.Checked = True Then
                    objBILLOutR.PaymentProvided = 1
                Else
                    objBILLOutR.PaymentProvided = 0
                End If
                objBILLOutR.ItemType = ddlItemType.SelectedValue
                objBILLOutR.CopyrightCompliance = ddlCopyrightCompliance.SelectedValue
                objBILLOutR.Priority = ddlPiroity.SelectedValue

                ' PaymentType
                objBILLOutR.PaymentType = ddlPaymentType.SelectedValue

                objBILLOutR.Medium = ddlMedium.SelectedValue
                objBILLOutR.Title = txtTitle.Text
                objBILLOutR.PatronName = txtPatronName.Text
                objBILLOutR.PatronCode = txtPatronCode.Text
                objBILLOutR.PatronGroupID = ddlPatronGroup.SelectedValue
                ' ILL_LIBRARIES
                objBILLOutR.AccountNumber = txtAccount.Text
                objBILLOutR.PostDelivName = txtPostDelivName.Text
                objBILLOutR.PostDelivXAddr = txtPostDelivAddr.Text
                objBILLOutR.PostDelivStreet = txtPostDelivStreet.Text
                objBILLOutR.PostDelivBox = txtPostDelivBox.Text
                objBILLOutR.PostDelivCity = txtPostDelivCity.Text
                objBILLOutR.PostDelivRegion = txtPostDelivRegion.Text
                objBILLOutR.PostDelivCountry = ddlDelivCountry.SelectedValue
                objBILLOutR.PostDelivCode = txtPostDelivCode.Text
                objBILLOutR.BillDelivName = ddlBillDelivName.Items(ddlBillDelivName.SelectedIndex).Text
                objBILLOutR.BillDelivXAddr = txtBillDelivAddr.Text
                objBILLOutR.BillDelivStreet = txtBillDelivStreet.Text
                objBILLOutR.BillDelivBox = txtBillDelivBox.Text
                objBILLOutR.BillDelivCity = txtBillDelivCity.Text
                objBILLOutR.BillDelivRegion = txtBillDelivRegion.Text
                objBILLOutR.BillDelivCountry = ddlBillDelivCountry.SelectedValue
                objBILLOutR.BillDelivCode = txtBillDelivCode.Text
                ' ILL_REQUEST_ITEMS
                objBILLOutR.CallNumber = txtCallNumber.Text
                objBILLOutR.Author = txtAuthor.Text
                objBILLOutR.PlaceOfPub = txtPlaceOfPub.Text
                objBILLOutR.Publisher = txtPublisher.Text
                objBILLOutR.SeriesTitleNumber = txtSerialTitleNumber.Text
                objBILLOutR.VolumeIssue = txtVolumeIssue.Text
                objBILLOutR.Edition = txtEdition.Text
                objBILLOutR.PubDate = txtPubDate.Text
                objBILLOutR.ComponentPubDate = txtComponentPubDate.Text
                objBILLOutR.ArticleAuthor = txtArticleAuthor.Text
                objBILLOutR.ArticleTitle = txtArticleTitle.Text
                objBILLOutR.Pagination = txtPagination.Text
                objBILLOutR.NationalBibNumber = txtNationalBibNumber.Text
                objBILLOutR.ISBN = txtISBN.Text
                objBILLOutR.ISSN = txtISSN.Text
                objBILLOutR.SystemNumber = txtItemCode.Text
                objBILLOutR.OtherNumbers = txtOtherNumbers.Text
                objBILLOutR.Verification = txtVerification.Text
                objBILLOutR.LocalNote = txtLocalNote.Text
                objBILLOutR.RequestType = 0
                objBILLOutR.SponsoringBody = txtSponsoringBody.Text
                intRetVal = objBILLOutR.UpdateOR
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutR.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutR.ErrorCode)

                ' Write log
                WriteLog(66, ddlLabel.Items(16).Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            Catch ex As Exception
                Page.RegisterClientScriptBlock("UpdateORErrorJs1", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
            Finally
                If intRetVal = 1 Then
                    Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("UpdateORErrorJs2", "<script language='javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
                End If
            End Try
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutR Is Nothing Then
                    objBILLOutR.Dispose(True)
                    objBILLOutR = Nothing
                End If
                If Not objBILLLib Is Nothing Then
                    objBILLLib.Dispose(True)
                    objBILLLib = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBPhyDelMode Is Nothing Then
                    objBPhyDelMode.Dispose(True)
                    objBPhyDelMode = Nothing
                End If
                If Not objBPhyDelAddr Is Nothing Then
                    objBPhyDelAddr.Dispose(True)
                    objBPhyDelAddr = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace