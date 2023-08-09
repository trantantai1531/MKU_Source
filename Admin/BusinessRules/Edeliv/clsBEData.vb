' Name: clsDEData
' Purpose: Management edata information
' Creator: Oanhtn
' Created Date: 24/12/2004
' Modification History:

'Imports eMicLibAdmin.BusinessRules.Edeliv
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Edeliv

Namespace eMicLibAdmin.BusinessRules.Edeliv
    Public Class clsBEData
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objDEData As New clsDEData
        Private objBInput As New clsBInput

        Private lngID As Long

        Private strIDs As String
        Private strFileLocation As String
        Private lngFileSize As Long
        Private strCreatedDate As String
        Private strNote As String
        Private blnExisted As Boolean
        Private intSecretLevel As Integer
        Private strLastModifiedBy As String
        Private intMediaType As Integer
        Private strTitle As String
        Private strAuthor As String
        Private strDescription As String
        Private blnLocked As Boolean
        Private strLockedBy As String
        Private strLockedDate As String
        Private intStatus As Integer
        Private intModifyTime As Integer

        'Collection
        Private intCollectionID As Integer
        Private strCollection As String
        Private strCollectionName As String
        Private strCollectionDescription As String
        Private intCollectionIsShow As Integer
        Private strCollectionCover As String
        'Collection filter
        Private intCollectionFilterID As Integer
        Private strCollectionFilterBoolArr As String
        Private strCollectionFilterFieldArr As String
        Private strCollectionFilterValArr As String
        Private strCollectionFilterFromDate As String
        Private strCollectionFilterToDate As String
        Private strCollectionFilterUsername As String
        Private intCollectionFilterDocType As Integer

        Private strInputer As String
        Private strFormat As String
        Private intPageCount As Integer
        Private lngStartID As Long
        Private intPageSize As Integer
        Private intFree As Integer

        'Tuanhv column in Edata Multimedia
        Private intBitmapType As Integer
        Private strColorModel As String
        Private intImgWidth As Integer
        Private intImgHeight As Integer
        Private intXdpi As Integer
        Private intYdpi As Integer
        Private intNoColorUsed As Long
        Private strAlbum As String
        Private strArtist As String
        Private intBitRate As Integer
        Private dbDuration As Double
        Private strGenre As String
        Private strUploadedDate As String
        Private strUploadedBy As String
        Private strFieldCode As String
        Private intItemID As String
        Private strURL As String
        Private strPhysicalPath As String
        Private intExisted As Integer
        Private intDownloadTimes As Long
        Private intLocked As Integer
        Private intModifiedTimes As Integer

        Private strFileName As String
        Private dblPrice As Double
        Private strCurrency As String
        Private strPagination As String
        Private strFileFormat As String

        Private strParam As String = ""
        Private intParentID As Integer

        'Table of content
        Private strTocName As String = ""
        Private intTocNumOfPage As Integer = 0
        Private intTocID As Integer = 0

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' CollectionFilterID property
        Public Property CollectionFilterID() As Integer
            Get
                Return intCollectionFilterID
            End Get
            Set(ByVal Value As Integer)
                intCollectionFilterID = Value
            End Set
        End Property

        ' CollectionFilterFieldArr property
        Public Property CollectionFilterFieldArr() As String
            Get
                Return strCollectionFilterFieldArr
            End Get
            Set(ByVal Value As String)
                strCollectionFilterFieldArr = Value
            End Set
        End Property

        ' CollectionFilterBoolArr property
        Public Property CollectionFilterBoolArr() As String
            Get
                Return strCollectionFilterBoolArr
            End Get
            Set(ByVal Value As String)
                strCollectionFilterBoolArr = Value
            End Set
        End Property

        ' CollectionFilterValArr property
        Public Property CollectionFilterValArr() As String
            Get
                Return strCollectionFilterValArr
            End Get
            Set(ByVal Value As String)
                strCollectionFilterValArr = Value
            End Set
        End Property

        ' CollectionFilterFromDate property
        Public Property CollectionFilterFromDate() As String
            Get
                Return strCollectionFilterFromDate
            End Get
            Set(ByVal Value As String)
                strCollectionFilterFromDate = Value
            End Set
        End Property

        ' CollectionFilterToDate property
        Public Property CollectionFilterToDate() As String
            Get
                Return strCollectionFilterToDate
            End Get
            Set(ByVal Value As String)
                strCollectionFilterToDate = Value
            End Set
        End Property

        ' CollectionFilterUsername property
        Public Property CollectionFilterUsername() As String
            Get
                Return strCollectionFilterUsername
            End Get
            Set(ByVal Value As String)
                strCollectionFilterUsername = Value
            End Set
        End Property

        ' CollectionFilterDocType property
        Public Property CollectionFilterDocType() As Integer
            Get
                Return intCollectionFilterDocType
            End Get
            Set(ByVal Value As Integer)
                intCollectionFilterDocType = Value
            End Set
        End Property

        ' CollectionName property
        Public Property CollectionName() As String
            Get
                Return strCollectionName
            End Get
            Set(ByVal Value As String)
                strCollectionName = Value
            End Set
        End Property

        ' CollectionDescription property
        Public Property CollectionDescription() As String
            Get
                Return strCollectionDescription
            End Get
            Set(ByVal Value As String)
                strCollectionDescription = Value
            End Set
        End Property

        ' CollectionIsShow property
        Public Property CollectionIsShow() As Integer
            Get
                Return intCollectionIsShow
            End Get
            Set(ByVal Value As Integer)
                intCollectionIsShow = Value
            End Set
        End Property

        ' CollectionCover property
        Public Property CollectionCover() As String
            Get
                Return strCollectionCover
            End Get
            Set(ByVal Value As String)
                strCollectionCover = Value
            End Set
        End Property

        ' TocName property
        Public Property TocName() As String
            Get
                Return strTocName
            End Get
            Set(ByVal Value As String)
                strTocName = Value
            End Set
        End Property

        ' TocNumOfPage property
        Public Property TocNumOfPage() As Integer
            Get
                Return intTocNumOfPage
            End Get
            Set(ByVal Value As Integer)
                intTocNumOfPage = Value
            End Set
        End Property

        ' TocID property
        Public Property TocID() As Integer
            Get
                Return intTocID
            End Get
            Set(ByVal Value As Integer)
                intTocID = Value
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

        ' UploadedDate property
        Public Property UploadedDate() As String
            Get
                Return strUploadedDate
            End Get
            Set(ByVal Value As String)
                strUploadedDate = Value
            End Set
        End Property

        ' FieldCode property
        Public Property FieldCode() As String
            Get
                Return strFieldCode
            End Get
            Set(ByVal Value As String)
                strFieldCode = Value
            End Set
        End Property

        ' UploadedBy property
        Public Property UploadedBy() As String
            Get
                Return strUploadedBy
            End Get
            Set(ByVal Value As String)
                strUploadedBy = Value
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

        ' ItemID  property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
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

        ' Inputer property
        Public Property Inputer() As String
            Get
                Return strInputer
            End Get
            Set(ByVal Value As String)
                strInputer = Value
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


        ' PageSize property
        Public Property PageSize() As Integer
            Get
                Return intPageSize
            End Get
            Set(ByVal Value As Integer)
                intPageSize = Value
            End Set
        End Property

        ' URL property
        Public Property URL() As String
            Get
                Return strURL
            End Get
            Set(ByVal Value As String)
                strURL = Value
            End Set
        End Property


        ' PhysicalPath property
        Public Property PhysicalPath() As String
            Get
                Return strPhysicalPath
            End Get
            Set(ByVal Value As String)
                strPhysicalPath = Value
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

        ' FileLocation property
        Public Property FileLocation() As String
            Get
                Return strFileLocation
            End Get
            Set(ByVal Value As String)
                strFileLocation = Value
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


        ' SecretLevel property
        Public Property SecretLevel() As Integer
            Get
                Return intSecretLevel
            End Get
            Set(ByVal Value As Integer)
                intSecretLevel = Value
            End Set
        End Property

        ' DownloadTimes property
        Public Property DownloadTimes() As Long
            Get
                Return intDownloadTimes
            End Get
            Set(ByVal Value As Long)
                intDownloadTimes = Value
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
        Public Property Locked() As Integer
            Get
                Return intLocked
            End Get
            Set(ByVal Value As Integer)
                intLocked = Value
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


        ' LockedBy property
        Public Property LockedBy() As String
            Get
                Return strLockedBy
            End Get
            Set(ByVal Value As String)
                strLockedBy = Value
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

        ' ModifiedTimes property
        Public Property ModifiedTimes() As Integer
            Get
                Return intModifiedTimes
            End Get
            Set(ByVal Value As Integer)
                intModifiedTimes = Value
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

        ' CollectionID property
        Public Property CollectionID() As Integer
            Get
                Return intCollectionID
            End Get
            Set(ByVal Value As Integer)
                intCollectionID = Value
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

        ' Genre property
        Public Property Genre() As String
            Get
                Return strGenre
            End Get
            Set(ByVal Value As String)
                strGenre = Value
            End Set
        End Property

        ' Duration property
        Public Property Duration() As Double
            Get
                Return dbDuration
            End Get
            Set(ByVal Value As Double)
                dbDuration = Value
            End Set
        End Property

        ' BitRate property
        Public Property BitRate() As Integer
            Get
                Return intBitRate
            End Get
            Set(ByVal Value As Integer)
                intBitRate = Value
            End Set
        End Property

        ' Artist property
        Public Property Artist() As String
            Get
                Return strArtist
            End Get
            Set(ByVal Value As String)
                strArtist = Value
            End Set
        End Property

        ' Album property
        Public Property Album() As String
            Get
                Return strAlbum
            End Get
            Set(ByVal Value As String)
                strAlbum = Value
            End Set
        End Property

        ' NoColorUsed property
        Public Property NoColorUsed() As Long
            Get
                Return intNoColorUsed
            End Get
            Set(ByVal Value As Long)
                intNoColorUsed = Value
            End Set
        End Property

        ' Ydpi property
        Public Property Ydpi() As Integer
            Get
                Return intYdpi
            End Get
            Set(ByVal Value As Integer)
                intYdpi = Value
            End Set
        End Property

        ' Xdpi property
        Public Property Xdpi() As Integer
            Get
                Return intXdpi
            End Get
            Set(ByVal Value As Integer)
                intXdpi = Value
            End Set
        End Property

        ' ImgHeight property
        Public Property ImgHeight() As Integer
            Get
                Return intImgHeight
            End Get
            Set(ByVal Value As Integer)
                intImgHeight = Value
            End Set
        End Property

        ' ImgWidth property
        Public Property ImgWidth() As Integer
            Get
                Return intImgWidth
            End Get
            Set(ByVal Value As Integer)
                intImgWidth = Value
            End Set
        End Property

        ' ColorModel property
        Public Property ColorModel() As String
            Get
                Return strColorModel
            End Get
            Set(ByVal Value As String)
                strColorModel = Value
            End Set
        End Property

        ' BitmapType property
        Public Property BitmapType() As Integer
            Get
                Return intBitmapType
            End Get
            Set(ByVal Value As Integer)
                intBitmapType = Value
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

        ' FileName property 
        Public Property FileName() As String
            Get
                Return strFileName
            End Get
            Set(ByVal Value As String)
                strFileName = Value
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

        ' Currency property
        Public Property Currency() As String
            Get
                Return strCurrency
            End Get
            Set(ByVal Value As String)
                strCurrency = Value
            End Set
        End Property

        ' Pagination property
        Public Property Pagination() As String
            Get
                Return strPagination
            End Get
            Set(ByVal Value As String)
                strPagination = Value
            End Set
        End Property

        ' FileFormat property
        Public Property FileFormat() As String
            Get
                Return strFileFormat
            End Get
            Set(ByVal Value As String)
                strFileFormat = Value
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

        ' ParentID property
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
            End Set
        End Property

        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************

        ' InitVariablesForMultimedia method
        ' Purpose: Init value for variable in table multimedia
        ' Input: 
        ' Output: Default value for variable in table multimedia
        ' Create: Tuanhv
        Public Sub InitVariablesForMultimedia()
            lngID = 0
            intBitmapType = -1
            strColorModel = ""
            intImgWidth = -1
            intImgHeight = -1
            intXdpi = -1
            intYdpi = -1
            intNoColorUsed = -1
            strAlbum = ""
            strArtist = ""
            intBitRate = -1
            dbDuration = -1
            strGenre = ""
            intPageCount = -1
        End Sub

        ' InitVariablesForEdataFile method
        ' Purpose: Init value for variable in table edata file
        ' Input: 
        ' Output: Default value for variable in table file
        ' Create: Tuanhv
        Public Sub InitVariablesForEdataFile()
            lngID = 0
            strIDs = ""
            lngFileSize = -1
            strUploadedDate = ""
            strUploadedBy = ""
            strFieldCode = ""
            intItemID = -1
            strURL = ""
            strPhysicalPath = ""
            intExisted = -1
            strFileLocation = ""
            intSecretLevel = -1
            intDownloadTimes = -1
            intMediaType = -1
            strTitle = ""
            strAuthor = ""
            strDescription = ""
            intLocked = -1
            strLockedDate = ""
            strLockedBy = ""
            strLastModifiedBy = ""
            intModifiedTimes = -1
            intStatus = -1
            strNote = ""
            intCollectionID = -1
            intFree = -1
            strFileName = ""
            dblPrice = -1
            strCurrency = ""
            strPagination = ""
            strFileFormat = ""
        End Sub


        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            ' Init objBCSP object
            objBSP.DBServer = strDBServer
            objBSP.ConnectionString = strConnectionString
            objBSP.InterfaceLanguage = strInterfaceLanguage
            objBSP.Initialize()

            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()

            ' Init objDEData object
            objDEData.DBServer = strDBServer
            objDEData.ConnectionString = strConnectionString
            objDEData.Initialize()

            ' Init objBInput object
            objBInput.DBServer = strdbserver
            objBInput.ConnectionString = strConnectionString
            objBInput.InterfaceLanguage = strInterfaceLanguage
            objBInput.Initialize()
        End Sub

        ' CreateEdataFile method
        ' Purpose: Insert information into edata file
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function CreateFileRecord() As Integer
            Try
                objDEData.InitVariablesForEdataFile()
                objDEData.FileSize = lngFileSize
                objDEData.UploadedDate = strUploadedDate
                objDEData.UploadedBy = objBSP.ConvertItBack(strUploadedBy)
                objDEData.FieldCode = strFieldCode
                objDEData.ItemID = intItemID
                objDEData.URL = objBSP.ConvertItBack(strURL)
                objDEData.PhysicalPath = objBSP.ConvertItBack(strPhysicalPath)
                objDEData.Existed = intExisted
                objDEData.FileLocation = objBSP.ConvertItBack(strFileLocation)
                objDEData.SecretLevel = intSecretLevel
                objDEData.DownloadTimes = intDownloadTimes
                objDEData.MediaType = intMediaType
                objDEData.Title = objBSP.ConvertItBack(strTitle)
                objDEData.Author = objBSP.ConvertItBack(strAuthor)
                objDEData.Description = objBSP.ConvertItBack(strDescription)
                objDEData.Locked = intLocked
                objDEData.LockedDate = strLockedDate
                objDEData.LockedBy = strLockedBy
                objDEData.LastModifiedBy = strLastModifiedBy
                objDEData.ModifiedTimes = intModifiedTimes
                objDEData.Status = intStatus
                objDEData.Note = strNote
                objDEData.CollectionID = intCollectionID
                objDEData.Free = intFree
                objDEData.FileName = objBSP.ConvertItBack(strFileName)
                objDEData.Price = dblPrice
                objDEData.Currency = strCurrency
                objDEData.Pagination = strPagination
                objDEData.FileFormat = strFileFormat
                CreateFileRecord = objDEData.CreateFileRecord()
                lngID = objDEData.FileID
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateMediaRecord method
        ' Purpose: 
        ' Output: 
        ' Creator:
        Public Function CreateMediaRecord(ByVal strFieldInput As String, ByVal strFieldValue As String, ByVal intIDEdataFile As Integer) As Integer
            Try
                CreateMediaRecord = objDEData.CreateMediaRecord(strFieldInput, objBSP.ConvertItBack(strFieldValue), intIDEdataFile)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' CreateMultimedia method
        ' Purpose: insert data multimedia 
        ' Input: Some information of multimedia
        ' Output: datatable result
        ' Create: Tuanhv
        Public Function CreateMultimedia() As Integer
            Try
                objDEData.InitVariablesForMultimedia()
                objDEData.FileID = lngID
                objDEData.BitmapType = intBitmapType
                objDEData.ColorModel = strColorModel
                objDEData.ImgWidth = intImgWidth
                objDEData.ImgHeight = intImgHeight
                objDEData.Xdpi = intXdpi
                objDEData.Ydpi = intYdpi
                objDEData.NoColorUsed = intNoColorUsed
                objDEData.Album = objBSP.ConvertItBack(strAlbum, True)
                objDEData.Artist = objBSP.ConvertItBack(strArtist, True)
                objDEData.BitRate = intBitRate
                objDEData.Duration = dbDuration
                objDEData.Genre = objBSP.ConvertItBack(strGenre, True)
                objDEData.PageCount = intPageCount
                CreateMultimedia = objDEData.CreateMultimedia()
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateFileLoc method
        ' Purpose: Update file path, url and file location of file
        ' Out put: 0 or 1 (0 is success)
        Public Function UpdateFileLoc(ByVal strOldLoc As String, ByVal strNewLoc As String) As Integer
            UpdateFileLoc = 0
            Try
                UpdateFileLoc = objDEData.UpdateFileLoc(objBSP.ConvertItBack(strOldLoc, True), objBSP.ConvertItBack(strNewLoc, True))
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
                UpdateFileLoc = 1
            End Try
        End Function

        ' CreateCollectionRecord method
        ' Purpose: Create record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function CreateCollectionRecord(ByVal strDescriptionCol As String) As Integer
            Try
                objDEData.Collection = objBSP.ConvertItBack(strCollection)
                objDEData.Description = objBSP.ConvertItBack(strDescriptionCol)
                CreateCollectionRecord = objDEData.CreateCollectionRecord
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GroupCollection method
        ' Purpose: Create group record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function GroupCollection(ByVal strCollectionIDs As String) As Integer
            Try
                objDEData.CollectionID = intCollectionID
                GroupCollection = objDEData.GroupCollection(strCollectionIDs)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateCollection method
        ' Purpose: Create group record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function UpdateCollection() As Integer
            Try
                objDEData.CollectionID = intCollectionID
                objDEData.Collection = objBSP.ConvertItBack(strCollection)
                objDEData.Description = objBSP.ConvertItBack(strDescription)
                UpdateCollection = objDEData.UpdateCollection
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCollection method
        ' Purpose: Get all record in Collection
        ' Output: all record in Collection
        ' Creator: Tuanhv
        Public Function GetCollection() As DataTable
            Try
                GetCollection = objBCDBS.ConvertTable(objDEData.GetCollection)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetCollection method
        ' Purpose: Delete collection in table 
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function DeleteCollection() As Integer
            Try
                objDEData.CollectionID = intCollectionID
                DeleteCollection = objDEData.DeleteCollection
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateFileRecord method
        ' Purpose: Update information into edata file
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function UpdateFileRecord() As Integer
            UpdateFileRecord = 0
            Try
                objDEData.InitVariablesForEdataFile()
                objDEData.FileIDs = strIDs
                objDEData.FileSize = lngFileSize
                objDEData.UploadedDate = strUploadedDate
                objDEData.UploadedBy = objBSP.ConvertItBack(strUploadedBy, True)
                objDEData.FieldCode = strFieldCode
                objDEData.ItemID = intItemID
                objDEData.URL = objBSP.ConvertItBack(strURL)
                objDEData.PhysicalPath = objBSP.ConvertItBack(strPhysicalPath, True)
                objDEData.Existed = intExisted
                objDEData.FileLocation = objBSP.ConvertItBack(strFileLocation, True)
                objDEData.SecretLevel = intSecretLevel
                objDEData.DownloadTimes = intDownloadTimes
                objDEData.MediaType = intMediaType
                objDEData.Title = objBSP.ConvertItBack(strTitle, True)
                objDEData.Author = objBSP.ConvertItBack(strAuthor, True)
                objDEData.Description = objBSP.ConvertItBack(strDescription, True)
                objDEData.Locked = intLocked
                objDEData.LockedDate = strLockedDate
                objDEData.LockedBy = objBSP.ConvertItBack(strLockedBy, True)
                objDEData.LastModifiedBy = objBSP.ConvertItBack(strLastModifiedBy, True)
                objDEData.ModifiedTimes = intModifiedTimes
                objDEData.Status = intStatus
                objDEData.Note = objBSP.ConvertItBack(strNote, True)
                objDEData.CollectionID = intCollectionID
                objDEData.Price = dblPrice
                objDEData.Currency = objBSP.ConvertItBack(strCurrency, True)
                objDEData.FileFormat = objBSP.ConvertItBack(strFileFormat, True)
                objDEData.Pagination = objBSP.ConvertItBack(strPagination, True)
                objDEData.Free = intFree
                objDEData.FileName = objBSP.ConvertItBack(strFileName, True)
                UpdateFileRecord = objDEData.UpdateFileRecord()
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                UpdateFileRecord = 1
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateEdelivFileRecord method
        ' Purpose: 
        ' Output: 
        ' Creator:
        Public Function UpdateEdelivFileRecord() As Integer
            Try
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetTotalOfFiles method
        ' Purpose: Get total number of files 
        ' Output: 
        ' Creator:
        Public Function GetTotalOfFiles() As DataTable
            Try
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' DeleteFiles method
        ' Purpose: Delete file infor 
        ' Output: 
        ' Creator:
        Public Function DeleteFiles() As Integer
            Try
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetGeneraInfor method
        ' Purpose: Get general infor of file (File Name, Size,...)
        ' Output: 
        ' Output: datatable result
        Public Function GetGeneralInfor(ByVal intMode As Int16, ByVal intListType As Int16, ByVal intViewMode As Int16, ByRef lngTotalRec As Long, Optional ByVal intType As Int16 = -1) As DataTable
            Dim tblTemp As DataTable
            Try
                objDEData.FileIDs = strIDs
                objDEData.StartID = lngStartID
                objDEData.PageSize = intPageSize
                objDEData.CollectionID = intCollectionID
                objDEData.Param = objBSP.ConvertItBack(strParam)
                tblTemp = objDEData.GetGeneralInfor(intMode, intListType, intViewMode, lngTotalRec, intType)
                GetGeneralInfor = objBCDBS.ConvertTable(tblTemp)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetEdataFile(ByVal strUserName As String, ByVal intID As Integer) As DataTable
            Try
                GetEdataFile = objDEData.GetEdataFile(strUserName, intID)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GeneralDelete(ByVal intMode As Int16, ByVal intHaveFieldCode As Int16, ByVal lngItemID As Long, ByVal strURL As String, ByVal strFieldName As String, ByVal strFieldCode As String, ByVal str856Content As String, ByVal str956Content As String) As Integer
            GeneralDelete = 0
            Try
                objDEData.FileID = lngID
                GeneralDelete = objDEData.GeneralDelete(intMode, intHaveFieldCode, lngItemID, objBSP.ConvertItBack(strURL), strFieldName, strFieldCode, objBSP.ConvertItBack(str856Content), objBSP.ConvertItBack(str956Content))
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                GeneralDelete = 1
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMediaInfor method
        ' Purpose: Get the media infor of file
        ' Output: datatable result
        ' Creator:
        Public Function GetMediaInfor() As DataTable
            Try
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMinIDByTopNum method
        ' Purpose: Get the min ID of the page having a top number
        ' Output: datatable result
        ' Creator:
        Public Function GetMaxIDByTopNum(ByVal intListType As Integer, ByVal lngTopNum As Long, Optional ByVal intFree As Integer = -1) As DataTable
            Try
                objDEData.Status = intStatus
                objDEData.Param = objBSP.ConvertItBack(strParam)
                objDEData.CollectionID = intCollectionID
                GetMaxIDByTopNum = objBCDBS.ConvertTable(objDEData.GetMaxIDByTopNum(intListType, lngTopNum, intFree))
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetFileLocations method
        ' Purpose: Get all file locations
        ' Output: datatable result
        ' Creator:
        Public Function GetFileLocations() As DataTable
            Try
                GetFileLocations = objDEData.GetFileLocations
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetDisplayTypes(ByVal intType As Integer, Optional ByVal intFree As Integer = -1) As DataTable
            Try
                GetDisplayTypes = objDEData.GetDisplayTypes(intType, intFree)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetItemInfor(ByVal strItemCode As String) As DataTable
            Try
                strItemCode = objBSP.ConvertItBack(strItemCode)
                GetItemInfor = objBCDBS.ConvertTable(objDEData.GetItemInfor(strItemCode))
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' ImportToField856 method
        ' Purpose: Import the value to the field856s (For attach a file to a Item)
        Public Function ImportEdataRec(ByVal intFormID As Integer, ByVal lngItemID As Long, ByVal str856 As String, ByVal str956 As String) As Integer
            Dim arrLabelStr() As String = {"", "", "", "", "", "", "", "", ""}
            Dim arr8561() As String = {"856"}
            Dim arr8562() As String = {str856}
            Dim arr9561() As String = {"956"}
            Dim arr9562() As String = {str956}

            Dim intStatus As Integer
            Try
                objBInput.RecID = lngItemID

                If Trim(str856) <> "" Then
                    objBInput.FieldName = arr8561
                    objBInput.FieldValue = arr8562
                    ImportEdataRec = objBInput.Update(intFormID, 0)
                End If
                If Trim(str956) <> "" Then
                    objBInput.FieldName = arr9561
                    objBInput.FieldValue = arr9562
                    ImportEdataRec = objBInput.Update(intFormID, 0)
                End If
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetItemDetailInfor(ByVal strItemIDs As String) As DataTable
            Try
                GetItemDetailInfor = objBCDBS.ConvertTable(objDEData.GetItemDetailInfor(strItemIDs))
                strErrorMsg = objDEData.ErrorMsg
                intErrorCode = objDEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' UpdateEdataCollection method
        ' Purpose: Update information into edata file
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function UpdateEdataCollection(ByVal strIDs As String, ByVal intCollectionID As Integer) As Integer
            Try
                UpdateEdataCollection = objDEData.UpdateEdataCollection(strIDs, intCollectionID)
                strErrorMsg = objDEData.ErrorMsg
                intErrorCode = objDEData.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' AttachEdata method
        ' Purpose: Attach file edata 
        ' Output: Return 1 if attach success else return 0
        ' Creator: Tuanhv
        Public Function AttachEdata(ByVal strItemCode As String, ByVal strFileIDSelect As String) As Integer
            Try
                Dim tblItemAttach As DataTable
                Dim tblEdataFile As DataTable
                Dim objLbCaJobs As Object
                Dim arrFieldName() As String
                Dim arrFieldValue() As String
                Dim intFormID As Integer = 0
                Dim strFielsEdataVal As String = ""
                Dim strCurrentEdataVal As String = ""
                Dim intRow As Integer = 0
                Dim intFree As Integer = 0
                ReDim arrFieldName(1)
                ReDim arrFieldValue(1)

                AttachEdata = 1
                tblItemAttach = objBCDBS.ConvertTable(objDEData.GetGenItemAttach(strItemCode))

                'Check Item with ItemCode
                If Not tblItemAttach Is Nothing Then
                    If tblItemAttach.Rows.Count > 0 Then
                        If Not IsDBNull(tblItemAttach.Rows(0).Item("ID")) Then
                            If tblItemAttach.Rows.Count > 0 Then
                                intFormID = CInt(tblItemAttach.Rows(0).Item("FORMID"))
                                intItemID = CInt(tblItemAttach.Rows(0).Item("ID"))

                                For intRow = 0 To tblItemAttach.Rows.Count - 1
                                    strCurrentEdataVal = strCurrentEdataVal & tblItemAttach.Rows(intRow).Item("Ind1") & tblItemAttach.Rows(intRow).Item("Ind2") & "::" & tblItemAttach.Rows(intRow).Item("Content") & "$&"
                                Next

                                tblEdataFile = objBCDBS.ConvertTable(objDEData.GetFileAttach(strFileIDSelect))
                                If Not tblEdataFile Is Nothing Then
                                    If tblEdataFile.Rows.Count > 0 Then
                                        Dim strURLPrefix As String = ""
                                        If CStr(tblEdataFile.Rows(0).Item("Free")) = "True" Then
                                            intFree = 1
                                        Else
                                            intFree = 0
                                        End If
                                        'Check edata data file
                                        strIDs = ""
                                        If intFree = 1 Then
                                            strURLPrefix = "Wdownload.aspx?FileID="

                                            For intRow = 0 To tblEdataFile.Rows.Count - 1
                                                strIDs = strIDs & CStr(tblEdataFile.Rows(intRow).Item("ID")) & ","
                                                strFielsEdataVal = strFielsEdataVal & "42::$u" & strURLPrefix & tblEdataFile.Rows(intRow).Item("ID") & "$&"
                                            Next

                                            'Get for update item
                                            arrFieldName(0) = "856"
                                            arrFieldValue(0) = strCurrentEdataVal & strFielsEdataVal
                                        Else
                                            For intRow = 0 To tblEdataFile.Rows.Count - 1
                                                strIDs = strIDs & CStr(tblEdataFile.Rows(intRow).Item("ID")) & ","
                                                strFielsEdataVal = strFielsEdataVal & "::$a" & tblEdataFile.Rows(intRow).Item("ID")

                                                ' Price
                                                If Not IsDBNull(tblEdataFile.Rows(intRow).Item("Price")) Then
                                                    If Not CDbl(tblEdataFile.Rows(intRow).Item("Price")) = 0 Then
                                                        strFielsEdataVal = strFielsEdataVal & "$b" & tblEdataFile.Rows(intRow).Item("Price")
                                                    End If
                                                End If

                                                ' Currecny 
                                                If Not IsDBNull(tblEdataFile.Rows(intRow).Item("Currency")) Then
                                                    If Not tblEdataFile.Rows(intRow).Item("Currency") = "" Then
                                                        strFielsEdataVal = strFielsEdataVal & "$c" & tblEdataFile.Rows(intRow).Item("Currency")
                                                    End If
                                                End If

                                                ' Note
                                                If Not IsDBNull(tblEdataFile.Rows(intRow).Item("Note")) Then
                                                    If Not tblEdataFile.Rows(intRow).Item("Note") = "" Then
                                                        strFielsEdataVal = strFielsEdataVal & "$d" & tblEdataFile.Rows(intRow).Item("Note")
                                                    End If
                                                End If

                                                ' Pagination
                                                If Not IsDBNull(tblEdataFile.Rows(intRow).Item("Pagination")) Then
                                                    If Not tblEdataFile.Rows(intRow).Item("Pagination") = "" Then
                                                        strFielsEdataVal = strFielsEdataVal & "$e" & tblEdataFile.Rows(intRow).Item("Pagination")
                                                    End If
                                                End If

                                                ' FileFormat
                                                If Not IsDBNull(tblEdataFile.Rows(intRow).Item("FileFormat")) Then
                                                    If Not tblEdataFile.Rows(intRow).Item("FileFormat") = "" Then
                                                        strFielsEdataVal = strFielsEdataVal & "$f" & tblEdataFile.Rows(intRow).Item("FileFormat")
                                                    End If
                                                End If
                                                strFielsEdataVal = strFielsEdataVal & "$&"
                                            Next
                                            'Get for update item
                                            arrFieldName(0) = "956"
                                            arrFieldValue(0) = strCurrentEdataVal & strFielsEdataVal
                                        End If

                                        If Len(strIDs) > 1 Then
                                            strIDs = Left(strIDs, Len(strIDs) - 1)
                                        End If

                                        'Update CAT_EDATA_FILE
                                        Call objDEData.UpdateEdataFile(strIDs, intItemID, arrFieldName(0))

                                        'Update ITEM
                                        objBInput.RecID = intItemID
                                        objBInput.FieldName = arrFieldName
                                        objBInput.FieldValue = arrFieldValue
                                        Call objBInput.Update(intFormID, 0)
                                    End If
                                End If
                            End If
                        Else
                            AttachEdata = 0
                        End If
                    End If
                Else
                    AttachEdata = 0
                End If
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' DetachFile method
        ' Purpose: Detach file edata 
        ' Output: Return 1 if attach success else return 0
        ' Creator: Tuanhv
        Public Function DetachFile(ByVal strFileIDSelect As String) As Integer
            Try
                DetachFile = objDEData.DetachFile(strFileIDSelect)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMetadataDef method
        ' Purpose: Get metadata define fields
        ' Output: Datatable 
        ' Creator: Oanhtn
        Public Function GetMetadataDef() As DataTable
            Try
                GetMetadataDef = objDEData.GetMetadataDef
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMetadata method
        ' Purpose: Get metadata of the selected object
        ' Output: Datatable 
        ' Creator: Oanhtn
        ' CreatedDate: 18/02/2005
        Public Function GetMetadata() As DataTable
            Try
                objDEData.FileID = lngID
                GetMetadata = objBCDBS.ConvertTable(objDEData.GetMetadata)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' DeleteMetadata method
        ' Purpose: Delete metadata of the selected object
        ' Creator: Oanhtn
        ' CreatedDate: 18/02/2005
        Public Sub DeleteMetadata()
            Try
                objDEData.FileID = lngID
                Call objDEData.DeleteMetadata()
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' UpdateMetadata method
        ' Purpose: Update metadata of the selected object
        ' Creator: Oanhtn
        ' CreatedDate: 18/02/2005
        Public Sub UpdateMetadata(ByVal strFieldIDs As String, ByVal strDisplayEntry As String)
            Dim strAccessEntry As String
            Try
                objDEData.FileID = lngID
                strDisplayEntry = objBSP.ConvertItBack(strDisplayEntry)
                strAccessEntry = objBSP.ProcessVal(strDisplayEntry)
                Call objDEData.UpdateMetadataOfObj(strFieldIDs, strDisplayEntry, strAccessEntry)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Sub ChangeItemType(ByVal intType As Integer)
            Try
                objDEData.FileIDs = strIDs
                Call objDEData.ChangeItemType(intType)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function GetEdataDubTitle(ByVal lngID As Long) As DataTable
            Try
                GetEdataDubTitle = objBCDBS.ConvertTable(objDEData.GetEdataDubTitle(lngID))
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub GetEdataStatistic(ByRef lngFreeCount As Long, ByRef lngChargeCount As Long, ByRef lngReqNum As Long, ByRef lngUserCount As Long, ByRef lngAccessNum As Long)
            Try
                Call objDEData.GetEdataStatistic(lngFreeCount, lngChargeCount, lngReqNum, lngUserCount, lngAccessNum)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function getItemFilesTableOfConents(Optional ByVal intType As Integer = 0, Optional ByVal strFormatID As String = ",4,") As DataTable
            Try
                objDEData.LibID = intLibID
                getItemFilesTableOfConents = objBCDBS.ConvertTable(objDEData.getItemFilesTableOfConents(intType, strFormatID))
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function getFilesByItemId() As DataTable
            Try
                objDEData.ItemID = ItemID
                getFilesByItemId = objBCDBS.ConvertTable(objDEData.getFilesByItemId)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function getTableOfConents() As DataTable
            Try
                objDEData.FileID = FileID
                objDEData.ParentID = ParentID
                getTableOfConents = objBCDBS.ConvertTable(objDEData.getTableOfConents)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function getTableOfConentsByID() As DataTable
            Try
                objDEData.TocID = TocID
                getTableOfConentsByID = objBCDBS.ConvertTable(objDEData.getTableOfConentsByID)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function getTableOfConentsByName() As DataTable
            Try
                objDEData.FileID = FileID
                objDEData.ParentID = ParentID
                objDEData.TocName = TocName
                getTableOfConentsByName = objBCDBS.ConvertTable(objDEData.getTableOfConentsByName)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' insertTableOfContent method
        ' Purpose: Insert information into table of content
        ' Input: Some row in metadata
        ' Output: Return id>0 if insert else return 0
        Public Function insertTableOfContent() As Integer
            Try
                With objDEData
                    .FileID = FileID
                    .ParentID = ParentID
                    .TocName = TocName
                    .TocNumOfPage = TocNumOfPage
                End With
                insertTableOfContent = objDEData.insertTableOfContent
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' deleteTableOfContent method
        ' Purpose: delete information into table of content
        ' Input: ID
        ' Output: Return 1 if delete else return 0
        Public Function deleteTableOfContent() As Integer
            Try
                With objDEData
                    .TocID = TocID
                    deleteTableOfContent = .deleteTableOfContent
                    intErrorCode = .ErrorCode
                    strErrorMsg = .ErrorMsg
                End With
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' updateTableOfContent method
        ' Purpose: update information into table of content
        ' Input: Some row in metadata
        ' Output: Return 1 if delete else return 0
        Public Function updateTableOfContent() As Integer
            Try
                With objDEData
                    .TocID = TocID
                    .TocName = TocName
                    .TocNumOfPage = TocNumOfPage
                    updateTableOfContent = .updateTableOfContent
                    intErrorCode = .ErrorCode
                    strErrorMsg = .ErrorMsg
                End With
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' updateTableOfContentByParentID method
        ' Purpose: update information into table of content by parentid
        ' Input: Some row in metadata
        ' Output: Return 1 if delete else return 0
        Public Function updateTableOfContentByParentID() As Integer
            Try
                With objDEData
                    .TocID = TocID
                    .ParentID = ParentID
                    updateTableOfContentByParentID = .updateTableOfContentByParentID
                    intErrorCode = .ErrorCode
                    strErrorMsg = .ErrorMsg
                End With
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' getCollectionByParentID method
        ' Purpose: Get collection by parentID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getCollectionByParentID() As DataTable
            Try
                objDEData.ParentID = ParentID
                objDEData.LibID = intLibID
                getCollectionByParentID = objBCDBS.ConvertTable(objDEData.getCollectionByParentID)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' deleteCollectionByCollectionID method
        ' Purpose: delete collection by CollectionID
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function deleteCollectionByCollectionID() As Integer
            Try
                With objDEData
                    .CollectionID = CollectionID
                    deleteCollectionByCollectionID = .deleteCollectionByCollectionID
                    intErrorCode = .ErrorCode
                    strErrorMsg = .ErrorMsg
                End With
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' insertItemCollection method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertItemCollection(Optional ByVal intAddNew As Integer = 0) As Integer
            Try
                With objDEData
                    .LibID = intLibID
                    .CollectionID = CollectionID
                    .ParentID = ParentID
                    .CollectionName = CollectionName
                    .CollectionDescription = CollectionDescription
                    .CollectionIsShow = CollectionIsShow
                    .CollectionCover = CollectionCover
                End With
                insertItemCollection = objDEData.insertItemCollection(intAddNew)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' insertItemCollection method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertCatDicCollection() As Integer
            Try
                With objDEData
                    .CollectionID = CollectionID
                    .ItemID = ItemID
                End With
                insertCatDicCollection = objDEData.insertCatDicCollection
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' updateCollectionFilter method
        ' Purpose: update information into table of content by parentid
        ' Input: Some row in metadata
        ' Output: Return 1 if insert else return 0
        Public Function updateCollectionFilter() As Integer
            Try
                With objDEData
                    .CollectionFilterID = CollectionFilterID
                    .CollectionID = CollectionID
                    updateCollectionFilter = .updateCollectionFilter
                    intErrorCode = .ErrorCode
                    strErrorMsg = .ErrorMsg
                End With
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' updateCollectionByParentID method
        ' Purpose: update information into table of content by parentid
        ' Input: Some row in metadata
        ' Output: Return 1 if insert else return 0
        Public Function updateCollectionByParentID() As Integer
            Try
                With objDEData
                    .CollectionID = CollectionID
                    .ParentID = ParentID
                    updateCollectionByParentID = .updateCollectionByParentID
                    intErrorCode = .ErrorCode
                    strErrorMsg = .ErrorMsg
                End With
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' getCollectionByCollectionID method
        ' Purpose: Get collection by Collection ID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getCollectionByCollectionID() As DataTable
            Try
                objDEData.CollectionID = CollectionID
                objDEData.LibID = intLibID
                getCollectionByCollectionID = objBCDBS.ConvertTable(objDEData.getCollectionByCollectionID)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' insertCollectionFilter method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertCollectionFilter() As Integer
            Try
                With objDEData
                    .CollectionID = CollectionID
                    .CollectionFilterBoolArr = CollectionFilterBoolArr
                    .CollectionFilterFieldArr = CollectionFilterFieldArr
                    .CollectionFilterValArr = CollectionFilterValArr
                    .CollectionFilterFromDate = CollectionFilterFromDate
                    .CollectionFilterToDate = CollectionFilterToDate
                    .CollectionFilterUsername = CollectionFilterUsername
                    .CollectionFilterDocType = CollectionFilterDocType
                End With
                insertCollectionFilter = objDEData.insertCollectionFilter
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function


        ' getCollectionfilterByCollectionID method
        ' Purpose: Get collection filter by collectionID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.23
        Public Function getCollectionfilterByCollectionID() As DataTable
            Try
                objDEData.CollectionID = CollectionID
                getCollectionfilterByCollectionID = objBCDBS.ConvertTable(objDEData.getCollectionfilterByCollectionID)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' getFilesFolder method
        ' Purpose: get all files folder
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.03
        Public Function getFilesFolder() As DataTable
            Try
                objDEData.FileLocation = FileFormat
                getFilesFolder = objBCDBS.ConvertTable(objDEData.getFilesFolder)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function CheckExitFileIn800s(ByVal strContent As String) As DataTable
            Try
                strContent = objBSP.ConvertItBack(strContent)
                CheckExitFileIn800s = objBCDBS.ConvertTable(objDEData.CheckExitFileIn800s(strContent))
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' getFilesFormat method
        ' Purpose:get files format
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.03
        Public Function getFilesFormat() As DataTable
            Try
                objDEData.FileFormat = FileFormat
                objDEData.LibID = intLibID
                getFilesFormat = objBCDBS.ConvertTable(objDEData.getFilesFormat)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' getCountFormat method
        ' Purpose: get count format list
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.03
        Public Function getCountFormat() As DataTable
            Try
                objDEData.LibID = intLibID
                getCountFormat = objBCDBS.ConvertTable(objDEData.getCountFormat)
                intErrorCode = objDEData.ErrorCode
                strErrorMsg = objDEData.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objBSP Is Nothing Then
                    objBSP.Dispose(True)
                    objBSP = Nothing
                End If
                If Not objDEData Is Nothing Then
                    objDEData.Dispose(True)
                    objDEData = Nothing
                End If
                If Not objBInput Is Nothing Then
                    objBInput.Dispose(True)
                    objBInput = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace