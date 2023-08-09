Imports eMicLibOPAC.BusinessRules
Imports eMicLibOPAC.BusinessRules.OPAC
Imports eMicLibOPAC.BusinessRules.Common
Imports eMicLibOPAC.DataAccess
Imports eMicLibOPAC.DataAccess.OPAC

Namespace eMicLibOPAC.BusinessRules.OPAC
    Public Class clsBOPACILLOutGoingReq
        Inherits clsBBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private objDILLOut As New clsDOPACILLOutGoingReq
        Private objBSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem

        Private strRequestType As String = ""
        Private strCardNo As String = ""
        Private strPassWord As String = ""
        Private strValidDate As String = ""
        Private dblFee As Double
        Private strCurrentUnit As String = ""
        Private strAuthor As String = ""
        Private strTitle As String = ""
        Private strPublishDate As String = ""
        Private strOtherInfo As String = ""
        Private strLibrary As String = ""
        Private strChapterName As String = ""
        Private strChapterAuthor As String = ""
        Private strPublisher As String = ""
        Private intPagecount As Integer
        Private strVol As String = ""
        Private strVolNo As String = ""
        Private intType As Integer
        Private strPatronCode As String = ""
        Private strNeedBeforeDate As String = ""
        Private dblMaxCost As Double
        Private strCurrencyCode As String = ""
        Private strNote As String = ""
        Private strPubDate As String = ""
        Private strArticleAuthor As String = ""
        Private strArticleTitle As String = ""
        Private strPagination As String = ""

        Private strVerification As String = ""
        Private strSponsoringBody As String = ""
        Private strSeriesTitleNumber As String = ""
        Private strVolumeIssue As String = ""
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************        
        ' RequestType property
        Public Property RequestType() As String
            Get
                Return strRequestType
            End Get
            Set(ByVal Value As String)
                strRequestType = Value
            End Set
        End Property

        ' CardNo property
        Public Property CardNo() As String
            Get
                Return strCardNo
            End Get
            Set(ByVal Value As String)
                strCardNo = Value
            End Set
        End Property

        ' Password property
        Public Property Password() As String
            Get
                Return strPassWord
            End Get
            Set(ByVal Value As String)
                strPassWord = Value
            End Set
        End Property

        ' ValidDate property
        Public Property ValidDate() As String
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        ' Current Unit property
        Public Property CurrentUnit() As String
            Get
                Return strCurrentUnit
            End Get
            Set(ByVal Value As String)
                strCurrentUnit = Value
            End Set
        End Property

        ' Fee property
        Public Property Fee() As Double
            Get
                Return dblFee
            End Get
            Set(ByVal Value As Double)
                dblFee = Value
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

        ' Author property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                strTitle = Value
            End Set
        End Property

        ' PublishDate property
        Public Property PublishDate() As String
            Get
                Return strPublishDate
            End Get
            Set(ByVal Value As String)
                strPublishDate = Value
            End Set
        End Property

        ' OtherInfo property
        Public Property OtherInfo() As String
            Get
                Return strOtherInfo
            End Get
            Set(ByVal Value As String)
                strOtherInfo = Value
            End Set
        End Property

        ' Library property
        Public Property Library() As String
            Get
                Return strLibrary
            End Get
            Set(ByVal Value As String)
                strLibrary = Value
            End Set
        End Property

        ' ChapterName property
        Public Property ChapterName() As String
            Get
                Return strChapterName
            End Get
            Set(ByVal Value As String)
                strChapterName = Value
            End Set
        End Property


        ' ChapterAuthor property
        Public Property ChapterAuthor() As String
            Get
                Return strChapterAuthor
            End Get
            Set(ByVal Value As String)
                strChapterAuthor = Value
            End Set
        End Property

        ' Publisher property
        Public Property Publisher() As String
            Get
                Return strPublisher
            End Get
            Set(ByVal Value As String)
                strPublisher = Value
            End Set
        End Property

        ' Pagecount Public Property 
        Public Property Pagecount() As Integer
            Get
                Return intPagecount
            End Get
            Set(ByVal Value As Integer)
                intPagecount = Value
            End Set
        End Property

        Public Property Vol() As String
            Get
                Return strVol
            End Get
            Set(ByVal Value As String)
                strVol = Value
            End Set
        End Property

        ' VolNo property
        Public Property VolNo() As String
            Get
                Return strVolNo
            End Get
            Set(ByVal Value As String)
                strVolNo = Value
            End Set
        End Property

        ' Type property
        Public Property Type() As Integer
            Get
                Return intType
            End Get
            Set(ByVal Value As Integer)
                intType = Value
            End Set
        End Property
        ' PatronCode property
        Public Property PatronCode() As String
            Get
                Return strPatronCode
            End Get
            Set(ByVal Value As String)
                strPatronCode = Value
            End Set
        End Property
        ' NeedBeforeDate property
        Public Property NeedBeforeDate() As String
            Get
                Return strNeedBeforeDate
            End Get
            Set(ByVal Value As String)
                strNeedBeforeDate = Value
            End Set
        End Property
        ' MaxCost property
        Public Property MaxCost() As Double
            Get
                Return dblMaxCost
            End Get
            Set(ByVal Value As Double)
                dblMaxCost = Value
            End Set
        End Property
        ' CurrencyCode property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
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
        ' PubDate property
        Public Property PubDate() As String
            Get
                Return strPubDate
            End Get
            Set(ByVal Value As String)
                strPubDate = Value
            End Set
        End Property
        ' ArticleAuthor property
        Public Property ArticleAuthor() As String
            Get
                Return strArticleAuthor
            End Get
            Set(ByVal Value As String)
                strArticleAuthor = Value
            End Set
        End Property
        ' ArticleTitle property
        Public Property ArticleTitle() As String
            Get
                Return strArticleTitle
            End Get
            Set(ByVal Value As String)
                strArticleTitle = Value
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
        ' Verification property
        Public Property Verification() As String
            Get
                Return strVerification
            End Get
            Set(ByVal Value As String)
                strVerification = Value
            End Set
        End Property
        ' SponsoringBody property
        Public Property SponsoringBody() As String
            Get
                Return strSponsoringBody
            End Get
            Set(ByVal Value As String)
                strSponsoringBody = Value
            End Set
        End Property
        ' SeriesTitleNumber property
        Public Property SeriesTitleNumber() As String
            Get
                Return strSeriesTitleNumber
            End Get
            Set(ByVal Value As String)
                strSeriesTitleNumber = Value
            End Set
        End Property
        ' VolumeIssue property
        Public Property VolumeIssue() As String
            Get
                Return strVolumeIssue
            End Get
            Set(ByVal Value As String)
                strVolumeIssue = Value
            End Set
        End Property
        ' Initialize method
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

            ' Init objDAcqPurchaseOrder object
            objDILLOut.DBServer = strDBServer
            objDILLOut.ConnectionString = strConnectionString
            objDILLOut.Initialize()
        End Sub


        ' purpose : Create one ILLOutGoing Request
        ' Created by: dgsoft2016
        Public Function CreateRequest() As Integer
            Try
                objDILLOut.Type = intType
                objDILLOut.PatronCode = objBSP.ConvertItBack(strPatronCode)
                objDILLOut.Password = objBSP.ConvertItBack(strPassWord)
                objDILLOut.NeedBeforeDate = objBCDBS.ConvertDateBack(strNeedBeforeDate)
                objDILLOut.MaxCost = dblMaxCost
                objDILLOut.CurrencyCode = objBSP.ConvertItBack(strCurrencyCode)
                objDILLOut.Note = objBSP.ConvertItBack(strNote)
                objDILLOut.Title = objBSP.ConvertItBack(strTitle)
                objDILLOut.Author = objBSP.ConvertItBack(strAuthor)
                objDILLOut.PubDate = objBCDBS.ConvertDateBack(strPubDate)
                objDILLOut.ArticleAuthor = objBSP.ConvertItBack(strArticleAuthor)
                objDILLOut.ArticleTitle = objBSP.ConvertItBack(strArticleTitle)
                objDILLOut.Pagination = objBSP.ConvertItBack(strPagination)
                objDILLOut.Publisher = objBSP.ConvertItBack(strPublisher)
                objDILLOut.Verification = objBSP.ConvertItBack(strVerification)
                objDILLOut.SponsoringBody = objBSP.ConvertItBack(strSponsoringBody)
                objDILLOut.SeriesTitleNumber = objBSP.ConvertItBack(strSeriesTitleNumber)
                objDILLOut.VolumeIssue = objBSP.ConvertItBack(strVolumeIssue)
                CreateRequest = objDILLOut.CreateRequest
            Catch ex As Exception
                strErrorMsg = objDILLOut.ErrorMsg
            End Try
        End Function

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
                If Not objDILLOut Is Nothing Then
                    objDILLOut.Dispose(True)
                    objDILLOut = Nothing
                End If
            Finally
                MyBase.Dispose()
                Me.Dispose()
            End Try
        End Sub
    End Class
End Namespace