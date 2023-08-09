Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORAcceptCond
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblContent As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBILLOutRequest As New clsBILLOutRequest

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
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
        Private Sub Initialize()
            ' Init objBILLOutRequest object 
            objBILLOutRequest.ConnectionString = Session("ConnectionString")
            objBILLOutRequest.DBServer = Session("DBServer")
            objBILLOutRequest.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBILLOutRequest.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            btnClose.Attributes.Add("OnClick", "self.close();")
            rdoAccept.Attributes.Add("OnClick", "document.forms[0].rdoDeny.checked=false;")
            rdoDeny.Attributes.Add("OnClick", "document.forms[0].rdoAccept.checked=false;")
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim tblRequest As New DataTable
            Dim tblResponse As New DataTable
            Dim lngLogID As Long = 0
            Dim lngReasonID As Long = 0
            Dim blnValid As Boolean = True

            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblRequest = objBILLOutRequest.GetORInfor

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(7).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(8).Text, objBILLOutRequest.ErrorCode)

                If Not tblRequest Is Nothing Then
                    If tblRequest.Rows.Count > 0 Then
                        ' ResponderID
                        If Not IsDBNull(tblRequest.Rows(0).Item("ResponderID")) Then
                            hdnResponderID.Value = tblRequest.Rows(0).Item("ResponderID")
                        Else
                            hdnResponderID.Value = 0
                        End If

                        tblResponse = objBILLOutRequest.GetOutRequestResponseInfor(CLng(Request("ILLID")))

                        ' Write Error
                        Call WriteErrorMssg(ddlLabel.Items(7).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(8).Text, objBILLOutRequest.ErrorCode)

                        If Not tblResponse Is Nothing AndAlso tblResponse.Rows.Count > 0 Then
                            ' LogID
                            If Session("DBServer") = "ORACLE" Then
                                If Not IsDBNull(tblResponse.Rows(0).Item("LOGID")) Then
                                    lngLogID = CLng(tblResponse.Rows(0).Item("LOGID"))
                                End If
                            Else
                                If Not IsDBNull(tblResponse.Rows(0).Item("LogID")) Then
                                    lngLogID = CLng(tblResponse.Rows(0).Item("LogID"))
                                End If
                            End If
                            ' ReasonID
                            If Not IsDBNull(tblResponse.Rows(0).Item("ReasonID")) Then
                                lngReasonID = CLng(tblResponse.Rows(0).Item("ReasonID"))
                            End If
                            ' Transaction Date and ResponseDate
                            If Not IsDBNull(tblResponse.Rows(0).Item("TRANSACTIONDATE")) Then
                                lblTransactionDate.Text = ddlLabel.Items(1).Text & " " & tblResponse.Rows(0).Item("TRANSACTIONDATE")
                                lblResponseDate.Text = ddlLabel.Items(2).Text & " " & tblResponse.Rows(0).Item("TRANSACTIONDATE")
                            End If
                            ' Condition
                            If Not IsDBNull(tblResponse.Rows(0).Item("ReasonCode")) Then
                                lblCondition.Text = tblResponse.Rows(0).Item("ReasonCode")
                            End If
                            If Not IsDBNull(tblResponse.Rows(0).Item("Reason_Eng")) Then
                                lblCondition.Text = lblCondition.Text & ": " & tblResponse.Rows(0).Item("Reason_Eng")
                            End If
                            If Not IsDBNull(tblResponse.Rows(0).Item("Reason_Viet")) Then
                                lblCondition.Text = lblCondition.Text & " (" & tblResponse.Rows(0).Item("Reason_Viet") & " )"
                            End If
                            ' ResponderSpecReason
                            If Not IsDBNull(tblResponse.Rows(0).Item("ResponderSpecReason")) Then
                                lblCondition.Text = lblCondition.Text & "<BR>" & tblResponse.Rows(0).Item("ResponderSpecReason")
                            End If
                        Else
                            Page.RegisterClientScriptBlock("Msg1", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "');</script>")
                            lngLogID = 0
                        End If
                    Else
                        Page.RegisterClientScriptBlock("Msg3", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');self.close();</script>")
                    End If
                Else
                    blnValid = False
                End If
            Else
                blnValid = False
            End If

            ' Not valid
            If blnValid = False Then
                Page.RegisterClientScriptBlock("Msg4", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');self.close();</script>")
            End If
        End Sub

        ' btnSent_Click event
        Private Sub btnSent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSent.Click
            Call AnswerCondition()
        End Sub

        ' Answer condition method
        Private Sub AnswerCondition()
            ' Declare variables
            Dim strContent As String
            Dim intAnswer As Integer
            Dim intSuccess As Integer = 0
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String

            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CInt(Request("ILLID"))
                objBILLOutRequest.Note = txtNote.Text

                ' Answer or not
                If rdoAccept.Checked = True Then
                    intAnswer = 1
                Else
                    intAnswer = 0
                End If
                objBILLOutRequest.AnswerCondition(intAnswer)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(7).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(8).Text, objBILLOutRequest.ErrorCode)

                If intAnswer = 1 Then
                    ' Write log
                    WriteLog(66, lblPageTitle.Text & " (" & lblConditionTemp.Text & " - " & ddlLabel.Items(10).Text & ", RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                Else
                    ' Write log
                    WriteLog(66, lblPageTitle.Text & " (" & lblConditionTemp.Text & " - " & ddlLabel.Items(11).Text & ", RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                End If
                strContent = objBILLOutRequest.ConrepXmlRecord(intAnswer, txtNote.Text)
                objBILLOutRequest.ResponderID = hdnResponderID.Value
                intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
                EncodeILLError(objBILLOutRequest.EncodeOk)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(7).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(8).Text, objBILLOutRequest.ErrorCode)

                ' Success
                If intSuccess = 0 Then
                    intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(7).Text, ErrorMsg, ddlLabel.Items(8).Text, ErrorCode)

                    If intSendMail = 1 Then
                        Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                    End If
                Else
                    Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
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

