' WIndexCatalogue class
' Creator: Oanhtn
' CreatedDate: 13/05/2004
' Modification history:
'   - 03/03/2005 by Oanhtn: review & update

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WIndexCatalogue
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

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Call Navigation()
            End If
        End Sub

        ' Navigation method
        ' Purpose: create navigation for all links 
        Private Sub Navigation()
            Dim strJs As String
            ' Set default value
            lnkSetDefaultValue.NavigateUrl = "WMarcFieldsDefault.aspx"
            ' New catalogueing
            lnkNew.NavigateUrl = "WMarcFormSelect.aspx"
            ' Modify existting item
            lnkUpdate.NavigateUrl = "javascript:top.Sentform.location.href=""WCataModify.aspx"";"
            ' Browse existting items
            lnkBrowse.NavigateUrl = "javascript:top.Sentform.location.href=""WControlBar.aspx"";"
            ' Delete existting items
            lnkDelete.NavigateUrl = "javascript:top.Workform.location.href=""WDeleteItem.aspx"";"
            ' Import items from file
            lnkImpFromFile.NavigateUrl = "javascript:top.Workform.location.href=""WImportFromFile.aspx"";"
            ' Import items from Z3950
            lnkImpFromZ3950.NavigateUrl = "javascript:top.Workform.location.href=""WZForm.aspx"";"
            ' Export to file
            lnkExpData.NavigateUrl = "javascript:top.Workform.location.href=""WExportRecordToFile.aspx"";"

            'lnkCatalogue
            strJs = ""
            strJs = "document.location.href=""WCataDetail.aspx"";"
            strJs = strJs & "parent.Sentform.location.href=""WCataDetailTaskbar.aspx"";"
            lnkCatalogue.NavigateUrl = "WCataDetail.aspx"
            lnkCatalogue.Attributes.Add("onclick", "javascript:" & strJs)
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace