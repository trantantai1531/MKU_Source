' WZDbsList class
' Purpose: Display Z3950 servers list
' Creator: Oanhtn
' CreatedDate: 12/08/2004
' Modification history:
'   + 24/02/2005 by Oanhtn: review & update

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WZDbsList
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
        Private objBZ3950 As New clsBZ3950

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindData()
        End Sub

        ' Initialize method
        ' Purpose: Init all objects
        Private Sub Initialize()
            ' Init objBZ3950 object
            objBZ3950.InterfaceLanguage = Session("InterfaceLanguage")
            objBZ3950.DBServer = Session("DBServer")
            objBZ3950.ConnectionString = Session("ConnectionString")
            objBZ3950.Initialize()

            ' Resister Javascripts File
            Page.RegisterClientScriptBlock("SelfJs", "<script language = 'javascript' src = '../js/Catalogue/WZFind.js'></script>")
            btnClose.Attributes.Add("onClick", "self.close();")
        End Sub

        ' BindData method
        ' Purpose: Create Z3950 server list
        Private Sub BindData()
            Dim tblTemp As DataTable

            tblTemp = objBZ3950.GetZServerList
            Call WriteErrorMssg(ddlLabel.Items(1).Text, objBZ3950.ErrorMsg, ddlLabel.Items(0).Text, objBZ3950.ErrorCode)

            dtgZDbs.DataSource = tblTemp
            dtgZDbs.DataBind()
        End Sub

        ' Page_Unload event
        Private Sub Page_UnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Release all object
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBZ3950 Is Nothing Then
                    objBZ3950.Dispose(True)
                    objBZ3950 = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace