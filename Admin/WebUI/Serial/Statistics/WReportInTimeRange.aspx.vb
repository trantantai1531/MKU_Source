' Class: WReportInTimeRange
' Puspose: Report acquiried in range time
' Creator: Sondp
' CreatedDate: 17/04/2005
' Modification history:
' Review code : Lent 20-04-2005

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WReportInTimeRange
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

        Private objBPC As New clsBPeriodicalCollection
        Dim tblDataReturn As DataTable

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            Call objBPC.Initialize()
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(98) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ShelfJS", "<script language='javascript' src='../Js/Statistics/WReportInTimeRange.js'></script>")
            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkFromTime, txtFromTime, ddlLabel.Items(3).Text)
            SetOnclickCalendar(lnkToTime, txtToTime, ddlLabel.Items(3).Text)

            btnReset.Attributes.Add("OnClick", "ResetForm();return false;")
            btnReport.Attributes.Add("OcClick", "return CheckReport('" & ddlLabel.Items(3).Text & "');")
        End Sub

        ' btnReport_Click event
        Private Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
            BindDataSearch()
        End Sub


        Private Sub BindDataSearch(Optional ByVal blnPageSwitch As Boolean = False)
            Dim intRow, intCount As Integer

            objBPC.FromDate = txtFromTime.Text
            objBPC.ToDate = txtToTime.Text
            tblDataReturn = objBPC.GenReportByRangeTime()
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

            dtgResult.Visible = False
            lblDataNotFound.Visible = True
            If Not tblDataReturn Is Nothing AndAlso tblDataReturn.Rows.Count > 0 Then

                dtgResult.Visible = True
                lblDataNotFound.Visible = False
                dtgResult.DataSource = tblDataReturn
                dtgResult.DataBind()
                If Not blnPageSwitch Then
                    dtgResult.CurrentPageIndex = 0
                End If
                intCount = tblDataReturn.Rows.Count
                'Changer columns
                For intRow = 0 To intCount - 1
                    dtgResult.Items(intRow).Cells(1).Text = ChangColumn(CInt(tblDataReturn.Rows(intRow).Item("ItemID")))
                Next
            End If
        End Sub

        ' BindData method
        Private Function ChangColumn(ByVal intItemID As Integer) As String
            Dim intYear As Integer
            Dim intResetReg As Integer

            Dim strMonths As String
            Dim arrYear() As String
            Dim arrYearIssue() As String
            Dim strHavingYearIssue As String

            Dim strShowHas, strShowLost, strHas, strLost, strShow As String
            Dim strFromTime, strToTime As String

            strFromTime = Trim(txtFromTime.Text)
            strToTime = Trim(txtToTime.Text)
            strShow = ""
            objBPC.LocationID = 0
            objBPC.ItemID = intItemID
            Call objBPC.GetReceiveIssueForStatic(strFromTime, strToTime, intResetReg, strMonths, strHavingYearIssue)
            If objBPC.ErrorMsg <> "" Then
                ChangColumn = ""
                Exit Function
            End If

            ' For reset mode is every month
            If intResetReg = 1 Then
                ' Format strMonths: 2005:1,2,3|2,3,4....; (not has volumns) or 2006:Tap1@1,2,3|2,4...#Tap2@1,2,3,..|2,3,4..;
                arrYear = strMonths.Split(";")
                For intYear = 0 To arrYear.Length - 1
                    arrYearIssue = arrYear(intYear).Split(":")
                    strShowHas &= arrYearIssue(0) & ":" & "<br>"
                    clsGetIssueNos.GetHasLostIssueNo(intResetReg, arrYearIssue(1), "", "0", ddlLabel.Items(9).Text, ddlLabel.Items(4).Text, "", strHas, strLost)
                    If strHas <> "" Then
                        strShowHas &= strHas
                    End If
                Next
            End If   ' For reset mode = 1

            ' For reset mode is every year
            If intResetReg <> 1 Then
                If strHavingYearIssue <> "" Then
                    arrYear = strHavingYearIssue.Split(";")
                    'don't has any volumn
                    strShowHas = ""
                    strShowLost = ""
                    For intYear = 0 To arrYear.Length - 1
                        arrYearIssue = arrYear(intYear).Split(":")
                        clsGetIssueNos.GetHasLostIssueNo(intResetReg, "", arrYearIssue(1), "0", ddlLabel.Items(9).Text, ddlLabel.Items(4).Text, "", strHas, strLost)
                        If strHas <> "" Then
                            strShowHas &= arrYearIssue(0) & ":" & strHas & "<BR>"
                        End If
                    Next
                End If
            End If
            ChangColumn = strShowHas
        End Function
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPC Is Nothing Then
                    objBPC.Dispose(True)
                    objBPC = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Private Sub dtgResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgResult.PageIndexChanged
            dtgResult.CurrentPageIndex = e.NewPageIndex
            BindDataSearch(True)
        End Sub

        Private Sub dtgResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgResult.ItemCreated
            If Not tblDataReturn Is Nothing Then
                Select Case e.Item.ItemType
                    Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                        Dim lnk As HyperLink
                        lnk = CType(e.Item.Cells(3).FindControl("lnkSelect"), HyperLink)
                        lnk.Font.Bold = True
                        Dim inti As Integer
                        inti = e.Item.DataSetIndex()
                        ' Add the attribute for the hiperlink to change the item session to item selected
                        lnk.NavigateUrl = "#"
                        lnk.Attributes.Add("onclick", "javascript:parent.Hiddenbase.location.href='../WSaveSession.aspx';parent.Hiddenbase.document.forms[0].hidItemID.value=" & CInt(tblDataReturn.Rows(inti).Item("ItemID")) & ";parent.Hiddenbase.document.forms[0].hidTitle.value='" & CStr(tblDataReturn.Rows(inti).Item("Content")) & "';parent.Hiddenbase.document.forms[0].btnSave.click();alert('" & ddlLabel.Items(8).Text & "');return false;")
                End Select
            End If
        End Sub
    End Class
End Namespace