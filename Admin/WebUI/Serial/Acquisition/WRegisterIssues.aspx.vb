' Class: WRegisterIssues
' Puspose: auto register issue
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 21/04/2005 by Oanhtn

Imports eMicLibAdmin.BusinessRules.Serial

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WRegisterIssues
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
        Private objBIssue As New clsBIssue

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call GetLastIssueInfor()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(88) Then
                btnRegister.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBPeriodical object
            objBIssue.InterfaceLanguage = Session("InterfaceLanguage")
            objBIssue.DBServer = Session("DBServer")
            objBIssue.ConnectionString = Session("ConnectionString")
            Call objBIssue.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: Include all javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WRegisterIssues.js'></script>")

            lnkCreateIssue.NavigateUrl = "WCreateIssue.aspx"
            lnkNextIssue.NavigateUrl = "javascript:GetNextIssue();"
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkStartDate, txtStartDate, ddlLabel.Items(7).Text)
            SetOnclickCalendar(lnkEndDate, txtEndDate, ddlLabel.Items(7).Text)

            SetCheckNumber(txtStartIssueNo, ddlLabel.Items(8).Text, 1)
            SetCheckNumber(txtStartOvIssueNo, ddlLabel.Items(8).Text, 0)
            SetCheckNumber(txtPrice, ddlLabel.Items(8).Text, 0)
            SetCheckNumber(txtCopies, ddlLabel.Items(8).Text, 1)

            btnRegister.Attributes.Add("OnClick", "return CheckAll('" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(10).Text & "','" & ddlLabel.Items(11).Text & "','" & Session("DateFormat") & "');")
            btnReset.Attributes.Add("OnClick", "return ResetAll();")

            lnkHdAcquire.NavigateUrl = "WAcquire.aspx"
            lnkHdSetRegularity.NavigateUrl = "WSetRegularity.aspx"
            lnkHdReceive.NavigateUrl = "WReceive.aspx"
            lnkHdView.NavigateUrl = "WViewInCalendarMode.aspx"
            lnkHdBinding.NavigateUrl = "WBinding.aspx"
            lnkHdSummary.NavigateUrl = "WSummaryHoldingManagement.aspx"
        End Sub

        ' GetLastIssueInfor method
        ' Purpose: Get information of the last issue
        Private Sub GetLastIssueInfor()
            Dim strTemp As String = ""
            Dim tblTemp As DataTable

            lblTitle.Text = "<H3>" & Session("Title") & "</H3>"

            objBIssue.ItemID = Session("ItemID")
            tblTemp = objBIssue.GetLastIssueInfor
            txtStartDate.Text = Session("ToDay")
            If Session("DateFormat") = "dd/mm/yyyy" Then
                txtEndDate.Text = "31/12/" & CStr(Year(Now))
            ElseIf Session("DateFormat") = "mm/dd/yyyy" Then
                txtEndDate.Text = "12/31/" & CStr(Year(Now))
            ElseIf Session("DateFormat") = "yyyy/dd/mm" Then
                txtEndDate.Text = CStr(Year(Now)) & "/31/12"
            ElseIf Session("DateFormat") = "yyyy/mm/dd" Then
                txtEndDate.Text = CStr(Year(Now)) & "/12/31"
            End If

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    strTemp = tblTemp.Rows(0).Item("IssueNo")
                    If Not IsDBNull(tblTemp.Rows(0).Item("OvIssueNo")) Then
                        strTemp = strTemp & " (" & tblTemp.Rows(0).Item("OvIssueNo") & ")"
                    End If
                    strTemp = strTemp & " -- " & tblTemp.Rows(0).Item("ISSUEDDATE") & " -- "
                    lblLastIssue.Text = strTemp
                    hidLastIssueNo.Value = tblTemp.Rows(0).Item("IssueNo")
                    If Not IsDBNull(tblTemp.Rows(0).Item("OvIssueNo")) Then
                        hidLastOvIssueNo.Value = tblTemp.Rows(0).Item("OvIssueNo")
                    Else
                        hidLastOvIssueNo.Value = 0
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Price")) Then
                        txtPrice.Text = CInt(tblTemp.Rows(0).Item("Price"))
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("VolumeByPublisher")) Then
                        txtVolumeByPublisher.Text = tblTemp.Rows(0).Item("VolumeByPublisher")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("SubscribedCopies")) Then
                        txtCopies.Text = tblTemp.Rows(0).Item("SubscribedCopies")
                    End If
                End If
            End If
        End Sub

        ' btnRegister_Click event
        ' Purpose: Auto register some issues depending on user's conditionals
        Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
            Dim intOutValue As Integer = 0
            Dim intStartIssueNo As Integer = 1
            Dim intStartOvIssueNo As Integer = 0
            If txtStartIssueNo.Text.Trim <> "" Then
                intStartIssueNo = CInt(txtStartIssueNo.Text.Trim)
            End If
            If txtStartOvIssueNo.Text.Trim <> "" Then
                intStartOvIssueNo = CInt(txtStartOvIssueNo.Text.Trim)
            End If

            Dim strStartDate As String = txtStartDate.Text.Trim
            Dim strEndDate As String = txtEndDate.Text.Trim
            objBIssue.Price = txtPrice.Text.Trim
            objBIssue.VolumeByPublisher = txtVolumeByPublisher.Text.Trim
            objBIssue.SubscribedCopies = CInt(txtCopies.Text.Trim)
            objBIssue.ItemID = Session("ItemID")
            intOutValue = objBIssue.Register(intStartIssueNo, intStartOvIssueNo, strStartDate, strEndDate)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If intOutValue = 0 Then
                lblResult.Visible = False
                lblCount.Visible = False
                lblCount.Text = 0
                Page.RegisterClientScriptBlock("RegFailJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            Else
                lblResult.Visible = True
                lblCount.Visible = True
                lblCount.Text = intOutValue
                Page.RegisterClientScriptBlock("RegSuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                Call GetLastIssueInfor()
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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