Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WShowGroup
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

        Private objBIDXGrp As New clsBIDXGroup

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPermission()
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                Call ShowGroup()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Object: objBIDXGrp
            objBIDXGrp.InterfaceLanguage = Session("InterfaceLanguage")
            objBIDXGrp.DBServer = Session("DbServer")
            objBIDXGrp.ConnectionString = Session("ConnectionString")
            Call objBIDXGrp.Initialize()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            ' View bibliography details
            If Not CheckPemission(168) Then
                Call WriteErrorMssg(ddlLabel.Items(2).Text)
            End If
        End Sub

        ' BindJS method
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("JSCommon", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("JSSelf", "<script language = 'javascript' src = '../js/Bibliography/WShowGroup.js'></script>")

            btnClose.Attributes.Add("Onclick", "self.close(); return false;")
        End Sub

        ' ShowGroup method
        Private Sub ShowGroup()
            Dim tblGrp As New DataTable

            If Not Request.QueryString("intID") & "" = "" Then
                objBIDXGrp.IDs = CInt(Request.QueryString("intID"))
                tblGrp = objBIDXGrp.IDXDetailRetrieveDistLink()
                tblGrp = objBIDXGrp.ProcessTable(tblGrp)
                'Show data
                dtgGrp.DataSource = tblGrp
                dtgGrp.DataBind()
            End If
        End Sub

        'Event: dtgGrp_PageIndexChanged
        Private Sub dtgGrp_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgGrp.PageIndexChanged
            dtgGrp.CurrentPageIndex = CInt(e.NewPageIndex)
            Call ShowGroup()
        End Sub

        'Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBIDXGrp Is Nothing Then
                        objBIDXGrp.Dispose(True)
                        objBIDXGrp = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace