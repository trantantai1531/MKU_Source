' Class: WCreateIssue
' Puspose: Create Issue of the selected periodical
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 01/10/2004 by Oanhtn: write processing methods

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WCreateIssue
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
        Private objBCDBS As New clsBCommonDBSystem
        Private objBItem As New clsBItem
        Private objBPeriodical As New clsBPeriodical

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call GetLastIssueInfor()
                Call BindData()
                If Not Request("IssueID") = "" Then
                    Call LoadIssueInfor()
                End If
                If Not Request("PubDate") = "" Then
                    txtIssuedDate.Text = ToCurrentDate(Trim(Request("PubDate")))
                End If
                If Request("Modify") = "1" Then
                    btnDelete.Visible = True
                End If
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permissions
        Private Sub CheckFormPermission()
            If Not CheckPemission(88) Then
                btnUpdate.Enabled = False
            End If
            If Not CheckPemission(194) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Request.QueryString("ItemID") & "" = "" Then
                If Not IsNumeric(Session("ItemID")) Then
                    Response.Redirect("../WSearch.aspx?URL=Acquisition/WCreateIssue.aspx")
                End If
            End If

            Dim lngItemID As Long

            If Not Request("ItemID") = "" Then
                lngItemID = CLng(Request("ItemID"))
                Session("ItemID") = lngItemID
                tblHeader.Visible = False
            Else
                lngItemID = Session("ItemID")
            End If

            ' Init objBPeriodical object
            objBIssue.InterfaceLanguage = Session("InterfaceLanguage")
            objBIssue.DBServer = Session("DBServer")
            objBIssue.ConnectionString = Session("ConnectionString")
            objBIssue.ItemID = lngItemID
            Call objBIssue.Initialize()

            ' Init objBPeriodical object
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.ItemID = lngItemID
            Call objBPeriodical.Initialize()

            ' Init for objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()

            ' Init for objBItem
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.Initialize()
        End Sub

        ' Method: BindJavascript
        ' Purpose: Include all javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WCreateIssue.js'></script>")

            If Request("ItemID") = "" Then
                lnkRegister.NavigateUrl = "WRegisterIssues.aspx"
            End If

            lnkNextIssue.NavigateUrl = "javascript:GetNextIssue();"
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkIssuedDate, txtIssuedDate, ddlLabel.Items(13).Text)

            Me.SetCheckNumber(txtCopies, ddlLabel.Items(14).Text, 1)
            Me.SetCheckNumber(txtPrice, ddlLabel.Items(14).Text, 0)

            btnDelete.Attributes.Add("OnClick", "javascript:if(!confirm('" & ddlLabel.Items(18).Text & "')) {return false;}")
            btnUpdate.Attributes.Add("OnClick", "if (CheckAll()==false) {alert('" & ddlLabel.Items(15).Text & "'); return false;} else {if (parseFloat(document.forms[0].txtCopies.value) <= 0) {alert('" & ddlLabel.Items(16).Text & "');document.forms[0].txtCopies.focus();document.forms[0].txtCopies.select();return false;} else { /*if ((parseFloat(document.forms[0].txtIssueNo.value)-parseFloat(document.forms[0].txtOvIssueNo.value))>0) {alert('" & ddlLabel.Items(17).Text & "'); return false;}*/}}")
            btnReset.Attributes.Add("OnClick", "return ResetAll();")

            lnkHdAcquire.NavigateUrl = "WAcquire.aspx"
            lnkHdSetRegularity.NavigateUrl = "WSetRegularity.aspx"
            lnkHdReceive.NavigateUrl = "WReceive.aspx"
            lnkHdView.NavigateUrl = "WViewInCalendarMode.aspx"
            lnkHdBinding.NavigateUrl = "WBinding.aspx"
            lnkHdSummary.NavigateUrl = "WSummaryHoldingManagement.aspx"
        End Sub

        ' LoadIssueInfor method
        ' Purpose: Load information of the current Issue for update or delete
        Private Sub LoadIssueInfor()
            Dim tblTemp As DataTable
            Dim str300 As String = ""

            If Request("IssueID") & "" <> "" Then
                hidIssueID.Value = Request("IssueID")
                objBIssue.IssueID = hidIssueID.Value
                tblTemp = objBIssue.GetIssueInfor

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

                ' Load
                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        lnkNextIssue.Visible = False
                        'txtIssueNo.ReadOnly = True
                        'txtOvIssueNo.ReadOnly = True
                        'txtIssuedDate.ReadOnly = True
                        'lnkIssuedDate.Visible = False

                        If Not IsDBNull(tblTemp.Rows(0).Item("IssueNo")) Then
                            txtIssueNo.Text = tblTemp.Rows(0).Item("IssueNo")
                        End If

                        If Not IsDBNull(tblTemp.Rows(0).Item("OvIssueNo")) Then
                            txtOvIssueNo.Text = tblTemp.Rows(0).Item("OvIssueNo")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("ISSUEDDATE")) Then
                            txtIssuedDate.Text = tblTemp.Rows(0).Item("ISSUEDDATE")
                        End If
                        'If Not IsDBNull(tblTemp.Rows(0).Item("PhysDetail")) Then
                        '    txtPhysDetail.Text = tblTemp.Rows(0).Item("PhysDetail")
                        'End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("FIELD300")) Then
                            str300 = tblTemp.Rows(0).Item("FIELD300")
                            txtPhysDetail.Text = str300.Trim
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Price")) Then
                            txtPrice.Text = CInt(tblTemp.Rows(0).Item("Price"))
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Note")) Then
                            txtNote.Text = tblTemp.Rows(0).Item("Note")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("Summary")) Then
                            txtSummary.Text = tblTemp.Rows(0).Item("Summary")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("VolumeByPublisher")) Then
                            txtVolumeByPublisher.Text = tblTemp.Rows(0).Item("VolumeByPublisher")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("SubscribedCopies")) Then
                            txtCopies.Text = tblTemp.Rows(0).Item("SubscribedCopies")
                        End If
                        If Not IsDBNull(tblTemp.Rows(0).Item("SpecialTitle")) Then
                            txtSpecialTitle.Text = tblTemp.Rows(0).Item("SpecialTitle")
                        End If
                        If tblTemp.Rows(0).Item("FirstIssueInYear") = "1" Then
                            chkFirstIssueInYear.Checked = True
                        End If
                        If tblTemp.Rows(0).Item("SpecialIssue") = "1" Then
                            chkSpecialIssue.Checked = True
                        End If
                    End If
                    ' Release tblTemp
                    tblTemp = Nothing
                End If
            End If
        End Sub

        ' BindData method
        ' Purpose: Get information of the current periodical
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim tblItem As DataTable
            Dim strTitle As String = ""
            Dim dvTitle As DataView
            Dim str300 As String = ""

            txtIssuedDate.Text = Session("ToDay")

            If Request.QueryString("ItemID") & "" <> "" AndAlso IsNumeric(Request.QueryString("ItemID") & "") Then
                objBItem.ItemID = CLng(Request.QueryString("ItemID"))
                tblItem = objBCDBS.ConvertTable(objBItem.GetItemInfor, "Content")
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBItem.ErrorMsg, ddlLabel.Items(0).Text, objBItem.ErrorCode)

                If Not tblItem Is Nothing AndAlso tblItem.Rows.Count > 0 Then
                    dvTitle = New DataView
                    dvTitle.Table = tblItem
                    dvTitle.RowFilter = "FieldCode = '245'"
                    If dvTitle.Count > 0 Then
                        strTitle = dvTitle.Item(0).Row("Content")
                    End If
                End If
            End If

            ' Set Title
            If strTitle <> "" Then
                lblTitle.Text = "<H3>" & strTitle & "</H3>"
                Session("Title") = strTitle
            Else
                lblTitle.Text = "<H3>" & Session("Title") & "</H3>"
            End If

            ' Get infor of the periodical
            tblTemp = objBPeriodical.GetPeriodicalInfor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    hidClaimCycle1.Value = Trim(tblTemp.Rows(0).Item("ClaimCycle1"))
                    hidClaimCycle2.Value = Trim(tblTemp.Rows(0).Item("ClaimCycle2"))
                    hidClaimCycle3.Value = Trim(tblTemp.Rows(0).Item("ClaimCycle3"))
                    If Not IsDBNull(tblTemp.Rows(0).Item("DeliveryTime")) Then
                        hidDeliveryTime.Value = Trim(tblTemp.Rows(0).Item("DeliveryTime"))
                    Else
                        hidDeliveryTime.Value = ""
                    End If
                    If Session("DBServer") = "ORACLE" Then
                        hidResetRegularity.Value = Trim(tblTemp.Rows(0).Item("RESETREGULARITY"))
                    Else
                        hidResetRegularity.Value = Trim(tblTemp.Rows(0).Item("ResetRegularity"))
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("FIELD300")) Then
                        str300 = tblTemp.Rows(0).Item("FIELD300")
                        txtPhysDetail.Text = str300.Trim
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("Content")) Then
                        lblTitle.Text = tblTemp.Rows(0).Item("Content")
                    End If
                    txtPrice.Text = CInt(tblTemp.Rows(0).Item("UnitPrice"))
                End If
                tblTemp = Nothing
            End If
        End Sub

        ' GetLastIssueInfor method
        ' Purpose: Get information of the last issue
        Private Sub GetLastIssueInfor()
            Dim strTemp As String = ""
            Dim tblTemp As DataTable
            Dim str300 As String = ""

            tblTemp = objBIssue.GetLastIssueInfor

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
                    If IsDBNull(tblTemp.Rows(0).Item("OvIssueNo")) Then
                        hidLastOvIssueNo.Value = 0
                    Else
                        hidLastOvIssueNo.Value = tblTemp.Rows(0).Item("OvIssueNo")
                    End If

                    If IsNumeric(tblTemp.Rows(0).Item("IssueNo")) Then
                        txtIssueNo.Text = CInt(tblTemp.Rows(0).Item("IssueNo"))
                    Else
                        If (IsDBNull(tblTemp.Rows(0).Item("IssueNo"))) Then
                            txtIssueNo.Text = "1"
                        Else
                            Try
                                txtIssueNo.Text = CInt(tblTemp.Rows(0).Item("IssueNo").ToString().Split("/")(0).ToString()) + 1
                            Catch ex As Exception
                                txtIssueNo.Text = "Parse Error"
                            End Try
                        End If
                    End If

                    If IsNumeric(tblTemp.Rows(0).Item("OvIssueNo")) Then
                        txtOvIssueNo.Text = CInt(tblTemp.Rows(0).Item("OvIssueNo")) + 1
                    Else
                        txtOvIssueNo.Text = "1"
                    End If

                    txtPrice.Text = CInt(tblTemp.Rows(0).Item("Price"))
                    If Not IsDBNull(tblTemp.Rows(0).Item("SUBSCRIBEDCOPIES")) Then
                        txtCopies.Text = tblTemp.Rows(0).Item("SUBSCRIBEDCOPIES")
                    End If
                    If Not IsDBNull(tblTemp.Rows(0).Item("FIELD300")) Then
                        str300 = tblTemp.Rows(0).Item("FIELD300")
                        txtPhysDetail.Text = str300.Trim
                    End If
                End If
            End If
        End Sub

        ' btnUpdate_Click event
        ' Purpose: Create (Update) issue record
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intResult As Integer = 0

            objBIssue.ResetRegularity = hidResetRegularity.Value
            'objBIssue.ResetRegularity = 1

            If Request("Modify") = "1" Then
                ' Update
                objBIssue.IssueID = hidIssueID.Value
                objBIssue.ClaimCycle1 = hidClaimCycle1.Value
                objBIssue.ClaimCycle2 = hidClaimCycle2.Value
                objBIssue.ClaimCycle3 = hidClaimCycle3.Value
                If chkSpecialIssue.Checked Then
                    objBIssue.SpecialIssue = 1
                Else
                    objBIssue.SpecialIssue = 0
                End If
                objBIssue.PhysDetail = txtPhysDetail.Text.Trim
                objBIssue.Price = txtPrice.Text.Trim
                objBIssue.Note = txtNote.Text.Trim
                objBIssue.IssuedDate = txtIssuedDate.Text.Trim
                objBIssue.IssueNo = txtIssueNo.Text.Trim
                objBIssue.OvIssueNo = txtOvIssueNo.Text.Trim
                objBIssue.VolumeByPublisher = txtVolumeByPublisher.Text.Trim
                objBIssue.SpecialTitle = txtSpecialTitle.Text.Trim
                objBIssue.Summary = txtSummary.Text.Trim
                objBIssue.SubscribedCopies = CInt(txtCopies.Text.Trim)
                If chkFirstIssueInYear.Checked Then
                    objBIssue.FirstIssueInYear = 1
                Else
                    objBIssue.FirstIssueInYear = 0
                End If
                intResult = objBIssue.Update

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(2).Text & " " & Trim(lblTitle.Text.Replace("<H3>", "").Replace("</H3>", "")), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intResult = 0 Then ' Success
                    Call GetLastIssueInfor()
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")
                ElseIf intResult = 2 Then  ' Fail
                    Page.RegisterClientScriptBlock("ExistIssueNoJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                End If
            Else
                ' Create
                objBIssue.ClaimCycle1 = hidClaimCycle1.Value
                objBIssue.ClaimCycle2 = hidClaimCycle2.Value
                objBIssue.ClaimCycle3 = hidClaimCycle3.Value
                If chkSpecialIssue.Checked Then
                    objBIssue.SpecialIssue = 1
                Else
                    objBIssue.SpecialIssue = 0
                End If
                objBIssue.PhysDetail = txtPhysDetail.Text.Trim
                objBIssue.Price = txtPrice.Text.Trim
                objBIssue.Note = txtNote.Text.Trim
                objBIssue.IssuedDate = txtIssuedDate.Text.Trim
                objBIssue.IssueNo = txtIssueNo.Text.Trim
                objBIssue.OvIssueNo = txtOvIssueNo.Text.Trim
                objBIssue.VolumeByPublisher = txtVolumeByPublisher.Text.Trim
                objBIssue.SpecialTitle = txtSpecialTitle.Text.Trim
                objBIssue.Summary = txtSummary.Text.Trim
                objBIssue.SubscribedCopies = CInt(txtCopies.Text.Trim)
                If chkFirstIssueInYear.Checked Then
                    objBIssue.FirstIssueInYear = 1
                Else
                    objBIssue.FirstIssueInYear = 0
                End If

                intResult = objBIssue.Add

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(2).Text & " " & Trim(lblTitle.Text.Replace("<H3>", "").Replace("</H3>", "")), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intResult = 0 Then ' Success
                    Call GetLastIssueInfor()
                    Page.RegisterClientScriptBlock("SuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                ElseIf intResult = 2 Then  ' Exist IssueNo
                    Page.RegisterClientScriptBlock("ExistIssueNoJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(7).Text & "');</script>")
                ElseIf intResult = 1 Then  ' Fail
                    Page.RegisterClientScriptBlock("FailJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")
                ElseIf intResult = 4 Then  ' Exist OvIssueNo
                    Page.RegisterClientScriptBlock("ExistOvIssueNoJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(10).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("IssuedDateExistJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                End If
            End If
            Session("Issueinfor") = objBIssue.IssueID & "|" & txtIssuedDate.Text.Trim

        End Sub

        ' btnDelete_Click event
        ' Purpose: delete the current issue
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim intRetVal As Integer = 0

            If Request("Modify") = "1" Then
                objBIssue.IssueID = hidIssueID.Value
                intRetVal = objBIssue.Delete

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(3).Text & " " & Trim(lblTitle.Text.Replace("<H3>", "").Replace("</H3>", "")), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                If intRetVal = 0 Then ' Success
                    Page.RegisterClientScriptBlock("DeleteSuccessJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(11).Text & "');</script>")
                Else ' Fail
                    Page.RegisterClientScriptBlock("DeleteFailJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                End If

            End If
        End Sub

        Function ToCurrentDate(ByVal strInDate As String) As String
            Dim strRet As String
            Dim strTime As String
            Dim strDate As String
            Dim strTypeShow As String

            If strInDate = "NULL" Then
                strInDate = ""
            End If

            If Trim(strInDate) = "" Then
                ToCurrentDate = ""
                Exit Function
            Else
                Dim strInDay As String, strInMon As String, strInYear As String

                strInDay = Left(strInDate, InStr(strInDate, "/") - 1)
                strInDate = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                strInMon = Left(strInDate, InStr(strInDate, "/") - 1)
                strInYear = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))

                Select Case UCase(Session("DateFormat"))
                    Case "DD/MM/YYYY"
                        ToCurrentDate = strInDay.PadLeft(2, "0") & "/" & strInMon.PadLeft(2, "0") & "/" & strInYear
                    Case "MM/DD/YYYY"
                        ToCurrentDate = strInMon.PadLeft(2, "0") & "/" & strInDay.PadLeft(2, "0") & "/" & strInYear
                    Case "YYYY/DD/MM"
                        ToCurrentDate = strInYear & "/" & strInDay.PadLeft(2, "0") & "/" & strInMon.PadLeft(2, "0")
                    Case "YYYY/MM/DD"
                        ToCurrentDate = strInYear & "/" & strInMon.PadLeft(2, "0") & "/" & strInDay.PadLeft(2, "0")
                    Case Else
                        ToCurrentDate = strInDay.PadLeft(2, "0") & "/" & strInMon.PadLeft(2, "0") & "/" & strInYear
                End Select

            End If
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBIssue Is Nothing Then
                    objBIssue.Dispose(True)
                    objBIssue = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace