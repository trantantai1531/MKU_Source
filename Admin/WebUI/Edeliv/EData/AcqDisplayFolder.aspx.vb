Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports eMicLibAdmin.BusinessRules.Acquisition
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Page_AcqDisplayFolder
        Inherits clsWBase

        Private objBEData As New clsBEData
        Private objBLibrary As New clsBLibrary
        Protected _rootFolder As String = ""
        Private _FileFolder As DataTable = Nothing

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Call Initialize()
            Dim _arrFolder() As String = Me.getUploadRoot().Split(";")
            If Not Page.IsPostBack AndAlso Not GridCallBack.IsCallback Then
                Call initTreeViewFolder(Me.getUploadRoot())
                Call initFileFolder()
                Call initGrid()
                Call getVariant()
            End If
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            Response.Expires = 0
            ' Init objBCSP object
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

        ' Process method
        ' Purpose: execute all process now
        Private Sub getVariant()
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
        End Sub

        Private Sub initFileFolder()
            If Not Me._FileFolder Is Nothing Then
                Me._FileFolder = Nothing
            End If
        End Sub

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
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

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Sub SetFileNameSession(ByVal _path As String)
            Try
                Session("FileName") = _path
            Catch ex As Exception
            End Try
        End Sub

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function CheckIsFolderOrFile(ByVal _strPath As String) As Integer
            Try
                If Directory.Exists(_strPath) Then
                    Return 1
                ElseIf File.Exists(_strPath) Then
                    Return 2
                Else
                    Return 0
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function DeleteFolder(ByVal _strPath As String, Optional ByVal _name As String = "") As Integer
            Try
                If Directory.Exists(_strPath) Then
                    If Directory.GetFiles(_strPath).Count = 0 AndAlso Directory.GetDirectories(_strPath).Count = 0 Then
                        Dim subDirectories As DirectoryInfo = Directory.GetParent(_strPath)
                        For Each subdic In subDirectories.GetDirectories
                            'If subdic.Name.ToLower = _name.ToLower Then
                            If subdic.Name = _name Then
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

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function deletefile(ByVal _fileremovePath As String) As Integer
            Dim intResult As Integer = 0
            Try
                Dim bolDeleteRights As Boolean = False
                If getVisibleToolbarItem("Delete", clsWCommon.MAIN_TOOLBAR.catFileManagement) Then
                    bolDeleteRights = 1
                End If
                If Not bolDeleteRights Then
                    intResult = 4
                Else
                    If Directory.Exists(_fileremovePath) Then
                        Try
                            Directory.Delete(_fileremovePath)
                        Catch ex As Exception
                            intResult = 3
                        End Try
                    ElseIf File.Exists(_fileremovePath) Then
                        Try
                            File.Delete(_fileremovePath)
                            'Dim clsLog As New BusinessLayer.Log
                            'clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsCommon.gModule.mPhanHeBienMuc, 1, clsCommon.gModule.mXemDuLieuDienTu, clsCommon.getTextLog(Common.FDataType.ACTION_ID._Delete, Session("Language")) & ": file tài liệu - " & _fileremovePath, "127.0.0.1")
                            Dim strLog As String = clsWCommon.getTextLog(clsWCommon.ACTION_ID.eDelete, clsSession.GlbLanguage) & ": file tài liệu - " & _fileremovePath.ToString
                            Call WriteLog(78, strLog, Me.SCRIPT_NAME, Me.REMOTE_ADDR, clsSession.GlbUserFullName)
                        Catch ex As Exception
                            intResult = 2
                        End Try
                    Else
                        intResult = 1
                    End If
                End If

            Catch ex As Exception
            End Try
            Return intResult
        End Function

        Private Function getVisibleToolbarItem(ByVal strValue As String, ByVal idControl As Integer) As Boolean
            Dim bolResults As Boolean = False
            Try
                'Dim ilUserRights As IList = Session("UserRight")
                'If Not IsNothing(ilUserRights) AndAlso ilUserRights.Count > 0 Then
                '    For Each ilData In ilUserRights
                '        If ilData.ModuleID = idControl Then
                '            bolResults = getFunction(strValue, ilData.RightsList.ToString)
                '            Exit For
                '        End If
                '    Next
                'End If
                bolResults = True
            Catch ex As Exception
            End Try
            Return bolResults
        End Function

        Private Function getFunction(ByVal strValue As String, ByVal strRightsList As String) As Boolean
            Dim bolResults As Boolean = False
            Try
                Select Case strValue
                    Case "New"
                        If strRightsList.Substring(1, 1) = "1" Then
                            bolResults = True
                        End If
                    Case "Edit"
                        If strRightsList.Substring(2, 1) = "1" Then
                            bolResults = True
                        End If
                    Case "Delete"
                        If strRightsList.Substring(3, 1) = "1" Then
                            bolResults = True
                        End If
                End Select
            Catch ex As Exception
            End Try
            Return bolResults
        End Function

        Private Sub initTreeViewFolder(ByVal rootFolder As String)
            TreeViewFolder.Nodes.Clear()
            Dim _arrFolder() As String = rootFolder.Split(";")
            objBLibrary.LibID = clsSession.GlbSite
            Dim libaryInfo = objBLibrary.GetFolderbyLibId()
            Dim folderName = libaryInfo.Rows(0).Item("EdelivFolder")
            For i As Integer = 0 To UBound(_arrFolder)
                Dim path = _arrFolder(i) & "\" & folderName.ToString()
                If Directory.Exists(path) Then
                    _rootFolder = path
                    rootFolder = path
                    Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
                    rootNode.Text = _rootFolder
                    rootNode.ImageUrl = "folder-remote.png"
                    rootNode.Expanded = True
                    rootNode.ID = rootFolder.Replace("\\", _rootFolder)
                    TreeViewFolder.Nodes.Add(rootNode)
                    BuildTreeDirectory(rootFolder, rootNode)
                End If
            Next
            'Dim dt = objBLibrary.GetListFolder()
            'For Each dr In dt.Rows
            '    Dim fName = dr("EdelivFolder").ToString()
            '    Dim pth = rootFolder.Replace(";", "") & "\" & fName.Replace(" ", "")
            '    If Not Directory.Exists(pth) Then
            '        Try
            '            Directory.CreateDirectory(pth)
            '        Catch ex As Exception
            '            Console.Write(pth)
            '        End Try
            '    End If
            'Next
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


        Private Sub initGrid()
            objBLibrary.LibID = clsSession.GlbSite
            Dim libaryInfo = objBLibrary.GetFolderbyLibId()
            Dim folderName = libaryInfo.Rows(0).Item("EdelivFolder")
            Dim _strPath As String = ""
            If Not Session("folderPath") Is Nothing AndAlso Not Session("folderPath") = "" Then
                _strPath = Session("folderPath")
            Else
                Dim _arrFolder() As String = Me.getUploadRoot().Split(";")
                _strPath = _arrFolder(0) & "\" & folderName
            End If
            If Directory.Exists(_strPath) Then
                Dim ds As DataSet = GetDirectoryDataSet(_strPath, "128")
                ds.Tables(0).DefaultView.Sort = "DateModified DESC"
                GridFolder.DataSource = ds
                GridFolder.DataBind()

            End If
        End Sub

        ' Returns a DataSet containing the list of files and folders for the given directory 
        Private Function GetDirectoryDataSet(ByVal dirPath As String, Optional ByVal _size As String = "32", Optional ByVal _search As String = "") As DataSet
            Dim ds As New DataSet()
            Dim dt As New DataTable()
            dt.Columns.Add(New DataColumn("Name", GetType(String)))
            dt.Columns.Add(New DataColumn("Icon", GetType(String)))
            dt.Columns.Add(New DataColumn("Size", GetType(Integer)))
            dt.Columns.Add(New DataColumn("Type", GetType(String)))
            dt.Columns.Add(New DataColumn("DateModified", GetType(Date)))
            dt.Columns.Add(New DataColumn("IsFolder", GetType(Boolean)))
            dt.Columns.Add(New DataColumn("Value", GetType(String)))
            dt.Columns.Add(New DataColumn("Extension", GetType(String)))
            dt.Columns.Add(New DataColumn("SizeString", GetType(String)))
            dt.Columns.Add(New DataColumn("FullPath", GetType(String)))
            dt.Columns.Add(New DataColumn("id", GetType(Integer)))
            dt.Columns.Add(New DataColumn("SercretLevel", GetType(Integer)))
            dt.Columns.Add(New DataColumn("DownloadTimes", GetType(Integer)))
            dt.Columns.Add(New DataColumn("DocID", GetType(Integer)))
            dt.Columns.Add(New DataColumn("status", GetType(String)))
            dt.Columns.Add(New DataColumn("Charge", GetType(Integer)))
            dt.Columns.Add(New DataColumn("statusid", GetType(Integer)))
            dt.Columns.Add(New DataColumn("IsExit800", GetType(Boolean)))
            ds.Tables.Add(dt)

            Dim _intId As Integer = 0
            Dim subDirectories As String() = Directory.GetDirectories(dirPath)
            Dim _bolAddRow As Boolean = True
            For Each directory__1 As String In subDirectories
                _bolAddRow = True
                Dim parts As String() = directory__1.Split("\"c)
                Dim name As String = parts(parts.Length - 1)
                If _search <> "" Then
                    If Not name.ToLower.StartsWith(_search.ToLower) Then
                        _bolAddRow = False
                    End If
                End If
                Dim dateTimCreateFolder As DateTime = Directory.GetCreationTime(directory__1)

                If _bolAddRow Then
                    Dim rowValues As Object() = New Object(16) {}
                    rowValues(0) = name
                    rowValues(1) = "folder.png"
                    rowValues(2) = 0
                    rowValues(3) = "File Folder"
                    rowValues(4) = dateTimCreateFolder
                    rowValues(5) = True
                    rowValues(6) = directory__1 '.Replace("\", _rootsavefile)
                    rowValues(7) = ""
                    rowValues(8) = ""
                    rowValues(9) = directory__1
                    rowValues(10) = _intId
                    _intId += 1
                    rowValues(11) = -1
                    rowValues(12) = -1
                    rowValues(13) = -1
                    rowValues(14) = ""
                    rowValues(15) = False
                    rowValues(16) = -1
                    dt.Rows.Add(rowValues)
                End If
            Next
            Dim files As String() = Directory.GetFiles(dirPath)
            Dim _arrayFiles() As String
            For Each file As String In files
                _bolAddRow = True
                Dim parts As String() = file.Split("\"c)
                Dim name As String = parts(parts.Length - 1)
                If _search <> "" Then
                    If Not name.ToLower.StartsWith(_search.ToLower) Then
                        _bolAddRow = False
                    End If
                End If
                If _bolAddRow Then
                    Dim icon As String = "file.gif"
                    Dim type As String = ""
                    Dim fi As New FileInfo(file)
                    Dim attribs As clsWCommon.ItemAttributes = clsWCommon.getItemAttributes(fi.Extension, _size)
                    Dim rowValues As Object() = New Object(16) {}
                    rowValues(0) = name
                    rowValues(1) = attribs.Icon
                    rowValues(2) = fi.Length
                    rowValues(3) = attribs.Type
                    rowValues(4) = fi.LastWriteTime
                    rowValues(5) = False
                    rowValues(6) = ""
                    rowValues(7) = fi.Extension
                    rowValues(8) = clsWCommon.GetSizeString(fi.Length)
                    rowValues(9) = fi.FullName
                    rowValues(10) = _intId
                    _intId += 1
                    _arrayFiles = FindKeyFiles(fi.FullName)
                    rowValues(11) = _arrayFiles(0)
                    rowValues(12) = _arrayFiles(1)
                    rowValues(13) = _arrayFiles(2)
                    rowValues(14) = _arrayFiles(3)
                    rowValues(15) = _arrayFiles(4)
                    rowValues(16) = _arrayFiles(5)
                    dt.Rows.Add(rowValues)
                End If
            Next
            For Each item As DataRow In dt.Rows
                Dim result = objBEData.CheckExitFileIn800s(item.Item("Name"))
                If Not result Is Nothing AndAlso result.Rows.Count > 0 Then
                    item.Item("IsExit800") = True
                Else
                    item.Item("IsExit800") = False
                End If
            Next
            Return ds
        End Function

        Private Function FindKeyFiles(ByVal colvalue As String) As String()
            Dim Result(5) As String
            Try
                If _FileFolder Is Nothing Then
                    'Dim _FileArray As New BusinessLayer.Acquisition
                    'Dim _Array As IList = _FileArray.Select_cat_files_array(_LanguageCode)
                    '_FileFolder = _Array
                    '_FileArray = Nothing
                    Dim tblData As DataTable
                    With objBEData
                        .FileLocation = colvalue
                        tblData = .getFilesFolder
                    End With
                    _FileFolder = tblData
                End If

                Result(0) = 0
                Result(1) = 0
                Result(2) = -1
                Result(3) = 0
                Result(4) = 0
                Result(5) = 0
                If Not IsNothing(_FileFolder) AndAlso _FileFolder.Rows.Count - 1 Then
                    For i As Integer = 0 To _FileFolder.Rows.Count - 1
                        Result(0) = _FileFolder.Rows(i).Item("SercretLevel")
                        Result(1) = _FileFolder.Rows(i).Item("DownloadTimes")
                        Result(2) = _FileFolder.Rows(i).Item("DocID")
                        Result(3) = _FileFolder.Rows(i).Item("status")
                        Result(4) = _FileFolder.Rows(i).Item("Charge")
                        Result(5) = _FileFolder.Rows(i).Item("statusid")
                    Next
                End If

                'For Each _pro In _FileFolder
                '    If colvalue.ToLower.Trim = _pro.Path.ToLower.Trim Then
                '        Result(0) = _pro.SercretLevel
                '        Result(1) = _pro.DownloadTimes
                '        Result(2) = _pro.DocID
                '        Result(3) = _pro.status
                '        Result(4) = _pro.Charge
                '        Result(5) = _pro.statusid
                '        Exit For
                '    End If
                'Next
            Catch ex As Exception
            End Try
            Return Result
        End Function





        ' This callback is triggered a TreeView node is selected 
        Private Sub GridCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            ' Don't allow browsing the file system outside of the app root 
            Try
                If e.Parameter <> "" Then
                    GridFolder.DataSource = Nothing
                    GridFolder.DataBind()
                    GridFolder.Dispose()
                    Session("folderPath") = e.Parameter
                    Dim ds As DataSet = GetDirectoryDataSet(e.Parameter, "128")
                    ds.Tables(0).DefaultView.Sort = "DateModified DESC"
                    GridFolder.DataSource = ds
                    GridFolder.DataBind()
                    GridFolder.RenderControl(e.Output)
                End If
            Catch ex As Exception : End Try

        End Sub

        ' Triggered when context menu is activated 
        Private Sub MenuCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            System.Threading.Thread.Sleep(10)
            MenuFolder.Dispose()
            Call addMenuItems()
            MenuFolder.RenderControl(e.Output)
        End Sub

        ' Adds the top menu item. This technique can be used to generate the entire menu programmatically. 
        Private Sub addMenuItems()
            MenuFolder.Items.Clear()
            Dim newItem As ComponentArt.Web.UI.MenuItem
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_treeview_upload.InnerText
                .Value = "upload"
                .Look.LeftIconUrl = "upload.png"
                .Look.HoverLeftIconUrl = "upload.png"
            End With
            MenuFolder.Items.Insert(0, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .CssClass = "MenuBreak"
                .Look.ImageUrl = "break.gif"
                .Look.ImageWidth = Unit.Percentage(100)
                .Look.ImageHeight = "2"
            End With
            MenuFolder.Items.Insert(1, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_treeview_new_folder.InnerText
                .Value = "add"
                .Look.LeftIconUrl = "folder_add.png"
                .Look.HoverLeftIconUrl = "folder_add.png"
            End With
            MenuFolder.Items.Insert(2, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_treeview_edit_folder.InnerText
                .Value = "edit"
                .Look.LeftIconUrl = "folder-remote.png"
                .Look.HoverLeftIconUrl = "folder-remote.png"
            End With
            MenuFolder.Items.Insert(3, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_treeview_delete_folder.InnerText
                .Value = "delete"
                .Look.LeftIconUrl = "folder_remove.png"
                .Look.HoverLeftIconUrl = "folder_remove.png"
            End With
            MenuFolder.Items.Insert(4, newItem)
        End Sub

        ' Triggered when context menu is activated 
        Private Sub MenuCallBackGrid_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            System.Threading.Thread.Sleep(10)
            MenuGrid.Dispose()
            Call addMenuItemsGrid()
            MenuGrid.RenderControl(e.Output)
        End Sub

        ' Adds the top menu item. This technique can be used to generate the entire menu programmatically. 
        Private Sub addMenuItemsGrid()
            MenuGrid.Items.Clear()
            Dim newItem As ComponentArt.Web.UI.MenuItem
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_grid_open.InnerText
                .Value = "open"
                .Look.LeftIconUrl = "fileopen.png"
                .Look.HoverLeftIconUrl = "fileopen.png"
            End With
            MenuGrid.Items.Insert(0, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .CssClass = "MenuBreak"
                .Look.ImageUrl = "break.gif"
                .Look.ImageWidth = Unit.Percentage(100)
                .Look.ImageHeight = "2"
            End With
            MenuGrid.Items.Insert(1, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_grid_delete_file_info.InnerText
                .Value = "delete"
                .Look.LeftIconUrl = "RecycleBin.png"
                .Look.HoverLeftIconUrl = "RecycleBin.png"
            End With
            MenuGrid.Items.Insert(2, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .CssClass = "MenuBreak"
                .Look.ImageUrl = "break.gif"
                .Look.ImageWidth = Unit.Percentage(100)
                .Look.ImageHeight = "2"
            End With
            MenuGrid.Items.Insert(3, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_grid_checkall.InnerText
                .Value = "checkall"
                .Look.LeftIconUrl = "CheckAll.png"
                .Look.HoverLeftIconUrl = "CheckAll.png"
            End With
            MenuGrid.Items.Insert(4, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_grid_uncheckall.InnerText
                .Value = "uncheckall"
                .Look.LeftIconUrl = "unCheckAll.png"
                .Look.HoverLeftIconUrl = "unCheckAll.png"
            End With
            MenuGrid.Items.Insert(5, newItem)
        End Sub


        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function saveFileIds(ByVal strFileIds As String) As Integer
            Dim intResult As Integer = 0
            Try
                Session("uploadFiles") = Nothing
                Session("ResetUploadFiles") = Nothing
                Dim strArrFileIDs() As String = Split(strFileIds, ",")
                Dim j As Integer = 0
                For i As Integer = 0 To UBound(strArrFileIDs)
                    If strArrFileIDs(i) <> "" Then
                        ReDim Preserve Session("uploadFiles")(2, j)
                        Session("uploadFiles")(0, j) = strArrFileIDs(i).ToString.Substring(0, strArrFileIDs(i).ToString.LastIndexOf("\"))
                        Session("uploadFiles")(1, j) = strArrFileIDs(i).ToString.Substring(strArrFileIDs(i).ToString.LastIndexOf("\") + 1, strArrFileIDs(i).Length - strArrFileIDs(i).ToString.LastIndexOf("\") - 1)
                        Session("uploadFiles")(2, j) = ""
                        j += 1
                    End If
                Next
                intResult = 1
            Catch ex As Exception
            End Try
            Return intResult
        End Function


        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function addSaveFileIds(ByVal strFileIds As String, ByVal hidSFile As String, ByVal fielCode As String) As String
            Dim strResult As String = ""
            Try
                Dim intFileType As Integer = 0
                Dim strArrFileIDs() As String = Split(strFileIds, ",")
                If fielCode = "907" Then
                    intFileType = clsWCommon.GetFileMediaType(strArrFileIDs(0).Trim)
                    If intFileType = clsWCommon.gfileType.ePicture Then
                        Dim fileName As String = Path.GetFileName(strArrFileIDs(0).Trim)
                        fileName = clsWCommon.ChangeFileName(fileName)

                        Dim strDictionary As String = Now.Year.ToString & "\" & Now.Month.ToString & "\" & Now.Day.ToString  'Format(Now, "yyyyMMdd")
                        Dim strPath As String = Server.MapPath("~/Upload/ImageCover/") & strDictionary
                        If Not Directory.Exists(strPath) Then
                            Directory.CreateDirectory(strPath)
                        End If
                        If strPath.EndsWith("\") = False Then
                            strPath &= "\"
                        End If
                        strPath &= fileName

                        File.Copy(strArrFileIDs(0).Trim, strPath)

                        Session("imageCover") = strPath
                        strResult = Path.GetFileName(Session("imageCover"))
                    End If
                ElseIf fielCode = "856$f" Then '2016.05.05 BE1
                    Dim j As Integer = 0
                    If Not IsNothing(Session("uploadFiles")) Then
                        j = UBound(Session("uploadFiles"), 2) + 1
                    End If
                    Dim strDictionary As String = ""
                    Dim strFile As String = ""
                    For i As Integer = 0 To UBound(strArrFileIDs)
                        If strArrFileIDs(i) <> "" Then
                            strDictionary = strArrFileIDs(i).ToString.Substring(0, strArrFileIDs(i).ToString.LastIndexOf("\"))
                            strFile = strArrFileIDs(i).ToString.Substring(strArrFileIDs(i).ToString.LastIndexOf("\") + 1, strArrFileIDs(i).Length - strArrFileIDs(i).ToString.LastIndexOf("\") - 1)
                            If checkDuplicateFiles(strDictionary, strFile) Then
                                ReDim Preserve Session("uploadFiles")(2, j)
                                Session("uploadFiles")(0, j) = strDictionary
                                Session("uploadFiles")(1, j) = strFile
                                Session("uploadFiles")(2, j) = ""
                                j += 1
                            End If
                        End If
                    Next
                    strResult = setField856(hidSFile)
                End If
            Catch ex As Exception
            End Try
            Return strResult
        End Function

        Public Function setField856(ByVal hidSFile As String) As String
            Dim str As String = ""
            Try
                Dim strFieldValue As String = hidSFile & "$&" & Space(1)
                If Not Session("uploadFiles") Is Nothing Then
                    Dim _icountArr As Integer = UBound(Session("uploadFiles"), 2)
                    For _icount As Integer = _icountArr To 0 Step -1
                        If System.IO.File.Exists(System.IO.Path.Combine(Session("uploadFiles")(0, _icount), Session("uploadFiles")(1, _icount))) Then
                            Dim _fileInfo As New System.IO.FileInfo(System.IO.Path.Combine(Session("uploadFiles")(0, _icount), Session("uploadFiles")(1, _icount)))
                            'If InStr(strFieldValue, "$f" & _fileInfo.Name) = 0 Then
                            '    strFieldValue &= "$f" & _fileInfo.Name
                            'End If
                            strFieldValue &= _fileInfo.Name & "$&"
                        End If
                    Next
                End If
                str = strFieldValue.Trim
            Catch ex As Exception
            End Try
            Return str
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Function checkDuplicateFiles(ByVal strDictionary As String, ByVal strFile As String) As Boolean
            Dim bolResult As Boolean = True
            Try
                If Not IsNothing(Session("uploadFiles")) Then
                    Dim intUbound As Integer = UBound(Session("uploadFiles"))
                    For ij As Integer = 0 To intUbound
                        If Session("uploadFiles")(0, ij) = strDictionary AndAlso Session("uploadFiles")(1, ij) = strFile Then
                            bolResult = False
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
            Return bolResult
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not IsNothing(objBEData) Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub

#Region "Web Form Designer generated code"
        Protected Overloads Overrides Sub OnInit(ByVal e As EventArgs)
            ' 
            ' CODEGEN: This call is required by the ASP.NET Web Form Designer. 
            ' 
            InitializeComponent()
            MyBase.OnInit(e)
        End Sub

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor. 
        ''' </summary> 
        Private Sub InitializeComponent()
            AddHandler Me.GridCallBack.Callback, AddressOf Me.GridCallBack_Callback
            AddHandler Me.MenuCallBack.Callback, AddressOf Me.MenuCallBack_Callback
            AddHandler Me.MenuCallBackGrid.Callback, AddressOf Me.MenuCallBackGrid_Callback
            AddHandler Me.Load, AddressOf Me.Page_Load
        End Sub
#End Region

    End Class
End Namespace




