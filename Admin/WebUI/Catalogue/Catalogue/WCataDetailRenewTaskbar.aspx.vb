' Class: WCataDetailTaskbar
' Puspose: allow catalogue or delete item selected record
' Creator: KhoaNA
' CreatedDate: 17/03/2004
' Modification Histority
'   - 24/03/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataDetailRenewTaskbar
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

        ' Declare Variable
        Private objBForm As New clsBForm
        Private objBItem As New clsBItem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
                Call BindJS()
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(3) Then
                btnCatalogue.Enabled = False
            End If
            If Not CheckPemission(4) Then
                btnDelete.Enabled = False
            End If
            If Not CheckPemission(5) Then
                btnRenew.Enabled = False
            End If
        End Sub

        ' Initialize Method
        ' Purpose: Initialize the component
        Private Sub Initialize()
            'Init objBForm
            objBForm.ConnectionString = Session("ConnectionString")
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            Call objBForm.Initialize()
        End Sub

        ' BindJS method
        ' Purpose: Bind javascript
        Private Sub BindJS()
            Dim strJVScript As String   ' string of JAVASCRIPT
            Dim strMsg As String

            ' Add the attribute for the delete button
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("Catalog", "<script language = 'javascript' src = '../Js/Catalogue/WCataDetail.js'></script>")

            Session("arrFilteredItemID") = Nothing
            strJVScript = "var intUseDefault;"
            strJVScript = strJVScript & "if (eval(parent.Workform.document.forms[0].hidID).value!="""") {"
            strJVScript = strJVScript & "if (eval(document.forms[0].chkUseDefault).checked == false) {intUseDefault=0;} else {intUseDefault=1;}"
            strJVScript = strJVScript & "parent.Sentform.location.href='WCataModify.aspx?CurrentID=0&ItemID='+ parent.Workform.document.forms[0].hidID.value + '"
            strJVScript = strJVScript & "&FormID=' + parent.Sentform.document.forms[0].ddlForm.options[parent.Sentform.document.forms[0].ddlForm.options.selectedIndex].value + '"
            strJVScript = strJVScript & "&UseDefault=' + intUseDefault"

            ' Add the attribute for the catalogue button 
            btnCatalogue.Attributes.Add("onclick", "javascript:" & strJVScript & ";return false;}else {alert('" & ddlLabel.Items(0).Text & "');return false;}")
            btnDelete.Attributes.Add("onclick", "javascript:if (CheckNull(parent.Workform.document.forms[0].hidIDs)) {alert('" & ddlLabel.Items(3).Text & "');} else{if (window.confirm('" & ddlLabel.Items(4).Text & "')) {parent.Workform.document.location.href='WCataDetailRenew.aspx?strDelete=' + parent.Workform.document.forms[0].hidIDs.value;}}return false;")
            btnRenew.Attributes.Add("onclick", "javascript:if (CheckNull(parent.Workform.document.forms[0].hidIDs)) {alert('" & ddlLabel.Items(6).Text & "');} else{if (window.confirm('" & ddlLabel.Items(5).Text & "')) {parent.Workform.document.location.href='WCataDetailRenew.aspx?strUpdate=' + parent.Workform.document.forms[0].hidIDs.value;}}return false;")
            Page.RegisterClientScriptBlock("LoadWorkForm", "<script language='javascript'>parent.Workform.location.href = 'WCataDetailRenew.aspx';</script>")
        End Sub

        ' BindData method
        ' Purpose: Bind the Form name to the drop down list
        Private Sub BindData()
            Dim tblForm As DataTable

            ' get form
            tblForm = objBForm.GetForms

            If Not tblForm Is Nothing Then
                If tblForm.Rows.Count > 0 Then
                    ddlForm.DataSource = objBForm.GetForms
                    ddlForm.DataTextField = "Name"
                    ddlForm.DataValueField = "ID"
                    ddlForm.DataBind()
                End If
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        ' purpose: Release the component
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBForm Is Nothing Then
                        objBForm.Dispose(True)
                        objBForm = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace