' Class: WShowClaimLetter
' Puspose: Show Claim Letter
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 2/10/2004 by Sondp: ShowClaimLetter

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common
Imports System.ValueType

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WShowClaimLetter
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btn As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBBClaimTemplate As New clsBClaimTemplate
        Private objBPeriodical As New clsBPeriodical
        Private objBCommonDBSystem As New clsBCommonDBSystem
        Private objMetric As clsBClaimTemplate.Metric
        Private objBIssue As New clsBIssue

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Not Request.QueryString("Destination") Is Nothing Then
                Call ViewLetter()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            'Init objBBClaimTemplate object
            objBBClaimTemplate.ConnectionString = Session("ConnectionString")
            objBBClaimTemplate.DBServer = Session("DBServer")
            objBBClaimTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBBClaimTemplate.Initialize()
            'Init objBPeriodical

            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.Initialize()

            'Init objBCommonDBSystem object
            objBCommonDBSystem.ConnectionString = Session("ConnectionString")
            objBCommonDBSystem.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonDBSystem.DBServer = Session("DBServer")
            objBCommonDBSystem.Initialize()

            'Init objBIssue object
            objBIssue.ConnectionString = Session("ConnectionString")
            objBIssue.InterfaceLanguage = Session("InterfaceLanguage")
            objBIssue.DBServer = Session("DBServer")
            objBIssue.Initialize()
        End Sub
        'purpose: Display ClaimLetter method
        Private Function ViewLetter() As String
            Call BindData()
            Dim arrItemID() As String

            arrItemID = Request.QueryString("IDs").Split(",")
            objBBClaimTemplate.IDs = Request.QueryString("IDs") 'string IDs
            objBBClaimTemplate.TemplateID = Request.QueryString("TemplateID") ' Claim Template ID
            objBBClaimTemplate.ClaimCycleMode = Request.QueryString("ClaimCycleMode")
            objBBClaimTemplate.IssueYear = Request.QueryString("IssueYear")
            objBBClaimTemplate.ItemID = CInt(Session("ItemID"))

            Dim intIndex As Integer
            Dim listEmal As String = ""
            If Not Session("ListEmail") Is Nothing Then
                listEmal = Session("ListEmail").ToString()
            End If
            objBBClaimTemplate.LibID = clsSession.GlbSite
            objMetric = objBBClaimTemplate.PreviewClaimUnReceivedIssues
            objMetric.arrStrEmailAddress = listEmal.Split(",")
            If Not objMetric.arrStrOutMsg Is Nothing Then
                Session("OutMsg") = Nothing ' Clear Session("OutMsg") before used
                Session("OutMsg") = objMetric.arrStrOutMsg
                Session("EmailAddress") = objMetric.arrStrEmailAddress
                For intIndex = 0 To UBound(objMetric.arrStrOutMsg)
                    Select Case UCase(Request.QueryString("Destination"))
                        Case "PREVIEW"
                            'lblOutMsg.Text = lblOutMsg.Text & objMetric.arrStrOutMsg(intIndex) & "<table width=100%><tr><td width=100% align=""center"" bgcolor=""#C0C0C0""><input class=""lbButton"" type=submit name=""btn" & intIndex & """ id=""btn" & intIndex & """ runat=""server"" value=""" & lblRepair.Text & """ OnClick=""javascript:document.forms[0].action='WEditClaimLetter.aspx?ID=" & intIndex & "&ClaimMode=" & Request.QueryString("ClaimCycleMode") & "';document.forms[0].method='post';document.forms[0].submit();"" cssClass=""lbLabel""></td></tr></table>"
                            'lblOutMsg.Text = lblOutMsg.Text & objMetric.arrStrOutMsg(intIndex) & "<table width=100%><tr><td width=100% align=""center"" bgcolor=""#C0C0C0""><input class=""lbButton"" type=submit name=""btn" & intIndex & """ id=""btn" & intIndex & """ runat=""server"" value=""" & lblRepair.Text & """ OnClick=""javascript:document.forms[0].action='WEditClaimLetter.aspx?ID=" & intIndex & "&ItemID=" & arrItemID(intIndex) & "&ClaimMode=" & Request.QueryString("ClaimCycleMode") & "';document.forms[0].method='post';document.forms[0].submit();"" cssClass=""lbLabel""></td></tr></table>"
                            lblOutMsg.Text = lblOutMsg.Text & objMetric.arrStrOutMsg(intIndex) & "<table width=100%><tr><td width=100% align=""center""><input class=""lbButton"" type=submit name=""btn" & intIndex & """ id=""btn" & intIndex & """ runat=""server"" value=""" & lblRepair.Text & """ OnClick=""javascript:document.forms[0].action='WEditClaimLetter.aspx?ID=" & intIndex & "&ItemID=" & arrItemID(intIndex) & "&ClaimMode=" & Request.QueryString("ClaimCycleMode") & "';document.forms[0].method='post';document.forms[0].submit();"" cssClass=""lbLabel""><input class=""lbButton"" type=submit name=""btnS" & intIndex & """ id=""btnS" & intIndex & """ runat=""server"" value=""" & ddlLabel.Items(6).Text & """ OnClick=""javascript:document.forms[0].action='WShowClaimLetter.aspx?Destination=EMAIL&IDs=" & arrItemID(intIndex) & "&TemplateID=" & Request.QueryString("TemplateID") & "&ClaimCycleMode=" & Request.QueryString("ClaimCycleMode") & "&IssueYear=" & Request.QueryString("IssueYear") & "';document.forms[0].method='post';document.forms[0].submit();"" cssClass=""lbLabel""></td></tr></table>"
                        Case "PRINT"
                            lblOutMsg.Text = lblOutMsg.Text & objMetric.arrStrOutMsg(intIndex)
                            Page.RegisterClientScriptBlock("PrintJs", "<script language='javascript'>self.focus();setTimeout('self.print()', 1);;</script>")

                            ' Update Claim date
                            Call objBIssue.UpdateClaimDate(Request.QueryString("IDs"), Request.QueryString("ClaimCycleMode"))

                            ' Write error
                            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)
                        Case "EMAIL"
                            Dim boolSendeMail As Boolean
                            boolSendeMail = SendEmail()
                            If boolSendeMail Then
                                ' Update Claim date
                                Call objBIssue.UpdateClaimDate(Request.QueryString("IDs"), Request.QueryString("ClaimCycleMode"))

                                ' Write error
                                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

                                Response.Write(lblSendEmailSussessfullAlert.Text)
                            Else
                                If objBBClaimTemplate.ErrorMsg <> "" Then
                                    Response.Write(lblSendEmailUnSussessfullAlert.Text & " At Error=" & objBBClaimTemplate.ErrorMsg)
                                Else
                                    Response.Write(lblSendEmailUnSussessfullAlert.Text & ". " & ddlLabel.Items(5).Text)
                                End If
                            End If
                    End Select
                Next
            End If
            If Request.QueryString("Msg") <> "" Then
                Response.Write(Request.QueryString("hdMsg"))
            End If
        End Function
        'BindData method
        Private Sub BindData()
            Dim inti As Integer
            For inti = 0 To ddlColumnTitle.Items.Count - 1
                objBBClaimTemplate.ColumnTitle.Add(ddlColumnTitle.Items(inti).Text, ddlColumnTitle.Items(inti).Value)
            Next
        End Sub

        ' Send Email method return true if successful or false if Unsuccessful
        Private Function SendEmail() As Boolean
            Dim intSendMail As Int16 = 0
            Dim strMailTo As String
            Dim strContentOut As String
            Dim intIndex As Integer = 0
            Dim intCount As Integer = 0

            For intIndex = 0 To UBound(objMetric.arrStrEmailAddress)
                If Not IsDBNull(objMetric.arrStrEmailAddress(intIndex)) Then
                    strMailTo = objMetric.arrStrEmailAddress(intIndex)
                    If strMailTo Is Nothing Or strMailTo = "" Then
                        'RegisterClientScriptBlock("AlertError", "<script language='JavaScript'>alert('" & ddlLabel.Items(5).Text & "')</script>")
                    Else
                        strContentOut = objMetric.arrStrOutMsg(intIndex)
                        intSendMail = SendMail(lblClaimEmailTitle.Text, strContentOut, strMailTo, True, "")
                        If intSendMail = 1 Then
                            intCount = intCount + 1
                        End If
                    End If
                End If
            Next

            If intCount > 0 Then 'send email successcul
                Return (True)
            Else
                Return (False) ' send email unsuccessful
            End If
        End Function
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBBClaimTemplate Is Nothing Then
                    objBBClaimTemplate.Dispose(True)
                    objBBClaimTemplate = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
                If Not objBCommonDBSystem Is Nothing Then
                    objBCommonDBSystem.Dispose(True)
                    objBCommonDBSystem = Nothing
                End If
                If Not objBIssue Is Nothing Then
                    objBIssue.Dispose(True)
                    objBIssue = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace