Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCopyNumberTemplate
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblEmtyCopyNumberTemplate As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBCT As New clsBCommonTemplate

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call ShowData()
            End If
        End Sub

        ' CheckPermission method
        ' Purpose: Check user permission
        Private Sub CheckFormPermission()
            If Not CheckPemission(100) Then
                btnUpdate.Enabled = False
            End If
        End Sub

        ' Initialize method
        Public Sub Initialize()
            ' Init objBCT object
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.DBServer = Session("DBServer")
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCT.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            ddlElement.Attributes.Add("OnChange", "javascript:if(document.forms[0].ddlElement.options[document.forms[0].ddlElement.options.selectedIndex].value==0){document.forms[0].txtFormat.value='';return false;}else{document.forms[0].txtFormat.value+=document.forms[0].ddlElement.options[document.forms[0].ddlElement.options.selectedIndex].value;return false;}")

            btnUpdate.Attributes.Add("OnClick", "javascript:if(CheckNull(document.forms[0].txtFormat)){alert('" & ddlLabel.Items(5).Text & "'); return false;};CheckInt(document.forms[0].txtLenght,'Chiều dài chuỗi không hợp lệ')")
            btnReset.Attributes.Add("OnClick", "document.forms[0].txtFormat.value=''; return false;")
        End Sub

        ' Method: ShowData
        Private Sub ShowData()
            Dim tblTemplate As New DataTable

            ' Get copynumber template
            objBCT.TemplateID = 0
            objBCT.TemplateType = 3
            objBCT.LibID = clsSession.GlbSite
            tblTemplate = objBCT.GetTemplate

            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                hidTemplateID.Value = tblTemplate.Rows(0).Item("ID").ToString.Trim
                txtFormat.Text = tblTemplate.Rows(0).Item("Content").ToString.Trim
            End If

            'Show data for HoldingTemplate
            tblTemplate = objBCT.GetHoldingTemplate()

            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                ckbEnable.Checked = tblTemplate.Rows(0).Item("Enable").ToString.Trim
                txtLenght.Text = tblTemplate.Rows(0).Item("Lenght").ToString.Trim
                txtStartPosition.Text = tblTemplate.Rows(0).Item("StartPosition").ToString.Trim
                txtEndPosition.Text = tblTemplate.Rows(0).Item("EndPosition").ToString.Trim
            End If
        End Sub

        ' btnUpdate_Click event
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Try
                objBCT.TemplateID = CInt(hidTemplateID.Value)
                objBCT.Enable = ckbEnable.Checked
                objBCT.Lenght = txtLenght.Text
                objBCT.StartPosition = txtStartPosition.Text
                objBCT.EndPosition = txtEndPosition.Text
                objBCT.Enable = ckbEnable.Checked
                objBCT.LibID = clsSession.GlbSite
                objBCT.UpdateHoldingTemplate()


                If CInt(hidTemplateID.Value) > 0 Then ' Update
                    objBCT.TemplateID = CInt(hidTemplateID.Value)
                    objBCT.Name = "CopyNumberTemplate"
                    objBCT.Modifier = clsSession.GlbUserFullName

                    objBCT.TemplateType = 3
                    objBCT.Content = txtFormat.Text.Trim
                    objBCT.UpdateTemplate()

                    ' WriteLog
                    Call WriteLog(39, ddlLabel.Items(0).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Else ' Add new
                    objBCT.Name = "CopyNumberTemplate"
                    objBCT.Creator = clsSession.GlbUserFullName
                    objBCT.Modifier = clsSession.GlbUserFullName

                    objBCT.TemplateType = 3
                    objBCT.Content = txtFormat.Text.Trim

                    objBCT.CreateTemplate()

                    ' WriteLog
                    Call WriteLog(39, ddlLabel.Items(1).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End If



                Page.RegisterClientScriptBlock("AlertJs", "<script language='javascript'>alert('" & ddlLabel.Items(1).Text.Trim & " " & ddlLabel.Items(4).Text.Trim & "');</script>")
            Catch ex As Exception
                Call WriteErrorMssg(ddlLabel.Items(2).Text, ex.Message.Trim, ddlLabel.Items(3).Text, 0)
            End Try
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
        End Sub
    End Class
End Namespace