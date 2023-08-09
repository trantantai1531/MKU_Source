' Class: WBibliographyTemplate
' Purpose: Display index page
' Creator: Oanhtn
' CreatedDate: 05/04/2004
' Modification history 
'   - 22/02/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIndexTemplate
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

        Private objBForm As New clsBForm

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call CheckFormPermission()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call BindJavascripts()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBForm object 
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            objBForm.IsAuthority = Session("IsAuthority")
            Call objBForm.Initialize()

            ' Session
            Session("IsAuthority") = 0

            'Page.RegisterClientScriptBlock("DefaulFooter", "<script language = 'javascript'>parent.Sentform.location.href='WNothing.htm';</script>")
        End Sub

        ' BindJavascripts method
        ' Purpose: include all javascript functions
        Private Sub BindJavascripts()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("FooterJS", "<script language = 'javascript'>parent.Sentform.location.href='WNothing.htm';</script>")
            Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = '../Js/BibliographyTemplate/WIndexTemplate.js'></script>")

            btnUpdate.Attributes.Add("OnClick", "javascript:UpdateForm(document.forms[0].lstMarcForm.options[document.forms[0].lstMarcForm.options.selectedIndex].value); return false;")
            btnMerger.Attributes.Add("OnClick", "javascript:if (document.forms[0].lstMarcForm.options.selectedIndex == 0) {alert('" & ddlLabel.Items(0).Text & "'); return false;}")
            btnUpdateField.Attributes.Add("OnClick", "javascript:UpdateField(document.forms[0].lstMarcField.options[document.forms[0].lstMarcField.options.selectedIndex].value, 'Mess1', 'Mess2'); return false;")
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check permission for use form's functions
        Private Sub CheckFormPermission()
            'Gop mau bien muc
            If Not CheckPemission(18) Then
                btnMerger.Enabled = False
            End If
            'Cap nhat(u)
            If Not CheckPemission(16) Or Not CheckPemission(17) Then
                btnUpdate.Enabled = False
            End If
            'Cap nhat(p)
            If Not CheckPemission(19) Or Not CheckPemission(20) Then
                btnUpdateField.Enabled = False
            End If
        End Sub

        ' BindData method
        ' Purpose: Create MarcForm ListBox
        Private Sub BindData()
            Dim arrFieldText()
            Dim arrFieldValue()
            Dim strNew As String = "------------------------------- " & ddlLabel.Items(1).Text & " -------------------------------"
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
            If tblTemp.Rows.Count > 2 Then
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
                ddlMarcForm.DataBind()
                ddlMarcForm.SelectedIndex = 0

                tblTemp.Clear()
            End If
            ' Create MarcFieldList
            tblTemp = objBForm.GetUserFields
            intLen = tblTemp.Rows.Count
            ReDim arrFieldText(intLen)
            ReDim arrFieldValue(intLen)
            arrFieldText(0) = strNew
            arrFieldValue(0) = "0"
            If intLen > 0 Then
                For intCounter = 0 To intLen - 1
                    arrFieldText(intCounter + 1) = tblTemp.Rows(intCounter).Item("FieldCode") & " ".PadRight(5 - Len(tblTemp.Rows(intCounter).Item("FieldCode"))) & " -- " & tblTemp.Rows(intCounter).Item("VietFieldName")
                    arrFieldValue(intCounter + 1) = tblTemp.Rows(intCounter).Item("FieldCode")
                Next
            End If
            lstMarcField.DataTextField = "TextField"
            lstMarcField.DataValueField = "ValueField"
            lstMarcField.DataSource = CreateTable(arrFieldText, arrFieldValue)
            lstMarcField.DataBind()
            lstMarcField.SelectedIndex = 0
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
            ' Write log
            Call WriteLog(21, ddlLabel.Items(3).Text & ": " & lstMarcForm.SelectedItem.Text & " and " & ddlMarcForm.SelectedItem.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

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