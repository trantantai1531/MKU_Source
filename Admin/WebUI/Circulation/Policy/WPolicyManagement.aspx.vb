Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Patron
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WPolicyManagement
        Inherits clsWBase
        Implements IUCNumberOfRecord

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblDataTimeUnit As System.Web.UI.WebControls.Label
        Protected WithEvents lblDataFixFee As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBLoanType As New clsBLoanType
        Private objBPatronGroup As  new clsBPatronGroup

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(70) Then
                btnNew.Enabled = False
                btnGroup.Enabled = False
            End If
        End Sub

        Private Sub Initialze()
            objBLoanType.InterfaceLanguage = Session("InterfaceLanguage")
            objBLoanType.DBServer = Session("DBServer")
            objBLoanType.ConnectionString = Session("ConnectionString")
            Call objBLoanType.Initialize()
            ''
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            Call objBPatronGroup.Initialize()
        End Sub

        Private Sub BindData()
            Dim tblLoanType As New DataTable

            objBLoanType.LoanTypeID = 0
            objBLoanType.LibID = clsSession.GlbSite
            tblLoanType = objBLoanType.GetLoanTypes()
            If Not tblLoanType Is Nothing Then
                If tblLoanType.Rows.Count > 0 Then
                    dtgPolicy.DataSource = ProcessTab(tblLoanType)
                    'dtgPolicy.CurrentPageIndex = intPage
                    'dtgPolicy.DataBind()
                End If
                tblLoanType = Nothing
            End If
            Call BinDDl()
        End Sub

        Private Sub BinDDl()
            Dim arrTimeUnit() = Split(lblLabel1.Text, "|")
            Dim arrValTimeUnit() = {1, 2}
            Dim arrFixedFee() = Split(lblLabel2.Text, "|")
            Dim arrValFixedFee() = {1, 2}

            ' Load dropdownlist TimeUnit
            ddlNewTimeUnit.DataSource = CreateTable(arrTimeUnit, arrValTimeUnit)
            ddlNewTimeUnit.DataTextField = "TextField"
            ddlNewTimeUnit.DataValueField = "ValueField"
            ddlNewTimeUnit.DataBind()

            ' Load dropdownlist FixedFee
            ddlNewFixedFee.DataSource = CreateTable(arrFixedFee, arrValFixedFee)
            ddlNewFixedFee.DataTextField = "TextField"
            ddlNewFixedFee.DataValueField = "ValueField"
            ddlNewFixedFee.DataBind()

            'Load data to dropdownlist LoanTypeGroup
            ddlLoanTypeGroup.DataSource = objBLoanType.GetLoanTypes
            ddlLoanTypeGroup.DataTextField = "LoanType"
            ddlLoanTypeGroup.DataValueField = "ID"
            ddlLoanTypeGroup.DataBind()
            ''Load data to select
            Dim tmpResult As  DataTable
            objBPatronGroup.LibID = clsSession.GlbSite
            tmpResult = objBPatronGroup.GetPatronGroup()
            selectGroups.DataSource = tmpResult
            selectGroups.DataTextField = "Name"
            selectGroups.DataValueField = "ID"
            selectGroups.DataBind()
        End Sub

        Private Function ProcessTab(ByVal tblSrc As DataTable) As DataTable
            Dim intCount As Integer
            Dim arrTimeUnit() = Split(lblLabel1.Text, "|")
            Dim arrFixFee() = Split(lblLabel2.Text, "|")
            Dim tblTotalCopies As New DataTable
            Dim rowi As DataRow()
            Dim strTmp As String = ""
            Dim intLoanTypeID As Integer = 0

            ' get total copies for each LoanTypeID
            tblTotalCopies = objBLoanType.GetTotal_HoldingCopies(CInt(Session("UserID")))
            If Not tblSrc Is Nothing And Not tblTotalCopies Is Nothing Then
                For intCount = 0 To tblSrc.Rows.Count - 1
                    intLoanTypeID = tblSrc.Rows(intCount).Item("ID")
                    ' filter by LoanTypeID
                    rowi = tblTotalCopies.Select("LoanTypeID=" & intLoanTypeID)

                    strTmp = ""
                    strTmp = tblSrc.Rows(intCount).Item("LoanType")
                    strTmp = strTmp & " ("
                    If rowi.GetUpperBound(0) > -1 Then
                        strTmp = strTmp & "<Font color='990000'><b>" & rowi(0).Item("NOR") & "</b></Font> " & ddlLabel.Items(6).Text & ")<BR><a href='WChangeLoanType.aspx?intLoanTypeID=" & intLoanTypeID & "' runat='server' class='lbLinkFunction'>" & ddlLabel.Items(7).Text & "</a>"
                    Else
                        strTmp = strTmp & "<Font color='990000'><b>0</b></Font> " & ddlLabel.Items(6).Text & ")"
                    End If
                    tblSrc.Rows(intCount).Item("strLoanTypeView") = strTmp
                    If tblSrc.Rows(intCount).Item("TimeUnit") = 1 Then
                        tblSrc.Rows(intCount).Item("strTimeUnit") = arrTimeUnit(0)
                    Else
                        tblSrc.Rows(intCount).Item("strTimeUnit") = arrTimeUnit(1)
                    End If

                    If tblSrc.Rows(intCount).Item("FixedFee") Then
                        tblSrc.Rows(intCount).Item("strFixedFee") = arrFixFee(0)
                    Else
                        tblSrc.Rows(intCount).Item("strFixedFee") = arrFixFee(1)
                    End If
                Next
            End If
            Return tblSrc
        End Function

        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Policy/WPolicyManagement.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnNew.Attributes.Add("onClick", "return ValidNew('" & ddlLabel.Items(4).Text & "');")
            btnGroup.Attributes.Add("onClick", "return SureMerge('" & ddlLabel.Items(5).Text & "')")

            txtNewLoanPeriod.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(11).Text & "'); this.value=''; this.focus();}")
            txtNewRenewals.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(11).Text & "'); this.value=''; this.focus();}")
            txtNewRenewalPeriod.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(11).Text & "'); this.value=''; this.focus();}")
            txtNewOverdueFine.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(11).Text & "'); this.value=''; this.focus();}")
            txtNewFee.Attributes.Add("OnChange", "if (!CheckNum(this)) {alert('" & ddlLabel.Items(11).Text & "'); this.value=''; this.focus();}")
        End Sub

        Protected Sub dtgPolicy_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgPolicy.UpdateCommand
            Dim intItemIndex As Integer = 0
            Dim intIndexControl As Integer = 0
            Dim lngID As Long = 0
            Dim dblFee As Double = 0
            Dim bytFixedFee As Byte
            Dim bytLoanPeriod As Integer = 0
            Dim strLoanType As String = ""
            Dim strLoanTypeCode As String = ""
            Dim dblOverdueFine As Double = 0
            Dim bytRenewals As Integer = 0
            Dim bytRenewPeriod As Integer = 0
            Dim bytTimeUnit As Integer = 0
            Dim blnValidUpdate As Boolean = True

            'Dim intLoanPeriod As Byte

            intItemIndex = e.Item.ItemIndex

            ' Get Value
            lngID = CLng(CType(e.Item.Cells(1).FindControl("lblID"), Label).Text)
            If CType(e.Item.Cells(8).FindControl("txtFee"), TextBox).Text <> "" Then
                If IsNumeric(CType(e.Item.Cells(8).FindControl("txtFee"), TextBox).Text) Then
                    dblFee = CDbl(CType(e.Item.Cells(8).FindControl("txtFee"), TextBox).Text)
                Else
                    blnValidUpdate = False
                    intIndexControl = 6
                    GoTo ErrInput
                End If
            Else
                blnValidUpdate = False
                intIndexControl = 6
                GoTo ErrInput
            End If
            bytFixedFee = CType(e.Item.Cells(10).FindControl("ddlFixedFee"), DropDownList).SelectedValue
            If CType(e.Item.Cells(4).FindControl("txtLoanPeriod"), TextBox).Text <> "" Then
                If IsNumeric(CType(e.Item.Cells(4).FindControl("txtLoanPeriod"), TextBox).Text) Then
                    bytLoanPeriod = CInt(CType(e.Item.Cells(4).FindControl("txtLoanPeriod"), TextBox).Text)
                Else
                    blnValidUpdate = False
                    intIndexControl = 2
                    GoTo ErrInput
                End If
            Else
                blnValidUpdate = False
                intIndexControl = 2
                GoTo ErrInput
            End If
            strLoanType = CType(e.Item.Cells(2).FindControl("txtLoanType"), TextBox).Text
            If Trim(strLoanType) = "" Then
                blnValidUpdate = False
                intIndexControl = 1
                GoTo ErrInput
            End If
            strLoanTypeCode = CType(e.Item.Cells(3).FindControl("txtLoanTypeCode"), TextBox).Text
            If Trim(strLoanTypeCode) = "" Then
                blnValidUpdate = False
                intIndexControl = 3
                GoTo ErrInput
            End If
            If CType(e.Item.Cells(8).FindControl("txtOverdueFine"), TextBox).Text <> "" Then
                If IsNumeric(CType(e.Item.Cells(8).FindControl("txtOverdueFine"), TextBox).Text) Then
                    dblOverdueFine = CDbl(CType(e.Item.Cells(8).FindControl("txtOverdueFine"), TextBox).Text)
                Else
                    blnValidUpdate = False
                    intIndexControl = 5
                    GoTo ErrInput
                End If
            Else
                blnValidUpdate = False
                intIndexControl = 5
                GoTo ErrInput
            End If
            If CType(e.Item.Cells(6).FindControl("txtRenewals"), TextBox).Text <> "" Then
                If IsNumeric(CType(e.Item.Cells(6).FindControl("txtRenewals"), TextBox).Text) Then
                    bytRenewals = CInt(CType(e.Item.Cells(6).FindControl("txtRenewals"), TextBox).Text)
                Else
                    blnValidUpdate = False
                    intIndexControl = 1
                    GoTo ErrInput
                End If
            Else
                blnValidUpdate = False
                intIndexControl = 1
                GoTo ErrInput
            End If
            If CType(e.Item.Cells(7).FindControl("txtRenewalPeriod"), TextBox).Text <> "" Then
                If IsNumeric(CType(e.Item.Cells(7).FindControl("txtRenewalPeriod"), TextBox).Text) Then
                    bytRenewPeriod = CInt(CType(e.Item.Cells(7).FindControl("txtRenewalPeriod"), TextBox).Text)
                Else
                    blnValidUpdate = False
                    intIndexControl = 4
                    GoTo ErrInput
                End If
            Else
                blnValidUpdate = False
                intIndexControl = 4
                GoTo ErrInput
            End If
ErrInput:
            If Not blnValidUpdate Then
                Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>ValidUpdate(" & intIndexControl & ",'" & ddlLabel.Items(4).Text & "'," & intItemIndex & ")</script>")
            Else
                bytTimeUnit = CInt(CType(e.Item.Cells(5).FindControl("ddlSelectTimeUnit"), DropDownList).SelectedValue)
                If bytTimeUnit = 0 Then
                    bytTimeUnit = 2
                End If
                'Check with MaxHour=15h
                If bytTimeUnit = 2 Then
                    If bytLoanPeriod > 15 Then
                        Page.RegisterClientScriptBlock("JSErr", "<script language = 'javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
                        bytLoanPeriod = 1
                    End If
                End If

                objBLoanType.LoanTypeID = lngID
                objBLoanType.Fee = dblFee
                objBLoanType.FixedFee = bytFixedFee
                objBLoanType.LoanPeriod = bytLoanPeriod
                objBLoanType.LoanType = strLoanType
                objBLoanType.LoanTypeCode = strLoanTypeCode
                objBLoanType.OverdueFine = dblOverdueFine
                objBLoanType.Renewals = bytRenewals
                objBLoanType.RenewPeriod = bytRenewPeriod
                objBLoanType.TimeUnit = bytTimeUnit
                objBLoanType.PatronGroupIDs = Hidden1.Value
                objBLoanType.UpdateLoanType()
                ' WriteLog
                Call WriteLog(110, ddlLabel.Items(9).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                'dtgPolicy.EditItemIndex = -1
                Call BindData()
            End If
        End Sub

        Protected Sub dtgPolicy_EditCommand(sender As Object, e As GridCommandEventArgs) Handles dtgPolicy.EditCommand
            Dim intIndex As Integer
            Dim ddlTimeUnitTmp As New DropDownList
            Dim ddlFixedFeeTmp As New DropDownList
            Dim arrTimeUnit() = Split(lblLabel1.Text, "|")
            Dim arrValTimeUnit() = {1, 0}
            Dim arrFixedFee() = Split(lblLabel2.Text, "|")
            Dim arrValFixedFee() = {1, 0}

            intIndex = CInt(e.Item.ItemIndex)
            'dtgPolicy.EditItemIndex = intIndex
            Call BindData()
        End Sub

        Protected Sub dtgPolicy_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles dtgPolicy.ItemCommand
            Dim strJS As String
            Dim strCmd As String = ""
            Dim objLabel As New Label
            Dim strMark As String = ""

            strCmd = UCase(e.CommandName)
            If strCmd = "EDIT" Or strCmd = "UPDATE" Or strCmd = "CANCEL" Then
                objLabel = CType(e.Item.FindControl("lblMark"), Label)
                strMark = Replace(objLabel.Text, "<a name=""", "")
                strMark = Replace(strMark, """>", "")
                strJS = "<script language='JavaScript'>"
                strJS = strJS & "self.location.href='#" & strMark & "';"
                'strJS = strJS & ";"
                strJS = strJS & "</script>"
                Page.RegisterClientScriptBlock("Bookmark", strJS)
            End If
        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
            'Check with MaxHour=15h
            If CInt(ddlNewTimeUnit.SelectedValue) = 2 Then
                If CInt(txtNewLoanPeriod.Text) > 15 Then
                    Page.RegisterClientScriptBlock("JSErr", "<script language = 'javascript'>alert('" & ddlLabel.Items(13).Text & "');</script>")
                    Exit Sub
                End If
            End If
            Dim fee = 0
            If txtNewFee.Text <> "" Then
                objBLoanType.Fee = txtNewFee.Text
            Else
                objBLoanType.Fee = 0
            End If

            objBLoanType.FixedFee = ddlNewFixedFee.SelectedValue
            'objBLoanType.LoanPeriod = txtNewLoanPeriod.Text
            objBLoanType.LoanPeriod = 1 '' 
            objBLoanType.LoanType = txtNewLoanType.Text
            objBLoanType.OverdueFine = txtNewOverdueFine.Text
            objBLoanType.Renewals = txtNewRenewals.Text
            objBLoanType.RenewPeriod = txtNewRenewalPeriod.Text
            'objBLoanType.TimeUnit = ddlNewTimeUnit.SelectedValue
            objBLoanType.TimeUnit = 1 '' ngay
            objBLoanType.LibID = clsSession.GlbSite
            objBLoanType.LoanTypeCode = txtLoanTypeCode.Text
            objBLoanType.PatronGroupIDs = HidenListGroups.Value
            Dim intOut As Integer
            intOut = objBLoanType.CreateLoanType()
            If intOut > 0 Then
                Page.RegisterClientScriptBlock("JSNoAlert", "<script language = 'javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                Exit Sub
            Else
                Page.RegisterClientScriptBlock("JSNoAlert", "<script language = 'javascript'>alert('Tạo mới chính sách lưu thông thành công');</script>")
            End If

            ' WriteLog
            Call WriteLog(110, ddlLabel.Items(8).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Call BindData()
            txtNewFee.Text = ""
            txtNewLoanPeriod.Text = ""
            txtNewLoanType.Text = ""
            txtNewOverdueFine.Text = ""
            txtNewRenewals.Text = ""
            txtNewRenewalPeriod.Text = ""
            txtLoanTypeCode.Text = ""
        End Sub

        Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
            Dim intCount As Integer
            Dim strIDs As String = ""
            For intCount = 0 To dtgPolicy.Items.Count - 1
                If CType(dtgPolicy.Items(intCount).Cells(10).FindControl("chkCopyID"), CheckBox).Checked Then
                    strIDs = strIDs & CType(dtgPolicy.Items(intCount).Cells(1).FindControl("lblID"), Label).Text & ","
                End If
            Next
            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
            End If
            objBLoanType.LoanTypeID = ddlLoanTypeGroup.SelectedValue
            objBLoanType.GroupLoanTypeIDs = strIDs
            objBLoanType.MergeLoanType()
            Page.RegisterClientScriptBlock("JSNoAlert", "<script language = 'javascript'>alert('Gộp chính sách lưu thông thành công');</script>")
            ' WriteLog
            Call WriteLog(110, ddlLabel.Items(10).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            Call BindData()
            dtgPolicy.Rebind()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBLoanType Is Nothing Then
                    objBLoanType.Dispose(True)
                    objBLoanType = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub dtgPolicy_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgPolicy.NeedDataSource
            BindData()

        End Sub

        Public Function NumberOfRecord() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

        Protected Sub dtgPolicy_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles dtgPolicy.ItemDataBound

            If e.Item.IsInEditMode Then
                Dim editItem As GridEditableItem = DirectCast(e.Item, GridEditableItem)
                Dim intIndex As Integer
                Dim ddlTimeUnitTmp As New DropDownList
                Dim ddlFixedFeeTmp As New DropDownList
                Dim selectGroup As New HtmlSelect
                Dim arrTimeUnit() = Split(lblLabel1.Text, "|")
                Dim arrValTimeUnit() = {1, 0}
                Dim arrFixedFee() = Split(lblLabel2.Text, "|")
                Dim arrValFixedFee() = {1, 0}
                ' Load dropdownlist TimeUnit
                ddlTimeUnitTmp = CType(editItem.FindControl("ddlSelectTimeUnit"), DropDownList)
                ddlTimeUnitTmp.DataSource = CreateTable(arrTimeUnit, arrValTimeUnit)
                ddlTimeUnitTmp.DataTextField = "TextField"
                ddlTimeUnitTmp.DataValueField = "ValueField"
                ddlTimeUnitTmp.DataBind()
                If CType(editItem.FindControl("txtSelectTimeUnit"), TextBox).Text = "0" Then
                    ddlTimeUnitTmp.SelectedIndex = 1
                End If

                ' Load dropdownlist FixedFee
                ddlFixedFeeTmp = CType(editItem.FindControl("ddlFixedFee"), DropDownList)
                ddlFixedFeeTmp.DataSource = CreateTable(arrFixedFee, arrValFixedFee)
                ddlFixedFeeTmp.DataTextField = "TextField"
                ddlFixedFeeTmp.DataValueField = "ValueField"
                ddlFixedFeeTmp.DataBind()
                If Not CBool(CType(editItem.FindControl("txtSelectFixedFee"), TextBox).Text) Then
                    ddlFixedFeeTmp.SelectedIndex = 1
                End If

                '' Load select PatronGroups
                Dim tmpselectGroup As DataTable
                objBPatronGroup.LibID = clsSession.GlbSite
                tmpselectGroup = objBPatronGroup.GetPatronGroup()

                selectGroup = CType(editItem.FindControl("ReSelectGroups"), HtmlSelect)
                selectGroup.DataSource = tmpselectGroup
                selectGroup.DataTextField = "Name"
                selectGroup.DataValueField = "ID"
                selectGroup.DataBind()

                Dim Groups = CType(editItem.FindControl("txtGroupsName"), TextBox)

                Dim strJS = " <script language = 'javascript'> "
                'strJS &= " $('#Hidden1').val(" & Groups.Text & "); "
                strJS &= " var x = '" & Groups.Text & "' ; "
                strJS &= " $('#Hidden1').val(x); "
                strJS &= " var y = x.split(','); "
                strJS &= " $('#" & selectGroup.ClientID & "').val(y).trigger('chosen:updated'); "
                strJS &= " $('#" & selectGroup.ClientID & "').change(function(){ "
                strJS &= " var listGroups = ''; "
                strJS &= " $('#" & selectGroup.ClientID & " :selected').each(function () { "
                strJS &= " listGroups += ',' + $(this).val(); "
                strJS &= " }); "
                strJS &= " if (listGroups.length > 0) { "
                strJS &= " listGroups = listGroups.substring(1,listGroups.length) } "
                strJS &= " $('#Hidden1').val(listGroups); "
                strJS &= " }); "
                strJS &= " </script>"
                ClientScript.RegisterStartupScript(Me.GetType(), Nothing, strJS)
            End If


        End Sub
    End Class
End Namespace