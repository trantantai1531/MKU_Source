Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WExportToXML
        Inherits clsWEData

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

        ' page_load event
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call Initialize()
            btnClose.Attributes.Add("OnClick", "javascript:self.close();return false;")
            Call ExportXMLRec()
        End Sub

        ' CheckFormPermission method
        Private Sub CheckFormPermission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' BindXMLRec method
        Private Sub ExportXMLRec()
            If Not Request("FileIDs") & "" = "" Then
                Dim intSuccess As Integer = 0
                Dim intFail As Integer = 0
                Dim strFileName As String = ""
                Dim strFilePath As String = ""

                ' Get the string of file IDs
                strIDs = Right(Request("FileIDs"), Len(Request("FileIDs")) - 1)

                ' Export to XML file
                If ExportXMLToFile(intSuccess, intFail, strFileName, strFilePath) = 0 Then
                    Call WriteErrorMssg(ddlLabel.Items(2).Text, strErrorMsg, ddlLabel.Items(1).Text, intErrorCode)
                    lblSucces.Visible = True
                    lblFail.Visible = False
                    lblSuccessCount.Text = CStr(intSuccess)
                    lblFailCount.Text = CStr(intFail)
                    lblCount.Text = CStr(intSuccess + intFail)

                    ' get the result
                    If Not strFileName = "" And Not strFilePath = "" Then
                        lblFile.Visible = True
                        lnkFile.Visible = True
                        lnkFile.Text = strFileName
                        'lnkFile.NavigateUrl = strFilePath
                        lnkFile.Target = "Hiddenbase"
                        lnkFile.NavigateUrl = "javascript:parent.top.main.Hiddenbase.location.href='../Common/WSaveTempFile.aspx?ModuleID=9&FileName=" & strFileName & "';"
                    Else
                        lblFile.Visible = False
                        lnkFile.Visible = False
                    End If
                Else
                    Call WriteErrorMssg(ddlLabel.Items(2).Text, strErrorMsg, ddlLabel.Items(1).Text, intErrorCode)
                    lblSucces.Visible = False
                    lblFail.Visible = True
                    lblSuccessCount.Text = CStr(intSuccess)
                    lblFailCount.Text = CStr(intFail)
                    lblCount.Text = CStr(intSuccess + intFail)
                    lblFile.Visible = False
                    lnkFile.Visible = False
                End If
            Else
                'Page.RegisterClientScriptBlock("Invalid", "<script language='javascript'>alert('" & ddlLabel.Items(3).Text & "'); self.close();</script>")
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

    End Class
End Namespace
