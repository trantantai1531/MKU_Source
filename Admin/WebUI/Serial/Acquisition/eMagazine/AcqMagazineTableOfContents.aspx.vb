Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class eMagazine_AcqTableOfContents
        Inherits clsWBase

        Private objBMagazine As New clsBMagazine
        Private objBCSP As New clsBCommonStringProc

        Private Sub initTreeViewTOC(ByVal MagId As Integer)
            TreeViewCollection_Table_Of_Contents.Nodes.Clear()
            Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
            rootNode.Text = span_treeview_root_Tableofcontent.InnerText
            rootNode.ImageUrl = "TableOfContents.png"
            rootNode.Expanded = True
            rootNode.ID = "0"
            rootNode.Value = "0-0"
            TreeViewCollection_Table_Of_Contents.Nodes.Add(rootNode)
            Call BuildTreeDirectoryTOC(MagId, rootNode)
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Initialize()
            Call BindScript()

            If Not Page.IsPostBack AndAlso Not CallbackTreeview.IsCallback Then
                hidIIPServer.Value = clsWCommon.gIIPServer
                If Not Request("MagId") Is Nothing AndAlso Request("MagId") <> "" Then
                    hidMagId.Value = Request("MagId")
                End If
                If Not Request("page") Is Nothing AndAlso Request("page") <> "" Then
                    hidMagPage.Value = Request("page")
                End If
                Call loadMagazineNumber(hidMagId.Value, hidMagPage.Value)
                Call initTreeViewTOC(hidMagDetailId.Value)

                pageInfo.InnerText = span_page.InnerText & Space(1) & hidMagPage.Value & "/" & hidMagPageCount.Value
            End If
        End Sub


        ' BindScript method
        Private Sub BindScript()
            'Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
            ' Init for objBPeriodicalCollection
            objBMagazine.InterfaceLanguage = Session("InterfaceLanguage")
            objBMagazine.DBServer = Session("DBServer")
            objBMagazine.ConnectionString = Session("ConnectionString")
            objBMagazine.Initialize()
        End Sub

        ' InitializeForCallback method
        ' Purpose: Init all neccessary objects
        Public Sub InitializeForCallback()
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            objBCSP.ConnectionString = Session("ConnectionString")
            Call objBCSP.Initialize()
            ' Init for objBPeriodicalCollection
            objBMagazine.InterfaceLanguage = Session("InterfaceLanguage")
            objBMagazine.DBServer = Session("DBServer")
            objBMagazine.ConnectionString = Session("ConnectionString")
            objBMagazine.Initialize()
        End Sub

        Private Sub loadMagazineNumber(ByVal MagId As Integer, ByVal MagPage As Integer)
            Try
                Dim tblItem As New DataTable
                objBMagazine.MagId = MagId
                tblItem = objBMagazine.getMagazineDetailByMagID

                If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                    hidMagPageCount.Value = tblItem.Rows.Count
                    For i As Integer = 0 To tblItem.Rows.Count - 1
                        If tblItem.Rows(i).Item("PageNum").ToString = MagPage.ToString Then
                            hidMagFilePath.Value = Replace(tblItem.Rows(i).Item("XMLpath").ToString, "\", "/")
                            hidMagDetailId.Value = tblItem.Rows(i).Item("Id")
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub BuildTreeDirectoryTOC(ByVal MagId As Integer, ByVal rootNode As ComponentArt.Web.UI.TreeViewNode)
            Try
                Dim tblItem As New DataTable
                objBMagazine.MagId = MagId
                tblItem = objBMagazine.getManazineTOCByMagDetailID
                If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                    For i As Integer = 0 To tblItem.Rows.Count - 1
                        Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
                        node.Text = ""
                        node.ToolTip = ""
                        If Not IsDBNull(tblItem.Rows(i).Item("Overview")) Then
                            node.Text = tblItem.Rows(i).Item("Overview").ToString
                            node.ToolTip = tblItem.Rows(i).Item("Overview").ToString
                        End If
                        node.ID = tblItem.Rows(i).Item("Id").ToString
                        node.Value = ""
                        If Not IsDBNull(tblItem.Rows(i).Item("coordinatesX")) AndAlso Not IsDBNull(tblItem.Rows(i).Item("coordinatesY")) Then
                            node.Value = tblItem.Rows(i).Item("coordinatesX").ToString & "-" & tblItem.Rows(i).Item("coordinatesY").ToString
                        End If
                        rootNode.Nodes.Add(node)
                    Next
                End If
            Catch ex As Exception
            End Try
        End Sub

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function CreateTableofcontent(ByVal subjectName As String, ByVal authorName As String, ByVal overview As String, ByVal magId As Integer, ByVal pageNum As Integer, ByVal coordinatesX As Double, ByVal coordinatesY As Double) As Integer
            Dim _intInsert As Integer = 0
            Try
                Call InitializeForCallback()
                Dim subjectId As Integer = 0
                If Not subjectName.Trim = "" Then
                    Dim strSubjectName As String = objBCSP.ProcessVal(subjectName)
                    With objBMagazine
                        .DisplayEntry = subjectName
                        .AccessEntry = strSubjectName
                        .VietnameseAccent = objBCSP.CutVietnameseAccent(strSubjectName)
                        subjectId = .insertMagazineTOCForKeyWord
                    End With
                End If
                Dim authorId As Integer = 0
                If Not authorName.Trim = "" Then
                    Dim strauthorName As String = objBCSP.ProcessVal(authorName)
                    With objBMagazine
                        .DisplayEntry = authorName
                        .AccessEntry = strauthorName
                        .VietnameseAccent = objBCSP.CutVietnameseAccent(strauthorName)
                        authorId = .insertMagazineTOCForAuthor
                    End With
                End If

                With objBMagazine
                    .MagId = magId
                    .SubjectId = subjectId
                    .AuthorId = authorId
                    .Overview = overview
                    .PageNum = pageNum
                    .userName = clsSession.GlbUser
                    .coordinatesX = IIf(coordinatesX > 0, coordinatesX, 0)
                    .coordinatesY = IIf(coordinatesY > 0, coordinatesY, 0)
                    _intInsert = .insertMagazineTOC
                End With
                'If _intInsert > 0 Then
                '    Dim clsLog As New BusinessLayer.Log
                '    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._New, Session("Language")) & ": số mục lục chi tiết id - " & _intInsert.ToString, "127.0.0.1")
                'End If
            Catch ex As Exception
            End Try
            Return _intInsert
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function UpdateTableofcontent(ByVal magId As Integer, ByVal subjectName As String, ByVal authorName As String, ByVal overview As String, ByVal pageNum As Integer, ByVal coordinatesX As Double, ByVal coordinatesY As Double) As Integer
            Dim intUpdate As Integer = 0
            Try
                ''Dim subjectId As Integer = 0
                ''If Not subjectName.Trim = "" Then
                ''    Dim _insertKeyword As New BusinessLayer.Acquisition
                ''    subjectId = _insertKeyword.Insert_magazine_keyword(0, 0, subjectName.Trim, clsWCommon.ProcessValOpac(subjectName.Trim), subjectName.Trim, clsWCommon.ProcessValOpac(subjectName.Trim))
                ''    If Not IsNothing(_insertKeyword) Then
                ''        _insertKeyword = Nothing
                ''    End If
                ''End If
                ''Dim authorId As Integer = 0
                ''If Not authorName.Trim = "" Then
                ''    Dim _insertAuthor As New BusinessLayer.Acquisition
                ''    authorId = _insertAuthor.Insert_magazine_author(0, authorName.Trim, clsWCommon.ProcessValOpac(authorName.Trim))
                ''    If Not IsNothing(_insertAuthor) Then
                ''        _insertAuthor = Nothing
                ''    End If
                ''End If
                ''Dim updateToc As New BusinessLayer.Acquisition
                ''Dim intUpdate As Boolean = updateToc.Update_magazine_table_of_content(magId, Session("username"), subjectId, authorId, overview, pageNum, coordinatesX, coordinatesY)
                ''updateToc = Nothing
                ''If intUpdate Then
                ''    Dim clsLog As New BusinessLayer.Log
                ''    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._Update, Session("Language")) & ": số mục lục chi tiết id - " & magId.ToString, "127.0.0.1")
                ''End If
                'Return 1
                Call InitializeForCallback()
                Dim subjectId As Integer = 0
                If Not subjectName.Trim = "" Then
                    Dim strSubjectName As String = objBCSP.ProcessVal(subjectName)
                    With objBMagazine
                        .DisplayEntry = subjectName
                        .AccessEntry = strSubjectName
                        .VietnameseAccent = objBCSP.CutVietnameseAccent(strSubjectName)
                        subjectId = .insertMagazineTOCForKeyWord
                    End With
                End If
                Dim authorId As Integer = 0
                If Not authorName.Trim = "" Then
                    Dim strauthorName As String = objBCSP.ProcessVal(authorName)
                    With objBMagazine
                        .DisplayEntry = authorName
                        .AccessEntry = strauthorName
                        .VietnameseAccent = objBCSP.CutVietnameseAccent(strauthorName)
                        authorId = .insertMagazineTOCForAuthor
                    End With
                End If
                With objBMagazine
                    .Id = magId
                    .SubjectId = subjectId
                    .AuthorId = authorId
                    .Overview = overview
                    .PageNum = pageNum
                    .userNameUpdate = clsSession.GlbUser
                    .coordinatesX = IIf(coordinatesX > 0, coordinatesX, 0)
                    .coordinatesY = IIf(coordinatesY > 0, coordinatesY, 0)
                    intUpdate = .updateMagazineTOC
                End With
            Catch ex As Exception
            End Try
            Return intUpdate
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function DeleteTableofcontent(ByVal id As Integer) As Integer
            Dim intDelete As Integer = 0
            Try
                Call InitializeForCallback()
                With objBMagazine
                    .Id = id
                    intDelete = .deleteMagazineTOC
                End With
                'Dim deleteMagazineToc As New BusinessLayer.Acquisition
                'Dim bolDelelte As Boolean = deleteMagazineToc.Delete_magazine_table_of_content(id)
                'deleteMagazineToc = Nothing
                'If bolDelelte Then
                '    Dim clsLog As New BusinessLayer.Log
                '    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._Delete, Session("Language")) & ": số mục lục chi tiết id - " & id.ToString, "127.0.0.1")
                '    Return 1
                'Else
                '    Return 0
                'End If
            Catch ex As Exception
            End Try
            Return intDelete
        End Function


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


        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function UpdateAnnotation(ByVal magDetailId As Integer, ByVal aId As String, ByVal coordinatesX As Double, ByVal coordinatesY As Double, ByVal aWidth As Double, ByVal aHeight As Double, ByVal title As String, ByVal lnk As String) As Integer
            Dim intResult As Integer = 0
            Try
                Call InitializeForCallback()
                With objBMagazine
                    .magDetailId = magDetailId
                    .aId = aId
                    .coordinatesX = IIf(coordinatesX > 0, coordinatesX, 0)
                    .coordinatesY = IIf(coordinatesY > 0, coordinatesY, 0)
                    .aWidth = aWidth
                    .aHeight = aHeight
                    .title = title
                    .lnk = lnk
                    intResult = .updateMagazineTOCAnnotation
                End With
                'If intResult Then
                '    Dim clsLog As New BusinessLayer.Log
                '    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._New, Session("Language")) & ": Thêm mới link chi tiết id - " & aId.ToString, "127.0.0.1")
                'End If
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function DeleteAnnotation(ByVal magDetailId As Integer, ByVal aId As String) As Integer
            Dim intResult As Integer = 0
            Try
                Call InitializeForCallback()
                With objBMagazine
                    .magDetailId = magDetailId
                    .aId = aId
                    intResult = .deleteMagazineTOCAnnotation
                End With
                'If intResult Then
                '    intResult = 1
                '    Dim clsLog As New BusinessLayer.Log
                '    clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsWCommon.gModule.mPhanHeBienMuc, 1, clsWCommon.gModule.mBienMucMucLuc, clsWCommon.getTextLog(Common.FDataType.ACTION_ID._Update, Session("Language")) & ": Cập nhật link chi tiết id - " & aId.ToString, "127.0.0.1")
                'Else
                '    intResult = 2
                'End If
            Catch ex As Exception
            End Try
            Return intResult
        End Function

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBMagazine Is Nothing Then
                    objBMagazine.Dispose(True)
                    objBMagazine = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
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
            AddHandler Me.MenuCallBack.Callback, AddressOf Me.MenuCallBack_Callback
            AddHandler Me.Load, AddressOf Me.Page_Load
        End Sub
#End Region
    End Class
End Namespace

