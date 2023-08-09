Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WORSendReq
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
                Page.RegisterClientScriptBlock("invaliduser", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "'); self.close();</script>")
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
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            If IsNumeric(Request("ILLID")) Then
                btnViewMail.Attributes.Add("OnClick", "OpenWindow('WOREdiFactView.aspx?ILLID=" & Request("ILLID") & "','WORSetIem',620,400,100,50);")
            End If
        End Sub

        ' BindData method
        ' Purpose: Check the request data and display the result
        Private Sub BindData()
            ' Declare variables
            Dim blnExist As Boolean = True
            Dim intStatus As Integer
            Dim blnValidStatus As Boolean = True
            Dim tblORInfor As DataTable

            blnExist = False
            blnValidStatus = False
            ' Check the existing of request
            If IsNumeric(Request("ILLID")) Then
                objBILLOutRequest.IllID = CLng(Request("ILLID"))
                tblORInfor = objBILLOutRequest.GetORInfor
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(4).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(5).Text, objBILLOutRequest.ErrorCode)

                If Not tblORInfor Is Nothing Then
                    If tblORInfor.Rows.Count > 0 Then
                        If Not IsDBNull(tblORInfor.Rows(0).Item("Status")) Then
                            intStatus = CInt(tblORInfor.Rows(0).Item("Status"))
                            If intStatus = 2 Or intStatus = 21 Then
                                blnValidStatus = True
                            End If
                        End If
                        ' ResponderID
                        If Not IsDBNull(tblORInfor.Rows(0).Item("ResponderID")) Then
                            hdnResponderID.Value = tblORInfor.Rows(0).Item("ResponderID")
                        Else
                            hdnResponderID.Value = 0
                        End If
                        blnExist = True
                    End If
                End If
            End If

            ' The request is not exist or have not been selected requests
            If blnExist = False Then
                Page.RegisterClientScriptBlock("NotExist", "<script language='javascript'>alert('" & ddlLabel.Items(0).Text & "');self.close();</script>")
            End If

            ' Invalid Status
            If blnValidStatus = False Then
                Page.RegisterClientScriptBlock("InValidStatus", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text & "');self.close();</script>")
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

            objBILLOutRequest.IllID = CInt(Request("ILLID"))
            strContent = objBILLOutRequest.IllreqXmlRecord()
            objBILLOutRequest.ResponderID = hdnResponderID.Value
            intSuccess = objBILLOutRequest.GetEmailInfor(Server.MapPath(""), strContent, strMailFrom, strMailTo, strContentOut)
            EncodeILLError(objBILLOutRequest.EncodeOk)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(5).Text, objBILLOutRequest.ErrorCode)

            objBILLOutRequest.SendRequest()
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(4).Text, objBILLOutRequest.ErrorMsg, ddlLabel.Items(5).Text, objBILLOutRequest.ErrorCode)

            ' Write log
            WriteLog(66, lblFormTitle.Text & " (RequestID:" & Request("ILLID") & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            ' Success
            If intSuccess = 0 Then
                intSendMail = SendMail("ILL", strContentOut, strMailTo, False, strMailFrom)
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(4).Text, ErrorMsg, ddlLabel.Items(5).Text, ErrorCode)
                If intSendMail = 1 Then
                    Page.RegisterClientScriptBlock("Success", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                Else
                    Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
                End If
            Else
                Page.RegisterClientScriptBlock("UnSuccess", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');opener.top.main.Workform.location.href='WORMan.aspx';self.close();</script>")
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

