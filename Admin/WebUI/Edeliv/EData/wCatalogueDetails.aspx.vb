Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules.Catalogue
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WCatalogueDetails
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

        ' Declare variables
        ' Class variables
        Private objBItemCollection As New clsBItemCollection
        Private objBCDBS As New clsBCommonDBSystem

        ' Strings
        Private strIDs As String
        Private strItemTopNum As String
        Private strAction As String
        Private strPostID As String
        Private strFormID As String = ""

        ' Integers
        Private intType As Integer  ' View type

        ' Page Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call CheckFormPemission()
            Call Initialize()
            Call BindJavaScript()
            Call BindData()
            'Me.ExportResource("c:\inetpub\wwwroot\WebUIBM\Resources\LabelString\Catalogue\Catalogue\WCataloguePropertySR.vi.resx", False)
            'Me.ExportResource("c:\inetpub\wwwroot\WebUIBM\Resources\LabelString\Catalogue\Catalogue\WCataloguePropertySR.en.resx", False)
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            objBItemCollection.Initialize()

            'Init objBItemCollection
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.Initialize()
        End Sub

        ' BindJavascript method
        Private Sub BindJavaScript()
            Page.RegisterClientScriptBlock("JScript", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            btnClose.Attributes.Add("OnClick", "javascript:self.close(); return false;")
        End Sub

        ' BindData Method 
        ' Purpose: Bind the data 
        Private Sub BindData()
            Dim tblItem As New DataTable

            ' Get the Item details by Item ID and bind to the datagrid
            objBItemCollection.ItemIDs = CStr(Request("ItemID"))
            tblItem = objBItemCollection.GetContents
            Call WriteErrorMssg(ddlLabel.Items(2).Text, objBItemCollection.ErrorMsg, ddlLabel.Items(1).Text, objBItemCollection.ErrorCode)
            grdProperty.DataSource = tblItem
            grdProperty.DataBind()
        End Sub

        ' Page_Unload event
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
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                ' Call Dispose on your base class.
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace