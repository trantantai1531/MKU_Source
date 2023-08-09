' WBibliographyTemplate class
' Creator: Oanhtn
' CreatedDate: 05/04/2004
' Modification history:
'   - 23/02/2005 by Oanhtn: review & test

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIndexTemplateAuthority
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel5 As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBForm As New clsBForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call BindJS()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBForm object 
            objBForm.IsAuthority = CInt(Session("IsAuthority"))
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WIndexTemplateAuthority", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WIndexTemplateAuthority.js'></script>")

            btnUpdate.Attributes.Add("OnClick", "javascript:UpdateForm(document.forms[0].lstMarcForm.options[document.forms[0].lstMarcForm.options.selectedIndex].value); return false;")
            btnMerger.Attributes.Add("OnClick", "javascript:if (document.forms[0].lstMarcForm.options.selectedIndex == 0) {alert('" & ddlLabel.Items(1).Text & "'); return false;}")

            Page.RegisterClientScriptBlock("DefaulFooter", "<script language = 'javascript'>parent.Sentform.location.href='WNothing.htm';</script>")
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check permission for use form's functions
        Private Sub CheckFormPermission()
            If Not CheckPemission(18) Then
                btnMerger.Enabled = False
            End If
            If Not CheckPemission(19) Or Not CheckPemission(20) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' BindData method
        ' Purpose: Create MarcForm ListBox
        Private Sub BindData()
            ' Declare variables
            Dim arrFieldText()
            Dim arrFieldValue()
            Dim strNew As String = "--------------------- " & ddlLabel.Items(0).Text & " ---------------------"
            Dim intLen As Integer
            Dim intCounter As Integer
            Dim tblTemp As New DataTable

            tblTemp = objBForm.GetForms

            tblTemp = InsertOneRow(tblTemp, strNew)
            lstMarcForm.DataTextField = "Name"
            lstMarcForm.DataValueField = "ID"
            lstMarcForm.DataSource = tblTemp
            lstMarcForm.DataBind()
            lstMarcForm.SelectedIndex = 0

            If tblTemp.Rows.Count > 1 Then
                intLen = tblTemp.Rows.Count - 2
                ReDim arrFieldText(intLen)
                ReDim arrFieldValue(intLen)

                For intCounter = 0 To intLen
                    arrFieldText(intCounter) = tblTemp.Rows(intCounter + 1).Item("Name")
                    arrFieldValue(intCounter) = tblTemp.Rows(intCounter + 1).Item("ID")
                Next
                ddlMarcForm.DataTextField = "TextField"
                ddlMarcForm.DataValueField = "ValueField"
                ddlMarcForm.DataSource = CreateTable(arrFieldText, arrFieldValue)
                Call WriteErrorMssg(ddlLabel.Items(3).Text, ErrorMsg, ddlLabel.Items(2).Text, ErrorCode)
                ddlMarcForm.DataBind()
                ddlMarcForm.SelectedIndex = 0
            End If
            tblTemp.Clear()
            tblTemp.Dispose()
            tblTemp = Nothing

        End Sub

        ' btnMerger_Click event
        ' Purpose: Merger some MarcForms
        Private Sub btnMerger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerger.Click
            Dim intSouFormID As Integer = lstMarcForm.SelectedValue
            Dim intDesFormID As Integer = ddlMarcForm.SelectedValue
            objBForm.SouFormID = intSouFormID
            objBForm.DesFormID = intDesFormID

            ' Merger forms
            Call objBForm.MergerForms()
            ' Writelog
            Call WriteLog(21, ddlLabel.Items(4).Text & ": " & lstMarcForm.SelectedItem.Text & " & " & ddlMarcForm.SelectedItem.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Alert message
            Page.RegisterClientScriptBlock("AlertJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(5).Text.Trim & "');</script>")

            ' Refresh page
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace