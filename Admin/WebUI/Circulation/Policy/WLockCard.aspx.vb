' Class: WLockCard 
' Puspose: Locked card patron
' Creator: Tuanhv
' CreatedDate: 30/08/2004
' Modification History:

Imports eMicLibAdmin.BusinessRules.Circulation

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WLockCard
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtStartedDate As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNode As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtLockedDays As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblNodeText As System.Web.UI.WebControls.Label
        Protected WithEvents txtNodeText As System.Web.UI.WebControls.TextBox


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBPatron As New clsBPatron
        Private objBLoanTransaction As New clsBLoanTransaction

        Dim strStartDateFrom As String = ""
        Dim strStartDateTo As String = ""

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                txtStartedDateText.Text = Session("ToDay")
                txtEndDateText.Text = Session("ToDay")
                'txtLockedDaysText.Text = 1

                If Request("PatronCodeOnly") & "" <> "" Then
                    txtPatronCodeText.Text = Request("PatronCodeOnly")
                    btnDelete.Visible = False
                    lblPatronLockCodes.Visible = False
                    trShowFillter.Visible = False
                Else
                    Call ShowResult()
                End If
            Else
                '' format string datetime yyyy/mm/dd
                If txtStartDateFrom.Text <> "" Then
                    strStartDateFrom = txtStartDateFrom.Text
                    Dim DateFrom = DateTime.ParseExact(strStartDateFrom, "dd/MM/yyyy", Nothing)
                    strStartDateFrom = DateFrom.ToString("yyyy/MM/dd")
                End If
                If txtStartDateTo.Text <> "" Then
                    strStartDateTo = txtStartDateTo.Text
                    Dim DateTo = DateTime.ParseExact(strStartDateTo, "dd/MM/yyyy", Nothing)
                    strStartDateTo = DateTo.ToString("yyyy/MM/dd")
                End If
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(72) Then
                btnDelete.Enabled = False
                btnLocks.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Init objBLoanTransaction object
            objBLoanTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanTransaction.DBServer = Session("DBServer")
            objBLoanTransaction.ConnectionString = Session("ConnectionString")
            Call objBLoanTransaction.Initialize()

            ' Init objBPatron object
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatron.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Bind javascript
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WLockCard.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            txtStartedDateText.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtStartedDateText.ToolTip = Session("DateFormat")
            txtEndDateText.Attributes.Add("onChange", "javascript:CheckDate(this,'" & Session("DateFormat") & "','" & ddlLabel.Items(4).Text & " (" & Session("DateFormat") & ")');")
            txtEndDateText.ToolTip = Session("DateFormat")
            txtLockedDaysText.Attributes.Add("OnChange", "if (!CheckNumBer(this, '" & ddlLabel.Items(5).Text & "',1)) {this.value='1'; this.focus(); return false;}")
            btnLocks.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtPatronCodeText)) {alert('" & ddlLabel.Items(7).Text.Trim & "'); document.forms[0].txtPatronCodeText.focus(); return false;} if (CheckNull(document.forms[0].txtStartedDateText)) {alert('" & ddlLabel.Items(7).Text.Trim & "'); document.forms[0].txtStartedDateText.focus(); return false;} if (CheckNull(document.forms[0].txtLockedDaysText)) {alert('" & ddlLabel.Items(7).Text.Trim & "'); document.forms[0].txtLockedDaysText.focus(); return false;}")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkStartDate, txtStartedDateText, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkEndDate, txtEndDateText, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkStartDateFrom, txtStartDateFrom, ddlLabel.Items(4).Text)
            SetOnclickCalendar(lnkStartDateTo, txtStartDateTo, ddlLabel.Items(4).Text)

            txtPatronCodeF.Attributes.Add("onkeypress", "EventKeyPress();")
            txtPatronCodeF.Attributes.Add("onChange", "EventOnChange();")

            txtNoteText.Attributes.Add("OnChange", "if (this.value.length > 200) {alert('" & ddlLabel.Items(13).Text & "'); this.focus();return false;}")
        End Sub

        ' Event: dtgPolicy_PageIndexChanged
        Private Sub dtgPolicy_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgdPantronLocks.PageIndexChanged
            Call BindData(e.NewPageIndex)
        End Sub

        ' Method: BindData
        Private Sub BindData(Optional ByVal intPage As Integer = 0)
            Dim tblLockPatron As New DataTable
            Dim blnFound As Boolean = False
            Dim strPatronCodeF As String
            strPatronCodeF = hidPatronCodeCheck.Value

            tblLockPatron = objBPatron.GetLockedPatrons(strPatronCodeF, strStartDateTo.Trim(), strStartDateFrom.Trim(), clsSession.GlbSite)
            If Not tblLockPatron Is Nothing AndAlso tblLockPatron.Rows.Count > 0 Then
                dgdPantronLocks.DataSource = tblLockPatron
                dgdPantronLocks.CurrentPageIndex = intPage
                dgdPantronLocks.DataBind()
                blnFound = True
                dgdPantronLocks.Visible = True
                btnDelete.Visible = True
                tblLockPatron = Nothing
            End If
            If Not blnFound Then
                dgdPantronLocks.Visible = False
                btnDelete.Visible = False
            End If
        End Sub

        ' Event: dgdPantronLocks_EditCommand
        Private Sub dgdPantronLocks_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdPantronLocks.EditCommand
            Dim intIndex As Integer = CInt(e.Item.ItemIndex)
            dgdPantronLocks.EditItemIndex = intIndex
            Call BindData(dgdPantronLocks.CurrentPageIndex)
        End Sub

        ' Event: dgdPantronLocks_ItemCommand
        'Private Sub dgdPantronLocks_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdPantronLocks.ItemCommand
        '    Dim strJS As String
        '    Dim strCmd As String = ""
        '    Dim objLabel As New Label
        '    Dim strMark As String = ""
        '    strCmd = UCase(e.CommandName)

        '    'dgdPantronLocks.Columns(4).Visible = Not dgdPantronLocks.Columns(4).Visible
        '    'dgdPantronLocks.Columns(3).Visible = Not dgdPantronLocks.Columns(3).Visible            
        'End Sub

        ' Event: dgdPantronLocks_UpdateCommand
        Private Sub dgdPantronLocks_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdPantronLocks.UpdateCommand
            Dim strPatronCode As String
            Dim intLockedDays As Integer
            Dim strStartedDate As String
            Dim strNode As String

            Try
                'dgdPantronLocks.Columns(4).Visible = False
                dgdPantronLocks.Columns(3).Visible = True
                strPatronCode = CType(e.Item.Cells(1).FindControl("lblPatronCode"), Label).Text
                intLockedDays = CInt(CType(e.Item.Cells(4).FindControl("txtLockDay"), TextBox).Text)
                'lenta remove
                strStartedDate = CType(e.Item.Cells(2).FindControl("lblStartedDate"), Label).Text
                strNode = CType(e.Item.Cells(5).FindControl("txtNote"), TextBox).Text
                objBPatron.PatronCode = strPatronCode
                objBPatron.LockedDays = intLockedDays
                objBPatron.StartedDate = strStartedDate
                objBPatron.Note = strNode
                objBPatron.LockPatronCard()
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Alert message
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & lblMsg4.Text & "');</script>")

            Catch ex As Exception
                Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
            End Try
            ' Reload form
            'Call ShowResult()

            dgdPantronLocks.EditItemIndex = -1
            Call BindData(dgdPantronLocks.CurrentPageIndex)
        End Sub

        ' Event: dgdPantronLocks_CancelCommand
        Private Sub dgdPantronLocks_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgdPantronLocks.CancelCommand
            dgdPantronLocks.EditItemIndex = -1
            Call BindData(dgdPantronLocks.CurrentPageIndex)
        End Sub

        ' Method: ShowResult
        Sub ShowResult()
            If Request("PatronCodeOnly") & "" <> "" Then
                Exit Sub
            End If
            Dim tblPatronLock As DataTable
            Dim blnFound As Boolean = False
            Dim strPatronCodeF As String
            strPatronCodeF = hidPatronCodeCheck.Value

            tblPatronLock = objBPatron.GetLockedPatrons(strPatronCodeF, strStartDateTo.Trim(), strStartDateFrom.Trim(), clsSession.GlbSite)

            If Not tblPatronLock Is Nothing AndAlso tblPatronLock.Rows.Count > 0 Then
                dgdPantronLocks.Visible = True
                dgdPantronLocks.DataSource = tblPatronLock
                dgdPantronLocks.DataBind()
                blnFound = True
                btnDelete.Visible = True
                tblPatronLock = Nothing
            End If
            If Not blnFound Then
                dgdPantronLocks.Visible = False
                btnDelete.Visible = False
            End If
        End Sub

        ' Event: btnLocks_Click
        Private Sub btnLocks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocks.Click
            Dim intStatus As Int16
            Dim strPatronCode As String = Request("PatronCode") & ""
            Dim intUserID As Integer = CInt(Session("UserID"))
            Dim intLoanMode As Int16 = 1
            If Not Request("LoanMode") = "" Then
                intLoanMode = CInt(Request("LoanMode"))
            End If
            If strPatronCode = "" Then
                strPatronCode = txtPatronCodeText.Text.Trim
            End If
            objBLoanTransaction.PatronCode = strPatronCode
            objBLoanTransaction.UserID = intUserID
            intStatus = objBLoanTransaction.CheckPatronCode(intLoanMode)
            Select Case intStatus
                Case 1
                    Page.RegisterClientScriptBlock("NotExistPatronCodeJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(11).Text & "');if (eval(parent.Workform.document.forms[0].txtPatronCodeText)) {parent.Workform.document.forms[0].txtPatronCodeText.value = '';parent.Workform.document.forms[0].txtPatronCodeText.focus();}</script>")
                    Exit Sub
                Case 4
                    Page.RegisterClientScriptBlock("LockedPatronCodeJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(12).Text & "');if (eval(parent.Workform.document.forms[0].txtPatronCodeText)) {parent.Workform.document.forms[0].txtPatronCodeText.value = '';parent.Workform.document.forms[0].txtPatronCodeText.focus();}</script>")
                    Exit Sub
            End Select


            objBPatron.PatronCode = strPatronCode
            Dim intResult As Integer = objBPatron.UnLockPatronCard(0)
            Select Case intResult
                Case 0
                    Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & String.Format(lblMsg5.Text, strPatronCode) & "');</script>")
                    Exit Sub
            End Select

            Try

                Dim tblLockPatron As New DataTable
                Dim blnFound As Boolean = False
                Dim i As Integer
                objBPatron.PatronCode = strPatronCode
                tblLockPatron = objBPatron.GetLockedPatrons(strPatronCode)
                If Not tblLockPatron Is Nothing AndAlso tblLockPatron.Rows.Count > 0 Then
                    If Request("PatronCodeOnly") & "" <> "" Then
                        Page.RegisterClientScriptBlock("AlertJSJ", "<script language = 'javascript'>alert('" & ddlLabel.Items(9).Text.Trim & "');self.close();</script>")
                    Else
                        Page.RegisterClientScriptBlock("AlertJSJ", "<script language = 'javascript'>alert('" & ddlLabel.Items(9).Text.Trim & "');</script>")
                    End If
                    Exit Sub
                End If
                objBPatron.PatronCode = txtPatronCodeText.Text.Trim
                objBPatron.StartedDate = txtStartedDateText.Text.Trim
                'objBPatron.LockedDays = CInt(txtLockedDaysText.Text.Trim)
                objBPatron.LockedDays = DateDiff(DateInterval.Day, CDate(txtStartedDateText.Text.Trim), CDate(txtEndDateText.Text.Trim))
                objBPatron.Note = txtNoteText.Text.Trim
                objBPatron.LockPatronCard(0)
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(2).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call ShowResult()


                ' Alert message
                If Request("PatronCodeOnly") & "" <> "" Then
                    Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text.Trim & " " & ddlLabel.Items(8).Text.Trim & "');self.close();</script>")
                Else
                    Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text.Trim & " " & ddlLabel.Items(8).Text.Trim & "');</script>")
                End If
                txtPatronCodeText.Text = ""
                txtLockedDaysText.Text = "1"
                txtNoteText.Text = ""
            Catch ex As Exception ' Check error
            End Try
        End Sub

        ' Event: btnDelete_Click
        ' Purpose: Delete 
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            'Dim dgrItem As DataGridItem
            'Dim lblHidden As Label
            Dim strCrr_IDs As String = ""
            Dim strCrr_ID As String = ""
            Dim intCount As Integer = 0

            ' Find control in datagrid
            For intCount = 0 To dgdPantronLocks.Items.Count - 1
                If CType(dgdPantronLocks.Items(intCount).Cells(6).FindControl("chkCopyID"), CheckBox).Checked Then
                    strCrr_ID = CType(dgdPantronLocks.Items(intCount).Cells(1).FindControl("lblPatronCode"), Label).Text
                    'strCrr_IDs = strCrr_IDs & ", '" & strCrr_ID & "'"
                    strCrr_IDs = strCrr_IDs & "," & strCrr_ID
                End If
            Next
            If Len(strCrr_IDs) <> 0 Then
                strCrr_IDs = Right(strCrr_IDs, Len(strCrr_IDs) - 1)
                'Practic del information in reservations

                Dim lstPatronCodeUnLock As New List(Of String)
                Dim lstPatronCodeNotUnLock As New List(Of String)
                Dim lstPatronCodeNotExist As New List(Of String)

                If strCrr_IDs <> "" Then

                    Dim splitIDs As String() = strCrr_IDs.Split(",")
                    For Each strID As String In splitIDs
                        objBPatron.PatronCode = strID
                        Dim intResult As Integer = objBPatron.UnLockPatronCard(0)
                        If intResult = 0 Then
                            lstPatronCodeNotUnLock.Add(strID)
                        End If
                        If intResult = 1 Then
                            lstPatronCodeUnLock.Add(strID)
                        End If
                        If intResult = 2 Then
                            lstPatronCodeNotExist.Add(strID)
                        End If
                    Next

                    'List PatronCode IsNot UnLock
                    Dim strPatronCodeNotUnLock As String = ""
                    Dim i As Integer = 0
                    If lstPatronCodeNotUnLock.Count > 0 Then
                        For Each strPatronCode As String In lstPatronCodeNotUnLock
                            If i = 0 Then
                                strPatronCodeNotUnLock = strPatronCodeNotUnLock & strPatronCode
                            Else
                                strPatronCodeNotUnLock = strPatronCodeNotUnLock & "," & strPatronCode
                            End If
                            i = i + 1
                        Next
                    End If

                    'List PatronCode Not Exist
                    i = 0
                    Dim strPatronCodeNotExist As String = ""
                    If lstPatronCodeNotExist.Count > 0 Then
                        For Each strPatronCode As String In lstPatronCodeNotExist
                            If i = 0 Then
                                strPatronCodeNotExist = strPatronCodeNotExist & strPatronCode
                            Else
                                strPatronCodeNotExist = strPatronCodeNotExist & "," & strPatronCode
                            End If
                            i = i + 1
                        Next
                    End If

                    'List PatronCode UnLock Success
                    i = 0
                    Dim strPatronCodeUnLock As String = ""
                    If lstPatronCodeUnLock.Count > 0 Then
                        For Each strPatronCode As String In lstPatronCodeUnLock
                            If i = 0 Then
                                strPatronCodeUnLock = strPatronCodeUnLock & strPatronCode
                            Else
                                strPatronCodeUnLock = strPatronCodeUnLock & "," & strPatronCode
                            End If
                            i = i + 1
                        Next
                    End If

                    If strPatronCodeUnLock <> "" Then
                        Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & String.Format(lblMsg3.Text, strPatronCodeUnLock) & "');</script>")
                    End If

                    If strPatronCodeNotUnLock <> "" Then
                        Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & String.Format(lblMsg1.Text, strPatronCodeNotUnLock) & "');</script>")
                    End If

                    If strPatronCodeNotExist <> "" Then
                        Page.RegisterClientScriptBlock("ConfirmJS", "<script language = 'javascript'>confirm('" & String.Format(lblMsg2.Text, strPatronCodeNotExist) & "', '" & strPatronCodeNotExist & "');</script>")
                    End If

                    'objBPatron.PatronCode = strCrr_IDs
                    'objBPatron.UnLockPatronCard()
                    ' WriteLog
                    Call WriteLog(110, ddlLabel.Items(3).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    Call ShowResult()
                End If
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
                If Not objBLoanTransaction Is Nothing Then
                    objBLoanTransaction.Dispose(True)
                    objBLoanTransaction = Nothing
                End If
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
            Finally
                MyBase.Dispose()
            End Try
        End Sub

        Private Sub btnFillter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFillter.Click
            Call BindData()
            txtPatronCodeF.Text = ""
        End Sub
        Protected Sub btnAcceptUnLock_Click(sender As Object, e As EventArgs) Handles btnAcceptUnLock.Click

            Dim splitPatronCode As String() = hidPatronCodeNotExist.Value.Split(",")
            Dim lstPatronCodeNotExist As New List(Of String)
            For Each strPatronCode As String In splitPatronCode
                objBPatron.PatronCode = strPatronCode
                Dim intResult As Integer = objBPatron.UnLockPatronCard(1)
                If intResult = 1 Then
                    lstPatronCodeNotExist.Add(strPatronCode)
                End If
            Next
            Dim i As Integer = 0
            Dim strPatronCodeUnLock As String = ""
            If lstPatronCodeNotExist.Count > 0 Then
                For Each strPatronCode As String In lstPatronCodeNotExist
                    If i = 0 Then
                        strPatronCodeUnLock = strPatronCodeUnLock & strPatronCode
                    Else
                        strPatronCodeUnLock = strPatronCodeUnLock & "," & strPatronCode
                    End If
                    i = i + 1
                Next

                If strPatronCodeUnLock <> "" Then
                    Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & String.Format(lblMsg3.Text, strPatronCodeUnLock) & "');</script>")
                End If

            End If
        End Sub

    End Class
End Namespace