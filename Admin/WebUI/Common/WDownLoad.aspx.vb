' Class: WDownLoad
' Puspose: Allow download selected file
' Creator: Oanhtn
' CreatedDate: 21/01/2005
' Modification History:

Imports System.IO
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI
    Partial Class WDownLoad
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
            Call CheckFormPemission()
            Call Initialize()
            If Not Page.IsPostBack Then
                Call DownloadFile()
            End If
        End Sub

        ' CheckFormPemission method
        ' Purpose: check permission to use this form
        Public Sub CheckFormPemission()
            If Not CheckPemission(166) Then
                Call WriteErrorMssg(ddlLabel.Items(0).Text)
            End If
        End Sub

        ' DownloadFile method
        ' Purpose: download selected file from server
        Private Sub DownloadFile()
            Dim tblTemp As DataTable
            Dim strFileFullName As String
            Dim strFileExt As String
            Dim strFileContentType As String
            Dim lngTotalRec As Long
            Dim objFileInfor As FileInfo
            'Dim objSmartUpload As New aspSmartUpload.SmartUpload

            ' Check exists
            If Not Request("FileID") = "" Then
                strIDs = Request("FileID")
                tblTemp = GetGeneralInfor(7, 0, 0, lngTotalRec)

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then

                        strFileFullName = tblTemp.Rows(0).Item("PhysicalPath")
                        objFileInfor = New FileInfo(strFileFullName)
                        If objFileInfor.Exists Then

                            strFileExt = Replace(LCase(objFileInfor.Extension), ".", "")
                            Select Case strFileExt
                                Case "pdf"
                                    strFileContentType = "application/pdf"
                                Case "doc"
                                    strFileContentType = "application/msword"
                                Case "txt"
                                    strFileContentType = "text/plain"
                                Case "rtf"
                                    strFileContentType = "application/rtf"
                                Case "html", "htm"
                                    strFileContentType = "text/html"
                                Case "xls"
                                    strFileContentType = "application/vnd.ms-excel"
                                Case "ppt", "pps"
                                    strFileContentType = "application/vnd.ms-powerpoint"
                                Case "ps"
                                    strFileContentType = "application/postscript"
                                Case "wri"
                                    strFileContentType = "application/x-mswrite"
                                Case "jpg", "jpeg", "jpe"
                                    strFileContentType = "image/jpeg"
                                Case "gif"
                                    strFileContentType = "application/gif"
                                Case "png"
                                    strFileContentType = "application/png"
                                Case Else
                                    strFileContentType = "application/x-application"
                            End Select

                            ' Clear the current output content from the buffer
                            Response.Clear()

                            ' Add the header that specifies the default filename 
                            ' for the Download/SaveAs dialog
                            Response.AddHeader("Content-Disposition", "attachment; filename=" & objFileInfor.Name)

                            ' Add the header that specifies the file size, so that the 
                            ' browser can show the download progress
                            Response.AddHeader("Content-Length", objFileInfor.Length.ToString())

                            ' Specify that the response is a stream that cannot be read _
                            ' by the client and must be downloaded
                            Response.ContentType = strFileContentType

                            ' Send the file stream to the client
                            Response.WriteFile(objFileInfor.FullName)

                            ' Release objects
                            objFileInfor = Nothing
                            tblTemp = Nothing

                            ' Stop the execution of this page
                            Response.End()
                        End If
                    End If
                End If
            End If
        End Sub

        ' Page UnLoad event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub
    End Class
End Namespace