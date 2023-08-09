Imports System.Data
Imports System.Data.sqlClient
Imports System.Data.SqlDbType
Imports System.Data.OracleClient
Imports System.Data.OracleClient.OracleType

Namespace eMicLibOPAC.DataAccess.OPAC
    Public Class clsDOPACILLInComingReq
        Inherits clsDBase

        ' *************************************************************************************************
        ' Declare Private variables
        ' *************************************************************************************************
        Private blnAlert As Boolean
        Private strBarcode As String
        Private strCancelledDate As String
        Private intChargeableUnits As Integer
        Private strCheckedInDate As String
        Private strCheckedOutDate As String
        Private intCopyrightCompliance As Int16
        Private dblCost As Double
        Private strCurrencyCode As String
        Private strCurrencyCode1 As String
        Private strCurrencyCode2 As String
        Private strCurrencyCode3 As String
        Private intDelivConditionID As Int16
        Private blnDelivMode As Boolean
        Private strDueDate As String
        Private strEdelivMode As String
        Private strEDelivTSAddr As String
        Private strEmailReplyAddress As String
        Private strExpiryDate As String
        Private dblInsuredForCost As Double
        Private strInternalRefNumber As String
        Private intItemType As Int16
        Private intLoanTypeID As Int16
        Private dblMaxCost As Double
        Private intMedium As Int16
        Private strNeedBeforeDate As String
        Private strNote As String
        Private strPatronID As String
        Private strPatronName As String
        Private strPatronStatus As String
        Private blnPaymentProvided As Boolean
        Private intPaymentType As Int16
        Private intPriority As Int16
        Private strReceivedDate As String
        Private blnReciprocalAgreement As Boolean
        Private blnRenewable As Boolean
        Private intRenewals As Int32
        Private strRequestID As String
        Private strRespondDate As String
        Private strReturnedDate As String
        Private dblReturnInsuranceCost As Double
        Private intReturnLocID As Int16
        Private intServiceType As Int16
        Private strShippedDate As String
        Private intSoID As Integer
        Private intItemID As Integer
        Private strTitle As String
        Private intTransportationModeID As Int16
        Private blnWillPayFee As Boolean
        Private strCode As String = ""
        Private strCodeLib As String = ""
        Private strEmail As String
        Private strCardNo As String
        Private strValidDate As String
        Private bytPriority As Byte
        Private intStatus As Integer = 21
        ' ILLLibrary variables
        Private intLibID As Integer
        Private strAccountNumber As String
        Private strBillDelivBox As String
        Private strBillDelivCity As String
        Private strBillDelivCode As String
        Private intBillDelivCountry As String
        Private strBillDelivName As String
        Private strBillDelivRegion As String
        Private strBillDelivStreet As String
        Private strBillDelivXAddr As String
        Private blnDublicate As Boolean
        Private strLibraryName As String
        Private strLibrarySymbol As String
        Private strPostDelivBox As String
        Private strPostDelivCity As String
        Private strPostDelivCode As String
        Private intPostDelivCountry As Int16
        Private strPostDelivName As String = ""
        Private strPostDelivRegion As String = ""
        Private strPostDelivStreet As String = ""
        Private strPostDelivXAddr As String = ""
        Private strTelephone As String = ""
        ' IllReqItems variables
        Private blnRequestType As Boolean
        Private strCallNumber As String
        Private strAuthor As String
        Private strPlaceOfPub As String
        Private strPublisher As String = ""
        Private strSeriesTitleNumber As String
        Private strVolumeIssue As String
        Private strEdition As String
        Private strPubDate As String
        Private strComponentPubDate As String
        Private strArticleAuthor As String
        Private strArticleTitle As String
        Private strPagination As String
        Private strNationalBibNumber As String
        Private strISBN As String
        Private strISSN As String
        Private strSystemNumber As String
        Private strOtherNumbers As String
        Private strVerification As String
        Private intEncodingScheme As Integer
        ' ILLInComingReqBi variables
        ' ILLInComingReqDe variables        
        ' ILLInComingReqLog variables       
        ' *************************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' *************************************************************************************************
        ' Alert property
        Public Property Alert() As Boolean
            Get
                Return blnAlert
            End Get
            Set(ByVal Value As Boolean)
                blnAlert = Value
            End Set
        End Property
        ' Barcode property
        Public Property Barcode() As String
            Get
                Return strBarcode
            End Get
            Set(ByVal Value As String)
                strBarcode = Value
            End Set
        End Property
        ' CancelledDate property
        Public Property CancelledDate() As String
            Get
                Return strCancelledDate
            End Get
            Set(ByVal Value As String)
                strCancelledDate = Value
            End Set
        End Property
        ' ChargeableUnits property
        Public Property ChargeableUnits() As Integer
            Get
                Return intChargeableUnits
            End Get
            Set(ByVal Value As Integer)
                intChargeableUnits = Value
            End Set
        End Property
        ' CheckedInDate property
        Public Property CheckedInDate() As String
            Get
                Return strCheckedInDate
            End Get
            Set(ByVal Value As String)
                strCheckedInDate = Value
            End Set
        End Property
        ' CheckedOutDate property
        Public Property CheckedOutDate() As String
            Get
                Return strCheckedOutDate
            End Get
            Set(ByVal Value As String)
                strCheckedOutDate = Value
            End Set
        End Property
        ' CopyrightCompliance Property
        Public Property CopyrightCompliance() As Int16
            Get
                Return intCopyrightCompliance
            End Get
            Set(ByVal Value As Int16)
                intCopyrightCompliance = Value
            End Set
        End Property
        ' Cost property
        Public Property Cost() As Double
            Get
                Return dblCost
            End Get
            Set(ByVal Value As Double)
                dblCost = Value
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
        ' CurrencyCode1 property
        Public Property CurrencyCode1() As String
            Get
                Return strCurrencyCode1
            End Get
            Set(ByVal Value As String)
                strCurrencyCode1 = Value
            End Set
        End Property
        ' CurrencyCode2 property
        Public Property CurrencyCode2() As String
            Get
                Return strCurrencyCode2
            End Get
            Set(ByVal Value As String)
                strCurrencyCode2 = Value
            End Set
        End Property
        ' strCurrencyCode3 property
        Public Property CurrencyCode3() As String
            Get
                Return strCurrencyCode3
            End Get
            Set(ByVal Value As String)
                strCurrencyCode3 = Value
            End Set
        End Property
        ' DelivConditionID property
        Public Property DelivConditionID() As Int16
            Get
                Return intDelivConditionID
            End Get
            Set(ByVal Value As Int16)
                intDelivConditionID = Value
            End Set
        End Property
        ' DelivMode Property
        Public Property DelivMode() As Boolean
            Get
                Return blnDelivMode
            End Get
            Set(ByVal Value As Boolean)
                blnDelivMode = Value
            End Set
        End Property

        ' ExpiryDate property
        Public Property ExpiryDate() As String
            Get
                Return strExpiryDate
            End Get
            Set(ByVal Value As String)
                strExpiryDate = Value
            End Set
        End Property
        ' InsuredForCost property
        Public Property InsuredForCost() As Double
            Get
                Return dblInsuredForCost
            End Get
            Set(ByVal Value As Double)
                dblInsuredForCost = Value
            End Set
        End Property
        ' InternalRefNumber propery
        Public Property InternalRefNumber() As String
            Get
                Return strInternalRefNumber
            End Get
            Set(ByVal Value As String)
                strInternalRefNumber = Value
            End Set
        End Property

        ' LoanTypeID property
        Public Property LoanTypeID() As Int16
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Int16)
                intLoanTypeID = Value
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
        ' Medium property
        Public Property Medium() As Int16
            Get
                Return intMedium
            End Get
            Set(ByVal Value As Int16)
                intMedium = Value
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

        ' PatronID property
        Public Property PatronID() As String
            Get
                Return strPatronID
            End Get
            Set(ByVal Value As String)
                strPatronID = Value
            End Set
        End Property
        ' PatronName property
        Public Property PatronName() As String
            Get
                Return strPatronName
            End Get
            Set(ByVal Value As String)
                strPatronName = Value
            End Set
        End Property
        ' PatronStatus property
        Public Property PatronStatus() As String
            Get
                Return strPatronStatus
            End Get
            Set(ByVal Value As String)
                strPatronStatus = Value
            End Set
        End Property
        ' PaymentProvided property
        Public Property PaymentProvided() As Boolean
            Get
                Return blnPaymentProvided
            End Get
            Set(ByVal Value As Boolean)
                blnPaymentProvided = Value
            End Set
        End Property
        ' PaymentType property
        Public Property PaymentType() As Int16
            Get
                Return intPaymentType
            End Get
            Set(ByVal Value As Int16)
                intPaymentType = Value
            End Set
        End Property
        ' ReceivedDate property
        Public Property ReceivedDate() As String
            Get
                Return strReceivedDate
            End Get
            Set(ByVal Value As String)
                strReceivedDate = Value
            End Set
        End Property
        ' ReciprocalAgreement property
        Public Property ReciprocalAgreement() As Boolean
            Get
                Return blnReciprocalAgreement
            End Get
            Set(ByVal Value As Boolean)
                blnReciprocalAgreement = Value
            End Set
        End Property
        ' Renewable property
        Public Property Renewable() As Boolean
            Get
                Return blnRenewable
            End Get
            Set(ByVal Value As Boolean)
                blnRenewable = Value
            End Set
        End Property
        ' Renewals property
        Public Property Renewals() As Int32
            Get
                Return intRenewals
            End Get
            Set(ByVal Value As Int32)
                intRenewals = Value
            End Set
        End Property

        ' RequestID property
        Public Property RequestID() As String
            Get
                Return strRequestID
            End Get
            Set(ByVal Value As String)
                strRequestID = Value
            End Set
        End Property
        ' RespondDate property
        Public Property RespondDate() As String
            Get
                Return strRespondDate
            End Get
            Set(ByVal Value As String)
                strRespondDate = Value
            End Set
        End Property
        ' ReturnedDate property
        Public Property ReturnedDate() As String
            Get
                Return strReturnedDate
            End Get
            Set(ByVal Value As String)
                strReturnedDate = Value
            End Set
        End Property
        ' ReturnInsuranceCost property
        Public Property ReturnInsuranceCost() As Double
            Get
                Return dblReturnInsuranceCost
            End Get
            Set(ByVal Value As Double)
                dblReturnInsuranceCost = Value
            End Set
        End Property
        ' ReturnLocID property
        Public Property ReturnLocID() As Int16
            Get
                Return intReturnLocID
            End Get
            Set(ByVal Value As Int16)
                intReturnLocID = Value
            End Set
        End Property
        ' ShippedDate property
        Public Property ShippedDate() As String
            Get
                Return strShippedDate
            End Get
            Set(ByVal Value As String)
                strShippedDate = Value
            End Set
        End Property
        ' SoID property
        Public Property SoID() As Integer
            Get
                Return intSoID
            End Get
            Set(ByVal Value As Integer)
                intSoID = Value
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
        ' ItemID property
        Public Property ItemID() As Integer
            Get
                Return intItemID
            End Get
            Set(ByVal Value As Integer)
                intItemID = Value
            End Set
        End Property
        ' TransportationModeID property
        Public Property TransportationModeID() As Int16
            Get
                Return intTransportationModeID
            End Get
            Set(ByVal Value As Int16)
                intTransportationModeID = Value
            End Set
        End Property
        ' WillPayFee property
        Public Property WillPayFee() As Boolean
            Get
                Return blnWillPayFee
            End Get
            Set(ByVal Value As Boolean)
                blnWillPayFee = Value
            End Set
        End Property

        ' CodeLib property
        Public Property CodeLib() As String
            Get
                Return strCodeLib
            End Get
            Set(ByVal Value As String)
                strCodeLib = Value
            End Set
        End Property

        ' Email property
        Public Property Email() As String
            Get
                Return strEmail
            End Get
            Set(ByVal Value As String)
                strEmail = Value
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

        ' Valid date property
        Public Property ValidDate() As String
            Get
                Return strValidDate
            End Get
            Set(ByVal Value As String)
                strValidDate = Value
            End Set
        End Property

        ' Priority property
        Public Property Priority() As Int16
            Get
                Return intPriority
            End Get
            Set(ByVal Value As Int16)
                intPriority = Value
            End Set
        End Property

        ' ILLLibrary property
        Public Property LibID() As Integer
            Get
                Return intLibID
            End Get
            Set(ByVal Value As Integer)
                intLibID = Value
            End Set
        End Property
        ' AccountNumber property
        Public Property AccountNumber() As String
            Get
                Return strAccountNumber
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strAccountNumber = Value
                End If
            End Set
        End Property
        ' BillDelivXAddr property
        Public Property BillDelivXAddr() As String
            Get
                Return strBillDelivXAddr
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strBillDelivXAddr = Value
                End If
            End Set
        End Property
        ' Code property
        Public Property Code() As String
            Get
                Return strCode
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strCode = Value
                End If
            End Set
        End Property
        ' Dublicate property
        Public Property Dublicate() As Boolean
            Get
                Return blnDublicate
            End Get
            Set(ByVal Value As Boolean)
                blnDublicate = Value
            End Set
        End Property
        ' EDelivMode property
        Public Property EDelivMode() As String
            Get
                Return strEdelivMode
            End Get
            Set(ByVal Value As String)
                strEdelivMode = Value
            End Set
        End Property
        ' EDelivTSAddr property
        Public Property EDelivTSAddr() As String
            Get
                Return strEDelivTSAddr
            End Get
            Set(ByVal Value As String)
                strEDelivTSAddr = Value
            End Set
        End Property
        ' EmailReplyAddress property
        Public Property EmailReplyAddress() As String
            Get
                Return strEmailReplyAddress
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strEmailReplyAddress = Value
                End If
            End Set
        End Property
        ' LibraryName property
        Public Property LibraryName() As String
            Get
                Return strLibraryName
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strLibraryName = Value
                End If
            End Set
        End Property
        ' LibrarySymbol property
        Public Property LibrarySymbol() As String
            Get
                Return strLibrarySymbol
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strLibrarySymbol = Value
                End If
            End Set
        End Property
        ' PostDelivXAddr property
        Public Property PostDelivXAddr() As String
            Get
                Return strPostDelivXAddr
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPostDelivXAddr = Value
                End If
            End Set
        End Property
        ' Telephone property
        Public Property Telephone() As String
            Get
                Return strTelephone
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strTelephone = Value
                End If
            End Set
        End Property
        ' ILLReqItems properties
        ' RequestType property
        Public Property RequestType() As Boolean
            Get
                Return blnRequestType
            End Get
            Set(ByVal Value As Boolean)
                blnRequestType = Value
            End Set
        End Property
        ' CallNumber property
        Public Property CallNumber() As String
            Get
                Return strCallNumber
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strCallNumber = Value
                End If
            End Set
        End Property
        ' Title property
        Public Property Title() As String
            Get
                Return strTitle
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strTitle = Value
                End If
            End Set
        End Property
        ' Author property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strAuthor = Value
                End If
            End Set
        End Property
        ' PlaceOfBub property
        Public Property PlaceOfPub() As String
            Get
                Return strPlaceOfPub
            End Get
            Set(ByVal Value As String)
                strPlaceOfPub = Value
            End Set
        End Property
        ' Publisher property
        Public Property Publisher() As String
            Get
                Return strPublisher
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPublisher = Value
                End If
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
        ' Edition property
        Public Property Edition() As String
            Get
                Return strEdition
            End Get
            Set(ByVal Value As String)
                strEdition = Value
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
        ' ComponentPubDate property
        Public Property ComponentPubDate() As String
            Get
                Return strComponentPubDate
            End Get
            Set(ByVal Value As String)
                strComponentPubDate = Value
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
        ' NationalBibNumber property
        Public Property NationalBibNumber() As String
            Get
                Return strNationalBibNumber
            End Get
            Set(ByVal Value As String)
                strNationalBibNumber = Value
            End Set
        End Property
        ' ISBN property
        Public Property ISBN() As String
            Get
                Return strISBN
            End Get
            Set(ByVal Value As String)
                strISBN = Value
            End Set
        End Property
        ' ISSN property
        Public Property ISSN() As String
            Get
                Return strISSN
            End Get
            Set(ByVal Value As String)
                strISSN = Value
            End Set
        End Property
        ' ItemType property
        Public Property ItemType() As Int16
            Get
                Return intItemType
            End Get
            Set(ByVal Value As Int16)
                intItemType = Value
            End Set
        End Property
        ' SystemNumber property
        Public Property SystemNumber() As String
            Get
                Return strSystemNumber
            End Get
            Set(ByVal Value As String)
                strSystemNumber = Value
            End Set
        End Property
        ' OtherNumbers property
        Public Property OtherNumbers() As String
            Get
                Return strOtherNumbers
            End Get
            Set(ByVal Value As String)
                strOtherNumbers = Value
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
        ' ILLInComingReqBi properties
        ' BillDelivName property
        Public Property BillDelivName() As String
            Get
                Return strBillDelivName
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strBillDelivName = Value
                End If
            End Set
        End Property
        ' BillDelivBox property
        Public Property BillDelivBox() As String
            Get
                Return strBillDelivBox
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strBillDelivBox = Value
                End If
            End Set
        End Property
        ' BillDelivStreet property
        Public Property BillDelivStreet() As String
            Get
                Return strBillDelivStreet
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strBillDelivStreet = Value
                End If
            End Set
        End Property
        ' BillDelivCity property
        Public Property BillDelivCity() As String
            Get
                Return strBillDelivCity
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strBillDelivCity = Value
                End If
            End Set
        End Property
        ' BillDelivRegion property
        Public Property BillDelivRegion() As String
            Get
                Return strBillDelivRegion
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strBillDelivRegion = Value
                End If
            End Set
        End Property
        ' BillDelivCountry property
        Public Property BillDelivCountry() As Int16
            Get
                Return intBillDelivCountry
            End Get
            Set(ByVal Value As Int16)
                intBillDelivCountry = Value
            End Set
        End Property
        ' BillDelivCode property
        Public Property BillDelivCode() As String
            Get
                Return strBillDelivCode
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strBillDelivCode = Value
                End If
            End Set
        End Property

        ' ILLInComingReqDe properties        
        ' PostDelivName property
        Public Property PostDelivName() As String
            Get
                Return strPostDelivName
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPostDelivName = Value
                End If
            End Set
        End Property
        ' PostDelivStreet property
        Public Property PostDelivStreet() As String
            Get
                Return strPostDelivStreet
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPostDelivStreet = Value
                End If
            End Set
        End Property
        ' PostDelivBox property
        Public Property PostDelivBox() As String
            Get
                Return strPostDelivBox
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPostDelivBox = Value
                End If
            End Set
        End Property
        ' PostDelivCity property
        Public Property PostDelivCity() As String
            Get
                Return strPostDelivCity
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPostDelivCity = Value
                End If
            End Set
        End Property
        ' PostDelivRegion property
        Public Property PostDelivRegion() As String
            Get
                Return strPostDelivRegion
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPostDelivRegion = Value
                End If
            End Set
        End Property
        ' PostDelivCountry property
        Public Property PostDelivCountry() As Integer
            Get
                Return intPostDelivCountry
            End Get
            Set(ByVal Value As Integer)
                intPostDelivCountry = Value
            End Set
        End Property
        ' PostDelivCode property
        Public Property PostDelivCode() As String
            Get
                Return strPostDelivCode
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strPostDelivCode = Value
                End If
            End Set
        End Property
        ' ILLInComingReqLog properties        
        ' Note property
        Public Property Note() As String
            Get
                Return strNote
            End Get
            Set(ByVal Value As String)
                If Not Value Is Nothing Then
                    strNote = Value
                End If
            End Set
        End Property
        ' ServiceType property
        Public Property ServiceType() As Int16
            Get
                Return intServiceType
            End Get
            Set(ByVal Value As Int16)
                intServiceType = Value
            End Set
        End Property
        ' DueDate property
        Public Property DueDate() As String
            Get
                Return strDueDate
            End Get
            Set(ByVal Value As String)
                strDueDate = Value
            End Set
        End Property

        ' EncodingScheme property
        Public Property EncodingScheme() As Int16
            Get
                Return intEncodingScheme
            End Get
            Set(ByVal Value As Int16)
                intEncodingScheme = Value
            End Set
        End Property

        ' *************************************************************************************************
        ' End declare properties
        ' IMPLEMENT METHODS HERE
        ' *************************************************************************************************

        ' purpose : Create one ILLImComing Request
        ' Created by: dgsoft2016
        Public Function CreateRequest() As Integer
            Me.OpenConnection()
            Select Case UCase(strDBServer)
                Case "SQLSERVER"
                    With SqlCommand
                        .CommandText = "Opac_spIllIncomingRequest_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New SqlParameter("@strRequestID", SqlDbType.VarChar, 16)).Value = strRequestID
                                .Add(New SqlParameter("@strNeedBeforeDate", SqlDbType.VarChar, 10)).Value = strNeedBeforeDate
                                .Add(New SqlParameter("@strExpiryDate", SqlDbType.VarChar, 10)).Value = strExpiryDate
                                .Add(New SqlParameter("@intServiceType", SqlDbType.Bit)).Value = intServiceType
                                .Add(New SqlParameter("@intCopyrightCompliance", SqlDbType.TinyInt)).Value = intCopyrightCompliance
                                .Add(New SqlParameter("@intPriority", SqlDbType.TinyInt)).Value = intPriority
                                .Add(New SqlParameter("@dblMaxCost", SqlDbType.Money)).Value = dblMaxCost
                                .Add(New SqlParameter("@strCurrencyCode", SqlDbType.Char, 3)).Value = strCurrencyCode
                                .Add(New SqlParameter("@intPaymentType", SqlDbType.TinyInt)).Value = intPaymentType
                                .Add(New SqlParameter("@intItemType", SqlDbType.TinyInt)).Value = intItemType
                                .Add(New SqlParameter("@blnReciprocalAgreement", SqlDbType.Bit)).Value = blnReciprocalAgreement
                                .Add(New SqlParameter("@blnWillPayFee", SqlDbType.Bit)).Value = blnWillPayFee
                                .Add(New SqlParameter("@blnPaymentProvided", SqlDbType.Bit)).Value = blnPaymentProvided
                                .Add(New SqlParameter("@intMedium", SqlDbType.TinyInt)).Value = intMedium
                                .Add(New SqlParameter("@blnDelivMode", SqlDbType.Bit)).Value = blnDelivMode
                                .Add(New SqlParameter("@strEDelivMode", SqlDbType.VarChar, 20)).Value = strEdelivMode
                                .Add(New SqlParameter("@strEDelivTSAddr", SqlDbType.NVarChar, 50)).Value = strEDelivTSAddr
                                .Add(New SqlParameter("@strEmailReplyAddress", SqlDbType.VarChar, 30)).Value = strEmailReplyAddress
                                .Add(New SqlParameter("@strNote", SqlDbType.NVarChar, 200)).Value = strNote
                                .Add(New SqlParameter("@strPatronName", SqlDbType.NVarChar, 50)).Value = strPatronName
                                .Add(New SqlParameter("@strPatronID", SqlDbType.VarChar, 24)).Value = strPatronID
                                .Add(New SqlParameter("@strPatronStatus", SqlDbType.VarChar, 50)).Value = strPatronStatus
                                .Add(New SqlParameter("@intStatus", SqlDbType.Int)).Value = intStatus
                                .Add(New SqlParameter("@strTitle", SqlDbType.NVarChar, 200)).Value = strTitle
                                '	ILLLibrary 
                                .Add(New SqlParameter("@intLibID", SqlDbType.Int)).Value = intLibID
                                .Add(New SqlParameter("@strAccountNumber", SqlDbType.NVarChar, 50)).Value = strAccountNumber
                                .Add(New SqlParameter("@strLibraryName", SqlDbType.NVarChar, 50)).Value = strLibraryName
                                .Add(New SqlParameter("@strLibrarySymbol", SqlDbType.NVarChar, 50)).Value = strLibrarySymbol
                                .Add(New SqlParameter("@strBillDelivBox", SqlDbType.NVarChar, 50)).Value = strBillDelivBox
                                .Add(New SqlParameter("@strBillDelivCity", SqlDbType.NVarChar, 50)).Value = strBillDelivCity
                                .Add(New SqlParameter("@strBillDelivCode", SqlDbType.VarChar, 50)).Value = strBillDelivCode
                                .Add(New SqlParameter("@intBillDelivCountry", SqlDbType.TinyInt)).Value = intBillDelivCountry
                                .Add(New SqlParameter("@strBillDelivName", SqlDbType.NVarChar, 50)).Value = strBillDelivName
                                .Add(New SqlParameter("@strBillDelivRegion", SqlDbType.NVarChar, 50)).Value = strBillDelivRegion
                                .Add(New SqlParameter("@strBillDelivStreet", SqlDbType.NVarChar, 50)).Value = strBillDelivStreet
                                .Add(New SqlParameter("@strBillDelivXAddr", SqlDbType.NVarChar, 50)).Value = strBillDelivXAddr
                                .Add(New SqlParameter("@strCode", SqlDbType.Char, 4)).Value = strCode
                                .Add(New SqlParameter("@blnDublicate", SqlDbType.Bit)).Value = blnDublicate
                                .Add(New SqlParameter("@strPostDelivBox", SqlDbType.NVarChar, 50)).Value = strPostDelivBox
                                .Add(New SqlParameter("@strPostDelivCity", SqlDbType.NVarChar, 50)).Value = strPostDelivCity
                                .Add(New SqlParameter("@strPostDelivCode", SqlDbType.VarChar, 10)).Value = strPostDelivCode
                                .Add(New SqlParameter("@intPostDelivCountry", SqlDbType.TinyInt)).Value = intPostDelivCountry
                                .Add(New SqlParameter("@strPostDelivName", SqlDbType.NVarChar, 50)).Value = strPostDelivName
                                .Add(New SqlParameter("@strPostDelivRegion", SqlDbType.NVarChar, 50)).Value = strPostDelivRegion
                                .Add(New SqlParameter("@strPostDelivStreet", SqlDbType.NVarChar, 50)).Value = strPostDelivStreet
                                .Add(New SqlParameter("@strPostDelivXAddr", SqlDbType.NVarChar, 100)).Value = strPostDelivXAddr
                                .Add(New SqlParameter("@strTelephone", SqlDbType.VarChar, 14)).Value = strTelephone
                                .Add(New SqlParameter("@intEncodingScheme", SqlDbType.TinyInt)).Value = intEncodingScheme
                                '	ILLRequestItems
                                .Add(New SqlParameter("@blnRequestType", SqlDbType.Bit)).Value = 1 'blnRequestType
                                .Add(New SqlParameter("@strCallNumber", SqlDbType.VarChar, 24)).Value = strCallNumber
                                .Add(New SqlParameter("@strAuthor", SqlDbType.NVarChar, 100)).Value = strAuthor
                                .Add(New SqlParameter("@strPlaceOfPub", SqlDbType.NVarChar, 50)).Value = strPlaceOfPub
                                .Add(New SqlParameter("@strPublisher", SqlDbType.NVarChar, 50)).Value = strPublisher
                                .Add(New SqlParameter("@strSeriesTitleNumber", SqlDbType.NVarChar, 120)).Value = strSeriesTitleNumber
                                .Add(New SqlParameter("@strVolumeIssue", SqlDbType.NVarChar, 50)).Value = strVolumeIssue
                                .Add(New SqlParameter("@strEdition", SqlDbType.NVarChar, 50)).Value = strEdition
                                .Add(New SqlParameter("@strPubDate", SqlDbType.VarChar, 8)).Value = strPubDate
                                .Add(New SqlParameter("@strComponentPubDate", SqlDbType.VarChar, 8)).Value = strComponentPubDate
                                .Add(New SqlParameter("@strArticleAuthor", SqlDbType.NVarChar, 64)).Value = strArticleAuthor
                                .Add(New SqlParameter("@strArticleTitle", SqlDbType.NVarChar, 200)).Value = strArticleTitle
                                .Add(New SqlParameter("@strPagination", SqlDbType.NVarChar, 50)).Value = strPagination
                                .Add(New SqlParameter("@strNationalBibNumber", SqlDbType.NVarChar, 25)).Value = strNationalBibNumber
                                .Add(New SqlParameter("@strISBN", SqlDbType.VarChar, 16)).Value = strISBN
                                .Add(New SqlParameter("@strISSN", SqlDbType.VarChar, 16)).Value = strISSN
                                .Add(New SqlParameter("@strSystemNumber", SqlDbType.NVarChar, 50)).Value = strSystemNumber
                                .Add(New SqlParameter("@strOtherNumbers", SqlDbType.NVarChar, 50)).Value = strOtherNumbers
                                .Add(New SqlParameter("@strVerification", SqlDbType.NVarChar, 50)).Value = strVerification
                                .Add(New SqlParameter("@intRetval", SqlDbType.Int)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateRequest = .Parameters("@intRetval").Value
                        Catch sqlClientEx As SqlException
                            strErrorMsg = sqlClientEx.Message.ToString
                            intErrorCode = sqlClientEx.Number
                        Finally
                            .Parameters.Clear()
                        End Try
                    End With
                Case "ORACLE"
                    With OraCommand
                        .CommandText = "OPAC.Opac_spIllIncomingRequest_Create"
                        .CommandType = CommandType.StoredProcedure
                        Try
                            With .Parameters
                                .Add(New OracleParameter("strRequestID", OracleType.VarChar, 16)).Value = strRequestID
                                .Add(New OracleParameter("strNeedBeforeDate", OracleType.VarChar, 10)).Value = strNeedBeforeDate
                                .Add(New OracleParameter("strExpiryDate", OracleType.VarChar, 10)).Value = strExpiryDate
                                .Add(New OracleParameter("intServiceType", OracleType.Number)).Value = intServiceType
                                .Add(New OracleParameter("intCopyrightCompliance", OracleType.Number)).Value = intCopyrightCompliance
                                .Add(New OracleParameter("intPriority", OracleType.Number)).Value = intPriority
                                .Add(New OracleParameter("dblMaxCost", OracleType.Float)).Value = dblMaxCost
                                .Add(New OracleParameter("strCurrencyCode", OracleType.Char, 3)).Value = strCurrencyCode
                                .Add(New OracleParameter("intPaymentType", OracleType.Number)).Value = intPaymentType
                                .Add(New OracleParameter("intItemType", OracleType.Number)).Value = intItemType
                                .Add(New OracleParameter("blnReciprocalAgreement", OracleType.Number)).Value = blnReciprocalAgreement
                                .Add(New OracleParameter("blnWillPayFee", OracleType.Number)).Value = blnWillPayFee
                                .Add(New OracleParameter("blnPaymentProvided", OracleType.Number)).Value = blnPaymentProvided
                                .Add(New OracleParameter("intMedium", OracleType.Number)).Value = intMedium
                                .Add(New OracleParameter("blnDelivMode", OracleType.Number)).Value = blnDelivMode
                                .Add(New OracleParameter("strEDelivMode", OracleType.VarChar, 20)).Value = strEdelivMode
                                .Add(New OracleParameter("strEDelivTSAddr", OracleType.VarChar, 50)).Value = strEDelivTSAddr
                                .Add(New OracleParameter("strEmailReplyAddress", OracleType.VarChar, 30)).Value = strEmailReplyAddress
                                .Add(New OracleParameter("strNote", OracleType.VarChar, 200)).Value = strNote
                                .Add(New OracleParameter("strPatronName", OracleType.VarChar, 50)).Value = strPatronName
                                .Add(New OracleParameter("strPatronID", OracleType.VarChar, 24)).Value = strPatronID
                                .Add(New OracleParameter("strPatronStatus", OracleType.VarChar, 50)).Value = strPatronStatus
                                .Add(New OracleParameter("intStatus", OracleType.Number)).Value = intStatus
                                .Add(New OracleParameter("strTitle", OracleType.VarChar, 200)).Value = strTitle
                                '	ILLLibrary 
                                .Add(New OracleParameter("intLibID", OracleType.Number)).Value = intLibID
                                .Add(New OracleParameter("strAccountNumber", OracleType.VarChar, 50)).Value = strAccountNumber
                                .Add(New OracleParameter("strLibraryName", OracleType.VarChar, 50)).Value = strLibraryName
                                .Add(New OracleParameter("strLibrarySymbol", OracleType.VarChar, 50)).Value = strLibrarySymbol
                                .Add(New OracleParameter("strBillDelivBox", OracleType.VarChar, 50)).Value = strBillDelivBox
                                .Add(New OracleParameter("strBillDelivCity", OracleType.VarChar, 50)).Value = strBillDelivCity
                                .Add(New OracleParameter("strBillDelivCode", OracleType.VarChar, 50)).Value = strBillDelivCode
                                .Add(New OracleParameter("intBillDelivCountry", OracleType.Number)).Value = intBillDelivCountry
                                .Add(New OracleParameter("strBillDelivName", OracleType.VarChar, 50)).Value = strBillDelivName
                                .Add(New OracleParameter("strBillDelivRegion", OracleType.VarChar, 50)).Value = strBillDelivRegion
                                .Add(New OracleParameter("strBillDelivStreet", OracleType.VarChar, 50)).Value = strBillDelivStreet
                                .Add(New OracleParameter("strBillDelivXAddr", OracleType.VarChar, 50)).Value = strBillDelivXAddr
                                .Add(New OracleParameter("strCode", OracleType.Char, 4)).Value = strCode
                                .Add(New OracleParameter("blnDublicate", OracleType.Number)).Value = blnDublicate
                                .Add(New OracleParameter("strPostDelivBox", OracleType.VarChar, 50)).Value = strPostDelivBox
                                .Add(New OracleParameter("strPostDelivCity", OracleType.VarChar, 50)).Value = strPostDelivCity
                                .Add(New OracleParameter("strPostDelivCode", OracleType.VarChar, 10)).Value = strPostDelivCode
                                .Add(New OracleParameter("intPostDelivCountry", OracleType.Number)).Value = intPostDelivCountry
                                .Add(New OracleParameter("strPostDelivName", OracleType.VarChar, 50)).Value = strPostDelivName
                                .Add(New OracleParameter("strPostDelivRegion", OracleType.VarChar, 50)).Value = strPostDelivRegion
                                .Add(New OracleParameter("strPostDelivStreet", OracleType.VarChar, 50)).Value = strPostDelivStreet
                                .Add(New OracleParameter("strPostDelivXAddr", OracleType.VarChar, 100)).Value = strPostDelivXAddr
                                .Add(New OracleParameter("strTelephone", OracleType.VarChar, 14)).Value = strTelephone
                                .Add(New OracleParameter("intEncodingScheme", OracleType.Number)).Value = intEncodingScheme
                                '	ILLRequestItems
                                .Add(New OracleParameter("blnRequestType", OracleType.Number)).Value = 1 'blnRequestType
                                .Add(New OracleParameter("strCallNumber", OracleType.VarChar, 24)).Value = strCallNumber
                                .Add(New OracleParameter("strAuthor", OracleType.VarChar, 100)).Value = strAuthor
                                .Add(New OracleParameter("strPlaceOfPub", OracleType.VarChar, 50)).Value = strPlaceOfPub
                                .Add(New OracleParameter("strPublisher", OracleType.VarChar, 50)).Value = strPublisher
                                .Add(New OracleParameter("strSeriesTitleNumber", OracleType.VarChar, 120)).Value = strSeriesTitleNumber
                                .Add(New OracleParameter("strVolumeIssue", OracleType.VarChar, 40)).Value = strVolumeIssue
                                .Add(New OracleParameter("strEdition", OracleType.VarChar, 50)).Value = strEdition
                                .Add(New OracleParameter("strPubDate", OracleType.VarChar, 8)).Value = strPubDate
                                .Add(New OracleParameter("strComponentPubDate", OracleType.VarChar, 8)).Value = strComponentPubDate
                                .Add(New OracleParameter("strArticleAuthor", OracleType.VarChar, 64)).Value = strArticleAuthor
                                .Add(New OracleParameter("strArticleTitle", OracleType.VarChar, 200)).Value = strArticleTitle
                                .Add(New OracleParameter("strPagination", OracleType.VarChar, 50)).Value = strPagination
                                .Add(New OracleParameter("strNationalBibNumber", OracleType.VarChar, 25)).Value = strNationalBibNumber
                                .Add(New OracleParameter("strISBN", OracleType.VarChar, 16)).Value = strISBN
                                .Add(New OracleParameter("strISSN", OracleType.VarChar, 16)).Value = strISSN
                                .Add(New OracleParameter("strSystemNumber", OracleType.VarChar, 20)).Value = strSystemNumber
                                .Add(New OracleParameter("strOtherNumbers", OracleType.VarChar, 50)).Value = strOtherNumbers
                                .Add(New OracleParameter("strVerification", OracleType.VarChar, 16)).Value = strVerification
                                .Add(New OracleParameter("intRetval", OracleType.Number)).Direction = ParameterDirection.Output
                            End With
                            .ExecuteNonQuery()
                            CreateRequest = .Parameters("intRetval").Value
                        Catch OraEx As OracleException
                            strErrorMsg = OraEx.Message.ToString
                            intErrorCode = OraEx.Code
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