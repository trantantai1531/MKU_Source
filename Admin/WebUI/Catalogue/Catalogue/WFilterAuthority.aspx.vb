Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WFilterAuthority
        Inherits clsWBase

        ' Declare the class variables
        Private objBForm As New clsBForm
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBCDS As New clsBCommonDBSystem

#Region " Web Form Designer Generated Code "


        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub



        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
            Call BindScript()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objWCommonDBSystem object
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()

            ' Init objBForm object
            objBForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBForm.DBServer = Session("DBServer")
            objBForm.ConnectionString = Session("ConnectionString")
            Call objBForm.Initialize()

            ' Init objBCDS object
            objBCDS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDS.DBServer = Session("DBServer")
            objBCDS.ConnectionString = Session("ConnectionString")
            Call objBCDS.Initialize()
        End Sub

        ' BindScript method
        ' Purpose: BindJavascript
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnFilter.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtAccessEntry) && (document.forms[0].ddlReference.options[document.forms[0].ddlReference.selectedIndex].value=='')) {alert('" & ddlLabel.Items(4).Text & "'); return false;}")
        End Sub

        ' BindData method
        ' Purpose: load all marc worksheet into dropdown list
        Private Sub BindData()
            Dim tblTemp As DataTable

            objBForm.IsAuthority = 1
            tblTemp = objBForm.GetForms

            objBCDS.InsertOneRow(tblTemp, Trim(ddlLabel.Items(3).Text))
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    ddlReference.DataSource = tblTemp
                    ddlReference.DataTextField = "Name"
                    ddlReference.DataValueField = "ID"
                    ddlReference.DataBind()
                End If
            End If
        End Sub

        ' SearchItem method 
        ' Purpose: Search items by the reference 
        Private Sub SearchItem()
            ' Declare the module variables
            Dim strIDs As String
            Dim strSQL As String
            Dim tblItem As DataTable
            Dim intIndex As Integer
            Dim intCount As Integer
            Dim intSumFound As Integer = 0

            objBCatalogueForm.AccessEntry = CStr(txtAccessEntry.Text)

            If Not Trim(CStr(ddlReference.SelectedValue)) = "" Then
                objBCatalogueForm.ReferenceID = 0
            Else
                objBCatalogueForm.ReferenceID = 0
            End If

            tblItem = objBCatalogueForm.GetAuthorityInfor(0, CInt(ddlReference.SelectedValue))
            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    intSumFound = tblItem.Rows.Count
                End If
            End If

            strIDs = ""

            If intSumFound <> 0 Then
                ' The session of IDs must less than or equal 5000
                If intSumFound <= 5000 Then
                    For intIndex = 0 To tblItem.Rows.Count - 1
                        strIDs = strIDs & CStr(tblItem.Rows(intIndex).Item("ID")) & ","
                    Next
                Else
                    For intIndex = 0 To 4999
                        strIDs = strIDs & CStr(tblItem.Rows(intIndex).Item("ID")) & ","
                    Next
                End If
                strIDs = Left(strIDs, Len(strIDs) - 1)
                Session("TotalRecord") = CInt(intSumFound)
                Session("Filter") = 1
                Session("strIDs") = strIDs
                Page.RegisterClientScriptBlock("JSDisplay", "<script language= 'javascript'>parent.Sentform.location.href='WControlBar.aspx'</script>")
            Else
                ' Not found any item IDs
                Page.RegisterClientScriptBlock("JSAlert", "<script language= 'javascript'>alert('" & ddlLabel.Items(0).Text & "')</script>")
            End If

        End Sub

        ' btnFilter_Click event
        ' Purpose: Filter the Items
        Private Sub btnFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Call SearchItem()
        End Sub
        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBForm Is Nothing Then
                    objBForm.Dispose(True)
                    objBForm = Nothing
                End If
                If Not objBCatalogueForm Is Nothing Then
                    objBCatalogueForm.Dispose(True)
                    objBCatalogueForm = Nothing
                End If
                If Not objBCDS Is Nothing Then
                    objBCDS.Dispose(True)
                    objBCDS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace