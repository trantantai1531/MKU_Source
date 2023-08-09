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
Imports eMicLibAdmin.BusinessRules.Edeliv

Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class Pages_AcqDisplayformat
        Inherits clsWBase

        Private objBEData As New clsBEData
        Protected _rootformat As String = ""

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            Call Initialize()
            Dim _arrformat() As String = Me.getUploadRoot().Split(";")
            If Not Page.IsPostBack AndAlso Not GridCallBack.IsCallback Then
                Call initTreeViewformat()
                Call initGrid()
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
        End Sub

        'Init for treeview
        Private Sub initTreeViewformat()
            TreeViewformat.Nodes.Clear()
            Dim rootNode As New ComponentArt.Web.UI.TreeViewNode()
            rootNode.Text = span_treeview_root_format.InnerText
            rootNode.ImageUrl = "folder_blue.png"
            rootNode.Expanded = True
            rootNode.ID = "0"
            TreeViewformat.Nodes.Add(rootNode)
            Call BuildTreeDirectoryformat(0, rootNode)
        End Sub

        Private Sub BuildTreeDirectoryformat(ByVal _level As Integer, ByVal _parentNode As ComponentArt.Web.UI.TreeViewNode)
            'Dim procs As New BusinessLayer.Acquisition
            'Dim _format As IList = procs.Select_document_files_format(Session("Language"))
            'If Not _format Is Nothing AndAlso _format.Count > 0 Then
            '    For Each proc In _format
            '        Dim _formatCount As Integer = procs.Select_document_files_count_format(proc.ID, Session("Language"))
            '        Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
            '        node.Text = proc.Name.ToString & " (" & _formatCount.ToString & ")"
            '        node.ID = proc.ID.ToString
            '        _parentNode.Nodes.Add(node)
            '    Next
            'End If
            Try
                Dim tblData As DataTable
                With objBEData
                    .LibID = clsSession.GlbSite
                    tblData = .getCountFormat
                End With
                For i As Integer = 0 To tblData.Rows.Count - 1
                    Dim node As ComponentArt.Web.UI.TreeViewNode = New ComponentArt.Web.UI.TreeViewNode()
                    node.Text = tblData.Rows(i).Item("Name").ToString & " (" & tblData.Rows(i).Item("ACOUNT").ToString & ")"
                    node.ID = tblData.Rows(i).Item("ID").ToString
                    _parentNode.Nodes.Add(node)
                Next
            Catch ex As Exception
            End Try
        End Sub


        Private Sub initGrid()
            Dim _Id As Integer = 0
            If Not Session("formatId") Is Nothing AndAlso Not Session("formatId") = "" Then
                _Id = Session("formatId")
            End If
            Dim ds As DataSet = GetformatDataSet(_Id, Session("Language"), "128")
            Gridformat.DataSource = ds
            Gridformat.DataBind()
        End Sub

        'Returns a DataSet containing the list of format
        Private Function GetFormatDataSet(ByVal _FormatId As Integer, Optional ByVal _LanguageCode As String = "vie", Optional ByVal _size As String = "32") As DataSet
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
            ds.Tables.Add(dt)
            Dim _intId As Integer = 0
            'Dim procs As New BusinessLayer.Acquisition
            'Dim _ilist As IList = procs.Select_document_files_formatId(_FormatId, _LanguageCode)
            'procs = Nothing

            Dim tblData As DataTable
            With objBEData
                .FileFormat = _FormatId
                .LibID = clsSession.GlbSite
                tblData = .getFilesFormat
            End With
            Dim _fileName As String = ""
            For i As Integer = 0 To tblData.Rows.Count - 1
                _fileName = tblData.Rows(i).Item("Path").ToString ' IList.Path.ToString
                If File.Exists(_fileName) Then
                    Dim parts As String() = _fileName.Split("\"c)
                    Dim name As String = parts(parts.Length - 1)
                    Dim icon As String = "file.gif"
                    Dim type As String = ""
                    Dim fi As New FileInfo(_fileName)
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
                    rowValues(11) = tblData.Rows(i).Item("SercretLevel").ToString 'IList.SercretLevel.ToString
                    rowValues(12) = tblData.Rows(i).Item("DownloadTimes").ToString 'IList.DownloadTimes.ToString
                    rowValues(13) = tblData.Rows(i).Item("ItemID").ToString ' IList.DocID.ToString
                    rowValues(14) = tblData.Rows(i).Item("status").ToString ' IList.status.ToString
                    rowValues(15) = tblData.Rows(i).Item("Charge").ToString 'IList.Charge.ToString
                    rowValues(16) = tblData.Rows(i).Item("statusid").ToString 'IList.statusid.ToString
                    dt.Rows.Add(rowValues)
                End If
            Next

            'Dim _fileName As String = ""
            'For Each ilist In _ilist
            '    _fileName = ilist.Path.ToString
            '    If File.Exists(_fileName) Then
            '        Dim parts As String() = _fileName.Split("\"c)
            '        Dim name As String = parts(parts.Length - 1)
            '        Dim icon As String = "file.gif"
            '        Dim type As String = ""
            '        Dim fi As New FileInfo(_fileName)
            '        Dim attribs As clsWCommon.ItemAttributes = clsWCommon.getItemAttributes(fi.Extension, _size)
            '        Dim rowValues As Object() = New Object(16) {}
            '        rowValues(0) = name
            '        rowValues(1) = attribs.Icon
            '        rowValues(2) = fi.Length
            '        rowValues(3) = attribs.Type
            '        rowValues(4) = fi.LastWriteTime
            '        rowValues(5) = False
            '        rowValues(6) = ""
            '        rowValues(7) = fi.Extension
            '        rowValues(8) = clsWCommon.GetSizeString(fi.Length)
            '        rowValues(9) = fi.FullName
            '        rowValues(10) = _intId
            '        _intId += 1
            '        rowValues(11) = ilist.SercretLevel.ToString
            '        rowValues(12) = ilist.DownloadTimes.ToString
            '        rowValues(13) = ilist.DocID.ToString
            '        rowValues(14) = ilist.status.ToString
            '        rowValues(15) = ilist.Charge.ToString
            '        rowValues(16) = ilist.statusid.ToString
            '        dt.Rows.Add(rowValues)
            '    End If
            'Next
            Return ds
        End Function



        <ComponentArt.Web.UI.ComponentArtCallbackMethod()> _
        Public Sub SetFileNameSession(ByVal _path As String)
            Try
                Session("FileName") = _path
            Catch ex As Exception
            End Try
        End Sub

        ' This callback is triggered a TreeView node is selected 
        Private Sub GridCallBack_Callback(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.CallBackEventArgs)
            ' Don't allow browsing the file system outside of the app root 
            Try
                If e.Parameter <> "" Then
                    Gridformat.DataSource = Nothing
                    Gridformat.DataBind()
                    Gridformat.Dispose()
                    Session("formatId") = e.Parameter
                    Dim ds As DataSet = GetFormatDataSet(e.Parameter, Session("Language"), "128")
                    Gridformat.DataSource = ds
                    Gridformat.DataBind()
                    Gridformat.RenderControl(e.Output)
                End If
            Catch ex As Exception : End Try
        End Sub

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
            AddHandler Me.Load, AddressOf Me.Page_Load
        End Sub
#End Region
    End Class
End Namespace

