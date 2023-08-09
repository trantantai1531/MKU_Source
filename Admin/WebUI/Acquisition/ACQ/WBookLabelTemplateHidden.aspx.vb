' class 
' Puspose: Load BookLabelTemplate
' Creator: Sondp
' CreatedDate: 20/02/2005
' Modification History:

Imports System
Imports System.Web
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.BusinessRules
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Acquisition

Namespace eMicLibAdmin.WebUI.Acquisition
    Partial Class WBookLabelTemplateHidden
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

        Private objBCT As New clsBCommonTemplate
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Initialize()
            Call BindJS()
            If Not Page.IsPostBack Then
                If Request.QueryString("TemplateID") & "" <> "" Then
                    Dim tblTemplate As New DataTable
                    'Dim strJs As String
                    objBCT.TemplateID = CInt(Request.QueryString("TemplateID"))
                    objBCT.TemplateType = 4
                    tblTemplate = objBCT.GetTemplate
                    'If Not tblTemplate Is Nothing Then
                    '    If tblTemplate.Rows.Count > 0 Then
                    '        strJs &= "top.main.mainacq.document.forms[0].txtContent.value='" & Replace(tblTemplate.Rows(0).Item("Content"), vbCrLf, "\n") & "';"
                    '        strJs &= "top.main.mainacq.document.forms[0].txtTitle.value='" & Replace(tblTemplate.Rows(0).Item("Title"), vbCrLf, "\n") & "';"
                    '    End If
                    'End If
                    'Page.RegisterClientScriptBlock("UploadDataJs", "<script language='javascript'>" & strJs & "</script>")

                    Call WriteErrorMssg(objBCT.ErrorCode, objBCT.ErrorMsg)

                    If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                        Page.RegisterClientScriptBlock("LoadTitleJs", "<script language='javascript'>console.log(parent); parent.mainacq.document.forms[0].txtTitle.value='" & tblTemplate.Rows(0).Item("Title") & "';</script>")
                        Page.RegisterClientScriptBlock("LoadContentJs", "<script language='javascript'>console.log(parent);parent.mainacq.document.forms[0].txtContent.value='" & Replace(Replace(tblTemplate.Rows(0).Item("Content"), vbCrLf, "\n"), "'", "\'") & "';</script>")
                        Page.RegisterClientScriptBlock("LoadfckContentJs", "<script language='javascript'>showTemplate('" & Replace(Replace(tblTemplate.Rows(0).Item("Content"), vbCrLf, "\n"), "'", "\'") & "');</script>")
                    Else
                        Page.RegisterClientScriptBlock("LoadTitleJs", "<script language='javascript'>console.log(parent);parent.mainacq.document.forms[0].txtTitle.value='';</script>")
                        Page.RegisterClientScriptBlock("LoadContentJs", "<script language='javascript'>console.log(parent);parent.mainacq.document.forms[0].txtContent.value='';</script>")
                        Page.RegisterClientScriptBlock("LoadfckContentJs", "<script language='javascript'>console.log(parent);parent.mainacq.document.forms[0].fckContent.value='';</script>")
                    End If
                End If
            End If
        End Sub


        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WBookLabelTemplateHiddenJs", "<script language = 'javascript' src = '../js/ACQ/WBookLabelTemplateHidden.js'></script>")
        End Sub

        ' Initialize method
        Private Sub Initialize()
            ' Initialize objBCT object
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.Initialize()
        End Sub

        ' Page_Unload method
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
        End Sub
    End Class
End Namespace