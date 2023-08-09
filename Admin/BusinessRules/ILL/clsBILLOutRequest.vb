Imports System
Imports System.IO
Imports eMicLibAdmin.BusinessRules.Common
Imports eMicLibAdmin.BusinessRules.ILL
Imports eMicLibAdmin.DataAccess.ILL

Namespace eMicLibAdmin.BusinessRules.ILL
    Public Class clsBILLOutRequest
        Inherits clsBBase

        ' ***********************************************************************************************
        ' Declare Private variables
        ' ***********************************************************************************************


        Private strNote As String = ""

        Private objBCSP As New clsBCommonStringProc
        Private objBCDBS As New clsBCommonDBSystem
        Private objBILLLibrary As New clsBILLLibrary
        Private objDILLOutRequest As New clsDILLOutRequest
        Private objPara() As String = {"SMTP_SERVER", "SMTP_PORT", "ADMIN_EMAIL_ADDRESS", "DATE_FORMAT", "ILL_ENCODE"}
        Private objSysPara() As String

        Private strRequesterSymbol As String = ""
        Private strRequesterName As String = ""
        Private strResponderSymbol As String = ""
        Private strResponderName As String = ""
        Private strServiceDate As String = ""
        Private strServiceTime As String = ""
        Private strSubTransactQualifier As String = ""
        Private strProtocolVerNum As String = ""
        Private strTransactGroupQualifier As String = ""
        Private strNBD As String
        Private strED As String

        ' ILL_OUTGOING_REQUESTS
        Private strRequestID As String
        Private intResponderID As Integer
        Private strCreatedDate As String
        Private strRequestDate As String
        Private strNeedBeforeDate As String
        Private strExpiredDate As String
        Private strRespondDate As String
        Private strCancelledDate As String
        Private strShippedDate As String
        Private strReceivedDate As String
        Private strReturnedDate As String
        Private strCheckedInDate As String
        Private strDueDate As String
        Private strLocalDueDate As String
        Private strLocalCheckedInDate As String
        Private strLocalCheckedOutDate As String
        Private intRenewals As Integer
        Private intLoanTypeID As Integer
        Private strBarcode As String
        Private intNoticePatron As Integer
        Private dbCost As Double
        Private strCurrencyCode1 As String
        Private dbInsuredForCost As Double
        Private strCurrencyCode2 As String
        Private intReturnInsuranceCost As Integer
        Private intChageableUnits As Integer
        Private dbMaxCost As Double
        Private strCurrencyCode As String
        Private intStatus As Integer
        Private intDeliveryLocID As Integer
        Private intBillingLocID As Integer
        Private intReciprocalAgreement As Integer
        Private intWillPayFee As Integer
        Private intPaymentProvided As Integer
        Private intServiceType As Integer
        Private intCopyrightCompliance As Integer
        Private intPriority As Integer
        Private intPaymentType As Integer
        Private intItemType As Integer
        Private intMedium As Integer
        Private intDelivMode As Integer
        Private intEDelivModeID As Integer
        Private intAlert As Integer
        Protected strTitle As String = ""
        Protected strPatronName As String = ""
        Protected strPatronCode As String = ""
        Private intPatronGroupID As Integer

        '  ILL_LIBRARIES
        Private strAccountNumber As String
        Private strPostDelivName As String
        Private strPostDelivXAddr As String
        Private strPostDelivStreet As String
        Private strPostDelivBox As String
        Private strPostDelivCity As String
        Private strPostDelivRegion As String
        Private intPostDelivCountry As Integer
        Private strPostDelivCode As String
        Private strBillDelivName As String
        Private strBillDelivXAddr As String
        Private strBillDelivStreet As String
        Private strBillDelivBox As String
        Private strBillDelivCity As String
        Private strBillDelivRegion As String
        Private intBillDelivCountry As Integer
        Private strBillDelivCode As String

        ' ILL_REQUEST_ITEMS
        Private strCallNumber As String
        Protected strAuthor As String = ""
        Private strPlaceOfPub As String
        Private strPublisher As String
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
        Private strLocalNote As String
        Private intRequestType As Integer
        Private strSponsoringBody As String
        Private intRetVal As Integer
        Private intAPDUType As Integer
        Private colContentData As New Collection
        Private objBILLTemplate As New clsBILLTemplate
        Private mtx As clsBILLTemplate.Metric

        ' OUTGOING_ILL_REQUEST_LOG
        Private intIllID As Integer
        Private strTransactionDate As String
        Private intReasonID As Integer
        Private strProvidedDate As String
        Private strResponderSpecReason As String
        Private intSendShipped As Integer
        Private intSendCheckedIn As Integer
        Private intSendReceived As Integer
        Private intSendReturned As Integer
        Private intTRE As Integer
        Private intAnswer As Integer
        Private intRenewable As Integer
        Private intLogID As Integer
        Private strLocation As String
        Private strReturnedVia As String
        Private dbReturnInsuranceCost As Double
        Private strCurrencyCode3 As String
        Private strTransportationMode As String
        Private strSubSQL As String = "1=1"
        Private blnEncodeOk As Boolean = False

        ' ***********************************************************************************************
        ' End declare variables
        ' Declare public properties
        ' ***********************************************************************************************
        ' Location property
        Public Property Location() As String
            Get
                Return strLocation
            End Get
            Set(ByVal Value As String)
                strLocation = Value
            End Set
        End Property

        ' TransportationMode property
        Public Property TransportationMode() As String
            Get
                Return strTransportationMode
            End Get
            Set(ByVal Value As String)
                strTransportationMode = Value
            End Set
        End Property

        ' ReturnedVia property
        Public Property ReturnedVia() As String
            Get
                Return strReturnedVia
            End Get
            Set(ByVal Value As String)
                strReturnedVia = Value
            End Set
        End Property

        ' Answer property
        Public Property Answer() As Integer
            Get
                Return intAnswer
            End Get
            Set(ByVal Value As Integer)
                intAnswer = Value
            End Set
        End Property


        ' InsuredForCost property
        Public Property InsuredForCost() As Double
            Get
                Return dbInsuredForCost
            End Get
            Set(ByVal Value As Double)
                dbInsuredForCost = Value
            End Set
        End Property

        ' ResponderSpecReason property
        Public Property ResponderSpecReason() As String
            Get
                Return strResponderSpecReason
            End Get
            Set(ByVal Value As String)
                strResponderSpecReason = Value
            End Set
        End Property

        ' ProvidedDate property
        Public Property ProvidedDate() As String
            Get
                Return strProvidedDate
            End Get
            Set(ByVal Value As String)
                strProvidedDate = Value
            End Set
        End Property

        ' TransactionDate property
        Public Property TransactionDate() As String
            Get
                Return strTransactionDate
            End Get
            Set(ByVal Value As String)
                strTransactionDate = Value
            End Set
        End Property

        ' LogID property
        Public Property LogID() As Integer
            Get
                Return intLogID
            End Get
            Set(ByVal Value As Integer)
                intLogID = Value
            End Set
        End Property

        ' TRE property
        Public Property TRE() As Integer
            Get
                Return intTRE
            End Get
            Set(ByVal Value As Integer)
                intTRE = Value
            End Set
        End Property

        ' SendShipped property
        Public Property SendShipped() As Integer
            Get
                Return intSendShipped
            End Get
            Set(ByVal Value As Integer)
                intSendShipped = Value
            End Set
        End Property

        ' IllID property
        Public Property IllID() As Integer
            Get
                Return intIllID
            End Get
            Set(ByVal Value As Integer)
                intIllID = Value
            End Set
        End Property

        ' SendReceived property
        Public Property SendReceived() As Integer
            Get
                Return intSendReceived
            End Get
            Set(ByVal Value As Integer)
                intSendReceived = Value
            End Set
        End Property

        ' SendCheckedIn property
        Public Property SendCheckedIn() As Integer
            Get
                Return intSendCheckedIn
            End Get
            Set(ByVal Value As Integer)
                intSendCheckedIn = Value
            End Set
        End Property

        ' SendReturned property
        Public Property SendReturned() As Integer
            Get
                Return intSendReturned
            End Get
            Set(ByVal Value As Integer)
                intSendReturned = Value
            End Set
        End Property

        ' ReasonID property
        Public Property ReasonID() As Integer
            Get
                Return intReasonID
            End Get
            Set(ByVal Value As Integer)
                intReasonID = Value
            End Set
        End Property

        ' APDUType
        Public Property APDUType() As Integer
            Get
                Return intAPDUType
            End Get
            Set(ByVal Value As Integer)
                intAPDUType = Value
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

        ' ContentData property
        Public Property ContentData() As Collection
            Get
                Return colContentData
            End Get
            Set(ByVal Value As Collection)
                colContentData = Value
            End Set
        End Property

        '  Properties for ILL_OUTGOING_REQUESTS
        ' RequestID property
        Public Property RequestIDCode() As String
            Get
                Return strRequestID
            End Get
            Set(ByVal Value As String)
                strRequestID = Value
            End Set
        End Property
        ' ResponderID property
        Public Property ResponderID() As Integer
            Get
                Return intResponderID
            End Get
            Set(ByVal Value As Integer)
                intResponderID = Value
            End Set
        End Property
        ' Created Date property
        Public Property CreatedDate() As String
            Get
                Return strCreatedDate
            End Get
            Set(ByVal Value As String)
                strCreatedDate = Value
            End Set
        End Property
        ' RequestDate Date property
        Public Property RequestDate() As String
            Get
                Return strRequestDate
            End Get
            Set(ByVal Value As String)
                strRequestDate = Value
            End Set
        End Property
        ' Need Before Date property
        Public Property NeedBeforeDate() As String
            Get
                Return strNeedBeforeDate
            End Get
            Set(ByVal Value As String)
                strNeedBeforeDate = Value
            End Set
        End Property
        ' Expired Date property
        Public Property ExpiredDate() As String
            Get
                Return strExpiredDate
            End Get
            Set(ByVal Value As String)
                strExpiredDate = Value
            End Set
        End Property
        '  RespondDate  property
        Public Property RespondDate() As String
            Get
                Return strRespondDate
            End Get
            Set(ByVal Value As String)
                strRespondDate = Value
            End Set
        End Property
        '  CancelledDate  property
        Public Property CancelledDate() As String
            Get
                Return strCancelledDate
            End Get
            Set(ByVal Value As String)
                strCancelledDate = Value
            End Set
        End Property
        '  ShippedDate property
        Public Property ShippedDate() As String
            Get
                Return strShippedDate
            End Get
            Set(ByVal Value As String)
                strShippedDate = Value
            End Set
        End Property
        '  ReceivedDate property
        Public Property ReceivedDate() As String
            Get
                Return strReceivedDate
            End Get
            Set(ByVal Value As String)
                strReceivedDate = Value
            End Set
        End Property
        '  ReturnedDate property
        Public Property ReturnedDate() As String
            Get
                Return strReturnedDate
            End Get
            Set(ByVal Value As String)
                strReturnedDate = Value
            End Set
        End Property
        '  CheckedInDate property
        Public Property CheckedInDate() As String
            Get
                Return strCheckedInDate
            End Get
            Set(ByVal Value As String)
                strCheckedInDate = Value
            End Set
        End Property
        '  DueDate property
        Public Property DueDate() As String
            Get
                Return strDueDate
            End Get
            Set(ByVal Value As String)
                strDueDate = Value
            End Set
        End Property
        '  LocalDueDate property
        Public Property LocalDueDate() As String
            Get
                Return strLocalDueDate
            End Get
            Set(ByVal Value As String)
                strLocalDueDate = Value
            End Set
        End Property
        '  LocalCheckedInDate property
        Public Property LocalCheckedInDate() As String
            Get
                Return strLocalCheckedInDate
            End Get
            Set(ByVal Value As String)
                strLocalCheckedInDate = Value
            End Set
        End Property
        '  LocalCheckedOutDate property
        Public Property LocalCheckedOutDate() As String
            Get
                Return strLocalCheckedOutDate
            End Get
            Set(ByVal Value As String)
                strLocalCheckedOutDate = Value
            End Set
        End Property
        '  Renewals property
        Public Property Renewals() As Integer
            Get
                Return intRenewals
            End Get
            Set(ByVal Value As Integer)
                intRenewals = Value
            End Set
        End Property
        '  Renewable property
        Public Property Renewable() As Integer
            Get
                Return intRenewable
            End Get
            Set(ByVal Value As Integer)
                intRenewable = Value
            End Set
        End Property

        '  LoanTypeID property
        Public Property LoanTypeID() As Integer
            Get
                Return intLoanTypeID
            End Get
            Set(ByVal Value As Integer)
                intLoanTypeID = Value
            End Set
        End Property
        '  Barcode property
        Public Property Barcode() As String
            Get
                Return strBarcode
            End Get
            Set(ByVal Value As String)
                strBarcode = Value
            End Set
        End Property
        '  Notice Patron property
        Public Property NoticePatron() As Integer
            Get
                Return intNoticePatron
            End Get
            Set(ByVal Value As Integer)
                intNoticePatron = Value
            End Set
        End Property
        '  Cost property
        Public Property Cost() As Double
            Get
                Return dbCost
            End Get
            Set(ByVal Value As Double)
                dbCost = Value
            End Set
        End Property
        '  CurrencyCode1 property
        Public Property CurrencyCode1() As String
            Get
                Return strCurrencyCode1
            End Get
            Set(ByVal Value As String)
                strCurrencyCode1 = Value
            End Set
        End Property
        '  InsuredForCost property
        Public Property InisuredForCost() As Double
            Get
                Return dbInsuredForCost
            End Get
            Set(ByVal Value As Double)
                dbInsuredForCost = Value
            End Set
        End Property
        '  CurrencyCode2 property
        Public Property CurrencyCode2() As String
            Get
                Return strCurrencyCode2
            End Get
            Set(ByVal Value As String)
                strCurrencyCode2 = Value
            End Set
        End Property
        '  ReturnInsuranceCost property
        Public Property ReturnInsuranceCost() As Integer
            Get
                Return intReturnInsuranceCost
            End Get
            Set(ByVal Value As Integer)
                intReturnInsuranceCost = Value
            End Set
        End Property
        '  CurrencyCode3 property
        Public Property CurrencyCode3() As String
            Get
                Return strCurrencyCode3
            End Get
            Set(ByVal Value As String)
                strCurrencyCode3 = Value
            End Set
        End Property
        '  ChageableUnits property
        Public Property ChageableUnits() As Integer
            Get
                Return intChageableUnits
            End Get
            Set(ByVal Value As Integer)
                intChageableUnits = Value
            End Set
        End Property
        '  MaxCost property
        Public Property MaxCost() As Double
            Get
                Return dbMaxCost
            End Get
            Set(ByVal Value As Double)
                dbMaxCost = Value
            End Set
        End Property
        ' Currency Code property
        Public Property CurrencyCode() As String
            Get
                Return strCurrencyCode
            End Get
            Set(ByVal Value As String)
                strCurrencyCode = Value
            End Set
        End Property
        ' Status property
        Public Property Statust() As Integer
            Get
                Return intStatus
            End Get
            Set(ByVal Value As Integer)
                intStatus = Value
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
        ' DeliveryLocID property
        Public Property DeliveryLocID() As Integer
            Get
                Return intDeliveryLocID
            End Get
            Set(ByVal Value As Integer)
                intDeliveryLocID = Value
            End Set
        End Property
        ' BillingLocID property
        Public Property BillingLocID() As Integer
            Get
                Return intBillingLocID
            End Get
            Set(ByVal Value As Integer)
                intBillingLocID = Value
            End Set
        End Property
        ' ReciprocalAgreement property
        Public Property ReciprocalAgreement() As Integer
            Get
                Return intReciprocalAgreement
            End Get
            Set(ByVal Value As Integer)
                intReciprocalAgreement = Value
            End Set
        End Property
        ' WilPayFee property
        Public Property WillPayFee() As Integer
            Get
                Return intWillPayFee
            End Get
            Set(ByVal Value As Integer)
                intWillPayFee = Value
            End Set
        End Property
        ' PaymentProvided
        Public Property PaymentProvided() As Integer
            Get
                Return intPaymentProvided
            End Get
            Set(ByVal Value As Integer)
                intPaymentProvided = Value
            End Set
        End Property
        ' ServiceType property
        Public Property ServiceType() As Integer
            Get
                Return intServiceType
            End Get
            Set(ByVal Value As Integer)
                intServiceType = Value
            End Set
        End Property
        ' Copyright Compliance property
        Public Property CopyrightCompliance() As Integer
            Get
                Return intCopyrightCompliance
            End Get
            Set(ByVal Value As Integer)
                intCopyrightCompliance = Value
            End Set
        End Property
        ' Priority property 
        Public Property Priority() As Integer
            Get
                Return intPriority
            End Get
            Set(ByVal Value As Integer)
                intPriority = Value
            End Set
        End Property
        ' PaymentType property
        Public Property PaymentType() As Integer
            Get
                Return intPaymentType
            End Get
            Set(ByVal Value As Integer)
                intPaymentType = Value
            End Set
        End Property
        ' ItemType property
        Public Property ItemType() As Integer
            Get
                Return intItemType
            End Get
            Set(ByVal Value As Integer)
                intItemType = Value
            End Set
        End Property
        ' Medium property 
        Public Property Medium() As Integer
            Get
                Return intMedium
            End Get
            Set(ByVal Value As Integer)
                intMedium = Value
            End Set
        End Property
        ' DelivMode property
        Public Property DelivMode() As Integer
            Get
                Return intDelivMode
            End Get
            Set(ByVal Value As Integer)
                intDelivMode = Value
            End Set
        End Property
        ' EDeliveryModeID property
        Public Property EDelivModeID() As Integer
            Get
                Return intEDelivModeID
            End Get
            Set(ByVal Value As Integer)
                intEDelivModeID = Value
            End Set
        End Property
        '  Alert property
        Public Property Alert() As Integer
            Get
                Return intAlert
            End Get
            Set(ByVal Value As Integer)
                intAlert = Value
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
        ' PatronName property
        Public Property PatronName() As String
            Get
                Return strPatronName
            End Get
            Set(ByVal Value As String)
                strPatronName = Value
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
        '  PatronGroupID
        Public Property PatronGroupID() As Integer
            Get
                Return intPatronGroupID
            End Get
            Set(ByVal Value As Integer)
                intPatronGroupID = Value
            End Set
        End Property

        '  Properties for ILL_LIBRARIES
        '  AccountNumber
        Public Property AccountNumber() As String
            Get
                Return strAccountNumber
            End Get
            Set(ByVal Value As String)
                strAccountNumber = Value
            End Set
        End Property

        '  PostDelivName 
        Public Property PostDelivName() As String
            Get
                Return strPostDelivName
            End Get
            Set(ByVal Value As String)
                strPostDelivName = Value
            End Set
        End Property
        '  PostDelivXAddress
        Public Property PostDelivXAddr() As String
            Get
                Return strPostDelivXAddr
            End Get
            Set(ByVal Value As String)
                strPostDelivXAddr = Value
            End Set
        End Property
        '  PostDelivStreet
        Public Property PostDelivStreet() As String
            Get
                Return strPostDelivStreet
            End Get
            Set(ByVal Value As String)
                strPostDelivStreet = Value
            End Set
        End Property
        '  PostDelivBox
        Public Property PostDelivBox() As String
            Get
                Return strPostDelivBox
            End Get
            Set(ByVal Value As String)
                strPostDelivBox = Value
            End Set
        End Property
        '  PostDelivCity
        Public Property PostDelivCity() As String
            Get
                Return strPostDelivCity
            End Get
            Set(ByVal Value As String)
                strPostDelivCity = Value
            End Set
        End Property
        '  PostDelivRegion
        Public Property PostDelivRegion() As String
            Get
                Return strPostDelivRegion
            End Get
            Set(ByVal Value As String)
                strPostDelivRegion = Value
            End Set
        End Property
        '  PostDelivCountry
        Public Property PostDelivCountry() As Integer
            Get
                Return intPostDelivCountry
            End Get
            Set(ByVal Value As Integer)
                intPostDelivCountry = Value
            End Set
        End Property
        '  PostDelivCode
        Public Property PostDelivCode() As String
            Get
                Return strPostDelivCode
            End Get
            Set(ByVal Value As String)
                strPostDelivCode = Value
            End Set
        End Property
        '  BillDelivName 
        Public Property BillDelivName() As String
            Get
                Return strBillDelivName
            End Get
            Set(ByVal Value As String)
                strBillDelivName = Value
            End Set
        End Property
        '  BillDelivXAddreass
        Public Property BillDelivXAddr() As String
            Get
                Return strBillDelivXAddr
            End Get
            Set(ByVal Value As String)
                strBillDelivXAddr = Value
            End Set
        End Property
        '  BillDelivStreet
        Public Property BillDelivStreet() As String
            Get
                Return strBillDelivStreet
            End Get
            Set(ByVal Value As String)
                strBillDelivStreet = Value
            End Set
        End Property
        '  BillDelivBox
        Public Property BillDelivBox() As String
            Get
                Return strBillDelivBox
            End Get
            Set(ByVal Value As String)
                strBillDelivBox = Value
            End Set
        End Property
        '  BillDelivCity
        Public Property BillDelivCity() As String
            Get
                Return strBillDelivCity
            End Get
            Set(ByVal Value As String)
                strBillDelivCity = Value
            End Set
        End Property
        '  BillDelivRegion
        Public Property BillDelivRegion() As String
            Get
                Return strBillDelivRegion
            End Get
            Set(ByVal Value As String)
                strBillDelivRegion = Value
            End Set
        End Property
        '  BillDelivCountry
        Public Property BillDelivCountry() As Integer
            Get
                Return intBillDelivCountry
            End Get
            Set(ByVal Value As Integer)
                intBillDelivCountry = Value
            End Set
        End Property
        '  BillDelivCode
        Public Property BillDelivCode() As String
            Get
                Return strBillDelivCode
            End Get
            Set(ByVal Value As String)
                strBillDelivCode = Value
            End Set
        End Property

        '  Properites for ILL_ITEMS
        '  CallNumber property
        Public Property CallNumber() As String
            Get
                Return strCallNumber
            End Get
            Set(ByVal Value As String)
                strCallNumber = Value
            End Set
        End Property
        '  Author property
        Public Property Author() As String
            Get
                Return strAuthor
            End Get
            Set(ByVal Value As String)
                strAuthor = Value
            End Set
        End Property
        ' PlaceOfPub property
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
                strPublisher = Value
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
        ' Article Title property
        Public Property ArticleTitle() As String
            Get
                Return strArticleTitle
            End Get
            Set(ByVal Value As String)
                strArticleTitle = Value
            End Set
        End Property
        ' Article Author property
        Public Property ArticleAuthor() As String
            Get
                Return strArticleAuthor
            End Get
            Set(ByVal Value As String)
                strArticleAuthor = Value
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
        ' NationalBibNumber
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
        ' SystemNumber property
        Public Property SystemNumber() As String
            Get
                Return strSystemNumber
            End Get
            Set(ByVal Value As String)
                strSystemNumber = Value
            End Set
        End Property
        ' Othernumbers property
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
        ' LocalNote property
        Public Property LocalNote() As String
            Get
                Return strLocalNote
            End Get
            Set(ByVal Value As String)
                strLocalNote = Value
            End Set
        End Property
        ' RequestType property
        Public Property RequestType() As Integer
            Get
                Return intRequestType
            End Get
            Set(ByVal Value As Integer)
                intRequestType = Value
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
        ' SubSQL property
        Public Property SubSQL() As String
            Get
                Return strSubSQL
            End Get
            Set(ByVal Value As String)
                strSubSQL = Value
            End Set
        End Property

        ' Return value property
        Public ReadOnly Property ReturnVal() As Integer
            Get
                Return intRetVal
            End Get
        End Property
        ' Return value property
        Public ReadOnly Property EncodeOk() As Boolean
            Get
                Return blnEncodeOk
            End Get
        End Property

        ' ***********************************************************************************************
        ' End declare properties
        ' Implement methods here
        ' ***********************************************************************************************
        '  Initialize Value method
        '  Pupose: Init variables are information need outrequest
        '  Creater: Tuanhv
        '  Date: 23/12/2004
        Public Sub InitValues()
            ' Init properties for table ILL_OUTGOING_REQUESTS
            strRequestID = ""
            intResponderID = -1
            strRequestDate = ""
            strCreatedDate = ""
            strNeedBeforeDate = ""
            strExpiredDate = ""
            strRespondDate = ""
            strCancelledDate = ""
            strShippedDate = ""
            strReceivedDate = ""
            strReturnedDate = ""
            strCheckedInDate = ""
            strDueDate = ""
            strLocalDueDate = ""
            strLocalCheckedInDate = ""
            strLocalCheckedOutDate = ""
            intRenewals = -1
            intLoanTypeID = -1
            strBarcode = ""
            intNoticePatron = -1
            dbCost = -1
            strCurrencyCode1 = ""
            dbInsuredForCost = -1
            strCurrencyCode2 = ""
            intReturnInsuranceCost = -1
            strCurrencyCode3 = ""
            intChageableUnits = -1
            dbMaxCost = -1
            strCurrencyCode = ""
            intStatus = -1
            strNote = ""
            intDeliveryLocID = -1
            intBillingLocID = -1
            intReciprocalAgreement = -1
            intWillPayFee = -1
            intPaymentProvided = -1
            intServiceType = -1
            intCopyrightCompliance = -1
            intPriority = -1
            intPaymentType = -1
            intItemType = -1
            intMedium = -1
            intDelivMode = -1
            intEDelivModeID = -1
            intAlert = -1
            strTitle = ""
            strPatronName = ""
            strPatronCode = ""
            intPatronGroupID = -1
            ' Init properties for table ILL_REQUEST_ITEMS
            strCallNumber = ""
            strAuthor = ""
            strPlaceOfPub = ""
            strPublisher = ""
            strSeriesTitleNumber = ""
            strVolumeIssue = ""
            strEdition = ""
            strPubDate = ""
            strComponentPubDate = ""
            strArticleAuthor = ""
            strArticleTitle = ""
            strPagination = ""
            strNationalBibNumber = ""
            strISBN = ""
            strISSN = ""
            strSystemNumber = ""
            strOtherNumbers = ""
            strVerification = ""
            strLocalNote = ""
            strSponsoringBody = ""
            ' Init properties for table ILL_LIBRARIES
            strAccountNumber = ""
            strPostDelivName = ""
            strPostDelivXAddr = ""
            strPostDelivStreet = ""
            strPostDelivBox = ""
            strPostDelivCity = ""
            strPostDelivRegion = ""
            intPostDelivCountry = -1
            strPostDelivCode = ""
            strBillDelivName = ""
            strBillDelivXAddr = ""
            strBillDelivStreet = ""
            strBillDelivBox = ""
            strBillDelivCity = ""
            strBillDelivRegion = ""
            intBillDelivCountry = -1
            strBillDelivCode = ""
            ' Init property for table Ill_OutGoing_Request_Log
            intIllID = -1
            strTransactionDate = ""
            intAPDUType = -1
            intReasonID = -1
            strResponderSpecReason = ""
            intSendShipped = 0
            intSendCheckedIn = 0
            intSendReceived = 0
            intSendReturned = 0
            intTRE = -1
            intAnswer = 0
            intLogID = 0
            strLocation = ""
            strReturnedVia = ""
            strTransportationMode = ""
            strSubSQL = "1 = 1"
        End Sub

        ' Initialize method
        ' Purpose: Init all neccessary objects
        Public Sub Initialize()
            Try
                ' Init objBCSP object
                objBCSP.InterfaceLanguage = strInterfaceLanguage
                objBCSP.DBServer = strDBServer
                objBCSP.ConnectionString = strConnectionString
                Call objBCSP.Initialize()

                ' Init objBILLTemplate object
                objBILLTemplate.DBServer = strDBServer
                objBILLTemplate.ConnectionString = strConnectionString
                objBILLTemplate.InterfaceLanguage = strInterfaceLanguage
                Call objBILLTemplate.Initialize()

                ' Init objBCDBS object
                objBCDBS.DBServer = strDBServer
                objBCDBS.ConnectionString = strConnectionString
                objBCDBS.InterfaceLanguage = strInterfaceLanguage
                Call objBCDBS.Initialize()

                ' Init objDILLOutRequest object
                objDILLOutRequest.DBServer = strDBServer
                objDILLOutRequest.ConnectionString = strConnectionString
                Call objDILLOutRequest.Initialize()

                ' Init  objBILLLibrary object
                objBILLLibrary.DBServer = strDBServer
                objBILLLibrary.ConnectionString = strConnectionString
                objBILLLibrary.InterfaceLanguage = strInterfaceLanguage
                Call objBILLLibrary.Initialize()

                Call GetSysPara()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' GetSysPara method
        Public Sub GetSysPara()
            Try
                objSysPara = objBCDBS.GetSystemParameters(objPara)
                strErrorMsg = objBCDBS.ErrorMsg
                intErrorCode = objBCDBS.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Private Sub GeneralParams()
            ' Declare variables
            Dim tblTemp As DataTable

            strProtocolVerNum = 1
            strSubTransactQualifier = "LIBOLILL"
            strTransactGroupQualifier = ""

            ' Set requester symbol and name
            objBCDBS.SQLStatement = "Select LibrarySymbol,LibraryName FROM ILL_LIBRARIES WHERE LocalLib=1"
            tblTemp = objBCDBS.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strRequesterSymbol = tblTemp.Rows(0).Item("LibrarySymbol")
                strRequesterName = tblTemp.Rows(0).Item("LibraryName")
            End If

            ' Set RequestID,Responder Symbol And name
            tblTemp = Nothing
            objBCDBS.SQLStatement = "Select B.LibrarySymbol,B.LibraryName,A.RequestID FROM ILL_OUTGOING_REQUESTS A JOIN ILL_LIBRARIES B ON B.ID = A.ResponderID WHERE A.ID=" & intIllID
            tblTemp = objBCDBS.RetrieveItemInfor
            If Not tblTemp Is Nothing AndAlso tblTemp.Rows.Count > 0 Then
                strResponderSymbol = tblTemp.Rows(0).Item("LibrarySymbol")
                strResponderName = tblTemp.Rows(0).Item("LibraryName")
                strRequestID = tblTemp.Rows(0).Item("RequestID")
            End If

            strServiceDate = CStr(Year(Now)) & CStr(Month(Now)).PadLeft(2, "0") & CStr(Day(Now)).PadLeft(2, "0")
            strServiceTime = CStr(Hour(Now)).PadLeft(2, "0") & CStr(Minute(Now)).PadLeft(2, "0") & CStr(Second(Now)).PadLeft(2, "0")
        End Sub

        Public Function IllreqXmlRecord() As String
            ' Declare variables
            Dim tblRequest As DataTable
            Dim strTemp As String

            Dim strSQL1 As String

            tblRequest = GetORInfor()

            If Not tblRequest Is Nothing Then
                If tblRequest.Rows.Count > 0 Then
                    If Not IsDBNull(tblRequest.Rows(0).Item("NEEDBEFOREDATE")) Then
                        strNBD = ToISODate(tblRequest.Rows(0).Item("NEEDBEFOREDATE"))
                    End If
                    If Not IsDBNull(tblRequest.Rows(0).Item("EXPIRYDATE")) Then
                        strED = ToISODate(tblRequest.Rows(0).Item("EXPIRYDATE"))
                    End If
                    Call GeneralParams()
                    strTemp = CreateHeader("ILLREQ")
                    strTemp = strTemp & "<transaction-type>1</transaction-type>" & vbCrLf
                    'Delivery Address
                    strTemp = strTemp & "<delivery-address>" & vbCrLf
                    If CInt(tblRequest.Rows(0).Item("DelivMode")) = 1 Then
                        'ElectronicAddress
                        strTemp = strTemp & "<electronic-address>" & vbCrLf
                        strTemp = strTemp & "<telecom-service-identifier>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("EDelivMode")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("EDelivMode")
                        End If
                        strTemp = strTemp & "</telecom-service-identifier>" & vbCrLf
                        strTemp = strTemp & "<telecom-service-address>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("EDelivTSAddr")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("EDelivTSAddr")
                        End If
                        strTemp = strTemp & "</telecom-service-address>" & vbCrLf
                        strTemp = strTemp & "</electronic-address>" & vbCrLf
                    Else
                        'PostalAddress
                        strTemp = strTemp & "<postal-address>" & vbCrLf
                        strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostDelivName")) Then
                            strTemp = strTemp & "<name-of-institution>" & tblRequest.Rows(0).Item("PostDelivName") & "</name-of-institution>" & vbCrLf
                        Else
                            strTemp = strTemp & "<name-of-institution>Unknown</name-of-institution>" & vbCrLf
                        End If
                        strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
                        strTemp = strTemp & "<extended-postal-delivery-address>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostDelivXAddr")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PostDelivXAddr")
                        End If
                        strTemp = strTemp & "</extended-postal-delivery-address>" & vbCrLf
                        strTemp = strTemp & "<street-and-number>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostDelivStreet")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PostDelivStreet")
                        End If
                        strTemp = strTemp & "</street-and-number>" & vbCrLf
                        strTemp = strTemp & "<post-office-box>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostDelivBox")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PostDelivBox")
                        End If
                        strTemp = strTemp & "</post-office-box>" & vbCrLf
                        strTemp = strTemp & "<city>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostDelivCity")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PostDelivCity")
                        End If
                        strTemp = strTemp & "</city>" & vbCrLf
                        strTemp = strTemp & "<region>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostDelivRegion")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PostDelivRegion")
                        End If
                        strTemp = strTemp & "</region>" & vbCrLf
                        strTemp = strTemp & "<country>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostCountry")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PostCountry")
                        End If
                        strTemp = strTemp & "</country>" & vbCrLf
                        strTemp = strTemp & "<postal-code>"
                        If Not IsDBNull(tblRequest.Rows(0).Item("PostDelivCode")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PostDelivCode")
                        End If
                        strTemp = strTemp & "</postal-code>" & vbCrLf
                        strTemp = strTemp & "</postal-address>" & vbCrLf
                    End If
                    strTemp = strTemp & "</delivery-address>" & vbCrLf

                    ' hien tai chua xac dinh dc the nay co su dung khong

                    'strTemp = strTemp & "<delivery-service>" & vbCrLf
                    'strTemp = strTemp & "</delivery-service>" & vbCrLf

                    '''''''''''''''''''''''''''''''''''''

                    strTemp = strTemp & "<billing-address>" & vbCrLf
                    strTemp = strTemp & "<postal-address>" & vbCrLf
                    strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillDelivName")) Then
                        strTemp = strTemp & "<name-of-institution>" & tblRequest.Rows(0).Item("BillDelivName") & "</name-of-institution>" & vbCrLf
                    Else
                        strTemp = strTemp & "<name-of-institution>Unknown</name-of-institution>" & vbCrLf
                    End If
                    strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
                    strTemp = strTemp & "<extended-postal-delivery-address>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillDelivXAddr")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("BillDelivXAddr")
                    End If
                    strTemp = strTemp & "</extended-postal-delivery-address>" & vbCrLf
                    strTemp = strTemp & "<street-and-number>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillDelivStreet")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("BillDelivStreet")
                    End If
                    strTemp = strTemp & "</street-and-number>" & vbCrLf
                    strTemp = strTemp & "<post-office-box>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillDelivBox")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("BillDelivBox")
                    End If
                    strTemp = strTemp & "</post-office-box>" & vbCrLf
                    strTemp = strTemp & "<city>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillDelivCity")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("BillDelivCity")
                    End If
                    strTemp = strTemp & "</city>" & vbCrLf
                    strTemp = strTemp & "<region>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillDelivRegion")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("BillDelivRegion")
                    End If
                    strTemp = strTemp & "</region>" & vbCrLf
                    strTemp = strTemp & "<country>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillCountry")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("BillCountry")
                    End If
                    strTemp = strTemp & "</country>" & vbCrLf
                    strTemp = strTemp & "<postal-code>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("BillDelivCode")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("BillDelivCode")
                    End If
                    strTemp = strTemp & "</postal-code>" & vbCrLf
                    strTemp = strTemp & "</postal-address>" & vbCrLf
                    strTemp = strTemp & "</billing-address>" & vbCrLf
                    strTemp = strTemp & "<ill-service-type>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("ServiceType")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("ServiceType")
                    Else
                        strTemp = strTemp & "1"
                    End If
                    strTemp = strTemp & "</ill-service-type>" & vbCrLf

                    strTemp = strTemp & "<requester-optional-messages>" & vbCrLf
                    strTemp = strTemp & "<can-send-received>1</can-send-received>" & vbCrLf
                    strTemp = strTemp & "<can-send-returned>1</can-send-returned>" & vbCrLf
                    strTemp = strTemp & "<requester-shipped>2</requester-shipped>" & vbCrLf
                    strTemp = strTemp & "<requester-checked-in>2</requester-checked-in>" & vbCrLf
                    strTemp = strTemp & "</requester-optional-messages>" & vbCrLf
                    strTemp = strTemp & "<search-type>" & vbCrLf
                    strTemp = strTemp & "<level-of-service></level-of-service>" & vbCrLf
                    strTemp = strTemp & "<need-before-date>" & strNBD & "</need-before-date>" & vbCrLf
                    If Not strNBD = "" Then
                        strTemp = strTemp & "<expiry-flag>1</expiry-flag>" & vbCrLf
                    Else
                        If Not strED = "" Then
                            strTemp = strTemp & "<expiry-flag>2</expiry-flag>" & vbCrLf
                        Else
                            strTemp = strTemp & "<expiry-flag>3</expiry-flag>" & vbCrLf
                        End If
                    End If
                    strTemp = strTemp & "<expiry-date>" & strED & "</expiry-date>" & vbCrLf
                    strTemp = strTemp & "</search-type>" & vbCrLf
                    strTemp = strTemp & "<supply-medium-info-type>" & vbCrLf
                    strTemp = strTemp & "<supply-medium-type>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Medium")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Medium")
                    End If
                    strTemp = strTemp & "</supply-medium-type>" & vbCrLf
                    strTemp = strTemp & "<medium-characteristics>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("MediumDisplay")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("MediumDisplay")
                    End If
                    strTemp = strTemp & "</medium-characteristics>" & vbCrLf
                    strTemp = strTemp & "</supply-medium-info-type>" & vbCrLf
                    strTemp = strTemp & "<place-on-hold>" & tblRequest.Rows(0).Item("Priority") & "</place-on-hold>" & vbCrLf
                    strTemp = strTemp & "<client-id>" & vbCrLf
                    strTemp = strTemp & "<client-name>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("PatronName")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("PatronName")
                    End If
                    strTemp = strTemp & "</client-name>" & vbCrLf
                    strTemp = strTemp & "<client-identifier>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("PatronCode")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("PatronCode")
                    End If
                    strTemp = strTemp & "</client-identifier>" & vbCrLf
                    strTemp = strTemp & "<client-status>"
                    If strDBServer = "ORACLE" Then
                        If Not IsDBNull(tblRequest.Rows(0).Item("PATRONGROUP")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PATRONGROUP")
                        End If
                    Else
                        If Not IsDBNull(tblRequest.Rows(0).Item("PATRONGROUP")) Then
                            strTemp = strTemp & tblRequest.Rows(0).Item("PATRONGROUP")
                        End If
                    End If
                    strTemp = strTemp & "</client-status>" & vbCrLf
                    strTemp = strTemp & "</client-id>" & vbCrLf
                    strTemp = strTemp & "<item-id>" & vbCrLf
                    strTemp = strTemp & "<item-type>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("ItemType")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("ItemType")
                    Else
                        strTemp = strTemp & "1"
                    End If
                    strTemp = strTemp & "</item-type>" & vbCrLf
                    strTemp = strTemp & "<held-medium-type></held-medium-type>" & vbCrLf
                    strTemp = strTemp & "<call-number>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("CallNumber")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("CallNumber")
                    End If
                    strTemp = strTemp & "</call-number>" & vbCrLf
                    strTemp = strTemp & "<author>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Author")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Author")
                    End If
                    strTemp = strTemp & "</author>" & vbCrLf
                    strTemp = strTemp & "<title>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Title")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Title")
                    End If
                    strTemp = strTemp & "</title>" & vbCrLf
                    strTemp = strTemp & "<sub-title></sub-title>" & vbCrLf
                    strTemp = strTemp & "<sponsoring-body>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("SponsoringBody")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("SponsoringBody")
                    End If
                    strTemp = strTemp & "</sponsoring-body>" & vbCrLf
                    strTemp = strTemp & "<place-of-publication>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("PlaceOfPub")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("PlaceOfPub")
                    End If
                    strTemp = strTemp & "</place-of-publication>" & vbCrLf
                    strTemp = strTemp & "<publisher>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Publisher")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Publisher")
                    End If
                    strTemp = strTemp & "</publisher>" & vbCrLf
                    strTemp = strTemp & "<series-title-number>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("SeriesTitleNumber")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("SeriesTitleNumber")
                    End If
                    strTemp = strTemp & "</series-title-number>" & vbCrLf
                    strTemp = strTemp & "<volume-issue>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("VolumeIssue")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("VolumeIssue")
                    End If
                    strTemp = strTemp & "</volume-issue>" & vbCrLf
                    strTemp = strTemp & "<edition>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Edition")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Edition")
                    End If
                    strTemp = strTemp & "</edition>" & vbCrLf
                    strTemp = strTemp & "<publication-date>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("PUBDATE")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("PUBDATE")
                    End If
                    strTemp = strTemp & "</publication-date>" & vbCrLf
                    strTemp = strTemp & "<publication-date-of-component>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("COMPONENTPUBDATE")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("COMPONENTPUBDATE")
                    End If
                    strTemp = strTemp & "</publication-date-of-component>" & vbCrLf
                    strTemp = strTemp & "<author-of-article>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("ArticleAuthor")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("ArticleAuthor")
                    End If
                    strTemp = strTemp & "</author-of-article>" & vbCrLf
                    strTemp = strTemp & "<title-of-article>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("ArticleTitle")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("ArticleTitle")
                    End If
                    strTemp = strTemp & "</title-of-article>" & vbCrLf
                    strTemp = strTemp & "<pagination>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Pagination")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Pagination")
                    End If
                    strTemp = strTemp & "</pagination>" & vbCrLf
                    strTemp = strTemp & "<national-bibliography-no>" & vbCrLf
                    strTemp = strTemp & "<descriptor>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("NationalBibNumber")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("NationalBibNumber")
                    End If
                    strTemp = strTemp & "</descriptor>" & vbCrLf
                    strTemp = strTemp & "</national-bibliography-no>" & vbCrLf
                    strTemp = strTemp & "<isbn>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("ISBN")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("ISBN")
                    End If
                    strTemp = strTemp & "</isbn>" & vbCrLf
                    strTemp = strTemp & "<issn>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("ISSN")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("ISSN")
                    End If
                    strTemp = strTemp & "</issn>" & vbCrLf
                    strTemp = strTemp & "<system-no>" & vbCrLf
                    strTemp = strTemp & "<descriptor>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("SystemNumber")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("SystemNumber")
                    End If
                    strTemp = strTemp & "</descriptor>" & vbCrLf
                    strTemp = strTemp & "</system-no>" & vbCrLf
                    strTemp = strTemp & "<additional-no-letters>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("OtherNumbers")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("OtherNumbers")
                    End If
                    strTemp = strTemp & "</additional-no-letters>" & vbCrLf
                    strTemp = strTemp & "<verification-reference-source>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Verification")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Verification")
                    End If
                    strTemp = strTemp & "</verification-reference-source>" & vbCrLf
                    strTemp = strTemp & "</item-id>" & vbCrLf
                    strTemp = strTemp & "<cost-info-type>" & vbCrLf
                    strTemp = strTemp & "<account-number>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("AccountNumber")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("AccountNumber")
                    End If
                    strTemp = strTemp & "</account-number>" & vbCrLf
                    strTemp = strTemp & "<maximum-cost>" & vbCrLf
                    strTemp = strTemp & "<currency-code>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("CurrencyCode")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("CurrencyCode")
                    End If
                    strTemp = strTemp & "</currency-code>" & vbCrLf
                    strTemp = strTemp & "<monetary-value>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("MaxCost")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("MaxCost")
                    End If
                    strTemp = strTemp & "</monetary-value>" & vbCrLf
                    strTemp = strTemp & "</maximum-cost>" & vbCrLf
                    strTemp = strTemp & "<reciprocal-agreement>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("ReciprocalAgreement")) Then
                        strTemp = strTemp & Math.Abs(CInt(tblRequest.Rows(0).Item("ReciprocalAgreement")))
                    End If
                    strTemp = strTemp & "</reciprocal-agreement>" & vbCrLf
                    strTemp = strTemp & "<will-pay-fee>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("WillPayFee")) Then
                        strTemp = strTemp & Math.Abs(CInt(tblRequest.Rows(0).Item("WillPayFee")))
                    End If
                    strTemp = strTemp & "</will-pay-fee>" & vbCrLf
                    strTemp = strTemp & "<payment-provided>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("PaymentProvided")) Then
                        strTemp = strTemp & Math.Abs(CInt(tblRequest.Rows(0).Item("PaymentProvided")))
                    End If
                    strTemp = strTemp & "</payment-provided>" & vbCrLf
                    strTemp = strTemp & "</cost-info-type>" & vbCrLf
                    strTemp = strTemp & "<copyright-compliance>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("CopyrightCompliance")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("CopyrightCompliance")
                    End If
                    strTemp = strTemp & "</copyright-compliance>" & vbCrLf
                    ' gui tiep cho doi tac thu 3 neu doi tac thu 2 khong co
                    ' chua thuc hien chuc nang nay
                    ' strTemp = strTemp & "<third-party-info-type></third-party-info-type>" & vbCrLf
                    strTemp = strTemp & "<retry-flag>0</retry-flag>" & vbCrLf
                    strTemp = strTemp & "<forward-flag>0</forward-flag>" & vbCrLf
                    strTemp = strTemp & "<requester-note>"
                    If Not IsDBNull(tblRequest.Rows(0).Item("Note")) Then
                        strTemp = strTemp & tblRequest.Rows(0).Item("Note")
                    End If
                    strTemp = strTemp & "</requester-note>" & vbCrLf
                    strTemp = strTemp & "<forward-note></forward-note>" & vbCrLf
                    strTemp = strTemp & "</illapdu>" & vbCrLf
                End If
            End If
            tblRequest = Nothing
            IllreqXmlRecord = strTemp
        End Function

        Function CreateHeader(ByVal strAPDU As String)
            Dim strTemp As String
            'strTemp = "<?xml version=""1.0"" encoding=""utf-8""?>" & vbCrLf
            strTemp = "<?xml version=""1.0""?>" & vbCrLf
            strTemp = strTemp & "<illapdu type=""" & strAPDU & """ xmlns=""www.GREENHOUSE.com.vn/libol"">" & vbCrLf
            strTemp = strTemp & "<protocol-version-num>" & strProtocolVerNum & "</protocol-version-num>" & vbCrLf
            strTemp = strTemp & "<transaction-id>" & vbCrLf
            strTemp = strTemp & "<initial-requester-id>" & vbCrLf
            strTemp = strTemp & "<person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<institution-symbol>" & strRequesterSymbol & "</institution-symbol>" & vbCrLf
            strTemp = strTemp & "</person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "<name-of-institution>" & strRequesterName & "</name-of-institution>" & vbCrLf
            strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "</initial-requester-id>" & vbCrLf
            strTemp = strTemp & "<transaction-group-qualifier>" & strTransactGroupQualifier & "</transaction-group-qualifier>" & vbCrLf
            strTemp = strTemp & "<transaction-qualifier>" & strRequestID & "</transaction-qualifier>" & vbCrLf
            strTemp = strTemp & "<sub-transaction-qualifier>" & strSubTransactQualifier & "</sub-transaction-qualifier>" & vbCrLf
            strTemp = strTemp & "</transaction-id>" & vbCrLf
            strTemp = strTemp & "<service-date-time>" & vbCrLf
            strTemp = strTemp & "<date-time-of-this-service>" & vbCrLf
            strTemp = strTemp & "<date>" & strServiceDate & "</date>" & vbCrLf
            strTemp = strTemp & "<time>" & strServiceTime & "</time>" & vbCrLf
            strTemp = strTemp & "</date-time-of-this-service>" & vbCrLf
            strTemp = strTemp & "<date-time-of-original-service>" & vbCrLf
            strTemp = strTemp & "<date></date>" & vbCrLf
            strTemp = strTemp & "<time></time>" & vbCrLf
            strTemp = strTemp & "</date-time-of-original-service>" & vbCrLf
            strTemp = strTemp & "</service-date-time>" & vbCrLf
            strTemp = strTemp & "<requester-id>" & vbCrLf
            strTemp = strTemp & "<person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<institution-symbol>" & strRequesterSymbol & "</institution-symbol>" & vbCrLf
            strTemp = strTemp & "</person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "<name-of-institution>" & strRequesterName & "</name-of-institution>" & vbCrLf
            strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "</requester-id>" & vbCrLf
            strTemp = strTemp & "<responder-id>" & vbCrLf
            strTemp = strTemp & "<person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<institution-symbol>" & strResponderSymbol & "</institution-symbol>" & vbCrLf
            strTemp = strTemp & "</person-or-institution-symbol>" & vbCrLf
            strTemp = strTemp & "<name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "<name-of-institution>" & strResponderName & "</name-of-institution>" & vbCrLf
            strTemp = strTemp & "</name-of-person-or-institution>" & vbCrLf
            strTemp = strTemp & "</responder-id>" & vbCrLf
            CreateHeader = strTemp
        End Function

        Public Function ConrepXmlRecord(ByVal intAnswer As Integer, ByVal strNote As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("CONREP")
            Str = Str & "<answer>" & intAnswer & "</answer>" & vbCrLf
            Str = Str & "<requester-note>" & objBCSP.ConvertIt(strNote) & "</requester-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            ConrepXmlRecord = Str
        End Function

        Function CancelXmlRecord(ByVal strNote As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("CANCEL")
            Str = Str & "<requester-note>" & objBCSP.ConvertIt(strNote) & "</requester-note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            CancelXmlRecord = Str
        End Function

        Function MessageXmlRecord(ByVal strNote As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("MESSAG")
            Str = Str & "<note>" & objBCSP.ConvertIt(strNote) & "</note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            MessageXmlRecord = Str
        End Function

        Function StatusXmlRecord(ByVal strNote As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("STATUS")
            Str = Str & "<note>" & objBCSP.ConvertIt(strNote) & "</note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            StatusXmlRecord = Str
        End Function

        ' SendMail function
        ' Purpose: send strmail to customer
        ' Input: some infor of message
        ' Output: int value (0 when success)
        Public Function GetEmailInfor(ByVal strServerPath As String, ByVal strContent As String, ByRef strEmailFrom As String, ByRef strEmailTo As String, ByRef strContentOut As String, Optional ByVal intEndC As Integer = 0, Optional ByVal blnEnCode As Boolean = True) As Integer
            ' Declare variables
            Dim tblTemp As DataTable
            Dim tblLocalLibMail As DataTable
            Dim strFileName As String
            Dim intEnCode As Integer
            Dim strOut As String = ""

            Try
                blnEncodeOk = True

                '  Get local lib email
                objBILLLibrary.LibID = 0
                tblLocalLibMail = objBILLLibrary.GetLib(1)

                If Not tblLocalLibMail Is Nothing Then
                    If tblLocalLibMail.Rows.Count > 0 Then
                        strEmailFrom = tblLocalLibMail.Rows(0).Item("EmailReplyAddress").ToString.Trim
                    End If
                End If

                ' get email reply address
                ' Get Destination Email Address
                If strEmailTo = "" Then
                    tblLocalLibMail = Nothing
                    objBILLLibrary.LibID = intResponderID
                    tblLocalLibMail = objBILLLibrary.GetLib(-1)
                    If Not tblLocalLibMail Is Nothing AndAlso tblLocalLibMail.Rows.Count > 0 Then
                        If tblLocalLibMail.Rows(0).Item("EncodingScheme").ToString.Trim = "" Then
                            intEnCode = 0
                        Else
                            intEnCode = tblLocalLibMail.Rows(0).Item("EncodingScheme").ToString.Trim
                        End If
                        strEmailTo = tblLocalLibMail.Rows(0).Item("EmailReplyAddress").ToString.Trim
                    End If
                Else
                    intEnCode = intEndC
                End If

                ' EnCode to BASE 64 or not
                If intEnCode = 1 And blnEnCode Then
                    objBCDBS.Extension = "XML"
                    strFileName = strServerPath & "\" & objBCDBS.GenRandomFile
                    Dim ObjOut = New StreamWriter(strFileName)
                    strContent = objBCSP.CutVietnameseAccent(strContent)
                    ObjOut.Write(strContent)
                    ObjOut.Close()
                    ObjOut = Nothing
                    Try
                        Dim objILL As New ILLCOMLib.core
                        Dim i As Integer = 0
                        Dim itry As Integer = 10
                        Dim strDecode As String
                        blnEncodeOk = False
                        While i < itry
                            strOut = objILL.BEREncode(strFileName)
                            strDecode = objILL.BERDecode(strOut)
                            If strDecode.ToLower <> "errdecode" Then
                                i = itry
                                blnEncodeOk = True
                            End If
                            i = i + 1
                        End While
                        objILL = Nothing
                    Catch ex As Exception
                        strOut = ""
                    End Try

                    If blnEncodeOk Then
                        strContent = strOut
                        ' Delete file
                        Dim objFileInfor As FileInfo
                        objFileInfor = New FileInfo(strFileName)

                        If objFileInfor.Exists Then
                            objFileInfor.Delete()
                        End If
                        objFileInfor = Nothing
                    End If
                End If

                If Trim(strContent) <> "" Then
                    strContentOut = strContent
                    GetEmailInfor = 0
                Else
                    strerrormsg = "The body is incorrect"
                    GetEmailInfor = 1
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
                GetEmailInfor = 1
            End Try
        End Function

        Public Function CreateOR() As Integer
            Try
                ' ILL_OUTGOING_REQUESTS
                objDILLOutRequest.ResponderID = intResponderID
                objDILLOutRequest.CreatedDate = objBCDBS.ConvertDateBack(strCreatedDate)
                objDILLOutRequest.NeedBeforeDate = objBCDBS.ConvertDateBack(strNeedBeforeDate)
                objDILLOutRequest.ExpiredDate = objBCDBS.ConvertDateBack(strExpiredDate)
                objDILLOutRequest.NoticePatron = intNoticePatron
                objDILLOutRequest.MaxCost = dbMaxCost
                objDILLOutRequest.CurrencyCode = objBCSP.ConvertItBack(strCurrencyCode)
                objDILLOutRequest.Statust = intStatus
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.DeliveryLocID = intDeliveryLocID
                objDILLOutRequest.BillingLocID = intBillingLocID
                objDILLOutRequest.ReciprocalAgreement = intReciprocalAgreement
                objDILLOutRequest.WillPayFee = intWillPayFee
                objDILLOutRequest.PaymentProvided = intPaymentProvided
                objDILLOutRequest.ServiceType = intServiceType
                objDILLOutRequest.CopyrightCompliance = intCopyrightCompliance
                objDILLOutRequest.Priority = intPriority
                objDILLOutRequest.PaymentType = intPaymentType
                objDILLOutRequest.ItemType = intItemType
                objDILLOutRequest.Medium = intMedium
                objDILLOutRequest.DelivMode = intDelivMode
                objDILLOutRequest.EDelivModeID = intEDelivModeID
                objDILLOutRequest.Title = objBCSP.ConvertItBack(strTitle)
                objDILLOutRequest.PatronName = objBCSP.ConvertItBack(strPatronName)
                objDILLOutRequest.PatronCode = objBCSP.ConvertItBack(strPatronCode)
                objDILLOutRequest.PatronGroupID = intPatronGroupID
                ' ILL_REQUEST_ITEMS
                objDILLOutRequest.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDILLOutRequest.Author = objBCSP.ConvertItBack(strAuthor)
                objDILLOutRequest.PlaceOfPub = objBCSP.ConvertItBack(strPlaceOfPub)
                objDILLOutRequest.Publisher = objBCSP.ConvertItBack(strPublisher)
                objDILLOutRequest.SeriesTitleNumber = objBCSP.ConvertItBack(strSeriesTitleNumber)
                objDILLOutRequest.ComponentPubDate = objBCDBS.ConvertDateBack(strComponentPubDate)
                objDILLOutRequest.VolumeIssue = objBCSP.ConvertItBack(strVolumeIssue)
                objDILLOutRequest.Edition = objBCSP.ConvertItBack(strEdition)
                objDILLOutRequest.PubDate = objBCDBS.ConvertDateBack(strPubDate)
                objDILLOutRequest.ArticleAuthor = objBCSP.ConvertItBack(strArticleAuthor)
                objDILLOutRequest.ArticleTitle = objBCSP.ConvertItBack(strArticleTitle)
                objDILLOutRequest.Pagination = objBCSP.ConvertItBack(strPagination)
                objDILLOutRequest.NationalBibNumber = objBCSP.ConvertItBack(strNationalBibNumber)
                objDILLOutRequest.ISBN = objBCSP.ConvertItBack(strISBN)
                objDILLOutRequest.ISSN = objBCSP.ConvertItBack(strISSN)
                objDILLOutRequest.SystemNumber = objBCSP.ConvertItBack(strSystemNumber)
                objDILLOutRequest.OtherNumbers = objBCSP.ConvertItBack(strOtherNumbers)
                objDILLOutRequest.Verification = objBCSP.ConvertItBack(strVerification)
                objDILLOutRequest.LocalNote = objBCSP.ConvertItBack(strLocalNote)
                objDILLOutRequest.RequestType = intRequestType
                objDILLOutRequest.SponsoringBody = objBCSP.ConvertItBack(strSponsoringBody)
                CreateOR = objDILLOutRequest.CreateOR()
                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetORInfor() As DataTable
            Try
                objDILLOutRequest.IllID = intIllID
                GetORInfor = objBCDBS.ConvertTable(objDILLOutRequest.GetORInfor)
                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetORItem() As DataTable
            Try
                objDILLOutRequest.IllID = intIllID
                GetORItem = objBCDBS.ConvertTable(objDILLOutRequest.GetORItem)
                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetILLOutRequestNum(ByVal lngTopNum As Long, ByRef lngTotalRec As Long, ByRef lngCurrentPos As Long) As DataTable
            Try
                objDILLOutRequest.IllID = intIllID
                GetILLOutRequestNum = objBCDBS.ConvertTable(objDILLOutRequest.GetILLOutRequestNum(lngTopNum, lngTotalRec, lngCurrentPos))
                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function DoublicateOR() As Integer
            Try
                ' ILL_OUTGOING_REQUESTS
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.ResponderID = intResponderID
                objDILLOutRequest.NeedBeforeDate = objBCDBS.ConvertDateBack(strNeedBeforeDate)
                objDILLOutRequest.ExpiredDate = objBCDBS.ConvertDateBack(strExpiredDate)
                objDILLOutRequest.NoticePatron = intNoticePatron
                objDILLOutRequest.MaxCost = dbMaxCost
                objDILLOutRequest.CurrencyCode = objBCSP.ConvertItBack(strCurrencyCode)
                objDILLOutRequest.Statust = intStatus
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.DeliveryLocID = intDeliveryLocID
                objDILLOutRequest.BillingLocID = intBillingLocID
                objDILLOutRequest.ReciprocalAgreement = intReciprocalAgreement
                objDILLOutRequest.WillPayFee = intWillPayFee
                objDILLOutRequest.PaymentProvided = intPaymentProvided
                objDILLOutRequest.ServiceType = intServiceType
                objDILLOutRequest.CopyrightCompliance = intCopyrightCompliance
                objDILLOutRequest.Priority = intPriority
                objDILLOutRequest.PaymentType = intPaymentType
                objDILLOutRequest.ItemType = intItemType
                objDILLOutRequest.Medium = intMedium
                objDILLOutRequest.DelivMode = intDelivMode
                objDILLOutRequest.EDelivModeID = intEDelivModeID
                objDILLOutRequest.Title = objBCSP.ConvertItBack(strTitle)
                objDILLOutRequest.PatronName = objBCSP.ConvertItBack(strPatronName)
                objDILLOutRequest.PatronCode = objBCSP.ConvertItBack(strPatronCode)
                objDILLOutRequest.PatronGroupID = intPatronGroupID
                '  ILL_LIBRARIES
                objDILLOutRequest.AccountNumber = objBCSP.ConvertItBack(strAccountNumber)
                objDILLOutRequest.PostDelivName = objBCSP.ConvertItBack(strPostDelivName)
                objDILLOutRequest.PostDelivXAddr = objBCSP.ConvertItBack(strPostDelivXAddr)
                objDILLOutRequest.PostDelivStreet = objBCSP.ConvertItBack(strPostDelivStreet)
                objDILLOutRequest.PostDelivBox = objBCSP.ConvertItBack(strPostDelivBox)
                objDILLOutRequest.PostDelivCity = objBCSP.ConvertItBack(strPostDelivCity)
                objDILLOutRequest.PostDelivRegion = objBCSP.ConvertItBack(strPostDelivRegion)
                objDILLOutRequest.PostDelivCountry = intPostDelivCountry
                objDILLOutRequest.PostDelivCode = objBCSP.ConvertItBack(strPostDelivCode)
                objDILLOutRequest.BillDelivName = objBCSP.ConvertItBack(strBillDelivName)
                objDILLOutRequest.BillDelivXAddr = objBCSP.ConvertItBack(strBillDelivXAddr)
                objDILLOutRequest.BillDelivStreet = objBCSP.ConvertItBack(strBillDelivStreet)
                objDILLOutRequest.BillDelivBox = objBCSP.ConvertItBack(strBillDelivBox)
                objDILLOutRequest.BillDelivCity = objBCSP.ConvertItBack(strBillDelivCity)
                objDILLOutRequest.BillDelivRegion = objBCSP.ConvertItBack(strBillDelivRegion)
                objDILLOutRequest.BillDelivCountry = intBillDelivCountry
                objDILLOutRequest.BillDelivCode = objBCSP.ConvertItBack(strBillDelivCode)
                ' ILL_REQUEST_ITEMS
                objDILLOutRequest.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDILLOutRequest.Author = objBCSP.ConvertItBack(strAuthor)
                objDILLOutRequest.PlaceOfPub = objBCSP.ConvertItBack(strPlaceOfPub)
                objDILLOutRequest.Publisher = objBCSP.ConvertItBack(strPublisher)
                objDILLOutRequest.SeriesTitleNumber = objBCSP.ConvertItBack(strSeriesTitleNumber)
                objDILLOutRequest.ComponentPubDate = objBCDBS.ConvertDateBack(strComponentPubDate)
                objDILLOutRequest.VolumeIssue = objBCSP.ConvertItBack(strVolumeIssue)
                objDILLOutRequest.Edition = objBCSP.ConvertItBack(strEdition)
                objDILLOutRequest.PubDate = objBCDBS.ConvertDateBack(strPubDate)
                objDILLOutRequest.ArticleAuthor = objBCSP.ConvertItBack(strArticleAuthor)
                objDILLOutRequest.ArticleTitle = objBCSP.ConvertItBack(strArticleTitle)
                objDILLOutRequest.Pagination = objBCSP.ConvertItBack(strPagination)
                objDILLOutRequest.NationalBibNumber = objBCSP.ConvertItBack(strNationalBibNumber)
                objDILLOutRequest.ISBN = objBCSP.ConvertItBack(strISBN)
                objDILLOutRequest.ISSN = objBCSP.ConvertItBack(strISSN)
                objDILLOutRequest.SystemNumber = objBCSP.ConvertItBack(strSystemNumber)
                objDILLOutRequest.OtherNumbers = objBCSP.ConvertItBack(strOtherNumbers)
                objDILLOutRequest.Verification = objBCSP.ConvertItBack(strVerification)
                objDILLOutRequest.LocalNote = objBCSP.ConvertItBack(strLocalNote)
                objDILLOutRequest.RequestType = intRequestType
                objDILLOutRequest.SponsoringBody = objBCSP.ConvertItBack(strSponsoringBody)
                DoublicateOR = objDILLOutRequest.UpdateOR()
                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub CancelOR()
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.CancelOR()
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Function LostitXmlRecord(ByVal Note As String) As String
            Dim Str As String
            Call GeneralParams()
            Str = CreateHeader("LOSTIT")
            Str = Str & "<note>" & strNote & "</note>" & vbCrLf
            Str = Str & "</illapdu>" & vbCrLf
            LostitXmlRecord = Str
        End Function

        Public Function RceivdXmlRecord(ByVal strRceivdDate As String, ByVal strServiceType As String, ByVal strNote As String, ByVal ILLID As Integer)
            Dim StrXml As String
            Call GeneralParams()
            strRceivdDate = ToISODate(strRceivdDate)
            StrXml = CreateHeader("RCEIVD")
            StrXml = StrXml & "<supplier-id>" & vbCrLf
            StrXml = StrXml & "<person-or-institution-symbol>" & vbCrLf
            StrXml = StrXml & "<institution-symbol>" & strResponderSymbol & "</institution-symbol>" & vbCrLf
            StrXml = StrXml & "</person-or-institution-symbol>" & vbCrLf
            StrXml = StrXml & "<name-of-person-or-institution>" & vbCrLf
            StrXml = StrXml & "<name-of-institution>" & strResponderName & "</name-of-institution>" & vbCrLf
            StrXml = StrXml & "</name-of-person-or-institution>" & vbCrLf
            StrXml = StrXml & "</supplier-id>" & vbCrLf
            StrXml = StrXml & "<date-received>" & strRceivdDate & "</date-received>" & vbCrLf
            StrXml = StrXml & "<shipped-service-type>" & strServiceType & "</shipped-service-type>" & vbCrLf
            StrXml = StrXml & "<requester-note>" & strNote & "</requester-note>" & vbCrLf
            StrXml = StrXml & "</illapdu>" & vbCrLf
            RceivdXmlRecord = StrXml
        End Function

        Public Function RetrndXmlRecord(ByVal strReturnedDate As String, ByVal strReturnedVia As String, ByVal strInsuredForCost As String, ByVal strCurrencyCode As String, ByVal strNote As String, ByVal intILLID As Integer) As String
            Dim StrXml As String
            Call GeneralParams()
            strReturnedDate = ToISODate(strReturnedDate)
            StrXml = CreateHeader("RETRND")
            StrXml = StrXml & "<date-returned>"
            StrXml = StrXml & strReturnedDate & vbCrLf
            StrXml = StrXml & "</date-returned>" & vbCrLf
            StrXml = StrXml & "<returned-via>" & strReturnedVia & "</returned-via>" & vbCrLf
            StrXml = StrXml & "<insured-for>" & vbCrLf
            StrXml = StrXml & "<currency-code>" & strCurrencyCode & "</currency-code>" & vbCrLf
            StrXml = StrXml & "<monetary-value>" & strInsuredForCost & "</monetary-value>" & vbCrLf
            StrXml = StrXml & "</insured-for>" & vbCrLf
            StrXml = StrXml & "<requester-note>" & strNote & "</requester-note>" & vbCrLf
            StrXml = StrXml & "</illapdu>" & vbCrLf
            RetrndXmlRecord = StrXml
        End Function

        Public Function RenewlXmlRecord(ByVal strDesiredDueDate, ByVal strNote) As String
            Dim StrXml As String
            Call GeneralParams()
            strDesiredDueDate = ToISODate(strDesiredDueDate)
            StrXml = CreateHeader("RENEWL")
            StrXml = StrXml & "<desired-due-date>" & strDesiredDueDate & "</desired-due-date>" & vbCrLf
            StrXml = StrXml & "<requester-note>" & strNote & "</requester-note>" & vbCrLf
            StrXml = StrXml & "</illapdu>" & vbCrLf
            RenewlXmlRecord = StrXml
        End Function

        ' ToISODate Date method
        ' Purpose: Convert the date time to the iso date format
        Function ToISODate(ByVal strInDate As String) As String
            Dim strRet As String
            Dim strTime As String
            Dim strDate As String
            Dim strTypeShow As String

            If Trim(strInDate) = "" Then
                ToISODate = ""
                Exit Function
            Else
                If Not objSysPara(3) & "" = "" Then
                    strTypeShow = objSysPara(3)
                Else
                    strTypeShow = "DD/MM/YYYY"
                End If
                Dim strInDay As String, strInMon As String, strInYear As String

                Select Case UCase(strTypeShow)
                    Case "DD/MM/YYYY"
                        strInDay = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInDate = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                        strInMon = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInYear = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                    Case "MM/DD/YYYY"
                        strInMon = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInDate = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                        strInDay = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInYear = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                    Case "YYYY/DD/MM"
                        strInYear = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInDate = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                        strInDay = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInMon = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                    Case "YYYY/MM/DD"
                        strInYear = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInDate = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                        strInMon = Left(strInDate, InStr(strInDate, "/") - 1)
                        strInDay = Right(strInDate, Len(strInDate) - InStr(strInDate, "/"))
                End Select
                ToISODate = strInYear & strInMon.PadLeft(2, "0") & strInDay.PadLeft(2, "0")
            End If
        End Function

        Public Function GetILLResponse() As DataTable
            Try
                GetILLResponse = objBCDBS.ConvertTable(objDILLOutRequest.GetILLResponse)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Sub SetValueVariables()
            objDILLOutRequest.IllID = intIllID
            objDILLOutRequest.ResponderID = intResponderID
            objDILLOutRequest.TransactionDate = strTransactionDate
            objDILLOutRequest.Note = strNote
            objDILLOutRequest.APDUType = intAPDUType
            objDILLOutRequest.ReasonID = intReasonID
            objDILLOutRequest.ProvidedDate = strProvidedDate
            objDILLOutRequest.ResponderSpecReason = strResponderSpecReason
            objDILLOutRequest.SendShipped = intSendShipped
            objDILLOutRequest.SendCheckedIn = intSendCheckedIn
            objDILLOutRequest.SendReceived = intSendReceived
            objDILLOutRequest.SendReturned = intSendReturned
            objDILLOutRequest.TRE = intTRE
            objDILLOutRequest.Medium = intMedium
            objDILLOutRequest.Cost = dbCost
            objDILLOutRequest.CurrencyCode1 = strCurrencyCode1
            objDILLOutRequest.Answer = intAnswer
            objDILLOutRequest.DueDate = strDueDate
            objDILLOutRequest.Renewable = intRenewable
            objDILLOutRequest.Alert = intAlert
            objDILLOutRequest.LogID = intLogID
            objDILLOutRequest.ServiceType = intServiceType
            objDILLOutRequest.Location = strLocation
            objDILLOutRequest.CopyrightCompliance = intCopyrightCompliance
            objDILLOutRequest.ReturnedVia = strReturnedVia
            objDILLOutRequest.InsuredForCost = dbInsuredForCost
            objDILLOutRequest.CurrencyCode2 = strCurrencyCode2
            objDILLOutRequest.ReturnInsuranceCost = dbReturnInsuranceCost
            objDILLOutRequest.CurrencyCode3 = strCurrencyCode3
            objDILLOutRequest.TransportationMode = strTransportationMode
        End Sub

        Function InsertORequestLog() As Integer
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.ResponderID = intResponderID
                objDILLOutRequest.TransactionDate = objBCDBS.ConvertDateBack(strTransactionDate)
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.APDUType = intAPDUType
                objDILLOutRequest.ReasonID = intReasonID
                objDILLOutRequest.ProvidedDate = objBCDBS.ConvertDateBack(strProvidedDate)
                objDILLOutRequest.ResponderSpecReason = objBCDBS.ConvertDateBack(strResponderSpecReason)
                objDILLOutRequest.SendShipped = intSendShipped
                objDILLOutRequest.SendCheckedIn = intSendCheckedIn
                objDILLOutRequest.SendReceived = intSendReceived
                objDILLOutRequest.SendReturned = intSendReturned
                objDILLOutRequest.TRE = intTRE
                objDILLOutRequest.Medium = intMedium
                objDILLOutRequest.Cost = dbCost
                objDILLOutRequest.CurrencyCode1 = objBCSP.ConvertItBack(strCurrencyCode1)
                objDILLOutRequest.Answer = intAnswer
                objDILLOutRequest.DueDate = objBCDBS.ConvertDateBack(strDueDate)
                objDILLOutRequest.Renewable = intRenewable
                objDILLOutRequest.Alert = intAlert
                objDILLOutRequest.ServiceType = intServiceType
                objDILLOutRequest.Location = objBCSP.ConvertItBack(strLocation)
                objDILLOutRequest.CopyrightCompliance = intCopyrightCompliance
                objDILLOutRequest.ReturnedVia = objBCSP.ConvertItBack(strReturnedVia)
                objDILLOutRequest.InsuredForCost = dbInsuredForCost
                objDILLOutRequest.CurrencyCode2 = objBCSP.ConvertItBack(strCurrencyCode2)
                objDILLOutRequest.ReturnInsuranceCost = dbReturnInsuranceCost
                objDILLOutRequest.CurrencyCode3 = objBCSP.ConvertItBack(strCurrencyCode3)
                objDILLOutRequest.TransportationMode = objBCSP.ConvertItBack(strTransportationMode)

                InsertORequestLog = objDILLOutRequest.InsertORequestLog()
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function DenyOR(ByVal intTemplateID As Integer, ByVal intTempType As Integer, ByVal strCauseResponse As String) As clsBILLTemplate.Metric
            Dim tblPatronInfor As New DataTable
            Dim tblResponseInfor As New DataTable

            Try
                ' Get all content of response
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.DenyOR(tblPatronInfor, tblResponseInfor)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
                ' Convert table
                tblPatronInfor = objBCDBS.ConvertTable(tblPatronInfor)
                tblResponseInfor = objBCDBS.ConvertTable(tblResponseInfor)
                ' Get content email and Emailaddress of patron
                mtx = objBILLTemplate.GenDenniedTemplate(intTempType, intIllID, tblPatronInfor, tblResponseInfor, intTemplateID, strCauseResponse)
                Return (mtx)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function UpdateOR() As Integer
            Try
                '  Initialize variables
                objDILLOutRequest.InitValues()

                ' ILL_OUTGOING_REQUESTS
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.ResponderID = intResponderID
                objDILLOutRequest.NeedBeforeDate = objBCDBS.ConvertDateBack(strNeedBeforeDate)
                objDILLOutRequest.RespondDate = objBCDBS.ConvertDateBack(strRespondDate)
                objDILLOutRequest.ExpiredDate = objBCDBS.ConvertDateBack(strExpiredDate)
                objDILLOutRequest.ReturnedDate = objBCDBS.ConvertDateBack(strReturnedDate)
                objDILLOutRequest.ShippedDate = objBCDBS.ConvertDateBack(strShippedDate)
                objDILLOutRequest.CheckedInDate = objBCDBS.ConvertDateBack(strCheckedInDate)
                objDILLOutRequest.ReceivedDate = objBCDBS.ConvertDateBack(strReceivedDate)
                objDILLOutRequest.ReceivedDate = objBCDBS.ConvertDateBack(strReceivedDate)
                objDILLOutRequest.DueDate = objBCDBS.ConvertDateBack(strDueDate)
                objDILLOutRequest.CancelledDate = objBCDBS.ConvertDateBack(strCancelledDate)
                objDILLOutRequest.LocalDueDate = objBCDBS.ConvertDateBack(strLocalDueDate)
                objDILLOutRequest.LocalCheckedOutDate = objBCDBS.ConvertDateBack(strLocalCheckedOutDate)
                objDILLOutRequest.LocalCheckedInDate = objBCDBS.ConvertDateBack(strLocalCheckedInDate)
                objDILLOutRequest.Renewals = intRenewals
                objDILLOutRequest.NoticePatron = intNoticePatron
                objDILLOutRequest.MaxCost = dbMaxCost
                objDILLOutRequest.CurrencyCode = objBCSP.ConvertItBack(strCurrencyCode)
                objDILLOutRequest.Statust = intStatus
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.DeliveryLocID = intDeliveryLocID
                objDILLOutRequest.BillingLocID = intBillingLocID
                objDILLOutRequest.ReciprocalAgreement = intReciprocalAgreement
                objDILLOutRequest.WillPayFee = intWillPayFee
                objDILLOutRequest.PaymentProvided = intPaymentProvided
                objDILLOutRequest.ServiceType = intServiceType
                objDILLOutRequest.CopyrightCompliance = intCopyrightCompliance
                objDILLOutRequest.Priority = intPriority
                objDILLOutRequest.PaymentType = intPaymentType
                objDILLOutRequest.ItemType = intItemType
                objDILLOutRequest.Medium = intMedium
                objDILLOutRequest.DelivMode = intDelivMode
                objDILLOutRequest.EDelivModeID = intEDelivModeID
                objDILLOutRequest.Title = objBCSP.ConvertItBack(strTitle)
                objDILLOutRequest.PatronName = objBCSP.ConvertItBack(strPatronName)
                objDILLOutRequest.PatronCode = objBCSP.ConvertItBack(strPatronCode)
                objDILLOutRequest.PatronGroupID = intPatronGroupID
                objDILLOutRequest.Renewable = intRenewable

                '  ILL_LIBRARIES
                objDILLOutRequest.AccountNumber = objBCSP.ConvertItBack(strAccountNumber)
                objDILLOutRequest.PostDelivName = objBCSP.ConvertItBack(strPostDelivName)
                objDILLOutRequest.PostDelivXAddr = objBCSP.ConvertItBack(strPostDelivXAddr)
                objDILLOutRequest.PostDelivStreet = objBCSP.ConvertItBack(strPostDelivStreet)
                objDILLOutRequest.PostDelivBox = objBCSP.ConvertItBack(strPostDelivBox)
                objDILLOutRequest.PostDelivCity = objBCSP.ConvertItBack(strPostDelivCity)
                objDILLOutRequest.PostDelivRegion = objBCSP.ConvertItBack(strPostDelivRegion)
                objDILLOutRequest.PostDelivCountry = intPostDelivCountry
                objDILLOutRequest.PostDelivCode = objBCSP.ConvertItBack(strPostDelivCode)
                objDILLOutRequest.BillDelivName = objBCSP.ConvertItBack(strBillDelivName)
                objDILLOutRequest.BillDelivXAddr = objBCSP.ConvertItBack(strBillDelivXAddr)
                objDILLOutRequest.BillDelivStreet = objBCSP.ConvertItBack(strBillDelivStreet)
                objDILLOutRequest.BillDelivBox = objBCSP.ConvertItBack(strBillDelivBox)
                objDILLOutRequest.BillDelivCity = objBCSP.ConvertItBack(strBillDelivCity)
                objDILLOutRequest.BillDelivRegion = objBCSP.ConvertItBack(strBillDelivRegion)
                objDILLOutRequest.BillDelivCountry = intBillDelivCountry
                objDILLOutRequest.BillDelivCode = objBCSP.ConvertItBack(strBillDelivCode)
                ' ILL_REQUEST_ITEMS
                objDILLOutRequest.CallNumber = objBCSP.ConvertItBack(strCallNumber)
                objDILLOutRequest.Author = objBCSP.ConvertItBack(strAuthor)
                objDILLOutRequest.PlaceOfPub = objBCSP.ConvertItBack(strPlaceOfPub)
                objDILLOutRequest.Publisher = objBCSP.ConvertItBack(strPublisher)
                objDILLOutRequest.SeriesTitleNumber = objBCSP.ConvertItBack(strSeriesTitleNumber)
                objDILLOutRequest.ComponentPubDate = objBCDBS.ConvertDateBack(strComponentPubDate)
                objDILLOutRequest.VolumeIssue = objBCSP.ConvertItBack(strVolumeIssue)
                objDILLOutRequest.Edition = objBCSP.ConvertItBack(strEdition)
                objDILLOutRequest.PubDate = objBCDBS.ConvertDateBack(strPubDate)
                objDILLOutRequest.ArticleAuthor = objBCSP.ConvertItBack(strArticleAuthor)
                objDILLOutRequest.ArticleTitle = objBCSP.ConvertItBack(strArticleTitle)
                objDILLOutRequest.Pagination = objBCSP.ConvertItBack(strPagination)
                objDILLOutRequest.NationalBibNumber = objBCSP.ConvertItBack(strNationalBibNumber)
                objDILLOutRequest.ISBN = objBCSP.ConvertItBack(strISBN)
                objDILLOutRequest.ISSN = objBCSP.ConvertItBack(strISSN)
                objDILLOutRequest.SystemNumber = objBCSP.ConvertItBack(strSystemNumber)
                objDILLOutRequest.OtherNumbers = objBCSP.ConvertItBack(strOtherNumbers)
                objDILLOutRequest.Verification = objBCSP.ConvertItBack(strVerification)
                objDILLOutRequest.LocalNote = objBCSP.ConvertItBack(strLocalNote)
                objDILLOutRequest.RequestType = intRequestType
                objDILLOutRequest.SponsoringBody = objBCSP.ConvertItBack(strSponsoringBody)
                objDILLOutRequest.SubSQL = strSubSQL
                UpdateOR = objDILLOutRequest.UpdateOR()

                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub ChangeORStatus(ByVal intType As Int16)
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.ChangeORStatus(intType)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function GetORHistoryInfor(Optional ByVal blHasMail As Boolean = False) As DataTable
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.Alert = -1
                If blHasMail Then
                    objDILLOutRequest.Alert = 1
                End If
                GetORHistoryInfor = objBCDBS.ConvertTable(objDILLOutRequest.GetORHistoryInfor, True)
                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub Renew(ByVal strDesiredDueDate As String, ByVal strNote As String, Optional ByVal lngLogID As Long = 0)
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.Renew(objBCDBS.ConvertDateBack(strDesiredDueDate), objBCSP.ConvertItBack(strNote), lngLogID)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function SendNoticePatron(ByVal intTemplateID As Integer, ByVal intTempType As Integer) As clsBILLTemplate.Metric
            Try
                Dim tblPatronInfor As New DataTable
                Dim tblResponseInfor As New DataTable
                ' Get all content of response
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.SendNoticePatron(tblPatronInfor, tblResponseInfor)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
                ' Convert table
                tblPatronInfor = objBCDBS.ConvertTable(tblPatronInfor)
                tblResponseInfor = objBCDBS.ConvertTable(tblResponseInfor)
                ' Get content email and Emailaddress of patron
                mtx = objBILLTemplate.GenNoticeTemplate(intTempType, intIllID, tblPatronInfor, tblResponseInfor, intTemplateID)
                'mtx = objBILLTemplate.GenNoticePatron(intTempType, intIllID, tblPatronInfor, tblResponseInfor, intTemplateID)
                Return (mtx)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub AnswerCondition(ByVal intAnser As Int16)
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.AnswerCondition(intAnser)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function DeleteOR() As Integer
            Try
                objDILLOutRequest.IllID = intIllID
                DeleteOR = objDILLOutRequest.DeleteOR
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub ChangeFolder()
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.ChangeFolder()
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strerrormsg = ex.Message
            End Try
        End Sub

        Public Sub SendRequest()
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.SendRequest()
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function SendOverDueMess(ByVal intTemplateID As Integer, ByVal intTempType As Integer) As clsBILLTemplate.Metric
            Try
                Dim tblPatronInfor As New DataTable
                ' Get all content of response
                objDILLOutRequest.IllID = intIllID
                ' Convert table
                tblPatronInfor = objBCDBS.ConvertTable(objDILLOutRequest.SendOverDueMess())
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
                ' Get content email and Emailaddress of patron
                mtx = objBILLTemplate.GenOverdueTemplate(intTempType, intIllID, tblPatronInfor, intTemplateID)
                Return (mtx)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetRequestIDByIndex(ByVal lngIndex As Long) As Long
            Try
                GetRequestIDByIndex = objDILLOutRequest.GetRequestIDByIndex(lngIndex)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetOutRequestResponseInfor(ByVal lngID As Long) As DataTable
            Try
                GetOutRequestResponseInfor = objBCDBS.ConvertTable(objDILLOutRequest.GetOutRequestResponseInfor(lngID), True)
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetItemType(Optional ByVal strTypeID As String = "") As DataTable
            Try
                GetItemType = objBCDBS.ConvertTable(objDILLOutRequest.GetItemType(""))
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetILLMediumTypes(Optional ByVal intID As Integer = 0) As DataTable
            Try
                GetILLMediumTypes = objBCDBS.ConvertTable(objDILLOutRequest.GetILLMediumTypes(intID))
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub AddORLog(ByVal intAPDU As Integer)
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                objDILLOutRequest.AddORLog(intAPDU)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        Public Function GetPatronGroup(Optional ByVal intID As Integer = 0) As DataTable
            Try
                GetPatronGroup = objBCDBS.ConvertTable(objDILLOutRequest.GetPatronGroup(intID))
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function SearchPatron(ByVal strPatronName As String, ByVal strPatronCode As String) As DataTable
            Try
                Dim tblPatron As New DataTable
                Dim inti As Integer
                tblPatron = objBCDBS.ConvertTable(objDILLOutRequest.SearchPatron(objBCSP.ConvertItBack(strPatronName), objBCSP.ConvertItBack(strPatronCode)))
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
                If Not tblPatron Is Nothing Then
                    If tblPatron.Rows.Count > 0 Then
                        For inti = 0 To tblPatron.Rows.Count - 1
                            tblPatron.Rows(inti).Item("ID") = inti + 1
                            tblPatron.Rows(inti).Item("Code") = "<U>" & "<A class=""lbLinkFunction"" HREF=" & """javascript:LoadBackPatron(' " & tblPatron.Rows(inti).Item("GroupID") & "' ,' " & tblPatron.Rows(inti).Item("FullName") & "' ,' " & tblPatron.Rows(inti).Item("Code") & "' )""" & ">" & tblPatron.Rows(inti).Item("Code") & "</A>" & "</U>"
                        Next
                    End If
                End If
                SearchPatron = tblPatron
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function GetORequestItems(ByVal intExpandInfor As Integer) As DataTable
            Try
                objDILLOutRequest.IllID = intIllID
                GetORequestItems = objBCDBS.ConvertTable(objDILLOutRequest.GetORequestItems(intExpandInfor))
                strErrorMsg = objDILLOutRequest.ErrorMsg
                intErrorCode = objDILLOutRequest.ErrorCode
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Function Get_ILL_OR_Renew_Log() As DataTable
            Try
                objDILLOutRequest.IllID = intIllID
                Get_ILL_OR_Renew_Log = objBCDBS.ConvertTable(objDILLOutRequest.Get_ILL_OR_Renew_Log)
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Function

        Public Sub InsertORequestDenied()
            Try
                objDILLOutRequest.IllID = intIllID
                objDILLOutRequest.RequestDate = objBCDBS.ConvertDateBack(strRequestDate)
                objDILLOutRequest.ResponderID = intResponderID
                objDILLOutRequest.ReasonID = intReasonID
                objDILLOutRequest.RespondDate = objBCDBS.ConvertDateBack(strRespondDate)
                objDILLOutRequest.Note = objBCSP.ConvertItBack(strNote)
                Call objDILLOutRequest.InsertORequestDenied()
                intErrorCode = objDILLOutRequest.ErrorCode
                strErrorMsg = objDILLOutRequest.ErrorMsg
            Catch ex As Exception
                strErrorMsg = ex.Message
            End Try
        End Sub

        ' Dispose method
        ' Purpose: Release all resource
        Public Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            Try
                If Not objBCSP Is Nothing Then
                    objBCSP.Dispose(True)
                    objBCSP = Nothing
                End If
                If Not objBCDBS Is Nothing Then
                    objBCDBS.Dispose(True)
                    objBCDBS = Nothing
                End If
                If Not objDILLOutRequest Is Nothing Then
                    objDILLOutRequest.Dispose(True)
                    objDILLOutRequest = Nothing
                End If
                If Not objBILLLibrary Is Nothing Then
                    objBILLLibrary.Dispose(True)
                    objBILLLibrary = Nothing
                End If
                If Not objBILLTemplate Is Nothing Then
                    objBILLTemplate.Dispose(True)
                    objBILLTemplate = Nothing
                End If
            Catch ex As Exception
                strErrorMsg = ex.Message
            Finally
                Dispose()
            End Try
        End Sub
    End Class
End Namespace