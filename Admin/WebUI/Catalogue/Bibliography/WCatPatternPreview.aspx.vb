Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPatternPreview
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents lblLabel2 As System.Web.UI.WebControls.Label
        Protected WithEvents lblLabel3 As System.Web.UI.WebControls.Label

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objBCatTemplate As New clsBCatalogueTemplate

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Init all object use in form
            Call Initialize()
            'Bind javascript
            Call BindScript()
            If Not Page.IsPostBack Then
                'Show data
                Call Bindata()
            End If
        End Sub

        'Initialize all object use in form
        Public Sub Initialize()
            ' objBCatTemplate object 
            objBCatTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCatTemplate.DBServer = Session("DBServer")
            objBCatTemplate.ConnectionString = Session("ConnectionString")
            objBCatTemplate.Initialize()
        End Sub

        ' BindScript
        Public Sub BindScript()
            ' Close form
            btnClose.Attributes.Add("onclick", "javascript:self.close();")
        End Sub

        ' BindData method
        Sub Bindata()
            ' Declare variables
            Dim collData As New Collection
            Dim arrText(5) As String
            Dim arrValue(5) As String
            Dim inti As Integer

            For inti = 0 To ddlViewField.Items.Count - 1
                collData.Add(Trim(ddlViewField.Items(inti).Text), ddlViewField.Items(inti).Value)
            Next

            arrText(0) = CStr(Day(Now))
            arrValue(0) = "CURDAY"
            collData.Add(arrText(0), arrValue(0))
            arrText(1) = CStr(Month(Now))
            arrValue(1) = "CURMONTH"
            collData.Add(arrText(1), arrValue(1))
            arrText(2) = CStr(Year(Now))
            arrValue(2) = "CURYEAR"
            collData.Add(arrText(2), arrValue(2))

            'Set data, properties for objBCatTemplate
            objBCatTemplate.Data = collData
            objBCatTemplate.Header = Request("txtHeader")
            objBCatTemplate.Content = Request("txtContent")
            objBCatTemplate.Footer = Request("txtFooter")
            objBCatTemplate.GenerateCatalogueTemplate()

            Response.Write(objBCatTemplate.Temp)
            lblContent.Text = objBCatTemplate.OutMsg
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBCatTemplate Is Nothing Then
                    objBCatTemplate.Dispose(True)
                    objBCatTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub
    End Class
End Namespace