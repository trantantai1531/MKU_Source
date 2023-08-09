Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIndexCata
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

        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Call Initialize()
                Call LoadTotalRecord()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Not Session("IsAuthority") = 0 Then
                Session("strIDs") = Nothing
                Session("Filter") = Nothing
                Session("arrFilteredItemID") = Nothing
                Session("TotalRecord") = Nothing
            End If
            Session("IsAuthority") = 0

            ' Init objBItemCollection object
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            objBItemCollection.Initialize()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' LoadTotalRecord method
        Private Sub LoadTotalRecord()
            Dim tblItemID As DataTable
            ' Inti session for cat query
            Session("InputTime") = 0
            objBItemCollection.TypeItem = 0
            tblItemID = objBItemCollection.GetRangeItemID
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(0).Text, objBItemCollection.ErrorCode)

            Page.RegisterClientScriptBlock("LoadData", "<script language='javascript'>if (parent.Menu.document.forms[0].txtTotalItem) {parent.Menu.document.forms[0].txtTotalItem.disabled=false; parent.Menu.document.forms[0].txtTotalItem.value=" & tblItemID.Rows(0).Item("Total") & ";}; </script>")
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