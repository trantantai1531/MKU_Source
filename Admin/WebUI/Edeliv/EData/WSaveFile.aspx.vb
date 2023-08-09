Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports eMicLibAdmin.WebUI.Edeliv
Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Admin
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibLogin
Namespace eMicLibAdmin.WebUI.Edeliv
    Partial Class WSaveFile
        Inherits System.Web.UI.Page
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

        Private objBUser As New clsBUser
        Private objBCDBS As New clsBCommonDBSystem
        Private objBEData As New clsBEData
        Private objBCSP As New clsBCommonStringProc

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            Call Upload()
        End Sub
        Private Sub AlertMsg(ByVal strMsg As String, Optional ByVal strMsgID As String = "")
            Page.RegisterClientScriptBlock("AlertJS" & strMsgID, "<script language='javascript'> alert('" & strMsg & "');  </script>")
        End Sub
        Private Sub Initialize()
            ' Init objBUser object
            objBUser.ConnectionString = Session("ConnectionString")
            objBUser.DBServer = Session("DBServer")
            objBUser.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBUser.Initialize()
            ' Init objBCDBS object
            objBCDBS.ConnectionString = Session("ConnectionString")
            objBCDBS.DBServer = Session("DBServer")
            objBCDBS.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCDBS.Initialize()
            ' Init objBEData object
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.DBServer = Session("DBServer")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBEData.Initialize()
            ' Init objBCSP object
            objBCSP.ConnectionString = Session("ConnectionString")
            objBCSP.DBServer = Session("DBServer")
            objBCSP.InterfaceLanguage = Session("InterfaceLanguage")
            Call objBCSP.Initialize()
        End Sub

        ' Upload method
        ' Pupose: Upload file from client to server
        ' In: FileLocation, FileName
        Private Sub Upload()
            'Dim objUpLoad As Object
            Dim objUpLoad As aspSmartUpload.SmartUpload
            Dim objBase21 As New BASP21Lib.Basp21
            Dim tblAuth As New DataTable
            Dim tblEData As New DataTable
            Dim realm, sep, UserName, PassWord, FileToSave, Extension, strFileLocation, strFileName, strDBID, strDBSever, strConnectringString, strInterfaceLanguage As String
            Dim intID, intMediaType As Integer
            Dim FileSize As Long
            Dim arrBasic() As String
            Try
                'objUpLoad = New aspSmartUpload.SmartUpload
                objUpLoad = Server.CreateObject("aspSmartUpload.SmartUpload")
                objUpLoad.Upload()

                If Not objUpLoad.Files("Content").FileName = "" And Not objUpLoad.Files("Content").IsMissing Then
                    realm = objUpLoad.Form("auth").Values
                    If InStr(LCase(realm), "basic ") = 1 Then
                        realm = objBase21.Base64(Right(realm, Len(realm) - 6), 1)
                        arrBasic = Split(realm, Chr(9))
                        ' Get UserName
                        UserName = arrBasic(0)
                        ' Get Password
                        PassWord = arrBasic(1)
                        ' Get DataBase ID
                        strDBID = arrBasic(2)
                        ' Depend on Database ID will parse ConnectiongString, DBServer... from file WLoginDB.xml
                        ResetSession(CInt(strDBID))
                        ' Initialize method
                        Call Initialize()
                        ' Process here
                        objBUser.UserName = Replace(UserName, "'", "")
                        objBUser.UserPass = Replace(PassWord, "'", "")
                        tblAuth = objBUser.GetUserLogin
                        If Not tblAuth Is Nothing AndAlso tblAuth.Rows.Count > 0 Then ' Correct user--> upload
                            If Session("DBServer") = "SQLSERVER" Then
                                objBCDBS.SQLStatement = "SELECT ID FROM Cat_tblEdataFile WHERE URL='" & objUpLoad.Form("fileloc").Values & "' AND(Locked=0 OR LockedBy='" & UserName & "' OR (DATEDIFF(DAY,LockedDate,GETDATE())>=1 AND Locked=1))"
                            Else
                                objBCDBS.SQLStatement = "SELECT ID FROM Cat_tblEdataFile WHERE URL='" & objUpLoad.Form("fileloc").Values & "' AND(Locked=0 OR LockedBy='" & UserName & "' OR (SYSDATE-LockedDate >=1 AND Locked=1))"
                            End If
                            tblEData = objBCDBS.RetrieveItemInfor
                            If Not tblEData Is Nothing AndAlso tblEData.Rows.Count > 0 Then
                                intID = tblEData.Rows(0).Item("ID")
                                If InStr(objUpLoad.Form("fileloc").Values, ":\") = 0 Then
                                    FileToSave = Server.MapPath(objUpLoad.Form("fileloc").Values)
                                Else
                                    FileToSave = objUpLoad.Form("fileloc").Values
                                End If
                                Page.RegisterClientScriptBlock("lak2fsd", "<script language='javascript'>alert('" & FileToSave & "');</script>")
                                Extension = LCase(Right(FileToSave, Len(FileToSave) - InStrRev(FileToSave, ".")))
                                FileSize = objUpLoad.Files("Content").Size
                                ' Upload file to server
                                objUpLoad.Files.Item("Content").SaveAs(FileToSave)
                                objBCDBS.SQLStatement = "UPDATE Cat_tblEdataFile SET Locked=0, LockedBy='', LockedDate=NULL, LastModifiedBy='" & UserName & "', ModifiedTimes=ModifiedTimes + 1, MaxSize=" & FileSize & " WHERE ID=" & intID
                                objBCDBS.ProcessItem()
                                objBCDBS.SQLStatement = "DELETE FROM Cat_tblEdataFile WHERE ID=" & intID
                                objBCDBS.ProcessItem()
                                strFileLocation = Left(FileToSave, InStrRev(FileToSave, "\"))
                                strFileName = Right(FileToSave, Len(FileToSave) - InStrRev(FileToSave, "\"))
                                Call ImportEData(strFileLocation, strFileName)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                AlertMsg(ex.Message)
            End Try

            objUpLoad = Nothing
            objBase21 = Nothing
        End Sub

        ' Method: ResetSession
        Private Sub ResetSession(Optional ByVal intDBID As Integer = 0)
            Dim objeMicLibLogin As New eMicLibLogin.clseMicLibLogin
            Session("ConnectionString") = objeMicLibLogin.GetConnectionString(intDBID)
            Session("DBServer") = objeMicLibLogin.DBServer
            objeMicLibLogin = Nothing
        End Sub

        Public Sub ImportEData(ByVal strLocation As String, ByVal strFile As String)
            Try
                ' Get MediaType
                objBEData.MediaType = GetFileMediaType(Replace(strLocation & "\", "\\", "\") & strFile)
                Call ImportFile(strLocation, strFile, objBEData.MediaType)
            Catch ex As Exception
            End Try
        End Sub

        ' GetFileMediaType method
        ' Purpose: Get media file type by inputting full file name
        Public Function GetFileMediaType(ByVal strFilePath As String) As Integer
            Dim intMediaType As Integer
            Dim strExtension As String

            strExtension = LCase(Right(strFilePath, Len(strFilePath) - InStrRev(strFilePath, ".")))
            Try
                Select Case strExtension
                    Case "bmp", "gif", "jpg", "jpeg", "tif", "pcx", "png", "jpe"
                        intMediaType = 1
                    Case "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf"
                        intMediaType = 2
                    Case "mp3", "wav"
                        intMediaType = 3
                    Case "doc", "pdf", "ps", "html", "htm", "rtf", "txt", "ppt", "pps", "xls"
                        intMediaType = 4
                    Case "exe"
                        intMediaType = 6
                    Case Else
                        intMediaType = 7
                End Select
            Catch ex As Exception
            Finally
                GetFileMediaType = intMediaType
            End Try

        End Function

        Public Sub ImportFile(ByVal strLocation As String, ByVal strFileName As String, ByVal intMediaType As Integer)
            ' Declare variables
            Dim tblFile As DataTable
            Dim objFileInfor As FileInfo
            Dim strFilePath As String = ""
            Dim lngFileSize As Long = 0
            Dim lngID As Long
            Dim strExtension As String
            Dim strBipmapType As String
            Dim strColorModel As String
            Dim strTitle As String = ""
            Dim strAuthor As String = ""
            Dim strDescription As String = ""
            Dim intWidth As Integer
            Dim intHeight As Integer
            Dim shtXdpi As Short
            Dim shtYdpi As Short
            Dim dblDuration As Double
            Dim intNoColorUsed As Long
            Dim intPageCount As Integer
            Dim strAlbum As String
            Dim strArtist As String
            Dim strComment As String
            Dim strGenre As String
            Dim intBitRate As Integer

            Try
                ' Get existed file infor in database

                strFilePath = Replace(strLocation & "\", "\\", "\") & strFileName
                objFileInfor = New FileInfo(strFilePath)
                If objFileInfor.Exists Then
                    lngFileSize = objFileInfor.Length
                    objBEData.InitVariablesForEdataFile()

                    objBEData.Param = strFilePath
                    tblFile = objBEData.GetGeneralInfor(5, 0, 0, 0, 3)

                    objBEData.FileName = strFileName
                    objBEData.PhysicalPath = Replace(strLocation & "\", "\\", "\") & strFileName
                    objBEData.URL = Replace(strLocation & "\", "\\", "\") & strFileName
                    objBEData.FileLocation = strLocation
                    objBEData.FileSize = lngFileSize
                    objBEData.UploadedBy = clsSession.GlbUserFullName
                    objBEData.FileFormat = Right(strFileName, Len(strFileName) - InStrRev(strFileName, "."))

                    If Right(Trim(strLocation), 1) = "\" Then
                        strLocation = Left(Trim(strLocation), Len(Trim(strLocation)) - 1)
                    End If

                    objBEData.FileLocation = strLocation
                    objBEData.MediaType = intMediaType

                    ' insert to edata file table
                    If Not tblFile Is Nothing Then
                        If tblFile.Rows.Count > 0 Then
                            lngID = tblFile.Rows(0).Item("ID")
                            objBEData.FileID = lngID
                            objBEData.FileIDs = CStr(lngID)
                            objBEData.UpdateFileRecord()
                            objBEData.GeneralDelete(3, 0, 0, "", "", "", "", "")
                        Else
                            objBEData.CreateFileRecord()
                            lngID = objBEData.FileID
                        End If
                    Else
                        objBEData.CreateFileRecord()
                        lngID = objBEData.FileID
                    End If

                    objBEData.InitVariablesForMultimedia()
                    ' Get the phisical infor of file
                    Call GetFileInfor(strFilePath, strBipmapType, strColorModel, intWidth, intHeight, shtXdpi, shtYdpi, intNoColorUsed, dblDuration, strAlbum, strArtist, strComment, strGenre, intPageCount, strTitle, strAuthor, strDescription, intBitRate)
                    Select Case intMediaType
                        Case 1 ' "bmp", "gif", "jpg", "jpeg", "tif", "pcx", "png", "jpe"
                            objBEData.BitmapType = CInt(strBipmapType)
                            objBEData.ColorModel = strColorModel
                            objBEData.ImgWidth = intWidth
                            objBEData.ImgHeight = intHeight
                            objBEData.Xdpi = shtXdpi
                            objBEData.Ydpi = shtYdpi
                            objBEData.NoColorUsed = intNoColorUsed
                        Case 2 ' "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf"
                            objBEData.ImgWidth = intWidth
                            objBEData.ImgHeight = intHeight
                            objBEData.Duration = dblDuration
                        Case 3 ' "mp3", "wav"
                            If Not Trim(strTitle) = "" Or Not Trim(strDescription) = "" Or Not Trim(strAuthor) = "" Then
                                objBEData.InitVariablesForEdataFile()
                                objBEData.FileID = lngID
                                objBEData.Title = strTitle
                                objBEData.Description = strDescription
                                objBEData.Author = strAuthor
                                objBEData.UpdateFileRecord()
                            End If
                            objBEData.Duration = dblDuration
                            objBEData.Album = strAlbum
                            objBEData.Artist = strArtist
                            objBEData.BitRate = intBitRate
                            objBEData.Genre = strGenre
                        Case 4 ' "doc", "pdf", "ps", "html", "htm", "rtf", "txt", "ppt", "pps", "xls"
                            If Not Trim(strTitle) = "" Or Not Trim(strDescription) = "" Or Not Trim(strAuthor) = "" Then
                                objBEData.InitVariablesForEdataFile()
                                objBEData.FileIDs = CStr(lngID)
                                objBEData.Title = strTitle
                                objBEData.Description = strDescription
                                objBEData.Author = strAuthor
                                objBEData.UpdateFileRecord()
                            End If
                            objBEData.PageCount = intPageCount
                            objBEData.Pagination = CStr(intPageCount)
                    End Select
                    ' Create new multimedia record of file
                    objBEData.FileID = lngID
                    objBEData.CreateMultimedia()
                End If
            Catch ex As Exception
            End Try
        End Sub

        Public Sub GetFileInfor(ByVal strFilePath As String, ByRef strBipmapType As String, ByRef strColorModel As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef shtXdpi As Short, ByRef shtYdpi As Short, ByRef intNoColorUsed As Long, ByRef dblDuration As Double, ByRef strAlbum As String, ByRef strArtist As String, ByRef strComment As String, ByRef strGenre As String, ByRef intPageCount As Integer, ByRef strTitle As String, ByRef strAuthor As String, ByRef strDescription As String, ByRef intBitRate As Integer)
            Dim strFileExtension As String
            strFileExtension = LCase(Right(strFilePath, Len(strFilePath) - InStrRev(strFilePath, ".")))
            Try
                Select Case strFileExtension
                    Case "bmp", "gif", "jpg", "jpeg", "tif", "pcx", "png", "jpe"
                        Call GetImageInfor(strFilePath, strBipmapType, strColorModel, intWidth, intHeight, shtXdpi, shtYdpi, intNoColorUsed)
                    Case "mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf"
                        Call GetMediaInfor(strFilePath, intWidth, intHeight, dblDuration)
                    Case "mp3", "wav"
                        Call GetSoundInfor(strFilePath, strAlbum, strArtist, dblDuration, strComment, strGenre, intBitRate)
                    Case "pdf"
                        Call GetPdfInfor(strFilePath, intPageCount)
                    Case "doc", "xsl", "ppt", "pps"
                        Call GetDocInfor(strFilePath, strTitle, strAuthor, strDescription, intPageCount)
                    Case "exe"
                    Case Else
                End Select
            Catch ex As Exception

            End Try
        End Sub

        Public Sub GetImageInfor(ByVal strFilePath As String, ByRef strBipmapType As String, ByRef strColorModel As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef shtXdpi As Short, ByRef shtYdpi As Short, ByRef intNoColorUsed As Long)
            Dim objImg As New GflAx193.GflAxClass
            Try
                ' Get the image infor
                With objImg
                    .EnableLZW = True
                    .LoadBitmap(strFilePath)
                    strBipmapType = CStr(.BitmapType)
                    strColorModel = .ColorModel
                    intWidth = .Width
                    intHeight = .Height
                    shtXdpi = .Xdpi
                    shtYdpi = .Ydpi
                    intNoColorUsed = .NumberOfColorsUsed
                End With
            Catch ex As Exception
            End Try
        End Sub

        Public Sub GetMediaInfor(ByVal strFilePath As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef dblDuration As Double)
            Dim objInfoRetriever As New MEDIAPROCESSORLib.InfoRetrieverClass
            Try
                ' The display media infor
                objInfoRetriever.RetrieveInfo(strFilePath)
                intWidth = objInfoRetriever.Width
                intHeight = objInfoRetriever.Height
                dblDuration = Math.Round(objInfoRetriever.Duration, 2)
            Catch ex As Exception
            End Try
        End Sub

        Public Sub GetSoundInfor(ByVal strFilePath As String, ByRef strAlbum As String, ByRef strArtist As String, ByRef dblDuration As Double, ByRef strComment As String, ByRef strGenre As String, ByVal intBitRate As Integer)
            Dim objInfoRetriever As New MEDIAPROCESSORLib.InfoRetrieverClass
            Try
                ' The sound media infor
                objInfoRetriever.RetrieveInfo(strFilePath)
                If Not LCase(objInfoRetriever.Album) = "unknown" Then
                    strAlbum = objBCSP.ToUTF8Back(objInfoRetriever.Album)
                End If
                If Not LCase(objInfoRetriever.Artist) = "unknown" Then
                    strArtist = objBCSP.ToUTF8Back(objInfoRetriever.Artist)
                End If
                If Not LCase(objInfoRetriever.Author) = "unknown" Then
                    objBEData.Author = objBCSP.ToUTF8Back(objInfoRetriever.Author)
                End If
                If Not LCase(objInfoRetriever.Comment) = "unknown" Then
                    strComment = objBCSP.ToUTF8Back(objInfoRetriever.Comment)
                End If
                dblDuration = Math.Round(objInfoRetriever.Duration, 2)
                If Not LCase(objInfoRetriever.Genre) = "unknown" Then
                    strGenre = objBCSP.ToUTF8Back(objInfoRetriever.Genre)
                End If
                If Not LCase(objInfoRetriever.ShortDescr) = "unknown" Then
                    objBEData.Description = objBCSP.ToUTF8Back(objInfoRetriever.ShortDescr)
                End If
                If Not LCase(objInfoRetriever.Title) = "unknown" Then
                    objBEData.Title = objBCSP.ToUTF8Back(objInfoRetriever.Title)
                End If
                intBitRate = objInfoRetriever.BitRate
            Catch ex As Exception
            End Try
        End Sub

        Public Sub GetPdfInfor(ByVal strFilePath As String, ByRef intPageCount As Integer)
            Dim objDoc As New ABCpdf4.Doc
            ' The PDF infor
            objDoc.Read(strFilePath)
            intPageCount = objDoc.PageCount
        End Sub

        Public Sub GetDocInfor(ByVal strFilePath As String, ByRef strTitle As String, ByRef strAuthor As String, ByRef strDescription As String, ByRef intPageCount As Integer)
            Dim objFilePropReader As New DSOleFile.PropertyReaderClass
            Dim objDocProp As DSOleFile.DocumentProperties

            objDocProp = objFilePropReader.GetDocumentProperties(strFilePath)

            If Not Trim(objDocProp.Title) = "" Then
                strTitle = objBCSP.ToUTF8Back(objDocProp.Title)
            End If
            If Not Trim(objDocProp.Author) = "" Then
                strAuthor = objBCSP.ToUTF8Back(objDocProp.Author)
            End If
            If Not Trim(objDocProp.Comments) = "" Then
                strDescription = objBCSP.ToUTF8Back(objDocProp.Comments)
            End If
            If strAuthor = "" And Not Trim(objDocProp.Company) = "" Then
                strAuthor = objBCSP.ToUTF8Back(objDocProp.Company)
            End If
            intPageCount = objDocProp.PageCount
        End Sub

        ' Page_Unload event
        Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
            Me.Dispose(True)
        End Sub

        ' Dispose method
        ' Purpose: release all objects
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBUser Is Nothing Then
                    objBUser.Dispose(True)
                    objBUser = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
            Catch
            End Try
        End Sub
    End Class
End Namespace
