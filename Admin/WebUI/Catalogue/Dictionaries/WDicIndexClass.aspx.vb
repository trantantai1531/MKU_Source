' Class: WDicIndexClass
' Propose: 
' CreatedDate: 19/04/2004
' Creator: Sondp.
'  Modification history 
'    - 25/02/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WDicIndexClass
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

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call LoadData("")
            End If
        End Sub

        ' Methord: BindJavascript
        Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WDicIndexClass.js'></script>")
            btnGroup.Attributes.Add("onClick", "CreateIDs();")
        End Sub

        Private Sub Initialze()
            'Object objBCatDiclist
            objBCatDiclist.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatDiclist.DBServer = Session("DbServer")
            objBCatDiclist.ConnectionString = Session("ConnectionString")
            objBCatDiclist.Initialize()

            'Object objBDictionary
            objBDictionary.InterfaceLanguage = Session("InterfaceLanguage")
            objBDictionary.DBServer = Session("DbServer")
            objBDictionary.ConnectionString = Session("ConnectionString")
            objBDictionary.Initialize()

            dtgDicIndex.HeaderStyle.CssClass = "lbGridHeader"
            dtgDicIndex.PagerStyle.CssClass = "lbGridPager"
            dtgDicIndex.AlternatingItemStyle.CssClass = "lbGridAlterCell"
            dtgDicIndex.ItemStyle.CssClass = "lbGridCell"
            dtgDicIndex.EditItemStyle.CssClass = "lbGridEdit"
        End Sub

        ' Methord: ReadTableDicName
        Private Function ReadTableDicName() As String
            Dim TblDicIndex As New DataTable
            Dim strRet As String
            If IsNumeric(Request.QueryString("ID")) Then
                objBCatDiclist.IDs = Trim(Request.QueryString("ID"))
                objBCatDiclist.SystemDic = 1
                TblDicIndex = objBCatDiclist.Retrieve
                If TblDicIndex.Rows.Count > 0 Then
                    strRet = Trim(TblDicIndex.Rows(0).Item("DicTable") & "")
                Else
                    strRet = ""
                End If
            Else
                strRet = ""
            End If
            ReadTableDicName = strRet
        End Function

        ' Methord: LoadData
        Private Sub LoadData(ByVal strFilter As String, Optional ByVal intPage As Integer = 0)
            Dim TblDicIndex As New DataTable
            Dim strDicName As String
            strDicName = Me.ReadTableDicName()
            If strDicName <> "" Then
                objBDictionary.TableDicName = strDicName
                objBDictionary.DisplayEntry = strFilter
                TblDicIndex = objBDictionary.RetrieveDicIndex()
                dtgDicIndex.DataSource = TblDicIndex
                dtgDicIndex.CurrentPageIndex = intPage
                dtgDicIndex.DataBind()
            End If
        End Sub

        Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
            Call LoadData(txtFilter.Text)
        End Sub

        Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
            Dim strIDsCheck As String
            If IsNumeric(ddlDic.SelectedValue & "") Then
                strIDsCheck = txtIDs.Value
                If strIDsCheck <> "" Then
                    objBDictionary.IDs = strIDsCheck
                    objBDictionary.IDNew = ddlDic.SelectedValue
                    If IsNumeric(Request.QueryString("ID") & "") Then
                        objBDictionary.DicIndexID = CInt(Request.QueryString("ID"))
                        objBDictionary.MergeDicIndex()
                    Else
                        ' khong thay TableDic
                    End If
                Else
                    ' chua chon ID can gop
                End If
            Else
                ' chua chon IDNew
            End If
            Call LoadData(txtFilter.Text)
        End Sub

        ' Event: dtgDicIndex_UpdateCommand
        Private Sub dtgDicIndex_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.UpdateCommand
            Dim strID As String
            Dim strDisplayEntry As String
            If CType(e.Item.Cells(2).FindControl("txtDisplayEntry"), TextBox).Enabled Then
                strDisplayEntry = CType(e.Item.Cells(2).FindControl("txtDisplayEntry"), TextBox).Text
                strID = CType(e.Item.Cells(0).FindControl("lblID"), Label).Text
                Response.Write(strDisplayEntry & "---" & strID)
                objBDictionary.IDs = strID
                objBDictionary.DisplayEntry = strDisplayEntry
                objBDictionary.TableDicName = Me.ReadTableDicName()
                objBDictionary.UpdateDicIndex()
            End If
            dtgDicIndex.EditItemIndex = -1
            Call LoadData(txtFilter.Text, dtgDicIndex.CurrentPageIndex)
        End Sub

        ' Event: dtgDicIndex_EditCommand
        Private Sub dtgDicIndex_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.EditCommand
            Dim intIndex As Integer

            intIndex = CInt(e.Item.ItemIndex)
            dtgDicIndex.EditItemIndex = intIndex
            Call LoadData(txtFilter.Text, dtgDicIndex.CurrentPageIndex)
        End Sub

        ' Event: dtgDicIndex_CancelCommand
        Private Sub dtgDicIndex_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicIndex.CancelCommand
            '
            dtgDicIndex.EditItemIndex = -1
            Call LoadData(txtFilter.Text, dtgDicIndex.CurrentPageIndex)
        End Sub

        ' Event: dtgDicIndex_PageIndexChanged
        Private Sub dtgDicIndex_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgDicIndex.PageIndexChanged
            Call LoadData(txtFilter.Text, e.NewPageIndex)
        End Sub

        ' Event: txtGroup_TextChanged
        Private Sub txtGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroup.TextChanged
            Dim TblDicIndex As New DataTable
            If Trim(txtGroup.Text) <> "" Then
                Dim strDicName As String
                strDicName = Me.ReadTableDicName()
                If strDicName <> "" Then
                    objBDictionary.TableDicName = strDicName
                    objBDictionary.DisplayEntry = txtGroup.Text
                    TblDicIndex = objBDictionary.RetrieveDicIndex()
                    ddlDic.DataSource = TblDicIndex
                    ddlDic.DataTextField = "DisplayEntry"
                    ddlDic.DataValueField = "ID"
                    ddlDic.DataBind()
                End If
            Else
                ddlDic.DataSource = TblDicIndex
                ddlDic.DataBind()
            End If
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
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
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace