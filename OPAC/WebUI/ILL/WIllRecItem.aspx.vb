Imports eMicLibOPAC.BusinessRules.OPAC

Namespace eMicLibOPAC.WebUI.OPAC
    Partial Class WIllRecItem
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
        Private objBOPACILLItem As New clsBOPACILLItem

        'Event : Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindData()
        End Sub

        ' Initialize
        Private Sub Initialize()
            objBOPACILLItem.ConnectionString = Session("ConnectionString")
            objBOPACILLItem.DBServer = Session("DBServer")
            objBOPACILLItem.Initialize()
        End Sub

        ' BindData
        Private Sub BindData()
            Dim tblTemp As DataTable
            tblTemp = objBOPACILLItem.GetILLRecItem
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                dtgRecItem.DataSource = tblTemp
                dtgRecItem.DataBind()
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBOPACILLItem Is Nothing Then
                    objBOPACILLItem.Dispose(True)
                    objBOPACILLItem = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace