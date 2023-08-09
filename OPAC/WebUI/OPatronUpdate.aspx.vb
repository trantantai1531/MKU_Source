Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.WebUI

Namespace eMicLibOPAC.WebUI.OPAC
    Public Class OPatronUpdate
        Inherits clsWBaseJqueryUI
        ' Declare variables
        Private objBPatronInfor As New clsBOPACPatronInfor

        ' Event :  Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If Trim(clsSession.GlbUser & "") = "" Then
                Response.Redirect("OLogin.aspx")
            End If
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBPatronInfor
            objBPatronInfor.InterfaceLanguage = clsSession.GlbInterfaceLanguage
            objBPatronInfor.DBServer = Session("DBServer")
            objBPatronInfor.ConnectionString = Session("ConnectionString")
            objBPatronInfor.Initialize()
        End Sub

        ' Purpose: Register Script method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("MainJs", "<script language='javascript' src='JS/OPatronUpdate.js'></script>")

            ddlOccupation.Attributes.Add("OnChange", "SetOccupation();")
            ddlEducation.Attributes.Add("OnChange", "SetEducation();")
            btnUpdate.Attributes.Add("OnClick", "return(CheckForUpdate('" & lblEmtyPassword.Text & "','" & lblComparePassword.Text & "','" & lblNotValidEmail.Text & "'));")
            btnReset.Attributes.Add("onClick", "document.forms[0].reset(); return (false)")
        End Sub

        ' Purpose: BindData 
        Private Sub BindData()
            Dim tblPatronInfor As New DataTable
            Dim tblOccupation As New DataTable
            Dim tblEducation As New DataTable
            Dim inti As Integer
            ' Get all edcuation bind to education drowdownlist
            tblEducation = objBPatronInfor.GetEducation
            If Not tblEducation Is Nothing AndAlso tblEducation.Rows.Count > 0 Then
                ddlEducation.DataSource = tblEducation
                ddlEducation.DataTextField = "EducationLevel"
                ddlEducation.DataValueField = "ID"
                ddlEducation.DataBind()
            End If
            ' Get all occupation bind to occupation drowdownlist
            tblOccupation = objBPatronInfor.GetOccupation
            If Not tblOccupation Is Nothing AndAlso tblOccupation.Rows.Count > 0 Then
                ddlOccupation.DataSource = tblOccupation
                ddlOccupation.DataValueField = "ID"
                ddlOccupation.DataTextField = "Occupation"
                ddlOccupation.DataBind()
            End If
            ' Get Patron Informations
            objBPatronInfor.CardNo = Trim(clsSession.GlbUser & "")
            objBPatronInfor.Password = Trim(clsSession.GlbPassword & "")
            tblPatronInfor = objBPatronInfor.GetPatron
            If Not tblPatronInfor Is Nothing AndAlso tblPatronInfor.Rows.Count > 0 Then
                lblCardNoValue.Text = "<B>" & clsSession.GlbUser.ToString & "</B>"
                lblPatronNameValue.Text = "<B>" & clsSession.GlbUserFullName.ToString & "</B>"
                txtWorkPlace.Text = tblPatronInfor.Rows(0).Item("WorkPlace").ToString
                txtAddress.Text = tblPatronInfor.Rows(0).Item("Address").ToString
                txtTel.Text = tblPatronInfor.Rows(0).Item("Telephone").ToString
                txtMobile.Text = tblPatronInfor.Rows(0).Item("Mobile").ToString
                txtPassword.Text = tblPatronInfor.Rows(0).Item("Password").ToString
                hidPassword.Value = tblPatronInfor.Rows(0).Item("Password").ToString
                txtEmail.Text = tblPatronInfor.Rows(0).Item("Email").ToString
                ' Occupation 
                If Not IsDBNull(tblPatronInfor.Rows(0).Item("OccupationID")) Then
                    For inti = 0 To ddlOccupation.Items.Count - 1
                        If ddlOccupation.Items(inti).Value = tblPatronInfor.Rows(0).Item("OccupationID") Then
                            ddlOccupation.Items(inti).Selected = True
                            Exit For
                        End If
                    Next
                End If
                ' Education
                If Not IsDBNull(tblPatronInfor.Rows(0).Item("EducationID")) Then
                    For inti = 0 To ddlEducation.Items.Count - 1
                        If ddlEducation.Items(inti).Value = tblPatronInfor.Rows(0).Item("EducationID") Then
                            ddlEducation.Items(inti).Selected = True
                            Exit For
                        End If
                    Next
                End If
            End If
        End Sub

        ' Purponse: Update patron information 
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            objBPatronInfor.CardNo = clsSession.GlbUser
            objBPatronInfor.WorkPlace = txtWorkPlace.Text.Trim
            objBPatronInfor.EducationID = CInt("0" & ddlEducation.SelectedValue) ' CInt(txtEducation.Text)
            objBPatronInfor.OccupationID = CInt("0" & ddlOccupation.SelectedValue)  'CInt(txtOccupation.Text)
            objBPatronInfor.Tel = txtTel.Text.Trim
            objBPatronInfor.Address = txtAddress.Text.Trim
            objBPatronInfor.Mobile = txtMobile.Text.Trim
            objBPatronInfor.Password = txtPassword.Text.Trim
            objBPatronInfor.Email = txtEmail.Text.Trim
            ' Update into database
            Call objBPatronInfor.UpdatePatron()
            ' Reset password for session of this patron
            If Not txtPassword.Text.Trim = "" Then
                clsSession.GlbPassword = txtPassword.Text
            End If
            Page.RegisterClientScriptBlock("UpdateSuccessfulAlterJs", "<script language='javascript'>alert('" & lblUpdateSuccessful.Text & "');self.location.href='OPatronInfo.aspx';</script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPatronInfor Is Nothing Then
                    objBPatronInfor.Dispose(True)
                    objBPatronInfor = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

    End Class
End Namespace
