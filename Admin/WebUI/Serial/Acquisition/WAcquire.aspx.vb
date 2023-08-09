' Class: WAcquire
' Puspose: acquire new periodical
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 21/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WAcquire
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label8 As System.Web.UI.WebControls.Label
        Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
        Protected WithEvents hidItemID As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents lnkHdSearch As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPeriodical As New clsBPeriodical
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBItemOrder As New clsBItemOrder
        Private objBIO As New clsBItemOrder
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            hidCurrentDate.Value = Session("Today")
            Call BindJs()
            Call LoadLocations()
            txtRemainCopies.Visible = False
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            'Cap nhat thong tin bo sung
            If Not CheckPemission(86) Then
                Call WriteErrorMssg(ddlLabel.Items(15).Text)
            End If
            'Lap yeu cau noi tiep don dat mua
            If Not CheckPemission(85) Then
                btnSearch.Enabled = False
            End If
            'Phan kho tap chi
            If Not CheckPemission(192) Then
                btnRoute.Enabled = False
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Request("ItemID") & "" <> "" Then
                Session("ItemID") = Request("ItemID")
            End If
            If Request("title") <> "" Then
                Session("Title") = Request("title")
            End If
            If Not IsNumeric(Session("ItemID")) Then
                Response.Redirect("../WSearch.aspx?URL=Acquisition/WAcquire.aspx")
            End If

            ' Init objBCommonBusiness object
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.UserID = Session("UserID")
            Call objBCommonBusiness.Initialize()

            ' Init objBPeriodical object
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPeriodical.Initialize()

            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            Call objBIO.Initialize()

        End Sub

        ' Method: BindJs
        ' Purpose: include all necessary javascript function
        Private Sub BindJs()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WAcquire.js'></script>")

            btnViewContract.Attributes.Add("OnClick", "javascript:if(parseFloat(document.forms[0].hidContractID.value) > 0) {OpenWindow('WContractDetail.aspx?ContractID=' + document.forms[0].hidContractID.value,'WShowContractDetail',720,450,40,40);} return false;")
            btnSearch.Attributes.Add("OnClick", "javascript:OpenWindow('WSearchPurchaseOrder.aspx?ContractCode=opener.document.forms[0].txtContractCode&ContractID=opener.document.forms[0].hidContractID','WSearchPurchaseOrder',480,300,200,270); return false;")
            btnView.Attributes.Add("OnClick", "javascript:OpenWindow('WShowRoute.aspx?ContractCode=' + document.forms[0].txtContractCode.value,'WShowRoute',400,250,80,80); return false;")
            btnRoute.Attributes.Add("OnClick", "javascript:CheckRouting('" & ddlLabel.Items(6).Text & "', '" & ddlLabel.Items(14).Text & "','" & ddlLabel.Items(13).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(3).Text & "'); return false;")
            btnReset.Attributes.Add("OnClick", "return ResetAll();")

            btnRemove.Attributes.Add("OnClick", "javascript:if (confirm('" & ddlLabel.Items(5).Text & "')){document.forms[0].hidContractID.value=0;document.forms[0].txtContractCode.value='';}return false;")
            btnUpdate.Attributes.Add("OnClick", "return CheckForUpdate('" & ddlLabel.Items(8).Text & "','" & ddlLabel.Items(12).Text & "','" & ddlLabel.Items(11).Text & "','" & Session("DateFormat") & "');")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkBasedDate, txtBasedDate, ddlLabel.Items(10).Text)
            SetOnclickCalendar(lnkCeasedDate, txtCeasedDate, ddlLabel.Items(10).Text)
            lnkHdSetRegularity.NavigateUrl = "WSetRegularity.aspx"
            lnkHdRegister.NavigateUrl = "WCreateIssue.aspx"
            lnkHdReceive.NavigateUrl = "WReceive.aspx"
            lnkHdView.NavigateUrl = "WViewInCalendarMode.aspx"
            lnkHdSummary.NavigateUrl = "WSummaryHoldingManagement.aspx"
            lnkHdBinding.NavigateUrl = "WSetBindRule.aspx"
            Me.SetCheckNumber(txtCopies, ddlLabel.Items(9).Text, 0)
        End Sub

        ' Method: LoadLocations
        ' Purpose: load list of locations
        Private Sub LoadLocations()
            Dim tblTemp As DataTable

            ' Get Locations
            objBCommonBusiness.LibID = clsSession.GlbSite
            tblTemp = objBCommonBusiness.GetLocations(3)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    Dim intIndex As Int16
                    Dim intMax As Int16 = tblTemp.Rows.Count

                    Dim strScript As String = "<script Language='JavaScript'>"
                    strScript = strScript & "InvName = new Array(" & intMax & ");" & Chr(10)
                    strScript = strScript & "InvID = new Array(" & intMax & ");" & Chr(10)
                    strScript = strScript & "LibID = new Array(" & intMax & ");" & Chr(10)
                    For intIndex = 0 To intMax - 1
                        strScript = strScript & "LibID[" & intIndex & "] = " & tblTemp.Rows(intIndex).Item("LibID") & ";" & Chr(10)
                        strScript = strScript & "InvID[" & intIndex & "] = " & tblTemp.Rows(intIndex).Item("ID") & ";" & Chr(10)
                        strScript = strScript & "InvName[" & intIndex & "] = '" & tblTemp.Rows(intIndex).Item("Symbol") & "';" & Chr(10)
                    Next
                    strScript = strScript & "function GetLocations(intLibID) {" & Chr(10)
                    strScript = strScript & "document.forms[0].ddlLocation.options.length = 0;" & Chr(10)
                    strScript = strScript & "/*if(intLibID==0) {document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].value = 0;" & Chr(10)
                    strScript = strScript & "document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].text = '" & ddlLabel.Items(2).Text & "';}*/" & Chr(10)
                    strScript = strScript & "for (j = 0; j < LibID.length; j++) {" & Chr(10)
                    strScript = strScript & "if (LibID[j] == intLibID) {" & Chr(10)
                    strScript = strScript & "document.forms[0].hidLocationID.value=InvID[j];" & Chr(10)
                    strScript = strScript & "document.forms[0].ddlLocation.options.length = document.forms[0].ddlLocation.options.length + 1;" & Chr(10)
                    strScript = strScript & "document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].value = InvID[j];" & Chr(10)
                    strScript = strScript & "document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.length - 1].text = InvName[j];" & Chr(10)
                    strScript = strScript & "}}" & Chr(10)
                    strScript = strScript & "if (document.forms[0].ddlLocation.options.length > 0) {document.forms[0].ddlLocation.options.selectedIndex = 0;document.forms[0].hidLocationID.value=document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value;}" & Chr(10)
                    strScript = strScript & "}</script>" & Chr(10)
                    Page.RegisterClientScriptBlock("GetLocations", strScript)
                    ddlLibrary.Attributes.Add("OnChange", "javascript:GetLocations(this.options[this.options.selectedIndex].value);")
                    ddlLocation.Attributes.Add("OnChange", "javascript:document.forms[0].hidLocationID.value=this.options[this.options.selectedIndex].value;")
                End If
                tblTemp = Nothing
            End If
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intRemainCopies As Integer = 0

            ' Get serial categories
            tblTemp = objBCommonBusiness.GetCategories

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlSerCategory.DataSource = tblTemp
                    ddlSerCategory.DataValueField = "ID"
                    ddlSerCategory.DataTextField = "DisplayEntry"
                    ddlSerCategory.DataBind()
                End If
                tblTemp.Clear()
            End If

            ' Get acquire source
            tblTemp = objBCommonBusiness.GetAcqSources

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlAcqSource.DataSource = tblTemp
                    ddlAcqSource.DataValueField = "ID"
                    ddlAcqSource.DataTextField = "Source"
                    ddlAcqSource.DataBind()
                End If
                tblTemp.Clear()
            End If

            ' Get Libraries
            tblTemp = objBCommonBusiness.GetLibraries(clsSession.GlbSite, -1, -1, Session("UserID"), 3)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                    ddlLibrary.DataSource = tblTemp
                    ddlLibrary.DataValueField = "ID"
                    ddlLibrary.DataTextField = "Code"
                    ddlLibrary.DataBind()
                End If
                tblTemp.Clear()
            End If

            ' Get Libraries
            objBIO.LibID = clsSession.GlbSite
            tblTemp = objBIO.GetWaittingPO
            ' tblTemp = objBItemOrder.GetAcqStatus()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            Dim datasourceDDAQCPO = tblTemp
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    tblTemp = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                    ddlAQCPO.DataSource = tblTemp
                    ddlAQCPO.DataValueField = "ID"
                    ddlAQCPO.DataTextField = "POName"
                    ddlAQCPO.DataBind()
                End If
                tblTemp.Clear()
            End If



            ' Get serial information
            objBPeriodical.ItemID = Session("ItemID")
            lblTitle.Text = "<H3>" & Session("Title") & "</H3>"
            tblTemp = objBPeriodical.GetPeriodicalInfor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    If Not IsDBNull(tblTemp.Rows(0).Item("CategoryID")) Then
                        ddlSerCategory.SelectedValue = tblTemp.Rows(0).Item("CategoryID")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("AcqSourceID")) Then
                        ddlAcqSource.SelectedValue = tblTemp.Rows(0).Item("AcqSourceID")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("ReceiptNo")) Then
                        txtContractCode.Text = tblTemp.Rows(0).Item("ReceiptNo")
                        Dim currentIndexDDLAQCPO As Integer = 1
                        If Not datasourceDDAQCPO Is Nothing Then
                            For Each o As DataRow In datasourceDDAQCPO.Rows
                                If o.Item("ReceiptNo") = tblTemp.Rows(0).Item("ReceiptNo") Then
                                    ddlAQCPO.SelectedIndex = currentIndexDDLAQCPO
                                End If
                                currentIndexDDLAQCPO += 1
                            Next
                        End If

                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("BASEDDATE")) Then
                        txtBasedDate.Text = tblTemp.Rows(0).Item("BASEDDATE")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("CEASEDDATE")) Then
                        txtCeasedDate.Text = tblTemp.Rows(0).Item("CEASEDDATE")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("CEASED")) AndAlso tblTemp.Rows(0).Item("CEASED") = 1 Then
                        chkCeased.Checked = True
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Note")) Then
                        txtNote.Text = tblTemp.Rows(0).Item("Note")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("ChangeNote")) Then
                        txtChangeNote.Text = tblTemp.Rows(0).Item("ChangeNote")
                    End If
                    If Not tblTemp.Rows(0).Item("OnSubscription") = "0" Or tblTemp.Rows(0).Item("OnSubscription") Then
                        rdoStatus.Items(0).Selected = True
                    Else
                        rdoStatus.Items(1).Selected = True
                    End If
                    'hidContractID.Value = 0
                    If Not IsDBNull(tblTemp.Rows(0).Item("POID")) Then
                        btnSearch.Visible = True
                        btnViewContract.Visible = True
                        btnRemove.Visible = True
                        If CInt(hidContractID.Value) = 0 Then
                            hidContractID.Value = tblTemp.Rows(0).Item("POID")
                        End If
                        objBPeriodical.POID = tblTemp.Rows(0).Item("POID")
                        intRemainCopies = objBPeriodical.GetRemainCopies()
                        ' Check error
                        Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)
                        If intRemainCopies >= 0 Then
                            lblRemainCopies.Visible = True
                            txtRemainCopies.Visible = True
                        End If
                        txtRemainCopies.Text = intRemainCopies
                    Else
                        btnSearch.Visible = False
                        btnViewContract.Visible = False
                        btnRemove.Visible = False
                    End If
                End If
            End If

            ' Release object
            If Not tblTemp Is Nothing Then
                tblTemp.Dispose()
                tblTemp = Nothing
            End If
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: update information of the current periodical
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intCeased As Int16 = 0
            Dim intOnSubscription As Int16 = 0
            Dim blnResult As Boolean = False


            If chkCeased.Checked Then
                intCeased = 1
            End If
            If rdoStatus.Items(1).Selected Then
                intOnSubscription = 0
            Else
                intOnSubscription = 1
            End If

            If Not ddlAQCPO.SelectedValue Is Nothing AndAlso ddlAQCPO.SelectedValue <> "" Then
                objBPeriodical.POID = ddlAQCPO.SelectedValue
            End If

            objBPeriodical.ItemID = Session("ItemID")
            objBPeriodical.AcqSourceID = ddlAcqSource.SelectedValue
            objBPeriodical.CategoryID = ddlSerCategory.SelectedValue
            objBPeriodical.Ceased = intCeased
            objBPeriodical.CeasedDate = txtCeasedDate.Text.Trim
            objBPeriodical.BasedDate = txtBasedDate.Text.Trim
            objBPeriodical.Note = txtNote.Text.Trim
            objBPeriodical.ChangeNote = txtChangeNote.Text.Trim
            objBPeriodical.OnSubscription = intOnSubscription
            blnResult = objBPeriodical.Acquire

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(7).Text & " " & Session("Title"), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If blnResult Then
                Call BindData()
                Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            Else
                Page.RegisterClientScriptBlock("Fail", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            End If

            'If hidContractID.Value <> 0 Then
            '    Dim intRemainCopies As Integer = 0

            '    lblRemainCopies.Visible = True
            '    txtRemainCopies.Visible = True
            '    objBPeriodical.POID = hidContractID.Value
            '    intRemainCopies = objBPeriodical.GetRemainCopies()

            '    ' Check error
            '    Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            '    txtRemainCopies.Text = intRemainCopies
            'End If

            Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
            '  Response.Redirect("../WSearch.aspx?URL=Acquisition/WAcquire.aspx")
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace