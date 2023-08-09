Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestModeMan

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

        Private objBERequestMode As New clsBERequestMode
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call GetRequestMode()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(160) Then
                Call WriteErrorMssg(lblLabel1.Text)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Tool/WRequestModeMan.js'></script>")

            lstRequestMode.Attributes.Add("OnChange", "javascript:Edit_List();if (this.options[this.options.selectedIndex].value != 0) {document.forms[0].txtRequestMode.value = this.options[this.options.selectedIndex].text} else {document.forms[0].txtRequestMode.value = '';}document.forms[0].txtRequestMode.focus();")
            btnAddNew.Attributes.Add("OnClick", "javascript:if (CheckNull(document.forms[0].txtRequestMode)) {alert('" & lblMsg.Text & "');return false;}")
            btnUpdate.Attributes.Add("OnClick", "javascript:if (CheckNull(document.forms[0].txtRequestMode)) {alert('" & lblMsg.Text & "');return false;}")
            btnDelete.Attributes.Add("OnClick", "javascript: if (!confirm('" & lblConfirm.Text & "') ) {return false;}")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init for objBECustomer
            objBERequestMode.InterfaceLanguage = Session("InterfaceLanguage")
            objBERequestMode.DBServer = Session("DBServer")
            objBERequestMode.ConnectionString = Session("ConnectionString")
            objBERequestMode.Initialize()

            ' Init for objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' GetRequestMode method
        Private Sub GetRequestMode()
            Dim tblRequestMode As New DataTable
            Dim lstItem As New ListItem

            objBERequestMode.RequestModeID = 0
            tblRequestMode = objBERequestMode.GetRequestMode
            Call WriteErrorMssg(lblLabel3.Text, objBERequestMode.ErrorMsg, lblLabel2.Text, objBERequestMode.ErrorCode)

            If Not tblRequestMode Is Nothing AndAlso tblRequestMode.Rows.Count > 0 Then
                tblRequestMode = objBCDBS.InsertOneRow(tblRequestMode, lblAddNew.Text)
                Call WriteErrorMssg(lblLabel3.Text, ErrorMsg, lblLabel2.Text, ErrorCode)
                With lstRequestMode
                    .DataSource = tblRequestMode
                    .DataTextField = "Note"
                    .DataValueField = "ModeID"
                    .DataBind()
                End With
            Else
                lstRequestMode.Items.Clear()
                lstItem.Text = lblAddNew.Text
                lstItem.Value = 0
                lstRequestMode.Items.Add(lstItem)
            End If
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Call UpdateRequestMode()
            Call BindScript()
            Call GetRequestMode()
        End Sub

        ' btnAddNew_Click event
        Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNew.Click
            Call CreateRequestMode()
            Call BindScript()
            Call GetRequestMode()
            txtRequestMode.Text = ""
        End Sub

        ' btnDelete_Click event
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Call DeleteRequestMode()
            Call BindScript()
            Call GetRequestMode()
            txtRequestMode.Text = ""
        End Sub

        ' UpdateRequestMode method
        Private Function UpdateRequestMode() As Integer
            objBERequestMode.RequestModeID = lstRequestMode.SelectedValue
            objBERequestMode.RequestMode = txtRequestMode.Text
            UpdateRequestMode = objBERequestMode.Update()
            Call WriteErrorMssg(lblLabel3.Text, objBERequestMode.ErrorMsg, lblLabel2.Text, objBERequestMode.ErrorCode)
            If UpdateRequestMode <> 0 Then
                Page.RegisterClientScriptBlock("Unssucess", "<script language='javascript'>alert('" & lblError.Text & "');</script>")
            Else
                Call WriteLog(73, ddlLog.Items(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
            txtRequestMode.Text = ""
        End Function

        ' CreateRequestMode method
        Private Function CreateRequestMode() As Integer
            objBERequestMode.RequestMode = txtRequestMode.Text
            CreateRequestMode = objBERequestMode.Create()
            Call WriteErrorMssg(lblLabel3.Text, objBERequestMode.ErrorMsg, lblLabel2.Text, objBERequestMode.ErrorCode)
            If CreateRequestMode <> 0 Then
                Page.RegisterClientScriptBlock("Unssucess", "<script language='javascript'>alert('" & lblError.Text & "');</script>")
            Else
                Call WriteLog(73, ddlLog.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            End If
            txtRequestMode.Text = ""
        End Function

        ' DeleteRequestMode method
        Private Sub DeleteRequestMode()
            objBERequestMode.RequestModeID = lstRequestMode.SelectedValue
            objBERequestMode.Delete()
            Call WriteErrorMssg(lblLabel3.Text, objBERequestMode.ErrorMsg, lblLabel2.Text, objBERequestMode.ErrorCode)
            Call WriteLog(73, ddlLog.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBERequestMode Is Nothing Then
                    objBERequestMode.Dispose(True)
                    objBERequestMode = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace
