Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.IO.Path
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqTableOfContents
        Inherits clsWBase

        Protected langcodePath As String = ""
        Private objBEData As New clsBEData
        Private objBCSP As New clsBCommonStringProc

        Public Class ItemAttributes
            Private _icon As String
            Public Property Icon() As String
                Get
                    Return _icon
                End Get
                Set(ByVal value As String)
                    _icon = value
                End Set
            End Property

            Private _type As String
            Public Property Type() As String
                Get
                    Return _type
                End Get
                Set(ByVal value As String)
                    _type = value
                End Set
            End Property
        End Class

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Call Initialize()
            If Not Page.IsPostBack AndAlso Not GridCallBack.IsCallback AndAlso Not CallbackTreeview.IsCallback Then
                Call initGrid()
                Call initTreeViewCollection(0)
                Call setRightsToolbar()
                Call getLangcode()
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
            'objBEData.FileID = lngObjID
            ' Init BCommonStringProc object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub

        Private Sub setRightsToolbar()
            ToolBarItem1.Visible = getVisibleToolbarItem("New", clsWCommon.MAIN_TOOLBAR.catTableOfContent)
            ToolBarItem2.Visible = getVisibleToolbarItem("Edit", clsWCommon.MAIN_TOOLBAR.catTableOfContent)
            ToolBarItem3.Visible = getVisibleToolbarItem("Delete", clsWCommon.MAIN_TOOLBAR.catTableOfContent)
        End Sub

        Private Sub getLangcode()
            Try
                If Not IsNothing(clsSession.GlbLanguage) AndAlso clsSession.GlbLanguage = "vie" Then
                    langcodePath = Request.Url.AbsoluteUri.ToString.Substring(0, InStrRev(Request.Url.AbsoluteUri.ToString, "/")) & "language/lang_vie.txt"
                Else
                    langcodePath = Request.Url.AbsoluteUri.ToString.Substring(0, InStrRev(Request.Url.AbsoluteUri.ToString, "/")) & "language/lang_eng.txt"
                End If
            Catch ex As Exception

            End Try
        End Sub

        Protected Sub ToolBarTableOfContents_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolBarTableOfContents.Load
            Call ChangeLanguage()
        End Sub
        Private Sub ChangeLanguage()
            ToolBarTableOfContents.Items(0).Text = ""
            ToolBarTableOfContents.Items(2).Text = ""
            ToolBarTableOfContents.Items(4).Text = ""
            ToolBarTableOfContents.Items(0).ToolTip = span_treeview_new_Tableofcontent.InnerText
            ToolBarTableOfContents.Items(2).ToolTip = span_treeview_edit_Tableofcontent.InnerText
            ToolBarTableOfContents.Items(4).ToolTip = span_treeview_delete_Tableofcontent.InnerText
        End Sub


        'Init for treeview
        Private Sub initTreeViewCollection(ByVal _DocId As Integer)
            TreeViewCollection_Table_Of_Contents.Nodes.Clear()
            Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
            rootNode.Text = span_treeview_root_Tableofcontent.InnerText
            rootNode.ImageUrl = "TableOfContents.png"
            rootNode.Expanded = True
            rootNode.ID = "0"
            rootNode.Value = "0"
            rootNode.Attributes.Add("fileId", "0")
            TreeViewCollection_Table_Of_Contents.Nodes.Add(rootNode)
            Dim tblData As DataTable
            objBEData.ItemID = _DocId
            tblData = objBEData.getFilesByItemId
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBEData.ErrorMsg, ddlLabel.Items(1).Text, objBEData.ErrorCode)

            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                Dim intFileId As Integer = 0
                For i As Integer = 0 To tblData.Rows.Count - 1
                    intFileId = tblData.Rows(i).Item("Id")
                    Call BuildTreeDirectoryCollection(intFileId, 0, rootNode)
                Next
            End If

            'Dim procs As New BusinessLayer.Acquisition
            'Dim getFileIds As IList = procs.Select_get_files_from_Docid(_DocId)
            'If Not getFileIds Is Nothing AndAlso getFileIds.Count > 0 Then
            '    Dim intFileId As Integer = 0
            '    For Each proc In getFileIds
            '        intFileId = proc.Id
            '        'Call BuildTreeTableofcontents(_DocId, intFileId, _fileType, _subjectId, 0, rootNode)
            '        Call BuildTreeDirectoryCollection(intFileId, 0, rootNode)
            '    Next
            'End If

            'Call BuildTreeDirectoryCollection(_FileId, 0, rootNode)
        End Sub

        Private Sub BuildTreeDirectoryCollection(ByVal _FileId As Integer, ByVal _level As Integer, ByVal _parentNode As ComponentArt.Web.UI.TreeViewNode)
            Dim tblData As DataTable
            With objBEData
                .FileID = _FileId
                .ParentID = _level
                tblData = objBEData.getTableOfConents
            End With
            Call WriteErrorMssg(ddlLabel.Items(0).Text, objBEData.ErrorMsg, ddlLabel.Items(1).Text, objBEData.ErrorCode)
            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                For i As Integer = 0 To tblData.Rows.Count - 1
                    Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
                    node.Text = ""
                    If Not IsDBNull(tblData.Rows(i).Item("Name")) Then
                        node.Text = tblData.Rows(i).Item("Name")
                    End If
                    node.ID = tblData.Rows(i).Item("ID")
                    node.Value = ""
                    If Not IsDBNull(tblData.Rows(i).Item("Name")) Then
                        node.Value = tblData.Rows(i).Item("NumOfPage")
                    End If
                    node.Attributes.Add("fileId", tblData.Rows(i).Item("FileId"))
                    _parentNode.Nodes.Add(node)
                    Call BuildTreeDirectoryCollection(_FileId, CInt(tblData.Rows(i).Item("ID")), node)
                Next
            End If
            'Dim procs As New BusinessLayer.Acquisition
            'Dim _Tableofcontent As IList = procs.Select_table_of_contents(_FileId, _level)
            'If Not _Tableofcontent Is Nothing AndAlso _Tableofcontent.Count > 0 Then
            '    For Each proc In _Tableofcontent
            '        Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
            '        node.Text = proc.Name.ToString
            '        node.ID = proc.ID.ToString
            '        node.Value = proc.NumOfPage.ToString
            '        node.Attributes.Add("fileId", proc.FileId.ToString)
            '        _parentNode.Nodes.Add(node)
            '        Call BuildTreeDirectoryCollection(_FileId, CInt(proc.ID), node)
            '    Next
            'End If
        End Sub

        ' InitializeForCallback method
        ' Purpose: Init all neccessary objects
        Public Sub InitializeForCallback()
            ' Init objBCSP object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()
            'objBEData.FileID = lngObjID
            ' Init BCommonStringProc object
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
        End Sub


        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function CreateTableofcontent(ByVal _FileId As Integer, ByVal _ParentID As Integer, ByVal _Name As String, ByVal _NumOfPage As Integer) As Integer
            Try
                Call InitializeForCallback()
                Dim tblData As DataTable
                With objBEData
                    .FileID = _FileId
                    .ParentID = _ParentID
                    .TocName = _Name
                    tblData = .getTableOfConentsByName
                End With
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                    Return 0
                End If
                Dim _intInsert As Integer = 0
                With objBEData
                    .FileID = _FileId
                    .ParentID = _ParentID
                    .TocName = _Name
                    .TocNumOfPage = _NumOfPage
                    _intInsert = .insertTableOfContent()
                End With
                If _intInsert > 0 Then
                    Dim strLog As String = clsWCommon.getTextLog(clsWCommon.ACTION_ID.eNew, clsSession.GlbLanguage) & ": file tài liệu id - " & _FileId.ToString
                    Call WriteLog(78, strLog, Me.SCRIPT_NAME, Me.REMOTE_ADDR, clsSession.GlbUserFullName)
                End If
                'Dim _ExistCollection As New BusinessLayer.Acquisition
                'Dim _bolExist As Boolean = _ExistCollection.Select_exist_cat_table_of_content(_FileId, _ParentID, _Name)
                '_ExistCollection = Nothing
                'If _bolExist Then
                '    Return 0
                'End If
                'Dim _insertCollection As New BusinessLayer.Acquisition
                'Dim _intInsert As Integer = _insertCollection.Insert_cat_table_of_content(_FileId, _ParentID, _Name, _NumOfPage)
                '_insertCollection = Nothing
                'If _intInsert > 0 Then
                '    Dim clsLog As New BusinessLayer.Log
                '    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._New, clsSession.GlbLanguage) & ": file tài liệu id - " & _FileId.ToString, "127.0.0.1")
                'End If
                Return _intInsert
            Catch ex As Exception
                Return -1
            End Try
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function DeleteTableofcontent(ByVal _id As Integer) As Integer
            Dim intResult As Integer = 0
            Try
                Call InitializeForCallback()
                With objBEData
                    .TocID = _id
                    intResult = .deleteTableOfContent
                End With
                If intResult = 1 Then
                    Dim strLog As String = clsWCommon.getTextLog(clsWCommon.ACTION_ID.eDelete, clsSession.GlbLanguage) & ": file tài liệu id - " & _id.ToString
                    Call WriteLog(78, strLog, Me.SCRIPT_NAME, Me.REMOTE_ADDR, clsSession.GlbUserFullName)
                End If

                'Dim _ExistChild As New BusinessLayer.Acquisition
                'Dim _bolExist As Boolean = _ExistChild.Select_table_of_contents_parentid(_id)
                '_ExistChild = Nothing
                'If _bolExist Then
                '    Return 2
                'End If
                'Dim _deleteCollection As New BusinessLayer.Acquisition
                'Dim _intDelelte As Boolean = _deleteCollection.Delete_cat_table_of_content(_id)
                '_deleteCollection = Nothing
                'If _intDelelte Then
                '    Dim clsLog As New BusinessLayer.Log
                '    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._Delete, clsSession.GlbLanguage) & ": file tài liệu id - " & _id.ToString, "127.0.0.1")
                '    Return 1
                'Else
                '    Return 0
                'End If
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function GetFalshViewer(ByVal _pageno As Integer, ByVal _pathxml As String) As String
            Dim _str As String = ""
            Try
                Dim _lang As String = IIf(clsSession.GlbLanguage = "vie", "vie", "eng")
                _str = "<object id=""idViewer"" codebase=""http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0""" & _
                    " width=""800"" height=""600"" classid=""clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"" ><param name=""movie""" & _
                    " value=""swf/MLbook.swf?langcode=" & _lang & "&pageno=" & _pageno & "&pathxml=" & _pathxml & """ /> <param name=""wmode"" value=""transparent"" />" & _
                    " <param name=""quality"" value=""high"" /> <param name=""bgcolor"" value=""#cccccc"" /> <param name=""allowFullScreen"" value=""true"" />" & _
                    " <param name=""allowScriptAccess"" value=""sameDomain"" />" & _
                    " <embed id=""idViewer"" width=""800"" height=""600"" src=""swf/MLbook.swf?langcode=" & _lang & "&pageno=" & _pageno & "&pathxml=" & _pathxml & """" & _
                    " quality=""high"" wmode=""transparent"" pluginspage=""http://www.macromedia.com/go/getflashplayer"" bgcolor=""#cccccc"" allowFullScreen=""true""" & _
                    " allowScriptAccess=""sameDomain"" type=""application/x-shockwave-flash""  ></embed></object>"
            Catch ex As Exception
            End Try
            Return _str
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function UpdateTableofcontent(ByVal _id As Integer, ByVal _name As String, ByVal _NumOfPage As Integer) As Integer
            Dim _intUpdate As Integer = 0
            Try
                Call InitializeForCallback()
                With objBEData
                    .TocID = _id
                    .TocName = _name
                    .TocNumOfPage = _NumOfPage
                    _intUpdate = .updateTableOfContent
                End With
                If _intUpdate Then
                    Dim strLog As String = clsWCommon.getTextLog(clsWCommon.ACTION_ID.eUpdate, clsSession.GlbLanguage) & ": file tài liệu id - " & _id.ToString
                    Call WriteLog(78, strLog, Me.SCRIPT_NAME, Me.REMOTE_ADDR, clsSession.GlbUserFullName)
                End If
                'Dim _updateCollection As New BusinessLayer.Acquisition
                'Dim _intupdate As Boolean = _updateCollection.Update_cat_table_of_content(_id, _name, _NumOfPage)
                '_updateCollection = Nothing
                'If _intupdate Then
                '    Dim clsLog As New BusinessLayer.Log
                '    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._Update, clsSession.GlbLanguage) & ": file tài liệu id - " & _id.ToString, "127.0.0.1")
                '    Return 1
                'Else
                '    Return 0
                'End If
            Catch ex As Exception
            End Try
            Return _intUpdate
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function IsSwf(ByVal fileName As String) As Integer
            Dim _intReturn As Integer = 0
            Try
                If fileName.ToLower.EndsWith(".swf") Then
                    _intReturn = 1
                End If
            Catch ex As Exception
            End Try
            Return _intReturn
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function MoveTableofcontent(ByVal _id As Integer, ByVal _idParent As Integer) As Integer
            Dim _intReturn As Integer = 0
            Try
                Call InitializeForCallback()
                With objBEData
                    .TocID = _id
                    .ParentID = _idParent
                    _intReturn = .updateTableOfContentByParentID
                End With
                If _intReturn Then
                    Dim strLog As String = clsWCommon.getTextLog(clsWCommon.ACTION_ID.eUpdate, clsSession.GlbLanguage) & ": file tài liệu id - " & _id.ToString
                    Call WriteLog(78, strLog, Me.SCRIPT_NAME, Me.REMOTE_ADDR, clsSession.GlbUserFullName)
                End If
                'Dim _updateCollection As New BusinessLayer.Acquisition
                'Dim _intupdate As Boolean = _updateCollection.Move_update_cat_table_of_content(_id, _idParent)
                '_updateCollection = Nothing
                'If _intupdate Then
                '    _intReturn = 1
                'End If
            Catch ex As Exception
            End Try
            Return _intReturn
        End Function

        Private Sub initGrid()
            'Dim tblData As DataTable
            'Dim strEbooks As String = "," & clsWCommon.gfileType.eEbook & ","
            'tblData = objBEData.getItemFilesTableOfConents(clsWCommon.gViewer.NotTableOfContent, strEbooks)
            'GridTableOfContent.AutoAdjustPageSize = True
            'GridTableOfContent.DataSource = tblData
            'GridTableOfContent.DataBind()
            Dim ds As DataSet = GetFilesScan(clsWCommon.gViewer.NotTableOfContent, "128")
            ds.Tables(0).DefaultView.Sort = "DateModified DESC"
            GridTableOfContent.AutoAdjustPageSize = True
            GridTableOfContent.DataSource = ds
            GridTableOfContent.DataBind()
        End Sub


        'This callback is triggered a TreeView node is selected 
        Private Sub GridCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            ' Don't allow browsing the file system outside of the app root 
            Try
                If Not IsNothing(e.Parameter) AndAlso e.Parameter <> "" Then
                    GridTableOfContent.DataSource = Nothing
                    GridTableOfContent.DataBind()
                    GridTableOfContent.Dispose()
                    'Dim tblData As DataTable
                    'Dim strEbooks As String = "," & clsWCommon.gfileType.eEbook & ","
                    'tblData = objBEData.getItemFilesTableOfConents(e.Parameter, strEbooks)
                    'GridTableOfContent.DataSource = tblData
                    'GridTableOfContent.DataBind()
                    'GridTableOfContent.RenderControl(e.Output)
                    Dim ds As DataSet = GetFilesScan(e.Parameter, "128")
                    ds.Tables(0).DefaultView.Sort = "DateModified DESC"
                    GridTableOfContent.DataSource = ds
                    GridTableOfContent.DataBind()
                    GridTableOfContent.RenderControl(e.Output)
                End If
            Catch ex As Exception : End Try
        End Sub

        ' Returns item attributes based on its extension 
        Public Shared Function getItemAttributes(ByVal Extension As String, Optional ByVal _size As String = "32") As ItemAttributes
            Dim attribs As New ItemAttributes()
            Select Case Extension.ToLower()
                Case ""
                    attribs.Icon = "folder.png"
                    attribs.Type = "File Folder"
                    Exit Select
                Case ".mp3"
                    attribs.Icon = "FileType/Audio/mp3/MP3" & _size & ".png"
                    attribs.Type = "Audio File"
                    Exit Select
                Case ".wav"
                    attribs.Icon = "FileType/Audio/wav/WAV" & _size & ".png"
                    attribs.Type = "Audio File"
                    Exit Select
                Case ".html", ".htm"
                    attribs.Icon = "FileType/document/html/html" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".xls", ".xlsx"
                    attribs.Icon = "FileType/document/excel/Excel" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".ppt", ".pptx"
                    attribs.Icon = "FileType/document/powerpoint/PowerPoint" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".rtf"
                    attribs.Icon = "FileType/document/rtf/rtf" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".txt"
                    attribs.Icon = "FileType/document/text/txt" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".doc", ".docx"
                    attribs.Icon = "FileType/document/word/Word" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".pdf"
                    attribs.Icon = "FileType/document/pdf/pdf" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".xml"
                    attribs.Icon = "FileType/document/xml/xml" & _size & ".png"
                    attribs.Type = "Document File"
                    Exit Select
                Case ".exe"
                    attribs.Icon = "FileType/exec/exec" & _size & ".png"
                    attribs.Type = "Exe File"
                    Exit Select
                Case ".avi"
                    attribs.Icon = "FileType/media/avi/avi" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".flv"
                    attribs.Icon = "FileType/media/flv/flv" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".mov"
                    attribs.Icon = "FileType/media/mov/mov" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".mpeg"
                    attribs.Icon = "FileType/media/mpeg/mpeg" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".mpg"
                    attribs.Icon = "FileType/media/mpg/mpg" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".swf"
                    attribs.Icon = "FileType/media/swf/swf" & _size & ".png"
                    attribs.Type = "Media File"
                    Exit Select
                Case ".bmp"
                    attribs.Icon = "FileType/picture/bmp/bmp" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".gif"
                    attribs.Icon = "FileType/picture/gif/gif" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".jpeg"
                    attribs.Icon = "FileType/picture/jpeg/jpeg" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".jpg"
                    attribs.Icon = "FileType/picture/jpg/jpg" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".png"
                    attribs.Icon = "FileType/picture/png/png" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".tif"
                    attribs.Icon = "FileType/picture/tif/tif" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case ".tiff"
                    attribs.Icon = "FileType/picture/tiff/tiff" & _size & ".png"
                    attribs.Type = "Picture File"
                    Exit Select
                Case Else
                    attribs.Icon = "FileType/other/other" & _size & ".png"
                    attribs.Type = Extension.Replace(".", "").ToUpper() & " File"
                    Exit Select
            End Select
            Try
                attribs.Icon = "FileType/" & GetImage(Extension)
            Catch ex As Exception
            End Try
            Return attribs
        End Function

        Public Shared Function GetImage(ByVal _FilePath As String) As String
            Dim strFileType As String = ""
            Try
                _FilePath = LCase(Right(_FilePath, Len(_FilePath) - InStrRev(_FilePath, ".") + 1))
                If _FilePath.ToLower.EndsWith(".doc") Or _FilePath.ToLower.EndsWith(".docx") Then
                    strFileType = "document/doc.png"
                ElseIf _FilePath.ToLower.EndsWith(".pdf") Then
                    strFileType = "document/pdf.png"
                ElseIf _FilePath.ToLower.EndsWith(".html") Or _FilePath.ToLower.EndsWith(".htm") Then
                    strFileType = "document/html.png"
                ElseIf _FilePath.ToLower.EndsWith(".ppt") Or _FilePath.ToLower.EndsWith(".pptx") Then
                    strFileType = "document/ppt.png"
                ElseIf _FilePath.ToLower.EndsWith(".xls") Or _FilePath.ToLower.EndsWith(".xlsx") Then
                    strFileType = "document/xls.png"
                ElseIf _FilePath.ToLower.EndsWith(".rtf") Then
                    strFileType = "document/rtf.png"
                ElseIf _FilePath.ToLower.EndsWith(".prc") Then
                    strFileType = "document/prc.png"
                ElseIf _FilePath.ToLower.EndsWith(".lit") Then
                    strFileType = "document/lit.png"
                ElseIf _FilePath.ToLower.EndsWith(".txt") Then
                    strFileType = "document/txt.png"
                ElseIf _FilePath.ToLower.EndsWith(".chm") Then
                    strFileType = "document/chm.png"
                Else
                    If _FilePath.Substring(0, 1) = "." Then
                        Select Case _FilePath
                            Case ".mpg", ".avi", ".asf", ".mpeg", ".mov", ".flc", ".mpv", ".swf", ".flv", ".mp4", ".ivf", ".div", ".divx", ".m4v", ".mpe", ".wmv", ".mov", ".qt", ".ts", ".mts", ".m2t", ".m2ts", ".mod", ".tod", ".vro", ".dat", ".3pg2", ".3gpp", ".3gp", ".3g2", ".dvr", ".ms", ".f4v", ".amv", ".rm", ".rmm", ".rv", ".rmvb", ".ogv", ".mkv"
                                strFileType = "Media/Media.png"
                            Case ".mp3", ".wav", ".aac", ".wma", ".m4a", ".m4b", ".ogg", ".flac", ".ra", ".ram", ".amr", ".ape", ".mka", ".tta", ".aiff", ".au", ".mpc", ".spx", ".ac3"
                                strFileType = "Audio/Sound.png"
                            Case ".bmp", ".gif", ".jpg", ".jpeg", ".tif", ".tiff", ".pcx", ".png", ".jpe", ".tga"
                                strFileType = "Picture/Picture.png"
                            Case ".exe"
                                strFileType = "exe/exe.png"
                            Case Else
                                strFileType = "Other/Other.png"
                        End Select
                    Else
                        strFileType = "other/other.png"
                    End If
                End If
            Catch ex As Exception

            End Try
            Return strFileType
        End Function

        'Returns a DataSet containing the list of collection
        Public Function GetFilesScan(Optional ByVal _viewer As Integer = 0, Optional ByVal _size As String = "32") As DataSet
            Dim ds As New DataSet()
            Dim dt As New DataTable()
            dt.Columns.Add(New DataColumn("FielName", GetType(String)))
            dt.Columns.Add(New DataColumn("Icon", GetType(String)))
            dt.Columns.Add(New DataColumn("Name", GetType(String)))
            dt.Columns.Add(New DataColumn("Value", GetType(String)))
            dt.Columns.Add(New DataColumn("DocID", GetType(Integer)))
            dt.Columns.Add(New DataColumn("viewer", GetType(Boolean)))
            dt.Columns.Add(New DataColumn("id", GetType(Integer)))
            dt.Columns.Add(New DataColumn("XMLpath", GetType(String)))
            dt.Columns.Add(New DataColumn("viewContent", GetType(Integer)))
            dt.Columns.Add(New DataColumn("Creator", GetType(String)))
            dt.Columns.Add(New DataColumn("DateModified", GetType(Date)))
            ds.Tables.Add(dt)
            Dim _intId As Integer = 0
            'Dim procs As New BusinessLayer.Acquisition
            'Dim _ilist As IList = procs.Select_cat_files_scan(_viewer)
            'procs = Nothing
            Dim tblData As DataTable
            Dim strEbooks As String = "," & clsWCommon.gfileType.eEbook & ","
            objBEData.LibID = clsSession.GlbSite
            tblData = objBEData.getItemFilesTableOfConents(_viewer, strEbooks)
            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                Dim _fileName As String = ""
                For i As Integer = 0 To tblData.Rows.Count - 1
                    _fileName = tblData.Rows(i).Item("Path").ToString
                    If File.Exists(_fileName) Then
                        Dim parts As String() = _fileName.Split("\"c)
                        Dim name As String = parts(parts.Length - 1)
                        Dim fi As New FileInfo(_fileName)
                        Dim attribs As ItemAttributes = getItemAttributes(fi.Extension, _size)
                        Dim rowValues As Object() = New Object(10) {}
                        rowValues(0) = tblData.Rows(i).Item("fileName").ToString
                        rowValues(1) = attribs.Icon
                        rowValues(2) = objBCSP.TrimSubFieldCodes(tblData.Rows(i).Item("Name").ToString)
                        rowValues(3) = tblData.Rows(i).Item("Path").ToString
                        rowValues(4) = tblData.Rows(i).Item("ItemID").ToString
                        rowValues(5) = tblData.Rows(i).Item("viewer").ToString
                        rowValues(6) = tblData.Rows(i).Item("id").ToString
                        rowValues(7) = ""
                        rowValues(8) = tblData.Rows(i).Item("viewContent").ToString
                        rowValues(9) = tblData.Rows(i).Item("Creator").ToString
                        rowValues(10) = ""
                        If Not IsDBNull(tblData.Rows(i).Item("XMLpath").ToString) AndAlso tblData.Rows(i).Item("XMLpath").ToString.Trim <> "" Then
                            If tblData.Rows(i).Item("XMLpath").ToString.ToLower.EndsWith(".swf") Then
                                Dim _tempDir As String = Me.ChangeMapVirtualPath(tblData.Rows(i).Item("XMLpath").ToString)
                                '_tempDir = Replace(_tempDir, "\", "/")
                                'Dim _XMLViewer_physicalPath As String = Replace(clsCommon._XMLViewer_physicalPath, "\", "/")
                                'Dim _XMLViewer_VirtualPath As String = clsCommon._XMLViewer_VirtualPath
                                '_tempDir = Replace(_tempDir, _XMLViewer_physicalPath, _XMLViewer_VirtualPath)
                                rowValues(7) = _tempDir
                                Dim dateTimCreateFolder As DateTime = Directory.GetCreationTime(tblData.Rows(i).Item("Path").ToString)
                                rowValues(10) = dateTimCreateFolder
                            Else
                                'Dim _tempDir As String = GetDirectoryName(tblData.Rows(i).Item("XMLpath").ToString)
                                '_tempDir = _tempDir.Substring(_tempDir.LastIndexOf("\") + 1)
                                'rowValues(7) = "xml/" & _tempDir

                                rowValues(7) = tblData.Rows(i).Item("XMLpath").ToString
                                Dim dateTimCreateFolder As DateTime = Directory.GetCreationTime(tblData.Rows(i).Item("Path").ToString)
                                rowValues(10) = dateTimCreateFolder
                            End If

                        End If
                        dt.Rows.Add(rowValues)
                    End If
                Next
            End If

            'If Not IsNothing(_ilist) AndAlso _ilist.Count > 0 Then
            '    For Each ilist In _ilist
            '        _fileName = ilist.Path.ToString
            '        If File.Exists(_fileName) Then
            '            Dim parts As String() = _fileName.Split("\"c)
            '            Dim name As String = parts(parts.Length - 1)
            '            Dim fi As New FileInfo(_fileName)
            '            Dim attribs As ItemAttributes = getItemAttributes(fi.Extension, _size)
            '            Dim rowValues As Object() = New Object(9) {}
            '            rowValues(0) = ilist.fileName.ToString 'name
            '            rowValues(1) = attribs.Icon
            '            rowValues(2) = ilist.Name.ToString
            '            rowValues(3) = ilist.Path.ToString
            '            rowValues(4) = ilist.docID
            '            rowValues(5) = ilist.viewer
            '            rowValues(6) = ilist.id
            '            rowValues(7) = ""
            '            rowValues(8) = ilist.viewContent
            '            rowValues(9) = ilist.Creator.ToString
            '            If Not IsNothing(ilist.XMLpath) AndAlso Not ilist.XMLpath = "" Then
            '                If ilist.XMLpath.ToString.ToLower.EndsWith(".swf") Then
            '                    Dim _tempDir As String = ilist.XMLpath.ToString
            '                    _tempDir = Replace(_tempDir, "\", "/")
            '                    Dim _XMLViewer_physicalPath As String = Replace(clsCommon._XMLViewer_physicalPath, "\", "/")
            '                    Dim _XMLViewer_VirtualPath As String = clsCommon._XMLViewer_VirtualPath
            '                    _tempDir = Replace(_tempDir, _XMLViewer_physicalPath, _XMLViewer_VirtualPath)
            '                    rowValues(7) = _tempDir
            '                Else
            '                    Dim _tempDir As String = GetDirectoryName(ilist.XMLpath.ToString)
            '                    _tempDir = _tempDir.Substring(_tempDir.LastIndexOf("\") + 1)
            '                    rowValues(7) = "xml/" & _tempDir
            '                End If

            '            End If
            '            dt.Rows.Add(rowValues)
            '        End If
            '    Next
            'End If
            Return ds
        End Function

        'Private Sub TreeCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs) Handles TreeCallBack.Callback
        '    Try
        '        If Not IsNothing(e.Parameter) AndAlso e.Parameter > 0 Then
        '            Dim _FileId As Integer = e.Parameter
        '            Call initTreeViewCollection(_FileId)
        '            TreeViewCollection_Table_Of_Contents.RenderControl(e.Output)
        '        End If
        '    Catch ex As Exception : End Try
        'End Sub
        'TreeCallBack
        Private Sub CallbackTreeview_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs) Handles CallbackTreeview.Callback
            Try
                If Not IsNothing(e.Parameter) AndAlso e.Parameter > 0 Then
                    'Dim _FileId As Integer = e.Parameter
                    'TreeViewCollection_Table_Of_Contents.Dispose()
                    'Call initTreeViewCollection(_FileId)
                    'TreeViewCollection_Table_Of_Contents.RenderControl(e.Output)
                    Dim _docId As Integer = e.Parameter
                    TreeViewCollection_Table_Of_Contents.Dispose()
                    Call initTreeViewCollection(_docId)
                    TreeViewCollection_Table_Of_Contents.RenderControl(e.Output)
                End If
            Catch ex As Exception : End Try
        End Sub

        ' Triggered when context menu is activated 
        Private Sub MenuCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            System.Threading.Thread.Sleep(10)
            MenuCollection.Dispose()
            Call addMenuItems()
            MenuCollection.RenderControl(e.Output)
        End Sub

        ' Adds the top menu item. This technique can be used to generate the entire menu programmatically. 
        Private Sub addMenuItems()
            Dim bolItem As Boolean = False
            MenuCollection.Items.Clear()
            Dim newItem As ComponentArt.Web.UI.MenuItem
            newItem = New ComponentArt.Web.UI.MenuItem
            bolItem = getVisibleToolbarItem("New", clsWCommon.MAIN_TOOLBAR.catTableOfContent)
            With newItem
                .Text = span_treeview_new_Tableofcontent.InnerText
                .Value = "add"
                .Look.LeftIconUrl = "bookma-new.png"
                .Look.HoverLeftIconUrl = "bookma-new.png"
                .Visible = bolItem
            End With
            MenuCollection.Items.Insert(0, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .CssClass = "MenuBreak"
                .Look.ImageUrl = "break.gif"
                .Look.ImageWidth = Unit.Percentage(100)
                .Look.ImageHeight = "2"
                .Visible = bolItem
            End With
            MenuCollection.Items.Insert(1, newItem)
            bolItem = getVisibleToolbarItem("Edit", clsWCommon.MAIN_TOOLBAR.catTableOfContent)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_treeview_edit_Tableofcontent.InnerText
                .Value = "edit"
                .Look.LeftIconUrl = "bookmark-edit.png"
                .Look.HoverLeftIconUrl = "bookmark-edit.png"
                .Visible = bolItem
            End With
            MenuCollection.Items.Insert(2, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .CssClass = "MenuBreak"
                .Look.ImageUrl = "break.gif"
                .Look.ImageWidth = Unit.Percentage(100)
                .Look.ImageHeight = "2"
                .Visible = bolItem
            End With
            MenuCollection.Items.Insert(3, newItem)
            bolItem = getVisibleToolbarItem("Delete", clsWCommon.MAIN_TOOLBAR.catTableOfContent)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_treeview_delete_Tableofcontent.InnerText
                .Value = "delete"
                .Look.LeftIconUrl = "bookmark-delete.png"
                .Look.HoverLeftIconUrl = "bookmark-delete.png"
                .Visible = bolItem
            End With
            MenuCollection.Items.Insert(4, newItem)
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
        End Sub


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


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
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

