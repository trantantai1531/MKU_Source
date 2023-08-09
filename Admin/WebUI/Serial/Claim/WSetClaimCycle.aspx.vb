' Class: WSetClaimCycle
' Puspose: Send Claim email
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 18/10/2004 by Sondp: SetClaimCycle

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSetClaimCycle
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lbl As System.Web.UI.WebControls.Label


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
            Call CheckFormPermissions()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                lblItemTitle.Text = "<H3 class='main-head-form'>" & Session("Title") & "</H3>"
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermissions
        ' Purpose: Check permission
        Private Sub CheckFormPermissions()
            If Not CheckPemission(95) Then
                btnSetUP.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Not IsNumeric(Session("ItemID")) Then
                Response.Redirect("../WSearch.aspx?URL=Claim/WSetClaimCycle.aspx")
            End If

            'Init objBPeriodical object
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPeriodical.Initialize()
        End Sub

        ' Method: BindScript
        Public Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Claim/WSetClaimCycle.js'></script>")

            hrfClaimTemplate.Attributes.Add("OnClick", "javascript:parent.Workform.location.href='WClaimTemplateManagement.aspx';return false;")
            hrfClaim.Attributes.Add("OnClick", "javascript:parent.Workform.location.href='WClaim.aspx';return false;")
            hrfShowClaimList.Attributes.Add("OnClick", "javascript:parent.Workform.location.href='WShowClaimList.aspx';return false;")

            btnReset.Attributes.Add("OnClick", "javascript:return ResetAll();")
            btnSetUP.Attributes.Add("OnClick", "javascript:if (CheckAllValue('" & ddlLabel.Items(6).Text & "')) {return(CheckForSetUp('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(2).Text & "'));} else{return false;}")

            txtClaimCycle1.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(2).Text & "'); this.focus(); this.value='30';}")
            txtClaimCycle2.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(2).Text & "'); this.focus(); this.value='60';}")
            txtClaimCycle3.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(2).Text & "'); this.focus(); this.value='90';}")
            txtDeliveryTime.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(2).Text & "'); this.focus(); this.value='1';}")
        End Sub

        ' Method: Bind Data
        Private Sub BindData()
            Dim tblSerItem As DataTable
            objBPeriodical.ItemID = CLng(Session("ItemID"))
            tblSerItem = objBPeriodical.GetPeriodicalInfor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            If Not tblSerItem Is Nothing AndAlso tblSerItem.Rows.Count > 0 Then
                txtDeliveryTime.Text = CStr(tblSerItem.Rows(0).Item("DeliveryTime") & "").Trim
                txtClaimCycle1.Text = CStr(tblSerItem.Rows(0).Item("ClaimCycle1") & "").Trim
                txtClaimCycle2.Text = CStr(tblSerItem.Rows(0).Item("ClaimCycle2") & "").Trim
                txtClaimCycle3.Text = CStr(tblSerItem.Rows(0).Item("ClaimCycle3") & "").Trim
                hdDeliveryTime.Value = txtDeliveryTime.Text
                hdClaimCycle1.Value = txtClaimCycle1.Text
                hdClaimCycle2.Value = txtClaimCycle2.Text
                hdClaimCycle3.Value = txtClaimCycle3.Text
            End If
        End Sub

        ' Event: btnSetUP_Click
        ' Purpose: Setup claim cycles
        Private Sub btnSetUP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetUP.Click
            objBPeriodical.ItemID = Session("ItemID")
            objBPeriodical.DeliveryTime = CInt(txtDeliveryTime.Text.Trim)
            objBPeriodical.ClaimCycle1 = CInt(txtClaimCycle1.Text.Trim)
            objBPeriodical.ClaimCycle2 = CInt(txtClaimCycle2.Text.Trim)
            objBPeriodical.ClaimCycle3 = CInt(txtClaimCycle3.Text.Trim)
            objBPeriodical.SetClaimCycle()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            ' WriteLog
            Call WriteLog(115, ddlLabel.Items(4).Text & " " & Session("Title"), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'> alert('" & ddlLabel.Items(3).Text & "');</script>")
            Call BindData()
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