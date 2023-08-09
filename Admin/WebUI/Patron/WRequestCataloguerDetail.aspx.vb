Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WRequestCataloguerDetail
        Inherits clsWBase

        Private objBRequestCataloguer As New clsBRequestCataloguer

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            If Page.IsPostBack = False Then
                Call BindData()
            End If
        End Sub

        Private Sub Initialize()
            objBRequestCataloguer.DBServer = Session("DBServer")
            objBRequestCataloguer.ConnectionString = Session("ConnectionString")
            objBRequestCataloguer.InterfaceLanguage = Session("InterfaceLanguage")
            objBRequestCataloguer.Initialize()
        End Sub

        Private Sub BindData()
            Dim intID As Integer = CInt(Request.QueryString("intID"))
            Dim tblData As DataTable = objBRequestCataloguer.GetRequestCataloguer_ByID(intID)
            If (Not IsNothing(tblData)) AndAlso tblData.Rows.Count > 0 Then
                txtFullName.Text = tblData.Rows(0).Item("FullName") & ""
                txtPatronCode.Text = tblData.Rows(0).Item("PatronCode") & ""
                txtEmail.Text = tblData.Rows(0).Item("Email") & ""
                txtPhone.Text = tblData.Rows(0).Item("Phone") & ""
                txtFacebook.Text = tblData.Rows(0).Item("Facebook") & ""
                txtSupplier.Text = tblData.Rows(0).Item("Supplier") & ""
                txtGroupName.Text = tblData.Rows(0).Item("GroupName") & ""
                txtTitle.Text = tblData.Rows(0).Item("Title") & ""
                txtAuthor.Text = tblData.Rows(0).Item("Author") & ""
                txtPublier.Text = tblData.Rows(0).Item("Publisher") & ""
                txtPublishYear.Text = tblData.Rows(0).Item("PublishYear") & ""
                txtInformation.Text = tblData.Rows(0).Item("Information") & ""
                txtDateInput.Text = tblData.Rows(0).Item("DateInput") & ""
            End If
        End Sub
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRequestCataloguer Is Nothing Then
                    objBRequestCataloguer.Dispose(True)
                    objBRequestCataloguer = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace

