Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class WCatPatternHidden
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

        'Evenr: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim tblTemplate As DataTable
            Dim inti As Integer
            Dim arrContent() As String
            Dim strHeader As String = ""
            Dim strContent As String = ""
            Dim strFooter As String = ""

            'Init all object use in form
            Call Initialize()
            'Showdata
            If Not Request("ID") & "" = "" Then
                Dim strScript As String = ""

                ' Clear Display Form
                If Request("ID") = 0 Then
                    strScript = "ClearForm();parent.Display.document.forms[0].reset();parent.Display.document.forms[0].txtTitle.focus();"
                Else ' Load data to Display Form

                    objBCommonTemplate.TemplateType = 1
                    objBCommonTemplate.TemplateID = Request("ID")
                    tblTemplate = objBCommonTemplate.GetTemplate
                    If Not tblTemplate Is Nothing Then
                        If tblTemplate.Rows.Count > 0 Then
                            arrContent = Split(tblTemplate.Rows(0).Item("Content"), Chr(9))
                            If UBound(arrContent) > 0 Then
                                strHeader = arrContent(0).Replace(vbCrLf, "\n")
                                strContent = arrContent(1).Replace(vbCrLf, "\n")
                                strFooter = arrContent(2).Replace(vbCrLf, "\n")
                            End If
                            ' Load data to Display Form
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
            ' Object objBCommonTemplate 
            objBCommonTemplate.ConnectionString = Session("ConnectionString")
            objBCommonTemplate.DBServer = Session("DBServer")
            objBCommonTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCommonTemplate.Initialize()
            ' Register Client Script
            Page.RegisterClientScriptBlock("PatternCatalogueJs", "<script language='javascript' src='../js/Bibliography/WCatPatternCatalogue.js'></script>")
        End Sub

        'Event: Page_Unload
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
                ' Call Dispose on your base class.
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace