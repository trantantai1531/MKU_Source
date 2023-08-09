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

Partial Class Pages_AcqDisplayCollection
    Inherits clsPage

    Protected _rootCollection As String = ""
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim _arrCollection() As String = clsCommon._rootsavefile.Split(";")
        If Not Page.IsPostBack AndAlso Not GridCallBack.IsCallback Then
            Call initTreeViewCollection()
            Call initGrid()
        End If
    End Sub


    'Init for treeview
    Private Sub initTreeViewCollection()
        TreeViewCollection.Nodes.Clear()
        Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
        rootNode.Text = span_treeview_root_collection.InnerText
        rootNode.ImageUrl = "Folder_home.png"
        rootNode.Expanded = True
        rootNode.ID = "0"
        TreeViewCollection.Nodes.Add(rootNode)
        Call BuildTreeDirectoryCollection(0, rootNode)
    End Sub

    Private Sub BuildTreeDirectoryCollection(ByVal _level As Integer, ByVal _parentNode As ComponentArt.Web.UI.TreeViewNode)
        Dim procs As New BusinessLayer.Acquisition
        Dim _Collection As IList = procs.Select_document_collection(_level)
        If Not _Collection Is Nothing AndAlso _Collection.Count > 0 Then
            For Each proc In _Collection
                Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
                node.Text = proc.Name.ToString
                node.ID = proc.ID.ToString
                _parentNode.Nodes.Add(node)
                Call BuildTreeDirectoryCollection(CInt(proc.ID), node)
            Next
        End If
    End Sub

    <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
    Public Sub SetFileNameSession(ByVal _path As String)
        Try
            Session("FileName") = _path
        Catch ex As Exception
        End Try
    End Sub

    <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
     Public Function CreateCollection(ByVal _ParentID As Integer, ByVal _Name As String) As Integer
        Try
            Dim _ExistCollection As New BusinessLayer.Acquisition
            Dim _bolExist As Boolean = _ExistCollection.Select_exist_document_collection(_ParentID, _Name)
            _ExistCollection = Nothing
            If _bolExist Then
                Return 0
            End If
            Dim _insertCollection As New BusinessLayer.Acquisition
            Dim _intInsert As Integer = _insertCollection.Insert_collection(_ParentID, _Name, "")
            _insertCollection = Nothing
            Return _intInsert
        Catch ex As Exception
            Return -1
        End Try
    End Function

    <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
    Public Function DeleteCollection(ByVal _id As Integer) As Integer
        Try
            Dim _selectParentCollection As New BusinessLayer.Acquisition
            Dim _Collection As IList = _selectParentCollection.Select_document_collection(_id)
            _selectParentCollection = Nothing
            If Not _Collection Is Nothing AndAlso _Collection.Count > 0 Then
                Return 2
            Else
                Dim _selectItemCollection As New BusinessLayer.Acquisition
                Dim _ItemCollection As IList = _selectItemCollection.Select_item_collection(_id)
                _selectItemCollection = Nothing
                If Not _ItemCollection Is Nothing AndAlso _ItemCollection.Count > 0 Then
                    Return 3
                Else
                    Dim _deleteCollection As New BusinessLayer.Acquisition
                    Dim _intDelelte As Boolean = _deleteCollection.Delete_collection(_id)
                    _deleteCollection = Nothing
                    If _intDelelte Then
                        Return 1
                    Else
                        Return 0
                    End If
                End If
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
   Public Function UpdateCollection(ByVal _idParent As Integer, ByVal _id As Integer, ByVal _name As String) As Integer
        Try
            Dim _ExistCollection As New BusinessLayer.Acquisition
            Dim _bolExist As Boolean = _ExistCollection.Select_exist_document_collection(_idParent, _name)
            _ExistCollection = Nothing
            If _bolExist Then
                Return 2
            End If
            Dim _updateCollection As New BusinessLayer.Acquisition
            Dim _intupdate As Boolean = _updateCollection.Update_collection(_id, _name)
            _updateCollection = Nothing
            If _intupdate Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub initGrid()
        Dim _Id As Integer = 0
        If Not Session("CollectionId") Is Nothing AndAlso Not Session("CollectionId") = "" Then
            _Id = Session("CollectionId")
        End If
        Dim ds As DataSet = clsCommon.GetCollectionDataSet(_Id, Session("Language"), "128")
        GridCollection.DataSource = ds
        GridCollection.DataBind()
    End Sub


    ' This callback is triggered a TreeView node is selected 
    Private Sub GridCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
        ' Don't allow browsing the file system outside of the app root 
        Try
            If e.Parameter <> "" Then
                GridCollection.DataSource = Nothing
                GridCollection.DataBind()
                GridCollection.Dispose()
                Session("CollectionId") = e.Parameter
                Dim ds As DataSet = clsCommon.GetCollectionDataSet(e.Parameter, Session("Language"), "128")
                GridCollection.DataSource = ds
                GridCollection.DataBind()
                GridCollection.RenderControl(e.Output)
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
        MenuCollection.Items.Clear()
        Dim newItem As ComponentArt.Web.UI.MenuItem
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .Text = span_treeview_charge.InnerText
            .Value = "charge"
            .Look.LeftIconUrl = "Charge.png"
            .Look.HoverLeftIconUrl = "Charge.png"
        End With
        MenuCollection.Items.Insert(0, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .CssClass = "MenuBreak"
            .Look.ImageUrl = "break.gif"
            .Look.ImageWidth = Unit.Percentage(100)
            .Look.ImageHeight = "2"
        End With
        MenuCollection.Items.Insert(1, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .Text = span_treeview_security.InnerText
            .Value = "security"
            .Look.LeftIconUrl = "Security.png"
            .Look.HoverLeftIconUrl = "Security.png"
        End With
        MenuCollection.Items.Insert(2, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .CssClass = "MenuBreak"
            .Look.ImageUrl = "break.gif"
            .Look.ImageWidth = Unit.Percentage(100)
            .Look.ImageHeight = "2"
        End With
        MenuCollection.Items.Insert(3, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .Text = span_treeview_status.InnerText
            .Value = "status"
            .Look.LeftIconUrl = "Status.png"
            .Look.HoverLeftIconUrl = "Status.png"
        End With
        MenuCollection.Items.Insert(4, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .CssClass = "MenuBreak"
            .Look.ImageUrl = "break.gif"
            .Look.ImageWidth = Unit.Percentage(100)
            .Look.ImageHeight = "2"
        End With
        MenuCollection.Items.Insert(5, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .Text = span_treeview_new_Collection.InnerText
            .Value = "add"
            .Look.LeftIconUrl = "cd_add.png"
            .Look.HoverLeftIconUrl = "cd_add.png"
        End With
        MenuCollection.Items.Insert(6, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .Text = span_treeview_edit_Collection.InnerText
            .Value = "edit"
            .Look.LeftIconUrl = "cd_edit.png"
            .Look.HoverLeftIconUrl = "cd_edit.png"
        End With
        MenuCollection.Items.Insert(7, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .Text = span_treeview_delete_Collection.InnerText
            .Value = "delete"
            .Look.LeftIconUrl = "cd_delete.png"
            .Look.HoverLeftIconUrl = "cd_delete.png"
        End With
        MenuCollection.Items.Insert(8, newItem)
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
            .Text = span_treeview_charge.InnerText
            .Value = "charge"
            .Look.LeftIconUrl = "Charge.png"
            .Look.HoverLeftIconUrl = "Charge.png"
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
            .Text = span_treeview_security.InnerText
            .Value = "security"
            .Look.LeftIconUrl = "Security.png"
            .Look.HoverLeftIconUrl = "Security.png"
        End With
        MenuGrid.Items.Insert(4, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .CssClass = "MenuBreak"
            .Look.ImageUrl = "break.gif"
            .Look.ImageWidth = Unit.Percentage(100)
            .Look.ImageHeight = "2"
        End With
        MenuGrid.Items.Insert(5, newItem)
        newItem = New ComponentArt.Web.UI.MenuItem
        With newItem
            .Text = span_treeview_status.InnerText
            .Value = "status"
            .Look.LeftIconUrl = "Status.png"
            .Look.HoverLeftIconUrl = "Status.png"
        End With
        MenuGrid.Items.Insert(6, newItem)
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
