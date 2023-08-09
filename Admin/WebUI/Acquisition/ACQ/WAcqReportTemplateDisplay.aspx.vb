' Class: WAcqReportTemplateDisplay
' Puspose: Manager AcquisitionTemplate
' Creator: Sondp
' CreatedDate: 20/02/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WAcqReportTemplateDisplay
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblColor As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddNew As System.Web.UI.WebControls.Label
        Protected WithEvents lblDeleteConfirm As System.Web.UI.WebControls.Label
        Protected WithEvents lblEmtyTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateUnSuccessful As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCommonTemplate As New clsBCommonTemplate
        Private objBCDBS As New clsBCommonDBSystem

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub
        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            ' Khuon dang bao cao bo sung
            If Not CheckPemission(138) Then
                btnUpdate.Enabled = False
                btnDelete.Enabled = False
            End If
        End Sub
        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initialize objBCommonTemplate object
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            Call objBCommonTemplate.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            Call objBCDBS.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: Include all need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WAcqReportTemplateDJs", "<script language='javascript' src='../Js/ACQ/WAcqReportTemplate.js'></script>")

            ddlID.Attributes.Add("onchange", "javascript:Encryption(); ChangeTemplate(); Decryption(); return false;")

            btnAdd.Attributes.Add("onclick", "javascript:AddItem(); return false;")
            btnRemove.Attributes.Add("onclick", "javascript:RemoveItem(); return false;")
            btnDelete.Attributes.Add("OnClick", "javascript:Encryption(); return(AskDelete('" & ddlLabel.Items(6).Text & "', '" & ddlLabel.Items(11).Text & "')); Decryption();")
            btnUpdate.Attributes.Add("OnClick", "javascript:Encryption(); return(CheckValidData('" & ddlLabel.Items(10).Text & "'));Decryption();")
            btnPreview.Attributes.Add("OnClick", "javascript:Encryption();PreviewTemplate();Decryption(); return false;")
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim listItem As New ListItem

            Try
                objBCommonTemplate.TemplateID = 0
                objBCommonTemplate.TemplateType = 11
                objBCommonTemplate.LibID = clsSession.GlbSite
                tblTemplate = objBCommonTemplate.GetTemplate
                If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                    ddlID.DataSource = objBCDBS.InsertOneRow(tblTemplate, ddlLabel.Items(5).Text)
                    ddlID.DataValueField = "ID"
                    ddlID.DataTextField = "Title"
                    ddlID.DataBind()
                Else
                    listItem.Value = 0
                    listItem.Text = ddlLabel.Items(5).Text
                    ddlID.Items.Add(listItem)
                End If
                txtCollumCaption.Text = ""
                txtCollum.Value = ""
                txtHeader.Text = ""
                txtPageHeader.Text = ""
                txtCaption.Text = ""
                txtCollumWidth.Text = ""
                txtAlign.Text = ""
                txtFormat.Text = ""
                txtTableColor.Text = ""
                txtEventColor.Text = ""
                txtOddColor.Text = ""
                txtPageFooter.Text = ""
                txtFooter.Text = ""
                hdCollumCaptionText.Value = ""
                hdMax.Value = 0
            Catch ex As Exception
                Response.Write(ex.Message)
            End Try
        End Sub

        ' Event: btnDelete_Click
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim strTemplate As String

            Try
                strTemplate = ddlID.SelectedItem.Text
                objBCommonTemplate.TemplateType = 11
                If ddlID.SelectedValue > 0 Then
                    objBCommonTemplate.TemplateID = ddlID.SelectedValue
                    objBCommonTemplate.DeleteTemplate()
                Else
                    Page.RegisterClientScriptBlock("DeleteSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                End If

            Catch ex As Exception
                Response.Write(ex.Message)
            Finally
                ' WriteLog
                Page.RegisterClientScriptBlock("DeleteSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(12).Text & "');</script>")
                Call WriteLog(39, ddlLabel.Items(2).Text & ":" & strTemplate, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                Call BindData()
            End Try
        End Sub

        ' Event: btnUpdate_Click
        Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim strContent As String
            Dim arrCollumCaption() As String
            Dim arrCollumText() As String
            Dim strCollumCaption As String
            Dim inti As Integer
            Dim intj As Integer

            ' Add data if user no get infomation about column name, align, format, width
            arrCollumCaption = Split(txtCollumCaption.Text.Replace("&lt;", "<").Replace("&gt;", ">"), vbCrLf)
            arrCollumText = Split(hdCollumCaptionText.Value, "<~>")
            If UBound(arrCollumCaption) < UBound(arrCollumText) Then
                ReDim Preserve arrCollumCaption(UBound(arrCollumText))
            End If
            For inti = LBound(arrCollumText) To UBound(arrCollumText)
                If arrCollumCaption(inti) = "" Then
                    arrCollumCaption(inti) = arrCollumText(inti)
                End If
                strCollumCaption &= arrCollumCaption(inti) & "<~>"
            Next
            If Len(strCollumCaption) > 2 Then
                strCollumCaption = Left(strCollumCaption, Len(strCollumCaption) - 3)
            End If
            If txtCollumWidth.Text = "" Then
                intj = 0
            Else
                intj = UBound(Split(txtCollumWidth.Text, vbCrLf))
            End If
            For inti = intj To CInt(hdMax.Value)
                txtCollumWidth.Text &= vbCrLf
            Next
            If txtAlign.Text = "" Then
                intj = 0
            Else
                intj = UBound(Split(txtAlign.Text, vbCrLf))
            End If
            For inti = intj To CInt(hdMax.Value)
                txtAlign.Text &= vbCrLf
            Next
            If txtFormat.Text = "" Then
                intj = 0
            Else
                intj = UBound(Split(txtFormat.Text, vbCrLf))
            End If
            For inti = intj To CInt(hdMax.Value)
                txtFormat.Text &= vbCrLf
            Next
            strContent = strContent & txtHeader.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "") & Chr(9) & txtPageHeader.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtCollum.Value & Chr(9) & txtCollumCaption.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtCollumWidth.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtAlign.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtFormat.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtTableColor.Text.Replace("'", "") & Chr(9) & txtEventColor.Text.Replace("'", "") & Chr(9) & txtOddColor.Text.Replace("'", "") & Chr(9) & txtPageFooter.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtFooter.Text.Replace(vbCrLf, "<~>").Replace(Chr(9), "")
            objBCommonTemplate.TemplateID = ddlID.SelectedItem.Value
            objBCommonTemplate.Content = Replace(strContent, "'", "")
            objBCommonTemplate.Name = Replace(txtCaption.Text, "'", "")
            objBCommonTemplate.Modifier = CStr(clsSession.GlbUserFullName)
            objBCommonTemplate.Creator = CStr(clsSession.GlbUserFullName)
            objBCommonTemplate.TemplateType = 11
            objBCommonTemplate.LibID = clsSession.GlbSite
            If ddlID.SelectedItem.Value > 0 Then ' Update
                Try
                    objBCommonTemplate.UpdateTemplate()
                    Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(8).Text & "');</script>")

                Catch ex As Exception
                    Response.Write(ex.Message)
                    Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                Finally
                    ' WriteLog
                    Call WriteLog(39, ddlLabel.Items(1).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Try
            Else ' Addnew
                Try
                    Dim result = objBCommonTemplate.CreateTemplate()
                    If result = 0 Then
                        Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('Cập nhật thành công');</script>")
                    Else
                        Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('Đã tồn tại mẫu báo cáo');</script>")
                    End If

                Catch ex As Exception
                    Response.Write(ex.Message)
                    Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('Không thể tạo mới mẫu báo cáo');</script>")
                Finally
                    ' WriteLog
                    Call WriteLog(39, ddlLabel.Items(0).Text & ": " & txtCaption.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)
                End Try
            End If
            Call BindData()
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCommonTemplate Is Nothing Then
                objBCommonTemplate.Dispose(True)
                objBCommonTemplate = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
    End Class
End Namespace