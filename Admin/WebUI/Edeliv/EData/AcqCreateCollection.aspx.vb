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
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Catalogue
'Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common


Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqCreateCollection
        Inherits clsWBase

        Private objBEData As New eMicLibAdmin.BusinessRules.Edeliv.clsBEData
        Private objBCSP As New clsBCommonStringProc
        Private objBItemCollection As New clsBItemCollection

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Call Initialize()
            If Not Page.IsPostBack AndAlso Not GridCallBack.IsCallback AndAlso Not CallbackTreeview.IsCallback Then
                Dim collectionId As Integer = 0 'Root Node
                Dim addCollection As Integer = 0
                If Not IsNothing(Request("collectionId")) AndAlso Request("collectionId") <> "" Then
                    If Not IsNothing(Request("addCollection")) AndAlso Request("addCollection") <> "" Then
                        addCollection = Request("addCollection")
                    End If
                    collectionId = Request("collectionId")
                    Call showRecord()
                    Call showImageCover(addCollection)
                    Call setEnableControls(True)
                Else
                    Call setEnableControls(False)
                End If
                Call initTreeViewCollection(collectionId, addCollection)

                If Not IsNothing(Request("FilterCollectionId")) AndAlso Request("FilterCollectionId") <> "" Then
                    hidFilterCollectionId.Value = Request("FilterCollectionId")
                End If
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
            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
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
            'Init objBItemCollection
            objBItemCollection.ConnectionString = Session("ConnectionString")
            objBItemCollection.InterfaceLanguage = Session("InterfaceLanguage")
            objBItemCollection.DBServer = Session("DBServer")
            objBItemCollection.IsAuthority = Session("IsAuthority")
            Call objBItemCollection.Initialize()
        End Sub


        Private Sub setEnableControls(Optional ByVal bol As Boolean = False)
            Try
                txtTenbosuutap.Enabled = bol
                txtMotabosuutap.Enabled = bol
                AsyncFileUpload1.Enabled = bol
                If (bol) Then
                    chkShowOpac.Disabled = False
                Else
                    chkShowOpac.Disabled = True
                End If



                Dim strDisplay As String = "none"
                If bol Then
                    strDisplay = "inline"
                End If
                rLink.Style("display") = strDisplay
                AsyncFileUpload1.Style("display") = strDisplay
                If bol Then
                    txtTenbosuutap.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub showImageCover(ByVal addCollection As Integer)
            Try
                If addCollection = 1 Then 'add new
                    Session("imageCoverCollection") = Server.MapPath("~") & "\Upload\ImageCover\collectionCover.jpg"
                    MyImageCover.Src = "../../Upload/ImageCover/collectionCover.jpg"
                Else
                    If Not IsNothing(Session("imageCoverCollection")) AndAlso Session("imageCoverCollection") <> "" Then
                        Dim strPath As String = Session("imageCoverCollection")
                        Dim strImageCover As String = ""
                        Dim intImageCover As Integer = InStr(strPath, "\ImageCover\")
                        If intImageCover > 0 Then
                            strImageCover = strPath.Substring(InStr(strPath, "\ImageCover\") + 11)
                            strImageCover = Replace(strImageCover, "\", "/")
                        End If
                        MyImageCover.Src = "../../Upload/ImageCover/" & strImageCover
                    Else
                        Session("imageCoverCollection") = Server.MapPath("~") & "\Upload\ImageCover\collectionCover.jpg"
                        MyImageCover.Src = "../../Upload/ImageCover/collectionCover.jpg"
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub showRecord()
            Dim NumRec As Integer = 1
            If Not Request("NumRec") Is Nothing AndAlso Request("NumRec") <> "" Then
                NumRec = CInt(Request("NumRec"))
                Call setValueToolbar(NumRec)
            End If
            Call LoadGrid(NumRec)
        End Sub


        Private Sub LoadGrid(ByVal _Ind As Integer)
            Dim _Id As Integer = FindIDs(_Ind - 1)
            Dim ds As DataSet = GetViewRecordDataSet(_Id)
            Gridformat.DataSource = ds
            Gridformat.DataBind()
        End Sub

        'Returns a DataSet containing the list of viewrecord
        Public Function GetViewRecordDataSet(ByVal ItemID As Integer) As DataSet
            Dim ds As New DataSet()
            Try
                Dim dt As New DataTable()
                dt.Columns.Add(New DataColumn("FieldCode", GetType(String)))
                dt.Columns.Add(New DataColumn("Ind", GetType(String)))
                dt.Columns.Add(New DataColumn("Content", GetType(String)))
                ds.Tables.Add(dt)
                Dim tblData As DataTable
                With objBItemCollection
                    .ItemIDs = ItemID
                    tblData = objBItemCollection.GetContents
                End With
                Dim rowValues() As String
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                    For i As Integer = 0 To tblData.Rows.Count - 1
                        ReDim rowValues(2)
                        rowValues(0) = tblData.Rows(i).Item("FieldCode")
                        If Not IsNothing(tblData.Rows(i).Item("FieldCode")) AndAlso tblData.Rows(i).Item("FieldCode") <> "" Then
                            rowValues(0) = tblData.Rows(i).Item("FieldCode")
                        End If
                        rowValues(1) = ""
                        If Not IsNothing(tblData.Rows(i).Item("Ind")) AndAlso tblData.Rows(i).Item("Ind") <> "" Then
                            rowValues(1) = tblData.Rows(i).Item("Ind")
                        End If
                        rowValues(2) = ""
                        If Not IsNothing(tblData.Rows(i).Item("Content")) AndAlso tblData.Rows(i).Item("Content") <> "" Then
                            rowValues(2) = Replace(tblData.Rows(i).Item("Content"), vbNewLine, "&lt;br/&gt;")
                        End If
                        dt.Rows.Add(rowValues)
                    Next
                End If
                'Dim _intId As Integer = 0
                'Dim procs As New BusinessLayer.Acquisition
                'Dim _ilist As IList = procs.Select_document(_docId, _LanguageCode)
                'procs = Nothing
                'Dim _DubMarcField As String = ""
                ''Dim rowValues As Object() = New Object(2) {}
                'Dim rowValues() As String
                'For Each ilist In _ilist
                '    ReDim rowValues(2)
                '    rowValues(0) = ilist.docid
                '    rowValues(1) = Replace(ilist.Name.ToString, vbNewLine, "&lt;br/&gt;")
                '    If _DubMarcField = ilist.DubMarcField.ToString Then
                '        rowValues(2) = ""
                '    Else
                '        rowValues(2) = ilist.DubName.ToString
                '        If Not IsNothing(ilist.DubMarcField) AndAlso ilist.DubMarcField.ToString <> "" Then
                '            rowValues(2) &= " (" & ilist.DubMarcField.ToString & ")"
                '        End If
                '    End If
                '    dt.Rows.Add(rowValues)
                '    _DubMarcField = ilist.DubMarcField.ToString
                'Next
            Catch ex As Exception
            End Try
            Return ds
        End Function

        Private Sub setValueToolbar(Optional ByVal val As Integer = 1)
            Try
                Dim iCount As Integer = 0
                If Not IsNothing(Session("RecordCollectionIDs")) AndAlso IsArray(Session("RecordCollectionIDs")) Then
                    iCount = UBound(Session("RecordCollectionIDs")) + 1
                End If
                If iCount > 0 Then
                    indNum.MinValue = 1
                    indNum.MaxValue = iCount
                    indNum.Value = val
                    MaxNum.Value = iCount
                Else
                    indNum.Value = 0
                    indNum.MinValue = 0
                    indNum.MaxValue = 0
                    MaxNum.Value = 0
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function FindIDs(ByVal iOrder As Integer) As Integer
            Dim IntIDs As Integer = 0
            Try
                If IsArray(Session("RecordCollectionIDs")) Then
                    Dim iCount As Integer = UBound(Session("RecordCollectionIDs"))
                    For i As Integer = 0 To iCount
                        If i = iOrder Then
                            IntIDs = CInt(Session("RecordCollectionIDs")(i))
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception : End Try
            Return IntIDs
        End Function

        'Init for treeview
        Private Sub initTreeViewCollection(Optional ByVal collectionId As Integer = 0, Optional ByVal addNew As Integer = 0)
            TreeViewCollection.Nodes.Clear()
            Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
            rootNode.Text = span_treeview_root_collection.InnerText
            rootNode.ImageUrl = "Folder_home.png"
            rootNode.Expanded = True
            rootNode.ID = "0"
            rootNode.Attributes.Add("description", "")
            rootNode.Attributes.Add("cover", "")
            rootNode.Attributes.Add("isShow", 0)
            If collectionId = 0 Then
                TreeViewCollection.SelectedNode = rootNode
            End If
            TreeViewCollection.Nodes.Add(rootNode)
            Call BuildTreeDirectoryCollection(0, rootNode, collectionId, addNew)
        End Sub


        Private Sub BuildTreeDirectoryCollection(ByVal _level As Integer, ByVal _parentNode As ComponentArt.Web.UI.TreeViewNode, Optional ByVal collectionId As Integer = 0, Optional ByVal addNew As Integer = 0)
            Dim tblData As DataTable
            With objBEData
                .ParentID = _level
                .LibID = clsSession.GlbSite
                tblData = objBEData.getCollectionByParentID
            End With
            If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                Dim strDescription As String = ""
                Dim strCover As String = ""
                Dim intIsShow As Integer = 0
                For i As Integer = 0 To tblData.Rows.Count - 1
                    Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
                    With node
                        .Text = tblData.Rows(i).Item("Name").ToString
                        .ID = tblData.Rows(i).Item("ID").ToString
                        strDescription = ""
                        If Not IsDBNull(tblData.Rows(i).Item("Description")) AndAlso tblData.Rows(i).Item("Description").ToString <> "" Then
                            strDescription = tblData.Rows(i).Item("Description").ToString
                        End If
                        .Attributes.Add("description", strDescription)
                        If Not IsDBNull(tblData.Rows(i).Item("Cover")) AndAlso tblData.Rows(i).Item("Cover").ToString <> "" Then
                            strCover = tblData.Rows(i).Item("Cover").ToString
                        End If
                        .Attributes.Add("cover", strCover)
                        intIsShow = 0
                        If Not IsDBNull(tblData.Rows(i).Item("isShow")) AndAlso tblData.Rows(i).Item("isShow") Then
                            intIsShow = 1
                        End If
                        .Attributes.Add("isShow", intIsShow)
                        If collectionId.ToString = tblData.Rows(i).Item("ID").ToString Then
                            TreeViewCollection.SelectedNode = node
                            If addNew <> 1 Then
                                txtTenbosuutap.Text = tblData.Rows(i).Item("Name").ToString
                                txtMotabosuutap.Text = strDescription
                                chkShowOpac.Checked = intIsShow

                            End If
                        End If
                        If intIsShow Then
                            .ImageUrl = "~/Images/ComponentArt/Input/images/checkbox_yes.png"
                        Else
                            .ImageUrl = "~/Images/ComponentArt/Input/images/checkbox_no.png"
                        End If
                    End With
                    _parentNode.Nodes.Add(node)
                    Call BuildTreeDirectoryCollection(CInt(tblData.Rows(i).Item("ID").ToString), node, collectionId, addNew)
                Next
            End If
        End Sub

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function callbackDeleteCollection(ByVal _id As Integer) As Integer
            Dim _intReturn As Integer = 0
            Try
                Call InitializeForCallback()
                With objBEData
                    .CollectionID = _id
                    _intReturn = objBEData.deleteCollectionByCollectionID
                End With
                If _intReturn = 1 Then
                    Dim strLog As String = clsWCommon.getTextLog(clsWCommon.ACTION_ID.eDelete, clsSession.GlbLanguage) & ": Bộ sưu tập ID - " & _id.ToString
                    Call WriteLog(78, strLog, Me.SCRIPT_NAME, Me.REMOTE_ADDR, clsSession.GlbUserFullName)
                End If
            Catch ex As Exception
            End Try
            Return _intReturn
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function callbackUpdateCollection(ByVal intAddNew As Integer, ByVal _id As Integer, ByVal _name As String, ByVal _Description As String, ByVal _isShow As Integer, ByVal _idParent As Integer, ByVal filterCollectionId As Integer) As Integer
            Dim _intReturn As Integer = 0
            Try
                If Not IsNothing(Session("RecordCollectionIDs")) AndAlso IsArray(Session("RecordCollectionIDs")) Then
                    Call InitializeForCallback()
                    Dim iCount As Integer = UBound(Session("RecordCollectionIDs"))
                    _intReturn = 1
                    'If intAddNew <> 1 Then 'Modify
                    '    With objBEData
                    '        .CollectionID = _id
                    '        _intReturn = objBEData.deleteCollectionByCollectionID
                    '    End With
                    'End If
                    If _intReturn Then
                        Dim imgCover As String = ""
                        If Not IsNothing(Session("imageCoverCollection")) AndAlso Session("imageCoverCollection") <> "" Then
                            imgCover = Session("imageCoverCollection")
                        End If
                        Dim intCollection As Integer = 0 ' _db.insertCollection(_name.Trim, _Description.Trim, _isShow, _idParent, imgCover)
                        With objBEData
                            .LibID = clsSession.GlbSite
                            .CollectionID = _id
                            .ParentID = _idParent
                            .CollectionName = _name.Trim
                            .CollectionDescription = _Description.Trim
                            .CollectionIsShow = _isShow
                            .CollectionCover = imgCover
                            intCollection = objBEData.insertItemCollection(intAddNew)
                        End With
                        If intCollection > 0 Then
                            For i As Integer = 0 To iCount
                                With objBEData
                                    .CollectionID = intCollection
                                    .ItemID = Session("RecordCollectionIDs")(i)
                                    _intReturn = objBEData.insertCatDicCollection
                                End With
                            Next
                            'Cap nhat vao bang loc bo suu tap
                            _intReturn = insertCollectionFilter(intCollection)
                            _intReturn = intCollection
                        Else
                            _intReturn = -1 'Error
                        End If
                    Else
                        _intReturn = -2  'Error
                    End If
                End If
            Catch ex As Exception
                _intReturn = -3  'Error
            End Try
            Return _intReturn
        End Function


        Private Function insertCollectionFilter(ByVal collectionId As Integer) As Integer
            Dim intResult As Integer = 0
            Try
                Dim collFilter As New Collection
                collFilter = clsSession.GlbCollectionFilter
                If Not IsNothing(collFilter) Then
                    With objBEData
                        .CollectionID = collectionId
                        .CollectionFilterBoolArr = collFilter.Item("BoolArr")
                        .CollectionFilterFieldArr = collFilter.Item("FieldArr")
                        .CollectionFilterValArr = collFilter.Item("ValArr")
                        .CollectionFilterFromDate = collFilter.Item("fromDate")
                        .CollectionFilterToDate = collFilter.Item("toDate")
                        .CollectionFilterUsername = collFilter.Item("userName")
                        .CollectionFilterDocType = collFilter.Item("DocType")
                        intResult = objBEData.insertCollectionFilter
                    End With
                End If
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function MoveCollection(ByVal _id As Integer, ByVal _idParent As Integer) As Integer
            Dim _intReturn As Integer = 0
            Try
                Call InitializeForCallback()
                With objBEData
                    .CollectionID = _id
                    .ParentID = _idParent
                    _intReturn = objBEData.updateCollectionByParentID
                End With
                'Dim _updateCollection As New BusinessLayer.Acquisition
                'Dim _intupdate As Boolean = _updateCollection.Move_Update_Collection(_id, _idParent)
                '_updateCollection = Nothing
                'If _intupdate Then
                '    _intReturn = 1
                'End If
            Catch ex As Exception
            End Try
            Return _intReturn
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function callbackGetImageCover() As String
            Dim strResults As String = ""
            Try
                If Not IsNothing(Session("imageCoverCollection")) AndAlso Session("imageCoverCollection") <> "" Then
                    strResults = Session("imageCoverCollection")
                End If
            Catch ex As Exception
            End Try
            Return strResults
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function callbackGetDocIds(ByVal _id As Integer, ByVal imgCover As String) As Integer
            Dim _maxCount As Integer = 0
            Try
                Call InitializeForCallback()
                Dim tblData As DataTable
                With objBEData
                    .CollectionID = _id
                    .LibID = clsSession.GlbSite
                    tblData = objBEData.getCollectionByCollectionID
                End With
                If Not IsNothing(tblData) AndAlso tblData.Rows.Count > 0 Then
                    _maxCount = tblData.Rows.Count
                    Dim ArrIDs() As Integer = Nothing
                    For i As Integer = 0 To tblData.Rows.Count - 1
                        ReDim Preserve ArrIDs(i)
                        ArrIDs(i) = CInt(tblData.Rows(i).Item("ITEMID"))
                    Next
                    Session("RecordCollectionIDs") = ArrIDs
                Else
                    Session("RecordCollectionIDs") = Nothing
                End If

                'Dim procs As New BusinessLayer.Acquisition
                'Dim _GetIds As IList = procs.Select_Document_collection_by_Id(_id)
                'If Not _GetIds Is Nothing AndAlso _GetIds.Count > 0 Then
                '    _maxCount = _GetIds.Count
                '    Dim ArrIDs() As Integer = Nothing
                '    Dim _i As Integer = 0
                '    For Each GetIds In _GetIds
                '        ReDim Preserve ArrIDs(_i)
                '        ArrIDs(_i) = CInt(GetIds)
                '        _i += 1
                '    Next
                '    Session("RecordCollectionIDs") = ArrIDs
                'Else
                '    Session("RecordCollectionIDs") = Nothing
                'End If
                If imgCover <> "" Then
                    Dim ind As Integer = InStr(imgCover, "Upload/ImageCover/")
                    Dim strCover As String = ""
                    If ind > 0 Then
                        strCover = Server.MapPath("~") & "\" & imgCover.Substring(ind - 1)
                        strCover = Replace(strCover, "/", "\")
                        Session("imageCoverCollection") = strCover
                    Else
                        Session("imageCoverCollection") = ""
                    End If
                Else
                    Session("imageCoverCollection") = ""
                End If
            Catch ex As Exception
            End Try
            Return _maxCount
        End Function


        Private Sub GridCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            Try
                If e.Parameter <> "" Then
                    Gridformat.DataSource = Nothing
                    Gridformat.DataBind()
                    Gridformat.Dispose()
                    Call LoadGrid(e.Parameter)
                    Gridformat.RenderControl(e.Output)

                End If
            Catch ex As Exception : End Try
        End Sub

        Public Sub DisplayInfo(ByVal title As String, ByVal info As String, ByVal icon As Integer)
            Dim _strInfo As String = ""
            _strInfo = "top.MLContent.showDialogInfo('',true," & icon & ",'" & title & "','" & info & "');"
            clsWCommon.MyMsgBoxInfor(_strInfo, Me.Page)
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
            AddHandler Me.Load, AddressOf Me.Page_Load
        End Sub
#End Region

#Region "Upload"
        Protected Sub AsyncFileUpload1_UploadedComplete(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs)
            Try
                Dim intFileType As Integer = 0
                If (AsyncFileUpload1.HasFile) Then
                    'Dim _fileName As String = Format(Now, "yyyyMMddhhmmssfff") & Path.GetExtension(e.FileName)
                    Dim strTempPath As String = Server.MapPath("~/Upload/ImageCover/") & Format(Now, "yyyyMMddhhmmssfff") & Path.GetExtension(e.FileName)
                    intFileType = clsWCommon.GetFileMediaType(strTempPath)
                    If intFileType = clsWCommon.gfileType.ePicture Then
                        AsyncFileUpload1.SaveAs(strTempPath)
                        Dim fileName As String = Path.GetFileName(e.FileName) ' Format(Now, "yyyyMMddhhmmssfff") & Path.GetExtension(e.FileName)

                        fileName = clsWCommon.ChangeFileName(fileName)
                        Dim strDictionary As String = Format(Now, "yyyyMMdd")
                        Dim strPath As String = Server.MapPath("~/Upload/ImageCover/") & strDictionary
                        If Not Directory.Exists(strPath) Then
                            Directory.CreateDirectory(strPath)
                        End If
                        If strPath.EndsWith("\") = False Then
                            strPath &= "\"
                        End If
                        strPath &= fileName

                        Dim imgResize As System.Drawing.Image = System.Drawing.Image.FromFile(strTempPath)
                        Dim thumbNailImg As System.Drawing.Image
                        thumbNailImg = ResizeImage(imgResize, clsWCommon.gImageWidthCollection, clsWCommon.gImageHeightCollection)
                        thumbNailImg.Save(strPath, System.Drawing.Imaging.ImageFormat.Jpeg)
                        thumbNailImg.Dispose()
                        imgResize.Dispose()
                        imgResize = Nothing
                        thumbNailImg = Nothing
                        MyImageCover.Src = "../../Upload/ImageCover/" & strDictionary & "/" & fileName
                        Session("imageCoverCollection") = strPath

                        File.Delete(strTempPath)
                        'lnkDelete.Visible = True
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Protected Function ResizeImage(ByVal original As System.Drawing.Image, ByVal _Width As Integer, ByVal _Height As Integer) As System.Drawing.Image
            Try
                Dim tn As New System.Drawing.Bitmap(_Width, _Height)
                Dim g As Graphics = Graphics.FromImage(tn)
                g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBilinear
                g.DrawImage(original, New System.Drawing.Rectangle(0, 0, tn.Width, tn.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel)
                g.Dispose()
                Return CType(tn, System.Drawing.Image)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function Delete_Image_Cover() As Integer
            Dim intResult As Integer = 0
            Try
                If Not IsNothing(Session("imageCoverCollection")) AndAlso Session("imageCoverCollection") <> "" Then
                    Dim strPath As String = Session("imageCoverCollection")
                    If File.Exists(strPath) Then
                        If InStr(strPath.ToLower, "\upload\imagecover\collectioncover.jpg") = 0 Then
                            File.Delete(strPath)
                            Session("imageCoverCollection") = Server.MapPath("~") & "\Upload\ImageCover\collectionCover.jpg"
                        End If
                        intResult = 1
                    End If
                End If
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function callbackChangeFileName(ByVal fileName As String) As String
            Dim strResult As String = ""
            Try
                strResult = clsWCommon.ChangeFileName(fileName)
            Catch ex As Exception
            End Try
            Return strResult
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
                If Not objBItemCollection Is Nothing Then
                    objBItemCollection.Dispose(True)
                    objBItemCollection = Nothing
                End If
            Finally
                MyBase.Dispose()
                Call Dispose()
            End Try
        End Sub

#End Region
    End Class
End Namespace

