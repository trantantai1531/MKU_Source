Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACILLOutGoingReq
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************

        Private strRequestType As String
        Private strCardNo As String
        Private strPassWord As String
        Private strValidDate As String
        Private dblFee As Double
        Private strCurrentUnit As String
        Private strAuthor As String
        Private strTitle As String
        Private strPublishDate As String
        Private strOtherInfo As String
        Private strLibrary As String
        Private strChapterName As String
        Private strChapterAuthor As String
        Private strPublisher As String
        Private intPagecount As Integer
        Private strVol As String
        Private strVolNo As String
        Private intType As Integer
        Private strPatronCode As String
        Private strNeedBeforeDate As String
        Private dblMaxCost As Double
        Private strCurrencyCode As String
        Private strNote As String
        Private strPubDate As String
        Private strArticleAuthor As String
        Private strArticleTitle As String
        Private strPagination As String

        Private strVerification As String
        Private strSponsoringBody As String
        Private strSeriesTitleNumber As String
        Private strVolumeIssue As String
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
        ' *************************************************************************************************
        ' End declare properties
        ' IMPLEMENT METHODS HERE
        ' *************************************************************************************************

        ' purpose : Create one ILLOutGoing Request
        ' Created by: dgsoft2016
        Public Function CreateRequest() As Integer
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spIllOutgoingRequest_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@intType", SqlDbType.Int)).Value = intType
                                .Add(New SqlParameter("@strPatronCode", SqlDbType.VarChar, 20)).Value = strPatronCode
                                .Add(New SqlParameter("@strPassword", SqlDbType.VarChar, 20)).Value = strPassWord
                                .Add(New SqlParameter("@strNeedBeforeDate", SqlDbType.VarChar, 30)).Value = strNeedBeforeDate
                                .Add(New SqlParameter("@dblMaxCost", SqlDbType.Float)).Value = dblMaxCost
                                .Add(New SqlParameter("@strCurrencyCode", SqlDbType.VarChar, 10)).Value = strCurrencyCode
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 50)).Value = strNote
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 100)).Value = strTitle
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 100)).Value = strAuthor
                                .Add(New SqlParameter("@strPubDate", SqlDbType.VarChar, 30)).Value = strPubDate
                                .Add(New SqlParameter("@strArticleAuthor", SqlDbType.NVarChar, 100)).Value = strArticleAuthor
                                .Add(New SqlParameter("@strArticleTitle", SqlDbType.NVarChar, 100)).Value = strArticleTitle
                                .Add(New SqlParameter("@strPagination", SqlDbType.VarChar, 50)).Value = strPagination
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar, 100)).Value = strPublisher
                                .Add(New SqlParameter("@strVerification", SqlDbType.NVarChar, 100)).Value = strVerification
                                .Add(New SqlParameter("@strSponsoringBody", SqlDbType.NVarChar, 100)).Value = strSponsoringBody
                                .Add(New SqlParameter("@strSeriesTitleNumber", SqlDbType.VarChar, 20)).Value = strSeriesTitleNumber
                                .Add(New SqlParameter("@strVolumeIssue", SqlDbType.NVarChar, 100)).Value = strVolumeIssue
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateRequest = .Parameters("@intRetval").Value
                        Catch ex As SqlException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spIllOutgoingRequest_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("intType", OracleType.Number)).Value = intType
                                .Add(New OracleParameter("strPatronCode", OracleType.VarChar, 20)).Value = strPatronCode
                                .Add(New OracleParameter("strPassword", OracleType.VarChar, 20)).Value = strPassWord
                                .Add(New OracleParameter("strNeedBeforeDate", OracleType.VarChar, 20)).Value = strNeedBeforeDate
                                .Add(New OracleParameter("dblMaxCost", OracleType.Float)).Value = dblMaxCost
                                .Add(New OracleParameter("strCurrencyCode", OracleType.VarChar, 10)).Value = strCurrencyCode
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 50)).Value = strNote
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 100)).Value = strTitle
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                                .Add(New OracleParameter("strPubDate", OracleType.VarChar, 20)).Value = strPubDate
                                .Add(New OracleParameter("strArticleAuthor", OracleType.VarChar, 100)).Value = strArticleAuthor
                                .Add(New OracleParameter("strArticleTitle", OracleType.VarChar, 100)).Value = strArticleTitle
                                .Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                                .Add(New OracleParameter("strPublisher", OracleType.VarChar, 100)).Value = strPublisher
                                .Add(New OracleParameter("strVerification", OracleType.VarChar, 100)).Value = strVerification
                                .Add(New OracleParameter("strSponsoringBody", OracleType.VarChar, 100)).Value = strSponsoringBody
                                .Add(New OracleParameter("strSeriesTitleNumber", OracleType.VarChar, 20)).Value = strSeriesTitleNumber
                                .Add(New OracleParameter("strVolumeIssue", OracleType.VarChar, 100)).Value = strVolumeIssue
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateRequest = .Parameters("intRetval").Value
                        Catch ex As OracleException
                            strErrorMsg = ex.Message
                            intErrorCode = ex.Code
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
            End Select
            Me.CloseConnection()
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