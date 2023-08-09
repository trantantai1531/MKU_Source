Imports ComponentArt.Web.UI
Imports System.Data
Imports System.IO
Imports System.IO.Path
Imports eMicLibAdmin.WebUI.Common
Imports eMicLibAdmin.BusinessRules.Serial
Imports eMicLibAdmin.BusinessRules.Acquisition

Namespace eMicLibAdmin.WebUI.Serial
    Partial Class Pages_AcqMagRegisterNumber
        Inherits clsWBase

        Private objBLibrary As New clsBLibrary
        Private objBMagazine As New clsBMagazine
        Protected _rootFolder As String = ""

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Initialize()
            Call BindScript()
            Call ChangeLanguageTaptrip()
            If Not IsPostBack AndAlso Not UploadFiles.CausedCallback Then
                Call initValues()
                If Not Request("add") Is Nothing AndAlso Request("add") <> "" Then
                    hidAddNew.Value = Request("add")
                End If
                If Not Request("docID") Is Nothing AndAlso Request("docID") <> "" Then
                    hidDocId.Value = Request("docID")
                End If
                If Not Request("MagId") Is Nothing AndAlso Request("MagId") <> "" Then
                    hidMagId.Value = Request("MagId")
                End If
                Call InitControls(hidMagId.Value, hidAddNew.Value)
            End If
            Call initTreeViewInputAcquisition(Me.getPhysicalPath) ' clsCommon._rootsavefile)
        End Sub

        ' BindScript method
        Private Sub BindScript()
            ' Page.RegisterClientScriptBlock("CommonJs", "<script language = 'javascript' src = '../Common/eMicLibCommon.js?t=" & String.Format("{0}", Date.Now.Ticks) & "'></script>")
        End Sub

        ' Initialize method
        ' Purpose: init all necessary objects
        Private Sub Initialize()

            ' Init for objBPeriodicalCollection
            objBMagazine.InterfaceLanguage = Session("InterfaceLanguage")
            objBMagazine.DBServer = Session("DBServer")
            objBMagazine.ConnectionString = Session("ConnectionString")
            objBMagazine.Initialize()

            ' Init objBLibrary object
            objBLibrary.DBServer = Session("DBServer")
            objBLibrary.ConnectionString = Session("ConnectionString")
            objBLibrary.InterfaceLanguage = Session("InterfaceLanguage")
            objBLibrary.Initialize()
        End Sub

        Private Sub initValues()
            Try
                indYear.Value = Now.Year
                indYear.MinValue = 1900
                indYear.MaxValue = 2100

                indMonth.Value = Now.Month
                indMonth.MinValue = 1
                indMonth.MaxValue = 12

                indDay.Value = Now.Day
                indDay.MinValue = 1
                indDay.MaxValue = 31

                txtNumber.Text = ""
            Catch ex As Exception
            End Try
        End Sub

        Private Sub LoadFileIds()
            Try
                Dim FileIds As String = ""
                If Not Request("FileIds") Is Nothing AndAlso Request("FileIds") = "1" Then
                    Call DisplayUploadFields()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Function CheckValid() As Integer
            Dim _intValid As Integer = 0
            Try
                If txtNumber.Text.Trim = "" Then
                    _intValid = 1
                    Return _intValid
                End If
                If Session("uploadFilesMagazine") Is Nothing Then
                    _intValid = 2
                    Return _intValid
                End If
                Dim strOldNum As String = hidOldNum.Value
                If strOldNum.Trim <> "" AndAlso strOldNum.Trim.ToLower <> txtNumber.Text.Trim.ToLower Then
                    Dim tblItem As New DataTable
                    Dim eYear As Integer = indYear.Value
                    Dim strEnum As String = txtNumber.Text.Trim
                    With objBMagazine
                        .eYear = eYear
                        .eNumMag = strEnum
                        tblItem = .getMagazineByMagNo(strOldNum)
                    End With
                    Dim bolCheckDup As Boolean = False
                    If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                        If tblItem.Rows(0).Item(0) > 0 Then
                            bolCheckDup = True
                        End If
                    End If
                    If bolCheckDup Then
                        _intValid = 3
                        Return _intValid
                    End If
                End If
            Catch ex As Exception : End Try
            Return _intValid
        End Function


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

        Private Sub ChangeLanguageTaptrip()
            If Not Session("Language") Is Nothing AndAlso Session("Language") = "vie" Then
                TabStripInputAcquisition.SiteMapXmlFile = "../../Resources/Skin/arcticwhite/Tabstrip/AcqMagRegisterNumber_vie.xml"
                TabStripInputAcquisition.ImagesBaseUrl = "../../Resources/Skin/arcticwhite/Tabstrip/images/InputAcquisition/"
            Else
                TabStripInputAcquisition.SiteMapXmlFile = "../../Resources/Skin/arcticwhite/Tabstrip/AcqMagRegisterNumber_eng.xml"
                TabStripInputAcquisition.ImagesBaseUrl = "../../Resources/Skin/arcticwhite/Tabstrip/images/InputAcquisition/"
            End If
            lblSavefile.Text = span_save_file.InnerText
            MenuInputAcquisition.Items(0).Text = span_Menu_item1.InnerText
            MenuInputAcquisition.Items(1).Text = span_Menu_item2.InnerText
            MenuInputAcquisition.Items(2).Text = span_Menu_item3.InnerText
        End Sub

        'Init for treeview for InputAcquisition
        Private Sub initTreeViewInputAcquisition(ByVal rootFolder As String)
            TreeViewInputAcquisition.Nodes.Clear()
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
                    rootNode.Text = span_treeview_root.InnerText & " (" & _rootFolder & ")"
                    rootNode.ImageUrl = "folder-remote.png"
                    rootNode.Expanded = True
                    rootNode.ID = rootFolder.Replace("\\", _rootFolder)
                    TreeViewInputAcquisition.Nodes.Add(rootNode)
                    BuildTreeDirectory(rootFolder, rootNode)
                End If
            Next
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
        Protected Sub raiseAddRecord_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseAddRecord.Click
            Select Case CheckValid()
                Case 0
                    Dim bolResult As Boolean = False
                    Dim userName As String = clsSession.GlbUser
                    If hidAddNew.Value <> 1 Then
                        bolResult = UpdateRecord(userName)
                    Else
                        bolResult = InsertRecord(userName)
                    End If
                    If bolResult Then
                        Call callbackParent(hidDocId.Value, span_info.InnerText, span_addnew.InnerText, 6)
                    Else
                        Call DisplayInfo(span_info.InnerText, span_error.InnerText, 5)
                    End If
                Case 1
                    Call DisplayInfo(span_info.InnerText, span_addnew_invalid1.InnerText, 5)
                    MultiPageInputAcquisition.SelectedIndex = 0
                Case 2
                    Call DisplayInfo(span_info.InnerText, span_addnew_invalid3.InnerText, 5)
                    MultiPageInputAcquisition.SelectedIndex = 1
                Case 3
                    Call DisplayInfo(span_info.InnerText, span_addnew_invalid4.InnerText, 5)
            End Select
        End Sub

        'Display information to be updated
        Public Sub DisplayInfo(ByVal title As String, ByVal info As String, ByVal icon As Integer)
            Dim _strInfo As String = ""
            _strInfo = "top.showDialogInfo('',true," & icon & ",'" & title & "','" & info & "');"
            clsWCommon.MyMsgBoxInfor(_strInfo, Me.Page)
        End Sub

        ''Display information to be updated
        Public Sub callbackParent(ByVal docId As Integer, ByVal title As String, ByVal info As String, ByVal icon As Integer)
            Dim _strInfo As String = ""
            _strInfo = "callbackParent(" & docId & ",'" & title & "','" & info & "'," & icon & ");"
            clsWCommon.MyMsgBoxInfor(_strInfo, Me.Page)
        End Sub

        'Insert a new record into database
        Private Function InsertRecord(ByVal userName As String) As Boolean
            Dim bolResult As Boolean = False
            Try
                'Dim insertDocMagazine As New BusinessLayer.Acquisition
                Dim eYear As Integer = indYear.Value
                Dim eMonth As Integer = indMonth.Value
                Dim eDay As Integer = indDay.Value
                Dim strEnum As String = txtNumber.Text.Trim
                Dim Description As String = txtDecription.Text.Trim
                Dim docId As Integer = hidDocId.Value
                Dim intInsertMagId As Integer = 0 ' insertDocMagazine.Insert_magazine_number(userName, docId, eYear, eMonth, eDay, strEnum, Description)
                'insertDocMagazine = Nothing
                With objBMagazine
                    .eYear = eYear
                    .eMonth = eMonth
                    .eDay = eDay
                    .ItemID = docId
                    .Description = Description
                    .eNumMag = strEnum
                    .userName = userName
                    intInsertMagId = .insertMagazineNo()
                End With

                If intInsertMagId > 0 Then
                    Call InsertFilesUpload(intInsertMagId)
                    bolResult = True

                    'Dim clsLog As New BusinessLayer.Log
                    'clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsCommon.gModule.mPhanHeBienMuc, 1, clsCommon.gModule.mBienMucMucLuc, clsCommon.getTextLog(Common.FDataType.ACTION_AccessPage._NewNumber, Session("Language")) & ": Magazine id - " & intInsertMagId.ToString, Request.ServerVariables("REMOTE_ADDR"))
                End If
            Catch ex As Exception : End Try
            Return bolResult
        End Function




        'Update the record 
        Private Function UpdateRecord(ByVal username As String) As Boolean
            Dim bolResult As Boolean = False
            Try
                Dim magId As Integer = hidMagId.Value

                'Dim updateDocMagazine As New BusinessLayer.Acquisition
                Dim eYear As Integer = indYear.Value
                Dim eMonth As Integer = indMonth.Value
                Dim eDay As Integer = indDay.Value
                Dim strEnum As String = txtNumber.Text.Trim
                Dim Description As String = txtDecription.Text.Trim
                Dim bolUpdateMagNum As Boolean = False ' updateDocMagazine.update_magazine_number(username, magId, eYear, eMonth, eDay, strEnum, Description)
                'updateDocMagazine = Nothing

                With objBMagazine
                    .MagId = magId
                    .eYear = eYear
                    .eMonth = eMonth
                    .eDay = eDay
                    .Description = Description
                    .eNumMag = strEnum
                    .userNameUpdate = username
                    bolUpdateMagNum = .updateMagazineNo()
                End With
                If bolUpdateMagNum Then
                    Call InsertFilesUpload(magId, 1)

                    bolResult = True
                    'Dim clsLog As New BusinessLayer.Log
                    'clsLog.INSERT_SYS_LOG(Session("UserFullName"), clsCommon.gModule.mPhanHeBienMuc, 1, clsCommon.gModule.mBienMucMucLuc, clsCommon.getTextLog(Common.FDataType.ACTION_AccessPage._Update, Session("Language")) & ": Magazine id - " & magId.ToString, Request.ServerVariables("REMOTE_ADDR"))
                End If
            Catch ex As Exception : End Try
            Return bolResult
        End Function


        Private Sub InsertFilesUpload(ByVal MagId As Integer, Optional ByVal intUpdate As Integer = 0)
            If Not Session("uploadFilesMagazine") Is Nothing Then
                Dim _icountArr As Integer = UBound(Session("uploadFilesMagazine"), 2)
                Dim intFileType As Integer = 0
                Dim bolCoverImage As Boolean = False
                Dim bolCoverImageMedia As Boolean = False
                Dim _intInsert As Integer = 0
                Dim intPageNum As Integer = 1
                Try
                    If intUpdate > 0 AndAlso Not IsNothing(Session("CountUploadFilesMagazine")) Then
                        intPageNum += CInt(Session("CountUploadFilesMagazine"))
                    End If
                Catch ex As Exception
                End Try
                For _icount As Integer = _icountArr To 0 Step -1
                    If System.IO.File.Exists(System.IO.Path.Combine(Session("uploadFilesMagazine")(0, _icount), Session("uploadFilesMagazine")(1, _icount))) Then
                        Dim _fileInfo As New System.IO.FileInfo(System.IO.Path.Combine(Session("uploadFilesMagazine")(0, _icount), Session("uploadFilesMagazine")(1, _icount)))

                        With objBMagazine
                            .MagId = MagId
                            .FileName = _fileInfo.Name
                            .Status = 0
                            .DownloadTimes = 0
                            .FileSize = _fileInfo.Length
                            .Path = _fileInfo.FullName
                            .PageNum = intPageNum
                            _intInsert = .updateMagazineDetai(intUpdate)
                        End With
                        'Dim _insertFilesUpload As New BusinessLayer.Acquisition
                        '_intInsert = _insertFilesUpload.Insert_Files_magazine_number(MagId, 0, _fileInfo.Name, _fileInfo.Length, _fileInfo.FullName, Now.Date, intPageNum, _bolupdate)
                        intPageNum += 1
                        '_insertFilesUpload = Nothing
                    End If
                    Session("folderPathMagazine") = Session("uploadFilesMagazine")(0, _icount)
                Next
            End If
        End Sub

        Private Sub InitControls(Optional ByVal requestMagId As Integer = 0, Optional ByVal addNew As Integer = 0)
            Try
                Call initTreeViewInputAcquisition(Me.getPhysicalPath) ' clsCommon._rootsavefile)
                Call initTempUploadDirectory()
                Call initUploadFields()
                If addNew = 0 Then
                    Dim bolloadRecord As Boolean = LoadRecord(requestMagId)
                    If bolloadRecord Then
                        Call DisplayUploadFields()
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub


        Protected Sub raiseRemoveFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseRemoveFile.Click
            Try
                MultiPageInputAcquisition.SelectedIndex = 1
                Dim _id As Integer = hidRemovefileID.Value
                If _id > -1 Then
                    Call RemoveSession(_id)
                End If
                Call DisplayUploadFields()
            Catch ex As Exception : End Try
        End Sub

        Protected Sub raiseDisplayUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles raiseDisplayUpload.Click
            Try
                MultiPageInputAcquisition.SelectedIndex = 1
                Call DisplayUploadFields()
            Catch ex As Exception : End Try
        End Sub


        Private Function LoadRecord(Optional ByVal requestMagId As Integer = 0) As Boolean
            Dim _bol As Boolean = False
            Try
                Dim tblItem As New DataTable
                With objBMagazine
                    .MagId = requestMagId
                    tblItem = .getMagazineByMagID()
                End With

                If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                    For i As Integer = 0 To tblItem.Rows.Count - 1
                        indYear.Value = CInt(tblItem.Rows(i).Item("eYear"))
                        indMonth.Value = CInt(tblItem.Rows(i).Item("eMonth"))
                        indDay.Value = CInt(tblItem.Rows(i).Item("eDay"))
                        txtNumber.Text = CInt(tblItem.Rows(i).Item("eNum"))
                        hidOldNum.Value = CInt(tblItem.Rows(i).Item("eNum"))
                        txtDecription.Text = ""
                        If Not IsDBNull(tblItem.Rows(i).Item("Description")) Then
                            txtDecription.Text = tblItem.Rows(i).Item("Description")
                        End If
                    Next
                    With objBMagazine
                        .MagId = requestMagId
                        tblItem = .getMagazineDetailByMagID()
                    End With
                    If Not IsNothing(tblItem) AndAlso tblItem.Rows.Count > 0 Then
                        Session("CountUploadFilesMagazine") = tblItem.Rows.Count
                        For i As Integer = 0 To tblItem.Rows.Count - 1
                            If Session("uploadFilesMagazine") Is Nothing Then
                                ReDim Preserve Session("uploadFilesMagazine")(2, 0)
                                Session("uploadFilesMagazine")(0, 0) = tblItem.Rows(i).Item("Path").ToString.Substring(0, tblItem.Rows(i).Item("Path").ToString.LastIndexOf("\"))
                                Session("uploadFilesMagazine")(1, 0) = tblItem.Rows(i).Item("FileName").ToString
                                Session("uploadFilesMagazine")(2, 0) = tblItem.Rows(i).Item("Path").ToString
                            Else
                                Dim _icountArr As Integer = UBound(Session("uploadFilesMagazine"), 2) + 1
                                ReDim Preserve Session("uploadFilesMagazine")(2, _icountArr)
                                Session("uploadFilesMagazine")(0, _icountArr) = tblItem.Rows(i).Item("Path").ToString.Substring(0, tblItem.Rows(i).Item("Path").ToString.LastIndexOf("\"))
                                Session("uploadFilesMagazine")(1, _icountArr) = tblItem.Rows(i).Item("FileName").ToString
                                Session("uploadFilesMagazine")(2, _icountArr) = tblItem.Rows(i).Item("Path").ToString
                            End If
                        Next
                    End If
                    _bol = True
                End If
            Catch ex As Exception : End Try
            Return _bol
        End Function

        Private Sub initTempUploadDirectory()
            UpLoadFiles.TempFileFolder = Server.MapPath("~/Upload")
        End Sub


        Private Sub initUploadFields()
            If Not IsNothing(Session("ResetUploadFilesMagazine")) AndAlso Session("ResetUploadFilesMagazine") = True Then
                Session("uploadFilesMagazine") = Nothing
                Session("CountUploadFilesMagazine") = Nothing
                litinfoUpload.Text = ""
            End If
            Session("ResetUploadFilesMagazine") = True
            'clsCommon._ResetUploadFiles = True
        End Sub

        Private Sub DisplayUploadFields(Optional ByVal strCoverImage As String = "")
            Try
                If Not Session("uploadFilesMagazine") Is Nothing Then
                    Dim _icountArr As Integer = UBound(Session("uploadFilesMagazine"), 2)
                    Dim _strUploadFiles As String = ""
                    _strUploadFiles = "<table cellpadding='1' cellspacing='1' border='0' width='100%'>"
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
                        If Session("uploadFilesMagazine")(1, _icount).Length > 0 Then
                            _strGetIcon = clsWCommon.GetImage(Session("uploadFilesMagazine")(1, _icount))
                        Else
                            _strGetIcon = ""
                        End If

                        _Img = "<img src='" & "../../Resources/Skin/arcticwhite/FileType/" & _strGetIcon & "' height='16' width='32' border='0'/>"

                        _strUploadFiles &= "<td valign='top'  width='3%'>"
                        _strUploadFiles &= _Img
                        _strUploadFiles &= "</td>"
                        _strUploadFiles &= "<td valign='top'  width='80%'>"
                        _strUploadFiles &= "<b><i>" & Session("uploadFilesMagazine")(1, _icount) & "</i></b>" & " (" & Session("uploadFilesMagazine")(0, _icount) & ")"
                        If Session("uploadFilesMagazine")(2, _icount).ToString = "" Then
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

        Protected Sub UploadFiles_Uploaded(ByVal sender As Object, ByVal e As ComponentArt.Web.UI.UploadUploadedEventArgs) Handles UploadFiles.Uploaded
            Try
                Dim fileName As String = ""
                For Each oInfo In e.UploadedFiles
                    If oInfo.FileName.ToString.Trim <> "" Then
                        fileName = clsWCommon.ChangeFileName(oInfo.FileName)
                        If Directory.Exists(UpLoadFiles.CallbackParameter) Then
                            oInfo.SaveAs(Path.Combine(UpLoadFiles.CallbackParameter, fileName), True)
                            If Session("uploadFilesMagazine") Is Nothing Then
                                ReDim Preserve Session("uploadFilesMagazine")(2, 0)
                                Session("uploadFilesMagazine")(0, 0) = UpLoadFiles.CallbackParameter
                                Session("uploadFilesMagazine")(1, 0) = fileName
                                Session("uploadFilesMagazine")(2, 0) = ""
                            Else
                                Dim _icountArr As Integer = UBound(Session("uploadFilesMagazine"), 2) + 1
                                ReDim Preserve Session("uploadFilesMagazine")(2, _icountArr)
                                Session("uploadFilesMagazine")(0, _icountArr) = UpLoadFiles.CallbackParameter
                                Session("uploadFilesMagazine")(1, _icountArr) = fileName
                                Session("uploadFilesMagazine")(2, _icountArr) = ""
                            End If
                        Else
                            Call DisplayInfo(span_info.InnerText, span_addnew_invalid2.InnerText, 5)
                            Exit For
                        End If
                    End If
                Next
                UpLoadFiles.Dispose()
            Catch ex As Exception : End Try
        End Sub

        Public Sub RemoveSession(ByVal _item As Integer)
            Try
                If Not Session("uploadFilesMagazine") Is Nothing Then
                    Dim _iUbound As Integer = UBound(Session("uploadFilesMagazine"), 2) - 1
                    Dim _fileremovePath As String = IIf(Session("uploadFilesMagazine")(0, _item).ToString.Last = "\", Session("uploadFilesMagazine")(0, _item), Session("uploadFilesMagazine")(0, _item) & "\") & Session("uploadFilesMagazine")(1, _item)
                    For _icount As Integer = _item To _iUbound
                        Session("uploadFilesMagazine")(0, _icount) = Session("uploadFilesMagazine")(0, _icount + 1)
                        Session("uploadFilesMagazine")(1, _icount) = Session("uploadFilesMagazine")(1, _icount + 1)
                        Session("uploadFilesMagazine")(2, _icount) = Session("uploadFilesMagazine")(2, _icount + 1)
                    Next
                    If _iUbound > -1 Then
                        ReDim Preserve Session("uploadFilesMagazine")(2, _iUbound)
                    Else
                        Session("uploadFilesMagazine") = Nothing
                    End If
                    If File.Exists(_fileremovePath) Then
                        File.Delete(_fileremovePath)
                    End If
                End If
            Catch ex As Exception : End Try
        End Sub


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
    End Class
End Namespace

