' Class: WOverduePrintLetter
' Puspose: Print Overdue Patron
' Creator: Sondp
' CreatedDate: 27/8/2004
' Modification History:
'   - 18/04/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Circulation
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Circulation
    Partial Class WOverduePrintLetter
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tblPrintLetter As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tblBodyPrintLetter As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tblPickPatron As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents tblSubButton As System.Web.UI.HtmlControls.HtmlTable
        Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
        Protected WithEvents lblSelectPatron As System.Web.UI.WebControls.Label
        Protected WithEvents lblSelectTemplate As System.Web.UI.WebControls.Label
        Protected WithEvents lblLessThan0 As System.Web.UI.WebControls.Label
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: Checkpermission
        Private Sub CheckFormPermission()
            If Not CheckPemission(60) Then
                Call WritePermErrorMssg()
            End If
        End Sub

        ' Method: Initialize
        ' Init all necessary objects
        Private Sub Initialize()
            ' Init objBOverdueTemplate object
            objBOverdueTemplate.ConnectionString = Session("ConnectionString")
            objBOverdueTemplate.DBServer = Session("DBServer")
            objBOverdueTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTemplate.Initialize()

            ' Init objBOverdueTransaction object
            objBOverdueTransaction.ConnectionString = Session("ConnectionString")
            objBOverdueTransaction.DBServer = Session("DBServer")
            objBOverdueTransaction.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBOverdueTransaction.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Include all necessary javascript functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("RegisterActionPrintLetterJs", "<script language='javascript' src='../Js/Overdue/WOverduePrintLetter.js'></script>")

            ' Controls action
            rbAllPatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbOverduePatron.checked=0;document.forms[0].rbSelectPatron.checked=0;document.forms[0].txtOverduePrintMode.value=0;")
            rbOverduePatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbSelectPatron.checked=0;document.forms[0].txtOverduePrintMode.value=1;")
            rbSelectPatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbAllPatron.checked=0;document.forms[0].rbOverduePatron.checked=0;document.forms[0].txtOverduePrintMode.value=2;")

            ddlOverduePatron.Attributes.Add("OnClick", "javascript:document.forms[0].rbOverduePatron.checked=1;document.forms[0].rbAllPatron.checked=0;document.forms[0].rbSelectPatron.checked=0; return false;")

            txtOverduePatron.Attributes.Add("OnChange", "javascript:if (!CheckNum(this)) {alert('" & ddlLabel.Items(5).Text & "'); this.value=1; this.focus();} else {document.forms[0].rbOverduePatron.checked=1;document.forms[0].rbAllPatron.checked=0;document.forms[0].rbSelectPatron.checked=0;}")

            btnAdd.Attributes.Add("OnClick", "javascript:AddItem(); return false;")
            btnRemove.Attributes.Add("OnClick", "javascript:RemoveItem(); return false;")
            btnPrint.Attributes.Add("OnClick", "javascript:return(PrintLetter('" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "'));")
            btnReset.Attributes.Add("OnClick", "javascript:ResetForm(); return false;")
        End Sub

        ' BindData method
        ' Purpose: Bind Data for first time display
        Private Sub BindData()
            Dim tblTemplate As DataTable
            Dim tblOverduePatrons As DataTable

            ' Bind data to dropdownlist Overdue Template
            objBOverdueTemplate.TemplateID = 0
            objBOverdueTemplate.TemplateType = 2
            objBOverdueTemplate.LibID = clsSession.GlbSite
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
            objBOverdueTransaction.UserID = Session("UserID")
            objBOverdueTransaction.Logic = ""
            objBOverdueTransaction.DueTime = 0
            objBOverdueTransaction.PatronIDs = ""
            objBOverdueTransaction.LibID = clsSession.GlbSite
            tblOverduePatrons = objBOverdueTransaction.GetOverduePatronAuthority
            If Not tblOverduePatrons Is Nothing Then
                If tblOverduePatrons.Rows.Count > 0 Then
                    lsbAllOverduePatron.DataSource = tblOverduePatrons
                    lsbAllOverduePatron.DataValueField = "ID"
                    lsbAllOverduePatron.DataTextField = "Name"
                    lsbAllOverduePatron.DataBind()
                End If
                tblOverduePatrons = Nothing
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
                If Not objBOverdueTemplate Is Nothing Then
                    objBOverdueTemplate.Dispose(True)
                    objBOverdueTemplate = Nothing
                End If
                If Not objBOverdueTransaction Is Nothing Then
                    objBOverdueTransaction.Dispose(True)
                    objBOverdueTransaction = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace