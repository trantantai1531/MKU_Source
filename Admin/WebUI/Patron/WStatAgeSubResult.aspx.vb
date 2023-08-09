Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common
Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WStatAgeSubResult
        Inherits clsWBase
        Private objBPatronCollection As New clsBPatronCollection
        Private objBCChart As New clsBCommonChart
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindScript()
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBPatronCollection object
            objBPatronCollection.DBServer = Session("DBServer")
            objBPatronCollection.ConnectionString = Session("ConnectionString")
            objBPatronCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBPatronCollection.initialize()

            ' Initialize objBCChart object
            objBCChart.DBServer = Session("DBServer")
            objBCChart.ConnectionString = Session("ConnectionString")
            objBCChart.InterfaceLanguage = Session("InterfaceLanguage")
            objBCChart.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("WStatAgeResultJs", "<script language='javascript' src='js/WStatAgeResult.js'></script>")
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPatronCollection Is Nothing Then
                objBPatronCollection.Dispose(True)
                objBPatronCollection = Nothing
            End If
            If Not objBCChart Is Nothing Then
                objBCChart.Dispose(True)
                objBCChart = Nothing
            End If
        End Sub
    End Class
End Namespace