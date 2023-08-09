Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WFindAuthorityID
        Inherits clsWBase

        ' Declare the class variables
        Private objBCatalogueForm As New clsBCatalogueForm
        Private objBCDS As New clsBCommonDBSystem

#Region " Web Form Designer Generated Code "


        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub




        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckFormPemission()
            Call Initialize()
            Call BindJavaScript()
        End Sub
        ' Method: CheckFormPemission
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(142) Then
                btnModify.Enabled = False
                btnSearch.Enabled = False
            End If
        End Sub
        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objWCommonDBSystem object
            objBCatalogueForm.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatalogueForm.DBServer = Session("DBServer")
            objBCatalogueForm.ConnectionString = Session("ConnectionString")
            Call objBCatalogueForm.Initialize()

            ' Init objBCDS object
            objBCDS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDS.DBServer = Session("DBServer")
            objBCDS.ConnectionString = Session("ConnectionString")
            Call objBCDS.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavaScript()
            Dim strJS As String
            ' Register the javascipt files
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            ' Set JS string
            strJS = "if (CheckNull(document.forms[0].txtAuthorityID)) {alert('" & ddlLabel.Items(1).Text & "');document.forms[0].txtAuthorityID.focus();return false;}"

            ' Add attribute for btnModify button control
            btnModify.Attributes.Add("OnClick", "javascript:" & strJS)
        End Sub

        ' SearchItem method 
        ' Purpose: Search items by the reference 
        Private Sub SearchItem()
            Dim strSQL As String
            Dim tblItem As DataTable
            Dim intIndex As Integer
            Dim intCount As Integer
            Dim intSumFound As Integer = 0

            objBCatalogueForm.AccessEntry = CStr(txtAccessEntry.Text)

            If Not Trim(CStr(ddlReference.SelectedValue)) = "" Then
                objBCatalogueForm.ReferenceID = CInt(ddlReference.SelectedValue)
            Else
                objBCatalogueForm.ReferenceID = 0
            End If

            tblItem = objBCatalogueForm.GetAuthorityInfor(0, 0)

            If Not tblItem Is Nothing Then
                If tblItem.Rows.Count > 0 Then
                    intSumFound = tblItem.Rows.Count
                End If
            End If


            If intSumFound <> 0 Then
                dgrResult.Visible = True
                dgrResult.DataSource = tblItem
                dgrResult.DataBind()
                lblCapResult.Visible = True
                lblResult.Visible = True
                lblResult.Text = CStr(intSumFound)
                lblCap.Visible = True
            Else
                lblCapResult.Visible = False
                lblResult.Visible = False
                lblResult.Text = ""
                lblCap.Visible = False
                ' Not found any item IDs
                Page.RegisterClientScriptBlock("JSAlert", "<script language= 'javascript'>alert('" & ddlLabel.Items(2).Text & "')</script>")
                dgrResult.Visible = False
            End If
            tblItem.Dispose()
            tblItem = Nothing
        End Sub

        ' btnSearch_Click event
        ' Purpose: Filter the Items
        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            dgrResult.CurrentPageIndex = 0
            Call SearchItem()
        End Sub

        ' dgrResult_ItemCreated event
        Private Sub dgrResult_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrResult.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCell As TableCell
                    tblCell = e.Item.Cells(0)
                    Dim lnk As HyperLink
                    lnk = CType(tblCell.FindControl("lnkContent"), HyperLink)
                    lnk.Font.Bold = True

                    ' Add the attribute for the hiperlink to modify an item
                    lnk.NavigateUrl = "WCataModify.aspx"
                    lnk.Attributes.Add("onclick", "javascript:parent.Sentform.location.href='WCataModify.aspx?CurrentID=0&ItemID=" & DataBinder.Eval(e.Item.DataItem, "ID") & "';return false;")
            End Select
        End Sub

        ' DgrResult_PageIndexChanged event
        ' Purpose: Change the page index
        Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrResult.PageIndexChanged
            dgrResult.CurrentPageIndex = e.NewPageIndex
            Call SearchItem()
        End Sub

        ' btnModify_Click event
        ' Purpose: modify item by itemcode
        Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
            Dim TblTempItem As DataTable
            objBCatalogueForm.AccessEntry = CStr(txtAuthorityID.Text)
            TblTempItem = objBCatalogueForm.GetAuthorityInfor(1, 0)
            If TblTempItem.Rows.Count <> 0 Then
                Page.RegisterClientScriptBlock("CataModify", "<script language='javascript'>parent.Sentform.location.href='WCataModify.aspx?CurrentID=0&ItemID=" & TblTempItem.Rows(0).Item("ID") & "';</script>")
            Else
                Page.RegisterClientScriptBlock("NotFound", "<script language= 'javascript'>alert('" & ddlLabel.Items(0).Text & "');</script>")
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
                If Not objBCatalogueForm Is Nothing Then
                    objBCatalogueForm.Dispose(True)
                    objBCatalogueForm = Nothing
                End If
                If Not objBCDS Is Nothing Then
                    objBCDS.Dispose(True)
                    objBCDS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace