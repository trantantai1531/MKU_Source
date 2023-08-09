Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORRenew
        Inherits clsWBase

        ' Declare variables
        Private objBILLOutRequest As New clsBILLOutRequest
        Dim objBCDBS As New clsBCommonDBSystem
        Private tblORInfor As DataTable

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

        ' Page_load event
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
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(14).Text & "'); self.close();</script>")
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
            ' Init objBCDBS object 
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ORRenewJs", "<script language = 'javascript' src = '../JS/ORMan/WORRenew.js'></script>")
            txtRenewDate.Attributes.Add("onkeypress", "return Reset();")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lbkCalendar, txtRenewDate, ddlLabel.Items(11).Text)
            btnCancel.Attributes.Add("OnClick", "self.close();")
        End Sub

        ' BindData method
        ' Purpose: Check the request data and display the result
        Private Sub BindData()
            ' Declare variables
            Dim blnExist As Boolean = True
            Dim intStatus As Integer
            Dim blnValidStatus As Boolean = True
            hidLogID.Value = ""
            ' Check the existing of request
            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblORInfor = objBILLOutRequest.GetORInfor

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(12).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(13).Text, objBILLOutRequest.ErrorCode)

                If Not tblORInfor Is Nothing Then
                    If tblORInfor.Rows.Count > 0 Then
                        ' ResponderID
                        If Not IsDBNull(tblORInfor.Rows(0).Item("ResponderID")) Then
                            hdnResponderID.Value = tblORInfor.Rows(0).Item("ResponderID")
                        Else
                            hdnResponderID.Value = 0
                        End If
                        If Not IsDBNull(tblORInfor.Rows(0).Item("Status")) Then
                            intStatus = CInt(tblORInfor.Rows(0).Item("Status"))
                            If intStatus = 9 Or intStatus = 11 Or intStatus = 12 Or intStatus = 13 Then
                                Call BindRenewInfor()
                            Else
                                blnValidStatus = False
                            End If
                        Else
                            blnValidStatus = False
                        End If
                    Else
                        blnExist = False
                    End If
                Else
                    blnExist = False
                End If
            Else
                blnExist = False
            End If

            ' The request is not exist or have not been selected requests
            If blnExist = False Then
                Page.RegisterClientScriptBlock("NotExist", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
            End If

            ' Invalid Status
            If blnValidStatus = False Then
                Page.RegisterClientScriptBlock("InValidStatus", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');self.close();</script>")
            End If
        End Sub

        ' RenewIt method
        ' Purpose: renew the request and sent the message
        Private Sub BindRenewInfor()
            ' Declare variables
            Dim tblRenew As DataTable
            Dim blnHaveLog As Boolean = True

            objBILLOutRequest.IllID = CLng(Request("ILLID"))
            tblRenew = objBILLOutRequest.Get_ILL_OR_Renew_Log

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(12).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(13).Text, objBILLOutRequest.ErrorCode)

            ' Check the request log
            If Not tblRenew Is Nothing Then
                If tblRenew.Rows.Count > 0 Then
                    blnHaveLog = True
                Else
                    blnHaveLog = False
                End If
            Else
                blnHaveLog = False
            End If

            ' Bind the renew infor of request
            If blnHaveLog = False Then
                lblContent.Text = ddlLabel.Items(10).Text
                hidLogID.Value = ""
                ' Due Date
                If Not IsDBNull(tblORInfor.Rows(0).Item("DUEDATE")) Then
                    lblContent.Text = lblContent.Text & "<BR><BR>" & ddlLabel.Items(7).Text & " " & Trim(CStr(tblORInfor.Rows(0).Item("DUEDATE")))
                End If
            Else
                If Not IsDBNull(tblRenew.Rows(0).Item("LogID")) Then
                    If Session("DBServer") = "ORACLE" Then
                        hidLogID.Value = tblRenew.Rows(0).Item("LOGID")
                    Else
                        hidLogID.Value = tblRenew.Rows(0).Item("LogID")
                    End If
                End If
                ' Renewable or not. If not, still can sent the message
                If Not IsDBNull(tblRenew.Rows(0).Item("Renewable")) Then
                    If tblRenew.Rows(0).Item("Renewable") = 0 Then
                        lblContent.Text = ddlLabel.Items(9).Text
                    End If
                End If
                ' Trans Date
                If Not IsDBNull(tblRenew.Rows(0).Item("TRANSACTIONDATE")) Then
                    lblContent.Text = lblContent.Text & "<BR><BR>" & ddlLabel.Items(6).Text & " " & Trim(CStr(tblRenew.Rows(0).Item("TRANSACTIONDATE")))
                End If
                ' Due Date
                If Not IsDBNull(tblRenew.Rows(0).Item("DUEDATE")) Then
                    lblContent.Text = lblContent.Text & "<BR><BR>" & ddlLabel.Items(7).Text & " " & Trim(CStr(tblRenew.Rows(0).Item("DUEDATE")))
                End If
            End If

            ' Local Due Date
            If Not IsDBNull(tblORInfor.Rows(0).Item("LOCALDUEDATE")) Then
                lblContent.Text = lblContent.Text & "<BR><BR>" & ddlLabel.Items(8).Text & " " & Trim(CStr(tblORInfor.Rows(0).Item("LOCALDUEDATE")))
            End If
        End Sub

        ' btnSent_Click event
        Private Sub btnSent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSent.Click
            ' Declare variables
            Dim strContent As String
            Dim intAnswer As Integer
            Dim intSuccess As Integer = 0
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String

            Call objBILLOutRequest.InitValues()

            objBILLOutRequest.IllID = CLng(Request("ILLID"))
            objBILLOutRequest.Status = 10
            objBILLOutRequest.SubSQL = "Status IN (9, 11,12, 13)"
            intSuccess = objBILLOutRequest.UpdateOR()

            objBILLOutRequest.IllID = CLng(Request("ILLID"))
            objBILLOutRequest.ResponderID = hdnResponderID.Value
            objBILLOutRequest.APDUType = 13
            objBILLOutRequest.Note = txtNote.Text
            objBILLOutRequest.Alert = 0
            objBILLOutRequest.DueDate = txtRenewDate.Text.Trim
            Call objBILLOutRequest.InsertORequestLog()
            If hidLogID.Value <> "" Then
                objBCDBS.SQLStatement = "UPDATE ILL_OUTGOING_REQUESTS_LOG SET Alert = 0 WHERE LogID = " & hidLogID.Value
                Call objBCDBS.ProcessItem()
            End If
            objBILLOutRequest.IllID = CLng(Request("ILLID"))
            objBILLOutRequest.Note = txtNote.Text

            strContent = objBILLOutRequest.RenewlXmlRecord(Trim(txtRenewDate.Text), txtNote.Text)

            intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
            EncodeILLError(objBILLOutRequest.EncodeOk)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(12).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(13).Text, objBILLOutRequest.ErrorCode)

            'objBILLOutRequest.Renew(Trim(txtRenewDate.Text), txtNote.Text, CLng(Request("ILLID")))
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(12).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(13).Text, objBILLOutRequest.ErrorCode)

            ' Write log
            WriteLog(66, lblPageTitle.Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

            ' Success
            If intSuccess = 0 Then
                intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(12).Text, ErrorMsg, ddlLabel.Items(13).Text, ErrorCode)
                If intSendMail = 1 Then
                    Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                Else
                    Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
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

