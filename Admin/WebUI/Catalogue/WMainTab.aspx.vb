Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WMainTab
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkAuthority As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lnkTitle As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink2 As System.Web.UI.WebControls.HyperLink
        Protected WithEvents Hyperlink3 As System.Web.UI.WebControls.HyperLink


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindStyle_JS()
            Call LoadData()
        End Sub

        ' BindJavascripts method
        ' Purpose: include all necessary javascript Functions
        Private Sub BindStyle_JS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = 'js/WMainTab.js'></script>")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            ' Init objBItemCollection object
            Session("IsAuthority") = 0
            Session("TypeData") = "INDEX"

            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
        End Sub

        ' LoadData method
        ' Purpose: get total of items and load into txtTotalItem
        Private Sub LoadData()
            Dim tblTotalItems As DataTable

            ' Get total of items
            objBItemCollection.TypeItem = 0
            tblTotalItems = objBItemCollection.GetRangeItemID
            Call WriteErrorMssg(lblLabel2.Text, objBItemCollection.ErrorMsg, lblLabel1.Text, objBItemCollection.ErrorCode)

            If tblTotalItems.Rows.Count > 0 Then
                txtTotalItem.Text = tblTotalItems.Rows(0).Item("TOTAL")
            Else
                txtTotalItem.Text = 0
            End If
            hidCount.Value = txtTotalItem.Text
            tblTotalItems.Dispose()
            tblTotalItems = Nothing
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace