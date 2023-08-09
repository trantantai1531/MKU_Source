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
Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Common


Namespace eMicLibAdmin.WebUI.Serial
    Partial Class Page_AcqMagNumber
        Inherits clsWBase

        Private objBMagazine As New clsBMagazine


        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            If Not CheckPemission() Then
                Call WritePermErrorMssg()
            End If
            Initialize()
            Call BindScript()
            If Not Page.IsPostBack AndAlso Not GridCallBack.IsCallback Then
                Call initTreeViewFolder()
            End If
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init for objBPeriodicalCollection
            objBMagazine.InterfaceLanguage = Session("InterfaceLanguage")
            objBMagazine.DBServer = Session("DBServer")
            objBMagazine.ConnectionString = Session("ConnectionString")
            objBMagazine.Initialize()
        End Sub

        ' InitializeForCallback method
        ' Purpose: Init all neccessary objects
        Public Sub InitializeForCallback()
            ' Init for objBPeriodicalCollection
            objBMagazine.InterfaceLanguage = Session("InterfaceLanguage")
            objBMagazine.DBServer = Session("DBServer")
            objBMagazine.ConnectionString = Session("ConnectionString")
            objBMagazine.Initialize()
        End Sub

        ' BindScript method
        Private Sub BindScript()
            Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
            'Page.RegisterClientScriptBlock("SelfJS", "<script language = 'javascript' src = 'js/WSearch.js'></script>")
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

        Private Sub initTreeViewFolder()
            TreeViewFolder.Nodes.Clear()
            Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
            rootNode.Text = span_document_list.InnerText
            rootNode.ImageUrl = "folder_home.png"
            rootNode.Expanded = True
            rootNode.ID = "0"
            rootNode.Value = "0"
            TreeViewFolder.Nodes.Add(rootNode)
            BuildTreeDirectory(rootNode)
        End Sub

        Private Sub BuildTreeDirectory(ByVal parentNode As ComponentArt.Web.UI.TreeViewNode)
            Dim tblItem As New DataTable
            objBMagazine.LibID = clsSession.GlbSite
            tblItem = objBMagazine.getAllSerialItems
            If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                For i As Integer = 0 To tblItem.Rows.Count - 1
                    Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
                    node.ImageUrl = "iBooks-32.png"
                    node.Text = ""
                    If Not IsDBNull(tblItem.Rows(i).Item("TITLE")) Then
                        node.Text = tblItem.Rows(i).Item("TITLE").ToString
                    End If
                    node.ID = tblItem.Rows(i).Item("Code").ToString
                    node.Value = tblItem.Rows(i).Item("ID").ToString 'ItemID
                    parentNode.Nodes.Add(node)
                Next
            End If
        End Sub


        ' This callback is triggered a TreeView node is selected 
        Private Sub GridCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            ' Don't allow browsing the file system outside of the app root 
            Try
                If Not IsNothing(e.Parameter) AndAlso e.Parameter > 0 Then
                    GridFolder.DataSource = Nothing
                    GridFolder.DataBind()
                    GridFolder.Dispose()
                    Dim tblItem As New DataTable
                    objBMagazine.ItemID = e.Parameter
                    tblItem = objBMagazine.getAllMagazineByItemID
                    GridFolder.DataSource = tblItem
                    GridFolder.DataBind()
                    GridFolder.RenderControl(e.Output)
                Else
                    GridFolder.DataSource = Nothing
                    GridFolder.DataBind()
                    GridFolder.Dispose()
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
                .Text = span_grid_add.InnerText
                .Value = "add"
                .Look.LeftIconUrl = "Acquisition.png"
                .Look.HoverLeftIconUrl = "Acquisition.png"
            End With
            MenuGrid.Items.Insert(0, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_grid_edit.InnerText
                .Value = "edit"
                .Look.LeftIconUrl = "Modify.png"
                .Look.HoverLeftIconUrl = "Modify.png"
            End With
            MenuGrid.Items.Insert(1, newItem)
            newItem = New ComponentArt.Web.UI.MenuItem
            With newItem
                .Text = span_grid_delete.InnerText
                .Value = "delete"
                .Look.LeftIconUrl = "Delete.png"
                .Look.HoverLeftIconUrl = "Delete.png"
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
                .Text = span_grid_tableOfContents.InnerText
                .Value = "tableOfContents"
                .Look.LeftIconUrl = "bookma-new.png"
                .Look.HoverLeftIconUrl = "bookma-new.png"
            End With
            MenuGrid.Items.Insert(4, newItem)
        End Sub

        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Function callback_delete_magazine_number(ByVal Magid As Integer) As Integer
            Dim intMagId As Integer = 0
            Try
                Call InitializeForCallback()
                With objBMagazine
                    .MagId = Magid
                    intMagId = .deleteMagazineNo
                End With
                '        Dim clsLog As New BusinessLayer.Log
                '        clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsCommon.gModule.mPhanHeBienMuc, 1, clsCommon.gModule.mBienMucMucLuc, clsCommon.getTextLog(Common.FDataType.ACTION_AccessPage._Delete, Session("Language")) & ": Magazine id - " & Magid.ToString, "127.0.0.1")
            Catch ex As Exception
            End Try
            Return intMagId
        End Function


        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Call Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
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
            AddHandler Me.GridCallBack.Callback, AddressOf Me.GridCallBack_Callback
            AddHandler Me.MenuCallBack.Callback, AddressOf Me.MenuCallBack_Callback
            AddHandler Me.MenuCallBackGrid.Callback, AddressOf Me.MenuCallBackGrid_Callback
            AddHandler Me.Load, AddressOf Me.Page_Load
        End Sub
#End Region

    End Class
End Namespace




