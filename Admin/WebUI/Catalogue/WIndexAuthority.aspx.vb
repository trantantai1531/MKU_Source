Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIndexAuthority
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lnkDelete As System.Web.UI.WebControls.HyperLink
        Protected WithEvents lblDelete As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call LoadTotalRecord()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Not Session("IsAuthority") = 1 Then
                Session("strIDs") = Nothing
                Session("Filter") = Nothing
                Session("arrFilteredItemID") = Nothing
                Session("TotalRecord") = Nothing
            End If
            Session("IsAuthority") = 1

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            objBItemCollection.Initialize()
        End Sub

        ' LoadTotalRecord method
        ' Purpose: load total of items in menu page
        Private Sub LoadTotalRecord()
            Dim tblItemID As DataTable
            objBItemCollection.TypeItem = 0
            tblItemID = objBItemCollection.GetRangeItemID
            Call WriteErrorMssg(lblLabel2.Text, objBItemCollection.ErrorMsg, lblLabel1.Text, objBItemCollection.ErrorCode)

            Page.RegisterClientScriptBlock("LoadTotalItems", "<script language='javascript'>top.main.Menu.document.forms[0].enabled=true; top.main.Menu.document.forms[0].txtTotalItem.value=" & tblItemID.Rows(0).Item("Total") & "; top.main.Menu.document.forms[0].enabled=false;</script>")
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