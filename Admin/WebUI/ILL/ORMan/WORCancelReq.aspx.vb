Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORCancelReq
        Inherits clsWBase

        ' Declare variables
        Private objBILLOutRequest As New clsBILLOutRequest

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
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & "'); self.close();</script>")
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
            Dim intStatus As Int16 = 0
            Dim blnValid As Boolean = True

            ' Check the request infor
            blnValid = False
            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblRequest = objBILLOutRequest.GetORInfor

                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(5).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(6).Text, objBILLOutRequest.ErrorCode)
                If Not tblRequest Is Nothing Then
                    If tblRequest.Rows.Count > 0 Then
                        If Not IsDBNull(tblRequest.Rows(0).Item("Status")) Then
                            intStatus = CInt(tblRequest.Rows(0).Item("Status"))
                        End If
                        If intStatus <> 2 And intStatus <> 5 Then
                            Page.RegisterClientScriptBlock("Msg1", "<script language = 'javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
                        End If
                        ' ResponderID
                        If Not IsDBNull(tblRequest.Rows(0).Item("ResponderID")) Then
                            hdnResponderID.Value = tblRequest.Rows(0).Item("ResponderID")
                        Else
                            hdnResponderID.Value = 0
                        End If
                        blnValid = True
                    End If
                End If
            End If

            ' blnValid is False (Not Success)
            If blnValid = False Then
                Page.RegisterClientScriptBlock("Msg", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');self.close();</script>")
            End If

        End Sub

        ' btnSent_Click event
        Private Sub btnSent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSent.Click
            Call CancelIt()
        End Sub

        ' CancelIt method
        Private Sub CancelIt()
            ' Declare variables
            Dim strContent As String
            Dim intAnswer As Integer
            Dim intSuccess As Int16
            Dim intSendMail As Int16 = 0
            Dim strMailFrom As String
            Dim strMailTo As String
            Dim strContentOut As String

            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CInt(Request("ILLID"))
                objBILLOutRequest.Note = txtNote.Text

                objBILLOutRequest.CancelOR()
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(5).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(6).Text, objBILLOutRequest.ErrorCode)

                ' Write log
                WriteLog(66, lblPageTitle.Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)

                strContent = objBILLOutRequest.CancelXmlRecord(txtNote.Text)
                objBILLOutRequest.ResponderID = hdnResponderID.Value
                intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
                EncodeILLError(objBILLOutRequest.EncodeOk)
                ' Write Error
                Call WriteErrorMssg(ddlLabel.Items(5).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(6).Text, objBILLOutRequest.ErrorCode)

                If intSuccess = 0 Then
                    intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                    ' Write Error
                    Call WriteErrorMssg(ddlLabel.Items(5).Text, ErrorMsg, ddlLabel.Items(6).Text, ErrorCode)
                    If intSendMail = 1 Then
                        Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                    End If
                Else
                    Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
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

