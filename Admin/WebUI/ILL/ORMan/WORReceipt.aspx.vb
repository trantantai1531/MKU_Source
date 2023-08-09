'Class WORReceipt.aspx
'Puspose: Announcement receipt request
'Creator: Tuanhv
'CreatedDate: 25/11/2004
'Modification History:
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORReceipt
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblButton As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBILLOutRequest As New clsBILLOutRequest
        Private objBCopyRight As New clsBCopyRightCompliance
        Private objBCDBS As New clsBCommonDBSystem
        'Page_Load event
        'Purpose: Load information init in this form
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()

            'Bind data init form
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(10).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        'Initialize method
        'Purpose: Init all object using in this class
        Private Sub Initialize()
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            Call objBILLOutRequest.Initialize()

            objBCopyRight.InterfaceLanguage = Session("InterfaceLanguage")
            objBCopyRight.DBServer = Session("DBServer")
            objBCopyRight.ConnectionString = Session("ConnectionString")
            Call objBCopyRight.Initialize()

            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        'BindJavascript method
        'Purpose: Get code javascript using in this form
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnNoSend.Attributes.Add("Onclick", "javascript:self.close()")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDateReceipt, txtDateReceipt, ddlLabel.Items(2).Text)
            SetOnclickCalendar(lnkReceiptPatronDate, txtReceiptPatronDate, ddlLabel.Items(2).Text)
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim intIllID As Integer = 7
            Dim strNote As String = ""
            Dim intResponederID As Integer = 0
            Dim strContent As String = ""
            Dim tblResult As DataTable
            Dim i As Integer

            If Request("ILLID") & "" <> "" Then
                intIllID = CInt(Request("ILLID"))
                hdnILLID.Value = intIllID
            End If

            objBILLOutRequest.IllID = intIllID
            tblResult = objBILLOutRequest.GetORInfor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            If Not tblResult.Rows.Count > 0 Then
                'No find request
                Page.RegisterClientScriptBlock("NotFound", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');self.close();</script>")
                objBILLOutRequest.LogID = 0
            Else
                intResponederID = tblResult.Rows(0).Item("ResponderID")
                hdnResponderID.Value = intResponederID
                If CInt(tblResult.Rows(0).Item("Status")) <> 2 And CInt(tblResult.Rows(0).Item("Status")) <> 8 Then
                    'No find request
                    Page.RegisterClientScriptBlock("CantAct", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');self.close();</script>")
                    btnNoSend.Text = ddlLabel.Items(4).Text
                    Call ChangerControl(False)
                Else
                    'objBILLOutRequest.LogID = tblResult.Rows(0).Item("LogID")
                    If Not IsDBNull(tblResult.Rows(0).Item("DUEDATE")) Then
                        If Not tblResult.Rows(0).Item("DUEDATE") = "" Then
                            txtReceiptPatronDate.Text = tblResult.Rows(0).Item("DUEDATE") & ""
                        End If
                    End If
                    Dim tblTemp As DataTable
                    Try
                        objBCopyRight.ID = 0
                        tblTemp = objBCopyRight.GetCopyright

                        ' Write Error
                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCopyRight.ErrorMsg, ddlLabel.Items(1).Text, objBCopyRight.ErrorCode)

                        If Not tblTemp Is Nothing Then
                            tblTemp = InsertOneRow(tblTemp, "-----------")
                            ' Write Error
                            Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                        End If

                        If Not tblTemp Is Nothing Then
                            If tblTemp.Rows.Count > 0 Then
                                ddlCopyrightCompliance.DataSource = tblTemp
                                ddlCopyrightCompliance.DataTextField = "CopyrightCompliance"
                                ddlCopyrightCompliance.DataValueField = "ID"
                                ddlCopyrightCompliance.DataBind()
                                ddlCopyrightCompliance.Items(0).Value = 0
                                ddlCopyrightCompliance.Items(0).Selected = True
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
                    If Not IsDBNull(tblResult.Rows(0).Item("ServiceType")) Then
                        For i = 0 To ddlServiceType.Items.Count - 1
                            If ddlServiceType.Items(i).Value = tblResult.Rows(0).Item("ServiceType") Then
                                ddlServiceType.SelectedIndex = i
                            End If
                        Next
                    End If
                    If Not IsDBNull(tblResult.Rows(0).Item("CopyrightCompliance")) Then
                        For i = 0 To ddlServiceType.Items.Count - 1
                            If ddlServiceType.Items(i).Value = tblResult.Rows(0).Item("CopyrightCompliance") Then
                                ddlCopyrightCompliance.SelectedIndex = i
                            End If
                        Next
                    End If
                End If
            End If
        End Sub

        'ChangerControl sub
        'Purpose: close some control in form if action not realize
        Sub ChangerControl(ByVal bol As Boolean)
            ddlCopyrightCompliance.Visible = bol
            ddlServiceType.Visible = bol
            lblCopyrightCompliance.Visible = bol
            lblDateReceipt.Visible = bol
            lblLocalDueDate.Visible = bol
            lblServiceType.Visible = bol
            txtDateReceipt.Visible = bol
            txtNote.Visible = bol
            txtReceiptPatronDate.Visible = bol
            btnSend.Visible = bol
        End Sub

        'BindData method
        Private Sub SendData()
            Dim intIllID As Integer = 7
            Dim strNote As String = ""
            Dim intResponederID As Integer = 0
            Dim strContent As String = ""
            Dim tblResult As DataTable
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String

            If hdnILLID.Value & "" <> "" Then
                intIllID = CInt(hdnILLID.Value)
            End If
            If hdnResponderID.Value & "" <> "" Then
                intResponederID = CInt(hdnResponderID.Value)
            End If

            Call objBILLOutRequest.InitValues()
            If ddlServiceType.SelectedValue = 2 Then
                'Update ill_outgoing_request
                objBILLOutRequest.IllID = intIllID
                objBILLOutRequest.Status = 22
                If Not IsDBNull(txtDateReceipt.Text) Then
                    objBILLOutRequest.ReceivedDate = txtDateReceipt.Text
                End If
                If Not IsDBNull(txtReceiptPatronDate.Text) Then
                    objBILLOutRequest.LocalDueDate = txtReceiptPatronDate.Text
                End If
                Call objBILLOutRequest.UpdateOR()
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)
            Else
                'Update ill_outgoing_request
                objBILLOutRequest.IllID = intIllID
                objBILLOutRequest.Status = 9
                If Not IsDBNull(txtDateReceipt.Text) Then
                    objBILLOutRequest.ReceivedDate = txtDateReceipt.Text
                End If
                If Not IsDBNull(txtReceiptPatronDate.Text) Then
                    objBILLOutRequest.LocalDueDate = txtReceiptPatronDate.Text
                End If
                Call objBILLOutRequest.UpdateOR()
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)
            End If

            'Insert ill_outgoing_request_log
            objBILLOutRequest.IllID = intIllID
            objBILLOutRequest.ResponderID = intResponederID
            objBILLOutRequest.APDUType = 8
            objBILLOutRequest.Note = txtNote.Text
            objBILLOutRequest.ProvidedDate = txtDateReceipt.Text
            objBILLOutRequest.Alert = 0
            Call objBILLOutRequest.InsertORequestLog()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            ' Write log
            WriteLog(66, ddlLabel.Items(11).Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            objBILLOutRequest.ServiceType = ddlServiceType.SelectedValue
            strContent = objBILLOutRequest.RceivdXmlRecord(txtDateReceipt.Text, ddlServiceType.Items(ddlServiceType.SelectedValue - 1).Text, txtNote.Text, intIllID)

            'SendMail
            Dim intSuccess As Integer
            objBILLOutRequest.ResponderID = hdnResponderID.Value
            intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
            EncodeILLError(objBILLOutRequest.EncodeOk)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            If intSuccess = 0 Then
                intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                If intSendMail = 1 Then
                    Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                Else
                    Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
            End If
        End Sub

        'btnSend_Click event
        'Purpose: Send data communicate receipt
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Call SendData()
        End Sub

        'Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        'Dispose method
        'Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutRequest Is Nothing Then
                    objBILLOutRequest.Dispose(True)
                    objBILLOutRequest = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace

