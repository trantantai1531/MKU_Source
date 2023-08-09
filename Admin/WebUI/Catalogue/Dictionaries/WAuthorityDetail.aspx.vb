' Class: WAuthorityDetail
' Propose:
' CreatedDate: 19/04/2004
' Creator: Sondp.
'  Modification history 
'    - 02/03/2005 by Tuanhv: review
'    - 12/05/2005 by Lent: review

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.WebUI.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WAuthorityDetail
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private objBCatDiclist As New clsBCatDicList
        Private objBDictionary As New clsBDictionary

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialze()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call CheckDic()
                Call ReadTableDicName()
                Call LoadData("")
            End If
            Call LoadTitle()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            ' View entries
            If Not CheckPemission(8) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
            'Xoa muc tu tu dien
            If Not CheckPemission(7) Then
                dtgDicIndex.Columns(1).Visible = False
                btnGroup.Enabled = False
            End If
            ' Update entry
            If Not CheckPemission(6) Then
                dtgDicIndex.Columns(9).Visible = False
            End If
        End Sub

        ' CheckDic method
        ' Purpose: Check the dictionary to visible some rows
        Private Sub CheckDic()

            Select Case Request.QueryString("intID")
                Case 10, 11 ' Cat_tblDic_Language, Cat_tblDic_Country
                    dtgDicIndex.Columns(3).Visible = True
                    dtgDicIndex.Columns(4).Visible = True
                    dtgDicIndex.Columns(5).Visible = True
                Case 4  ' BBK
                    dtgDicIndex.Columns(4).HeaderText = ddlLabel.Items(12).Text
                    dtgDicIndex.Columns(4).Visible = True
                    dtgDicIndex.Columns(6).Visible = True
                    dtgDicIndex.Columns(7).Visible = True
                Case 5, 6, 7, 30  ' DDC, NLM, UDC, LOC
                    dtgDicIndex.Columns(4).HeaderText = ddlLabel.Items(13).Text
                    dtgDicIndex.Columns(5).HeaderText = ddlLabel.Items(14).Text
                    dtgDicIndex.Columns(4).Visible = True
                    dtgDicIndex.Columns(5).Visible = True
                    dtgDicIndex.Columns(6).Visible = True
                    dtgDicIndex.Columns(7).Visible = True
                Case 9 ' Subject Heading
                    'dtgDicIndex.Columns(6).Visible = True
                    dtgDicIndex.Columns(7).Visible = True
                Case 19 ' Theasis Subject
                    dtgDicIndex.Columns(4).HeaderText = ddlLabel.Items(15).Text
                    dtgDicIndex.Columns(4).Visible = True
            End Select
        End Sub

        ' Method: LoadTitle
        Private Sub LoadTitle()
            Dim tblTmp As New DataTable
            Dim strTmp As String
            If IsNumeric(Request.QueryString("intID")) Then
                objBCatDiclist.IDs = Trim(Request.QueryString("intID"))
                objBCatDiclist.SystemDic = 1
                objBCatDiclist.IsClassifiCation = -1
                objBCatDiclist.IsAuthority = -1
                tblTmp = objBCatDiclist.Retrieve
                If Not tblTmp Is Nothing AndAlso tblTmp.Rows.Count > 0 Then
                    strTmp = Trim(tblTmp.Rows(0).Item("Name") & "")
                Else
                    strTmp = ""
                End If
            Else
                strTmp = ""
            End If
            lblHeader.Text = Replace(lblHeader.Text, strTmp, "") & " " & strTmp
        End Sub

        ' Method: BindJavascript
        ' Popurse: Bind javascript for all control need 
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicIndexClass.js'></script>")

            btnGroup.Attributes.Add("onClick", "return(CheckMerger('" & ddlLabel.Items(11).Text & "','" & ddlLabel.Items(9).Text & "','" & ddlLabel.Items(10).Text & "'))")
        End Sub

        ' Method: Initialze
        ' Popurse: Init all object use in form
        Private Sub Initialze()
            ' Init objBCatDiclist object
            objBCatDiclist.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDiclist.DBServer = Session("DbServer")
            objBCatDiclist.ConnectionString = Session("ConnectionString")
            Call objBCatDiclist.Initialize()

            ' Init objBDictionary object
            objBDictionary.InterfaceLanguage = Session("InterfaceLanguage")
            objBDictionary.DBServer = Session("DbServer")
            objBDictionary.ConnectionString = Session("ConnectionString")
            Call objBDictionary.Initialize()
        End Sub

        ' Method: ReadTableDicName
        Private Sub ReadTableDicName()
            Dim tblTemp As New DataTable
            Dim strRet As String
            If IsNumeric(Request.QueryString("intID")) Then
                objBCatDiclist.IDs = Trim(Request.QueryString("intID"))
                objBCatDiclist.SystemDic = 1
                objBCatDiclist.IsClassifiCation = -1
                objBCatDiclist.IsAuthority = -1
                tblTemp = objBCatDiclist.Retrieve
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    hidNameTable.Value = Trim(tblTemp.Rows(0).Item("DicTable"))
                    hidSearchField.Value = Trim(tblTemp.Rows(0).Item("SearchFields"))
                End If
            End If
        End Sub

        ' Method: LoadData
        Private Sub LoadData(ByVal strFilter As String)
            Dim tblTemp As New DataTable
            Dim intCount As Integer
            Dim strDicIDs As String

            dtgDicIndex.Visible = False
            txtGroup.Visible = False
            btnGroup.Visible = False
            ddlDic.Visible = False
            lblFilterDrop.Visible = False
            lblNoInfo.Visible = True
            divddlDic.Visible = False
            divtxtGroup.Visible = False
            If hidNameTable.Value <> "" Then
                objBDictionary.TableDicName = hidNameTable.Value
                objBDictionary.DisplayEntry = strFilter
                objBDictionary.SearchFields = hidSearchField.Value
                tblTemp = objBDictionary.RetrieveDicIndex()
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    intCount = Math.Ceiling(tblTemp.Rows.Count / dtgDicIndex.PageSize)
                    If dtgDicIndex.CurrentPageIndex >= intCount Then
                        dtgDicIndex.CurrentPageIndex = dtgDicIndex.CurrentPageIndex - 1
                    End If
                    dtgDicIndex.DataSource = tblTemp
                    dtgDicIndex.DataBind()

                    ddlDic.DataSource = tblTemp
                    ddlDic.DataTextField = "DisplayEntry"
                    ddlDic.DataValueField = "ID"
                    ddlDic.DataBind()

                    ''Phuong 20080904
                    'B1
                    'I don't understand to purpose for the command...???

                    '' Set value for hidLocIDs
                    'For intCount = 0 To tblTemp.Rows.Count - 1
                    '    strDicIDs = strDicIDs & CStr(tblTemp.Rows(intCount).Item("ID")) & ","
                    'Next
                    'If strDicIDs <> "" Then
                    '    hidDicIDs.Value = Left(strDicIDs, Len(strDicIDs) - 1)
                    'End If

                    'E1

                    dtgDicIndex.Visible = True
                    txtGroup.Visible = True
                    btnGroup.Visible = True
                    ddlDic.Visible = True
                    lblFilterDrop.Visible = True
                    lblNoInfo.Visible = False
                    divddlDic.Visible = True
                    divtxtGroup.Visible = True
                End If
            End If
        End Sub

        ' Event: btnFilter_Click
        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            dtgDicIndex.CurrentPageIndex = 0
            Call LoadData(txtFilter.Text)
        End Sub

        ' Event: btnGroup_Click
        Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
            Dim chkCheckBox As HtmlInputCheckBox

            Dim strIDs As String = ""
            Dim dtgItem As DataGridItem

            For Each dtgItem In dtgDicIndex.Items
                chkCheckBox = dtgItem.FindControl("ckbdtgMerger")
                If chkCheckBox.Checked Then
                    strIDs = strIDs & dtgItem.Cells(0).Text & ","
                End If
            Next
            If strIDs <> "" Then
                strIDs = Left(strIDs, Len(strIDs) - 1)
                objBDictionary.IDs = strIDs
                objBDictionary.IDNew = ddlDic.SelectedValue
                If IsNumeric(Request.QueryString("intID") & "") Then
                    objBDictionary.DicIndexID = CInt(Request.QueryString("intID"))
                    objBDictionary.MergeDicIndex()
                    ' Write log
                    Call WriteLog(15, ddlLabel.Items(8).Text & " " & strIDs & " -->" & ddlDic.SelectedItem.Text & "(" & ddlDic.SelectedValue & ")", Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    Page.RegisterClientScriptBlock("MegerSuccJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(4).Text & "');</script>")

                End If
            End If
            Call LoadData(txtFilter.Text)
        End Sub

        ' Event: dtgDicIndex_UpdateCommand
        Private Sub dtgDicIndex_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.UpdateCommand
            Dim strID As String
            Dim strDisplayEntry As String
            Dim strIsoCode As String
            Dim strName As String
            Dim strNameViet As String
            Dim strNote As String
            Dim lngParentID As String

            Dim tblTemp As New DataTable
            Dim intRow As Integer = 0
            Dim blnExist As Boolean = False

            If hidNameTable.Value <> "" Then
                strDisplayEntry = CType(e.Item.Cells(2).FindControl("txtDisplayEntry"), TextBox).Text
                strIsoCode = CType(e.Item.Cells(3).FindControl("txtIsoCode"), TextBox).Text
                strName = CType(e.Item.Cells(4).FindControl("txtName"), TextBox).Text
                strNameViet = CType(e.Item.Cells(5).FindControl("txtNameViet"), TextBox).Text
                strNote = CType(e.Item.Cells(6).FindControl("txtNote"), TextBox).Text

                ' parentID
                If Not CType(e.Item.Cells(7).FindControl("ddlParName"), DropDownList).SelectedValue = "" Then
                    lngParentID = CType(e.Item.Cells(7).FindControl("ddlParName"), DropDownList).SelectedValue
                Else
                    lngParentID = 0
                End If

                strID = e.Item.Cells(0).Text

                ' Check exist
                objBDictionary.TableDicName = hidNameTable.Value
                objBDictionary.DisplayEntry = strDisplayEntry
                objBDictionary.SearchFields = hidSearchField.Value
                tblTemp = objBDictionary.RetrieveDicIndex()
                If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                    For intRow = 0 To tblTemp.Rows.Count - 1
                        If CStr(tblTemp.Rows(intRow).Item("DisplayEntry")).ToUpper = strDisplayEntry.ToUpper And CStr(tblTemp.Rows(intRow).Item("ID")) <> strID Then
                            blnExist = True
                            Exit For
                        End If
                    Next
                End If
                If Not blnExist Then
                    objBDictionary.IDs = strID
                    objBDictionary.DisplayEntry = strDisplayEntry

                    Select Case Request.QueryString("intID")
                        Case 10, 11 ' Cat_tblDic_Language, Cat_tblDic_Country
                            objBDictionary.IsoCode = strIsoCode & ""
                            objBDictionary.Name = strName
                            objBDictionary.NameViet = strNameViet
                        Case 4  ' BBK
                            objBDictionary.Name = strName
                            objBDictionary.Note = strNote
                            objBDictionary.ParentID = lngParentID
                        Case 5, 6, 7, 30  ' DDC, NLM, UDC, LOC
                            objBDictionary.Name = strName
                            objBDictionary.NameViet = strNameViet
                            objBDictionary.Note = strNote
                            objBDictionary.ParentID = lngParentID
                        Case 9 ' Subject Heading
                            objBDictionary.ParentID = lngParentID
                        Case 19 ' Theasis Subject
                            objBDictionary.Name = strName
                    End Select

                    objBDictionary.TableDicName = hidNameTable.Value
                    Call objBDictionary.UpdateDicIndex()
                    ' Write log
                    Call WriteLog(15, ddlLabel.Items(7).Text & " : " & strID & " - " & strDisplayEntry, Request.ServerVariables("SCRIPT_NAME"), Request.ServerVariables("REMOTE_ADDR"), clsSession.GlbUserFullName)

                    Page.RegisterClientScriptBlock("UpdateSuccJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text & "');</script>")
                    dtgDicIndex.EditItemIndex = -1
                    Call LoadData(txtFilter.Text)
                Else
                    Page.RegisterClientScriptBlock("DuplicateUpJS", "<script language = 'javascript'>alert('" & ddlLabel.Items(6).Text & "');</script>")
                End If
            End If
        End Sub

        ' Event: dtgDicIndex_EditCommand
        Private Sub dtgDicIndex_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.EditCommand
            Dim intIndex As Integer
            Dim ddlParName As New DropDownList
            Dim txtParentID As New TextBox
            Dim inti As Integer

            intIndex = CInt(e.Item.ItemIndex)
            dtgDicIndex.EditItemIndex = intIndex

            Call LoadData(txtFilter.Text)

            txtParentID = CType(dtgDicIndex.Items(intIndex).Cells(7).FindControl("txtParentID"), TextBox)
            ddlParName = CType(dtgDicIndex.Items(intIndex).Cells(7).FindControl("ddlParName"), DropDownList)

            ' Get the list of Parent Names
            Dim tblParDic As DataTable

            objBDictionary.TableDicName = hidNameTable.Value
            objBDictionary.DisplayEntry = ""
            objBDictionary.SearchFields = ""
            tblParDic = objBDictionary.RetrieveDicIndex()
            If Not tblParDic Is Nothing AndAlso tblParDic.Rows.Count > 0 Then
                tblParDic = InsertOneRow(tblParDic, ddlLabel.Items(16).Text)
                'ddlParName.DataSource = tblParDic
                If Request.QueryString("intID") = 9 Then
                    ddlParName.DataTextField = "DisplayEntry"
                Else
                    ddlParName.DataTextField = "Name"
                End If

                ddlParName.DataValueField = "ID"
                ddlParName.DataBind()
            End If

            'PhuongTT
            'Mac dinh cho phep sua tat ca cac chi muc du co ParentID = NULL
            '20080808
            'B1

            'For inti = 0 To ddlParName.Items.Count - 1
            '    If CStr(ddlParName.Items(inti).Value) = txtParentID.Text Then
            '        ddlParName.Items(inti).Selected = True
            '    Else
            '        ddlParName.Items(inti).Selected = False
            '    End If
            'Next
            'B2
        End Sub

        ' Event: dtgDicIndex_CancelCommand
        Private Sub dtgDicIndex_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.CancelCommand
            dtgDicIndex.EditItemIndex = -1
            Call LoadData(txtFilter.Text)
        End Sub

        ' Event: dtgDicIndex_ItemCreated
        Private Sub dtgDicIndex_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgDicIndex.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim lnkbtnUpdate As LinkButton
                    lnkbtnUpdate = CType(e.Item.FindControl("lnkdtgUpdate"), LinkButton)
                    If Not lnkbtnUpdate Is Nothing Then
                        lnkbtnUpdate.Attributes.Add("OnClick", "javascript:return(CheckUpdate('document.forms[0].dtgDicIndex__ctl" & CStr(e.Item.ItemIndex + 3) & "_txtDisplayEntry','" & ddlLabel.Items(5).Text & "'));")
                    End If
            End Select
        End Sub

        ' Event: dtgDicIndex_PageIndexChanged
        Private Sub dtgDicIndex_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgDicIndex.PageIndexChanged
            dtgDicIndex.CurrentPageIndex = e.NewPageIndex
            Call LoadData(txtFilter.Text)
        End Sub

        ' Event: txtGroup_TextChanged
        Private Sub txtGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroup.TextChanged
            Dim tblTemp As New DataTable
            If hidNameTable.Value <> "" Then
                objBDictionary.TableDicName = hidNameTable.Value
                objBDictionary.DisplayEntry = txtGroup.Text
                objBDictionary.SearchFields = hidSearchField.Value
                tblTemp = objBDictionary.RetrieveDicIndex()
                If Not tblTemp Is Nothing Then
                    ddlDic.DataSource = tblTemp
                    ddlDic.DataTextField = "DisplayEntry"
                    ddlDic.DataValueField = "ID"
                    ddlDic.DataBind()
                End If
            End If
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
                    If Not objBDictionary Is Nothing Then
                        objBDictionary.Dispose(True)
                        objBDictionary = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Dispose()
            End Try
        End Sub

    End Class
End Namespace