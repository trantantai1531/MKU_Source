' Class WORReturn.aspx
' Puspose: Return item,... 
' Creator: Tuanhv
' CreatedDate: 23/12/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORReturn
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ResponederID As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variable
        Private objBILLOutRequest As New clsBILLOutRequest
        Private objBCommonBusiness As New clsBCommonBusiness

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()

            If Not Page.IsPostBack Then
                ' Insert data to ddlCurrency
                Call InitData()
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(154) Then
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "'); self.close();</script>")
                Response.End()
            End If
        End Sub

        ' Initialize method
        ' Pupose: Init all object using in this class
        Private Sub Initialize()
            ' Init objBILLOutRequest object
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            Call objBILLOutRequest.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            Call objBCommonBusiness.Initialize()
        End Sub

        ' InitData method
        ' Pupose: Get data insert into ddlCurrency
        Private Sub InitData()
            Dim tblCurrency As New DataTable

            objBCommonBusiness.CurrencyCode = ""
            tblCurrency = objBCommonBusiness.GetCurrency
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(1).Text, objBCommonBusiness.ErrorCode)

            If Not tblCurrency Is Nothing Then
                If tblCurrency.Rows.Count > 0 Then
                    ddlCurrency.DataSource = tblCurrency
                    ddlCurrency.DataTextField = "CurrencyCode"
                    ddlCurrency.DataValueField = "CurrencyCode"
                    ddlCurrency.DataBind()
                End If
            End If
            Call BindData()
        End Sub

        '  BindData method
        Private Sub BindData()
            Dim intIllID As Integer = 7
            Dim strNote As String = ""
            Dim intResponederID As Integer = 0
            Dim strContent As String = ""
            Dim tblResult As DataTable

            If Request("ILLID") & "" <> "" Then
                intIllID = CInt(Request("ILLID"))
                hdnILLID.Value = intIllID
            End If

            objBILLOutRequest.IllID = intIllID
            tblResult = objBILLOutRequest.GetORInfor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            If Not tblResult Is Nothing Then
                If Not tblResult.Rows.Count > 0 Then
                    ' No find request
                    lblNote.Text = ddlLabel.Items(2).Text
                    objBILLOutRequest.LogID = ""
                Else
                    intResponederID = tblResult.Rows(0).Item("ResponderID")
                    hdnResponderID.Value = intResponederID
                    If CInt(tblResult.Rows(0).Item("Status")) <> 9 And CInt(tblResult.Rows(0).Item("Status")) <> 10 And CInt(tblResult.Rows(0).Item("Status")) <> 11 And CInt(tblResult.Rows(0).Item("Status")) <> 12 And CInt(tblResult.Rows(0).Item("Status")) <> 13 And CInt(tblResult.Rows(0).Item("Status")) <> 16 Then
                        lblNote.Text = ddlLabel.Items(8).Text
                        btnNoSend.Text = ddlLabel.Items(7).Text
                        Call ChangerControl(False)
                    End If
                End If
            End If
        End Sub

        ' ChangerControl method
        ' Pupose: close some control in form
        Sub ChangerControl(ByVal blnValue As Boolean)
            txtDateReturn.Visible = blnValue
            txtInsure.Visible = blnValue
            txtNote.Visible = blnValue
            txtSendFollow.Visible = blnValue
            lblCurrency.Visible = blnValue
            lblDateReturn.Visible = blnValue
            lblInsure.Visible = blnValue
            lblNote.Visible = blnValue
            lblTitleFromName.Visible = blnValue
            ddlCurrency.Visible = blnValue
            btnSend.Visible = blnValue
        End Sub

        ' BindData method
        Private Sub SendData()
            Dim intIllID As Integer = 7
            Dim strNote As String = ""
            Dim intResponderID As Integer = 0
            Dim strContent As String = ""
            Dim intSuccess As Integer = 0
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String
            Dim strSubject As String

            If hdnILLID.Value & "" <> "" Then
                intIllID = CInt(hdnILLID.Value)
                hdnILLID.Value = intIllID
            End If
            If Not hdnResponderID.Value & "" = "" Then
                intResponderID = CInt(hdnResponderID.Value)
            End If

            If Not IsDBNull(txtNote.Text) Then
                strNote = txtNote.Text
            Else
                strNote = ""
            End If

            Call objBILLOutRequest.InitValues()

            ' Update ill_outgoing_request
            objBILLOutRequest.IllID = intIllID
            objBILLOutRequest.Status = 14
            objBILLOutRequest.ReturnedDate = txtDateReturn.Text
            Call objBILLOutRequest.UpdateOR()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            ' Insert ill_outgoing_request_log
            objBILLOutRequest.IllID = intIllID
            objBILLOutRequest.APDUType = 10
            objBILLOutRequest.TransactionDate = ""
            If Not IsDBNull(txtDateReturn.Text) Then
                objBILLOutRequest.ProvidedDate = txtDateReturn.Text
            End If
            If Not IsDBNull(txtNote.Text) Then
                objBILLOutRequest.Note = txtNote.Text
            End If
            objBILLOutRequest.Alert = 0
            If txtInsure.Text <> "" Then
                objBILLOutRequest.InsuredForCost = CDbl(txtInsure.Text)
            End If
            objBILLOutRequest.CurrencyCode2 = ddlCurrency.SelectedValue
            If Not IsDBNull(txtSendFollow.Text) Then
                objBILLOutRequest.ReturnedVia = txtSendFollow.Text
            End If
            objBILLOutRequest.ResponderID = intResponderID
            Call objBILLOutRequest.InsertORequestLog()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)
            strContent = objBILLOutRequest.RetrndXmlRecord(txtDateReturn.Text, txtSendFollow.Text, txtInsure.Text, ddlCurrency.SelectedValue, txtNote.Text, intIllID)
            objBILLOutRequest.ResponderID = hdnResponderID.Value
            intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
            EncodeILLError(objBILLOutRequest.EncodeOk)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(1).Text, objBILLOutRequest.ErrorCode)

            strSubject = lblTitleFromName.Text

            ' Write log
            WriteLog(66, lblTitleFromName.Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

            If intSuccess = 0 Then
                intSendMail = SendMail(strSubject, strContentOut, strMailTo, False, strMailFrom)
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, ErrorMsg, ddlLabel.Items(1).Text, ErrorCode)
                If intSendMail = 1 Then
                    Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                Else
                    Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
            End If
        End Sub

        ' BindJavascript method
        ' Pupose: Get code javascript using in this form
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkDateReturn, txtDateReturn, ddlLabel.Items(5).Text)
            btnNoSend.Attributes.Add("Onclick", "javascript:self.close()")
            Me.SetCheckNumber(txtInsure, ddlLabel.Items(10).Text, ">0")
        End Sub

        ' Event btnSend_Click
        Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
            Call SendData()
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBILLOutRequest Is Nothing Then
                    objBILLOutRequest.Dispose(True)
                    objBILLOutRequest = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace