Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WPrintLocationInventoryT
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
        Private intCountPage As Integer
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call CheckPermission()
            Call BindData()
            Call BindScript()
        End Sub

        ' Method: CheckPermission 
        ' Purpose: Check permission 
        Private Sub CheckPermission()
            If Not CheckPemission(177) Then
                Call WriteErrorMssg(ddlLabelNote.Items(2).Text)
            End If
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("SelfJs", "<script language='javascript' src='../JS/Location/WPrintLocationInventory.js'></script>")

            btnLastPage.Attributes.Add("onClick", "javascript:return(Prev('" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'))")
            btnNextPage.Attributes.Add("onClick", "javascript:return(Next(" & CStr(intCountPage) & ",'" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "'))")
            txtPageIndex.Attributes.Add("onKeyDown", "if(event.keyCode == 13 || event.which == 13 ) {CurrentPageChange(" & CStr(intCountPage) & ",'" & ddlLabelNote.Items(2).Text & "','" & ddlLabelNote.Items(3).Text & "');return false;}")
        End Sub
        ' Method: BindData 
        ' Purpose: Load data
        Private Sub BindData()
            Dim arrInforInventory() As String = CStr(Session("InventoryInfor")).Split(",")
            Dim intRowIn1Page As Integer = CInt(arrInforInventory(5))
            Dim arrIDs() As String = Session("InventoryIDs")
            intCountPage = Math.Ceiling(arrIDs.Length / intRowIn1Page)
            lblIndexPage1.Text = lblIndexPage1.Text & " " & CStr(intCountPage)
        End Sub
    End Class
End Namespace