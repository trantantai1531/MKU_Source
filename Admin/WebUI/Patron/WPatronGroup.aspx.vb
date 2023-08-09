' Class: WPatronGroup
' Puspose: management patron group
' Creator: Lent
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WPatronGroup
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
        Private objBPatronGroup As New clsBPatronGroup
        Private objBPatron As New eMicLibAdmin.BusinessRules.Circulation.clsBPatron

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(47) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: Init all neccessary objects
        Private Sub Initialize()
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()

            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatron.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/WPatronGroup.js'></script>")

            txtInlibraryQuota.Attributes.Add("OnChange", "if (!CheckNum(this)) {this.focus(); this.value = 0; alert('" & ddlLabel.Items(5).Text & "'); return false;}")
            txtLoanQuota.Attributes.Add("OnChange", "if (!CheckNum(this)) {this.focus(); this.value = 0; alert('" & ddlLabel.Items(5).Text & "'); return false;}")
            txtIllQuota.Attributes.Add("OnChange", "if (!CheckNum(this)) {this.focus(); this.value = 0; alert('" & ddlLabel.Items(5).Text & "'); return false;}")
            txtHoldQuota.Attributes.Add("OnChange", "if (!CheckNum(this)) {this.focus(); this.value = 0; alert('" & ddlLabel.Items(5).Text & "'); return false;}")
            txtHoldTurnTimeOut.Attributes.Add("OnChange", "if (!CheckNum(this)) {this.focus(); this.value = 0; alert('" & ddlLabel.Items(5).Text & "'); return false;}")
            txtPriority.Attributes.Add("OnChange", "if (!CheckNum(this)) {this.focus(); this.value = 0; alert('" & ddlLabel.Items(5).Text & "'); return false;}")
            txtNameGroup.Attributes.Add("OnChange", "if (CheckNull(this)) {alert('" & ddlLabel.Items(10).Text & "'); return false;};")

            btnUpdate.Attributes.Add("OnClick", "javascript:return(CheckAddNew('" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "'));")
            btnReset.Attributes.Add("Onclick", "javascript:return(ResetForm());")
            btnAdd.Attributes.Add("OnClick", "javascript:AddItem();return(false);")
            btnRemove.Attributes.Add("OnClick", "javascript:RemoveItem();return(false);")
            btnDelete.Attributes.Add("OnClick", "javascript:return(AskDeletePatron('" + ddlLabel.Items(3).Text + "'));")
        End Sub

        ' BindData method
        ' Purpose: Load data
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intIDrq As Integer = 0
            Dim intRow As Integer
            objBPatronGroup.LibID = clsSession.GlbSite
            ' Get patron group
            tblTemp = objBPatronGroup.GetPatronGroup

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlPatronGroup.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(2).Text)
                ddlPatronGroup.DataTextField = "Name"
                ddlPatronGroup.DataValueField = "ID"
                ddlPatronGroup.SelectedIndex = 0
                ddlPatronGroup.DataBind()
            Else
                ddlPatronGroup.Items.Add(New ListItem(ddlLabel.Items(2).Text, "0"))
            End If


            ' Get locations of the selected patron group
            objBPatronGroup.LibID = clsSession.GlbSite
            tblTemp = objBPatronGroup.GetLocation

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    lstStore.DataSource = tblTemp
                    lstStore.DataTextField = "Symbol"
                    lstStore.DataValueField = "ID"
                    lstStore.DataBind()
                End If
            End If

            If Request("ID") & "" <> "" Then
                intIDrq = CInt(Request("ID"))
                For intRow = 0 To ddlPatronGroup.Items.Count - 1
                    If CInt(ddlPatronGroup.Items(intRow).Value) = intIDrq Then
                        ddlPatronGroup.SelectedIndex = intRow
                        Exit For
                    End If
                Next
                If ddlPatronGroup.SelectedIndex > 0 Then
                    Call LoadData()
                End If
            End If
        End Sub

        ' Method: ResetForm
        ' Purpose: Clear form's values
        Private Sub ResetForm()
            Dim tblTemp As DataTable

            txtNameGroup.Text = ""
            txtInlibraryQuota.Text = 0
            txtLoanQuota.Text = 0
            txtIllQuota.Text = 0
            txtHoldQuota.Text = 0
            txtHoldTurnTimeOut.Text = 0
            txtPriority.Text = 0
            ddlAccessLevel.SelectedIndex = 0
            ddlPatronGroup.SelectedIndex = 0
            ckbDownLoad.Checked = False
            ' Get location
            objBPatronGroup.LibID = clsSession.GlbSite
            tblTemp = objBPatronGroup.GetLocation

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    lstStore.DataSource = tblTemp
                    lstStore.DataTextField = "Symbol"
                    lstStore.DataValueField = "ID"
                    lstStore.DataBind()
                    lstStoreUsed.Items.Clear()
                    lstStoreUsed.DataBind()
                End If
            End If
        End Sub

        ' Method: LoadData
        Private Sub LoadData()
            Dim dtbPatronGroup As New DataTable
            Dim dtbStoreUsed As New DataTable
            Dim dtbStore As New DataTable
            Dim dtvPatronGroup As New DataView
            Dim intIndex1 As Integer
            Dim intIndex2 As Integer

            If ddlPatronGroup.SelectedIndex > 0 Then
                dtbPatronGroup = objBPatronGroup.GetPatronGroup

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

                objBPatronGroup.LibID = clsSession.GlbSite
                dtbStore = objBPatronGroup.GetLocation

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

                objBPatronGroup.ID = CInt(ddlPatronGroup.SelectedValue)
                objBPatronGroup.LibID = clsSession.GlbSite
                dtbStoreUsed = objBPatronGroup.GetLocationOfGroup

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

                If Not dtbPatronGroup Is Nothing Then

                    Dim isDownLoad As Boolean = False
                    objBPatron.PatronGroupID = CInt(ddlPatronGroup.SelectedValue)
                    Dim intResult As Integer = objBPatron.GetIsDownLoad_ByPatronGroup()
                    isDownLoad = If(intResult = 1, True, False)

                    dtvPatronGroup = dtbPatronGroup.DefaultView()
                    dtvPatronGroup.RowFilter = "id=" & ddlPatronGroup.SelectedValue
                    If dtvPatronGroup.Count > 0 Then
                        txtNameGroup.Text = dtvPatronGroup.Item(0).Item("Name").ToString
                        txtInlibraryQuota.Text = dtvPatronGroup.Item(0).Item("InlibraryQuota").ToString
                        txtLoanQuota.Text = dtvPatronGroup.Item(0).Item("LoanQuota").ToString
                        txtIllQuota.Text = dtvPatronGroup.Item(0).Item("IllQuota").ToString
                        txtHoldQuota.Text = dtvPatronGroup.Item(0).Item("HoldQuota").ToString
                        txtHoldTurnTimeOut.Text = dtvPatronGroup.Item(0).Item("HoldTurnTimeOut").ToString
                        txtPriority.Text = dtvPatronGroup.Item(0).Item("Priority").ToString
                        txtLoanDayPeriod.Text = dtvPatronGroup.Item(0).Item("LoanDayPeriod").ToString()
                        ddlAccessLevel.SelectedIndex = CInt(dtvPatronGroup.Item(0).Item("AccessLevel").ToString)

                        ckbDownLoad.Checked = isDownLoad

                        ' Get data for listbox store used
                        If Not dtbStoreUsed Is Nothing Then
                            lstStoreUsed.DataSource = Nothing
                            lstStoreUsed.DataSource = dtbStoreUsed
                            lstStoreUsed.DataTextField = "Symbol"
                            lstStoreUsed.DataValueField = "LocationID"
                            lstStoreUsed.DataBind()
                        End If

                        ' Get store for listbox store
                        If Not dtbStore Is Nothing Then
                            lstStore.DataSource = Nothing
                            lstStore.DataSource = dtbStore
                            lstStore.DataTextField = "Symbol"
                            lstStore.DataValueField = "ID"
                            lstStore.DataBind()
                        End If

                        For intIndex1 = 0 To lstStoreUsed.Items.Count - 1
                            For intIndex2 = 0 To lstStore.Items.Count - 1
                                If lstStore.Items(intIndex2).Value = lstStoreUsed.Items(intIndex1).Value Then
                                    lstStore.Items.RemoveAt(intIndex2)
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                End If
            Else
                Call ResetForm()
            End If
        End Sub


        ' Event: btnUpdate_Click
        ' Purpose: create/update patron group
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intOut As Integer = 0
            Dim strStoreIDs As String = ""
            Dim intIndex1 As Integer

            strStoreIDs = hidStoreIDs.Value
            If ddlPatronGroup.SelectedIndex = 0 Then ' Add new
                objBPatronGroup.Name = txtNameGroup.Text.Trim
                objBPatronGroup.Priority = txtPriority.Text.Trim
                objBPatronGroup.HoldQuota = txtHoldQuota.Text.Trim
                objBPatronGroup.LoanQuota = txtLoanQuota.Text.Trim
                objBPatronGroup.HoldTurnTimeOut = txtHoldTurnTimeOut.Text.Trim
                objBPatronGroup.InLibraryQuota = txtInlibraryQuota.Text.Trim
                objBPatronGroup.ILLQuota = txtIllQuota.Text.Trim
                objBPatronGroup.StoreIDs = strStoreIDs
                objBPatronGroup.AccessLevel = CInt(ddlAccessLevel.SelectedItem.Value)
                objBPatronGroup.LibID = clsSession.GlbSite
                objBPatronGroup.LoanDayPeriod = CInt(txtLoanDayPeriod.Text)
                intOut = objBPatronGroup.Create()
                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)
                If intOut = -1 Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                    Exit Sub
                End If
            Else ' Update
                objBPatronGroup.ID = CInt(ddlPatronGroup.SelectedValue)
                objBPatronGroup.Name = txtNameGroup.Text.Trim
                objBPatronGroup.Priority = txtPriority.Text.Trim
                objBPatronGroup.HoldQuota = txtHoldQuota.Text.Trim
                objBPatronGroup.LoanQuota = txtLoanQuota.Text.Trim
                objBPatronGroup.HoldTurnTimeOut = txtHoldTurnTimeOut.Text.Trim
                objBPatronGroup.InLibraryQuota = txtInlibraryQuota.Text.Trim
                objBPatronGroup.ILLQuota = txtIllQuota.Text.Trim
                objBPatronGroup.StoreIDs = strStoreIDs
                objBPatronGroup.AccessLevel = CInt(ddlAccessLevel.SelectedItem.Value)
                objBPatronGroup.LoanDayPeriod = CInt(txtLoanDayPeriod.Text)
                intOut = objBPatronGroup.Update()

                ' Check error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)
            End If

            objBPatron.PatronGroupID = CInt(ddlPatronGroup.SelectedValue)
            objBPatron.CreditPatronDownLoadFile(ckbDownLoad.Checked)

            If ddlPatronGroup.SelectedValue <> 0 Then
                Dim intPatronGroupID As Integer
                If intOut = 0 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(6).Text & ": " & txtNameGroup.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & " " & ddlLabel.Items(8).Text & "');</script>")
                    intPatronGroupID = ddlPatronGroup.SelectedIndex
                    Call BindData()
                    ddlPatronGroup.SelectedIndex = intPatronGroupID
                    If ddlPatronGroup.SelectedIndex > 0 Then
                        Call LoadData()
                    End If
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                End If
            Else
                If intOut <> 0 Then
                    ' WriteLog
                    Call WriteLog(118, ddlLabel.Items(11).Text & ": " & txtNameGroup.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    ' Alert message
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & " " & ddlLabel.Items(8).Text & "');</script>")

                    Call BindData()
                    Call ResetForm()
                Else
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                End If
            End If
        End Sub

        ' Event: btnDelete_Click
        ' Purpose: Delete selected patron group
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            objBPatronGroup.ID = CInt(ddlPatronGroup.SelectedValue)
            Dim _Succes As Integer = 0
            _Succes = objBPatronGroup.Delete()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

            ' WriteLog
            Call WriteLog(118, ddlLabel.Items(9).Text & ": " & txtNameGroup.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If _Succes = 0 Then
                ' Alert message
                Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & " " & ddlLabel.Items(13).Text & " " & ddlLabel.Items(8).Text & "');</script>")
            Else
                If _Succes = -1 Then
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('Không thể xóa nhóm bạn đọc khi tồn tại bạn đọc trong nhóm');</script>")
                Else
                    'Delete's Ok
                    Page.RegisterClientScriptBlock("Alert", "<script language='javascript'>alert('" & ddlLabel.Items(7).Text & " " & ddlLabel.Items(8).Text & "');</script>")
                    Call BindData()
                    Call ResetForm()
                End If

            End If
        End Sub

        ' Event: ddlPatronGroup_SelectedIndexChanged
        Private Sub ddlPatronGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPatronGroup.SelectedIndexChanged
            Call LoadData()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronGroup Is Nothing Then
                    objBPatronGroup.Dispose(True)
                    objBPatronGroup = Nothing
                End If

                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace