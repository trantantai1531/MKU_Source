' Class: WZServerList
' Puspose: Show ZServer List
' Creator: Lent
' CreatedDate: 22/10/2004

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.OPAC
    Public Class WZServerList
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
        Protected WithEvents dtgZDbs As System.Web.UI.WebControls.DataGrid
        Protected WithEvents btnClose As System.Web.UI.WebControls.Button
        Protected WithEvents ddlLabelNote As System.Web.UI.WebControls.DropDownList

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        'Declare variables
        Private objBZdbs As New clsBZ3950

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBZdbs object
            objBZdbs.InterfaceLanguage = Session("InterfaceLanguage")
            objBZdbs.DBServer = Session("DBServer")
            objBZdbs.ConnectionString = Session("ConnectionString")
            Call objBZdbs.Initialize()
        End Sub

        ' BindData method
        ' Purpose: Create Z3950 server list
        Private Sub BindData()
            Dim tblResult As DataTable

            tblResult = objBZdbs.GetZServerList

            ' Write error
            Call WriteErrorMssg(ddlLabelNote.Items(0).Text, objBZdbs.ErrorMsg, ddlLabelNote.Items(1).Text, objBZdbs.ErrorCode)

            If Not tblResult Is Nothing AndAlso tblResult.Rows.Count > 0 Then
                dtgZDbs.DataSource = tblResult
                dtgZDbs.DataBind()
            End If
        End Sub

        ' BindJS method
        ' Include all neccessary javascript function
        Public Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WZFindJs", "<script language = 'javascript' src = '../Js/ACQ/WZFind.js'></script>")

            btnClose.Attributes.Add("onClick", "self.close();")
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose()
        End Sub

        ' Method: Dispose
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBZdbs Is Nothing Then
                    objBZdbs.Dispose(True)
                    objBZdbs = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace