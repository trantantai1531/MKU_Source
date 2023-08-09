' Class: WUpload
' Purpose: Upload patron image
' Creator: Kiemdv
' Created Date: 
' Modification history:
'   - 27/04/2005 by Oanhtn: review

Imports System
Imports System.IO

Namespace eMicLibAdmin.WebUI.Patron
    Partial Class WUpload
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

        ' Event: Page_Load
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Call BindJS()
        End Sub

        ' Method: BindJS
        ' Purpose: write need js functions
        Private Sub BindJS()
            Page.RegisterClientScriptBlock("CommonJs", "<script language='javascript' src='../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WBatchPatronUpdateJs", "<script language = 'javascript' src='js/WUpload.js'></script>")
            btnClose.Attributes.Add("OnClick", "self.close(); return false;")
            btnUpload.Attributes.Add("OnClick", "javascript:if (!CheckFileExt()) {alert('" & ddlLabel.Items(2).Text & "'); return false;};")
        End Sub

        ' Event: btnUpload_Click
        ' Purpose: upload patron's image
        Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
            Dim strPath As String
            Dim strFileName As String
            Dim strImageFile As String = Request("Code").ToString.Trim
            Dim strJS As String = ""
            Dim cardImage As System.Drawing.Image = Nothing

            If Not strImageFile = "" Then
                strJS = strJS & "opener.document.images['imgPatron'].src = '../Images/Card/Empty.gif';"
                strPath = Server.MapPath("../Images/Card")
                '' delete Exists file name 
                For Each fileName As String In IO.Directory.GetFiles(strPath, strImageFile & ".*")
                    IO.File.Delete(fileName)
                Next
                strFileName = UpLoadFiles(FileUpload, strPath, strImageFile)

                ' Catch error
                Call WriteErrorMssg(ddlLabel.Items(1).Text, ErrorMsg, ddlLabel.Items(0).Text, ErrorCode)

                Try
                    strJS = "opener.document.images['imgPatron'].src = '../images/card/" & strFileName & "';"
                    cardImage = System.Drawing.Image.FromFile(Server.MapPath("../Images/Card/") & strFileName)
                    If cardImage.Width > cardImage.Height Then
                        strJS = strJS & "opener.document.images['imgPatron'].width = 80;"
                    Else
                        strJS = strJS & "opener.document.images['imgPatron'].height = 120;"
                    End If
                    cardImage.Dispose()
                    Page.RegisterClientScriptBlock("AddPortrait", "<script language = 'javascript'>" & strJS & "opener.document.forms[0].hidCode.value = '" & strFileName & "'; self.close();</script>")
                Catch ex As Exception
                    strJS = strJS & "opener.document.images['imgPatron'].width = 80;"
                End Try
            End If
        End Sub
    End Class
End Namespace
