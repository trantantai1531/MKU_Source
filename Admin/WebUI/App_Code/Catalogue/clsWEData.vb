Imports System.IO
Imports GflAx193.GflAxClass
Imports MEDIAPROCESSORLib.MediaProcessorClass
Imports DSOleFile.PropertyReaderClass
Imports ABCpdf4
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.Catalogue

Namespace eMicLibAdmin.WebUI
    Public Class clsWEData
        Inherits clsWBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Protected lngID As Long = 0
        Protected strIDs As String = ""
        Protected strFileLocation As String = ""
        Protected lngFileSize As Long = 0
        Protected strCreatedDate As String = ""
        Protected strNote As String = ""
        Protected intExisted As Integer
        Protected intSecretLevel As Integer = 0
        Protected strLastModifiedBy As String = ""
        Protected intDownloadTime As Integer = 0
        Protected intMediaType As Integer = 0
        Protected strTitle As String = ""
        Protected strAuthor As String = ""
        Protected strDescription As String = ""
        Protected blnLocked As Boolean
        Protected strLockedBy As String = ""
        Protected strLockedDate As String = ""
        Protected intStatus As Integer = 0
        Protected intModifyTime As Integer = 0
        Protected intCollectionID As Integer = 0
        Protected strInputer As String = ""
        Protected dblPrice As Double = 0
        Protected strFormat As String = ""
        Protected intPageCount As Integer = 0
        Protected strCurrency As String = ""
        Protected lngStartID As Long = 0
        Protected intFree As Integer
        Protected intPageSize As Integer = 0
        Protected strParam As String = ""
        Protected strCollection As String = ""
        Protected strSysDirs() As String
        Private intDataTypeID As Integer = 0
        Private strFieldCode As String = ""

        Private objBEData As New clsBEData
        Private objBCDBSYS As New clsBCommonDBSystem

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' strFieldCode property
        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        ' Collection property
        Public Property Collection() As String
            Get
                Return strCollection
            End Get
            Set(ByVal Value As String)
                strCollection = Value
            End Set
        End Property

        ' DataTypeID property
        Public Property DataTypeID() As Integer
            Get
                Return intDataTypeID
            End Get
            Set(ByVal Value As Integer)
                intDataTypeID = Value
            End Set
        End Property

        ' FileID property
        Public Property FileID() As Long
            Get
                Return lngID
            End Get
            Set(ByVal Value As Long)
                lngID = Value
            End Set
        End Property

        ' StartID property
        Public Property StartID() As Long
            Get
                Return lngStartID
            End Get
            Set(ByVal Value As Long)
                lngStartID = Value
            End Set
        End Property

        ' FileIDs property
        Public Property FileIDs() As String
            Get
                Return strIDs
            End Get
            Set(ByVal Value As String)
                strIDs = Value
            End Set
        End Property

        ' FileLocation property
        Public Property FileLocation() As String
            Get
                Return strFileLocation
            End Get
            Set(ByVal Value As String)
                strFileLocation = Value
            End Set
        End Property

        ' FileSize property
        Public Property FileSize() As Long
            Get
                Return lngFileSize
            End Get
            Set(ByVal Value As Long)
                lngFileSize = Value
            End Set
        End Property

        ' CreatedDate property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property

        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                strNote = Value
            End Set
        End Property

        ' Existed property
        Public Property Existed() As Integer
            Get
                Return intExisted
            End Get
            Set(ByVal Value As Integer)
                intExisted = Value
            End Set
        End Property

        ' SecretLevel property
        Public Property SecretLevel() As Integer
            Get
                Return intSecretLevel
            End Get
            Set(ByVal Value As Integer)
                intSecretLevel = Value
            End Set
        End Property

        ' LastModifiedBy property
        Public Property LastModifiedBy() As String
            Get
                Return strLastModifiedBy
            End Get
            Set(ByVal Value As String)
                strLastModifiedBy = Value
            End Set
        End Property

        ' DownloadTime property
        Public Property DownloadTime() As Integer
            Get
                Return intDownloadTime
            End Get
            Set(ByVal Value As Integer)
                intDownloadTime = Value
            End Set
        End Property

        ' MediaType property
        Public Property MediaType() As Integer
            Get
                Return intMediaType
            End Get
            Set(ByVal Value As Integer)
                intMediaType = Value
            End Set
        End Property

        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' Author property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property

        ' Description property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property

        ' Locked property
        Public Property Locked() As Boolean
            Get
                Return blnLocked
            End Get
            Set(ByVal Value As Boolean)
                blnLocked = Value
            End Set
        End Property

        ' LockedBy property
        Public Property LockedBy() As String
            Get
                Return strLockedBy
            End Get
            Set(ByVal Value As String)
                strLockedBy = Value
            End Set
        End Property

        ' LockedDate property
        Public Property LockedDate() As String
            Get
                Return strLockedDate
            End Get
            Set(ByVal Value As String)
                strLockedDate = Value
            End Set
        End Property

        ' Status property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property

        ' ModifyTime property
        Public Property ModifyTime() As Integer
            Get
                Return intModifyTime
            End Get
            Set(ByVal Value As Integer)
                intModifyTime = Value
            End Set
        End Property

        ' CollectionID property
        Public Property CollectionID() As Integer
            Get
                Return intCollectionID
            End Get
            Set(ByVal Value As Integer)
                intCollectionID = Value
            End Set
        End Property

        ' Free property
        Public Property Free() As Integer
            Get
                Return intFree
            End Get
            Set(ByVal Value As Integer)
                intFree = Value
            End Set
        End Property

        ' Inputer property
        Public Property Inputer() As String
            Get
                Return strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
            End Set
        End Property

        ' Price property
        Public Property Price() As Double
            Get
                Return dblPrice
            End Get
            Set(ByVal Value As Double)
                dblPrice = Value
            End Set
        End Property

        ' Format property
        Public Property Format() As String
            Get
                Return strFormat
            End Get
            Set(ByVal Value As String)
                strFormat = Value
            End Set
        End Property

        ' PageCount property
        Public Property PageCount() As Integer
            Get
                Return intPageCount
            End Get
            Set(ByVal Value As Integer)
                intPageCount = Value
            End Set
        End Property

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' PageSize property
        Public Property PageSize() As Integer
            Get
                Return intPageSize
            End Get
            Set(ByVal Value As Integer)
                intPageSize = Value
            End Set
        End Property

        ' Param property
        Public Property Param() As String
            Get
                Return strParam
            End Get
            Set(ByVal Value As String)
                strParam = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Init objBEData object
            objBEData.DBServer = Session("DBServer")
            objBEData.ConnectionString = Session("ConnectionString")
            objBEData.InterfaceLanguage = Session("InterfaceLanguage")
            objBEData.Initialize()

            ' Init objBCSP object
            objBCDBSYS.DBServer = Session("DBServer")
            objBCDBSYS.ConnectionString = Session("ConnectionString")
            objBCDBSYS.InterfaceLanguage = Session("InterfaceLanguage")
            objBCDBSYS.Initialize()
        End Sub

        ' DownLoad method
        Public Function DownLoad() As Integer
            Try
                objBEData.InitVariablesForEdataFile()
                objBEData.FileIDs = strIDs
                objBEData.DownloadTimes = 0
                objBEData.UpdateFileRecord()
                intErrorCode = objBEData.ErrorCode()
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Delete(ByVal blnIsPhysicalRemove As Boolean) As Integer
            Dim objDirInfor As DirectoryInfo
            Dim objFileInfor As FileInfo
            Dim tblTemp As DataTable
            Dim intIndex As Integer
            Dim strTabNumb As String

            Try
                objBEData.FileIDs = strIDs
                tblTemp = objBEData.GetGeneralInfor(2, 0, 0, 0)

                If Not tblTemp Is Nothing Then
                    If tblTemp.Rows.Count > 0 Then
                        For intIndex = 0 To tblTemp.Rows.Count
                            If Not IsDBNull(tblTemp.Rows(intIndex).Item("ItemID")) Then
                                If tblTemp.Rows(intIndex).Item("ItemID") <> "" Then
                                    ' DELETE URL
                                    objBEData.FileID = tblTemp.Rows(intIndex).Item("ID")
                                    objBEData.GeneralDelete(0, 0, tblTemp.Rows(intIndex).Item("ItemID"), LCase("%WDownLoad.aspx?FileID=" & tblTemp.Rows(intIndex).Item("ID") & "%"), "", "", "", "")
                                    If Not IsDBNull(tblTemp.Rows(intIndex).Item("FieldCode")) Then
                                        If tblTemp.Rows(intIndex).Item("FieldCode") <> "" Then
                                            strTabNumb = "Field" & Left(tblTemp.Rows(intIndex).Item("FieldCode"), 1) & "00s"
                                            objBEData.FileID = tblTemp.Rows(intIndex).Item("ID")
                                            objBEData.GeneralDelete(1, 1, tblTemp.Rows(intIndex).Item("ItemID"), "", "", strTabNumb, LCase("%WDownLoad.aspx?FileID=" & tblTemp.Rows(intIndex).Item("ID") & "%"), "")
                                        End If
                                    End If
                                End If
                            End If
                            If blnIsPhysicalRemove = True Then
                                objFileInfor = New FileInfo(tblTemp.Rows(intIndex).Item("PhysicalPath"))
                                If objFileInfor.Exists Then
                                    objFileInfor.Delete()
                                End If
                            End If
                            objBEData.FileID = tblTemp.Rows(intIndex).Item("ID")
                            objBEData.GeneralDelete(2, 0, 0, "", "", "", "", "")
                        Next
                    End If
                End If
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateMultimedia method
        ' Purpose:
        ' Creator:
        Public Function CreateMultimedia() As Integer
            Try


            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateEDataInfor method
        ' Purpose:
        ' Creator:
        Public Function UpdateEDataInfor() As Integer
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetTotalOfFiles method
        ' Purpose:
        ' Creator:
        Public Function GetTotalOfFiles() As Integer
            Try

            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

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
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function ImportEData(ByVal strLocation As String, ByVal strFile As String) As Long
            Dim lngRetVal As Long = 0
            Try
                ' Get MediaType
                intMediaType = GetFileMediaType(Replace(strLocation & "\", "\\", "\") & strFile)
                lngRetVal = ImportFile(strLocation, strFile, intMediaType)
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
                strErrorMsg = objBEData.ErrorCode
            Finally
                ImportEData = lngRetVal
            End Try
        End Function

        Public Function ImportFile(ByVal strLocation As String, ByVal strFileName As String, ByVal intMediaType As Integer) As Long
            ' Declare variables
            Dim lngRetVal As Long = 0
            Dim tblFile As DataTable
            Dim objFileInfor As FileInfo
            Dim strFilePath As String = ""
            Dim lngFileSize As Long = 0
            Dim lngID As Long
            Dim strExtension As String
            Dim strBipmapType As String
            Dim strColorModel As String
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
                strFilePath = Replace(strLocation & "\", "\\", "\") & strFileName
                objFileInfor = New FileInfo(strFilePath)
                lngFileSize = objFileInfor.Length
                objBEData.InitVariablesForEdataFile()

                objBEData.FileLocation = strFilePath
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

                ' Insert to edata file table
                objBEData.CreateFileRecord()
                lngID = objBEData.FileID
                lngRetVal = lngID

                ' Create multimedia record of this file
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
                strErrorMsg = objBEData.ErrorMsg
                intErrorCode = objBEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message.ToString
            Finally
                ImportFile = lngRetVal
            End Try
        End Function

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
                        intMediaType = 5
                    Case Else
                        intMediaType = 6
                End Select
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                GetFileMediaType = intMediaType
            End Try

        End Function

        Public Sub GetImageInfor(ByVal strFilePath As String, ByRef strBipmapType As String, ByRef strColorModel As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef shtXdpi As Short, ByRef shtYdpi As Short, ByRef intNoColorUsed As Long)
            'Dim objImg As New GflAx193.GflAxClass
            'Try
            '    ' Get the image infor
            '    With objImg
            '        .EnableLZW = True
            '        .LoadBitmap(strFilePath)
            '        strBipmapType = CStr(.BitmapType)
            '        strColorModel = .ColorModel
            '        intWidth = .Width
            '        intHeight = .Height
            '        shtXdpi = .Xdpi
            '        shtYdpi = .Ydpi
            '        intNoColorUsed = .NumberOfColorsUsed
            '    End With
            'Catch ex As Exception
            '    strErrorMsg = ex.Message
            'End Try
        End Sub

        ' GetMediaInfor method ("mpg", "avi", "asf", "mpeg", "mov", "flc", "mpv", "swf")
        ' Purpose: Get the media infor
        Public Sub GetMediaInfor(ByVal strFilePath As String, ByRef intWidth As Integer, ByRef intHeight As Integer, ByRef dblDuration As Double)
            Dim objInfoRetriever As New MEDIAPROCESSORLib.InfoRetrieverClass
            Try
                ' The display media infor
                objInfoRetriever.RetrieveInfo(strFilePath)
                intWidth = objInfoRetriever.Width
                intHeight = objInfoRetriever.Height
                dblDuration = Math.Round(objInfoRetriever.Duration, 2)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetSoundInfor
        ' Purpose: Get the sound media infor ("mp3, wav")

        Public Sub GetSoundInfor(ByVal strFilePath As String, ByRef strAlbum As String, ByRef strArtist As String, ByRef dblDuration As Double, ByRef strComment As String, ByRef strGenre As String, ByVal intBitRate As Long)
            Dim objInfoRetriever As New MEDIAPROCESSORLib.InfoRetrieverClass
            Try
                ' The sound media infor
                objInfoRetriever.RetrieveInfo(strFilePath)
                If Not LCase(objInfoRetriever.Album) = "unknown" Then
                    strAlbum = objInfoRetriever.Album
                End If
                If Not LCase(objInfoRetriever.Artist) = "unknown" Then
                    strArtist = objInfoRetriever.Artist
                End If
                If Not LCase(objInfoRetriever.Author) = "unknown" Then
                    strAuthor = objInfoRetriever.Author
                End If
                If Not LCase(objInfoRetriever.Comment) = "unknown" Then
                    strComment = objInfoRetriever.Comment
                End If
                dblDuration = Math.Round(objInfoRetriever.Duration, 2)
                If Not LCase(objInfoRetriever.Genre) = "unknown" Then
                    strGenre = objInfoRetriever.Genre
                End If
                If Not LCase(objInfoRetriever.ShortDescr) = "unknown" Then
                    strDescription = objInfoRetriever.ShortDescr
                End If
                If Not LCase(objInfoRetriever.Title) = "unknown" Then
                    strTitle = objInfoRetriever.Title
                End If
                intBitRate = objInfoRetriever.BitRate
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetPdfInfor method
        ' Purpose: Get the page count of PDF file

        Public Sub GetPdfInfor(ByVal strFilePath As String, ByRef intPageCount As Integer)
            'Dim objDoc As New ABCpdf4.Doc

            '' The PDF infor
            'objDoc.Read(strFilePath)
            'intPageCount = objDoc.PageCount
        End Sub

        ' GetDocInfor
        ' Purpose: Get the properties of document ("doc", "xsl", "ppt", "pps") infor 

        Public Sub GetDocInfor(ByVal strFilePath As String, ByRef strTitle As String, ByRef strAuthor As String, ByRef strDescription As String, ByRef intPageCount As Integer)
            Dim objFilePropReader As New DSOleFile.PropertyReaderClass
            Dim objDocProp As DSOleFile.DocumentProperties

            objDocProp = objFilePropReader.GetDocumentProperties(strFilePath)

            If Not Trim(objDocProp.Title) = "" Then
                strTitle = objDocProp.Title
            End If
            If Not Trim(objDocProp.Author) = "" Then
                strAuthor = objDocProp.Author
            End If
            If Not Trim(objDocProp.Comments) = "" Then
                strDescription = objDocProp.Comments
            End If
            If strAuthor = "" And Not Trim(objDocProp.Company) = "" Then
                strAuthor = objDocProp.Company
            End If
            intPageCount = objDocProp.PageCount
        End Sub

        ' GetEDataParam method
        ' Purpose: Get all edata parameters
        ' Input: integer value of DataType
        ' Output: datatable
        Public Function GetEDataParams() As DataTable
            Try
                objBEData.FieldCode = strFieldCode
                GetEDataParams = objBEData.GetEDataParams
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Function

        ' GetGeneraInfor method
        ' Purpose: Get general infor of file (File Name, Size,...)
        ' Output: 
        ' Output: datatable result
        Public Function GetGeneralInfor(ByVal intMode As Int16, ByVal intListType As Int16, ByVal intViewMode As Int16, ByRef lngTotalRec As Long, Optional ByVal intType As Int16 = -1) As DataTable
            Try
                objBEData.FileIDs = strIDs
                objBEData.StartID = lngStartID
                objBEData.PageSize = intPageSize
                objBEData.CollectionID = intCollectionID
                objBEData.Param = strParam
                GetGeneralInfor = objBEData.GetGeneralInfor(intMode, intListType, intViewMode, lngTotalRec, intType)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMinIDByTopNum method
        ' Purpose: Get the min ID of the page having a top number
        ' Output: datatable result
        ' Creator:
        Public Function GetMaxIDByTopNum(ByVal intListType As Integer, ByVal lngTopNum As Long, Optional ByVal intFree As Integer = -1) As Long
            Dim lngMaxID As Long = 0
            Try
                objBEData.Status = intStatus
                objBEData.Param = strParam
                objBEData.CollectionID = intCollectionID
                lngMaxID = objBEData.GetMaxIDByTopNum(intListType, lngTopNum).Rows(0).Item(0)
                intErrorCode = objBEData.ErrorCode
                strErrorMsg = objBEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            GetMaxIDByTopNum = lngMaxID
        End Function

        ' GetEdataSearchCount function
        ' Purpose: Get count of edata searched
        Public Function GetEdataSearchCount(ByVal strSQLStatement As String) As DataTable
            Try
                objBCDBSYS.SQLStatement = strSQLStatement
                GetEdataSearchCount = objBCDBSYS.RetrieveItemInfor
                strErrorMsg = objBCDBSYS.ErrorMsg
                intErrorCode = objBCDBSYS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Function CheckSysDir(ByVal strLoc) As Boolean
            Dim strURLPaths() As String
            Dim i As Integer

            Try
                CheckSysDir = False
                If Not objSysPara(7).ToString.Trim = "" Then
                    strSysDirs = Split(objSysPara(7).Trim, ";")
                    If Not strSysDirs Is Nothing AndAlso UBound(strSysDirs) > 0 Then
                        For i = LBound(strSysDirs) To UBound(strSysDirs) - 1
                            If InStr(LCase(strLoc & "\"), LCase(Replace(strSysDirs(i), "/", "\"))) > 0 Then
                                CheckSysDir = True
                                Exit Function
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                CheckSysDir = False
                strErrorMsg = ex.Message
            End Try
        End Function

        ' FormatSize method
        ' Purpose: show size of file, directory in suite format
        ' Input: FileSize
        ' Output: String value
        Protected Function FormatSize(ByVal dblFileSize As Double) As String
            If dblFileSize < 1024 Then
                Return String.Format("{0:N0} B", dblFileSize)
            ElseIf (dblFileSize < 1024 * 1024) Then
                Return String.Format("{0:N2} KB", dblFileSize / 1024)
            Else
                Return String.Format("{0:N2} MB", dblFileSize / (1024 * 1024))
            End If
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBEData Is Nothing Then
                    objBEData.Dispose(True)
                    objBEData = Nothing
                End If
                If Not objBCDBSYS Is Nothing Then
                    objBCDBSYS.Dispose(True)
                    objBCDBSYS = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace