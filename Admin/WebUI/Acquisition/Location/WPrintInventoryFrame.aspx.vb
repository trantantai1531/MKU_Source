Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition

    Public Class WPrintInventoryFrame
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Dim strtype As String
            Dim strInven As String
            Dim strlibid As String
            Dim strlocid As String
            Dim strshelf As String
            Dim strshort As String
            Dim strpage As String
            Dim strurl As String

            strtype = Request("Type")
            strInven = Request("InventoryID")
            strlibid = Request("LibID")
            strlocid = Request("LocID")
            strshelf = Request("Shelf")
            strshort = Request("ShortView")
            strpage = Request("PageOneNum")
            strurl = "MenuInventory.location='WPrintInventoryMenu.aspx?InventoryID=" & strInven & "&LibID=" & strlibid & "&LocID=" & strlocid & "&Shelf=" & strshelf & "&Type=" & strtype & "&ShortView=" & strshort & "&PageOneNum=" & strpage & "'"
            Page.RegisterClientScriptBlock("selfJs", "<script language='javascript'>alert('afadsfsa');</script>")
        End Sub

    End Class
End Namespace