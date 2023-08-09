Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataDetailRenew
        Inherits clsWBase
        Implements IUCNumberOfRecord
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblAll As System.Web.UI.WebControls.Label
        Protected WithEvents lblMonth As System.Web.UI.WebControls.Label
        Protected WithEvents lblDash As System.Web.UI.WebControls.Label
        Protected WithEvents lblNotCata As System.Web.UI.WebControls.Label
        Protected WithEvents lblCata As System.Web.UI.WebControls.Label
        Protected WithEvents lblListItemCata As System.Web.UI.WebControls.Label


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCataQueue As New clsBCataQueue
        Private objBItemCollection As New clsBItemCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.ShowWaitingOnPage(ddlLabel.Items(7).Text, "../..", False, True)
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                'Delete
                If Request("strDelete") & "" <> "" Then
                    Call Delete()
                End If
                'Update
                If Request("strUpdate") & "" <> "" Then
                    Call Update()
                End If
                Call BindDropDownList()
                Call BindGrid()
            End If
            Me.ShowWaitingOnPage("", "", True, True)
        End Sub

        ' Initialize Method
        Private Sub Initialize()
            'Init objBCataQueue
            objBCataQueue.ConnectionString = Session("ConnectionString")
            objBCataQueue.InterfaceLanguage = Session("InterfaceLanguage")
            objBCataQueue.DBServer = Session("DBServer")
            objBCataQueue.Initialize()

            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            objBItemCollection.Initialize()

        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("Catalog", "<script language = 'javascript' src = '../Js/Catalogue/WCataDetail.js'></script>")
        End Sub

        ' Delete function 
        Private Sub Delete()

            Try
                objBItemCollection.ItemIDs = Request("strDelete")
                'objBItemCollection.DeleteCatQueue()
                objBItemCollection.DeleteItem()
                Page.RegisterClientScriptBlock("UpdateFail2", "<script language = 'javascript'>alert('Xóa thành công')</script>")
            Catch ex As Exception

            End Try

        
        End Sub

        ' Delete function 
        Private Sub Update()
            'Dim tblResult As DataTable
            'Dim strIDs As String = ","
            'Dim inti As Integer
            'objBItemCollection.ItemIDs = Request("strUpdate")
            'tblResult = objBItemCollection.GetItemReview

            'If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
            '    For inti = 0 To tblResult.Rows.Count - 1
            '        strIDs = strIDs & tblResult.Rows(inti).Item("ITEMID") & ","
            '    Next
            'End If
            'If Len(strIDs) > 1 Then
            '    strIDs = Left(strIDs, Len(strIDs) - 1)
            '    strIDs = Right(strIDs, Len(strIDs) - 1)
            '    objBItemCollection.ItemIDs = strIDs
            '    objBItemCollection.UpdateItemReview(clsSession.GlbUserFullName)
            '    objBItemCollection.DeleteCatQueue()
            'End If
            objBItemCollection.ItemIDs = Request("strUpdate")
            objBItemCollection.UpdateItemReview(clsSession.GlbUserFullName)
            'objBItemCollection.DeleteCatQueue()

        End Sub

        ' BindDropDownList function
        Private Sub BindDropDownList()
            Dim tblTemp As DataTable

            objBCataQueue.All = ddlLabel.Items(0).Text.Trim
            objBCataQueue.Month = ddlLabel.Items(1).Text.Trim
            objBCataQueue.Dash = ddlLabel.Items(2).Text.Trim
            objBCataQueue.NotCatalog = ddlLabel.Items(3).Text.Trim
            objBCataQueue.Catalog = ddlLabel.Items(4).Text.Trim

            objBCataQueue.LibID = clsSession.GlbSite
            tblTemp = objBCataQueue.RetrieveInputTime(1)

            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                ddlInputTime.DataSource = tblTemp
                ddlInputTime.DataTextField = "Text"
                ddlInputTime.DataValueField = "ID"
                ddlInputTime.DataBind()
                ddlInputTime.Items(Session("InputTime")).Selected = True
            End If
        End Sub

        ' BindGrid function
        Private Sub BindGrid()
            Dim CataQueue As DataTable
            Dim intModeSort As Integer
            objBCataQueue.InputDate = ""
            If InStr(ddlInputTime.Items(CInt(Session("InputTime"))).Text, Trim(ddlLabel.Items(0).Text)) > 0 Then
                objBCataQueue.InputDate = ""
            ElseIf InStr(ddlInputTime.Items(CInt(Session("InputTime"))).Text, Trim(ddlLabel.Items(1).Text)) > 0 Then
                objBCataQueue.InputDate = ddlInputTime.Items(CInt(Session("InputTime"))).Text.Substring(6, 7)
            End If
            If Not Request.QueryString("SortMode") & "" = "" Then
                intModeSort = CInt(Request.QueryString("SortMode"))
            Else
                intModeSort = 1 ' Default by Code
            End If
            objBCataQueue.Reviewed = 1
            objBCataQueue.LibID = clsSession.GlbSite
            CataQueue = objBCataQueue.GetItemCatQueueField(intModeSort)
            If Not CataQueue Is Nothing Then
                If grdFItem.CurrentPageIndex > 0 And grdFItem.PageCount < grdFItem.CurrentPageIndex + 1 Then
                    grdFItem.CurrentPageIndex = grdFItem.CurrentPageIndex - 1
                End If
                grdFItem.DataSource = CataQueue
                'grdFItem.DataBind()
                If Not grdFItem.PageCount > 0 Then
                    grdFItem.Visible = False
                Else
                    grdFItem.Visible = True
                End If
            End If
        End Sub

        ' grdFItem_SelectedIndexChanged event (Change to new row)
        Private Sub grdFItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFItem.SelectedIndexChanged
            grdFItem.CurrentPageIndex = 0
            BindGrid()
            grdFItem.Rebind()
        End Sub

        '' grdFItem_SelectedIndexChanged event (Change to new page)
        'Private Sub grdFItem_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grdFItem.PageIndexChanged
        '    grdFItem.CurrentPageIndex = e.NewPageIndex
        '    BindGrid()
        'End Sub

        '' grdFItem_SelectedIndexChanged event (Change to new short)
        'Private Sub grdFItem_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles grdFItem.SortCommand
        '    hidColSort.Value = e.SortExpression
        '    BindGrid()
        'End Sub

        ' grdFItem_SelectedIndexChanged event (Change to new collection of records by changing the dropdownlist ddlInputTime)
        Private Sub ddlInputTime_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlInputTime.SelectedIndexChanged
            Session("InputTime") = ddlInputTime.SelectedIndex
            grdFItem.CurrentPageIndex = 0
            BindGrid()
            hidID.Value = ""
            hidIDs.Value = ""
        End Sub

        ' grdFItem_ItemCreated event
        ' Purpose: Add the attributes for the controls in the rows for other purposes
        Private Sub grdFItem_ItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles grdFItem.ItemCreated
            If TypeOf e.Item Is GridDataItem Then
                ' xu ly neu da kiem ke roi thi` chuyen Label co dang <A href></A>
                Dim lnk = TryCast(e.Item.FindControl("lnkContent"), HyperLink)
                If DataBinder.Eval(e.Item.DataItem, "Reviewed") <> "1" Then
                    'lnk.Font.Bold = True
                    lnk.NavigateUrl = "WCatalogueProperty.aspx"
                    lnk.Attributes.Add("onclick", "javascript:OpenWindow('WCatalogueProperty.aspx?intItemID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "&Action=Display','WCatalogueProperty',750,400,20,60);return false;")
                End If
                If DataBinder.Eval(e.Item.DataItem, "Reviewed") = "1" Then
                    'lnk.Font.Bold = True
                    lnk.NavigateUrl = "WCatalogueProperty.aspx"
                    lnk.Attributes.Add("onclick", "javascript:OpenWindow('WCatalogueProperty.aspx?intItemID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "&Action=Display','WCatalogueProperty',750,400,20,60);return false;")
                End If

                With e.Item
                    Dim strJVScript As String
                    Session("arrFilteredItemID") = Nothing
                    strJVScript = "var intUseDefault;"
                    strJVScript = strJVScript & "if (eval(parent.Sentform.document.forms[0].chkUseDefault).checked == false) intUseDefault=0; else intUseDefault=1;"
                    strJVScript = strJVScript & "parent.Sentform.location.href='WCataModify.aspx?CurrentID=0&ItemID=" & DataBinder.Eval(e.Item.DataItem, "ID")
                    strJVScript = strJVScript & "&FormID=' + parent.Sentform.document.forms[0].ddlForm.options[parent.Sentform.document.forms[0].ddlForm.options.selectedIndex].value +"
                    strJVScript = strJVScript & "'&UseDefault=' + intUseDefault"

                    .Attributes.Add("onclick", "javascript:rdoEvent(" & DataBinder.Eval(e.Item.DataItem, "ID") & "," & e.Item.ItemIndex & ");")
                    .Attributes.Add("onDblClick", "javascript:" & strJVScript & ";")
                End With
            End If

           

        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        ' Purpose: Release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBCataQueue Is Nothing Then
                        objBCataQueue.Dispose(True)
                        objBCataQueue = Nothing
                    End If
                    If Not objBItemCollection Is Nothing Then
                        objBItemCollection.Dispose(True)
                        objBItemCollection = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub



        Protected Sub grdFItem_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles grdFItem.NeedDataSource
            BindGrid()

        End Sub

        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

    End Class
End Namespace