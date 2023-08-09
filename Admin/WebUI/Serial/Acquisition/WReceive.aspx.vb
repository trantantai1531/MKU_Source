' Class: WReceive
' Puspose: Receive some issue
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   - 21/04/2005 by Oanhtn: Review

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WReceive
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCDBS As New clsBCommonDBSystem
        Private objBCopy As New clsBCopy
        Private objBIssue As New clsBIssue
        Private objBPeriodical As New clsBPeriodical
        Private objBCommonBusiness As New clsBCommonBusiness
        Private objBItem As New clsBItem
        Dim strIssueNoInfo As String = ""
        Dim strIssueMonthInfo As String = ""
        Dim strIssueYearInfo As String = ""
        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Session("Issueinfor") & "" <> "" Then
                Dim strIssueDateInfo As String = ""
                strIssueNoInfo = CStr(Session("Issueinfor")).Split("|")(0)
                strIssueDateInfo = CStr(Session("Issueinfor")).Split("|")(1)
                If strIssueDateInfo <> "" Then
                    Dim strDeli As String = ""
                    If InStr(strIssueDateInfo, "/") <> 0 Then
                        strDeli = "/"
                    End If
                    If InStr(strIssueDateInfo, "-") <> 0 Then
                        strDeli = "-"
                    End If
                    If strDeli <> "" And strIssueDateInfo <> "" Then
                        Dim bytPos1 As Byte
                        Dim bytPos2 As Byte
                        bytPos1 = InStr(strIssueDateInfo, strDeli)
                        bytPos2 = InStrRev(strIssueDateInfo, strDeli)
                        ' convert to format mm/dd/yyyy
                        Select Case UCase(Session("DateFormat"))
                            Case "DD/MM/YYYY"
                                strIssueMonthInfo = Mid(strIssueDateInfo, bytPos1 + 1, bytPos2 - bytPos1 - 1)
                                strIssueYearInfo = Right(strIssueDateInfo, Len(strIssueDateInfo) - bytPos2)
                            Case "MM/DD/YYYY"
                                strIssueMonthInfo = Month(CDate(strIssueDateInfo))
                                strIssueYearInfo = Year(CDate(strIssueDateInfo))
                            Case "YYYY/DD/MM"
                                strIssueMonthInfo = Mid(strIssueDateInfo, bytPos1 + 1, bytPos2 - bytPos1 - 1)
                                strIssueYearInfo = Right(strIssueDateInfo, Len(strIssueDateInfo) - bytPos2)
                            Case "YYYY/MM/DD"
                                strIssueMonthInfo = Mid(strIssueDateInfo, bytPos1 + 1, bytPos2 - bytPos1 - 1)
                                strIssueYearInfo = Right(strIssueDateInfo, Len(strIssueDateInfo) - bytPos2)
                        End Select
                    End If
                End If
            End If
            ' Load the CeasedDate
            If Not Page.IsPostBack Then
                Call LoadCeasedDate()
            End If

            ' Bind javascript
            Call BindJavascript()

            If Not Page.IsPostBack Then
                Call BindData()
                If IsNumeric(ddlIssue.SelectedValue) Then
                    Call LoadReceivedCopies(ddlIssue.SelectedValue)
                End If
            End If
        End Sub
        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(90) Then
                Call WriteErrorMssg(ddlLabel.Items(13).Text)
            End If
        End Sub
        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            Dim lngItemID As Long

            If Not IsNumeric(Request("ItemID")) Then
                If Not IsNumeric(Session("ItemID")) Then
                    Response.Redirect("../WSearch.aspx?URL=Acquisition/WReceive.aspx")
                Else
                    ' Get ItemID
                    lngItemID = CLng(Session("ItemID"))
                End If
            Else
                ' Get ItemID
                lngItemID = CLng(Request("ItemID"))
                Session("ItemID") = lngItemID
                tblHeader.Visible = False
            End If

            dtgResult.Visible = False
            btnUnReceive.Visible = False

            ' Init for objBCDBS
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonBusiness.UserID = Session("UserID")
            objBCommonBusiness.ItemID = lngItemID
            Call objBCommonBusiness.Initialize()

            ' Init objBPeriodical object
            objBPeriodical.ConnectionString = Session("ConnectionString")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.ItemID = lngItemID
            Call objBPeriodical.Initialize()

            ' Init objBCopy object
            objBCopy.ConnectionString = Session("ConnectionString")
            objBCopy.DBServer = Session("DBServer")
            objBCopy.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCopy.Initialize()

            ' Init objBIssue object
            objBIssue.ConnectionString = Session("ConnectionString")
            objBIssue.DBServer = Session("DBServer")
            objBIssue.InterfaceLanguage = Session("InterfaceLanguage")
            objBIssue.ItemID = lngItemID
            Call objBIssue.Initialize()

            ' Init for objBItem
            objBItem.InterfaceLanguage = Session("InterfaceLanguage")
            objBItem.DBServer = Session("DBServer")
            objBItem.ConnectionString = Session("ConnectionString")
            objBItem.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: Include all javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WReceive.js'></script>")

            btnReceive.Attributes.Add("OnClick", "return CheckAllReceive('" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(11).Text & "','" & Session("DateFormat") & "','" & ddlLabel.Items(10).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(12).Text & "');")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkReceivedDate, txtReceivedDate, ddlLabel.Items(2).Text)
            lnkHdAcquire.NavigateUrl = "WAcquire.aspx"
            lnkHdSetRegularity.NavigateUrl = "WSetRegularity.aspx"
            lnkHdRegister.NavigateUrl = "WCreateIssue.aspx"
            lnkHdView.NavigateUrl = "WViewInCalendarMode.aspx"
            lnkHdBinding.NavigateUrl = "WBinding.aspx"
            lnkHdSummary.NavigateUrl = "WSummaryHoldingManagement.aspx"
            btnUnReceive.Attributes.Add("OnClick", "if(!CheckOptionsNull('dtgResult', 'chkID', 2, 1000, '" & ddlLabel.Items(8).Text & "')) return false; else return ConfirmDelete('" & ddlLabel.Items(9).Text & "');")
        End Sub

        ' LoadCeasedDate method
        Private Sub LoadCeasedDate()
            Dim tblTemp As DataTable

            tblTemp = objBPeriodical.GetPeriodicalInfor

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                If Not IsDBNull(tblTemp.Rows(0).Item("CEASEDDATE")) Then
                    hidCeasedDate.Value = tblTemp.Rows(0).Item("CEASEDDATE")
                End If
                ddlMonth.SelectedIndex = Now.Month - 1
                If Session("DBServer") = "ORACLE" Then
                    If Trim(tblTemp.Rows(0).Item("RESETREGULARITY")) <> 1 Then
                        lblMonth.Visible = False
                        ddlMonth.Visible = False
                    End If
                Else
                    If Trim(tblTemp.Rows(0).Item("ResetRegularity")) <> 1 Then
                        lblMonth.Visible = False
                        ddlMonth.Visible = False
                        ddlformboxMonth.Visible = False
                    End If
                End If
            End If
        End Sub

        ' LoadLocation method
        ' Purpose: Load form now
        Private Sub LoadLocation(ByVal intLocationID As Integer)
            Dim intCount As Integer
            Dim intYear As Integer
            Dim tblTemp As DataTable

            ' Get ReceivedYear
            ddlVolume.Items.Clear()
            ddlYear.Items.Clear()
            ddlIssue.Items.Clear()

            objBPeriodical.LocationID = intLocationID
            tblTemp = objBPeriodical.GetReceivedYear()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlYear.DataSource = tblTemp
                    ddlYear.DataTextField = "Years"
                    ddlYear.DataValueField = "Years"
                    ddlYear.DataBind()
                    '''''''''''''''''

                    '''''''''''''''
                    If Request("Year") = "" Then
                        intYear = CInt(tblTemp.Rows(0).Item("Years"))
                        If strIssueYearInfo <> "" Then
                            intYear = strIssueYearInfo
                        End If
                    Else
                        intYear = CInt(Request("Year"))
                    End If
                    For intCount = 0 To tblTemp.Rows.Count - 1
                        If intYear = CInt(tblTemp.Rows(intCount).Item("Years")) Then
                            ddlYear.SelectedIndex = intCount
                            Exit For
                        End If
                    Next
                    Call ChangeYear(intYear)
                End If
                tblTemp.Dispose()
            End If
        End Sub

        ' BindData method
        ' Purpose: Load form now
        Private Sub BindData()
            Dim intCount As Integer
            Dim intLocationID As Integer
            Dim tblItem As DataTable
            Dim tblTemp As DataTable
            Dim strTitle As String = ""
            Dim dvTitle As DataView

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

            If strTitle <> "" Then
                lblTitle.Text = "<H3>" & strTitle & "</H3>"
                Session("Title") = strTitle
            Else
                lblTitle.Text = "<H3>" & Session("Title") & "</H3>"
            End If

            txtReceivedDate.Text = Session("ToDay") & ""

            ' Get Locations
            tblTemp = objBCommonBusiness.GetRoutingLocations()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCommonBusiness.ErrorMsg, ddlLabel.Items(0).Text, objBCommonBusiness.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlLocation.DataSource = tblTemp
                    ddlLocation.DataTextField = "LOCNAME"
                    ddlLocation.DataValueField = "ID"
                    ddlLocation.DataBind()
                    If Request("LocationID") = "" Then
                        intLocationID = tblTemp.Rows(0).Item("ID")
                    Else
                        intLocationID = CInt(Request("LocationID"))
                        For intCount = 0 To tblTemp.Rows.Count - 1
                            If CInt(tblTemp.Rows(intCount).Item("ID")) = intLocationID Then
                                ddlLocation.SelectedIndex = intCount
                                Exit For
                            End If
                        Next
                    End If
                    tblTemp.Clear()

                    ' Get ReceivedYear
                    Call LoadLocation(intLocationID)
                End If
                tblTemp = Nothing
            End If
        End Sub

        ' btnReceive_Click event
        ' Purpose: receive copies now
        Private Sub btnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceive.Click
            Dim intRetVal As Integer = 0

            objBCopy.IssueID = ddlIssue.SelectedValue
            objBCopy.LocationID = ddlLocation.SelectedValue
            objBCopy.ReceivedDate = Trim(txtReceivedDate.Text)
            objBCopy.Note = Trim(txtNote.Text)
            objBCopy.ReceivedCopies = CInt(txtReceivedCopies.Text)
            intRetVal = objBCopy.Receive

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopy.ErrorMsg, ddlLabel.Items(0).Text, objBCopy.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(6).Text & " " & Trim(lblTitle.Text.Replace("<H3>", "").Replace("</H3>", "")), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If intRetVal > 0 Then
                Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WRegisterIssues.js'></script>")
            Else
                Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Acquisition/WRegisterIssues.js'></script>")
            End If
            Call LoadReceivedCopies(ddlIssue.SelectedValue)
        End Sub

        ' btnUnReceive_Click
        ' Purpose: Unreceived some received copies
        Private Sub btnUnReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnReceive.Click
            'Dim dtgItem As DataGridItem
            'Dim chkCopyID As CheckBox
            Dim strCopyIDs As String = ""
            Dim intCount As Integer = 0

            'For Each dtgItem In dtgResult.Items
            '    chkCopyID = dtgItem.FindControl("chkID")
            '    If chkCopyID.Checked Then
            '        strCopyIDs = strCopyIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
            '        intCount = intCount + 1
            '    End If
            'Next
            'dtgResult_ctl02_hidID

            For i As Integer = 2 To 1001
                Dim inti As String = i.ToString()
                If i < 10 Then
                    inti = "0" & i
                End If
                If (Request("dtgResult$ctl" & inti & "$chkID") = "on") Then
                    strCopyIDs = strCopyIDs & CType(Request("dtgResult$ctl" & inti & "$hidID"), Integer) & ","
                    intCount = intCount + 1
                End If
            Next


            If Not strCopyIDs = "" Then
                strCopyIDs = Left(strCopyIDs, Len(strCopyIDs) - 1)
                objBCopy.IssueID = ddlIssue.SelectedValue
                Call objBCopy.UnReceive(strCopyIDs, intCount)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopy.ErrorMsg, ddlLabel.Items(0).Text, objBCopy.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(7).Text & " " & Trim(lblTitle.Text.Replace("<H3>", "").Replace("</H3>", "")), Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Call LoadReceivedCopies(ddlIssue.SelectedValue)
            End If
        End Sub

        ' LoadReceivedCopies method
        ' Purpose: Load received copies of the selected issue
        Private Sub LoadReceivedCopies(ByVal lngIssueID As Long)
            Dim intRemainCopies As Integer
            Dim tblTemp As DataTable

            dtgResult.Visible = False
            btnUnReceive.Visible = False
            txtReceivedCopies.Text = 0
            objBIssue.IssueID = lngIssueID
            tblTemp = objBIssue.GetReceivedCopies(intRemainCopies, ddlLocation.SelectedValue)
            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBIssue.ErrorMsg, ddlLabel.Items(0).Text, objBIssue.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    dtgResult.Visible = True
                    btnUnReceive.Visible = True
                    dtgResult.DataSource = tblTemp
                    dtgResult.DataBind()
                    intRemainCopies = intRemainCopies - tblTemp.Rows.Count
                End If
            End If
            'so luong da dang ky
            'txtReceivedCopies.Text = tblTemp.Rows.Count
            txtReceivedCopies.Text = intRemainCopies
        End Sub
        Private Function strSub(ByVal msg As String) As String
            If msg = "" Or msg Is Nothing Then
                Return strSub = ""
            End If
            If InStr(msg, "-") > 0 Then
                strSub = Left(msg, InStr(msg, "-") - 1)
            Else
                strSub = msg
            End If
        End Function
        ' ChangeVolume method
        ' Purpose: Get copies of the selected volume
        Private Sub ChangeVolume(ByVal intYear As Integer, ByVal strVolume As String)
            Dim intCount As Integer
            Dim lngIssueID As Long
            Dim tblTemp As DataTable
            Dim intMonth As Integer = 0

            If Not strVolume = "" Then
                If ddlMonth.Visible Then
                    'If strIssueMonthInfo <> "" Then
                    '    ddlMonth.SelectedIndex = CInt(strIssueMonthInfo) - 1
                    'End If
                    intMonth = ddlMonth.SelectedValue
                End If
                tblTemp = objBPeriodical.GetReceivedIssues(intYear, strVolume, intMonth)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)


                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        ddlIssue.DataSource = tblTemp
                        ddlIssue.DataValueField = "ID"
                        ddlIssue.DataTextField = "IssueNo"
                        ddlIssue.DataBind()
                        If Request("IssueID") & "" = "" Then
                            If strIssueNoInfo <> "" Then
                                lngIssueID = strIssueNoInfo
                            Else
                                lngIssueID = tblTemp.Rows(tblTemp.Rows.Count - 1).Item("ID")
                            End If
                        Else
                            lngIssueID = CInt(Request("IssueID"))
                        End If
                        For intCount = 0 To tblTemp.Rows.Count - 1
                            If CInt(tblTemp.Rows(intCount).Item("ID")) = lngIssueID Then
                                ddlIssue.SelectedIndex = intCount
                                Exit For
                            End If
                        Next
                        Call LoadReceivedCopies(ddlIssue.SelectedValue)
                    Else
                        ddlIssue.DataSource = ""
                        ddlIssue.DataBind()
                    End If
                    tblTemp.Clear()
                Else
                    ddlIssue.DataSource = ""
                    ddlIssue.DataBind()
                End If
            End If
        End Sub

        ' ChangeYear method
        ' Purpose: Get copies of the selected volume
        Private Sub ChangeYear(ByVal intYear As Integer)
            Dim intCount As Integer
            Dim strVolume As String
            Dim tblTemp As DataTable

            If intYear > 0 Then
                If ddlMonth.Visible Then
                    tblTemp = objBPeriodical.GetReceivedVolume(intYear, ddlMonth.SelectedValue)
                Else
                    tblTemp = objBPeriodical.GetReceivedVolume(intYear)
                End If


                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        ddlVolume.DataSource = tblTemp
                        ddlVolume.DataValueField = "Volume"
                        ddlVolume.DataTextField = "Volume"
                        ddlVolume.DataBind()
                        If Request("Volume") = "" Then
                            strVolume = tblTemp.Rows(0).Item("Volume")
                        Else
                            strVolume = Request("Volume")
                            For intCount = 0 To tblTemp.Rows.Count - 1
                                If Trim(strVolume) = Trim(tblTemp.Rows(intCount).Item("Volume").ToString) Then
                                    ddlVolume.SelectedIndex = intCount
                                    Exit For
                                End If
                            Next
                        End If
                        Call ChangeVolume(intYear, strVolume)
                    End If
                End If
                tblTemp.Clear()
            End If
        End Sub
        ' ChangeYear method
        ' Purpose: Get copies of the selected volume
        Private Sub ChangeMonth(ByVal intMonth As Integer)
            Dim intCount As Integer
            Dim strVolume As String
            Dim tblTemp As DataTable

            If intMonth > 0 Then
                tblTemp = objBPeriodical.GetReceivedVolume(ddlYear.SelectedValue, intMonth)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodical.ErrorCode)

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        ddlVolume.DataSource = tblTemp
                        ddlVolume.DataValueField = "Volume"
                        ddlVolume.DataTextField = "Volume"
                        ddlVolume.DataBind()
                        If Request("Volume") = "" Then
                            strVolume = tblTemp.Rows(0).Item("Volume")
                        Else
                            strVolume = Request("Volume")
                            For intCount = 0 To tblTemp.Rows.Count - 1
                                If Trim(strVolume) = Trim(tblTemp.Rows(intCount).Item("Volume").ToString) Then
                                    ddlVolume.SelectedIndex = intCount
                                    Exit For
                                End If
                            Next
                        End If
                        Call ChangeVolume(ddlYear.SelectedValue, strVolume)
                    Else
                        ddlVolume.DataSource = ""
                        ddlVolume.DataBind()
                        ddlIssue.DataSource = ""
                        ddlIssue.DataBind()
                    End If
                Else
                    ddlVolume.DataSource = ""
                    ddlVolume.DataBind()
                    ddlIssue.DataSource = ""
                    ddlIssue.DataBind()
                End If
                tblTemp.Clear()
            End If
        End Sub
        ' ddlYear_SelectedIndexChanged event
        ' Purpose: Get volumes of the selected year
        Private Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
            Try
                Call ChangeYear(ddlYear.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

        ' ddlVolume_SelectedIndexChanged event
        ' Purpose: Get copies of the selected volume
        Private Sub ddlVolume_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlVolume.SelectedIndexChanged
            Try
                Call ChangeVolume(ddlYear.SelectedValue, ddlVolume.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

        ' ddlIssue_SelectedIndexChanged event
        ' Purpose: display received copies of the selected issue
        Private Sub ddlIssue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlIssue.SelectedIndexChanged
            Call LoadReceivedCopies(ddlIssue.SelectedValue)
        End Sub

        ' dtgResult_EditCommand event
        Public Sub dtgResult_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Try
                dtgResult.EditItemIndex = e.Item.ItemIndex

                ' Show data for editing
                Call LoadReceivedCopies(ddlIssue.SelectedValue)

                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).Attributes.Add("OnChange", "javascript:CheckDate(this, 'dd/mm/yyyy', '" & lblLabel1.Text & "');")
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).Width = Unit.Point(50)
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).CssClass = "lbTextBox"
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Width = Unit.Pixel(260)
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Rows = 2
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).CssClass = "lbTextBox"
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_CancelCommand event
        Public Sub dtgResult_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Try
                dtgResult.EditItemIndex = -1
                Call LoadReceivedCopies(ddlIssue.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_UpdateCommand event
        ' Purpose: update information of the selected copy record
        Public Sub dtgResult_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
            Try
                Dim intCopyID As Integer = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)

                ' Update now
                Dim strReceivedDate As String = CStr(CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).Text)
                Dim strNote As String = CStr(CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Text)

                objBCopy.CopyID = intCopyID
                objBCopy.ReceivedDate = Trim(strReceivedDate)
                objBCopy.Note = Trim(strNote)
                Call objBCopy.UpdateReceiveDate()
                dtgResult.EditItemIndex = -1
                Call LoadReceivedCopies(ddlIssue.SelectedValue)

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBCopy.ErrorMsg, ddlLabel.Items(0).Text, objBCopy.ErrorCode)

                ' Refresh interface
                Call LoadReceivedCopies(ddlIssue.SelectedValue)
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).Attributes.Add("OnChange", "javascript:CheckDate(this, 'dd/mm/yyyy', '" & lblLabel1.Text & "');")
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).Width = Unit.Point(50)
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(2).Controls(0), TextBox).CssClass = "lbTextBox"
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Width = Unit.Pixel(260)
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).TextMode = TextBoxMode.MultiLine
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).Rows = 2
                CType(dtgResult.Items(dtgResult.EditItemIndex).Cells(3).Controls(0), TextBox).CssClass = "lbTextBox"
            Catch ex As Exception
            End Try
        End Sub

        ' ddlLocation_SelectedIndexChanged event
        ' Purpose: Change location
        Private Sub ddlLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLocation.SelectedIndexChanged
            Try
                Call LoadReceivedCopies(ddlIssue.SelectedValue)
                'Call LoadLocation(ddlLocation.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

        ' dtgResult_ItemCreated event
        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim intIndex As Int16 = e.Item.ItemIndex + 2
                    Dim inti As Integer

                    For inti = 1 To e.Item.Cells.Count - 1
                        'e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dtgResult','chkID'," & e.Item.ItemIndex + 2 & ");")
                        Dim LiteralItem As Literal = CType(e.Item.Cells(inti).FindControl("LiteralCheckBox"), Literal)
                        If Not (IsNothing(LiteralItem)) Then
                            Dim indexInt As String = ""
                            If (e.Item.ItemIndex + 2 < 10) Then
                                indexInt = "0" & (e.Item.ItemIndex + 2).ToString()
                            Else
                                indexInt = (e.Item.ItemIndex + 2).ToString()
                            End If
                            Dim htmlStr As String = "<input id='dtgResult_ctl" & indexInt & "_chkID' type='checkbox' name='dtgResult$ctl" & indexInt & "$chkID'><label for='dtgResult_ctl" & indexInt & "_chkID'></label>"
                            LiteralItem.Text = htmlStr
                        End If
                    Next
            End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCopy Is Nothing Then
                    objBCopy.Dispose(True)
                    objBCopy = Nothing
                End If
                If Not objBPeriodical Is Nothing Then
                    objBPeriodical.Dispose(True)
                    objBPeriodical = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
                If Not objBIssue Is Nothing Then
                    objBIssue.Dispose(True)
                    objBIssue = Nothing
                End If
                If Not objBItem Is Nothing Then
                    objBItem.Dispose(True)
                    objBItem = Nothing
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

        Private Sub ddlMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
            Try
                Call ChangeMonth(ddlMonth.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace