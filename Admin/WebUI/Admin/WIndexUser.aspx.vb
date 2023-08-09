Imports eMicLibAdmin.BusinessRules.Admin
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WIndexUser
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
        Dim objBUser As New clsBUser
        Dim objBRole As New clsBRole

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call GetBasicRights()
                ' Call BindData()
                ddlCatalogue.SelectedIndex = 1
                If Not Session("UserID") = 1 Then
                    Call LimitUserRole()
                End If
                hidParentIDTemp.Value = Session("UserID")
                If objSysPara(0) = 1 Then
                    TRLDAP.Visible = True
                    txtUserName.ReadOnly = True
                    txtPassword.Enabled = False
                    txtRetypePass.Enabled = False
                Else
                    TRLDAP.Visible = False
                End If
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(199) And Not CheckPemission(200) And Not CheckPemission(201) And Not CheckPemission(202) And Not CheckPemission(203) And Not CheckPemission(204) And Not CheckPemission(205) And Not CheckPemission(238) Then
                Call WriteErrorMssg(ddlLabel.Items(13).Text)
            Else
                ' Catalogue module
                If Not CheckPemission(199) Then
                    ddlCatalogue.SelectedIndex = 0
                    ddlCatalogue.Enabled = False
                    lnkCatalogue.Visible = False
                End If
                ' Patron module
                If Not CheckPemission(200) Then
                    ddlPatron.Enabled = False
                    lnkPatron.Visible = False
                End If
                ' Circulation module
                If Not CheckPemission(201) Then
                    ddlCirculation.Enabled = False
                    lnkCirculation.Visible = False
                End If
                ' Acq module
                If Not CheckPemission(202) Then
                    ddlAcq.Enabled = False
                    lnkAcq.Visible = False
                End If
                ' Serial module
                If Not CheckPemission(203) Then
                    ddlSerial.Enabled = False
                    lnkSerial.Visible = False
                End If
                ' ILL module
                If Not CheckPemission(204) Then
                    ddlILL.Enabled = False
                    lnkILL.Visible = False
                End If
                ' Edeliv module
                If Not CheckPemission(205) Then
                    ddlEdeliv.Enabled = False
                    lnkEdeliv.Visible = False
                End If
                ' Admin module
                If Not Session("UserID") = 1 And Not CheckPemission(238) Then
                    lblAdmin.Visible = False
                    ddlAdmin.Visible = False
                    lnkAdmin.Visible = False
                End If
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            objBUser.InterfaceLanguage = Session("InterfaceLanguage")
            objBUser.DBServer = Session("DBServer")
            objBUser.ConnectionString = Session("ConnectionString")
            objBUser.Initialize()

            objBRole.InterfaceLanguage = Session("InterfaceLanguage")
            objBRole.DBServer = Session("DBServer")
            objBRole.ConnectionString = Session("ConnectionString")
            objBRole.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Dim strJSConfirm As String = ""
            Dim strJSCheckDel As String = ""
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'Js/WIndexUser.js'></script>")

            lnkCatalogue.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=1&Dest=opener.document.forms[0].hidRights','ModuleRights',700, 250, 50,50)"

            lnkPersonal.NavigateUrl = "javascript:OpenWindow('WChangePersonalInfo.aspx','ChangeInfo',500, 250,50,50)"

            lnkPatron.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=2&Dest=opener.document.forms[0].hidRights','ModuleRights',700, 250, 50,50)"
            lnkCirculation.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=3&Dest=opener.document.forms[0].hidRights&LocDest=opener.document.forms[0].hidCirRights','ModuleRights',700, 400, 50,50)"
            lnkAcq.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=4&Dest=opener.document.forms[0].hidRights&LocDest=opener.document.forms[0].hidAcqRights','ModuleRights',700, 400, 50,50)"
            lnkSerial.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=5&Dest=opener.document.forms[0].hidRights&LocDest=opener.document.forms[0].hidSerRights','ModuleRights',700, 400, 50,50)"
            lnkILL.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=8&Dest=opener.document.forms[0].hidRights&LocDest=opener.document.forms[0].hidLocRights','ModuleRights',700, 250, 50,50)"
            lnkEdeliv.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=9&Dest=opener.document.forms[0].hidRights&LocDest=opener.document.forms[0].hidLocRights','ModuleRights',700, 250, 50,50)"
            lnkAdmin.NavigateUrl = "javascript:OpenWindow('WShowRoleOfModule.aspx?ModuleID=6&Dest=opener.document.forms[0].hidRights','ModuleRights',700, 250, 50,50)"
            lnkLoadLDAP.NavigateUrl = "javascript:if (document.forms[0].hidUpdate.value!='1'){OpenWindow('WLDAPUsers.aspx','LDAPUser',700, 350, 50,50);}"

            btnReset.Attributes.Add("OnClick", "javascript:document.forms[0].reset();TRAdmin.style.display = """";return false;")
            btnAdd.Attributes.Add("OnClick", "javascript:return CheckAllInput('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(11).Text & "');")

            strJSConfirm = "return ConfirmDelete('" & ddlLabel.Items(6).Text & "');"
            strJSCheckDel = "if(!CheckOptionsNullByCssClass('ckb-value', 'chkID', 3, 15, '" & ddlLabel.Items(8).Text & "')) return false;"
            btnDelete.Attributes.Add("onClick", strJSCheckDel & " else " & strJSConfirm)
        End Sub

        ' GetBasicRights method
        ' Purpose: Get the basic rights of an user (for add new user)
        Private Sub GetBasicRights()
            ' Declare varables
            Dim intIndex As Integer
            Dim tblRights As DataTable

            ' Get rights
            objBRole.ModuleID = 0
            objBRole.UID = 0
            If Session("UserID") <> 1 Then
                objBRole.ParentID = Session("UserID")
            End If
            tblRights = objBRole.GetRights
            If Not tblRights Is Nothing Then
                If tblRights.Rows.Count > 0 Then
                    For intIndex = 0 To tblRights.Rows.Count - 1
                        hidRights.Value = hidRights.Value & tblRights.Rows(intIndex).Item(0) & ","
                    Next
                End If
            End If

        End Sub

        ' BindData method
        Private Sub BindData()
            ' Declare variables
            Dim tblUser As DataTable
            Dim dtgItem As DataGridItem
            Dim chkSelected As CheckBox
            Dim strUser As String
            Dim intItem As Integer
            Dim intCount As Integer

            objBUser.UID = 0
            objBUser.ParentID = Session("UserID")

            tblUser = objBUser.GetUsers
            ' get all user
            btnDelete.Visible = False
            lblNote2.Visible = False
            dgtUser.Visible = False

            If Not tblUser Is Nothing Then
                If tblUser.Rows.Count > 0 Then
                    intCount = CInt(tblUser.Rows.Count / dgtUser.PageSize)
                    intItem = intCount * dgtUser.PageSize
                    If intItem = tblUser.Rows.Count Then
                        If dgtUser.CurrentPageIndex > intCount - 1 Then
                            dgtUser.CurrentPageIndex = dgtUser.CurrentPageIndex - 1
                        End If
                    End If

                    dgtUser.DataSource = tblUser
                    'dgtUser.DataBind()

                    dgtUser.Visible = True
                    btnDelete.Visible = True
                    lblNote2.Visible = True
                End If
            End If
        End Sub

        ' btnAdd_Click event
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Select Case hidUpdate.Value
                Case "0"
                    AddNewUser()
                Case "1"
                    UpdateUser()
            End Select
            'Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(14).Text & "');</script>")
        End Sub

        ' AddNewUser method
        ' Purpose: Check the distinct of username and add new user
        Private Sub AddNewUser()
            ' Declare variables
            Dim strFullName As String
            Dim strUserName As String
            Dim strPassword As String
            Dim strCirRights As String
            Dim strAcqRights As String
            Dim strSerRights As String
            Dim strRights As String
            Dim intDupplicateUsers As Integer = 0
            Dim intNewUser As Integer
            Dim inti As Integer = 0
            Dim intIndex As Integer = 0
            Dim strTemp As String = ""
            Dim arrCirRights() As String
            Dim arrAcqRights() As String
            Dim arrSerRights() As String
            Dim intIsLDAP As Integer = 0

            ' Get the user infor from the interface
            strFullName = txtFullName.Text
            strUserName = Trim(txtUserName.Text)
            strPassword = Trim(txtPassword.Text)
            strCirRights = Trim(hidCirRights.Value)
            strAcqRights = Trim(hidAcqRights.Value)
            strSerRights = Trim(hidSerRights.Value)
            strRights = Trim(hidRights.Value)

            objBUser.FullName = strFullName
            objBUser.UserName = strUserName
            objBUser.UserPass = strPassword
            objBUser.CatModule = CInt(ddlCatalogue.SelectedValue)
            objBUser.PatModule = CInt(ddlPatron.SelectedValue)
            objBUser.CirModule = CInt(ddlCirculation.SelectedValue)
            objBUser.AcqModule = CInt(ddlAcq.SelectedValue)
            objBUser.SerModule = CInt(ddlSerial.SelectedValue)
            objBUser.ILLModule = CInt(ddlILL.SelectedValue)
            objBUser.DelModule = CInt(ddlEdeliv.SelectedValue)
            objBUser.AdmModule = CInt(ddlAdmin.SelectedValue)
            objBUser.LDAPAdsPath = hidLDAPAdsPath.Value
            objBUser.ParentID = Session("UserID")
            objBUser.LibID = clsSession.GlbSite

            If objSysPara(0) = 1 Then
                intIsLDAP = 1
                objBUser.UserPass = ""
            Else
                intIsLDAP = 0
            End If

            intDupplicateUsers = objBUser.AddUser(intNewUser, intIsLDAP)
            ' Check the existing of username
            If intDupplicateUsers <> 0 Then
                Page.RegisterClientScriptBlock("DupplicateUser", "<script language='javascript'> alert('" & ddlLabel.Items(5).Text & "');</script>")
                btnReset.Visible = False
                Exit Sub
            Else
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(14).Text & "');</script>")
                ' Grant rights
                If Trim(strRights) <> "" Then
                    Do While Len(strRights) <> 0
                        inti = InStr(strRights, ",")
                        If inti > 0 Then
                            strTemp = Left(strRights, inti - 1)
                            strRights = Right(strRights, Len(strRights) - inti)
                        Else
                            strTemp = strRights
                            strRights = ""
                        End If
                        objBUser.UID = intNewUser
                        objBUser.RightID = CInt(strTemp)
                        objBUser.GrantRights()
                    Loop
                End If
                ' Grant location rights
                If Trim(strCirRights) <> "" Then
                    arrCirRights = Split(strCirRights, ",")
                    For intIndex = 0 To arrCirRights.Length - 2
                        objBUser.UserID = intNewUser
                        objBUser.LocationID = CInt(arrCirRights(intIndex))
                        objBUser.GrantLocation(1)
                    Next
                End If
                If Trim(strAcqRights) <> "" Then
                    arrAcqRights = Split(strAcqRights, ",")
                    For intIndex = 0 To arrAcqRights.Length - 2
                        objBUser.UserID = intNewUser
                        objBUser.LocationID = CInt(arrAcqRights(intIndex))
                        objBUser.GrantLocation(2)
                    Next
                End If
                If Trim(strSerRights) <> "" Then
                    arrSerRights = Split(strSerRights, ",")
                    For intIndex = 0 To arrSerRights.Length - 2
                        objBUser.UserID = intNewUser
                        objBUser.LocationID = CInt(arrSerRights(intIndex))
                        objBUser.GrantLocation(3)
                    Next
                End If
                If Session("UserID") <> 1 Then
                    ' Write log
                    WriteLog(117, ddlLabel.Items(9).Text & "(UserName: " & txtUserName.Text & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                End If
            End If
            Call BindData()
            Call ResetValues()
            btnReset.Visible = True
        End Sub

        ' UpdateUser method
        ' Purpose: Check the distinct of username and update user
        Private Sub UpdateUser()
            ' Declare variables
            Dim intUID As Integer
            Dim strFullName As String
            Dim strUserName As String
            Dim strPassword As String
            Dim strCirRights As String
            Dim strAcqRights As String
            Dim strSerRights As String
            Dim strRights As String
            Dim intDupplicateUsers As Integer = 0
            Dim inti As Integer = 0
            Dim intIndex As Integer = 0
            Dim strTemp As String = ""
            Dim arrCirRights() As String
            Dim arrAcqRights() As String
            Dim arrSerRights() As String
            Dim intIsLDAP As Integer = 0

            ' Get the user infor from the interface
            intUID = hidUserID.Value
            strFullName = txtFullName.Text
            strUserName = Trim(txtUserName.Text)
            strPassword = Trim(txtPassword.Text)
            strCirRights = Trim(hidCirRights.Value)
            strAcqRights = Trim(hidAcqRights.Value)
            strSerRights = Trim(hidSerRights.Value)
            strRights = Trim(hidRights.Value)

            objBUser.UID = intUID
            objBUser.FullName = strFullName
            objBUser.UserName = strUserName
            objBUser.UserPass = strPassword
            objBUser.CatModule = CInt(ddlCatalogue.SelectedValue)
            objBUser.PatModule = CInt(ddlPatron.SelectedValue)
            objBUser.CirModule = CInt(ddlCirculation.SelectedValue)
            objBUser.AcqModule = CInt(ddlAcq.SelectedValue)
            objBUser.SerModule = CInt(ddlSerial.SelectedValue)
            objBUser.ILLModule = CInt(ddlILL.SelectedValue)
            objBUser.DelModule = CInt(ddlEdeliv.SelectedValue)
            objBUser.AdmModule = CInt(ddlAdmin.SelectedValue)
            objBUser.ParentID = Session("UserID")

            If objSysPara(0) = 1 Then
                intIsLDAP = 1
                objBUser.UserPass = ""
            Else
                intIsLDAP = 0
            End If

            intDupplicateUsers = objBUser.UpdateUser(intIsLDAP)
            ' Check the existing of username
            If intDupplicateUsers <> 0 Then
                Page.RegisterClientScriptBlock("DupplicateUser", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "'); </script>")
                btnReset.Visible = False
                Exit Sub
            Else
                Page.RegisterClientScriptBlock("JSSucc", "<script language='javascript'>alert('" & ddlLabel.Items(14).Text & "');</script>")
                ' Grant rights
                If Trim(strRights) <> "" Then
                    Do While Len(strRights) <> 0
                        inti = InStr(strRights, ",")
                        If inti > 0 Then
                            strTemp = Left(strRights, inti - 1)
                            strRights = Right(strRights, Len(strRights) - inti)
                        Else
                            strTemp = strRights
                            strRights = ""
                        End If
                        objBUser.UID = CInt(hidUserID.Value)
                        objBUser.RightID = CInt(strTemp)
                        objBUser.GrantRights()
                    Loop
                End If
                ' Grant location rights
                If Trim(strCirRights) <> "" Then
                    arrCirRights = Split(strCirRights, ",")
                    For intIndex = 0 To arrCirRights.Length - 2
                        objBUser.UserID = intUID
                        objBUser.LocationID = CInt(arrCirRights(intIndex))
                        objBUser.GrantLocation(1)
                    Next
                End If
                If Trim(strAcqRights) <> "" Then
                    arrAcqRights = Split(strAcqRights, ",")
                    For intIndex = 0 To arrAcqRights.Length - 2
                        objBUser.UserID = intUID
                        objBUser.LocationID = CInt(arrAcqRights(intIndex))
                        objBUser.GrantLocation(2)
                    Next
                End If
                If Trim(strSerRights) <> "" Then
                    arrSerRights = Split(strSerRights, ",")
                    For intIndex = 0 To arrSerRights.Length - 2
                        objBUser.UserID = intUID
                        objBUser.LocationID = CInt(arrSerRights(intIndex))
                        objBUser.GrantLocation(3)
                    Next
                End If
                If Session("UserID") <> 1 Then
                    ' Write log
                    WriteLog(117, ddlLabel.Items(10).Text & "(UserName: " & txtUserName.Text & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
                End If
            End If
            Call BindData()
            Call ResetValues()
            btnReset.Visible = True
        End Sub

        ' btnDelete_Click event
        ' Purpose: Delete user(s)
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim dtgItem As GridDataItem
            Dim chkSelected As HtmlInputCheckBox
            Dim strSelectedIDs As String

            ' Return the IDs string for deletting
            For Each dtgItem In dgtUser.Items
                chkSelected = dtgItem.FindControl("chkID")
                If chkSelected.Checked = True Then
                    strSelectedIDs = strSelectedIDs & CType(dtgItem.FindControl("lblID"), Label).Text & ","
                End If
            Next

            ' If checked, delete
            If strSelectedIDs <> "" Then
                strSelectedIDs = Left(strSelectedIDs, strSelectedIDs.Length - 1)
                objBUser.UIDs = strSelectedIDs
                objBUser.DeleteUser()
                ' Write log
                WriteLog(117, ddlLabel.Items(12).Text & "(UserIDs: " & strSelectedIDs & ")", Request.ServerVariables("SCRIPT_NAME"), CStr(Request.ServerVariables("Remote_Addr")), clsSession.GlbUserFullName)
            End If
            Call BindData()
            Call ResetValues()
            dgtUser.Rebind()
        End Sub

        'dgtUser_ItemCreated event
        'Private Sub dgtUser_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgtUser.ItemCreated
        '    Select Case e.Item.ItemType
        '        Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
        '            Dim tblCell As TableCell
        '            Dim tblCell1 As TableCell
        '            Dim inti As Integer

        '            'Dim chk As CheckBox
        '            Dim lnk As HyperLink
        '            Dim chk As CheckBox

        '            tblCell = e.Item.Cells(1)
        '            tblCell1 = e.Item.Cells(0)
        '            chk = CType(tblCell1.FindControl("chkID"), CheckBox)
        '            lnk = CType(tblCell.FindControl("lnkUser"), HyperLink)

        '            lnk.Target = "Hiddenbase"

        '            If DataBinder.Eval(e.Item.DataItem, "ID") = 1 Then
        '                chk.Visible = False
        '            Else
        '                If DataBinder.Eval(e.Item.DataItem, "Nor") > 0 Then
        '                    'chk.Visible = False
        '                    e.Item.BackColor = Color.FromName("#95b9c7")
        '                End If
        '            End If

        '            If DataBinder.Eval(e.Item.DataItem, "ID") = 1 Then
        '                'lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href = 'WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';"
        '                'lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = ""none"";")
        '                lnk.NavigateUrl = "WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID")
        '                'lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = ""none"";")
        '            Else
        '                'lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href = 'WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';"
        '                ' lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = """";")
        '                lnk.NavigateUrl = "WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID")
        '                'lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = """";")
        '            End If

        '            For inti = 1 To e.Item.Cells.Count - 1
        '                e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dgtUser','chkID'," & e.Item.ItemIndex + 3 & ");")
        '            Next

        '    End Select
        'End Sub

        ' dgtUser_PageIndexChanged event

        'Private Sub dgtUser_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgtUser.PageIndexChanged
        '    dgtUser.CurrentPageIndex = e.NewPageIndex
        '    Call BindData()
        '    Call ResetValues()
        'End Sub

        'ResetValues method
        Private Sub ResetValues()
            hidRights.Value = ""
            Call GetBasicRights()
            ddlCatalogue.SelectedIndex = 1
            hidAcqRights.Value = ""
            hidCirRights.Value = ""
            hidSerRights.Value = ""
            hidUserID.Value = 0
            hidParentID.Value = "1"
            hidUpdate.Value = 0
            hidLDAPAdsPath.Value = ""
            txtFullName.Text = ""
            txtUserName.Text = ""
            txtPassword.Text = ""
            txtRetypePass.Text = ""
            ddlAcq.SelectedIndex = 0
            'ddlCatalogue.SelectedIndex = 1
            ddlCatalogue.SelectedIndex = 0
            ddlCirculation.SelectedIndex = 0
            ddlSerial.SelectedIndex = 0
            ddlEdeliv.SelectedIndex = 0
            ddlILL.SelectedIndex = 0
            ddlPatron.SelectedIndex = 0
            ddlAdmin.SelectedIndex = 0
        End Sub

        ' Limit user role method
        ' Purpose: Limit the second admin user role
        Private Sub LimitUserRole()
            Dim tblUser As DataTable
            Dim intUserID As Integer = 0
            Dim strName As String = ""
            Dim strUserName As String = ""
            Dim intCatModule As Int16 = 0
            Dim intIndex As Integer = 0
            Dim lstItem As ListItem

            intUserID = Session("UserID")

            If intUserID > 0 Then
                objBUser.UID = intUserID
                tblUser = objBUser.GetUsers
                If Not tblUser Is Nothing Then
                    If tblUser.Rows.Count > 0 Then
                        ' Acquisition rights
                        If CInt(tblUser.Rows(0).Item("AcqModule")) = 0 Then
                            ddlAcq.Items.Clear()
                            lstItem = New ListItem
                            lstItem.Text = "0"
                            lstItem.Value = 0
                            ddlAcq.Items.Add(lstItem)
                        End If

                        ' Serial rights
                        If CInt(tblUser.Rows(0).Item("SerModule")) = 0 Then
                            ddlSerial.Items.Clear()
                            lstItem = New ListItem
                            lstItem.Text = "0"
                            lstItem.Value = 0
                            ddlSerial.Items.Add(lstItem)
                        End If

                        ' Circulation rights
                        If CInt(tblUser.Rows(0).Item("CirModule")) = 0 Then
                            ddlCirculation.Items.Clear()
                            lstItem = New ListItem
                            lstItem.Text = "0"
                            lstItem.Value = 0
                            ddlCirculation.Items.Add(lstItem)
                        End If

                        ' Patron rights
                        If CInt(tblUser.Rows(0).Item("PatModule")) = 0 Then
                            ddlPatron.Items.Clear()
                            lstItem = New ListItem
                            lstItem.Text = "0"
                            lstItem.Value = 0
                            ddlPatron.Items.Add(lstItem)
                        End If

                        ' Catalogue rights
                        intCatModule = tblUser.Rows(0).Item("Priority").ToString
                        Select Case intCatModule
                            Case 0
                                ddlCatalogue.Items.Clear()
                                lstItem = New ListItem
                                lstItem.Text = "0"
                                lstItem.Value = 0
                                ddlCatalogue.Items.Add(lstItem)
                            Case 1
                                ddlCatalogue.Items.Clear()
                                For intIndex = 0 To 1
                                    lstItem = New ListItem
                                    lstItem.Text = CStr(intIndex)
                                    lstItem.Value = intIndex
                                    ddlCatalogue.Items.Add(lstItem)
                                Next
                                If Not CheckPemission(199) Then
                                    ddlCatalogue.SelectedIndex = 0
                                Else
                                    ddlCatalogue.SelectedIndex = 1
                                End If
                        End Select

                        ' ILL rights
                        If CInt(tblUser.Rows(0).Item("ILLModule")) = 0 Then
                            ddlILL.Items.Clear()
                            lstItem = New ListItem
                            lstItem.Text = "0"
                            lstItem.Value = 0
                            ddlILL.Items.Add(lstItem)
                        End If

                        ' Delivery rights
                        If CInt(tblUser.Rows(0).Item("DELModule")) = 0 Then
                            ddlEdeliv.Items.Clear()
                            lstItem = New ListItem
                            lstItem.Text = "0"
                            lstItem.Value = 0
                            ddlEdeliv.Items.Add(lstItem)
                        End If
                    End If
                End If
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
                If Not objBRole Is Nothing Then
                    objBRole.Dispose(True)
                    objBRole = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        Protected Sub dgtUser_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dgtUser.NeedDataSource
            ' Declare variables
            Dim tblUser As DataTable
            Dim dtgItem As DataGridItem
            Dim chkSelected As CheckBox
            Dim strUser As String
            Dim intItem As Integer
            Dim intCount As Integer

            objBUser.UID = 0
            objBUser.ParentID = Session("UserID")

            tblUser = objBUser.GetUsers
            ' get all user
            btnDelete.Visible = False
            lblNote2.Visible = False
            dgtUser.Visible = False

            If Not tblUser Is Nothing Then
                If tblUser.Rows.Count > 0 Then
                    intCount = CInt(tblUser.Rows.Count / dgtUser.PageSize)
                    intItem = intCount * dgtUser.PageSize
                    If intItem = tblUser.Rows.Count Then
                        If dgtUser.CurrentPageIndex > intCount - 1 Then
                            dgtUser.CurrentPageIndex = dgtUser.CurrentPageIndex - 1
                        End If
                    End If

                    dgtUser.DataSource = tblUser
                    'dgtUser.DataBind()

                    dgtUser.Visible = True
                    btnDelete.Visible = True
                    lblNote2.Visible = True
                End If
            End If
        End Sub

        Protected Sub dgtUser_ItemCreated(sender As Object, e As GridItemEventArgs) Handles dgtUser.ItemCreated

            Select Case e.Item.ItemType
                Case GridItemType.Item, GridItemType.AlternatingItem, GridItemType.EditItem
                    Dim tblCell As TableCell
                    Dim tblCell1 As TableCell
                    Dim inti As Integer

                    'Dim chk As CheckBox
                    Dim lnk As HyperLink
                    Dim chk As HtmlInputCheckBox


                    Dim item As GridDataItem
                    item = e.Item
                    Dim LinkButton1 As HtmlInputCheckBox
                    LinkButton1 = item("cbCheckAll").FindControl("chkID")

                    tblCell = e.Item.Cells(1)
                    tblCell1 = e.Item.Cells(0)
                    chk = CType(tblCell1.FindControl("chkID"), HtmlInputCheckBox)
                    lnk = CType(tblCell.FindControl("lnkUser"), HyperLink)

                    If Not chk Is Nothing Then
                        If DataBinder.Eval(e.Item.DataItem, "ID") = 1 Then
                            chk.Visible = False
                        Else
                            If DataBinder.Eval(e.Item.DataItem, "Nor") > 0 Then
                                'chk.Visible = False
                                e.Item.BackColor = Color.FromName("#95b9c7")
                            End If
                        End If
                    End If

                    If Not lnk Is Nothing Then
                        lnk.Target = "Hiddenbase"

                        If DataBinder.Eval(e.Item.DataItem, "ID") = 1 Then
                            'lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href = 'WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';"
                            'lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = ""none"";")
                            lnk.NavigateUrl = "WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID")
                            'lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = ""none"";")
                        Else
                            'lnk.NavigateUrl = "javascript:parent.Hiddenbase.location.href = 'WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';"
                            ' lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = """";")
                            lnk.NavigateUrl = "WUserMan.aspx?UserID=" & DataBinder.Eval(e.Item.DataItem, "ID")
                            'lnk.Attributes.Add("OnClick", "javascript:if (eval(document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID)) {document.forms[0].dgtUser__ctl" & e.Item.ItemIndex + 3 & "_chkID.checked='false';}TRAdmin.style.display = """";")
                        End If
                    End If
                    'For inti = 1 To e.Item.Cells.Count - 1
                    '    e.Item.Cells(inti).Attributes.Add("onClick", "javascript:CheckOptionVisible('dgtUser','chkID'," & e.Item.ItemIndex + 3 & ");")
                    'Next

            End Select
        End Sub
    End Class
End Namespace