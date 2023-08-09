' Class: WOverdueSendMail
' Puspose: Send Mail to Overdue Patron
' Creator: Sondp
' CreatedDate: 31/8/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOrverdueSendMail
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblOverduePrintLetter As System.Web.UI.WebControls.Label
        Protected WithEvents lnkOverdueSendEmail As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
        Protected WithEvents lblSelectPatron As System.Web.UI.WebControls.Label
        Protected WithEvents lblSelectTemplate As System.Web.UI.WebControls.Label
        Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBOverdueTransaction As New clsBOverdueTransaction
        Private objBOverdueTemplate As New clsBOverdueTemplate
        Private objBPatronGroup As New clsBPatronGroup

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()

            Dim tmpscriptManager As New ScriptManager
            tmpscriptManager = ScriptManager.GetCurrent(Me.Page)

            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Checkpermission
        Private Sub CheckFormPermission()
            If Not CheckPemission(61) Then
                btnPrint.Enabled = False
            End If
        End Sub

        ' Method: Initialize
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBOverdueTemplate object
            objBOverdueTemplate.ConnectionString = Session("ConnectionString")
            objBOverdueTemplate.DBServer = Session("DBServer")
            objBOverdueTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTemplate.Initialize()

            ' Init objBOverdueTransaction
            objBOverdueTransaction.ConnectionString = Session("ConnectionString")
            objBOverdueTransaction.DBServer = Session("DBServer")
            objBOverdueTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTransaction.Initialize()

            ' Init objBOverdueTransaction
            objBPatronGroup.ConnectionString = Session("ConnectionString")
            objBPatronGroup.DBServer = Session("DBServer")
            objBPatronGroup.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPatronGroup.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: include all necessary objects
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("RegisterActionPrintLetterJs", "<script language='javascript' src='../Js/Overdue/WOrverdueSendMail.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            ' Controls action
            rbAllPatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbSelectPatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=0;document.forms[0].txtOverduePrintMode.value=0;")
            rbOverduePatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbSelectPatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=0;document.forms[0].txtOverduePrintMode.value=1;")
            rbSelectPatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=0;document.forms[0].txtOverduePrintMode.value=2;")
            rbOverduePatronGroup.Attributes.Add("OnClick", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbSelectPatron.checked=0;document.forms[0].txtOverduePrintMode.value=3;")

            txtFullName.Attributes.Add("onmousedown", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=0;document.forms[0].rbSelectPatron.checked=1;document.forms[0].txtOverduePrintMode.value=2;")
            ddlPatronGroup.Attributes.Add("onmousedown", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=0;document.forms[0].rbSelectPatron.checked=1;document.forms[0].txtOverduePrintMode.value=2;")
            ddlOverduePatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbOverduePatron.checked=1;document.forms[0].rbAllPatron.checked=0;document.forms[0].rbSelectPatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=0;return false;")
            CheckBoxListPatronGroup.Attributes.Add("OnClick", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbSelectPatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=1;document.forms[0].txtOverduePrintMode.value=3;")
            lsbAllOverduePatron.Attributes.Add("onmousedown", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbOverduePatronGroup.checked=0;document.forms[0].rbSelectPatron.checked=1;document.forms[0].txtOverduePrintMode.value=2;")

            txtOverduePatron.Attributes.Add("OnChange", "javascript:if (!CheckNum(this)) {alert('" & ddlLabel.Items(5).Text & "'); this.value=1; this.focus();} else {document.forms[0].rbOverduePatron.checked=1;document.forms[0].rbAllPatron.checked=0;document.forms[0].rbSelectPatron.checked=0;}")

            btnAdd.Attributes.Add("OnClick", "javascript:AddItem(); return false;")
            btnRemove.Attributes.Add("OnClick", "javascript:RemoveItem(); return false;")
            btnPrint.Attributes.Add("OnClick", "javascript:return(SendMail('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "'));")
            btnReset.Attributes.Add("OnClick", "javascript:ResetForm(); return false;")
        End Sub

        ' Method: BindData
        ' Purpose: Bind Data for first time display
        Private Sub BindData()
            Dim tblTemplate As DataTable
            Dim tblOverduePatrons As DataTable
            Dim dvOverduePatron As New DataView
            Dim tblPatronGroup As DataTable
            Dim Item As New ListItem

            ' BindData for ddlPatronGroup
            tblPatronGroup = objBPatronGroup.GetPatronGroup()
            If Not tblPatronGroup Is Nothing AndAlso tblPatronGroup.Rows.Count > 0 Then
                ddlPatronGroup.DataSource = InsertOneRow(tblPatronGroup, ddlLabel.Items(6).Text)
                ddlPatronGroup.DataTextField = "Name"
                ddlPatronGroup.DataValueField = "ID"
                ddlPatronGroup.DataBind()

                CheckBoxListPatronGroup.DataSource = tblPatronGroup
                CheckBoxListPatronGroup.DataBind()
            Else
                ddlPatronGroup = Nothing
                ddlPatronGroup.DataBind()
            End If

            ' Bind data to dropdownlist Overdue Template
            objBOverdueTemplate.TemplateID = 0
            objBOverdueTemplate.TemplateType = 2
            tblTemplate = objBOverdueTemplate.GetTemplate
            If Not tblTemplate Is Nothing Then
                If tblTemplate.Rows.Count > 0 Then
                    tblTemplate = InsertOneRow(tblTemplate, ddlLabel.Items(2).Text)
                    ddlOverdueTemplate.DataSource = tblTemplate
                    ddlOverdueTemplate.DataTextField = "Title"
                    ddlOverdueTemplate.DataValueField = "ID"
                    ddlOverdueTemplate.DataBind()
                End If
                tblTemplate = Nothing
            End If

            ' Bind data to listbox Overdue Patrons
            objBOverdueTransaction.SelectMode = "ALL"
            objBOverdueTransaction.Logic = ""
            objBOverdueTransaction.DueTime = 0
            objBOverdueTransaction.PatronIDs = ""
            tblOverduePatrons = objBOverdueTransaction.GetOverduePatron(txtFullName.Text, ddlPatronGroup.SelectedValue)
            If Not tblOverduePatrons Is Nothing Then
                If tblOverduePatrons.Rows.Count > 0 Then
                    dvOverduePatron = tblOverduePatrons.DefaultView
                    dvOverduePatron.RowFilter = "Email LIKE '%@%'"
                    If Not IsDBNull(dvOverduePatron) Then
                        If dvOverduePatron.Count > 0 Then
                            lsbAllOverduePatron.DataSource = dvOverduePatron
                            lsbAllOverduePatron.DataValueField = "ID"
                            lsbAllOverduePatron.DataTextField = "Name"
                            lsbAllOverduePatron.DataBind()
                        Else
                            'Item.Text = "            "
                            'Item.Value = 0
                            'lsbAllOverduePatron.Items.Add(Item)
                            lsbAllOverduePatron.Items.Clear()
                            lsbAllOverduePatron.DataSource = Nothing
                            lsbAllOverduePatron.DataBind()
                        End If
                    Else
                        'Item.Text = "          "
                        'Item.Value = 0
                        'lsbAllOverduePatron.Items.Add(Item)
                        lsbAllOverduePatron.Items.Clear()
                        lsbAllOverduePatron.DataSource = Nothing
                        lsbAllOverduePatron.DataBind()
                    End If
                Else
                    lsbAllOverduePatron.Items.Clear()
                    lsbAllOverduePatron.DataSource = Nothing
                    lsbAllOverduePatron.DataBind()
                End If
            Else
                lsbAllOverduePatron.Items.Clear()
                lsbAllOverduePatron.DataSource = Nothing
                lsbAllOverduePatron.DataBind()
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOverdueTemplate Is Nothing Then
                    objBOverdueTemplate.Dispose(True)
                    objBOverdueTemplate = Nothing
                End If
                If Not objBOverdueTransaction Is Nothing Then
                    objBOverdueTransaction.Dispose(True)
                    objBOverdueTransaction = Nothing
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
        Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
            ' Bind data to listbox Overdue Patrons
            Dim dvOverduePatron As New DataView
            Dim Item As New ListItem
            objBOverdueTransaction.SelectMode = "ALL"
            objBOverdueTransaction.Logic = ""
            objBOverdueTransaction.DueTime = 0
            objBOverdueTransaction.PatronIDs = ""
            Dim tblOverduePatrons As DataTable = objBOverdueTransaction.GetOverduePatron(txtFullName.Text, ddlPatronGroup.SelectedValue)
            If Not tblOverduePatrons Is Nothing Then
                If tblOverduePatrons.Rows.Count > 0 Then
                    dvOverduePatron = tblOverduePatrons.DefaultView
                    dvOverduePatron.RowFilter = "Email LIKE '%@%'"
                    If Not IsDBNull(dvOverduePatron) Then
                        If dvOverduePatron.Count > 0 Then
                            lsbAllOverduePatron.DataSource = dvOverduePatron
                            lsbAllOverduePatron.DataValueField = "ID"
                            lsbAllOverduePatron.DataTextField = "Name"
                            lsbAllOverduePatron.DataBind()
                        Else
                            'Item.Text = "            "
                            'Item.Value = 0
                            'lsbAllOverduePatron.Items.Add(Item)
                            lsbAllOverduePatron.Items.Clear()
                            lsbAllOverduePatron.DataSource = Nothing
                            lsbAllOverduePatron.DataBind()
                        End If
                    Else
                        'Item.Text = "          "
                        'Item.Value = 0
                        'lsbAllOverduePatron.Items.Add(Item)
                        lsbAllOverduePatron.Items.Clear()
                        lsbAllOverduePatron.DataSource = Nothing
                        lsbAllOverduePatron.DataBind()
                    End If
                Else
                    lsbAllOverduePatron.Items.Clear()
                    lsbAllOverduePatron.DataSource = Nothing
                    lsbAllOverduePatron.DataBind()
                End If
            Else
                lsbAllOverduePatron.Items.Clear()
                lsbAllOverduePatron.DataSource = Nothing
                lsbAllOverduePatron.DataBind()
            End If
        End Sub

        Protected Sub CheckBoxListPatronGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckBoxListPatronGroup.SelectedIndexChanged
            hidCheckedPatronGroup.Value = ""
            For i As Integer = 0 To CheckBoxListPatronGroup.Items.Count - 1
                If CheckBoxListPatronGroup.Items(i).Selected Then
                    If hidCheckedPatronGroup.Value = "" Then
                        hidCheckedPatronGroup.Value = CheckBoxListPatronGroup.Items(i).Value
                    Else
                        hidCheckedPatronGroup.Value = hidCheckedPatronGroup.Value & "," & CheckBoxListPatronGroup.Items(i).Value
                    End If
                End If
            Next
        End Sub
        Protected Sub ddlPatronGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPatronGroup.SelectedIndexChanged
            Dim dvOverduePatron As New DataView
            Dim Item As New ListItem
            objBOverdueTransaction.SelectMode = "ALL"
            objBOverdueTransaction.Logic = ""
            objBOverdueTransaction.DueTime = 0
            objBOverdueTransaction.PatronIDs = ""
            Dim tblOverduePatrons As DataTable = objBOverdueTransaction.GetOverduePatron(txtFullName.Text, ddlPatronGroup.SelectedValue)
            If Not tblOverduePatrons Is Nothing Then
                If tblOverduePatrons.Rows.Count > 0 Then
                    dvOverduePatron = tblOverduePatrons.DefaultView
                    dvOverduePatron.RowFilter = "Email LIKE '%@%'"
                    If Not IsDBNull(dvOverduePatron) Then
                        If dvOverduePatron.Count > 0 Then
                            lsbAllOverduePatron.DataSource = dvOverduePatron
                            lsbAllOverduePatron.DataValueField = "ID"
                            lsbAllOverduePatron.DataTextField = "Name"
                            lsbAllOverduePatron.DataBind()
                        Else
                            'Item.Text = "            "
                            'Item.Value = 0
                            'lsbAllOverduePatron.Items.Add(Item)
                            lsbAllOverduePatron.Items.Clear()
                            lsbAllOverduePatron.DataSource = Nothing
                            lsbAllOverduePatron.DataBind()
                        End If
                    Else
                        'Item.Text = "          "
                        'Item.Value = 0
                        'lsbAllOverduePatron.Items.Add(Item)
                        lsbAllOverduePatron.Items.Clear()
                        lsbAllOverduePatron.DataSource = Nothing
                        lsbAllOverduePatron.DataBind()
                    End If
                Else
                    lsbAllOverduePatron.Items.Clear()
                    lsbAllOverduePatron.DataSource = Nothing
                    lsbAllOverduePatron.DataBind()
                End If
            Else
                lsbAllOverduePatron.Items.Clear()
                lsbAllOverduePatron.DataSource = Nothing
                lsbAllOverduePatron.DataBind()
            End If
        End Sub

    End Class
End Namespace