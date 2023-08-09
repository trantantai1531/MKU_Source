Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibAdmin.DataAccess.Catalogue
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

        Private intCollectionID As Integer
        Private strCollection As String
        'Private strDescription As String

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
        Private strCoverPicture As String = ""

        Private strAllowedFileExt As String
        Private strDeniedFileExt As String
        Private strLogo As String
        Private strPrefix As String
        Private lngMaxsize As Long
        Private intDataTypeID As Integer

        ' *****************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *****************************************************************************************************
        ' CoverPicture property
        Public Property CoverPicture() As String
            Get
                Return strCoverPicture
            End Get
            Set(ByVal Value As String)
                strCoverPicture = Value
            End Set
        End Property

        ' AllowedFileExt property
        Public Property AllowedFileExt() As String
            Get
                Return strAllowedFileExt
            End Get
            Set(ByVal Value As String)
                strAllowedFileExt = Value
            End Set
        End Property

        ' DeniedFileExt property
        Public Property DeniedFileExt() As String
            Get
                Return strDeniedFileExt
            End Get
            Set(ByVal Value As String)
                strDeniedFileExt = Value
            End Set
        End Property

        ' Logo property
        Public Property Logo() As String
            Get
                Return strLogo
            End Get
            Set(ByVal Value As String)
                strLogo = Value
            End Set
        End Property

        ' Prefix property
        Public Property Prefix() As String
            Get
                Return strPrefix
            End Get
            Set(ByVal Value As String)
                strPrefix = Value
            End Set
        End Property

        ' Maxsize property
        Public Property Maxsize() As Long
            Get
                Return lngMaxsize
            End Get
            Set(ByVal Value As Long)
                lngMaxsize = Value
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
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 128)).Value = strURL
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
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 30)).Value = strFileName
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("strCurrency", OracleType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New OracleParameter("strFileFormat", OracleType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New OracleParameter("intFileID", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
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
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.NVarChar, 128)).Value = strURL
                            .Parameters.Add(New SqlParameter("@strPhysicalPath", SqlDbType.VarChar, 200)).Value = strPhysicalPath
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
                            .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.VarChar, 30)).Value = strFileName
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Money)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New SqlParameter("@strPagination", SqlDbType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New SqlParameter("@strFileFormat", SqlDbType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New SqlParameter("@intFileID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output
                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            oraDataAdapter.SelectCommand = oraCommand
                            .ExecuteNonQuery()
                            CreateMediaRecord = .Parameters.Item("@intOutVal").Value
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
                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 128)).Value = strURL
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
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 30)).Value = strFileName
                            .Parameters.Add(New OracleParameter("dblPrice", OracleType.Float)).Value = dblPrice
                            .Parameters.Add(New OracleParameter("strCurrency", OracleType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New OracleParameter("strFileFormat", OracleType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New OracleParameter("intOutVal", OracleType.Number)).Direction = ParameterDirection.Output
                            oraDataAdapter.SelectCommand = oraCommand
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
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.NVarChar, 128)).Value = strURL
                            .Parameters.Add(New SqlParameter("@strPhysicalPath", SqlDbType.VarChar, 200)).Value = strPhysicalPath
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
                            .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.VarChar, 30)).Value = strFileName
                            .Parameters.Add(New SqlParameter("@dblPrice", SqlDbType.Money)).Value = dblPrice
                            .Parameters.Add(New SqlParameter("@strCurrency", SqlDbType.VarChar, 50)).Value = strCurrency
                            .Parameters.Add(New SqlParameter("@strPagination", SqlDbType.VarChar, 50)).Value = strPagination
                            .Parameters.Add(New SqlParameter("@strFileFormat", SqlDbType.VarChar, 50)).Value = strFileFormat

                            .Parameters.Add(New SqlParameter("@intOutVal", SqlDbType.Int)).Direction = ParameterDirection.Output

                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            oraDataAdapter.SelectCommand = oraCommand
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
                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            oraDataAdapter.SelectCommand = oraCommand
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
                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            oraDataAdapter.SelectCommand = oraCommand
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
                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            oraDataAdapter.SelectCommand = oraCommand
                            .ExecuteNonQuery()
                            UpdateMetaData = .Parameters.Item("@intOutVal").Value
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
                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            oraDataAdapter.SelectCommand = oraCommand
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
                            SqlDataAdapter.SelectCommand = SqlCommand
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
                            .CommandText = "SP_EDATA_GET_ITEM_DETAILINFOR"
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

        Public Function GetDisplayTypes(ByVal intType As Integer) As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_GET_DISPLAY_TYPE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("intType", OracleType.Number)).Value = intType
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
                            oraDataAdapter.SelectCommand = oraCommand
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
                            SqlDataAdapter.SelectCommand = SqlCommand
                            SqlDataAdapter.SelectCommand = SqlCommand
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

        ' Add method
        ' Purpose: Add new electronic data
        Public Sub Add()
            Modify()
            Exit Sub

            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_EDATA_PARAMETER_INS"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("strPhysicalPath", OracleType.VarChar, 100)).Value = strPhysicalPath
                            .Parameters.Add(New OracleParameter("strAllowedFileExt", OracleType.VarChar)).Value = strAllowedFileExt
                            .Parameters.Add(New OracleParameter("strDeniedFileExt", OracleType.VarChar, 100)).Value = strDeniedFileExt
                            .Parameters.Add(New OracleParameter("strLogo", OracleType.VarChar, 100)).Value = strLogo
                            .Parameters.Add(New OracleParameter("strPrefix", OracleType.VarChar, 5)).Value = strPrefix
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 100)).Value = strURL
                            .Parameters.Add(New OracleParameter("lngMaxSize", OracleType.Number)).Value = lngMaxsize
                            .Parameters.Add(New OracleParameter("strSQL", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            strSQLStatement = .Parameters("strSQL").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataParameter_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode & ""
                            .Parameters.Add(New SqlParameter("@strPhysicalPath", SqlDbType.NVarChar, 100)).Value = strPhysicalPath & ""
                            .Parameters.Add(New SqlParameter("@strAllowedFileExt", SqlDbType.VarChar, 100)).Value = strAllowedFileExt & ""
                            .Parameters.Add(New SqlParameter("@strDeniedFileExt", SqlDbType.VarChar, 100)).Value = strDeniedFileExt & ""
                            .Parameters.Add(New SqlParameter("@strLogo", SqlDbType.NVarChar, 100)).Value = strLogo & ""
                            .Parameters.Add(New SqlParameter("@strPrefix", SqlDbType.NVarChar, 5)).Value = strPrefix & ""
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.NVarChar, 100)).Value = strURL & ""
                            .Parameters.Add(New SqlParameter("@lngMaxSize", SqlDbType.Int)).Value = lngMaxsize
                            .Parameters.Add(New SqlParameter("@strSQL", SqlDbType.NVarChar, 4000)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            strSQLStatement = .Parameters("@strSQL").Value
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

        ' Modify method
        ' Purpose: Modify the information of the current edata
        Public Sub Modify()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_EDATA_PARAMETER_UPD"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("strPhysicalPath", OracleType.VarChar, 100)).Value = strPhysicalPath
                            .Parameters.Add(New OracleParameter("strAllowedFileExt", OracleType.VarChar)).Value = strAllowedFileExt
                            .Parameters.Add(New OracleParameter("strDeniedFileExt", OracleType.VarChar, 100)).Value = strDeniedFileExt
                            .Parameters.Add(New OracleParameter("strLogo", OracleType.VarChar, 100)).Value = strLogo
                            .Parameters.Add(New OracleParameter("strPrefix", OracleType.VarChar, 5)).Value = strPrefix
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 100)).Value = strURL
                            .Parameters.Add(New OracleParameter("lngMaxSize", OracleType.Number)).Value = lngMaxsize
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
                        .CommandText = "Cat_spEdataParameter_Upd"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                            .Parameters.Add(New SqlParameter("@strPhysicalPath", SqlDbType.NVarChar)).Value = strPhysicalPath
                            .Parameters.Add(New SqlParameter("@strAllowedFileExt", SqlDbType.VarChar)).Value = strAllowedFileExt
                            .Parameters.Add(New SqlParameter("@strDeniedFileExt", SqlDbType.VarChar)).Value = strDeniedFileExt
                            .Parameters.Add(New SqlParameter("@strLogo", SqlDbType.NVarChar)).Value = strLogo
                            .Parameters.Add(New SqlParameter("@strPrefix", SqlDbType.NVarChar)).Value = strPrefix
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.NVarChar)).Value = strURL
                            .Parameters.Add(New SqlParameter("@lngMaxSize", SqlDbType.Int)).Value = lngMaxsize
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

        ' Delete method
        ' Purpose: Delete the selected edata
        Public Sub Delete()
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_EDATA_PARAMETER_DEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode
                            .ExecuteNonQuery()
                            strSQLStatement = .Parameters("strSQL").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataParameter_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
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

        ' GetEDataParam method
        ' Purpose: Get all edata parameters
        ' Input: integer value of DataTypeID
        ' Output: datatable
        Public Function GetEDataParams() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_CAT_EDATA_PARAMETER_SEL"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 5)).Value = strFieldCode & ""
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblEDATAPARAMETER")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdataParameter_Sel"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar, 5)).Value = strFieldCode & ""
                            SqlDataAdapter = New SqlDataAdapter(SqlCommand)
                            SqlDataAdapter.Fill(dsData, "tblEDATAPARAMETER")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetEDataParams = dsData.Tables("tblEDATAPARAMETER")
            dsData.Tables.Remove("tblEDATAPARAMETER")
            Call CloseConnection()
        End Function

        ' CreateEData method
        ' Purpose: Add new electronic data
        Public Function CreateEData() As Long
            Call OpenConnection()
            Dim lngFileID As Long = 0
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_EDATA_CREATE"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("strFieldCode", OracleType.VarChar, 3)).Value = strFieldCode
                            .Parameters.Add(New OracleParameter("intDataTypeID", OracleType.Number)).Value = intDataTypeID
                            .Parameters.Add(New OracleParameter("strURL", OracleType.VarChar, 100)).Value = strURL
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.VarChar, 100)).Value = strFileName
                            .Parameters.Add(New OracleParameter("lngFileSize", OracleType.Number)).Value = lngFileSize
                            .Parameters.Add(New OracleParameter("strInputer", OracleType.VarChar, 30)).Value = strInputer
                            .Parameters.Add(New OracleParameter("intBitmapType", OracleType.Number)).Value = intBitmapType
                            .Parameters.Add(New OracleParameter("strColorModel", OracleType.VarChar, 20)).Value = strColorModel
                            .Parameters.Add(New OracleParameter("intImgWidth", OracleType.Number)).Value = intImgWidth
                            .Parameters.Add(New OracleParameter("intImgHeight", OracleType.Number)).Value = intImgHeight
                            .Parameters.Add(New OracleParameter("intXdpi", OracleType.Number)).Value = intXdpi
                            .Parameters.Add(New OracleParameter("intYdpi", OracleType.Number)).Value = intYdpi
                            .Parameters.Add(New OracleParameter("intNoColorUsed", OracleType.Number)).Value = intNoColorUsed
                            .Parameters.Add(New OracleParameter("intFileID", OracleType.Number)).Direction = ParameterDirection.Output
                            .Parameters.Add(New OracleParameter("strSQL", OracleType.VarChar, 4000)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            strSQLStatement = .Parameters("strSQL").Value
                            lngFileID = .Parameters("intFileID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Cat_spEdata_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@strFieldCode", SqlDbType.VarChar)).Value = strFieldCode
                            .Parameters.Add(New SqlParameter("@intDataTypeID", SqlDbType.Int)).Value = intDataTypeID
                            .Parameters.Add(New SqlParameter("@strURL", SqlDbType.VarChar)).Value = strURL
                            .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.VarChar)).Value = strFileName
                            .Parameters.Add(New SqlParameter("@lngFileSize", SqlDbType.Int)).Value = lngFileSize
                            .Parameters.Add(New SqlParameter("@strInputer", SqlDbType.NVarChar)).Value = strInputer
                            .Parameters.Add(New SqlParameter("@intBitmapType", SqlDbType.Int)).Value = intBitmapType
                            .Parameters.Add(New SqlParameter("@strColorModel", SqlDbType.VarChar)).Value = strColorModel
                            .Parameters.Add(New SqlParameter("@intImgWidth", SqlDbType.Int)).Value = intImgWidth
                            .Parameters.Add(New SqlParameter("@intImgHeight", SqlDbType.Int)).Value = intImgHeight
                            .Parameters.Add(New SqlParameter("@intXdpi", SqlDbType.Int)).Value = intXdpi
                            .Parameters.Add(New SqlParameter("@intYdpi", SqlDbType.Int)).Value = intYdpi
                            .Parameters.Add(New SqlParameter("@intNoColorUsed", SqlDbType.Int)).Value = intNoColorUsed
                            .Parameters.Add(New SqlParameter("@intFileID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .Parameters.Add(New SqlParameter("@strSQL", SqlDbType.NVarChar, 1000)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            strSQLStatement = .Parameters("@strSQL").Value
                            lngFileID = .Parameters("@intFileID").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            CreateEData = lngFileID
            Call CloseConnection()
        End Function

        ' insertItemFile method
        ' Purpose: Insert information into Metadata as string content field and value
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function insertItemFile() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_INSERT_ITEM_FILES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("strFileName", OracleType.NVarChar, 150)).Value = FileName
                            .Parameters.Add(New OracleParameter("intFormatID", OracleType.Number)).Value = MediaType
                            .Parameters.Add(New OracleParameter("intFileSize", OracleType.Number)).Value = FileSize
                            .Parameters.Add(New OracleParameter("bolExisted", OracleType.Number)).Value = Existed
                            .Parameters.Add(New OracleParameter("strPath", OracleType.NVarChar, 500)).Value = FileLocation
                            .Parameters.Add(New OracleParameter("intDownloadTimes", OracleType.Number)).Value = DownloadTimes
                            .Parameters.Add(New OracleParameter("strDateUpload", OracleType.NVarChar, 20)).Value = UploadedDate
                            .Parameters.Add(New OracleParameter("strOriginFile", OracleType.NVarChar, 10)).Value = FileFormat
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertItemFile = .Parameters.Item("intID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFile_Ins"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            .Parameters.Add(New SqlParameter("@strFileName", SqlDbType.NVarChar, 150)).Value = FileName
                            .Parameters.Add(New SqlParameter("@intFormatID", SqlDbType.Int)).Value = MediaType
                            .Parameters.Add(New SqlParameter("@intFileSize", SqlDbType.Int)).Value = FileSize
                            .Parameters.Add(New SqlParameter("@bolExisted", SqlDbType.Int)).Value = Existed
                            .Parameters.Add(New SqlParameter("@strPath", SqlDbType.NVarChar, 500)).Value = FileLocation
                            .Parameters.Add(New SqlParameter("@intDownloadTimes", SqlDbType.Int)).Value = DownloadTimes
                            .Parameters.Add(New SqlParameter("@strDateUpload", SqlDbType.NVarChar, 20)).Value = UploadedDate
                            .Parameters.Add(New SqlParameter("@strOriginFile", SqlDbType.NVarChar, 10)).Value = FileFormat
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            insertItemFile = .Parameters.Item("@intID").Value
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


        ' insertItemFile method
        ' Purpose: delete tblItemFile table by ItemId and pathFile
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function deleteItemFile() As Integer
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "EDELIV.SP_EDATA_DELETE_ITEM_FILES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("strPath", OracleType.NVarChar, 500)).Value = FileLocation
                            .Parameters.Add(New OracleParameter("intID", OracleType.Number)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteItemFile = .Parameters.Item("intID").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFile_Del"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            .Parameters.Add(New SqlParameter("@strPath", SqlDbType.NVarChar, 500)).Value = FileLocation
                            .Parameters.Add(New SqlParameter("@intID", SqlDbType.Int)).Direction = ParameterDirection.Output
                            .ExecuteNonQuery()
                            deleteItemFile = .Parameters.Item("@intID").Value
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

        ' GetItemFileByItemID method
        ' Purpose: Get all item file by ItemID
        ' Input: integer value of DataTypeID
        ' Output: datatable
        Public Function GetItemFileByItemID() As DataTable
            Call OpenConnection()
            Select Case UCase(strDBServer)
                Case "ORACLE"
                    With oraCommand
                        .CommandText = "CATALOGUE.SP_EDATA_SELECT_ITEM_FILES"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                            .Parameters.Add(New OracleParameter("tblName", OracleType.Cursor)).Direction = ParameterDirection.Output
                            oraDataAdapter = New OracleDataAdapter(oraCommand)
                            oraDataAdapter.Fill(dsData, "tblEDATAITEMFILE")
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "SQLSERVER"
                    With sqlCommand
                        .CommandText = "Lib_spItemFile_SelByItemIdOrderPath"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                            sqlDataAdapter = New SqlDataAdapter(sqlCommand)
                            sqlDataAdapter.Fill(dsData, "tblEDATAITEMFILE")
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            GetItemFileByItemID = dsData.Tables("tblEDATAITEMFILE")
            dsData.Tables.Remove("tblEDATAITEMFILE")
            Call CloseConnection()
        End Function

        ' updateCoverItem method
        ' Purpose: update cover for ITEM
        ' Input: Some row in metadata
        ' Output: Return 0 if insert else return 1
        Public Function updateCoverItem() As Integer
            Dim intResult As Integer = 0
            Try
                Call OpenConnection()
                Select Case UCase(strDBServer)
                    Case "ORACLE"
                        With oraCommand
                            .CommandText = "EDELIV.SP_CATA_ITEM_UPDATECOVER"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New OracleParameter("intItemID", OracleType.Number)).Value = ItemID
                                .Parameters.Add(New OracleParameter("CoverPicture", OracleType.VarChar, 300)).Value = CoverPicture
                                .ExecuteNonQuery()
                                intResult = 1
                            Catch OraEx As OracleException
                                strErrorMsg = OraEx.Message.ToString
                                intErrorCode = OraEx.Code
                            Finally
                                .Parameters.Clear()
                            End Try
                        End With
                    Case "SQLSERVER"
                        With sqlCommand
                            .CommandText = "Lib_spItem_UpdCover"
                            .CommandType = CommandType.StoredProcedure
                            Try
                                .Parameters.Add(New SqlParameter("@intItemID", SqlDbType.Int)).Value = ItemID
                                .Parameters.Add(New SqlParameter("@CoverPicture", SqlDbType.VarChar, 300)).Value = CoverPicture
                                .ExecuteNonQuery()
                                intResult = 1
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
            End Try
            Return intResult
        End Function
        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                    Call MyBase.Dispose(True)
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace