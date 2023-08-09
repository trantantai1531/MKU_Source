' class: WACQsRequest
' Puspose: Create/update serial request
' Creator: Oanhtn
' CreatedDate: 10/04/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQsRequest
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents msgUpdateFail As System.Web.UI.WebControls.Label
        Protected WithEvents msgUpdateSuccess As System.Web.UI.WebControls.Label
        Protected WithEvents msgAddFail As System.Web.UI.WebControls.Label
        Protected WithEvents msgAddSuccess As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBItemOrder As New clsBItemOrder
        Private intRequestID As Integer = 0

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call BindControl()
            'Call BindDataSubscribedDate()
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Gui don dat
            If Not CheckPemission(32) Then
                Call WriteErrorMssg(ddlLabel.Items(9).Text)
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            ' Init objBCommonBusiness object
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()

            ' Init objBItemOrder object
            objBItemOrder.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemOrder.DBServer = Session("DBServer")
            objBItemOrder.ConnectionString = Session("ConnectionString")
            Call objBItemOrder.Initialize()

            txtRequester.Text = clsSession.GlbUserFullName
        End Sub

        ' Method: BindControl
        Private Sub BindControl()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("AcqRequestJs", "<script language = 'javascript' src = '../Js/PO/WAcqRequest.js'></script>")

            lnkCheckExists.NavigateUrl = "javascript:if (!CheckNull(document.forms[0].txtTitle)) {OpenWindow('WCheckExistItem.aspx?Title='+ Esc(document.forms[0].txtTitle.value" & ",'" & Session("InterfaceLanguage") & "') + '&Single=false','CheckItem',565,456,20,40);}"

            Me.SetOnclickZ3950(btnZ3950, "../..")
            btnInsert.Attributes.Add("OnClick", "return CheckSRequest('" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(8).Text & "','" & Session("DateFormat") & "');")
            btnReset.Attributes.Add("OnClick", "document.forms[0].txtRequester.value='" & clsSession.GlbUserFullName & "';")

            Me.SetCheckNumberCurrency(txtUnitPrice, ddlLabel.Items(5).Text)
            txtRequestedCopies.Attributes.Add("OnChange", "if (!CheckNumBer(this, '" & ddlLabel.Items(5).Text & "',1)) {this.value=1; this.focus();} else {SetUnitPrice();}")
            txtIssues.Attributes.Add("OnChange", "if (!CheckNumBer(this, '" & ddlLabel.Items(5).Text & "',1)) {this.value=1; this.focus();} else {SetUnitPrice();}")
            txtIssuePrice.Attributes.Add("OnChange", "if (!CheckNumBerCurrency(this, '" & ddlLabel.Items(5).Text & "',0)) {this.value=0; this.focus();} else {SetUnitPrice();}")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkValidSubscribedDate, txtValidSubscribedDate, ddlLabel.Items(7).Text)
            SetOnclickCalendar(lnkExpiredSubscribedDate, txtExpiredSubscribedDate, ddlLabel.Items(7).Text)
        End Sub
        Private Sub BindDataSubscribedDate()
            If Not Request("ID") = "" Then
                Exit Sub
            End If
            Dim intMonth, intYear, inti, intj As Integer
            Dim intMonthFirstQuarter As Integer
            Dim intMonthLastQuarter As Integer
            Dim intDayFinish As Integer
            Dim intYearLast As Integer
            Dim arrQuarter(3) As String
            Dim strDateStart, strDateFinish As String
            Dim tblResult As DataTable
            Dim strSQL As String
            Dim intID As Integer
            intMonth = Month(Session("ToDay"))
            intYear = Year(Session("ToDay"))
            arrQuarter(0) = "1,2,3"
            arrQuarter(1) = "4,5,6"
            arrQuarter(2) = "7,8,9"
            arrQuarter(3) = "10,11,12"
            For inti = 0 To arrQuarter.Length - 1
                If InStr(arrQuarter(inti), intMonth) > 0 Then
                    Exit For
                End If
            Next
            Select Case inti
                Case 0
                    intMonthFirstQuarter = 4
                    intMonthLastQuarter = 6
                    intDayFinish = 30
                Case 1
                    intMonthFirstQuarter = 7
                    intMonthLastQuarter = 9
                    intDayFinish = 30
                Case 2
                    intMonthFirstQuarter = 10
                    intMonthLastQuarter = 12
                    intDayFinish = 31
                Case 3
                    intMonthFirstQuarter = 1
                    intMonthLastQuarter = 3
                    intDayFinish = 31
                    intYear = intYear + 1
                Case Else
                    intMonthFirstQuarter = Month(Session("ToDay"))
                    intMonthLastQuarter = intMonthFirstQuarter + 2
                    intDayFinish = 30
                    intYear = Year(Session("ToDay"))
            End Select
            strDateStart = "01/" & intMonthFirstQuarter & "/" & intYear
            strDateFinish = intDayFinish & "/" & intMonthLastQuarter & "/" & intYear
            txtValidSubscribedDate.Text = strDateStart
            txtExpiredSubscribedDate.Text = strDateFinish
        End Sub
        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As New DataTable
            Dim dblUnitPrice As Double
            Dim strCurrency As String
            Dim strNote As String
            Dim strISSN As String
            Dim strEdition As String
            Dim strPubYear As String
            Dim strPublisher As String
            Dim strRequestedCopies As String
            Dim strAuthor As String
            Dim strRequester As String
            Dim intUrgency As Integer
            Dim intLanguageID As Integer
            Dim intCountryID As Integer
            Dim intMediumID As Integer
            Dim inti As Integer

            ' Get ID
            If Not Request("ID") = "" Then
                intRequestID = Request("ID")
                txtRequestID.Value = Request("ID")
            Else
                If Not txtRequestID.Value = "" Then
                    intRequestID = txtRequestID.Value
                End If
            End If

            ' Language dropdownlist
            tblTemp = objBCommonBusiness.GetLanguages
            ddlLanguage.DataSource = tblTemp
            ddlLanguage.DataTextField = "Language"
            ddlLanguage.DataValueField = "ID"
            ddlLanguage.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("ISOCode")).ToLower = "vi" Then
                    ddlLanguage.SelectedIndex = inti
                    Exit For
                End If
            Next

            ' Country dropdownlist
            tblTemp = objBCommonBusiness.GetCountries
            ddlCountry.DataSource = tblTemp
            ddlCountry.DataTextField = "Country"
            ddlCountry.DataValueField = "ID"
            ddlCountry.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("ISOCode")).ToLower = "vm" Or CStr(tblTemp.Rows(inti).Item("ISOCode")).ToLower = "vn" Then
                    ddlCountry.SelectedIndex = inti
                    Exit For
                End If
            Next

            ' Medium dropdownlist            
            tblTemp = objBCommonBusiness.GetMediums
            ddlMedium.DataSource = tblTemp
            ddlMedium.DataTextField = "Medium"
            ddlMedium.DataValueField = "ID"
            ddlMedium.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("Code")).ToLower = "g" Then
                    ddlMedium.SelectedIndex = inti
                    Exit For
                End If
            Next

            ' Currency dropdownlist
            tblTemp = objBCommonBusiness.GetCurrency
            ddlCurrency.DataSource = tblTemp
            ddlCurrency.DataTextField = "CurrencyCode"
            ddlCurrency.DataValueField = "CurrencyCode"
            ddlCurrency.DataBind()
            For inti = 0 To tblTemp.Rows.Count - 1
                If CStr(tblTemp.Rows(inti).Item("CurrencyCode")).ToLower = "vnd" Then
                    ddlCurrency.SelectedIndex = inti
                    Exit For
                End If
            Next

            ' RegularityCode dropdownlist
            tblTemp = objBCommonBusiness.GetRegularity
            ddlRegularityCode.DataSource = tblTemp
            ddlRegularityCode.DataTextField = "DisplayEntry"
            ddlRegularityCode.DataValueField = "RegularityCode"
            ddlRegularityCode.DataBind()

            ' Load Po's information to update
            If intRequestID > 0 Then
                objBItemOrder.RequestID = intRequestID
                tblTemp = objBItemOrder.GetOrderItems()
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        txtTitle.Text = tblTemp.Rows(0).Item("Title")
                        If Not IsDBNull(tblTemp.Rows(0).Item("Author")) Then
                            txtAuthor.Text = tblTemp.Rows(0).Item("Author")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Publisher")) Then
                            txtPublisher.Text = tblTemp.Rows(0).Item("Publisher")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("ISSN")) Then
                            txtISSN.Text = tblTemp.Rows(0).Item("ISSN")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Requester")) Then
                            txtRequester.Text = tblTemp.Rows(0).Item("Requester")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Note")) Then
                            txtNote.Text = tblTemp.Rows(0).Item("Note")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("RequestedCopies")) Then
                            txtRequestedCopies.Text = tblTemp.Rows(0).Item("RequestedCopies")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("UnitPrice")) Then
                            txtUnitPrice.Text = tblTemp.Rows(0).Item("UnitPrice")
                            txtUnitPrice.Text = If(Not (txtUnitPrice.Text = "0"), CDbl(txtUnitPrice.Text).ToString("#,##"), "0")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("PubYear")) Then
                            txtPubYear.Text = tblTemp.Rows(0).Item("PubYear")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("SerialCode")) Then
                            txtSerialCode.Text = tblTemp.Rows(0).Item("SerialCode")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("IssuePrice")) Then
                            txtIssuePrice.Text = tblTemp.Rows(0).Item("IssuePrice")
                            txtIssuePrice.Text = If(Not (txtIssuePrice.Text = "0"), CDbl(txtIssuePrice.Text).ToString("#,##"), "0")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Issues")) Then
                            txtIssues.Text = tblTemp.Rows(0).Item("Issues")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("VALIDSUBSCRIBEDDATE")) Then
                            txtValidSubscribedDate.Text = tblTemp.Rows(0).Item("VALIDSUBSCRIBEDDATE")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("EXPIREDSUBSCRIBEDDATE")) Then
                            txtExpiredSubscribedDate.Text = tblTemp.Rows(0).Item("EXPIREDSUBSCRIBEDDATE")
                        End If

                        Call BindLanguage(CInt(tblTemp.Rows(0).Item("LanguageID")))
                        Call BindCountry(CInt(tblTemp.Rows(0).Item("CountryID")))
                        Call BindMedium(CInt(tblTemp.Rows(0).Item("MediumID")))
                        Call BindCurrency(CStr(tblTemp.Rows(0).Item("Currency")))
                        Call BindUrgency(CInt(tblTemp.Rows(0).Item("Urgency")))
                        Call BindRegularityCode(CStr(tblTemp.Rows(0).Item("RegularityCode")))
                    End If
                End If
            End If

            ' Release object
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindCurrency
        Private Sub BindCurrency(ByVal strInput As String)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetCurrency
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If Trim(tblTemp.Rows(intIndex).Item("CurrencyCode")) = Trim(strInput) Then
                    ddlCurrency.SelectedIndex = intIndex
                    Exit For
                End If
            Next

            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindRegularityCode
        Private Sub BindRegularityCode(ByVal strInput As String)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetRegularity
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If Trim(tblTemp.Rows(intIndex).Item("RegularityCode")) = Trim(strInput) Then
                    ddlRegularityCode.SelectedIndex = intIndex
                    Exit For
                End If
            Next

            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindUrgency
        Private Sub BindUrgency(ByVal intUrgency As Integer)
            ddlUrgency.SelectedIndex = intUrgency - 1
        End Sub

        ' Method: BindLanguage
        Private Sub BindLanguage(ByVal intLanguageID As Integer)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetLanguages
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If CInt(tblTemp.Rows(intIndex).Item("ID")) = intLanguageID Then
                    ddlLanguage.SelectedIndex = intIndex
                    Exit For
                End If
            Next

            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindCountry
        Private Sub BindCountry(ByVal intCountryID As Integer)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetCountries
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If CInt(tblTemp.Rows(intIndex).Item("ID")) = intCountryID Then
                    ddlCountry.SelectedIndex = intIndex
                    Exit For
                End If
            Next

            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Method: BindMedium
        Private Sub BindMedium(ByVal intMediumID As Integer)
            Dim intIndex As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBCommonBusiness.GetMediums
            For intIndex = 0 To tblTemp.Rows.Count - 1
                If CInt(tblTemp.Rows(intIndex).Item("ID")) = intMediumID Then
                    ddlMedium.SelectedIndex = intIndex
                    Exit For
                End If
            Next

            ' Release objects
            tblTemp.Dispose()
            tblTemp = Nothing
        End Sub

        ' Event: btnInsert_Click
        ' Purpose: Insert(Update) Data
        Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
            Dim intRetVal As Integer = 0
            Dim decUnitPrice As Decimal = 0
            Dim intRequestedCopies As Integer = 0
            Dim decIssuePrice As Decimal = 0
            Dim intIssues As Integer = 0
            Dim dtrows(), dtrow As DataRow


            ' Get ID
            If Not Request("RequestID") = "" Then
                intRequestID = Request("RequestID")
                txtRequestID.Value = Request("RequestID")
            Else
                If Not txtRequestID.Value = "" Then
                    intRequestID = txtRequestID.Value
                End If
            End If

            If Not Trim(txtUnitPrice.Text) = "" Then
                'decUnitPrice = CDec(Trim(txtUnitPrice.Text))
                If IsNumeric(txtUnitPrice.Text) Then decUnitPrice = CDec(txtUnitPrice.Text.Trim.Replace(".", ""))
            End If
            If Not Trim(txtRequestedCopies.Text) = "" Then
                intRequestedCopies = CInt(txtRequestedCopies.Text)
            End If
            If Not Trim(txtIssuePrice.Text) = "" Then
                'decIssuePrice = CDec(txtIssuePrice.Text)
                If IsNumeric(txtUnitPrice.Text) Then decUnitPrice = CDec(txtUnitPrice.Text.Trim.Replace(".", ""))
            End If
            If Not Trim(txtIssues.Text) = "" Then
                intIssues = CInt(txtIssues.Text)
            End If

            ' Assign properties's value
            objBItemOrder.RequestID = intRequestID
            objBItemOrder.TypeID = 0 ' Serial
            objBItemOrder.Title = txtTitle.Text
            objBItemOrder.Author = txtAuthor.Text
            objBItemOrder.Publisher = txtPublisher.Text
            objBItemOrder.PubYear = txtPubYear.Text
            objBItemOrder.ISSN = txtISSN.Text
            objBItemOrder.SerialCode = txtSerialCode.Text
            objBItemOrder.Issues = intIssues
            objBItemOrder.IssuePrice = decIssuePrice
            objBItemOrder.UnitPrice = decUnitPrice
            objBItemOrder.ValidSubscribedDate = txtValidSubscribedDate.Text
            objBItemOrder.ExpiredSubscribedDate = txtExpiredSubscribedDate.Text
            objBItemOrder.RequestedCopies = intRequestedCopies
            objBItemOrder.Requester = txtRequester.Text
            objBItemOrder.Note = txtNote.Text
            objBItemOrder.MediumID = ddlMedium.SelectedValue
            objBItemOrder.Urgency = ddlUrgency.SelectedValue
            objBItemOrder.Currency = ddlCurrency.SelectedValue
            objBItemOrder.LanguageID = ddlLanguage.SelectedValue
            objBItemOrder.RegularityCode = ddlRegularityCode.SelectedValue
            objBItemOrder.CountryID = ddlCountry.SelectedValue
            objBItemOrder.ItemTypeID = 9 ' Serial (default)
            objBItemOrder.LibID = clsSession.GlbSite
            objBItemOrder.AdditionalBy = ""
            objBItemOrder.AcqSourceID = 0
            objBItemOrder.LoanTypeID = 0
            dtrows = objBCommonBusiness.GetItemTypes().Select("TypeCode='TT'")
            If dtrows.Length > 0 Then
                For Each dtrow In dtrows
                    objBItemOrder.ItemTypeID = dtrow.Item("ID")
                Next
            End If
            ' Execute
            If intRequestID > 0 Then
                intRetVal = objBItemOrder.Update
                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(6).Text & " " & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intRetVal = 0 Then
                    Page.RegisterClientScriptBlock("Success", "<script language='JavaScript'>alert('" & ddlLabel.Items(3).Text & "'); opener.location.href=opener.location.href; self.close();</Script>")
                    Call ResetForm()
                Else
                    Page.RegisterClientScriptBlock("Fail", "<script language='JavaScript'>alert('" & ddlLabel.Items(2).Text & "'); opener.location.href=opener.location.href; self.close();</Script>")
                End If
            Else
                intRetVal = objBItemOrder.Create
                ' WriteLog
                Call WriteLog(38, ddlLabel.Items(6).Text & " " & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intRetVal = 0 Then
                    Page.RegisterClientScriptBlock("Success", "<script language='JavaScript'>alert('" & ddlLabel.Items(3).Text & "');</Script>")
                    Call ResetForm()
                Else
                    Page.RegisterClientScriptBlock("Fail", "<script language='JavaScript'>alert('" & ddlLabel.Items(2).Text & "');</Script>")
                End If
            End If
            Call Reset()
        End Sub
        Private Sub Reset()
            txtTitle.Text = ""
            txtAuthor.Text = ""
            txtPublisher.Text = ""
            txtPubYear.Text = ""
            txtISSN.Text = ""
            txtSerialCode.Text = ""
            txtIssues.Text = "1"
            txtIssuePrice.Text = "0"
            txtUnitPrice.Text = "0"
            txtValidSubscribedDate.Text = ""
            txtExpiredSubscribedDate.Text = ""
            txtRequestedCopies.Text = ""
            txtNote.Text = ""
        End Sub
        ' Event: btnReset_Click
        ' Purpose: Reset form data
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Call ResetForm()
        End Sub

        Private Sub ResetForm()
            txtTitle.Text = ""
            txtAuthor.Text = ""
            txtPublisher.Text = ""
            txtPubYear.Text = ""
            txtISSN.Text = ""
            txtSerialCode.Text = ""
            txtIssues.Text = "1"
            txtIssuePrice.Text = "0"
            txtUnitPrice.Text = "0"
            txtValidSubscribedDate.Text = ""
            txtExpiredSubscribedDate.Text = ""
            txtRequestedCopies.Text = ""
            txtNote.Text = ""
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBItemOrder Is Nothing Then
                    objBItemOrder.Dispose(True)
                    objBItemOrder = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace