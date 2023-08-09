' Class: WShowIssueInfor
' Puspose: Show infor of the selected issue
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history: 
'   - 20/04/2005 by Tuanhv: View code & Update

Imports eMicLibAdmin.BusinessRules.Serial

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WShowIssueInfor
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
        Private objBPeriodical As New clsBPeriodical
        Private intItemID As Long = 0
        Private intYear As Integer = 0
        Private intMonth As Integer = 0
        Private strTitle As String = ""

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Me.ShowWaitingOnPage(ddlLabel.Items(5).Text, "../..")
            Call BindJs()
            If Not Page.IsPostBack Then
                Call ShowControl(False)
                Call BindMonth()
                Call BindDataYear()
                If lblYear.Visible Then
                    Call BindData()
                Else
                    Page.RegisterClientScriptBlock("Nodata1", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                End If
            Else
                Call BindData()
            End If
            ShowWaitingOnPage("", "", True)
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Not IsNumeric(Session("ItemID")) Then
                Response.Redirect("../WSearch.aspx?URL=Article/WShowIssueInfor.aspx")
            End If

            ' Init objBPeriodical object
            objBPeriodical.InterfaceLanguage = Session("InterfaceLanguage")
            objBPeriodical.DBServer = Session("DBServer")
            objBPeriodical.ConnectionString = Session("ConnectionString")
            Call objBPeriodical.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(195) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' Method: BindJS
        ' Purpose: include all necessary javascript function
        Private Sub BindJs()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Article/WShowIssueInfor.js'></script>")
        End Sub

        ' Method: BindDataYear
        ' Purpose: Bind year into ddlyear
        Sub BindDataYear()
            Dim tblTempYear As New DataTable

            Try
                intItemID = Session("ItemID")
                objBPeriodical.ItemID = intItemID
                objBPeriodical.LocationID = 0
                tblTempYear = objBPeriodical.GetReceivedYear

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

                If Not tblTempYear Is Nothing Then
                    If tblTempYear.Rows.Count > 0 Then
                        Call ShowControl(True)
                        ddlYear.DataTextField = "Years"
                        ddlYear.DataValueField = "Years"
                        ddlYear.DataSource = tblTempYear
                        ddlYear.DataBind()
                        If tblTempYear.Rows.Count > 0 Then
                            intYear = CInt(ddlYear.SelectedValue)
                            hidYears.Value = intYear
                        Else
                            intYear = Year(Now)
                            hidYears.Value = intYear
                        End If
                    End If
                End If
                tblTempYear = Nothing
            Finally
            End Try
        End Sub
        Sub BindMonth()
            ddlMonth.SelectedValue = Month(Session("ToDay"))
            intMonth = CInt(ddlMonth.SelectedValue)
        End Sub
        ' Method: ShowControl
        Sub ShowControl(ByVal bol As Boolean)
            lblYear.Visible = bol
            ddlYear.Visible = bol
            lblIssue.Visible = bol
            txtIssue.Visible = bol
        End Sub

        'Get all data need into table
        Sub BindData()
            Dim tblLocationItemPO As New DataTable
            Dim tblVolumeItemPO As New DataTable
            Dim tblGenarateItemPO As New DataTable
            Dim tblCopyNumber As New DataTable
            Dim intRowGenarateItemPO As Integer
            Dim introw As Integer
            Dim tblItem As DataTable
            Dim tblRow As TableRow
            Dim tblCell1 As TableCell
            Dim tblCell2 As TableCell

            'Create table
            tblRow = New TableRow

            lblTitle.Text = "<H3>" & Session("Title") & "</H3>"

            ' Get input for seach
            Try
                'tblResult.Visible = False
                objBPeriodical.Year = intYear
                objBPeriodical.Month = intMonth
                If Trim(txtIssue.Text) <> "" Then
                    objBPeriodical.IssueNo = Trim(txtIssue.Text)
                End If

                ' Get informations
                objBPeriodical.ItemID = Session("ItemID")
                Try
                    objBPeriodical.Year = CInt(ddlYear.SelectedValue)
                    objBPeriodical.Month = CInt(ddlMonth.SelectedValue)
                Catch ex As Exception
                    Page.RegisterClientScriptBlock("Nodata2", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                    Exit Sub
                End Try

                objBPeriodical.IssueNo = Trim(txtIssue.Text)
                tblGenarateItemPO = objBPeriodical.GetGenaralInfor

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

                intRowGenarateItemPO = 0
                intRowGenarateItemPO = tblGenarateItemPO.Rows.Count
                If intRowGenarateItemPO = 0 Then
                    Page.RegisterClientScriptBlock("Nodata", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                Else
                    tblResult.Visible = True
                    For introw = 0 To intRowGenarateItemPO - 1
                        'Get Link
                        tblRow = New TableRow
                        tblCell1 = New TableCell
                        tblCell1.HorizontalAlign = HorizontalAlign.Left
                        tblCell1.CssClass = "lbLabel"
                        tblCell1.Width = Unit.Percentage(10%)
                        tblCell1.VerticalAlign = VerticalAlign.Top

                        tblCell2 = New TableCell
                        tblCell2.HorizontalAlign = HorizontalAlign.Left
                        tblCell2.CssClass = "lbLabel"
                        Dim strIssueInfor As String = ""
                        Dim strShowItem As String

                        'Get IssueNo
                        If Not IsDBNull(tblGenarateItemPO.Rows(introw).Item("IssueNo")) Then
                            If Trim(CStr(tblGenarateItemPO.Rows(introw).Item("IssueNo"))) <> "" Then
                                strShowItem = "<b><font color= red>" & lblIssueTitle.Text & "</font></b>" & CStr(tblGenarateItemPO.Rows(introw).Item("IssueNo"))
                                strIssueInfor = lblIssueTitle.Text & CStr(tblGenarateItemPO.Rows(introw).Item("IssueNo"))
                            End If
                        End If

                        'get OvIssueNo
                        If Not IsDBNull(tblGenarateItemPO.Rows(introw).Item("OvIssueNo")) Then
                            If Trim(CStr(tblGenarateItemPO.Rows(introw).Item("OvIssueNo"))) <> "" Then
                                strShowItem = strShowItem & "(<b>" & CStr(tblGenarateItemPO.Rows(introw).Item("OvIssueNo")) & "</b>)."
                                strIssueInfor = strIssueInfor & "(" & CStr(tblGenarateItemPO.Rows(introw).Item("OvIssueNo")) & ")"
                            End If
                        End If

                        'Get ISSUEDDATE
                        If Not IsDBNull(tblGenarateItemPO.Rows(introw).Item("ISSUEDDATE")) Then
                            If Trim(CStr(lblIssueDate.Text & tblGenarateItemPO.Rows(introw).Item("ISSUEDDATE"))) <> "" Then
                                strShowItem = strShowItem & lblIssueDate.Text & Trim(CStr(tblGenarateItemPO.Rows(introw).Item("ISSUEDDATE")))
                                'strIssueInfor = strIssueInfor & ".&nbsp;&nbsp;&nbsp;" & lblIssueDate.Text & Trim(CStr(tblGenarateItemPO.Rows(introw).Item("ISSUEDDATE")))
                                strIssueInfor = strIssueInfor & lblIssueDate.Text & Trim(CStr(tblGenarateItemPO.Rows(introw).Item("ISSUEDDATE")))
                                Dim lnkLink As New HyperLink
                                'lnkLink.NavigateUrl = "WManagementArticle.aspx?IssueID=" & Trim(CStr(tblGenarateItemPO.Rows(introw).Item("ID"))) & "&IssueInfor=" & strIssueInfor
                                lnkLink.NavigateUrl = "javascript:OpenWindow('WManagementArticle.aspx?IssueID=" & Trim(CStr(tblGenarateItemPO.Rows(introw).Item("ID"))) & "&IssueInfor=" & strIssueInfor & "','WManagementArticle',750,450,1,1)"
                                'lnkLink.NavigateUrl = "javascript:OpenWindow(WManagementArticle.aspx,'w,500,600,100,100')"
                                lnkLink.Text = "<img src='../../Images/Select.jpg' border=0>"
                                lnkLink.CssClass = "lbLinkFunction"
                                lnkLink.ToolTip = ddlLabel.Items(4).Text
                                tblCell1.Controls.Add(lnkLink)
                                tblRow.Cells.Add(tblCell1)
                            End If
                        End If

                        'Get PhysDetail
                        If Not IsDBNull(tblGenarateItemPO.Rows(introw).Item("PhysDetail")) Then
                            If Trim(CStr(tblGenarateItemPO.Rows(introw).Item("PhysDetail"))) <> "" Then
                                strShowItem = strShowItem & " ." & lblPhysDetail.Text & Trim(CStr(tblGenarateItemPO.Rows(introw).Item("PhysDetail")))
                            End If
                        End If

                        'Get Volume
                        If Not IsDBNull(tblGenarateItemPO.Rows(introw).Item("VolumeByPublisher")) Then
                            If Trim(CStr(tblGenarateItemPO.Rows(introw).Item("VolumeByPublisher"))) <> "" Then
                                strShowItem = strShowItem & " ." & lblVolumeP.Text & tblGenarateItemPO.Rows(introw).Item("VolumeByPublisher")
                            End If
                        End If

                        'Get SpecialTitle
                        If Not IsDBNull(tblGenarateItemPO.Rows(introw).Item("SpecialTitle")) Then
                            If Trim(CStr(tblGenarateItemPO.Rows(introw).Item("SpecialTitle"))) <> "" Then
                                strShowItem = strShowItem & " ." & lblSpecialTitle.Text & tblGenarateItemPO.Rows(introw).Item("SpecialTitle")
                            End If
                        End If

                        Dim intCountLocation As Integer = 0

                        'Get location
                        objBPeriodical.Issue = CInt(tblGenarateItemPO.Rows(introw).Item("ID"))
                        tblLocationItemPO = objBPeriodical.GetLocationInfor

                        ' Write error
                        Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

                        'Get count Copynumber
                        If Not IsDBNull(tblLocationItemPO) Then
                            intCountLocation = tblLocationItemPO.Rows.Count
                            Dim intRow1 As Integer
                            If intCountLocation > 0 Then
                                strShowItem = strShowItem & " <br>&nbsp;"
                                strShowItem = strShowItem & "<b><i><u>" & lblCopyNumberTitle.Text & "</u></i></b>" & "<br>&nbsp;"
                                For intRow1 = 0 To intCountLocation - 1
                                    'Get symbol
                                    If Not IsDBNull(tblLocationItemPO.Rows(intRow1).Item("Symbol")) Then
                                        If Trim(CStr(tblLocationItemPO.Rows(intRow1).Item("Symbol"))) <> "" Then
                                            strShowItem = strShowItem & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" & Trim(CStr(tblLocationItemPO.Rows(intRow1).Item("Symbol")))
                                        End If
                                    End If

                                    'Get code
                                    If Not IsDBNull(tblLocationItemPO.Rows(intRow1).Item("Code")) Then
                                        If Trim(CStr(tblLocationItemPO.Rows(intRow1).Item("Code"))) <> "" Then
                                            strShowItem = strShowItem & "-" & Trim(CStr(tblLocationItemPO.Rows(intRow1).Item("Code")))
                                        End If
                                    End If

                                    ' Get volume
                                    Dim intCountVolume As Integer = 0
                                    objBPeriodical.LocationID = tblLocationItemPO.Rows(intRow1).Item("LocationID")
                                    tblVolumeItemPO = objBPeriodical.GetVolumeInfor
                                    ' Write error
                                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

                                    If Not tblVolumeItemPO Is Nothing Then
                                        intCountVolume = tblVolumeItemPO.Rows.Count

                                        ' Get Total volume
                                        strShowItem = strShowItem & "(" & CStr(intCountVolume) & " " & lblVolumeL.Text & ")"
                                        Dim intRow2 As Integer
                                        If intCountVolume > 0 Then
                                            For intRow2 = 0 To intCountVolume - 1

                                                'Get Copynumber
                                                If Not IsDBNull(tblVolumeItemPO.Rows(intRow2).Item("CopynumberID")) Then
                                                    If Trim(CStr(tblVolumeItemPO.Rows(intRow2).Item("CopynumberID"))) <> "" Then
                                                        objBPeriodical.CopyNumberID = CInt(tblVolumeItemPO.Rows(intRow2).Item("CopynumberID"))
                                                    Else
                                                        objBPeriodical.CopyNumberID = 0
                                                    End If
                                                Else
                                                    objBPeriodical.CopyNumberID = 0
                                                End If
                                                tblCopyNumber = objBPeriodical.GetCopyNumber
                                                ' Write error
                                                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPeriodical.ErrorMsg, ddlLabel.Items(1).Text, objBPeriodical.ErrorCode)

                                                Dim intCountCopynumber As Integer = 0

                                                'Get total copynumber
                                                If Not tblCopyNumber Is Nothing Then
                                                    intCountCopynumber = tblCopyNumber.Rows.Count
                                                    Dim intRow3 As Integer
                                                    If intCountCopynumber > 0 Then
                                                        For intRow3 = 0 To intCountCopynumber - 1
                                                            If Not IsDBNull(tblCopyNumber.Rows(intRow3).Item("Copynumber")) Then
                                                                If Trim(CStr(tblCopyNumber.Rows(intRow3).Item("Copynumber"))) <> "" And Trim(CStr(tblCopyNumber.Rows(intRow3).Item("Copynumber"))) <> " " Then
                                                                    strShowItem = strShowItem & "<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                                                    strShowItem = strShowItem & tblCopyNumber.Rows(intRow3).Item("Copynumber")
                                                                End If
                                                            End If
                                                        Next
                                                    End If
                                                End If
                                            Next
                                        End If
                                    End If
                                Next
                            End If
                        End If

                        'Get Summary
                        If Not IsDBNull(tblGenarateItemPO.Rows(introw).Item("Summary")) Then
                            If Trim(CStr(tblGenarateItemPO.Rows(introw).Item("Summary"))) <> "" Then
                                strShowItem = strShowItem & "<br>&nbsp;<b><i>" & lbltt.Text & "</i></b><br>&nbsp;"
                                strShowItem = strShowItem & tblGenarateItemPO.Rows(introw).Item("Summary")
                            End If
                        End If
                        tblCell2.Controls.Add(New LiteralControl(strShowItem))
                        tblRow.Cells.Add(tblCell2)
                        tblResult.Rows.Add(tblRow)
                    Next
                End If
            Finally
            End Try
        End Sub

        ' Event: ddlYear_SelectedIndexChanged
        Private Sub ddlYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
            If lblYear.Visible Then
                'Call BindData()
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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