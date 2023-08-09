' Class: WLoadTemplate
' Puspose: Load template's content to opener form
' Creator: Sondp
' CreatedDate: 29/11/2004
' Modification History:
'   24/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.ILL
    Partial Class WLoadTemplate
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
        Private objBCTemplate As New clsBCommonTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindScript()
            Call LoadBackData()
        End Sub

        ' Method: Initialize
        ' Purpose: Init all need objects
        Private Sub Initialize()
            ' Initialize objBCTemplate object
            objBCTemplate.ConnectionString = Session("ConnectionString")
            objBCTemplate.InterfaceLanguage = Session("InterfaceLanguage")
            objBCTemplate.DBServer = Session("DBServer")
            Call objBCTemplate.Initialize()
        End Sub

        ' Method: BindScript
        ' Purpose: Include all need js functions
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("TempalteJs", "<script language='javascript' src='../JS/ToolsMan/WTemplate.js'></script>")
        End Sub

        ' Method: LoadBackData
        ' Purpose: load back data to opener form
        Private Sub LoadBackData()
            Dim strJavaScript As String = ""
            Dim tblTemplate As New DataTable

            If Request.QueryString("TemplateID") = 0 Then
                strJavaScript = "RefreshData();"
            Else
                strJavaScript = "RefreshData();"

                ' Get content of the selected template
                objBCTemplate.TemplateID = Request.QueryString("TemplateID")
                objBCTemplate.TemplateType = Request.QueryString("TemplateType")
                tblTemplate = objBCTemplate.GetTemplate

                Call WriteErrorMssg(objBCTemplate.ErrorCode, objBCTemplate.ErrorMsg)

                If Not tblTemplate Is Nothing Then
                    If tblTemplate.Rows.Count > 0 Then
                        strJavaScript = "LoadBackData('" & tblTemplate.Rows(0).Item("Title") & "','" & tblTemplate.Rows(0).Item("Content") & "');"
                    End If
                End If
            End If
            ' Register Client Action
            Page.RegisterClientScriptBlock("LoadBackDataJs", "<script language='javascript'> " & strJavaScript & "</script>")
        End Sub

        ' Event: Page_UnLoad
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Method: Dispose
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCTemplate Is Nothing Then
                    objBCTemplate.Dispose(True)
                    objBCTemplate = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace