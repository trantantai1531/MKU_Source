Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WRequestSendFile
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
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(159) Then
                Call WriteErrorMssg(ddlLabel.Items(8).Text)
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
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Request/WRequestSendFile.js'></script>")

            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
            btnSend.Attributes.Add("OnClick", "EncryptionTags(document.forms[0].txtContent);if (CheckNull(document.forms[0].txtSubject) || CheckNull(document.forms[0].txtContent)) {alert('" & ddlLabel.Items(0).Text & "');DecryptionTags(document.forms[0].txtContent); return false;}")
        End Sub

        ' BindData method
        ' Purpose: load form
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim lngRequestID As Long = 0
            Dim strMode As String = "EMAIL"
            Dim strFileURL As String

            strFileURL = objBERequest.GetServerIP
            Call WriteErrorMssg(ddlLabel.Items(10).Text, objBERequest.ErrorMsg, ddlLabel.Items(9).Text, objBERequest.ErrorCode)

            If Not Request("RequestID") & "" = "" AndAlso IsNumeric(Request("RequestID")) Then
                hidRequestID.Value = Request("RequestID")
                lngRequestID = CLng(hidRequestID.Value)
                objBERequest.RequestID = lngRequestID
                tblTemp = objBERequest.GetRequestInfor()
                Call WriteErrorMssg(ddlLabel.Items(10).Text, objBERequest.ErrorMsg, ddlLabel.Items(9).Text, objBERequest.ErrorCode)
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        strFileURL = "&lt;A href=""" & objSysPara(8) & "/WDownLoad.aspx" & "?FileID=" & tblTemp.Rows(0).Item("ID") & """&gt;" & objSysPara(8) & "/WDownLoad.aspx" & "?FileID=" & tblTemp.Rows(0).Item("ID") & "&lt;/A&gt;" & ". "
                        strMode = tblTemp.Rows(0).Item("Mode")
                        If strMode = "CD" Then
                            txtContent.Text = ddlLabel.Items(1).Text
                        ElseIf strMode = "URL" Then
                            txtContent.Text = ddlLabel.Items(3).Text & Chr(10) & strFileURL.Replace("&lt;", "<").Replace("&gt;", ">") & Chr(10) & ". " & ddlLabel.Items(4).Text & Chr(10) & ddlLabel.Items(11).Text & " " & objSysPara(10) & " " & ddlLabel.Items(12).Text
                        Else
                            txtContent.Text = ddlLabel.Items(5).Text
                            hidPath.Value = tblTemp.Rows(0).Item("PhysicalPath")
                        End If
                    End If
                End If
            End If
        End Sub

        ' btnSend_Click event
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Dim strSubject As String = Trim(txtSubject.Text)
            Dim strContent As String = Trim(txtContent.Text)
            Dim lngRequestID As Long = CLng(Request("RequestID"))
            Dim intSucess As Integer
            Dim intSendMail As Integer
            Dim strEmailTo As String = ""

            objBERequest.RequestID = lngRequestID

            intSucess = objBERequest.GetMailInfor(strEmailTo)

            If Trim(strContent) <> "" Then
                intSucess = objBERequest.GetMailInfor(strEmailTo)

                If intSucess = 0 Then
                    If Not hidPath.Value.Trim = "" Then
                        intSendMail = SendMail(strSubject, strContent, strEmailTo, True, "", hidPath.Value)
                    Else
                        intSendMail = SendMail(strSubject, Replace(Replace(strContent, "&lt;", "<"), "&gt;", ">"), strEmailTo, True)
                    End If
                    Call WriteErrorMssg(ddlLabel.Items(10).Text, ErrorMsg, ddlLabel.Items(9).Text, ErrorCode)

                    If intSendMail = 1 Then
                        objBERequest.RequestID = CInt(Request("RequestID"))
                        objBERequest.StatusID = 5 ' Shipped
                        Call objBERequest.ChangeStatus()
                        Call WriteErrorMssg(ddlLabel.Items(10).Text, objBERequest.ErrorMsg, ddlLabel.Items(9).Text, objBERequest.ErrorCode)
                        ' WriteLog
                        Call WriteLog(72, lblPageTitle.Text & " (RequestID:" & Request("RequestID") & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                        Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>opener.top.main.Workform.location.href='WRequestList.aspx';alert('" & ddlLabel.Items(6).Text & "'); self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("FailJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "')</script>")
                    End If
                Else
                    Page.RegisterClientScriptBlock("FailJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "')</script>")
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