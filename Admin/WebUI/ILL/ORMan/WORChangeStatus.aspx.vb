' class WORChangeStatus.aspx
' Puspose: 
' Creator: Sondp
' CreatedDate: 25/11/2004
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORChangeStatus
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents Label3 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBILLOutRequest As New clsBILLOutRequest
        Private intStatus As Integer = 0

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
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "'); self.close();</script>")
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
            btnCancel.Attributes.Add("OnClick", "self.close();")
        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim tblRequest As DataTable
            Dim blnValid As Boolean = True

            ' Check the request infor
            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblRequest = objBILLOutRequest.GetORInfor
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(6).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(7).Text, objBILLOutRequest.ErrorCode)

                If Not tblRequest Is Nothing Then
                    If tblRequest.Rows.Count > 0 Then
                        If Not IsDBNull(tblRequest.Rows(0).Item("Status")) Then
                            intStatus = CInt(tblRequest.Rows(0).Item("Status"))
                        End If
                        Select Case intStatus
                            Case 2
                                ddlStatus.Items.Clear()
                                ddlStatus.Items.Add(ddlLabel.Items(2).Text)
                                ddlStatus.Items(0).Value = 1
                            Case 5
                                ddlStatus.Items.Clear()
                                ddlStatus.Items.Add(ddlLabel.Items(2).Text)
                                ddlStatus.Items(0).Value = 1
                            Case 6
                                ddlStatus.Items.Clear()
                                ddlStatus.Items.Add(ddlLabel.Items(3).Text)
                                ddlStatus.Items(0).Value = 7
                            Case 8
                                ddlStatus.Items.Clear()
                                ddlStatus.Items.Add(ddlLabel.Items(4).Text)
                                ddlStatus.Items(0).Value = 22
                            Case 14
                                ddlStatus.Items.Clear()
                                ddlStatus.Items.Add(ddlLabel.Items(4).Text)
                                ddlStatus.Items(0).Value = 22
                            Case 13
                                ddlStatus.Items.Clear()
                                ddlStatus.Items.Add(ddlLabel.Items(2).Text)
                                ddlStatus.Items(0).Value = 1
                                ddlStatus.Items.Add(ddlLabel.Items(4).Text)
                                ddlStatus.Items(1).Value = 22
                        End Select
                    Else
                        blnValid = False
                    End If
                Else
                    blnValid = False
                End If
            Else
                blnValid = False
            End If

            ' Success
            If blnValid = False Then
                Page.RegisterClientScriptBlock("Msg2", "<script language = 'javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
            End If
        End Sub

        ' btnChange_Click event
        Private Sub btnChange_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChange.Click
            Call ChangeStat()
        End Sub

        ' ChangeStat method
        Private Sub ChangeStat()
            ' Declare variables
            Dim strContent As String
            Dim intType As Integer = 0
            Dim intSuccess As Int16
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String
            Dim tblTemp As DataTable

            Select Case ddlStatus.SelectedValue
                Case 1
                    intType = 1
                Case 7
                    intType = 2
                Case 22
                    intType = 3
            End Select

            ' Change Status of Outgoing request and sent the message
            If IsNumeric(Request("ILLID")) Then
                If intType <> 0 Then
                    objBILLOutRequest.IllID = CInt(Request("ILLID"))
                    objBILLOutRequest.Note = lblPageTitle.Text & " ( " & ddlStatus.SelectedItem.Text & " ). " & txtNote.Text

                    objBILLOutRequest.ChangeORStatus(intType)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(6).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(7).Text, objBILLOutRequest.ErrorCode)

                    ' Write log
                    WriteLog(66, lblPageTitle.Text & " (RequestID:" & Request("ILLID") & " -> " & ddlStatus.SelectedItem.Text & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

                    tblTemp = objBILLOutRequest.GetORInfor
                    strMailTo = tblTemp.Rows(0).Item("EmailReplyAddress")
                    strContent = objBILLOutRequest.MessageXmlRecord(lblPageTitle.Text & " ( " & ddlStatus.SelectedItem.Text & " ). " & txtNote.Text)
                    intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut, tblTemp.Rows(0).Item("EncodingScheme"))
                    EncodeILLError(objBILLOutRequest.EncodeOk)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(6).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(7).Text, objBILLOutRequest.ErrorCode)

                    ' Success
                    If intSuccess = 0 Then
                        intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                        ' Write Error
                        Call WriteErrorMssg(ddlLabel.Items(6).Text, ErrorMsg, ddlLabel.Items(7).Text, ErrorCode)
                        If intSendMail = 1 Then
                            Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                        Else
                            Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                        End If
                    Else
                        Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                    End If
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

