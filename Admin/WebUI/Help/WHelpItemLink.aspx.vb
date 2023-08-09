' Purpose: Manage HelpInfor
' Creator: thaott
' Created Date: 30/Aug/2006
' Modification History: 
Imports eMicLibAdmin.BusinessRules
Imports System.IO
Imports System.IO.Directory
Imports System.IO.DirectoryInfo
Imports System.IO.File
Namespace eMicLibAdmin.WebUI
    Partial Class WHelpItemLink
        Inherits clsWHelpBase
        'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Private objBHelp As New clsBHelp
        Dim intType As String
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            intType = Request.QueryString("Type")
            If intType = "" Then intType = 0
            If Not Page.IsPostBack Then
                Call Initialize()
                If intType = 0 Then
                    LoadDataToListBox(Session("ItemLinkID"))
                End If
                If intType = 1 Then
                    LoadDataFileToListBox(Session("FileID"), Session("HelpLibolType"))
                End If
            End If
            '---JS
            bttClose.Attributes.Add("onclick", "parent.close();")
        End Sub
        Private Sub Initialize()
            ' Init objBHoldingInfo object
            objBHelp.InterfaceLanguage = Session("InterfaceLanguage")
            objBHelp.DBServer = Session("DBServer")
            objBHelp.ConnectionString = Session("ConnectionString")
            Call objBHelp.Initialize()
        End Sub
        '
        ' Name: LoadDataToListBox
        ' Purpose: Load data to Listbox
        ' Input: strNotSelectCatDicID,strCatDicID
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Private Sub LoadDataToListBox(ByVal strLinkSelect As String)
            Dim dtList As New DataTable
            Dim dtListSelected As New DataTable
            Dim dtvList As New DataView
            If strLinkSelect Is Nothing Then strLinkSelect = ""
            If strLinkSelect <> "" Then
                objBHelp.ListCatDicID = strLinkSelect
                objBHelp.NotSelectCatDicID = ""
                objBHelp.Type = Session("HelpLibolType")
                objBHelp.GetHepCatDicByID()
                dtListSelected = objBHelp.GetHepCatDicByID
                lstLinkSelected.DataSource = dtListSelected
                lstLinkSelected.DataTextField = "HelpTitle"
                lstLinkSelected.DataValueField = "ID"
                lstLinkSelected.DataBind()
            End If
            objBHelp.ListCatDicID = ""
            objBHelp.NotSelectCatDicID = strLinkSelect
            dtList = objBHelp.GetHepCatDicByID
            dtvList.Table = dtList
            If Request.QueryString("DicID") <> "" Then
                dtvList.RowFilter = "ParentID=" & Request.QueryString("DicID")
            End If
            lstLink.DataSource = dtvList
            lstLink.DataTextField = "HelpTitle"
            lstLink.DataValueField = "ID"
            lstLink.DataBind()

        End Sub
        '
        ' Name: LoadDataFileToListBox
        ' Purpose: Load file to Listbox
        ' Input: strNotSelectCatDicID,strCatDicID
        ' Output: DataTable
        ' Creator: thaott
        ' Created Date: 1Sep2006
        ' Modification History: 
        Private Sub LoadDataFileToListBox(ByVal strFileSelect As String, ByVal intType As Integer)
            Dim dtFile As New DataTable
            Dim dtList As New DataTable
            Dim dtListSelected As New DataTable
            Dim dtvList As New DataView
            Dim arrFilefoler() As String
            Dim arrSession() As String
            Dim arrFileSelected() As String
            Dim i, j, n As Integer
            '---Get file from folder
            If intType = 0 Then
                GetFolderFile(Server.MapPath(Session("strRootOPAC")), "OPAC", arrFilefoler)
            End If
            If intType = 1 Then
                GetFolderFile(Server.MapPath(Session("strRootLibol")), "Libol60", arrFilefoler)
            End If

            '--Get file from database
            dtFile = objBHelp.GetHepCatFileByDicID()
            '---Add to arrFileSelected
            arrFileSelected = Session("arrFile")
            If dtFile.Rows.Count > 0 Then

                If Not IsNothing(arrFileSelected) Then
                    i = arrFileSelected.Length
                    n = i + dtFile.Rows.Count - 1
                Else
                    i = 0
                    n = dtFile.Rows.Count - 1
                End If
                ReDim Preserve arrFileSelected(n)
                For j = i To n
                    arrFileSelected(i) = dtFile.Rows(n - j).Item("FileURL")
                Next
            End If
            '---Add to lstLink
            Dim blnAdd As Boolean = True
            lstLink.Items.Clear()
            For i = 1 To arrFilefoler.Length - 1
                blnAdd = True
                If Not IsNothing(arrFileSelected) Then
                    For j = 0 To arrFileSelected.Length - 1
                        If arrFilefoler(i) = arrFileSelected(j) Then
                            blnAdd = False
                        End If
                    Next
                End If
                If blnAdd = True Then
                    lstLink.Items.Add(arrFilefoler(i))
                End If
            Next
            '--Add to lstLinkSelected
            lstLinkSelected.Items.Clear()
            arrSession = Session("arrFile")
            If Not IsNothing(arrSession) Then
                For i = 0 To arrSession.Length - 1
                    lstLinkSelected.Items.Add(arrSession(i))
                Next
            End If
        End Sub

        Private Sub bttAddOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttAddOne.Click
            '---Add
            Dim i As Integer
            Dim str As String
            Dim licCollection As New ListItemCollection
            For i = 0 To lstLink.Items.Count - 1
                If lstLink.Items(i).Selected Then
                    lstLinkSelected.Items.Add(lstLink.Items(i))
                Else
                    licCollection.Add(lstLink.Items(i))
                End If
            Next
            '--Remove and add item again
            lstLink.Items.Clear()
            For i = 0 To licCollection.Count - 1
                lstLink.Items.Add(licCollection(i))
            Next
            SubSaveSelectItem()
        End Sub

        Private Sub bttDeleteOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttDeleteOne.Click
            Dim i As Integer
            Dim str As String
            Dim licCollection As New ListItemCollection
            For i = 0 To lstLinkSelected.Items.Count - 1
                If lstLinkSelected.Items(i).Selected Then
                    lstLink.Items.Add(lstLinkSelected.Items(i))
                Else
                    licCollection.Add(lstLinkSelected.Items(i))
                End If
            Next
            '--Remove & Add item again
            lstLinkSelected.Items.Clear()
            For i = 0 To licCollection.Count - 1
                lstLinkSelected.Items.Add(licCollection(i))
            Next
            SubSaveSelectItem()
        End Sub

        Private Sub bttAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttAddAll.Click
            Dim i As Integer
            For i = 0 To lstLink.Items.Count - 1
                lstLinkSelected.Items.Add(lstLink.Items(i))
            Next
            lstLink.Items.Clear()
            SubSaveSelectItem()
        End Sub

        Private Sub bttDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttDeleteAll.Click
            Dim i As Integer
            For i = 0 To lstLinkSelected.Items.Count - 1
                lstLink.Items.Add(lstLinkSelected.Items(i))
            Next
            lstLinkSelected.Items.Clear()
            SubSaveSelectItem()
        End Sub

        Private Sub bttSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttSelect.Click
            SubSaveSelectItem()
            Page.RegisterClientScriptBlock("SaveAndClose", "<script language='javascript'>parent.close();</script>")
        End Sub
        Private Sub SubSaveSelectItem()
            Dim strTemp As String
            Dim arrTemp() As String
            Dim i As Integer
            If lstLinkSelected.Items.Count = 0 Then
                strTemp = ""
                ReDim arrTemp(-1)
            Else
                ReDim arrTemp(lstLinkSelected.Items.Count - 1)
                For i = 0 To lstLinkSelected.Items.Count - 1
                    strTemp = strTemp & lstLinkSelected.Items(i).Value & ","
                    arrTemp(i) = lstLinkSelected.Items(i).Value
                Next
                strTemp = Left(strTemp, strTemp.Length - 1)
            End If
            If intType = 0 Then
                Session("ItemLinkID") = strTemp
            End If
            If intType = 1 Then
                Session("arrFile") = arrTemp
            End If
        End Sub
        '
        ' Name: GetFolderFile
        ' Purpose: get all file asp to arrlist
        ' Input: Root,_path, 
        ' Output: arrURL
        ' Creator: thaott
        ' Created Date: 30/Aug/2006
        ' Modification History: 
        Public Sub GetFolderFile(ByVal Root As String, ByVal _path As String, ByRef arrURL() As String)
            ' bo qua phan tu dau tinh tu phan tu 1
            If arrURL Is Nothing Then ReDim arrURL(0)
            Dim i As Integer
            Dim lblTemp As String
            Dim objDirInfo As DirectoryInfo = New DirectoryInfo(Root & "\" & _path)
            Dim arrChildFiles As Array = objDirInfo.GetFiles()
            Dim arrSubFolders As Array = objDirInfo.GetDirectories()
            Dim objChildFile As FileInfo
            Dim objChildFolder As DirectoryInfo
            objDirInfo.Create()
            'first loop through the files and add the size of each file 
            For Each objChildFile In arrChildFiles
                i = arrURL.Length
                lblTemp = objChildFile.Name
                If UCase(lblTemp.Split(".")(lblTemp.Split(".").Length - 1)) = "ASPX" Then
                    ReDim Preserve arrURL(arrURL.Length)
                    arrURL(i) = _path & "\" & objChildFile.Name
                End If
            Next
            'then for each subfolder found call this function again  
            For Each objChildFolder In arrSubFolders
                lblTemp = objChildFolder.Name
                GetFolderFile(Root, _path & "\" & objChildFolder.Name, arrURL)
            Next
        End Sub
    End Class
End Namespace

