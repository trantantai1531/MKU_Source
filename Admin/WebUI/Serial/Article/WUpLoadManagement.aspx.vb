'UpLoad File
'Creator: Tuannv
Imports System
Imports System.IO
Namespace eMicLibAdmin.WebUI.Serial
    Partial Class WUpLoadManagement
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call BindJS()
        End Sub
        ' Method: BindJS
        ' Purpose: write need js functions
        Private Sub BindJS()
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
        End Sub

        Private Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
            Dim strPath As String
            Dim strFileName As String
            Dim strPathTemp As String = ""
            Dim file As FileInfo
            Dim dr As DirectoryInfo
            Dim strImageFile As String
            Dim strJS As String = ""
            Dim objDirInfor As DirectoryInfo

            Randomize()
            strImageFile = Year(Now) & CStr(Month(Now)).PadLeft(2, "0") & Month(Now) & CStr(Day(Now)).PadLeft(2, "0") & Day(Now) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65) & Chr(Int(25 * Rnd(1)) + 65)
            If Not strImageFile = "" Then
                strPath = Server.MapPath("../../Serial/FileUpload")
                objDirInfor = New DirectoryInfo(strPath)
                If Not objDirInfor.Exists Then
                    Call objDirInfor.Create()
                End If
                strFileName = UpLoadFiles(FileUpload, strPath, strImageFile)

                ' Catch error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, ErrorMsg, ddlLabel.Items(0).Text, ErrorCode)

                Try
                    strPath = strPath.Replace("\", "\\").Replace("/", "//")
                    strJS = "opener.document.forms[0].FileAttach.value = '" & strFileName & "';"
                Catch ex As Exception
                End Try
                Page.RegisterClientScriptBlock("UploadManagement", "<script language = 'javascript'>" & strJS & "self.close();</script>")
            End If

        End Sub
    End Class
End Namespace

