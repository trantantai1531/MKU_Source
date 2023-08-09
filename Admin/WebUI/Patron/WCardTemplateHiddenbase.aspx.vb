' Class: WCardTemplatePreview
' Puspose: get patron card information
' Creator: Sondp
' CreatedDate: 21-1-2005
' Modification History:
'   - 25/04/2005 by Oanhtn: review

Imports eMicLibAdmin.BusinessRules.Patron
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WCardTemplateHiddenbase
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
        Private objBCT As New clsBCommonTemplate
        Private objBCDBS As New clsBCommonDBSystem

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            Call BindJS()
            Call UploadTemplate()
        End Sub

        ' Method: Initialize
        Private Sub Initialize()
            ' Initialize objBCT object
            objBCT.DBServer = Session("DBServer")
            objBCT.ConnectionString = Session("ConnectionString")
            objBCT.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCT.Initialize()

            ' Initialize objBCDBS object
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()
        End Sub

        ' Method: BindJS
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("WCardTemplateJs", "<script language = 'javascript' src = 'js/WCardTemplateHiddenbase.js'></script>")
        End Sub

        ' Method: UpLoadTemplate
        Private Sub UploadTemplate()
            Dim tblTemplate As New DataTable
            objBCT.TemplateType = 5
            objBCT.TemplateID = CStr(Request.QueryString("TemplateID"))
            tblTemplate = objBCT.GetTemplate()

            ' Check error
            Call WriteErrorMssg(objBCT.ErrorCode, objBCT.ErrorMsg)

            If Not tblTemplate Is Nothing AndAlso tblTemplate.Rows.Count > 0 Then
                Page.RegisterClientScriptBlock("LoadTitleJs", "<script language='javascript'>parent.Workform.document.forms[0].txtTitle.value='" & tblTemplate.Rows(0).Item("Title") & "';</script>")
                Page.RegisterClientScriptBlock("LoadContentJs", "<script language='javascript'>parent.Workform.document.forms[0].txtContent.value='" & Replace(Replace(tblTemplate.Rows(0).Item("Content"), vbCrLf, "\n"), "'", "\'") & "';</script>")
                Page.RegisterClientScriptBlock("LoadfckContentJs", "<script language='javascript'>showTemplate('" & Replace(Replace(tblTemplate.Rows(0).Item("Content"), vbCrLf, "\n"), "'", "\'") & "');</script>")
            Else
                Page.RegisterClientScriptBlock("LoadTitleJs", "<script language='javascript'>parent.Workform.document.forms[0].txtTitle.value='';</script>")
                Page.RegisterClientScriptBlock("LoadContentJs", "<script language='javascript'>parent.Workform.document.forms[0].txtContent.value='';</script>")
                Page.RegisterClientScriptBlock("LoadfckContentJs", "<script language='javascript'>parent.Workform.document.forms[0].fckContent.value='';</script>")
            End If
        End Sub

        ' Event: Page_Unload
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            If Not objBCT Is Nothing Then
                objBCT.Dispose(True)
                objBCT = Nothing
            End If
            If Not objBCDBS Is Nothing Then
                objBCDBS.Dispose(True)
                objBCDBS = Nothing
            End If
        End Sub
    End Class
End Namespace