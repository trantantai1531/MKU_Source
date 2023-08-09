' Class: WSetBindRule
' Puspose: Set binding rule
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 21/04/2005 by Oanhtn: review 

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSetBindRule
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
        Private objBPeriodical As New clsBPeriodical

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(198) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBPeriodical object
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = CLng(Session("ItemID"))
            Call objBPeriodical.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: Include all javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WSetBindRule.js'></script>")

            txtNOIs.Attributes.Add("OnFocus", "document.forms[0].rdoByIssue.checked=true;")
            txtNODs.Attributes.Add("OnFocus", "document.forms[0].rdoByTime.checked=true;")
            txtNOIs.Attributes.Add("OnChange", "CheckNumBer(this, '" & ddlLabel.Items(2).Text & "');")
            txtNODs.Attributes.Add("OnChange", "CheckNumBer(this, '" & ddlLabel.Items(2).Text & "');")
            btnUpdate.Attributes.Add("OnClick", "if (!CheckAll()) {alert('" & ddlLabel.Items(3).Text & "'); return false;}")

            lnkHdAcquire.NavigateUrl = "WAcquire.aspx"
            lnkHdSetRegularity.NavigateUrl = "WSetRegularity.aspx"
            lnkHdRegister.NavigateUrl = "WCreateIssue.aspx"
            lnkHdReceive.NavigateUrl = "WReceive.aspx"
            lnkHdView.NavigateUrl = "WViewInCalendarMode.aspx"
            lnkHdSummary.NavigateUrl = "WSummaryHoldingManagement.aspx"
            lnkBinding.NavigateUrl = "WBinding.aspx"
            rdoByIssue.Attributes.Add("Onclick", "document.forms[0].txtNOIs.disabled=false;document.forms[0].txtNODs.disabled=true;document.forms[0].txtNODs.value='';")
            rdoByTime.Attributes.Add("Onclick", "document.forms[0].txtNOIs.disabled=true;document.forms[0].txtNODs.disabled=false;document.forms[0].txtNOIs.value='';")
        End Sub

        ' BindData method
        ' Purpose: Bind data for form's controls
        Private Sub BindData()
            Dim intBindingRule As Integer
            Dim intBindingMode As Integer

            lblTitle.Text = "<H3>" & Session("Title") & "</H3>"

            ' Get BindingRule infor
            Call objBPeriodical.GetBindingRule()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            intBindingRule = objBPeriodical.BindingRule
            intBindingMode = objBPeriodical.BindingMode

            ' Showing
            If intBindingMode = 0 Then
                rdoByIssue.Checked = True
                txtNOIs.Text = intBindingRule
            Else
                rdoByTime.Checked = True
                txtNODs.Text = intBindingRule
            End If
        End Sub

        ' Event: btnUpdate_Click
        ' Purpose: set binding rules
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intBindingRule As Integer = 0
            Dim intBindingMode As Integer = 0

            If Not rdoByIssue.Checked Then
                intBindingMode = 1
                intBindingRule = CInt(Trim(txtNODs.Text))
            Else
                intBindingRule = CInt(Trim(txtNOIs.Text))
            End If
            objBPeriodical.BindingRule = intBindingRule
            objBPeriodical.BindingMode = intBindingMode
            Call objBPeriodical.SetBindingRule()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(4).Text & " " & Session("Title"), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Successful
            Page.RegisterClientScriptBlock("Success", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "')</script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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