' Class: WManagementArticle
' Puspose: Manage Article of the selected issue
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
'   + 03/10/2004 by Tuanhv
Imports System.IO
Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WManagementArticle
        Inherits clsWBase
        'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents txtSubject As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAuthordt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtNotedt As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtHidden As System.Web.UI.WebControls.Label
        Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBArticle As New clsBArticle
        Private objBCDB As New clsBCommonDBSystem
        Private objBCSP As New clsBCommonDBSystem
        Private intIssueID As Integer

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJs()
            Call BindData()
            If Not Page.IsPostBack Then

                Call BindSubject()
                txtDate.Text = Session("ToDay")
                Call BindDataGrid()
                btnDeleteFile.Attributes.Add("onClick", "if(!confirm('Bạn có thật sự muốn xóa file đính kèm này?')) return false;")
            End If
        End Sub

        ' CheckFormPermission method
        ' Purpose: Check the permission of user
        Private Sub CheckFormPermission()
            If Not CheckPemission(195) Then
                btnInsert.Enabled = False
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            If Session("ItemID") & "" = "" Then
                Response.Redirect("../WSearch.aspx?URL=Article/WManagementArticle.aspx")
            End If

            ' Init objBArticle object
            objBArticle.InterfaceLanguage = Session("InterfaceLanguage")
            objBArticle.DBServer = Session("DBServer")
            objBArticle.ConnectionString = Session("ConnectionString")
            Call objBArticle.Initialize()

            objBCDB.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDB.DBServer = Session("DBServer")
            objBCDB.ConnectionString = Session("ConnectionString")
            Call objBCDB.Initialize()

            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        ' BindJs method
        ' Purpose: include all necessary javascript function
        Private Sub BindJs()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../Js/Article/WManagementArticle.js'></script>")

            btnInsert.Attributes.Add("OnClick", "if (!CheckAll()) {alert('" & lblLabel1.Text & "'); return false;}")
            btnReset.Attributes.Add("OnClick", "document.forms[0].reset(); return false;")
            btnDelete.Attributes.Add("Onclick", "return CheckIssueIDs('" & ddlLabel.Items(8).Text & "');")
            ddlSubject.Attributes.Add("OnChange", "document.forms[0].hid.value=this.options[this.selectedIndex].value;")
            'txtPage.Attributes.Add("onchange", "CheckNumber(this,'" & ddlLabel.Items(4).Text & "');")
            btnClose.Attributes.Add("OnClick", "self.close();")

            Me.RegisterCalendar("../..")
            SetOnclickCalendar(lnkCal, txtDate, ddlLabel.Items(9).Text)
            lnkAdd.NavigateUrl = "javascript:OpenWindow('SubjectAdd.aspx?','Subject',290,150,250,200)"
            lnkUpload.NavigateUrl = "javascript:OpenWindow('WUpLoadManagement.aspx?','UploadManagement',400,150,10,20);"
        End Sub

        ' BindData method
        ' Purpose: Bind data to from
        Sub BindData()
            If lblTitle.Text = "" Then
                lblTitle.Text = "<H3>" & Session("Title") & " -- " & Request("IssueInfor") & "</H3>"
            End If
            btnDelete.Visible = False
            'Chinhnh Add Delete File
            btnDeleteFile.Visible = False
            If Not Request("IssueID") = "" Then
                hidIssueID.Value = Request("IssueID")
                'If Not FileAttach.Text = "" Then

                'End If
            End If
            intIssueID = CInt(hidIssueID.Value)
        End Sub
        Sub BindSubject()
            Dim tblSubject As DataTable
            Dim strSQL As String
            strSQL = "SELECT DISTINCT upper(subject),subject FROM Ser_Subject WHERE Subject IS NOT NULL ORDER BY Subject"
            objBCDB.SQLStatement = strSQL
            tblSubject = objBCDB.RetrieveItemInfor()
            If Not tblSubject Is Nothing AndAlso tblSubject.Rows.Count > 0 Then
                ddlSubject.DataSource = tblSubject
                ddlSubject.DataTextField = "subject"
                ddlSubject.DataValueField = "subject"
                ddlSubject.DataBind()
            End If
        End Sub
        ' btnInsert_Click event
        ' Purpose: Simle call create
        Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
            If CInt(hidIDtd.Value) = 0 Then
                Call Create()
            Else
                Call Update()
                hidIDtd.Value = "0"
            End If
        End Sub

        ' Create method
        ' Purpose: Create article record
        Sub Create()
            Try
                objBArticle.IssueID = intIssueID
                objBArticle.Name = txtName.Text.Trim
                objBArticle.Author = txtAuthor.Text.Trim
                If hid.Value <> "" Then
                    objBArticle.Subject = hid.Value
                Else
                    objBArticle.Subject = ddlSubject.SelectedValue
                End If
                objBArticle.Page = txtPage.Text.Trim
                objBArticle.Note = txtNote.Text.Trim
                objBArticle.CreatedDate = txtDate.Text.Trim
                objBArticle.FileAttack = FileAttach.Text.Trim
                objBArticle.Create()

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBArticle.ErrorMsg, ddlLabel.Items(1).Text, objBArticle.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                ' Reset form
                txtAuthor.Text = ""
                txtName.Text = ""
                txtPage.Text = ""
                txtNote.Text = ""
                txtDate.Text = ""
                FileAttach.Text = ""
                dgrResult.EditItemIndex = -1
                Call BindDataGrid()
                Call BindSubject()
            Catch
            End Try
        End Sub

        ' BindDataGrid method
        ' Purpose: Show data on datagrid
        Sub BindDataGrid()
            Dim tblResult As DataTable
            Dim intItem As Integer
            Dim intCount As Integer

            objBArticle.IssueID = intIssueID
            tblResult = objBArticle.GetArticleInfor
            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBArticle.ErrorMsg, ddlLabel.Items(1).Text, objBArticle.ErrorCode)
            dgrResult.Visible = False
            If Not tblResult Is Nothing Then
                If tblResult.Rows.Count > 0 Then
                    intCount = CInt(tblResult.Rows.Count / dgrResult.PageSize)
                    intItem = intCount * dgrResult.PageSize
                    If intItem = tblResult.Rows.Count Then
                        If dgrResult.CurrentPageIndex > intCount - 1 Then
                            dgrResult.CurrentPageIndex = dgrResult.CurrentPageIndex - 1
                        End If
                    End If
                    dgrResult.DataSource = tblResult
                    dgrResult.DataBind()
                    btnDelete.Visible = True
                    'chinhnh add 06/10/08

                    hidIssueIDCount.Value = tblResult.Rows.Count + 3
                    dgrResult.Visible = True
                End If
            End If
            tblResult = Nothing
        End Sub

        ' Delete method
        ' Purpose: Delete some article record
        Function Delete() As Boolean
            Dim intCount As Integer = 0
            Dim strIDs As String = ""
            Dim strID As String = ""
            Dim arrIDs() As String
            Dim inti As Integer
            For intCount = 0 To dgrResult.Items.Count - 1
                If CType(dgrResult.Items(intCount).Cells(7).FindControl("chkIssueID"), CheckBox).Checked Then
                    strID = CType(dgrResult.Items(intCount).Cells(1).FindControl("lblIDdt"), Label).Text
                    strIDs = strIDs & strID & ","
                End If
            Next

            If Not strIDs = "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                'Delete file Attach
                Dim strSQL As String = ""
                Dim tblSer As DataTable
                Dim strPath As String = Server.MapPath("../FileUpload/")
                Dim file As FileInfo
                If strIDs <> "" Then
                    arrIDs = strIDs.Split(",")
                    For inti = 0 To arrIDs.Length - 1
                        strSQL = "SELECT IMAGEURL FROM Ser_tblArticle WHERE ID=" & arrIDs(inti)
                        objBCSP.SQLStatement = strSQL
                        tblSer = objBCSP.RetrieveItemInfor()
                        If Not tblSer Is Nothing AndAlso tblSer.Rows.Count > 0 Then
                            strPath = strPath & tblSer.Rows(0).Item("ImageURL")
                            Try
                                file = New FileInfo(strPath)
                                If file.Exists Then
                                    file.Delete()
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End If
                objBArticle.IDs = strIDs
                Delete = objBArticle.Delete()
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBArticle.ErrorMsg, ddlLabel.Items(1).Text, objBArticle.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(6).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                Call BindDataGrid()
            Else
                Page.RegisterClientScriptBlock("FailJs", "<script language = 'javascript'>alert('" & lblLabel2.Text & "');</script>")
                btnDelete.Visible = True
                'chinhnh add 06/10/08

            End If
        End Function

        ' btnDelete_Click event
        ' Purpose: Simple call delete method
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Call Delete()
            Call BindDataGrid()
        End Sub

        ' dgrResult_EditCommand event
        Private Sub dgrResult_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrResult.EditCommand
            Try
                dgrResult.EditItemIndex = CInt(e.Item.ItemIndex)
                hidIDtd.Value = CStr(CType(e.Item.Cells(1).FindControl("lblIDdt"), Label).Text)
                txtName.Text = CStr(CType(e.Item.Cells(2).FindControl("lblNamedt"), Label).Text)
                txtAuthor.Text = CStr(CType(e.Item.Cells(3).FindControl("lblAuthordt"), Label).Text)
                ddlSubject.DataTextField = CStr(CType(e.Item.Cells(4).FindControl("lblSubjectdt"), Label).Text)
                ddlSubject.DataValueField = CStr(CType(e.Item.Cells(4).FindControl("lblSubjectdt"), Label).Text)
                txtDate.Text = CStr(CType(e.Item.Cells(5).FindControl("lblCreatedDate"), Label).Text)
                txtPage.Text = CStr(CType(e.Item.Cells(6).FindControl("lblPagedt"), Label).Text)
                txtNote.Text = CStr(CType(e.Item.Cells(7).FindControl("lblNotedt"), Label).Text)
                FileAttach.Text = CStr(CType(e.Item.Cells(8).FindControl("lblImageURL"), Label).Text)

                If Not FileAttach.Text = "" Then
                    btnDeleteFile.Visible = True
                End If
            Catch ex As Exception
            End Try
        End Sub
        Sub Update()
            objBArticle.IssueID = intIssueID
            objBArticle.ID = CInt(hidIDtd.Value)
            objBArticle.Name = txtName.Text.Trim
            objBArticle.Author = txtAuthor.Text.Trim
            If hid.Value <> "" Then
                objBArticle.Subject = hid.Value
            Else
                objBArticle.Subject = ddlSubject.SelectedValue
            End If
            objBArticle.Page = txtPage.Text.Trim
            objBArticle.Note = txtNote.Text.Trim
            objBArticle.CreatedDate = txtDate.Text.Trim
            objBArticle.FileAttack = FileAttach.Text.Trim
            ' objBArticle.CreatedDate = txtDate.Text.Trim
            ' Update now
            Call objBArticle.Update()

            ' Write error
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBArticle.ErrorMsg, ddlLabel.Items(1).Text, objBArticle.ErrorCode)

            ' WriteLog
            Call WriteLog(34, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)


            ' Reset form
            txtAuthor.Text = ""
            txtName.Text = ""
            txtPage.Text = ""
            txtNote.Text = ""
            txtDate.Text = ""
            FileAttach.Text = ""
            Call BindDataGrid()
            Call BindSubject()
        End Sub
        ' dgrResult_ItemCommand event
        Private Sub dgrResult_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrResult.ItemCommand
            Dim strJS As String
            Dim strCmd As String = ""
            Dim objLabel As New Label
            Dim strMark As String = ""
            strCmd = UCase(e.CommandName)
        End Sub

        ' dgrResult_UpdateCommand event
        ' Purpose: Update data of the selected article
        Private Sub dgrResult_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrResult.UpdateCommand
            Try
                objBArticle.IssueID = intIssueID
                objBArticle.ID = CInt(CType(e.Item.Cells(1).FindControl("lblIDdt"), Label).Text)
                objBArticle.Name = CStr(CType(e.Item.Cells(2).FindControl("txtNamedt"), TextBox).Text)
                objBArticle.Author = CStr(CType(e.Item.Cells(3).FindControl("txtAuthordt"), TextBox).Text)
                objBArticle.Subject = CStr(CType(e.Item.Cells(4).FindControl("txtSubjectdt"), TextBox).Text)
                objBArticle.Page = CStr(CType(e.Item.Cells(5).FindControl("txtPagedt"), TextBox).Text)
                objBArticle.Note = CStr(CType(e.Item.Cells(6).FindControl("txtNotedt"), TextBox).Text)

                ' Update now
                Call objBArticle.Update()

                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBArticle.ErrorMsg, ddlLabel.Items(1).Text, objBArticle.ErrorCode)

                ' WriteLog
                Call WriteLog(34, ddlLabel.Items(5).Text, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                dgrResult.EditItemIndex = -1
                Call BindDataGrid()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dgrResult_CancelCommand
        Private Sub dgrResult_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrResult.CancelCommand
            Try
                dgrResult.EditItemIndex = -1
                Call BindDataGrid()
            Catch ex As Exception
            End Try
        End Sub

        ' Event: dgrResult_ItemCreated
        Private Sub dgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.EditItem, ListItemType.Item, ListItemType.AlternatingItem
                    Dim txtNamedtTemp As TextBox
                    Dim txtAuthordtTemp As TextBox
                    Dim txtSubjectdtTemp As TextBox
                    Dim txtPagedtTemp As TextBox
                    Dim lnkdtgUpdate As LinkButton

                    txtPagedtTemp = CType(e.Item.FindControl("txtPagedt"), TextBox)

                    lnkdtgUpdate = CType(e.Item.FindControl("lnkbtnUpdate"), LinkButton)
                    If Not lnkdtgUpdate Is Nothing Then
                        lnkdtgUpdate.Attributes.Add("OnClick", "javascript:return(CheckInserUpdate('document.forms[0].dgrResult__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & ddlLabel.Items(7).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dgrResult_PageIndexChanged
        Private Sub dgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrResult.PageIndexChanged
            Try
                dgrResult.CurrentPageIndex = e.NewPageIndex
                Call BindDataGrid()
            Catch ex As Exception
            End Try
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBArticle Is Nothing Then
                    objBArticle.Dispose(True)
                    objBArticle = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Private Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        '    hid.Value = ddlSubject.SelectedValue
        'End Sub

        Private Sub btnDeleteFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteFile.Click
            If FileAttach.Text <> "" Then
                Dim strPath As String = Server.MapPath("../FileUpload/")
                Dim strFilePath = strPath + FileAttach.Text
                If File.Exists(strFilePath) Then
                    File.Delete(strFilePath)
                    FileAttach.Text = ""
                End If
                FileAttach.Text = ""
            End If
        End Sub
    End Class
End Namespace