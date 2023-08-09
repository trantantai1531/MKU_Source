Imports System
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACeMagazine
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private intId As Integer
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

        'Detail
        Private strFileName As String
        Private strXMLpath As String
        Private strThumnail As String
        Private intDownloadTimes As Integer
        Private dtmDateUpload As Object
        Private bolViewer As Boolean
        Private intFileSize As Integer
        Private strPath As String
        Private intPageNum As Integer
        Private intMagID As Integer

        
        Private objDOPACeMagazine As New clsDOPACeMagazine
        Private objBCDBS As New clsBCommonDBSystem
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        Public Property MagID() As Integer
            Get
                Return intMagID
            End Get
            Set(ByVal Value As Integer)
                intMagID = Value
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
        Public Property eMagNum() As String
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
        ' *****************************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' *****************************************************************************************************
        ' Initialize method
        Public Sub Initialize()
            ' Init objDOPACItem object
            objDOPACeMagazine.DBServer = strDBServer
            objDOPACeMagazine.ConnectionString = strConnectionString
            objDOPACeMagazine.Initialize()
            ' Init objBCDBS object
            objBCDBS.DBServer = strDBServer
            objBCDBS.ConnectionString = strConnectionString
            objBCDBS.InterfaceLanguage = strInterfaceLanguage
            objBCDBS.Initialize()
        End Sub

        ' Purpose: Get year of all magazine by ItemID
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetYearMagazineNumberByItemID() As DataTable
            objDOPACeMagazine.ItemID = ItemID
            GetYearMagazineNumberByItemID = objBCDBS.ConvertTable(objDOPACeMagazine.GetYearMagazineNumberByItemID, "Content")
        End Function

        ' Purpose: Get all magazine detail by ItemID
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailByYear(Optional ByVal intPage As Integer = 1, Optional ByVal intPageSize As Integer = 10) As DataTable
            objDOPACeMagazine.ItemID = ItemID
            objDOPACeMagazine.eYear = eYear
            GetMagazineNumberDetailByYear = objDOPACeMagazine.GetMagazineNumberDetailByYear(intPage, intPageSize)
        End Function

        ' Purpose: Get Total of all magazine detail by year
        ' Input: ItemID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailCount() As Integer
            objDOPACeMagazine.ItemID = ItemID
            objDOPACeMagazine.eYear = eYear
            GetMagazineNumberDetailCount = objDOPACeMagazine.GetMagazineNumberDetailCount
        End Function

        ' Purpose: Get all magazine detail by MagID
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailByMagID() As DataTable
            objDOPACeMagazine.MagID = MagID
            GetMagazineNumberDetailByMagID = objDOPACeMagazine.GetMagazineNumberDetailByMagID
        End Function

        ' Purpose: Get all magazine detail TOC by MagID
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailTOCByMagID() As DataTable
            objDOPACeMagazine.MagID = MagID
            GetMagazineNumberDetailTOCByMagID = objDOPACeMagazine.GetMagazineNumberDetailTOCByMagID
        End Function

        ' Purpose: Get all magazine detail Annotation by MagID
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberDetailAnnotationByMagID() As DataTable
            objDOPACeMagazine.MagID = MagID
            GetMagazineNumberDetailAnnotationByMagID = objDOPACeMagazine.GetMagazineNumberDetailAnnotationByMagID
        End Function

        ' Purpose: Get all magazine number home
        ' Input: MagID
        ' Output: DataTable
        ' Created by: PhuongTT
        Public Function GetMagazineNumberHome(Optional ByVal intLibID As Integer = 0) As DataTable
            GetMagazineNumberHome = objBCDBS.ConvertTable(objDOPACeMagazine.GetMagazineNumberHome(intLibID), "Content")
        End Function

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If isDisposing Then
                End If
                If Not objDOPACeMagazine Is Nothing Then
                    Call objDOPACeMagazine.Dispose(True)
                    objDOPACeMagazine = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    Call objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace