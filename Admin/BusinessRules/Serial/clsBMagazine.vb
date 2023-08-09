' Class: clsBMagazine
' Purpose: Management Magazine
' Creator: PhuongTT
' Created Date: 2014.12.02


Imports System
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.DataAccess.Serial

Namespace eMicLibAdmin.BusinessRules.Serial
    Public Class clsBMagazine
        Inherits clsBBase

        Private objBCDBS As New clsBCommonDBSystem
        Private objDMagazine As New clsDMagazine

        'Mag no
        Private intId As Integer
        Private intMagId As Integer
        Private inteYear As Integer
        Private inteMonth As Integer
        Private inteDay As Integer
        Private intItemID As Integer
        Private streNum As String
        Private intStatus As Integer
        Private strDescription As String
        Private struserName As String
        Private struserNameUpdate As String
        Private bolHome As Boolean

        'Mag no Detail
        Private strFileName As String
        Private strXMLpath As String
        Private strThumnail As String
        Private intDownloadTimes As Integer
        Private dtmDateUpload As Object
        Private bolViewer As Boolean
        Private intFileSize As Integer
        Private strPath As String
        Private intPageNum As Integer

        'TOC
        Private intSubjectId As Integer
        Private intAuthorId As Integer
        Private strOverview As String
        Private dblcoordinatesX As Double
        Private dblcoordinatesY As Double

        'CAT_DIC_KEYWORD-AUTHOR
        Private strDisplayEntry As String
        Private strAccessEntry As String
        Private intDicItemID As Integer
        Private strVietnameseAccent As String

        'TOC-Annotation
        Private DblaWidth As Double
        Private DblaHeight As Double
        Private strtitle As String
        Private strlnk As String
        Private intmagDetailId As Integer
        Private straId As String
        Private intLibID As String

        Public Property aId() As String
            Get
                Return straId
            End Get
            Set(ByVal Value As String)
                straId = Value
            End Set
        End Property
        Public Property magDetailId() As Integer
            Get
                Return intmagDetailId
            End Get
            Set(ByVal Value As Integer)
                intmagDetailId = Value
            End Set
        End Property
        Public Property aWidth() As Double
            Get
                Return DblaWidth
            End Get
            Set(ByVal Value As Double)
                DblaWidth = Value
            End Set
        End Property
        Public Property aHeight() As Double
            Get
                Return DblaHeight
            End Get
            Set(ByVal Value As Double)
                DblaHeight = Value
            End Set
        End Property
        Public Property title() As String
            Get
                Return strtitle
            End Get
            Set(ByVal Value As String)
                strtitle = Value
            End Set
        End Property
        Public Property lnk() As String
            Get
                Return strlnk
            End Get
            Set(ByVal Value As String)
                strlnk = Value
            End Set
        End Property

        Public Property DisplayEntry() As String
            Get
                Return strDisplayEntry
            End Get
            Set(ByVal Value As String)
                strDisplayEntry = Value
            End Set
        End Property
        Public Property AccessEntry() As String
            Get
                Return strAccessEntry
            End Get
            Set(ByVal Value As String)
                strAccessEntry = Value
            End Set
        End Property
        Public Property DicItemID() As Integer
            Get
                Return intDicItemID
            End Get
            Set(ByVal Value As Integer)
                intDicItemID = Value
            End Set
        End Property
        Public Property VietnameseAccent() As String
            Get
                Return strVietnameseAccent
            End Get
            Set(ByVal Value As String)
                strVietnameseAccent = Value
            End Set
        End Property

        Public Property SubjectId() As Integer
            Get
                Return intSubjectId
            End Get
            Set(ByVal Value As Integer)
                intSubjectId = Value
            End Set
        End Property
        Public Property AuthorId() As Integer
            Get
                Return intAuthorId
            End Get
            Set(ByVal Value As Integer)
                intAuthorId = Value
            End Set
        End Property
        Public Property Overview() As String
            Get
                Return strOverview
            End Get
            Set(ByVal Value As String)
                strOverview = Value
            End Set
        End Property

        Public Property coordinatesX() As Double
            Get
                Return dblcoordinatesX
            End Get
            Set(ByVal Value As Double)
                dblcoordinatesX = Value
            End Set
        End Property
        Public Property coordinatesY() As Double
            Get
                Return dblcoordinatesY
            End Get
            Set(ByVal Value As Double)
                dblcoordinatesY = Value
            End Set
        End Property

        Public Property MagId() As Integer
            Get
                Return intMagId
            End Get
            Set(ByVal Value As Integer)
                intMagId = Value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return intId
            End Get
            Set(ByVal Value As Integer)
                intId = Value
            End Set
        End Property
        Public Property eYear() As Integer
            Get
                Return inteYear
            End Get
            Set(ByVal Value As Integer)
                inteYear = Value
            End Set
        End Property
        Public Property eMonth() As Integer
            Get
                Return inteMonth
            End Get
            Set(ByVal Value As Integer)
                inteMonth = Value
            End Set
        End Property
        Public Property eDay() As Integer
            Get
                Return inteDay
            End Get
            Set(ByVal Value As Integer)
                inteDay = Value
            End Set
        End Property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property

        Public Property eNumMag() As String
            Get
                Return streNum
            End Get
            Set(ByVal Value As String)
                streNum = Value
            End Set
        End Property
        Public Property Status() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Return strDescription
            End Get
            Set(ByVal Value As String)
                strDescription = Value
            End Set
        End Property
        Public Property userName() As String
            Get
                Return struserName
            End Get
            Set(ByVal Value As String)
                struserName = Value
            End Set
        End Property
        Public Property userNameUpdate() As String
            Get
                Return struserNameUpdate
            End Get
            Set(ByVal Value As String)
                struserNameUpdate = Value
            End Set
        End Property
        Public Property Home() As Boolean
            Get
                Return bolHome
            End Get
            Set(ByVal Value As Boolean)
                bolHome = Value
            End Set
        End Property

        Public Property FileName() As String
            Get
                Return strFileName
            End Get
            Set(ByVal Value As String)
                strFileName = Value
            End Set
        End Property
        Public Property XMLpath() As String
            Get
                Return strXMLpath
            End Get
            Set(ByVal Value As String)
                strXMLpath = Value
            End Set
        End Property
        Public Property Thumnail() As String
            Get
                Return strThumnail
            End Get
            Set(ByVal Value As String)
                strThumnail = Value
            End Set
        End Property
        Public Property DownloadTimes() As Integer
            Get
                Return intDownloadTimes
            End Get
            Set(ByVal Value As Integer)
                intDownloadTimes = Value
            End Set
        End Property
        Public Property DateUpload() As Object
            Get
                Return dtmDateUpload
            End Get
            Set(ByVal Value As Object)
                dtmDateUpload = Value
            End Set
        End Property
        Public Property Viewer() As Boolean
            Get
                Return bolViewer
            End Get
            Set(ByVal Value As Boolean)
                bolViewer = Value
            End Set
        End Property
        Public Property FileSize() As Integer
            Get
                Return intFileSize
            End Get
            Set(ByVal Value As Integer)
                intFileSize = Value
            End Set
        End Property
        Public Property Path() As String
            Get
                Return strPath
            End Get
            Set(ByVal Value As String)
                strPath = Value
            End Set
        End Property
        Public Property PageNum() As Integer
            Get
                Return intPageNum
            End Get
            Set(ByVal Value As Integer)
                intPageNum = Value
            End Set
        End Property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property


        ' Initialize method
        ' Purpose: Init all necessary objects
        Public Overloads Sub Initialize()
            Try
                ' Init objDItemCollection object
                objDMagazine.DBServer = strDBServer
                objDMagazine.ConnectionString = strConnectionString
                Call objDMagazine.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                objBCDBS.ConnectionString = strConnectionString
                Call objBCDBS.Initialize()

            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
            End Try
        End Sub
        ' getAllSerialItems method
        ' Purpose: Get all the collection of items
        ' Creator: PhuongTT - 2014.12.01
        Public Function getAllSerialItems() As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.LibID = intLibID
                dt = objBCDBS.ConvertTable(objDMagazine.getAllSerialItems, "TITLE")
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function

        ' Method: getTOCByItemID  
        ' Purpose: Get list of Table of content by ItemID
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getAllMagazineByItemID() As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.ItemID = ItemID
                dt = objBCDBS.ConvertTable(objDMagazine.getAllMagazineByItemID, "Name")
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function

        ' Method: getMagazineByMagNo  
        ' Purpose: Check exist by mag number
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getMagazineByMagNo(ByVal strUpdateNumNew As String) As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.eNumMag = eNumMag
                objDMagazine.eYear = eYear
                dt = objDMagazine.getMagazineByMagNo(strUpdateNumNew)
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function

        ' Method: getMagazineByMagID  
        ' Purpose: get all magazine number detail by mag id
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getMagazineByMagID() As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.MagId = MagId
                dt = objDMagazine.getMagazineByMagID()
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function

        ' Method: getMagazineDetailByMagID  
        ' Purpose: get all magazine number detail by mag id
        ' Input: ItemID
        ' Output: DataTable result
        Public Function getMagazineDetailByMagID() As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.MagId = MagId
                dt = objDMagazine.getMagazineDetailByMagID()
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function

        ' updateMagazineDetai method
        ' Purpose: Update information into magazine detail
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function updateMagazineDetai(ByVal intUpdate As Integer) As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .MagId = MagId
                    .FileName = FileName
                    .Status = Status
                    .DownloadTimes = DownloadTimes
                    .FileSize = FileSize
                    .Path = Path
                    .PageNum = PageNum
                    intResult = .updateMagazineDetai(intUpdate)
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function



        ' insertMagazineNo method
        ' Purpose: Update information into magazine detail
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function insertMagazineNo() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .eYear = eYear
                    .eMonth = eMonth
                    .eDay = eDay
                    .ItemID = ItemID
                    .Description = Description
                    .eNumMag = eNumMag
                    .userName = userName
                    intResult = .insertMagazineNo()
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function

        ' updateMagazineNo method
        ' Purpose: Update information into magazine detail
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function updateMagazineNo() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .MagId = MagId
                    .eYear = eYear
                    .eMonth = eMonth
                    .eDay = eDay
                    .Description = Description
                    .eNumMag = eNumMag
                    .userNameUpdate = userNameUpdate
                    intResult = .updateMagazineNo()
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function


        ' deleteMagazineNo method
        ' Purpose: Delete (magazine - magazine detail)
        ' Input: Some row in metadata
        ' Output: Return o or 1
        Public Function deleteMagazineNo() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .MagId = MagId
                    intResult = .deleteMagazineNo()
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function


        ' Method: getAnnotationByMagID  
        ' Purpose: Get list of Table of content by MagDetailID
        ' Input: MagDetailID
        ' Output: DataTable result
        Public Function getAnnotationByMagID() As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.MagId = MagId
                dt = objDMagazine.getAnnotationByMagID()
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function


        ' Method: getManazineTOCByID  
        ' Purpose: Get list of Table of content by MagTOCID
        ' Input: MagDetailID
        ' Output: DataTable result
        Public Function getManazineTOCByID() As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.Id = Id
                dt = objDMagazine.getManazineTOCByID()
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function

        ' Method: getManazineTOCByMagDetailID  
        ' Purpose: Get list of Table of content by MagDetailID
        ' Input: MagDetailID
        ' Output: DataTable result
        Public Function getManazineTOCByMagDetailID() As DataTable
            Dim dt As DataTable = Nothing
            Try
                objDMagazine.MagId = MagId
                dt = objDMagazine.getManazineTOCByMagDetailID()
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return dt
        End Function



        ' insertMagazineTOC method
        ' Purpose: Insert information into magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function insertMagazineTOC() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .MagId = MagId
                    .SubjectId = SubjectId
                    .AuthorId = AuthorId
                    .Overview = Overview
                    .PageNum = PageNum
                    .userName = userName
                    .coordinatesX = coordinatesX
                    .coordinatesY = coordinatesY
                    intResult = .insertMagazineTOC
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function

        ' updateMagazineTOC method
        ' Purpose: update information into magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function updateMagazineTOC() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .Id = Id
                    .SubjectId = SubjectId
                    .AuthorId = AuthorId
                    .Overview = Overview
                    .PageNum = PageNum
                    .userNameUpdate = userNameUpdate
                    .coordinatesX = coordinatesX
                    .coordinatesY = coordinatesY
                    intResult = .updateMagazineTOC
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function


        ' deleteMagazineTOC method
        ' Purpose: delete magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function deleteMagazineTOC() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .Id = Id
                    intResult = .deleteMagazineTOC
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function

        ' insertMagazineTOCForKeyWord method
        ' Purpose: Insert information into Cat_tblDicKeyword
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function insertMagazineTOCForKeyWord() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .DisplayEntry = DisplayEntry
                    .AccessEntry = AccessEntry
                    .VietnameseAccent = VietnameseAccent
                    intResult = .insertMagazineTOCForKeyWord
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function



        ' insertMagazineTOCAuthor method
        ' Purpose: Insert information into Cat_tblDic_Author
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function insertMagazineTOCForAuthor() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .DisplayEntry = DisplayEntry
                    .AccessEntry = AccessEntry
                    .VietnameseAccent = VietnameseAccent
                    intResult = .insertMagazineTOCForAuthor
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function



        ' updateMagazineTOCAnnotation method
        ' Purpose: update information into magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function updateMagazineTOCAnnotation() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .magDetailId = magDetailId
                    .aId = aId
                    .coordinatesX = coordinatesX
                    .coordinatesY = coordinatesY
                    .aWidth = aWidth
                    .aHeight = aHeight
                    .title = title
                    .lnk = lnk
                    intResult = .updateMagazineTOCAnnotation
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function

        ' deleteMagazineTOCAnnotation method
        ' Purpose: delete magazine detail TOC
        ' Input: Some row in metadata
        ' Output: Return id
        Public Function deleteMagazineTOCAnnotation() As Integer
            Dim intResult As Integer = 0
            Try
                With objDMagazine
                    .magDetailId = magDetailId
                    .aId = aId
                    intResult = .deleteMagazineTOCAnnotation
                End With
                strErrorMsg = objDMagazine.ErrorMsg
                intErrorCode = objDMagazine.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
            Return intResult
        End Function


        ' Method: Dispose
        ' Release resource method
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objDMagazine Is Nothing Then
                    Call objDMagazine.Dispose(True)
                    objDMagazine = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Finally
                Call MyBase.Dispose()
                Call Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace