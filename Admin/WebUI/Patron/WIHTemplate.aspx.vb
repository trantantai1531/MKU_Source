' Class: WIHTemplate
' Puspose: Get content of the selected template & load to opener form
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 13/05/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WIHTemplate
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
        Private objBPT As New clsBPatronTemplate

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()

            If Not IsDBNull(CStr(Request.QueryString("TemplateID"))) Then
                Dim tblExTemplate As New DataTable
                Dim strJsCommand As String

                If Request.QueryString("TemplateID") = 0 Then
                    strJsCommand = "parent.Workform.document.forms[0].txtTitle.value='';parent.Workform.document.forms[0].txtContent.value='';parent.Workform.document.forms[0].txtTitle.focus();"
                Else
                    Try
                        objBPT.TemplateID = CStr(Request.QueryString("TemplateID"))
                        objBPT.TemplateType = 30
                        tblExTemplate = objBPT.GetPatronTemplate()

                        ' Check error
                        Call WriteErrorMssg(objBPT.ErrorCode, objBPT.ErrorMsg)

                        If Not tblExTemplate Is Nothing AndAlso tblExTemplate.Rows.Count > 0 Then
                            strJsCommand = "parent.Workform.document.forms[0].txtTitle.value='" + tblExTemplate.Rows(0).Item("Title") + "';" + "parent.Workform.document.forms[0].txtContent.value='" + Replace(tblExTemplate.Rows(0).Item("Content"), vbCrLf, "\n") + "';"
                        End If
                    Catch ex As Exception
                    End Try
                End If
                Page.RegisterClientScriptBlock("LoadBackDataJs", "<script language='javascript'>" & strJsCommand & "</script>")
            End If
        End Sub

        ' Method: Initialize 
        Private Sub Initialize()
            ' Initialize objBPT object
            objBPT.DBServer = Session("DBServer")
            objBPT.ConnectionString = Session("ConnectionString")
            objBPT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBPT.Initialize()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBPT Is Nothing Then
                objBPT.Dispose(True)
                objBPT = Nothing
            End If
        End Sub
    End Class
End Namespace