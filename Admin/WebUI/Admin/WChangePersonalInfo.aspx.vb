' Class: WChangePersonalInfo
' Puspose: Change personal Infomation
' Creator: Minhns
' CreatedDate: 01/08/2006

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Admin
    Partial Class WChangePersonalInfo
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents TRLocLabel As System.Web.UI.HtmlControls.HtmlTableRow
        Protected WithEvents TRLoc As System.Web.UI.HtmlControls.HtmlTableRow


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Dim objBCommonBusiness As New clsBCommonBusiness
        Dim objBRole As New clsBRole
        Dim objBUser As New clsBUser
        Dim intIsLDAP As Integer = 0


        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()

            If objSysPara(0) = 1 Then
                intIsLDAP = 1
                txtOldPassword.Enabled = False
                txtNewPassword.Enabled = False
                txtRetypePassword.Enabled = False
            Else
                intIsLDAP = 0
            End If

            Call BindScript()

            If Not Page.IsPostBack Then
                txtUserName.Text = clsSession.GlbUser
                txtFullName.Text = clsSession.GlbUserFullName

            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Init objBRole object
            objBRole.ConnectionString = Session("ConnectionString")
            objBRole.DBServer = Session("DBServer")
            objBRole.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBRole.Initialize()

            ' Init objBUser object
            objBUser.InterfaceLanguage = Session("InterfaceLanguage")
            objBUser.DBServer = Session("DBServer")
            objBUser.ConnectionString = Session("ConnectionString")
            objBUser.Initialize()

            ' Init objBCommonBusiness object
            objBCommonBusiness.ConnectionString = Session("ConnectionString")
            objBCommonBusiness.DBServer = Session("DBServer")
            objBCommonBusiness.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCommonBusiness.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = 'Js/ChangePersonalInfo.js'></script>")

            If intIsLDAP = 0 Then
                btnUpdate.Attributes.Add("OnClick", "javascript:return CheckAllInput('" & ddlLabel.Items(2).Text & "','" & ddlLabel.Items(3).Text & "','" & ddlLabel.Items(4).Text & "','" & ddlLabel.Items(5).Text & "');")
            Else
                btnUpdate.Attributes.Add("OnClick", "javascript:return CheckInputName('" & ddlLabel.Items(3).Text & "');")
            End If

            btnClose.Attributes.Add("OnClick", "self.close();")
        End Sub

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

            If Not (txtOldPassword.Text = Session("Password")) And intIsLDAP = 0 Then
                Page.RegisterClientScriptBlock("InvalidPassword", "<script language='javascript'>alert('" & ddlLabel.Items(4).Text & "')</script>")
            Else
                'Update
                objBUser.UID = Session("UserID")
                objBUser.UserName = txtUserName.Text
                objBUser.UserPass = txtNewPassword.Text
                objBUser.FullName = txtFullName.Text
                objBUser.ChangeUserPass(intIsLDAP)

                If objBUser.ErrorCode = 0 Then

                    Session("Password") = objBUser.UserPass
                    clsSession.GlbUserFullName = objBUser.FullName
                    Page.RegisterClientScriptBlock("UpdateSuccessful", "<script language='javascript'>alert('" & ddlLabel.Items(6).Text & "'); self.close();</script>")
                Else
                    Call WriteErrorMssg(ddlLabel.Items(0).Text, objBUser.ErrorMsg, ddlLabel.Items(1).Text, objBUser.ErrorCode)
                End If

            End If

        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBRole Is Nothing Then
                    objBRole.Dispose(True)
                    objBRole = Nothing
                End If
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
                If Not objBCommonBusiness Is Nothing Then
                    objBCommonBusiness.Dispose(True)
                    objBCommonBusiness = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


    End Class
End Namespace