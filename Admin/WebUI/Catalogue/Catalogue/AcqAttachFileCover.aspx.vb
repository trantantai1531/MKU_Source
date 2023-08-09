Imports System.IO
Imports System.IO.Path
Imports eMicLibAdmin.WebUI.Common
Imports System.Net

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class Catalogue_Catalogue_AcqAttachFileCover
        Inherits clsWBase

        Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call BindJavascript()
            Call Process()
        End Sub
        Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
            Try
                '' Check size of file
                'If Not CheckSize(CLng(hidFileSize.Value)) Then
                '    'Page.RegisterClientScriptBlock("Excess", "<script language = 'javascript'>alert('" & ddlLabel.Items(0).Text & "');</script>")
                'Else

                'End If
                Dim strJS As String = ""
                Dim strFieldValue As String = hidSFile.Value
                strFieldValue = Path.GetFileName(Session("imageCover"))
                strJS = strJS & "top.main." & hidWField.Value & ".value = '';" & "top.main." & hidWField.Value & ".value = '" & strFieldValue & "';" & Chr(13)
                'strJS = strJS & "ud('" & hidFieldCode.Value & "');" & Chr(13)
                strJS = strJS & " myUpdateRecord('" & hidFieldCode.Value & "');" & Chr(13)
                Page.RegisterClientScriptBlock("LoadBack", "<script language = 'javascript'>" & strJS & ";</script>")
                Page.RegisterClientScriptBlock("UploadSuccess", "<script language = 'javascript'>top.closeDialog('Dialog_content');</script>")
                'Page.RegisterClientScriptBlock("UploadSuccess", "<script language = 'javascript'>top.closeDialog('Dialog_content');</script>")
            Catch ex As Exception
            End Try
        End Sub
        ' BindJavascript method
        ' Purpose: include all neccessary javascript function
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js'></script>")
            Page.RegisterClientScriptBlock("WCataUploadToolkitJs", "<script language = 'javascript' src = '../Js/Catalogue/AcqUploadToolkit.js'></script>")

            'btnClose.Attributes.Add("OnClick", "javascript:self.close();")
            'btnClose.Attributes.Add("OnClick", "javascript:top.closeDialog('Dialog_content');")
        End Sub

        ' Process method
        ' Purpose: execute all process now
        Private Sub Process()
            Dim strFieldCode As String = Trim(Request("FieldCode"))
            'Dim tblEDataParameters As DataTable

            ' Reserv
            If Not strFieldCode = "" Then
                hidFieldCode.Value = strFieldCode
            End If
            If Not Request("Repeatable") = "" Then
                hidRepeatable.Value = Request("Repeatable")
            End If
            If Not Request("WField") = "" Then
                hidWField.Value = Request("WField")
            End If
            If Not Request("SField") = "" Then
                hidSField.Value = Request("SField")
            End If
            If Not Request("SFile") = "" Then
                hidSFile.Value = Request("SFile")
            End If

            '' Get some information: allowed, dennied types of fiel, max value of file' size
            'objWEData.FieldCode = strFieldCode
            'tblEDataParameters = objWEData.GetEDataParams
            'If Not tblEDataParameters Is Nothing Then
            '    If tblEDataParameters.Rows.Count > 0 Then
            '        lblShowFieldCode.Text = tblEDataParameters.Rows(0).Item("FieldCode") & " - " & tblEDataParameters.Rows(0).Item("FieldCodeName")
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("AllowedFileExt")) Then
            '            lblAllowedFileNames.Text = CStr(tblEDataParameters.Rows(0).Item("AllowedFileExt"))
            '        End If
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("DeniedFileExt")) AndAlso tblEDataParameters.Rows(0).Item("DeniedFileExt") <> "" Then
            '            lblDenniedFileNames.Visible = True
            '            lblDenniedFiles.Visible = True
            '            lblDenniedFileNames.Text = CStr(tblEDataParameters.Rows(0).Item("DeniedFileExt"))
            '        Else
            '            lblDenniedFileNames.Visible = False
            '            lblDenniedFiles.Visible = False
            '        End If
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("Maxsize")) Then
            '            lblMaxSizeDetail.Text = CStr(tblEDataParameters.Rows(0).Item("Maxsize"))
            '        End If
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("AllowedFileExt")) Then
            '            hidAllowedFiles.Value = CStr(tblEDataParameters.Rows(0).Item("AllowedFileExt"))
            '        End If
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("DeniedFileExt")) Then
            '            hidDenniedFiles.Value = CStr(tblEDataParameters.Rows(0).Item("DeniedFileExt").GetType.ToString).Trim
            '        End If
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("Maxsize")) Then
            '            hidFileSize.Value = CStr(tblEDataParameters.Rows(0).Item("Maxsize"))
            '        End If
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("PhysicalPath")) Then
            '            hidPath.Value = CStr(tblEDataParameters.Rows(0).Item("PhysicalPath"))
            '        End If
            '        'If Not IsDBNull(tblEDataParameters.Rows(0).Item("URL")) Then
            '        '    hidURL.Value = CStr(tblEDataParameters.Rows(0).Item("URL"))
            '        'End If
            '        If Not IsDBNull(tblEDataParameters.Rows(0).Item("Prefix")) Then
            '            hidPrefix.Value = tblEDataParameters.Rows(0).Item("Prefix")
            '        End If
            '    End If
            'End If
            'hidURL.Value = GetOneParaSystem("OPAC_URL")
        End Sub

        Private Shared Sub DownloadImage(ByVal url As String, ByVal saveFilename As String)
            Dim strTime As String = DateAndTime.Now.Year & DateAndTime.Now.Month & DateAndTime.Now.Day & DateAndTime.Now.Hour & DateAndTime.Now.Minute & DateAndTime.Now.Second & DateAndTime.Now.Millisecond

            HttpContext.Current.Response.Clear()
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=File_" & strTime & ".jpg")
            HttpContext.Current.Response.ContentType = "application/pdf"
            HttpContext.Current.Response.WriteFile("/Upload/" & url)
            HttpContext.Current.Response.Flush()
            HttpContext.Current.Response.End()
        End Sub

        Protected Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
            Dim strFile As String = ""
            If Not IsNothing(Request.QueryString("sfile")) Then
                strFile = Request.QueryString("sfile")
            End If

            If strFile <> "" Then
                DownloadImage(strFile, "abc.jpg")
            End If
        End Sub
    End Class
End Namespace

