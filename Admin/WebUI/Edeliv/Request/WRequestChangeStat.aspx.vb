Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestChangeStat
        Inherits clsWBase
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel5 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel6 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Dim objBERequest As New clsBERequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                CheckRequest()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(3).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBERequest object
            objBERequest.ConnectionString = Session("ConnectionString")
            objBERequest.DBServer = Session("DBServer")
            objBERequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBERequest.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnCancel.Attributes.Add("OnClick", "javascript:self.close(); return false;")
        End Sub

        ' CheckRequest method
        ' PurposeL: Check the existing of request
        Private Sub CheckRequest()
            Dim tblRequest As DataTable
            Dim intStatus As Integer = 0

            ' Check the request ID
            If Not Trim(Request("RequestID")) Is Nothing Then
                objBERequest.RequestID = CInt(Trim(Request("RequestID")))
                tblRequest = objBERequest.GetRequestInfor()
                Call WriteErrorMssg(ddlLabel.Items(5).Text, objBERequest.ErrorMsg, ddlLabel.Items(4).Text, objBERequest.ErrorCode)
                If Not tblRequest Is Nothing Then
                    If tblRequest.Rows.Count > 0 Then
                        intStatus = CInt(tblRequest.Rows(0).Item("StatusID"))
                        ' Check the status of request and display the action(s) can be applied change
                        If intStatus = 7 Then
                            ddlStatus.Items.RemoveAt(1)
                        End If
                        btnChange.Visible = True
                        btnCancel.Visible = True
                        lblChangeStatus.Visible = True
                        ddlStatus.Visible = True
                    Else
                        Page.RegisterClientScriptBlock("RegNotFound1", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
                        btnChange.Visible = False
                        btnCancel.Visible = False
                        lblChangeStatus.Visible = False
                        ddlStatus.Visible = False
                    End If
                Else
                    Page.RegisterClientScriptBlock("RegNotFound2", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
                    btnChange.Visible = False
                    btnCancel.Visible = False
                    lblChangeStatus.Visible = False
                    ddlStatus.Visible = False
                End If
            Else
                Page.RegisterClientScriptBlock("NotService", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script")
                btnChange.Visible = False
                btnCancel.Visible = False
                lblChangeStatus.Visible = False
                ddlStatus.Visible = False
            End If
        End Sub

        ' ChangeStatus method
        Private Sub ChangeStatus()
            objBERequest.RequestID = CInt(Request("RequestID"))
            objBERequest.StatusID = ddlStatus.SelectedValue
            objBERequest.ChangeStatus()
            Call WriteErrorMssg(ddlLabel.Items(5).Text, objBERequest.ErrorMsg, ddlLabel.Items(4).Text, objBERequest.ErrorCode)
            ' WriteLog
            Call WriteLog(72, lblPageTitle.Text & " (RequestID:" & Request("RequestID") & " -> " & ddlStatus.SelectedItem.Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
        End Sub

        ' btnChange_Click event
        Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
            Call ChangeStatus()
            ' Refresh workform
            Page.RegisterClientScriptBlock("LoadWorkForm", "<script language = 'javascript'>opener.top.main.Workform.location.href='WRequestList.aspx';</script>")
            Page.RegisterClientScriptBlock("StatusChanged", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "');self.close();</script>")
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBERequest Is Nothing Then
                    objBERequest.Dispose(True)
                    objBERequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace