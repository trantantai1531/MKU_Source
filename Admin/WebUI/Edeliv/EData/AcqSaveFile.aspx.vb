﻿Imports ComponentArt.Web.UI
Imports System.Data
Imports System.IO

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqSaveFile
        Inherits clsWBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Call DownloadFile()
            End If
        End Sub

        Private Sub DownloadFile()
            'Dim tblTemp As DataTable
            Dim strFileFullName As String = ""
            Dim strFileExt As String = ""
            Dim strFileContentType As String = ""
            Dim objFileInfor As FileInfo


            'If IsNumeric(Request("ModuleID")) Then
            '    tblTemp = objBCDBS.GetTempFilePath(CInt(Request("ModuleID")))
            'End If
            'If Not Trim(Request("FileName")) & "" = "" AndAlso tblTemp.Rows.Count > 0 AndAlso tblTemp.Rows.Count > 0 Then


            ' Check exists 
            Try
                If Not Request("FileName") Is Nothing AndAlso Request("FileName") <> "" Then
                    If Not Request("bol") Is Nothing AndAlso Request("bol") = 1 Then
                        strFileFullName = Session("FileName")
                    Else
                        If File.Exists(Request("FileName")) Then
                            strFileFullName = Request("FileName")
                        Else
                            strFileFullName = Server.MapPath(Me.getUploadRoot() & Request("FileName"))
                        End If
                    End If
                    objFileInfor = New FileInfo(strFileFullName)
                    If objFileInfor.Exists Then

                        strFileExt = Replace(LCase(objFileInfor.Extension), ".", "")
                        Select Case strFileExt
                            Case "pdf"
                                strFileContentType = "application/pdf"
                            Case "doc", "docx"
                                strFileContentType = "application/msword"
                            Case "txt"
                                strFileContentType = "text/plain"
                            Case "rtf"
                                strFileContentType = "application/rtf"
                            Case "html", "htm"
                                strFileContentType = "text/html"
                            Case "xls", "xlsx"
                                strFileContentType = "application/vnd.ms-excel"
                            Case "ppt", "pps", "pptx"
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
                        'tblTemp = Nothing

                        ' Stop the execution of this page
                        Response.End()
                    End If
                End If
            Catch ex As Exception

            End Try

        End Sub
    End Class
End Namespace

