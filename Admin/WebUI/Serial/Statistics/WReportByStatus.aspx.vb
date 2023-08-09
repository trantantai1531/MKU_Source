' Class: WReportByStatus
' Puspose: create Status Report
' Creator: Oanhtn
' CreatedDate: 21/09/2004
' Modification history:
' Date: 10/10/2004
' Modify by: Tuanhv, Lent 
' Works: 
'       + Change method: BindData
'       + Repair: Interface form

Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WReportByStatus
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
        Private objBPC As New clsBPeriodicalCollection

        ' Page_Load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call BindData()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            'Init objBPC object
            objBPC.InterfaceLanguage = Session("InterfaceLanguage")
            objBPC.DBServer = Session("DBServer")
            objBPC.ConnectionString = Session("ConnectionString")
            objBPC.Initialize()
        End Sub

        'Bind javascript
        Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("StatJs", "<script language = 'javascript' src = '../Js/Statistics/WStatistic.js'></script>")
        End Sub

        'Bind data to datagrid
        Sub BindData()
            Dim tblResult As DataTable
            'Check statistic link to form
            Try
                'Show result
                tblResult = objBPC.GetGenExpriedItem
                ' Write error
                Call WriteErrorMssg(ddlLabel.Items(0).Text, objBPC.ErrorMsg, ddlLabel.Items(1).Text, objBPC.ErrorCode)

                If Not tblResult Is Nothing Then
                    DgrResult.DataSource = tblResult
                    DgrResult.DataBind()
                End If
                tblResult = Nothing
            Catch ex As Exception
            End Try
        End Sub

        ' Event: DgrResult_PageIndexChanged
        Private Sub DgrResult_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles DgrResult.PageIndexChanged
            DgrResult.CurrentPageIndex = e.NewPageIndex()
            Call BindData()
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBPC Is Nothing Then
                    objBPC.Dispose(True)
                    objBPC = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace