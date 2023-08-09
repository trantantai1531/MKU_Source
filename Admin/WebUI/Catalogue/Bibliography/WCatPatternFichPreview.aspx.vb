Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPatternFichPreview
        Inherits clsWBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents CatPatternPreview As System.Web.UI.HtmlControls.HtmlTable


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        ' Declare variables
        Private objbCatTemplate As New clsBCatalogueTemplate

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            If Not Page.IsPostBack Then
                Call Bindata()
            End If
        End Sub

        ' Method: Initialize
        ' Initialize all objects use in form method
        Public Sub Initialize()
            'clsBCatalogueTemplate's properties
            objbCatTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objbCatTemplate.DBServer = Session("DBServer")
            objbCatTemplate.ConnectionString = Session("ConnectionString")
            Call objbCatTemplate.Initialize()
        End Sub

        ' BindScript method
        Public Sub BindScript()
            btnClose.Attributes.Add("onclick", "javascript:self.close();")
        End Sub

        ' Bindata method
        ' Purpose: Show data tempale for Catalogue
        Sub Bindata()
            Dim collData As New Collection 'Why 45? because 45 = total items in files ( resource ) WCatPatternCataloguePreviewSR.vi.resx
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

            'Set data, properties for objbCatTemplate
            objbCatTemplate.Data = collData
            objbCatTemplate.Header = Request("txtHeader")
            objbCatTemplate.Content = Request("txtContent")
            objbCatTemplate.Footer = Request("txtFooter")
            objbCatTemplate.GenerateCatalogueTemplate()
            Response.Write(objbCatTemplate.Temp)
            lblContent.Text = objbCatTemplate.OutMsg
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objbCatTemplate Is Nothing Then
                    objbCatTemplate.Dispose(True)
                    objbCatTemplate = Nothing
                End If
                ' Call Dispose on your base class.
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace