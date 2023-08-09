Imports System.DirectoryServices
Imports eMicLibAdmin.BusinessRules.Admin

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WLDAPUsers
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents tbllLDAPUser As System.Web.UI.WebControls.Table


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private ds As DataSet

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            btnClose.Attributes.Add("OnClick", "self.close();return false;")
            Call Main()
        End Sub

        ' Method: Main
        ' Purpose: simple call running functions
        Private Sub Main()
            Dim intMode As Int16
            Dim strLocation As String
            Dim strServerType As String
            Dim strUser As String
            Dim strPassword As String
            Dim tblrow As TableRow
            Dim tblcell As TableCell
            Dim strSQLStmt As String

            Try
                intMode = objSysPara(0)
                strLocation = objSysPara(1)
                strServerType = objSysPara(2)
                strUser = objSysPara(3)
                strPassword = objSysPara(4)

                If intMode = 1 Then
                    Dim de As DirectoryEntry
                    Dim src As DirectorySearcher
                    Select Case UCase(strServerType)
                        Case "MS ACTIVE DIRECTORY"
                            de = New DirectoryEntry(strLocation, strUser, strPassword)
                            src = New DirectorySearcher("(&(objectCategory=Person)(objectClass=user))")
                        Case "LDAP"
                            de = New DirectoryEntry(strLocation, strUser, strPassword, AuthenticationTypes.ServerBind)
                            src = New DirectorySearcher("(&(objectCategory=Person)(objectClass=user))")
                        Case "OSSO ORACLE"
                            de = New DirectoryEntry(strLocation, strUser, strPassword, AuthenticationTypes.Anonymous)
                            src = New DirectorySearcher("(objectClass=person)")
                    End Select

                    Dim res As SearchResult
                    CreateLDAPTable()
                    src.SearchRoot = de
                    src.SearchScope = SearchScope.Subtree

                    For Each res In src.FindAll()
                        Dim tbltopRow As DataRow
                        tbltopRow = ds.Tables("users").NewRow
                        Select Case UCase(strServerType)
                            Case "MS ACTIVE DIRECTORY"
                                tbltopRow("UserName") = res.Properties("sAMAccountName")(0)
                                tbltopRow("Name") = res.Properties("cn")(0)
                                tbltopRow("AdressPath") = res.Properties("adspath")(0)
                                ds.Tables("users").Rows.Add(tbltopRow)
                            Case "LDAP"
                                tbltopRow("UserName") = res.Properties("uid")(0)
                                tbltopRow("Name") = res.Properties("cn")(0)
                                tbltopRow("Mail") = res.Properties("mail")(0)
                                tbltopRow("AdressPath") = res.Properties("adspath")(0)
                                ds.Tables("users").Rows.Add(tbltopRow)
                            Case "OSSO ORACLE"
                                tbltopRow("UserName") = res.Properties("uid")(0)
                                tbltopRow("Name") = res.Properties("cn")(0)
                                tbltopRow("AdressPath") = res.Properties("adspath")(0)
                                ds.Tables("users").Rows.Add(tbltopRow)
                        End Select
                    Next
                    dtgLDAP.DataSource = ds.Tables("users")
                    dtgLDAP.DataBind()
                End If
            Catch ex As Exception
                Call WriteErrorMssg(ex.Message)
            End Try
        End Sub

        ' CreateLDAPTable method
        ' purpose: create ldap table  for datagrid to binhd
        Private Sub CreateLDAPTable()
            ds = New DataSet
            'DataTable for users
            Dim tbUsers As DataTable = New DataTable("users")
            'Create Columns for DataTable.
            tbUsers.Columns.Add("UserName", System.Type.GetType("System.String"))
            tbUsers.Columns.Add("Name", System.Type.GetType("System.String"))
            tbUsers.Columns.Add("Mail", System.Type.GetType("System.String"))
            tbUsers.Columns.Add("AdressPath", System.Type.GetType("System.String"))
            ds.Tables.Add(tbUsers)
            'DataTable for properties
            Dim tbProperties As DataTable = New DataTable("properties")
            'Create Columns for DataTable.
            tbProperties.Columns.Add("PropertyName", System.Type.GetType("System.String"))
            tbProperties.Columns.Add("PropertyValue", System.Type.GetType("System.String"))
            ds.Tables.Add(tbProperties)
        End Sub

        ' dtgLDAP_ItemCreated
        Private Sub dtgLDAP_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgLDAP.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    tblCell = e.Item.Cells(0)
                    Dim lnk As HyperLink
                    lnk = CType(tblCell.FindControl("lnkSelect"), HyperLink)
                    lnk.Text = "<img src=""../Images/select.jpg"" border=""0"" alt=""" & ddlLabel.Items(3).Text & """>"
                    lnk.NavigateUrl = "javascript:if (confirm('" & ddlLabel.Items(4).Text & "')) {opener.document.forms[0].txtFullName.value='" & DataBinder.Eval(e.Item.DataItem, "Name") & "';opener.document.forms[0].txtUserName.value='" & DataBinder.Eval(e.Item.DataItem, "UserName") & "';opener.document.forms[0].hidLDAPAdsPath.value='" & DataBinder.Eval(e.Item.DataItem, "AdressPath") & "';self.close();}"
            End Select
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace