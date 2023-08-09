' Class: WAddPatron 
' Puspose: Add new patron
' Creator: Tuanhv
' CreatedDate: 19/08/2004
' Modification History:
'   - 17/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.WebUI.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WAddPatron
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
        Private objBPatron As New clsBPatron
        Private objBPatronGroup As New clsBPatronGroup

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not IsPostBack Then
                Call BindDataGrid()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(187) Then
                btnInsert.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all objects
        Private Sub Initialize()
            Response.Expires = 0

            ' Init objBPatron object
            objBPatron.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatron.DBServer = Session("DBServer")
            objBPatron.ConnectionString = Session("ConnectionString")
            objBPatron.Initialize()

            ' Init objBPatronGroup object
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.Initialize()
            If Not Page.IsPostBack Then
                txtValidDate.Text = Session("ToDay")
                txtExpiredDate.Text = Session("ToDay")
            End If
        End Sub

        ' Method: BindScript
        ' Purpose: include all neccessary javascript function
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("CheckNew", "<script language = 'javascript' src = 'Js/WAddPatron.js'></script>")

            txtExpiredDate.Attributes.Add("OnChange", "if (!CheckDate(this, 'dd/mm/yyyy','" & ddlLabel.Items("3").Text & "')) {this.focus(); this.value='';}")
            txtValidDate.Attributes.Add("OnChange", "if (!CheckDate(this, 'dd/mm/yyyy','" & ddlLabel.Items("3").Text & "')) {this.focus(); this.value='';}")

            lnkViewPatronGroup.NavigateUrl = "javascript:OpenWindow('WViewPatronGroup.aspx?PatronGroupID=' + document.forms[0].ddlPatronGroup.options[document.forms[0].ddlPatronGroup.options.selectedIndex].value,'WViewpatronGroup',300,200,100,100);"

            btnInsert.Attributes.Add("onClick", "if(!validatePatronCode(document.forms[0].txtCode)) {alert('so the khong hop le') return false;}; if (!ValidNew('" & ddlLabel.Items("4").Text & "') ) {return false;} else {if (CompareDate(document.forms[0].txtExpiredDate,document.forms[0].txtValidDate,'" & Session("DateFormat") & "')==1){alert('" & ddlLabel.Items(8).Text & "'); return false;}}")
            btnReset.Attributes.Add("OnClick", "Resetform('" & Session("Today") & "'); return false;")
            txtEmail.Attributes.Add("OnChange", "if (!CheckValidEmail(this)) {alert('" & ddlLabel.Items(9).Text & "'); return false;}")
            SetCheckNumber(txtTelephone, ddlLabel.Items(10).Text, "")
        End Sub

        ' Method: BindScript
        ' Purpose: Bind datagrid
        Private Sub BindDataGrid()
            Dim tblTemp As DataTable
            Dim strPatronCode = Trim(Request("PatronCode"))

            ' Write invalid patron message
            If Not strPatronCode = "" Then
                If Request("CheckIn") = "1" Then
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckIn.document.forms[0].txtPatronCode.value='';parent.CheckIn.document.forms[0].txtPatronCode.focus();</script>")
                Else
                    Page.RegisterClientScriptBlock("RefreshJs", "<script language = 'javascript'>parent.CheckOut.document.forms[0].txtPatronCode.value='';parent.CheckOut.document.forms[0].txtPatronCode.focus();</script>")
                End If
                Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(2).Text & ": " & Trim(Request("PatronCode")) & "');</script>")
            End If

            ' Show PatronGroup
            tblTemp = objBPatronGroup.GetPatronGroup()

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatronGroup.ErrorMsg, ddlLabel.Items(0).Text, objBPatronGroup.ErrorCode)

            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlPatronGroup.DataSource = tblTemp
                    ddlPatronGroup.DataTextField = "Name"
                    ddlPatronGroup.DataValueField = "ID"
                    ddlPatronGroup.DataBind()
                    ddlPatronGroup.SelectedIndex = 0
                End If
            End If
        End Sub

        ' Event: btnInsert_Click
        Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
            ' Simple call AddPatron method
            Call AddPatron()
        End Sub

        ' Method: AddPatron
        ' Purpose: Add new patron
        Public Sub AddPatron()
            Dim intRetVal As Integer = 0

            objBPatron.Code = txtCode.Text.Trim
            objBPatron.ValidDate = txtValidDate.Text.Trim
            objBPatron.ExpiredDate = txtExpiredDate.Text.Trim
            objBPatron.FirstName = txtFirstName.Text.Trim
            objBPatron.LastName = txtLastName.Text.Trim
            objBPatron.MiddleName = txtMiddleName.Text.Trim
            objBPatron.PatronGroupID = CInt(Trim(ddlPatronGroup.SelectedValue))
            objBPatron.WorkPlace = txtWorkPlace.Text.Trim
            objBPatron.Telephone = txtTelephone.Text.Trim
            objBPatron.Email = txtEmail.Text.Trim
            intRetVal = objBPatron.Create(1)

            ' Check error
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBPatron.ErrorMsg, ddlLabel.Items(0).Text, objBPatron.ErrorCode)

            ' WriteLog
            Call WriteLog(26, ddlLabel.Items(5).Text & ": " & txtCode.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            If intRetVal > 0 Then
                Page.RegisterClientScriptBlock("Success", "<Script language='JavaScript'>alert('" & ddlLabel.Items(5).Text & " " & ddlLabel.Items(6).Text & "');</Script>")
            Else
                Page.RegisterClientScriptBlock("Fail", "<Script language='JavaScript'>alert('" & ddlLabel.Items(7).Text & "');</Script>")
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
                If Not objBPatron Is Nothing Then
                    objBPatron.Dispose(True)
                    objBPatron = Nothing
                End If
                If Not objBPatronGroup Is Nothing Then
                    objBPatronGroup.Dispose(True)
                    objBPatronGroup = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace