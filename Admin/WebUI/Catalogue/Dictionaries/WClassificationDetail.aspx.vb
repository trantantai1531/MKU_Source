' Class: WCatPatternCatalogueDisplay
' Propose: Create fich pattern
' CreatedDate: 19/04/2004
' Creator: Sondp.
'  Modification history 
'    - 02/03/2005 by Tuanhv: review

Imports eMicLibAdmin.BusinessRules.Catalogue
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WClassificationDetail
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialze()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                'Call LoadData()
            End If
            lblHeader.Text = Replace(lblHeader.Text, ReadClassName, "") & " " & ReadClassName()
            lblList.Text = Replace(lblList.Text, ReadClassName, "") & " " & ReadClassName()
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

        ' BindJavascript method
        ' Purpose: Include all neccessary javascript functions
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Dictionaries/WClassificationDetail.js'></script>")
            btnNew.Attributes.Add("onClick", "if (CheckNull(document.forms[0].txtDisplayEntryT)) {alert('" & ddlAboutAction.Items(11).Text & "'); return false;}")
        End Sub

        ' Method: ReadClassName
        Private Function ReadClassName() As String
            If IsNumeric(Request.QueryString("Type")) Then
                Select Case CInt(Request.QueryString("Type"))
                    Case 1
                        ReadClassName = "BBK"
                    Case 2
                        ReadClassName = "DDC"
                    Case 3
                        ReadClassName = "LOC"
                    Case 4
                        ReadClassName = "UDC"
                    Case 5
                        ReadClassName = "NLM"
                    Case 6
                        ReadClassName = "NSC"
                    Case 7 ' Medium
                        Response.Redirect("WDicMedium.aspx")
                    Case 8 ' Item type
                        Response.Redirect("WDicItemType.aspx")
                End Select
            Else
                ReadClassName = ""
            End If
        End Function

        ' Method: LoadData
        Private Sub LoadData()
            Dim tblClass As New DataTable
            Dim intItem As Integer
            Dim intCount As Integer

            If IsNumeric(Request.QueryString("Type")) Then
                objBDictionary.Type = ReadClassName()
                tblClass = objBDictionary.Retrieve
                dtgDicClassi.Visible = False
                If Not tblClass Is Nothing AndAlso tblClass.Rows.Count > 0 Then
                    intCount = CInt(tblClass.Rows.Count / dtgDicClassi.PageSize)
                    intItem = intCount * dtgDicClassi.PageSize
                    If intItem = tblClass.Rows.Count Then
                        If dtgDicClassi.CurrentPageIndex > intCount - 1 Then
                            dtgDicClassi.CurrentPageIndex = dtgDicClassi.CurrentPageIndex - 1
                        End If
                    End If
                    dtgDicClassi.DataSource = tblClass
                    'dtgDicClassi.DataBind()
                    dtgDicClassi.Visible = True
                End If
            End If
        End Sub

        ' Event: dtgDicClassi_UpdateCommand
        ' Purpose: update selected entry
        Protected Sub dtgDicClassi_UpdateCommand1(sender As Object, e As GridCommandEventArgs) Handles dtgDicClassi.UpdateCommand
            Dim strItemLeader As String = ""
            Dim strVersion As String = ""
            Dim strCaption As String = ""
            Dim strDisplayEntry As String = ""
            Dim strVietCaption As String = ""
            Dim strDescription As String = ""
            Dim intRetval As Integer = 1


            strDisplayEntry = CType(e.Item.Cells(3).FindControl("txtDisplayEntry"), TextBox).Text
            If Trim(strDisplayEntry) = "" Then
                Page.RegisterClientScriptBlock("alertJSEmpty", "<script language = 'javascript'>alert('" & ddlAboutAction.Items(11).Text & "');</script>")
            Else
                strItemLeader = CType(e.Item.Cells(1).FindControl("txtItemLeader"), TextBox).Text
                strCaption = CType(e.Item.Cells(4).FindControl("txtCaption"), TextBox).Text
                strVietCaption = CType(e.Item.Cells(5).FindControl("txtVietCaption"), TextBox).Text
                strDescription = CType(e.Item.Cells(6).FindControl("txtDescription"), TextBox).Text
                strVersion = CType(e.Item.Cells(7).FindControl("txtVersion"), TextBox).Text

                objBDictionary.ID = CLng(CType(e.Item.Cells(0).FindControl("lblID"), Label).Text)
                objBDictionary.ItemLeader = strItemLeader
                objBDictionary.Version = strVersion
                objBDictionary.DisplayEntry = strDisplayEntry
                objBDictionary.Caption = strCaption
                objBDictionary.VietCaption = strVietCaption
                objBDictionary.Description = strDescription
                objBDictionary.Type = ReadClassName()
                intRetval = objBDictionary.Update()
                If intRetval > 0 Then
                    Page.RegisterClientScriptBlock("DuplicateJS", "<script language='javascript'>alert('" & ddlAboutAction.Items(12).Text & "');</script>")
                Else
                    objBDictionary.IDs = ""
                    objBDictionary.DisplayEntry = ""
                    'dtgDicClassi.EditItemIndex = -1
                    Call LoadData()
                End If
            End If
        End Sub

        ' Event: dtgDicClassi_EditCommand
        Private Sub dtgDicClassi_EditCommand(sender As Object, e As GridCommandEventArgs) Handles dtgDicClassi.EditCommand
            'dtgDicClassi.EditIndexes = CInt(e.Item.ItemIndex)
            Call LoadData()
        End Sub

        '' Event: dtgDicClassi_PageIndexChanged
        'Private Sub dtgDicClassi_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgDicClassi.PageIndexChanged
        '    dtgDicClassi.CurrentPageIndex = e.NewPageIndex
        '    Call LoadData()
        'End Sub

        ' Event: dtgDicClassi_CancelCommand
        'Private Sub dtgDicClassi_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgDicClassi.CancelCommand
        '    dtgDicClassi.EditItemIndex = -1
        '    Call LoadData()
        'End Sub

        ' Event: dtgDicClassi_DeleteCommand
        ' Purpose: delete selected entry
        Private Sub dtgDicClassi_DeleteCommand(sender As Object, e As GridCommandEventArgs) Handles dtgDicClassi.DeleteCommand
            Dim strIDDel As String
            strIDDel = CType(dtgDicClassi.Items(e.Item.ItemIndex).FindControl("lblID"), Label).Text
            objBDictionary.IDs = strIDDel
            objBDictionary.Delete()
            objBDictionary.DisplayEntry = ""
            objBDictionary.IDs = ""
            'dtgDicClassi.EditItemIndex = -1
            Try
            Catch ex As Exception
                dtgDicClassi.CurrentPageIndex = 0
            Finally
                Call LoadData()
            End Try
        End Sub

        ' Event: btnNew_Click
        ' Purpose: new entry
        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
            Dim intRetval As Integer = 1
            objBDictionary.Caption = Trim(txtCaptionT.Text)
            objBDictionary.VietCaption = Trim(txtVietCaptionT.Text)
            If IsNumeric(Request.QueryString("Type")) Then
                objBDictionary.TypeID = CInt(Request.QueryString("Type"))
            End If
            objBDictionary.DisplayEntry = Trim(txtDisplayEntryT.Text)
            objBDictionary.Description = Trim(txtDescriptionT.Text)
            objBDictionary.Version = Trim(txtVersionT.Text)
            objBDictionary.Type = ReadClassName()
            intRetval = objBDictionary.Insert()
            If intRetval > 0 Then
                Page.RegisterClientScriptBlock("DuplicateJS", "<script language='javascript'>alert('" & ddlAboutAction.Items(12).Text & "');</script>")
            End If
            objBDictionary.DisplayEntry = ""
            objBDictionary.IDs = ""
            Call LoadData()
            dtgDicClassi.Rebind()
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



        Protected Sub dtgDicClassi_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgDicClassi.NeedDataSource

            LoadData()
        End Sub

    
    End Class
End Namespace