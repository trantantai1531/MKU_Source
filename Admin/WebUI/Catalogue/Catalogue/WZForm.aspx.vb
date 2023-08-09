' Class: WZForm
' Purpose: Display z3950 search form
' Creator: Oanhtn
' CreatedDate: 12/08/2004
' Modification history:
'   - 24/02/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WZForm
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents Label1 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindControl()
            Call BindJS()
        End Sub

        ' CheckFormPermission method
        ' Purpose: check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(9) Then ' Import records
                btnSearch.Enabled = False
            End If
            If Not CheckPemission(173) Then
                optOverlay.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all objects
        Private Sub Initialize()
            ' Reset all sessions
            Session("zServer") = "z3950.loc.gov"
            Session("zPort") = "7090"
            Session("zDatabase") = "voyager"
        End Sub

        ' BindJS method
        ' Purpose: Include all neccessary javascript function
        Private Sub BindJS()
            Dim strJS As String = ""

            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Catalogue/WZForm.js'></script>")

            'If Not Request.QueryString("tocat") = "" Then
            '    strJS = "document.forms[0].action='WZFind.aspx?tocat=1'; document.forms[0].submit();"
            'Else
            '    strJS = "document.forms[0].action='WZFind.aspx'; document.forms[0].submit();"
            'End If
            'strJS = "if (CheckAll()) {" & strJS & "} else {alert('" & ddlLabel.Items(0).Text.Trim & "');}"
            btnSearch.Attributes.Add("OnClick", "return ValidateForm('" & ddlLabel.Items(0).Text.Trim & "','" & ddlLabel.Items(1).Text & "','" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "');")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            lnkZServerList.NavigateUrl = "javascript:openModal('WZDbsList.aspx','ZDBServerWin',400,350,160,100,'yes','',0)"
        End Sub

        ' BindControl method
        ' Purpose: Create some dropdownlist
        Private Sub BindControl()
            txtzServer.Text = Session("zServer")
            txtZPort.Text = Session("zPort")
            txtZDatabase.Text = Session("zDatabase")

            If Session("Overlay") = 1 Then
                lblComment.Visible = False
                optNotImport.Visible = False
                optOverlay.Visible = False
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace