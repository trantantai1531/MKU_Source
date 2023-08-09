' class: Display CopyNumber Released
' Puspose: Generate CopyNumber Removed
' Creator: Sondp
' CreatedDate: 08/03/2005
' Modification History:

Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WCopyNumRemR
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

        Private objBT As New clsBTemplate
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            dgrResult.Visible = False
            If Not Page.IsPostBack Then
                dgrResult.PageSize = Request.QueryString("pagesize")
                If Not Session("IDs") Is Nothing Then
                    hdIDs.Value = Session("IDs")
                Else
                    hdIDs.Value = ""
                End If
                Call BindData()
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBT object
            objBT.InterfaceLanguage = Session("InterfaceLanguage")
            objBT.DBServer = Session("DBServer")
            objBT.ConnectionString = Session("ConnectionString")
            objBT.Initialize()
        End Sub

        ' BindData method
        Private Sub BindData()
            Dim tblData As New DataTable
            If Not hdIDs.Value = "" Then
                If Len(hdIDs.Value) > 4000 Then
                    hdIDs.Value = Left(hdIDs.Value, 4000)
                End If
                tblData = objBT.GetCopyNumRem(hdIDs.Value)
                If Not tblData Is Nothing Then
                    If tblData.Rows.Count > 0 Then
                        lblTitle.Text &= Request.QueryString("LiquidCode")
                        dgrResult.Visible = True
                        dgrResult.DataSource = tblData
                        dgrResult.DataBind()
                    End If
                End If
            End If
        End Sub

        Private Sub dgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrResult.PageIndexChanged
            dgrResult.CurrentPageIndex = e.NewPageIndex
            Call BindData()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBT Is Nothing Then
                objBT.Dispose(True)
                objBT = Nothing
            End If
        End Sub
    End Class
End Namespace