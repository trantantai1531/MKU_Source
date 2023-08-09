Imports System.IO
Imports System.IO.Path
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI.Catalogue
    Partial Class AcqAttachFileCategory
        Inherits clsWBase
        Protected _rootFolder As String = ""
        Private objBEData As New clsBEData
        Private objBLibrary As New clsBLibrary
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Call Initialize()
            Call BindJavascript()
            If Not IsPostBack AndAlso Not UploadFiles.CausedCallback Then
                hidPathRoot.Value = GetOneParaSystem("EDATA_CATALOGUER")
                Call InitControls()
                Call LoadFileIds()
                Call Process()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init objBEData object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()

            ' Init objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBLibrary.Initialize()
        End Sub

        ' BindJavascript method
        ' Purpose: include all neccessary javascript function
        Private Sub BindJavascript()
            Page.RegisterClientScriptBlock("WCommonJs", "<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataJs", "<script language = 'javascript' src = '../Js/Catalogue/WCata.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            Page.RegisterClientScriptBlock("WCataAttachFileJs", "<script language = 'javascript' src = '../Js/Catalogue/AcqAttachFile.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")

            'btnClose.Attributes.Add("OnClick", "javascript:self.close();")
            btnClose.Attributes.Add("OnClick", "javascript:top.closeDialog('Dialog_content');")
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

            If Not Request("intItemID") Is Nothing AndAlso Request("intItemID") <> "" Then
                hidItemID.Value = Request("intItemID")
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

        Private Sub BindDataFile(Optional strListFileItem As String = "")

        End Sub

        Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
            Try
                Dim strJS As String = ""
                Dim strFieldValue As String = "" ' hidSFile.Value
                If Not Session("uploadCataloger") Is Nothing Then
                    Dim _icountArr As Integer = UBound(Session("uploadCataloger"), 2)
                    Dim strValue As String = ""
                    For _icount As Integer = _icountArr To 0 Step -1
                        If System.IO.File.Exists(System.IO.Path.Combine(Session("uploadCataloger")(0, _icount), Session("uploadCataloger")(1, _icount))) Then
                            Dim _fileInfo As New System.IO.FileInfo(System.IO.Path.Combine(Session("uploadCataloger")(0, _icount), Session("uploadCataloger")(1, _icount)))
                            'If InStr(strFieldValue, "$f" & _fileInfo.Name) = 0 Then
                            '    strFieldValue &= "$f" & _fileInfo.Name
                            'End If
                            If _icount = _icountArr Then
                                strValue = _fileInfo.FullName.Replace(hidPathRoot.Value & "\", "").Replace("\", "/")
                            End If
                            strFieldValue &= "::" & _fileInfo.FullName.Replace(hidPathRoot.Value & "\", "").Replace("\", "/") & "$&"
                        End If
                    Next

                    strJS = strJS & "top.main." & hidWField.Value & ".value = '';" & "top.main." & hidWField.Value & ".value = '" & strValue & "';" & Chr(13)
                    strJS = strJS & "top.main.Sentform.document.forms[0].tag" & hidFieldCode.Value & ".value = '';" & "top.main.Sentform.document.forms[0].tag" & hidFieldCode.Value & ".value = '" & strFieldValue & "';" & Chr(13)

                    strJS = strJS & "myUpdateRecord('" & hidFieldCode.Value & "');"
                    Page.RegisterClientScriptBlock("LoadBack", "<script language = 'javascript'>" & strJS & "</script>")
                    Page.RegisterClientScriptBlock("UploadSuccess", "<script language = 'javascript'>top.closeDialog('Dialog_content');</script>")
                Else
                    Page.RegisterClientScriptBlock("UploadSuccess", "<script language = 'javascript'>alert('Chưa có file upload');</script>")
                End If

            Catch ex As Exception
            End Try
        End Sub

        Private Sub InitControls()
            Try
                Call initTreeViewInputAcquisition()
                Call initTempUploadDirectory()
            Catch ex As Exception
            End Try
        End Sub

        Protected Sub raiseDisplayUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseDisplayUpload.Click
            Try
                Call DisplayUploadFields()
            Catch ex As Exception : End Try
        End Sub

        Private Sub initTempUploadDirectory()
            Try
                UploadFiles.TempFileFolder = Server.MapPath("~/Upload")
            Catch ex As Exception
            End Try
        End Sub

        'Init for treeview for InputAcquisition
        Private Sub initTreeViewInputAcquisition()
            TreeViewFolder.Nodes.Clear()
            'objBLibrary.LibID = clsSession.GlbSite
            'Dim libaryInfo = objBLibrary.GetFolderbyLibId()
            Dim folderName = hidPathRoot.Value 'libaryInfo.Rows(0).Item("EdelivFolder")
            Dim path = folderName.ToString()
            If Directory.Exists(path) Then
                _rootFolder = path.Trim
                'rootFolder = path.Trim
                Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
                rootNode.Text = span_treeview_root.InnerText & " (" & _rootFolder & ")"
                rootNode.ImageUrl = "folder-remote.png"
                rootNode.Expanded = True
                rootNode.ID = _rootFolder
                TreeViewFolder.Nodes.Add(rootNode)
                TreeViewFolder.SelectedNode = rootNode
                txtfilePath.Text = rootNode.ID
                BuildTreeDirectory(_rootFolder, rootNode)
            End If
        End Sub

        Private Sub BuildTreeDirectory(ByVal dirPath As String, ByVal parentNode As ComponentArt.Web.UI.TreeViewNode)
            Dim subDirectories() As String = Directory.GetDirectories(dirPath)
            For Each directory As String In subDirectories
                Dim parts() As String = directory.Split("\\")
                Dim name As String = parts(parts.Length - 1)
                Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
                node.Text = name
                node.ID = directory.Replace("\\", _rootFolder)
                parentNode.Nodes.Add(node)
                BuildTreeDirectory(directory, node)
            Next
        End Sub

        Private Sub LoadFileIds()
            Try
                Dim FileIds As String = ""
                If Not Request("intItemID") Is Nothing AndAlso Request("intItemID") <> "0" AndAlso IsNothing(Session("uploadCataloger")) Then
                    Dim dtItemFile As New DataTable
                    With objBEData
                        .ItemID = Request("intItemID")
                        dtItemFile = .GetItemFileByItemID
                    End With
                    If Not IsNothing(dtItemFile) AndAlso dtItemFile.Rows.Count > 0 Then
                        Dim strXMLpath As String = ""
                        For i As Integer = 0 To dtItemFile.Rows.Count - 1
                            ReDim Preserve Session("uploadCataloger")(2, i)
                            Session("uploadCataloger")(0, i) = dtItemFile.Rows(i).Item("Path").ToString.Substring(0, dtItemFile.Rows(i).Item("Path").ToString.LastIndexOf("\"))
                            Session("uploadCataloger")(1, i) = dtItemFile.Rows(i).Item("FileName").ToString
                            strXMLpath = ""
                            If (Not IsDBNull(dtItemFile.Rows(i).Item("XMLpath"))) Then
                                strXMLpath = dtItemFile.Rows(i).Item("XMLpath")
                            End If
                            Session("uploadCataloger")(2, i) = strXMLpath
                            'If IsNothing(Session("uploadFiles")) Then
                            '    ReDim Preserve Session("uploadFiles")(2, 0)
                            '    Session("uploadFiles")(0, 0) = dtItemFile.Rows(i).Item("Path").ToString.Substring(0, dtItemFile.Rows(i).Item("Path").ToString.LastIndexOf("\"))
                            '    Session("uploadFiles")(1, 0) = dtItemFile.Rows(i).Item("FileName").ToString
                            '    strXMLpath = ""
                            '    If (Not IsDBNull(dtItemFile.Rows(i).Item("XMLpath"))) Then
                            '        strXMLpath = dtItemFile.Rows(i).Item("XMLpath")
                            '    End If
                            '    Session("uploadFiles")(2, 0) = strXMLpath
                            'Else
                            '    Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2) + 1
                            '    Session("uploadFiles")(0, _icountArr) = dtItemFile.Rows(i).Item("Path").ToString.Substring(0, dtItemFile.Rows(i).Item("Path").ToString.LastIndexOf("\"))
                            '    Session("uploadFiles")(1, _icountArr) = dtItemFile.Rows(i).Item("FileName").ToString
                            '    strXMLpath = ""
                            '    If (Not IsDBNull(dtItemFile.Rows(i).Item("XMLpath"))) Then
                            '        strXMLpath = dtItemFile.Rows(i).Item("XMLpath")
                            '    End If
                            '    Session("uploadFiles")(2, _icountArr) = strXMLpath
                            'End If
                        Next
                    End If
                    'Session("uploadFiles") = Nothing
                    'FileIds = Request("FileIds")
                    'Dim strArrFileIDs() As String = Split(FileIds, ",")
                    'Dim j As Integer = 0
                    'For i As Integer = 0 To UBound(strArrFileIDs)
                    '    If strArrFileIDs(i) <> "" Then
                    '        ReDim Preserve Session("uploadFiles")(2, j)
                    '        Session("uploadFiles")(0, j) = strArrFileIDs(i).ToString.Substring(0, strArrFileIDs(i).ToString.LastIndexOf("\"))
                    '        Session("uploadFiles")(1, j) = strArrFileIDs(i).ToString.Substring(strArrFileIDs(i).ToString.LastIndexOf("\") + 1, strArrFileIDs(i).Length - strArrFileIDs(i).ToString.LastIndexOf("\") - 1)
                    '        Session("uploadFiles")(2, j) = ""
                    '        j += 1
                    '    End If
                    'Next
                End If
                Call DisplayUploadFields()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub DisplayUploadFields(Optional ByVal strCoverImage As String = "")
            Try
                If Not Session("uploadCataloger") Is Nothing Then
                    Dim _icountArr As Integer = UBound(Session("uploadCataloger"), 2)
                    Dim _strUploadFiles As String = ""
                    _strUploadFiles = "<table id='upload_file_result' cellpadding='1' cellspacing='1' border='0' width='100%'>"
                    Dim _Img As String = ""
                    Dim _strGetIcon As String = ""
                    For _icount As Integer = 0 To _icountArr
                        If _icount = 0 Then
                            _strUploadFiles &= "<tr>"
                            _strUploadFiles &= "<td valign='top' width='17%'>"
                            _strUploadFiles &= span_info_uploadfiles.InnerText & " : "
                            _strUploadFiles &= "</td>"
                        Else
                            _strUploadFiles &= "<tr>"
                            _strUploadFiles &= "<td  width='17%'>"
                            _strUploadFiles &= "&nbsp;"
                            _strUploadFiles &= "</td>"
                        End If
                        _Img = ""
                        If Session("uploadCataloger")(1, _icount).Length > 0 Then
                            _strGetIcon = clsWCommon.GetImage(Session("uploadCataloger")(1, _icount))
                        Else
                            _strGetIcon = ""
                        End If

                        _Img = "<img src='" & "../../Images/ComponentArt/FileType/" & _strGetIcon & "' height='16' width='32' border='0'/>"

                        _strUploadFiles &= "<td valign='top'  width='3%'>"
                        _strUploadFiles &= _Img
                        _strUploadFiles &= "</td>"
                        _strUploadFiles &= "<td valign='top'  width='80%'>"
                        _strUploadFiles &= "<b><i>" & Session("uploadCataloger")(1, _icount) & "</i></b>" & " (" & Session("uploadCataloger")(0, _icount) & ")"
                        If Session("uploadCataloger")(2, _icount).ToString = "" Then
                            _strUploadFiles &= " (<a href=""javascript:void(0);"" onclick=""removeFileUpload(" & _icount & ");return false;"">" & span_upload_removefiles.InnerText & "</a>)"
                        End If
                        _strUploadFiles &= "</td>"
                        _strUploadFiles &= "</tr>"
                        If strCoverImage <> "" Then
                            _strUploadFiles &= "<tr>"
                            _strUploadFiles &= "<td valign='top' width='17%'>"
                            _strUploadFiles &= "&nbsp;"
                            _strUploadFiles &= "</td>"

                            _strUploadFiles &= "<td valign='top' width='83%' colspan='2'>"
                            _strUploadFiles &= strCoverImage
                            _strUploadFiles &= "</td>"

                            _strUploadFiles &= "</tr>"
                        End If
                    Next
                    _strUploadFiles &= "</table>"
                    litinfoUpload.Text = _strUploadFiles
                Else
                    litinfoUpload.Text = ""
                End If
            Catch ex As Exception : End Try
        End Sub

        Protected Sub raiseRemoveFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseRemoveFile.Click
            Try

                Dim _id As Integer = hidRemovefileID.Value
                If _id > -1 Then
                    Call RemoveSession(_id)
                End If
                Call DisplayUploadFields()

                Dim strJS As String = ""
                Dim strFieldValue As String = "" 'idSFile.Value
                Dim strValue As String = ""
                If Not Session("uploadCataloger") Is Nothing Then
                    Dim _icountArr As Integer = UBound(Session("uploadCataloger"), 2)
                    For _icount As Integer = _icountArr To 0 Step -1
                        If System.IO.File.Exists(System.IO.Path.Combine(Session("uploadCataloger")(0, _icount), Session("uploadCataloger")(1, _icount))) Then
                            Dim _fileInfo As New System.IO.FileInfo(System.IO.Path.Combine(Session("uploadCataloger")(0, _icount), Session("uploadCataloger")(1, _icount)))
                            'If InStr(strFieldValue, "$f" & _fileInfo.Name) = 0 Then
                            '    strFieldValue &= "$f" & _fileInfo.Name
                            'End If
                            If _icount = _icountArr Then
                                strValue = _fileInfo.FullName.Replace(hidPathRoot.Value & "\", "").Replace("\", "/")
                            End If
                            strFieldValue &= "::" & _fileInfo.FullName.Replace(hidPathRoot.Value & "\", "").Replace("\", "/") & "$&"
                        End If
                    Next
                Else
                    strFieldValue = ""
                End If
                'strJS = strJS & "top.main." & hidWField.Value & ".value = '';" & "top.main." & hidWField.Value & ".value = '" & strFieldValue & "';" & Chr(13)
                'strJS = strJS & "myUpdateRecord('" & hidFieldCode.Value & "');" & Chr(13)
                'Page.RegisterClientScriptBlock("LoadBack", "<script language = 'javascript'>" & strJS & ";</script>")

                strJS = strJS & "top.main." & hidWField.Value & ".value = '';" & "top.main." & hidWField.Value & ".value = '" & strValue & "';" & Chr(13)
                strJS = strJS & "top.main.Sentform.document.forms[0].tag" & hidFieldCode.Value & ".value = '';" & "top.main.Sentform.document.forms[0].tag" & hidFieldCode.Value & ".value = '" & strFieldValue & "';" & Chr(13)

                strJS = strJS & "myUpdateRecord('" & hidFieldCode.Value & "');"
                Page.RegisterClientScriptBlock("LoadBack", "<script language = 'javascript'>" & strJS & "</script>")


            Catch ex As Exception : End Try
        End Sub

        Public Sub RemoveSession(ByVal _item As Integer)
            Try
                If Not Session("uploadCataloger") Is Nothing Then
                    Dim _iUbound As Integer = UBound(Session("uploadCataloger"), 2) - 1
                    Dim _fileremovePath As String = IIf(Session("uploadCataloger")(0, _item).ToString.Last = "\", Session("uploadCataloger")(0, _item), Session("uploadCataloger")(0, _item) & "\") & Session("uploadCataloger")(1, _item)
                    For _icount As Integer = _item To _iUbound
                        Session("uploadCataloger")(0, _icount) = Session("uploadCataloger")(0, _icount + 1)
                        Session("uploadCataloger")(1, _icount) = Session("uploadCataloger")(1, _icount + 1)
                        Session("uploadCataloger")(2, _icount) = Session("uploadCataloger")(2, _icount + 1)
                    Next
                    If _iUbound > -1 Then
                        ReDim Preserve Session("uploadCataloger")(2, _iUbound)
                    Else
                        Session("uploadCataloger") = Nothing
                    End If
                    If File.Exists(_fileremovePath) Then
                        File.Delete(_fileremovePath)
                    End If
                End If
            Catch ex As Exception : End Try
        End Sub

        Protected Sub UploadFiles_Uploaded(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.UploadUploadedEventArgs) Handles UploadFiles.Uploaded
            Try
                Dim fileName As String = ""
                For Each oInfo In e.UploadedFiles
                    If oInfo.FileName.ToString.Trim <> "" Then
                        fileName = clsWCommon.ChangeFileName(oInfo.FileName)
                        If Directory.Exists(UploadFiles.CallbackParameter) Then
                            oInfo.SaveAs(Path.Combine(UploadFiles.CallbackParameter, fileName), True)
                            If Session("uploadCataloger") Is Nothing Then
                                ReDim Preserve Session("uploadCataloger")(2, 0)
                                Session("uploadCataloger")(0, 0) = UploadFiles.CallbackParameter
                                Session("uploadCataloger")(1, 0) = fileName
                                Session("uploadCataloger")(2, 0) = ""
                            Else
                                Dim _icountArr As Integer = UBound(Session("uploadCataloger"), 2) + 1
                                ReDim Preserve Session("uploadCataloger")(2, _icountArr)
                                Session("uploadCataloger")(0, _icountArr) = UploadFiles.CallbackParameter
                                Session("uploadCataloger")(1, _icountArr) = fileName
                                Session("uploadCataloger")(2, _icountArr) = ""
                            End If
                        Else
                            Call DisplayInfo(span_info.InnerText, span_addnew_invalid2.InnerText, 5)

                            Exit For
                        End If
                    End If
                Next
                UploadFiles.Dispose()
            Catch ex As Exception : End Try
        End Sub

        'Display information to be updated
        Public Sub DisplayInfo(ByVal title As String, ByVal info As String, ByVal icon As Integer)
            Dim _strInfo As String = ""
            _strInfo = "top.showDialogInfo('',true," & icon & ",'" & title & "','" & info & "');"
            clsWCommon.MyMsgBoxInfor(_strInfo, Me.Page)
        End Sub
        <ComponentArt.Web.UI.ComponentArtCallbackMethod()>
        Public Function LoadFolder(ByVal strListFileItem As String, ByVal strFolderName As String, ByVal strPathRoot As String) As String
            Dim folderName = strFolderName '"E:\eMicLib\EIU" 'libaryInfo.Rows(0).Item("EdelivFolder")
            Dim path = folderName.ToString()
            Dim tblData As New DataTable()

            Dim strResult As String = ""
            'For (var index = 0; index < arrData.length; index++)
            '{
            '    strResult = strResult & "<td><input type='checkbox' id='CheckBoxChecked_" & Index & "' onchange='changeFile('CheckBoxChecked_" & Index & "','" & arrData[index][0] & "')'></td>";
            '    strResult = strResult & "<td>" & arrData[index][0] & "</td>";
            '    strResult = strResult & "</tr>"
            '}


            If Directory.Exists(path) Then
                tblData.Columns.Add("FileName")
                tblData.Columns.Add("IsFileCheck")
                Dim subDirectories() As String = Directory.GetFiles(path)
                If subDirectories.Length > 0 Then
                    Dim index As Integer = 1
                    strResult = strResult & "<table width='100%' border='1' cellspacing='0' cellpadding='1'>"
                    strResult = strResult & "<tr>"
                    strResult = strResult & "<td width='30px' height='30px'>&nbsp;</td>"
                    strResult = strResult & "<td>FileName</td>"
                    strResult = strResult & "</tr>"
                    For Each itemFile As String In subDirectories
                        Dim info As New FileInfo(itemFile)
                        Dim row As DataRow = tblData.NewRow()
                        strResult = strResult & "<tr>"
                        row("FileName") = info.Name
                        If strListFileItem.Contains("::" & info.FullName.Replace(strPathRoot & "\", "").Replace("\", "/") & "::") Then
                            row("IsFileCheck") = True
                            strResult = strResult & "<td><div class='checkbox-control'><input type='checkbox' checked='checked' id='CheckBoxChecked_" & index & "' onchange=""changeFile('CheckBoxChecked_" & index & "','" & info.FullName.Replace(strPathRoot & "\", "").Replace("\", "/") & "')""></div></td>"
                        Else
                            row("IsFileCheck") = False
                            strResult = strResult & "<td><div class='checkbox-control'><input type='checkbox' id='CheckBoxChecked_" & index & "' onchange=""changeFile('CheckBoxChecked_" & index & "','" & info.FullName.Replace(strPathRoot & "\", "").Replace("\", "/") & "')""></div></td>"
                        End If
                        strResult = strResult & "<td>" & info.FullName.Replace(strPathRoot & "\", "").Replace("\", "/") & "</td>"
                        tblData.Rows.Add(row)
                        strResult = strResult & "</tr>"
                        index = index + 1
                    Next
                    strResult = strResult & "</table>"
                End If

                'GridViewFile.DataSource = tblData
                'GridViewFile.DataBind()
                'txtFolderAdd.Text = strListFileItem & " " & strFolderName
            Else

                'GridViewFile.DataSource = Nothing
                'GridViewFile.DataBind()

            End If
            Return strResult
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()>
        Public Function CreateFolder(ByVal _strPath As String, ByVal _name As String) As ComponentArt.Web.UI.TreeViewNode
            Try
                If Not Directory.Exists(_strPath) Then
                    Directory.CreateDirectory(_strPath)
                    Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
                    rootNode.Text = _name
                    rootNode.ImageUrl = "folder-remote.png"
                    rootNode.Expanded = True
                    rootNode.ID = _strPath.Replace("\\", _rootFolder)
                    Return rootNode
                Else
                    Return Nothing
                End If
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()>
        Public Function DeleteFolder(ByVal _strPath As String, Optional ByVal _name As String = "") As Integer
            Try
                If Directory.Exists(_strPath) Then
                    If Directory.GetFiles(_strPath).Count = 0 AndAlso Directory.GetDirectories(_strPath).Count = 0 Then
                        Dim subDirectories As DirectoryInfo = Directory.GetParent(_strPath)
                        For Each subdic In subDirectories.GetDirectories
                            If subdic.Name.ToLower = _name.ToLower Then
                                'Duplicated folder name
                                Return 2
                            End If
                        Next
                        Directory.Delete(_strPath)
                        Return 0
                    Else
                        Return 1
                    End If
                Else
                    Return 4
                End If
            Catch ex As Exception
                Return 3
            End Try
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not objBEData Is Nothing Then
                        objBEData.Dispose(True)
                        objBEData = Nothing
                    End If
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub

        'Protected Sub GridViewFile_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridViewFile.RowDataBound
        '    If (e.Row.RowType = DataControlRowType.DataRow) Then
        '        Dim CheckBoxChecked As CheckBox = CType(e.Row.Cells(0).FindControl("CheckBoxChecked"), CheckBox)
        '        CheckBoxChecked.Attributes.Add("onchange", "changeFile('" & CheckBoxChecked.ClientID & "','" & e.Row.Cells(1).Text & "')")
        '    End If
        'End Sub
        Protected Sub raiseLoadFolder_Click(sender As Object, e As EventArgs) Handles raiseLoadFolder.Click
            BindDataFile(Request.QueryString("sfile") & "")
        End Sub

        Protected Sub raiseAddFolder_Click(sender As Object, e As EventArgs) Handles raiseAddFolder.Click
            CreateFolder(txtfilePath.Text & "\" & txtFolderAdd.Text, txtFolderAdd.Text)
            initTreeViewInputAcquisition()
        End Sub
    End Class
End Namespace

