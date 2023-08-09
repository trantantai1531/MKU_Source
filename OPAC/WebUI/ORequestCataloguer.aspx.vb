Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.WebUI

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class ORequestCataloguer
        Inherits clsWBaseJqueryUI

        Private objBOPACRequestCataloguer As New clsBOPACRequestCataloguer
        Private objBOPACPatronInfor As New clsBOPACPatronInfor

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If String.IsNullOrEmpty(clsSession.GlbUser) Then
                Response.Redirect("OLoginRequest.aspx?RequestLogin=1", False)
            End If

            Call Initialize()
            Call BindScript()
            If Page.IsPostBack = False Then
                Call BindPatronGroup()
                Call LockTextBox()
                Call BindInfoPatron()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBPatronInfor
            objBOPACRequestCataloguer.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACRequestCataloguer.DBServer = Session("DBServer")
            objBOPACRequestCataloguer.ConnectionString = Session("ConnectionString")
            objBOPACRequestCataloguer.Initialize()

            'Init objBOPACPatronInfor
            objBOPACPatronInfor.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBOPACPatronInfor.DBServer = Session("DBServer")
            objBOPACPatronInfor.ConnectionString = Session("ConnectionString")
            objBOPACPatronInfor.Initialize()
        End Sub

        Private Sub LockTextBox()
            If Not String.IsNullOrEmpty(clsSession.GlbUser) Then
                txtFullName.ReadOnly = True
                txtPatronCode.ReadOnly = True
                txtEmail.ReadOnly = True
                txtPhone.ReadOnly = True
                txtFacebook.ReadOnly = True
                txtSupplier.ReadOnly = True
                RadioButtonListGroupName.Enabled = False
            End If
        End Sub

        Private Sub BindInfoPatron()

            objBOPACPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            Dim tblPatronInfor As DataTable = objBOPACPatronInfor.GetPatronInfo()
            If tblPatronInfor IsNot Nothing Then
                If tblPatronInfor.Rows.Count > 0 Then
                    txtFullName.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("FullName")), "", tblPatronInfor.Rows(0).Item("FullName"))
                    txtPatronCode.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Code")), "", tblPatronInfor.Rows(0).Item("Code"))
                    txtEmail.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Email")), "", tblPatronInfor.Rows(0).Item("Email"))
                    txtPhone.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Telephone")), "", tblPatronInfor.Rows(0).Item("Telephone"))
                    txtFacebook.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Facebook")), "", tblPatronInfor.Rows(0).Item("Facebook"))
                    txtSupplier.Text = If(IsDBNull(tblPatronInfor.Rows(0).Item("Faculty")), "", tblPatronInfor.Rows(0).Item("Faculty"))
                    RadioButtonListGroupName.SelectedValue = If(IsDBNull(tblPatronInfor.Rows(0).Item("PatronGroupID")), "0", tblPatronInfor.Rows(0).Item("PatronGroupID"))
                End If
            End If
        End Sub

        Private Sub BindPatronGroup()
            'RadioButtonListGroupName
            Dim tblPatronGroup As DataTable = objBOPACPatronInfor.GetPatronGroup(clsSession.GlbSite)
            If tblPatronGroup IsNot Nothing Then
                If tblPatronGroup.Rows.Count > 0 Then
                    RadioButtonListGroupName.Items.Clear()

                    RadioButtonListGroupName.DataSource = tblPatronGroup
                    RadioButtonListGroupName.DataTextField = "Name"
                    RadioButtonListGroupName.DataValueField = "ID"
                    RadioButtonListGroupName.DataBind()
                End If
            End If
        End Sub

        ' Purpose: Register Script method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/ORequestCataloguer.js'></script>")

            btnUpdate.Attributes.Add("OnClick", "return(CheckForRequest('" & lblRequired.Text & "','" & lblNotValidEmail.Text & "'));")
            btnReset.Attributes.Add("onClick", "document.forms[0].reset(); return (false);")
        End Sub

        Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            objBOPACRequestCataloguer.FullName = txtFullName.Text
            objBOPACRequestCataloguer.PatronCode = txtPatronCode.Text
            objBOPACRequestCataloguer.Email = txtEmail.Text
            objBOPACRequestCataloguer.Phone = txtPhone.Text
            objBOPACRequestCataloguer.Facebook = txtFacebook.Text
            objBOPACRequestCataloguer.Supplier = txtSupplier.Text
            objBOPACRequestCataloguer.GroupName = RadioButtonListGroupName.SelectedItem.Text
            objBOPACRequestCataloguer.Title = txtTitle.Text
            objBOPACRequestCataloguer.Author = txtAuthor.Text
            objBOPACRequestCataloguer.Publisher = txtPublier.Text
            objBOPACRequestCataloguer.PublishYear = txtPublishYear.Text
            objBOPACRequestCataloguer.Information = txtInformation.Text

            Dim intResult As Integer = objBOPACRequestCataloguer.Insert()
            If intResult = 1 Then
                Page.RegisterClientScriptBlock("UpdateSuccessfulAlterJs", "<script language='javascript'>alert('" & lblSuccessRequest.Text & "');</script>")
                Call ResetPage()
            Else
                Page.RegisterClientScriptBlock("UpdateUnSuccessfulAlterJs", "<script language='javascript'>alert('" & lblNoSuccessRequest.Text & "');</script>")
            End If
        End Sub

        Private Sub ResetPage()
            txtFullName.Text = ""
            txtPatronCode.Text = ""
            txtEmail.Text = ""
            txtPhone.Text = ""
            txtFacebook.Text = ""
            txtSupplier.Text = ""
            txtTitle.Text = ""
            txtAuthor.Text = ""
            txtPublier.Text = ""
            txtPublishYear.Text = ""
            txtInformation.Text = ""
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACRequestCataloguer Is Nothing Then
                    objBOPACRequestCataloguer.Dispose(True)
                    objBOPACRequestCataloguer = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
