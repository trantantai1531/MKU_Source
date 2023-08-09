Imports eMicLibAdmin.BusinessRules.Catalogue
Imports Telerik.Web.UI

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatAuthority
        Inherits clsWBase
        Implements IUCNumberOfRecord
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

        Private objBCatAuthor As New clsBCatAuthority

        'event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Check permisssion
            'Call CheckFormPermission()
            Call Initialze()
            Call BindJavascript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(13) Then
                WriteErrorMssg(lblLabel0.Text)
            End If
        End Sub

        ' Method: BindJavascript
        ' Purpose: bind java script for all control need
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            dtgCatAuthor.HeaderStyle.CssClass = "lbGridHeader"
            dtgCatAuthor.PagerStyle.CssClass = "lbGridPager"
            dtgCatAuthor.AlternatingItemStyle.CssClass = "lbGridAlterCell"
            dtgCatAuthor.ItemStyle.CssClass = "lbGridCell"
            dtgCatAuthor.EditItemStyle.CssClass = "lbGridEdit"
        End Sub

        ' Method: Initialze
        ' Purpose: init all object use in form
        Private Sub Initialze()
            objBCatAuthor.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatAuthor.DBServer = Session("DbServer")
            objBCatAuthor.ConnectionString = Session("ConnectionString")
            objBCatAuthor.Initialize()
        End Sub

        ' Method: BindData
        Public Sub BindData(Optional ByVal intPage As Integer = 0)
            dtgCatAuthor.DataSource = objBCatAuthor.Retrieve
            'Check error
            Call WriteErrorMssg(lblLabel2.Text, objBCatAuthor.ErrorMsg, lblLabel3.Text, objBCatAuthor.ErrorCode)

            dtgCatAuthor.CurrentPageIndex = intPage
            'dtgCatAuthor.DataBind()
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
                    If Not objBCatAuthor Is Nothing Then
                        objBCatAuthor.Dispose(True)
                        objBCatAuthor = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub


        Public Function GetNumber() As Integer Implements IUCNumberOfRecord.NumberOfRecord
            Return 25
        End Function

        Protected Sub dtgCatAuthor_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles dtgCatAuthor.NeedDataSource
            Call BindData()

        End Sub
    End Class
End Namespace