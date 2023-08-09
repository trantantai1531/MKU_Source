Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestCancel
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

        Dim objBERequest As New clsBERequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindScript()
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
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
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Request/WRequestCancel.js'></script>")

            btnClose.Attributes.Add("Onclick", "javascript:self.close();")
        End Sub

        ' btnAccept_Click event
        ' Purpose: Change the request status to cancel
        Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
            objBERequest.RequestID = CLng(Request("RequestID"))
            objBERequest.StatusID = 3
            Call objBERequest.ChangeStatus()
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBERequest.ErrorMsg, ddlLabel.Items(3).Text, objBERequest.ErrorCode)
            ' WriteLog
            Call WriteLog(72, lblPageTitle.Text & " (RequestID:" & Request("RequestID") & " - " & ddlLabel.Items(0).Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call SentEmail()
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBERequest.ErrorMsg, ddlLabel.Items(3).Text, objBERequest.ErrorCode)
            ' Refresh workform
            Page.RegisterClientScriptBlock("LoadWorkForm", "<script language = 'javascript'>opener.top.main.Workform.location.href='WRequestList.aspx';alert('" & ddlLabel.Items(0).Text & "');self.close();</script>")
        End Sub

        ' btnNot_Click event
        ' Purpose: Change the request status to new
        Private Sub btnNotAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotAccept.Click
            objBERequest.RequestID = CLng(Request("RequestID"))
            objBERequest.StatusID = 1
            Call objBERequest.ChangeStatus()
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBERequest.ErrorMsg, ddlLabel.Items(3).Text, objBERequest.ErrorCode)
            ' WriteLog
            Call WriteLog(72, lblPageTitle.Text & " (RequestID:" & Request("RequestID") & " - " & ddlLabel.Items(1).Text & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
            Call SentEmail()
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBERequest.ErrorMsg, ddlLabel.Items(3).Text, objBERequest.ErrorCode)
            ' Refresh workform
            Page.RegisterClientScriptBlock("LoadWorkForm", "<script language = 'javascript'>opener.parent.Workform.location.href='WRequestList.aspx';alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
        End Sub

        ' SentEmail method
        ' Purpose: Sent email to the customer
        Private Sub SentEmail()
            Dim strEmail As String
            Dim strSubject As String = "E-DELIVERY (Emiclib)"
            Dim strContent As String = ""
            Dim strEmailTo As String = ""
            Dim intSucess As Integer

            objBERequest.RequestID = CLng(Request("RequestID"))
            strContent = txtNote.Text
            If Trim(strContent) <> "" Then
                intSucess = objBERequest.GetMailInfor(strEmailTo)
                Call WriteErrorMssg(ddlLabel.Items(4).Text, objBERequest.ErrorMsg, ddlLabel.Items(3).Text, objBERequest.ErrorCode)
                If intSucess = 0 Then
                    Call SendMail(strSubject, strContent, strEmailTo, True)
                End If
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
