Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPatternFichDisplay
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblLabel1 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel4 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel0 As System.Web.UI.WebControls.Label

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBCT As New clsBCommonTemplate

        ' Event: Page_Load 
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize all object use in form
        Public Sub Initialize()
            ' Object objBCT 
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.DBServer = Session("DBServer")
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCT.Initialize()
        End Sub

        '  BindJS method
        Private Sub BindJS()
            ' Register Javascript (common and self JS)
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("CatPatternFichDisplayJs", "<script language='javascript' src='../js/Bibliography/WCatPatternFich.js'></script>")

            ' Send TemplateID (ID) to Hidden file ( WCatPatternFichHidden.aspx )
            ddlTemplate.Attributes.Add("Onchange", "if ((this.value=='') || (this.value==0)) {document.forms[0].txtTemplate.value=0} else {document.forms[0].txtTemplate.value=this.value};parent.Hidden.location.href='WCatPatternFichHidden.aspx?ID=' + document.forms[0].txtTemplate.value; CheckPermission(); return false;")

            txtContent.Attributes.Add("OnClick", "javascript:storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnSelect", "javascript:storeCaret(document.Form1.txtContent)")
            txtContent.Attributes.Add("OnKeyup", "javascript:storeCaret(document.Form1.txtContent)")

            ' Preview the Template
            btnView.Attributes.Add("OnClick", "javascript:return(PreviewIt());")

            ' Add New Tag
            btnAddField.Attributes.Add("onclick", "javascript:return(AddTag());")

            ' Clear all textbox on the form
            btnReset.Attributes.Add("onclick", "javascript:document.forms[0].reset();document.forms[0].txtTitle.focus();return false;")

            ' Don't Delete if Combobox' s Value is "Them moi"
            btnDelete.Attributes.Add("OnClick", "if(document.forms[0].ddlTemplate.selectedIndex ==0){alert('Chưa chọn mẫu cần xóa');return false;} return ConfirmDelete('" & ddlLabel.Items(0).Text & "', '" & ddlLabel.Items(15).Text & "');")
            btnUpdate.Attributes.Add("OnClick", "return CheckValidData('" & ddlLabel.Items(4).Text & "')")
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            'Tao khuon dang phich
            If Not CheckPemission(140) Then
                btnUpdate.Enabled = False
            End If
            'PhuongTT 20080905
            'B1
            'Sua khuon dang phich
            If Not CheckPemission(227) Then
                hidUpdateRight.Value = 0
            Else
                hidUpdateRight.Value = 1
            End If
            'E1
            'Xoa khuon dang phich
            If Not CheckPemission(221) Then
                btnDelete.Enabled = False
            End If
        End Sub

        ' Methord: BindData 
        ' Popurse: Method-Load data into ComboBox
        Private Sub BindData()
            Dim tblTemp As DataTable = Nothing
            Dim lsItem As New ListItem

            ' order select All Item
            objBCT.TemplateID = 0

            ' clear data 

            ddlTemplate.DataSource = Nothing
            tblTemp = Nothing
            ddlTemplate.Items.Clear()
            ' The type of the Item called "Mau phich"
            objBCT.TemplateType = 15
            objBCT.LibID = clsSession.GlbSite
            tblTemp = objBCT.GetTemplate ' Get data to display            
         
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlTemplate.DataSource = InsertOneRow(tblTemp, ddlLabel.Items(14).Text)
                ddlTemplate.DataTextField = "Title"
                ddlTemplate.DataValueField = "ID"
                ddlTemplate.DataBind()
            Else
                ' Default -No select: Load String "--Them moi--"
                lsItem.Text = ddlLabel.Items(14).Text
                lsItem.Value = 0
                ddlTemplate.Items.Add(lsItem)
            End If

            ' Clear all Textbox when form load or reload
            txtContent.Text = ""
            txtTitle.Text = ""
            txtHeader.Text = ""
            txtFooter.Text = ""
            txtTemplate.Value = "0"
        End Sub

        ' Event: btnUpdate_Click
        ' Pupose: Update or addnew runat server
        ' Fix Error: Object reference not set to an instance of an object
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim intRetVal As Integer = 1
            Dim strTemplateContent As String
            Dim strTemplateTitle As String

            ' Header
            If Not IsDBNull(txtHeader.Text) Then
                txtHeader.Text = txtHeader.Text.Trim.Replace("' ", "<!--`-->").Replace(Chr(9), "") & Chr(9)
            End If

            ' Content
            If Not IsDBNull(txtContent.Text) Then
                txtContent.Text = txtContent.Text.Trim.Replace("' ", "<!--`-->").Replace(Chr(9), "") & Chr(9)
            End If

            ' Footer
            If Not IsDBNull(txtFooter.Text) Then
                txtFooter.Text = txtFooter.Text.Trim.Replace("' ", "<!--`-->").Replace(Chr(9), "")
            End If

            ' Title
            If Not IsDBNull(txtTitle.Text) Then
                txtTitle.Text = txtTitle.Text.Replace("' ", "<!--`-->")
            End If

            ' Update or insert template
            objBCT.TemplateID = txtTemplate.Value
            objBCT.Content = txtHeader.Text & txtContent.Text & txtFooter.Text
            objBCT.Name = txtTitle.Text.Trim
            objBCT.Modifier = CStr(clsSession.GlbUserFullName)
            objBCT.Creator = CStr(clsSession.GlbUserFullName)
            objBCT.TemplateType = 15
            objBCT.LibID = clsSession.GlbSite
            ' If the ComboBox' Text differ from "--Phich moi---" then Update
            If CInt(txtTemplate.Value) > 0 Then  ' update
                intRetVal = objBCT.UpdateTemplate()
                If intRetVal = 0 Then
                    ' Write log
                    Call WriteLog(18, ddlLabel.Items(13).Text & ddlLabel.Items(7).Text & Trim(txtTemplate.Value) & " : " & txtTitle.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(2).Text & "');</script>")
                Else
                    Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                End If
            Else
                ' The AddNew Action Occur
                If txtTitle.Text.Trim <> "" Then
                    intRetVal = objBCT.CreateTemplate()
                    If intRetVal = 0 Then
                        ' Write log
                        Call WriteLog(18, ddlLabel.Items(13).Text & ddlLabel.Items(6).Text & " " & txtTitle.Text.Trim, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                        ' Success in Update data
                        Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(5).Text & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(9).Text & "');</script>")
                    End If
                End If
            End If

            ' Reload data-Load New data into ComboBox
            Call BindData()
        End Sub

        ' Event: btnDelete_Click
        ' Popurse: Delete selected form run at server
        Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            objBCT.TemplateType = 15 'Template type
            objBCT.TemplateID = txtTemplate.Value
            objBCT.DeleteTemplate()
            ' Write Log
            Call WriteLog(18, ddlLabel.Items(13).Text & ddlLabel.Items(8).Text & ddlLabel.SelectedItem.Value & ":" & ddlLabel.SelectedItem.Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

            ' Alert message
            Page.RegisterClientScriptBlock("AlertJS", "<script language='javascript'>alert('" & ddlLabel.Items(16).Text.Trim & "');</script>")

            ' Reload data-Load for ComboBox
            Call BindData()
        End Sub

        '  Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCT Is Nothing Then
                    objBCT.Dispose(True)
                    objBCT = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub
    End Class
End Namespace