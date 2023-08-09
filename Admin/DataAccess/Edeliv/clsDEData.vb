' Name: clsDEFile
' Purpose: Management file information
' Creator: Oanhtn
' Created Date: 01/11/2004
' Modification History:

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Edeliv
    Public Class clsDEData
        Inherits clsDBase

        ' *******************************************************************************************************
        ' Declare Private variables
        ' *******************************************************************************************************
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


        'Private intID As Integer
        Private strUploadedDate As String
        Private strUploadedBy As String
        Private strFieldCode As String
        Private intItemID As String
        Private intParentID As Integer

        Private strURL As String
        Private strPhysicalPath As String
        Private intExisted As Integer
        Private intDownloadTimes As Long
        Private intLocked As Integer
        Private intModifiedTimes As Integer

        ' Edeliv infor
        Private strFileName As String
        Private dblPrice As Double
        Private strCurrency As String
        Private strPagination As String
        Private strFileFormat As String

        Private strParam As String = ""

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

        ' CollectionFilterBoolArr property
        Public Property CollectionFilterBoolArr() As String
            Get
                Return strCollectionFilterBoolArr
            End Get
            Set(ByVal Value As String)
                strCollectionFilterBoolArr = Value
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

        ' ParentID property
        Public Property ParentID() As Integer
            Get
                Return intParentID
            End Get
            Set(ByVal Value As Integer)
                intParentID = Value
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

        'Tuanhv File

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

        ' Free property
        Public Property Free() As Integer
            Get
                Return intFree
            End Get
            Set(ByVal Value As Integer)
                intFree = Value
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

        ' CreateEdataFile method
        ' Purpose: Insert information into edata file
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function CreateFileRecord() As Integer
            Dim strFieldInput As String = ""
            Dim strFieldValue As String = ""

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_INSERT_FILE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intFileSize", OracleType.Number)).Value = lngFileSize
                            .Parameters.Add(New OracleParameter("strUploadedDate", OracleType.VarChar, 30)).Value = strUploadedDate
                            .Parameters.Add(New OracleParameter("strUploadedBy", OracleType.VarChar, 50)).Value = strUploadedBy
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 250)).Value = strURL
                            .Parameters.Add(New OracleParameter("strPhysicalPath", OracleType.VarChar, 200)).Value = strPhysicalPath
                            .Parameters.Add(New OracleParameter("intExisted", OracleType.Number)).Value = intExisted
                            .Parameters.Add(New OracleParameter("strFileLocation", OracleType.VarChar, 150)).Value = strFileLocation
                            .Parameters.Add(New OracleParameter("intSecretLevel", OracleType.Number)).Value = intSecretLevel
                            .Parameters.Add(New OracleParameter("intDownloadTimes", OracleType.Number)).Value = intDownloadTimes
                            .Parameters.Add(New OracleParameter("intMediaType", OracleType.Number)).Value = intMediaType
                            .Parameters.Add(New OracleParameter("intLocked", OracleType.Number)).Value = intLocked
                            .Parameters.Add(New OracleParameter("strLockedDate", OracleType.VarChar, 30)).Value = strLockedDate
                            .Parameters.Add(New OracleParameter("strLockedBy", OracleType.VarChar, 50)).Value = strLockedBy
                            .Parameters.Add(New OracleParameter("strLastModifiedBy", OracleType.VarChar, 50)).Value = strLastModifiedBy
                            .Parameters.Add(New OracleParameter("intModifiedTimes", OracleType.Number)).Value = intModifiedTimes
                            .Parameters.Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 500)).Value = strNote
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .Parameters.Add(New OracleParameter("intFree", OracleType.Number)).Value = intFree
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 100)).Value = strFileName
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("strCurrency", OracleType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New OracleParameter("strFileFormat", OracleType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New OracleParameter("intFileID", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            CreateFileRecord = .Parameters.Item("intOutVal").Value
                            lngID = .Parameters.Item("intFileID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intFileSize", SqlDbType.Int)).Value = lngFileSize
                            .Parameters.Add(New SqlParameter("@strUploadedDate", SqlDbType.VarChar, 30)).Value = strUploadedDate
                            .Parameters.Add(New SqlParameter("@strUploadedBy", SqlDbType.VarChar, 50)).Value = strUploadedBy
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.NVarChar, 250)).Value = strURL
                            .Parameters.Add(New SqlParameter("@strPhysicalPath", SqlDbType.NVarChar, 200)).Value = strPhysicalPath
                            .Parameters.Add(New SqlParameter("@intExisted", SqlDbType.Int)).Value = intExisted
                            .Parameters.Add(New SqlParameter("@strFileLocation", SqlDbType.VarChar, 150)).Value = strFileLocation
                            .Parameters.Add(New SqlParameter("@intSecretLevel", SqlDbType.Int)).Value = intSecretLevel
                            .Parameters.Add(New SqlParameter("@intDownloadTimes", SqlDbType.Int)).Value = intDownloadTimes
                            .Parameters.Add(New SqlParameter("@intMediaType", SqlDbType.Int)).Value = intMediaType
                            .Parameters.Add(New SqlParameter("@intLocked", SqlDbType.Int)).Value = intLocked
                            .Parameters.Add(New SqlParameter("@strLockedDate", SqlDbType.VarChar, 30)).Value = strLockedDate
                            .Parameters.Add(New SqlParameter("@strLockedBy", SqlDbType.VarChar, 50)).Value = strLockedBy
                            .Parameters.Add(New SqlParameter("@strLastModifiedBy", SqlDbType.VarChar, 50)).Value = strLastModifiedBy
                            .Parameters.Add(New SqlParameter("@intModifiedTimes", SqlDbType.Int)).Value = intModifiedTimes
                            .Parameters.Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 500)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = intCollectionID
                            .Parameters.Add(New SqlParameter("@intFree", SqlDbType.Int)).Value = intFree
                            .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.NVarChar, 100)).Value = strFileName
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Money)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New SqlParameter("@strPagination", SqlDbType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New SqlParameter("@strFileFormat", SqlDbType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New SqlParameter("@intFileID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            CreateFileRecord = .Parameters.Item("@intOutVal").Value
                            lngID = .Parameters.Item("@intFileID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

            'Insert into Edata meta
            If strTitle <> "" Then
                strFieldInput = strFieldInput & strTitle & "&&,&&"
                strFieldValue = strFieldValue & "1" & "&&,&&"
            End If
            If strAuthor <> "" Then
                strFieldInput = strFieldInput & strAuthor & "&&,&&"
                strFieldValue = strFieldValue & "2" & "&&,&&"
            End If
            If strDescription <> "" Then
                strFieldInput = strFieldInput & strDescription & "&&,&&"
                strFieldValue = strFieldValue & "3" & "&&,&&"
            End If
            If strFieldInput <> "" Then
                CreateFileRecord = CreateMediaRecord(strFieldInput, strFieldValue, lngID)
            End If
        End Function

        ' CreateMetaData method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function CreateMediaRecord(ByVal strFieldInput As String, ByVal strFieldValue As String, ByVal intIDEdataFile As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_METADATA_INSERT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldInput", OracleType.VarChar, 1000)).Value = strFieldInput
                            .Parameters.Add(New OracleParameter("strFieldValue", OracleType.VarChar, 1000)).Value = strFieldValue
                            .Parameters.Add(New OracleParameter("intIDEdataFile", OracleType.Number)).Value = intIDEdataFile
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            CreateMediaRecord = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataMetaData_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldInput", SqlDbType.NVarChar, 1000)).Value = strFieldInput
                            .Parameters.Add(New SqlParameter("@strFieldValue", SqlDbType.NVarChar, 1000)).Value = strFieldValue
                            .Parameters.Add(New SqlParameter("@intIDEdataFile", SqlDbType.Int)).Value = intIDEdataFile
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            CreateMediaRecord = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' CreateMultimedia method
        ' Purpose: insert data multimedia 
        ' Input: Some information of multimedia
        ' Output: datatable result
        ' Create: Tuanhv
        Public Function CreateMultimedia() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_INSERT_MULTIMEDIA"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = lngID
                            .Parameters.Add(New OracleParameter("intBitmapType", OracleType.Number)).Value = intBitmapType
                            .Parameters.Add(New OracleParameter("strColorModel", OracleType.VarChar, 40)).Value = strColorModel
                            .Parameters.Add(New OracleParameter("intImgWidth", OracleType.Number)).Value = intImgWidth
                            .Parameters.Add(New OracleParameter("intImgHeight", OracleType.Number)).Value = intImgHeight
                            .Parameters.Add(New OracleParameter("intXdpi", OracleType.Number)).Value = intXdpi
                            .Parameters.Add(New OracleParameter("intYdpi", OracleType.Number)).Value = intYdpi
                            .Parameters.Add(New OracleParameter("intNoColorUsed", OracleType.Number)).Value = intNoColorUsed
                            .Parameters.Add(New OracleParameter("strAlbum", OracleType.VarChar, 128)).Value = strAlbum
                            .Parameters.Add(New OracleParameter("strArtist", OracleType.VarChar, 64)).Value = strArtist
                            .Parameters.Add(New OracleParameter("intBitRate", OracleType.Number)).Value = intBitRate
                            .Parameters.Add(New OracleParameter("dbDuration", OracleType.Float)).Value = dbDuration
                            .Parameters.Add(New OracleParameter("strGenre", OracleType.VarChar, 64)).Value = strGenre
                            .Parameters.Add(New OracleParameter("intPageCount", OracleType.Number)).Value = intPageCount
                            .ExecuteNonQuery()
                            CreateMultimedia = 0
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataMultiMedia_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = lngID
                            .Parameters.Add(New SqlParameter("@intBitmapType", SqlDbType.Int)).Value = intBitmapType
                            .Parameters.Add(New SqlParameter("@strColorModel", SqlDbType.VarChar, 40)).Value = strColorModel
                            .Parameters.Add(New SqlParameter("@intImgWidth", SqlDbType.Int)).Value = intImgWidth
                            .Parameters.Add(New SqlParameter("@intImgHeight", SqlDbType.Int)).Value = intImgHeight
                            .Parameters.Add(New SqlParameter("@intXdpi", SqlDbType.Int)).Value = intXdpi
                            .Parameters.Add(New SqlParameter("@intYdpi", SqlDbType.Int)).Value = intYdpi
                            .Parameters.Add(New SqlParameter("@intNoColorUsed", SqlDbType.Int)).Value = intNoColorUsed
                            .Parameters.Add(New SqlParameter("@strAlbum", SqlDbType.NVarChar, 128)).Value = strAlbum
                            .Parameters.Add(New SqlParameter("@strArtist", SqlDbType.NVarChar, 64)).Value = strArtist
                            .Parameters.Add(New SqlParameter("@intBitRate", SqlDbType.Int)).Value = intBitRate
                            .Parameters.Add(New SqlParameter("@dbDuration", SqlDbType.Float)).Value = dbDuration
                            .Parameters.Add(New SqlParameter("@strGenre", SqlDbType.NVarChar, 64)).Value = strGenre
                            .Parameters.Add(New SqlParameter("@intPageCount", SqlDbType.Int)).Value = intPageCount
                            .ExecuteNonQuery()
                            CreateMultimedia = 0

                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' CreateCollectionRecord method
        ' Purpose: Create record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function CreateCollectionRecord() As Integer
            CreateCollectionRecord = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_COLLECTION_CREATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strCollection", OracleType.VarChar, 255)).Value = strCollection
                            .Parameters.Add(New OracleParameter("strDescription", OracleType.VarChar, 255)).Value = strDescription
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            CreateCollectionRecord = 0
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataCollection_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strCollection", SqlDbType.NVarChar, 255)).Value = strCollection
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 255)).Value = strDescription
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            CreateCollectionRecord = 0
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GroupCollection method
        ' Purpose: Create group record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function GroupCollection(ByVal strCollectionIDs As String) As Integer
            GroupCollection = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_COLLECTION_UPDATE_MER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .Parameters.Add(New OracleParameter("strCollectionIDs", OracleType.VarChar, 255)).Value = strCollectionIDs
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            GroupCollection = 0
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataCollection_UpdMerge"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int, 255)).Value = intCollectionID
                            .Parameters.Add(New SqlParameter("@strCollectionIDs", SqlDbType.VarChar, 255)).Value = strCollectionIDs
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            GroupCollection = 0
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' UpdateCollection method
        ' Purpose: Create group record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function UpdateCollection() As Integer
            UpdateCollection = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_COLLECTION_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .Parameters.Add(New OracleParameter("strCollection", OracleType.VarChar, 255)).Value = strCollection
                            .Parameters.Add(New OracleParameter("strDescription", OracleType.VarChar, 255)).Value = strDescription
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            UpdateCollection = 0
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataCollection_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = intCollectionID
                            .Parameters.Add(New SqlParameter("@strCollection", SqlDbType.NVarChar, 255)).Value = strCollection
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 255)).Value = strDescription
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            UpdateCollection = 0
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetCollection method
        ' Purpose: Get record for Collection
        ' Output: 
        ' Creator: Tuanhv
        Public Function GetCollection() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_COLLECTION_GET"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetCollection = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataCollection_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetCollection = dsData.Tables("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' DeleteCollection method
        ' Purpose: Delete record for Collection
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function DeleteCollection() As Integer
            DeleteCollection = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_COLLECTION_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            DeleteCollection = 0
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataCollection_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = intCollectionID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            DeleteCollection = 0
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' UpdateFileRecord method
        ' Purpose: Update information into edata file
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function UpdateFileRecord() As Integer
            Dim strFieldInput As String = ""
            Dim strFieldValue As String = ""
            UpdateFileRecord = 0

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_FILE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strID", OracleType.VarChar, 1000)).Value = strIDs
                            .Parameters.Add(New OracleParameter("intFileSize", OracleType.Number)).Value = lngFileSize
                            .Parameters.Add(New OracleParameter("strUploadedDate", OracleType.VarChar, 30)).Value = strUploadedDate
                            .Parameters.Add(New OracleParameter("strUploadedBy", OracleType.VarChar, 50)).Value = strUploadedBy
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 250)).Value = strURL
                            .Parameters.Add(New OracleParameter("strPhysicalPath", OracleType.VarChar, 200)).Value = strPhysicalPath
                            .Parameters.Add(New OracleParameter("intExisted", OracleType.Number)).Value = intExisted
                            .Parameters.Add(New OracleParameter("strFileLocation", OracleType.VarChar, 150)).Value = strFileLocation
                            .Parameters.Add(New OracleParameter("intSecretLevel", OracleType.Number)).Value = intSecretLevel
                            .Parameters.Add(New OracleParameter("intDownloadTimes", OracleType.Number)).Value = intDownloadTimes
                            .Parameters.Add(New OracleParameter("intMediaType", OracleType.Number)).Value = intMediaType
                            .Parameters.Add(New OracleParameter("intLocked", OracleType.Number)).Value = intLocked
                            .Parameters.Add(New OracleParameter("strLockedDate", OracleType.VarChar, 30)).Value = strLockedDate
                            .Parameters.Add(New OracleParameter("strLockedBy", OracleType.VarChar, 50)).Value = strLockedBy
                            .Parameters.Add(New OracleParameter("strLastModifiedBy", OracleType.VarChar, 50)).Value = strLastModifiedBy
                            .Parameters.Add(New OracleParameter("intModifiedTimes", OracleType.Number)).Value = intModifiedTimes
                            .Parameters.Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                            .Parameters.Add(New OracleParameter("strNote", OracleType.VarChar, 500)).Value = strNote
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .Parameters.Add(New OracleParameter("intFree", OracleType.Number)).Value = intFree
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 100)).Value = strFileName
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("strCurrency", OracleType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New OracleParameter("strFileFormat", OracleType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            UpdateFileRecord = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            UpdateFileRecord = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strID", SqlDbType.VarChar, 1000)).Value = strIDs
                            .Parameters.Add(New SqlParameter("@intFileSize", SqlDbType.Int)).Value = lngFileSize
                            .Parameters.Add(New SqlParameter("@strUploadedDate", SqlDbType.VarChar, 30)).Value = strUploadedDate
                            .Parameters.Add(New SqlParameter("@strUploadedBy", SqlDbType.VarChar, 50)).Value = strUploadedBy
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.NVarChar, 250)).Value = strURL
                            .Parameters.Add(New SqlParameter("@strPhysicalPath", SqlDbType.NVarChar, 200)).Value = strPhysicalPath
                            .Parameters.Add(New SqlParameter("@intExisted", SqlDbType.Int)).Value = intExisted
                            .Parameters.Add(New SqlParameter("@strFileLocation", SqlDbType.VarChar, 150)).Value = strFileLocation
                            .Parameters.Add(New SqlParameter("@intSecretLevel", SqlDbType.Int)).Value = intSecretLevel
                            .Parameters.Add(New SqlParameter("@intDownloadTimes", SqlDbType.Int)).Value = intDownloadTimes
                            .Parameters.Add(New SqlParameter("@intMediaType", SqlDbType.Int)).Value = intMediaType
                            .Parameters.Add(New SqlParameter("@intLocked", SqlDbType.Int)).Value = intLocked
                            .Parameters.Add(New SqlParameter("@strLockedDate", SqlDbType.VarChar, 30)).Value = strLockedDate
                            .Parameters.Add(New SqlParameter("@strLockedBy", SqlDbType.VarChar, 50)).Value = strLockedBy
                            .Parameters.Add(New SqlParameter("@strLastModifiedBy", SqlDbType.VarChar, 50)).Value = strLastModifiedBy
                            .Parameters.Add(New SqlParameter("@intModifiedTimes", SqlDbType.Int)).Value = intModifiedTimes
                            .Parameters.Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                            .Parameters.Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 500)).Value = strNote
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = intCollectionID
                            .Parameters.Add(New SqlParameter("@intFree", SqlDbType.Int)).Value = intFree
                            .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.NVarChar, 100)).Value = strFileName
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Money)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New SqlParameter("@strPagination", SqlDbType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New SqlParameter("@strFileFormat", SqlDbType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output

                            .ExecuteNonQuery()

                            UpdateFileRecord = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            UpdateFileRecord = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()

            'Insert into Edata meta
            If strTitle <> "" Then
                strFieldInput = strFieldInput & "1" & "&&,&&"
                strFieldValue = strFieldValue & strTitle & "&&,&&"
            End If
            If strAuthor <> "" Then
                strFieldInput = strFieldInput & "2" & "&&,&&"
                strFieldValue = strFieldValue & strAuthor & "&&,&&"
            End If
            If strDescription <> "" Then
                strFieldInput = strFieldInput & "3" & "&&,&&"
                strFieldValue = strFieldValue & strDescription & "&&,&&"
            End If
            If strFieldInput <> "" Then
                UpdateFileRecord = UpdateMetaData(strFieldInput, strFieldValue, CLng(strIDs))
            End If
        End Function

        ' UpdateEdataFile method
        ' Purpose: Update information into edata file
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function UpdateEdataFile(ByVal strIDs As String, ByVal intItemID As Integer, ByVal strFieldCode As String) As Integer
            Dim strFieldInput As String = ""
            Dim strFieldValue As String = ""
            UpdateEdataFile = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_FILE_DETACH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strID", OracleType.VarChar, 200)).Value = strIDs
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = intItemID
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 20)).Value = strFieldCode
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            UpdateEdataFile = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_UpdDetach"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strID", SqlDbType.VarChar, 200)).Value = strIDs
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = intItemID
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 20)).Value = strFieldCode
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            UpdateEdataFile = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' UpdateEdataCollection method
        ' Purpose: Update information into edata file
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function UpdateEdataCollection(ByVal strIDs As String, ByVal intCollectionID As Integer) As Integer
            Dim strFieldInput As String = ""
            Dim strFieldValue As String = ""
            UpdateEdataCollection = 0
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_FILE_COLL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strID", OracleType.VarChar, 200)).Value = strIDs
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            UpdateEdataCollection = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spUdataFileCollectionId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strID", SqlDbType.VarChar, 200)).Value = strIDs
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = intCollectionID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            UpdateEdataCollection = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' UpdateFileLoc method
        ' Purpose: Update file path, url and file location of file
        ' Out put: 0 or 1 (0 is success)
        Public Function UpdateFileLoc(ByVal strOldLoc As String, ByVal strNewLoc As String) As Integer
            Call OpenConnection()
            UpdateFileLoc = 0
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_LOC"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strOldLoc", OracleType.VarChar, 100)).Value = strOldLoc
                            .Parameters.Add(New OracleParameter("strNewLoc", OracleType.VarChar, 100)).Value = strNewLoc
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            UpdateFileLoc = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            UpdateFileLoc = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_UpdLoc"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strOldLoc", SqlDbType.VarChar, 100)).Value = strOldLoc
                            .Parameters.Add(New SqlParameter("@strNewLoc", SqlDbType.VarChar, 100)).Value = strNewLoc
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            UpdateFileLoc = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            UpdateFileLoc = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' UpdateMetaData method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Changer some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function UpdateMetaData(ByVal strFieldInput As String, ByVal strFieldValue As String, ByVal intIDEdataFile As Integer) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_METADATA_UPDATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldInput", OracleType.VarChar, 1000)).Value = strFieldInput
                            .Parameters.Add(New OracleParameter("strFieldValue", OracleType.VarChar, 1000)).Value = strFieldValue
                            .Parameters.Add(New OracleParameter("intIDEdataFile", OracleType.Number)).Value = intIDEdataFile
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            UpdateMetaData = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataMetaData_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldInput", SqlDbType.NVarChar, 1000)).Value = strFieldInput
                            .Parameters.Add(New SqlParameter("@strFieldValue", SqlDbType.NVarChar, 1000)).Value = strFieldValue
                            .Parameters.Add(New SqlParameter("@intIDEdataFile", SqlDbType.Int)).Value = intIDEdataFile
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            UpdateMetaData = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' UpdateEdelivFileRecord method
        ' Purpose: 
        ' Output: 
        ' Creator:
        Public Function UpdateEdelivFileRecord() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_UPDATE_EDELIV_FILE_RECORD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_UPDATE_EDELIV_FILE_RECORD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetTotalOfFiles method
        ' Purpose: Get total number of files
        ' Output: 
        ' Creator:
        Public Function GetTotalOfFiles() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_TOTAL_OF_FILES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetTotalOfFiles = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_GET_TOTAL_OF_FILES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetTotalOfFiles = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' DeleteFiles method
        ' Purpose: Delete file infor 
        ' Output: 
        ' Creator:
        Public Function DeleteFiles() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_DELETE_FILES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_DELETE_FILES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetGeneraInfor method
        ' Purpose: Get general infor of file (File Name, Size,...)
        ' Output: datatable result
        ' Creator:
        Public Function GetGeneralInfor(ByVal intMode As Int16, ByVal intListType As Int16, ByVal intViewMode As Int16, ByRef lngTotalRec As Long, Optional ByVal intType As Int16 = -1) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_GENERAL_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("intMode", OracleType.Number)).Value = intMode
                            .Parameters.Add(New OracleParameter("intListType", OracleType.Number)).Value = intListType
                            .Parameters.Add(New OracleParameter("intViewMode", OracleType.Number)).Value = intViewMode
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 300)).Value = strIDs
                            .Parameters.Add(New OracleParameter("lngStartID", OracleType.Number)).Value = lngStartID
                            .Parameters.Add(New OracleParameter("intPageSize", OracleType.Number)).Value = intPageSize
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .Parameters.Add(New OracleParameter("strParam", OracleType.VarChar, 4000)).Value = strParam
                            .Parameters.Add(New OracleParameter("lngTotalRec", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetGeneralInfor = dsData.Tables("tblResult")
                            lngTotalRec = .Parameters("lngTotalRec").Value
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdata_SelInfor"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = intMode
                            .Parameters.Add(New SqlParameter("@intListType", SqlDbType.Int)).Value = intListType
                            .Parameters.Add(New SqlParameter("@intViewMode", SqlDbType.Int)).Value = intViewMode
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar)).Value = strIDs
                            .Parameters.Add(New SqlParameter("@lngStartID", SqlDbType.Int)).Value = lngStartID
                            .Parameters.Add(New SqlParameter("@intPageSize", SqlDbType.Int)).Value = intPageSize
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = intCollectionID
                            .Parameters.Add(New SqlParameter("@strParam", SqlDbType.VarChar, 4000)).Value = strParam
                            .Parameters.Add(New SqlParameter("@lngTotalRec", SqlDbType.Int)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetGeneralInfor = dsData.Tables("tblResult")
                            lngTotalRec = .Parameters("@lngTotalRec").Value
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' Purpose: Check, update, get cat_edata_file
        ' In: strUserName, intID
        ' Output: datatable result
        ' Creator: Sondp
        Public Function GetEdataFile(ByVal strUserName As String, ByVal intID As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_EDATAFILE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strUserName", OracleType.VarChar, 30)).Value = strUserName
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = intID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetEdataFile = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strUserName", SqlDbType.VarChar, 30)).Value = strUserName
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = intID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetEdataFile = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GeneralDelete(ByVal intMode As Int16, ByVal intHaveFieldCode As Int16, ByVal lngItemID As Long, ByVal strURL As String, ByVal strFieldName As String, ByVal strFieldCode As String, ByVal str856Content As String, ByVal str956Content As String) As Integer
            Call OpenConnection()
            GeneralDelete = 0
            Select Case UCase(strDBSerVer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GENERAL_DELETE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intMode", OracleType.Number)).Value = intMode
                            .Parameters.Add(New OracleParameter("intHaveFieldCode", OracleType.Number)).Value = intHaveFieldCode
                            .Parameters.Add(New OracleParameter("lngFileID", OracleType.Number)).Value = lngID
                            .Parameters.Add(New OracleParameter("lngItemID", OracleType.Number)).Value = lngItemID
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 30)).Value = strURL
                            .Parameters.Add(New OracleParameter("strFieldName", OracleType.VarChar, 5)).Value = strFieldName
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("str856Content", OracleType.VarChar, 100)).Value = str856Content
                            .Parameters.Add(New OracleParameter("str956Content", OracleType.VarChar, 100)).Value = str956Content
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                            GeneralDelete = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdata_DelGeneral"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intMode", SqlDbType.Int)).Value = intMode
                            .Parameters.Add(New SqlParameter("@intHaveFieldCode", SqlDbType.Int)).Value = intHaveFieldCode
                            .Parameters.Add(New SqlParameter("@lngFileID", SqlDbType.Int)).Value = lngID
                            .Parameters.Add(New SqlParameter("@lngItemID", SqlDbType.Int)).Value = lngItemID
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.VarChar, 30)).Value = strURL
                            .Parameters.Add(New SqlParameter("@strFieldName", SqlDbType.VarChar, 5)).Value = strFieldName
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New SqlParameter("@str856Content", SqlDbType.VarChar, 100)).Value = str856Content
                            .Parameters.Add(New SqlParameter("@str956Content", SqlDbType.VarChar, 100)).Value = str956Content
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                            GeneralDelete = 1
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetMinIDByTopNum method
        ' Purpose: Get the min ID of the page having a top number
        ' Output: datatable result
        ' Creator:
        Public Function GetMaxIDByTopNum(ByVal intListType As Integer, ByVal lngTopNum As Long, Optional ByVal intFree As Integer = -1) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_MAXID_BY_TOPNUM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intListType", OracleType.Number)).Value = intListType
                            .Parameters.Add(New OracleParameter("lngTopNum", OracleType.Number)).Value = lngTopNum
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = intCollectionID
                            .Parameters.Add(New OracleParameter("strParam", OracleType.VarChar)).Value = strParam
                            .Parameters.Add(New OracleParameter("intFree", OracleType.Number)).Value = intFree
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMaxIDByTopNum = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdata_SelMaxIdByTopnum"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intListType", SqlDbType.Int)).Value = intListType
                            .Parameters.Add(New SqlParameter("@lngTopNum", SqlDbType.Int)).Value = lngTopNum
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = intCollectionID
                            .Parameters.Add(New SqlParameter("@strParam", SqlDbType.VarChar)).Value = strParam
                            .Parameters.Add(New SqlParameter("@intFree", SqlDbType.Int)).Value = intFree
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetMaxIDByTopNum = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetItemInfor(ByVal strItemCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_ITEM"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strItemCode", SqlDbType.Int)).Value = strItemCode
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetItemInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelByCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.Int)).Value = strItemCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetItemInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetItemDetailInfor(ByVal strItemIDs As String) As DataTable
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "EDELIV.SP_EDATA_GET_ITEM_DETAILINFOR"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("strItemIDs", OracleType.VarChar, 1000)).Value = strItemIDs
                                .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                                oraDataAdapter.SelectCommand = oraCommand
                                oraDataAdapter.Fill(dsData, "tblItemDetailInfor")
                                GetItemDetailInfor = dsData.Tables("tblItemDetailInfor")
                                dsData.Tables.Remove("tblItemDetailInfor")
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With SqlCommand
                            .CommandText = "Lib_spMARCBibField_SelItemDetailInfor"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@strItemIDs", SqlDbType.VarChar)).Value = strItemIDs
                                SqlDataAdapter.SelectCommand = SqlCommand
                                SqlDataAdapter.Fill(dsData, "tblItemDetailInfor")
                                GetItemDetailInfor = dsData.Tables("tblItemDetailInfor")
                                dsData.Tables.Remove("tblItemDetailInfor")
                            Catch sqlClientEx As SqlException
                                strErrorMsg = sqlClientEx.Message.ToString
                                intErrorCode = sqlClientEx.Number
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                End Select
                Call CloseConnection()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        ' GetMediaInfor method
        ' Purpose: Get the media infor of file 
        ' Output: Database result
        ' Creator: 
        Public Function GetMediaInfor() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_MEDIA_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMediaInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "SP_GET_MEDIA_INFOR"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetMediaInfor = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' CheckExitFileIn800s method
        ' Purpose: Check file exit in 800s field
        ' Output: datatable result
        ' Creator:
        Public Function CheckExitFileIn800s(ByVal strContent As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spField800S_SelByContent"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strContent", SqlDbType.NVarChar, 500)).Value = strContent

                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            CheckExitFileIn800s = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Function GetDisplayTypes(ByVal intType As Integer, Optional ByVal intFree As Integer = -1) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_DISPLAY_TYPE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("intFree", OracleType.Number)).Value = intFree
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetDisplayTypes = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_splEdata_SelDisplayType"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@intFree", SqlDbType.Int)).Value = intFree
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetDisplayTypes = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetGenItemAttach method
        ' Purpose: Get gen information for attach
        ' Output: Datatable content information for attach
        ' Creator: Tuanhv
        Public Function GetGenItemAttach(ByVal strItemCode As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_ITEM_GET"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strItemCode", OracleType.VarChar, 20)).Value = strItemCode
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetGenItemAttach = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Lib_spItem_SelByItemCode"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strItemCode", SqlDbType.VarChar, 20)).Value = strItemCode
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetGenItemAttach = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetFileAttach method
        ' Purpose: Get all ID in table Edata File with ItemId is null
        ' Output: Datatable 
        ' Creator: Tuanhv
        Public Function GetFileAttach(ByVal strFileIDSelect As String) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_FILE_GET"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 200)).Value = strFileIDSelect
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFileAttach = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_SelByIds"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 200)).Value = strFileIDSelect
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFileAttach = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' DetachFile method
        ' Purpose: Detach record from Edata file
        ' Output: Return 1 if success else return 0
        ' Creator: Tuanhv
        Public Function DetachFile(ByVal strFileIDSelect As String) As Integer
            DetachFile = 1
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_DETACH"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strIDs", OracleType.VarChar, 200)).Value = strFileIDSelect
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            DetachFile = 0
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_Detach"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strIDs", SqlDbType.VarChar, 200)).Value = strFileIDSelect
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            DetachFile = 0
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetMetadataDef method
        ' Purpose: Get metadata define fields
        ' Output: Datatable 
        ' Creator: Oanhtn
        ' CreatedDate: 18/02/2005
        Public Function GetMetadataDef() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_METADATA_DEFIN"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMetadataDef = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataMetaDataDefin_SelAll"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetMetadataDef = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' GetMetadata method
        ' Purpose: Get metadata of the selected object
        ' Output: Datatable 
        ' Creator: Oanhtn
        ' CreatedDate: 18/02/2005
        Public Function GetMetadata() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_METADATA"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngObjID", OracleType.Number)).Value = lngID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetMetadata = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataMetaData_SelObjId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngObjID", SqlDbType.Int)).Value = lngID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetMetadata = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' DeleteMetadata method
        ' Purpose: Delete metadata of the selected object
        ' Creator: Oanhtn
        ' CreatedDate: 18/02/2005
        Public Sub DeleteMetadata()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_DELETE_METADATA"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngObjID", OracleType.Number)).Value = lngID
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataMetaData_DelByObjId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngObjID", SqlDbType.Int)).Value = lngID
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' UpdateMetadataOfObj method
        ' Purpose: Update metadata of the selected object
        ' Creator: Oanhtn
        ' CreatedDate: 18/02/2005
        Public Sub UpdateMetadataOfObj(ByVal strFieldIDs As String, ByVal strDisplayEntry As String, ByVal strAccessEntry As String)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_METADATA"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngObjID", OracleType.Number)).Value = lngID
                            .Parameters.Add(New OracleParameter("strFieldIDs", OracleType.VarChar)).Value = strFieldIDs
                            .Parameters.Add(New OracleParameter("strDisplayEntry", OracleType.VarChar)).Value = strDisplayEntry
                            .Parameters.Add(New OracleParameter("strAccessEntry", OracleType.VarChar)).Value = strAccessEntry
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataMetaData_InsOrUpd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngObjID", SqlDbType.Int)).Value = lngID
                            .Parameters.Add(New SqlParameter("@strFieldIDs", SqlDbType.VarChar, 100)).Value = strFieldIDs
                            .Parameters.Add(New SqlParameter("@strDisplayEntry", SqlDbType.NVarChar, 4000)).Value = strDisplayEntry
                            .Parameters.Add(New SqlParameter("@strAccessEntry", SqlDbType.NVarChar, 4000)).Value = strAccessEntry
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Sub ChangeItemType(ByVal intType As Integer)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_CHANGE_ITEM_TYPE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("strID", OracleType.VarChar, 1000)).Value = strIDs
                            .ExecuteNonQuery()
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_UpdChangeType"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.VarChar, 1000)).Value = intType
                            .Parameters.Add(New SqlParameter("@strID", SqlDbType.VarChar, 1000)).Value = strIDs
                            .ExecuteNonQuery()
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        Public Function GetEdataDubTitle(ByVal lngID As Long) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_DUB_TITLE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("lngID", OracleType.Number)).Value = lngID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetEdataDubTitle = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@lngID", SqlDbType.Int)).Value = lngID
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetEdataDubTitle = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        Public Sub GetEdataStatistic(ByRef lngFreeCount As Long, ByRef lngChargeCount As Long, ByRef lngReqNum As Long, ByRef lngUserCount As Long, ByRef lngAccessNum As Long)
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_STATISTIC"
                        .CommandType = CommandType.StoredProcedure
                        Try

                            .Parameters.Add(New OracleParameter("intFreeCount", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intChargeCount", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intNumReq", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intUserCount", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intDownloadTimes", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            lngFreeCount = .Parameters("intFreeCount").Value
                            lngChargeCount = .Parameters("intChargeCount").Value
                            lngReqNum = .Parameters("intNumReq").Value
                            lngUserCount = .Parameters("intUserCount").Value
                            lngAccessNum = .Parameters("intDownloadTimes").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdata_Statistic"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intFreeCount", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intChargeCount", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intNumReq", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intUserCount", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intDownloadTimes", SqlDbType.Int)).Direction = ParameterDirection.Output

                            .ExecuteNonQuery()

                            lngFreeCount = .Parameters("@intFreeCount").Value
                            lngChargeCount = .Parameters("@intChargeCount").Value
                            lngReqNum = .Parameters("@intNumReq").Value
                            lngUserCount = .Parameters("@intUserCount").Value
                            lngAccessNum = .Parameters("@intDownloadTimes").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Sub

        ' getFilesByItemId method
        ' Purpose: Get files from ItemID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getFilesByItemId() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_FILES_BY_ITEMID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getFilesByItemId = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFile_SelByItemId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getFilesByItemId = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' getFilesByItemId method
        ' Purpose: Get files from ItemID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getTableOfConentsByID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_TABLE_OF_CONTENTS_BY_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intTocID", OracleType.Number)).Value = TocID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getTableOfConentsByID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_SelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intTocID", SqlDbType.Int)).Value = TocID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getTableOfConentsByID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' getFilesByItemId method
        ' Purpose: Get files from ItemID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getTableOfConents() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_TABLE_OF_CONTENTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intFileId", OracleType.Number)).Value = FileID
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = ParentID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getTableOfConents = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_SelByFileIdAndParentId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intFileId", SqlDbType.Int)).Value = FileID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = ParentID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getTableOfConents = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' getFilesByItemId method
        ' Purpose: Get files from ItemID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getItemFilesTableOfConents(Optional ByVal intType As Integer = 0, Optional ByVal strFormatID As String = ",4,") As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_SELECT_ITEM_FILES_TABLE_OF_CONTENT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                            .Parameters.Add(New OracleParameter("strFormatID", OracleType.NVarChar, 50)).Value = strFormatID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getItemFilesTableOfConents = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                            .Parameters.Add(New SqlParameter("@strFormatID", SqlDbType.NVarChar, 50)).Value = strFormatID
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getItemFilesTableOfConents = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function



        ' getFilesByItemId method
        ' Purpose: Get files from ItemID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getTableOfConentsByName() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_TABLE_OF_CONTENTS_BY_NAME"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intFileId", OracleType.Number)).Value = FileID
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = ParentID
                            .Parameters.Add(New OracleParameter("strName", OracleType.NVarChar, 1000)).Value = TocName
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getTableOfConentsByName = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_SelByName"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intFileId", SqlDbType.Int)).Value = FileID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = ParentID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 1000)).Value = TocName
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getTableOfConentsByName = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' insertTableOfContent method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertTableOfContent() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_INSERT_TABLE_OF_CONTENT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intFileID", OracleType.Number)).Value = FileID
                            .Parameters.Add(New OracleParameter("intParentId", OracleType.Number)).Value = ParentID
                            .Parameters.Add(New OracleParameter("strName", OracleType.NVarChar, 1000)).Value = TocName
                            .Parameters.Add(New OracleParameter("intNumOfPage", OracleType.Number)).Value = TocNumOfPage
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertTableOfContent = .Parameters.Item("intID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intFileID", SqlDbType.Int)).Value = FileID
                            .Parameters.Add(New SqlParameter("@intParentId", SqlDbType.Int)).Value = ParentID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 1000)).Value = TocName
                            .Parameters.Add(New SqlParameter("@intNumOfPage", SqlDbType.Int)).Value = TocNumOfPage
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertTableOfContent = .Parameters.Item("@intID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' deleteTableOfContent method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function deleteTableOfContent() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_DELETE_TABLE_OF_CONTENTS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = TocID
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteTableOfContent = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = TocID
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteTableOfContent = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' deleteTableOfContent method
        ' Purpose: update information into table of content
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function updateTableOfContent() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_TABLE_OF_CONTENT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = TocID
                            .Parameters.Add(New OracleParameter("strName", OracleType.NVarChar, 1000)).Value = TocName
                            .Parameters.Add(New OracleParameter("intNumOfPage", OracleType.Number)).Value = TocNumOfPage
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateTableOfContent = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = TocID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 1000)).Value = TocName
                            .Parameters.Add(New SqlParameter("@intNumOfPage", SqlDbType.Int)).Value = TocNumOfPage
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateTableOfContent = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' updateTableOfContentByParentID method
        ' Purpose: update information into table of content by parentid
        ' Input: Some row in metadata
        ' Output: Return 1 if insert else return 0
        Public Function updateTableOfContentByParentID() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_TABLE_OF_CONTENT_BY_PARENTID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = TocID
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.NVarChar, 1000)).Value = ParentID
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateTableOfContentByParentID = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFileTableOfContent_UpdParentId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = TocID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.NVarChar, 1000)).Value = ParentID
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateTableOfContentByParentID = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        'Collection

        ' getCollectionByParentID method
        ' Purpose: Get collection by parentID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getCollectionByParentID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_ITEM_COLLECTION_BY_PARENTID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.Number)).Value = ParentID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getCollectionByParentID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemCollection_SelByParentId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.Int)).Value = ParentID
                            '.Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getCollectionByParentID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' deleteCollectionByCollectionID method
        ' Purpose: delete collection by CollectionID
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function deleteCollectionByCollectionID() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_DELETE_ITEM_COLLECTION_BY_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteCollectionByCollectionID = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemCollection_DelById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = CollectionID
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteCollectionByCollectionID = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' insertItemCollection method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertItemCollection(Optional ByVal intAddNew As Integer = 0) As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_INSERT_ITEM_COLLECTION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intAddNews", OracleType.Number)).Value = intAddNew
                            .Parameters.Add(New OracleParameter("intCollectionId", OracleType.Number)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("intParentId", OracleType.Number)).Value = ParentID
                            .Parameters.Add(New OracleParameter("strName", OracleType.NVarChar, 100)).Value = CollectionName
                            .Parameters.Add(New OracleParameter("strDescription", OracleType.NVarChar, 300)).Value = CollectionDescription
                            .Parameters.Add(New OracleParameter("bolIsShow", OracleType.Number)).Value = CollectionIsShow
                            .Parameters.Add(New OracleParameter("strCover", OracleType.NVarChar, 300)).Value = CollectionCover
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Direction = ParameterDirection.Output
                              .ExecuteNonQuery()
                            insertItemCollection = .Parameters.Item("intID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemCollection_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intAddNew", SqlDbType.Int)).Value = intAddNew
                            .Parameters.Add(New SqlParameter("@intCollectionId", SqlDbType.Int)).Value = CollectionID
                            .Parameters.Add(New SqlParameter("@intParentId", SqlDbType.Int)).Value = ParentID
                            .Parameters.Add(New SqlParameter("@strName", SqlDbType.NVarChar, 100)).Value = CollectionName
                            .Parameters.Add(New SqlParameter("@strDescription", SqlDbType.NVarChar, 300)).Value = CollectionDescription
                            .Parameters.Add(New SqlParameter("@bolIsShow", SqlDbType.Int)).Value = CollectionIsShow
                            .Parameters.Add(New SqlParameter("@strCover", SqlDbType.NVarChar, 300)).Value = CollectionCover
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertItemCollection = .Parameters.Item("@intID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' insertCollection method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertCatDicCollection() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_INSERT_CAT_DIC_COLLECTION"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionId", OracleType.Number)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("ItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertCatDicCollection = .Parameters.Item("intID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDic_Collection_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionId", SqlDbType.Int)).Value = CollectionID
                            .Parameters.Add(New SqlParameter("@ItemID", SqlDbType.Int)).Value = ItemID
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertCatDicCollection = .Parameters.Item("@intID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' updateCollectionFilter method
        ' Purpose: update information into table of content by parentid
        ' Input: Some row in metadata
        ' Output: Return 1 if insert else return 0
        Public Function updateCollectionFilter() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_CAT_DIC_COLLECTION_FILTER_BY_COLLECTIONID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = CollectionFilterID
                            .Parameters.Add(New OracleParameter("intCollectionId", OracleType.NVarChar, 1000)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateCollectionFilter = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDic_CollectionFilter_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = CollectionFilterID
                            .Parameters.Add(New SqlParameter("@intCollectionId", SqlDbType.NVarChar, 1000)).Value = CollectionID
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateCollectionFilter = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' updateCollectionFilter method
        ' Purpose: update information into table of content by parentid
        ' Input: Some row in metadata
        ' Output: Return 1 if insert else return 0
        Public Function updateCollectionByParentID() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_UPDATE_ITEM_COLLECTION_BY_PARENTID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("intParentID", OracleType.NVarChar, 1000)).Value = ParentID
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateCollectionByParentID = .Parameters.Item("intOutVal").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemCollection_UpdPrarentId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Value = CollectionID
                            .Parameters.Add(New SqlParameter("@intParentID", SqlDbType.NVarChar, 1000)).Value = ParentID
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            updateCollectionByParentID = .Parameters.Item("@intOutVal").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' getCollectionByCollectionID method
        ' Purpose: Get collection by Collection ID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.19
        Public Function getCollectionByCollectionID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_SELECT_ITEM_COLLECTION_BY_ID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionID", OracleType.Number)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getCollectionByCollectionID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemCollection_SelItemById"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionID", SqlDbType.Int)).Value = CollectionID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getCollectionByCollectionID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' insertCollectionFilter method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertCollectionFilter() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_INSERT_CAT_DIC_COLLECTION_FILTER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionId", OracleType.Number)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("strBoolArr", OracleType.NVarChar, 50)).Value = CollectionFilterBoolArr
                            .Parameters.Add(New OracleParameter("strFieldArr", OracleType.NVarChar, 50)).Value = CollectionFilterFieldArr
                            .Parameters.Add(New OracleParameter("strValArr", OracleType.NVarChar, 1000)).Value = CollectionFilterValArr
                            .Parameters.Add(New OracleParameter("strFromDate", OracleType.NVarChar, 20)).Value = CollectionFilterFromDate
                            .Parameters.Add(New OracleParameter("strToDate", OracleType.NVarChar, 20)).Value = CollectionFilterToDate
                            .Parameters.Add(New OracleParameter("strUsername", OracleType.NVarChar, 100)).Value = CollectionFilterUsername
                            .Parameters.Add(New OracleParameter("intDocType", OracleType.Number)).Value = CollectionFilterDocType
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertCollectionFilter = .Parameters.Item("intID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDic_CollectionFilter_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionId", SqlDbType.Int)).Value = CollectionID
                            .Parameters.Add(New SqlParameter("@strBoolArr", SqlDbType.NVarChar, 50)).Value = CollectionFilterBoolArr
                            .Parameters.Add(New SqlParameter("@strFieldArr", SqlDbType.NVarChar, 50)).Value = CollectionFilterFieldArr
                            .Parameters.Add(New SqlParameter("@strValArr", SqlDbType.NVarChar, 1000)).Value = CollectionFilterValArr
                            .Parameters.Add(New SqlParameter("@strFromDate", SqlDbType.NVarChar, 20)).Value = CollectionFilterFromDate
                            .Parameters.Add(New SqlParameter("@strToDate", SqlDbType.NVarChar, 20)).Value = CollectionFilterToDate
                            .Parameters.Add(New SqlParameter("@strUsername", SqlDbType.NVarChar, 100)).Value = CollectionFilterUsername
                            .Parameters.Add(New SqlParameter("@intDocType", SqlDbType.Int)).Value = CollectionFilterDocType
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertCollectionFilter = .Parameters.Item("@intID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' getCollectionfilterByCollectionID method
        ' Purpose: Get collection filter by collectionID
        ' Creator: PhuongTT
        ' CreatedDate: 2014.10.23
        Public Function getCollectionfilterByCollectionID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_SELECT_CAT_DIC_COLLECTION_FILTER_BY_COLLECTIONID"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intCollectionId", OracleType.Number)).Value = CollectionID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getCollectionfilterByCollectionID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spDic_CollectionFilter_SelByCollectionId"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intCollectionId", SqlDbType.Int)).Value = CollectionID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getCollectionfilterByCollectionID = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' getFilesFolder method
        ' Purpose: get all files folder
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.03
        Public Function getFilesFolder() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_SELECT_FILES_FOLDER"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intPath", OracleType.NVarChar, 300)).Value = FileLocation
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getFilesFolder = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spEdata_SelFilesFolder"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intPath", SqlDbType.NVarChar, 300)).Value = FileLocation
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getFilesFolder = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' getCountFormat method
        ' Purpose: get count format list
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.03
        Public Function getCountFormat() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_SELECT_COUNT_FORMAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getCountFormat = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spEdata_SelCountFormat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getCountFormat = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function

        ' getFilesFormat method
        ' Purpose: get files format
        ' Creator: PhuongTT
        ' CreatedDate: 2014.11.03
        Public Function getFilesFormat() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_SELECT_FILES_FORMAT"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intFormatID", OracleType.Number)).Value = FileFormat
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            getFilesFormat = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Cat_spEdata_SelFilesFormat"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intFormatID", SqlDbType.Int)).Value = FileFormat
                            .Parameters.Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                            sqlDataAdapter.SelectCommand = sqlCommand
                            sqlDataAdapter.Fill(dsData, "tblResult")
                            getFilesFormat = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' GetFileLocations method
        ' Purpose: Get all file locations
        ' Output: datatable result
        ' Creator:
        Public Function GetFileLocations() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_GET_FILE_LOCATIONS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
                            oraDataAdapter.Fill(dsData, "tblResult")
                            GetFileLocations = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataFile_SelAllLocation"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.Fill(dsData, "tblResult")
                            GetFileLocations = dsData.Tables("tblResult")
                            dsData.Tables.Remove("tblResult")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Call CloseConnection()
        End Function


        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    If Not oraConnection Is Nothing Then
                        oraConnection.Dispose()
                        oraConnection = Nothing
                    End If
                    If Not oraCommand Is Nothing Then
                        oraCommand.Dispose()
                        oraCommand = Nothing
                    End If
                    If Not oraDataAdapter Is Nothing Then
                        oraDataAdapter.Dispose()
                        oraDataAdapter = Nothing
                    End If
                    If Not SqlConnection Is Nothing Then
                        SqlConnection.Dispose()
                        SqlConnection = Nothing
                    End If
                    If Not SqlCommand Is Nothing Then
                        SqlCommand.Dispose()
                        SqlCommand = Nothing
                    End If
                    If Not SqlDataAdapter Is Nothing Then
                        SqlDataAdapter.Dispose()
                        SqlDataAdapter = Nothing
                    End If
                    If Not dsData Is Nothing Then
                        dsData.Dispose()
                        dsData = Nothing
                    End If
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace