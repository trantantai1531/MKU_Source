Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WSetRegularity
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ACQTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblMọnth As System.Web.UI.WebControls.Label
        Protected WithEvents lblWeek As System.Web.UI.WebControls.Label
        Protected WithEvents lblMonth As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCB As New clsBCommonBusiness
        Private objBPeriodical As New clsBPeriodical

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                lblSubTitle.Text = Session("Title")
                Call BindDropDownList()
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(193) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' BindDropDownList method
        ' Purpose: Get the regularity level
        Private Sub BindDropDownList()
            Dim tblRegularity As DataTable
            tblRegularity = objBCB.GetRegularity

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCB.ErrorMsg, ddlLabel.Items(0).Text, objBCB.ErrorCode)

            If Not tblRegularity Is Nothing Then
                If tblRegularity.Rows.Count > 0 Then
                    ddlRegularity.DataSource = tblRegularity
                    ddlRegularity.DataTextField = "Regularity"
                    ddlRegularity.DataValueField = "RegularityCode"
                    ddlRegularity.DataBind()
                End If
            End If
        End Sub

        ' BindScript method
        ' Purpose: Bind Java Script
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Acquisition/WSetRegularity.js'></script>")

            ' Add attributes for the controls
            cbxAllDay.Attributes.Add("OnClick", "javasript:AllDays(this.checked);")
            cbxAllMonth.Attributes.Add("OnClick", "javasript:AllMonths(this.checked);")
            cbxAllWeek.Attributes.Add("OnClick", "javasript:AllWeeks(this.checked);")
            rdoRegularity1.Attributes.Add("OnClick", "javasript:rdoRegularity1Click(this.checked);")
            rdoRegularity2.Attributes.Add("OnClick", "javasript:rdoRegularity2Click(this.checked);")
            rdoRegularity3.Attributes.Add("OnClick", "javasript:rdoRegularity3Click(this.checked);")
            rdoRegularity4.Attributes.Add("OnClick", "javasript:rdoRegularity4Click(this.checked);")
            btnUpdate.Attributes.Add("OnClick", "javascript:return CheckAllInPut('" & lblMsg1.Text & "','" & lblMsg2.Text & "');")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Not IsNumeric(Session("ItemID")) Then
                Response.Redirect("../WSearch.aspx?URL=Acquisition/WSetRegularity.aspx")
            End If

            ' Init for objBCB
            objBCB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCB.DBServer = Session("DBServer")
            objBCB.ConnectionString = Session("ConnectionString")
            Call objBCB.Initialize()

            ' Init for objBPeriodical
            objBPeriodical.InterfaceLanguage = Session("IxnterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            Call objBPeriodical.Initialize()
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblReg As DataTable
            Dim strDays As String = ""
            Dim strMonths As String = ""
            Dim strWeeks As String = ""
            Dim strFreqCode As String = ""
            Dim strFreqMode As String = ""
            Dim strResetRegularity As String = ""
            Dim intIndex As Integer = 0

            ' Get the regularity
            objBPeriodical.ItemID = Session("ItemID")
            tblReg = objBPeriodical.GetRegularityOfItem

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            If Not tblReg Is Nothing Then
                If tblReg.Rows.Count > 0 Then
                    If Not IsDBNull(tblReg.Rows(0).Item("Weeks")) Then
                        strWeeks = tblReg.Rows(0).Item("Weeks")
                    End If
                    If Not IsDBNull(tblReg.Rows(0).Item("Months")) Then
                        strMonths = tblReg.Rows(0).Item("Months")
                    End If
                    If Not IsDBNull(tblReg.Rows(0).Item("DOWs")) Then
                        strDays = tblReg.Rows(0).Item("DOWs")
                    End If
                    If Not IsDBNull(tblReg.Rows(0).Item("FreqCode")) Then
                        strFreqCode = tblReg.Rows(0).Item("FreqCode")
                    End If
                    If Not IsDBNull(tblReg.Rows(0).Item("FreqMode")) Then
                        strFreqMode = tblReg.Rows(0).Item("FreqMode")
                    End If
                    If Session("DBServer") = "ORACLE" Then
                        If Not IsDBNull(tblReg.Rows(0).Item("RESETREGULARITY")) Then
                            strResetRegularity = tblReg.Rows(0).Item("RESETREGULARITY")
                        End If
                    Else
                        If Not IsDBNull(tblReg.Rows(0).Item("ResetRegularity")) Then
                            strResetRegularity = tblReg.Rows(0).Item("ResetRegularity")
                        End If
                    End If

                    ' Get days
                    For intIndex = 1 To 7
                        Select Case intIndex
                            Case 1
                                If InStr(strDays, CStr(intIndex) & ",") > 0 Then
                                    chkSunday.Checked = True
                                Else
                                    chkSunday.Checked = False
                                End If
                            Case 2
                                If InStr(strDays, CStr(intIndex) & ",") > 0 Then
                                    chkMonday.Checked = True
                                Else
                                    chkMonday.Checked = False
                                End If
                            Case 3
                                If InStr(strDays, CStr(intIndex) & ",") > 0 Then
                                    chkTuesday.Checked = True
                                Else
                                    chkTuesday.Checked = False
                                End If
                            Case 4
                                If InStr(strDays, CStr(intIndex) & ",") > 0 Then
                                    chkWednesday.Checked = True
                                Else
                                    chkWednesday.Checked = False
                                End If
                            Case 5
                                If InStr(strDays, CStr(intIndex) & ",") > 0 Then
                                    chkThursday.Checked = True
                                Else
                                    chkThursday.Checked = False
                                End If
                            Case 6
                                If InStr(strDays, CStr(intIndex) & ",") > 0 Then
                                    chkFriday.Checked = True
                                Else
                                    chkFriday.Checked = False
                                End If
                            Case 7
                                If InStr(strDays, CStr(intIndex) & ",") > 0 Then
                                    chkSaturday.Checked = True
                                Else
                                    chkSaturday.Checked = False
                                End If
                        End Select
                    Next

                    ' Get weeks
                    For intIndex = 1 To 5
                        Select Case intIndex
                            Case 1
                                If InStr(strWeeks, CStr(intIndex) & ",") > 0 Then
                                    chkFirstWeek.Checked = True
                                Else
                                    chkFirstWeek.Checked = False
                                End If
                            Case 2
                                If InStr(strWeeks, CStr(intIndex) & ",") > 0 Then
                                    chkSecondWeek.Checked = True
                                Else
                                    chkSecondWeek.Checked = False
                                End If
                            Case 3
                                If InStr(strWeeks, CStr(intIndex) & ",") > 0 Then
                                    chkThirdWeek.Checked = True
                                Else
                                    chkThirdWeek.Checked = False
                                End If
                            Case 4
                                If InStr(strWeeks, CStr(intIndex) & ",") > 0 Then
                                    chkFourthWeek.Checked = True
                                Else
                                    chkFourthWeek.Checked = False
                                End If
                            Case 5
                                If InStr(strWeeks, CStr(intIndex) & ",") > 0 Then
                                    chkLastWeek.Checked = True
                                Else
                                    chkLastWeek.Checked = False
                                End If
                        End Select
                    Next

                    ' Get months
                    For intIndex = 1 To 12
                        Select Case intIndex
                            Case 1
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkJanuary.Checked = True
                                Else
                                    chkJanuary.Checked = False
                                End If
                            Case 2
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkFebruary.Checked = True
                                Else
                                    chkFebruary.Checked = False
                                End If
                            Case 3
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkMarch.Checked = True
                                Else
                                    chkMarch.Checked = False
                                End If
                            Case 4
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkApril.Checked = True
                                Else
                                    chkApril.Checked = False
                                End If
                            Case 5
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkMay.Checked = True
                                Else
                                    chkMay.Checked = False
                                End If
                            Case 6
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkJune.Checked = True
                                Else
                                    chkJune.Checked = False
                                End If
                            Case 7
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkJuly.Checked = True
                                Else
                                    chkJuly.Checked = False
                                End If
                            Case 8
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkAugust.Checked = True
                                Else
                                    chkAugust.Checked = False
                                End If
                            Case 9
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkSeptember.Checked = True
                                Else
                                    chkSeptember.Checked = False
                                End If
                            Case 10
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkOctober.Checked = True
                                Else
                                    chkOctober.Checked = False
                                End If
                            Case 11
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkNovember.Checked = True
                                Else
                                    chkNovember.Checked = False
                                End If
                            Case 12
                                If InStr(strMonths, CStr(intIndex) & ",") > 0 Then
                                    chkDecember.Checked = True
                                Else
                                    chkDecember.Checked = False
                                End If
                        End Select
                    Next

                    ' Get reg mode
                    For intIndex = 0 To 3
                        Select Case intIndex
                            Case 0
                                If Trim(strFreqMode) = "0" Or Trim(strFreqMode) = "" Then
                                    rdoRegularity1.Checked = True
                                Else
                                    rdoRegularity1.Checked = False
                                End If
                            Case 1
                                If Trim(strFreqMode) = "1" Then
                                    rdoRegularity2.Checked = True
                                Else
                                    rdoRegularity2.Checked = False
                                End If
                            Case 2
                                If Trim(strFreqMode) = "2" Then
                                    rdoRegularity3.Checked = True
                                Else
                                    rdoRegularity3.Checked = False
                                End If
                            Case 3
                                If Trim(strFreqMode) = "3" Then
                                    rdoRegularity4.Checked = True
                                Else
                                    rdoRegularity4.Checked = False
                                End If
                        End Select
                    Next

                    ' Get Freq Code
                    For intIndex = 0 To ddlRegularity.Items.Count - 1
                        If Trim(strFreqCode) = ddlRegularity.Items(intIndex).Value Then
                            ddlRegularity.SelectedIndex = intIndex
                        End If
                    Next

                    ' Get Reset mode
                    For intIndex = 0 To ddlResetRegularity.Items.Count - 1
                        If Trim(strResetRegularity) = ddlResetRegularity.Items(intIndex).Value Then
                            ddlResetRegularity.SelectedIndex = intIndex
                        End If
                    Next
                End If
            End If
        End Sub

        ' btnUpdate_Click
        ' Purpose: Update the regularity
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strDays As String = ""
            Dim strMonths As String = ""
            Dim strWeeks As String = ""
            Dim strFreqCode As String = ""
            Dim intFreqMode As Int16 = 0
            Dim intResetReg As Int16 = 0
            Dim lngItemID As Long = 0
            Dim intIndex As Integer = 0

            lngItemID = CLng(Session("ItemID"))

            ' Get Freq Mode
            If rdoRegularity1.Checked = True Then
                intFreqMode = 0
            End If

            If rdoRegularity2.Checked = True Then
                intFreqMode = 1
            End If

            If rdoRegularity3.Checked = True Then
                intFreqMode = 2
            End If

            If rdoRegularity4.Checked = True Then
                intFreqMode = 3
            End If

            ' Get FreqCode
            strFreqCode = ddlRegularity.SelectedValue

            ' Get Reset regularity mode
            intResetReg = CInt(ddlResetRegularity.SelectedValue)

            ' Get days
            strDays = ""
            For intIndex = 1 To 7
                Select Case intIndex
                    Case 1
                        If chkSunday.Checked = True Then
                            strDays = strDays & "1, "
                        End If
                    Case 2
                        If chkMonday.Checked = True Then
                            strDays = strDays & "2, "
                        End If
                    Case 3
                        If chkTuesday.Checked = True Then
                            strDays = strDays & "3, "
                        End If
                    Case 4
                        If chkWednesday.Checked = True Then
                            strDays = strDays & "4, "
                        End If
                    Case 5
                        If chkThursday.Checked = True Then
                            strDays = strDays & "5, "
                        End If
                    Case 6
                        If chkFriday.Checked = True Then
                            strDays = strDays & "6, "
                        End If
                    Case 7
                        If chkSaturday.Checked = True Then
                            strDays = strDays & "7, "
                        End If
                End Select
            Next

            strWeeks = ""
            ' Get weeks
            For intIndex = 1 To 5
                Select Case intIndex
                    Case 1
                        If chkFirstWeek.Checked = True Then
                            strWeeks = strWeeks & "1, "
                        End If
                    Case 2
                        If chkSecondWeek.Checked = True Then
                            strWeeks = strWeeks & "2, "
                        End If
                    Case 3
                        If chkThirdWeek.Checked = True Then
                            strWeeks = strWeeks & "3, "
                        End If
                    Case 4
                        If chkFourthWeek.Checked = True Then
                            strWeeks = strWeeks & "4, "
                        End If
                    Case 5
                        If chkLastWeek.Checked = True Then
                            strWeeks = strWeeks & "5, "
                        End If
                End Select
            Next

            strMonths = ""
            ' Get months
            For intIndex = 1 To 12
                Select Case intIndex
                    Case 1
                        If chkJanuary.Checked = True Then
                            strMonths = strMonths & "1, "
                        End If
                    Case 2
                        If chkFebruary.Checked = True Then
                            strMonths = strMonths & "2, "
                        End If
                    Case 3
                        If chkMarch.Checked = True Then
                            strMonths = strMonths & "3, "
                        End If
                    Case 4
                        If chkApril.Checked = True Then
                            strMonths = strMonths & "4, "
                        End If
                    Case 5
                        If chkMay.Checked = True Then
                            strMonths = strMonths & "5, "
                        End If
                    Case 6
                        If chkJune.Checked = True Then
                            strMonths = strMonths & "6, "
                        End If
                    Case 7
                        If chkJuly.Checked = True Then
                            strMonths = strMonths & "7, "
                        End If
                    Case 8
                        If chkAugust.Checked = True Then
                            strMonths = strMonths & "8, "
                        End If
                    Case 9
                        If chkSeptember.Checked = True Then
                            strMonths = strMonths & "9, "
                        End If
                    Case 10
                        If chkOctober.Checked = True Then
                            strMonths = strMonths & "10, "
                        End If
                    Case 11
                        If chkDecember.Checked = True Then
                            strMonths = strMonths & "11, "
                        End If
                    Case 12
                        If chkNovember.Checked = True Then
                            strMonths = strMonths & "12, "
                        End If
                End Select
            Next

            objBPeriodical.ItemID = lngItemID
            objBPeriodical.Days = strDays
            objBPeriodical.Months = strMonths
            objBPeriodical.Weeks = strWeeks
            objBPeriodical.FreqCode = strFreqCode
            objBPeriodical.FreqMode = intFreqMode
            objBPeriodical.ResetReg = intResetReg
            objBPeriodical.SetRegularity()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)
            Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            'Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCB Is Nothing Then
                    objBCB.Dispose(True)
                    objBCB = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace