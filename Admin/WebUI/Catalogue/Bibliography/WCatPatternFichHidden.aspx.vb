Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPatternFichHidden
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

        Private objBCommonTemplate As New clsBCommonTemplate

        'Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim tblTemplate As DataTable = Nothing
            Dim inti As Integer
            Dim arrContent() As String
            Dim strHeader As String = ""
            Dim strContent As String = ""
            Dim strFooter As String = ""

            'Init all object for form
            Call Initialize()

            'get TemplateID from WCatPatternFichDisplay.aspx
            If Not Request("ID") & "" = "" Then
                Dim strScript As String = ""

                If Request("ID") = 0 Then 'clear WCatPatternCatalogueDisplay.aspx
                    strScript = "ClearForm(); parent.Display.document.forms[0].reset(); parent.Display.document.forms[0].txtTitle.focus();"
                Else 'load data to WCatPatternCatalogueDisplay.aspx

                    objBCommonTemplate.TemplateType = 15 'Template type
                    objBCommonTemplate.TemplateID = Request("ID")
                    tblTemplate = objBCommonTemplate.GetTemplate
                    If Not tblTemplate Is Nothing Then
                        If tblTemplate.Rows.Count > 0 Then
                            arrContent = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                            If UBound(arrContent) > 0 Then
                                strHeader = arrContent(0).Replace(vbCrLf, "\n")
                                strHeader = strHeader.Replace("'", "\'")
                                strContent = arrContent(1).Replace(vbCrLf, "\n")
                                strContent = strContent.Replace("'", "\'")
                                strFooter = arrContent(2).Replace(vbCrLf, "\n")
                                strFooter = strFooter.Replace("'", "\'")
                            End If
                            strScript = "UpLoadData('" & tblTemplate.Rows(0).Item("Title") & "','" & strHeader & "','" & strContent & "','" & strFooter & "');"
                        End If
                    End If
                End If

                ' Register client script action
                Page.RegisterClientScriptBlock("BindDataJs", "<script language='javascript'>" & strScript & "</script>")
            End If
        End Sub

        'Initialize all object use in form
        Public Sub Initialize()
            ' objBCommonTemplate object
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonTemplate.Initialize()

            ' Register Client Action
            Page.RegisterClientScriptBlock("PatternCatalogueJs", "<script language='javascript' src='../js/Bibliography/WCatPatternFich.js'></script>")
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose Method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                ' Release unmanaged resources.
                If Not objBCommonTemplate Is Nothing Then
                    objBCommonTemplate.Dispose(True)
                    objBCommonTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace