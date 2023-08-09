Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WClaim
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub


#End Region

        ' Declare variables
        Private objBBClaimTemplate As New clsBClaimTemplate
        Private objBPeriodicalCollection As New clsBPeriodicalCollection
        Private objBDB As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindDrowpDownList()
                Call ActiveControls(False)
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(96) Then
                btnCheck1.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBBClaimTemplate object
            objBBClaimTemplate.ConnectionString = Session("ConnectionString")
            objBBClaimTemplate.DBServer = Session("DBServer")
            objBBClaimTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBBClaimTemplate.Initialize()

            'Init objBPeriodicalCollection object
            objBPeriodicalCollection.ConnectionString = Session("ConnectionString")
            objBPeriodicalCollection.DBServer = Session("DBServer")
            objBPeriodicalCollection.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPeriodicalCollection.Initialize()

            'Init objBDB object
            objBDB.ConnectionString = Session("ConnectionString")
            objBDB.DBServer = Session("DBServer")
            objBDB.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBDB.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("ClaimJs", "<script language='javascript' src='../js/Claim/WClaim.js'></script>")

            'hrfTemplate.Attributes.Add("OnClick", "parent.Workform.location.href='WClaimTemplateManagement.aspx';return false;")

            rdClaimCycle1.Attributes.Add("OnClick", "document.forms[0].hdClaimCycleMode.value=1;")
            rdClaimCycle2.Attributes.Add("OnClick", "document.forms[0].hdClaimCycleMode.value=2;")
            rdClaimCycle3.Attributes.Add("OnClick", "document.forms[0].hdClaimCycleMode.value=3;")

            txtAcqYear.Attributes.Add("OnChange", "if(isNaN(document.forms[0].txtAcqYear.value)){alert('" & ddlLabel.Items(4).Text & "');document.forms[0].txtAcqYear.value='';document.forms[0].txtAcqYear.focus(); return false;}")

            btnPreview.Attributes.Add("OnClick", "if(document.forms[0].ddlClaimTemplate.options[document.forms[0].ddlClaimTemplate.options.selectedIndex].value==0){alert('" & ddlLabel.Items(5).Text & "');document.forms[0].ddlClaimTemplate.focus(); return false;} else{if(!CheckOptionsNull('dgrClaimItem', 'ckbIssueNo', 3, 20, '" & ddlLabel.Items(10).Text & "')) {return false;}}")
            btnPrintLetter.Attributes.Add("OnClick", "if(document.forms[0].ddlClaimTemplate.options[document.forms[0].ddlClaimTemplate.options.selectedIndex].value==0){alert('" & ddlLabel.Items(5).Text & "');document.forms[0].ddlClaimTemplate.focus(); return false;} else{if(!CheckOptionsNull('dgrClaimItem', 'ckbIssueNo', 3, 20, '" & ddlLabel.Items(10).Text & "')) {return false;}}")
            btnSendEmail.Attributes.Add("OnClick", "if(document.forms[0].ddlClaimTemplate.options[document.forms[0].ddlClaimTemplate.options.selectedIndex].value==0){alert('" & ddlLabel.Items(5).Text & "');document.forms[0].ddlClaimTemplate.focus(); return false;} else{if(!CheckOptionsNull('dgrClaimItem', 'ckbIssueNo', 3, 20, '" & ddlLabel.Items(10).Text & "')) {return false;}}")
            '   btnCheck.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtAcqYear)) {alert('" & ddlLabel.Items(9).Text & "'); return false;}")
        End Sub

        ' Method: BindDrowpDownList
        ' Purpose: Bind data to DrowpDownlist method
        Private Sub BindDrowpDownList()
            Dim tblClaimTemplate As New DataTable
            Dim lsItem As New ListItem

            objBBClaimTemplate.TemplateID = 0
            objBBClaimTemplate.TemplateType = 6
            objBBClaimTemplate.LibID = clsSession.GlbSite
            tblClaimTemplate = objBBClaimTemplate.GetTemplate

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBBClaimTemplate.ErrorMsg, ddlLabel.Items(0).Text, objBBClaimTemplate.ErrorCode)

            If Not tblClaimTemplate Is Nothing Then
                If tblClaimTemplate.Rows.Count > 0 Then
                    tblClaimTemplate = InsertOneRow(tblClaimTemplate, ddlLabel.Items(3).Text)
                    ddlClaimTemplate.DataSource = tblClaimTemplate
                    ddlClaimTemplate.DataTextField = "Title"
                    ddlClaimTemplate.DataValueField = "ID"
                    ddlClaimTemplate.DataBind()
                Else
                    lsItem.Text = ddlLabel.Items(3).Text
                    lsItem.Value = 0
                    ddlClaimTemplate.Items.Add(lsItem)
                End If
            Else
                lsItem.Text = ddlLabel.Items(3).Text
                lsItem.Value = 0
                ddlClaimTemplate.Items.Add(lsItem)
            End If
            txtAcqYear.Text = Year(Now)
        End Sub

        ' Method: BindData
        ' Purpose: Bind Data method
        Private Sub BindData()
            Dim tblClaimItems As New DataTable
            Dim blnFound As Boolean = False

            objBPeriodicalCollection.SelectMode = "0"
            objBPeriodicalCollection.ClaimCycleMode = hdClaimCycleMode.Value
            objBPeriodicalCollection.IssueYear = txtAcqYear.Text
            objBPeriodicalCollection.IDs = ""

            ' Get All UnReceivedIssues
            objBPeriodicalCollection.LibID = clsSession.GlbSite
            tblClaimItems = objBPeriodicalCollection.GetIssueForClaim

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPeriodicalCollection.ErrorMsg, ddlLabel.Items(0).Text, objBPeriodicalCollection.ErrorCode)

            Call ActiveControls(False)

            If Not tblClaimItems Is Nothing Then
                If tblClaimItems.Rows.Count > 0 Then
                    blnFound = True
                    dgrClaimItem.DataSource = tblClaimItems
                    dgrClaimItem.DataBind()
                    Call ActiveControls(True)
                End If
            End If

            If blnFound = False Then
                Page.RegisterClientScriptBlock("NotFound", "<script language='javascript'>alert('" & ddlLabel.Items(11).Text & "')</script>")
            End If
        End Sub

        ' Method: ActiveControls
        ' Purpose: Active all controls method
        Private Sub ActiveControls(ByVal action As Boolean)
            lblClaimTemplate.Visible = action
            ddlClaimTemplate.Visible = action
            dgrClaimItem.Visible = action
            btnPreview.Visible = action
            btnPrintLetter.Visible = action
            btnSendEmail.Visible = action
        End Sub

        ' Method: PickIDs
        ' Purpose: Pick selected ItemID
        Private Function PickIDs(ByVal intType As Integer) As String
            Dim intIndex As Integer
            Dim strIDs As String = ""
            Dim tblResult, tblTitle As DataTable
            Dim strItemID As String
            Dim strMsg As String = ""
            If intType = 0 Then
                For intIndex = 0 To dgrClaimItem.Items.Count - 1
                    If CType(dgrClaimItem.Items(intIndex).Cells(0).FindControl("ckbIssueNo"), HtmlInputCheckBox).Checked = True Then
                        strItemID = CType(dgrClaimItem.Items(intIndex).Cells(1).FindControl("txtID"), TextBox).Text.ToString
                        objBDB.SQLStatement = "SELECT DISTINCT D.ClaimEmail,E.Title from Ser_tblIssue A,Ser_tblItem B,Acq_tblPo C,Acq_tblVendor D, Lib_tblItemTitle E WHERE A.ItemID=B.ItemID AND B.POID=C.ID AND C.VendorID=D.ID AND E.ItemID=A.ItemID AND A.ItemID=" & strItemID
                        tblResult = objBDB.RetrieveItemInfor
                        If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                            If Not IsDBNull(tblResult.Rows(0).Item(0)) And tblResult.Rows(0).Item(0) <> "" Then
                                strIDs &= strItemID & ","
                            Else
                                If Not IsDBNull(tblResult.Rows(0).Item(1)) And tblResult.Rows(0).Item(1) <> "" Then
                                    strMsg &= CStr(tblResult.Rows(0).Item(1)) & ","
                                End If
                            End If
                        Else
                            tblTitle = Nothing
                            objBDB.SQLStatement = "select * from Lib_tblItemTitle where ItemID=" & strItemID
                            tblTitle = objBDB.RetrieveItemInfor
                            If Not tblTitle Is Nothing AndAlso tblTitle.Rows.Count > 0 Then
                                If Not IsDBNull(tblTitle.Rows(0).Item("Title")) Then
                                    strMsg &= CStr(tblTitle.Rows(0).Item("Title")) & ","
                                End If
                            End If
                        End If
                    End If
                Next
            Else
                For intIndex = 0 To dgrClaimItem.Items.Count - 1
                    If CType(dgrClaimItem.Items(intIndex).Cells(0).FindControl("ckbIssueNo"), HtmlInputCheckBox).Checked = True Then
                        strIDs &= CType(dgrClaimItem.Items(intIndex).Cells(1).FindControl("txtID"), TextBox).Text.ToString & ","
                    End If
                Next
            End If
            If strIDs <> "" Then
                strIDs = Left(strIDs, strIDs.Length - 1)
            End If
            If strMsg <> "" Then
                hdMsg.Value = ddlLabel.Items(12).Text & " " & Left(strMsg, Len(strMsg) - 1) & " " & ddlLabel.Items(13).Text
            Else
                hdMsg.Value = ""
            End If
            Return (strIDs)
        End Function


        ' Method: PickEmails
        ' Purpose: Pick selected ItemID
        Private Function PickEmails(ByVal intType As Integer) As String
            Dim intIndex As Integer
            Dim strIDs As String = ""
            Dim tblResult, tblTitle As DataTable
            Dim strItemID As String
            Dim strMsg As String = ""
            If intType = 0 Then
                For intIndex = 0 To dgrClaimItem.Items.Count - 1
                    If CType(dgrClaimItem.Items(intIndex).Cells(0).FindControl("ckbIssueNo"), HtmlInputCheckBox).Checked = True Then
                        strItemID = CType(dgrClaimItem.Items(intIndex).Cells(1).FindControl("txtID"), TextBox).Text.ToString
                        objBDB.SQLStatement = "SELECT DISTINCT D.ClaimEmail,E.Title from Ser_tblIssue A,Ser_tblItem B,Acq_tblPo C,Acq_tblVendor D, Lib_tblItemTitle E WHERE A.ItemID=B.ItemID AND B.POID=C.ID AND C.VendorID=D.ID AND E.ItemID=A.ItemID AND A.ItemID=" & strItemID
                        tblResult = objBDB.RetrieveItemInfor
                        If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                            If Not IsDBNull(tblResult.Rows(0).Item(0)) And tblResult.Rows(0).Item(0) <> "" Then
                                strIDs &= tblResult.Rows(0).Item(0).ToString() & ","
                            Else
                                If Not IsDBNull(tblResult.Rows(0).Item(1)) And tblResult.Rows(0).Item(1) <> "" Then
                                    strMsg &= CStr(tblResult.Rows(0).Item(1)) & ","
                                End If
                            End If
                        Else
                            tblTitle = Nothing
                            objBDB.SQLStatement = "select * from Lib_tblItemTitle where ItemID=" & strItemID
                            tblTitle = objBDB.RetrieveItemInfor
                            If Not tblTitle Is Nothing AndAlso tblTitle.Rows.Count > 0 Then
                                If Not IsDBNull(tblTitle.Rows(0).Item("Title")) Then
                                    strMsg &= CStr(tblTitle.Rows(0).Item("Title")) & ","
                                End If
                            End If
                        End If
                    End If
                Next
            Else
                For intIndex = 0 To dgrClaimItem.Items.Count - 1
                    If CType(dgrClaimItem.Items(intIndex).Cells(0).FindControl("ckbIssueNo"), HtmlInputCheckBox).Checked = True Then
                        strIDs &= CType(dgrClaimItem.Items(intIndex).Cells(1).FindControl("txtID"), TextBox).Text.ToString & ","
                    End If
                Next
            End If
            If strIDs <> "" Then
                strIDs = Left(strIDs, strIDs.Length - 1)
            End If
            If strMsg <> "" Then
                hdMsg.Value = ddlLabel.Items(12).Text & " " & Left(strMsg, Len(strMsg) - 1) & " " & ddlLabel.Items(13).Text
            Else
                hdMsg.Value = ""
            End If
            Return (strIDs)
        End Function

        ' Event: btnCheck_Click
        Private Sub btnCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheck1.Click
            Call BindData()
        End Sub

        ' Event: dgrClaimItem_ItemCreated
        ' Purpose: Bind ItemID to CheckBox when datagrid created
        Private Sub dgrClaimItem_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrClaimItem.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim myTableCell As TableCell
                    myTableCell = e.Item.Cells(0)
                    Dim myCheckBox As HtmlInputCheckBox
                    myCheckBox = CType(myTableCell.FindControl("ckbIssueNo"), HtmlInputCheckBox)
            End Select
        End Sub

        ' Event: btnPreview_Click
        Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
            hdIDs.Value = PickIDs(1)
            If hdIDs.Value <> "" Then
                ' Write log
                Call WriteLog(115, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("SubmitPageJs", "<script language='javascript'>document.forms[0].action='WShowClaimLetter.aspx?Destination=Preview&IDs= " & hdIDs.Value & "&TemplateID=" & ddlClaimTemplate.SelectedValue & "&ClaimCycleMode=" & hdClaimCycleMode.Value & "&IssueYear=" & txtAcqYear.Text & "';document.forms[0].method='post';document.forms[0].submit();</script>")
            End If
        End Sub

        ' Event: dgrClaimItem_PageIndexChanged
        Private Sub dgrClaimItem_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrClaimItem.PageIndexChanged
            dgrClaimItem.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Event: btnPrintLetter_Click
        Private Sub btnPrintLetter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrintLetter.Click
            hdIDs.Value = PickIDs(1)
            If hdIDs.Value <> "" Then
                ' Write log
                Call WriteLog(115, ddlLabel.Items(7).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Page.RegisterClientScriptBlock("SubmitPageJs", "<script language='javascript'>document.forms[0].action='WShowClaimLetter.aspx?Destination=Print&IDs= " & hdIDs.Value & "&TemplateID=" & ddlClaimTemplate.SelectedValue & "&ClaimCycleMode=" & hdClaimCycleMode.Value & "&IssueYear=" & txtAcqYear.Text & "';document.forms[0].method='post';document.forms[0].submit();</script>")
            End If
        End Sub

        ' Event: btnSendEmail_Click
        Private Sub btnSendEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendEmail.Click
            hdIDs.Value = PickIDs(0)
            Session("ListEmail") = PickEmails(0)
            If hdIDs.Value <> "" Then
                ' Write log
                Call WriteLog(115, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Page.RegisterClientScriptBlock("SubmitPageJs", "<script language='javascript'>document.forms[0].action='WShowClaimLetter.aspx?Destination=Email&IDs= " & hdIDs.Value & "&TemplateID=" & ddlClaimTemplate.SelectedValue & "&ClaimCycleMode=" & hdClaimCycleMode.Value & "&IssueYear=" & txtAcqYear.Text & "&Msg=" & hdMsg.Value & "';document.forms[0].method='post';document.forms[0].submit();</script>")
            Else
                Page.RegisterClientScriptBlock("AlertJs1", "<script language='javascript'>alert('" & hdMsg.Value & "')</script>")
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
                If Not objBBClaimTemplate Is Nothing Then
                    objBBClaimTemplate.Dispose(True)
                    objBBClaimTemplate = Nothing
                End If
                If Not objBPeriodicalCollection Is Nothing Then
                    objBPeriodicalCollection.Dispose(True)
                    objBPeriodicalCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace