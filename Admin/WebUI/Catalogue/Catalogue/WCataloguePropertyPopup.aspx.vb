Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCataloguePropertyPopup
        Inherits clsWBase
        Private objBItemCollection As New clsBItemCollection

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call BindData()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
        End Sub
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        Private Sub BindData()
            Dim intTempID As String = Request.QueryString("intItemID")
            Dim tblTemp As New DataTable

            objBItemCollection.ItemIDs = intTempID
            grdProperty.DataSource = objBItemCollection.GetContents
            grdProperty.DataBind()
        End Sub

        'Private Sub grdProperty_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProperty.ItemCreated
        '    Dim strJs As String         ' String of JAVASCIPT
        '    Dim tblCell As TableCell
        '    Dim lnk As HyperLink        ' hiperlink variable

        '    Select Case e.Item.ItemType
        '        Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
        '            If DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "001" And DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "Ldr" And DataBinder.Eval(e.Item.DataItem, "FieldCode") <> "852" Then
        '                ' Get the property of field code to indicate the field having indicator or not

        '                tblCell = e.Item.Cells(0)
        '                lnk = CType(tblCell.FindControl("lnkFieldCode"), HyperLink)
        '                lnk.NavigateUrl = "WCataViewHidden.aspx"
        '                Dim strField As String = ""
        '                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "FieldCode")) Then
        '                    strField = CStr(DataBinder.Eval(e.Item.DataItem, "FieldCode")).Trim
        '                End If
        '                Dim strInd As String = ""
        '                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "Ind")) Then
        '                    strInd = CStr(DataBinder.Eval(e.Item.DataItem, "Ind")).Trim
        '                End If
        '                Dim strContent As String = ""
        '                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "Content")) Then
        '                    strContent = CStr(DataBinder.Eval(e.Item.DataItem, "Content")).Trim
        '                End If
        '                strJs = "WCataViewHidden.aspx?FieldCode=" & strField & "&Indicator=" & strInd.Replace("#", "a") & "&FieldValue=" & strContent.Replace("'", "\'")
        '                lnk.Target = "Hiddenbase"

        '                lnk.Attributes.Add("OnClick", "javascript:parent.Hiddenbase.location.href='" & strJs & "';return false;")
        '            End If
        '    End Select
        'End Sub

        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class

End Namespace
