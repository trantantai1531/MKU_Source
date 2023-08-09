' Purpose: search field by name
' Creator: KhoaNA
' CreatedDate: 08/04/2004
' Modification Historiy

Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WFindFieldByName
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

        Private objBField As New clsBField

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
        End Sub

        ' Initialize Method
        Private Sub Initialize()
            ' Init objBField object
            objBField.ConnectionString = Session("ConnectionString")
            objBField.InterfaceLanguage = Session("InterfaceLanguage")
            objBField.DBServer = Session("DBServer")
            Call objBField.Initialize()
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
            btnFind.Attributes.Add("OnClick", "if (CheckNull(document.forms[0].txtPattern)) {alert('" & ddlLabel.Items(2).Text & "');return false;}")
        End Sub

        ' btnFind_Click event
        ' Purpose: searching & show result
        Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
            Call BindGrid()
        End Sub

        ' BindGrid method
        ' Purpose: search & show result
        Private Sub BindGrid()
            Dim tblTemp As DataTable

            objBField.Pattern = txtPattern.Text.ToString.Trim
            objBField.HaveParentFieldCode = 0
            objBField.IsAuthority = Session("IsAuthority")
            tblTemp = objBField.SearchField
            If Not tblTemp Is Nothing And tblTemp.Rows.Count > 0 Then
                dgr.DataSource = tblTemp
                dgr.DataBind()
            Else
                Page.RegisterClientScriptBlock("AlertJs", "<script language = 'javascript'>alert('" & ddlLabel.Items(3).Text.Trim & "');</script>")
            End If
        End Sub

        ' dgr_ItemCreated event
        Private Sub dgr_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgr.ItemCreated
            Select Case e.Item.ItemType
                Case ListItemType.Item ', ListItemType.AlternatingItem, ListItemType.EditItem
                    Dim tblCellLink As TableCell
                    tblCellLink = e.Item.Cells(0)
                    Dim lnkLink As HyperLink
                    lnkLink = CType(tblCellLink.FindControl("lnkLink"), HyperLink)
                    lnkLink.NavigateUrl = "#"
                    lnkLink.Attributes.Add("onclick", "javascript:window.open('../BibliographyTemplate/WMarcFieldProperties.aspx?FieldCode=" & DataBinder.Eval(e.Item.DataItem, "FieldCode") & "','WShowFieldProperty',440,400,0,0);return false;")

                    Dim cChoose As TableCell
                    cChoose = e.Item.Cells(2)
                    Dim lnk As LinkButton
                    lnk = CType(cChoose.FindControl("lnkChoose"), LinkButton)
                    lnk.CssClass = "lbLinkFunction"
                    lnk.Attributes.Add("onclick", "javascript:opener.document.forms[0].txtFieldCode.value='" & DataBinder.Eval(e.Item.DataItem, "FieldCode") & "'; opener.document.forms[0].txtFieldValue.focus(); opener.top.main.Hiddenbase.location.href='WMarcFieldsDefaultHidden.aspx?FieldCode=" & DataBinder.Eval(e.Item.DataItem, "FieldCode") & "'; self.close(); return false;")
            End Select
        End Sub

        ' dgr_SelectedIndexChanged event
        Private Sub dgr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgr.SelectedIndexChanged
            dgr.CurrentPageIndex = 0
            Call BindGrid()
        End Sub

        ' dgr_PageIndexChanged event
        Private Sub dgr_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgr.PageIndexChanged
            dgr.CurrentPageIndex = e.NewPageIndex
            Call BindGrid()
        End Sub

        ' Page_UnLoad event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBField Is Nothing Then
                        objBField.Dispose(True)
                        objBField = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace