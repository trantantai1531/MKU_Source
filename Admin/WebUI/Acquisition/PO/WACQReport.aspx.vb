' class 
' Puspose: 
' Creator: 
' CreatedDate: 
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.BusinessRules.Acquisition.clsBItemOrder
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WACQReport
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

        Private objBIO As New clsBItemOrder
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call InitializeData()
            Dim objmetric As New Metric
            objmetric = objBIO.GenSeparetedStore(3, 1, 290)
            If Not objmetric.Equals(Nothing) Then
                lblDisplay.Text = objmetric.objData(0)
            End If
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBIO object
            objBIO.InterfaceLanguage = Session("InterfaceLanguage")
            objBIO.DBServer = Session("DBServer")
            objBIO.ConnectionString = Session("ConnectionString")
            objBIO.Initialize()
        End Sub

        ' Initialize data method
        Private Sub InitializeData()
            Dim collecCollumTitle As New Collection
            Dim inti As Integer
            ' For CollumTitle(s)
            For inti = 0 To ddlCollumTitle.Items.Count - 1
                collecCollumTitle.Add(ddlCollumTitle.Items(inti).Text, ddlCollumTitle.Items(inti).Value)
            Next
            objBIO.TemplateID = 290
            objBIO.CollumTitle = collecCollumTitle
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBIO Is Nothing Then
                objBIO.Dispose(True)
                objBIO = Nothing
            End If
        End Sub
    End Class
End Namespace