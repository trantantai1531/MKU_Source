' class 
' Puspose: 
' Creator: Sondp
' CreatedDate: 20/02/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Public Class WAcqReportTemlateDisplay
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblMainTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblCaption As System.Web.UI.WebControls.Label
        Protected WithEvents txtCaption As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents txtHeader As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblPageHeader As System.Web.UI.WebControls.Label
        Protected WithEvents txtPageHeader As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblList As System.Web.UI.WebControls.Label
        Protected WithEvents lsbTemp As System.Web.UI.WebControls.ListBox
        Protected WithEvents lblAllCollums As System.Web.UI.WebControls.Label
        Protected WithEvents lblCollum As System.Web.UI.WebControls.Label
        Protected WithEvents lblCollumCaption As System.Web.UI.WebControls.Label
        Protected WithEvents lblCollumWidth As System.Web.UI.WebControls.Label
        Protected WithEvents lblAlign As System.Web.UI.WebControls.Label
        Protected WithEvents lblFormat As System.Web.UI.WebControls.Label
        Protected WithEvents lsbAllCollums As System.Web.UI.WebControls.ListBox
        Protected WithEvents btnAdd As System.Web.UI.WebControls.Button
        Protected WithEvents btnRemove As System.Web.UI.WebControls.Button
        Protected WithEvents lsbCollum As System.Web.UI.WebControls.ListBox
        Protected WithEvents txtCollumCaption As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtCollumWidth As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAlign As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtFormat As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblColor As System.Web.UI.WebControls.Label
        Protected WithEvents lblTableColor As System.Web.UI.WebControls.Label
        Protected WithEvents txtTableColor As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblPickTableColor As System.Web.UI.WebControls.Label
        Protected WithEvents lblOddColor As System.Web.UI.WebControls.Label
        Protected WithEvents txtOddColor As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblPickOddColor As System.Web.UI.WebControls.Label
        Protected WithEvents lblEventColor As System.Web.UI.WebControls.Label
        Protected WithEvents txtEventColor As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblPickEventColor As System.Web.UI.WebControls.Label
        Protected WithEvents lblPageFooter As System.Web.UI.WebControls.Label
        Protected WithEvents txtPageFooter As System.Web.UI.WebControls.TextBox
        Protected WithEvents lblFoter As System.Web.UI.WebControls.Label
        Protected WithEvents txtFooter As System.Web.UI.WebControls.TextBox
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
        Protected WithEvents btnPreview As System.Web.UI.WebControls.Button
        Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
        Protected WithEvents txtCollum As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents Label2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblAddNew As System.Web.UI.WebControls.Label
        Protected WithEvents ddlID As System.Web.UI.WebControls.DropDownList
        Protected WithEvents lblDeleteConfirm As System.Web.UI.WebControls.Label
        Protected WithEvents lblEmtyTitle As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents lblUpdateUnSuccessful As System.Web.UI.WebControls.Label
        Protected WithEvents hdCollumCaptionText As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hdMax As System.Web.UI.HtmlControls.HtmlInputHidden

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBCT As New clsBCommonTemplate
        Private objBCDBS As New clsBCommonDBSystem
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.Initialize()
            ' Initialize objBCDBS object
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WAcqReportTemplateDJs", "<script language='javascript' src='../Js/ACQ/WAcqReportTemplate.js'></script>")
            ddlID.Attributes.Add("onchange", "javascript:Encryption();ChangeTemplate();Decryption();return(false);")
            btnAdd.Attributes.Add("onclick", "javascript:AddItem();return(false);")
            btnRemove.Attributes.Add("onclick", "javascript:RemoveItem();return(false);")
            btnDelete.Attributes.Add("OnClick", "javascript:Encryption();return(AskDelete('" & lblDeleteConfirm.Text & "'));Decryption();")
            btnUpdate.Attributes.Add("OnClick", "javascript:Encryption();return(CheckValidData('" & lblEmtyTitle.Text & "'));Decryption();")
            btnPreview.Attributes.Add("OnClick", "javascript:Encryption();PreviewTemplate();Decryption();return(false);")
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblTemplate As New DataTable
            Dim listItem As New listItem
            Try
                objBCT.TemplateID = 0
                objBCT.TemplateType = 11
                tblTemplate = objBCT.GetTemplate
                If Not tblTemplate Is Nothing Then
                    If tblTemplate.Rows.Count > 0 Then
                        ddlID.DataSource = objBCDBS.InsertOneRow(tblTemplate, lblAddNew.Text)
                        ddlID.DataValueField = "ID"
                        ddlID.DataTextField = "Title"
                        ddlID.DataBind()
                    Else
                        listItem.Value = 0
                        listItem.Text = lblAddNew.Text
                        ddlID.Items.Add(listItem)
                    End If
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
            End Try
        End Sub

        ' Delete Template method
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Try
                objBCT.TemplateType = 11
                objBCT.TemplateID = ddlID.SelectedValue
                objBCT.DeleteTemplate()
            Catch ex As Exception
            Finally
                Call BindData()
            End Try
        End Sub

        ' Update or CreateNew Template method
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
            strContent = strContent & txtHeader.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtPageHeader.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtCollum.Value & Chr(9) & txtCollumCaption.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtCollumWidth.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtAlign.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtFormat.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtTableColor.Text.Replace("'", "") & Chr(9) & txtEventColor.Text.Replace("'", "") & Chr(9) & txtOddColor.Text.Replace("'", "") & Chr(9) & txtPageFooter.Text.Replace(vbCrLf, "<~>") & Chr(9) & txtFooter.Text.Replace(vbCrLf, "<~>")
            objBCT.TemplateID = ddlID.SelectedItem.Value
            objBCT.Content = Replace(strContent, "'", "")
            objBCT.Name = Replace(txtCaption.Text, "'", "")
            objBCT.Modifier = CStr(clsSession.GlbUserFullName)
            objBCT.Creator = CStr(clsSession.GlbUserFullName)
            objBCT.TemplateType = 11
            If ddlID.SelectedItem.Value > 0 Then ' Update
                Try
                    objBCT.UpdateTemplate()
                    Page.RegisterClientScriptBlock("UpdateSuccessfulJs", "<script language='javascript'>alert('" & lblUpdateSuccessful.Text & "');</script>")
                Catch ex As Exception
                    Page.RegisterClientScriptBlock("UpdateUnSuccessfulJs", "<script language='javascript'>alert('" & lblUpdateUnSuccessful.Text & "');</script>")

                End Try
            Else ' Addnew
                Try
                    objBCT.CreateTemplate()
                Catch ex As Exception
                End Try
            End If
            Call BindData()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
    End Class
End Namespace