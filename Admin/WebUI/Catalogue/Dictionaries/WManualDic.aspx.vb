' Class: WManualDic
' Propose: Management manual dictionaries
' CreatedDate: 26/05/2005
' Creator: Oanhtn
'  Modification history 

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WManualDic
        Inherits clsWBase
        Implements IUCNumberOfRecord
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidSizeDic As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Delclare variables
        Private objBCatDiclist As New clsBCatDicList
        Private objBDicSelfMade As New clsBDictionarySelfMade

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Method: Initialze
        ' Purpose: Init all object use in form
        Private Sub Initialze()
            ' Init objBCatDiclist object 
            objBCatDiclist.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDiclist.DBServer = Session("DbServer")
            objBCatDiclist.ConnectionString = Session("ConnectionString")
            Call objBCatDiclist.Initialize()

            ' Init objBDicSelfMade object
            objBDicSelfMade.InterfaceLanguage = Session("InterfaceLanguage")
            objBDicSelfMade.DBServer = Session("DbServer")
            objBDicSelfMade.ConnectionString = Session("ConnectionString")
            Call objBDicSelfMade.Initialize()
        End Sub

        ' Method: BindJS
        ' Purpose: include all neccessary javascript functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicAuthority.js'></script>")

            txtFieldSizeDic.Attributes.Add("OnChange", "if (!CheckValueSize(this, '" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(8).Text & "')) {this.value='0'; this.focus();}")
            btnNewDic.Attributes.Add("onClick", "return CheckInput('" & ddlLabel.Items(5).Text & "');")
        End Sub

        ' Method: CheckFormPermission
        ' Purpose: check permission
        Private Sub CheckFormPermission()

            If Not CheckPemission(147) And Not CheckPemission(8) And Not CheckPemission(169) And Not CheckPemission(170) And Not CheckPemission(171) Then
                Call WriteErrorMssg(ddlLabel.Items(9).Text)
            Else
                'Quyen quan ly 
                If Not CheckPemission(147) Then
                    ' View entries
                    If Not CheckPemission(8) Then
                        dtgDicSelfMade.Columns(5).Visible = False
                    End If
                    ' New dictionary
                    If Not CheckPemission(169) Then
                        btnNewDic.Enabled = False
                    End If
                    ' Update dictionary
                    If Not CheckPemission(170) Then
                        dtgDicSelfMade.Columns(5).Visible = False
                    End If
                    ' Delete dictionary
                    If Not CheckPemission(171) Then
                        dtgDicSelfMade.Columns(6).Visible = False
                    End If
                End If
            End If
        End Sub

        ' Method: BindData
        Private Sub BindData()
            Dim tblTemp As DataTable
            Dim intCount As Integer
            objBCatDiclist.SystemDic = 0
            objBCatDiclist.IsAuthority = -1
            objBCatDiclist.IsClassifiCation = -1
            objBCatDiclist.LibID = clsSession.GlbSite
            tblTemp = objBCatDiclist.Retrieve()
            If Not tblTemp Is Nothing Then
                If tblTemp.Rows.Count > 0 Then
                    intCount = Math.Ceiling(tblTemp.Rows.Count / dtgDicSelfMade.PageSize)
                    If dtgDicSelfMade.CurrentPageIndex >= intCount Then
                        dtgDicSelfMade.CurrentPageIndex = dtgDicSelfMade.CurrentPageIndex - 1
                    End If
                End If
                dtgDicSelfMade.DataSource = tblTemp
                'dtgDicSelfMade.DataBind()
            End If
        End Sub

        ' Event: dtgDicSelfMade_PageIndexChanged
        'Private Sub dtgDicSelfMade_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgDicSelfMade.PageIndexChanged
        '    dtgDicSelfMade.CurrentPageIndex = e.NewPageIndex
        '    Call BindData()
        'End Sub

        ' Event: dtgDicSelfMade_EditCommand
        'Private Sub dtgDicSelfMade_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicSelfMade.EditCommand
        '    dtgDicSelfMade.EditItemIndex = e.Item.ItemIndex
        '    Call BindData()
        'End Sub

        ' Event: dtgDicSelfMade_UpdateCommand
        'Private Sub dtgDicSelfMade_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicSelfMade.UpdateCommand
        '    Dim bytForStaff As Byte
        '    Dim bytForPatron As Byte
        '    Dim intFieldSize As Integer
        '    Dim intRet As Integer

        '    If CType(e.Item.Cells(2).FindControl("chkForStaffE"), CheckBox).Checked Then
        '        bytForStaff = 1
        '    Else
        '        bytForStaff = 0
        '    End If
        '    If CType(e.Item.Cells(3).FindControl("chkForPatronE"), CheckBox).Checked Then
        '        bytForPatron = 1
        '    Else
        '        bytForPatron = 0
        '    End If
        '    If IsNumeric(CType(e.Item.Cells(4).FindControl("txtFieldSize"), TextBox).Text) Then
        '        intFieldSize = CInt(CType(e.Item.Cells(4).FindControl("txtFieldSize"), TextBox).Text)
        '    End If
        '    objBDicSelfMade.ID = CType(e.Item.Cells(0).FindControl("lblID"), Label).Text
        '    objBDicSelfMade.TableName = CType(e.Item.Cells(1).FindControl("txtName"), TextBox).Text
        '    objBDicSelfMade.ForPatron = bytForPatron
        '    objBDicSelfMade.ForStaff = bytForStaff
        '    objBDicSelfMade.FieldSize = intFieldSize
        '    intRet = objBDicSelfMade.ChangeDic()
        '    dtgDicSelfMade.EditItemIndex = -1
        '    Call BindData()
        'End Sub

        ' Event: dtgDicSelfMade_CancelCommand
        'Private Sub dtgDicSelfMade_CancelCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dtgDicSelfMade.CancelCommand
        '    dtgDicSelfMade.EditItemIndex = -1
        '    Call BindData()
        'End Sub

        'Event: dtgDicSelfMade_DeleteCommand
        'Private Sub dtgDicSelfMade_DeleteCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dtgDicSelfMade.DeleteCommand
        '    objBDicSelfMade.ID = CInt(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)
        '    Call objBDicSelfMade.DropDictionary()
        '    Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Xóa từ điển tự tạo thành công')</script>")
        '    Call BindData()
        'End Sub

        ' Event: btnNewDic_Click
        ' Purpose: new manual dictionary
        Private Sub btnNewDic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewDic.Click
            Dim intRET As Integer
            Dim bytStaff As Byte
            Dim bytPatron As Byte
            Dim strJS
            If chkStaff.Checked Then
                bytStaff = 1
            Else
                bytStaff = 0
            End If
            If chkPatron.Checked Then
                bytPatron = 1
            Else
                bytPatron = 0
            End If
            objBDicSelfMade.NameDic = txtNameDic.Text.Trim
            objBDicSelfMade.ForPatron = bytPatron
            objBDicSelfMade.ForStaff = bytStaff
            objBDicSelfMade.FieldSize = CInt(txtFieldSizeDic.Text.Trim)
            objBDicSelfMade.LibID = clsSession.GlbSite
            intRET = objBDicSelfMade.CreateDictionary
            Select Case intRET
                Case 0 ' exist dicName in database
                    strJS = ddlLabel.Items(2).Text
                Case 1 ' OK !
                    strJS = ddlLabel.Items(3).Text
                    txtNameDic.Text = ""
                    txtFieldSizeDic.Text = 0
            End Select
            Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('" & strJS & "')</script>")
            Call BindData()
            dtgDicSelfMade.Rebind()
        End Sub

        ' Event: dtgDicSelfMade_ItemCreated
        Private Sub dtgDicSelfMade_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dtgDicSelfMade.ItemCreated

            'Select Case e.Item.ItemType
            '    Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
            '        Dim myTableCell As TableCell
            '        myTableCell = e.Item.Cells(6)
            '        Dim myDeleteButton As LinkButton
            '        Dim myUpdateButton As LinkButton = TryCast(e.Item.FindControl("lnkBudgetName"), LinkButton)
            '        myDeleteButton = myTableCell.Controls(0)
            '        myDeleteButton.Attributes.Add("onclick", "if (confirm('" & ddlLabel.Items(4).Text & "')==false) {return false}")

            '        myUpdateButton.Attributes.Add("Onclick", "return (CheckDicManualUpdate('document.forms[0].dtgDicSelfMade__ctl" & CStr(e.Item.ItemIndex + 3) & "_','" & ddlLabel.Items(5).Text & "','" & ddlLabel.Items(6).Text & "','" & ddlLabel.Items(7).Text & "','" & ddlLabel.Items(8).Text & "'," & DataBinder.Eval(e.Item.DataItem, "FieldSize") & "));")

            'End Select
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCatDiclist Is Nothing Then
                        objBCatDiclist.Dispose(True)
                        objBCatDiclist = Nothing
                    End If
                    If Not objBDicSelfMade Is Nothing Then
                        objBDicSelfMade.Dispose(True)
                        objBDicSelfMade = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Dispose()
            End Try
        End Sub

        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

        Protected Sub dtgDicSelfMade_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgDicSelfMade.NeedDataSource
            BindData()

        End Sub

        Protected Sub dtgDicSelfMade_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgDicSelfMade.DeleteCommand
            objBDicSelfMade.ID = CInt(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)
            Call objBDicSelfMade.DropDictionary()
            Page.RegisterClientScriptBlock("JSAlert", "<script language = 'javascript'>alert('Xóa từ điển tự tạo thành công')</script>")
            Call BindData()
            dtgDicSelfMade.Rebind()
        End Sub

        Protected Sub dtgDicSelfMade_UpdateCommand(sender As Object, e As GridCommandEventArgs) Handles dtgDicSelfMade.UpdateCommand
            Dim bytForStaff As Byte
            Dim bytForPatron As Byte
            Dim intFieldSize As Integer
            Dim intRet As Integer

            If CType(e.Item.Cells(2).FindControl("chkForStaffE"), CheckBox).Checked Then
                bytForStaff = 1
            Else
                bytForStaff = 0
            End If
            If CType(e.Item.Cells(3).FindControl("chkForPatronE"), CheckBox).Checked Then
                bytForPatron = 1
            Else
                bytForPatron = 0
            End If
            If IsNumeric(CType(e.Item.Cells(4).FindControl("txtFieldSize"), TextBox).Text) Then
                intFieldSize = CInt(CType(e.Item.Cells(4).FindControl("txtFieldSize"), TextBox).Text)
            End If
            objBDicSelfMade.ID = CType(e.Item.Cells(0).FindControl("lblID"), Label).Text
            objBDicSelfMade.TableName = CType(e.Item.Cells(1).FindControl("txtName"), TextBox).Text
            objBDicSelfMade.ForPatron = bytForPatron
            objBDicSelfMade.ForStaff = bytForStaff
            objBDicSelfMade.FieldSize = intFieldSize
            intRet = objBDicSelfMade.ChangeDic()

            Call BindData()
        End Sub

        '     Event: dtgDicSelfMade_CancelCommand
        'Private Sub dtgDicSelfMade_CancelCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles dtgDicSelfMade.CancelCommand
        '    dtgDicSelfMade.EditItemIndex = -1
        '    Call BindData()
        'End Sub
    End Class
End Namespace